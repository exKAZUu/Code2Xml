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
		private static CCodeToXml _throwableInstance;

		private CCodeToXml() {}

		private CCodeToXml(bool canThrowParseError) {
			CanThrowParseError = canThrowParseError;
		}

		public static CCodeToXml Instance {
			get { return _instance ?? (_instance = new CCodeToXml()); }
		}

		public static CCodeToXml ThrowableInstance {
			get {
				return _throwableInstance
				       ?? (_throwableInstance = new CCodeToXml(true));
			}
		}

		protected override Func<CParser, XParserRuleReturnScope> DefaultParseFunc {
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