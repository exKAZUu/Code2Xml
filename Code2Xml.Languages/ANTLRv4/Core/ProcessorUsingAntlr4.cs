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
using Antlr4.Runtime;
using Code2Xml.Core.Processors;

namespace Code2Xml.Languages.ANTLRv4.Core {
    /// <summary>
    /// Provides common code for processors using Antlr 4.
    /// </summary>
    /// <typeparam name="TParser"></typeparam>
    public abstract class ProcessorUsingAntlr4<TParser> : LanguageProcessor
            where TParser : Parser {
        protected ProcessorUsingAntlr4(params string[] extensions) : base(extensions) {}

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

        private XElement GenerateXml(
                ICharStream charStream, bool throwingParseError = DefaultThrowingParseError) {
            var lexer = CreateLexer(charStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = CreateParser(commonTokenStream);
            var builder = new Antlr4AstBuilder(parser);
            if (throwingParseError) {
                parser.ErrorHandler = new MyBailErrorStrategy();
            }
            builder.Visit(Parse(parser));
            return builder.FinishParsing();
        }

        /// <summary>
        /// Generates a xml from the specified text of the source code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public override XElement GenerateXml(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateXml(new AntlrInputStream(code), throwingParseError);
        }

        /// <summary>
        /// Generates a xml from the specified <c>TextReader</c> which reads the source code.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public override XElement GenerateXml(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateXml(codeReader.ReadToEnd(), throwingParseError);
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