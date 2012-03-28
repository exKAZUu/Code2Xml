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
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.Resources;
using Code2Xml.Languages.Ruby18.Properties;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class Ruby18CodeToXml : CodeToXml {
		private static Ruby18CodeToXml _instance;

		private readonly IronRubyParser _parser;

		private Ruby18CodeToXml() {
			_parser = new IronRubyParser();
		}

		public static Ruby18CodeToXml Instance {
			get { return _instance ?? (_instance = new Ruby18CodeToXml()); }
		}

		public override string ParserName {
			get { return "Ruby18"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".rb" }; }
		}

		public override XElement Generate(
				TextReader reader, bool throwingParseError) {
			return Generate(reader.ReadToEnd());
		}

		public override XElement Generate(string code, bool throwingParseError) {
			var ast = _parser.ParseCodeFromString(code);
			NodeInserter.ReplaceSafely(
					GetLackingBlockNodesAround(ast),
					node => {
						if (node.Name.LocalName == "block") {
							return node;
						}
						return node.Name.LocalName != "nil"
									   ? new XElement("block", node)
									   : new XElement("block");
					});

			NodeInserter.InsertAfter(
					GetLackingBlockNodesAfter(ast),
					node => new XElement("block"));
			return ast;
		}

		private IEnumerable<XElement> GetLackingBlockNodesAround(XElement root) {
			var ifs = RubyElements.If(root)
					.SelectMany(
							e => new[] {
									RubyElements.IfProcess(e),
									RubyElements.ElseProcess(e),
							});
			var untils = RubyElements.WhileUntil(root)
					.Select(RubyElements.WhileUntilProcess);
			var fors = RubyElements.For(root)
					.Select(RubyElements.ForProcess)
					.Where(e => e != null);
			var iters = RubyElements.Iterator(root)
					.Select(RubyElements.IteratorProcess)
					.Where(e => e != null);

			return ifs.Concat(untils).Concat(fors).Concat(iters);
		}

		private IEnumerable<XElement> GetLackingBlockNodesAfter(XElement root) {
			var fors = RubyElements.SimpleFor(root)
					.Select(RubyElements.ForProcessBefore);
			var iters = RubyElements.SimpleIterator(root)
					.Select(RubyElements.IteratorProcessBefore);

			return fors.Concat(iters);
		}
	}
}