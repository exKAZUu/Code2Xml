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

using System;
using System.IO;
using System.Xml.Linq;
using Code2Xml.Core.Resources;
using Code2Xml.Languages.Ruby18.Properties;
using IronRuby;
using Paraiba.Text;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
	public class IronRubyParser {
		private static readonly string DirectoryPath = Path.Combine(
				"ParserScripts", "IronRubyParser");

		private readonly Func<string, XElement> ParseCodeFunc;
		private readonly Func<XElement, string> ParseXmlFunc;

		public IronRubyParser() {
			ResourceManager.WriteResourceFiles(
					DirectoryPath,
					new[] {
							Tuple.Create(
									Path.Combine("racc", "parser.rb"),
									Resources.racc_parser),
							Tuple.Create(
									"composite_sexp_processor.rb",
									Resources.composite_sexp_processor),
							Tuple.Create(
									"gauntlet_rubyparser.rb",
									Resources.gauntlet_rubyparser),
							Tuple.Create("parser.rb", Resources.parser),
							Tuple.Create("ruby_lexer.rb", Resources.ruby_lexer),
							Tuple.Create(
									"ruby_parser.rb", Resources.ruby_parser),
							Tuple.Create(
									"ruby_parser_extras.rb",
									Resources.ruby_parser_extras),
							Tuple.Create(
									"ruby_parser_README.txt",
									Resources.ruby_parser_README),
							Tuple.Create("ruby2ruby.rb", Resources.ruby2ruby),
							Tuple.Create(
									"ruby2ruby_README.txt",
									Resources.ruby2ruby_README),
							Tuple.Create("sexp.rb", Resources.sexp),
							Tuple.Create(
									"sexp_processor.rb",
									Resources.sexp_processor),
							Tuple.Create(
									"SexpProcessor_README.txt",
									Resources.SexpProcessor_README)
							,
							Tuple.Create("sjis.rb", Resources.sjis),
							Tuple.Create("stringio.rb", Resources.stringio),
							Tuple.Create("strscan.rb", Resources.strscan),
							Tuple.Create("unique.rb", Resources.unique),
							Tuple.Create(
									"zkcount_08a2.rb", Resources.zkcount_08a2),
					});

			var engine = Ruby.CreateEngine();
			// ir.exe.config を参照のこと
			engine.SetSearchPaths(
					new[] {
							DirectoryPath,
					});

			var scope = engine.CreateScope();
			var source =
					engine.CreateScriptSourceFromFile(
							Path.Combine(DirectoryPath, "parser.rb"));
			source.Execute(scope);
			ParseCodeFunc =
					scope.GetVariable<Func<string, XElement>>("parse_code");
			ParseXmlFunc = scope.GetVariable<Func<XElement, string>>(
					"parse_xml");
		}

		public XElement ParseCodeFromString(string content) {
			return ParseCodeFunc(content);
		}

		public XElement ParseCodeFromFile(string fileName) {
			using (var reader = new StreamReader(fileName, XEncoding.SJIS)) {
				return ParseCodeFromString(reader.ReadToEnd());
			}
		}

		public XElement ParseCodeFromReader(TextReader reader) {
			return ParseCodeFromString(reader.ReadToEnd());
		}

		public String ParseXml(XElement root) {
			return ParseXmlFunc(root);
		}
	}
}