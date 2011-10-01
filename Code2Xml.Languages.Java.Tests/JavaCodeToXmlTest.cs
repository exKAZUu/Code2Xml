using System.IO;
using Antlr.Runtime;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.Java.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Languages.Java.Tests {
	[TestFixture]
	public class JavaCodeToXmlTest {
		private static readonly string InputPath =
			Path.Combine(Fixture.GetFailedInputPath("Java"), "Unicode.java");

		[Test, ExpectedException(typeof(MismatchedTokenException))]
		public void 不正なユニコード文字の入ったコードをパースできない() {
			JavaCodeToXml.Instance.GenerateFromFile(InputPath, true);
		}

		[Test]
		public void Hudsonのソースコードをパースできない() {
			var path = Fixture.GetInputPath("Java", "FileSystemProvisioner.java");
			JavaCodeToXml.Instance.GenerateFromFile(path, true);
		}
	}
}