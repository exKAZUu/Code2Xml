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

using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.Lua;
using Code2Xml.Learner.Core.Learning.Experiments;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3 {
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
        [TestCase(@"https://github.com/pygy/strung.lua.git",
                @"f17cdabe1973eaa5cb1ce7817822f7a8c37b8d8b", 23)]
        [TestCase(@"https://github.com/circumjacence/ConkyInfinitySVG.git",
                @"14aa1812dd4a596b23df70d58b78b8052258b9b5", 23)]
        [TestCase(@"https://github.com/lonelyplanet/openresty-statsd.git",
                @"9b1a788cabe1fcb20843f4dc0d78468ed04f9a62", 23)]
        [TestCase(@"https://github.com/Cluain/Lua-Simple-XML-Parser.git",
                @"2c318f3b01121dad61dee34b8c80c970ff938192", 23)]
        [TestCase(@"https://github.com/golgote/neturl.git",
                @"258c3f6e637030a39265b74ae1e9d681cf977296", 23)]
        [TestCase(@"https://github.com/JackH79/.dotfiles.git",
                @"b957416b6a83a0d05fa943067e821ed77732c201", 22)]
        [TestCase(@"https://github.com/kamaitama/Tiramisu--outdated--don-t-use-.git",
                @"15a847ad05042ae4d7b1117b887902e33470f076", 22)]
        [TestCase(@"https://github.com/Wiladams/LJIT2Win32.git",
                @"59e4419fc4fae4af2553e65fbbaa3d8a0125b4c4", 22)]
        [TestCase(@"https://github.com/haimanman/jx3.git",
                @"4fbdd1db34096d1c904ca426aa0f19c4f29595c5", 22)]
        [TestCase(@"https://github.com/PrinterLUA/FORGOTTENSERVER-ORTS.git",
                @"916b8b9341dac800a7adbbe76efb1b56d1bdb78d", 22)]
        [TestCase(@"https://github.com/Thalassicus/cep-bnw.git",
                @"a0f24cc82fd05ed2b1bfff411f276e8ef7ace176", 22)]
        [TestCase(@"https://github.com/affli/xCT.git",
                @"c20ea295aa816b53b6294eae47d6c4af2eb623d7", 22)]
        [TestCase(@"https://github.com/mascarenhas/luaclr.git",
                @"b0586fcba4320beab46a2d243ca80894fee02afd", 22)]
        [TestCase(@"https://github.com/Haleth/FreeUI.git",
                @"60353ebfe2a143c7beb32ba600701b6dd89e7398", 22)]
        [TestCase(@"https://github.com/speedata/publisher.git",
                @"8f4415a068bd7561f514b7cc6cc603e415a1bde6", 22)]
        [TestCase(@"https://github.com/FPtje/Sublime-GLua-Highlight.git",
                @"7a5a310f440519a25d4f344fcd25906fdd5baf98", 22)]
        [TestCase(@"https://github.com/xolox/lua-lxsh.git",
                @"ee16ce4903616030a26c15c4f8ce2222434f0ade", 22)]
        [TestCase(@"https://github.com/davidm/lua-bit-numberlua.git",
                @"30b6828b298b46411b548202d40524caba06a99c", 22)]
        [TestCase(@"https://github.com/mikar/awesome-themes.git",
                @"877511213c3db9397166bcd1436087b39387aa5d", 22)]
        [TestCase(@"https://github.com/ansca/Storyboard-Sample.git",
                @"500f3bfeda09abf6cf82f679b3e14cad65b40900", 22)]
        [TestCase(@"https://github.com/zrong/lua.git",
                @"5e3e50524a36552e95a4cdda2025dbb8b1694a65", 22)]
        //[TestCase(@"https://github.com/lovelyrpgcommunity/A-Whiff-of-Steam.git",
        //        @"e44aea49b6de9955603cb4db5cd88beea003f3f0", 21)]
        //[TestCase(@"https://github.com/fperrad/lua-TestMore.git",
        //        @"627b3b84afae5c0395f2c336ee710539792e4fac", 21)]
        //[TestCase(@"https://github.com/DracoBlue/lua-oauth.git",
        //        @"e09c6325713cde008416b9211fb57b284352f9a3", 21)]
        //[TestCase(@"https://github.com/creationix/nodeconf2012.git",
        //        @"879fcbe34143e3784fc3110637d467a62552d472", 21)]
        //[TestCase(@"https://github.com/Meneth/PB-git.git",
        //        @"0b1a1abafea33f8009f6502a3a5807ee89065d2e", 21)]
        //[TestCase(@"https://github.com/RafaelDeJongh/cap.git",
        //        @"c411140a3d0aa69f5752388c83d281bd5eb39755", 21)]
        //[TestCase(@"https://github.com/RafaelDeJongh/cap_resources.git",
        //        @"049e4f6a34937c5ac969d611e6e5f668e27f481a", 21)]
        //[TestCase(@"https://github.com/davidm/lua-matrix.git",
        //        @"7a33f9652ddc6808ec9eb866d9e214546bbfc765", 21)]
        //[TestCase(@"https://github.com/hoelzro/lua-term.git",
        //        @"76d7c992a22d4481969a977ad36d6d35d3b2ca6f", 21)]
        //[TestCase(@"https://github.com/ansca/Pinball-Madness.git",
        //        @"70679e4d288cf21cc612146f11c8d24fcdb51834", 21)]
        //[TestCase(@"https://github.com/duff333/Parallax-Class.git",
        //        @"cf6c6f4a4e90208ca9b6fd10d439825017a900b3", 21)]
        //[TestCase(@"https://github.com/coronalabs/CoronaCrush.git",
        //        @"211be29c3c9b90d4e762c8c502c543f6e6937d63", 21)]
        //[TestCase(@"https://github.com/wscherphof/lua-htmlparser.git",
        //        @"a8b5f6fb3160ababb5bc2c11bc4b2b0b67439be5", 21)]
        //[TestCase(@"https://github.com/clementfarabet/torch-tutorials.git",
        //        @"844457015aa1c23f60b4d75fc4a79e745f322e2e", 21)]
        //[TestCase(@"https://github.com/roaminggamer/RG_FreeStuff.git",
        //        @"8c27742b04911fe1f1ed348390681a46d04be6c7", 20)]
        //[TestCase(@"https://github.com/minetest-technic/technic.git",
        //        @"44dbc75b6115d5235ba0538925e44484037459a1", 20)]
        //[TestCase(@"https://github.com/joshtynjala/gtween.lua.git",
        //        @"572000edf616c2c7ce2c5ab15e550da97f8d928f", 20)]
        //[TestCase(@"https://github.com/Movimento5StelleLazio/ParlamentoElettronicoM5S.git",
        //        @"415d0b8c03bbda585171e1a795b7dc45d7d15bb7", 20)]
        //[TestCase(@"https://github.com/CK2Plus/CK2Plus.git",
        //        @"d34cdd807f66990e040edcbba462191d56f36852", 20)]
        //[TestCase(@"https://github.com/codepunkschmidt/Codepunk-s-Code.git",
        //        @"f2f76b3c1662e864269ca34f3540e90b61a375a4", 20)]
        //[TestCase(@"https://github.com/mkottman/lua-git.git",
        //        @"d64218a227fe26b1fc971a8802f74a1921e0187e", 20)]
        //[TestCase(@"https://github.com/bartbes/Class-Commons.git",
        //        @"53f6f546d20f9ff68d72b894b4c585be9dab9160", 20)]
        //[TestCase(@"https://github.com/keplerproject/cgilua.git",
        //        @"4ef15e7b641202325ba220e1700c60a23692f8dd", 20)]
        //[TestCase(@"https://github.com/graue/luasynth.git",
        //        @"4ddb9e9b587cfb62b2bca4914b3c67bb862338ab", 20)]
        //[TestCase(@"https://github.com/altuzar/Appsamuck_Corona_SDK.git",
        //        @"b4015eb491f6a8408a8201218048f49253665f25", 20)]
        //[TestCase(@"https://github.com/jolicloud/jolicloud-desktop-environment.git",
        //        @"77cb7b64647d1d10cbf40f30d6c11b8c05a9e96a", 20)]
        //[TestCase(@"https://github.com/bungle/lua-resty-template.git",
        //        @"aadc42ba718de8dc97fe8d2dd3f64fdd837f9910", 20)]
        //[TestCase(@"https://github.com/06wj/cocos2d_lua_snippets.git",
        //        @"e8486c6d51a63ef79552afd5bb556ae07b8558af", 20)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepo(url, commitPointer, "*.lua");
        }
    }
}