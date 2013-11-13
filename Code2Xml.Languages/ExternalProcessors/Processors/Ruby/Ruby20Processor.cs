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
using Code2Xml.Core;
using Code2Xml.Languages.ExternalProcessors.Core;
using Code2Xml.Languages.ExternalProcessors.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.ExternalProcessors.Processors.Ruby {
    /// <summary>
    /// Represents a Ruby 2.0.x processor for inter-converting between source code and XML-based ASTs.
    /// </summary>
    [Export(typeof(Processor))]
    public class Ruby20Processor : ProcessorUsingExternalProcessor {
        private static readonly string DirectoryPath = Path.Combine("ParserScripts", "Ruby");

        private static readonly string[] PrivateXmlGeneratorArguments = {
            Path.Combine(DirectoryPath, "ruby202xml.rb"),
        };

        private static readonly string[] PrivateCodeGeneratorArguments = {
            Path.Combine(DirectoryPath, "xml2ruby20.rb"),
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

        protected override string XmlGeneratorPath {
            get { return _processorPath; }
        }

        protected override string[] XmlGeneratorArguments {
            get { return PrivateXmlGeneratorArguments; }
        }

        protected override string CodeGeneratorPath {
            get { return _processorPath; }
        }

        protected override string[] CodeGeneratorArguments {
            get { return PrivateCodeGeneratorArguments; }
        }

        private readonly string _processorPath;

        public Ruby20Processor()
                : this(ExternalProgramUtils.GetRubyPath() ?? "ruby") {}

        public Ruby20Processor(string processorPath)
                : base(".rb") {
            _processorPath = processorPath;

            ParaibaFile.WriteIfDifferentSize(PrivateXmlGeneratorArguments[0], Resources.ruby202xml);
            ParaibaFile.WriteIfDifferentSize(PrivateCodeGeneratorArguments[0], Resources.xml2ruby20);
            RubyFiles.DeployCommonFiles(DirectoryPath);
        }
    }
}