using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class Ruby18CodeToXml : CodeToXml {
		private static Ruby18CodeToXml _instance;
		private Ruby18CodeToXml() {}

		public static Ruby18CodeToXml Instance {
			get { return _instance ?? (_instance = new Ruby18CodeToXml()); }
		}

		public override string ParserName {
			get { return "Ruby18"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".rb" }; }
		}

		public override XElement Generate(TextReader reader, bool throwingParseError) {
			return Generate(reader.ReadToEnd());
		}

		public override XElement Generate(string code, bool throwingParseError) {
			var ast = IronRubyParser.ParseCodeFromString(code);
			NodeInserter.ReplaceSafely(GetLackingBlockNodesAround(ast),
				node => {
					if (node.Name.LocalName == "block")
						return node;
					return node.Name.LocalName != "nil"
							? new XElement("block", node)
							: new XElement("block");
				});

			NodeInserter.InsertAfter(GetLackingBlockNodesAfter(ast),
				node => new XElement("block"));
			return ast;
		}

		public IEnumerable<XElement> GetLackingBlockNodesAround(XElement root) {
			var ifs = RubyElements.If(root)
				.SelectMany(e => new[] {
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

		public IEnumerable<XElement> GetLackingBlockNodesAfter(XElement root) {
			var fors = RubyElements.SimpleFor(root)
				.Select(RubyElements.ForProcessBefore);
			var iters = RubyElements.SimpleIterator(root)
				.Select(RubyElements.IteratorProcessBefore);

			return fors.Concat(iters);
		}
	}
}