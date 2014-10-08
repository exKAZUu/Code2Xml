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
using Code2Xml.Core.Generators.ANTLRv3.JavaScript;
using Code2Xml.Learner.Core.Learning.Experiments;
using NUnit.Framework;

namespace Code2Xml.Core.Tests.Generators.ANTLRv3 {
    [TestFixture]
    public class JavaScriptCstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new JavaScriptCstGeneratorUsingAntlr3();
        }

        [Test]
        [TestCase(@"")]
        [TestCase(@"var i = 1;")]
        [TestCase(@"function
f() {
	return 1
}")]
        [TestCase(@"for ( var i = 0, j = 0; i < 1; i++, j++ ) { }")]
        [TestCase(@"for(var i = 0, ii = directives.length; i < ii; i++) { }")]
        [TestCase(@"console.log('test')")]
        [TestCase(@"
//
")]
        [TestCase(@"
            compile({
                                          //
                                        });
")]
        [TestCase(@"
return 'a\
b';
")]
        [TestCase(@"
var path = require('path');
var argv = require('optimist').argv;
var completion = require('../lib/completion');
")]
        [TestCase(@"function(name) { this.name = name; }")]
        [TestCase(
                @"if ( first === 0 ) { return diff === 0; } else { return ( diff % first === 0 && diff / first >= 0 ); }"
                )]
        [TestCase("{ a = 0 }")]
        [TestCase(
                "function cv(a){if(!cj[a]){var b=f(\"<\"+a+\">\").appendTo(\"body\"),d=b.css(\"display\");b.remove();if(d===\"none\"||d===\"\"){ck||(ck=c.createElement(\"iframe\"),ck.frameBorder=ck.width=ck.height=0),c.body.appendChild(ck);if(!cl||!ck.createElement)cl=(ck.contentWindow||ck.contentDocument).document,cl.write(\"<!doctype><html><body></body></html>\");b=cl.createElement(a),cl.body.appendChild(b),d=f.css(b,\"display\"),c.body.removeChild(ck)}cj[a]=d}return cj[a]}"
                )]
        [TestCase(@"quickExpr = 'aaaa\naaa\w\Waaa\'a'")]
        [TestCase("quickExpr = \"aaaa\\naaa\\w\\Waaa\\\"a\"")]
        [TestCase(@"quickExpr = /\w\W\/\-/")]
        [TestCase(@"quickExpr = '#'")]
        [TestCase(@"quickExpr = /#/")]
        [TestCase(@"{1}")]
        [TestCase(@"{1}2")]
        [TestCase("\" \\t\\n\\r\\f\\u00A0\"")]
        [TestCase(@"((i = 1))")]
        [TestCase("var a\na = 0")]
        [TestCase("a = \"a\\\nb\"")]
        [TestCase(@"class2type = {};")]
        [TestCase(@"quickExpr = '^(?:[^<]*(<[\w]+>)[^>]*$|([\w]*)$)'")]
        [TestCase("quickExpr = \"^(?:[^<]*(<[\\w]+>)[^>]*$|([\\w]*)$)\"")]
        [TestCase(@"quickExpr = /^(?:[^<]*(<[\w]+>)[^>]*$|([\w]*)$)/")]
        [TestCase(@"rsingleTag = /^<(\w+)\s*\/?>(?:<\/\1>)?$/")]
        [TestCase(@"quickExpr = 'a'")]
        [TestCase("quickExpr = \"a\"")]
        [TestCase(@"quickExpr = /a/")]
        [TestCase(@"{1}{2}")]
        [TestCase(@"[ 1 / 1 ]")]
        [TestCase(@"res.true;")]
        [TestCase(@"res.function;")]
        [TestCase(@"import 'start';")]
        [TestCase(@"module.exports = function(grunt) { };")]
        [TestCase(@"export default xxx;")]
        [TestCase(@"i = 0 + 1 - 2 * 3 / 4;")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Block1.js")]
        [TestCase("Block2.js")]
        [TestCase("Block3.js")]
        [TestCase("extracting_branch.js")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("JavaScript", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/backbone-boilerplate/backbone-boilerplate.git",
                @"c698a5482b2ee7369d4972bfa3faed8f8709ea1b", 4212)]
        [TestCase(@"https://github.com/shutterstock/rickshaw.git",
                @"71877d994a81d39a003e3638b751ac5e6d6c87c6", 4205)]
        [TestCase(@"https://github.com/douglascrockford/JSON-js.git",
                @"3d7767b6b1f3da363c625ff54e63bbf20e9e83ac", 4198)]
        //[TestCase(@"https://github.com/LearnBoost/stylus.git",
        //        @"44fa9ddc6a1e55d8f0b3cec382291619b6ac33c3", 4187)]
        //[TestCase(@"https://github.com/davatron5000/FitText.js.git",
        //        @"1eb8a337ab9999166ae1b328f46cda60a13b4aab", 4148)]
        //[TestCase(@"https://github.com/npm/npm.git",
        //        @"6be6b4b74e5fd256a1bdfa098ea6541c62b30928", 4134)]
        //[TestCase(@"https://github.com/nodejitsu/forever.git",
        //        @"09d8403bcde961afadd8dba3daecab47ad213989", 4132)]
        //[TestCase(@"https://github.com/mozilla/togetherjs.git",
        //        @"aabd258007828fc7ec3949fbd82374eb03061bce", 4119)]
        //[TestCase(@"https://github.com/mleibman/SlickGrid.git",
        //        @"33e75b07bfd769349525dc084d987c406fc03e24", 4068)]
        //[TestCase(@"https://github.com/stubbornella/oocss.git",
        //        @"0c146a17e13d7b9d5797ffbf2805ce482cbddd9b", 4062)]
        //[TestCase(@"https://github.com/GoodBoyDigital/pixi.js.git",
        //        @"d90b75755a88a355b61c64a64f127214165ee4f5", 4059)]
        //[TestCase(@"https://github.com/dimsemenov/Magnific-Popup.git",
        //        @"3a35b057de57535db87826886acb91c15ddfa384", 4058)]
        //[TestCase(@"https://github.com/unconed/TermKit.git",
        //        @"2d368b849d6185df661bf89f742455875c00da2a", 4053)]
        //[TestCase(@"https://github.com/sindresorhus/pageres.git",
        //        @"2213ebcecd8e5cff45bc5691113ad8c6069fac36", 4046)]
        //[TestCase(@"https://github.com/imakewebthings/deck.js.git",
        //        @"63b55fea6b92d442e20fb64446783d9f2ac7c85b", 4020)]
        //[TestCase(@"https://github.com/VerbalExpressions/JSVerbalExpressions.git",
        //        @"db1cb79cf0d6c2dd7f5f4dc1b3c4a961052dcf3c", 4006)]
        //[TestCase(@"https://github.com/madrobby/keymaster.git",
        //        @"21e3785a1c3509161c4d812d42d1f9a604b82825", 3991)]
        //[TestCase(@"https://github.com/Polymer/polymer.git",
        //        @"ebae29364a9462c5ba5f89a1a689c9c280d54904", 3965)]
        //[TestCase(@"https://github.com/photonstorm/phaser.git",
        //        @"4c31623e6e89e1f68ad910cb026a9d86f50287e3", 3950)]
        //[TestCase(@"https://github.com/briangonzalez/jquery.adaptive-backgrounds.js.git",
        //        @"cfe1ec04167ae8c341e0404f62d94063c1112bd9", 3945)]
        //[TestCase(@"https://github.com/amsul/pickadate.js.git",
        //        @"18c62b215be96fb72fb6bbb3b84ee3e789dd48e1", 3943)]
        //[TestCase(@"https://github.com/adobe-webplatform/Snap.svg.git",
        //        @"f94872941f4f833e2f1feb88c2ef1c43d83a88b4", 3919)]
        //[TestCase(@"https://github.com/linnovate/mean.git",
        //        @"5a0c1693c58fb436541015c12603306294afe60e", 3897)]
        //[TestCase(@"https://github.com/getify/You-Dont-Know-JS.git",
        //        @"6cc6fc3c318372dc63f24c3d13e7f2063cff3b03", 3869)]
        //[TestCase(@"https://github.com/aFarkas/html5shiv.git",
        //        @"3013608075d82c4eaea0d6eeb5af0273f63e4938", 3842)]
        //[TestCase(@"https://github.com/thebird/Swipe.git",
        //        @"32c19c95ea09092167cd07cc783da24f79f5adf6", 3821)]
        //[TestCase(@"https://github.com/cubiq/iscroll.git",
        //        @"44d992bcaf1b6bb3eb69c43b9776247b0ab062ff", 3798)]
        //[TestCase(@"https://github.com/jzaefferer/jquery-validation.git",
        //        @"13d56eb009d2b3d767e1de6d8926f337c41e6c3f", 3790)]
        //[TestCase(@"https://github.com/mozilla/BrowserQuest.git",
        //        @"af32d247cac3495ca430d0effbb88dd5f3250b2c", 3763)]
        //[TestCase(@"https://github.com/imakewebthings/jquery-waypoints.git",
        //        @"6c7d129433343d04feca94310f117a966dab4721", 3749)]
        //[TestCase(@"https://github.com/paperjs/paper.js.git",
        //        @"9ccba17fbefa5a29a3ac359ad3d822caee6e98ff", 3730)]
        //[TestCase(@"https://github.com/ducksboard/gridster.js.git",
        //        @"a4f3baf38ffdffdc8b7cccd55a8f2667a593adf7", 3725)]
        //[TestCase(@"https://github.com/jschr/bootstrap-modal.git",
        //        @"47cb49a43fcf6e2c4cea40b9a65ac6595b3cc06b", 3679)]
        //[TestCase(@"https://github.com/mindmup/bootstrap-wysiwyg.git",
        //        @"9304f95917d603d813a9a9fd2670a586e5d74cde", 3647)]
        //[TestCase(@"https://github.com/tommoor/tinycon.git",
        //        @"0c860eecb63386ace9df16cbfc7897da3c664b84", 3629)]
        //[TestCase(@"https://github.com/WickyNilliams/headroom.js.git",
        //        @"1778e521e9978e17b2f0f826f72fd2e0b61c21a7", 3624)]
        //[TestCase(@"https://github.com/fabien-d/alertify.js.git",
        //        @"8492f15459efed9e5cbdeeaa879fa5796ce78170", 3598)]
        //[TestCase(@"https://github.com/jhollingworth/bootstrap-wysihtml5.git",
        //        @"283bb8f859977ac1aafb09bee715a1190f8cfd1b", 3592)]
        //[TestCase(@"https://github.com/adam-p/markdown-here.git",
        //        @"6f5222e45129db32838edd7e6e5c241d391f9de0", 3509)]
        //[TestCase(@"https://github.com/koajs/koa.git",
        //        @"430246c114e2782bcb0a2bb69842fbd78b0fcbab", 3501)]
        //[TestCase(@"https://github.com/aterrien/jQuery-Knob.git",
        //        @"1a6d5811fbf4f0d5508718a1d03e2cdb34cb6ed2", 3488)]
        //[TestCase(@"https://github.com/ExactTarget/fuelux.git",
        //        @"ebc519903c35356eaaa7c04f1dcad3e469cda0fc", 3480)]
        //[TestCase(@"https://github.com/jacomyal/sigma.js.git",
        //        @"7bd4b61f4f892c3531582436cd3213a2a8ef6b52", 3472)]
        //[TestCase(@"https://github.com/ether/etherpad-lite.git",
        //        @"962b166c3aa54889652db4d19c74fa6a25ec1b53", 3464)]
        //[TestCase(@"https://github.com/maroslaw/rainyday.js.git",
        //        @"ddd1a085f489e15165c69923fa50fa4e636b9de2", 3451)]
        //[TestCase(@"https://github.com/chjj/marked.git",
        //        @"dc3b344e82a0548c2faf290135d9447c06bd2574", 3436)]
        //[TestCase(@"https://github.com/square/crossfilter.git",
        //        @"6c84abd3d22cfd1594ce846b5d5edcec15a317a5", 3436)]
        //[TestCase(@"https://github.com/OscarGodson/EpicEditor.git",
        //        @"628020033d28f0d64fe8a3cf1e6e5ca441cbb3fc", 3436)]
        //[TestCase(@"https://github.com/GitbookIO/gitbook.git",
        //        @"f43e630528be43d5aec4e6f923b0f53107f93546", 3413)]
        //[TestCase(@"https://github.com/brianreavis/selectize.js.git",
        //        @"d6a6f53625f5d9c4de9337978e05b80136983990", 3411)]
        //[TestCase(@"https://github.com/jaredhanson/passport.git",
        //        @"298d2452430dd0d1841d417e9c0d0b23e4b06239", 3380)]
        //[TestCase(@"https://github.com/h5bp/mobile-boilerplate.git",
        //        @"36661edc9092730346f66fe0d7785712604ffc41", 3376)]
        //[TestCase(@"https://github.com/headjs/headjs.git",
        //        @"edc8427191a633d80e7372c49e6d28a098be766f", 3351)]
        //[TestCase(@"https://github.com/twitter/hogan.js.git",
        //        @"b1328c06eedf316bbe4c54b189ecb47cff7ac2ed", 3338)]
        //[TestCase(@"https://github.com/CreateJS/EaselJS.git",
        //        @"0374f486f0824b6da518b3a73faf084032596e81", 3316)]
        //[TestCase(@"https://github.com/paulasmuth/fnordmetric.git",
        //        @"d402c92fe6c880da28a27d3a5fa441965f55bd3d", 3310)]
        //[TestCase(@"https://github.com/blasten/turn.js.git",
        //        @"08c1f6599a1412b145c7bf645a1f28c14db12742", 3303)]
        //[TestCase(@"https://github.com/alvarotrigo/fullPage.js.git",
        //        @"9c149a3b43fd5450f2cc6d0dc7cd7bc5b6edd01e", 3279)]
        //[TestCase(@"https://github.com/felixge/node-mysql.git",
        //        @"f37cf8d0ba86edf712183940a9a9a05d3517d4ae", 3275)]
        //[TestCase(@"https://github.com/flot/flot.git",
        //        @"3aec7ce0bd975e452ff49107905a06146fe9e560", 3268)]
        //[TestCase(@"https://github.com/jackmoore/colorbox.git",
        //        @"f0a70f32221355c73a3a7c7dd85a0b9ec9011d47", 3257)]
        //[TestCase(@"https://github.com/vitalets/x-editable.git",
        //        @"f32802f48a33b8a7ec9cca32eec4ca844b7d39b2", 3250)]
        //[TestCase(@"https://github.com/remy/html5demos.git",
        //        @"0e4aff9432c3e34f3ef8b3726461e9dfd1bd43ea", 3247)]
        //[TestCase(@"https://github.com/mgcrea/angular-strap.git",
        //        @"a3ff0667f4897b210c70f350f9a994c6cd391747", 3224)]
        //[TestCase(@"https://github.com/jshint/jshint.git",
        //        @"20e2bee28242fa627e3a98087dda8713850941a9", 3187)]
        //[TestCase(@"https://github.com/square/cube.git",
        //        @"084bebe6839ffbd442010427f017e38e0fe0bef7", 3183)]
        //[TestCase(@"https://github.com/madebymany/sir-trevor-js.git",
        //        @"9be4a0694d854d7c5354d06a83ce6e3b86eae4f8", 3176)]
        //[TestCase(@"https://github.com/benweet/stackedit.git",
        //        @"1d7308ebaa09679e96126345a4818bdd24d96f2f", 3164)]
        //[TestCase(@"https://github.com/codeparty/derby.git",
        //        @"a84ba83f2fc0daf089c4c2f7de46d84fdbe138ab", 3144)]
        //[TestCase(@"https://github.com/Unitech/pm2.git",
        //        @"3a7932325d1f41f5fb08c949be64b885f47b7a51", 3130)]
        //[TestCase(@"https://github.com/remy/nodemon.git",
        //        @"787bebf1ac635c79f0a0d8fc1921ef338f0e1779", 3126)]
        //[TestCase(@"https://github.com/phonegap/phonegap-start.git",
        //        @"62fae0a8bd18ce15adf1e9485c819f79e9994663", 3119)]
        //[TestCase(@"https://github.com/niklasvh/html2canvas.git",
        //        @"454524cc4041cf6eef3df76f87cfef4a0e9e7c09", 3112)]
        //[TestCase(@"https://github.com/jimhigson/oboe.js.git",
        //        @"6b1ec90658ece4d19a9567a5e7786396391e4570", 3095)]
        //[TestCase(@"https://github.com/NetEase/pomelo.git",
        //        @"a077c4044dfa0e086b552e234e545353cb18d436", 3090)]
        //[TestCase(@"https://github.com/square/cubism.git",
        //        @"7181f11f54eda094abac15d14c7c6a3a11633d3e", 3082)]
        //[TestCase(@"https://github.com/dieulot/instantclick.git",
        //        @"a92fd5c9d9f10929e1a482c4b07bf72b5fc1acf5", 3077)]
        //[TestCase(@"https://github.com/Diogenesthecynic/FullScreenMario.git",
        //        @"cbd53d0f504ed6bc0d69180d1188faebf1960d6f", 3073)]
        //[TestCase(@"https://github.com/jquery/sizzle.git",
        //        @"bd428012b95c333f39685a0abb4e94e7f108c813", 3067)]
        //[TestCase(@"https://github.com/imsky/holder.git",
        //        @"1a299d6bb214f15b44577785cfeaf6ee7593e516", 3048)]
        //[TestCase(@"https://github.com/mgonto/restangular.git",
        //        @"8e65e1c8e6307e23cae1540415003023bc07bece", 3044)]
        //[TestCase(@"https://github.com/needim/noty.git",
        //        @"942473303dfa0b296d9aa316fa0a111e0cab1b4d", 3043)]
        //[TestCase(@"https://github.com/component/component.git",
        //        @"fe2aae08eebee54fe80ed4b458232d2f7d8fa6bc", 3042)]
        //[TestCase(@"https://github.com/segmentio/myth.git",
        //        @"e22b58562c6285a38d95b7fa5d3afc8a52764c8a", 2986)]
        //[TestCase(@"https://github.com/angular-app/angular-app.git",
        //        @"9b11c05eae688903b8ed797fd09bb2ac13cc3d52", 2984)]
        //[TestCase(@"https://github.com/kenkeiter/skeuocard.git",
        //        @"2d3067e4c19e90ad9dc1d3e6de72e007e8f8417e", 2969)]
        //[TestCase(@"https://github.com/daviferreira/medium-editor.git",
        //        @"73938c780eca8ee8eaf662159b7f80ded9faa68a", 2958)]
        //[TestCase(@"https://github.com/n1k0/casperjs.git",
        //        @"ff12c243ee66e674a8fccf534916142a004b0921", 2957)]
        //[TestCase(@"https://github.com/BBC-News/Imager.js.git",
        //        @"ef6d6a5ec3c506ced7ff46db3ac003639ff31eac", 2956)]
        //[TestCase(@"https://github.com/davatron5000/FitVids.js.git",
        //        @"2f4fbf3389e9ae65ae73fb1e1a2c1db4b4ebc6c4", 2956)]
        //[TestCase(@"https://github.com/kangax/fabric.js.git",
        //        @"c53089a60a4bff1f9db916146ef2bf5639d1c03f", 2937)]
        //[TestCase(@"https://github.com/simplefocus/FlowType.JS.git",
        //        @"a97f341dfc2c7e81cda21e04d8531a7e6084563d", 2928)]
        //[TestCase(@"https://github.com/bebraw/jswiki.git",
        //        @"2b6758e1f706c52224938b4efe2b4e21b14fb494", 2925)]
        //[TestCase(@"https://github.com/paulirish/infinite-scroll.git",
        //        @"3ffe36bf4fe7df254b3e4ce273bbed6036633fe2", 2913)]
        //[TestCase(@"https://github.com/nodejitsu/node-http-proxy.git",
        //        @"c54278bd3b00e82f4253393b6f6beb1d5a1b19e5", 2906)]
        //[TestCase(@"https://github.com/socketstream/socketstream.git",
        //        @"86afc6679c90f86cb90fcb3409a86c6c6e619812", 2903)]
        //[TestCase(@"https://github.com/arshaw/fullcalendar.git",
        //        @"0dfc25afcb99c4d1e89f51f8a1ebf71790aa3cf1", 2883)]
        //[TestCase(@"https://github.com/warpech/jquery-handsontable.git",
        //        @"29d60f31c7c52709552ce0a9673c0e01c4b96a18", 2874)]
        //[TestCase(@"https://github.com/julianlloyd/scrollReveal.js.git",
        //        @"df0703c3e8c255a687a36dd317f1ce5611f8ac96", 2871)]
        //[TestCase(@"https://github.com/jquery/qunit.git",
        //        @"04e0337cc7fba5c08fc8a7fc8542cadd062f1b03", 2863)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepo(url, commitPointer, "*.js");
        }

        [Test]
        public void ParseComment() {
            var e = Generator.GenerateTreeFromCodeText(
                    @"function(name) { /*a*/ } //aa
/*
c*/");
            Assert.That(
                    e.AllHiddens()
                            .Count(e2 => e2.Name == "Comment" || e2.Name == "LineComment"),
                    Is.EqualTo(3));
            var pos = e.AllHiddens("Comment").Last().Range;
            Assert.That(pos.StartLine, Is.EqualTo(2));
            Assert.That(pos.EndLine, Is.EqualTo(3));
            Assert.That(pos.StartPosition, Is.EqualTo(0));
            Assert.That(pos.EndPosition, Is.EqualTo(3));
        }
    }
}