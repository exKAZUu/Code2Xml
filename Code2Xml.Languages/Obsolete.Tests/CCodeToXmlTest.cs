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

using System;
using System.IO;
using Antlr.Runtime;
using Code2Xml.Languages.C.CodeToXmls;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.Obsolete.Tests {
	[TestFixture]
	public class CCodeToXmlTest {
		[Test]
		[TestCase("preprocessed/get_sign(gcc).c")]
		[TestCase("preprocessed/bubblesort.c")]
		[TestCase("preprocessed/quicksort.c")]
		[TestCase("preprocessed/nonAtte.c")]
		[TestCase("preprocessed/nonAtte02.c")]
		[TestCase("preprocessed/nonAtteInline.c")]
		[TestCase("preprocessed/Attribute.c")]
		[TestCase("preprocessed/get_sign3.c")]
		[TestCase("preprocessed/get_sign3.1864.c")]
		[TestCase("preprocessed/get_sign3.pass.c")]
		[TestCase("preprocessed/get_sign4.c")]
		[TestCase("DoubleUnderScore.c")]
		[TestCase("longlong.c")]
		[TestCase("mul_mv.c")]
		[TestCase("mersenne.c")]
		[TestCase("Block1.c")]
		[TestCase("multi.h")]
		public void Parse(string filePath) {
			var paths = filePath.Split(
					Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			var path = Fixture.GetInputCodePath("C", paths);
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

		[Test]
		public void ParseTypedefFunc() {
			var xml = CCodeToXml.Instance.Generate(
					@"
typedef int f(long argl, long argl2);

struct st {
	long argl2;
};
",
					true);
		}

		[Test]
		public void ParseTypedefStruct() {
			var xml = CCodeToXml.Instance.Generate(
					@"
typedef struct localeinfo_struct {
  int xxxx;
} _locale_tstruct,*_locale_t;
_locale_t locale;
",
					true);
		}

		[Test]
		public void ParseTypedefStruct2() {
			var xml = CCodeToXml.Instance.Generate(
					@"
typedef int (xxx)(const int *cipher);
struct private_key_st {
	int cipher;
};
",
					true);
		}

		[Test]
		public void ParseTypedef() {
			var xml = CCodeToXml.Instance.Generate(
					@"typedef void *AAAA(unsigned long);
// aaa
AAAA *cb;", true);
		}

		[Test]
		public void GetTokens() {
			var tokens = CCodeToXml.Instance.CreateTokenStream(
					@"typedef void *AAAA(unsigned long);
// aaa
AAAA *cb;");
			var list = tokens.GetTokens();
			tokens.Fill();
			foreach (var token in list) {
				if (token.Channel == TokenChannels.Default) {
					Console.WriteLine(token.Text);
				}
			}
			Assert.That(tokens.Count, Is.EqualTo(21));
		}
	}
}