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

using System.Linq;
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
#	define DEBUG
#	region
# if DEBUG
void main() { /* comment */ } // comment2
# else
xxxxx
# endif
# 	 undef DEBUG
#	endregion
}")]
		[TestCase(@"class Klass { void main() {
	for (int i = 1; i < 2; i++) Console.WriteLine();
} }")]
		[TestCase(@"class Klass { void main() { 1.ToString(); } }")]
		[TestCase(@"class Klass { void main() {
			var a = from method in new[] { 123.ToString() }
				group method by method.Length
				into overloads
				let oload = (from overload in overloads
					orderby overload.Length
					select overload).FirstOrDefault()
				orderby oload.Length
				select oload;
} }")]
		[TestCase(@"class Klass {
        Object s = new HashSet<int>(s.s) {};
}")]
		public void Parse(string code) {
			VerifyRestoringCode(code);
		}

		public void Test() {
			var code = @"class Klass {
        Object s = new HashSet<int>(s.s + 1) {};
}";
            var processor = CreateProcessor();
            var xml = processor.GenerateXml(code, true);
			Assert.That(xml.Descendants("argument_list").Count(), Is.EqualTo(1));
		}

		[Test]
		[TestCase("Block1.cs")]
		[TestCase("Block2.cs")]
		public void ParseFile(string fileName) {
			VerifyRestoringFile("CSharp", fileName);
		}
	}
}