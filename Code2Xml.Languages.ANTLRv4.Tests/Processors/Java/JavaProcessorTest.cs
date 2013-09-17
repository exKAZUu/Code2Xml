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
using Code2Xml.Languages.ANTLRv4.Processors.Java;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests.Processors.Java {
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
			var processor = new JavaProcessor();
			var xml = processor.GenerateXml(code);
			var code2 = processor.GenerateCode(xml);
			Assert.That(code2, Is.EqualTo(code));
		}

		[Test]
		public void Parse2() {
			var code = @"
class Hello {
    void main(String[] args) {
		System.out.println((String)args[0x00]);
    }
}
";
			var stream = new AntlrInputStream(code);
			var lexer = new JavaLexer(stream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new JavaParser(commonTokenStream);
			parser.compilationUnit();

			var processor = new JavaProcessor();
			var xml = processor.GenerateXml(code);
			var code2 = processor.GenerateCode(xml);
			Assert.That(code2, Is.EqualTo(code));
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
		public void ParseJavaSourceWithAttribute() {
			var dirInfo = new DirectoryInfo(@"C:\Users\exKAZUu\Desktop\src");
			if (!dirInfo.Exists) {
				return;
			}

			var javaFiles = dirInfo.GetFiles("*.java", SearchOption.AllDirectories);
			var processor = new JavaProcessor2();
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
	}
}