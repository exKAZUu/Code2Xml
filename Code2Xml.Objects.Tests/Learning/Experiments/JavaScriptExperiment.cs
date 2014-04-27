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
    public class JavaScriptExperiment {
        private readonly StreamWriter _writer = File.CreateText(
                @"C:\Users\exKAZUu\Dropbox\Data\js" + JavaExperiment.SkipCount + "_"
                + JavaExperiment.TakeCount + ".csv");

        public static CstGenerator Generator = CstGenerators.JavaScriptUsingAntlr3;
        private string _lastProjectName;
        private const string LangName = "JavaScript";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new JavaScriptComplexStatementExperiment(),
                    new JavaScriptSuperComplexBranchExperiment(),
                    new JavaScriptExpressionStatementExperiment(),
                    new JavaScriptArithmeticOperatorExperiment(),
                    new JavaScriptSwitchCaseExperiment(),
                    new JavaScriptSuperComplexBranchExperimentWithSwitch(),
                    new JavaScriptSuperComplexBranchExperimentWithSwitchWithoutTrue(), 
                    //new JavaScriptComplexBranchExperiment(),
                    //new JavaScriptIfExperiment(),
                    //new JavaScriptWhileExperiment(),
                    //new JavaScriptDoWhileExperiment(),
                    //new JavaScriptForExperiment(),
                    //new JavaScriptConsoleLogExperiment(),
                    //new JavaScriptStatementExperiment(),
                    //new JavaScriptBlockExperiment(),
                    //new JavaScriptLabeledStatementExperiment(),
                    //new JavaScriptEmptyStatementExperiment(),
                };
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/jashkenas/backbone.git",
                            @"285e07b6b3d6241966866d0662595ac9611c0f61",
                            "418b77ffffe9366a053d3ed73d8d7f6a204e188e"),
                    Tuple.Create(
                            @"https://github.com/blueimp/jQuery-File-Upload.git",
                            @"8dc29ded32a0f2caad86ebbdf8b23a22375ae78c",
                            "935805821f308c796c03d3c1f018d6414dd540cd"),
                    Tuple.Create(
                            @"https://github.com/hakimel/reveal.js.git",
                            @"9da952fea30906090446d038430186b11dba7f13",
                            "48f5ba936703a731392ead9ed910a6c7b21d898c"),
                    Tuple.Create(
                            @"https://github.com/visionmedia/express.git",
                            @"e1ab302234d82390f280ecfb478994cdff8809b6",
                            "0f2f3d4e2942840dd4be6cfdab1faaef3a7dbca8"),
                    Tuple.Create(
                            @"https://github.com/ivaynberg/select2.git",
                            @"100266bbb5a16eaefaa45e23de69e1e06464f97a",
                            "c2fa04529bba174819765b8a022f44fbfd873807"),
                    Tuple.Create(
                            @"https://github.com/emberjs/ember.js.git",
                            @"efd72af4ca25f246f241bcf5efd736a17c5ba87c",
                            "4cba6b08e6dc80454e7adcd4e0e314533507da43"),
                    Tuple.Create(
                            @"https://github.com/jquery/jquery-mobile.git",
                            @"1f95855f47bf0b4302b1749dda88a4d64b1345bf",
                            "0c449121278c3711d376da97aa78e80663d58752"),
                    Tuple.Create(
                            @"https://github.com/caolan/async.git",
                            @"931d15412c5081e35f96dee3cc7a98d8322e7b17",
                            "d03373932353f63f4d97998b1ed03faf89311abe"),
                    Tuple.Create(
                            @"https://github.com/jquery/jquery-ui.git",
                            @"919d9185f2cf586f794b367a2570368fd81f3879",
                            "d871fe46aa18abd561f2f9189a5e14c00f022420"),
                    Tuple.Create(
                            @"https://github.com/gruntjs/grunt.git",
                            @"4ae8a07d3854f5affd3002d3395725dc25648ee3",
                            "3702899234e14c3133ac0825aab67ab4fa047f12"),
                    Tuple.Create(
                            @"https://github.com/nnnick/Chart.js.git",
                            @"8f025f33c08c66991a12f02f908bab156a963aef",
                            "9453a670cd4d082895b2fe8d7af22177cf92dd90"),
                    Tuple.Create(
                            @"https://github.com/Semantic-Org/Semantic-UI.git",
                            @"14d97f7336efde50efddf0ddee7ebd42734afb40",
                            "8b1f8badcf53b5bfb5d0efd989844c228086427f"),
                    Tuple.Create(
                            @"https://github.com/EightMedia/hammer.js.git",
                            @"b9e3ecec174c7ae217489dc3a24540a64243692e",
                            "6d61b69b792dcaf2518cb63edc04547120077ded"),
                    Tuple.Create(
                            @"https://github.com/pivotal/jasmine.git",
                            @"00c8e372576438243a8f977b8bc7b81f04389dd6",
                            "4138fd3626ac9b654de3bad62ab42c0ab422a6e8"),
                    Tuple.Create(
                            @"https://github.com/browserstate/history.js.git",
                            @"14968aa3cf2a27335f71d26386de0a5c4073835d",
                            "3cbe0164564c71be9f48454e375f7379e6da98fa"),
                    Tuple.Create(
                            @"https://github.com/wycats/handlebars.js.git",
                            @"085e5e1937b442a4d4add5525db2627e825538aa",
                            "da130f7745fc338d7ea31c60d9954ab6e0e1511a"),
                    Tuple.Create(
                            @"https://github.com/NUKnightLab/TimelineJS.git",
                            @"cede826f6212af83361ecd571481b5bb95f7a610",
                            "e06e1f52d1f6c0d2d7d6da2050873e7ea47b84ae"),
                    Tuple.Create(
                            @"https://github.com/DmitryBaranovskiy/raphael.git",
                            @"5234aa33d04be07b0fea7627504ab4b53d872e19",
                            "65792bb06561d6ccf45a7e99712de8889958e848"),
                    Tuple.Create(
                            @"https://github.com/fgnass/spin.js.git",
                            @"cdf391a8e41b6ad8f902dc9a10cae80486d472ef",
                            "4b105f42d61e1152c63ba0f33bb7a3e822772823"),
                    Tuple.Create(
                            @"https://github.com/balderdashy/sails.git",
                            @"6adfdf85eebdc6e001bacdc5098a58a1cd93aa38",
                            "6265594e0a9a8164dd22b41208f072c30fe0b941"),
                    Tuple.Create(
                            @"https://github.com/xing/wysihtml5.git",
                            @"56960b31adc37e07797382d8e8b10109f206b19c",
                            "c10ba3221dc7de4b43b5234786b2c90a9553a7fc"),
                    Tuple.Create(
                            @"https://github.com/jrburke/requirejs.git",
                            @"f1c533d181da5b759adc7f6297e87d556ef02ce2",
                            "6abf6b0df3c62f78341d60daefb76c1bcf375bea"),
                    Tuple.Create(
                            @"https://github.com/enyo/dropzone.git",
                            @"ac87ee44d7219afb091e22db0748e58ca989b466",
                            "83728ca84f6f31b36893a5e323707059bb8d8400"),
                    Tuple.Create(
                            @"https://github.com/videojs/video.js.git",
                            @"3bafdeef51d9f135de13fe4c51158942031ce6c2",
                            "45fa3dc45a572877e64c03ca047dbea85328b93d"),
                    Tuple.Create(
                            @"https://github.com/Widen/fine-uploader.git",
                            @"55166f33438e4915045f17d8c4e1adea008af19b",
                            "fd59c79a3a6b0d55b101aa39212b0623d40f6039"),
                    Tuple.Create(
                            @"https://github.com/guillaumepotier/Parsley.js.git",
                            @"2f5ebd0422a2c1207738c212563b5da16b2bb032",
                            "6728db1b215f0292e2a4436aec65b290441e46cc"),
                    Tuple.Create(
                            @"https://github.com/mishoo/UglifyJS.git",
                            @"2bc1d02363db3798d5df41fb5059a19edca9b7eb",
                            "77f28277c930b646a55b84f7f8d9af6feaea61b0"),
                    Tuple.Create(
                            @"https://github.com/ccampbell/mousetrap.git",
                            @"afaaf95f984f2e2a80670b980d421683ac42eed6",
                            "a2059e4663ac96b5a57213e52d8908e13945d9a0"),
                    Tuple.Create(
                            @"https://github.com/marionettejs/backbone.marionette.git",
                            @"84e735d7d7cf85957fe08caebcd086cf7ee11e42",
                            "2730e21eb199edf42b06228095c700c221468215"),
                    Tuple.Create(
                            @"https://github.com/LearnBoost/mongoose.git",
                            @"f243bc9453a3c43cd00f89d0df0f7feb097f3668",
                            "2a7b1ea75e7102b1d90074f8501cd098a6996814"),
                    Tuple.Create(
                            @"https://github.com/Kicksend/mailcheck.git",
                            @"5ff8678cc4b7ec36c4442ccc6213910aa734f4d7",
                            "e1d81a18edd2a9c98722395cd6e69bbbe409f37d"),
                    Tuple.Create(
                            @"https://github.com/javve/list.js.git",
                            @"9754c28262b07e647e0ad3de181cdb4e323e7db7",
                            "c4e1834b9c35768738aca03bc6a423f3ba7226cb"),
                    Tuple.Create(
                            @"https://github.com/mikeal/request.git",
                            @"6a4fd9ad6f57ba27a24f7cea01d0c702f7f5fefa",
                            "12f4997ed83bfbfefa3fc5b5635bc9a6829aa0d7"),
                    Tuple.Create(
                            @"https://github.com/visionmedia/mocha.git",
                            @"638e049cfae48f35493c8b4bf3c5debe5691d751",
                            "dbac210a7583712ab15edeefd54e8355954af9d2"),
                    Tuple.Create(
                            @"https://github.com/substack/node-browserify.git",
                            @"2bfdd64ef45e5c1760fe8fa90e2c80033a238d12",
                            "7ce2d7d8b357e0dea78706415a60c1a4f4d708fd"),
                    Tuple.Create(
                            @"https://github.com/shutterstock/rickshaw.git",
                            @"71877d994a81d39a003e3638b751ac5e6d6c87c6",
                            "c484798bd9ff0201274ad7a7468cf8338af4c07a"),
                    Tuple.Create(
                            @"https://github.com/npm/npm.git",
                            @"6be6b4b74e5fd256a1bdfa098ea6541c62b30928",
                            "218fcb79f43c32d622817b2f61d6f2a257e2a08d"),
                    Tuple.Create(
                            @"https://github.com/imakewebthings/deck.js.git",
                            @"63b55fea6b92d442e20fb64446783d9f2ac7c85b",
                            "7c1c3f6b66e81887829bfd8e0f9bc40cd35d8338"),
                    Tuple.Create(
                            @"https://github.com/adobe-webplatform/Snap.svg.git",
                            @"f94872941f4f833e2f1feb88c2ef1c43d83a88b4",
                            "570cae0c49345574bec3e29349d4188afbd46e36"),
                    Tuple.Create(
                            @"https://github.com/jzaefferer/jquery-validation.git",
                            @"13d56eb009d2b3d767e1de6d8926f337c41e6c3f",
                            "78515511035f0989ddfd8191c70b3378b8e452ff"),
                    Tuple.Create(
                            @"https://github.com/imakewebthings/jquery-waypoints.git",
                            @"6c7d129433343d04feca94310f117a966dab4721",
                            "a417017cee5c43aa91f2463d92193c44aea946de"),
                    Tuple.Create(
                            @"https://github.com/jhollingworth/bootstrap-wysihtml5.git",
                            @"283bb8f859977ac1aafb09bee715a1190f8cfd1b",
                            "71971c4b74b96e856077ce890264292fdf8776d1"),
                    Tuple.Create(
                            @"https://github.com/GitbookIO/gitbook.git",
                            @"f43e630528be43d5aec4e6f923b0f53107f93546",
                            "68e35758c33168e9b3fe1c678e07d52b42879720"),
                    Tuple.Create(
                            @"https://github.com/brianreavis/selectize.js.git",
                            @"d6a6f53625f5d9c4de9337978e05b80136983990",
                            "453ceec35e364093825f6f7b942b8963cc785e62"),
                    Tuple.Create(
                            @"https://github.com/jaredhanson/passport.git",
                            @"298d2452430dd0d1841d417e9c0d0b23e4b06239",
                            "aef7469e7c61468095f17d6605c029767c0a5d15"),
                    Tuple.Create(
                            @"https://github.com/h5bp/mobile-boilerplate.git",
                            @"36661edc9092730346f66fe0d7785712604ffc41",
                            "bd60b15b400cceb7294f8e0cc031d6f79997978c"),
                    Tuple.Create(
                            @"https://github.com/twitter/hogan.js.git",
                            @"b1328c06eedf316bbe4c54b189ecb47cff7ac2ed",
                            "bd7e730921e1187f0d818290d8602ad7a5a24e9e"),
                    Tuple.Create(
                            @"https://github.com/paulasmuth/fnordmetric.git",
                            @"d402c92fe6c880da28a27d3a5fa441965f55bd3d",
                            "beb02e1b983a7e8af315734d9c292363c1ad6a2b"),
                    Tuple.Create(
                            @"https://github.com/alvarotrigo/fullPage.js.git",
                            @"9c149a3b43fd5450f2cc6d0dc7cd7bc5b6edd01e",
                            "b83db9f8ef2eb086d52c2d49378dc2ea7e1e8414"),
                    Tuple.Create(
                            @"https://github.com/flot/flot.git",
                            @"3aec7ce0bd975e452ff49107905a06146fe9e560",
                            "f01bcee85446beb63a04d0b95c427f68c92ae4a9"),
                };
                foreach (var exp in exps) {
                    foreach (
                            var learningSet in
                                    learningSets.Skip(JavaExperiment.SkipCount)
                                            .Take(JavaExperiment.TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        Git.Clone(path, url);
                        yield return
                                new TestCaseData(exp, path, learningSet.Item2, learningSet.Item3);
                    }
                }
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, int starCount) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "seed.js"), };
            if (_lastProjectName != exp.GetType().Name) {
                _writer.WriteLine();
                _writer.Write(Path.GetFileName(projectPath) + ",");
                _lastProjectName = exp.GetType().Name;
            }
            exp.Learn(seedPaths, _writer, projectPath, "*.js");
            _writer.Flush();
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
        }
    }

    public class JavaScriptSuperComplexBranchExperiment : LearningExperiment {
        public JavaScriptSuperComplexBranchExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return true;
            }
            if (parentName == "whileStatement") {
                return true;
            }
            if (parentName == "doWhileStatement") {
                return true;
            }
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            var p = e.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Element("arguments").Element("assignmentExpression") == e) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptComplexBranchExperiment : LearningExperiment {
        public JavaScriptComplexBranchExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return true;
            }
            if (parentName == "whileStatement") {
                return true;
            }
            if (parentName == "doWhileStatement") {
                return true;
            }
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptIfExperiment : LearningExperiment {
        public JavaScriptIfExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptWhileExperiment : LearningExperiment {
        public JavaScriptWhileExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "whileStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptDoWhileExperiment : LearningExperiment {
        public JavaScriptDoWhileExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "doWhileStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptForExperiment : LearningExperiment {
        public JavaScriptForExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptConsoleLogExperiment : LearningExperiment {
        public JavaScriptConsoleLogExperiment() : base("assignmentExpression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Element("arguments").Element("assignmentExpression") == e) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaScriptStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return true;
        }
    }

    public class JavaScriptComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaScriptComplexStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "statementBlock") {
                return false;
            }
            if (e.FirstChild.Name == "labelledStatement") {
                return false;
            }
            if (e.FirstChild.Name == "emptyStatement") {
                return false;
            }
            return true;
        }
    }

    public class JavaScriptBlockExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaScriptBlockExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "statementBlock") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaScriptLabeledStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "labelledStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaScriptEmptyStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "emptyStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public JavaScriptExpressionStatementExperiment() : base("expressionStatement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "statement") {
                e = e.FirstChild;
            }
            return e.Name == "expressionStatement";
        }
    }

    public class JavaScriptArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaScriptArithmeticOperatorExperiment() : base("TOKENS") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return ((e.TokenText == "*" || e.TokenText == "/")
                    && e.Parent.Name == "multiplicativeExpression")
                   ||
                   ((e.TokenText == "+" || e.TokenText == "-")
                    && e.Parent.Name == "additiveExpression");
        }
    }

    public class JavaScriptSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public JavaScriptSwitchCaseExperiment() : base("expression", "caseClause", "defaultClause") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Parent.Name == "switchStatement") {
                return true;
            }
            return e.Name == "caseClause" || e.Name == "defaultClause";
        }
    }

    public class JavaScriptSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        public JavaScriptSuperComplexBranchExperimentWithSwitch()
                : base("expression", "caseClause", "defaultClause") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return true;
            }
            if (parentName == "whileStatement") {
                return true;
            }
            if (parentName == "doWhileStatement") {
                return true;
            }
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            if (parentName == "switchStatement") {
                return true;
            }
            if (e.Name == "caseClause" || e.Name == "defaultClause") {
                return true;
            }
            var p = e.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Element("arguments").Element("assignmentExpression") == e) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptSuperComplexBranchExperimentWithSwitchWithoutTrue : LearningExperiment {
        public JavaScriptSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("expression", "caseClause", "defaultClause") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return e.TokenText != "true";
            }
            if (parentName == "whileStatement") {
                return e.TokenText != "true";
            }
            if (parentName == "doWhileStatement") {
                return e.TokenText != "true";
            }
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return e.TokenText != "true";
            }
            if (parentName == "switchStatement") {
                return true;
            }
            if (e.Name == "caseClause" || e.Name == "defaultClause") {
                return true;
            }
            var p = e.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Element("arguments").Element("assignmentExpression") == e) {
                return e.TokenText != "true";
            }
            return false;
        }
    }
}