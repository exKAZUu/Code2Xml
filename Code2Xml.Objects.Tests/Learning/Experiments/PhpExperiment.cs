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
    public class PhpExperiment {
        private readonly StreamWriter _writer = File.CreateText(@"C:\Users\exKAZUu\Desktop\php.txt");

        public static CstGenerator Generator = CstGenerators.PhpUsingAntlr3;
        private const string LangName = "Php";

        //new MemoryCacheCstGenerator(new FileCacheCstGenerator(ProcessorLoader.PhpUsingAntlr3));

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
                            @"https://github.com/al3x/sovereign.git",
                            @"4349e03dfc4b53e75a78441ebd8ace93f8e4cd47", 2927),
                    Tuple.Create(
                            @"https://github.com/serbanghita/Mobile-Detect.git",
                            @"d70de7bfd0641d4d32a6f9c71e1f5d2839a5331e", 2862),
                    Tuple.Create(
                            @"https://github.com/abraham/twitteroauth.git",
                            @"4b775766fe3526ebc67ee20c97ff29a3b47bc5d8", 2304),
                    Tuple.Create(
                            @"https://github.com/subtlepatterns/SubtlePatterns.git",
                            @"6e056565a1254c967228aab60c9d9c7d0e63a7e3", 2271),
                    Tuple.Create(
                            @"https://github.com/leafo/lessphp.git",
                            @"b7cd5c79e82666bcd2dfadb304342311209fb527", 1929),
                    Tuple.Create(
                            @"https://github.com/puphpet/puphpet.git",
                            @"e4012cbbe0fc3b200b4750bb79673a9f468c1b9e", 1803),
                    Tuple.Create(
                            @"https://github.com/venomous0x/WhatsAPI.git",
                            @"5ad50b311d728752cee50b7c7ed00062df6cb740", 1613),
                    Tuple.Create(
                            @"https://github.com/PHPMailer/PHPMailer.git",
                            @"7b384d0bedf7feb1d3cdfaae689d8c5b68eb0515", 1600),
                    Tuple.Create(
                            @"https://github.com/fabpot/Goutte.git",
                            @"06a5451288ffddd204b10fa6c6f9ab2b86dd515d", 1584),
                    Tuple.Create(
                            @"https://github.com/tommcfarlin/WordPress-Plugin-Boilerplate.git",
                            @"db289e22840277c26911d46972fe516ce309e430", 1543),
                    Tuple.Create(
                            @"https://github.com/MattWilcox/Adaptive-Images.git",
                            @"faa87fd94fc59373df7c2e5bb605c7e3c28e38a4", 1454),
                    Tuple.Create(
                            @"https://github.com/kohana/kohana.git",
                            @"338bea96dfa197e7864674dab6cef78958e1f1df", 1365),
                    Tuple.Create(
                            @"https://github.com/WebDevStudios/Custom-Metaboxes-and-Fields-for-WordPress.git",
                            @"c9402b287b6ffcfbc0eeab4109ece8f1a5d25848", 1361),
                    Tuple.Create(
                            @"https://github.com/michelf/php-markdown.git",
                            @"6f952ee180e9bd345f3dd6005aa11e0f5dcbd1b8", 1347),
                    Tuple.Create(
                            @"https://github.com/fuel/fuel.git",
                            @"82f79d7d9be671fafcfd9ca405425501bf8d8634", 1313),
                    Tuple.Create(
                            @"https://github.com/umpirsky/country-list.git",
                            @"19c2fb49a7eda5347170f8f8d723f92701468f60", 1306),
                    Tuple.Create(
                            @"https://github.com/usmanhalalit/charisma.git",
                            @"5a8e4fdbefe694bf6a3a9c86e41acf9abf5c06cb", 1288),
                    Tuple.Create(
                            @"https://github.com/omnipay/omnipay.git",
                            @"aa1de2346b365527486b16f0f07ff190effe6d3e", 1204),
                    Tuple.Create(
                            @"https://github.com/j4mie/idiorm.git",
                            @"11e964157a6a2c6128a0546673ad5e99ac1a62cd", 1200),
                    Tuple.Create(
                            @"https://github.com/benedmunds/CodeIgniter-Ion-Auth.git",
                            @"e083881869045eeee9f96f957a65872b9977450f", 1184),
                    Tuple.Create(
                            @"https://github.com/JosephLenton/PHP-Error.git",
                            @"9918dd5eeec527846d43c92a4c9880bfcdd0de14", 1150),
                    Tuple.Create(
                            @"https://github.com/zendframework/ZendSkeletonApplication.git",
                            @"67cbbbf61897831ef1feda323be9845aa7d79682", 1110),
                    Tuple.Create(
                            @"https://github.com/pattern-lab/patternlab-php.git",
                            @"ff31431333113c553d2f299a49b783351229d026", 1077),
                    Tuple.Create(
                            @"https://github.com/facebook/xhprof.git",
                            @"e83d1792569ecbc5ef14c50a00eb37094d4e6ad9", 1036),
                    Tuple.Create(
                            @"https://github.com/KnpLabs/Gaufrette.git",
                            @"c2b6af8eb6fc093409ee0753137817dce1673763", 1027),
                    Tuple.Create(
                            @"https://github.com/symfony/symfony-standard.git",
                            @"50aeda221a0328dccae905b8dafed67f97983bcf", 1006),
                    Tuple.Create(
                            @"https://github.com/Circa75/dropplets.git",
                            @"feb2e82b21ef7a7da484e17628160f866c2da6c0", 997),
                    Tuple.Create(
                            @"https://github.com/panique/php-login.git",
                            @"350ffc9455617b24979535283258ea8a05b7cf33", 994),
                    Tuple.Create(
                            @"https://github.com/opauth/opauth.git",
                            @"3ff68e72c21a3691e5a87fc8c30e458edbb22990", 987),
                    Tuple.Create(
                            @"https://github.com/simplethemes/skeleton_wp.git",
                            @"55495c735bcb35f2e7752c6e62e29054bfc69892", 968),
                    Tuple.Create(
                            @"https://github.com/kriswallsmith/Buzz.git",
                            @"a0f207ac4939978b604be9bec5d5b19baecd8165", 862),
                    Tuple.Create(
                            @"https://github.com/interconnectit/Search-Replace-DB.git",
                            @"12c6732502958a0c57125f6b30741e6e0f05655c", 852),
                    Tuple.Create(
                            @"https://github.com/markjaquith/WP-Stack.git",
                            @"1a5714be857ffcd494ea56d9ff3619500815839e", 829),
                    Tuple.Create(
                            @"https://github.com/KnpLabs/snappy.git",
                            @"9d7bd2e806e68acf6216c8b7eca7ddd774d0aebf", 812),
                    Tuple.Create(
                            @"https://github.com/themattharris/tmhOAuth.git",
                            @"47dcee2ac74f8c032d2a1afb836e65108bf582b7", 785),
                    Tuple.Create(
                            @"https://github.com/anandkunal/ToroPHP.git",
                            @"09a1e01c6baf27d9fd70759f7739699fdf85218b", 784),
                    Tuple.Create(
                            @"https://github.com/fabpot/Pimple.git",
                            @"a9e94d9fd6cb9e8f097551a25ffec73ff2480a24", 770),
                    Tuple.Create(
                            @"https://github.com/masterexploder/PHPThumb.git",
                            @"69fe4dbef9c70915ee16652339395deadb1509cb", 762),
                    Tuple.Create(
                            @"https://github.com/Codiad/Codiad.git",
                            @"0faabeb14aabb1737a4671e9b71c0447ed20fc5b", 744),
                    Tuple.Create(
                            @"https://github.com/Herzult/SimplePHPEasyPlus.git",
                            @"e9b2d592a16a0bb72ac1f2d6483f2993427a4475", 743),
                    Tuple.Create(
                            @"https://github.com/Block8/PHPCI.git",
                            @"102354190773f1b36bd7c0c762efd8ec7938f888", 740),
                    Tuple.Create(
                            @"https://github.com/cakephp/debug_kit.git",
                            @"bbfb1d1993b195b14b2bf7b4c3f37e732ad76195", 738),
                    Tuple.Create(
                            @"https://github.com/VerbalExpressions/PHPVerbalExpressions.git",
                            @"f9d4e0b38605704b0e8e343375adca656b28c222", 737),
                    Tuple.Create(
                            @"https://github.com/ccampbell/chromephp.git",
                            @"c3c297615d48ae5b2a86a82311152d1ed095fcef", 730),
                    Tuple.Create(
                            @"https://github.com/barryvdh/laravel-ide-helper.git",
                            @"16f77638f159c75a93da97dd48904707618483a3", 730),
                    Tuple.Create(
                            @"https://github.com/lucb1e/cookielesscookies.git",
                            @"a23a2c8163d91063f08ca38e530b284839933d06", 729),
                    Tuple.Create(
                            @"https://github.com/erusev/parsedown.git",
                            @"c10bde01746867e2afbc715a6149f4e682f0263b", 714),
                    Tuple.Create(
                            @"https://github.com/maximebf/php-debugbar.git",
                            @"f6da2ec2239a764032c197ebfe85c23faf694748", 710),
                    Tuple.Create(
                            @"https://github.com/ruflin/Elastica.git",
                            @"be1729b04954da58bc1f5c97eb3bcfac12e61249", 653),
                    Tuple.Create(
                            @"https://github.com/Intervention/image.git",
                            @"517d9ba46735237b279ed97bafb79fc68f6ce350", 647),
                    Tuple.Create(
                            @"https://github.com/symfony-cmf/symfony-cmf.git",
                            @"0c9f93cbb2d6e1d94395db57f5cabe17f5631550", 622),
                    Tuple.Create(
                            @"https://github.com/twittem/wp-bootstrap-navwalker.git",
                            @"1e869edb03b04aff7792cf3327e94bb3dafac95b", 622),
                    Tuple.Create(
                            @"https://github.com/elliotcondon/acf.git",
                            @"772259933c0751e4325d16acbcbce415450bc054", 604),
                    Tuple.Create(
                            @"https://github.com/catfan/Medoo.git",
                            @"f9f6073cf52c68d5d5d4d1b9434f24ce3e42531c", 592),
                    Tuple.Create(
                            @"https://github.com/mikecao/flight.git",
                            @"b9b2d0fa2d75e6b2f606fbd0d9a8059a0f741578", 585),
                    Tuple.Create(
                            @"https://github.com/dodgepudding/wechat-php-sdk.git",
                            @"28105dcdf2a3cd8a4a482e61896ea614b9b0b657", 583),
                    Tuple.Create(
                            @"https://github.com/jamierumbelow/codeigniter-base-model.git",
                            @"2d03af0bd87f6a191f09a63612da9b035733f077", 576),
                    Tuple.Create(
                            @"https://github.com/laravelbook/ardent.git",
                            @"0a0238b8040abc1c71401ce27a8edf2619fa5bed", 557),
                    Tuple.Create(
                            @"https://github.com/J7mbo/twitter-api-php.git",
                            @"ab76f1c1e6bf83f0a257216cbaf9932b7cc19a3f", 557),
                    Tuple.Create(
                            @"https://github.com/jmathai/twitter-async.git",
                            @"a361018261b887a5f8fb823a05e0e0e688a5c040", 556),
                    Tuple.Create(
                            @"https://github.com/jmathai/epiphany.git",
                            @"0418fa96add6bbc3c1e3b2dd313a041be72f9717", 555),
                    Tuple.Create(
                            @"https://github.com/leemason/NHP-Theme-Options-Framework.git",
                            @"ed709af8fc4e96dc2c638fad949b00594cca8427", 553),
                    Tuple.Create(
                            @"https://github.com/NeonHorizon/berryio.git",
                            @"d0f4d61a9f6123ac2d6c279afc1fec67accb9a75", 549),
                    Tuple.Create(
                            @"https://github.com/WP-API/WP-API.git",
                            @"e8bb59da12aa0df512b9138e2b741abbc9b9c1b0", 543),
                    Tuple.Create(
                            @"https://github.com/BenTheDesigner/Dropbox.git",
                            @"94de100581fc103920786d38d4aa5433802d3842", 532),
                    Tuple.Create(
                            @"https://github.com/hwi/HWIOAuthBundle.git",
                            @"cb90e60c079bbf3aed8044cd71d5e03e32d60133", 531),
                    Tuple.Create(
                            @"https://github.com/danielstjules/Stringy.git",
                            @"8d961e25d09f946b463c0581e927a963f3578647", 529),
                    Tuple.Create(
                            @"https://github.com/Xeoncross/micromvc.git",
                            @"04779326fa0d5bbd672996a7bcac80150c9cd82f", 524),
                    Tuple.Create(
                            @"https://github.com/Behat/Mink.git",
                            @"055da154b9fcb0bb238332adda3c4b38210c85d3", 520),
                    Tuple.Create(
                            @"https://github.com/barryvdh/laravel-debugbar.git",
                            @"9c0c6de939141f43efdf9c3beed22db50e2a4248", 510),
                    Tuple.Create(
                            @"https://github.com/nelmio/NelmioApiDocBundle.git",
                            @"fd126c1a0101a7703489b2fd65c91526d2b75774", 499),
                    Tuple.Create(
                            @"https://github.com/eyecatchup/SEOstats.git",
                            @"d6f8dc189f12801bdc2b5fc9aa58a4f342c76681", 481),
                    Tuple.Create(
                            @"https://github.com/stof/StofDoctrineExtensionsBundle.git",
                            @"f1c7993863f83f22f187f11d2a8eb462b836701e", 477),
                    Tuple.Create(
                            @"https://github.com/sebastianbergmann/phpcpd.git",
                            @"a9462153f2dd90466a010179901d31fbff598365", 476),
                    Tuple.Create(
                            @"https://github.com/pda/pheanstalk.git",
                            @"56c44c947cf44a85c8d639209361da5f67b6fbff", 471),
                    Tuple.Create(
                            @"https://github.com/ErikDubbelboer/phpRedisAdmin.git",
                            @"f9b7820c76ed507267d853f11168425f340f9f4a", 467),
                    Tuple.Create(
                            @"https://github.com/fabpot/Sismo.git",
                            @"9732d3a1a370ab093e9e126f7ea0366ce64c7389", 462),
                    Tuple.Create(
                            @"https://github.com/ZF-Commons/ZfcUser.git",
                            @"8774d3d60d93b5e1c0d537ce6d5633c6f75960d1", 454),
                    Tuple.Create(
                            @"https://github.com/rilwis/meta-box.git",
                            @"f5f7209ec4b8050cf407eab8444ba673e30d625b", 454),
                    Tuple.Create(
                            @"https://github.com/videlalvaro/php-amqplib.git",
                            @"1ca6d49bec6b8d2a011e94726c63d6bfad04856b", 446),
                    Tuple.Create(
                            @"https://github.com/webtechnick/CakePHP-Facebook-Plugin.git",
                            @"d1b4ae95bb610ab60b51f0e64e0227d42ae84b69", 446),
                    Tuple.Create(
                            @"https://github.com/jkudish/WordPress-GitHub-Plugin-Updater.git",
                            @"6d0c856659de1f2f5083dc79a53018cdb973f3cd", 439),
                    Tuple.Create(
                            @"https://github.com/philsturgeon/codeigniter-restclient.git",
                            @"296de79b3249101bc0af6502f358da4b55a262d5", 436),
                    Tuple.Create(
                            @"https://github.com/nelmio/alice.git",
                            @"6178f891f5dac28d28bbdb2721a0611add8d3177", 435),
                    Tuple.Create(
                            @"https://github.com/codeguy/Upload.git",
                            @"508ba2ba50119b6ab99a551806ef6b7d43c16b5c", 434),
                    Tuple.Create(
                            @"https://github.com/Sybio/ImageWorkshop.git",
                            @"2b58bcde5205956e4b439cfaa86fb88113442d72", 418),
                    Tuple.Create(
                            @"https://github.com/FriendsOfSymfony/FOSJsRoutingBundle.git",
                            @"36629f5976f9f588093bf0bfb5230502fdb0eacf", 417),
                    Tuple.Create(
                            @"https://github.com/codeguy/Slim-Extras.git",
                            @"59300d25d62f2f299b4065ed99eb71ca91f8a434", 408),
                    Tuple.Create(
                            @"https://github.com/fennb/phirehose.git",
                            @"fe8d322690c3d106b2b2fc73c7df4a9581b16be9", 403),
                    Tuple.Create(
                            @"https://github.com/Anahkiasen/former.git",
                            @"fce6790e10bbd0acf3f5a5224d56477ecd44ba7b", 397),
                    Tuple.Create(
                            @"https://github.com/rgrove/jsmin-php.git",
                            @"948d87c203010b0544ecc50cf31ad743d7e02a57", 392),
                    Tuple.Create(
                            @"https://github.com/walu/phpbook.git",
                            @"b0b3a2f0e5d8dcc8c4991586e794e3b36ef6e4f1", 392),
                    Tuple.Create(
                            @"https://github.com/twilio/twilio-php.git",
                            @"389e07ee41eabc422ea88b805006bccac7de9eb3", 389),
                    Tuple.Create(
                            @"https://github.com/jenssegers/Laravel-MongoDB.git",
                            @"2ae7980f86312f050c2ab626f48fa9015fbe26a3", 389),
                    Tuple.Create(
                            @"https://github.com/allynbauer/statuspanic.git",
                            @"2fb6d082ca971598c5e8632e58804cafac03b891", 363),
                    Tuple.Create(
                            @"https://github.com/alexbilbie/codeigniter-mongodb-library.git",
                            @"1bb4939aa10ee1fdef0ea53e82b6905b548983ad", 357),
                    Tuple.Create(
                            @"https://github.com/ornicar/php-github-api.git",
                            @"60bdbe492afaf4f4dc1ecd3739351c3daed37ce6", 355),
                    Tuple.Create(
                            @"https://github.com/fabpot/Twig-extensions.git",
                            @"502303198afc1ec0bcc061c6f3a0926f7eb685e3", 355),
                    Tuple.Create(
                            @"https://github.com/crowdfavorite/wp-post-formats.git",
                            @"2ff0fb194f711c4efa6d232c35cc3a19c8e597c0", 354),
                    Tuple.Create(
                            @"https://github.com/jaysalvat/image2css.git",
                            @"ba5b75cb707950e5d928d7f58b1aaf6386686700", 354),
                };
                foreach (var exp in exps) {
                    foreach (
                            var learningSet in
                                    learningSets.Skip(JavaExperiment.SkipCount)
                                            .Take(JavaExperiment.TakeCount)
                            ) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        Git.CloneAndCheckout(path, url, learningSet.Item2);
                        yield return new TestCaseData(exp, path, learningSet.Item3);
                    }
                }
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, int starCount) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.php"), };
            var allPaths = Directory.GetFiles(projectPath, "*.php", SearchOption.AllDirectories)
                    .ToList();
            exp.Learn(allPaths, seedPaths, _writer, projectPath);
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
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
            if (e.FirstChild.Name != "UnquotedString") {
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
            if (e.FirstChild.Name != "UnquotedString") {
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