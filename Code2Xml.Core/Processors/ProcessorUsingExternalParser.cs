#region License

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

using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Code2Xml.Core;
using Paraiba.Core;
using Paraiba.IO;

namespace Code2Xml.Languages.ExternalProcessors.Core {
    /// <summary>
    /// Provides functions to invoke external parsers.
    /// Note that this class does not help invoking external programs to generate code from xml.
    /// </summary>
    public abstract class ProcessorUsingExternalParser : Processor {
        protected static readonly Encoding Encoding = new UTF8Encoding(false);

        protected abstract string XmlGeneratorPath { get; }

        protected abstract string[] XmlGeneratorArguments { get; }

        protected virtual string XmlGeneratorWorkingDirectory {
            get {
                Contract.Ensures(Contract.Result<string>() != null);
                return "";
            }
        }

        protected ProcessorUsingExternalParser(params string[] extensions)
                : base(extensions) {}

        public override XElement GenerateXml(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            // TODO: Support throwingParseError and enablePosition
            var info = new ProcessStartInfo {
                FileName = XmlGeneratorPath,
                Arguments = XmlGeneratorArguments.JoinString(" "),
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding,
                StandardErrorEncoding = Encoding,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = XmlGeneratorWorkingDirectory,
            };
            using (var p = Process.Start(info)) {
                using (var write = new StreamWriter(p.StandardInput.BaseStream, Encoding)) {
                    write.WriteFromStream(codeReader);
                }
                var xmlStr = p.StandardOutput.ReadToEnd();
                var normalizedXmlStr = NormalizeXmlText(xmlStr);
                Debug.WriteLine(p.StandardError.ReadToEnd());
                return XDocument.Parse(normalizedXmlStr).Root;
            }
        }

        public override XElement GenerateXml(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateXml(new StringReader(code), throwingParseError);
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
    }
}