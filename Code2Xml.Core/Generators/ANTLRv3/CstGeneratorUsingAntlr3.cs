#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
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
using System.IO;
using Antlr.Runtime;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators.ANTLRv3 {
    /// <summary>
    /// Provides common code for processors using Antlr 3.
    /// </summary>
    /// <typeparam name="TParser"></typeparam>
    public abstract class CstGeneratorUsingAntlr3<TParser> : CstGenerator
            where TParser : ICustomizedAntlr3Parser {
        public bool ThrowingParseError { get; set; }

        protected CstGeneratorUsingAntlr3(params string[] extensions) : base(extensions) {
            ThrowingParseError = false;
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
        protected abstract Antlr3CstNode Parse(TParser parser);

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
        protected CstNode GenerateSyntaxTree(
                ICharStream charStream, bool throwingParseError = DefaultThrowingParseError) {
            var tokenStream = CreateTokenStream(charStream);
            var parser = CreateParser(tokenStream);
            var builder = throwingParseError ?
                    new CstBuilderForAntlr3WithReportingError(tokenStream, parser.TokenNames) :
                    new CstBuilderForAntlr3(tokenStream, parser.TokenNames);
            parser.TraceDestination = Console.Error;
            parser.TreeAdaptor = builder;
            var root = Parse(parser);
            return builder.FinishParsing(root.Node);
        }

        /// <summary>
        /// Generates a syntax tree from the specified text of the source code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public override CstNode GenerateTreeFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateSyntaxTree(new ANTLRStringStream(code), throwingParseError);
        }

        /// <summary>
        /// Generates a syntax tree from the specified <c>TextReader</c> which reads the source code.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public override CstNode GenerateTreeFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateSyntaxTree(new ANTLRReaderStream(codeReader), throwingParseError);
        }
 
        public void TryParse(TextReader codeReader) {
            var tokenStream = CreateTokenStream(codeReader);
            var parser = CreateParser(tokenStream);
            parser.TraceDestination = Console.Error;
            parser.TreeAdaptor = new ExperimentalCstBuilderForAntlr3();
            Parse(parser);
       }
    }
}