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
using System.IO;
using System.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.Java;
using NUnit.Framework;
using ParserTests;
using JavaLexer = Code2Xml.Core.Tests.Generators.ANTLRv3.Parsers.JavaLexer;
using JavaParser = Code2Xml.Core.Tests.Generators.ANTLRv3.Parsers.JavaParser;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3 {
    [TestFixture]
    public class JavaCstGeneratorUsingAntlr3Test : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new JavaCstGeneratorUsingAntlr3();
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
        [TestCase(@"class K { void m() { converter.reverse().convert(0666); }}")]
        [TestCase(@"class K { void m() { int i = 0 + 1 - 2 * 3/ 4; }}")]
        [TestCase(@"class K { void m() { if (1 < 2) { } }}")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        public void CheckIds() {
            var t = Generator.GenerateTreeFromCodeText(
                    "class K { void m() { if (true) stmt(); else stmt(); } }");
            var nodes =
                    Generator.GenerateTreeFromCodeText(
                            "class K { void m() { if (true) stmt(); else stmt(); } }")
                            .Descendants("statement")
                            .ToList();
            Assert.That(nodes[0].RuleId, Is.Not.EqualTo(nodes[1].RuleId));
            Assert.That(nodes[0].RuleId, Is.Not.EqualTo(nodes[2].RuleId));
            Assert.That(nodes[1].RuleId, Is.Not.EqualTo(nodes[2].RuleId));
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
            Action<string> parse = code => {
                var parser =
                        new JavaParser(
                                new CommonTokenStream(new JavaLexer(new ANTLRStringStream(code))));
                parser.TraceDestination = Console.Error;
                var ret = parser.compilationUnit();
            };
            MeasurePerformance(url, commitPointer, parse, "*.java");
        }

        [Test]
        public void ParseSourceCodeOfHudson2() {
            Generator.GenerateTreeFromCode(
                    new FileInfo(
                            @"C:\Users\exKAZUu\Projects\Code2Xml\ParserTests\fixture\Git\guava-libraries\guava-gwt\test-super\com\google\common\primitives\super\com\google\common\primitives\IntsTest.java"),
                    null, true);
        }

        [Test]
        public void ParseBrokenCodeIgnoringException() {
            var code = @"class A {{ }";
            Generator.GenerateTreeFromCodeText(code, false);
        }

        [Test, ExpectedException(typeof(ParseException))]
        public void ParseBrokenCode() {
            var code = @"class A {{ }";
            Generator.GenerateTreeFromCodeText(code, true);
        }

        [Test]
        public void ParseSourceCodeOfHudson() {
            var path = Fixture.GetInputCodePath("Java", "FileSystemProvisioner.java");
            Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
        }

        [Test, ExpectedException(typeof(ParseException))]
        public void ParseSourceCodeContainingIlligalUnicodeCharacters() {
            var path = Path.Combine(Fixture.GetFailedInputPath("Java"), "Unicode.java");
            Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
        }

        [Test]
        public void ParseComment() {
            var e = Generator.GenerateTreeFromCodeText(
                    @"public class A { /*a
aa*/
/* aaa */
// sss
// bbb
}");
            var cs = e.AllTokensWithHiddens()
                    .Where(e2 => e2.Name == "COMMENT" || e2.Name == "LINE_COMMENT")
                    .ToList();
            var p1 = cs[0].Range;
            var p2 = cs[1].Range;
            var p3 = cs[2].Range;
            var p4 = cs[3].Range;
            Assert.That(cs.Count, Is.EqualTo(4));
            Assert.That(p1.StartLine, Is.EqualTo(1));
            Assert.That(p1.EndLine, Is.EqualTo(2));
            Assert.That(p2.StartLine, Is.EqualTo(3));
            Assert.That(p2.EndLine, Is.EqualTo(3));
            Assert.That(p3.StartLine, Is.EqualTo(4));
            Assert.That(p3.EndLine, Is.EqualTo(5));
            Assert.That(p4.StartLine, Is.EqualTo(5));
            Assert.That(p4.EndLine, Is.EqualTo(6));
        }
    }
}