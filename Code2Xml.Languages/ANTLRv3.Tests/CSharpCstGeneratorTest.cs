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
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.CSharp;
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
        [TestCase(@"https://github.com/MuMech/MechJeb2.git",
                @"2837dbac38f59520ff840c479a242228c88ab485")]
        [TestCase(@"https://github.com/MediaPortal/MediaPortal-1.git",
                @"bb1af6b26eb596ba953c9a2d307313840f43f93f")]
        [TestCase(@"https://github.com/migueldeicaza/MonoTouch.Dialog.git",
                @"921612a37a282d2d32512e2d94465d0ed845f457")]
        [TestCase(@"https://github.com/NuGet/NuGetGallery.git",
                @"50ec4075f82d0dde0dcb9b94f991185c39e13326")]
        [TestCase(@"https://github.com/AvilanceLtd/StarryboundServer.git",
                @"2a89b59f28959257aceba1b542b7b1d6b41e2b0b")]
        [TestCase(@"https://github.com/MehdiK/Humanizer.git",
                @"b51cc6715acde38f674dfd84ae02188be0547702")] // Star: 503
        [TestCase(@"https://github.com/NancyFx/Nancy.git",
                @"e069dfbc326af4552f79b55b12c6966305baad79")] // Star: 2104
        [TestCase(@"https://github.com/mono/MonoGame.git",
                @"73fc2954b0cd83a4a7f3ddecdc56f155ff135e99")] // Star: 1996
        [TestCase(@"https://github.com/SignalR/SignalR.git",
                @"b940230aedc851c50775c2ed32ab96c476f10ec6")] // Star: 4108
        [TestCase(@"https://github.com/JamesNK/Newtonsoft.Json.git",
                @"9e2581be74585605b4f49e0110d65c85c17cb323")] // Star: 825
        [TestCase(@"https://github.com/Glimpse/Glimpse.git",
                @"b78f1c8b336e86278efea95c115f8a9a404ab901")] // Star: 691
        [TestCase(@"https://github.com/WebMBro/WebMConverter.git",
                @"07ff15b0e4fdf1b5cf66cf25a71a2d3b88a6f75e")] // Star: 40
        [TestCase(@"https://github.com/shimat/opencvsharp.git",
                @"d337e665265a8ce88773869d2402cad7fc1d21d3")] // Star: 40
        [TestCase(@"https://github.com/mrward/monodevelop-nuget-addin.git",
                @"f593536fcd779f4e819def961c676e392eee0ff3")] // Star: 225
        [TestCase(@"https://github.com/MahApps/MahApps.Metro.git",
                @"36fe5e517e0c65116d288fdabf2e68a2a9494bd9")] // Star: 799
        [TestCase(@"https://github.com/apache/cordova-wp8.git",
                @"30fba42357f8b6cf2e9a433128369c8f4cc914bb")] // Star: 49
        [TestCase(@"https://github.com/magicdict/MagicMongoDBTool.git",
                @"694ab21e1d4e4d3f47c1d9e31527c96b2a0e29bc")] // Star: 92
        [TestCase(@"https://github.com/sharpdx/SharpDX.git",
                @"65799e012fa2200748b16095aebb7b9427a6fb16")] // Star: 201
        [TestCase(@"https://github.com/hbons/SparkleShare.git",
                @"4085f1937041d89f76829336119f8b68ce97b43c")] // Star: 3033
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.git",
                @"6cb92e0429e2cce31ef68e4fa02801718b00dd4f")] // Star: 2285
        [TestCase(@"https://github.com/mono/mono.git",
                @"81bdc35dd4b800831efc540be9705e021f8b848a")] // Star: 2056
        [TestCase(@"https://github.com/AutoMapper/AutoMapper.git",
                @"bc2ece165e028b4dbe963d978ef54e1ed2b50f5f")] // Star: 1853
        [TestCase(@"https://github.com/restsharp/RestSharp.git",
                @"70be25dae0edb44a1c962aee078e9dbf74cb4177")] // Star: 1828
        [TestCase(@"https://github.com/Redth/PushSharp.git",
                @"19216ead2bfbbf36c4fcaa95dfa8469facc5a7ef")] // Star: 1688
        [TestCase(@"https://github.com/opserver/Opserver.git",
                @"a170ea8bcda9f9e52d4aaff7339f3d198309369b")] // Star: 1324
        [TestCase(@"https://github.com/robconery/massive.git",
                @"87075153609fe096bcbd9f81a6901c1b60e2e579")] // Star: 1203
        [TestCase(@"https://github.com/SamSaffron/dapper-dot-net.git",
                @"885a8d46cbd67f09bd6a5e686a824759d79d5f78")] // Star: 1182
        [TestCase(@"https://github.com/ravendb/ravendb.git",
                @"a60d8dd3ffaf5892d86d5fcf8a9a81bec71800e7")] // Star: 1118
        [TestCase(@"https://github.com/SamSaffron/MiniProfiler.git",
                @"3744054e0686b2f88083b869a7f2fe7e1fa14e9c")] // Star: 1113
        [TestCase(@"https://github.com/jaredpar/VsVim.git",
                @"86d9e298c9d117e54266501ae9c4dd35b4d345cb")] // Star: 1097
        [TestCase(@"https://github.com/mono/roslyn.git",
                @"35ebc72b4fde323dde2c372d70ecd6437de97c4c")] // Star: 46
        [TestCase(@"https://github.com/PlasmaByte/PokemonNXT.git",
                @"8cf7d43119ea1a7cba4f8711472efefb54bb53fb")] // Star: 34
        [TestCase(@"https://github.com/robconery/biggy.git",
                @"0c7a0cb8f08b0ac7e5d87f91c5617d4cc6e21b84")] // Star: 266
        [TestCase(@"https://github.com/jstedfast/MailKit.git",
                @"3ef47b326f89a4a6ad960c9fcca00bdbac18a227")] // Star: 122
        [TestCase(@"https://github.com/madskristensen/WebEssentials2013.git",
                @"e422af47986bfd6c70ee6564cb1bf892cbf197f8")] // Star: 489
        [TestCase(@"https://github.com/jamesmontemagno/Xam.PCL.Plugins.git",
                @"0e6151295a2dba17f77c90034e4820ca42a941d9")] // Star: 28
        [TestCase(@"https://github.com/xamarin/xamarin-store-app.git",
                @"a68dcd6f07a45a127c6ed9af21fc8084f1b3bcb5")] // Star: 38
        [TestCase(@"https://github.com/StephanieRct/NieMath.git",
                @"9a4a49ab374d1652c3568ea5960b0de9a0218ea1")] // Star: 32
        [TestCase(@"https://github.com/MvvmCross/MvvmCross.git",
                @"fd16e13d05678e578ddc96938a680b3d94d8a496")] // Star: 706
        [TestCase(@"https://github.com/reactiveui/ReactiveUI.git",
                @"45aaa51f5d5202a5c8d34ea3151955f0bce8a956")] // Star: 888
        [TestCase(@"https://github.com/Moq/moq4.git",
                @"ac31aeca01056e3608540d5b5d043ba013f19abe")] // Star: 273
        [TestCase(@"https://github.com/xunit/xunit.git",
                @"075bedaa4a25ca407b6a73f4e5c2f68298618967")] // Star: 137
        [TestCase(@"https://github.com/playgameservices/play-games-plugin-for-unity.git",
                @"3ad9798396cc5e443815d5c1438bcebc54d98ed9")] // Star: 281
        [TestCase(@"https://github.com/qianlifeng/Wox.git",
                @"b07d1b027c42c045bce8304b40b4c27e4d03248f")] // Star: 334
        [TestCase(@"https://github.com/serilog/serilog.git",
                @"60e8120a12abee4db942d2ff03b123341fab1fff")] // Star: 161
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "csharp_repo.txt", "*.cs");
        }
    }
}