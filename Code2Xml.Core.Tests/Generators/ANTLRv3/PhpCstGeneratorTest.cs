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

using System;
using Antlr.Runtime;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.Php;
using NUnit.Framework;
using PhpLexer = Code2Xml.Languages.ANTLRv3.Processors.Php.PhpLexer;
using PhpParser = Code2Xml.Languages.ANTLRv3.Processors.Php.PhpParser;

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
        //[TestCase(@"")] // Failed
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
        //[TestCase(@"https://github.com/laravel/laravel",
        //        @"5eb4d0afd7f5047ffd6532423c9150c363d01af8", 12693)]
        //[TestCase(@"https://github.com/symfony/symfony",
        //        @"65b6594a983b9291ad376b09281dd83e503b6abe", 9097)]
        //[TestCase(@"https://github.com/bcit-ci/CodeIgniter",
        //        @"865fb1c71f858ab54439e6854a7e5c5590cc56a4", 8353)]
        //[TestCase(@"https://github.com/jrburke/requirejs",
        //        @"252355fb785b65ba3ddc18430866cf0584fcd8e3", 6461)]
        //[TestCase(@"https://github.com/cakephp/cakephp",
        //        @"5b32fd7e257df77f43992e6e10477aff8ad5ad3a", 5231)]
        [TestCase(@"https://github.com/php-fig/fig-standards",
                @"887eb52c4caf6344f4c23902d734bdcaff093168", 5015)]
        //[TestCase(@"https://github.com/zendframework/zf2",
        //        @"3e6936d75c7fcb4220a9a547d78c6c217a746060", 4887)]
        [TestCase(@"https://github.com/domnikl/DesignPatternsPHP",
                @"37cdbd6c23329a28f105fc1475dcf00b3fd86866", 4865)]
        [TestCase(@"https://github.com/roots/roots",
                @"246594f2308393df619e28038a9db0fa5f272502", 4787)]
        //[TestCase(@"https://github.com/WordPress/WordPress",
        //        @"3949a8b6cc50a021ed93798287b4ef9ea8a560d9", 4637)]
        [TestCase(@"https://github.com/composer/composer",
                @"a309e1d89ded6919935a842faeaed8e888fbfe37", 4520)]
        [TestCase(@"https://github.com/fzaninotto/Faker",
                @"b6d383161d84092a7a9f5b14db6e2637edbd3a6e", 4493)]
        [TestCase(@"https://github.com/phacility/phabricator",
                @"a4b281aa291621c7d75739f3e9be8cf7e33d4240", 4423)]
        [TestCase(@"https://github.com/guzzle/guzzle",
                @"3e5a4bba47291f6a12872f44128715950fc35e86", 4157)]
        [TestCase(@"https://github.com/codeguy/Slim",
                @"52de96e42801661c41973a7b4c6979f883f02b43", 4112)]
        [TestCase(@"https://github.com/yiisoft/yii",
                @"7d65d74855620fcdca26decb998f45bc00be74dd", 4107)]
        [TestCase(@"https://github.com/zurb/ink",
                @"91171dc7a2a4ba9e2c1726c36d70d799cec17ce6", 4029)]
        [TestCase(@"https://github.com/al3x/sovereign",
                @"5f6160f914c647ddb6a3d8e47d1b5a46fbf6b22c", 3991)]
        [TestCase(@"https://github.com/sebastianbergmann/phpunit",
                @"0b78eddd0519dd9bf7c35359287fa6b0adb17391", 3984)]
        [TestCase(@"https://github.com/yiisoft/yii2",
                @"6fb62f836bd7e35efab3267adfd08e34a6ba973d", 3855)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            Action<string> parse = code => {
                var parser =
                        new PhpParser(
                                new CommonTokenStream(new PhpLexer(new ANTLRStringStream(code))));
                parser.TraceDestination = Console.Error;
                var ret = parser.prog();
            };
            MeasurePerformance(url, commitPointer, parse, "*.php");
        }
    }
}