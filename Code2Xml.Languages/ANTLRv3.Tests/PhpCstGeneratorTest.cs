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
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Seed.php")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("Php", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/roots/bedrock.git",
                @"513a3cff64b29be7a4d08ffdfa9728c55a30b68a")]
        [TestCase(@"https://github.com/aheinze/cockpit.git",
                @"3b65c826559d45833078a1e1f196773495fdd47f")]
        [TestCase(@"https://github.com/pborreli/composer-service.git",
                @"38c12f002cfad65e32510f80778a645ddfa03c48")]
        [TestCase(@"https://github.com/mikecao/flight.git",
                @"2776d542286c1abd0e91b3892dd02029085c1ba8")]
        [TestCase(@"https://github.com/thephpleague/flysystem.git",
                @"4fb166cbba5b6614d67ee2b361afed6e0901dc9c")]
        [TestCase(@"https://github.com/cordoval/gush.git",
                @"37576d4211e7d23dbe5a7e6477ede4be4ded047b")]
        [TestCase(@"https://github.com/laravel/laravel.git",
                @"aeda6b13cdfcd662089c30d428839965c7443ab9")]
        [TestCase(@"https://github.com/panique/php-mvc.git",
                @"319eaa8c845569592c3fbefdd15003848e49226e")]
        [TestCase(@"https://github.com/vlucas/phpdotenv.git",
                @"8efa54e839f569422d5891b69495ebeaeee5e7ca")]
        [TestCase(@"https://github.com/al3x/sovereign.git",
                @"5853ee92615b67a4f4bd802ff7493cb684294a79")]
        [TestCase(@"https://github.com/serbanghita/Mobile-Detect.git",
                @"d6943b36f45a9ee654e87cd98832890797a228fb")]
        [TestCase(@"https://github.com/Anahkiasen/rocketeer.git",
                @"3591b74208e632ce5ffe090ffcd19330785feb77")]
        [TestCase(@"https://github.com/PHPMailer/PHPMailer.git",
                @"01f4c43b683d994e461d4e5049e88d8c5daff31d")]
        [TestCase(@"https://github.com/phoronix-test-suite/phoronix-test-suite.git",
                @"307a0c3f7d5fb1a5fee93e59e52410e04b9868e0")]
        // Failed test cases
        //[TestCase(@"https://github.com/EllisLab/CodeIgniter.git",
        //        @"8fb31c929b9cca6154eb007ff553f4a96d31415e")]
        //[TestCase(@"https://github.com/YOURLS/YOURLS.git",
        //        @"f645c06f054c851ce00fd8c349f567b7a0b2100f")]
        //[TestCase(@"https://github.com/composer/composer.git",
        //        @"7adc41d02c3536b3e19a6b906cf0c4cf6d3beb70")] // not terminate
        //[TestCase(@"https://github.com/owncloud/core.git",
        //        @"9fa788c452403646cc5c2a7c0fe875879e7082fa")]
        //[TestCase(@"https://github.com/google/google-api-php-client.git",
        //        @"7b7030e33fa6e99071ebe1369c8c23443e642a95")]
        //[TestCase(@"https://github.com/guzzle/guzzle.git",
        //        @"028195b32bb2e096b168baebe07c704473db81d4")]
        //[TestCase(@"https://github.com/facebook/phabricator.git",
        //        @"e61069f0d6b798e958987ccbb90110e548694903")]
        //[TestCase(@"https://github.com/MPOS/php-mpos.git",
        //        @"481c8dd980fe0603e38d7e1e464cd74b8ced5d17")]
        //[TestCase(@"https://github.com/piwik/piwik.git",
        //        @"b234e0ac5aa70a1b8d1e9115f79ffaa00b5a40e2")]
        //[TestCase(@"https://github.com/bobthecow/psysh.git",
        //        @"46dd9a050405ecc2a3d1203d57bcff0f00675ff5")] // not terminate
        //[TestCase(@"https://github.com/symfony/symfony.git",
        //        @"78d49fbe8c479722319d9e7f1021c89ba6e55308")]
        //[TestCase(@"https://github.com/yiisoft/yii.git",
        //        @"2c2f25ba411e9e8d8b9fe3d7a2598940e05eb645")]
        //[TestCase(@"https://github.com/yiisoft/yii2.git",
        //        @"30accd28d6507935acb0ce3d7a1b374a3117d878")]
        //[TestCase(@"https://github.com/zendframework/zf2.git",
        //        @"4fe2829353077239aafc9ffe39a15c07bba5b660")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.php");
        }
    }
}