using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests
{
	[TestFixture]
    public class Class1
    {
		[Test]
		public void Test() {
			var inputStream = new AntlrInputStream("public class Klass { }");
			var javaLexer = new JavaLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(javaLexer);
			var javaParser = new JavaParser(commonTokenStream);
			var context = javaParser.compilationUnit();
			var visitor = new JavaVisitor();
			visitor.VisitCompilationUnit(context);
			var result = visitor.Root;
			Console.WriteLine(result);
		}
		[Test]
		public void TestLua() {
			var inputStream = new AntlrInputStream("a = 1");
			var LuaLexer = new LuaLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(LuaLexer);
			var LuaParser = new LuaParser(commonTokenStream);
			var context = LuaParser.chunk();
			var visitor = new LuaVisitor();
			visitor.VisitChunk(context);
			var result = visitor.Root;
			Console.WriteLine(result);
		}
    }
}
