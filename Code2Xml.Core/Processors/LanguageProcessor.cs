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

using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Paraiba.Text;

namespace Code2Xml.Core.Processors {
	/// <summary>
	/// Represents a language processor for inter-converting source code and a xml representing an abstract syntax tree.
	/// </summary>
	public abstract class LanguageProcessor {
		public const bool DefaultThrowingParseError = false;
		public const bool DefaultEnablePosition = true;

		/// <summary>
		/// Gets the full language name including the version.
		/// </summary>
		public string FullLanguageName {
			get { return LanguageName + " " + LanguageVersion; }
		}

		/// <summary>
		/// Gets the language name except for the version.
		/// </summary>
		public abstract string LanguageName { get; }

		/// <summary>
		/// Gets the language version.
		/// </summary>
		public abstract string LanguageVersion { get; }

		/// <summary>
		/// Gets the extensions of the supported languages.
		/// </summary>
		public ReadOnlyCollection<string> SupportedExtensions { get; private set; }

		/// <summary>
		/// Gets the default extension of the supported language.
		/// </summary>
		public string DefaultExtension {
			get { return SupportedExtensions[0]; }
		}

		protected LanguageProcessor(params string[] extensions) {
			SupportedExtensions = extensions.ToList().AsReadOnly();
		}

		#region GenerateCode

		/// <summary>
		/// Generates source code from the specified xml.
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public abstract string GenerateCode(XElement root);

		/// <summary>
		/// Generates source code from the specified xml.
		/// </summary>
		/// <param name="xdoc"></param>
		/// <returns></returns>
		public string GenerateCode(XDocument xdoc) {
			Contract.Requires(xdoc != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return GenerateCode(xdoc.Root);
		}

		/// <summary>
		/// Generates source code from the specified <c>TextReader</c> instance which read a xml.
		/// </summary>
		/// <param name="xmlReader"></param>
		/// <returns></returns>
		public string GenerateCode(TextReader xmlReader) {
			Contract.Requires(xmlReader != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return GenerateCode(XDocument.Load(xmlReader));
		}

		/// <summary>
		/// Generates source code from the specified xml text.
		/// </summary>
		/// <param name="xmlText"></param>
		/// <returns></returns>
		public string GenerateCode(string xmlText) {
			Contract.Requires(xmlText != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return GenerateCode(XDocument.Parse(xmlText));
		}

		/// <summary>
		/// Generates source code from the specified xml file and encoding.
		/// </summary>
		/// <param name="xmlFile"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public string GenerateCode(FileInfo xmlFile, Encoding encoding = null) {
			Contract.Requires(xmlFile != null);
			Contract.Ensures(Contract.Result<string>() != null);
			if (encoding == null) {
				return GenerateCode(GuessEncoding.ReadAllText(xmlFile.FullName));
			}
			using (var stream = new StreamReader(xmlFile.FullName, encoding)) {
				return GenerateCode(stream);
			}
		}

		#endregion

		#region GenerateXml

		/// <summary>
		/// Generates a xml from the specified text of the source code.
		/// </summary>
		/// <param name="code"></param>
		/// <param name="throwingParseError"></param>
		/// <returns></returns>
		public abstract XElement GenerateXml(
				string code,
				bool throwingParseError = DefaultThrowingParseError);

		/// <summary>
		/// Generates a xml from the specified <c>TextReader</c> which reads the source code.
		/// </summary>
		/// <param name="codeReader"></param>
		/// <param name="throwingParseError"></param>
		/// <returns></returns>
		public abstract XElement GenerateXml(
				TextReader codeReader,
				bool throwingParseError = DefaultThrowingParseError);

		/// <summary>
		/// Generates a xml from the specified file of the source code and the specified encoding.
		/// </summary>
		/// <param name="codeFile"></param>
		/// <param name="encoding"></param>
		/// <param name="throwingParseError"></param>
		/// <returns></returns>
		public XElement GenerateXml(
				FileInfo codeFile, Encoding encoding = null,
				bool throwingParseError = DefaultThrowingParseError) {
			Contract.Requires(codeFile != null);
			if (encoding == null) {
				return GenerateXml(
						GuessEncoding.ReadAllText(codeFile.FullName), throwingParseError);
			}
			using (var reader = new StreamReader(codeFile.FullName, encoding)) {
				return GenerateXml(reader, throwingParseError);
			}
		}

		#endregion
	}
}