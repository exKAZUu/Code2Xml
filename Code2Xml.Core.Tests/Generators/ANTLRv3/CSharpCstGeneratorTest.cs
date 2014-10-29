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
using Antlr.Runtime;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.CSharp;
using NUnit.Framework;
using csLexer = Code2Xml.Languages.ANTLRv3.Processors.CSharp.csLexer;
using csParser = Code2Xml.Languages.ANTLRv3.Processors.CSharp.csParser;

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
        [TestCase(@"https://github.com/SignalR/SignalR",
                @"af938bc188ddeb9bab6c32a66907e120fb252c6d", 4558)]
        [TestCase(@"https://github.com/hbons/SparkleShare",
                @"264506a9b98f461a4a4e42bac109d88e164971a7", 3217)]
        //[TestCase(@"https://github.com/mono/mono",
        //        @"45d831259bbeed78b13205b3ce70324970c6442b", 2586)]
        [TestCase(@"https://github.com/ServiceStack/ServiceStack",
                @"c2b30eaacbbfdf8cdfebcdeebe9b9fe03e920784", 2558)]
        [TestCase(@"https://github.com/NancyFx/Nancy",
                @"45c2cc1f07c21081c00e6a40e79c468a3c9dba7c", 2454)]
        //[TestCase(@"https://github.com/mono/MonoGame",
        //        @"1b06b97fa47beb9bd3dd0d62626f40b073fdd053", 2347)]
        //[TestCase(@"https://github.com/AutoMapper/AutoMapper",
        //        @"de2aa09f18738ad37b339ba9bfbba644ab4611a8", 2186)]
        [TestCase(@"https://github.com/adamcaudill/Psychson",
                @"4522989aac27aada5f522675b33a2bde63a13b30", 2119)]
        [TestCase(@"https://github.com/restsharp/RestSharp",
                @"3ac91252c02e4038b74d92a81b26719fb13001e6", 2097)]
        [TestCase(@"https://github.com/Redth/PushSharp",
                @"1832ebbd3f42f37d10305c246a2810ee4cf7c259", 2076)]
        //[TestCase(@"https://github.com/StackExchange/dapper-dot-net",
        //        @"8e33a56df1e7535434405ad32a6c3bae59f3dcd5", 1654)]
        [TestCase(@"https://github.com/opserver/Opserver",
                @"1336763435659401a896e590deda737caad225e4", 1620)]
        [TestCase(@"https://github.com/OpenRA/OpenRA",
                @"0f50d0bf49c851d4f0d7201d72c1e0a9d3ba2516", 1440)]
        [TestCase(@"https://github.com/robconery/massive",
                @"37699cc39e72b1080d80358ffe9183e3f4cfd4b2", 1299)]
        [TestCase(@"https://github.com/jaredpar/VsVim",
                @"34a2bbc6370f7e2ec087173619b843a333278007", 1279)]
        [TestCase(@"https://github.com/JamesNK/Newtonsoft.Json",
                @"70d3e9327d5dcd9a1770b3aed5437d6aa0b15802", 1232)]
        //[TestCase(@"https://github.com/ravendb/ravendb",
        //        @"d0198ae2adef266dee2eb68e121eff39fde7225a", 1225)]
        //[TestCase(@"https://github.com/SonyWWS/ATF",
        //        @"0ff57f7de853c2cd08f6a59e3e0320c1c5ce1d97", 1202)]
        [TestCase(@"https://github.com/reactiveui/ReactiveUI",
                @"7c3cd0cbfb198cc8de5cd60c62196708b33fac1e", 1191)]
        //[TestCase(@"https://github.com/mono/monodevelop",
        //        @"a56951526cd7c6f89361b93e546d8bfacbd1a513", 1152)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            Action<string> parse = code => {
                var parser =
                        new csParser(
                                new CommonTokenStream(new csLexer(new ANTLRStringStream(code))));
                parser.TraceDestination = Console.Error;
                var ret = parser.compilation_unit();
            };
            MeasurePerformance(url, commitPointer, parse, "*.cs");
        }
    }
}