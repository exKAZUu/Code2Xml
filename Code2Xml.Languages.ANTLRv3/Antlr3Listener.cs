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

namespace Code2Xml.Languages.ANTLRv3 {
	public class Antlr3Listener {
		private readonly bool _throwingParseError;
		private readonly XElement _dummyRoot, _dummyNode;
		private readonly Stack<XElement> _elements;
		private readonly CommonTokenStream _stream;
		private int _nextTokenIndex;
		private XElement _lastElement;
		private readonly string[] _lexerTokenNames;

		public Antlr3Listener(Lexer lexer, Parser parser, bool throwingParseError) {
			_lexerTokenNames = lexer.TokenNames;
			_stream = (CommonTokenStream)parser.TokenStream;
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
				var token = _stream.Get(i);
				var name = token.Channel != Lexer.Hidden ? "TOKEN" : "HIDDEN";
				_lastElement.Add(new XElement(name, token.Text));
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

		public void VisitTerminalNode(string text, int ruleIndex, int channel) {
			if (ruleIndex > 0 && channel != Lexer.Hidden) {
				var count = _stream.Count;
				for (int i = _nextTokenIndex; i < count; i++) {
					var token = _stream.Get(i);
					var name = token.Channel != Lexer.Hidden ? "TOKEN" : "HIDDEN";
					_lastElement.Add(new XElement(name, token.Text));
				}
				_nextTokenIndex = count + 1;
				_lastElement = new XElement("TOKENS", new XElement("TOKEN", text));
				_elements.Peek().Add(_lastElement);
			}
		}

		//public void VisitErrorNode(IErrorNode node) {
		//	if (_throwingParseError) {
		//		throw new ParseException(node.ToStringTree());
		//	}
		//}

		public void EnterNonTerminalNode(string name) {
			var element = new XElement(name);
			_elements.Peek().Add(element);
			_elements.Push(element);
		}

		public void LeaveNonTerminalNode(string name) {
			_elements.Pop();
		}
	}
}