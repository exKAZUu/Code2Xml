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

using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators {
    /// <summary>
    /// Represents a programming language processor for inter-converting source code and a xml representing an abstract syntax tree.
    /// </summary>
    public abstract class CstGenerator : SyntaxTreeGenerator<CstNode, CstToken> {
        protected CstGenerator(IEnumerable<string> extensions) : base(extensions) {}

        protected CstGenerator(params string[] extensions) : base(extensions) {}

        #region GenerateTree

        public override sealed CstNode GenerateTreeFromXml(
                XElement element, bool throwingParseError = DefaultThrowingParseError) {
            return element.ToCst();
        }

        #endregion

        #region GenerateXml

        public override sealed XElement GenerateXmlFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromCode(codeReader, throwingParseError).ToXml();
        }

        public override sealed XElement GenerateXmlFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromCodeText(code, throwingParseError).ToXml();
        }

        #endregion

        #region GenerateCode

        public override sealed string GenerateCodeFromTree(CstNode root) {
            return root.Code;
        }

        public override sealed string GenerateCodeFromXml(XElement root) {
            return root.Value;
        }

        public override sealed string GenerateCodeFromXml(TextReader xmlReader) {
            return GenerateCodeFromXml(XDocument.Load(xmlReader, LoadOptions.PreserveWhitespace));
        }

        public override sealed string GenerateCodeFromXmlText(string xmlText) {
            return GenerateCodeFromXml(XDocument.Parse(xmlText, LoadOptions.PreserveWhitespace));
        }

        #endregion
    }
}