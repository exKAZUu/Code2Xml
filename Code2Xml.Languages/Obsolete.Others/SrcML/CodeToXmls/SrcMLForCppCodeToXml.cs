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
using System.IO;
using System.Text.RegularExpressions;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.XmlToCodes;
using Code2Xml.Languages.Obsolete.Others.Properties;
using Code2Xml.Languages.SrcML.XmlToCodes;
using Paraiba.IO;

namespace Code2Xml.Languages.SrcML.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class SrcMLForCppCodeToXml : ExternalCodeToXml {
		private static SrcMLForCppCodeToXml _instance;

		private static readonly string DirectoryPath =
				Path.Combine("ParserScripts", "SrcML");

		private static readonly string PrivateProcessorPath =
				Path.Combine(DirectoryPath, "src2srcml.exe");

		private static readonly string[] PrivateArguments = { "-l", "C++" };

		private readonly ReadOnlyCollection<string> _targetExtensions =
				new ReadOnlyCollection<string>(new[] { ".cpp", ".cxx", ".c++", ".h", ".hpp", ".hxx", ".h++" });

		public static SrcMLForCppCodeToXml Instance {
			get { return _instance ?? (_instance = new SrcMLForCppCodeToXml()); }
		}

		public override string ParserName {
			get { return "SrcMLForC++"; }
		}

		public override ReadOnlyCollection<string> TargetExtensions {
			get { return _targetExtensions; }
		}

		public override XmlToCode XmlToCode {
			get { return SrcMLForCppXmlToCode.Instance; }
		}

		protected override string ProcessorPath {
			get { return PrivateProcessorPath; }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public SrcMLForCppCodeToXml() {
			ParaibaFile.WriteIfDifferentSize(PrivateProcessorPath, Resources.src2srcml);
			SrcMLFiles.DeployCommonFiles(DirectoryPath);
		}

		protected override string Normalize(string xml) {
			xml = base.Normalize(xml);
			xml = Regex.Replace(
					xml, @"(xmlns:?[^=]*=[""][^""]*[""])", "",
					RegexOptions.IgnoreCase | RegexOptions.Multiline)
					.Replace("</cpp:", "</")
					.Replace("<cpp:", "<");
			return xml;
		}
	}
}