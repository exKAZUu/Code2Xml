#region License

// Copyright (C) 2011-2015 Kazunori Sakamoto
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

using System.IO;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ExternalGenerators.Java;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Core.Tests.Generators.ExternalGenerators {
    [TestFixture]
    public class JavaAstGeneratorTest : AstGeneratorTest {
        protected override AstGenerator CreateGenerator() {
            return AstGenerators.Java;
        }

        [Test]
        [TestCase("class A {}")]
        [TestCase("class A { void m() { itn a = 0; } }")]
        public void Parse(string code) {
            VerifyParsing(code);
        }

        [Test]
        public void CanParse() {
            var path = Fixture.GetInputCodePath("Java", "Block1.java");
            Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
        }
    }
}