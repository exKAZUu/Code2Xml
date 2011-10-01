using System;
using System.Collections.Generic;
using System.IO;
using Code2Xml.Core.Plugins;
using Paraiba.Text;

namespace Code2Xml.Console {
	public static class Parser {
		public static void ParseCodeToXml(
				IEnumerable<string> filePaths,
				string parserName, OutputType outputType,
				string outputPath) {
			var getOutPutFunc = GetGetOutputFunc(outputType, outputPath, ".xml");
			foreach (var path in filePaths) {
				var extension = Path.GetExtension(path);
				var parser = parserName != null
				             		? PluginManager.GetCodeToXmlByName(parserName)
				             		: PluginManager.GetCodeToXmlByExtension(extension);
				if (parser == null) {
					continue;
				}
				var ast = parser.GenerateFromFile(path);
				getOutPutFunc.Item1(path, ast.ToString());
			}
			getOutPutFunc.Item2();
		}

		public static void ParseXmlToCode(
				IEnumerable<string> filePaths,
				string parserName, OutputType isOutputFile,
				string outputPath) {
			var parser = PluginManager.GetXmlToCodeByName(parserName);
			var getOutPutFunc = GetGetOutputFunc(
					isOutputFile, outputPath,
					parser.DefaultExtension);
			foreach (var path in filePaths) {
				var code = parser.GenerateFromFile(path);
				getOutPutFunc.Item1(path, code);
			}
			getOutPutFunc.Item2();
		}

		private static Tuple<Action<string, string>, Action> GetGetOutputFunc
				(OutputType outputType, string outPath, string outExtension) {
			Action<string, string> action1;
			Action action2;
			switch (outputType) {
			case OutputType.DefaultStream:
				action1 = (inputPath, content) => System.Console.WriteLine(content);
				action2 = () => { }; // disposer
				break;
			case OutputType.File: {
				var writer = new StreamWriter(outPath, false, XEncoding.SJIS);
				action1 = (inputPath, content) => writer.WriteLine(content);
				action2 = writer.Close; // disposer
				break;
			}
			case OutputType.Directory: {
				action1 = (inputPath, content) => {
					var newPath = Path.Combine(
							outPath ?? Path.GetDirectoryName(inputPath),
							Path.GetFileNameWithoutExtension(inputPath) + outExtension);
					using (var writer = new StreamWriter(newPath, false, XEncoding.SJIS)) {
						writer.WriteLine(content);
					}
				};
				action2 = () => { }; // disposer
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("outputType");
			}
			return Tuple.Create(action1, action2);
		}
	}
}