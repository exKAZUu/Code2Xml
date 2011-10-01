using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClassFor(typeof(CodeToXml))]
	internal abstract class CodeToXmlContract : CodeToXml {
		public override string ParserName {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				throw new NotImplementedException();
			}
		}

		public override IEnumerable<string> TargetExtensions {
			get {
				Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);
				Contract.Ensures(Contract.Result<IEnumerable<string>>().Count() > 0);
				throw new NotImplementedException();
			}
		}

		public override XElement Generate(TextReader reader, bool throwingParseError) {
			Contract.Requires(reader != null);
			throw new NotImplementedException();
		}
	}
}