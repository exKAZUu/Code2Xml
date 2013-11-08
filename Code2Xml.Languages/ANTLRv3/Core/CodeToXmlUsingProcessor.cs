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

using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using Antlr.Runtime;
using Code2Xml.Core.XmlToCodes;
using Code2Xml.Languages.ANTLRv3.Core;

namespace Code2Xml.Core.CodeToXmls {
	public abstract class CodeToXmlUsingProcessor<TProcessor, TXmlToCode, TParser> : CodeToXml
			where TProcessor : Antlr3Processor<TParser, TProcessor>, new()
			where TXmlToCode : XmlToCodeUsingProcessor<TProcessor>, new()
			where TParser : ICustomizedAntlr3Parser {
		private readonly TProcessor _processor;
		private readonly TXmlToCode _xmlToCode;

		public override string ParserName {
			get { return _processor.LanguageName + " " + _processor.LanguageVersion; }
		}

		public override ReadOnlyCollection<string> TargetExtensions {
			get { return _processor.SupportedExtensions; }
		}

		public override XmlToCode XmlToCode {
			get { return _xmlToCode; }
		}

		protected CodeToXmlUsingProcessor() {
			_processor = Antlr3Processor<TParser, TProcessor>.Instance;
			_xmlToCode = new TXmlToCode();
		}

		public override XElement Generate(
				TextReader reader, bool throwingParseError = DefaultThrowingParseError,
				bool enablePosition = DefaultEnablePosition) {
			return _processor.GenerateXml(reader, throwingParseError);
		}

		public CommonTokenStream CreateTokenStream(string code) {
			return _processor.CreateTokenStream(code);
		}

		public CommonTokenStream CreateTokenStream(TextReader reader) {
			return _processor.CreateTokenStream(reader);
		}
	}
}