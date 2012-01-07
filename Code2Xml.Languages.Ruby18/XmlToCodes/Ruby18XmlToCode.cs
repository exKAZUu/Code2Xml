#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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

using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Code2Xml.Core.XmlToCodes;
using Code2Xml.Languages.Ruby18.CodeToXmls;

namespace Code2Xml.Languages.Ruby18.XmlToCodes {
    [Export(typeof(XmlToCode))]
    public class Ruby18XmlToCode : XmlToCode {
        private static Ruby18XmlToCode _instance;

        private readonly ReadOnlyCollection<string> _supportedExtensions =
                new ReadOnlyCollection<string>(new[] { ".rb" });

        private Ruby18XmlToCode() {}

        public static Ruby18XmlToCode Instance {
            get { return _instance ?? (_instance = new Ruby18XmlToCode()); }
        }

        public override string ParserName {
            get { return "Ruby1.8"; }
        }

        public override ReadOnlyCollection<string> SupportedExtensions {
            get { return _supportedExtensions; }
        }

        public override string Generate(XElement root) {
            return IronRubyParser.ParseXml(root);
        }
    }
}