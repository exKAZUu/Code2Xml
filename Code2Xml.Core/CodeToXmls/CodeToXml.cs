#region License

// Copyright (C) 2009-2013 Kazunori Sakamoto
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

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Paraiba.Text;

namespace Code2Xml.Core.CodeToXmls {
	public abstract class CodeToXml<TCodeToXml> : CodeToXml
			where TCodeToXml : CodeToXml, new() {
		private static TCodeToXml _instance;

		public static TCodeToXml Instance {
			get { return (_instance = _instance ?? new TCodeToXml()); }
		}
	}

	[ContractClass(typeof(CodeToXmlContract))]
	public abstract class CodeToXml {
		public const bool DefaultThrowingParseError = false;
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		public XElement GenerateFromFile(
				string path, Encoding encoding,
				bool throwingParseError) {
			Contract.Requires(path != null);
			using (var reader = new StreamReader(path, encoding)) {
				return Generate(reader, throwingParseError);
			}
		}

		public XElement GenerateFromFile(string path, bool throwingParseError) {
			Contract.Requires(path != null);
			return Generate(GuessEncoding.ReadAllText(path), throwingParseError);
		}

		public abstract XElement Generate(
				TextReader reader, bool throwingParseError);

		public virtual XElement Generate(string code, bool throwingParseError) {
			Contract.Requires(code != null);
			using (var reader = new StringReader(code)) {
				return Generate(reader, throwingParseError);
			}
		}

		public XElement GenerateFromFile(string path, Encoding encoding) {
			Contract.Requires(path != null);
			return GenerateFromFile(path, encoding, DefaultThrowingParseError);
		}

		public XElement GenerateFromFile(string path) {
			Contract.Requires(path != null);
			return GenerateFromFile(path, DefaultThrowingParseError);
		}

		public XElement Generate(TextReader reader) {
			Contract.Requires(reader != null);
			return Generate(reader, DefaultThrowingParseError);
		}

		public XElement Generate(string code) {
			Contract.Requires(code != null);
			return Generate(code, DefaultThrowingParseError);
		}
	}
}