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
using Code2Xml.Objects.Tests.Learning.Experiments;
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
        [TestCase(@"class K { void m() { converter.reverse().convert(0666); }}")]
        [TestCase(@"class K { void m() { int i = 0 + 1 - 2 * 3/ 4; }}")]
        [TestCase(@"class K { void m() { if (1 < 2) { } }}")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        public void CheckIds() {
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
        [TestCase(@"https://github.com/Athou/commafeed.git",
                @"3a8d72cab4038e975af87d8083e2b7e68f2e328c", 1048)]
        [TestCase(@"https://github.com/Comcast/FreeFlow.git",
                @"47bfb57e8037eecae320266cb00dd23e673362e5", 1079)]
        [TestCase(@"https://github.com/Graylog2/graylog2-server.git",
                @"c1c5491c4a3194a19c21a7c744d5d45421ecd227", 1041)]
        [TestCase(@"https://github.com/JakeWharton/ActionBarSherlock.git",
                @"4a79d536af872339899a90d6dc743aa57745474b", 5553)]
        [TestCase(@"https://github.com/JakeWharton/Android-ViewPagerIndicator.git",
                @"8cd549f23f3d20ff920e19a2345c54983f65e26b", 3466)]
        [TestCase(@"https://github.com/ManuelPeinado/FadingActionBar.git",
                @"f679e313d105075cfb389695052348ee09a8e80a", 1068)]
        [TestCase(@"https://github.com/bigbluebutton/bigbluebutton.git",
                @"55773f594eed3e0eff5af47ec8cbd6fcf713a56a", 1062)]
        [TestCase(@"https://github.com/chrisbanes/Android-PullToRefresh.git",
                @"3bd8ef6869c3297bfe874d2f15c2ee53c3456e99", 3007)]
        [TestCase(@"https://github.com/clojure/clojure.git",
                @"201a0dd9701e1a0ee3998431241388eb4a854ebf", 3051)]
        [TestCase(@"https://github.com/douglascrockford/JSON-java.git",
                @"4d86b05d3c6a72e88c476430d60676f9ae2fafab", 1052)]
        [TestCase(@"https://github.com/eclipse/vert.x.git",
                @"4a6498baa2269a0dc753861d0539ebeee5926769", 2866)]
        [TestCase(@"https://github.com/elasticsearch/elasticsearch.git",
                @"e688f445ad15054d9335f71c94a0b6736877481b", 6637)]
        [TestCase(@"https://github.com/facebook/facebook-android-sdk.git",
                @"118e756568f7e9a8045e87575c190a2c304071a6", 2818)]
        [TestCase(@"https://github.com/github/android.git",
                @"9d490829b944d3a2c77dbd0010ec7a0bfe2efaee", 3881)]
        [TestCase(@"https://github.com/libgdx/libgdx.git",
                @"ed9733d93a2e5bdf20e10e8c10437e86a66941a2", 3289)]
        [TestCase(@"https://github.com/loopj/android-async-http.git",
                @"6077c6aa7bf06b2b8c13fbb4355e094dea436b7c", 3304)]
        [TestCase(@"https://github.com/mttkay/ignition.git",
                @"bbeb55cb4f080bdc31e549142ea745c65e4727c7", 1058)]
        [TestCase(@"https://github.com/nathanmarz/storm.git",
                @"cdb116e942666973bc4eaa0df098d5bab82739e7", 8108)]
        [TestCase(@"https://github.com/netty/netty.git",
                @"8615f7a69ecbbabd6d8f7ba8cae90ba63d702fec", 2805)]
        [TestCase(@"https://github.com/nostra13/Android-Universal-Image-Loader.git",
                @"29811229c3ba3da390b29353875be2c92f88a789", 4251)]
        [TestCase(@"https://github.com/phonegap/phonegap-facebook-plugin.git",
                @"ccb2a6f648bb2ed44e4b7b71add4fb7b7e95eaed", 1084)]
        [TestCase(@"https://github.com/processing/processing.git",
                @"9c63a2c4a227ed2329fd01006cb593ba8954962d", 1054)]
        [TestCase(@"https://github.com/purplecabbage/phonegap-plugins.git",
                @"319dfb7297002040ec7ab98896e68d05c7fd8180", 1083)]
        [TestCase(@"https://github.com/spring-projects/spring-framework.git",
                @"09248a0b372ad2e6019b44190ae64f4316dbc1fd", 3294)]
        [TestCase(@"https://github.com/twall/jna.git",
                @"323a913bf610c982f43b58883b0fc54c78a29621", 1098)]
        [TestCase(@"https://github.com/yusuke/twitter4j.git",
                @"747982dfdccd6d1b2ef4857720fe289455a435a1", 1101)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            var exp = new JavaComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "java_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.java");
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