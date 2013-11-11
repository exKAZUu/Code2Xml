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
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Languages.ANTLRv3.Core;
using Code2Xml.Languages.ExternalProcessors.Processors.Python;
using Code2Xml.Languages.Python3.XmlToCodes;

namespace Code2Xml.Languages.Python3.CodeToXmls {
    [Export(typeof(CodeToXml))]
    public class Python3CodeToXml : CodeToXmlUsingProcessor<Python3Processor, Python3XmlToCode> {
        private static Python3CodeToXml _instance;

        public static Python3CodeToXml Instance {
            get { return _instance ?? (_instance = new Python3CodeToXml()); }
        }
    }
}