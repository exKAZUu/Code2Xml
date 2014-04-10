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
using System.Xml.Linq;
using Code2Xml.Core.Location;

namespace Code2Xml.Core.Generators {
    public class CstToken : SyntaxTreeToken<CstToken> {
        public CodeRange Range { get; set; }
        public string RuleId { get; private set; }
        public string BeforeInsertedText { get; set; }
        public string AfterInsertedText { get; set; }

        public int StartPosition {
            get { return Range.StartPosition; }
        }

        public int EndPosition {
            get { return Range.EndPosition; }
        }

        public int StartLine {
            get { return Range.StartLine; }
        }

        public int EndLine {
            get { return Range.EndLine; }
        }

        public CstToken(string name) : this(name, "", CodeRange.Nil) {}

        public CstToken(string name, string text)
                : this(name, text, Code2XmlConstants.DefaultRuleId, CodeRange.Nil) {}

        public CstToken(string name, string text, string ruleId)
                : this(name, text, ruleId, CodeRange.Nil) {}

        public CstToken(string name, string text, CodeRange range)
                : this(name, text, Code2XmlConstants.DefaultRuleId, range) {}

        public CstToken(string name, string text, string ruleId, CodeRange range)
                : this(name, text, "", "", ruleId, range) {}

        public CstToken(
                string name, string text, string beforeInsertedText, string afterInsertedText,
                string ruleId,
                CodeRange range) {
            Contract.Requires(name != null);
            Contract.Requires(text != null);
            Contract.Requires(beforeInsertedText != null);
            Contract.Requires(afterInsertedText != null);
            Contract.Requires(ruleId != null);
            Name = name;
            Text = text;
            BeforeInsertedText = beforeInsertedText;
            AfterInsertedText = afterInsertedText;
            Range = range;
            RuleId = ruleId;
        }

        #region Inter-conversion between AstToken and XElement

        public XElement ToXml() {
            return ToXmlPrivate(Code2XmlConstants.TokenElementName);
        }

        public XElement ToXmlFromHiddenToken() {
            var element = ToXmlPrivate(Name);
            element.SetAttributeValue(Code2XmlConstants.HiddenAttributeName, "true");
            return element;
        }

        private XElement ToXmlPrivate(string name) {
            var element = new XElement(name) { Value = Text };
            element.SetAttributeValue(Code2XmlConstants.IdAttributeName, RuleId);
            element.SetAttributeValue(
                    Code2XmlConstants.StartLineName, StartLine);
            element.SetAttributeValue(
                    Code2XmlConstants.StartPositionName, StartPosition);
            element.SetAttributeValue(
                    Code2XmlConstants.EndLineName, EndLine);
            element.SetAttributeValue(
                    Code2XmlConstants.EndPositionName, EndPosition);
            return element;
        }

        public static CstToken FromXml(XElement element) {
            return new CstToken(
                    element.Name.LocalName, element.Value,
                    element.Attribute(Code2XmlConstants.IdAttributeName).Value,
                    new CodeRange(element));
        }

        #endregion

        #region Insertion

        public void InsertCodeBeforeSelf(string code) {
            BeforeInsertedText = BeforeInsertedText + code;
        }

        public void InsertCodeAfterSelf(string code) {
            AfterInsertedText = code + AfterInsertedText;
        }

        public void WrapCode(string code) {
            BeforeInsertedText = BeforeInsertedText + code;
            AfterInsertedText = code + AfterInsertedText;
        }

        #endregion

        public override string ToString() {
            return Text;
        }
    }
}