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
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Code2Xml.Core;

namespace Code2Xml.Languages.ANTLRv3.Core {
	public class Antlr3AstBuilder : CommonTreeAdaptor {
		private readonly bool _throwingParseError;
		private readonly XElement _dummyRoot, _dummyNode;
		private readonly Stack<XElement> _elements;
		private readonly CommonTokenStream _stream;
		private int _nextTokenIndex;
		private XElement _lastElement;

		public Antlr3AstBuilder(CommonTokenStream stream, bool throwingParseError) {
			_stream = stream;
			_throwingParseError = throwingParseError;
			_dummyRoot = new XElement("root");
			_dummyNode = new XElement("dummy");
			_elements = new Stack<XElement>(new[] { _dummyRoot });
			_lastElement = _dummyNode;
			_nextTokenIndex = 0;
		}

		public XElement FinishParsing() {
			var size = _stream.Count - 1; // Avoid writing "<EOF>"
			for (int i = _nextTokenIndex; i < size; i++) {
				var oldToken = _stream.Get(i);
				var name = oldToken.Channel != Lexer.Hidden ? "TOKEN" : "HIDDEN";
				_lastElement.Add(CreateTokenElement(name, oldToken));
			}

			var root = _dummyRoot.Elements().First();
			var firstTokensNode = root.Descendants("TOKENS").FirstOrDefault() ??
			                      root.Descendants().LastOrDefault();
			if (firstTokensNode != null) {
				foreach (var element in _dummyNode.Elements().Reverse()) {
					firstTokensNode.AddFirst(element);
				}
			}
			return root;
		}

		public void EnterNonTerminalNode(string name) {
			var element = new XElement(name);
			_elements.Peek().Add(element);
			_elements.Push(element);
		}

		public void LeaveNonTerminalNode(string name) {
			_elements.Pop();
		}

		public override object Create(IToken token) {
			if (token != null) {
				var count = token.TokenIndex;
				for (int i = _nextTokenIndex; i < count; i++) {
					var oldToken = _stream.Get(i);
					var name = oldToken.Channel != Lexer.Hidden ? "TOKEN" : "HIDDEN";
					_lastElement.Add(CreateTokenElement(name, oldToken));
				}
				_nextTokenIndex = count + 1;
				_lastElement = new XElement("TOKENS", CreateTokenElement("TOKEN", token));
				_elements.Peek().Add(_lastElement);
			}
			return base.Create(token);
		}

		public override object ErrorNode(
				ITokenStream input, IToken start, IToken stop, RecognitionException e) {
			if (_throwingParseError) {
				throw e;
			}
			return base.ErrorNode(input, start, stop, e);
		}

		private static XElement CreateTokenElement(string name, IToken token) {
			var text = token.Text;
			var newLineCount = text.Count(ch => ch == '\n');
			var tokenElement = new XElement(name, text);
			tokenElement.SetAttributeValue(
					Code2XmlConstants.StartLineName, token.Line);
			tokenElement.SetAttributeValue(
					Code2XmlConstants.StartPositionName, token.CharPositionInLine);
			tokenElement.SetAttributeValue(
					Code2XmlConstants.EndLineName, token.Line + newLineCount);
			tokenElement.SetAttributeValue(
					Code2XmlConstants.EndPositionName, newLineCount == 0
							? token.CharPositionInLine + text.Length - 1
							: text.Length - (text.LastIndexOf('\n') + 1) - 1);
			return tokenElement;
		}
	}
}