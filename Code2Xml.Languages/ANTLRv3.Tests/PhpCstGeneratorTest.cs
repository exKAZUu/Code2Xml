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
            var exp = new PhpComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "php_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.php");
        }
    }
}