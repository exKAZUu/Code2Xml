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
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Numerics;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;
using Code2Xml.Learner.Core.Learning.Experiments;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
    public class LearningResult {
        public ClassificationResult ClassificationResult { get; set; }
        public Classifier Classifier { get; set; }
        public EncodingResult EncodingResult { get; set; }
        public FeatureEncoder FeatureEncoder { get; set; }
    }

    public abstract class LearningExperiment : ILearningExperiment {
        protected abstract CstGenerator Generator { get; }

        public readonly ISet<string> OracleNames;

        protected LearningExperiment(params string[] elementNames) {
            OracleNames = elementNames.ToImmutableHashSet();
        }

        public ClassificationResult Apply(
                ICollection<string> codePaths, string searchPattern, FeatureEncoder featureEncoder,
                Classifier classifier, StreamWriter writer = null) {
            var allCsts = GenerateValidCsts(codePaths);
            var encodingResult = featureEncoder.Encode(codePaths, allCsts, this);

            var time = Environment.TickCount;
            var groupCache = new GroupCache(encodingResult, classifier);
            var result = Classify(Int32.MaxValue, classifier, groupCache, encodingResult);
            Console.WriteLine("Time: " + (Environment.TickCount - time));

            if (writer != null) {
                encodingResult.WriteResult(writer);
            }

            return result;
        }

        public LearningResult Learn(
                ICollection<string> seedPaths, ICollection<string> codePaths, string searchPattern,
                StreamWriter writer = null) {
            var allCsts = GenerateValidCsts(codePaths);
            var seedCsts = GenerateValidCsts(seedPaths).ToList();
            var seedNodes = seedCsts
                    .SelectMany(
                            cst => LearningExperimentUtil.GetUppermostNodesByNames(cst, OracleNames))
                    .Where(ProtectedIsAcceptedUsingOracle)
                    .ToList();

            var seedCst = seedCsts.First();
            var seedCode = seedCst.Code;
            var structuredCode = new StructuredCode(seedCode);

            var acceptingFragments = AcceptingFragments.ToList();
            var rejectingFragments = RejectingFragments.ToList();

            SelectedFragment.Initialize();
            for (int i = 0; i < acceptingFragments.Count; i++) {
                acceptingFragments[i].Update(structuredCode, seedCst);
                if (acceptingFragments[i].Node != seedNodes[i].AncestorWithSingleChild()) {
                    throw new Exception("The selected node should be the node selected by the oracle.");
                }
            }
            SelectedFragment.Initialize();
            foreach (var fragment in rejectingFragments) {
                fragment.Update(structuredCode, seedCst);
            }

            var preparingTime = Environment.TickCount;
            var extractor = CreateExtractor();
            var seedNodeSet = new SeedNodeSet(acceptingFragments.Select(f => f.Node), seedCsts, this);
            Console.WriteLine("#Accepted seed nodes: " + seedNodeSet.AcceptedNodes.Count
                              + " (" + acceptingFragments.Count() + ")");
            Console.WriteLine("#Rejected seed nodes: " + seedNodeSet.RejectedNodes.Count
                              + " (" + rejectingFragments.Count() + ")");

            var featureSet = new FeatuerSet(seedNodeSet, extractor, acceptingFragments, rejectingFragments);
            var groupPaths = seedNodeSet.SelectedNodeNames.Select(n => ">" + n + ">")
            var classifier = new Classifier(groupPaths, featureSet);
            Console.WriteLine(
                    "#Features: " + featureSet.AcceptingFeatureCount + ", "
                    + featureSet.RejectingFeatureCount);
            Console.WriteLine("Inner: " + extractor.IsInner);

            var featureEncoder = new FeatureEncoder(seedNodeSet.SelectedNodeNames, extractor,
                    featureSet);
            var encodingResult = featureEncoder.Encode(codePaths, allCsts, this, seedNodeSet);
            Console.WriteLine("#Unique Elements: " + encodingResult.VectorCount);
            if (encodingResult.IdealAcceptedVector2GroupPath.Keys.ToHashSet()
                    .Overlaps(encodingResult.IdealRejectedVector2GroupPath.Keys.ToHashSet())) {
                var others = encodingResult.IdealRejectedVector2GroupPath;
                var vector =
                        encodingResult.IdealAcceptedVector2GroupPath.Keys.First(others.ContainsKey);
                foreach (var featureString in featureEncoder.GetFeatureStringsByVector(vector)) {
                    Console.WriteLine(Experiment.Beautify(featureString));
                }
                throw new Exception("Master predicates can't classify elements!");
            }

            var groupCache = new GroupCache(encodingResult, classifier);
            var trainingSet = encodingResult.CreateTrainingVectorSet();
            classifier.Create(trainingSet, groupCache);
            Experiment.WriteFeatureStrings(Console.Out, classifier, featureEncoder);
            Console.WriteLine("Preparing time: " + (Environment.TickCount - preparingTime));

            var count = 0;
            var sumTime = Environment.TickCount;
            ClassificationResult classificationResult;
            while (true) {
                var time = Environment.TickCount;
                classificationResult = Classify(count, classifier, groupCache, encodingResult,
                        trainingSet);
                if (classificationResult.SuspiciousNodes == null) {
                    break;
                }

                var additionalAcceptedSet = RevealSuspiciousElements(
                        encodingResult.IdealAcceptedVector2GroupPath.Keys,
                        classificationResult.SuspiciousNodes, encodingResult, trainingSet);
                if (!classifier.Update(additionalAcceptedSet, trainingSet, groupCache)) {
                    count++;
                } else {
                    count = 0;
                }

                Console.WriteLine("Time: " + (Environment.TickCount - time));
            }
            classifier.MakeImmutable();
            Console.WriteLine();
            Console.WriteLine("Sum time: " + (Environment.TickCount - sumTime));
            var trainingVectorCount = trainingSet.Count;
            var idealVectorCount = encodingResult.IdealVectorSet.Count;
            Console.WriteLine("#Required vectors: " + trainingVectorCount + " / " + idealVectorCount);

            if (writer != null) {
                encodingResult.WriteResult(writer, trainingSet);
            }

            foreach (var groupPath in classifier.GroupPaths) {
                Console.WriteLine(groupPath);
            }

            classifier.Optimize(encodingResult.IdealRejectedVector2GroupPath.Keys, groupCache);

            return new LearningResult {
                ClassificationResult = classificationResult,
                Classifier = classifier,
                EncodingResult = encodingResult,
                FeatureEncoder = featureEncoder,
            };
        }

        private IEnumerable<CstNode> GenerateValidCsts(IEnumerable<string> codePaths) {
            return codePaths.Select(
                    path => {
                        try {
                            var ret = Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
                            Console.Write(".");
                            return ret;
                        } catch {
                            return null;
                        }
                    })
                    .Where(t => t != null);
        }

        public ClassificationResult Classify(
                int count, Classifier classifier, GroupCache groupCache,
                EncodingResult encodingResult,
                RevealedVectorSet trainingSet = null) {
            trainingSet = trainingSet ?? new RevealedVectorSet();
            var correctlyAccepted = 0;
            var correctlyRejected = 0;
            var wronglyAccepted = 0;
            var wronglyRejected = 0;
            var correctlyRejectedInRejecting = 0;
            var wronglyRejectedInRejecting = 0;
            var rejectAccept = new List<List<SuspiciousNode>>();
            var rejectReject = new List<List<SuspiciousNode>>();
            var acceptAccept = new List<List<SuspiciousNode>>();
            var acceptReject = new List<List<SuspiciousNode>>();
            for (int i = 0; i < classifier.GroupCount; i++) {
                rejectAccept.Add(new List<SuspiciousNode>());
                rejectReject.Add(new List<SuspiciousNode>());
                acceptAccept.Add(new List<SuspiciousNode>());
                acceptReject.Add(new List<SuspiciousNode>());
            }

            var wrongNodeCount = 0;
            var wronglyRejectedFeatures = new List<BigInteger>();
            var wronglyAcceptedFeatures = new List<BigInteger>();
            foreach (var vectorAndGroupPath in encodingResult.IdealVectorSet.Accepted) {
                var vector = vectorAndGroupPath.Key;
                var groupPath = vectorAndGroupPath.Value;
                var groupIndex = groupCache.GetGroupIndex(vector);
                var rejected = classifier.IsRejected(vector, groupIndex);
                var accepted = classifier.IsAccepted(vector, groupIndex);
                if (!trainingSet.Accepted.ContainsKey(vector)
                    && !trainingSet.Rejected.ContainsKey(vector)) {
                    var target = new SuspiciousNode {
                        Vector = vector,
                        GroupKey = groupPath,
                        Used = false,
                    };
                    if (accepted) {
                        if (!rejected) {
                            acceptAccept[groupIndex].Add(target);
                        } else {
                            acceptReject[groupIndex].Add(target);
                        }
                    } else {
                        if (!rejected) {
                            rejectAccept[groupIndex].Add(target);
                        } else {
                            rejectReject[groupIndex].Add(target);
                        }
                    }
                }
                if (!accepted) {
                    wronglyRejected++;
                    wrongNodeCount += encodingResult.Vector2Count[vector];
                    wronglyRejectedFeatures.Add(vector);
                } else if (!rejected) {
                    correctlyAccepted++;
                } else {
                    wronglyRejectedInRejecting++;
                    wrongNodeCount += encodingResult.Vector2Count[vector];
                    wronglyRejectedFeatures.Add(vector);
                }
            }

            foreach (var vectorAndGroupPath in encodingResult.IdealVectorSet.Rejected) {
                var vector = vectorAndGroupPath.Key;
                var groupPath = vectorAndGroupPath.Value;
                var groupIndex = groupCache.GetGroupIndex(vector);
                var rejected = classifier.IsRejected(vector, groupIndex);
                var accepted = classifier.IsAccepted(vector, groupIndex);
                if (!trainingSet.Accepted.ContainsKey(vector)
                    && !trainingSet.Rejected.ContainsKey(vector)) {
                    var target = new SuspiciousNode {
                        Vector = vector,
                        GroupKey = groupPath,
                        Used = false,
                    };
                    if (accepted) {
                        if (!rejected) {
                            acceptAccept[groupIndex].Add(target);
                        } else {
                            acceptReject[groupIndex].Add(target);
                        }
                    } else {
                        if (!rejected) {
                            rejectAccept[groupIndex].Add(target);
                        } else {
                            rejectReject[groupIndex].Add(target);
                        }
                    }
                }
                if (!accepted) {
                    correctlyRejected++;
                } else if (!rejected) {
                    wronglyAccepted++;
                    wrongNodeCount += encodingResult.Vector2Count[vector];
                    wronglyAcceptedFeatures.Add(vector);
                } else {
                    correctlyRejectedInRejecting++;
                }
            }
            Console.WriteLine("done");
            Console.WriteLine(
                    "WA: " + wronglyAccepted + ", WR: " + wronglyRejected + "/"
                    + wronglyRejectedInRejecting + ", CA: "
                    + correctlyAccepted + ", CR: " + correctlyRejected + "/"
                    + correctlyRejectedInRejecting);
            Console.WriteLine(
                    "TR: "
                    + trainingSet.Count + ", AF: "
                    + String.Join(", ", classifier.CountAcceptingFeatures())
                    + ", RF: "
                    + String.Join(", ", classifier.CountRejectingFeatures()));
            var wrongFeatureCount = wronglyAccepted + wronglyRejected
                                    + wronglyRejectedInRejecting;

            var selector = new SuspiciousNodeSelector(classifier.AcceptingFeatureBitMask,
                    classifier.RejectingFeatureBitMask);
            var suspiciousNodes = selector.SelectSuspiciousNodes(count, classifier, acceptAccept,
                    acceptReject, rejectAccept, rejectReject);

            return new ClassificationResult(suspiciousNodes, wronglyAcceptedFeatures,
                    wronglyRejectedFeatures,
                    wrongFeatureCount, wrongNodeCount, encodingResult);
        }

        public IDictionary<BigInteger, string> RevealSuspiciousElements(
                ICollection<BigInteger> actuallyAcceptedVectors,
                IList<SuspiciousNode> suspiciousNodes,
                EncodingResult encodingResult, RevealedVectorSet trainingSet) {
            var additionalAcceptedVector2GroupPath = new Dictionary<BigInteger, string>();
            foreach (var t in suspiciousNodes) {
                if (actuallyAcceptedVectors.Contains(t.Vector)) {
                    additionalAcceptedVector2GroupPath.Add(t.Vector, t.GroupKey);
                    trainingSet.Accepted.Add(t.Vector, t.GroupKey);
                } else {
                    trainingSet.Rejected.Add(t.Vector, t.GroupKey);
                }
            }

            Console.WriteLine(
                    "Accepted: " + trainingSet.AcceptedCount + " + "
                    + additionalAcceptedVector2GroupPath.Count
                    + " / " + encodingResult.IdealVectorSet.AcceptedCount);
            Console.WriteLine(
                    "Rejected: " + trainingSet.RejectedCount + " + "
                    + (suspiciousNodes.Count - additionalAcceptedVector2GroupPath.Count)
                    + " / " + encodingResult.IdealVectorSet.RejectedCount);

            return additionalAcceptedVector2GroupPath;
        }

        protected IEnumerable<CstNode> GetAllElements(CstNode cst, ISet<string> elementNames) {
            return cst.DescendantsAndSelf()
                    .Where(e => elementNames.Contains(e.Name));
        }

        public bool IsAcceptedUsingOracle(CstNode uppermostNode) {
            return uppermostNode.DescendantsOfSingleAndSelf()
                    .Concat(uppermostNode.AncestorsWithSingleChild())
                    .Where(e => OracleNames.Contains(e.Name))
                    .Any(ProtectedIsAcceptedUsingOracle);
        }

        public int CountUsingOracle(CstNode cst) {
            return LearningExperimentUtil.GetUppermostNodesByNames(cst, OracleNames)
                    .Count(IsAcceptedUsingOracle);
        }

        public abstract bool ProtectedIsAcceptedUsingOracle(CstNode node);

        public virtual FeatureExtractor CreateExtractor() {
            return new FeatureExtractor();
        }

        public virtual IEnumerable<SelectedFragment> AcceptingFragments {
            get { return null; }
        }

        public virtual IEnumerable<SelectedFragment> RejectingFragments {
            get { return Enumerable.Empty<SelectedFragment>(); }
        }
    }

    public interface ILearningExperiment {
        FeatureExtractor CreateExtractor();
        IEnumerable<SelectedFragment> AcceptingFragments { get; }
        IEnumerable<SelectedFragment> RejectingFragments { get; }
    }
}
