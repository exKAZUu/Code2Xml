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
using Paraiba.Collections.Generic;
using Paraiba.Linq;

namespace Code2Xml.Objects.Tests.Learning {
    public abstract class LearningExperiment {
        public class SuspiciousTarget {
            public int BitsCount { get; set; }
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
        private IDictionary<string, BigInteger> _masterFeatures;
        private List<string> _groupKeys;
        private int _acceptingFeatureCount;
        private BigInteger _acceptingMask;
        private BigInteger _rejectingMask;
        private BigInteger _mask;
        public List<SuspiciousTarget> SuspiciousAcceptedInAccepting { get; private set; }
        public List<SuspiciousTarget> SuspiciousRejectedInAccepting { get; private set; }
        public List<SuspiciousTarget> SuspiciousRejectedInRejecting { get; private set; }
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
            SuspiciousAcceptedInAccepting.Clear();
            SuspiciousRejectedInAccepting.Clear();
            SuspiciousRejectedInRejecting.Clear();
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
            SuspiciousAcceptedInAccepting = null;
            SuspiciousRejectedInAccepting = null;
            SuspiciousRejectedInRejecting = null;
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
                groupKeySequence = descendants.Select(e => e.NameWithId());
                if (descendants[descendants.Count - 1].HasToken) {
                    groupKeySequence =
                            groupKeySequence.Concat(descendants[descendants.Count - 1].TokenText);
                }
            } else {
                //node = node.DescendantsOfOnlyChildAndSelf().Last(); // TODO
                groupKeySequence = node.AncestorsAndSelf()
                        .Take(GroupKeyLength)
                        .Select(e => e.NameWithId());
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
            var cacheFile = new FileInfo(
                    Path.Combine(
                            projectPath ?? "",
                            GetType().Name + Code2XmlConstants.LearningCacheExtension));
            if (string.IsNullOrEmpty(projectPath) || !cacheFile.Exists) {
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

            CreateClassifiers(); // for the first time

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

        private int GetGroupIndex(string groupKey) {
            for (int i = _groupKeys.Count - 1; i >= 0; i--) {
                if (groupKey.StartsWith(_groupKeys[i])) {
                    return i;
                }
            }
            throw new Exception("Can't find the given group key: " + groupKey);
        }

        #region Create Classifier

        private void CreateClassifiers() {
            while (true) {
                var acceptingClassifiers = InitializeAcceptingClassifiers();
                var rejectingClassifiers = CreateRejectingClassifiers();
                var groupInfo = CreateAcceptingClassifiers(
                        acceptingClassifiers, rejectingClassifiers);
                if (groupInfo == null) {
                    _acceptingClassifiers = acceptingClassifiers;
                    _rejectingClassifiers = rejectingClassifiers;
                    return;
                }
                var count = _groupKeys.Count;
                if (groupInfo.Accepted.Key != _groupKeys[groupInfo.Accepted.Index]) {
                    AddNewGroup(groupInfo.Accepted);
                }
                if (groupInfo.Rejected.Key != _groupKeys[groupInfo.Rejected.Index]) {
                    AddNewGroup(groupInfo.Rejected);
                }
                if (_groupKeys.Count == count) {
                    throw new Exception("Fail to learn rules");
                }
                Console.WriteLine("Groups: " + _groupKeys.Count + " (" + count + ")");
            }
        }

        private LearningResult CreateAcceptingClassifiers(
                IList<BigInteger> acceptingClassifiers, IList<BigInteger> rejectingClassifiers) {
            foreach (var featureAndGroupKey in _acceptedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(groupKey);
                acceptingClassifiers[groupIndex] &= feature;
                var rejectedGroupInfo = CanReject(
                        acceptingClassifiers, rejectingClassifiers, _rejectedTrainingSet);
                if (rejectedGroupInfo != null) {
                    return new LearningResult {
                        Rejected = rejectedGroupInfo,
                        Accepted = new GroupInfo { Index = groupIndex, Key = groupKey },
                    };
                }
            }
            return null;
        }

        private IList<BigInteger> CreateRejectingClassifiers() {
            var rejectingClassifiers = InitializeRejectingClassifiers();
            foreach (var featureAndGroupKey in _acceptedTrainingSet) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var iGroupKey = GetGroupIndex(groupKey);
                rejectingClassifiers[iGroupKey] |= feature;
            }
            for (int i = 0; i < rejectingClassifiers.Count; i++) {
                // ëSÇƒÇÃAcceptedÇ™îıÇ¶ÇƒÇ¢Ç»Ç¢ê´éøÇ1Ç…
                rejectingClassifiers[i] ^= _rejectingMask;
                rejectingClassifiers[i] &= _rejectingMask;
            }
            return rejectingClassifiers;
        }

        private void AddNewGroup(GroupInfo info) {
            var i = info.Key.IndexOf('>', _groupKeys[info.Index].Length + 1);
            var newGroupKey = info.Key.Substring(0, i + 1);
            if (!_groupKeys.Contains(newGroupKey)) {
                _groupKeys.Add(newGroupKey);
            }
        }

        private List<BigInteger> InitializeRejectingClassifiers() {
            return Enumerable.Repeat(BigInteger.Zero, _groupKeys.Count).ToList();
        }

        private List<BigInteger> InitializeAcceptingClassifiers() {
            return Enumerable.Repeat(_mask, _groupKeys.Count).ToList();
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
            var rejectedInRejecting = new List<List<SuspiciousTarget>>();
            var rejectedInAccepting = new List<List<SuspiciousTarget>>();
            var acceptedInAccepting = new List<List<SuspiciousTarget>>();
            for (int i = 0; i < _groupKeys.Count; i++) {
                rejectedInRejecting.Add(new List<SuspiciousTarget>());
                rejectedInAccepting.Add(new List<SuspiciousTarget>());
                acceptedInAccepting.Add(new List<SuspiciousTarget>());
            }
            _wronglyAcceptedFeatures.Clear();
            _wronglyRejectedFeatures.Clear();

            var index = 0;

            foreach (var featureAndGroupKey in _idealAccepted) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(groupKey);
                var rejected = IsRejected(feature, rejectingClassifiers[groupIndex]);
                var accepted = IsAccepted(feature, acceptingClassifiers[groupIndex]);
                index++;
                if (!accepted) {
                    wronglyRejected++;
                    WrongElementCount += _feature2Count[feature];
                    _wronglyRejectedFeatures.Add(featureAndGroupKey);
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        // AcceptedÇ∆ã§í çÄÇ™ëΩÇ¢Ç‡ÇÃÇë_Ç§
                        rejectedInAccepting[groupIndex].Add(
                                new SuspiciousTarget {
                                    BitsCount =
                                        -CountAcceptingBits(
                                                feature & acceptingClassifiers[groupIndex]),
                                    Feature = feature,
                                    GroupKey = groupKey,
                                });
                    }
                } else if (!rejected) {
                    correctlyAccepted++;
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        // AcceptedÇ∆ã§í çÄÇ™è≠Ç»Ç¢Ç‡ÇÃÇë_Ç§
                        acceptedInAccepting[groupIndex].Add(
                                new SuspiciousTarget {
                                    BitsCount = CountAcceptingBits(feature),
                                    Feature = feature,
                                    GroupKey = groupKey,
                                });
                    }
                } else {
                    wronglyRejectedInRejecting++;
                    WrongElementCount += _feature2Count[feature];
                    _wronglyRejectedFeatures.Add(featureAndGroupKey);
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        // RejectedÇ∆ã§í çÄÇ™è≠Ç»Ç¢Ç‡ÇÃÇë_Ç§
                        rejectedInRejecting[groupIndex].Add(
                                new SuspiciousTarget {
                                    BitsCount =
                                        CountRejectingBits(
                                                feature & rejectingClassifiers[groupIndex]),
                                    Feature = feature,
                                    GroupKey = groupKey,
                                });
                    }
                }
            }

            foreach (var featureAndGroupKey in _idealRejected) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(groupKey);
                var rejected = IsRejected(feature, rejectingClassifiers[groupIndex]);
                var accepted = IsAccepted(feature, acceptingClassifiers[groupIndex]);
                index++;
                if (!accepted) {
                    correctlyRejected++;
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        // AcceptedÇ∆ã§í çÄÇ™ëΩÇ¢Ç‡ÇÃÇë_Ç§
                        rejectedInAccepting[groupIndex].Add(
                                new SuspiciousTarget {
                                    BitsCount =
                                        -CountAcceptingBits(
                                                feature & acceptingClassifiers[groupIndex]),
                                    Feature = feature,
                                    GroupKey = groupKey,
                                });
                    }
                } else if (!rejected) {
                    wronglyAccepted++;
                    WrongElementCount += _feature2Count[feature];
                    _wronglyAcceptedFeatures.Add(featureAndGroupKey);
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        // AcceptedÇ∆ã§í çÄÇ™è≠Ç»Ç¢Ç‡ÇÃÇë_Ç§
                        acceptedInAccepting[groupIndex].Add(
                                new SuspiciousTarget {
                                    BitsCount = CountAcceptingBits(feature),
                                    Feature = feature,
                                    GroupKey = groupKey,
                                });
                    }
                } else {
                    correctlyRejectedInRejecting++;
                    if (!_acceptedTrainingSet.ContainsKey(feature)
                        && !_rejectedTrainingSet.ContainsKey(feature)) {
                        // RejectedÇ∆ã§í çÄÇ™è≠Ç»Ç¢Ç‡ÇÃÇë_Ç§
                        rejectedInRejecting[groupIndex].Add(
                                new SuspiciousTarget {
                                    BitsCount =
                                        CountRejectingBits(
                                                feature & rejectingClassifiers[groupIndex]),
                                    Feature = feature,
                                    GroupKey = groupKey,
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
                    "L: " + (_acceptedTrainingSet.Count + _rejectedTrainingSet.Count) + ", AP: "
                    + string.Join(", ", _acceptingClassifiers.Select(CountBits)) + ", RP: "
                    + string.Join(", ", _rejectingClassifiers.Select(CountRejectingBits)));
            WrongFeatureCount = wronglyAccepted + wronglyRejected + wronglyRejectedInRejecting;

            SuspiciousAcceptedInAccepting = new List<SuspiciousTarget>();
            SuspiciousRejectedInAccepting = new List<SuspiciousTarget>();
            SuspiciousRejectedInRejecting = new List<SuspiciousTarget>();
            switch (count) {
            case 0:
                //suspiciousAcceptedByAccepting = SelectSuspiciousElements(
                //		suspiciousAcceptedListByAccepting, acceptingClassifiers, BigInteger.Zero, BigInteger.Zero);
                //		//suspiciousAcceptedListByAccepting, acceptingClassifiers, BigInteger.Zero, BigInteger.Zero);
                //suspiciousRejectedByAccepting = SelectSuspiciousElements(
                //		suspiciousRejectedListByAccepting, acceptingClassifiers, BigInteger.Zero, BigInteger.Zero);
                //suspiciousRejectedByRejecting = SelectSuspiciousElements(
                //		suspiciousRejectedListByRejecting, rejectingClassifiers, _rejectingMask, _rejectingMask);
                //suspiciousAcceptedInAccepting = FlattenSuspiciousTargetsList(acceptedInAccepting);
                //suspiciousRejectedInAccepting = FlattenSuspiciousTargetsList(rejectedInAccepting);
                SuspiciousAcceptedInAccepting = SelectVariousElements(
                        acceptedInAccepting, _acceptingMask);
                SuspiciousRejectedInAccepting = SelectVariousElements(
                        rejectedInAccepting, _acceptingMask);
                SuspiciousRejectedInRejecting = FlattenSuspiciousTargetsList(rejectedInRejecting);
                //SuspiciousRejectedInRejecting = SelectVariousElements(rejectedInRejecting, _rejectingMask);
                break;
            case 1:
                SuspiciousAcceptedInAccepting = SelectSuspiciousElementsWithMaskWithSmallGrowing(
                        acceptedInAccepting, BigInteger.Zero, _mask);
                SuspiciousRejectedInAccepting = SelectSuspiciousElementsWithMaskWithSmallGrowing(
                        rejectedInAccepting, _acceptingMask, _acceptingMask);
                SuspiciousRejectedInRejecting = SelectSuspiciousElementsWithMaskWithSmallGrowing(
                        rejectedInRejecting, _rejectingMask, _rejectingMask);
                //suspiciousAcceptedByAccepting = SelectSuspiciousElements(
                //		suspiciousAcceptedListByAccepting, acceptingClassifiers, _acceptingMask, BigInteger.Zero);
                //suspiciousRejectedByAccepting = SelectSuspiciousElements(
                //		suspiciousRejectedListByAccepting, acceptingClassifiers, BigInteger.Zero, BigInteger.Zero);
                //suspiciousRejectedByRejecting = SelectSuspiciousElements(
                //		suspiciousRejectedListByRejecting, rejectingClassifiers, _rejectingMask, _rejectingMask);
                return -1;
                break;
            case 2:
                SuspiciousAcceptedInAccepting = SelectSuspiciousElementsWithMaskWithSmallGrowing(
                        acceptedInAccepting, BigInteger.Zero, _acceptingMask);
                SuspiciousRejectedInAccepting = SelectSuspiciousElementsWithMaskWithSmallGrowing(
                        rejectedInAccepting, BigInteger.Zero, _acceptingMask);
                SuspiciousRejectedInRejecting = SelectSuspiciousElementsWithMaskWithSmallGrowing(
                        rejectedInRejecting, _rejectingMask, _rejectingMask);
                break;
            default:
                return -1;
            }
            Console.WriteLine(
                    "SA(A): " + SuspiciousAcceptedInAccepting.Count
                    + ", SR(A): " + SuspiciousRejectedInAccepting.Count
                    + ", SR(R): " + SuspiciousRejectedInRejecting.Count);

            return count + 1;
        }

        public bool AddNewElements(ICollection<BigInteger> actuallyAcceptedElements) {
            var additionalAccepted =
                    SuspiciousAcceptedInAccepting.Concat(SuspiciousRejectedInAccepting)
                            .Concat(SuspiciousRejectedInRejecting)
                            .Where(t => actuallyAcceptedElements.Contains(t.Feature))
                            .ToList();
            var additionalRejected =
                    SuspiciousAcceptedInAccepting.Concat(SuspiciousRejectedInAccepting)
                            .Concat(SuspiciousRejectedInRejecting)
                            .Where(t => !actuallyAcceptedElements.Contains(t.Feature))
                            .ToList();
            var foundWronglyRejected = SuspiciousRejectedInAccepting.Concat(
                    SuspiciousRejectedInRejecting)
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
                _acceptedTrainingSet.Add(suspiciousTarget.Feature, suspiciousTarget.GroupKey);
            }
            foreach (var suspiciousTarget in additionalRejected) {
                _rejectedTrainingSet.Add(suspiciousTarget.Feature, suspiciousTarget.GroupKey);
            }

            var finalAcceptingClassifiers = _acceptingClassifiers.ToList();
            var finalRejectingClassifiers = _rejectingClassifiers.ToList();
            CreateClassifiers();
            var ret = foundWronglyRejected + foundWronglyAccepted == 0
                      && finalAcceptingClassifiers.SequenceEqual(_acceptingClassifiers)
                      && finalRejectingClassifiers.SequenceEqual(_rejectingClassifiers);
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
                        if (minDiffCount != 0 && minDiffCount > diffCount) {
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
                IList<SuspiciousTarget> existings, IEnumerable<SuspiciousTarget> targets,
                BigInteger mask) {
            if (existings.Count == 0) {
                return targets.FirstOrDefault();
            }
            var maxDiff = 0;
            SuspiciousTarget ret = null;
            foreach (var t in targets) {
                var feature = t.Feature & mask;
                var diff = existings.Min(e => CountBits((e.Feature & mask) ^ feature));
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
                    var e = SelectMostDifferentElement(ret, list, mask);
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

        #endregion

        private GroupInfo CanReject(
                IList<BigInteger> acceptingClassifiers, IList<BigInteger> rejectingClassifiers,
                Dictionary<BigInteger, string> rejected) {
            foreach (var featureAndGroupKey in rejected) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(groupKey);
                if (IsAccepted(feature, acceptingClassifiers[groupIndex])
                    && !IsRejected(feature, rejectingClassifiers[groupIndex])) {
                    return new GroupInfo { Index = groupIndex, Key = groupKey };
                }
            }
            return null;
        }

        private bool IsAccepted(BigInteger feature, BigInteger acceptingClassifier) {
            // ëSÇƒÇÃê´éøÇîıÇ¶ÇƒÇ¢ÇÍÇŒAccepted
            return (feature & acceptingClassifier) == acceptingClassifier;
        }

        private bool IsRejected(BigInteger feature, BigInteger rejectingClassifier) {
            // Ç¢Ç∏ÇÍÇ©ÇÃê´éøÇîıÇ¶ÇƒÇ¢ÇÍÇŒRejected
            // RejectÇ™Ç»Ç¢èÍçáÇ‡ê≥èÌÇ…ìÆçÏ
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

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(A): ");
            foreach (var featureAndGroupKey in _idealAccepted) {
                var feature = featureAndGroupKey.Key;
                var classifier = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(classifier);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(A): ");
            foreach (var featureAndGroupKey in _idealRejected) {
                var feature = featureAndGroupKey.Key;
                var classifier = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(classifier);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(A): ");
            foreach (var featureAndGroupKey in _wronglyAcceptedFeatures) {
                var feature = featureAndGroupKey.Key;
                var classifier = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(classifier);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(A): ");
            foreach (var featureAndGroupKey in _wronglyRejectedFeatures) {
                var feature = featureAndGroupKey.Key;
                var classifier = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(classifier);
                Console.Write(
                        CountAcceptingBits(feature & _acceptingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------------------------------------------");
            Console.Write("A(R): ");
            foreach (var featureAndGroupKey in _idealAccepted) {
                var feature = featureAndGroupKey.Key;
                var classifier = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(classifier);
                Console.Write(
                        CountRejectingBits(feature & _rejectingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("R(R): ");
            foreach (var featureAndGroupKey in _idealRejected) {
                var feature = featureAndGroupKey.Key;
                var groupKey = featureAndGroupKey.Value;
                var groupIndex = GetGroupIndex(groupKey);
                Console.Write(
                        CountRejectingBits(feature & _rejectingClassifiers[groupIndex]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WA(R): ");
            foreach (var featureAndGroupKey in _wronglyAcceptedFeatures) {
                var feature = featureAndGroupKey.Key;
                var classifier = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(classifier);
                Console.Write(
                        CountRejectingBits(feature & _rejectingClassifiers[iClassifier]) + ", ");
            }
            Console.WriteLine();
            Console.Write("WR(R): ");
            foreach (var featureAndGroupKey in _wronglyRejectedFeatures) {
                var feature = featureAndGroupKey.Key;
                var classifier = featureAndGroupKey.Value;
                var iClassifier = GetGroupIndex(classifier);
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

        protected abstract bool ProtectedIsAcceptedUsingOracle(CstNode e);
    }
}