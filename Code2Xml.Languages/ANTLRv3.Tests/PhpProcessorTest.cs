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

using Code2Xml.Core;
using Code2Xml.Core.Tests;
using Code2Xml.Languages.ANTLRv3.Processors.Php;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
	[TestFixture]
	public class PhpProcessorTest : ProcessorTest {
		protected override Processor CreateProcessor() {
			return new PhpProcessorUsingAntlr3();
		}

		[Test]
		[TestCase(@"<?php $$a = 1;")]
		[TestCase(@"<?php echo 'Hello';")]
		[TestCase(@"<?php f();")]
		[TestCase(@"<?php f(function($class){});")]
		[TestCase(@"<?php $obj = new Klass(p);")]
		[TestCase(@"<?php $obj = new Group\Klass($p);")]
		[TestCase(@"<?php $obj = new \Group\Klass($p);")]
		[TestCase(@"<?php $obj = getArray()[0];")]
		[TestCase(@"<?php $obj = new static;")]
		[TestCase(@"<?php $obj = new parent;")]
		[TestCase(@"<?php switch (1) { case 1: case 2: break; }")]
		[TestCase(@"<?php namespace xxx { }")]
		[TestCase(@"<?php namespace xxx;")]
		[TestCase(@"<?php foreach(new xxx() as $a) {}")]
		[TestCase(@"<?php $i = (array)$x;")]
		[TestCase(@"<?php $i = array(1);")]
		[TestCase(@"<?php $i = unset(1);")]
		[TestCase(@"<?php $unset = 1;")]
		[TestCase(@"<?php $obj->f()->f();")]
		[TestCase(@"<?php $obj->{$v};")]
		[TestCase(@"<?php $s = ${$a};")]
		[TestCase(@"<?php function f($p = xx::yy) {}")]
		[TestCase(@"<?php \klass::m1();")]
		[TestCase(@"<?php const a = 1;")]
		[TestCase(@"<?php $a = -(1);")]
		[TestCase(@"<?php while (false);")]
		[TestCase(@"<?php $v = $v->v . $v->break;")]
		[TestCase(@"<?php if ($a = 1 + $b = 0) {}")]
		[TestCase(@"<?php 1 + $a = 1;")]
		[TestCase(@"<?php $x .= $y ^ $z;")]
		public void Parse(string code) {
			VerifyRestoringCode(code);
		}

		[Test]
		public void ParseFile(string fileName) {
			VerifyRestoringFile("Php", fileName);
		}

		[Test]
		[TestCase("cockpit")]
		[TestCase("composer-service")]
		[TestCase("php-mvc")]
		[TestCase("sovereign")]
		public void ParseDirectory(string fileName) {
			VerifyRestoringProjectDirectory("Php", fileName, "*.php");
		}
	}
}