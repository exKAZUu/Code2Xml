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
	public class CSharpExperiment {
		private readonly StreamWriter _writer = File.CreateText(@"C:\Users\exKAZUu\Desktop\cs.txt");

		public static CstGenerator Generator = CstGenerators.CSharpUsingAntlr3;

		//new MemoryCacheCstGenerator(new FileCacheCstGenerator(ProcessorLoader.CSharpUsingAntlr3));

		private static IEnumerable<TestCaseData> TestCases {
			get {
				var exps = new BitLearningExperimentGroupingWithId[] {
					new CSharpComplexStatementExperiment(),
					new CSharpSuperComplexBranchExperiment(),
					new CSharpComplexBranchExperiment(),
					new CSharpIfExperiment(),
					new CSharpWhileExperiment(),
					new CSharpDoWhileExperiment(),
					new CSharpForExperiment(),
					new CSharpPreconditionsExperiment(),
					new CSharpStatementExperiment(), 
					new CSharpBlockExperiment(),
					new CSharpLabeledStatementExperiment(),
					new CSharpEmptyStatementExperiment(),
				};
				const string langName = "CSharp";
				var learningSets = new[] {
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "MechJeb2"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					//Tuple.Create(Fixture.GetInputProjectPath(langName, "MediaPortal-1"),
					//		new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "MonoTouch.Dialog"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "moq4"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "Nancy"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "Newtonsoft.Json"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "NuGetGallery"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "ravendb"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "ServiceStack"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "SignalR"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "StarryboundServer"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
				};
				foreach (var exp in exps) {
					foreach (var learningSet in learningSets) {
						yield return new TestCaseData(exp, learningSet.Item1, learningSet.Item2);
					}
				}
			}
		}

		[Test, TestCaseSource("TestCases")]
		public void Test(
				BitLearningExperimentGroupingWithId exp, string projectPath, IList<string> seedPaths) {
			var allPaths = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories)
					.ToList();
			exp.AutomaticallyLearnUntilBeStable(allPaths, seedPaths, _writer, projectPath);
			exp.Clear();
			Assert.That(exp.WrongCount, Is.EqualTo(0));
		}

		[Test, TestCaseSource("TestCases")]
		public void CheckLearnable(
				BitLearningExperimentGroupingWithId exp, string projectPath, IList<string> seedPaths) {
			var allPaths = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories)
					.ToList();
			//exp.CheckLearnable(allPaths, seedPaths);
		}
	}

	public class CSharpSuperComplexBranchExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public CSharpSuperComplexBranchExperiment() : base("boolean_expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.Parent.Name;
			if (pName == "if_statement") {
				return true;
			}
			if (pName == "while_statement") {
				return true;
			}
			if (pName == "do_statement") {
				return true;
			}
			if (pName == "for_condition") {
				return true;
			}
			if (e.ElementsBeforeSelf().Any()) {
				return false;
			}
			var p = e.Parent.Parent.Parent.Parent.Parent;
			var parts = p.Elements("primary_expression_start")
					.Concat(p.Elements("primary_expression_part"))
					.ToList();
			if (parts.All(e2 => e2.Descendants("identifier").FirstOrDefault().TokenText != "Contract")) {
				return false;
			}
			if (parts.All(e2 => e2.Descendants("identifier").FirstOrDefault().TokenText != "Requires")) {
				return false;
			}
			return true;
		}
	}

	public class CSharpComplexBranchExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public CSharpComplexBranchExperiment() : base("boolean_expression") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.Parent.Name;
			if (pName == "if_statement") {
				return true;
			}
			if (pName == "while_statement") {
				return true;
			}
			if (pName == "do_statement") {
				return true;
			}
			if (pName == "for_condition") {
				return true;
			}
			return false;
		}
	}

	public class CSharpIfExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.Parent.Name;
			if (pName == "if_statement") {
				return true;
			}
			return false;
		}

		public CSharpIfExperiment() : base("boolean_expression") {}
	}

	public class CSharpWhileExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.Parent.Name;
			if (pName == "while_statement") {
				return true;
			}
			return false;
		}

		public CSharpWhileExperiment() : base("boolean_expression") {}
	}

	public class CSharpDoWhileExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pName = e.Parent.Name;
			if (pName == "do_statement") {
				return true;
			}
			return false;
		}

		public CSharpDoWhileExperiment() : base("boolean_expression") {}
	}

	public class CSharpForExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return true;
		}

		public CSharpForExperiment() : base("for_condition") {}
	}

	public class CSharpPreconditionsExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.ElementsBeforeSelf().Any()) {
				return false;
			}
			var p = e.Parent.Parent.Parent.Parent.Parent;
			var parts = p.Elements("primary_expression_start")
					.Concat(p.Elements("primary_expression_part"))
					.ToList();
			if (parts.All(e2 => e2.Descendants("identifier").FirstOrDefault().SafeTokenText() != "Contract")) {
				return false;
			}
			if (parts.All(e2 => e2.Descendants("identifier").FirstOrDefault().SafeTokenText() != "Requires")) {
				return false;
			}
			return true;
		}

		public CSharpPreconditionsExperiment() : base("argument") {}
	}

	public class CSharpComplexStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ラベルはループ文に付くため，ラベルの中身は除外
			if (e.Element("labeled_statement") != null) {
				return false;
			}

			// ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
			var e2 = e.Element("embedded_statement");
			if (e2 != null && e2.Element("block") != null) {
				return false;
			}

			// 空文を除外
			if (e.TokenText == ";") {
				return false;
			}
			return true;
		}

		public CSharpComplexStatementExperiment() : base("statement") {}
	}

	public class CSharpStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return true;
		}

		public CSharpStatementExperiment() : base("statement") {}
	}

	public class CSharpBlockExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ブロック自身は意味を持たないステートメントで、中身だけが必要なので除外
			var e2 = e.Element("embedded_statement");
			if (e2 != null && e2.Element("block") != null) {
				return true;
			}
			return false;
		}

		public CSharpBlockExperiment() : base("statement") {}
	}

	public class CSharpLabeledStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// ラベルはループ文に付くため，ラベルの中身は除外
			if (e.Element("labeled_statement") != null) {
				return true;
			}
			return false;
		}

		public CSharpLabeledStatementExperiment() : base("statement") {}
	}

	public class CSharpEmptyStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			// 空文を除外
			if (e.TokenText == ";") {
				return true;
			}
			return false;
		}

		public CSharpEmptyStatementExperiment() : base("statement") {}
	}
}