using System.IO;
using System.Linq;

namespace Code2Xml.AntlrHelper {
	internal class Program {
		private static void Main(string[] args) {
			foreach (var arg in args) {
				var path = Path.GetFullPath(arg);
				var dir = Directory.Exists(path) ? path : Path.GetDirectoryName(path);
				var parser = Directory.EnumerateFiles(dir, "*Parser.cs").First();
				var lexer = Directory.EnumerateFiles(dir, "*Lexer.cs").First();
				ParserModifier.Modify(parser);
				LexerModifier.Modify(lexer);
			}
		}
	}
}