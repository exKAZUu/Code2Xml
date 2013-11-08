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

using Antlr4.Runtime;

namespace Code2Xml.Languages.ANTLRv4.Core {
	public static class Token {
		public const int HIDDEN_CHANNEL = TokenConstants.HiddenChannel;
	}

	public static class Antlr4Extension {
		public static int getType(this IToken token) {
			return token.Type;
		}

		public static void setChannel(this IWritableToken token, int channel) {
			token.Channel = channel;
		}

		public static int LA(this ICharStream stream, int i) {
			return stream.La(i);
		}

		public static IToken LT(this ITokenStream stream, int k) {
			return stream.Lt(k);
		}
	}
}