#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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
using Code2Xml.Languages.SrcML.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.SrcML.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class SrcMLForCCodeToXml : ExternalCodeToXml {
		private static SrcMLForCCodeToXml _instance;

		private static readonly string DirectoryPath = 
			Path.Combine( "ParserScripts", "SrcML");

		private static readonly string PrivateProcessorPath = 
			Path.Combine(DirectoryPath, "src2srcml.exe");

		private static readonly string[] PrivateArguments = 
			new[] { "-l", "C" };

		public static SrcMLForCCodeToXml Instance {
			get { return _instance ?? (_instance = new SrcMLForCCodeToXml()); }
		}

		public override string ParserName {
			get { return "SrcMLForC"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".c", ".h" }; }
		}

		protected override string ProcessorPath {
			get { return PrivateProcessorPath; }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public SrcMLForCCodeToXml() {
			ParaibaFile.WriteIfDifferentSize(PrivateProcessorPath, Resources.src2srcml);
			SrcMLFiles.DeployCommonFiles(DirectoryPath);
		}
	}
}