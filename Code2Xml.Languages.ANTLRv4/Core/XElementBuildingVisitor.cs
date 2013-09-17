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
using Code2Xml.Core.Processors;

namespace Code2Xml.Languages.ANTLRv4.Core {
	public class XElementBuildingVisitor : AbstractParseTreeVisitor<object> {
		private readonly bool _throwingParseError;
		private readonly string[] _parserRuleNames;
		private readonly XElement _root = new XElement("root");
		private readonly Stack<XElement> _elements;
		private int _lastDepth;

		public XElement Root {
			get { return _root.Elements().First(); }
		}

		public XElementBuildingVisitor(Parser parser, bool throwingParseError) {
			_parserRuleNames = parser.RuleNames;
			_throwingParseError = throwingParseError;
			_elements = new Stack<XElement>(new[] { _root });
		}

		public override object VisitTerminal(ITerminalNode node) {
			if (node.Symbol.Type > 0) {
				//var name = _lexerRuleNames[node.Symbol.Type - 1];
				var value = node.Symbol.Text;
				_elements.Peek().Add(new XElement("TOKEN", value));
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
			_elements.Peek().Add(element);
			_lastDepth = node.RuleContext.Depth();
			_elements.Push(element);
			return base.VisitChildren(node);
		}

		public override object VisitErrorNode(IErrorNode node) {
			if (_throwingParseError) {
				throw new ParseException(node.ToStringTree());
			}
			return base.VisitErrorNode(node);
		}
	}
}