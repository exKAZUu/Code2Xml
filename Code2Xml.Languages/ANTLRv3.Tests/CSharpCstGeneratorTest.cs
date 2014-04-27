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
        [TestCase(@"https://github.com/todbot/blink1.git",
                @"afbb60c8a3c586770a2f244ea8a3907fd020ba53", 327)]
        [TestCase(@"https://github.com/loresoft/msbuildtasks.git",
                @"fa3b1cb19afb83c6a005547d00465b7233cf5ab7", 324)]
        [TestCase(@"https://github.com/mono/xwt.git",
                @"11b0131af050526dad2c105ce74cfb085c2450ff", 323)]
        [TestCase(@"https://github.com/mspnp/cqrs-journey-code.git",
                @"dbb9b8a28eedbb0e03463d03091f44ff0c935567", 323)]
        [TestCase(@"https://github.com/ncqrs/ncqrs.git",
                @"09ef321d1ad6dcea30584e586ade9526104c6e51", 320)]
        [TestCase(@"https://github.com/DropNet/DropNet.git",
                @"ee955df5a86ccba3a50e6e3f1db8ab2e1dc10fb9", 317)]
        [TestCase(@"https://github.com/sixthsense/sixthsense.git",
                @"d0185b77c5ffdd8d0e07a87a98424db3cc21f76a", 315)]
        [TestCase(@"https://github.com/Jessecar96/SteamBot.git",
                @"5af6a0b85a82620862236077336964b4b76b19b5", 311)]
        [TestCase(@"https://github.com/VerbalExpressions/CSharpVerbalExpressions.git",
                @"245a871122b6233c1911911553539fd6735d5556", 310)]
        [TestCase(@"https://github.com/OpenCover/opencover.git",
                @"4bd5079ef2cde7410a42a5af1494857eee6231ba", 309)]
        [TestCase(@"https://github.com/richhickey/clojure-clr.git",
                @"2c7e20cd3c6ffc64b783ddb3cb7984fb93472ad4", 308)]
        [TestCase(@"https://github.com/mausch/SolrNet.git",
                @"f29b03107c1922226f888a64f0ed0b848c56fb54", 305)]
        [TestCase(@"https://github.com/nsubstitute/NSubstitute.git",
                @"d787176463bde8a9793709756575a37b1acf8c17", 303)]
        [TestCase(@"https://github.com/icsharpcode/NRefactory.git",
                @"3f78bdbedb78cc3e3023bdfbeda016de194acffd", 300)]
        [TestCase(@"https://github.com/WebApiContrib/WebAPIContrib.git",
                @"fe88ff3c0b3871c77b062dbbe9a8ff87107b1d9e", 298)]
        [TestCase(@"https://github.com/loresoft/EntityFramework.Extended.git",
                @"2a999b949530458edc4fd39861e52e043295177d", 298)]
        [TestCase(@"https://github.com/NyxStudios/TShock.git",
                @"61d05ffdc6b3fb9544be72d333585a8aace835da", 297)]
        [TestCase(@"https://github.com/Haacked/SeeGit.git",
                @"3c47da93e5d4260612daa8aff3c6ce97da672936", 295)]
        [TestCase(@"https://github.com/timheuer/callisto.git",
                @"fb9cbac2ccc7900cecf69f722045ca881dbddba3", 290)]
        [TestCase(@"https://github.com/thinktecture/Thinktecture.IdentityModel.45.git",
                @"a2fed40e655beac76f54f11dde1c3b907079a4d1", 289)]
        [TestCase(@"https://github.com/Lokad/lokad-cqrs.git",
                @"75e16de6103c3a6fd9d59846ccea6eeb88185dca", 289)]
        [TestCase(@"https://github.com/Fody/Fody.git",
                @"77a985ae84e22c032de7f6fb29ed259ec804e5dd", 286)]
        [TestCase(@"https://github.com/AutoFixture/AutoFixture.git",
                @"f945ef7e65477f23f89e96d3a6302b7a96d0cf37", 285)]
        [TestCase(@"https://github.com/playgameservices/play-games-plugin-for-unity.git",
                @"3ad9798396cc5e443815d5c1438bcebc54d98ed9", 282)]
        [TestCase(@"https://github.com/erichexter/twitter.bootstrap.mvc.git",
                @"d3275c3e0c1d9f061a15442cb2d400133b63c137", 281)]
        [TestCase(@"https://github.com/MassTransit/MassTransit.git",
                @"b7cd961d72deec199542e9ee256154671873f54a", 278)]
        [TestCase(@"https://github.com/maartenba/MvcSiteMapProvider.git",
                @"92ad5eb87a16597c2b18cbb6daf56a4491a652c9", 277)]
        [TestCase(@"https://github.com/Moq/moq4.git",
                @"ac31aeca01056e3608540d5b5d043ba013f19abe", 276)]
        [TestCase(@"https://github.com/Azure/azure-sdk-tools.git",
                @"94432b2152a43d544df8a06c6b60d60d79ed6aee", 274)]
        [TestCase(@"https://github.com/mono/monotorrent.git",
                @"3c201b9e3c68b33243a7af61678fb948a0189461", 274)]
        [TestCase(@"https://github.com/robconery/biggy.git",
                @"0c7a0cb8f08b0ac7e5d87f91c5617d4cc6e21b84", 272)]
        [TestCase(@"https://github.com/sestoft/C5.git",
                @"0350623579519d17494da788744ecfad4857cfee", 272)]
        [TestCase(@"https://github.com/jdiamond/Nustache.git",
                @"957a95f26265876a42dcd8934708bab95d01ef87", 269)]
        [TestCase(@"https://github.com/statianzo/Fleck.git",
                @"06837f548345fa06e91c01312a0f5c18fd6f012f", 269)]
        [TestCase(@"https://github.com/MarlabsInc/SocialGoal.git",
                @"d6cc337d3f97be6f3fec5b66aa2c8982e800c98c", 263)]
        [TestCase(@"https://github.com/danielcrenna/metrics-net.git",
                @"4b4b5dd49eedd387ac0b2423be402ce6e20a4d87", 260)]
        [TestCase(@"https://github.com/Compilify/Compilify.git",
                @"dc523cffd6205a142e70f45c735f87a1eb40a712", 252)]
        [TestCase(@"https://github.com/gsscoder/commandline.git",
                @"a3fa34f261fe5511f2c8bd7d259f3906b1688e2c", 251)]
        [TestCase(@"https://github.com/Code52/pretzel.git",
                @"90b1739e9d1fbe397e9ff20ca5f2d1526d5d5c61", 249)]
        [TestCase(@"https://github.com/FakeItEasy/FakeItEasy.git",
                @"d8c919b852e7668217d5463cbe20d97402bde61a", 247)]
        [TestCase(@"https://github.com/bamboo/boo.git",
                @"6a1040dfa2ee35a39b0a05b7b252695662c8a7fb", 238)]
        [TestCase(@"https://github.com/ShareX/ShareX.git",
                @"110277b4196986e4e8e0dcfab7ef457942d92c7d", 235)]
        [TestCase(@"https://github.com/chucknorris/roundhouse.git",
                @"812f4debbb0f31896af08e9ef1dd0b47f1686882", 234)]
        [TestCase(@"https://github.com/zeromq/clrzmq.git",
                @"76404a94e0a0bbb0aff23e5500eb5af0a70bda05", 234)]
        [TestCase(@"https://github.com/enyim/EnyimMemcached.git",
                @"62d1cbfc397fca400feeed68ff91844d2874624c", 234)]
        [TestCase(@"https://github.com/0xd4d/de4dot.git",
                @"7222bdbe426f4296c93517551022efc82cd5b9cd", 232)]
        [TestCase(@"https://github.com/David20321/FTJ.git",
                @"802f54b31eebd3831ee9a7732146f9859d1074e5", 230)]
        [TestCase(@"https://github.com/grumpydev/TinyIoC.git",
                @"fda59bd5cb53864835ff8b025e31ef10a7a77f68", 228)]
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.Examples.git",
                @"8eafa0b5bc45976e1cdbe54240df0a5b90f124e5", 227)]
        [TestCase(@"https://github.com/Olivine-Labs/Alchemy-Websockets.git",
                @"42c00b6d29116834432de37ea77fa954b093bc74", 226)]
        [TestCase(@"https://github.com/mrward/monodevelop-nuget-addin.git",
                @"f593536fcd779f4e819def961c676e392eee0ff3", 225)]
        [TestCase(@"https://github.com/ninject/ninject.web.mvc.git",
                @"41b0136be6d265f82396d382ac87d999eb981a87", 224)]
        [TestCase(@"https://github.com/thedillonb/CodeHub.git",
                @"a6272d13f4db89f99e9ce6afb7f88a1f987a969c", 224)]
        [TestCase(@"https://github.com/Azure/azure-mobile-services.git",
                @"2deee4c26a010a1411d2f6f2d104a6a76aef9159", 223)]
        [TestCase(@"https://github.com/Redth/APNS-Sharp.git",
                @"4a5919f753127ebf2b4600f64591a5f3cdc68b28", 223)]
        [TestCase(@"https://github.com/mono/monomac.git",
                @"99fc8d74c5357325c42de4bc5eb4594bf792c392", 223)]
        [TestCase(@"https://github.com/AArnott/IronPigeon.git",
                @"225a50009f396ac1b8cde599a1b67ef25c96f9cd", 220)]
        [TestCase(@"https://github.com/MediaBrowser/MediaBrowser.git",
                @"026fd77a0b8cfa353ad8212c0b32111de74cb932", 216)]
        [TestCase(@"https://github.com/n2cms/n2cms.git",
                @"04f1a6ce84311561c81576c1a7d6deac968ac982", 215)]
        [TestCase(@"https://github.com/real-logic/simple-binary-encoding.git",
                @"0741472eaf8cec63d2f41e6d97c3cc9952941874", 214)]
        [TestCase(@"https://github.com/pbhogan/InControl.git",
                @"f431490f92dd15f5684e2067e6b6ae0b27a77a85", 214)]
        [TestCase(@"https://github.com/viperneo/winforms-modernui.git",
                @"f76aa9a781d3f2051942253fc1f12b6d9fbe49f9", 214)]
        [TestCase(@"https://github.com/srkirkland/DataAnnotationsExtensions.git",
                @"b1f9af625edfaa5b0573eeb2ad89213a63665766", 214)]
        [TestCase(@"https://github.com/ccnet/CruiseControl.NET.git",
                @"ef2dfcc5364d9219d142287399642f5716cbd998", 213)]
        [TestCase(@"https://github.com/danielcrenna/hammock.git",
                @"2f2ace45511d0571ecea2202fc90d339853862cf", 213)]
        [TestCase(@"https://github.com/ricardojmendez/UnitySteer.git",
                @"77ebf2ee07c883e4d95c6cbd5eb16537ec0a8c3a", 208)]
        [TestCase(@"https://github.com/ayende/rhino-mocks.git",
                @"0f0f0557f8f383062327876045933dccfd6e7681", 204)]
        [TestCase(@"https://github.com/koush/UniversalAdbDriver.git",
                @"a6d6fd72f524feacc9f9a462e5d1a0cd27357899", 204)]
        [TestCase(@"https://github.com/jsonfx/jsonfx.git",
                @"bebad51d6c61188dd348b5951716b863aa6a91cc", 203)]
        [TestCase(@"https://github.com/MITGameLab/OpenRelativity.git",
                @"4036fb72915e59e7a940e7d8447b654c6f16ae59", 202)]
        [TestCase(@"https://github.com/sharpdx/SharpDX.git",
                @"dfe4bc426f92732f990a7ae13adde34e1967bb7f", 201)]
        [TestCase(@"https://github.com/npgsql/Npgsql.git",
                @"554c4d61630db0451e5765bd04db647e114d6d9e", 200)]
        [TestCase(@"https://github.com/apache/lucene.net.git",
                @"d7a8976051ab94f046661725660b52e66fc762a9", 199)]
        [TestCase(@"https://github.com/prime31/GoKit.git",
                @"dd03dab39afd9cc9991393daf5bf1dfb327a7f7f", 199)]
        [TestCase(@"https://github.com/mono/ngit.git",
                @"292a4e4ff81d1c4f59b04cd2b9bc1a1f588fa4eb", 199)]
        [TestCase(@"https://github.com/mwrock/RequestReduce.git",
                @"fe4f794336e7d347afcf92ab02557750157f198d", 199)]
        [TestCase(@"https://github.com/dockpanelsuite/dockpanelsuite.git",
                @"a04dc1a8f062f1d80e12ff231a3454521786dc88", 199)]
        [TestCase(@"https://github.com/jaymedavis/stripe.net.git",
                @"fe7348bc22c755e9feb1ec261db1728b3e6cc497", 198)]
        [TestCase(@"https://github.com/SimpleAuthentication/SimpleAuthentication.git",
                @"1e1e29ad0795f608bd6620e9e4ee2aa23ac53b1a", 196)]
        [TestCase(@"https://github.com/SparkViewEngine/spark.git",
                @"2487d4fe7c8820ed4be956ffbce6a409ed8c6717", 193)]
        [TestCase(@"https://github.com/disruptor-net/Disruptor-net.git",
                @"8fc6cde3b6f806d05c16b931113cd82ba68180d6", 193)]
        [TestCase(@"https://github.com/erik-kallen/SaltarelleCompiler.git",
                @"d13bccaeb825ed2c3709b5cf5f2db668987f9a68", 192)]
        [TestCase(@"https://github.com/featurist/coypu.git",
                @"23938a9abc9bb36e39ccf041edc9a106da769867", 192)]
        [TestCase(@"https://github.com/hhariri/EasyHttp.git",
                @"c647610cd0a126d6a534f9818a3e1bebd19c37c3", 192)]
        [TestCase(@"https://github.com/ASP-NET-MVC/aspnetwebstack.git",
                @"d4cb4a90d09686c0dd8cdba9920c643eb04f6ca4", 192)]
        [TestCase(@"https://github.com/openrasta/openrasta-stable.git",
                @"49d8498f52583ef97b82d4d01dd1dfebef665648", 190)]
        [TestCase(@"https://github.com/yysun/Git-Source-Control-Provider.git",
                @"dd8bd933482600f2caf5c2dd935327fbfde8b057", 187)]
        [TestCase(@"https://github.com/autofac/Autofac.git",
                @"8c0732e120b55d277dc9313827fe02bbde289f3e", 184)]
        [TestCase(@"https://github.com/CartBlanche/MonoGame-Samples.git",
                @"2a2528583473bb0195a70c24c8b111c286962baa", 184)]
        [TestCase(@"https://github.com/phatboyg/Stact.git",
                @"0dc52852ffbbbeac937045269314af089e7e7af7", 183)]
        [TestCase(@"https://github.com/NLua/NLua.git",
                @"a766ff3a45c5edd4e1ce9654b180db5083f26489", 180)]
        [TestCase(@"https://github.com/filipw/AspNetWebApi-OutputCache.git",
                @"e03d6b257582dab3575fd8e86e93c421125376f4", 178)]
        [TestCase(@"https://github.com/mono/taglib-sharp.git",
                @"a5f6949a53d09ce63ee7495580d6802921a21f14", 178)]
        [TestCase(@"https://github.com/akkadotnet/akka.net.git",
                @"25b66cc2d62fc2bfc50cd4050ac6fdd6909063fa", 177)]
        [TestCase(@"https://github.com/joliver/CommonDomain.git",
                @"c7d3ca18d33ca3d056cb806ab8876d96cfe7a0a8", 175)]
        [TestCase(@"https://github.com/repetier/Repetier-Host.git",
                @"f5d808611a57c7aeb4f3aa6a5c70446f11f63c54", 175)]
        [TestCase(@"https://github.com/sprache/Sprache.git",
                @"744a80ea6b87bedf22e1ec4452ade8f8f5dc1fd1", 175)]
        [TestCase(@"https://github.com/andyedinborough/aenetmail.git",
                @"0b2d3f16578fbf39136f78853c3bcb8728895490", 174)]
        [TestCase(@"https://github.com/fdorg/flashdevelop.git",
                @"1b8c0f1f64775873015548fb80bd4baa1c9bdadd", 174)]
        [TestCase(@"https://github.com/turquoiseowl/i18n.git",
                @"8d0dd7b84707efdd04c8d3be889ed9b2c90ff8ae", 173)]
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