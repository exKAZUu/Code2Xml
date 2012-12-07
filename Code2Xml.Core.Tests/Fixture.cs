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

namespace Code2Xml.Core.Tests {
	public static class Fixture {
		public static string FixturePath = Path.Combine("..", "..", "fixture");
		public static string ExpectationName = "expectation";
		public static string InputName = "input";
		public static string FailedInputName = "failed_input";
		public static string OutputName = "output";
		public static string XmlExpectationName = "xmlexpectation";

		public static string GetInputPath(string lang, params string[] names) {
			var path = Path.Combine(FixturePath, lang, InputName);
			return Path.GetFullPath(names.Aggregate(path, Path.Combine));
		}

		public static string GetFailedInputPath(string lang, params string[] names) {
			var path = Path.Combine(FixturePath, lang, FailedInputName);
			return Path.GetFullPath(names.Aggregate(path, Path.Combine));
		}

		public static string GetOutputDirPath(string lang) {
			var path = Path.Combine(FixturePath, lang, OutputName);
			Directory.CreateDirectory(path);
			return Path.GetFullPath(path);
		}

		public static string GetOutputFilePath(string lang, string fileName) {
			return Path.GetFullPath(Path.Combine(GetOutputDirPath(lang), fileName));
		}

		public static string GetExpectationPath(string lang, params string[] names) {
			var path = Path.Combine(FixturePath, lang, ExpectationName);
			return Path.GetFullPath(names.Aggregate(path, Path.Combine));
		}

		public static string GetXmlExpectationPath(string lang, params string[] names) {
			var path = Path.Combine(FixturePath, lang, XmlExpectationName);
			return Path.GetFullPath(names.Aggregate(path, Path.Combine));
		}
	}
}