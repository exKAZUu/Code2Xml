using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Code2Xml.Core.Processors {
	public class FileCacheProcessor : Processor {
		public Processor DelegatingProcessor { get; private set; }

		public override string LanguageName {
			get { return DelegatingProcessor.LanguageName; }
		}

		public override string LanguageVersion {
			get { return DelegatingProcessor.LanguageVersion; }
		}

		public FileCacheProcessor(Processor delegatingProcessor)
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
			foreach (var invalidChar in Path.GetInvalidFileNameChars()) {
				time = time.Replace(invalidChar, '_');
			}
			Directory.CreateDirectory("cache");
			var chachFileInfo =
					new FileInfo(Path.Combine("cache",
							Path.GetFileNameWithoutExtension(codeFile.FullName) + time + ".xml"));
			if (chachFileInfo.Exists) {
				using (var reader = chachFileInfo.OpenText()) {
					var xdoc = XDocument.Load(reader, LoadOptions.PreserveWhitespace);
					var cachedTree = xdoc.Root;
					cachedTree.Remove();
					return cachedTree;
				}
			}
			var tree = base.GenerateXml(codeFile, encoding, throwingParseError);
			using (var stream = chachFileInfo.OpenWrite()) {
				tree.Save(stream, SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces);
			}
			return tree;
		}
	}
}