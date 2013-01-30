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
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Code2Xml.Core.Antlr;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.JavaScript.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class JavaScriptCodeToXml : AntlrCodeToXml<JavaScriptParser> {
		private static JavaScriptCodeToXml _instance;

		private JavaScriptCodeToXml() {}

		public static JavaScriptCodeToXml Instance {
			get { return _instance ?? (_instance = new JavaScriptCodeToXml()); }
		}

		protected override Func<JavaScriptParser, XAstParserRuleReturnScope>
			DefaultParseFunc {
			get { return parser => parser.program(); }
		}

		public override string ParserName {
			get { return "JavaScriptScript"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".js" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new JavaScriptLexer(stream);
		}

		protected override JavaScriptParser CreateParser(
				ITokenStream tokenStream) {
			return new JavaScriptParser(tokenStream);
		}
	}
}