using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.Linq;
using Paraiba.Text;

namespace Code2Xml.Core.XmlToCodes {
	[ContractClass(typeof(XmlToCodeContract))]
	public abstract class XmlToCode {
		public abstract string ParserName { get; }
		public abstract ReadOnlyCollection<string> SupportedExtensions { get; }
		public string DefaultExtension { get { return SupportedExtensions[0]; } }

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

		public string GenerateFromFile(string fileName) {
			Contract.Requires(fileName != null);
			Contract.Ensures(Contract.Result<string>() != null);
			// TODO: fix encoding
			using (var stream = new StreamReader(fileName, XEncoding.SJIS)) {
				return Generate(stream);
			}
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
				Contract.Ensures(Contract.Result<ReadOnlyCollection<string>>() != null);
				Contract.Ensures(Contract.Result<ReadOnlyCollection<string>>().Count > 0);
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