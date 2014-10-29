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
        //[TestCase(@"https://github.com/composer/composer",
        //        @"a309e1d89ded6919935a842faeaed8e888fbfe37", 4520)]
        //[TestCase(@"https://github.com/fzaninotto/Faker",
        //        @"b6d383161d84092a7a9f5b14db6e2637edbd3a6e", 4493)]
        //[TestCase(@"https://github.com/phacility/phabricator",
        //        @"a4b281aa291621c7d75739f3e9be8cf7e33d4240", 4423)]
        [TestCase(@"https://github.com/guzzle/guzzle",
                @"3e5a4bba47291f6a12872f44128715950fc35e86", 4157)]
        //[TestCase(@"https://github.com/codeguy/Slim",
        //        @"52de96e42801661c41973a7b4c6979f883f02b43", 4112)]
        [TestCase(@"https://github.com/yiisoft/yii",
                @"7d65d74855620fcdca26decb998f45bc00be74dd", 4107)]
        [TestCase(@"https://github.com/zurb/ink",
                @"91171dc7a2a4ba9e2c1726c36d70d799cec17ce6", 4029)]
        [TestCase(@"https://github.com/al3x/sovereign",
                @"5f6160f914c647ddb6a3d8e47d1b5a46fbf6b22c", 3991)]
        //[TestCase(@"https://github.com/sebastianbergmann/phpunit",
        //        @"0b78eddd0519dd9bf7c35359287fa6b0adb17391", 3984)]
        //[TestCase(@"https://github.com/yiisoft/yii2",
        //        @"6fb62f836bd7e35efab3267adfd08e34a6ba973d", 3855)]
        [TestCase(@"https://github.com/serbanghita/Mobile-Detect",
                @"5f215c5fc8a2bbc81142c5b26fb9abffb2adcb97", 3594)]
        [TestCase(@"https://github.com/facebookarchive/facebook-php-sdk",
                @"3388ec541761b93651614b48766608c22daad981", 3566)]
        [TestCase(@"https://github.com/ginatrapani/ThinkUp",
                @"52ace51f9f0541982b61b3b8180e2cdc95f0566f", 3154)]
        [TestCase(@"https://github.com/PHPOffice/PHPExcel",
                @"37b4d18d456e3b533d838099f208e5d3f089a954", 2992)]
        [TestCase(@"https://github.com/piwik/piwik",
                @"f4dbc61263d401a003c300847af19cf4b1f5db13", 2932)]
        [TestCase(@"https://github.com/subtlepatterns/SubtlePatterns",
                @"6e056565a1254c967228aab60c9d9c7d0e63a7e3", 2886)]
        [TestCase(@"https://github.com/kriswallsmith/assetic",
                @"f8a41b17522dadccbaeb422d4c6617b46c4c52f5", 2721)]
        //[TestCase(@"https://github.com/owncloud/core",
        //        @"a00712aa65169b248cac8e541dfe69fd82082609", 2679)]
        [TestCase(@"https://github.com/reactphp/react",
                @"9db35d22a50e1bc473a5967876fe1daf8ef4a539", 2676)]
        [TestCase(@"https://github.com/Seldaek/monolog",
                @"d0a9acbad0643726453e901d9d49c14e13de9f86", 2675)]
        [TestCase(@"https://github.com/laravel/framework",
                @"687ad93f18e47fbb530d17f109c9043126dd164c", 2646)]
        [TestCase(@"https://github.com/PHPMailer/PHPMailer",
                @"2000bbb41f7cbb4db766436ab7c996907a8c1c31", 2640)]
        [TestCase(@"https://github.com/JeffreyWay/Laravel-4-Generators",
                @"457228dc2c0bef7ef75014f8e711def7732fb0ef", 2580)]
        [TestCase(@"https://github.com/abraham/twitteroauth",
                @"0d9c7fb3057c9f7cdc8847566ae9bd398165c761", 2546)]
        [TestCase(@"https://github.com/twigphp/Twig",
                @"f8b6e918a7d8e073efe14cbed7ae02df40ef19ed", 2431)]
        [TestCase(@"https://github.com/puphpet/puphpet",
                @"5cff10cb105e6928b4cfb308c769a8d6378125ee", 2394)]
        [TestCase(@"https://github.com/silexphp/Silex",
                @"bce2a5dc5931411ce319ebb470b1f4132cfddf08", 2374)]
        [TestCase(@"https://github.com/doctrine/doctrine2",
                @"20c6bfd360b3db9e9bc53e5ae37afe1a22dccca3", 2303)]
        [TestCase(@"https://github.com/avalanche123/Imagine",
                @"5b23b4a7d82e611ef0634ab98a446e1657360c23", 2211)]
        [TestCase(@"https://github.com/fabpot/Goutte",
                @"33b16e073667a3408b6a1e8c464614fbb731041a", 2186)]
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