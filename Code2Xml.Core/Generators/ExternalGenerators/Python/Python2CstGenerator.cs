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

using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using Code2Xml.Core.Properties;
using Paraiba.IO;

namespace Code2Xml.Core.Generators.ExternalGenerators.Python {
    /// <summary>
    /// Represents a Python 2.x processor for inter-converting between source code and XML-based ASTs.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class Python2CstGenerator : CstGeneratorUsingExternalProgram {
        private static readonly string DirectoryPath =
                Path.Combine(Code2XmlConstants.DependenciesDirectoryName, "Python");

        private static readonly string[] XmlGeneratorArguments = {
            Path.Combine(DirectoryPath, "ast2xml.py"),
        };

        private static readonly string[] ParserArguments = {
            Path.Combine(DirectoryPath, "ast_parser.py"),
        };

        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Python"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "2"; }
        }

        private string _processorPath;

        private string ProcessorPath {
            get {
                if (_processorPath == null) {
                    ProcessorPath = ExternalProgramUtils.GetPythonPath("2") ?? "python";
                }
                return _processorPath;
            }
            set {
                _processorPath = value;
                ParaibaFile.WriteIfDifferentSize(XmlGeneratorArguments[0], Resources.ast2xml);
                ParaibaFile.WriteIfDifferentSize(ParserArguments[0], Resources.ast_parser);
            }
        }

        public Python2CstGenerator()
                : this("\n") {}

        public Python2CstGenerator(string newLine)
                : this(newLine, null) {}

        public Python2CstGenerator(string newLine, string processorPath)
                : base(newLine, ".py") {
            if (processorPath != null) {
                ProcessorPath = processorPath;
            }
        }

        protected override Process StartProcess(string code) {
            return ExternalProgramUtils.StartProcess(
                    code.Replace("\r\n", "\n"), ProcessorPath, XmlGeneratorArguments);
        }

        public override void TryParseFromCodeText(string code) {
            using (var p = ExternalProgramUtils.StartProcess(
                    code.Replace("\r\n", "\n"), ProcessorPath, ParserArguments)) {}
        }
    }
}