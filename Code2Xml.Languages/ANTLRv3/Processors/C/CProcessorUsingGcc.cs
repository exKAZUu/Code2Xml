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
using Paraiba.IO;

namespace Code2Xml.Languages.ANTLRv3.Processors.C {
    /// <summary>
    /// Represents a C processor using GCC for inter-converting between source code and XML-based ASTs.
    /// </summary>
    [Export(typeof(Processor))]
    public class CProcessorUsingGcc : ProcessorUsingExternalParser {
		private static readonly Processor _proc = new CProcessorUsingAntlr3();

        private static readonly string[] PrivateXmlGeneratorArguments = {
            "-E", "-P", "-",
        };

        /// <summary>
        /// Gets the language name except for the version.
        /// </summary>
        public override string LanguageName {
            get { return _proc.LanguageName; }
        }

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public override string LanguageVersion {
            get { return _proc.LanguageVersion; }
        }

        protected override string XmlGeneratorPath {
            get { return _processorPath; }
        }

        protected override string[] XmlGeneratorArguments {
            get { return PrivateXmlGeneratorArguments; }
        }

        private readonly string _processorPath;

        public CProcessorUsingGcc()
                : this("\n") {}

        public CProcessorUsingGcc(string newLine)
                : this("gcc") {}

        public CProcessorUsingGcc(string newLine, string processorPath)
                : base(newLine, ".py") {
            _processorPath = processorPath;
        }

        public override XElement GenerateXml(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
			var xml = base.GenerateXml(codeReader, throwingParseError);
		}

		public override string GenerateCode(XElement root)
		{
			throw new System.NotImplementedException();
		}
	}
}