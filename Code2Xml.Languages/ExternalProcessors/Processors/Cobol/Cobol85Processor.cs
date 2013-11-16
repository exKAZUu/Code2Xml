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
using ParserTests;

namespace Code2Xml.Languages.ExternalProcessors.Processors.Cobol {
    /// <summary>
    /// Represents a Cobol-85 processor for inter-converting between source code and XML-based ASTs.
    /// </summary>
    [Export(typeof(Processor))]
    public class Cobol85Processor : ProcessorUsingExternalProcessor {
        private static readonly string DirectoryPath = Path.Combine("ParserScripts", "Cobol");

        private static readonly string[] PrivateXmlGeneratorArguments = {
             string.Concat("-cp ", Path.Combine(DirectoryPath, "koopafor85.jar"), " koopa.app.cli.ToXml " )
        };
        //java -cp koopa.jar koopa.app.cli.ToXml [--free-format] <cobol-file> <xml-file>

        private static readonly string[] PrivateCodeGeneratorArguments = {
         //   Path.Combine(DirectoryPath, ""),
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

        protected override string XmlGeneratorPath {
            get { return _processorPath; }
        }

        protected override string[] XmlGeneratorArguments {
            get { return PrivateXmlGeneratorArguments; }
        }

        protected override string CodeGeneratorPath
        {
            get { return _processorPath; }
        }

        protected override string[] CodeGeneratorArguments
        {
            get { return PrivateCodeGeneratorArguments; }
        }

        private readonly string _processorPath;

        public Cobol85Processor()
            : this("java") { }

        public Cobol85Processor(string processorPath)
                : base(".CBL") {
            _processorPath = processorPath;

       //     ParaibaFile.WriteIfDifferentSize(PrivateXmlGeneratorArguments[0], Resources.koopafor85);
        }
    }
}