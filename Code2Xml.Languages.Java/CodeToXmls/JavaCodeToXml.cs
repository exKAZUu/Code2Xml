using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Code2Xml.Core.Antlr;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.Java.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class JavaCodeToXml : AntlrCodeToXml<JavaParser> {
		private static JavaCodeToXml _instance;

		private JavaCodeToXml() {}

		public static JavaCodeToXml Instance {
			get { return _instance ?? (_instance = new JavaCodeToXml()); }
		}

		protected override Func<JavaParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.compilationUnit(); }
		}

		public override string ParserName {
			get { return "Java6"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".java" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new JavaLexer(stream);
		}

		protected override JavaParser CreateParser(ITokenStream tokenStream) {
			return new JavaParser(tokenStream);
		}
	}
}