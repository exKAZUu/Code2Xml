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
using Code2Xml.Core;
using NUnit.Framework;

namespace Code2Xml.Languages.Tests {
	[TestFixture]
	public class AcceptanceTest {
		[Test]
		public void GatherIdentifier() {
			var code = @"class K { void main(String[] args) {} }";
			var xml = ProcessorLoader.JavaUsingAntlr3.GenerateXml(code);
			var ids = xml.Descendants("IDENTIFIER").ToList();
			Assert.That(ids.Count, Is.EqualTo(4));
		}

		[Test]
		public void GetComments() {
			var code = @"class K {
/** Main method */
void main(String[] args) {
  return; // return
}
} // test";
			var xml = ProcessorLoader.JavaUsingAntlr3.GenerateXml(code);
			var method = xml.Descendants("methodDeclaration").First();
			method.BeforeHiddens();
			//Assert.That(ids.Count, Is.EqualTo(4));
		}
	}
}