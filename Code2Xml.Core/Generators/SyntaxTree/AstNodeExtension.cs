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
    public static class AstNodeExtension {
        #region AstNode

        public static AstNode ToAst(this XElement e) {
            return AstNode.FromXml(e);
        }

        public static IEnumerable<AstNode> AllTokenNodes(this IEnumerable<AstNode> self) {
            return self.DescendantsAndSelf().Where(n => n.HasToken);
        }

        public static IEnumerable<AstNode> AllTokenNodes(
                this IEnumerable<AstNode> self, string name) {
            return self.AllTokenNodes().Where(n => n.Name == name);
        }

        public static IEnumerable<AstToken> AllTokens(this IEnumerable<AstNode> self) {
            return self.SelectMany(n => n.AllTokens());
        }

        public static IEnumerable<AstToken> AllTokens(this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(n => n.AllTokens(name));
        }

        #endregion

        #region Node

        public static IEnumerable<AstNode> Ancestors(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.Ancestors());
        }

        public static IEnumerable<AstNode> AncestorsAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSelf());
        }

        public static IEnumerable<AstNode> Children(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.Children());
        }

        public static IEnumerable<AstNode> NextsFromSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.NextsFromSelf());
        }

        public static IEnumerable<AstNode> NextsFromSelfAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.NextsFromSelfAndSelf());
        }

        public static IEnumerable<AstNode> NextsFromLast(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.NextsFromLast());
        }

        public static IEnumerable<AstNode> NextsFromLastAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.NextsFromLastAndSelf());
        }

        public static IEnumerable<AstNode> PrevsFromFirst(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.PrevsFromFirst());
        }

        public static IEnumerable<AstNode> PrevsFromFirstAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.PrevsFromFirstAndSelf());
        }

        public static IEnumerable<AstNode> PrevsFromSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.PrevsFromSelf());
        }

        public static IEnumerable<AstNode> PrevsFromSelfAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.PrevsFromSelfAndSelf());
        }

        public static IEnumerable<AstNode> Descendants(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.Descendants());
        }

        public static IEnumerable<AstNode> DescendantsAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.DescendantsAndSelf());
        }

        public static IEnumerable<AstNode> Siblings(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.Siblings());
        }

        public static IEnumerable<AstNode> SiblingsAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.SiblingsAndSelf());
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsAfterSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelf());
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsAfterSelfAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelfAndSelf());
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsBeforeSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelf());
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsBeforeSelfAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelfAndSelf());
        }

        public static IEnumerable<AstNode> AncestorsWithSingleChild(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.AncestorsWithSingleChild());
        }

        public static IEnumerable<AstNode> AncestorsWithSingleChildAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.AncestorsWithSingleChildAndSelf());
        }

        public static IEnumerable<AstNode> DescendantsOfSingle(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.DescendantsOfSingle());
        }

        public static IEnumerable<AstNode> DescendantsOfSingleAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.DescendantsOfSingleAndSelf());
        }

        public static IEnumerable<AstNode> DescendantsOfFirstChild(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.DescendantsOfFirstChild());
        }

        public static IEnumerable<AstNode> DescendantsOfFirstChildAndSelf(
                this IEnumerable<AstNode> self) {
            return self.SelectMany(node => node.DescendantsOfFirstChildAndSelf());
        }

        public static IEnumerable<AstNode> Ancestors(
                this IEnumerable<AstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.Ancestors(inclusiveDepth));
        }

        public static IEnumerable<AstNode> AncestorsAndSelf(
                this IEnumerable<AstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.AncestorsAndSelf(inclusiveDepth));
        }

        public static IEnumerable<AstNode> Descendants(
                this IEnumerable<AstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.Descendants(inclusiveDepth));
        }

        public static IEnumerable<AstNode> DescendantsAndSelf(
                this IEnumerable<AstNode> self, int inclusiveDepth) {
            return self.SelectMany(node => node.DescendantsAndSelf(inclusiveDepth));
        }

        public static IEnumerable<AstNode> Siblings(
                this IEnumerable<AstNode> self, int inclusiveEachLength) {
            return self.SelectMany(node => node.Siblings(inclusiveEachLength));
        }

        public static IEnumerable<AstNode> SiblingsAndSelf(
                this IEnumerable<AstNode> self, int inclusiveEachLength) {
            return self.SelectMany(node => node.SiblingsAndSelf(inclusiveEachLength));
        }

        #endregion

        #region NamedNode

        public static IEnumerable<AstNode> Ancestors(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.Ancestors(name));
        }

        public static IEnumerable<AstNode> AncestorsAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSelf(name));
        }

        public static IEnumerable<AstNode> Children(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.Children(name));
        }

        public static IEnumerable<AstNode> NextsFromSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromSelf(name));
        }

        public static IEnumerable<AstNode> NextsFromSelfAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromSelfAndSelf(name));
        }

        public static IEnumerable<AstNode> NextsFromLast(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromLast(name));
        }

        public static IEnumerable<AstNode> NextsFromLastAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.NextsFromLastAndSelf(name));
        }

        public static IEnumerable<AstNode> PrevsFromFirst(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromFirst(name));
        }

        public static IEnumerable<AstNode> PrevsFromFirstAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromFirstAndSelf(name));
        }

        public static IEnumerable<AstNode> PrevsFromSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromSelf(name));
        }

        public static IEnumerable<AstNode> PrevsFromSelfAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.PrevsFromSelfAndSelf(name));
        }

        public static IEnumerable<AstNode> Descendants(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.Descendants(name));
        }

        public static IEnumerable<AstNode> DescendantsAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsAndSelf(name));
        }

        public static IEnumerable<AstNode> Siblings(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.Siblings(name));
        }

        public static IEnumerable<AstNode> SiblingsAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.SiblingsAndSelf(name));
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsAfterSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelf(name));
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsAfterSelfAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsAfterSelfAndSelf(name));
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsBeforeSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelf(name));
        }

        public static IEnumerable<AstNode> AncestorsAndSiblingsBeforeSelfAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsAndSiblingsBeforeSelfAndSelf(name));
        }

        public static IEnumerable<AstNode> AncestorsWithSingleChild(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsWithSingleChild(name));
        }

        public static IEnumerable<AstNode> AncestorsWithSingleChildAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.AncestorsWithSingleChildAndSelf(name));
        }

        public static IEnumerable<AstNode> DescendantsOfSingle(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfSingle(name));
        }

        public static IEnumerable<AstNode> DescendantsOfSingleAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfSingleAndSelf(name));
        }

        public static IEnumerable<AstNode> DescendantsOfFirstChild(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfFirstChild(name));
        }

        public static IEnumerable<AstNode> DescendantsOfFirstChildAndSelf(
                this IEnumerable<AstNode> self, string name) {
            return self.SelectMany(node => node.DescendantsOfFirstChildAndSelf(name));
        }

        public static IEnumerable<AstNode> Ancestors(
                this IEnumerable<AstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.Ancestors(name, inclusiveDepth));
        }

        public static IEnumerable<AstNode> AncestorsAndSelf(
                this IEnumerable<AstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.AncestorsAndSelf(name, inclusiveDepth));
        }

        public static IEnumerable<AstNode> Descendants(
                this IEnumerable<AstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.Descendants(name, inclusiveDepth));
        }

        public static IEnumerable<AstNode> DescendantsAndSelf(
                this IEnumerable<AstNode> self, string name, int inclusiveDepth) {
            return self.SelectMany(node => node.DescendantsAndSelf(name, inclusiveDepth));
        }

        public static IEnumerable<AstNode> Siblings(
                this IEnumerable<AstNode> self, string name, int inclusiveEachLength) {
            return self.SelectMany(node => node.Siblings(name, inclusiveEachLength));
        }

        public static IEnumerable<AstNode> SiblingsAndSelf(
                this IEnumerable<AstNode> self, string name, int inclusiveEachLength) {
            return self.SelectMany(node => node.SiblingsAndSelf(name, inclusiveEachLength));
        }

        #endregion
    }
}