using System.IO;
using System.Xml.Linq;
using Code2Xml.Core;
using Code2Xml.Languages.ANTLRv3.Processors.Java;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class FileCacheProcessorTest {
		[Test]
		public void TestWritingXml() {
			var proc = new JavaProcessorUsingAntlr3();
			var xml = proc.GenerateXml(@"
class Main {
  void test() { obj.method().<Object>method2(); }
}
");
			var xdoc = new XDocument(xml);
			var fileInfo = new FileInfo("temp.txt");
			using (var stream = fileInfo.OpenWrite())
				xdoc.Save(stream, SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces);
			using (var stream = fileInfo.OpenText()) {
				var xdoc2 = XDocument.Load(stream, LoadOptions.PreserveWhitespace);
				Assert.That(xdoc2.Root.Text(), Is.EqualTo(xml.Text()));
			}
		}
	}
}