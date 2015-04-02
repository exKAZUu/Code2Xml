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
    public class Python2Experiment : Experiment {
        public static CstGenerator Generator = CstGenerators.Python2;
        private const string LangName = "Python2";

        private static readonly LearningExperiment[] Experiments = {
            new PythonComplexStatementExperiment(),
            new PythonSuperComplexBranchExperiment(),
            new PythonExpressionStatementExperiment(),
            new PythonArithmeticOperatorExperiment(),
            //new PythonSuperComplexBranchExperimentWithoutTrue(), 
            //new PythonEmptyStatementExperiment(),
        };

        #region LearningSets

        private static readonly Tuple<string, string>[] LearningSets = {
            Tuple.Create(
                    @"https://github.com/mitsuhiko/flask.git",
                    @"d4b3d16c142e2189c6faf8f784a195e7f827c596"),
            Tuple.Create(
                    @"https://github.com/django/django.git",
                    @"09af48c70fb5cc652ea109487015472e9ef984df"),
            Tuple.Create(
                    @"https://github.com/facebook/tornado.git",
                    @"c5292057a8db3ebec4a80d9c9207bfadff7fa784"),
            Tuple.Create(
                    @"https://github.com/jkbr/httpie.git",
                    @"746a1899f319a7c2a60f27bf23cc3762822be1a2"),
            Tuple.Create(
                    @"https://github.com/ansible/ansible.git",
                    @"2cc4ac2e7563e6b73666048c3624bf092f9959e1"),
            Tuple.Create(
                    @"https://github.com/reddit/reddit.git",
                    @"b50f91c53149671c4039ff1de4250ac0d5bc89c0"),
            Tuple.Create(
                    @"https://github.com/getsentry/sentry.git",
                    @"94e56e691f4081db7680faf49db5592ec29edd23"),
            Tuple.Create(
                    @"https://github.com/rg3/youtube-dl.git",
                    @"2d4c98dbd17676978114b70d59ea15628f886c24"),
            Tuple.Create(
                    @"https://github.com/pagekite/Mailpile.git",
                    @"556c9e16855dea71db23bc2180e4cef1cf2a40ef"),
            Tuple.Create(
                    @"https://github.com/apenwarr/sshuttle.git",
                    @"9ce2fa00f94c2f2e5c310abeb1a2907ae7e7a7b0"),
            Tuple.Create(
                    @"https://github.com/getpelican/pelican.git",
                    @"b11b8a93cd45ad2d16118ce2bffef8bd3128a004"),
            Tuple.Create(
                    @"https://github.com/fabric/fabric.git",
                    @"b41f7995bcaa5ade335e1dd1e438ae2ca42f4e07"),
            Tuple.Create(
                    @"https://github.com/django/django-old.git",
                    @"ad096059b58afd35b395b01ad4eba36b8ff863de"),
            Tuple.Create(
                    @"https://github.com/webpy/webpy.git",
                    @"73f1119649ffe54ba26ddaf6a612aaf1dab79b7f"),
            Tuple.Create(
                    @"https://github.com/divio/django-cms.git",
                    @"f884372e0576a384e05c6a8f084eaf089eae25b3"),
            Tuple.Create(
                    @"https://github.com/midgetspy/Sick-Beard.git",
                    @"a493151582d5779f5656291c9251398623511e7b"),
            Tuple.Create(
                    @"https://github.com/Lokaltog/powerline.git",
                    @"c100c90b088c55fe91146eb52dfcbbc7e43039bd"),
            Tuple.Create(
                    @"https://github.com/django-debug-toolbar/django-debug-toolbar.git",
                    @"777c8a1cd669bbfde6cfcb8866de4fdf8c0825cf"),
            Tuple.Create(
                    @"https://github.com/toastdriven/django-tastypie.git",
                    @"834f728b07ab1a008b281b12a2cab2987f26c99d"),
            Tuple.Create(
                    @"https://github.com/andymccurdy/redis-py.git",
                    @"f96e46b971a5bb66ab5f94ba87ab3e092e5f01ac"),
            Tuple.Create(
                    @"https://github.com/clips/pattern.git",
                    @"a9d7f8449c0118e7442b4ffb1c78097c74b468ed"),
            Tuple.Create(
                    @"https://github.com/tomchristie/django-rest-framework.git",
                    @"b3b0515ae6325e7de6a582bbb2fd7eeac687c325"),
            Tuple.Create(
                    @"https://github.com/mitmproxy/mitmproxy.git",
                    @"1dba379ae90593a563acb9dbed6f5e6b721c086a"),
            Tuple.Create(
                    @"https://github.com/amoffat/sh.git",
                    @"80af5726d8aa42017ced548abbd39b489068922a"),
            Tuple.Create(
                    @"https://github.com/joke2k/faker.git",
                    @"7cd01eb89df25ee7e98854b9edd991e008c6f49f"),
            Tuple.Create(
                    @"https://github.com/nicolargo/glances.git",
                    @"4177046cdd3be8f2019799490de54a7aab5b0550"),
            Tuple.Create(
                    @"https://github.com/scrapinghub/portia.git",
                    @"55f97e61fc558d243a0806ae8bf4a26b080026de"),
            Tuple.Create(
                    @"https://github.com/jorgebastida/glue.git",
                    @"33fa00c35ad3a186e187bdf93105617ced46d43f"),
            Tuple.Create(
                    @"https://github.com/tweepy/tweepy.git",
                    @"d626a964b29f7a9e93599a3b25789f8b997b1aef"),
            Tuple.Create(
                    @"https://github.com/sloria/TextBlob.git",
                    @"75d983fc798528dc3c8633efcfb031ae191752d1"),
            Tuple.Create(
                    @"https://github.com/maraujop/django-crispy-forms.git",
                    @"e31e39561c10b01be3693914aad1aa79350f5647"),
            Tuple.Create(
                    @"https://github.com/matplotlib/matplotlib.git",
                    @"3c8fe522356de92811bf0aecb244b5603b6e48c6"),
            Tuple.Create(
                    @"https://github.com/quantopian/zipline.git",
                    @"63e3aa4c1e8f25b08e3fbc437f778b28453c7e45"),
            Tuple.Create(
                    @"https://github.com/nicolaiarocci/eve.git",
                    @"ee559c0407204ee4c42c8b3e59f3c6b8fa4a7437"),
            Tuple.Create(
                    @"https://github.com/kennethreitz/clint.git",
                    @"f1ab574413631de12166469e87257784785d3da6"),
            Tuple.Create(
                    @"https://github.com/Pylons/pyramid.git",
                    @"77005d96fa57a83ac91c2547892fbb3e3c34e553"),
            Tuple.Create(
                    @"https://github.com/mongodb/mongo-python-driver.git",
                    @"a7575fa14f5a9aaeb0149981899f776af9e1ad1c"),
            Tuple.Create(
                    @"https://github.com/lihaoyi/macropy.git",
                    @"13993ccb08df21a0d63b091dbaae50b9dbb3fe3e"),
            Tuple.Create(
                    @"https://github.com/torchbox/wagtail.git",
                    @"d3ac6c072886a1c4cd8d27b94c4a9b6e9d51f218"),
            Tuple.Create(
                    @"https://github.com/Eugeny/ajenti.git",
                    @"75013c621095775887f514ba014b36578ca48fae"),
            Tuple.Create(
                    @"https://github.com/pennersr/django-allauth.git",
                    @"3fee3665b86cc9a56174e81267a187b36b1290de"),
            Tuple.Create(
                    @"https://github.com/gorakhargosh/watchdog.git",
                    @"a8391941d4ff450483f0dfe2b5a3c02ecdd8f818"),
            Tuple.Create(
                    @"https://github.com/coleifer/peewee.git",
                    @"e24cdd19204d63984d537842336cbc5426217cc0"),
            Tuple.Create(
                    @"https://github.com/gurgeh/selfspy.git",
                    @"75792f48e280575366ce855a947f2bff6eea513b"),
            Tuple.Create(
                    @"https://github.com/livid/v2ex.git",
                    @"c8af57e2d2c4c8701901fb346cc98a4cde13b54b"),
            Tuple.Create(
                    @"https://github.com/spotify/luigi.git",
                    @"8b13063c398a3fa9f7b1dadacefa0512b407f164"),
            Tuple.Create(
                    @"https://github.com/Yelp/mrjob.git",
                    @"94a67a42d36e69aada9e31d1975be32e730f1656"),
            Tuple.Create(
                    @"https://github.com/paramiko/paramiko.git",
                    @"e96e2653a2ca0a465d2773b1fe468c0f87e758bc"),
            Tuple.Create(
                    @"https://github.com/wrobstory/vincent.git",
                    @"c2e4e34cb6e008e759d63066c9b8420fd2f0e71c"),
            Tuple.Create(
                    @"https://github.com/alex/django-taggit.git",
                    @"f478e34f8e82c20b04f5992ae5299d7cf41c2b9f"),
        };

        #endregion

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

        protected override string SearchPattern {
            get { return "*.py"; }
        }

        [Test]
        public void TestApply() {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.py"), };
            LearnAndApply(seedPaths, LearningSets, Experiments);
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "Seed.py"), };
            Learn(seedPaths, exp, projectPath);
        }
    }

    public class PythonSuperComplexBranchExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new FeatureExtractor(4, 0, 1, 0);
        }

        public PythonSuperComplexBranchExperiment() : base("test", "argument") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.Name == "test"
                && (node.Parent.Name == "if_stmt" || node.Parent.Name == "while_stmt")) {
                return true;
            }
            if (node.Name == "test") {
                node = node.Parent;
            }
            if (node.Name == "argument" && node.Prev == null && node.Parent.Name == "arglist"
                && node.Parent.Parent.Name == "trailer"
                && node.Parent.Parent.Parent.Name == "power") {
                var atom = node.Parent.Parent.Prev;
                return atom.Name == "atom" && atom.TokenText == "str";
            }
            return false;
        }
    }

    public class PythonComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new FeatureExtractor();
        }

        public PythonComplexStatementExperiment() : base("small_stmt", "compound_stmt") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            // stmt: simple_stmt | compound_stmt
            // simple_stmt: small_stmt (';' small_stmt)* [';'] NEWLINE
            // small_stmt: (expr_stmt | print_stmt  | del_stmt | pass_stmt | flow_stmt |
            //              import_stmt | global_stmt | exec_stmt | assert_stmt)
            if (node.Name == "stmt") {
                node = node.FirstChild;
            }
            if (node.Name == "small_stmt" && node.FirstChild.Name == "pass_stmt") {
                return false;
            }
            return node.Name == "small_stmt" || node.Name == "compound_stmt";
        }
    }

    public class PythonEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new FeatureExtractor();
        }

        public PythonEmptyStatementExperiment() : base("pass_stmt") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.Name == "stmt") {
                node = node.FirstChild;
            }
            if (node.Name == "small_stmt" && node.FirstChild.Name == "pass_stmt") {
                return true;
            }
            return node.Name == "pass_stmt";
        }
    }

    public class PythonExpressionStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new FeatureExtractor();
        }

        public PythonExpressionStatementExperiment() : base("expr_stmt") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.Name == "small_stmt") {
                return node.FirstChild.Name == "expr_stmt";
            }
            return true;
        }
    }

    public class PythonArithmeticOperatorExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new FeatureExtractor(1, 0, 0, 0);
        }

        public PythonArithmeticOperatorExperiment() : base("PLUS", "MINUS", "STAR", "SLASH") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            return ((node.TokenText == "+" || node.TokenText == "-")
                    && node.Parent.Name == "arith_expr") ||
                   ((node.TokenText == "*" || node.TokenText == "/") && node.Parent.Name == "term");
        }
    }

    public class PythonSuperComplexBranchExperimentWithoutTrue : LearningExperiment {
        protected override CstGenerator Generator {
            get { return Python2Experiment.Generator; }
        }

        public override FeatureExtractor CreateExtractor() {
            return new FeatureExtractor(4, 0, 1, 0);
        }

        public PythonSuperComplexBranchExperimentWithoutTrue() : base("test", "argument") {}

        public override bool ProtectedIsAcceptedUsingOracle(CstNode node) {
            if (node.Name == "test"
                && (node.Parent.Name == "if_stmt" || node.Parent.Name == "while_stmt")) {
                return node.TokenText != "True";
            }
            if (node.Name == "test") {
                node = node.Parent;
            }
            if (node.Name == "argument" && node.Prev == null && node.Parent.Name == "arglist"
                && node.Parent.Parent.Name == "trailer"
                && node.Parent.Parent.Parent.Name == "power") {
                var atom = node.Parent.Parent.Prev;
                return atom.Name == "atom" && atom.TokenText == "str";
            }
            return false;
        }
    }
}
