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

using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.Java;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.ANTLRv3.Tests {
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
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        public void CheckIds() {
            var nodes = Generator.GenerateTreeFromCodeText("class K { void m() { if (true) stmt(); else stmt(); } }")
                    .Descendants("statement")
                    .ToList();
            Assert.That(nodes[0].RuleId, Is.Not.EqualTo(nodes[1].RuleId));
            Assert.That(nodes[0].RuleId, Is.Not.EqualTo(nodes[2].RuleId));
            Assert.That(nodes[1].RuleId, Is.Not.EqualTo(nodes[2].RuleId));
        }

        //[Test]
        //[TestCase(@"android-betterpickers")]
        //[TestCase(@"android-priority-jobqueue")]
        //[TestCase(@"elasticsearch")]
        //[TestCase(@"Hydra")]
        //[TestCase(@"pageobjectgenerator")]
        //[TestCase(@"presto")]
        //[TestCase(@"RxJava")]
        //[TestCase(@"scalpel")]
        //[TestCase(@"storm")]
        //[TestCase(@"u2020")]
        //public void ParseDirectory(string directoryName) {
        //    VerifyRestoringProjectDirectory("Java", directoryName, "*.java");
        //}

        [Test]
        [TestCase(@"https://github.com/derekbrameyer/android-betterpickers.git",
                @"0a72367b478970b1731822e78790a158a4f7ebb4")]
        [TestCase(@"https://github.com/path/android-priority-jobqueue.git",
                @"89d76ea193cfded0d9401f534fedbfe14c981c04")]
        [TestCase(@"https://github.com/elasticsearch/elasticsearch.git",
                @"211f740100bae44a96ce5efe7a850914ad8d9abb")]
        [TestCase(@"https://github.com/Findwise/Hydra.git",
                @"455917103ad47bf14edce135c5eba1045d9196a4")]
        [TestCase(@"https://github.com/exKAZUu/POGen.git",
                @"69fff3e37565ad668e6c8e90e7b2e4d135117cf5")]
        [TestCase(@"https://github.com/facebook/presto.git",
                @"16c3fae380c2caf195d5f43f87495c978bccb22b")]
        [TestCase(@"https://github.com/Netflix/RxJava.git",
                @"3c6fbe0bb170e45ed072b82adef8b34f63100a79")]
        [TestCase(@"https://github.com/JakeWharton/scalpel.git",
                @"97299acd1cc7b4138af714f1ed0bce47e9ce516d")]
        [TestCase(@"https://github.com/nathanmarz/storm.git",
                @"cdb116e942666973bc4eaa0df098d5bab82739e7")]
        [TestCase(@"https://github.com/JakeWharton/u2020.git",
                @"831efcdaf8dec58bc8da836d94b6e1ea6151696e")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.java");
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