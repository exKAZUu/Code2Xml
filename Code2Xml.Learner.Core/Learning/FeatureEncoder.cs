﻿#region License

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
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Collections.Generic;

namespace Code2Xml.Learner.Core.Learning {
	[Serializable]
	public class FeatureEncoder {
		private const int SurroundingLength = 7;
		private const int GroupKeyLength = 5;

		private readonly FeatureExtractor _extractor;

		private readonly IDictionary<string, BigInteger> _featureString2Bit;
		private readonly IDictionary<BigInteger, string> _bit2FeatureString;

		public FeatureEncoder(FeatureExtractor extractor, FeatuerSet featureSet) {
			_extractor = extractor;
			_featureString2Bit = CreateFeatureString2Bit(featureSet);
			_bit2FeatureString = CreateBit2FeatureString(_featureString2Bit);
		}

		public BigInteger GetBitByFeatureString(string featureString) {
			return _featureString2Bit[featureString];
		}

		public string GetFeatureStringByBit(BigInteger bit) {
			return _bit2FeatureString[bit];
		}

		public IEnumerable<string> GetFeatureStringsByVector(BigInteger vector) {
			var featureBit = BigInteger.One;
			while (vector != BigInteger.Zero) {
				if ((vector & featureBit) != BigInteger.Zero) {
					vector ^= featureBit;
				}
				yield return GetFeatureStringByBit(featureBit);
				featureBit <<= 1;
			}
		}

		public EncodingResult Encode(
				ICollection<string> codePaths, IEnumerable<CstNode> allCsts, SeedNodeSet seedNodeSet,
				LearningExperiment oracle) {
			var fileName = codePaths.Count > 0
					? String.Join(",", codePaths).GetHashCode() + "_" +
					  (codePaths.First() + "," + codePaths.Last()).GetHashCode() + ".encoded"
					: null;
			var formatter = new BinaryFormatter();
			if (fileName != null && File.Exists(fileName)) {
				using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
					return (EncodingResult)formatter.Deserialize(fs);
				}
			}

			var allUppermostNodes = allCsts.SelectMany(
					cst => {
						Console.WriteLine(".");
						return LearningExperimentUtil.GetUppermostNodesByNames(cst, seedNodeSet.SelectedNodeNames);
					});

			var result = new EncodingResult();
			result.SeedAcceptedNodeCount = seedNodeSet.SeedAcceptedNodes.Count;
			result.SeedNodeCount = result.SeedAcceptedNodeCount + seedNodeSet.SeedRejectedNodes.Count;
			EncodeSeedNodes(
					seedNodeSet.SeedAcceptedNodes, result.IdealAcceptedVector2GroupPath,
					result.SeedAcceptedVector2GroupPath, result);
			EncodeSeedNodes(
					seedNodeSet.SeedRejectedNodes, result.IdealRejectedVector2GroupPath,
					result.SeedRejectedVector2GroupPath, result);
			EncodeTargetNodes(allUppermostNodes, oracle, result);
			result.MakeImmutable();

			if (fileName != null) {
				using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
					formatter.Serialize(fs, result);
				}
			}
			return result;
		}

		private void EncodeSeedNodes(
				IEnumerable<CstNode> seedNodes, IDictionary<BigInteger, string> idealVector2Path,
				IDictionary<BigInteger, string> seedVector2Path, EncodingResult result) {
			foreach (var node in seedNodes) {
				var vector = node.GetFeatureVector(SurroundingLength, _featureString2Bit, _extractor);
				UpdateVector2GroupPath(idealVector2Path, vector, node);
				seedVector2Path[vector] = idealVector2Path[vector];
				UpdateVectorDict(result, vector, node);
			}
		}

		private void EncodeTargetNodes(
				IEnumerable<CstNode> allUppermostNodes, LearningExperiment oracle, EncodingResult result) {
			foreach (var uppermostNode in allUppermostNodes) {
				var vector = uppermostNode.GetFeatureVector(SurroundingLength, _featureString2Bit, _extractor);
				if (oracle.IsAcceptedUsingOracle(uppermostNode)) {
					// TODO: for debug
					if (result.IdealRejectedVector2GroupPath.ContainsKey(vector)) {
						PrintNotDistinguishedElement(uppermostNode, vector, result);
					}
					UpdateVector2GroupPath(result.IdealAcceptedVector2GroupPath, vector, uppermostNode);
				} else {
					// TODO: for debug
					if (result.IdealAcceptedVector2GroupPath.ContainsKey(vector)) {
						PrintNotDistinguishedElement(uppermostNode, vector, result);
					}
					UpdateVector2GroupPath(result.IdealRejectedVector2GroupPath, vector, uppermostNode);
				}
				UpdateVectorDict(result, vector, uppermostNode);
			}
		}

		private static void UpdateVectorDict(EncodingResult result, BigInteger vector, CstNode node) {
			result.Vector2Node[vector] = node;
			if (result.Vector2Count.ContainsKey(vector)) {
				result.Vector2Count[vector]++;
			} else {
				result.Vector2Count[vector] = 1;
			}
		}

		private static void PrintNotDistinguishedElement(
				CstNode e, BigInteger feautre, EncodingResult result) {
			Console.WriteLine(e.Parent.Name + ", " + e.Name + ", " + e.Code);
			Console.WriteLine(
					result.Vector2Node[feautre].Parent.Name + ", "
					+ result.Vector2Node[feautre].Name + ", "
					+ result.Vector2Node[feautre].Code);
		}

		private static IDictionary<BigInteger, string> CreateBit2FeatureString(
				IEnumerable<KeyValuePair<string, BigInteger>> featureString2Bit) {
			return featureString2Bit
					.ToDictionary(
							featureStringAndBit => featureStringAndBit.Value,
							featureStringAndBit => featureStringAndBit.Key)
					.ToImmutableDictionary();
		}

		private static IDictionary<string, BigInteger> CreateFeatureString2Bit(FeatuerSet featuerSet) {
			var featureString2Bit = new Dictionary<string, BigInteger>();
			var masterFeatureVector = BigInteger.One;
			foreach (var featureStr in featuerSet.AcceptingFeatures) {
				featureString2Bit.Add(featureStr, masterFeatureVector);
				masterFeatureVector <<= 1;
			}
			foreach (var featureStr in featuerSet.RejectingFeatures) {
				featureString2Bit.Add(featureStr, masterFeatureVector);
				masterFeatureVector <<= 1;
			}
			return featureString2Bit.ToImmutableDictionary();
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
			if (_extractor.IsInner) {
				//node = node.AncestorsOfOnlyChildAndSelf().Last(); // TODO
				// TODO: descendants may be empty list
				distinctivePath = node.DescendantsOfFirstChild()
						.Take(GroupKeyLength)
						.Select(e => e.HasToken ? e.RuleId + "-" + _extractor.GetToken(e) : e.RuleId);
			} else {
				//node = node.DescendantsOfOnlyChildAndSelf().Last(); // TODO
				distinctivePath = node.AncestorsAndSelf()
						.Take(GroupKeyLength)
						.Select(e => e.HasToken ? e.RuleId + "-" + _extractor.GetToken(e) : e.RuleId);
			}

			return ">" + node.Name + ">" + String.Join(">", distinctivePath) + ">";
		}
	}
}