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
using Code2Xml.Core.Generators.ANTLRv3.Java;
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Serialization {
    [TestFixture]
    public class SerializationTest {
        [Test]
        public void SerializeAndDeserialize() {
            var proc = new JavaCstGeneratorUsingAntlr3();
            var fileInfo = new FileInfo("temp.txt");
            var code = @"
class Main {
  void test() { obj.method().<Object>method2(); }
}
";
            var tree = proc.GenerateTreeFromCodeText(code);
            tree.Serialize(fileInfo);
            var tree2 = CstNode.Deserialize(fileInfo);

            Assert.That(tree.Code, Is.EqualTo(code));
            Assert.That(tree2.Code, Is.EqualTo(code));
            Assert.That(tree2.ToXml().ToCst().Code, Is.EqualTo(code));

            fileInfo.Delete();
        }
    }
}