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

using Code2Xml.Languages.ANTLRv4.Processors.Java;
using NUnit.Framework;
using Paraiba.Core;

namespace Code2Xml.Languages.ANTLRv4.Tests.Processors.Java {
	[TestFixture]
	public class JavaProcessorTest {
		[Test]
		public void Parse() {
			var code = @"import javax.swing.*;
 
public class Hello extends JFrame {
    Hello() {
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        pack();
    }
 
    public static void main(String[] args) {
        new Hello().setVisible(true);
    }
}";
			var processor = new JavaProcessor();
			var xml = processor.GenerateXml(code);
			var code2 = processor.GenerateCode(xml);
			Assert.That(code2.ReplaceNewlinesForWindows(),
				Is.EqualTo(@"import javax . swing . * ;
public class Hello extends JFrame {
	Hello ( ) {
		setDefaultCloseOperation ( WindowConstants . DISPOSE_ON_CLOSE ) ;
		pack ( ) ;
	}
	public static void main ( String [ ] args ) {
		new Hello ( ) . setVisible ( true ) ;
	}
}
".ReplaceNewlinesForWindows()));
		}
	}
}