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
        [TestCase(@"class K { void m() { converter.reverse().convert(0666); }}")]
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
        [TestCase(@"https://github.com/Findwise/Hydra.git",
                @"5c781845a466f99645eac9fa27fb27aceb88a442")]
        [TestCase(@"https://github.com/Netflix/RxJava.git",
                @"bd87341aecb408b2a0acc3f7a42dc118be006b1d")]
        [TestCase(@"https://github.com/derekbrameyer/android-betterpickers.git",
                @"5646215424ad779f1f780254101b75221675b76b")]
        [TestCase(@"https://github.com/path/android-priority-jobqueue.git",
                @"d3b33d9ae94df76ffde1f4b9735c0f7cc6463384")]
        [TestCase(@"https://github.com/elasticsearch/elasticsearch.git",
                @"2f32908193f3f61139da054f0ee5a949f8c589dc")]
        [TestCase(@"https://code.google.com/p/pageobjectgenerator/",
                @"169bdaf6a5a08fab62e167764e7f8401309d7b64")]
        [TestCase(@"https://github.com/facebook/presto.git",
                @"78045f8ede1f1e3deb4e40b880745141480d362f")]
        [TestCase(@"https://github.com/JakeWharton/scalpel.git",
                @"27338feaa632bc160ae4f27f001474f0850310ea")]
        [TestCase(@"https://github.com/nathanmarz/storm.git",
                @"66a397368a98834095b47db2b706420901c52ba3")]
        [TestCase(@"https://github.com/JakeWharton/u2020.git",
                @"a08a7ec51e01cc40aa27779dca52277e69d156f7")]
        [TestCase(@"https://code.google.com/p/guava-libraries/",
                @"f510d9bc51715c4d583e0b152e5d0265c44c982f")]
        [TestCase(@"https://github.com/MehdiK/Humanizer.git",
                @"b51cc6715acde38f674dfd84ae02188be0547702")] // Star: 503
        [TestCase(@"https://github.com/NancyFx/Nancy.git",
                @"e069dfbc326af4552f79b55b12c6966305baad79")] // Star: 2104
        [TestCase(@"https://github.com/mono/MonoGame.git",
                @"73fc2954b0cd83a4a7f3ddecdc56f155ff135e99")] // Star: 1996
        [TestCase(@"https://github.com/SignalR/SignalR.git",
                @"b940230aedc851c50775c2ed32ab96c476f10ec6")] // Star: 4108
        [TestCase(@"https://github.com/JamesNK/Newtonsoft.Json.git",
                @"9e2581be74585605b4f49e0110d65c85c17cb323")] // Star: 825
        [TestCase(@"https://github.com/Glimpse/Glimpse.git",
                @"b78f1c8b336e86278efea95c115f8a9a404ab901")] // Star: 691
        [TestCase(@"https://github.com/WebMBro/WebMConverter.git",
                @"07ff15b0e4fdf1b5cf66cf25a71a2d3b88a6f75e")] // Star: 40
        [TestCase(@"https://github.com/shimat/opencvsharp.git",
                @"d337e665265a8ce88773869d2402cad7fc1d21d3")] // Star: 40
        [TestCase(@"https://github.com/mrward/monodevelop-nuget-addin.git",
                @"f593536fcd779f4e819def961c676e392eee0ff3")] // Star: 225
        [TestCase(@"https://github.com/MahApps/MahApps.Metro.git",
                @"36fe5e517e0c65116d288fdabf2e68a2a9494bd9")] // Star: 799
        [TestCase(@"https://github.com/apache/cordova-wp8.git",
                @"30fba42357f8b6cf2e9a433128369c8f4cc914bb")] // Star: 49
        [TestCase(@"https://github.com/magicdict/MagicMongoDBTool.git",
                @"694ab21e1d4e4d3f47c1d9e31527c96b2a0e29bc")] // Star: 92
        [TestCase(@"https://github.com/sharpdx/SharpDX.git",
                @"65799e012fa2200748b16095aebb7b9427a6fb16")] // Star: 201
        [TestCase(@"https://github.com/hbons/SparkleShare.git",
                @"4085f1937041d89f76829336119f8b68ce97b43c")] // Star: 3033
        [TestCase(@"https://github.com/ServiceStack/ServiceStack.git",
                @"6cb92e0429e2cce31ef68e4fa02801718b00dd4f")] // Star: 2285
        [TestCase(@"https://github.com/mono/mono.git",
                @"81bdc35dd4b800831efc540be9705e021f8b848a")] // Star: 2056
        [TestCase(@"https://github.com/AutoMapper/AutoMapper.git",
                @"bc2ece165e028b4dbe963d978ef54e1ed2b50f5f")] // Star: 1853
        [TestCase(@"https://github.com/restsharp/RestSharp.git",
                @"70be25dae0edb44a1c962aee078e9dbf74cb4177")] // Star: 1828
        [TestCase(@"https://github.com/Redth/PushSharp.git",
                @"19216ead2bfbbf36c4fcaa95dfa8469facc5a7ef")] // Star: 1688
        [TestCase(@"https://github.com/opserver/Opserver.git",
                @"a170ea8bcda9f9e52d4aaff7339f3d198309369b")] // Star: 1324
        [TestCase(@"https://github.com/robconery/massive.git",
                @"87075153609fe096bcbd9f81a6901c1b60e2e579")] // Star: 1203
        [TestCase(@"https://github.com/SamSaffron/dapper-dot-net.git",
                @"885a8d46cbd67f09bd6a5e686a824759d79d5f78")] // Star: 1182
        [TestCase(@"https://github.com/ravendb/ravendb.git",
                @"a60d8dd3ffaf5892d86d5fcf8a9a81bec71800e7")] // Star: 1118
        [TestCase(@"https://github.com/SamSaffron/MiniProfiler.git",
                @"3744054e0686b2f88083b869a7f2fe7e1fa14e9c")] // Star: 1113
        [TestCase(@"https://github.com/jaredpar/VsVim.git",
                @"86d9e298c9d117e54266501ae9c4dd35b4d345cb")] // Star: 1097
        [TestCase(@"https://github.com/mono/roslyn.git",
                @"35ebc72b4fde323dde2c372d70ecd6437de97c4c")] // Star: 46
        [TestCase(@"https://github.com/PlasmaByte/PokemonNXT.git",
                @"8cf7d43119ea1a7cba4f8711472efefb54bb53fb")] // Star: 34
        [TestCase(@"https://github.com/robconery/biggy.git",
                @"0c7a0cb8f08b0ac7e5d87f91c5617d4cc6e21b84")] // Star: 266
        [TestCase(@"https://github.com/jstedfast/MailKit.git",
                @"3ef47b326f89a4a6ad960c9fcca00bdbac18a227")] // Star: 122
        [TestCase(@"https://github.com/madskristensen/WebEssentials2013.git",
                @"e422af47986bfd6c70ee6564cb1bf892cbf197f8")] // Star: 489
        [TestCase(@"https://github.com/jamesmontemagno/Xam.PCL.Plugins.git",
                @"0e6151295a2dba17f77c90034e4820ca42a941d9")] // Star: 28
        [TestCase(@"https://github.com/xamarin/xamarin-store-app.git",
                @"a68dcd6f07a45a127c6ed9af21fc8084f1b3bcb5")] // Star: 38
        [TestCase(@"https://github.com/StephanieRct/NieMath.git",
                @"9a4a49ab374d1652c3568ea5960b0de9a0218ea1")] // Star: 32
        [TestCase(@"https://github.com/MvvmCross/MvvmCross.git",
                @"fd16e13d05678e578ddc96938a680b3d94d8a496")] // Star: 706
        [TestCase(@"https://github.com/reactiveui/ReactiveUI.git",
                @"45aaa51f5d5202a5c8d34ea3151955f0bce8a956")] // Star: 888
        [TestCase(@"https://github.com/Moq/moq4.git",
                @"ac31aeca01056e3608540d5b5d043ba013f19abe")] // Star: 273
        [TestCase(@"https://github.com/xunit/xunit.git",
                @"075bedaa4a25ca407b6a73f4e5c2f68298618967")] // Star: 137
        [TestCase(@"https://github.com/playgameservices/play-games-plugin-for-unity.git",
                @"3ad9798396cc5e443815d5c1438bcebc54d98ed9")] // Star: 281
        [TestCase(@"https://github.com/qianlifeng/Wox.git",
                @"b07d1b027c42c045bce8304b40b4c27e4d03248f")] // Star: 334
        [TestCase(@"https://github.com/serilog/serilog.git",
                @"60e8120a12abee4db942d2ff03b123341fab1fff")] // Star: 161
        [TestCase(@"https://github.com/akkadotnet/akka.net.git",
                @"25b66cc2d62fc2bfc50cd4050ac6fdd6909063fa")] // Star: 177
        [TestCase(@"https://github.com/autofac/Autofac.git",
                @"8c0732e120b55d277dc9313827fe02bbde289f3e")] // Star: 182
        [TestCase(@"https://github.com/umbraco/Umbraco-CMS.git",
                @"5697809ce930e1b8f9f111586c2b4bb59e8f3869")] // Star: 458
        [TestCase(@"https://github.com/xamarin/monodroid-samples.git",
                @"4851316a320c9c6ce0b57348d05c6dc6e8819e1c")] // Star: 597
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "java_repo.txt", "*.java");
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