using System.IO;
using Antlr.Runtime;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using NUnit.Framework;

namespace Code2Xml.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptCodeToXmlTest {
		[Test]
		public void 一行のExpressionStatementをパースできる() {
			JavaScriptCodeToXml.Instance.Generate("((i = 1))", true);
		}

		[Test]
		public void functionをパースできる() {
			JavaScriptCodeToXml.Instance.Generate(@"function(name) { this.name = name; }");
		}

		[Test]
		public void 記号なしの文字列をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(@"quickExpr = 'a'");
			JavaScriptCodeToXml.Instance.Generate("quickExpr = \"a\"");
		}

		[Test]
		public void シャープの文字列をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(@"quickExpr = '#'", true);
		}

		[Test]
		public void エスケープ文字が含まれた文字列をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(@"quickExpr = 'aaaa\naaa\w\Waaa\'a'",
				true);
			JavaScriptCodeToXml.Instance.Generate(
				"quickExpr = \"aaaa\\naaa\\w\\Waaa\\\"a\"", true);
		}

		[Test]
		public void 記号が含まれた文字列をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(
				@"quickExpr = '^(?:[^<]*(<[\w]+>)[^>]*$|([\w]*)$)'", true);
			JavaScriptCodeToXml.Instance.Generate(
				"quickExpr = \"^(?:[^<]*(<[\\w]+>)[^>]*$|([\\w]*)$)\"", true);
		}

		[Test]
		public void 記号なしの正規表現をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(@"quickExpr = /a/", true);
		}

		[Test]
		public void シャープの正規表現をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(@"quickExpr = /#/", true);
		}

		[Test]
		public void エスケープ文字列が含まれたの正規表現をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(@"quickExpr = /\w\W\/\-/", true);
		}

		[Test]
		public void 記号が含まれた正規表現をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(
				@"quickExpr = /^(?:[^<]*(<[\w]+>)[^>]*$|([\w]*)$)/", true);
			JavaScriptCodeToXml.Instance.Generate(
				@"rsingleTag = /^<(\w+)\s*\/?>(?:<\/\1>)?$/", true);
		}

		[Test]
		public void jQueryのコード片をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(
				@"if ( first === 0 ) { return diff === 0; } else { return ( diff % first === 0 && diff / first >= 0 ); }",
				true);
			JavaScriptCodeToXml.Instance.Generate(
				"{ a = 0 }",
				false);
			JavaScriptCodeToXml.Instance.Generate(
			    "function cv(a){if(!cj[a]){var b=f(\"<\"+a+\">\").appendTo(\"body\"),d=b.css(\"display\");b.remove();if(d===\"none\"||d===\"\"){ck||(ck=c.createElement(\"iframe\"),ck.frameBorder=ck.width=ck.height=0),c.body.appendChild(ck);if(!cl||!ck.createElement)cl=(ck.contentWindow||ck.contentDocument).document,cl.write(\"<!doctype><html><body></body></html>\");b=cl.createElement(a),cl.body.appendChild(b),d=f.css(b,\"display\"),c.body.removeChild(ck)}cj[a]=d}return cj[a]}",
			    true);
		}

		[Test]
		public void 空のオブジェクトリテラルをパースできる() {
			JavaScriptCodeToXml.Instance.Generate(
				@"class2type = {};",
				true);
		}

		[Test]
		public void ユニコードのエスケープ文字をパースできる() {
			JavaScriptCodeToXml.Instance.Generate(
				'"' + @" \t\n\r\f\u00A0" + '"', true);
		}

		[Test]
		public void 除算() {
			JavaScriptCodeToXml.Instance.Generate(
				@"[ 1 / 1 ]", true);
		}

		[Test]
		public void ブロック() {
			JavaScriptCodeToXml.Instance.Generate(
				@"{1}", true);
		}

		[Test]
		public void 連続ブロック() {
			JavaScriptCodeToXml.Instance.Generate(
				@"{1}{2}", true);
		}

		[Test]
		public void ブロックと式の連続() {
			JavaScriptCodeToXml.Instance.Generate(
				@"{1}2", true);
		}

		[Test]
		public void 改行の入る文字列() {
			JavaScriptCodeToXml.Instance.Generate(
				"a = \"a\\\nb\"", true);
		}

		[Test]
		public void 変数宣言と改行() {
			JavaScriptCodeToXml.Instance.Generate(
				"var a\na = 0", true);
		}
	}
}