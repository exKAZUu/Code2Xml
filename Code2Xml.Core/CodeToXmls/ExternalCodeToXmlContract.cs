using System;
using System.Diagnostics.Contracts;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClassFor(typeof(ExternalCodeToXml))]
	internal abstract class ExternalCodeToXmlContract : ExternalCodeToXml {
		protected override string ProcessorPath {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				throw new NotImplementedException();
			}
		}

		protected override string[] Arguments {
			get {
				Contract.Ensures(Contract.Result<string[]>() != null);
				throw new NotImplementedException();
			}
		}
	}
}