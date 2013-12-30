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
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Antlr.Runtime;
using Code2Xml.Core;

namespace Code2Xml.Languages.ANTLRv3.Core {
	/// <summary>
	/// Provides common code for processors using Antlr 3.
	/// </summary>
	/// <typeparam name="TParser"></typeparam>
	public abstract class ProcessorUsingAntlr3<TParser> : Processor
			where TParser : ICustomizedAntlr3Parser {
		public bool ThrowingParseError { get; set; }

		protected ProcessorUsingAntlr3(params string[] extensions) : base(extensions) {
			ThrowingParseError = false;
		}

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
					var attr = e.Attribute(Code2XmlConstants.HiddenAttributeName);
					builder.Append(attr == null ? e.Value : attr.Value);
				}
			}
		}

		/// <summary>
		/// Creates and returns a lexer.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		protected abstract ITokenSource CreateLexer(ICharStream stream);

		/// <summary>
		/// Creates and returns a parser.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		protected abstract TParser CreateParser(ITokenStream stream);

		/// <summary>
		/// Parse source code already given.
		/// </summary>
		/// <param name="parser"></param>
		protected abstract Antlr3AstNode Parse(TParser parser);

		/// <summary>
		/// Creates a token stream which provides tokenized code.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		private CommonTokenStream CreateTokenStream(ICharStream stream) {
			var lexer = CreateLexer(stream);
			return new CommonTokenStream(lexer);
		}

		/// <summary>
		/// Creates a token stream which provides tokenized code.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public CommonTokenStream CreateTokenStream(string code) {
			return CreateTokenStream(new ANTLRStringStream(code));
		}

		/// <summary>
		/// Creates a token stream which provides tokenized code.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public CommonTokenStream CreateTokenStream(TextReader reader) {
			return CreateTokenStream(new ANTLRReaderStream(reader));
		}

		/// <summary>
		/// Generates a xml from the specified char stream of the source code.
		/// </summary>
		/// <param name="charStream"></param>
		/// <param name="throwingParseError"></param>
		/// <returns></returns>
		protected XElement GenerateXml(
				ICharStream charStream, bool throwingParseError = DefaultThrowingParseError) {
			var tokenStream = CreateTokenStream(charStream);
			var parser = CreateParser(tokenStream);
			var builder = throwingParseError ?
					new Antlr3AstBuilderWithReportingError(tokenStream, parser.TokenNames) :
					new Antlr3AstBuilder(tokenStream, parser.TokenNames);
			parser.TraceDestination = Console.Error;
			parser.TreeAdaptor = builder;
			var tokens = tokenStream.GetTokens();
			foreach (var token in tokens) {
				Console.WriteLine(token);
			}
			var root = Parse(parser);
			Console.WriteLine("-----------------------------------------");
			tokens = tokenStream.GetTokens();
			foreach (var token in tokens) {
				Console.WriteLine(token);
			}
			return builder.FinishParsing(root.Element);
		}

		/// <summary>
		/// Generates a xml from the specified text of the source code.
		/// </summary>
		/// <param name="code"></param>
		/// <param name="throwingParseError"></param>
		/// <returns></returns>
		public override XElement GenerateXml(
				string code, bool throwingParseError = DefaultThrowingParseError) {
			return GenerateXml(new ANTLRStringStream(code), throwingParseError);
		}

		/// <summary>
		/// Generates a xml from the specified <c>TextReader</c> which reads the source code.
		/// </summary>
		/// <param name="codeReader"></param>
		/// <param name="throwingParseError"></param>
		/// <returns></returns>
		public override XElement GenerateXml(
				TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
			return GenerateXml(new ANTLRReaderStream(codeReader), throwingParseError);
		}
	}
}