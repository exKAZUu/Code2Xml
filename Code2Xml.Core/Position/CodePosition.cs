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
using System.Diagnostics.Contracts;
using System.IO;

namespace Code2Xml.Core.Position {
	/// <summary>
	/// A data class which represents a position of a element in sour code with start/end  line/position(column).
	/// </summary>
	[Serializable]
	public struct CodePosition : IEquatable<CodePosition> {
		public int EndLine;
		public int EndPosition;
		public int StartLine;
		public int StartPosition;

		public CodePosition(int startLine, int endLine, int startPosition, int endPosition) {
			Contract.Requires(startLine <= endLine);
			StartLine = startLine;
			StartPosition = startPosition;
			EndLine = endLine;
			EndPosition = endPosition;
		}

		/// <summary>
		/// Returns the string representation of the line numbers with "StartLine - EndLine"
		/// </summary>
		public string LineString {
			get { return StartLine + " - " + EndLine; }
		}

		/// <summary>
		/// Returns the string representation of the position (column) numbers with "StartPosition - EndPosition"
		/// </summary>
		public string PositionString {
			get { return StartPosition + " - " + EndPosition; }
		}

		/// <summary>
		/// Returns the smart string representation of the line numbers
		/// with "StartLine - EndLine" when StartLine != EndLine
		/// with just "StartLine" when StartLine == EndLine
		/// </summary>
		public string SmartLineString {
			get {
				return StartLine == EndLine
						? StartLine.ToString() : (StartLine + " - " + EndLine);
			}
		}

		/// <summary>
		/// Returns the smart string representation of the position (column) numbers
		/// with "StartPosition - EndPosition" when StartPosition != EndPosition
		/// with just "StartPosition" when StartPosition == EndPosition
		/// </summary>
		public string SmartPositionString {
			get {
				return StartPosition == EndPosition
						? StartPosition.ToString() : (StartPosition + " - " + EndPosition);
			}
		}

		#region IEquatable<CodePosition> Members

		public bool Equals(CodePosition other) {
			return other.EndLine == EndLine && other.EndPosition == EndPosition &&
					other.StartLine == StartLine && other.StartPosition == StartPosition;
		}

		#endregion

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) {
				return false;
			}
			if (obj.GetType() != typeof(CodePosition)) {
				return false;
			}
			return Equals((CodePosition)obj);
		}

		public override int GetHashCode() {
			unchecked {
				int result = EndLine;
				result = (result * 397) ^ EndPosition;
				result = (result * 397) ^ StartLine;
				result = (result * 397) ^ StartPosition;
				return result;
			}
		}

		public static bool operator ==(CodePosition left, CodePosition right) {
			return left.Equals(right);
		}

		public static bool operator !=(CodePosition left, CodePosition right) {
			return !left.Equals(right);
		}

		public override string ToString() {
			return "Line: " + SmartLineString + ", Pos: " + SmartPositionString;
		}

		public static CodePosition Read(BinaryReader reader) {
			var startLine = reader.ReadInt32();
			var endLine = reader.ReadInt32();
			var startPos = reader.ReadInt32();
			var endPos = reader.ReadInt32();
			return new CodePosition(startLine, endLine, startPos, endPos);
		}

		public void Write(BinaryWriter writer) {
			writer.Write(StartLine);
			writer.Write(EndLine);
			writer.Write(StartPosition);
			writer.Write(EndPosition);
		}
	}
}