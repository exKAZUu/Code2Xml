#region License

// Copyright (C) 2009-2013 Kazunori Sakamoto
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
using Code2Xml.Languages.Ruby18.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class Ruby18CodeToXml : ExternalCodeToXml {
		private static Ruby18CodeToXml _instance;

		private static readonly string DirectoryPath = Path.Combine(
				"ParserScripts", "Ruby18");

		private static readonly string[] PrivateArguments = new[] {
				Path.Combine(DirectoryPath, "ruby2xml.rb"),
		};

		private readonly string _processorPath;

		public Ruby18CodeToXml()
				: this(ParserUtils.GetRubyPath(19) ?? "ruby") {}

		public Ruby18CodeToXml(string processorPath) {
			_processorPath = processorPath;

			ParaibaFile.WriteIfDifferentSize(PrivateArguments[0], Resources.ruby2xml);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(
							DirectoryPath,
							"composite_sexp_processor.rb"), Resources.composite_sexp_processor);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "gauntlet_rubyparser.rb"), Resources.gauntlet_rubyparser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "pt_testcase.rb"), Resources.pt_testcase);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "README_ruby_parser.txt"), Resources.README_ruby_parser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "README_sexp_processor.txt"), Resources.README_sexp_processor);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby_lexer.rb"), Resources.ruby_lexer);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby_parser.rb"), Resources.ruby_parser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby_parser_extras.rb"), Resources.ruby_parser_extras);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby18_parser.rb"), Resources.ruby18_parser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby19_parser.rb"), Resources.ruby19_parser);
			ParaibaFile.WriteIfDifferentSize(Path.Combine(DirectoryPath, "sexp.rb"), Resources.sexp);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "sexp_processor.rb"), Resources.sexp_processor);
			ParaibaFile.WriteIfDifferentSize(Path.Combine(DirectoryPath, "unique.rb"), Resources.unique);
		}

		public static Ruby18CodeToXml Instance {
			get { return _instance ?? (_instance = new Ruby18CodeToXml()); }
		}

		protected override string ProcessorPath {
			get { return _processorPath; }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public override string ParserName {
			get { return "Ruby18"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".rb" }; }
		}
	}
}