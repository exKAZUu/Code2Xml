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

using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Code2Xml.Core.Processors;
using Code2Xml.Core.XmlToCodes;
using Paraiba.Text;

namespace Code2Xml.Core.CodeToXmls {
	/// <summary>
	/// Please use <see cref="Processor"/> class.
	/// </summary>
	[Obsolete]
	public abstract class CodeToXml<TCodeToXml> : CodeToXml
			where TCodeToXml : CodeToXml, new() {
		private static TCodeToXml _instance;

		public static TCodeToXml Instance {
			get { return (_instance = _instance ?? new TCodeToXml()); }
		}
	}

	/// <summary>
	/// Please use <see cref="Processor"/> class.
	/// </summary>
	[Obsolete]
	[ContractClass(typeof(CodeToXmlContract))]
	public abstract class CodeToXml {
		public const bool DefaultThrowingParseError = false;
		public const bool DefaultEnablePosition = true;

		public abstract string ParserName { get; }
		public abstract ReadOnlyCollection<string> TargetExtensions { get; }
		public abstract XmlToCode XmlToCode { get; }

		public XElement GenerateFromFile(
				string path, Encoding encoding,
				bool throwingParseError = DefaultThrowingParseError, bool enablePosition = DefaultEnablePosition) {
			Contract.Requires(path != null);
			using (var reader = new StreamReader(path, encoding)) {
				return Generate(reader, throwingParseError, enablePosition);
			}
		}

		public XElement GenerateFromFile(
				string path,
				bool throwingParseError = DefaultThrowingParseError, bool enablePosition = DefaultEnablePosition) {
			Contract.Requires(path != null);
			return Generate(GuessEncoding.ReadAllText(path), throwingParseError, enablePosition);
		}

		public XElement GenerateFromFile(
				FileInfo file, Encoding encoding,
				bool throwingParseError = DefaultThrowingParseError, bool enablePosition = DefaultEnablePosition) {
			Contract.Requires(file != null);
			return GenerateFromFile(file.FullName, encoding, throwingParseError, enablePosition);
		}

		public XElement GenerateFromFile(
				FileInfo file,
				bool throwingParseError = DefaultThrowingParseError, bool enablePosition = DefaultEnablePosition) {
			Contract.Requires(file != null);
			return GenerateFromFile(file.FullName, throwingParseError, enablePosition);
		}

		public abstract XElement Generate(
				TextReader reader,
				bool throwingParseError = DefaultThrowingParseError, bool enablePosition = DefaultEnablePosition);

		public virtual XElement Generate(
				string code,
				bool throwingParseError = DefaultThrowingParseError, bool enablePosition = DefaultEnablePosition) {
			Contract.Requires(code != null);
			using (var reader = new StringReader(code)) {
				return Generate(reader, throwingParseError, enablePosition);
			}
		}
	}
}