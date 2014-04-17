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
                var exps = new LearningExperiment[] {
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
                            @"https://github.com/MuMech/MechJeb2.git",
                            @"2837dbac38f59520ff840c479a242228c88ab485",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    //Tuple.Create(
                    //        @"https://github.com/MediaPortal/MediaPortal-1.git",
                    //        @"bb1af6b26eb596ba953c9a2d307313840f43f93f",
                    //        new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/migueldeicaza/MonoTouch.Dialog.git",
                            @"921612a37a282d2d32512e2d94465d0ed845f457",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/NancyFx/Nancy.git",
                            @"333096e9d4b50e715260acf6e7fd73ebd63def69",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/JamesNK/Newtonsoft.Json.git",
                            @"fdb2811bae10dd285a155e07cb8ea1c2e7683a3a",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/NuGet/NuGetGallery.git",
                            @"50ec4075f82d0dde0dcb9b94f991185c39e13326",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/ServiceStack/ServiceStack.git",
                            @"2c14c23396996115d8120042168c6282a8b1a3c7",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/SignalR/SignalR.git",
                            @"2f6649e9b6c645daed59eae7e893b0d0dcd9840d",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/AvilanceLtd/StarryboundServer.git",
                            @"2a89b59f28959257aceba1b542b7b1d6b41e2b0b",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/Moq/moq4.git",
                            @"3c3eab9d2f10357b3ee1655984d1eea0d3010a0b",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
                    Tuple.Create(
                            @"https://github.com/ravendb/ravendb.git",
                            @"cd5e3234276082bef217dd87e69eaaca0078dc46",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.cs"), }),
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

        //[Test, TestCaseSource("TestCases")]
        public void Test(
                LearningExperiment exp, string projectPath, IList<string> seedPaths) {
            var allPaths = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories)
                    .ToList();
            exp.Learn(allPaths, seedPaths, _writer, projectPath);
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
        }
    }

    public class CSharpSuperComplexBranchExperiment : LearningExperiment {
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
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().TokenText
                                    != "Contract")) {
                return false;
            }
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().TokenText
                                    != "Requires")) {
                return false;
            }
            return true;
        }
    }

    public class CSharpComplexBranchExperiment : LearningExperiment {
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

    public class CSharpIfExperiment : LearningExperiment {
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

    public class CSharpWhileExperiment : LearningExperiment {
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

    public class CSharpDoWhileExperiment : LearningExperiment {
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

    public class CSharpForExperiment : LearningExperiment {
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

    public class CSharpPreconditionsExperiment : LearningExperiment {
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
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().SafeTokenText()
                                    != "Contract")) {
                return false;
            }
            if (
                    parts.All(
                            e2 =>
                                    e2.Descendants("identifier").FirstOrDefault().SafeTokenText()
                                    != "Requires")) {
                return false;
            }
            return true;
        }

        public CSharpPreconditionsExperiment() : base("argument") {}
    }

    public class CSharpComplexStatementExperiment : LearningExperiment {
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

    public class CSharpStatementExperiment : LearningExperiment {
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

    public class CSharpBlockExperiment : LearningExperiment {
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

    public class CSharpLabeledStatementExperiment : LearningExperiment {
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

    public class CSharpEmptyStatementExperiment : LearningExperiment {
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

	public class CSharpExpressionStatementExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public CSharpExpressionStatementExperiment() : base("expression_statement") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return true;
		}
	}

	public class CSharpArithmeticOperatorExperiment : LearningExperiment {
		protected override CstGenerator Generator {
			get { return CSharpExperiment.Generator; }
		}

		protected override bool IsInner {
			get { return true; }
		}

		public CSharpArithmeticOperatorExperiment() : base("TOKENS", "MINUS") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return ((e.TokenText == "*" || e.TokenText == "/") && e.Parent.Name == "multiplicative_expression") ||
			       ((e.TokenText == "+" || e.TokenText == "-") && e.Parent.Name == "additive_expression");
		}
	}
}