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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Paraiba.Core;

namespace Code2Xml.Core.Processors {
	public static class ExternalProgramUtils {
        private static readonly Encoding Encoding = new UTF8Encoding(false);

        public static string Invoke(string input, string filePath, IEnumerable<string> arguments, string workingDirectory) {
            var info = new ProcessStartInfo {
                FileName = filePath,
                Arguments = arguments.JoinString(" "),
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding,
                StandardErrorEncoding = Encoding,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = workingDirectory,
            };
            using (var p = Process.Start(info)) {
                using (var write = new StreamWriter(p.StandardInput.BaseStream, Encoding)) {
                    write.Write(input);
                }
                var result = p.StandardOutput.ReadToEnd();
                Debug.WriteLine(p.StandardError.ReadToEnd());
                return result;
            }
		}

		public static string GetPythonPath(params string[] versions) {
			IEnumerable<string> paths;
			// Check whether running OS is Unix/Linux
			if (!ParaibaEnvironment.OnUnixLike()) {
				var path = TryGetPythonPathFromRegistry(versions);
				if (path != null) {
					return path;
				}
				paths = FindOnWindows("python", versions);
			} else {
				paths = FindOnUnixLike("python", versions);
			}
			return paths.Select(path => Tuple.Create(path, GetVersion(path, "-v")))
					.Where(t => versions.Any(version => t.Item2.Replace(".", "").StartsWith(version)))
					.OrderByDescending(t => t.Item2)
					.Select(t => t.Item1)
					.FirstOrDefault();
		}

		public static string GetRubyPath(params string[] versions) {
			// Check whether running OS is Unix/Linux
			var paths = ParaibaEnvironment.OnUnixLike()
					? FindOnUnixLike("ruby", versions) : FindOnWindows("ruby", versions, "bin");
			return paths.OrderByDescending(path => GetVersion(path, "-v"))
					.FirstOrDefault();
		}

		private static string TryGetPythonPathFromRegistry(IList<string> versions) {
			if (versions.Count == 0) {
				versions = new[] { "" };
			}
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
						.Where(s => versions.Any(s.StartsWith))
						.OrderByDescending(s => s)
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

		private static IEnumerable<string> FindOnWindows(
				string dirName, IList<string> versions, string cmdDirName = null, string cmdName = null) {
			if (versions.Count == 0) {
				versions = new[] { "" };
			}
			cmdName = (cmdName ?? dirName);
			var pathVariable = Environment.GetEnvironmentVariable(
					"Path",
					EnvironmentVariableTarget.Process) ?? "";
			return Directory.GetLogicalDrives()
					.Where(Directory.Exists)
					.SelectMany(
							dirPath => versions.SelectMany(
									version => Directory.EnumerateDirectories(dirPath, dirName + version + "*")
											.Select(p => cmdDirName != null ? Path.Combine(p, cmdDirName) : p)))
					.Concat(pathVariable.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
					.Select(dirPath => Path.Combine(dirPath, cmdName + ".exe"))
					.Where(File.Exists);
		}

		private static IEnumerable<string> FindOnUnixLike(string cmdName, IEnumerable<string> versions) {
			var names = new[] { cmdName, cmdName + ".exe" }
					.Concat(versions.Select(version => cmdName + version));
			var pathVariable = Environment.GetEnvironmentVariable(
					"PATH",
					EnvironmentVariableTarget.Process) ?? "";
			return new[] { @"/usr/bin", @"/usr/local/bin" }
					.Concat(pathVariable.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
					.SelectMany(dirPath => names.Select(name => Path.Combine(dirPath, name)))
					.Where(File.Exists);
		}

		private static string GetVersion(string path, params string[] arguments) {
			var info = new ProcessStartInfo {
				FileName = path,
				Arguments = arguments.JoinString(" "),
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				UseShellExecute = false,
			};
			using (var p = Process.Start(info)) {
				var result = p.StandardOutput.ReadToEnd();
				return result.Split(' ').FirstOrDefault(s => s.Contains(".")) ?? "";
			}
		}
	}
}