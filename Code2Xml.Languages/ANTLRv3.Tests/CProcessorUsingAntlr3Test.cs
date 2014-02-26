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
using System.IO;
using Code2Xml.Core;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.ANTLRv3.Processors.C;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class CProcessorUsingAntlr3Test : ProcessorTest {
		protected override Processor CreateProcessor() {
			return new CProcessorUsingAntlr3();
		}

		[Test]
		[TestCase(@"void main() {
pvariant = (__extension__ ({ __typeof__ (stype[0]) __x = (stype[0]); (void) __ctype_ptr__[__x]; (tolower) (__x);}) == 'p') ? 1 : 0;
}")]
		[TestCase(@"void main() {}")]
		[TestCase(@"union u { __extension__ struct { int a; }; int b; };")]
		[TestCase(@"enum e { a = 0, };")]
		[TestCase(@"struct s { struct { int a; } b; struct { int c; }; };")]
		[TestCase(@"char cs[] = ""\xa5\xc2\x28\x1a"";")]
//		[TestCase(@"typedef struct option option_t;
//void main() {
//	int x;
//	x = (option_t){ ((void *)0), 0, ((void *)0), 0 };
//}
//")]
		public void Parse(string code) {
			VerifyRestoringCode(code);
		}

		[Test]
		[TestCase("assignment.c")]
		public void ParseFile(string fileName) {
			VerifyRestoringFile("C", fileName);
		}

		[Test]
		[TestCase(@"FiniteStateEntropy")]
		[TestCase(@"greatest")]
		//[TestCase(@"libgit2")]
		//[TestCase(@"the_silver_searcher")]
		//[TestCase(@"twemproxy")]
		//[TestCase(@"bfgminer")]
		//[TestCase(@"Cinnamon")]
		//[TestCase(@"ejoy2d")]
		//[TestCase(@"exploit-database")]
		//[TestCase(@"lwan")]
		//[TestCase(@"micropython")]
		//[TestCase(@"redis")]
		//[TestCase(@"watchman")]
		//[TestCase(@"frida-core")]
		//[TestCase(@"libgdx")]
		//[TestCase(@"libuv")]
		//[TestCase(@"algo")]
		public void ParseDirectory(string directoryName) {
			var path = Fixture.GetInputProjectPath("C", directoryName);
			var filePaths = Directory.GetFiles(path, "*.c", SearchOption.AllDirectories);
			foreach (var filePath in filePaths) {
				Console.WriteLine(filePath);
				var processor = CreateProcessor();
				var code = CProcessorUsingAntlr3AndGcc.PreprocessCode(
						File.ReadAllText(filePath), Path.GetDirectoryName(filePath));
				var xml = processor.GenerateXml(code, true);
				var code2 = processor.GenerateCode(xml);
				Assert.That(code2, Is.EqualTo(code));
			}
		}
	}
}