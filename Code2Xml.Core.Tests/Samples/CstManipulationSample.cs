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
using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Samples {
    /// <summary>
    /// Collect identifiers by manipulating Java CST.
    /// CST structure depends on ANTLR grammar file for Java
    /// (https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/ANTLRv3/Generators/Java/Java.g).
    /// </summary>
    [TestFixture]
    public class CstManipulationSample {
        [Test]
        public void ProcessIdentifiers() {
            const string code = @"class K { void m() {} }";
            var cst = CstGenerators.JavaUsingAntlr3.GenerateTreeFromCodeText(code);
            Console.WriteLine(cst.ToXml());
            var ids = cst.Descendants("IDENTIFIER").ToList();
            Assert.That(ids.Count, Is.EqualTo(2));
            var method = cst.Descendants("methodDeclaration").First();
            var methodName = method.Child("IDENTIFIER").TokenText;
            Assert.That(methodName, Is.EqualTo("m"));
        }

        /// <summary>
        /// Collect comments by manipulating Java CST.
        /// CST structure depends on ANTLR grammar file for Java
        /// (https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/ANTLRv3/Generators/Java/Java.g).
        /// </summary>
        [Test]
        public void ProcessComments() {
            const string code = @"class K {
// c1
/** c2 */ void m() { /* c3 */ } // c4
}";
            var cst = CstGenerators.JavaUsingAntlr3.GenerateTreeFromCodeText(code);
            Console.WriteLine(cst.ToXml());
            var method = cst.Descendants("methodDeclaration").First();
            var prevHiddens = method.PreviousHiddens()
                    .Where(e => e.Name.EndsWith("COMMENT")).ToList();
            var nextHiddens = method.NextHiddens()
                    .Where(e => e.Name.EndsWith("COMMENT")).ToList();
            Assert.That(prevHiddens.Count, Is.EqualTo(2));
            Assert.That(prevHiddens[0].Text.Trim(), Is.EqualTo("// c1"));
            Assert.That(prevHiddens[1].Text, Is.EqualTo("/** c2 */"));
            Assert.That(nextHiddens.Count, Is.EqualTo(1));
            Assert.That(nextHiddens[0].Text.Trim(), Is.EqualTo("// c4"));
        }

        /// <summary>
        /// Insert statements by manipulating Java CST.
        /// CST structure depends on ANTLR grammar file for Java
        /// (https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/ANTLRv3/Generators/Java/Java.g).
        /// </summary>
        [Test]
        public void InsertStatements() {
            const string code = @"class K { void m1() {} void m2() { int i; } }";
            const string expected =
                    @"class K { void m1() { head(); } void m2() { head();  int i; } }";
            var cst = CstGenerators.JavaUsingAntlr3.GenerateTreeFromCodeText(code);
            Console.WriteLine(cst.ToXml());
            var methodBlocks = cst.Descendants("methodDeclaration")
                    .Descendants("block");
            foreach (var methodBlock in methodBlocks) {
                methodBlock.AllTokens().First().InsertCodeAfterSelf(" head(); ");
            }
            var actualCode = cst.Code;
            Assert.That(actualCode, Is.EqualTo(expected));
        }
 
        /// <summary>
        /// Remove hidden tokens such as white spaces by manipulating Java CST.
        /// CST structure depends on ANTLR grammar file for Java
        /// (https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/ANTLRv3/Generators/Java/Java.g).
        /// </summary>
        [Test]
        public void RemoveHiddenTokens() {
            const string code = @"class K {
    void m1() {}
    void m2() { int i; }
}";
            const string expected =
                    @"classK{voidm1(){}voidm2(){inti;}}";
            var cst = CstGenerators.JavaUsingAntlr3.GenerateTreeFromCodeText(code);
            Console.WriteLine(cst.ToXml());
            foreach (var node in cst.AllTokenNodes()) {
                node.Hiddens.Clear();
            }
            var actualCode = cst.Code;
            Assert.That(actualCode, Is.EqualTo(expected));
        }
  
        /// <summary>
        /// Remove single nodes which have only a child node by manipulating Java CST.
        /// CST structure depends on ANTLR grammar file for Java
        /// (https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/ANTLRv3/Generators/Java/Java.g).
        /// </summary>
        [Test]
        public void RemoveSingleNodes() {
            const string code = @"class K { void m1() {} void m2() { int i; } }";
            var cst = CstGenerators.JavaUsingAntlr3.GenerateTreeFromCodeText(code);
            var nodes = cst.Descendants().ToList();
            var originalNodeCount = nodes.Count;
            foreach (var node in nodes) {
                if (node.Parent == null)
                    continue;
                var single = node.DescendantsOfSingle().LastOrDefault();
                if (single != null && node.FirstChild != single) {
                    single.Remove();
                    node.FirstChild.Remove();
                    node.AddFirst(single);
                }
            }
            Console.WriteLine(originalNodeCount + ", " + cst.Descendants().Count());
            var actualCode = cst.Code;
            Assert.That(actualCode, Is.EqualTo(code));
        }
    }
}
