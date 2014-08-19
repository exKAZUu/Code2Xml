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
    public class JavaExperiment {
        private readonly StreamWriter _writer = File.CreateText(
                @"C:\Users\exKAZUu\Dropbox\Data\java" + SkipCount + "_" + TakeCount + ".csv");

        public static CstGenerator Generator = CstGenerators.JavaUsingAntlr3;
        private string _lastProjectName;
        private const string LangName = "Java";
        public const int SkipCount = 0;
        public const int TakeCount = 50;

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new JavaComplexStatementExperiment(),
                    new JavaSuperComplexBranchExperiment(),
                    new JavaExpressionStatementExperiment(),
                    new JavaArithmeticOperatorExperiment(),
                    new JavaSwitchCaseExperiment(),
                    new JavaSuperComplexBranchExperimentWithSwitch(),
                    new JavaSuperComplexBranchExperimentWithSwitchWithoutTrue(),

                    //new JavaComplexBranchExperiment(),
                    //new JavaIfExperiment(),
                    //new JavaWhileExperiment(),
                    //new JavaDoWhileExperiment(),
                    //new JavaForExperiment(),
                    //new JavaPreconditionsExperiment(),
                    //new JavaStatementExperiment(),
                    //new JavaBlockExperiment(),
                    //new JavaLabeledStatementExperiment(),
                    //new JavaEmptyStatementExperiment(),
                };
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/nostra13/Android-Universal-Image-Loader.git",
                            @"29811229c3ba3da390b29353875be2c92f88a789",
                            "e7d94e30299c9c606c3612bee1bf478bea09bc47"),
                    Tuple.Create(
                            @"https://github.com/github/android.git",
                            @"9d490829b944d3a2c77dbd0010ec7a0bfe2efaee",
                            "f60a269d2eecad6cb705da0d6d94c6efe37cf73c"),
                    Tuple.Create(
                            @"https://github.com/JakeWharton/Android-ViewPagerIndicator.git",
                            @"8cd549f23f3d20ff920e19a2345c54983f65e26b",
                            "7a0798644424edd4845fefa862c0ef7bb3980015"),
                    Tuple.Create(
                            @"https://github.com/loopj/android-async-http.git",
                            @"6077c6aa7bf06b2b8c13fbb4355e094dea436b7c",
                            "cb99009b08b1488d0293a96d258d2eea5abfbe98"),
                    Tuple.Create(
                            @"https://github.com/junit-team/junit.git",
                            @"e65558c174a8f5c4c7758f0d9dd1ffe027b023d8",
                            "f49fb25b6fbffcc7a68b28824ed3856ffa9d6fdd"),
                    Tuple.Create(
                            @"https://github.com/square/picasso.git",
                            @"e0c3d44f53919742a0a608277be26b47742bb2a2",
                            "5c7e2c6942a7c80d4bc1ab9cd1af8aa6e6f9a0bd"),
                    Tuple.Create(
                            @"https://github.com/chrisbanes/ActionBar-PullToRefresh.git",
                            @"65d4183994eaf8c450e81afadb389fca61499063",
                            "bed1e752e43452aa92e2cf1b481b57c7a10e2198"),
                    Tuple.Create(
                            @"https://github.com/cyrilmottier/GreenDroid.git",
                            @"abd9769f677bb4a753f0bf1119f961187bdf7020",
                            "62609b89a3405f7dc8b2f09cc6b3dda21db625cf"),
                    Tuple.Create(
                            @"https://github.com/dropwizard/metrics.git",
                            @"e61395657d9f471a88dc0d9f3c7f78f0e773fe28",
                            "93d611f3a7b6bdd2bd26b8cc95514e690c1ca401"),
                    Tuple.Create(
                            @"https://github.com/nicolasgramlich/AndEngine.git",
                            @"720897f99d2c56ba357e8fe361454bd8d88c37ed",
                            "ad61b68192a7a0b37a4346eddc2dd57c4d11a98b"),
                    Tuple.Create(
                            @"https://github.com/Prototik/HoloEverywhere.git",
                            @"3b6021aa4af717cd31b1b6c877f6c30b674af6d9",
                            "9e7e429cbcd4823b08150c3179177d2b0293d0b1"),
                    Tuple.Create(
                            @"https://github.com/Bukkit/CraftBukkit.git",
                            @"1ab090e71ea261fe38cef980bc2ebe696a494ea3",
                            "b8d2671dd7362e4b738d40070ea4db99d0dbbb32"),
                    Tuple.Create(
                            @"https://github.com/fernandezpablo85/scribe-java.git",
                            @"135ad50a4e4e27e97f09e42ae50d6011c7af7a4b",
                            "bfcf0655dab0b436d6be580e3e81c784d0984938"),
                    Tuple.Create(
                            @"https://github.com/LMAX-Exchange/disruptor.git",
                            @"1072645ad75f8b07b9145197fd4137fcfa79011a",
                            "ba9684886b9963b35567f058b96fdcd85d42ff2c"),
                    Tuple.Create(
                            @"https://github.com/dropwizard/dropwizard.git",
                            @"4758ac698ff9993879798db338b3314c6a1c6a27",
                            "12ca959c5e75685426b2e71bf51da383d0c67cff"),
                    Tuple.Create(
                            @"https://github.com/square/retrofit.git",
                            @"1f7cc4942f71d6c6cf4770fcd93670bc93a8c710",
                            "4d802a40b5e588cffe353a10cf88ad83353b5418"),
                    Tuple.Create(
                            @"https://github.com/SimonVT/android-menudrawer.git",
                            @"1260f2f6d50d3b572ebfa98e93a0b4f8258371de",
                            "3b467e0f698963988ae8f532f630da6db205db5f"),
                    Tuple.Create(
                            @"https://github.com/square/dagger.git",
                            @"21a9e0d875da31306b0f41273348f4f75741fef7",
                            "87ccc75bd6cb209ae8ce3832c9fc06e5b80a85c2"),
                    Tuple.Create(
                            @"https://github.com/Atmosphere/atmosphere.git",
                            @"dd2397e03088f2bced1f8e47f8f81e935664a923",
                            "ae3d4f811fd5c5cf8e88857b572fd4778654421c"),
                    Tuple.Create(
                            @"https://github.com/thinkaurelius/titan.git",
                            @"c26cd982b1dc5ba792ee7a63af59887bd8b08223",
                            "c8f7d2d5b27ae8a77304868480b41e43685af9eb"),
                    Tuple.Create(
                            @"https://github.com/Comcast/FreeFlow.git",
                            @"47bfb57e8037eecae320266cb00dd23e673362e5",
                            "057f895f2d2fd45ec52b7cb338f2739fc229da29"),
                    Tuple.Create(
                            @"https://github.com/greenrobot/greenDAO.git",
                            @"d13a1f1d0e8d244e8033a944599adda7bb157bef",
                            "c978dc004d153d2987ad1889693db1006fc2c07c"),
                    Tuple.Create(
                            @"https://github.com/commonsguy/cw-advandroid.git",
                            @"ab8e52a00413592b99a7bb9f93050bee760f289f",
                            "c4705e6f4baa0ae6b9d0bda322a6fb140defbdfc"),
                    Tuple.Create(
                            @"https://github.com/koush/AndroidAsync.git",
                            @"09c60732944a20eac52301026e9c24344ccb3062",
                            "813b0bc740021866c8e40dbc1249a862efb68252"),
                    Tuple.Create(
                            @"https://github.com/square/android-times-square.git",
                            @"2bb367039b3cb93e6764e55835dc023df9f4fd77",
                            "1b18bb6a5882b1398a1b669ce5d51abb63c50362"),
                    Tuple.Create(
                            @"https://github.com/pardom/ActiveAndroid.git",
                            @"bd98740d466249fc085311b1c166570cfc08f532",
                            "c0fb1c44c8d9420428a13ce10b436635e276b59f"),
                    Tuple.Create(
                            @"https://github.com/kevinsawicki/http-request.git",
                            @"c11e2a8b335d43adb9e273412ec7a39c7e404e72",
                            "4a25dddd28f077ab7e7cf16cef41269530e95eee"),
                    Tuple.Create(
                            @"https://github.com/qii/weiciyuan.git",
                            @"14fdfe9f6f7f3d927a66d802b709f53ba0ff629e",
                            "056dd1d1e3fb99c4dae9e864eced5a1ef5cffc6e"),
                    Tuple.Create(
                            @"https://github.com/twitter/ambrose.git",
                            @"9ff6dc68e6eb7e95645878082774f44acca5814f",
                            "09d804e4a0512907f27fe368dcc8078b4540b727"),
                    Tuple.Create(
                            @"https://github.com/perwendel/spark.git",
                            @"f1f06769abacc6732e511774d4db2306cbe5db54",
                            "25feca79b3bec6aa82f79de660db74698a2414d6"),
                    Tuple.Create(
                            @"https://github.com/addthis/stream-lib.git",
                            @"56c48e001341f874c37e0113c09554436e93ea10",
                            "6bff10d9c6ce0420388ba3379af0c6380d441c5b"),
                    Tuple.Create(
                            @"https://github.com/http-kit/http-kit.git",
                            @"7184fa8cf2526a24446e7e6602bc16d9d1c0948a",
                            "d8e1b2d28b6cab0583c8b61d0cf645cd0cb9666c"),
                    Tuple.Create(
                            @"https://github.com/quartzjer/TeleHash.git",
                            @"133f4212666911d066f59255e2e7fbd69bea8265",
                            "c92e5e97af2be5299719bd59ca0e9fc75d5608f0"),
                    Tuple.Create(
                            @"https://github.com/cucumber/cucumber-jvm.git",
                            @"08e6b87a0a21010bf35d643157b7032a40832efd",
                            "7c4d730c77a85d20ca53be67f80f85941f498528"),
                    Tuple.Create(
                            @"https://github.com/jankotek/MapDB.git",
                            @"c890d8b4edc5fb9d064bb04aa132aea8608f87dd",
                            "14b45eba0465a21f9c4a93145055b51ea3478cfc"),
                    Tuple.Create(
                            @"https://github.com/peter-lawrey/Java-Chronicle.git",
                            @"6716f0cff0750d125a07eb769bba0698a617b7fb",
                            "9fab9764cf84075af51e58ba31cf2972b2b1344e"),
                    Tuple.Create(
                            @"https://github.com/TooTallNate/Java-WebSocket.git",
                            @"7c3b223536dc8bd4e8794ac265ad06679583e30f",
                            "53395cc5fd2719bad277d0c6a67f04d3687b51f1"),
                    Tuple.Create(
                            @"https://github.com/derekbrameyer/android-betterpickers.git",
                            @"0a72367b478970b1731822e78790a158a4f7ebb4",
                            "6d42db9d5898c5b1cb44e2e5e516a65cbe974f24"),
                    Tuple.Create(
                            @"https://github.com/typesafehub/config.git",
                            @"36c1392028c82db2c146ade29a2f6940bc6f5407",
                            "f1bedacdfcd8a06c61e829d31e45119d07e7b299"),
                    Tuple.Create(
                            @"https://github.com/OpenTSDB/opentsdb.git",
                            @"a2bd5737d9d11a8fd3fa6e9c36a31dd8cb5c4af4",
                            "c95cb72b82f6dcdbdd33293e3058a470bd556671"),
                    Tuple.Create(
                            @"https://github.com/kevinweil/elephant-bird.git",
                            @"ccddfc68e634fea2d05a1804057a1c4826817471",
                            "7dc6a24575570d514ad0b3456a0e87fb502647be"),
                    Tuple.Create(
                            @"https://github.com/nathanmarz/storm-starter.git",
                            @"917a4c5c171009af3b130d09339355f6310a2042",
                            "4e2dd49ee0c7bdfc78863d648e51d7c99b68f48c"),
                    Tuple.Create(
                            @"https://github.com/mongodb/mongo-hadoop.git",
                            @"29788439cbc8cc9a45910ceba316a70049a8b4e8",
                            "f1289137e6a1517d84dd9dd43daaadfae6b650a3"),
                    Tuple.Create(
                            @"https://github.com/harism/android_page_curl.git",
                            @"7a2c8f152bb4f1b0de3b1aa72b3cb79e1fe8e3bd",
                            "4b3a954c9cbc291a9ec296deb1c160aec8ca06bd"),
                    Tuple.Create(
                            @"https://github.com/RobotiumTech/robotium.git",
                            @"ee7d989c95f2cf380935f7a117d7f9345820cbf7",
                            "4a4078d2edae808094ddac4b128c3dd5b5801f08"),
                    Tuple.Create(
                            @"https://github.com/hector-client/hector.git",
                            @"0c760d9347ebf9bdaeec5fe195f175f674590909",
                            "0bd040edef174eedb74700f5df308d176853ca33"),
                    Tuple.Create(
                            @"https://github.com/eishay/jvm-serializers.git",
                            @"3ec217ec19aff74654b40a47c010d57a44996efb",
                            "2e6dbd948635724ae3c4819853d95de3e509868b"),
                    Tuple.Create(
                            @"https://github.com/jberkel/sms-backup-plus.git",
                            @"3565f645126d3f9e8c0371ec57c8aac4bbf5cde1",
                            "7f651fbbb00d001fe40a34a4a858d01ca1ce422d"),
                    Tuple.Create(
                            @"https://github.com/jayway/maven-android-plugin.git",
                            @"2ce1428c8e83365c5ac096b7855e71bd8a035013",
                            "d25945fa9d270ecd65eff72f3b0bb5d5f54d2dbc"),
                    Tuple.Create(
                            @"https://github.com/square/spoon.git",
                            @"975dacb45607ed45492fa3dd9e697f0a5263e71a",
                            "97d7f54e714d171d3a524af751a8407d70c65d7f"),
                };
                foreach (var exp in exps) {
                    foreach (
                            var learningSet in
                                    learningSets.Skip(SkipCount)
                                            .Take(TakeCount)) {
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
        public void Test(LearningExperiment exp, string projectPath, int starCount) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.java"), };
            if (_lastProjectName != exp.GetType().Name) {
                _writer.WriteLine();
                _writer.Write(Path.GetFileName(projectPath) + ",");
                _lastProjectName = exp.GetType().Name;
            }
            var ret = exp.Learn(seedPaths, _writer, projectPath, "*.java");
            _writer.Flush();
            if (ret.WrongFeatureCount > 0) {
                Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
                foreach (var we in ret.WronglyAcceptedElements) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
                Console.WriteLine("---- WronglyRejectedElements ----");
                foreach (var we in ret.WronglyRejectedElements) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
            }
            exp.Clear();
            Assert.That(ret.WrongFeatureCount, Is.EqualTo(0));
        }

        public void CalculateMetrics(LearningExperiment exp, string projectPath, int starCount) {
            if (!(exp is JavaSuperComplexBranchExperiment)) {
                return;
            }
            var commitPointers = Git.GetCommitPointers(projectPath, Generator, "*.java");
            Action goNow = () => Git.Checkout(projectPath, commitPointers.Item1);
            Action goBack = () => Git.Checkout(projectPath, commitPointers.Item2);
            goBack();
            var allPaths = Directory.GetFiles(projectPath, "*.java", SearchOption.AllDirectories)
                    .ToList();
            var allNodes = allPaths.Select(p => Generator.GenerateTreeFromCodePath(p))
                    .SelectMany(r => r.DescendantsAndSelf());
            var statementCount = 0;
            var branchCount = 0;
            foreach (var node in allNodes) {
                if (node.Name == "statement") {
                    switch (node.FirstChild.TokenText) {
                    case "if":
                    case "while":
                    case "do":
                    case "switch":
                        branchCount++;
                        break;
                    }
                } else if (node.Name == "conditionalExpression" && node.Children().Skip(1).Any()) {
                    branchCount++;
                } else if (node.Name == "switchLabel" && node.FirstChild.TokenText == "case") {
                    branchCount++;
                } else if (node.Name == "statement" || node.Name == "localVariableDeclarationStatement") {
                    statementCount++;
                }
            }
            _writer.Write(statementCount + ",");
            _writer.Write(branchCount + ",");
            _writer.WriteLine();
            _writer.Flush();
            goNow();
        }
    }

    public class JavaSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSuperComplexBranchExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            {
                var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                //if (primary.Elements().All(e2 => e2.TokenText() != "Preconditions")) {
                //	return false;
                //}
                if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                //if (primary.NthElementOrDefault(0).SafeTokenText() != "Preconditions") {
                //	return false;
                //}
                //if (primary.NthElementOrDefault(2).SafeTokenText() != "checkArgument") {
                //	return false;
                //}
                if (e.ElementsBeforeSelf().Any()) {
                    return false;
                }
                return true;
            }
        }

        public IEnumerable<CstNode> SelectBooleanExpressions(CstNode e) {
            var expressions = e.Descendants("expression")
                    .Where(
                            e_ => IsIf(e_) || IsWhile(e_) ||
                                  IsDoWhile(e_) || IsFor(e_) || IsCheckArgument(e_))
                    .Where(e_ => !IsChild(e_, IsCatchBlock));
            return expressions;
        }

        public bool IsCatchBlock(CstNode e) {
            // catch { .. snip .. } 
            return e.Name == "block" && e.Parent.Name == "catchClause";
        }

        public bool IsChild(CstNode e, Func<CstNode, bool> isCatchBlock) {
            return e.Ancestors().Any(isCatchBlock);
        }

        public bool IsIf(CstNode e) {
            // if (cond) { .. snip .. }
            CstNode p = e.Parent, pp = p.Parent;
            return p.Name == "parExpression" && pp.Name == "statement"
                   && pp.FirstChild.TokenText == "if";
        }

        public bool IsWhile(CstNode e) {
            // while (cond) { .. snip .. }
            CstNode p = e.Parent, pp = p.Parent;
            return p.Name == "parExpression" && pp.Name == "statement"
                   && pp.FirstChild.TokenText == "while";
        }

        public bool IsDoWhile(CstNode e) {
            // do { .. snip .. } while (cond);
            CstNode p = e.Parent, pp = p.Parent;
            return p.Name == "parExpression" && pp.Name == "statement"
                   && pp.FirstChild.TokenText == "do";
        }

        public bool IsFor(CstNode e) {
            // do { .. snip .. } while (cond);
            var p = e.Parent;
            return p.Name == "forstatement"
                   && p.Elements().Count(e_ => e_.TokenText == ";") >= 2;
        }

        public bool IsCheckArgument(CstNode e) {
            // Preconditions.checkArgument(cond, msg);
            var primary = e.Parent.Parent.Parent.Parent;
            return primary.Name == "primary"
                   && primary.Elements().Any(e2 => e2.TokenText == "checkArgument")
                   && e.ElementsBeforeSelf().Count() == 0;
        }
    }

    public class JavaComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaComplexBranchExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            return false;
        }
    }

    public class JavaIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaIfExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            return false;
        }
    }

    public class JavaWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaWhileExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            return false;
        }
    }

    public class JavaDoWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaDoWhileExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            return false;
        }
    }

    public class JavaForExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaForExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            return false;
        }
    }

    public class JavaPreconditionsExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaPreconditionsExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
            if (primary.SafeName() != "primary") {
                return false;
            }
            //if (primary.Elements().All(e2 => e2.TokenText() != "Preconditions")) {
            //	return false;
            //}
            if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                return false;
            }
            //if (primary.NthElementOrDefault(0).SafeTokenText() != "Preconditions") {
            //	return false;
            //}
            //if (primary.NthElementOrDefault(2).SafeTokenText() != "checkArgument") {
            //	return false;
            //}
            if (e.ElementsBeforeSelf().Any()) {
                return false;
            }
            return true;
        }
    }

    public class JavaComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaComplexStatementExperiment() : base("statement", "blockStatement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "blockStatement") {
                if (e.FirstChild.Name != "statement") {
                    return true;
                }
                e = e.FirstChild;
            }

            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (e.FirstChild.Name == "block") {
                return false;
            }
            // ラベルはループ文に付くため，ラベルの中身は除外
            var second = e.Siblings().ElementAtOrDefault(1);
            if (second != null && second.TokenText == ":"
                && e.Parent.Name == "statement") {
                return false;
            }
            if (e.FirstChild.TokenText == ";") {
                return false;
            }
            return true;
        }

        /*
blockStatement 
    : localVariableDeclarationStatement
    | classOrInterfaceDeclaration
    | statement
    ;
statement 
    : block
    | ';'
    | IDENTIFIER ':' statement
	| expression ';'
    | ... (snip) ...
	;
		 */

        public IEnumerable<CstNode> SelectStatements(CstNode e) {
            var blockStatements = e.Descendants("blockStatement")
                    .Where(e_ => IsVariableDeclaration(e_) || IsClassDeclaration(e_));
            var statements = e.Descendants("statement")
                    .Where(
                            e_ =>
                                    !IsBlockStatement(e_) && !IsEmptyStatement(e_)
                                    && !IsLabeledStatement(e_));
            return blockStatements.Concat(statements);
        }

        public bool IsVariableDeclaration(CstNode e) {
            // int value = 0;
            return e.FirstChild.Name == "localVariableDeclarationStatement";
        }

        public bool IsClassDeclaration(CstNode e) {
            // class A {}
            return e.FirstChild.Name == "classOrInterfaceDeclaration";
        }

        public bool IsBlockStatement(CstNode e) {
            // { int value = 0; }
            return e.FirstChild.Name == "block";
        }

        public bool IsEmptyStatement(CstNode e) {
            // ;
            return e.TokenText == ";";
        }

        public bool IsLabeledStatement(CstNode e) {
            // LABEL: should_be_ignored();
            var second = e.Siblings().ElementAtOrDefault(1);
            return second != null && second.TokenText == ":";
        }
    }

    public class JavaBlockExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaBlockExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (e.FirstChild.Name == "block") {
                return true;
            }
            return false;
        }
    }

    public class JavaStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.Name == "statement";
        }
    }

    public class JavaLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaLabeledStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ラベルはループ文に付くため，ラベルの中身は除外
            var second = e.Siblings().ElementAtOrDefault(1);
            if (second != null && second.TokenText == ":"
                && e.Parent.Name == "statement") {
                return true;
            }
            return false;
        }
    }

    public class JavaEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaEmptyStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.TokenText == ";") {
                return true;
            }
            return false;
        }
    }

    public class JavaExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaExpressionStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.FirstChild.Name == "expression";
        }
    }

    public class JavaArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaArithmeticOperatorExperiment() : base("PLUS", "SUB", "STAR", "SLASH") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return ((e.TokenText == "+" || e.TokenText == "-")
                    && e.Parent.Name == "additiveExpression") ||
                   ((e.TokenText == "*" || e.TokenText == "/")
                    && e.Parent.Name == "multiplicativeExpression");
        }
    }

    public class JavaSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSwitchCaseExperiment() : base("expression", "switchLabel") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            return e.Name == "switchLabel";
        }
    }

    public class JavaSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSuperComplexBranchExperimentWithSwitch() : base("expression", "switchLabel") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return true;
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            if (e.Name == "switchLabel") {
                return true;
            }
            {
                var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                if (e.ElementsBeforeSelf().Any()) {
                    return false;
                }
                return true;
            }
        }
    }

    public class JavaSuperComplexBranchExperimentWithSwitchWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("expression", "switchLabel") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return e.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return e.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return e.TokenText != "true";
            }
            if (p.SafeName() == "forstatement"
                && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
                return e.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            if (e.Name == "switchLabel") {
                return true;
            }
            {
                var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                if (e.ElementsBeforeSelf().Any()) {
                    return false;
                }
                return e.TokenText != "true";
            }
        }
    }
}