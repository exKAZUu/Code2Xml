using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.JavaScript.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class JavaScriptXmlToCode : XmlToCodeBase {
		private static JavaScriptXmlToCode _instance;

		private readonly ReadOnlyCollection<string> _supportedExtensions =
			new ReadOnlyCollection<string>(new[] { ".js" });

		private JavaScriptXmlToCode() {}

		public static JavaScriptXmlToCode Instance {
			get { return _instance ?? (_instance = new JavaScriptXmlToCode()); }
		}

		public override string ParserName {
			get { return "JavaScript"; }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { return _supportedExtensions; }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			switch (element.Value) {
			case "\r\n":
				WriteLine();
				break;

			case "\n":
				WriteLine();
				break;

			case "\r":
				WriteLine();
				break;

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