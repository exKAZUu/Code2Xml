#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
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

using Code2Xml.Core;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.ANTLRv3.Processors.CSharp;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class CSharpProcessorTest : ProcessorTest {
		protected override Processor CreateProcessor() {
			return new CSharpProcessorUsingAntlr3();
		}

		[Test]
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
		[TestCase("NuGetGallery")]
		[TestCase("SignalR")]
		public void ParseDirectory(string fileName) {
			VerifyRestoringProjectDirectory("CSharp", fileName, "*.cs");
		}
	}
}