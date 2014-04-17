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
        [TestCase(@"https://github.com/aws/aws-sdk-php.git",
                @"2a4355cac155aa3631cf9649f32a2584a3bb211a", 1000)]
        [TestCase(@"https://github.com/Circa75/dropplets.git",
                @"feb2e82b21ef7a7da484e17628160f866c2da6c0", 997)]
        [TestCase(@"https://github.com/welaika/wordless.git",
                @"e9f815592b7c3138c2c4a3f1de365c8abfd1d385", 994)]
        [TestCase(@"https://github.com/panique/php-login.git",
                @"350ffc9455617b24979535283258ea8a05b7cf33", 994)]
        [TestCase(@"https://github.com/opauth/opauth.git",
                @"3ff68e72c21a3691e5a87fc8c30e458edbb22990", 987)]
        [TestCase(@"https://github.com/simplethemes/skeleton_wp.git",
                @"55495c735bcb35f2e7752c6e62e29054bfc69892", 968)]
        [TestCase(@"https://github.com/Behat/Behat.git",
                @"05d75c23de7d594afd7542cd459ae2206f833552", 965)]
        [TestCase(@"https://github.com/somerandomdude/Frank.git",
                @"bc8e6de6d672da1c78e8267d59f62b710a623a7c", 965)]
        [TestCase(@"https://github.com/cartalyst/sentry.git",
                @"fcf802d6ef42cb6db08df731c55bb3a687f3ec0e", 949)]
        [TestCase(@"https://github.com/sonata-project/SonataAdminBundle.git",
                @"020e4ff2ba694e15f8970a9878bd507e15044a06", 947)]
        [TestCase(@"https://github.com/roots/bedrock.git",
                @"623c5dfb0f9af60c7f0f3adcfc28a9cc81e5fd29", 942)]
        [TestCase(@"https://github.com/markjaquith/WordPress-Skeleton.git",
                @"1be2fe16e43ec4aeaab07d92597a01519ecbd30d", 930)]
        [TestCase(@"https://github.com/kolber/stacey.git",
                @"3fe746e2522eb08e98976c1ca946fd2d3e496baa", 922)]
        [TestCase(@"https://github.com/jquery/testswarm.git",
                @"bd1877cd4e67fd9c40315b88c2c1d117c9cfbc5c", 920)]
        [TestCase(@"https://github.com/jpfuentes2/php-activerecord.git",
                @"6ca994b9f8cf984cff14033ad96264d17916af56", 908)]
        [TestCase(@"https://github.com/swiftmailer/swiftmailer.git",
                @"d5d580ca7ced89955ce7200f41fb0f97b8f74c60", 898)]
        [TestCase(@"https://github.com/ircmaxell/password_compat.git",
                @"c91b1168bc53c26f56fc65f16958b5be45ca5dc9", 898)]
        [TestCase(@"https://github.com/YOURLS/YOURLS.git",
                @"c55212cd14a0d34c1e3030aa3ffe59d592b77dc2", 897)]
        [TestCase(@"https://github.com/UnionOfRAD/lithium.git",
                @"791c2ce345b63cd47f067cdebccb6497a35de014", 887)]
        [TestCase(@"https://github.com/vanillaforums/Garden.git",
                @"a72014abebf891b647e7399d27ddaa03eba1095e", 879)]
        [TestCase(@"https://github.com/moodle/moodle.git",
                @"069fe267b611d0025d232bf66706a44ffccc737c", 878)]
        [TestCase(@"https://github.com/murtaugh/HTML5-Reset-WordPress-Theme.git",
                @"374166a449a39da3eb70e1079fec9be76d9144d7", 874)]
        [TestCase(@"https://github.com/SSilence/selfoss.git",
                @"32f11b973fd5632438d291568359b28949963e4c", 873)]
        [TestCase(@"https://github.com/Anahkiasen/rocketeer.git",
                @"02e2eace2765d88754731d1c672bb14b0d2cf6ca", 868)]
        [TestCase(@"https://github.com/kriswallsmith/Buzz.git",
                @"a0f207ac4939978b604be9bec5d5b19baecd8165", 862)]
        [TestCase(@"https://github.com/interconnectit/Search-Replace-DB.git",
                @"12c6732502958a0c57125f6b30741e6e0f05655c", 852)]
        [TestCase(@"https://github.com/kakserpom/phpdaemon.git",
                @"3bf6abc148c4764d7e2bdb2a80d9bcfbb00ca995", 851)]
        [TestCase(@"https://github.com/mongodb/mongo-php-driver.git",
                @"87c2cfefbcbfb91d96552d704631af2177222c42", 841)]
        [TestCase(@"https://github.com/splitbrain/dokuwiki.git",
                @"36d893219337b45ab7952d10534ff4c212c59ca8", 835)]
        [TestCase(@"https://github.com/marcoarment/secondcrack.git",
                @"664b40ae9934359703e15934fd6b4b14c6098601", 830)]
        [TestCase(@"https://github.com/markjaquith/WP-Stack.git",
                @"1a5714be857ffcd494ea56d9ff3619500815839e", 829)]
        [TestCase(@"https://github.com/phpmyadmin/phpmyadmin.git",
                @"b77cc7f1ce38099290e7fddf8badcf85f2a56f69", 813)]
        [TestCase(@"https://github.com/KnpLabs/snappy.git",
                @"9d7bd2e806e68acf6216c8b7eca7ddd774d0aebf", 812)]
        [TestCase(@"https://github.com/FriendsOfSymfony/FOSRestBundle.git",
                @"292891740390ec5bdddc95340dec3a2b3c687e0d", 805)]
        [TestCase(@"https://github.com/drewsymo/Foundation.git",
                @"2ef5908f6bfaa7b3c1f944a7f89a457f8a792403", 799)]
        [TestCase(@"https://github.com/nette/nette.git",
                @"9ff44c392a248d1bdd17dcd94f7e441a73e601d6", 799)]
        [TestCase(@"https://github.com/Codeception/Codeception.git",
                @"a02f50ee09f067c2c0c08d4cadb3946ad8dc2d9d", 793)]
        [TestCase(@"https://github.com/mikelbring/tinyissue.git",
                @"3d514bbd017832e3896d5503ad113b081a029a00", 790)]
        [TestCase(@"https://github.com/simplepie/simplepie.git",
                @"5f00e77b5feb96605cbcea4dcfb555e87c2fed24", 789)]
        [TestCase(@"https://github.com/themattharris/tmhOAuth.git",
                @"47dcee2ac74f8c032d2a1afb836e65108bf582b7", 785)]
        [TestCase(@"https://github.com/anandkunal/ToroPHP.git",
                @"09a1e01c6baf27d9fd70759f7739699fdf85218b", 784)]
        [TestCase(@"https://github.com/c9s/phpbrew.git",
                @"496c0400fd247ce2fd01d4f5ce705b9ceb5222bb", 774)]
        [TestCase(@"https://github.com/fabpot/Pimple.git",
                @"a9e94d9fd6cb9e8f097551a25ffec73ff2480a24", 770)]
        [TestCase(@"https://github.com/bastianallgeier/kirbycms.git",
                @"2281b002fa4b8aa2c943a063bc8e47b9bb4df630", 769)]
        [TestCase(@"https://github.com/masterexploder/PHPThumb.git",
                @"69fe4dbef9c70915ee16652339395deadb1509cb", 762)]
        [TestCase(@"https://github.com/forkcms/forkcms.git",
                @"4f3ccdabf6e76a6ebbd8a85306588a47933da854", 751)]
        [TestCase(@"https://github.com/amazonwebservices/aws-sdk-for-php.git",
                @"aab09f6dac35e5e9a263fb7311bb4e71de95b0ba", 750)]
        [TestCase(@"https://github.com/propelorm/Propel.git",
                @"e914de6d6372f4e09c82a19a59dd11ca9d16d503", 746)]
        [TestCase(@"https://github.com/Codiad/Codiad.git",
                @"0faabeb14aabb1737a4671e9b71c0447ed20fc5b", 744)]
        [TestCase(@"https://github.com/Herzult/SimplePHPEasyPlus.git",
                @"e9b2d592a16a0bb72ac1f2d6483f2993427a4475", 743)]
        [TestCase(@"https://github.com/Block8/PHPCI.git",
                @"102354190773f1b36bd7c0c762efd8ec7938f888", 740)]
        [TestCase(@"https://github.com/cakephp/debug_kit.git",
                @"bbfb1d1993b195b14b2bf7b4c3f37e732ad76195", 738)]
        [TestCase(@"https://github.com/VerbalExpressions/PHPVerbalExpressions.git",
                @"f9d4e0b38605704b0e8e343375adca656b28c222", 737)]
        [TestCase(@"https://github.com/esotalk/esoTalk.git",
                @"22c2d7b31aabafc6be325ab6116d4da7a0279d40", 733)]
        [TestCase(@"https://github.com/ccampbell/chromephp.git",
                @"c3c297615d48ae5b2a86a82311152d1ed095fcef", 730)]
        [TestCase(@"https://github.com/barryvdh/laravel-ide-helper.git",
                @"16f77638f159c75a93da97dd48904707618483a3", 730)]
        [TestCase(@"https://github.com/lucb1e/cookielesscookies.git",
                @"a23a2c8163d91063f08ca38e530b284839933d06", 729)]
        [TestCase(@"https://github.com/fuel/core.git",
                @"2fdd79e0d902d78c081e472b086f551336b4663e", 716)]
        [TestCase(@"https://github.com/thephpleague/oauth2-server.git",
                @"ba5f2840fb46e8b23ae437890bfaffe74392be8e", 715)]
        [TestCase(@"https://github.com/erusev/parsedown.git",
                @"c10bde01746867e2afbc715a6149f4e682f0263b", 714)]
        [TestCase(@"https://github.com/maximebf/php-debugbar.git",
                @"f6da2ec2239a764032c197ebfe85c23faf694748", 710)]
        [TestCase(@"https://github.com/raveren/kint.git",
                @"590e3fcc3fd4234a8d5e844ce783c82464401d7f", 709)]
        [TestCase(@"https://github.com/dmolsen/Detector.git",
                @"f697794be555b4a2ce070a0b1265a1eb5f87fb58", 707)]
        [TestCase(@"https://github.com/facebook/xhp.git",
                @"1e1825cfdcd10e42c563b48e8f25818ee831ed9d", 705)]
        [TestCase(@"https://github.com/csscomb/csscomb.git",
                @"f065c6dc298a612b4f9492c382b6eb3f1ec1f095", 693)]
        [TestCase(@"https://github.com/kohana/core.git",
                @"06c8242ce73abce2a633944cb7b259f9ba861ef1", 690)]
        [TestCase(@"https://github.com/j4mie/paris.git",
                @"dd1a87544127874dce367f0252dcc81246dfc83b", 689)]
        [TestCase(@"https://github.com/brianhaveri/Underscore.php.git",
                @"4c5c191bcf0bcb88a0a9bee9d47332ba44900a92", 687)]
        [TestCase(@"https://github.com/croogo/croogo.git",
                @"8b99a1d2128e6b45b969beae1d3391c8bddcbd23", 685)]
        [TestCase(@"https://github.com/tommcfarlin/WordPress-Widget-Boilerplate.git",
                @"d5ece3b884d376e4dee820ecc2aa33e928e6d5ac", 680)]
        [TestCase(@"https://github.com/ushahidi/Ushahidi_Web.git",
                @"712909759ca1a2e97c912b360bf2a67ac856c25b", 667)]
        [TestCase(@"https://github.com/squizlabs/PHP_CodeSniffer.git",
                @"339b91cd73c9930c792d54092dc6e1cd376b7a8d", 666)]
        [TestCase(@"https://github.com/ruflin/Elastica.git",
                @"be1729b04954da58bc1f5c97eb3bcfac12e61249", 653)]
        [TestCase(@"https://github.com/bshaffer/oauth2-server-php.git",
                @"153fdf3123cdcf971fc2d88222765528813ae085", 650)]
        [TestCase(@"https://github.com/Intervention/image.git",
                @"517d9ba46735237b279ed97bafb79fc68f6ce350", 647)]
        [TestCase(@"https://github.com/vrana/adminer.git",
                @"bc466f7f85d248a939ecf5cfce7cc18af3dede7f", 645)]
        [TestCase(@"https://github.com/toddmotto/html5blank.git",
                @"d55c379dcf0df84bafbdc1634ed8a87be855344c", 643)]
        [TestCase(@"https://github.com/joomla/joomla-platform.git",
                @"10ea69dece20f9ef1fe57f8584f2cd8e7c17ac7f", 641)]
        [TestCase(@"https://github.com/frapi/frapi.git",
                @"ef50192b6cf336ef2c4c0fc3ad122194e3d0ecde", 638)]
        [TestCase(@"https://github.com/PrestaShop/PrestaShop.git",
                @"aadf18e60f7424376b586c2a8880c74e7736b308", 626)]
        [TestCase(@"https://github.com/symfony-cmf/symfony-cmf.git",
                @"0c9f93cbb2d6e1d94395db57f5cabe17f5631550", 622)]
        [TestCase(@"https://github.com/twittem/wp-bootstrap-navwalker.git",
                @"1e869edb03b04aff7792cf3327e94bb3dafac95b", 622)]
        [TestCase(@"https://github.com/openid/php-openid.git",
                @"cb53da46b73baff46ae325eb799d91703acc3780", 614)]
        [TestCase(@"https://github.com/apigen/apigen.git",
                @"396a550d0261c19bf44624f1342ab4a0d4e057ae", 613)]
        [TestCase(@"https://github.com/Datawalke/Coordino.git",
                @"d3d0b068b3d9be6864c72a021ba4cb77d770d916", 610)]
        [TestCase(@"https://github.com/mhoofman/wordpress-heroku.git",
                @"dca3d327dd9fa03cbb9ce05a01c790c92357b7c2", 608)]
        [TestCase(@"https://github.com/drush-ops/drush.git",
                @"407eaf355a04c96e6a8fcc1b94ac92c22022298e", 606)]
        [TestCase(@"https://github.com/devinsays/options-framework-plugin.git",
                @"e413c99778bf207ae3d6ac04a12ae4506a500637", 605)]
        [TestCase(@"https://github.com/elliotcondon/acf.git",
                @"772259933c0751e4325d16acbcbce415450bc054", 604)]
        [TestCase(@"https://github.com/FrozenNode/Laravel-Administrator.git",
                @"da269970a0b1153191cbaa76dbadd0bda6757eb1", 603)]
        [TestCase(@"https://github.com/facebook/php-webdriver.git",
                @"390c6008ba7b39c2180e2a5cc55c790315696a1c", 594)]
        [TestCase(@"https://github.com/catfan/Medoo.git",
                @"f9f6073cf52c68d5d5d4d1b9434f24ce3e42531c", 592)]
        [TestCase(@"https://github.com/phpbb/phpbb.git",
                @"b487da7c053a129c8e06056e4659ba7928f63c40", 590)]
        [TestCase(@"https://github.com/zencoder/html5-boilerplate-for-wordpress.git",
                @"7fb69b1759ea133128992533999c1e7e2dfcf1ed", 588)]
        [TestCase(@"https://github.com/thomasgriffin/TGM-Plugin-Activation.git",
                @"1e98e425f4a3bc43bd0fa05fe74a4268aa624f33", 587)]
        [TestCase(@"https://github.com/MPOS/php-mpos.git",
                @"6324471bdf670a68dbff614319003519cbf339f4", 586)]
        [TestCase(@"https://github.com/manifestinteractive/easyapns.git",
                @"154662a40f95e43025dce5b3cb405c9830060fd3", 586)]
        [TestCase(@"https://github.com/mikecao/flight.git",
                @"b9b2d0fa2d75e6b2f606fbd0d9a8059a0f741578", 585)]
        [TestCase(@"https://github.com/dodgepudding/wechat-php-sdk.git",
                @"28105dcdf2a3cd8a4a482e61896ea614b9b0b657", 583)]
        [TestCase(@"https://github.com/facebook/libphutil.git",
                @"3ca028dec2e77ec8780c644f453b5700b606ab60", 579)]
        [TestCase(@"https://github.com/concrete5/concrete5.git",
                @"98272c83c6ae20dc2a52ca677332bfe6a2a6581e", 576)]
        [TestCase(@"https://github.com/jamierumbelow/codeigniter-base-model.git",
                @"2d03af0bd87f6a191f09a63612da9b035733f077", 576)]
        [TestCase(@"https://github.com/Trimidea/inews.git",
                @"9b2072466c404007a37adfa42f3dde77b5ec4e51", 572)]
        [TestCase(@"https://github.com/sofadesign/limonade.git",
                @"a21f45f5b3c208e95162ef8246f4552c2963a70a", 572)]
        [TestCase(@"https://github.com/daylightstudio/FUEL-CMS.git",
                @"8d6ed8fd514a64a36af8173abcf54d632855012c", 571)]
        [TestCase(@"https://github.com/tpyo/amazon-s3-php-class.git",
                @"7cce95a8aea426c36d1290b3eeb84a46dbecf6e5", 566)]
        [TestCase(@"https://github.com/modxcms/revolution.git",
                @"817c7bf3148c253eb2c5540421fc118fc2608db2", 561)]
        [TestCase(@"https://github.com/Elgg/Elgg.git",
                @"f84677b41577195f44e9e34aa91fd407792fd2fb", 560)]
        [TestCase(@"https://github.com/laravelbook/ardent.git",
                @"0a0238b8040abc1c71401ce27a8edf2619fa5bed", 557)]
        [TestCase(@"https://github.com/J7mbo/twitter-api-php.git",
                @"ab76f1c1e6bf83f0a257216cbaf9932b7cc19a3f", 557)]
        [TestCase(@"https://github.com/jmathai/twitter-async.git",
                @"a361018261b887a5f8fb823a05e0e0e688a5c040", 556)]
        [TestCase(@"https://github.com/jmathai/epiphany.git",
                @"0418fa96add6bbc3c1e3b2dd313a041be72f9717", 555)]
        [TestCase(@"https://github.com/leemason/NHP-Theme-Options-Framework.git",
                @"ed709af8fc4e96dc2c638fad949b00594cca8427", 553)]
        [TestCase(@"https://github.com/NeonHorizon/berryio.git",
                @"d0f4d61a9f6123ac2d6c279afc1fec67accb9a75", 549)]
        [TestCase(@"https://github.com/atoum/atoum.git",
                @"ae761218e03e4df060153034924270660d4da768", 549)]
        [TestCase(@"https://github.com/WP-API/WP-API.git",
                @"e8bb59da12aa0df512b9138e2b741abbc9b9c1b0", 543)]
        [TestCase(@"https://github.com/jarednova/timber.git",
                @"4578c80160bbdbf43683fb610711b045c9f81d5f", 542)]
        [TestCase(@"https://github.com/peej/tonic.git",
                @"7589f49abc0f6c2a482978e0d7108bc7ba273543", 536)]
        [TestCase(@"https://github.com/meenie/munee.git",
                @"7f25338c978a284a26eb503e91430743eb760c00", 536)]
        [TestCase(@"https://github.com/wallabag/wallabag.git",
                @"4a74d9857cdb6116ce24df01b45176b92ad592c0", 534)]
        [TestCase(@"https://github.com/BenTheDesigner/Dropbox.git",
                @"94de100581fc103920786d38d4aa5433802d3842", 532)]
        [TestCase(@"https://github.com/hwi/HWIOAuthBundle.git",
                @"cb90e60c079bbf3aed8044cd71d5e03e32d60133", 531)]
        [TestCase(@"https://github.com/danielstjules/Stringy.git",
                @"8d961e25d09f946b463c0581e927a963f3578647", 529)]
        [TestCase(@"https://github.com/Xeoncross/micromvc.git",
                @"04779326fa0d5bbd672996a7bcac80150c9cd82f", 524)]
        [TestCase(@"https://github.com/google/google-api-php-client.git",
                @"85e361f074687b2cd374872d10e7b3309ab8d108", 521)]
        [TestCase(@"https://github.com/Behat/Mink.git",
                @"055da154b9fcb0bb238332adda3c4b38210c85d3", 520)]
        [TestCase(@"https://github.com/scribu/wp-posts-to-posts.git",
                @"4c524f337a8a4a5c407794d548e9171a46145e09", 520)]
        [TestCase(@"https://github.com/barryvdh/laravel-debugbar.git",
                @"9c0c6de939141f43efdf9c3beed22db50e2a4248", 510)]
        [TestCase(@"https://github.com/liu21st/thinkphp.git",
                @"6c9066f8a0f601e86fb80072ded623728f024ed4", 509)]
        [TestCase(@"https://github.com/laravel/cashier.git",
                @"f0de421064bdd633f951824ad0494baa6edb3998", 509)]
        [TestCase(@"https://github.com/Zizaco/confide.git",
                @"93138bc190ed29ad6ca0f750984c9f7e12aa0d54", 505)]
        [TestCase(@"https://github.com/jeromeschneider/Baikal.git",
                @"6c77c02e21f120379edb5ace593f0cc67c04fe92", 503)]
        [TestCase(@"https://github.com/nelmio/NelmioApiDocBundle.git",
                @"fd126c1a0101a7703489b2fd65c91526d2b75774", 499)]
        [TestCase(@"https://github.com/reeze/tipi.git",
                @"a515cdfa4896cf1471b63d208cd786af07972663", 489)]
        [TestCase(@"https://github.com/devinsays/options-framework-theme.git",
                @"474cf76be30938e50b54b8c3d326ae415e59c193", 486)]
        [TestCase(@"https://github.com/robmorgan/phinx.git",
                @"048393f59708be2f8d5faff4c57ed6d9ba3017d5", 484)]
        [TestCase(@"https://github.com/niklasvh/php.js.git",
                @"920b7e58ef6a97127d998e49889b1c0497364586", 483)]
        [TestCase(@"https://github.com/sebastianbergmann/phploc.git",
                @"eda0bfe29c804a317e8b013899ebc15b991d4e1a", 482)]
        [TestCase(@"https://github.com/eyecatchup/SEOstats.git",
                @"d6f8dc189f12801bdc2b5fc9aa58a4f342c76681", 481)]
        [TestCase(@"https://github.com/stof/StofDoctrineExtensionsBundle.git",
                @"f1c7993863f83f22f187f11d2a8eb462b836701e", 477)]
        [TestCase(@"https://github.com/typecho/typecho.git",
                @"310ee3e2dca3c100d3c102088a30326157a2304e", 477)]
        [TestCase(@"https://github.com/sebastianbergmann/phpcpd.git",
                @"a9462153f2dd90466a010179901d31fbff598365", 476)]
        [TestCase(@"https://github.com/pda/pheanstalk.git",
                @"56c44c947cf44a85c8d639209361da5f67b6fbff", 471)]
        [TestCase(@"https://github.com/ErikDubbelboer/phpRedisAdmin.git",
                @"f9b7820c76ed507267d853f11168425f340f9f4a", 467)]
        [TestCase(@"https://github.com/lyrixx/Silex-Kitchen-Edition.git",
                @"e82700b368833d3303303ddca68b2a663b349096", 467)]
        [TestCase(@"https://github.com/fabpot/Sismo.git",
                @"9732d3a1a370ab093e9e126f7ea0366ce64c7389", 462)]
        [TestCase(@"https://github.com/composer/satis.git",
                @"eed9a2e763d89be19b57f55486b62f12d97e6aab", 459)]
        [TestCase(@"https://github.com/phpspec/phpspec.git",
                @"5f3b795d37488439fc08ca6c7b33ec8fb28f643d", 458)]
        [TestCase(@"https://github.com/brunogaspar/laravel4-starter-kit.git",
                @"d27e3f66c487252c11b0e6f8962646df970b4060", 457)]
        [TestCase(@"https://github.com/Zizaco/entrust.git",
                @"b580e422df43b5abf9f46069421123497487604b", 457)]
        [TestCase(@"https://github.com/doctrine/mongodb-odm.git",
                @"dedb73ab4025989575fbfc784a4bc66aee737bcc", 455)]
        [TestCase(@"https://github.com/ZF-Commons/ZfcUser.git",
                @"8774d3d60d93b5e1c0d537ce6d5633c6f75960d1", 454)]
        [TestCase(@"https://github.com/rilwis/meta-box.git",
                @"f5f7209ec4b8050cf407eab8444ba673e30d625b", 454)]
        [TestCase(@"https://github.com/doctrine/dbal.git",
                @"32817aac490eeba4c39bd7670ec2f6182e496fc5", 449)]
        [TestCase(@"https://github.com/syamilmj/Options-Framework.git",
                @"c5ac7a0930b3e20f5f55ba4c38f1dd8a9eab1efe", 448)]
        [TestCase(@"https://github.com/videlalvaro/php-amqplib.git",
                @"1ca6d49bec6b8d2a011e94726c63d6bfad04856b", 446)]
        [TestCase(@"https://github.com/webtechnick/CakePHP-Facebook-Plugin.git",
                @"d1b4ae95bb610ab60b51f0e64e0227d42ae84b69", 446)]
        [TestCase(@"https://github.com/ircmaxell/PHPPHP.git",
                @"6d5d62a04fda07d7798587a7db424feae4663950", 445)]
        [TestCase(@"https://github.com/fabpot/Sami.git",
                @"a9578e8b51c70929b3687f57028699d403aafa84", 445)]
        [TestCase(@"https://github.com/xdebug/xdebug.git",
                @"684d90385ca8c6362eff3d1eb9a3539cc989ac3f", 443)]
        [TestCase(@"https://github.com/graulund/tweetnest.git",
                @"82a8d170592cde7fc5085e256c623351e3fe951d", 443)]
        [TestCase(@"https://github.com/PHPOffice/PHPWord.git",
                @"c6fc1d4e892b217d781bbc9ad194d9d0d0b05d84", 442)]
        [TestCase(@"https://github.com/vrana/notorm.git",
                @"d7f320a3d8da0dbcb17187ad4b9c91a396f5d0c6", 439)]
        [TestCase(@"https://github.com/jkudish/WordPress-GitHub-Plugin-Updater.git",
                @"6d0c856659de1f2f5083dc79a53018cdb973f3cd", 439)]
        [TestCase(@"https://github.com/duccio/ApnsPHP.git",
                @"a65a0aaf913389fcec7321f31eff4b6492c8291c", 437)]
        [TestCase(@"https://github.com/philsturgeon/codeigniter-restclient.git",
                @"296de79b3249101bc0af6502f358da4b55a262d5", 436)]
        [TestCase(@"https://github.com/nelmio/alice.git",
                @"6178f891f5dac28d28bbdb2721a0611add8d3177", 435)]
        [TestCase(@"https://github.com/symphonycms/symphony-2.git",
                @"15eb9fb550f203daa95c1a4d4e4597fe2da9ca73", 434)]
        [TestCase(@"https://github.com/codeguy/Upload.git",
                @"508ba2ba50119b6ab99a551806ef6b7d43c16b5c", 434)]
        [TestCase(@"https://github.com/technosophos/querypath.git",
                @"5597edb17eba8b974f2d8a5e65e4cb8fa0fc95f6", 432)]
        [TestCase(@"https://github.com/stripe/stripe-php.git",
                @"66d8b3139f7c11761d3ff33807210f7eedb78fbe", 430)]
        [TestCase(@"https://github.com/WhatCD/Gazelle.git",
                @"f544294c3a26706621a4551d6f24a32104b0b97b", 424)]
        [TestCase(@"https://github.com/contao/core.git",
                @"e61490827d472e75356a3794a36b2da3854d96c7", 422)]
        [TestCase(@"https://github.com/yandod/candycane.git",
                @"a115201174400922b5ba925e15800984dd90f95c", 421)]
        [TestCase(@"https://github.com/nategood/httpful.git",
                @"9d66cd3c37f2945eda5f3ee57ba8bad0b617eb3d", 421)]
        [TestCase(@"https://github.com/Sybio/ImageWorkshop.git",
                @"2b58bcde5205956e4b439cfaa86fb88113442d72", 418)]
        [TestCase(@"https://github.com/FriendsOfSymfony/FOSJsRoutingBundle.git",
                @"36629f5976f9f588093bf0bfb5230502fdb0eacf", 417)]
        [TestCase(@"https://github.com/brianlmoon/GearmanManager.git",
                @"da2e6ea736c96482ab79631b050d3a2a8a5a96df", 415)]
        [TestCase(@"https://github.com/phingofficial/phing.git",
                @"2692a9c2bf3744a1e0cc2b7ccd90f305e048df14", 413)]
        [TestCase(@"https://github.com/spotweb/spotweb.git",
                @"8d1e002f5358155854f2d2b535072b46a58f008e", 412)]
        [TestCase(@"https://github.com/backdrop/backdrop.git",
                @"2a826129975d67e913094f66049cb12387483d37", 411)]
        [TestCase(@"https://github.com/lisachenko/go-aop-php.git",
                @"2ed1ec129fb21eae2e830461fa1da629e9dbf658", 408)]
        [TestCase(@"https://github.com/peteboere/css-crush.git",
                @"d2192769bc27529b955a72c8e31698d2d907ad08", 408)]
        [TestCase(@"https://github.com/codeguy/Slim-Extras.git",
                @"59300d25d62f2f299b4065ed99eb71ca91f8a434", 408)]
        [TestCase(@"https://github.com/zynga/zperfmon.git",
                @"ee78dd143dd0555bef094b40877cc627309cb060", 408)]
        [TestCase(@"https://github.com/khoaofgod/phpfastcache.git",
                @"b74ef587cddd432fac57f05a4375ea41eac42e21", 408)]
        [TestCase(@"https://github.com/plainmade/unmark.git",
                @"bc5a242f243d6f211344868a937a8ba3af709591", 406)]
        [TestCase(@"https://github.com/fennb/phirehose.git",
                @"fe8d322690c3d106b2b2fc73c7df4a9581b16be9", 403)]
        [TestCase(@"https://github.com/Pawka/phrozn.git",
                @"a9be165f0c1210d6badba833653706e4ce95aa7f", 402)]
        [TestCase(@"https://github.com/sjlu/CodeIgniter-Bootstrap.git",
                @"49ad9c17a21577ed9883c216b9636d2e65f618c7", 401)]
        [TestCase(@"https://github.com/yupe/yupe.git",
                @"4082c3a0c7a8ced413b84147476b59c24812fbd9", 399)]
        [TestCase(@"https://github.com/Anahkiasen/former.git",
                @"fce6790e10bbd0acf3f5a5224d56477ecd44ba7b", 397)]
        [TestCase(@"https://github.com/mageplus/mageplus.git",
                @"2e06c9d5752e9397cb045c80a22f74d61fede7e4", 396)]
        [TestCase(@"https://github.com/rgrove/jsmin-php.git",
                @"948d87c203010b0544ecc50cf31ad743d7e02a57", 392)]
        [TestCase(@"https://github.com/walu/phpbook.git",
                @"b0b3a2f0e5d8dcc8c4991586e794e3b36ef6e4f1", 392)]
        [TestCase(@"https://github.com/patrikf/glip.git",
                @"50edbd9c77eda1aa91fbb971403492b635cf9482", 391)]
        [TestCase(@"https://github.com/genemu/GenemuFormBundle.git",
                @"9fecbe7a12fba1761228909e843301c4d1a11e7c", 391)]
        [TestCase(@"https://github.com/phpseclib/phpseclib.git",
                @"1a7e3746d540fa32df0f414852e7b0597de47291", 389)]
        [TestCase(@"https://github.com/twilio/twilio-php.git",
                @"389e07ee41eabc422ea88b805006bccac7de9eb3", 389)]
        [TestCase(@"https://github.com/jenssegers/Laravel-MongoDB.git",
                @"2ae7980f86312f050c2ab626f48fa9015fbe26a3", 389)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepositorySavingRepo(
                    url, commitPointer, "php_repo.csv", starCount, "*.php");
        }
    }
}