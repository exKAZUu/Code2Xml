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

namespace Code2Xml.Core.Generators.ANTLRv4.GarryLua {
    /// <summary>
    /// Represents a GarryLua parser and a GarryLua code generator.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class GarryLuaCstGenerator : CstGeneratorUsingAntlr4<GarryLuaParser> {
        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "GarryLua"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "5.2"; }
        }

        public GarryLuaCstGenerator() : base(".lua") {}

        protected override ITokenSource CreateLexer(ICharStream stream) {
            return new GarryLuaLexer(stream);
        }

        protected override GarryLuaParser CreateParser(CommonTokenStream stream) {
            return new GarryLuaParser(stream);
        }

        protected override ParserRuleContext Parse(GarryLuaParser parser) {
            return parser.chunk();
        }
    }
}