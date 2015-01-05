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
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Learner.Core.Learning.Experiments {
    public abstract class Experiment {
        protected readonly Dictionary<string, StreamWriter> Writers;

        public const int SkipCount = 0;
        public const int TakeCount = 1;
        private const int ProjectCount = 20;

        protected Experiment() {
            Writers = new Dictionary<string, StreamWriter>();
        }

        protected abstract string SearchPattern { get; }

        public void LearnAndApply(
                ICollection<string> seedPaths, Tuple<string, string>[] learningSets,
                LearningExperiment[] experiments) {
            var projectPaths =
                    learningSets.Take(50).Select(
                            t => {
                                var url = t.Item1;
                                var path = Fixture.GetGitRepositoryPath(url);
                                Git.Clone(path, url);
                                Git.Checkout(path, t.Item2);
                                return path;
                            }).ToList();
            var failedCount = 0;
            foreach (var exp in experiments) {
                LearnWithoutClearing(seedPaths, exp, projectPaths.Take(ProjectCount));

                var w = CreateWriter(exp.GetType().Name + "_classifier_" + ProjectCount + ".txt");
                w.WriteLine(exp.GetClassifierSummary());
                w.Flush();

                var writer = CreateWriter(exp.GetType().Name + "_" + ProjectCount + ".csv");
                foreach (var projectPath in projectPaths) {
                    var codePaths = Directory.GetFiles(
                            projectPath, SearchPattern, SearchOption.AllDirectories);
                    writer.Write(DateTime.Now);
                    writer.Write(",");
                    writer.Write(projectPath);
                    writer.Write(",");
                    var ret = exp.Apply(writer, codePaths, SearchPattern);
                    var features = exp.GetFeatures();

                    writer.Write(ret.WrongElementCount);
                    writer.Write(",");
                    writer.Write(ret.WrongFeatureCount);
                    writer.Write(",");
                    writer.WriteLine();
                    writer.Flush();
                    if (ret.WrongElementCount > 0) {
                        failedCount++;
                        Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
                        foreach (var we in ret.WronglyAcceptedElements) {
                            var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                            Console.WriteLine(we.Code);
                            Console.WriteLine(e.Code);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("---- WronglyRejectedElements ----");
                        foreach (var we in ret.WronglyRejectedElements) {
                            var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                            Console.WriteLine(we.Code);
                            Console.WriteLine(e.Code);
                            Console.WriteLine("---------------------------------------------");
                        }
                    }
                }
                exp.Clear();
            }
            Assert.That(failedCount, Is.EqualTo(0));
        }

        private void LearnWithoutClearing(
                ICollection<string> seedPaths, LearningExperiment exp,
                IEnumerable<string> projectPaths) {
            var writer = CreateWriter(exp.GetType().Name + "_learn_" + ProjectCount + ".csv");
            var codePaths = projectPaths.SelectMany(
                    projectPath => Directory.GetFiles(
                            projectPath, SearchPattern, SearchOption.AllDirectories)
                    ).ToList();
            writer.Write(DateTime.Now);
            writer.Write(",");
            writer.Write(projectPaths.First());
            writer.Write(",");
            var ret = exp.Learn(seedPaths, writer, codePaths, SearchPattern);
            writer.Write(ret.WrongElementCount);
            writer.Write(",");
            writer.Write(ret.WrongFeatureCount);
            writer.Write(",");
            writer.WriteLine();
            writer.Flush();
            if (ret.WrongFeatureCount > 0) {
                Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
                foreach (var we in ret.WronglyAcceptedElements) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
                Console.WriteLine("---- WronglyRejectedElements ----");
                foreach (var we in ret.WronglyRejectedElements) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
            }
            Assert.That(ret.WrongFeatureCount, Is.EqualTo(0));
        }

        private StreamWriter CreateWriter(string fileName) {
            StreamWriter writer;
            if (!Writers.TryGetValue(fileName, out writer)) {
                writer = File.CreateText(@"C:\Users\exKAZUu\Dropbox\Data\" + fileName);
                writer.Write("Time");
                writer.Write(",");
                writer.Write("Name");
                writer.Write(",");
                writer.Write("AllNodes");
                writer.Write(",");
                writer.Write("TrainingNodes");
                writer.Write(",");
                writer.Write("AllVectors");
                writer.Write(",");
                writer.Write("TrainingVectors");
                writer.Write(",");
                writer.Write("SeedNodeCount");
                writer.Write(",");
                writer.Write("AbstractSeedNodeCount");
                writer.Write(",");
                writer.Write("AcceptedSeedNodeCount");
                writer.Write(",");
                writer.Write("WrongNodeCount");
                writer.Write(",");
                writer.Write("WrongAbstractNodeCount");
                writer.Write(",");
                writer.WriteLine();
                Writers.Add(fileName, writer);
            }
            return writer;
        }

        public void Learn(
                List<string> seedPaths, LearningExperiment exp, IEnumerable<string> projectPaths) {
            LearnWithoutClearing(seedPaths, exp, projectPaths);
            exp.Clear();
        }

        public void Learn(
                List<string> seedPaths, LearningExperiment exp, params string[] projectPaths) {
            Learn(seedPaths, exp, (IEnumerable<string>)projectPaths);
        }
    }
}