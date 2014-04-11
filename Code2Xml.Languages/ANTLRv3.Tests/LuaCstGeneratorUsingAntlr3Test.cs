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
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.Lua;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
    [TestFixture]
    public class LuaCstGeneratorUsingAntlr3Test : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new LuaCstGeneratorUsingAntlr3();
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
        [TestCase(@"--[==[]==]")]
        [TestCase(@"if true then end --[[SCars]] ")]
        [TestCase(@"if true then --[[SCars]] end")]
        [TestCase(@"if true --[[SCars]] then end")]
        [TestCase(@"--[=")]
        [TestCase(@"--a")]
        [TestCase("-- running the tests and examples\nrequire 'pl'\n")]
        [TestCase("require 'pl'\n")]
        [TestCase(@"print(1)")]
        [TestCase(@"print(1, 2)")]
        [TestCase("a = [=[one [[two]] three]=]")]
        [TestCase("a = func()[1]")]
        [TestCase(@"local s = '/[^() ]*lib' .. '%.so[^() ]*'")]
        [TestCase("--[[Any--]]")]
        [TestCase(@"
--
print(1)
")]
        [TestCase(@"--")]
        [TestCase(@"
if true --[[xx]] then
	print(1)
end
")]
        [TestCase(@"
if true then --[[VERBOSE]] print(1) end
")]
        [TestCase(@"-- comment
")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Block1.lua")]
        [TestCase("Block2.lua")]
        [TestCase("Block3.lua")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("Lua", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/stevedonovan/Penlight.git",
                @"e9992789af07861974cad2bad5ba7c067d089e26")]
        [TestCase(@"https://github.com/zedshaw/Tir.git",
                @"4c1bdfa5b421e8eb9d3724928055da2728130d40")]
        [TestCase(@"https://github.com/ostinelli/gin.git",
                @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76")]
        [TestCase(@"https://github.com/koreader/koreader.git",
                @"ca85deb1fa6779bc001b914d7bd371864106ea3a")]
        [TestCase(@"https://github.com/leafo/lapis.git",
                @"0fe074b55e834267d82122f5c49d8b5a89c55f3d")]
        [TestCase(@"https://github.com/exKAZUu/lsyncd.git",
                @"178f31590732da0eb39cd58b20cc53c3d954ebec")]
        [TestCase(@"https://github.com/rtsisyk/luafun.git",
                @"396dfc14171cfccda349ce2b445707b889ab422d")]
        [TestCase(@"https://github.com/mason-larobina/luakit.git",
                @"993d814c6a51bf50ec0424e65ce2dc35f4aa435f")]
        [TestCase(@"https://github.com/kikito/middleclass.git",
                @"124c6d687eaf46fa7f869056959975f018ae45bd")]
        [TestCase(@"https://github.com/tylerneylon/pacpac.git",
                @"cad99bdd64346dbc3180ee611ea502197da8b414")]
        [TestCase(@"https://github.com/exebetche/vlsub.git",
                @"e2280c4a75c3c3aba2986465d9c9559927ed4479")]
        // Failed test cases
        //[TestCase(@"https://github.com/pkulchenko/ZeroBraneStudio.git",
        //        @"777690862d387ed5c2311cf52ae35ff37b20269c")]
        //[TestCase(@"https://github.com/justincormack/ljsyscall.git",
        //        @"e71e418526e506dc1ab07d1e955f17de21e4b471")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.java");
        }
    }
}