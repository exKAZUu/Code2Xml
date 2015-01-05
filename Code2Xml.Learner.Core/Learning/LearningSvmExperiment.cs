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
using System.Numerics;
using Accord.MachineLearning.DecisionTrees;
using Code2Xml.Core.Generators;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Collections.Generic;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
    public abstract class LearningSvmExperiment : ILearningExperiment {
        private readonly LearningAlgorithm _algorithm;

        public class SuspiciousTarget {
            public double Prob { get; set; }
            public BigInteger Feature { get; set; }
        }

        public class LearningResult {
            public GroupInfo Accepted { get; set; }
            public GroupInfo Rejected { get; set; }
        }

        public class GroupInfo {
            public string Key { get; set; }
            public int Index { get; set; }
        }

        public int WrongFeatureCount { get; set; }
        public int WrongElementCount { get; set; }
        protected abstract CstGenerator Generator { get; }
        public abstract bool IsInner { get; }

        public virtual int MaxUp {
            get { return -1; }
        }

        public virtual int MaxLeft {
            get { return -1; }
        }

        public virtual int MaxRight {
            get { return -1; }
        }

        public IList<CstNode> GetRootsUsingOracle(CstNode e) {
            return null;
        }

        public virtual string GetToken(CstNode e) {
            return e.TokenText;
        }

        public Dictionary<BigInteger, CstNode> Feature2Element {
            get { return _feature2Element; }
        }

        public IList<CstNode> WronglyAcceptedElements {
            get {
                return
                        _wronglyAcceptedFeatures.Select(kv => kv.Key)
                                .Select(f => _feature2Element[f])
                                .ToList();
            }
        }

        public IList<CstNode> WronglyRejectedElements {
            get {
                return
                        _wronglyRejectedFeatures.Select(kv => kv.Key)
                                .Select(f => _feature2Element[f])
                                .ToList();
            }
        }

        public IList<CstNode> IdealAcceptedElements {
            get { return _idealAccepted.Keys.Select(f => _feature2Element[f]).ToList(); }
        }

        public IList<CstNode> IdealRejectedElements {
            get { return _idealRejected.Keys.Select(f => _feature2Element[f]).ToList(); }
        }

        private ISet<string> _elementNames;
        private Dictionary<BigInteger, string> _idealAccepted;
        private Dictionary<BigInteger, string> _idealRejected;
        private Dictionary<BigInteger, string> _acceptedTrainingSet;
        private Dictionary<BigInteger, string> _rejectedTrainingSet;
        private Dictionary<BigInteger, CstNode> _feature2Element;

        private readonly List<KeyValuePair<BigInteger, string>> _wronglyAcceptedFeatures =
                new List<KeyValuePair<BigInteger, string>>();

        private readonly List<KeyValuePair<BigInteger, string>> _wronglyRejectedFeatures =
                new List<KeyValuePair<BigInteger, string>>();

        private const int SurroundingLength = 7;
        private const int LearningCount = 5;
        private const int GroupKeyLength = 5;
        private IDictionary<string, BigInteger> _masterFeatures;
        private List<string> _groupKeys;
        private int _acceptingFeatureCount;
        private BigInteger _acceptingMask;
        private BigInteger _rejectingMask;
        private BigInteger _mask;
        public List<SuspiciousTarget> SuspiciousAcceptedInAccepting { get; private set; }
        public List<SuspiciousTarget> SuspiciousRejectedInAccepting { get; private set; }
        private readonly HashSet<string> _initialElementNames;
        private Dictionary<BigInteger, int> _feature2Count;
        private IList<DecisionVariable> _variables;
        private Func<double[], double> _classifier;

        protected LearningSvmExperiment(params string[] elementNames) {
            _algorithm = new SvmLearnerWithLinear();
            _initialElementNames = elementNames.ToHashSet();
        }

        public void Clear() {
            _elementNames.Clear();
            _idealAccepted.Clear();
            _idealRejected.Clear();
            _acceptedTrainingSet.Clear();
            _rejectedTrainingSet.Clear();
            if (_feature2Element != null) {
                _feature2Element.Clear();
            }
            _masterFeatures.Clear();
            _groupKeys.Clear();
            SuspiciousAcceptedInAccepting.Clear();
            SuspiciousRejectedInAccepting.Clear();
            _wronglyAcceptedFeatures.Clear();
            _wronglyRejectedFeatures.Clear();
            _elementNames = null;
            _idealAccepted = null;
            _idealRejected = null;
            _acceptedTrainingSet = null;
            _rejectedTrainingSet = null;
            _feature2Element = null;
            _masterFeatures = null;
            _groupKeys = null;
            SuspiciousAcceptedInAccepting = null;
            SuspiciousRejectedInAccepting = null;
        }

        private static string CommonSuffix(string s1, string s2) {
            var count = Math.Min(s1.Length, s2.Length);
            var ret = "";
            var lastIndex = -1;
            for (int i = 0; i < count; i++) {
                var ch = s1[i];
                if (ch == s2[i]) {
                    ret += ch;
                } else {
                    break;
                }
                if (ch == '>') {
                    lastIndex = i;
                }
            }
            return ret.Substring(0, lastIndex + 1);
        }

        private void UpdateDict(
                Dictionary<BigInteger, string> dict, BigInteger bits, CstNode element) {
            var existingClassifiersStr = dict.GetValueOrDefault(bits);
            IEnumerable<string> classifiers;
            if (IsInner) {
                //element = element.AncestorsOfOnlyChildAndSelf().Last(); // TODO
                // TODO: descendants may be empty list
                var descendants = element.DescendantsOfFirstChild()
                        .Take(GroupKeyLength)
                        .ToList();
                classifiers = descendants.Select(e => e.NameWithId());
                if (descendants[descendants.Count - 1].HasToken) {
                    classifiers = classifiers.Concat(descendants[descendants.Count - 1].TokenText);
                }
            } else {
                //element = element.DescendantsOfOnlyChildAndSelf().Last(); // TODO
                classifiers = element.AncestorsAndSelf()
                        .Take(GroupKeyLength)
                        .Select(e => e.NameWithId());
            }
            var classifiersStre = ">" + element.Name + ">" + string.Join(">", classifiers) + ">";
            if (existingClassifiersStr == null) {
                dict.Add(bits, classifiersStre);
            } else {
                dict[bits] = CommonSuffix(existingClassifiersStr, classifiersStre);
            }
        }

        private static ISet<string> AdoptNodeNames(ICollection<CstNode> outermosts) {
            var name2Count = new Dictionary<string, int>();
            var candidates = outermosts.SelectMany(
                    e => e.DescendantsOfSingleAndSelf());
            foreach (var e in candidates) {
                var count = name2Count.GetValueOrDefault(e.Name);
                name2Count[e.Name] = count + 1;
            }
            return outermosts.Select(
                    e => e.DescendantsOfSingleAndSelf()
                            .Select(e2 => e2.Name)
                            .MaxElementOrDefault(name => name2Count[name]))
                    .ToHashSet();
        }

        public void Learn(
                ICollection<string> allPaths, ICollection<string> seedPaths, StreamWriter writer,
                string projectPath) {
            var allAsts = allPaths.Select(
                    path => Generator.GenerateTreeFromCode(new FileInfo(path), null, true));
            var seedAsts = seedPaths.Select(
                    path => Generator.GenerateTreeFromCode(new FileInfo(path), null, true))
                    .ToList();
            _elementNames = _initialElementNames.ToHashSet();
            foreach (var elementName in _elementNames) {
                Console.WriteLine(elementName);
            }
            var seedAcceptedElements = seedAsts
                    .SelectMany(GetAllElements)
                    .Where(ProtectedIsAcceptedUsingOracle)
                    .ToList();
            Console.WriteLine("Accepted elements: " + seedAcceptedElements.Count);
            if (!seedAcceptedElements.Any()) {
                var es = seedAsts.SelectMany(GetAllElements).ToList();
                foreach (var e in es) {
                    var b = ProtectedIsAcceptedUsingOracle(e);
                }
                Console.WriteLine("buggy");
            }
            ExtractFeatures(allAsts, seedAsts, seedAcceptedElements.ToList());

            _variables = Enumerable.Repeat(0, _masterFeatures.Count)
                    .Select(_ => new DecisionVariable(null, DecisionVariableKind.Discrete))
                    .ToList();

            var count = 0;
            var sumTime = Environment.TickCount;
            while (true) {
                var time = Environment.TickCount;
                count = LearnAndApply(count);
                var ret = AddNewElements(_idealAccepted.Keys);
                if (!ret) {
                    count = 0;
                } else if (count < 0) {
                    break;
                }

                Console.WriteLine("Time: " + (Environment.TickCount - time));
            }
            Console.WriteLine();
            Console.WriteLine("Sum time: " + (Environment.TickCount - sumTime));
            Console.WriteLine(
                    "Required elements: "
                    + (_acceptedTrainingSet.Count + _rejectedTrainingSet.Count) + " / "
                    + (_idealAccepted.Count + _idealRejected.Count));
            if (writer != null) {
                writer.Write(
                        (_acceptedTrainingSet.Count + _rejectedTrainingSet.Count) + " / "
                        + (_idealAccepted.Count + _idealRejected.Count));
                writer.Write(",");
                writer.Flush();
            }

            //ShowBitsInfo();
        }

        public void ExtractFeatures(
                IEnumerable<CstNode> allAsts, IEnumerable<CstNode> seedAsts,
                IList<CstNode> seedElements) {
            var preparingTime = Environment.TickCount;

            var uppermostSeedAcceptedElements = GetMostOuterElements(seedElements).ToHashSet();
            _elementNames = AdoptNodeNames(uppermostSeedAcceptedElements).ToHashSet();
            var seedAcceptedElements = uppermostSeedAcceptedElements
                    .SelectMany(
                            e => e.DescendantsOfSingleAndSelf()
                                    .Where(e2 => _elementNames.Contains(e2.Name)))
                    .ToHashSet();
            var seedRejectedElements = new List<CstNode>();
            foreach (var elementName in _elementNames) {
                Console.WriteLine(elementName);
            }
            if (!seedAcceptedElements.Any()) {
                throw new Exception("There are no seed elements!");
            }

            _idealAccepted = new Dictionary<BigInteger, string>();
            _idealRejected = new Dictionary<BigInteger, string>();
            _acceptedTrainingSet = new Dictionary<BigInteger, string>();
            _rejectedTrainingSet = new Dictionary<BigInteger, string>();
            _feature2Element = new Dictionary<BigInteger, CstNode>();
            _feature2Count = new Dictionary<BigInteger, int>();
            _groupKeys = new List<string> { ">" };
            _masterFeatures = new Dictionary<string, BigInteger>();

            foreach (var ast in seedAsts) {
                Console.Write(".");
                foreach (var e in GetAllElements(ast)) {
                    if (!seedAcceptedElements.Contains(e)) {
                        seedRejectedElements.Add(e);
                    }
                }
            }
            var acceptingFeatures = seedAcceptedElements
                    .GetUnionKeys(SurroundingLength, this)
                    .ToHashSet()
                    .ToList();
            acceptingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            _acceptingFeatureCount = acceptingFeatures.Count;
            var rejectingFeatureSet = seedRejectedElements
                    .GetUnionKeys(SurroundingLength, this)
                    .ToHashSet();
            rejectingFeatureSet.ExceptWith(acceptingFeatures);
            var rejectingFeatures = rejectingFeatureSet.ToList();
            rejectingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));

            var masterBit = BigInteger.One;
            foreach (var predicate in acceptingFeatures) {
                _masterFeatures.Add(predicate, masterBit);
                masterBit <<= 1;
            }
            foreach (var predicate in rejectingFeatures) {
                _masterFeatures.Add(predicate, masterBit);
                masterBit <<= 1;
            }

            _mask = (BigInteger.One << _masterFeatures.Count) - BigInteger.One;
            _acceptingMask = (BigInteger.One << _acceptingFeatureCount) - BigInteger.One;
            _rejectingMask = _mask ^ _acceptingMask;

            foreach (var e in seedAcceptedElements) {
                var bits = e.GetSurroundingPathBits(SurroundingLength, _masterFeatures, this);
                UpdateDict(_idealAccepted, bits, e);
                _acceptedTrainingSet[bits] = _idealAccepted[bits];
                _feature2Element[bits] = e;
                if (_feature2Count.ContainsKey(bits)) {
                    _feature2Count[bits]++;
                } else {
                    _feature2Count[bits] = 1;
                }
            }
            foreach (var e in seedRejectedElements) {
                var bits = e.GetSurroundingPathBits(SurroundingLength, _masterFeatures, this);
                UpdateDict(_idealRejected, bits, e);
                _rejectedTrainingSet[bits] = _idealRejected[bits];
                _feature2Element[bits] = e;
                if (_feature2Count.ContainsKey(bits)) {
                    _feature2Count[bits]++;
                } else {
                    _feature2Count[bits] = 1;
                }
            }

            foreach (var ast in allAsts) {
                Console.Write(".");
                foreach (var e in GetAllElementsWithoutDuplicates(ast)) {
                    var bits = e.GetSurroundingPathBits(SurroundingLength, _masterFeatures, this);
                    if (IsAcceptedUsingOracle(e)) {
                        // TODO: for debug
                        if (_idealRejected.ContainsKey(bits)) {
                            PrintNotDistinguishedElement(e, bits);
                        }
                        UpdateDict(_idealAccepted, bits, e);
                    } else {
                        // TODO: for debug
                        if (_idealAccepted.ContainsKey(bits)) {
                            PrintNotDistinguishedElement(e, bits);
                        }
                        UpdateDict(_idealRejected, bits, e);
                    }
                    _feature2Element[bits] = e;
                    if (_feature2Count.ContainsKey(bits)) {
                        _feature2Count[bits]++;
                    } else {
                        _feature2Count[bits] = 1;
                    }
                }
            }

            if (_idealAccepted.Keys.ToHashSet().Overlaps(_idealRejected.Keys.ToHashSet())) {
                throw new Exception("Master predicates can't classify elements!");
            }

            _variables = Enumerable.Repeat(0, _masterFeatures.Count)
                    .Select(_ => new DecisionVariable(null, DecisionVariableKind.Discrete))
                    .ToList();

            CreateClassifiers(); // for the first time

            Console.WriteLine("Preparing time: " + (Environment.TickCount - preparingTime));
        }

        private void PrintNotDistinguishedElement(CstNode e, BigInteger bits) {
            Console.WriteLine(e.Parent.Name + ", " + e.Name + ", " + e.Code);
            Console.WriteLine(
                    _feature2Element[bits].Parent.Name + ", "
                    + _feature2Element[bits].Name + ", "
                    + _feature2Element[bits].Code);
            IsAcceptedUsingOracle(e);
            bits = e.GetSurroundingPathBits(SurroundingLength, _masterFeatures, this);
        }

        #region Create Classifier

        private void CreateClassifiers() {
            var trainingSet =
                    _acceptedTrainingSet.Select(b => b.Key.BigIntegerToDoubles(_variables.Count))
                            .Concat(
                                    _rejectedTrainingSet.Select(
                                            b => b.Key.BigIntegerToDoubles(_variables.Count)))
                            .ToArray();
            var labels = Enumerable.Repeat(-1, _acceptedTrainingSet.Count)
                    .Concat(Enumerable.Repeat(1, _rejectedTrainingSet.Count))
                    .ToArray();

            var data = new LearningData {
                Inputs = trainingSet,
                Outputs = labels,
                Variables = _variables,
            };

            _classifier = _algorithm.Learn(data);
        }

        #endregion

        public int LearnAndApply(int count) {
            var correctlyAccepted = 0;
            var correctlyRejected = 0;
            var wronglyAccepted = 0;
            var wronglyRejected = 0;
            var correctlyRejectedInRejecting = 0;
            var wronglyRejectedInRejecting = 0;
            var rejectedTargets = new List<SuspiciousTarget>();
            var acceptedTargets = new List<SuspiciousTarget>();
            _wronglyAcceptedFeatures.Clear();
            _wronglyRejectedFeatures.Clear();

            var index = 0;

            foreach (var featureAndGroupKey in _idealAccepted) {
                var feature = featureAndGroupKey.Key;
                var prob = _classifier(feature.BigIntegerToDoubles(_variables.Count));
                var accepted = prob <= 0;
                index++;
                if (!accepted) {
                    wronglyRejected++;
                    WrongElementCount += _feature2Count[feature];
                    _wronglyRejectedFeatures.Add(featureAndGroupKey);
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        rejectedTargets.Add(
                                new SuspiciousTarget {
                                    Feature = feature,
                                    Prob = Math.Abs(prob),
                                });
                    }
                } else {
                    wronglyRejectedInRejecting++;
                    WrongElementCount += _feature2Count[feature];
                    _wronglyRejectedFeatures.Add(featureAndGroupKey);
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        acceptedTargets.Add(
                                new SuspiciousTarget {
                                    Feature = feature,
                                    Prob = Math.Abs(prob),
                                });
                    }
                }
            }

            foreach (var featureAndGroupKey in _idealRejected) {
                var feature = featureAndGroupKey.Key;
                var prob = _classifier(feature.BigIntegerToDoubles(_variables.Count));
                var accepted = prob <= 0;
                index++;
                if (!accepted) {
                    correctlyRejected++;
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        rejectedTargets.Add(
                                new SuspiciousTarget {
                                    Feature = feature,
                                    Prob = Math.Abs(prob),
                                });
                    }
                } else {
                    correctlyRejectedInRejecting++;
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        acceptedTargets.Add(
                                new SuspiciousTarget {
                                    Feature = feature,
                                    Prob = Math.Abs(prob),
                                });
                    }
                }
            }
            Console.WriteLine("done");
            Console.WriteLine(
                    "WA: " + wronglyAccepted + ", WR: " + wronglyRejected + "/"
                    + wronglyRejectedInRejecting + ", CA: "
                    + correctlyAccepted + ", CR: " + correctlyRejected + "/"
                    + correctlyRejectedInRejecting);
            Console.WriteLine(
                    "L: " + (_acceptedTrainingSet.Count + _rejectedTrainingSet.Count));
            WrongFeatureCount = wronglyAccepted + wronglyRejected + wronglyRejectedInRejecting;

            SuspiciousAcceptedInAccepting = new List<SuspiciousTarget>();
            SuspiciousRejectedInAccepting = new List<SuspiciousTarget>();
            switch (count) {
            case 0:
                SuspiciousAcceptedInAccepting = acceptedTargets.OrderBy(t => t.Prob)
                        .Take(LearningCount)
                        .ToList();
                SuspiciousRejectedInAccepting = rejectedTargets.OrderBy(t => t.Prob)
                        .Take(LearningCount)
                        .ToList();
                break;
            case 1:
                SuspiciousAcceptedInAccepting = acceptedTargets.OrderBy(t => t.Prob)
                        .Take(LearningCount)
                        .ToList();
                SuspiciousRejectedInAccepting = rejectedTargets.OrderBy(t => t.Prob)
                        .Take(LearningCount)
                        .ToList();
                return -1;
            default:
                return -1;
            }
            Console.WriteLine(
                    "SA(A): " + SuspiciousAcceptedInAccepting.Count
                    + ", SR(A): " + SuspiciousRejectedInAccepting.Count);

            return count + 1;
        }

        public bool AddNewElements(ICollection<BigInteger> actuallyAcceptedElements) {
            var additionalAccepted =
                    SuspiciousAcceptedInAccepting.Concat(SuspiciousRejectedInAccepting)
                            .Where(t => actuallyAcceptedElements.Contains(t.Feature))
                            .ToList();
            var additionalRejected =
                    SuspiciousAcceptedInAccepting.Concat(SuspiciousRejectedInAccepting)
                            .Where(t => !actuallyAcceptedElements.Contains(t.Feature))
                            .ToList();
            var foundWronglyRejected = SuspiciousRejectedInAccepting
                    .Count(t => actuallyAcceptedElements.Contains(t.Feature));
            var foundWronglyAccepted = SuspiciousAcceptedInAccepting
                    .Count(t => !actuallyAcceptedElements.Contains(t.Feature));

            var additionalAcceptedCount = additionalAccepted.Count;
            var additionalRejectedCount = additionalRejected.Count;

            Console.WriteLine(
                    "Accepted: " + _acceptedTrainingSet.Count + " + " + additionalAcceptedCount
                    + " / " + _idealAccepted.Count);
            Console.WriteLine(
                    "Rejected: " + _rejectedTrainingSet.Count + " + " + additionalRejectedCount
                    + " / " + _idealRejected.Count);
            foreach (var suspiciousTarget in additionalAccepted) {
                _acceptedTrainingSet.Add(suspiciousTarget.Feature, "");
            }
            foreach (var suspiciousTarget in additionalRejected) {
                _rejectedTrainingSet.Add(suspiciousTarget.Feature, "");
            }

            CreateClassifiers();
            var ret = foundWronglyRejected + foundWronglyAccepted == 0;
            return ret;
        }

        private static int CountBits(BigInteger bits) {
            var count = 0;
            while (bits != BigInteger.Zero) {
                count += (int)(bits & BigInteger.One);
                bits >>= 1;
            }
            return count;
        }

        private int CountAcceptingBits(BigInteger bits) {
            return CountBits(bits & _acceptingMask);
        }

        private int CountRejectingBits(BigInteger bits) {
            return CountBits(bits >> _acceptingFeatureCount);
        }

        private void ShowBitsInfo() {
            CreateClassifiers();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(A): ");
            foreach (var f in _idealAccepted.Keys) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(A): ");
            foreach (var f in _idealRejected.Keys) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(A): ");
            foreach (var f in _wronglyAcceptedFeatures.Select(kv => kv.Key)) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(A): ");
            foreach (var f in _wronglyRejectedFeatures.Select(kv => kv.Key)) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(R): ");
            foreach (var f in _idealAccepted.Keys) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(R): ");
            foreach (var f in _idealRejected.Keys) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(R): ");
            foreach (var f in _wronglyAcceptedFeatures.Select(kv => kv.Key)) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(R): ");
            foreach (var f in _wronglyRejectedFeatures.Select(kv => kv.Key)) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
        }

        private static IEnumerable<CstNode> GetMostOuterElements(IEnumerable<CstNode> elements) {
            return elements.Select(e => e.AncestorsWithSingleChildAndSelf().Last());
        }

        protected IEnumerable<CstNode> GetAllElements(CstNode ast) {
            return ast.DescendantsAndSelf()
                    .Where(e => _elementNames.Contains(e.Name));
        }

        protected IEnumerable<CstNode> GetAllElementsWithoutDuplicates(CstNode ast) {
            return ast.DescendantsAndSelf()
                    .Where(e => _elementNames.Contains(e.Name))
                    .Where(
                            e => e.AncestorsWithSingleChild()
                                    .All(a => !_elementNames.Contains(a.Name)));
        }

        public bool IsAcceptedUsingOracle(CstNode e) {
            return e.DescendantsOfSingleAndSelf()
                    .Where(e2 => _elementNames.Contains(e2.Name))
                    .Any(ProtectedIsAcceptedUsingOracle);
        }

        protected abstract bool ProtectedIsAcceptedUsingOracle(CstNode e);
    }
}