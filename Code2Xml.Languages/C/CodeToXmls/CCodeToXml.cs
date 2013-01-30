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

namespace Code2Xml.Languages.C.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class CCodeToXml : AntlrCodeToXml<CParser> {
		private static CCodeToXml _instance;

		private CCodeToXml() {}

		public static CCodeToXml Instance {
			get { return _instance ?? (_instance = new CCodeToXml()); }
		}

		protected override Func<CParser, XAstParserRuleReturnScope>
			DefaultParseFunc {
			get { return parser => parser.translation_unit(); }
		}

		public override string ParserName {
			get { return "C"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".c" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new CLexer(stream);
		}

		protected override CParser CreateParser(ITokenStream tokenStream) {
			return new CParser(tokenStream);
		}
	}
}