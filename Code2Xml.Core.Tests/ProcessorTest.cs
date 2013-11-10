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
using Code2Xml.Core.Processors;
using NUnit.Framework;

namespace Code2Xml.Core.Tests {
    public abstract class ProcessorTest {
        protected abstract LanguageProcessor CreateProcessor();

        protected void VerifyParsing(string code) {
            var processor = CreateProcessor();
            var xml = processor.GenerateXml(code);
            var code2 = processor.GenerateCode(xml);
            Assert.That(code2, Is.EqualTo(code));
            Console.WriteLine(xml);
        }
    }
}