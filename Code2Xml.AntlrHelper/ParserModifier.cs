using System.Diagnostics.Contracts;
using System.IO;
using System.Text.RegularExpressions;
using Paraiba.Text;

namespace Code2Xml.AntlrHelper {
	public static class ParserModifier {
		private static readonly Regex SystemOutRegex =
			new Regex(@"System\.out\.println[^;]+;");

		private static readonly Regex NonTerminalRegex =
			new Regex(@"adaptor\.AddChild\(([^,]*), (.*)\.Tree\)");

		private static readonly Regex TerminalRegex =
			new Regex(@"adaptor\.Create\(([^),]*)\)");

		private static readonly Regex MatchRegex =
			new Regex(@"Match\(input,([^\d][^,]*),[^)]*\)");

		private static readonly Regex PrivateRegex =
			new Regex(@"private ([^.]*Parser)\.");

		public static void Modify(string path) {
			Contract.Requires(path != null);

			string code;
			using (var reader = new StreamReader(path, XEncoding.SJIS)) {
				code = reader.ReadToEnd();
				code = ModifyInheritClass(code);
				code = ModifyFromJavaToCSharp(code);
				code = ModifyCommonTreeAdaptorRegex(code);
				code = ModifyReturnScope(code);
				code = ModifyForNonTerminalNode(code);
				code = ModifyForTerminalNode(code);
				code = ModifyAccessModifier(code);
			}
			using (var writer = new StreamWriter(path, false, XEncoding.SJIS)) {
				writer.WriteLine("using Code2Xml.Core.Antlr;");
				writer.WriteLine("using System;");
				writer.Write(code);
			}
		}

		public static string ModifyFromJavaToCSharp(string code) {
			Contract.Requires(code != null);

			return SystemOutRegex.Replace(code, "");
		}

		public static string ModifyCommonTreeAdaptorRegex(string code) {
			Contract.Requires(code != null);

			return code
				.Replace("ITreeAdaptor", "XmlTreeAdaptor")
				.Replace("CommonTreeAdaptor", "XmlTreeAdaptor");
		}

		public static string ModifyReturnScope(string code) {
			Contract.Requires(code != null);

			return code.Replace(
				": ParserRuleReturnScope<IToken>", ": XParserRuleReturnScope");
		}

		public static string ModifyForNonTerminalNode(string code) {
			Contract.Requires(code != null);

			return NonTerminalRegex.Replace(
				code,
				@"adaptor.AddChild($1, $2.Tree, $2, retval)");
		}

		public static string ModifyForTerminalNode(string code) {
			Contract.Requires(!new Regex(@"adaptor\.Create\(([^)]*),").IsMatch(code));

			code = MatchRegex.Replace(code, "new XToken((IToken)$0, \"$1\")");
			return TerminalRegex.Replace(code, @"adaptor.Create($1, retval)");
		}

		public static string ModifyAccessModifier(string code) {
			Contract.Requires(code != null);

			return PrivateRegex.Replace(code, "public $1.");
		}

		public static string ModifyInheritClass(string code) {
			Contract.Requires(code != null);

			return code.Replace(" : Antlr.Runtime.Parser",
				" : Antlr.Runtime.Parser, IAntlrParser");
		}
	}
}