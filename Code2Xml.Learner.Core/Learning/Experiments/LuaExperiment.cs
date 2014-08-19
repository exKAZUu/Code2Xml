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
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Learner.Core.Learning.Experiments {
    [TestFixture]
    public class LuaExperiment {
        private readonly StreamWriter _writer = File.CreateText(
                @"C:\Users\exKAZUu\Dropbox\Data\lua" + JavaExperiment.SkipCount + "_"
                + JavaExperiment.TakeCount + ".csv");

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
                            @"ec423a1984fa923e117053c114c92ae86d32bfd4",
                            "56ed090beaecb00a38317ee0d318b4a833f5e24c"),
                    Tuple.Create(
                            @"https://github.com/nrk/redis-lua.git",
                            @"4408c3d686ffd1f2689c0561a166821785cc09ec",
                            "26dab1fd3387440519dd7a66a959c530e6a22a81"),
                    Tuple.Create(
                            @"https://github.com/gamesys/moonshine.git",
                            @"ca6d7a57bfb676caf409e7398a448f90eb139b47",
                            "9dd8584c233f6527e3b0899cf89434ff598592be"),
                    Tuple.Create(
                            @"https://github.com/tekkub/wow-ui-source.git",
                            @"e9e777a6d1baca29d6253260a69463767d8d9b00",
                            "ef5e66f9bdb6d893576008993fad098fa6455743"),
                    Tuple.Create(
                            @"https://github.com/minetest/minetest_game.git",
                            @"15740ffd3d1ea1af182a8607c600f3af414c2c73",
                            "894f98d878b198256881e348e294365e8a677cbf"),
                    Tuple.Create(
                            @"https://github.com/kikito/lua_missions.git",
                            @"330d7702417c4b18358ab822ba676058892ad889",
                            "e2363031da6948391e1d5fd55fb505df60c3d536"),
                    Tuple.Create(
                            @"https://github.com/kernelsauce/turbo.git",
                            @"d1411bbbcbe18cb20a7d91bb95505d952993c31f",
                            "bedd3c1b200056d5bc43c2c2a18b69c25e404c56"),
                    Tuple.Create(
                            @"https://github.com/appwilldev/moochine.git",
                            @"9f643a5b51fb132c11ec1c870e4979cf03012992",
                            "386ab4095e02b222efc874cca97c7ebbabcfc515"),
                    Tuple.Create(
                            @"https://github.com/Fluorohydride/ygopro.git",
                            @"16a98132749215b8ca27f6e479976ef42c4cd0fc",
                            "689440546bed214a2071a563cceedb7fcf9b3d5f"),
                    Tuple.Create(
                            @"https://github.com/Shestak/ShestakUI.git",
                            @"42527a9c4b81c3c1f762b73d4e777cd0fbd3a852",
                            "4ae15e9a7d695790b7cafd0637e278cf14f97462"),
                    Tuple.Create(
                            @"https://github.com/pavouk/lgi.git",
                            @"3feb90f4c0c20312e646fb8b1106a5c44a04293e",
                            "91068f66558a50ee2f8fe5eb425c60f369a1127b"),
                    Tuple.Create(
                            @"https://github.com/virgo-agent-toolkit/rackspace-monitoring-agent.git",
                            @"5197adcd93c61db3c30b1a45a6fc6dbd1d95d66f",
                            "2ecf5c528edc4e44df57578b47c33ca74686782e"),
                    Tuple.Create(
                            @"https://github.com/pkulchenko/MobDebug.git",
                            @"c2b9988ccda7998be466da67690316b45fd3469a",
                            "df119c83610b382da1deb4923a0993c524daf937"),
                    Tuple.Create(
                            @"https://github.com/davidm/lua-inspect.git",
                            @"ca3988019a2f5f1b3f4e94b285eb6e77e5923dd3",
                            "b214441af0172d0ebe075119aba16e65c4290ea7"),
                    Tuple.Create(
                            @"https://github.com/lipp/lua-websockets.git",
                            @"9ade24fc972cfc80b5d1d31e1d92ec1d28b7c4be",
                            "7c1f97f2f414f1f0208244bb6de94dc2abdd09ec"),
                    Tuple.Create(
                            @"https://github.com/harningt/luajson.git",
                            @"827425b10152f8cdc515e4ffb900338506e28910",
                            "32ca4123e4d2e73e7862a8e09b88fc86d7102f57"),
                    Tuple.Create(
                            @"https://github.com/AdamBuchweitz/CrawlSpaceLib.git",
                            @"471868fe6cad288cac57281b5218cdd711b826eb",
                            "14985eda97b6a40bdb6c678bb60ac103e95f924f"),
                    Tuple.Create(
                            @"https://github.com/miko/Love2d-samples.git",
                            @"50a8b4b43d517081a83d036e4510904402dcd7d2",
                            "2ac588ef7aa4655576d2370c13ac6b7eb285e404"),
                    Tuple.Create(
                            @"https://github.com/Neopallium/lua-handlers.git",
                            @"ae93f442175f4f03dd612cafa073df74a8fe626f",
                            "c22f7425b1c20fe7c5049d4249495fe1ed043bbe"),
                    Tuple.Create(
                            @"https://github.com/cedlemo/blingbling.git",
                            @"7ac39503e2811042cf0d83a0874d230779a710ef",
                            "d0ff3be7f1242e596355ea46c0e88e421c2a8ce7"),
                    Tuple.Create(
                            @"https://github.com/radamanthus/corona-game-template.git",
                            @"2d1dc125648b70b855fe5a318ad8a6ee30a4e1d2",
                            "76a71e8c9242cb49c08f5d2d1228ea3499981372"),
                    Tuple.Create(
                            @"https://github.com/ostinelli/gin.git",
                            @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76",
                            "d0d16d865e3dbd7dc2b3f888f56bbe45ef693bae"),
                    Tuple.Create(
                            @"https://github.com/ymobe/rapanui.git",
                            @"595076d5706695a8b9b8de393b749d7d90a414a2",
                            "642d6cfb7c7f27660d7e35b744bae954e65a2a80"),
                    Tuple.Create(
                            @"https://github.com/bjc/prosody.git",
                            @"701fa72ca55909888b3fd428724128c654d8b543",
                            "4693fe1ab54233629f2c4b33636f54f8610a1421"),
                    Tuple.Create(
                            @"https://github.com/Yonaba/Jumper.git",
                            @"2479afadf3d50e30ea9f9ab104e6229176d57339",
                            "1da043fba66070aac09c36ce4cc2fe175cb4f980"),
                    Tuple.Create(
                            @"ad7687e3a9e0c6",
                            @"134585", "7192"),
                    Tuple.Create(
                            @"https://github.com/iamgreaser/iceball.git",
                            @"4ae5d09ce4fd2269f4e097b63bd0fd9b83f2198f",
                            "6239c60b779e021a0583c064861480e80c31cb7d"),
                    Tuple.Create(
                            @"https://github.com/xopxe/Lumen.git",
                            @"264d9d042ee9848bccfd064d69259c1d6bde0a2e",
                            "f79fa364d82499f7e0979545565af4b9cc4bc73c"),
                    Tuple.Create(
                            @"https://github.com/Bertram25/ValyriaTear.git",
                            @"a0e86da761fbc84ace9a778faf64e0f3687dbb3e",
                            "6e2019d9959f2e446b7971d80925262f1ee1397f"),
                    Tuple.Create(
                            @"https://github.com/Yonaba/Moses.git",
                            @"57c7b5d1d1f074cafbd570088ad8681b03c65601",
                            "4323caefe61737f195b96acbd51e701639eff8f2"),
                    Tuple.Create(
                            @"https://github.com/metadeus/luv.git",
                            @"655c0efc14572d18744aff336210b30574dd7eaf",
                            "21653326254a84a552089eba3c7e620be2b9367a"),
                    Tuple.Create(
                            @"https://github.com/lubyk/dub.git",
                            @"b0c7087e878937399f329468bff41de9484f8b0c",
                            "6247877f0a67a0ebcafe5ec1b918412cbb712cfc"),
                    Tuple.Create(
                            @"https://github.com/pygy/LuLPeg.git",
                            @"c457b27e0d7fc935b133921bf3aee92efffe40c8",
                            "c015f2d1fe4027f0b867322349167066c89fb403"),
                    Tuple.Create(
                            @"https://github.com/lua-nucleo/lua-nucleo.git",
                            @"570e115dab1260ad433bd778eebb5d91fd122d5a",
                            "01a43cb2fa05bae2c752fcde0d5540ca9235c17a"),
                    Tuple.Create(
                            @"https://github.com/annulen/premake.git",
                            @"c559fa4913bd86be6e415c3b193db90ae4607f5b",
                            "d947c1fed5d9aa04dc586cb1ff6906db9c2540ab"),
                    Tuple.Create(
                            @"https://github.com/Neopallium/LuaNativeObjects.git",
                            @"a5c444769b7dfad1436a1bc4fe21dce75629db25",
                            "b08030b08a3d0bac41fd5debd323c66079ebdb3c"),
                    Tuple.Create(
                            @"https://github.com/SiENcE/lovecodify.git",
                            @"9b84ce1a5f3474707e6021355afd6c2554f18251",
                            "ef8e374d88c47ac8ffd53e37533e65371f61df71"),
                    Tuple.Create(
                            @"https://github.com/jp-ganis/JPS.git",
                            @"c65f107fa59a5f572e0ffd70be7990a873d87487",
                            "82c21a32fc71e347e63c104eb0a87ee05566a468"),
                    Tuple.Create(
                            @"https://github.com/stravant/LuaMinify.git",
                            @"c284a942089b0154af7498b110e02d1bba8aee16",
                            "fb1aa5b26e401f7eb74343c0e662ef4ff409dda2"),
                    Tuple.Create(
                            @"https://github.com/UPenn-RoboCup/UPennalizers.git",
                            @"abd9b34294a6485965be274333b72f1272f8f3c8",
                            "f56d1740ba1e781c65b5903c7c38c164caf6795b"),
                    Tuple.Create(
                            @"https://github.com/SimonLarsen/mrrescue.git",
                            @"8f226413b95544d0e0744d9c3e92c68b87659483",
                            "0c2eeda9cd99481d1ac8989be33e781ae4ece10a"),
                    Tuple.Create(
                            @"https://github.com/meric/l2l.git",
                            @"e9394879e9bde63b1b21e39928ac19f304fc1b39",
                            "983ab97a012106f7c7ff1079a1a34145888a10d4"),
                    Tuple.Create(
                            @"https://github.com/dmccuskey/DMC-Corona-Library.git",
                            @"8c85803e39a673cc84b6aa089b51be56f05dd062",
                            "47a84264425cba43def72e663408a62573065879"),
                    Tuple.Create(
                            @"https://github.com/Neopallium/lua-pb.git",
                            @"862fe3121e71f695d9a44ee1d1038069292b69f3",
                            "60a4033a7eb268f2b18d83bf1f17a9ba184cb9d8"),
                    Tuple.Create(
                            @"https://github.com/SnakeSVx/spacebuild.git",
                            @"68186b8bc7cabbb5275afd734fae9613fbd8761d",
                            "a1102e3a9cc105a992cca8303a1c861d1fff19a7"),
                    Tuple.Create(
                            @"https://github.com/Wiladams/LAPHLibs.git",
                            @"aed3531fb6face76c5634bde995e9cf503d6136b",
                            "689537d3f96c78e3525285015b3d37fcc9225b50"),
                    Tuple.Create(
                            @"https://github.com/tales/sourceoftales.git",
                            @"f259c99ebb42a4956f6e4c5464051651a3226d5a",
                            "fe1396ce2c8e3d8aa3a76f466a03b2243ac4ab74"),
                    Tuple.Create(
                            @"https://github.com/paulofmandown/rotLove.git",
                            @"bb089f3294ba9cd1f7cc031dffc0b695fa2ed4bf",
                            "2717740d7a41712a0369bc3804c347ec2e5f6fca"),
                    Tuple.Create(
                            @"https://github.com/Eonblast/fleece-lite.git",
                            @"06103ea87601c74801ca5780bc9014011243bbec",
                            "501ee823d9896c674c484ec65fa06a8bbca70a1f"),
                    Tuple.Create(
                            @"https://github.com/ildyria/iFilger.git",
                            @"d092e040143146a551b6821b6a9b199a4b98e9db",
                            "172180c51187092483fc50ddfd9a082b04cba16a"),
                };
                foreach (var exp in exps) {
                    foreach (
                            var learningSet in
                                    learningSets.Skip(JavaExperiment.SkipCount)
                                            .Take(JavaExperiment.TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", url + "Clone\r\n");
                        Git.Clone(path, url);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", "Done\r\n");
                        yield return
                                new TestCaseData(exp, path, learningSet.Item2, learningSet.Item3);
                    }
                }
            }
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, string sha1, string sha2) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), };
            if (_lastProjectName != exp.GetType().Name) {
                _writer.WriteLine();
                _writer.Write(Path.GetFileName(projectPath) + ",");
                _lastProjectName = exp.GetType().Name;
            }
            exp.Learn(seedPaths, _writer, projectPath, "*.lua");
            _writer.Flush();
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