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
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Code2Xml.Core;
using Code2Xml.Core.Location;

namespace Code2Xml.Languages.ANTLRv4.Core {
    public class Antlr4AstBuilder : AbstractParseTreeVisitor<object> {
	    public Parser Parser { get; set; }
	    private readonly string[] _parserRuleNames;
        private readonly XElement _dummyRoot;
        private readonly Stack<XElement> _elements;
        private readonly CommonTokenStream _stream;
        private readonly string[] _tokenNames;
        private int _nextTokenIndex;
        private int _lastDepth;

        public Antlr4AstBuilder(Parser parser) {
	        Parser = parser;
	        _parserRuleNames = parser.RuleNames;
            _tokenNames = parser.TokenNames;
            _stream = (CommonTokenStream)parser.InputStream;
            _dummyRoot = new XElement("root");
            _elements = new Stack<XElement>(new[] { _dummyRoot });
            _nextTokenIndex = 0;
        }

        public XElement FinishParsing() {
            var root = _dummyRoot.Elements().First();
            var count = _stream.Size - 1; // Avoid writing "<EOF>"
            while (count > 0 && _stream.Get(count - 1).Type < 0) {
                count--;
            }
            var token = _stream.Get(count);
            var tokenName = Code2XmlConstants.EofElementName;
            var element = CreateTokenSetElement(tokenName, token, string.Empty, count);
			element.SetAttributeValue(Code2XmlConstants.IdAttributeName, 0);
            root.Add(element);
			root.SetAttributeValue(Code2XmlConstants.IdAttributeName, 0);
			root.Remove();	// TODO: is it OK?
            return root;
        }

        public override object VisitTerminal(ITerminalNode node) {
            var token = node.Symbol;
            if (token.Type > 0) {
                var count = token.TokenIndex;
                var tokenName = DetermineElementName(token, Code2XmlConstants.TokenSetElementName);
                var element = CreateTokenSetElement(tokenName, token, token.Text, count);
				element.SetAttributeValue(Code2XmlConstants.IdAttributeName, token.Type);
                _elements.Peek().Add(element);
                _nextTokenIndex = count + 1;
            }
            return base.VisitTerminal(node);
        }

        public override object VisitChildren(IRuleNode node) {
            var name = _parserRuleNames[node.RuleContext.GetRuleIndex()];
            var maxDepth = _lastDepth + 1;
            for (int i = node.RuleContext.Depth(); i < maxDepth; i++) {
                _elements.Pop();
            }
            var element = new XElement(name);
			element.SetAttributeValue(Code2XmlConstants.IdAttributeName, node.RuleContext.invokingState);
            _elements.Peek().Add(element);
            _lastDepth = node.RuleContext.Depth();
            _elements.Push(element);
            return base.VisitChildren(node);
        }

        private XElement CreateTokenSetElement(
                string tokenSetName, IToken token, string text, int exclusiveEndIndex) {
            var element = new XElement(tokenSetName);
            for (int i = _nextTokenIndex; i < exclusiveEndIndex; i++) {
                var oldToken = _stream.Get(i);
          //      Debug.Assert(oldToken.Channel == Lexer.Hidden);
                var hiddenName = DetermineElementName(oldToken, Code2XmlConstants.HiddenElementName);
                var hiddenElement = CreateHiddenElement(hiddenName, oldToken);
                element.Add(hiddenElement);
            }
            var tokenElement = CreateTokenElement(Code2XmlConstants.TokenElementName, text, token);
            element.Add(tokenElement);
            return element;
        }

        private string DetermineElementName(IToken token, string defaultName) {
            var tokenName = _tokenNames[token.Type];
            return !char.IsLetter(tokenName[0]) ? defaultName : tokenName;
        }

        private static XElement CreateTokenElement(string name, string text, IToken token) {
            var tokenElement = new XElement(name, text);
            var startLocation = new CodeLocation(token.Line, token.Column);
            return CodeRange.SetLocationAttributes(tokenElement, text, startLocation);
        }

        private static XElement CreateHiddenElement(string name, IToken token) {
            var tokenElement = new XElement(name);
            tokenElement.SetAttributeValue(Code2XmlConstants.HiddenAttributeName, token.Text);
            var startLocation = new CodeLocation(token.Line, token.Column);
            return CodeRange.SetLocationAttributes(tokenElement, token.Text, startLocation);
        }
    }
}