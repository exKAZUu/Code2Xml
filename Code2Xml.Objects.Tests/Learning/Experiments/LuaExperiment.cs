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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Objects.Tests.Learning.Experiments {
    [TestFixture]
    public class LuaExperiment {
        private readonly StreamWriter _writer = File.CreateText(@"C:\Users\exKAZUu\Desktop\lua.txt");

        public static CstGenerator Generator = CstGenerators.LuaUsingAntlr3;
        private string _lastProjectName;
        private const string langName = "Lua";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new LuaComplexStatementExperiment(),
                    new LuaSuperComplexBranchExperiment(),
                    new LuaExpressionStatementExperiment(),
                    new LuaArithmeticOperatorExperiment(),
                    new LuaSuperComplexBranchExperimentWithoutTrue(), 

                    //new LuaComplexBranchExperiment(),
                    //new LuaStatementExperiment(),
                    //new LuaIfExperiment(),
                    //new LuaWhileExperiment(),
                    //new LuaDoWhileExperiment(),
                    //new LuaPrintExperiment(),
                    //new LuaStatementExperiment(),
                    //new LuaLabeledStatementExperiment(),
                    //new LuaEmptyStatementExperiment(),
                };
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/kennyledet/Algorithm-Implementations.git",
                            @"ec423a1984fa923e117053c114c92ae86d32bfd4", 890),
                    Tuple.Create(
                            @"https://github.com/mason-larobina/luakit.git",
                            @"993d814c6a51bf50ec0424e65ce2dc35f4aa435f", 513),
                    Tuple.Create(
                            @"https://github.com/koreader/koreader.git",
                            @"f1a8970adb94a6a43cff4d3d16769931039e1f73", 466),
                    Tuple.Create(
                            @"https://github.com/pkulchenko/ZeroBraneStudio.git",
                            @"95452706a059c60fb34e88a0afff44ba4a9032ac", 376),
                    Tuple.Create(
                            @"https://github.com/leafo/lapis.git",
                            @"f2cdcd8179bc0d57560df5bbd95ee03f26214ef7", 374),
                    Tuple.Create(
                            @"https://github.com/rtsisyk/luafun.git",
                            @"3d44c0841dbc93b645546bb13868550089bfa076", 352),
                    Tuple.Create(
                            @"https://github.com/copycat-killer/awesome-copycats.git",
                            @"2b565ee240c883bbb4115106eef66f9f1508a864", 289),
                    Tuple.Create(
                            @"https://github.com/tylerneylon/pacpac.git",
                            @"cad99bdd64346dbc3180ee611ea502197da8b414", 273),
                    Tuple.Create(
                            @"https://github.com/exebetche/vlsub.git",
                            @"71ef0ef295cafb5477769d9ba3975c6c2ba8d609", 259),
                    Tuple.Create(
                            @"https://github.com/stevedonovan/Penlight.git",
                            @"6118a923f5ef4a21a9ae432d42707c5f4f0446a1", 248),
                    Tuple.Create(
                            @"https://github.com/zedshaw/Tir.git",
                            @"4c1bdfa5b421e8eb9d3724928055da2728130d40", 241),
                    Tuple.Create(
                            @"https://github.com/mirven/underscore.lua.git",
                            @"1bb487f5a0e523a4438a9d126a7ed44accea5a5a", 212),
                    Tuple.Create(
                            @"https://github.com/ymobe/rapanui.git",
                            @"595076d5706695a8b9b8de393b749d7d90a414a2", 201),
                    Tuple.Create(
                            @"https://github.com/keplerproject/luarocks.git",
                            @"999e27d74abd0bc53165d2ce2642fb5a7af81f40", 200),
                    Tuple.Create(
                            @"https://github.com/nrk/redis-lua.git",
                            @"4408c3d686ffd1f2689c0561a166821785cc09ec", 186),
                    Tuple.Create(
                            @"https://github.com/basecamp/intermission.git",
                            @"bb75e1ec83dea67e4db4a6a7c00bc4fcd477eae0", 150),
                    Tuple.Create(
                            @"https://github.com/minetest/minetest_game.git",
                            @"15740ffd3d1ea1af182a8607c600f3af414c2c73", 145),
                    Tuple.Create(
                            @"https://github.com/vrld/hump.git",
                            @"e10fa66e60c5984a8d92801163d23811b7ac509f", 142),
                    Tuple.Create(
                            @"https://github.com/fab13n/metalua.git",
                            @"355ff0bc201e00856ba20d82c65b14ffa6fcfe4b", 136),
                    Tuple.Create(
                            @"https://github.com/kikito/lua_missions.git",
                            @"330d7702417c4b18358ab822ba676058892ad889", 133),
                    Tuple.Create(
                            @"https://github.com/diegonehab/luasocket.git",
                            @"6d5e40c324c84d9c1453ae88e0ad5bdd0a631448", 131),
                    Tuple.Create(
                            @"https://github.com/loveshell/ngx_lua_waf.git",
                            @"2b32a34dfc67e8bbb677987319a30357d5ae6e14", 127),
                    Tuple.Create(
                            @"https://github.com/ansca/Ghosts-vs.-Monsters.git",
                            @"7c036c0d11f279c5dace9dcda4f5ad2242a8ca77", 124),
                    Tuple.Create(
                            @"https://github.com/mikar/awesome34-themes.git",
                            @"312cbc31b271afa164a81d51822de7d54b1153f3", 117),
                    Tuple.Create(
                            @"https://github.com/kernelsauce/turbo.git",
                            @"d1411bbbcbe18cb20a7d91bb95505d952993c31f", 115),
                    Tuple.Create(
                            @"https://github.com/oneoo/alilua.git",
                            @"7ce84488504cd364aa5d86acceff8fb8203b9b4f", 112),
                    Tuple.Create(
                            @"https://github.com/kikito/inspect.lua.git",
                            @"e67a7471d4dd9e22e26b3620ce8701c0e479cb82", 112),
                    Tuple.Create(
                            @"https://github.com/Kadoba/Advanced-Tiled-Loader.git",
                            @"0cc155d14406feb0335d455afd1c1fdd8b028671", 110),
                    Tuple.Create(
                            @"https://github.com/appwilldev/moochine.git",
                            @"9f643a5b51fb132c11ec1c870e4979cf03012992", 109),
                    Tuple.Create(
                            @"https://github.com/Fluorohydride/ygopro.git",
                            @"16a98132749215b8ca27f6e479976ef42c4cd0fc", 107),
                    Tuple.Create(
                            @"https://github.com/NikolaiResokav/LoveFrames.git",
                            @"4dfffef2bc8fd5053e714533b7e6e701722c7a89", 101),
                    Tuple.Create(
                            @"https://github.com/haste/oUF.git",
                            @"955f9424bf53b149fb03822bb2082f8888241c78", 99),
                    Tuple.Create(
                            @"https://github.com/Shestak/ShestakUI.git",
                            @"42527a9c4b81c3c1f762b73d4e777cd0fbd3a852", 98),
                    Tuple.Create(
                            @"https://github.com/pavouk/lgi.git",
                            @"3feb90f4c0c20312e646fb8b1106a5c44a04293e", 93),
                    Tuple.Create(
                            @"https://github.com/majek/lua-channels.git",
                            @"599b27ee7496cef488a057aad86e1ce472190a78", 93),
                    Tuple.Create(
                            @"https://github.com/makotok/Hanappe.git",
                            @"b1a759fe9606bfc49a8df458629099be87ab86f5", 92),
                    Tuple.Create(
                            @"https://github.com/virgo-agent-toolkit/rackspace-monitoring-agent.git",
                            @"5197adcd93c61db3c30b1a45a6fc6dbd1d95d66f", 90),
                    Tuple.Create(
                            @"https://github.com/lefcha/concurrentlua.git",
                            @"74405929dca29b2c61fcb9e94c6b6d8799bb148a", 90),
                    Tuple.Create(
                            @"https://github.com/pkulchenko/MobDebug.git",
                            @"c2b9988ccda7998be466da67690316b45fd3469a", 88),
                    Tuple.Create(
                            @"https://github.com/davidm/lua-inspect.git",
                            @"ca3988019a2f5f1b3f4e94b285eb6e77e5923dd3", 88),
                    Tuple.Create(
                            @"https://github.com/terceiro/awesome-freedesktop.git",
                            @"e514e742864495f23fd725f8c596f41a01d67795", 86),
                    Tuple.Create(
                            @"https://github.com/norman/telescope.git",
                            @"c80b928e306cad7195e1ce5b92ddcdcb0a2c50b2", 85),
                    Tuple.Create(
                            @"https://github.com/kikito/tween.lua.git",
                            @"b14444fe3c6bb0a530b97109f3ce2f5e32f55839", 85),
                    Tuple.Create(
                            @"https://github.com/crosslife/LoveClear.git",
                            @"dd9a81488bbf598e3e279c545a99c562f201d41b", 80),
                    Tuple.Create(
                            @"https://github.com/nrk/mercury.git",
                            @"13c85348e059dd24f2c26cf9b4e259fa2d1001c8", 77),
                    Tuple.Create(
                            @"https://github.com/richardhundt/shine.git",
                            @"a3cdf3bfc9645f90572fdd80951302edf6681ede", 76),
                    Tuple.Create(
                            @"https://github.com/jtarchie/underscore-lua.git",
                            @"a98846874399916a8689dd5bfe7cafd373128a66", 75),
                    Tuple.Create(
                            @"https://github.com/copycat-killer/lain.git",
                            @"4c3cf3c0b78624242be877a8454a3cd7c2679d45", 73),
                    Tuple.Create(
                            @"https://github.com/keplerproject/xavante.git",
                            @"58188b9da0d6ad621e5da6089684c5273936b398", 73),
                    Tuple.Create(
                            @"https://github.com/lipp/lua-websockets.git",
                            @"9ade24fc972cfc80b5d1d31e1d92ec1d28b7c4be", 72),
                    Tuple.Create(
                            @"https://github.com/vrld/HardonCollider.git",
                            @"fb8c0511cf85b86327e34f9356e1e8cf9aee8b47", 72),
                    Tuple.Create(
                            @"https://github.com/Cue/hop.git",
                            @"3e1b8e6bf535fb12f1ad3348473c64acd3647993", 72),
                    Tuple.Create(
                            @"https://github.com/harningt/luajson.git",
                            @"827425b10152f8cdc515e4ffb900338506e28910", 71),
                    Tuple.Create(
                            @"https://github.com/AdamBuchweitz/CrawlSpaceLib.git",
                            @"471868fe6cad288cac57281b5218cdd711b826eb", 71),
                    Tuple.Create(
                            @"https://github.com/tony/awesome-config.git",
                            @"2957a1bd888a6a99666f3a67c87d0333474736a9", 71),
                    Tuple.Create(
                            @"https://github.com/weshoke/Lust.git",
                            @"174ee908a3b0ee4ca71c92f314fd0efa82498035", 71),
                    Tuple.Create(
                            @"https://github.com/miko/Love2d-samples.git",
                            @"50a8b4b43d517081a83d036e4510904402dcd7d2", 71),
                    Tuple.Create(
                            @"https://github.com/Kiwi/clyde.git",
                            @"dcdba8de3a3be3685a72a1fcab24080124242a7e", 70),
                    Tuple.Create(
                            @"https://github.com/Neopallium/lua-handlers.git",
                            @"ae93f442175f4f03dd612cafa073df74a8fe626f", 70),
                    Tuple.Create(
                            @"https://github.com/Stabyourself/mari0.git",
                            @"b1412a08a1411b2f237cdd276aee27df008cb06e", 69),
                    Tuple.Create(
                            @"https://github.com/mcurry/html_cache.git",
                            @"83af9d9ee24b94b99387d8171b78e388388be756", 68),
                    Tuple.Create(
                            @"https://github.com/liseen/lua-resty-http.git",
                            @"32d951bb47ebddb82b0e3bf1a6eb0af4a6df9f1e", 68),
                    Tuple.Create(
                            @"https://github.com/cedlemo/blingbling.git",
                            @"7ac39503e2811042cf0d83a0874d230779a710ef", 66),
                    Tuple.Create(
                            @"https://github.com/keplerproject/orbit.git",
                            @"123ec06e3a9fd844f28a43258227bce19ba8ab30", 65),
                    Tuple.Create(
                            @"https://github.com/radamanthus/corona-game-template.git",
                            @"2d1dc125648b70b855fe5a318ad8a6ee30a4e1d2", 65),
                    Tuple.Create(
                            @"https://github.com/ostinelli/gin.git",
                            @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76", 64),
                    Tuple.Create(
                            @"https://github.com/ignacio/LuaOAuth.git",
                            @"3e1e6962658cbb78a5cd3e10c8f6abd35d59232a", 64),
                    Tuple.Create(
                            @"https://github.com/davidm/lua2c.git",
                            @"c5b239dd5a9fad5718ffaa16e6a30cca8053ba92", 62),
                    Tuple.Create(
                            @"https://github.com/haberman/jitdemo.git",
                            @"387503c5b8db268a6236a46e491d6f756ed17d31", 62),
                    Tuple.Create(
                            @"https://github.com/torhve/LuaWeb.git",
                            @"da1b73e7b70c938e35051a242c6fa70236e60aac", 61),
                    Tuple.Create(
                            @"https://github.com/henkboom/pax-britannica.git",
                            @"a7a3c0c21e5b27e6f4be3b0b817ebd29cd23fa7d", 60),
                    Tuple.Create(
                            @"https://github.com/roaminggamer/SSKCorona.git",
                            @"a9d6dfec85c01c2d9f8d455a10dcfefcafe35694", 60),
                    Tuple.Create(
                            @"https://github.com/vincentbernat/awesome-configuration.git",
                            @"b649c57c91ba4cb624f37d3f2a4249d9806da68c", 59),
                    Tuple.Create(
                            @"https://github.com/kikito/love-tile-tutorial.git",
                            @"92c5ce5e7e5aa9de461f948c17ed5c8d3af1d0d4", 59),
                    Tuple.Create(
                            @"https://github.com/dualface/quick-x-server.git",
                            @"2c037690610d92692744bf78fc136dec8068fddf", 59),
                    Tuple.Create(
                            @"https://github.com/geoffleyland/luatrace.git",
                            @"6150cfd6290986adab8ea948e756ee17c80d098a", 58),
                    Tuple.Create(
                            @"https://github.com/Yonaba/30log.git",
                            @"25022b30e58f1590ca3d2bc2c17107b869c38d62", 57),
                    Tuple.Create(
                            @"https://github.com/SimonLarsen/mrrescue.git",
                            @"8f226413b95544d0e0744d9c3e92c68b87659483", 57),
                    Tuple.Create(
                            @"https://github.com/Nuku/Flexible-Survival.git",
                            @"4b75f275ece08e07d1325efc3205578edc0a021b", 56),
                    Tuple.Create(
                            @"https://github.com/meric/l2l.git",
                            @"e9394879e9bde63b1b21e39928ac19f304fc1b39", 56),
                    Tuple.Create(
                            @"https://github.com/pkulchenko/serpent.git",
                            @"026f4e1a5c34f0670948a13d2182729448a260f2", 56),
                    Tuple.Create(
                            @"https://github.com/AlexChittock/SimpleShortener.git",
                            @"76462aeea14adcc0aef49c2cfa8a49951b5d460e", 55),
                    Tuple.Create(
                            @"https://github.com/willsteel/lcpp.git",
                            @"7fdda9a5e3eacccee7571130602dc1381c01bcd9", 55),
                    Tuple.Create(
                            @"https://github.com/dmccuskey/DMC-Corona-Library.git",
                            @"8c85803e39a673cc84b6aa089b51be56f05dd062", 55),
                    Tuple.Create(
                            @"https://github.com/Neopallium/lua-pb.git",
                            @"862fe3121e71f695d9a44ee1d1038069292b69f3", 54),
                    Tuple.Create(
                            @"https://github.com/darklajid/ansible-communication.git",
                            @"003bc68dcbb9606a8099132a399cf21bf342e81c", 53),
                    Tuple.Create(
                            @"https://github.com/ansca/Corona-Comics-SDK-2.0.git",
                            @"ac2abb7ef77753bb01e76ce008d88cece46661b4", 53),
                    Tuple.Create(
                            @"https://github.com/xolox/vim-lua-inspect.git",
                            @"d7fb876f0291cbd13c4c38177ada015fafc58770", 53),
                    Tuple.Create(
                            @"https://github.com/annulen/premake.git",
                            @"c559fa4913bd86be6e415c3b193db90ae4607f5b", 52),
                    Tuple.Create(
                            @"https://github.com/ignacio/StackTracePlus.git",
                            @"3c0d8a09670a40267104348feac19de73191d398", 51),
                    Tuple.Create(
                            @"https://github.com/leafo/magick.git",
                            @"6ba5063b2fe3cf043b4247e9508a6c74b211e704", 51),
                    Tuple.Create(
                            @"https://github.com/mirven/luaspec.git",
                            @"c0c774b54dcc214250cc8eb8aea0dcea60dc6f7c", 49),
                    Tuple.Create(
                            @"https://github.com/shawndumas/adventure.lua.git",
                            @"e98626163129f7c3c4fa6f23abaad1d16b524b16", 48),
                    Tuple.Create(
                            @"https://github.com/Olivine-Labs/lustache.git",
                            @"3358eda141041f8998b938c242b1eda7817898e9", 48),
                    Tuple.Create(
                            @"https://github.com/bioe007/awesome-configs.git",
                            @"cb91a271d55a40cae6b25b0a34ded6947211353f", 47),
                    Tuple.Create(
                            @"https://github.com/xopxe/Lumen.git",
                            @"264d9d042ee9848bccfd064d69259c1d6bde0a2e", 47),
                    Tuple.Create(
                            @"https://github.com/Neopallium/lualogging.git",
                            @"c85130120406b9641e96ab05f782dde819fbd102", 47),
                    Tuple.Create(
                            @"https://github.com/Bertram25/ValyriaTear.git",
                            @"a0e86da761fbc84ace9a778faf64e0f3687dbb3e", 46),
                    Tuple.Create(
                            @"https://github.com/keplerproject/wsapi.git",
                            @"eed8338401196cc155e59280adbe58d78933ead0", 46),
                    Tuple.Create(
                            @"https://github.com/GymbylCoding/Dusk-Engine.git",
                            @"f0fcdfc2cd628966bbf208bcb6bf3c3374dd1e42", 46),
                };
                foreach (var exp in exps) {
                    foreach (
                            var learningSet in
                                    learningSets.Skip(JavaExperiment.SkipCount)
                                            .Take(JavaExperiment.TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        Git.CloneAndCheckout(path, url, learningSet.Item2);
                        yield return new TestCaseData(exp, path, learningSet.Item3);
                    }
                }
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, int startCount) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), };
            var allPaths = Directory.GetFiles(projectPath, "*.lua", SearchOption.AllDirectories)
                    .ToList();
            var projectName = Path.GetDirectoryName(projectPath);
            if (_lastProjectName != projectName) {
                _writer.WriteLine();
                _writer.Write(projectName + ",");
                _lastProjectName = projectName;
            }
            _writer.Flush();
            exp.Learn(allPaths, seedPaths, _writer, projectPath);
            //if (exp.WrongFeatureCount > 0) {
            //	Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
            //	foreach (var we in exp.WronglyAcceptedElements) {
            //		var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
            //		Console.WriteLine(we.Text());
            //		Console.WriteLine(e.Text());
            //		Console.WriteLine("---------------------------------------------");
            //	}
            //	Console.WriteLine("---- WronglyRejectedElements ----");
            //	foreach (var we in exp.WronglyRejectedElements) {
            //		var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
            //		Console.WriteLine(we.Text());
            //		Console.WriteLine(e.Text());
            //		Console.WriteLine("---------------------------------------------");
            //	}
            //}
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
        }
    }

    public class LuaComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaComplexBranchExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return true;
            }
            return false;
        }
    }

    public class LuaSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaSuperComplexBranchExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return true;
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return true;
            }
            var pppp = e.SafeParent().SafeParent().SafeParent().SafeParent();
            if (pppp.SafeName() == "functioncall" && pppp.FirstChild.TokenText == "print") {
                return true;
            }
            return false;
        }
    }

    public class LuaSuperComplexBranchExperimentWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaSuperComplexBranchExperimentWithoutTrue() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return e.TokenText != "true";
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return e.TokenText != "true";
            }
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return e.TokenText != "true";
            }
            var pppp = e.SafeParent().SafeParent().SafeParent().SafeParent();
            if (pppp.SafeName() == "functioncall" && pppp.FirstChild.TokenText == "print") {
                return e.TokenText != "true";
            }
            return false;
        }
    }

    public class LuaIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaIfExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
                return true;
            }
            return false;
        }
    }

    public class LuaWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaWhileExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
                return true;
            }
            return false;
        }
    }

    public class LuaDoWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaDoWhileExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var siblings = e.Siblings().ToList();
            var parent = e.Parent;
            if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
                return true;
            }
            return false;
        }
    }

    public class LuaPrintExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaPrintExperiment() : base("exp") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pppp = e.SafeParent().SafeParent().SafeParent().SafeParent();
            if (pppp.SafeName() == "functioncall" && pppp.FirstChild.TokenText == "print") {
                return true;
            }
            return false;
        }
    }

    public class LuaComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaComplexStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "label") {
                return false;
            }
            if (e.FirstChild.TokenText == ";") {
                return false;
            }
            return true;
        }
    }

    public class LuaStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return true;
        }
    }

    public class LuaLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaLabeledStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "label") {
                return true;
            }
            return false;
        }
    }

    public class LuaEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaEmptyStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.TokenText == ";") {
                return true;
            }
            return false;
        }
    }

    public class LuaExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public LuaExpressionStatementExperiment() : base("stat") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.FirstChild.Name == "varlist";
        }
    }

    public class LuaArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public LuaArithmeticOperatorExperiment() : base("TOKENS") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "binop") {
                e = e.FirstChild;
            }
            return e.Parent.Name == "binop"
                   && (e.TokenText == "+" || e.TokenText == "-" || e.TokenText == "*"
                       || e.TokenText == "/");
        }
    }
}