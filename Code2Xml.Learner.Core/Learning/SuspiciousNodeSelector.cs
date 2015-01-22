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
	public class SuspiciousNodeSelector {
		private const int LearningCount = 5;
		private const int TargetCount = 5;
		private const int StronglyTargetCount = 10000000;
		private const int ThresholdvectorCount = 10000000;

		private readonly BigInteger _acceptingFeatureBitMask;
		private readonly BigInteger _rejectingFeatureBitMask;

		public SuspiciousNodeSelector(BigInteger acceptingFeatureBitMask, BigInteger rejectingFeatureBitMask) {
			_acceptingFeatureBitMask = acceptingFeatureBitMask;
			_rejectingFeatureBitMask = rejectingFeatureBitMask;
		}

		public List<SuspiciousNode> SelectSuspiciousNodes(
				int count, Classifier classifiers, List<List<SuspiciousNode>> acceptAccept,
				List<List<SuspiciousNode>> acceptReject, List<List<SuspiciousNode>> rejectAccept,
				List<List<SuspiciousNode>> rejectReject) {
			var suspiciousNodes = new List<SuspiciousNode>();

			switch (count) {
			case 0:
				var time1 = Environment.TickCount;
				suspiciousNodes.AddRange(SelectSuspiciousAcceptedNodes(acceptAccept, classifiers));
				suspiciousNodes.AddRange(SelectSuspiciousAcceptedNodes(acceptReject, classifiers));
				suspiciousNodes.AddRange(SelectSuspiciousRejectedNodes(acceptAccept, classifiers));
				suspiciousNodes.AddRange(SelectSuspiciousRejectedNodes(rejectAccept, classifiers));

				suspiciousNodes.AddRange(SelectNodesForFastAcceptanceLearning(rejectAccept, classifiers));
				//suspiciousNodes.AddRange(SelectNodesForSlowAcceptanceLearning(rejectAccept));
				suspiciousNodes.AddRange(SelectNodesForFastAcceptanceLearning(rejectReject, classifiers));
				//suspiciousNodes.AddRange(SelectNodesForSlowAcceptanceLearning(rejectReject));

				suspiciousNodes.AddRange(SelectNodesForFastRejectionLearning(acceptReject, classifiers));
				//suspiciousNodes.AddRange(SelectNodesForSlowRejectionLearning(acceptReject));
				suspiciousNodes.AddRange(SelectNodesForFastRejectionLearning(rejectReject, classifiers));
				//suspiciousNodes.AddRange(SelectNodesForSlowRejectionLearning(rejectReject));
				Console.WriteLine("SelectSuspiciousAcceptedNodes: " + (Environment.TickCount - time1));
				break;
			case 1:
				var time2 = Environment.TickCount;
				//suspiciousNodes.AddRange(SelectSuspiciousAcceptedNodesStrongly(acceptAccept));
				//suspiciousNodes.AddRange(SelectSuspiciousAcceptedNodesStrongly(acceptReject));
				//suspiciousNodes.AddRange(SelectSuspiciousRejectedNodesStrongly(acceptAccept));
				//suspiciousNodes.AddRange(SelectSuspiciousRejectedNodesStrongly(rejectAccept));

				//suspiciousNodes.AddRange(SelectNodesForFastAcceptanceLearningStrongly(rejectAccept));
				suspiciousNodes.AddRange(
						SelectNodesForSlowAcceptanceLearningStrongly(rejectAccept, classifiers));
				//suspiciousNodes.AddRange(SelectNodesForFastAcceptanceLearningStrongly(rejectReject));
				suspiciousNodes.AddRange(
						SelectNodesForSlowAcceptanceLearningStrongly(rejectReject, classifiers));

				//suspiciousNodes.AddRange(SelectNodesForFastRejectionLearningStrongly(acceptReject));
				suspiciousNodes.AddRange(SelectNodesForSlowRejectionLearningStrongly(acceptReject, classifiers));
				//suspiciousNodes.AddRange(SelectNodesForFastRejectionLearningStrongly(rejectReject));
				suspiciousNodes.AddRange(SelectNodesForSlowRejectionLearningStrongly(rejectReject, classifiers));
				Console.WriteLine("SelectSuspiciousAcceptedNodesStrongly: " + (Environment.TickCount - time2));
				break;
			default:
				return null;
			}
			Console.WriteLine("Suspicious nodes: " + suspiciousNodes.Count);
			return suspiciousNodes;
		}

		#region Latest selectors

		public IEnumerable<SuspiciousNode> SelectSuspiciousAcceptedNodes(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				foreach (var candidate in candidates) {
					candidate.BitsCount = LearningExperimentUtil.CountBits(candidate.Vector & _acceptingFeatureBitMask);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var count = DetermineCount(i, classifiers);
				foreach (var candidate in candidates) {
					if (candidate.Used) {
						continue;
					}
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectSuspiciousRejectedNodes(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				foreach (var candidate in candidates) {
					candidate.BitsCount = LearningExperimentUtil.CountBits(candidate.Vector & _rejectingFeatureBitMask);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var count = DetermineCount(i, classifiers);
				for (int j = candidates.Count - 1; j >= 0; j--) {
					var candidate = candidates[j];
					if (candidate.Used) {
						continue;
					}
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForFastAcceptanceLearning(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Accepting;
				foreach (var candidate in candidates) {
					candidate.BitsCount = LearningExperimentUtil.CountBits(candidate.Vector & classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var count = DetermineCount(i, classifiers);
				foreach (var candidate in candidates) {
					if (candidate.Used) {
						continue;
					}
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForSlowAcceptanceLearning(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Accepting;
				foreach (var target in candidates) {
					target.BitsCount = LearningExperimentUtil.CountBits(target.Vector & classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var count = DetermineCount(i, classifiers);
				for (int j = candidates.Count - 1; j >= 0; j--) {
					var candidate = candidates[j];
					if (candidate.Used) {
						continue;
					}
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForFastRejectionLearning(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Rejecting;
				foreach (var cnadidate in candidates) {
					cnadidate.BitsCount = LearningExperimentUtil.CountBits(
							(cnadidate.Vector & _rejectingFeatureBitMask) | classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var count = DetermineCount(i, classifiers);
				for (int j = candidates.Count - 1; j >= 0; j--) {
					var candidate = candidates[j];
					if (candidate.Used) {
						continue;
					}
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForSlowRejectionLearning(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Rejecting;
				foreach (var candidate in candidates) {
					candidate.BitsCount = LearningExperimentUtil.CountBits(
							(candidate.Vector & _rejectingFeatureBitMask) | classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var count = DetermineCount(i, classifiers);
				foreach (var candidate in candidates) {
					if (candidate.Used) {
						continue;
					}
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectSuspiciousAcceptedNodesStrongly(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				foreach (var candidate in candidates) {
					candidate.BitsCount = LearningExperimentUtil.CountBits(candidate.Vector & _acceptingFeatureBitMask);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var vector = BigInteger.Zero;
				var count = DetermineStrongCount(i, classifiers);
				foreach (var candidate in candidates) {
					if (candidate.Used) {
						continue;
					}
					var newVector = (vector | candidate.Vector) & _acceptingFeatureBitMask;
					if (newVector == vector) {
						continue;
					}
					vector = newVector;
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectSuspiciousRejectedNodesStrongly(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				foreach (var target in candidates) {
					target.BitsCount = LearningExperimentUtil.CountBits(target.Vector & _rejectingFeatureBitMask);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var vector = _rejectingFeatureBitMask;
				var count = DetermineStrongCount(i, classifiers);
				for (int j = candidates.Count - 1; j >= 0; j--) {
					var candidate = candidates[j];
					if (candidate.Used) {
						continue;
					}
					var newVector = vector & candidate.Vector;
					if (newVector == vector) {
						continue;
					}
					vector = newVector;
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForFastAcceptanceLearningStrongly(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Accepting;
				foreach (var target in candidates) {
					target.BitsCount = LearningExperimentUtil.CountBits(target.Vector & classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var vector = BigInteger.Zero;
				var count = DetermineStrongCount(i, classifiers);
				foreach (var candidate in candidates) {
					if (candidate.Used) {
						continue;
					}
					var newVector = (vector | candidate.Vector) & _acceptingFeatureBitMask;
					if (newVector == vector) {
						continue;
					}
					vector = newVector;
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForSlowAcceptanceLearningStrongly(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Accepting;
				foreach (var target in candidates) {
					target.BitsCount = LearningExperimentUtil.CountBits(target.Vector & classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var vector = BigInteger.Zero;
				var count = DetermineStrongCount(i, classifiers);
				for (int j = candidates.Count - 1; j >= 0; j--) {
					var candidate = candidates[j];
					if (candidate.Used) {
						continue;
					}
					var newVector = (vector | candidate.Vector) & _acceptingFeatureBitMask;
					if (newVector == vector) {
						continue;
					}
					vector = newVector;
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForFastRejectionLearningStrongly(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Rejecting;
				foreach (var candidate in candidates) {
					candidate.BitsCount = LearningExperimentUtil.CountBits(
							(candidate.Vector & _rejectingFeatureBitMask) | classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var vector = _rejectingFeatureBitMask;
				var count = DetermineStrongCount(i, classifiers);
				for (int j = candidates.Count - 1; j >= 0; j--) {
					var candidate = candidates[j];
					if (candidate.Used) {
						continue;
					}
					var newVector = vector & candidate.Vector;
					if (newVector == vector) {
						continue;
					}
					vector = newVector;
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		public IEnumerable<SuspiciousNode> SelectNodesForSlowRejectionLearningStrongly(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var candidates = candidateNodesLists[i];
				var classifier = classifiers[i].Rejecting;
				foreach (var target in candidates) {
					target.BitsCount = LearningExperimentUtil.CountBits(
							(target.Vector & _rejectingFeatureBitMask) | classifier);
				}
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				var vector = _rejectingFeatureBitMask;
				var count = DetermineStrongCount(i, classifiers);
				foreach (var candidate in candidates) {
					if (!candidate.Used) {
						continue;
					}
					var newVector = vector & candidate.Vector;
					if (newVector == vector) {
						continue;
					}
					vector = newVector;
					yield return candidate;
					candidate.Used = true;
					if (--count == 0) {
						break;
					}
				}
			}
		}

		private static int DetermineCount(int i, IReadOnlyList<ClassifierUnit> classifiers) {
			return LearningExperimentUtil.CountBits(classifiers[i].Accepting) > ThresholdvectorCount
					? TargetCount : TargetCount / 2;
		}

		private static int DetermineStrongCount(int i, IReadOnlyList<ClassifierUnit> classifiers) {
			return LearningExperimentUtil.CountBits(classifiers[i].Accepting) > ThresholdvectorCount
					? StronglyTargetCount : StronglyTargetCount / 2;
		}

		#endregion

		#region Old selector

		private IEnumerable<SuspiciousNode> SelectSuspiciousElementsWithMaskWithSmallGrowing(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists, BigInteger xor, BigInteger mask) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var vector = BigInteger.Zero;
				var candidates = candidateNodesLists[i];
				while (true) {
					var minDiffCount = int.MaxValue;
					SuspiciousNode newNode = null;
					foreach (var candidate in candidates) {
						var newVector = (vector | (candidate.Vector ^ xor)) & mask;
						var diff = newVector ^ vector;
						var diffCount = LearningExperimentUtil.CountBits(diff);
						if (diffCount > 0 && minDiffCount > diffCount) {
							minDiffCount = diffCount;
							vector = newVector;
							newNode = candidate;
						}
					}
					if (newNode != null) {
						yield return newNode;
					} else {
						break;
					}
				}
			}
		}

		private IEnumerable<SuspiciousNode> SelectSuspiciousElementsWithMask(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists, BigInteger xor, BigInteger mask) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var vector = BigInteger.Zero;
				var candidates = candidateNodesLists[i];
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
				foreach (var candidate in candidates) {
					var newVector = (vector | (candidate.Vector ^ xor)) & mask;
					if (newVector != vector) {
						vector = newVector;
						yield return candidate;
					}
				}
			}
		}

		private List<SuspiciousNode> FlattenSuspiciouscandidateNodesLists(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists) {
			var ret = new List<SuspiciousNode>();
			var indices = Enumerable.Repeat(0, candidateNodesLists.Count).ToList();
			foreach (List<SuspiciousNode> list in candidateNodesLists) {
				list.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
			}
			while (ret.Count < LearningCount) {
				var added = false;
				for (int i = 0; i < candidateNodesLists.Count; i++) {
					var list = candidateNodesLists[i];
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

		private SuspiciousNode SelectMostDifferentElement(
				IEnumerable<BigInteger> existings, IEnumerable<SuspiciousNode> candidates,
				BigInteger mask) {
			if (!existings.Any()) {
				return candidates.FirstOrDefault();
			}
			var maxDiff = 0;
			SuspiciousNode ret = null;
			foreach (var candidate in candidates) {
				var vector = candidate.Vector & mask;
				var diff = existings.Min(f => LearningExperimentUtil.CountBits((f & mask) ^ vector));
				if (maxDiff < diff) {
					maxDiff = diff;
					ret = candidate;
				}
			}
			return ret;
		}

		private List<SuspiciousNode> SelectVariousElements(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists, BigInteger mask) {
			var ret = new List<SuspiciousNode>();
			foreach (var list in candidateNodesLists) {
				list.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
			}
			while (ret.Count < LearningCount) {
				var added = false;
				foreach (var candidates in candidateNodesLists) {
					var e = SelectMostDifferentElement(ret.Select(t => t.Vector), candidates, mask);
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

		private List<SuspiciousNode> SelectVariousElementsExisting(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists, IList<BigInteger> existings,
				BigInteger mask) {
			var ret = new List<SuspiciousNode>();
			foreach (var candidates in candidateNodesLists) {
				candidates.Sort((t1, t2) => t1.BitsCount.CompareTo(t2.BitsCount));
			}
			while (ret.Count < LearningCount) {
				var added = false;
				foreach (var candidates in candidateNodesLists) {
					var e = SelectMostDifferentElement(existings, candidates, mask);
					if (e != null) {
						ret.Add(e);
						existings.Add(e.Vector);
						added = true;
					}
				}
				if (!added) {
					break;
				}
			}
			return ret;
		}

		private IEnumerable<SuspiciousNode> SelectSuspiciousElementsWithMaskForFastAcceptanceLearning(
				IReadOnlyList<List<SuspiciousNode>> candidateNodesLists, BigInteger xor, BigInteger mask,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var vector = BigInteger.Zero;
				var classifier = classifiers[i];
				var candidates = candidateNodesLists[i]
						.OrderBy(t => LearningExperimentUtil.CountBits(classifier.Accepting & t.Vector))
						.ToList();
				foreach (var candidate in candidates) {
					var newVector = (vector | (candidate.Vector ^ xor)) & mask;
					if (newVector != vector) {
						vector = newVector;
						yield return candidate;
					}
				}
			}
		}

		private IEnumerable<SuspiciousNode> SelectSuspiciousElementsWithMaskForFastRejectionLearning(
				List<List<SuspiciousNode>> candidateNodesLists, BigInteger xor, BigInteger mask,
				IReadOnlyList<ClassifierUnit> classifiers) {
			for (int i = 0; i < candidateNodesLists.Count; i++) {
				var vector = BigInteger.Zero;
				var classifier = classifiers[i];
				var candidates = candidateNodesLists[i]
						.OrderBy(
								t => LearningExperimentUtil.CountBits(
										classifier.Accepting
										& ((t.Vector & _rejectingFeatureBitMask) ^ _rejectingFeatureBitMask)))
						.ToList();
				foreach (var candidate in candidates) {
					var newVector = (vector | (candidate.Vector ^ xor)) & mask;
					if (newVector == vector) {
						continue;
					}
					vector = newVector;
					yield return candidate;
				}
			}
		}

		#endregion
	}
}