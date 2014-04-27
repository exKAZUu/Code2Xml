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
        [TestCase(@"https://github.com/kennyledet/Algorithm-Implementations.git",
                @"ec423a1984fa923e117053c114c92ae86d32bfd4", 890)]
        [TestCase(@"https://github.com/leafo/moonscript.git",
                @"1527a5f696f1dda718f44bdd28b6615f2ab650cf", 683)]
        [TestCase(@"https://github.com/hawkthorne/hawkthorne-journey.git",
                @"998edb55ca7625ea5473228a794884e4d7c633c2", 552)]
        [TestCase(@"https://github.com/mason-larobina/luakit.git",
                @"993d814c6a51bf50ec0424e65ce2dc35f4aa435f", 513)]
        [TestCase(@"https://github.com/axkibe/lsyncd.git",
                @"85e95ef15066d0b594144e155c3fa955adae68f3", 504)]
        [TestCase(@"https://github.com/koreader/koreader.git",
                @"f1a8970adb94a6a43cff4d3d16769931039e1f73", 466)]
        [TestCase(@"https://github.com/SnabbCo/snabbswitch.git",
                @"6b88f9c5c70e74aafad691654b677aa492580a96", 457)]
        [TestCase(@"https://github.com/kikito/middleclass.git",
                @"f67092082019d9640db1084c4128525141b722d5", 391)]
        [TestCase(@"https://github.com/pkulchenko/ZeroBraneStudio.git",
                @"95452706a059c60fb34e88a0afff44ba4a9032ac", 376)]
        [TestCase(@"https://github.com/leafo/lapis.git",
                @"f2cdcd8179bc0d57560df5bbd95ee03f26214ef7", 374)]
        [TestCase(@"https://github.com/rtsisyk/luafun.git",
                @"3d44c0841dbc93b645546bb13868550089bfa076", 352)]
        [TestCase(@"https://github.com/koreader/kindlepdfviewer.git",
                @"c5beab2ded22d6bd480604c2bb87f3479d4b3b85", 350)]
        [TestCase(@"https://github.com/copycat-killer/awesome-copycats.git",
                @"2b565ee240c883bbb4115106eef66f9f1508a864", 289)]
        [TestCase(@"https://github.com/tylerneylon/pacpac.git",
                @"cad99bdd64346dbc3180ee611ea502197da8b414", 273)]
        [TestCase(@"https://github.com/exebetche/vlsub.git",
                @"71ef0ef295cafb5477769d9ba3975c6c2ba8d609", 259)]
        [TestCase(@"https://github.com/ignacio/LuaNode.git",
                @"bca3678ec44334b990d026c60ac51d15a5ef2a06", 249)]
        [TestCase(@"https://github.com/stevedonovan/Penlight.git",
                @"6118a923f5ef4a21a9ae432d42707c5f4f0446a1", 248)]
        [TestCase(@"https://github.com/zedshaw/Tir.git",
                @"4c1bdfa5b421e8eb9d3724928055da2728130d40", 241)]
        [TestCase(@"https://github.com/CorsixTH/CorsixTH.git",
                @"a7da0b72a7895d1e253963bb68c32ae6b226991f", 238)]
        [TestCase(@"https://github.com/Olivine-Labs/busted.git",
                @"2ded1f55a2314cee25d4a5689e34e7f92e47ac46", 224)]
        [TestCase(@"https://github.com/SpiderLabs/owasp-modsecurity-crs.git",
                @"6b9e47e4c210a9f2824e042d54b590506982b93a", 215)]
        [TestCase(@"https://github.com/mirven/underscore.lua.git",
                @"1bb487f5a0e523a4438a9d126a7ed44accea5a5a", 212)]
        [TestCase(@"https://github.com/ymobe/rapanui.git",
                @"595076d5706695a8b9b8de393b749d7d90a414a2", 201)]
        [TestCase(@"https://github.com/keplerproject/luarocks.git",
                @"999e27d74abd0bc53165d2ce2642fb5a7af81f40", 200)]
        [TestCase(@"https://github.com/nrk/redis-lua.git",
                @"4408c3d686ffd1f2689c0561a166821785cc09ec", 186)]
        [TestCase(@"https://github.com/gamesys/moonshine.git",
                @"ca6d7a57bfb676caf409e7398a448f90eb139b47", 167)]
        [TestCase(@"https://github.com/garrynewman/garrysmod.git",
                @"1bd8973a763e4bb3f9dcb61bacc25acab2769df8", 162)]
        [TestCase(@"https://github.com/tekkub/wow-ui-source.git",
                @"e9e777a6d1baca29d6253260a69463767d8d9b00", 162)]
        [TestCase(@"https://github.com/malkia/ufo.git",
                @"bdcba300f91c38a2d4652d644b0de9f64ad9936c", 154)]
        [TestCase(@"https://github.com/basecamp/intermission.git",
                @"bb75e1ec83dea67e4db4a6a7c00bc4fcd477eae0", 150)]
        [TestCase(@"https://github.com/wiremod/wire.git",
                @"231148a4da77173768e823a64842753243ec304e", 148)]
        [TestCase(@"https://github.com/minetest/minetest_game.git",
                @"15740ffd3d1ea1af182a8607c600f3af414c2c73", 145)]
        [TestCase(@"https://github.com/bjc/prosody.git",
                @"701fa72ca55909888b3fd428724128c654d8b543", 142)]
        [TestCase(@"https://github.com/vrld/hump.git",
                @"e10fa66e60c5984a8d92801163d23811b7ac509f", 142)]
        [TestCase(@"https://github.com/justincormack/ljsyscall.git",
                @"19eb826a46c177c2f93f9ec8985afc684beb1a78", 140)]
        [TestCase(@"https://github.com/osadchuk/Corona-SDK.tmbundle.git",
                @"86ac8c832b0b9234a9859c5c49e704d4cd7899fb", 140)]
        [TestCase(@"https://github.com/igrigorik/tokyo-recipes.git",
                @"b2b34fe52ca7163d964954f408d9f787c408670a", 139)]
        [TestCase(@"https://github.com/fab13n/metalua.git",
                @"355ff0bc201e00856ba20d82c65b14ffa6fcfe4b", 136)]
        [TestCase(@"https://github.com/kikito/lua_missions.git",
                @"330d7702417c4b18358ab822ba676058892ad889", 133)]
        [TestCase(@"https://github.com/diegonehab/luasocket.git",
                @"6d5e40c324c84d9c1453ae88e0ad5bdd0a631448", 131)]
        [TestCase(@"https://github.com/haberman/gazelle.git",
                @"af0fb1b2bcaae513e1ff54d70f022cdc97a93377", 129)]
        [TestCase(@"https://github.com/loveshell/ngx_lua_waf.git",
                @"2b32a34dfc67e8bbb677987319a30357d5ae6e14", 127)]
        [TestCase(@"https://github.com/Yonaba/Jumper.git",
                @"2479afadf3d50e30ea9f9ab104e6229176d57339", 127)]
        [TestCase(@"https://github.com/ansca/Ghosts-vs.-Monsters.git",
                @"7c036c0d11f279c5dace9dcda4f5ad2242a8ca77", 124)]
        [TestCase(@"https://github.com/FPtje/DarkRP.git",
                @"ed1a0db0afc6302353d474a73777948f230a3d1d", 123)]
        [TestCase(@"https://github.com/mikar/awesome34-themes.git",
                @"312cbc31b271afa164a81d51822de7d54b1153f3", 117)]
        [TestCase(@"https://github.com/kernelsauce/turbo.git",
                @"d1411bbbcbe18cb20a7d91bb95505d952993c31f", 115)]
        [TestCase(@"https://github.com/oneoo/alilua.git",
                @"7ce84488504cd364aa5d86acceff8fb8203b9b4f", 112)]
        [TestCase(@"https://github.com/kikito/inspect.lua.git",
                @"e67a7471d4dd9e22e26b3620ce8701c0e479cb82", 112)]
        [TestCase(@"https://github.com/daogangtang/bamboo.git",
                @"e8e58814b1c511396589846ed3f7cb57a3222d48", 111)]
        [TestCase(@"https://github.com/Kadoba/Advanced-Tiled-Loader.git",
                @"0cc155d14406feb0335d455afd1c1fdd8b028671", 110)]
        [TestCase(@"https://github.com/appwilldev/moochine.git",
                @"9f643a5b51fb132c11ec1c870e4979cf03012992", 109)]
        [TestCase(@"https://github.com/Fluorohydride/ygopro.git",
                @"16a98132749215b8ca27f6e479976ef42c4cd0fc", 107)]
        [TestCase(@"https://github.com/fjolnir/TLC.git",
                @"3b0300d2dac913d2d43162cde52479a2d3986ecb", 103)]
        [TestCase(@"https://github.com/NikolaiResokav/LoveFrames.git",
                @"4dfffef2bc8fd5053e714533b7e6e701722c7a89", 101)]
        [TestCase(@"https://github.com/haste/oUF.git",
                @"955f9424bf53b149fb03822bb2082f8888241c78", 99)]
        [TestCase(@"https://github.com/Shestak/ShestakUI.git",
                @"42527a9c4b81c3c1f762b73d4e777cd0fbd3a852", 98)]
        [TestCase(@"https://github.com/stevedonovan/LDoc.git",
                @"511dfe7df01f92da03c639c5f56495c0c31b6e2b", 96)]
        [TestCase(@"https://github.com/pavouk/lgi.git",
                @"3feb90f4c0c20312e646fb8b1106a5c44a04293e", 93)]
        [TestCase(@"https://github.com/majek/lua-channels.git",
                @"599b27ee7496cef488a057aad86e1ce472190a78", 93)]
        [TestCase(@"https://github.com/makotok/Hanappe.git",
                @"b1a759fe9606bfc49a8df458629099be87ab86f5", 92)]
        [TestCase(@"https://github.com/virgo-agent-toolkit/rackspace-monitoring-agent.git",
                @"5197adcd93c61db3c30b1a45a6fc6dbd1d95d66f", 90)]
        [TestCase(@"https://github.com/lefcha/concurrentlua.git",
                @"74405929dca29b2c61fcb9e94c6b6d8799bb148a", 90)]
        [TestCase(@"https://github.com/pkulchenko/MobDebug.git",
                @"c2b9988ccda7998be466da67690316b45fd3469a", 88)]
        [TestCase(@"https://github.com/davidm/lua-inspect.git",
                @"ca3988019a2f5f1b3f4e94b285eb6e77e5923dd3", 88)]
        [TestCase(@"https://github.com/terceiro/awesome-freedesktop.git",
                @"e514e742864495f23fd725f8c596f41a01d67795", 86)]
        [TestCase(@"https://github.com/norman/telescope.git",
                @"c80b928e306cad7195e1ce5b92ddcdcb0a2c50b2", 85)]
        [TestCase(@"https://github.com/kikito/tween.lua.git",
                @"b14444fe3c6bb0a530b97109f3ce2f5e32f55839", 85)]
        [TestCase(@"https://github.com/romockee/powerarrow.git",
                @"530d208c76280d4f6f566394e6f6a7ebf18fc61e", 85)]
        [TestCase(@"https://github.com/crosslife/LoveClear.git",
                @"dd9a81488bbf598e3e279c545a99c562f201d41b", 80)]
        [TestCase(@"https://github.com/LuaAV/LuaAV.git",
                @"7a5dd24de0c31f0d46b27440363408d1a987b044", 79)]
        [TestCase(@"https://github.com/nrk/mercury.git",
                @"13c85348e059dd24f2c26cf9b4e259fa2d1001c8", 77)]
        [TestCase(@"https://github.com/richardhundt/shine.git",
                @"a3cdf3bfc9645f90572fdd80951302edf6681ede", 76)]
        [TestCase(@"https://github.com/jtarchie/underscore-lua.git",
                @"a98846874399916a8689dd5bfe7cafd373128a66", 75)]
        [TestCase(@"https://github.com/copycat-killer/lain.git",
                @"4c3cf3c0b78624242be877a8454a3cd7c2679d45", 73)]
        [TestCase(@"https://github.com/keplerproject/xavante.git",
                @"58188b9da0d6ad621e5da6089684c5273936b398", 73)]
        [TestCase(@"https://github.com/Cue/hop.git",
                @"3e1b8e6bf535fb12f1ad3348473c64acd3647993", 72)]
        [TestCase(@"https://github.com/vrld/HardonCollider.git",
                @"fb8c0511cf85b86327e34f9356e1e8cf9aee8b47", 72)]
        [TestCase(@"https://github.com/lipp/lua-websockets.git",
                @"9ade24fc972cfc80b5d1d31e1d92ec1d28b7c4be", 72)]
        [TestCase(@"https://github.com/harningt/luajson.git",
                @"827425b10152f8cdc515e4ffb900338506e28910", 71)]
        [TestCase(@"https://github.com/AdamBuchweitz/CrawlSpaceLib.git",
                @"471868fe6cad288cac57281b5218cdd711b826eb", 71)]
        [TestCase(@"https://github.com/tony/awesome-config.git",
                @"2957a1bd888a6a99666f3a67c87d0333474736a9", 71)]
        [TestCase(@"https://github.com/weshoke/Lust.git",
                @"174ee908a3b0ee4ca71c92f314fd0efa82498035", 71)]
        [TestCase(@"https://github.com/miko/Love2d-samples.git",
                @"50a8b4b43d517081a83d036e4510904402dcd7d2", 71)]
        [TestCase(@"https://github.com/Kiwi/clyde.git",
                @"dcdba8de3a3be3685a72a1fcab24080124242a7e", 70)]
        [TestCase(@"https://github.com/Neopallium/lua-handlers.git",
                @"ae93f442175f4f03dd612cafa073df74a8fe626f", 70)]
        [TestCase(@"https://github.com/Stabyourself/mari0.git",
                @"b1412a08a1411b2f237cdd276aee27df008cb06e", 69)]
        [TestCase(@"https://github.com/mcurry/html_cache.git",
                @"83af9d9ee24b94b99387d8171b78e388388be756", 68)]
        [TestCase(@"https://github.com/liseen/lua-resty-http.git",
                @"32d951bb47ebddb82b0e3bf1a6eb0af4a6df9f1e", 68)]
        [TestCase(@"https://github.com/cedlemo/blingbling.git",
                @"7ac39503e2811042cf0d83a0874d230779a710ef", 66)]
        [TestCase(@"https://github.com/stevedonovan/Lake.git",
                @"065ac452fd43be501cab587e8a30d3c9b7479726", 66)]
        [TestCase(@"https://github.com/nmap/nmap.git",
                @"ef328e6eed8410d4b2f18560da43f45856e269db", 65)]
        [TestCase(@"https://github.com/keplerproject/orbit.git",
                @"123ec06e3a9fd844f28a43258227bce19ba8ab30", 65)]
        [TestCase(@"https://github.com/radamanthus/corona-game-template.git",
                @"2d1dc125648b70b855fe5a318ad8a6ee30a4e1d2", 65)]
        [TestCase(@"https://github.com/ostinelli/gin.git",
                @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76", 64)]
        [TestCase(@"https://github.com/ignacio/LuaOAuth.git",
                @"3e1e6962658cbb78a5cd3e10c8f6abd35d59232a", 64)]
        [TestCase(@"https://github.com/davidm/lua2c.git",
                @"c5b239dd5a9fad5718ffaa16e6a30cca8053ba92", 62)]
        [TestCase(@"https://github.com/haberman/jitdemo.git",
                @"387503c5b8db268a6236a46e491d6f756ed17d31", 62)]
        [TestCase(@"https://github.com/Jiyambi/WoW-Pro-Guides.git",
                @"d2179d9532aec0a86c6a0e6ae548fdc1c5314a4c", 61)]
        [TestCase(@"https://github.com/Germanunkol/trAInsported.git",
                @"9acd13435ac05ca3821688b1c5d60ba115625e8b", 61)]
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