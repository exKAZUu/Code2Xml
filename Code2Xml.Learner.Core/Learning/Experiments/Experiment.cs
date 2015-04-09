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
        public const int SkipCount = 0;
        public const int TakeCount = 0;
        private const int ProjectCount = 50;
        private const int ProjectCountToLearn = 40;
        protected readonly Dictionary<string, StreamWriter> Writers;

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
                        seedPaths, exp, projectPaths.Take(ProjectCountToLearn).ToList());

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
                        PrintWrongResults(classificationResult, learningResult.FeatureEncoder);
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
                PrintWrongResults(classificationResult, learningResult.FeatureEncoder);
            }
            WriteFeatureStrings(exp, projectPaths, learningResult);
            return learningResult;
        }

        private static void PrintWrongResults(
                ClassificationResult classificationResult, FeatureEncoder featureEncoder) {
            Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
            foreach (var wn in classificationResult.WronglyAcceptedNodes) {
                var e = wn.AncestorsAndSelf().ElementAtOrDefault(5) ?? wn;
                Console.WriteLine(wn.Code);
                Console.WriteLine(e.Code);
                Console.WriteLine("---------------------------------------------");
            }
            Console.WriteLine("---- WronglyRejectedElements ----");
            foreach (var wn in classificationResult.WronglyRejectedNodes) {
                var e = wn.AncestorsAndSelf().ElementAtOrDefault(5) ?? wn;
                Console.WriteLine(wn.Code);
                Console.WriteLine(e.Code);
                Console.WriteLine("---------------------------------------------");
            }

            Console.WriteLine("--------------- WronglyAcceptedFeatures ---------------");
            foreach (var wf in classificationResult.WronglyAcceptedFeatures) {
                var features = featureEncoder.GetFeatureStringsByVector(wf);
                foreach (var feature in features) {
                    Console.WriteLine(Beautify(feature));
                }
            }
            Console.WriteLine("---- WronglyRejectedFeatures ----");
            foreach (var wf in classificationResult.WronglyRejectedFeatures) {
                var features = featureEncoder.GetFeatureStringsByVector(wf);
                foreach (var feature in features) {
                    Console.WriteLine(Beautify(feature));
                }
            }
        }

        public static string Beautify(string path) {
            return path.Replace(">", " > ").Replace("<", " < ");
        }

        private void WriteFeatureStrings(
                LearningExperiment exp, ICollection<string> projectPaths,
                LearningResult learningResult) {
            var featureWriter =
                    CreateWriter(exp.GetType().Name + "_feature_" + projectPaths.Count() + ".txt");
            var acceptingFeature =
                    learningResult.Classifier.GetAllAcceptingFeatureStrings(
                            learningResult.FeatureEncoder);
            var rejectingFeatures =
                    learningResult.Classifier.GetAllRejectingFeatureStrings(
                            learningResult.FeatureEncoder);
            var acceptingVectorCounts =
                    learningResult.Classifier.CountAcceptedVectorsOfEachGroup(
                            learningResult.EncodingResult);
            var rejectingVectorCounts =
                    learningResult.Classifier.CountRejectedVectorsOfEachGroup(
                            learningResult.EncodingResult);
            featureWriter.WriteLine("################ Accepting Features ################");
            for (var i = 0; i < acceptingFeature.Count; i++) {
                featureWriter.WriteLine("######## Group: " + (i + 1) + " ("
                                        + acceptingVectorCounts[i] + ") ########");
                featureWriter.WriteLine(Beautify(learningResult.Classifier.GroupPaths[i]));
                featureWriter.WriteLine();
                foreach (var feature in acceptingFeature[i]) {
                    featureWriter.WriteLine(Beautify(feature));
                }
            }
            featureWriter.WriteLine("################ Rejecting Features ################");
            for (var i = 0; i < rejectingFeatures.Count; i++) {
                featureWriter.WriteLine("######## Group: " + (i + 1) + " ("
                                        + rejectingVectorCounts[i] + ") ########");
                featureWriter.WriteLine(Beautify(learningResult.Classifier.GroupPaths[i]));
                featureWriter.WriteLine();
                foreach (var feature in rejectingFeatures[i]) {
                    featureWriter.WriteLine(Beautify(feature));
                }
            }
            featureWriter.Flush();
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