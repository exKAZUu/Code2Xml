using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Code2Xml.Core.Antlr;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.CSharp.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class CSharpCodeToXml : AntlrCodeToXml<csParser> {
		private static CSharpCodeToXml _instance;
		private static CSharpCodeToXml _throwableInstance;

		private CSharpCodeToXml() {}

		private CSharpCodeToXml(bool canThrowParseError) {
			CanThrowParseError = canThrowParseError;
		}

		public static CSharpCodeToXml Instance {
			get { return _instance ?? (_instance = new CSharpCodeToXml()); }
		}

		public static CSharpCodeToXml ThrowableInstance {
			get {
				return _throwableInstance
				       ?? (_throwableInstance = new CSharpCodeToXml(true));
			}
		}
		protected override Func<csParser, XParserRuleReturnScope> DefaultParseFunc {
			get { return parser => parser.compilation_unit(); }
		}

		public override string ParserName {
			get { return "C#4.0"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".cs" }; }
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			return new csLexer(stream);
		}

		protected override csParser CreateParser(ITokenStream tokenStream) {
			return new csParser(tokenStream);
		}
	}
}