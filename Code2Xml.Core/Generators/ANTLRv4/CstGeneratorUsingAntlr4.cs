#region License

// Copyright (C) 2011-2016 Kazunori Sakamoto
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
using System.Reflection;
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
        /// Parse the source code already given.
        /// </summary>
        /// <param name="parser"></param>
        protected abstract ParserRuleContext Parse(TParser parser);

        /// <summary>
        /// Parse the fragment of the source code already given.
        /// </summary>
        /// <param name="parser"></param>
        private static ParserRuleContext ParseFragment(TParser parser) {
            var errorHandler = new MemorizingErrorStrategy();
            parser.ErrorHandler = errorHandler;
            parser.InputStream.Mark();
            var methodInfos =
                    parser.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var methodInfo in methodInfos) {
                if (methodInfo.ReturnType.IsSubclassOf(typeof(ParserRuleContext))
                    && methodInfo.GetParameters().Length == 0) {
                    errorHandler.Initialize();
                    parser.Reset();
                    var ret = methodInfo.Invoke(parser, new object[0]);
                    if (!errorHandler.HasErrors) {
                        return (ParserRuleContext)ret;
                    }
                }
            }
            throw errorHandler.LastException;
        }

        private CstNode GenerateSyntaxTree(
            ICharStream charStream, bool parsingCompleteCode, bool throwingParseError) {
            var lexer = CreateLexer(charStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = CreateParser(commonTokenStream);
            var builder = new CstBuilderForAntlr4(parser);
            if (throwingParseError) {
                parser.ErrorHandler = new MyBailErrorStrategy();
            }
            builder.Visit(parsingCompleteCode ? Parse(parser) : ParseFragment(parser));
            return builder.FinishParsing();
        }

        public override CstNode GenerateTreeFromCode(
            TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateSyntaxTree(new AntlrInputStream(codeReader), true, throwingParseError);
        }

        public override CstNode GenerateTreeFromCodeText(
            string code, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateSyntaxTree(new AntlrInputStream(code), true, throwingParseError);
        }

        public override CstNode GenerateTreeFromCodeFragment(TextReader codeReader) {
            return GenerateSyntaxTree(new AntlrInputStream(codeReader), false, false);
        }

        public override CstNode GenerateTreeFromCodeFragmentText(string code) {
            return GenerateSyntaxTree(new AntlrInputStream(code), false, false);
        }

        private void TryParse(ICharStream charStream, bool parsingCompleteCode) {
            var lexer = CreateLexer(charStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = CreateParser(commonTokenStream);
            parser.ErrorHandler = new MyBailErrorStrategy();
            if (parsingCompleteCode) {
                Parse(parser);
            } else {
                ParseFragment(parser);
            }
        }

        /// <summary>
        /// Try to parse the source code which is retrieved from the specified <c>TextReader</c>.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <returns></returns>
        public override void TryParseFromCode(TextReader codeReader) {
            TryParse(new AntlrInputStream(codeReader), true);
        }

        /// <summary>
        /// Try to parse the source code of the specified <c>string</c>.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override void TryParseFromCodeText(string code) {
            TryParse(new AntlrInputStream(code), true);
        }

        public override void TryParseFromCodeFragment(TextReader codeReader) {
            TryParse(new AntlrInputStream(codeReader), false);
        }

        public override void TryParseFromCodeFragmentText(string code) {
            TryParse(new AntlrInputStream(code), false);
        }
    }

    public class MyBailErrorStrategy : DefaultErrorStrategy {
        public override void Recover(Parser recognizer, RecognitionException e) {
            for (ParserRuleContext parserRuleContext = recognizer.Context; parserRuleContext != null;
                parserRuleContext = (ParserRuleContext)parserRuleContext.Parent) {
                parserRuleContext.exception = e;
            }
            throw new ParseException(e);
        }

        public override IToken RecoverInline(Parser recognizer) {
            InputMismatchException mismatchException = new InputMismatchException(recognizer);
            for (ParserRuleContext parserRuleContext = recognizer.Context; parserRuleContext != null;
                parserRuleContext = (ParserRuleContext)parserRuleContext.Parent) {
                parserRuleContext.exception = mismatchException;
            }
            throw new ParseException(mismatchException);
        }

        public override void Sync(Parser recognizer) {}
    }

    public class MemorizingErrorStrategy : DefaultErrorStrategy {
        public bool HasErrors { get; private set; }
        public ParseException LastException { get; private set; }

        public void Initialize() {
            HasErrors = false;
        }

        public override void Recover(Parser recognizer, RecognitionException e) {
            HasErrors = true;
            LastException = new ParseException(e);
        }

        public override IToken RecoverInline(Parser recognizer) {
            HasErrors = true;
            var e = new InputMismatchException(recognizer);
            LastException = new ParseException(recognizer.CurrentToken.ToString(), e);
            return base.RecoverInline(recognizer);
        }

        public override void Sync(Parser recognizer) {}
    }
}