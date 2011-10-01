using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.CSharp.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class CSharpXmlToCode : XmlToCodeBase {
		private static CSharpXmlToCode _instance;

		private readonly ReadOnlyCollection<string> _supportedExtensions =
			new ReadOnlyCollection<string>(new[] { ".cs" });

		private CSharpXmlToCode() {}

		public static CSharpXmlToCode Instance {
			get { return _instance ?? (_instance = new CSharpXmlToCode()); }
		}

		public override string ParserName {
			get { return "C#4.0"; }
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