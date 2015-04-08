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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core;
using Code2Xml.Core.Generators;
using Code2Xml.Learner.Core.Learning.Experiments;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Learner.Core {
    [TestFixture]
    public class CleanUp {
        [Test]
        public void ShowCandidatesOfWrongRepos() {
            var fixturePath = Fixture.FixturePath;
            var gitDirs = Directory.GetDirectories(
                    fixturePath, ".git", SearchOption.AllDirectories)
                    .Select(Path.GetDirectoryName)
                    .ToList();
            foreach (var gitDir in gitDirs) {
                Git.Reset(gitDir);
            }
            var directories = gitDirs
                    .Where(
                            path =>
                                    Directory.GetDirectories(path).Length
                                    + Directory.GetFiles(path).Length <= 1);
            foreach (var directory in directories) {
                try {
                    Directory.Delete(directory, true);
                } catch {
                    Console.WriteLine(directory);
                }
            }

            var cachFilePaths = Directory.GetFiles(
                    fixturePath, "*" + Code2XmlConstants.LearningCacheExtension,
                    SearchOption.AllDirectories);
            foreach (var filePath in cachFilePaths) {
                File.Delete(filePath);
            }
        }

        [Test]
        public void MoveToDropbox() {
            const string dropBoxPath = @"C:\Users\exKAZUu\Dropbox\Git";
            Directory.CreateDirectory(dropBoxPath);

            var fixturePath = Fixture.FixturePath;
            var cacheFilePaths = Directory.GetFiles(
                    fixturePath, "*" + Code2XmlConstants.LearningCacheExtension,
                    SearchOption.AllDirectories)
                    .ToList();
            foreach (var cacheFilePath in cacheFilePaths) {
                var dirPath = Path.GetDirectoryName(cacheFilePath);
                var dirName = Path.GetFileName(dirPath);
                var toPath = Path.Combine(dropBoxPath, dirName);
                Directory.CreateDirectory(toPath);
                File.Copy(
                        cacheFilePath, Path.Combine(toPath, Path.GetFileName(cacheFilePath)), true);
            }
        }

        [Test]
        public void GenerateTestCases() {
            var inPath = @"C:\Users\exKAZUu\Projects\RepositoryProbe\java.csv";
            if (!File.Exists(inPath)) {
                return;
            }
            var set = new HashSet<string>();
            foreach (var line in File.ReadAllLines(inPath).Skip(1).Take(100)) {
                var items = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length <= 2) {
                    continue;
                }
                if (!set.Contains(items[0])) {
                    set.Add(items[0]);
                    Console.WriteLine("Tuple.Create(@\"" + items[0] + "\",");
                    Console.WriteLine(
                            "@\"" + items[3] + "\"),");
                }
            }
        }

        [Test]
        public void TestJava() {
            var cst =
                    CstGenerators.JavaUsingAntlr3.GenerateTreeFromCodeText(
                            "class K { void m() { int i; i = 0 + 1 - 2 * 3/ 4; }}");
            var e1 = new JavaArithmeticOperatorExperiment();
            var e2 = new JavaExpressionStatementExperiment();
            Assert.That(e1.CountUsingOracle(cst), Is.EqualTo(4));
            Assert.That(e2.CountUsingOracle(cst), Is.EqualTo(1));
        }

        [Test]
        public void TestCSharp() {
            var cst =
                    CstGenerators.CSharpUsingAntlr3.GenerateTreeFromCodeText(
                            "class K { void m() { int i; i = 0 + 1 - 2 * 3/ 4 % 5; }}");
            var e1 = new CSharpArithmeticOperatorExperiment();
            var e2 = new CSharpExpressionStatementExperiment();
            Assert.That(e1.CountUsingOracle(cst), Is.EqualTo(4));
            Assert.That(e2.CountUsingOracle(cst), Is.EqualTo(1));
        }

        [Test]
        public void TestJavaScript() {
            var cst =
                    CstGenerators.JavaScriptUsingAntlr3.GenerateTreeFromCodeText(
                            "i = 0 + 1 - 2 * 3/ 4 % 5;");
            var e1 = new JavaScriptArithmeticOperatorExperiment();
            var e2 = new JavaScriptExpressionStatementExperiment();
            Assert.That(e1.CountUsingOracle(cst), Is.EqualTo(4));
            Assert.That(e2.CountUsingOracle(cst), Is.EqualTo(1));
        }

        [Test]
        public void TestPhp() {
            var cst =
                    CstGenerators.PhpUsingAntlr3.GenerateTreeFromCodeText(
                            "<?php $i = 0 + 1 - 2 * 3 / 4 % 5;");
            var e1 = new PhpArithmeticOperatorExperiment();
            var e2 = new PhpExpressionStatementExperiment();
            Assert.That(e1.CountUsingOracle(cst), Is.EqualTo(4));
            Assert.That(e2.CountUsingOracle(cst), Is.EqualTo(1));
        }

        [Test]
        public void TestLua() {
            var cst =
                    CstGenerators.LuaUsingAntlr3.GenerateTreeFromCodeText(
                            "i = 0 + 1 - 2 * 3 / 4 % 5;");
            var e1 = new LuaArithmeticOperatorExperiment();
            var e2 = new LuaExpressionStatementExperiment();
            Assert.That(e1.CountUsingOracle(cst), Is.EqualTo(4));
            Assert.That(e2.CountUsingOracle(cst), Is.EqualTo(1));
        }

        [Test]
        public void TestPython2() {
            var cst =
                    CstGenerators.Python2.GenerateTreeFromCodeText(
                            "i = 0 + 1 - 2 * 3 / 4 % 5; str(1)");
            var e1 = new PythonArithmeticOperatorExperiment();
            var e2 = new PythonExpressionStatementExperiment();
            var e3 = new PythonSuperComplexBranchExperiment();
            Assert.That(e1.CountUsingOracle(cst), Is.EqualTo(4));
            Assert.That(e2.CountUsingOracle(cst), Is.EqualTo(2));
            Assert.That(e3.CountUsingOracle(cst), Is.EqualTo(1));
        }
    }
}