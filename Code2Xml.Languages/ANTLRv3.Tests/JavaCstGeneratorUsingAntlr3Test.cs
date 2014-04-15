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
        //[TestCase(@"https://github.com/Findwise/Hydra.git",
        //        @"5c781845a466f99645eac9fa27fb27aceb88a442")]
        //[TestCase(@"https://github.com/Netflix/RxJava.git",
        //        @"bd87341aecb408b2a0acc3f7a42dc118be006b1d")]
        //[TestCase(@"https://github.com/derekbrameyer/android-betterpickers.git",
        //        @"5646215424ad779f1f780254101b75221675b76b")]
        //[TestCase(@"https://github.com/path/android-priority-jobqueue.git",
        //        @"d3b33d9ae94df76ffde1f4b9735c0f7cc6463384")]
        //[TestCase(@"https://github.com/elasticsearch/elasticsearch.git",
        //        @"2f32908193f3f61139da054f0ee5a949f8c589dc")]
        //[TestCase(@"https://code.google.com/p/pageobjectgenerator/",
        //        @"169bdaf6a5a08fab62e167764e7f8401309d7b64")]
        //[TestCase(@"https://github.com/facebook/presto.git",
        //        @"78045f8ede1f1e3deb4e40b880745141480d362f")]
        //[TestCase(@"https://github.com/JakeWharton/scalpel.git",
        //        @"27338feaa632bc160ae4f27f001474f0850310ea")]
        //[TestCase(@"https://github.com/nathanmarz/storm.git",
        //        @"66a397368a98834095b47db2b706420901c52ba3")]
        //[TestCase(@"https://github.com/JakeWharton/u2020.git",
        //        @"a08a7ec51e01cc40aa27779dca52277e69d156f7")]
        //[TestCase(@"https://code.google.com/p/guava-libraries/",
        //        @"f510d9bc51715c4d583e0b152e5d0265c44c982f")]
        [TestCase(@"https://github.com/jfeinstein10/SlidingMenu.git",
                @"4254feca3ece9397cd501921ee733f19ea0fdad8")] // Star: 5192
        [TestCase(@"https://github.com/spring-projects/spring-framework.git",
                @"09248a0b372ad2e6019b44190ae64f4316dbc1fd")] // Star: 3294
        [TestCase(@"https://github.com/junit-team/junit.git",
                @"e65558c174a8f5c4c7758f0d9dd1ffe027b023d8")] // Star: 2461
        [TestCase(@"https://github.com/github/android.git",
                @"9d490829b944d3a2c77dbd0010ec7a0bfe2efaee")] // Star: 3881
        [TestCase(@"https://github.com/excilys/androidannotations.git",
                @"5e769c2d90c76ebfe685f6423435b3fda5fa4bc6")] // Star: 2725
        [TestCase(@"https://github.com/AndroidBootstrap/android-bootstrap.git",
                @"e43e3ac4a5984edf9a6ccc87bac04be177a3615a")] // Star: 2446
        [TestCase(@"https://github.com/elasticsearch/elasticsearch.git",
                @"e688f445ad15054d9335f71c94a0b6736877481b")] // Star: 6637
        [TestCase(@"https://github.com/chrisbanes/Android-PullToRefresh.git",
                @"3bd8ef6869c3297bfe874d2f15c2ee53c3456e99")] // Star: 3007
        [TestCase(@"https://github.com/JakeWharton/ActionBarSherlock.git",
                @"4a79d536af872339899a90d6dc743aa57745474b")] // Star: 5553
        [TestCase(@"https://github.com/loopj/android-async-http.git",
                @"6077c6aa7bf06b2b8c13fbb4355e094dea436b7c")] // Star: 3304
        [TestCase(@"https://github.com/Bearded-Hen/Android-Bootstrap.git",
                @"9187a05fd7d91350569347f8565078441135d8d4")] // Star: 2650
        [TestCase(@"https://github.com/sparklemotion/nokogiri.git",
                @"163103b0eaf904575e62909eddc00dcc9e425a2a")] // Star: 2604
        [TestCase(@"https://github.com/nathanmarz/storm.git",
                @"cdb116e942666973bc4eaa0df098d5bab82739e7")] // Star: 8108
        [TestCase(@"https://github.com/netty/netty.git",
                @"8615f7a69ecbbabd6d8f7ba8cae90ba63d702fec")] // Star: 2805
        [TestCase(@"https://github.com/libgdx/libgdx.git",
                @"ed9733d93a2e5bdf20e10e8c10437e86a66941a2")] // Star: 3289
        [TestCase(@"https://github.com/eclipse/vert.x.git",
                @"4a6498baa2269a0dc753861d0539ebeee5926769")] // Star: 2866
        [TestCase(@"https://github.com/facebook/facebook-android-sdk.git",
                @"118e756568f7e9a8045e87575c190a2c304071a6")] // Star: 2818
        [TestCase(@"https://github.com/JakeWharton/Android-ViewPagerIndicator.git",
                @"8cd549f23f3d20ff920e19a2345c54983f65e26b")] // Star: 3466
        [TestCase(@"https://github.com/nostra13/Android-Universal-Image-Loader.git",
                @"29811229c3ba3da390b29353875be2c92f88a789")] // Star: 4251
        [TestCase(@"https://github.com/clojure/clojure.git",
                @"201a0dd9701e1a0ee3998431241388eb4a854ebf")] // Star: 3051
        [TestCase(@"https://github.com/square/picasso.git",
                @"e0c3d44f53919742a0a608277be26b47742bb2a2")] // Star: 2312
        [TestCase(@"https://github.com/facebook/presto.git",
                @"b4b5d67e09576ec38be1564123e5a0e2d4bc1996")] // Star: 2281
        [TestCase(@"https://github.com/WhisperSystems/TextSecure.git",
                @"4d52d2ee364c2edad50420a9afa500dde66a48d9")] // Star: 2261
        [TestCase(@"https://github.com/chrisbanes/ActionBar-PullToRefresh.git",
                @"65d4183994eaf8c450e81afadb389fca61499063")] // Star: 2272
        [TestCase(@"https://github.com/dropwizard/metrics.git",
                @"e61395657d9f471a88dc0d9f3c7f78f0e773fe28")] // Star: 2090
        [TestCase(@"https://github.com/Prototik/HoloEverywhere.git",
                @"3b6021aa4af717cd31b1b6c877f6c30b674af6d9")] // Star: 2065
        [TestCase(@"https://github.com/Netflix/RxJava.git",
                @"8bb52a0184a194f2faa4a4732f72f62be2caafe9")] // Star: 2049
        [TestCase(@"https://github.com/Bukkit/CraftBukkit.git",
                @"1ab090e71ea261fe38cef980bc2ebe696a494ea3")] // Star: 2032
        [TestCase(@"https://github.com/cyrilmottier/GreenDroid.git",
                @"abd9769f677bb4a753f0bf1119f961187bdf7020")] // Star: 2123
        [TestCase(@"https://github.com/nicolasgramlich/AndEngine.git",
                @"720897f99d2c56ba357e8fe361454bd8d88c37ed")] // Star: 2068
        [TestCase(@"https://github.com/fernandezpablo85/scribe-java.git",
                @"135ad50a4e4e27e97f09e42ae50d6011c7af7a4b")] // Star: 1997
        [TestCase(@"https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition.git",
                @"5f399a52c8bf5626b098629906f82be1763089f4")] // Star: 2005
        [TestCase(@"https://github.com/OpenRefine/OpenRefine.git",
                @"c2cadab47593d5d3f49e45b5fe434e117e67f8dd")] // Star: 1827
        [TestCase(@"https://github.com/LMAX-Exchange/disruptor.git",
                @"1072645ad75f8b07b9145197fd4137fcfa79011a")] // Star: 1836
        [TestCase(@"https://github.com/dropwizard/dropwizard.git",
                @"4758ac698ff9993879798db338b3314c6a1c6a27")] // Star: 1776
        [TestCase(@"https://github.com/Netflix/SimianArmy.git",
                @"6a8b799af24cd638cd7110965ca8504e18cd6b24")] // Star: 1743
        [TestCase(@"https://github.com/johannilsson/android-pulltorefresh.git",
                @"4277c1ecf6256518248a1143b3ee882c703b33d6")] // Star: 1739
        [TestCase(@"https://github.com/Atmosphere/atmosphere.git",
                @"dd2397e03088f2bced1f8e47f8f81e935664a923")] // Star: 1671
        [TestCase(@"https://github.com/SimonVT/android-menudrawer.git",
                @"1260f2f6d50d3b572ebfa98e93a0b4f8258371de")] // Star: 1727
        [TestCase(@"https://github.com/square/retrofit.git",
                @"1f7cc4942f71d6c6cf4770fcd93670bc93a8c710")] // Star: 1776
        [TestCase(@"https://github.com/thinkaurelius/titan.git",
                @"c26cd982b1dc5ba792ee7a63af59887bd8b08223")] // Star: 1625
        [TestCase(@"https://github.com/android/platform_frameworks_base.git",
                @"aa19a2f69c33fdb6499d0bc1cfafced9f572da5b")] // Star: 1606
        [TestCase(@"https://github.com/square/dagger.git",
                @"21a9e0d875da31306b0f41273348f4f75741fef7")] // Star: 1706
        [TestCase(@"https://github.com/chrisbanes/PhotoView.git",
                @"99fc9956a2de2279e45af9e95286efec79c0d739")] // Star: 1609
        [TestCase(@"https://github.com/Netflix/Hystrix.git",
                @"04949497901e6fcd71f68d804e5b89f9e368271d")] // Star: 1624
        [TestCase(@"https://github.com/roboguice/roboguice.git",
                @"c0c61a89ad8ce844858373748f09222de187d61e")] // Star: 1644
        [TestCase(@"https://github.com/etsy/AndroidStaggeredGrid.git",
                @"84a06f8da0ba70de32e7373c57f6e38b9d9b6780")] // Star: 1612
        [TestCase(@"https://github.com/apache/cassandra.git",
                @"6e97178a50d1cc9a6817653e463ef5f0cf132873")] // Star: 1540
        [TestCase(@"https://github.com/jeresig/processing-js.git",
                @"02363398a823eae731cafa180a5581fe353397bf")] // Star: 1553
        [TestCase(@"https://github.com/springside/springside4.git",
                @"c92379755c041cd081c8c4cd881b44283a80f845")] // Star: 1500
        [TestCase(@"https://github.com/zxing/zxing.git",
                @"41caac38e8414be512fee712dae98966b7f4f05e")] // Star: 1494
        [TestCase(@"https://github.com/Bukkit/Bukkit.git",
                @"ec19988db3ba9415f9453c68b4861ffbe90e4153")] // Star: 1477
        [TestCase(@"https://github.com/gabrielemariotti/cardslib.git",
                @"3a1998cbf4d1ab24a5dcf22441fadafab3da655f")] // Star: 1436
        [TestCase(@"https://github.com/keyboardsurfer/Crouton.git",
                @"0957a7ea09e40d521defa28c6d1ffa1127f7e7da")] // Star: 1441
        [TestCase(@"https://github.com/gradle/gradle.git",
                @"b690b255ecefe8724fd78e8248d91be054e8e718")] // Star: 1400
        [TestCase(@"https://github.com/emilsjolander/StickyListHeaders.git",
                @"60eecee1b8a53a0c6de9a5d6ddb3cefbfef6d90a")] // Star: 1379
        [TestCase(@"https://github.com/yui/yuicompressor.git",
                @"e814062c2f1f8c75decde08e884d84387938faba")] // Star: 1430
        [TestCase(@"https://github.com/xetorthio/jedis.git",
                @"ac53759f9706b52184963e98af11d2e44bfb1297")] // Star: 1373
        [TestCase(@"https://github.com/square/okhttp.git",
                @"c51e223ff96da5f6581515d7080a080808c35384")] // Star: 1353
        [TestCase(@"https://github.com/aporter/coursera-android.git",
                @"a4c1fceac0d2c0a86f74ebad8ccc7539330e8290")] // Star: 1405
        [TestCase(@"https://github.com/nhaarman/ListViewAnimations.git",
                @"98a4793f62bbb4c9c9aaec199ccdeb3b4403a162")] // Star: 1352
        [TestCase(@"https://github.com/47deg/android-swipelistview.git",
                @"f0d4859100d7cb80e3e7ca4551daa69d5c61fd25")] // Star: 1486
        [TestCase(@"https://github.com/koush/ion.git",
                @"d14f69b87387bb57a213c871ff57dd42c3481e5b")] // Star: 1324
        [TestCase(@"https://github.com/k9mail/k-9.git",
                @"8e078bc0146cf0ab02a54c1d852842f6ee734f23")] // Star: 1323
        [TestCase(@"https://github.com/stephanenicolas/robospice.git",
                @"03d119df6de56c0007a65b21582c99adb22734b4")] // Star: 1304
        [TestCase(@"https://github.com/bauerca/drag-sort-listview.git",
                @"c3cfccee21676149dfdf8e803c0ec2eaebc6b841")] // Star: 1449
        [TestCase(@"https://github.com/square/otto.git",
                @"b821b22e283dabc08ae09786861c4a958000a5ae")] // Star: 1297
        [TestCase(@"https://github.com/voldemort/voldemort.git",
                @"351f4dee88829f2107afd5c283fb0768b5282165")] // Star: 1261
        [TestCase(@"https://github.com/videlalvaro/gifsockets.git",
                @"0ccb1fd01edeb835a90c0c1140ad91dbd1a354b1")] // Star: 1285
        [TestCase(@"https://github.com/androidquery/androidquery.git",
                @"45ed6c85dcf0b3b58a08810b423886fb275b33b0")] // Star: 1225
        [TestCase(@"https://github.com/johannilsson/android-actionbar.git",
                @"093a5f8039dfade914f52b55b5536b95850ddaf1")] // Star: 1242
        [TestCase(@"https://github.com/ACRA/acra.git",
                @"ee7085683018b556e73f74b059040d93794cf388")] // Star: 1196
        [TestCase(@"https://github.com/AsyncHttpClient/async-http-client.git",
                @"f96bcbbe906c1e472fbbd7cca5cfaf3778db02d6")] // Star: 1175
        [TestCase(@"https://github.com/pakerfeldt/android-viewflow.git",
                @"3da74fa32a935bcbb37e5ebeb270477cde1985d4")] // Star: 1247
        [TestCase(@"https://github.com/xamarin/XobotOS.git",
                @"f20db6295e878a2f298c5e3896528e240785805b")] // Star: 1166
        [TestCase(@"https://github.com/umano/AndroidSlidingUpPanel.git",
                @"38327d828690da0771e7b35a15a118eeecc20e26")] // Star: 1161
        [TestCase(@"https://github.com/JetBrains/intellij-community.git",
                @"e8b5589ad6a04a407d6af701dd72dc0540118688")] // Star: 1124
        [TestCase(@"https://github.com/JakeWharton/butterknife.git",
                @"3a6f2eb9713cfcea3037282e4fc4d34d50f19d6c")] // Star: 1121
        [TestCase(@"https://github.com/yinwang0/pysonar2.git",
                @"240192fb7827dedd9381dbfdd0df3062c47078d0")] // Star: 1128
        [TestCase(@"https://github.com/tinkerpop/gremlin.git",
                @"e622d5bf289ef8f74a088dc0237c69b98baf6792")] // Star: 1111
        [TestCase(@"https://github.com/wildfly/wildfly.git",
                @"23dc89381b609dcdac4d2f9da4e4d78b235c51e3")] // Star: 1102
        [TestCase(@"https://github.com/commonsguy/cw-omnibus.git",
                @"674f1edab621b409922028d0326e02e9ad81015f")] // Star: 1124
        [TestCase(@"https://github.com/twall/jna.git",
                @"323a913bf610c982f43b58883b0fc54c78a29621")] // Star: 1098
        [TestCase(@"https://github.com/JakeWharton/NineOldAndroids.git",
                @"9f20fd77e04942fd50b95aeb1c492a38e36c06dd")] // Star: 1252
        [TestCase(@"https://github.com/purplecabbage/phonegap-plugins.git",
                @"319dfb7297002040ec7ab98896e68d05c7fd8180")] // Star: 1083
        [TestCase(@"https://github.com/phonegap/phonegap-facebook-plugin.git",
                @"ccb2a6f648bb2ed44e4b7b71add4fb7b7e95eaed")] // Star: 1084
        [TestCase(@"https://github.com/Comcast/FreeFlow.git",
                @"47bfb57e8037eecae320266cb00dd23e673362e5")] // Star: 1079
        [TestCase(@"https://github.com/yusuke/twitter4j.git",
                @"747982dfdccd6d1b2ef4857720fe289455a435a1")] // Star: 1101
        [TestCase(@"https://github.com/ManuelPeinado/FadingActionBar.git",
                @"f679e313d105075cfb389695052348ee09a8e80a")] // Star: 1068
        [TestCase(@"https://github.com/bigbluebutton/bigbluebutton.git",
                @"55773f594eed3e0eff5af47ec8cbd6fcf713a56a")] // Star: 1062
        [TestCase(@"https://github.com/greenrobot/EventBus.git",
                @"0fe7ea575c508ac3b072b4a31ecea9c8680435be")] // Star: 1270
        [TestCase(@"https://github.com/processing/processing.git",
                @"9c63a2c4a227ed2329fd01006cb593ba8954962d")] // Star: 1054
        [TestCase(@"https://github.com/Athou/commafeed.git",
                @"3a8d72cab4038e975af87d8083e2b7e68f2e328c")] // Star: 1048
        [TestCase(@"https://github.com/Graylog2/graylog2-server.git",
                @"c1c5491c4a3194a19c21a7c744d5d45421ecd227")] // Star: 1041
        [TestCase(@"https://github.com/amlcurran/ShowcaseView.git",
                @"cc55def081814213c94ad80be4195b17ac4ef18c")] // Star: 1145
        [TestCase(@"https://github.com/jhy/jsoup.git",
                @"80158d6fa7445506eaaafdeadb1f4dc291ca10a5")] // Star: 1129
        [TestCase(@"https://github.com/astuetz/PagerSlidingTabStrip.git",
                @"3f4738eca833faeca563d93cd77c8df763a45fb6")] // Star: 1340
        [TestCase(@"https://github.com/mttkay/ignition.git",
                @"bbeb55cb4f080bdc31e549142ea745c65e4727c7")] // Star: 1058
        [TestCase(@"https://github.com/openaphid/android-flip.git",
                @"ab2dea1b045ffc626221c2826ce9dd00823e696d")] // Star: 1142
        [TestCase(@"https://github.com/koush/AndroidAsync.git",
                @"09c60732944a20eac52301026e9c24344ccb3062")] // Star: 993
        [TestCase(@"https://github.com/ether/pad.git",
                @"cb4977238f55f9b2518e7c43a5c769823b0afd45")] // Star: 987
        [TestCase(@"https://github.com/commonsguy/cw-advandroid.git",
                @"ab8e52a00413592b99a7bb9f93050bee760f289f")] // Star: 1028
        [TestCase(@"https://github.com/grails/grails-core.git",
                @"048025b9b98332645df30d82593d44b1f7a84bbd")] // Star: 960
        [TestCase(@"https://github.com/douglascrockford/JSON-java.git",
                @"4d86b05d3c6a72e88c476430d60676f9ae2fafab")] // Star: 1052
        [TestCase(@"https://github.com/pardom/ActiveAndroid.git",
                @"bd98740d466249fc085311b1c166570cfc08f532")] // Star: 959
        [TestCase(@"https://github.com/square/android-times-square.git",
                @"2bb367039b3cb93e6764e55835dc023df9f4fd77")] // Star: 967
        [TestCase(@"https://github.com/mongodb/mongo-java-driver.git",
                @"244b5a26bfe1b6f9e15264d690fa944e7c6e2c54")] // Star: 924
        [TestCase(@"https://github.com/kevinsawicki/http-request.git",
                @"c11e2a8b335d43adb9e273412ec7a39c7e404e72")] // Star: 939
        [TestCase(@"https://github.com/hibernate/hibernate-orm.git",
                @"9bd6917d0d92c3d350b74f23c03af5a4bb80890d")] // Star: 910
        [TestCase(@"https://github.com/BonzaiThePenguin/WikiSort.git",
                @"b83bde28fbf26198749eb0169d7f01052841b192")] // Star: 905
        [TestCase(@"https://github.com/qii/weiciyuan.git",
                @"14fdfe9f6f7f3d927a66d802b709f53ba0ff629e")] // Star: 906
        [TestCase(@"https://github.com/orientechnologies/orientdb.git",
                @"8bfc83acadc833b40ec3d485216b39b786935b4c")] // Star: 897
        [TestCase(@"https://github.com/reactor/reactor.git",
                @"83f0b805ca0a8e5fd9cd881e6370c173685ad228")] // Star: 875
        [TestCase(@"https://github.com/pcpratts/rootbeer1.git",
                @"c046801c73b9b2e48d4fe40739b0ce68c496d103")] // Star: 872
        [TestCase(@"https://github.com/mttkay/droid-fu.git",
                @"469b1bf7a844cc09866bad95fc06321291c649e8")] // Star: 882
        [TestCase(@"https://github.com/Netflix/curator.git",
                @"1e66d7ccd7ac601df3c814833f1b9e32b25331c6")] // Star: 896
        [TestCase(@"https://github.com/spring-projects/spring-mvc-showcase.git",
                @"c7b9162c061e135c081a28bf7fc209bb9a992cea")] // Star: 869
        [TestCase(@"https://github.com/greenrobot/greenDAO.git",
                @"d13a1f1d0e8d244e8033a944599adda7bb157bef")] // Star: 1039
        [TestCase(@"https://github.com/commonsguy/cw-android.git",
                @"568c11f2b9b556027dda05ad7b62c044f039b4e4")] // Star: 899
        [TestCase(@"https://github.com/yangfuhai/afinal.git",
                @"e706f0e896f8f819aa9a6a8374c7fe9f71fa4950")] // Star: 865
        [TestCase(@"https://github.com/thest1/LazyList.git",
                @"0f37d108f2067f5f44749eb0ad44e51656f96f02")] // Star: 882
        [TestCase(@"https://github.com/metamx/druid.git",
                @"db5f04c84dc7b23f87aac31397f1a6457f4903f7")] // Star: 837
        [TestCase(@"https://github.com/tjerkw/Android-SlideExpandableListView.git",
                @"a44e6f0fcfabf3a870469667b219552a5d562e87")] // Star: 901
        [TestCase(@"https://github.com/tinkerpop/blueprints.git",
                @"34b5b83fcfd92cca3a69c425c67a9a782dd18c42")] // Star: 824
        [TestCase(@"https://github.com/rzwitserloot/lombok.git",
                @"6afa3d2ec9ec18ed8ae5f6c5217b9fb1710c69c7")] // Star: 827
        [TestCase(@"https://github.com/perwendel/spark.git",
                @"f1f06769abacc6732e511774d4db2306cbe5db54")] // Star: 843
        [TestCase(@"https://github.com/robovm/robovm.git",
                @"a72f06e62dbe4afd3271fb3bfa4ca2c4d47d3329")] // Star: 832
        [TestCase(@"https://github.com/addthis/stream-lib.git",
                @"56c48e001341f874c37e0113c09554436e93ea10")] // Star: 808
        [TestCase(@"https://github.com/twitter/ambrose.git",
                @"9ff6dc68e6eb7e95645878082774f44acca5814f")] // Star: 847
        [TestCase(@"https://github.com/quartzjer/TeleHash.git",
                @"133f4212666911d066f59255e2e7fbd69bea8265")] // Star: 791
        [TestCase(@"https://github.com/todoroo/astrid.git",
                @"4fc5c7714fb1b48ae46dcacbda287bcef9c3f6bf")] // Star: 848
        [TestCase(@"https://github.com/apache/hadoop-common.git",
                @"572bd72991fe976da586db41ac4dd03466a480dd")] // Star: 795
        [TestCase(@"https://github.com/jgilfelt/android-viewbadger.git",
                @"e08c3a78cb92c0c8587790b15e73434f972912cf")] // Star: 900
        [TestCase(@"https://github.com/jgilfelt/android-mapviewballoons.git",
                @"a47528473b562170fbed33b7cf01da2353300acd")] // Star: 806
        [TestCase(@"https://github.com/http-kit/http-kit.git",
                @"7184fa8cf2526a24446e7e6602bc16d9d1c0948a")] // Star: 804
        [TestCase(@"https://github.com/cucumber/cucumber-jvm.git",
                @"08e6b87a0a21010bf35d643157b7032a40832efd")] // Star: 784
        [TestCase(@"https://github.com/alibaba/druid.git",
                @"4bebaa9d86038ec563febd2f50e7b232544a3ab7")] // Star: 798
        [TestCase(@"https://github.com/BoltsFramework/Bolts-Android.git",
                @"b046dfdbe9b36989ab7bf4492dc403a20118c590")] // Star: 781
        [TestCase(@"https://github.com/Netflix/ice.git",
                @"f5cd61177fca0ea0d45eecacc7c3209e8b1bbc57")] // Star: 790
        [TestCase(@"https://github.com/cloudera/flume.git",
                @"1d7535638556998e895d55599a2f4a024390edd1")] // Star: 774
        [TestCase(@"https://github.com/jankotek/MapDB.git",
                @"c890d8b4edc5fb9d064bb04aa132aea8608f87dd")] // Star: 763
        [TestCase(@"https://github.com/linkedin/indextank-engine.git",
                @"f2354fe9db43786126e304d12aae4322ae7b98b1")] // Star: 770
        [TestCase(@"https://github.com/tjake/Solandra.git",
                @"64e1d192604144c06962e284523cce3c4df51c4e")] // Star: 768
        [TestCase(@"https://github.com/amplab/tachyon.git",
                @"6ce29b2da55130e7cb32a32f029fef43cdc35ef5")] // Star: 756
        [TestCase(@"https://github.com/novoda/android.git",
                @"3052e6d253bd6a29c3e9b043ba87021242857ba5")] // Star: 875
        [TestCase(@"https://github.com/facebook/hadoop-20.git",
                @"9f1ea1b28047a4b16f4962c7561613f139dd3e86")] // Star: 752
        [TestCase(@"https://github.com/ginatrapani/todo.txt-android.git",
                @"ce117c601510cb7343f4633e3033ec0cbfe35ff7")] // Star: 761
        [TestCase(@"https://github.com/OpenTSDB/opentsdb.git",
                @"a2bd5737d9d11a8fd3fa6e9c36a31dd8cb5c4af4")] // Star: 733
        [TestCase(@"https://github.com/peter-lawrey/Java-Chronicle.git",
                @"6716f0cff0750d125a07eb769bba0698a617b7fb")] // Star: 756
        [TestCase(@"https://github.com/rstudio/rstudio.git",
                @"cb0b00ee99905c6e2cf1e88b4bee316214d54769")] // Star: 722
        [TestCase(@"https://github.com/kevinweil/elephant-bird.git",
                @"ccddfc68e634fea2d05a1804057a1c4826817471")] // Star: 723
        [TestCase(@"https://github.com/neo4j/neo4j.git",
                @"521ec09bd83bdee1ef39af4dc162fe0c88fedf4b")] // Star: 719
        [TestCase(@"https://github.com/hazelcast/hazelcast.git",
                @"67389104cdb892d040bc15e7df39ab4bd5df3895")] // Star: 718
        [TestCase(@"https://github.com/typesafehub/config.git",
                @"36c1392028c82db2c146ade29a2f6940bc6f5407")] // Star: 736
        [TestCase(@"https://github.com/JodaOrg/joda-time.git",
                @"fcf264d737af5a37d45c6c5c9802487ce53c8de8")] // Star: 722
        [TestCase(@"https://github.com/leachim6/hello-world.git",
                @"02e3bb8c5b356739644d24c60adbe6dda020b6fc")] // Star: 734
        [TestCase(@"https://github.com/alibaba/fastjson.git",
                @"5e3ede7923bd4b7930b8f785b900e80753b97c01")] // Star: 763
        [TestCase(@"https://github.com/MovingBlocks/Terasology.git",
                @"387497a2ea91b25339b3cbe8b18338edd7d3d1f5")] // Star: 701
        [TestCase(@"https://github.com/0xdata/h2o.git",
                @"c5e4bfd7e1b1ecc59b5d9c40eb0f56bfabf646be")] // Star: 694
        [TestCase(@"https://github.com/apache/lucene-solr.git",
                @"9e87821edeb3e24ca8dedaecf856f6510d61d0d3")] // Star: 692
        [TestCase(@"https://github.com/nathanmarz/storm-starter.git",
                @"917a4c5c171009af3b130d09339355f6310a2042")] // Star: 695
        [TestCase(@"https://github.com/derekbrameyer/android-betterpickers.git",
                @"0a72367b478970b1731822e78790a158a4f7ebb4")] // Star: 740
        [TestCase(@"https://github.com/mongodb/mongo-hadoop.git",
                @"29788439cbc8cc9a45910ceba316a70049a8b4e8")] // Star: 689
        [TestCase(@"https://github.com/JakeWharton/u2020.git",
                @"543eaea54f04fd4397aa74f4578670e279cc857a")] // Star: 680
        [TestCase(@"https://github.com/castorflex/SmoothProgressBar.git",
                @"9198cb9201268cec63e69d87cdbfb879a962f827")] // Star: 708
        [TestCase(@"https://github.com/JakeWharton/hugo.git",
                @"de887a549a14fba7e3735ce4c202e15502c78a43")] // Star: 702
        [TestCase(@"https://github.com/apache/mahout.git",
                @"add3038b35029cf886ac907822016c91ec4b4278")] // Star: 668
        [TestCase(@"https://github.com/novoda/ImageLoader.git",
                @"a82512b76c43e271a15717e0697055cd9e3d9031")] // Star: 678
        [TestCase(@"https://github.com/JakeWharton/scalpel.git",
                @"97299acd1cc7b4138af714f1ed0bce47e9ce516d")] // Star: 684
        [TestCase(@"https://github.com/RobotiumTech/robotium.git",
                @"ee7d989c95f2cf380935f7a117d7f9345820cbf7")] // Star: 664
        [TestCase(@"https://github.com/maurycyw/StaggeredGridView.git",
                @"06dbc841a6330143f114eba82566d25b5a808c61")] // Star: 758
        [TestCase(@"https://github.com/ansjsun/ansj_seg.git",
                @"ab56d87c9799e543e4141840809b52aa27932d87")] // Star: 671
        [TestCase(@"https://github.com/hector-client/hector.git",
                @"0c760d9347ebf9bdaeec5fe195f175f674590909")] // Star: 655
        [TestCase(@"https://github.com/mortardata/mortar-recsys.git",
                @"617fbf66a8e8fb7738354c224760dc2419ed0c13")] // Star: 654
        [TestCase(@"https://github.com/eishay/jvm-serializers.git",
                @"3ec217ec19aff74654b40a47c010d57a44996efb")] // Star: 653
        [TestCase(@"https://github.com/koush/UrlImageViewHelper.git",
                @"a9897afbf0277727810158c9739c3ddd9cf15899")] // Star: 690
        [TestCase(@"https://github.com/jberkel/sms-backup-plus.git",
                @"3565f645126d3f9e8c0371ec57c8aac4bbf5cde1")] // Star: 647
        [TestCase(@"https://github.com/BuildCraft/BuildCraft.git",
                @"080b4ba74990c6488f7c645cc64d3985f47e42fd")] // Star: 643
        [TestCase(@"https://github.com/jayway/maven-android-plugin.git",
                @"2ce1428c8e83365c5ac096b7855e71bd8a035013")] // Star: 645
        [TestCase(@"https://github.com/TooTallNate/Java-WebSocket.git",
                @"7c3b223536dc8bd4e8794ac265ad06679583e30f")] // Star: 754
        [TestCase(@"https://github.com/facebook/buck.git",
                @"def0eb1077d6c2a9f129b200e8356acaec9a17ed")] // Star: 631
        [TestCase(@"https://github.com/square/spoon.git",
                @"975dacb45607ed45492fa3dd9e697f0a5263e71a")] // Star: 630
        [TestCase(@"https://github.com/brianfrankcooper/YCSB.git",
                @"4791826f0b90c472dd04cc5eb6ed73c4d5906330")] // Star: 632
        [TestCase(@"https://github.com/aws/aws-sdk-java.git",
                @"f04beb908018dcb0ca58ac6e00f2bd66953efe45")] // Star: 628
        [TestCase(@"https://github.com/cloudera/oryx.git",
                @"8986b58e49b55d7c57f72f232596689a16a013a9")] // Star: 617
        [TestCase(@"https://github.com/gephi/gephi.git",
                @"5777cab4a8f649ef85f4c571f37b0df43e4db46f")] // Star: 620
        [TestCase(@"https://github.com/MinecraftForge/MinecraftForge.git",
                @"2cef9c5cb29fdaa1d118591604ff7c5f2e956c09")] // Star: 619
        [TestCase(@"https://github.com/sk89q/worldedit.git",
                @"33d4285f1a7af21b42585fccca5a93036c953262")] // Star: 613
        [TestCase(@"https://github.com/harism/android_page_curl.git",
                @"7a2c8f152bb4f1b0de3b1aa72b3cb79e1fe8e3bd")] // Star: 664
        [TestCase(@"https://github.com/geometer/FBReaderJ.git",
                @"ec96ce8dd837f495fbeafef8592001e06b601bb0")] // Star: 611
        [TestCase(@"https://github.com/commonsguy/cwac-endless.git",
                @"7a6fe3c123fc85e08c36b6db6a88740385625340")] // Star: 658
        [TestCase(@"https://github.com/apache/hbase.git",
                @"f0a4811e4bef6e66ced0b24bfdace39d99251142")] // Star: 608
        [TestCase(@"https://github.com/jfeinstein10/JazzyViewPager.git",
                @"05fab564593adffec28c76857520ab35f908dea0")] // Star: 719
        [TestCase(@"https://github.com/liferay/liferay-portal.git",
                @"917c5277997b15fd9fb2abd9694809e535132855")] // Star: 597
        [TestCase(@"https://github.com/JetBrains/kotlin.git",
                @"d28ca5bdfae653d91de63a8cd1ddfc1bea7545bd")] // Star: 594
        [TestCase(@"https://github.com/spring-projects/spring-boot.git",
                @"620d8eb87e63ab23bf667c2b1c6518d9fd2ab187")] // Star: 613
        [TestCase(@"https://github.com/sirthias/parboiled.git",
                @"036214177d6ae3126b8bee179164e202c8bc9a9d")] // Star: 605
        [TestCase(@"https://github.com/chewiebug/GCViewer.git",
                @"26a080b1555d3d14bef91afa5090c75ae6a6b657")] // Star: 597
        [TestCase(@"https://github.com/Trinea/android-common.git",
                @"3e8308815b0d2d592276f44fdd3c6b9a02e04587")] // Star: 598
        [TestCase(@"https://github.com/goldmansachs/gs-collections.git",
                @"4e597130fbe4e6f9d745a8d5348c77c45e9341d8")] // Star: 619
        [TestCase(@"https://github.com/afollestad/Cards-UI.git",
                @"cd59ad57efd28c35b59d4abd461d669f1df9dda5")] // Star: 595
        [TestCase(@"https://github.com/tomwhite/hadoop-book.git",
                @"0087add3342b36503bb60c972a0d441f91e37ef1")] // Star: 589
        [TestCase(@"https://github.com/notnoop/java-apns.git",
                @"20c10ebd22e15a55c0c1c12695c535d37435dcfd")] // Star: 652
        [TestCase(@"https://github.com/siyamed/android-satellite-menu.git",
                @"ff0964c849095eb17c5fe9f84f158e39d5a5ef03")] // Star: 652
        [TestCase(@"https://github.com/zeromq/jeromq.git",
                @"97332bcbeb6cb5f28b8e950c3440d53ea28e6588")] // Star: 589
        [TestCase(@"https://github.com/pahimar/Equivalent-Exchange-3.git",
                @"664387f0637838e6e982471634b0b34b64705471")] // Star: 579
        [TestCase(@"https://github.com/rnewson/couchdb-lucene.git",
                @"aa7d0fc8203d8a566862021101ab05ebc25f41ad")] // Star: 578
        [TestCase(@"https://github.com/fastestforward/gauges-android.git",
                @"372528e3a689fa38f582330e69f7a31c62b2aa9c")] // Star: 621
        [TestCase(@"https://github.com/inmite/android-styled-dialogs.git",
                @"38975c5220aeab1d79ee3db2a8c4d269c0600c38")] // Star: 723
        [TestCase(@"https://github.com/Graylog2/graylog2-web-interface.git",
                @"26cdb17791df1a169265da883e3c3127b505f8ac")] // Star: 566
        [TestCase(@"https://github.com/square/tape.git",
                @"36cc75ee4e7c2352d75f26678c7a833fe46fb3b8")] // Star: 596
        [TestCase(@"https://github.com/jackpal/Android-Terminal-Emulator.git",
                @"60f5dd963464aa733c14d844c9b2f0414888cc79")] // Star: 566
        [TestCase(@"https://github.com/dim-s/jphp.git",
                @"2d2353448d2df7f375512eff4c42242e5d57057b")] // Star: 564
        [TestCase(@"https://github.com/calabash/calabash-android.git",
                @"14724f6ab39886516088c8a1e982febc2f36ed1b")] // Star: 565
        [TestCase(@"https://github.com/Netflix/astyanax.git",
                @"b9ab12712607734f8ff0d4ac692c04da01c571c7")] // Star: 581
        [TestCase(@"https://github.com/romannurik/muzei.git",
                @"a9d2ccfaeccabad26f9c6eba26355882654cc4c1")] // Star: 774
        [TestCase(@"https://github.com/jjoe64/GraphView.git",
                @"638ab6ac76890e06e6180ccde7540e0ea467196f")] // Star: 547
        [TestCase(@"https://github.com/loopj/android-smart-image-view.git",
                @"49a7facbb30455b2d3760419028a9a7ff0b1aa89")] // Star: 606
        [TestCase(@"https://github.com/matburt/mobileorg-android.git",
                @"a9297345109ff97a9150ee04990a96dce2a8da0e")] // Star: 545
        [TestCase(@"https://github.com/facebook/rebound.git",
                @"a0fe027ca170d1f50b64ac34276a35bb11e79896")] // Star: 575
        [TestCase(@"https://github.com/mozilla/rhino.git",
                @"5f1ad11dfbf23b3afcc8caa6c230fa3533b5ffd6")] // Star: 581
        [TestCase(@"https://github.com/JohnPersano/SuperToasts.git",
                @"eb739b3b00cdacee5ad599d9543cecb47a81976f")] // Star: 555
        [TestCase(@"https://github.com/spring-projects/spring-security-oauth.git",
                @"75f0d1c09765522b10e115ed833deccc18ac8cad")] // Star: 540
        [TestCase(@"https://github.com/JetBrains/ideavim.git",
                @"ee1a6bbbd95ca72a64b281282e9c6fa549638e84")] // Star: 542
        [TestCase(@"https://github.com/yixia/VitamioBundle.git",
                @"1b0eacce724153f4305ecfb32190ad76172e14f8")] // Star: 539
        [TestCase(@"https://github.com/gitblit/gitblit.git",
                @"a57d0c36910a96391b79511224eeb2989f52f6e3")] // Star: 523
        [TestCase(@"https://github.com/redsolution/xabber-android.git",
                @"2b8e6b216fa2a928b2f62b7cd62b2c079d706d38")] // Star: 612
        [TestCase(@"https://github.com/mariotaku/twidere.git",
                @"1f3f6a036e5d511185fc4c0dd6aabb944843b821")] // Star: 520
        [TestCase(@"https://github.com/jclouds/legacy-jclouds.git",
                @"1665a70471609aed0314dc60e27a80c7ffa65d45")] // Star: 522
        [TestCase(@"https://github.com/webbit/webbit.git",
                @"0154b235a8dd2b3ab966f299506375f6c6538cbb")] // Star: 549
        [TestCase(@"https://github.com/lucasr/smoothie.git",
                @"8532d5355649dae87243a1e4b71710314eb97652")] // Star: 595
        [TestCase(@"https://github.com/sikuli/sikuli.git",
                @"141897fd93a1141d7214c4c07b6f6688b45e38a1")] // Star: 523
        [TestCase(@"https://github.com/UweTrottmann/SeriesGuide.git",
                @"0dd18b8dc5a36c3f1ba111f2fdca114ebaabbbd2")] // Star: 508
        [TestCase(@"https://github.com/romainguy/ViewServer.git",
                @"f7bfe2752eb47a277436480b910b0184f55f81fc")] // Star: 591
        [TestCase(@"https://github.com/apache/cordova-android.git",
                @"b872df0f314194ad50cbaa098ebbf717e53bb354")] // Star: 519
        [TestCase(@"https://github.com/linkedin/datafu.git",
                @"e98e7b4284712e6ebc06138aff9355420b08f42a")] // Star: 528
        [TestCase(@"https://github.com/spullara/mustache.java.git",
                @"c9e64e12d0193ffa5fc2b7fa2c7c0ea05067281d")] // Star: 504
        [TestCase(@"https://github.com/MikeOrtiz/TouchImageView.git",
                @"7594f9836a985fdec4c1ce051fe4ed869cbf84a8")] // Star: 503
        [TestCase(@"https://github.com/foxykeep/DataDroid.git",
                @"0553cada0d6c508eca3a9295fa7729deba8a75e4")] // Star: 509
        [TestCase(@"https://github.com/linkedin/rest.li.git",
                @"f0f868024d9eca663d39fb7d05a49dc7985e9bf6")] // Star: 503
        [TestCase(@"https://github.com/liquibase/liquibase.git",
                @"dee23ae4fd2f8c4eae4d1353d0a0f8aab76d9953")] // Star: 508
        [TestCase(@"https://github.com/go-lang-plugin-org/go-lang-idea-plugin.git",
                @"d7138f7ff36e90b0fe57bf62cfc9dcf508e81659")] // Star: 510
        [TestCase(@"https://github.com/chrisbanes/Android-BitmapCache.git",
                @"147e5c078324c8f61765750da756c4a7d1f2aae3")] // Star: 532
        [TestCase(@"https://github.com/apache/zookeeper.git",
                @"644542390d75af0b752ab34fde0ccbf995bb05cf")] // Star: 501
        [TestCase(@"https://github.com/opentripplanner/OpenTripPlanner.git",
                @"d47db7893b4899cada1bf074e4399fdeb175fd47")] // Star: 493
        [TestCase(@"https://github.com/jgilfelt/android-sqlite-asset-helper.git",
                @"9e6a939ad6baf9946b8073a03c5d279a2eede290")] // Star: 602
        [TestCase(@"https://github.com/kikoso/android-stackblur.git",
                @"668da822f334ea5a4750ab45430d349de2a57c3d")] // Star: 574
        [TestCase(@"https://github.com/vinc3m1/RoundedImageView.git",
                @"2f6414bd3e2606395d9fe9de7373ef86be70f4cf")] // Star: 493
        [TestCase(@"https://github.com/nutzam/nutz.git",
                @"8b1c4ac2588896ad2b6f5e34821e02d82c342805")] // Star: 489
        [TestCase(@"https://github.com/ManuelPeinado/GlassActionBar.git",
                @"ca6b9416e547483c7fd004f2957209ee89bde65e")] // Star: 588
        [TestCase(@"https://github.com/oschina/android-app.git",
                @"6a5bf77e7450151a3765fc7569c16d3d835df0f8")] // Star: 498
        [TestCase(@"https://github.com/Todd-Davies/ProgressWheel.git",
                @"b07bb7dd995aaf0d4ac921991bb37d9da36d72f2")] // Star: 536
        [TestCase(@"https://github.com/robotmedia/AndroidBillingLibrary.git",
                @"4bbe429d7811d531ca6d478745b4eeebb17f1783")] // Star: 504
        [TestCase(@"https://github.com/fearofcode/bateman.git",
                @"0c3a8287133e2195c63a52f665f912cca6fc5b65")] // Star: 494
        [TestCase(@"https://github.com/vrapper/vrapper.git",
                @"250ff536fcaa5dc77eb657d23695098096f44843")] // Star: 480
        [TestCase(@"https://github.com/mitallast/diablo-js.git",
                @"bdd6b737b8071fcff218be389cd406301dad88a3")] // Star: 477
        [TestCase(@"https://github.com/mixi-inc/AndroidTraining.git",
                @"83d2527dab5586dfe3ecab8af5e599441920d35d")] // Star: 506
        [TestCase(@"https://github.com/path/android-priority-jobqueue.git",
                @"89d76ea193cfded0d9401f534fedbfe14c981c04")] // Star: 552
        [TestCase(@"https://github.com/eoecn/android-app.git",
                @"38f08642e11c97ec00178c529e34bae0c1ddee88")] // Star: 547
        [TestCase(@"https://github.com/jOOQ/jOOQ.git",
                @"5014e5d5c42c9744eb9129183996451f261fb46d")] // Star: 472
        [TestCase(@"https://github.com/NanoHttpd/nanohttpd.git",
                @"852318439539b54ee6b4ce048df63b6c12cf0417")] // Star: 488
        [TestCase(@"https://github.com/richardwilly98/elasticsearch-river-mongodb.git",
                @"c2e4240fc8481b10fb0b94b2eb5d9c131ef22354")] // Star: 465
        [TestCase(@"https://github.com/owncloud/android.git",
                @"70677a46fdb3fbf11dc9885b77e7dfe29646821f")] // Star: 463
        [TestCase(@"https://github.com/wyouflf/xUtils.git",
                @"9cdd5bd42035b6f4c6318119cc348797327cd95d")] // Star: 463
        [TestCase(@"https://github.com/etsy/oculus.git",
                @"3cb3626faee58d8387a9807b4a7c6efc840151ea")] // Star: 467
        [TestCase(@"https://github.com/lorensiuswlt/NewQuickAction.git",
                @"9773852b297114d9826e580f9d3845e522e766a7")] // Star: 481
        [TestCase(@"https://github.com/unclebob/fitnesse.git",
                @"6252a712699b0bf674eaa07d3018db3854a0adbf")] // Star: 461
        [TestCase(@"https://github.com/romannurik/Android-MonthCalendarWidget.git",
                @"f198096a4c2f9db2b98fc41f6fb57087558c21c6")] // Star: 519
        [TestCase(@"https://github.com/javaee-samples/javaee7-samples.git",
                @"a23fc9126b0cee80e26166073493154cf822463f")] // Star: 470
        [TestCase(@"https://github.com/6wunderkinder/android-sliding-layer-lib.git",
                @"3f7d6ba4ac779225268702a8364f5997361e7e17")] // Star: 535
        [TestCase(@"https://github.com/puniverse/quasar.git",
                @"0561de92c77b0c94c3b66e57344d0e97c6f72434")] // Star: 455
        [TestCase(@"https://github.com/darvds/RibbonMenu.git",
                @"0d051fe76fa61d392b29ac8e1f7bd4ceeb5e0449")] // Star: 471
        [TestCase(@"https://github.com/rundeck/rundeck.git",
                @"6b832473d4fecad533f96d6908b1bffab97c97d3")] // Star: 453
        [TestCase(@"https://github.com/dinocore1/DevsmartLib-Android.git",
                @"5572ff39b8d5627c9b31db97e7290ca986448404")] // Star: 505
        [TestCase(@"https://github.com/saik0/UnifiedPreference.git",
                @"dcfdb0c590ba0c27230bdee2808cc839d42debfe")] // Star: 475
        [TestCase(@"https://github.com/jmxtrans/jmxtrans.git",
                @"d67aa723ee8bb7cd6adc520925c453e7710097de")] // Star: 452
        [TestCase(@"https://github.com/eclipse-color-theme/eclipse-color-theme.git",
                @"697d04d24e86a1308562c15198aafe0a0e419df2")] // Star: 447
        [TestCase(@"https://github.com/alibaba/dubbo.git",
                @"17becc2d6676be84b01c0d15a81c5f33f85d21d6")] // Star: 449
        [TestCase(@"https://github.com/emilsjolander/sprinkles.git",
                @"64579073bac01066423b9f69b13f67a3994bb798")] // Star: 446
        [TestCase(@"https://github.com/ManuelPeinado/RefreshActionItem.git",
                @"b592791550ec45c5f8cf5a320c42d26c26639d8f")] // Star: 489
        [TestCase(@"https://github.com/johnkil/Android-AppMsg.git",
                @"a701a05ba1c1e16a26cb356b9282ffc32d688994")] // Star: 513
        [TestCase(@"https://github.com/forcedotcom/phoenix.git",
                @"5e49d5f940f9dbd2538fb890f0cc6697068c74ac")] // Star: 458
        [TestCase(@"https://github.com/apache/incubator-storm.git",
                @"1a0b46e95ab4ac467525314a75819a75dec92c40")] // Star: 449
        [TestCase(@"https://github.com/RadiusNetworks/android-ibeacon-service.git",
                @"e916f1d0d6e98c05e9aea3365b1cd91aec117da5")] // Star: 470
        [TestCase(@"https://github.com/trifork/erjang.git",
                @"6e8527bfa12448303c2eb48640acdeec5dadd774")] // Star: 439
        [TestCase(@"https://github.com/FasterXML/jackson-core.git",
                @"b0a2e19b1db9a26a43dc5cd3d3e7ab3fef5751b8")] // Star: 438
        [TestCase(@"https://github.com/cgeo/cgeo.git",
                @"62f3d4b7c15358f80ff42e8d5816d73d7de4de7e")] // Star: 438
        [TestCase(@"https://github.com/chrisjenx/Calligraphy.git",
                @"6590aa7e2f1255d343b1c1e70358584cfe5146d3")] // Star: 449
        [TestCase(@"https://github.com/jeeeyul/eclipse-themes.git",
                @"13f5ae7ae9c74354b7ec271d5d3ff05189ad1bc5")] // Star: 437
        [TestCase(@"https://github.com/joscha/play-authenticate.git",
                @"32bdc032a8321e665f91ebcfe8df40ae53d31084")] // Star: 451
        [TestCase(@"https://github.com/danieloeh/AntennaPod.git",
                @"ae849077c78770f096f40e9360250b9e32d14f40")] // Star: 434
        [TestCase(@"https://github.com/chrislacy/TweetLanes.git",
                @"c0f13c9e5085c8a8a3290d20d419f43e9257eba8")] // Star: 454
        [TestCase(@"https://github.com/apigee/usergrid-stack.git",
                @"06a6ff5131327b3f39bcae1665204a4e9d78aa2d")] // Star: 451
        [TestCase(@"https://github.com/ervandew/eclim.git",
                @"67a4bb3dd5edf3ea787e068d029fbd89a599d7ac")] // Star: 436
        [TestCase(@"https://github.com/MichaelEvans/ColorArt.git",
                @"c819bbe562caa373d8ceab068af781b3c8ed202e")] // Star: 435
        [TestCase(@"https://github.com/jersey/jersey.git",
                @"9e6176cb40c8ac1f41d67dad0a89e7f17c47244c")] // Star: 427
        [TestCase(@"https://github.com/yanchenko/droidparts.git",
                @"40bee3cc1a35e80eb9e252df06bd168529e61da7")] // Star: 425
        [TestCase(@"https://github.com/guardianproject/ChatSecureAndroid.git",
                @"acff537de56c5957c74c5670c39938f76c564ac7")] // Star: 456
        [TestCase(@"https://github.com/groovy/groovy-core.git",
                @"e1d4d933c208d53fb1ff95d8a57774040f0a2a0a")] // Star: 423
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