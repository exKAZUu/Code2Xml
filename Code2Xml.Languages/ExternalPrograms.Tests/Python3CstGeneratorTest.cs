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
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ExternalGenerators.Generators.Python;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.ExternalGenerators.Tests {
    [TestFixture]
    public class Python3CstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new Python3CstGenerator();
        }

        [Test]
        [TestCase("a = 1\n\n")]
        [TestCase("a = 1\nb = 2\n\n")]
        [TestCase(@"'''
'''")]
        [TestCase(@"# coding: utf-8
pass")]
        public void Parse(string code) {
            VerifyRestoringCodeAndInspect(code);
        }

        [Test]
        [TestCase(@"https://github.com/musalbas/heartbleed-masstest.git",
                @"71210f4f794e7dd3e1af77f9afb7c81ae0c91f37")]
        [TestCase(@"https://github.com/jasperproject/jasper-client.git",
                @"9c240bafb55b0c8de45b024a606d903c125b9ae1")]
        [TestCase(@"https://github.com/rg3/youtube-dl.git",
                @"d0f2ab6969db70895624303b586ed76e1a8a3291")]
        [TestCase(@"https://github.com/ansible/ansible.git",
                @"b0556ab1fbc0652147b86a809cf8b69d4c3cd188")]
        [TestCase(@"https://github.com/scrapinghub/portia.git",
                @"55f97e61fc558d243a0806ae8bf4a26b080026de")]
        [TestCase(@"https://github.com/Lekensteyn/pacemaker.git",
                @"68d51e461a26a6f63c19ff7ee2da7bdaaddbe787")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.py");
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