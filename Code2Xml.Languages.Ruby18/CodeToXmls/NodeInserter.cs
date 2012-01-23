#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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
using System.Xml.Linq;
using Paraiba.Collections.Generic;
using Paraiba.Utility;
using Paraiba.Xml.Linq;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
    public static class NodeInserter {
        public static void InsertBefore(XElement node, XElement newNode) {
            node.AddBeforeSelf(newNode);
        }

        public static void InsertBefore(
                XElement node,
                Func<XElement, XElement> createNodeFunc) {
            node.AddBeforeSelf(createNodeFunc(node));
        }

        public static void InsertBefore(
                IEnumerable<XElement> nodes,
                Func<XElement, XElement> createNodeFunc) {
            InsertBefore(nodes.ToList(), createNodeFunc);
        }

        public static void InsertBefore(
                IList<XElement> nodeList,
                Func<XElement, XElement> createNodeFunc) {
            foreach (var node in nodeList) {
                InsertBefore(node, createNodeFunc);
            }
        }

        public static void InsertAfter(
                XElement node,
                Func<XElement, XElement> createNodeFunc) {
            node.AddAfterSelf(createNodeFunc(node));
        }

        public static void InsertAfter(
                IEnumerable<XElement> nodes,
                Func<XElement, XElement> createNodeFunc) {
            InsertAfter(nodes.ToList(), createNodeFunc);
        }

        public static void InsertAfter(
                IList<XElement> nodeList,
                Func<XElement, XElement> createNodeFunc) {
            foreach (var node in nodeList) {
                InsertAfter(node, createNodeFunc);
            }
        }

        public static void Replace(
                XElement node,
                Func<XElement, XElement> createNodeFunc) {
            node.AddAfterSelf(createNodeFunc(node));
            node.Remove();
        }

        public static void Replace(
                IEnumerable<XElement> nodes,
                Func<XElement, XElement> createNodeFunc) {
            Replace(nodes.ToList(), createNodeFunc);
        }

        public static void Replace(
                IList<XElement> nodeList,
                Func<XElement, XElement> createNodeFunc) {
            foreach (var node in nodeList) {
                Replace(node, createNodeFunc);
            }
        }

        public static void ReplaceSafely(
                IEnumerable<XElement> nodes,
                Func<XElement, XElement> createNodeFunc) {
            var sortedDict = GetElementListsOrderedByDepth(nodes);

            foreach (var list in sortedDict.Values) {
                foreach (var node in list) {
                    Replace(node, createNodeFunc);
                }
            }
        }

        private static SortedDictionary<int, List<XElement>>
                GetElementListsOrderedByDepth(IEnumerable<XElement> nodes) {
            var cmp = Make.Comparer<int>((v1, v2) => v2 - v1);
            var sortedDict = new SortedDictionary<int, List<XElement>>(cmp);
            foreach (var element in nodes) {
                var depth = element.Depth();
                var list = sortedDict.GetValueOrDefault(depth);
                if (list == null) {
                    list = new List<XElement>();
                    sortedDict.Add(depth, list);
                }
                list.Add(element);
            }
            return sortedDict;
        }
    }
}