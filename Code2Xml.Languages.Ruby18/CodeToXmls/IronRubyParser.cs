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

using System;
using System.IO;
using System.Xml.Linq;
using IronRuby;
using Paraiba.Text;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
    public static class IronRubyParser {
        private static readonly Func<string, XElement> ParseCodeFunc;
        private static readonly Func<XElement, string> ParseXmlFunc;

        static IronRubyParser() {
            var engine = Ruby.CreateEngine();
            // ir.exe.config を参照のこと
            engine.SetSearchPaths(
                    new[] {
                            @"ParserScripts\IronRubyParser",
                    });

            var scope = engine.CreateScope();
            var source =
                    engine.CreateScriptSourceFromFile(
                            @"ParserScripts\IronRubyParser\parser.rb");
            source.Execute(scope);
            ParseCodeFunc =
                    scope.GetVariable<Func<string, XElement>>("parse_code");
            ParseXmlFunc = scope.GetVariable<Func<XElement, string>>(
                    "parse_xml");
        }

        public static XElement ParseCodeFromString(string content) {
            return ParseCodeFunc(content);
        }

        public static XElement ParseCodeFromFile(string fileName) {
            using (var reader = new StreamReader(fileName, XEncoding.SJIS)) {
                return ParseCodeFromString(reader.ReadToEnd());
            }
        }

        public static XElement ParseCodeFromReader(TextReader reader) {
            return ParseCodeFromString(reader.ReadToEnd());
        }

        public static String ParseXml(XElement root) {
            return ParseXmlFunc(root);
        }
    }
}