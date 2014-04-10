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

using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Code2Xml.Core.Serialization;

namespace Code2Xml.Core.Generators {
    public class AstNode : SyntaxTreeNode<AstNode, AstToken> {
        public AstNode(string name) {
            Contract.Requires(name != null);
            Name = name;
            Token = null;
        }

        public AstNode(AstToken token) {
            Contract.Requires(token != null);
            Name = token.Name;
            Token = token;
        }

        #region Inter-conversion between AstNode and XElement

        public override XElement ToXml() {
            if (Token == null) {
                var element = new XElement(Name);
                foreach (var child in Children()) {
                    element.Add(child.ToXml());
                }
                return element;
            }
            return Token.ToXml();
        }

        public static AstNode FromXml(XElement element) {
            if (element.HasElements) {
                var node = new AstNode(element.Name.LocalName);
                foreach (var child in element.Elements()) {
                    node.AddLast(FromXml(child));
                }
                return node;
            }
            return new AstNode(AstToken.FromXml(element));
        }

        #endregion

        #region Serialization / Deserialization

        public void Serialize(StreamWriter writer) {
            Serialize(new TextSerializer(writer));
        }

        public void Serialize(FileInfo fileInfo, Encoding encoding = null) {
            using (var stream = fileInfo.OpenRead()) {
                Serialize(stream, encoding);
            }
        }

        public void Serialize(Stream stream, Encoding encoding = null) {
            using (var writer = new StreamWriter(stream, encoding ?? Encoding.UTF8)) {
                Serialize(writer);
            }
        }

        public void Serialize(TextSerializer serializer) {
            if (Token == null) {
                serializer.Serialize(true);
                serializer.Serialize(Name);
                foreach (var child in Children()) {
                    serializer.Serialize(true);
                    child.Serialize(serializer);
                }
                serializer.Serialize(false);
            } else {
                serializer.Serialize(false);
                Token.Serialize(serializer);
            }
        }

        public static AstNode Deserialize(StreamReader reader) {
            return Deserialize(new TextDeserializer(reader));
        }

        public static AstNode Deserialize(FileInfo fileInfo, Encoding encoding = null) {
            using (var stream = fileInfo.OpenRead()) {
                return Deserialize(stream, encoding);
            }
        }

        public static AstNode Deserialize(Stream stream, Encoding encoding = null) {
            using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8)) {
                return Deserialize(reader);
            }
        }

        public static AstNode Deserialize(TextDeserializer deserializer) {
            if (deserializer.DeserializeBoolean()) {
                var name = deserializer.DeserializeString();
                var node = new AstNode(name);
                while (deserializer.DeserializeBoolean()) {
                    node.AddLast(Deserialize(deserializer));
                }
                return node;
            } else {
                return new AstNode(AstToken.Deserialize(deserializer));
            }
        }

        #endregion

        public override string ToString() {
            return ToXml().ToString();
        }
    }
}