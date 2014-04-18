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
	public class Python2Experiment {
		private readonly StreamWriter _writer = File.CreateText(
				@"C:\Users\exKAZUu\Desktop\Python.csv");

		public static CstGenerator Generator = CstGenerators.Python2;
		private const string LangName = "Python2";

		private static IEnumerable<TestCaseData> TestCases {
			get {
				var exps = new LearningExperiment[] {
					new PythonComplexStatementExperiment(),
					new PythonSuperComplexBranchExperiment(),
					new PythonExpressionStatementExperiment(),
					new PythonArithmeticOperatorExperiment(), 
					new PythonEmptyStatementExperiment(),
				};
				var learningSets = new[] {
					Tuple.Create(
							@"https://github.com/kennethreitz/requests.git",
							@"07ee20d07dfd316a0fdd5ec4f5d276a72fe4cc62", 9438),
					Tuple.Create(
							@"https://github.com/django/django.git",
							@"09af48c70fb5cc652ea109487015472e9ef984df", 9391),
					Tuple.Create(
							@"https://github.com/mitsuhiko/flask.git",
							@"d4b3d16c142e2189c6faf8f784a195e7f827c596", 9253),
					Tuple.Create(
							@"https://github.com/jkbr/httpie.git",
							@"746a1899f319a7c2a60f27bf23cc3762822be1a2", 6922),
					Tuple.Create(
							@"https://github.com/ansible/ansible.git",
							@"2cc4ac2e7563e6b73666048c3624bf092f9959e1", 5536),
					Tuple.Create(
							@"https://github.com/reddit/reddit.git",
							@"b50f91c53149671c4039ff1de4250ac0d5bc89c0", 5480),
					Tuple.Create(
							@"https://github.com/CamDavidsonPilon/Probabilistic-Programming-and-Bayesian-Methods-for-Hackers.git",
							@"39f9356f320bcff1a2a3e01d8559d9089413b4eb", 5379),
					Tuple.Create(
							@"https://github.com/kennethreitz/python-guide.git",
							@"cf3a875262eb5172342e6b0d06ccfb6655233abf", 4749),
					Tuple.Create(
							@"https://github.com/getsentry/sentry.git",
							@"94e56e691f4081db7680faf49db5592ec29edd23", 4705),
					Tuple.Create(
							@"https://github.com/scrapy/scrapy.git",
							@"7814cbf3197605a1b125f061a78cde015a934819", 4520),
					Tuple.Create(
							@"https://github.com/rg3/youtube-dl.git",
							@"2d4c98dbd17676978114b70d59ea15628f886c24", 4143),
					Tuple.Create(
							@"https://github.com/pagekite/Mailpile.git",
							@"556c9e16855dea71db23bc2180e4cef1cf2a40ef", 4049),
					Tuple.Create(
							@"https://github.com/apenwarr/sshuttle.git",
							@"9ce2fa00f94c2f2e5c310abeb1a2907ae7e7a7b0", 3944),
					Tuple.Create(
							@"https://github.com/boto/boto.git",
							@"c213ff114a28aedb491f90a3acc6ee4626cae578", 3680),
					Tuple.Create(
							@"https://github.com/getpelican/pelican.git",
							@"b11b8a93cd45ad2d16118ce2bffef8bd3128a004", 3281),
					Tuple.Create(
							@"https://github.com/saltstack/salt.git",
							@"0c9f7eb3569cc5fc547d2ed2628da9a3def7d80e", 3271),
					Tuple.Create(
							@"https://github.com/fabric/fabric.git",
							@"b41f7995bcaa5ade335e1dd1e438ae2ca42f4e07", 3102),
					Tuple.Create(
							@"https://github.com/kennethreitz/legit.git",
							@"473d87d32488f8f71f0ee3086814fdf62b291a60", 3088),
					Tuple.Create(
							@"https://github.com/facebook/huxley.git",
							@"2177563400ba03580622144b521bb116c345225c", 2969),
					Tuple.Create(
							@"https://github.com/django/django-old.git",
							@"ad096059b58afd35b395b01ad4eba36b8ff863de", 2908),
					Tuple.Create(
							@"https://github.com/webpy/webpy.git",
							@"73f1119649ffe54ba26ddaf6a612aaf1dab79b7f", 2804),
					Tuple.Create(
							@"https://github.com/lebinh/ngxtop.git",
							@"3694d55b15f73b531d8c7951711799ffa3c7521a", 2783),
					Tuple.Create(
							@"https://github.com/sampsyo/beets.git",
							@"fcb55145e6fcafab69bc6eedb16154516c341548", 2734),
					Tuple.Create(
							@"https://github.com/liftoff/GateOne.git",
							@"2fe1daf3812bbc620ea53245666106e270b7502c", 2707),
					Tuple.Create(
							@"https://github.com/divio/django-cms.git",
							@"f884372e0576a384e05c6a8f084eaf089eae25b3", 2704),
					Tuple.Create(
							@"https://github.com/midgetspy/Sick-Beard.git",
							@"a493151582d5779f5656291c9251398623511e7b", 2684),
					Tuple.Create(
							@"https://github.com/Lokaltog/powerline.git",
							@"c100c90b088c55fe91146eb52dfcbbc7e43039bd", 2614),
					Tuple.Create(
							@"https://github.com/django-debug-toolbar/django-debug-toolbar.git",
							@"777c8a1cd669bbfde6cfcb8866de4fdf8c0825cf", 2613),
					Tuple.Create(
							@"https://github.com/SublimeCodeIntel/SublimeCodeIntel.git",
							@"3a0c3b924632e3f504f21f86c2fda2c87d2ce0ca", 2592),
					Tuple.Create(
							@"https://github.com/celery/celery.git",
							@"ae277443cfe381a0c855a67338afe08a34cff1b5", 2557),
					Tuple.Create(
							@"https://github.com/progrium/localtunnel.git",
							@"08f3ac0f15f3b7324f1f1b1fbbbccfb926bfa7fe", 2492),
					Tuple.Create(
							@"https://github.com/toastdriven/django-tastypie.git",
							@"834f728b07ab1a008b281b12a2cab2987f26c99d", 2439),
					Tuple.Create(
							@"https://github.com/andymccurdy/redis-py.git",
							@"f96e46b971a5bb66ab5f94ba87ab3e092e5f01ac", 2438),
					Tuple.Create(
							@"https://github.com/Katee/quietnet.git",
							@"946e57c2f87800e342240a4d33c0163d3682e8c1", 2431),
					Tuple.Create(
							@"https://github.com/square/SocketRocket.git",
							@"656283dd195414723cd473746923db50abd34cb2", 2390),
					Tuple.Create(
							@"https://github.com/docopt/docopt.git",
							@"05125ddcd1750f7e5ed373044910e224e1e636ed", 2377),
					Tuple.Create(
							@"https://github.com/defnull/bottle.git",
							@"33b1683793bc6ce8af37c9d5c34be0c4fe220d1f", 2292),
					Tuple.Create(
							@"https://github.com/clips/pattern.git",
							@"a9d7f8449c0118e7442b4ffb1c78097c74b468ed", 2253),
					Tuple.Create(
							@"https://github.com/tomchristie/django-rest-framework.git",
							@"b3b0515ae6325e7de6a582bbb2fd7eeac687c325", 2200),
					Tuple.Create(
							@"https://github.com/jisaacks/GitGutter.git",
							@"299097085eb58bfdb4da52b0d86b4bb450e4c59d", 2182),
					Tuple.Create(
							@"https://github.com/amoffat/sh.git",
							@"80af5726d8aa42017ced548abbd39b489068922a", 2181),
					Tuple.Create(
							@"https://github.com/gleitz/howdoi.git",
							@"e022e1d341bdb11f6731f2d819399aee7dc57d5c", 2165),
					Tuple.Create(
							@"https://github.com/joke2k/faker.git",
							@"7cd01eb89df25ee7e98854b9edd991e008c6f49f", 2163),
					Tuple.Create(
							@"https://github.com/nicolargo/glances.git",
							@"4177046cdd3be8f2019799490de54a7aab5b0550", 2136),
					Tuple.Create(
							@"https://github.com/scrapinghub/portia.git",
							@"55f97e61fc558d243a0806ae8bf4a26b080026de", 2132),
					Tuple.Create(
							@"https://github.com/jorgebastida/glue.git",
							@"33fa00c35ad3a186e187bdf93105617ced46d43f", 2128),
					Tuple.Create(
							@"https://github.com/kstenerud/iOS-Universal-Framework.git",
							@"2b65899ed6c57e999145f521a327999692837ac8", 2094),
					Tuple.Create(
							@"https://github.com/somerandomdude/Iconic.git",
							@"3a1136003928f0dbc1284eb568d3a0b6a5ad6830", 2080),
					Tuple.Create(
							@"https://github.com/omab/django-social-auth.git",
							@"3a6e4414da0e969fcaf625a891852a3b2d7627c0", 2078),
					Tuple.Create(
							@"https://github.com/joelthelion/autojump.git",
							@"6360876933c4245ee3762a3d52e74a6d591772ff", 1994),
					Tuple.Create(
							@"https://github.com/tweepy/tweepy.git",
							@"d626a964b29f7a9e93599a3b25789f8b997b1aef", 1993),
					Tuple.Create(
							@"https://github.com/simplegeo/python-oauth2.git",
							@"a83f4a297336b631e75cba102910c19231518159", 1991),
					Tuple.Create(
							@"https://github.com/bup/bup.git",
							@"458051fe66179667b88b84cf31596c21d3b0f05a", 1948),
					Tuple.Create(
							@"https://github.com/lg/murder.git",
							@"9c59118ce17c1d033318a34b01995eb96b3d35a3", 1868),
					Tuple.Create(
							@"https://github.com/facebook/chisel.git",
							@"368e4f675a77cefc7f2dddfd4de87f8b9422aadd", 1864),
					Tuple.Create(
							@"https://github.com/django-extensions/django-extensions.git",
							@"893bcffdb79dbdd98ecf5aebe30452080c71ac7a", 1844),
					Tuple.Create(
							@"https://github.com/pinax/pinax.git",
							@"2d45637a035d41ec900e0f3152812cb940c76d35", 1839),
					Tuple.Create(
							@"https://github.com/aws/aws-cli.git",
							@"4996cd601117b83e059104b7c9c0a65dbd0c00df", 1828),
					Tuple.Create(
							@"https://github.com/klen/python-mode.git",
							@"b79b2e991e48488fb2800d9deec3b2ec457bb095", 1793),
					Tuple.Create(
							@"https://github.com/sokolovstas/SublimeWebInspector.git",
							@"ec464edcb13899ea4b4ff98003fc8daf7f1d451a", 1788),
					Tuple.Create(
							@"https://github.com/redecentralize/alternative-internet.git",
							@"2f4b440c456c00813d78d3416c8b72ec2f08cc5c", 1787),
					Tuple.Create(
							@"https://github.com/orchardup/fig.git",
							@"530afba5cb0d0f0b15f37643f4da476c4b336ded", 1785),
					Tuple.Create(
							@"https://github.com/benoitc/gunicorn.git",
							@"3bf6d0e77026098e7a6d905426c53e951a3889ef", 1783),
					Tuple.Create(
							@"https://github.com/sqlmapproject/sqlmap.git",
							@"ef5ce7e66c26af2405ea7f0e1da282b99f7cb450", 1767),
					Tuple.Create(
							@"https://github.com/devstructure/blueprint.git",
							@"574a9fc0dd3031c66970387f1105d8c89e61218f", 1732),
					Tuple.Create(
							@"https://github.com/kivy/kivy.git",
							@"84a6bbcae99278928c996ddcbc39d683c2803e57", 1722),
					Tuple.Create(
							@"https://github.com/kemayo/sublime-text-git.git",
							@"cce6c085670140d00b3f76c5458f34bf7caeb5ef", 1691),
					Tuple.Create(
							@"https://github.com/thearn/webcam-pulse-detector.git",
							@"42bfbe23a54e8f0a1725595468e4486d96e11561", 1665),
					Tuple.Create(
							@"https://github.com/shipyard/shipyard.git",
							@"400b6455fc249ad096bc849f2f27385cfe2daa6d", 1650),
					Tuple.Create(
							@"https://github.com/mitsuhiko/jinja2.git",
							@"b7d13f278753d057bb3765b4d4a672c351d88bf3", 1626),
					Tuple.Create(
							@"https://github.com/sloria/TextBlob.git",
							@"75d983fc798528dc3c8633efcfb031ae191752d1", 1625),
					Tuple.Create(
							@"https://github.com/wbond/sublime_package_control.git",
							@"0b03e16d91203df21aced724b013c8bd75856cd3", 1620),
					Tuple.Create(
							@"https://github.com/harelba/q.git",
							@"eb64e76c366163b14ba76b95525ef0ac99d0ab9b", 1616),
					Tuple.Create(
							@"https://github.com/fogleman/Minecraft.git",
							@"d02cd72d1ec2ee133b3fec6ac1710e22bea59365", 1561),
					Tuple.Create(
							@"https://github.com/coursera-dl/coursera.git",
							@"3fdb3ce901587eaadb6a1b3c00f1d45ae666e5c2", 1520),
					Tuple.Create(
							@"https://github.com/clowwindy/shadowsocks.git",
							@"854d1752453d742db9c759f2ae4c3253dd0143e7", 1517),
					Tuple.Create(
							@"https://github.com/opdemand/deis.git",
							@"50e42169ac82417dd337fd4a08527401edbeea85", 1507),
					Tuple.Create(
							@"https://github.com/maraujop/django-crispy-forms.git",
							@"e31e39561c10b01be3693914aad1aa79350f5647", 1502),
					Tuple.Create(
							@"https://github.com/jeffknupp/sandman.git",
							@"e534defd803082feee0af30b64d2c9fb4c5ed2ac", 1482),
					Tuple.Create(
							@"https://github.com/playframework/play1.git",
							@"b835b790c795bddd7d41ac6a4a7a1eb6922fab2f", 1472),
					Tuple.Create(
							@"https://github.com/thumbor/thumbor.git",
							@"0ec1e71fe2d85d3278e3a4196e23f8d8229238e3", 1459),
					Tuple.Create(
							@"https://github.com/mitsuhiko/werkzeug.git",
							@"ca58b6856f1bb204e8a2b4fd247d92ad943b798b", 1419),
					Tuple.Create(
							@"https://github.com/iambus/xunlei-lixian.git",
							@"4d814d1b6fc6907162892ffae3e22898ad98184f", 1411),
					Tuple.Create(
							@"https://github.com/toastdriven/django-haystack.git",
							@"366e7489169d460d36ac4d942c22c0e97e58c26b", 1408),
					Tuple.Create(
							@"https://github.com/nltk/nltk.git",
							@"8cef1664d6461992b5c6f172dd8975511e043d4e", 1396),
					Tuple.Create(
							@"https://github.com/quantopian/zipline.git",
							@"63e3aa4c1e8f25b08e3fbc437f778b28453c7e45", 1395),
					Tuple.Create(
							@"https://github.com/nicolaiarocci/eve.git",
							@"ee559c0407204ee4c42c8b3e59f3c6b8fa4a7437", 1386),
					Tuple.Create(
							@"https://github.com/aziz/PlainTasks.git",
							@"be34d6efad4435e4029870297d193699985bc414", 1386),
					Tuple.Create(
							@"https://github.com/RuudBurger/CouchPotatoServer.git",
							@"b69f8b7ed520930dcab53dc27c1eb58a0c2afbf4", 1378),
					Tuple.Create(
							@"https://github.com/utahta/pythonbrew.git",
							@"e8823c5494a26e2c91aa516eac80b748474ba129", 1368),
					Tuple.Create(
							@"https://github.com/kennethreitz/clint.git",
							@"f1ab574413631de12166469e87257784785d3da6", 1364),
					Tuple.Create(
							@"https://github.com/taobao/nginx-book.git",
							@"b1cba2dc114393766e863581b34dbe179b28c18e", 1363),
					Tuple.Create(
							@"https://github.com/Pylons/pyramid.git",
							@"77005d96fa57a83ac91c2547892fbb3e3c34e553", 1352),
					Tuple.Create(
							@"https://github.com/treeio/treeio.git",
							@"a4fbffabec2644a98f8b06d678a94d2949304235", 1335),
					Tuple.Create(
							@"https://github.com/rembo10/headphones.git",
							@"d6cd9cd7e4cd95e2e4d2fd845fa0c64b91e5e4a5", 1319),
					Tuple.Create(
							@"https://github.com/koenbok/Cactus.git",
							@"10cd41a4a06ab0c88daf625e5a1b7fda202d7126", 1319),
					Tuple.Create(
							@"https://github.com/nvie/rq.git",
							@"aef7af9c77fb6c1e5836403660a4e71fe3c05230", 1316),
					Tuple.Create(
							@"https://github.com/mongodb/mongo-python-driver.git",
							@"a7575fa14f5a9aaeb0149981899f776af9e1ad1c", 1286),
					Tuple.Create(
							@"https://github.com/lihaoyi/macropy.git",
							@"13993ccb08df21a0d63b091dbaae50b9dbb3fe3e", 1271),
					Tuple.Create(
							@"https://github.com/torchbox/wagtail.git",
							@"d3ac6c072886a1c4cd8d27b94c4a9b6e9d51f218", 1256),
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
			var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.py"), };
			var allPaths = Directory.GetFiles(projectPath, "*.py", SearchOption.AllDirectories)
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

	public class PythonSuperComplexBranchExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return Python2Experiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public PythonSuperComplexBranchExperiment() : base("test", "argument") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.Name == "test" && (e.Parent.Name == "if_stmt" || e.Parent.Name == "while_stmt")) {
				return true;
			}
			if (e.Name == "test") {
				e = e.Parent;
			}
			if (e.Name == "argument" && e.Prev == null && e.SafeParent().Name == "arglist"
			    && e.SafeParent().SafeParent().Name == "trailer"
			    && e.SafeParent().SafeParent().SafeParent().Name == "power") {
				var atom = e.SafeParent().SafeParent().Prev;
				return atom.Name == "atom" && atom.TokenText == "str";
			}
			return false;
		}
	}

	public class PythonComplexStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return Python2Experiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public PythonComplexStatementExperiment() : base("small_stmt", "compound_stmt") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.Name == "stmt") {
				e = e.FirstChild;
			}
			if (e.Name == "small_stmt" && e.FirstChild.Name == "pass_stmt") {
				return false;
			}
			return e.Name == "small_stmt" || e.Name == "compound_stmt";
		}
	}

	public class PythonEmptyStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return Python2Experiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public PythonEmptyStatementExperiment() : base("pass_stmt") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return true;
		}
	}

	public class PythonExpressionStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return Python2Experiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public PythonExpressionStatementExperiment() : base("expr_stmt") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.Name == "small_stmt") {
				return e.FirstChild.Name == "expr_stmt";
			}
			return true;
		}
	}

	public class PythonArithmeticOperatorExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return Python2Experiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public PythonArithmeticOperatorExperiment() : base("PLUS", "MINUS", "STAR", "SLASH") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return ((e.TokenText == "+" || e.TokenText == "-") && e.Parent.Name == "arith_expr") ||
			       ((e.TokenText == "*" || e.TokenText == "/") && e.Parent.Name == "term");
		}
	}
}