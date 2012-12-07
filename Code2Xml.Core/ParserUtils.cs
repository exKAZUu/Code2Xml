﻿#region License

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
using System.Linq;
using Microsoft.Win32;
using Paraiba.Core;

namespace Code2Xml.Core {
	public static class ParserUtils {
		private static string TryGetPythonPathFromRegistry(int version) {
			var names = new[] {
					@"SOFTWARE\Python\PythonCore",
					@"SOFTWARE\Wow6432Node\Python\PythonCore",
			};
			foreach (var name in names) {
				var versionKey = Registry.CurrentUser.OpenSubKey(name) ??
						Registry.LocalMachine.OpenSubKey(name);
				if (versionKey == null) {
					continue;
				}
				var subKeyName = versionKey.GetSubKeyNames()
						.Where(s => s.StartsWith(version.ToString()))
						.OrderByDescending(
								s => s.Split('.')
										.Aggregate(
												"",
												(s1, s2) =>
														s1 + s2.PadLeft(4, '0')))
						.FirstOrDefault();
				if (subKeyName == null) {
					continue;
				}
				var pathKey = versionKey.OpenSubKey(subKeyName + @"\InstallPath");
				if (pathKey == null) {
					var path = Path.Combine(
							"C:",
							"Python" + subKeyName.Replace(".", "") + "Python.exe");
					if (!File.Exists(path)) {
						continue;
					}
					return path;
				}
				var dirPath = pathKey.GetValue(null) as string;
				if (dirPath == null) {
					continue;
				}
				return Path.Combine(dirPath, "python.exe");
			}
			return null;
		}

		public static string GetPythonPath(int version) {
			// Check whether running OS is Unix/Linux
			if (!ParaibaEnvironment.OnMono()) {
				var path = TryGetPythonPathFromRegistry(version);
				if (path != null) {
					return path;
				}

				var pathVariable = Environment.GetEnvironmentVariable(
						"Path",
						EnvironmentVariableTarget.Process) ?? "";
				var dirPaths = new[] { @"C:", @"D:" }.Concat(pathVariable.Split(';'));
				foreach (var dirPath in dirPaths) {
					var pythonDirPath = Directory.EnumerateDirectories(dirPath, "Python" + version + "*")
							.OrderByDescending(f => f)
							.FirstOrDefault();
					if (pythonDirPath != null) {
						return Path.Combine(pythonDirPath, "python.exe");
					}
				}
			} else {
				var pythonNames = new[] { "python" + version, "python" };
				foreach (var pythonName in pythonNames) {
					var pathVariable = Environment.GetEnvironmentVariable(
							"PATH",
							EnvironmentVariableTarget.Process) ?? "";
					var dirPaths = new[] { @"/usr/bin", @"/usr/local/bin" }.Concat(pathVariable.Split(':'));
					foreach (var dirPath in dirPaths) {
						var path = Path.Combine(dirPath, pythonName);
						if (File.Exists(path)) {
							return path;
						}
					}
				}
			}
			return null;
		}
	}
}