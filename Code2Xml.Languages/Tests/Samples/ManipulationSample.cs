#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
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
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Core;
using NUnit.Framework;
using Paraiba.Xml.Linq; // Provides usefule extension methods for XElement

namespace Code2Xml.Languages.Tests.Samples {
    /// <summary>
    /// Sample code for manipulating ASTs.
    /// This sample code uses JavaUsingAntlr3 which is based on Java.g.
    /// </summary>
    [TestFixture]
    public class ManipulationSample {
        [Test]
        public void ProcessIdentifiers() {
            var code = @"class K { void m() {} }";
            var ast = ProcessorLoader.JavaUsingAntlr3.GenerateXml(code);
            Console.WriteLine(ast);
            var ids = ast.Descendants("IDENTIFIER").ToList();
            Assert.That(ids.Count, Is.EqualTo(2));
            var method = ast.Descendants("methodDeclaration").First();
            var methodName = method.Element("IDENTIFIER").TokenText();
            Assert.That(methodName, Is.EqualTo("m"));
        }

        [Test]
        public void ProcessComments() {
            var code = @"class K {
// c1
/** c2 */ void m() { /* c3 */ } // c4
}";
            var ast = ProcessorLoader.JavaUsingAntlr3.GenerateXml(code);
            Console.WriteLine(ast);
            var method = ast.Descendants("methodDeclaration").First();
            var prevHiddens =
                    method.PreviousHiddens().Where(e => e.Name().EndsWith("COMMENT")).ToList();
            var nextHiddens = method.NextHiddens().Where(e => e.Name().EndsWith("COMMENT")).ToList();
            Assert.That(prevHiddens.Count, Is.EqualTo(2));
            Assert.That(prevHiddens[0].HiddenText().Trim(), Is.EqualTo("// c1"));
            Assert.That(prevHiddens[1].HiddenText(), Is.EqualTo("/** c2 */"));
            Assert.That(nextHiddens.Count, Is.EqualTo(1));
            Assert.That(nextHiddens[0].HiddenText().Trim(), Is.EqualTo("// c4"));
        }

        [Test]
        public void InsertStatements() {
            var code = @"class K { void m1() {} void m2() {} }";
            var expected = @"class K { void m1() { head(); } void m2() { head(); } }";
            var ast = ProcessorLoader.JavaUsingAntlr3.GenerateXml(code);
            Console.WriteLine(ast);
            var methodBlocks = ast.Descendants("methodDeclaration")
                    .Descendants("block");
            foreach (var methodBlock in methodBlocks) {
                methodBlock.NthElement(0).AddAfterSelf(new XElement("INSERTED", " head(); "));
            }
            var actualCode = ProcessorLoader.JavaUsingAntlr3.GenerateCode(ast);
            Assert.That(actualCode, Is.EqualTo(expected));
        }
    }
}