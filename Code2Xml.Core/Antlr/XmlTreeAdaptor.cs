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

using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Code2Xml.Core.Antlr {
	public class XmlTreeAdaptor : CommonTreeAdaptor {
		public CommonTokenStream TokenStream { get; set; }
		public bool EnablePosition { get; set; }

		public XmlTreeAdaptor() {
			EnablePosition = true;
		}

		public object Create(IToken payload, XAstParserRuleReturnScope parent) {
			Contract.Requires(parent != null);
			if (payload != null) {
				var xtoken = payload as XToken;
				var name = xtoken != null ? xtoken.Name : "TOKEN";
				var element = new XElement(name, payload.Text);

				if (EnablePosition) {
					element.SetAttributeValue(Code2XmlConstants.StartLineName, payload.Line);
					element.SetAttributeValue(
							Code2XmlConstants.StartPositionName, payload.CharPositionInLine);
				}

				//var endToken = TokenStream.Get(payload.TokenIndex + 1);
				//element.SetAttributeValue(Code2XmlConstants.EndLineName, endToken.Line);
				//element.SetAttributeValue(
				//        Code2XmlConstants.EndPositionName, endToken.CharPositionInLine);
				parent.Element.Add(element);
			}
			return Create(payload);
		}

		public void AddChild(
				object t, object child, XAstParserRuleReturnScope target,
				XAstParserRuleReturnScope parent) {
			Contract.Requires(parent != null);
			parent.Element.Add(target.Element);
			base.AddChild(t, child);
		}
	}
}