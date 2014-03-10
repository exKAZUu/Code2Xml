#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
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
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Core.Location;
using NUnit.Framework;
using Paraiba.Xml;
using ParserTests;

namespace Code2Xml.Core.Tests {
	public abstract class ProcessorTest {
		protected abstract Processor CreateProcessor();

		protected void VerifyParsing(string code) {
			var processor = CreateProcessor();
			var xml = processor.GenerateXml(code);

			Console.WriteLine(xml);
		}

		protected void VerifyInterConverting(string code) {
			var processor = CreateProcessor();
			var r1 = processor.GenerateXml(code, true);
			var c1 = processor.GenerateCode(r1);
			var r2 = processor.GenerateXml(c1, true);
			var c2 = processor.GenerateCode(r2);
			var r3 = processor.GenerateXml(c2, true);
			var c3 = processor.GenerateCode(r3);

			Assert.IsTrue(XmlUtil.EqualsWithElementAndValue(r2, r3));
			Assert.AreEqual(c2, c3);
		}

		protected Tuple<int, int> VerifyRestoringCode(string code, bool write = true) {
			var processor = CreateProcessor();
			var time1 = Environment.TickCount;
			var xml = processor.GenerateXml(code, true);
			var time2 = Environment.TickCount;
			var code2 = processor.GenerateCode(xml);
			var time3 = Environment.TickCount;

			Assert.That(code2, Is.EqualTo(code));
			if (write) {
				Console.WriteLine(xml);
			}
			VerifyLocation(code, xml);

			return Tuple.Create(time2 - time1, time3 - time2);
		}

		protected void VerifyLocation(string code, XElement ast) {
			var es = ast.Descendants().Where(e => e.Attribute("startpos") != null);
			foreach (var e in es) {
				Assert.That(CodeRange.LocateIncludingHidden(e).GetCodeFragment(code), Is.EqualTo(e.Text()));
			}
		}

		protected void VerifyRestoringFile(string langName, string fileName) {
			var path = Fixture.GetInputCodePath(langName, fileName);
			VerifyRestoringCode(File.ReadAllText(path));
		}

		protected void VerifyRestoringProjectDirectory(
				string langName, string fileName, params string[] patterns) {
			var times = new { Ast = 0, Code = 0 };
			var path = Fixture.GetInputProjectPath(langName, fileName);
			foreach (var pattern in patterns) {
				var filePaths = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
				foreach (var filePath in filePaths) {
					Console.WriteLine(filePath);
					var ts = VerifyRestoringCode(File.ReadAllText(filePath), false);
					times = new {
						Ast = times.Ast + ts.Item1,
						Code = times.Code + ts.Item2
					};
				}
			}
			var total = times.Ast + times.Code;
			Console.WriteLine("Ast: " + times.Ast + ", Code: " + times.Code + ", Total: " + total);
		}
	}
}