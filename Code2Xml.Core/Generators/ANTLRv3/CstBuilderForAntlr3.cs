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
using Antlr.Runtime;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators.ANTLRv3 {
    public class CstBuilderForAntlr3 {
        private readonly CommonTokenStream _stream;
        private readonly string[] _tokenNames;
        private int _nextTokenIndex;

        public CstBuilderForAntlr3(
                CommonTokenStream stream, string[] tokenNames) {
            _stream = stream;
            _tokenNames = tokenNames;
            _nextTokenIndex = 0;
        }

        public CstNode FinishParsing(CstNode root) {
            var count = _stream.Count - 1; // Avoid writing "<EOF>"
            while (count > 0 && _stream.Get(count - 1).Type < 0) {
                count--;
            }
            var antlrToken = _stream.Get(count);
            var token = CreateTerminalNode(
                    Code2XmlConstants.EofTokenName, antlrToken, String.Empty, count,
                    Code2XmlConstants.EofRuleId);
            root.AddLast(token);
            return root;
        }

        public void AddChild(CstNode parent, CstNode child, string id) {
            parent.AddLast(child);
            child.RuleId = id.Substring(child.Name.Length);
        }

        public void Create(CstNode parent, IToken token, string id) {
            if (token != null) {
                var count = token.TokenIndex;
                var tokenName = DetermineElementName(token, Code2XmlConstants.TokenSetElementName);
                var node = CreateTerminalNode(tokenName, token, token.Text, count, id);
                parent.AddLast(node);
                _nextTokenIndex = count + 1;
            }
        }

        public virtual void ErrorNode(
                ITokenStream input, IToken start, IToken stop, RecognitionException e) {
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
            var startLocation = new CodeLocation(token.Line, token.CharPositionInLine);
            var endLocation = startLocation.Advance(text);
            return new CodeRange(startLocation, endLocation);
        }
    }

    public class CstBuilderForAntlr3WithReportingError : CstBuilderForAntlr3 {
        public CstBuilderForAntlr3WithReportingError(CommonTokenStream stream, string[] tokenNames)
                : base(stream, tokenNames) {}

        public override void ErrorNode(
                ITokenStream input, IToken start, IToken stop, RecognitionException e) {
            throw new ParseException(e);
        }
    }
}