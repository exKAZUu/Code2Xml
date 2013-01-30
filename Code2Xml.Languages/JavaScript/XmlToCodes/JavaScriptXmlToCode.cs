#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

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