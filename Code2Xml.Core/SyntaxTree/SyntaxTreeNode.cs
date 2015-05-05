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

namespace Code2Xml.Core.SyntaxTree {
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

        public IEnumerable<TToken> PreviousTokens() {
            var node = Parent;
            while (node != null) {
                foreach (var token in node.PrevsFromSelf().SelectMany(n => n.AllTokens().Reverse())) {
                    yield return token;
                }
                node = node.Parent;
            }
        }

        public IEnumerable<TToken> NextTokens() {
            var node = Parent;
            while (node != null) {
                foreach (var token in node.NextsFromSelf().SelectMany(n => n.AllTokens())) {
                    yield return token;
                }
                node = node.Parent;
            }
        }

        public IEnumerable<TNode> PreviousTokenNodes() {
            var node = Parent;
            while (node != null) {
                var tokenNodes = node.PrevsFromSelf().SelectMany(n => n.AllTokenNodes().Reverse());
                foreach (var tokenNode in tokenNodes) {
                    yield return tokenNode;
                }
                node = node.Parent;
            }
        }

        public IEnumerable<TNode> NextTokenNodes() {
            var node = Parent;
            while (node != null) {
                var tokenNodes = node.NextsFromSelf().SelectMany(n => n.AllTokenNodes());
                foreach (var tokenNode in tokenNodes) {
                    yield return tokenNode;
                }
                node = node.Parent;
            }
        }

        public IEnumerable<TNode> PreviousTokenNodes(TNode outermostNode) {
            var node = Parent;
            while (node != null) {
                var tokenNodes = node.PrevsFromSelf().SelectMany(n => n.AllTokenNodes().Reverse());
                foreach (var tokenNode in tokenNodes) {
                    yield return tokenNode;
                }
                if (node == outermostNode) {
                    break;
                }
                node = node.Parent;
            }
        }

        public IEnumerable<TNode> NextTokenNodes(TNode outermostNode) {
            var node = Parent;
            while (node != null) {
                var tokenNodes = node.NextsFromSelf().SelectMany(n => n.AllTokenNodes());
                foreach (var tokenNode in tokenNodes) {
                    yield return tokenNode;
                }
                if (node == outermostNode) {
                    break;
                }
                node = node.Parent;
            }
        }

        public abstract XElement ToXml();
    }
}