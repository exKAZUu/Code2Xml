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
using Code2Xml.Languages.Ruby18.CodeToXmls;
using IronRuby;
using NUnit.Framework;

namespace Code2Xml.Languages.Ruby18.Tests {
	[TestFixture]
	public class Ruby18CodeToXmlTest {
		[Test]
		public void コードを解析できる() {
			var path = Fixture.GetInputPath(
					"Ruby18", "block.rb");
			Ruby18CodeToXml.Instance.GenerateFromFile(path, true);
		}

		[Test]
		public void InvokeRubyScript() {
			var DirectoryPath = Path.Combine(
					"ParserScripts", "IronRubyParser");
			var engine = Ruby.CreateEngine();
			// ir.exe.config を参照のこと
			engine.SetSearchPaths(
					new[] {
							DirectoryPath,
					});

			var scope = engine.CreateScope();
			var source =
					engine.CreateScriptSourceFromFile(Path.Combine(DirectoryPath, "parser.rb"));
			source.Execute(scope);
		}
	}
}