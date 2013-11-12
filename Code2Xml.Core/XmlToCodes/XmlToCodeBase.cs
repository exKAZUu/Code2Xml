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
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;
using Code2Xml.Core.Processors;

namespace Code2Xml.Core.XmlToCodes {
	/// <summary>
	/// Please use <see cref="Processor"/> class.
	/// </summary>
	[Obsolete]
	[ContractClass(typeof(XmlToCodeBaseContract))]
	public abstract class XmlToCodeBase : XmlToCode {
		private readonly string _newLine;
		protected readonly StringBuilder Builder;
		private int _depth;
		private bool _indented;

		protected XmlToCodeBase(string newLine = "\n") {
			_newLine = newLine;
			Builder = new StringBuilder();
		}

		protected int Depth {
			get { return _depth; }
			set { _depth = value; }
		}

		protected virtual void Initialize() {
			Builder.Length = 0;
			_depth = 0;
			_indented = false;
		}

		protected void WriteWord(string str) {
			Contract.Requires(str != null);
			if (_indented) {
				Builder.Append(' ');
			} else {
				WriteIndent();
			}
			Builder.Append(str);
		}

		protected void WriteWordWithoutWhiteSpace(string str) {
			Contract.Requires(str != null);
			if (!_indented) {
				WriteIndent();
			}
			Builder.Append(str);
		}

		protected void WriteIndent() {
			for (int i = 0; i < _depth; i++) {
				Builder.Append('\t');
			}
			_indented = true;
		}

		protected void WriteLine() {
			Builder.Append(_newLine);
			_indented = false;
		}

		protected void WriteLine(string str) {
			Contract.Requires(str != null);
			WriteWord(str);
			Builder.Append(_newLine);
			_indented = false;
		}

		protected void WalkElement(XContainer element) {
			Contract.Requires(element != null);
			foreach (var e in element.Elements()) {
				if (e.HasElements) {
					WalkElement(e);
				} else if (!TreatTerminalSymbol(e) && e.Value != string.Empty) {
					WriteWord(e.Value);
				}
			}
		}

		protected abstract bool TreatTerminalSymbol(XElement element);

		public override string Generate(XElement root) {
			Initialize();
			WalkElement(root);
			return Builder.ToString();
		}
	}

	[ContractClassFor(typeof(XmlToCodeBase))]
	internal abstract class XmlToCodeBaseContract : XmlToCodeBase {
		protected override bool TreatTerminalSymbol(XElement element) {
			Contract.Requires(element != null);
			throw new NotImplementedException();
		}
	}
}