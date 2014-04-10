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

using Code2Xml.Core.Location;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Location {
    [TestFixture]
    public class CodeLocationTest {
        [Test]
        [TestCase(2, 2, "aaa\r\nbbb", 3, 3)]
        [TestCase(2, 2, "aaa\r\n", 3, 0)]
        [TestCase(2, 2, "aaa", 2, 5)]
        public void Advance(
                int startLine, int startPos, string text, int endLine, int endPos) {
            var startLocation = new CodeLocation(startLine, startPos);
            var endLocation = startLocation.Advance(text);
            Assert.That(endLocation, Is.EqualTo(new CodeLocation(endLine, endPos)));
        }
    }
}