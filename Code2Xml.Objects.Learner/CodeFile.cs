using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Location;
using Paraiba.Linq;
using Paraiba.Text;

namespace Code2Xml.Objects.Learner {
	public class CodeFile {
		public bool ReadOnly { get; set; }

		public FileInfo Info { get; private set; }

		public string Code { get; private set; }

		public CstNode Ast { get; private set; }

		public IDictionary<CodeRange, CstNode> Range2Elements { get; set; }

		public CodeFile(CstGenerator cstGenerator, FileInfo info) {
			Info = info;
			Code = GuessEncoding.ReadAllText(info.FullName);
			Ast = cstGenerator.GenerateTreeFromCodeText(Code);
			Range2Elements = new Dictionary<CodeRange, CstNode>();
		}

		public bool RangesEquals(Dictionary<CodeRange, CstNode> range2Elements) {
			return Range2Elements.Values.ToHashSet().SetEquals(range2Elements.Values.ToHashSet());
		}

		public bool RangesEquals(string elementName, Dictionary<CodeRange, CstNode> range2Elements) {
			return Range2Elements.Values.Where(e => e.Name == elementName).ToHashSet()
				.SetEquals(range2Elements.Values.Where(e => e.Name == elementName).ToHashSet());
		}
	}
}