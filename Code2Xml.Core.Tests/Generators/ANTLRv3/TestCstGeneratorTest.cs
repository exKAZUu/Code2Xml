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

using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.Test;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3 {
    [TestFixture]
    public class TestCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new TestCstGeneratorUsingAntlr3();
        }

        [Test]
        [TestCase(@"1 * a = 2 + 3")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }
    }
}