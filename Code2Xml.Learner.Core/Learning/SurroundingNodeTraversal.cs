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
        private const int ChildrenCount = 7;

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
                this ICollection<CstNode> nodes, ICollection<SelectedFragment> fragments,
                FeatureExtractor extractor) {
            var commonKeys = new HashSet<string>();
            var usedRangeCount = 0;
            if (nodes.Count > 0) {
                var root = nodes.First().AncestorsAndSelf().Last();
                foreach (var node in nodes) {
                    IEnumerable<CstNode> surroundingNodes;
                    CstNode outermostNode = null;
                    var fragment = fragments
                            .FirstOrDefault(f => node.AncestorWithSingleChild() == f.Node);
                    if (fragment != null) {
                        surroundingNodes = fragment.SurroundingRange.FindOverlappedNodes(root);
                        outermostNode = fragment.SurroundingRange.FindInnermostNode(root);
                        usedRangeCount++;
                    } else {
                        surroundingNodes = node.DescendantsAndSelf();
                    }
                    var keys = node.GetSurroundingPaths(
                            surroundingNodes.ToHashSet(), extractor, outermostNode);
                    commonKeys.UnionWith(keys);
                }
            }
            Console.WriteLine("#Used Ranges: " + usedRangeCount);
            return commonKeys;
        }

        private static bool IsTemporalVariable(CstNode node) {
            var tokenText = node.TokenText;
            return IsTemporalVariable(tokenText);
        }

        private static bool IsTemporalVariable(string tokenText) {
            return (tokenText.Length == 1 || (tokenText.StartsWith("$") && tokenText.Length == 2))
                   && char.IsLetter(tokenText[0]);
        }

        private static bool IsMeaningfulIdentifier(CstNode node) {
            var tokenText = node.TokenText;
            return IsMeaningfulIdentifier(tokenText);
        }

        private static bool IsMeaningfulIdentifier(string tokenText) {
            return !(tokenText.Length <= 1 || (tokenText.StartsWith("$") && tokenText.Length == 2))
                   && char.IsLetter(tokenText[0]);
        }

        private static Tuple<string, bool> GetSurroundingPaths(
                CstNode node, string path, ICollection<CstNode> surroundingNodes,
                FeatureExtractor extractor, ISet<string> paths) {
            var token = "";
            var temporal = false;
            var count = 0;
            if (node.HasToken) {
                token = extractor.GetToken(node);
                temporal = IsTemporalVariable(token);
            } else {
                foreach (var child in node.Children()) {
                    count++;
                    if (surroundingNodes.Contains(child)) {
                        var ret = GetSurroundingPaths(child, path + ">" + child.Name + child.RuleId,
                                surroundingNodes, extractor, paths);
                        temporal = ret.Item2;
                        if (token != null && ret.Item1 != null) {
                            token += ret.Item1;
                            continue;
                        }
                    }
                    token = null;
                }
            }
            if (temporal && count <= 1) {
                return Tuple.Create<string, bool>(null, true);
            }
            paths.Add(path);
            if (token != null) {
                paths.Add(path + "'" + token); // need node.Name + node.RuleId ?
            }
            return Tuple.Create(token, false);
        }

        private static string GetFeatureVector(
                CstNode node, string path, IDictionary<string, BigInteger> featureString2Bit,
                FeatureExtractor extractor, ref BigInteger vector) {
            BigInteger bit;
            var token = "";
            if (node.HasToken) {
                token = extractor.GetToken(node);
            } else {
                foreach (var child in node.Children()) {
                    var newPath = path + ">" + child.Name + child.RuleId;
                    if (featureString2Bit.TryGetValue(newPath, out bit)) {
                        vector |= bit;
                        var ret = GetFeatureVector(child, newPath, featureString2Bit, extractor,
                                ref vector);
                        if (token != null && ret != null) {
                            token += ret;
                            continue;
                        }
                    }
                    token = null;
                }
            }
            if (token != null) {
                if (featureString2Bit.TryGetValue(path + "'" + token, out bit)) {
                    vector |= bit;
                }
            }
            return token;
        }

        public static HashSet<string> GetSurroundingPaths(
                this CstNode node, HashSet<CstNode> surroundingNodes, FeatureExtractor extractor,
                CstNode outermostNode) {
            var path = "";
            var paths = new HashSet<string>();

            paths.Add(node.Name);
            paths.Add("'" + extractor.GetToken(node));

            var ancestor = node.Ancestors().FirstOrDefault(a => a.Children().Count() > 1);
            if (surroundingNodes.Contains(ancestor)) {
                extractor.IsInner = false;

                var originalNode = node;
                path = node.Name + node.RuleId;
                while ((node = node.Parent) != outermostNode) {
                    path = path + "<" + node.Name + node.RuleId;
                    paths.Add(path);
                }
                path = path + "<" + node.Name; // must not have RuleId
                paths.Add(path);

                var index = 0;
                foreach (var tokenNode in
                        originalNode.PreviousTokenNodes(node).Where(IsMeaningfulIdentifier)) {
                    if (!surroundingNodes.Contains(tokenNode)) {
                        break;
                    }
                    paths.Add("'-" + extractor.GetToken(tokenNode));
                    index++;
                }
                extractor.TokenLeft = Math.Max(extractor.TokenLeft, index);
                index = 0;
                foreach (var tokenNode in 
                        originalNode.NextTokenNodes(node).Where(IsMeaningfulIdentifier)) {
                    if (!surroundingNodes.Contains(tokenNode)) {
                        break;
                    }
                    paths.Add("'+" + extractor.GetToken(tokenNode));
                    index++;
                }
                extractor.TokenRight = Math.Max(extractor.TokenRight, index);
            }
            GetSurroundingPaths(node, path, surroundingNodes, extractor, paths);
            return paths;
        }

        public static BigInteger GetFeatureVector(
                this CstNode node, IDictionary<string, BigInteger> featureString2Bit,
                FeatureExtractor extractor) {
            BigInteger bit;
            var path = "";
            var vector = BigInteger.Zero;

            if (featureString2Bit.TryGetValue(node.Name, out bit)) {
                vector |= bit;
            }
            if (featureString2Bit.TryGetValue("'" + extractor.GetToken(node), out bit)) {
                vector |= bit;
            }

            if (!extractor.IsInner) {
                var originalNode = node;
                path = node.Name + node.RuleId;
                while (true) {
                    node = node.Parent;
                    var newPath = path + "<" + node.Name + node.RuleId;
                    if (!featureString2Bit.TryGetValue(newPath, out bit)) {
                        break;
                    }
                    path = newPath;
                    // vector |= bit; is unnecesarry
                }
                path = path + "<" + node.Name; // must not have RuleId
                if (!featureString2Bit.TryGetValue(path, out bit)) {
                    return vector;
                }
                // vector |= bit; is unnecesarry

                originalNode.PreviousTokenNodes(node)
                        .Where(IsMeaningfulIdentifier)
                        .Take(extractor.TokenLeft)
                        .ForEach(
                                tokenNode => {
                                    if (featureString2Bit.TryGetValue(
                                            "'-" + extractor.GetToken(tokenNode), out bit)) {
                                        vector |= bit;
                                    }
                                });
                originalNode.NextTokenNodes(node)
                        .Where(IsMeaningfulIdentifier)
                        .Take(extractor.TokenRight)
                        .ForEach(
                                tokenNode => {
                                    if (featureString2Bit.TryGetValue(
                                            "'+" + extractor.GetToken(tokenNode), out bit)) {
                                        vector |= bit;
                                    }
                                });
            }
            GetFeatureVector(node, path, featureString2Bit, extractor, ref vector);
            return vector;
        }
    }
}