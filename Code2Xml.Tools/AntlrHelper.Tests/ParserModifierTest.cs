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

using NUnit.Framework;

namespace Code2Xml.Tools.AntlrHelper.Tests {
	public class ParserModifierTest {
		[Test]
		public void JavaコードをCSharpコードに変換できる() {
			const string code =
					@"
if (declaration_stack.size()>0&&((declaration_scope)declaration_stack.Peek()).isTypedef) {
	((Symbols_scope)Symbols_stack.Peek()).types.add(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
	System.out.println(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
}
";
			const string expected =
					@"
if (declaration_stack.size()>0&&((declaration_scope)declaration_stack.Peek()).isTypedef) {
	((Symbols_scope)Symbols_stack.Peek()).types.add(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
	
}
";
			Assert.That(
					ParserModifier.ModifyFromJavaToCSharp(code),
					Is.EqualTo(expected));
		}

		[Test]
		public void 非終端ノード用のメソッドを置き換える() {
			const string code =
					@"if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree);";
			const string expected =
					@"if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree, leftHandSideExpression159, retval);";
			Assert.That(
					ParserModifier.ModifyForNonTerminalNode(code),
					Is.EqualTo(expected));
		}

		[Test]
		public void 終端ノード用のメソッドを置き換える() {
			const string code =
					@"
						string_literal29=(IToken)Match(input,34,FOLLOW_34_in_type_specifier357); if (state.failed) return retval;
				IDENTIFIER38=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_type_id415); if (state.failed) return retval;
{string_literal17_tree = (object)adaptor.Create(string_literal17);";
			const string expected =
					@"
						string_literal29=(IToken)Match(input,34,FOLLOW_34_in_type_specifier357); if (state.failed) return retval;
				IDENTIFIER38=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_type_id415), "
							+
							"\"IDENTIFIER\"" +
							@"); if (state.failed) return retval;
{string_literal17_tree = (object)adaptor.Create(string_literal17, retval);";
			Assert.That(
					ParserModifier.ModifyForTerminalNode(code),
					Is.EqualTo(expected));
		}

		[Test]
		public void ParserRuleReturnScopeを置き換える() {
			const string code =
					@"    public class compilationUnit_return : ParserRuleReturnScope<IToken>";
			const string expected =
					@"    public class compilationUnit_return : XParserRuleReturnScope";
			Assert.That(
					ParserModifier.ModifyReturnScope(code), Is.EqualTo(expected));
		}

		[Test]
		public void CommonTreeAdapterを置き換える() {
			const string code =
					@"
	protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

	public ITreeAdaptor TreeAdaptor
	{
		get { return this.adaptor; }
		set {
		this.adaptor = value;
		}
	}";
			const string expected =
					@"
	protected XmlTreeAdaptor adaptor = new XmlTreeAdaptor();

	public XmlTreeAdaptor TreeAdaptor
	{
		get { return this.adaptor; }
		set {
		this.adaptor = value;
		}
	}";
			Assert.That(
					ParserModifier.ModifyCommonTreeAdaptorRegex(code),
					Is.EqualTo(expected));
		}

		[Test]
		public void Parseメソッドのアクセス修飾子を変更する() {
			const string code =
					@"
	private JavaScriptParser.program_return program()
	{
	}";
			const string expected =
					@"
	public JavaScriptParser.program_return program()
	{
	}";
			Assert.That(
					ParserModifier.ModifyAccessModifier(code),
					Is.EqualTo(expected));
		}

		[Test]
		public void Parseメソッドのアクセス修飾子を変更する2() {
			const string code =
					@"private AstParserRuleReturnScope";
			const string expected =
					@"public AstParserRuleReturnScope";
			Assert.That(
					ParserModifier.ModifyAccessModifier(code),
					Is.EqualTo(expected));
		}

		[Test]
		public void XAstParserRuleReturnScopeの生成() {
			const string code =
					@"TraceIn(" + "\"prog\""
							+
							@", 2);
					Symbols_stack.Push(new Symbols_scope(this));Symbols_scopeInit(Symbols_stack.Peek());
					AstParserRuleReturnScope<object, IToken> retval = new AstParserRuleReturnScope<object, IToken>();";
			const string expected =
					"var retval = new XAstParserRuleReturnScope(\"prog\");" + @"
					Symbols_stack.Push(new Symbols_scope(this));Symbols_scopeInit(Symbols_stack.Peek());
					";
			Assert.That(
					ParserModifier.ModifyTraceIn(code),
					Is.EqualTo(expected));
		}
	}
}