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
using Code2Xml.Languages.ANTLRv4.Processors.Lua;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests {
	[TestFixture]
	public class LuaProcessorTest : ProcessorTest {
		protected override Processor CreateProcessor() {
			return new LuaProcessor();
		}

		[Test]
		[TestCase(@"a = 1")]
		[TestCase(@"#!/usr/bin/lua
a = 1")]
		[TestCase(@"#!/if/while/lua
a = 1")]
		[TestCase(@"--")]
		[TestCase(@"--[")]
		[TestCase(@"--[==")]
		[TestCase(@"--[==[]==]")]
		[TestCase(@"if true then --[[SCars]] end")]
		[TestCase(@"if true --[[SCars]] then end")]
		[TestCase(@"print(1)")]
		[TestCase(@"print(1, 2)")]
		public void Parse(string code) {
			VerifyRestoringCode(code);
		}

		[Test]
		[TestCase("Block1.lua")]
		[TestCase("Block2.lua")]
		[TestCase("Block3.lua")]
		public void ParseFile(string fileName) {
			VerifyRestoringFile("Lua", fileName);
		}

		[Test]
		[TestCase("koreader")]
		[TestCase("lapis")]
		[TestCase("lsyncd")]
		[TestCase("luafun")]
		[TestCase("luakit")]
		[TestCase("middleclass")]
		[TestCase("pacpac")]
		[TestCase("Tir")]
		[TestCase("Penlight")]
		[TestCase("vlsub")]
		public void ParseDirectory(string fileName) {
			VerifyRestoringProjectDirectory("Lua", fileName, "*.lua");
		}
	}
}