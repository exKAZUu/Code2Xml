using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Antlr.Runtime;

namespace Code2Xml.Core.Antlr {
	public class XParserRuleReturnScope : ParserRuleReturnScope<IToken> {
		public XParserRuleReturnScope() {
			Element = new XElement(GetNodeName());
		}

		public XElement Element { get; set; }

		private string GetNodeName() {
			Contract.Requires(GetType().Name.EndsWith("_return"));
			var name = GetType().Name;
			return name.Substring(0, name.Length - 7);
		}
	}
}