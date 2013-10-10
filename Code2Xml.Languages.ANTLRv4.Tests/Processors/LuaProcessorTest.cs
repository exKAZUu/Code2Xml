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

using System;
using System.Diagnostics;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv4.Processors.Lua;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests.Processors {
	[TestFixture]
	public class LuaProcessorTest {
		[Test]
		public void ParseLongString() {
			TestParsing("a = [=[one [[two]] three]=]");
		}

		[Test]
		public void ParseIndexer() {
			TestParsing("a = func()[1]");
		}

		[Test, ExpectedException(typeof(ParseException))]
		public void ParseEscapeSequence() {
			TestParsing(@"local expr = '/[^() ]*lib' .. libname .. '\.so[^() ]*'");
		}

		[Test]
		public void ParseOnlyComment() {
			TestParsing("--[[Any--]]");
		}

		[Test]
		public void ParseLineComment() {
			TestParsing(@"
--
print(1)
");
		}

		[Test]
		public void ParseLineCommentWithoutNewLines() {
			TestParsing(@"--");
		}

		[Test]
		public void ParseCodeWithComment() {
			TestParsing(@"
if true --[[xx]] then
	print(1)
end
");
		}

		[Test]
		public void ParseCodeWithComment2() {
			TestParsing(@"
if true then --[[VERBOSE]] print(1) end
");
		}

		[Test]
		public void ParseFiles() {
			var dirInfo = new DirectoryInfo(@"C:\Users\exKAZUu\Downloads\lua-5.2.2-tests (1).tarz");
			if (!dirInfo.Exists) {
				return;
			}

			var files = dirInfo.GetFiles("*.lua", SearchOption.AllDirectories);
			var processor = new LuaProcessor();
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			foreach (var file in files) {
				Console.WriteLine(file);
				var code = file.OpenText().ReadToEnd();
				var xml = processor.GenerateXml(code, true);
				var code2 = processor.GenerateCode(xml);
				Assert.That(code2, Is.EqualTo(code));
			}
			stopwatch.Stop();
			Console.WriteLine(stopwatch.Elapsed);
		}

		private static void TestParsing(string code) {
			var processor = new LuaProcessor();
			var xml = processor.GenerateXml(code, true);
			var code2 = processor.GenerateCode(xml);
			Assert.That(code2, Is.EqualTo(code));
			Console.WriteLine(xml);
		}
	}
}