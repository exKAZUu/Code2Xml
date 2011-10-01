using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace Code2Xml.Core {
	public static class Settings {
		public static string GetPythonInstallPath(string versionPrefix) {
			const string name = @"SOFTWARE\Python\PythonCore";
			var versionKey = Registry.CurrentUser.OpenSubKey(name) ??
			                 Registry.LocalMachine.OpenSubKey(name);
			if (versionKey == null)
				return null;
			var subKeyName = versionKey.GetSubKeyNames()
					.Where(s => s.StartsWith(versionPrefix))
					.OrderByDescending(
							s => s.Split('.')
							     		.Aggregate("", (s1, s2) => s1 + s2.PadLeft(4, '0')))
					.FirstOrDefault();
			if (subKeyName == null)
				return null;
			var pathKey = versionKey.OpenSubKey(subKeyName + @"\InstallPath");
			var dirPath = pathKey.GetValue(null) as string;
			if (dirPath == null)
				return null;
			return Path.Combine(dirPath, "Python.exe");
		}
	}
}