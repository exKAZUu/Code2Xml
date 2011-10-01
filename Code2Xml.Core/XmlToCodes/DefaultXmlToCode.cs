using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Code2Xml.Core.XmlToCodes {
	public class DefaultXmlToCode : XmlToCodeBase {
		private static DefaultXmlToCode _instance;

		public static DefaultXmlToCode Instance {
			get { return _instance ?? (_instance = new DefaultXmlToCode()); }
		}

		public override string ParserName {
			get { throw new NotImplementedException(); }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { throw new NotImplementedException(); }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			return false;
		}
	}
}