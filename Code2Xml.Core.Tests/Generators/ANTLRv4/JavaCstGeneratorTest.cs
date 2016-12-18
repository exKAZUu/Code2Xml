#region License

// Copyright (C) 2011-2016 Kazunori Sakamoto
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
using System.Linq;
using Antlr4.Runtime;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv4;
using Code2Xml.Core.Generators.ANTLRv4.Java;
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv4 {
    [TestFixture]
    public class JavaCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new JavaCstGenerator();
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
        [TestCase(@"
@Retention(RetentionPolicy.CLASS)
@Target({
    ElementType.ANNOTATION_TYPE,
    ElementType.CONSTRUCTOR,
    ElementType.FIELD,
    ElementType.METHOD,
    ElementType.TYPE})
@Documented
@GwtCompatible
public @interface Beta {}")]
        [TestCase(@"
public class AlignedTuplePrinter {
    List<String> columnLines = new ArrayList<>();
}")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        public void CheckIds() {
            var tree = Generator.GenerateTreeFromCodeText(
                "class K { void m() { if (true) stmt(); else stmt(); } }");
            var nodes = tree.Descendants()
                    .Where(e => e.Name == "statement" || e.Name == "statementNoShortIf")
                    .ToList();
            Assert.That(nodes[0].RuleId, Is.Not.EqualTo(nodes[1].RuleId));
            Assert.That(nodes[0].RuleId, Is.Not.EqualTo(nodes[2].RuleId));
            Assert.That(nodes[1].RuleId, Is.Not.EqualTo(nodes[2].RuleId));
        }

        [Test]
        public void ParseComments() {
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
            var cst = TestParsing(code);
            var nComments = cst.AllTokensWithHiddens()
                    .Count(e => e.Name == "COMMENT" || e.Name == "LINE_COMMENT");
            Assert.That(nComments, Is.EqualTo(3));
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
            var processor = new JavaCstGenerator();
            processor.GenerateTreeFromCodeText(code, false);
        }

        [Test]
        public void ParseBrokenCode() {
            var code = @"class A {{ }";
            var processor = new JavaCstGenerator();
            Assert.Throws<ParseException>(() => processor.GenerateTreeFromCodeText(code, true));
        }

        [Test]
        public void ParseJavaSource() {
            var dirInfo = new DirectoryInfo(@"C:\Users\exKAZUu\Desktop\src");
            if (!dirInfo.Exists) {
                return;
            }

            var javaFiles = dirInfo.GetFiles("*.java", SearchOption.AllDirectories);
            var processor = new JavaCstGenerator();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var javaFile in javaFiles) {
                Console.WriteLine(javaFile);
                var code = javaFile.OpenText().ReadToEnd();
                var cst = processor.GenerateTreeFromCodeText(code);
                var code2 = cst.Code;
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
            var visitor = new CstBuilderForAntlr4(javaParser);
            visitor.Visit(context);
            Console.WriteLine(visitor.FinishParsing().ToXml());
        }

        private static CstNode TestParsing(string code) {
            var processor = new JavaCstGenerator();
            var cst = processor.GenerateTreeFromCodeText(code, true);
            var code2 = cst.Code;
            Assert.That(code2, Is.EqualTo(code));
            Console.WriteLine(cst);
            return cst;
        }

        [Test]
        [TestCase(@"https://github.com/elasticsearch/elasticsearch",
             @"96e62b3c1b1ea22fa788fc14b7c9d1f4388dbc1c", 8678)]
        [TestCase(@"https://github.com/nathanmarz/storm",
             @"cdb116e942666973bc4eaa0df098d5bab82739e7", 8404)]
        [TestCase(@"https://github.com/jfeinstein10/SlidingMenu",
             @"4254feca3ece9397cd501921ee733f19ea0fdad8", 6457)]
        [TestCase(@"https://github.com/JakeWharton/ActionBarSherlock",
             @"4a79d536af872339899a90d6dc743aa57745474b", 6360)]
        [TestCase(@"https://github.com/nostra13/Android-Universal-Image-Loader",
             @"b3888a4f35d31a3e7b96c9f7a5665216c1946bb5", 6210)]
        [TestCase(@"https://github.com/github/android",
             @"fbfb63c6607d8077018c245d7508f0fedab65dbb", 4910)]
        [TestCase(@"https://github.com/libgdx/libgdx",
             @"806ba436b1805c3d56c22a3b25b7fd383bc44c40", 4829)]
        [TestCase(@"https://github.com/google/iosched",
             @"f2e87424ea7cc0c3f8022f984966091ea746a23e", 4669)]
        [TestCase(@"https://github.com/loopj/android-async-http",
             @"b954a3178751b5fcf051f4c0134774cc51ba5fcc", 4581)]
        [TestCase(@"https://github.com/JakeWharton/Android-ViewPagerIndicator",
             @"8cd549f23f3d20ff920e19a2345c54983f65e26b", 4417)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            MeasurePerformance(url, commitPointer, null, "*.java");
        }
    }
}