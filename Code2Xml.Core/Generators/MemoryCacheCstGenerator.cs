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
using System.Text;

namespace Code2Xml.Core.Generators {
    public class MemoryCacheCstGenerator : CstGenerator {
        public CstGenerator DelegatingCstGenerator { get; private set; }

        private static readonly Dictionary<string, CstNode> Path2Element =
                new Dictionary<string, CstNode>();

        public override string LanguageName {
            get { return DelegatingCstGenerator.LanguageName; }
        }

        public override string LanguageVersion {
            get { return DelegatingCstGenerator.LanguageVersion; }
        }

        public MemoryCacheCstGenerator(CstGenerator delegatingCstGenerator)
                : base(delegatingCstGenerator.SupportedExtensions) {
            DelegatingCstGenerator = delegatingCstGenerator;
        }

        public override CstNode GenerateTreeFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return DelegatingCstGenerator.GenerateTreeFromCodeText(code, throwingParseError);
        }

        public override CstNode GenerateTreeFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return DelegatingCstGenerator.GenerateTreeFromCode(codeReader, throwingParseError);
        }

        public override CstNode GenerateTreeFromCode(
                FileInfo codeFile, Encoding encoding = null,
                bool throwingParseError = DefaultThrowingParseError) {
            var id = codeFile.FullName + codeFile.LastWriteTime;
            if (Path2Element.ContainsKey(id)) {
                return Path2Element[id];
            }
            var tree = DelegatingCstGenerator.GenerateTreeFromCode(
                    codeFile, encoding, throwingParseError);
            Path2Element[id] = tree;
            return tree;
        }
    }
}