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
using System.Diagnostics;
using System.IO;
using Code2Xml.Core.Properties;
using Paraiba.IO;

namespace Code2Xml.Core.Generators.ExternalGenerators.Cobol {
    /// <summary>
    /// Represents a Cobol-85 CstGenerator for inter-converting between source code and XML-based ASTs.
    /// </summary>
    //TODO: [Export(typeof(AstGenerator))]
    public class Cobol85AstGenerator : AstGeneratorUsingExternalProgram {
        private static readonly string DirectoryPath =
                Path.Combine(Code2XmlConstants.DependenciesDirectoryName, "Cobol");

        private static readonly string[] XmlGeneratorArguments = {
            // java -cp koopa.jar koopa.app.cli.ToXml [--free-format] <cobol-file> <xml-file>
            "-cp", Path.Combine(DirectoryPath, "koopafor85.jar"), "koopa.app.cli.ToXml"
        };

        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Cobol"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "85"; }
        }

        private readonly string _processorPath;

        public Cobol85AstGenerator()
                : this("java") {}

        public Cobol85AstGenerator(string processorPath)
                : base(".cbl") {
            _processorPath = processorPath;
            ParaibaFile.WriteIfDifferentSize(XmlGeneratorArguments[1], Resources.koopafor85);
        }

        protected override ProcessStartInfo CreateProcessStartInfoForGeneratingXml() {
            return ExternalProgramUtils.CreateProcessStartInfo(
                    _processorPath, XmlGeneratorArguments);
        }

        protected override ProcessStartInfo CreateProcessStartInfoForGeneratingCode() {
            throw new NotSupportedException();
        }
    }
}