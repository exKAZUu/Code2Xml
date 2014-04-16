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
        [TestCase(@"https://github.com/kennyledet/Algorithm-Implementations.git",
                @"ec423a1984fa923e117053c114c92ae86d32bfd4")] // Star: 890
        [TestCase(@"https://github.com/leafo/moonscript.git",
                @"1527a5f696f1dda718f44bdd28b6615f2ab650cf")] // Star: 683
        [TestCase(@"https://github.com/hawkthorne/hawkthorne-journey.git",
                @"998edb55ca7625ea5473228a794884e4d7c633c2")] // Star: 552
        [TestCase(@"https://github.com/mason-larobina/luakit.git",
                @"993d814c6a51bf50ec0424e65ce2dc35f4aa435f")] // Star: 513
        [TestCase(@"https://github.com/axkibe/lsyncd.git",
                @"85e95ef15066d0b594144e155c3fa955adae68f3")] // Star: 504
        [TestCase(@"https://github.com/koreader/koreader.git",
                @"f1a8970adb94a6a43cff4d3d16769931039e1f73")] // Star: 466
        [TestCase(@"https://github.com/SnabbCo/snabbswitch.git",
                @"6b88f9c5c70e74aafad691654b677aa492580a96")] // Star: 457
        [TestCase(@"https://github.com/kikito/middleclass.git",
                @"f67092082019d9640db1084c4128525141b722d5")] // Star: 391
        [TestCase(@"https://github.com/pkulchenko/ZeroBraneStudio.git",
                @"95452706a059c60fb34e88a0afff44ba4a9032ac")] // Star: 376
        [TestCase(@"https://github.com/leafo/lapis.git",
                @"f2cdcd8179bc0d57560df5bbd95ee03f26214ef7")] // Star: 374
        [TestCase(@"https://github.com/rtsisyk/luafun.git",
                @"3d44c0841dbc93b645546bb13868550089bfa076")] // Star: 352
        [TestCase(@"https://github.com/koreader/kindlepdfviewer.git",
                @"c5beab2ded22d6bd480604c2bb87f3479d4b3b85")] // Star: 350
        [TestCase(@"https://github.com/copycat-killer/awesome-copycats.git",
                @"2b565ee240c883bbb4115106eef66f9f1508a864")] // Star: 289
        [TestCase(@"https://github.com/tylerneylon/pacpac.git",
                @"cad99bdd64346dbc3180ee611ea502197da8b414")] // Star: 273
        [TestCase(@"https://github.com/exebetche/vlsub.git",
                @"71ef0ef295cafb5477769d9ba3975c6c2ba8d609")] // Star: 259
        [TestCase(@"https://github.com/ignacio/LuaNode.git",
                @"bca3678ec44334b990d026c60ac51d15a5ef2a06")] // Star: 249
        [TestCase(@"https://github.com/stevedonovan/Penlight.git",
                @"6118a923f5ef4a21a9ae432d42707c5f4f0446a1")] // Star: 248
        [TestCase(@"https://github.com/zedshaw/Tir.git",
                @"4c1bdfa5b421e8eb9d3724928055da2728130d40")] // Star: 241
        [TestCase(@"https://github.com/CorsixTH/CorsixTH.git",
                @"a7da0b72a7895d1e253963bb68c32ae6b226991f")] // Star: 238
        [TestCase(@"https://github.com/Olivine-Labs/busted.git",
                @"2ded1f55a2314cee25d4a5689e34e7f92e47ac46")] // Star: 224
        [TestCase(@"https://github.com/SpiderLabs/owasp-modsecurity-crs.git",
                @"6b9e47e4c210a9f2824e042d54b590506982b93a")] // Star: 215
        [TestCase(@"https://github.com/mirven/underscore.lua.git",
                @"1bb487f5a0e523a4438a9d126a7ed44accea5a5a")] // Star: 212
        [TestCase(@"https://github.com/ymobe/rapanui.git",
                @"595076d5706695a8b9b8de393b749d7d90a414a2")] // Star: 201
        [TestCase(@"https://github.com/keplerproject/luarocks.git",
                @"999e27d74abd0bc53165d2ce2642fb5a7af81f40")] // Star: 200
        [TestCase(@"https://github.com/nrk/redis-lua.git",
                @"4408c3d686ffd1f2689c0561a166821785cc09ec")] // Star: 186
        [TestCase(@"https://github.com/gamesys/moonshine.git",
                @"ca6d7a57bfb676caf409e7398a448f90eb139b47")] // Star: 167
        [TestCase(@"https://github.com/garrynewman/garrysmod.git",
                @"1bd8973a763e4bb3f9dcb61bacc25acab2769df8")] // Star: 162
        [TestCase(@"https://github.com/tekkub/wow-ui-source.git",
                @"e9e777a6d1baca29d6253260a69463767d8d9b00")] // Star: 162
        [TestCase(@"https://github.com/malkia/ufo.git",
                @"bdcba300f91c38a2d4652d644b0de9f64ad9936c")] // Star: 154
        [TestCase(@"https://github.com/basecamp/intermission.git",
                @"bb75e1ec83dea67e4db4a6a7c00bc4fcd477eae0")] // Star: 150
        [TestCase(@"https://github.com/wiremod/wire.git",
                @"231148a4da77173768e823a64842753243ec304e")] // Star: 148
        [TestCase(@"https://github.com/minetest/minetest_game.git",
                @"15740ffd3d1ea1af182a8607c600f3af414c2c73")] // Star: 145
        [TestCase(@"https://github.com/bjc/prosody.git",
                @"701fa72ca55909888b3fd428724128c654d8b543")] // Star: 142
        [TestCase(@"https://github.com/vrld/hump.git",
                @"e10fa66e60c5984a8d92801163d23811b7ac509f")] // Star: 142
        [TestCase(@"https://github.com/justincormack/ljsyscall.git",
                @"19eb826a46c177c2f93f9ec8985afc684beb1a78")] // Star: 140
        [TestCase(@"https://github.com/osadchuk/Corona-SDK.tmbundle.git",
                @"86ac8c832b0b9234a9859c5c49e704d4cd7899fb")] // Star: 140
        [TestCase(@"https://github.com/igrigorik/tokyo-recipes.git",
                @"b2b34fe52ca7163d964954f408d9f787c408670a")] // Star: 139
        [TestCase(@"https://github.com/fab13n/metalua.git",
                @"355ff0bc201e00856ba20d82c65b14ffa6fcfe4b")] // Star: 136
        [TestCase(@"https://github.com/kikito/lua_missions.git",
                @"330d7702417c4b18358ab822ba676058892ad889")] // Star: 133
        [TestCase(@"https://github.com/diegonehab/luasocket.git",
                @"6d5e40c324c84d9c1453ae88e0ad5bdd0a631448")] // Star: 131
        [TestCase(@"https://github.com/haberman/gazelle.git",
                @"af0fb1b2bcaae513e1ff54d70f022cdc97a93377")] // Star: 129
        [TestCase(@"https://github.com/loveshell/ngx_lua_waf.git",
                @"2b32a34dfc67e8bbb677987319a30357d5ae6e14")] // Star: 127
        [TestCase(@"https://github.com/Yonaba/Jumper.git",
                @"2479afadf3d50e30ea9f9ab104e6229176d57339")] // Star: 127
        [TestCase(@"https://github.com/ansca/Ghosts-vs.-Monsters.git",
                @"7c036c0d11f279c5dace9dcda4f5ad2242a8ca77")] // Star: 124
        [TestCase(@"https://github.com/FPtje/DarkRP.git",
                @"ed1a0db0afc6302353d474a73777948f230a3d1d")] // Star: 123
        [TestCase(@"https://github.com/mikar/awesome34-themes.git",
                @"312cbc31b271afa164a81d51822de7d54b1153f3")] // Star: 117
        [TestCase(@"https://github.com/kernelsauce/turbo.git",
                @"d1411bbbcbe18cb20a7d91bb95505d952993c31f")] // Star: 115
        [TestCase(@"https://github.com/oneoo/alilua.git",
                @"7ce84488504cd364aa5d86acceff8fb8203b9b4f")] // Star: 112
        [TestCase(@"https://github.com/kikito/inspect.lua.git",
                @"e67a7471d4dd9e22e26b3620ce8701c0e479cb82")] // Star: 112
        [TestCase(@"https://github.com/daogangtang/bamboo.git",
                @"e8e58814b1c511396589846ed3f7cb57a3222d48")] // Star: 111
        [TestCase(@"https://github.com/Kadoba/Advanced-Tiled-Loader.git",
                @"0cc155d14406feb0335d455afd1c1fdd8b028671")] // Star: 110
        [TestCase(@"https://github.com/appwilldev/moochine.git",
                @"9f643a5b51fb132c11ec1c870e4979cf03012992")] // Star: 109
        [TestCase(@"https://github.com/Fluorohydride/ygopro.git",
                @"16a98132749215b8ca27f6e479976ef42c4cd0fc")] // Star: 107
        [TestCase(@"https://github.com/fjolnir/TLC.git",
                @"3b0300d2dac913d2d43162cde52479a2d3986ecb")] // Star: 103
        [TestCase(@"https://github.com/NikolaiResokav/LoveFrames.git",
                @"4dfffef2bc8fd5053e714533b7e6e701722c7a89")] // Star: 101
        [TestCase(@"https://github.com/haste/oUF.git",
                @"955f9424bf53b149fb03822bb2082f8888241c78")] // Star: 99
        [TestCase(@"https://github.com/Shestak/ShestakUI.git",
                @"42527a9c4b81c3c1f762b73d4e777cd0fbd3a852")] // Star: 98
        [TestCase(@"https://github.com/stevedonovan/LDoc.git",
                @"511dfe7df01f92da03c639c5f56495c0c31b6e2b")] // Star: 96
        [TestCase(@"https://github.com/pavouk/lgi.git",
                @"3feb90f4c0c20312e646fb8b1106a5c44a04293e")] // Star: 93
        [TestCase(@"https://github.com/majek/lua-channels.git",
                @"599b27ee7496cef488a057aad86e1ce472190a78")] // Star: 93
        [TestCase(@"https://github.com/makotok/Hanappe.git",
                @"b1a759fe9606bfc49a8df458629099be87ab86f5")] // Star: 92
        [TestCase(@"https://github.com/virgo-agent-toolkit/rackspace-monitoring-agent.git",
                @"5197adcd93c61db3c30b1a45a6fc6dbd1d95d66f")] // Star: 90
        [TestCase(@"https://github.com/lefcha/concurrentlua.git",
                @"74405929dca29b2c61fcb9e94c6b6d8799bb148a")] // Star: 90
        [TestCase(@"https://github.com/pkulchenko/MobDebug.git",
                @"c2b9988ccda7998be466da67690316b45fd3469a")] // Star: 88
        [TestCase(@"https://github.com/davidm/lua-inspect.git",
                @"ca3988019a2f5f1b3f4e94b285eb6e77e5923dd3")] // Star: 88
        [TestCase(@"https://github.com/terceiro/awesome-freedesktop.git",
                @"e514e742864495f23fd725f8c596f41a01d67795")] // Star: 86
        [TestCase(@"https://github.com/norman/telescope.git",
                @"c80b928e306cad7195e1ce5b92ddcdcb0a2c50b2")] // Star: 85
        [TestCase(@"https://github.com/kikito/tween.lua.git",
                @"b14444fe3c6bb0a530b97109f3ce2f5e32f55839")] // Star: 85
        [TestCase(@"https://github.com/romockee/powerarrow.git",
                @"530d208c76280d4f6f566394e6f6a7ebf18fc61e")] // Star: 85
        [TestCase(@"https://github.com/crosslife/LoveClear.git",
                @"dd9a81488bbf598e3e279c545a99c562f201d41b")] // Star: 80
        [TestCase(@"https://github.com/LuaAV/LuaAV.git",
                @"7a5dd24de0c31f0d46b27440363408d1a987b044")] // Star: 79
        [TestCase(@"https://github.com/nrk/mercury.git",
                @"13c85348e059dd24f2c26cf9b4e259fa2d1001c8")] // Star: 77
        [TestCase(@"https://github.com/richardhundt/shine.git",
                @"a3cdf3bfc9645f90572fdd80951302edf6681ede")] // Star: 76
        [TestCase(@"https://github.com/jtarchie/underscore-lua.git",
                @"a98846874399916a8689dd5bfe7cafd373128a66")] // Star: 75
        [TestCase(@"https://github.com/copycat-killer/lain.git",
                @"4c3cf3c0b78624242be877a8454a3cd7c2679d45")] // Star: 73
        [TestCase(@"https://github.com/keplerproject/xavante.git",
                @"58188b9da0d6ad621e5da6089684c5273936b398")] // Star: 73
        [TestCase(@"https://github.com/Cue/hop.git",
                @"3e1b8e6bf535fb12f1ad3348473c64acd3647993")] // Star: 72
        [TestCase(@"https://github.com/vrld/HardonCollider.git",
                @"fb8c0511cf85b86327e34f9356e1e8cf9aee8b47")] // Star: 72
        [TestCase(@"https://github.com/lipp/lua-websockets.git",
                @"9ade24fc972cfc80b5d1d31e1d92ec1d28b7c4be")] // Star: 72
        [TestCase(@"https://github.com/harningt/luajson.git",
                @"827425b10152f8cdc515e4ffb900338506e28910")] // Star: 71
        [TestCase(@"https://github.com/AdamBuchweitz/CrawlSpaceLib.git",
                @"471868fe6cad288cac57281b5218cdd711b826eb")] // Star: 71
        [TestCase(@"https://github.com/tony/awesome-config.git",
                @"2957a1bd888a6a99666f3a67c87d0333474736a9")] // Star: 71
        [TestCase(@"https://github.com/weshoke/Lust.git",
                @"174ee908a3b0ee4ca71c92f314fd0efa82498035")] // Star: 71
        [TestCase(@"https://github.com/miko/Love2d-samples.git",
                @"50a8b4b43d517081a83d036e4510904402dcd7d2")] // Star: 71
        [TestCase(@"https://github.com/Kiwi/clyde.git",
                @"dcdba8de3a3be3685a72a1fcab24080124242a7e")] // Star: 70
        [TestCase(@"https://github.com/Neopallium/lua-handlers.git",
                @"ae93f442175f4f03dd612cafa073df74a8fe626f")] // Star: 70
        [TestCase(@"https://github.com/Stabyourself/mari0.git",
                @"b1412a08a1411b2f237cdd276aee27df008cb06e")] // Star: 69
        [TestCase(@"https://github.com/mcurry/html_cache.git",
                @"83af9d9ee24b94b99387d8171b78e388388be756")] // Star: 68
        [TestCase(@"https://github.com/liseen/lua-resty-http.git",
                @"32d951bb47ebddb82b0e3bf1a6eb0af4a6df9f1e")] // Star: 68
        [TestCase(@"https://github.com/cedlemo/blingbling.git",
                @"7ac39503e2811042cf0d83a0874d230779a710ef")] // Star: 66
        [TestCase(@"https://github.com/stevedonovan/Lake.git",
                @"065ac452fd43be501cab587e8a30d3c9b7479726")] // Star: 66
        [TestCase(@"https://github.com/nmap/nmap.git",
                @"ef328e6eed8410d4b2f18560da43f45856e269db")] // Star: 65
        [TestCase(@"https://github.com/keplerproject/orbit.git",
                @"123ec06e3a9fd844f28a43258227bce19ba8ab30")] // Star: 65
        [TestCase(@"https://github.com/radamanthus/corona-game-template.git",
                @"2d1dc125648b70b855fe5a318ad8a6ee30a4e1d2")] // Star: 65
        [TestCase(@"https://github.com/ostinelli/gin.git",
                @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76")] // Star: 64
        [TestCase(@"https://github.com/ignacio/LuaOAuth.git",
                @"3e1e6962658cbb78a5cd3e10c8f6abd35d59232a")] // Star: 64
        [TestCase(@"https://github.com/davidm/lua2c.git",
                @"c5b239dd5a9fad5718ffaa16e6a30cca8053ba92")] // Star: 62
        [TestCase(@"https://github.com/haberman/jitdemo.git",
                @"387503c5b8db268a6236a46e491d6f756ed17d31")] // Star: 62
        [TestCase(@"https://github.com/Jiyambi/WoW-Pro-Guides.git",
                @"d2179d9532aec0a86c6a0e6ae548fdc1c5314a4c")] // Star: 61
        [TestCase(@"https://github.com/Germanunkol/trAInsported.git",
                @"9acd13435ac05ca3821688b1c5d60ba115625e8b")] // Star: 61
        [TestCase(@"https://github.com/torhve/LuaWeb.git",
                @"da1b73e7b70c938e35051a242c6fa70236e60aac")] // Star: 61
        [TestCase(@"https://github.com/henkboom/pax-britannica.git",
                @"a7a3c0c21e5b27e6f4be3b0b817ebd29cd23fa7d")] // Star: 60
        [TestCase(@"https://github.com/roaminggamer/SSKCorona.git",
                @"a9d6dfec85c01c2d9f8d455a10dcfefcafe35694")] // Star: 60
        [TestCase(@"https://github.com/vincentbernat/awesome-configuration.git",
                @"b649c57c91ba4cb624f37d3f2a4249d9806da68c")] // Star: 59
        [TestCase(@"https://github.com/kikito/love-tile-tutorial.git",
                @"92c5ce5e7e5aa9de461f948c17ed5c8d3af1d0d4")] // Star: 59
        [TestCase(@"https://github.com/dualface/quick-x-server.git",
                @"2c037690610d92692744bf78fc136dec8068fddf")] // Star: 59
        [TestCase(@"https://github.com/josefnpat/vapor.git",
                @"168e91c009ad7bb270498721ff753b4eb1a33038")] // Star: 58
        [TestCase(@"https://github.com/geoffleyland/luatrace.git",
                @"6150cfd6290986adab8ea948e756ee17c80d098a")] // Star: 58
        [TestCase(@"https://github.com/Yonaba/30log.git",
                @"25022b30e58f1590ca3d2bc2c17107b869c38d62")] // Star: 57
        [TestCase(@"https://github.com/SimonLarsen/mrrescue.git",
                @"8f226413b95544d0e0744d9c3e92c68b87659483")] // Star: 57
        [TestCase(@"https://github.com/Nuku/Flexible-Survival.git",
                @"4b75f275ece08e07d1325efc3205578edc0a021b")] // Star: 56
        [TestCase(@"https://github.com/meric/l2l.git",
                @"e9394879e9bde63b1b21e39928ac19f304fc1b39")] // Star: 56
        [TestCase(@"https://github.com/pkulchenko/serpent.git",
                @"026f4e1a5c34f0670948a13d2182729448a260f2")] // Star: 56
        [TestCase(@"https://github.com/AlexChittock/SimpleShortener.git",
                @"76462aeea14adcc0aef49c2cfa8a49951b5d460e")] // Star: 55
        [TestCase(@"https://github.com/willsteel/lcpp.git",
                @"7fdda9a5e3eacccee7571130602dc1381c01bcd9")] // Star: 55
        [TestCase(@"https://github.com/dmccuskey/DMC-Corona-Library.git",
                @"8c85803e39a673cc84b6aa089b51be56f05dd062")] // Star: 55
        [TestCase(@"https://github.com/Neopallium/lua-pb.git",
                @"862fe3121e71f695d9a44ee1d1038069292b69f3")] // Star: 54
        [TestCase(@"https://github.com/keplerproject/luadoc.git",
                @"5250a12bf3bd45873a0f14305b363e53dc8b4a86")] // Star: 53
        [TestCase(@"https://github.com/SnakeSVx/spacebuild.git",
                @"68186b8bc7cabbb5275afd734fae9613fbd8761d")] // Star: 53
        [TestCase(@"https://github.com/darklajid/ansible-communication.git",
                @"003bc68dcbb9606a8099132a399cf21bf342e81c")] // Star: 53
        [TestCase(@"https://github.com/ansca/Corona-Comics-SDK-2.0.git",
                @"ac2abb7ef77753bb01e76ce008d88cece46661b4")] // Star: 53
        [TestCase(@"https://github.com/xolox/vim-lua-inspect.git",
                @"d7fb876f0291cbd13c4c38177ada015fafc58770")] // Star: 53
        [TestCase(@"https://github.com/Overtorment/NoobHub.git",
                @"b0e44e70f44544033e3d50d7ea345fc02db76fe5")] // Star: 53
        [TestCase(@"https://github.com/annulen/premake.git",
                @"c559fa4913bd86be6e415c3b193db90ae4607f5b")] // Star: 52
        [TestCase(@"https://github.com/yuri/sputnik.git",
                @"d4c41a5a6130cca259dc2f21c1d5d99ca6a225ac")] // Star: 51
        [TestCase(@"https://github.com/ignacio/StackTracePlus.git",
                @"3c0d8a09670a40267104348feac19de73191d398")] // Star: 51
        [TestCase(@"https://github.com/leafo/magick.git",
                @"6ba5063b2fe3cf043b4247e9508a6c74b211e704")] // Star: 51
        [TestCase(@"https://github.com/mirven/luaspec.git",
                @"c0c774b54dcc214250cc8eb8aea0dcea60dc6f7c")] // Star: 49
        [TestCase(@"https://github.com/iamgreaser/iceball.git",
                @"4ae5d09ce4fd2269f4e097b63bd0fd9b83f2198f")] // Star: 49
        [TestCase(@"https://github.com/shawndumas/adventure.lua.git",
                @"e98626163129f7c3c4fa6f23abaad1d16b524b16")] // Star: 48
        [TestCase(@"https://github.com/Olivine-Labs/lustache.git",
                @"3358eda141041f8998b938c242b1eda7817898e9")] // Star: 48
        [TestCase(@"https://github.com/bioe007/awesome-configs.git",
                @"cb91a271d55a40cae6b25b0a34ded6947211353f")] // Star: 47
        [TestCase(@"https://github.com/xopxe/Lumen.git",
                @"264d9d042ee9848bccfd064d69259c1d6bde0a2e")] // Star: 47
        [TestCase(@"https://github.com/Neopallium/lualogging.git",
                @"c85130120406b9641e96ab05f782dde819fbd102")] // Star: 47
        [TestCase(@"https://github.com/Bertram25/ValyriaTear.git",
                @"a0e86da761fbc84ace9a778faf64e0f3687dbb3e")] // Star: 46
        [TestCase(@"https://github.com/keplerproject/wsapi.git",
                @"eed8338401196cc155e59280adbe58d78933ead0")] // Star: 46
        [TestCase(@"https://github.com/wiremod/advduplicator.git",
                @"b00138d1b01545fbd6bdec9f7a57597b8c6da164")] // Star: 46
        [TestCase(@"https://github.com/GymbylCoding/Dusk-Engine.git",
                @"f0fcdfc2cd628966bbf208bcb6bf3c3374dd1e42")] // Star: 46
        [TestCase(@"https://github.com/mtourne/nginx_log_by_lua.git",
                @"adc7ecbb3107e0b2a487d851acd33464215a076a")] // Star: 46
        [TestCase(@"https://github.com/Yonaba/Moses.git",
                @"57c7b5d1d1f074cafbd570088ad8681b03c65601")] // Star: 46
        [TestCase(@"https://github.com/stevedonovan/Microlight.git",
                @"95ae73f9830aec3bb1d4773156a6f921dfbed9b4")] // Star: 46
        [TestCase(@"https://github.com/appwilldev/moochine-demo.git",
                @"3b3f565386d43aa533793700c020c4f096ac9636")] // Star: 45
        [TestCase(@"https://github.com/silentbicycle/tangram.git",
                @"85f56670ac839def04715457e1ddaaba7f340bc1")] // Star: 45
        [TestCase(@"https://github.com/metadeus/luv.git",
                @"655c0efc14572d18744aff336210b30574dd7eaf")] // Star: 44
        [TestCase(@"https://github.com/lubyk/dub.git",
                @"b0c7087e878937399f329468bff41de9484f8b0c")] // Star: 44
        [TestCase(@"https://github.com/keplerproject/copas.git",
                @"d2474ab444af5c2bff0ae23f60affb7c64f49242")] // Star: 44
        [TestCase(@"https://github.com/pygy/LuLPeg.git",
                @"c457b27e0d7fc935b133921bf3aee92efffe40c8")] // Star: 44
        [TestCase(@"https://github.com/franko/luajit-lang-toolkit.git",
                @"838b951f65899330a6b707cde96582b5f795abe3")] // Star: 43
        [TestCase(@"https://github.com/Elv13/tyrannical.git",
                @"117bf645ddf015a9da63da8c33cc7da004661261")] // Star: 43
        [TestCase(@"https://github.com/lua-nucleo/lua-nucleo.git",
                @"570e115dab1260ad433bd778eebb5d91fd122d5a")] // Star: 43
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "lua_repo.txt", "*.lua");
        }
    }
}