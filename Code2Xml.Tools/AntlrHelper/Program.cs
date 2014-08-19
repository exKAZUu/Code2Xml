#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Code2Xml.Tools.AntlrHelper {
    internal class Program {
        private static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Find 'Code2Xml.Languages' directory due to no arguments.");
                var dir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory;
                while (true) {
                    var dirs = dir.GetDirectories("Code2Xml.Languages", SearchOption.AllDirectories);
                    if (dirs.Length > 0) {
                        args = new[] { dirs[0].FullName };
                        break;
                    }
                    dir = dir.Parent;
                    if (dir == null) {
                        Console.WriteLine("Can't find 'Code2Xml.Languages' directory.");
                        args = new[] { Console.In.ReadLine() };
                        break;
                    }
                }
            }
            foreach (var arg in args) {
                var path = Path.GetFullPath(arg);
                var dir = Directory.Exists(path) ? path : Path.GetDirectoryName(path);
                var grammarFiles = Directory.GetFiles(dir, "php.g", SearchOption.AllDirectories);
                foreach (var grammarFile in grammarFiles) {
                    Console.WriteLine(grammarFile);
                    var info = new ProcessStartInfo {
                        FileName = "Antlr3",
                        Arguments = '"' + grammarFile + '"',
                        CreateNoWindow = true,
                        UseShellExecute = true,
                        WorkingDirectory = Path.GetDirectoryName(grammarFile),
                    };
                    using (var p = Process.Start(info)) {
                        p.WaitForExit();
                    }
                }
                var csFiles = grammarFiles
                        .Select(Path.GetDirectoryName)
                        .SelectMany(d => Directory.GetFiles(d, "*.cs", SearchOption.AllDirectories));
                foreach (var file in csFiles) {
                    if (file.EndsWith("Parser.cs")) {
                        Console.WriteLine(file);
                        ParserModifier.Modify(file);
                    } else if (file.EndsWith("Lexer.cs")) {
                        Console.WriteLine(file);
                        LexerModifier.Modify(file);
                    }
                }
            }
        }
    }
}