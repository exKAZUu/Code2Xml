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
using Code2Xml.Languages.Ruby18.Properties;
using IronRuby;
using Paraiba.IO;
using Paraiba.Text;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
	public class IronRubyParser {
		private static readonly string DirectoryPath = Path.Combine(
				"ParserScripts", "IronRubyParser");

		private readonly Func<string, XElement> ParseCodeFunc;
		private readonly Func<XElement, string> ParseXmlFunc;

		public IronRubyParser() {
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "racc", "parser.rb"), Resources.racc_parser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "composite_sexp_processor.rb"),
					Resources.composite_sexp_processor);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "gauntlet_rubyparser.rb"),
					Resources.gauntlet_rubyparser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "parser.rb"), Resources.parser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby_lexer.rb"), Resources.ruby_lexer);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby_parser.rb"), Resources.ruby_parser);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby_parser_extras.rb"),
					Resources.ruby_parser_extras);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby_parser_README.txt"),
					Resources.ruby_parser_README);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby2ruby.rb"), Resources.ruby2ruby);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "ruby2ruby_README.txt"),
					Resources.ruby2ruby_README);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "sexp.rb"), Resources.sexp);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "sexp_processor.rb"), Resources.sexp_processor);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "SexpProcessor_README.txt"),
					Resources.SexpProcessor_README);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "sjis.rb"), Resources.sjis);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "stringio.rb"), Resources.stringio);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "strscan.rb"), Resources.strscan);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "unique.rb"), Resources.unique);
			ParaibaFile.WriteIfDifferentSize(
					Path.Combine(DirectoryPath, "zkcount_08a2.rb"), Resources.zkcount_08a2);

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