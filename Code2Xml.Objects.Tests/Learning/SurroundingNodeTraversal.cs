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
using System.Linq;
using System.Numerics;
using Code2Xml.Core.Generators;
using Paraiba.Linq;

namespace Code2Xml.Objects.Tests.Learning {
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
				this IEnumerable<CstNode> targets, int length, bool inner = true, bool outer = true) {
			var commonKeys = new HashSet<string>();
			foreach (var target in targets) {
				var keys = target.GetSurroundingKeys(length, inner, outer);
				commonKeys.UnionWith(keys);
			}
			return commonKeys;
		}

		public static HashSet<string> GetCommonKeys(
				this IEnumerable<CstNode> targets, int length, bool inner = true, bool outer = true) {
			HashSet<string> commonKeys = null;
			foreach (var target in targets) {
				var keys = target.GetSurroundingKeys(length, inner, outer);
				if (commonKeys == null) {
					commonKeys = keys;
				} else {
					commonKeys.IntersectWith(keys);
				}
			}
			return commonKeys;
		}

		public static HashSet<string> GetSurroundingKeys(
				this CstNode node, int length, bool inner = true, bool outer = true) {
			//inner = outer = true; // TODO: for debug

			var ret = new HashSet<string>();
			var childElements = new List<Tuple<CstNode, string>>();
			if (inner) {
				childElements.Add(Tuple.Create(node, node.Name));
				var ancestorStr = "";
				foreach (var e in node.AncestorsWithSingleChildAndSelf()) {
					ancestorStr = ancestorStr + "<" + e.NameWithId();
					ret.Add(ancestorStr);
				}
			}
			var i = 1;
			if (outer) {
				var parentElement = Tuple.Create(node, node.Name);
				var descendantStr = "";
				foreach (var e in node.DescendantsOfSingleAndSelf()) {
					descendantStr = descendantStr + "<" + e.NameWithId();
					ret.Add(descendantStr);
				}
				// 自分自身の位置による区別も考慮する
				ret.Add(node.NameOrTokenWithId());
				for (; i <= length; i++) {
					var newChildElements = new List<Tuple<CstNode, string>>();
					foreach (var t in childElements) {
						foreach (var e in t.Item1.Elements()) {
							var key = t.Item2 + ">" + e.NameOrTokenWithId();
							newChildElements.Add(Tuple.Create(e, key));
							// トークンが存在するかチェックする弱い条件
							// for Preconditions.checkArguments()
							ret.Add(t.Item2 + ">'" + e.TokenText + "'");
						}
						foreach (var e in t.Item1.Descendants()) {
							// トークンが存在するかチェックする弱い条件
							//ret.Add(t.Item2 + ">>'" + e.TokenText() + "'");
						}
					}
					foreach (var e in parentElement.Item1.Siblings(10)) {
						var key = parentElement.Item2 + "-" + e.NameOrTokenWithId();
						//newChildElements.Add(Tuple.Create(e, key));
						// トークンが存在するかチェックする弱い条件
						// for Preconditions.checkArguments()
						ret.Add(parentElement.Item2 + "-'" + e.TokenText + "'");
					}
					parentElement.Item1.PrevsFromSelf().Take(10)
							.ForEach(
									(e, index) => {
										var key = parentElement.Item2 + "<-" + index + "-" + e.NameOrTokenWithId();
										newChildElements.Add(Tuple.Create(e, key));
										//ret.Add(key);
									});
					parentElement.Item1.NextsFromSelf().Take(10)
							.ForEach(
									(e, index) => {
										var key = parentElement.Item2 + ">-" + index + "-" + e.NameOrTokenWithId();
										newChildElements.Add(Tuple.Create(e, key));
										//ret.Add(key);
									});
					ret.UnionWith(newChildElements.Select(t => t.Item2));
					childElements = newChildElements;

					var newParentElement = parentElement.Item1.Parent;
					if (newParentElement == null) {
						break;
					}
					parentElement = Tuple.Create(
							newParentElement,
							parentElement.Item2 + "<" + newParentElement.NameOrTokenWithId());
					ret.Add(parentElement.Item2);
				}
			}
			for (; i <= length; i++) {
				var newChildElements = new List<Tuple<CstNode, string>>();
				foreach (var t in childElements) {
					foreach (var e in t.Item1.Elements()) {
						var key = t.Item2 + ">" + e.NameOrTokenWithId();
						newChildElements.Add(Tuple.Create(e, key));
						// トークンが存在するかチェックする弱い条件
						// for Preconditions.checkArguments()
						ret.Add(t.Item2 + ">'" + e.TokenText + "'");
					}
				}
				ret.UnionWith(newChildElements.Select(t => t.Item2));
				childElements = newChildElements;
			}
			return ret;
		}

		public static BigInteger GetSurroundingBits(
				this CstNode node, int length, IDictionary<string, BigInteger> key2Bit, bool inner = true,
				bool outer = true) {
			//inner = outer = true; // for debug

			var ret = BigInteger.Zero;
			BigInteger bit;
			var childElements = new List<Tuple<CstNode, string>>();
			if (inner) {
				childElements.Add(Tuple.Create(node, node.Name));
				var parentStr = "";
				foreach (var e in node.AncestorsWithSingleChildAndSelf()) {
					parentStr = parentStr + "<" + e.NameWithId();
					if (key2Bit.TryGetValue(parentStr, out bit)) {
						ret |= bit;
					}
				}
			}
			var i = 1;
			if (outer) {
				var parentElement = Tuple.Create(node, node.Name);
				var descendantStr = "";
				foreach (var e in node.DescendantsOfSingleAndSelf()) {
					descendantStr = descendantStr + "<" + e.NameWithId();
					if (key2Bit.TryGetValue(descendantStr, out bit)) {
						ret |= bit;
					}
				}
				// 自分自身の位置による区別も考慮する
				if (key2Bit.TryGetValue(node.NameOrTokenWithId(), out bit)) {
					ret |= bit;
				}
				for (; i <= length; i++) {
					var newChildElements = new List<Tuple<CstNode, string>>();
					foreach (var t in childElements) {
						foreach (var e in t.Item1.Elements()) {
							var key = t.Item2 + ">" + e.NameOrTokenWithId();
							if (key2Bit.TryGetValue(key, out bit)) {
								newChildElements.Add(Tuple.Create(e, key));
								ret |= bit;
							}
							// トークンが存在するかチェックする弱い条件
							// for Preconditions.checkArguments()
							if (key2Bit.TryGetValue(t.Item2 + ">'" + e.TokenText + "'", out bit)) {
								ret |= bit;
							}
						}
						foreach (var e in t.Item1.Descendants()) {
							// トークンが存在するかチェックする弱い条件
							//ret.Add(t.Item2 + ">>'" + e.TokenText() + "'");
						}
					}
					foreach (var e in parentElement.Item1.Siblings(10)) {
						var key = parentElement.Item2 + "-" + e.NameOrTokenWithId();
						//if (key2Bit.TryGetValue(key, out bit)) {
						//	newChildElements.Add(Tuple.Create(e, key));
						//	ret |= bit;
						//}
						// トークンが存在するかチェックする弱い条件
						// for Preconditions.checkArguments()
						if (key2Bit.TryGetValue(parentElement.Item2 + "-'" + e.TokenText + "'", out bit)) {
							ret |= bit;
						}
					}
					parentElement.Item1.PrevsFromSelf().Take(10)
							.ForEach(
									(e, index) => {
										var key = parentElement.Item2 + "<-" + index + "-" + e.NameOrTokenWithId();
										if (key2Bit.TryGetValue(key, out bit)) {
											newChildElements.Add(Tuple.Create(e, key));
											ret |= bit;
										}
									});
					parentElement.Item1.NextsFromSelf().Take(10)
							.ForEach(
									(e, index) => {
										var key = parentElement.Item2 + ">-" + index + "-" + e.NameOrTokenWithId();
										if (key2Bit.TryGetValue(key, out bit)) {
											newChildElements.Add(Tuple.Create(e, key));
											ret |= bit;
										}
									});
					childElements = newChildElements;

					var newParentElement = parentElement.Item1.Parent;
					if (newParentElement == null) {
						break;
					}
					parentElement = Tuple.Create(
							newParentElement,
							parentElement.Item2 + "<" + newParentElement.NameOrTokenWithId());
					if (key2Bit.TryGetValue(parentElement.Item2, out bit)) {
						ret |= bit;
					} else {
						break;
					}
				}
			}
			for (; i <= length; i++) {
				var newChildElements = new List<Tuple<CstNode, string>>();
				foreach (var t in childElements) {
					foreach (var e in t.Item1.Elements()) {
						var key = t.Item2 + ">" + e.NameOrTokenWithId();
						if (key2Bit.TryGetValue(key, out bit)) {
							newChildElements.Add(Tuple.Create(e, key));
							ret |= bit;
						}
						// トークンが存在するかチェックする弱い条件
						// for Preconditions.checkArguments()
						if (key2Bit.TryGetValue(t.Item2 + ">'" + e.TokenText + "'", out bit)) {
							ret |= bit;
						}
					}
				}
				childElements = newChildElements;
			}
			return ret;
		}
	}
}