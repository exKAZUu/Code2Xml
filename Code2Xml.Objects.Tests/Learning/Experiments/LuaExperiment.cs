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

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new LuaComplexStatementExperiment(),
                    new LuaSuperComplexBranchExperiment(),
                    new LuaComplexBranchExperiment(),
                    new LuaStatementExperiment(),
                    new LuaIfExperiment(),
                    new LuaWhileExperiment(),
                    new LuaDoWhileExperiment(),
                    new LuaPrintExperiment(),
                    new LuaStatementExperiment(),
                    new LuaLabeledStatementExperiment(),
                    new LuaEmptyStatementExperiment(),
                };
                const string langName = "Lua";
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/stevedonovan/Penlight.git",
                            @"e9992789af07861974cad2bad5ba7c067d089e26",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/zedshaw/Tir.git",
                            @"4c1bdfa5b421e8eb9d3724928055da2728130d40",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/ostinelli/gin.git",
                            @"8361d2f5f16e64c65ba33d1dbbc74b97d5256f76",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/koreader/koreader.git",
                            @"ca85deb1fa6779bc001b914d7bd371864106ea3a",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/leafo/lapis.git",
                            @"0fe074b55e834267d82122f5c49d8b5a89c55f3d",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/exKAZUu/lsyncd.git",
                            @"178f31590732da0eb39cd58b20cc53c3d954ebec",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/rtsisyk/luafun.git",
                            @"396dfc14171cfccda349ce2b445707b889ab422d",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/mason-larobina/luakit.git",
                            @"993d814c6a51bf50ec0424e65ce2dc35f4aa435f",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/kikito/middleclass.git",
                            @"124c6d687eaf46fa7f869056959975f018ae45bd",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/tylerneylon/pacpac.git",
                            @"cad99bdd64346dbc3180ee611ea502197da8b414",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                    Tuple.Create(
                            @"https://github.com/exebetche/vlsub.git",
                            @"e2280c4a75c3c3aba2986465d9c9559927ed4479",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
                };
                foreach (var exp in exps) {
                    foreach (var learningSet in learningSets) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        Git.CloneAndCheckout(path, url, learningSet.Item2);
                        yield return new TestCaseData(exp, path, learningSet.Item3);
                    }
                }
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(
                LearningExperiment exp, string projectPath, IList<string> seedPaths) {
            var allPaths = Directory.GetFiles(projectPath, "*.lua", SearchOption.AllDirectories)
                    .ToList();
            exp.AutomaticallyLearnUntilBeStable(allPaths, seedPaths, _writer, projectPath);
            //if (exp.WrongCount > 0) {
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
            Assert.That(exp.WrongCount, Is.EqualTo(0));
        }
    }

    public class LuaComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        protected override bool IsInner {
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

        protected override bool IsInner {
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

    public class LuaIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return LuaExperiment.Generator; }
        }

        protected override bool IsInner {
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

        protected override bool IsInner {
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

        protected override bool IsInner {
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

        protected override bool IsInner {
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

        protected override bool IsInner {
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

        protected override bool IsInner {
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

        protected override bool IsInner {
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

        protected override bool IsInner {
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
}