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

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Antlr.Runtime;
using Code2Xml.Core.Antlr;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.Lua.CodeToXmls {
    [Export(typeof(CodeToXml))]
    public class LuaCodeToXml : AntlrCodeToXml<LuaParser> {
        private static LuaCodeToXml _instance;
        private static LuaCodeToXml _throwableInstance;

        private LuaCodeToXml() {}

        private LuaCodeToXml(bool canThrowParseError) {
            CanThrowParseError = canThrowParseError;
        }

        public static LuaCodeToXml Instance {
            get { return _instance ?? (_instance = new LuaCodeToXml()); }
        }

        public static LuaCodeToXml ThrowableInstance {
            get {
                return _throwableInstance
                       ?? (_throwableInstance = new LuaCodeToXml(true));
            }
        }

        protected override Func<LuaParser, XParserRuleReturnScope>
            DefaultParseFunc {
            get { return parser => parser.chunk(); }
        }

        public override string ParserName {
            get { return "Lua5.1"; }
        }

        public override IEnumerable<string> TargetExtensions {
            get { return new[] { ".lua" }; }
        }

        protected override ITokenSource CreateTokenSource(ICharStream stream) {
            return new LuaLexer(stream);
        }

        protected override LuaParser CreateParser(ITokenStream tokenStream) {
            return new LuaParser(tokenStream);
        }
    }
}