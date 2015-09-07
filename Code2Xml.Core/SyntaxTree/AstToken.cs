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

using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Code2Xml.Core.Location;
using Code2Xml.Core.Serialization;

namespace Code2Xml.Core.SyntaxTree {
    public class AstToken : SyntaxTreeToken<AstToken> {
        public CodeRange? Range { get; set; }

        public int? StartPosition => Range?.StartPosition;
        public int? EndPosition => Range?.EndPosition;
        public int? StartLine => Range?.StartLine;
        public int? EndLine => Range?.EndLine;

        public AstToken(string name) : this(name, "") {}

        public AstToken(string name, string text) {
            Contract.Requires(name != null);
            Contract.Requires(text != null);
            Name = name;
            Text = text;
        }

        public AstToken(string name, string text, CodeRange range) {
            Contract.Requires(name != null);
            Contract.Requires(text != null);
            Name = name;
            Text = text;
            Range = range;
        }

        #region Inter-conversion between AstToken and XElement

        public XElement ToXml() {
            var element = new XElement(Name) { Value = Text };
            if (Range != null) {
                element.SetAttributeValue(
                        Code2XmlConstants.StartLineName, StartLine);
                element.SetAttributeValue(
                        Code2XmlConstants.StartPositionName, StartPosition);
                element.SetAttributeValue(
                        Code2XmlConstants.EndLineName, EndLine);
                element.SetAttributeValue(
                        Code2XmlConstants.EndPositionName, EndPosition);
            }
            return element;
        }

        public static AstToken FromXml(XElement element) {
            CodeRange range;
            if (CodeRange.TryParse(element, element, out range)) {
                return new AstToken(element.Name.LocalName, element.Value, range);
            }
            return new AstToken(element.Name.LocalName, element.Value);
        }

        #endregion

        #region Serialization / Deserialization

        public void Serialize(TextSerializer serializer) {
            serializer.Serialize(Name);
            serializer.Serialize(Text);
        }

        public static AstToken Deserialize(TextDeserializer deserializer) {
            var name = deserializer.DeserializeString();
            var text = deserializer.DeserializeString();
            return new AstToken(name, text);
        }

        #endregion

        public override string ToString() {
            return ToXml().ToString();
        }
    }
}