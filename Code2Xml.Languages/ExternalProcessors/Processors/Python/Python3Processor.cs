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

using System.ComponentModel.Composition;
using System.IO;
using System.Xml.Linq;
using Code2Xml.Core;
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ExternalProcessors.Core;
using Code2Xml.Languages.ExternalProcessors.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.ExternalProcessors.Processors.Python {
    /// <summary>
    /// Represents a Python 3.x processor for inter-converting between source code and XML-based ASTs.
    /// </summary>
    [Export(typeof(Processor))]
    public class Python3Processor : ProcessorUsingExternalParserAndOwnCodeGenerator {
        private static readonly string DirectoryPath = Path.Combine("ParserScripts", "Python");

        private static readonly string[] PrivateXmlGeneratorArguments = {
            Path.Combine(DirectoryPath, "st2xml.py"),
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
            get { return "3"; }
        }

        protected override string XmlGeneratorPath {
            get { return _processorPath; }
        }

        protected override string[] XmlGeneratorArguments {
            get { return PrivateXmlGeneratorArguments; }
        }

        private readonly string _processorPath;

        public Python3Processor()
                : this("\n") {}

        public Python3Processor(string newLine)
                : this(newLine, ExternalProgramUtils.GetPythonPath("3") ?? "python3") {}

        public Python3Processor(string newLine, string processorPath)
                : base(newLine, ".py") {
            _processorPath = processorPath;

            ParaibaFile.WriteIfDifferentSize(PrivateXmlGeneratorArguments[0], Resources.st2xml);
        }

        protected override bool TreatTerminalSymbol(XElement element) {
            switch (element.Name.LocalName) {
            case "NEWLINE":
                WriteLine();
                break;

            case "INDENT":
                Depth++;
                break;

            case "DEDENT":
                Depth--;
                break;

            default:
                return false;
            }

            return true;
        }
    }
}