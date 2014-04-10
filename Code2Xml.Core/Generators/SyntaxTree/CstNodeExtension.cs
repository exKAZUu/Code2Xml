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

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Code2Xml.Core.Generators {
    public static class CstNodeExtension {
        #region CstNode

        public static CstNode ToCst(this XElement e) {
            return CstNode.FromXml(e);
        }

        public static IEnumerable<CstNode> AllTokenNodes(this IEnumerable<CstNode> self) {
            return self.DescendantsAndSelf().Where(n => n.HasToken);
        }

        public static IEnumerable<CstNode> AllTokenNodes(
                this IEnumerable<CstNode> self, string name) {
            return self.AllTokenNodes().Where(n => n.Name == name);
        }

        public static IEnumerable<CstToken> AllTokens(this IEnumerable<CstNode> self) {
            return self.SelectMany(n => n.AllTokens());
        }

        public static IEnumerable<CstToken> AllTokens(this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(n => n.AllTokens(name));
        }

        public static IEnumerable<CstToken> AllTokensWithHiddens(this IEnumerable<CstNode> self) {
            return self.SelectMany(n => n.AllTokensWithHiddens());
        }

        public static IEnumerable<CstToken> AllTokensWithHiddens(
                this IEnumerable<CstNode> self,
                string name) {
            return self.SelectMany(n => n.AllTokensWithHiddens(name));
        }

        public static IEnumerable<CstToken> AllHiddens(this IEnumerable<CstNode> self) {
            return self.SelectMany(n => n.AllHiddens());
        }

        public static IEnumerable<CstToken> AllHiddens(this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(n => n.AllHiddens(name));
        }

        #endregion

        #region Safe Traversal

        public static string SafeName(this CstNode self) {
            return self != null ? self.Name : null;
        }

        public static CstNode SafeParent(this CstNode self) {
            return self != null ? self.Parent : null;
        }

        public static string SafeTokenText(this CstNode self) {
            return self != null ? self.TokenText : null;
        }

        #endregion

        #region Node

        public static IEnumerable<CstNode> Ancestors(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.Ancestors());
        }

        public static IEnumerable<CstNode> AncestorsAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSelf());
        }

        public static IEnumerable<CstNode> Children(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.Children());
        }

        public static IEnumerable<CstNode> ChildrenAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.ChildrenAndSelf());
        }

        public static IEnumerable<CstNode> NextsFromSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.NextsFromSelf());
        }

        public static IEnumerable<CstNode> NextsFromSelfAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.NextsFromSelfAndSelf());
        }

        public static IEnumerable<CstNode> NextsFromLast(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.NextsFromLast());
        }

        public static IEnumerable<CstNode> NextsFromLastAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.NextsFromLastAndSelf());
        }

        public static IEnumerable<CstNode> PrevsFromFirst(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.PrevsFromFirst());
        }

        public static IEnumerable<CstNode> PrevsFromFirstAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.PrevsFromFirstAndSelf());
        }

        public static IEnumerable<CstNode> PrevsFromSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.PrevsFromSelf());
        }

        public static IEnumerable<CstNode> PrevsFromSelfAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.PrevsFromSelfAndSelf());
        }

        public static IEnumerable<CstNode> Descendants(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.Descendants());
        }

        public static IEnumerable<CstNode> DescendantsAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.DescendantsAndSelf());
        }

        public static IEnumerable<CstNode> Siblings(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.Siblings());
        }

        public static IEnumerable<CstNode> SiblingsAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.SiblingsAndSelf());
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsAfterSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelf());
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsAfterSelfAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelfAndSelf());
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsBeforeSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelf());
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsBeforeSelfAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelfAndSelf());
        }

        public static IEnumerable<CstNode> AncestorsWithSingleChild(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.AncestorsWithSingleChild());
        }

        public static IEnumerable<CstNode> AncestorsWithSingleChildAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.AncestorsWithSingleChildAndSelf());
        }

        public static IEnumerable<CstNode> DescendantsOfSingle(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.DescendantsOfSingle());
        }

        public static IEnumerable<CstNode> DescendantsOfSingleAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.DescendantsOfSingleAndSelf());
        }

        public static IEnumerable<CstNode> DescendantsOfFirstChild(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.DescendantsOfFirstChild());
        }

        public static IEnumerable<CstNode> DescendantsOfFirstChildAndSelf(
                this IEnumerable<CstNode> self) {
            return self.SelectMany(node => node.DescendantsOfFirstChildAndSelf());
        }

        public static IEnumerable<CstNode> Ancestors(
                this IEnumerable<CstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.Ancestors(inclusiveDepth));
        }

        public static IEnumerable<CstNode> AncestorsAndSelf(
                this IEnumerable<CstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.AncestorsAndSelf(inclusiveDepth));
        }

        public static IEnumerable<CstNode> Descendants(
                this IEnumerable<CstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.Descendants(inclusiveDepth));
        }

        public static IEnumerable<CstNode> DescendantsAndSelf(
                this IEnumerable<CstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.DescendantsAndSelf(inclusiveDepth));
        }

        public static IEnumerable<CstNode> Siblings(
                this IEnumerable<CstNode> self, int inclusiveEachLength) {
            return self.SelectMany(node => node.Siblings(inclusiveEachLength));
        }

        public static IEnumerable<CstNode> SiblingsAndSelf(
                this IEnumerable<CstNode> self, int inclusiveEachLength) {
            return self.SelectMany(node => node.SiblingsAndSelf(inclusiveEachLength));
        }

        #endregion

        #region NamedNode

        public static IEnumerable<CstNode> Ancestors(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.Ancestors(name));
        }

        public static IEnumerable<CstNode> AncestorsAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSelf(name));
        }

        public static IEnumerable<CstNode> Children(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.Children(name));
        }

        public static IEnumerable<CstNode> ChildrenAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.ChildrenAndSelf(name));
        }

        public static IEnumerable<CstNode> NextsFromSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromSelf(name));
        }

        public static IEnumerable<CstNode> NextsFromSelfAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromSelfAndSelf(name));
        }

        public static IEnumerable<CstNode> NextsFromLast(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromLast(name));
        }

        public static IEnumerable<CstNode> NextsFromLastAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromLastAndSelf(name));
        }

        public static IEnumerable<CstNode> PrevsFromFirst(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromFirst(name));
        }

        public static IEnumerable<CstNode> PrevsFromFirstAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromFirstAndSelf(name));
        }

        public static IEnumerable<CstNode> PrevsFromSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromSelf(name));
        }

        public static IEnumerable<CstNode> PrevsFromSelfAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromSelfAndSelf(name));
        }

        public static IEnumerable<CstNode> Descendants(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.Descendants(name));
        }

        public static IEnumerable<CstNode> DescendantsAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsAndSelf(name));
        }

        public static IEnumerable<CstNode> Siblings(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.Siblings(name));
        }

        public static IEnumerable<CstNode> SiblingsAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.SiblingsAndSelf(name));
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsAfterSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelf(name));
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsAfterSelfAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelfAndSelf(name));
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsBeforeSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelf(name));
        }

        public static IEnumerable<CstNode> AncestorsAndSiblingsBeforeSelfAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelfAndSelf(name));
        }

        public static IEnumerable<CstNode> AncestorsWithSingleChild(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsWithSingleChild(name));
        }

        public static IEnumerable<CstNode> AncestorsWithSingleChildAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsWithSingleChildAndSelf(name));
        }

        public static IEnumerable<CstNode> DescendantsOfSingle(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfSingle(name));
        }

        public static IEnumerable<CstNode> DescendantsOfSingleAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfSingleAndSelf(name));
        }

        public static IEnumerable<CstNode> DescendantsOfFirstChild(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfFirstChild(name));
        }

        public static IEnumerable<CstNode> DescendantsOfFirstChildAndSelf(
                this IEnumerable<CstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfFirstChildAndSelf(name));
        }

        public static IEnumerable<CstNode> Ancestors(
                this IEnumerable<CstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.Ancestors(name, inclusiveDepth));
        }

        public static IEnumerable<CstNode> AncestorsAndSelf(
                this IEnumerable<CstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.AncestorsAndSelf(name, inclusiveDepth));
        }

        public static IEnumerable<CstNode> Descendants(
                this IEnumerable<CstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.Descendants(name, inclusiveDepth));
        }

        public static IEnumerable<CstNode> DescendantsAndSelf(
                this IEnumerable<CstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.DescendantsAndSelf(name, inclusiveDepth));
        }

        public static IEnumerable<CstNode> Siblings(
                this IEnumerable<CstNode> self, string name, int inclusiveEachLength) {
            return self.SelectMany(node => node.Siblings(name, inclusiveEachLength));
        }

        public static IEnumerable<CstNode> SiblingsAndSelf(
                this IEnumerable<CstNode> self, string name, int inclusiveEachLength) {
            return self.SelectMany(node => node.SiblingsAndSelf(name, inclusiveEachLength));
        }

        #endregion
    }
}