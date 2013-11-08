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
using Antlr4.Runtime;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv4.Core;

namespace Code2Xml.Languages.ANTLRv4.Processors.Verilog2001 {
	/// <summary>
	/// Represents a Verilog2001 parser and a Verilog2001 code generator.
	/// </summary>
	[Export(typeof(LanguageProcessor))]
	public class Verilog2001Processor : Antlr4Processor<Verilog2001Parser, Verilog2001Processor> {
		/// <summary>
		/// Gets the language name except for the version.
		/// </summary>
		public override string LanguageName {
			get { return "Verilog"; }
		}

		/// <summary>
		/// Gets the language version.
		/// </summary>
		public override string LanguageVersion {
			get { return "2001"; }
		}

		public Verilog2001Processor() : base(".v") {}

		protected override ITokenSource CreateLexer(ICharStream stream) {
			return new Verilog2001Lexer(stream);
		}

		protected override Verilog2001Parser CreateParser(CommonTokenStream stream) {
			return new Verilog2001Parser(stream);
		}

		protected override ParserRuleContext Parse(Verilog2001Parser parser) {
			return parser.source_text();
		}
	}
}