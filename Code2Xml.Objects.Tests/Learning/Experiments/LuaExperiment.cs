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
	public class LuaExperiment {
		private readonly StreamWriter _writer = File.CreateText(@"C:\Users\exKAZUu\Desktop\lua.txt");

		public static CstGenerator Generator = CstGenerators.LuaUsingAntlr3;

		//new MemoryCacheProcessor(new FileCacheProcessor(ProcessorLoader.LuaUsingAntlr3));

		private static IEnumerable<TestCaseData> TestCases {
			get {
				var exps = new BitLearningExperimentGroupingWithId[] {
					new LuaComplexStatementExperiment(),
					new LuaSuperComplexBranchExperiment(),
					new LuaComplexBranchExperiment(),
					new LuaStatementExperiment(),
					new LuaIfExperiment(),
					new LuaWhileExperiment(),
					new LuaDoWhileExperiment(),
					new LuaPrintExperiment(),
					new LuaStatementExperiment(),
					new LuaLabeledStatementExperiment(),
					new LuaEmptyStatementExperiment(),
				};
				const string langName = "Lua";
				var learningSets = new[] {
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "gin"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "koreader"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "lapis"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "luafun"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "luakit"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "middleclass"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "pacpac"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "Penlight"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "Tir"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
					Tuple.Create(
							Fixture.GetInputProjectPath(langName, "vlsub"),
							new List<string> { Fixture.GetInputCodePath(langName, "Seed.Lua"), }),
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
			var allPaths = Directory.GetFiles(projectPath, "*.lua", SearchOption.AllDirectories)
					.ToList();
			exp.AutomaticallyLearnUntilBeStable(allPaths, seedPaths, _writer, projectPath);
			//if (exp.WrongCount > 0) {
			//	Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
			//	foreach (var we in exp.WronglyAcceptedElements) {
			//		var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
			//		Console.WriteLine(we.Text());
			//		Console.WriteLine(e.Text());
			//		Console.WriteLine("---------------------------------------------");
			//	}
			//	Console.WriteLine("---- WronglyRejectedElements ----");
			//	foreach (var we in exp.WronglyRejectedElements) {
			//		var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
			//		Console.WriteLine(we.Text());
			//		Console.WriteLine(e.Text());
			//		Console.WriteLine("---------------------------------------------");
			//	}
			//}
			exp.Clear();
			Assert.That(exp.WrongCount, Is.EqualTo(0));
		}

		[Test, TestCaseSource("TestCases")]
		public void CheckLearnable(
				BitLearningExperimentGroupingWithId exp, string projectPath, IList<string> seedPaths) {
			var allPaths = Directory.GetFiles(projectPath, "*.lua", SearchOption.AllDirectories)
					.ToList();
			//exp.CheckLearnable(allPaths, seedPaths);
		}
	}

	public class LuaComplexBranchExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public LuaComplexBranchExperiment() : base("exp") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var siblings = e.Siblings().ToList();
			var parent = e.Parent;
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
				return true;
			}
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
				return true;
			}
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
				return true;
			}
			return false;
		}
	}

	public class LuaSuperComplexBranchExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public LuaSuperComplexBranchExperiment() : base("exp") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var siblings = e.Siblings().ToList();
			var parent = e.Parent;
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
				return true;
			}
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
				return true;
			}
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
				return true;
			}
			var pppp = e.SafeParent().SafeParent().SafeParent().SafeParent();
			if (pppp.SafeName() == "functioncall" && pppp.FirstChild.TokenText == "print") {
				return true;
			}
			return false;
		}
	}

	public class LuaIfExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public LuaIfExperiment() : base("exp") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var siblings = e.Siblings().ToList();
			var parent = e.Parent;
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "if") {
				return true;
			}
			return false;
		}
	}

	public class LuaWhileExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public LuaWhileExperiment() : base("exp") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var siblings = e.Siblings().ToList();
			var parent = e.Parent;
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "while") {
				return true;
			}
			return false;
		}
	}

	public class LuaDoWhileExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public LuaDoWhileExperiment() : base("exp") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var siblings = e.Siblings().ToList();
			var parent = e.Parent;
			if (parent.SafeName() == "stat" && siblings[0].TokenText == "repeat") {
				return true;
			}
			return false;
		}
	}

	public class LuaPrintExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return false; }
		}

		public LuaPrintExperiment() : base("exp") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			var pppp = e.SafeParent().SafeParent().SafeParent().SafeParent();
			if (pppp.SafeName() == "functioncall" && pppp.FirstChild.TokenText == "print") {
				return true;
			}
			return false;
		}
	}

	public class LuaComplexStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public LuaComplexStatementExperiment() : base("stat") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.Name == "label") {
				return false;
			}
			if (e.FirstChild.TokenText == ";") {
				return false;
			}
			return true;
		}
	}

	public class LuaStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public LuaStatementExperiment() : base("stat") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return true;
		}
	}

	public class LuaLabeledStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public LuaLabeledStatementExperiment() : base("stat") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.Name == "label") {
				return true;
			}
			return false;
		}
	}

	public class LuaEmptyStatementExperiment : BitLearningExperimentGroupingWithId {
		protected override CstGenerator Generator {
			get { return LuaExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public LuaEmptyStatementExperiment() : base("stat") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			if (e.FirstChild.TokenText == ";") {
				return true;
			}
			return false;
		}
	}
}