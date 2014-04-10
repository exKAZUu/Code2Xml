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

        //[Test]
        ////[TestCase("angular.js")]	// failed
        //[TestCase("bootstrap")]
        //[TestCase("browser-sync")]
        //[TestCase("cheet.js")]
        //[TestCase("clmtrackr")]
        ////[TestCase("codebox")]	// failed
        //[TestCase("countUp.js")]
        ////[TestCase("d3")]	// failed
        //[TestCase("fit.js")]
        ////[TestCase("Ghost")]	// failed
        //[TestCase("gulp")]
        //[TestCase("ionic")]
        ////[TestCase("jquery")]	// failed
        //[TestCase("jQuery-File-Upload")] // failed
        ////[TestCase("koa")]	// failed
        ////[TestCase("Lychee")]	// failed
        ////[TestCase("mathjs")]	// failed
        ////[TestCase("moment")]	// failed
        //[TestCase("my-mind")]
        ////[TestCase("node-jscs")]	// failed
        ////[TestCase("orbit.js")]	// failed
        ////[TestCase("planetary.js")]	// failed
        ////[TestCase("react")]	// failed
        ////[TestCase("Semantic-UI")]	// failed
        //public void ParseDirectory(string directoryName) {
        //    VerifyRestoringProjectDirectory("JavaScript", directoryName, "*.js");
        //}

        [Test]
        [TestCase(@"https://github.com/angular-ui/bootstrap.git",
                @"3b6ab25b5c227ee21fc863ffe523e719475dbca5")]
        [TestCase(@"https://github.com/shakyShane/browser-sync.git",
                @"388634027ddd79bacaffae5a3ac82106d0008801")]
        [TestCase(@"https://github.com/namuol/cheet.js.git",
                @"dd5fae6c476b22903c7c1777fbb6cb74b50ca4ed")]
        [TestCase(@"https://github.com/auduno/clmtrackr.git",
                @"f4461ac66b0dcf7146fe41611fbe91dda48cae89")]
        [TestCase(@"https://github.com/inorganik/countUp.js.git",
                @"c86547a4abf3263c5116c2c07448d4352a3a2be3")]
        [TestCase(@"https://github.com/soulwire/fit.js.git",
                @"74b6ef79a5cb1cda95a88c4b0c467c1c2eadbd54")]
        [TestCase(@"https://github.com/gulpjs/gulp.git",
                @"c2d02113d2b978e4565b9545495d3d9953ea4430")]
        [TestCase(@"https://github.com/driftyco/ionic.git",
                @"3a577129e932a42bb6c1de6b3808ca70764f4e92")]
        [TestCase(@"https://github.com/blueimp/jQuery-File-Upload.git",
                @"8dc29ded32a0f2caad86ebbdf8b23a22375ae78c")]
        [TestCase(@"https://github.com/ondras/my-mind.git",
                @"19500978c610429b292d094df9c1aa599c2cb3fb")]
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