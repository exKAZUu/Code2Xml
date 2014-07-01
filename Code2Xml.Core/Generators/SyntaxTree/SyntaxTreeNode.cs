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
using TreeDotNet;

namespace Code2Xml.Core.Generators {
    public interface ISyntaxTreeNode {
        XElement ToXml();
    }

    public abstract class SyntaxTreeNode<TNode, TToken> : NamedNode<TNode, TToken>, ISyntaxTreeNode
            where TNode : SyntaxTreeNode<TNode, TToken>
            where TToken : SyntaxTreeToken<TToken> {
        public TToken Token {
            get { return Value; }
            set { Value = value; }
        }

        public bool HasToken {
            get { return Value != null; }
        }

        public IEnumerable<TNode> AllTokenNodes() {
            return DescendantsAndSelf().Where(n => n.HasToken);
        }

        public IEnumerable<TNode> AllTokenNodes(string name) {
            return AllTokenNodes().Where(n => n.Name == name);
        }

        public IEnumerable<TToken> AllTokens() {
            return AllTokenNodes().Select(n => n.Value);
        }

        public IEnumerable<TToken> AllTokens(string name) {
            return AllTokenNodes(name).Select(n => n.Value);
        }

        public TNode Element(string name) {
            return Child(name);
        }

        public IEnumerable<TNode> Elements() {
            return Children();
        }

        public IEnumerable<TNode> Elements(string name) {
            return Children(name);
        }

        public IEnumerable<TNode> ElementsBeforeSelf() {
            return PrevsFromFirst();
        }

        public IEnumerable<TNode> ElementsBeforeSelf(string name) {
            return PrevsFromFirst(name);
        }

        public IEnumerable<TNode> ElementsAfterSelf() {
            return NextsFromSelf();
        }

        public IEnumerable<TNode> ElementsAfterSelf(string name) {
            return NextsFromSelf(name);
        }

        public abstract XElement ToXml();
    }
}