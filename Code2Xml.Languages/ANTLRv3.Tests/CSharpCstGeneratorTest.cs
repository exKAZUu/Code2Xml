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
        [TestCase(@"https://github.com/NancyFx/Nancy.git",
                @"333096e9d4b50e715260acf6e7fd73ebd63def69")]
        [TestCase(@"https://github.com/JamesNK/Newtonsoft.Json.git",
                @"fdb2811bae10dd285a155e07cb8ea1c2e7683a3a")]
        [TestCase(@"https://github.com/NuGet/NuGetGallery.git",
                @"50ec4075f82d0dde0dcb9b94f991185c39e13326")]
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.git",
                @"2c14c23396996115d8120042168c6282a8b1a3c7")]
        [TestCase(@"https://github.com/SignalR/SignalR.git",
                @"2f6649e9b6c645daed59eae7e893b0d0dcd9840d")]
        [TestCase(@"https://github.com/AvilanceLtd/StarryboundServer.git",
                @"2a89b59f28959257aceba1b542b7b1d6b41e2b0b")]
        [TestCase(@"https://github.com/Moq/moq4.git",
                @"3c3eab9d2f10357b3ee1655984d1eea0d3010a0b")]
        [TestCase(@"https://github.com/ravendb/ravendb.git",
                @"cd5e3234276082bef217dd87e69eaaca0078dc46")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.cs");
        }
    }
}