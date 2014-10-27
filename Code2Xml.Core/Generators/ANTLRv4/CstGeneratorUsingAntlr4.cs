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

using System.IO;
using Antlr4.Runtime;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators.ANTLRv4 {
    /// <summary>
    /// Provides common code for processors using Antlr 4.
    /// </summary>
    /// <typeparam name="TParser"></typeparam>
    public abstract class CstGeneratorUsingAntlr4<TParser> : CstGenerator
            where TParser : Parser {
        protected CstGeneratorUsingAntlr4(params string[] extensions) : base(extensions) {}

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
        protected abstract TParser CreateParser(CommonTokenStream stream);

        /// <summary>
        /// Parse source code already given.
        /// </summary>
        /// <param name="parser"></param>
        protected abstract ParserRuleContext Parse(TParser parser);

        private CstNode GenerateSyntaxTree(
                ICharStream charStream, bool throwingParseError = DefaultThrowingParseError) {
            var lexer = CreateLexer(charStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = CreateParser(commonTokenStream);
            var builder = new CstBuilderForAntlr4(parser);
            if (throwingParseError) {
                parser.ErrorHandler = new MyBailErrorStrategy();
            }
            builder.Visit(Parse(parser));
            return builder.FinishParsing();
        }

        public override CstNode GenerateTreeFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateSyntaxTree(new AntlrInputStream(codeReader), throwingParseError);
        }

        public override CstNode GenerateTreeFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateSyntaxTree(new AntlrInputStream(code), throwingParseError);
        }

        public void TryParse(TextReader codeReader) {
            var lexer = CreateLexer(new AntlrInputStream(codeReader));
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = CreateParser(commonTokenStream);
            parser.ErrorHandler = new MyBailErrorStrategy();
            Parse(parser);
        }
    }

    public class MyBailErrorStrategy : DefaultErrorStrategy {
        public override void Recover(Parser recognizer, RecognitionException e) {
            throw new ParseException(e);
        }

        public override IToken RecoverInline(Parser recognizer) {
            var e = new InputMismatchException(recognizer);
            throw new ParseException(recognizer.CurrentToken.ToString(), e);
        }

        public override void Sync(Parser recognizer) {}
    }
}