using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.SrcML.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Languages.SrcML.Tests
{
    public class SrcMLForCCodeToXmlTest
    {
		[Test, Ignore]
		public void CanParseJapanese() {
			var xml = SrcMLForCCodeToXml.Instance.Generate(@"int あ;", true);
            Assert.That(xml.ToString(), Is.StringContaining("あ"));
		}
    }
}
