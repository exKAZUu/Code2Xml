#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
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
using Antlr.Runtime;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv3.Core;

namespace Code2Xml.Languages.ANTLRv3.Processors.C {
    /// <summary>
    /// Represents a C parser and a C code generator.
    /// </summary>
    [Export(typeof(LanguageProcessor))]
    public class CProcessorUsingAntlr3 : ProcessorUsingAntlr3<CParser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "C"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "11"; }
        }

        public CProcessorUsingAntlr3() : base(".c", ".h") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new CLexer(stream);
        }

        protected override CParser CreateParser(ITokenStream stream) {
            return new CParser(stream);
        }

        protected override Antlr3AstNode Parse(CParser parser) {
            return parser.translation_unit();
        }
    }
}