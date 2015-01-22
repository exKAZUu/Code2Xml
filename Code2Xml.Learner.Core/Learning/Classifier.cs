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
using System.Linq;
using System.Numerics;

namespace Code2Xml.Learner.Core.Learning {
	[Serializable]
	public class Classifier {
		private class UpdateResult {
			public GroupInfo Accepted { get; set; }
			public GroupInfo Rejected { get; set; }
		}

		private class GroupInfo {
			public string Path { get; set; }
			public int Index { get; set; }
		}

		private readonly FeatureEncoder _featureEncoder;
		private readonly EncodingResult _encodingResult;

		private readonly Dictionary<BigInteger, string> _trainingAcceptedVector2GroupPath;
		private readonly Dictionary<BigInteger, string> _trainingRejectedVector2GroupPath;

		private readonly int _acceptingFeatureCount;
		public BigInteger AcceptingFeatureBitMask { get; private set; }
		public BigInteger RejectingFeatureBitMask { get; private set; }
		public BigInteger AllFeatureBitMask { get; private set; }

		private List<string> _currentGroupPaths;
		private Dictionary<BigInteger, int> _vector2GroupIndex;

		public int GroupCount {
			get { return _currentGroupPaths.Count; }
		}

		public List<ClassifierUnit> Classifiers { get; set; }

		public Classifier(
				FeatuerSet featureSet, FeatureEncoder featureEncoder, EncodingResult encodingResult) {
			_featureEncoder = featureEncoder;
			_encodingResult = encodingResult;
			_acceptingFeatureCount = featureSet.AcceptingFeatures.Count;

			AllFeatureBitMask = (BigInteger.One << featureSet.FeatureCount) - BigInteger.One;
			AcceptingFeatureBitMask = (BigInteger.One << featureSet.AcceptingFeatureCount) - BigInteger.One;
			RejectingFeatureBitMask = AllFeatureBitMask ^ AcceptingFeatureBitMask;

			_trainingAcceptedVector2GroupPath =
					new Dictionary<BigInteger, string>(encodingResult.SeedAcceptedVector2GroupPath);
			_trainingRejectedVector2GroupPath =
					new Dictionary<BigInteger, string>(encodingResult.SeedRejectedVector2GroupPath);

			InitializeGroups(featureSet);
			UpdateGroupCache();
			Create();
		}

		public void InitializeGroups(FeatuerSet featureSet) {
			_currentGroupPaths = featureSet.SelectedNodeNames.Select(n => ">" + n + ">").ToList();
		}

		public bool IsAccepted(BigInteger vector, int groupIndex) {
			var acceptingClassifier = Classifiers[groupIndex].Accepting;
			return (vector & acceptingClassifier) == acceptingClassifier;
		}

		public bool IsRejected(BigInteger vector, int groupIndex) {
			var rejectingClassifier = Classifiers[groupIndex].Rejecting;
			return (vector & rejectingClassifier) != BigInteger.Zero;
		}

		#region Group cache

		public int GetGroupIndexWithCache(BigInteger feature) {
			return _vector2GroupIndex[feature];
		}

		public int GetGroupIndexWithoutCache(string groupPath) {
			for (int i = _currentGroupPaths.Count - 1; i >= 0; i--) {
				if (groupPath.StartsWith(_currentGroupPaths[i])) {
					return i;
				}
			}
			throw new Exception("Can't find the given group key: " + groupPath);
		}

		private void UpdateGroupCache() {
			_vector2GroupIndex = new Dictionary<BigInteger, int>();
			foreach (var kv in _encodingResult.IdealAcceptedVector2GroupPath) {
				var index = GetGroupIndexWithoutCache(kv.Value);
				_vector2GroupIndex.Add(kv.Key, index);
			}
			foreach (var kv in _encodingResult.IdealRejectedVector2GroupPath) {
				var index = GetGroupIndexWithoutCache(kv.Value);
				_vector2GroupIndex.Add(kv.Key, index);
			}
		}

		#endregion

		#region Create / Update classifiers

		public void Update(IDictionary<BigInteger, string> acceptedVector2GroupPath) {
			if (!UpdateClassifierUnits(acceptedVector2GroupPath)) {
				Create();
			}
		}

		public void Create() {
			do {
				Initialize();
			} while (!UpdateClassifierUnits(_trainingAcceptedVector2GroupPath));
		}

		private void Initialize() {
			Classifiers = Enumerable.Repeat(0, _currentGroupPaths.Count)
					.Select(_ => new ClassifierUnit(AcceptingFeatureBitMask, RejectingFeatureBitMask))
					.ToList();
		}

		private bool UpdateClassifierUnits(IDictionary<BigInteger, string> acceptedTrainingSet) {
			UpdateRejectingClassifierUnits(acceptedTrainingSet.Keys);
			var result = UpdateAcceptingClassifierUnits(acceptedTrainingSet);
			if (result == null) {
				return true;
			}
			var count = _currentGroupPaths.Count;
			var updated = false;
			if (result.Accepted != null
			    && result.Accepted.Path != _currentGroupPaths[result.Accepted.Index]) {
				updated |= AddNewGroup(result.Accepted);
			}
			if (result.Rejected.Path != _currentGroupPaths[result.Rejected.Index]) {
				updated |= AddNewGroup(result.Rejected);
			}
			if (updated) {
				UpdateGroupCache();
			}
			// ReSharper disable once PossibleUnintendedReferenceComparison
			if (_currentGroupPaths.Count == count
			    && acceptedTrainingSet == _trainingAcceptedVector2GroupPath) {
				throw new Exception("Fail to learn rules");
			}
			Console.WriteLine("Failed to create classifier units.");
			Console.WriteLine("Groups: " + _currentGroupPaths.Count + " (" + count + ")");
			return false;
		}

		private UpdateResult UpdateAcceptingClassifierUnits(
				IDictionary<BigInteger, string> acceptedVector2GroupPath) {
			if (acceptedVector2GroupPath.Count == 0) {
				var rejectedGroupInfo = FindWronglyAcceptedGroupInfo();
				if (rejectedGroupInfo != null) {
					return new UpdateResult {
						Rejected = rejectedGroupInfo,
						Accepted = null,
					};
				}
				return null;
			}
			foreach (var vectorAndGroupPath in acceptedVector2GroupPath) {
				var vector = vectorAndGroupPath.Key;
				var groupIndex = GetGroupIndexWithCache(vector);
				Classifiers[groupIndex].Accepting &= vector;
				var rejectedGroupInfo = FindWronglyAcceptedGroupInfo();
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

		private void UpdateRejectingClassifierUnits(IEnumerable<BigInteger> acceptedTrainingSet) {
			var count = Classifiers.Count;
			for (int i = 0; i < count; i++) {
				Classifiers[i].Rejecting ^= RejectingFeatureBitMask;
			}
			foreach (var vector in acceptedTrainingSet) {
				var iGroupKey = GetGroupIndexWithCache(vector);
				Classifiers[iGroupKey].Rejecting |= vector;
			}
			for (int i = 0; i < count; i++) {
				Classifiers[i].Rejecting ^= RejectingFeatureBitMask;
				Classifiers[i].Rejecting &= RejectingFeatureBitMask;
			}
		}

		private bool AddNewGroup(GroupInfo info) {
			var i = info.Path.IndexOf('>', _currentGroupPaths[info.Index].Length + 1);
			var newGroupPath = info.Path.Substring(0, i + 1);
			if (!_currentGroupPaths.Contains(newGroupPath)) {
				_currentGroupPaths.Add(newGroupPath);
				return true;
			}
			return false;
		}

		private GroupInfo FindWronglyAcceptedGroupInfo() {
			foreach (var featureAndGroupPath in _trainingRejectedVector2GroupPath) {
				var feature = featureAndGroupPath.Key;
				var groupPath = featureAndGroupPath.Value;
				var groupIndex = GetGroupIndexWithCache(feature);
				var accepted = LearningExperimentUtil.IsAccepted(feature, Classifiers[groupIndex].Accepting)
				               && !LearningExperimentUtil.IsRejected(feature, Classifiers[groupIndex].Rejecting);
				if (accepted) {
					return new GroupInfo { Index = groupIndex, Path = groupPath };
				}
			}
			return null;
		}

		#endregion

		#region for Debug

		public List<List<string>> GetAllAcceptingFeatureStrings() {
			return Classifiers
					.Select(cl => _featureEncoder.GetFeatureStringsByVector(cl.Accepting).ToList())
					.ToList();
		}

		public List<List<string>> GetAllRejectingFeatureStrings() {
			return Classifiers
					.Select(cl => _featureEncoder.GetFeatureStringsByVector(cl.Rejecting).ToList())
					.ToList();
		}

		public string GetClassifierSummary() {
			var acceptingFeatureCounts = String.Join(", ", CountAcceptingFeatures());
			var rejectingFeatureCounts = String.Join(", ", CountRejectingFeatures());
			return "AP: " + acceptingFeatureCounts + ", RP: " + rejectingFeatureCounts;
		}

		#endregion

	    public static int CountBits(BigInteger bits) {
		    var count = 0;
		    while (bits != BigInteger.Zero) {
			    count += (int)(bits & BigInteger.One);
			    bits >>= 1;
		    }
		    return count;
	    }

	    public IEnumerable<int> CountAcceptingFeatures() {
		    return Classifiers.Select(c => CountBits(c.Accepting & AcceptingFeatureBitMask));
	    }

	    public IEnumerable<int> CountRejectingFeatures() {
		    return Classifiers.Select(c => CountBits(c.Rejecting  >> _acceptingFeatureCount));
	    }
	}
}