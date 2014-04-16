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
using Code2Xml.Languages.ANTLRv3.Generators.JavaScript;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
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
        [TestCase(@"https://github.com/jquery/jquery.git",
                @"99d735ab4662f45c3b65ea1200fa0d3e2b671111", 30340)]
        [TestCase(@"https://github.com/joyent/node.git",
                @"940974ed039d3c9a8befe608d9c95b2ffdb457d3", 28954)]
        [TestCase(@"https://github.com/mbostock/d3.git",
                @"49ba8afebb2ae813ab66dc2f48f533aa7f333c3c", 24562)]
        [TestCase(@"https://github.com/angular/angular.js.git",
                @"b10a4371a6592ea1c54b5b9eb401842af7f63c90", 22642)]
        [TestCase(@"https://github.com/bartaz/impress.js.git",
                @"d505df4e4ed20f91b589893cba306fe693ab17d3", 19873)]
        [TestCase(@"https://github.com/jashkenas/backbone.git",
                @"285e07b6b3d6241966866d0662595ac9611c0f61", 17626)]
        [TestCase(@"https://github.com/blueimp/jQuery-File-Upload.git",
                @"8dc29ded32a0f2caad86ebbdf8b23a22375ae78c", 15847)]
        [TestCase(@"https://github.com/adobe/brackets.git",
                @"23f4531238fcefed98885d5cc1b3c8401b1ac4fd", 15494)]
        [TestCase(@"https://github.com/moment/moment.git",
                @"a05fec84f049fcc4ad81e2c220f430a708458b8a", 15315)]
        [TestCase(@"https://github.com/mrdoob/three.js.git",
                @"4d690145512178c97d4307aecf132b636c5c22ce", 14871)]
        [TestCase(@"https://github.com/hakimel/reveal.js.git",
                @"9da952fea30906090446d038430186b11dba7f13", 14663)]
        [TestCase(@"https://github.com/visionmedia/express.git",
                @"e1ab302234d82390f280ecfb478994cdff8809b6", 13362)]
        [TestCase(@"https://github.com/meteor/meteor.git",
                @"e7a85a39b6803c72a3241f6b6aa455d42eb09f6f", 12130)]
        [TestCase(@"https://github.com/Modernizr/Modernizr.git",
                @"d3043c26388532386b682faf038d3ddba21e27ae", 11846)]
        [TestCase(@"https://github.com/LearnBoost/socket.io.git",
                @"94905500e492d8128e17a355ebf9885bbc4bf93b", 11351)]
        [TestCase(@"https://github.com/jashkenas/underscore.git",
                @"955b57335ab2b458a33465b380c322d2880aa92c", 11037)]
        [TestCase(@"https://github.com/ivaynberg/select2.git",
                @"100266bbb5a16eaefaa45e23de69e1e06464f97a", 10332)]
        [TestCase(@"https://github.com/less/less.js.git",
                @"d6d983f727f6f8342c4d439c784ab90c3c7fea0d", 10283)]
        [TestCase(@"https://github.com/TryGhost/Ghost.git",
                @"0806c3188e202bd15011684332d69848161840f3", 9982)]
        [TestCase(@"https://github.com/emberjs/ember.js.git",
                @"efd72af4ca25f246f241bcf5efd736a17c5ba87c", 9867)]
        [TestCase(@"https://github.com/resume/resume.github.com.git",
                @"c537d43f3eeb259578f4a0501cb5c0014edd3b72", 9746)]
        [TestCase(@"https://github.com/bower/bower.git",
                @"03f035cdf03ce027892a46d8e0f731dc9b950561", 9334)]
        [TestCase(@"https://github.com/defunkt/jquery-pjax.git",
                @"67fbdced9825864a7949c3103c4d90cf6a8b1e29", 9059)]
        [TestCase(@"https://github.com/tastejs/todomvc.git",
                @"35fe24713c3ed08ab8bcafcf16a58c4334713ca7", 9037)]
        [TestCase(@"https://github.com/jquery/jquery-mobile.git",
                @"1f95855f47bf0b4302b1749dda88a4d64b1345bf", 9031)]
        [TestCase(@"https://github.com/caolan/async.git",
                @"931d15412c5081e35f96dee3cc7a98d8322e7b17", 8311)]
        [TestCase(@"https://github.com/jquery/jquery-ui.git",
                @"919d9185f2cf586f794b367a2570368fd81f3879", 8249)]
        [TestCase(@"https://github.com/Prinzhorn/skrollr.git",
                @"a08d11500a50d22cfca549864e9a486c17b29c90", 8238)]
        [TestCase(@"https://github.com/mozilla/pdf.js.git",
                @"1b636532d680d269069ca976b02a053392ab5ab2", 8126)]
        [TestCase(@"https://github.com/addyosmani/backbone-fundamentals.git",
                @"7372900a65b6942d234f69f1ed982f094ff5b0bf", 7748)]
        [TestCase(@"https://github.com/gruntjs/grunt.git",
                @"4ae8a07d3854f5affd3002d3395725dc25648ee3", 7721)]
        [TestCase(@"https://github.com/nnnick/Chart.js.git",
                @"8f025f33c08c66991a12f02f908bab156a963aef", 7660)]
        [TestCase(@"https://github.com/Semantic-Org/Semantic-UI.git",
                @"14d97f7336efde50efddf0ddee7ebd42734afb40", 7656)]
        [TestCase(@"https://github.com/ajaxorg/ace.git",
                @"993df16bdb4cf80dac13f0fe8f449bb7adb05a65", 7636)]
        [TestCase(@"https://github.com/EightMedia/hammer.js.git",
                @"b9e3ecec174c7ae217489dc3a24540a64243692e", 7444)]
        [TestCase(@"https://github.com/Leaflet/Leaflet.git",
                @"c5091eefdaa88c5d924c364312f50bf5ab7ba5a5", 7297)]
        [TestCase(@"https://github.com/twitter/typeahead.js.git",
                @"0caa797de2bee9c7f06af08cb5579f8cdfb6a7b9", 7087)]
        [TestCase(@"https://github.com/rwaldron/idiomatic.js.git",
                @"4b2938bd2e2ca3251367572e3613a7a2935aba53", 6831)]
        [TestCase(@"https://github.com/usablica/intro.js.git",
                @"10fab7d91f0ea28e61f32812abb70112ffb3d624", 6827)]
        [TestCase(@"https://github.com/rstacruz/nprogress.git",
                @"4c3af762a7576632a0ca2718a53a17bdeb45efe8", 6789)]
        [TestCase(@"https://github.com/scottjehl/Respond.git",
                @"3fde2627484f8cb38e2bd4dbf2374cf41184b0f4", 6766)]
        [TestCase(@"https://github.com/pivotal/jasmine.git",
                @"00c8e372576438243a8f977b8bc7b81f04389dd6", 6653)]
        [TestCase(@"https://github.com/madrobby/zepto.git",
                @"579c0971f4b21ebb25831278a7012fa76494d5cc", 6550)]
        [TestCase(@"https://github.com/Shopify/dashing.git",
                @"ff3acd8074e57edba29bf731d3d0a8b6761f97ca", 6383)]
        [TestCase(@"https://github.com/visionmedia/jade.git",
                @"aa1f1f059b4ca858811c66b6d8b817ff9f41009f", 6340)]
        [TestCase(@"https://github.com/browserstate/history.js.git",
                @"14968aa3cf2a27335f71d26386de0a5c4073835d", 6285)]
        [TestCase(@"https://github.com/janl/mustache.js.git",
                @"0295646b677b8c9e15527e8b63583ed6728b77d0", 6260)]
        [TestCase(@"https://github.com/ftlabs/fastclick.git",
                @"3497d2e92ccc8a959c7efb326c0fc437302d5bcf", 6250)]
        [TestCase(@"https://github.com/wycats/handlebars.js.git",
                @"085e5e1937b442a4d4add5525db2627e825538aa", 6222)]
        [TestCase(@"https://github.com/NUKnightLab/TimelineJS.git",
                @"cede826f6212af83361ecd571481b5bb95f7a610", 6175)]
        [TestCase(@"https://github.com/DmitryBaranovskiy/raphael.git",
                @"5234aa33d04be07b0fea7627504ab4b53d872e19", 6165)]
        [TestCase(@"https://github.com/fgnass/spin.js.git",
                @"cdf391a8e41b6ad8f902dc9a10cae80486d472ef", 6062)]
        [TestCase(@"https://github.com/wagerfield/parallax.git",
                @"a42beb93b7cdcb9dbfdb0e96e5eafd5232b86ba2", 6060)]
        [TestCase(@"https://github.com/desandro/masonry.git",
                @"b9df286dc6a3004b8a7f90599c7ba79d09e8ce2e", 5871)]
        [TestCase(@"https://github.com/balderdashy/sails.git",
                @"6adfdf85eebdc6e001bacdc5098a58a1cd93aa38", 5852)]
        [TestCase(@"https://github.com/xing/wysihtml5.git",
                @"56960b31adc37e07797382d8e8b10109f206b19c", 5823)]
        [TestCase(@"https://github.com/facebook/react.git",
                @"ea361e884e1b6c8458fb64312069e89df0053883", 5638)]
        [TestCase(@"https://github.com/kamens/jQuery-menu-aim.git",
                @"86ac9a0782ebc417b50114c2475f2a4b106cf121", 5615)]
        [TestCase(@"https://github.com/shichuan/javascript-patterns.git",
                @"1a1805763e54c99359d96792e0396b47af649d6c", 5545)]
        [TestCase(@"https://github.com/jrburke/requirejs.git",
                @"f1c533d181da5b759adc7f6297e87d556ef02ce2", 5521)]
        [TestCase(@"https://github.com/gulpjs/gulp.git",
                @"160933474a7d8e566de699dbc6e2f8c4e49c1b5f", 5455)]
        [TestCase(@"https://github.com/etsy/statsd.git",
                @"f95dd0360fdf0e14ef2fe9080611d1b3594b6297", 5423)]
        [TestCase(@"https://github.com/enyo/dropzone.git",
                @"ac87ee44d7219afb091e22db0748e58ca989b466", 5409)]
        [TestCase(@"https://github.com/videojs/video.js.git",
                @"3bafdeef51d9f135de13fe4c51158942031ce6c2", 5242)]
        [TestCase(@"https://github.com/flightjs/flight.git",
                @"4b71426ac4776f09ef6c318f4b01c3fbee31b127", 5185)]
        [TestCase(@"https://github.com/carhartl/jquery-cookie.git",
                @"9481ec9eb649e10cd8650d58c0170a36b2da10e7", 5173)]
        [TestCase(@"https://github.com/peachananr/onepage-scroll.git",
                @"fb65fb933553220982fe2c96da2bdc5afb52475b", 5145)]
        [TestCase(@"https://github.com/kriskowal/q.git",
                @"93c00699f22354973e0bccf800d7f03c9413d0d8", 5049)]
        [TestCase(@"https://github.com/kenwheeler/slick.git",
                @"027e8fe6320d2031303acfdbb3b8531d61743093", 4958)]
        [TestCase(@"https://github.com/FredrikNoren/ungit.git",
                @"91c2681cfd9816db2973a06fd5b1c1f81f4f5746", 4947)]
        [TestCase(@"https://github.com/Widen/fine-uploader.git",
                @"55166f33438e4915045f17d8c4e1adea008af19b", 4901)]
        [TestCase(@"https://github.com/jquery-ui-bootstrap/jquery-ui-bootstrap.git",
                @"439e6662414f4dc7feb2032186d1f2a784f6455d", 4886)]
        [TestCase(@"https://github.com/guillaumepotier/Parsley.js.git",
                @"2f5ebd0422a2c1207738c212563b5da16b2bb032", 4848)]
        [TestCase(@"https://github.com/knockout/knockout.git",
                @"80120969d8cb5341325f76ec1e74dde6e2af00fc", 4846)]
        [TestCase(@"https://github.com/rstacruz/jquery.transit.git",
                @"857c438ed80120f20052edd78872175bff4343dc", 4834)]
        [TestCase(@"https://github.com/mishoo/UglifyJS.git",
                @"2bc1d02363db3798d5df41fb5059a19edca9b7eb", 4810)]
        [TestCase(@"https://github.com/ccampbell/mousetrap.git",
                @"afaaf95f984f2e2a80670b980d421683ac42eed6", 4777)]
        [TestCase(@"https://github.com/marionettejs/backbone.marionette.git",
                @"84e735d7d7cf85957fe08caebcd086cf7ee11e42", 4743)]
        [TestCase(@"https://github.com/lodash/lodash.git",
                @"7384c42d7a7e63804fd8503cecbc26c13c25eb2a", 4723)]
        [TestCase(@"https://github.com/LearnBoost/mongoose.git",
                @"f243bc9453a3c43cd00f89d0df0f7feb097f3668", 4704)]
        [TestCase(@"https://github.com/scottjehl/picturefill.git",
                @"bc7b1250a2d7795210f9f1f4650de61ceb117d0f", 4687)]
        [TestCase(@"https://github.com/ajaxorg/cloud9.git",
                @"5b62a7c83445ccba9f50592d41a7128b1f1fe868", 4681)]
        [TestCase(@"https://github.com/angular/angular-seed.git",
                @"d38e34855b4bda3efaeed63a81844ef94331e3b2", 4668)]
        [TestCase(@"https://github.com/driftyco/ionic.git",
                @"14a2790749f2d65ec6f0c652d5aac7a4a9d72c24", 4663)]
        [TestCase(@"https://github.com/angular-ui/bootstrap.git",
                @"2423f6d4c05cb0eb3fd2104dedbeb0e3740f7f68", 4610)]
        [TestCase(@"https://github.com/Kicksend/mailcheck.git",
                @"5ff8678cc4b7ec36c4442ccc6213910aa734f4d7", 4536)]
        [TestCase(@"https://github.com/javve/list.js.git",
                @"9754c28262b07e647e0ad3de181cdb4e323e7db7", 4533)]
        [TestCase(@"https://github.com/mikeal/request.git",
                @"6a4fd9ad6f57ba27a24f7cea01d0c702f7f5fefa", 4507)]
        [TestCase(@"https://github.com/HPNeo/gmaps.git",
                @"edbb7362d6fd050a38bded00a7396a760d3f556a", 4494)]
        [TestCase(@"https://github.com/hakimel/Ladda.git",
                @"5ec83261fbd2fd2613ec8efe83c90996ac289e7c", 4479)]
        [TestCase(@"https://github.com/marijnh/CodeMirror.git",
                @"8a6778baf496da5c80fe785304fdd0e3d5ec8adb", 4461)]
        [TestCase(@"https://github.com/desandro/isotope.git",
                @"829eaeadc6434e4d313b627ccff4e74c759a1051", 4437)]
        [TestCase(@"https://github.com/gollum/gollum.git",
                @"ff82ddea9740b1ca7206c17af4f55a6250ba3cfd", 4386)]
        [TestCase(@"https://github.com/visionmedia/mocha.git",
                @"638e049cfae48f35493c8b4bf3c5debe5691d751", 4346)]
        [TestCase(@"https://github.com/senchalabs/connect.git",
                @"bed911ebb94c7c682fe6a72ae6414eed69301c34", 4286)]
        [TestCase(@"https://github.com/jakiestfu/Snap.js.git",
                @"8538051df8e2c82a39d2603b6dfd8219ce8f04e6", 4284)]
        [TestCase(@"https://github.com/eternicode/bootstrap-datepicker.git",
                @"8bc254a136110369684dc05a48171682ff1f3a81", 4274)]
        [TestCase(@"https://github.com/marmelab/gremlins.js.git",
                @"06d1d0f9abffdad9d72f31d2d3337e7d1a567de2", 4273)]
        [TestCase(@"https://github.com/node-inspector/node-inspector.git",
                @"a7c4fa23a46af15cf265ec4662f6340ccb40f337", 4260)]
        [TestCase(@"https://github.com/substack/node-browserify.git",
                @"2bfdd64ef45e5c1760fe8fa90e2c80033a238d12", 4246)]
        [TestCase(@"https://github.com/backbone-boilerplate/backbone-boilerplate.git",
                @"c698a5482b2ee7369d4972bfa3faed8f8709ea1b", 4212)]
        [TestCase(@"https://github.com/shutterstock/rickshaw.git",
                @"71877d994a81d39a003e3638b751ac5e6d6c87c6", 4205)]
        [TestCase(@"https://github.com/douglascrockford/JSON-js.git",
                @"3d7767b6b1f3da363c625ff54e63bbf20e9e83ac", 4198)]
        [TestCase(@"https://github.com/LearnBoost/stylus.git",
                @"44fa9ddc6a1e55d8f0b3cec382291619b6ac33c3", 4187)]
        [TestCase(@"https://github.com/davatron5000/FitText.js.git",
                @"1eb8a337ab9999166ae1b328f46cda60a13b4aab", 4148)]
        [TestCase(@"https://github.com/npm/npm.git",
                @"6be6b4b74e5fd256a1bdfa098ea6541c62b30928", 4134)]
        [TestCase(@"https://github.com/nodejitsu/forever.git",
                @"09d8403bcde961afadd8dba3daecab47ad213989", 4132)]
        [TestCase(@"https://github.com/mozilla/togetherjs.git",
                @"aabd258007828fc7ec3949fbd82374eb03061bce", 4119)]
        [TestCase(@"https://github.com/mleibman/SlickGrid.git",
                @"33e75b07bfd769349525dc084d987c406fc03e24", 4068)]
        [TestCase(@"https://github.com/stubbornella/oocss.git",
                @"0c146a17e13d7b9d5797ffbf2805ce482cbddd9b", 4062)]
        [TestCase(@"https://github.com/GoodBoyDigital/pixi.js.git",
                @"d90b75755a88a355b61c64a64f127214165ee4f5", 4059)]
        [TestCase(@"https://github.com/dimsemenov/Magnific-Popup.git",
                @"3a35b057de57535db87826886acb91c15ddfa384", 4058)]
        [TestCase(@"https://github.com/unconed/TermKit.git",
                @"2d368b849d6185df661bf89f742455875c00da2a", 4053)]
        [TestCase(@"https://github.com/sindresorhus/pageres.git",
                @"2213ebcecd8e5cff45bc5691113ad8c6069fac36", 4046)]
        [TestCase(@"https://github.com/imakewebthings/deck.js.git",
                @"63b55fea6b92d442e20fb64446783d9f2ac7c85b", 4020)]
        [TestCase(@"https://github.com/VerbalExpressions/JSVerbalExpressions.git",
                @"db1cb79cf0d6c2dd7f5f4dc1b3c4a961052dcf3c", 4006)]
        [TestCase(@"https://github.com/madrobby/keymaster.git",
                @"21e3785a1c3509161c4d812d42d1f9a604b82825", 3991)]
        [TestCase(@"https://github.com/Polymer/polymer.git",
                @"ebae29364a9462c5ba5f89a1a689c9c280d54904", 3965)]
        [TestCase(@"https://github.com/photonstorm/phaser.git",
                @"4c31623e6e89e1f68ad910cb026a9d86f50287e3", 3950)]
        [TestCase(@"https://github.com/briangonzalez/jquery.adaptive-backgrounds.js.git",
                @"cfe1ec04167ae8c341e0404f62d94063c1112bd9", 3945)]
        [TestCase(@"https://github.com/amsul/pickadate.js.git",
                @"18c62b215be96fb72fb6bbb3b84ee3e789dd48e1", 3943)]
        [TestCase(@"https://github.com/adobe-webplatform/Snap.svg.git",
                @"f94872941f4f833e2f1feb88c2ef1c43d83a88b4", 3919)]
        [TestCase(@"https://github.com/linnovate/mean.git",
                @"5a0c1693c58fb436541015c12603306294afe60e", 3897)]
        [TestCase(@"https://github.com/getify/You-Dont-Know-JS.git",
                @"6cc6fc3c318372dc63f24c3d13e7f2063cff3b03", 3869)]
        [TestCase(@"https://github.com/aFarkas/html5shiv.git",
                @"3013608075d82c4eaea0d6eeb5af0273f63e4938", 3842)]
        [TestCase(@"https://github.com/thebird/Swipe.git",
                @"32c19c95ea09092167cd07cc783da24f79f5adf6", 3821)]
        [TestCase(@"https://github.com/cubiq/iscroll.git",
                @"44d992bcaf1b6bb3eb69c43b9776247b0ab062ff", 3798)]
        [TestCase(@"https://github.com/jzaefferer/jquery-validation.git",
                @"13d56eb009d2b3d767e1de6d8926f337c41e6c3f", 3790)]
        [TestCase(@"https://github.com/mozilla/BrowserQuest.git",
                @"af32d247cac3495ca430d0effbb88dd5f3250b2c", 3763)]
        [TestCase(@"https://github.com/imakewebthings/jquery-waypoints.git",
                @"6c7d129433343d04feca94310f117a966dab4721", 3749)]
        [TestCase(@"https://github.com/paperjs/paper.js.git",
                @"9ccba17fbefa5a29a3ac359ad3d822caee6e98ff", 3730)]
        [TestCase(@"https://github.com/ducksboard/gridster.js.git",
                @"a4f3baf38ffdffdc8b7cccd55a8f2667a593adf7", 3725)]
        [TestCase(@"https://github.com/jschr/bootstrap-modal.git",
                @"47cb49a43fcf6e2c4cea40b9a65ac6595b3cc06b", 3679)]
        [TestCase(@"https://github.com/mindmup/bootstrap-wysiwyg.git",
                @"9304f95917d603d813a9a9fd2670a586e5d74cde", 3647)]
        [TestCase(@"https://github.com/tommoor/tinycon.git",
                @"0c860eecb63386ace9df16cbfc7897da3c664b84", 3629)]
        [TestCase(@"https://github.com/WickyNilliams/headroom.js.git",
                @"1778e521e9978e17b2f0f826f72fd2e0b61c21a7", 3624)]
        [TestCase(@"https://github.com/fabien-d/alertify.js.git",
                @"8492f15459efed9e5cbdeeaa879fa5796ce78170", 3598)]
        [TestCase(@"https://github.com/jhollingworth/bootstrap-wysihtml5.git",
                @"283bb8f859977ac1aafb09bee715a1190f8cfd1b", 3592)]
        [TestCase(@"https://github.com/adam-p/markdown-here.git",
                @"6f5222e45129db32838edd7e6e5c241d391f9de0", 3509)]
        [TestCase(@"https://github.com/koajs/koa.git",
                @"430246c114e2782bcb0a2bb69842fbd78b0fcbab", 3501)]
        [TestCase(@"https://github.com/aterrien/jQuery-Knob.git",
                @"1a6d5811fbf4f0d5508718a1d03e2cdb34cb6ed2", 3488)]
        [TestCase(@"https://github.com/ExactTarget/fuelux.git",
                @"ebc519903c35356eaaa7c04f1dcad3e469cda0fc", 3480)]
        [TestCase(@"https://github.com/jacomyal/sigma.js.git",
                @"7bd4b61f4f892c3531582436cd3213a2a8ef6b52", 3472)]
        [TestCase(@"https://github.com/ether/etherpad-lite.git",
                @"962b166c3aa54889652db4d19c74fa6a25ec1b53", 3464)]
        [TestCase(@"https://github.com/maroslaw/rainyday.js.git",
                @"ddd1a085f489e15165c69923fa50fa4e636b9de2", 3451)]
        [TestCase(@"https://github.com/chjj/marked.git",
                @"dc3b344e82a0548c2faf290135d9447c06bd2574", 3436)]
        [TestCase(@"https://github.com/square/crossfilter.git",
                @"6c84abd3d22cfd1594ce846b5d5edcec15a317a5", 3436)]
        [TestCase(@"https://github.com/OscarGodson/EpicEditor.git",
                @"628020033d28f0d64fe8a3cf1e6e5ca441cbb3fc", 3436)]
        [TestCase(@"https://github.com/GitbookIO/gitbook.git",
                @"f43e630528be43d5aec4e6f923b0f53107f93546", 3413)]
        [TestCase(@"https://github.com/brianreavis/selectize.js.git",
                @"d6a6f53625f5d9c4de9337978e05b80136983990", 3411)]
        [TestCase(@"https://github.com/jaredhanson/passport.git",
                @"298d2452430dd0d1841d417e9c0d0b23e4b06239", 3380)]
        [TestCase(@"https://github.com/h5bp/mobile-boilerplate.git",
                @"36661edc9092730346f66fe0d7785712604ffc41", 3376)]
        [TestCase(@"https://github.com/headjs/headjs.git",
                @"edc8427191a633d80e7372c49e6d28a098be766f", 3351)]
        [TestCase(@"https://github.com/twitter/hogan.js.git",
                @"b1328c06eedf316bbe4c54b189ecb47cff7ac2ed", 3338)]
        [TestCase(@"https://github.com/CreateJS/EaselJS.git",
                @"0374f486f0824b6da518b3a73faf084032596e81", 3316)]
        [TestCase(@"https://github.com/paulasmuth/fnordmetric.git",
                @"d402c92fe6c880da28a27d3a5fa441965f55bd3d", 3310)]
        [TestCase(@"https://github.com/blasten/turn.js.git",
                @"08c1f6599a1412b145c7bf645a1f28c14db12742", 3303)]
        [TestCase(@"https://github.com/alvarotrigo/fullPage.js.git",
                @"9c149a3b43fd5450f2cc6d0dc7cd7bc5b6edd01e", 3279)]
        [TestCase(@"https://github.com/felixge/node-mysql.git",
                @"f37cf8d0ba86edf712183940a9a9a05d3517d4ae", 3275)]
        [TestCase(@"https://github.com/flot/flot.git",
                @"3aec7ce0bd975e452ff49107905a06146fe9e560", 3268)]
        [TestCase(@"https://github.com/jackmoore/colorbox.git",
                @"f0a70f32221355c73a3a7c7dd85a0b9ec9011d47", 3257)]
        [TestCase(@"https://github.com/vitalets/x-editable.git",
                @"f32802f48a33b8a7ec9cca32eec4ca844b7d39b2", 3250)]
        [TestCase(@"https://github.com/remy/html5demos.git",
                @"0e4aff9432c3e34f3ef8b3726461e9dfd1bd43ea", 3247)]
        [TestCase(@"https://github.com/mgcrea/angular-strap.git",
                @"a3ff0667f4897b210c70f350f9a994c6cd391747", 3224)]
        [TestCase(@"https://github.com/jshint/jshint.git",
                @"20e2bee28242fa627e3a98087dda8713850941a9", 3187)]
        [TestCase(@"https://github.com/square/cube.git",
                @"084bebe6839ffbd442010427f017e38e0fe0bef7", 3183)]
        [TestCase(@"https://github.com/madebymany/sir-trevor-js.git",
                @"9be4a0694d854d7c5354d06a83ce6e3b86eae4f8", 3176)]
        [TestCase(@"https://github.com/benweet/stackedit.git",
                @"1d7308ebaa09679e96126345a4818bdd24d96f2f", 3164)]
        [TestCase(@"https://github.com/codeparty/derby.git",
                @"a84ba83f2fc0daf089c4c2f7de46d84fdbe138ab", 3144)]
        [TestCase(@"https://github.com/Unitech/pm2.git",
                @"3a7932325d1f41f5fb08c949be64b885f47b7a51", 3130)]
        [TestCase(@"https://github.com/remy/nodemon.git",
                @"787bebf1ac635c79f0a0d8fc1921ef338f0e1779", 3126)]
        [TestCase(@"https://github.com/phonegap/phonegap-start.git",
                @"62fae0a8bd18ce15adf1e9485c819f79e9994663", 3119)]
        [TestCase(@"https://github.com/niklasvh/html2canvas.git",
                @"454524cc4041cf6eef3df76f87cfef4a0e9e7c09", 3112)]
        [TestCase(@"https://github.com/jimhigson/oboe.js.git",
                @"6b1ec90658ece4d19a9567a5e7786396391e4570", 3095)]
        [TestCase(@"https://github.com/NetEase/pomelo.git",
                @"a077c4044dfa0e086b552e234e545353cb18d436", 3090)]
        [TestCase(@"https://github.com/square/cubism.git",
                @"7181f11f54eda094abac15d14c7c6a3a11633d3e", 3082)]
        [TestCase(@"https://github.com/dieulot/instantclick.git",
                @"a92fd5c9d9f10929e1a482c4b07bf72b5fc1acf5", 3077)]
        [TestCase(@"https://github.com/Diogenesthecynic/FullScreenMario.git",
                @"cbd53d0f504ed6bc0d69180d1188faebf1960d6f", 3073)]
        [TestCase(@"https://github.com/jquery/sizzle.git",
                @"bd428012b95c333f39685a0abb4e94e7f108c813", 3067)]
        [TestCase(@"https://github.com/imsky/holder.git",
                @"1a299d6bb214f15b44577785cfeaf6ee7593e516", 3048)]
        [TestCase(@"https://github.com/mgonto/restangular.git",
                @"8e65e1c8e6307e23cae1540415003023bc07bece", 3044)]
        [TestCase(@"https://github.com/needim/noty.git",
                @"942473303dfa0b296d9aa316fa0a111e0cab1b4d", 3043)]
        [TestCase(@"https://github.com/component/component.git",
                @"fe2aae08eebee54fe80ed4b458232d2f7d8fa6bc", 3042)]
        [TestCase(@"https://github.com/segmentio/myth.git",
                @"e22b58562c6285a38d95b7fa5d3afc8a52764c8a", 2986)]
        [TestCase(@"https://github.com/angular-app/angular-app.git",
                @"9b11c05eae688903b8ed797fd09bb2ac13cc3d52", 2984)]
        [TestCase(@"https://github.com/kenkeiter/skeuocard.git",
                @"2d3067e4c19e90ad9dc1d3e6de72e007e8f8417e", 2969)]
        [TestCase(@"https://github.com/daviferreira/medium-editor.git",
                @"73938c780eca8ee8eaf662159b7f80ded9faa68a", 2958)]
        [TestCase(@"https://github.com/n1k0/casperjs.git",
                @"ff12c243ee66e674a8fccf534916142a004b0921", 2957)]
        [TestCase(@"https://github.com/BBC-News/Imager.js.git",
                @"ef6d6a5ec3c506ced7ff46db3ac003639ff31eac", 2956)]
        [TestCase(@"https://github.com/davatron5000/FitVids.js.git",
                @"2f4fbf3389e9ae65ae73fb1e1a2c1db4b4ebc6c4", 2956)]
        [TestCase(@"https://github.com/kangax/fabric.js.git",
                @"c53089a60a4bff1f9db916146ef2bf5639d1c03f", 2937)]
        [TestCase(@"https://github.com/simplefocus/FlowType.JS.git",
                @"a97f341dfc2c7e81cda21e04d8531a7e6084563d", 2928)]
        [TestCase(@"https://github.com/bebraw/jswiki.git",
                @"2b6758e1f706c52224938b4efe2b4e21b14fb494", 2925)]
        [TestCase(@"https://github.com/paulirish/infinite-scroll.git",
                @"3ffe36bf4fe7df254b3e4ce273bbed6036633fe2", 2913)]
        [TestCase(@"https://github.com/nodejitsu/node-http-proxy.git",
                @"c54278bd3b00e82f4253393b6f6beb1d5a1b19e5", 2906)]
        [TestCase(@"https://github.com/socketstream/socketstream.git",
                @"86afc6679c90f86cb90fcb3409a86c6c6e619812", 2903)]
        [TestCase(@"https://github.com/arshaw/fullcalendar.git",
                @"0dfc25afcb99c4d1e89f51f8a1ebf71790aa3cf1", 2883)]
        [TestCase(@"https://github.com/warpech/jquery-handsontable.git",
                @"29d60f31c7c52709552ce0a9673c0e01c4b96a18", 2874)]
        [TestCase(@"https://github.com/julianlloyd/scrollReveal.js.git",
                @"df0703c3e8c255a687a36dd317f1ce5611f8ac96", 2871)]
        [TestCase(@"https://github.com/jquery/qunit.git",
                @"04e0337cc7fba5c08fc8a7fc8542cadd062f1b03", 2863)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            VerifyRestoringGitRepositorySavingRepo(
                    url, commitPointer, "js_repo.csv", starCount, "*.js");
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