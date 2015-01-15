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
                this IEnumerable<CstNode> targets, int length, ILearningExperiment exp) {
            var commonKeys = new HashSet<string>();
            foreach (var target in targets) {
                var roots = exp.GetRootsUsingOracle(target);
                var keys = roots == null
                        ? target.GetSurroundingPaths(length, exp)
                        : target.GetSurroundingPathsFilteringByRoots(roots, length, exp);
                commonKeys.UnionWith(keys);
            }
            return commonKeys;
        }

        public static HashSet<string> GetCommonKeys(
                this IEnumerable<CstNode> targets, int length, ILearningExperiment exp) {
            HashSet<string> commonKeys = null;
            foreach (var target in targets) {
                var roots = exp.GetRootsUsingOracle(target);
                var keys = roots == null
                        ? target.GetSurroundingPaths(length, exp)
                        : target.GetSurroundingPathsFilteringByRoots(roots, length, exp);
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

        //private static void GetDescendantPaths(
        //        CstNode node, CstNode reached, string path, int length, ILearningExperiment exp,
        //        HashSet<string> paths) {
        //    if (--length < 0) {
        //        return;
        //    }
        //    var children = new List<Tuple<CstNode, string>>();
        //    foreach (var child in node.Children()) {
        //        if (child == reached || CanSkip(child)) {
        //            continue;
        //        }
        //        children.Add(Tuple.Create(child, path + ">" + child.Name + child.RuleId));
        //        // for Preconditions.checkArguments()
        //        paths.Add(path + ">'" + exp.GetToken(child));
        //    }
        //    paths.UnionWith(children.Select(t => t.Item2));

        //    while (!children.isEmpty() && --length >= 0) {
        //        var newChildren = new List<Tuple<CstNode, string>>();
        //        foreach (var t in children) {
        //            foreach (var child in t.Item1.Children()) {
        //                if (CanSkip(child)) {
        //                    continue;
        //                }
        //                newChildren.Add(
        //                        Tuple.Create(child, t.Item2 + ">" + child.Name + child.RuleId));
        //                // for Preconditions.checkArguments()
        //                paths.Add(t.Item2 + ">'" + exp.GetToken(child));
        //            }
        //        }
        //        paths.UnionWith(newChildren.Select(t => t.Item2));
        //        children = newChildren;
        //    }
        //}

        //public static HashSet<string> GetSurroundingPaths(
        //        this CstNode node, int length, ILearningExperiment exp) {
        //    var paths = new HashSet<string>();
        //    // 自分自身の位置による区別も考慮する
        //    //ret.Add(node.Name);
        //    paths.Add(node.RuleId);
        //    paths.Add("'" + exp.GetToken(node));

        //    var reached = node;
        //    var path = "";
        //    for (int i = 0;; i++) {
        //        GetDescendantPaths(node, reached, path, length, exp, paths);
        //        reached = node;
        //        node = node.Parent;
        //        if (node == null || i >= length) {
        //            break;
        //        }
        //        path += "<" + node.RuleId;
        //        paths.Add(path);
        //    }
        //    return paths;
        //}

        //private static BigInteger GetDescendantPathBits(
        //        CstNode node, CstNode reached, string path, IDictionary<string, BigInteger> path2Bit,
        //        int length, ILearningExperiment exp, BigInteger bits) {
        //    if (--length < 0) {
        //        return bits;
        //    }
        //    BigInteger bit;
        //    var children = new List<Tuple<CstNode, string>>();
        //    foreach (var child in node.Children()) {
        //        if (child == reached || CanSkip(child)) {
        //            continue;
        //        }
        //        var newPath = path + ">" + child.Name + child.RuleId;
        //        if (path2Bit.TryGetValue(newPath, out bit)) {
        //            children.Add(Tuple.Create(child, newPath));
        //            bits |= bit;
        //        }
        //        // for Preconditions.checkArguments()
        //        if (path2Bit.TryGetValue(children + ">'" + exp.GetToken(child), out bit)) {
        //            bits |= bit;
        //        }
        //    }
        //    while (!children.isEmpty() && --length >= 0) {
        //        var newChildren = new List<Tuple<CstNode, string>>();
        //        foreach (var t in children) {
        //            foreach (var child in t.Item1.Children()) {
        //                if (CanSkip(child)) {
        //                    continue;
        //                }
        //                var newPath = t.Item2 + ">" + child.Name + child.RuleId;
        //                if (path2Bit.TryGetValue(newPath, out bit)) {
        //                    newChildren.Add(Tuple.Create(child, newPath));
        //                    bits |= bit;
        //                }
        //                // for Preconditions.checkArguments()
        //                if (path2Bit.TryGetValue(t.Item2 + ">'" + exp.GetToken(child), out bit)) {
        //                    bits |= bit;
        //                }
        //            }
        //        }
        //        children = newChildren;
        //    }
        //    return bits;
        //}

        //public static BigInteger GetFeatureVector(
        //        this CstNode node, int length, IDictionary<string, BigInteger> path2Bit,
        //        ILearningExperiment exp) {
        //    var bits = BigInteger.Zero;
        //    BigInteger bit;
        //    //if (key2Bit.TryGetValue(node.Name, out bit)) {
        //    //    bits |= bit;
        //    //}
        //    if (path2Bit.TryGetValue(node.RuleId, out bit)) {
        //        bits |= bit;
        //    }
        //    if (path2Bit.TryGetValue("'" + exp.GetToken(node), out bit)) {
        //        bits |= bit;
        //    }

        //    var reached = node;
        //    var path = "";
        //    for (int i = 0;; i++) {
        //        bits = GetDescendantPathBits(node, reached, path, path2Bit, length, exp, bits);
        //        reached = node;
        //        node = node.Parent;
        //        if (node == null || i >= length) {
        //            break;
        //        }
        //        path += "<" + node.RuleId;
        //        if (path2Bit.TryGetValue(path, out bit)) {
        //            bits |= bit;
        //        } else {
        //            break;
        //        }
        //    }
        //    return bits;
        //}

        //public static HashSet<string> GetSurroundingPaths(
        //        this CstNode node, int length, ILearningExperiment exp) {
        //    var paths = new HashSet<string>();
        //    // 自分自身の位置による区別も考慮する
        //    //ret.Add(node.Name);
        //    paths.Add(node.RuleId);
        //    paths.Add("'" + exp.GetToken(node));

        //    var children = new List<Tuple<CstNode, string>>();
        //    children.Add(Tuple.Create(node, ""));
        //    //var ancestorStr = "";
        //    //foreach (var e in node.AncestorsWithSingleChild()) {
        //    //    ancestorStr = ancestorStr + "<" + e.RuleId;
        //    //    ret.Add(ancestorStr);
        //    //}
        //    var i = 1;
        //    if (!exp.IsInner) {
        //        var parent = Tuple.Create(node, "");
        //        //var descendantStr = "";
        //        //foreach (var e in node.DescendantsOfSingle()) {
        //        //    descendantStr = descendantStr + ">" + e.RuleId;
        //        //    ret.Add(descendantStr);
        //        //}
        //        for (; i <= length; i++) {
        //            var newChildren = new List<Tuple<CstNode, string>>();
        //            foreach (var t in children) {
        //                foreach (var child in t.Item1.Elements()) {
        //                    if (CanSkip(child)) {
        //                        continue;
        //                    }
        //                    var key = t.Item2 + ">" + child.RuleId;
        //                    newChildren.Add(Tuple.Create(child, key));
        //                    // for Preconditions.checkArguments()
        //                    paths.Add(t.Item2 + ">'" + exp.GetToken(child));
        //                }
        //            }
        //            parent.Item1.PrevsFromSelf().Take(10)
        //                    .ForEach(
        //                            (child, index) => {
        //                                var key = parent.Item2 + "<-" + index + "-" + child.RuleId;
        //                                newChildren.Add(Tuple.Create(child, key));
        //                                // for Preconditions.checkArguments()
        //                                paths.Add(
        //                                        parent.Item2 + "<-" + index + "-'"
        //                                        + exp.GetToken(child));
        //                            });
        //            parent.Item1.NextsFromSelf().Take(10)
        //                    .ForEach(
        //                            (e, index) => {
        //                                var key = parent.Item2 + ">-" + index + "-" + e.RuleId;
        //                                newChildren.Add(Tuple.Create(e, key));
        //                                // for Preconditions.checkArguments()
        //                                paths.Add(
        //                                        parent.Item2 + ">-" + index + "-'" + exp.GetToken(e));
        //                            });
        //            paths.UnionWith(newChildren.Select(t => t.Item2));
        //            children = newChildren;

        //            var newParent = parent.Item1.Parent;
        //            if (newParent == null) {
        //                break;
        //            }
        //            parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.RuleId);
        //            paths.Add(parent.Item2);
        //        }
        //    }
        //    for (; i <= length; i++) {
        //        var newChildren = new List<Tuple<CstNode, string>>();
        //        foreach (var t in children) {
        //            foreach (var child in t.Item1.Elements()) {
        //                if (CanSkip(child)) {
        //                    continue;
        //                }
        //                var key = t.Item2 + ">" + child.RuleId;
        //                newChildren.Add(Tuple.Create(child, key));
        //                // for Preconditions.checkArguments()
        //                paths.Add(t.Item2 + ">'" + exp.GetToken(child));
        //            }
        //        }
        //        paths.UnionWith(newChildren.Select(t => t.Item2));
        //        children = newChildren;
        //    }
        //    return paths;
        //}

        //public static BigInteger GetFeatureVector(
        //        this CstNode node, int length, IDictionary<string, BigInteger> path2Bit,
        //        ILearningExperiment exp) {
        //    var ret = BigInteger.Zero;
        //    BigInteger bit;
        //    //if (key2Bit.TryGetValue(node.Name, out bit)) {
        //    //    ret |= bit;
        //    //}
        //    if (path2Bit.TryGetValue(node.RuleId, out bit)) {
        //        ret |= bit;
        //    }
        //    if (path2Bit.TryGetValue("'" + exp.GetToken(node), out bit)) {
        //        ret |= bit;
        //    }

        //    var children = new List<Tuple<CstNode, string>>();
        //    children.Add(Tuple.Create(node, ""));
        //    //var ancestorStr = "";
        //    //foreach (var e in node.AncestorsWithSingleChild()) {
        //    //    ancestorStr = ancestorStr + "<" + e.RuleId;
        //    //    if (key2Bit.TryGetValue(ancestorStr, out bit)) {
        //    //        ret |= bit;
        //    //    }
        //    //}
        //    var i = 1;
        //    if (!exp.IsInner) {
        //        var parent = Tuple.Create(node, "");
        //        //var descendantStr = "";
        //        //foreach (var e in node.DescendantsOfSingle()) {
        //        //    descendantStr = descendantStr + ">" + e.RuleId;
        //        //    if (key2Bit.TryGetValue(descendantStr, out bit)) {
        //        //        ret |= bit;
        //        //    }
        //        //}
        //        for (; i <= length; i++) {
        //            var newChildren = new List<Tuple<CstNode, string>>();
        //            foreach (var t in children) {
        //                foreach (var child in t.Item1.Elements()) {
        //                    var key = t.Item2 + ">" + child.RuleId;
        //                    if (path2Bit.TryGetValue(key, out bit)) {
        //                        newChildren.Add(Tuple.Create(child, key));
        //                        ret |= bit;
        //                    }
        //                    // for Preconditions.checkArguments()
        //                    if (path2Bit.TryGetValue(t.Item2 + ">'" + exp.GetToken(child), out bit)) {
        //                        ret |= bit;
        //                    }
        //                }
        //            }
        //            parent.Item1.PrevsFromSelf().Take(10)
        //                    .ForEach(
        //                            (e, index) => {
        //                                var key = parent.Item2 + "<-" + index + "-" + e.RuleId;
        //                                if (path2Bit.TryGetValue(key, out bit)) {
        //                                    newChildren.Add(Tuple.Create(e, key));
        //                                    ret |= bit;
        //                                }
        //                                if (path2Bit.TryGetValue(
        //                                        parent.Item2 + "<-" + index + "-'" + exp.GetToken(e),
        //                                        out bit)) {
        //                                    ret |= bit;
        //                                }
        //                            });
        //            parent.Item1.NextsFromSelf().Take(10)
        //                    .ForEach(
        //                            (e, index) => {
        //                                var key = parent.Item2 + ">-" + index + "-" + e.RuleId;
        //                                if (path2Bit.TryGetValue(key, out bit)) {
        //                                    newChildren.Add(Tuple.Create(e, key));
        //                                    ret |= bit;
        //                                }
        //                                if (path2Bit.TryGetValue(
        //                                        parent.Item2 + ">-" + index + "-'" + exp.GetToken(e),
        //                                        out bit)) {
        //                                    ret |= bit;
        //                                }
        //                            });
        //            children = newChildren;

        //            var newParent = parent.Item1.Parent;
        //            if (newParent == null) {
        //                break;
        //            }
        //            parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.RuleId);
        //            if (path2Bit.TryGetValue(parent.Item2, out bit)) {
        //                ret |= bit;
        //            } else {
        //                break;
        //            }
        //        }
        //    }
        //    for (; i <= length; i++) {
        //        var newChildren = new List<Tuple<CstNode, string>>();
        //        foreach (var t in children) {
        //            foreach (var child in t.Item1.Elements()) {
        //                var key = t.Item2 + ">" + child.RuleId;
        //                if (path2Bit.TryGetValue(key, out bit)) {
        //                    newChildren.Add(Tuple.Create(child, key));
        //                    ret |= bit;
        //                }
        //                // for Preconditions.checkArguments()
        //                if (path2Bit.TryGetValue(t.Item2 + ">'" + exp.GetToken(child), out bit)) {
        //                    ret |= bit;
        //                }
        //            }
        //        }
        //        children = newChildren;
        //    }
        //    return ret;
        //}

        public static HashSet<string> GetSurroundingPathsFilteringByRoots(
                this CstNode node, IList<CstNode> roots, int length, ILearningExperiment exp) {
            var paths = new HashSet<string>();
            if (!roots.IsIntersect(node.AncestorsAndSelf())) {
                return paths;
            }
            // 自分自身の位置による区別も考慮する
            //ret.Add(node.Name);
            paths.Add(node.RuleId);
            paths.Add("'" + exp.GetToken(node));

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
                var maxUp = exp.MaxUp < 0 ? length : exp.MaxUp;
                var maxLeft = exp.MaxLeft < 0 ? 10 : exp.MaxLeft;
                var maxRight = exp.MaxRight < 0 ? 10 : exp.MaxRight;
                for (; i <= maxUp; i++) {
                    var newChildren = new List<Tuple<CstNode, string>>();
                    foreach (var t in children) {
                        foreach (var child in t.Item1.Children()) {
                            if (CanSkip(child)) {
                                continue;
                            }
                            var key = t.Item2 + ">" + child.RuleId;
                            newChildren.Add(Tuple.Create(child, key));
                            // for Preconditions.checkArguments()
                            paths.Add(t.Item2 + ">'" + exp.GetToken(child));
                        }
                    }
                    var parentPathUnit = parent.Item1.Parent != null ? parent.Item1.Parent.Name : "";
                    parent.Item1.PrevsFromSelf().Take(i != maxUp ? 10 : maxLeft)
                            .ForEach(
                                    (child, index) => {
                                        if (roots.IsIntersect(child.AncestorsAndSelf())) {
                                            var key = parent.Item2 + "<" + parentPathUnit + '-'
                                                      + index
                                                      + ">" + child.RuleId;
                                            newChildren.Add(Tuple.Create(child, key));
                                            // for Preconditions.checkArguments()
                                            paths.Add(
                                                    parent.Item2 + "<" + parentPathUnit + '-'
                                                    + index
                                                    + ">'" + exp.GetToken(child));
                                        }
                                    });
                    parent.Item1.NextsFromSelf().Take(i != maxUp ? 10 : maxRight)
                            .ForEach(
                                    (child, index) => {
                                        if (roots.IsIntersect(child.AncestorsAndSelf())) {
                                            var key = parent.Item2 + "<" + parentPathUnit + '-'
                                                      + index
                                                      + ">" + child.RuleId;
                                            newChildren.Add(Tuple.Create(child, key));
                                            // for Preconditions.checkArguments()
                                            paths.Add(
                                                    parent.Item2 + "<" + parentPathUnit + '-'
                                                    + index
                                                    + ">'" + exp.GetToken(child));
                                        }
                                    });
                    paths.UnionWith(newChildren.Select(t => t.Item2));
                    children = newChildren;

                    var newParent = parent.Item1.Parent;
                    if (newParent == null || !roots.IsIntersect(newParent.AncestorsAndSelf())) {
                        break;
                    }
                    parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.RuleId);
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
                        var key = t.Item2 + ">" + child.RuleId;
                        newChildren.Add(Tuple.Create(child, key));
                        // for Preconditions.checkArguments()
                        paths.Add(t.Item2 + ">'" + exp.GetToken(child));
                    }
                }
                paths.UnionWith(newChildren.Select(t => t.Item2));
                children = newChildren;
            }
            return paths;
        }

        public static HashSet<string> GetSurroundingPaths(
                this CstNode node, int length, ILearningExperiment exp) {
            var paths = new HashSet<string>();
            // 自分自身の位置による区別も考慮する
            //ret.Add(node.Name);
            paths.Add(node.RuleId);
            paths.Add("'" + exp.GetToken(node));

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
                var maxUp = exp.MaxUp < 0 ? length : exp.MaxUp;
                var maxLeft = exp.MaxLeft < 0 ? 10 : exp.MaxLeft;
                var maxRight = exp.MaxRight < 0 ? 10 : exp.MaxRight;
                for (; i <= maxUp; i++) {
                    var newChildren = new List<Tuple<CstNode, string>>();
                    foreach (var t in children) {
                        foreach (var child in t.Item1.Children()) {
                            if (CanSkip(child)) {
                                continue;
                            }
                            var key = t.Item2 + ">" + child.RuleId;
                            newChildren.Add(Tuple.Create(child, key));
                            // for Preconditions.checkArguments()
                            paths.Add(t.Item2 + ">'" + exp.GetToken(child));
                        }
                    }
                    var parentPathUnit = parent.Item1.Parent != null ? parent.Item1.Parent.Name : "";
                    parent.Item1.PrevsFromSelf().Take(i != maxUp ? 10 : maxLeft)
                            .ForEach(
                                    (child, index) => {
                                        var key = parent.Item2 + "<" + parentPathUnit + '-' + index
                                                  + ">" + child.RuleId;
                                        newChildren.Add(Tuple.Create(child, key));
                                        // for Preconditions.checkArguments()
                                        paths.Add(
                                                parent.Item2 + "<" + parentPathUnit + '-' + index
                                                + ">'" + exp.GetToken(child));
                                    });
                    parent.Item1.NextsFromSelf().Take(i != maxUp ? 10 : maxRight)
                            .ForEach(
                                    (child, index) => {
                                        var key = parent.Item2 + "<" + parentPathUnit + '-' + index
                                                  + ">" + child.RuleId;
                                        newChildren.Add(Tuple.Create(child, key));
                                        // for Preconditions.checkArguments()
                                        paths.Add(
                                                parent.Item2 + "<" + parentPathUnit + '-' + index
                                                + ">'" + exp.GetToken(child));
                                    });
                    paths.UnionWith(newChildren.Select(t => t.Item2));
                    children = newChildren;

                    var newParent = parent.Item1.Parent;
                    if (newParent == null) {
                        break;
                    }
                    parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.RuleId);
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
                        var key = t.Item2 + ">" + child.RuleId;
                        newChildren.Add(Tuple.Create(child, key));
                        // for Preconditions.checkArguments()
                        paths.Add(t.Item2 + ">'" + exp.GetToken(child));
                    }
                }
                paths.UnionWith(newChildren.Select(t => t.Item2));
                children = newChildren;
            }
            return paths;
        }

        public static BigInteger GetFeatureVector(
                this CstNode node, int length, IDictionary<string, BigInteger> path2Bit,
                ILearningExperiment exp) {
            var ret = BigInteger.Zero;
            BigInteger bit;
            //if (key2Bit.TryGetValue(node.Name, out bit)) {
            //    ret |= bit;
            //}
            if (path2Bit.TryGetValue(node.RuleId, out bit)) {
                ret |= bit;
            }
            if (path2Bit.TryGetValue("'" + exp.GetToken(node), out bit)) {
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
                var maxUp = exp.MaxUp < 0 ? length : exp.MaxUp;
                var maxLeft = exp.MaxLeft < 0 ? 10 : exp.MaxLeft;
                var maxRight = exp.MaxRight < 0 ? 10 : exp.MaxRight;
                for (; i <= maxUp; i++) {
                    var newChildren = new List<Tuple<CstNode, string>>();
                    foreach (var t in children) {
                        foreach (var child in t.Item1.Children()) {
                            var key = t.Item2 + ">" + child.RuleId;
                            if (path2Bit.TryGetValue(key, out bit)) {
                                newChildren.Add(Tuple.Create(child, key));
                                ret |= bit;
                            }
                            // for Preconditions.checkArguments()
                            if (path2Bit.TryGetValue(t.Item2 + ">'" + exp.GetToken(child), out bit)) {
                                ret |= bit;
                            }
                        }
                    }
                    var parentPathUnit = parent.Item1.Parent != null ? parent.Item1.Parent.Name : "";
                    parent.Item1.PrevsFromSelf().Take(i != maxUp ? 10 : maxLeft)
                            .ForEach(
                                    (e, index) => {
                                        var key = parent.Item2 + "<" + parentPathUnit + '-' + index
                                                  + ">" + e.RuleId;
                                        if (path2Bit.TryGetValue(key, out bit)) {
                                            newChildren.Add(Tuple.Create(e, key));
                                            ret |= bit;
                                        }
                                        if (path2Bit.TryGetValue(
                                                parent.Item2 + "<" + parentPathUnit + '-' + index
                                                + ">'" + exp.GetToken(e), out bit)) {
                                            ret |= bit;
                                        }
                                    });
                    parent.Item1.NextsFromSelf().Take(i != maxUp ? 10 : maxRight)
                            .ForEach(
                                    (e, index) => {
                                        var key = parent.Item2 + "<" + parentPathUnit + '-' + index
                                                  + ">" + e.RuleId;
                                        if (path2Bit.TryGetValue(key, out bit)) {
                                            newChildren.Add(Tuple.Create(e, key));
                                            ret |= bit;
                                        }
                                        if (path2Bit.TryGetValue(
                                                parent.Item2 + "<" + parentPathUnit + '-' + index
                                                + ">'" + exp.GetToken(e), out bit)) {
                                            ret |= bit;
                                        }
                                    });
                    children = newChildren;

                    var newParent = parent.Item1.Parent;
                    if (newParent == null) {
                        break;
                    }
                    parent = Tuple.Create(newParent, parent.Item2 + "<" + newParent.RuleId);
                    if (path2Bit.TryGetValue(parent.Item2, out bit)) {
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
                        var key = t.Item2 + ">" + child.RuleId;
                        if (path2Bit.TryGetValue(key, out bit)) {
                            newChildren.Add(Tuple.Create(child, key));
                            ret |= bit;
                        }
                        // for Preconditions.checkArguments()
                        if (path2Bit.TryGetValue(t.Item2 + ">'" + exp.GetToken(child), out bit)) {
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