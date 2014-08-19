using System;
using System.Collections.Generic;
using System.Text;

namespace Code2Xml.Tools.AntlrGrammarConverter {
	internal class PhpLexer {
		public string Generate(string input) {
			var ret = new StringBuilder();
			var names = new HashSet<string>();
			foreach (var line in input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)) {
				var head = line.IndexOf('\'');
				var tail = line.LastIndexOf('\'');
				var token = line.Substring(head + 1, tail - head - 1);
				var newToken = "";
				foreach (var ch in token) {
					if (char.IsLetter(ch)) {
						newToken += "('" + char.ToLower(ch) + "'|'" + char.ToUpper(ch) + "')";
					} else {
						newToken += "'" + ch + "'";
					}
				}
				ret.AppendLine(line.Replace('\'' + token + '\'', newToken));

				var colon = line.IndexOf(':');
				names.Add(line.Substring(0, colon).Trim());
			}
			ret.AppendLine(string.Join("|", names));
			return ret.ToString();
		}
	}
}