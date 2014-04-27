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
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.Lua;
using Code2Xml.Objects.Tests.Learning.Experiments;
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
        [TestCase(@"https://github.com/torhve/LuaWeb.git",
                @"da1b73e7b70c938e35051a242c6fa70236e60aac", 61)]
        [TestCase(@"https://github.com/henkboom/pax-britannica.git",
                @"a7a3c0c21e5b27e6f4be3b0b817ebd29cd23fa7d", 60)]
        [TestCase(@"https://github.com/roaminggamer/SSKCorona.git",
                @"a9d6dfec85c01c2d9f8d455a10dcfefcafe35694", 60)]
        [TestCase(@"https://github.com/vincentbernat/awesome-configuration.git",
                @"b649c57c91ba4cb624f37d3f2a4249d9806da68c", 59)]
        [TestCase(@"https://github.com/kikito/love-tile-tutorial.git",
                @"92c5ce5e7e5aa9de461f948c17ed5c8d3af1d0d4", 59)]
        [TestCase(@"https://github.com/dualface/quick-x-server.git",
                @"2c037690610d92692744bf78fc136dec8068fddf", 59)]
        [TestCase(@"https://github.com/josefnpat/vapor.git",
                @"168e91c009ad7bb270498721ff753b4eb1a33038", 58)]
        [TestCase(@"https://github.com/geoffleyland/luatrace.git",
                @"6150cfd6290986adab8ea948e756ee17c80d098a", 58)]
        [TestCase(@"https://github.com/Yonaba/30log.git",
                @"25022b30e58f1590ca3d2bc2c17107b869c38d62", 57)]
        [TestCase(@"https://github.com/SimonLarsen/mrrescue.git",
                @"8f226413b95544d0e0744d9c3e92c68b87659483", 57)]
        [TestCase(@"https://github.com/Nuku/Flexible-Survival.git",
                @"4b75f275ece08e07d1325efc3205578edc0a021b", 56)]
        [TestCase(@"https://github.com/meric/l2l.git",
                @"e9394879e9bde63b1b21e39928ac19f304fc1b39", 56)]
        [TestCase(@"https://github.com/pkulchenko/serpent.git",
                @"026f4e1a5c34f0670948a13d2182729448a260f2", 56)]
        [TestCase(@"https://github.com/AlexChittock/SimpleShortener.git",
                @"76462aeea14adcc0aef49c2cfa8a49951b5d460e", 55)]
        [TestCase(@"https://github.com/willsteel/lcpp.git",
                @"7fdda9a5e3eacccee7571130602dc1381c01bcd9", 55)]
        [TestCase(@"https://github.com/dmccuskey/DMC-Corona-Library.git",
                @"8c85803e39a673cc84b6aa089b51be56f05dd062", 55)]
        [TestCase(@"https://github.com/Neopallium/lua-pb.git",
                @"862fe3121e71f695d9a44ee1d1038069292b69f3", 54)]
        [TestCase(@"https://github.com/keplerproject/luadoc.git",
                @"5250a12bf3bd45873a0f14305b363e53dc8b4a86", 53)]
        [TestCase(@"https://github.com/SnakeSVx/spacebuild.git",
                @"68186b8bc7cabbb5275afd734fae9613fbd8761d", 53)]
        [TestCase(@"https://github.com/darklajid/ansible-communication.git",
                @"003bc68dcbb9606a8099132a399cf21bf342e81c", 53)]
        [TestCase(@"https://github.com/ansca/Corona-Comics-SDK-2.0.git",
                @"ac2abb7ef77753bb01e76ce008d88cece46661b4", 53)]
        [TestCase(@"https://github.com/xolox/vim-lua-inspect.git",
                @"d7fb876f0291cbd13c4c38177ada015fafc58770", 53)]
        [TestCase(@"https://github.com/Overtorment/NoobHub.git",
                @"b0e44e70f44544033e3d50d7ea345fc02db76fe5", 53)]
        [TestCase(@"https://github.com/annulen/premake.git",
                @"c559fa4913bd86be6e415c3b193db90ae4607f5b", 52)]
        [TestCase(@"https://github.com/yuri/sputnik.git",
                @"d4c41a5a6130cca259dc2f21c1d5d99ca6a225ac", 51)]
        [TestCase(@"https://github.com/ignacio/StackTracePlus.git",
                @"3c0d8a09670a40267104348feac19de73191d398", 51)]
        [TestCase(@"https://github.com/leafo/magick.git",
                @"6ba5063b2fe3cf043b4247e9508a6c74b211e704", 51)]
        [TestCase(@"https://github.com/mirven/luaspec.git",
                @"c0c774b54dcc214250cc8eb8aea0dcea60dc6f7c", 49)]
        [TestCase(@"https://github.com/iamgreaser/iceball.git",
                @"4ae5d09ce4fd2269f4e097b63bd0fd9b83f2198f", 49)]
        [TestCase(@"https://github.com/shawndumas/adventure.lua.git",
                @"e98626163129f7c3c4fa6f23abaad1d16b524b16", 48)]
        [TestCase(@"https://github.com/Olivine-Labs/lustache.git",
                @"3358eda141041f8998b938c242b1eda7817898e9", 48)]
        [TestCase(@"https://github.com/bioe007/awesome-configs.git",
                @"cb91a271d55a40cae6b25b0a34ded6947211353f", 47)]
        [TestCase(@"https://github.com/xopxe/Lumen.git",
                @"264d9d042ee9848bccfd064d69259c1d6bde0a2e", 47)]
        [TestCase(@"https://github.com/Neopallium/lualogging.git",
                @"c85130120406b9641e96ab05f782dde819fbd102", 47)]
        [TestCase(@"https://github.com/Bertram25/ValyriaTear.git",
                @"a0e86da761fbc84ace9a778faf64e0f3687dbb3e", 46)]
        [TestCase(@"https://github.com/keplerproject/wsapi.git",
                @"eed8338401196cc155e59280adbe58d78933ead0", 46)]
        [TestCase(@"https://github.com/wiremod/advduplicator.git",
                @"b00138d1b01545fbd6bdec9f7a57597b8c6da164", 46)]
        [TestCase(@"https://github.com/GymbylCoding/Dusk-Engine.git",
                @"f0fcdfc2cd628966bbf208bcb6bf3c3374dd1e42", 46)]
        [TestCase(@"https://github.com/mtourne/nginx_log_by_lua.git",
                @"adc7ecbb3107e0b2a487d851acd33464215a076a", 46)]
        [TestCase(@"https://github.com/Yonaba/Moses.git",
                @"57c7b5d1d1f074cafbd570088ad8681b03c65601", 46)]
        [TestCase(@"https://github.com/stevedonovan/Microlight.git",
                @"95ae73f9830aec3bb1d4773156a6f921dfbed9b4", 46)]
        [TestCase(@"https://github.com/appwilldev/moochine-demo.git",
                @"3b3f565386d43aa533793700c020c4f096ac9636", 45)]
        [TestCase(@"https://github.com/silentbicycle/tangram.git",
                @"85f56670ac839def04715457e1ddaaba7f340bc1", 45)]
        [TestCase(@"https://github.com/metadeus/luv.git",
                @"655c0efc14572d18744aff336210b30574dd7eaf", 44)]
        [TestCase(@"https://github.com/lubyk/dub.git",
                @"b0c7087e878937399f329468bff41de9484f8b0c", 44)]
        [TestCase(@"https://github.com/keplerproject/copas.git",
                @"d2474ab444af5c2bff0ae23f60affb7c64f49242", 44)]
        [TestCase(@"https://github.com/pygy/LuLPeg.git",
                @"c457b27e0d7fc935b133921bf3aee92efffe40c8", 44)]
        [TestCase(@"https://github.com/franko/luajit-lang-toolkit.git",
                @"838b951f65899330a6b707cde96582b5f795abe3", 43)]
        [TestCase(@"https://github.com/Elv13/tyrannical.git",
                @"117bf645ddf015a9da63da8c33cc7da004661261", 43)]
        [TestCase(@"https://github.com/lua-nucleo/lua-nucleo.git",
                @"570e115dab1260ad433bd778eebb5d91fd122d5a", 43)]
        [TestCase(@"https://github.com/lilydjwg/myawesomerc.git",
                @"d7183f3cb533064ecc39a51e621fc556671ff449", 42)]
        [TestCase(@"https://github.com/bioe007/awesome-shifty.git",
                @"b12b66e6a26a2c5fbec6c1119dd29b4f8faf0fe0", 41)]
        [TestCase(@"https://github.com/kikito/anim8.git",
                @"8f110db45f63451df2589255c009ad0e2312eed6", 41)]
        [TestCase(@"https://github.com/vrld/Quickie.git",
                @"52d06037d13afdc68384f1031766ac087cb5e70e", 41)]
        [TestCase(@"https://github.com/silentbicycle/lunatest.git",
                @"e33f2ff55dc843a29d01013aef22b4b89903599b", 41)]
        [TestCase(@"https://github.com/headchant/LICK.git",
                @"e2f900bb5dea40f4d8009fad03cdcf4aa96991f7", 41)]
        [TestCase(@"https://github.com/ravageralpha/my_openwrt_mod.git",
                @"70fcba54825c9da6e09e7cdeb8ba57809c36c8e1", 40)]
        [TestCase(@"https://github.com/iamaleksey/lua-zmq.git",
                @"5578612efe296faa36203c7b80507e38fa7714e0", 40)]
        [TestCase(@"https://github.com/henix/slt2.git",
                @"67141149a05937589548a1368d0b52027014e2f1", 40)]
        [TestCase(@"https://github.com/cloudwu/lua-trace.git",
                @"79a31124f64d863cf670ff82583a144f19570339", 40)]
        [TestCase(@"https://github.com/norman/lua-haml.git",
                @"7eb4179f9003cc4f3d1db2adbaf81cea2fc8994c", 39)]
        [TestCase(@"https://github.com/FourOne/Tukui_Filger.git",
                @"2fb93152102c651ed8b2e8271727cf6d002738a2", 39)]
        [TestCase(@"https://github.com/Neopallium/LuaNativeObjects.git",
                @"a5c444769b7dfad1436a1bc4fe21dce75629db25", 39)]
        [TestCase(@"https://github.com/alexander-yakushev/awesompd.git",
                @"00f26f44c5bf890988322b5107ee536531d6e0bc", 39)]
        [TestCase(@"https://github.com/stevedonovan/LuaMacro.git",
                @"4ec5a8ebdbb9576ca9aa16cc6645f4c7cf2a7705", 38)]
        [TestCase(@"https://github.com/SiENcE/lovecodify.git",
                @"9b84ce1a5f3474707e6021355afd6c2554f18251", 38)]
        [TestCase(@"https://github.com/jp-ganis/JPS.git",
                @"c65f107fa59a5f572e0ffd70be7990a873d87487", 38)]
        [TestCase(@"https://github.com/SnakeSVx/sbep.git",
                @"346e1431ed536d4b8b54676d330f28a06c3e54be", 38)]
        [TestCase(@"https://github.com/stravant/LuaMinify.git",
                @"c284a942089b0154af7498b110e02d1bba8aee16", 38)]
        [TestCase(@"https://github.com/Toresh/Tukui_ClassTimer.git",
                @"f9f5752d33a1a882cb5f46ef9e42badaa1fb5fc2", 37)]
        [TestCase(@"https://github.com/dualface/cocos2d-x-lua-framework.git",
                @"8ebfc699fb135bd1749de02b6c1d5522ac105dd1", 37)]
        [TestCase(@"https://github.com/JesterXL/Robotlegs-for-Corona.git",
                @"79e1407f962dce303325a827adff1fe0a3e16ad6", 36)]
        [TestCase(@"https://github.com/jsimmons/mongrel2-lua.git",
                @"f6d2f50df67c69a56be50d23690530e19e9648db", 36)]
        [TestCase(@"https://github.com/UPenn-RoboCup/UPennalizers.git",
                @"abd9b34294a6485965be274333b72f1272f8f3c8", 36)]
        [TestCase(@"https://github.com/fperrad/lua-MessagePack.git",
                @"c908ead3c2001663ac3d0b5a9c1001bfdcc87397", 36)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            var exp = new LuaComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "lua_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.lua");
        }
    }
}