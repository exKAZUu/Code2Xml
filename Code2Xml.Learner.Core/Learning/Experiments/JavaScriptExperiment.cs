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
    public class JavaScriptExperiment : Experiment {
        public static CstGenerator Generator = CstGenerators.JavaScriptUsingAntlr3;

        private static readonly Tuple<string, string>[] LearningSets = {
            Tuple.Create(
                    @"https://github.com/jashkenas/backbone.git",
                    @"285e07b6b3d6241966866d0662595ac9611c0f61"),
            Tuple.Create(
                    @"https://github.com/blueimp/jQuery-File-Upload.git",
                    @"8dc29ded32a0f2caad86ebbdf8b23a22375ae78c"),
            Tuple.Create(
                    @"https://github.com/hakimel/reveal.js.git",
                    @"9da952fea30906090446d038430186b11dba7f13"),
            Tuple.Create(
                    @"https://github.com/visionmedia/express.git",
                    @"e1ab302234d82390f280ecfb478994cdff8809b6"),
            Tuple.Create(
                    @"https://github.com/ivaynberg/select2.git",
                    @"100266bbb5a16eaefaa45e23de69e1e06464f97a"),
            Tuple.Create(
                    @"https://github.com/emberjs/ember.js.git",
                    @"efd72af4ca25f246f241bcf5efd736a17c5ba87c"),
            Tuple.Create(
                    @"https://github.com/jquery/jquery-mobile.git",
                    @"1f95855f47bf0b4302b1749dda88a4d64b1345bf"),
            Tuple.Create(
                    @"https://github.com/caolan/async.git",
                    @"931d15412c5081e35f96dee3cc7a98d8322e7b17"),
            Tuple.Create(
                    @"https://github.com/jquery/jquery-ui.git",
                    @"919d9185f2cf586f794b367a2570368fd81f3879"),
            Tuple.Create(
                    @"https://github.com/gruntjs/grunt.git",
                    @"4ae8a07d3854f5affd3002d3395725dc25648ee3"),
            Tuple.Create(
                    @"https://github.com/nnnick/Chart.js.git",
                    @"8f025f33c08c66991a12f02f908bab156a963aef"),
            Tuple.Create(
                    @"https://github.com/Semantic-Org/Semantic-UI.git",
                    @"14d97f7336efde50efddf0ddee7ebd42734afb40"),
            Tuple.Create(
                    @"https://github.com/EightMedia/hammer.js.git",
                    @"b9e3ecec174c7ae217489dc3a24540a64243692e"),
            Tuple.Create(
                    @"https://github.com/pivotal/jasmine.git",
                    @"00c8e372576438243a8f977b8bc7b81f04389dd6"),
            Tuple.Create(
                    @"https://github.com/browserstate/history.js.git",
                    @"14968aa3cf2a27335f71d26386de0a5c4073835d"),
            Tuple.Create(
                    @"https://github.com/wycats/handlebars.js.git",
                    @"085e5e1937b442a4d4add5525db2627e825538aa"),
            Tuple.Create(
                    @"https://github.com/NUKnightLab/TimelineJS.git",
                    @"cede826f6212af83361ecd571481b5bb95f7a610"),
            Tuple.Create(
                    @"https://github.com/DmitryBaranovskiy/raphael.git",
                    @"5234aa33d04be07b0fea7627504ab4b53d872e19"),
            Tuple.Create(
                    @"https://github.com/fgnass/spin.js.git",
                    @"cdf391a8e41b6ad8f902dc9a10cae80486d472ef"),
            Tuple.Create(
                    @"https://github.com/balderdashy/sails.git",
                    @"6adfdf85eebdc6e001bacdc5098a58a1cd93aa38"),
            Tuple.Create(
                    @"https://github.com/xing/wysihtml5.git",
                    @"56960b31adc37e07797382d8e8b10109f206b19c"),
            Tuple.Create(
                    @"https://github.com/jrburke/requirejs.git",
                    @"f1c533d181da5b759adc7f6297e87d556ef02ce2"),
            Tuple.Create(
                    @"https://github.com/enyo/dropzone.git",
                    @"ac87ee44d7219afb091e22db0748e58ca989b466"),
            Tuple.Create(
                    @"https://github.com/videojs/video.js.git",
                    @"3bafdeef51d9f135de13fe4c51158942031ce6c2"),
            Tuple.Create(
                    @"https://github.com/Widen/fine-uploader.git",
                    @"55166f33438e4915045f17d8c4e1adea008af19b"),
            Tuple.Create(
                    @"https://github.com/guillaumepotier/Parsley.js.git",
                    @"2f5ebd0422a2c1207738c212563b5da16b2bb032"),
            Tuple.Create(
                    @"https://github.com/mishoo/UglifyJS.git",
                    @"2bc1d02363db3798d5df41fb5059a19edca9b7eb"),
            Tuple.Create(
                    @"https://github.com/ccampbell/mousetrap.git",
                    @"afaaf95f984f2e2a80670b980d421683ac42eed6"),
            Tuple.Create(
                    @"https://github.com/marionettejs/backbone.marionette.git",
                    @"84e735d7d7cf85957fe08caebcd086cf7ee11e42"),
            Tuple.Create(
                    @"https://github.com/LearnBoost/mongoose.git",
                    @"f243bc9453a3c43cd00f89d0df0f7feb097f3668"),
            Tuple.Create(
                    @"https://github.com/Kicksend/mailcheck.git",
                    @"5ff8678cc4b7ec36c4442ccc6213910aa734f4d7"),
            Tuple.Create(
                    @"https://github.com/javve/list.js.git",
                    @"9754c28262b07e647e0ad3de181cdb4e323e7db7"),
            Tuple.Create(
                    @"https://github.com/mikeal/request.git",
                    @"6a4fd9ad6f57ba27a24f7cea01d0c702f7f5fefa"),
            Tuple.Create(
                    @"https://github.com/visionmedia/mocha.git",
                    @"638e049cfae48f35493c8b4bf3c5debe5691d751"),
            Tuple.Create(
                    @"https://github.com/substack/node-browserify.git",
                    @"2bfdd64ef45e5c1760fe8fa90e2c80033a238d12"),
            Tuple.Create(
                    @"https://github.com/shutterstock/rickshaw.git",
                    @"71877d994a81d39a003e3638b751ac5e6d6c87c6"),
            Tuple.Create(
                    @"https://github.com/npm/npm.git",
                    @"6be6b4b74e5fd256a1bdfa098ea6541c62b30928"),
            Tuple.Create(
                    @"https://github.com/imakewebthings/deck.js.git",
                    @"63b55fea6b92d442e20fb64446783d9f2ac7c85b"),
            Tuple.Create(
                    @"https://github.com/adobe-webplatform/Snap.svg.git",
                    @"f94872941f4f833e2f1feb88c2ef1c43d83a88b4"),
            Tuple.Create(
                    @"https://github.com/jzaefferer/jquery-validation.git",
                    @"13d56eb009d2b3d767e1de6d8926f337c41e6c3f"),
            Tuple.Create(
                    @"https://github.com/imakewebthings/jquery-waypoints.git",
                    @"6c7d129433343d04feca94310f117a966dab4721"),
            Tuple.Create(
                    @"https://github.com/jhollingworth/bootstrap-wysihtml5.git",
                    @"283bb8f859977ac1aafb09bee715a1190f8cfd1b"),
            Tuple.Create(
                    @"https://github.com/GitbookIO/gitbook.git",
                    @"f43e630528be43d5aec4e6f923b0f53107f93546"),
            Tuple.Create(
                    @"https://github.com/brianreavis/selectize.js.git",
                    @"d6a6f53625f5d9c4de9337978e05b80136983990"),
            Tuple.Create(
                    @"https://github.com/jaredhanson/passport.git",
                    @"298d2452430dd0d1841d417e9c0d0b23e4b06239"),
            Tuple.Create(
                    @"https://github.com/h5bp/mobile-boilerplate.git",
                    @"36661edc9092730346f66fe0d7785712604ffc41"),
            Tuple.Create(
                    @"https://github.com/twitter/hogan.js.git",
                    @"b1328c06eedf316bbe4c54b189ecb47cff7ac2ed"),
            Tuple.Create(
                    @"https://github.com/paulasmuth/fnordmetric.git",
                    @"d402c92fe6c880da28a27d3a5fa441965f55bd3d"),
            Tuple.Create(
                    @"https://github.com/alvarotrigo/fullPage.js.git",
                    @"9c149a3b43fd5450f2cc6d0dc7cd7bc5b6edd01e"),
            Tuple.Create(
                    @"https://github.com/flot/flot.git",
                    @"3aec7ce0bd975e452ff49107905a06146fe9e560"),
        };

        private static readonly LearningExperiment[] Experiments = {
            //new JavaScriptComplexStatementExperiment(),
            //new JavaScriptSuperComplexBranchExperiment(),
            new JavaScriptExpressionStatementExperiment(),
            //new JavaScriptArithmeticOperatorExperiment(),
            //new JavaScriptSwitchCaseExperiment(),
            //new JavaScriptSuperComplexBranchExperimentWithSwitch(),
            //new JavaScriptSuperComplexBranchExperimentWithSwitchWithoutTrue(), 

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

        private const string LangName = "JavaScript";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                foreach (var exp in Experiments) {
                    foreach (var learningSet in LearningSets.Skip(SkipCount).Take(TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", url + "Clone\r\n");
                        Git.Clone(path, url);
                        Git.Checkout(path, learningSet.Item2);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", "Done\r\n");
                        yield return new TestCaseData(exp, path);
                    }
                }
            }
        }

        protected override string SearchPattern {
            get { return "*.js"; }
        }

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "seed.js"), };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "seed.js"), };
            Learn(seedPaths, exp, projectPath);
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

        public override int MaxUp {
            get { return 2; }
        }

        public override int MaxLeft {
            get { return 1; }
        }

        public override int MaxRight {
            get { return 0; }
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
                && e.Prev == e.Parent.Children().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            var p = e.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Child("arguments").Child("assignmentExpression") == e) {
                return true;
            }
            return false;
        }

        public override IList<CstNode> GetRootsUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return new[] { e.Prev.Prev, e.Prev, e };
            }
            if (parentName == "whileStatement") {
                return new[] { e.Prev.Prev, e.Prev, e };
            }
            if (parentName == "doWhileStatement") {
                return new[] { e.Prev.Prev, e.Prev, e, e.Next };
            }
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Children().First(e2 => e2.TokenText == ";")) {
                return e.PrevsFromSelfAndSelf().Concat(Enumerable.Repeat(e.Next, 1))
                        .ToList();
            }
            var pp = e.SafeParent().SafeParent();
            if (pp.SafeName() == "callExpression" && pp.FirstChild.TokenText == "console.log" &&
                pp.Child("arguments").Child("assignmentExpression") == e) {
                return new[] { pp };
            }
            return new CstNode[0];
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
                && e.Prev == e.Parent.Children().First(e2 => e2.TokenText == ";")) {
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
                && e.Prev == e.Parent.Children().First(e2 => e2.TokenText == ";")) {
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
                p.Child("arguments").Child("assignmentExpression") == e) {
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

        public override IList<CstNode> GetRootsUsingOracle(CstNode e) {
            if (e.Name == "statement") {
                e = e.FirstChild;
            }
            if (e.Name == "expressionStatement") {
                return new[] { e.Parent };
            }
            return new CstNode[0];
        }
    }

    public class JavaScriptArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public override int MaxUp {
            get { return 2; }
        }

        public override int MaxLeft {
            get { return 0; }
        }

        public override int MaxRight {
            get { return 0; }
        }

        public JavaScriptArithmeticOperatorExperiment() : base("TOKENS") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return ((e.TokenText == "*" || e.TokenText == "/")
                    && e.Parent.Name == "multiplicativeExpression")
                   ||
                   ((e.TokenText == "+" || e.TokenText == "-")
                    && e.Parent.Name == "additiveExpression");
        }

        public override IList<CstNode> GetRootsUsingOracle(CstNode e) {
            if (((e.TokenText == "*" || e.TokenText == "/")
                 && e.Parent.Name == "multiplicativeExpression")
                ||
                ((e.TokenText == "+" || e.TokenText == "-")
                 && e.Parent.Name == "additiveExpression")) {
                return new[] { e.Parent };
            }
            return new CstNode[0];
        }
    }

    public class JavaScriptSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public override int MaxUp {
            get { return 1; }
        }

        public override int MaxLeft {
            get { return 0; }
        }

        public override int MaxRight {
            get { return 0; }
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

        public override int MaxUp {
            get { return 2; }
        }

        public override int MaxLeft {
            get { return 1; }
        }

        public override int MaxRight {
            get { return 0; }
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
                && e.Prev == e.Parent.Children().First(e2 => e2.TokenText == ";")) {
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
                p.Child("arguments").Child("assignmentExpression") == e) {
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

        public override int MaxUp {
            get { return 2; }
        }

        public override int MaxLeft {
            get { return 1; }
        }

        public override int MaxRight {
            get { return 0; }
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
                && e.Prev == e.Parent.Children().First(e2 => e2.TokenText == ";")) {
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
                p.Child("arguments").Child("assignmentExpression") == e) {
                return e.TokenText != "true";
            }
            return false;
        }
    }
}