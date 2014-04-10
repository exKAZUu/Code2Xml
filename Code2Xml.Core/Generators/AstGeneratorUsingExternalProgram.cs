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

using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Paraiba.IO;

namespace Code2Xml.Core.Generators {
    /// <summary>
    /// Provides functions to invoke external parsers.
    /// Note that this class does not help invoking external programs to generate code from xml.
    /// </summary>
    public abstract class AstGeneratorUsingExternalProgram : AstGenerator {
        protected AstGeneratorUsingExternalProgram(params string[] extensions)
                : base(extensions) {}

        protected abstract ProcessStartInfo CreateProcessStartInfoForGeneratingXml();

        protected abstract ProcessStartInfo CreateProcessStartInfoForGeneratingCode();

        #region GenerateXml

        public override XElement GenerateXmlFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            // TODO: Support throwingParseError and enablePosition
            var info = CreateProcessStartInfoForGeneratingXml();
            using (var process = Process.Start(info)) {
                using (var write = new StreamWriter(
                        process.StandardInput.BaseStream, info.StandardOutputEncoding)) {
                    write.WriteFromStream(codeReader);
                }
                return ReadXml(process);
            }
        }

        public override XElement GenerateXmlFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            // TODO: Support throwingParseError and enablePosition
            var info = CreateProcessStartInfoForGeneratingXml();
            using (var process = Process.Start(info)) {
                using (var write = new StreamWriter(
                        process.StandardInput.BaseStream, info.StandardOutputEncoding)) {
                    write.Write(code);
                }
                return ReadXml(process);
            }
        }

        private XElement ReadXml(Process process) {
            var xmlStr = process.StandardOutput.ReadToEnd();
            var normalizedXmlStr = NormalizeXmlText(xmlStr);
            Debug.WriteLine(process.StandardError.ReadToEnd());
            return XDocument.Parse(normalizedXmlStr).Root;
        }

        protected virtual string NormalizeXmlText(string xml) {
            // TODO: Deal with illegal characters more smartly
            var buf = new StringBuilder(xml.Length);
            for (int i = 0; i < xml.Length; i++) {
                var c = xml[i];
                if (char.IsControl(c) && c != '\r' && c != '\n') {
                    c = ' ';
                }
                buf.Append(c);
            }
            return buf.ToString();
        }

        #endregion

        #region GenerateTree

        public override AstNode GenerateTreeFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateXmlFromCode(codeReader, throwingParseError).ToAst();
        }

        public override AstNode GenerateTreeFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateXmlFromCodeText(code, throwingParseError).ToAst();
        }

        #endregion

        #region GenerateCode

        public override string GenerateCodeFromXml(XElement root) {
            return GenerateCodeFromXmlText(root.ToString());
        }

        public override string GenerateCodeFromXml(TextReader xmlReader) {
            // TODO: Support throwingParseError and enablePosition
            var info = CreateProcessStartInfoForGeneratingCode();
            using (var process = Process.Start(info)) {
                using (var write = new StreamWriter(
                        process.StandardInput.BaseStream, info.StandardOutputEncoding)) {
                    write.WriteFromStream(xmlReader);
                }
                var code = process.StandardOutput.ReadToEnd();
                Debug.WriteLine(process.StandardError.ReadToEnd());
                return code;
            }
        }

        public override string GenerateCodeFromXmlText(string xmlText) {
            // TODO: Support throwingParseError and enablePosition
            var info = CreateProcessStartInfoForGeneratingCode();
            using (var process = Process.Start(info)) {
                using (var write = new StreamWriter(
                        process.StandardInput.BaseStream, info.StandardOutputEncoding)) {
                    write.Write(xmlText);
                }
                var code = process.StandardOutput.ReadToEnd();
                Debug.WriteLine(process.StandardError.ReadToEnd());
                return code;
            }
        }

        #endregion
    }
}