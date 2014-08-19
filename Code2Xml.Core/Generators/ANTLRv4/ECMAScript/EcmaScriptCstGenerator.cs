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

namespace Code2Xml.Core.Generators.ANTLRv4.ECMAScript {
    /// <summary>
    /// Represents a ECMAScript parser and a ECMAScript code generator.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class EcmaScriptCstGenerator : CstGeneratorUsingAntlr4<ECMAScriptParser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "ECMAScript"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "5.1"; }
        }

        public EcmaScriptCstGenerator() : base(".js") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new ECMAScriptLexer(stream);
        }

        protected override ECMAScriptParser CreateParser(CommonTokenStream stream) {
            return new ECMAScriptParser(stream);
        }

        protected override ParserRuleContext Parse(ECMAScriptParser parser) {
            return parser.program();
        }
    }
}