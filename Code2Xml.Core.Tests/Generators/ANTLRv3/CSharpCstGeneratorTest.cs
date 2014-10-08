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

using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.CSharp;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3 {
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
        [TestCase(@"https://github.com/openrasta/openwrap.git",
                @"9161caebbe699e3912995a089a35c2d68a013772", 172)]
        [TestCase(@"https://github.com/SteamRE/SteamKit.git",
                @"90cdecb2db34c03ef85f4e1d763930f17f0f38b6", 172)]
        [TestCase(@"https://github.com/sones/sones.git",
                @"773b7a7dbbad6032e18a28e011111a1fc2d37447", 172)]
        [TestCase(@"https://github.com/tmsmith/Dapper-Extensions.git",
                @"82a6c3f6a3ef37c6d6df129daf5face3aae196b5", 170)]
        [TestCase(@"https://github.com/markrendle/Simple.Web.git",
                @"b702f9c4b825c8c73a626ba4595d9ee31bc6ee39", 169)]
        [TestCase(@"https://github.com/InteractiveLab/TouchScript.git",
                @"f9d16e3a1bfcdc5e0221a52ab672bec8178b871c", 169)]
        [TestCase(@"https://github.com/igor-tkachev/bltoolkit.git",
                @"fea27c2c0b5b4dfb4af4a078a02a50ee7a1a5947", 168)]
        [TestCase(@"https://github.com/zenogantner/MyMediaLite.git",
                @"6690d45514e1fb40d23b93d0f8ea2c12c82adc17", 168)]
        [TestCase(@"https://github.com/aws/aws-sdk-net.git",
                @"9e518440a29097b56cee96943905b636b9beea74", 167)]
        [TestCase(@"https://github.com/paf31/initialround.git",
                @"6811c12818126106c101ba1c237e0c2d622bdaa7", 166)]
        [TestCase(@"https://github.com/TestStack/White.git",
                @"5fa36b4c59177f2da91e6c8aeb13276014bb9222", 164)]
        [TestCase(@"https://github.com/dnewcome/Node.net.git",
                @"b5cbbb45e6716fb8b05b1ad6d175f8b3c7d8e43d", 163)]
        [TestCase(@"https://github.com/serilog/serilog.git",
                @"f2d638baa8ed47bf824ed784dfb7bd17353b6734", 162)]
        [TestCase(@"https://github.com/paulcbetts/refit.git",
                @"dc0b50d0a634fe4202b6fdfba804a15e58b2b5d7", 162)]
        [TestCase(@"https://github.com/mchidk/BinaryRage.git",
                @"c4651ac248bb6117d68c4662ea8cedf90f8b7a2d", 162)]
        [TestCase(@"https://github.com/Grabacr07/KanColleViewer.git",
                @"dc6717a54be14a5dbe6592879277acc2c2f92c56", 161)]
        [TestCase(@"https://github.com/migueldeicaza/TweetStation.git",
                @"1691b7e173b4dea488af9ed9dc77d9daff855194", 160)]
        [TestCase(@"https://github.com/picoe/Eto.git",
                @"f1f02696eb79d6f35118c515cff5477378009416", 160)]
        [TestCase(@"https://github.com/TehGimp/KerbalMultiPlayer.git",
                @"852346c1fcfcbe939ecbde4587917bda96160a16", 158)]
        [TestCase(@"https://github.com/BlueSpire/Caliburn.Micro.git",
                @"d464ff559d2b2309c2fa085cf107875c8fa4692a", 158)]
        [TestCase(@"https://github.com/twilio/twilio-csharp.git",
                @"8bdf3a14b36c385f2c621990b6c547e00440b659", 157)]
        [TestCase(@"https://github.com/benrhughes/todotxt.net.git",
                @"3cf4522cc1d86a15a76547296f5509186150b4ee", 157)]
        [TestCase(@"https://github.com/JuhaKiili/RagePixel.git",
                @"991aca50d4fdc319a2d82f9d0df92b3b767655df", 156)]
        [TestCase(@"https://github.com/craiggwilson/fluent-mongo.git",
                @"481791637931621c8bbce98e777a6f68caeb1e77", 155)]
        [TestCase(@"https://github.com/sta/websocket-sharp.git",
                @"99f7c9616ef807332e95d70ee286d8a4e48cc65c", 155)]
        [TestCase(@"https://github.com/vc3/Afterthought.git",
                @"35e6ac7be836bb798d89eb5c8150ce0a3ba30f44", 155)]
        [TestCase(@"https://github.com/thinkpixellab/bot.git",
                @"0fe417e5f708a8887e07d1ab02f6711b307e6ac5", 155)]
        [TestCase(@"https://github.com/zeromq/netmq.git",
                @"8cda02a9de96b2254e2288a1d5a7f960ed00c4d0", 154)]
        [TestCase(@"https://github.com/owin/owin.git",
                @"826a356981d5698c6d0619e0574c682a3b696ae5", 153)]
        [TestCase(@"https://github.com/icsharpcode/SharpZipLib.git",
                @"c49a22d70a77819b1dc88309c91e99565aa9099b", 152)]
        [TestCase(@"https://github.com/Haacked/CodeHaacks.git",
                @"74d725b76ba7b43e7cd44b63019b3f711b5eb5eb", 152)]
        [TestCase(@"https://github.com/BinaryConstruct/Terraria-Map-Editor.git",
                @"c92474e23a4b95c4c61bf041789858cb50c80cc4", 151)]
        [TestCase(@"https://github.com/kohsuke/winsw.git",
                @"6250a2755b798726d07a2d7018975b29b65f38ff", 151)]
        [TestCase(@"https://github.com/kellyelton/OCTGN.git",
                @"fcd41ecd45d5f1de75b75b60b6f02f5421ef2498", 150)]
        [TestCase(@"https://github.com/Moq/moq.git",
                @"84221b633dc28da2c09da80a002be2a3aadcadb4", 149)]
        [TestCase(@"https://github.com/DmitryEfimenko/TwitterBootstrapMvc.git",
                @"0a561811a1b7189e49ee84fb3e2bf6864339e830", 148)]
        [TestCase(@"https://github.com/NuGet/WebBackgrounder.git",
                @"2c1df6aa80ddd4ee235a263e3474ef93984822da", 148)]
        [TestCase(@"https://github.com/hibernating-rhinos/rhino-esb.git",
                @"b4c4b697afed0a2d7f69cda688cbe8012b085782", 147)]
        [TestCase(@"https://github.com/paulyoder/LinqToExcel.git",
                @"235327996a79a510ce56328e949f8a947467f411", 146)]
        [TestCase(@"https://github.com/exceptionless/Exceptionless.git",
                @"021f217817d5bd2d0710034b64944982781c4881", 145)]
        [TestCase(@"https://github.com/jstedfast/MimeKit.git",
                @"a70df702d6828141d1f94136c5f23eb2c8b2cbae", 144)]
        [TestCase(@"https://github.com/phatboyg/Magnum.git",
                @"c9626b133a67185c5befff907cf45be9ff2c72ea", 144)]
        [TestCase(@"https://github.com/DarthFubuMVC/htmltags.git",
                @"5da6715c23d1a04bc384bd1a2ff2c2e9bb4b1eec", 143)]
        [TestCase(@"https://github.com/MicrosoftResearchSVC/Naiad.git",
                @"7ceaced529bb747713ba19307f6d2e5151eec899", 143)]
        [TestCase(@"https://github.com/phendryx/superputty.git",
                @"ce95576eb6cb6ad6d6393784edae1f0a62438d23", 143)]
        [TestCase(@"https://github.com/jgeurts/FluentScheduler.git",
                @"e6bac58d8e6809440da53b759105de8a7872479a", 143)]
        [TestCase(@"https://github.com/Code52/carnac.git",
                @"2afbceab4d25961445314293c93eae2551f05c44", 142)]
        [TestCase(@"https://github.com/MuMech/MechJeb2.git",
                @"6262cd1176544ba514727b8704399acb27e2cbcc", 141)]
        [TestCase(@"https://github.com/formosatek/dotliquid.git",
                @"d458a2f33fb49bb1c62c7c65f83186f59b39ec79", 141)]
        [TestCase(@"https://github.com/Twitterizer/Twitterizer.git",
                @"ab3fab9ebe0180acf68bfc82e47a736fd2f62eba", 140)]
        [TestCase(@"https://github.com/polyethene/IronAHK.git",
                @"a4ff409341651f5a1b4c637fa9e09de1c84084a3", 140)]
        [TestCase(@"https://github.com/garora/TDD-Katas.git",
                @"9e4bf23e64e51ef173d38fd7ad7d91d91e2a9dbb", 140)]
        [TestCase(@"https://github.com/JeremySkinner/git-dot-aspx.git",
                @"7172adceefc1c9a1fe5ade250a65b9f8290d6cde", 139)]
        [TestCase(@"https://github.com/anurse/git-credential-winstore.git",
                @"f617d1289d5e26f878e7c6e469b4cd60d7f1c056", 139)]
        [TestCase(@"https://github.com/hmemcpy/AgentMulder.git",
                @"56d215466a07004cf68f1233913f065e4ea509c5", 138)]
        [TestCase(@"https://github.com/soomla/unity3d-store.git",
                @"ca2858ae17aedeb1cb650deaf25467133c5e6889", 138)]
        [TestCase(@"https://github.com/WCell/WCell.git",
                @"5ae2d190d2a8c7ef484c841d57ba441645bfc10d", 138)]
        [TestCase(@"https://github.com/xunit/xunit.git",
                @"075bedaa4a25ca407b6a73f4e5c2f68298618967", 138)]
        [TestCase(@"https://github.com/msgpack/msgpack-cli.git",
                @"f5a6ec52c936a083fc2458cd747aec929f689367", 137)]
        [TestCase(@"https://github.com/SirCmpwn/Craft.Net.git",
                @"29f69992e97ccde525971e7fd28f33fed693b450", 136)]
        [TestCase(@"https://github.com/riteshrao/ncommon.git",
                @"c07b5b37d52a5b61d3a04b0b0eb87d9c04e3c9cb", 135)]
        [TestCase(@"https://github.com/manojlds/cmd.git",
                @"fbf81d6d5fda5e80bb4ec6ab3ed91b0bd531eacf", 134)]
        [TestCase(@"https://github.com/cocos2d/cocos2d-x-for-xna.git",
                @"4537342146219d6b7b1a65e6e37a593d03154b08", 133)]
        [TestCase(@"https://github.com/paulcbetts/splat.git",
                @"7f17708b13f6c3db1d3b5505a5211325bd8e1417", 133)]
        [TestCase(@"https://github.com/adamdriscoll/poshtools.git",
                @"23e28bf8a731f19a35d5c823658d8834750cd11b", 133)]
        [TestCase(@"https://github.com/fluentcassandra/fluentcassandra.git",
                @"c25726d83f2fc22d18de6c6f80ef3bd7466c2530", 132)]
        [TestCase(@"https://github.com/NetEase/UnitySocketIO.git",
                @"455010508c297806d8e18de253b9077a5f48b5d9", 132)]
        [TestCase(@"https://github.com/dennisdoomen/fluentassertions.git",
                @"fdfcedb25221ad6443058b631584cab4e5aa2ffe", 131)]
        [TestCase(@"https://github.com/NickCraver/StackExchange.Exceptional.git",
                @"84b8032f6be7d3459541f3432926b735db26c781", 130)]
        [TestCase(@"https://github.com/AdamsLair/duality.git",
                @"e8024f039fcea978a62d1e98855168d0b65a5582", 129)]
        [TestCase(@"https://github.com/Codeusa/Borderless-Gaming.git",
                @"0bfa051f59d94617ddc188a9cb60adfe318d206a", 129)]
        [TestCase(@"https://github.com/ayende/rhino-etl.git",
                @"88104d78c534af5b238283d71b5ab3039711e994", 129)]
        [TestCase(@"https://github.com/NzbDrone/NzbDrone.git",
                @"5bc820efedc769386fe722a0d863b7dae1359c19", 127)]
        [TestCase(@"https://github.com/sorear/niecza.git",
                @"48a8de321378f4c9447831bdc691615096473f0d", 127)]
        [TestCase(@"https://github.com/philiplaureano/LinFu.git",
                @"96c17c8c11d99c755bb02da3b4e35019754a9f33", 127)]
        [TestCase(@"https://github.com/nant/nant.git",
                @"7906a4d7e903b0ee26c466fefa58d7ba730f534c", 126)]
        [TestCase(@"https://github.com/moserware/AES-Illustrated.git",
                @"4de319f46ff331148c63f8cb074332dea8a6b889", 126)]
        [TestCase(@"https://github.com/JetBrains/FSharper.git",
                @"792af6933898342ba450752beacdeaa6d970ba3b", 125)]
        [TestCase(@"https://github.com/SirCmpwn/bf-irc-bot.git",
                @"db5660e0b1cac97bc8d8503fbe2883262b5c3dab", 124)]
        [TestCase(@"https://github.com/stack72/TeamCitySharp.git",
                @"3d2e6b33de5aac7ab4ba64777f9dbdee650c1572", 124)]
        [TestCase(@"https://github.com/fehaar/FFWD.git",
                @"fc98c0fdf119f5c62ec108d3462e3c5b74375ba1", 123)]
        [TestCase(@"https://github.com/Pash-Project/Pash.git",
                @"187b95597cbbb791758902d2bc190c94da6e232b", 123)]
        [TestCase(@"https://github.com/koush/androidmono.git",
                @"6b465fd8e9b576fcff0bd5c975f5dda416502242", 123)]
        [TestCase(@"https://github.com/mono/cxxi.git",
                @"b0796517cb8981c54549f9e480f3511f7b1e043f", 123)]
        [TestCase(@"https://github.com/stirno/FluentAutomation.git",
                @"d65630102cb9ccccbd687665797f9bf57b396810", 123)]
        [TestCase(@"https://github.com/jstedfast/MailKit.git",
                @"e2b6c3187cd458acd1af788eb5b5ce5e5c16f949", 122)]
        [TestCase(@"https://github.com/stevehodgkiss/restful-routing.git",
                @"f517649e9ee77838f01a90b7c7cda63669965a15", 122)]
        [TestCase(@"https://github.com/frabert/NetLua.git",
                @"67bf607bcbe8eac1f3a6b0118699ece5fa43484d", 122)]
        [TestCase(@"https://github.com/wojilu/wojilu.git",
                @"83a2f1c850ec49cee0f40cf8fa71bcd2d8e92313", 122)]
        [TestCase(@"https://github.com/kristofferahl/FluentSecurity.git",
                @"407426d061892422671305386ca48bd4be314154", 121)]
        [TestCase(@"https://github.com/Cocos2DXNA/cocos2d-xna.git",
                @"93a246dbb4b5717a3dfa34daf0ef54c73c2c3293", 121)]
        [TestCase(@"https://github.com/spring-projects/spring-net.git",
                @"a32fee13be53e1f792c0c0cacebe2ab06f276dbb", 121)]
        [TestCase(@"https://github.com/opentween/OpenTween.git",
                @"c5c129e708dc018011134908b928fbee53cecfb6", 120)]
        [TestCase(@"https://github.com/Arctium/Arctium-WoW.git",
                @"5f76e9ecd934e557e3dc250c2bde3566538e7d41", 120)]
        [TestCase(@"https://github.com/ishani/ClangVSx.git",
                @"b3c184e2d2102cd919138ae3cc825eb2ffce613e", 119)]
        [TestCase(@"https://github.com/moserware/Skills.git",
                @"ee312fd39db913de2fc297951dc663e12dc7e504", 118)]
        [TestCase(@"https://github.com/chucknorris/dropkick.git",
                @"d4fc1f090d45364a142a97f81d037e906c58e7fc", 117)]
        [TestCase(@"https://github.com/iloire/ASP.NET-MVC-ACME-Invoicing--App.git",
                @"90829135440c98dfdfd9a8805ee4675968feac30", 117)]
        [TestCase(@"https://github.com/TaoK/PoorMansTSqlFormatter.git",
                @"4fd83bb2c0bfc87410e05385cfe4da6a12f689d1", 117)]
        [TestCase(@"https://github.com/castleproject/Castle.Windsor-READONLY.git",
                @"8e2b032b5e88e6948eda1a4f0f2fb96bd53bcb78", 116)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepo(url, commitPointer, "*.cs");
        }
    }
}