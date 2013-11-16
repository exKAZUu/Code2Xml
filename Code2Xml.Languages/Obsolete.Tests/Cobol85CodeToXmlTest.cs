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

using Code2Xml.Languages.Cobol85.CodeToXmls;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.Obsolete.Tests {
	[TestFixture]
	public class Cobol85CodeToXmlTest {
		[Test]
		public void CanParse() {

            var path = Fixture.GetInputCodePath("Cobol85", "CM101M.CBL");
   //         var xmlFilePath = Fixture.GetRelativeExpectationPath("Cobol85", "hellowCobol85.xml");
            Cobol85CodeToXml.Instance.GenerateFromFile(path, true);

            //var path = Fixture.GetInputCodePath("Python2", "Block1.py");
            //Python2CodeToXml.Instance.GenerateFromFile(path, true);
		}

        //[Test]
        //public void CanParseJapanese() {
        //    var xml = Python2CodeToXml.Instance.Generate(@"print('あ')", true);
        //    Assert.That(xml.ToString(), Is.StringContaining("あ"));
        //}
	}
}