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
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Samples {
    internal class AnalysisAndTransformationSample {
        [Test]
        public void CountIfInJava() {
            const string originalCode = @"class K { void m() { if (true) {} if (false) {} } }";
            var gen = CstGenerators.JavaUsingAntlr3;
            var cst = gen.GenerateTreeFromCodeText(originalCode);
            Assert.That(cst.Descendants("IF").Count(), Is.EqualTo(2));
        }

        [Test]
        public void ListUpMethodsInJava() {
            const string originalCode = @"class K { void m() { } int n() {} }";
            var gen = CstGenerators.JavaUsingAntlr3;
            var cst = gen.GenerateTreeFromCodeText(originalCode);
            var names = cst.Descendants("methodDeclaration")
                    .Select(node => node.Child("IDENTIFIER").TokenText)
                    .ToList();
            Assert.That(names, Is.EqualTo(new[] { "m", "n" }));
        }

        [Test]
        public void ModifyIfConditionInC() {
            const string originalCode = @"void m() { if (true) {} if (false) {} }";
            var gen = CstGenerators.CUsingAntlr3;
            var cst = gen.GenerateTreeFromCodeText(originalCode);
            var conds = cst.Descendants("selection_statement")
                    .Where(e => e.FirstChild.TokenText == "if")
                    .Select(e => e.Child("expression"));
            foreach (var cond in conds) {
                cond.InsertCodeBeforeSelf("b(");
                cond.InsertCodeAfterSelf(")");
            }
            Assert.That(
                    cst.Code, Is.EqualTo(
                            @"void m() { if (b(true)) {} if (b(false)) {} }"));
        }

        [Test]
        public void ReplaceStatementWithPassInPython() {
            const string originalCode = @"a = 6; b = 7; b = a * b; print(b)";
            var gen = CstGenerators.Python2;
            var cst = gen.GenerateTreeFromCodeText(originalCode);
            var stmts = cst.Descendants("small_stmt").ToList();
            foreach (var stmt in stmts) {
                stmt.Replacement = "pass";
                // .. Conduct tests to judge whether tests detect mutants ..
                Console.WriteLine(cst.Code);
                Assert.That(cst.Code, Is.StringContaining("pass"));
                stmt.Replacement = null;
                Assert.That(cst.Code, Is.EqualTo(originalCode));
            }
        }

        [Test]
        public void RemoveStatementInCSharp() {
            const string originalCode = @"class K {
    void M() {
        Console.WriteLine(0);
        if (true) {
            Console.WriteLine(1);
        }
        Console.WriteLine(2);
        Console.WriteLine(3);
    }
}";
            var gen = CstGenerators.CSharpUsingAntlr3;
            var cst = gen.GenerateTreeFromCodeText(originalCode);
            var stmts = cst.Descendants("embedded_statement");
            foreach (var stmt in stmts) {
                var restore = stmt.RemoveRecoverably();
                // .. Conduct tests to judge whether tests detect mutants ..
                Console.WriteLine(cst.Code);
                restore();
                Assert.That(cst.Code, Is.EqualTo(originalCode));
            }
        }
    }
}