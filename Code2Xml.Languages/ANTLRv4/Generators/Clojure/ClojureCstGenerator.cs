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

namespace Code2Xml.Languages.ANTLRv4.Generators.Clojure {
    /// <summary>
    /// Represents a Clojure parser and a Clojure code generator.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class ClojureCstGenerator : CstGeneratorUsingAntlr4<ClojureParser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Clojure"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return ""; }
        }

        public ClojureCstGenerator() : base(".clj") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new ClojureLexer(stream);
        }

        protected override ClojureParser CreateParser(CommonTokenStream stream) {
            return new ClojureParser(stream);
        }

        protected override ParserRuleContext Parse(ClojureParser parser) {
            return parser.file();
        }
    }
}