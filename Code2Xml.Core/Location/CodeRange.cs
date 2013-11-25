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
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Code2Xml.Core.Location {
	/// <summary>
	/// Represents a range in sour code with the specified *INCLUSIVE* start and end positions.
	/// </summary>
	[Serializable]
	public struct CodeRange : IEquatable<CodeRange> {
		public CodeLocation StartLocation;
		public CodeLocation EndLocation;

		public int StartLine {
			get { return StartLocation.Line; }
			set { StartLocation.Line = value; }
		}

		public int StartPosition {
			get { return StartLocation.Position; }
			set { StartLocation.Position = value; }
		}

		public int EndLine {
			get { return EndLocation.Line; }
			set { EndLocation.Line = value; }
		}

		public int EndPosition {
			get { return EndLocation.Position; }
			set { EndLocation.Position = value; }
		}

		public CodeRange(CodeLocation inclusiveStartLocation, CodeLocation inclusiveEndLocation) {
			Contract.Requires(inclusiveStartLocation <= inclusiveEndLocation);
			StartLocation = inclusiveStartLocation;
			EndLocation = inclusiveEndLocation;
		}

		#region Members about the string representation

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

		public override string ToString() {
			return "Line: " + SmartLineString + ", Pos: " + SmartPositionString;
		}

		#endregion

		#region Members about the equality

		public bool Equals(CodeRange other) {
			return other.EndLine == EndLine && other.EndPosition == EndPosition &&
			       other.StartLine == StartLine && other.StartPosition == StartPosition;
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) {
				return false;
			}
			if (obj.GetType() != typeof(CodeRange)) {
				return false;
			}
			return Equals((CodeRange)obj);
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

		public static bool operator ==(CodeRange left, CodeRange right) {
			return left.Equals(right);
		}

		public static bool operator !=(CodeRange left, CodeRange right) {
			return !left.Equals(right);
		}

		#endregion

		#region Members about the serialization

		public static CodeRange Read(BinaryReader reader) {
			var startLine = reader.ReadInt32();
			var endLine = reader.ReadInt32();
			var startPos = reader.ReadInt32();
			var endPos = reader.ReadInt32();
			return new CodeRange(new CodeLocation(startLine, startPos), new CodeLocation(endLine, endPos));
		}

		public void Write(BinaryWriter writer) {
			writer.Write(StartLine);
			writer.Write(EndLine);
			writer.Write(StartPosition);
			writer.Write(EndPosition);
		}

		#endregion

		/// <summary>
		/// Returns whether the specified location (line and position) is included this CodeRange instance.
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
		public bool Contains(CodeLocation location) {
			if (location.Line < StartLine) {
				return false;
			}
			if (location.Line == StartLine && location.Position < StartPosition) {
				return false;
			}
			if (EndLine < location.Line) {
				return false;
			}
			if (location.Line == EndLine && EndPosition < location.Position) {
				return false;
			}
			return true;
		}

		/// <summary>
		/// Returns whether the specified CodeRange instance is included by this CodeRange instance.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Contains(CodeRange other) {
			return Contains(other.StartLocation) &&
			       Contains(other.EndLocation);
		}

		/// <summary>
		/// Returns whether the specified CodeRange instance is overlapped with this CodeRange instance.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Overlaps(CodeRange other) {
			return Contains(other.StartLocation) ||
			       Contains(other.EndLocation) ||
			       other.Contains(StartLocation) ||
			       other.Contains(EndLocation);
		}

		/// <summary>
		/// Find the most inner element which locates at the this range from the specified root.
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public XElement FindInnermostElement(XElement root) {
			XElement lastElement = null;
			foreach (var elem in root.DescendantsAndSelf()) {
				var pos = Locate(elem);
				if (pos.Contains(this)) {
					lastElement = elem;
				} else if (EndLocation <= pos.StartLocation) {
					break;
				}
			}
			return lastElement;
		}

		/// <summary>
		/// Find the most outer element which locates at the this range from the specified root.
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public XElement FindOutermostElement(XElement root) {
			var ret = FindInnermostElement(root);
			while (ret.Parent != null && ret.Parent.Elements().Count() == 1) {
				ret = ret.Parent;
			}
			return ret;
		}

		#region Inter-Conversion between a CodeRange object and indicies

		public void ConvertToIndicies(string code, out int inclusiveStart, out int exclusiveEnd) {
			var headIndex = 0;
			var i = 1;
			for (; i < StartLine; i++) {
				headIndex = code.IndexOf('\n', headIndex) + 1;
			}
			inclusiveStart = headIndex + StartPosition;
			for (; i < EndLine; i++) {
				headIndex = code.IndexOf('\n', headIndex) + 1;
			}
			exclusiveEnd = headIndex + EndPosition + 1;
		}

		public Tuple<int, int> ConvertToIndicies(string code) {
			int inclusiveStart, exclusiveEnd;
			ConvertToIndicies(code, out inclusiveStart, out exclusiveEnd);
			return Tuple.Create(inclusiveStart, exclusiveEnd);
		}

		public static CodeRange ConvertFromIndicies(string code, int inclusiveStart, int exclusiveEnd) {
			var beforeCode = code.Substring(0, inclusiveStart);
			var targetCode = code.Substring(inclusiveStart, exclusiveEnd - inclusiveStart);
			var beforeCount = beforeCode.Count(ch => ch == '\n');
			var afterCount = targetCode.Count(ch => ch == '\n');
			var headLineIndexOfBefore = beforeCode.LastIndexOf('\n') + 1;
			var headLineIndexOfTarget = targetCode.LastIndexOf('\n') + 1;
			if (headLineIndexOfTarget == 0) {
				headLineIndexOfTarget = -(beforeCode.Length - headLineIndexOfBefore);
			}
			return new CodeRange(
					new CodeLocation(
							beforeCount + 1,
							beforeCode.Length - headLineIndexOfBefore),
					new CodeLocation(
							beforeCount + afterCount + 1,
							(targetCode.Length - 1) - headLineIndexOfTarget));
		}

		public static CodeRange ConvertFromIndiciesSkippingWhitespaces(
				string code, ref int inclusiveStart, ref int exclusiveEnd) {
			while (char.IsWhiteSpace(code[inclusiveStart])) {
				inclusiveStart++;
			}
			while (char.IsWhiteSpace(code[exclusiveEnd - 1])) {
				exclusiveEnd--;
			}
			return ConvertFromIndicies(code, inclusiveStart, exclusiveEnd);
		}

		#endregion

		#region Locate a node of an AST

		public static CodeRange Locate(XElement element) {
			return LocatePrivate(element.DescendantsAndSelf());
		}

		public static CodeRange Locate(IEnumerable<XElement> elements) {
			return LocatePrivate(elements.DescendantsAndSelf());
		}

		public static CodeLocation CalculateInclusiveEndLocation(CodeLocation startLocation, string text) {
			var newLineCount = text.Count(ch => ch == '\n');
			var lastNewLineIndex = text.LastIndexOf('\n');
			var endLine = startLocation.Line + newLineCount;
			var endPos = newLineCount == 0
					? startLocation.Position + text.Length - 1
					: text.Length - (lastNewLineIndex + 1) - 1;
			if (endPos == -1) {
				endLine--;
				if (newLineCount - 1 <= 0) {
					endPos = startLocation.Position + text.Length - 1;
				} else {
					var lastSecondNewLineIndex = text.Substring(0, lastNewLineIndex).LastIndexOf('\n');
					endPos = lastNewLineIndex - lastSecondNewLineIndex - 1;
				}
			}
			return new CodeLocation(endLine, endPos);
		}

		public static XElement SetLocationAttributes(XElement element, string text, CodeLocation startLocation) {
			var endLocation = CalculateInclusiveEndLocation(startLocation, text);
			element.SetAttributeValue(
					Code2XmlConstants.StartLineName, startLocation.Line);
			element.SetAttributeValue(
					Code2XmlConstants.StartPositionName, startLocation.Position);
			element.SetAttributeValue(
					Code2XmlConstants.EndLineName, endLocation.Line);
			element.SetAttributeValue(
					Code2XmlConstants.EndPositionName, endLocation.Position);
			return element;
		}

		private static CodeRange LocatePrivate(IEnumerable<XElement> descendants) {
			int startLine = 0, startPos = 0;
			var first = descendants.FirstOrDefault(
					e => e.Attribute(Code2XmlConstants.StartLineName) != null);
			if (first != null) {
				var startLineAttr = first.Attribute(Code2XmlConstants.StartLineName);
				int.TryParse(startLineAttr.Value, out startLine);

				var startPosAttr =
						first.Attribute(Code2XmlConstants.StartPositionName);
				if (startPosAttr != null) {
					int.TryParse(startPosAttr.Value, out startPos);
				}
			} else {
				return new CodeRange(new CodeLocation(-1, -1), new CodeLocation(-1, -1));
			}

			int endLine = 0, endPos = 0;
			var last = descendants.LastOrDefault(
					e => e.Attribute(Code2XmlConstants.StartLineName) != null);
			if (last != null) {
				var endLineAttr = last.Attribute(Code2XmlConstants.EndLineName);
				if (!(endLineAttr != null && int.TryParse(endLineAttr.Value, out endLine))) {
					// Accept the last element's start line number
					var startLineAttr = last.Attribute(Code2XmlConstants.StartLineName);
					if (int.TryParse(startLineAttr.Value, out endLine)) {
						endLine += last.Value.Count(c => c == '\n');
					}
				}

				var endPosAttr = last.Attribute(Code2XmlConstants.EndPositionName);
				if (!(endPosAttr != null && int.TryParse(endPosAttr.Value, out endPos))) {
					var startPosAttr =
							last.Attribute(Code2XmlConstants.StartPositionName);
					int value;
					if (startPosAttr != null && int.TryParse(startPosAttr.Value, out value)) {
						int ignoredCount = last.Value.LastIndexOf('\n') + 1;
						endPos = value + (last.Value.Length - 1) - ignoredCount;
					}
				}
			}

			return new CodeRange(new CodeLocation(startLine, startPos), new CodeLocation(endLine, endPos));
		}

		#endregion
	}
}