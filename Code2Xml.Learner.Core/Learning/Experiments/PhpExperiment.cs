﻿#region License

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
    public class PhpExperiment : Experiment {
        public static CstGenerator Generator = CstGenerators.PhpUsingAntlr3;
        private const string LangName = "Php";

        private static readonly LearningExperiment[] Experiments = {
            new PhpComplexStatementExperiment(),
            new PhpSuperComplexBranchExperiment(),
            new PhpExpressionStatementExperiment(),
            new PhpArithmeticOperatorExperiment(),
            new PhpSwitchCaseExperiment(),
            new PhpSuperComplexBranchExperimentWithSwitch(),
            new PhpSuperComplexBranchExperimentWithSwitchWithoutTrue()

            //new PhpComplexBranchExperiment(),
            //new PhpIfExperiment(),
            //new PhpWhileExperiment(),
            //new PhpDoWhileExperiment(),
            //new PhpForExperiment(),
            //new PhpEchoExperiment(),
            //new PhpStatementExperiment(),
            //new PhpBlockExperiment(),
            //new PhpLabeledStatementExperiment(),
            //new PhpEmptyStatementExperiment(),
        };

        #region LearningSets

        private static readonly Tuple<string, string>[] LearningSets = {
            Tuple.Create(
                    @"https://github.com/domnikl/DesignPatternsPHP.git",
                    @"ed291cd959053366e9d9edba62d8633034f93b0b"),
            Tuple.Create(
                    @"https://github.com/facebook/facebook-php-sdk.git",
                    @"8a992afce97122556c4e42b0f1c1d60b9d49276d"),
            Tuple.Create(
                    @"https://github.com/Seldaek/monolog.git",
                    @"03000a7fcd4072bd7e1f99c8ce4328621c5773b9"),
            Tuple.Create(
                    @"https://github.com/leafo/lessphp.git",
                    @"b7cd5c79e82666bcd2dfadb304342311209fb527"),
            Tuple.Create(
                    @"https://github.com/puphpet/puphpet.git",
                    @"e4012cbbe0fc3b200b4750bb79673a9f468c1b9e"),
            Tuple.Create(
                    @"https://github.com/cboden/Ratchet.git",
                    @"67cedf0ce6b6c7fbb5e305e0667ac219e655d561"),
            Tuple.Create(
                    @"https://github.com/geocoder-php/Geocoder.git",
                    @"972eed79fb50b6752b5154d391201f2ec7a8e11a"),
            Tuple.Create(
                    @"https://github.com/filp/whoops.git",
                    @"230da4810fc7fff67bf92061dc64eff4d451b68d"),
            Tuple.Create(
                    @"https://github.com/WebDevStudios/Custom-Metaboxes-and-Fields-for-WordPress.git",
                    @"c9402b287b6ffcfbc0eeab4109ece8f1a5d25848"),
            Tuple.Create(
                    @"https://github.com/themeskult/wp-svbtle.git",
                    @"45736be0e55e688a1111afe7d0f53d2ede79cfdb"),
            Tuple.Create(
                    @"https://github.com/wp-cli/wp-cli.git",
                    @"fd5a95f208bb0fa9422a03cf40091e1a7704e481"),
            Tuple.Create(
                    @"https://github.com/umpirsky/country-list.git",
                    @"19c2fb49a7eda5347170f8f8d723f92701468f60"),
            Tuple.Create(
                    @"https://github.com/nrk/predis.git",
                    @"83df2ef11c18ea490daf6a7a8789315f57f555a8"),
            Tuple.Create(
                    @"https://github.com/j4mie/idiorm.git",
                    @"11e964157a6a2c6128a0546673ad5e99ac1a62cd"),
            Tuple.Create(
                    @"https://github.com/rmccue/Requests.git",
                    @"81a917f6425a2194c89d74b12102614c3ed16b2e"),
            Tuple.Create(
                    @"https://github.com/benedmunds/CodeIgniter-Ion-Auth.git",
                    @"e083881869045eeee9f96f957a65872b9977450f"),
            Tuple.Create(
                    @"https://github.com/chriso/klein.php.git",
                    @"376fd62813eb2008f3644e206d03002a3250122a"),
            Tuple.Create(
                    @"https://github.com/padraic/mockery.git",
                    @"4eff32b268a0db52b9abe36725cb775658ad3f1f"),
            Tuple.Create(
                    @"https://github.com/thephpleague/flysystem.git",
                    @"387e012fa93878e3865ed8db1aa9daba8bf2f9c5"),
            Tuple.Create(
                    @"https://github.com/KnpLabs/Gaufrette.git",
                    @"c2b6af8eb6fc093409ee0753137817dce1673763"),
            Tuple.Create(
                    @"https://github.com/jquery/testswarm.git",
                    @"bd1877cd4e67fd9c40315b88c2c1d117c9cfbc5c"),
            Tuple.Create(
                    @"https://github.com/murtaugh/HTML5-Reset-WordPress-Theme.git",
                    @"374166a449a39da3eb70e1079fec9be76d9144d7"),
            Tuple.Create(
                    @"https://github.com/Anahkiasen/rocketeer.git",
                    @"02e2eace2765d88754731d1c672bb14b0d2cf6ca"),
            Tuple.Create(
                    @"https://github.com/kriswallsmith/Buzz.git",
                    @"a0f207ac4939978b604be9bec5d5b19baecd8165"),
            Tuple.Create(
                    @"https://github.com/FriendsOfSymfony/FOSRestBundle.git",
                    @"292891740390ec5bdddc95340dec3a2b3c687e0d"),
            Tuple.Create(
                    @"https://github.com/simplepie/simplepie.git",
                    @"5f00e77b5feb96605cbcea4dcfb555e87c2fed24"),
            Tuple.Create(
                    @"https://github.com/amazonwebservices/aws-sdk-for-php.git",
                    @"aab09f6dac35e5e9a263fb7311bb4e71de95b0ba"),
            Tuple.Create(
                    @"https://github.com/Block8/PHPCI.git",
                    @"102354190773f1b36bd7c0c762efd8ec7938f888"),
            Tuple.Create(
                    @"https://github.com/fuel/core.git",
                    @"2fdd79e0d902d78c081e472b086f551336b4663e"),
            Tuple.Create(
                    @"https://github.com/thephpleague/oauth2-server.git",
                    @"ba5f2840fb46e8b23ae437890bfaffe74392be8e"),
            Tuple.Create(
                    @"https://github.com/maximebf/php-debugbar.git",
                    @"f6da2ec2239a764032c197ebfe85c23faf694748"),
            Tuple.Create(
                    @"https://github.com/brianhaveri/Underscore.php.git",
                    @"4c5c191bcf0bcb88a0a9bee9d47332ba44900a92"),
            Tuple.Create(
                    @"https://github.com/scribu/wp-posts-to-posts.git",
                    @"4c524f337a8a4a5c407794d548e9171a46145e09"),
            Tuple.Create(
                    @"https://github.com/nelmio/NelmioApiDocBundle.git",
                    @"fd126c1a0101a7703489b2fd65c91526d2b75774"),
            Tuple.Create(
                    @"https://github.com/robmorgan/phinx.git",
                    @"048393f59708be2f8d5faff4c57ed6d9ba3017d5"),
            Tuple.Create(
                    @"https://github.com/sebastianbergmann/phploc.git",
                    @"eda0bfe29c804a317e8b013899ebc15b991d4e1a"),
            Tuple.Create(
                    @"https://github.com/pda/pheanstalk.git",
                    @"56c44c947cf44a85c8d639209361da5f67b6fbff"),
            Tuple.Create(
                    @"https://github.com/ZF-Commons/ZfcUser.git",
                    @"8774d3d60d93b5e1c0d537ce6d5633c6f75960d1"),
            Tuple.Create(
                    @"https://github.com/rilwis/meta-box.git",
                    @"f5f7209ec4b8050cf407eab8444ba673e30d625b"),
            Tuple.Create(
                    @"https://github.com/videlalvaro/php-amqplib.git",
                    @"1ca6d49bec6b8d2a011e94726c63d6bfad04856b"),
            Tuple.Create(
                    @"https://github.com/vrana/notorm.git",
                    @"d7f320a3d8da0dbcb17187ad4b9c91a396f5d0c6"),
            Tuple.Create(
                    @"https://github.com/nelmio/alice.git",
                    @"6178f891f5dac28d28bbdb2721a0611add8d3177"),
            Tuple.Create(
                    @"https://github.com/technosophos/querypath.git",
                    @"5597edb17eba8b974f2d8a5e65e4cb8fa0fc95f6"),
            Tuple.Create(
                    @"https://github.com/farinspace/wpalchemy.git",
                    @"060f0b8d1c28a8808e4b323cec5450253663200d"),
            Tuple.Create(
                    @"https://github.com/sebastianbergmann/php-code-coverage.git",
                    @"0f87633dd5e3d3336606903e5d8b65a61771e989"),
            Tuple.Create(
                    @"https://github.com/KnpLabs/KnpMenuBundle.git",
                    @"e5700ed8cbd5c402d24d6dda118aa23400937288"),
            Tuple.Create(
                    @"https://github.com/fabpot/Twig-extensions.git",
                    @"502303198afc1ec0bcc061c6f3a0926f7eb685e3"),
            Tuple.Create(
                    @"https://github.com/kherge/php-box.git",
                    @"c75ebd1ced2ea411c262557a76d66a842d78b648"),
            Tuple.Create(
                    @"https://github.com/Lusitanian/PHPoAuthLib.git",
                    @"faeb011212d12d45f161a16a77ebe5f69db1a8c2"),
            Tuple.Create(
                    @"https://github.com/jadell/neo4jphp.git",
                    @"6ca33b202b403c4f564f6a2f3bacc9482597b203")
        };

        #endregion

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
            get { return "*.php"; }
        }

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.php") };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.php") };
            Learn(seedPaths, exp, projectPath);
        }
    }

    public class PhpComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public PhpComplexBranchExperiment() : base("expression") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return true;
            }
            if (pName == "While") {
                return true;
            }
            if (pName == "Do") {
                return true;
            }
            if (node.SafeParent().Name == "commaList" && node.SafeParent().Next == null
                && node.SafeParent().SafeParent().Name == "forCondition") {
                return true;
            }
            return false;
        }
    }

    public class PhpSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public PhpSuperComplexBranchExperiment() : base("expression") {}

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(2, @"echo """"", "\"\""),
                    new SelectedFragment(3, @"echo 1", "1"),
                    new SelectedFragment(4, @"echo 1, 2", "1, 2"),
                    new SelectedFragment(6, @"if ($b)", "$b"),
                    new SelectedFragment(6, @"elseif ($b)", "$b"),
                    new SelectedFragment(7, @"while ($b)", "$b"),
                    new SelectedFragment(8, @"while ($b)", "$b"),
                    new SelectedFragment(9, @"for (; $b;)", "$b"),
                    new SelectedFragment(22, @"if (true)", "true"),
                    new SelectedFragment(22, @"elseif (true)", "true"),
                    new SelectedFragment(23, @"while (true)", "true"),
                    new SelectedFragment(24, @"while (true)", "true"),
                    new SelectedFragment(25, @"for (; true;)", "true")
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return true;
            }
            if (pName == "While") {
                return true;
            }
            if (pName == "Do") {
                return true;
            }
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "forCondition"
                && !node.NextsFromSelf().Any()) {
                return true;
            }
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "simpleStatement"
                && node.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && node.Prev == null) {
                return true;
            }
            return false;
        }
    }

    public class PhpIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return true;
            }
            return false;
        }

        public PhpIfExperiment() : base("expression") {}
    }

    public class PhpWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "While") {
                return true;
            }
            return false;
        }

        public PhpWhileExperiment() : base("expression") {}
    }

    public class PhpDoWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "Do") {
                return true;
            }
            return false;
        }

        public PhpDoWhileExperiment() : base("expression") {}
    }

    public class PhpForExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "forCondition"
                && !node.NextsFromSelf().Any()) {
                return true;
            }
            return false;
        }

        public PhpForExperiment() : base("expression") {}
    }

    public class PhpEchoExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "simpleStatement"
                && node.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && node.Prev == null) {
                return true;
            }
            return false;
        }

        public PhpEchoExperiment() : base("expression") {}
    }

    public class PhpComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new PhpFeatureExtractor();
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(2, @"echo """";"),
                    new SelectedFragment(3, @"echo 1;"),
                    new SelectedFragment(4, @"echo 1, 2;"),
                    new SelectedFragment(6, @"if ($b) {} elseif ($b) {} else {}"),
                    new SelectedFragment(7, @"while ($b) { }"),
                    new SelectedFragment(8, @"do { } while ($b);"),
                    new SelectedFragment(9, @"for (; $b;) { }"),
                    new SelectedFragment(10, @"switch ($b) {
	case 0:
		break;
	default:
		break;
}"),
                    new SelectedFragment(12, @"break;"),
                    new SelectedFragment(14, @"break;"),
                    new SelectedFragment(19, @"$i = 0;"),
                    new SelectedFragment(20, @"f(0 + 1 - 2 * 3 / 4 % 5);"),
                    new SelectedFragment(22, @"if (true) {} elseif (true) {} else {}"),
                    new SelectedFragment(23, @"while (true) { }"),
                    new SelectedFragment(24, @"do { } while (true);"),
                    new SelectedFragment(25, @"for (; true;) { }")
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            // ラベルはループ文に付くため，ラベル文を除外
            if (node.FirstChild.Name == "UnquotedString") {
                return false;
            }
            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (node.Child("bracketedBlock") != null) {
                return false;
            }
            // 空文
            if (node.FirstChild.TokenText == ";") {
                return false;
            }
            return true;
        }

        public PhpComplexStatementExperiment() : base("statement") {}
    }

    public class PhpStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new PhpFeatureExtractor();
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return true;
        }

        public PhpStatementExperiment() : base("statement") {}
    }

    public class PhpBlockExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new PhpFeatureExtractor();
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (node.Child("bracketedBlock") != null) {
                return true;
            }
            return false;
        }

        public PhpBlockExperiment() : base("statement") {}
    }

    public class PhpLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new PhpFeatureExtractor();
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            // ラベルはループ文に付くため，ラベルの中身は除外
            if (node.FirstChild.Name == "UnquotedString") {
                return true;
            }
            return false;
        }

        public PhpLabeledStatementExperiment() : base("statement") {}
    }

    public class PhpEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new PhpFeatureExtractor();
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            // 空文
            if (node.FirstChild.TokenText == ";") {
                return true;
            }
            return false;
        }

        public PhpEmptyStatementExperiment() : base("statement") {}
    }

    public class PhpExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new PhpFeatureExtractor();
        }

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(19, @"$i = 0;"),
                    new SelectedFragment(20, @"f(0 + 1 - 2 * 3 / 4 % 5);")
                };
            }
        }

        public PhpExpressionStatementExperiment() : base("simpleStatement") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return node.FirstChild.Name == "expression";
        }
    }

    public class PhpArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public PhpArithmeticOperatorExperiment() : base("Plus", "Minus", "Asterisk", "Forwardslash") {}

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(20, @"0 + 1", @"+"),
                    new SelectedFragment(20, @"1 - 2", @"-"),
                    new SelectedFragment(20, @"2 * 3", @"*"),
                    new SelectedFragment(20, @"3 / 4", @"/")
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return node.Parent.Name == "addition" ||
                   node.Parent.Name == "multiplication";
        }
    }

    public class PhpSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public PhpSwitchCaseExperiment() : base("expression", "casestatement", "defaultcase") {}

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(10, @"switch ($b)", @"$b"),
                    new SelectedFragment(11, @"case 0:"),
                    new SelectedFragment(13, @"default:")
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "Switch") {
                return true;
            }
            return node.Name == "casestatement" || node.Name == "defaultcase";
        }
    }

    public class PhpSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public PhpSuperComplexBranchExperimentWithSwitch()
                : base("expression", "casestatement", "defaultcase") {}

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(2, @"echo """"", "\"\""),
                    new SelectedFragment(3, @"echo 1", "1"),
                    new SelectedFragment(4, @"echo 1, 2", "1, 2"),
                    new SelectedFragment(6, @"if ($b)", "$b"),
                    new SelectedFragment(6, @"elseif ($b)", "$b"),
                    new SelectedFragment(7, @"while ($b)", "$b"),
                    new SelectedFragment(8, @"while ($b)", "$b"),
                    new SelectedFragment(9, @"for (; $b;)", "$b"),
                    new SelectedFragment(10, @"switch ($b)", @"$b"),
                    new SelectedFragment(11, @"case 0:"),
                    new SelectedFragment(13, @"default:"),
                    new SelectedFragment(22, @"if (true)", "true"),
                    new SelectedFragment(22, @"elseif (true)", "true"),
                    new SelectedFragment(23, @"while (true)", "true"),
                    new SelectedFragment(24, @"while (true)", "true"),
                    new SelectedFragment(25, @"for (; true;)", "true")
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return true;
            }
            if (pName == "While") {
                return true;
            }
            if (pName == "Do") {
                return true;
            }
            if (pName == "Switch") {
                return true;
            }
            if (node.Name == "casestatement" || node.Name == "defaultcase") {
                return true;
            }
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "forCondition"
                && !node.NextsFromSelf().Any()) {
                return true;
            }
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "simpleStatement"
                && node.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && node.Prev == null) {
                return true;
            }
            return false;
        }
    }

    public class PhpSuperComplexBranchExperimentWithSwitchWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public PhpSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("expression", "casestatement", "defaultcase") {}

        public override IEnumerable<SelectedFragment> AcceptingFragments {
            get {
                return new[] {
                    new SelectedFragment(2, @"echo """"", "\"\""),
                    new SelectedFragment(3, @"echo 1", "1"),
                    new SelectedFragment(4, @"echo 1, 2", "1, 2"),
                    new SelectedFragment(6, @"if ($b)", "$b"),
                    new SelectedFragment(6, @"elseif ($b)", "$b"),
                    new SelectedFragment(7, @"while ($b)", "$b"),
                    new SelectedFragment(8, @"while ($b)", "$b"),
                    new SelectedFragment(9, @"for (; $b;)", "$b"),
                    new SelectedFragment(10, @"switch ($b)", @"$b"),
                    new SelectedFragment(11, @"case 0:"),
                    new SelectedFragment(13, @"default:")
                };
            }
        }

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            var pName = node.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return node.TokenText.ToLower() != "true";
            }
            if (pName == "While") {
                return node.TokenText.ToLower() != "true";
            }
            if (pName == "Do") {
                return node.TokenText.ToLower() != "true";
            }
            if (pName == "Switch") {
                return true;
            }
            if (node.Name == "casestatement" || node.Name == "defaultcase") {
                return true;
            }
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "forCondition"
                && !node.NextsFromSelf().Any()) {
                return node.TokenText.ToLower() != "true";
            }
            if (node.SafeParent().Name == "commaList"
                && node.SafeParent().SafeParent().Name == "simpleStatement"
                && node.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && node.Prev == null) {
                return node.TokenText.ToLower() != "true";
            }
            return false;
        }
    }
}