using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
    [Serializable]
    public class Classifier {
        public class UpdateResult {
            public GroupInfo Accepted { get; set; }
            public GroupInfo Rejected { get; set; }
        }

        public class GroupInfo {
            public string Path { get; set; }
            public int Index { get; set; }
        }

        public readonly int AcceptingFeatureCount;
        public readonly int RejectingFeatureCount;
        public readonly int AllFeatureCount;
        public readonly BigInteger AcceptingFeatureBitMask;
        public readonly BigInteger RejectingFeatureBitMask;
        public readonly BigInteger AllFeatureBitMask;

        public IList<ClassifierUnit> Units { get; private set; }
        public IList<string> GroupPaths { get; private set; }

        public int GroupCount {
            get { return GroupPaths.Count; }
        }

        public Classifier(IEnumerable<string> selectedNodeNames, FeatuerSet featureSet) {
            AcceptingFeatureCount = featureSet.AcceptingFeatureCount;
            RejectingFeatureCount = featureSet.RejectingFeatureCount;
            AllFeatureCount = AcceptingFeatureCount + RejectingFeatureCount;
            AllFeatureBitMask = (BigInteger.One << featureSet.FeatureCount) - BigInteger.One;
            AcceptingFeatureBitMask = (BigInteger.One << featureSet.AcceptingFeatureCount)
                                      - BigInteger.One;
            RejectingFeatureBitMask = AllFeatureBitMask ^ AcceptingFeatureBitMask;
            GroupPaths = selectedNodeNames.Select(n => ">" + n + ">").ToList();
            Initialize();
        }

        /// <summary>
        /// ï™óﬁåãâ Ç…âeãøÇó^Ç¶Ç»Ç¢acceptingFeatureÇéÊÇËèúÇ≠ÅB
        /// </summary>
        /// <param name="rejectedVectors"></param>
        /// <param name="groupCache"></param>
        public void Optimize(IEnumerable<BigInteger> rejectedVectors, GroupCache groupCache) {
            var groupIndex2RejectedVectors = new List<List<BigInteger>>();
            for (int i = 0; i < Units.Count; i++) {
                groupIndex2RejectedVectors.Add(new List<BigInteger>());
            }
            foreach (var rejectedVector in rejectedVectors) {
                var groupIndex = groupCache.GetGroupIndex(rejectedVector);
                var acceptingClassifier = Units[groupIndex].Accepting;
                var accepted = (rejectedVector & acceptingClassifier) == acceptingClassifier;
                if (!accepted) {
                    groupIndex2RejectedVectors[groupIndex].Add(rejectedVector);
                }
            }
            foreach (var unitAndVectors in Units.Zip(groupIndex2RejectedVectors)) {
                var unit = unitAndVectors.Item1;
                var vectors = unitAndVectors.Item2;
                var bit = BigInteger.One;
                for (int i = 0; i < AcceptingFeatureCount; i++) {
                    if ((unit.Accepting & bit) != 0) {
                        unit.Accepting ^= bit;
                        var acceptingClassifier = unit.Accepting;
                        foreach (var rejectedVector in vectors) {
                            var accepted = (rejectedVector & acceptingClassifier) == acceptingClassifier;
                            if (accepted) {
                                unit.Accepting ^= bit;
                                break;
                            }
                        }
                    }
                    bit <<= 1;
                }
            }
        }

        /// <summary>
        /// Ç«ÇÒÇ»Ç«ÇÒÇ»RejectedVectorÇ‡éùÇΩÇ»Ç¢AcceptingFeatuerÇçÌèúÇ∑ÇÈÅB
        /// </summary>
        /// <param name="rejectedVectors"></param>
        /// <param name="groupCache"></param>
        public void OptimizeWeakly(ICollection<BigInteger> rejectedVectors, GroupCache groupCache) {
            var usedRejectedFeatures =
                    Enumerable.Repeat(RejectingFeatureBitMask, Units.Count).ToList();
            foreach (var rejectedVector in rejectedVectors) {
                var groupIndex = groupCache.GetGroupIndex(rejectedVector);
                usedRejectedFeatures[groupIndex] |= rejectedVector;
            }
            foreach (var unitAndFeature in Units.Zip(usedRejectedFeatures)) {
                unitAndFeature.Item1.Accepting &= AllFeatureBitMask ^ unitAndFeature.Item2;
            }
        }

        public bool IsAccepted(BigInteger vector, int groupIndex) {
            var acceptingClassifier = Units[groupIndex].Accepting;
            return (vector & acceptingClassifier) == acceptingClassifier;
        }

        public bool IsRejected(BigInteger vector, int groupIndex) {
            var rejectingClassifier = Units[groupIndex].Rejecting;
            return (vector & rejectingClassifier) != BigInteger.Zero;
        }

        public int GetGroupIndex(string groupPath) {
            for (int i = GroupPaths.Count - 1; i >= 0; i--) {
                if (groupPath.StartsWith(GroupPaths[i])) {
                    return i;
                }
            }
            throw new Exception("Can't find the given group key: " + groupPath);
        }

        public void MakeImmutable() {
            Units = Units.ToImmutableList();
            GroupPaths = GroupPaths.ToImmutableList();
        }

        #region Builder

        public bool Update(
                IDictionary<BigInteger, string> additionalAcceptedSet, RevealedVectorSet trainingSet,
                GroupCache groupCache) {
            var originalClassifierUnit = Units.Select(c => c.Clone()).ToImmutableList();
            if (!UpdateClassifierUnits(additionalAcceptedSet, trainingSet, groupCache)) {
                Create(trainingSet, groupCache);
            }
            return !Units.SequenceEqual(originalClassifierUnit);
        }

        public void Create(RevealedVectorSet trainingSet, GroupCache groupCache) {
            do {
                Initialize();
            } while (!UpdateClassifierUnits(trainingSet.Accepted, trainingSet, groupCache));
        }

        private void Initialize() {
            Units = Enumerable.Repeat(0, GroupPaths.Count)
                    .Select(_ =>
                            new ClassifierUnit(AcceptingFeatureBitMask, RejectingFeatureBitMask))
                    .ToList();
        }

        private bool UpdateClassifierUnits(
                IDictionary<BigInteger, string> additionalAcceptedSet, RevealedVectorSet trainingSet,
                GroupCache groupCache) {
            UpdateRejectingClassifierUnits(additionalAcceptedSet.Keys, groupCache);
            var result = UpdateAcceptingClassifierUnits(additionalAcceptedSet, trainingSet,
                    groupCache);
            if (result == null) {
                return true;
            }
            var count = GroupPaths.Count;
            var updated = false;
            if (result.Accepted != null
                && result.Accepted.Path != GroupPaths[result.Accepted.Index]) {
                updated |= AddNewGroup(result.Accepted);
            }
            if (result.Rejected.Path != GroupPaths[result.Rejected.Index]) {
                updated |= AddNewGroup(result.Rejected);
            }
            if (updated) {
                groupCache.UpdateGroupCache(this);
            }
            // ReSharper disable once PossibleUnintendedReferenceComparison
            if (GroupPaths.Count == count
                && additionalAcceptedSet == trainingSet.Accepted) {
                throw new Exception("Fail to learn rules");
            }
            Console.WriteLine("Failed to create Classifier units.");
            Console.WriteLine("Groups: " + GroupPaths.Count + " (" + count + ")");
            return false;
        }

        private void UpdateRejectingClassifierUnits(
                IEnumerable<BigInteger> acceptedVectors, GroupCache groupCache) {
            var count = Units.Count;
            for (int i = 0; i < count; i++) {
                Units[i].Rejecting ^= RejectingFeatureBitMask;
            }
            foreach (var vector in acceptedVectors) {
                var iGroupKey = groupCache.GetGroupIndex(vector);
                Units[iGroupKey].Rejecting |= vector;
            }
            for (int i = 0; i < count; i++) {
                Units[i].Rejecting ^= RejectingFeatureBitMask;
                Units[i].Rejecting &= RejectingFeatureBitMask;
            }
        }

        private UpdateResult UpdateAcceptingClassifierUnits(
                IDictionary<BigInteger, string> additionalAcceptedSet, RevealedVectorSet trainingSet,
                GroupCache groupCache) {
            if (additionalAcceptedSet.Count == 0) {
                var rejectedGroupInfo = FindWronglyAcceptedGroupInfo(trainingSet, groupCache);
                if (rejectedGroupInfo != null) {
                    return new UpdateResult {
                        Rejected = rejectedGroupInfo,
                        Accepted = null,
                    };
                }
                return null;
            }
            foreach (var vectorAndGroupPath in additionalAcceptedSet) {
                var vector = vectorAndGroupPath.Key;
                var groupIndex = groupCache.GetGroupIndex(vector);
                Units[groupIndex].Accepting &= vector;
                var rejectedGroupInfo = FindWronglyAcceptedGroupInfo(trainingSet, groupCache);
                if (rejectedGroupInfo != null) {
                    return new UpdateResult {
                        Rejected = rejectedGroupInfo,
                        Accepted = new GroupInfo {
                            Index = groupIndex, Path = vectorAndGroupPath.Value
                        },
                    };
                }
            }
            return null;
        }

        private GroupInfo FindWronglyAcceptedGroupInfo(
                RevealedVectorSet trainingSet, GroupCache groupCache) {
            foreach (var featureAndGroupPath in trainingSet.Rejected) {
                var feature = featureAndGroupPath.Key;
                var groupPath = featureAndGroupPath.Value;
                var groupIndex = groupCache.GetGroupIndex(feature);
                var accepted = IsAccepted(feature, groupIndex) && !IsRejected(feature, groupIndex);
                if (accepted) {
                    return new GroupInfo { Index = groupIndex, Path = groupPath };
                }
            }
            return null;
        }

        private bool AddNewGroup(GroupInfo info) {
            var i = info.Path.IndexOf('>', GroupPaths[info.Index].Length + 1);
            var newGroupPath = info.Path.Substring(0, i + 1);
            if (!GroupPaths.Contains(newGroupPath)) {
                GroupPaths.Add(newGroupPath);
                return true;
            }
            return false;
        }

        #endregion

        #region Debug

        public List<List<string>> GetAllAcceptingFeatureStrings(FeatureEncoder featureEncoder) {
            return Units.Select(cl =>
                    featureEncoder.GetFeatureStringsByVector(cl.Accepting).ToList()).ToList();
        }

        public List<List<string>> GetAllRejectingFeatureStrings(FeatureEncoder featureEncoder) {
            return Units.Select(cl =>
                    featureEncoder.GetFeatureStringsByVector(cl.Rejecting).ToList()).ToList();
        }

        public string GetClassifierSummary() {
            var acceptingFeatureCounts = String.Join(", ", CountAcceptingFeatures());
            var rejectingFeatureCounts = String.Join(", ", CountRejectingFeatures());
            return "#AF: " + acceptingFeatureCounts + ", #RF: " + rejectingFeatureCounts;
        }

        public IEnumerable<int> CountAcceptingFeatures() {
            return Units.Select(c =>
                    LearningExperimentUtil.CountBits(c.Accepting & AcceptingFeatureBitMask));
        }

        public IEnumerable<int> CountRejectingFeatures() {
            return Units.Select(c =>
                    LearningExperimentUtil.CountBits(c.Rejecting >> AcceptingFeatureCount));
        }

        public IList<int> CountAcceptedVectorsOfEachGroup(EncodingResult encodingResult) {
            return CountVectorsOfEachGroup(encodingResult.IdealAcceptedVector2GroupPath.Values);
        }

        public IList<int> CountRejectedVectorsOfEachGroup(EncodingResult encodingResult) {
            return CountVectorsOfEachGroup(encodingResult.IdealRejectedVector2GroupPath.Values);
        }

        private IList<int> CountVectorsOfEachGroup(IEnumerable<string> groupPaths) {
            var counts = new int[GroupCount];
            foreach (var groupPath in groupPaths) {
                counts[GetGroupIndex(groupPath)]++;
            }
            return counts;
        }

        #endregion
    }
}