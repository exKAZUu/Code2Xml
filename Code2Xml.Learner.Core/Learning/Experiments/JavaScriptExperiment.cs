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

        private static readonly LearningExperiment[] Experiments = {
            new JavaScriptComplexStatementExperiment(), // OK(40/50)
            new JavaScriptSuperComplexBranchExperiment(), // OK(40/50)
            new JavaScriptExpressionStatementExperiment(), // OK(40/50)
            new JavaScriptArithmeticOperatorExperiment(), // OK(40/50)
            new JavaScriptSwitchCaseExperiment(), // OK(40/50)
            new JavaScriptSuperComplexBranchExperimentWithSwitch(), // OK(40/50)
            new JavaScriptSuperComplexBranchExperimentWithSwitchWithoutTrue(), // OK(40/50)

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

        #region LearningSets

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

        #endregion

        private const string LangName = "JavaScript";

        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
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

        protected override string SearchPattern
        {
            get { return "*.js"; }
        }

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "seed.js"), };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "seed.js"), };
            Learn(seedPaths, exp, projectPath);
        }
    }

    public class JavaScriptSuperComplexBranchExperiment : LearningExperiment {
        public JavaScriptSuperComplexBranchExperiment() : base("expression", "assignmentExpression") {}

        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(1, @"console.log(b)", "b"),
                    new SelectedFragment(3, @"for (; b;)", "b"),
                    new SelectedFragment(@"while (b) {", "b"),
                    new SelectedFragment(@"} while (b);", "b"),
                    new SelectedFragment(@"if (b) {", "b"),
                    new SelectedFragment(6, @"if (b) {", "b"),
                    new SelectedFragment(8, @"for (; a, b;)", "b"),
                    new SelectedFragment(@"while (a, b) {", "b"),
                    new SelectedFragment(@"} while (a, b)", "b"),
                    new SelectedFragment(@"if (a, b) {", "b"),
                    new SelectedFragment(11, @"if (a, b) {", "b"),
                    new SelectedFragment(13, @"for (; true;)", "b"),
                    new SelectedFragment(@"while (true) {", "b"),
                    new SelectedFragment(@"} while (true)", "b"),
                    new SelectedFragment(@"if (true) {", "b"),
                    new SelectedFragment(16, @"if (true) {", "b"),
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var parentName = node.Parent.SafeName();
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
                && node.Prev == node.Parent.Children().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            var p = node.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Child("arguments").Child("assignmentExpression") == node) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptComplexBranchExperiment : LearningExperiment {
        public JavaScriptComplexBranchExperiment() : base("expression") {}

        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(3, @"for (; b;)", "b"),
                    new SelectedFragment(@"while (b) {", "b"),
                    new SelectedFragment(@"} while (b);", "b"),
                    new SelectedFragment(@"if (b) {", "b"),
                    new SelectedFragment(6, @"if (b) {", "b"),
                    new SelectedFragment(8, @"for (; a, b;)", "b"),
                    new SelectedFragment(@"while (a, b) {", "b"),
                    new SelectedFragment(@"} while (a, b)", "b"),
                    new SelectedFragment(@"if (a, b) {", "b"),
                    new SelectedFragment(11, @"if (a, b) {", "b"),
                    new SelectedFragment(13, @"for (; true;)", "b"),
                    new SelectedFragment(@"while (true) {", "b"),
                    new SelectedFragment(@"} while (true)", "b"),
                    new SelectedFragment(@"if (true) {", "b"),
                    new SelectedFragment(16, @"if (true) {", "b"),
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var parentName = node.Parent.SafeName();
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
                && node.Prev == node.Parent.Children().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(1, @"console.log(b);"),
                    new SelectedFragment(3, @"for (; b;) { }"),
                    new SelectedFragment(3, @"{ }"),
                    new SelectedFragment(4, @"while (b) { }"),
                    new SelectedFragment(4, @"{ }"),
                    new SelectedFragment(5, @"do { } while (b);"),
                    new SelectedFragment(5, @"{ }"),
                    new SelectedFragment(6, @"if (b) { } else if (b) { } else { }"),
                    new SelectedFragment(6, @"{ }"),
                    new SelectedFragment(6, @"if (b) { } else { }"),
                    new SelectedFragment(6, @"{ }"),
                    new SelectedFragment(6, @"{ }"),
                    new SelectedFragment(8, @"for (; a, b;) { }"),
                    new SelectedFragment(8, @"{ }"),
                    new SelectedFragment(9, @"while (a, b) { }"),
                    new SelectedFragment(9, @"{ }"),
                    new SelectedFragment(10, @"do { } while (a, b);"),
                    new SelectedFragment(10, @"{ }"),
                    new SelectedFragment(11, @"if (a, b) { } else if (a, b) { } else { }"),
                    new SelectedFragment(11, @"{ }"),
                    new SelectedFragment(11, @"if (a, b) { } else { }"),
                    new SelectedFragment(11, @"{ }"),
                    new SelectedFragment(11, @"{ }"),
                    new SelectedFragment(13, @"for (; true;) { }"),
                    new SelectedFragment(13, @"{ }"),
                    new SelectedFragment(14, @"while (true) { }"),
                    new SelectedFragment(14, @"{ }"),
                    new SelectedFragment(15, @"do { } while (true);"),
                    new SelectedFragment(15, @"{ }"),
                    new SelectedFragment(16, @"if (true) { } else if (true) { } else { }"),
                    new SelectedFragment(16, @"{ }"),
                    new SelectedFragment(16, @"if (true) { } else { }"),
                    new SelectedFragment(16, @"{ }"),
                    new SelectedFragment(16, @"{ }"),
                    new SelectedFragment(18, @"{}"),
                    new SelectedFragment(19, @"{ i = 1; }"),
                    new SelectedFragment(19, @"i = 1;"),
                    new SelectedFragment(@";"),
                    new SelectedFragment(@"i = 1;"),
                    new SelectedFragment(@"T:
f(0 + 1 - 2 * 3 / 4 % 5);"),
                    new SelectedFragment(@"f(0 + 1 - 2 * 3 / 4 % 5);"),
                    new SelectedFragment(25, @"switch (b) {
	case 0:
		break;
	default:
		break;
}"),
                    new SelectedFragment(27, @"break;"),
                    new SelectedFragment(29, @"break;"),
                };
            }
        }

        public JavaScriptStatementExperiment() : base("statement") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return true;
        }
    }

    public class JavaScriptComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(1, @"console.log(b);"),
                    new SelectedFragment(3, @"for (; b;) { }"),
                    new SelectedFragment(4, @"while (b) { }"),
                    new SelectedFragment(5, @"do { } while (b);"),
                    new SelectedFragment(6, @"if (b) { } else if (b) { } else { }"),
                    new SelectedFragment(6, @"if (b) { } else { }"),
                    new SelectedFragment(8, @"for (; a, b;) { }"),
                    new SelectedFragment(9, @"while (a, b) { }"),
                    new SelectedFragment(10, @"do { } while (a, b);"),
                    new SelectedFragment(11, @"if (a, b) { } else if (a, b) { } else { }"),
                    new SelectedFragment(11, @"if (a, b) { } else { }"),
                    new SelectedFragment(13, @"for (; true;) { }"),
                    new SelectedFragment(14, @"while (true) { }"),
                    new SelectedFragment(15, @"do { } while (true);"),
                    new SelectedFragment(16, @"if (true) { } else if (true) { } else { }"),
                    new SelectedFragment(16, @"if (true) { } else { }"),
                    new SelectedFragment(19, @"i = 1;"),
                    new SelectedFragment(@"i = 1;"),
                    new SelectedFragment(@"f(0 + 1 - 2 * 3 / 4 % 5);"),
                    new SelectedFragment(25, @"switch (b) {
	case 0:
		break;
	default:
		break;
}"),
                    new SelectedFragment(27, @"break;"),
                    new SelectedFragment(29, @"break;"),
                };
            }
        }

        public override IEnumerable<SelectedFragment> RejectingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(3, @"{ }"),
                    new SelectedFragment(19, @"{ i = 1; }"),
                    new SelectedFragment(@";"),
                    new SelectedFragment(@"T:
f(0 + 1 - 2 * 3 / 4 % 5);"),
                };
            }
        }

        public JavaScriptComplexStatementExperiment() : base("statement") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.FirstChild.Name == "statementBlock") {
                return false;
            }
            if (node.FirstChild.Name == "labelledStatement") {
                return false;
            }
            if (node.FirstChild.Name == "emptyStatement") {
                return false;
            }
            return true;
        }
    }

    public class JavaScriptExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(1, @"console.log(b);"),
                    new SelectedFragment(19, @"i = 1;"),
                    new SelectedFragment(21, @"i = 1;"),
                    new SelectedFragment(23, @"f(0 + 1 - 2 * 3 / 4 % 5);"),                    
                };
            }
        }

        public JavaScriptExpressionStatementExperiment() : base("expressionStatement") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.Name == "statement") {
                node = node.FirstChild;
            }
            return node.Name == "expressionStatement";
        }
    }

    public class JavaScriptArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(23, @"0 + 1", @"+"),
                    new SelectedFragment(23, @"1 - 2", @"-"),
                    new SelectedFragment(23, @"2 * 3", @"*"),
                    new SelectedFragment(23, @"3 / 4", @"/"),
                };
            }
        }

        public JavaScriptArithmeticOperatorExperiment() : base("TOKENS") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return ((node.TokenText == "*" || node.TokenText == "/")
                    && node.Parent.Name == "multiplicativeExpression")
                   ||
                   ((node.TokenText == "+" || node.TokenText == "-")
                    && node.Parent.Name == "additiveExpression");
        }
    }

    public class JavaScriptSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(25, @"switch (b)", @"b"),
                    new SelectedFragment(26, @"case 0:"),
                    new SelectedFragment(28, @"default:"),
                };
            }
        }

        public JavaScriptSwitchCaseExperiment() : base("expression", "caseClause", "defaultClause") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.Parent.Name == "switchStatement") {
                return true;
            }
            return node.Name == "caseClause" || node.Name == "defaultClause";
        }
    }

    public class JavaScriptSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        public JavaScriptSuperComplexBranchExperimentWithSwitch()
                : base("expression", "assignmentExpression", "caseClause", "defaultClause") {}

        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(1, @"console.log(b)", "b"),
                    new SelectedFragment(3, @"for (; b;)", "b"),
                    new SelectedFragment(@"while (b) {", "b"),
                    new SelectedFragment(@"} while (b);", "b"),
                    new SelectedFragment(@"if (b) {", "b"),
                    new SelectedFragment(6, @"if (b) {", "b"),
                    new SelectedFragment(8, @"for (; a, b;)", "b"),
                    new SelectedFragment(@"while (a, b) {", "b"),
                    new SelectedFragment(@"} while (a, b)", "b"),
                    new SelectedFragment(@"if (a, b) {", "b"),
                    new SelectedFragment(11, @"if (a, b) {", "b"),
                    new SelectedFragment(13, @"for (; true;)", "b"),
                    new SelectedFragment(@"while (true) {", "b"),
                    new SelectedFragment(@"} while (true)", "b"),
                    new SelectedFragment(@"if (true) {", "b"),
                    new SelectedFragment(16, @"if (true) {", "b"),
                    new SelectedFragment(25, @"switch (b)", @"b"),
                    new SelectedFragment(26, @"case 0:"),
                    new SelectedFragment(28, @"default:"),
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var parentName = node.Parent.SafeName();
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
                && node.Prev == node.Parent.Children().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            if (parentName == "switchStatement") {
                return true;
            }
            if (node.Name == "caseClause" || node.Name == "defaultClause") {
                return true;
            }
            var p = node.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Child("arguments").Child("assignmentExpression") == node) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptSuperComplexBranchExperimentWithSwitchWithoutTrue : LearningExperiment {
        public JavaScriptSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("expression", "assignmentExpression", "caseClause", "defaultClause") {}

        protected override CstGenerator Generator
        {
            get { return JavaScriptExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(1, @"console.log(b)", "b"),
                    new SelectedFragment(3, @"for (; b;)", "b"),
                    new SelectedFragment(@"while (b) {", "b"),
                    new SelectedFragment(@"} while (b);", "b"),
                    new SelectedFragment(@"if (b) {", "b"),
                    new SelectedFragment(6, @"if (b) {", "b"),
                    new SelectedFragment(8, @"for (; a, b;)", "b"),
                    new SelectedFragment(@"while (a, b) {", "b"),
                    new SelectedFragment(@"} while (a, b)", "b"),
                    new SelectedFragment(@"if (a, b) {", "b"),
                    new SelectedFragment(11, @"if (a, b) {", "b"),
                    new SelectedFragment(25, @"switch (b)", @"b"),
                    new SelectedFragment(26, @"case 0:"),
                    new SelectedFragment(28, @"default:"),
                };
            }
        }

        public override IEnumerable<SelectedFragment> RejectingFragments
        {
            get
            {
                return new[] {
                    new SelectedFragment(13, @"for (; true;)", "b"),
                    new SelectedFragment(@"while (true) {", "b"),
                    new SelectedFragment(@"} while (true)", "b"),
                    new SelectedFragment(@"if (true) {", "b"),
                    new SelectedFragment(16, @"if (true) {", "b"),
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var parentName = node.Parent.SafeName();
            if (parentName == "ifStatement") {
                return node.TokenText != "true";
            }
            if (parentName == "whileStatement") {
                return node.TokenText != "true";
            }
            if (parentName == "doWhileStatement") {
                return node.TokenText != "true";
            }
            if (parentName == "forStatement"
                && node.Prev == node.Parent.Children().First(e2 => e2.TokenText == ";")) {
                return node.TokenText != "true";
            }
            if (parentName == "switchStatement") {
                return true;
            }
            if (node.Name == "caseClause" || node.Name == "defaultClause") {
                return true;
            }
            var p = node.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Child("arguments").Child("assignmentExpression") == node) {
                return node.TokenText != "true";
            }
            return false;
        }
    }
}