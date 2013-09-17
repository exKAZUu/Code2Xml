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

namespace Code2Xml.Languages.ANTLRv4.Core {
	public class XElementBuildingListenerUsingTokens : IParseTreeListener {
		private readonly string[] _lexerTokenNames;
		private readonly bool _throwingParseError;
		private readonly string[] _parserRuleNames;
		private readonly XElement _dummyRoot;
		private readonly Stack<XElement> _elements;
		private readonly CommonTokenStream _stream;
		private int _lastTokenIndex;
		private XElement _lastElement;
		private XElement _dummyNode;

		public XElementBuildingListenerUsingTokens(Parser parser, Lexer lexer, bool throwingParseError) {
			_parserRuleNames = parser.RuleNames;
			_lexerTokenNames = lexer.TokenNames;
			_throwingParseError = throwingParseError;
			_stream = parser.InputStream as CommonTokenStream;
			_dummyRoot = new XElement("root");
			_dummyNode = new XElement("dummy");
			_elements = new Stack<XElement>(new[] { _dummyRoot });
			_lastElement = _dummyNode;
			_lastTokenIndex = -1;
		}

		public XElement FinishParsing() {
			var size = _stream.Size - 1; // Avoid writing "<EOF>"
			for (int i = _lastTokenIndex + 1; i < size; i++) {
				var token = _stream.Get(i);
				if (token.Channel == Lexer.Hidden) {
					var name = _lexerTokenNames[token.Type];
					_lastElement.Add(new XElement(name, token.Text));
				} else {
					_lastElement.Add(new XElement("TOKEN", token.Text));
				}
			}

			var root = _dummyRoot.Elements().First();
			var firstTokensNode = root.Descendants("TOKENS").FirstOrDefault();
			if (firstTokensNode != null) {
				foreach (var element in _dummyNode.Elements().Reverse()) {
					firstTokensNode.AddFirst(element);
				}
			}
			return root;
		}

		public void VisitTerminal(ITerminalNode node) {
			var symbol = node.Symbol;
			if (symbol.Type > 0) {
				var tokenIndex = symbol.TokenIndex;
				for (int i = _lastTokenIndex + 1; i < tokenIndex; i++) {
					var token = _stream.Get(i);
					if (token.Channel == Lexer.Hidden) {
						var name = _lexerTokenNames[token.Type];
						_lastElement.Add(new XElement(name, token.Text));
					} else {
						_lastElement.Add(new XElement("TOKEN", token.Text));
					}
				}
				_lastTokenIndex = tokenIndex;
				_lastElement = new XElement("TOKENS", new XElement("TOKEN", symbol.Text));
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