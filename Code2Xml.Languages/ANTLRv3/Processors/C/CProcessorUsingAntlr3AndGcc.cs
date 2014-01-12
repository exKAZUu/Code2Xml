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

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Core;
using Code2Xml.Core.Processors;

namespace Code2Xml.Languages.ANTLRv3.Processors.C {
	/// <summary>
	/// Represents a C parser and a C code generator using GCC as a preprocessor.
	/// </summary>
	[Export(typeof(Processor))]
	public class CProcessorUsingAntlr3AndGcc : CProcessorUsingAntlr3 {
		private readonly string _defaultWorkingDirectory;

		public CProcessorUsingAntlr3AndGcc() {
			_defaultWorkingDirectory = null;
		}

		public CProcessorUsingAntlr3AndGcc(string defaultWorkingDirectory) {
			_defaultWorkingDirectory = defaultWorkingDirectory;
		}

		public override XElement GenerateXml(
				TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
			return GenerateXml(codeReader.ReadToEnd(), throwingParseError);
		}

		public override XElement GenerateXml(
				string code, bool throwingParseError = DefaultThrowingParseError) {
			return base.GenerateXml(
					PreprocessCode(code, _defaultWorkingDirectory), throwingParseError);
		}

		//public static IEnumerable<string> PreprocessCode(
		//		DirectoryInfo dirInfo, string fileSearchPattern, string workingDirectory = null) {
		//	foreach (var fileInfo in dirInfo.GetFiles(fileSearchPattern, SearchOption.AllDirectories)) {
		//		yield return ExternalProgramUtils.Invoke(
		//				string.Empty, "gcc", new[] { "-E", "-P", "-", fileInfo.FullName },
		//				workingDirectory ?? dirInfo.FullName);
		//	}
		//}

		//public static string PreprocessCode(FileInfo fileInfo, string workingDirectory = null) {
		//	return ExternalProgramUtils.Invoke(
		//			string.Empty, "gcc", new[] { "-E", "-P", "-", fileInfo.FullName },
		//			workingDirectory ?? fileInfo.DirectoryName);
		//}

		public static string PreprocessCode(string code, string workingDirectory) {
			var dirs = Directory.EnumerateDirectories(workingDirectory, "*", SearchOption.AllDirectories);
			var args = dirs.Select(dir => "-I" + dir).Concat(new[] { "-E", "-P", "-" });
			return ExternalProgramUtils.Invoke(
					code, "gcc", args, workingDirectory);
		}
	}
}