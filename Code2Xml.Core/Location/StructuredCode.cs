#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
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
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace Code2Xml.Core.Location {
    public class StructuredCode {
        public string Code { get; private set; }
        public ReadOnlyCollection<int> Indices { get; set; }

        public char this[CodeLocation location] {
            get { return Code[GetIndex(location)]; }
        }

        public char this[int line, int pos] {
            get { return Code[GetIndex(line, pos)]; }
        }

        public char this[int index] {
            get { return Code[index]; }
        }

        public StructuredCode(string code) {
            Code = code;
            var indices = new List<int> { 0, 0 };
            for (int i = 0; i < code.Length; i++) {
                if (code[i] == '\n') {
                    indices.Add(i + 1);
                }
            }
            Indices = indices.AsReadOnly();
        }

        public int GetIndex(CodeLocation location) {
            return Indices[location.Line] + location.Position;
        }

        public int GetIndex(int line, int pos) {
            Contract.Requires(line > 0);
            return Indices[line] + pos;
        }

        public CodeLocation GetLocation(int index) {
            Contract.Requires(index >= 0);
            return GetLocation(index, 2);
        }

        public CodeLocation GetLocation(int index, CodeLocation startLocation) {
            Contract.Requires(index >= 0);
            return GetLocation(index, startLocation.Line);
        }

        private CodeLocation GetLocation(int index, int startLine) {
            for (; startLine < Indices.Count; startLine++) {
                if (index < Indices[startLine]) {
                    break;
                }
            }
            return new CodeLocation(startLine - 1, index - Indices[startLine - 1]);
        }

        public CodeRange GetRange(int startIndex, int exclusiveEndIndex) {
            Contract.Requires(startIndex >= 0);
            Contract.Requires(exclusiveEndIndex >= startIndex);
            var startLocation = GetLocation(startIndex, 2);
            var endLocation = GetLocation(exclusiveEndIndex, startLocation.Line + 1);
            return new CodeRange(startLocation, endLocation);
        }

        public string GetFragment(CodeRange range) {
            var startIndex = GetIndex(range.StartLocation);
            var exclusiveEndIndex = GetIndex(range.EndLocation);
            return Code.Substring(startIndex, exclusiveEndIndex - startIndex);
        }
    }
}