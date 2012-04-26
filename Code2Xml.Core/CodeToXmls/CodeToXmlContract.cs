#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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
				Contract.Ensures(
						Contract.Result<IEnumerable<string>>().Any());
				throw new NotImplementedException();
			}
		}

		public override XElement Generate(
				TextReader reader, bool throwingParseError) {
			Contract.Requires(reader != null);
			throw new NotImplementedException();
		}
	}
}