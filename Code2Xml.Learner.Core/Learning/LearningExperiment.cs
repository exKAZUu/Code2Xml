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
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using Code2Xml.Core.Generators;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Collections.Generic;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
    public abstract class LearningExperiment : ILearningExperiment {
        public class SuspiciousTarget {
            public int BitsCount { get; set; }
            public bool Used { get; set; }
            public BigInteger Feature { get; set; }
            public string GroupKey { get; set; }
        }

        public class LearningResult {
            public GroupInfo Accepted { get; set; }
            public GroupInfo Rejected { get; set; }
        }

        public class GroupInfo {
            public string Key { get; set; }
            public int Index { get; set; }
        }

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

        public virtual string GetToken(CstNode e) {
            if (e.TokenText.Length == 1) {
                var ch = e.TokenText[0];
                if (char.IsDigit(ch)) {
                    return "0";
                }
                if (char.IsLetter(ch)) {
                    return "i";
                }
            }
            return e.TokenText;
        }

        public IList<CstNode> IdealAcceptedElements {
            get {
                return
                        _idealAcceptedVector2GroupKey.Keys.Select(f => _featureBit2Element[f])
                                .ToList();
            }
        }

        public IList<CstNode> IdealRejectedElements {
            get {
                return
                        _idealRejectedVector2GroupKey.Keys.Select(f => _featureBit2Element[f])
                                .ToList();
            }
        }

        private const int SurroundingLength = 7;
        private const int LearningCount = 5;
        private const int GroupKeyLength = 5;
        private const int TargetCount = 5;
        private const int StronglyTargetCount = 10000000;
        private const int ThresholdFeatureCount = 10000000;

        private Dictionary<BigInteger, string> _idealAcceptedVector2GroupKey;
        private Dictionary<BigInteger, string> _idealRejectedVector2GroupKey;
        private Dictionary<BigInteger, string> _trainingAcceptedVector2GroupKey;
        private Dictionary<BigInteger, string> _trainingRejectedVector2GroupKey;
        private Dictionary<BigInteger, CstNode> _featureBit2Element;

        private ISet<string> _selectedNames;
        private IDictionary<string, BigInteger> _key2Feature;
        private List<string> _groupKeys;
        private Dictionary<BigInteger, int> _feature2GroupIndex;
        private int _acceptingFeatureCount;
        private BigInteger _acceptingMask;
        private BigInteger _rejectingMask;
        private BigInteger _mask;
        public List<SuspiciousTarget> SuspiciousTargets { get; private set; }
        private readonly HashSet<string> _oracleNames;
        private Dictionary<BigInteger, int> _featureBit2Count;
        private Dictionary<BigInteger, string> _featureBit2Path;
        private int _seedElementCount;
        private int _seedAbstractCount;
        private int _acceptedSeedElementCount;

        protected LearningExperiment(params string[] elementNames) {
            _oracleNames = elementNames.ToHashSet();
        }

        public IList<Tuple<List<string>, List<string>>> GetFeatures(IList<ClassifierUnit> classifiers) {
            return classifiers.Select(
                    cl => Tuple.Create(
                            LearningExperimentUtil
                                    .GetFeatureByVector(_key2Feature, cl.Accepting)
                                    .ToList(),
                            LearningExperimentUtil
                                    .GetFeatureByVector(_key2Feature, cl.Rejecting)
                                    .ToList()))
                    .ToList();
        }

        public string GetClassifierSummary(IList<ClassifierUnit> classifiers) {
            return "AP: "
                   + string.Join(", ", classifiers.Select(c => CountBits(c.Accepting)))
                   + ", RP: "
                   + string.Join(", ", classifiers.Select(c => CountRejectingBits(c.Rejecting)));
        }

        public void Clear() {
            _idealAcceptedVector2GroupKey.Clear();
            _idealRejectedVector2GroupKey.Clear();
            _trainingAcceptedVector2GroupKey.Clear();
            _trainingRejectedVector2GroupKey.Clear();
            if (_featureBit2Element != null) {
                _featureBit2Element.Clear();
            }
            _selectedNames.Clear();
            _key2Feature.Clear();
            _groupKeys.Clear();
            SuspiciousTargets.Clear();
            _idealAcceptedVector2GroupKey = null;
            _idealRejectedVector2GroupKey = null;
            _trainingAcceptedVector2GroupKey = null;
            _trainingRejectedVector2GroupKey = null;
            _featureBit2Element = null;
            _key2Feature = null;
            _groupKeys = null;
            SuspiciousTargets = null;
        }

        private void UpdateGroupKey(
                Dictionary<BigInteger, string> dict, BigInteger feature, CstNode node) {
            var groupKey = GetGroupKeyFromNode(node);
            var existingGroupKey = dict.GetValueOrDefault(feature);
            if (existingGroupKey == null) {
                dict.Add(feature, groupKey);
            } else {
                dict[feature] = LearningExperimentUtil.CommonSuffix(existingGroupKey, groupKey);
            }
        }

        /// <summary>
        /// Get a group key from the specified node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetGroupKeyFromNode(CstNode node) {
            IEnumerable<string> groupKeySequence;
            if (IsInner) {
                //node = node.AncestorsOfOnlyChildAndSelf().Last(); // TODO
                // TODO: descendants may be empty list
                groupKeySequence = node.DescendantsOfFirstChild()
                        .Take(GroupKeyLength)
                        .Select(e => e.HasToken ? e.RuleId + "-" + GetToken(e) : e.RuleId);
            } else {
                //node = node.DescendantsOfOnlyChildAndSelf().Last(); // TODO
                groupKeySequence = node.AncestorsAndSelf()
                        .Take(GroupKeyLength)
                        .Select(e => e.HasToken ? e.RuleId + "-" + GetToken(e) : e.RuleId);
            }

            return ">" + node.Name + ">" + string.Join(">", groupKeySequence) + ">";
        }

        public ExperimentalResult Apply(
                StreamWriter writer, ICollection<string> codePaths, string searchPattern) {
            var allCsts = GenerateValidCsts(codePaths);
            _idealAcceptedVector2GroupKey.Clear();
            _idealRejectedVector2GroupKey.Clear();
            _featureBit2Element.Clear();
            _featureBit2Count.Clear();
            _featureBit2Path.Clear();
            _trainingAcceptedVector2GroupKey.Clear();
            _trainingRejectedVector2GroupKey.Clear();

            EncodeTargetCsts(codePaths, allCsts);

            UpdateGroup();
            _trainingAcceptedVector2GroupKey.AddRange(_idealAcceptedVector2GroupKey);
            _trainingRejectedVector2GroupKey.AddRange(_idealRejectedVector2GroupKey);
            var count = 10;
            var time = Environment.TickCount;
            var result = LearnAndApply(ref count);
            Console.WriteLine("Time: " + (Environment.TickCount - time));

            if (writer != null) {
                writer.Write(
                        _idealAcceptedVector2GroupKey.Concat(_idealRejectedVector2GroupKey)
                                .Sum(f => _featureBit2Count[f.Key]));
                writer.Write(",");
                writer.Write(
                        _trainingAcceptedVector2GroupKey.Concat(_trainingRejectedVector2GroupKey)
                                .Sum(f => _featureBit2Count[f.Key]));
                writer.Write(",");
                writer.Write(
                        _idealAcceptedVector2GroupKey.Count + _idealRejectedVector2GroupKey.Count);
                writer.Write(",");
                writer.Write(
                        _trainingAcceptedVector2GroupKey.Count
                        + _trainingRejectedVector2GroupKey.Count);
                writer.Write(",");
                writer.Write(_seedElementCount);
                writer.Write(",");
                writer.Write(_seedAbstractCount);
                writer.Write(",");
                writer.Write(_acceptedSeedElementCount);
                writer.Write(",");
            }

            return result;
        }

        private void EncodeTargetCsts(ICollection<string> codePaths, IEnumerable<CstNode> allCsts) {
            var fileName = codePaths.Count > 0
                    ? string.Join(",", codePaths).GetHashCode() + "_" +
                      (codePaths.First() + "," + codePaths.Last()).GetHashCode() + ".features"
                    : null;
            var formatter = new BinaryFormatter();
            if (false && fileName != null && File.Exists(fileName)) {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
                    _idealRejectedVector2GroupKey =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(fs);
                    _idealAcceptedVector2GroupKey =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(fs);
                    _featureBit2Count = (Dictionary<BigInteger, int>)formatter.Deserialize(fs);
                }
            } else {
                foreach (var cst in allCsts) {
                    Console.Write(".");
                    ConvertUppermostNodesToVectors(cst, _selectedNames);
                }
                if (fileName != null) {
                    using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                        formatter.Serialize(fs, _idealRejectedVector2GroupKey);
                        formatter.Serialize(fs, _idealAcceptedVector2GroupKey);
                        formatter.Serialize(fs, _featureBit2Count);
                    }
                }
            }
        }

        public ExperimentalResult Learn(
                ICollection<string> seedPaths, StreamWriter writer,
                ICollection<string> codePaths, string searchPattern) {
            var allCsts = GenerateValidCsts(codePaths);
            var seedCsts = GenerateValidCsts(seedPaths).ToList();
            var seedNodes = seedCsts
                    .SelectMany(cst => GetUppermostNodesByNames(cst, _oracleNames))
                    .Where(ProtectedIsAcceptedUsingOracle)
                    .ToList();
            Console.WriteLine("Accepted elements: " + seedNodes.Count);
            ExtractFeatures(codePaths, allCsts, seedCsts, seedNodes);

            UpdateGroup();
            CreateClassifiers(_trainingAcceptedVector2GroupKey); // for the first time

            var count = 0;
            var sumTime = Environment.TickCount;
            ExperimentalResult result;
            while (true) {
                var time = Environment.TickCount;
                result = LearnAndApply(ref count);
                var ret = AddNewElements(_idealAcceptedVector2GroupKey.Keys);
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
                    + (_trainingAcceptedVector2GroupKey.Count
                       + _trainingRejectedVector2GroupKey.Count) + " / "
                    + (_idealAcceptedVector2GroupKey.Count + _idealRejectedVector2GroupKey.Count));
            if (writer != null) {
                writer.Write(
                        _idealAcceptedVector2GroupKey.Concat(_idealRejectedVector2GroupKey)
                                .Sum(f => _featureBit2Count[f.Key]) - _seedElementCount);
                writer.Write(",");
                writer.Write(
                        _trainingAcceptedVector2GroupKey.Concat(_trainingRejectedVector2GroupKey)
                                .Sum(f => _featureBit2Count[f.Key]) - _seedElementCount);
                writer.Write(",");
                writer.Write(
                        _idealAcceptedVector2GroupKey.Count + _idealRejectedVector2GroupKey.Count
                        - _seedAbstractCount);
                writer.Write(",");
                writer.Write(
                        _trainingAcceptedVector2GroupKey.Count
                        + _trainingRejectedVector2GroupKey.Count - _seedAbstractCount);
                writer.Write(",");
                writer.Write(_seedElementCount);
                writer.Write(",");
                writer.Write(_seedAbstractCount);
                writer.Write(",");
                writer.Write(_acceptedSeedElementCount);
                writer.Write(",");
            }

            foreach (var groupKey in _groupKeys) {
                Console.WriteLine(groupKey);
            }

            //ShowBitsInfo();

            return result;
        }

        private IEnumerable<CstNode> GenerateValidCsts(IEnumerable<string> codePaths) {
            return codePaths.Select(
                    path => {
                        try {
                            return Generator.GenerateTreeFromCode(
                                    new FileInfo(path), null, true);
                        } catch {
                            return null;
                        }
                    })
                    .Where(t => t != null);
        }

        private void ExtractFeatures(
                ICollection<string> codePaths, IEnumerable<CstNode> allCsts, IList<CstNode> seedCsts,
                IList<CstNode> seedNodes) {
            var preparingTime = Environment.TickCount;

            var uppermostSeedAcceptedNodes = SelectUppermostNodes(seedNodes)
                    .ToHashSet();
            _selectedNames = LearningExperimentUtil.AdoptNodeNames(uppermostSeedAcceptedNodes)
                    .ToHashSet();
            _groupKeys = _selectedNames.Select(n => ">" + n + ">")
                    .ToList();

            var seedAcceptedNodes = uppermostSeedAcceptedNodes
                    .Select(
                            e => e.DescendantsOfSingleAndSelf()
                                    .First(e2 => _selectedNames.Contains(e2.Name)))
                    .ToHashSet();

            var uppermostSeedAcceptedNodes2 = seedCsts
                    .SelectMany(cst => GetUppermostNodesByNames(cst, _selectedNames))
                    .Where(ProtectedIsAcceptedUsingOracle)
                    .ToList();
            var b1 = !uppermostSeedAcceptedNodes.All(IsAcceptedUsingOracle);
            var b2 = SelectUppermostNodes(uppermostSeedAcceptedNodes2)
                    .Any(e => !uppermostSeedAcceptedNodes.Contains(e));
            var b3 = uppermostSeedAcceptedNodes.Count != uppermostSeedAcceptedNodes2.Count;
            Console.WriteLine("Initial: " + string.Join(", ", _oracleNames));
            Console.WriteLine("Learned: " + string.Join(", ", _selectedNames));
            if (b1 || b2 || b3) {
                Console.WriteLine("--------------------------------------------------");
                foreach (var e in uppermostSeedAcceptedNodes) {
                    Console.WriteLine(e);
                }
                Console.WriteLine("--------------------------------------------------");
                foreach (var e in uppermostSeedAcceptedNodes2) {
                    Console.WriteLine(e);
                }
                throw new Exception("Wrong Oracle.");
            }
            var seedRejectedNodes = new List<CstNode>();
            if (!seedAcceptedNodes.Any()) {
                throw new Exception("There are no seed elements!");
            }

            _idealAcceptedVector2GroupKey = new Dictionary<BigInteger, string>();
            _idealRejectedVector2GroupKey = new Dictionary<BigInteger, string>();
            _trainingAcceptedVector2GroupKey = new Dictionary<BigInteger, string>();
            _trainingRejectedVector2GroupKey = new Dictionary<BigInteger, string>();
            _featureBit2Element = new Dictionary<BigInteger, CstNode>();
            _featureBit2Count = new Dictionary<BigInteger, int>();
            _featureBit2Path = new Dictionary<BigInteger, string>();
            // TODO: Maybe this initialization is wrong
            // _groupKeys = new List<string> { ">" };
            _key2Feature = new Dictionary<string, BigInteger>();

            foreach (var cst in seedCsts) {
                Console.Write(".");
                foreach (var e in GetUppermostNodesByNames(cst, _selectedNames)) {
                    if (!seedAcceptedNodes.Contains(e)) {
                        seedRejectedNodes.Add(e);
                    }
                }
            }
            var acceptingFeatures = seedAcceptedNodes
                    .GetUnionKeys(SurroundingLength, this)
                    .ToHashSet()
                    .ToList();
            acceptingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            _acceptingFeatureCount = acceptingFeatures.Count;
            var rejectingFeatureSet = seedRejectedNodes
                    .GetUnionKeys(SurroundingLength, this)
                    .ToHashSet();
            rejectingFeatureSet.ExceptWith(acceptingFeatures);
            var rejectingFeatures = rejectingFeatureSet.ToList();
            rejectingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));

            Console.WriteLine(
                    "Feature Count: " + _acceptingFeatureCount + ", " + rejectingFeatures.Count);

            var masterFeatureVector = BigInteger.One;
            foreach (var featureStr in acceptingFeatures) {
                _key2Feature.Add(featureStr, masterFeatureVector);
                _featureBit2Path.Add(masterFeatureVector, featureStr);
                masterFeatureVector <<= 1;
            }
            foreach (var featureStr in rejectingFeatures) {
                _key2Feature.Add(featureStr, masterFeatureVector);
                _featureBit2Path.Add(masterFeatureVector, featureStr);
                masterFeatureVector <<= 1;
            }

            _mask = (BigInteger.One << _key2Feature.Count) - BigInteger.One;
            _acceptingMask = (BigInteger.One << _acceptingFeatureCount) - BigInteger.One;
            _rejectingMask = _mask ^ _acceptingMask;

            _acceptedSeedElementCount = seedAcceptedNodes.Count;
            _seedElementCount = _acceptedSeedElementCount + seedRejectedNodes.Count;
            _seedAbstractCount = 0;

            EncodeSeedNodes(
                    seedAcceptedNodes, _idealAcceptedVector2GroupKey,
                    _trainingAcceptedVector2GroupKey);
            EncodeSeedNodes(
                    seedRejectedNodes, _idealRejectedVector2GroupKey,
                    _trainingRejectedVector2GroupKey);

            EncodeTargetCsts(codePaths, allCsts);

            Console.WriteLine(
                    "Unique Element Count: "
                    + (_idealAcceptedVector2GroupKey.Count + _idealRejectedVector2GroupKey.Count));

            if (_idealAcceptedVector2GroupKey.Keys.ToHashSet()
                    .Overlaps(_idealRejectedVector2GroupKey.Keys.ToHashSet())) {
                throw new Exception("Master predicates can't classify elements!");
            }

            Console.WriteLine("Preparing time: " + (Environment.TickCount - preparingTime));
        }

        private void EncodeSeedNodes(
                IEnumerable<CstNode> seedNodes,
                Dictionary<BigInteger, string> idealVector2GroupKey,
                Dictionary<BigInteger, string> trainingVector2GroupKey) {
            foreach (var e in seedNodes) {
                var feature = e.GetSurroundingPathBits(SurroundingLength, _key2Feature, this);
                UpdateGroupKey(idealVector2GroupKey, feature, e);
                trainingVector2GroupKey[feature] = idealVector2GroupKey[feature];
                _featureBit2Element[feature] = e;
                if (_featureBit2Count.ContainsKey(feature)) {
                    _featureBit2Count[feature]++;
                } else {
                    _featureBit2Count[feature] = 1;
                    _seedAbstractCount++;
                }
            }
        }

        private void ConvertUppermostNodesToVectors(CstNode cst, ISet<string> selectedNames) {
            foreach (var uppermostNode in GetUppermostNodesByNames(cst, selectedNames)) {
                var vector = uppermostNode.GetSurroundingPathBits(
                        SurroundingLength, _key2Feature, this);
                if (IsAcceptedUsingOracle(uppermostNode)) {
                    // TODO: for debug
                    if (_idealRejectedVector2GroupKey.ContainsKey(vector)) {
                        PrintNotDistinguishedElement(uppermostNode, vector);
                    }
                    UpdateGroupKey(_idealAcceptedVector2GroupKey, vector, uppermostNode);
                } else {
                    // TODO: for debug
                    if (_idealAcceptedVector2GroupKey.ContainsKey(vector)) {
                        PrintNotDistinguishedElement(uppermostNode, vector);
                    }
                    UpdateGroupKey(_idealRejectedVector2GroupKey, vector, uppermostNode);
                }
                _featureBit2Element[vector] = uppermostNode;
                if (_featureBit2Count.ContainsKey(vector)) {
                    _featureBit2Count[vector]++;
                } else {
                    _featureBit2Count[vector] = 1;
                }
            }
        }

        private void PrintNotDistinguishedElement(CstNode e, BigInteger feautre) {
            Console.WriteLine(e.Parent.Name + ", " + e.Name + ", " + e.Code);
            Console.WriteLine(
                    _featureBit2Element[feautre].Parent.Name + ", "
                    + _featureBit2Element[feautre].Name + ", "
                    + _featureBit2Element[feautre].Code);
            IsAcceptedUsingOracle(e);
            e.GetSurroundingPathBits(SurroundingLength, _key2Feature, this);
        }

        private int GetGroupIndex(BigInteger feature) {
            return _feature2GroupIndex[feature];
        }

        private int GetGroupIndexWithoutCache(string groupKey) {
            for (int i = _groupKeys.Count - 1; i >= 0; i--) {
                if (groupKey.StartsWith(_groupKeys[i])) {
                    return i;
                }
            }
            throw new Exception("Can't find the given group key: " + groupKey);
        }

        #region Create Classifier

        private bool UpdateClassifiers(
                ICollection<KeyValuePair<BigInteger, string>> acceptedTrainingSet,
                List<ClassifierUnit> classifiers) {
            UpdateRejectingClassifiers(acceptedTrainingSet, classifiers);
            var result = UpdateAcceptingClassifiers(acceptedTrainingSet, classifiers);
            if (result == null) {
                return true;
            }
            var count = _groupKeys.Count;
            var updated = false;
            if (result.Accepted != null
                && result.Accepted.Key != _groupKeys[result.Accepted.Index]) {
                updated |= AddNewGroup(result.Accepted);
            }
            if (result.Rejected.Key != _groupKeys[result.Rejected.Index]) {
                updated |= AddNewGroup(result.Rejected);
            }
            if (updated) {
                UpdateGroup();
            }
            // ReSharper disable once PossibleUnintendedReferenceComparison
            if (_groupKeys.Count == count
                && acceptedTrainingSet == _trainingAcceptedVector2GroupKey) {
                throw new Exception("Fail to learn rules");
            }
            Console.WriteLine("Groups: " + _groupKeys.Count + " (" + count + ")");
            return false;
        }

        private List<ClassifierUnit> CreateClassifiers(
                ICollection<KeyValuePair<BigInteger, string>> acceptedTrainingSet) {
            var classifiers = InitializeClassifiers();
            while (true) {
                if (UpdateClassifiers(_trainingAcceptedVector2GroupKey, classifiers)) {
                    break;
                }
            }
            return classifiers;
        }

        private List<ClassifierUnit> CreateClassifiers(
                ICollection<KeyValuePair<BigInteger, string>> acceptedTrainingSet, List<ClassifierUnit> classifiers) {
            while (true) {
                // Use whole training set after the first iteration
                acceptedTrainingSet = _trainingAcceptedVector2GroupKey;
                classifiers = InitializeClassifiers();
            }
        }

        private LearningResult UpdateAcceptingClassifiers(
                ICollection<KeyValuePair<BigInteger, string>> acceptedTrainingSet, IList<ClassifierUnit> classifiers) {
            if (acceptedTrainingSet.Count == 0) {
                var rejectedGroupInfo = CanReject(classifiers);
                if (rejectedGroupInfo != null) {
                    return new LearningResult {
                        Rejected = rejectedGroupInfo,
                        Accepted = null,
                    };
                }
                return null;
            }
            foreach (var featureAndGroupKey in acceptedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                classifiers[groupIndex].Accepting &= feature;
                var rejectedGroupInfo = CanReject(classifiers);
                if (rejectedGroupInfo != null) {
                    return new LearningResult {
                        Rejected = rejectedGroupInfo,
                        Accepted = new GroupInfo { Index = groupIndex, Key = groupKey },
                    };
                }
            }
            return null;
        }

        private void UpdateRejectingClassifiers(
                IEnumerable<KeyValuePair<BigInteger, string>> acceptedTrainingSet, IList<ClassifierUnit> classifiers) {
            var count = classifiers.Count;
            for (int i = 0; i < count; i++) {
                classifiers[i].Rejecting ^= _rejectingMask;
            }
            foreach (var featureAndGroupKey in acceptedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var iGroupKey = GetGroupIndex(feature);
                classifiers[iGroupKey].Rejecting |= feature;
            }
            for (int i = 0; i < count; i++) {
                classifiers[i].Rejecting ^= _rejectingMask;
                classifiers[i].Rejecting &= _rejectingMask;
            }
        }

        private bool AddNewGroup(GroupInfo info) {
            var i = info.Key.IndexOf('>', _groupKeys[info.Index].Length + 1);
            var newGroupKey = info.Key.Substring(0, i + 1);
            if (!_groupKeys.Contains(newGroupKey)) {
                _groupKeys.Add(newGroupKey);
                return true;
            }
            return false;
        }

        private void UpdateGroup() {
            _feature2GroupIndex = new Dictionary<BigInteger, int>();
            foreach (var kv in _idealAcceptedVector2GroupKey) {
                var index = GetGroupIndexWithoutCache(kv.Value);
                _feature2GroupIndex.Add(kv.Key, index);
            }
            foreach (var kv in _idealRejectedVector2GroupKey) {
                var index = GetGroupIndexWithoutCache(kv.Value);
                _feature2GroupIndex.Add(kv.Key, index);
            }
        }

        private List<ClassifierUnit> InitializeClassifiers() {
            return Enumerable.Repeat(
                    new ClassifierUnit(_acceptingMask, _rejectingMask), _groupKeys.Count)
                    .Select(_ => new ClassifierUnit(_acceptingMask, _rejectingMask))
                    .ToList();
        }

        #endregion

        public ExperimentalResult LearnAndApply(ref int count) {
            var result = new ExperimentalResult(_featureBit2Element, _featureBit2Path);

            var classifiers = _classifiers;
            var correctlyAccepted = 0;
            var correctlyRejected = 0;
            var wronglyAccepted = 0;
            var wronglyRejected = 0;
            var correctlyRejectedInRejecting = 0;
            var wronglyRejectedInRejecting = 0;
            var rejectAccept = new List<List<SuspiciousTarget>>();
            var rejectReject = new List<List<SuspiciousTarget>>();
            var acceptAccept = new List<List<SuspiciousTarget>>();
            var acceptReject = new List<List<SuspiciousTarget>>();
            for (int i = 0; i < _groupKeys.Count; i++) {
                rejectAccept.Add(new List<SuspiciousTarget>());
                rejectReject.Add(new List<SuspiciousTarget>());
                acceptAccept.Add(new List<SuspiciousTarget>());
                acceptReject.Add(new List<SuspiciousTarget>());
            }

            foreach (var featureAndGroupKey in _idealAcceptedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                var rejected = IsRejected(feature, classifiers[groupIndex].Rejecting);
                var accepted = IsAccepted(feature, classifiers[groupIndex].Accepting);
                if (!_trainingAcceptedVector2GroupKey.ContainsKey(feature)
                    && !_trainingRejectedVector2GroupKey.ContainsKey(feature)) {
                    var target = new SuspiciousTarget {
                        Feature = feature,
                        GroupKey = groupKey,
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
                    result.WrongElementCount += _featureBit2Count[feature];
                    result.WronglyRejectedFeatures.Add(feature);
                } else if (!rejected) {
                    correctlyAccepted++;
                } else {
                    wronglyRejectedInRejecting++;
                    result.WrongElementCount += _featureBit2Count[feature];
                    result.WronglyRejectedFeatures.Add(feature);
                }
            }

            foreach (var featureAndGroupKey in _idealRejectedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                var rejected = IsRejected(feature, classifiers[groupIndex].Rejecting);
                var accepted = IsAccepted(feature, classifiers[groupIndex].Accepting);
                if (!_trainingAcceptedVector2GroupKey.ContainsKey(feature)
                    && !_trainingRejectedVector2GroupKey.ContainsKey(feature)) {
                    var target = new SuspiciousTarget {
                        Feature = feature,
                        GroupKey = groupKey,
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
                    result.WrongElementCount += _featureBit2Count[feature];
                    result.WronglyAcceptedFeatures.Add(feature);
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
                    + (_trainingAcceptedVector2GroupKey.Count
                       + _trainingRejectedVector2GroupKey.Count) + ", AF: "
                    + string.Join(", ", classifiers.Select(c => CountBits(c.Accepting))) + ", RF: "
                    + string.Join(", ", classifiers.Select(c => CountRejectingBits(c.Rejecting))));
            result.WrongFeatureCount = wronglyAccepted + wronglyRejected
                                       + wronglyRejectedInRejecting;

            SuspiciousTargets = new List<SuspiciousTarget>();
            switch (count) {
            case 0:
                var time1 = Environment.TickCount;
                SelectSuspicioutAcceptedNodes(acceptAccept, _classifiers);
                SelectSuspicioutAcceptedNodes(acceptReject, _classifiers);
                SelectSuspicioutRejectedNodes(acceptAccept, _classifiers);
                SelectSuspicioutRejectedNodes(rejectAccept, _classifiers);

                SelectNodesForFastAcceptanceLearning(rejectAccept, _classifiers);
                //SelectNodesForSlowAcceptanceLearning(rejectAccept);
                SelectNodesForFastAcceptanceLearning(rejectReject, _classifiers);
                //SelectNodesForSlowAcceptanceLearning(rejectReject);

                SelectNodesForFastRejectionLearning(acceptReject, _classifiers);
                //SelectNodesForSlowRejectionLearning(acceptReject);
                SelectNodesForFastRejectionLearning(rejectReject, _classifiers);
                //SelectNodesForSlowRejectionLearning(rejectReject);
                Console.WriteLine(
                        "SelectSuspicioutAcceptedNodes: " + (Environment.TickCount - time1));
                break;
            case 1:
                var time2 = Environment.TickCount;
                //SelectSuspicioutAcceptedNodesStrongly(acceptAccept);
                //SelectSuspicioutAcceptedNodesStrongly(acceptReject);
                //SelectSuspicioutRejectedNodesStrongly(acceptAccept);
                //SelectSuspicioutRejectedNodesStrongly(rejectAccept);

                //SelectNodesForFastAcceptanceLearningStrongly(rejectAccept);
                SelectNodesForSlowAcceptanceLearningStrongly(rejectAccept, _classifiers);
                //SelectNodesForFastAcceptanceLearningStrongly(rejectReject);
                SelectNodesForSlowAcceptanceLearningStrongly(rejectReject, _classifiers);

                //SelectNodesForFastRejectionLearningStrongly(acceptReject);
                SelectNodesForSlowRejectionLearningStrongly(acceptReject, _classifiers);
                //SelectNodesForFastRejectionLearningStrongly(rejectReject);
                SelectNodesForSlowRejectionLearningStrongly(rejectReject, _classifiers);
                Console.WriteLine(
                        "SelectSuspicioutAcceptedNodesStrongly: " + (Environment.TickCount - time2));
                break;
            default:
                count = -1;
                return result;
            }
            Console.WriteLine("Suspicious nodes: " + SuspiciousTargets.Count);
            count++;
            return result;
        }

        public bool AddNewElements(ICollection<BigInteger> actuallyAcceptedElements) {
            var additionalAccepted = new List<KeyValuePair<BigInteger, string>>();
            var additionalRejected = new List<KeyValuePair<BigInteger, string>>();
            foreach (var t in SuspiciousTargets) {
                if (actuallyAcceptedElements.Contains(t.Feature)) {
                    additionalAccepted.Add(
                            new KeyValuePair<BigInteger, string>(t.Feature, t.GroupKey));
                } else {
                    additionalRejected.Add(
                            new KeyValuePair<BigInteger, string>(t.Feature, t.GroupKey));
                }
            }

            var additionalAcceptedCount = additionalAccepted.Count;
            var additionalRejectedCount = additionalRejected.Count;

            Console.WriteLine(
                    "Accepted: " + _trainingAcceptedVector2GroupKey.Count + " + "
                    + additionalAcceptedCount
                    + " / " + _idealAcceptedVector2GroupKey.Count);
            Console.WriteLine(
                    "Rejected: " + _trainingRejectedVector2GroupKey.Count + " + "
                    + additionalRejectedCount
                    + " / " + _idealRejectedVector2GroupKey.Count);
            foreach (var featureAndGroupKey in additionalAccepted) {
                _trainingAcceptedVector2GroupKey.Add(
                        featureAndGroupKey.Key, featureAndGroupKey.Value);
            }
            foreach (var featureAndGroupKey in additionalRejected) {
                _trainingRejectedVector2GroupKey.Add(
                        featureAndGroupKey.Key, featureAndGroupKey.Value);
            }

            var lastClassifiers = _classifiers.Select(c => c.Clone()).ToList();
            CreateClassifiers(additionalAccepted);
            var ret = lastClassifiers.SequenceEqual(_classifiers);
            return ret;
        }

        #region SelectNextElements

        private List<SuspiciousTarget> SelectSuspiciousElementsWithMaskWithSmallGrowing(
                List<List<SuspiciousTarget>> suspiciousElementsList, BigInteger xor, BigInteger mask) {
            var suspiciousElements = new List<SuspiciousTarget>();
            for (int i = 0; i < suspiciousElementsList.Count; i++) {
                var feature = BigInteger.Zero;
                var list = suspiciousElementsList[i];
                while (true) {
                    var minDiffCount = int.MaxValue;
                    SuspiciousTarget newTarget = null;
                    foreach (var t in list) {
                        var newFeature = (feature | (t.Feature ^ xor)) & mask;
                        var diff = newFeature ^ feature;
                        var diffCount = CountBits(diff);
                        if (diffCount > 0 && minDiffCount > diffCount) {
                            minDiffCount = diffCount;
                            feature = newFeature;
                            newTarget = t;
                        }
                    }
                    if (newTarget != null) {
                        suspiciousElements.Add(newTarget);
                    } else {
                        break;
                    }
                }
            }
            return suspiciousElements;
        }

        private List<SuspiciousTarget> SelectSuspiciousElementsWithMask(
                List<List<SuspiciousTarget>> suspiciousElementsList, BigInteger xor, BigInteger mask) {
            var suspiciousElements = new List<SuspiciousTarget>();
            for (int i = 0; i < suspiciousElementsList.Count; i++) {
                var feature = BigInteger.Zero;
                var list = suspiciousElementsList[i];
                list.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                foreach (var t in list) {
                    var newFeature = (feature | (t.Feature ^ xor)) & mask;
                    if (newFeature != feature) {
                        feature = newFeature;
                        suspiciousElements.Add(t);
                    }
                }
            }
            return suspiciousElements;
        }

        private List<SuspiciousTarget> FlattenSuspiciousTargetsList(
                List<List<SuspiciousTarget>> targetsList) {
            var ret = new List<SuspiciousTarget>();
            var indices = Enumerable.Repeat(0, targetsList.Count).ToList();
            foreach (List<SuspiciousTarget> list in targetsList) {
                list.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
            }
            while (ret.Count < LearningCount) {
                var added = false;
                for (int i = 0; i < targetsList.Count; i++) {
                    var list = targetsList[i];
                    if (indices[i] < list.Count) {
                        ret.Add(list[indices[i]++]);
                        added = true;
                    }
                }
                if (!added) {
                    break;
                }
            }
            return ret;
        }

        private SuspiciousTarget SelectMostDifferentElement(
                IEnumerable<BigInteger> existings, IEnumerable<SuspiciousTarget> targets,
                BigInteger mask) {
            if (!existings.Any()) {
                return targets.FirstOrDefault();
            }
            var maxDiff = 0;
            SuspiciousTarget ret = null;
            foreach (var t in targets) {
                var feature = t.Feature & mask;
                var diff = existings.Min(f => CountBits((f & mask) ^ feature));
                if (maxDiff < diff) {
                    maxDiff = diff;
                    ret = t;
                }
            }
            return ret;
        }

        private List<SuspiciousTarget> SelectVariousElements(
                List<List<SuspiciousTarget>> targetsList, BigInteger mask) {
            var ret = new List<SuspiciousTarget>();
            foreach (List<SuspiciousTarget> list in targetsList) {
                list.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
            }
            while (ret.Count < LearningCount) {
                var added = false;
                foreach (var list in targetsList) {
                    var e = SelectMostDifferentElement(ret.Select(t => t.Feature), list, mask);
                    if (e != null) {
                        ret.Add(e);
                        added = true;
                    }
                }
                if (!added) {
                    break;
                }
            }
            return ret;
        }

        private List<SuspiciousTarget> SelectVariousElementsExisting(
                List<List<SuspiciousTarget>> targetsList, IList<BigInteger> existings, BigInteger mask) {
            var ret = new List<SuspiciousTarget>();
            foreach (List<SuspiciousTarget> list in targetsList) {
                list.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
            }
            while (ret.Count < LearningCount) {
                var added = false;
                foreach (var list in targetsList) {
                    var e = SelectMostDifferentElement(existings, list, mask);
                    if (e != null) {
                        ret.Add(e);
                        existings.Add(e.Feature);
                        added = true;
                    }
                }
                if (!added) {
                    break;
                }
            }
            return ret;
        }

        private List<SuspiciousTarget> SelectSuspiciousElementsWithMaskForFastAcceptanceLearning(
                List<List<SuspiciousTarget>> suspiciousElementsList, BigInteger xor, BigInteger mask, IList<ClassifierUnit> classifiers) {
            var suspiciousElements = new List<SuspiciousTarget>();
            for (int i = 0; i < suspiciousElementsList.Count; i++) {
                var feature = BigInteger.Zero;
                var classifier = classifiers[i];
                var list = suspiciousElementsList[i]
                        .OrderBy(t => CountBits(classifier.Accepting & t.Feature))
                        .ToList();
                foreach (var t in list) {
                    var newFeature = (feature | (t.Feature ^ xor)) & mask;
                    if (newFeature != feature) {
                        feature = newFeature;
                        suspiciousElements.Add(t);
                    }
                }
            }
            return suspiciousElements;
        }

        private List<SuspiciousTarget> SelectSuspiciousElementsWithMaskForFastRejectionLearning(
                List<List<SuspiciousTarget>> suspiciousElementsList, BigInteger xor, BigInteger mask, IList<ClassifierUnit> classifiers) {
            var suspiciousElements = new List<SuspiciousTarget>();
            for (int i = 0; i < suspiciousElementsList.Count; i++) {
                var feature = BigInteger.Zero;
                var classifier = classifiers[i];
                var list = suspiciousElementsList[i]
                        .OrderBy(
                                t =>
                                        CountBits(
                                                classifier.Accepting
                                                & ((t.Feature & _rejectingMask) ^ _rejectingMask)))
                        .ToList();
                foreach (var t in list) {
                    var newFeature = (feature | (t.Feature ^ xor)) & mask;
                    if (newFeature != feature) {
                        feature = newFeature;
                        suspiciousElements.Add(t);
                    }
                }
            }
            return suspiciousElements;
        }

        private static int DetermineCount(int i, IList<ClassifierUnit> classifiers) {
            return CountBits(classifiers[i].Accepting) > ThresholdFeatureCount
                    ? TargetCount : TargetCount / 2;
        }

        private static int DetermineStrongCount(int i, IList<ClassifierUnit> classifiers) {
            return CountBits(classifiers[i].Accepting) > ThresholdFeatureCount
                    ? StronglyTargetCount : StronglyTargetCount / 2;
        }

        private void SelectSuspicioutAcceptedNodes(List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _acceptingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i, classifiers);
                foreach (var target in targets) {
                    if (!target.Used) {
                        SuspiciousTargets.Add(target);
                        target.Used = true;
                        if (--count == 0) {
                            break;
                        }
                    }
                }
            }
        }

        private void SelectSuspicioutRejectedNodes(List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _rejectingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i, classifiers);
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        SuspiciousTargets.Add(target);
                        target.Used = true;
                        if (--count == 0) {
                            break;
                        }
                    }
                }
            }
        }

        private void SelectNodesForFastAcceptanceLearning(
                List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i, classifiers);
                foreach (var target in targets) {
                    if (!target.Used) {
                        SuspiciousTargets.Add(target);
                        target.Used = true;
                        if (--count == 0) {
                            break;
                        }
                    }
                }
            }
        }

        private void SelectNodesForSlowAcceptanceLearning(List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i, classifiers);
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        SuspiciousTargets.Add(target);
                        target.Used = true;
                        if (--count == 0) {
                            break;
                        }
                    }
                }
            }
        }

        private void SelectNodesForFastRejectionLearning(List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i, classifiers);
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        SuspiciousTargets.Add(target);
                        target.Used = true;
                        if (--count == 0) {
                            break;
                        }
                    }
                }
            }
        }

        private void SelectNodesForSlowRejectionLearning(List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i, classifiers);
                foreach (var target in targets) {
                    if (!target.Used) {
                        SuspiciousTargets.Add(target);
                        target.Used = true;
                        if (--count == 0) {
                            break;
                        }
                    }
                }
            }
        }

        private void SelectSuspicioutAcceptedNodesStrongly(List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _acceptingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = BigInteger.Zero;
                var count = DetermineStrongCount(i, classifiers);
                foreach (var target in targets) {
                    if (!target.Used) {
                        var newFeature = (feature | target.Feature) & _acceptingMask;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                            if (--count == 0) {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SelectSuspicioutRejectedNodesStrongly(List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _rejectingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = _rejectingMask;
                var count = DetermineStrongCount(i, classifiers);
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        var newFeature = feature & target.Feature;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                            if (--count == 0) {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SelectNodesForFastAcceptanceLearningStrongly(
                List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = BigInteger.Zero;
                var count = DetermineStrongCount(i, classifiers);
                foreach (var target in targets) {
                    if (!target.Used) {
                        var newFeature = (feature | target.Feature) & _acceptingMask;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                            if (--count == 0) {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SelectNodesForSlowAcceptanceLearningStrongly(
                List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = BigInteger.Zero;
                var count = DetermineStrongCount(i, classifiers);
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        var newFeature = (feature | target.Feature) & _acceptingMask;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                            if (--count == 0) {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SelectNodesForFastRejectionLearningStrongly(
                List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = _rejectingMask;
                var count = DetermineStrongCount(i, classifiers);
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        var newFeature = feature & target.Feature;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                            if (--count == 0) {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void SelectNodesForSlowRejectionLearningStrongly(
                List<List<SuspiciousTarget>> targetsList, IList<ClassifierUnit> classifiers) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = _rejectingMask;
                var count = DetermineStrongCount(i, classifiers);
                foreach (var target in targets) {
                    if (!target.Used) {
                        var newFeature = feature & target.Feature;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                            if (--count == 0) {
                                break;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        private GroupInfo CanReject(IList<ClassifierUnit> classifiers) {
            foreach (var featureAndGroupKey in _trainingRejectedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                if (IsAccepted(feature, classifiers[groupIndex].Accepting)
                    && !IsRejected(feature, classifiers[groupIndex].Rejecting)) {
                    return new GroupInfo { Index = groupIndex, Key = groupKey };
                }
            }
            return null;
        }

        private bool IsAccepted(BigInteger feature, BigInteger acceptingClassifier) {
            return (feature & acceptingClassifier) == acceptingClassifier;
        }

        private bool IsRejected(BigInteger feature, BigInteger rejectingClassifier) {
            return (feature & rejectingClassifier) != BigInteger.Zero;
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

        private void ShowBitsInfo(ExperimentalResult result, IList<ClassifierUnit> classifiers) {
            CreateClassifiers(_trainingAcceptedVector2GroupKey);

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(A): ");
            foreach (var f in _idealAcceptedVector2GroupKey.Keys) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(A): ");
            foreach (var f in _idealRejectedVector2GroupKey.Keys) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(A): ");
            foreach (var f in result.WronglyAcceptedFeatures) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(A): ");
            foreach (var f in result.WronglyRejectedFeatures) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(R): ");
            foreach (var f in _idealAcceptedVector2GroupKey.Keys) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(R): ");
            foreach (var f in _idealRejectedVector2GroupKey.Keys) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(R): ");
            foreach (var f in result.WronglyAcceptedFeatures) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(R): ");
            foreach (var f in result.WronglyRejectedFeatures) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(A): ");
            foreach (var featureAndGroupKey in _idealAcceptedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(A): ");
            foreach (var featureAndGroupKey in _idealRejectedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(A): ");
            foreach (var feature in result.WronglyAcceptedFeatures) {
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(A): ");
            foreach (var feature in result.WronglyRejectedFeatures) {
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(R): ");
            foreach (var featureAndGroupKey in _idealAcceptedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & classifiers[iClassifier].Rejecting) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(R): ");
            foreach (var featureAndGroupKey in _idealRejectedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & classifiers[iClassifier].Rejecting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(R): ");
            foreach (var feature in result.WronglyAcceptedFeatures) {
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & classifiers[iClassifier].Rejecting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(R): ");
            foreach (var feature in result.WronglyRejectedFeatures) {
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & classifiers[iClassifier].Rejecting) + ", ");
            }
            Console.WriteLine();
        }

        private static IEnumerable<CstNode> SelectUppermostNodes(IEnumerable<CstNode> elements) {
            return elements.Select(e => e.AncestorsWithSingleChildAndSelf().Last());
        }

        protected IEnumerable<CstNode> GetAllElements(CstNode cst, ISet<string> elementNames) {
            return cst.DescendantsAndSelf()
                    .Where(e => elementNames.Contains(e.Name));
        }

        protected IEnumerable<CstNode> GetUppermostNodesByNames(
                CstNode cst, ISet<string> elementNames) {
            return cst.DescendantsAndSelf()
                    .Where(e => elementNames.Contains(e.Name))
                    .Where(
                            e => e.AncestorsWithSingleChild()
                                    .All(a => !elementNames.Contains(a.Name)));
        }

        public bool IsAcceptedUsingOracle(CstNode uppermostNode) {
            return uppermostNode.DescendantsOfSingleAndSelf()
                    .Concat(uppermostNode.AncestorsWithSingleChild())
                    .Where(e => _oracleNames.Contains(e.Name))
                    .Any(ProtectedIsAcceptedUsingOracle);
        }

        public int CountUsingOracle(CstNode cst) {
            return GetUppermostNodesByNames(cst, _oracleNames)
                    .Count(IsAcceptedUsingOracle);
        }

        protected abstract bool ProtectedIsAcceptedUsingOracle(CstNode e);

        public virtual IList<CstNode> GetRootsUsingOracle(CstNode e) {
            return null;
        }
    }

    public interface ILearningExperiment {
        bool IsInner { get; }
        string GetToken(CstNode e);
        int MaxUp { get; }
        int MaxLeft { get; }
        int MaxRight { get; }

        IList<CstNode> GetRootsUsingOracle(CstNode e);
    }
}