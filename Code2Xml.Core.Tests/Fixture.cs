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
			return names.Aggregate(path, Path.Combine);
		}

		public static string GetFailedInputPath(string lang, params string[] names) {
			var path = Path.Combine(FixturePath, lang, FailedInputName);
			return names.Aggregate(path, Path.Combine);
		}

		public static string GetOutputDirPath(string lang) {
			var path = Path.Combine(FixturePath, lang, OutputName);
			Directory.CreateDirectory(path);
			return path;
		}

		public static string GetOutputFilePath(string lang, string fileName) {
			return Path.Combine(GetOutputDirPath(lang), fileName);
		}

		public static string GetExpectationPath(string lang, params string[] names) {
			var path = Path.Combine(FixturePath, lang, ExpectationName);
			return names.Aggregate(path, Path.Combine);
		}

		public static string GetXmlExpectationPath(string lang, params string[] names) {
			var path = Path.Combine(FixturePath, lang, XmlExpectationName);
			return names.Aggregate(path, Path.Combine);
		}
	}
}