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

using System.Linq;
using Code2Xml.Core.Generators.ANTLRv3.Java;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Location {
    [TestFixture]
    public class CodeRangeTest {
        [Test]
        [TestCase(1, 10, Result = false)]
        [TestCase(2, 1, Result = false)]
        [TestCase(2, 3, Result = false)]
        [TestCase(2, 5, Result = true)]
        [TestCase(2, 6, Result = true)]
        [TestCase(3, 0, Result = true)]
        [TestCase(3, 3, Result = false)]
        [TestCase(3, 4, Result = false)]
        [TestCase(5, 0, Result = false)]
        public bool ContainsCodeLocation(int line, int pos) {
            return new CodeRange(new CodeLocation(2, 5), new CodeLocation(3, 3))
                    .Contains(new CodeLocation(line, pos));
        }

        [Test]
        [TestCase(1, 0, 2, 1, Result = false)]
        [TestCase(1, 0, 2, 5, Result = false)]
        [TestCase(1, 0, 2, 10, Result = false)]
        [TestCase(1, 0, 3, 10, Result = false)]
        [TestCase(2, 0, 2, 1, Result = false)]
        [TestCase(2, 0, 2, 5, Result = false)]
        [TestCase(2, 0, 2, 10, Result = false)]
        [TestCase(2, 0, 3, 10, Result = false)]
        [TestCase(2, 5, 2, 10, Result = true)]
        [TestCase(2, 5, 3, 1, Result = true)]
        [TestCase(2, 5, 3, 3, Result = true)]
        [TestCase(2, 5, 3, 10, Result = false)]
        [TestCase(3, 7, 3, 8, Result = false)]
        public bool ContainsCodePosition(int startLine, int startPos, int endLine, int endPos) {
            var startLocation = new CodeLocation(startLine, startPos);
            var endLocation = new CodeLocation(endLine, endPos);
            return new CodeRange(new CodeLocation(2, 5), new CodeLocation(3, 3))
                    .Contains(new CodeRange(startLocation, endLocation));
        }

        [Test]
        [TestCase(1, 0, 2, 1, Result = false)]
        [TestCase(1, 0, 2, 5, Result = false)]
        [TestCase(1, 0, 2, 6, Result = true)]
        [TestCase(1, 0, 2, 10, Result = true)]
        [TestCase(1, 0, 3, 10, Result = true)]
        [TestCase(2, 0, 2, 1, Result = false)]
        [TestCase(2, 0, 2, 5, Result = false)]
        [TestCase(2, 0, 2, 6, Result = true)]
        [TestCase(2, 0, 2, 10, Result = true)]
        [TestCase(2, 0, 3, 10, Result = true)]
        [TestCase(2, 5, 2, 10, Result = true)]
        [TestCase(2, 5, 3, 1, Result = true)]
        [TestCase(2, 5, 3, 3, Result = true)]
        [TestCase(2, 5, 3, 10, Result = true)]
        [TestCase(3, 2, 3, 8, Result = true)]
        [TestCase(3, 3, 3, 8, Result = false)]
        [TestCase(3, 7, 3, 8, Result = false)]
        public bool Overlaps(int startLine, int startPos, int endLine, int endPos) {
            return new CodeRange(new CodeLocation(2, 5), new CodeLocation(3, 3))
                    .Overlaps(
                            new CodeRange(
                                    new CodeLocation(startLine, startPos),
                                    new CodeLocation(endLine, endPos)));
        }

        [Test]
        public void FindElement() {
            var cst = new JavaCstGeneratorUsingAntlr3().GenerateTreeFromCodeText(@"
public class Hello {
	public static void main(String[] args) {
		System.out.println(1);
	}
}");
            var stmt = cst.Descendants("statement").First();
            var pos = CodeRange.Locate(stmt);
            Assert.That(pos.FindInnermostNode(cst), Is.EqualTo(stmt));
            Assert.That(pos.FindOutermostNode(cst), Is.EqualTo(stmt.Parent));
        }

        [Test]
        public void Locate() {
            var code = @"
public class Hello {
	public static void main(String[] args) {
	}
}";
            var xml = new JavaCstGeneratorUsingAntlr3().GenerateTreeFromCodeText(code);
            var id = xml.Descendants("IDENTIFIER").First();
            var range = CodeRange.Locate(id);
            Assert.That(range.GetCodeFragment(code), Is.EqualTo(id.TokenText));
            Assert.That(
                    range.GetCodeFragment(new StructuredCode(code)),
                    Is.EqualTo(id.TokenText));
        }

        [Test]
        [TestCase(@"class Klass { void method() { System.out.println(1); } }")]
        [TestCase(@"class Klass { void method() { System.out
.println(1); } }")]
        public void InterConvertCodeRangeAndIndicies(string code) {
            var ast = new JavaCstGeneratorUsingAntlr3().GenerateTreeFromCodeText(code);
            foreach (var elem in ast.DescendantsAndSelf("statement")) {
                int inclusiveStart, exclusiveEnd;
                var range = ConvertRangeToIndicies(code, elem, out inclusiveStart, out exclusiveEnd);
                ConvertIndiciesToRange(ast, code, inclusiveStart, exclusiveEnd, range);
            }
        }

        private static CodeRange ConvertRangeToIndicies(
                string code, CstNode node, out int inclusiveStart, out int exclusiveEnd) {
            var range = CodeRange.Locate(node);
            range.ConvertToIndicies(code, out inclusiveStart, out exclusiveEnd);
            Assert.That(
                    code.Substring(inclusiveStart, exclusiveEnd - inclusiveStart),
                    Is.EqualTo(node.Code.Trim()));

            range.ConvertToIndicies(new StructuredCode(code), out inclusiveStart, out exclusiveEnd);
            Assert.That(
                    code.Substring(inclusiveStart, exclusiveEnd - inclusiveStart),
                    Is.EqualTo(node.Code.Trim()));
            return range;
        }

        private static void ConvertIndiciesToRange(
                CstNode node, string code, int inclusiveStart, int exclusiveEnd, CodeRange range) {
            var newRange = CodeRange.ConvertFromIndicies(code, inclusiveStart, exclusiveEnd);
            var newInclusiveStart = char.IsWhiteSpace(code[inclusiveStart - 1])
                    ? inclusiveStart - 1 : inclusiveStart;
            var newExclusiveEnd = char.IsWhiteSpace(code[exclusiveEnd])
                    ? exclusiveEnd + 1 : exclusiveEnd;
            var elem = CodeRange.ConvertFromIndiciesSkippingWhitespaces(
                    code, ref newInclusiveStart, ref newExclusiveEnd)
                    .FindInnermostNode(node);
            Assert.That(CodeRange.Locate(elem), Is.EqualTo(newRange));

            newRange.ConvertToIndicies(code, out newInclusiveStart, out newExclusiveEnd);
            Assert.That(newRange, Is.EqualTo(range));
            Assert.That(newInclusiveStart, Is.EqualTo(inclusiveStart));
            Assert.That(newExclusiveEnd, Is.EqualTo(exclusiveEnd));

            var scode = new StructuredCode(code);
            Assert.That(
                    CodeRange.ConvertFromIndicies(scode, inclusiveStart, exclusiveEnd),
                    Is.EqualTo(range));
            newRange.ConvertToIndicies(scode, out newInclusiveStart, out newExclusiveEnd);
            Assert.That(newInclusiveStart, Is.EqualTo(inclusiveStart));
            Assert.That(newExclusiveEnd, Is.EqualTo(exclusiveEnd));
        }
    }
}