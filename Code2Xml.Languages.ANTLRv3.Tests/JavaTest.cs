using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests
{
	[TestFixture]
    public class JavaTest
    {
		[Test]
		public void Test() {
			var charStream = new ANTLRStringStream("class A { }");
			var lexer = new JavaLexer(charStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new JavaParser(commonTokenStream);
			parser.Listener = new Antlr3Listener(lexer, parser, true);
			lexer.Listener = parser.Listener;
			parser.compilationUnit();
			var ast = lexer.Listener.FinishParsing();
			Console.WriteLine(ast);
		}
    }
}
