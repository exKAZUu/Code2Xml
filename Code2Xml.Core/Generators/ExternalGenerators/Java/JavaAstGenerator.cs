#region License

// Copyright (C) 2011-2015 Kazunori Sakamoto
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
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using Code2Xml.Core.Properties;
using Paraiba.IO;

namespace Code2Xml.Core.Generators.ExternalGenerators.Java {
    /// <summary>
    /// Represents a Java AstGenerator for converting source code into XML-based ASTs.
    /// </summary>
    [Export(typeof(AstGenerator))]
    public class JavaAstGenerator : AstGeneratorUsingExternalProgram {
        private static readonly string DirectoryPath =
                Path.Combine(Code2XmlConstants.DependenciesDirectoryName, "Java");

        private static readonly string[] XmlGeneratorArguments = {
            "-jar", Path.Combine(DirectoryPath, "java_ast_serializer.jar")
        };

        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return "Java"; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return "8"; }
        }

        private readonly string _processorPath;

        public JavaAstGenerator()
                : this("java") {}

        public JavaAstGenerator(string processorPath)
                : base(".java") {
            _processorPath = processorPath;
            ParaibaFile.WriteIfDifferentSize(
                    XmlGeneratorArguments[1], Resources.java_ast_serializer);
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