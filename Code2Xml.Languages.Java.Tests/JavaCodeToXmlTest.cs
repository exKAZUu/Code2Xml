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

using System.IO;
using System.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.Java.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Languages.Java.Tests {
    [TestFixture]
    public class JavaCodeToXmlTest {
        private static readonly string InputPath =
                Path.Combine(Fixture.GetFailedInputPath("Java"), "Unicode.java");

        [Test]
        public void Hudsonのソースコードをパースできない() {
            var path = Fixture.GetInputPath(
                    "Java", "FileSystemProvisioner.java");
            JavaCodeToXml.Instance.GenerateFromFile(path, true);
        }

        [Test, ExpectedException(typeof(MismatchedTokenException))]
        public void 不正なユニコード文字の入ったコードをパースできない() {
            JavaCodeToXml.Instance.GenerateFromFile(InputPath, true);
        }

        [Test]
        public void ParseComment() {
            var e = JavaCodeToXml.Instance.Generate(
                    @"public class A { /*aaa*/ } // bbb");
        	Assert.That(e.Descendants("Comment").Count(), Is.EqualTo(2));
        }
    }
}