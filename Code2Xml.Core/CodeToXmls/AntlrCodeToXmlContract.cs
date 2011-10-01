using System;
using System.Diagnostics.Contracts;
using Antlr.Runtime;
using Code2Xml.Core.Antlr;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClassFor(typeof(AntlrCodeToXml<>))]
	internal abstract class AntlrCodeToXmlContract<TParser>
			: AntlrCodeToXml<TParser>
			where TParser : Parser, IAntlrParser {
		protected override Func<TParser, XParserRuleReturnScope> DefaultParseFunc {
			get {
				Contract.Ensures(
						Contract.Result<Func<TParser, XParserRuleReturnScope>>() !=
						null);
				throw new NotImplementedException();
			}
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			Contract.Requires(stream != null);
			Contract.Ensures(Contract.Result<ITokenSource>() != null);
			throw new NotImplementedException();
		}

		protected override TParser CreateParser(ITokenStream tokenStream) {
			Contract.Requires(tokenStream != null);
			Contract.Ensures(Contract.Result<TParser>() != null);
			throw new NotImplementedException();
		}
			}
}