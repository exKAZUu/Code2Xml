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
        public const int TakeCount = 2;

        protected Experiment() {
            Writers = new Dictionary<string, StreamWriter>();
        }

        protected abstract string SearchPattern { get; }

        public void LearnAndApply(
                ICollection<string> seedPaths, Tuple<string, string>[] learningSets,
                LearningExperiment[] experiments) {
            var projectPaths =
                    learningSets.Select(
                            t => {
                                var url = t.Item1;
                                var path = Fixture.GetGitRepositoryPath(url);
                                Git.Clone(path, url);
                                Git.Checkout(path, t.Item2);
                                return path;
                            }).ToList();
            foreach (var exp in experiments) {
                LearnWithoutClearing(seedPaths, exp, projectPaths.Take(10));
                foreach (var projectPath in projectPaths.Skip(10)) {
                    exp.Apply(null, new[] { projectPath }, SearchPattern);
                }
            }
        }

        private void LearnWithoutClearing(
                ICollection<string> seedPaths, LearningExperiment exp,
                IEnumerable<string> projectPaths) {
            StreamWriter writer;
            var expName = exp.GetType().Name;
            if (!Writers.TryGetValue(expName, out writer)) {
                writer =
                        File.CreateText(
                                @"C:\Users\exKAZUu\Dropbox\Data\" + expName + SkipCount + "_"
                                + TakeCount + ".csv");
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
                writer.WriteLine(",");
                Writers.Add(expName, writer);
            }
            var codePaths = projectPaths.SelectMany(
                    projectPath => Directory.GetFiles(
                            projectPath, SearchPattern, SearchOption.AllDirectories)
                    ).ToList();
            var ret = exp.Learn(seedPaths, writer, codePaths, SearchPattern);
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