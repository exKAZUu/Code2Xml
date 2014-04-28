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

using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv4.Generators.GarryLua;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests.Generators {
    [TestFixture]
    public class GarryLuaCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new GarryLuaCstGenerator();
        }

        [Test]
        [TestCase(@"a = 1")]
        [TestCase(@"#!/usr/bin/lua
a = 1")]
        [TestCase(@"#!/if/while/lua
a = 1")]
        [TestCase(@"--")]
        [TestCase(@"--[")]
        [TestCase(@"--[==")]
        [TestCase(@"if true then --[[SCars]] end")]
        [TestCase(@"if true --[[SCars]] then end")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Block1.lua")]
        [TestCase("Block2.lua")]
        [TestCase("Block3.lua")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("GarryLua", fileName);
        }

        [Test]
        [TestCase("https://github.com/FPtje/DarkRP.git",
                "95f7e8190f48a88e24c216878f3b623a1b2736f4")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepo(url, commitPointer, "*.lua");
        }
    }
}