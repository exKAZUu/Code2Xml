#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
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
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Code2Xml.Core;
using Code2Xml.Core.Processors;

namespace Code2Xml.Languages.ANTLRv4.Core {
	public class XElementBuildingListenerUsingAttribute : IParseTreeListener {
		private readonly bool _throwingParseError;
		private readonly string[] _parserRuleNames;
		private readonly XElement _dummyRoot;
		private readonly Stack<XElement> _elements;
		private readonly CommonTokenStream _stream;
		private int _lastTokenIndex;
		private XElement _lastElement;

		public XElementBuildingListenerUsingAttribute(Parser parser, bool throwingParseError) {
			_parserRuleNames = parser.RuleNames;
			_throwingParseError = throwingParseError;
			_stream = parser.InputStream as CommonTokenStream;
			_dummyRoot = new XElement("root");
			_elements = new Stack<XElement>(new[] { _dummyRoot });
			_lastElement = _dummyRoot;
			_lastTokenIndex = -1;
		}

		public XElement FinishParsing() {
			var size = _stream.Size - 1; // Avoid writing "<EOF>"
			var text = "";
			for (int i = _lastTokenIndex + 1; i < size; i++) {
				text += _stream.Get(i).Text;
			}
			_lastElement.SetAttributeValue("hidden", text);

			var root = _dummyRoot.Elements().First();
			var attr = _dummyRoot.Attribute("hidden");
			if (attr != null) {
				root.SetAttributeValue("hidden", attr.Value);
			}
			return root;
		}

		public void VisitTerminal(ITerminalNode node) {
			var symbol = node.Symbol;
			if (symbol.Type > 0) {
				//var name = _lexerRuleNames[node.Symbol.Type - 1];
				var text = "";
				var tokenIndex = symbol.TokenIndex;
				for (int i = _lastTokenIndex + 1; i < tokenIndex; i++) {
					text += _stream.Get(i).Text;
				}
				_lastElement.SetAttributeValue("hidden", text);
				_lastTokenIndex = tokenIndex;
				_lastElement = new XElement("TOKEN", symbol.Text);
				_elements.Peek().Add(_lastElement);
			}
		}

		public void VisitErrorNode(IErrorNode node) {
			if (_throwingParseError) {
				throw new ParseException(node.ToStringTree());
			}
		}

		public void EnterEveryRule(ParserRuleContext ctx) {
			var name = _parserRuleNames[ctx.GetRuleIndex()];
			var element = new XElement(name);
			_elements.Peek().Add(element);
			_elements.Push(element);
		}

		public void ExitEveryRule(ParserRuleContext ctx) {
			_elements.Pop();
		}
	}
}