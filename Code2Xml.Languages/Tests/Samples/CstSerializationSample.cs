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
using NUnit.Framework;

namespace Code2Xml.Languages.Tests.Samples {
    /// <summary>
    /// Sample code for serializing / deserializing CST.
    /// </summary>
    [TestFixture]
    public class CstSerializationSample {
        [Test]
        public void SerializeCst() {
            const string originalCode = @"class Klass {}";
            var gen = CstGenerators.JavaUsingAntlr3;

            var cst = gen.GenerateTreeFromCodeText(originalCode);

            var stringWriter = new StringWriter();
            cst.Serialize(stringWriter);
            Assert.That(CstNode.Deserialize(new StringReader(stringWriter.ToString())).Code,
                    Is.EqualTo(originalCode));

            var memoryStream = new MemoryStream();
            var binaryWritr = new BinaryWriter(memoryStream);
            cst.Serialize(binaryWritr);
            memoryStream.Seek(0, SeekOrigin.Begin);
            Assert.That(CstNode.Deserialize(new BinaryReader(memoryStream)).Code,
                    Is.EqualTo(originalCode));
        }
    }
}