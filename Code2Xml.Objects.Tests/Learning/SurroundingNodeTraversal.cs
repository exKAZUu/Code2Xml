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
                this IEnumerable<CstNode> targets, int length, ILearningExperiment exp) {
            var commonKeys = new HashSet<string>();
            foreach (var target in targets) {
                var keys = target.GetSurroundingKeys(length, exp);
                commonKeys.UnionWith(keys);
            }
            return commonKeys;
        }

        public static HashSet<string> GetCommonKeys(
                this IEnumerable<CstNode> targets, int length, ILearningExperiment exp) {
            HashSet<string> commonKeys = null;
            foreach (var target in targets) {
                var keys = target.GetSurroundingKeys(length, exp);
                if (commonKeys == null) {
                    commonKeys = keys;
                } else {
                    commonKeys.IntersectWith(keys);
                }
            }
            return commonKeys;
        }

        public static HashSet<string> GetSurroundingKeys(
                this CstNode node, int length, ILearningExperiment exp) {
            var ret = new HashSet<string>();
            // 自分自身の位置による区別も考慮する
            //ret.Add(node.Name);
            ret.Add(node.RuleId);
            ret.Add("'" + exp.GetToken(node));

            var children = new List<Tuple<CstNode, string>>();
            children.Add(Tuple.Create(node, ""));
            //var ancestorStr = "";
            //foreach (var e in node.AncestorsWithSingleChild()) {
            //    ancestorStr = ancestorStr + "<" + e.RuleId;
            //    ret.Add(ancestorStr);
            //}
            var i = 1;
            if (!exp.IsInner) {
                var parent = Tuple.Create(node, "");
                //var descendantStr = "";
                //foreach (var e in node.DescendantsOfSingle()) {
                //    descendantStr = descendantStr + ">" + e.RuleId;
                //    ret.Add(descendantStr);
                //}
                for (; i <= length; i++) {
                    var newChildren = new List<Tuple<CstNode, string>>();
                    foreach (var t in children) {
                        foreach (var e in t.Item1.Elements()) {
                            var key = t.Item2 + ">" + e.RuleId;
                            newChildren.Add(Tuple.Create(e, key));
                            // for Preconditions.checkArguments()
                            ret.Add(t.Item2 + ">'" + exp.GetToken(e));
                        }
                    }
                    parent.Item1.PrevsFromSelf().Take(10)
                            .ForEach(
                                    (e, index) => {
                                        var key = parent.Item2 + "<-" + index + "-" + e.RuleId;
                                        newChildren.Add(Tuple.Create(e, key));
                                        // for Preconditions.checkArguments()
                                        ret.Add(
                                                parent.Item2 + "<-" + index + "-'" + exp.GetToken(e));
                                    });
                    parent.Item1.NextsFromSelf().Take(10)
                            .ForEach(
                                    (e, index) => {
                                        var key = parent.Item2 + ">-" + index + "-" + e.RuleId;
                                        newChildren.Add(Tuple.Create(e, key));
                                        // for Preconditions.checkArguments()
                                        ret.Add(
                                                parent.Item2 + ">-" + index + "-'" + exp.GetToken(e));
                                    });
                    ret.UnionWith(newChildren.Select(t => t.Item2));
                    children = newChildren;

                    var newParent = parent.Item1.Parent;
                    if (newParent == null) {
                        break;
                    }
                    parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.RuleId);
                    ret.Add(parent.Item2);
                }
            }
            for (; i <= length; i++) {
                var newChildren = new List<Tuple<CstNode, string>>();
                foreach (var t in children) {
                    foreach (var e in t.Item1.Elements()) {
                        var key = t.Item2 + ">" + e.RuleId;
                        newChildren.Add(Tuple.Create(e, key));
                        // for Preconditions.checkArguments()
                        ret.Add(t.Item2 + ">'" + exp.GetToken(e));
                    }
                }
                ret.UnionWith(newChildren.Select(t => t.Item2));
                children = newChildren;
            }
            return ret;
        }

        public static BigInteger GetSurroundingBits(
                this CstNode node, int length, IDictionary<string, BigInteger> key2Bit,
                ILearningExperiment exp) {
            var ret = BigInteger.Zero;
            BigInteger bit;
            //if (key2Bit.TryGetValue(node.Name, out bit)) {
            //    ret |= bit;
            //}
            if (key2Bit.TryGetValue(node.RuleId, out bit)) {
                ret |= bit;
            }
            if (key2Bit.TryGetValue("'" + exp.GetToken(node), out bit)) {
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
            if (!exp.IsInner) {
                var parent = Tuple.Create(node, "");
                //var descendantStr = "";
                //foreach (var e in node.DescendantsOfSingle()) {
                //    descendantStr = descendantStr + ">" + e.RuleId;
                //    if (key2Bit.TryGetValue(descendantStr, out bit)) {
                //        ret |= bit;
                //    }
                //}
                for (; i <= length; i++) {
                    var newChildren = new List<Tuple<CstNode, string>>();
                    foreach (var t in children) {
                        foreach (var e in t.Item1.Elements()) {
                            var key = t.Item2 + ">" + e.RuleId;
                            if (key2Bit.TryGetValue(key, out bit)) {
                                newChildren.Add(Tuple.Create(e, key));
                                ret |= bit;
                            }
                            // for Preconditions.checkArguments()
                            if (key2Bit.TryGetValue(t.Item2 + ">'" + exp.GetToken(e), out bit)) {
                                ret |= bit;
                            }
                        }
                    }
                    parent.Item1.PrevsFromSelf().Take(10)
                            .ForEach(
                                    (e, index) => {
                                        var key = parent.Item2 + "<-" + index + "-" + e.RuleId;
                                        if (key2Bit.TryGetValue(key, out bit)) {
                                            newChildren.Add(Tuple.Create(e, key));
                                            ret |= bit;
                                        }
                                        if (key2Bit.TryGetValue(
                                                parent.Item2 + "<-" + index + "-'" + exp.GetToken(e),
                                                out bit)) {
                                            ret |= bit;
                                        }
                                    });
                    parent.Item1.NextsFromSelf().Take(10)
                            .ForEach(
                                    (e, index) => {
                                        var key = parent.Item2 + ">-" + index + "-" + e.RuleId;
                                        if (key2Bit.TryGetValue(key, out bit)) {
                                            newChildren.Add(Tuple.Create(e, key));
                                            ret |= bit;
                                        }
                                        if (key2Bit.TryGetValue(
                                                parent.Item2 + ">-" + index + "-'" + exp.GetToken(e),
                                                out bit)) {
                                            ret |= bit;
                                        }
                                    });
                    children = newChildren;

                    var newParent = parent.Item1.Parent;
                    if (newParent == null) {
                        break;
                    }
                    parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.RuleId);
                    if (key2Bit.TryGetValue(parent.Item2, out bit)) {
                        ret |= bit;
                    } else {
                        break;
                    }
                }
            }
            for (; i <= length; i++) {
                var newChildren = new List<Tuple<CstNode, string>>();
                foreach (var t in children) {
                    foreach (var e in t.Item1.Elements()) {
                        var key = t.Item2 + ">" + e.RuleId;
                        if (key2Bit.TryGetValue(key, out bit)) {
                            newChildren.Add(Tuple.Create(e, key));
                            ret |= bit;
                        }
                        // for Preconditions.checkArguments()
                        if (key2Bit.TryGetValue(t.Item2 + ">'" + exp.GetToken(e), out bit)) {
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