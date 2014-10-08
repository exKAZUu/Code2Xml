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
using System.Runtime.Serialization.Formatters.Binary;
using Code2Xml.Core;
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

        public virtual string GetToken(CstNode e) {
            return e.TokenText;
        }

        public IList<CstNode> IdealAcceptedElements {
            get {
                return _idealAcceptedVector2GroupKey.Keys.Select(f => _feature2Element[f]).ToList();
            }
        }

        public IList<CstNode> IdealRejectedElements {
            get {
                return _idealRejectedVector2GroupKey.Keys.Select(f => _feature2Element[f]).ToList();
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
        private Dictionary<BigInteger, CstNode> _feature2Element;

        private IDictionary<string, BigInteger> _feature2Vector;
        private List<string> _groupKeys;
        private Dictionary<BigInteger, int> _feature2GroupIndex;
        private int _acceptingFeatureCount;
        private BigInteger _acceptingMask;
        private BigInteger _rejectingMask;
        private BigInteger _mask;
        public List<SuspiciousTarget> SuspiciousTargets { get; private set; }
        private IList<ClassifierUnit> _classifiers;
        private readonly HashSet<string> _oracleNames;
        private Dictionary<BigInteger, int> _feature2Count;
        private int _seedElementCount;
        private int _seedAbstractCount;
        private int _acceptedSeedElementCount;

        protected LearningExperiment(params string[] elementNames) {
            _oracleNames = elementNames.ToHashSet();
        }

        public void Clear() {
            _idealAcceptedVector2GroupKey.Clear();
            _idealRejectedVector2GroupKey.Clear();
            _trainingAcceptedVector2GroupKey.Clear();
            _trainingRejectedVector2GroupKey.Clear();
            if (_feature2Element != null) {
                _feature2Element.Clear();
            }
            _feature2Vector.Clear();
            _groupKeys.Clear();
            _classifiers.Clear();
            SuspiciousTargets.Clear();
            _idealAcceptedVector2GroupKey = null;
            _idealRejectedVector2GroupKey = null;
            _trainingAcceptedVector2GroupKey = null;
            _trainingRejectedVector2GroupKey = null;
            _feature2Element = null;
            _feature2Vector = null;
            _groupKeys = null;
            _classifiers = null;
            SuspiciousTargets = null;
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
                Dictionary<BigInteger, string> dict, BigInteger feature, CstNode node) {
            var groupKey = GetGroupKeyFromNode(node);
            var existingGroupKey = dict.GetValueOrDefault(feature);
            if (existingGroupKey == null) {
                dict.Add(feature, groupKey);
            } else {
                dict[feature] = CommonSuffix(existingGroupKey, groupKey);
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

        private static ISet<string> AdoptNodeNames(ICollection<CstNode> uppermosts) {
            var name2Count = new Dictionary<string, int>();
            var name2Ids = new Dictionary<string, HashSet<string>>();
            var candidates = uppermosts.SelectMany(
                    e => e.DescendantsOfSingleAndSelf());
            foreach (var e in candidates) {
                if (name2Count.ContainsKey(e.Name)) {
                    name2Count[e.Name] += 1;
                    name2Ids[e.Name].Add(e.NameAndTokenWithId());
                } else {
                    name2Count[e.Name] = 1;
                    name2Ids[e.Name] = new HashSet<string> {
                        e.NameAndTokenWithId()
                    };
                }
            }
            return uppermosts.Select(
                    e => e.DescendantsOfSingleAndSelf()
                            .Select(e2 => e2.Name)
                            .MaxElementOrDefault(
                                    name => (name2Count[name] << 8) + name2Ids[name].Count))
                    .ToHashSet();
        }

        public ExperimentalResult Learn(
                ICollection<string> seedPaths, StreamWriter writer,
                string projectPath, string searchPattern) {
            var allPaths = Directory.GetFiles(
                    projectPath, searchPattern, SearchOption.AllDirectories)
                    .ToList();

            var cacheFile = new FileInfo(
                    Path.Combine(
                            projectPath ?? "",
                            GetType().Name + Code2XmlConstants.LearningCacheExtension));
            if (true || string.IsNullOrEmpty(projectPath) || !cacheFile.Exists) {
                var allCsts = allPaths.Select(
                        path => {
                            try {
                                return Generator.GenerateTreeFromCode(
                                        new FileInfo(path), null, true);
                            } catch {
                                return null;
                            }
                        })
                        .Where(t => t != null);
                var seedCsts = seedPaths.Select(
                        path => Generator.GenerateTreeFromCode(new FileInfo(path), null, true))
                        .ToList();
                var seedNodes = seedCsts
                        .SelectMany(cst => GetUppermostNodesByNames(cst, _oracleNames))
                        .Where(ProtectedIsAcceptedUsingOracle)
                        .ToList();
                Console.WriteLine("Accepted elements: " + seedNodes.Count);
                if (string.IsNullOrEmpty(projectPath) != null) {
                    ExtractFeatures(allCsts, seedCsts, seedNodes);
                    var formatter = new BinaryFormatter();
                    using (var stream = cacheFile.OpenWrite()) {
                        formatter.Serialize(stream, _idealAcceptedVector2GroupKey);
                        formatter.Serialize(stream, _idealRejectedVector2GroupKey);
                        formatter.Serialize(stream, _trainingAcceptedVector2GroupKey);
                        formatter.Serialize(stream, _trainingRejectedVector2GroupKey);
                        //formatter.Serialize(stream, _feature2Element);

                        //formatter.Serialize(stream, _wronglyAcceptedFeatures);
                        //formatter.Serialize(stream, _wronglyRejectedFeatures);

                        formatter.Serialize(stream, _feature2Vector);
                        formatter.Serialize(stream, _groupKeys);
                        //formatter.Serialize(stream, _feature2GroupIndex);
                        formatter.Serialize(stream, _acceptingFeatureCount);
                        //formatter.Serialize(stream, _acceptingFeatureCount);
                        formatter.Serialize(stream, _acceptingMask);
                        formatter.Serialize(stream, _rejectingMask);
                        formatter.Serialize(stream, _mask);
                        //formatter.Serialize(stream, SuspiciousTargets);
                        formatter.Serialize(stream, _classifiers);
                        //formatter.Serialize(stream, _oracleNames);
                        formatter.Serialize(stream, _feature2Count);
                        //formatter.Serialize(stream, goNow);
                        //formatter.Serialize(stream, goBack);
                        //formatter.Serialize(stream, _seedElementCount);
                        //formatter.Serialize(stream, _seedAbstractCount);
                        //formatter.Serialize(stream, _acceptedSeedElementCount);
                    }
                }
            } else {
                var formatter = new BinaryFormatter();
                using (var stream = cacheFile.OpenRead()) {
                    _idealAcceptedVector2GroupKey =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    _idealRejectedVector2GroupKey =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    _trainingAcceptedVector2GroupKey =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    _trainingRejectedVector2GroupKey =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    //_feature2Element = (Dictionary<BigInteger, CstNode>)formatter.Deserialize(stream);
                    _feature2Count = (Dictionary<BigInteger, int>)formatter.Deserialize(stream);
                    _feature2Vector =
                            (IDictionary<string, BigInteger>)formatter.Deserialize(stream);
                    _groupKeys = (List<string>)formatter.Deserialize(stream);
                    _acceptingFeatureCount = (int)formatter.Deserialize(stream);
                    _acceptingMask = (BigInteger)formatter.Deserialize(stream);
                    _rejectingMask = (BigInteger)formatter.Deserialize(stream);
                    _mask = (BigInteger)formatter.Deserialize(stream);
                    _classifiers = (IList<ClassifierUnit>)formatter.Deserialize(stream);
                }
            }

            UpdateGroup();
            _classifiers = InitializeClassifiers();
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
                                .Sum(f => _feature2Count[f.Key]) - _seedElementCount);
                writer.Write(",");
                writer.Write(
                        _trainingAcceptedVector2GroupKey.Concat(_trainingRejectedVector2GroupKey)
                                .Sum(f => _feature2Count[f.Key]) - _seedElementCount);
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

        public void ExtractFeatures(
                IEnumerable<CstNode> allCsts, IList<CstNode> seedCsts, IList<CstNode> seedNodes) {
            var preparingTime = Environment.TickCount;

            var uppermostSeedAcceptedNodes = SelectUppermostNodes(seedNodes).ToHashSet();
            var selectedNames = AdoptNodeNames(uppermostSeedAcceptedNodes).ToHashSet();
            _groupKeys = selectedNames.Select(n => ">" + n + ">")
                    .ToList();

            var seedAcceptedNodes = uppermostSeedAcceptedNodes
                    .Select(
                            e => e.DescendantsOfSingleAndSelf()
                                    .First(e2 => selectedNames.Contains(e2.Name)))
                    .ToHashSet();

            var uppermostSeedAcceptedNodes2 = seedCsts
                    .SelectMany(cst => GetUppermostNodesByNames(cst, selectedNames))
                    .Where(ProtectedIsAcceptedUsingOracle)
                    .ToList();
            var b1 =
                    !uppermostSeedAcceptedNodes.All(IsAcceptedUsingOracle);
            var b2 = SelectUppermostNodes(uppermostSeedAcceptedNodes2)
                    .Any(e => !uppermostSeedAcceptedNodes.Contains(e));
            var b3 = uppermostSeedAcceptedNodes.Count != uppermostSeedAcceptedNodes2.Count;
            Console.WriteLine("Initial: " + string.Join(", ", _oracleNames));
            Console.WriteLine("Learned: " + string.Join(", ", selectedNames));
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
            _feature2Element = new Dictionary<BigInteger, CstNode>();
            _feature2Count = new Dictionary<BigInteger, int>();
            _groupKeys = new List<string> { ">" };
            _feature2Vector = new Dictionary<string, BigInteger>();

            foreach (var cst in seedCsts) {
                Console.Write(".");
                foreach (var e in GetAllElements(cst, selectedNames)) {
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

            var masterFeature = BigInteger.One;
            foreach (var feature in acceptingFeatures) {
                _feature2Vector.Add(feature, masterFeature);
                masterFeature <<= 1;
            }
            foreach (var feature in rejectingFeatures) {
                _feature2Vector.Add(feature, masterFeature);
                masterFeature <<= 1;
            }

            _mask = (BigInteger.One << _feature2Vector.Count) - BigInteger.One;
            _acceptingMask = (BigInteger.One << _acceptingFeatureCount) - BigInteger.One;
            _rejectingMask = _mask ^ _acceptingMask;

            _acceptedSeedElementCount = 0;
            _seedAbstractCount = 0;
            _seedElementCount = 0;

            foreach (var e in seedAcceptedNodes) {
                var feature = e.GetSurroundingPathBits(SurroundingLength, _feature2Vector, this);
                UpdateDict(_idealAcceptedVector2GroupKey, feature, e);
                _trainingAcceptedVector2GroupKey[feature] = _idealAcceptedVector2GroupKey[feature];
                _feature2Element[feature] = e;
                if (_feature2Count.ContainsKey(feature)) {
                    _feature2Count[feature]++;
                } else {
                    _feature2Count[feature] = 1;
                    _seedAbstractCount++;
                }
                _acceptedSeedElementCount++;
                _seedElementCount++;
            }
            foreach (var e in seedRejectedNodes) {
                var feature = e.GetSurroundingPathBits(SurroundingLength, _feature2Vector, this);
                UpdateDict(_idealRejectedVector2GroupKey, feature, e);
                _trainingRejectedVector2GroupKey[feature] = _idealRejectedVector2GroupKey[feature];
                _feature2Element[feature] = e;
                if (_feature2Count.ContainsKey(feature)) {
                    _feature2Count[feature]++;
                } else {
                    _feature2Count[feature] = 1;
                    _seedAbstractCount++;
                }
                _seedElementCount++;
            }

            foreach (var cst in allCsts) {
                Console.Write(".");
                ConvertUppermostNodesToVectors(cst, selectedNames);
            }

            Console.WriteLine(
                    "Unique Element Count: "
                    + (_idealAcceptedVector2GroupKey.Count + _idealRejectedVector2GroupKey.Count));

            if (_idealAcceptedVector2GroupKey.Keys.ToHashSet()
                    .Overlaps(_idealRejectedVector2GroupKey.Keys.ToHashSet())) {
                throw new Exception("Master predicates can't classify elements!");
            }

            _classifiers = new List<ClassifierUnit>();

            Console.WriteLine("Preparing time: " + (Environment.TickCount - preparingTime));
        }

        private void ConvertUppermostNodesToVectors(CstNode cst, ISet<string> selectedNames) {
            foreach (var uppermostNode in GetUppermostNodesByNames(cst, selectedNames)) {
                var vector = uppermostNode.GetSurroundingPathBits(
                        SurroundingLength, _feature2Vector, this);
                if (IsAcceptedUsingOracle(uppermostNode)) {
                    // TODO: for debug
                    if (_idealRejectedVector2GroupKey.ContainsKey(vector)) {
                        PrintNotDistinguishedElement(uppermostNode, vector);
                    }
                    UpdateDict(_idealAcceptedVector2GroupKey, vector, uppermostNode);
                } else {
                    // TODO: for debug
                    if (_idealAcceptedVector2GroupKey.ContainsKey(vector)) {
                        PrintNotDistinguishedElement(uppermostNode, vector);
                    }
                    UpdateDict(_idealRejectedVector2GroupKey, vector, uppermostNode);
                }
                _feature2Element[vector] = uppermostNode;
                if (_feature2Count.ContainsKey(vector)) {
                    _feature2Count[vector]++;
                } else {
                    _feature2Count[vector] = 1;
                }
            }
        }

        private void PrintNotDistinguishedElement(CstNode e, BigInteger feautre) {
            Console.WriteLine(e.Parent.Name + ", " + e.Name + ", " + e.Code);
            Console.WriteLine(
                    _feature2Element[feautre].Parent.Name + ", "
                    + _feature2Element[feautre].Name + ", "
                    + _feature2Element[feautre].Code);
            IsAcceptedUsingOracle(e);
            feautre = e.GetSurroundingPathBits(SurroundingLength, _feature2Vector, this);
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

        private void CreateClassifiers(
                ICollection<KeyValuePair<BigInteger, string>> acceptedTrainingSet) {
            while (true) {
                CreateRejectingClassifiers(acceptedTrainingSet);
                var result = CreateAcceptingClassifiers(acceptedTrainingSet);
                if (result == null) {
                    return;
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
                if (_groupKeys.Count == count
                    && acceptedTrainingSet == _trainingAcceptedVector2GroupKey) {
                    throw new Exception("Fail to learn rules");
                }
                Console.WriteLine("Groups: " + _groupKeys.Count + " (" + count + ")");
                acceptedTrainingSet = _trainingAcceptedVector2GroupKey;
                _classifiers = InitializeClassifiers();
            }
        }

        private LearningResult CreateAcceptingClassifiers(
                ICollection<KeyValuePair<BigInteger, string>> acceptedTrainingSet) {
            if (acceptedTrainingSet.Count == 0) {
                var rejectedGroupInfo = CanReject();
                if (rejectedGroupInfo != null) {
                    return new LearningResult {
                        Rejected = rejectedGroupInfo,
                        Accepted = null,
                    };
                }
                return null;
            }
            var classifiers = _classifiers;
            foreach (var featureAndGroupKey in acceptedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                classifiers[groupIndex].Accepting &= feature;
                var rejectedGroupInfo = CanReject();
                if (rejectedGroupInfo != null) {
                    return new LearningResult {
                        Rejected = rejectedGroupInfo,
                        Accepted = new GroupInfo { Index = groupIndex, Key = groupKey },
                    };
                }
            }
            return null;
        }

        private void CreateRejectingClassifiers(
                IEnumerable<KeyValuePair<BigInteger, string>> acceptedTrainingSet) {
            var classifiers = _classifiers;
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
                // �S�Ă�Accepted�������Ă��Ȃ�������1��
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
            return
                    Enumerable.Repeat(
                            new ClassifierUnit(_acceptingMask, _rejectingMask), _groupKeys.Count)
                            .Select(_ => new ClassifierUnit(_acceptingMask, _rejectingMask))
                            .ToList();
        }

        #endregion

        public ExperimentalResult LearnAndApply(ref int count) {
            var result = new ExperimentalResult(_feature2Element);

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
                    result.WrongElementCount += _feature2Count[feature];
                    result.WronglyRejectedFeatures.Add(featureAndGroupKey);
                } else if (!rejected) {
                    correctlyAccepted++;
                } else {
                    wronglyRejectedInRejecting++;
                    result.WrongElementCount += _feature2Count[feature];
                    result.WronglyRejectedFeatures.Add(featureAndGroupKey);
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
                    result.WrongElementCount += _feature2Count[feature];
                    result.WronglyAcceptedFeatures.Add(featureAndGroupKey);
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
                    "L: "
                    + (_trainingAcceptedVector2GroupKey.Count
                       + _trainingRejectedVector2GroupKey.Count) + ", AP: "
                    + string.Join(", ", classifiers.Select(c => CountBits(c.Accepting))) + ", RP: "
                    + string.Join(", ", classifiers.Select(c => CountRejectingBits(c.Rejecting))));
            result.WrongFeatureCount = wronglyAccepted + wronglyRejected
                                       + wronglyRejectedInRejecting;

            SuspiciousTargets = new List<SuspiciousTarget>();
            switch (count) {
            case 0:
                var time1 = Environment.TickCount;
                SelectSuspicioutAcceptedNodes(acceptAccept);
                SelectSuspicioutAcceptedNodes(acceptReject);
                SelectSuspicioutRejectedNodes(acceptAccept);
                SelectSuspicioutRejectedNodes(rejectAccept);

                SelectNodesForFastAcceptanceLearning(rejectAccept);
                //SelectNodesForSlowAcceptanceLearning(rejectAccept);
                SelectNodesForFastAcceptanceLearning(rejectReject);
                //SelectNodesForSlowAcceptanceLearning(rejectReject);

                SelectNodesForFastRejectionLearning(acceptReject);
                //SelectNodesForSlowRejectionLearning(acceptReject);
                SelectNodesForFastRejectionLearning(rejectReject);
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
                SelectNodesForSlowAcceptanceLearningStrongly(rejectAccept);
                //SelectNodesForFastAcceptanceLearningStrongly(rejectReject);
                SelectNodesForSlowAcceptanceLearningStrongly(rejectReject);

                //SelectNodesForFastRejectionLearningStrongly(acceptReject);
                SelectNodesForSlowRejectionLearningStrongly(acceptReject);
                //SelectNodesForFastRejectionLearningStrongly(rejectReject);
                SelectNodesForSlowRejectionLearningStrongly(rejectReject);
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
                List<List<SuspiciousTarget>> targetsList, IList<BigInteger> existings,
                BigInteger mask) {
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
                List<List<SuspiciousTarget>> suspiciousElementsList, BigInteger xor, BigInteger mask) {
            var classifiers = _classifiers;
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
                List<List<SuspiciousTarget>> suspiciousElementsList, BigInteger xor, BigInteger mask) {
            var classifiers = _classifiers;
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

        private int DetermineCount(int i) {
            return CountBits(_classifiers[i].Accepting) > ThresholdFeatureCount
                    ? TargetCount : TargetCount / 2;
        }

        private int DetermineStrongCount(int i) {
            return CountBits(_classifiers[i].Accepting) > ThresholdFeatureCount
                    ? StronglyTargetCount : StronglyTargetCount / 2;
        }

        private void SelectSuspicioutAcceptedNodes(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _acceptingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i);
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

        private void SelectSuspicioutRejectedNodes(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _rejectingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i);
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
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i);
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

        private void SelectNodesForSlowAcceptanceLearning(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i);
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

        private void SelectNodesForFastRejectionLearning(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i);
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

        private void SelectNodesForSlowRejectionLearning(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = DetermineCount(i);
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

        private void SelectSuspicioutAcceptedNodesStrongly(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _acceptingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = BigInteger.Zero;
                var count = DetermineStrongCount(i);
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

        private void SelectSuspicioutRejectedNodesStrongly(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _rejectingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = _rejectingMask;
                var count = DetermineStrongCount(i);
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
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = BigInteger.Zero;
                var count = DetermineStrongCount(i);
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
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Accepting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = BigInteger.Zero;
                var count = DetermineStrongCount(i);
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
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = _rejectingMask;
                var count = DetermineStrongCount(i);
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
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _classifiers[i].Rejecting;
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = _rejectingMask;
                var count = DetermineStrongCount(i);
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

        private GroupInfo CanReject() {
            var classifiers = _classifiers;
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
            // �S�Ă̐���������Ă����Accepted
            return (feature & acceptingClassifier) == acceptingClassifier;
        }

        private bool IsRejected(BigInteger feature, BigInteger rejectingClassifier) {
            // �����ꂩ�̐���������Ă����Rejected
            // Reject���Ȃ��ꍇ�����ɓ���
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

        private void ShowBitsInfo(ExperimentalResult result) {
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
            foreach (var f in result.WronglyAcceptedFeatures.Select(kv => kv.Key)) {
                Console.Write(CountAcceptingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(A): ");
            foreach (var f in result.WronglyRejectedFeatures.Select(kv => kv.Key)) {
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
            foreach (var f in result.WronglyAcceptedFeatures.Select(kv => kv.Key)) {
                Console.Write(CountRejectingBits(f) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(R): ");
            foreach (var f in result.WronglyRejectedFeatures.Select(kv => kv.Key)) {
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
                        CountAcceptingBits(feature & _classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(A): ");
            foreach (var featureAndGroupKey in _idealRejectedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & _classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(A): ");
            foreach (var featureAndGroupKey in result.WronglyAcceptedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & _classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(A): ");
            foreach (var featureAndGroupKey in result.WronglyRejectedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & _classifiers[iClassifier].Accepting) + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(R): ");
            foreach (var featureAndGroupKey in _idealAcceptedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _classifiers[iClassifier].Rejecting) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(R): ");
            foreach (var featureAndGroupKey in _idealRejectedVector2GroupKey) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _classifiers[iClassifier].Rejecting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(R): ");
            foreach (var featureAndGroupKey in result.WronglyAcceptedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _classifiers[iClassifier].Rejecting) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(R): ");
            foreach (var featureAndGroupKey in result.WronglyRejectedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _classifiers[iClassifier].Rejecting) + ", ");
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
    }

    public interface ILearningExperiment {
        bool IsInner { get; }
        string GetToken(CstNode e);
    }
}