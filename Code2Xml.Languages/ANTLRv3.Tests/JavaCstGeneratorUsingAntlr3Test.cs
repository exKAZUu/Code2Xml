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
        [TestCase(@"https://github.com/nathanmarz/storm.git",
                @"cdb116e942666973bc4eaa0df098d5bab82739e7", 8108)]
        [TestCase(@"https://github.com/elasticsearch/elasticsearch.git",
                @"e688f445ad15054d9335f71c94a0b6736877481b", 6637)]
        [TestCase(@"https://github.com/JakeWharton/ActionBarSherlock.git",
                @"4a79d536af872339899a90d6dc743aa57745474b", 5553)]
        [TestCase(@"https://github.com/jfeinstein10/SlidingMenu.git",
                @"4254feca3ece9397cd501921ee733f19ea0fdad8", 5192)]
        [TestCase(@"https://github.com/nostra13/Android-Universal-Image-Loader.git",
                @"29811229c3ba3da390b29353875be2c92f88a789", 4251)]
        [TestCase(@"https://github.com/github/android.git",
                @"9d490829b944d3a2c77dbd0010ec7a0bfe2efaee", 3881)]
        [TestCase(@"https://github.com/JakeWharton/Android-ViewPagerIndicator.git",
                @"8cd549f23f3d20ff920e19a2345c54983f65e26b", 3466)]
        [TestCase(@"https://github.com/loopj/android-async-http.git",
                @"6077c6aa7bf06b2b8c13fbb4355e094dea436b7c", 3304)]
        [TestCase(@"https://github.com/spring-projects/spring-framework.git",
                @"09248a0b372ad2e6019b44190ae64f4316dbc1fd", 3294)]
        [TestCase(@"https://github.com/libgdx/libgdx.git",
                @"ed9733d93a2e5bdf20e10e8c10437e86a66941a2", 3289)]
        [TestCase(@"https://github.com/clojure/clojure.git",
                @"201a0dd9701e1a0ee3998431241388eb4a854ebf", 3051)]
        [TestCase(@"https://github.com/chrisbanes/Android-PullToRefresh.git",
                @"3bd8ef6869c3297bfe874d2f15c2ee53c3456e99", 3007)]
        [TestCase(@"https://github.com/eclipse/vert.x.git",
                @"4a6498baa2269a0dc753861d0539ebeee5926769", 2866)]
        [TestCase(@"https://github.com/facebook/facebook-android-sdk.git",
                @"118e756568f7e9a8045e87575c190a2c304071a6", 2818)]
        [TestCase(@"https://github.com/netty/netty.git",
                @"8615f7a69ecbbabd6d8f7ba8cae90ba63d702fec", 2805)]
        [TestCase(@"https://github.com/excilys/androidannotations.git",
                @"5e769c2d90c76ebfe685f6423435b3fda5fa4bc6", 2725)]
        [TestCase(@"https://github.com/sparklemotion/nokogiri.git",
                @"163103b0eaf904575e62909eddc00dcc9e425a2a", 2604)]
        [TestCase(@"https://github.com/junit-team/junit.git",
                @"e65558c174a8f5c4c7758f0d9dd1ffe027b023d8", 2461)]
        [TestCase(@"https://github.com/AndroidBootstrap/android-bootstrap.git",
                @"e43e3ac4a5984edf9a6ccc87bac04be177a3615a", 2446)]
        [TestCase(@"https://github.com/square/picasso.git",
                @"e0c3d44f53919742a0a608277be26b47742bb2a2", 2312)]
        [TestCase(@"https://github.com/facebook/presto.git",
                @"b4b5d67e09576ec38be1564123e5a0e2d4bc1996", 2281)]
        [TestCase(@"https://github.com/chrisbanes/ActionBar-PullToRefresh.git",
                @"65d4183994eaf8c450e81afadb389fca61499063", 2272)]
        [TestCase(@"https://github.com/WhisperSystems/TextSecure.git",
                @"4d52d2ee364c2edad50420a9afa500dde66a48d9", 2261)]
        [TestCase(@"https://github.com/cyrilmottier/GreenDroid.git",
                @"abd9769f677bb4a753f0bf1119f961187bdf7020", 2123)]
        [TestCase(@"https://github.com/dropwizard/metrics.git",
                @"e61395657d9f471a88dc0d9f3c7f78f0e773fe28", 2090)]
        [TestCase(@"https://github.com/nicolasgramlich/AndEngine.git",
                @"720897f99d2c56ba357e8fe361454bd8d88c37ed", 2068)]
        [TestCase(@"https://github.com/Prototik/HoloEverywhere.git",
                @"3b6021aa4af717cd31b1b6c877f6c30b674af6d9", 2065)]
        [TestCase(@"https://github.com/Netflix/RxJava.git",
                @"8bb52a0184a194f2faa4a4732f72f62be2caafe9", 2049)]
        [TestCase(@"https://github.com/Bukkit/CraftBukkit.git",
                @"1ab090e71ea261fe38cef980bc2ebe696a494ea3", 2032)]
        [TestCase(@"https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition.git",
                @"5f399a52c8bf5626b098629906f82be1763089f4", 2005)]
        [TestCase(@"https://github.com/fernandezpablo85/scribe-java.git",
                @"135ad50a4e4e27e97f09e42ae50d6011c7af7a4b", 1997)]
        [TestCase(@"https://github.com/LMAX-Exchange/disruptor.git",
                @"1072645ad75f8b07b9145197fd4137fcfa79011a", 1836)]
        [TestCase(@"https://github.com/OpenRefine/OpenRefine.git",
                @"c2cadab47593d5d3f49e45b5fe434e117e67f8dd", 1827)]
        [TestCase(@"https://github.com/dropwizard/dropwizard.git",
                @"4758ac698ff9993879798db338b3314c6a1c6a27", 1776)]
        [TestCase(@"https://github.com/square/retrofit.git",
                @"1f7cc4942f71d6c6cf4770fcd93670bc93a8c710", 1776)]
        [TestCase(@"https://github.com/Netflix/SimianArmy.git",
                @"6a8b799af24cd638cd7110965ca8504e18cd6b24", 1743)]
        [TestCase(@"https://github.com/johannilsson/android-pulltorefresh.git",
                @"4277c1ecf6256518248a1143b3ee882c703b33d6", 1739)]
        [TestCase(@"https://github.com/SimonVT/android-menudrawer.git",
                @"1260f2f6d50d3b572ebfa98e93a0b4f8258371de", 1727)]
        [TestCase(@"https://github.com/square/dagger.git",
                @"21a9e0d875da31306b0f41273348f4f75741fef7", 1706)]
        [TestCase(@"https://github.com/Atmosphere/atmosphere.git",
                @"dd2397e03088f2bced1f8e47f8f81e935664a923", 1671)]
        [TestCase(@"https://github.com/roboguice/roboguice.git",
                @"c0c61a89ad8ce844858373748f09222de187d61e", 1644)]
        [TestCase(@"https://github.com/thinkaurelius/titan.git",
                @"c26cd982b1dc5ba792ee7a63af59887bd8b08223", 1625)]
        [TestCase(@"https://github.com/Netflix/Hystrix.git",
                @"04949497901e6fcd71f68d804e5b89f9e368271d", 1624)]
        [TestCase(@"https://github.com/etsy/AndroidStaggeredGrid.git",
                @"84a06f8da0ba70de32e7373c57f6e38b9d9b6780", 1612)]
        [TestCase(@"https://github.com/chrisbanes/PhotoView.git",
                @"99fc9956a2de2279e45af9e95286efec79c0d739", 1609)]
        [TestCase(@"https://github.com/android/platform_frameworks_base.git",
                @"aa19a2f69c33fdb6499d0bc1cfafced9f572da5b", 1606)]
        [TestCase(@"https://github.com/jeresig/processing-js.git",
                @"02363398a823eae731cafa180a5581fe353397bf", 1553)]
        [TestCase(@"https://github.com/apache/cassandra.git",
                @"6e97178a50d1cc9a6817653e463ef5f0cf132873", 1540)]
        [TestCase(@"https://github.com/springside/springside4.git",
                @"c92379755c041cd081c8c4cd881b44283a80f845", 1500)]
        [TestCase(@"https://github.com/zxing/zxing.git",
                @"41caac38e8414be512fee712dae98966b7f4f05e", 1494)]
        [TestCase(@"https://github.com/47deg/android-swipelistview.git",
                @"f0d4859100d7cb80e3e7ca4551daa69d5c61fd25", 1486)]
        [TestCase(@"https://github.com/Bukkit/Bukkit.git",
                @"ec19988db3ba9415f9453c68b4861ffbe90e4153", 1477)]
        [TestCase(@"https://github.com/bauerca/drag-sort-listview.git",
                @"c3cfccee21676149dfdf8e803c0ec2eaebc6b841", 1449)]
        [TestCase(@"https://github.com/keyboardsurfer/Crouton.git",
                @"0957a7ea09e40d521defa28c6d1ffa1127f7e7da", 1441)]
        [TestCase(@"https://github.com/gabrielemariotti/cardslib.git",
                @"3a1998cbf4d1ab24a5dcf22441fadafab3da655f", 1436)]
        [TestCase(@"https://github.com/yui/yuicompressor.git",
                @"e814062c2f1f8c75decde08e884d84387938faba", 1430)]
        [TestCase(@"https://github.com/aporter/coursera-android.git",
                @"a4c1fceac0d2c0a86f74ebad8ccc7539330e8290", 1405)]
        [TestCase(@"https://github.com/gradle/gradle.git",
                @"b690b255ecefe8724fd78e8248d91be054e8e718", 1400)]
        [TestCase(@"https://github.com/emilsjolander/StickyListHeaders.git",
                @"60eecee1b8a53a0c6de9a5d6ddb3cefbfef6d90a", 1379)]
        [TestCase(@"https://github.com/xetorthio/jedis.git",
                @"ac53759f9706b52184963e98af11d2e44bfb1297", 1373)]
        [TestCase(@"https://github.com/square/okhttp.git",
                @"c51e223ff96da5f6581515d7080a080808c35384", 1353)]
        [TestCase(@"https://github.com/nhaarman/ListViewAnimations.git",
                @"98a4793f62bbb4c9c9aaec199ccdeb3b4403a162", 1352)]
        [TestCase(@"https://github.com/astuetz/PagerSlidingTabStrip.git",
                @"3f4738eca833faeca563d93cd77c8df763a45fb6", 1340)]
        [TestCase(@"https://github.com/koush/ion.git",
                @"d14f69b87387bb57a213c871ff57dd42c3481e5b", 1324)]
        [TestCase(@"https://github.com/k9mail/k-9.git",
                @"8e078bc0146cf0ab02a54c1d852842f6ee734f23", 1323)]
        [TestCase(@"https://github.com/stephanenicolas/robospice.git",
                @"03d119df6de56c0007a65b21582c99adb22734b4", 1304)]
        [TestCase(@"https://github.com/square/otto.git",
                @"b821b22e283dabc08ae09786861c4a958000a5ae", 1297)]
        [TestCase(@"https://github.com/videlalvaro/gifsockets.git",
                @"0ccb1fd01edeb835a90c0c1140ad91dbd1a354b1", 1285)]
        [TestCase(@"https://github.com/greenrobot/EventBus.git",
                @"0fe7ea575c508ac3b072b4a31ecea9c8680435be", 1270)]
        [TestCase(@"https://github.com/voldemort/voldemort.git",
                @"351f4dee88829f2107afd5c283fb0768b5282165", 1261)]
        [TestCase(@"https://github.com/JakeWharton/NineOldAndroids.git",
                @"9f20fd77e04942fd50b95aeb1c492a38e36c06dd", 1252)]
        [TestCase(@"https://github.com/pakerfeldt/android-viewflow.git",
                @"3da74fa32a935bcbb37e5ebeb270477cde1985d4", 1247)]
        [TestCase(@"https://github.com/johannilsson/android-actionbar.git",
                @"093a5f8039dfade914f52b55b5536b95850ddaf1", 1242)]
        [TestCase(@"https://github.com/androidquery/androidquery.git",
                @"45ed6c85dcf0b3b58a08810b423886fb275b33b0", 1225)]
        [TestCase(@"https://github.com/ACRA/acra.git",
                @"ee7085683018b556e73f74b059040d93794cf388", 1196)]
        [TestCase(@"https://github.com/AsyncHttpClient/async-http-client.git",
                @"f96bcbbe906c1e472fbbd7cca5cfaf3778db02d6", 1175)]
        [TestCase(@"https://github.com/xamarin/XobotOS.git",
                @"f20db6295e878a2f298c5e3896528e240785805b", 1166)]
        [TestCase(@"https://github.com/umano/AndroidSlidingUpPanel.git",
                @"38327d828690da0771e7b35a15a118eeecc20e26", 1161)]
        [TestCase(@"https://github.com/amlcurran/ShowcaseView.git",
                @"cc55def081814213c94ad80be4195b17ac4ef18c", 1145)]
        [TestCase(@"https://github.com/openaphid/android-flip.git",
                @"ab2dea1b045ffc626221c2826ce9dd00823e696d", 1142)]
        [TestCase(@"https://github.com/jhy/jsoup.git",
                @"80158d6fa7445506eaaafdeadb1f4dc291ca10a5", 1129)]
        [TestCase(@"https://github.com/yinwang0/pysonar2.git",
                @"240192fb7827dedd9381dbfdd0df3062c47078d0", 1128)]
        [TestCase(@"https://github.com/JetBrains/intellij-community.git",
                @"e8b5589ad6a04a407d6af701dd72dc0540118688", 1124)]
        [TestCase(@"https://github.com/commonsguy/cw-omnibus.git",
                @"674f1edab621b409922028d0326e02e9ad81015f", 1124)]
        [TestCase(@"https://github.com/JakeWharton/butterknife.git",
                @"3a6f2eb9713cfcea3037282e4fc4d34d50f19d6c", 1121)]
        [TestCase(@"https://github.com/tinkerpop/gremlin.git",
                @"e622d5bf289ef8f74a088dc0237c69b98baf6792", 1111)]
        [TestCase(@"https://github.com/wildfly/wildfly.git",
                @"23dc89381b609dcdac4d2f9da4e4d78b235c51e3", 1102)]
        [TestCase(@"https://github.com/yusuke/twitter4j.git",
                @"747982dfdccd6d1b2ef4857720fe289455a435a1", 1101)]
        [TestCase(@"https://github.com/twall/jna.git",
                @"323a913bf610c982f43b58883b0fc54c78a29621", 1098)]
        [TestCase(@"https://github.com/phonegap/phonegap-facebook-plugin.git",
                @"ccb2a6f648bb2ed44e4b7b71add4fb7b7e95eaed", 1084)]
        [TestCase(@"https://github.com/purplecabbage/phonegap-plugins.git",
                @"319dfb7297002040ec7ab98896e68d05c7fd8180", 1083)]
        [TestCase(@"https://github.com/Comcast/FreeFlow.git",
                @"47bfb57e8037eecae320266cb00dd23e673362e5", 1079)]
        [TestCase(@"https://github.com/ManuelPeinado/FadingActionBar.git",
                @"f679e313d105075cfb389695052348ee09a8e80a", 1068)]
        [TestCase(@"https://github.com/bigbluebutton/bigbluebutton.git",
                @"55773f594eed3e0eff5af47ec8cbd6fcf713a56a", 1062)]
        [TestCase(@"https://github.com/mttkay/ignition.git",
                @"bbeb55cb4f080bdc31e549142ea745c65e4727c7", 1058)]
        [TestCase(@"https://github.com/processing/processing.git",
                @"9c63a2c4a227ed2329fd01006cb593ba8954962d", 1054)]
        [TestCase(@"https://github.com/douglascrockford/JSON-java.git",
                @"4d86b05d3c6a72e88c476430d60676f9ae2fafab", 1052)]
        [TestCase(@"https://github.com/Athou/commafeed.git",
                @"3a8d72cab4038e975af87d8083e2b7e68f2e328c", 1048)]
        [TestCase(@"https://github.com/Graylog2/graylog2-server.git",
                @"c1c5491c4a3194a19c21a7c744d5d45421ecd227", 1041)]
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
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepositorySavingRepo(
                    url, commitPointer, "java_repo.csv", starCount, "*.java");
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