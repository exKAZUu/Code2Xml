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

        /// <summary>
        /// Returns whether the specified location (line and position) is included this CodePosition.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool Contains(int line, int pos) {
            if (line < StartLine) {
                return false;
            }
            if (line == StartLine && pos < StartPosition) {
                return false;
            }
            if (EndLine < line) {
                return false;
            }
            if (line == EndLine && EndPosition < pos) {
                return false;
            }
            return true;
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

        public static CodePosition Analyze(XElement element) {
            return AnalyzePrivate(element.DescendantsAndSelf());
        }

        public static CodePosition Analyze(IEnumerable<XElement> elements) {
            return AnalyzePrivate(elements.DescendantsAndSelf());
        }

        private static CodePosition AnalyzePrivate(
                IEnumerable<XElement> descendants) {
            int startLine = 0, startPos = 0;
            var first =
                    descendants.FirstOrDefault(
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
                return new CodePosition(-1, -1, -1, -1);
            }

            int endLine = 0, endPos = 0;
            var last =
                    descendants.LastOrDefault(
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
                        int index = last.Value.LastIndexOf('\n');
                        endPos = value + last.Value.Length - (index + 1);
                    }
                }
            }

            return new CodePosition(startLine, endLine, startPos, endPos);
        }
    }
}