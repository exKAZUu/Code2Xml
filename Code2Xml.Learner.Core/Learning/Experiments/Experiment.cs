#region License

// Copyright (C) 2011-2015 Kazunori Sakamoto
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
        public const int TakeCount = 0;

        private const int ProjectCount = 50;
        private const int ProjectCountToLearn = 20;

        protected Experiment() {
            Writers = new Dictionary<string, StreamWriter>();
        }

        protected abstract string SearchPattern { get; }

        public void LearnAndApply(
                ICollection<string> seedPaths, Tuple<string, string>[] learningSets,
                LearningExperiment[] experiments) {
            var projectPaths =
                    learningSets.Take(ProjectCount).Select(
                            t => {
                                var url = t.Item1;
                                var path = Fixture.GetGitRepositoryPath(url);
                                Git.Clone(path, url);
                                Git.Checkout(path, t.Item2);
                                return path;
                            }).ToList();
            var failedCount = 0;
            foreach (var exp in experiments) {
                var learningResult = LearnWithoutClearing(
                        seedPaths, exp, projectPaths.Skip(ProjectCountToLearn).ToList());

                var w = CreateWriter(exp.GetType().Name + "_classifier_" +
                                     ProjectCountToLearn + "_" + ProjectCount + ".txt");
                w.WriteLine(learningResult.Classifier.GetClassifierSummary());
                w.Flush();

                var writer = CreateWriter(exp.GetType().Name + "_apply_" +
                                          ProjectCountToLearn + "_" + ProjectCount + ".csv");
                foreach (var projectPath in projectPaths.Skip(ProjectCountToLearn)) {
                    var codePaths = Directory.GetFiles(projectPath, SearchPattern,
                            SearchOption.AllDirectories);
                    writer.Write(DateTime.Now);
                    writer.Write(",");
                    writer.Write(projectPath);
                    writer.Write(",");
                    var classificationResult = exp.Apply(codePaths, SearchPattern,
                            learningResult.FeatureEncoder,
                            learningResult.Classifier, writer);
                    var features =
                            learningResult.Classifier.GetAllAcceptingFeatureStrings(
                                    learningResult.FeatureEncoder);
                    writer.Write(classificationResult.WrongElementCount);
                    writer.Write(",");
                    writer.Write(classificationResult.WrongFeatureCount);
                    writer.Write(",");
                    writer.WriteLine();
                    writer.Flush();
                    if (classificationResult.WrongElementCount > 0) {
                        failedCount++;
                        Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
                        foreach (var we in classificationResult.WronglyAcceptedNodes) {
                            var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                            Console.WriteLine(we.Code);
                            Console.WriteLine(e.Code);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("---- WronglyRejectedElements ----");
                        foreach (var we in classificationResult.WronglyAcceptedNodes) {
                            var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                            Console.WriteLine(we.Code);
                            Console.WriteLine(e.Code);
                            Console.WriteLine("---------------------------------------------");
                        }
                    }
                }
            }
            Assert.That(failedCount, Is.EqualTo(0));
        }

        private LearningResult LearnWithoutClearing(
                ICollection<string> seedPaths, LearningExperiment exp,
                ICollection<string> projectPaths) {
            var writer =
                    CreateWriter(exp.GetType().Name + "_learn_" + projectPaths.Count() + ".csv");
            var codePaths = projectPaths.SelectMany(
                    projectPath => Directory.GetFiles(
                            projectPath, SearchPattern, SearchOption.AllDirectories)
                    ).ToList();
            writer.Write(DateTime.Now);
            writer.Write(",");
            writer.Write(projectPaths.First());
            writer.Write(",");
            var learningResult = exp.Learn(seedPaths, codePaths, SearchPattern, writer);
            var classificationResult = learningResult.ClassificationResult;
            writer.Write(classificationResult.WrongElementCount);
            writer.Write(",");
            writer.Write(classificationResult.WrongFeatureCount);
            writer.Write(",");
            writer.WriteLine();
            writer.Flush();
            if (classificationResult.WrongFeatureCount > 0) {
                Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
                foreach (var we in classificationResult.WronglyAcceptedNodes) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
                Console.WriteLine("---- WronglyRejectedElements ----");
                foreach (var we in classificationResult.WronglyRejectedNodes) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
            }
            return learningResult;
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
                writer.Write("SeedAcceptedNodeCount");
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
                List<string> seedPaths, LearningExperiment exp, ICollection<string> projectPaths) {
            var ret = LearnWithoutClearing(seedPaths, exp, projectPaths);
            Assert.That(ret.ClassificationResult.WrongFeatureCount, Is.EqualTo(0));
        }

        public void Learn(
                List<string> seedPaths, LearningExperiment exp, params string[] projectPaths) {
            Learn(seedPaths, exp, (ICollection<string>)projectPaths);
        }
    }
}
