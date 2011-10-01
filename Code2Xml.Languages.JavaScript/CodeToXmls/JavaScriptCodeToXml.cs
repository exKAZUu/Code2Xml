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

		protected override Func<JavaScriptParser, XParserRuleReturnScope>
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

		protected override JavaScriptParser CreateParser(ITokenStream tokenStream) {
			return new JavaScriptParser(tokenStream);
		}
	}
}