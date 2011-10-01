using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.Lua.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class LuaXmlToCode : XmlToCodeBase {
		private static LuaXmlToCode _instance;

		private LuaXmlToCode() {}

		private readonly ReadOnlyCollection<string> _supportedExtensions =
			new ReadOnlyCollection<string>(new[] { ".lua" });


		public static LuaXmlToCode Instance {
			get { return _instance ?? (_instance = new LuaXmlToCode()); }
		}

		public override string ParserName {
			get { return "Lua5.1"; }
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