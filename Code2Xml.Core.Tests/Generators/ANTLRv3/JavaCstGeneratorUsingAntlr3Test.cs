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
using Code2Xml.Core.Generators.ANTLRv3.Java;
using Code2Xml.Learner.Core.Learning.Experiments;
using NUnit.Framework;
using ParserTests;

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
        [TestCase(@"https://github.com/greenrobot/greenDAO.git",
                @"d13a1f1d0e8d244e8033a944599adda7bb157bef", 1039)]
        [TestCase(@"https://github.com/commonsguy/cw-advandroid.git",
                @"ab8e52a00413592b99a7bb9f93050bee760f289f", 1028)]
        [TestCase(@"https://github.com/koush/AndroidAsync.git",
                @"09c60732944a20eac52301026e9c24344ccb3062", 993)]
        [TestCase(@"https://github.com/ether/pad.git",
                @"cb4977238f55f9b2518e7c43a5c769823b0afd45", 987)]
        [TestCase(@"https://github.com/square/android-times-square.git",
                @"2bb367039b3cb93e6764e55835dc023df9f4fd77", 967)]
        [TestCase(@"https://github.com/grails/grails-core.git",
                @"048025b9b98332645df30d82593d44b1f7a84bbd", 960)]
        [TestCase(@"https://github.com/pardom/ActiveAndroid.git",
                @"bd98740d466249fc085311b1c166570cfc08f532", 959)]
        [TestCase(@"https://github.com/kevinsawicki/http-request.git",
                @"c11e2a8b335d43adb9e273412ec7a39c7e404e72", 939)]
        [TestCase(@"https://github.com/mongodb/mongo-java-driver.git",
                @"244b5a26bfe1b6f9e15264d690fa944e7c6e2c54", 924)]
        [TestCase(@"https://github.com/hibernate/hibernate-orm.git",
                @"9bd6917d0d92c3d350b74f23c03af5a4bb80890d", 910)]
        [TestCase(@"https://github.com/qii/weiciyuan.git",
                @"14fdfe9f6f7f3d927a66d802b709f53ba0ff629e", 906)]
        [TestCase(@"https://github.com/BonzaiThePenguin/WikiSort.git",
                @"b83bde28fbf26198749eb0169d7f01052841b192", 905)]
        [TestCase(@"https://github.com/tjerkw/Android-SlideExpandableListView.git",
                @"a44e6f0fcfabf3a870469667b219552a5d562e87", 901)]
        [TestCase(@"https://github.com/jgilfelt/android-viewbadger.git",
                @"e08c3a78cb92c0c8587790b15e73434f972912cf", 900)]
        [TestCase(@"https://github.com/commonsguy/cw-android.git",
                @"568c11f2b9b556027dda05ad7b62c044f039b4e4", 899)]
        [TestCase(@"https://github.com/orientechnologies/orientdb.git",
                @"8bfc83acadc833b40ec3d485216b39b786935b4c", 897)]
        [TestCase(@"https://github.com/Netflix/curator.git",
                @"1e66d7ccd7ac601df3c814833f1b9e32b25331c6", 896)]
        [TestCase(@"https://github.com/mttkay/droid-fu.git",
                @"469b1bf7a844cc09866bad95fc06321291c649e8", 882)]
        [TestCase(@"https://github.com/thest1/LazyList.git",
                @"0f37d108f2067f5f44749eb0ad44e51656f96f02", 882)]
        [TestCase(@"https://github.com/reactor/reactor.git",
                @"83f0b805ca0a8e5fd9cd881e6370c173685ad228", 875)]
        [TestCase(@"https://github.com/novoda/android.git",
                @"3052e6d253bd6a29c3e9b043ba87021242857ba5", 875)]
        [TestCase(@"https://github.com/pcpratts/rootbeer1.git",
                @"c046801c73b9b2e48d4fe40739b0ce68c496d103", 872)]
        [TestCase(@"https://github.com/spring-projects/spring-mvc-showcase.git",
                @"c7b9162c061e135c081a28bf7fc209bb9a992cea", 869)]
        [TestCase(@"https://github.com/yangfuhai/afinal.git",
                @"e706f0e896f8f819aa9a6a8374c7fe9f71fa4950", 865)]
        [TestCase(@"https://github.com/todoroo/astrid.git",
                @"4fc5c7714fb1b48ae46dcacbda287bcef9c3f6bf", 848)]
        [TestCase(@"https://github.com/twitter/ambrose.git",
                @"9ff6dc68e6eb7e95645878082774f44acca5814f", 847)]
        [TestCase(@"https://github.com/perwendel/spark.git",
                @"f1f06769abacc6732e511774d4db2306cbe5db54", 843)]
        [TestCase(@"https://github.com/metamx/druid.git",
                @"db5f04c84dc7b23f87aac31397f1a6457f4903f7", 837)]
        [TestCase(@"https://github.com/robovm/robovm.git",
                @"a72f06e62dbe4afd3271fb3bfa4ca2c4d47d3329", 832)]
        [TestCase(@"https://github.com/rzwitserloot/lombok.git",
                @"6afa3d2ec9ec18ed8ae5f6c5217b9fb1710c69c7", 827)]
        [TestCase(@"https://github.com/tinkerpop/blueprints.git",
                @"34b5b83fcfd92cca3a69c425c67a9a782dd18c42", 824)]
        [TestCase(@"https://github.com/addthis/stream-lib.git",
                @"56c48e001341f874c37e0113c09554436e93ea10", 808)]
        [TestCase(@"https://github.com/jgilfelt/android-mapviewballoons.git",
                @"a47528473b562170fbed33b7cf01da2353300acd", 806)]
        [TestCase(@"https://github.com/http-kit/http-kit.git",
                @"7184fa8cf2526a24446e7e6602bc16d9d1c0948a", 804)]
        [TestCase(@"https://github.com/alibaba/druid.git",
                @"4bebaa9d86038ec563febd2f50e7b232544a3ab7", 798)]
        [TestCase(@"https://github.com/apache/hadoop-common.git",
                @"572bd72991fe976da586db41ac4dd03466a480dd", 795)]
        [TestCase(@"https://github.com/quartzjer/TeleHash.git",
                @"133f4212666911d066f59255e2e7fbd69bea8265", 791)]
        [TestCase(@"https://github.com/Netflix/ice.git",
                @"f5cd61177fca0ea0d45eecacc7c3209e8b1bbc57", 790)]
        [TestCase(@"https://github.com/cucumber/cucumber-jvm.git",
                @"08e6b87a0a21010bf35d643157b7032a40832efd", 784)]
        [TestCase(@"https://github.com/BoltsFramework/Bolts-Android.git",
                @"b046dfdbe9b36989ab7bf4492dc403a20118c590", 781)]
        [TestCase(@"https://github.com/cloudera/flume.git",
                @"1d7535638556998e895d55599a2f4a024390edd1", 774)]
        [TestCase(@"https://github.com/romannurik/muzei.git",
                @"a9d2ccfaeccabad26f9c6eba26355882654cc4c1", 774)]
        [TestCase(@"https://github.com/linkedin/indextank-engine.git",
                @"f2354fe9db43786126e304d12aae4322ae7b98b1", 770)]
        [TestCase(@"https://github.com/tjake/Solandra.git",
                @"64e1d192604144c06962e284523cce3c4df51c4e", 768)]
        [TestCase(@"https://github.com/jankotek/MapDB.git",
                @"c890d8b4edc5fb9d064bb04aa132aea8608f87dd", 763)]
        [TestCase(@"https://github.com/alibaba/fastjson.git",
                @"5e3ede7923bd4b7930b8f785b900e80753b97c01", 763)]
        [TestCase(@"https://github.com/ginatrapani/todo.txt-android.git",
                @"ce117c601510cb7343f4633e3033ec0cbfe35ff7", 761)]
        [TestCase(@"https://github.com/maurycyw/StaggeredGridView.git",
                @"06dbc841a6330143f114eba82566d25b5a808c61", 758)]
        [TestCase(@"https://github.com/amplab/tachyon.git",
                @"6ce29b2da55130e7cb32a32f029fef43cdc35ef5", 756)]
        [TestCase(@"https://github.com/peter-lawrey/Java-Chronicle.git",
                @"6716f0cff0750d125a07eb769bba0698a617b7fb", 756)]
        [TestCase(@"https://github.com/TooTallNate/Java-WebSocket.git",
                @"7c3b223536dc8bd4e8794ac265ad06679583e30f", 754)]
        [TestCase(@"https://github.com/facebook/hadoop-20.git",
                @"9f1ea1b28047a4b16f4962c7561613f139dd3e86", 752)]
        [TestCase(@"https://github.com/derekbrameyer/android-betterpickers.git",
                @"0a72367b478970b1731822e78790a158a4f7ebb4", 740)]
        [TestCase(@"https://github.com/typesafehub/config.git",
                @"36c1392028c82db2c146ade29a2f6940bc6f5407", 736)]
        [TestCase(@"https://github.com/leachim6/hello-world.git",
                @"02e3bb8c5b356739644d24c60adbe6dda020b6fc", 734)]
        [TestCase(@"https://github.com/OpenTSDB/opentsdb.git",
                @"a2bd5737d9d11a8fd3fa6e9c36a31dd8cb5c4af4", 733)]
        [TestCase(@"https://github.com/kevinweil/elephant-bird.git",
                @"ccddfc68e634fea2d05a1804057a1c4826817471", 723)]
        [TestCase(@"https://github.com/inmite/android-styled-dialogs.git",
                @"38975c5220aeab1d79ee3db2a8c4d269c0600c38", 723)]
        [TestCase(@"https://github.com/rstudio/rstudio.git",
                @"cb0b00ee99905c6e2cf1e88b4bee316214d54769", 722)]
        [TestCase(@"https://github.com/JodaOrg/joda-time.git",
                @"fcf264d737af5a37d45c6c5c9802487ce53c8de8", 722)]
        [TestCase(@"https://github.com/neo4j/neo4j.git",
                @"521ec09bd83bdee1ef39af4dc162fe0c88fedf4b", 719)]
        [TestCase(@"https://github.com/jfeinstein10/JazzyViewPager.git",
                @"05fab564593adffec28c76857520ab35f908dea0", 719)]
        [TestCase(@"https://github.com/hazelcast/hazelcast.git",
                @"67389104cdb892d040bc15e7df39ab4bd5df3895", 718)]
        [TestCase(@"https://github.com/castorflex/SmoothProgressBar.git",
                @"9198cb9201268cec63e69d87cdbfb879a962f827", 708)]
        [TestCase(@"https://github.com/JakeWharton/hugo.git",
                @"de887a549a14fba7e3735ce4c202e15502c78a43", 702)]
        [TestCase(@"https://github.com/MovingBlocks/Terasology.git",
                @"387497a2ea91b25339b3cbe8b18338edd7d3d1f5", 701)]
        [TestCase(@"https://github.com/nathanmarz/storm-starter.git",
                @"917a4c5c171009af3b130d09339355f6310a2042", 695)]
        [TestCase(@"https://github.com/0xdata/h2o.git",
                @"c5e4bfd7e1b1ecc59b5d9c40eb0f56bfabf646be", 694)]
        [TestCase(@"https://github.com/apache/lucene-solr.git",
                @"9e87821edeb3e24ca8dedaecf856f6510d61d0d3", 692)]
        [TestCase(@"https://github.com/koush/UrlImageViewHelper.git",
                @"a9897afbf0277727810158c9739c3ddd9cf15899", 690)]
        [TestCase(@"https://github.com/mongodb/mongo-hadoop.git",
                @"29788439cbc8cc9a45910ceba316a70049a8b4e8", 689)]
        [TestCase(@"https://github.com/JakeWharton/scalpel.git",
                @"97299acd1cc7b4138af714f1ed0bce47e9ce516d", 684)]
        [TestCase(@"https://github.com/JakeWharton/u2020.git",
                @"543eaea54f04fd4397aa74f4578670e279cc857a", 680)]
        [TestCase(@"https://github.com/novoda/ImageLoader.git",
                @"a82512b76c43e271a15717e0697055cd9e3d9031", 678)]
        [TestCase(@"https://github.com/ansjsun/ansj_seg.git",
                @"ab56d87c9799e543e4141840809b52aa27932d87", 671)]
        [TestCase(@"https://github.com/apache/mahout.git",
                @"add3038b35029cf886ac907822016c91ec4b4278", 668)]
        [TestCase(@"https://github.com/RobotiumTech/robotium.git",
                @"ee7d989c95f2cf380935f7a117d7f9345820cbf7", 664)]
        [TestCase(@"https://github.com/harism/android_page_curl.git",
                @"7a2c8f152bb4f1b0de3b1aa72b3cb79e1fe8e3bd", 664)]
        [TestCase(@"https://github.com/commonsguy/cwac-endless.git",
                @"7a6fe3c123fc85e08c36b6db6a88740385625340", 658)]
        [TestCase(@"https://github.com/hector-client/hector.git",
                @"0c760d9347ebf9bdaeec5fe195f175f674590909", 655)]
        [TestCase(@"https://github.com/mortardata/mortar-recsys.git",
                @"617fbf66a8e8fb7738354c224760dc2419ed0c13", 654)]
        [TestCase(@"https://github.com/eishay/jvm-serializers.git",
                @"3ec217ec19aff74654b40a47c010d57a44996efb", 653)]
        [TestCase(@"https://github.com/notnoop/java-apns.git",
                @"20c10ebd22e15a55c0c1c12695c535d37435dcfd", 652)]
        [TestCase(@"https://github.com/siyamed/android-satellite-menu.git",
                @"ff0964c849095eb17c5fe9f84f158e39d5a5ef03", 652)]
        [TestCase(@"https://github.com/jberkel/sms-backup-plus.git",
                @"3565f645126d3f9e8c0371ec57c8aac4bbf5cde1", 647)]
        [TestCase(@"https://github.com/jayway/maven-android-plugin.git",
                @"2ce1428c8e83365c5ac096b7855e71bd8a035013", 645)]
        [TestCase(@"https://github.com/BuildCraft/BuildCraft.git",
                @"080b4ba74990c6488f7c645cc64d3985f47e42fd", 643)]
        [TestCase(@"https://github.com/brianfrankcooper/YCSB.git",
                @"4791826f0b90c472dd04cc5eb6ed73c4d5906330", 632)]
        [TestCase(@"https://github.com/facebook/buck.git",
                @"def0eb1077d6c2a9f129b200e8356acaec9a17ed", 631)]
        [TestCase(@"https://github.com/square/spoon.git",
                @"975dacb45607ed45492fa3dd9e697f0a5263e71a", 630)]
        [TestCase(@"https://github.com/aws/aws-sdk-java.git",
                @"f04beb908018dcb0ca58ac6e00f2bd66953efe45", 628)]
        [TestCase(@"https://github.com/fastestforward/gauges-android.git",
                @"372528e3a689fa38f582330e69f7a31c62b2aa9c", 621)]
        [TestCase(@"https://github.com/gephi/gephi.git",
                @"5777cab4a8f649ef85f4c571f37b0df43e4db46f", 620)]
        [TestCase(@"https://github.com/MinecraftForge/MinecraftForge.git",
                @"2cef9c5cb29fdaa1d118591604ff7c5f2e956c09", 619)]
        [TestCase(@"https://github.com/goldmansachs/gs-collections.git",
                @"4e597130fbe4e6f9d745a8d5348c77c45e9341d8", 619)]
        [TestCase(@"https://github.com/cloudera/oryx.git",
                @"8986b58e49b55d7c57f72f232596689a16a013a9", 617)]
        [TestCase(@"https://github.com/sk89q/worldedit.git",
                @"33d4285f1a7af21b42585fccca5a93036c953262", 613)]
        [TestCase(@"https://github.com/spring-projects/spring-boot.git",
                @"620d8eb87e63ab23bf667c2b1c6518d9fd2ab187", 613)]
        [TestCase(@"https://github.com/redsolution/xabber-android.git",
                @"2b8e6b216fa2a928b2f62b7cd62b2c079d706d38", 612)]
        [TestCase(@"https://github.com/geometer/FBReaderJ.git",
                @"ec96ce8dd837f495fbeafef8592001e06b601bb0", 611)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepo(url, commitPointer, "*.java");
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