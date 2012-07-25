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
using System.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.C.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Languages.C.Tests {
    [TestFixture]
    public class CCodeToXmlTest {
        /*
        [Test]
        public void ParseQuicksortp()
        {
            var path = Fixture.GetInputPath(
                    "C", "quicksort_p.c");
            CCodeToXml.Instance.GenerateFromFile(path, true);
        }*/

        [Test]
        public void ParseQuicksortpSub()
        {
            var path = Fixture.GetInputPath(
                    "C", "quicksort_p_sub.c");
            CCodeToXml.Instance.GenerateFromFile(path, true);
        }
        [Test]
        public void ParseDoubleUnderScore()
        {
            var path = Fixture.GetInputPath(
                    "C", "DoubleUnderScore.c");
            CCodeToXml.Instance.GenerateFromFile(path, true);
        }
        
        [Test]
        public void ParseMulmv()
        {
            var path = Fixture.GetInputPath(
                    "C", "mul_mv.c");
            CCodeToXml.Instance.GenerateFromFile(path, true);
        }
        [Test]
        public void ParseBlock1()
        {
            var path = Fixture.GetInputPath(
                    "C", "Block1.c");
            CCodeToXml.Instance.GenerateFromFile(path, true);
        }
        [Test]
        public void ParseMersenne()
        {
            var path = Fixture.GetInputPath(
                    "C", "mersenne.c");
            CCodeToXml.Instance.GenerateFromFile(path, true);
        }
        [Test]
        public void ParseMulti()
        {
            var path = Fixture.GetInputPath(
                    "C", "multi.h");
            CCodeToXml.Instance.GenerateFromFile(path, true);
        }

    }
}