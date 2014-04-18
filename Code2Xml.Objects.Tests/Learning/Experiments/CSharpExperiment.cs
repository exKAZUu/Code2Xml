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
    public class CSharpExperiment {
        private readonly StreamWriter _writer = File.CreateText(@"C:\Users\exKAZUu\Desktop\cs.txt");

        public static CstGenerator Generator = CstGenerators.CSharpUsingAntlr3;

        private const string LangName = "CSharp";
        //new MemoryCacheCstGenerator(new FileCacheCstGenerator(ProcessorLoader.CSharpUsingAntlr3));

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
					new CSharpComplexStatementExperiment(),
					new CSharpSuperComplexBranchExperiment(),
					new CSharpExpressionStatementExperiment(),
					new CSharpArithmeticOperatorExperiment(),
					new CSharpSwitchCaseExperiment(),
                    new CSharpSuperComplexBranchExperimentWithSwitch(), 
                    //new CSharpComplexBranchExperiment(),
                    //new CSharpIfExperiment(),
                    //new CSharpWhileExperiment(),
                    //new CSharpDoWhileExperiment(),
                    //new CSharpForExperiment(),
                    //new CSharpPreconditionsExperiment(),
                    //new CSharpStatementExperiment(),
                    //new CSharpBlockExperiment(),
                    //new CSharpLabeledStatementExperiment(),
                    //new CSharpEmptyStatementExperiment(),
                };
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/SignalR/SignalR.git",
                            @"b940230aedc851c50775c2ed32ab96c476f10ec6", 4109),
                    Tuple.Create(
                            @"https://github.com/hbons/SparkleShare.git",
                            @"bc69e1d80ffd36b2b5dc36286f491bb38951f238", 3034),
                    Tuple.Create(
                            @"https://github.com/ServiceStack/ServiceStack.git",
                            @"6cb92e0429e2cce31ef68e4fa02801718b00dd4f", 2284),
                    Tuple.Create(
                            @"https://github.com/NancyFx/Nancy.git",
                            @"cdea9f2db9dca8c11d0d1a5d6335cd2b78207c5d", 2104),
                    Tuple.Create(
                            @"https://github.com/restsharp/RestSharp.git",
                            @"70be25dae0edb44a1c962aee078e9dbf74cb4177", 1828),
                    Tuple.Create(
                            @"https://github.com/Redth/PushSharp.git",
                            @"19216ead2bfbbf36c4fcaa95dfa8469facc5a7ef", 1690),
                    Tuple.Create(
                            @"https://github.com/opserver/Opserver.git",
                            @"a170ea8bcda9f9e52d4aaff7339f3d198309369b", 1324),
                    Tuple.Create(
                            @"https://github.com/robconery/massive.git",
                            @"87075153609fe096bcbd9f81a6901c1b60e2e579", 1204),
                    Tuple.Create(
                            @"https://github.com/SamSaffron/dapper-dot-net.git",
                            @"885a8d46cbd67f09bd6a5e686a824759d79d5f78", 1182),
                    Tuple.Create(
                            @"https://github.com/ravendb/ravendb.git",
                            @"a60d8dd3ffaf5892d86d5fcf8a9a81bec71800e7", 1118),
                    Tuple.Create(
                            @"https://github.com/SamSaffron/MiniProfiler.git",
                            @"3744054e0686b2f88083b869a7f2fe7e1fa14e9c", 1113),
                    Tuple.Create(
                            @"https://github.com/jaredpar/VsVim.git",
                            @"86d9e298c9d117e54266501ae9c4dd35b4d345cb", 1097),
                    Tuple.Create(
                            @"https://github.com/jagregory/fluent-nhibernate.git",
                            @"4d2348d560b952abba72179b3c4097acf02f4b99", 1078),
                    Tuple.Create(
                            @"https://github.com/ninject/ninject.git",
                            @"f2a558f58e1492226614392acf10cea72130c437", 1007),
                    Tuple.Create(
                            @"https://github.com/reactiveui/ReactiveUI.git",
                            @"45aaa51f5d5202a5c8d34ea3151955f0bce8a956", 889),
                    Tuple.Create(
                            @"https://github.com/markrendle/Simple.Data.git",
                            @"65ff01e482ce71190869001c221caa140feb70e5", 864),
                    Tuple.Create(
                            @"https://github.com/JamesNK/Newtonsoft.Json.git",
                            @"9e2581be74585605b4f49e0110d65c85c17cb323", 827),
                    Tuple.Create(
                            @"https://github.com/scriptcs/scriptcs.git",
                            @"fce68ff79b412c9acbadc8669614db498418abf5", 822),
                    Tuple.Create(
                            @"https://github.com/mongodb/mongo-csharp-driver.git",
                            @"3f7996e297ba8756025c709979467982839c3277", 792),
                    Tuple.Create(
                            @"https://github.com/Squirrel/Squirrel.Windows.git",
                            @"04a44954ffd416397c6b9156a837a155efe9bb49", 767),
                    Tuple.Create(
                            @"https://github.com/DotNetOpenAuth/DotNetOpenAuth.git",
                            @"c9df84fda7963fe84848c3636d87696bc22169a5", 699),
                    Tuple.Create(
                            @"https://github.com/Glimpse/Glimpse.git",
                            @"b78f1c8b336e86278efea95c115f8a9a404ab901", 692),
                    Tuple.Create(
                            @"https://github.com/OpenRA/OpenRA.git",
                            @"5e1e45631a31a1b189a706d5c829999b9b5b8653", 691),
                    Tuple.Create(
                            @"https://github.com/schambers/fluentmigrator.git",
                            @"73c831c94eb4b28ba11f55c6fb63cd96748247d5", 655),
                    Tuple.Create(
                            @"https://github.com/NEventStore/NEventStore.git",
                            @"828bb20ba29acf0a4e3f1d4982045e01e6418b98", 648),
                    Tuple.Create(
                            @"https://github.com/akavache/Akavache.git",
                            @"d04819c6a29205cc39740ae54b5fa473b25809db", 646),
                    Tuple.Create(
                            @"https://github.com/Code52/DownmarkerWPF.git",
                            @"5bea50ace54a97258d3778d79c487b3e63a5a462", 632),
                    Tuple.Create(
                            @"https://github.com/git-tfs/git-tfs.git",
                            @"69eb7f240565bec3f1a1d9cd5d3afddd71be0280", 611),
                    Tuple.Create(
                            @"https://github.com/henon/GitSharp.git",
                            @"4cef5fe76e80cfb457abb7d5f9d8c5040affa4c5", 590),
                    Tuple.Create(
                            @"https://github.com/cefsharp/CefSharp.git",
                            @"9bdb5376371c28fb1893de8b39c9ad7babfc0067", 578),
                    Tuple.Create(
                            @"https://github.com/quartznet/quartznet.git",
                            @"8d3d11b51ffc37ae0bdb06b701488e591dbb5580", 578),
                    Tuple.Create(
                            @"https://github.com/facebook-csharp-sdk/facebook-csharp-sdk.git",
                            @"332f32799530b934ebe9f0c94e3ff564697a795c", 572),
                    Tuple.Create(
                            @"https://github.com/Particular/NServiceBus.git",
                            @"8002a95026e2487347f4ba28d83fca7ea5feb924", 565),
                    Tuple.Create(
                            @"https://github.com/projectkudu/kudu.git",
                            @"b1f9bc97370ded46461e0b4f3a1345189d297d81", 560),
                    Tuple.Create(
                            @"https://github.com/Antaris/RazorEngine.git",
                            @"8adc810c0dea0d364b85678d49f4b25fcc27e720", 547),
                    Tuple.Create(
                            @"https://github.com/ServiceStack/ServiceStack.Redis.git",
                            @"718395587df889fe708c629421f66ea129a8f109", 534),
                    Tuple.Create(
                            @"https://github.com/toptensoftware/PetaPoco.git",
                            @"8358e323ea02f17cd5e3565391b70bb0dd06f236", 534),
                    Tuple.Create(
                            @"https://github.com/subsonic/SubSonic-3.0.git",
                            @"18114a145ff6cdaaf4dbf1e6c28af443adc956b7", 531),
                    Tuple.Create(
                            @"https://github.com/libgit2/libgit2sharp.git",
                            @"cccecb2a5eddcb9e952cfd8be545396312ee24d5", 524),
                    Tuple.Create(
                            @"https://github.com/ServiceStack/ServiceStack.Text.git",
                            @"ec31bb5b4bb191ce8fd148bcc63f3e3378d58fa9", 518),
                    Tuple.Create(
                            @"https://github.com/MehdiK/Humanizer.git",
                            @"45ac92ebd5005a708e98dc51a5e309096a58ef52", 518),
                    Tuple.Create(
                            @"https://github.com/MattRix/Futile.git",
                            @"9d56ee479ee966424c8ef8ccc4da6aa7a5d001ca", 502),
                    Tuple.Create(
                            @"https://github.com/Azure/azure-sdk-for-net.git",
                            @"37fc9b1954a1c3bbf94e6123697069262fe905f8", 494),
                    Tuple.Create(
                            @"https://github.com/xamarin/monotouch-samples.git",
                            @"e607885cdff9548721ea7b08ff07c1aca81eb2bf", 475),
                    Tuple.Create(
                            @"https://github.com/gregoryyoung/m-r.git",
                            @"51e39f81b773146c12e0ee7150b5a48076893a13", 451),
                    Tuple.Create(
                            @"https://github.com/waseems/inbox2_desktop.git",
                            @"221c56e0c83b0e873314767f0f9a53e25416343a", 447),
                    Tuple.Create(
                            @"https://github.com/NuGet/NuGetGallery.git",
                            @"6f365c1600acd9f9dc623a9741c606be60bcf07c", 420),
                    Tuple.Create(
                            @"https://github.com/migueldeicaza/MonoTouch.Dialog.git",
                            @"6dfe7f61ea40486310c68fd12f2988d6d242f7f7", 418),
                    Tuple.Create(
                            @"https://github.com/oddgames/UIToolkit.git",
                            @"b60aa4b1523d6a6fef33c11fdaad00364e9bb9a0", 416),
                    Tuple.Create(
                            @"https://github.com/NewEraCracker/LOIC.git",
                            @"c847036537d92ab8548e8e5058ac8dfa6846acea", 415),
                    Tuple.Create(
                            @"https://github.com/samus/mongodb-csharp.git",
                            @"6397a0f032f24227894afa6ec37e92dd18dd0b3f", 408),
                    Tuple.Create(
                            @"https://github.com/smsohan/MvcMailer.git",
                            @"475099d384597792dfcddfa557569e4f70bec308", 408),
                    Tuple.Create(
                            @"https://github.com/octokit/octokit.net.git",
                            @"20a25d57991ebd5f6f5a812ed7bb01ec006aa989", 391),
                    Tuple.Create(
                            @"https://github.com/atheken/NoRM.git",
                            @"f73ee334145e7e5e94f0b78e6b27cda56ae2fdc6", 389),
                    Tuple.Create(
                            @"https://github.com/mccalltd/AttributeRouting.git",
                            @"028202b2f72d5fb139e6d9970430e077f421efc2", 385),
                    Tuple.Create(
                            @"https://github.com/JeremySkinner/FluentValidation.git",
                            @"7803000a4c709347b862ac5b8d500c175dfc460a", 381),
                    Tuple.Create(
                            @"https://github.com/elasticsearch/elasticsearch-net.git",
                            @"903060e3094de06d01a88b32ed07e588701391aa", 377),
                    Tuple.Create(
                            @"https://github.com/mikehadlow/EasyNetQ.git",
                            @"74a5178fd9d85f316c34f5f2c13fe2e4bb0107d8", 374),
                    Tuple.Create(
                            @"https://github.com/kayak/kayak.git",
                            @"f3fb78490243ee59d100811e802a0dd5b6f3daae", 365),
                    Tuple.Create(
                            @"https://github.com/JoshClose/CsvHelper.git",
                            @"b5d0563510bafcf1cbba7ed3423d6b9d19349a46", 358),
                    Tuple.Create(
                            @"https://github.com/structuremap/structuremap.git",
                            @"a1fdad054fabd10b129b17ec36cb78f7e2331ae4", 357),
                    Tuple.Create(
                            @"https://github.com/jbevain/cecil.git",
                            @"b6cc4bb1dbe489170af429b87a5802182e27a37a", 356),
                    Tuple.Create(
                            @"https://github.com/brockallen/BrockAllen.MembershipReboot.git",
                            @"55ff159604b74c719c02aaaf85c99bd316a7dcca", 355),
                    Tuple.Create(
                            @"https://github.com/Rduerden/Node.cs.git",
                            @"1e5c77f2ef8f7b524656763c4c371f7aee966f4a", 348),
                    Tuple.Create(
                            @"https://github.com/danielcrenna/tweetsharp.git",
                            @"e3d00e44aad40419b215a6f9a591b989d25519d6", 347),
                    Tuple.Create(
                            @"https://github.com/qianlifeng/Wox.git",
                            @"b07d1b027c42c045bce8304b40b4c27e4d03248f", 336),
                    Tuple.Create(
                            @"https://github.com/clojure/clojure-clr.git",
                            @"0a23829782aca9005f0db733c46a6ce65262020c", 332),
                    Tuple.Create(
                            @"https://github.com/todbot/blink1.git",
                            @"afbb60c8a3c586770a2f244ea8a3907fd020ba53", 327),
                    Tuple.Create(
                            @"https://github.com/loresoft/msbuildtasks.git",
                            @"fa3b1cb19afb83c6a005547d00465b7233cf5ab7", 324),
                    Tuple.Create(
                            @"https://github.com/mono/xwt.git",
                            @"11b0131af050526dad2c105ce74cfb085c2450ff", 323),
                    Tuple.Create(
                            @"https://github.com/ncqrs/ncqrs.git",
                            @"09ef321d1ad6dcea30584e586ade9526104c6e51", 320),
                    Tuple.Create(
                            @"https://github.com/DropNet/DropNet.git",
                            @"ee955df5a86ccba3a50e6e3f1db8ab2e1dc10fb9", 317),
                    Tuple.Create(
                            @"https://github.com/sixthsense/sixthsense.git",
                            @"d0185b77c5ffdd8d0e07a87a98424db3cc21f76a", 315),
                    Tuple.Create(
                            @"https://github.com/Jessecar96/SteamBot.git",
                            @"5af6a0b85a82620862236077336964b4b76b19b5", 311),
                    Tuple.Create(
                            @"https://github.com/VerbalExpressions/CSharpVerbalExpressions.git",
                            @"245a871122b6233c1911911553539fd6735d5556", 310),
                    Tuple.Create(
                            @"https://github.com/OpenCover/opencover.git",
                            @"4bd5079ef2cde7410a42a5af1494857eee6231ba", 309),
                    Tuple.Create(
                            @"https://github.com/mausch/SolrNet.git",
                            @"f29b03107c1922226f888a64f0ed0b848c56fb54", 305),
                    Tuple.Create(
                            @"https://github.com/nsubstitute/NSubstitute.git",
                            @"d787176463bde8a9793709756575a37b1acf8c17", 303),
                    Tuple.Create(
                            @"https://github.com/WebApiContrib/WebAPIContrib.git",
                            @"fe88ff3c0b3871c77b062dbbe9a8ff87107b1d9e", 298),
                    Tuple.Create(
                            @"https://github.com/loresoft/EntityFramework.Extended.git",
                            @"2a999b949530458edc4fd39861e52e043295177d", 298),
                    Tuple.Create(
                            @"https://github.com/NyxStudios/TShock.git",
                            @"61d05ffdc6b3fb9544be72d333585a8aace835da", 297),
                    Tuple.Create(
                            @"https://github.com/Haacked/SeeGit.git",
                            @"3c47da93e5d4260612daa8aff3c6ce97da672936", 295),
                    Tuple.Create(
                            @"https://github.com/timheuer/callisto.git",
                            @"fb9cbac2ccc7900cecf69f722045ca881dbddba3", 290),
                    Tuple.Create(
                            @"https://github.com/thinktecture/Thinktecture.IdentityModel.45.git",
                            @"a2fed40e655beac76f54f11dde1c3b907079a4d1", 289),
                    Tuple.Create(
                            @"https://github.com/Lokad/lokad-cqrs.git",
                            @"75e16de6103c3a6fd9d59846ccea6eeb88185dca", 289),
                    Tuple.Create(
                            @"https://github.com/Fody/Fody.git",
                            @"77a985ae84e22c032de7f6fb29ed259ec804e5dd", 286),
                    Tuple.Create(
                            @"https://github.com/playgameservices/play-games-plugin-for-unity.git",
                            @"3ad9798396cc5e443815d5c1438bcebc54d98ed9", 282),
                    Tuple.Create(
                            @"https://github.com/maartenba/MvcSiteMapProvider.git",
                            @"92ad5eb87a16597c2b18cbb6daf56a4491a652c9", 277),
                    Tuple.Create(
                            @"https://github.com/Moq/moq4.git",
                            @"ac31aeca01056e3608540d5b5d043ba013f19abe", 276),
                    Tuple.Create(
                            @"https://github.com/robconery/biggy.git",
                            @"0c7a0cb8f08b0ac7e5d87f91c5617d4cc6e21b84", 272),
                    Tuple.Create(
                            @"https://github.com/jdiamond/Nustache.git",
                            @"957a95f26265876a42dcd8934708bab95d01ef87", 269),
                    Tuple.Create(
                            @"https://github.com/statianzo/Fleck.git",
                            @"06837f548345fa06e91c01312a0f5c18fd6f012f", 269),
                    Tuple.Create(
                            @"https://github.com/MarlabsInc/SocialGoal.git",
                            @"d6cc337d3f97be6f3fec5b66aa2c8982e800c98c", 263),
                    Tuple.Create(
                            @"https://github.com/danielcrenna/metrics-net.git",
                            @"4b4b5dd49eedd387ac0b2423be402ce6e20a4d87", 260),
                    Tuple.Create(
                            @"https://github.com/Compilify/Compilify.git",
                            @"dc523cffd6205a142e70f45c735f87a1eb40a712", 252),
                    Tuple.Create(
                            @"https://github.com/gsscoder/commandline.git",
                            @"a3fa34f261fe5511f2c8bd7d259f3906b1688e2c", 251),
                    Tuple.Create(
                            @"https://github.com/Code52/pretzel.git",
                            @"90b1739e9d1fbe397e9ff20ca5f2d1526d5d5c61", 249),
                    Tuple.Create(
                            @"https://github.com/FakeItEasy/FakeItEasy.git",
                            @"d8c919b852e7668217d5463cbe20d97402bde61a", 247),
                    Tuple.Create(
                            @"https://github.com/chucknorris/roundhouse.git",
                            @"812f4debbb0f31896af08e9ef1dd0b47f1686882", 234),
                    Tuple.Create(
                            @"https://github.com/zeromq/clrzmq.git",
                            @"76404a94e0a0bbb0aff23e5500eb5af0a70bda05", 234),
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
        public void Test(LearningExperiment exp, string projectPath, int starCount) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.cs"), };
            var allPaths = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories)
                    .ToList();
            exp.Learn(allPaths, seedPaths, _writer, projectPath);
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
        }
    }

    public class CSharpSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        public CSharpSuperComplexBranchExperiment() : base("boolean_expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "if_statement") {
                return true;
            }
            if (pName == "while_statement") {
                return true;
            }
            if (pName == "do_statement") {
                return true;
            }
            if (pName == "for_condition") {
                return true;
            }
            if (e.ElementsBeforeSelf().Any()) {
                return false;
            }
            var p = e.Parent.Parent.Parent.Parent.Parent;
            var parts = p.Elements("primary_expression_start")
                    .Concat(p.Elements("primary_expression_part"))
                    .ToList();
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().TokenText
                                    != "Contract")) {
                return false;
            }
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().TokenText
                                    != "Requires")) {
                return false;
            }
            return true;
        }
    }

    public class CSharpComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        public CSharpComplexBranchExperiment() : base("boolean_expression") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "if_statement") {
                return true;
            }
            if (pName == "while_statement") {
                return true;
            }
            if (pName == "do_statement") {
                return true;
            }
            if (pName == "for_condition") {
                return true;
            }
            return false;
        }
    }

    public class CSharpIfExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "if_statement") {
                return true;
            }
            return false;
        }

        public CSharpIfExperiment() : base("boolean_expression") {}
    }

    public class CSharpWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "while_statement") {
                return true;
            }
            return false;
        }

        public CSharpWhileExperiment() : base("boolean_expression") {}
    }

    public class CSharpDoWhileExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "do_statement") {
                return true;
            }
            return false;
        }

        public CSharpDoWhileExperiment() : base("boolean_expression") {}
    }

    public class CSharpForExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return true;
        }

        public CSharpForExperiment() : base("for_condition") {}
    }

    public class CSharpPreconditionsExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.ElementsBeforeSelf().Any()) {
                return false;
            }
            var p = e.Parent.Parent.Parent.Parent.Parent;
            var parts = p.Elements("primary_expression_start")
                    .Concat(p.Elements("primary_expression_part"))
                    .ToList();
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().SafeTokenText()
                                    != "Contract")) {
                return false;
            }
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().SafeTokenText()
                                    != "Requires")) {
                return false;
            }
            return true;
        }

        public CSharpPreconditionsExperiment() : base("argument") {}
    }

    public class CSharpComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ラベルはループ文に付くため，ラベルの中身は除外
            if (e.Element("labeled_statement") != null) {
                return false;
            }

            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            var e2 = e.Element("embedded_statement");
            if (e2 != null && e2.Element("block") != null) {
                return false;
            }

            // 空文を除外
            if (e.TokenText == ";") {
                return false;
            }
            return true;
        }

        public CSharpComplexStatementExperiment() : base("statement") {}
    }

    public class CSharpStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return true;
        }

        public CSharpStatementExperiment() : base("statement") {}
    }

    public class CSharpBlockExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
            var e2 = e.Element("embedded_statement");
            if (e2 != null && e2.Element("block") != null) {
                return true;
            }
            return false;
        }

        public CSharpBlockExperiment() : base("statement") {}
    }

    public class CSharpLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // ラベルはループ文に付くため，ラベルの中身は除外
            if (e.Element("labeled_statement") != null) {
                return true;
            }
            return false;
        }

        public CSharpLabeledStatementExperiment() : base("statement") {}
    }

    public class CSharpEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            // 空文を除外
            if (e.TokenText == ";") {
                return true;
            }
            return false;
        }

        public CSharpEmptyStatementExperiment() : base("statement") {}
    }

    public class CSharpExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        public CSharpExpressionStatementExperiment() : base("expression_statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "statement") {
                e = e.FirstChild;
            }
            if (e.Name == "embedded_statement") {
                e = e.FirstChild;
            }
            return e.Name == "expression_statement";
        }
    }

    public class CSharpArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        public CSharpArithmeticOperatorExperiment() : base("TOKENS", "MINUS") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return ((e.TokenText == "*" || e.TokenText == "/")
                    && e.Parent.Name == "multiplicative_expression") ||
                   ((e.TokenText == "+" || e.TokenText == "-")
                    && e.Parent.Name == "additive_expression");
        }
    }

    public class CSharpSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        public CSharpSwitchCaseExperiment() : base("expression", "switch_label") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "switch_statement") {
                return true;
            }
            if (e.Name == "switch_labels" && e.ChildrenCount == 1) {
                return true;
            }
            return e.Name == "switch_label";
        }
    }

    public class CSharpSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        public CSharpSuperComplexBranchExperimentWithSwitch()
                : base("boolean_expression", "expression", "switch_label") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "if_statement") {
                return true;
            }
            if (pName == "while_statement") {
                return true;
            }
            if (pName == "do_statement") {
                return true;
            }
            if (pName == "for_condition") {
                return true;
            }
            if (e.Parent.Name == "switch_statement") {
                return true;
            }
            if (e.Name == "switch_labels" && e.ChildrenCount == 1) {
                return true;
            }
            if (e.Name == "switch_label") {
                return true;
            }
            if (e.ElementsBeforeSelf().Any()) {
                return false;
            }
            var p = e.Parent.Parent.Parent.Parent.Parent;
            var parts = p.Elements("primary_expression_start")
                    .Concat(p.Elements("primary_expression_part"))
                    .ToList();
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().TokenText
                                    != "Contract")) {
                return false;
            }
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().TokenText
                                    != "Requires")) {
                return false;
            }
            return true;
        }
    }
}