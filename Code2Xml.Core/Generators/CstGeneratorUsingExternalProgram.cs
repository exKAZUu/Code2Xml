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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators {
    /// <summary>
    /// Provides functions to invoke external parsers.
    /// Note that this class does not help invoking external programs to generate code from xml.
    /// </summary>
    public abstract class CstGeneratorUsingExternalProgram : CstGenerator {
        protected CstGeneratorUsingExternalProgram(IEnumerable<string> extensions)
                : base(extensions) {}

        protected CstGeneratorUsingExternalProgram(params string[] extensions)
                : this((IEnumerable<string>)extensions) {}

        protected abstract Process StartProcess(string code);

        protected string NormalizeCode(string code) {
            return code;
        }

        public override CstNode GenerateTreeFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromCodeText(codeReader.ReadToEnd(), throwingParseError);
        }

        public override CstNode GenerateTreeFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            // TODO: Support throwingParseError and enablePosition
            using (var p = StartProcess(code)) {
                var tree = CstNode.Deserialize(p.StandardOutput);
                SetLocationInformation(tree, code);
                return tree;
                // for debug
                //try {
                //    var tree = CstNode.Deserialize(p.StandardOutput);
                //    SetLocationInformation(tree, code);
                //    return tree;
                //} catch (Exception e) {
                //    Debug.WriteLine(p.StandardError.ReadToEnd());    
                //    throw new ParseException(e);
                //}
            }
        }

        public void SetLocationInformation(CstNode tree, string code) {
            var line = 1;
            var pos = 0;
            var index = 0;
            var startHiddenLocation = new CodeLocation(line, pos);
            foreach (var tokenNode in tree.AllTokenNodes()) {
                var token = tokenNode.Token;
                var tokenStr = token.Text;
                if (tokenStr == string.Empty) { // e.g. NEWLINE in Python
                    token.Range = new CodeRange(startHiddenLocation, startHiddenLocation);
                    continue;
                }
                var startHiddenIndex = index;
                var tokenChar = tokenStr[0];
                while (code[index] != tokenChar
                       || code.Substring(index, tokenStr.Length) != tokenStr) {
                    if (code[index] != '\n') {
                        pos++;
                    } else {
                        line++;
                        pos = 0;
                    }
                    index++;
                }
                var endHiddenIndex = index;
                var startTokenLocation = new CodeLocation(line, pos);
                var endIndex = index + tokenStr.Length;
                while (index < endIndex) {
                    if (code[index] != '\n') {
                        pos++;
                    } else {
                        line++;
                        pos = 0;
                    }
                    index++;
                }
                tokenNode.Hiddens.Add(
                        new CstToken(
                                Code2XmlConstants.HiddenElementName,
                                code.Substring(startHiddenIndex, endHiddenIndex - startHiddenIndex),
                                Code2XmlConstants.DefaultHiddenRuleId,
                                new CodeRange(startHiddenLocation, startTokenLocation)));
                startHiddenLocation = new CodeLocation(line, pos); // as endTokenLocation
                token.Range = new CodeRange(startTokenLocation, startHiddenLocation);
            }

            {
                var startHiddenIndex = index;
                var endIndex = code.Length;
                while (index < endIndex) {
                    if (code[index] != '\n') {
                        pos++;
                    } else {
                        line++;
                        pos = 0;
                    }
                    index++;
                }
                var endHiddenLocation = new CodeLocation(line, pos);
                var token = new CstToken(
                        Code2XmlConstants.EofTokenName, String.Empty, Code2XmlConstants.EofRuleId,
                        new CodeRange(endHiddenLocation, endHiddenLocation));
                var eofNode = new CstNode(token);
                eofNode.Hiddens.Add(
                        new CstToken(
                                Code2XmlConstants.HiddenElementName,
                                code.Substring(startHiddenIndex, index - startHiddenIndex),
                                Code2XmlConstants.DefaultHiddenRuleId,
                                new CodeRange(startHiddenLocation, endHiddenLocation)));
                tree.AddLast(eofNode);
            }
        }
    }
}