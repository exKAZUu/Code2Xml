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

using System;
using System.IO;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv4.Generators.C;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests.Generators {
    [TestFixture]
    public class CCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new CCstGenerator();
        }

        [Test]
        [TestCase(@"void main() {
pvariant = (__extension__ ({ __typeof__ (stype[0]) __x = (stype[0]); (void) __ctype_ptr__[__x]; (tolower) (__x);}) == 'p') ? 1 : 0;
}")]
        [TestCase(@"void main() {}")]
        [TestCase(@"void main() {}
")]
        [TestCase(@"union u { __extension__ struct { int a; }; int b; };")]
        [TestCase(@"enum e { a = 0, };")]
        [TestCase(@"struct s { struct { int a; } b; struct { int c; }; };")]
        [TestCase(@"char cs[] = ""\xa5\xc2\x28\x1a"";")]
        [TestCase(@"__extension__ unsigned long long _rand_next;")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("assignment.c")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("C", fileName);
        }
    }
}