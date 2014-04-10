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
using Code2Xml.Languages.ANTLRv4.Generators.Lua;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests.Generators {
    [TestFixture]
    public class LuaCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new LuaCstGenerator();
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
        [TestCase(@"if true then --[[SCars]] end")]
        [TestCase(@"if true --[[SCars]] then end")]
        [TestCase(@"print(1)")]
        [TestCase(@"print(1, 2)")]
        [TestCase("a = [=[one [[two]] three]=]")]
        [TestCase("a = func()[1]")]
        [TestCase(@"local expr = '/[^() ]*lib' .. libname .. '\.so[^() ]*'")]
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
        [TestCase(@"https://github.com/ostinelli/gin.git",
                @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76")]
        [TestCase(@"https://github.com/koreader/koreader.git",
                @"87f69291e18c84b5d7135589d2e8c910bab79f74")]
        [TestCase(@"https://github.com/leafo/lapis.git",
                @"afe3480cf9e64d3f92838846f1ce889a013d1d5e")]
        [TestCase(@"https://github.com/exKAZUu/lsyncd.git",
                @"7addc7060b05e664b8e09e5c13b294e8e6394481")]
        [TestCase(@"https://github.com/rtsisyk/luafun.git",
                @"3d44c0841dbc93b645546bb13868550089bfa076")]
        [TestCase(@"https://github.com/mason-larobina/luakit.git",
                @"993d814c6a51bf50ec0424e65ce2dc35f4aa435f")]
        [TestCase(@"https://github.com/kikito/middleclass.git",
                @"a8a8298a4c0fc03cb7c2906b4d17c3123c2c0038")]
        [TestCase(@"https://github.com/tylerneylon/pacpac.git",
                @"cad99bdd64346dbc3180ee611ea502197da8b414")]
        [TestCase(@"https://github.com/zedshaw/Tir.git",
                @"4c1bdfa5b421e8eb9d3724928055da2728130d40")]
        [TestCase(@"https://github.com/stevedonovan/Penlight.git",
                @"6118a923f5ef4a21a9ae432d42707c5f4f0446a1")]
        [TestCase(@"https://github.com/exebetche/vlsub.git",
                @"71ef0ef295cafb5477769d9ba3975c6c2ba8d609")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.java");
        }
    }
}