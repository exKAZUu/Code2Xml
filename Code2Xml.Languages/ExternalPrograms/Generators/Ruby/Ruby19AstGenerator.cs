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
    /// Represents a Ruby 1.9.x processor for inter-converting between source code and XML-based ASTs.
    /// </summary>
    [Export(typeof(AstGenerator))]
    public class Ruby19AstGenerator : AstGeneratorUsingExternalProgram {
        private static readonly string DirectoryPath =
                Path.Combine(Code2XmlConstants.DependenciesDirectoryName, "Ruby");

        private static readonly string[] PrivateXmlGeneratorArguments = {
            Path.Combine(DirectoryPath, "ruby192xml.rb"),
        };

        private static readonly string[] PrivateCodeGeneratorArguments = {
            Path.Combine(DirectoryPath, "xml2ruby19.rb"),
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

        private readonly string _processorPath;

        public Ruby19AstGenerator()
                : this(ExternalProgramUtils.GetRubyPath() ?? "ruby") {}

        public Ruby19AstGenerator(string processorPath)
                : base(".rb") {
            _processorPath = processorPath;

            ParaibaFile.WriteIfDifferentSize(PrivateXmlGeneratorArguments[0], Resources.ruby192xml);
            ParaibaFile.WriteIfDifferentSize(PrivateCodeGeneratorArguments[0], Resources.xml2ruby19);
            RubyFiles.DeployCommonFiles(DirectoryPath);
        }

        protected override ProcessStartInfo CreateProcessStartInfoForGeneratingXml() {
            return ExternalProgramUtils.CreateProcessStartInfo(
                    _processorPath, PrivateXmlGeneratorArguments);
        }

        protected override ProcessStartInfo CreateProcessStartInfoForGeneratingCode() {
            return ExternalProgramUtils.CreateProcessStartInfo(
                    _processorPath, PrivateCodeGeneratorArguments);
        }
    }
}