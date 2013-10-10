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

using Code2Xml.Core.Antlr;

partial class CParser {
	private bool changed;

	partial void EnterRule_declarator_suffix() {
		if (declaration_stack.size() > 0 && declaration_stack.Peek().isTypedef) {
			declaration_stack.Peek().isTypedef = false;
			changed = true;
		}
	}

	partial void LeaveRule_declarator_suffix() {
		if (changed) {
			changed = false;
			declaration_stack.Peek().isTypedef = true;
		}
	}
}