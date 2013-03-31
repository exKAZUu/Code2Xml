﻿#region License

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

using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.Lua.XmlToCodes {
    [Export(typeof(XmlToCode))]
    public class LuaXmlToCode : XmlToCodeBase {
        private static LuaXmlToCode _instance;

        private readonly ReadOnlyCollection<string> _supportedExtensions =
                new ReadOnlyCollection<string>(new[] { ".lua" });

        private LuaXmlToCode() {}

        public static LuaXmlToCode Instance {
            get { return _instance ?? (_instance = new LuaXmlToCode()); }
        }

        public override string ParserName {
            get { return "Lua5.1"; }
        }

        public override ReadOnlyCollection<string> SupportedExtensions {
            get { return _supportedExtensions; }
        }

        protected void WalkElementLua(XContainer element) {
            Contract.Requires(element != null);
            foreach (var e in element.Elements()) {
                if (e.HasElements) {
                    if (e.Name.LocalName == "block") {
                        WriteLine();
                        Depth++;
                    }
                    WalkElementLua(e);
                    if (e.Name.LocalName == "block") {
                        Depth--;
                    }
                    else if (e.Name.LocalName == "stat") {
                        WriteLine();
                    }
                } else if (!TreatTerminalSymbol(e) && e.Value != string.Empty) {
                    WriteWord(e.Value);
                }
            }
        }

        public override string Generate(XElement root) {
            Initialize();
            WalkElementLua(root);
            return _builder.ToString();
        }

        protected override bool TreatTerminalSymbol(XElement element) {
            switch (element.Value) {
            case ";":
                WriteLine(";");
                break;

            case "{":
                WriteLine("{");
                Depth++;
                break;

            case "}":
                Depth--;
                WriteLine("}");
                break;

            default:
                return false;
            }

            return true;
        }
    }
}