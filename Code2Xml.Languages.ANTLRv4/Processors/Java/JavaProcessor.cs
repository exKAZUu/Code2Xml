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

using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Antlr4.Runtime;
using Code2Xml.Core.Processors;
using Code2Xml.Core.XmlToCodes;
using Code2Xml.Languages.ANTLRv4.Core;

namespace Code2Xml.Languages.ANTLRv4.Processors.Java {
	[Export(typeof(LanguageProcessor))]
	public class JavaProcessor : Antlr4Processor {
		public override string LanguageName {
			get { return "Java"; }
		}

		public override string LanguageVersion {
			get { return "7"; }
		}

		private readonly JavaCodeGenerator _codeGenerator;

		public JavaProcessor() : base(".java") {
			_codeGenerator = new JavaCodeGenerator();
		}

		/// <summary>
		/// Generates source code from the specified xml.
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public override string GenerateCode(XElement root) {
			return _codeGenerator.Generate(root);
		}

		protected override XElement GenerateXml(
				ICharStream charStream, bool throwingParseError = DefaultThrowingParseError,
				bool enablePosition = DefaultEnablePosition) {
			var lexer = new JavaLexer(charStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new JavaParser(commonTokenStream);
			var listener = new XElementBuildingListener(parser, throwingParseError);
			parser.AddParseListener(listener);
			parser.compilationUnit();
			return listener.Root;
		}

		private class JavaCodeGenerator : XmlToCodeBase {
			public override string ParserName {
				get { throw new NotImplementedException(); }
			}

			public override ReadOnlyCollection<string> SupportedExtensions {
				get { throw new NotImplementedException(); }
			}

			protected override bool TreatTerminalSymbol(XElement element) {
				switch (element.Value) {
				case "<":
				case ">":
				case "=":
					WriteWordWithoutWhiteSpace(element.Value);
					break;

				case ";":
					WriteLine(";");
					break;

				case "{":
					WriteLine("{");
					Depth++;
					break;

				case "}":
					Depth--;
					WriteLine("}");
					break;

				default:
					return false;
				}

				return true;
			}
		}
	}
}