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
using Code2Xml.Core;
using Code2Xml.Core.XmlToCodes;
using Code2Xml.Languages.Ruby18.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.Ruby18.XmlToCodes {
	[Export(typeof(XmlToCode))]
	public class Ruby18XmlToCode : ExternalXmlToCode {
		private static Ruby18XmlToCode _instance;

		private static readonly string DirectoryPath = Path.Combine(
				"ParserScripts", "Ruby18");

		private static readonly string[] PrivateArguments = new[] {
				Path.Combine(DirectoryPath, "xml2ruby.rb"),
		};

		private readonly ReadOnlyCollection<string> _supportedExtensions =
				new ReadOnlyCollection<string>(new[] { ".rb" });

		private readonly string _processorPath;

		protected override string ProcessorPath {
			get { return _processorPath; }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public Ruby18XmlToCode()
				: this(ParserUtils.GetRubyPath(19) ?? "ruby") {}

		public Ruby18XmlToCode(string processorPath) {
			_processorPath = processorPath;

			ParaibaFile.WriteIfDifferentSize(PrivateArguments[0], Resources.xml2ruby);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby2ruby.rb"), Resources.ruby2ruby);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "composite_sexp_processor.rb"),
					Resources.composite_sexp_processor);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "pt_testcase.rb"), Resources.pt_testcase);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "README_ruby2ruby.txt"), Resources.README_ruby2ruby);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "README_sexp_processor.txt"),
					Resources.README_sexp_processor);
			ParaibaFile.WriteIfDifferentSize(Path.Combine(DirectoryPath, "sexp.rb"), Resources.sexp);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "sexp_processor.rb"), Resources.sexp_processor);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "unique.rb"), Resources.unique);
		}

		public static Ruby18XmlToCode Instance {
			get { return _instance ?? (_instance = new Ruby18XmlToCode()); }
		}

		public override string ParserName {
			get { return "Ruby18"; }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { return _supportedExtensions; }
		}
	}
}