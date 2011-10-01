using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Code2Xml.Core.Antlr {
	public class XmlTreeAdaptor : CommonTreeAdaptor {
		public object Create(IToken payload, XParserRuleReturnScope parent) {
			Contract.Requires(parent != null);
			if (payload != null) {
				var xtoken = payload as XToken;
				var name = xtoken != null ? xtoken.Name : "TOKEN";
				var element = new XElement(name, payload.Text);
				element.SetAttributeValue("startline", payload.Line);
				element.SetAttributeValue("startpos", payload.CharPositionInLine);
				parent.Element.Add(element);
			}
			return Create(payload);
		}

		public void AddChild(
				object t, object child, XParserRuleReturnScope target,
				XParserRuleReturnScope parent) {
			Contract.Requires(parent != null);
			parent.Element.Add(target.Element);
			base.AddChild(t, child);
		}
	}
}