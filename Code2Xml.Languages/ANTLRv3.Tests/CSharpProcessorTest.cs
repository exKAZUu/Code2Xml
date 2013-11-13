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
		[TestCase(@"class Klass { void main() {} }")]
		[TestCase(@"class Klass {
#region
void main() { /* comment */ } // comment2
#endregion
}")]
		[TestCase(@"class Klass { void main() {
	for (int i = 1; i < 2; i++) Console.WriteLine();
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
	}
}