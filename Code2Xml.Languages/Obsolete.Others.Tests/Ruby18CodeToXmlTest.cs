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
using Code2Xml.Languages.Ruby18.CodeToXmls;
using Code2Xml.Languages.Ruby18.XmlToCodes;
using NUnit.Framework;
using Paraiba.Xml;
using ParserTests;

namespace Code2Xml.Languages.Ruby18.Tests {
	public class Ruby18CodeToXmlTest {
		[Test]
		public void CanParse() {
			var path = Fixture.GetInputCodePath("Ruby18", "block.rb");
			Ruby18CodeToXml.Instance.GenerateFromFile(path, true);
		}

		[Test]
		public void CanParseJapanese() {
			var xml = Ruby18CodeToXml.Instance.Generate(@"p 'あ'", true);
			Console.WriteLine(xml);
			Assert.That(xml.ToString(), Is.StringContaining("あ"));
		}

		[Test]
		public void CanParseJapanese2() {
			var xml = Ruby18CodeToXml.Instance.Generate(@"p = 'あ'", true);
			Console.WriteLine(xml);
			Assert.That(xml.ToString(), Is.StringContaining("あ"));
		}

		[Test, Ignore]
		public void CanParseJapanese3() {
			// TODO: Currently, this test fails due to the bugs of ruby_parser
			// https://github.com/seattlerb/ruby_parser/issues/133
			var xml = Ruby18CodeToXml.Instance.Generate("p = \"\\u{3042}\"", true);
			Console.WriteLine(xml);
			Assert.That(xml.ToString(), Is.StringContaining("\\u{3042}"));
		}

		[Test, Ignore]
		public void InterConvertJapanese() {
			// TODO: Currently, this test fails due to the bugs of ruby_parser
			// https://github.com/seattlerb/ruby_parser/issues/133
			var r1 = Ruby18CodeToXml.Instance.Generate(@"p = 'あ'", true);
			var c1 = Ruby18XmlToCode.Instance.Generate(r1);
			var r2 = Ruby18CodeToXml.Instance.Generate(c1, true);
			var c2 = Ruby18XmlToCode.Instance.Generate(r2);
			var r3 = Ruby18CodeToXml.Instance.Generate(c2, true);
			var c3 = Ruby18XmlToCode.Instance.Generate(r3);

			Assert.IsTrue(XmlUtil.EqualsWithElementAndValue(r2, r3));
			Assert.That(c1, Is.EqualTo("p = \"\\u{3042}\""));
			Assert.That(c2, Is.EqualTo("p = \"\\u{3042}\""));
		}
	}
}