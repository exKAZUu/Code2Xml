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

using System.IO;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.C.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Languages.C.Tests {
	[TestFixture]
	public class CCodeToXmlTest {
		[Test]
		[TestCase("preprocessed/bubblesort.c")]
		[TestCase("preprocessed/get_sign.c")]
		[TestCase("preprocessed/quicksort.c")]
		[TestCase("DoubleUnderScore.c")]
		[TestCase("Attribute.c")]
		[TestCase("nonAtte.c")]
		[TestCase("nonAtte02.c")]
		[TestCase("nonAtteInline.c")]
		[TestCase("longlong.c")]
		[TestCase("mul_mv.c")]
		[TestCase("mersenne.c")]
		[TestCase("Block1.c")]
		[TestCase("multi.h")]
		public void Parse(string filePath) {
			var paths = filePath.Split(
					Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			var path = Fixture.GetInputPath("C", paths);
			CCodeToXml.Instance.GenerateFromFile(path, true);
		}

		[Test]
		public void ParseWrongCode() {
			var xml = CCodeToXml.Instance.Generate(
					@"
int main() {
	printf()
	return 0;
}
",
					false);
		}
	}
}