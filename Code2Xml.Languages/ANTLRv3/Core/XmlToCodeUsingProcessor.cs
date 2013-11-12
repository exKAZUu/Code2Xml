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

using System.Collections.ObjectModel;
using System.Xml.Linq;
using Code2Xml.Core.Processors;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.ANTLRv3.Core {
	public abstract class XmlToCodeUsingProcessor<TProcessor> : XmlToCode
			where TProcessor : Processor, new() {
		private readonly Processor _processor;

		protected XmlToCodeUsingProcessor() {
			_processor = new TProcessor();
		}

		public override string ParserName {
			get { return _processor.LanguageName + " " + _processor.LanguageVersion; }
		}

		public override ReadOnlyCollection<string> SupportedExtensions {
			get { return _processor.SupportedExtensions; }
		}

		public override string Generate(XElement root) {
			return _processor.GenerateCode(root);
		}
	}
}