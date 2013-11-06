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
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime;

namespace Code2Xml.Core.Antlr {
	public static class ExtensionForParser {
		public static T get<T>(this IList<T> stack, int i) {
			return stack[i];
		}

		public static int size<T>(this IList<T> stack) {
			return stack.Count;
		}

		public static bool add<T>(this HashSet<T> set, T item) {
			return set.Add(item);
		}

		public static bool contains<T>(this HashSet<T> set, T item) {
			return set.Contains(item);
		}

		public static void append(this StringBuilder builder, string str) {
			builder.Append(str);
		}

		public static void append(this StringBuilder builder, char ch) {
			builder.Append(ch);
		}

		public static string toString(this StringBuilder builder) {
			return builder.ToString();
		}

		public static char charAt(this string str, int index) {
			return str.charAt(index);
		}

		public static bool endsWith(this string str, string other) {
			return str.EndsWith(other);
		}

		public static int length(this string str) {
			return str.Length;
		}

		public static string getText(this IToken token) {
			return token.Text;
		}

		public static void skip(this Lexer lexer) {
			lexer.Skip();
		}

		public static int index(this ICharStream stream) {
			return stream.Index;
		}

		public static int getLine(this ICharStream stream) {
			return stream.Line;
		}

		public static int getCharPositionInLine(this ICharStream stream) {
			return stream.CharPositionInLine;
		}

		public static void consume(this ICharStream stream) {
			stream.Consume();
		}
	}

	public class Set : HashSet<object> {}

	public class HashSet : Set {}

	public struct boolean {
		private readonly bool _value;

		public boolean(bool value) {
			_value = value;
		}

		public static implicit operator bool(boolean value) {
			return value._value;
		}

		public static implicit operator boolean(bool value) {
			return new boolean(value);
		}
	}
}