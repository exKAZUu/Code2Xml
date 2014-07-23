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
using Code2Xml.Core;
using Code2Xml.Core.Generators;
using Code2Xml.Languages.ExternalGenerators.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.ExternalGenerators.Generators.Ruby {
    /// <summary>
    /// Represents a Ruby 1.8.x processor for inter-converting between source code and XML-based ASTs.
    /// </summary>
    [Export(typeof(AstGenerator))]
    public class Ruby18AstGenerator : AstGeneratorUsingExternalProgram {
        private static readonly string DirectoryPath =
                Path.Combine(Code2XmlConstants.DependenciesDirectoryName, "Ruby");

        private static readonly string[] XmlGeneratorArguments = {
            Path.Combine(DirectoryPath, "ruby182xml.rb"),
        };

        private static readonly string[] CodeGeneratorArguments = {
            Path.Combine(DirectoryPath, "xml2ruby18.rb"),
        };

        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Ruby"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "1.8"; }
        }

        private string _processorPath;

        private string ProcessorPath {
            get {
                if (_processorPath == null) {
                    ProcessorPath = ExternalProgramUtils.GetRubyPath() ?? "ruby";
                }
                return _processorPath;
            }
            set {
                _processorPath = value;
                ParaibaFile.WriteIfDifferentSize(XmlGeneratorArguments[0], Resources.ruby182xml);
                ParaibaFile.WriteIfDifferentSize(CodeGeneratorArguments[0], Resources.xml2ruby18);
                RubyFiles.DeployCommonFiles(DirectoryPath);
            }
        }

        public Ruby18AstGenerator()
                : this(null) {}

        public Ruby18AstGenerator(string processorPath)
                : base(".rb") {
            if (processorPath != null) {
                ProcessorPath = processorPath;
            }
        }

        protected override ProcessStartInfo CreateProcessStartInfoForGeneratingXml() {
            return ExternalProgramUtils.CreateProcessStartInfo(
                    ProcessorPath, XmlGeneratorArguments);
        }

        protected override ProcessStartInfo CreateProcessStartInfoForGeneratingCode() {
            return ExternalProgramUtils.CreateProcessStartInfo(
                    ProcessorPath, CodeGeneratorArguments);
        }
    }
}