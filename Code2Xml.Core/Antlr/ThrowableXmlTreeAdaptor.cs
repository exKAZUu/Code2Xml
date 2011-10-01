using Antlr.Runtime;

namespace Code2Xml.Core.Antlr {
	public class ThrowableXmlTreeAdaptor : XmlTreeAdaptor {
		public override object ErrorNode(
				ITokenStream input, IToken start, IToken stop, RecognitionException e) {
			throw e;
		}
	}
}