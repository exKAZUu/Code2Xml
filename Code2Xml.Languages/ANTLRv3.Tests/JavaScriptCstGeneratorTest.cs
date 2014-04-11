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
using Code2Xml.Core.Location;
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
        [TestCase(@"https://github.com/angular-ui/bootstrap.git",
                @"94a7f5934ac114626e386a46619e19a43f918bf2")]
        [TestCase(@"https://github.com/shakyShane/browser-sync.git",
                @"e56b9314ba6f6ed45eaa2f378d5391b98c3bf239")]
        [TestCase(@"https://github.com/namuol/cheet.js.git",
                @"25f9e09245ad615d52e5e56f906bf2f011db51e9")]
        [TestCase(@"https://github.com/auduno/clmtrackr.git",
                @"58f852aa8e796488fd7ebe3791f87eede7d34c6d")]
        [TestCase(@"https://github.com/inorganik/countUp.js.git",
                @"67788e475e2fd26b5ef5bd8b19d9e787cb148b7c")]
        [TestCase(@"https://github.com/soulwire/fit.js.git",
                @"9ad6d824805cfabba511f044325b219ad9d8c267")]
        [TestCase(@"https://github.com/gulpjs/gulp.git",
                @"23b2e41c8be1888f4ef79bed05219ac13a359af9")]
        [TestCase(@"https://github.com/driftyco/ionic.git",
                @"8bc870e494469785aaec934878a4ee631596a06f")]
        [TestCase(@"https://github.com/blueimp/jQuery-File-Upload.git",
                @"d87b2494a4157b8aea309fe3eeab862d5cd9e6d5")]
        [TestCase(@"https://github.com/ondras/my-mind.git",
                @"47215ceec70ba7c529012e2aa63ea5f2acbe321d")]
        // Failed test cases
        [TestCase(@"https://github.com/TryGhost/Ghost.git",
                @"185f3c65cd7a389384b3d9b91021954ba18f03dc")]
        //[TestCase(@"https://github.com/electerious/Lychee.git",
        //        @"f9f4afe7db9d2a2f9c98b208edb7fc47962cb41f")]
        //[TestCase(@"https://github.com/Semantic-Org/Semantic-UI.git",
        //        @"db646f9b72c3c0ff7a12f1c75c7bbdaf5b26ce57")]
        //[TestCase(@"https://github.com/angular/angular.js.git",
        //        @"40dc806e03b81cf8bdbb24d67c8e8e3c8af42324")]
        //[TestCase(@"https://github.com/FriendCode/codebox.git",
        //        @"6bdd4769c0fba1af7ac1ce3f455295fb97b5fd8c")]
        //[TestCase(@"https://github.com/mbostock/d3.git",
        //        @"b3d9f5e63b62974acd4ce5848e4da3e241cca649")]
        //[TestCase(@"https://github.com/blueimp/jQuery-File-Upload.git",
        //        @"d87b2494a4157b8aea309fe3eeab862d5cd9e6d5")]
        //[TestCase(@"https://github.com/jquery/jquery.git",
        //        @"4655c3de5f0348da25452ea64d80613bf919284e")]
        //[TestCase(@"https://github.com/koajs/koa.git",
        //        @"ac0896598860e90fab2d36ec17f427befff4a2e3")]
        //[TestCase(@"https://github.com/josdejong/mathjs.git",
        //        @"fe8d832bedd06dd411a37d35b781241762e7e590")]
        //[TestCase(@"https://github.com/moment/moment.git",
        //        @"e5c26e00a4dc00b45443e46cca28dabc472d54a7")]
        //[TestCase(@"https://github.com/mdevils/node-jscs.git",
        //        @"d36c4727cc35a551ec5f0a0b8601d75808756975")]
        //[TestCase(@"https://github.com/orbitjs/orbit.js.git",
        //        @"2a015c5defa825a8bca83917c1e02d039e161faa")]
        //[TestCase(@"https://github.com/mdevils/node-jscs.git",
        //        @"d36c4727cc35a551ec5f0a0b8601d75808756975")]
        //[TestCase(@"https://github.com/BinaryMuse/planetary.js.git",
        //        @"74013bde2960b5d271091e0db152adee2fc854d6")]
        //[TestCase(@"https://github.com/facebook/react.git",
        //        @"ce92efefc03116169f4a52aa96f8413471b260b9")]
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepository(url, commitPointer, "*.js");
        }

        [Test]
        public void ParseComment() {
            var e = Generator.GenerateTreeFromCodeText(
                    @"function(name) { /*a*/ } //aa
/*
c*/");
            Assert.That(e.AllHiddens()
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