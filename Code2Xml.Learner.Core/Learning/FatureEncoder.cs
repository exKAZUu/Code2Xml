using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Collections.Generic;

namespace Code2Xml.Learner.Core.Learning
{
	class FatureEncoder
	{
		public bool IsInner { get; private set; }
		public int MaxUp { get; private set; }
		public int MaxLeft { get; private set; }
		public int MaxRight { get; private set; }

		private const int SurroundingLength = 7;
		private const int GroupKeyLength = 5;

		private ISet<string> _selectedNodeNames;
		private readonly IDictionary<string, BigInteger> _featureString2Bit;
		private readonly IDictionary<BigInteger, string> _bit2FeatureString;
		private readonly FeatureExtractor _extractor;

		public FatureEncoder(FeatuerSet featureSet, FeatureExtractor extractor) {
			_extractor = extractor;
			_selectedNodeNames = featureSet.SelectedNodeNames;
			_featureString2Bit = CreateFeatureString2Bit(featureSet);
			_bit2FeatureString = CreateBit2FeatureString(_featureString2Bit);
		}

		#region Encode

		private EncodingResult Encode(ICollection<string> codePaths, IEnumerable<CstNode> allUppermostNodeNodes, LearningExperiment oracle) {
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
			var ret = EncodeUppermostNodes(allUppermostNodeNodes, oracle);
			if (fileName != null) {
				using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
					formatter.Serialize(fs, ret);
				}
			}
		}

		private void EncodeSeedNodes(
				IEnumerable<CstNode> seedNodes,
				Dictionary<BigInteger, string> idealVector2Path,
				Dictionary<BigInteger, string> trainingVector2Path) {
			foreach (var e in seedNodes) {
				var vector = e.GetFeatureVector(SurroundingLength, _featureString2Bit, _extractor);
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

		private void EncodeUppermostNodes(IEnumerable<CstNode> allUppermostNodeNodes, LearningExperiment oracle) {
					var _idealAcceptedVector2GroupPath = new Dictionary<BigInteger, string>();
		var _idealRejectedVector2GroupPath = new Dictionary<BigInteger, string>();
		var _vector2Count = new Dictionary<BigInteger, int>();


			foreach (var uppermostNode in allUppermostNodeNodes) {
				var vector = uppermostNode.GetFeatureVector(
						SurroundingLength, _featureString2Bit, _extractor);
				if (oracle.IsAcceptedUsingOracle(uppermostNode)) {
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
		}

		private static IDictionary<BigInteger, string> CreateBit2FeatureString(IEnumerable<KeyValuePair<string, BigInteger>> _featureString2Bit) {
			return _featureString2Bit
				.ToDictionary(featureStringAndBit => featureStringAndBit.Value,
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

			return ">" + node.Name + ">" + String.Join(">", distinctivePath) + ">";
		}

	}
}
