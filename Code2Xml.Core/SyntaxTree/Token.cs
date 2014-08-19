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
using System.Xml.Linq;
using Code2Xml.Core.Location;

namespace Code2Xml.Core.Tree {
	public class Token {
		public string Name { get; private set; }
		public string Text { get; private set; }
		public CodeRange Range { get; private set; }
		public string RuleId { get; private set; }

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

		public Token(string name) : this(name, "", CodeRange.Nil) {}

		public Token(string name, string text) : this(name, text, CodeRange.Nil, STNode.DefaultRuleId) {}

		public Token(string name, string text, string ruleId) : this(name, text, CodeRange.Nil, ruleId) {}

		public Token(string name, string text, CodeRange range)
				: this(name, text, range, STNode.DefaultRuleId) {}

		public Token(string name, string text, CodeRange range, string ruleId) {
			Contract.Requires(name != null);
			Contract.Requires(text != null);
			Contract.Requires(ruleId != null);
			Name = name;
			Text = text;
			Range = range;
			RuleId = ruleId;
		}

		public void Serialize(TextWriter writer) {
			
		}
		
		public XElement ToXmlAsHiddenElement() {
			var element = ToXmlPrivate(Name);
			element.SetAttributeValue(Code2XmlConstants.HiddenAttributeName, Text);
			return element;
		}
		
		public XElement ToXml() {
			var element = ToXmlPrivate(Code2XmlConstants.TokenElementName);
			element.Value = Text;
			return element;
		}

		private XElement ToXmlPrivate(string name) {
			var element = new XElement(name);
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
	}
}