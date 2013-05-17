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

using System.Collections.Generic;
using System.IO;
using Paraiba.Core;

namespace Code2Xml.Console {
	public class Program {
		public static void Main(string[] args) {
			string parserName = null;
			string outputPath = null;
			var outputType = OutputType.DefaultStream;
			var isXmlToCode = false;
			var filePaths = new List<string>();

			for (int i = 0; i < args.Length; i++) {
				var arg = args[i].ToLower();
				if (arg == "-d") {
					outputType = OutputType.Directory;
					outputPath = args.AtOrDefault(i + 1);
					if (Directory.Exists(outputPath)) {
						i++;
					} else {
						outputPath = null;
					}
				} else if (arg == "-f") {
					outputType = OutputType.File;
					outputPath = args.AtOrDefault(i + 1);
					i++;
				} else if (arg == "-code") {
					isXmlToCode = true;
				} else if (arg.StartsWith("-")) {
					parserName = parserName ?? arg.Substring(1);
				} else {
					filePaths.Add(arg);
				}
			}

			if (!isXmlToCode) {
				Parser.ParseCodeToXml(
						filePaths, parserName, outputType, outputPath);
			} else {
				Parser.ParseXmlToCode(
						filePaths, parserName, outputType, outputPath);
			}
		}
	}
}