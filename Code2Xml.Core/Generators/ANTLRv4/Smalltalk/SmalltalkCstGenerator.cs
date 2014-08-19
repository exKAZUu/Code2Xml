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

namespace Code2Xml.Core.Generators.ANTLRv4.Smalltalk {
    /// <summary>
    /// Represents a Verilog2001 parser and a Verilog2001 code generator.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class SmalltalkCstGenerator : CstGeneratorUsingAntlr4<SmalltalkParser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Smalltalk"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return ""; }
        }

        public SmalltalkCstGenerator() : base(".v") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new SmalltalkLexer(stream);
        }

        protected override SmalltalkParser CreateParser(CommonTokenStream stream) {
            return new SmalltalkParser(stream);
        }

        protected override ParserRuleContext Parse(SmalltalkParser parser) {
            return parser.script();
        }
    }
}