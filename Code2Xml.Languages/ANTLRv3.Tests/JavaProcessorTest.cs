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
using Antlr.Runtime;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv3.Processors.Java;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class JavaProcessorTest {
		[Test]
		public void Parse() {
			var code = @"//test
import javax.swing.*;
 
public class Hello extends JFrame {
    Hello() /*test*/ {
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        pack(); // pack();
    }
 
    public static void main(String[] args) {
        new Hello().setVisible(true);
    }
}
";
			TestParsing(code);
		}

		[Test]
		public void ParseGenericMethod() {
			var code = @"
class Main {
  void test() { obj.method().<Object>method2(); }
}";
			TestParsing(code);
		}

		[Test]
		public void ParseUnicodeCharacter() {
			var code = @"obj.method().<Object>method2()";
			TestParsing(code);
		}

		[Test]
		public void ParseBrokenCodeIgnoringException() {
			var code = @"class A {{ }";
			var processor = new JavaProcessorUsingAntlr3();
			processor.GenerateXml(code, false);
		}

		[Test]
		public void ParseDiamond() {
			var code = @"
public class AlignedTuplePrinter {
    List<String> columnLines = new ArrayList<>();
}
";
			var processor = new JavaProcessorUsingAntlr3();
			processor.GenerateXml(code, true);
		}

		[Test, ExpectedException(typeof(ParseException))]
		public void ParseBrokenCode() {
			var code = @"class A {{ }";
			var processor = new JavaProcessorUsingAntlr3();
			processor.GenerateXml(code, true);
		}

		private static void TestParsing(string code) {
			var processor = new JavaProcessorUsingAntlr3();
			var xml = processor.GenerateXml(code);
			var code2 = processor.GenerateCode(xml);
			Assert.That(code2, Is.EqualTo(code));
			Console.WriteLine(xml);
		}
	}
}