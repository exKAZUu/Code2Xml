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

using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.CSharp;
using Code2Xml.Objects.Tests.Learning.Experiments;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
    [TestFixture]
    public class CSharpCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new CSharpCstGeneratorUsingAntlr3();
        }

        [Test]
        [TestCase(@"class K { }")]
        [TestCase(@"class K { void m() {} }")]
        [TestCase(@"class K {
#	define DEBUG
#	region
# if DEBUG
void m() { /* comment */ } // comment2
# else
xxxxx
# endif
# 	 undef DEBUG
#	endregion
}")]
        [TestCase(@"class K { void m() {
	for (int i = 1; i < 2; i++) Console.WriteLine();
} }")]
        [TestCase(@"class K { void m() { 1.ToString(); } }")]
        [TestCase(@"class K { void m() { 123.ToString(); } }")]
        [TestCase(@"class K { void m() { var a = from method in new[] { 123 } select method; } }")]
        [TestCase(@"class K { void m() {
			var a = from method in new[] { 123.ToString() }
				group method by method.Length
				into overloads
				let oload = (from overload in overloads
					orderby overload.Length
					select overload).FirstOrDefault()
				orderby oload.Length
				select oload;
} }")]
        [TestCase(@"class K { Object s = new HashSet<int>(s.s) {}; }")]
        [TestCase(@"class K { void m() { var o = new { args }; }; }")]
        [TestCase(@"class K { void m() { var o = new { args }.args; }; }")]
        [TestCase(@"[Attr(XX.YY, XX.ZZ, prop: true)] class K {}")]
        [TestCase(@"//x")]
        [TestCase(@"class K { void m() {
			var items = new[] { new L() { Text = emptyItemText, Value = 1 }.m(), }.m(); } }")]
        [TestCase(@"class K { void m() {
			var items = new[] { new L() { Text = emptyItemText, Value = 1, }.m() }.m(); } }")]
        [TestCase(@"class K { void m() {
			var items = new[] { new L() { Text = emptyItemText, Value = 1, }.m(), }.m(); } }")]
        [TestCase(@"class K { void m() { new object[2].GetEnumerator(); } }")]
        [TestCase(@"class K { void m() { var a = new int[][,] {  }; } }")]
        [TestCase(@"class K { void m() { var a = new []{ 1 }.GetEnumerator(); } }")]
        [TestCase(@"class K { void m() { new Action[]{ }[0](); } }")]
        [TestCase(@"class K { void m() { var a = new Action[]{ }[0]; } }")]
        [TestCase(@"﻿using System;")]
        [TestCase(@"class K { void m() { new[] { 1 }; } }")]
        [TestCase(@"class K { void m() { new[] { 1 }.m(); } }")]
        [TestCase(@"class K { void m() { new[] { 1 }.m().m(); } }")]
        [TestCase(@"class K { public T operator *(int a, int b) {} }")]
        [TestCase(@"class K { public T operator*(int a, int b) {} }")]
        [TestCase(@"class K { void m() { var b = from p in a group p by (int)1 into x select x; } }"
                )]
        [TestCase(@"class K { void m() { var b = from p in a group p by (p.X) into x select x; } }")
        ]
        [TestCase(@"class K { K() { f += (a1, a2) => a1; } }")]
        [TestCase(@"class K { K() { f += async (a1, a2) => a1; } }")]
        [TestCase(@"class K { K() { var length = await sizeTask; var await = 1; } }")]
        [TestCase(@"class K { K() { new O() { P = v }; } }")]
        [TestCase(@"class K { int dynamic; }")]
        [TestCase(@"class K { void m() { var f = new { s.Length, p = 1 }; } }")]
        [TestCase(@"class K	{ void m() {
#if ( DEBUG )
#endif
		} }")]
        [TestCase(@"class K	{ void m() {
#if( DEBUG )
#endif
		} }")]
        [TestCase(@"class K	{ void m() {
#if(DEBUG)
#endif
		} }")]
        [TestCase(@"unsafe struct S { fixed byte b[4]; }")]
        [TestCase(@"class K { void m() { var v = t as int?; } }")]
        [TestCase(@"class K { void m() { return v is int ? 1 : 1; } }")]
        [TestCase(@"class K { void m() { var x = typeof(double?[]); } }")]
        [TestCase(@"class K { void m() { var partial = 1; } }")]
        [TestCase(@"class K { void m() { var get = 1; } }")]
        [TestCase(@"class K { void m() { var set = 1; } }")]
        [TestCase(@"class K { void m() { var from = 1; } }")]
        [TestCase(@"class K { void m() { var q = u.Name == (s); } }")]
        [TestCase(@"class K { void m() { var q = from u in u where u == (s) select u; } }")]
        [TestCase(@"#pragma warning")]
        [TestCase(@"#define A")]
        [TestCase(@"#define A //")]
        [TestCase(@"
#if!A
#endif")]
        [TestCase(@"class K { void m() { var from = 1; from = 2; } }")]
        [TestCase(@"public class \u211B { }")]
        [TestCase(@"class K { void m() {
			Contract.Requires(true);
			Contract.Requires(true, s);
			Contract.Requires<Exception>(true);
			Contract.Requires<Exception>(true, s);

			System.Diagnostics.Contracts.Contract.Requires(true);
			System.Diagnostics.Contracts.Contract.Requires(true, s);
			System.Diagnostics.Contracts.Contract.Requires<Exception>(true);
			System.Diagnostics.Contracts.Contract.Requires<Exception>(true, s);
} }")]
        [TestCase(@"class K { void m() { int i = 0 + 1 - 2 * 3/ 4; }}")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Block1.cs")]
        [TestCase("Block2.cs")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("CSharp", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/SignalR/SignalR.git",
                @"b940230aedc851c50775c2ed32ab96c476f10ec6", 4109)]
        [TestCase(@"https://github.com/hbons/SparkleShare.git",
                @"bc69e1d80ffd36b2b5dc36286f491bb38951f238", 3034)]
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.git",
                @"6cb92e0429e2cce31ef68e4fa02801718b00dd4f", 2284)]
        [TestCase(@"https://github.com/NancyFx/Nancy.git",
                @"cdea9f2db9dca8c11d0d1a5d6335cd2b78207c5d", 2104)]
        [TestCase(@"https://github.com/mono/mono.git",
                @"6a7791058f83e62ed73a7cda21f037cc9a827a83", 2056)]
        [TestCase(@"https://github.com/mono/MonoGame.git",
                @"73fc2954b0cd83a4a7f3ddecdc56f155ff135e99", 1997)]
        [TestCase(@"https://github.com/AutoMapper/AutoMapper.git",
                @"af890ba90bd5fd00b3b62afebda014da153b34a1", 1855)]
        [TestCase(@"https://github.com/restsharp/RestSharp.git",
                @"70be25dae0edb44a1c962aee078e9dbf74cb4177", 1828)]
        [TestCase(@"https://github.com/Redth/PushSharp.git",
                @"19216ead2bfbbf36c4fcaa95dfa8469facc5a7ef", 1690)]
        [TestCase(@"https://github.com/opserver/Opserver.git",
                @"a170ea8bcda9f9e52d4aaff7339f3d198309369b", 1324)]
        [TestCase(@"https://github.com/robconery/massive.git",
                @"87075153609fe096bcbd9f81a6901c1b60e2e579", 1204)]
        [TestCase(@"https://github.com/SamSaffron/dapper-dot-net.git",
                @"885a8d46cbd67f09bd6a5e686a824759d79d5f78", 1182)]
        [TestCase(@"https://github.com/ravendb/ravendb.git",
                @"a60d8dd3ffaf5892d86d5fcf8a9a81bec71800e7", 1118)]
        [TestCase(@"https://github.com/SamSaffron/MiniProfiler.git",
                @"3744054e0686b2f88083b869a7f2fe7e1fa14e9c", 1113)]
        [TestCase(@"https://github.com/jaredpar/VsVim.git",
                @"86d9e298c9d117e54266501ae9c4dd35b4d345cb", 1097)]
        [TestCase(@"https://github.com/jagregory/fluent-nhibernate.git",
                @"4d2348d560b952abba72179b3c4097acf02f4b99", 1078)]
        [TestCase(@"https://github.com/ninject/ninject.git",
                @"f2a558f58e1492226614392acf10cea72130c437", 1007)]
        [TestCase(@"https://github.com/mono/monodevelop.git",
                @"1716affe5e0a1a69efd626d2dd41bd0c56113dfc", 998)]
        [TestCase(@"https://github.com/gitextensions/gitextensions.git",
                @"b57b3f4788dd000ea7d1bb5f6980e1e06977c5b9", 954)]
        [TestCase(@"https://github.com/JabbR/JabbR.git",
                @"e40634b4e6594ce4ebd6aea0a6864b8f61b1ed02", 927)]
        [TestCase(@"https://github.com/SonyWWS/ATF.git",
                @"bcbfc1277dc63455be0106f4644a3b6549e75623", 900)]
        [TestCase(@"https://github.com/reactiveui/ReactiveUI.git",
                @"45aaa51f5d5202a5c8d34ea3151955f0bce8a956", 889)]
        [TestCase(@"https://github.com/icsharpcode/ILSpy.git",
                @"056dfa1194fe01562dd8ad6908ed9cdff882618e", 867)]
        [TestCase(@"https://github.com/markrendle/Simple.Data.git",
                @"65ff01e482ce71190869001c221caa140feb70e5", 864)]
        [TestCase(@"https://github.com/JamesNK/Newtonsoft.Json.git",
                @"9e2581be74585605b4f49e0110d65c85c17cb323", 827)]
        [TestCase(@"https://github.com/scriptcs/scriptcs.git",
                @"fce68ff79b412c9acbadc8669614db498418abf5", 822)]
        [TestCase(@"https://github.com/MahApps/MahApps.Metro.git",
                @"36fe5e517e0c65116d288fdabf2e68a2a9494bd9", 800)]
        [TestCase(@"https://github.com/mongodb/mongo-csharp-driver.git",
                @"3f7996e297ba8756025c709979467982839c3277", 792)]
        [TestCase(@"https://github.com/Squirrel/Squirrel.Windows.git",
                @"04a44954ffd416397c6b9156a837a155efe9bb49", 767)]
        [TestCase(@"https://github.com/sq/JSIL.git",
                @"a1c58ec111a107e2d670d4a0548fcfc1f3460394", 751)]
        [TestCase(@"https://github.com/MvvmCross/MvvmCross.git",
                @"fd16e13d05678e578ddc96938a680b3d94d8a496", 708)]
        [TestCase(@"https://github.com/DotNetOpenAuth/DotNetOpenAuth.git",
                @"c9df84fda7963fe84848c3636d87696bc22169a5", 699)]
        [TestCase(@"https://github.com/Glimpse/Glimpse.git",
                @"b78f1c8b336e86278efea95c115f8a9a404ab901", 692)]
        [TestCase(@"https://github.com/OpenRA/OpenRA.git",
                @"5e1e45631a31a1b189a706d5c829999b9b5b8653", 691)]
        [TestCase(@"https://github.com/schambers/fluentmigrator.git",
                @"73c831c94eb4b28ba11f55c6fb63cd96748247d5", 655)]
        [TestCase(@"https://github.com/NEventStore/NEventStore.git",
                @"828bb20ba29acf0a4e3f1d4982045e01e6418b98", 648)]
        [TestCase(@"https://github.com/akavache/Akavache.git",
                @"d04819c6a29205cc39740ae54b5fa473b25809db", 646)]
        [TestCase(@"https://github.com/Code52/DownmarkerWPF.git",
                @"5bea50ace54a97258d3778d79c487b3e63a5a462", 632)]
        [TestCase(@"https://github.com/git-tfs/git-tfs.git",
                @"69eb7f240565bec3f1a1d9cd5d3afddd71be0280", 611)]
        [TestCase(@"https://github.com/nhibernate/nhibernate-core.git",
                @"5e78ad6c7d5d37aebfeca75d832e44eded89e894", 602)]
        [TestCase(@"https://github.com/xamarin/monodroid-samples.git",
                @"4851316a320c9c6ce0b57348d05c6dc6e8819e1c", 599)]
        [TestCase(@"https://github.com/henon/GitSharp.git",
                @"4cef5fe76e80cfb457abb7d5f9d8c5040affa4c5", 590)]
        [TestCase(@"https://github.com/cefsharp/CefSharp.git",
                @"9bdb5376371c28fb1893de8b39c9ad7babfc0067", 578)]
        [TestCase(@"https://github.com/quartznet/quartznet.git",
                @"8d3d11b51ffc37ae0bdb06b701488e591dbb5580", 578)]
        [TestCase(@"https://github.com/facebook-csharp-sdk/facebook-csharp-sdk.git",
                @"332f32799530b934ebe9f0c94e3ff564697a795c", 572)]
        [TestCase(@"https://github.com/Particular/NServiceBus.git",
                @"8002a95026e2487347f4ba28d83fca7ea5feb924", 565)]
        [TestCase(@"https://github.com/projectkudu/kudu.git",
                @"b1f9bc97370ded46461e0b4f3a1345189d297d81", 560)]
        [TestCase(@"https://github.com/EventStore/EventStore.git",
                @"96c1a28325d80577cccc51b35af73ffa5d307d0e", 560)]
        [TestCase(@"https://github.com/dotless/dotless.git",
                @"1b1bea4be98954551c80c9fa9fd3c825be647880", 547)]
        [TestCase(@"https://github.com/Antaris/RazorEngine.git",
                @"8adc810c0dea0d364b85678d49f4b25fcc27e720", 547)]
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.Redis.git",
                @"718395587df889fe708c629421f66ea129a8f109", 534)]
        [TestCase(@"https://github.com/toptensoftware/PetaPoco.git",
                @"8358e323ea02f17cd5e3565391b70bb0dd06f236", 534)]
        [TestCase(@"https://github.com/subsonic/SubSonic-3.0.git",
                @"18114a145ff6cdaaf4dbf1e6c28af443adc956b7", 531)]
        [TestCase(@"https://github.com/libgit2/libgit2sharp.git",
                @"cccecb2a5eddcb9e952cfd8be545396312ee24d5", 524)]
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.Text.git",
                @"ec31bb5b4bb191ce8fd148bcc63f3e3378d58fa9", 518)]
        [TestCase(@"https://github.com/MehdiK/Humanizer.git",
                @"45ac92ebd5005a708e98dc51a5e309096a58ef52", 518)]
        [TestCase(@"https://github.com/MattRix/Futile.git",
                @"9d56ee479ee966424c8ef8ccc4da6aa7a5d001ca", 502)]
        [TestCase(@"https://github.com/Azure/azure-sdk-for-net.git",
                @"37fc9b1954a1c3bbf94e6123697069262fe905f8", 494)]
        [TestCase(@"https://github.com/madskristensen/WebEssentials2013.git",
                @"1de6c4f84358e0a1adf8d61bbcc8dfd20197dc96", 491)]
        [TestCase(@"https://github.com/nikhilk/scriptsharp.git",
                @"d79f89354dc6b9eb61da56cae35ce84fbfe1e94f", 483)]
        [TestCase(@"https://github.com/xamarin/monotouch-samples.git",
                @"e607885cdff9548721ea7b08ff07c1aca81eb2bf", 475)]
        [TestCase(@"https://github.com/machine/machine.specifications.git",
                @"85a0d917cc64abf3699a3bafd92a5ba6d4e4161a", 471)]
        [TestCase(@"https://github.com/NLog/NLog.git",
                @"2c609e48a5f3ea26786b2d66c9112e269e3ac536", 460)]
        [TestCase(@"https://github.com/umbraco/Umbraco-CMS.git",
                @"5697809ce930e1b8f9f111586c2b4bb59e8f3869", 458)]
        [TestCase(@"https://github.com/jacksonh/manos.git",
                @"300450cd5c8a146cdf5e9cbaa837ecccfd8ab951", 451)]
        [TestCase(@"https://github.com/icsharpcode/SharpDevelop.git",
                @"d3a44776f32ec7829d60e18c3a57538eb559974c", 451)]
        [TestCase(@"https://github.com/gregoryyoung/m-r.git",
                @"51e39f81b773146c12e0ee7150b5a48076893a13", 451)]
        [TestCase(@"https://github.com/andrewdavey/cassette.git",
                @"38e229f1d7bfd41c65f75fb73f1af10b076c31cb", 447)]
        [TestCase(@"https://github.com/waseems/inbox2_desktop.git",
                @"221c56e0c83b0e873314767f0f9a53e25416343a", 447)]
        [TestCase(@"https://github.com/NuGet/NuGetGallery.git",
                @"6f365c1600acd9f9dc623a9741c606be60bcf07c", 420)]
        [TestCase(@"https://github.com/migueldeicaza/MonoTouch.Dialog.git",
                @"6dfe7f61ea40486310c68fd12f2988d6d242f7f7", 418)]
        [TestCase(@"https://github.com/oddgames/UIToolkit.git",
                @"b60aa4b1523d6a6fef33c11fdaad00364e9bb9a0", 416)]
        [TestCase(@"https://github.com/NewEraCracker/LOIC.git",
                @"c847036537d92ab8548e8e5058ac8dfa6846acea", 415)]
        [TestCase(@"https://github.com/samus/mongodb-csharp.git",
                @"6397a0f032f24227894afa6ec37e92dd18dd0b3f", 408)]
        [TestCase(@"https://github.com/smsohan/MvcMailer.git",
                @"475099d384597792dfcddfa557569e4f70bec308", 408)]
        [TestCase(@"https://github.com/octokit/octokit.net.git",
                @"20a25d57991ebd5f6f5a812ed7bb01ec006aa989", 391)]
        [TestCase(@"https://github.com/atheken/NoRM.git",
                @"f73ee334145e7e5e94f0b78e6b27cda56ae2fdc6", 389)]
        [TestCase(@"https://github.com/mccalltd/AttributeRouting.git",
                @"028202b2f72d5fb139e6d9970430e077f421efc2", 385)]
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.OrmLite.git",
                @"0af1405cd208c2c1b06d17b115f7344adc9e6557", 384)]
        [TestCase(@"https://github.com/JeremySkinner/FluentValidation.git",
                @"7803000a4c709347b862ac5b8d500c175dfc460a", 381)]
        [TestCase(@"https://github.com/elasticsearch/elasticsearch-net.git",
                @"903060e3094de06d01a88b32ed07e588701391aa", 377)]
        [TestCase(@"https://github.com/mikehadlow/EasyNetQ.git",
                @"74a5178fd9d85f316c34f5f2c13fe2e4bb0107d8", 374)]
        [TestCase(@"https://github.com/DarthFubuMVC/fubumvc.git",
                @"371eeac6d32da0c5fa73892f432c27cb1fc207d8", 371)]
        [TestCase(@"https://github.com/kayak/kayak.git",
                @"f3fb78490243ee59d100811e802a0dd5b6f3daae", 365)]
        [TestCase(@"https://github.com/JoshClose/CsvHelper.git",
                @"b5d0563510bafcf1cbba7ed3423d6b9d19349a46", 358)]
        [TestCase(@"https://github.com/structuremap/structuremap.git",
                @"a1fdad054fabd10b129b17ec36cb78f7e2331ae4", 357)]
        [TestCase(@"https://github.com/MarkNijhof/Fohjin.git",
                @"e22c7e147f682c73032aa4f6a8295c63d9c13185", 357)]
        [TestCase(@"https://github.com/jbevain/cecil.git",
                @"b6cc4bb1dbe489170af429b87a5802182e27a37a", 356)]
        [TestCase(@"https://github.com/brockallen/BrockAllen.MembershipReboot.git",
                @"55ff159604b74c719c02aaaf85c99bd316a7dcca", 355)]
        [TestCase(@"https://github.com/mathnet/mathnet-numerics.git",
                @"515ebee32b1a40a7822f98e965bb8b81651f8b5e", 352)]
        [TestCase(@"https://github.com/jamietre/CsQuery.git",
                @"aba9f82fffe79d0827a429f088565dc243e23545", 351)]
        [TestCase(@"https://github.com/Rduerden/Node.cs.git",
                @"1e5c77f2ef8f7b524656763c4c371f7aee966f4a", 348)]
        [TestCase(@"https://github.com/danielcrenna/tweetsharp.git",
                @"e3d00e44aad40419b215a6f9a591b989d25519d6", 347)]
        [TestCase(@"https://github.com/mono/monotouch-bindings.git",
                @"e8cdef83e2e877af51992b8a3c9fd30879851f3d", 340)]
        [TestCase(@"https://github.com/liveservices/LiveSDK.git",
                @"8912c05e19a83b34718ffff1930936a007ce5294", 339)]
        [TestCase(@"https://github.com/qianlifeng/Wox.git",
                @"b07d1b027c42c045bce8304b40b4c27e4d03248f", 336)]
        [TestCase(@"https://github.com/xamarin/mobile-samples.git",
                @"c2e0e43d9ccf7734efd551744bfe24959f4504a0", 332)]
        [TestCase(@"https://github.com/clojure/clojure-clr.git",
                @"0a23829782aca9005f0db733c46a6ce65262020c", 332)]
        [TestCase(@"https://github.com/xebecnan/UniLua.git",
                @"c3ca0e543970928302b5b21e83a9b913ec710173", 329)]
        [TestCase(@"https://github.com/jkowalski/NLog.git",
                @"72f649596504d832eae0b9535c2d2e7583382182", 328)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            var exp = new CSharpComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "csharp_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.cs");
        }
    }
}