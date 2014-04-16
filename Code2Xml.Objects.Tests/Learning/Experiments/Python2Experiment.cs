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
					new PythonEmptyStatementExperiment(),
					new PythonExpressionStatementExperiment(),
					new PythonArithmeticOperatorExperiment(), 
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
			var power = e.SafeParent().SafeParent().SafeParent();
			if (e.Name == "argument" && power.SafeName() == "power" && power.FirstChild.TokenText == "str") {
				return true;
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
			return true;
		}
	}

	public class PythonArithmeticOperatorExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return Python2Experiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public PythonArithmeticOperatorExperiment() : base("PLUS", "MINUS", "STAR", "SLASH") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return ((e.TokenText == "+" || e.TokenText == "-") && e.Parent.Name == "arith_expr") ||
			       ((e.TokenText == "*" || e.TokenText == "/") && e.Parent.Name == "term");
		}
	}
}