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
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Learner.Core.Learning.Experiments {
    public abstract class Experiment {
        public const int SkipCount = 0;
        public const int TakeCount = 0;
        private const int ProjectCount = 5;
        private const int ProjectCountToLearn = 3;
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
                    writer.Write(classificationResult.WrongVectorCount);
                    writer.Write(",");
                    writer.WriteLine();
                    writer.Flush();
                    if (classificationResult.WrongElementCount > 0) {
                        failedCount++;
                        PrintWrongResults(classificationResult, learningResult);
                    }
                    Console.WriteLine(exp.GetType().Name);
                    Assert.That(failedCount, Is.EqualTo(0));
                }
            }
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
            writer.Write(classificationResult.WrongVectorCount);
            writer.Write(",");
            writer.WriteLine();
            writer.Flush();
            if (classificationResult.WrongVectorCount > 0) {
                PrintWrongResults(classificationResult, learningResult);
            }
            var seedWriter =
                    CreateWriter(exp.GetType().Name + "_seed_" + projectPaths.Count() + ".txt");
            WriteSeedVectors(seedWriter, learningResult);
            var featureWriter =
                    CreateWriter(exp.GetType().Name + "_feature_" + projectPaths.Count() + ".txt");
            WriteFeatureStrings(featureWriter, learningResult.Classifier,
                    learningResult.FeatureEncoder, learningResult.EncodingResult);
            return learningResult;
        }

        private static void WriteSeedVectors(TextWriter writer, LearningResult learningResult) {
            writer.WriteLine("################ Seed Accepted Vectors ################");
            var seedAcceptedVectors =
                    learningResult.EncodingResult.SeedAcceptedVector2GroupPath.Keys;
            foreach (var vector in seedAcceptedVectors) {
                writer.WriteLine("--------------------------------------");
                if (learningResult.EncodingResult.Vector2Node != null) {
                    writer.WriteLine(learningResult.EncodingResult.Vector2Node[vector].Code);
                    writer.WriteLine(GetGoodAncestorNode(
                            learningResult.EncodingResult.Vector2Node[vector]).Code);
                }
                var features = learningResult.FeatureEncoder.GetFeatureStringsByVector(vector);
                foreach (var feature in features) {
                    if (feature.Contains("Requires") || feature.Contains("Contract")) {
                        writer.WriteLine(Beautify(feature));
                    }
                }
                writer.WriteLine();
            }
            writer.WriteLine("################ Seed Rejected Vectors ################");
            var seedRejectedVectors =
                    learningResult.EncodingResult.SeedAcceptedVector2GroupPath.Keys;
            foreach (var vector in seedRejectedVectors) {
                writer.WriteLine("--------------------------------------");
                if (learningResult.EncodingResult.Vector2Node != null) {
                    writer.WriteLine(learningResult.EncodingResult.Vector2Node[vector].Code);
                    writer.WriteLine(GetGoodAncestorNode
                            (learningResult.EncodingResult.Vector2Node[vector]).Code);
                }
                var features = learningResult.FeatureEncoder.GetFeatureStringsByVector(vector);
                foreach (var feature in features) {
                    if (learningResult.EncodingResult.Vector2Node != null) {
                        writer.WriteLine(learningResult.EncodingResult.Vector2Node[vector].Code);
                    }
                    if (feature.Contains("Requires") || feature.Contains("Contract")) {
                        writer.WriteLine(Beautify(feature));
                    }
                }
                writer.WriteLine();
            }
        }

        private static void PrintWrongResults(
                ClassificationResult classificationResult, LearningResult learningResult) {
            var nodeAndVectors = new[] {
                classificationResult.WronglyAcceptedNodes
                        .Zip(classificationResult.WronglyAcceptedVectors, Tuple.Create),
                classificationResult.WronglyRejectedNodes
                        .Zip(classificationResult.WronglyRejectedVectors, Tuple.Create)
            };
            var titles = new[] {
                "WronglyAcceptedNodes", "WronglyRejectedNodes"
            };

            for (int i = 0; i < nodeAndVectors.Length; i++) {
                Console.WriteLine("--------------- " + titles[i] + " ---------------");
                foreach (var nodeAndVector in nodeAndVectors[i]) {
                    var node = nodeAndVector.Item1;
                    var vector = nodeAndVector.Item2;
                    Console.WriteLine(node.Code);
                    Console.WriteLine(GetGoodAncestorNode(node).Code);
                    var groupPath = learningResult.FeatureEncoder.GetGroupPathFromNode(node);
                    var groupIndex = learningResult.Classifier.GetGroupIndex(groupPath);
                    Console.WriteLine("Group: " + (groupIndex + 1) + " (" + groupPath + ")");
                    Console.WriteLine("IsAccepted: "
                                      + learningResult.Classifier.IsAccepted(vector, groupIndex));
                    Console.WriteLine("IsRejected: "
                                      + learningResult.Classifier.IsRejected(vector, groupIndex));
                    var featureStrings =
                            learningResult.FeatureEncoder.GetFeatureStringsByVector(vector);
                    foreach (var featureString in featureStrings) {
                        Console.WriteLine(Beautify(featureString));
                    }
                    if (i == 1) {
                        Console.WriteLine("------------- Rejcting Features -------------");
                        var negativeVector = vector
                                             & learningResult.Classifier.Units[groupIndex].Rejecting;
                        featureStrings =
                                learningResult.FeatureEncoder.GetFeatureStringsByVector(
                                        negativeVector);
                        foreach (var featureString in featureStrings) {
                            Console.WriteLine(Beautify(featureString));
                        }
                    }
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }

        public static string Beautify(string path) {
            return path.Replace(">", " > ").Replace("<", " < ");
        }

        public static void WriteFeatureStrings(
                TextWriter writer, Classifier classifier, FeatureEncoder featureEncoder,
                EncodingResult encodingResult = null) {
            var acceptingFeature = classifier.GetAllAcceptingFeatureStrings(featureEncoder);
            var rejectingFeatures = classifier.GetAllRejectingFeatureStrings(featureEncoder);
            var acceptingVectorCounts = encodingResult != null
                    ? classifier.CountAcceptedVectorsOfEachGroup(encodingResult)
                    : Enumerable.Repeat(-1, acceptingFeature.Count).ToList();
            var rejectingVectorCounts = encodingResult != null
                    ? classifier.CountRejectedVectorsOfEachGroup(encodingResult)
                    : Enumerable.Repeat(-1, rejectingFeatures.Count).ToList();
            writer.WriteLine("################ Accepting Features ################");
            for (var i = 0; i < acceptingFeature.Count; i++) {
                writer.WriteLine("######## Group: " + (i + 1) + " ("
                                 + acceptingVectorCounts[i] + ") ########");
                writer.WriteLine(Beautify(classifier.GroupPaths[i]));
                if (acceptingVectorCounts[i] != 0) {
                    writer.WriteLine();
                    foreach (var featureString in acceptingFeature[i]) {
                        writer.WriteLine(Beautify(featureString));
                    }
                }
            }
            writer.WriteLine("################ Rejecting Features ################");
            for (var i = 0; i < rejectingFeatures.Count; i++) {
                writer.WriteLine("######## Group: " + (i + 1) + " ("
                                 + rejectingVectorCounts[i] + ") ########");
                writer.WriteLine(Beautify(classifier.GroupPaths[i]));
                if (rejectingVectorCounts[i] != 0) {
                    writer.WriteLine();
                    foreach (var featureString in rejectingFeatures[i]) {
                        writer.WriteLine(Beautify(featureString));
                    }
                }
            }
            writer.Flush();
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
            Assert.That(ret.ClassificationResult.WrongVectorCount, Is.EqualTo(0));
        }

        public void Learn(
                List<string> seedPaths, LearningExperiment exp, params string[] projectPaths) {
            Learn(seedPaths, exp, (ICollection<string>)projectPaths);
        }

        public static CstNode GetGoodAncestorNode(CstNode node) {
            while (node.Parent != null && node.Parent.Code.Length < 100) {
                node = node.Parent;
            }
            return node;
        }
    }
}