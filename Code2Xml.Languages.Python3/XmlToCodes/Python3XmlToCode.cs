using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.Python3.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class Python3XmlToCode : XmlToCodeBase {
		private static Python3XmlToCode _instance;

		private readonly ReadOnlyCollection<string> _supportedExtensions =
			new ReadOnlyCollection<string>(new[] { ".py" });

		private Python3XmlToCode() {}

		public static Python3XmlToCode Instance {
			get { return _instance ?? (_instance = new Python3XmlToCode()); }
		}

		public override string ParserName {
			get { return "Python3"; }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { return _supportedExtensions; }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			switch (element.Name.LocalName) {
			case "NEWLINE":
				WriteLine();
				break;

			case "INDENT":
				Depth++;
				break;

			case "DEDENT":
				Depth--;
				break;

			default:
				return false;
			}

			return true;
		}
	}
}