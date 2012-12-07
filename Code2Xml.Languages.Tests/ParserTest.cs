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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.Plugins;
using Code2Xml.Core.Tests;
using Code2Xml.Core.XmlToCodes;
using NUnit.Framework;
using Paraiba.Core;
using Paraiba.IO;
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
						//"IronRuby",
						"Java",
						"JavaScript",
						"Lua",
						"Python2",
						"Python3",
						//"Ruby18",
						//"Ruby19",
				};
				var tt = names
						.SelectMany(
								name => Directory.EnumerateFiles(
										Fixture.GetInputPath(name), "*", SearchOption.AllDirectories)
										.Select(path => new { Name = name, Path = path }))
						.Select(
								p => new TestCaseData(
										p.Name, p.Path, PluginManager.CodeToXmls.FirstOrDefault(
												o => o.GetType().Name == p.Name + "CodeToXml"),
										PluginManager.XmlToCodes.FirstOrDefault(
												o => o.GetType().Name == p.Name + "XmlToCode")))
						.Where(t => t.Arguments[2] != null)
						.ToList();
				return tt;
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void Parse(string lang, string path, CodeToXml codeToXml, XmlToCode xmlToCode) {
			var relativePath = XPath.GetRelativePath(path, Fixture.GetInputPath(lang));
			var expPath = Fixture.GetXmlExpectationPath(lang, relativePath);
			var r = codeToXml.GenerateFromFile(path, true)
				.ToString()
				.ReplaceNewlinesForWindows();
			using (var reader = new StreamReader(expPath, XEncoding.SJIS)) {
				Assert.That(r, Is.EqualTo(reader.ReadToEnd().ReplaceNewlinesForWindows()));
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void WriteConvertedXml(string lang, string path, CodeToXml codeToXml, XmlToCode xmlToCode) {
			var relativePath = XPath.GetRelativePath(path, Fixture.GetInputPath(lang));
			var outPath = Fixture.GetOutputFilePath(lang, relativePath);
			Directory.CreateDirectory(Path.GetDirectoryName(outPath));
			var r = codeToXml.GenerateFromFile(path, true);
			using (var writer = new StreamWriter(outPath, false, XEncoding.SJIS) ) {
				writer.Write(r.ToString());
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void InterConvertCodeAndXml(
				string lang, string path, CodeToXml codeToXml, XmlToCode xmlToCode) {
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