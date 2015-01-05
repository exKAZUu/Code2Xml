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

using System.Collections.Generic;
using Antlr.Runtime;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3.Parsers  {
	public partial class csLexer {
		// Preprocessor Data Structures - see lexer section below and PreProcessor.cs
		protected HashSet<string> MacroDefines = new HashSet<string>();
		protected Stack<bool> Processing = new Stack<bool>();

		// Uggh, lexer rules don't return values, so use a stack to return values.
		protected Stack<bool> Returns = new Stack<bool>();

		private readonly Queue<IToken> _tokens = new Queue<IToken>();

		public override void Emit(IToken token) {
			state.token = token;
			_tokens.Enqueue(token);
		}

		public override IToken NextToken() {
			base.NextToken();
			if (_tokens.Count > 0) {
				return _tokens.Dequeue();
			}
			return GetEndOfFileToken();
		}

		partial void OnCreated() {
			// By default we are preprocessing input
			Processing.Push(true);
		}
	}
}