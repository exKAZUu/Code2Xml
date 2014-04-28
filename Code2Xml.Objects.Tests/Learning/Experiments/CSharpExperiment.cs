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
        private readonly StreamWriter _writer = File.CreateText(
                @"C:\Users\exKAZUu\Dropbox\Data\csharp" + JavaExperiment.SkipCount + "_"
                + JavaExperiment.TakeCount + ".csv");

        public static CstGenerator Generator = CstGenerators.CSharpUsingAntlr3;
        private string _lastProjectName;

        private const string LangName = "CSharp";
        //new MemoryCacheCstGenerator(new FileCacheCstGenerator(ProcessorLoader.CSharpUsingAntlr3));

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
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
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/hbons/SparkleShare.git",
                            @"bc69e1d80ffd36b2b5dc36286f491bb38951f238",
                            "9604be2a533c25d8bc1b15f7920620574570ad48"),
                    Tuple.Create(
                            @"https://github.com/restsharp/RestSharp.git",
                            @"70be25dae0edb44a1c962aee078e9dbf74cb4177",
                            "c32b52861aba9f95fdeb67ab6aa88363009345ba"),
                    Tuple.Create(
                            @"https://github.com/SamSaffron/dapper-dot-net.git",
                            @"885a8d46cbd67f09bd6a5e686a824759d79d5f78",
                            "bae5fc70769ff18af246a371a384587f87007248"),
                    Tuple.Create(
                            @"https://github.com/ninject/ninject.git",
                            @"f2a558f58e1492226614392acf10cea72130c437",
                            "f68149d57cb22669e82dabec4017905ca2bb6942"),
                    Tuple.Create(
                            @"https://github.com/reactiveui/ReactiveUI.git",
                            @"45aaa51f5d5202a5c8d34ea3151955f0bce8a956",
                            "4b4e6cd868894d31e6958cfbf5a78f7683bb5b17"),
                    Tuple.Create(
                            @"https://github.com/icsharpcode/ILSpy.git",
                            @"056dfa1194fe01562dd8ad6908ed9cdff882618e",
                            "1c1420a8d2eb1e42203ea6e167fa26a677599bb6"),
                    Tuple.Create(
                            @"https://github.com/markrendle/Simple.Data.git",
                            @"65ff01e482ce71190869001c221caa140feb70e5",
                            "02c3c775c682ea97676e337c49900653d003fb7a"),
                    Tuple.Create(
                            @"https://github.com/JamesNK/Newtonsoft.Json.git",
                            @"9e2581be74585605b4f49e0110d65c85c17cb323",
                            "12a91cce9ee0f3675a8df44a9a204137c0b136b9"),
                    Tuple.Create(
                            @"https://github.com/scriptcs/scriptcs.git",
                            @"fce68ff79b412c9acbadc8669614db498418abf5",
                            "e7d8eb3a7b359891d2813e82329ea7fffe71a7fa"),
                    Tuple.Create(
                            @"https://github.com/MahApps/MahApps.Metro.git",
                            @"36fe5e517e0c65116d288fdabf2e68a2a9494bd9",
                            "8f9775f383bb0fcba58fb0c829001d92f15b6dd7"),
                    Tuple.Create(
                            @"https://github.com/mongodb/mongo-csharp-driver.git",
                            @"3f7996e297ba8756025c709979467982839c3277",
                            "90cadbe7f85814e49159493cea5e3f0d9d447edd"),
                    Tuple.Create(
                            @"https://github.com/Squirrel/Squirrel.Windows.git",
                            @"04a44954ffd416397c6b9156a837a155efe9bb49",
                            "58dc4d55021c7aa3550c090937cff6f5f90c553e"),
                    Tuple.Create(
                            @"https://github.com/sq/JSIL.git",
                            @"a1c58ec111a107e2d670d4a0548fcfc1f3460394",
                            "eb163bf0e51790f1dcfbbb3fd37232f61f4043e1"),
                    Tuple.Create(
                            @"https://github.com/Glimpse/Glimpse.git",
                            @"b78f1c8b336e86278efea95c115f8a9a404ab901",
                            "e4d605f2dd2a85a4386d7dffafa2b48aeac66f7a"),
                    Tuple.Create(
                            @"https://github.com/machine/machine.specifications.git",
                            @"85a0d917cc64abf3699a3bafd92a5ba6d4e4161a",
                            "5b05b08b1916747fc431d2476d2c5a249d4269a9"),
                    Tuple.Create(
                            @"https://github.com/NLog/NLog.git",
                            @"2c609e48a5f3ea26786b2d66c9112e269e3ac536",
                            "3d3328800ba45eecdbab1c4095d68562e08b9e9f"),
                    Tuple.Create(
                            @"https://github.com/jacksonh/manos.git",
                            @"300450cd5c8a146cdf5e9cbaa837ecccfd8ab951",
                            "f981f1fc0ffe1db66b55f5458a4023c70d025ebb"),
                    Tuple.Create(
                            @"https://github.com/migueldeicaza/MonoTouch.Dialog.git",
                            @"6dfe7f61ea40486310c68fd12f2988d6d242f7f7",
                            "8a62aa867bcbc5f73775ad487ca4a61ff54f28e8"),
                    Tuple.Create(
                            @"https://github.com/oddgames/UIToolkit.git",
                            @"b60aa4b1523d6a6fef33c11fdaad00364e9bb9a0",
                            "ccf0b4ce70ad53abc6193aeb667785548ab18cb0"),
                    Tuple.Create(
                            @"https://github.com/atheken/NoRM.git",
                            @"f73ee334145e7e5e94f0b78e6b27cda56ae2fdc6",
                            "7be00fbe4d4b00bf6a4cde9baa0cf2059fb9174c"),
                    Tuple.Create(
                            @"https://github.com/mccalltd/AttributeRouting.git",
                            @"028202b2f72d5fb139e6d9970430e077f421efc2",
                            "b3e28079e4c65252f993e59515399625a13700a5"),
                    Tuple.Create(
                            @"https://github.com/JeremySkinner/FluentValidation.git",
                            @"7803000a4c709347b862ac5b8d500c175dfc460a",
                            "b8efec522180bcb9ea7c1c3ea9839e06c3e69ea9"),
                    Tuple.Create(
                            @"https://github.com/mikehadlow/EasyNetQ.git",
                            @"74a5178fd9d85f316c34f5f2c13fe2e4bb0107d8",
                            "e57c823a20e6244eea82a7096a9dc0187120c1ec"),
                    Tuple.Create(
                            @"https://github.com/JoshClose/CsvHelper.git",
                            @"b5d0563510bafcf1cbba7ed3423d6b9d19349a46",
                            "873184b5c25fc7aedce557c98ebadd09e4cd4303"),
                    Tuple.Create(
                            @"https://github.com/timheuer/callisto.git",
                            @"fb9cbac2ccc7900cecf69f722045ca881dbddba3",
                            "813e0efe4f5b7e7be182294aa63d893d36afd875"),
                    Tuple.Create(
                            @"https://github.com/thinktecture/Thinktecture.IdentityModel.45.git",
                            @"a2fed40e655beac76f54f11dde1c3b907079a4d1",
                            "c17058d0714bd4a338a777a567ef963e40b18a3a"),
                    Tuple.Create(
                            @"https://github.com/Lokad/lokad-cqrs.git",
                            @"75e16de6103c3a6fd9d59846ccea6eeb88185dca",
                            "1d755c1fa1798c0c5ce280ddfb6137bb0a5dd053"),
                    Tuple.Create(
                            @"https://github.com/AutoFixture/AutoFixture.git",
                            @"f945ef7e65477f23f89e96d3a6302b7a96d0cf37",
                            "47e026989af3abe17abc88f8c086fd3c1112724b"),
                    Tuple.Create(
                            @"https://github.com/maartenba/MvcSiteMapProvider.git",
                            @"92ad5eb87a16597c2b18cbb6daf56a4491a652c9",
                            "795d03c4bba45e1132d76fbd273511cdf3d9e186"),
                    Tuple.Create(
                            @"https://github.com/mono/monotorrent.git",
                            @"3c201b9e3c68b33243a7af61678fb948a0189461",
                            "568c748c71acef17509f1db1c3109091e36a3a1a"),
                    Tuple.Create(
                            @"https://github.com/robconery/biggy.git",
                            @"0c7a0cb8f08b0ac7e5d87f91c5617d4cc6e21b84",
                            "ec524849568785ea6ebd51b97d75be4e0857baf6"),
                    Tuple.Create(
                            @"https://github.com/jdiamond/Nustache.git",
                            @"957a95f26265876a42dcd8934708bab95d01ef87",
                            "1605af948e2407ed6321f18665965b3cdf322730"),
                    Tuple.Create(
                            @"https://github.com/danielcrenna/metrics-net.git",
                            @"4b4b5dd49eedd387ac0b2423be402ce6e20a4d87",
                            "25ee298f070bf274a6b22fbcf9e5e5275d73aa3f"),
                    Tuple.Create(
                            @"https://github.com/Code52/pretzel.git",
                            @"90b1739e9d1fbe397e9ff20ca5f2d1526d5d5c61",
                            "b3b51e03d9769ea9d1b484e31c421ab6237eac19"),
                    Tuple.Create(
                            @"https://github.com/chucknorris/roundhouse.git",
                            @"812f4debbb0f31896af08e9ef1dd0b47f1686882",
                            "460d008e0e6a07e283032567d270e3f793eb91fd"),
                    Tuple.Create(
                            @"https://github.com/enyim/EnyimMemcached.git",
                            @"62d1cbfc397fca400feeed68ff91844d2874624c",
                            "363e6eedefd3b7753216cc5ff3ddda1149b19fdd"),
                    Tuple.Create(
                            @"https://github.com/zeromq/clrzmq.git",
                            @"76404a94e0a0bbb0aff23e5500eb5af0a70bda05",
                            "25ffb1b7a90fb6bf3817e70a1c02f44a2f8ae22a"),
                    Tuple.Create(
                            @"https://github.com/0xd4d/de4dot.git",
                            @"7222bdbe426f4296c93517551022efc82cd5b9cd",
                            "e5da0a1255178dc30ed821b22e55d8c79b497549"),
                    Tuple.Create(
                            @"https://github.com/David20321/FTJ.git",
                            @"802f54b31eebd3831ee9a7732146f9859d1074e5",
                            "6116133c2b5803c8fcd98018fa265bf0bcc8ef86"),
                    Tuple.Create(
                            @"https://github.com/grumpydev/TinyIoC.git",
                            @"fda59bd5cb53864835ff8b025e31ef10a7a77f68",
                            "3de002c09d2b570436a2074aa42af11875a73517"),
                    Tuple.Create(
                            @"https://github.com/ServiceStack/ServiceStack.Examples.git",
                            @"8eafa0b5bc45976e1cdbe54240df0a5b90f124e5",
                            "d47f08b96f936ae924ba039d088e2f2ebbc8eb63"),
                    Tuple.Create(
                            @"https://github.com/thedillonb/CodeHub.git",
                            @"a6272d13f4db89f99e9ce6afb7f88a1f987a969c",
                            "100e6995041d294ddd112db99dd7a5cad6b16008"),
                    Tuple.Create(
                            @"https://github.com/real-logic/simple-binary-encoding.git",
                            @"0741472eaf8cec63d2f41e6d97c3cc9952941874",
                            "90566bf7181ed452cdb8991f40c560a70871681f"),
                    Tuple.Create(
                            @"https://github.com/danielcrenna/hammock.git",
                            @"2f2ace45511d0571ecea2202fc90d339853862cf",
                            "c7114f8b4f1eefd4a2e25e7d04c623ab8e839c9b"),
                    Tuple.Create(
                            @"https://github.com/jsonfx/jsonfx.git",
                            @"bebad51d6c61188dd348b5951716b863aa6a91cc",
                            "13d4809ee001570310313d0c1ee8e3e45098c86e"),
                    Tuple.Create(
                            @"https://github.com/mwrock/RequestReduce.git",
                            @"fe4f794336e7d347afcf92ab02557750157f198d",
                            "c10c4135b3f668aa67efc9547f1ec2b099b3d7b3"),
                    Tuple.Create(
                            @"https://github.com/SimpleAuthentication/SimpleAuthentication.git",
                            @"1e1e29ad0795f608bd6620e9e4ee2aa23ac53b1a",
                            "8658f971190b28f154a6e86aecee8789814818a7"),
                    Tuple.Create(
                            @"https://github.com/erik-kallen/SaltarelleCompiler.git",
                            @"d13bccaeb825ed2c3709b5cf5f2db668987f9a68",
                            "831c320b6c76ce72349fedb36c7d756c22b42c5b"),
                    Tuple.Create(
                            @"https://github.com/phatboyg/Stact.git",
                            @"0dc52852ffbbbeac937045269314af089e7e7af7",
                            "732fa3f67cae4f74658303a3363c382cfba8a32a"),
                    Tuple.Create(
                            @"https://github.com/filipw/AspNetWebApi-OutputCache.git",
                            @"e03d6b257582dab3575fd8e86e93c421125376f4",
                            "ac5b1e242b351a4cc5632a9fcd3ecbad12917e47"),
                };
                foreach (var exp in exps) {
                    foreach (
                            var learningSet in
                                    learningSets.Skip(JavaExperiment.SkipCount)
                                            .Take(JavaExperiment.TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", url + "Clone\r\n");
                        Git.Clone(path, url);
                        File.AppendAllText(@"C:\Users\exKAZUu\Desktop\Debug.txt", "Done\r\n");
                        yield return
                                new TestCaseData(exp, path, learningSet.Item2, learningSet.Item3);
                    }
                }
            }
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, string sha1, string sha2) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.cs"), };
            if (_lastProjectName != exp.GetType().Name) {
                _writer.WriteLine();
                _writer.Write(Path.GetFileName(projectPath) + ",");
                _lastProjectName = exp.GetType().Name;
            }
            exp.Learn(seedPaths, _writer, projectPath, "*.cs", sha1, sha2);
            _writer.Flush();
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
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