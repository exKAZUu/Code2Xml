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

namespace Code2Xml.Languages.Java.CodeToXmls {
    [Export(typeof(CodeToXml))]
    public class JavaCodeToXml : AntlrCodeToXml<JavaParser> {
        private static JavaCodeToXml _instance;

        private JavaCodeToXml() {}

        public static JavaCodeToXml Instance {
            get { return _instance ?? (_instance = new JavaCodeToXml()); }
        }

        protected override Func<JavaParser, XParserRuleReturnScope>
            DefaultParseFunc {
            get { return parser => parser.compilationUnit(); }
        }

        public override string ParserName {
            get { return "Java6"; }
        }

        public override IEnumerable<string> TargetExtensions {
            get { return new[] { ".java" }; }
        }

        protected override ITokenSource CreateTokenSource(ICharStream stream) {
            return new JavaLexer(stream);
        }

        protected override JavaParser CreateParser(ITokenStream tokenStream) {
            return new JavaParser(tokenStream);
        }
    }
}