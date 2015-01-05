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
using System.Linq;
using System.Text.RegularExpressions;
using Paraiba.Text;

namespace Code2Xml.Tools.AntlrHelper {
    public static class ParserModifier {
        private static readonly Regex[] UnusedCodeRegexes = {
            new Regex(@"adaptor\.AddChild\([^,]*, .*_tree\);"),
            new Regex(@"System\.out\.println[^;]+;"),
        };

        private static readonly string[] UnusedCodeStrings = {
            "root_0 = (object)adaptor.Nil();",
            "retval.Tree = (object)adaptor.RulePostProcessing(root_0);",
            "adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);",
        };

        private static readonly Regex AddChildForNonTerminalNodeRegex =
                new Regex(@"adaptor\.AddChild\([^,]*, (.*)\.Tree\);");

        private static readonly Regex CreateInStatementForTerminalNodeRegex =
                new Regex(@".* = \(object\)adaptor\.Create\(([^),]*)\)");

        private static readonly Regex CreateInParameterForTerminalNodeRegex =
                new Regex(@"adaptor.AddChild\(root_0, \(object\)adaptor\.Create\(([^),]*)\)\)");

        private static readonly Regex TraceInRegex =
                new Regex(@"TraceIn\((.*), .*\)");

        public static void Modify(string path) {
            Contract.Requires(path != null);

            string code;
            using (var reader = new StreamReader(path, XEncoding.SJIS)) {
                code = reader.ReadToEnd();
                code = RemoveUnusedCode(code);
                code = ModifyInheritClass(code);
                code = ModifyCommonTreeAdaptor(code);
                code = ModifyAstParserRuleReturnScope(code);
                code = ModifyAddChild(code);
                code = ModifyCreate(code);
                code = ModifyTraceIn(code);
                code = ModifyRetval(code);
            }
            using (var writer = new StreamWriter(path, false, XEncoding.SJIS)) {
                writer.WriteLine("using Code2Xml.Core.Generators.ANTLRv3;");
                writer.WriteLine("using Code2Xml.Core.SyntaxTree;");
                writer.WriteLine("using System;");
                writer.Write(code);
            }
        }

        public static string RemoveUnusedCode(string code) {
            Contract.Requires(code != null);
            code = UnusedCodeRegexes
                    .Aggregate(code, (c, regex) => regex.Replace(c, ""));
            return UnusedCodeStrings
                    .Aggregate(code, (c, str) => c.Replace(str, ""));
        }

        public static string ModifyInheritClass(string code) {
            Contract.Requires(code != null);
            return code.Replace(
                    " : Antlr.Runtime.Parser",
                    " : Antlr.Runtime.Parser, ICustomizedAntlr3Parser");
        }

        public static string ModifyCommonTreeAdaptor(string code) {
            Contract.Requires(code != null);
            // ITreeAdaptor treeAdaptor = default(ITreeAdaptor);
            // TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();
            // =>
            // CstBuilderForAntlr3 treeAdaptor = default(CstBuilderForAntlr3);
            // TreeAdaptor = treeAdaptor;
            return code
                    .Replace(" ?? new CommonTreeAdaptor()", "")
                    .Replace("ITreeAdaptor", "CstBuilderForAntlr3");
        }

        public static string ModifyAstParserRuleReturnScope(string code) {
            Contract.Requires(code != null);
            // public AstParserRuleReturnScope<object, IToken> chunk() {
            // AstParserRuleReturnScope<object, IToken> retval = new AstParserRuleReturnScope<object, IToken>();
            // =>
            // public CstNode chunk() {
            // CstNode retval = new CstNode();
            // =>
            // public CstNode chunk() {
            //
            return code.Replace("AstParserRuleReturnScope<object, IToken>", "CstNode")
                    .Replace("CstNode retval = new CstNode();", "");
        }

        public static string ModifyTraceIn(string code) {
            Contract.Requires(!code.Contains("AstParserRuleReturnScope<object, IToken>"));
            // TraceIn("typeParameters", 11);
            // =>
            // var retval = new CstNode("typeParameters");
            return TraceInRegex.Replace(code, "var retval = new CstNode($1)");
        }

        public static string ModifyAddChild(string code) {
            Contract.Requires(code != null);
            // adaptor.AddChild(root_0, block1.Tree);
            // =>
            // adaptor.AddChild(retval, block1);
            return AddChildForNonTerminalNodeRegex
                    .Replace(code, "adaptor.AddChild(retval, $1, \"$1\");");
        }

        public static string ModifyCreate(string code) {
            Contract.Requires(code != null);
            // char_literal4_tree = (object)adaptor.Create(char_literal4);
            // =>
            // adaptor.Create(retval, char_literal4, "char_literal4");
            code = CreateInStatementForTerminalNodeRegex
                    .Replace(code, "adaptor.Create(retval, $1, \"$1\")");
            // if (state.backtracking == 0) adaptor.AddChild(root_0, (object)adaptor.Create(set157));
            // =>
            // if (state.backtracking == 0) adaptor.Create(retval, set157, "set157");
            return CreateInParameterForTerminalNodeRegex
                    .Replace(code, "adaptor.Create(retval, $1, \"$1\")");
        }

        public static string ModifyRetval(string code) {
            code = code.Replace(
                    "retval.Start = (IToken)input.LT(1);",
                    "var retval_Start = (IToken)input.LT(1);");
            code = code.Replace(
                    "retval.Stop = (IToken)input.LT(-1);",
                    "");
            code = code.Replace(
                    "retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);",
                    "adaptor.ErrorNode(input, retval_Start, input.LT(-1), re);");
            return code;
        }
    }
}