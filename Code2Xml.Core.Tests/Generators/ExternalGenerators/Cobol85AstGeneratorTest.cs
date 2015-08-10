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

using System.IO;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ExternalGenerators.Cobol;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Core.Tests.Generators.ExternalGenerators {
    [TestFixture]
    public class Cobol85AstGeneratorTest : AstGeneratorTest {
        protected override AstGenerator CreateGenerator() {
            return new Cobol85AstGenerator();
        }

        [Test]
        [TestCase("000010 IDENTIFICATION DIVISION.")]
        [TestCase("000120      DISPLAY \"Hello World!!\".")]
        public void Parse(string code) {
            VerifyParsing(code);
        }

        [Test]
        public void CanParse() {
            var path = Fixture.GetInputCodePath("Cobol85", "CM101M.CBL");
            Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
        }
    }
}