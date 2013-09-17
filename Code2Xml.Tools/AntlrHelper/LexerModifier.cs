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

using System.Diagnostics.Contracts;
using System.IO;
using Paraiba.Text;

namespace Code2Xml.Tools.AntlrHelper {
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