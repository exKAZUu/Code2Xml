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
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators {
    public abstract class CstGeneratorTest :
            SyntaxTreeGeneratorTest<CstGenerator, CstNode, CstToken> {
        protected override void VerifyLocation(string code, CstNode root) {
            foreach (var node in root.AllTokens()) {
                Assert.That(node.Range.GetCodeFragment(code), Is.EqualTo(node.Text));
            }
            foreach (var node in root.DescendantsAndSelf()) {
                Assert.That(
                        CodeRange.LocateWithHiddens(node).GetCodeFragment(code),
                        Is.EqualTo(node.Code));
            }
        }
    }
}