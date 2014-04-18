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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Objects.Tests.Learning.Experiments {
	[TestFixture]
	public class JavaExperiment {
		private readonly StreamWriter _writer = File.CreateText(
				@"C:\Users\exKAZUu\Desktop\java.csv");

		public static CstGenerator Generator = CstGenerators.JavaUsingAntlr3;
		private const string LangName = "Java";

		private static IEnumerable<TestCaseData> TestCases {
			get {
				var exps = new LearningExperiment[] {
					new JavaComplexStatementExperiment(),
					new JavaSuperComplexBranchExperiment(),
					new JavaExpressionStatementExperiment(),
					new JavaArithmeticOperatorExperiment(),
					new JavaSwitchCaseExperiment(), 
					//new JavaComplexBranchExperiment(),
					//new JavaIfExperiment(),
					//new JavaWhileExperiment(),
					//new JavaDoWhileExperiment(),
					//new JavaForExperiment(),
					//new JavaPreconditionsExperiment(),
					//new JavaStatementExperiment(),
					//new JavaBlockExperiment(),
					//new JavaLabeledStatementExperiment(),
					//new JavaEmptyStatementExperiment(),
				};
				var learningSets = new[] {
					Tuple.Create(
							@"https://github.com/facebook/facebook-android-sdk.git",
							@"118e756568f7e9a8045e87575c190a2c304071a6", 2818),
					Tuple.Create(
							@"https://github.com/netty/netty.git",
							@"8615f7a69ecbbabd6d8f7ba8cae90ba63d702fec", 2805),
					Tuple.Create(
							@"https://github.com/excilys/androidannotations.git",
							@"5e769c2d90c76ebfe685f6423435b3fda5fa4bc6", 2725),
					Tuple.Create(
							@"https://github.com/sparklemotion/nokogiri.git",
							@"163103b0eaf904575e62909eddc00dcc9e425a2a", 2604),
					Tuple.Create(
							@"https://github.com/junit-team/junit.git",
							@"e65558c174a8f5c4c7758f0d9dd1ffe027b023d8", 2461),
					Tuple.Create(
							@"https://github.com/AndroidBootstrap/android-bootstrap.git",
							@"e43e3ac4a5984edf9a6ccc87bac04be177a3615a", 2446),
					Tuple.Create(
							@"https://github.com/square/picasso.git",
							@"e0c3d44f53919742a0a608277be26b47742bb2a2", 2312),
					Tuple.Create(
							@"https://github.com/facebook/presto.git",
							@"b4b5d67e09576ec38be1564123e5a0e2d4bc1996", 2281),
					Tuple.Create(
							@"https://github.com/chrisbanes/ActionBar-PullToRefresh.git",
							@"65d4183994eaf8c450e81afadb389fca61499063", 2272),
					Tuple.Create(
							@"https://github.com/WhisperSystems/TextSecure.git",
							@"4d52d2ee364c2edad50420a9afa500dde66a48d9", 2261),
					Tuple.Create(
							@"https://github.com/cyrilmottier/GreenDroid.git",
							@"abd9769f677bb4a753f0bf1119f961187bdf7020", 2123),
					Tuple.Create(
							@"https://github.com/dropwizard/metrics.git",
							@"e61395657d9f471a88dc0d9f3c7f78f0e773fe28", 2090),
					Tuple.Create(
							@"https://github.com/nicolasgramlich/AndEngine.git",
							@"720897f99d2c56ba357e8fe361454bd8d88c37ed", 2068),
					Tuple.Create(
							@"https://github.com/Prototik/HoloEverywhere.git",
							@"3b6021aa4af717cd31b1b6c877f6c30b674af6d9", 2065),
					Tuple.Create(
							@"https://github.com/Bukkit/CraftBukkit.git",
							@"1ab090e71ea261fe38cef980bc2ebe696a494ea3", 2032),
					Tuple.Create(
							@"https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition.git",
							@"5f399a52c8bf5626b098629906f82be1763089f4", 2005),
					Tuple.Create(
							@"https://github.com/fernandezpablo85/scribe-java.git",
							@"135ad50a4e4e27e97f09e42ae50d6011c7af7a4b", 1997),
					Tuple.Create(
							@"https://github.com/LMAX-Exchange/disruptor.git",
							@"1072645ad75f8b07b9145197fd4137fcfa79011a", 1836),
					Tuple.Create(
							@"https://github.com/OpenRefine/OpenRefine.git",
							@"c2cadab47593d5d3f49e45b5fe434e117e67f8dd", 1827),
					Tuple.Create(
							@"https://github.com/dropwizard/dropwizard.git",
							@"4758ac698ff9993879798db338b3314c6a1c6a27", 1776),
					Tuple.Create(
							@"https://github.com/square/retrofit.git",
							@"1f7cc4942f71d6c6cf4770fcd93670bc93a8c710", 1776),
					Tuple.Create(
							@"https://github.com/Netflix/SimianArmy.git",
							@"6a8b799af24cd638cd7110965ca8504e18cd6b24", 1743),
					Tuple.Create(
							@"https://github.com/johannilsson/android-pulltorefresh.git",
							@"4277c1ecf6256518248a1143b3ee882c703b33d6", 1739),
					Tuple.Create(
							@"https://github.com/SimonVT/android-menudrawer.git",
							@"1260f2f6d50d3b572ebfa98e93a0b4f8258371de", 1727),
					Tuple.Create(
							@"https://github.com/square/dagger.git",
							@"21a9e0d875da31306b0f41273348f4f75741fef7", 1706),
					Tuple.Create(
							@"https://github.com/Atmosphere/atmosphere.git",
							@"dd2397e03088f2bced1f8e47f8f81e935664a923", 1671),
					Tuple.Create(
							@"https://github.com/roboguice/roboguice.git",
							@"c0c61a89ad8ce844858373748f09222de187d61e", 1644),
					Tuple.Create(
							@"https://github.com/thinkaurelius/titan.git",
							@"c26cd982b1dc5ba792ee7a63af59887bd8b08223", 1625),
					Tuple.Create(
							@"https://github.com/Netflix/Hystrix.git",
							@"04949497901e6fcd71f68d804e5b89f9e368271d", 1624),
					Tuple.Create(
							@"https://github.com/etsy/AndroidStaggeredGrid.git",
							@"84a06f8da0ba70de32e7373c57f6e38b9d9b6780", 1612),
					Tuple.Create(
							@"https://github.com/chrisbanes/PhotoView.git",
							@"99fc9956a2de2279e45af9e95286efec79c0d739", 1609),
					Tuple.Create(
							@"https://github.com/jeresig/processing-js.git",
							@"02363398a823eae731cafa180a5581fe353397bf", 1553),
					Tuple.Create(
							@"https://github.com/apache/cassandra.git",
							@"6e97178a50d1cc9a6817653e463ef5f0cf132873", 1540),
					Tuple.Create(
							@"https://github.com/zxing/zxing.git",
							@"41caac38e8414be512fee712dae98966b7f4f05e", 1494),
					Tuple.Create(
							@"https://github.com/47deg/android-swipelistview.git",
							@"f0d4859100d7cb80e3e7ca4551daa69d5c61fd25", 1486),
					Tuple.Create(
							@"https://github.com/Bukkit/Bukkit.git",
							@"ec19988db3ba9415f9453c68b4861ffbe90e4153", 1477),
					Tuple.Create(
							@"https://github.com/bauerca/drag-sort-listview.git",
							@"c3cfccee21676149dfdf8e803c0ec2eaebc6b841", 1449),
					Tuple.Create(
							@"https://github.com/keyboardsurfer/Crouton.git",
							@"0957a7ea09e40d521defa28c6d1ffa1127f7e7da", 1441),
					Tuple.Create(
							@"https://github.com/gabrielemariotti/cardslib.git",
							@"3a1998cbf4d1ab24a5dcf22441fadafab3da655f", 1436),
					Tuple.Create(
							@"https://github.com/yui/yuicompressor.git",
							@"e814062c2f1f8c75decde08e884d84387938faba", 1430),
					Tuple.Create(
							@"https://github.com/aporter/coursera-android.git",
							@"a4c1fceac0d2c0a86f74ebad8ccc7539330e8290", 1405),
					Tuple.Create(
							@"https://github.com/emilsjolander/StickyListHeaders.git",
							@"60eecee1b8a53a0c6de9a5d6ddb3cefbfef6d90a", 1379),
					Tuple.Create(
							@"https://github.com/xetorthio/jedis.git",
							@"ac53759f9706b52184963e98af11d2e44bfb1297", 1373),
					Tuple.Create(
							@"https://github.com/square/okhttp.git",
							@"c51e223ff96da5f6581515d7080a080808c35384", 1353),
					Tuple.Create(
							@"https://github.com/nhaarman/ListViewAnimations.git",
							@"98a4793f62bbb4c9c9aaec199ccdeb3b4403a162", 1352),
					Tuple.Create(
							@"https://github.com/astuetz/PagerSlidingTabStrip.git",
							@"3f4738eca833faeca563d93cd77c8df763a45fb6", 1340),
					Tuple.Create(
							@"https://github.com/koush/ion.git",
							@"d14f69b87387bb57a213c871ff57dd42c3481e5b", 1324),
					Tuple.Create(
							@"https://github.com/k9mail/k-9.git",
							@"8e078bc0146cf0ab02a54c1d852842f6ee734f23", 1323),
					Tuple.Create(
							@"https://github.com/square/otto.git",
							@"b821b22e283dabc08ae09786861c4a958000a5ae", 1297),
					Tuple.Create(
							@"https://github.com/videlalvaro/gifsockets.git",
							@"0ccb1fd01edeb835a90c0c1140ad91dbd1a354b1", 1285),
					Tuple.Create(
							@"https://github.com/greenrobot/EventBus.git",
							@"0fe7ea575c508ac3b072b4a31ecea9c8680435be", 1270),
					Tuple.Create(
							@"https://github.com/JakeWharton/NineOldAndroids.git",
							@"9f20fd77e04942fd50b95aeb1c492a38e36c06dd", 1252),
					Tuple.Create(
							@"https://github.com/pakerfeldt/android-viewflow.git",
							@"3da74fa32a935bcbb37e5ebeb270477cde1985d4", 1247),
					Tuple.Create(
							@"https://github.com/johannilsson/android-actionbar.git",
							@"093a5f8039dfade914f52b55b5536b95850ddaf1", 1242),
					Tuple.Create(
							@"https://github.com/androidquery/androidquery.git",
							@"45ed6c85dcf0b3b58a08810b423886fb275b33b0", 1225),
					Tuple.Create(
							@"https://github.com/ACRA/acra.git",
							@"ee7085683018b556e73f74b059040d93794cf388", 1196),
					Tuple.Create(
							@"https://github.com/AsyncHttpClient/async-http-client.git",
							@"f96bcbbe906c1e472fbbd7cca5cfaf3778db02d6", 1175),
					Tuple.Create(
							@"https://github.com/umano/AndroidSlidingUpPanel.git",
							@"38327d828690da0771e7b35a15a118eeecc20e26", 1161),
					Tuple.Create(
							@"https://github.com/amlcurran/ShowcaseView.git",
							@"cc55def081814213c94ad80be4195b17ac4ef18c", 1145),
					Tuple.Create(
							@"https://github.com/openaphid/android-flip.git",
							@"ab2dea1b045ffc626221c2826ce9dd00823e696d", 1142),
					Tuple.Create(
							@"https://github.com/jhy/jsoup.git",
							@"80158d6fa7445506eaaafdeadb1f4dc291ca10a5", 1129),
					Tuple.Create(
							@"https://github.com/yinwang0/pysonar2.git",
							@"240192fb7827dedd9381dbfdd0df3062c47078d0", 1128),
					Tuple.Create(
							@"https://github.com/commonsguy/cw-omnibus.git",
							@"674f1edab621b409922028d0326e02e9ad81015f", 1124),
					Tuple.Create(
							@"https://github.com/JakeWharton/butterknife.git",
							@"3a6f2eb9713cfcea3037282e4fc4d34d50f19d6c", 1121),
					Tuple.Create(
							@"https://github.com/tinkerpop/gremlin.git",
							@"e622d5bf289ef8f74a088dc0237c69b98baf6792", 1111),
					Tuple.Create(
							@"https://github.com/wildfly/wildfly.git",
							@"23dc89381b609dcdac4d2f9da4e4d78b235c51e3", 1102),
					Tuple.Create(
							@"https://github.com/yusuke/twitter4j.git",
							@"747982dfdccd6d1b2ef4857720fe289455a435a1", 1101),
					Tuple.Create(
							@"https://github.com/twall/jna.git",
							@"323a913bf610c982f43b58883b0fc54c78a29621", 1098),
					Tuple.Create(
							@"https://github.com/phonegap/phonegap-facebook-plugin.git",
							@"ccb2a6f648bb2ed44e4b7b71add4fb7b7e95eaed", 1084),
					Tuple.Create(
							@"https://github.com/purplecabbage/phonegap-plugins.git",
							@"319dfb7297002040ec7ab98896e68d05c7fd8180", 1083),
					Tuple.Create(
							@"https://github.com/Comcast/FreeFlow.git",
							@"47bfb57e8037eecae320266cb00dd23e673362e5", 1079),
					Tuple.Create(
							@"https://github.com/ManuelPeinado/FadingActionBar.git",
							@"f679e313d105075cfb389695052348ee09a8e80a", 1068),
					Tuple.Create(
							@"https://github.com/bigbluebutton/bigbluebutton.git",
							@"55773f594eed3e0eff5af47ec8cbd6fcf713a56a", 1062),
					Tuple.Create(
							@"https://github.com/mttkay/ignition.git",
							@"bbeb55cb4f080bdc31e549142ea745c65e4727c7", 1058),
					Tuple.Create(
							@"https://github.com/processing/processing.git",
							@"9c63a2c4a227ed2329fd01006cb593ba8954962d", 1054),
					Tuple.Create(
							@"https://github.com/douglascrockford/JSON-java.git",
							@"4d86b05d3c6a72e88c476430d60676f9ae2fafab", 1052),
					Tuple.Create(
							@"https://github.com/Athou/commafeed.git",
							@"3a8d72cab4038e975af87d8083e2b7e68f2e328c", 1048),
					Tuple.Create(
							@"https://github.com/Graylog2/graylog2-server.git",
							@"c1c5491c4a3194a19c21a7c744d5d45421ecd227", 1041),
					Tuple.Create(
							@"https://github.com/greenrobot/greenDAO.git",
							@"d13a1f1d0e8d244e8033a944599adda7bb157bef", 1039),
					Tuple.Create(
							@"https://github.com/commonsguy/cw-advandroid.git",
							@"ab8e52a00413592b99a7bb9f93050bee760f289f", 1028),
					Tuple.Create(
							@"https://github.com/ether/pad.git",
							@"cb4977238f55f9b2518e7c43a5c769823b0afd45", 987),
					Tuple.Create(
							@"https://github.com/square/android-times-square.git",
							@"2bb367039b3cb93e6764e55835dc023df9f4fd77", 967),
					Tuple.Create(
							@"https://github.com/grails/grails-core.git",
							@"048025b9b98332645df30d82593d44b1f7a84bbd", 960),
					Tuple.Create(
							@"https://github.com/pardom/ActiveAndroid.git",
							@"bd98740d466249fc085311b1c166570cfc08f532", 959),
					Tuple.Create(
							@"https://github.com/kevinsawicki/http-request.git",
							@"c11e2a8b335d43adb9e273412ec7a39c7e404e72", 939),
					Tuple.Create(
							@"https://github.com/mongodb/mongo-java-driver.git",
							@"244b5a26bfe1b6f9e15264d690fa944e7c6e2c54", 924),
					Tuple.Create(
							@"https://github.com/qii/weiciyuan.git",
							@"14fdfe9f6f7f3d927a66d802b709f53ba0ff629e", 906),
					Tuple.Create(
							@"https://github.com/BonzaiThePenguin/WikiSort.git",
							@"b83bde28fbf26198749eb0169d7f01052841b192", 905),
					Tuple.Create(
							@"https://github.com/tjerkw/Android-SlideExpandableListView.git",
							@"a44e6f0fcfabf3a870469667b219552a5d562e87", 901),
					Tuple.Create(
							@"https://github.com/jgilfelt/android-viewbadger.git",
							@"e08c3a78cb92c0c8587790b15e73434f972912cf", 900),
					Tuple.Create(
							@"https://github.com/commonsguy/cw-android.git",
							@"568c11f2b9b556027dda05ad7b62c044f039b4e4", 899),
					Tuple.Create(
							@"https://github.com/orientechnologies/orientdb.git",
							@"8bfc83acadc833b40ec3d485216b39b786935b4c", 897),
					Tuple.Create(
							@"https://github.com/Netflix/curator.git",
							@"1e66d7ccd7ac601df3c814833f1b9e32b25331c6", 896),
					Tuple.Create(
							@"https://github.com/mttkay/droid-fu.git",
							@"469b1bf7a844cc09866bad95fc06321291c649e8", 882),
					Tuple.Create(
							@"https://github.com/thest1/LazyList.git",
							@"0f37d108f2067f5f44749eb0ad44e51656f96f02", 882),
					Tuple.Create(
							@"https://github.com/spring-projects/spring-mvc-showcase.git",
							@"c7b9162c061e135c081a28bf7fc209bb9a992cea", 869),
					Tuple.Create(
							@"https://github.com/yangfuhai/afinal.git",
							@"e706f0e896f8f819aa9a6a8374c7fe9f71fa4950", 865),
					Tuple.Create(
							@"https://github.com/todoroo/astrid.git",
							@"4fc5c7714fb1b48ae46dcacbda287bcef9c3f6bf", 848),
					Tuple.Create(
							@"https://github.com/twitter/ambrose.git",
							@"9ff6dc68e6eb7e95645878082774f44acca5814f", 847),
					Tuple.Create(
							@"https://github.com/perwendel/spark.git",
							@"f1f06769abacc6732e511774d4db2306cbe5db54", 843),
				};
				foreach (var exp in exps) {
					foreach (var learningSet in learningSets) {
						var url = learningSet.Item1;
						var path = Fixture.GetGitRepositoryPath(url);
						Git.CloneAndCheckout(path, url, learningSet.Item2);
						yield return new TestCaseData(exp, path, learningSet.Item3);
					}
				}
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void Test(LearningExperiment exp, string projectPath, int starCount) {
			var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.java"), };
			var allPaths = Directory.GetFiles(projectPath, "*.java", SearchOption.AllDirectories)
					.ToList();
			exp.Learn(allPaths, seedPaths, _writer, projectPath);
			if (exp.WrongFeatureCount > 0) {
				Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
				foreach (var we in exp.WronglyAcceptedElements) {
					var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
					Console.WriteLine(we.Code);
					Console.WriteLine(e.Code);
					Console.WriteLine("---------------------------------------------");
				}
				Console.WriteLine("---- WronglyRejectedElements ----");
				foreach (var we in exp.WronglyRejectedElements) {
					var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
					Console.WriteLine(we.Code);
					Console.WriteLine(e.Code);
					Console.WriteLine("---------------------------------------------");
				}
			}
			exp.Clear();
			Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
		}
	}

	public class JavaSuperComplexBranchExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaSuperComplexBranchExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.Parent;
			var pp = p.Parent;
			var isPar = p.SafeName() == "parExpression";
			var isStmt = pp.SafeName() == "statement";
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
				return true;
			}
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
				return true;
			}
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
				return true;
			}
			if (p.SafeName() == "forstatement"
			    && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
				return true;
			}
			{
				var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
				if (primary.SafeName() != "primary") {
					return false;
				}
				//if (primary.Elements().All(e2 => e2.TokenText() != "Preconditions")) {
				//	return false;
				//}
				if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
					return false;
				}
				//if (primary.NthElementOrDefault(0).SafeTokenText() != "Preconditions") {
				//	return false;
				//}
				//if (primary.NthElementOrDefault(2).SafeTokenText() != "checkArgument") {
				//	return false;
				//}
				if (e.ElementsBeforeSelf().Any()) {
					return false;
				}
				return true;
			}
		}

		public IEnumerable<CstNode> SelectBooleanExpressions(CstNode e) {
			var expressions = e.Descendants("expression")
					.Where(
							e_ => IsIf(e_) || IsWhile(e_) ||
							      IsDoWhile(e_) || IsFor(e_) || IsCheckArgument(e_))
					.Where(e_ => !IsChild(e_, IsCatchBlock));
			return expressions;
		}

		public bool IsCatchBlock(CstNode e) {
			// catch { .. snip .. } 
			return e.Name == "block" && e.Parent.Name == "catchClause";
		}

		public bool IsChild(CstNode e, Func<CstNode, bool> isCatchBlock) {
			return e.Ancestors().Any(isCatchBlock);
		}

		public bool IsIf(CstNode e) {
			// if (cond) { .. snip .. }
			CstNode p = e.Parent, pp = p.Parent;
			return p.Name == "parExpression" && pp.Name == "statement"
			       && pp.FirstChild.TokenText == "if";
		}

		public bool IsWhile(CstNode e) {
			// while (cond) { .. snip .. }
			CstNode p = e.Parent, pp = p.Parent;
			return p.Name == "parExpression" && pp.Name == "statement"
			       && pp.FirstChild.TokenText == "while";
		}

		public bool IsDoWhile(CstNode e) {
			// do { .. snip .. } while (cond);
			CstNode p = e.Parent, pp = p.Parent;
			return p.Name == "parExpression" && pp.Name == "statement"
			       && pp.FirstChild.TokenText == "do";
		}

		public bool IsFor(CstNode e) {
			// do { .. snip .. } while (cond);
			var p = e.Parent;
			return p.Name == "forstatement"
			       && p.Elements().Count(e_ => e_.TokenText == ";") >= 2;
		}

		public bool IsCheckArgument(CstNode e) {
			// Preconditions.checkArgument(cond, msg);
			var primary = e.Parent.Parent.Parent.Parent;
			return primary.Name == "primary"
			       && primary.Elements().Any(e2 => e2.TokenText == "checkArgument")
			       && e.ElementsBeforeSelf().Count() == 0;
		}
	}

	public class JavaComplexBranchExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaComplexBranchExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.Parent;
			var pp = p.Parent;
			var isPar = p.SafeName() == "parExpression";
			var isStmt = pp.SafeName() == "statement";
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
				return true;
			}
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
				return true;
			}
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
				return true;
			}
			if (p.SafeName() == "forstatement"
			    && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
				return true;
			}
			return false;
		}
	}

	public class JavaIfExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaIfExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.Parent;
			var pp = p.Parent;
			var isPar = p.SafeName() == "parExpression";
			var isStmt = pp.SafeName() == "statement";
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "if") {
				return true;
			}
			return false;
		}
	}

	public class JavaWhileExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaWhileExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.Parent;
			var pp = p.Parent;
			var isPar = p.SafeName() == "parExpression";
			var isStmt = pp.SafeName() == "statement";
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "while") {
				return true;
			}
			return false;
		}
	}

	public class JavaDoWhileExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaDoWhileExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.Parent;
			var pp = p.Parent;
			var isPar = p.SafeName() == "parExpression";
			var isStmt = pp.SafeName() == "statement";
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "do") {
				return true;
			}
			return false;
		}
	}

	public class JavaForExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaForExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.Parent;
			if (p.SafeName() == "forstatement"
			    && p.Elements().Count(e2 => e2.TokenText == ";") >= 2) {
				return true;
			}
			return false;
		}
	}

	public class JavaPreconditionsExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaPreconditionsExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var primary = e.SafeParent().SafeParent().SafeParent().SafeParent();
			if (primary.SafeName() != "primary") {
				return false;
			}
			//if (primary.Elements().All(e2 => e2.TokenText() != "Preconditions")) {
			//	return false;
			//}
			if (primary.Elements().All(e2 => e2.TokenText != "checkArgument")) {
				return false;
			}
			//if (primary.NthElementOrDefault(0).SafeTokenText() != "Preconditions") {
			//	return false;
			//}
			//if (primary.NthElementOrDefault(2).SafeTokenText() != "checkArgument") {
			//	return false;
			//}
			if (e.ElementsBeforeSelf().Any()) {
				return false;
			}
			return true;
		}
	}

	public class JavaComplexStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaComplexStatementExperiment() : base("statement", "blockStatement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.Name == "blockStatement") {
				if (e.FirstChild.Name != "statement") {
					return true;
				}
				e = e.FirstChild;
			}

			// ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
			if (e.FirstChild.Name == "block") {
				return false;
			}
			// ラベルはループ文に付くため，ラベルの中身は除外
			var second = e.Siblings().ElementAtOrDefault(1);
			if (second != null && second.TokenText == ":"
			    && e.Parent.Name == "statement") {
				return false;
			}
			if (e.FirstChild.TokenText == ";") {
				return false;
			}
			return true;
		}

		/*
blockStatement 
    : localVariableDeclarationStatement
    | classOrInterfaceDeclaration
    | statement
    ;
statement 
    : block
    | ';'
    | IDENTIFIER ':' statement
	| expression ';'
    | ... (snip) ...
	;
		 */

		public IEnumerable<CstNode> SelectStatements(CstNode e) {
			var blockStatements = e.Descendants("blockStatement")
					.Where(e_ => IsVariableDeclaration(e_) || IsClassDeclaration(e_));
			var statements = e.Descendants("statement")
					.Where(
							e_ =>
									!IsBlockStatement(e_) && !IsEmptyStatement(e_)
									&& !IsLabeledStatement(e_));
			return blockStatements.Concat(statements);
		}

		public bool IsVariableDeclaration(CstNode e) {
			// int value = 0;
			return e.FirstChild.Name == "localVariableDeclarationStatement";
		}

		public bool IsClassDeclaration(CstNode e) {
			// class A {}
			return e.FirstChild.Name == "classOrInterfaceDeclaration";
		}

		public bool IsBlockStatement(CstNode e) {
			// { int value = 0; }
			return e.FirstChild.Name == "block";
		}

		public bool IsEmptyStatement(CstNode e) {
			// ;
			return e.TokenText == ";";
		}

		public bool IsLabeledStatement(CstNode e) {
			// LABEL: should_be_ignored();
			var second = e.Siblings().ElementAtOrDefault(1);
			return second != null && second.TokenText == ":";
		}
	}

	public class JavaBlockExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaBlockExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
			if (e.FirstChild.Name == "block") {
				return true;
			}
			return false;
		}
	}

	public class JavaStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return e.Name == "statement";
		}
	}

	public class JavaLabeledStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaLabeledStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ラベルはループ文に付くため，ラベルの中身は除外
			var second = e.Siblings().ElementAtOrDefault(1);
			if (second != null && second.TokenText == ":"
			    && e.Parent.Name == "statement") {
				return true;
			}
			return false;
		}
	}

	public class JavaEmptyStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaEmptyStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.TokenText == ";") {
				return true;
			}
			return false;
		}
	}

	public class JavaExpressionStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaExpressionStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return e.FirstChild.Name == "expression";
		}
	}

	public class JavaArithmeticOperatorExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaArithmeticOperatorExperiment() : base("PLUS", "SUB", "STAR", "SLASH") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return ((e.TokenText == "+" || e.TokenText == "-") && e.Parent.Name == "additiveExpression") ||
			       ((e.TokenText == "*" || e.TokenText == "/") && e.Parent.Name == "multiplicativeExpression");
		}
	}

	public class JavaSwitchCaseExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return JavaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public JavaSwitchCaseExperiment() : base("expression", "switchLabel") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.Parent;
			var pp = p.Parent;
			var isPar = p.SafeName() == "parExpression";
			var isStmt = pp.SafeName() == "statement";
			if (isStmt && isPar && pp.FirstChild.SafeTokenText() == "switch") {
				return true;
			}
			return e.Name == "switchLabel";
		}
	}
}