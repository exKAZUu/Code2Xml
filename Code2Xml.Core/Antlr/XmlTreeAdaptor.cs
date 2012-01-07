#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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
        public object Create(IToken payload, XParserRuleReturnScope parent) {
            Contract.Requires(parent != null);
            if (payload != null) {
                var xtoken = payload as XToken;
                var name = xtoken != null ? xtoken.Name : "TOKEN";
                var element = new XElement(name, payload.Text);
                element.SetAttributeValue("startline", payload.Line);
                element.SetAttributeValue(
                        "startpos", payload.CharPositionInLine);
                parent.Element.Add(element);
            }
            return Create(payload);
        }

        public void AddChild(
                object t, object child, XParserRuleReturnScope target,
                XParserRuleReturnScope parent) {
            Contract.Requires(parent != null);
            parent.Element.Add(target.Element);
            base.AddChild(t, child);
        }
    }
}