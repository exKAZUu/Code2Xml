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
using Code2Xml.Core;
using Code2Xml.Languages.ANTLRv4.Core;

namespace Code2Xml.Languages.ANTLRv4.Processors.R {
	/// <summary>
	/// Represents a R parser and a R code generator.
	/// </summary>
	[Export(typeof(Processor))]
	public class RProcessor : ProcessorUsingAntlr4<RParser> {
		/// <summary>
		/// Gets the language name except for the version.
		/// </summary>
		public override string LanguageName {
			get { return "R"; }
		}

		/// <summary>
		/// Gets the language version.
		/// </summary>
		public override string LanguageVersion {
			get { return "2"; }
		}

		public RProcessor() : base(".r", ".q") {}

		protected override ITokenSource CreateLexer(ICharStream stream) {
			return new RLexer(stream);
		}

		protected override RParser CreateParser(CommonTokenStream stream) {
			var filter = new RFilter(stream);
			filter.BuildParseTree = false;
			filter.stream(); // call start rule: stream
			stream.Reset();
			return new RParser(stream);
		}

		protected override ParserRuleContext Parse(RParser parser) {
			return parser.prog();
		}
	}
}