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
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code2Xml.Core.Location;
using Code2Xml.Core.Serialization;
using Paraiba.Linq;

namespace Code2Xml.Core.SyntaxTree {
    public class CstNode : SyntaxTreeNode<CstNode, CstToken> {
        public string RuleId { get; set; }

        /// <summary>
        /// The hidden tokens which exist before the token.
        /// </summary>
        public List<CstToken> Hiddens { get; private set; }

        // TODO: Maybe unneeded
        public string NameWithId {
            get { return Name + RuleId; }
        }

        public string Code {
            get {
                var builder = new StringBuilder();
                GenerateCode(this, builder);
                return builder.ToString();
            }
        }

        public string CodeWithoutInserted {
            get {
                var builder = new StringBuilder();
                GenerateCodeWithoutInserted(this, builder);
                return builder.ToString();
            }
        }

        public string TokenText {
            get {
                var builder = new StringBuilder();
                GenerateCodeWithoutInsertedAndHiddens(this, builder);
                return builder.ToString();
            }
        }

        public string Replacement { get; set; }

        public IEnumerable<CstToken> TokenWithHiddens() {
            return Hiddens.Concat(Value);
        }

        public IEnumerable<CstToken> AllTokensWithHiddens() {
            return AllTokenNodes().SelectMany(n => n.TokenWithHiddens());
        }

        public IEnumerable<CstToken> AllTokensWithHiddens(string name) {
            return AllTokensWithHiddens().Where(n => n.Name == name);
        }

        public IEnumerable<CstToken> AllHiddens() {
            return AllTokenNodes().SelectMany(n => n.Hiddens);
        }

        public IEnumerable<CstToken> AllHiddens(string name) {
            return AllHiddens().Where(n => n.Name == name);
        }

        public CstNode(string name) : this(name, Code2XmlConstants.DefaultRuleId) {}

        public CstNode(string name, string ruleId) {
            Contract.Requires(name != null);
            Contract.Requires(ruleId != null);
            Name = name;
            RuleId = ruleId;
            Value = null;
            Hiddens = null;
        }

        public CstNode(CstToken token) : this(token, new List<CstToken>()) {}

        public CstNode(CstToken token, List<CstToken> hiddens) {
            Contract.Requires(token != null);
            Contract.Requires(hiddens != null);
            Name = token.Name;
            Value = token;
            Hiddens = hiddens;
            RuleId = token.RuleId;
        }

        public IList<CstToken> PreviousHiddens() {
            foreach (var tokenNode in AllTokenNodes()) {
                return tokenNode.Hiddens;
            }
            return new CstToken[0];
        }

        public IList<CstToken> NextHiddens() {
            foreach (var tokenNode in AncestorsAndSiblingsAfterSelf()) {
                return tokenNode.Hiddens;
            }
            return new CstToken[0];
        }

        internal static void GenerateCode(CstNode node, StringBuilder builder) {
            if (node.Replacement == null) {
                if (node.Value != null) {
                    foreach (var token in node.Hiddens) {
                        builder.Append(token.BeforeInsertedText);
                        builder.Append(token.Text);
                        builder.Append(token.AfterInsertedText);
                    }
                    {
                        var token = node.Value;
                        builder.Append(token.BeforeInsertedText);
                        builder.Append(token.Text);
                        builder.Append(token.AfterInsertedText);
                    }
                } else {
                    foreach (var child in node.Children()) {
                        GenerateCode(child, builder);
                    }
                }
            } else {
                var tokenNode = node.AllTokenNodes().First();
                if (tokenNode != null) {
                    foreach (var token in tokenNode.Hiddens) {
                        builder.Append(token.BeforeInsertedText);
                        builder.Append(token.Text);
                        builder.Append(token.AfterInsertedText);
                    }
                }
                builder.Append(node.Replacement);
            }
        }

        internal static void GenerateCodeWithoutInserted(CstNode node, StringBuilder builder) {
            if (node.Value != null) {
                foreach (var token in node.Hiddens) {
                    builder.Append(token.Text);
                }
                builder.Append(node.Value.Text);
            } else {
                foreach (var child in node.Children()) {
                    GenerateCodeWithoutInserted(child, builder);
                }
            }
        }

        internal static void GenerateCodeWithoutInsertedAndHiddens(
                CstNode node, StringBuilder builder) {
            if (node.Value != null) {
                builder.Append(node.Value.Text);
            } else {
                foreach (var child in node.Children()) {
                    GenerateCodeWithoutInsertedAndHiddens(child, builder);
                }
            }
        }

        #region Insertion

        public void InsertCodeBeforeSelf(string code) {
            var token = AllTokens().First();
            token.BeforeInsertedText = token.BeforeInsertedText + code;
        }

        public void InsertCodeAfterSelf(string code) {
            var token = AllTokens().Last();
            token.AfterInsertedText = code + token.AfterInsertedText;
        }

        public void WrapCode(string code) {
            var firstAndLast = AllTokens().FirstAndLast();
            var beforeToken = firstAndLast.Item1;
            var afterToken = firstAndLast.Item2;
            beforeToken.BeforeInsertedText = beforeToken.BeforeInsertedText + code;
            afterToken.AfterInsertedText = code + afterToken.AfterInsertedText;
        }

        #endregion

        #region Inter-conversion between AstNode and XElement

        public override XElement ToXml() {
            var element = new XElement(Name);
            element.SetAttributeValue(Code2XmlConstants.IdAttributeName, RuleId);
            if (Value == null) {
                foreach (var child in Children()) {
                    element.Add(child.ToXml());
                }
            } else {
                foreach (var token in Hiddens) {
                    element.Add(token.ToXmlFromHiddenToken());
                }
                element.Add(Value.ToXml());
            }
            return element;
        }

        public static CstNode FromXml(XElement element) {
            if (!element.IsTokenSet()) {
                var node = new CstNode(
                        element.Name.LocalName,
                        element.Attribute(Code2XmlConstants.IdAttributeName).Value);
                foreach (var child in element.Elements()) {
                    node.AddLast(FromXml(child));
                }
                return node;
            } else {
                var es = element.Elements().ToList();
                var node = new CstNode(CstToken.FromXml(es[es.Count - 1]));
                for (int i = 0; i < es.Count - 1; i++) {
                    node.Hiddens.Add(CstToken.FromXml(es[i]));
                }
                return node;
            }
        }

        #endregion

        #region Serialization / Deserialization

        public void Serialize(Serializer serializer) {
            new CstSerializer(serializer).Serialize(this);
        }

        public void Serialize(TextWriter writer) {
            Serialize(new TextSerializer(writer));
        }

        public void Serialize(FileInfo fileInfo, Encoding encoding = null) {
            using (var stream = fileInfo.OpenWrite()) {
                Serialize(stream, encoding);
            }
        }

        public void Serialize(Stream stream, Encoding encoding = null) {
            using (var writer = new StreamWriter(stream, encoding ?? Encoding.UTF8)) {
                Serialize(writer);
            }
        }

        public void Serialize(BinaryWriter writer) {
            Serialize(new BinarySerializer(writer));
        }

        public static CstNode Deserialize(Deserializer deserializer) {
            SerializationType type;
            if (!Enum.TryParse(deserializer.DeserializeString(), out type)) {
                return null;
            }
            CstDeserializerWithAll cstDeserializer;
            switch (type) {
            case SerializationType.WithAll:
                cstDeserializer = new CstDeserializerWithAll(deserializer);
                break;
            case SerializationType.WithRuleId:
                cstDeserializer = new CstDeserializerWithRuleId(deserializer);
                break;
            default:
                throw new ArgumentOutOfRangeException();
            }
            return cstDeserializer.DeserializeNode();
        }

        public static CstNode Deserialize(TextReader reader) {
            return Deserialize(new TextDeserializer(reader));
        }

        public static CstNode Deserialize(FileInfo fileInfo, Encoding encoding = null) {
            using (var stream = fileInfo.OpenRead()) {
                return Deserialize(stream, encoding);
            }
        }

        public static CstNode Deserialize(Stream stream, Encoding encoding = null) {
            using (var reader = new StreamReader(stream, encoding ?? Encoding.UTF8)) {
                return Deserialize(reader);
            }
        }

        public static CstNode Deserialize(BinaryReader reader) {
            return Deserialize(new BinaryDeserializer(reader));
        }

        #endregion

        public override string ToString() {
            return Name + ": " + Code;
        }

        private class CstSerializer {
            private readonly Serializer _serializer;

            internal CstSerializer(Serializer serializer) {
                _serializer = serializer;
                serializer.Serialize(SerializationType.WithAll.ToString());
            }

            internal void Serialize(CstNode node) {
                if (!node.HasToken) {
                    _serializer.Serialize(true);
                    _serializer.Serialize(node.Name);
                    _serializer.Serialize(node.RuleId);
                    foreach (var child in node.Children()) {
                        _serializer.Serialize(true);
                        Serialize(child);
                    }
                    _serializer.Serialize(false);
                } else {
                    _serializer.Serialize(false);
                    Serialize(node.Value);
                    _serializer.Serialize(node.Hiddens.Count);
                    foreach (var hiddenToken in node.Hiddens) {
                        Serialize(hiddenToken);
                    }
                }
            }

            private void Serialize(CstToken token) {
                _serializer.Serialize(token.Name);
                _serializer.Serialize(token.RuleId);
                _serializer.Serialize(token.Text);
                _serializer.Serialize(token.BeforeInsertedText);
                _serializer.Serialize(token.AfterInsertedText);
                token.Range.Serialize(_serializer);
            }
        }

        protected class CstDeserializerWithAll {
            protected readonly Deserializer Deserializer;

            internal CstDeserializerWithAll(Deserializer deserializer) {
                Deserializer = deserializer;
            }

            public CstNode DeserializeNode() {
                return Deserializer.DeserializeBoolean()
                        ? DeserializeInnerNode() : DeserializeTerminalNode();
            }

            protected virtual CstNode DeserializeTerminalNode() {
                var token = DeserializeToken();
                var count = Deserializer.DeserializeInt();
                var hiddenTokens = new List<CstToken>(count);
                for (int i = 0; i < count; i++) {
                    hiddenTokens.Add(DeserializeToken());
                }
                return new CstNode(token, hiddenTokens);
            }

            protected virtual CstNode DeserializeInnerNode() {
                var name = Deserializer.DeserializeString();
                var ruleId = Deserializer.DeserializeString();
                var node = new CstNode(name, ruleId);
                while (Deserializer.DeserializeBoolean()) {
                    node.AddLast(DeserializeNode());
                }
                return node;
            }

            protected virtual CstToken DeserializeToken() {
                var name = Deserializer.DeserializeString();
                var ruleId = Deserializer.DeserializeString();
                var text = Deserializer.DeserializeString();
                var beforeInsertedText = Deserializer.DeserializeString();
                var afterInsertedText = Deserializer.DeserializeString();
                var range = CodeRange.Desrialize(Deserializer);
                return new CstToken(
                        name, text, beforeInsertedText, afterInsertedText, ruleId, range);
            }
        }

        protected class CstDeserializerWithRuleId : CstDeserializerWithAll {
            internal CstDeserializerWithRuleId(Deserializer deserializer) : base(deserializer) {}

            protected override CstNode DeserializeTerminalNode() {
                var token = DeserializeToken();
                return new CstNode(token);
            }

            protected override CstToken DeserializeToken() {
                var name = Deserializer.DeserializeString();
                var ruleId = Deserializer.DeserializeString();
                var text = Deserializer.DeserializeString();
                return new CstToken(name, text, "", "", ruleId, CodeRange.Nil);
            }
        }
    }
}