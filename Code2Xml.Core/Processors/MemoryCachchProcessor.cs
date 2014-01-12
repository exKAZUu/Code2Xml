using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Code2Xml.Core.Processors {
	public class MemoryCachchProcessor : Processor {
		public Processor DelegatingProcessor { get; private set; }

		private static readonly Dictionary<string, XElement> Path2Element =
				new Dictionary<string, XElement>();

		public override string LanguageName {
			get { return DelegatingProcessor.LanguageName; }
		}

		public override string LanguageVersion {
			get { return DelegatingProcessor.LanguageVersion; }
		}

		public MemoryCachchProcessor(Processor delegatingProcessor)
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
			var time = codeFile.LastWriteTime.ToString();
			foreach (var invalidChar in Path.GetInvalidPathChars()) {
				time = time.Replace(invalidChar, '_');
			}
			var path = Path.GetFileNameWithoutExtension(codeFile.FullName) + time + ".xml";
			if (Path2Element.ContainsKey(path)) {
				return Path2Element[path];
			}
			var tree = base.GenerateXml(codeFile, encoding, throwingParseError);
			Path2Element[path] = tree;
			return tree;
		}
	}
}