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
        [TestCase(@"https://github.com/stevedonovan/Penlight.git",
                @"6118a923f5ef4a21a9ae432d42707c5f4f0446a1")] // Star: 248
        [TestCase(@"https://github.com/ignacio/LuaNode.git",
                @"bca3678ec44334b990d026c60ac51d15a5ef2a06")] // Star: 249
        [TestCase(@"https://github.com/CorsixTH/CorsixTH.git",
                @"a7da0b72a7895d1e253963bb68c32ae6b226991f")] // Star: 238
        [TestCase(@"https://github.com/exebetche/vlsub.git",
                @"71ef0ef295cafb5477769d9ba3975c6c2ba8d609")] // Star: 259
        [TestCase(@"https://github.com/zedshaw/Tir.git",
                @"4c1bdfa5b421e8eb9d3724928055da2728130d40")] // Star: 241
        [TestCase(@"https://github.com/Olivine-Labs/busted.git",
                @"2ded1f55a2314cee25d4a5689e34e7f92e47ac46")] // Star: 224
        [TestCase(@"https://github.com/SpiderLabs/owasp-modsecurity-crs.git",
                @"6b9e47e4c210a9f2824e042d54b590506982b93a")] // Star: 215
        [TestCase(@"https://github.com/ymobe/rapanui.git",
                @"595076d5706695a8b9b8de393b749d7d90a414a2")] // Star: 201
        [TestCase(@"https://github.com/mirven/underscore.lua.git",
                @"1bb487f5a0e523a4438a9d126a7ed44accea5a5a")] // Star: 212
        [TestCase(@"https://github.com/keplerproject/luarocks.git",
                @"999e27d74abd0bc53165d2ce2642fb5a7af81f40")] // Star: 200
        [TestCase(@"https://github.com/nrk/redis-lua.git",
                @"4408c3d686ffd1f2689c0561a166821785cc09ec")] // Star: 186
        [TestCase(@"https://github.com/garrynewman/garrysmod.git",
                @"1bd8973a763e4bb3f9dcb61bacc25acab2769df8")] // Star: 162
        [TestCase(@"https://github.com/tekkub/wow-ui-source.git",
                @"e9e777a6d1baca29d6253260a69463767d8d9b00")] // Star: 162
        [TestCase(@"https://github.com/malkia/ufo.git",
                @"bdcba300f91c38a2d4652d644b0de9f64ad9936c")] // Star: 154
        [TestCase(@"https://github.com/wiremod/wire.git",
                @"231148a4da77173768e823a64842753243ec304e")] // Star: 148
        [TestCase(@"https://github.com/basecamp/intermission.git",
                @"bb75e1ec83dea67e4db4a6a7c00bc4fcd477eae0")] // Star: 150
        [TestCase(@"https://github.com/minetest/minetest_game.git",
                @"15740ffd3d1ea1af182a8607c600f3af414c2c73")] // Star: 145
        [TestCase(@"https://github.com/justincormack/ljsyscall.git",
                @"19eb826a46c177c2f93f9ec8985afc684beb1a78")] // Star: 140
        [TestCase(@"https://github.com/bjc/prosody.git",
                @"701fa72ca55909888b3fd428724128c654d8b543")] // Star: 142
        [TestCase(@"https://github.com/osadchuk/Corona-SDK.tmbundle.git",
                @"86ac8c832b0b9234a9859c5c49e704d4cd7899fb")] // Star: 140
        [TestCase(@"https://github.com/igrigorik/tokyo-recipes.git",
                @"b2b34fe52ca7163d964954f408d9f787c408670a")] // Star: 139
        [TestCase(@"https://github.com/vrld/hump.git",
                @"e10fa66e60c5984a8d92801163d23811b7ac509f")] // Star: 142
        [TestCase(@"https://github.com/haberman/gazelle.git",
                @"af0fb1b2bcaae513e1ff54d70f022cdc97a93377")] // Star: 129
        [TestCase(@"https://github.com/loveshell/ngx_lua_waf.git",
                @"2b32a34dfc67e8bbb677987319a30357d5ae6e14")] // Star: 127
        [TestCase(@"https://github.com/kikito/lua_missions.git",
                @"330d7702417c4b18358ab822ba676058892ad889")] // Star: 133
        [TestCase(@"https://github.com/FPtje/DarkRP.git",
                @"ed1a0db0afc6302353d474a73777948f230a3d1d")] // Star: 123
        [TestCase(@"https://github.com/fab13n/metalua.git",
                @"355ff0bc201e00856ba20d82c65b14ffa6fcfe4b")] // Star: 136
        [TestCase(@"https://github.com/ansca/Ghosts-vs.-Monsters.git",
                @"7c036c0d11f279c5dace9dcda4f5ad2242a8ca77")] // Star: 124
        [TestCase(@"https://github.com/mikar/awesome34-themes.git",
                @"312cbc31b271afa164a81d51822de7d54b1153f3")] // Star: 117
        [TestCase(@"https://github.com/kernelsauce/turbo.git",
                @"d1411bbbcbe18cb20a7d91bb95505d952993c31f")] // Star: 115
        [TestCase(@"https://github.com/oneoo/alilua.git",
                @"7ce84488504cd364aa5d86acceff8fb8203b9b4f")] // Star: 112
        [TestCase(@"https://github.com/daogangtang/bamboo.git",
                @"e8e58814b1c511396589846ed3f7cb57a3222d48")] // Star: 111
        [TestCase(@"https://github.com/Fluorohydride/ygopro.git",
                @"16a98132749215b8ca27f6e479976ef42c4cd0fc")] // Star: 107
        [TestCase(@"https://github.com/Yonaba/Jumper.git",
                @"2479afadf3d50e30ea9f9ab104e6229176d57339")] // Star: 127
        [TestCase(@"https://github.com/appwilldev/moochine.git",
                @"9f643a5b51fb132c11ec1c870e4979cf03012992")] // Star: 109
        [TestCase(@"https://github.com/kikito/inspect.lua.git",
                @"e67a7471d4dd9e22e26b3620ce8701c0e479cb82")] // Star: 112
        [TestCase(@"https://github.com/diegonehab/luasocket.git",
                @"6d5e40c324c84d9c1453ae88e0ad5bdd0a631448")] // Star: 131
        [TestCase(@"https://github.com/NikolaiResokav/LoveFrames.git",
                @"4dfffef2bc8fd5053e714533b7e6e701722c7a89")] // Star: 101
        [TestCase(@"https://github.com/haste/oUF.git",
                @"955f9424bf53b149fb03822bb2082f8888241c78")] // Star: 99
        [TestCase(@"https://github.com/Kadoba/Advanced-Tiled-Loader.git",
                @"0cc155d14406feb0335d455afd1c1fdd8b028671")] // Star: 110
        [TestCase(@"https://github.com/fjolnir/TLC.git",
                @"3b0300d2dac913d2d43162cde52479a2d3986ecb")] // Star: 103
        [TestCase(@"https://github.com/Shestak/ShestakUI.git",
                @"42527a9c4b81c3c1f762b73d4e777cd0fbd3a852")] // Star: 98
        [TestCase(@"https://github.com/pavouk/lgi.git",
                @"3feb90f4c0c20312e646fb8b1106a5c44a04293e")] // Star: 93
        [TestCase(@"https://github.com/majek/lua-channels.git",
                @"599b27ee7496cef488a057aad86e1ce472190a78")] // Star: 93
        [TestCase(@"https://github.com/makotok/Hanappe.git",
                @"b1a759fe9606bfc49a8df458629099be87ab86f5")] // Star: 92
        [TestCase(@"https://github.com/virgo-agent-toolkit/rackspace-monitoring-agent.git",
                @"5197adcd93c61db3c30b1a45a6fc6dbd1d95d66f")] // Star: 90
        [TestCase(@"https://github.com/stevedonovan/LDoc.git",
                @"511dfe7df01f92da03c639c5f56495c0c31b6e2b")] // Star: 96
        [TestCase(@"https://github.com/pkulchenko/MobDebug.git",
                @"c2b9988ccda7998be466da67690316b45fd3469a")] // Star: 88
        [TestCase(@"https://github.com/norman/telescope.git",
                @"c80b928e306cad7195e1ce5b92ddcdcb0a2c50b2")] // Star: 85
        [TestCase(@"https://github.com/davidm/lua-inspect.git",
                @"ca3988019a2f5f1b3f4e94b285eb6e77e5923dd3")] // Star: 88
        [TestCase(@"https://github.com/terceiro/awesome-freedesktop.git",
                @"e514e742864495f23fd725f8c596f41a01d67795")] // Star: 86
        [TestCase(@"https://github.com/lefcha/concurrentlua.git",
                @"74405929dca29b2c61fcb9e94c6b6d8799bb148a")] // Star: 90
        [TestCase(@"https://github.com/kikito/tween.lua.git",
                @"b14444fe3c6bb0a530b97109f3ce2f5e32f55839")] // Star: 85
        [TestCase(@"https://github.com/nrk/mercury.git",
                @"13c85348e059dd24f2c26cf9b4e259fa2d1001c8")] // Star: 77
        [TestCase(@"https://github.com/romockee/powerarrow.git",
                @"530d208c76280d4f6f566394e6f6a7ebf18fc61e")] // Star: 85
        [TestCase(@"https://github.com/richardhundt/shine.git",
                @"a3cdf3bfc9645f90572fdd80951302edf6681ede")] // Star: 76
        [TestCase(@"https://github.com/Cue/hop.git",
                @"3e1b8e6bf535fb12f1ad3348473c64acd3647993")] // Star: 72
        [TestCase(@"https://github.com/copycat-killer/lain.git",
                @"4c3cf3c0b78624242be877a8454a3cd7c2679d45")] // Star: 73
        [TestCase(@"https://github.com/keplerproject/xavante.git",
                @"58188b9da0d6ad621e5da6089684c5273936b398")] // Star: 73
        [TestCase(@"https://github.com/Kiwi/clyde.git",
                @"dcdba8de3a3be3685a72a1fcab24080124242a7e")] // Star: 70
        [TestCase(@"https://github.com/jtarchie/underscore-lua.git",
                @"a98846874399916a8689dd5bfe7cafd373128a66")] // Star: 75
        [TestCase(@"https://github.com/harningt/luajson.git",
                @"827425b10152f8cdc515e4ffb900338506e28910")] // Star: 71
        [TestCase(@"https://github.com/LuaAV/LuaAV.git",
                @"7a5dd24de0c31f0d46b27440363408d1a987b044")] // Star: 79
        [TestCase(@"https://github.com/AdamBuchweitz/CrawlSpaceLib.git",
                @"471868fe6cad288cac57281b5218cdd711b826eb")] // Star: 71
        [TestCase(@"https://github.com/vrld/HardonCollider.git",
                @"fb8c0511cf85b86327e34f9356e1e8cf9aee8b47")] // Star: 72
        [TestCase(@"https://github.com/mcurry/html_cache.git",
                @"83af9d9ee24b94b99387d8171b78e388388be756")] // Star: 68
        [TestCase(@"https://github.com/Neopallium/lua-handlers.git",
                @"ae93f442175f4f03dd612cafa073df74a8fe626f")] // Star: 70
        [TestCase(@"https://github.com/tony/awesome-config.git",
                @"2957a1bd888a6a99666f3a67c87d0333474736a9")] // Star: 71
        [TestCase(@"https://github.com/Stabyourself/mari0.git",
                @"b1412a08a1411b2f237cdd276aee27df008cb06e")] // Star: 69
        [TestCase(@"https://github.com/lipp/lua-websockets.git",
                @"9ade24fc972cfc80b5d1d31e1d92ec1d28b7c4be")] // Star: 72
        [TestCase(@"https://github.com/nmap/nmap.git",
                @"ef328e6eed8410d4b2f18560da43f45856e269db")] // Star: 65
        [TestCase(@"https://github.com/liseen/lua-resty-http.git",
                @"32d951bb47ebddb82b0e3bf1a6eb0af4a6df9f1e")] // Star: 68
        [TestCase(@"https://github.com/crosslife/LoveClear.git",
                @"dd9a81488bbf598e3e279c545a99c562f201d41b")] // Star: 80
        [TestCase(@"https://github.com/keplerproject/orbit.git",
                @"123ec06e3a9fd844f28a43258227bce19ba8ab30")] // Star: 65
        [TestCase(@"https://github.com/radamanthus/corona-game-template.git",
                @"2d1dc125648b70b855fe5a318ad8a6ee30a4e1d2")] // Star: 65
        [TestCase(@"https://github.com/weshoke/Lust.git",
                @"174ee908a3b0ee4ca71c92f314fd0efa82498035")] // Star: 71
        [TestCase(@"https://github.com/cedlemo/blingbling.git",
                @"7ac39503e2811042cf0d83a0874d230779a710ef")] // Star: 66
        [TestCase(@"https://github.com/stevedonovan/Lake.git",
                @"065ac452fd43be501cab587e8a30d3c9b7479726")] // Star: 66
        [TestCase(@"https://github.com/ostinelli/gin.git",
                @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76")] // Star: 64
        [TestCase(@"https://github.com/Jiyambi/WoW-Pro-Guides.git",
                @"d2179d9532aec0a86c6a0e6ae548fdc1c5314a4c")] // Star: 61
        [TestCase(@"https://github.com/ignacio/LuaOAuth.git",
                @"3e1e6962658cbb78a5cd3e10c8f6abd35d59232a")] // Star: 64
        [TestCase(@"https://github.com/davidm/lua2c.git",
                @"c5b239dd5a9fad5718ffaa16e6a30cca8053ba92")] // Star: 62
        [TestCase(@"https://github.com/henkboom/pax-britannica.git",
                @"a7a3c0c21e5b27e6f4be3b0b817ebd29cd23fa7d")] // Star: 60
        [TestCase(@"https://github.com/Germanunkol/trAInsported.git",
                @"9acd13435ac05ca3821688b1c5d60ba115625e8b")] // Star: 61
        [TestCase(@"https://github.com/vincentbernat/awesome-configuration.git",
                @"b649c57c91ba4cb624f37d3f2a4249d9806da68c")] // Star: 59
        [TestCase(@"https://github.com/josefnpat/vapor.git",
                @"168e91c009ad7bb270498721ff753b4eb1a33038")] // Star: 58
        [TestCase(@"https://github.com/miko/Love2d-samples.git",
                @"50a8b4b43d517081a83d036e4510904402dcd7d2")] // Star: 71
        [TestCase(@"https://github.com/roaminggamer/SSKCorona.git",
                @"a9d6dfec85c01c2d9f8d455a10dcfefcafe35694")] // Star: 60
        [TestCase(@"https://github.com/Yonaba/30log.git",
                @"25022b30e58f1590ca3d2bc2c17107b869c38d62")] // Star: 57
        [TestCase(@"https://github.com/AlexChittock/SimpleShortener.git",
                @"76462aeea14adcc0aef49c2cfa8a49951b5d460e")] // Star: 55
        [TestCase(@"https://github.com/Nuku/Flexible-Survival.git",
                @"4b75f275ece08e07d1325efc3205578edc0a021b")] // Star: 56
        [TestCase(@"https://github.com/torhve/LuaWeb.git",
                @"da1b73e7b70c938e35051a242c6fa70236e60aac")] // Star: 61
        [TestCase(@"https://github.com/meric/l2l.git",
                @"e9394879e9bde63b1b21e39928ac19f304fc1b39")] // Star: 56
        [TestCase(@"https://github.com/geoffleyland/luatrace.git",
                @"6150cfd6290986adab8ea948e756ee17c80d098a")] // Star: 58
        [TestCase(@"https://github.com/willsteel/lcpp.git",
                @"7fdda9a5e3eacccee7571130602dc1381c01bcd9")] // Star: 55
        [TestCase(@"https://github.com/keplerproject/luadoc.git",
                @"5250a12bf3bd45873a0f14305b363e53dc8b4a86")] // Star: 53
        [TestCase(@"https://github.com/SnakeSVx/spacebuild.git",
                @"68186b8bc7cabbb5275afd734fae9613fbd8761d")] // Star: 53
        [TestCase(@"https://github.com/yuri/sputnik.git",
                @"d4c41a5a6130cca259dc2f21c1d5d99ca6a225ac")] // Star: 51
        [TestCase(@"https://github.com/kikito/love-tile-tutorial.git",
                @"92c5ce5e7e5aa9de461f948c17ed5c8d3af1d0d4")] // Star: 59
        [TestCase(@"https://github.com/annulen/premake.git",
                @"c559fa4913bd86be6e415c3b193db90ae4607f5b")] // Star: 52
        [TestCase(@"https://github.com/darklajid/ansible-communication.git",
                @"003bc68dcbb9606a8099132a399cf21bf342e81c")] // Star: 53
        [TestCase(@"https://github.com/haberman/jitdemo.git",
                @"387503c5b8db268a6236a46e491d6f756ed17d31")] // Star: 62
        [TestCase(@"https://github.com/dualface/quick-x-server.git",
                @"2c037690610d92692744bf78fc136dec8068fddf")] // Star: 59
        [TestCase(@"https://github.com/ansca/Corona-Comics-SDK-2.0.git",
                @"ac2abb7ef77753bb01e76ce008d88cece46661b4")] // Star: 53
        [TestCase(@"https://github.com/Neopallium/lua-pb.git",
                @"862fe3121e71f695d9a44ee1d1038069292b69f3")] // Star: 54
        [TestCase(@"https://github.com/dmccuskey/DMC-Corona-Library.git",
                @"8c85803e39a673cc84b6aa089b51be56f05dd062")] // Star: 55
        [TestCase(@"https://github.com/pkulchenko/serpent.git",
                @"026f4e1a5c34f0670948a13d2182729448a260f2")] // Star: 56
        [TestCase(@"https://github.com/mirven/luaspec.git",
                @"c0c774b54dcc214250cc8eb8aea0dcea60dc6f7c")] // Star: 49
        [TestCase(@"https://github.com/ignacio/StackTracePlus.git",
                @"3c0d8a09670a40267104348feac19de73191d398")] // Star: 51
        [TestCase(@"https://github.com/iamgreaser/iceball.git",
                @"4ae5d09ce4fd2269f4e097b63bd0fd9b83f2198f")] // Star: 49
        [TestCase(@"https://github.com/bioe007/awesome-configs.git",
                @"cb91a271d55a40cae6b25b0a34ded6947211353f")] // Star: 47
        [TestCase(@"https://github.com/Bertram25/ValyriaTear.git",
                @"a0e86da761fbc84ace9a778faf64e0f3687dbb3e")] // Star: 46
        [TestCase(@"https://github.com/shawndumas/adventure.lua.git",
                @"e98626163129f7c3c4fa6f23abaad1d16b524b16")] // Star: 48
        [TestCase(@"https://github.com/xopxe/Lumen.git",
                @"264d9d042ee9848bccfd064d69259c1d6bde0a2e")] // Star: 47
        [TestCase(@"https://github.com/keplerproject/wsapi.git",
                @"eed8338401196cc155e59280adbe58d78933ead0")] // Star: 46
        [TestCase(@"https://github.com/wiremod/advduplicator.git",
                @"b00138d1b01545fbd6bdec9f7a57597b8c6da164")] // Star: 46
        [TestCase(@"https://github.com/xolox/vim-lua-inspect.git",
                @"d7fb876f0291cbd13c4c38177ada015fafc58770")] // Star: 53
        [TestCase(@"https://github.com/metadeus/luv.git",
                @"655c0efc14572d18744aff336210b30574dd7eaf")] // Star: 44
        [TestCase(@"https://github.com/appwilldev/moochine-demo.git",
                @"3b3f565386d43aa533793700c020c4f096ac9636")] // Star: 45
        [TestCase(@"https://github.com/GymbylCoding/Dusk-Engine.git",
                @"f0fcdfc2cd628966bbf208bcb6bf3c3374dd1e42")] // Star: 46
        [TestCase(@"https://github.com/mtourne/nginx_log_by_lua.git",
                @"adc7ecbb3107e0b2a487d851acd33464215a076a")] // Star: 46
        [TestCase(@"https://github.com/silentbicycle/tangram.git",
                @"85f56670ac839def04715457e1ddaaba7f340bc1")] // Star: 45
        [TestCase(@"https://github.com/SimonLarsen/mrrescue.git",
                @"8f226413b95544d0e0744d9c3e92c68b87659483")] // Star: 57
        [TestCase(@"https://github.com/franko/luajit-lang-toolkit.git",
                @"838b951f65899330a6b707cde96582b5f795abe3")] // Star: 43
        [TestCase(@"https://github.com/Yonaba/Moses.git",
                @"57c7b5d1d1f074cafbd570088ad8681b03c65601")] // Star: 46
        [TestCase(@"https://github.com/Overtorment/NoobHub.git",
                @"b0e44e70f44544033e3d50d7ea345fc02db76fe5")] // Star: 53
        [TestCase(@"https://github.com/Elv13/tyrannical.git",
                @"117bf645ddf015a9da63da8c33cc7da004661261")] // Star: 43
        [TestCase(@"https://github.com/Neopallium/lualogging.git",
                @"c85130120406b9641e96ab05f782dde819fbd102")] // Star: 47
        [TestCase(@"https://github.com/stevedonovan/Microlight.git",
                @"95ae73f9830aec3bb1d4773156a6f921dfbed9b4")] // Star: 46
        [TestCase(@"https://github.com/bioe007/awesome-shifty.git",
                @"b12b66e6a26a2c5fbec6c1119dd29b4f8faf0fe0")] // Star: 41
        [TestCase(@"https://github.com/lubyk/dub.git",
                @"b0c7087e878937399f329468bff41de9484f8b0c")] // Star: 44
        [TestCase(@"https://github.com/lilydjwg/myawesomerc.git",
                @"d7183f3cb533064ecc39a51e621fc556671ff449")] // Star: 42
        [TestCase(@"https://github.com/lua-nucleo/lua-nucleo.git",
                @"570e115dab1260ad433bd778eebb5d91fd122d5a")] // Star: 43
        [TestCase(@"https://github.com/kikito/anim8.git",
                @"8f110db45f63451df2589255c009ad0e2312eed6")] // Star: 41
        [TestCase(@"https://github.com/Olivine-Labs/lustache.git",
                @"3358eda141041f8998b938c242b1eda7817898e9")] // Star: 48
        [TestCase(@"https://github.com/keplerproject/copas.git",
                @"d2474ab444af5c2bff0ae23f60affb7c64f49242")] // Star: 44
        [TestCase(@"https://github.com/ravageralpha/my_openwrt_mod.git",
                @"70fcba54825c9da6e09e7cdeb8ba57809c36c8e1")] // Star: 40
        [TestCase(@"https://github.com/norman/lua-haml.git",
                @"7eb4179f9003cc4f3d1db2adbaf81cea2fc8994c")] // Star: 39
        [TestCase(@"https://github.com/leafo/magick.git",
                @"6ba5063b2fe3cf043b4247e9508a6c74b211e704")] // Star: 51
        [TestCase(@"https://github.com/iamaleksey/lua-zmq.git",
                @"5578612efe296faa36203c7b80507e38fa7714e0")] // Star: 40
        [TestCase(@"https://github.com/FourOne/Tukui_Filger.git",
                @"2fb93152102c651ed8b2e8271727cf6d002738a2")] // Star: 39
        [TestCase(@"https://github.com/vrld/Quickie.git",
                @"52d06037d13afdc68384f1031766ac087cb5e70e")] // Star: 41
        [TestCase(@"https://github.com/silentbicycle/lunatest.git",
                @"e33f2ff55dc843a29d01013aef22b4b89903599b")] // Star: 41
        [TestCase(@"https://github.com/Neopallium/LuaNativeObjects.git",
                @"a5c444769b7dfad1436a1bc4fe21dce75629db25")] // Star: 39
        [TestCase(@"https://github.com/stevedonovan/LuaMacro.git",
                @"4ec5a8ebdbb9576ca9aa16cc6645f4c7cf2a7705")] // Star: 38
        [TestCase(@"https://github.com/headchant/LICK.git",
                @"e2f900bb5dea40f4d8009fad03cdcf4aa96991f7")] // Star: 41
        [TestCase(@"https://github.com/SiENcE/lovecodify.git",
                @"9b84ce1a5f3474707e6021355afd6c2554f18251")] // Star: 38
        [TestCase(@"https://github.com/jp-ganis/JPS.git",
                @"c65f107fa59a5f572e0ffd70be7990a873d87487")] // Star: 38
        [TestCase(@"https://github.com/Toresh/Tukui_ClassTimer.git",
                @"f9f5752d33a1a882cb5f46ef9e42badaa1fb5fc2")] // Star: 37
        [TestCase(@"https://github.com/JesterXL/Robotlegs-for-Corona.git",
                @"79e1407f962dce303325a827adff1fe0a3e16ad6")] // Star: 36
        [TestCase(@"https://github.com/jsimmons/mongrel2-lua.git",
                @"f6d2f50df67c69a56be50d23690530e19e9648db")] // Star: 36
        [TestCase(@"https://github.com/alexander-yakushev/awesompd.git",
                @"00f26f44c5bf890988322b5107ee536531d6e0bc")] // Star: 39
        [TestCase(@"https://github.com/henix/slt2.git",
                @"67141149a05937589548a1368d0b52027014e2f1")] // Star: 40
        [TestCase(@"https://github.com/dualface/cocos2d-x-lua-framework.git",
                @"8ebfc699fb135bd1749de02b6c1d5522ac105dd1")] // Star: 37
        [TestCase(@"https://github.com/UPenn-RoboCup/UPennalizers.git",
                @"abd9b34294a6485965be274333b72f1272f8f3c8")] // Star: 36
        [TestCase(@"https://github.com/Windower/Lua.git",
                @"28926d6c45907ca91d3883599745903173eb15ad")] // Star: 35
        [TestCase(@"https://github.com/pygy/LuLPeg.git",
                @"c457b27e0d7fc935b133921bf3aee92efffe40c8")] // Star: 44
        [TestCase(@"https://github.com/Elv13/awesome-configs.git",
                @"18bbb46a2c8d2fc69e65e0d0a6fe66db9b5e0055")] // Star: 34
        [TestCase(@"https://github.com/ggcrunchy/corona-sdk-snippets.git",
                @"e89f4547a36c4b8b817855e2a3e7c50b9ae19a4d")] // Star: 34
        [TestCase(@"https://github.com/SnakeSVx/sbep.git",
                @"346e1431ed536d4b8b54676d330f28a06c3e54be")] // Star: 38
        [TestCase(@"https://github.com/leafo/heroku-openresty.git",
                @"5945df6f7641e456e51c518947a5f9e50f0cc4d5")] // Star: 34
        [TestCase(@"https://github.com/cloudwu/lua-trace.git",
                @"79a31124f64d863cf670ff82583a144f19570339")] // Star: 40
        [TestCase(@"https://github.com/fperrad/lua-MessagePack.git",
                @"c908ead3c2001663ac3d0b5a9c1001bfdcc87397")] // Star: 36
        [TestCase(@"https://github.com/vain/awesome-vain.git",
                @"a83343157e11efc1e1cbbe7b80ab01d38fca373a")] // Star: 32
        [TestCase(@"https://github.com/chatid/fend.git",
                @"72dc6b024e2cabb4b707250b89097d4ff0da22f2")] // Star: 35
        [TestCase(@"https://github.com/deniza/Ad-Mediator-for-Corona.git",
                @"084d12b45bd576f6abbb34cb3e849aaaa294e91c")] // Star: 34
        [TestCase(@"https://github.com/solso/api-aggregator.git",
                @"2ea1f6b38f9bd4465255cd3a60a6dd6a6442dd9b")] // Star: 36
        [TestCase(@"https://github.com/mpeterv/luacheck.git",
                @"43721c92786dc0b0fded70abe5b51880ec42e5e2")] // Star: 33
        [TestCase(@"https://github.com/stravant/LuaMinify.git",
                @"c284a942089b0154af7498b110e02d1bba8aee16")] // Star: 38
        [TestCase(@"https://github.com/Floobits/diffshipper.git",
                @"8542aeac030cc4f8fa93088a145574e8c379fdd9")] // Star: 33
        [TestCase(@"https://github.com/silentbicycle/tamale.git",
                @"6d8ef8315348b01c88bb9d2245f84d6b1cd68c07")] // Star: 34
        [TestCase(@"https://github.com/tdy/dots.git",
                @"c74fbd925b41c6189ed394854ea289131399f3f1")] // Star: 36
        [TestCase(@"https://github.com/tekkub/libdatabroker-1-1.git",
                @"1a63ede0248c11aa1ee415187c1f9c9489ce3e02")] // Star: 32
        [TestCase(@"https://github.com/dluksza/screenful.git",
                @"758057633588cb35d54417783af1ce14864b8a3c")] // Star: 35
        [TestCase(@"https://github.com/fediaFedia/Omnimo.git",
                @"a98cdf9cc5fa51b1aa82f2834218a3a11085f0b3")] // Star: 36
        [TestCase(@"https://github.com/cycojesus/awesome-solarized.git",
                @"7f9f3615bc0bf283888a60d72f5f8453d8ce8bc0")] // Star: 33
        [TestCase(@"https://github.com/kikito/stateful.lua.git",
                @"eede90c5a5ec97639154b5e4413c337175ed21e2")] // Star: 34
        [TestCase(@"https://github.com/hoelzro/lua-repl.git",
                @"b5fde2ac342def303eda8eb8d51b2bc807fdc4ba")] // Star: 34
        [TestCase(@"https://github.com/JakobOvrum/LuaIRC.git",
                @"16057be815ec4408e32988c561e7ea4038bc53ba")] // Star: 32
        [TestCase(@"https://github.com/Jeija/minetest-mod-mesecons.git",
                @"1f666875807c3c8e6c1771e4fb46c374d2e40ccb")] // Star: 33
        [TestCase(@"https://github.com/catwell/luajit-msgpack-pure.git",
                @"a7f16a0826831dc78ff29b94a834b66847988506")] // Star: 32
        [TestCase(@"https://github.com/brimworks/lua-http-parser.git",
                @"7adc3e7310091db5ffd1c09a87edcbc55255f730")] // Star: 34
        [TestCase(@"https://github.com/nrk/hige.git",
                @"f8ccf97063c62b93224fe6991551522fdaba9083")] // Star: 34
        [TestCase(@"https://github.com/Jasoco/LOVE-Adventure-Game-Engine.git",
                @"5ed8cb4f6b561090ef9b5fccda187b5b32217dbf")] // Star: 33
        [TestCase(@"https://github.com/kikito/cron.lua.git",
                @"170f7d9463de36ecd73c16fd008b3789de2e54cb")] // Star: 31
        [TestCase(@"https://github.com/SpiderLabs/Nmap-Tools.git",
                @"0282df407ae5ba426bd96415fcbe36a166a74838")] // Star: 34
        [TestCase(@"https://github.com/mailru/tntlua.git",
                @"15d742d541725e6eeea96a24d1e60fff38294af5")] // Star: 31
        [TestCase(@"https://github.com/creationix/moonslice-luv.git",
                @"717f5ce1ce96f0c1abb58b97c44e90bbaef814f2")] // Star: 31
        [TestCase(@"https://github.com/bartbes/love-misc-libs.git",
                @"79faade695182e728cd7a5eda1304f3ed5df1073")] // Star: 34
        [TestCase(@"https://github.com/Mic92/vicious.git",
                @"1c626ec7a6988e91f8ffe6c94d516b18bf95f9d9")] // Star: 31
        [TestCase(@"https://github.com/OutlawGameTools/Lime2DTileEngine.git",
                @"b61f2b5ba47bbeef7674436aa8925d2f04c3d926")] // Star: 33
        [TestCase(@"https://github.com/ToxicFrog/vstruct.git",
                @"f230429b6aa0791d0a0f3755ff670372186fb63c")] // Star: 32
        [TestCase(@"https://github.com/pintsized/lua-resty-rack.git",
                @"4d8f8e166c01a7aa8ce9a9f06969699fd0aebf47")] // Star: 33
        [TestCase(@"https://github.com/waf/nice-and-clean-theme.git",
                @"8a0ae5950921c2cadb609ba1c735fd9392bee70c")] // Star: 31
        [TestCase(@"https://github.com/Wiladams/LAPHLibs.git",
                @"aed3531fb6face76c5634bde995e9cf503d6136b")] // Star: 29
        [TestCase(@"https://github.com/cloudwu/luacc.git",
                @"cbf858da578aa75c6e3651e78ea78c19e5e12159")] // Star: 29
        [TestCase(@"https://github.com/wiremod/wire-extras.git",
                @"a2db0eb86660e4f0bbfff935368a6dcd29acfb80")] // Star: 31
        [TestCase(@"https://github.com/GlitchGames/GGData.git",
                @"283673459586a92c75473da7fe97855ec85517a5")] // Star: 30
        [TestCase(@"https://github.com/Chessnut/NutScript.git",
                @"10ae4f18968a265c158a78a14327a56a6a9088ee")] // Star: 29
        [TestCase(@"https://github.com/sroccaserra/object-lua.git",
                @"64f6a91318a310cf2a7ef8eb0884f82d46beead6")] // Star: 31
        [TestCase(@"https://github.com/kikito/bump.lua.git",
                @"f3e2033bf248c4278ca2dc2c7c4e66d5cf413a2f")] // Star: 29
        [TestCase(@"https://github.com/craigmj/json4lua.git",
                @"0459abdca8145b4965b9a818c526c634725986b1")] // Star: 30
        [TestCase(@"https://github.com/wingify/lua-resty-rabbitmqstomp.git",
                @"a8c9a0d9ad5e150b6f284a594e239e7baa766622")] // Star: 31
        [TestCase(@"https://github.com/z1lt0id/awesome.git",
                @"a93c6274fcd411dcd2224b963238928ab821a064")] // Star: 32
        [TestCase(@"https://github.com/fsantanna/luagravity.git",
                @"58c761ded3b8f27e1f2f7a0810898a9e91d7437a")] // Star: 28
        [TestCase(@"https://github.com/tales/sourceoftales.git",
                @"f259c99ebb42a4956f6e4c5464051651a3226d5a")] // Star: 29
        [TestCase(@"https://github.com/Nayruden/Ulysses.git",
                @"3860886d9dabf36b1ad7e7f81d7e26776c6960c3")] // Star: 32
        [TestCase(@"https://github.com/paulofmandown/rotLove.git",
                @"bb089f3294ba9cd1f7cc031dffc0b695fa2ed4bf")] // Star: 29
        [TestCase(@"https://github.com/ansca/Air-Hockey.git",
                @"ff05ac99ec276259249ec423520064dafaac0eb7")] // Star: 31
        [TestCase(@"https://github.com/DarkstarProject/darkstar.git",
                @"367bd9591cc586b06171c4679d7722cedad00557")] // Star: 28
        [TestCase(@"https://github.com/khaledhosny/euler-otf.git",
                @"6c76de44dcff216f2d91d0638386cb575a52ded5")] // Star: 30
        [TestCase(@"https://github.com/ansca/TinyPenguin.git",
                @"865b63634e55d6769e3a00b1da902c79ede68787")] // Star: 29
        [TestCase(@"https://github.com/derickd/moaigui.git",
                @"9e0300469df5c65bf2445705c2cda6df9bc81b1f")] // Star: 28
        [TestCase(@"https://github.com/Eonblast/fleece-lite.git",
                @"06103ea87601c74801ca5780bc9014011243bbec")] // Star: 28
        [TestCase(@"https://github.com/mason-larobina/luakit-plugins.git",
                @"d5c774952d1ebdb36b20f5dfedb0f831abb8743a")] // Star: 28
        [TestCase(@"https://github.com/stevedonovan/luaish.git",
                @"6c5ea145e8faedd6bf65d7e80cb4fc741629cf16")] // Star: 27
        [TestCase(@"https://github.com/jtarchie/sinatra-openresty.git",
                @"7f7ed65eb389f432bd0a80bd226e8c1bbdc15352")] // Star: 31
        [TestCase(@"https://github.com/fgprodigal/RayUI.git",
                @"2ffd999fec0a372a70247058c6c00f8cb766acab")] // Star: 26
        [TestCase(@"https://github.com/Asphyxia/Tukui.git",
                @"3c8e581abc23fc8bcd7aa8668affe30e6204be5d")] // Star: 27
        [TestCase(@"https://github.com/clementfarabet/ipam-tutorials.git",
                @"e0cfcf4749d88f7a41fa5989ee94605942b205eb")] // Star: 31
        [TestCase(@"https://github.com/cloudwu/ldebug.git",
                @"b80bcd31944d7ea4c504dc915601d3e2080e73d9")] // Star: 35
        [TestCase(@"https://github.com/slembcke/debugger.lua.git",
                @"49baebfe73e3cc2ae5f17ee2997ad82b5ecd06d3")] // Star: 29
        [TestCase(@"https://github.com/tullamods/Dominos.git",
                @"6d5b7bf1883d62c26b64ff635244a0e435c2074d")] // Star: 27
        [TestCase(@"https://github.com/tadeuszwojcik/luvit-redis.git",
                @"a91d4584f5b1eab95923c3e48f838a4096b8499d")] // Star: 27
        [TestCase(@"https://github.com/ildyria/iFilger.git",
                @"d092e040143146a551b6821b6a9b199a4b98e9db")] // Star: 26
        [TestCase(@"https://github.com/dmccuskey/Ghost-vs-Monsters---OOP.git",
                @"c9bbaadc02941f71f518d3258a7b0d0624ac9daf")] // Star: 27
        [TestCase(@"https://github.com/sergeyzavadski/breeze.git",
                @"b17da085ca4691feb189690038b8d054b861d6e0")] // Star: 26
        [TestCase(@"https://github.com/500px/500pxPublisher.lrplugin.git",
                @"09aa4a317c56f856ffef770ef1d37d1cc3d13f96")] // Star: 28
        [TestCase(@"https://github.com/bioe007/awesome-revelation.git",
                @"2f28b196352199acd51d6967b19dcaf3d95a55e8")] // Star: 26
        [TestCase(@"https://github.com/Olivine-Labs/lusty.git",
                @"97ff69c9ccc09a339969c4b2e08d94da9581c06d")] // Star: 29
        [TestCase(@"https://github.com/rgieseke/locco.git",
                @"139fc5b8b3cd3fa6e1a4de777ec98ce59715ec18")] // Star: 27
        [TestCase(@"https://github.com/tullamods/OmniCC.git",
                @"434fb78fba9e891efdd9a43978efe00ab3232ad2")] // Star: 26
        [TestCase(@"https://github.com/TACC/Lmod.git",
                @"4f4a3eae00a8c2d26daf42bb6038be9674971faa")] // Star: 26
        [TestCase(@"https://github.com/Nayruden/ns2lua.git",
                @"9dc97d8b7aa7eee606e2fc0d55107b1cf52bc70a")] // Star: 26
        [TestCase(@"https://github.com/fperrad/lua-Spore.git",
                @"af3be83d6569c17bd9b87d170b2530564ec7b3aa")] // Star: 26
        [TestCase(@"https://github.com/silentbicycle/sidereal.git",
                @"145f788b5246e73f7cd9f82097161b63ee05b6f8")] // Star: 26
        [TestCase(@"https://github.com/ierton/awesomerc-ierton.git",
                @"7d0cbecc84266e2e11223f8fac5a25833589a21c")] // Star: 25
        [TestCase(@"https://github.com/perky/FEZ.git",
                @"39186578f86f42bc554526ebb6184f943b16a2dc")] // Star: 26
        [TestCase(@"https://github.com/desbouis/nginx-redis-proxy.git",
                @"1e9048f67c518f5093b6f516af240c39c4d1b678")] // Star: 26
        [TestCase(@"https://github.com/RobSis/treesome.git",
                @"6486454d586f86ee4eebd9edcc6df76664ff9227")] // Star: 29
        [TestCase(@"https://github.com/kindy/lj-web.git",
                @"81081dc8f29e09c977f864a035695d46a55395c1")] // Star: 29
        [TestCase(@"https://github.com/Senscape/Asylum-Teaser.git",
                @"52f4f5a0dcb868fd1ebb9b86f3e4c2dbdb4579d0")] // Star: 24
        [TestCase(@"https://github.com/Phrogz/SLAXML.git",
                @"8aa52bc271eb9a28b1f8f3c5260202ad1b6fcaf8")] // Star: 27
        [TestCase(@"https://github.com/haveatry823/QSanguoshaAI.git",
                @"97b9a4cc39f3b320c741f20f53368ef490b9e753")] // Star: 25
        [TestCase(@"https://github.com/leegao/see.lua.git",
                @"4f326f0ce435d6056787ded652e78729c60c439d")] // Star: 25
        [TestCase(@"https://github.com/affli/Tukui_DBM.git",
                @"4d637aa6ea9c48fb55d5755ae98a8750cb6a762f")] // Star: 25
        [TestCase(@"https://github.com/bartbes/lovelybigplanet.git",
                @"a8ff90107788e1b2375e0f347a89a0f47b16f2bb")] // Star: 25
        [TestCase(@"https://github.com/kengonakajima/lua-msgpack.git",
                @"91fcc8910a5f5cb83de6119357402940ce309fcc")] // Star: 25
        [TestCase(@"https://github.com/TheLinx/ltwitter.git",
                @"1859f60816a2c8d1b999db4d2fdfe0d671f047d6")] // Star: 25
        [TestCase(@"https://github.com/npryce/codea-controllers.git",
                @"38bbfb87a15627a594c625ccc6c4b90e7c63aae3")] // Star: 24
        [TestCase(@"https://github.com/johnpolacek/Match-The-Letter-Game.git",
                @"4f164f80e997755f0999b678896058aa4e767818")] // Star: 27
        [TestCase(@"https://github.com/decltype/forgottenmapeditor.git",
                @"bae6c103c688ab58c1e422179871779fbd6a8687")] // Star: 26
        [TestCase(@"https://github.com/renstrom/NeavUI.git",
                @"e16a5b8fd402fd67b3d61b66531b2adbd1e24c8c")] // Star: 24
        [TestCase(@"https://github.com/sacek/LPegLJ.git",
                @"a97c49b36abc172221fedbfc984dba108ede7f01")] // Star: 24
        [TestCase(@"https://github.com/karai17/Simple-Tiled-Implementation.git",
                @"936a563e383366c7a68bd87148b8d535ebedd2f3")] // Star: 24
        [TestCase(@"https://github.com/GrahamRanson/Ice.git",
                @"0efbc709ce9b65526ed0939921ce0933e486ccb9")] // Star: 27
        [TestCase(@"https://github.com/kikito/passion.git",
                @"1fb7233b4035cddb4e58ea18a9f590d011eb2f72")] // Star: 24
        [TestCase(@"https://github.com/khaledhosny/luaotfload.git",
                @"9291e1983240e72d93815a096963dc28a7acd770")] // Star: 24
        [TestCase(@"https://github.com/philipbl/Day-One-Lightroom-Plugin.git",
                @"f48bee6370a144fb83c23f669b731be88196c3cd")] // Star: 34
        [TestCase(@"https://github.com/TekNoLogic/GnomishVendorShrinker.git",
                @"dbf481f2cd0da671169c9673f976bf9a2d61e957")] // Star: 23
        [TestCase(@"https://github.com/kikito/middleclass-extras.git",
                @"840a6b250f7fd8d46d796a3ec99c363651c626c0")] // Star: 23
        [TestCase(@"https://github.com/johnpolacek/Video-Gallery.git",
                @"bad64b606c222165606237b204a4f5a57024cd4c")] // Star: 25
        [TestCase(@"https://github.com/geekscape/mqtt_lua.git",
                @"aba95ca2f790d0aa0ca910a8c26f2455f8d3b166")] // Star: 25
        [TestCase(@"https://github.com/TekNoLogic/Panda.git",
                @"32b4d6e53446ae3579e9d72838c81113edd3549d")] // Star: 24
        [TestCase(@"https://github.com/LazyZhu/lua-resty-ssdb.git",
                @"c7bdbcc8dc3ee23790fa9ca6ee3631e84fa0bf5d")] // Star: 27
        [TestCase(@"https://github.com/Elv13/radical.git",
                @"8da00cbd657f77fdfcd4b6a9cc81420daa2cb5e7")] // Star: 24
        [TestCase(@"https://github.com/neomantra/lds.git",
                @"d3b054dc48ab7428ea0020ea81e79688ad160fa1")] // Star: 26
        [TestCase(@"https://github.com/josemota/dotfiles.git",
                @"23abfcce78efc084854868dca9d57cb95b4feeff")] // Star: 26
        [TestCase(@"https://github.com/robmiracle/Corona-SDK-RSS-Reader.git",
                @"0ff21a80b3c9548e265d9816428aa256007ff8a5")] // Star: 26
        [TestCase(@"https://github.com/Metapyziks/finalfrontier.git",
                @"3b22cc19b155834c0e9af7c107ee58f1cd4deea8")] // Star: 23
        [TestCase(@"https://github.com/Wiladams/TINN.git",
                @"e588fff7f9e147ef4bc56e872cb385b56f712913")] // Star: 23
        [TestCase(@"https://github.com/RustOxide/Oxide.git",
                @"b69be445c99762f70ebe4c3e42e53170d09a21cf")] // Star: 23
        [TestCase(@"https://github.com/JackH79/.dotfiles.git",
                @"b957416b6a83a0d05fa943067e821ed77732c201")] // Star: 22
        [TestCase(@"https://github.com/mydevelopergames/AutoLAN.git",
                @"b5353864003cb0ba20d5b1e37284dd97114cf1df")] // Star: 24
        [TestCase(@"https://github.com/kamaitama/Tiramisu--outdated--don-t-use-.git",
                @"15a847ad05042ae4d7b1117b887902e33470f076")] // Star: 22
        [TestCase(@"https://github.com/Wiladams/LJIT2Win32.git",
                @"59e4419fc4fae4af2553e65fbbaa3d8a0125b4c4")] // Star: 22
        [TestCase(@"https://github.com/pygy/strung.lua.git",
                @"f17cdabe1973eaa5cb1ce7817822f7a8c37b8d8b")] // Star: 23
        [TestCase(@"https://github.com/haimanman/jx3.git",
                @"4fbdd1db34096d1c904ca426aa0f19c4f29595c5")] // Star: 22
        [TestCase(@"https://github.com/PrinterLUA/FORGOTTENSERVER-ORTS.git",
                @"916b8b9341dac800a7adbbe76efb1b56d1bdb78d")] // Star: 22
        [TestCase(@"https://github.com/Thalassicus/cep-bnw.git",
                @"a0f24cc82fd05ed2b1bfff411f276e8ef7ace176")] // Star: 22
        [TestCase(@"https://github.com/andycai/kodelua.git",
                @"b8556d073ef658959a1afc32fa6d2313e4285923")] // Star: 28
        [TestCase(@"https://github.com/affli/xCT.git",
                @"c20ea295aa816b53b6294eae47d6c4af2eb623d7")] // Star: 22
        [TestCase(@"https://github.com/ilua/ilua.git",
                @"c9ef6799113e71d89d629b29b266d1eba4105038")] // Star: 25
        [TestCase(@"https://github.com/kikito/beholder.lua.git",
                @"9f1a31eb51f5e3775f1c111fab37a9f72db6deae")] // Star: 24
        [TestCase(@"https://github.com/lovelyrpgcommunity/A-Whiff-of-Steam.git",
                @"e44aea49b6de9955603cb4db5cd88beea003f3f0")] // Star: 21
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "lua_repo.txt", "*.lua");
        }
    }
}