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
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ExternalGenerators.Python;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Core.Tests.Generators.ExternalGenerators {
    [TestFixture]
    public class Python2CstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new Python2CstGenerator();
        }

        [Test]
        [TestCase("a = 1\n\n")]
        [TestCase("a = 1\nb = 2\n\n")]
        [TestCase(@"'''
'''")]
        [TestCase(@"# coding: utf-8
pass")]
        [TestCase(@"i = 0 + 1 - 2 * 3 / 4 % 5")]
        [TestCase(@"str(1 + 2)")]
        public void Parse(string code) {
            VerifyRestoringCodeAndInspect(code);
        }

        [Test]
        [TestCase(@"https://github.com/kennethreitz/clint.git",
                @"f1ab574413631de12166469e87257784785d3da6", 1364)]
        [TestCase(@"https://github.com/taobao/nginx-book.git",
                @"b1cba2dc114393766e863581b34dbe179b28c18e", 1363)]
        [TestCase(@"https://github.com/codelucas/newspaper.git",
                @"e0718be363470a19055b1e894957d127c6ae541d", 1361)]
        [TestCase(@"https://github.com/Pylons/pyramid.git",
                @"77005d96fa57a83ac91c2547892fbb3e3c34e553", 1352)]
        [TestCase(@"https://github.com/treeio/treeio.git",
                @"a4fbffabec2644a98f8b06d678a94d2949304235", 1335)]
        [TestCase(@"https://github.com/rembo10/headphones.git",
                @"d6cd9cd7e4cd95e2e4d2fd845fa0c64b91e5e4a5", 1319)]
        [TestCase(@"https://github.com/koenbok/Cactus.git",
                @"10cd41a4a06ab0c88daf625e5a1b7fda202d7126", 1319)]
        [TestCase(@"https://github.com/nvie/rq.git",
                @"aef7af9c77fb6c1e5836403660a4e71fe3c05230", 1316)]
        [TestCase(@"https://github.com/mongodb/mongo-python-driver.git",
                @"a7575fa14f5a9aaeb0149981899f776af9e1ad1c", 1286)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepo(url, commitPointer, "*.py");
        }

        [Test]
        public void AnalyzeLocation() {
            var code = @"
a = 1
if b == 2:
    c = 3
d = 4";
            var xml = Generator.GenerateTreeFromCodeText(code);
            VerifyLocation(code, xml);
            Console.WriteLine(xml);
        }

        [Test]
        public void CanParse() {
            var path = Fixture.GetInputCodePath("Python2", "Block1.py");
            Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
        }

        [Test]
        public void CanParseJapanese() {
            var xml = Generator.GenerateTreeFromCodeText(@"print('あ')", true);
            Assert.That(xml.ToString(), Is.StringContaining("あ"));
        }
    }
}