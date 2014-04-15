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
        //[TestCase(@"https://github.com/roots/bedrock.git",
        //        @"513a3cff64b29be7a4d08ffdfa9728c55a30b68a")]
        //[TestCase(@"https://github.com/aheinze/cockpit.git",
        //        @"3b65c826559d45833078a1e1f196773495fdd47f")]
        //[TestCase(@"https://github.com/pborreli/composer-service.git",
        //        @"38c12f002cfad65e32510f80778a645ddfa03c48")]
        //[TestCase(@"https://github.com/mikecao/flight.git",
        //        @"2776d542286c1abd0e91b3892dd02029085c1ba8")]
        //[TestCase(@"https://github.com/thephpleague/flysystem.git",
        //        @"4fb166cbba5b6614d67ee2b361afed6e0901dc9c")]
        //[TestCase(@"https://github.com/cordoval/gush.git",
        //        @"37576d4211e7d23dbe5a7e6477ede4be4ded047b")]
        //[TestCase(@"https://github.com/laravel/laravel.git",
        //        @"aeda6b13cdfcd662089c30d428839965c7443ab9")]
        //[TestCase(@"https://github.com/panique/php-mvc.git",
        //        @"319eaa8c845569592c3fbefdd15003848e49226e")]
        //[TestCase(@"https://github.com/vlucas/phpdotenv.git",
        //        @"8efa54e839f569422d5891b69495ebeaeee5e7ca")]
        //[TestCase(@"https://github.com/al3x/sovereign.git",
        //        @"5853ee92615b67a4f4bd802ff7493cb684294a79")]
        //[TestCase(@"https://github.com/serbanghita/Mobile-Detect.git",
        //        @"d6943b36f45a9ee654e87cd98832890797a228fb")]
        //[TestCase(@"https://github.com/Anahkiasen/rocketeer.git",
        //        @"3591b74208e632ce5ffe090ffcd19330785feb77")]
        //[TestCase(@"https://github.com/PHPMailer/PHPMailer.git",
        //        @"01f4c43b683d994e461d4e5049e88d8c5daff31d")]
        //[TestCase(@"https://github.com/phoronix-test-suite/phoronix-test-suite.git",
        //        @"307a0c3f7d5fb1a5fee93e59e52410e04b9868e0")]

        // -------------------- Failed test cases --------------------

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
        [TestCase(@"https://github.com/laravel/laravel.git",
                @"af7092275956a839e79f49158312241d3ea3b7f9")] // Star: 9323
        [TestCase(@"https://github.com/symfony/symfony.git",
                @"c875acf3a264f852e4bb2ddc5987bb5426d41cda")] // Star: 8237
        [TestCase(@"https://github.com/EllisLab/CodeIgniter.git",
                @"aeed15eb8556ab671507f17ef9a8cf28903999aa")] // Star: 7477
        [TestCase(@"https://github.com/cakephp/cakephp.git",
                @"e9c9e9697d275e0e15277d21e23edbf975443425")] // Star: 4670
        [TestCase(@"https://github.com/zendframework/zf2.git",
                @"0ce25cc36d430095dbc89f4de19dc319b4f90ee4")] // Star: 4660
        [TestCase(@"https://github.com/php-fig/fig-standards.git",
                @"2e276153b8f084d5d552ae3cf86876bb06b20385")] // Star: 4068
        [TestCase(@"https://github.com/WordPress/WordPress.git",
                @"77e2da21cf2925e1b809888969677184c3d34fec")] // Star: 3790
        [TestCase(@"https://github.com/domnikl/DesignPatternsPHP.git",
                @"ed291cd959053366e9d9edba62d8633034f93b0b")] // Star: 3757
        [TestCase(@"https://github.com/composer/composer.git",
                @"14f35e812cd41746c4a4a7a2dec2b2365c8cdc61")] // Star: 3690
        [TestCase(@"https://github.com/yiisoft/yii.git",
                @"ffb9a06b2fdeef83098221334bfd34bc8c2e2aa6")] // Star: 3682
        [TestCase(@"https://github.com/sebastianbergmann/phpunit.git",
                @"d8bd89e337ad2f810131b5e291d695b5671bbf23")] // Star: 3619
        [TestCase(@"https://github.com/zurb/ink.git",
                @"af382061180d2f5efa9a088ed3ee005e575377d4")] // Star: 3580
        [TestCase(@"https://github.com/facebook/phabricator.git",
                @"47245b1b59c7523af8f442ba05ffb4a4a8b41991")] // Star: 3497
        [TestCase(@"https://github.com/codeguy/Slim.git",
                @"4906b77a07c7bd6ff1a99aea903e940a2d4fa106")] // Star: 3487
        [TestCase(@"https://github.com/facebook/facebook-php-sdk.git",
                @"8a992afce97122556c4e42b0f1c1d60b9d49276d")] // Star: 3392
        [TestCase(@"https://github.com/fzaninotto/Faker.git",
                @"89345a3ccc366bc14e0a984a086cc66028bd6411")] // Star: 3366
        [TestCase(@"https://github.com/Automattic/_s.git",
                @"2d2f66f9a1e3ecd40fb6e5ba90e4e5a44ed3b5ae")] // Star: 3258
        [TestCase(@"https://github.com/guzzle/guzzle.git",
                @"364fa40fb8dccbd1fb6da564a7996f75a36e8d36")] // Star: 3170
        [TestCase(@"https://github.com/ginatrapani/ThinkUp.git",
                @"06bc738952cd534938ebd03fe05a8f1a0cb9d8b8")] // Star: 3033
        [TestCase(@"https://github.com/al3x/sovereign.git",
                @"4349e03dfc4b53e75a78441ebd8ace93f8e4cd47")] // Star: 2927
        [TestCase(@"https://github.com/serbanghita/Mobile-Detect.git",
                @"d70de7bfd0641d4d32a6f9c71e1f5d2839a5331e")] // Star: 2862
        [TestCase(@"https://github.com/kriswallsmith/assetic.git",
                @"f2a5214034928d4c6849bc94cfd462ea832a50a8")] // Star: 2435
        [TestCase(@"https://github.com/yiisoft/yii2.git",
                @"c501ae4f4d35343115733f9a6a09259050a78d8f")] // Star: 2237
        [TestCase(@"https://github.com/PHPOffice/PHPExcel.git",
                @"c2a277c447ca965bbe030cd83d6b92df95661541")] // Star: 2240
        [TestCase(@"https://github.com/reactphp/react.git",
                @"7b996f82dc8b4b974fb719ab26f54fce028960a8")] // Star: 2192
        [TestCase(@"https://github.com/abraham/twitteroauth.git",
                @"4b775766fe3526ebc67ee20c97ff29a3b47bc5d8")] // Star: 2304
        [TestCase(@"https://github.com/fabpot/Twig.git",
                @"c8366374d9d531029a6b031528b552c37e1b2e66")] // Star: 2188
        [TestCase(@"https://github.com/doctrine/doctrine2.git",
                @"3a1e24e6801961128c27104919050d40d745030b")] // Star: 2104
        [TestCase(@"https://github.com/silexphp/Silex.git",
                @"3cbf93cfb0eb41b216be453ff40a4fa17f1bdbcd")] // Star: 2093
        [TestCase(@"https://github.com/owncloud/core.git",
                @"340089f270a778aeb296b1744821dcdb5878131e")] // Star: 2077
        [TestCase(@"https://github.com/piwik/piwik.git",
                @"e3efda0492c51cfb786f67419ea3a94c76f15e25")] // Star: 2066
        [TestCase(@"https://github.com/Seldaek/monolog.git",
                @"03000a7fcd4072bd7e1f99c8ce4328621c5773b9")] // Star: 2054
        [TestCase(@"https://github.com/subtlepatterns/SubtlePatterns.git",
                @"6e056565a1254c967228aab60c9d9c7d0e63a7e3")] // Star: 2271
        [TestCase(@"https://github.com/leafo/lessphp.git",
                @"b7cd5c79e82666bcd2dfadb304342311209fb527")] // Star: 1929
        [TestCase(@"https://github.com/avalanche123/Imagine.git",
                @"f93b6895f4567136528448263cc1fe71ee8504ce")] // Star: 1916
        [TestCase(@"https://github.com/laravel/framework.git",
                @"627fc22cb2fdd343cb17b552955eb317860f023d")] // Star: 1851
        [TestCase(@"https://github.com/anchorcms/anchor-cms.git",
                @"d0e113ade61f60cf2672037a687100eac5746330")] // Star: 1859
        [TestCase(@"https://github.com/puphpet/puphpet.git",
                @"e4012cbbe0fc3b200b4750bb79673a9f468c1b9e")] // Star: 1803
        [TestCase(@"https://github.com/pyrocms/pyrocms.git",
                @"26b64c5dcab1bcb0590647f2576daa81f77ae86e")] // Star: 1771
        [TestCase(@"https://github.com/JeffreyWay/Laravel-4-Generators.git",
                @"cf766fae573d35621c2f2a14f0710c5484edf3f0")] // Star: 1703
        [TestCase(@"https://github.com/bobthecow/mustache.php.git",
                @"43dc9457a2089cf86c0f7fdb79fcdc516293a4b6")] // Star: 1671
        [TestCase(@"https://github.com/philsturgeon/codeigniter-restserver.git",
                @"2aa6fec9a05a04d530c58ce77716bba2ba4f46ca")] // Star: 1684
        [TestCase(@"https://github.com/venomous0x/WhatsAPI.git",
                @"5ad50b311d728752cee50b7c7ed00062df6cb740")] // Star: 1613
        [TestCase(@"https://github.com/PHPMailer/PHPMailer.git",
                @"7b384d0bedf7feb1d3cdfaae689d8c5b68eb0515")] // Star: 1600
        [TestCase(@"https://github.com/tommcfarlin/WordPress-Plugin-Boilerplate.git",
                @"db289e22840277c26911d46972fe516ce309e430")] // Star: 1543
        [TestCase(@"https://github.com/fabpot/Goutte.git",
                @"06a5451288ffddd204b10fa6c6f9ab2b86dd515d")] // Star: 1584
        [TestCase(@"https://github.com/cboden/Ratchet.git",
                @"67cedf0ce6b6c7fbb5e305e0667ac219e655d561")] // Star: 1473
        [TestCase(@"https://github.com/gothfox/Tiny-Tiny-RSS.git",
                @"cda0418af19f55669f16c14c838ee44bf6fd8c99")] // Star: 1462
        [TestCase(@"https://github.com/drupal/drupal.git",
                @"95614ce35deb112da18f1f8841632b718be816c7")] // Star: 1439
        [TestCase(@"https://github.com/ccoenraets/backbone-directory.git",
                @"c5654ab50002a7865da849fbc743e7cea750a54e")] // Star: 1468
        [TestCase(@"https://github.com/magento/magento2.git",
                @"8611ea725e25c67683f3f7e533406291ae8a723b")] // Star: 1431
        [TestCase(@"https://github.com/simplebits/Pears.git",
                @"bd6211cdd2bf08682716e0a0b080ebee5b90da0b")] // Star: 1436
        [TestCase(@"https://github.com/MattWilcox/Adaptive-Images.git",
                @"faa87fd94fc59373df7c2e5bb605c7e3c28e38a4")] // Star: 1454
        [TestCase(@"https://github.com/filp/whoops.git",
                @"230da4810fc7fff67bf92061dc64eff4d451b68d")] // Star: 1375
        [TestCase(@"https://github.com/geocoder-php/Geocoder.git",
                @"972eed79fb50b6752b5154d391201f2ec7a8e11a")] // Star: 1381
        [TestCase(@"https://github.com/kohana/kohana.git",
                @"338bea96dfa197e7864674dab6cef78958e1f1df")] // Star: 1365
        [TestCase(@"https://github.com/WebDevStudios/Custom-Metaboxes-and-Fields-for-WordPress.git",
                @"c9402b287b6ffcfbc0eeab4109ece8f1a5d25848")] // Star: 1361
        [TestCase(@"https://github.com/woothemes/woocommerce.git",
                @"4afeb7926c912c2f5a9ac5fca6739274c9503014")] // Star: 1365
        [TestCase(@"https://github.com/fuel/fuel.git",
                @"82f79d7d9be671fafcfd9ca405425501bf8d8634")] // Star: 1313
        [TestCase(@"https://github.com/wp-cli/wp-cli.git",
                @"fd5a95f208bb0fa9422a03cf40091e1a7704e481")] // Star: 1309
        [TestCase(@"https://github.com/fabpot/PHP-CS-Fixer.git",
                @"5b601200086382cdb2c3c4b68b28487aabc287d2")] // Star: 1320
        [TestCase(@"https://github.com/mrclay/minify.git",
                @"fb3931f8cd54a637b2a42170c3a9a1c4da9e69a9")] // Star: 1287
        [TestCase(@"https://github.com/nrk/predis.git",
                @"83df2ef11c18ea490daf6a7a8789315f57f555a8")] // Star: 1302
        [TestCase(@"https://github.com/themeskult/wp-svbtle.git",
                @"45736be0e55e688a1111afe7d0f53d2ede79cfdb")] // Star: 1330
        [TestCase(@"https://github.com/picocms/Pico.git",
                @"184b18383f1595ace4d6c43ee25c59693610d635")] // Star: 1289
        [TestCase(@"https://github.com/d11wtq/boris.git",
                @"177f9b9f39e1ac4c668ab573844c530800fbbe5e")] // Star: 1302
        [TestCase(@"https://github.com/Respect/Validation.git",
                @"979c06997b6027a4780712e29999dffd53f7878f")] // Star: 1270
        [TestCase(@"https://github.com/usmanhalalit/charisma.git",
                @"5a8e4fdbefe694bf6a3a9c86e41acf9abf5c06cb")] // Star: 1288
        [TestCase(@"https://github.com/michelf/php-markdown.git",
                @"6f952ee180e9bd345f3dd6005aa11e0f5dcbd1b8")] // Star: 1347
        [TestCase(@"https://github.com/omnipay/omnipay.git",
                @"aa1de2346b365527486b16f0f07ff190effe6d3e")] // Star: 1204
        [TestCase(@"https://github.com/umpirsky/country-list.git",
                @"19c2fb49a7eda5347170f8f8d723f92701468f60")] // Star: 1306
        [TestCase(@"https://github.com/benedmunds/CodeIgniter-Ion-Auth.git",
                @"e083881869045eeee9f96f957a65872b9977450f")] // Star: 1184
        [TestCase(@"https://github.com/rmccue/Requests.git",
                @"81a917f6425a2194c89d74b12102614c3ed16b2e")] // Star: 1190
        [TestCase(@"https://github.com/joomla/joomla-cms.git",
                @"b3f84c58382f7024e02ff991a1d961571c2d5546")] // Star: 1165
        [TestCase(@"https://github.com/j4mie/idiorm.git",
                @"11e964157a6a2c6128a0546673ad5e99ac1a62cd")] // Star: 1200
        [TestCase(@"https://github.com/phpDocumentor/phpDocumentor2.git",
                @"9f58c140bd9b7bf2662485d035d84c2270fae864")] // Star: 1141
        [TestCase(@"https://github.com/TechEmpower/FrameworkBenchmarks.git",
                @"4eeb8039e62caa8516e092e7e49663cefbcebbc5")] // Star: 1131
        [TestCase(@"https://github.com/ci-bonfire/Bonfire.git",
                @"cdd0daf0ad10c7fd2fe83400833ea1badd9e6b6b")] // Star: 1123
        [TestCase(@"https://github.com/JosephLenton/PHP-Error.git",
                @"9918dd5eeec527846d43c92a4c9880bfcdd0de14")] // Star: 1150
        [TestCase(@"https://github.com/nikic/PHP-Parser.git",
                @"c341ab2ecfa117b265c452666f11471e152c9416")] // Star: 1120
        [TestCase(@"https://github.com/hybridauth/hybridauth.git",
                @"e831fb60307fc0c355d1403cb4d2f58ca919d746")] // Star: 1117
        [TestCase(@"https://github.com/bcosca/fatfree.git",
                @"7c221c6dde27fd812af88d4bb614867911084e99")] // Star: 1105
        [TestCase(@"https://github.com/photo/frontend.git",
                @"efde9393d144daa2d1133ce236be0289904addd6")] // Star: 1108
        [TestCase(@"https://github.com/padraic/mockery.git",
                @"4eff32b268a0db52b9abe36725cb775658ad3f1f")] // Star: 1114
        [TestCase(@"https://github.com/dompdf/dompdf.git",
                @"4c5b3c977579f45ec5cd815a32dea835e2416d6d")] // Star: 1109
        [TestCase(@"https://github.com/opencart/opencart.git",
                @"93076dc43c53b9c593f425ec2de6221c91d1f2c9")] // Star: 1097
        [TestCase(@"https://github.com/zendframework/ZendSkeletonApplication.git",
                @"67cbbbf61897831ef1feda323be9845aa7d79682")] // Star: 1110
        [TestCase(@"https://github.com/gabordemooij/redbean.git",
                @"4a59b3926c3e1fa636146cd91cf397e66e48d20e")] // Star: 1080
        [TestCase(@"https://github.com/facebook/xhprof.git",
                @"e83d1792569ecbc5ef14c50a00eb37094d4e6ad9")] // Star: 1036
        [TestCase(@"https://github.com/bolt/bolt.git",
                @"ee68b23ed9a18a2fd3f05fbe8c013ac3b5078eaf")] // Star: 1029
        [TestCase(@"https://github.com/briannesbitt/Carbon.git",
                @"21c4cb4301969c7d85aee8a62eefdfa881413af0")] // Star: 1334
        [TestCase(@"https://github.com/pattern-lab/patternlab-php.git",
                @"ff31431333113c553d2f299a49b783351229d026")] // Star: 1077
        [TestCase(@"https://github.com/thephpleague/flysystem.git",
                @"387e012fa93878e3865ed8db1aa9daba8bf2f9c5")] // Star: 1055
        [TestCase(@"https://github.com/Sylius/Sylius.git",
                @"6476bdef07eaa7bb8c2d092bbdb093c1a840044d")] // Star: 1023
        [TestCase(@"https://github.com/roundcube/roundcubemail.git",
                @"a5f8c8307a9e4059dad2833712b9a612631a36ed")] // Star: 1022
        [TestCase(@"https://github.com/KnpLabs/Gaufrette.git",
                @"c2b6af8eb6fc093409ee0753137817dce1673763")] // Star: 1027
        [TestCase(@"https://github.com/chrisboulton/php-resque.git",
                @"610c4dcdbf3e7e5856f694384f3160db94850d1f")] // Star: 1048
        [TestCase(@"https://github.com/chriso/klein.php.git",
                @"376fd62813eb2008f3644e206d03002a3250122a")] // Star: 1119
        [TestCase(@"https://github.com/symfony/symfony-standard.git",
                @"50aeda221a0328dccae905b8dafed67f97983bcf")] // Star: 1006
        [TestCase(@"https://github.com/Atlantic18/DoctrineExtensions.git",
                @"f2cd33516faa4a773d576ad58d02e283467acdd0")] // Star: 1003
        [TestCase(@"https://github.com/aws/aws-sdk-php.git",
                @"2a4355cac155aa3631cf9649f32a2584a3bb211a")] // Star: 1000
        [TestCase(@"https://github.com/welaika/wordless.git",
                @"e9f815592b7c3138c2c4a3f1de365c8abfd1d385")] // Star: 994
        [TestCase(@"https://github.com/opauth/opauth.git",
                @"3ff68e72c21a3691e5a87fc8c30e458edbb22990")] // Star: 987
        [TestCase(@"https://github.com/simplethemes/skeleton_wp.git",
                @"55495c735bcb35f2e7752c6e62e29054bfc69892")] // Star: 968
        [TestCase(@"https://github.com/Behat/Behat.git",
                @"05d75c23de7d594afd7542cd459ae2206f833552")] // Star: 965
        [TestCase(@"https://github.com/sonata-project/SonataAdminBundle.git",
                @"020e4ff2ba694e15f8970a9878bd507e15044a06")] // Star: 947
        [TestCase(@"https://github.com/roots/bedrock.git",
                @"623c5dfb0f9af60c7f0f3adcfc28a9cc81e5fd29")] // Star: 942
        [TestCase(@"https://github.com/Circa75/dropplets.git",
                @"feb2e82b21ef7a7da484e17628160f866c2da6c0")] // Star: 997
        [TestCase(@"https://github.com/panique/php-login.git",
                @"350ffc9455617b24979535283258ea8a05b7cf33")] // Star: 994
        [TestCase(@"https://github.com/cartalyst/sentry.git",
                @"fcf802d6ef42cb6db08df731c55bb3a687f3ec0e")] // Star: 949
        [TestCase(@"https://github.com/somerandomdude/Frank.git",
                @"bc8e6de6d672da1c78e8267d59f62b710a623a7c")] // Star: 965
        [TestCase(@"https://github.com/jquery/testswarm.git",
                @"bd1877cd4e67fd9c40315b88c2c1d117c9cfbc5c")] // Star: 920
        [TestCase(@"https://github.com/swiftmailer/swiftmailer.git",
                @"d5d580ca7ced89955ce7200f41fb0f97b8f74c60")] // Star: 898
        [TestCase(@"https://github.com/YOURLS/YOURLS.git",
                @"c55212cd14a0d34c1e3030aa3ffe59d592b77dc2")] // Star: 897
        [TestCase(@"https://github.com/jpfuentes2/php-activerecord.git",
                @"6ca994b9f8cf984cff14033ad96264d17916af56")] // Star: 908
        [TestCase(@"https://github.com/UnionOfRAD/lithium.git",
                @"791c2ce345b63cd47f067cdebccb6497a35de014")] // Star: 887
        [TestCase(@"https://github.com/vanillaforums/Garden.git",
                @"a72014abebf891b647e7399d27ddaa03eba1095e")] // Star: 879
        [TestCase(@"https://github.com/kolber/stacey.git",
                @"3fe746e2522eb08e98976c1ca946fd2d3e496baa")] // Star: 922
        [TestCase(@"https://github.com/moodle/moodle.git",
                @"069fe267b611d0025d232bf66706a44ffccc737c")] // Star: 878
        [TestCase(@"https://github.com/SSilence/selfoss.git",
                @"32f11b973fd5632438d291568359b28949963e4c")] // Star: 873
        [TestCase(@"https://github.com/kriswallsmith/Buzz.git",
                @"a0f207ac4939978b604be9bec5d5b19baecd8165")] // Star: 862
        [TestCase(@"https://github.com/Anahkiasen/rocketeer.git",
                @"02e2eace2765d88754731d1c672bb14b0d2cf6ca")] // Star: 868
        [TestCase(@"https://github.com/ircmaxell/password_compat.git",
                @"c91b1168bc53c26f56fc65f16958b5be45ca5dc9")] // Star: 898
        [TestCase(@"https://github.com/kakserpom/phpdaemon.git",
                @"3bf6abc148c4764d7e2bdb2a80d9bcfbb00ca995")] // Star: 851
        [TestCase(@"https://github.com/markjaquith/WordPress-Skeleton.git",
                @"1be2fe16e43ec4aeaab07d92597a01519ecbd30d")] // Star: 930
        [TestCase(@"https://github.com/mongodb/mongo-php-driver.git",
                @"87c2cfefbcbfb91d96552d704631af2177222c42")] // Star: 841
        [TestCase(@"https://github.com/splitbrain/dokuwiki.git",
                @"36d893219337b45ab7952d10534ff4c212c59ca8")] // Star: 835
        [TestCase(@"https://github.com/interconnectit/Search-Replace-DB.git",
                @"12c6732502958a0c57125f6b30741e6e0f05655c")] // Star: 852
        [TestCase(@"https://github.com/murtaugh/HTML5-Reset-WordPress-Theme.git",
                @"374166a449a39da3eb70e1079fec9be76d9144d7")] // Star: 874
        [TestCase(@"https://github.com/marcoarment/secondcrack.git",
                @"664b40ae9934359703e15934fd6b4b14c6098601")] // Star: 830
        [TestCase(@"https://github.com/phpmyadmin/phpmyadmin.git",
                @"b77cc7f1ce38099290e7fddf8badcf85f2a56f69")] // Star: 813
        [TestCase(@"https://github.com/markjaquith/WP-Stack.git",
                @"1a5714be857ffcd494ea56d9ff3619500815839e")] // Star: 829
        [TestCase(@"https://github.com/KnpLabs/snappy.git",
                @"9d7bd2e806e68acf6216c8b7eca7ddd774d0aebf")] // Star: 812
        [TestCase(@"https://github.com/FriendsOfSymfony/FOSRestBundle.git",
                @"292891740390ec5bdddc95340dec3a2b3c687e0d")] // Star: 805
        [TestCase(@"https://github.com/drewsymo/Foundation.git",
                @"2ef5908f6bfaa7b3c1f944a7f89a457f8a792403")] // Star: 799
        [TestCase(@"https://github.com/nette/nette.git",
                @"9ff44c392a248d1bdd17dcd94f7e441a73e601d6")] // Star: 799
        [TestCase(@"https://github.com/Codeception/Codeception.git",
                @"a02f50ee09f067c2c0c08d4cadb3946ad8dc2d9d")] // Star: 793
        [TestCase(@"https://github.com/themattharris/tmhOAuth.git",
                @"47dcee2ac74f8c032d2a1afb836e65108bf582b7")] // Star: 785
        [TestCase(@"https://github.com/simplepie/simplepie.git",
                @"5f00e77b5feb96605cbcea4dcfb555e87c2fed24")] // Star: 789
        [TestCase(@"https://github.com/mikelbring/tinyissue.git",
                @"3d514bbd017832e3896d5503ad113b081a029a00")] // Star: 790
        [TestCase(@"https://github.com/c9s/phpbrew.git",
                @"496c0400fd247ce2fd01d4f5ce705b9ceb5222bb")] // Star: 774
        [TestCase(@"https://github.com/amazonwebservices/aws-sdk-for-php.git",
                @"aab09f6dac35e5e9a263fb7311bb4e71de95b0ba")] // Star: 750
        [TestCase(@"https://github.com/forkcms/forkcms.git",
                @"4f3ccdabf6e76a6ebbd8a85306588a47933da854")] // Star: 751
        [TestCase(@"https://github.com/bastianallgeier/kirbycms.git",
                @"2281b002fa4b8aa2c943a063bc8e47b9bb4df630")] // Star: 769
        [TestCase(@"https://github.com/propelorm/Propel.git",
                @"e914de6d6372f4e09c82a19a59dd11ca9d16d503")] // Star: 746
        [TestCase(@"https://github.com/anandkunal/ToroPHP.git",
                @"09a1e01c6baf27d9fd70759f7739699fdf85218b")] // Star: 784
        [TestCase(@"https://github.com/Block8/PHPCI.git",
                @"102354190773f1b36bd7c0c762efd8ec7938f888")] // Star: 740
        [TestCase(@"https://github.com/Codiad/Codiad.git",
                @"0faabeb14aabb1737a4671e9b71c0447ed20fc5b")] // Star: 744
        [TestCase(@"https://github.com/fabpot/Pimple.git",
                @"a9e94d9fd6cb9e8f097551a25ffec73ff2480a24")] // Star: 770
        [TestCase(@"https://github.com/cakephp/debug_kit.git",
                @"bbfb1d1993b195b14b2bf7b4c3f37e732ad76195")] // Star: 738
        [TestCase(@"https://github.com/masterexploder/PHPThumb.git",
                @"69fe4dbef9c70915ee16652339395deadb1509cb")] // Star: 762
        [TestCase(@"https://github.com/esotalk/esoTalk.git",
                @"22c2d7b31aabafc6be325ab6116d4da7a0279d40")] // Star: 733
        [TestCase(@"https://github.com/lucb1e/cookielesscookies.git",
                @"a23a2c8163d91063f08ca38e530b284839933d06")] // Star: 729
        [TestCase(@"https://github.com/fuel/core.git",
                @"2fdd79e0d902d78c081e472b086f551336b4663e")] // Star: 716
        [TestCase(@"https://github.com/Herzult/SimplePHPEasyPlus.git",
                @"e9b2d592a16a0bb72ac1f2d6483f2993427a4475")] // Star: 743
        [TestCase(@"https://github.com/ccampbell/chromephp.git",
                @"c3c297615d48ae5b2a86a82311152d1ed095fcef")] // Star: 730
        [TestCase(@"https://github.com/maximebf/php-debugbar.git",
                @"f6da2ec2239a764032c197ebfe85c23faf694748")] // Star: 710
        [TestCase(@"https://github.com/raveren/kint.git",
                @"590e3fcc3fd4234a8d5e844ce783c82464401d7f")] // Star: 709
        [TestCase(@"https://github.com/facebook/xhp.git",
                @"1e1825cfdcd10e42c563b48e8f25818ee831ed9d")] // Star: 705
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "php_repo.txt", "*.php");
        }
    }
}