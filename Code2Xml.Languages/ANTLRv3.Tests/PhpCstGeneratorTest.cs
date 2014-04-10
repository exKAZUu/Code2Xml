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

using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.Php;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
    [TestFixture]
    public class PhpCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new PhpCstGeneratorUsingAntlr3();
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
        [TestCase(@"<?php if (true) { }")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Seed.php")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("Php", fileName);
        }

        //[Test]
        //[TestCase("bedrock")]
        //[TestCase("cockpit")]
        ////[TestCase("CodeIgniter")]	// failed
        ////[TestCase("composer")]	// too heavy
        //[TestCase("composer-service")]
        ////[TestCase("core")]	// failed
        //[TestCase("flight")]
        //[TestCase("flysystem")]
        ////[TestCase("google-api-php-client")]	// failed
        //[TestCase("gush")]
        ////[TestCase("guzzle")]	// failed
        //[TestCase("laravel")]
        ////[TestCase("Mobile-Detect")]	// failed
        ////[TestCase("phabricator")]	// failed
        ////[TestCase("phoronix-test-suite")]	// failed
        //[TestCase("phpdotenv")]
        ////[TestCase("PHPMailer")]	// failed
        ////[TestCase("php-mpos")]	// failed
        //[TestCase("php-mvc")]
        ////[TestCase("piwik")]	// failed
        ////[TestCase("psysh")]	// too heavy
        ////[TestCase("rocketeer")]	// failed
        //[TestCase("sovereign")]
        ////[TestCase("symfony")]	// failed
        ////[TestCase("yii")]	// failed
        ////[TestCase("yii2")]	// failed
        ////[TestCase("YOURLS")]	// failed
        ////[TestCase("zf2")]	// failed
        //public void ParseDirectory(string directoryName) {
        //    VerifyRestoringProjectDirectory("Php", directoryName, "*.php");
        //}

        [Test]
        [TestCase(@"https://github.com/roots/bedrock.git",
                @"f0c21c22e3366f0777fe88decd43f62e61e028dd")]
        [TestCase(@"https://github.com/aheinze/cockpit.git",
                @"42136f0173b732ec8b1d8aacf612521bec11331d")]
        [TestCase(@"https://github.com/pborreli/composer-service.git",
                @"44e13091818b0219e9943572e52376b76043cebe")]
        [TestCase(@"https://github.com/mikecao/flight.git",
                @"b9b2d0fa2d75e6b2f606fbd0d9a8059a0f741578")]
        [TestCase(@"https://github.com/thephpleague/flysystem.git",
                @"63686a3d3fa27276fcd2b1562b2aa696d3d9e51d")]
        [TestCase(@"https://github.com/cordoval/gush.git",
                @"7863bc406ed3948b8b28d44d5c8124b9590a9d06")]
        [TestCase(@"https://github.com/laravel/laravel.git",
                @"a2cb6049c9bbbc4a65a07d1827ac7cb5a646fcd4")]
        [TestCase(@"https://github.com/vlucas/phpdotenv.git",
                @"a6d7d9778975100460a24395f8b5175024e14a54")]
        [TestCase(@"https://github.com/panique/php-mvc.git",
                @"2fe402b7e10a642c18a56826366dfdb1bcd5b2ad")]
        [TestCase(@"https://github.com/al3x/sovereign.git",
                @"18ea566cee435c47e7b706b7c607b932f16fe66a")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.java");
        }
    }
}