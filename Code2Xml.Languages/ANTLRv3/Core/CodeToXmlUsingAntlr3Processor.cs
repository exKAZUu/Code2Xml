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

using System.IO;
using Antlr.Runtime;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.ANTLRv3.Core {
    public abstract class CodeToXmlUsingAntlr3Processor<TProcessor, TXmlToCode, TParser>
            : CodeToXmlUsingProcessor<TProcessor, TXmlToCode>
            where TProcessor : ProcessorUsingAntlr3<TParser>, new()
            where TXmlToCode : XmlToCodeUsingProcessor<TProcessor>, new()
            where TParser : ICustomizedAntlr3Parser {
        public CommonTokenStream CreateTokenStream(string code) {
            return Processor.CreateTokenStream(code);
        }

        public CommonTokenStream CreateTokenStream(TextReader reader) {
            return Processor.CreateTokenStream(reader);
        }
    }
}