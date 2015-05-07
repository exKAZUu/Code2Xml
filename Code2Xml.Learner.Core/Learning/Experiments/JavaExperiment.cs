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
    public class JavaExperiment : Experiment {
        public static CstGenerator Generator = CstGenerators.JavaUsingAntlr3;
        private const string LangName = "Java";

        private static readonly LearningExperiment[] Experiments = {
            new JavaComplexStatementExperiment(), // OK(40/50)
            new JavaSuperComplexBranchExperiment(), // OK(40/50)
            new JavaExpressionStatementExperiment(), // OK(40/50)
            new JavaArithmeticOperatorExperiment(), // OK(40/50)
            new JavaSwitchCaseExperiment(), // OK(40/50)
            new JavaSuperComplexBranchExperimentWithSwitch(), // OK(40/50)
            new JavaSuperComplexBranchExperimentWithSwitchWithoutTrue() // OK(40/50)

            //new JavaComplexBranchExperiment(),
        };

        #region LearningSets

        private static readonly Tuple<string, string>[] LearningSets = {
            Tuple.Create(
                    @"https://github.com/elasticsearch/elasticsearch",
                    @"96e62b3c1b1ea22fa788fc14b7c9d1f4388dbc1c"),
            Tuple.Create(
                    @"https://github.com/nathanmarz/storm",
                    @"cdb116e942666973bc4eaa0df098d5bab82739e7"),
            Tuple.Create(
                    @"https://github.com/jfeinstein10/SlidingMenu",
                    @"4254feca3ece9397cd501921ee733f19ea0fdad8"),
            Tuple.Create(
                    @"https://github.com/JakeWharton/ActionBarSherlock",
                    @"4a79d536af872339899a90d6dc743aa57745474b"),
            Tuple.Create(
                    @"https://github.com/nostra13/Android-Universal-Image-Loader",
                    @"b3888a4f35d31a3e7b96c9f7a5665216c1946bb5"),
            Tuple.Create(
                    @"https://github.com/github/android",
                    @"fbfb63c6607d8077018c245d7508f0fedab65dbb"),
            Tuple.Create(
                    @"https://github.com/libgdx/libgdx",
                    @"806ba436b1805c3d56c22a3b25b7fd383bc44c40"),
            Tuple.Create(
                    @"https://github.com/google/iosched",
                    @"f2e87424ea7cc0c3f8022f984966091ea746a23e"),
            Tuple.Create(
                    @"https://github.com/loopj/android-async-http",
                    @"b954a3178751b5fcf051f4c0134774cc51ba5fcc"),
            Tuple.Create(
                    @"https://github.com/JakeWharton/Android-ViewPagerIndicator",
                    @"8cd549f23f3d20ff920e19a2345c54983f65e26b"),
            Tuple.Create(
                    @"https://github.com/spring-projects/spring-framework",
                    @"a3213f26a5ae0bc741b1d166545f39597acbbd12"),
            Tuple.Create(
                    @"https://github.com/chrisbanes/Android-PullToRefresh",
                    @"3bd8ef6869c3297bfe874d2f15c2ee53c3456e99"),
            Tuple.Create(
                    @"https://github.com/square/picasso",
                    @"2ce8847cfe05553d7f44baafa9a90db73caf4cc7"),
            Tuple.Create(
                    @"https://github.com/excilys/androidannotations",
                    @"45c041346847a02ccf56806111b25b93a05f26d4"),
            Tuple.Create(
                    @"https://github.com/netty/netty",
                    @"99376c43911bd36df7cd31a5966b2757128e7319"),
            Tuple.Create(
                    @"https://github.com/clojure/clojure",
                    @"be39843727bd0d4b022f3a3996d3c64ddefdd84d"),
            Tuple.Create(
                    @"https://github.com/ReactiveX/RxJava",
                    @"054959ee58c464470afc3911549e442995a48846"),
            Tuple.Create(
                    @"https://github.com/Bearded-Hen/Android-Bootstrap",
                    @"ffa647269c420810faa05a62cc0d14842401925d"),
            Tuple.Create(
                    @"https://github.com/square/retrofit",
                    @"96b93b57a45768b56641680e72964b55fd05e01c"),
            Tuple.Create(
                    @"https://github.com/eclipse/vert.x",
                    @"49775052e59e82d64bf06340ff2cfe2e66c19e1c"),
            Tuple.Create(
                    @"https://github.com/AndroidBootstrap/android-bootstrap",
                    @"332bd8896a9c7337b72f79237993072eca7a59d2"),
            Tuple.Create(
                    @"https://github.com/zxing/zxing",
                    @"b8bafbe5c95310ed81e42e51f4b86d9f6b427c92"),
            Tuple.Create(
                    @"https://github.com/facebook/facebook-android-sdk",
                    @"f94970f6d99623ed3f74bf6c2dcf1f37b39ecc3f"),
            Tuple.Create(
                    @"https://github.com/junit-team/junit",
                    @"26f9ebac45e0ff95c72d356b98b64eaf3de4f618"),
            Tuple.Create(
                    @"https://github.com/sparklemotion/nokogiri",
                    @"0af5a8e4bf244977643660894441a6c8431f5a46"),
            Tuple.Create(
                    @"https://github.com/WhisperSystems/TextSecure",
                    @"503d1ef452b794bd21d3f2fecd1dcde81e411453"),
            Tuple.Create(
                    @"https://github.com/google/physical-web",
                    @"7afe865ee012b51519cc3ebfd1fd62ea7ed41195"),
            Tuple.Create(
                    @"https://github.com/chrisbanes/ActionBar-PullToRefresh",
                    @"f347ef96c2643fecee7cbf671db05c0487666dff"),
            Tuple.Create(
                    @"https://github.com/facebook/presto",
                    @"94be5c57224855b50e662fa175a5bcf14e98a50f"),
            Tuple.Create(
                    @"https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition",
                    @"a26369b6d817cdeba0bf858247f02d1586166dfd"),
            Tuple.Create(
                    @"https://github.com/gabrielemariotti/cardslib",
                    @"1af847481e6dbcd2e1d0b0c9496c33d2c11f3b8d"),
            Tuple.Create(
                    @"https://github.com/etsy/AndroidStaggeredGrid",
                    @"d8ca7e6aafd600842c002afc76d17b5d3a2b9cfb"),
            Tuple.Create(
                    @"https://github.com/nhaarman/ListViewAnimations",
                    @"4aa6dd2253c6132b121497cd3e729962f411d0d3"),
            Tuple.Create(
                    @"https://github.com/dropwizard/metrics",
                    @"b077a56fddcd7c119597ff26bf255fe55505df80"),
            Tuple.Create(
                    @"https://github.com/square/okhttp",
                    @"59b11fbabf1ae35ab27e70ea890338c81a7dd3fa"),
            Tuple.Create(
                    @"https://github.com/square/dagger",
                    @"65573a5680e6e170b62aed573ec1672139e48fcf"),
            Tuple.Create(
                    @"https://github.com/dropwizard/dropwizard",
                    @"e03b81ecf3cd50240b534ef64606b52c3fa79c76"),
            Tuple.Create(
                    @"https://github.com/greenrobot/EventBus",
                    @"4cdd420d4ec26de6cedb444e7f6ec129d70b2b20"),
            Tuple.Create(
                    @"https://github.com/LMAX-Exchange/disruptor",
                    @"c4e244bdb14d9a5999b5059cecd007ce87f5e671"),
            Tuple.Create(
                    @"https://github.com/chrisbanes/PhotoView",
                    @"48427bff9bb1a408cfebf6697aa019c0788ded76"),
            Tuple.Create(
                    @"https://github.com/cyrilmottier/GreenDroid",
                    @"abd9769f677bb4a753f0bf1119f961187bdf7020"),
            Tuple.Create(
                    @"https://github.com/Netflix/Hystrix",
                    @"62ac93f94c7248c2a5bac596344bac0f332fdf7f"),
            Tuple.Create(
                    @"https://github.com/aporter/coursera-android",
                    @"f4a837c6cb7c6422c813b1bda00af7948df658f8"),
            Tuple.Create(
                    @"https://github.com/fernandezpablo85/scribe-java",
                    @"e47e494ce39f9b180352fc9b5fd73c8b3ccce7f8"),
            Tuple.Create(
                    @"https://github.com/nicolasgramlich/AndEngine",
                    @"720897f99d2c56ba357e8fe361454bd8d88c37ed"),
            Tuple.Create(
                    @"https://github.com/roboguice/roboguice",
                    @"d84517c2003fa0d5d56d0f469ce30804ac6316a9"),
            Tuple.Create(
                    @"https://github.com/astuetz/PagerSlidingTabStrip",
                    @"3f4738eca833faeca563d93cd77c8df763a45fb6"),
            Tuple.Create(
                    @"https://github.com/koush/ion",
                    @"f699946ecc7b45cf56889c2997adfb4553bd8c99"),
            Tuple.Create(
                    @"https://github.com/OpenRefine/OpenRefine",
                    @"a58426332bf04c4c10d1ba2d4d65d932de665dfb"),
            Tuple.Create(
                    @"https://github.com/Prototik/HoloEverywhere",
                    @"b870abb5ab009a5a6dbab3fb855ec2854e35e125"),
            Tuple.Create(
                    @"https://github.com/thinkaurelius/titan",
                    @"1fc9959967a2a34255afa2408e8e6335f0544821"),
            //Tuple.Create(
            //        @"https://github.com/android/platform_frameworks_base",
            //        @"ced7ebdb1d522b4206e2048b278554ca841aeaba"),
            Tuple.Create(
                    @"https://github.com/47deg/android-swipelistview",
                    @"eb5a84c41d2131c5e858d5185001ea1e861afe7f"),
            Tuple.Create(
                    @"https://github.com/Netflix/SimianArmy",
                    @"011d467e280bbd2e312ac81ac69dfb0d02df918d"),
            Tuple.Create(
                    @"https://github.com/SimonVT/android-menudrawer",
                    @"59e8d18e109c77d911b8b63232d66d5f0551cf6a"),
            Tuple.Create(
                    @"https://github.com/JakeWharton/butterknife",
                    @"3dcd577810a623d15327a07a589a232a9e8dc355"),
            Tuple.Create(
                    @"https://github.com/johannilsson/android-pulltorefresh",
                    @"ccd0c71a4b291a5ad4673081dfbb72877fb3b346"),
            Tuple.Create(
                    @"https://github.com/emilsjolander/StickyListHeaders",
                    @"80e71051d1f54e1db0d20a4a756618caa91b385f"),
            Tuple.Create(
                    @"https://github.com/keyboardsurfer/Crouton",
                    @"fbc3df3902a2ef4615bf36042c9199d7e6ef3458"),
            Tuple.Create(
                    @"https://github.com/umano/AndroidSlidingUpPanel",
                    @"935c4fae0fb9cb03f3f86bc1539076eea6e32195"),
            Tuple.Create(
                    @"https://github.com/Atmosphere/atmosphere",
                    @"b25abd6090bcfca71d7123f1ec2c9379c654fdd1"),
            Tuple.Create(
                    @"https://github.com/stephanenicolas/robospice",
                    @"211949a3806215cd9828744dd6da71c49b6fa32f"),
            Tuple.Create(
                    @"https://github.com/square/otto",
                    @"7f32e50b9dd9846e4acc0c39611360509809740c"),
            Tuple.Create(
                    @"https://github.com/springside/springside4",
                    @"429cdcee61367131d99d711305c7c22597bc5652"),
            Tuple.Create(
                    @"https://github.com/bauerca/drag-sort-listview",
                    @"c3cfccee21676149dfdf8e803c0ec2eaebc6b841"),
            Tuple.Create(
                    @"https://github.com/gradle/gradle",
                    @"c7374fad4d499ec828ef3dc9750b42d3b95f429e"),
            Tuple.Create(
                    @"https://github.com/JakeWharton/NineOldAndroids",
                    @"9f20fd77e04942fd50b95aeb1c492a38e36c06dd"),
            Tuple.Create(
                    @"https://github.com/amlcurran/ShowcaseView",
                    @"0fe55b8eeedba01cf0864171de71fad0541bc70d"),
            Tuple.Create(
                    @"https://github.com/xetorthio/jedis",
                    @"f7995a7771ff20c2abce5591bad7781a97630b2c"),
            Tuple.Create(
                    @"https://github.com/daimajia/AndroidSwipeLayout",
                    @"1c4dfcc9854ca34f9f8ca513a9d47c58be25ad59"),
            Tuple.Create(
                    @"https://github.com/koush/AndroidAsync",
                    @"198751982785b9fb75e352d9585ea4eb2a1d251f"),
            Tuple.Create(
                    @"https://github.com/apache/cassandra",
                    @"7e7cb6e375534bdfdf18f07f85acd06de7191185"),
            Tuple.Create(
                    @"https://github.com/pardom/ActiveAndroid",
                    @"08c6335cd7324c6e72da536b0c6fffa5a798f6a2"),
            Tuple.Create(
                    @"https://github.com/ManuelPeinado/FadingActionBar",
                    @"1c148b91867259ea43e6343d8afb69d106168b46"),
            Tuple.Create(
                    @"https://github.com/jeresig/processing-js",
                    @"02363398a823eae731cafa180a5581fe353397bf"),
            Tuple.Create(
                    @"https://github.com/yui/yuicompressor",
                    @"f613d652cfac7487e335f3f8c60e0a51e9e17e1d"),
            Tuple.Create(
                    @"https://github.com/k9mail/k-9",
                    @"4aad31e05a81c92ea4b96cccc211ef83e0cb660a"),
            Tuple.Create(
                    @"https://github.com/greenrobot/greenDAO",
                    @"d49f1800a64504e693962c47d0f49cda46301685"),
            Tuple.Create(
                    @"https://github.com/daimajia/AndroidViewAnimations",
                    @"8b41ec8cc1e2218b071790da0c2dd87707076f77"),
            Tuple.Create(
                    @"https://github.com/AsyncHttpClient/async-http-client",
                    @"77589fdaf6ec3be75afb46b70476d5d561a79a6c"),
            Tuple.Create(
                    @"https://github.com/Bukkit/Bukkit",
                    @"f210234e59275330f83b994e199c76f6abd41ee7"),
            Tuple.Create(
                    @"https://github.com/Comcast/FreeFlow",
                    @"b6c240fcfbcd5bd97e2ec9a3f06271890446b6c1"),
            Tuple.Create(
                    @"https://github.com/perwendel/spark",
                    @"ffe3b1169d49af12b10b2dbff9ee913501ffc8a8"),
            Tuple.Create(
                    @"https://github.com/castorflex/SmoothProgressBar",
                    @"aeca86b0eb5ecb1e1e360e6a47222bafccb85726"),
            Tuple.Create(
                    @"https://github.com/commonsguy/cw-omnibus",
                    @"e0e0e4a0835540065e39e48a63ae3abe2b29b38b"),
            Tuple.Create(
                    @"https://github.com/ACRA/acra",
                    @"2f170732c38f078c941283188a23b52291814410"),
            Tuple.Create(
                    @"https://github.com/androidquery/androidquery",
                    @"45ed6c85dcf0b3b58a08810b423886fb275b33b0"),
            Tuple.Create(
                    @"https://github.com/openaphid/android-flip",
                    @"ab2dea1b045ffc626221c2826ce9dd00823e696d"),
            Tuple.Create(
                    @"https://github.com/jhy/jsoup",
                    @"83ad1bc40f08cbdd2994695058580972e7499381"),
            Tuple.Create(
                    @"https://github.com/pakerfeldt/android-viewflow",
                    @"3da74fa32a935bcbb37e5ebeb270477cde1985d4"),
            //Tuple.Create(
            //        @"https://github.com/JetBrains/intellij-community",
            //        @"a2595d6960aaf06e853acf2b1dcf4939d7d7186d"),
            Tuple.Create(
                    @"https://github.com/square/android-times-square",
                    @"bd78e97a4ba1a9a4b6806b737e203bdb7981d648"),
            //Tuple.Create(
            //        @"https://github.com/processing/processing",
            //        @"3d4bf5cbd24dadb501d0e6ab742435e31402cba5"),
            Tuple.Create(
                    @"https://github.com/yinwang0/pysonar2",
                    @"efbd4d3de10d6141bab2d4d78d6ae8abd1884734"),
            Tuple.Create(
                    @"https://github.com/dmytrodanylyk/circular-progress-button",
                    @"97f31ec128d1ba1435c0ccd4b5f2881e7892a4c9"),
            Tuple.Create(
                    @"https://github.com/facebook/rebound",
                    @"5bdf98d98ad51be23a8bce1a986715a891025b4c"),
            //Tuple.Create(
            //        @"https://github.com/voldemort/voldemort",
            //        @"f52dceddf7c56e0f8455260cdc01b4033818f7e5"),
            Tuple.Create(
                    @"https://github.com/videlalvaro/gifsockets",
                    @"0ccb1fd01edeb835a90c0c1140ad91dbd1a354b1"),
            Tuple.Create(
                    @"https://github.com/yangfuhai/afinal",
                    @"eef7702b19d46ae9fc14af6ad209287f220eb6ab"),
            Tuple.Create(
                    @"https://github.com/johannilsson/android-actionbar",
                    @"47157b28766b540d166073f26c43ed5a2c14bfb3")
        };

        #endregion

        protected override string SearchPattern {
            get { return "*.java"; }
        }

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

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.java") };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.java") };
            Learn(seedPaths, exp, projectPath);
        }

        public void CalculateMetrics(LearningExperiment exp, string projectPath, int starCount) {
            if (!(exp is JavaSuperComplexBranchExperiment)) {
                return;
            }
            var allPaths =
                    Directory.GetFiles(projectPath, SearchPattern, SearchOption.AllDirectories)
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
            var writer = Writers[exp.GetType().Name];
            writer.Write(statementCount + ",");
            writer.Write(branchCount + ",");
            writer.WriteLine();
            writer.Flush();
        }
    }

    public class JavaSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(7, "checkArgument(b)", "b"),
                    new SelectedFragment(14, "for (; b;)", "b"),
                    new SelectedFragment(15, "while (b)", "b"),
                    new SelectedFragment(16, "while (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(27, "checkArgument(true)", "true"),
                    new SelectedFragment(29, "for (; true;)", "true"),
                    new SelectedFragment(30, "while (true)", "true"),
                    new SelectedFragment(31, "while (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true")
                };
            }
        }

        public JavaSuperComplexBranchExperiment() : base("expression") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var p = node.Parent;
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
                && p.Children().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            {
                var primary = node.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                //if (primary.Elements().All(e2 => e2.TokenText() != "Preconditions")) {
                //	return false;
                //}
                if (primary.Children().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                //if (primary.NthElementOrDefault(0).SafeTokenText() != "Preconditions") {
                //	return false;
                //}
                //if (primary.NthElementOrDefault(2).SafeTokenText() != "checkArgument") {
                //	return false;
                //}
                if (node.PrevsFromFirst().Any()) {
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
                   && p.Children().Count(e_ => e_.TokenText == ";") >= 2;
        }

        public bool IsCheckArgument(CstNode e) {
            // Preconditions.checkArgument(cond, msg);
            var primary = e.Parent.Parent.Parent.Parent;
            return primary.Name == "primary"
                   && primary.Children().Any(e2 => e2.TokenText == "checkArgument")
                   && !e.PrevsFromFirst().Any();
        }
    }

    public class JavaComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(14, "for (; b;)", "b"),
                    new SelectedFragment(15, "while (b)", "b"),
                    new SelectedFragment(16, "while (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(29, "for (; true;)", "true"),
                    new SelectedFragment(30, "while (true)", "true"),
                    new SelectedFragment(31, "while (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true")
                };
            }
        }

        public JavaComplexBranchExperiment() : base("expression") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var p = node.Parent;
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
                && p.Children().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            return false;
        }
    }

    public class JavaComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(7, @"checkArgument(b);"),
                    new SelectedFragment(9, @"i = 0;"),
                    new SelectedFragment(11, @"i = 0;"),
                    new SelectedFragment(12, @"f(0 + 1 - 2 * 3 / 4 % 5);"),
                    new SelectedFragment(14, @"for (; b;) { }"),
                    new SelectedFragment(15, @"while (b) { }"),
                    new SelectedFragment(16, @"do { } while (b);"),
                    new SelectedFragment(17, @"if (b) { } else if (b) { } else { }"),
                    new SelectedFragment(17, @"if (b) { } else { }"),
                    new SelectedFragment(19, @"switch (b) {
			case 0:
			case 1:
				break;
			default:
				break;
		}"),
                    new SelectedFragment(22, @"break;"),
                    new SelectedFragment(24, @"break;"),
                    new SelectedFragment(27, @"checkArgument(true);"),
                    new SelectedFragment(29, @"for (; true;) { }"),
                    new SelectedFragment(30, @"while (true) { }"),
                    new SelectedFragment(31, @"do { } while (true);"),
                    new SelectedFragment(32, @"if (true) { } else if (true) { } else { }"),
                    new SelectedFragment(32, @"if (true) { } else { }")
                };
            }
        }

        public override IEnumerable<SelectedFragment> RejectingFragments {
            get {
                return new[] {
                    new SelectedFragment(9, @"L: i = 0;"),
                    new SelectedFragment(10, @";"),
                    new SelectedFragment(11, @"{ i = 0; }")
                };
            }
        }

        public JavaComplexStatementExperiment() : base("statement", "blockStatement") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            // blockStatement 
            //    :   localVariableDeclarationStatement
            //    |   classOrInterfaceDeclaration
            //    |   statement
            //    ;
            if (node.Name == "blockStatement") {
                if (node.FirstChild.Name != "statement") {
                    return true;
                }
                node = node.FirstChild;
            }

            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (node.FirstChild.Name == "block") {
                return false;
            }
            // ラベルを持つステートメントを除外
            if (node.FirstChild.Name == "IDENTIFIER") {
                return false;
            }
            if (node.FirstChild.TokenText == ";") {
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
            return e.FirstChild.Name == "IDENTIFIER";
        }
    }

    public class JavaExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(7, @"checkArgument(b);"),
                    new SelectedFragment(9, @"i = 0;"),
                    new SelectedFragment(11, @"i = 0;"),
                    new SelectedFragment(12, @"f(0 + 1 - 2 * 3 / 4 % 5);"),
                    new SelectedFragment(27, @"checkArgument(true);")
                };
            }
        }

        public JavaExpressionStatementExperiment() : base("statement") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return node.FirstChild.Name == "expression";
        }
    }

    public class JavaArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(12, @"0 + 1", @"+"),
                    new SelectedFragment(12, @"1 - 2", @"-"),
                    new SelectedFragment(12, @"2 * 3", @"*"),
                    new SelectedFragment(12, @"3 / 4", @"/")
                };
            }
        }

        public JavaArithmeticOperatorExperiment() : base("PLUS", "SUB", "STAR", "SLASH") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return ((node.TokenText == "+" || node.TokenText == "-")
                    && node.Parent.Name == "additiveExpression") ||
                   ((node.TokenText == "*" || node.TokenText == "/")
                    && node.Parent.Name == "multiplicativeExpression");
        }
    }

    public class JavaSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(19, @"switch (b)", @"b"),
                    new SelectedFragment(20, @"case 0:"),
                    new SelectedFragment(21, @"case 1:"),
                    new SelectedFragment(23, @"default:")
                };
            }
        }

        public JavaSwitchCaseExperiment() : base("expression", "switchLabel") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var p = node.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            return node.Name == "switchLabel";
        }
    }

    public class JavaSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaExperiment.Generator; }
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(7, "checkArgument(b)", "b"),
                    new SelectedFragment(14, "for (; b;)", "b"),
                    new SelectedFragment(15, "while (b)", "b"),
                    new SelectedFragment(16, "while (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(19, @"switch (b)", @"b"),
                    new SelectedFragment(20, @"case 0:"),
                    new SelectedFragment(21, @"case 1:"),
                    new SelectedFragment(23, @"default:"),
                    new SelectedFragment(27, "checkArgument(true)", "true"),
                    new SelectedFragment(29, "for (; true;)", "true"),
                    new SelectedFragment(30, "while (true)", "true"),
                    new SelectedFragment(31, "while (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true")
                };
            }
        }

        public JavaSuperComplexBranchExperimentWithSwitch() : base("expression", "switchLabel") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var p = node.Parent;
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
                && p.Children().Count(e2 => e2.TokenText == ";") >= 2) {
                return true;
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            if (node.Name == "switchLabel") {
                return true;
            }
            {
                var primary = node.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                if (primary.Children().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                if (node.PrevsFromFirst().Any()) {
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

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(7, "checkArgument(b)", "b"),
                    new SelectedFragment(14, "for (; b;)", "b"),
                    new SelectedFragment(15, "while (b)", "b"),
                    new SelectedFragment(16, "while (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(17, "if (b)", "b"),
                    new SelectedFragment(19, @"switch (b)", @"b"),
                    new SelectedFragment(20, @"case 0:"),
                    new SelectedFragment(21, @"case 1:"),
                    new SelectedFragment(23, @"default:")
                };
            }
        }

        public override IEnumerable<SelectedFragment> RejectingFragments {
            get {
                return new[] {
                    new SelectedFragment(27, "checkArgument(true)", "true"),
                    new SelectedFragment(29, "for (; true;)", "true"),
                    new SelectedFragment(30, "while (true)", "true"),
                    new SelectedFragment(31, "while (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true"),
                    new SelectedFragment(32, "if (true)", "true")
                };
            }
        }

        public JavaSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("expression", "switchLabel") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var p = node.Parent;
            var pp = p.Parent;
            var isPar = p.SafeName() == "parExpression";
            var isStmt = pp.SafeName() == "statement";
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
                return node.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
                return node.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
                return node.TokenText != "true";
            }
            if (p.SafeName() == "forstatement"
                && p.Children().Count(e2 => e2.TokenText == ";") >= 2) {
                return node.TokenText != "true";
            }
            if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
                return true;
            }
            if (node.Name == "switchLabel") {
                return true;
            }
            {
                var primary = node.SafeParent().SafeParent().SafeParent().SafeParent();
                if (primary.SafeName() != "primary") {
                    return false;
                }
                if (primary.Children().All(e2 => e2.TokenText != "checkArgument")) {
                    return false;
                }
                if (node.PrevsFromFirst().Any()) {
                    return false;
                }
                return node.TokenText != "true";
            }
        }
    }
}