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
	public class LearningResult {
		public ClassificationResult ClassificationResult { get; set; }
		public IReadOnlyList<ClassifierUnit> Classifiers { get; set; }
	}

	public abstract class LearningExperiment : ILearningExperiment {
		public class UpdateResult {
			public GroupInfo Accepted { get; set; }
			public GroupInfo Rejected { get; set; }
		}

		public class GroupInfo {
			public string Path { get; set; }
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

		private const int SurroundingLength = 7;
		private const int GroupKeyLength = 5;

		private Dictionary<BigInteger, string> _idealAcceptedVector2GroupPath;
		private Dictionary<BigInteger, string> _idealRejectedVector2GroupPath;
		private Dictionary<BigInteger, string> _trainingAcceptedVector2GroupPath;
		private Dictionary<BigInteger, string> _trainingRejectedVector2GroupPath;

		private Dictionary<BigInteger, CstNode> _vector2Node;
		private Dictionary<BigInteger, int> _vector2Count;
		private Dictionary<BigInteger, string> _vector2Path;

		private readonly HashSet<string> _oracleNames;

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
			_selectedNames.Clear();
			_featureString2Bit.Clear();
			_currentGroupPaths.Clear();
			_idealAcceptedVector2GroupPath = null;
			_idealRejectedVector2GroupPath = null;
			_trainingAcceptedVector2GroupPath = null;
			_trainingRejectedVector2GroupPath = null;
			_vector2Node = null;
			_featureString2Bit = null;
			_currentGroupPaths = null;
		}

		private void UpdateVector2GroupPath(
				IDictionary<BigInteger, string> vector2GroupPath, BigInteger vector, CstNode node) {
			var groupPath = GetGroupPathFromNode(node);
			var existingGroupPath = vector2GroupPath.GetValueOrDefault(vector);
			if (existingGroupPath == null) {
				vector2GroupPath.Add(vector, groupPath);
			} else {
				vector2GroupPath[vector] = LearningExperimentUtil.GetCommonSuffix(existingGroupPath, groupPath);
			}
		}

		/// <summary>
		/// Get a group key from the specified node.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		private string GetGroupPathFromNode(CstNode node) {
			IEnumerable<string> distinctivePath;
			if (IsInner) {
				//node = node.AncestorsOfOnlyChildAndSelf().Last(); // TODO
				// TODO: descendants may be empty list
				distinctivePath = node.DescendantsOfFirstChild()
						.Take(GroupKeyLength)
						.Select(e => e.HasToken ? e.RuleId + "-" + GetToken(e) : e.RuleId);
			} else {
				//node = node.DescendantsOfOnlyChildAndSelf().Last(); // TODO
				distinctivePath = node.AncestorsAndSelf()
						.Take(GroupKeyLength)
						.Select(e => e.HasToken ? e.RuleId + "-" + GetToken(e) : e.RuleId);
			}

			return ">" + node.Name + ">" + string.Join(">", distinctivePath) + ">";
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
			var result = Classify(int.MaxValue, classifiers);
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
					.SelectMany(cst => GetUppermostNodesByNames(cst, _oracleNames))
					.Where(ProtectedIsAcceptedUsingOracle)
					.ToList();
			Console.WriteLine("Accepted elements: " + seedNodes.Count);

			ExtractFeatures(codePaths, allCsts, seedCsts, seedNodes);
			UpdateVector2GroupIndex();

			var classifiers = CreateClassifiers(); // for the first time
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

		private void ExtractFeatures(
				ICollection<string> codePaths, IEnumerable<CstNode> allCsts, IList<CstNode> seedCsts,
				IList<CstNode> seedNodes) {
			var preparingTime = Environment.TickCount;

			var uppermostSeedAcceptedNodes = SelectUppermostNodes(seedNodes)
					.ToHashSet();
			_selectedNames = LearningExperimentUtil.FindGoodNodeNames(uppermostSeedAcceptedNodes)
					.ToHashSet();
			_currentGroupPaths = _selectedNames.Select(n => ">" + n + ">")
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

			_idealAcceptedVector2GroupPath = new Dictionary<BigInteger, string>();
			_idealRejectedVector2GroupPath = new Dictionary<BigInteger, string>();
			_trainingAcceptedVector2GroupPath = new Dictionary<BigInteger, string>();
			_trainingRejectedVector2GroupPath = new Dictionary<BigInteger, string>();
			_vector2Node = new Dictionary<BigInteger, CstNode>();
			_vector2Count = new Dictionary<BigInteger, int>();
			_vector2Path = new Dictionary<BigInteger, string>();
			// TODO: Maybe this initialization is wrong
			// _currentGroupPaths = new List<string> { ">" };
			_featureString2Bit = new Dictionary<string, BigInteger>();

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
					"Vector Count: " + _acceptingFeatureCount + ", " + rejectingFeatures.Count);

			var masterFeatureVector = BigInteger.One;
			foreach (var featureStr in acceptingFeatures) {
				_featureString2Bit.Add(featureStr, masterFeatureVector);
				_vector2Path.Add(masterFeatureVector, featureStr);
				masterFeatureVector <<= 1;
			}
			foreach (var featureStr in rejectingFeatures) {
				_featureString2Bit.Add(featureStr, masterFeatureVector);
				_vector2Path.Add(masterFeatureVector, featureStr);
				masterFeatureVector <<= 1;
			}

			_allFeatureBitMask = (BigInteger.One << _featureString2Bit.Count) - BigInteger.One;
			_acceptingFeatureBitMask = (BigInteger.One << _acceptingFeatureCount) - BigInteger.One;
			_rejectingFeatureBitMask = _allFeatureBitMask ^ _acceptingFeatureBitMask;

			_acceptedSeedElementCount = seedAcceptedNodes.Count;
			_seedElementCount = _acceptedSeedElementCount + seedRejectedNodes.Count;
			_seedAbstractCount = 0;

			EncodeSeedNodes(
					seedAcceptedNodes, _idealAcceptedVector2GroupPath,
					_trainingAcceptedVector2GroupPath);
			EncodeSeedNodes(
					seedRejectedNodes, _idealRejectedVector2GroupPath,
					_trainingRejectedVector2GroupPath);

			EncodeCsts(codePaths, allCsts);

			Console.WriteLine(
					"Unique Element Count: "
					+ (_idealAcceptedVector2GroupPath.Count + _idealRejectedVector2GroupPath.Count));

			if (_idealAcceptedVector2GroupPath.Keys.ToHashSet()
					.Overlaps(_idealRejectedVector2GroupPath.Keys.ToHashSet())) {
				throw new Exception("Master predicates can't classify elements!");
			}

			Console.WriteLine("Preparing time: " + (Environment.TickCount - preparingTime));
		}

		#region Encode

		private void EncodeCsts(ICollection<string> codePaths, IEnumerable<CstNode> allCsts) {
			var fileName = codePaths.Count > 0
					? string.Join(",", codePaths).GetHashCode() + "_" +
					  (codePaths.First() + "," + codePaths.Last()).GetHashCode() + ".features"
					: null;
			var formatter = new BinaryFormatter();
			if (false && fileName != null && File.Exists(fileName)) {
				using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
					_idealRejectedVector2GroupPath =
							(Dictionary<BigInteger, string>)formatter.Deserialize(fs);
					_idealAcceptedVector2GroupPath =
							(Dictionary<BigInteger, string>)formatter.Deserialize(fs);
					_vector2Count = (Dictionary<BigInteger, int>)formatter.Deserialize(fs);
				}
			} else {
				foreach (var cst in allCsts) {
					Console.Write(".");
					EncodeUppermostNodes(cst, _selectedNames);
				}
				if (fileName != null) {
					using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
						formatter.Serialize(fs, _idealRejectedVector2GroupPath);
						formatter.Serialize(fs, _idealAcceptedVector2GroupPath);
						formatter.Serialize(fs, _vector2Count);
					}
				}
			}
		}

		private void EncodeSeedNodes(
				IEnumerable<CstNode> seedNodes,
				Dictionary<BigInteger, string> idealVector2Path,
				Dictionary<BigInteger, string> trainingVector2Path) {
			foreach (var e in seedNodes) {
				var vector = e.GetFeatureVector(SurroundingLength, _featureString2Bit, this);
				UpdateVector2GroupPath(idealVector2Path, vector, e);
				trainingVector2Path[vector] = idealVector2Path[vector];
				_vector2Node[vector] = e;
				if (_vector2Count.ContainsKey(vector)) {
					_vector2Count[vector]++;
				} else {
					_vector2Count[vector] = 1;
					_seedAbstractCount++;
				}
			}
		}

		private void EncodeUppermostNodes(CstNode cst, ISet<string> selectedNames) {
			foreach (var uppermostNode in GetUppermostNodesByNames(cst, selectedNames)) {
				var vector = uppermostNode.GetFeatureVector(
						SurroundingLength, _featureString2Bit, this);
				if (IsAcceptedUsingOracle(uppermostNode)) {
					// TODO: for debug
					if (_idealRejectedVector2GroupPath.ContainsKey(vector)) {
						PrintNotDistinguishedElement(uppermostNode, vector);
					}
					UpdateVector2GroupPath(_idealAcceptedVector2GroupPath, vector, uppermostNode);
				} else {
					// TODO: for debug
					if (_idealAcceptedVector2GroupPath.ContainsKey(vector)) {
						PrintNotDistinguishedElement(uppermostNode, vector);
					}
					UpdateVector2GroupPath(_idealRejectedVector2GroupPath, vector, uppermostNode);
				}
				_vector2Node[vector] = uppermostNode;
				if (_vector2Count.ContainsKey(vector)) {
					_vector2Count[vector]++;
				} else {
					_vector2Count[vector] = 1;
				}
			}
		}

		#endregion

		private void PrintNotDistinguishedElement(CstNode e, BigInteger feautre) {
			Console.WriteLine(e.Parent.Name + ", " + e.Name + ", " + e.Code);
			Console.WriteLine(
					_vector2Node[feautre].Parent.Name + ", "
					+ _vector2Node[feautre].Name + ", "
					+ _vector2Node[feautre].Code);
			IsAcceptedUsingOracle(e);
			e.GetFeatureVector(SurroundingLength, _featureString2Bit, this);
		}

		private int GetGroupIndex(BigInteger feature) {
			return _vector2GroupIndex[feature];
		}

		private int GetGroupIndexWithoutCache(string groupKey) {
			for (int i = _currentGroupPaths.Count - 1; i >= 0; i--) {
				if (groupKey.StartsWith(_currentGroupPaths[i])) {
					return i;
				}
			}
			throw new Exception("Can't find the given group key: " + groupKey);
		}

		private void UpdateVector2GroupIndex() {
			_vector2GroupIndex = new Dictionary<BigInteger, int>();
			foreach (var kv in _idealAcceptedVector2GroupPath) {
				var index = GetGroupIndexWithoutCache(kv.Value);
				_vector2GroupIndex.Add(kv.Key, index);
			}
			foreach (var kv in _idealRejectedVector2GroupPath) {
				var index = GetGroupIndexWithoutCache(kv.Value);
				_vector2GroupIndex.Add(kv.Key, index);
			}
		}

		#region Create classifiers

		private List<ClassifierUnit> InitializeClassifiers() {
			return Enumerable.Repeat(
					new ClassifierUnit(_acceptingFeatureBitMask, _rejectingFeatureBitMask),
					_currentGroupPaths.Count)
					.Select(_ => new ClassifierUnit(_acceptingFeatureBitMask, _rejectingFeatureBitMask))
					.ToList();
		}

		private List<ClassifierUnit> CreateClassifiers() {
			while (true) {
				var classifiers = InitializeClassifiers();
				if (UpdateClassifiers(_trainingAcceptedVector2GroupPath, classifiers)) {
					return classifiers;
				}
			}
		}

		private List<ClassifierUnit> UpdateOrCreateClassifiers(
				IDictionary<BigInteger, string> acceptedVector2GroupPath, List<ClassifierUnit> classifiers) {
			if (UpdateClassifiers(acceptedVector2GroupPath, classifiers)) {
				return classifiers;
			}
			return CreateClassifiers();
		}

		#region Update classifiers in detailed

		private bool UpdateClassifiers(
				IDictionary<BigInteger, string> acceptedTrainingSet, List<ClassifierUnit> classifiers) {
			UpdateRejectingClassifiers(acceptedTrainingSet.Keys, classifiers);
			var result = UpdateAcceptingClassifiers(acceptedTrainingSet, classifiers);
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
				UpdateVector2GroupIndex();
			}
			// ReSharper disable once PossibleUnintendedReferenceComparison
			if (_currentGroupPaths.Count == count
			    && acceptedTrainingSet == _trainingAcceptedVector2GroupPath) {
				throw new Exception("Fail to learn rules");
			}
			Console.WriteLine("Groups: " + _currentGroupPaths.Count + " (" + count + ")");
			return false;
		}

		private UpdateResult UpdateAcceptingClassifiers(
				IDictionary<BigInteger, string> acceptedVector2GroupPath,
				IReadOnlyList<ClassifierUnit> classifiers) {
			if (acceptedVector2GroupPath.Count == 0) {
				var rejectedGroupInfo = CanReject(classifiers);
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
				var groupIndex = GetGroupIndex(vector);
				classifiers[groupIndex].Accepting &= vector;
				var rejectedGroupInfo = CanReject(classifiers);
				if (rejectedGroupInfo != null) {
					return new UpdateResult {
						Rejected = rejectedGroupInfo,
						Accepted = new GroupInfo { Index = groupIndex, Path = vectorAndGroupPath.Value },
					};
				}
			}
			return null;
		}

		private void UpdateRejectingClassifiers(
				IEnumerable<BigInteger> acceptedTrainingSet, IList<ClassifierUnit> classifiers) {
			var count = classifiers.Count;
			for (int i = 0; i < count; i++) {
				classifiers[i].Rejecting ^= _rejectingFeatureBitMask;
			}
			foreach (var vector in acceptedTrainingSet) {
				var iGroupKey = GetGroupIndex(vector);
				classifiers[iGroupKey].Rejecting |= vector;
			}
			for (int i = 0; i < count; i++) {
				classifiers[i].Rejecting ^= _rejectingFeatureBitMask;
				classifiers[i].Rejecting &= _rejectingFeatureBitMask;
			}
		}

		private bool AddNewGroup(GroupInfo info) {
			var i = info.Path.IndexOf('>', _currentGroupPaths[info.Index].Length + 1);
			var newGroupKey = info.Path.Substring(0, i + 1);
			if (!_currentGroupPaths.Contains(newGroupKey)) {
				_currentGroupPaths.Add(newGroupKey);
				return true;
			}
			return false;
		}

		#endregion

		#endregion

		public ClassificationResult Classify(int count, IReadOnlyList<ClassifierUnit> classifiers) {
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
			for (int i = 0; i < _currentGroupPaths.Count; i++) {
				rejectAccept.Add(new List<SuspiciousNode>());
				rejectReject.Add(new List<SuspiciousNode>());
				acceptAccept.Add(new List<SuspiciousNode>());
				acceptReject.Add(new List<SuspiciousNode>());
			}

			foreach (var featureAndGroupKey in _idealAcceptedVector2GroupPath) {
				var feature = featureAndGroupKey.Key;
				var groupKey = featureAndGroupKey.Value;
				var groupIndex = GetGroupIndex(feature);
				var rejected = LearningExperimentUtil.IsRejected(feature, classifiers[groupIndex].Rejecting);
				var accepted = LearningExperimentUtil.IsAccepted(feature, classifiers[groupIndex].Accepting);
				if (!_trainingAcceptedVector2GroupPath.ContainsKey(feature)
				    && !_trainingRejectedVector2GroupPath.ContainsKey(feature)) {
					var target = new SuspiciousNode {
						Vector = feature,
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
					result.WrongElementCount += _vector2Count[feature];
					result.WronglyRejectedFeatures.Add(feature);
				} else if (!rejected) {
					correctlyAccepted++;
				} else {
					wronglyRejectedInRejecting++;
					result.WrongElementCount += _vector2Count[feature];
					result.WronglyRejectedFeatures.Add(feature);
				}
			}

			foreach (var featureAndGroupKey in _idealRejectedVector2GroupPath) {
				var feature = featureAndGroupKey.Key;
				var groupKey = featureAndGroupKey.Value;
				var groupIndex = GetGroupIndex(feature);
				var rejected = LearningExperimentUtil.IsRejected(feature, classifiers[groupIndex].Rejecting);
				var accepted = LearningExperimentUtil.IsAccepted(feature, classifiers[groupIndex].Accepting);
				if (!_trainingAcceptedVector2GroupPath.ContainsKey(feature)
				    && !_trainingRejectedVector2GroupPath.ContainsKey(feature)) {
					var target = new SuspiciousNode {
						Vector = feature,
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
					result.WrongElementCount += _vector2Count[feature];
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
					+ (_trainingAcceptedVector2GroupPath.Count
					   + _trainingRejectedVector2GroupPath.Count) + ", AF: "
					+ string.Join(", ", classifiers.Select(c => LearningExperimentUtil.CountBits(c.Accepting)))
					+ ", RF: "
					+ string.Join(
							", ",
							classifiers.Select(
									c => LearningExperimentUtil.CountRejectingBits(c.Rejecting, _acceptingFeatureCount))));
			result.WrongFeatureCount = wronglyAccepted + wronglyRejected
			                           + wronglyRejectedInRejecting;

			var selector = new SuspiciousNodeSelector(_acceptingFeatureBitMask, _rejectingFeatureBitMask);
			result.SuspiciousNodes = selector.SelectSuspiciousNodes(
					count, classifiers, acceptAccept, acceptReject, rejectAccept, rejectReject);
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

		private GroupInfo CanReject(IReadOnlyList<ClassifierUnit> classifiers) {
			foreach (var featureAndGroupKey in _trainingRejectedVector2GroupPath) {
				var feature = featureAndGroupKey.Key;
				var groupKey = featureAndGroupKey.Value;
				var groupIndex = GetGroupIndex(feature);
				if (LearningExperimentUtil.IsAccepted(feature, classifiers[groupIndex].Accepting)
				    && !LearningExperimentUtil.IsRejected(feature, classifiers[groupIndex].Rejecting)) {
					return new GroupInfo { Index = groupIndex, Path = groupKey };
				}
			}
			return null;
		}

		private void ShowBitsInfo(ClassificationResult result, IList<ClassifierUnit> classifiers) {
			CreateClassifiers();

			Console.WriteLine("---------------------------------------------------");
			Console.Write("A(A): ");
			foreach (var f in _idealAcceptedVector2GroupPath.Keys) {
				Console.Write(LearningExperimentUtil.CountAcceptingBits(f, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();
			Console.Write("R(A): ");
			foreach (var f in _idealRejectedVector2GroupPath.Keys) {
				Console.Write(LearningExperimentUtil.CountAcceptingBits(f, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();
			Console.Write("WA(A): ");
			foreach (var f in result.WronglyAcceptedFeatures) {
				Console.Write(LearningExperimentUtil.CountAcceptingBits(f, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();
			Console.Write("WR(A): ");
			foreach (var f in result.WronglyRejectedFeatures) {
				Console.Write(LearningExperimentUtil.CountAcceptingBits(f, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();

			Console.WriteLine("---------------------------------------------------");
			Console.Write("A(R): ");
			foreach (var f in _idealAcceptedVector2GroupPath.Keys) {
				Console.Write(LearningExperimentUtil.CountRejectingBits(f, _acceptingFeatureCount) + ", ");
			}
			Console.WriteLine();
			Console.Write("R(R): ");
			foreach (var f in _idealRejectedVector2GroupPath.Keys) {
				Console.Write(LearningExperimentUtil.CountRejectingBits(f, _acceptingFeatureCount) + ", ");
			}
			Console.WriteLine();
			Console.Write("WA(R): ");
			foreach (var f in result.WronglyAcceptedFeatures) {
				Console.Write(LearningExperimentUtil.CountRejectingBits(f, _acceptingFeatureCount) + ", ");
			}
			Console.WriteLine();
			Console.Write("WR(R): ");
			foreach (var f in result.WronglyRejectedFeatures) {
				Console.Write(LearningExperimentUtil.CountRejectingBits(f, _acceptingFeatureCount) + ", ");
			}
			Console.WriteLine();

			Console.WriteLine("---------------------------------------------------");
			Console.Write("A(A): ");
			foreach (var featureAndGroupKey in _idealAcceptedVector2GroupPath) {
				var feature = featureAndGroupKey.Key;
				var groupKey = featureAndGroupKey.Value;
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountAcceptingBits(
								feature & classifiers[iClassifier].Accepting, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();
			Console.Write("R(A): ");
			foreach (var featureAndGroupKey in _idealRejectedVector2GroupPath) {
				var feature = featureAndGroupKey.Key;
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountAcceptingBits(
								feature & classifiers[iClassifier].Accepting, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();
			Console.Write("WA(A): ");
			foreach (var feature in result.WronglyAcceptedFeatures) {
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountAcceptingBits(
								feature & classifiers[iClassifier].Accepting, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();
			Console.Write("WR(A): ");
			foreach (var feature in result.WronglyRejectedFeatures) {
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountAcceptingBits(
								feature & classifiers[iClassifier].Accepting, _acceptingFeatureBitMask) + ", ");
			}
			Console.WriteLine();

			Console.WriteLine("---------------------------------------------------");
			Console.Write("A(R): ");
			foreach (var featureAndGroupKey in _idealAcceptedVector2GroupPath) {
				var feature = featureAndGroupKey.Key;
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountRejectingBits(
								feature & classifiers[iClassifier].Rejecting, _acceptingFeatureCount) + ", ");
			}
			Console.WriteLine();
			Console.Write("R(R): ");
			foreach (var featureAndGroupKey in _idealRejectedVector2GroupPath) {
				var feature = featureAndGroupKey.Key;
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountRejectingBits(
								feature & classifiers[iClassifier].Rejecting, _acceptingFeatureCount) + ", ");
			}
			Console.WriteLine();
			Console.Write("WA(R): ");
			foreach (var feature in result.WronglyAcceptedFeatures) {
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountRejectingBits(
								feature & classifiers[iClassifier].Rejecting, _acceptingFeatureCount) + ", ");
			}
			Console.WriteLine();
			Console.Write("WR(R): ");
			foreach (var feature in result.WronglyRejectedFeatures) {
				var iClassifier = GetGroupIndex(feature);
				Console.Write(
						LearningExperimentUtil.CountRejectingBits(
								feature & classifiers[iClassifier].Rejecting, _acceptingFeatureCount) + ", ");
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