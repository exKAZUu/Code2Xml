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
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Code2Xml.Languages.ANTLRv3 {
	public partial class JavaParser {
		public Antlr3Listener Listener {
			get; set;
		}

		partial void EnterRule(string ruleName, int ruleIndex) {
			Listener.EnterNonTerminalNode(ruleName);
			Console.WriteLine("Enter: " + ruleName);
		}

		partial void LeaveRule(string ruleName, int ruleIndex) {
			Listener.LeaveNonTerminalNode(ruleName);
			Console.WriteLine("Leave: " + ruleName);
		}

		partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor) {
		}
	}
}