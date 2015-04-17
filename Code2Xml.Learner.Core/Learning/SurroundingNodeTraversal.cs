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
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
    public static class SurroundingNodeTraversal {
        private const int TokenCount = 5;

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
                this IEnumerable<CstNode> targets, List<CodeRange> rangeList,
                FeatureExtractor extractor) {
            var commonKeys = new HashSet<string>();
            var usedRangeCount = 0;
            foreach (var target in targets.OrderBy(t => CodeRange.Locate(t).StartLocation)) {
                var index = rangeList.FindIndex(range => range.Overlaps(target));
                if (index < 0) {
                    continue;
                }
                var surroundingNodes = rangeList[index]
                        .FindOverlappedNodes(target.AncestorsAndSelf().Last())
                        .ToHashSet();
                var keys = target
                        .GetSurroundingPathsFilteringBySurroundingNodes(surroundingNodes, extractor);
                commonKeys.UnionWith(keys);
                rangeList[index] = CodeRange.Nil;
                usedRangeCount++;
            }
            Console.WriteLine("#Used Ranges: " + usedRangeCount);
            return commonKeys;
        }

        private static bool CanSkip(CstNode node) {
            var tokenText = node.TokenText;
            return tokenText.Length == 1 && char.IsLetter(tokenText[0]);
        }

        public static HashSet<string> GetSurroundingPathsFilteringBySurroundingNodes(
                this CstNode node, HashSet<CstNode> surroundingNodes, FeatureExtractor extractor) {
            var paths = new HashSet<string>();
            var children = new List<Tuple<CstNode, string>> { Tuple.Create(node, "") };

            // 自分自身の位置による区別も考慮する
            paths.Add(node.Name);
            paths.Add("'" + extractor.GetToken(node));
            node.PreviousTokenNodes().Take(5)
                    .ForEach(
                            (tokenNode, i) => {
                                paths.Add("'-" + i + extractor.GetToken(tokenNode));
                            });
            node.NextTokenNodes().Take(5)
                    .ForEach(
                            (tokenNode, i) => {
                                paths.Add("'+" + i + extractor.GetToken(tokenNode));
                            });

            var ancestor = node.Ancestors().FirstOrDefault(a => a.Children().Count() > 1);
            if (surroundingNodes.Contains(ancestor)) {
                paths.Add(node.Name + node.RuleId);
                extractor.IsInner = false;

                var parent = Tuple.Create(node, "");
                while (surroundingNodes.Contains(parent.Item1.Parent)) {
                    var newParent = parent.Item1.Parent;
                    var parentPathUnit = parent.Item2 + "<" + newParent.Name + newParent.RuleId;
                    paths.Add(parentPathUnit);
                    parent.Item1.PrevsFromSelf().Take(10)
                            .ForEach((child, index) => {
                                if (surroundingNodes.Contains(child)) {
                                    var key = parentPathUnit + '-' + index +
                                              ">" + child.Name + child.RuleId;
                                    children.Add(Tuple.Create(child, key));
                                    // for Preconditions.checkArguments()
                                    paths.Add(parentPathUnit + '-' + index + ">'"
                                              + extractor.GetToken(child));
                                }
                            });
                    parent.Item1.NextsFromSelf().Take(10)
                            .ForEach((child, index) => {
                                if (surroundingNodes.Contains(child)) {
                                    var key = parentPathUnit + '+' + index +
                                              ">" + child.Name + child.RuleId;
                                    children.Add(Tuple.Create(child, key));
                                    // for Preconditions.checkArguments()
                                    paths.Add(parentPathUnit + '+' + index +
                                              ">'" + extractor.GetToken(child));
                                }
                            });
                    parent = Tuple.Create(newParent, parentPathUnit);
                }
            }
            paths.UnionWith(children.Skip(1).Select(t => t.Item2));
            var count = 0;
            do {
                var newChildren = new List<Tuple<CstNode, string>>();
                foreach (var t in children) {
                    foreach (var child in t.Item1.Children()) {
                        if (!CanSkip(child) && surroundingNodes.Contains(child)) {
                            var key = t.Item2 + ">" + child.Name + child.RuleId;
                            newChildren.Add(Tuple.Create(child, key));
                            // for Preconditions.checkArguments()
                            paths.Add(t.Item2 + ">'" + extractor.GetToken(child));
                        }
                    }
                }
                paths.UnionWith(newChildren.Select(t => t.Item2));
                children = newChildren;
            } while (children.Any() && ++count <= 7);
            return paths;
        }

        public static BigInteger GetFeatureVector(
                this CstNode node, IDictionary<string, BigInteger> featureString2Bit,
                FeatureExtractor extractor) {
            var ret = BigInteger.Zero;
            BigInteger bit;

            var children = new List<Tuple<CstNode, string>> { Tuple.Create(node, "") };

            if (featureString2Bit.TryGetValue(node.Name, out bit)) {
                ret |= bit;
            }
            if (featureString2Bit.TryGetValue("'" + extractor.GetToken(node), out bit)) {
                ret |= bit;
            }
            node.PreviousTokenNodes().Take(5)
                    .ForEach(
                            (tokenNode, i) => {
                                if (featureString2Bit.TryGetValue(
                                        "'-" + i + extractor.GetToken(tokenNode), out bit)) {
                                    ret |= bit;
                                }
                            });
            node.NextTokenNodes().Take(5)
                    .ForEach(
                            (tokenNode, i) => {
                                if (featureString2Bit.TryGetValue(
                                        "'+" + i + extractor.GetToken(tokenNode), out bit)) {
                                    ret |= bit;
                                }
                            });
            if (!extractor.IsInner) {
                if (featureString2Bit.TryGetValue(node.Name + node.RuleId, out bit)) {
                    ret |= bit;
                }
                var parent = Tuple.Create(node, "");
                while (parent.Item1.Parent != null) {
                    var newParent = parent.Item1.Parent;
                    var parentPathUnit = parent.Item2 + "<" + newParent.Name + newParent.RuleId;
                    if (!featureString2Bit.TryGetValue(parentPathUnit, out bit)) {
                        break;
                    }
                    ret |= bit;
                    parent.Item1.PrevsFromSelf().Take(10)
                            .ForEach((child, index) => {
                                var key = parentPathUnit + '-' + index +
                                          ">" + child.Name + child.RuleId;
                                if (featureString2Bit.TryGetValue(key, out bit)) {
                                    // 枝刈り
                                    children.Add(Tuple.Create(child, key));
                                    ret |= bit;
                                }
                                if (featureString2Bit.TryGetValue(
                                        parentPathUnit + '-' + index +
                                        ">'" + extractor.GetToken(child), out bit)) {
                                    ret |= bit;
                                }
                            });
                    parent.Item1.NextsFromSelf().Take(10)
                            .ForEach((child, index) => {
                                var key = parentPathUnit + '+' + index +
                                          ">" + child.Name + child.RuleId;
                                if (featureString2Bit.TryGetValue(key, out bit)) {
                                    // 枝刈り
                                    children.Add(Tuple.Create(child, key));
                                    ret |= bit;
                                }
                                if (featureString2Bit.TryGetValue(
                                        parentPathUnit + '+' + index +
                                        ">'" + extractor.GetToken(child), out bit)) {
                                    ret |= bit;
                                }
                            });
                    parent = Tuple.Create(newParent, parentPathUnit);
                }
            }
            do {
                var newChildren = new List<Tuple<CstNode, string>>();
                foreach (var t in children) {
                    foreach (var child in t.Item1.Children()) {
                        var key = t.Item2 + ">" + child.Name + child.RuleId;
                        if (featureString2Bit.TryGetValue(key, out bit)) {
                            newChildren.Add(Tuple.Create(child, key));
                            ret |= bit;
                        }
                        // for Preconditions.checkArguments()
                        if (featureString2Bit.TryGetValue(
                                t.Item2 + ">'" + extractor.GetToken(child), out bit)) {
                            ret |= bit;
                        }
                    }
                }
                children = newChildren;
            } while (children.Any());
            return ret;
        }
    }
}