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

        //new MemoryCacheCstGenerator(new FileCacheCstGenerator(ProcessorLoader.PhpUsingAntlr3));

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new PhpComplexStatementExperiment(),
                    new PhpSuperComplexBranchExperiment(),
                    new PhpComplexBranchExperiment(),
                    new PhpIfExperiment(),
                    new PhpWhileExperiment(),
                    new PhpDoWhileExperiment(),
                    new PhpForExperiment(),
                    new PhpEchoExperiment(),
                    new PhpStatementExperiment(),
                    new PhpBlockExperiment(),
                    new PhpLabeledStatementExperiment(),
                    new PhpEmptyStatementExperiment(),
                };
                const string langName = "Php";
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/roots/bedrock.git",
                            @"513a3cff64b29be7a4d08ffdfa9728c55a30b68a",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/aheinze/cockpit.git",
                            @"3b65c826559d45833078a1e1f196773495fdd47f",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/pborreli/composer-service.git",
                            @"38c12f002cfad65e32510f80778a645ddfa03c48",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/mikecao/flight.git",
                            @"2776d542286c1abd0e91b3892dd02029085c1ba8",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/thephpleague/flysystem.git",
                            @"4fb166cbba5b6614d67ee2b361afed6e0901dc9c",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/cordoval/gush.git",
                            @"37576d4211e7d23dbe5a7e6477ede4be4ded047b",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/laravel/laravel.git",
                            @"aeda6b13cdfcd662089c30d428839965c7443ab9",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/panique/php-mvc.git",
                            @"319eaa8c845569592c3fbefdd15003848e49226e",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/vlucas/phpdotenv.git",
                            @"8efa54e839f569422d5891b69495ebeaeee5e7ca",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
                    Tuple.Create(
                            @"https://github.com/al3x/sovereign.git",
                            @"5853ee92615b67a4f4bd802ff7493cb684294a79",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.php"), }),
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
        public void Test(
                LearningExperiment exp, string projectPath, IList<string> seedPaths) {
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
			get { return true; }
		}

		public PhpArithmeticOperatorExperiment() : base("Plus", "Minus", "Asterisk", "Forwardslash") {}

		protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
			return e.Parent.Name == "addition" ||
			       e.Parent.Name == "multiplication";
		}
	}
}