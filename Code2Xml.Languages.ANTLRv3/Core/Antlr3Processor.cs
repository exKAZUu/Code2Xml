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
using System.Text;
using System.Xml.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Processors;

namespace Code2Xml.Languages.ANTLRv3.Core {
	public abstract class Antlr3Processor : LanguageProcessor {
		protected Antlr3Processor(params string[] extensions) : base(extensions) {}

		/// <summary>
		/// Generates source code from the specified xml.
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public override string GenerateCode(XElement root) {
			var builder = new StringBuilder();
			GenerateCode(builder, root);
			return builder.ToString();
		}

		private void GenerateCode(StringBuilder builder, XContainer element) {
			Contract.Requires(element != null);
			foreach (var e in element.Elements()) {
				if (e.HasElements) {
					GenerateCode(builder, e);
				} else {
					builder.Append(e.Value);
				}
			}
		}

		protected abstract XElement GenerateXml(
				ICharStream charStream, bool throwingParseError = DefaultThrowingParseError,
				bool enablePosition = DefaultEnablePosition);

		/// <summary>
		/// Generates a xml from the specified text of the source code.
		/// </summary>
		/// <param name="code"></param>
		/// <param name="throwingParseError"></param>
		/// <param name="enablePosition"></param>
		/// <returns></returns>
		public override XElement GenerateXml(
				string code, bool throwingParseError = DefaultThrowingParseError,
				bool enablePosition = DefaultEnablePosition) {
			return GenerateXml(new ANTLRStringStream(code), throwingParseError, enablePosition);
		}

		/// <summary>
		/// Generates a xml from the specified <c>TextReader</c> which reads the source code.
		/// </summary>
		/// <param name="codeReader"></param>
		/// <param name="throwingParseError"></param>
		/// <param name="enablePosition"></param>
		/// <returns></returns>
		public override XElement GenerateXml(
				TextReader codeReader, bool throwingParseError = DefaultThrowingParseError,
				bool enablePosition = DefaultEnablePosition) {
			return GenerateXml(codeReader.ReadToEnd(), throwingParseError, enablePosition);
		}
	}
}