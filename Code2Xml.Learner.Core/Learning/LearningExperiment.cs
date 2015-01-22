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
using Code2Xml.Core.Generators;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Collections.Generic;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
	public class LearningResult {
		public ClassificationResult ClassificationResult { get; set; }
		public IReadOnlyList<ClassifierUnit> Classifiers { get; set; }
	}

	public abstract class LearningExperiment : ILearningExperiment {
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

		public IList<CstNode> IdealAcceptedNodes {
			get {
				return _idealAcceptedVector2GroupPath.Keys.Select(f => _vector2Node[f])
						.ToList();
			}
		}

		public IList<CstNode> IdealRejectedNodes {
			get {
				return _idealRejectedVector2GroupPath.Keys.Select(f => _vector2Node[f])
						.ToList();
			}
		}

		private Dictionary<BigInteger, string> _idealAcceptedVector2GroupPath;
		private Dictionary<BigInteger, string> _idealRejectedVector2GroupPath;
		private Dictionary<BigInteger, string> _trainingAcceptedVector2GroupPath;
		private Dictionary<BigInteger, string> _trainingRejectedVector2GroupPath;

		private Dictionary<BigInteger, CstNode> _vector2Node;
		private Dictionary<BigInteger, int> _vector2Count;
		private Dictionary<BigInteger, string> _vector2Path;

		public readonly HashSet<string> _oracleNames;

		private int _seedElementCount;
		private int _seedAbstractCount;
		private int _acceptedSeedElementCount;

		protected LearningExperiment(params string[] elementNames) {
			_oracleNames = elementNames.ToHashSet();
		}

		public void Clear() {
			_idealAcceptedVector2GroupPath.Clear();
			_idealRejectedVector2GroupPath.Clear();
			_trainingAcceptedVector2GroupPath.Clear();
			_trainingRejectedVector2GroupPath.Clear();
			if (_vector2Node != null) {
				_vector2Node.Clear();
			}
			_idealAcceptedVector2GroupPath = null;
			_idealRejectedVector2GroupPath = null;
			_trainingAcceptedVector2GroupPath = null;
			_trainingRejectedVector2GroupPath = null;
			_vector2Node = null;
		}

		public ClassificationResult Apply(
				StreamWriter writer, ICollection<string> codePaths, string searchPattern,
				IReadOnlyList<ClassifierUnit> classifiers) {
			var allCsts = GenerateValidCsts(codePaths);
			_idealAcceptedVector2GroupPath.Clear();
			_idealRejectedVector2GroupPath.Clear();
			_vector2Node.Clear();
			_vector2Count.Clear();
			_vector2Path.Clear();
			_trainingAcceptedVector2GroupPath.Clear();
			_trainingRejectedVector2GroupPath.Clear();

			EncodeCsts(codePaths, allCsts);
			UpdateVector2GroupIndex();

			_trainingAcceptedVector2GroupPath.AddRange(_idealAcceptedVector2GroupPath);
			_trainingRejectedVector2GroupPath.AddRange(_idealRejectedVector2GroupPath);

			var time = Environment.TickCount;
			var result = Classify(Int32.MaxValue, classifiers);
			Console.WriteLine("Time: " + (Environment.TickCount - time));

			if (writer != null) {
				writer.Write(
						_idealAcceptedVector2GroupPath
								.Concat(_idealRejectedVector2GroupPath)
								.Sum(f => _vector2Count[f.Key]));
				writer.Write(",");
				writer.Write(
						_trainingAcceptedVector2GroupPath
								.Concat(_trainingRejectedVector2GroupPath)
								.Sum(f => _vector2Count[f.Key]));
				writer.Write(",");
				writer.Write(
						_idealAcceptedVector2GroupPath.Count
						+ _idealRejectedVector2GroupPath.Count);
				writer.Write(",");
				writer.Write(
						_trainingAcceptedVector2GroupPath.Count
						+ _trainingRejectedVector2GroupPath.Count);
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

		public LearningResult Learn(
				ICollection<string> seedPaths, StreamWriter writer,
				ICollection<string> codePaths, string searchPattern) {
			var allCsts = GenerateValidCsts(codePaths);
			var seedCsts = GenerateValidCsts(seedPaths).ToList();
			var seedNodes = seedCsts
					.SelectMany(cst => LearningExperimentUtil.GetUppermostNodesByNames(cst, _oracleNames))
					.Where(ProtectedIsAcceptedUsingOracle)
					.ToList();
			Console.WriteLine("Accepted elements: " + seedNodes.Count);

			var classifiers = CreateInitialClassifier(codePaths, allCsts, seedCsts, seedNodes);

			var count = 0;
			var sumTime = Environment.TickCount;
			ClassificationResult classificationResult;
			while (true) {
				var time = Environment.TickCount;
				classificationResult = Classify(count, classifiers);
				if (classificationResult.SuspiciousNodes == null) {
					break;
				}

				var newlyAcceptedVector2GroupPath =
						RevealSuspiciousElements(
								_idealAcceptedVector2GroupPath.Keys, classificationResult.SuspiciousNodes);
				var lastClassifiers = classifiers.Select(c => c.Clone()).ToList();
				classifiers = UpdateOrCreateClassifiers(newlyAcceptedVector2GroupPath, classifiers);
				if (classifiers.SequenceEqual(lastClassifiers)) {
					count++;
				} else {
					count = 0;
				}

				Console.WriteLine("Time: " + (Environment.TickCount - time));
			}
			Console.WriteLine();
			Console.WriteLine("Sum time: " + (Environment.TickCount - sumTime));
			Console.WriteLine(
					"Required elements: "
					+ (_trainingAcceptedVector2GroupPath.Count
					   + _trainingRejectedVector2GroupPath.Count) + " / "
					+ (_idealAcceptedVector2GroupPath.Count + _idealRejectedVector2GroupPath.Count));
			if (writer != null) {
				writer.Write(
						_idealAcceptedVector2GroupPath.Concat(_idealRejectedVector2GroupPath)
								.Sum(f => _vector2Count[f.Key]) - _seedElementCount);
				writer.Write(",");
				writer.Write(
						_trainingAcceptedVector2GroupPath.Concat(_trainingRejectedVector2GroupPath)
								.Sum(f => _vector2Count[f.Key]) - _seedElementCount);
				writer.Write(",");
				writer.Write(
						_idealAcceptedVector2GroupPath.Count + _idealRejectedVector2GroupPath.Count
						- _seedAbstractCount);
				writer.Write(",");
				writer.Write(
						_trainingAcceptedVector2GroupPath.Count
						+ _trainingRejectedVector2GroupPath.Count - _seedAbstractCount);
				writer.Write(",");
				writer.Write(_seedElementCount);
				writer.Write(",");
				writer.Write(_seedAbstractCount);
				writer.Write(",");
				writer.Write(_acceptedSeedElementCount);
				writer.Write(",");
			}

			foreach (var groupKey in _currentGroupPaths) {
				Console.WriteLine(groupKey);
			}

			//ShowBitsInfo();

			return new LearningResult {
				ClassificationResult = classificationResult, Classifiers = classifiers
			};
		}

		private IEnumerable<CstNode> GenerateValidCsts(IEnumerable<string> codePaths) {
			return codePaths.Select(
					path => {
						try {
							return Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
						} catch {
							return null;
						}
					})
					.Where(t => t != null);
		}

		private Classifier CreateInitialClassifier(
				ICollection<string> codePaths, IEnumerable<CstNode> allCsts, IList<CstNode> seedCsts,
				IList<CstNode> seedNodes) {
			var preparingTime = Environment.TickCount;

			var extractor = new FeatureExtractor(MaxUp, 0, MaxLeft, MaxRight, IsInner);
			var seedNodeSet = new SeedNodeSet(seedNodes, seedCsts, this);
			var featureSet = new FeatuerSet(seedNodeSet, extractor, this);
			Console.WriteLine(
					"Feature Count: " + featureSet.AcceptingFeatureCount + ", "
					+ featureSet.RejectingFeatureCount);

			var featureEncoder = new FeatureEncoder(extractor, featureSet);

			var allUppermostNodes = allCsts.SelectMany(
					cst => {
						Console.WriteLine(".");
						return featureSet.GetTargetNodes(cst);
					});
			var encodingResult = featureEncoder.Encode(codePaths, allUppermostNodes, seedNodeSet, this);

			Console.WriteLine("Unique Element Count: " + encodingResult.AbstractCount);
			if (encodingResult.IdealAcceptedVector2GroupPath.Keys.ToHashSet()
					.Overlaps(encodingResult.IdealRejectedVector2GroupPath.Keys.ToHashSet())) {
				throw new Exception("Master predicates can't classify elements!");
			}

			var classifier = new Classifier(featureSet, featureEncoder, encodingResult);
			Console.WriteLine("Preparing time: " + (Environment.TickCount - preparingTime));

			return classifier;
		}

		public ClassificationResult Classify(int count, Classifier classifier) {
			var result = new ClassificationResult(_vector2Node, _vector2Path);

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

			foreach (var vectorAndGroupPath in _idealAcceptedVector2GroupPath) {
				var vector = vectorAndGroupPath.Key;
				var groupPath = vectorAndGroupPath.Value;
				var groupIndex = classifier.GetGroupIndexWithCache(vector);
				var rejected = classifier.IsRejected(vector, groupIndex);
				var accepted = classifier.IsAccepted(vector, groupIndex);
				if (!_trainingAcceptedVector2GroupPath.ContainsKey(vector)
				    && !_trainingRejectedVector2GroupPath.ContainsKey(vector)) {
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
					result.WrongElementCount += _vector2Count[vector];
					result.WronglyRejectedFeatures.Add(vector);
				} else if (!rejected) {
					correctlyAccepted++;
				} else {
					wronglyRejectedInRejecting++;
					result.WrongElementCount += _vector2Count[vector];
					result.WronglyRejectedFeatures.Add(vector);
				}
			}

			foreach (var vectorAndGroupPath in _idealRejectedVector2GroupPath) {
				var vector = vectorAndGroupPath.Key;
				var groupPath = vectorAndGroupPath.Value;
				var groupIndex = classifier.GetGroupIndexWithCache(vector);
				var rejected = classifier.IsRejected(vector, groupIndex);
				var accepted = classifier.IsAccepted(vector, groupIndex);
				if (!_trainingAcceptedVector2GroupPath.ContainsKey(vector)
				    && !_trainingRejectedVector2GroupPath.ContainsKey(vector)) {
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
					result.WrongElementCount += _vector2Count[vector];
					result.WronglyAcceptedFeatures.Add(vector);
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
					+ (_trainingAcceptedVector2GroupPath.Count
					   + _trainingRejectedVector2GroupPath.Count) + ", AF: "
					+ String.Join(", ", classifier.CountAcceptingFeatures())
					+ ", RF: "
					+ String.Join(", ", classifier.CountRejectingFeatures()));
			result.WrongFeatureCount = wronglyAccepted + wronglyRejected
			                           + wronglyRejectedInRejecting;

			var selector = new SuspiciousNodeSelector(classifier.AcceptingFeatureBitMask,
					classifier.RejectingFeatureBitMask);
			result.SuspiciousNodes = selector.SelectSuspiciousNodes(count, classifier, acceptAccept,
					acceptReject, rejectAccept, rejectReject);
			return result;
		}

		public IDictionary<BigInteger, string> RevealSuspiciousElements(
				ICollection<BigInteger> actuallyAcceptedVectors, IReadOnlyList<SuspiciousNode> suspiciousNodes) {
			var newlyAcceptedVectorAndGroupKeys = new Dictionary<BigInteger, string>();
			foreach (var t in suspiciousNodes) {
				if (actuallyAcceptedVectors.Contains(t.Vector)) {
					newlyAcceptedVectorAndGroupKeys.Add(t.Vector, t.GroupKey);
					_trainingAcceptedVector2GroupPath.Add(t.Vector, t.GroupKey);
				} else {
					_trainingRejectedVector2GroupPath.Add(t.Vector, t.GroupKey);
				}
			}

			Console.WriteLine(
					"Accepted: " + _trainingAcceptedVector2GroupPath.Count + " + "
					+ newlyAcceptedVectorAndGroupKeys.Count
					+ " / " + _idealAcceptedVector2GroupPath.Count);
			Console.WriteLine(
					"Rejected: " + _trainingRejectedVector2GroupPath.Count + " + "
					+ (suspiciousNodes.Count - newlyAcceptedVectorAndGroupKeys.Count)
					+ " / " + _idealRejectedVector2GroupPath.Count);

			return newlyAcceptedVectorAndGroupKeys;
		}

		protected IEnumerable<CstNode> GetAllElements(CstNode cst, ISet<string> elementNames) {
			return cst.DescendantsAndSelf()
					.Where(e => elementNames.Contains(e.Name));
		}

		public bool IsAcceptedUsingOracle(CstNode uppermostNode) {
			return uppermostNode.DescendantsOfSingleAndSelf()
					.Concat(uppermostNode.AncestorsWithSingleChild())
					.Where(e => _oracleNames.Contains(e.Name))
					.Any(ProtectedIsAcceptedUsingOracle);
		}

		public int CountUsingOracle(CstNode cst) {
			return LearningExperimentUtil.GetUppermostNodesByNames(cst, _oracleNames)
					.Count(IsAcceptedUsingOracle);
		}

		public abstract bool ProtectedIsAcceptedUsingOracle(CstNode e);

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