#region License

// Copyright (C) 2011-2015 Kazunori Sakamoto
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
using Code2Xml.Core.Serialization;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Linq;

namespace Code2Xml.Core.Location {
    /// <summary>
    /// Represents a range in sour code with the specified start and *EXCLUSIVE* end positions.
    /// </summary>
    [Serializable]
    public struct CodeRange : IEquatable<CodeRange> {
        public static CodeRange Nil = new CodeRange {
            StartLine = -1, EndLine = -1, StartPosition = -1, EndPosition = -1
        };

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

        public CodeRange(CodeLocation inclusiveStartLocation, CodeLocation exclusiveEndLocation) {
            Contract.Requires(inclusiveStartLocation <= exclusiveEndLocation);
            StartLocation = inclusiveStartLocation;
            EndLocation = exclusiveEndLocation;
        }

        public CodeRange(XElement startElement, XElement endElement) {
            Contract.Requires(startElement != null);
            Contract.Requires(endElement != null);
            StartLocation = new CodeLocation(
                    int.Parse(startElement.Attribute(Code2XmlConstants.StartLineName).Value),
                    int.Parse(startElement.Attribute(Code2XmlConstants.StartPositionName).Value));
            EndLocation = new CodeLocation(
                    int.Parse(endElement.Attribute(Code2XmlConstants.EndLineName).Value),
                    int.Parse(endElement.Attribute(Code2XmlConstants.EndPositionName).Value));
        }

        public CodeRange(XElement element) : this(element, element) {}

        public static bool TryParse(XElement startElement, XElement endElement, out CodeRange range) {
            var startLineStr = startElement.Attribute(Code2XmlConstants.StartLineName)?.Value;
            var startPosStr = startElement.Attribute(Code2XmlConstants.StartPositionName)?.Value;
            var endLineStr = endElement.Attribute(Code2XmlConstants.EndLineName)?.Value;
            var endPosStr = endElement.Attribute(Code2XmlConstants.EndPositionName)?.Value;
            int startLine, startPosition, endLine, endPosition;
            if (int.TryParse(startLineStr, out startLine) &&
                int.TryParse(startPosStr, out startPosition) &&
                int.TryParse(endLineStr, out endLine) &&
                int.TryParse(endPosStr, out endPosition)) {
                range = new CodeRange(
                        new CodeLocation(startLine, startPosition),
                        new CodeLocation(endLine, endPosition));
                return true;
            }
            range = new CodeRange();
            return false;
        }

        #region Members about the string representation

        /// <summary>
        /// Returns the string representation of the line numbers with "StartLine - EndLine"
        /// </summary>
        public string LineString => StartLine + " - " + EndLine;

        /// <summary>
        /// Returns the string representation of the position (column) numbers with "StartPosition - EndPosition"
        /// </summary>
        public string PositionString => StartPosition + " - " + EndPosition;

        /// <summary>
        /// Returns the smart string representation of the line numbers
        /// with "StartLine - EndLine" when StartLine != EndLine
        /// with just "StartLine" when StartLine == EndLine
        /// </summary>
        public string SmartLineString => StartLine == EndLine
            ? StartLine.ToString() : (StartLine + " - " + EndLine);

        /// <summary>
        /// Returns the smart string representation of the position (column) numbers
        /// with "StartPosition - EndPosition" when StartPosition != EndPosition
        /// with just "StartPosition" when StartPosition == EndPosition
        /// </summary>
        public string SmartPositionString => StartPosition == EndPosition
                ? StartPosition.ToString() : (StartPosition + " - " + EndPosition);

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

        public static CodeRange ReadBinary(BinaryReader reader) {
            var startLine = reader.ReadInt32();
            var endLine = reader.ReadInt32();
            var startPos = reader.ReadInt32();
            var endPos = reader.ReadInt32();
            return new CodeRange(
                    new CodeLocation(startLine, startPos), new CodeLocation(endLine, endPos));
        }

        public void WriteBinary(BinaryWriter writer) {
            writer.Write(StartLine);
            writer.Write(EndLine);
            writer.Write(StartPosition);
            writer.Write(EndPosition);
        }

        public static CodeRange Desrialize(Deserializer deserializer) {
            var startLine = deserializer.DeserializeInt();
            var endLine = deserializer.DeserializeInt();
            var startPos = deserializer.DeserializeInt();
            var endPos = deserializer.DeserializeInt();
            return new CodeRange(
                    new CodeLocation(startLine, startPos), new CodeLocation(endLine, endPos));
        }

        public void Serialize(Serializer serializer) {
            serializer.Serialize(StartLine);
            serializer.Serialize(EndLine);
            serializer.Serialize(StartPosition);
            serializer.Serialize(EndPosition);
        }

        #endregion

        /// <summary>
        /// Returns whether the specified location (line and position) is included this CodeRange instance.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool Contains(CodeLocation location) {
            return StartLocation <= location && location < EndLocation;
        }

        /// <summary>
        /// Returns whether the specified CodeRange value is included by this CodeRange instance.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Contains(CodeRange other) {
            return StartLocation <= other.StartLocation && other.EndLocation <= EndLocation;
        }

        /// <summary>
        /// Returns whether the specified CstNode instance is included by this CodeRange instance.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Contains(CstNode node) {
            return Contains(Locate(node));
        }

        /// <summary>
        /// Returns whether the specified AstNode instance is included by this CodeRange instance.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Contains(AstNode node) {
            return Contains(Locate(node));
        }

        /// <summary>
        /// Returns whether the specified CodeRange value is overlapped with this CodeRange instance.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Overlaps(CodeRange other) {
            return (StartLocation <= other.StartLocation && other.StartLocation < EndLocation) ||
                   (StartLocation < other.EndLocation && other.EndLocation <= EndLocation) ||
                   (other.StartLocation <= StartLocation && StartLocation < other.EndLocation) ||
                   (other.StartLocation < EndLocation && EndLocation <= other.EndLocation);
        }

        /// <summary>
        /// Returns whether the specified CstNode instance is overlapped with this CodeRange instance.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Overlaps(CstNode node) {
            return Overlaps(Locate(node));
        }

        /// <summary>
        /// Returns whether the specified AstNode instance is overlapped with this CodeRange instance.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Overlaps(AstNode node) {
            return Overlaps(Locate(node));
        }

        #region Find nodes

        /// <summary>
        /// Find all the inner elements which locate at this range from the specified CstNode instance.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IEnumerable<CstNode> FindIncludedNodes(CstNode root) {
            var thisRange = this;
            // TODO: Should be more efficient
            return thisRange.FindOutermostNode(root).DescendantsAndSelf()
                    .Where(
                            node => {
                                var range = Locate(node);
                                return thisRange.Contains(Locate(node));
                            });
        }

        /// <summary>
        /// Find all the inner elements which locate at this range from the specified AstNode instance.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IEnumerable<AstNode> FindIncludedNodes(AstNode root) {
            var thisRange = this;
            // TODO: Should be more efficient
            return thisRange.FindOutermostNode(root).DescendantsAndSelf()
                    .Where(
                            node => {
                                var range = Locate(node);
                                return thisRange.Contains(Locate(node));
                            });
        }

        /// <summary>
        /// Find all the inner elements whose range overlapped with this range from the specified CstNode instance.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IEnumerable<CstNode> FindOverlappedNodes(CstNode root) {
            var thisRange = this;
            // TODO: Should be more efficient
            return thisRange.FindOutermostNode(root).DescendantsAndSelf()
                    .Where(node => thisRange.Overlaps(Locate(node)));
        }

        /// <summary>
        /// Find all the inner elements whose range overlapped with this range from the specified AstNode instance.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IEnumerable<AstNode> FindOverlappedNodes(AstNode root) {
            var thisRange = this;
            // TODO: Should be more efficient
            return thisRange.FindOutermostNode(root).DescendantsAndSelf()
                    .Where(node => thisRange.Overlaps(Locate(node)));
        }

        /// <summary>
        /// Find the most inner element which includes this range from the specified CstNode instance.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public CstNode FindInnermostNode(CstNode root) {
            CstNode lastElement = null;
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
        /// Find the most inner element which includes this range from the specified AstNode instance.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public AstNode FindInnermostNode(AstNode root) {
            AstNode lastElement = null;
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
        /// Find the most outer element which includes this range from the specified root.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public CstNode FindOutermostNode(CstNode root) {
            var ret = FindInnermostNode(root);
            if (ret != null) {
                while (ret.Parent != null && ret.Parent.Children().Count() == 1) {
                    ret = ret.Parent;
                }
            }
            return ret;     // Returns null if the CodeRange is out of root node.
        }

        /// <summary>
        /// Find the most outer element which includes this range from the specified AstNode instance.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public AstNode FindOutermostNode(AstNode root) {
            var ret = FindInnermostNode(root);
            if (ret != null) {
                while (ret.Parent != null && ret.Parent.Children().Count() == 1) {
                    ret = ret.Parent;
                }
            }
            return ret;     // Returns null if the CodeRange is out of root node.
        }

        #endregion

        #region Inter-Conversion between a CodeRange object and indicies

        public string GetCodeFragment(string code) {
            var indicies = ConvertToIndicies(code);
            var length = indicies.Item2 - indicies.Item1;
            return length != 0
                    ? code.Substring(indicies.Item1, indicies.Item2 - indicies.Item1)
                    : string.Empty;
        }

        public string GetCodeFragment(StructuredCode code) {
            return code.GetFragment(this);
        }

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
            exclusiveEnd = headIndex + EndPosition;
        }

        public void ConvertToIndicies(
                StructuredCode code, out int inclusiveStart, out int exclusiveEnd) {
            inclusiveStart = code.GetIndex(StartLocation);
            exclusiveEnd = code.GetIndex(EndLocation);
        }

        public Tuple<int, int> ConvertToIndicies(string code) {
            int inclusiveStart, exclusiveEnd;
            ConvertToIndicies(code, out inclusiveStart, out exclusiveEnd);
            return Tuple.Create(inclusiveStart, exclusiveEnd);
        }

        public Tuple<int, int> ConvertToIndicies(StructuredCode code) {
            int inclusiveStart, exclusiveEnd;
            ConvertToIndicies(code, out inclusiveStart, out exclusiveEnd);
            return Tuple.Create(inclusiveStart, exclusiveEnd);
        }

        public static CodeRange ConvertFromIndicies(
                string code, int inclusiveStart, int exclusiveEnd) {
            var startLocation = CodeLocation.ConvertFromIndex(code, inclusiveStart);
            var endLocation = CodeLocation.ConvertFromIndex(
                    code, exclusiveEnd, startLocation, inclusiveStart);
            return new CodeRange(startLocation, endLocation);
        }

        public static CodeRange ConvertFromIndicies(
                StructuredCode code, int inclusiveStart, int exclusiveEnd) {
            var startLocation = CodeLocation.ConvertFromIndex(code, inclusiveStart);
            var endLocation = CodeLocation.ConvertFromIndex(code, exclusiveEnd, startLocation);
            return new CodeRange(startLocation, endLocation);
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

        public static CodeRange ConvertFromIndiciesSkippingWhitespaces(
                StructuredCode code, ref int inclusiveStart, ref int exclusiveEnd) {
            while (char.IsWhiteSpace(code[inclusiveStart])) {
                inclusiveStart++;
            }
            while (char.IsWhiteSpace(code[exclusiveEnd - 1])) {
                exclusiveEnd--;
            }
            return ConvertFromIndicies(code, inclusiveStart, exclusiveEnd);
        }

        #endregion

        #region Locate a node of an CST/AST

        public static CodeRange LocateIncludingHidden(XElement element) {
            return LocatePrivate(
                    element.DescendantsAndSelf()
                            .Where(e => e.Attribute(Code2XmlConstants.StartPositionName) != null));
        }

        public static CodeRange Locate(XElement element) {
            return LocatePrivate(
                    element.DescendantsAndSelf()
                            .Where(
                                    e =>
                                            e.Attribute(Code2XmlConstants.StartPositionName) != null
                                            && !e.IsHidden()));
        }

        public static CodeRange Locate(IEnumerable<XElement> elements) {
            return LocatePrivate(
                    elements.DescendantsAndSelf()
                            .Where(
                                    e =>
                                            e.Attribute(Code2XmlConstants.StartPositionName) != null
                                            && !e.IsHidden()));
        }

        public static CodeRange LocateWithHiddens(XElement element) {
            return LocatePrivate(element.DescendantsAndSelf());
        }

        public static CodeRange LocateWithHiddens(IEnumerable<XElement> elements) {
            return LocatePrivate(elements.DescendantsAndSelf());
        }

        public static XElement SetLocationAttributes(
                XElement element, string text, CodeLocation startLocation) {
            var exclusiveEndLocation = startLocation.Advance(text);
            element.SetAttributeValue(
                    Code2XmlConstants.StartLineName, startLocation.Line);
            element.SetAttributeValue(
                    Code2XmlConstants.StartPositionName, startLocation.Position);
            element.SetAttributeValue(
                    Code2XmlConstants.EndLineName, exclusiveEndLocation.Line);
            element.SetAttributeValue(
                    Code2XmlConstants.EndPositionName, exclusiveEndLocation.Position);
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

            return new CodeRange(
                    new CodeLocation(startLine, startPos), new CodeLocation(endLine, endPos));
        }

        public static CodeRange Locate(CstNode node) {
            var tuple = node.AllTokens().FirstAndLastOrNull();
            if (tuple != null) {
                var firstToken = tuple.Item1;
                var lastToken = tuple.Item2;
                return new CodeRange(
                        new CodeLocation(firstToken.StartLine, firstToken.StartPosition),
                        new CodeLocation(lastToken.EndLine, lastToken.EndPosition));
            }
            return Nil;
        }

        public static CodeRange Locate(AstNode node) {
            var tuple = node.AllTokens()
                .Where(n => n.StartPosition.HasValue)
                .FirstAndLastOrNull();
            if (tuple != null) {
                var firstToken = tuple.Item1;
                var lastToken = tuple.Item2;
                return new CodeRange(
                        new CodeLocation(firstToken.StartLine.Value, firstToken.StartPosition.Value),
                        new CodeLocation(lastToken.EndLine.Value, lastToken.EndPosition.Value));
            }
            return Nil;
        }

        public static CodeRange LocateWithHiddens(CstNode node) {
            var tuple = node.AllTokensWithHiddens().FirstAndLastOrNull();
            if (tuple != null) {
                var firstToken = tuple.Item1;
                var lastToken = tuple.Item2;
                return new CodeRange(
                        new CodeLocation(firstToken.StartLine, firstToken.StartPosition),
                        new CodeLocation(lastToken.EndLine, lastToken.EndPosition));
            }
            return Nil;
        }

        #endregion
    }
}