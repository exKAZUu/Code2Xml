#region License

// Copyright (C) 2011-2016 Kazunori Sakamoto
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
using System.Linq;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Sharpen;

namespace Code2Xml.Core.Generators.ANTLRv4 {
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

    public static class Token {
        public const int HIDDEN_CHANNEL = TokenConstants.HiddenChannel;
        public const int EOF = TokenConstants.Eof;
    }

    public static class StandardLibraryExtension {
        public static bool isEmpty<T>(this IEnumerable<T> stack) {
            return !stack.Any();
        }

        public static void push<T>(this Stack<T> stack, T item) {
            stack.Push(item);
        }

        public static T pop<T>(this Stack<T> stack) {
            return stack.Pop();
        }

        public static T peek<T>(this Stack<T> stack) {
            return stack.Peek();
        }

        public static void offer<T>(this Queue<T> queue, T item) {
            queue.Enqueue(item);
        }

        public static T poll<T>(this Queue<T> queue) {
            return queue.Dequeue();
        }

        public static string replaceAll(this string str, string pattern, string replacement) {
            return Regex.Replace(str, pattern, replacement);
        }
    }

    public static class Antlr4Extension {
        public static string getText(this Lexer lexer) {
            return lexer.Text;
        }

        public static void emit(this Lexer lexer, IToken token) {
            lexer.Emit(token);
        }

        public static void skip(this Lexer lexer) {
            lexer.Skip();
        }

        public static IToken getCurrentToken(this Parser parser) {
            return parser.CurrentToken;
        }

        public static int getTokenIndex(this IToken token) {
            return token.TokenIndex;
        }

        public static string getText(this IToken token) {
            return token.Text;
        }

        public static int getType(this IToken token) {
            return token.Type;
        }

        public static int getChannel(this IToken token) {
            return token.Channel;
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

        public static IToken get(this ITokenStream stream, int i) {
            return stream.Get(i);
        }

        public static int index(this ITokenStream stream) {
            return stream.Index;
        }

        public static bool contains(this string str, string s) {
            return str.Contains(s);
        }

        public static bool startsWith(this string str, string s) {
            return str.StartsWith(s);
        }

        public static void set(this BitSet set, int index) {
            set.Set(index);
        }

        public static void set(this BitSet set, int startIndex, int exclusiveEndIndex) {
            for (; startIndex < exclusiveEndIndex; startIndex++) {
                set.Set(startIndex);
            }
        }

        public static void Set(this BitSet set, int startIndex, int exclusiveEndIndex) {
            for (; startIndex < exclusiveEndIndex; startIndex++) {
                set.Set(startIndex);
            }
        }
    }
}