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
        private const string LangName = "Java";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new JavaComplexStatementExperiment(),
                    new JavaSuperComplexBranchExperiment(),
                    //new JavaComplexBranchExperiment(),
                    //new JavaIfExperiment(),
                    //new JavaWhileExperiment(),
                    //new JavaDoWhileExperiment(),
                    //new JavaForExperiment(),
                    //new JavaPreconditionsExperiment(),
                    //new JavaStatementExperiment(),
                    //new JavaBlockExperiment(),
                    //new JavaLabeledStatementExperiment(),
                    //new JavaEmptyStatementExperiment(),
                };
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/dropwizard/dropwizard.git",
                            @"4758ac698ff9993879798db338b3314c6a1c6a27"),
                    Tuple.Create(
                            @"https://github.com/JakeWharton/Android-ViewPagerIndicator.git",
                            @"8cd549f23f3d20ff920e19a2345c54983f65e26b"),
                    Tuple.Create(
                            @"https://github.com/facebook/presto.git",
                            @"b4b5d67e09576ec38be1564123e5a0e2d4bc1996"),
                    Tuple.Create(
                            @"https://github.com/facebook/facebook-android-sdk.git",
                            @"118e756568f7e9a8045e87575c190a2c304071a6"),
                    Tuple.Create(
                            @"https://github.com/chrisbanes/ActionBar-PullToRefresh.git",
                            @"65d4183994eaf8c450e81afadb389fca61499063"),
                    Tuple.Create(
                            @"https://github.com/clojure/clojure.git",
                            @"201a0dd9701e1a0ee3998431241388eb4a854ebf"),
                    Tuple.Create(
                            @"https://github.com/dropwizard/metrics.git",
                            @"e61395657d9f471a88dc0d9f3c7f78f0e773fe28"),
                    Tuple.Create(
                            @"https://github.com/nostra13/Android-Universal-Image-Loader.git",
                            @"29811229c3ba3da390b29353875be2c92f88a789"),
                    Tuple.Create(
                            @"https://github.com/cyrilmottier/GreenDroid.git",
                            @"abd9769f677bb4a753f0bf1119f961187bdf7020"),
                    Tuple.Create(
                            @"https://github.com/WhisperSystems/TextSecure.git",
                            @"4d52d2ee364c2edad50420a9afa500dde66a48d9"),
                    Tuple.Create(
                            @"https://github.com/fernandezpablo85/scribe-java.git",
                            @"135ad50a4e4e27e97f09e42ae50d6011c7af7a4b"),
                    Tuple.Create(
                            @"https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition.git",
                            @"5f399a52c8bf5626b098629906f82be1763089f4"),
                    Tuple.Create(
                            @"https://github.com/Bukkit/CraftBukkit.git",
                            @"1ab090e71ea261fe38cef980bc2ebe696a494ea3"),
                    Tuple.Create(
                            @"https://github.com/nicolasgramlich/AndEngine.git",
                            @"720897f99d2c56ba357e8fe361454bd8d88c37ed"),
                    Tuple.Create(
                            @"https://github.com/Prototik/HoloEverywhere.git",
                            @"3b6021aa4af717cd31b1b6c877f6c30b674af6d9"),
                    Tuple.Create(
                            @"https://github.com/LMAX-Exchange/disruptor.git",
                            @"1072645ad75f8b07b9145197fd4137fcfa79011a"),
                    Tuple.Create(
                            @"https://github.com/johannilsson/android-pulltorefresh.git",
                            @"4277c1ecf6256518248a1143b3ee882c703b33d6"),
                    Tuple.Create(
                            @"https://github.com/dropwizard/dropwizard.git",
                            @"4758ac698ff9993879798db338b3314c6a1c6a27"),
                    Tuple.Create(
                            @"https://github.com/facebook/facebook-android-sdk.git",
                            @"118e756568f7e9a8045e87575c190a2c304071a6"),
                    Tuple.Create(
                            @"https://github.com/JakeWharton/Android-ViewPagerIndicator.git",
                            @"8cd549f23f3d20ff920e19a2345c54983f65e26b"),
                    Tuple.Create(
                            @"https://github.com/nostra13/Android-Universal-Image-Loader.git",
                            @"29811229c3ba3da390b29353875be2c92f88a789"),
                    Tuple.Create(
                            @"https://github.com/clojure/clojure.git",
                            @"201a0dd9701e1a0ee3998431241388eb4a854ebf"),
                    Tuple.Create(
                            @"https://github.com/square/picasso.git",
                            @"e0c3d44f53919742a0a608277be26b47742bb2a2"),
                    Tuple.Create(
                            @"https://github.com/facebook/presto.git",
                            @"b4b5d67e09576ec38be1564123e5a0e2d4bc1996"),
                    Tuple.Create(
                            @"https://github.com/WhisperSystems/TextSecure.git",
                            @"4d52d2ee364c2edad50420a9afa500dde66a48d9"),
                    Tuple.Create(
                            @"https://github.com/chrisbanes/ActionBar-PullToRefresh.git",
                            @"65d4183994eaf8c450e81afadb389fca61499063"),
                    Tuple.Create(
                            @"https://github.com/dropwizard/metrics.git",
                            @"e61395657d9f471a88dc0d9f3c7f78f0e773fe28"),
                    Tuple.Create(
                            @"https://github.com/Prototik/HoloEverywhere.git",
                            @"3b6021aa4af717cd31b1b6c877f6c30b674af6d9"),
                    Tuple.Create(
                            @"https://github.com/Bukkit/CraftBukkit.git",
                            @"1ab090e71ea261fe38cef980bc2ebe696a494ea3"),
                    Tuple.Create(
                            @"https://github.com/cyrilmottier/GreenDroid.git",
                            @"abd9769f677bb4a753f0bf1119f961187bdf7020"),
                    Tuple.Create(
                            @"https://github.com/nicolasgramlich/AndEngine.git",
                            @"720897f99d2c56ba357e8fe361454bd8d88c37ed"),
                    Tuple.Create(
                            @"https://github.com/fernandezpablo85/scribe-java.git",
                            @"135ad50a4e4e27e97f09e42ae50d6011c7af7a4b"),
                    Tuple.Create(
                            @"https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition.git",
                            @"5f399a52c8bf5626b098629906f82be1763089f4"),
                    Tuple.Create(
                            @"https://github.com/LMAX-Exchange/disruptor.git",
                            @"1072645ad75f8b07b9145197fd4137fcfa79011a"),
                    Tuple.Create(
                            @"https://github.com/johannilsson/android-pulltorefresh.git",
                            @"4277c1ecf6256518248a1143b3ee882c703b33d6"),
                    Tuple.Create(
                            @"https://github.com/SimonVT/android-menudrawer.git",
                            @"1260f2f6d50d3b572ebfa98e93a0b4f8258371de"),
                    Tuple.Create(
                            @"https://github.com/square/retrofit.git",
                            @"1f7cc4942f71d6c6cf4770fcd93670bc93a8c710"),
                    Tuple.Create(
                            @"https://github.com/robovm/robovm.git",
                            @"a72f06e62dbe4afd3271fb3bfa4ca2c4d47d3329"),
                    Tuple.Create(
                            @"https://github.com/jfeinstein10/SlidingMenu.git",
                            @"4254feca3ece9397cd501921ee733f19ea0fdad8"),
                    Tuple.Create(
                            @"https://github.com/junit-team/junit.git",
                            @"e65558c174a8f5c4c7758f0d9dd1ffe027b023d8"),
                    Tuple.Create(
                            @"https://github.com/github/android.git",
                            @"9d490829b944d3a2c77dbd0010ec7a0bfe2efaee"),
                    Tuple.Create(
                            @"https://github.com/AndroidBootstrap/android-bootstrap.git",
                            @"e43e3ac4a5984edf9a6ccc87bac04be177a3615a"),
                    Tuple.Create(
                            @"https://github.com/JakeWharton/ActionBarSherlock.git",
                            @"4a79d536af872339899a90d6dc743aa57745474b"),
                    Tuple.Create(
                            @"https://github.com/loopj/android-async-http.git",
                            @"6077c6aa7bf06b2b8c13fbb4355e094dea436b7c"),
                    Tuple.Create(
                            @"https://github.com/sparklemotion/nokogiri.git",
                            @"163103b0eaf904575e62909eddc00dcc9e425a2a"),
                    Tuple.Create(
                            @"https://github.com/nathanmarz/storm.git",
                            @"cdb116e942666973bc4eaa0df098d5bab82739e7"),
                    Tuple.Create(
                            @"https://github.com/netty/netty.git",
                            @"8615f7a69ecbbabd6d8f7ba8cae90ba63d702fec"),
                };
                foreach (var exp in exps) {
                    foreach (var learningSet in learningSets) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        Git.CloneAndCheckout(path, url, learningSet.Item2);
                        yield return new TestCaseData(exp, path);
                    }
                }
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.java"), };
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