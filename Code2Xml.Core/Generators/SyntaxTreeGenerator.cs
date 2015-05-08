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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Text;

namespace Code2Xml.Core.Generators {
    public abstract class SyntaxTreeGenerator {
        public const bool DefaultThrowingParseError = false;
        public const bool DefaultEnablePosition = true;

        /// <summary>
        /// Gets the full language name including the version.
        /// </summary>
        public string LanguageNameWithVersion {
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

        protected SyntaxTreeGenerator(IEnumerable<string> extensions) {
            SupportedExtensions = extensions.ToList().AsReadOnly();
        }

        protected SyntaxTreeGenerator(params string[] extensions)
                : this((IEnumerable<string>)extensions) {}

        #region ParseTree

        /// <summary>
        /// Try to parse the fragment of the source code which is retrieved from the specified <c>TextReader</c>.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <returns></returns>
        public virtual void TryParseFromCode(TextReader codeReader) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Try to parse the fragment of the source code which is retrieved from the specified <c>FileInfo</c>.
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public void TryParseFromCode(FileInfo codeFile, Encoding encoding = null) {
            if (encoding == null) {
                try {
                    TryParseFromCodeText(GuessEncoding.ReadAllText(codeFile.FullName));
                } catch {
                    TryParseFromCodeText(File.ReadAllText(codeFile.FullName));
                }
            } else {
                using (var reader = new StreamReader(codeFile.FullName, encoding)) {
                    TryParseFromCode(reader);
                }
            }
        }

        /// <summary>
        /// Try to parse the fragment of the source code of the specified <c>string</c>.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual void TryParseFromCodeText(string code) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Try to parse the fragment of the source code which is retrieved from the specified file path.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public void TryParseFromCodePath(string path, Encoding encoding = null) {
            TryParseFromCode(new FileInfo(path), encoding);
        }

        /// <summary>
        /// Try to parse the fragment of the source code which is retrieved from the specified <c>TextReader</c>.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <returns></returns>
        public virtual void TryParseFromCodeFragment(TextReader codeReader) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Try to parse the fragment of the source code of the specified <c>string</c>.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual void TryParseFromCodeFragmentText(string code) {
            throw new NotImplementedException();
        }

        #endregion

        #region GenerateXml

        /// <summary>
        /// Generates a xml from the specified <c>TextReader</c> which reads the source code.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public abstract XElement GenerateXmlFromCode(
                TextReader codeReader,
                bool throwingParseError = DefaultThrowingParseError);

        /// <summary>
        /// Generates a xml from the specified file of the source code and the specified encoding.
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="encoding"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public XElement GenerateXmlFromCode(
                FileInfo codeFile, Encoding encoding = null,
                bool throwingParseError = DefaultThrowingParseError) {
            Contract.Requires(codeFile != null);
            if (encoding == null) {
                try {
                    return GenerateXmlFromCodeText(
                            GuessEncoding.ReadAllText(codeFile.FullName), true);
                } catch {
                    return GenerateXmlFromCodeText(
                            File.ReadAllText(codeFile.FullName), throwingParseError);
                }
            }
            using (var reader = new StreamReader(codeFile.FullName, encoding)) {
                return GenerateXmlFromCode(reader, throwingParseError);
            }
        }

        /// <summary>
        /// Generates a xml from the specified text of the source code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public abstract XElement GenerateXmlFromCodeText(
                string code,
                bool throwingParseError = DefaultThrowingParseError);

        /// <summary>
        /// Generates a xml from the specified text of the source code.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public XElement GenerateXmlFromCodePath(
                string path, Encoding encoding = null,
                bool throwingParseError = DefaultThrowingParseError) {
            return GenerateXmlFromCode(new FileInfo(path), encoding, throwingParseError);
        }

        /// <summary>
        /// Generates a xml from the specified <c>TextReader</c> which reads the fragment of the source code.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <returns></returns>
        public abstract XElement GenerateXmlFromCodeFragment(TextReader codeReader);

        /// <summary>
        /// Generates a xml from the specified text of the fragment of the source code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public abstract XElement GenerateXmlFromCodeFragmentText(string code);

        #endregion

        #region GenerateCode

        /// <summary>
        /// Generates source code from the specified xml.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public abstract string GenerateCodeFromXml(XElement root);

        /// <summary>
        /// Generates source code from the specified xml.
        /// </summary>
        /// <param name="xdoc"></param>
        /// <returns></returns>
        public string GenerateCodeFromXml(XDocument xdoc) {
            Contract.Requires(xdoc != null);
            Contract.Ensures(Contract.Result<string>() != null);
            return GenerateCodeFromXml(xdoc.Root);
        }

        /// <summary>
        /// Generates source code from the specified <c>TextReader</c> instance which read a xml.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns></returns>
        public abstract string GenerateCodeFromXml(TextReader xmlReader);

        /// <summary>
        /// Generates source code from the specified xml file and encoding.
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string GenerateCodeFromXml(FileInfo xmlFile, Encoding encoding = null) {
            Contract.Requires(xmlFile != null);
            Contract.Ensures(Contract.Result<string>() != null);
            if (encoding == null) {
                return GenerateCodeFromXmlText(GuessEncoding.ReadAllText(xmlFile.FullName));
            }
            using (var stream = new StreamReader(xmlFile.FullName, encoding)) {
                return GenerateCodeFromXml(stream);
            }
        }

        /// <summary>
        /// Generates source code from the specified xml text.
        /// </summary>
        /// <param name="xmlText"></param>
        /// <returns></returns>
        public abstract string GenerateCodeFromXmlText(string xmlText);

        /// <summary>
        /// Generates source code from the specified xml text.
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        public string GenerateCodeFromXmlPath(string xmlFilePath) {
            Contract.Requires(xmlFilePath != null);
            Contract.Ensures(Contract.Result<string>() != null);
            return GenerateCodeFromXml(new FileInfo(xmlFilePath));
        }

        #endregion
    }

    /// <summary>
    /// Represents a programming language processor for inter-converting source code and a xml representing an abstract syntax tree.
    /// </summary>
    public abstract class SyntaxTreeGenerator<TNode, TToken> : SyntaxTreeGenerator
            where TNode : SyntaxTreeNode<TNode, TToken>
            where TToken : SyntaxTreeToken<TToken> {
        protected SyntaxTreeGenerator(IEnumerable<string> extensions) : base(extensions) {}

        protected SyntaxTreeGenerator(params string[] extensions) : base(extensions) {}

        #region GenerateTree

        /// <summary>
        /// Generates a tree from the specified <c>TextReader</c> which reads the source code.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public abstract TNode GenerateTreeFromCode(
                TextReader codeReader,
                bool throwingParseError = DefaultThrowingParseError);

        /// <summary>
        /// Generates a tree from the specified file of the source code and the specified encoding.
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="encoding"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public virtual TNode GenerateTreeFromCode(
                FileInfo codeFile, Encoding encoding = null,
                bool throwingParseError = DefaultThrowingParseError) {
            Contract.Requires(codeFile != null);
            if (encoding == null) {
                try {
                    return GenerateTreeFromCodeText(
                            GuessEncoding.ReadAllText(codeFile.FullName), throwingParseError);
                } catch {
                    return GenerateTreeFromCodeText(
                            File.ReadAllText(codeFile.FullName), throwingParseError);
                }
            }
            using (var reader = new StreamReader(codeFile.FullName, encoding)) {
                return GenerateTreeFromCode(reader, throwingParseError);
            }
        }

        /// <summary>
        /// Generates a tree from the specified text of the source code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public abstract TNode GenerateTreeFromCodeText(
                string code,
                bool throwingParseError = DefaultThrowingParseError);

        /// <summary>
        /// Generates a tree from the specified file of the source code and the specified encoding.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public TNode GenerateTreeFromCodePath(
                string path, Encoding encoding = null,
                bool throwingParseError = DefaultThrowingParseError) {
            Contract.Requires(path != null);
            return GenerateTreeFromCode(new FileInfo(path), encoding, throwingParseError);
        }

        /// <summary>
        /// Generates a tree from the specified <c>TextReader</c> which reads the fragment of the source code.
        /// </summary>
        /// <param name="codeReader"></param>
        /// <returns></returns>
        public abstract TNode GenerateTreeFromCodeFragment(TextReader codeReader);

        /// <summary>
        /// Generates a tree from the specified text of the fragment of the source code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public abstract TNode GenerateTreeFromCodeFragmentText(string code);

        /// <summary>
        /// Generates a tree from the specified xml representing the source code.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public abstract TNode GenerateTreeFromXml(
                XElement element, bool throwingParseError = DefaultThrowingParseError);

        /// <summary>
        /// Generates a tree from the specified xml representing the source code.
        /// </summary>
        /// <param name="xdoc"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public TNode GenerateTreeFromXml(
                XDocument xdoc, bool throwingParseError = DefaultThrowingParseError) {
            Contract.Requires(xdoc != null);
            return GenerateTreeFromXml(xdoc.Root, throwingParseError);
        }

        /// <summary>
        /// Generates a tree from the specified xml file representing the source code.
        /// </summary>
        /// <param name="xmlFileInfo"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public TNode GenerateTreeFromXml(
                FileInfo xmlFileInfo, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromXmlPath(xmlFileInfo.FullName, throwingParseError);
        }

        /// <summary>
        /// Generates a tree from the specified xml representing the source code.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public TNode GenerateTreeFromXmlText(
                string xml, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromXml(
                    XDocument.Parse(xml, LoadOptions.PreserveWhitespace),
                    throwingParseError);
        }

        /// <summary>
        /// Generates a tree from the specified xml file representing the source code.
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="throwingParseError"></param>
        /// <returns></returns>
        public TNode GenerateTreeFromXmlPath(
                string xmlFilePath, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromXml(
                    XDocument.Load(xmlFilePath, LoadOptions.PreserveWhitespace),
                    throwingParseError);
        }

        #endregion

        #region GenerateXml

        public XElement GenerateXmlFromTree(
                TNode root,
                bool throwingParseError = DefaultThrowingParseError) {
            return root.ToXml();
        }

        #endregion

        #region GenerateCode

        /// <summary>
        /// Generates source code from the specified xml.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public abstract string GenerateCodeFromTree(TNode root);

        #endregion
    }
}