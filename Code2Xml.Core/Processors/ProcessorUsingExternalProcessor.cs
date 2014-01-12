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
using System.Xml.Linq;
using Paraiba.Core;

namespace Code2Xml.Core.Processors {
    public abstract class ProcessorUsingExternalProcessor : ProcessorUsingExternalParser {
        protected ProcessorUsingExternalProcessor(params string[] extensions) : base(extensions) {}

        protected abstract string CodeGeneratorPath { get; }

        protected abstract string[] CodeGeneratorArguments { get; }

        protected virtual string CodeGeneratorWorkingDirectory {
            get {
                Contract.Ensures(Contract.Result<string>() != null);
                return "";
            }
        }

        public override string GenerateCode(XElement root) {
            var info = new ProcessStartInfo {
                FileName = CodeGeneratorPath,
                Arguments = CodeGeneratorArguments.JoinString(" "),
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding,
                StandardErrorEncoding = Encoding,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = CodeGeneratorWorkingDirectory,
            };
            using (var p = Process.Start(info)) {
                using (var write = new StreamWriter(p.StandardInput.BaseStream, Encoding)) {
                    write.Write(root);
                }
                var code = p.StandardOutput.ReadToEnd();
                Debug.WriteLine(p.StandardError.ReadToEnd());
                return code;
            }
        }
    }
}