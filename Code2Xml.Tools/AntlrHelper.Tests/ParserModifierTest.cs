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

using NUnit.Framework;

namespace Code2Xml.Tools.AntlrHelper.Tests {
    public class ParserModifierTest {
        [Test]
        public void RemoveUnusedCode() {
            const string code =
                    @"
root_0 = (object)adaptor.Nil();
System.out.println(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
retval.Tree = (object)adaptor.RulePostProcessing(root_0);
adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
adaptor.AddChild(root_0, string_literal68_tree);
";
            const string expected =
                    @"





";
            Assert.That(
                    ParserModifier.RemoveUnusedCode(code),
                    Is.EqualTo(expected));
        }

        [Test]
        public void ModifyInheritClass() {
            const string code =
                    @"public partial class LuaParser : Antlr.Runtime.Parser";
            const string expected =
                    @"public partial class LuaParser : Antlr.Runtime.Parser, ICustomizedAntlr3Parser";
            Assert.That(
                    ParserModifier.ModifyInheritClass(code),
                    Is.EqualTo(expected));
        }

        [Test]
        public void ModifyCommonTreeAdaptor() {
            const string code =
                    @"
ITreeAdaptor treeAdaptor = default(ITreeAdaptor);
TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();
";
            const string expected =
                    @"
CstBuilderForAntlr3 treeAdaptor = default(CstBuilderForAntlr3);
TreeAdaptor = treeAdaptor;
";
            Assert.That(
                    ParserModifier.ModifyCommonTreeAdaptor(code),
                    Is.EqualTo(expected));
        }

        [Test]
        public void ModifyAstParserRuleReturnScope() {
            const string code =
                    @"
public AstParserRuleReturnScope<object, IToken> chunk() {
AstParserRuleReturnScope<object, IToken> retval = new AstParserRuleReturnScope<object, IToken>();";
            const string expected =
                    @"
public CstNode chunk() {
";
            Assert.That(
                    ParserModifier.ModifyAstParserRuleReturnScope(code), Is.EqualTo(expected));
        }

        [Test]
        public void ModifyTraceIn() {
            const string code =
                    @"TraceIn(""typeParameters"", 11);";
            const string expected =
                    @"var retval = new CstNode(""typeParameters"");";
            Assert.That(
                    ParserModifier.ModifyTraceIn(code), Is.EqualTo(expected));
        }

        [Test]
        public void ModifyAddChild() {
            const string code =
                    @"if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree);";
            const string expected =
                    @"if ( state.backtracking == 0 ) adaptor.AddChild(retval, leftHandSideExpression159, ""leftHandSideExpression159"");";
            Assert.That(
                    ParserModifier.ModifyAddChild(code),
                    Is.EqualTo(expected));
        }

        [Test]
        public void ModifyCreate() {
            const string code =
                    @"
char_literal4_tree = (object)adaptor.Create(char_literal4);
if (state.backtracking == 0) adaptor.AddChild(root_0, (object)adaptor.Create(set157));
";
            const string expected =
                    @"
adaptor.Create(retval, char_literal4, ""char_literal4"");
if (state.backtracking == 0) adaptor.Create(retval, set157, ""set157"");
";
            Assert.That(
                    ParserModifier.ModifyCreate(code),
                    Is.EqualTo(expected));
        }

        [Test]
        public void ModifyRetval() {
            const string code =
                    @"
retval.Start = (IToken)input.LT(1);
retval.Stop = (IToken)input.LT(-1);
retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);
";
            const string expected =
                    @"
var retval_Start = (IToken)input.LT(1);

adaptor.ErrorNode(input, retval_Start, input.LT(-1), re);
";
            Assert.That(
                    ParserModifier.ModifyRetval(code),
                    Is.EqualTo(expected));
        }
    }
}