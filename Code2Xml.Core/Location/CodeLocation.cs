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

namespace Code2Xml.Core.Location {
	/// <summary>
	/// Represents a position in sour code with the specified line and position(column).
	/// </summary>
	[Serializable]
	public struct CodeLocation : IEquatable<CodeLocation>, IComparable<CodeLocation> {
		public int Line;
		public int Position;

		public CodeLocation(int line, int position) {
			Line = line;
			Position = position;
		}

		public bool Equals(CodeLocation other) {
			return Line == other.Line && Position == other.Position;
		}

		public int CompareTo(CodeLocation other) {
			if (Line < other.Line) {
				return -1;
			}
			if (Line == other.Line) {
				if (Position < other.Position) {
					return -1;
				}
				if (Position == other.Position) {
					return 0;
				}
			}
			return 1;
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) {
				return false;
			}
			return obj is CodeLocation && Equals((CodeLocation)obj);
		}

		public override int GetHashCode() {
			unchecked {
				return (Line * 397) ^ Position;
			}
		}

		public override string ToString() {
			return string.Format("Line: {0}, Pos: {1}", Line, Position);
		}

		public static bool operator <(CodeLocation location1, CodeLocation location2) {
			return location1.CompareTo(location2) < 0;
		}

		public static bool operator >(CodeLocation location1, CodeLocation location2) {
			return location1.CompareTo(location2) > 0;
		}

		public static bool operator <=(CodeLocation location1, CodeLocation location2) {
			return location1.CompareTo(location2) <= 0;
		}

		public static bool operator >=(CodeLocation location1, CodeLocation location2) {
			return location1.CompareTo(location2) >= 0;
		}

		public static bool operator ==(CodeLocation location1, CodeLocation location2) {
			return location1.CompareTo(location2) == 0;
		}

		public static bool operator !=(CodeLocation location1, CodeLocation location2) {
			return location1.CompareTo(location2) != 0;
		}

		public CodeLocation Advance(string code) {
			return ConvertFromIndex(code, code.Length, Line, Position, 0);
		}

		public static CodeLocation ConvertFromIndex(string code, int index) {
			return ConvertFromIndex(code, index, 1, 0, 0);
		}

		public static CodeLocation ConvertFromIndex(string code, int index, CodeLocation startLocation, int startIndex) {
			return ConvertFromIndex(code, index, startLocation.Line, startLocation.Position, startIndex);
		}

		public static CodeLocation ConvertFromIndex(StructuredCode code, int index) {
			return code.GetLocation(index);
		}

		public static CodeLocation ConvertFromIndex(StructuredCode code, int index, CodeLocation startLocation) {
			return code.GetLocation(index, startLocation);
		}

		private static CodeLocation ConvertFromIndex(string code, int endIndex, int startLine, int startPosition, int startIndex) {
			var i = startIndex;
			for (; i < endIndex; i++) {
				if (code[i] != '\n') {
					startPosition++;
				} else {
					startLine++;
					startPosition = 0;
				}
			}
			return new CodeLocation(startLine, startPosition);
		}
	}
}