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
                @"C:\Users\exKAZUu\Desktop\java.txt");

        public static CstGenerator Generator = CstGenerators.JavaUsingAntlr3;

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new JavaComplexStatementExperiment(),
                    new JavaSuperComplexBranchExperiment(),
                    new JavaComplexBranchExperiment(),
                    new JavaIfExperiment(),
                    new JavaWhileExperiment(),
                    new JavaDoWhileExperiment(),
                    new JavaForExperiment(),
                    new JavaPreconditionsExperiment(),
                    new JavaStatementExperiment(),
                    new JavaBlockExperiment(),
                    new JavaLabeledStatementExperiment(),
                    new JavaEmptyStatementExperiment(),
                };
                const string langName = "Java";
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/Findwise/Hydra.git",
                            @"5c781845a466f99645eac9fa27fb27aceb88a442",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/Netflix/RxJava.git",
                            @"bd87341aecb408b2a0acc3f7a42dc118be006b1d",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/derekbrameyer/android-betterpickers.git",
                            @"5646215424ad779f1f780254101b75221675b76b",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/path/android-priority-jobqueue.git",
                            @"d3b33d9ae94df76ffde1f4b9735c0f7cc6463384",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/elasticsearch/elasticsearch.git",
                            @"2f32908193f3f61139da054f0ee5a949f8c589dc",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://code.google.com/p/pageobjectgenerator/",
                            @"169bdaf6a5a08fab62e167764e7f8401309d7b64",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/facebook/presto.git",
                            @"78045f8ede1f1e3deb4e40b880745141480d362f",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/JakeWharton/scalpel.git",
                            @"27338feaa632bc160ae4f27f001474f0850310ea",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/nathanmarz/storm.git",
                            @"66a397368a98834095b47db2b706420901c52ba3",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
                    Tuple.Create(
                            @"https://github.com/JakeWharton/u2020.git",
                            @"a08a7ec51e01cc40aa27779dca52277e69d156f7",
                            new List<string> { Fixture.GetInputCodePath(langName, "Seed.java"), }),
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
}