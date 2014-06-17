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
using Antlr4.Runtime;
using Code2Xml.Core.Generators;
using Code2Xml.Languages.ANTLRv4.Core;

namespace Code2Xml.Languages.ANTLRv4.Generators.Python3 {
    /// <summary>
    /// Represents a Python3 parser and a Python3 code generator.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class Python3CstGenerator : CstGeneratorUsingAntlr4<Python3Parser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Python"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "3"; }
        }

        public Python3CstGenerator() : base(".py") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new Python3Lexer(stream);
        }

        protected override Python3Parser CreateParser(CommonTokenStream stream) {
            return new Python3Parser(stream);
        }

        protected override ParserRuleContext Parse(Python3Parser parser) {
            return parser.file_input();
        }
    }
}