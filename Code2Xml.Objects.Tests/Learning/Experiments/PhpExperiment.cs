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
	public class PhpExperiment {
		private readonly StreamWriter _writer = File.CreateText(@"C:\Users\exKAZUu\Desktop\php.txt");

		public static CstGenerator Generator = CstGenerators.PhpUsingAntlr3;
		private const string LangName = "Php";

		//new MemoryCacheCstGenerator(new FileCacheCstGenerator(ProcessorLoader.PhpUsingAntlr3));

		private static IEnumerable<TestCaseData> TestCases {
			get {
				var exps = new LearningExperiment[] {
					new PhpComplexStatementExperiment(),
					new PhpSuperComplexBranchExperiment(),
					new PhpExpressionStatementExperiment(),
					new PhpArithmeticOperatorExperiment(), 
					//new PhpComplexBranchExperiment(),
					//new PhpIfExperiment(),
					//new PhpWhileExperiment(),
					//new PhpDoWhileExperiment(),
					//new PhpForExperiment(),
					//new PhpEchoExperiment(),
					//new PhpStatementExperiment(),
					//new PhpBlockExperiment(),
					//new PhpLabeledStatementExperiment(),
					//new PhpEmptyStatementExperiment(),
				};
				var learningSets = new[] {
					Tuple.Create(
							@"https://github.com/al3x/sovereign.git",
							@"4349e03dfc4b53e75a78441ebd8ace93f8e4cd47", 2927),
					Tuple.Create(
							@"https://github.com/serbanghita/Mobile-Detect.git",
							@"d70de7bfd0641d4d32a6f9c71e1f5d2839a5331e", 2862),
					Tuple.Create(
							@"https://github.com/abraham/twitteroauth.git",
							@"4b775766fe3526ebc67ee20c97ff29a3b47bc5d8", 2304),
					Tuple.Create(
							@"https://github.com/subtlepatterns/SubtlePatterns.git",
							@"6e056565a1254c967228aab60c9d9c7d0e63a7e3", 2271),
					Tuple.Create(
							@"https://github.com/leafo/lessphp.git",
							@"b7cd5c79e82666bcd2dfadb304342311209fb527", 1929),
					Tuple.Create(
							@"https://github.com/puphpet/puphpet.git",
							@"e4012cbbe0fc3b200b4750bb79673a9f468c1b9e", 1803),
					Tuple.Create(
							@"https://github.com/venomous0x/WhatsAPI.git",
							@"5ad50b311d728752cee50b7c7ed00062df6cb740", 1613),
					Tuple.Create(
							@"https://github.com/PHPMailer/PHPMailer.git",
							@"7b384d0bedf7feb1d3cdfaae689d8c5b68eb0515", 1600),
					Tuple.Create(
							@"https://github.com/fabpot/Goutte.git",
							@"06a5451288ffddd204b10fa6c6f9ab2b86dd515d", 1584),
					Tuple.Create(
							@"https://github.com/tommcfarlin/WordPress-Plugin-Boilerplate.git",
							@"db289e22840277c26911d46972fe516ce309e430", 1543),
					Tuple.Create(
							@"https://github.com/MattWilcox/Adaptive-Images.git",
							@"faa87fd94fc59373df7c2e5bb605c7e3c28e38a4", 1454),
					Tuple.Create(
							@"https://github.com/kohana/kohana.git",
							@"338bea96dfa197e7864674dab6cef78958e1f1df", 1365),
					Tuple.Create(
							@"https://github.com/WebDevStudios/Custom-Metaboxes-and-Fields-for-WordPress.git",
							@"c9402b287b6ffcfbc0eeab4109ece8f1a5d25848", 1361),
					Tuple.Create(
							@"https://github.com/michelf/php-markdown.git",
							@"6f952ee180e9bd345f3dd6005aa11e0f5dcbd1b8", 1347),
					Tuple.Create(
							@"https://github.com/fuel/fuel.git",
							@"82f79d7d9be671fafcfd9ca405425501bf8d8634", 1313),
					Tuple.Create(
							@"https://github.com/umpirsky/country-list.git",
							@"19c2fb49a7eda5347170f8f8d723f92701468f60", 1306),
					Tuple.Create(
							@"https://github.com/usmanhalalit/charisma.git",
							@"5a8e4fdbefe694bf6a3a9c86e41acf9abf5c06cb", 1288),
					Tuple.Create(
							@"https://github.com/omnipay/omnipay.git",
							@"aa1de2346b365527486b16f0f07ff190effe6d3e", 1204),
					Tuple.Create(
							@"https://github.com/j4mie/idiorm.git",
							@"11e964157a6a2c6128a0546673ad5e99ac1a62cd", 1200),
					Tuple.Create(
							@"https://github.com/benedmunds/CodeIgniter-Ion-Auth.git",
							@"e083881869045eeee9f96f957a65872b9977450f", 1184),
					Tuple.Create(
							@"https://github.com/JosephLenton/PHP-Error.git",
							@"9918dd5eeec527846d43c92a4c9880bfcdd0de14", 1150),
					Tuple.Create(
							@"https://github.com/zendframework/ZendSkeletonApplication.git",
							@"67cbbbf61897831ef1feda323be9845aa7d79682", 1110),
					Tuple.Create(
							@"https://github.com/pattern-lab/patternlab-php.git",
							@"ff31431333113c553d2f299a49b783351229d026", 1077),
					Tuple.Create(
							@"https://github.com/facebook/xhprof.git",
							@"e83d1792569ecbc5ef14c50a00eb37094d4e6ad9", 1036),
					Tuple.Create(
							@"https://github.com/KnpLabs/Gaufrette.git",
							@"c2b6af8eb6fc093409ee0753137817dce1673763", 1027),
					Tuple.Create(
							@"https://github.com/symfony/symfony-standard.git",
							@"50aeda221a0328dccae905b8dafed67f97983bcf", 1006),
					Tuple.Create(
							@"https://github.com/Circa75/dropplets.git",
							@"feb2e82b21ef7a7da484e17628160f866c2da6c0", 997),
					Tuple.Create(
							@"https://github.com/panique/php-login.git",
							@"350ffc9455617b24979535283258ea8a05b7cf33", 994),
					Tuple.Create(
							@"https://github.com/opauth/opauth.git",
							@"3ff68e72c21a3691e5a87fc8c30e458edbb22990", 987),
					Tuple.Create(
							@"https://github.com/simplethemes/skeleton_wp.git",
							@"55495c735bcb35f2e7752c6e62e29054bfc69892", 968),
					Tuple.Create(
							@"https://github.com/interconnectit/Search-Replace-DB.git",
							@"12c6732502958a0c57125f6b30741e6e0f05655c", 852),
					Tuple.Create(
							@"https://github.com/markjaquith/WP-Stack.git",
							@"1a5714be857ffcd494ea56d9ff3619500815839e", 829),
				};
				foreach (var exp in exps) {
					foreach (var learningSet in learningSets.Take(10)) {
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
			var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.php"), };
			var allPaths = Directory.GetFiles(projectPath, "*.php", SearchOption.AllDirectories)
					.ToList();
			exp.Learn(allPaths, seedPaths, _writer, projectPath);
			exp.Clear();
			Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
		}
	}

	public class PhpComplexBranchExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public PhpComplexBranchExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = (string)e.SafeParent().FirstChild.Name;
			if (pName == "If") {
				return true;
			}
			if (pName == "While") {
				return true;
			}
			if (pName == "Do") {
				return true;
			}
			if (e.SafeParent().Name == "commaList" && e.SafeParent().Next == null
			    && e.SafeParent().SafeParent().Name == "forCondition") {
				return true;
			}
			return false;
		}
	}

	public class PhpSuperComplexBranchExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public PhpSuperComplexBranchExperiment() : base("expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.SafeParent().FirstChild.Name;
			if (pName == "If") {
				return true;
			}
			if (pName == "While") {
				return true;
			}
			if (pName == "Do") {
				return true;
			}
			if (e.SafeParent().Name == "commaList"
			    && e.SafeParent().SafeParent().Name == "forCondition"
			    && !e.NextsFromSelf().Any()) {
				return true;
			}
			if (e.SafeParent().Name == "commaList"
			    && e.SafeParent().SafeParent().Name == "simpleStatement"
			    && e.SafeParent().SafeParent().FirstChild.Name == "Echo"
			    && e.Prev == null) {
				return true;
			}
			return false;
		}
	}

	public class PhpIfExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.SafeParent().FirstChild.Name;
			if (pName == "If") {
				return true;
			}
			return false;
		}

		public PhpIfExperiment() : base("expression") {}
	}

	public class PhpWhileExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.SafeParent().FirstChild.Name;
			if (pName == "While") {
				return true;
			}
			return false;
		}

		public PhpWhileExperiment() : base("expression") {}
	}

	public class PhpDoWhileExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.SafeParent().FirstChild.Name;
			if (pName == "Do") {
				return true;
			}
			return false;
		}

		public PhpDoWhileExperiment() : base("expression") {}
	}

	public class PhpForExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.SafeParent().Name == "commaList"
			    && e.SafeParent().SafeParent().Name == "forCondition"
			    && !e.NextsFromSelf().Any()) {
				return true;
			}
			return false;
		}

		public PhpForExperiment() : base("expression") {}
	}

	public class PhpEchoExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.SafeParent().Name == "commaList"
			    && e.SafeParent().SafeParent().Name == "simpleStatement"
			    && e.SafeParent().SafeParent().FirstChild.Name == "Echo"
			    && e.Prev == null) {
				return true;
			}
			return false;
		}

		public PhpEchoExperiment() : base("expression") {}
	}

	public class PhpComplexStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ラベルはループ文に付くため，ラベルの中身は除外
			if (e.FirstChild.Name != "UnquotedString") {
				return false;
			}
			// ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
			if (e.Element("bracketedBlock") != null) {
				return false;
			}
			// 空文
			if (e.FirstChild.TokenText == ";") {
				return false;
			}
			return true;
		}

		public PhpComplexStatementExperiment() : base("statement") {}
	}

	public class PhpStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return true;
		}

		public PhpStatementExperiment() : base("statement") {}
	}

	public class PhpBlockExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
			if (e.Element("bracketedBlock") != null) {
				return true;
			}
			return false;
		}

		public PhpBlockExperiment() : base("statement") {}
	}

	public class PhpLabeledStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ラベルはループ文に付くため，ラベルの中身は除外
			if (e.FirstChild.Name != "UnquotedString") {
				return true;
			}
			return false;
		}

		public PhpLabeledStatementExperiment() : base("statement") {}
	}

	public class PhpEmptyStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// 空文
			if (e.FirstChild.TokenText == ";") {
				return true;
			}
			return false;
		}

		public PhpEmptyStatementExperiment() : base("statement") {}
	}

	public class PhpExpressionStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public PhpExpressionStatementExperiment() : base("simpleStatement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return e.FirstChild.Name == "expression";
		}
	}

	public class PhpArithmeticOperatorExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return PhpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public PhpArithmeticOperatorExperiment() : base("Plus", "Minus", "Asterisk", "Forwardslash") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return e.Parent.Name == "addition" ||
			       e.Parent.Name == "multiplication";
		}
	}
}