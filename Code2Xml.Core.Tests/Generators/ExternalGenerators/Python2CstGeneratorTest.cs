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
        [TestCase(@"https://github.com/jakubroztocil/httpie",
                @"04819577154fc1b11fc20ae7ac584d67614eca25", 12133)]
        [TestCase(@"https://github.com/django/django",
                @"5b8e37a69e66715e9b6a5fc8c4b701498e281a88", 11605)]
        [TestCase(@"https://github.com/kennethreitz/requests",
                @"091991be0da19de9108dbe5e3752917fea3d7fdc", 11439)]
        [TestCase(@"https://github.com/mitsuhiko/flask",
                @"fe2d75e1f41efb49472d625ec7c366e7c242a2c2", 11303)]
        [TestCase(@"https://github.com/ansible/ansible",
                @"1ece7e99e53d328d13f257b3e747f51af97d463f", 8130)]
        [TestCase(@"https://github.com/tornadoweb/tornado",
                @"26cb9b3fa67ef3282414a86743ee2e16c81913c3", 7949)]
        [TestCase(@"https://github.com/reddit/reddit",
                @"f701b678799905506bc5ade9149ade336824259c", 7512)]
        [TestCase(@"https://github.com/numbbbbb/the-swift-programming-language-in-chinese",
                @"c36d53016be76a78f65070b87b9419d965046736", 7490)]
        [TestCase(@"https://github.com/vinta/awesome-python",
                @"613f296fc1b4eb896587cc8d963c8ae7e9fd3b5f", 7175)]
        [TestCase(
                @"https://github.com/CamDavidsonPilon/Probabilistic-Programming-and-Bayesian-Methods-for-Hackers",
                @"28b8d4d686bba616c9f3eddf39a80d845f5030e0", 6495)]
        [TestCase(@"https://github.com/karan/Projects",
                @"5492b82aabf9ae10ac70405a32a52b502f0bb892", 6329)]
        [TestCase(@"https://github.com/scrapy/scrapy",
                @"38dcf50cd6a6328f5ec293015dbe53733343991a", 6152)]
        [TestCase(@"https://github.com/kennethreitz/python-guide",
                @"2f56b6756f9fe1262e1043ed3efca7ae83274bb8", 5905)]
        [TestCase(@"https://github.com/getsentry/sentry",
                @"10caaed2e5c958ab620ae9d95b870158aef4c056", 5884)]
        [TestCase(@"https://github.com/Valloric/YouCompleteMe",
                @"79a3f333344edc9693625102c0f2c792f89fd266", 5796)]
        [TestCase(@"https://github.com/rg3/youtube-dl",
                @"b2e6a1c14c142eab299266641a72101f7d679443", 5668)]
        [TestCase(@"https://github.com/pagekite/Mailpile",
                @"360885e5fb04ddddbd3fcd1e77d4f68812ba1068", 5137)]
        [TestCase(@"https://github.com/ipython/ipython",
                @"8d6041bbc5f1e268f995f68976003c9d7cdefdbb", 5054)]
        [TestCase(@"https://github.com/apenwarr/sshuttle",
                @"9ce2fa00f94c2f2e5c310abeb1a2907ae7e7a7b0", 4685)]
        [TestCase(@"https://github.com/fabric/fabric",
                @"bf216865b5c835b8e19c1cb6e23b72166ae47edd", 4236)]
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