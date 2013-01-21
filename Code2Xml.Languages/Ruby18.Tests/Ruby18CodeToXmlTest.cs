using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.Ruby18.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Languages.Ruby18.Tests
{
	public class Ruby18CodeToXmlTest
	{
		[Test]
		public void コードを解析できる() {
			var path = Fixture.GetInputPath("Ruby18", "block.rb");
			Ruby18CodeToXml.Instance.GenerateFromFile(path, true);
		}

	}
}
