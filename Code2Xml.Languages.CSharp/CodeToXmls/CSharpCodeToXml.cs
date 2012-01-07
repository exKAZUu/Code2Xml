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

namespace Code2Xml.Languages.CSharp.CodeToXmls {
    [Export(typeof(CodeToXml))]
    public class CSharpCodeToXml : AntlrCodeToXml<csParser> {
        private static CSharpCodeToXml _instance;
        private static CSharpCodeToXml _throwableInstance;

        private CSharpCodeToXml() {}

        private CSharpCodeToXml(bool canThrowParseError) {
            CanThrowParseError = canThrowParseError;
        }

        public static CSharpCodeToXml Instance {
            get { return _instance ?? (_instance = new CSharpCodeToXml()); }
        }

        public static CSharpCodeToXml ThrowableInstance {
            get {
                return _throwableInstance
                       ?? (_throwableInstance = new CSharpCodeToXml(true));
            }
        }

        protected override Func<csParser, XParserRuleReturnScope>
            DefaultParseFunc {
            get { return parser => parser.compilation_unit(); }
        }

        public override string ParserName {
            get { return "C#4.0"; }
        }

        public override IEnumerable<string> TargetExtensions {
            get { return new[] { ".cs" }; }
        }

        protected override ITokenSource CreateTokenSource(ICharStream stream) {
            return new csLexer(stream);
        }

        protected override csParser CreateParser(ITokenStream tokenStream) {
            return new csParser(tokenStream);
        }
    }
}