using System.Diagnostics.Contracts;
using System.IO;
using Paraiba.Text;

namespace Code2Xml.AntlrHelper {
	public static class LexerModifier {
		public static void Modify(string path) {
			Contract.Requires(path != null);

			string code;
			using (var reader = new StreamReader(path, XEncoding.SJIS)) {
				code = reader.ReadToEnd();
				code = ModifyFromJavaToCSharp(code);
			}
			using (var writer = new StreamWriter(path, false, XEncoding.SJIS)) {
				writer.WriteLine("using Code2Xml.Core.Antlr;");
				writer.Write(code);
			}
		}

		public static string ModifyFromJavaToCSharp(string code) {
			Contract.Requires(code != null);

			return code.Replace("skip();", "Skip();")
					.Replace("HIDDEN", "Hidden");
		}
	}
}