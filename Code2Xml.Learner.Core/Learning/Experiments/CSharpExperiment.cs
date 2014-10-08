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
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Learner.Core.Learning.Experiments {
    [TestFixture]
    public class CSharpExperiment : Experiment {
        public static CstGenerator Generator = CstGenerators.CSharpUsingAntlr3;
        private const string LangName = "CSharp";

        private static readonly Tuple<string, string>[] LearningSets = {
            Tuple.Create(
                    @"https://github.com/hbons/SparkleShare.git",
                    @"bc69e1d80ffd36b2b5dc36286f491bb38951f238"),
            Tuple.Create(
                    @"https://github.com/restsharp/RestSharp.git",
                    @"70be25dae0edb44a1c962aee078e9dbf74cb4177"),
            Tuple.Create(
                    @"https://github.com/SamSaffron/dapper-dot-net.git",
                    @"885a8d46cbd67f09bd6a5e686a824759d79d5f78"),
            Tuple.Create(
                    @"https://github.com/ninject/ninject.git",
                    @"f2a558f58e1492226614392acf10cea72130c437"),
            Tuple.Create(
                    @"https://github.com/reactiveui/ReactiveUI.git",
                    @"45aaa51f5d5202a5c8d34ea3151955f0bce8a956"),
            Tuple.Create(
                    @"https://github.com/icsharpcode/ILSpy.git",
                    @"056dfa1194fe01562dd8ad6908ed9cdff882618e"),
            Tuple.Create(
                    @"https://github.com/markrendle/Simple.Data.git",
                    @"65ff01e482ce71190869001c221caa140feb70e5"),
            Tuple.Create(
                    @"https://github.com/JamesNK/Newtonsoft.Json.git",
                    @"9e2581be74585605b4f49e0110d65c85c17cb323"),
            Tuple.Create(
                    @"https://github.com/scriptcs/scriptcs.git",
                    @"fce68ff79b412c9acbadc8669614db498418abf5"),
            Tuple.Create(
                    @"https://github.com/MahApps/MahApps.Metro.git",
                    @"36fe5e517e0c65116d288fdabf2e68a2a9494bd9"),
            Tuple.Create(
                    @"https://github.com/mongodb/mongo-csharp-driver.git",
                    @"3f7996e297ba8756025c709979467982839c3277"),
            Tuple.Create(
                    @"https://github.com/Squirrel/Squirrel.Windows.git",
                    @"04a44954ffd416397c6b9156a837a155efe9bb49"),
            Tuple.Create(
                    @"https://github.com/sq/JSIL.git",
                    @"a1c58ec111a107e2d670d4a0548fcfc1f3460394"),
            Tuple.Create(
                    @"https://github.com/Glimpse/Glimpse.git",
                    @"b78f1c8b336e86278efea95c115f8a9a404ab901"),
            Tuple.Create(
                    @"https://github.com/machine/machine.specifications.git",
                    @"85a0d917cc64abf3699a3bafd92a5ba6d4e4161a"),
            Tuple.Create(
                    @"https://github.com/NLog/NLog.git",
                    @"2c609e48a5f3ea26786b2d66c9112e269e3ac536"),
            Tuple.Create(
                    @"https://github.com/jacksonh/manos.git",
                    @"300450cd5c8a146cdf5e9cbaa837ecccfd8ab951"),
            Tuple.Create(
                    @"https://github.com/migueldeicaza/MonoTouch.Dialog.git",
                    @"6dfe7f61ea40486310c68fd12f2988d6d242f7f7"),
            Tuple.Create(
                    @"https://github.com/oddgames/UIToolkit.git",
                    @"b60aa4b1523d6a6fef33c11fdaad00364e9bb9a0"),
            Tuple.Create(
                    @"https://github.com/atheken/NoRM.git",
                    @"f73ee334145e7e5e94f0b78e6b27cda56ae2fdc6"),
            Tuple.Create(
                    @"https://github.com/mccalltd/AttributeRouting.git",
                    @"028202b2f72d5fb139e6d9970430e077f421efc2"),
            Tuple.Create(
                    @"https://github.com/JeremySkinner/FluentValidation.git",
                    @"7803000a4c709347b862ac5b8d500c175dfc460a"),
            Tuple.Create(
                    @"https://github.com/mikehadlow/EasyNetQ.git",
                    @"74a5178fd9d85f316c34f5f2c13fe2e4bb0107d8"),
            Tuple.Create(
                    @"https://github.com/JoshClose/CsvHelper.git",
                    @"b5d0563510bafcf1cbba7ed3423d6b9d19349a46"),
            Tuple.Create(
                    @"https://github.com/timheuer/callisto.git",
                    @"fb9cbac2ccc7900cecf69f722045ca881dbddba3"),
            Tuple.Create(
                    @"https://github.com/thinktecture/Thinktecture.IdentityModel.45.git",
                    @"a2fed40e655beac76f54f11dde1c3b907079a4d1"),
            Tuple.Create(
                    @"https://github.com/Lokad/lokad-cqrs.git",
                    @"75e16de6103c3a6fd9d59846ccea6eeb88185dca"),
            Tuple.Create(
                    @"https://github.com/AutoFixture/AutoFixture.git",
                    @"f945ef7e65477f23f89e96d3a6302b7a96d0cf37"),
            Tuple.Create(
                    @"https://github.com/maartenba/MvcSiteMapProvider.git",
                    @"92ad5eb87a16597c2b18cbb6daf56a4491a652c9"),
            Tuple.Create(
                    @"https://github.com/mono/monotorrent.git",
                    @"3c201b9e3c68b33243a7af61678fb948a0189461"),
            Tuple.Create(
                    @"https://github.com/robconery/biggy.git",
                    @"0c7a0cb8f08b0ac7e5d87f91c5617d4cc6e21b84"),
            Tuple.Create(
                    @"https://github.com/jdiamond/Nustache.git",
                    @"957a95f26265876a42dcd8934708bab95d01ef87"),
            Tuple.Create(
                    @"https://github.com/danielcrenna/metrics-net.git",
                    @"4b4b5dd49eedd387ac0b2423be402ce6e20a4d87"),
            Tuple.Create(
                    @"https://github.com/Code52/pretzel.git",
                    @"90b1739e9d1fbe397e9ff20ca5f2d1526d5d5c61"),
            Tuple.Create(
                    @"https://github.com/chucknorris/roundhouse.git",
                    @"812f4debbb0f31896af08e9ef1dd0b47f1686882"),
            Tuple.Create(
                    @"https://github.com/enyim/EnyimMemcached.git",
                    @"62d1cbfc397fca400feeed68ff91844d2874624c"),
            Tuple.Create(
                    @"https://github.com/zeromq/clrzmq.git",
                    @"76404a94e0a0bbb0aff23e5500eb5af0a70bda05"),
            Tuple.Create(
                    @"https://github.com/0xd4d/de4dot.git",
                    @"7222bdbe426f4296c93517551022efc82cd5b9cd"),
            Tuple.Create(
                    @"https://github.com/David20321/FTJ.git",
                    @"802f54b31eebd3831ee9a7732146f9859d1074e5"),
            Tuple.Create(
                    @"https://github.com/grumpydev/TinyIoC.git",
                    @"fda59bd5cb53864835ff8b025e31ef10a7a77f68"),
            Tuple.Create(
                    @"https://github.com/ServiceStack/ServiceStack.Examples.git",
                    @"8eafa0b5bc45976e1cdbe54240df0a5b90f124e5"),
            Tuple.Create(
                    @"https://github.com/thedillonb/CodeHub.git",
                    @"a6272d13f4db89f99e9ce6afb7f88a1f987a969c"),
            Tuple.Create(
                    @"https://github.com/real-logic/simple-binary-encoding.git",
                    @"0741472eaf8cec63d2f41e6d97c3cc9952941874"),
            Tuple.Create(
                    @"https://github.com/danielcrenna/hammock.git",
                    @"2f2ace45511d0571ecea2202fc90d339853862cf"),
            Tuple.Create(
                    @"https://github.com/jsonfx/jsonfx.git",
                    @"bebad51d6c61188dd348b5951716b863aa6a91cc"),
            Tuple.Create(
                    @"https://github.com/mwrock/RequestReduce.git",
                    @"fe4f794336e7d347afcf92ab02557750157f198d"),
            Tuple.Create(
                    @"https://github.com/SimpleAuthentication/SimpleAuthentication.git",
                    @"1e1e29ad0795f608bd6620e9e4ee2aa23ac53b1a"),
            Tuple.Create(
                    @"https://github.com/erik-kallen/SaltarelleCompiler.git",
                    @"d13bccaeb825ed2c3709b5cf5f2db668987f9a68"),
            Tuple.Create(
                    @"https://github.com/phatboyg/Stact.git",
                    @"0dc52852ffbbbeac937045269314af089e7e7af7"),
            Tuple.Create(
                    @"https://github.com/filipw/AspNetWebApi-OutputCache.git",
                    @"e03d6b257582dab3575fd8e86e93c421125376f4"),
        };

        private static readonly LearningExperiment[] Experiments = {
            new CSharpComplexStatementExperiment(),
            new CSharpSuperComplexBranchExperiment(),
            new CSharpExpressionStatementExperiment(),
            new CSharpArithmeticOperatorExperiment(),
            new CSharpSwitchCaseExperiment(),
            new CSharpSuperComplexBranchExperimentWithSwitch(),
            new CSharpSuperComplexBranchExperimentWithSwitchWithoutTrue(),
                    
            //new CSharpComplexBranchExperiment(),
            //new CSharpIfExperiment(),
            //new CSharpWhileExperiment(),
            //new CSharpDoWhileExperiment(),
            //new CSharpForExperiment(),
            //new CSharpPreconditionsExperiment(),
            //new CSharpStatementExperiment(),
            //new CSharpBlockExperiment(),
            //new CSharpLabeledStatementExperiment(),
            //new CSharpEmptyStatementExperiment(),
        };

        protected override string SearchPattern {
            get { return "*.cs"; }
        }

        private static IEnumerable<TestCaseData> TestCases {
            get {
                foreach (var exp in Experiments) {
                    foreach (var learningSet in LearningSets.Skip(SkipCount).Take(TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", url + "Clone\r\n");
                        Git.Clone(path, url);
                        Git.Checkout(path, learningSet.Item2);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", "Done\r\n");
                        yield return new TestCaseData(exp, path);
                    }
                }
            }
        }

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.cs"), };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, string sha1, string sha2) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.cs"), };
            Learn(seedPaths, exp, projectPath);
        }
    }

    public class CSharpSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public CSharpSuperComplexBranchExperiment() : base("boolean_expression", "argument") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "expression") {
                e = e.Parent;
            }
            if (e.Name == "argument_value") {
                e = e.Parent;
            }
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
            if (e.Name == "boolean_expression") {
                e = e.FirstChild;
            }

            var p = e.Parent.Parent.Parent.Parent.Parent;
            var parts = p.Elements("primary_expression_start")
                    .Concat(p.Elements("primary_expression_part"))
                    .ToList();
            if (parts.All(
                    e2 => e2.Descendants("identifier")
                            .FirstOrDefault().SafeTokenText() != "Contract")) {
                return false;
            }
            if (parts.All(
                    e2 => e2.Descendants("identifier")
                            .FirstOrDefault().SafeTokenText() != "Requires")) {
                return false;
            }
            return true;
        }
    }

    public class CSharpComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
            get { return true; }
        }

        public CSharpComplexStatementExperiment() : base("statement") {}

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
    }

    public class CSharpStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
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

        public override bool IsInner {
            get { return true; }
        }

        public CSharpExpressionStatementExperiment() : base("expression_statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "statement") {
                e = e.FirstChild;
            }
            if (e.Name == "embedded_statement") {
                e = e.FirstChild;
            }
            return e.Name == "expression_statement";
        }
    }

    public class CSharpArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public CSharpArithmeticOperatorExperiment() : base("TOKENS", "MINUS") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return ((e.TokenText == "*" || e.TokenText == "/")
                    && e.Parent.Name == "multiplicative_expression") ||
                   ((e.TokenText == "+" || e.TokenText == "-")
                    && e.Parent.Name == "additive_expression");
        }
    }

    public class CSharpSwitchCaseExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public CSharpSwitchCaseExperiment() : base("expression", "switch_label") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var pName = e.Parent.Name;
            if (pName == "switch_statement") {
                return true;
            }
            if (e.Name == "switch_labels") {
                return e.ChildrenCount == 1;
            }
            return e.Name == "switch_label";
        }
    }

    public class CSharpSuperComplexBranchExperimentWithSwitch : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public CSharpSuperComplexBranchExperimentWithSwitch()
                : base("boolean_expression", "argument", "switch_label") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "expression") {
                e = e.Parent;
            }
            if (e.Name == "argument_value") {
                e = e.Parent;
            }
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
            if (e.Parent.Name == "switch_statement") {
                return true;
            }
            if (e.Name == "switch_labels") {
                return e.ChildrenCount == 1;
            }
            if (e.Name == "switch_label") {
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
    }

    public class CSharpSuperComplexBranchExperimentWithSwitchWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return CSharpExperiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public CSharpSuperComplexBranchExperimentWithSwitchWithoutTrue()
                : base("boolean_expression", "argument", "switch_label") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "expression") {
                e = e.Parent;
            }
            if (e.Name == "argument_value") {
                e = e.Parent;
            }
            var pName = e.Parent.Name;
            if (pName == "if_statement") {
                return e.TokenText != "true";
            }
            if (pName == "while_statement") {
                return e.TokenText != "true";
            }
            if (pName == "do_statement") {
                return e.TokenText != "true";
            }
            if (pName == "for_condition") {
                return e.TokenText != "true";
            }
            if (e.Parent.Name == "switch_statement") {
                return true;
            }
            if (e.Name == "switch_labels") {
                return e.ChildrenCount == 1;
            }
            if (e.Name == "switch_label") {
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
            return e.TokenText != "true";
        }
    }
}