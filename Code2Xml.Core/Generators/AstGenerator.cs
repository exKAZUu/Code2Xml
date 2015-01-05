
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
using System.Xml.Linq;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators {
    /// <summary>
    /// Represents a programming language processor for inter-converting source code and a xml representing an abstract syntax tree.
    /// </summary>
    public abstract class AstGenerator : SyntaxTreeGenerator<AstNode, AstToken> {
        protected AstGenerator(IEnumerable<string> extensions) : base(extensions) {}

        protected AstGenerator(params string[] extensions) : base(extensions) {}

        #region GenerateTree

        public override sealed AstNode GenerateTreeFromXml(
                XElement element, bool throwingParseError = DefaultThrowingParseError) {
            return element.ToAst();
        }

        #endregion

        #region GenerateCode

        public override string GenerateCodeFromTree(AstNode root) {
            return GenerateCodeFromXml(root.ToXml());
        }

        #endregion
    }
}