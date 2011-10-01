using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;
using Code2Xml.Languages.Ruby18.CodeToXmls;

namespace Code2Xml.Languages.Ruby18.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class Ruby18XmlToCode : XmlToCode {
		private static Ruby18XmlToCode _instance;

		private readonly ReadOnlyCollection<string> _supportedExtensions =
			new ReadOnlyCollection<string>(new[] { ".rb" });

		private Ruby18XmlToCode() {}

		public static Ruby18XmlToCode Instance {
			get { return _instance ?? (_instance = new Ruby18XmlToCode()); }
		}

		public override string ParserName {
			get { return "Ruby1.8"; }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { return _supportedExtensions; }
		}

		public override string Generate(XElement root) {
			return IronRubyParser.ParseXml(root);
		}
	}
}