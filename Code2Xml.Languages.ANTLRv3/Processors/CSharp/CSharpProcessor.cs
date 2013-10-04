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
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv3.Core;

namespace Code2Xml.Languages.ANTLRv3.Processors.CSharp {
	/// <summary>
	/// Represents a CSharp parser and a CSharp code generator.
	/// </summary>
	[Export(typeof(LanguageProcessor))]
	public class CSharpProcessor : Antlr3Processor {
		/// <summary>
		/// Gets the language name except for the version.
		/// </summary>
		public override string LanguageName {
			get { return "CSharp"; }
		}

		/// <summary>
		/// Gets the language version.
		/// </summary>
		public override string LanguageVersion {
			get { return "4"; }
		}

		public CSharpProcessor() : base(".cs") {}

		protected override XElement GenerateXml(
				ICharStream charStream, bool throwingParseError = DefaultThrowingParseError,
				bool enablePosition = DefaultEnablePosition) {
			var lexer = new csLexer(charStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new csParser(commonTokenStream);
			var builder = new Antlr3AstBuilder(commonTokenStream, true);
			parser.TreeAdaptor = builder;
			parser.AstBuilder = builder;
			parser.compilation_unit();
			return builder.FinishParsing();
		}
	}
}