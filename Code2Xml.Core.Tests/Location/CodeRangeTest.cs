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

using System.Linq;
using System.Xml.Linq;
using Code2Xml.Core.Location;
using Code2Xml.Languages.ANTLRv3.Processors.Java;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Location {
	[TestFixture]
	public class CodeRangeTest {
		[Test]
		[TestCase(1, 1, Result = false)]
		[TestCase(1, 3, Result = false)]
		[TestCase(1, 5, Result = true)]
		[TestCase(1, 6, Result = true)]
		[TestCase(2, 0, Result = true)]
		[TestCase(2, 3, Result = true)]
		[TestCase(2, 4, Result = false)]
		public bool ContainsCodeLocation(int line, int pos) {
			return new CodeRange(new CodeLocation(1, 5), new CodeLocation(2, 3))
					.Contains(new CodeLocation(line, pos));
		}

		[Test]
		[TestCase(1, 0, 1, 1, Result = false)]
		[TestCase(1, 0, 1, 5, Result = false)]
		[TestCase(1, 0, 1, 6, Result = false)]
		[TestCase(1, 5, 1, 6, Result = true)]
		[TestCase(1, 5, 2, 1, Result = true)]
		[TestCase(1, 5, 2, 3, Result = true)]
		[TestCase(1, 5, 2, 8, Result = false)]
		[TestCase(2, 7, 2, 8, Result = false)]
		public bool ContainsCodePosition(int startLine, int startPos, int endLine, int endPos) {
			var startLocation = new CodeLocation(startLine, startPos);
			var endLocation = new CodeLocation(endLine, endPos);
			return new CodeRange(new CodeLocation(1, 5), new CodeLocation(2, 3))
					.Contains(new CodeRange(startLocation, endLocation));
		}

		[Test]
		[TestCase(1, 0, 1, 1, false)]
		[TestCase(1, 0, 1, 5, true)]
		[TestCase(1, 0, 1, 6, true)]
		[TestCase(1, 5, 1, 6, true)]
		[TestCase(1, 5, 2, 1, true)]
		[TestCase(1, 5, 2, 3, true)]
		[TestCase(1, 5, 2, 8, true)]
		[TestCase(2, 7, 2, 8, false)]
		public void Overlaps(
				int startLine, int startPos, int endLine, int endPos, bool contained) {
			Assert.That(
					new CodeRange(new CodeLocation(1, 5), new CodeLocation(2, 3))
							.Overlaps(
									new CodeRange(
											new CodeLocation(startLine, startPos),
											new CodeLocation(endLine, endPos))),
					Is.EqualTo(contained));
		}

		[Test]
		public void FindElement() {
			var xml = new JavaProcessorUsingAntlr3().GenerateXml(@"
public class Hello {
	public static void main(String[] args) {
		System.out.println(1);
	}
}");
			var elem = xml.Descendants("statement").First();
			var pos = CodeRange.Locate(elem);
			Assert.That(pos.FindInnerElement(xml), Is.EqualTo(elem));
			Assert.That(pos.FindOuterElement(xml), Is.EqualTo(elem.Parent));
		}

		[Test]
		[TestCase(@"class Klass { void method() { System.out.println(1); } }")]
		[TestCase(@"class Klass { void method() { System.out
.println(1); } }")]
		public void InterConvertCodeRangeAndIndicies(string code) {
            var ast = new JavaProcessorUsingAntlr3().GenerateXml(code);
			foreach (var elem in ast.DescendantsAndSelf("statement")) {
				int inclusiveStart, exclusiveEnd;
				var range = ConvertRangeToIndicies(code, elem, out inclusiveStart, out exclusiveEnd);
				ConvertIndiciesToRange(ast, code, inclusiveStart, exclusiveEnd, range);
			}
		}

		private static CodeRange ConvertRangeToIndicies(
				string code, XElement elem, out int inclusiveStart, out int exclusiveEnd) {
			var range = CodeRange.Locate(elem);
			range.ConvertToIndicies(code, out inclusiveStart, out exclusiveEnd);
			Assert.That(
					code.Substring(inclusiveStart, exclusiveEnd - inclusiveStart),
					Is.EqualTo(elem.Value));
			return range;
		}

		private static void ConvertIndiciesToRange(
				XElement ast, string code, int inclusiveStart, int exclusiveEnd, CodeRange range) {
			var newRange = CodeRange.ConvertFromIndicies(code, inclusiveStart, exclusiveEnd);
			var newInclusiveStart = char.IsWhiteSpace(code[inclusiveStart - 1])
					? inclusiveStart - 1 : inclusiveStart;
			var newExclusiveEnd = char.IsWhiteSpace(code[exclusiveEnd])
					? exclusiveEnd + 1 : exclusiveEnd;
			var elem = CodeRange.ConvertFromIndiciesSkippingWhitespaces(
					code, ref newInclusiveStart, ref newExclusiveEnd)
					.FindInnerElement(ast);
			Assert.That(CodeRange.Locate(elem), Is.EqualTo(newRange));

			newRange.ConvertToIndicies(code, out newInclusiveStart, out newExclusiveEnd);
			Assert.That(newRange, Is.EqualTo(range));
			Assert.That(newInclusiveStart, Is.EqualTo(inclusiveStart));
			Assert.That(newExclusiveEnd, Is.EqualTo(exclusiveEnd));
		}

		[Test]
		[TestCase(2, 2, "aaa\r\nbbb", 3, 2)]
		[TestCase(2, 2, "aaa\r\n", 2, 6)]
		[TestCase(2, 2, "aaa", 2, 4)]
		public void CalculateInclusiveEndLocation(
				int startLine, int startPos, string text, int endLine, int endPos) {
			var startLocation = new CodeLocation(startLine, startPos);
			var endLocation = CodeRange.CalculateInclusiveEndLocation(startLocation, text);
			Assert.That(endLocation, Is.EqualTo(new CodeLocation(endLine, endPos)));
		}
	}
}