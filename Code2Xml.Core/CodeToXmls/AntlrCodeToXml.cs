using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Antlr;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClass(typeof(AntlrCodeToXmlContract<>))]
	public abstract class AntlrCodeToXml<TParser> : CodeToXml
			where TParser : Parser, IAntlrParser {
		protected bool CanThrowParseError { get; set; }

		protected abstract Func<TParser, XParserRuleReturnScope> DefaultParseFunc { get; }

		protected abstract ITokenSource CreateTokenSource(ICharStream stream);

		protected abstract TParser CreateParser(ITokenStream tokenStream);

		private XElement Generate(
				ICharStream stream,
				Func<TParser, XParserRuleReturnScope> parseFunc,
				bool throwingParseError
			) {
			var lex = CreateTokenSource(stream);
			var tokens = new CommonTokenStream(lex);
			var parser = CreateParser(tokens);
			parser.TraceDestination = Console.Error;
			if (throwingParseError) {
				parser.TreeAdaptor = new ThrowableXmlTreeAdaptor();
			}

			// launch parsing
			return parseFunc(parser).Element;
		}

		private XElement Generate(ICharStream stream, string nodeName, bool throwingParseError) {
			return Generate(
					stream,
					p =>
					(XParserRuleReturnScope)
					p.GetType().GetMethod(nodeName).Invoke(p, null),
					throwingParseError);
		}

		public XElement Generate(string code, string nodeName, bool throwingParseError) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), nodeName, throwingParseError);
		}

		public XElement Generate(string code, string nodeName) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(code, nodeName, DefaultThrowingParseError);
		}

		public XElement Generate(
				string code,
				Func<TParser, XParserRuleReturnScope> parseAction,
				bool throwingParseError) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), parseAction, throwingParseError);
		}

		public XElement Generate(
				string code,
				Func<TParser, XParserRuleReturnScope> parseAction) {
			Contract.Requires<ArgumentNullException>(code != null);
			Contract.Requires<ArgumentNullException>(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), parseAction, DefaultThrowingParseError);
		}

		public override XElement Generate(TextReader reader, bool throwingParseError) {
			Contract.Requires(reader != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRReaderStream(reader), DefaultParseFunc, throwingParseError);
		}

		public override XElement Generate(string code, bool throwingParseError) {
			Contract.Requires(code != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), DefaultParseFunc, throwingParseError);
		}
			}
}