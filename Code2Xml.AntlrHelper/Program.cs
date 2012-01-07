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

using System.IO;
using System.Linq;

namespace Code2Xml.AntlrHelper {
    internal class Program {
        private static void Main(string[] args) {
            foreach (var arg in args) {
                var path = Path.GetFullPath(arg);
                var dir = Directory.Exists(path)
                                  ? path : Path.GetDirectoryName(path);
                var parser = Directory.EnumerateFiles(dir, "*Parser.cs").First();
                var lexer = Directory.EnumerateFiles(dir, "*Lexer.cs").First();
                ParserModifier.Modify(parser);
                LexerModifier.Modify(lexer);
            }
        }
    }
}