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
using Code2Xml.Core;
using Code2Xml.Core.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.Java;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
    [TestFixture]
    public class FileCacheCstGeneratorTest {
        [Test]
        public void TestWritingXml() {
            var proc = new FileCacheCstGenerator(new JavaCstGeneratorUsingAntlr3());
            var code = @"
class Main {
  void test() { obj.method().<Object>method2(); }
}
";
            var fileInfo = new FileInfo("temp.txt");
            File.WriteAllText(fileInfo.FullName, code);
            var time = fileInfo.LastWriteTime;

            var root = proc.GenerateTreeFromCode(fileInfo);
            File.WriteAllText(fileInfo.FullName, "");
            fileInfo.LastWriteTime = time.AddDays(1);

            Assert.That(proc.GenerateTreeFromCode(fileInfo).Code, Is.Not.EqualTo(root.Code));
            fileInfo.LastWriteTime = time;
            Assert.That(proc.GenerateTreeFromCode(fileInfo).Code, Is.EqualTo(root.Code));

            fileInfo.Delete();
            var cacheFilePaths = Directory.GetFiles(
                    ".", "*" + Code2XmlConstants.SyntaxTreeCacheExtension);
            foreach (var cacheFilePath in cacheFilePaths) {
                File.Delete(cacheFilePath);
            }
        }
    }
}