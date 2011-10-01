using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.Plugins;
using Code2Xml.Core.Tests;
using Code2Xml.Core.XmlToCodes;
using NUnit.Framework;
using Paraiba.Text;
using Paraiba.Xml;

namespace Code2Xml.Languages.Tests {
	[TestFixture]
	public class ParserTest {
		private static IEnumerable<TestCaseData> TestCases {
			get {
				var names = new[] {
					"C",
					"CSharp",
					"IronRuby",
					"Java",
					"JavaScript",
					"Lua",
					"Python2",
					"Python3",
					"Ruby18",
					//"Ruby19",
				};
				return names
					.SelectMany(
						name => Directory.EnumerateFiles(Fixture.GetInputPath(name))
						        	.Select(path => new { Name = name, Path = path }))
					.Select(p =>
					        new TestCaseData(p.Name, p.Path,
								PluginManager.CodeToXmls.FirstOrDefault(o => o.GetType().Name == p.Name + "CodeToXml"),
					        	PluginManager.XmlToCodes.FirstOrDefault(o => o.GetType().Name == p.Name + "XmlToCode")))
					.Where(t => t.Arguments[2] != null);
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void パース結果が変化していない(string lang, string path, CodeToXml codeToXml,
		                          XmlToCode xmlToCode) {
			var expPath = Fixture.GetXmlExpectationPath(lang, Path.GetFileName(path));
			var r = codeToXml.GenerateFromFile(path, true);
			using (var reader = new StreamReader(expPath, XEncoding.SJIS)) {
				Assert.That(r.ToString(), Is.EqualTo(reader.ReadToEnd()));
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void パース結果をファイルに出力できる(string lang, string path, CodeToXml codeToXml,
		                             XmlToCode xmlToCode) {
			var outPath = Fixture.GetOutputFilePath(lang, Path.GetFileName(path));
			var r = codeToXml.GenerateFromFile(path, true);
			using (var writer = new StreamWriter(outPath, false, XEncoding.SJIS)) {
				writer.Write(r.ToString());
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void 構文木生成とコード生成を二回繰り返してもコードが変化しない(string lang, string path,
		                                          CodeToXml codeToXml,
		                                          XmlToCode xmlToCode) {
			var r1 = codeToXml.GenerateFromFile(path, true);
			var c1 = xmlToCode.Generate(r1);
			var r2 = codeToXml.Generate(c1, true);
			var c2 = xmlToCode.Generate(r2);
			var r3 = codeToXml.Generate(c2, true);
			var c3 = xmlToCode.Generate(r3);

			Assert.IsTrue(XmlUtil.EqualsWithElementAndValue(r2, r3));
			Assert.AreEqual(c2, c3);
		}
	}
}