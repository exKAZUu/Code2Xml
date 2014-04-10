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
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Core.Tests.Generators {
    public abstract class SyntaxTreeGeneratorTest<TGenerator, TNode, TToken>
            where TGenerator : SyntaxTreeGenerator<TNode, TToken>
            where TNode : SyntaxTreeNode<TNode, TToken>
            where TToken : SyntaxTreeToken<TToken> {
        private long _timeToGenerateTree;
        private long _timeToGenerateCode;
        private TGenerator _generator;

        protected TGenerator Generator {
            get { return _generator ?? (_generator = CreateGenerator()); }
        }

        protected abstract TGenerator CreateGenerator();

        protected void StartMeasuringTimes() {
            _timeToGenerateTree = 0;
            _timeToGenerateCode = 0;
        }

        protected void ShowTimes() {
            Console.WriteLine("Time to generate tree: " + _timeToGenerateTree);
            Console.WriteLine("Time to generate code: " + _timeToGenerateCode);
        }

        protected void VerifyParsing(string code) {
            var time = Environment.TickCount;
            var root = Generator.GenerateTreeFromCodeText(code);
            _timeToGenerateTree += (Environment.TickCount - time);

            Console.WriteLine(root.ToXml());
        }

        protected void VerifyInterConverting(string code) {
            var time = Environment.TickCount;
            var r1 = Generator.GenerateTreeFromCodeText(code, true);
            var time2 = Environment.TickCount;
            var c1 = Generator.GenerateCodeFromTree(r1);
            _timeToGenerateCode += (Environment.TickCount - time2);
            _timeToGenerateTree += (time2 - time);

            var r2 = Generator.GenerateTreeFromCodeText(c1, true);
            var c2 = Generator.GenerateCodeFromTree(r2);
            var r3 = Generator.GenerateTreeFromCodeText(c2, true);
            var c3 = Generator.GenerateCodeFromTree(r3);

            Assert.That(r2, Is.EqualTo(r3));
            Assert.That(c2, Is.EqualTo(c3));
        }

        protected void VerifyRestoringCode(string code, bool write = true) {
            var time = Environment.TickCount;
            var tree = Generator.GenerateTreeFromCodeText(code, true);
            var time2 = Environment.TickCount;
            var code2 = Generator.GenerateCodeFromTree(tree);
            _timeToGenerateCode += (Environment.TickCount - time2);
            _timeToGenerateTree += (time2 - time);

            Assert.That(code2, Is.EqualTo(code));
            if (write) {
                Console.WriteLine(tree.ToXml());
            }
            VerifyLocation(code, tree);
        }

        protected abstract void VerifyLocation(string code, TNode root);

        protected void VerifyRestoringFile(string langName, string fileName) {
            var path = Fixture.GetInputCodePath(langName, fileName);
            VerifyRestoringCode(File.ReadAllText(path));
        }

        protected void VerifyRestoringProjectDirectory(
                string langName, string directoryName,
                params string[] patterns) {
            VerifyRestoringProjectDirectory(langName, directoryName, File.ReadAllText, patterns);
        }

        protected void VerifyRestoringProjectDirectory(string langName, string directoryName,
                Func<string, string> readFileFunc, params string[] patterns) {
            var path = Fixture.GetInputProjectPath(langName, directoryName);
            VerifyRestoringProjectDirectory(path, readFileFunc, patterns);
        }

        private void VerifyRestoringProjectDirectory(string path, Func<string, string> readFileFunc,
                params string[] patterns) {
            StartMeasuringTimes();
            foreach (var pattern in patterns) {
                var filePaths = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                foreach (var filePath in filePaths) {
                    Console.Write(".");
                    VerifyRestoringCode(readFileFunc(filePath), false);
                }
            }
            Console.WriteLine();
            ShowTimes();
        }

        protected void VerifyRestoringGitRepository(string url, string commitPointer,
                params string[] patterns) {
            VerifyRestoringGitRepository(url, commitPointer, File.ReadAllText, patterns);
        }

        protected void VerifyRestoringGitRepository(string url, string commitPointer,
                Func<string, string> readFileFunc, params string[] patterns) {
            var path = Fixture.GetGitRepositoryPath(url);
            Directory.CreateDirectory(path);
            if (!new DirectoryInfo(path).GetDirectories().Any()) {
                Git.Clone(url, commitPointer, path);
            }
            VerifyRestoringProjectDirectory(path, readFileFunc, patterns);
        }
    }
}