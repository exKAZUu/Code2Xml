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
using Code2Xml.Languages.ANTLRv4.Core;
using Code2Xml.Languages.ANTLRv4.Processors.Java;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests.Processors {
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
		public void ParseHexicalNumber() {
			var code = @"
class Hello {
    void main(String[] args) {
		System.out.println((String)args[0x00]);
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
		public void ParseBrokenCodeIgnoringException() {
			var code = @"class A {{ }";
			var processor = new JavaProcessor();
			processor.GenerateXml(code, false);
		}

		[Test, ExpectedException(typeof(ParseException))]
		public void ParseBrokenCode() {
			var code = @"class A {{ }";
			var processor = new JavaProcessor();
			processor.GenerateXml(code, true);
		}

		[Test]
		public void ParseJavaSource() {
			var dirInfo = new DirectoryInfo(@"C:\Users\exKAZUu\Desktop\src");
			if (!dirInfo.Exists) {
				return;
			}

			var javaFiles = dirInfo.GetFiles("*.java", SearchOption.AllDirectories);
			var processor = new JavaProcessor();
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			foreach (var javaFile in javaFiles) {
				Console.WriteLine(javaFile);
				var code = javaFile.OpenText().ReadToEnd();
				var xml = processor.GenerateXml(code);
				var code2 = processor.GenerateCode(xml);
				Assert.That(code2, Is.EqualTo(code));
			}
			stopwatch.Stop();
			Console.WriteLine(stopwatch.Elapsed);
		}

		[Test]
		public void Test() {
			var inputStream = new AntlrInputStream("public /*aa*/ class Klass { }");
			var javaLexer = new JavaLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(javaLexer);
			var javaParser = new JavaParser(commonTokenStream);
			var context = javaParser.compilationUnit();
			var visitor = new Antlr4AstBuilder(javaParser);
			visitor.Visit(context);
			Console.WriteLine(visitor.FinishParsing());
		}

		private static void TestParsing(string code) {
			var processor = new JavaProcessor();
			var xml = processor.GenerateXml(code, true);
			var code2 = processor.GenerateCode(xml);
			Assert.That(code2, Is.EqualTo(code));
			Console.WriteLine(xml);
		}
	}
}