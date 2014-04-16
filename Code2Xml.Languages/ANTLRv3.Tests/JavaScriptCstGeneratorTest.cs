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
        //[TestCase(@"https://github.com/angular-ui/bootstrap.git",
        //        @"94a7f5934ac114626e386a46619e19a43f918bf2")]
        //[TestCase(@"https://github.com/shakyShane/browser-sync.git",
        //        @"e56b9314ba6f6ed45eaa2f378d5391b98c3bf239")]
        //[TestCase(@"https://github.com/namuol/cheet.js.git",
        //        @"25f9e09245ad615d52e5e56f906bf2f011db51e9")]
        //[TestCase(@"https://github.com/auduno/clmtrackr.git",
        //        @"58f852aa8e796488fd7ebe3791f87eede7d34c6d")]
        //[TestCase(@"https://github.com/inorganik/countUp.js.git",
        //        @"67788e475e2fd26b5ef5bd8b19d9e787cb148b7c")]
        //[TestCase(@"https://github.com/soulwire/fit.js.git",
        //        @"9ad6d824805cfabba511f044325b219ad9d8c267")]
        //[TestCase(@"https://github.com/gulpjs/gulp.git",
        //        @"23b2e41c8be1888f4ef79bed05219ac13a359af9")]
        //[TestCase(@"https://github.com/driftyco/ionic.git",
        //        @"8bc870e494469785aaec934878a4ee631596a06f")]
        //[TestCase(@"https://github.com/blueimp/jQuery-File-Upload.git",
        //        @"d87b2494a4157b8aea309fe3eeab862d5cd9e6d5")]
        //[TestCase(@"https://github.com/ondras/my-mind.git",
        //        @"47215ceec70ba7c529012e2aa63ea5f2acbe321d")]
        //[TestCase(@"https://github.com/TryGhost/Ghost.git",
        //        @"185f3c65cd7a389384b3d9b91021954ba18f03dc")]
        //[TestCase(@"https://github.com/blueimp/jQuery-File-Upload.git",
        //        @"d87b2494a4157b8aea309fe3eeab862d5cd9e6d5")]
        //[TestCase(@"https://github.com/josdejong/mathjs.git",
        //        @"fe8d832bedd06dd411a37d35b781241762e7e590")]
        //[TestCase(@"https://github.com/mdevils/node-jscs.git",
        //        @"d36c4727cc35a551ec5f0a0b8601d75808756975")]
        //[TestCase(@"https://github.com/electerious/Lychee.git",
        //        @"f9f4afe7db9d2a2f9c98b208edb7fc47962cb41f")]
        //[TestCase(@"https://github.com/angular/angular.js.git",
        //        @"40dc806e03b81cf8bdbb24d67c8e8e3c8af42324")]

        // -------------------- Failed test cases --------------------

        //[TestCase(@"https://github.com/Semantic-Org/Semantic-UI.git",
        //        @"db646f9b72c3c0ff7a12f1c75c7bbdaf5b26ce57")]
        //[TestCase(@"https://github.com/FriendCode/codebox.git",
        //        @"6bdd4769c0fba1af7ac1ce3f455295fb97b5fd8c")]
        //[TestCase(@"https://github.com/mbostock/d3.git",
        //        @"b3d9f5e63b62974acd4ce5848e4da3e241cca649")]
        //[TestCase(@"https://github.com/jquery/jquery.git",
        //        @"4655c3de5f0348da25452ea64d80613bf919284e")]
        //[TestCase(@"https://github.com/koajs/koa.git",
        //        @"ac0896598860e90fab2d36ec17f427befff4a2e3")]
        //[TestCase(@"https://github.com/moment/moment.git",
        //        @"e5c26e00a4dc00b45443e46cca28dabc472d54a7")]
        //[TestCase(@"https://github.com/orbitjs/orbit.js.git",
        //        @"2a015c5defa825a8bca83917c1e02d039e161faa")]
        //[TestCase(@"https://github.com/BinaryMuse/planetary.js.git",
        //        @"74013bde2960b5d271091e0db152adee2fc854d6")]
        //[TestCase(@"https://github.com/facebook/react.git",
        //        @"ce92efefc03116169f4a52aa96f8413471b260b9")]
        [TestCase(@"https://github.com/kennethreitz/requests.git",
                @"07ee20d07dfd316a0fdd5ec4f5d276a72fe4cc62")] // Star: 9438
        [TestCase(@"https://github.com/django/django.git",
                @"09af48c70fb5cc652ea109487015472e9ef984df")] // Star: 9391
        [TestCase(@"https://github.com/mitsuhiko/flask.git",
                @"d4b3d16c142e2189c6faf8f784a195e7f827c596")] // Star: 9253
        [TestCase(@"https://github.com/facebook/tornado.git",
                @"c5292057a8db3ebec4a80d9c9207bfadff7fa784")] // Star: 7026
        [TestCase(@"https://github.com/jkbr/httpie.git",
                @"746a1899f319a7c2a60f27bf23cc3762822be1a2")] // Star: 6922
        [TestCase(@"https://github.com/ansible/ansible.git",
                @"2cc4ac2e7563e6b73666048c3624bf092f9959e1")] // Star: 5536
        [TestCase(@"https://github.com/reddit/reddit.git",
                @"b50f91c53149671c4039ff1de4250ac0d5bc89c0")] // Star: 5480
        [TestCase(
                @"https://github.com/CamDavidsonPilon/Probabilistic-Programming-and-Bayesian-Methods-for-Hackers.git",
                @"39f9356f320bcff1a2a3e01d8559d9089413b4eb")] // Star: 5379
        [TestCase(@"https://github.com/kennethreitz/python-guide.git",
                @"cf3a875262eb5172342e6b0d06ccfb6655233abf")] // Star: 4749
        [TestCase(@"https://github.com/getsentry/sentry.git",
                @"94e56e691f4081db7680faf49db5592ec29edd23")] // Star: 4705
        [TestCase(@"https://github.com/karan/Projects.git",
                @"292fabbd855949a2aa100615b13ad4017809ed81")] // Star: 4667
        [TestCase(@"https://github.com/scrapy/scrapy.git",
                @"7814cbf3197605a1b125f061a78cde015a934819")] // Star: 4520
        [TestCase(@"https://github.com/rg3/youtube-dl.git",
                @"2d4c98dbd17676978114b70d59ea15628f886c24")] // Star: 4143
        [TestCase(@"https://github.com/pagekite/Mailpile.git",
                @"556c9e16855dea71db23bc2180e4cef1cf2a40ef")] // Star: 4049
        [TestCase(@"https://github.com/apenwarr/sshuttle.git",
                @"9ce2fa00f94c2f2e5c310abeb1a2907ae7e7a7b0")] // Star: 3944
        [TestCase(@"https://github.com/boto/boto.git",
                @"c213ff114a28aedb491f90a3acc6ee4626cae578")] // Star: 3680
        [TestCase(@"https://github.com/ipython/ipython.git",
                @"fb1283edcacdeb0aaad12201741e5502a341f0eb")] // Star: 3550
        [TestCase(@"https://github.com/getpelican/pelican.git",
                @"b11b8a93cd45ad2d16118ce2bffef8bd3128a004")] // Star: 3281
        [TestCase(@"https://github.com/saltstack/salt.git",
                @"0c9f7eb3569cc5fc547d2ed2628da9a3def7d80e")] // Star: 3271
        [TestCase(@"https://github.com/fabric/fabric.git",
                @"b41f7995bcaa5ade335e1dd1e438ae2ca42f4e07")] // Star: 3102
        [TestCase(@"https://github.com/kennethreitz/legit.git",
                @"473d87d32488f8f71f0ee3086814fdf62b291a60")] // Star: 3088
        [TestCase(@"https://github.com/facebook/huxley.git",
                @"2177563400ba03580622144b521bb116c345225c")] // Star: 2969
        [TestCase(@"https://github.com/django/django-old.git",
                @"ad096059b58afd35b395b01ad4eba36b8ff863de")] // Star: 2908
        [TestCase(@"https://github.com/pydata/pandas.git",
                @"ad1f47ddb16c383c7377d0f7a930d0a80c6fbfef")] // Star: 2874
        [TestCase(@"https://github.com/faif/python-patterns.git",
                @"f7ec06df2f4d7fb98d3187af30d8a54b1bc08dea")] // Star: 2829
        [TestCase(@"https://github.com/webpy/webpy.git",
                @"73f1119649ffe54ba26ddaf6a612aaf1dab79b7f")] // Star: 2804
        [TestCase(@"https://github.com/lebinh/ngxtop.git",
                @"3694d55b15f73b531d8c7951711799ffa3c7521a")] // Star: 2783
        [TestCase(@"https://github.com/sampsyo/beets.git",
                @"fcb55145e6fcafab69bc6eedb16154516c341548")] // Star: 2734
        [TestCase(@"https://github.com/liftoff/GateOne.git",
                @"2fe1daf3812bbc620ea53245666106e270b7502c")] // Star: 2707
        [TestCase(@"https://github.com/divio/django-cms.git",
                @"f884372e0576a384e05c6a8f084eaf089eae25b3")] // Star: 2704
        [TestCase(@"https://github.com/midgetspy/Sick-Beard.git",
                @"a493151582d5779f5656291c9251398623511e7b")] // Star: 2684
        [TestCase(@"https://github.com/Lokaltog/powerline.git",
                @"c100c90b088c55fe91146eb52dfcbbc7e43039bd")] // Star: 2614
        [TestCase(@"https://github.com/django-debug-toolbar/django-debug-toolbar.git",
                @"777c8a1cd669bbfde6cfcb8866de4fdf8c0825cf")] // Star: 2613
        [TestCase(@"https://github.com/SublimeCodeIntel/SublimeCodeIntel.git",
                @"3a0c3b924632e3f504f21f86c2fda2c87d2ce0ca")] // Star: 2592
        [TestCase(@"https://github.com/celery/celery.git",
                @"ae277443cfe381a0c855a67338afe08a34cff1b5")] // Star: 2557
        [TestCase(@"https://github.com/progrium/localtunnel.git",
                @"08f3ac0f15f3b7324f1f1b1fbbbccfb926bfa7fe")] // Star: 2492
        [TestCase(@"https://github.com/toastdriven/django-tastypie.git",
                @"834f728b07ab1a008b281b12a2cab2987f26c99d")] // Star: 2439
        [TestCase(@"https://github.com/andymccurdy/redis-py.git",
                @"f96e46b971a5bb66ab5f94ba87ab3e092e5f01ac")] // Star: 2438
        [TestCase(@"https://github.com/Katee/quietnet.git",
                @"946e57c2f87800e342240a4d33c0163d3682e8c1")] // Star: 2431
        [TestCase(@"https://github.com/square/SocketRocket.git",
                @"656283dd195414723cd473746923db50abd34cb2")] // Star: 2390
        [TestCase(@"https://github.com/docopt/docopt.git",
                @"05125ddcd1750f7e5ed373044910e224e1e636ed")] // Star: 2377
        [TestCase(@"https://github.com/defnull/bottle.git",
                @"33b1683793bc6ce8af37c9d5c34be0c4fe220d1f")] // Star: 2292
        [TestCase(@"https://github.com/clips/pattern.git",
                @"a9d7f8449c0118e7442b4ffb1c78097c74b468ed")] // Star: 2253
        [TestCase(@"https://github.com/tomchristie/django-rest-framework.git",
                @"b3b0515ae6325e7de6a582bbb2fd7eeac687c325")] // Star: 2200
        [TestCase(@"https://github.com/mitmproxy/mitmproxy.git",
                @"1dba379ae90593a563acb9dbed6f5e6b721c086a")] // Star: 2191
        [TestCase(@"https://github.com/jisaacks/GitGutter.git",
                @"299097085eb58bfdb4da52b0d86b4bb450e4c59d")] // Star: 2182
        [TestCase(@"https://github.com/amoffat/sh.git",
                @"80af5726d8aa42017ced548abbd39b489068922a")] // Star: 2181
        [TestCase(@"https://github.com/gleitz/howdoi.git",
                @"e022e1d341bdb11f6731f2d819399aee7dc57d5c")] // Star: 2165
        [TestCase(@"https://github.com/joke2k/faker.git",
                @"7cd01eb89df25ee7e98854b9edd991e008c6f49f")] // Star: 2163
        [TestCase(@"https://github.com/nicolargo/glances.git",
                @"4177046cdd3be8f2019799490de54a7aab5b0550")] // Star: 2136
        [TestCase(@"https://github.com/scrapinghub/portia.git",
                @"55f97e61fc558d243a0806ae8bf4a26b080026de")] // Star: 2132
        [TestCase(@"https://github.com/jorgebastida/glue.git",
                @"33fa00c35ad3a186e187bdf93105617ced46d43f")] // Star: 2128
        [TestCase(@"https://github.com/kstenerud/iOS-Universal-Framework.git",
                @"2b65899ed6c57e999145f521a327999692837ac8")] // Star: 2094
        [TestCase(@"https://github.com/somerandomdude/Iconic.git",
                @"3a1136003928f0dbc1284eb568d3a0b6a5ad6830")] // Star: 2080
        [TestCase(@"https://github.com/omab/django-social-auth.git",
                @"3a6e4414da0e969fcaf625a891852a3b2d7627c0")] // Star: 2078
        [TestCase(@"https://github.com/joelthelion/autojump.git",
                @"6360876933c4245ee3762a3d52e74a6d591772ff")] // Star: 1994
        [TestCase(@"https://github.com/tweepy/tweepy.git",
                @"d626a964b29f7a9e93599a3b25789f8b997b1aef")] // Star: 1993
        [TestCase(@"https://github.com/simplegeo/python-oauth2.git",
                @"a83f4a297336b631e75cba102910c19231518159")] // Star: 1991
        [TestCase(@"https://github.com/bup/bup.git",
                @"458051fe66179667b88b84cf31596c21d3b0f05a")] // Star: 1948
        [TestCase(@"https://github.com/lg/murder.git",
                @"9c59118ce17c1d033318a34b01995eb96b3d35a3")] // Star: 1868
        [TestCase(@"https://github.com/facebook/chisel.git",
                @"368e4f675a77cefc7f2dddfd4de87f8b9422aadd")] // Star: 1864
        [TestCase(@"https://github.com/django-extensions/django-extensions.git",
                @"893bcffdb79dbdd98ecf5aebe30452080c71ac7a")] // Star: 1844
        [TestCase(@"https://github.com/pinax/pinax.git",
                @"2d45637a035d41ec900e0f3152812cb940c76d35")] // Star: 1839
        [TestCase(@"https://github.com/aws/aws-cli.git",
                @"4996cd601117b83e059104b7c9c0a65dbd0c00df")] // Star: 1828
        [TestCase(@"https://github.com/klen/python-mode.git",
                @"b79b2e991e48488fb2800d9deec3b2ec457bb095")] // Star: 1793
        [TestCase(@"https://github.com/sokolovstas/SublimeWebInspector.git",
                @"ec464edcb13899ea4b4ff98003fc8daf7f1d451a")] // Star: 1788
        [TestCase(@"https://github.com/redecentralize/alternative-internet.git",
                @"2f4b440c456c00813d78d3416c8b72ec2f08cc5c")] // Star: 1787
        [TestCase(@"https://github.com/orchardup/fig.git",
                @"530afba5cb0d0f0b15f37643f4da476c4b336ded")] // Star: 1785
        [TestCase(@"https://github.com/benoitc/gunicorn.git",
                @"3bf6d0e77026098e7a6d905426c53e951a3889ef")] // Star: 1783
        [TestCase(@"https://github.com/sqlmapproject/sqlmap.git",
                @"ef5ce7e66c26af2405ea7f0e1da282b99f7cb450")] // Star: 1767
        [TestCase(@"https://github.com/devstructure/blueprint.git",
                @"574a9fc0dd3031c66970387f1105d8c89e61218f")] // Star: 1732
        [TestCase(@"https://github.com/kivy/kivy.git",
                @"84a6bbcae99278928c996ddcbc39d683c2803e57")] // Star: 1722
        [TestCase(@"https://github.com/kemayo/sublime-text-git.git",
                @"cce6c085670140d00b3f76c5458f34bf7caeb5ef")] // Star: 1691
        [TestCase(@"https://github.com/gregmalcolm/python_koans.git",
                @"075dfd4d3d9a9c1908664e304b964076782ddcdb")] // Star: 1667
        [TestCase(@"https://github.com/thearn/webcam-pulse-detector.git",
                @"42bfbe23a54e8f0a1725595468e4486d96e11561")] // Star: 1665
        [TestCase(@"https://github.com/shipyard/shipyard.git",
                @"400b6455fc249ad096bc849f2f27385cfe2daa6d")] // Star: 1650
        [TestCase(@"https://github.com/stephenmcd/mezzanine.git",
                @"c937a98c2e83231e3016b5a562a9dc96d41a51bb")] // Star: 1644
        [TestCase(@"https://github.com/mitsuhiko/jinja2.git",
                @"b7d13f278753d057bb3765b4d4a672c351d88bf3")] // Star: 1626
        [TestCase(@"https://github.com/sloria/TextBlob.git",
                @"75d983fc798528dc3c8633efcfb031ae191752d1")] // Star: 1625
        [TestCase(@"https://github.com/wbond/sublime_package_control.git",
                @"0b03e16d91203df21aced724b013c8bd75856cd3")] // Star: 1620
        [TestCase(@"https://github.com/harelba/q.git",
                @"eb64e76c366163b14ba76b95525ef0ac99d0ab9b")] // Star: 1616
        [TestCase(@"https://github.com/fogleman/Minecraft.git",
                @"d02cd72d1ec2ee133b3fec6ac1710e22bea59365")] // Star: 1561
        [TestCase(@"https://github.com/coursera-dl/coursera.git",
                @"3fdb3ce901587eaadb6a1b3c00f1d45ae666e5c2")] // Star: 1520
        [TestCase(@"https://github.com/clowwindy/shadowsocks.git",
                @"854d1752453d742db9c759f2ae4c3253dd0143e7")] // Star: 1517
        [TestCase(@"https://github.com/opdemand/deis.git",
                @"50e42169ac82417dd337fd4a08527401edbeea85")] // Star: 1507
        [TestCase(@"https://github.com/maraujop/django-crispy-forms.git",
                @"e31e39561c10b01be3693914aad1aa79350f5647")] // Star: 1502
        [TestCase(@"https://github.com/jeffknupp/sandman.git",
                @"e534defd803082feee0af30b64d2c9fb4c5ed2ac")] // Star: 1482
        [TestCase(@"https://github.com/playframework/play1.git",
                @"b835b790c795bddd7d41ac6a4a7a1eb6922fab2f")] // Star: 1472
        [TestCase(@"https://github.com/matplotlib/matplotlib.git",
                @"3c8fe522356de92811bf0aecb244b5603b6e48c6")] // Star: 1460
        [TestCase(@"https://github.com/thumbor/thumbor.git",
                @"0ec1e71fe2d85d3278e3a4196e23f8d8229238e3")] // Star: 1459
        [TestCase(@"https://github.com/mitsuhiko/werkzeug.git",
                @"ca58b6856f1bb204e8a2b4fd247d92ad943b798b")] // Star: 1419
        [TestCase(@"https://github.com/iambus/xunlei-lixian.git",
                @"4d814d1b6fc6907162892ffae3e22898ad98184f")] // Star: 1411
        [TestCase(@"https://github.com/toastdriven/django-haystack.git",
                @"366e7489169d460d36ac4d942c22c0e97e58c26b")] // Star: 1408
        [TestCase(@"https://github.com/fxsjy/jieba.git",
                @"2682e887b83962f6ff84fbc896de2ff5cfc903f8")] // Star: 1402
        [TestCase(@"https://github.com/nltk/nltk.git",
                @"8cef1664d6461992b5c6f172dd8975511e043d4e")] // Star: 1396
        [TestCase(@"https://github.com/quantopian/zipline.git",
                @"63e3aa4c1e8f25b08e3fbc437f778b28453c7e45")] // Star: 1395
        [TestCase(@"https://github.com/nicolaiarocci/eve.git",
                @"ee559c0407204ee4c42c8b3e59f3c6b8fa4a7437")] // Star: 1386
        [TestCase(@"https://github.com/aziz/PlainTasks.git",
                @"be34d6efad4435e4029870297d193699985bc414")] // Star: 1386
        [TestCase(@"https://github.com/RuudBurger/CouchPotatoServer.git",
                @"b69f8b7ed520930dcab53dc27c1eb58a0c2afbf4")] // Star: 1378
        [TestCase(@"https://github.com/utahta/pythonbrew.git",
                @"e8823c5494a26e2c91aa516eac80b748474ba129")] // Star: 1368
        [TestCase(@"https://github.com/kennethreitz/clint.git",
                @"f1ab574413631de12166469e87257784785d3da6")] // Star: 1364
        [TestCase(@"https://github.com/taobao/nginx-book.git",
                @"b1cba2dc114393766e863581b34dbe179b28c18e")] // Star: 1363
        [TestCase(@"https://github.com/codelucas/newspaper.git",
                @"e0718be363470a19055b1e894957d127c6ae541d")] // Star: 1361
        [TestCase(@"https://github.com/Pylons/pyramid.git",
                @"77005d96fa57a83ac91c2547892fbb3e3c34e553")] // Star: 1352
        [TestCase(@"https://github.com/treeio/treeio.git",
                @"a4fbffabec2644a98f8b06d678a94d2949304235")] // Star: 1335
        [TestCase(@"https://github.com/surfly/gevent.git",
                @"f6831bfa5cac1fcbdbc76b8d9595ec4f6c53889e")] // Star: 1331
        [TestCase(@"https://github.com/rembo10/headphones.git",
                @"d6cd9cd7e4cd95e2e4d2fd845fa0c64b91e5e4a5")] // Star: 1319
        [TestCase(@"https://github.com/koenbok/Cactus.git",
                @"10cd41a4a06ab0c88daf625e5a1b7fda202d7126")] // Star: 1319
        [TestCase(@"https://github.com/nvie/rq.git",
                @"aef7af9c77fb6c1e5836403660a4e71fe3c05230")] // Star: 1316
        [TestCase(@"https://github.com/mongodb/mongo-python-driver.git",
                @"a7575fa14f5a9aaeb0149981899f776af9e1ad1c")] // Star: 1286
        [TestCase(@"https://github.com/lihaoyi/macropy.git",
                @"13993ccb08df21a0d63b091dbaae50b9dbb3fe3e")] // Star: 1271
        [TestCase(@"https://github.com/torchbox/wagtail.git",
                @"d3ac6c072886a1c4cd8d27b94c4a9b6e9d51f218")] // Star: 1256
        [TestCase(@"https://github.com/pypa/pip.git",
                @"7bda9c3e6fba43260aef822421627b7f7bdc7005")] // Star: 1255
        [TestCase(@"https://github.com/kennethreitz/envoy.git",
                @"94c24eeaea8ba171a87e99194a59b36932424a66")] // Star: 1254
        [TestCase(@"https://github.com/Bitmessage/PyBitmessage.git",
                @"700e3d1f17a820dd80108c08c8e1679debed2fd3")] // Star: 1239
        [TestCase(@"https://github.com/Eugeny/ajenti.git",
                @"75013c621095775887f514ba014b36578ca48fae")] // Star: 1237
        [TestCase(@"https://github.com/martinblech/xmltodict.git",
                @"23b9f41d90bf29d119246e3dcac29fec3a5fbc8e")] // Star: 1229
        [TestCase(@"https://github.com/samuraisam/pyapns.git",
                @"a56912f3b83b72c497e716c34ed6b5fda6bd21f3")] // Star: 1223
        [TestCase(@"https://github.com/litl/rauth.git",
                @"97b6c6a3cff0379bd915acd2de382ccc5f22c4cf")] // Star: 1218
        [TestCase(@"https://github.com/openstack/nova.git",
                @"66e4e32f8b8f1fa004ca0289b843e0a4fa5600d1")] // Star: 1198
        [TestCase(@"https://github.com/AppScale/appscale.git",
                @"1d1d24d7ae1890f39db9775ebfb3efddb12ad79d")] // Star: 1197
        [TestCase(@"https://github.com/django-compressor/django-compressor.git",
                @"aba8c5f6b59dd78831d2bf1e53222f8475b2f9f8")] // Star: 1197
        [TestCase(@"https://github.com/pennersr/django-allauth.git",
                @"3fee3665b86cc9a56174e81267a187b36b1290de")] // Star: 1162
        [TestCase(@"https://github.com/gorakhargosh/watchdog.git",
                @"a8391941d4ff450483f0dfe2b5a3c02ecdd8f818")] // Star: 1159
        [TestCase(@"https://github.com/jokkedk/webgrind.git",
                @"dc3539340dba1c6d6308a62a9701fdc3f3343de5")] // Star: 1154
        [TestCase(@"https://github.com/coleifer/peewee.git",
                @"e24cdd19204d63984d537842336cbc5426217cc0")] // Star: 1149
        [TestCase(@"https://github.com/pudo/dataset.git",
                @"e08565609e2439ac9a88f98081a36e42ba44a6a0")] // Star: 1141
        [TestCase(@"https://github.com/dotcloud/zerorpc-python.git",
                @"1dee8bdb1ce78ee792cb4b46a47d894e70f26cb6")] // Star: 1137
        [TestCase(@"https://github.com/gurgeh/selfspy.git",
                @"75792f48e280575366ce855a947f2bff6eea513b")] // Star: 1135
        [TestCase(@"https://github.com/spadgos/sublime-jsdocs.git",
                @"da6294af5301d108cf42f90eb11e01f32395c8ac")] // Star: 1132
        [TestCase(@"https://github.com/DanMcInerney/LANs.py.git",
                @"791d794b3851891e2c50be39336459d515307271")] // Star: 1125
        [TestCase(@"https://github.com/edx/edx-platform.git",
                @"36be4e543c41284172031585ae8fe0dc825166bc")] // Star: 1122
        [TestCase(@"https://github.com/rstacruz/sparkup.git",
                @"ea35be6c0bac75e6308ebf72a9c737fb8c21e3ae")] // Star: 1122
        [TestCase(@"https://github.com/google/pyringe.git",
                @"6309eb6215cb3750fc3e914c17f6e472aec12824")] // Star: 1122
        [TestCase(@"https://github.com/crsmithdev/arrow.git",
                @"b7eb832c08a1e376ffbacb70e95366b03a844379")] // Star: 1117
        [TestCase(@"https://github.com/livid/v2ex.git",
                @"c8af57e2d2c4c8701901fb346cc98a4cde13b54b")] // Star: 1116
        [TestCase(@"https://github.com/spotify/luigi.git",
                @"8b13063c398a3fa9f7b1dadacefa0512b407f164")] // Star: 1114
        [TestCase(@"https://github.com/khamidou/kite.git",
                @"5ed8ba0c002b38733804d50410792245474520c6")] // Star: 1090
        [TestCase(@"https://github.com/numba/numba.git",
                @"36d4596430ee4e3761cdd5adf14509160dad213c")] // Star: 1079
        [TestCase(@"https://github.com/scipy/scipy.git",
                @"87df1db4f0137dd30d6841565dd88f16bddccb02")] // Star: 1076
        [TestCase(@"https://github.com/Yelp/mrjob.git",
                @"94a67a42d36e69aada9e31d1975be32e730f1656")] // Star: 1076
        [TestCase(@"https://github.com/rtfd/readthedocs.org.git",
                @"fc4dbc905010c0a47764e19366f8b1f09231df53")] // Star: 1073
        [TestCase(@"https://github.com/sivel/speedtest-cli.git",
                @"18408ee93884de3d28142d0afac12714049e293b")] // Star: 1073
        [TestCase(@"https://github.com/sympy/sympy.git",
                @"9ba613eb3385c9fc63a834efc624595b0d7ac7b7")] // Star: 1072
        [TestCase(@"https://github.com/ajalt/fuckitpy.git",
                @"9db07766ceb73e95f7e5f6bd1245967535e8e2c3")] // Star: 1070
        [TestCase(@"https://github.com/etianen/django-reversion.git",
                @"7a163dde302f072904e1f0e102cc8d98b64dfe92")] // Star: 1063
        [TestCase(@"https://github.com/paramiko/paramiko.git",
                @"e96e2653a2ca0a465d2773b1fe468c0f87e758bc")] // Star: 1063
        [TestCase(@"https://github.com/RuudBurger/CouchPotatoV1.git",
                @"135b3331d1b88ef645e29b76f2d4cc4a732c9232")] // Star: 1059
        [TestCase(@"https://github.com/freedomofpress/securedrop.git",
                @"3e794a7052225bcb9bde0f498bd4797b475a40e0")] // Star: 1058
        [TestCase(@"https://github.com/milkbikis/powerline-shell.git",
                @"e8300222fed3e5424956b9ef7e026e26edc227fd")] // Star: 1053
        [TestCase(@"https://github.com/etsy/logster.git",
                @"7475c53822c2e22d0994ea059bfd482044019a5b")] // Star: 1053
        [TestCase(@"https://github.com/davidhalter/jedi.git",
                @"4ff8b921a3b252895ed43b9598a5a40f0cbd487c")] // Star: 1040
        [TestCase(@"https://github.com/newsapps/beeswithmachineguns.git",
                @"5eeb3cabfecc31add46f2dabe804c7a9277cd035")] // Star: 1040
        [TestCase(@"https://github.com/seatgeek/fuzzywuzzy.git",
                @"7d8f2f89b69bd21707f5b66036d568c81f81d64e")] // Star: 1033
        [TestCase(@"https://github.com/wrobstory/vincent.git",
                @"c2e4e34cb6e008e759d63066c9b8420fd2f0e71c")] // Star: 1027
        [TestCase(@"https://github.com/kennethreitz/tablib.git",
                @"fc4cc7fa148c3e292fb33e9c07eb9e47a3e45fcf")] // Star: 1025
        [TestCase(@"https://github.com/sightmachine/SimpleCV.git",
                @"fd26f7ea451db9ed24ab8cfceff23251fbac350b")] // Star: 1023
        [TestCase(@"https://github.com/alex/django-taggit.git",
                @"f478e34f8e82c20b04f5992ae5299d7cf41c2b9f")] // Star: 1002
        [TestCase(@"https://github.com/hyde/hyde.git",
                @"b29ba60b2b752ee31ecb5894409529d9ed99202e")] // Star: 1000
        [TestCase(@"https://github.com/iBaa/PlexConnect.git",
                @"e076e37cb30ac9f72d7a52a8c1cc7da6fa4f6315")] // Star: 992
        [TestCase(@"https://github.com/kachayev/fn.py.git",
                @"dc5c57345dc05398c0b0a1a12c479a986b970995")] // Star: 991
        [TestCase(@"https://github.com/gaubert/gmvault.git",
                @"02f33060eb3744658681a7f667bcb513132706e9")] // Star: 990
        [TestCase(@"https://github.com/python-imaging/Pillow.git",
                @"994c9a7e56a8a74da9044d9a732a29e41b4d30b6")] // Star: 982
        [TestCase(@"https://github.com/elvanderb/TCP-32764.git",
                @"fc014066bac5fd3158d21e5336f5be85582b36a8")] // Star: 981
        [TestCase(@"https://github.com/sixohsix/twitter.git",
                @"83c7a242415861d7f0f18037c2866f308782164d")] // Star: 978
        [TestCase(@"https://github.com/gmate/gmate.git",
                @"f77cb109ab50959ad0b0ac6138ba16d1ecff6d4d")] // Star: 976
        [TestCase(@"https://github.com/DanMcInerney/wifijammer.git",
                @"386a4399c6d54777e716b64138ab9a2722afcbaf")] // Star: 976
        [TestCase(@"https://github.com/sebastien/cuisine.git",
                @"329e0bf2a956a1c153dc3b1ca17067378ef376e7")] // Star: 972
        [TestCase(@"https://github.com/sublimehq/anim_encoder.git",
                @"06f6fec3c459db5c77778c3aa8804289f8bb1960")] // Star: 958
        [TestCase(@"https://github.com/tgalal/yowsup.git",
                @"938cf1f0d0aedf650be748dcc258a43b8c87a6b3")] // Star: 942
        [TestCase(@"https://github.com/kennethreitz/inbox.py.git",
                @"551b4f44b144564504c687cebdb4c543cb8e9adf")] // Star: 936
        [TestCase(@"https://github.com/pythonforfacebook/facebook-sdk.git",
                @"e30370fa71a73129979cdd838307a37812d94d1b")] // Star: 930
        [TestCase(@"https://github.com/tangentlabs/django-oscar.git",
                @"f3f983ac3faed17a242ac1fbb9e2dbfbb8385f50")] // Star: 929
        [TestCase(@"https://github.com/martinrusev/amonone.git",
                @"c882215aa3b970db8f4da1eb7789b6199cf4610a")] // Star: 928
        [TestCase(@"https://github.com/tschellenbach/Django-facebook.git",
                @"4a57628766afe5a09525faf246f0bc2563b9c3a0")] // Star: 928
        [TestCase(@"https://github.com/chrisallenlane/cheat.git",
                @"406cf0dcf3c86305bce7a471feb592a36a80b791")] // Star: 921
        [TestCase(@"https://github.com/buildbot/buildbot.git",
                @"d3364bff14663a422a7bc4a5a6cdede14645cc56")] // Star: 920
        [TestCase(@"https://github.com/nathanborror/django-basic-apps.git",
                @"3a90090857549ea4198a72c44f45f6edb238e2a8")] // Star: 919
        [TestCase(@"https://github.com/charlierguo/gmail.git",
                @"4626823d3fbf159d242a50b33251576aeddbd9ad")] // Star: 917
        [TestCase(@"https://github.com/revolunet/sublimetext-markdown-preview.git",
                @"3b94b8489b2c9b6f54eabf50bd19984e9b588f2c")] // Star: 911
        [TestCase(@"https://github.com/overviewer/Minecraft-Overviewer.git",
                @"8e5944d5c3fc1c1aae8331daa1b72af0c29d8702")] // Star: 909
        [TestCase(@"https://github.com/emre/storm.git",
                @"92fb3a77f4f39578a327aba419a7f4a1afcf1199")] // Star: 902
        [TestCase(@"https://github.com/Supervisor/supervisor.git",
                @"65221682eb2590b2de504586f5736d55327e81d6")] // Star: 894
        [TestCase(@"https://github.com/mikemaccana/python-docx.git",
                @"e507db84bdaa65010b616033a8ac6639ac4f6a12")] // Star: 890
        [TestCase(@"https://github.com/symfony/symfony-docs.git",
                @"98288fcf789197b5c7a26a6a44ccbdabc911690f")] // Star: 889
        [TestCase(@"https://github.com/pypa/virtualenv.git",
                @"5858d32f913f626c536c78fdd17c9c67d1d1fb70")] // Star: 889
        [TestCase(@"https://github.com/etsy/skyline.git",
                @"90d7bb16ea6ebc8a61b66e67428c8e669b1082a1")] // Star: 887
        [TestCase(@"https://github.com/paulhammond/webkit2png.git",
                @"8c6fbb435990c81ce721ba3bc6bc12dfb332aaa2")] // Star: 879
        [TestCase(@"https://github.com/titoBouzout/SideBarEnhancements.git",
                @"067db326b805163840333721cf2708d0e224e9fe")] // Star: 878
        [TestCase(@"https://github.com/mothran/bunny.git",
                @"8a61d0eddf7d655b6493847f106e7ee6110f53fe")] // Star: 875
        [TestCase(@"https://github.com/Rip-Rip/clang_complete.git",
                @"5b3ced59588dc9f65e9e916890cb6795764c3fe4")] // Star: 875
        [TestCase(@"https://github.com/wuub/SublimeREPL.git",
                @"f2b2a79140fe8423a5233fd9b962fe9bde052ca6")] // Star: 872
        [TestCase(@"https://github.com/lra/mackup.git",
                @"565fbc6c9f48f3e1082fba2965948f609ef64f4d")] // Star: 867
        [TestCase(@"https://github.com/noamraph/tqdm.git",
                @"da5fdbf7c05a9127f04ac5887292457e8335f480")] // Star: 867
        [TestCase(@"https://github.com/madisonmay/CommonRegex.git",
                @"2cf86259676da169b480f734181a5831eb62f8b9")] // Star: 866
        [TestCase(@"https://github.com/klbostee/dumbo.git",
                @"ca79358a061d18df45b1ab8010cfd69f5943ef6b")] // Star: 863
        [TestCase(@"https://github.com/Jahaja/psdash.git",
                @"f05c8e0a1011603d5ef408d32f7cf34e2a2f2470")] // Star: 862
        [TestCase(@"https://github.com/simon-weber/Unofficial-Google-Music-API.git",
                @"e23d2f51f533b47c90df6120a4f2ecc588cf1737")] // Star: 859
        [TestCase(@"https://github.com/jacobian/djangobook.com.git",
                @"e205e45759fdd4ae2e4f9e6ed8fbf87a0e158c53")] // Star: 855
        [TestCase(@"https://github.com/bread-and-pepper/django-userena.git",
                @"f07ba8e209ee97b16467cf3cddb4b4a77a7f04a8")] // Star: 852
        [TestCase(@"https://github.com/s3tools/s3cmd.git",
                @"d52d5edcc916512e979917f04abcea19d3a25af7")] // Star: 850
        [TestCase(@"https://github.com/sshwsfc/django-xadmin.git",
                @"effe5c0471be4c2f434ccece3a0c48bf222e0c74")] // Star: 847
        [TestCase(@"https://github.com/hannes-brt/hebel.git",
                @"346cfa6765c347fc60ab1e3f0d426e5d152f813b")] // Star: 838
        [TestCase(@"https://github.com/twilio/stashboard.git",
                @"5713647d4eeda0306a95d583283734382a067033")] // Star: 836
        [TestCase(@"https://github.com/dcramer/django-devserver.git",
                @"b65bee8e22adf777181147a7e80fb16ace1fd776")] // Star: 826
        [TestCase(@"https://github.com/alex/django-filter.git",
                @"d88b98dd2b70551deb9c128b209fcf783b325acc")] // Star: 826
        [TestCase(@"https://github.com/zeromq/pyzmq.git",
                @"3fd2d252be30ee21c0b416fd9a0793da3f6abad3")] // Star: 814
        [TestCase(@"https://github.com/django-mptt/django-mptt.git",
                @"e82722d9152986be64ac5a40df9cd5a1d5462311")] // Star: 814
        [TestCase(@"https://github.com/omab/python-social-auth.git",
                @"461ae02c612a3c44212414f3147d020330cbd40d")] // Star: 810
        [TestCase(@"https://github.com/topazproject/topaz.git",
                @"2aaf6231728943a0cead1a0d3fa02b3df5aeb087")] // Star: 807
        [TestCase(@"https://github.com/audreyr/cookiecutter.git",
                @"a144fe77ebd4c6a8d43c87f7aba00c48b985d363")] // Star: 807
        [TestCase(@"https://github.com/networkx/networkx.git",
                @"4f31ecac6ff2193b8d29232f8382439c12904256")] // Star: 802
        [TestCase(@"https://github.com/facelessuser/BracketHighlighter.git",
                @"d0634d794b1dd2d9cc154d5a6d83be5808d38388")] // Star: 800
        [TestCase(@"https://github.com/mopidy/mopidy.git",
                @"ed918fc7ff4d6009acd48197d2019e921e8ad697")] // Star: 791
        [TestCase(@"https://github.com/SirVer/ultisnips.git",
                @"2f848994458d006a6adebee028c7e27475ebdbb9")] // Star: 785
        [TestCase(@"https://github.com/hhatto/autopep8.git",
                @"5cb335c7638f9f158cb0f5281e5a3155fdaee153")] // Star: 782
        [TestCase(@"https://github.com/gabrielfalcao/lettuce.git",
                @"09b10c5f6797b7c39579c5a935d458f8e6ef9bfc")] // Star: 781
        [TestCase(@"https://github.com/Fantomas42/django-blog-zinnia.git",
                @"73849ba5fe22874b64074555acf986890b507dc5")] // Star: 780
        [TestCase(@"https://github.com/earle/django-bootstrap.git",
                @"97eb50b3f4932798e7fa8ad4b42f0534d521826d")] // Star: 778
        [TestCase(@"https://github.com/nvie/pip-tools.git",
                @"d138317842ef934d8711172d7f1ef785d0af8f37")] // Star: 771
        [TestCase(@"https://github.com/douban/dpark.git",
                @"7e7d17668a689b4c77c3a246a599046c33a72923")] // Star: 770
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "js_repo.txt", "*.js");
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