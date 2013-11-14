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

using System.IO;
using Code2Xml.Core.Plugin;
using Code2Xml.Languages.CSharp.CodeToXmls;
using Code2Xml.Languages.CSharp.XmlToCodes;
using Code2Xml.Languages.Java.CodeToXmls;
using Code2Xml.Languages.Java.XmlToCodes;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.Tests.Samples {
	[TestFixture]
	public class CodeToXmlSample {
		[Test]
		public void ParseJavaText() {
			var originalCode = @"class Klass {}";
			var xml = JavaCodeToXml.Instance.Generate(originalCode);
			var code = JavaXmlToCode.Instance.Generate(xml);
			Assert.That(code, Is.EqualTo(originalCode));
		}

		[Test]
		public void ParseCSharpFile() {
			var path = Fixture.GetInputCodePath("CSharp", "Student.cs");
			var xml = CSharpCodeToXml.Instance.GenerateFromFile(path);
			var code = CSharpXmlToCode.Instance.Generate(xml);
			Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
		}

		[Test]
		public void ParseLuaFileUsingFilePath() {
			var path = Fixture.GetInputCodePath("Lua", "Block1.lua");
			var codeToXml = PluginManager.GetCodeToXmlByPath(path);
			var xml = codeToXml.GenerateFromFile(path);
			var code = codeToXml.XmlToCode.Generate(xml);
			Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
		}
	}
}