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
using System.Xml.Linq;

namespace Code2Xml.Core.Position {
	public static class CodePositions {
		public static CodePosition Create(XElement element) {
			return NewPrivate(element.DescendantsAndSelf());
		}

		public static CodePosition Create(IEnumerable<XElement> elements) {
			return NewPrivate(elements.DescendantsAndSelf());
		}

		private static CodePosition NewPrivate(
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