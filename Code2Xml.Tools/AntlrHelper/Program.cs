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

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Paraiba.IO;

namespace Code2Xml.Tools.AntlrHelper {
	internal class Program {
		private static void Main(string[] args) {
			if (args.Length == 0) {
				Console.WriteLine("Please enter the path of the input directory");
				args = new[] { Console.In.ReadLine() };
			}
			foreach (var arg in args) {
				var path = Path.GetFullPath(arg);
				var dir = Directory.Exists(path) ? path : Path.GetDirectoryName(path);
				foreach (var file in Directory.GetFiles(dir, "*.g", SearchOption.AllDirectories)) {
					Console.WriteLine(file);
					var info = new ProcessStartInfo {
						FileName = "Antlr3",
						Arguments = '"' + file + '"',
						CreateNoWindow = true,
						UseShellExecute = false,
						WorkingDirectory = Path.GetDirectoryName(file),
					};
					using (var p = Process.Start(info)) {
						p.WaitForExit();
					}
				}
				foreach (var file in Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories)) {
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