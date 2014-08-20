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

using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.Php;
using Code2Xml.Learner.Core.Learning.Experiments;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3 {
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
        [TestCase(@"<?php print $output;")]
        [TestCase(@"<?php list( $this->parm ) = $parms;")]
        [TestCase(@"<?php function &f() { }")]
        [TestCase(@"<?php $response = $interface::preload();")]
        [TestCase(@"<?php $response = $interface::$preload();")]
        [TestCase(@"<?php $response = interface::preload();")]
        [TestCase(@"<?php $response = preload();")]
        [TestCase(@"<?php int;")]
        [TestCase(@"<?php $classname::int;")]
        [TestCase(@"<?php $classname::CONST_VALUE;")]
        [TestCase(@"<?php $classname::$my_static;")]
        [TestCase(@"<?php self::CONST_VALUE;")]
        [TestCase(@"<?php self::CONST_VALUE();")]
        [TestCase(@"<?php interface::preload();")]
        [TestCase(@"<?php interfac::preload();")]
        [TestCase(@"<?php self::$my_static;")]
        [TestCase(@"<?php \xxx\yyy::zzz();")]
        [TestCase(@"<?php class::preload();")]
        [TestCase(@"<?php function ($results) use (&$output) {};")]
        [TestCase(@"<?php function ($results) {};")]
        [TestCase(@"<?php $i = 0 + 1 - 2 * 3 / 4;")]
        [TestCase(@"")]
        [TestCase(@"
<?php
	function filemtime($path)
	{
		if($this->embedExpiry)
			return (int)@file_get_contents($path,false,null,0,10);
		else
			return @filemtime($path);
	}
")]
        [TestCase(@"
<?php

class AdapterOptions extends AbstractOptions
{
    protected function normalizeTtl(&$ttl)
    {
        if (!is_int($ttl)) {
            $ttl = (float) $ttl;

            // convert to int if possible
            if ($ttl === (float) (int) $ttl) {
                $ttl = (int) $ttl;
            }
        }

        if ($ttl < 0) {
             throw new Exception\InvalidArgumentException('');
        }
    }
}
")]
        [TestCase(@"
<?php

namespace Balanced;

class Resource extends \RESTful\Resource
{

    public static function convertError($response)
    {
        $error = $codes[0]();
        return $error;
    }

}
")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Seed.php")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("Php", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/cakephp/cakephp.git",
                @"e9c9e9697d275e0e15277d21e23edbf975443425", 4670)]
        [TestCase(@"https://github.com/zendframework/zf2.git",
                @"0ce25cc36d430095dbc89f4de19dc319b4f90ee4", 4660)]
        [TestCase(@"https://github.com/WordPress/WordPress.git",
                @"77e2da21cf2925e1b809888969677184c3d34fec", 3790)]
        [TestCase(@"https://github.com/domnikl/DesignPatternsPHP.git",
                @"ed291cd959053366e9d9edba62d8633034f93b0b", 3757)]
        [TestCase(@"https://github.com/yiisoft/yii.git",
                @"ffb9a06b2fdeef83098221334bfd34bc8c2e2aa6", 3682)]
        [TestCase(@"https://github.com/sebastianbergmann/phpunit.git",
                @"d8bd89e337ad2f810131b5e291d695b5671bbf23", 3619)]
        [TestCase(@"https://github.com/zurb/ink.git",
                @"af382061180d2f5efa9a088ed3ee005e575377d4", 3580)]
        [TestCase(@"https://github.com/facebook/phabricator.git",
                @"47245b1b59c7523af8f442ba05ffb4a4a8b41991", 3497)]
        [TestCase(@"https://github.com/codeguy/Slim.git",
                @"4906b77a07c7bd6ff1a99aea903e940a2d4fa106", 3487)]
        [TestCase(@"https://github.com/facebook/facebook-php-sdk.git",
                @"8a992afce97122556c4e42b0f1c1d60b9d49276d", 3392)]
        [TestCase(@"https://github.com/fzaninotto/Faker.git",
                @"89345a3ccc366bc14e0a984a086cc66028bd6411", 3366)]
        [TestCase(@"https://github.com/Automattic/_s.git",
                @"2d2f66f9a1e3ecd40fb6e5ba90e4e5a44ed3b5ae", 3258)]
        [TestCase(@"https://github.com/guzzle/guzzle.git",
                @"364fa40fb8dccbd1fb6da564a7996f75a36e8d36", 3170)]
        [TestCase(@"https://github.com/ginatrapani/ThinkUp.git",
                @"06bc738952cd534938ebd03fe05a8f1a0cb9d8b8", 3033)]
        [TestCase(@"https://github.com/al3x/sovereign.git",
                @"4349e03dfc4b53e75a78441ebd8ace93f8e4cd47", 2927)]
        [TestCase(@"https://github.com/serbanghita/Mobile-Detect.git",
                @"d70de7bfd0641d4d32a6f9c71e1f5d2839a5331e", 2862)]
        [TestCase(@"https://github.com/abraham/twitteroauth.git",
                @"4b775766fe3526ebc67ee20c97ff29a3b47bc5d8", 2304)]
        [TestCase(@"https://github.com/subtlepatterns/SubtlePatterns.git",
                @"6e056565a1254c967228aab60c9d9c7d0e63a7e3", 2271)]
        [TestCase(@"https://github.com/PHPOffice/PHPExcel.git",
                @"c2a277c447ca965bbe030cd83d6b92df95661541", 2240)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepo(url, commitPointer, "*.php");
        }
    }
}