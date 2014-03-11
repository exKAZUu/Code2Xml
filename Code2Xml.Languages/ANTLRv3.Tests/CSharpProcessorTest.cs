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

using System.IO;
using Code2Xml.Core;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.ANTLRv3.Processors.CSharp;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class CSharpProcessorTest : ProcessorTest {
		protected override Processor CreateProcessor() {
			return new CSharpProcessorUsingAntlr3();
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
		[TestCase(@"class K { void m() { var b = from p in a group p by (int)1 into x select x; } }")]
		[TestCase(@"class K { void m() { var b = from p in a group p by (p.X) into x select x; } }")]
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
		public void Test() {
			var path = Fixture.GetInputProjectPath("CSharp", "MediaPortal-1");
			new CSharpProcessorUsingAntlr3()
					.GenerateXml(
							new FileInfo(
									Path.Combine(path, "mediaportal", "Utils", "Web", "html", "HtmlString.cs")),
							null, true);
		}

		[Test]
		[TestCase("https://github.com/MuMech/MechJeb2/releases/tag/v2.1.1")] //  39453 ms (69 files)
		[TestCase("MediaPortal-1")] // 335704 ms (2787 files)
		[TestCase("MonoTouch.Dialog")] //   2328 ms (31 files)
		[TestCase("Nancy")] //  24187 ms (813 files)
		[TestCase("Newtonsoft.Json")] //  30765 ms (477 files)
		[TestCase("NuGetGallery")] //  24235 ms (764 files)
		[TestCase("ServiceStack")] //  80156 ms (3335 files)
		[TestCase("SignalR")] //  35469 ms (702 files)
		[TestCase("StarryboundServer")] //   4922 ms (54 files)
		[TestCase("moq4")] //   6640 ms (226 files)
		[TestCase("ravendb")] // 176156 ms (4041 files)
		public void ParseDirectory(string fileName) {
			VerifyRestoringProjectDirectory("CSharp", fileName, "*.cs");
		}
	}
}