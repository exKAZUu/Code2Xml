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
        [TestCase(@"https://github.com/laravel/laravel.git",
                @"af7092275956a839e79f49158312241d3ea3b7f9")] // Star: 9316
        [TestCase(@"https://github.com/yiisoft/yii2.git",
                @"c501ae4f4d35343115733f9a6a09259050a78d8f")] // Star: 2223
        [TestCase(@"https://github.com/owncloud/core.git",
                @"71de32186936c4afc2e48a566c2d3c6f3fdf365b")] // Star: 2074
        [TestCase(@"https://github.com/Anahkiasen/rocketeer.git",
                @"02e2eace2765d88754731d1c672bb14b0d2cf6ca")] // Star: 867
        [TestCase(@"https://github.com/gajus/vlad.git",
                @"65ecdb433485163a7bf27b3ed317cc458cf17aab")] // Star: 80
        [TestCase(@"https://github.com/guzzle/guzzle.git",
                @"222323bd6a2c79ea7e13bfe6b3b1435f007274fd")] // Star: 3166
        [TestCase(@"https://github.com/composer/composer.git",
                @"14f35e812cd41746c4a4a7a2dec2b2365c8cdc61")] // Star: 3686
        [TestCase(@"https://github.com/thephpleague/flysystem.git",
                @"387e012fa93878e3865ed8db1aa9daba8bf2f9c5")] // Star: 1045
        [TestCase(@"https://github.com/domnikl/DesignPatternsPHP.git",
                @"ed291cd959053366e9d9edba62d8633034f93b0b")] // Star: 3753
        [TestCase(@"https://github.com/JeffreyWay/Laravel-4-Generators.git",
                @"cf766fae573d35621c2f2a14f0710c5484edf3f0")] // Star: 1695
        [TestCase(@"https://github.com/fzaninotto/Faker.git",
                @"89345a3ccc366bc14e0a984a086cc66028bd6411")] // Star: 3363
        [TestCase(@"https://github.com/php-fig/fig-standards.git",
                @"2e276153b8f084d5d552ae3cf86876bb06b20385")] // Star: 4069
        [TestCase(@"https://github.com/Seldaek/monolog.git",
                @"03000a7fcd4072bd7e1f99c8ce4328621c5773b9")] // Star: 2053
        [TestCase(@"https://github.com/JakubOnderka/PHP-Parallel-Lint.git",
                @"9c601da4e840e35c7f85a0682b30b9b04400f9e0")] // Star: 35
        [TestCase(@"https://github.com/AdvancedCustomFields/acf5-beta.git",
                @"3be7f4586683e8aa1d6e20834eb4fccf8ea863e9")] // Star: 92
        [TestCase(@"https://github.com/facebook/phabricator.git",
                @"2509c6b0f57dc533607fb6811adc02529b0d6fd8")] // Star: 3497
        [TestCase(@"https://github.com/ginatrapani/ThinkUp.git",
                @"06bc738952cd534938ebd03fe05a8f1a0cb9d8b8")] // Star: 3032
        [TestCase(@"https://github.com/puphpet/puphpet.git",
                @"e4012cbbe0fc3b200b4750bb79673a9f468c1b9e")] // Star: 1800
        [TestCase(@"https://github.com/google/google-api-php-client.git",
                @"e1a2f23ada736923627d1db315d045f6d1d1cc1b")] // Star: 520
        [TestCase(@"https://github.com/sonata-project/SonataDoctrinePhpcrAdminBundle.git",
                @"33deaa30c2b554603647db05b7647d1b4e1c43ca")] // Star: 24
        [TestCase(@"https://github.com/PrestaShop/PrestaShop-modules.git",
                @"07a753b47a48200629eb7ef0f4a2373ccb26a093")] // Star: 91
        [TestCase(@"https://github.com/opencart/opencart.git",
                @"263117979c50f424feab60f9918e602f5bf9b2af")] // Star: 1092
        [TestCase(@"https://github.com/benedmunds/CodeIgniter-Ion-Auth.git",
                @"e083881869045eeee9f96f957a65872b9977450f")] // Star: 1184
        [TestCase(@"https://github.com/zendframework/modules.zendframework.com.git",
                @"3dd1f19d35eee60090acd7e2cdff2f279ffbc735")] // Star: 157
        [TestCase(@"https://github.com/zendframework/zf1.git",
                @"89bedb5de121610eee02b610c40b6f818200a6b3")] // Star: 165
        [TestCase(@"https://github.com/dingo/api.git",
                @"5687f23b56d62ccb62f1809da39e847da7508495")] // Star: 70
        [TestCase(@"https://github.com/symfony/symfony.git",
                @"c875acf3a264f852e4bb2ddc5987bb5426d41cda")] // Star: 8234
        [TestCase(@"https://github.com/EllisLab/CodeIgniter.git",
                @"db0873365aabce72390fe9ccf19081de143a1d51")] // Star: 7476
        [TestCase(@"https://github.com/PHPMailer/PHPMailer.git",
                @"7b384d0bedf7feb1d3cdfaae689d8c5b68eb0515")] // Star: 1600
        [TestCase(@"https://github.com/leroy-merlin-br/larasniffer.git",
                @"5f1c6104a8c9229357aba56312ba0cc6bf7863b6")] // Star: 47
        [TestCase(@"https://github.com/WordPress/WordPress.git",
                @"3de93ccba3525de41216784ca0ccc8863195d4f6")] // Star: 3789
        [TestCase(@"https://github.com/laravel/framework.git",
                @"627fc22cb2fdd343cb17b552955eb317860f023d")] // Star: 1850
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
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "php_repo.txt", "*.php");
        }
    }
}