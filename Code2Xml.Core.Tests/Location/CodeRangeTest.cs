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
using Code2Xml.Core.Location;
using Code2Xml.Languages.Java.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Location {
	[TestFixture]
	public class CodeRangeTest {
		[Test]
		[TestCase(1, 1, false)]
		[TestCase(1, 3, false)]
		[TestCase(1, 5, true)]
		[TestCase(1, 6, true)]
		[TestCase(2, 0, true)]
		[TestCase(2, 3, true)]
		[TestCase(2, 4, false)]
		public void ContainsCodeLocation(int line, int pos, bool contained) {
			Assert.That(
					new CodeRange(new CodeLocation(1, 5), new CodeLocation(2, 3))
							.Contains(new CodeLocation(line, pos)), Is.EqualTo(contained));
		}

		[Test]
		[TestCase(1, 0, 1, 1, false)]
		[TestCase(1, 0, 1, 5, false)]
		[TestCase(1, 0, 1, 6, false)]
		[TestCase(1, 5, 1, 6, true)]
		[TestCase(1, 5, 2, 1, true)]
		[TestCase(1, 5, 2, 3, true)]
		[TestCase(1, 5, 2, 8, false)]
		[TestCase(2, 7, 2, 8, false)]
		public void ContainsCodePosition(
				int startLine, int startPos, int endLine, int endPos, bool contained) {
			Assert.That(
					new CodeRange(new CodeLocation(1, 5), new CodeLocation(2, 3))
							.Contains(
									new CodeRange(
											new CodeLocation(startLine, startPos),
											new CodeLocation(endLine, endPos))),
					Is.EqualTo(contained));
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
			var xml = JavaCodeToXml.Instance.Generate(@"
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
		public void InterConvertCodeRangeAndIndicies() {
			var code = @"
public class Hello {
	public static void main(String[] args) {
		System.out.println(1);
	}
}";
			var ast = JavaCodeToXml.Instance.Generate(code);
			var elem = ast.DescendantsAndSelf("statement").First();
			int inclusiveStart, exclusiveEnd;
			int newInclusiveStart, newExclusiveEnd;
			var range = CodeRange.Locate(elem);
			range.ConvertToIndicies(code, out inclusiveStart, out exclusiveEnd);
			var newRange = CodeRange.ConvertFromIndiciesSkippingWhitespaces(
					code, ref inclusiveStart, ref exclusiveEnd);
			newRange.ConvertToIndicies(code, out newInclusiveStart, out newExclusiveEnd);
			Assert.That(newRange, Is.EqualTo(range));
			Assert.That(newInclusiveStart, Is.EqualTo(inclusiveStart));
			Assert.That(newExclusiveEnd, Is.EqualTo(exclusiveEnd));
		}
	}
}