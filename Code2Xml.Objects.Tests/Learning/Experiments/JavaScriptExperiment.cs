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
	public class JavaScriptExperiment {
		private readonly StreamWriter _writer = File.CreateText(
				@"C:\Users\exKAZUu\Desktop\javascript.txt");

		public static CstGenerator Generator = CstGenerators.JavaScriptUsingAntlr3;

		//new MemoryCacheCstGenerator(new FileCacheCstGenerator(ProcessorLoader.JavaScriptUsingAntlr3));

		private static IEnumerable<TestCaseData> TestCases {
			get {
				var exps = new BitLearningExperimentGroupingWithId[] {
                    new JavaScriptComplexStatementExperiment(),
                    new JavaScriptSuperComplexBranchExperiment(),
                    new JavaScriptComplexBranchExperiment(),
                    new JavaScriptIfExperiment(),
                    new JavaScriptWhileExperiment(),
                    new JavaScriptDoWhileExperiment(),
                    new JavaScriptForExperiment(),
                    new JavaScriptConsoleLogExperiment(),
                    new JavaScriptStatementExperiment(),
                    new JavaScriptBlockExperiment(),
                    new JavaScriptLabeledStatementExperiment(),
                    new JavaScriptEmptyStatementExperiment(),
				};
				const string langName = "JavaScript";
				var learningSets = new[] {
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "bootstrap"),
							new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "browser-sync"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "cheet.js"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "clmtrackr"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "countUp.js"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "fit.js"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "gulp"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "ionic"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "jQuery-File-Upload"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            Fixture.GetInputProjectPath(langName, "my-mind"),
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
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
			var allPaths = Directory.GetFiles(projectPath, "*.js", SearchOption.AllDirectories)
					.ToList();
			exp.AutomaticallyLearnUntilBeStable(allPaths, seedPaths, _writer, projectPath);
			exp.Clear();
			Assert.That(exp.WrongCount, Is.EqualTo(0));
		}
	}

	public class JavaScriptSuperComplexBranchExperiment : BitLearningExperimentGroupingWithId {
		public JavaScriptSuperComplexBranchExperiment() : base("expression") {}

		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var parentName = e.Parent.SafeName();
			if (parentName == "ifStatement") {
				return true;
			}
			if (parentName == "whileStatement") {
				return true;
			}
			if (parentName == "doWhileStatement") {
				return true;
			}
			if (parentName == "forStatement"
			    && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
				return true;
			}
			var p = e.SafeParent().SafeParent();
			if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
			    p.Element("arguments").Element("assignmentExpression") == e) {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptComplexBranchExperiment : BitLearningExperimentGroupingWithId {
		public JavaScriptComplexBranchExperiment() : base("expression") {}

		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var parentName = e.Parent.SafeName();
			if (parentName == "ifStatement") {
				return true;
			}
			if (parentName == "whileStatement") {
				return true;
			}
			if (parentName == "doWhileStatement") {
				return true;
			}
			if (parentName == "forStatement"
			    && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptIfExperiment : BitLearningExperimentGroupingWithId {
		public JavaScriptIfExperiment() : base("expression") {}

		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var parentName = e.Parent.SafeName();
			if (parentName == "ifStatement") {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptWhileExperiment : BitLearningExperimentGroupingWithId {
		public JavaScriptWhileExperiment() : base("expression") {}

		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var parentName = e.Parent.SafeName();
			if (parentName == "whileStatement") {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptDoWhileExperiment : BitLearningExperimentGroupingWithId {
		public JavaScriptDoWhileExperiment() : base("expression") {}

		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var parentName = e.Parent.SafeName();
			if (parentName == "doWhileStatement") {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptForExperiment : BitLearningExperimentGroupingWithId {
		public JavaScriptForExperiment() : base("expression") {}

		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var parentName = e.Parent.SafeName();
			if (parentName == "forStatement"
			    && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptConsoleLogExperiment : BitLearningExperimentGroupingWithId {
		public JavaScriptConsoleLogExperiment() : base("assignmentExpression") {}

		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var p = e.SafeParent().SafeParent();
			if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
			    p.Element("arguments").Element("assignmentExpression") == e) {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaScriptStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return true;
		}
	}

	public class JavaScriptComplexStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaScriptComplexStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.Name == "statementBlock") {
				return false;
			}
			if (e.FirstChild.Name == "labelledStatement") {
				return false;
			}
			if (e.FirstChild.Name == "emptyStatement") {
				return false;
			}
			return true;
		}
	}

	public class JavaScriptBlockExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaScriptBlockExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.Name == "statementBlock") {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptLabeledStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaScriptLabeledStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.Name == "labelledStatement") {
				return true;
			}
			return false;
		}
	}

	public class JavaScriptEmptyStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return JavaScriptExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public JavaScriptEmptyStatementExperiment() : base("statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.Name == "emptyStatement") {
				return true;
			}
			return false;
		}
	}
}