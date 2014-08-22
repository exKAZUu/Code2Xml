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
    public class PhpExperiment : Experiment {
        public static CstGenerator Generator = CstGenerators.PhpUsingAntlr3;
        private const string LangName = "Php";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new PhpComplexStatementExperiment(),
                    new PhpSuperComplexBranchExperiment(),
                    new PhpExpressionStatementExperiment(),
                    new PhpArithmeticOperatorExperiment(),
                    new PhpSwitchCaseExperiment(),
                    new PhpSuperComplexBranchExperimentWithSwitch(),
                    new PhpSuperComplexBranchExperimentWithSwitchWithoutTrue(),
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
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/domnikl/DesignPatternsPHP.git",
                            @"ed291cd959053366e9d9edba62d8633034f93b0b",
                            "c0162c1f46eaa3d67731599effc7227a022934f1"),
                    Tuple.Create(
                            @"https://github.com/facebook/facebook-php-sdk.git",
                            @"8a992afce97122556c4e42b0f1c1d60b9d49276d",
                            "674dfe04322e07b1c99891391c0ce35bb4862cc1"),
                    Tuple.Create(
                            @"https://github.com/Seldaek/monolog.git",
                            @"03000a7fcd4072bd7e1f99c8ce4328621c5773b9",
                            "908d7734e7182d7236145c39ee3d825a20037e7a"),
                    Tuple.Create(
                            @"https://github.com/leafo/lessphp.git",
                            @"b7cd5c79e82666bcd2dfadb304342311209fb527",
                            "c3a141863835402d610c3b4b9c860f600b4ae02d"),
                    Tuple.Create(
                            @"https://github.com/puphpet/puphpet.git",
                            @"e4012cbbe0fc3b200b4750bb79673a9f468c1b9e",
                            "a8a0e0451da6609b6e1799df038283a30c6a3146"),
                    Tuple.Create(
                            @"https://github.com/cboden/Ratchet.git",
                            @"67cedf0ce6b6c7fbb5e305e0667ac219e655d561",
                            "1f608f1d3a2e2af716e8f0d4928dd48e7f800897"),
                    Tuple.Create(
                            @"https://github.com/geocoder-php/Geocoder.git",
                            @"972eed79fb50b6752b5154d391201f2ec7a8e11a",
                            "976f9fe3b4029e4c3286d98b35346f347533afec"),
                    Tuple.Create(
                            @"https://github.com/filp/whoops.git",
                            @"230da4810fc7fff67bf92061dc64eff4d451b68d",
                            "588a9cce80cfeeaf0edb886a77dd9881831fcea1"),
                    Tuple.Create(
                            @"https://github.com/WebDevStudios/Custom-Metaboxes-and-Fields-for-WordPress.git",
                            @"c9402b287b6ffcfbc0eeab4109ece8f1a5d25848",
                            "873fa4bde231037fea1a7f01addf925e86747c17"),
                    Tuple.Create(
                            @"https://github.com/themeskult/wp-svbtle.git",
                            @"45736be0e55e688a1111afe7d0f53d2ede79cfdb",
                            "9ae03bc0501b93ec55d758b94f6b26a4331ede41"),
                    Tuple.Create(
                            @"https://github.com/wp-cli/wp-cli.git",
                            @"fd5a95f208bb0fa9422a03cf40091e1a7704e481",
                            "c8ea8cad0ed32cf9c298958de98ecd024be92b11"),
                    Tuple.Create(
                            @"https://github.com/umpirsky/country-list.git",
                            @"19c2fb49a7eda5347170f8f8d723f92701468f60",
                            "8d0636410b9943604e1844b4153f0baef58ec2b4"),
                    Tuple.Create(
                            @"https://github.com/nrk/predis.git",
                            @"83df2ef11c18ea490daf6a7a8789315f57f555a8",
                            "dd20e8557fdb9c7da01ff5dfa5cc9f44704da115"),
                    Tuple.Create(
                            @"https://github.com/j4mie/idiorm.git",
                            @"11e964157a6a2c6128a0546673ad5e99ac1a62cd",
                            "ac450407608d6dcd111c873d964228cd159c53a0"),
                    Tuple.Create(
                            @"https://github.com/rmccue/Requests.git",
                            @"81a917f6425a2194c89d74b12102614c3ed16b2e",
                            "936d80cb3f45127639d8f969ef34ef5f64094d08"),
                    Tuple.Create(
                            @"https://github.com/benedmunds/CodeIgniter-Ion-Auth.git",
                            @"e083881869045eeee9f96f957a65872b9977450f",
                            "493b8cea62ca5c0be0123d3f1ee1075fd5933201"),
                    Tuple.Create(
                            @"https://github.com/chriso/klein.php.git",
                            @"376fd62813eb2008f3644e206d03002a3250122a",
                            "afc871c242402b0b36a2c097be07efbfc17a0838"),
                    Tuple.Create(
                            @"https://github.com/padraic/mockery.git",
                            @"4eff32b268a0db52b9abe36725cb775658ad3f1f",
                            "69037c5f28a22a35077a9ac18de3af24724973e5"),
                    Tuple.Create(
                            @"https://github.com/thephpleague/flysystem.git",
                            @"387e012fa93878e3865ed8db1aa9daba8bf2f9c5",
                            "1b60885eb6b1affaddec69ef37cc353261e0f42f"),
                    Tuple.Create(
                            @"https://github.com/KnpLabs/Gaufrette.git",
                            @"c2b6af8eb6fc093409ee0753137817dce1673763",
                            "416666fc95b863dc89c92127e78504cd361fca32"),
                    Tuple.Create(
                            @"https://github.com/jquery/testswarm.git",
                            @"bd1877cd4e67fd9c40315b88c2c1d117c9cfbc5c",
                            "6e4019fd49ba012e1fcb453210e4902b0b9501c5"),
                    Tuple.Create(
                            @"https://github.com/murtaugh/HTML5-Reset-WordPress-Theme.git",
                            @"374166a449a39da3eb70e1079fec9be76d9144d7",
                            "5b13362f5fa346b84ff127668c44104c1df15be1"),
                    Tuple.Create(
                            @"https://github.com/Anahkiasen/rocketeer.git",
                            @"02e2eace2765d88754731d1c672bb14b0d2cf6ca",
                            "797312171c8cca535854b13032c7bc0f7b74ea2b"),
                    Tuple.Create(
                            @"https://github.com/kriswallsmith/Buzz.git",
                            @"a0f207ac4939978b604be9bec5d5b19baecd8165",
                            "407c035c35c655cf791f6557405b074154ccd35e"),
                    Tuple.Create(
                            @"https://github.com/FriendsOfSymfony/FOSRestBundle.git",
                            @"292891740390ec5bdddc95340dec3a2b3c687e0d",
                            "b1be201ac89112d8deccbf00faebe9de3d4c5824"),
                    Tuple.Create(
                            @"https://github.com/simplepie/simplepie.git",
                            @"5f00e77b5feb96605cbcea4dcfb555e87c2fed24",
                            "099cbab5e3dd9c04c19e520983625858d703348a"),
                    Tuple.Create(
                            @"https://github.com/amazonwebservices/aws-sdk-for-php.git",
                            @"aab09f6dac35e5e9a263fb7311bb4e71de95b0ba",
                            "85072db75c562b8d42fe205ab81ea61d75ce2a8c"),
                    Tuple.Create(
                            @"https://github.com/Block8/PHPCI.git",
                            @"102354190773f1b36bd7c0c762efd8ec7938f888",
                            "b3bc8110e8bf4549381471b0779ecbdfc23c7c6c"),
                    Tuple.Create(
                            @"https://github.com/fuel/core.git",
                            @"2fdd79e0d902d78c081e472b086f551336b4663e",
                            "ed7a99dcc72abc30a6585255b8af46c419435b71"),
                    Tuple.Create(
                            @"https://github.com/thephpleague/oauth2-server.git",
                            @"ba5f2840fb46e8b23ae437890bfaffe74392be8e",
                            "1b29c0f1a005e761195541ce1448e5f6b319e5de"),
                    Tuple.Create(
                            @"https://github.com/maximebf/php-debugbar.git",
                            @"f6da2ec2239a764032c197ebfe85c23faf694748",
                            "9c6d9bc245ca83327b1b640adf441e4cfe39e685"),
                    Tuple.Create(
                            @"https://github.com/brianhaveri/Underscore.php.git",
                            @"4c5c191bcf0bcb88a0a9bee9d47332ba44900a92",
                            "0e98826b9a885dc8fc3a656284e10ce9a178ac79"),
                    Tuple.Create(
                            @"https://github.com/scribu/wp-posts-to-posts.git",
                            @"4c524f337a8a4a5c407794d548e9171a46145e09",
                            "2f6c4cbadddf761a710df63e5146afcb39752bd0"),
                    Tuple.Create(
                            @"https://github.com/nelmio/NelmioApiDocBundle.git",
                            @"fd126c1a0101a7703489b2fd65c91526d2b75774",
                            "cbdddfebb539dca86db999dd8b6f64961321dfb8"),
                    Tuple.Create(
                            @"https://github.com/robmorgan/phinx.git",
                            @"048393f59708be2f8d5faff4c57ed6d9ba3017d5",
                            "1c9276ab1410ec7ba8c4643b291df71caa9f31e8"),
                    Tuple.Create(
                            @"https://github.com/sebastianbergmann/phploc.git",
                            @"eda0bfe29c804a317e8b013899ebc15b991d4e1a",
                            "c7155d0026a99d131a49d645ad78cfd206a7c2dd"),
                    Tuple.Create(
                            @"https://github.com/pda/pheanstalk.git",
                            @"56c44c947cf44a85c8d639209361da5f67b6fbff",
                            "1908a3ddbd14130730fd589af870b2e62b92dace"),
                    Tuple.Create(
                            @"https://github.com/ZF-Commons/ZfcUser.git",
                            @"8774d3d60d93b5e1c0d537ce6d5633c6f75960d1",
                            "6807a32478fadf4cde94557c46e7df9d7a069c82"),
                    Tuple.Create(
                            @"https://github.com/rilwis/meta-box.git",
                            @"f5f7209ec4b8050cf407eab8444ba673e30d625b",
                            "036e74be13cf131d29894736d10f9fe6e48c73b5"),
                    Tuple.Create(
                            @"https://github.com/videlalvaro/php-amqplib.git",
                            @"1ca6d49bec6b8d2a011e94726c63d6bfad04856b",
                            "ff0de691ee9b3238d0169885a7ab616901dad7b6"),
                    Tuple.Create(
                            @"https://github.com/vrana/notorm.git",
                            @"d7f320a3d8da0dbcb17187ad4b9c91a396f5d0c6",
                            "782f6f1a3894541c57289a192ed23a5ed2a97f4b"),
                    Tuple.Create(
                            @"https://github.com/nelmio/alice.git",
                            @"6178f891f5dac28d28bbdb2721a0611add8d3177",
                            "d160fe6a9c14e09426171b66a1609cf1b9647e3c"),
                    Tuple.Create(
                            @"https://github.com/technosophos/querypath.git",
                            @"5597edb17eba8b974f2d8a5e65e4cb8fa0fc95f6",
                            "625e26cebd9c552a4ab4cbfef6a364aa5ac5d8b7"),
                    Tuple.Create(
                            @"https://github.com/farinspace/wpalchemy.git",
                            @"060f0b8d1c28a8808e4b323cec5450253663200d",
                            "08114b9b84618b8d6a7973c87d42103208d0a3f7"),
                    Tuple.Create(
                            @"https://github.com/sebastianbergmann/php-code-coverage.git",
                            @"0f87633dd5e3d3336606903e5d8b65a61771e989",
                            "6f029b322f46f97580a757d1e95ac48bdd07f016"),
                    Tuple.Create(
                            @"https://github.com/KnpLabs/KnpMenuBundle.git",
                            @"e5700ed8cbd5c402d24d6dda118aa23400937288",
                            "f672622a97584b331d217719d52f3ff66b2f04d8"),
                    Tuple.Create(
                            @"https://github.com/fabpot/Twig-extensions.git",
                            @"502303198afc1ec0bcc061c6f3a0926f7eb685e3",
                            "ad80ac8ced9f127eb973cbfcb5509b6201248a51"),
                    Tuple.Create(
                            @"https://github.com/kherge/php-box.git",
                            @"c75ebd1ced2ea411c262557a76d66a842d78b648",
                            "47e45f94de7b81a0a66c163144aac9a8f4f207d2"),
                    Tuple.Create(
                            @"https://github.com/Lusitanian/PHPoAuthLib.git",
                            @"faeb011212d12d45f161a16a77ebe5f69db1a8c2",
                            "711a09d4b46ca10c9ab49c05f98ab74a8fca966c"),
                    Tuple.Create(
                            @"https://github.com/jadell/neo4jphp.git",
                            @"6ca33b202b403c4f564f6a2f3bacc9482597b203",
                            "11423e854b32fe1af14fb6852def4ae8358ea4f1"),
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

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, string sha1, string sha2) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.php"), };
            Test(seedPaths, "*.php", exp, projectPath);
        }
    }

    public class PhpComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        public PhpComplexBranchExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return true;
            }
            if (pName == "While") {
                return true;
            }
            if (pName == "Do") {
                return true;
            }
            if (e.SafeParent().Name == "commaList" && e.SafeParent().Next == null
                && e.SafeParent().SafeParent().Name == "forCondition") {
                return true;
            }
            return false;
        }
    }

    public class PhpSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        public PhpSuperComplexBranchExperiment() : base("expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return true;
            }
            if (pName == "While") {
                return true;
            }
            if (pName == "Do") {
                return true;
            }
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "forCondition"
                && !e.NextsFromSelf().Any()) {
                return true;
            }
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "simpleStatement"
                && e.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && e.Prev == null) {
                return true;
            }
            return false;
        }
    }

    public class PhpIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "forCondition"
                && !e.NextsFromSelf().Any()) {
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "simpleStatement"
                && e.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && e.Prev == null) {
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ラベルはループ文に付くため，ラベルの中身は除外
            if (e.FirstChild.Name == "UnquotedString") {
                return false;
            }
            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (e.Element("bracketedBlock") != null) {
                return false;
            }
            // 空文
            if (e.FirstChild.TokenText == ";") {
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return true;
        }

        public PhpStatementExperiment() : base("statement") {}
    }

    public class PhpBlockExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            if (e.Element("bracketedBlock") != null) {
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ラベルはループ文に付くため，ラベルの中身は除外
            if (e.FirstChild.Name == "UnquotedString") {
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // 空文
            if (e.FirstChild.TokenText == ";") {
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

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return true; }
        }

        public PhpExpressionStatementExperiment() : base("simpleStatement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.FirstChild.Name == "expression";
        }
    }

    public class PhpArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        public PhpArithmeticOperatorExperiment() : base("Plus", "Minus", "Asterisk", "Forwardslash") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return e.Parent.Name == "addition" ||
                   e.Parent.Name == "multiplication";
        }
    }

    public class PhpSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        public PhpSwitchCaseExperiment() : base("expression", "casestatement", "defaultcase") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
            if (pName == "Switch") {
                return true;
            }
            return e.Name == "casestatement" || e.Name == "defaultcase";
        }
    }

    public class PhpSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        public PhpSuperComplexBranchExperimentWithSwitch()
                : base("expression", "casestatement", "defaultcase") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
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
            if (e.Name == "casestatement" || e.Name == "defaultcase") {
                return true;
            }
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "forCondition"
                && !e.NextsFromSelf().Any()) {
                return true;
            }
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "simpleStatement"
                && e.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && e.Prev == null) {
                return true;
            }
            return false;
        }
    }

    public class PhpSuperComplexBranchExperimentWithSwitchWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return PhpExperiment.Generator; }
        }

        public override string GetToken(CstNode e) {
            return e.TokenText.ToLower();
        }

        public override bool IsInner {
            get { return false; }
        }

        public PhpSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("expression", "casestatement", "defaultcase") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.SafeParent().FirstChild.Name;
            if (pName == "If") {
                return e.TokenText.ToLower() != "true";
            }
            if (pName == "While") {
                return e.TokenText.ToLower() != "true";
            }
            if (pName == "Do") {
                return e.TokenText.ToLower() != "true";
            }
            if (pName == "Switch") {
                return true;
            }
            if (e.Name == "casestatement" || e.Name == "defaultcase") {
                return true;
            }
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "forCondition"
                && !e.NextsFromSelf().Any()) {
                return e.TokenText.ToLower() != "true";
            }
            if (e.SafeParent().Name == "commaList"
                && e.SafeParent().SafeParent().Name == "simpleStatement"
                && e.SafeParent().SafeParent().FirstChild.Name == "Echo"
                && e.Prev == null) {
                return e.TokenText.ToLower() != "true";
            }
            return false;
        }
    }
}