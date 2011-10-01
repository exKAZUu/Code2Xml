using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Paraiba.Text;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClass(typeof(CodeToXmlContract))]
	public abstract class CodeToXml {
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }
		public const bool DefaultThrowingParseError = false;

		public XElement GenerateFromFile(string path, Encoding encoding,
		                                 bool throwingParseError) {
			Contract.Requires(path != null);
			using (var reader = new StreamReader(path, encoding)) {
				return Generate(reader, throwingParseError);
			}
		}

		public XElement GenerateFromFile(string path, bool throwingParseError) {
			Contract.Requires(path != null);
			// TODO: fix encoding
			return GenerateFromFile(path, XEncoding.SJIS, throwingParseError);
		}

		public abstract XElement Generate(TextReader reader, bool throwingParseError);

		public virtual XElement Generate(string code, bool throwingParseError) {
			Contract.Requires(code != null);
			using (var reader = new StringReader(code)) {
				return Generate(reader, throwingParseError);
			}
		}

		public XElement GenerateFromFile(string path, Encoding encoding) {
			Contract.Requires(path != null);
			return GenerateFromFile(path, encoding, DefaultThrowingParseError);
		}

		public XElement GenerateFromFile(string path) {
			Contract.Requires(path != null);
			return GenerateFromFile(path, DefaultThrowingParseError);
		}

		public XElement Generate(TextReader reader) {
			Contract.Requires(reader != null);
			return Generate(reader, DefaultThrowingParseError);
		}

		public XElement Generate(string code) {
			Contract.Requires(code != null);
			return Generate(code, DefaultThrowingParseError);
		}
	}
}