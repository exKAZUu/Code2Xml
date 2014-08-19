using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code2Xml.Tools.AntlrGrammarConverter {
	public class CSharpParser {
		private bool _isParserSection;
		private bool _isOneOf;
		private readonly HashSet<string> _lexerDict;

		public CSharpParser() {
			_isParserSection = false;
			_isOneOf = false;
			_lexerDict = new HashSet<string>();
		}

		public string Generate(string input) {
			var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
			var builder = new StringBuilder();
			var count = 0;
			foreach (var line in lines) {
				var words = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				if (words.Length == 0) {
					continue;
				}
				if (words[0].StartsWith("B")) {
					if (words[0].StartsWith("B.2")) {
						_isParserSection = true;
					}
					continue;
				}
				if (!char.IsPunctuation(words[0][0]) && words[0].EndsWith(":")) {
					words[0] = words[0].Substring(0, words[0].Length - 1);
					if (count > 0) {
						builder.AppendLine(";");
						count = 0;
					}
					if (!_isParserSection) {
						_lexerDict.Add(words[0]);
					}
					if (words.Length == 3 && words[1] == "one" && words[2] == "of") {
						words = new[] { words[0] };
						_isOneOf = true;
					} else {
						_isOneOf = false;
					}
				}
				count++;
				if (count == 2) {
					builder.Append("\t: ");
				} else if (count >= 3) {
					builder.Append("\t| ");
				}
				var delimiter = _isOneOf ? " | " : " ";
				builder.AppendLine(string.Join(delimiter, words.Select(ProcessWord)));
			}
			return builder.ToString();
		}

		public string ProcessWord(string word) {
			var keywords = new[] {
				"abstract", "as", "base", "bool", "break",
				"byte", "case", "catch", "char", "checked",
				"class", "const", "continue", "decimal", "default",
				"delegate", "do", "double", "else", "enum",
				"event", "explicit", "extern", "false", "finally",
				"fixed", "float", "for", "foreach", "goto",
				"if", "implicit", "in", "", "int", "interface",
				"internal", "is", "", "lock", "long", "namespace",
				"new", "null", "object", "operator", "out",
				"override", "params", "private", "protected", "public",
				"readonly", "ref", "return", "sbyte", "sealed",
				"short", "sizeof", "stackalloc", "static", "string",
				"struct", "switch", "this", "throw", "true",
				"try", "typeof", "uint", "ulong", "unchecked",
				"unsafe", "ushort", "using", "virtual", "void",
				"volatile", "while",
			};
			var suffix = "";
			if (word.EndsWith("opt")) {
				word = word.Substring(0, word.Length - 3);
				suffix = "?";
			}
			if (word.Length >= 4 && !keywords.Contains(word)) {
				var ret = "";
				for (int i = 0; i < word.Length; i++) {
					if (word[i] == '-') {
						ret += char.ToUpper(word[++i]);
					} else {
						ret += word[i];
					}
				}
				if (!_isParserSection || _lexerDict.Contains(word)) {
					ret = char.ToUpper(ret[0]) + ret.Substring(1);
				}
				word = ret;
			} else {
				word = "'" + word + "'";
			}
			return word + suffix;
		}
	}
}