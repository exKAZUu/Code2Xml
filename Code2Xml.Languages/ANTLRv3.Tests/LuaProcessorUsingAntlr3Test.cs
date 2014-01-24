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
using Code2Xml.Core;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.ANTLRv3.Processors.Lua;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class LuaProcessorUsingAntlr3Test : ProcessorTest {
		protected override Processor CreateProcessor() {
			return new LuaProcessorUsingAntlr3();
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
		[TestCase(@"if true then end --[[SCars]] ")]
		[TestCase(@"if true then --[[SCars]] end")]
		[TestCase(@"if true --[[SCars]] then end")]
		[TestCase(@"--[=")]
		[TestCase(@"--a")]
		[TestCase("-- running the tests and examples\nrequire 'pl'\n")]
		[TestCase("require 'pl'\n")]
		[TestCase(@"print(1)")]
		[TestCase(@"print(1, 2)")]
		public void Parse(string code) {
			VerifyRestoringCode(code);
		}

		[Test]
		public void test() {
			var x = new LuaProcessorUsingAntlr3()
					.GenerateXml("-- running the tests and examples\nrequire 'pl'\n");
			Console.WriteLine(x);
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