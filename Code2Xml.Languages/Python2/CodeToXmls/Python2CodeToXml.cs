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

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Code2Xml.Core;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.XmlToCodes;
using Code2Xml.Languages.Python2.Properties;
using Code2Xml.Languages.Python2.XmlToCodes;
using Paraiba.IO;

namespace Code2Xml.Languages.Python2.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class Python2CodeToXml : ExternalCodeToXml {
		private static Python2CodeToXml _instance;

		private static readonly string DirectoryPath = Path.Combine(
				"ParserScripts", "Python2");

		private static readonly string[] PrivateArguments = new[] {
				Path.Combine(DirectoryPath, "ast2xml.py"),
		};

		private readonly string _processorPath;

		public Python2CodeToXml()
				: this(ParserUtils.GetPythonPath("2") ?? "python2") {}

		public Python2CodeToXml(string processorPath) {
			_processorPath = processorPath;

			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ast2xml.py"), Resources.ast2xml);
		}

		public static Python2CodeToXml Instance {
			get { return _instance ?? (_instance = new Python2CodeToXml()); }
		}

		protected override string ProcessorPath {
			get { return _processorPath; }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public override string ParserName {
			get { return "Python2"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".py" }; }
		}

		public override XmlToCode XmlToCode {
			get { return Python2XmlToCode.Instance; }
		}
	}
}