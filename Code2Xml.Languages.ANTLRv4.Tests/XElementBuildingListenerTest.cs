#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
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
using Antlr4.Runtime;
using Code2Xml.Languages.ANTLRv4.Core;
using Code2Xml.Languages.ANTLRv4.Processors.C;
using Code2Xml.Languages.ANTLRv4.Processors.Clojure;
using Code2Xml.Languages.ANTLRv4.Processors.Java;
using Code2Xml.Languages.ANTLRv4.Processors.Lua;
using Code2Xml.Languages.ANTLRv4.Processors.ObjectiveC;
using Code2Xml.Languages.ANTLRv4.Processors.R;
using Code2Xml.Languages.ANTLRv4.Processors.Verilog2001;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv4.Tests {
	[TestFixture]
	public class Antlr4AstBuilderTest {
		[Test]
		public void ParseC() {
			var inputStream = new AntlrInputStream(@"
int main(int argc, char **args) {
	printf(args[0]);
	return 0;
}");
			var lexer = new CLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new CParser(commonTokenStream);
			var listener = new Antlr4AstBuilder(parser);
			parser.AddParseListener(listener);
			parser.compilationUnit();
			Console.WriteLine(listener.FinishParsing());
		}

		[Test]
		public void ParseClojure() {
			var inputStream = new AntlrInputStream("(def lst '(a b c))");
			var lexer = new ClojureLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new ClojureParser(commonTokenStream);
			var listener = new Antlr4AstBuilder(parser);
			parser.AddParseListener(listener);
			parser.file();
			Console.WriteLine(listener.FinishParsing());
		}

		[Test]
		public void ParseJava() {
			var inputStream = new AntlrInputStream(@"
import javax.swing.*;
 
public class Hello extends JFrame {
    Hello() {
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        pack();
    }
 
    public static void main(String[] args) {
        new Hello().setVisible(true);
    }
}");
			var lexer = new JavaLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new JavaParser(commonTokenStream);
			var listener = new Antlr4AstBuilder(parser);
			parser.AddParseListener(listener);
			parser.compilationUnit();
			Console.WriteLine(listener.FinishParsing());
		}

		[Test]
		public void ParseLua() {
			var inputStream = new AntlrInputStream(@"
     do
       local t = {}
       t[f(1)] = g
       t[1] = 5         -- 1st exp
       t[2] = 2         -- 2nd exp
       t.x = 1          
       t[3] = f(x)      -- 3rd exp
       t[30] = 23
       t[4] = 45        -- 4th exp
       a = t
     end
");
			var lexer = new LuaLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new LuaParser(commonTokenStream);
			var listener = new Antlr4AstBuilder(parser);
			parser.AddParseListener(listener);
			parser.chunk();
			Console.WriteLine(listener.FinishParsing());
		}

		[Test]
		public void ParseObjectiveC() {
			var inputStream = new AntlrInputStream(
@"@interface MyObject : NSObject {
    int val;
    id obj;
}
 
+ (void)classMethod:(id)arg;
- (id)method:(NSObject*)arg1 with:(int)arg2;
@end");
			var lexer = new ObjectiveCLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new ObjectiveCParser(commonTokenStream);
			var listener = new Antlr4AstBuilder(parser);
			parser.AddParseListener(listener);
			parser.translation_unit();
			Console.WriteLine(listener.FinishParsing());
		}

		[Test]
		public void ParseR() {
			var inputStream = new AntlrInputStream(@"
x <- 1:3
y <- 2:4
z <- call('plot', x, y)
eval(z)
");
			var lexer = new RLexer(inputStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new RParser(commonTokenStream);
			var listener = new Antlr4AstBuilder(parser);
			parser.AddParseListener(listener);
			parser.prog();
			Console.WriteLine(listener.FinishParsing());
		}

		[Test]
		public void ParseVerilog2001() {
			var inputStream = new AntlrInputStream(@"
module generate_example();

reg read,write = 0;
reg [31:0] data_in  = 0;
reg [3:0] address = 0;
wire [31:0] data_out;

initial begin
  $monitor ($time, read, write, address, data_in, data_out);
   #1  read = 0; // why only for read
   #3  repeat (16) begin
    data_in = $random;
    write = 1;
     #1  address = address + 1;
  end
  write = 0;
  address = 0;
   #3  repeat (16) begin
    read = 1;
     #1  address = address + 1;
  end
  read = 0;
   #1  $finish;
end  

endmodule
");
			var lexer = new Verilog2001Lexer(inputStream);
			var commonTokenStream = new CommonTokenStream(lexer);
			var parser = new Verilog2001Parser(commonTokenStream);
			var listener = new Antlr4AstBuilder(parser);
			parser.AddParseListener(listener);
			parser.source_text();
			Console.WriteLine(listener.FinishParsing());
		}
	}
}