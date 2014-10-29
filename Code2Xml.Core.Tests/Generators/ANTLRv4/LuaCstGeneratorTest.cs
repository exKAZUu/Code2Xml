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
using Code2Xml.Core.Generators.ANTLRv4.Lua;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv4 {
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
        [TestCase(@"i = 0 + 1 - 2 * 3/ 4;")]
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
        [TestCase(@"https://github.com/kennyledet/Algorithm-Implementations",
                @"140093792bd5d0c7a13b5d7b886f3d3c7a20b314", 1119)]
        //[TestCase(@"https://github.com/SnabbCo/snabbswitch",
        //        @"a3e8b906d3f52de4ce7ac16e6088d90b0ba175d6", 864)]
        //[TestCase(@"https://github.com/leafo/moonscript",
        //        @"163748b8c91f2df226aa8cb81f91c20e1fa1fc62", 837)]
        //[TestCase(@"https://github.com/axkibe/lsyncd",
        //        @"4da2257758df7814a7eb7b6ce6494cde6d2789f6", 756)]
        [TestCase(@"https://github.com/koreader/koreader",
                @"7a22c60256a422c1981b09721adf69d5cab44387", 704)]
        [TestCase(@"https://github.com/hawkthorne/hawkthorne-journey",
                @"610b9b3907b2a1b21da2ae926e4c7c4c9e19959b", 593)]
        [TestCase(@"https://github.com/mason-larobina/luakit",
                @"5e3c2c8f519eaf095d1ae3e402639bf80eafbb3b", 556)]
        [TestCase(@"https://github.com/pkulchenko/ZeroBraneStudio",
                @"9789ecb9238687dfc20457022ac097f7eb3e94c6", 491)]
        [TestCase(@"https://github.com/kikito/middleclass",
                @"f67092082019d9640db1084c4128525141b722d5", 464)]
        [TestCase(@"https://github.com/copycat-killer/awesome-copycats",
                @"1394a36c42b8984318e2e8c87bb3bd2d398f65a2", 452)]
        [TestCase(@"https://github.com/rtsisyk/luafun",
                @"3d44c0841dbc93b645546bb13868550089bfa076", 450)]
        [TestCase(@"https://github.com/CorsixTH/CorsixTH",
                @"03a4e80874288d4e66b282c3a0778d346e937bf3", 382)]
        [TestCase(@"https://github.com/tylerneylon/termtris",
                @"282229abe21abb3b10f0368e23fcd649b70697e4", 374)]
        [TestCase(@"https://github.com/koreader/kindlepdfviewer",
                @"c5beab2ded22d6bd480604c2bb87f3479d4b3b85", 373)]
        [TestCase(@"https://github.com/exebetche/vlsub",
                @"61cd3aaf1845560c04850b007fffd36ac965dd7e", 316)]
        [TestCase(@"https://github.com/stevedonovan/Penlight",
                @"cbfe7d3a715543928a42a826148253c9dbeea13e", 304)]
        [TestCase(@"https://github.com/SpiderLabs/owasp-modsecurity-crs",
                @"ebe8790dd8d6949eade1a16dc47179dc6e376179", 301)]
        [TestCase(@"https://github.com/Olivine-Labs/busted",
                @"35c86d3987304e5afebbb6a65a9c9fd5ee5aa6bb", 297)]
        //[TestCase(@"https://github.com/ignacio/LuaNode",
        //        @"56ee65e45007dd983f38646103c91728dd7dd194", 296)]
        [TestCase(@"https://github.com/tylerneylon/pacpac",
                @"cad99bdd64346dbc3180ee611ea502197da8b414", 295)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            MeasurePerformance(url, commitPointer, null, "*.lua");
        }
    }
}