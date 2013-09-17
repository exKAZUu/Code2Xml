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
using Antlr4.Runtime;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv4.Core;

namespace Code2Xml.Languages.ANTLRv4.Processors.Java {
	/// <summary>
	/// Represents a Java parser and a Java code generator.
	/// </summary>
	[Export(typeof(LanguageProcessor))]
	public class JavaProcessor2 : Antlr4Processor {
		/// <summary>
		/// Gets the language name except for the version.
		/// </summary>
		public override string LanguageName {
			get { return "Java"; }
		}

		/// <summary>
		/// Gets the language version.
		/// </summary>
		public override string LanguageVersion {
			get { return "7"; }
		}

		public JavaProcessor2() : base(".java") {}

		/// <summary>
		/// Generates source code from the specified xml.
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public override string GenerateCode(XElement root) {
			var builder = new StringBuilder();
			var hidden = root.Attribute("hidden");
			if (hidden != null) {
				builder.Append(hidden.Value);
			}
			GenerateCode(builder, root);
			return builder.ToString();
		}

		private void GenerateCode(StringBuilder builder, XContainer element) {
			Contract.Requires(element != null);
			foreach (var e in element.Elements()) {
				if (e.HasElements) {
					GenerateCode(builder, e);
				} else {
					builder.Append(e.Value);
					var hidden = e.Attribute("hidden");
					if (hidden != null) {
						builder.Append(hidden.Value);
					}
				}
			}
		}

		protected override XElement GenerateXml(
				ICharStream charStream, bool throwingParseError = DefaultThrowingParseError,
				bool enablePosition = DefaultEnablePosition) {
			var lexer = new JavaLexer(charStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new JavaParser(commonTokenStream);
			var listener = new XElementBuildingListenerUsingAttribute(parser, throwingParseError);
			parser.AddParseListener(listener);
			parser.compilationUnit();
			return listener.FinishParsing();
		}
	}
}