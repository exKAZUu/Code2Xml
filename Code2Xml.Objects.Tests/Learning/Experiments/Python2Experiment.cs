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
    public class Python2Experiment {
        private readonly StreamWriter _writer = File.CreateText(
                @"C:\Users\exKAZUu\Dropbox\Data\py" + JavaExperiment.SkipCount + "_"
                + JavaExperiment.TakeCount + ".csv");

        public static CstGenerator Generator = CstGenerators.Python2;
        private string _lastProjectName;
        private const string LangName = "Python2";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new PythonComplexStatementExperiment(),
                    new PythonSuperComplexBranchExperiment(),
                    new PythonExpressionStatementExperiment(),
                    new PythonArithmeticOperatorExperiment(),
                    new PythonSuperComplexBranchExperimentWithoutTrue(), 
                    //new PythonEmptyStatementExperiment(),
                };
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/django/django.git",
                            @"09af48c70fb5cc652ea109487015472e9ef984df",
                            "fd3ee7d7867dd13a336b90873ccb8df6302f2c05"),
                    Tuple.Create(
                            @"https://github.com/mitsuhiko/flask.git",
                            @"d4b3d16c142e2189c6faf8f784a195e7f827c596",
                            "8a73097fe528430eb77ac26c81ba85229a8af553"),
                    Tuple.Create(
                            @"https://github.com/facebook/tornado.git",
                            @"c5292057a8db3ebec4a80d9c9207bfadff7fa784",
                            "b260c92d17eba13403ec4a40edba8aa12055bc7a"),
                    Tuple.Create(
                            @"https://github.com/jkbr/httpie.git",
                            @"746a1899f319a7c2a60f27bf23cc3762822be1a2",
                            "8905b4fc72e32a76bea9a1117a2f43cc35c96967"),
                    Tuple.Create(
                            @"https://github.com/ansible/ansible.git",
                            @"2cc4ac2e7563e6b73666048c3624bf092f9959e1",
                            "65c8c691f7bfcf3256ae4c0494aa4ae369635ba1"),
                    Tuple.Create(
                            @"https://github.com/reddit/reddit.git",
                            @"b50f91c53149671c4039ff1de4250ac0d5bc89c0",
                            "1f1f0606f5b6bf14a0db55a28cfd03e1e42e3550"),
                    Tuple.Create(
                            @"https://github.com/getsentry/sentry.git",
                            @"94e56e691f4081db7680faf49db5592ec29edd23",
                            "49ee8640281246a73d5adfdb3dc866dad02dbdef"),
                    Tuple.Create(
                            @"https://github.com/rg3/youtube-dl.git",
                            @"2d4c98dbd17676978114b70d59ea15628f886c24",
                            "07ac9e2cc2c269d7eb015d6de5bc6e66981d4e31"),
                    Tuple.Create(
                            @"https://github.com/pagekite/Mailpile.git",
                            @"556c9e16855dea71db23bc2180e4cef1cf2a40ef",
                            "4458882900e3eff81e0b9115d3fa2e6c15cda612"),
                    Tuple.Create(
                            @"https://github.com/apenwarr/sshuttle.git",
                            @"9ce2fa00f94c2f2e5c310abeb1a2907ae7e7a7b0",
                            "7d3028dee23adabd8b92e91c9cdc2cde65934fdd"),
                    Tuple.Create(
                            @"https://github.com/getpelican/pelican.git",
                            @"b11b8a93cd45ad2d16118ce2bffef8bd3128a004",
                            "178d63b154b2b0582b367447eaf34ecb7d5465db"),
                    Tuple.Create(
                            @"https://github.com/fabric/fabric.git",
                            @"b41f7995bcaa5ade335e1dd1e438ae2ca42f4e07",
                            "b2e9fb788162f60c6b408f6802ac8fe9f742836d"),
                    Tuple.Create(
                            @"https://github.com/django/django-old.git",
                            @"ad096059b58afd35b395b01ad4eba36b8ff863de",
                            "7baa52f773afeb34e444788626f5e5d6346c002d"),
                    Tuple.Create(
                            @"https://github.com/webpy/webpy.git",
                            @"73f1119649ffe54ba26ddaf6a612aaf1dab79b7f",
                            "770a14690a02679edc5cf00f89fff8e504b9ee15"),
                    Tuple.Create(
                            @"https://github.com/divio/django-cms.git",
                            @"f884372e0576a384e05c6a8f084eaf089eae25b3",
                            "3c3f83e6d03813350c1b49973ade57db16b5e396"),
                    Tuple.Create(
                            @"https://github.com/midgetspy/Sick-Beard.git",
                            @"a493151582d5779f5656291c9251398623511e7b",
                            "cb275afc1e10024f83ed61a4678d39408789c104"),
                    Tuple.Create(
                            @"https://github.com/Lokaltog/powerline.git",
                            @"c100c90b088c55fe91146eb52dfcbbc7e43039bd",
                            "287a88f473cdd11317fed5cc15f6f6bbf3506465"),
                    Tuple.Create(
                            @"https://github.com/django-debug-toolbar/django-debug-toolbar.git",
                            @"777c8a1cd669bbfde6cfcb8866de4fdf8c0825cf",
                            "5d4fbe175509c73f461c5271a555c952465eeded"),
                    Tuple.Create(
                            @"https://github.com/toastdriven/django-tastypie.git",
                            @"834f728b07ab1a008b281b12a2cab2987f26c99d",
                            "8de91a0deaa87b0df13a151f1964451a30ad0d96"),
                    Tuple.Create(
                            @"https://github.com/andymccurdy/redis-py.git",
                            @"f96e46b971a5bb66ab5f94ba87ab3e092e5f01ac",
                            "def45c6133358a79274815e738e6c4005e10e188"),
                    Tuple.Create(
                            @"https://github.com/clips/pattern.git",
                            @"a9d7f8449c0118e7442b4ffb1c78097c74b468ed",
                            "a53fbdf48c41017609f9f90c81a7f6ec8f167f6e"),
                    Tuple.Create(
                            @"https://github.com/tomchristie/django-rest-framework.git",
                            @"b3b0515ae6325e7de6a582bbb2fd7eeac687c325",
                            "79596dc613bbf24aac7b5c56179cbc5c46eacdf3"),
                    Tuple.Create(
                            @"https://github.com/mitmproxy/mitmproxy.git",
                            @"1dba379ae90593a563acb9dbed6f5e6b721c086a",
                            "2e492b8e94362dbd9380d1d3eb38b5abaa8f137d"),
                    Tuple.Create(
                            @"https://github.com/amoffat/sh.git",
                            @"80af5726d8aa42017ced548abbd39b489068922a",
                            "fd30b7ec4579f3291663f69963bce74c2adf4806"),
                    Tuple.Create(
                            @"https://github.com/joke2k/faker.git",
                            @"7cd01eb89df25ee7e98854b9edd991e008c6f49f",
                            "7e948eb5aeca868d9a35b8663c5992f956aa9738"),
                    Tuple.Create(
                            @"https://github.com/nicolargo/glances.git",
                            @"4177046cdd3be8f2019799490de54a7aab5b0550",
                            "6acba29bad0095704e198a78e79d67b02d474810"),
                    Tuple.Create(
                            @"https://github.com/scrapinghub/portia.git",
                            @"55f97e61fc558d243a0806ae8bf4a26b080026de",
                            "3471337b18e555bcfed55a7acec7ec9026ee5397"),
                    Tuple.Create(
                            @"https://github.com/jorgebastida/glue.git",
                            @"33fa00c35ad3a186e187bdf93105617ced46d43f",
                            "f75d1a06bcfa6f2d8fbc0881f23ed2b6ce99504e"),
                    Tuple.Create(
                            @"https://github.com/tweepy/tweepy.git",
                            @"d626a964b29f7a9e93599a3b25789f8b997b1aef",
                            "a518381f8fdae80ca97815448f18a957a0562c8d"),
                    Tuple.Create(
                            @"https://github.com/sloria/TextBlob.git",
                            @"75d983fc798528dc3c8633efcfb031ae191752d1",
                            "e6819a5d2f89bb87c895550cc86710206ff5f322"),
                    Tuple.Create(
                            @"https://github.com/maraujop/django-crispy-forms.git",
                            @"e31e39561c10b01be3693914aad1aa79350f5647",
                            "6c4b5073f161219fa8c7efcbb81fe4e49e211d80"),
                    Tuple.Create(
                            @"https://github.com/matplotlib/matplotlib.git",
                            @"3c8fe522356de92811bf0aecb244b5603b6e48c6",
                            "c3d5ba020b55711a9092dc7b836e39fbbd7c352a"),
                    Tuple.Create(
                            @"https://github.com/quantopian/zipline.git",
                            @"63e3aa4c1e8f25b08e3fbc437f778b28453c7e45",
                            "518d471a9337aec9f692fd5534b1c23d02cd80d0"),
                    Tuple.Create(
                            @"https://github.com/nicolaiarocci/eve.git",
                            @"ee559c0407204ee4c42c8b3e59f3c6b8fa4a7437",
                            "30f185fa625366f8916f6d805b6b58e6bc3806ea"),
                    Tuple.Create(
                            @"https://github.com/kennethreitz/clint.git",
                            @"f1ab574413631de12166469e87257784785d3da6",
                            "a54fedd0fb8ff0c8af47db766669b7004ab54944"),
                    Tuple.Create(
                            @"https://github.com/Pylons/pyramid.git",
                            @"77005d96fa57a83ac91c2547892fbb3e3c34e553",
                            "0adc2fe61c2e225dfa1bcf9a3d814ba394e95ce7"),
                    Tuple.Create(
                            @"https://github.com/mongodb/mongo-python-driver.git",
                            @"a7575fa14f5a9aaeb0149981899f776af9e1ad1c",
                            "9c47f3c649cb5502b678dafaad9058b06f5811b6"),
                    Tuple.Create(
                            @"https://github.com/lihaoyi/macropy.git",
                            @"13993ccb08df21a0d63b091dbaae50b9dbb3fe3e",
                            "392390d0c59b2f8776540fcf4d4ee1e0aee9b314"),
                    Tuple.Create(
                            @"https://github.com/torchbox/wagtail.git",
                            @"d3ac6c072886a1c4cd8d27b94c4a9b6e9d51f218",
                            "4cce28b1f58bee3a2e698ef110fd855571704667"),
                    Tuple.Create(
                            @"https://github.com/Eugeny/ajenti.git",
                            @"75013c621095775887f514ba014b36578ca48fae",
                            "d2fe9977b95de32e00f2771eadcd46cc4d200eea"),
                    Tuple.Create(
                            @"https://github.com/pennersr/django-allauth.git",
                            @"3fee3665b86cc9a56174e81267a187b36b1290de",
                            "e1d9dd7c79e70ad166f044d9acbe07515f3ab6b2"),
                    Tuple.Create(
                            @"https://github.com/gorakhargosh/watchdog.git",
                            @"a8391941d4ff450483f0dfe2b5a3c02ecdd8f818",
                            "6cb95525bb4b78abd6e697ecbdd561ca731fb41c"),
                    Tuple.Create(
                            @"https://github.com/coleifer/peewee.git",
                            @"e24cdd19204d63984d537842336cbc5426217cc0",
                            "d0594960d26ab4f226239983b56a0bb377f9afb7"),
                    Tuple.Create(
                            @"https://github.com/gurgeh/selfspy.git",
                            @"75792f48e280575366ce855a947f2bff6eea513b",
                            "113badaf2700cfe151a50c9f34aa3db508609c73"),
                    Tuple.Create(
                            @"https://github.com/livid/v2ex.git",
                            @"c8af57e2d2c4c8701901fb346cc98a4cde13b54b",
                            "ae4be58d56080c06ab78d1ed1da334ac72e73114"),
                    Tuple.Create(
                            @"https://github.com/spotify/luigi.git",
                            @"8b13063c398a3fa9f7b1dadacefa0512b407f164",
                            "25ca876fc7280847777529f08b18b2f0561af49d"),
                    Tuple.Create(
                            @"https://github.com/Yelp/mrjob.git",
                            @"94a67a42d36e69aada9e31d1975be32e730f1656",
                            "ea2e0a2ed2ae314ae3d3e91cbd4f878753bfa895"),
                    Tuple.Create(
                            @"https://github.com/paramiko/paramiko.git",
                            @"e96e2653a2ca0a465d2773b1fe468c0f87e758bc",
                            "4cac30252a9aebccc87c76f5671a16d5b0b9b57a"),
                    Tuple.Create(
                            @"https://github.com/wrobstory/vincent.git",
                            @"c2e4e34cb6e008e759d63066c9b8420fd2f0e71c",
                            "d0d9a17f9b8b25681028fa43e3d6f7e9e1f0eeb9"),
                    Tuple.Create(
                            @"https://github.com/alex/django-taggit.git",
                            @"f478e34f8e82c20b04f5992ae5299d7cf41c2b9f",
                            "8313c77f3d82740c905fb2061f9737fe7157c593"),
                };
                foreach (var exp in exps) {
                    foreach (
                            var learningSet in
                                    learningSets.Skip(JavaExperiment.SkipCount)
                                            .Take(JavaExperiment.TakeCount)) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        Git.Clone(path, url);
                        yield return
                                new TestCaseData(exp, path, learningSet.Item2, learningSet.Item3);
                    }
                }
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath, int starCount) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.py"), };
            if (_lastProjectName != exp.GetType().Name) {
                _writer.WriteLine();
                _writer.Write(Path.GetFileName(projectPath) + ",");
                _lastProjectName = exp.GetType().Name;
            }
            exp.Learn(seedPaths, _writer, projectPath, "*.py");
            _writer.Flush();
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

    public class PythonSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public PythonSuperComplexBranchExperiment() : base("test", "argument") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "test" && (e.Parent.Name == "if_stmt" || e.Parent.Name == "while_stmt")) {
                return true;
            }
            if (e.Name == "test") {
                e = e.Parent;
            }
            if (e.Name == "argument" && e.Prev == null && e.SafeParent().Name == "arglist"
                && e.SafeParent().SafeParent().Name == "trailer"
                && e.SafeParent().SafeParent().SafeParent().Name == "power") {
                var atom = e.SafeParent().SafeParent().Prev;
                return atom.Name == "atom" && atom.TokenText == "str";
            }
            return false;
        }
    }

    public class PythonComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public PythonComplexStatementExperiment() : base("small_stmt", "compound_stmt") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "stmt") {
                e = e.FirstChild;
            }
            if (e.Name == "small_stmt" && e.FirstChild.Name == "pass_stmt") {
                return false;
            }
            return e.Name == "small_stmt" || e.Name == "compound_stmt";
        }
    }

    public class PythonEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public PythonEmptyStatementExperiment() : base("pass_stmt") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "stmt") {
                e = e.FirstChild;
            }
            if (e.Name == "small_stmt" && e.FirstChild.Name == "pass_stmt") {
                return true;
            }
            return e.Name == "pass_stmt";
        }
    }

    public class PythonExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override bool IsInner {
            get { return true; }
        }

        public PythonExpressionStatementExperiment() : base("expr_stmt") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "small_stmt") {
                return e.FirstChild.Name == "expr_stmt";
            }
            return true;
        }
    }

    public class PythonArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public PythonArithmeticOperatorExperiment() : base("PLUS", "MINUS", "STAR", "SLASH") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return ((e.TokenText == "+" || e.TokenText == "-") && e.Parent.Name == "arith_expr") ||
                   ((e.TokenText == "*" || e.TokenText == "/") && e.Parent.Name == "term");
        }
    }

    public class PythonSuperComplexBranchExperimentWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override bool IsInner {
            get { return false; }
        }

        public PythonSuperComplexBranchExperimentWithoutTrue() : base("test", "argument") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.Name == "test" && (e.Parent.Name == "if_stmt" || e.Parent.Name == "while_stmt")) {
                return e.TokenText != "True";
            }
            if (e.Name == "test") {
                e = e.Parent;
            }
            if (e.Name == "argument" && e.Prev == null && e.SafeParent().Name == "arglist"
                && e.SafeParent().SafeParent().Name == "trailer"
                && e.SafeParent().SafeParent().SafeParent().Name == "power") {
                var atom = e.SafeParent().SafeParent().Prev;
                return atom.Name == "atom" && atom.TokenText == "str" && e.TokenText != "True";
            }
            return false;
        }
    }
}