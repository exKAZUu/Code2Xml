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
using Code2Xml.Core.Generators.ExternalGenerators.Ruby;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Core.Tests.Generators.ExternalGenerators {
    [TestFixture]
    public class Ruby19AstGeneratorTest : AstGeneratorTest {
        protected override AstGenerator CreateGenerator() {
            return new Ruby19AstGenerator();
        }

        [Test]
        [TestCase("a = 1")]
        [TestCase("a = 1\r\nb = 2\r\n")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        public void CanParse() {
            var path = Fixture.GetInputCodePath("Ruby18", "block.rb");
            Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
        }

        [Test]
        public void CanParseJapanese() {
            var ast = Generator.GenerateTreeFromCodeText(@"p 'あ'", true);
            Console.WriteLine(ast);
            Assert.That(ast.ToString(), Is.StringContaining("あ"));
        }

        [Test]
        public void CanParseJapanese2() {
            var ast = Generator.GenerateTreeFromCodeText(@"p = 'あ'", true);
            Console.WriteLine(ast);
            Assert.That(ast.ToString(), Is.StringContaining("あ"));
        }

        [Test, Ignore("This test fails due to the bugs of ruby_parser")]
        public void CanParseJapanese3() {
            // TODO: Currently, this test fails due to the bugs of ruby_parser
            // https://github.com/seattlerb/ruby_parser/issues/133
            var xml = Generator.GenerateTreeFromCodeText("p = \"\\u{3042}\"", true);
            Console.WriteLine(xml);
            Assert.That(xml.ToString(), Is.StringContaining("\\u{3042}"));
        }

        [Test, Ignore("This test fails due to the bugs of ruby_parser")]
        public void InterConvertJapanese() {
            // TODO: Currently, this test fails due to the bugs of ruby_parser
            // https://github.com/seattlerb/ruby_parser/issues/133
            var generator = Generator;
            var r1 = generator.GenerateTreeFromCodeText(@"p = 'あ'", true);
            var c1 = generator.GenerateCodeFromTree(r1);
            var r2 = generator.GenerateTreeFromCodeText(c1, true);
            var c2 = generator.GenerateCodeFromTree(r2);
            var r3 = generator.GenerateTreeFromCodeText(c2, true);
            var c3 = generator.GenerateCodeFromTree(r3);

            // TODO: Assert.IsTrue(XmlUtil.EqualsWithElementAndValue(r2, r3));
            Assert.That(c1, Is.EqualTo("p = \"\\u{3042}\""));
            Assert.That(c2, Is.EqualTo("p = \"\\u{3042}\""));
        }
    }
}