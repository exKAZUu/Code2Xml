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
using Antlr.Runtime;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.C;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3 {
    [TestFixture]
    public class CCstGeneratorUsingAntlr3Test : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new CCstGeneratorUsingAntlr3();
        }

        [Test]
        [TestCase(@"void main() {
pvariant = (__extension__ ({ __typeof__ (stype[0]) __x = (stype[0]); (void) __ctype_ptr__[__x]; (tolower) (__x);}) == 'p') ? 1 : 0;
}")]
        [TestCase(@"void main() {}")]
        [TestCase(@"union u { __extension__ struct { int a; }; int b; };")]
        [TestCase(@"enum e { a = 0, };")]
        [TestCase(@"struct s { struct { int a; } b; struct { int c; }; };")]
        [TestCase(@"char cs[] = ""\xa5\xc2\x28\x1a"";")]
        [TestCase(@"typedef int f(long argl, long argl2); struct st {	long argl2; };")]
        //		[TestCase(@"typedef struct option option_t;
        //void main() {
        //	int x;
        //	x = (option_t){ ((void *)0), 0, ((void *)0), 0 };
        //}
        //")]
        [TestCase(@"typedef int f(long argl, long argl2); struct st {	long argl2; };")]
        [TestCase(@"
typedef int (xxx)(const int *cipher);
struct private_key_st {
	int cipher;
};")]
        [TestCase(@"
typedef struct localeinfo_struct {
  int xxxx;
} _locale_tstruct,*_locale_t;
_locale_t locale;")]
        [TestCase(@"typedef void *AAAA(unsigned long);
// aaa
AAAA *cb;")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        public void ParseWrongCode() {
            var cst = Generator.GenerateTreeFromCodeText(
                    @"
int main() {
	printf()
	return 0;
}
", false);
        }

        [Test]
        [TestCase("assignment.c")]
        [TestCase("preprocessed/get_sign(gcc).c")]
        [TestCase("preprocessed/bubblesort.c")]
        [TestCase("preprocessed/quicksort.c")]
        //[TestCase("preprocessed/nonAtte.c")]
        [TestCase("preprocessed/nonAtte02.c")]
        //[TestCase("preprocessed/nonAtteInline.c")]
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
        public void ParseFile(string fileName) {
            VerifyRestoringFile("C", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/Cyan4973/FiniteStateEntropy.git",
                @"2549f7ff026f1168dc09d705f7fb9a7856945740")]
        [TestCase(@"https://github.com/silentbicycle/greatest.git",
                @"64cc0eb00bc4eca7381652a162779c952327a7b8")]
        //[TestCase(@"libgit2")]
        //[TestCase(@"the_silver_searcher")]
        //[TestCase(@"twemproxy")]
        //[TestCase(@"bfgminer")]
        //[TestCase(@"Cinnamon")]
        //[TestCase(@"ejoy2d")]
        //[TestCase(@"exploit-database")]
        //[TestCase(@"lwan")]
        //[TestCase(@"micropython")]
        //[TestCase(@"redis")]
        //[TestCase(@"watchman")]
        //[TestCase(@"frida-core")]
        //[TestCase(@"libgdx")]
        //[TestCase(@"libuv")]
        //[TestCase(@"algo")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepo(
                    url, commitPointer,
                    filePath => CCstGeneratorUsingAntlr3AndGcc.PreprocessCode(
                            File.ReadAllText(filePath), Path.GetDirectoryName(filePath))
                    , "*.c");
        }

        [Test]
        public void GetTokens() {
            var tokens = new CCstGeneratorUsingAntlr3().CreateTokenStream(
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