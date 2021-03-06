﻿#region License

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
using System.Linq;
using Antlr.Runtime;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.JavaScript;
using NUnit.Framework;
using JavaScriptLexer = Code2Xml.Core.Tests.Generators.ANTLRv3.Parsers.JavaScriptLexer;
using JavaScriptParser = Code2Xml.Core.Tests.Generators.ANTLRv3.Parsers.JavaScriptParser;

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
        //[TestCase(@"https://github.com/joyent/node",
        //        @"cfcb1de130867197cbc9c6012b7e84e08e53d032", 32795)]
        //[TestCase(@"https://github.com/jquery/jquery",
        //        @"5bc1ddc5cc96e509e0fadb0c1e3a70927de6ed1c", 32244)]
        //[TestCase(@"https://github.com/mbostock/d3",
        //        @"d6598447cc972385fc34ca10f542fc53ad174183", 30951)]
        //[TestCase(@"https://github.com/angular/angular.js",
        //        @"d1ccf176351cda2b49599374c7d4ba594796012f", 30669)]
        //[TestCase(@"https://github.com/h5bp/html5-boilerplate",
        //        @"61015dbbea270c71490a6ea92484bcde8e5c6ec0", 27162)]
        //[TestCase(@"https://github.com/bartaz/impress.js",
        //        @"e2d1eb90bf12a1be02079d74545453164d7e7ec4", 22110)]
        [TestCase(@"https://github.com/jashkenas/backbone",
                @"eda14bdfb90ae6c7a8b6c18c6a1beacb5ef1e8a5", 19457)]    // 1
        //[TestCase(@"https://github.com/meteor/meteor",
        //        @"b0d47e10bc6a2c36a339da65a9b888e3df9d8133", 19344)]
        //[TestCase(@"https://github.com/adobe/brackets",
        //        @"ed56656f4953c8e4a54d0c5d453048dd4a754944", 18453)]
        //[TestCase(@"https://github.com/moment/moment",
        //        @"c9dd13e4ac00476e4fc5e83ae72d7eab16942c1c", 18347)]
        //[TestCase(@"https://github.com/blueimp/jQuery-File-Upload",
        //        @"62cd2f84d68dfbcb247ff374ae727ed4a42de49d", 17945)]
        [TestCase(@"https://github.com/hakimel/reveal.js",
                @"6565ba016807ba5c6c44efde5ce40613ed39c845", 17696)]    // 2
        //[TestCase(@"https://github.com/mrdoob/three.js",
        //        @"2d59713328c421c3edfc3feda1b116af13140b94", 16905)]
        //[TestCase(@"https://github.com/strongloop/express",
        //        @"d40dc651f3561a4978fdc9c40e7fc802261d99ce", 16056)]
        //[TestCase(@"https://github.com/resume/resume.github.com",
        //        @"c537d43f3eeb259578f4a0501cb5c0014edd3b72", 13913)]
        [TestCase(@"https://github.com/Automattic/socket.io",
                @"3352d1d72690cdec9794c5f3541c9c778f2dbcee", 13533)]    // 3
        //[TestCase(@"https://github.com/Modernizr/Modernizr",
        //        @"ad2be12934b66102005e3c7e4b850f65f36e25d2", 13496)]
        //[TestCase(@"https://github.com/jashkenas/underscore",
        //        @"bc50d7a0e8d610b461f2d520c2f9f13e5c52f179", 12645)]
        //[TestCase(@"https://github.com/TryGhost/Ghost",
        //        @"38019f356fd31355f6bdcc5ab22db8902b074008", 12627)]
        //[TestCase(@"https://github.com/ivaynberg/select2",
        //        @"dd323687f3324f9b89d73375777793d7f4c0ad13", 12216)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            Action<string> parse = code => {
                var parser =
                        new JavaScriptParser(
                                new CommonTokenStream(
                                        new JavaScriptLexer(new ANTLRStringStream(code))));
                parser.TraceDestination = Console.Error;
                var ret = parser.program();
            };
            MeasurePerformance(url, commitPointer, parse, "*.js");
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