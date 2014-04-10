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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using NUnit.Framework;
using Paraiba.Core;
using Paraiba.Text;
using ParserTests;

namespace Code2Xml.Tools.Console.Tests {
    [TestFixture]
    public class ProgramTest {
        private const string CLanguageName = "C";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var langs = new[] {
                    new { Name = "C", Opt = "-C" },
                    new { Name = "CSharp", Opt = "-C#" },
                    new { Name = "Java", Opt = "-Java" },
                    new { Name = "JavaScript", Opt = "-JavaScript" },
                    new { Name = "Lua", Opt = "-Lua" },
                    new { Name = "Python2", Opt = "-Python2" },
                    new { Name = "Python3", Opt = "-Python3" },
                    new { Name = "Ruby18", Opt = "-Ruby18" },
                    //new { Name = "Ruby19", Opt = "-Ruby19" },
                };
                return langs
                        .SelectMany(lang => Directory.EnumerateFiles(
                                Fixture.GetInputCodePath(lang.Name)).Select(path => new {
                                    lang.Name, lang.Opt,
                                    Path = path
                                }))
                        .Select(p => new TestCaseData(p.Path, p.Opt))
                        .Where(t => t.Arguments[2] != null);
            }
        }

        [Test]
        public void ConvertXmlToCode() {
            var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
            var filePaths = names
                    .Select(n => Fixture.GetInputCodePath(CLanguageName, n))
                    .ToList();
            var outputPath = Fixture.GetOutputDirPath(CLanguageName);

            Program.Main(filePaths.Concat(new[] { "-C", "-d", outputPath }).ToArray());
            Program.Main(filePaths
                    .Select(path => Path.Combine(
                            outputPath,
                            Path.ChangeExtension(Path.GetFileName(path), ".xml")))
                    .Concat(new[] { "-code", "-C", "-d", outputPath })
                    .ToArray());

            foreach (var filePath in filePaths) {
                var newPath = Path.Combine(outputPath, Path.GetFileName(filePath));
                using (var reader = new StreamReader(newPath, XEncoding.SJIS)) {
                    var actual = reader.ReadToEnd()
                            .ReplaceNewlinesForWindows();
                    var cst = CstGenerators.CUsingAntlr3
                            .GenerateTreeFromCode(new FileInfo(filePath))
                            .ToXml();
                    var expected = cst.ToCst().Code
                            .ReplaceNewlinesForWindows();
                    Assert.That(actual.StartsWith(expected), Is.True);
                }
            }
            Directory.Delete(outputPath, true);
        }

        [Test, TestCaseSource("TestCases")]
        public void Parse(string filePath, string option) {
            using (var output = new StringWriter()) {
                System.Console.SetOut(output);

                Program.Main(new[] { filePath, option });

                var actual = output.ToString()
                        .ReplaceNewlinesForWindows();
                var expected = SyntaxTreeGenerators.GetProcessorByPath(filePath)
                        .GenerateXmlFromCodePath(filePath)
                        .ToString()
                        .ReplaceNewlinesForWindows();
                Assert.That(actual.StartsWith(expected), Is.True);
            }
        }

        [Test]
        public void WriteGeneratedXmlInDirectory() {
            var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
            var filePaths = names.Select(n => Fixture.GetInputCodePath(CLanguageName, n)).ToList();

            Program.Main(filePaths.Concat(new[] { "-C", "-d" }).ToArray());

            foreach (var filePath in filePaths) {
                var newPath = Path.Combine(
                        Path.GetDirectoryName(filePath),
                        Path.ChangeExtension(Path.GetFileName(filePath), ".xml"));
                using (var reader = new StreamReader(newPath, XEncoding.SJIS)) {
                    var actual = reader.ReadToEnd()
                            .ReplaceNewlinesForWindows();
                    var expected =
                            CstGenerators.CUsingAntlr3.GenerateTreeFromCode(new FileInfo(filePath))
                                    .ToXml()
                                    .ToString()
                                    .ReplaceNewlinesForWindows();
                    Assert.That(actual.StartsWith(expected), Is.True);
                }
                File.Delete(newPath);
            }
        }

        [Test]
        public void WriteGeneratedXmlAsFile() {
            var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
            var filePaths = names.Select(n => Fixture.GetInputCodePath(CLanguageName, n))
                    .ToList();
            const string outputFilePath = "output.txt";

            Program.Main(filePaths.Concat(new[] { "-C", "-f", outputFilePath }).ToArray());

            using (var reader = new StreamReader(outputFilePath, XEncoding.SJIS)) {
                var expected = filePaths
                        .Select(filePath => CstGenerators.CUsingAntlr3
                                .GenerateTreeFromCode(new FileInfo(filePath))
                                .ToXml() + Environment.NewLine)
                        .JoinString()
                        .ReplaceNewlinesForWindows();
                var actual = reader.ReadToEnd()
                        .ReplaceNewlinesForWindows();
                Assert.That(actual, Is.EqualTo(expected));
            }
            File.Delete(outputFilePath);
        }

        [Test]
        public void WriteGeneratedXmlInSpecifiedDirectory() {
            var names = new[] { "Block1.c", "Block2.c", "Block3.c" };
            var filePaths = names.Select(n => Fixture.GetInputCodePath(CLanguageName, n))
                    .ToList();
            var outputPath = Fixture.GetOutputDirPath(CLanguageName);

            Program.Main(filePaths.Concat(new[] { "-C", "-d", outputPath }).ToArray());

            foreach (var filePath in filePaths) {
                var newPath = Path.Combine(
                        outputPath,
                        Path.ChangeExtension(Path.GetFileName(filePath), ".xml"));
                using (var reader = new StreamReader(newPath, XEncoding.SJIS)) {
                    var actual = reader.ReadToEnd()
                            .ReplaceNewlinesForWindows();
                    var expected =
                            CstGenerators.CUsingAntlr3.GenerateTreeFromCode(new FileInfo(filePath))
                                    .ToXml()
                                    .ToString()
                                    .ReplaceNewlinesForWindows();
                    Assert.That(actual.StartsWith(expected), Is.True);
                }
            }
            Directory.Delete(outputPath, true);
        }
    }
}