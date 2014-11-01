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

using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators.ANTLRv3.Php {
    /// <summary>
    /// Represents a Php parser and a Php code generator.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class PhpCstGeneratorUsingAntlr3 : CstGeneratorUsingAntlr3<PhpParser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Php"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "5.3"; }
        }

        public PhpCstGeneratorUsingAntlr3() : base(".php") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new PhpLexer(stream);
        }

        protected override PhpParser CreateParser(ITokenStream stream) {
            return new PhpParser(stream);
        }

        protected override CstNode Parse(PhpParser parser) {
            return parser.prog();
        }

        /// <summary>
        /// Generates a syntax tree from the specified text of the source code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public override CstNode GenerateTreeFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            if (code.Contains("<?php")) {
                return GenerateSyntaxTree(new ANTLRStringStream(code), throwingParseError);
            }
            var ret = GenerateSyntaxTree(new ANTLRStringStream("<?php " + code), throwingParseError);
            var node =
                    ret.DescendantsAndSelf()
                            .FirstOrDefault(n => n.HasToken && n.Token.Text == "<?php");
            if (node != null) {
                node.Token.Text = "";
            }
            var hidden = ret.AllHiddens()
                    .FirstOrDefault(t => t.Text.StartsWith(" "));
            if (hidden != null) {
                hidden.Text = hidden.Text.Substring(1);
            }
            var foundHidden = false;
            foreach (var token in ret.AllTokensWithHiddens()) {
                if (token.Range.StartLine != 1) {
                    break;
                }
                token.Range = new CodeRange(
                        new CodeLocation(
                                token.StartLine,
                                token.StartPosition < 5
                                        ? token.StartPosition
                                        : token.StartPosition - (foundHidden ? 6 : 5)),
                        new CodeLocation(
                                token.EndLine,
                                token.EndLine != 1
                                        ? token.EndPosition
                                        : token.EndPosition - (foundHidden ? 6 : 5)));
                if (token == hidden) {
                    foundHidden = true;
                    token.Range = new CodeRange(
                            token.Range.StartLocation,
                            new CodeLocation(
                                    token.EndLine,
                                    token.EndLine != 1 ? token.EndPosition : token.EndPosition - 1));
                }
            }
            // TODO: Should we modify positions?
            return ret;
        }

        /// <summary>
        /// Generates a syntax tree from the specified <c>TextReader</c> which reads the source code.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public override CstNode GenerateTreeFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromCodeText(codeReader.ReadToEnd(), throwingParseError);
        }
    }
}