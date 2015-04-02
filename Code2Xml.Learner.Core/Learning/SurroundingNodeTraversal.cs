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
using Code2Xml.Core.SyntaxTree;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
	public static class SurroundingNodeTraversal {
		public static double[] BigIntegerToDoubles(this BigInteger i, int bitLength) {
			var doubles = new List<double>();
			for (int j = 0; j < bitLength; j++) {
				if ((i & BigInteger.One) != BigInteger.Zero) {
					doubles.Add(1);
				} else {
					doubles.Add(0);
				}
				i >>= 1;
			}
			return doubles.ToArray();
		}

		public static string BigIntegerToString(this BigInteger i) {
			var ret = "";
			while (i != BigInteger.Zero) {
				if ((i & BigInteger.One) != BigInteger.Zero) {
					ret = "1" + ret;
				} else {
					ret = "0" + ret;
				}
				i >>= 1;
			}
			return ret;
		}

		public static HashSet<string> GetUnionKeys(
				this IEnumerable<CstNode> targets, int length, FeatureExtractor extractor,
				ILearningExperiment oracle) {
			var commonKeys = new HashSet<string>();
			foreach (var target in targets) {
				var roots = oracle.GetRootsUsingOracle(target);
				var keys = roots == null
						? target.GetSurroundingPaths(length, extractor)
						: target.GetSurroundingPathsFilteringByRoots(roots, length, extractor);
				commonKeys.UnionWith(keys);
			}
			return commonKeys;
		}

		public static HashSet<string> GetCommonKeys(
				this IEnumerable<CstNode> targets, int length, FeatureExtractor extractor,
				ILearningExperiment oracle) {
			HashSet<string> commonKeys = null;
			foreach (var target in targets) {
				var roots = oracle.GetRootsUsingOracle(target);
				var keys = roots == null
						? target.GetSurroundingPaths(length, extractor)
						: target.GetSurroundingPathsFilteringByRoots(roots, length, extractor);
				if (commonKeys == null) {
					commonKeys = keys;
				} else {
					commonKeys.IntersectWith(keys);
				}
			}
			return commonKeys;
		}

		private static bool CanSkip(CstNode node) {
			var tokenText = node.TokenText;
			return tokenText.Length == 1 && char.IsLetter(tokenText[0]);
		}

		public static HashSet<string> GetSurroundingPathsFilteringByRoots(
				this CstNode node, IList<CstNode> roots, int length, FeatureExtractor extractor) {
			var paths = new HashSet<string>();
			if (!roots.IsIntersect(node.AncestorsAndSelf())) {
				return paths;
			}
			// 自分自身の位置による区別も考慮する
			//ret.Add(node.Name);
			paths.Add(node.Name + node.RuleId);
			paths.Add("'" + extractor.GetToken(node));

			var children = new List<Tuple<CstNode, string>>();
			children.Add(Tuple.Create(node, ""));

			//var ancestorStr = "";
			//foreach (var e in node.AncestorsWithSingleChild()) {
			//    ancestorStr = ancestorStr + "<" + e.RuleId;
			//    ret.Add(ancestorStr);
			//}
			var i = 1;
			if (!extractor.IsInner) {
				var parent = Tuple.Create(node, "");
				//var descendantStr = "";
				//foreach (var e in node.DescendantsOfSingle()) {
				//    descendantStr = descendantStr + ">" + e.RuleId;
				//    ret.Add(descendantStr);
				//}
				var maxUp = extractor.MaxUp < 0 ? length : extractor.MaxUp;
				var maxLeft = extractor.MaxLeft < 0 ? 10 : extractor.MaxLeft;
				var maxRight = extractor.MaxRight < 0 ? 10 : extractor.MaxRight;
				for (; i <= maxUp; i++) {
					var newChildren = new List<Tuple<CstNode, string>>();
					foreach (var t in children) {
						foreach (var child in t.Item1.Children()) {
							if (CanSkip(child)) {
								continue;
							}
							var key = t.Item2 + ">" + child.Name + child.RuleId;
							newChildren.Add(Tuple.Create(child, key));
							// for Preconditions.checkArguments()
							paths.Add(t.Item2 + ">'" + extractor.GetToken(child));
						}
					}
					var parentPathUnit = parent.Item1.Parent != null ? parent.Item1.Parent.Name : "";
					parent.Item1.PrevsFromSelf().Take(i != maxUp ? 10 : maxLeft)
							.ForEach(
									(child, index) => {
										if (roots.IsIntersect(child.AncestorsAndSelf())) {
											var key = parent.Item2 + "<" + parentPathUnit + '-'
											          + index
											          + ">" + child.Name + child.RuleId;
											newChildren.Add(Tuple.Create(child, key));
											// for Preconditions.checkArguments()
											paths.Add(
													parent.Item2 + "<" + parentPathUnit + '-'
													+ index
													+ ">'" + extractor.GetToken(child));
										}
									});
					parent.Item1.NextsFromSelf().Take(i != maxUp ? 10 : maxRight)
							.ForEach(
									(child, index) => {
										if (roots.IsIntersect(child.AncestorsAndSelf())) {
											var key = parent.Item2 + "<" + parentPathUnit + '-'
											          + index
											          + ">" + child.Name + child.RuleId;
											newChildren.Add(Tuple.Create(child, key));
											// for Preconditions.checkArguments()
											paths.Add(
													parent.Item2 + "<" + parentPathUnit + '-'
													+ index
													+ ">'" + extractor.GetToken(child));
										}
									});
					paths.UnionWith(newChildren.Select(t => t.Item2));
					children = newChildren;

					var newParent = parent.Item1.Parent;
					if (newParent == null || !roots.IsIntersect(newParent.AncestorsAndSelf())) {
						break;
					}
					parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.Name + newParent.RuleId);
					paths.Add(parent.Item2);
				}
			}
			for (; i <= length; i++) {
				var newChildren = new List<Tuple<CstNode, string>>();
				foreach (var t in children) {
					foreach (var child in t.Item1.Children()) {
						if (CanSkip(child)) {
							continue;
						}
						var key = t.Item2 + ">" + child.Name + child.RuleId;
						newChildren.Add(Tuple.Create(child, key));
						// for Preconditions.checkArguments()
						paths.Add(t.Item2 + ">'" + extractor.GetToken(child));
					}
				}
				paths.UnionWith(newChildren.Select(t => t.Item2));
				children = newChildren;
			}
			return paths;
		}

		public static HashSet<string> GetSurroundingPaths(
				this CstNode node, int length, FeatureExtractor extractor) {
			var paths = new HashSet<string>();
			// 自分自身の位置による区別も考慮する
			//ret.Add(node.Name);
			paths.Add(node.Name + node.RuleId);
			paths.Add("'" + extractor.GetToken(node));

			var children = new List<Tuple<CstNode, string>>();
			children.Add(Tuple.Create(node, ""));
			//var ancestorStr = "";
			//foreach (var e in node.AncestorsWithSingleChild()) {
			//    ancestorStr = ancestorStr + "<" + e.RuleId;
			//    ret.Add(ancestorStr);
			//}
			var i = 1;
			if (!extractor.IsInner) {
				var parent = Tuple.Create(node, "");
				//var descendantStr = "";
				//foreach (var e in node.DescendantsOfSingle()) {
				//    descendantStr = descendantStr + ">" + e.RuleId;
				//    ret.Add(descendantStr);
				//}
				var maxUp = extractor.MaxUp < 0 ? length : extractor.MaxUp;
				var maxLeft = extractor.MaxLeft < 0 ? 10 : extractor.MaxLeft;
				var maxRight = extractor.MaxRight < 0 ? 10 : extractor.MaxRight;
				for (; i <= maxUp; i++) {
					var newChildren = new List<Tuple<CstNode, string>>();
					foreach (var t in children) {
						foreach (var child in t.Item1.Children()) {
							if (CanSkip(child)) {
								continue;
							}
							var key = t.Item2 + ">" + child.Name + child.RuleId;
							newChildren.Add(Tuple.Create(child, key));
							// for Preconditions.checkArguments()
							paths.Add(t.Item2 + ">'" + extractor.GetToken(child));
						}
					}
					var parentPathUnit = parent.Item1.Parent != null ? parent.Item1.Parent.Name : "";
					parent.Item1.PrevsFromSelf().Take(i != maxUp ? 10 : maxLeft)
							.ForEach(
									(child, index) => {
										var key = parent.Item2 + "<" + parentPathUnit + '-' + index
										          + ">" + child.Name + child.RuleId;
										newChildren.Add(Tuple.Create(child, key));
										// for Preconditions.checkArguments()
										paths.Add(
												parent.Item2 + "<" + parentPathUnit + '-' + index
												+ ">'" + extractor.GetToken(child));
									});
					parent.Item1.NextsFromSelf().Take(i != maxUp ? 10 : maxRight)
							.ForEach(
									(child, index) => {
										var key = parent.Item2 + "<" + parentPathUnit + '-' + index
										          + ">" + child.Name + child.RuleId;
										newChildren.Add(Tuple.Create(child, key));
										// for Preconditions.checkArguments()
										paths.Add(
												parent.Item2 + "<" + parentPathUnit + '-' + index
												+ ">'" + extractor.GetToken(child));
									});
					paths.UnionWith(newChildren.Select(t => t.Item2));
					children = newChildren;

					var newParent = parent.Item1.Parent;
					if (newParent == null) {
						break;
					}
					parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.Name + newParent.RuleId);
					paths.Add(parent.Item2);
				}
			}
			for (; i <= length; i++) {
				var newChildren = new List<Tuple<CstNode, string>>();
				foreach (var t in children) {
					foreach (var child in t.Item1.Children()) {
						if (CanSkip(child)) {
							continue;
						}
						var key = t.Item2 + ">" + child.Name + child.RuleId;
						newChildren.Add(Tuple.Create(child, key));
						// for Preconditions.checkArguments()
						paths.Add(t.Item2 + ">'" + extractor.GetToken(child));
					}
				}
				paths.UnionWith(newChildren.Select(t => t.Item2));
				children = newChildren;
			}
			return paths;
		}

		public static BigInteger GetFeatureVector(
				this CstNode node, int length, IDictionary<string, BigInteger> featureString2Bit,
				FeatureExtractor extractor) {
			var ret = BigInteger.Zero;
			BigInteger bit;
			//if (key2Bit.TryGetValue(node.Name, out bit)) {
			//    ret |= bit;
			//}
			if (featureString2Bit.TryGetValue(node.Name + node.RuleId, out bit)) {
				ret |= bit;
			}
			if (featureString2Bit.TryGetValue("'" + extractor.GetToken(node), out bit)) {
				ret |= bit;
			}

			var children = new List<Tuple<CstNode, string>>();
			children.Add(Tuple.Create(node, ""));
			//var ancestorStr = "";
			//foreach (var e in node.AncestorsWithSingleChild()) {
			//    ancestorStr = ancestorStr + "<" + e.RuleId;
			//    if (key2Bit.TryGetValue(ancestorStr, out bit)) {
			//        ret |= bit;
			//    }
			//}
			var i = 1;
			if (!extractor.IsInner) {
				var parent = Tuple.Create(node, "");
				//var descendantStr = "";
				//foreach (var e in node.DescendantsOfSingle()) {
				//    descendantStr = descendantStr + ">" + e.RuleId;
				//    if (key2Bit.TryGetValue(descendantStr, out bit)) {
				//        ret |= bit;
				//    }
				//}
				var maxUp = extractor.MaxUp < 0 ? length : extractor.MaxUp;
				var maxLeft = extractor.MaxLeft < 0 ? 10 : extractor.MaxLeft;
				var maxRight = extractor.MaxRight < 0 ? 10 : extractor.MaxRight;
				for (; i <= maxUp; i++) {
					var newChildren = new List<Tuple<CstNode, string>>();
					foreach (var t in children) {
						foreach (var child in t.Item1.Children()) {
							var key = t.Item2 + ">" + child.Name + child.RuleId;
							if (featureString2Bit.TryGetValue(key, out bit)) {
								newChildren.Add(Tuple.Create(child, key));
								ret |= bit;
							}
							// for Preconditions.checkArguments()
							if (featureString2Bit.TryGetValue(t.Item2 + ">'" + extractor.GetToken(child), out bit)) {
								ret |= bit;
							}
						}
					}
					var parentPathUnit = parent.Item1.Parent != null ? parent.Item1.Parent.Name : "";
					parent.Item1.PrevsFromSelf().Take(i != maxUp ? 10 : maxLeft)
							.ForEach(
									(child, index) => {
										var key = parent.Item2 + "<" + parentPathUnit + '-' + index
										          + ">" + child.Name + child.RuleId;
										if (featureString2Bit.TryGetValue(key, out bit)) {
											newChildren.Add(Tuple.Create(child, key));
											ret |= bit;
										}
										if (featureString2Bit.TryGetValue(
												parent.Item2 + "<" + parentPathUnit + '-' + index
												+ ">'" + extractor.GetToken(child), out bit)) {
											ret |= bit;
										}
									});
					parent.Item1.NextsFromSelf().Take(i != maxUp ? 10 : maxRight)
							.ForEach(
									(child, index) => {
										var key = parent.Item2 + "<" + parentPathUnit + '-' + index
										          + ">" + child.Name + child.RuleId;
										if (featureString2Bit.TryGetValue(key, out bit)) {
											newChildren.Add(Tuple.Create(child, key));
											ret |= bit;
										}
										if (featureString2Bit.TryGetValue(
												parent.Item2 + "<" + parentPathUnit + '-' + index
												+ ">'" + extractor.GetToken(child), out bit)) {
											ret |= bit;
										}
									});
					children = newChildren;

					var newParent = parent.Item1.Parent;
					if (newParent == null) {
						break;
					}
					parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.Name + newParent.RuleId);
					if (featureString2Bit.TryGetValue(parent.Item2, out bit)) {
						ret |= bit;
					} else {
						break;
					}
				}
			}
			for (; i <= length; i++) {
				var newChildren = new List<Tuple<CstNode, string>>();
				foreach (var t in children) {
					foreach (var child in t.Item1.Children()) {
						var key = t.Item2 + ">" + child.Name + child.RuleId;
						if (featureString2Bit.TryGetValue(key, out bit)) {
							newChildren.Add(Tuple.Create(child, key));
							ret |= bit;
						}
						// for Preconditions.checkArguments()
						if (featureString2Bit.TryGetValue(t.Item2 + ">'" + extractor.GetToken(child), out bit)) {
							ret |= bit;
						}
					}
				}
				children = newChildren;
			}
			return ret;
		}
	}
}