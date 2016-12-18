#region License

// Copyright (C) 2011-2016 Kazunori Sakamoto
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

using Code2Xml.Core.Location;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Location {
    [TestFixture]
    public class StructuredCodeTest {
        [TestCase(@"//test
import javax.swing.*;
 
public class Hello extends JFrame {
    Hello() /*test*/ {
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        pack(); // pack();
    }
 
    public static void main(String[] args) {
        new Hello().setVisible(true);
    }
}", 10)]
        public void GetLine(string code, int lineNumber) {
            var structuredCode = new StructuredCode(code);
            structuredCode.GetLine(lineNumber);
        }
    }
}