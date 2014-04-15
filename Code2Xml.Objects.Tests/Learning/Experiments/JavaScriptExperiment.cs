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
                var exps = new LearningExperiment[] {
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
                            @"https://github.com/angular-ui/bootstrap.git",
                            @"94a7f5934ac114626e386a46619e19a43f918bf2",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/shakyShane/browser-sync.git",
                            @"e56b9314ba6f6ed45eaa2f378d5391b98c3bf239",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/namuol/cheet.js.git",
                            @"25f9e09245ad615d52e5e56f906bf2f011db51e9",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/auduno/clmtrackr.git",
                            @"58f852aa8e796488fd7ebe3791f87eede7d34c6d",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/inorganik/countUp.js.git",
                            @"67788e475e2fd26b5ef5bd8b19d9e787cb148b7c",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/soulwire/fit.js.git",
                            @"9ad6d824805cfabba511f044325b219ad9d8c267",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/gulpjs/gulp.git",
                            @"23b2e41c8be1888f4ef79bed05219ac13a359af9",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/driftyco/ionic.git",
                            @"8bc870e494469785aaec934878a4ee631596a06f",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/blueimp/jQuery-File-Upload.git",
                            @"d87b2494a4157b8aea309fe3eeab862d5cd9e6d5",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
                    Tuple.Create(
                            @"https://github.com/ondras/my-mind.git",
                            @"47215ceec70ba7c529012e2aa63ea5f2acbe321d",
                            new List<string> { Fixture.GetInputCodePath(langName, "seed.js"), }),
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
            var allPaths = Directory.GetFiles(projectPath, "*.js", SearchOption.AllDirectories)
                    .ToList();
            exp.AutomaticallyLearnUntilBeStable(allPaths, seedPaths, _writer, projectPath);
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
        }
    }

    public class JavaScriptSuperComplexBranchExperiment : LearningExperiment {
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

    public class JavaScriptComplexBranchExperiment : LearningExperiment {
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

    public class JavaScriptIfExperiment : LearningExperiment {
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

    public class JavaScriptWhileExperiment : LearningExperiment {
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

    public class JavaScriptDoWhileExperiment : LearningExperiment {
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

    public class JavaScriptForExperiment : LearningExperiment {
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

    public class JavaScriptConsoleLogExperiment : LearningExperiment {
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

    public class JavaScriptStatementExperiment : LearningExperiment {
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

    public class JavaScriptComplexStatementExperiment : LearningExperiment {
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

    public class JavaScriptBlockExperiment : LearningExperiment {
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

    public class JavaScriptLabeledStatementExperiment : LearningExperiment {
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

    public class JavaScriptEmptyStatementExperiment : LearningExperiment {
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