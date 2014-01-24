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
using System.Text;
using System.Xml.Linq;

namespace Code2Xml.Core.Processors {
	public class FileCacheProcessor : Processor {
		public Processor DelegatingProcessor { get; private set; }

		public override string LanguageName {
			get { return DelegatingProcessor.LanguageName; }
		}

		public override string LanguageVersion {
			get { return DelegatingProcessor.LanguageVersion; }
		}

		public FileCacheProcessor(Processor delegatingProcessor)
				: base(delegatingProcessor.SupportedExtensions) {
			DelegatingProcessor = delegatingProcessor;
		}

		public override string GenerateCode(XElement root) {
			return DelegatingProcessor.GenerateCode(root);
		}

		public override XElement GenerateXml(
				string code, bool throwingParseError = DefaultThrowingParseError) {
			return DelegatingProcessor.GenerateXml(code, throwingParseError);
		}

		public override XElement GenerateXml(
				TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
			return DelegatingProcessor.GenerateXml(codeReader, throwingParseError);
		}

		public override XElement GenerateXml(
				FileInfo codeFile, Encoding encoding = null, bool throwingParseError = DefaultThrowingParseError) {
			var time = codeFile.LastWriteTime.ToString();
			foreach (var invalidChar in Path.GetInvalidFileNameChars()) {
				time = time.Replace(invalidChar, '_');
			}
			var cacheFileInfo = new FileInfo(codeFile.FullName + time + ".cached_xml");
			if (cacheFileInfo.Exists) {
				using (var reader = cacheFileInfo.OpenText()) {
					var xdoc = XDocument.Load(reader, LoadOptions.PreserveWhitespace);
					var cachedTree = xdoc.Root;
					cachedTree.Remove();
					return cachedTree;
				}
			}
			var tree = DelegatingProcessor.GenerateXml(codeFile, encoding, throwingParseError);
			using (var stream = cacheFileInfo.OpenWrite()) {
				tree.Save(stream, SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces);
			}
			return tree;
		}
	}
}