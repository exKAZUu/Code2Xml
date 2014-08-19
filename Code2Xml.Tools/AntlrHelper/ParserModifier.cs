#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Diagnostics.Contracts;
using System.IO;
using System.Text.RegularExpressions;
using Paraiba.Text;

namespace Code2Xml.Tools.AntlrHelper {
    public static class ParserModifier {
        private static readonly Regex SystemOutRegex =
                new Regex(@"System\.out\.println[^;]+;");

        private static readonly Regex NonTerminalRegex =
                new Regex(@"adaptor\.AddChild\(([^,]*), (.*)\.Tree\)");

        private static readonly Regex TerminalRegex =
                new Regex(@"adaptor\.Create\(([^),]*)\)");

        private static readonly Regex PrivateRegex =
                new Regex(@"private ([^.]*Parser)");

        private static readonly Regex TraceInRegex =
                new Regex(@"TraceIn\((.*), .*\)");

        public static void Modify(string path) {
            Contract.Requires(path != null);

            string code;
            using (var reader = new StreamReader(path, XEncoding.SJIS)) {
                code = reader.ReadToEnd();
                code = ModifyCommonTreeAdaptor(code);
                code = ModifyParserRuleReturnScope(code);
                code = ModifyAstParserRuleReturnScope(code);
                code = ModifyAddChild(code);
                code = ModifyCreate(code);
                code = ModifyTraceIn(code);
                code = ModifyInheritClass(code);
                //code = ModifyFromJavaToCSharp(code);
                //code = ModifyAccessModifier(code);
            }
            using (var writer = new StreamWriter(path, false, XEncoding.SJIS)) {
                writer.WriteLine("using Code2Xml.Languages.ANTLRv3.Core;");
                writer.WriteLine("using System;");
                writer.Write(code);
            }
        }

        public static string ModifyFromJavaToCSharp(string code) {
            Contract.Requires(code != null);

            return SystemOutRegex.Replace(code, "");
        }

        public static string ModifyCommonTreeAdaptor(string code) {
            Contract.Requires(code != null);

            return code
                    .Replace("ITreeAdaptor", "CstBuilderForAntlr3")
                    .Replace("CommonTreeAdaptor", "CstBuilderForAntlr3");
        }

        public static string ModifyParserRuleReturnScope(string code) {
            Contract.Requires(code != null);

            return code.Replace(
                    ": ParserRuleReturnScope<IToken>",
                    ": Antlr3CstNode");
        }

        private static string ModifyAstParserRuleReturnScope(string code) {
            Contract.Requires(code != null);

            return code.Replace(
                    "AstParserRuleReturnScope<object, IToken>",
                    "Antlr3CstNode");
        }

        public static string ModifyAddChild(string code) {
            Contract.Requires(code != null);

            return NonTerminalRegex.Replace(
                    code,
                    "adaptor.AddChild($1, $2.Tree, $2, \"$2\", retval)");
        }

        public static string ModifyCreate(string code) {
            Contract.Requires(
                    !new Regex(@"adaptor\.Create\(([^)]*),").IsMatch(code));

            return TerminalRegex.Replace(code, "adaptor.Create($1, \"$1\", retval)");
        }

        public static string ModifyTraceIn(string code) {
            Contract.Requires(code != null);
            // TraceIn("typeParameters", 11);
            // AstParserRuleReturnScope<object, IToken> retval = new AstParserRuleReturnScope<object, IToken>();
            // =>
            // var retval = new Antlr3CstNode("typeParameters", 11);
            return TraceInRegex.Replace(code, "var retval = new Antlr3CstNode($1)")
                    .Replace(
                            "AstParserRuleReturnScope<object, IToken> retval = new AstParserRuleReturnScope<object, IToken>();",
                            "")
                    .Replace("Antlr3CstNode retval = new Antlr3CstNode();", "");
        }

        public static string ModifyAccessModifier(string code) {
            Contract.Requires(code != null);

            return PrivateRegex.Replace(code, "public $1");
        }

        public static string ModifyInheritClass(string code) {
            Contract.Requires(code != null);

            return code.Replace(
                    " : Antlr.Runtime.Parser",
                    " : Antlr.Runtime.Parser, ICustomizedAntlr3Parser");
        }
    }
}