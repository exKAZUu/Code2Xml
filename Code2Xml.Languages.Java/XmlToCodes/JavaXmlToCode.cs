using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.Java.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class JavaXmlToCode : XmlToCodeBase {
		private static JavaXmlToCode _instance;

		private readonly ReadOnlyCollection<string> _supportedExtensions =
			new ReadOnlyCollection<string>(new[] { ".java" });

		private JavaXmlToCode() {}

		public static JavaXmlToCode Instance {
			get { return _instance ?? (_instance = new JavaXmlToCode()); }
		}

		public override string ParserName {
			get { return "Java6"; }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { return _supportedExtensions; }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			switch (element.Value) {
			case "<":
			case ">":
			case "=":
				WriteWordWithoutWhiteSpace(element.Value);
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