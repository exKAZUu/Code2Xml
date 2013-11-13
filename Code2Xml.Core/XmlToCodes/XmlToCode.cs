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
using System.Xml.Linq;
using Paraiba.Text;

namespace Code2Xml.Core.XmlToCodes {
	/// <summary>
	/// Please use <see cref="Processor"/> class.
	/// </summary>
	[Obsolete]
	[ContractClass(typeof(XmlToCodeContract))]
	public abstract class XmlToCode {
		public abstract string ParserName { get; }
		public abstract ReadOnlyCollection<string> SupportedExtensions { get; }

		public string DefaultExtension {
			get { return SupportedExtensions[0]; }
		}

		public abstract string Generate(XElement root);

		public string Generate(XDocument xdoc) {
			Contract.Requires(xdoc != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return Generate(xdoc.Root);
		}

		public string Generate(TextReader reader) {
			Contract.Requires(reader != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return Generate(XDocument.Load(reader));
		}

		public string GenerateFromText(string text) {
			Contract.Requires(text != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return Generate(XDocument.Parse(text));
		}

		public string GenerateFromFile(FileInfo file) {
			Contract.Requires(file != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return GenerateFromFile(file.FullName);
		}

		public string GenerateFromFile(string fileName) {
			Contract.Requires(fileName != null);
			Contract.Ensures(Contract.Result<string>() != null);
			return GenerateFromText(GuessEncoding.ReadAllText(fileName));
		}
	}

	[ContractClassFor(typeof(XmlToCode))]
	internal abstract class XmlToCodeContract : XmlToCode {
		public override string ParserName {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				throw new NotImplementedException();
			}
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get {
				Contract.Ensures(
						Contract.Result<ReadOnlyCollection<string>>() != null);
				Contract.Ensures(
						Contract.Result<ReadOnlyCollection<string>>().Count > 0);
				throw new NotImplementedException();
			}
		}

		public override string Generate(XElement root) {
			Contract.Requires(root != null);
			Contract.Ensures(Contract.Result<string>() != null);
			throw new NotImplementedException();
		}
	}
}