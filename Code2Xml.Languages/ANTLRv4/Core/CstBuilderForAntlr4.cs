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
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Code2Xml.Core;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Location;

namespace Code2Xml.Languages.ANTLRv4.Core {
    /// <summary>
    /// Note that you should replace "skip" with "channel(HIDDEN)".
    /// </summary>
    public class CstBuilderForAntlr4 : AbstractParseTreeVisitor<object> {
        public Parser Parser { get; set; }
        private readonly string[] _parserRuleNames;
        private readonly CstNode _dummyRoot;
        private readonly Stack<CstNode> _nodes;
        private readonly CommonTokenStream _stream;
        private readonly string[] _tokenNames;
        private int _nextTokenIndex;
        private int _lastDepth;

        public CstBuilderForAntlr4(Parser parser) {
            Parser = parser;
            _parserRuleNames = parser.RuleNames;
            _tokenNames = parser.TokenNames;
            _stream = (CommonTokenStream)parser.InputStream;
            _dummyRoot = new CstNode("root");
            _nodes = new Stack<CstNode>(new[] { _dummyRoot });
            _nextTokenIndex = 0;
        }

        public CstNode FinishParsing() {
            var root = _dummyRoot.Children().First();
            var count = _stream.Size - 1; // Avoid writing "<EOF>"
            while (count > 0 && _stream.Get(count - 1).Type < 0) {
                count--;
            }
            var antlrToken = _stream.Get(count);
            var token = CreateTerminalNode(
                    Code2XmlConstants.EofTokenName, antlrToken, String.Empty, count,
                    Code2XmlConstants.EofRuleId);
            // TODO: Deals with a bug in ANTLR 4 temporally
            if (token.Hiddens.Count > 0) {
                var location = token.Hiddens.Last().Range.EndLocation;
                token.Token.Range = new CodeRange(location, location);
            }
            root.AddLast(token);
            return root;
        }

        public override object VisitTerminal(ITerminalNode terminalNode) {
            var token = terminalNode.Symbol;
            if (token.Type > 0) {
                var maxDepth = _lastDepth + 1;
                _lastDepth = terminalNode.Parent.RuleContext.Depth();
                for (int i = _lastDepth + 1; i < maxDepth; i++) {
                    _nodes.Pop();
                }

                var count = token.TokenIndex;
                var tokenName = DetermineElementName(token, Code2XmlConstants.TokenSetElementName);
                var newNode = CreateTerminalNode(
                        tokenName, token, token.Text, count, token.Type.ToString());
                _nodes.Peek().AddLast(newNode);
                _nextTokenIndex = count + 1;
            }
            return base.VisitTerminal(terminalNode);
        }

        public override object VisitChildren(IRuleNode ruleNode) {
            var name = _parserRuleNames[ruleNode.RuleContext.RuleIndex];
            var maxDepth = _lastDepth + 1;
            _lastDepth = ruleNode.RuleContext.Depth();
            for (int i = _lastDepth; i < maxDepth; i++) {
                _nodes.Pop();
            }

            var newNode = new CstNode(name, ruleNode.RuleContext.invokingState.ToString());
            _nodes.Peek().AddLast(newNode);
            _nodes.Push(newNode);
            return base.VisitChildren(ruleNode);
        }

        private CstNode CreateTerminalNode(
                string tokenSetName, IToken antlrToken, string text, int exclusiveEndIndex,
                string ruleId) {
            var hiddenTokens = new List<CstToken>();
            for (int i = _nextTokenIndex; i < exclusiveEndIndex; i++) {
                var oldToken = _stream.Get(i); // Includes skipped tokens (maybe)
                var hiddenName = DetermineElementName(oldToken, Code2XmlConstants.HiddenElementName);
                var hiddenElement = CreateHiddenToken(hiddenName, oldToken);
                hiddenTokens.Add(hiddenElement);
            }
            var token = CreateToken(tokenSetName, antlrToken, text, ruleId);
            return new CstNode(token, hiddenTokens);
        }

        private string DetermineElementName(IToken token, string defaultName) {
            // TODO: Should we avoid generated name?
            var tokenName = _tokenNames[token.Type];
            return !char.IsLetter(tokenName[0]) ? defaultName : tokenName;
        }

        private static CstToken CreateToken(
                string name, IToken antlrToken, string text, string ruleId) {
            return new CstToken(name, text, ruleId, CreateCodeRange(antlrToken, text));
        }

        private static CstToken CreateHiddenToken(string name, IToken token) {
            var text = token.Text;
            return new CstToken(name, text, CreateCodeRange(token, text));
        }

        private static CodeRange CreateCodeRange(IToken token, string text) {
            var startLocation = new CodeLocation(token.Line, token.Column);
            var endLocation = startLocation.Advance(text);
            return new CodeRange(startLocation, endLocation);
        }
    }
}