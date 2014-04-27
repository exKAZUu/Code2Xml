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
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.Php;
using Code2Xml.Objects.Tests.Learning.Experiments;
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
        [TestCase(@"<?php $i = 0 + 1 - 2 * 3 / 4;")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Seed.php")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("Php", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/laravel/laravel.git",
                @"af7092275956a839e79f49158312241d3ea3b7f9", 9323)]
        [TestCase(@"https://github.com/symfony/symfony.git",
                @"c875acf3a264f852e4bb2ddc5987bb5426d41cda", 8237)]
        [TestCase(@"https://github.com/EllisLab/CodeIgniter.git",
                @"aeed15eb8556ab671507f17ef9a8cf28903999aa", 7477)]
        [TestCase(@"https://github.com/cakephp/cakephp.git",
                @"e9c9e9697d275e0e15277d21e23edbf975443425", 4670)]
        [TestCase(@"https://github.com/zendframework/zf2.git",
                @"0ce25cc36d430095dbc89f4de19dc319b4f90ee4", 4660)]
        [TestCase(@"https://github.com/php-fig/fig-standards.git",
                @"2e276153b8f084d5d552ae3cf86876bb06b20385", 4068)]
        [TestCase(@"https://github.com/WordPress/WordPress.git",
                @"77e2da21cf2925e1b809888969677184c3d34fec", 3790)]
        [TestCase(@"https://github.com/domnikl/DesignPatternsPHP.git",
                @"ed291cd959053366e9d9edba62d8633034f93b0b", 3757)]
        [TestCase(@"https://github.com/composer/composer.git",
                @"14f35e812cd41746c4a4a7a2dec2b2365c8cdc61", 3690)]
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
        [TestCase(@"https://github.com/kriswallsmith/assetic.git",
                @"f2a5214034928d4c6849bc94cfd462ea832a50a8", 2435)]
        [TestCase(@"https://github.com/abraham/twitteroauth.git",
                @"4b775766fe3526ebc67ee20c97ff29a3b47bc5d8", 2304)]
        [TestCase(@"https://github.com/subtlepatterns/SubtlePatterns.git",
                @"6e056565a1254c967228aab60c9d9c7d0e63a7e3", 2271)]
        [TestCase(@"https://github.com/PHPOffice/PHPExcel.git",
                @"c2a277c447ca965bbe030cd83d6b92df95661541", 2240)]
        [TestCase(@"https://github.com/yiisoft/yii2.git",
                @"c501ae4f4d35343115733f9a6a09259050a78d8f", 2237)]
        [TestCase(@"https://github.com/reactphp/react.git",
                @"7b996f82dc8b4b974fb719ab26f54fce028960a8", 2192)]
        [TestCase(@"https://github.com/fabpot/Twig.git",
                @"c8366374d9d531029a6b031528b552c37e1b2e66", 2188)]
        [TestCase(@"https://github.com/doctrine/doctrine2.git",
                @"3a1e24e6801961128c27104919050d40d745030b", 2104)]
        [TestCase(@"https://github.com/silexphp/Silex.git",
                @"3cbf93cfb0eb41b216be453ff40a4fa17f1bdbcd", 2093)]
        [TestCase(@"https://github.com/owncloud/core.git",
                @"340089f270a778aeb296b1744821dcdb5878131e", 2077)]
        [TestCase(@"https://github.com/piwik/piwik.git",
                @"e3efda0492c51cfb786f67419ea3a94c76f15e25", 2066)]
        [TestCase(@"https://github.com/Seldaek/monolog.git",
                @"03000a7fcd4072bd7e1f99c8ce4328621c5773b9", 2054)]
        [TestCase(@"https://github.com/leafo/lessphp.git",
                @"b7cd5c79e82666bcd2dfadb304342311209fb527", 1929)]
        [TestCase(@"https://github.com/avalanche123/Imagine.git",
                @"f93b6895f4567136528448263cc1fe71ee8504ce", 1916)]
        [TestCase(@"https://github.com/anchorcms/anchor-cms.git",
                @"d0e113ade61f60cf2672037a687100eac5746330", 1859)]
        [TestCase(@"https://github.com/laravel/framework.git",
                @"627fc22cb2fdd343cb17b552955eb317860f023d", 1851)]
        [TestCase(@"https://github.com/puphpet/puphpet.git",
                @"e4012cbbe0fc3b200b4750bb79673a9f468c1b9e", 1803)]
        [TestCase(@"https://github.com/pyrocms/pyrocms.git",
                @"26b64c5dcab1bcb0590647f2576daa81f77ae86e", 1771)]
        [TestCase(@"https://github.com/JeffreyWay/Laravel-4-Generators.git",
                @"cf766fae573d35621c2f2a14f0710c5484edf3f0", 1703)]
        [TestCase(@"https://github.com/philsturgeon/codeigniter-restserver.git",
                @"2aa6fec9a05a04d530c58ce77716bba2ba4f46ca", 1684)]
        [TestCase(@"https://github.com/bobthecow/mustache.php.git",
                @"43dc9457a2089cf86c0f7fdb79fcdc516293a4b6", 1671)]
        [TestCase(@"https://github.com/venomous0x/WhatsAPI.git",
                @"5ad50b311d728752cee50b7c7ed00062df6cb740", 1613)]
        [TestCase(@"https://github.com/PHPMailer/PHPMailer.git",
                @"7b384d0bedf7feb1d3cdfaae689d8c5b68eb0515", 1600)]
        [TestCase(@"https://github.com/fabpot/Goutte.git",
                @"06a5451288ffddd204b10fa6c6f9ab2b86dd515d", 1584)]
        [TestCase(@"https://github.com/tommcfarlin/WordPress-Plugin-Boilerplate.git",
                @"db289e22840277c26911d46972fe516ce309e430", 1543)]
        [TestCase(@"https://github.com/cboden/Ratchet.git",
                @"67cedf0ce6b6c7fbb5e305e0667ac219e655d561", 1473)]
        [TestCase(@"https://github.com/ccoenraets/backbone-directory.git",
                @"c5654ab50002a7865da849fbc743e7cea750a54e", 1468)]
        [TestCase(@"https://github.com/gothfox/Tiny-Tiny-RSS.git",
                @"cda0418af19f55669f16c14c838ee44bf6fd8c99", 1462)]
        [TestCase(@"https://github.com/MattWilcox/Adaptive-Images.git",
                @"faa87fd94fc59373df7c2e5bb605c7e3c28e38a4", 1454)]
        [TestCase(@"https://github.com/drupal/drupal.git",
                @"95614ce35deb112da18f1f8841632b718be816c7", 1439)]
        [TestCase(@"https://github.com/simplebits/Pears.git",
                @"bd6211cdd2bf08682716e0a0b080ebee5b90da0b", 1436)]
        [TestCase(@"https://github.com/magento/magento2.git",
                @"8611ea725e25c67683f3f7e533406291ae8a723b", 1431)]
        [TestCase(@"https://github.com/geocoder-php/Geocoder.git",
                @"972eed79fb50b6752b5154d391201f2ec7a8e11a", 1381)]
        [TestCase(@"https://github.com/filp/whoops.git",
                @"230da4810fc7fff67bf92061dc64eff4d451b68d", 1375)]
        [TestCase(@"https://github.com/kohana/kohana.git",
                @"338bea96dfa197e7864674dab6cef78958e1f1df", 1365)]
        [TestCase(@"https://github.com/woothemes/woocommerce.git",
                @"4afeb7926c912c2f5a9ac5fca6739274c9503014", 1365)]
        [TestCase(@"https://github.com/WebDevStudios/Custom-Metaboxes-and-Fields-for-WordPress.git",
                @"c9402b287b6ffcfbc0eeab4109ece8f1a5d25848", 1361)]
        [TestCase(@"https://github.com/michelf/php-markdown.git",
                @"6f952ee180e9bd345f3dd6005aa11e0f5dcbd1b8", 1347)]
        [TestCase(@"https://github.com/briannesbitt/Carbon.git",
                @"21c4cb4301969c7d85aee8a62eefdfa881413af0", 1334)]
        [TestCase(@"https://github.com/themeskult/wp-svbtle.git",
                @"45736be0e55e688a1111afe7d0f53d2ede79cfdb", 1330)]
        [TestCase(@"https://github.com/fabpot/PHP-CS-Fixer.git",
                @"5b601200086382cdb2c3c4b68b28487aabc287d2", 1320)]
        [TestCase(@"https://github.com/fuel/fuel.git",
                @"82f79d7d9be671fafcfd9ca405425501bf8d8634", 1313)]
        [TestCase(@"https://github.com/wp-cli/wp-cli.git",
                @"fd5a95f208bb0fa9422a03cf40091e1a7704e481", 1309)]
        [TestCase(@"https://github.com/umpirsky/country-list.git",
                @"19c2fb49a7eda5347170f8f8d723f92701468f60", 1306)]
        [TestCase(@"https://github.com/nrk/predis.git",
                @"83df2ef11c18ea490daf6a7a8789315f57f555a8", 1302)]
        [TestCase(@"https://github.com/d11wtq/boris.git",
                @"177f9b9f39e1ac4c668ab573844c530800fbbe5e", 1302)]
        [TestCase(@"https://github.com/picocms/Pico.git",
                @"184b18383f1595ace4d6c43ee25c59693610d635", 1289)]
        [TestCase(@"https://github.com/usmanhalalit/charisma.git",
                @"5a8e4fdbefe694bf6a3a9c86e41acf9abf5c06cb", 1288)]
        [TestCase(@"https://github.com/mrclay/minify.git",
                @"fb3931f8cd54a637b2a42170c3a9a1c4da9e69a9", 1287)]
        [TestCase(@"https://github.com/Respect/Validation.git",
                @"979c06997b6027a4780712e29999dffd53f7878f", 1270)]
        [TestCase(@"https://github.com/omnipay/omnipay.git",
                @"aa1de2346b365527486b16f0f07ff190effe6d3e", 1204)]
        [TestCase(@"https://github.com/j4mie/idiorm.git",
                @"11e964157a6a2c6128a0546673ad5e99ac1a62cd", 1200)]
        [TestCase(@"https://github.com/rmccue/Requests.git",
                @"81a917f6425a2194c89d74b12102614c3ed16b2e", 1190)]
        [TestCase(@"https://github.com/benedmunds/CodeIgniter-Ion-Auth.git",
                @"e083881869045eeee9f96f957a65872b9977450f", 1184)]
        [TestCase(@"https://github.com/joomla/joomla-cms.git",
                @"b3f84c58382f7024e02ff991a1d961571c2d5546", 1165)]
        [TestCase(@"https://github.com/JosephLenton/PHP-Error.git",
                @"9918dd5eeec527846d43c92a4c9880bfcdd0de14", 1150)]
        [TestCase(@"https://github.com/phpDocumentor/phpDocumentor2.git",
                @"9f58c140bd9b7bf2662485d035d84c2270fae864", 1141)]
        [TestCase(@"https://github.com/TechEmpower/FrameworkBenchmarks.git",
                @"4eeb8039e62caa8516e092e7e49663cefbcebbc5", 1131)]
        [TestCase(@"https://github.com/ci-bonfire/Bonfire.git",
                @"cdd0daf0ad10c7fd2fe83400833ea1badd9e6b6b", 1123)]
        [TestCase(@"https://github.com/nikic/PHP-Parser.git",
                @"c341ab2ecfa117b265c452666f11471e152c9416", 1120)]
        [TestCase(@"https://github.com/chriso/klein.php.git",
                @"376fd62813eb2008f3644e206d03002a3250122a", 1119)]
        [TestCase(@"https://github.com/hybridauth/hybridauth.git",
                @"e831fb60307fc0c355d1403cb4d2f58ca919d746", 1117)]
        [TestCase(@"https://github.com/padraic/mockery.git",
                @"4eff32b268a0db52b9abe36725cb775658ad3f1f", 1114)]
        [TestCase(@"https://github.com/zendframework/ZendSkeletonApplication.git",
                @"67cbbbf61897831ef1feda323be9845aa7d79682", 1110)]
        [TestCase(@"https://github.com/dompdf/dompdf.git",
                @"4c5b3c977579f45ec5cd815a32dea835e2416d6d", 1109)]
        [TestCase(@"https://github.com/photo/frontend.git",
                @"efde9393d144daa2d1133ce236be0289904addd6", 1108)]
        [TestCase(@"https://github.com/bcosca/fatfree.git",
                @"7c221c6dde27fd812af88d4bb614867911084e99", 1105)]
        [TestCase(@"https://github.com/opencart/opencart.git",
                @"93076dc43c53b9c593f425ec2de6221c91d1f2c9", 1097)]
        [TestCase(@"https://github.com/gabordemooij/redbean.git",
                @"4a59b3926c3e1fa636146cd91cf397e66e48d20e", 1080)]
        [TestCase(@"https://github.com/pattern-lab/patternlab-php.git",
                @"ff31431333113c553d2f299a49b783351229d026", 1077)]
        [TestCase(@"https://github.com/thephpleague/flysystem.git",
                @"387e012fa93878e3865ed8db1aa9daba8bf2f9c5", 1055)]
        [TestCase(@"https://github.com/chrisboulton/php-resque.git",
                @"610c4dcdbf3e7e5856f694384f3160db94850d1f", 1048)]
        [TestCase(@"https://github.com/facebook/xhprof.git",
                @"e83d1792569ecbc5ef14c50a00eb37094d4e6ad9", 1036)]
        [TestCase(@"https://github.com/bolt/bolt.git",
                @"ee68b23ed9a18a2fd3f05fbe8c013ac3b5078eaf", 1029)]
        [TestCase(@"https://github.com/KnpLabs/Gaufrette.git",
                @"c2b6af8eb6fc093409ee0753137817dce1673763", 1027)]
        [TestCase(@"https://github.com/Sylius/Sylius.git",
                @"6476bdef07eaa7bb8c2d092bbdb093c1a840044d", 1023)]
        [TestCase(@"https://github.com/roundcube/roundcubemail.git",
                @"a5f8c8307a9e4059dad2833712b9a612631a36ed", 1022)]
        [TestCase(@"https://github.com/symfony/symfony-standard.git",
                @"50aeda221a0328dccae905b8dafed67f97983bcf", 1006)]
        [TestCase(@"https://github.com/Atlantic18/DoctrineExtensions.git",
                @"f2cd33516faa4a773d576ad58d02e283467acdd0", 1003)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            var exp = new PhpComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "php_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.php");
        }
    }
}