using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Code2Xml.Core.Processors {
	public class MemoryCacheProcessor : Processor {
		public Processor DelegatingProcessor { get; private set; }

		private static readonly Dictionary<string, XElement> Path2Element =
				new Dictionary<string, XElement>();

		public override string LanguageName {
			get { return DelegatingProcessor.LanguageName; }
		}

		public override string LanguageVersion {
			get { return DelegatingProcessor.LanguageVersion; }
		}

		public MemoryCacheProcessor(Processor delegatingProcessor)
				: base(delegatingProcessor.SupportedExtensions) {
			DelegatingProcessor = delegatingProcessor;
		}

		public override string GenerateCode(XElement root) {
			return DelegatingProcessor.GenerateCode(root);
		}

		public override XElement GenerateXml(
				string code, bool throwingParseError = DefaultThrowingParseError) {
			return DelegatingProcessor.GenerateXml(code, throwingParseError);
		}

		public override XElement GenerateXml(
				TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
			return DelegatingProcessor.GenerateXml(codeReader, throwingParseError);
		}

		public override XElement GenerateXml(
				FileInfo codeFile, Encoding encoding = null, bool throwingParseError = DefaultThrowingParseError) {
			var id = codeFile.FullName + codeFile.LastWriteTime;
			if (Path2Element.ContainsKey(id)) {
				return Path2Element[id];
			}
			var tree = DelegatingProcessor.GenerateXml(codeFile, encoding, throwingParseError);
			Path2Element[id] = tree;
			return tree;
		}
	}
}