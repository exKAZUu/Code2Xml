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
using Microsoft.Win32;

namespace Code2Xml.Core {
	public static class ParserUtil {
		public static string GetPythonInstallPath(string versionPrefix) {
			const string name = @"SOFTWARE\Python\PythonCore";
			var versionKey = Registry.CurrentUser.OpenSubKey(name) ??
			                 Registry.LocalMachine.OpenSubKey(name);
			if (versionKey == null) {
				return null;
			}
			var subKeyName = versionKey.GetSubKeyNames()
					.Where(s => s.StartsWith(versionPrefix))
					.OrderByDescending(
							s => s.Split('.')
							     		.Aggregate(
							     				"",
							     				(s1, s2) =>
							     				s1 + s2.PadLeft(4, '0')))
					.FirstOrDefault();
			if (subKeyName == null) {
				return null;
			}
			var pathKey = versionKey.OpenSubKey(subKeyName + @"\InstallPath");
			if (pathKey == null) {
				var path = Path.Combine(
						"C:",
						"Python" + subKeyName.Replace(".", "") + "Python.exe");
				return File.Exists(path) ? path : null;
			}
			var dirPath = pathKey.GetValue(null) as string;
			if (dirPath == null) {
				return null;
			}
			return Path.Combine(dirPath, "Python.exe");
		}
	}
}