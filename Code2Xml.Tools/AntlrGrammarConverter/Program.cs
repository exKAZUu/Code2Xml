using System.IO;

namespace Code2Xml.Tools.AntlrGrammarConverter {
	internal class Program {
		private static void Main(string[] args) {
			var input = File.ReadAllText(@"C:\Users\exKAZUu\Desktop\php.txt");
			var output = new PhpLexer().Generate(input);
			File.WriteAllText(@"C:\Users\exKAZUu\Desktop\php2.txt", output);
		}
	}
}