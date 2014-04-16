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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Objects.Tests.Learning.Experiments {
    [TestFixture]
    public class JavaScriptExperiment {
        private readonly StreamWriter _writer = File.CreateText(
                @"C:\Users\exKAZUu\Desktop\javascript.txt");

        public static CstGenerator Generator = CstGenerators.JavaScriptUsingAntlr3;
        private const string LangName = "JavaScript";

        private static IEnumerable<TestCaseData> TestCases {
            get {
                var exps = new LearningExperiment[] {
                    new JavaScriptComplexStatementExperiment(),
                    new JavaScriptSuperComplexBranchExperiment(),
                    //new JavaScriptComplexBranchExperiment(),
                    //new JavaScriptIfExperiment(),
                    //new JavaScriptWhileExperiment(),
                    //new JavaScriptDoWhileExperiment(),
                    //new JavaScriptForExperiment(),
                    //new JavaScriptConsoleLogExperiment(),
                    //new JavaScriptStatementExperiment(),
                    //new JavaScriptBlockExperiment(),
                    //new JavaScriptLabeledStatementExperiment(),
                    //new JavaScriptEmptyStatementExperiment(),
                };
                var learningSets = new[] {
                    Tuple.Create(
                            @"https://github.com/douglascrockford/JSON-js.git",
                            @"3d7767b6b1f3da363c625ff54e63bbf20e9e83ac"),
                    Tuple.Create(
                            @"https://github.com/bower/bower.git",
                            @"03f035cdf03ce027892a46d8e0f731dc9b950561"),
                    Tuple.Create(
                            @"https://github.com/defunkt/jquery-pjax.git",
                            @"67fbdced9825864a7949c3103c4d90cf6a8b1e29"),
                    Tuple.Create(
                            @"https://github.com/caolan/async.git",
                            @"931d15412c5081e35f96dee3cc7a98d8322e7b17"),
                    Tuple.Create(
                            @"https://github.com/Prinzhorn/skrollr.git",
                            @"a08d11500a50d22cfca549864e9a486c17b29c90"),
                    Tuple.Create(
                            @"https://github.com/resume/resume.github.com.git",
                            @"c537d43f3eeb259578f4a0501cb5c0014edd3b72"),
                    Tuple.Create(
                            @"https://github.com/gruntjs/grunt.git",
                            @"4ae8a07d3854f5affd3002d3395725dc25648ee3"),
                    Tuple.Create(
                            @"https://github.com/addyosmani/backbone-fundamentals.git",
                            @"7372900a65b6942d234f69f1ed982f094ff5b0bf"),
                    Tuple.Create(
                            @"https://github.com/EightMedia/hammer.js.git",
                            @"b9e3ecec174c7ae217489dc3a24540a64243692e"),
                    Tuple.Create(
                            @"https://github.com/twitter/typeahead.js.git",
                            @"0caa797de2bee9c7f06af08cb5579f8cdfb6a7b9"),
                    Tuple.Create(
                            @"https://github.com/rwaldron/idiomatic.js.git",
                            @"4b2938bd2e2ca3251367572e3613a7a2935aba53"),
                    Tuple.Create(
                            @"https://github.com/usablica/intro.js.git",
                            @"10fab7d91f0ea28e61f32812abb70112ffb3d624"),
                    Tuple.Create(
                            @"https://github.com/nnnick/Chart.js.git",
                            @"8f025f33c08c66991a12f02f908bab156a963aef"),
                    Tuple.Create(
                            @"https://github.com/rstacruz/nprogress.git",
                            @"4c3af762a7576632a0ca2718a53a17bdeb45efe8"),
                    Tuple.Create(
                            @"https://github.com/pivotal/jasmine.git",
                            @"00c8e372576438243a8f977b8bc7b81f04389dd6"),
                    Tuple.Create(
                            @"https://github.com/Shopify/dashing.git",
                            @"ff3acd8074e57edba29bf731d3d0a8b6761f97ca"),
                    Tuple.Create(
                            @"https://github.com/madrobby/zepto.git",
                            @"579c0971f4b21ebb25831278a7012fa76494d5cc"),
                    Tuple.Create(
                            @"https://github.com/janl/mustache.js.git",
                            @"0295646b677b8c9e15527e8b63583ed6728b77d0"),
                    Tuple.Create(
                            @"https://github.com/scottjehl/Respond.git",
                            @"3fde2627484f8cb38e2bd4dbf2374cf41184b0f4"),
                    Tuple.Create(
                            @"https://github.com/wycats/handlebars.js.git",
                            @"085e5e1937b442a4d4add5525db2627e825538aa"),
                    Tuple.Create(
                            @"https://github.com/NUKnightLab/TimelineJS.git",
                            @"cede826f6212af83361ecd571481b5bb95f7a610"),
                    Tuple.Create(
                            @"https://github.com/DmitryBaranovskiy/raphael.git",
                            @"5234aa33d04be07b0fea7627504ab4b53d872e19"),
                    Tuple.Create(
                            @"https://github.com/ftlabs/fastclick.git",
                            @"3497d2e92ccc8a959c7efb326c0fc437302d5bcf"),
                    Tuple.Create(
                            @"https://github.com/douglascrockford/JSON-js.git",
                            @"3d7767b6b1f3da363c625ff54e63bbf20e9e83ac"),
                    Tuple.Create(
                            @"https://github.com/bower/bower.git",
                            @"03f035cdf03ce027892a46d8e0f731dc9b950561"),
                    Tuple.Create(
                            @"https://github.com/jquery/jquery-mobile.git",
                            @"1f95855f47bf0b4302b1749dda88a4d64b1345bf"),
                    Tuple.Create(
                            @"https://github.com/defunkt/jquery-pjax.git",
                            @"67fbdced9825864a7949c3103c4d90cf6a8b1e29"),
                    Tuple.Create(
                            @"https://github.com/caolan/async.git",
                            @"931d15412c5081e35f96dee3cc7a98d8322e7b17"),
                    Tuple.Create(
                            @"https://github.com/Prinzhorn/skrollr.git",
                            @"a08d11500a50d22cfca549864e9a486c17b29c90"),
                    Tuple.Create(
                            @"https://github.com/resume/resume.github.com.git",
                            @"c537d43f3eeb259578f4a0501cb5c0014edd3b72"),
                    Tuple.Create(
                            @"https://github.com/addyosmani/backbone-fundamentals.git",
                            @"7372900a65b6942d234f69f1ed982f094ff5b0bf"),
                    Tuple.Create(
                            @"https://github.com/gruntjs/grunt.git",
                            @"4ae8a07d3854f5affd3002d3395725dc25648ee3"),
                    Tuple.Create(
                            @"https://github.com/EightMedia/hammer.js.git",
                            @"b9e3ecec174c7ae217489dc3a24540a64243692e"),
                    Tuple.Create(
                            @"https://github.com/twitter/typeahead.js.git",
                            @"0caa797de2bee9c7f06af08cb5579f8cdfb6a7b9"),
                    Tuple.Create(
                            @"https://github.com/rwaldron/idiomatic.js.git",
                            @"4b2938bd2e2ca3251367572e3613a7a2935aba53"),
                    Tuple.Create(
                            @"https://github.com/usablica/intro.js.git",
                            @"10fab7d91f0ea28e61f32812abb70112ffb3d624"),
                    Tuple.Create(
                            @"https://github.com/nnnick/Chart.js.git",
                            @"8f025f33c08c66991a12f02f908bab156a963aef"),
                    Tuple.Create(
                            @"https://github.com/rstacruz/nprogress.git",
                            @"4c3af762a7576632a0ca2718a53a17bdeb45efe8"),
                    Tuple.Create(
                            @"https://github.com/pivotal/jasmine.git",
                            @"00c8e372576438243a8f977b8bc7b81f04389dd6"),
                    Tuple.Create(
                            @"https://github.com/Shopify/dashing.git",
                            @"ff3acd8074e57edba29bf731d3d0a8b6761f97ca"),
                    Tuple.Create(
                            @"https://github.com/madrobby/zepto.git",
                            @"579c0971f4b21ebb25831278a7012fa76494d5cc"),
                    Tuple.Create(
                            @"https://github.com/janl/mustache.js.git",
                            @"0295646b677b8c9e15527e8b63583ed6728b77d0"),
                    Tuple.Create(
                            @"https://github.com/scottjehl/Respond.git",
                            @"3fde2627484f8cb38e2bd4dbf2374cf41184b0f4"),
                    Tuple.Create(
                            @"https://github.com/wycats/handlebars.js.git",
                            @"085e5e1937b442a4d4add5525db2627e825538aa"),
                    Tuple.Create(
                            @"https://github.com/NUKnightLab/TimelineJS.git",
                            @"cede826f6212af83361ecd571481b5bb95f7a610"),
                    Tuple.Create(
                            @"https://github.com/DmitryBaranovskiy/raphael.git",
                            @"5234aa33d04be07b0fea7627504ab4b53d872e19"),
                    Tuple.Create(
                            @"https://github.com/ftlabs/fastclick.git",
                            @"3497d2e92ccc8a959c7efb326c0fc437302d5bcf"),
                    Tuple.Create(
                            @"https://github.com/wagerfield/parallax.git",
                            @"a42beb93b7cdcb9dbfdb0e96e5eafd5232b86ba2"),
                    Tuple.Create(
                            @"https://github.com/fgnass/spin.js.git",
                            @"cdf391a8e41b6ad8f902dc9a10cae80486d472ef"),
                    Tuple.Create(
                            @"https://github.com/balderdashy/sails.git",
                            @"6adfdf85eebdc6e001bacdc5098a58a1cd93aa38"),
                    Tuple.Create(
                            @"https://github.com/desandro/masonry.git",
                            @"b9df286dc6a3004b8a7f90599c7ba79d09e8ce2e"),
                    Tuple.Create(
                            @"https://github.com/xing/wysihtml5.git",
                            @"56960b31adc37e07797382d8e8b10109f206b19c"),
                    Tuple.Create(
                            @"https://github.com/etsy/statsd.git",
                            @"f95dd0360fdf0e14ef2fe9080611d1b3594b6297"),
                    Tuple.Create(
                            @"https://github.com/kamens/jQuery-menu-aim.git",
                            @"86ac9a0782ebc417b50114c2475f2a4b106cf121"),
                    Tuple.Create(
                            @"https://github.com/shichuan/javascript-patterns.git",
                            @"1a1805763e54c99359d96792e0396b47af649d6c"),
                    Tuple.Create(
                            @"https://github.com/videojs/video.js.git",
                            @"3bafdeef51d9f135de13fe4c51158942031ce6c2"),
                    Tuple.Create(
                            @"https://github.com/enyo/dropzone.git",
                            @"ac87ee44d7219afb091e22db0748e58ca989b466"),
                    Tuple.Create(
                            @"https://github.com/peachananr/onepage-scroll.git",
                            @"fb65fb933553220982fe2c96da2bdc5afb52475b"),
                    Tuple.Create(
                            @"https://github.com/kenwheeler/slick.git",
                            @"027e8fe6320d2031303acfdbb3b8531d61743093"),
                    Tuple.Create(
                            @"https://github.com/carhartl/jquery-cookie.git",
                            @"9481ec9eb649e10cd8650d58c0170a36b2da10e7"),
                    Tuple.Create(
                            @"https://github.com/FredrikNoren/ungit.git",
                            @"91c2681cfd9816db2973a06fd5b1c1f81f4f5746"),
                    Tuple.Create(
                            @"https://github.com/Widen/fine-uploader.git",
                            @"55166f33438e4915045f17d8c4e1adea008af19b"),
                    Tuple.Create(
                            @"https://github.com/marionettejs/backbone.marionette.git",
                            @"84e735d7d7cf85957fe08caebcd086cf7ee11e42"),
                    Tuple.Create(
                            @"https://github.com/lodash/lodash.git",
                            @"7384c42d7a7e63804fd8503cecbc26c13c25eb2a"),
                    Tuple.Create(
                            @"https://github.com/LearnBoost/mongoose.git",
                            @"f243bc9453a3c43cd00f89d0df0f7feb097f3668"),
                    Tuple.Create(
                            @"https://github.com/scottjehl/picturefill.git",
                            @"bc7b1250a2d7795210f9f1f4650de61ceb117d0f"),
                    Tuple.Create(
                            @"https://github.com/angular/angular-seed.git",
                            @"d38e34855b4bda3efaeed63a81844ef94331e3b2"),
                    Tuple.Create(
                            @"https://github.com/mikeal/request.git",
                            @"6a4fd9ad6f57ba27a24f7cea01d0c702f7f5fefa"),
                    Tuple.Create(
                            @"https://github.com/javve/list.js.git",
                            @"9754c28262b07e647e0ad3de181cdb4e323e7db7"),
                    Tuple.Create(
                            @"https://github.com/rstacruz/jquery.transit.git",
                            @"857c438ed80120f20052edd78872175bff4343dc"),
                    Tuple.Create(
                            @"https://github.com/hakimel/Ladda.git",
                            @"5ec83261fbd2fd2613ec8efe83c90996ac289e7c"),
                    Tuple.Create(
                            @"https://github.com/marijnh/CodeMirror.git",
                            @"8a6778baf496da5c80fe785304fdd0e3d5ec8adb"),
                    Tuple.Create(
                            @"https://github.com/Kicksend/mailcheck.git",
                            @"5ff8678cc4b7ec36c4442ccc6213910aa734f4d7"),
                    Tuple.Create(
                            @"https://github.com/HPNeo/gmaps.git",
                            @"edbb7362d6fd050a38bded00a7396a760d3f556a"),
                    Tuple.Create(
                            @"https://github.com/desandro/isotope.git",
                            @"829eaeadc6434e4d313b627ccff4e74c759a1051"),
                    Tuple.Create(
                            @"https://github.com/senchalabs/connect.git",
                            @"bed911ebb94c7c682fe6a72ae6414eed69301c34"),
                    Tuple.Create(
                            @"https://github.com/LearnBoost/stylus.git",
                            @"44fa9ddc6a1e55d8f0b3cec382291619b6ac33c3"),
                    Tuple.Create(
                            @"https://github.com/backbone-boilerplate/backbone-boilerplate.git",
                            @"c698a5482b2ee7369d4972bfa3faed8f8709ea1b"),
                    Tuple.Create(
                            @"https://github.com/jakiestfu/Snap.js.git",
                            @"8538051df8e2c82a39d2603b6dfd8219ce8f04e6"),
                    Tuple.Create(
                            @"https://github.com/eternicode/bootstrap-datepicker.git",
                            @"8bc254a136110369684dc05a48171682ff1f3a81"),
                    Tuple.Create(
                            @"https://github.com/nodejitsu/forever.git",
                            @"09d8403bcde961afadd8dba3daecab47ad213989"),
                    Tuple.Create(
                            @"https://github.com/marmelab/gremlins.js.git",
                            @"06d1d0f9abffdad9d72f31d2d3337e7d1a567de2"),
                    Tuple.Create(
                            @"https://github.com/sindresorhus/pageres.git",
                            @"2213ebcecd8e5cff45bc5691113ad8c6069fac36"),
                    Tuple.Create(
                            @"https://github.com/Polymer/polymer.git",
                            @"ebae29364a9462c5ba5f89a1a689c9c280d54904"),
                    Tuple.Create(
                            @"https://github.com/amsul/pickadate.js.git",
                            @"18c62b215be96fb72fb6bbb3b84ee3e789dd48e1"),
                    Tuple.Create(
                            @"https://github.com/madrobby/keymaster.git",
                            @"21e3785a1c3509161c4d812d42d1f9a604b82825"),
                    Tuple.Create(
                            @"https://github.com/stubbornella/oocss.git",
                            @"0c146a17e13d7b9d5797ffbf2805ce482cbddd9b"),
                    Tuple.Create(
                            @"https://github.com/VerbalExpressions/JSVerbalExpressions.git",
                            @"db1cb79cf0d6c2dd7f5f4dc1b3c4a961052dcf3c"),
                    Tuple.Create(
                            @"https://github.com/linnovate/mean.git",
                            @"5a0c1693c58fb436541015c12603306294afe60e"),
                    Tuple.Create(
                            @"https://github.com/imakewebthings/deck.js.git",
                            @"63b55fea6b92d442e20fb64446783d9f2ac7c85b"),
                    Tuple.Create(
                            @"https://github.com/getify/You-Dont-Know-JS.git",
                            @"6cc6fc3c318372dc63f24c3d13e7f2063cff3b03"),
                    Tuple.Create(
                            @"https://github.com/davatron5000/FitText.js.git",
                            @"1eb8a337ab9999166ae1b328f46cda60a13b4aab"),
                    Tuple.Create(
                            @"https://github.com/dimsemenov/Magnific-Popup.git",
                            @"3a35b057de57535db87826886acb91c15ddfa384"),
                    Tuple.Create(
                            @"https://github.com/thebird/Swipe.git",
                            @"32c19c95ea09092167cd07cc783da24f79f5adf6"),
                    Tuple.Create(
                            @"https://github.com/aFarkas/html5shiv.git",
                            @"3013608075d82c4eaea0d6eeb5af0273f63e4938"),
                    Tuple.Create(
                            @"https://github.com/jzaefferer/jquery-validation.git",
                            @"13d56eb009d2b3d767e1de6d8926f337c41e6c3f"),
                    Tuple.Create(
                            @"https://github.com/paperjs/paper.js.git",
                            @"9ccba17fbefa5a29a3ac359ad3d822caee6e98ff"),
                    Tuple.Create(
                            @"https://github.com/briangonzalez/jquery.adaptive-backgrounds.js.git",
                            @"cfe1ec04167ae8c341e0404f62d94063c1112bd9"),
                    Tuple.Create(
                            @"https://github.com/tommoor/tinycon.git",
                            @"0c860eecb63386ace9df16cbfc7897da3c664b84"),
                    Tuple.Create(
                            @"https://github.com/jschr/bootstrap-modal.git",
                            @"47cb49a43fcf6e2c4cea40b9a65ac6595b3cc06b"),
                    Tuple.Create(
                            @"https://github.com/ducksboard/gridster.js.git",
                            @"a4f3baf38ffdffdc8b7cccd55a8f2667a593adf7"),
                    Tuple.Create(
                            @"https://github.com/imakewebthings/jquery-waypoints.git",
                            @"6c7d129433343d04feca94310f117a966dab4721"),
                    Tuple.Create(
                            @"https://github.com/mozilla/BrowserQuest.git",
                            @"af32d247cac3495ca430d0effbb88dd5f3250b2c"),
                    Tuple.Create(
                            @"https://github.com/fabien-d/alertify.js.git",
                            @"8492f15459efed9e5cbdeeaa879fa5796ce78170"),
                    Tuple.Create(
                            @"https://github.com/WickyNilliams/headroom.js.git",
                            @"1778e521e9978e17b2f0f826f72fd2e0b61c21a7"),
                    Tuple.Create(
                            @"https://github.com/jacomyal/sigma.js.git",
                            @"7bd4b61f4f892c3531582436cd3213a2a8ef6b52"),
                    Tuple.Create(
                            @"https://github.com/ether/etherpad-lite.git",
                            @"962b166c3aa54889652db4d19c74fa6a25ec1b53"),
                    Tuple.Create(
                            @"https://github.com/jhollingworth/bootstrap-wysihtml5.git",
                            @"283bb8f859977ac1aafb09bee715a1190f8cfd1b"),
                    Tuple.Create(
                            @"https://github.com/mindmup/bootstrap-wysiwyg.git",
                            @"9304f95917d603d813a9a9fd2670a586e5d74cde"),
                    Tuple.Create(
                            @"https://github.com/maroslaw/rainyday.js.git",
                            @"ddd1a085f489e15165c69923fa50fa4e636b9de2"),
                    Tuple.Create(
                            @"https://github.com/adam-p/markdown-here.git",
                            @"6f5222e45129db32838edd7e6e5c241d391f9de0"),
                    Tuple.Create(
                            @"https://github.com/GitbookIO/gitbook.git",
                            @"f43e630528be43d5aec4e6f923b0f53107f93546"),
                    Tuple.Create(
                            @"https://github.com/chjj/marked.git",
                            @"dc3b344e82a0548c2faf290135d9447c06bd2574"),
                    Tuple.Create(
                            @"https://github.com/aterrien/jQuery-Knob.git",
                            @"1a6d5811fbf4f0d5508718a1d03e2cdb34cb6ed2"),
                    Tuple.Create(
                            @"https://github.com/h5bp/mobile-boilerplate.git",
                            @"36661edc9092730346f66fe0d7785712604ffc41"),
                    Tuple.Create(
                            @"https://github.com/CreateJS/EaselJS.git",
                            @"0374f486f0824b6da518b3a73faf084032596e81"),
                    Tuple.Create(
                            @"https://github.com/flot/flot.git",
                            @"3aec7ce0bd975e452ff49107905a06146fe9e560"),
                    Tuple.Create(
                            @"https://github.com/felixge/node-mysql.git",
                            @"f37cf8d0ba86edf712183940a9a9a05d3517d4ae"),
                    Tuple.Create(
                            @"https://github.com/jackmoore/colorbox.git",
                            @"f0a70f32221355c73a3a7c7dd85a0b9ec9011d47"),
                    Tuple.Create(
                            @"https://github.com/headjs/headjs.git",
                            @"edc8427191a633d80e7372c49e6d28a098be766f"),
                    Tuple.Create(
                            @"https://github.com/alvarotrigo/fullPage.js.git",
                            @"9c149a3b43fd5450f2cc6d0dc7cd7bc5b6edd01e"),
                    Tuple.Create(
                            @"https://github.com/twitter/hogan.js.git",
                            @"b1328c06eedf316bbe4c54b189ecb47cff7ac2ed"),
                    Tuple.Create(
                            @"https://github.com/square/crossfilter.git",
                            @"6c84abd3d22cfd1594ce846b5d5edcec15a317a5"),
                    Tuple.Create(
                            @"https://github.com/madebymany/sir-trevor-js.git",
                            @"9be4a0694d854d7c5354d06a83ce6e3b86eae4f8"),
                    Tuple.Create(
                            @"https://github.com/mgcrea/angular-strap.git",
                            @"a3ff0667f4897b210c70f350f9a994c6cd391747"),
                    Tuple.Create(
                            @"https://github.com/codeparty/derby.git",
                            @"a84ba83f2fc0daf089c4c2f7de46d84fdbe138ab"),
                    Tuple.Create(
                            @"https://github.com/blasten/turn.js.git",
                            @"08c1f6599a1412b145c7bf645a1f28c14db12742"),
                    Tuple.Create(
                            @"https://github.com/remy/nodemon.git",
                            @"787bebf1ac635c79f0a0d8fc1921ef338f0e1779"),
                    Tuple.Create(
                            @"https://github.com/phonegap/phonegap-start.git",
                            @"62fae0a8bd18ce15adf1e9485c819f79e9994663"),
                    Tuple.Create(
                            @"https://github.com/remy/html5demos.git",
                            @"0e4aff9432c3e34f3ef8b3726461e9dfd1bd43ea"),
                    Tuple.Create(
                            @"https://github.com/niklasvh/html2canvas.git",
                            @"454524cc4041cf6eef3df76f87cfef4a0e9e7c09"),
                };
                foreach (var exp in exps) {
                    foreach (var learningSet in learningSets) {
                        var url = learningSet.Item1;
                        var path = Fixture.GetGitRepositoryPath(url);
                        Git.CloneAndCheckout(path, url, learningSet.Item2);
                        yield return new TestCaseData(exp, path);
                    }
                }
            }
        }

        //[Test, TestCaseSource("TestCases")]
        public void Test(LearningExperiment exp, string projectPath) {
            var seedPaths = new List<string> { Fixture.GetInputCodePath(LangName, "seed.js"), };
            var allPaths = Directory.GetFiles(projectPath, "*.js", SearchOption.AllDirectories)
                    .ToList();
            exp.Learn(allPaths, seedPaths, _writer, projectPath);
            exp.Clear();
            Assert.That(exp.WrongFeatureCount, Is.EqualTo(0));
        }
    }

    public class JavaScriptSuperComplexBranchExperiment : LearningExperiment {
        public JavaScriptSuperComplexBranchExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return true;
            }
            if (parentName == "whileStatement") {
                return true;
            }
            if (parentName == "doWhileStatement") {
                return true;
            }
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            var p = e.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Element("arguments").Element("assignmentExpression") == e) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptComplexBranchExperiment : LearningExperiment {
        public JavaScriptComplexBranchExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return true;
            }
            if (parentName == "whileStatement") {
                return true;
            }
            if (parentName == "doWhileStatement") {
                return true;
            }
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptIfExperiment : LearningExperiment {
        public JavaScriptIfExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "ifStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptWhileExperiment : LearningExperiment {
        public JavaScriptWhileExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "whileStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptDoWhileExperiment : LearningExperiment {
        public JavaScriptDoWhileExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "doWhileStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptForExperiment : LearningExperiment {
        public JavaScriptForExperiment() : base("expression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var parentName = e.Parent.SafeName();
            if (parentName == "forStatement"
                && e.Prev == e.Parent.Elements().First(e2 => e2.TokenText == ";")) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptConsoleLogExperiment : LearningExperiment {
        public JavaScriptConsoleLogExperiment() : base("assignmentExpression") {}

        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return false; }
        }

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            var p = e.SafeParent().SafeParent();
            if (p.SafeName() == "callExpression" && p.FirstChild.TokenText == "console.log" &&
                p.Element("arguments").Element("assignmentExpression") == e) {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        public JavaScriptStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            return true;
        }
    }

    public class JavaScriptComplexStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        public JavaScriptComplexStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "statementBlock") {
                return false;
            }
            if (e.FirstChild.Name == "labelledStatement") {
                return false;
            }
            if (e.FirstChild.Name == "emptyStatement") {
                return false;
            }
            return true;
        }
    }

    public class JavaScriptBlockExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        public JavaScriptBlockExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "statementBlock") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptLabeledStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        public JavaScriptLabeledStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "labelledStatement") {
                return true;
            }
            return false;
        }
    }

    public class JavaScriptEmptyStatementExperiment : LearningExperiment {
        protected override CstGenerator Generator {
            get { return JavaScriptExperiment.Generator; }
        }

        protected override bool IsInner {
            get { return true; }
        }

        public JavaScriptEmptyStatementExperiment() : base("statement") {}

        protected override bool ProtectedIsAcceptedUsingOracle(CstNode e) {
            if (e.FirstChild.Name == "emptyStatement") {
                return true;
            }
            return false;
        }
    }
}