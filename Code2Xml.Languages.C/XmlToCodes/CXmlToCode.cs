using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.C.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class CXmlToCode : XmlToCodeBase {
		private static CXmlToCode _instance;

		private readonly ReadOnlyCollection<string> _supportedExtensions =
			new ReadOnlyCollection<string>(new[] { ".c" });

		private CXmlToCode() {}

		public static CXmlToCode Instance {
			get { return _instance ?? (_instance = new CXmlToCode()); }
		}

		public override string ParserName {
			get { return "C"; }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { return _supportedExtensions; }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			switch (element.Value) {
			case ";":
				WriteLine(";");
				break;

			case "{":
				WriteLine("{");
				Depth++;
				break;

			case "}":
				Depth--;
				WriteLine("}");
				break;

			default:
				return false;
			}

			return true;
		}
	}
}