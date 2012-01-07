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

using System.Collections.Generic;
using System.Linq;
using Antlr.Runtime;

namespace Code2Xml.Core.Antlr {
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

    public static class ExtensionForParser {
        public static T get<T>(this Stack<T> stack, int i) {
            return stack.ElementAt(i);
        }

        public static int size<T>(this Stack<T> stack) {
            return stack.Count;
        }

        public static bool add<T>(this HashSet<T> set, T item) {
            return set.Add(item);
        }

        public static bool contains<T>(this HashSet<T> set, T item) {
            return set.Contains(item);
        }

        public static string getText(this IToken token) {
            return token.Text;
        }

        public static void skip(this Lexer lexer) {
            lexer.Skip();
        }
    }
}