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
using Code2Xml.Languages.ANTLRv3.Core;
using Paraiba.Collections.Generic;
using Paraiba.Linq;

namespace Code2Xml.Objects.Tests.Learning {
    public abstract class LearningExperiment {
        public class SuspiciousTarget {
            public int BitsCount { get; set; }
            public boolean Used { get; set; }
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

        public int WrongFeatureCount { get; set; }
        public int WrongElementCount { get; set; }
        protected abstract CstGenerator Generator { get; }
        protected abstract bool IsInner { get; }

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
        private const int TargetCount = 3;
        private IDictionary<string, BigInteger> _masterFeatures;
        private List<string> _groupKeys;
        private Dictionary<BigInteger, int> _feature2GroupIndex;
        private int _acceptingFeatureCount;
        private BigInteger _acceptingMask;
        private BigInteger _rejectingMask;
        private BigInteger _mask;
        public List<SuspiciousTarget> SuspiciousTargets { get; private set; }
        private IList<BigInteger> _acceptingClassifiers;
        private IList<BigInteger> _rejectingClassifiers;
        private readonly HashSet<string> _initialElementNames;
        private Dictionary<BigInteger, int> _feature2Count;

        protected LearningExperiment(params string[] elementNames) {
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
            _acceptingClassifiers.Clear();
            _rejectingClassifiers.Clear();
            SuspiciousTargets.Clear();
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
            _acceptingClassifiers = null;
            _rejectingClassifiers = null;
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
            IEnumerable<string> groupKeySequence;
            if (IsInner) {
                //node = node.AncestorsOfOnlyChildAndSelf().Last(); // TODO
                // TODO: descendants may be empty list
                var descendants = node.DescendantsOfFirstChild()
                        .Take(GroupKeyLength)
                        .ToList();
                groupKeySequence = descendants.Select(e => e.NameAndTokenWithId());
                if (descendants[descendants.Count - 1].HasToken) {
                    groupKeySequence =
                            groupKeySequence.Concat(descendants[descendants.Count - 1].TokenText);
                }
            } else {
                //node = node.DescendantsOfOnlyChildAndSelf().Last(); // TODO
                groupKeySequence = node.AncestorsAndSelf()
                        .Take(GroupKeyLength)
                        .Select(e => e.NameAndTokenWithId());
            }

            var groupKey = ">" + node.Name + ">" + string.Join(">", groupKeySequence) + ">";
            var existingGroupKey = dict.GetValueOrDefault(feature);
            if (existingGroupKey == null) {
                dict.Add(feature, groupKey);
            } else {
                dict[feature] = CommonSuffix(existingGroupKey, groupKey);
            }
        }

        private static ISet<string> AdoptNodeNames(ICollection<CstNode> outermosts) {
            var name2Count = new Dictionary<string, int>();
            var name2Ids = new Dictionary<string, HashSet<string>>();
            var candidates = outermosts.SelectMany(
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
            return outermosts.Select(
                    e => e.DescendantsOfSingleAndSelf()
                            .Select(e2 => e2.Name)
                            .MaxElementOrDefault(
                                    name => (name2Count[name] << 8) + name2Ids[name].Count))
                    .ToHashSet();
        }

        public void Learn(
                ICollection<string> allPaths, ICollection<string> seedPaths, StreamWriter writer,
                string projectPath) {
            var cacheFile = new FileInfo(
                    Path.Combine(
                            projectPath ?? "",
                            GetType().Name + Code2XmlConstants.LearningCacheExtension));
            if (true || string.IsNullOrEmpty(projectPath) || !cacheFile.Exists) {
                var allAsts = allPaths.Select(
                        path => Generator.GenerateTreeFromCode(new FileInfo(path), null, true));
                var seedAsts = seedPaths.Select(
                        path => Generator.GenerateTreeFromCode(new FileInfo(path), null, true))
                        .ToList();
                _elementNames = _initialElementNames.ToHashSet();
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
                if (string.IsNullOrEmpty(projectPath) != null) {
                    ExtractFeatures(allAsts, seedAsts, seedAcceptedElements.ToList());
                    var formatter = new BinaryFormatter();
                    using (var stream = cacheFile.OpenWrite()) {
                        formatter.Serialize(stream, _elementNames);
                        formatter.Serialize(stream, _idealAccepted);
                        formatter.Serialize(stream, _idealRejected);
                        formatter.Serialize(stream, _acceptedTrainingSet);
                        formatter.Serialize(stream, _rejectedTrainingSet);
                        //formatter.Serialize(stream, _feature2Element);
                        formatter.Serialize(stream, _feature2Count);
                        formatter.Serialize(stream, _masterFeatures);
                        formatter.Serialize(stream, _groupKeys);
                        formatter.Serialize(stream, _acceptingFeatureCount);
                        formatter.Serialize(stream, _acceptingMask);
                        formatter.Serialize(stream, _rejectingMask);
                        formatter.Serialize(stream, _mask);
                        formatter.Serialize(stream, _acceptingClassifiers);
                        formatter.Serialize(stream, _rejectingClassifiers);
                    }
                }
            } else {
                var formatter = new BinaryFormatter();
                using (var stream = cacheFile.OpenRead()) {
                    _elementNames = (ISet<string>)formatter.Deserialize(stream);
                    _idealAccepted = (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    _idealRejected = (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    _acceptedTrainingSet =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    _rejectedTrainingSet =
                            (Dictionary<BigInteger, string>)formatter.Deserialize(stream);
                    //_feature2Element = (Dictionary<BigInteger, CstNode>)formatter.Deserialize(stream);
                    _feature2Count = (Dictionary<BigInteger, int>)formatter.Deserialize(stream);
                    _masterFeatures =
                            (IDictionary<string, BigInteger>)formatter.Deserialize(stream);
                    _groupKeys = (List<string>)formatter.Deserialize(stream);
                    _acceptingFeatureCount = (int)formatter.Deserialize(stream);
                    _acceptingMask = (BigInteger)formatter.Deserialize(stream);
                    _rejectingMask = (BigInteger)formatter.Deserialize(stream);
                    _mask = (BigInteger)formatter.Deserialize(stream);
                    _acceptingClassifiers = (IList<BigInteger>)formatter.Deserialize(stream);
                    _rejectingClassifiers = (IList<BigInteger>)formatter.Deserialize(stream);
                }
                UpdateGroup();
            }

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

            var uppermostSeedAcceptedElements2 = seedAsts
                    .SelectMany(GetAllElementsWithoutDuplicates)
                    .Where(ProtectedIsAcceptedUsingOracle)
                    .ToList();
            var b1 = !uppermostSeedAcceptedElements.All(IsAcceptedUsingOracle);
            var b2 = GetMostOuterElements(uppermostSeedAcceptedElements2)
                    .Any(e => !uppermostSeedAcceptedElements.Contains(e));
            var b3 = uppermostSeedAcceptedElements.Count != uppermostSeedAcceptedElements2.Count;
            Console.WriteLine("Initial: " + string.Join(", ", _initialElementNames));
            Console.WriteLine("Learned: " + string.Join(", ", _elementNames));
            if (b1 || b2 || b3) {
                Console.WriteLine("--------------------------------------------------");
                foreach (var e in uppermostSeedAcceptedElements) {
                    Console.WriteLine(e);
                }
                Console.WriteLine("--------------------------------------------------");
                foreach (var e in uppermostSeedAcceptedElements2) {
                    Console.WriteLine(e);
                }

                throw new Exception("Wrong Oracle.");
            }
            var seedRejectedElements = new List<CstNode>();
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
                    .GetUnionKeys(SurroundingLength, IsInner, !IsInner)
                    .ToHashSet()
                    .ToList();
            acceptingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            _acceptingFeatureCount = acceptingFeatures.Count;
            var rejectingFeatureSet = seedRejectedElements
                    .GetUnionKeys(SurroundingLength, IsInner, !IsInner)
                    .ToHashSet();
            rejectingFeatureSet.ExceptWith(acceptingFeatures);
            var rejectingFeatures = rejectingFeatureSet.ToList();
            rejectingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));

            var masterFeature = BigInteger.One;
            foreach (var feature in acceptingFeatures) {
                _masterFeatures.Add(feature, masterFeature);
                masterFeature <<= 1;
            }
            foreach (var feature in rejectingFeatures) {
                _masterFeatures.Add(feature, masterFeature);
                masterFeature <<= 1;
            }

            _mask = (BigInteger.One << _masterFeatures.Count) - BigInteger.One;
            _acceptingMask = (BigInteger.One << _acceptingFeatureCount) - BigInteger.One;
            _rejectingMask = _mask ^ _acceptingMask;

            foreach (var e in seedAcceptedElements) {
                var feature = e.GetSurroundingBits(
                        SurroundingLength, _masterFeatures, IsInner, !IsInner);
                UpdateDict(_idealAccepted, feature, e);
                _acceptedTrainingSet[feature] = _idealAccepted[feature];
                _feature2Element[feature] = e;
            }
            foreach (var e in seedRejectedElements) {
                var feature = e.GetSurroundingBits(
                        SurroundingLength, _masterFeatures, IsInner, !IsInner);
                UpdateDict(_idealRejected, feature, e);
                _rejectedTrainingSet[feature] = _idealRejected[feature];
                _feature2Element[feature] = e;
            }

            foreach (var ast in allAsts) {
                Console.Write(".");
                foreach (var e in GetAllElementsWithoutDuplicates(ast)) {
                    var feature = e.GetSurroundingBits(
                            SurroundingLength, _masterFeatures, IsInner, !IsInner);
                    if (IsAcceptedUsingOracle(e)) {
                        // TODO: for debug
                        if (_idealRejected.ContainsKey(feature)) {
                            PrintNotDistinguishedElement(e, feature);
                        }
                        UpdateDict(_idealAccepted, feature, e);
                    } else {
                        // TODO: for debug
                        if (_idealAccepted.ContainsKey(feature)) {
                            PrintNotDistinguishedElement(e, feature);
                        }
                        UpdateDict(_idealRejected, feature, e);
                    }
                    _feature2Element[feature] = e;
                    if (_feature2Count.ContainsKey(feature)) {
                        _feature2Count[feature]++;
                    } else {
                        _feature2Count[feature] = 1;
                    }
                }
            }

            if (_idealAccepted.Keys.ToHashSet().Overlaps(_idealRejected.Keys.ToHashSet())) {
                throw new Exception("Master predicates can't classify elements!");
            }

            UpdateGroup();
            _acceptingClassifiers = InitializeAcceptingClassifiers();
            _rejectingClassifiers = InitializeRejectingClassifiers();
            CreateClassifiers(_acceptedTrainingSet); // for the first time

            Console.WriteLine("Preparing time: " + (Environment.TickCount - preparingTime));
        }

        private void PrintNotDistinguishedElement(CstNode e, BigInteger feautre) {
            Console.WriteLine(e.Parent.Name + ", " + e.Name + ", " + e.Code);
            Console.WriteLine(
                    _feature2Element[feautre].Parent.Name + ", "
                    + _feature2Element[feautre].Name + ", "
                    + _feature2Element[feautre].Code);
            IsAcceptedUsingOracle(e);
            feautre = e.GetSurroundingBits(
                    SurroundingLength, _masterFeatures, IsInner, !IsInner);
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
                var groupInfo = CreateAcceptingClassifiers(acceptedTrainingSet);
                if (groupInfo == null) {
                    return;
                }
                var count = _groupKeys.Count;
                var updated = false;
                if (groupInfo.Accepted.Key != _groupKeys[groupInfo.Accepted.Index]) {
                    updated |= AddNewGroup(groupInfo.Accepted);
                }
                if (groupInfo.Rejected.Key != _groupKeys[groupInfo.Rejected.Index]) {
                    updated |= AddNewGroup(groupInfo.Rejected);
                }
                if (updated) {
                    UpdateGroup();
                }
                if (_groupKeys.Count == count) {
                    throw new Exception("Fail to learn rules");
                }
                Console.WriteLine("Groups: " + _groupKeys.Count + " (" + count + ")");
                acceptedTrainingSet = _acceptedTrainingSet;
                _acceptingClassifiers = InitializeAcceptingClassifiers();
                _rejectingClassifiers = InitializeRejectingClassifiers();
            }
        }

        private LearningResult CreateAcceptingClassifiers(
                IEnumerable<KeyValuePair<BigInteger, string>> acceptedTrainingSet) {
            var acceptingClassifiers = _acceptingClassifiers;
            foreach (var featureAndGroupKey in acceptedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                acceptingClassifiers[groupIndex] &= feature;
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
            var rejectingClassifiers = _rejectingClassifiers;
            var count = rejectingClassifiers.Count;
            for (int i = 0; i < count; i++) {
                rejectingClassifiers[i] ^= _rejectingMask;
            }
            foreach (var featureAndGroupKey in acceptedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var iGroupKey = GetGroupIndex(feature);
                rejectingClassifiers[iGroupKey] |= feature;
            }
            for (int i = 0; i < count; i++) {
                // ‘S‚Ä‚ÌAccepted‚ª”õ‚¦‚Ä‚¢‚È‚¢«Ž¿‚ð1‚É
                rejectingClassifiers[i] ^= _rejectingMask;
                rejectingClassifiers[i] &= _rejectingMask;
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
            foreach (var kv in _idealAccepted) {
                var index = GetGroupIndexWithoutCache(kv.Value);
                _feature2GroupIndex.Add(kv.Key, index);
            }
            foreach (var kv in _idealRejected) {
                var index = GetGroupIndexWithoutCache(kv.Value);
                _feature2GroupIndex.Add(kv.Key, index);
            }
        }

        private List<BigInteger> InitializeRejectingClassifiers() {
            return Enumerable.Repeat(_rejectingMask, _groupKeys.Count).ToList();
        }

        private List<BigInteger> InitializeAcceptingClassifiers() {
            return Enumerable.Repeat(_acceptingMask, _groupKeys.Count).ToList();
        }

        #endregion

        public int LearnAndApply(int count) {
            var acceptingClassifiers = _acceptingClassifiers;
            var rejectingClassifiers = _rejectingClassifiers;
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
            _wronglyAcceptedFeatures.Clear();
            _wronglyRejectedFeatures.Clear();

            foreach (var featureAndGroupKey in _idealAccepted) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                var rejected = IsRejected(feature, rejectingClassifiers[groupIndex]);
                var accepted = IsAccepted(feature, acceptingClassifiers[groupIndex]);
                if (!_acceptedTrainingSet.ContainsKey(feature)
                    && !_rejectedTrainingSet.ContainsKey(feature)) {
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
                    WrongElementCount += _feature2Count[feature];
                    _wronglyRejectedFeatures.Add(featureAndGroupKey);
                } else if (!rejected) {
                    correctlyAccepted++;
                } else {
                    wronglyRejectedInRejecting++;
                    WrongElementCount += _feature2Count[feature];
                    _wronglyRejectedFeatures.Add(featureAndGroupKey);
                }
            }

            foreach (var featureAndGroupKey in _idealRejected) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                var rejected = IsRejected(feature, rejectingClassifiers[groupIndex]);
                var accepted = IsAccepted(feature, acceptingClassifiers[groupIndex]);
                if (!_acceptedTrainingSet.ContainsKey(feature)
                    && !_rejectedTrainingSet.ContainsKey(feature)) {
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
                    WrongElementCount += _feature2Count[feature];
                    _wronglyAcceptedFeatures.Add(featureAndGroupKey);
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
                    "L: " + (_acceptedTrainingSet.Count + _rejectedTrainingSet.Count) + ", AP: "
                    + string.Join(", ", _acceptingClassifiers.Select(CountBits)) + ", RP: "
                    + string.Join(", ", _rejectingClassifiers.Select(CountRejectingBits)));
            WrongFeatureCount = wronglyAccepted + wronglyRejected + wronglyRejectedInRejecting;

            SuspiciousTargets = new List<SuspiciousTarget>();
            switch (count) {
            case 0:
                var time1 = Environment.TickCount;
                SelectSuspicioutAcceptedNodes(acceptAccept);
                SelectSuspicioutAcceptedNodes(acceptReject);
                SelectSuspicioutRejectedNodes(acceptAccept);
                SelectSuspicioutRejectedNodes(rejectAccept);

                SelectNodesForFastAcceptanceLearning(rejectAccept);
                SelectNodesForSlowAcceptanceLearning(rejectAccept);
                SelectNodesForFastAcceptanceLearning(rejectReject);
                SelectNodesForSlowAcceptanceLearning(rejectReject);

                SelectNodesForFastRejectionLearning(acceptReject);
                SelectNodesForSlowRejectionLearning(acceptReject);
                SelectNodesForFastRejectionLearning(rejectReject);
                SelectNodesForSlowRejectionLearning(rejectReject);
                Console.WriteLine(
                        "SelectSuspicioutAcceptedNodes: " + (Environment.TickCount - time1));
                break;
            case 1:
                var time2 = Environment.TickCount;
                SelectSuspicioutAcceptedNodesStrongly(acceptAccept);
                SelectSuspicioutAcceptedNodesStrongly(acceptReject);
                SelectSuspicioutRejectedNodesStrongly(acceptAccept);
                SelectSuspicioutRejectedNodesStrongly(rejectAccept);

                SelectNodesForFastAcceptanceLearningStrongly(rejectAccept);
                SelectNodesForSlowAcceptanceLearningStrongly(rejectAccept);
                SelectNodesForFastAcceptanceLearningStrongly(rejectReject);
                SelectNodesForSlowAcceptanceLearningStrongly(rejectReject);

                SelectNodesForFastRejectionLearningStrongly(acceptReject);
                SelectNodesForSlowRejectionLearningStrongly(acceptReject);
                SelectNodesForFastRejectionLearningStrongly(rejectReject);
                SelectNodesForSlowRejectionLearningStrongly(rejectReject);
                Console.WriteLine(
                        "SelectSuspicioutAcceptedNodesStrongly: " + (Environment.TickCount - time2));
                break;
            default:
                return -1;
            }
            Console.WriteLine("Suspicious nodes: " + SuspiciousTargets.Count);

            return count + 1;
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
                    "Accepted: " + _acceptedTrainingSet.Count + " + " + additionalAcceptedCount
                    + " / " + _idealAccepted.Count);
            Console.WriteLine(
                    "Rejected: " + _rejectedTrainingSet.Count + " + " + additionalRejectedCount
                    + " / " + _idealRejected.Count);
            foreach (var featureAndGroupKey in additionalAccepted) {
                _acceptedTrainingSet.Add(featureAndGroupKey.Key, featureAndGroupKey.Value);
            }
            foreach (var featureAndGroupKey in additionalRejected) {
                _rejectedTrainingSet.Add(featureAndGroupKey.Key, featureAndGroupKey.Value);
            }

            var lastAcceptingClassifiers = _acceptingClassifiers.ToList();
            var lastRejectingClassifiers = _rejectingClassifiers.ToList();
            CreateClassifiers(additionalAccepted);
            var ret = lastAcceptingClassifiers.SequenceEqual(_acceptingClassifiers)
                      && lastRejectingClassifiers.SequenceEqual(_rejectingClassifiers);
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
            var classifiers = _acceptingClassifiers;
            var suspiciousElements = new List<SuspiciousTarget>();
            for (int i = 0; i < suspiciousElementsList.Count; i++) {
                var feature = BigInteger.Zero;
                var classifier = classifiers[i];
                var list = suspiciousElementsList[i]
                        .OrderBy(t => CountBits(classifier & t.Feature))
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
            var classifiers = _acceptingClassifiers;
            var suspiciousElements = new List<SuspiciousTarget>();
            for (int i = 0; i < suspiciousElementsList.Count; i++) {
                var feature = BigInteger.Zero;
                var classifier = classifiers[i];
                var list = suspiciousElementsList[i]
                        .OrderBy(
                                t =>
                                        CountBits(
                                                classifier
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

        private void SelectSuspicioutAcceptedNodes(List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & _acceptingMask);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = TargetCount;
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
                var count = TargetCount;
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
                var classifier = _acceptingClassifiers[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = TargetCount;
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
                var count = TargetCount;
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
                var classifier = _rejectingClassifiers[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var count = TargetCount;
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
                var count = TargetCount;
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
                foreach (var target in targets) {
                    if (!target.Used) {
                        var newFeature = (feature | target.Feature) & _acceptingMask;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
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
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        var newFeature = feature & target.Feature;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                        }
                    }
                }
            }
        }

        private void SelectNodesForFastAcceptanceLearningStrongly(
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _acceptingClassifiers[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(target.Feature & classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = BigInteger.Zero;
                foreach (var target in targets) {
                    if (!target.Used) {
                        var newFeature = (feature | target.Feature) & _acceptingMask;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                        }
                    }
                }
            }
        }

        private void SelectNodesForSlowAcceptanceLearningStrongly(
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var feature = BigInteger.Zero;
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        var newFeature = (feature | target.Feature) & _acceptingMask;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                        }
                    }
                }
            }
        }

        private void SelectNodesForFastRejectionLearningStrongly(
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var classifier = _rejectingClassifiers[i];
                foreach (var target in targets) {
                    target.BitsCount = CountBits(
                            (target.Feature & _rejectingMask) | classifier);
                }
                targets.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
                var feature = _rejectingMask;
                for (int j = targets.Count - 1; j >= 0; j--) {
                    var target = targets[j];
                    if (!target.Used) {
                        var newFeature = feature & target.Feature;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                        }
                    }
                }
            }
        }

        private void SelectNodesForSlowRejectionLearningStrongly(
                List<List<SuspiciousTarget>> targetsList) {
            for (int i = 0; i < targetsList.Count; i++) {
                var targets = targetsList[i];
                var feature = _rejectingMask;
                foreach (var target in targets) {
                    if (!target.Used) {
                        var newFeature = feature & target.Feature;
                        if (newFeature != feature) {
                            feature = newFeature;
                            SuspiciousTargets.Add(target);
                            target.Used = true;
                        }
                    }
                }
            }
        }

        #endregion

        private GroupInfo CanReject() {
            var acceptingClassifiers = _acceptingClassifiers;
            var rejectingClassifiers = _rejectingClassifiers;
            foreach (var featureAndGroupKey in _rejectedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(feature);
                if (IsAccepted(feature, acceptingClassifiers[groupIndex])
                    && !IsRejected(feature, rejectingClassifiers[groupIndex])) {
                    return new GroupInfo { Index = groupIndex, Key = groupKey };
                }
            }
            return null;
        }

        private bool IsAccepted(BigInteger feature, BigInteger acceptingClassifier) {
            // ‘S‚Ä‚Ì«Ž¿‚ð”õ‚¦‚Ä‚¢‚ê‚ÎAccepted
            return (feature & acceptingClassifier) == acceptingClassifier;
        }

        private bool IsRejected(BigInteger feature, BigInteger rejectingClassifier) {
            // ‚¢‚¸‚ê‚©‚Ì«Ž¿‚ð”õ‚¦‚Ä‚¢‚ê‚ÎRejected
            // Reject‚ª‚È‚¢ê‡‚à³í‚É“®ì
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

        private void ShowBitsInfo() {
            CreateClassifiers(_acceptedTrainingSet);

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

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(A): ");
            foreach (var featureAndGroupKey in _idealAccepted) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(A): ");
            foreach (var featureAndGroupKey in _idealRejected) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(A): ");
            foreach (var featureAndGroupKey in _wronglyAcceptedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(A): ");
            foreach (var featureAndGroupKey in _wronglyRejectedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(R): ");
            foreach (var featureAndGroupKey in _idealAccepted) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _rejectingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(R): ");
            foreach (var featureAndGroupKey in _idealRejected) {
                var feature = featureAndGroupKey.Key;
                var groupIndex = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _rejectingClassifiers[groupIndex]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(R): ");
            foreach (var featureAndGroupKey in _wronglyAcceptedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _rejectingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(R): ");
            foreach (var featureAndGroupKey in _wronglyRejectedFeatures) {
                var feature = featureAndGroupKey.Key;
                var iClassifier = GetGroupIndex(feature);
                Console.Write(
                        CountRejectingBits(feature & _rejectingClassifiers[iClassifier]) + ", ");
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

        public bool OriginalIsAcceptedUsingOracle(CstNode e) {
            return _initialElementNames.Contains(e.Name) && ProtectedIsAcceptedUsingOracle(e);
        }

        protected abstract bool ProtectedIsAcceptedUsingOracle(CstNode e);
    }
}