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

using Antlr.Runtime;

namespace Code2Xml.Core.Generators.ANTLRv3.JavaScript {
	public partial class JavaScriptLexer {
		/// <summary>
		///   Containts the last on channel token.
		/// </summary>
		protected IToken Last;

		/// <summary>
		///   Indicates whether regular expression (yields true) or division expression recognition (false) in the lexer is enabled. These are mutual exclusive and the decision which is active in the lexer is based on the previous on channel token. When the previous token can be identified as a possible left operand for a division this results in false, otherwise true.
		/// </summary>
		private bool AreRegularExpressionsEnabled {
			get {
				if (Last == null) {
					return true;
				}

				switch (Last.Type) {
					// identifier
				case Identifier:
					// literals
				case NULL:
				case TRUE:
				case FALSE:
				case THIS:
				case NumericLiteral:
				case DecimalLiteral:
				case HexIntegerLiteral:
				case StringLiteral:
					// member access ending 
				case RBRACE:
					// function definition ending
				case RBRACK:
					// function call or nested expression ending
				case RPAREN:
					return false;

					// otherwise OK
				default:
					return true;
				}
			}
		}

		/// <summary>
		///   Override of base to track previous on channel token. This token is needed as input to decide whether regular expression or division expression recognition is enabled.
		/// </summary>
		public override IToken NextToken() {
			var result = base.NextToken();
			if (result.Channel == DefaultTokenChannel) {
				Last = result;
			}
			return result;
		}
	}
}