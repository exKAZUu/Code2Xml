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
using Code2Xml.Languages.ANTLRv3.Processors.Java;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
    [TestFixture]
    public class JavaProcessorUsingAntlr3Test : ProcessorTest {
        protected override Processor CreateProcessor() {
            return new JavaProcessorUsingAntlr3();
        }

        [Test]
        [TestCase(@"//test
import javax.swing.*;
 
public class Hello extends JFrame {
    Hello() /*test*/ {
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        pack(); // pack();
    }
 
    public static void main(String[] args) {
        new Hello().setVisible(true);
    }
}")]
        [TestCase(@"class Main {
  void test() { obj.method().<Object>method2(); }
}")]
        [TestCase(@"public class AlignedTuplePrinter {
    List<String> columnLines = new ArrayList<>();
}")]
        [TestCase(@"class Klass { void main() {
	try { } finally { }
}}")]
        [TestCase(@"class Klass { void main() {
	try (Object obj = new Object()) { } finally { }
}}")]
        [TestCase(@"class Klass { void main() {
	try (Object obj = new Object() ; Object obj = new Object()) { } finally { }
}}")]
        [TestCase(@"class Klass { void main() {
		checkArgument(args == null);
		Preconditions.checkArgument(args != null);
		com.google.common.base.Preconditions.checkArgument(args.length == 0, str);
}}")]
        [TestCase(@"class K { void m() { if (true) {} for(;false;) {} }}")]
        [TestCase(@"class K { void m() { if (true) { } else { } }}")]
        public void Parse(string code)
        {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase(@"android-betterpickers")]
        [TestCase(@"android-priority-jobqueue")]
        [TestCase(@"elasticsearch")]
        [TestCase(@"Hydra")]
        [TestCase(@"pageobjectgenerator")]
        [TestCase(@"presto")]
        [TestCase(@"RxJava")]
        [TestCase(@"scalpel")]
        [TestCase(@"storm")]
        [TestCase(@"u2020")]
        public void ParseDirectory(string directoryName) {
            VerifyRestoringProjectDirectory("Java", directoryName, "*.java");
        }

        [Test]
        public void ParseBrokenCodeIgnoringException() {
            var code = @"class A {{ }";
            var processor = new JavaProcessorUsingAntlr3();
            processor.GenerateXml(code, false);
        }

        [Test, ExpectedException(typeof(ParseException))]
        public void ParseBrokenCode() {
            var code = @"class A {{ }";
            var processor = new JavaProcessorUsingAntlr3();
            processor.GenerateXml(code, true);
        }
    }
}