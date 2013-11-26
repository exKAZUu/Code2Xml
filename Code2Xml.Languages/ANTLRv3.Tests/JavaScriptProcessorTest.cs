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
using Code2Xml.Languages.ANTLRv3.Processors.JavaScript;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class JavaScriptProcessorTest : ProcessorTest {
		protected override Processor CreateProcessor() {
			return new JavaScriptProcessorUsingAntlr3();
		}

		[Test]
		[TestCase(@"")]
		[TestCase(@"var i = 1;")]
		[TestCase(@"function
f() {
	return 1
}")]
		[TestCase(@"for ( var i = 0, j = 0; i < 1; i++, j++ ) { }")]
		[TestCase(@"for(var i = 0, ii = directives.length; i < ii; i++) { }")]
		[TestCase(@"console.log('test')")]
		[TestCase(@"
//
")]
		[TestCase(@"
            compile({
                                          //
                                        });
")]
		[TestCase(@"
return 'a\
b';
")]
		public void Parse(string code) {
			VerifyRestoringCode(code);
		}

		[Test]
		[TestCase("Block1.js")]
		[TestCase("Block2.js")]
		[TestCase("Block3.js")]
		[TestCase("extracting_branch.js")]
		public void ParseFile(string fileName) {
			VerifyRestoringFile("JavaScript", fileName);
		}

		[Test]
		[TestCase("ionic")]
		public void ParseDirectory(string fileName) {
			VerifyRestoringProjectDirectory("JavaScript", fileName, "*.js");
		}
	}
}