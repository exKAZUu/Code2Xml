using Code2Xml.Core.Antlr;
using System;
// $ANTLR 3.3 Nov 30, 2010 12:50:56 JavaScript.g 2011-10-01 18:49:12

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;
using Map = System.Collections.IDictionary;
using HashMap = System.Collections.Generic.Dictionary<object, object>;

using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class JavaScriptParser : Antlr.Runtime.Parser, IAntlrParser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "NULL", "TRUE", "FALSE", "THIS", "RBRACK", "RPAREN", "RBRACE", "LT", "Comment", "LineComment", "Identifier", "NumericLiteral", "StringLiteral", "RegularExpressionLiteral", "DoubleStringCharacter", "SingleStringCharacter", "ContinuousLineCharacter", "EscapeSequence", "CharacterEscapeSequence", "HexEscapeSequence", "UnicodeEscapeSequence", "SingleEscapeCharacter", "NonEscapeCharacter", "EscapeCharacter", "DecimalDigit", "HexDigit", "DecimalLiteral", "HexIntegerLiteral", "ExponentPart", "IdentifierStart", "IdentifierPart", "UnicodeLetter", "UnicodeDigit", "UnicodeConnectorPunctuation", "UnicodeCombiningMark", "WhiteSpace", "RegularExpressionFirstChar", "RegularExpressionChar", "RegularExpressionInnerChar", "';'", "'function'", "'('", "','", "'{'", "'var'", "'='", "'if'", "'else'", "'do'", "'while'", "'for'", "'in'", "'continue'", "'break'", "'return'", "'with'", "':'", "'switch'", "'case'", "'default'", "'throw'", "'try'", "'catch'", "'finally'", "'new'", "'['", "'.'", "'*='", "'/='", "'%='", "'+='", "'-='", "'<<='", "'>>='", "'>>>='", "'&='", "'^='", "'|='", "'?'", "'||'", "'&&'", "'|'", "'^'", "'&'", "'=='", "'!='", "'==='", "'!=='", "'<'", "'>'", "'<='", "'>='", "'instanceof'", "'<<'", "'>>'", "'>>>'", "'+'", "'-'", "'*'", "'/'", "'%'", "'delete'", "'void'", "'typeof'", "'++'", "'--'", "'~'", "'!'"
	};
	public const int EOF=-1;
	public const int T__43=43;
	public const int T__44=44;
	public const int T__45=45;
	public const int T__46=46;
	public const int T__47=47;
	public const int T__48=48;
	public const int T__49=49;
	public const int T__50=50;
	public const int T__51=51;
	public const int T__52=52;
	public const int T__53=53;
	public const int T__54=54;
	public const int T__55=55;
	public const int T__56=56;
	public const int T__57=57;
	public const int T__58=58;
	public const int T__59=59;
	public const int T__60=60;
	public const int T__61=61;
	public const int T__62=62;
	public const int T__63=63;
	public const int T__64=64;
	public const int T__65=65;
	public const int T__66=66;
	public const int T__67=67;
	public const int T__68=68;
	public const int T__69=69;
	public const int T__70=70;
	public const int T__71=71;
	public const int T__72=72;
	public const int T__73=73;
	public const int T__74=74;
	public const int T__75=75;
	public const int T__76=76;
	public const int T__77=77;
	public const int T__78=78;
	public const int T__79=79;
	public const int T__80=80;
	public const int T__81=81;
	public const int T__82=82;
	public const int T__83=83;
	public const int T__84=84;
	public const int T__85=85;
	public const int T__86=86;
	public const int T__87=87;
	public const int T__88=88;
	public const int T__89=89;
	public const int T__90=90;
	public const int T__91=91;
	public const int T__92=92;
	public const int T__93=93;
	public const int T__94=94;
	public const int T__95=95;
	public const int T__96=96;
	public const int T__97=97;
	public const int T__98=98;
	public const int T__99=99;
	public const int T__100=100;
	public const int T__101=101;
	public const int T__102=102;
	public const int T__103=103;
	public const int T__104=104;
	public const int T__105=105;
	public const int T__106=106;
	public const int T__107=107;
	public const int T__108=108;
	public const int T__109=109;
	public const int T__110=110;
	public const int T__111=111;
	public const int NULL=4;
	public const int TRUE=5;
	public const int FALSE=6;
	public const int THIS=7;
	public const int RBRACK=8;
	public const int RPAREN=9;
	public const int RBRACE=10;
	public const int LT=11;
	public const int Comment=12;
	public const int LineComment=13;
	public const int Identifier=14;
	public const int NumericLiteral=15;
	public const int StringLiteral=16;
	public const int RegularExpressionLiteral=17;
	public const int DoubleStringCharacter=18;
	public const int SingleStringCharacter=19;
	public const int ContinuousLineCharacter=20;
	public const int EscapeSequence=21;
	public const int CharacterEscapeSequence=22;
	public const int HexEscapeSequence=23;
	public const int UnicodeEscapeSequence=24;
	public const int SingleEscapeCharacter=25;
	public const int NonEscapeCharacter=26;
	public const int EscapeCharacter=27;
	public const int DecimalDigit=28;
	public const int HexDigit=29;
	public const int DecimalLiteral=30;
	public const int HexIntegerLiteral=31;
	public const int ExponentPart=32;
	public const int IdentifierStart=33;
	public const int IdentifierPart=34;
	public const int UnicodeLetter=35;
	public const int UnicodeDigit=36;
	public const int UnicodeConnectorPunctuation=37;
	public const int UnicodeCombiningMark=38;
	public const int WhiteSpace=39;
	public const int RegularExpressionFirstChar=40;
	public const int RegularExpressionChar=41;
	public const int RegularExpressionInnerChar=42;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				true, false, false, false, false, true, false, false, false, true, 
				false, false, false, false, false, false, false, false, false, true, 
				false, false, true, true, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, true, true, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, true, true, true, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, true, false, 
				false, true, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, true, false, false, true, true, false, true, false, false, false, 
				false, true, false, false, false, true, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, true, false, false, false, false, false, false, 
				false, false, true, false, false, false, false, false, false, true, 
				false, false, false, false, false, false, false, false, false, false, 
				, , , , , , , , , , , , , , false, false, , , , , , , , , , , , , , 
				false, false, , , , , , , , , , , , , , , , , , , , , , , , , , , , 
				, , , , , , , , , , , , , , , , , false, false, , , , , , , , , , 
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public JavaScriptParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public JavaScriptParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		this.state.ruleMemo = new System.Collections.Generic.Dictionary<int, int>[386+1];

		XmlTreeAdaptor treeAdaptor = null;
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new XmlTreeAdaptor();

		OnCreated();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref XmlTreeAdaptor adaptor);

	private XmlTreeAdaptor adaptor;

	public XmlTreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return JavaScriptParser.tokenNames; } }
	public override string GrammarFileName { get { return "JavaScript.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class statementEnd_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statementEnd();
	partial void Leave_statementEnd();

	// $ANTLR start "statementEnd"
	// JavaScript.g:30:1: statementEnd : ( ';' | LT | Comment | LineComment | EOF | {...}?);
	[GrammarRule("statementEnd")]
	public JavaScriptParser.statementEnd_return statementEnd()
	{
		Enter_statementEnd();
		EnterRule("statementEnd", 1);
		TraceIn("statementEnd", 1);
		JavaScriptParser.statementEnd_return retval = new JavaScriptParser.statementEnd_return();
		retval.Start = (IToken)input.LT(1);
		int statementEnd_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal1=null;
		IToken LT2=null;
		IToken Comment3=null;
		IToken LineComment4=null;
		IToken EOF5=null;

		object char_literal1_tree=null;
		object LT2_tree=null;
		object Comment3_tree=null;
		object LineComment4_tree=null;
		object EOF5_tree=null;

		try { DebugEnterRule(GrammarFileName, "statementEnd");
		DebugLocation(30, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 1)) { return retval; }
			// JavaScript.g:31:2: ( ';' | LT | Comment | LineComment | EOF | {...}?)
			int alt1=6;
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			try
			{
				alt1 = dfa1.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:31:4: ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(31, 4);
				char_literal1=(IToken)Match(input,43,Follow._43_in_statementEnd122); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal1_tree = (object)adaptor.Create(char_literal1, retval);
				adaptor.AddChild(root_0, char_literal1_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:32:4: LT
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(32, 4);
				LT2=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_statementEnd127), "LT"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				LT2_tree = (object)adaptor.Create(LT2, retval);
				adaptor.AddChild(root_0, LT2_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:33:4: Comment
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(33, 4);
				Comment3=(IToken)new XToken((IToken)Match(input,Comment,Follow._Comment_in_statementEnd132), "Comment"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				Comment3_tree = (object)adaptor.Create(Comment3, retval);
				adaptor.AddChild(root_0, Comment3_tree);
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// JavaScript.g:34:4: LineComment
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(34, 4);
				LineComment4=(IToken)new XToken((IToken)Match(input,LineComment,Follow._LineComment_in_statementEnd137), "LineComment"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				LineComment4_tree = (object)adaptor.Create(LineComment4, retval);
				adaptor.AddChild(root_0, LineComment4_tree);
				}

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// JavaScript.g:35:4: EOF
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(35, 7);
				EOF5=(IToken)new XToken((IToken)Match(input,EOF,Follow._EOF_in_statementEnd142), "EOF"); if (state.failed) return retval;

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// JavaScript.g:36:4: {...}?
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(36, 4);
				if (!(( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )))
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					throw new FailedPredicateException(input, "statementEnd", " input.LA(-1) == RBRACE || input.LA(1) == RBRACE ");
				}

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("statementEnd", 1);
			LeaveRule("statementEnd", 1);
			Leave_statementEnd();
			if (state.backtracking > 0) { Memoize(input, 1, statementEnd_StartIndex); }
		}
		DebugLocation(37, 1);
		} finally { DebugExitRule(GrammarFileName, "statementEnd"); }
		return retval;

	}
	// $ANTLR end "statementEnd"

	public class program_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_program();
	partial void Leave_program();

	// $ANTLR start "program"
	// JavaScript.g:39:1: program : ( LT )* sourceElements ( LT )* EOF ;
	[GrammarRule("program")]
	public JavaScriptParser.program_return program()
	{
		Enter_program();
		EnterRule("program", 2);
		TraceIn("program", 2);
		JavaScriptParser.program_return retval = new JavaScriptParser.program_return();
		retval.Start = (IToken)input.LT(1);
		int program_StartIndex = input.Index;
		object root_0 = null;

		IToken LT6=null;
		IToken LT8=null;
		IToken EOF9=null;
		JavaScriptParser.sourceElements_return sourceElements7 = default(JavaScriptParser.sourceElements_return);

		object LT6_tree=null;
		object LT8_tree=null;
		object EOF9_tree=null;

		try { DebugEnterRule(GrammarFileName, "program");
		DebugLocation(39, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 2)) { return retval; }
			// JavaScript.g:40:2: ( ( LT )* sourceElements ( LT )* EOF )
			DebugEnterAlt(1);
			// JavaScript.g:40:4: ( LT )* sourceElements ( LT )* EOF
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(40, 6);
			// JavaScript.g:40:6: ( LT )*
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if ((LA2_0==LT))
				{
					alt2=1;
				}


				} finally { DebugExitDecision(2); }
				switch ( alt2 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(40, 6);
					LT6=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_program159), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;

			} finally { DebugExitSubRule(2); }

			DebugLocation(40, 9);
			PushFollow(Follow._sourceElements_in_program163);
			sourceElements7=sourceElements();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElements7.Tree, sourceElements7, retval);
			DebugLocation(40, 26);
			// JavaScript.g:40:26: ( LT )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0==LT))
				{
					alt3=1;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(40, 26);
					LT8=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_program165), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }

			DebugLocation(40, 32);
			EOF9=(IToken)new XToken((IToken)Match(input,EOF,Follow._EOF_in_program169), "EOF"); if (state.failed) return retval;

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("program", 2);
			LeaveRule("program", 2);
			Leave_program();
			if (state.backtracking > 0) { Memoize(input, 2, program_StartIndex); }
		}
		DebugLocation(41, 1);
		} finally { DebugExitRule(GrammarFileName, "program"); }
		return retval;

	}
	// $ANTLR end "program"

	public class sourceElements_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_sourceElements();
	partial void Leave_sourceElements();

	// $ANTLR start "sourceElements"
	// JavaScript.g:43:1: sourceElements : sourceElement ( ( LT )* sourceElement )* ;
	[GrammarRule("sourceElements")]
	public JavaScriptParser.sourceElements_return sourceElements()
	{
		Enter_sourceElements();
		EnterRule("sourceElements", 3);
		TraceIn("sourceElements", 3);
		JavaScriptParser.sourceElements_return retval = new JavaScriptParser.sourceElements_return();
		retval.Start = (IToken)input.LT(1);
		int sourceElements_StartIndex = input.Index;
		object root_0 = null;

		IToken LT11=null;
		JavaScriptParser.sourceElement_return sourceElement10 = default(JavaScriptParser.sourceElement_return);
		JavaScriptParser.sourceElement_return sourceElement12 = default(JavaScriptParser.sourceElement_return);

		object LT11_tree=null;

		try { DebugEnterRule(GrammarFileName, "sourceElements");
		DebugLocation(43, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 3)) { return retval; }
			// JavaScript.g:44:2: ( sourceElement ( ( LT )* sourceElement )* )
			DebugEnterAlt(1);
			// JavaScript.g:44:4: sourceElement ( ( LT )* sourceElement )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(44, 4);
			PushFollow(Follow._sourceElement_in_sourceElements182);
			sourceElement10=sourceElement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElement10.Tree, sourceElement10, retval);
			DebugLocation(44, 18);
			// JavaScript.g:44:18: ( ( LT )* sourceElement )*
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
				try
				{
					alt5 = dfa5.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(5); }
				switch ( alt5 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:44:19: ( LT )* sourceElement
					{
					DebugLocation(44, 21);
					// JavaScript.g:44:21: ( LT )*
					try { DebugEnterSubRule(4);
					while (true)
					{
						int alt4=2;
						try { DebugEnterDecision(4, decisionCanBacktrack[4]);
						int LA4_0 = input.LA(1);

						if ((LA4_0==LT))
						{
							alt4=1;
						}


						} finally { DebugExitDecision(4); }
						switch ( alt4 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(44, 21);
							LT11=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_sourceElements185), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop4;
						}
					}

					loop4:
						;

					} finally { DebugExitSubRule(4); }

					DebugLocation(44, 24);
					PushFollow(Follow._sourceElement_in_sourceElements189);
					sourceElement12=sourceElement();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElement12.Tree, sourceElement12, retval);

					}
					break;

				default:
					goto loop5;
				}
			}

			loop5:
				;

			} finally { DebugExitSubRule(5); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("sourceElements", 3);
			LeaveRule("sourceElements", 3);
			Leave_sourceElements();
			if (state.backtracking > 0) { Memoize(input, 3, sourceElements_StartIndex); }
		}
		DebugLocation(45, 1);
		} finally { DebugExitRule(GrammarFileName, "sourceElements"); }
		return retval;

	}
	// $ANTLR end "sourceElements"

	public class sourceElement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_sourceElement();
	partial void Leave_sourceElement();

	// $ANTLR start "sourceElement"
	// JavaScript.g:47:1: sourceElement : ( functionDeclaration | statement );
	[GrammarRule("sourceElement")]
	public JavaScriptParser.sourceElement_return sourceElement()
	{
		Enter_sourceElement();
		EnterRule("sourceElement", 4);
		TraceIn("sourceElement", 4);
		JavaScriptParser.sourceElement_return retval = new JavaScriptParser.sourceElement_return();
		retval.Start = (IToken)input.LT(1);
		int sourceElement_StartIndex = input.Index;
		object root_0 = null;

		JavaScriptParser.functionDeclaration_return functionDeclaration13 = default(JavaScriptParser.functionDeclaration_return);
		JavaScriptParser.statement_return statement14 = default(JavaScriptParser.statement_return);


		try { DebugEnterRule(GrammarFileName, "sourceElement");
		DebugLocation(47, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 4)) { return retval; }
			// JavaScript.g:48:2: ( functionDeclaration | statement )
			int alt6=2;
			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			try
			{
				alt6 = dfa6.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:48:4: functionDeclaration
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(48, 4);
				PushFollow(Follow._functionDeclaration_in_sourceElement203);
				functionDeclaration13=functionDeclaration();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionDeclaration13.Tree, functionDeclaration13, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:49:4: statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(49, 4);
				PushFollow(Follow._statement_in_sourceElement208);
				statement14=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement14.Tree, statement14, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("sourceElement", 4);
			LeaveRule("sourceElement", 4);
			Leave_sourceElement();
			if (state.backtracking > 0) { Memoize(input, 4, sourceElement_StartIndex); }
		}
		DebugLocation(50, 1);
		} finally { DebugExitRule(GrammarFileName, "sourceElement"); }
		return retval;

	}
	// $ANTLR end "sourceElement"

	public class functionDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_functionDeclaration();
	partial void Leave_functionDeclaration();

	// $ANTLR start "functionDeclaration"
	// JavaScript.g:53:1: functionDeclaration : 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody ;
	[GrammarRule("functionDeclaration")]
	public JavaScriptParser.functionDeclaration_return functionDeclaration()
	{
		Enter_functionDeclaration();
		EnterRule("functionDeclaration", 5);
		TraceIn("functionDeclaration", 5);
		JavaScriptParser.functionDeclaration_return retval = new JavaScriptParser.functionDeclaration_return();
		retval.Start = (IToken)input.LT(1);
		int functionDeclaration_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal15=null;
		IToken LT16=null;
		IToken Identifier17=null;
		IToken LT18=null;
		IToken LT20=null;
		JavaScriptParser.formalParameterList_return formalParameterList19 = default(JavaScriptParser.formalParameterList_return);
		JavaScriptParser.functionBody_return functionBody21 = default(JavaScriptParser.functionBody_return);

		object string_literal15_tree=null;
		object LT16_tree=null;
		object Identifier17_tree=null;
		object LT18_tree=null;
		object LT20_tree=null;

		try { DebugEnterRule(GrammarFileName, "functionDeclaration");
		DebugLocation(53, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 5)) { return retval; }
			// JavaScript.g:54:2: ( 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody )
			DebugEnterAlt(1);
			// JavaScript.g:54:4: 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(54, 4);
			string_literal15=(IToken)Match(input,44,Follow._44_in_functionDeclaration221); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal15_tree = (object)adaptor.Create(string_literal15, retval);
			adaptor.AddChild(root_0, string_literal15_tree);
			}
			DebugLocation(54, 17);
			// JavaScript.g:54:17: ( LT )*
			try { DebugEnterSubRule(7);
			while (true)
			{
				int alt7=2;
				try { DebugEnterDecision(7, decisionCanBacktrack[7]);
				int LA7_0 = input.LA(1);

				if ((LA7_0==LT))
				{
					alt7=1;
				}


				} finally { DebugExitDecision(7); }
				switch ( alt7 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(54, 17);
					LT16=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionDeclaration223), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop7;
				}
			}

			loop7:
				;

			} finally { DebugExitSubRule(7); }

			DebugLocation(54, 20);
			Identifier17=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_functionDeclaration227), "Identifier"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			Identifier17_tree = (object)adaptor.Create(Identifier17, retval);
			adaptor.AddChild(root_0, Identifier17_tree);
			}
			DebugLocation(54, 33);
			// JavaScript.g:54:33: ( LT )*
			try { DebugEnterSubRule(8);
			while (true)
			{
				int alt8=2;
				try { DebugEnterDecision(8, decisionCanBacktrack[8]);
				int LA8_0 = input.LA(1);

				if ((LA8_0==LT))
				{
					alt8=1;
				}


				} finally { DebugExitDecision(8); }
				switch ( alt8 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(54, 33);
					LT18=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionDeclaration229), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop8;
				}
			}

			loop8:
				;

			} finally { DebugExitSubRule(8); }

			DebugLocation(54, 36);
			PushFollow(Follow._formalParameterList_in_functionDeclaration233);
			formalParameterList19=formalParameterList();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameterList19.Tree, formalParameterList19, retval);
			DebugLocation(54, 58);
			// JavaScript.g:54:58: ( LT )*
			try { DebugEnterSubRule(9);
			while (true)
			{
				int alt9=2;
				try { DebugEnterDecision(9, decisionCanBacktrack[9]);
				int LA9_0 = input.LA(1);

				if ((LA9_0==LT))
				{
					alt9=1;
				}


				} finally { DebugExitDecision(9); }
				switch ( alt9 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(54, 58);
					LT20=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionDeclaration235), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop9;
				}
			}

			loop9:
				;

			} finally { DebugExitSubRule(9); }

			DebugLocation(54, 61);
			PushFollow(Follow._functionBody_in_functionDeclaration239);
			functionBody21=functionBody();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionBody21.Tree, functionBody21, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("functionDeclaration", 5);
			LeaveRule("functionDeclaration", 5);
			Leave_functionDeclaration();
			if (state.backtracking > 0) { Memoize(input, 5, functionDeclaration_StartIndex); }
		}
		DebugLocation(55, 1);
		} finally { DebugExitRule(GrammarFileName, "functionDeclaration"); }
		return retval;

	}
	// $ANTLR end "functionDeclaration"

	public class functionExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_functionExpression();
	partial void Leave_functionExpression();

	// $ANTLR start "functionExpression"
	// JavaScript.g:57:1: functionExpression : 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody ;
	[GrammarRule("functionExpression")]
	public JavaScriptParser.functionExpression_return functionExpression()
	{
		Enter_functionExpression();
		EnterRule("functionExpression", 6);
		TraceIn("functionExpression", 6);
		JavaScriptParser.functionExpression_return retval = new JavaScriptParser.functionExpression_return();
		retval.Start = (IToken)input.LT(1);
		int functionExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal22=null;
		IToken LT23=null;
		IToken Identifier24=null;
		IToken LT25=null;
		IToken LT27=null;
		JavaScriptParser.formalParameterList_return formalParameterList26 = default(JavaScriptParser.formalParameterList_return);
		JavaScriptParser.functionBody_return functionBody28 = default(JavaScriptParser.functionBody_return);

		object string_literal22_tree=null;
		object LT23_tree=null;
		object Identifier24_tree=null;
		object LT25_tree=null;
		object LT27_tree=null;

		try { DebugEnterRule(GrammarFileName, "functionExpression");
		DebugLocation(57, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 6)) { return retval; }
			// JavaScript.g:58:2: ( 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody )
			DebugEnterAlt(1);
			// JavaScript.g:58:4: 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(58, 4);
			string_literal22=(IToken)Match(input,44,Follow._44_in_functionExpression251); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal22_tree = (object)adaptor.Create(string_literal22, retval);
			adaptor.AddChild(root_0, string_literal22_tree);
			}
			DebugLocation(58, 17);
			// JavaScript.g:58:17: ( LT )*
			try { DebugEnterSubRule(10);
			while (true)
			{
				int alt10=2;
				try { DebugEnterDecision(10, decisionCanBacktrack[10]);
				int LA10_0 = input.LA(1);

				if ((LA10_0==LT))
				{
					int LA10_2 = input.LA(2);

					if ((EvaluatePredicate(synpred14_JavaScript_fragment)))
					{
						alt10=1;
					}


				}


				} finally { DebugExitDecision(10); }
				switch ( alt10 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(58, 17);
					LT23=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionExpression253), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop10;
				}
			}

			loop10:
				;

			} finally { DebugExitSubRule(10); }

			DebugLocation(58, 20);
			// JavaScript.g:58:20: ( Identifier )?
			int alt11=2;
			try { DebugEnterSubRule(11);
			try { DebugEnterDecision(11, decisionCanBacktrack[11]);
			int LA11_0 = input.LA(1);

			if ((LA11_0==Identifier))
			{
				alt11=1;
			}
			} finally { DebugExitDecision(11); }
			switch (alt11)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: Identifier
				{
				DebugLocation(58, 20);
				Identifier24=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_functionExpression257), "Identifier"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				Identifier24_tree = (object)adaptor.Create(Identifier24, retval);
				adaptor.AddChild(root_0, Identifier24_tree);
				}

				}
				break;

			}
			} finally { DebugExitSubRule(11); }

			DebugLocation(58, 34);
			// JavaScript.g:58:34: ( LT )*
			try { DebugEnterSubRule(12);
			while (true)
			{
				int alt12=2;
				try { DebugEnterDecision(12, decisionCanBacktrack[12]);
				int LA12_0 = input.LA(1);

				if ((LA12_0==LT))
				{
					alt12=1;
				}


				} finally { DebugExitDecision(12); }
				switch ( alt12 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(58, 34);
					LT25=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionExpression260), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop12;
				}
			}

			loop12:
				;

			} finally { DebugExitSubRule(12); }

			DebugLocation(58, 37);
			PushFollow(Follow._formalParameterList_in_functionExpression264);
			formalParameterList26=formalParameterList();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameterList26.Tree, formalParameterList26, retval);
			DebugLocation(58, 59);
			// JavaScript.g:58:59: ( LT )*
			try { DebugEnterSubRule(13);
			while (true)
			{
				int alt13=2;
				try { DebugEnterDecision(13, decisionCanBacktrack[13]);
				int LA13_0 = input.LA(1);

				if ((LA13_0==LT))
				{
					alt13=1;
				}


				} finally { DebugExitDecision(13); }
				switch ( alt13 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(58, 59);
					LT27=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionExpression266), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop13;
				}
			}

			loop13:
				;

			} finally { DebugExitSubRule(13); }

			DebugLocation(58, 62);
			PushFollow(Follow._functionBody_in_functionExpression270);
			functionBody28=functionBody();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionBody28.Tree, functionBody28, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("functionExpression", 6);
			LeaveRule("functionExpression", 6);
			Leave_functionExpression();
			if (state.backtracking > 0) { Memoize(input, 6, functionExpression_StartIndex); }
		}
		DebugLocation(59, 1);
		} finally { DebugExitRule(GrammarFileName, "functionExpression"); }
		return retval;

	}
	// $ANTLR end "functionExpression"

	public class formalParameterList_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_formalParameterList();
	partial void Leave_formalParameterList();

	// $ANTLR start "formalParameterList"
	// JavaScript.g:61:1: formalParameterList : '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* RPAREN ;
	[GrammarRule("formalParameterList")]
	public JavaScriptParser.formalParameterList_return formalParameterList()
	{
		Enter_formalParameterList();
		EnterRule("formalParameterList", 7);
		TraceIn("formalParameterList", 7);
		JavaScriptParser.formalParameterList_return retval = new JavaScriptParser.formalParameterList_return();
		retval.Start = (IToken)input.LT(1);
		int formalParameterList_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal29=null;
		IToken LT30=null;
		IToken Identifier31=null;
		IToken LT32=null;
		IToken char_literal33=null;
		IToken LT34=null;
		IToken Identifier35=null;
		IToken LT36=null;
		IToken RPAREN37=null;

		object char_literal29_tree=null;
		object LT30_tree=null;
		object Identifier31_tree=null;
		object LT32_tree=null;
		object char_literal33_tree=null;
		object LT34_tree=null;
		object Identifier35_tree=null;
		object LT36_tree=null;
		object RPAREN37_tree=null;

		try { DebugEnterRule(GrammarFileName, "formalParameterList");
		DebugLocation(61, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 7)) { return retval; }
			// JavaScript.g:62:2: ( '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* RPAREN )
			DebugEnterAlt(1);
			// JavaScript.g:62:4: '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* RPAREN
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(62, 4);
			char_literal29=(IToken)Match(input,45,Follow._45_in_formalParameterList282); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal29_tree = (object)adaptor.Create(char_literal29, retval);
			adaptor.AddChild(root_0, char_literal29_tree);
			}
			DebugLocation(62, 8);
			// JavaScript.g:62:8: ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )?
			int alt18=2;
			try { DebugEnterSubRule(18);
			try { DebugEnterDecision(18, decisionCanBacktrack[18]);
			try
			{
				alt18 = dfa18.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(18); }
			switch (alt18)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:62:9: ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )*
				{
				DebugLocation(62, 11);
				// JavaScript.g:62:11: ( LT )*
				try { DebugEnterSubRule(14);
				while (true)
				{
					int alt14=2;
					try { DebugEnterDecision(14, decisionCanBacktrack[14]);
					int LA14_0 = input.LA(1);

					if ((LA14_0==LT))
					{
						alt14=1;
					}


					} finally { DebugExitDecision(14); }
					switch ( alt14 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(62, 11);
						LT30=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_formalParameterList285), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop14;
					}
				}

				loop14:
					;

				} finally { DebugExitSubRule(14); }

				DebugLocation(62, 14);
				Identifier31=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_formalParameterList289), "Identifier"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				Identifier31_tree = (object)adaptor.Create(Identifier31, retval);
				adaptor.AddChild(root_0, Identifier31_tree);
				}
				DebugLocation(62, 25);
				// JavaScript.g:62:25: ( ( LT )* ',' ( LT )* Identifier )*
				try { DebugEnterSubRule(17);
				while (true)
				{
					int alt17=2;
					try { DebugEnterDecision(17, decisionCanBacktrack[17]);
					try
					{
						alt17 = dfa17.Predict(input);
					}
					catch (NoViableAltException nvae)
					{
						DebugRecognitionException(nvae);
						throw;
					}
					} finally { DebugExitDecision(17); }
					switch ( alt17 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:62:26: ( LT )* ',' ( LT )* Identifier
						{
						DebugLocation(62, 28);
						// JavaScript.g:62:28: ( LT )*
						try { DebugEnterSubRule(15);
						while (true)
						{
							int alt15=2;
							try { DebugEnterDecision(15, decisionCanBacktrack[15]);
							int LA15_0 = input.LA(1);

							if ((LA15_0==LT))
							{
								alt15=1;
							}


							} finally { DebugExitDecision(15); }
							switch ( alt15 )
							{
							case 1:
								DebugEnterAlt(1);
								// JavaScript.g:0:0: LT
								{
								DebugLocation(62, 28);
								LT32=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_formalParameterList292), "LT"); if (state.failed) return retval;

								}
								break;

							default:
								goto loop15;
							}
						}

						loop15:
							;

						} finally { DebugExitSubRule(15); }

						DebugLocation(62, 31);
						char_literal33=(IToken)Match(input,46,Follow._46_in_formalParameterList296); if (state.failed) return retval;
						if ( state.backtracking==0 ) {
						char_literal33_tree = (object)adaptor.Create(char_literal33, retval);
						adaptor.AddChild(root_0, char_literal33_tree);
						}
						DebugLocation(62, 37);
						// JavaScript.g:62:37: ( LT )*
						try { DebugEnterSubRule(16);
						while (true)
						{
							int alt16=2;
							try { DebugEnterDecision(16, decisionCanBacktrack[16]);
							int LA16_0 = input.LA(1);

							if ((LA16_0==LT))
							{
								alt16=1;
							}


							} finally { DebugExitDecision(16); }
							switch ( alt16 )
							{
							case 1:
								DebugEnterAlt(1);
								// JavaScript.g:0:0: LT
								{
								DebugLocation(62, 37);
								LT34=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_formalParameterList298), "LT"); if (state.failed) return retval;

								}
								break;

							default:
								goto loop16;
							}
						}

						loop16:
							;

						} finally { DebugExitSubRule(16); }

						DebugLocation(62, 40);
						Identifier35=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_formalParameterList302), "Identifier"); if (state.failed) return retval;
						if ( state.backtracking==0 ) {
						Identifier35_tree = (object)adaptor.Create(Identifier35, retval);
						adaptor.AddChild(root_0, Identifier35_tree);
						}

						}
						break;

					default:
						goto loop17;
					}
				}

				loop17:
					;

				} finally { DebugExitSubRule(17); }


				}
				break;

			}
			} finally { DebugExitSubRule(18); }

			DebugLocation(62, 57);
			// JavaScript.g:62:57: ( LT )*
			try { DebugEnterSubRule(19);
			while (true)
			{
				int alt19=2;
				try { DebugEnterDecision(19, decisionCanBacktrack[19]);
				int LA19_0 = input.LA(1);

				if ((LA19_0==LT))
				{
					alt19=1;
				}


				} finally { DebugExitDecision(19); }
				switch ( alt19 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(62, 57);
					LT36=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_formalParameterList308), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop19;
				}
			}

			loop19:
				;

			} finally { DebugExitSubRule(19); }

			DebugLocation(62, 60);
			RPAREN37=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_formalParameterList312), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN37_tree = (object)adaptor.Create(RPAREN37, retval);
			adaptor.AddChild(root_0, RPAREN37_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("formalParameterList", 7);
			LeaveRule("formalParameterList", 7);
			Leave_formalParameterList();
			if (state.backtracking > 0) { Memoize(input, 7, formalParameterList_StartIndex); }
		}
		DebugLocation(63, 1);
		} finally { DebugExitRule(GrammarFileName, "formalParameterList"); }
		return retval;

	}
	// $ANTLR end "formalParameterList"

	public class functionBody_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_functionBody();
	partial void Leave_functionBody();

	// $ANTLR start "functionBody"
	// JavaScript.g:65:1: functionBody : '{' ( LT )* ( sourceElements )? ( LT )* RBRACE ;
	[GrammarRule("functionBody")]
	public JavaScriptParser.functionBody_return functionBody()
	{
		Enter_functionBody();
		EnterRule("functionBody", 8);
		TraceIn("functionBody", 8);
		JavaScriptParser.functionBody_return retval = new JavaScriptParser.functionBody_return();
		retval.Start = (IToken)input.LT(1);
		int functionBody_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal38=null;
		IToken LT39=null;
		IToken LT41=null;
		IToken RBRACE42=null;
		JavaScriptParser.sourceElements_return sourceElements40 = default(JavaScriptParser.sourceElements_return);

		object char_literal38_tree=null;
		object LT39_tree=null;
		object LT41_tree=null;
		object RBRACE42_tree=null;

		try { DebugEnterRule(GrammarFileName, "functionBody");
		DebugLocation(65, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 8)) { return retval; }
			// JavaScript.g:66:2: ( '{' ( LT )* ( sourceElements )? ( LT )* RBRACE )
			DebugEnterAlt(1);
			// JavaScript.g:66:4: '{' ( LT )* ( sourceElements )? ( LT )* RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(66, 4);
			char_literal38=(IToken)Match(input,47,Follow._47_in_functionBody323); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal38_tree = (object)adaptor.Create(char_literal38, retval);
			adaptor.AddChild(root_0, char_literal38_tree);
			}
			DebugLocation(66, 10);
			// JavaScript.g:66:10: ( LT )*
			try { DebugEnterSubRule(20);
			while (true)
			{
				int alt20=2;
				try { DebugEnterDecision(20, decisionCanBacktrack[20]);
				int LA20_0 = input.LA(1);

				if ((LA20_0==LT))
				{
					int LA20_2 = input.LA(2);

					if ((EvaluatePredicate(synpred24_JavaScript_fragment)))
					{
						alt20=1;
					}


				}


				} finally { DebugExitDecision(20); }
				switch ( alt20 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(66, 10);
					LT39=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionBody325), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop20;
				}
			}

			loop20:
				;

			} finally { DebugExitSubRule(20); }

			DebugLocation(66, 13);
			// JavaScript.g:66:13: ( sourceElements )?
			int alt21=2;
			try { DebugEnterSubRule(21);
			try { DebugEnterDecision(21, decisionCanBacktrack[21]);
			int LA21_0 = input.LA(1);

			if (((LA21_0>=NULL && LA21_0<=THIS)||(LA21_0>=Identifier && LA21_0<=RegularExpressionLiteral)||(LA21_0>=43 && LA21_0<=45)||(LA21_0>=47 && LA21_0<=48)||LA21_0==50||(LA21_0>=52 && LA21_0<=54)||(LA21_0>=56 && LA21_0<=59)||LA21_0==61||(LA21_0>=64 && LA21_0<=65)||(LA21_0>=68 && LA21_0<=69)||(LA21_0>=100 && LA21_0<=101)||(LA21_0>=105 && LA21_0<=111)))
			{
				alt21=1;
			}
			} finally { DebugExitDecision(21); }
			switch (alt21)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: sourceElements
				{
				DebugLocation(66, 13);
				PushFollow(Follow._sourceElements_in_functionBody329);
				sourceElements40=sourceElements();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElements40.Tree, sourceElements40, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(21); }

			DebugLocation(66, 31);
			// JavaScript.g:66:31: ( LT )*
			try { DebugEnterSubRule(22);
			while (true)
			{
				int alt22=2;
				try { DebugEnterDecision(22, decisionCanBacktrack[22]);
				int LA22_0 = input.LA(1);

				if ((LA22_0==LT))
				{
					alt22=1;
				}


				} finally { DebugExitDecision(22); }
				switch ( alt22 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(66, 31);
					LT41=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_functionBody332), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop22;
				}
			}

			loop22:
				;

			} finally { DebugExitSubRule(22); }

			DebugLocation(66, 34);
			RBRACE42=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_functionBody336), "RBRACE"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RBRACE42_tree = (object)adaptor.Create(RBRACE42, retval);
			adaptor.AddChild(root_0, RBRACE42_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("functionBody", 8);
			LeaveRule("functionBody", 8);
			Leave_functionBody();
			if (state.backtracking > 0) { Memoize(input, 8, functionBody_StartIndex); }
		}
		DebugLocation(67, 1);
		} finally { DebugExitRule(GrammarFileName, "functionBody"); }
		return retval;

	}
	// $ANTLR end "functionBody"

	public class statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statement();
	partial void Leave_statement();

	// $ANTLR start "statement"
	// JavaScript.g:70:1: statement : ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );
	[GrammarRule("statement")]
	public JavaScriptParser.statement_return statement()
	{
		Enter_statement();
		EnterRule("statement", 9);
		TraceIn("statement", 9);
		JavaScriptParser.statement_return retval = new JavaScriptParser.statement_return();
		retval.Start = (IToken)input.LT(1);
		int statement_StartIndex = input.Index;
		object root_0 = null;

		JavaScriptParser.statementBlock_return statementBlock43 = default(JavaScriptParser.statementBlock_return);
		JavaScriptParser.variableStatement_return variableStatement44 = default(JavaScriptParser.variableStatement_return);
		JavaScriptParser.emptyStatement_return emptyStatement45 = default(JavaScriptParser.emptyStatement_return);
		JavaScriptParser.expressionStatement_return expressionStatement46 = default(JavaScriptParser.expressionStatement_return);
		JavaScriptParser.ifStatement_return ifStatement47 = default(JavaScriptParser.ifStatement_return);
		JavaScriptParser.iterationStatement_return iterationStatement48 = default(JavaScriptParser.iterationStatement_return);
		JavaScriptParser.continueStatement_return continueStatement49 = default(JavaScriptParser.continueStatement_return);
		JavaScriptParser.breakStatement_return breakStatement50 = default(JavaScriptParser.breakStatement_return);
		JavaScriptParser.returnStatement_return returnStatement51 = default(JavaScriptParser.returnStatement_return);
		JavaScriptParser.withStatement_return withStatement52 = default(JavaScriptParser.withStatement_return);
		JavaScriptParser.labelledStatement_return labelledStatement53 = default(JavaScriptParser.labelledStatement_return);
		JavaScriptParser.switchStatement_return switchStatement54 = default(JavaScriptParser.switchStatement_return);
		JavaScriptParser.throwStatement_return throwStatement55 = default(JavaScriptParser.throwStatement_return);
		JavaScriptParser.tryStatement_return tryStatement56 = default(JavaScriptParser.tryStatement_return);


		try { DebugEnterRule(GrammarFileName, "statement");
		DebugLocation(70, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 9)) { return retval; }
			// JavaScript.g:71:2: ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement )
			int alt23=14;
			try { DebugEnterDecision(23, decisionCanBacktrack[23]);
			try
			{
				alt23 = dfa23.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(23); }
			switch (alt23)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:71:4: statementBlock
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(71, 4);
				PushFollow(Follow._statementBlock_in_statement348);
				statementBlock43=statementBlock();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock43.Tree, statementBlock43, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:72:4: variableStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(72, 4);
				PushFollow(Follow._variableStatement_in_statement353);
				variableStatement44=variableStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableStatement44.Tree, variableStatement44, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:73:4: emptyStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(73, 4);
				PushFollow(Follow._emptyStatement_in_statement358);
				emptyStatement45=emptyStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, emptyStatement45.Tree, emptyStatement45, retval);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// JavaScript.g:74:4: expressionStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(74, 4);
				PushFollow(Follow._expressionStatement_in_statement363);
				expressionStatement46=expressionStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionStatement46.Tree, expressionStatement46, retval);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// JavaScript.g:75:4: ifStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(75, 4);
				PushFollow(Follow._ifStatement_in_statement368);
				ifStatement47=ifStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ifStatement47.Tree, ifStatement47, retval);

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// JavaScript.g:76:4: iterationStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(76, 4);
				PushFollow(Follow._iterationStatement_in_statement373);
				iterationStatement48=iterationStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, iterationStatement48.Tree, iterationStatement48, retval);

				}
				break;
			case 7:
				DebugEnterAlt(7);
				// JavaScript.g:77:4: continueStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(77, 4);
				PushFollow(Follow._continueStatement_in_statement378);
				continueStatement49=continueStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, continueStatement49.Tree, continueStatement49, retval);

				}
				break;
			case 8:
				DebugEnterAlt(8);
				// JavaScript.g:78:4: breakStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(78, 4);
				PushFollow(Follow._breakStatement_in_statement383);
				breakStatement50=breakStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, breakStatement50.Tree, breakStatement50, retval);

				}
				break;
			case 9:
				DebugEnterAlt(9);
				// JavaScript.g:79:4: returnStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(79, 4);
				PushFollow(Follow._returnStatement_in_statement388);
				returnStatement51=returnStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, returnStatement51.Tree, returnStatement51, retval);

				}
				break;
			case 10:
				DebugEnterAlt(10);
				// JavaScript.g:80:4: withStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(80, 4);
				PushFollow(Follow._withStatement_in_statement393);
				withStatement52=withStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, withStatement52.Tree, withStatement52, retval);

				}
				break;
			case 11:
				DebugEnterAlt(11);
				// JavaScript.g:81:4: labelledStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(81, 4);
				PushFollow(Follow._labelledStatement_in_statement398);
				labelledStatement53=labelledStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, labelledStatement53.Tree, labelledStatement53, retval);

				}
				break;
			case 12:
				DebugEnterAlt(12);
				// JavaScript.g:82:4: switchStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(82, 4);
				PushFollow(Follow._switchStatement_in_statement403);
				switchStatement54=switchStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, switchStatement54.Tree, switchStatement54, retval);

				}
				break;
			case 13:
				DebugEnterAlt(13);
				// JavaScript.g:83:4: throwStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(83, 4);
				PushFollow(Follow._throwStatement_in_statement408);
				throwStatement55=throwStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, throwStatement55.Tree, throwStatement55, retval);

				}
				break;
			case 14:
				DebugEnterAlt(14);
				// JavaScript.g:84:4: tryStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(84, 4);
				PushFollow(Follow._tryStatement_in_statement413);
				tryStatement56=tryStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, tryStatement56.Tree, tryStatement56, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("statement", 9);
			LeaveRule("statement", 9);
			Leave_statement();
			if (state.backtracking > 0) { Memoize(input, 9, statement_StartIndex); }
		}
		DebugLocation(85, 1);
		} finally { DebugExitRule(GrammarFileName, "statement"); }
		return retval;

	}
	// $ANTLR end "statement"

	public class statementBlock_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statementBlock();
	partial void Leave_statementBlock();

	// $ANTLR start "statementBlock"
	// JavaScript.g:87:1: statementBlock : '{' ( LT )* ( statementList )? ( LT )* RBRACE ;
	[GrammarRule("statementBlock")]
	public JavaScriptParser.statementBlock_return statementBlock()
	{
		Enter_statementBlock();
		EnterRule("statementBlock", 10);
		TraceIn("statementBlock", 10);
		JavaScriptParser.statementBlock_return retval = new JavaScriptParser.statementBlock_return();
		retval.Start = (IToken)input.LT(1);
		int statementBlock_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal57=null;
		IToken LT58=null;
		IToken LT60=null;
		IToken RBRACE61=null;
		JavaScriptParser.statementList_return statementList59 = default(JavaScriptParser.statementList_return);

		object char_literal57_tree=null;
		object LT58_tree=null;
		object LT60_tree=null;
		object RBRACE61_tree=null;

		try { DebugEnterRule(GrammarFileName, "statementBlock");
		DebugLocation(87, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 10)) { return retval; }
			// JavaScript.g:88:2: ( '{' ( LT )* ( statementList )? ( LT )* RBRACE )
			DebugEnterAlt(1);
			// JavaScript.g:88:4: '{' ( LT )* ( statementList )? ( LT )* RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(88, 4);
			char_literal57=(IToken)Match(input,47,Follow._47_in_statementBlock425); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal57_tree = (object)adaptor.Create(char_literal57, retval);
			adaptor.AddChild(root_0, char_literal57_tree);
			}
			DebugLocation(88, 10);
			// JavaScript.g:88:10: ( LT )*
			try { DebugEnterSubRule(24);
			while (true)
			{
				int alt24=2;
				try { DebugEnterDecision(24, decisionCanBacktrack[24]);
				int LA24_0 = input.LA(1);

				if ((LA24_0==LT))
				{
					int LA24_2 = input.LA(2);

					if ((EvaluatePredicate(synpred40_JavaScript_fragment)))
					{
						alt24=1;
					}


				}


				} finally { DebugExitDecision(24); }
				switch ( alt24 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(88, 10);
					LT58=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_statementBlock427), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop24;
				}
			}

			loop24:
				;

			} finally { DebugExitSubRule(24); }

			DebugLocation(88, 13);
			// JavaScript.g:88:13: ( statementList )?
			int alt25=2;
			try { DebugEnterSubRule(25);
			try { DebugEnterDecision(25, decisionCanBacktrack[25]);
			int LA25_0 = input.LA(1);

			if (((LA25_0>=NULL && LA25_0<=THIS)||(LA25_0>=Identifier && LA25_0<=RegularExpressionLiteral)||(LA25_0>=43 && LA25_0<=45)||(LA25_0>=47 && LA25_0<=48)||LA25_0==50||(LA25_0>=52 && LA25_0<=54)||(LA25_0>=56 && LA25_0<=59)||LA25_0==61||(LA25_0>=64 && LA25_0<=65)||(LA25_0>=68 && LA25_0<=69)||(LA25_0>=100 && LA25_0<=101)||(LA25_0>=105 && LA25_0<=111)))
			{
				alt25=1;
			}
			} finally { DebugExitDecision(25); }
			switch (alt25)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: statementList
				{
				DebugLocation(88, 13);
				PushFollow(Follow._statementList_in_statementBlock431);
				statementList59=statementList();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList59.Tree, statementList59, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(25); }

			DebugLocation(88, 30);
			// JavaScript.g:88:30: ( LT )*
			try { DebugEnterSubRule(26);
			while (true)
			{
				int alt26=2;
				try { DebugEnterDecision(26, decisionCanBacktrack[26]);
				int LA26_0 = input.LA(1);

				if ((LA26_0==LT))
				{
					alt26=1;
				}


				} finally { DebugExitDecision(26); }
				switch ( alt26 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(88, 30);
					LT60=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_statementBlock434), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop26;
				}
			}

			loop26:
				;

			} finally { DebugExitSubRule(26); }

			DebugLocation(88, 33);
			RBRACE61=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_statementBlock438), "RBRACE"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RBRACE61_tree = (object)adaptor.Create(RBRACE61, retval);
			adaptor.AddChild(root_0, RBRACE61_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("statementBlock", 10);
			LeaveRule("statementBlock", 10);
			Leave_statementBlock();
			if (state.backtracking > 0) { Memoize(input, 10, statementBlock_StartIndex); }
		}
		DebugLocation(89, 1);
		} finally { DebugExitRule(GrammarFileName, "statementBlock"); }
		return retval;

	}
	// $ANTLR end "statementBlock"

	public class statementList_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statementList();
	partial void Leave_statementList();

	// $ANTLR start "statementList"
	// JavaScript.g:91:1: statementList : statement ( ( LT )* statement )* ;
	[GrammarRule("statementList")]
	public JavaScriptParser.statementList_return statementList()
	{
		Enter_statementList();
		EnterRule("statementList", 11);
		TraceIn("statementList", 11);
		JavaScriptParser.statementList_return retval = new JavaScriptParser.statementList_return();
		retval.Start = (IToken)input.LT(1);
		int statementList_StartIndex = input.Index;
		object root_0 = null;

		IToken LT63=null;
		JavaScriptParser.statement_return statement62 = default(JavaScriptParser.statement_return);
		JavaScriptParser.statement_return statement64 = default(JavaScriptParser.statement_return);

		object LT63_tree=null;

		try { DebugEnterRule(GrammarFileName, "statementList");
		DebugLocation(91, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 11)) { return retval; }
			// JavaScript.g:92:2: ( statement ( ( LT )* statement )* )
			DebugEnterAlt(1);
			// JavaScript.g:92:4: statement ( ( LT )* statement )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(92, 4);
			PushFollow(Follow._statement_in_statementList450);
			statement62=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement62.Tree, statement62, retval);
			DebugLocation(92, 14);
			// JavaScript.g:92:14: ( ( LT )* statement )*
			try { DebugEnterSubRule(28);
			while (true)
			{
				int alt28=2;
				try { DebugEnterDecision(28, decisionCanBacktrack[28]);
				try
				{
					alt28 = dfa28.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(28); }
				switch ( alt28 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:92:15: ( LT )* statement
					{
					DebugLocation(92, 17);
					// JavaScript.g:92:17: ( LT )*
					try { DebugEnterSubRule(27);
					while (true)
					{
						int alt27=2;
						try { DebugEnterDecision(27, decisionCanBacktrack[27]);
						int LA27_0 = input.LA(1);

						if ((LA27_0==LT))
						{
							alt27=1;
						}


						} finally { DebugExitDecision(27); }
						switch ( alt27 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(92, 17);
							LT63=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_statementList453), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop27;
						}
					}

					loop27:
						;

					} finally { DebugExitSubRule(27); }

					DebugLocation(92, 20);
					PushFollow(Follow._statement_in_statementList457);
					statement64=statement();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement64.Tree, statement64, retval);

					}
					break;

				default:
					goto loop28;
				}
			}

			loop28:
				;

			} finally { DebugExitSubRule(28); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("statementList", 11);
			LeaveRule("statementList", 11);
			Leave_statementList();
			if (state.backtracking > 0) { Memoize(input, 11, statementList_StartIndex); }
		}
		DebugLocation(93, 1);
		} finally { DebugExitRule(GrammarFileName, "statementList"); }
		return retval;

	}
	// $ANTLR end "statementList"

	public class variableStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableStatement();
	partial void Leave_variableStatement();

	// $ANTLR start "variableStatement"
	// JavaScript.g:95:1: variableStatement : 'var' ( LT )* variableDeclarationList statementEnd ;
	[GrammarRule("variableStatement")]
	public JavaScriptParser.variableStatement_return variableStatement()
	{
		Enter_variableStatement();
		EnterRule("variableStatement", 12);
		TraceIn("variableStatement", 12);
		JavaScriptParser.variableStatement_return retval = new JavaScriptParser.variableStatement_return();
		retval.Start = (IToken)input.LT(1);
		int variableStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal65=null;
		IToken LT66=null;
		JavaScriptParser.variableDeclarationList_return variableDeclarationList67 = default(JavaScriptParser.variableDeclarationList_return);
		JavaScriptParser.statementEnd_return statementEnd68 = default(JavaScriptParser.statementEnd_return);

		object string_literal65_tree=null;
		object LT66_tree=null;

		try { DebugEnterRule(GrammarFileName, "variableStatement");
		DebugLocation(95, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 12)) { return retval; }
			// JavaScript.g:96:2: ( 'var' ( LT )* variableDeclarationList statementEnd )
			DebugEnterAlt(1);
			// JavaScript.g:96:4: 'var' ( LT )* variableDeclarationList statementEnd
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(96, 4);
			string_literal65=(IToken)Match(input,48,Follow._48_in_variableStatement471); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal65_tree = (object)adaptor.Create(string_literal65, retval);
			adaptor.AddChild(root_0, string_literal65_tree);
			}
			DebugLocation(96, 12);
			// JavaScript.g:96:12: ( LT )*
			try { DebugEnterSubRule(29);
			while (true)
			{
				int alt29=2;
				try { DebugEnterDecision(29, decisionCanBacktrack[29]);
				int LA29_0 = input.LA(1);

				if ((LA29_0==LT))
				{
					alt29=1;
				}


				} finally { DebugExitDecision(29); }
				switch ( alt29 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(96, 12);
					LT66=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_variableStatement473), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop29;
				}
			}

			loop29:
				;

			} finally { DebugExitSubRule(29); }

			DebugLocation(96, 15);
			PushFollow(Follow._variableDeclarationList_in_variableStatement477);
			variableDeclarationList67=variableDeclarationList();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationList67.Tree, variableDeclarationList67, retval);
			DebugLocation(96, 39);
			PushFollow(Follow._statementEnd_in_variableStatement479);
			statementEnd68=statementEnd();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementEnd68.Tree, statementEnd68, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableStatement", 12);
			LeaveRule("variableStatement", 12);
			Leave_variableStatement();
			if (state.backtracking > 0) { Memoize(input, 12, variableStatement_StartIndex); }
		}
		DebugLocation(97, 1);
		} finally { DebugExitRule(GrammarFileName, "variableStatement"); }
		return retval;

	}
	// $ANTLR end "variableStatement"

	public class variableDeclarationList_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableDeclarationList();
	partial void Leave_variableDeclarationList();

	// $ANTLR start "variableDeclarationList"
	// JavaScript.g:99:1: variableDeclarationList : variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )* ;
	[GrammarRule("variableDeclarationList")]
	public JavaScriptParser.variableDeclarationList_return variableDeclarationList()
	{
		Enter_variableDeclarationList();
		EnterRule("variableDeclarationList", 13);
		TraceIn("variableDeclarationList", 13);
		JavaScriptParser.variableDeclarationList_return retval = new JavaScriptParser.variableDeclarationList_return();
		retval.Start = (IToken)input.LT(1);
		int variableDeclarationList_StartIndex = input.Index;
		object root_0 = null;

		IToken LT70=null;
		IToken char_literal71=null;
		IToken LT72=null;
		JavaScriptParser.variableDeclaration_return variableDeclaration69 = default(JavaScriptParser.variableDeclaration_return);
		JavaScriptParser.variableDeclaration_return variableDeclaration73 = default(JavaScriptParser.variableDeclaration_return);

		object LT70_tree=null;
		object char_literal71_tree=null;
		object LT72_tree=null;

		try { DebugEnterRule(GrammarFileName, "variableDeclarationList");
		DebugLocation(99, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 13)) { return retval; }
			// JavaScript.g:100:2: ( variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )* )
			DebugEnterAlt(1);
			// JavaScript.g:100:4: variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(100, 4);
			PushFollow(Follow._variableDeclaration_in_variableDeclarationList491);
			variableDeclaration69=variableDeclaration();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclaration69.Tree, variableDeclaration69, retval);
			DebugLocation(100, 24);
			// JavaScript.g:100:24: ( ( LT )* ',' ( LT )* variableDeclaration )*
			try { DebugEnterSubRule(32);
			while (true)
			{
				int alt32=2;
				try { DebugEnterDecision(32, decisionCanBacktrack[32]);
				try
				{
					alt32 = dfa32.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(32); }
				switch ( alt32 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:100:25: ( LT )* ',' ( LT )* variableDeclaration
					{
					DebugLocation(100, 27);
					// JavaScript.g:100:27: ( LT )*
					try { DebugEnterSubRule(30);
					while (true)
					{
						int alt30=2;
						try { DebugEnterDecision(30, decisionCanBacktrack[30]);
						int LA30_0 = input.LA(1);

						if ((LA30_0==LT))
						{
							alt30=1;
						}


						} finally { DebugExitDecision(30); }
						switch ( alt30 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(100, 27);
							LT70=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_variableDeclarationList494), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop30;
						}
					}

					loop30:
						;

					} finally { DebugExitSubRule(30); }

					DebugLocation(100, 30);
					char_literal71=(IToken)Match(input,46,Follow._46_in_variableDeclarationList498); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal71_tree = (object)adaptor.Create(char_literal71, retval);
					adaptor.AddChild(root_0, char_literal71_tree);
					}
					DebugLocation(100, 36);
					// JavaScript.g:100:36: ( LT )*
					try { DebugEnterSubRule(31);
					while (true)
					{
						int alt31=2;
						try { DebugEnterDecision(31, decisionCanBacktrack[31]);
						int LA31_0 = input.LA(1);

						if ((LA31_0==LT))
						{
							alt31=1;
						}


						} finally { DebugExitDecision(31); }
						switch ( alt31 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(100, 36);
							LT72=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_variableDeclarationList500), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop31;
						}
					}

					loop31:
						;

					} finally { DebugExitSubRule(31); }

					DebugLocation(100, 39);
					PushFollow(Follow._variableDeclaration_in_variableDeclarationList504);
					variableDeclaration73=variableDeclaration();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclaration73.Tree, variableDeclaration73, retval);

					}
					break;

				default:
					goto loop32;
				}
			}

			loop32:
				;

			} finally { DebugExitSubRule(32); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableDeclarationList", 13);
			LeaveRule("variableDeclarationList", 13);
			Leave_variableDeclarationList();
			if (state.backtracking > 0) { Memoize(input, 13, variableDeclarationList_StartIndex); }
		}
		DebugLocation(101, 1);
		} finally { DebugExitRule(GrammarFileName, "variableDeclarationList"); }
		return retval;

	}
	// $ANTLR end "variableDeclarationList"

	public class variableDeclarationListNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableDeclarationListNoIn();
	partial void Leave_variableDeclarationListNoIn();

	// $ANTLR start "variableDeclarationListNoIn"
	// JavaScript.g:103:1: variableDeclarationListNoIn : variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )* ;
	[GrammarRule("variableDeclarationListNoIn")]
	public JavaScriptParser.variableDeclarationListNoIn_return variableDeclarationListNoIn()
	{
		Enter_variableDeclarationListNoIn();
		EnterRule("variableDeclarationListNoIn", 14);
		TraceIn("variableDeclarationListNoIn", 14);
		JavaScriptParser.variableDeclarationListNoIn_return retval = new JavaScriptParser.variableDeclarationListNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int variableDeclarationListNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT75=null;
		IToken char_literal76=null;
		IToken LT77=null;
		JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn74 = default(JavaScriptParser.variableDeclarationNoIn_return);
		JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn78 = default(JavaScriptParser.variableDeclarationNoIn_return);

		object LT75_tree=null;
		object char_literal76_tree=null;
		object LT77_tree=null;

		try { DebugEnterRule(GrammarFileName, "variableDeclarationListNoIn");
		DebugLocation(103, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 14)) { return retval; }
			// JavaScript.g:104:2: ( variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:104:4: variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(104, 4);
			PushFollow(Follow._variableDeclarationNoIn_in_variableDeclarationListNoIn518);
			variableDeclarationNoIn74=variableDeclarationNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn74.Tree, variableDeclarationNoIn74, retval);
			DebugLocation(104, 28);
			// JavaScript.g:104:28: ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*
			try { DebugEnterSubRule(35);
			while (true)
			{
				int alt35=2;
				try { DebugEnterDecision(35, decisionCanBacktrack[35]);
				try
				{
					alt35 = dfa35.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(35); }
				switch ( alt35 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:104:29: ( LT )* ',' ( LT )* variableDeclarationNoIn
					{
					DebugLocation(104, 31);
					// JavaScript.g:104:31: ( LT )*
					try { DebugEnterSubRule(33);
					while (true)
					{
						int alt33=2;
						try { DebugEnterDecision(33, decisionCanBacktrack[33]);
						int LA33_0 = input.LA(1);

						if ((LA33_0==LT))
						{
							alt33=1;
						}


						} finally { DebugExitDecision(33); }
						switch ( alt33 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(104, 31);
							LT75=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_variableDeclarationListNoIn521), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop33;
						}
					}

					loop33:
						;

					} finally { DebugExitSubRule(33); }

					DebugLocation(104, 34);
					char_literal76=(IToken)Match(input,46,Follow._46_in_variableDeclarationListNoIn525); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal76_tree = (object)adaptor.Create(char_literal76, retval);
					adaptor.AddChild(root_0, char_literal76_tree);
					}
					DebugLocation(104, 40);
					// JavaScript.g:104:40: ( LT )*
					try { DebugEnterSubRule(34);
					while (true)
					{
						int alt34=2;
						try { DebugEnterDecision(34, decisionCanBacktrack[34]);
						int LA34_0 = input.LA(1);

						if ((LA34_0==LT))
						{
							alt34=1;
						}


						} finally { DebugExitDecision(34); }
						switch ( alt34 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(104, 40);
							LT77=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_variableDeclarationListNoIn527), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop34;
						}
					}

					loop34:
						;

					} finally { DebugExitSubRule(34); }

					DebugLocation(104, 43);
					PushFollow(Follow._variableDeclarationNoIn_in_variableDeclarationListNoIn531);
					variableDeclarationNoIn78=variableDeclarationNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn78.Tree, variableDeclarationNoIn78, retval);

					}
					break;

				default:
					goto loop35;
				}
			}

			loop35:
				;

			} finally { DebugExitSubRule(35); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableDeclarationListNoIn", 14);
			LeaveRule("variableDeclarationListNoIn", 14);
			Leave_variableDeclarationListNoIn();
			if (state.backtracking > 0) { Memoize(input, 14, variableDeclarationListNoIn_StartIndex); }
		}
		DebugLocation(105, 1);
		} finally { DebugExitRule(GrammarFileName, "variableDeclarationListNoIn"); }
		return retval;

	}
	// $ANTLR end "variableDeclarationListNoIn"

	public class variableDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableDeclaration();
	partial void Leave_variableDeclaration();

	// $ANTLR start "variableDeclaration"
	// JavaScript.g:107:1: variableDeclaration : Identifier ( ( LT )* initialiser )? ;
	[GrammarRule("variableDeclaration")]
	public JavaScriptParser.variableDeclaration_return variableDeclaration()
	{
		Enter_variableDeclaration();
		EnterRule("variableDeclaration", 15);
		TraceIn("variableDeclaration", 15);
		JavaScriptParser.variableDeclaration_return retval = new JavaScriptParser.variableDeclaration_return();
		retval.Start = (IToken)input.LT(1);
		int variableDeclaration_StartIndex = input.Index;
		object root_0 = null;

		IToken Identifier79=null;
		IToken LT80=null;
		JavaScriptParser.initialiser_return initialiser81 = default(JavaScriptParser.initialiser_return);

		object Identifier79_tree=null;
		object LT80_tree=null;

		try { DebugEnterRule(GrammarFileName, "variableDeclaration");
		DebugLocation(107, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 15)) { return retval; }
			// JavaScript.g:108:2: ( Identifier ( ( LT )* initialiser )? )
			DebugEnterAlt(1);
			// JavaScript.g:108:4: Identifier ( ( LT )* initialiser )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(108, 4);
			Identifier79=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_variableDeclaration545), "Identifier"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			Identifier79_tree = (object)adaptor.Create(Identifier79, retval);
			adaptor.AddChild(root_0, Identifier79_tree);
			}
			DebugLocation(108, 15);
			// JavaScript.g:108:15: ( ( LT )* initialiser )?
			int alt37=2;
			try { DebugEnterSubRule(37);
			try { DebugEnterDecision(37, decisionCanBacktrack[37]);
			try
			{
				alt37 = dfa37.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(37); }
			switch (alt37)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:108:16: ( LT )* initialiser
				{
				DebugLocation(108, 18);
				// JavaScript.g:108:18: ( LT )*
				try { DebugEnterSubRule(36);
				while (true)
				{
					int alt36=2;
					try { DebugEnterDecision(36, decisionCanBacktrack[36]);
					int LA36_0 = input.LA(1);

					if ((LA36_0==LT))
					{
						alt36=1;
					}


					} finally { DebugExitDecision(36); }
					switch ( alt36 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(108, 18);
						LT80=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_variableDeclaration548), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop36;
					}
				}

				loop36:
					;

				} finally { DebugExitSubRule(36); }

				DebugLocation(108, 21);
				PushFollow(Follow._initialiser_in_variableDeclaration552);
				initialiser81=initialiser();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initialiser81.Tree, initialiser81, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(37); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableDeclaration", 15);
			LeaveRule("variableDeclaration", 15);
			Leave_variableDeclaration();
			if (state.backtracking > 0) { Memoize(input, 15, variableDeclaration_StartIndex); }
		}
		DebugLocation(109, 1);
		} finally { DebugExitRule(GrammarFileName, "variableDeclaration"); }
		return retval;

	}
	// $ANTLR end "variableDeclaration"

	public class variableDeclarationNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableDeclarationNoIn();
	partial void Leave_variableDeclarationNoIn();

	// $ANTLR start "variableDeclarationNoIn"
	// JavaScript.g:111:1: variableDeclarationNoIn : Identifier ( ( LT )* initialiserNoIn )? ;
	[GrammarRule("variableDeclarationNoIn")]
	public JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn()
	{
		Enter_variableDeclarationNoIn();
		EnterRule("variableDeclarationNoIn", 16);
		TraceIn("variableDeclarationNoIn", 16);
		JavaScriptParser.variableDeclarationNoIn_return retval = new JavaScriptParser.variableDeclarationNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int variableDeclarationNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken Identifier82=null;
		IToken LT83=null;
		JavaScriptParser.initialiserNoIn_return initialiserNoIn84 = default(JavaScriptParser.initialiserNoIn_return);

		object Identifier82_tree=null;
		object LT83_tree=null;

		try { DebugEnterRule(GrammarFileName, "variableDeclarationNoIn");
		DebugLocation(111, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 16)) { return retval; }
			// JavaScript.g:112:2: ( Identifier ( ( LT )* initialiserNoIn )? )
			DebugEnterAlt(1);
			// JavaScript.g:112:4: Identifier ( ( LT )* initialiserNoIn )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(112, 4);
			Identifier82=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_variableDeclarationNoIn566), "Identifier"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			Identifier82_tree = (object)adaptor.Create(Identifier82, retval);
			adaptor.AddChild(root_0, Identifier82_tree);
			}
			DebugLocation(112, 15);
			// JavaScript.g:112:15: ( ( LT )* initialiserNoIn )?
			int alt39=2;
			try { DebugEnterSubRule(39);
			try { DebugEnterDecision(39, decisionCanBacktrack[39]);
			try
			{
				alt39 = dfa39.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(39); }
			switch (alt39)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:112:16: ( LT )* initialiserNoIn
				{
				DebugLocation(112, 18);
				// JavaScript.g:112:18: ( LT )*
				try { DebugEnterSubRule(38);
				while (true)
				{
					int alt38=2;
					try { DebugEnterDecision(38, decisionCanBacktrack[38]);
					int LA38_0 = input.LA(1);

					if ((LA38_0==LT))
					{
						alt38=1;
					}


					} finally { DebugExitDecision(38); }
					switch ( alt38 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(112, 18);
						LT83=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_variableDeclarationNoIn569), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop38;
					}
				}

				loop38:
					;

				} finally { DebugExitSubRule(38); }

				DebugLocation(112, 21);
				PushFollow(Follow._initialiserNoIn_in_variableDeclarationNoIn573);
				initialiserNoIn84=initialiserNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initialiserNoIn84.Tree, initialiserNoIn84, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(39); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("variableDeclarationNoIn", 16);
			LeaveRule("variableDeclarationNoIn", 16);
			Leave_variableDeclarationNoIn();
			if (state.backtracking > 0) { Memoize(input, 16, variableDeclarationNoIn_StartIndex); }
		}
		DebugLocation(113, 1);
		} finally { DebugExitRule(GrammarFileName, "variableDeclarationNoIn"); }
		return retval;

	}
	// $ANTLR end "variableDeclarationNoIn"

	public class initialiser_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_initialiser();
	partial void Leave_initialiser();

	// $ANTLR start "initialiser"
	// JavaScript.g:115:1: initialiser : '=' ( LT )* assignmentExpression ;
	[GrammarRule("initialiser")]
	public JavaScriptParser.initialiser_return initialiser()
	{
		Enter_initialiser();
		EnterRule("initialiser", 17);
		TraceIn("initialiser", 17);
		JavaScriptParser.initialiser_return retval = new JavaScriptParser.initialiser_return();
		retval.Start = (IToken)input.LT(1);
		int initialiser_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal85=null;
		IToken LT86=null;
		JavaScriptParser.assignmentExpression_return assignmentExpression87 = default(JavaScriptParser.assignmentExpression_return);

		object char_literal85_tree=null;
		object LT86_tree=null;

		try { DebugEnterRule(GrammarFileName, "initialiser");
		DebugLocation(115, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 17)) { return retval; }
			// JavaScript.g:116:2: ( '=' ( LT )* assignmentExpression )
			DebugEnterAlt(1);
			// JavaScript.g:116:4: '=' ( LT )* assignmentExpression
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(116, 4);
			char_literal85=(IToken)Match(input,49,Follow._49_in_initialiser587); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal85_tree = (object)adaptor.Create(char_literal85, retval);
			adaptor.AddChild(root_0, char_literal85_tree);
			}
			DebugLocation(116, 10);
			// JavaScript.g:116:10: ( LT )*
			try { DebugEnterSubRule(40);
			while (true)
			{
				int alt40=2;
				try { DebugEnterDecision(40, decisionCanBacktrack[40]);
				int LA40_0 = input.LA(1);

				if ((LA40_0==LT))
				{
					alt40=1;
				}


				} finally { DebugExitDecision(40); }
				switch ( alt40 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(116, 10);
					LT86=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_initialiser589), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop40;
				}
			}

			loop40:
				;

			} finally { DebugExitSubRule(40); }

			DebugLocation(116, 13);
			PushFollow(Follow._assignmentExpression_in_initialiser593);
			assignmentExpression87=assignmentExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression87.Tree, assignmentExpression87, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("initialiser", 17);
			LeaveRule("initialiser", 17);
			Leave_initialiser();
			if (state.backtracking > 0) { Memoize(input, 17, initialiser_StartIndex); }
		}
		DebugLocation(117, 1);
		} finally { DebugExitRule(GrammarFileName, "initialiser"); }
		return retval;

	}
	// $ANTLR end "initialiser"

	public class initialiserNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_initialiserNoIn();
	partial void Leave_initialiserNoIn();

	// $ANTLR start "initialiserNoIn"
	// JavaScript.g:119:1: initialiserNoIn : '=' ( LT )* assignmentExpressionNoIn ;
	[GrammarRule("initialiserNoIn")]
	public JavaScriptParser.initialiserNoIn_return initialiserNoIn()
	{
		Enter_initialiserNoIn();
		EnterRule("initialiserNoIn", 18);
		TraceIn("initialiserNoIn", 18);
		JavaScriptParser.initialiserNoIn_return retval = new JavaScriptParser.initialiserNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int initialiserNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal88=null;
		IToken LT89=null;
		JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn90 = default(JavaScriptParser.assignmentExpressionNoIn_return);

		object char_literal88_tree=null;
		object LT89_tree=null;

		try { DebugEnterRule(GrammarFileName, "initialiserNoIn");
		DebugLocation(119, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 18)) { return retval; }
			// JavaScript.g:120:2: ( '=' ( LT )* assignmentExpressionNoIn )
			DebugEnterAlt(1);
			// JavaScript.g:120:4: '=' ( LT )* assignmentExpressionNoIn
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(120, 4);
			char_literal88=(IToken)Match(input,49,Follow._49_in_initialiserNoIn605); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal88_tree = (object)adaptor.Create(char_literal88, retval);
			adaptor.AddChild(root_0, char_literal88_tree);
			}
			DebugLocation(120, 10);
			// JavaScript.g:120:10: ( LT )*
			try { DebugEnterSubRule(41);
			while (true)
			{
				int alt41=2;
				try { DebugEnterDecision(41, decisionCanBacktrack[41]);
				int LA41_0 = input.LA(1);

				if ((LA41_0==LT))
				{
					alt41=1;
				}


				} finally { DebugExitDecision(41); }
				switch ( alt41 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(120, 10);
					LT89=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_initialiserNoIn607), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop41;
				}
			}

			loop41:
				;

			} finally { DebugExitSubRule(41); }

			DebugLocation(120, 13);
			PushFollow(Follow._assignmentExpressionNoIn_in_initialiserNoIn611);
			assignmentExpressionNoIn90=assignmentExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn90.Tree, assignmentExpressionNoIn90, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("initialiserNoIn", 18);
			LeaveRule("initialiserNoIn", 18);
			Leave_initialiserNoIn();
			if (state.backtracking > 0) { Memoize(input, 18, initialiserNoIn_StartIndex); }
		}
		DebugLocation(121, 1);
		} finally { DebugExitRule(GrammarFileName, "initialiserNoIn"); }
		return retval;

	}
	// $ANTLR end "initialiserNoIn"

	public class emptyStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_emptyStatement();
	partial void Leave_emptyStatement();

	// $ANTLR start "emptyStatement"
	// JavaScript.g:123:1: emptyStatement : ';' ;
	[GrammarRule("emptyStatement")]
	public JavaScriptParser.emptyStatement_return emptyStatement()
	{
		Enter_emptyStatement();
		EnterRule("emptyStatement", 19);
		TraceIn("emptyStatement", 19);
		JavaScriptParser.emptyStatement_return retval = new JavaScriptParser.emptyStatement_return();
		retval.Start = (IToken)input.LT(1);
		int emptyStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal91=null;

		object char_literal91_tree=null;

		try { DebugEnterRule(GrammarFileName, "emptyStatement");
		DebugLocation(123, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 19)) { return retval; }
			// JavaScript.g:124:2: ( ';' )
			DebugEnterAlt(1);
			// JavaScript.g:124:4: ';'
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(124, 4);
			char_literal91=(IToken)Match(input,43,Follow._43_in_emptyStatement623); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal91_tree = (object)adaptor.Create(char_literal91, retval);
			adaptor.AddChild(root_0, char_literal91_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("emptyStatement", 19);
			LeaveRule("emptyStatement", 19);
			Leave_emptyStatement();
			if (state.backtracking > 0) { Memoize(input, 19, emptyStatement_StartIndex); }
		}
		DebugLocation(125, 1);
		} finally { DebugExitRule(GrammarFileName, "emptyStatement"); }
		return retval;

	}
	// $ANTLR end "emptyStatement"

	public class expressionStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expressionStatement();
	partial void Leave_expressionStatement();

	// $ANTLR start "expressionStatement"
	// JavaScript.g:127:1: expressionStatement : expression statementEnd ;
	[GrammarRule("expressionStatement")]
	public JavaScriptParser.expressionStatement_return expressionStatement()
	{
		Enter_expressionStatement();
		EnterRule("expressionStatement", 20);
		TraceIn("expressionStatement", 20);
		JavaScriptParser.expressionStatement_return retval = new JavaScriptParser.expressionStatement_return();
		retval.Start = (IToken)input.LT(1);
		int expressionStatement_StartIndex = input.Index;
		object root_0 = null;

		JavaScriptParser.expression_return expression92 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statementEnd_return statementEnd93 = default(JavaScriptParser.statementEnd_return);


		try { DebugEnterRule(GrammarFileName, "expressionStatement");
		DebugLocation(127, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 20)) { return retval; }
			// JavaScript.g:128:2: ( expression statementEnd )
			DebugEnterAlt(1);
			// JavaScript.g:128:4: expression statementEnd
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(128, 4);
			PushFollow(Follow._expression_in_expressionStatement635);
			expression92=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression92.Tree, expression92, retval);
			DebugLocation(128, 15);
			PushFollow(Follow._statementEnd_in_expressionStatement637);
			statementEnd93=statementEnd();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementEnd93.Tree, statementEnd93, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expressionStatement", 20);
			LeaveRule("expressionStatement", 20);
			Leave_expressionStatement();
			if (state.backtracking > 0) { Memoize(input, 20, expressionStatement_StartIndex); }
		}
		DebugLocation(129, 1);
		} finally { DebugExitRule(GrammarFileName, "expressionStatement"); }
		return retval;

	}
	// $ANTLR end "expressionStatement"

	public class ifStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_ifStatement();
	partial void Leave_ifStatement();

	// $ANTLR start "ifStatement"
	// JavaScript.g:131:1: ifStatement : 'if' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement ( ( LT )* 'else' ( LT )* statement )? ;
	[GrammarRule("ifStatement")]
	public JavaScriptParser.ifStatement_return ifStatement()
	{
		Enter_ifStatement();
		EnterRule("ifStatement", 21);
		TraceIn("ifStatement", 21);
		JavaScriptParser.ifStatement_return retval = new JavaScriptParser.ifStatement_return();
		retval.Start = (IToken)input.LT(1);
		int ifStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal94=null;
		IToken LT95=null;
		IToken char_literal96=null;
		IToken LT97=null;
		IToken LT99=null;
		IToken RPAREN100=null;
		IToken LT101=null;
		IToken LT103=null;
		IToken string_literal104=null;
		IToken LT105=null;
		JavaScriptParser.expression_return expression98 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statement_return statement102 = default(JavaScriptParser.statement_return);
		JavaScriptParser.statement_return statement106 = default(JavaScriptParser.statement_return);

		object string_literal94_tree=null;
		object LT95_tree=null;
		object char_literal96_tree=null;
		object LT97_tree=null;
		object LT99_tree=null;
		object RPAREN100_tree=null;
		object LT101_tree=null;
		object LT103_tree=null;
		object string_literal104_tree=null;
		object LT105_tree=null;

		try { DebugEnterRule(GrammarFileName, "ifStatement");
		DebugLocation(131, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 21)) { return retval; }
			// JavaScript.g:132:2: ( 'if' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement ( ( LT )* 'else' ( LT )* statement )? )
			DebugEnterAlt(1);
			// JavaScript.g:132:4: 'if' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement ( ( LT )* 'else' ( LT )* statement )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(132, 4);
			string_literal94=(IToken)Match(input,50,Follow._50_in_ifStatement649); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal94_tree = (object)adaptor.Create(string_literal94, retval);
			adaptor.AddChild(root_0, string_literal94_tree);
			}
			DebugLocation(132, 11);
			// JavaScript.g:132:11: ( LT )*
			try { DebugEnterSubRule(42);
			while (true)
			{
				int alt42=2;
				try { DebugEnterDecision(42, decisionCanBacktrack[42]);
				int LA42_0 = input.LA(1);

				if ((LA42_0==LT))
				{
					alt42=1;
				}


				} finally { DebugExitDecision(42); }
				switch ( alt42 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(132, 11);
					LT95=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_ifStatement651), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop42;
				}
			}

			loop42:
				;

			} finally { DebugExitSubRule(42); }

			DebugLocation(132, 14);
			char_literal96=(IToken)Match(input,45,Follow._45_in_ifStatement655); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal96_tree = (object)adaptor.Create(char_literal96, retval);
			adaptor.AddChild(root_0, char_literal96_tree);
			}
			DebugLocation(132, 20);
			// JavaScript.g:132:20: ( LT )*
			try { DebugEnterSubRule(43);
			while (true)
			{
				int alt43=2;
				try { DebugEnterDecision(43, decisionCanBacktrack[43]);
				int LA43_0 = input.LA(1);

				if ((LA43_0==LT))
				{
					alt43=1;
				}


				} finally { DebugExitDecision(43); }
				switch ( alt43 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(132, 20);
					LT97=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_ifStatement657), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop43;
				}
			}

			loop43:
				;

			} finally { DebugExitSubRule(43); }

			DebugLocation(132, 23);
			PushFollow(Follow._expression_in_ifStatement661);
			expression98=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression98.Tree, expression98, retval);
			DebugLocation(132, 36);
			// JavaScript.g:132:36: ( LT )*
			try { DebugEnterSubRule(44);
			while (true)
			{
				int alt44=2;
				try { DebugEnterDecision(44, decisionCanBacktrack[44]);
				int LA44_0 = input.LA(1);

				if ((LA44_0==LT))
				{
					alt44=1;
				}


				} finally { DebugExitDecision(44); }
				switch ( alt44 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(132, 36);
					LT99=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_ifStatement663), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop44;
				}
			}

			loop44:
				;

			} finally { DebugExitSubRule(44); }

			DebugLocation(132, 39);
			RPAREN100=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_ifStatement667), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN100_tree = (object)adaptor.Create(RPAREN100, retval);
			adaptor.AddChild(root_0, RPAREN100_tree);
			}
			DebugLocation(132, 48);
			// JavaScript.g:132:48: ( LT )*
			try { DebugEnterSubRule(45);
			while (true)
			{
				int alt45=2;
				try { DebugEnterDecision(45, decisionCanBacktrack[45]);
				int LA45_0 = input.LA(1);

				if ((LA45_0==LT))
				{
					alt45=1;
				}


				} finally { DebugExitDecision(45); }
				switch ( alt45 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(132, 48);
					LT101=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_ifStatement669), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop45;
				}
			}

			loop45:
				;

			} finally { DebugExitSubRule(45); }

			DebugLocation(132, 51);
			PushFollow(Follow._statement_in_ifStatement673);
			statement102=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement102.Tree, statement102, retval);
			DebugLocation(132, 61);
			// JavaScript.g:132:61: ( ( LT )* 'else' ( LT )* statement )?
			int alt48=2;
			try { DebugEnterSubRule(48);
			try { DebugEnterDecision(48, decisionCanBacktrack[48]);
			int LA48_0 = input.LA(1);

			if ((LA48_0==LT))
			{
				int LA48_1 = input.LA(2);

				if ((EvaluatePredicate(synpred64_JavaScript_fragment)))
				{
					alt48=1;
				}
			}
			else if ((LA48_0==51))
			{
				int LA48_2 = input.LA(2);

				if ((EvaluatePredicate(synpred64_JavaScript_fragment)))
				{
					alt48=1;
				}
			}
			} finally { DebugExitDecision(48); }
			switch (alt48)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:132:62: ( LT )* 'else' ( LT )* statement
				{
				DebugLocation(132, 64);
				// JavaScript.g:132:64: ( LT )*
				try { DebugEnterSubRule(46);
				while (true)
				{
					int alt46=2;
					try { DebugEnterDecision(46, decisionCanBacktrack[46]);
					int LA46_0 = input.LA(1);

					if ((LA46_0==LT))
					{
						alt46=1;
					}


					} finally { DebugExitDecision(46); }
					switch ( alt46 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(132, 64);
						LT103=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_ifStatement676), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop46;
					}
				}

				loop46:
					;

				} finally { DebugExitSubRule(46); }

				DebugLocation(132, 67);
				string_literal104=(IToken)Match(input,51,Follow._51_in_ifStatement680); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal104_tree = (object)adaptor.Create(string_literal104, retval);
				adaptor.AddChild(root_0, string_literal104_tree);
				}
				DebugLocation(132, 76);
				// JavaScript.g:132:76: ( LT )*
				try { DebugEnterSubRule(47);
				while (true)
				{
					int alt47=2;
					try { DebugEnterDecision(47, decisionCanBacktrack[47]);
					int LA47_0 = input.LA(1);

					if ((LA47_0==LT))
					{
						alt47=1;
					}


					} finally { DebugExitDecision(47); }
					switch ( alt47 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(132, 76);
						LT105=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_ifStatement682), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop47;
					}
				}

				loop47:
					;

				} finally { DebugExitSubRule(47); }

				DebugLocation(132, 79);
				PushFollow(Follow._statement_in_ifStatement686);
				statement106=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement106.Tree, statement106, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(48); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("ifStatement", 21);
			LeaveRule("ifStatement", 21);
			Leave_ifStatement();
			if (state.backtracking > 0) { Memoize(input, 21, ifStatement_StartIndex); }
		}
		DebugLocation(133, 1);
		} finally { DebugExitRule(GrammarFileName, "ifStatement"); }
		return retval;

	}
	// $ANTLR end "ifStatement"

	public class iterationStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_iterationStatement();
	partial void Leave_iterationStatement();

	// $ANTLR start "iterationStatement"
	// JavaScript.g:135:1: iterationStatement : ( doWhileStatement | whileStatement | forStatement | forInStatement );
	[GrammarRule("iterationStatement")]
	public JavaScriptParser.iterationStatement_return iterationStatement()
	{
		Enter_iterationStatement();
		EnterRule("iterationStatement", 22);
		TraceIn("iterationStatement", 22);
		JavaScriptParser.iterationStatement_return retval = new JavaScriptParser.iterationStatement_return();
		retval.Start = (IToken)input.LT(1);
		int iterationStatement_StartIndex = input.Index;
		object root_0 = null;

		JavaScriptParser.doWhileStatement_return doWhileStatement107 = default(JavaScriptParser.doWhileStatement_return);
		JavaScriptParser.whileStatement_return whileStatement108 = default(JavaScriptParser.whileStatement_return);
		JavaScriptParser.forStatement_return forStatement109 = default(JavaScriptParser.forStatement_return);
		JavaScriptParser.forInStatement_return forInStatement110 = default(JavaScriptParser.forInStatement_return);


		try { DebugEnterRule(GrammarFileName, "iterationStatement");
		DebugLocation(135, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 22)) { return retval; }
			// JavaScript.g:136:2: ( doWhileStatement | whileStatement | forStatement | forInStatement )
			int alt49=4;
			try { DebugEnterDecision(49, decisionCanBacktrack[49]);
			switch (input.LA(1))
			{
			case 52:
				{
				alt49=1;
				}
				break;
			case 53:
				{
				alt49=2;
				}
				break;
			case 54:
				{
				int LA49_3 = input.LA(2);

				if ((EvaluatePredicate(synpred67_JavaScript_fragment)))
				{
					alt49=3;
				}
				else if ((true))
				{
					alt49=4;
				}
				else
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 49, 3, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 49, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(49); }
			switch (alt49)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:136:4: doWhileStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(136, 4);
				PushFollow(Follow._doWhileStatement_in_iterationStatement700);
				doWhileStatement107=doWhileStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, doWhileStatement107.Tree, doWhileStatement107, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:137:4: whileStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(137, 4);
				PushFollow(Follow._whileStatement_in_iterationStatement705);
				whileStatement108=whileStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, whileStatement108.Tree, whileStatement108, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:138:4: forStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(138, 4);
				PushFollow(Follow._forStatement_in_iterationStatement710);
				forStatement109=forStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forStatement109.Tree, forStatement109, retval);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// JavaScript.g:139:4: forInStatement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(139, 4);
				PushFollow(Follow._forInStatement_in_iterationStatement715);
				forInStatement110=forInStatement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forInStatement110.Tree, forInStatement110, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("iterationStatement", 22);
			LeaveRule("iterationStatement", 22);
			Leave_iterationStatement();
			if (state.backtracking > 0) { Memoize(input, 22, iterationStatement_StartIndex); }
		}
		DebugLocation(140, 1);
		} finally { DebugExitRule(GrammarFileName, "iterationStatement"); }
		return retval;

	}
	// $ANTLR end "iterationStatement"

	public class doWhileStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_doWhileStatement();
	partial void Leave_doWhileStatement();

	// $ANTLR start "doWhileStatement"
	// JavaScript.g:142:1: doWhileStatement : 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression RPAREN statementEnd ;
	[GrammarRule("doWhileStatement")]
	public JavaScriptParser.doWhileStatement_return doWhileStatement()
	{
		Enter_doWhileStatement();
		EnterRule("doWhileStatement", 23);
		TraceIn("doWhileStatement", 23);
		JavaScriptParser.doWhileStatement_return retval = new JavaScriptParser.doWhileStatement_return();
		retval.Start = (IToken)input.LT(1);
		int doWhileStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal111=null;
		IToken LT112=null;
		IToken LT114=null;
		IToken string_literal115=null;
		IToken LT116=null;
		IToken char_literal117=null;
		IToken RPAREN119=null;
		JavaScriptParser.statement_return statement113 = default(JavaScriptParser.statement_return);
		JavaScriptParser.expression_return expression118 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statementEnd_return statementEnd120 = default(JavaScriptParser.statementEnd_return);

		object string_literal111_tree=null;
		object LT112_tree=null;
		object LT114_tree=null;
		object string_literal115_tree=null;
		object LT116_tree=null;
		object char_literal117_tree=null;
		object RPAREN119_tree=null;

		try { DebugEnterRule(GrammarFileName, "doWhileStatement");
		DebugLocation(142, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 23)) { return retval; }
			// JavaScript.g:143:2: ( 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression RPAREN statementEnd )
			DebugEnterAlt(1);
			// JavaScript.g:143:4: 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression RPAREN statementEnd
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(143, 4);
			string_literal111=(IToken)Match(input,52,Follow._52_in_doWhileStatement727); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal111_tree = (object)adaptor.Create(string_literal111, retval);
			adaptor.AddChild(root_0, string_literal111_tree);
			}
			DebugLocation(143, 11);
			// JavaScript.g:143:11: ( LT )*
			try { DebugEnterSubRule(50);
			while (true)
			{
				int alt50=2;
				try { DebugEnterDecision(50, decisionCanBacktrack[50]);
				int LA50_0 = input.LA(1);

				if ((LA50_0==LT))
				{
					alt50=1;
				}


				} finally { DebugExitDecision(50); }
				switch ( alt50 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(143, 11);
					LT112=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_doWhileStatement729), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop50;
				}
			}

			loop50:
				;

			} finally { DebugExitSubRule(50); }

			DebugLocation(143, 14);
			PushFollow(Follow._statement_in_doWhileStatement733);
			statement113=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement113.Tree, statement113, retval);
			DebugLocation(143, 26);
			// JavaScript.g:143:26: ( LT )*
			try { DebugEnterSubRule(51);
			while (true)
			{
				int alt51=2;
				try { DebugEnterDecision(51, decisionCanBacktrack[51]);
				int LA51_0 = input.LA(1);

				if ((LA51_0==LT))
				{
					alt51=1;
				}


				} finally { DebugExitDecision(51); }
				switch ( alt51 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(143, 26);
					LT114=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_doWhileStatement735), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop51;
				}
			}

			loop51:
				;

			} finally { DebugExitSubRule(51); }

			DebugLocation(143, 29);
			string_literal115=(IToken)Match(input,53,Follow._53_in_doWhileStatement739); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal115_tree = (object)adaptor.Create(string_literal115, retval);
			adaptor.AddChild(root_0, string_literal115_tree);
			}
			DebugLocation(143, 39);
			// JavaScript.g:143:39: ( LT )*
			try { DebugEnterSubRule(52);
			while (true)
			{
				int alt52=2;
				try { DebugEnterDecision(52, decisionCanBacktrack[52]);
				int LA52_0 = input.LA(1);

				if ((LA52_0==LT))
				{
					alt52=1;
				}


				} finally { DebugExitDecision(52); }
				switch ( alt52 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(143, 39);
					LT116=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_doWhileStatement741), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop52;
				}
			}

			loop52:
				;

			} finally { DebugExitSubRule(52); }

			DebugLocation(143, 42);
			char_literal117=(IToken)Match(input,45,Follow._45_in_doWhileStatement745); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal117_tree = (object)adaptor.Create(char_literal117, retval);
			adaptor.AddChild(root_0, char_literal117_tree);
			}
			DebugLocation(143, 46);
			PushFollow(Follow._expression_in_doWhileStatement747);
			expression118=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression118.Tree, expression118, retval);
			DebugLocation(143, 57);
			RPAREN119=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_doWhileStatement749), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN119_tree = (object)adaptor.Create(RPAREN119, retval);
			adaptor.AddChild(root_0, RPAREN119_tree);
			}
			DebugLocation(143, 64);
			PushFollow(Follow._statementEnd_in_doWhileStatement751);
			statementEnd120=statementEnd();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementEnd120.Tree, statementEnd120, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("doWhileStatement", 23);
			LeaveRule("doWhileStatement", 23);
			Leave_doWhileStatement();
			if (state.backtracking > 0) { Memoize(input, 23, doWhileStatement_StartIndex); }
		}
		DebugLocation(144, 1);
		} finally { DebugExitRule(GrammarFileName, "doWhileStatement"); }
		return retval;

	}
	// $ANTLR end "doWhileStatement"

	public class whileStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_whileStatement();
	partial void Leave_whileStatement();

	// $ANTLR start "whileStatement"
	// JavaScript.g:146:1: whileStatement : 'while' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement ;
	[GrammarRule("whileStatement")]
	public JavaScriptParser.whileStatement_return whileStatement()
	{
		Enter_whileStatement();
		EnterRule("whileStatement", 24);
		TraceIn("whileStatement", 24);
		JavaScriptParser.whileStatement_return retval = new JavaScriptParser.whileStatement_return();
		retval.Start = (IToken)input.LT(1);
		int whileStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal121=null;
		IToken LT122=null;
		IToken char_literal123=null;
		IToken LT124=null;
		IToken LT126=null;
		IToken RPAREN127=null;
		IToken LT128=null;
		JavaScriptParser.expression_return expression125 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statement_return statement129 = default(JavaScriptParser.statement_return);

		object string_literal121_tree=null;
		object LT122_tree=null;
		object char_literal123_tree=null;
		object LT124_tree=null;
		object LT126_tree=null;
		object RPAREN127_tree=null;
		object LT128_tree=null;

		try { DebugEnterRule(GrammarFileName, "whileStatement");
		DebugLocation(146, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 24)) { return retval; }
			// JavaScript.g:147:2: ( 'while' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement )
			DebugEnterAlt(1);
			// JavaScript.g:147:4: 'while' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(147, 4);
			string_literal121=(IToken)Match(input,53,Follow._53_in_whileStatement763); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal121_tree = (object)adaptor.Create(string_literal121, retval);
			adaptor.AddChild(root_0, string_literal121_tree);
			}
			DebugLocation(147, 14);
			// JavaScript.g:147:14: ( LT )*
			try { DebugEnterSubRule(53);
			while (true)
			{
				int alt53=2;
				try { DebugEnterDecision(53, decisionCanBacktrack[53]);
				int LA53_0 = input.LA(1);

				if ((LA53_0==LT))
				{
					alt53=1;
				}


				} finally { DebugExitDecision(53); }
				switch ( alt53 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(147, 14);
					LT122=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_whileStatement765), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop53;
				}
			}

			loop53:
				;

			} finally { DebugExitSubRule(53); }

			DebugLocation(147, 17);
			char_literal123=(IToken)Match(input,45,Follow._45_in_whileStatement769); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal123_tree = (object)adaptor.Create(char_literal123, retval);
			adaptor.AddChild(root_0, char_literal123_tree);
			}
			DebugLocation(147, 23);
			// JavaScript.g:147:23: ( LT )*
			try { DebugEnterSubRule(54);
			while (true)
			{
				int alt54=2;
				try { DebugEnterDecision(54, decisionCanBacktrack[54]);
				int LA54_0 = input.LA(1);

				if ((LA54_0==LT))
				{
					alt54=1;
				}


				} finally { DebugExitDecision(54); }
				switch ( alt54 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(147, 23);
					LT124=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_whileStatement771), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop54;
				}
			}

			loop54:
				;

			} finally { DebugExitSubRule(54); }

			DebugLocation(147, 26);
			PushFollow(Follow._expression_in_whileStatement775);
			expression125=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression125.Tree, expression125, retval);
			DebugLocation(147, 39);
			// JavaScript.g:147:39: ( LT )*
			try { DebugEnterSubRule(55);
			while (true)
			{
				int alt55=2;
				try { DebugEnterDecision(55, decisionCanBacktrack[55]);
				int LA55_0 = input.LA(1);

				if ((LA55_0==LT))
				{
					alt55=1;
				}


				} finally { DebugExitDecision(55); }
				switch ( alt55 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(147, 39);
					LT126=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_whileStatement777), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop55;
				}
			}

			loop55:
				;

			} finally { DebugExitSubRule(55); }

			DebugLocation(147, 42);
			RPAREN127=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_whileStatement781), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN127_tree = (object)adaptor.Create(RPAREN127, retval);
			adaptor.AddChild(root_0, RPAREN127_tree);
			}
			DebugLocation(147, 51);
			// JavaScript.g:147:51: ( LT )*
			try { DebugEnterSubRule(56);
			while (true)
			{
				int alt56=2;
				try { DebugEnterDecision(56, decisionCanBacktrack[56]);
				int LA56_0 = input.LA(1);

				if ((LA56_0==LT))
				{
					alt56=1;
				}


				} finally { DebugExitDecision(56); }
				switch ( alt56 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(147, 51);
					LT128=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_whileStatement783), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop56;
				}
			}

			loop56:
				;

			} finally { DebugExitSubRule(56); }

			DebugLocation(147, 54);
			PushFollow(Follow._statement_in_whileStatement787);
			statement129=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement129.Tree, statement129, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("whileStatement", 24);
			LeaveRule("whileStatement", 24);
			Leave_whileStatement();
			if (state.backtracking > 0) { Memoize(input, 24, whileStatement_StartIndex); }
		}
		DebugLocation(148, 1);
		} finally { DebugExitRule(GrammarFileName, "whileStatement"); }
		return retval;

	}
	// $ANTLR end "whileStatement"

	public class forStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forStatement();
	partial void Leave_forStatement();

	// $ANTLR start "forStatement"
	// JavaScript.g:150:1: forStatement : 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* RPAREN ( LT )* statement ;
	[GrammarRule("forStatement")]
	public JavaScriptParser.forStatement_return forStatement()
	{
		Enter_forStatement();
		EnterRule("forStatement", 25);
		TraceIn("forStatement", 25);
		JavaScriptParser.forStatement_return retval = new JavaScriptParser.forStatement_return();
		retval.Start = (IToken)input.LT(1);
		int forStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal130=null;
		IToken LT131=null;
		IToken char_literal132=null;
		IToken LT133=null;
		IToken LT135=null;
		IToken char_literal136=null;
		IToken LT137=null;
		IToken LT139=null;
		IToken char_literal140=null;
		IToken LT141=null;
		IToken LT143=null;
		IToken RPAREN144=null;
		IToken LT145=null;
		JavaScriptParser.forStatementInitialiserPart_return forStatementInitialiserPart134 = default(JavaScriptParser.forStatementInitialiserPart_return);
		JavaScriptParser.expression_return expression138 = default(JavaScriptParser.expression_return);
		JavaScriptParser.expression_return expression142 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statement_return statement146 = default(JavaScriptParser.statement_return);

		object string_literal130_tree=null;
		object LT131_tree=null;
		object char_literal132_tree=null;
		object LT133_tree=null;
		object LT135_tree=null;
		object char_literal136_tree=null;
		object LT137_tree=null;
		object LT139_tree=null;
		object char_literal140_tree=null;
		object LT141_tree=null;
		object LT143_tree=null;
		object RPAREN144_tree=null;
		object LT145_tree=null;

		try { DebugEnterRule(GrammarFileName, "forStatement");
		DebugLocation(150, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 25)) { return retval; }
			// JavaScript.g:151:2: ( 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* RPAREN ( LT )* statement )
			DebugEnterAlt(1);
			// JavaScript.g:151:4: 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* RPAREN ( LT )* statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(151, 4);
			string_literal130=(IToken)Match(input,54,Follow._54_in_forStatement799); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal130_tree = (object)adaptor.Create(string_literal130, retval);
			adaptor.AddChild(root_0, string_literal130_tree);
			}
			DebugLocation(151, 12);
			// JavaScript.g:151:12: ( LT )*
			try { DebugEnterSubRule(57);
			while (true)
			{
				int alt57=2;
				try { DebugEnterDecision(57, decisionCanBacktrack[57]);
				int LA57_0 = input.LA(1);

				if ((LA57_0==LT))
				{
					alt57=1;
				}


				} finally { DebugExitDecision(57); }
				switch ( alt57 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(151, 12);
					LT131=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement801), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop57;
				}
			}

			loop57:
				;

			} finally { DebugExitSubRule(57); }

			DebugLocation(151, 15);
			char_literal132=(IToken)Match(input,45,Follow._45_in_forStatement805); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal132_tree = (object)adaptor.Create(char_literal132, retval);
			adaptor.AddChild(root_0, char_literal132_tree);
			}
			DebugLocation(151, 19);
			// JavaScript.g:151:19: ( ( LT )* forStatementInitialiserPart )?
			int alt59=2;
			try { DebugEnterSubRule(59);
			try { DebugEnterDecision(59, decisionCanBacktrack[59]);
			try
			{
				alt59 = dfa59.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(59); }
			switch (alt59)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:151:20: ( LT )* forStatementInitialiserPart
				{
				DebugLocation(151, 22);
				// JavaScript.g:151:22: ( LT )*
				try { DebugEnterSubRule(58);
				while (true)
				{
					int alt58=2;
					try { DebugEnterDecision(58, decisionCanBacktrack[58]);
					int LA58_0 = input.LA(1);

					if ((LA58_0==LT))
					{
						alt58=1;
					}


					} finally { DebugExitDecision(58); }
					switch ( alt58 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(151, 22);
						LT133=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement808), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop58;
					}
				}

				loop58:
					;

				} finally { DebugExitSubRule(58); }

				DebugLocation(151, 25);
				PushFollow(Follow._forStatementInitialiserPart_in_forStatement812);
				forStatementInitialiserPart134=forStatementInitialiserPart();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forStatementInitialiserPart134.Tree, forStatementInitialiserPart134, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(59); }

			DebugLocation(151, 57);
			// JavaScript.g:151:57: ( LT )*
			try { DebugEnterSubRule(60);
			while (true)
			{
				int alt60=2;
				try { DebugEnterDecision(60, decisionCanBacktrack[60]);
				int LA60_0 = input.LA(1);

				if ((LA60_0==LT))
				{
					alt60=1;
				}


				} finally { DebugExitDecision(60); }
				switch ( alt60 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(151, 57);
					LT135=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement816), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop60;
				}
			}

			loop60:
				;

			} finally { DebugExitSubRule(60); }

			DebugLocation(151, 60);
			char_literal136=(IToken)Match(input,43,Follow._43_in_forStatement820); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal136_tree = (object)adaptor.Create(char_literal136, retval);
			adaptor.AddChild(root_0, char_literal136_tree);
			}
			DebugLocation(151, 64);
			// JavaScript.g:151:64: ( ( LT )* expression )?
			int alt62=2;
			try { DebugEnterSubRule(62);
			try { DebugEnterDecision(62, decisionCanBacktrack[62]);
			try
			{
				alt62 = dfa62.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(62); }
			switch (alt62)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:151:65: ( LT )* expression
				{
				DebugLocation(151, 67);
				// JavaScript.g:151:67: ( LT )*
				try { DebugEnterSubRule(61);
				while (true)
				{
					int alt61=2;
					try { DebugEnterDecision(61, decisionCanBacktrack[61]);
					int LA61_0 = input.LA(1);

					if ((LA61_0==LT))
					{
						alt61=1;
					}


					} finally { DebugExitDecision(61); }
					switch ( alt61 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(151, 67);
						LT137=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement823), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop61;
					}
				}

				loop61:
					;

				} finally { DebugExitSubRule(61); }

				DebugLocation(151, 70);
				PushFollow(Follow._expression_in_forStatement827);
				expression138=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression138.Tree, expression138, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(62); }

			DebugLocation(151, 85);
			// JavaScript.g:151:85: ( LT )*
			try { DebugEnterSubRule(63);
			while (true)
			{
				int alt63=2;
				try { DebugEnterDecision(63, decisionCanBacktrack[63]);
				int LA63_0 = input.LA(1);

				if ((LA63_0==LT))
				{
					alt63=1;
				}


				} finally { DebugExitDecision(63); }
				switch ( alt63 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(151, 85);
					LT139=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement831), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop63;
				}
			}

			loop63:
				;

			} finally { DebugExitSubRule(63); }

			DebugLocation(151, 88);
			char_literal140=(IToken)Match(input,43,Follow._43_in_forStatement835); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal140_tree = (object)adaptor.Create(char_literal140, retval);
			adaptor.AddChild(root_0, char_literal140_tree);
			}
			DebugLocation(151, 92);
			// JavaScript.g:151:92: ( ( LT )* expression )?
			int alt65=2;
			try { DebugEnterSubRule(65);
			try { DebugEnterDecision(65, decisionCanBacktrack[65]);
			try
			{
				alt65 = dfa65.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(65); }
			switch (alt65)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:151:93: ( LT )* expression
				{
				DebugLocation(151, 95);
				// JavaScript.g:151:95: ( LT )*
				try { DebugEnterSubRule(64);
				while (true)
				{
					int alt64=2;
					try { DebugEnterDecision(64, decisionCanBacktrack[64]);
					int LA64_0 = input.LA(1);

					if ((LA64_0==LT))
					{
						alt64=1;
					}


					} finally { DebugExitDecision(64); }
					switch ( alt64 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(151, 95);
						LT141=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement838), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop64;
					}
				}

				loop64:
					;

				} finally { DebugExitSubRule(64); }

				DebugLocation(151, 98);
				PushFollow(Follow._expression_in_forStatement842);
				expression142=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression142.Tree, expression142, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(65); }

			DebugLocation(151, 113);
			// JavaScript.g:151:113: ( LT )*
			try { DebugEnterSubRule(66);
			while (true)
			{
				int alt66=2;
				try { DebugEnterDecision(66, decisionCanBacktrack[66]);
				int LA66_0 = input.LA(1);

				if ((LA66_0==LT))
				{
					alt66=1;
				}


				} finally { DebugExitDecision(66); }
				switch ( alt66 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(151, 113);
					LT143=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement846), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop66;
				}
			}

			loop66:
				;

			} finally { DebugExitSubRule(66); }

			DebugLocation(151, 116);
			RPAREN144=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_forStatement850), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN144_tree = (object)adaptor.Create(RPAREN144, retval);
			adaptor.AddChild(root_0, RPAREN144_tree);
			}
			DebugLocation(151, 125);
			// JavaScript.g:151:125: ( LT )*
			try { DebugEnterSubRule(67);
			while (true)
			{
				int alt67=2;
				try { DebugEnterDecision(67, decisionCanBacktrack[67]);
				int LA67_0 = input.LA(1);

				if ((LA67_0==LT))
				{
					alt67=1;
				}


				} finally { DebugExitDecision(67); }
				switch ( alt67 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(151, 125);
					LT145=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatement852), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop67;
				}
			}

			loop67:
				;

			} finally { DebugExitSubRule(67); }

			DebugLocation(151, 128);
			PushFollow(Follow._statement_in_forStatement856);
			statement146=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement146.Tree, statement146, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forStatement", 25);
			LeaveRule("forStatement", 25);
			Leave_forStatement();
			if (state.backtracking > 0) { Memoize(input, 25, forStatement_StartIndex); }
		}
		DebugLocation(152, 1);
		} finally { DebugExitRule(GrammarFileName, "forStatement"); }
		return retval;

	}
	// $ANTLR end "forStatement"

	public class forStatementInitialiserPart_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forStatementInitialiserPart();
	partial void Leave_forStatementInitialiserPart();

	// $ANTLR start "forStatementInitialiserPart"
	// JavaScript.g:154:1: forStatementInitialiserPart : ( expressionNoIn | 'var' ( LT )* variableDeclarationListNoIn );
	[GrammarRule("forStatementInitialiserPart")]
	public JavaScriptParser.forStatementInitialiserPart_return forStatementInitialiserPart()
	{
		Enter_forStatementInitialiserPart();
		EnterRule("forStatementInitialiserPart", 26);
		TraceIn("forStatementInitialiserPart", 26);
		JavaScriptParser.forStatementInitialiserPart_return retval = new JavaScriptParser.forStatementInitialiserPart_return();
		retval.Start = (IToken)input.LT(1);
		int forStatementInitialiserPart_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal148=null;
		IToken LT149=null;
		JavaScriptParser.expressionNoIn_return expressionNoIn147 = default(JavaScriptParser.expressionNoIn_return);
		JavaScriptParser.variableDeclarationListNoIn_return variableDeclarationListNoIn150 = default(JavaScriptParser.variableDeclarationListNoIn_return);

		object string_literal148_tree=null;
		object LT149_tree=null;

		try { DebugEnterRule(GrammarFileName, "forStatementInitialiserPart");
		DebugLocation(154, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 26)) { return retval; }
			// JavaScript.g:155:2: ( expressionNoIn | 'var' ( LT )* variableDeclarationListNoIn )
			int alt69=2;
			try { DebugEnterDecision(69, decisionCanBacktrack[69]);
			int LA69_0 = input.LA(1);

			if (((LA69_0>=NULL && LA69_0<=THIS)||(LA69_0>=Identifier && LA69_0<=RegularExpressionLiteral)||(LA69_0>=44 && LA69_0<=45)||LA69_0==47||(LA69_0>=68 && LA69_0<=69)||(LA69_0>=100 && LA69_0<=101)||(LA69_0>=105 && LA69_0<=111)))
			{
				alt69=1;
			}
			else if ((LA69_0==48))
			{
				alt69=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 69, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(69); }
			switch (alt69)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:155:4: expressionNoIn
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(155, 4);
				PushFollow(Follow._expressionNoIn_in_forStatementInitialiserPart868);
				expressionNoIn147=expressionNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionNoIn147.Tree, expressionNoIn147, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:156:4: 'var' ( LT )* variableDeclarationListNoIn
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(156, 4);
				string_literal148=(IToken)Match(input,48,Follow._48_in_forStatementInitialiserPart873); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal148_tree = (object)adaptor.Create(string_literal148, retval);
				adaptor.AddChild(root_0, string_literal148_tree);
				}
				DebugLocation(156, 12);
				// JavaScript.g:156:12: ( LT )*
				try { DebugEnterSubRule(68);
				while (true)
				{
					int alt68=2;
					try { DebugEnterDecision(68, decisionCanBacktrack[68]);
					int LA68_0 = input.LA(1);

					if ((LA68_0==LT))
					{
						alt68=1;
					}


					} finally { DebugExitDecision(68); }
					switch ( alt68 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(156, 12);
						LT149=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forStatementInitialiserPart875), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop68;
					}
				}

				loop68:
					;

				} finally { DebugExitSubRule(68); }

				DebugLocation(156, 15);
				PushFollow(Follow._variableDeclarationListNoIn_in_forStatementInitialiserPart879);
				variableDeclarationListNoIn150=variableDeclarationListNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationListNoIn150.Tree, variableDeclarationListNoIn150, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forStatementInitialiserPart", 26);
			LeaveRule("forStatementInitialiserPart", 26);
			Leave_forStatementInitialiserPart();
			if (state.backtracking > 0) { Memoize(input, 26, forStatementInitialiserPart_StartIndex); }
		}
		DebugLocation(157, 1);
		} finally { DebugExitRule(GrammarFileName, "forStatementInitialiserPart"); }
		return retval;

	}
	// $ANTLR end "forStatementInitialiserPart"

	public class forInStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forInStatement();
	partial void Leave_forInStatement();

	// $ANTLR start "forInStatement"
	// JavaScript.g:159:1: forInStatement : 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* RPAREN ( LT )* statement ;
	[GrammarRule("forInStatement")]
	public JavaScriptParser.forInStatement_return forInStatement()
	{
		Enter_forInStatement();
		EnterRule("forInStatement", 27);
		TraceIn("forInStatement", 27);
		JavaScriptParser.forInStatement_return retval = new JavaScriptParser.forInStatement_return();
		retval.Start = (IToken)input.LT(1);
		int forInStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal151=null;
		IToken LT152=null;
		IToken char_literal153=null;
		IToken LT154=null;
		IToken LT156=null;
		IToken string_literal157=null;
		IToken LT158=null;
		IToken LT160=null;
		IToken RPAREN161=null;
		IToken LT162=null;
		JavaScriptParser.forInStatementInitialiserPart_return forInStatementInitialiserPart155 = default(JavaScriptParser.forInStatementInitialiserPart_return);
		JavaScriptParser.expression_return expression159 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statement_return statement163 = default(JavaScriptParser.statement_return);

		object string_literal151_tree=null;
		object LT152_tree=null;
		object char_literal153_tree=null;
		object LT154_tree=null;
		object LT156_tree=null;
		object string_literal157_tree=null;
		object LT158_tree=null;
		object LT160_tree=null;
		object RPAREN161_tree=null;
		object LT162_tree=null;

		try { DebugEnterRule(GrammarFileName, "forInStatement");
		DebugLocation(159, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 27)) { return retval; }
			// JavaScript.g:160:2: ( 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* RPAREN ( LT )* statement )
			DebugEnterAlt(1);
			// JavaScript.g:160:4: 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* RPAREN ( LT )* statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(160, 4);
			string_literal151=(IToken)Match(input,54,Follow._54_in_forInStatement891); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal151_tree = (object)adaptor.Create(string_literal151, retval);
			adaptor.AddChild(root_0, string_literal151_tree);
			}
			DebugLocation(160, 12);
			// JavaScript.g:160:12: ( LT )*
			try { DebugEnterSubRule(70);
			while (true)
			{
				int alt70=2;
				try { DebugEnterDecision(70, decisionCanBacktrack[70]);
				int LA70_0 = input.LA(1);

				if ((LA70_0==LT))
				{
					alt70=1;
				}


				} finally { DebugExitDecision(70); }
				switch ( alt70 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(160, 12);
					LT152=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forInStatement893), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop70;
				}
			}

			loop70:
				;

			} finally { DebugExitSubRule(70); }

			DebugLocation(160, 15);
			char_literal153=(IToken)Match(input,45,Follow._45_in_forInStatement897); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal153_tree = (object)adaptor.Create(char_literal153, retval);
			adaptor.AddChild(root_0, char_literal153_tree);
			}
			DebugLocation(160, 21);
			// JavaScript.g:160:21: ( LT )*
			try { DebugEnterSubRule(71);
			while (true)
			{
				int alt71=2;
				try { DebugEnterDecision(71, decisionCanBacktrack[71]);
				int LA71_0 = input.LA(1);

				if ((LA71_0==LT))
				{
					alt71=1;
				}


				} finally { DebugExitDecision(71); }
				switch ( alt71 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(160, 21);
					LT154=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forInStatement899), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop71;
				}
			}

			loop71:
				;

			} finally { DebugExitSubRule(71); }

			DebugLocation(160, 24);
			PushFollow(Follow._forInStatementInitialiserPart_in_forInStatement903);
			forInStatementInitialiserPart155=forInStatementInitialiserPart();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forInStatementInitialiserPart155.Tree, forInStatementInitialiserPart155, retval);
			DebugLocation(160, 56);
			// JavaScript.g:160:56: ( LT )*
			try { DebugEnterSubRule(72);
			while (true)
			{
				int alt72=2;
				try { DebugEnterDecision(72, decisionCanBacktrack[72]);
				int LA72_0 = input.LA(1);

				if ((LA72_0==LT))
				{
					alt72=1;
				}


				} finally { DebugExitDecision(72); }
				switch ( alt72 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(160, 56);
					LT156=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forInStatement905), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop72;
				}
			}

			loop72:
				;

			} finally { DebugExitSubRule(72); }

			DebugLocation(160, 59);
			string_literal157=(IToken)Match(input,55,Follow._55_in_forInStatement909); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal157_tree = (object)adaptor.Create(string_literal157, retval);
			adaptor.AddChild(root_0, string_literal157_tree);
			}
			DebugLocation(160, 66);
			// JavaScript.g:160:66: ( LT )*
			try { DebugEnterSubRule(73);
			while (true)
			{
				int alt73=2;
				try { DebugEnterDecision(73, decisionCanBacktrack[73]);
				int LA73_0 = input.LA(1);

				if ((LA73_0==LT))
				{
					alt73=1;
				}


				} finally { DebugExitDecision(73); }
				switch ( alt73 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(160, 66);
					LT158=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forInStatement911), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop73;
				}
			}

			loop73:
				;

			} finally { DebugExitSubRule(73); }

			DebugLocation(160, 69);
			PushFollow(Follow._expression_in_forInStatement915);
			expression159=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression159.Tree, expression159, retval);
			DebugLocation(160, 82);
			// JavaScript.g:160:82: ( LT )*
			try { DebugEnterSubRule(74);
			while (true)
			{
				int alt74=2;
				try { DebugEnterDecision(74, decisionCanBacktrack[74]);
				int LA74_0 = input.LA(1);

				if ((LA74_0==LT))
				{
					alt74=1;
				}


				} finally { DebugExitDecision(74); }
				switch ( alt74 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(160, 82);
					LT160=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forInStatement917), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop74;
				}
			}

			loop74:
				;

			} finally { DebugExitSubRule(74); }

			DebugLocation(160, 85);
			RPAREN161=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_forInStatement921), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN161_tree = (object)adaptor.Create(RPAREN161, retval);
			adaptor.AddChild(root_0, RPAREN161_tree);
			}
			DebugLocation(160, 94);
			// JavaScript.g:160:94: ( LT )*
			try { DebugEnterSubRule(75);
			while (true)
			{
				int alt75=2;
				try { DebugEnterDecision(75, decisionCanBacktrack[75]);
				int LA75_0 = input.LA(1);

				if ((LA75_0==LT))
				{
					alt75=1;
				}


				} finally { DebugExitDecision(75); }
				switch ( alt75 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(160, 94);
					LT162=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forInStatement923), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop75;
				}
			}

			loop75:
				;

			} finally { DebugExitSubRule(75); }

			DebugLocation(160, 97);
			PushFollow(Follow._statement_in_forInStatement927);
			statement163=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement163.Tree, statement163, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forInStatement", 27);
			LeaveRule("forInStatement", 27);
			Leave_forInStatement();
			if (state.backtracking > 0) { Memoize(input, 27, forInStatement_StartIndex); }
		}
		DebugLocation(161, 1);
		} finally { DebugExitRule(GrammarFileName, "forInStatement"); }
		return retval;

	}
	// $ANTLR end "forInStatement"

	public class forInStatementInitialiserPart_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_forInStatementInitialiserPart();
	partial void Leave_forInStatementInitialiserPart();

	// $ANTLR start "forInStatementInitialiserPart"
	// JavaScript.g:163:1: forInStatementInitialiserPart : ( leftHandSideExpression | 'var' ( LT )* variableDeclarationNoIn );
	[GrammarRule("forInStatementInitialiserPart")]
	public JavaScriptParser.forInStatementInitialiserPart_return forInStatementInitialiserPart()
	{
		Enter_forInStatementInitialiserPart();
		EnterRule("forInStatementInitialiserPart", 28);
		TraceIn("forInStatementInitialiserPart", 28);
		JavaScriptParser.forInStatementInitialiserPart_return retval = new JavaScriptParser.forInStatementInitialiserPart_return();
		retval.Start = (IToken)input.LT(1);
		int forInStatementInitialiserPart_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal165=null;
		IToken LT166=null;
		JavaScriptParser.leftHandSideExpression_return leftHandSideExpression164 = default(JavaScriptParser.leftHandSideExpression_return);
		JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn167 = default(JavaScriptParser.variableDeclarationNoIn_return);

		object string_literal165_tree=null;
		object LT166_tree=null;

		try { DebugEnterRule(GrammarFileName, "forInStatementInitialiserPart");
		DebugLocation(163, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 28)) { return retval; }
			// JavaScript.g:164:2: ( leftHandSideExpression | 'var' ( LT )* variableDeclarationNoIn )
			int alt77=2;
			try { DebugEnterDecision(77, decisionCanBacktrack[77]);
			int LA77_0 = input.LA(1);

			if (((LA77_0>=NULL && LA77_0<=THIS)||(LA77_0>=Identifier && LA77_0<=RegularExpressionLiteral)||(LA77_0>=44 && LA77_0<=45)||LA77_0==47||(LA77_0>=68 && LA77_0<=69)))
			{
				alt77=1;
			}
			else if ((LA77_0==48))
			{
				alt77=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 77, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(77); }
			switch (alt77)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:164:4: leftHandSideExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(164, 4);
				PushFollow(Follow._leftHandSideExpression_in_forInStatementInitialiserPart939);
				leftHandSideExpression164=leftHandSideExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression164.Tree, leftHandSideExpression164, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:165:4: 'var' ( LT )* variableDeclarationNoIn
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(165, 4);
				string_literal165=(IToken)Match(input,48,Follow._48_in_forInStatementInitialiserPart944); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal165_tree = (object)adaptor.Create(string_literal165, retval);
				adaptor.AddChild(root_0, string_literal165_tree);
				}
				DebugLocation(165, 12);
				// JavaScript.g:165:12: ( LT )*
				try { DebugEnterSubRule(76);
				while (true)
				{
					int alt76=2;
					try { DebugEnterDecision(76, decisionCanBacktrack[76]);
					int LA76_0 = input.LA(1);

					if ((LA76_0==LT))
					{
						alt76=1;
					}


					} finally { DebugExitDecision(76); }
					switch ( alt76 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(165, 12);
						LT166=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_forInStatementInitialiserPart946), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop76;
					}
				}

				loop76:
					;

				} finally { DebugExitSubRule(76); }

				DebugLocation(165, 15);
				PushFollow(Follow._variableDeclarationNoIn_in_forInStatementInitialiserPart950);
				variableDeclarationNoIn167=variableDeclarationNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn167.Tree, variableDeclarationNoIn167, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("forInStatementInitialiserPart", 28);
			LeaveRule("forInStatementInitialiserPart", 28);
			Leave_forInStatementInitialiserPart();
			if (state.backtracking > 0) { Memoize(input, 28, forInStatementInitialiserPart_StartIndex); }
		}
		DebugLocation(166, 1);
		} finally { DebugExitRule(GrammarFileName, "forInStatementInitialiserPart"); }
		return retval;

	}
	// $ANTLR end "forInStatementInitialiserPart"

	public class continueStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_continueStatement();
	partial void Leave_continueStatement();

	// $ANTLR start "continueStatement"
	// JavaScript.g:168:1: continueStatement : 'continue' ( Identifier )? statementEnd ;
	[GrammarRule("continueStatement")]
	public JavaScriptParser.continueStatement_return continueStatement()
	{
		Enter_continueStatement();
		EnterRule("continueStatement", 29);
		TraceIn("continueStatement", 29);
		JavaScriptParser.continueStatement_return retval = new JavaScriptParser.continueStatement_return();
		retval.Start = (IToken)input.LT(1);
		int continueStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal168=null;
		IToken Identifier169=null;
		JavaScriptParser.statementEnd_return statementEnd170 = default(JavaScriptParser.statementEnd_return);

		object string_literal168_tree=null;
		object Identifier169_tree=null;

		try { DebugEnterRule(GrammarFileName, "continueStatement");
		DebugLocation(168, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 29)) { return retval; }
			// JavaScript.g:169:2: ( 'continue' ( Identifier )? statementEnd )
			DebugEnterAlt(1);
			// JavaScript.g:169:4: 'continue' ( Identifier )? statementEnd
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(169, 4);
			string_literal168=(IToken)Match(input,56,Follow._56_in_continueStatement961); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal168_tree = (object)adaptor.Create(string_literal168, retval);
			adaptor.AddChild(root_0, string_literal168_tree);
			}
			DebugLocation(169, 15);
			// JavaScript.g:169:15: ( Identifier )?
			int alt78=2;
			try { DebugEnterSubRule(78);
			try { DebugEnterDecision(78, decisionCanBacktrack[78]);
			int LA78_0 = input.LA(1);

			if ((LA78_0==Identifier))
			{
				int LA78_1 = input.LA(2);

				if ((EvaluatePredicate(synpred96_JavaScript_fragment)))
				{
					alt78=1;
				}
			}
			} finally { DebugExitDecision(78); }
			switch (alt78)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: Identifier
				{
				DebugLocation(169, 15);
				Identifier169=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_continueStatement963), "Identifier"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				Identifier169_tree = (object)adaptor.Create(Identifier169, retval);
				adaptor.AddChild(root_0, Identifier169_tree);
				}

				}
				break;

			}
			} finally { DebugExitSubRule(78); }

			DebugLocation(169, 27);
			PushFollow(Follow._statementEnd_in_continueStatement966);
			statementEnd170=statementEnd();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementEnd170.Tree, statementEnd170, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("continueStatement", 29);
			LeaveRule("continueStatement", 29);
			Leave_continueStatement();
			if (state.backtracking > 0) { Memoize(input, 29, continueStatement_StartIndex); }
		}
		DebugLocation(170, 1);
		} finally { DebugExitRule(GrammarFileName, "continueStatement"); }
		return retval;

	}
	// $ANTLR end "continueStatement"

	public class breakStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_breakStatement();
	partial void Leave_breakStatement();

	// $ANTLR start "breakStatement"
	// JavaScript.g:172:1: breakStatement : 'break' ( Identifier )? statementEnd ;
	[GrammarRule("breakStatement")]
	public JavaScriptParser.breakStatement_return breakStatement()
	{
		Enter_breakStatement();
		EnterRule("breakStatement", 30);
		TraceIn("breakStatement", 30);
		JavaScriptParser.breakStatement_return retval = new JavaScriptParser.breakStatement_return();
		retval.Start = (IToken)input.LT(1);
		int breakStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal171=null;
		IToken Identifier172=null;
		JavaScriptParser.statementEnd_return statementEnd173 = default(JavaScriptParser.statementEnd_return);

		object string_literal171_tree=null;
		object Identifier172_tree=null;

		try { DebugEnterRule(GrammarFileName, "breakStatement");
		DebugLocation(172, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 30)) { return retval; }
			// JavaScript.g:173:2: ( 'break' ( Identifier )? statementEnd )
			DebugEnterAlt(1);
			// JavaScript.g:173:4: 'break' ( Identifier )? statementEnd
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(173, 4);
			string_literal171=(IToken)Match(input,57,Follow._57_in_breakStatement977); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal171_tree = (object)adaptor.Create(string_literal171, retval);
			adaptor.AddChild(root_0, string_literal171_tree);
			}
			DebugLocation(173, 12);
			// JavaScript.g:173:12: ( Identifier )?
			int alt79=2;
			try { DebugEnterSubRule(79);
			try { DebugEnterDecision(79, decisionCanBacktrack[79]);
			int LA79_0 = input.LA(1);

			if ((LA79_0==Identifier))
			{
				int LA79_1 = input.LA(2);

				if ((EvaluatePredicate(synpred97_JavaScript_fragment)))
				{
					alt79=1;
				}
			}
			} finally { DebugExitDecision(79); }
			switch (alt79)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: Identifier
				{
				DebugLocation(173, 12);
				Identifier172=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_breakStatement979), "Identifier"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				Identifier172_tree = (object)adaptor.Create(Identifier172, retval);
				adaptor.AddChild(root_0, Identifier172_tree);
				}

				}
				break;

			}
			} finally { DebugExitSubRule(79); }

			DebugLocation(173, 24);
			PushFollow(Follow._statementEnd_in_breakStatement982);
			statementEnd173=statementEnd();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementEnd173.Tree, statementEnd173, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("breakStatement", 30);
			LeaveRule("breakStatement", 30);
			Leave_breakStatement();
			if (state.backtracking > 0) { Memoize(input, 30, breakStatement_StartIndex); }
		}
		DebugLocation(174, 1);
		} finally { DebugExitRule(GrammarFileName, "breakStatement"); }
		return retval;

	}
	// $ANTLR end "breakStatement"

	public class returnStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_returnStatement();
	partial void Leave_returnStatement();

	// $ANTLR start "returnStatement"
	// JavaScript.g:176:1: returnStatement : 'return' ( expression )? statementEnd ;
	[GrammarRule("returnStatement")]
	public JavaScriptParser.returnStatement_return returnStatement()
	{
		Enter_returnStatement();
		EnterRule("returnStatement", 31);
		TraceIn("returnStatement", 31);
		JavaScriptParser.returnStatement_return retval = new JavaScriptParser.returnStatement_return();
		retval.Start = (IToken)input.LT(1);
		int returnStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal174=null;
		JavaScriptParser.expression_return expression175 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statementEnd_return statementEnd176 = default(JavaScriptParser.statementEnd_return);

		object string_literal174_tree=null;

		try { DebugEnterRule(GrammarFileName, "returnStatement");
		DebugLocation(176, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 31)) { return retval; }
			// JavaScript.g:177:2: ( 'return' ( expression )? statementEnd )
			DebugEnterAlt(1);
			// JavaScript.g:177:4: 'return' ( expression )? statementEnd
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(177, 4);
			string_literal174=(IToken)Match(input,58,Follow._58_in_returnStatement993); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal174_tree = (object)adaptor.Create(string_literal174, retval);
			adaptor.AddChild(root_0, string_literal174_tree);
			}
			DebugLocation(177, 13);
			// JavaScript.g:177:13: ( expression )?
			int alt80=2;
			try { DebugEnterSubRule(80);
			try { DebugEnterDecision(80, decisionCanBacktrack[80]);
			try
			{
				alt80 = dfa80.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(80); }
			switch (alt80)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: expression
				{
				DebugLocation(177, 13);
				PushFollow(Follow._expression_in_returnStatement995);
				expression175=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression175.Tree, expression175, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(80); }

			DebugLocation(177, 25);
			PushFollow(Follow._statementEnd_in_returnStatement998);
			statementEnd176=statementEnd();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementEnd176.Tree, statementEnd176, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("returnStatement", 31);
			LeaveRule("returnStatement", 31);
			Leave_returnStatement();
			if (state.backtracking > 0) { Memoize(input, 31, returnStatement_StartIndex); }
		}
		DebugLocation(178, 1);
		} finally { DebugExitRule(GrammarFileName, "returnStatement"); }
		return retval;

	}
	// $ANTLR end "returnStatement"

	public class withStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_withStatement();
	partial void Leave_withStatement();

	// $ANTLR start "withStatement"
	// JavaScript.g:180:1: withStatement : 'with' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement ;
	[GrammarRule("withStatement")]
	public JavaScriptParser.withStatement_return withStatement()
	{
		Enter_withStatement();
		EnterRule("withStatement", 32);
		TraceIn("withStatement", 32);
		JavaScriptParser.withStatement_return retval = new JavaScriptParser.withStatement_return();
		retval.Start = (IToken)input.LT(1);
		int withStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal177=null;
		IToken LT178=null;
		IToken char_literal179=null;
		IToken LT180=null;
		IToken LT182=null;
		IToken RPAREN183=null;
		IToken LT184=null;
		JavaScriptParser.expression_return expression181 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statement_return statement185 = default(JavaScriptParser.statement_return);

		object string_literal177_tree=null;
		object LT178_tree=null;
		object char_literal179_tree=null;
		object LT180_tree=null;
		object LT182_tree=null;
		object RPAREN183_tree=null;
		object LT184_tree=null;

		try { DebugEnterRule(GrammarFileName, "withStatement");
		DebugLocation(180, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 32)) { return retval; }
			// JavaScript.g:181:2: ( 'with' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement )
			DebugEnterAlt(1);
			// JavaScript.g:181:4: 'with' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(181, 4);
			string_literal177=(IToken)Match(input,59,Follow._59_in_withStatement1010); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal177_tree = (object)adaptor.Create(string_literal177, retval);
			adaptor.AddChild(root_0, string_literal177_tree);
			}
			DebugLocation(181, 13);
			// JavaScript.g:181:13: ( LT )*
			try { DebugEnterSubRule(81);
			while (true)
			{
				int alt81=2;
				try { DebugEnterDecision(81, decisionCanBacktrack[81]);
				int LA81_0 = input.LA(1);

				if ((LA81_0==LT))
				{
					alt81=1;
				}


				} finally { DebugExitDecision(81); }
				switch ( alt81 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(181, 13);
					LT178=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_withStatement1012), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop81;
				}
			}

			loop81:
				;

			} finally { DebugExitSubRule(81); }

			DebugLocation(181, 16);
			char_literal179=(IToken)Match(input,45,Follow._45_in_withStatement1016); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal179_tree = (object)adaptor.Create(char_literal179, retval);
			adaptor.AddChild(root_0, char_literal179_tree);
			}
			DebugLocation(181, 22);
			// JavaScript.g:181:22: ( LT )*
			try { DebugEnterSubRule(82);
			while (true)
			{
				int alt82=2;
				try { DebugEnterDecision(82, decisionCanBacktrack[82]);
				int LA82_0 = input.LA(1);

				if ((LA82_0==LT))
				{
					alt82=1;
				}


				} finally { DebugExitDecision(82); }
				switch ( alt82 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(181, 22);
					LT180=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_withStatement1018), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop82;
				}
			}

			loop82:
				;

			} finally { DebugExitSubRule(82); }

			DebugLocation(181, 25);
			PushFollow(Follow._expression_in_withStatement1022);
			expression181=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression181.Tree, expression181, retval);
			DebugLocation(181, 38);
			// JavaScript.g:181:38: ( LT )*
			try { DebugEnterSubRule(83);
			while (true)
			{
				int alt83=2;
				try { DebugEnterDecision(83, decisionCanBacktrack[83]);
				int LA83_0 = input.LA(1);

				if ((LA83_0==LT))
				{
					alt83=1;
				}


				} finally { DebugExitDecision(83); }
				switch ( alt83 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(181, 38);
					LT182=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_withStatement1024), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop83;
				}
			}

			loop83:
				;

			} finally { DebugExitSubRule(83); }

			DebugLocation(181, 41);
			RPAREN183=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_withStatement1028), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN183_tree = (object)adaptor.Create(RPAREN183, retval);
			adaptor.AddChild(root_0, RPAREN183_tree);
			}
			DebugLocation(181, 50);
			// JavaScript.g:181:50: ( LT )*
			try { DebugEnterSubRule(84);
			while (true)
			{
				int alt84=2;
				try { DebugEnterDecision(84, decisionCanBacktrack[84]);
				int LA84_0 = input.LA(1);

				if ((LA84_0==LT))
				{
					alt84=1;
				}


				} finally { DebugExitDecision(84); }
				switch ( alt84 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(181, 50);
					LT184=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_withStatement1030), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop84;
				}
			}

			loop84:
				;

			} finally { DebugExitSubRule(84); }

			DebugLocation(181, 53);
			PushFollow(Follow._statement_in_withStatement1034);
			statement185=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement185.Tree, statement185, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("withStatement", 32);
			LeaveRule("withStatement", 32);
			Leave_withStatement();
			if (state.backtracking > 0) { Memoize(input, 32, withStatement_StartIndex); }
		}
		DebugLocation(182, 1);
		} finally { DebugExitRule(GrammarFileName, "withStatement"); }
		return retval;

	}
	// $ANTLR end "withStatement"

	public class labelledStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_labelledStatement();
	partial void Leave_labelledStatement();

	// $ANTLR start "labelledStatement"
	// JavaScript.g:184:1: labelledStatement : Identifier ( LT )* ':' ( LT )* statement ;
	[GrammarRule("labelledStatement")]
	public JavaScriptParser.labelledStatement_return labelledStatement()
	{
		Enter_labelledStatement();
		EnterRule("labelledStatement", 33);
		TraceIn("labelledStatement", 33);
		JavaScriptParser.labelledStatement_return retval = new JavaScriptParser.labelledStatement_return();
		retval.Start = (IToken)input.LT(1);
		int labelledStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken Identifier186=null;
		IToken LT187=null;
		IToken char_literal188=null;
		IToken LT189=null;
		JavaScriptParser.statement_return statement190 = default(JavaScriptParser.statement_return);

		object Identifier186_tree=null;
		object LT187_tree=null;
		object char_literal188_tree=null;
		object LT189_tree=null;

		try { DebugEnterRule(GrammarFileName, "labelledStatement");
		DebugLocation(184, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 33)) { return retval; }
			// JavaScript.g:185:2: ( Identifier ( LT )* ':' ( LT )* statement )
			DebugEnterAlt(1);
			// JavaScript.g:185:4: Identifier ( LT )* ':' ( LT )* statement
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(185, 4);
			Identifier186=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_labelledStatement1045), "Identifier"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			Identifier186_tree = (object)adaptor.Create(Identifier186, retval);
			adaptor.AddChild(root_0, Identifier186_tree);
			}
			DebugLocation(185, 17);
			// JavaScript.g:185:17: ( LT )*
			try { DebugEnterSubRule(85);
			while (true)
			{
				int alt85=2;
				try { DebugEnterDecision(85, decisionCanBacktrack[85]);
				int LA85_0 = input.LA(1);

				if ((LA85_0==LT))
				{
					alt85=1;
				}


				} finally { DebugExitDecision(85); }
				switch ( alt85 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(185, 17);
					LT187=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_labelledStatement1047), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop85;
				}
			}

			loop85:
				;

			} finally { DebugExitSubRule(85); }

			DebugLocation(185, 20);
			char_literal188=(IToken)Match(input,60,Follow._60_in_labelledStatement1051); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal188_tree = (object)adaptor.Create(char_literal188, retval);
			adaptor.AddChild(root_0, char_literal188_tree);
			}
			DebugLocation(185, 26);
			// JavaScript.g:185:26: ( LT )*
			try { DebugEnterSubRule(86);
			while (true)
			{
				int alt86=2;
				try { DebugEnterDecision(86, decisionCanBacktrack[86]);
				int LA86_0 = input.LA(1);

				if ((LA86_0==LT))
				{
					alt86=1;
				}


				} finally { DebugExitDecision(86); }
				switch ( alt86 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(185, 26);
					LT189=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_labelledStatement1053), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop86;
				}
			}

			loop86:
				;

			} finally { DebugExitSubRule(86); }

			DebugLocation(185, 29);
			PushFollow(Follow._statement_in_labelledStatement1057);
			statement190=statement();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement190.Tree, statement190, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("labelledStatement", 33);
			LeaveRule("labelledStatement", 33);
			Leave_labelledStatement();
			if (state.backtracking > 0) { Memoize(input, 33, labelledStatement_StartIndex); }
		}
		DebugLocation(186, 1);
		} finally { DebugExitRule(GrammarFileName, "labelledStatement"); }
		return retval;

	}
	// $ANTLR end "labelledStatement"

	public class switchStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_switchStatement();
	partial void Leave_switchStatement();

	// $ANTLR start "switchStatement"
	// JavaScript.g:188:1: switchStatement : 'switch' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* caseBlock ;
	[GrammarRule("switchStatement")]
	public JavaScriptParser.switchStatement_return switchStatement()
	{
		Enter_switchStatement();
		EnterRule("switchStatement", 34);
		TraceIn("switchStatement", 34);
		JavaScriptParser.switchStatement_return retval = new JavaScriptParser.switchStatement_return();
		retval.Start = (IToken)input.LT(1);
		int switchStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal191=null;
		IToken LT192=null;
		IToken char_literal193=null;
		IToken LT194=null;
		IToken LT196=null;
		IToken RPAREN197=null;
		IToken LT198=null;
		JavaScriptParser.expression_return expression195 = default(JavaScriptParser.expression_return);
		JavaScriptParser.caseBlock_return caseBlock199 = default(JavaScriptParser.caseBlock_return);

		object string_literal191_tree=null;
		object LT192_tree=null;
		object char_literal193_tree=null;
		object LT194_tree=null;
		object LT196_tree=null;
		object RPAREN197_tree=null;
		object LT198_tree=null;

		try { DebugEnterRule(GrammarFileName, "switchStatement");
		DebugLocation(188, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 34)) { return retval; }
			// JavaScript.g:189:2: ( 'switch' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* caseBlock )
			DebugEnterAlt(1);
			// JavaScript.g:189:4: 'switch' ( LT )* '(' ( LT )* expression ( LT )* RPAREN ( LT )* caseBlock
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(189, 4);
			string_literal191=(IToken)Match(input,61,Follow._61_in_switchStatement1069); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal191_tree = (object)adaptor.Create(string_literal191, retval);
			adaptor.AddChild(root_0, string_literal191_tree);
			}
			DebugLocation(189, 15);
			// JavaScript.g:189:15: ( LT )*
			try { DebugEnterSubRule(87);
			while (true)
			{
				int alt87=2;
				try { DebugEnterDecision(87, decisionCanBacktrack[87]);
				int LA87_0 = input.LA(1);

				if ((LA87_0==LT))
				{
					alt87=1;
				}


				} finally { DebugExitDecision(87); }
				switch ( alt87 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(189, 15);
					LT192=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_switchStatement1071), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop87;
				}
			}

			loop87:
				;

			} finally { DebugExitSubRule(87); }

			DebugLocation(189, 18);
			char_literal193=(IToken)Match(input,45,Follow._45_in_switchStatement1075); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal193_tree = (object)adaptor.Create(char_literal193, retval);
			adaptor.AddChild(root_0, char_literal193_tree);
			}
			DebugLocation(189, 24);
			// JavaScript.g:189:24: ( LT )*
			try { DebugEnterSubRule(88);
			while (true)
			{
				int alt88=2;
				try { DebugEnterDecision(88, decisionCanBacktrack[88]);
				int LA88_0 = input.LA(1);

				if ((LA88_0==LT))
				{
					alt88=1;
				}


				} finally { DebugExitDecision(88); }
				switch ( alt88 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(189, 24);
					LT194=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_switchStatement1077), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop88;
				}
			}

			loop88:
				;

			} finally { DebugExitSubRule(88); }

			DebugLocation(189, 27);
			PushFollow(Follow._expression_in_switchStatement1081);
			expression195=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression195.Tree, expression195, retval);
			DebugLocation(189, 40);
			// JavaScript.g:189:40: ( LT )*
			try { DebugEnterSubRule(89);
			while (true)
			{
				int alt89=2;
				try { DebugEnterDecision(89, decisionCanBacktrack[89]);
				int LA89_0 = input.LA(1);

				if ((LA89_0==LT))
				{
					alt89=1;
				}


				} finally { DebugExitDecision(89); }
				switch ( alt89 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(189, 40);
					LT196=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_switchStatement1083), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop89;
				}
			}

			loop89:
				;

			} finally { DebugExitSubRule(89); }

			DebugLocation(189, 43);
			RPAREN197=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_switchStatement1087), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN197_tree = (object)adaptor.Create(RPAREN197, retval);
			adaptor.AddChild(root_0, RPAREN197_tree);
			}
			DebugLocation(189, 52);
			// JavaScript.g:189:52: ( LT )*
			try { DebugEnterSubRule(90);
			while (true)
			{
				int alt90=2;
				try { DebugEnterDecision(90, decisionCanBacktrack[90]);
				int LA90_0 = input.LA(1);

				if ((LA90_0==LT))
				{
					alt90=1;
				}


				} finally { DebugExitDecision(90); }
				switch ( alt90 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(189, 52);
					LT198=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_switchStatement1089), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop90;
				}
			}

			loop90:
				;

			} finally { DebugExitSubRule(90); }

			DebugLocation(189, 55);
			PushFollow(Follow._caseBlock_in_switchStatement1093);
			caseBlock199=caseBlock();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseBlock199.Tree, caseBlock199, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("switchStatement", 34);
			LeaveRule("switchStatement", 34);
			Leave_switchStatement();
			if (state.backtracking > 0) { Memoize(input, 34, switchStatement_StartIndex); }
		}
		DebugLocation(190, 1);
		} finally { DebugExitRule(GrammarFileName, "switchStatement"); }
		return retval;

	}
	// $ANTLR end "switchStatement"

	public class caseBlock_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_caseBlock();
	partial void Leave_caseBlock();

	// $ANTLR start "caseBlock"
	// JavaScript.g:192:1: caseBlock : '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* RBRACE ;
	[GrammarRule("caseBlock")]
	public JavaScriptParser.caseBlock_return caseBlock()
	{
		Enter_caseBlock();
		EnterRule("caseBlock", 35);
		TraceIn("caseBlock", 35);
		JavaScriptParser.caseBlock_return retval = new JavaScriptParser.caseBlock_return();
		retval.Start = (IToken)input.LT(1);
		int caseBlock_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal200=null;
		IToken LT201=null;
		IToken LT203=null;
		IToken LT205=null;
		IToken LT207=null;
		IToken RBRACE208=null;
		JavaScriptParser.caseClause_return caseClause202 = default(JavaScriptParser.caseClause_return);
		JavaScriptParser.defaultClause_return defaultClause204 = default(JavaScriptParser.defaultClause_return);
		JavaScriptParser.caseClause_return caseClause206 = default(JavaScriptParser.caseClause_return);

		object char_literal200_tree=null;
		object LT201_tree=null;
		object LT203_tree=null;
		object LT205_tree=null;
		object LT207_tree=null;
		object RBRACE208_tree=null;

		try { DebugEnterRule(GrammarFileName, "caseBlock");
		DebugLocation(192, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 35)) { return retval; }
			// JavaScript.g:193:2: ( '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* RBRACE )
			DebugEnterAlt(1);
			// JavaScript.g:193:4: '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(193, 4);
			char_literal200=(IToken)Match(input,47,Follow._47_in_caseBlock1105); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal200_tree = (object)adaptor.Create(char_literal200, retval);
			adaptor.AddChild(root_0, char_literal200_tree);
			}
			DebugLocation(193, 8);
			// JavaScript.g:193:8: ( ( LT )* caseClause )*
			try { DebugEnterSubRule(92);
			while (true)
			{
				int alt92=2;
				try { DebugEnterDecision(92, decisionCanBacktrack[92]);
				try
				{
					alt92 = dfa92.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(92); }
				switch ( alt92 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:193:9: ( LT )* caseClause
					{
					DebugLocation(193, 11);
					// JavaScript.g:193:11: ( LT )*
					try { DebugEnterSubRule(91);
					while (true)
					{
						int alt91=2;
						try { DebugEnterDecision(91, decisionCanBacktrack[91]);
						int LA91_0 = input.LA(1);

						if ((LA91_0==LT))
						{
							alt91=1;
						}


						} finally { DebugExitDecision(91); }
						switch ( alt91 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(193, 11);
							LT201=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_caseBlock1108), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop91;
						}
					}

					loop91:
						;

					} finally { DebugExitSubRule(91); }

					DebugLocation(193, 14);
					PushFollow(Follow._caseClause_in_caseBlock1112);
					caseClause202=caseClause();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseClause202.Tree, caseClause202, retval);

					}
					break;

				default:
					goto loop92;
				}
			}

			loop92:
				;

			} finally { DebugExitSubRule(92); }

			DebugLocation(193, 27);
			// JavaScript.g:193:27: ( ( LT )* defaultClause ( ( LT )* caseClause )* )?
			int alt96=2;
			try { DebugEnterSubRule(96);
			try { DebugEnterDecision(96, decisionCanBacktrack[96]);
			try
			{
				alt96 = dfa96.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(96); }
			switch (alt96)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:193:28: ( LT )* defaultClause ( ( LT )* caseClause )*
				{
				DebugLocation(193, 30);
				// JavaScript.g:193:30: ( LT )*
				try { DebugEnterSubRule(93);
				while (true)
				{
					int alt93=2;
					try { DebugEnterDecision(93, decisionCanBacktrack[93]);
					int LA93_0 = input.LA(1);

					if ((LA93_0==LT))
					{
						alt93=1;
					}


					} finally { DebugExitDecision(93); }
					switch ( alt93 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(193, 30);
						LT203=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_caseBlock1117), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop93;
					}
				}

				loop93:
					;

				} finally { DebugExitSubRule(93); }

				DebugLocation(193, 33);
				PushFollow(Follow._defaultClause_in_caseBlock1121);
				defaultClause204=defaultClause();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, defaultClause204.Tree, defaultClause204, retval);
				DebugLocation(193, 47);
				// JavaScript.g:193:47: ( ( LT )* caseClause )*
				try { DebugEnterSubRule(95);
				while (true)
				{
					int alt95=2;
					try { DebugEnterDecision(95, decisionCanBacktrack[95]);
					try
					{
						alt95 = dfa95.Predict(input);
					}
					catch (NoViableAltException nvae)
					{
						DebugRecognitionException(nvae);
						throw;
					}
					} finally { DebugExitDecision(95); }
					switch ( alt95 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:193:48: ( LT )* caseClause
						{
						DebugLocation(193, 50);
						// JavaScript.g:193:50: ( LT )*
						try { DebugEnterSubRule(94);
						while (true)
						{
							int alt94=2;
							try { DebugEnterDecision(94, decisionCanBacktrack[94]);
							int LA94_0 = input.LA(1);

							if ((LA94_0==LT))
							{
								alt94=1;
							}


							} finally { DebugExitDecision(94); }
							switch ( alt94 )
							{
							case 1:
								DebugEnterAlt(1);
								// JavaScript.g:0:0: LT
								{
								DebugLocation(193, 50);
								LT205=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_caseBlock1124), "LT"); if (state.failed) return retval;

								}
								break;

							default:
								goto loop94;
							}
						}

						loop94:
							;

						} finally { DebugExitSubRule(94); }

						DebugLocation(193, 53);
						PushFollow(Follow._caseClause_in_caseBlock1128);
						caseClause206=caseClause();
						PopFollow();
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseClause206.Tree, caseClause206, retval);

						}
						break;

					default:
						goto loop95;
					}
				}

				loop95:
					;

				} finally { DebugExitSubRule(95); }


				}
				break;

			}
			} finally { DebugExitSubRule(96); }

			DebugLocation(193, 70);
			// JavaScript.g:193:70: ( LT )*
			try { DebugEnterSubRule(97);
			while (true)
			{
				int alt97=2;
				try { DebugEnterDecision(97, decisionCanBacktrack[97]);
				int LA97_0 = input.LA(1);

				if ((LA97_0==LT))
				{
					alt97=1;
				}


				} finally { DebugExitDecision(97); }
				switch ( alt97 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(193, 70);
					LT207=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_caseBlock1134), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop97;
				}
			}

			loop97:
				;

			} finally { DebugExitSubRule(97); }

			DebugLocation(193, 73);
			RBRACE208=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_caseBlock1138), "RBRACE"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RBRACE208_tree = (object)adaptor.Create(RBRACE208, retval);
			adaptor.AddChild(root_0, RBRACE208_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("caseBlock", 35);
			LeaveRule("caseBlock", 35);
			Leave_caseBlock();
			if (state.backtracking > 0) { Memoize(input, 35, caseBlock_StartIndex); }
		}
		DebugLocation(194, 1);
		} finally { DebugExitRule(GrammarFileName, "caseBlock"); }
		return retval;

	}
	// $ANTLR end "caseBlock"

	public class caseClause_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_caseClause();
	partial void Leave_caseClause();

	// $ANTLR start "caseClause"
	// JavaScript.g:196:1: caseClause : 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )? ;
	[GrammarRule("caseClause")]
	public JavaScriptParser.caseClause_return caseClause()
	{
		Enter_caseClause();
		EnterRule("caseClause", 36);
		TraceIn("caseClause", 36);
		JavaScriptParser.caseClause_return retval = new JavaScriptParser.caseClause_return();
		retval.Start = (IToken)input.LT(1);
		int caseClause_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal209=null;
		IToken LT210=null;
		IToken LT212=null;
		IToken char_literal213=null;
		IToken LT214=null;
		JavaScriptParser.expression_return expression211 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statementList_return statementList215 = default(JavaScriptParser.statementList_return);

		object string_literal209_tree=null;
		object LT210_tree=null;
		object LT212_tree=null;
		object char_literal213_tree=null;
		object LT214_tree=null;

		try { DebugEnterRule(GrammarFileName, "caseClause");
		DebugLocation(196, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 36)) { return retval; }
			// JavaScript.g:197:2: ( 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )? )
			DebugEnterAlt(1);
			// JavaScript.g:197:4: 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(197, 4);
			string_literal209=(IToken)Match(input,62,Follow._62_in_caseClause1149); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal209_tree = (object)adaptor.Create(string_literal209, retval);
			adaptor.AddChild(root_0, string_literal209_tree);
			}
			DebugLocation(197, 13);
			// JavaScript.g:197:13: ( LT )*
			try { DebugEnterSubRule(98);
			while (true)
			{
				int alt98=2;
				try { DebugEnterDecision(98, decisionCanBacktrack[98]);
				int LA98_0 = input.LA(1);

				if ((LA98_0==LT))
				{
					alt98=1;
				}


				} finally { DebugExitDecision(98); }
				switch ( alt98 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(197, 13);
					LT210=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_caseClause1151), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop98;
				}
			}

			loop98:
				;

			} finally { DebugExitSubRule(98); }

			DebugLocation(197, 16);
			PushFollow(Follow._expression_in_caseClause1155);
			expression211=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression211.Tree, expression211, retval);
			DebugLocation(197, 29);
			// JavaScript.g:197:29: ( LT )*
			try { DebugEnterSubRule(99);
			while (true)
			{
				int alt99=2;
				try { DebugEnterDecision(99, decisionCanBacktrack[99]);
				int LA99_0 = input.LA(1);

				if ((LA99_0==LT))
				{
					alt99=1;
				}


				} finally { DebugExitDecision(99); }
				switch ( alt99 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(197, 29);
					LT212=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_caseClause1157), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop99;
				}
			}

			loop99:
				;

			} finally { DebugExitSubRule(99); }

			DebugLocation(197, 32);
			char_literal213=(IToken)Match(input,60,Follow._60_in_caseClause1161); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal213_tree = (object)adaptor.Create(char_literal213, retval);
			adaptor.AddChild(root_0, char_literal213_tree);
			}
			DebugLocation(197, 38);
			// JavaScript.g:197:38: ( LT )*
			try { DebugEnterSubRule(100);
			while (true)
			{
				int alt100=2;
				try { DebugEnterDecision(100, decisionCanBacktrack[100]);
				int LA100_0 = input.LA(1);

				if ((LA100_0==LT))
				{
					int LA100_2 = input.LA(2);

					if ((EvaluatePredicate(synpred118_JavaScript_fragment)))
					{
						alt100=1;
					}


				}


				} finally { DebugExitDecision(100); }
				switch ( alt100 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(197, 38);
					LT214=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_caseClause1163), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop100;
				}
			}

			loop100:
				;

			} finally { DebugExitSubRule(100); }

			DebugLocation(197, 41);
			// JavaScript.g:197:41: ( statementList )?
			int alt101=2;
			try { DebugEnterSubRule(101);
			try { DebugEnterDecision(101, decisionCanBacktrack[101]);
			int LA101_0 = input.LA(1);

			if (((LA101_0>=NULL && LA101_0<=THIS)||(LA101_0>=Identifier && LA101_0<=RegularExpressionLiteral)||(LA101_0>=43 && LA101_0<=45)||(LA101_0>=47 && LA101_0<=48)||LA101_0==50||(LA101_0>=52 && LA101_0<=54)||(LA101_0>=56 && LA101_0<=59)||LA101_0==61||(LA101_0>=64 && LA101_0<=65)||(LA101_0>=68 && LA101_0<=69)||(LA101_0>=100 && LA101_0<=101)||(LA101_0>=105 && LA101_0<=111)))
			{
				alt101=1;
			}
			} finally { DebugExitDecision(101); }
			switch (alt101)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: statementList
				{
				DebugLocation(197, 41);
				PushFollow(Follow._statementList_in_caseClause1167);
				statementList215=statementList();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList215.Tree, statementList215, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(101); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("caseClause", 36);
			LeaveRule("caseClause", 36);
			Leave_caseClause();
			if (state.backtracking > 0) { Memoize(input, 36, caseClause_StartIndex); }
		}
		DebugLocation(198, 1);
		} finally { DebugExitRule(GrammarFileName, "caseClause"); }
		return retval;

	}
	// $ANTLR end "caseClause"

	public class defaultClause_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_defaultClause();
	partial void Leave_defaultClause();

	// $ANTLR start "defaultClause"
	// JavaScript.g:200:1: defaultClause : 'default' ( LT )* ':' ( LT )* ( statementList )? ;
	[GrammarRule("defaultClause")]
	public JavaScriptParser.defaultClause_return defaultClause()
	{
		Enter_defaultClause();
		EnterRule("defaultClause", 37);
		TraceIn("defaultClause", 37);
		JavaScriptParser.defaultClause_return retval = new JavaScriptParser.defaultClause_return();
		retval.Start = (IToken)input.LT(1);
		int defaultClause_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal216=null;
		IToken LT217=null;
		IToken char_literal218=null;
		IToken LT219=null;
		JavaScriptParser.statementList_return statementList220 = default(JavaScriptParser.statementList_return);

		object string_literal216_tree=null;
		object LT217_tree=null;
		object char_literal218_tree=null;
		object LT219_tree=null;

		try { DebugEnterRule(GrammarFileName, "defaultClause");
		DebugLocation(200, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 37)) { return retval; }
			// JavaScript.g:201:2: ( 'default' ( LT )* ':' ( LT )* ( statementList )? )
			DebugEnterAlt(1);
			// JavaScript.g:201:4: 'default' ( LT )* ':' ( LT )* ( statementList )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(201, 4);
			string_literal216=(IToken)Match(input,63,Follow._63_in_defaultClause1180); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal216_tree = (object)adaptor.Create(string_literal216, retval);
			adaptor.AddChild(root_0, string_literal216_tree);
			}
			DebugLocation(201, 16);
			// JavaScript.g:201:16: ( LT )*
			try { DebugEnterSubRule(102);
			while (true)
			{
				int alt102=2;
				try { DebugEnterDecision(102, decisionCanBacktrack[102]);
				int LA102_0 = input.LA(1);

				if ((LA102_0==LT))
				{
					alt102=1;
				}


				} finally { DebugExitDecision(102); }
				switch ( alt102 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(201, 16);
					LT217=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_defaultClause1182), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop102;
				}
			}

			loop102:
				;

			} finally { DebugExitSubRule(102); }

			DebugLocation(201, 19);
			char_literal218=(IToken)Match(input,60,Follow._60_in_defaultClause1186); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal218_tree = (object)adaptor.Create(char_literal218, retval);
			adaptor.AddChild(root_0, char_literal218_tree);
			}
			DebugLocation(201, 25);
			// JavaScript.g:201:25: ( LT )*
			try { DebugEnterSubRule(103);
			while (true)
			{
				int alt103=2;
				try { DebugEnterDecision(103, decisionCanBacktrack[103]);
				int LA103_0 = input.LA(1);

				if ((LA103_0==LT))
				{
					int LA103_2 = input.LA(2);

					if ((EvaluatePredicate(synpred121_JavaScript_fragment)))
					{
						alt103=1;
					}


				}


				} finally { DebugExitDecision(103); }
				switch ( alt103 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(201, 25);
					LT219=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_defaultClause1188), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop103;
				}
			}

			loop103:
				;

			} finally { DebugExitSubRule(103); }

			DebugLocation(201, 28);
			// JavaScript.g:201:28: ( statementList )?
			int alt104=2;
			try { DebugEnterSubRule(104);
			try { DebugEnterDecision(104, decisionCanBacktrack[104]);
			int LA104_0 = input.LA(1);

			if (((LA104_0>=NULL && LA104_0<=THIS)||(LA104_0>=Identifier && LA104_0<=RegularExpressionLiteral)||(LA104_0>=43 && LA104_0<=45)||(LA104_0>=47 && LA104_0<=48)||LA104_0==50||(LA104_0>=52 && LA104_0<=54)||(LA104_0>=56 && LA104_0<=59)||LA104_0==61||(LA104_0>=64 && LA104_0<=65)||(LA104_0>=68 && LA104_0<=69)||(LA104_0>=100 && LA104_0<=101)||(LA104_0>=105 && LA104_0<=111)))
			{
				alt104=1;
			}
			} finally { DebugExitDecision(104); }
			switch (alt104)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: statementList
				{
				DebugLocation(201, 28);
				PushFollow(Follow._statementList_in_defaultClause1192);
				statementList220=statementList();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList220.Tree, statementList220, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(104); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("defaultClause", 37);
			LeaveRule("defaultClause", 37);
			Leave_defaultClause();
			if (state.backtracking > 0) { Memoize(input, 37, defaultClause_StartIndex); }
		}
		DebugLocation(202, 1);
		} finally { DebugExitRule(GrammarFileName, "defaultClause"); }
		return retval;

	}
	// $ANTLR end "defaultClause"

	public class throwStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_throwStatement();
	partial void Leave_throwStatement();

	// $ANTLR start "throwStatement"
	// JavaScript.g:204:1: throwStatement : 'throw' expression statementEnd ;
	[GrammarRule("throwStatement")]
	public JavaScriptParser.throwStatement_return throwStatement()
	{
		Enter_throwStatement();
		EnterRule("throwStatement", 38);
		TraceIn("throwStatement", 38);
		JavaScriptParser.throwStatement_return retval = new JavaScriptParser.throwStatement_return();
		retval.Start = (IToken)input.LT(1);
		int throwStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal221=null;
		JavaScriptParser.expression_return expression222 = default(JavaScriptParser.expression_return);
		JavaScriptParser.statementEnd_return statementEnd223 = default(JavaScriptParser.statementEnd_return);

		object string_literal221_tree=null;

		try { DebugEnterRule(GrammarFileName, "throwStatement");
		DebugLocation(204, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 38)) { return retval; }
			// JavaScript.g:205:2: ( 'throw' expression statementEnd )
			DebugEnterAlt(1);
			// JavaScript.g:205:4: 'throw' expression statementEnd
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(205, 4);
			string_literal221=(IToken)Match(input,64,Follow._64_in_throwStatement1205); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal221_tree = (object)adaptor.Create(string_literal221, retval);
			adaptor.AddChild(root_0, string_literal221_tree);
			}
			DebugLocation(205, 12);
			PushFollow(Follow._expression_in_throwStatement1207);
			expression222=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression222.Tree, expression222, retval);
			DebugLocation(205, 23);
			PushFollow(Follow._statementEnd_in_throwStatement1209);
			statementEnd223=statementEnd();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementEnd223.Tree, statementEnd223, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("throwStatement", 38);
			LeaveRule("throwStatement", 38);
			Leave_throwStatement();
			if (state.backtracking > 0) { Memoize(input, 38, throwStatement_StartIndex); }
		}
		DebugLocation(206, 1);
		} finally { DebugExitRule(GrammarFileName, "throwStatement"); }
		return retval;

	}
	// $ANTLR end "throwStatement"

	public class tryStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_tryStatement();
	partial void Leave_tryStatement();

	// $ANTLR start "tryStatement"
	// JavaScript.g:208:1: tryStatement : 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? ) ;
	[GrammarRule("tryStatement")]
	public JavaScriptParser.tryStatement_return tryStatement()
	{
		Enter_tryStatement();
		EnterRule("tryStatement", 39);
		TraceIn("tryStatement", 39);
		JavaScriptParser.tryStatement_return retval = new JavaScriptParser.tryStatement_return();
		retval.Start = (IToken)input.LT(1);
		int tryStatement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal224=null;
		IToken LT225=null;
		IToken LT227=null;
		IToken LT230=null;
		JavaScriptParser.statementBlock_return statementBlock226 = default(JavaScriptParser.statementBlock_return);
		JavaScriptParser.finallyClause_return finallyClause228 = default(JavaScriptParser.finallyClause_return);
		JavaScriptParser.catchClause_return catchClause229 = default(JavaScriptParser.catchClause_return);
		JavaScriptParser.finallyClause_return finallyClause231 = default(JavaScriptParser.finallyClause_return);

		object string_literal224_tree=null;
		object LT225_tree=null;
		object LT227_tree=null;
		object LT230_tree=null;

		try { DebugEnterRule(GrammarFileName, "tryStatement");
		DebugLocation(208, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 39)) { return retval; }
			// JavaScript.g:209:2: ( 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? ) )
			DebugEnterAlt(1);
			// JavaScript.g:209:4: 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? )
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(209, 4);
			string_literal224=(IToken)Match(input,65,Follow._65_in_tryStatement1220); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal224_tree = (object)adaptor.Create(string_literal224, retval);
			adaptor.AddChild(root_0, string_literal224_tree);
			}
			DebugLocation(209, 12);
			// JavaScript.g:209:12: ( LT )*
			try { DebugEnterSubRule(105);
			while (true)
			{
				int alt105=2;
				try { DebugEnterDecision(105, decisionCanBacktrack[105]);
				int LA105_0 = input.LA(1);

				if ((LA105_0==LT))
				{
					alt105=1;
				}


				} finally { DebugExitDecision(105); }
				switch ( alt105 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(209, 12);
					LT225=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_tryStatement1222), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop105;
				}
			}

			loop105:
				;

			} finally { DebugExitSubRule(105); }

			DebugLocation(209, 15);
			PushFollow(Follow._statementBlock_in_tryStatement1226);
			statementBlock226=statementBlock();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock226.Tree, statementBlock226, retval);
			DebugLocation(209, 32);
			// JavaScript.g:209:32: ( LT )*
			try { DebugEnterSubRule(106);
			while (true)
			{
				int alt106=2;
				try { DebugEnterDecision(106, decisionCanBacktrack[106]);
				int LA106_0 = input.LA(1);

				if ((LA106_0==LT))
				{
					alt106=1;
				}


				} finally { DebugExitDecision(106); }
				switch ( alt106 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(209, 32);
					LT227=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_tryStatement1228), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop106;
				}
			}

			loop106:
				;

			} finally { DebugExitSubRule(106); }

			DebugLocation(209, 35);
			// JavaScript.g:209:35: ( finallyClause | catchClause ( ( LT )* finallyClause )? )
			int alt109=2;
			try { DebugEnterSubRule(109);
			try { DebugEnterDecision(109, decisionCanBacktrack[109]);
			int LA109_0 = input.LA(1);

			if ((LA109_0==67))
			{
				alt109=1;
			}
			else if ((LA109_0==66))
			{
				alt109=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 109, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(109); }
			switch (alt109)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:209:36: finallyClause
				{
				DebugLocation(209, 36);
				PushFollow(Follow._finallyClause_in_tryStatement1233);
				finallyClause228=finallyClause();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause228.Tree, finallyClause228, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:209:52: catchClause ( ( LT )* finallyClause )?
				{
				DebugLocation(209, 52);
				PushFollow(Follow._catchClause_in_tryStatement1237);
				catchClause229=catchClause();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, catchClause229.Tree, catchClause229, retval);
				DebugLocation(209, 64);
				// JavaScript.g:209:64: ( ( LT )* finallyClause )?
				int alt108=2;
				try { DebugEnterSubRule(108);
				try { DebugEnterDecision(108, decisionCanBacktrack[108]);
				try
				{
					alt108 = dfa108.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(108); }
				switch (alt108)
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:209:65: ( LT )* finallyClause
					{
					DebugLocation(209, 67);
					// JavaScript.g:209:67: ( LT )*
					try { DebugEnterSubRule(107);
					while (true)
					{
						int alt107=2;
						try { DebugEnterDecision(107, decisionCanBacktrack[107]);
						int LA107_0 = input.LA(1);

						if ((LA107_0==LT))
						{
							alt107=1;
						}


						} finally { DebugExitDecision(107); }
						switch ( alt107 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(209, 67);
							LT230=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_tryStatement1240), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop107;
						}
					}

					loop107:
						;

					} finally { DebugExitSubRule(107); }

					DebugLocation(209, 70);
					PushFollow(Follow._finallyClause_in_tryStatement1244);
					finallyClause231=finallyClause();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause231.Tree, finallyClause231, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(108); }


				}
				break;

			}
			} finally { DebugExitSubRule(109); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("tryStatement", 39);
			LeaveRule("tryStatement", 39);
			Leave_tryStatement();
			if (state.backtracking > 0) { Memoize(input, 39, tryStatement_StartIndex); }
		}
		DebugLocation(210, 1);
		} finally { DebugExitRule(GrammarFileName, "tryStatement"); }
		return retval;

	}
	// $ANTLR end "tryStatement"

	public class catchClause_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_catchClause();
	partial void Leave_catchClause();

	// $ANTLR start "catchClause"
	// JavaScript.g:212:1: catchClause : 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* RPAREN ( LT )* statementBlock ;
	[GrammarRule("catchClause")]
	public JavaScriptParser.catchClause_return catchClause()
	{
		Enter_catchClause();
		EnterRule("catchClause", 40);
		TraceIn("catchClause", 40);
		JavaScriptParser.catchClause_return retval = new JavaScriptParser.catchClause_return();
		retval.Start = (IToken)input.LT(1);
		int catchClause_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal232=null;
		IToken LT233=null;
		IToken char_literal234=null;
		IToken LT235=null;
		IToken Identifier236=null;
		IToken LT237=null;
		IToken RPAREN238=null;
		IToken LT239=null;
		JavaScriptParser.statementBlock_return statementBlock240 = default(JavaScriptParser.statementBlock_return);

		object string_literal232_tree=null;
		object LT233_tree=null;
		object char_literal234_tree=null;
		object LT235_tree=null;
		object Identifier236_tree=null;
		object LT237_tree=null;
		object RPAREN238_tree=null;
		object LT239_tree=null;

		try { DebugEnterRule(GrammarFileName, "catchClause");
		DebugLocation(212, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 40)) { return retval; }
			// JavaScript.g:213:2: ( 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* RPAREN ( LT )* statementBlock )
			DebugEnterAlt(1);
			// JavaScript.g:213:4: 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* RPAREN ( LT )* statementBlock
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(213, 4);
			string_literal232=(IToken)Match(input,66,Follow._66_in_catchClause1265); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal232_tree = (object)adaptor.Create(string_literal232, retval);
			adaptor.AddChild(root_0, string_literal232_tree);
			}
			DebugLocation(213, 14);
			// JavaScript.g:213:14: ( LT )*
			try { DebugEnterSubRule(110);
			while (true)
			{
				int alt110=2;
				try { DebugEnterDecision(110, decisionCanBacktrack[110]);
				int LA110_0 = input.LA(1);

				if ((LA110_0==LT))
				{
					alt110=1;
				}


				} finally { DebugExitDecision(110); }
				switch ( alt110 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(213, 14);
					LT233=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_catchClause1267), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop110;
				}
			}

			loop110:
				;

			} finally { DebugExitSubRule(110); }

			DebugLocation(213, 17);
			char_literal234=(IToken)Match(input,45,Follow._45_in_catchClause1271); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal234_tree = (object)adaptor.Create(char_literal234, retval);
			adaptor.AddChild(root_0, char_literal234_tree);
			}
			DebugLocation(213, 23);
			// JavaScript.g:213:23: ( LT )*
			try { DebugEnterSubRule(111);
			while (true)
			{
				int alt111=2;
				try { DebugEnterDecision(111, decisionCanBacktrack[111]);
				int LA111_0 = input.LA(1);

				if ((LA111_0==LT))
				{
					alt111=1;
				}


				} finally { DebugExitDecision(111); }
				switch ( alt111 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(213, 23);
					LT235=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_catchClause1273), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop111;
				}
			}

			loop111:
				;

			} finally { DebugExitSubRule(111); }

			DebugLocation(213, 26);
			Identifier236=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_catchClause1277), "Identifier"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			Identifier236_tree = (object)adaptor.Create(Identifier236, retval);
			adaptor.AddChild(root_0, Identifier236_tree);
			}
			DebugLocation(213, 39);
			// JavaScript.g:213:39: ( LT )*
			try { DebugEnterSubRule(112);
			while (true)
			{
				int alt112=2;
				try { DebugEnterDecision(112, decisionCanBacktrack[112]);
				int LA112_0 = input.LA(1);

				if ((LA112_0==LT))
				{
					alt112=1;
				}


				} finally { DebugExitDecision(112); }
				switch ( alt112 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(213, 39);
					LT237=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_catchClause1279), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop112;
				}
			}

			loop112:
				;

			} finally { DebugExitSubRule(112); }

			DebugLocation(213, 42);
			RPAREN238=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_catchClause1283), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN238_tree = (object)adaptor.Create(RPAREN238, retval);
			adaptor.AddChild(root_0, RPAREN238_tree);
			}
			DebugLocation(213, 51);
			// JavaScript.g:213:51: ( LT )*
			try { DebugEnterSubRule(113);
			while (true)
			{
				int alt113=2;
				try { DebugEnterDecision(113, decisionCanBacktrack[113]);
				int LA113_0 = input.LA(1);

				if ((LA113_0==LT))
				{
					alt113=1;
				}


				} finally { DebugExitDecision(113); }
				switch ( alt113 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(213, 51);
					LT239=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_catchClause1285), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop113;
				}
			}

			loop113:
				;

			} finally { DebugExitSubRule(113); }

			DebugLocation(213, 54);
			PushFollow(Follow._statementBlock_in_catchClause1289);
			statementBlock240=statementBlock();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock240.Tree, statementBlock240, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("catchClause", 40);
			LeaveRule("catchClause", 40);
			Leave_catchClause();
			if (state.backtracking > 0) { Memoize(input, 40, catchClause_StartIndex); }
		}
		DebugLocation(214, 1);
		} finally { DebugExitRule(GrammarFileName, "catchClause"); }
		return retval;

	}
	// $ANTLR end "catchClause"

	public class finallyClause_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_finallyClause();
	partial void Leave_finallyClause();

	// $ANTLR start "finallyClause"
	// JavaScript.g:216:1: finallyClause : 'finally' ( LT )* statementBlock ;
	[GrammarRule("finallyClause")]
	public JavaScriptParser.finallyClause_return finallyClause()
	{
		Enter_finallyClause();
		EnterRule("finallyClause", 41);
		TraceIn("finallyClause", 41);
		JavaScriptParser.finallyClause_return retval = new JavaScriptParser.finallyClause_return();
		retval.Start = (IToken)input.LT(1);
		int finallyClause_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal241=null;
		IToken LT242=null;
		JavaScriptParser.statementBlock_return statementBlock243 = default(JavaScriptParser.statementBlock_return);

		object string_literal241_tree=null;
		object LT242_tree=null;

		try { DebugEnterRule(GrammarFileName, "finallyClause");
		DebugLocation(216, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 41)) { return retval; }
			// JavaScript.g:217:2: ( 'finally' ( LT )* statementBlock )
			DebugEnterAlt(1);
			// JavaScript.g:217:4: 'finally' ( LT )* statementBlock
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(217, 4);
			string_literal241=(IToken)Match(input,67,Follow._67_in_finallyClause1301); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			string_literal241_tree = (object)adaptor.Create(string_literal241, retval);
			adaptor.AddChild(root_0, string_literal241_tree);
			}
			DebugLocation(217, 16);
			// JavaScript.g:217:16: ( LT )*
			try { DebugEnterSubRule(114);
			while (true)
			{
				int alt114=2;
				try { DebugEnterDecision(114, decisionCanBacktrack[114]);
				int LA114_0 = input.LA(1);

				if ((LA114_0==LT))
				{
					alt114=1;
				}


				} finally { DebugExitDecision(114); }
				switch ( alt114 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(217, 16);
					LT242=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_finallyClause1303), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop114;
				}
			}

			loop114:
				;

			} finally { DebugExitSubRule(114); }

			DebugLocation(217, 19);
			PushFollow(Follow._statementBlock_in_finallyClause1307);
			statementBlock243=statementBlock();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock243.Tree, statementBlock243, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("finallyClause", 41);
			LeaveRule("finallyClause", 41);
			Leave_finallyClause();
			if (state.backtracking > 0) { Memoize(input, 41, finallyClause_StartIndex); }
		}
		DebugLocation(218, 1);
		} finally { DebugExitRule(GrammarFileName, "finallyClause"); }
		return retval;

	}
	// $ANTLR end "finallyClause"

	public class expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expression();
	partial void Leave_expression();

	// $ANTLR start "expression"
	// JavaScript.g:221:1: expression : assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* ;
	[GrammarRule("expression")]
	public JavaScriptParser.expression_return expression()
	{
		Enter_expression();
		EnterRule("expression", 42);
		TraceIn("expression", 42);
		JavaScriptParser.expression_return retval = new JavaScriptParser.expression_return();
		retval.Start = (IToken)input.LT(1);
		int expression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT245=null;
		IToken char_literal246=null;
		IToken LT247=null;
		JavaScriptParser.assignmentExpression_return assignmentExpression244 = default(JavaScriptParser.assignmentExpression_return);
		JavaScriptParser.assignmentExpression_return assignmentExpression248 = default(JavaScriptParser.assignmentExpression_return);

		object LT245_tree=null;
		object char_literal246_tree=null;
		object LT247_tree=null;

		try { DebugEnterRule(GrammarFileName, "expression");
		DebugLocation(221, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 42)) { return retval; }
			// JavaScript.g:222:2: ( assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:222:4: assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(222, 4);
			PushFollow(Follow._assignmentExpression_in_expression1319);
			assignmentExpression244=assignmentExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression244.Tree, assignmentExpression244, retval);
			DebugLocation(222, 25);
			// JavaScript.g:222:25: ( ( LT )* ',' ( LT )* assignmentExpression )*
			try { DebugEnterSubRule(117);
			while (true)
			{
				int alt117=2;
				try { DebugEnterDecision(117, decisionCanBacktrack[117]);
				try
				{
					alt117 = dfa117.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(117); }
				switch ( alt117 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:222:26: ( LT )* ',' ( LT )* assignmentExpression
					{
					DebugLocation(222, 28);
					// JavaScript.g:222:28: ( LT )*
					try { DebugEnterSubRule(115);
					while (true)
					{
						int alt115=2;
						try { DebugEnterDecision(115, decisionCanBacktrack[115]);
						int LA115_0 = input.LA(1);

						if ((LA115_0==LT))
						{
							alt115=1;
						}


						} finally { DebugExitDecision(115); }
						switch ( alt115 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(222, 28);
							LT245=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_expression1322), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop115;
						}
					}

					loop115:
						;

					} finally { DebugExitSubRule(115); }

					DebugLocation(222, 31);
					char_literal246=(IToken)Match(input,46,Follow._46_in_expression1326); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal246_tree = (object)adaptor.Create(char_literal246, retval);
					adaptor.AddChild(root_0, char_literal246_tree);
					}
					DebugLocation(222, 37);
					// JavaScript.g:222:37: ( LT )*
					try { DebugEnterSubRule(116);
					while (true)
					{
						int alt116=2;
						try { DebugEnterDecision(116, decisionCanBacktrack[116]);
						int LA116_0 = input.LA(1);

						if ((LA116_0==LT))
						{
							alt116=1;
						}


						} finally { DebugExitDecision(116); }
						switch ( alt116 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(222, 37);
							LT247=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_expression1328), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop116;
						}
					}

					loop116:
						;

					} finally { DebugExitSubRule(116); }

					DebugLocation(222, 40);
					PushFollow(Follow._assignmentExpression_in_expression1332);
					assignmentExpression248=assignmentExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression248.Tree, assignmentExpression248, retval);

					}
					break;

				default:
					goto loop117;
				}
			}

			loop117:
				;

			} finally { DebugExitSubRule(117); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expression", 42);
			LeaveRule("expression", 42);
			Leave_expression();
			if (state.backtracking > 0) { Memoize(input, 42, expression_StartIndex); }
		}
		DebugLocation(223, 1);
		} finally { DebugExitRule(GrammarFileName, "expression"); }
		return retval;

	}
	// $ANTLR end "expression"

	public class expressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expressionNoIn();
	partial void Leave_expressionNoIn();

	// $ANTLR start "expressionNoIn"
	// JavaScript.g:225:1: expressionNoIn : assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )* ;
	[GrammarRule("expressionNoIn")]
	public JavaScriptParser.expressionNoIn_return expressionNoIn()
	{
		Enter_expressionNoIn();
		EnterRule("expressionNoIn", 43);
		TraceIn("expressionNoIn", 43);
		JavaScriptParser.expressionNoIn_return retval = new JavaScriptParser.expressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int expressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT250=null;
		IToken char_literal251=null;
		IToken LT252=null;
		JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn249 = default(JavaScriptParser.assignmentExpressionNoIn_return);
		JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn253 = default(JavaScriptParser.assignmentExpressionNoIn_return);

		object LT250_tree=null;
		object char_literal251_tree=null;
		object LT252_tree=null;

		try { DebugEnterRule(GrammarFileName, "expressionNoIn");
		DebugLocation(225, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 43)) { return retval; }
			// JavaScript.g:226:2: ( assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:226:4: assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(226, 4);
			PushFollow(Follow._assignmentExpressionNoIn_in_expressionNoIn1346);
			assignmentExpressionNoIn249=assignmentExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn249.Tree, assignmentExpressionNoIn249, retval);
			DebugLocation(226, 29);
			// JavaScript.g:226:29: ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*
			try { DebugEnterSubRule(120);
			while (true)
			{
				int alt120=2;
				try { DebugEnterDecision(120, decisionCanBacktrack[120]);
				try
				{
					alt120 = dfa120.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(120); }
				switch ( alt120 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:226:30: ( LT )* ',' ( LT )* assignmentExpressionNoIn
					{
					DebugLocation(226, 32);
					// JavaScript.g:226:32: ( LT )*
					try { DebugEnterSubRule(118);
					while (true)
					{
						int alt118=2;
						try { DebugEnterDecision(118, decisionCanBacktrack[118]);
						int LA118_0 = input.LA(1);

						if ((LA118_0==LT))
						{
							alt118=1;
						}


						} finally { DebugExitDecision(118); }
						switch ( alt118 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(226, 32);
							LT250=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_expressionNoIn1349), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop118;
						}
					}

					loop118:
						;

					} finally { DebugExitSubRule(118); }

					DebugLocation(226, 35);
					char_literal251=(IToken)Match(input,46,Follow._46_in_expressionNoIn1353); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal251_tree = (object)adaptor.Create(char_literal251, retval);
					adaptor.AddChild(root_0, char_literal251_tree);
					}
					DebugLocation(226, 41);
					// JavaScript.g:226:41: ( LT )*
					try { DebugEnterSubRule(119);
					while (true)
					{
						int alt119=2;
						try { DebugEnterDecision(119, decisionCanBacktrack[119]);
						int LA119_0 = input.LA(1);

						if ((LA119_0==LT))
						{
							alt119=1;
						}


						} finally { DebugExitDecision(119); }
						switch ( alt119 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(226, 41);
							LT252=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_expressionNoIn1355), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop119;
						}
					}

					loop119:
						;

					} finally { DebugExitSubRule(119); }

					DebugLocation(226, 44);
					PushFollow(Follow._assignmentExpressionNoIn_in_expressionNoIn1359);
					assignmentExpressionNoIn253=assignmentExpressionNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn253.Tree, assignmentExpressionNoIn253, retval);

					}
					break;

				default:
					goto loop120;
				}
			}

			loop120:
				;

			} finally { DebugExitSubRule(120); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expressionNoIn", 43);
			LeaveRule("expressionNoIn", 43);
			Leave_expressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 43, expressionNoIn_StartIndex); }
		}
		DebugLocation(227, 1);
		} finally { DebugExitRule(GrammarFileName, "expressionNoIn"); }
		return retval;

	}
	// $ANTLR end "expressionNoIn"

	public class assignmentExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignmentExpression();
	partial void Leave_assignmentExpression();

	// $ANTLR start "assignmentExpression"
	// JavaScript.g:229:1: assignmentExpression : ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression );
	[GrammarRule("assignmentExpression")]
	public JavaScriptParser.assignmentExpression_return assignmentExpression()
	{
		Enter_assignmentExpression();
		EnterRule("assignmentExpression", 44);
		TraceIn("assignmentExpression", 44);
		JavaScriptParser.assignmentExpression_return retval = new JavaScriptParser.assignmentExpression_return();
		retval.Start = (IToken)input.LT(1);
		int assignmentExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT256=null;
		IToken LT258=null;
		JavaScriptParser.conditionalExpression_return conditionalExpression254 = default(JavaScriptParser.conditionalExpression_return);
		JavaScriptParser.leftHandSideExpression_return leftHandSideExpression255 = default(JavaScriptParser.leftHandSideExpression_return);
		JavaScriptParser.assignmentOperator_return assignmentOperator257 = default(JavaScriptParser.assignmentOperator_return);
		JavaScriptParser.assignmentExpression_return assignmentExpression259 = default(JavaScriptParser.assignmentExpression_return);

		object LT256_tree=null;
		object LT258_tree=null;

		try { DebugEnterRule(GrammarFileName, "assignmentExpression");
		DebugLocation(229, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 44)) { return retval; }
			// JavaScript.g:230:2: ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression )
			int alt123=2;
			try { DebugEnterDecision(123, decisionCanBacktrack[123]);
			try
			{
				alt123 = dfa123.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(123); }
			switch (alt123)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:230:4: conditionalExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(230, 4);
				PushFollow(Follow._conditionalExpression_in_assignmentExpression1373);
				conditionalExpression254=conditionalExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpression254.Tree, conditionalExpression254, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:231:4: leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(231, 4);
				PushFollow(Follow._leftHandSideExpression_in_assignmentExpression1378);
				leftHandSideExpression255=leftHandSideExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression255.Tree, leftHandSideExpression255, retval);
				DebugLocation(231, 29);
				// JavaScript.g:231:29: ( LT )*
				try { DebugEnterSubRule(121);
				while (true)
				{
					int alt121=2;
					try { DebugEnterDecision(121, decisionCanBacktrack[121]);
					int LA121_0 = input.LA(1);

					if ((LA121_0==LT))
					{
						alt121=1;
					}


					} finally { DebugExitDecision(121); }
					switch ( alt121 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(231, 29);
						LT256=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_assignmentExpression1380), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop121;
					}
				}

				loop121:
					;

				} finally { DebugExitSubRule(121); }

				DebugLocation(231, 32);
				PushFollow(Follow._assignmentOperator_in_assignmentExpression1384);
				assignmentOperator257=assignmentOperator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentOperator257.Tree, assignmentOperator257, retval);
				DebugLocation(231, 53);
				// JavaScript.g:231:53: ( LT )*
				try { DebugEnterSubRule(122);
				while (true)
				{
					int alt122=2;
					try { DebugEnterDecision(122, decisionCanBacktrack[122]);
					int LA122_0 = input.LA(1);

					if ((LA122_0==LT))
					{
						alt122=1;
					}


					} finally { DebugExitDecision(122); }
					switch ( alt122 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(231, 53);
						LT258=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_assignmentExpression1386), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop122;
					}
				}

				loop122:
					;

				} finally { DebugExitSubRule(122); }

				DebugLocation(231, 56);
				PushFollow(Follow._assignmentExpression_in_assignmentExpression1390);
				assignmentExpression259=assignmentExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression259.Tree, assignmentExpression259, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignmentExpression", 44);
			LeaveRule("assignmentExpression", 44);
			Leave_assignmentExpression();
			if (state.backtracking > 0) { Memoize(input, 44, assignmentExpression_StartIndex); }
		}
		DebugLocation(232, 1);
		} finally { DebugExitRule(GrammarFileName, "assignmentExpression"); }
		return retval;

	}
	// $ANTLR end "assignmentExpression"

	public class assignmentExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignmentExpressionNoIn();
	partial void Leave_assignmentExpressionNoIn();

	// $ANTLR start "assignmentExpressionNoIn"
	// JavaScript.g:234:1: assignmentExpressionNoIn : ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn );
	[GrammarRule("assignmentExpressionNoIn")]
	public JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn()
	{
		Enter_assignmentExpressionNoIn();
		EnterRule("assignmentExpressionNoIn", 45);
		TraceIn("assignmentExpressionNoIn", 45);
		JavaScriptParser.assignmentExpressionNoIn_return retval = new JavaScriptParser.assignmentExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int assignmentExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT262=null;
		IToken LT264=null;
		JavaScriptParser.conditionalExpressionNoIn_return conditionalExpressionNoIn260 = default(JavaScriptParser.conditionalExpressionNoIn_return);
		JavaScriptParser.leftHandSideExpression_return leftHandSideExpression261 = default(JavaScriptParser.leftHandSideExpression_return);
		JavaScriptParser.assignmentOperator_return assignmentOperator263 = default(JavaScriptParser.assignmentOperator_return);
		JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn265 = default(JavaScriptParser.assignmentExpressionNoIn_return);

		object LT262_tree=null;
		object LT264_tree=null;

		try { DebugEnterRule(GrammarFileName, "assignmentExpressionNoIn");
		DebugLocation(234, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 45)) { return retval; }
			// JavaScript.g:235:2: ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn )
			int alt126=2;
			try { DebugEnterDecision(126, decisionCanBacktrack[126]);
			try
			{
				alt126 = dfa126.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(126); }
			switch (alt126)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:235:4: conditionalExpressionNoIn
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(235, 4);
				PushFollow(Follow._conditionalExpressionNoIn_in_assignmentExpressionNoIn1402);
				conditionalExpressionNoIn260=conditionalExpressionNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpressionNoIn260.Tree, conditionalExpressionNoIn260, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:236:4: leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(236, 4);
				PushFollow(Follow._leftHandSideExpression_in_assignmentExpressionNoIn1407);
				leftHandSideExpression261=leftHandSideExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression261.Tree, leftHandSideExpression261, retval);
				DebugLocation(236, 29);
				// JavaScript.g:236:29: ( LT )*
				try { DebugEnterSubRule(124);
				while (true)
				{
					int alt124=2;
					try { DebugEnterDecision(124, decisionCanBacktrack[124]);
					int LA124_0 = input.LA(1);

					if ((LA124_0==LT))
					{
						alt124=1;
					}


					} finally { DebugExitDecision(124); }
					switch ( alt124 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(236, 29);
						LT262=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_assignmentExpressionNoIn1409), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop124;
					}
				}

				loop124:
					;

				} finally { DebugExitSubRule(124); }

				DebugLocation(236, 32);
				PushFollow(Follow._assignmentOperator_in_assignmentExpressionNoIn1413);
				assignmentOperator263=assignmentOperator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentOperator263.Tree, assignmentOperator263, retval);
				DebugLocation(236, 53);
				// JavaScript.g:236:53: ( LT )*
				try { DebugEnterSubRule(125);
				while (true)
				{
					int alt125=2;
					try { DebugEnterDecision(125, decisionCanBacktrack[125]);
					int LA125_0 = input.LA(1);

					if ((LA125_0==LT))
					{
						alt125=1;
					}


					} finally { DebugExitDecision(125); }
					switch ( alt125 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(236, 53);
						LT264=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_assignmentExpressionNoIn1415), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop125;
					}
				}

				loop125:
					;

				} finally { DebugExitSubRule(125); }

				DebugLocation(236, 56);
				PushFollow(Follow._assignmentExpressionNoIn_in_assignmentExpressionNoIn1419);
				assignmentExpressionNoIn265=assignmentExpressionNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn265.Tree, assignmentExpressionNoIn265, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignmentExpressionNoIn", 45);
			LeaveRule("assignmentExpressionNoIn", 45);
			Leave_assignmentExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 45, assignmentExpressionNoIn_StartIndex); }
		}
		DebugLocation(237, 1);
		} finally { DebugExitRule(GrammarFileName, "assignmentExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "assignmentExpressionNoIn"

	public class leftHandSideExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_leftHandSideExpression();
	partial void Leave_leftHandSideExpression();

	// $ANTLR start "leftHandSideExpression"
	// JavaScript.g:239:1: leftHandSideExpression : ( callExpression | newExpression );
	[GrammarRule("leftHandSideExpression")]
	public JavaScriptParser.leftHandSideExpression_return leftHandSideExpression()
	{
		Enter_leftHandSideExpression();
		EnterRule("leftHandSideExpression", 46);
		TraceIn("leftHandSideExpression", 46);
		JavaScriptParser.leftHandSideExpression_return retval = new JavaScriptParser.leftHandSideExpression_return();
		retval.Start = (IToken)input.LT(1);
		int leftHandSideExpression_StartIndex = input.Index;
		object root_0 = null;

		JavaScriptParser.callExpression_return callExpression266 = default(JavaScriptParser.callExpression_return);
		JavaScriptParser.newExpression_return newExpression267 = default(JavaScriptParser.newExpression_return);


		try { DebugEnterRule(GrammarFileName, "leftHandSideExpression");
		DebugLocation(239, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 46)) { return retval; }
			// JavaScript.g:240:2: ( callExpression | newExpression )
			int alt127=2;
			try { DebugEnterDecision(127, decisionCanBacktrack[127]);
			try
			{
				alt127 = dfa127.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(127); }
			switch (alt127)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:240:4: callExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(240, 4);
				PushFollow(Follow._callExpression_in_leftHandSideExpression1431);
				callExpression266=callExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, callExpression266.Tree, callExpression266, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:241:4: newExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(241, 4);
				PushFollow(Follow._newExpression_in_leftHandSideExpression1436);
				newExpression267=newExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, newExpression267.Tree, newExpression267, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("leftHandSideExpression", 46);
			LeaveRule("leftHandSideExpression", 46);
			Leave_leftHandSideExpression();
			if (state.backtracking > 0) { Memoize(input, 46, leftHandSideExpression_StartIndex); }
		}
		DebugLocation(242, 1);
		} finally { DebugExitRule(GrammarFileName, "leftHandSideExpression"); }
		return retval;

	}
	// $ANTLR end "leftHandSideExpression"

	public class newExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_newExpression();
	partial void Leave_newExpression();

	// $ANTLR start "newExpression"
	// JavaScript.g:244:1: newExpression : ( memberExpression | 'new' ( LT )* newExpression );
	[GrammarRule("newExpression")]
	public JavaScriptParser.newExpression_return newExpression()
	{
		Enter_newExpression();
		EnterRule("newExpression", 47);
		TraceIn("newExpression", 47);
		JavaScriptParser.newExpression_return retval = new JavaScriptParser.newExpression_return();
		retval.Start = (IToken)input.LT(1);
		int newExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal269=null;
		IToken LT270=null;
		JavaScriptParser.memberExpression_return memberExpression268 = default(JavaScriptParser.memberExpression_return);
		JavaScriptParser.newExpression_return newExpression271 = default(JavaScriptParser.newExpression_return);

		object string_literal269_tree=null;
		object LT270_tree=null;

		try { DebugEnterRule(GrammarFileName, "newExpression");
		DebugLocation(244, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 47)) { return retval; }
			// JavaScript.g:245:2: ( memberExpression | 'new' ( LT )* newExpression )
			int alt129=2;
			try { DebugEnterDecision(129, decisionCanBacktrack[129]);
			try
			{
				alt129 = dfa129.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(129); }
			switch (alt129)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:245:4: memberExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(245, 4);
				PushFollow(Follow._memberExpression_in_newExpression1448);
				memberExpression268=memberExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression268.Tree, memberExpression268, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:246:4: 'new' ( LT )* newExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(246, 4);
				string_literal269=(IToken)Match(input,68,Follow._68_in_newExpression1453); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal269_tree = (object)adaptor.Create(string_literal269, retval);
				adaptor.AddChild(root_0, string_literal269_tree);
				}
				DebugLocation(246, 12);
				// JavaScript.g:246:12: ( LT )*
				try { DebugEnterSubRule(128);
				while (true)
				{
					int alt128=2;
					try { DebugEnterDecision(128, decisionCanBacktrack[128]);
					int LA128_0 = input.LA(1);

					if ((LA128_0==LT))
					{
						alt128=1;
					}


					} finally { DebugExitDecision(128); }
					switch ( alt128 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(246, 12);
						LT270=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_newExpression1455), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop128;
					}
				}

				loop128:
					;

				} finally { DebugExitSubRule(128); }

				DebugLocation(246, 15);
				PushFollow(Follow._newExpression_in_newExpression1459);
				newExpression271=newExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, newExpression271.Tree, newExpression271, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("newExpression", 47);
			LeaveRule("newExpression", 47);
			Leave_newExpression();
			if (state.backtracking > 0) { Memoize(input, 47, newExpression_StartIndex); }
		}
		DebugLocation(247, 1);
		} finally { DebugExitRule(GrammarFileName, "newExpression"); }
		return retval;

	}
	// $ANTLR end "newExpression"

	public class memberExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_memberExpression();
	partial void Leave_memberExpression();

	// $ANTLR start "memberExpression"
	// JavaScript.g:249:1: memberExpression : ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )* ;
	[GrammarRule("memberExpression")]
	public JavaScriptParser.memberExpression_return memberExpression()
	{
		Enter_memberExpression();
		EnterRule("memberExpression", 48);
		TraceIn("memberExpression", 48);
		JavaScriptParser.memberExpression_return retval = new JavaScriptParser.memberExpression_return();
		retval.Start = (IToken)input.LT(1);
		int memberExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal274=null;
		IToken LT275=null;
		IToken LT277=null;
		IToken LT279=null;
		JavaScriptParser.primaryExpression_return primaryExpression272 = default(JavaScriptParser.primaryExpression_return);
		JavaScriptParser.functionExpression_return functionExpression273 = default(JavaScriptParser.functionExpression_return);
		JavaScriptParser.memberExpression_return memberExpression276 = default(JavaScriptParser.memberExpression_return);
		JavaScriptParser.arguments_return arguments278 = default(JavaScriptParser.arguments_return);
		JavaScriptParser.memberExpressionSuffix_return memberExpressionSuffix280 = default(JavaScriptParser.memberExpressionSuffix_return);

		object string_literal274_tree=null;
		object LT275_tree=null;
		object LT277_tree=null;
		object LT279_tree=null;

		try { DebugEnterRule(GrammarFileName, "memberExpression");
		DebugLocation(249, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 48)) { return retval; }
			// JavaScript.g:250:2: ( ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )* )
			DebugEnterAlt(1);
			// JavaScript.g:250:4: ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(250, 4);
			// JavaScript.g:250:4: ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments )
			int alt132=3;
			try { DebugEnterSubRule(132);
			try { DebugEnterDecision(132, decisionCanBacktrack[132]);
			switch (input.LA(1))
			{
			case NULL:
			case TRUE:
			case FALSE:
			case THIS:
			case Identifier:
			case NumericLiteral:
			case StringLiteral:
			case RegularExpressionLiteral:
			case 45:
			case 47:
			case 69:
				{
				alt132=1;
				}
				break;
			case 44:
				{
				alt132=2;
				}
				break;
			case 68:
				{
				alt132=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 132, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(132); }
			switch (alt132)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:250:5: primaryExpression
				{
				DebugLocation(250, 5);
				PushFollow(Follow._primaryExpression_in_memberExpression1472);
				primaryExpression272=primaryExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primaryExpression272.Tree, primaryExpression272, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:250:25: functionExpression
				{
				DebugLocation(250, 25);
				PushFollow(Follow._functionExpression_in_memberExpression1476);
				functionExpression273=functionExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionExpression273.Tree, functionExpression273, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:250:46: 'new' ( LT )* memberExpression ( LT )* arguments
				{
				DebugLocation(250, 46);
				string_literal274=(IToken)Match(input,68,Follow._68_in_memberExpression1480); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal274_tree = (object)adaptor.Create(string_literal274, retval);
				adaptor.AddChild(root_0, string_literal274_tree);
				}
				DebugLocation(250, 54);
				// JavaScript.g:250:54: ( LT )*
				try { DebugEnterSubRule(130);
				while (true)
				{
					int alt130=2;
					try { DebugEnterDecision(130, decisionCanBacktrack[130]);
					int LA130_0 = input.LA(1);

					if ((LA130_0==LT))
					{
						alt130=1;
					}


					} finally { DebugExitDecision(130); }
					switch ( alt130 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(250, 54);
						LT275=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_memberExpression1482), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop130;
					}
				}

				loop130:
					;

				} finally { DebugExitSubRule(130); }

				DebugLocation(250, 57);
				PushFollow(Follow._memberExpression_in_memberExpression1486);
				memberExpression276=memberExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression276.Tree, memberExpression276, retval);
				DebugLocation(250, 76);
				// JavaScript.g:250:76: ( LT )*
				try { DebugEnterSubRule(131);
				while (true)
				{
					int alt131=2;
					try { DebugEnterDecision(131, decisionCanBacktrack[131]);
					int LA131_0 = input.LA(1);

					if ((LA131_0==LT))
					{
						alt131=1;
					}


					} finally { DebugExitDecision(131); }
					switch ( alt131 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(250, 76);
						LT277=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_memberExpression1488), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop131;
					}
				}

				loop131:
					;

				} finally { DebugExitSubRule(131); }

				DebugLocation(250, 79);
				PushFollow(Follow._arguments_in_memberExpression1492);
				arguments278=arguments();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments278.Tree, arguments278, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(132); }

			DebugLocation(250, 90);
			// JavaScript.g:250:90: ( ( LT )* memberExpressionSuffix )*
			try { DebugEnterSubRule(134);
			while (true)
			{
				int alt134=2;
				try { DebugEnterDecision(134, decisionCanBacktrack[134]);
				try
				{
					alt134 = dfa134.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(134); }
				switch ( alt134 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:250:91: ( LT )* memberExpressionSuffix
					{
					DebugLocation(250, 93);
					// JavaScript.g:250:93: ( LT )*
					try { DebugEnterSubRule(133);
					while (true)
					{
						int alt133=2;
						try { DebugEnterDecision(133, decisionCanBacktrack[133]);
						int LA133_0 = input.LA(1);

						if ((LA133_0==LT))
						{
							alt133=1;
						}


						} finally { DebugExitDecision(133); }
						switch ( alt133 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(250, 93);
							LT279=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_memberExpression1496), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop133;
						}
					}

					loop133:
						;

					} finally { DebugExitSubRule(133); }

					DebugLocation(250, 96);
					PushFollow(Follow._memberExpressionSuffix_in_memberExpression1500);
					memberExpressionSuffix280=memberExpressionSuffix();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpressionSuffix280.Tree, memberExpressionSuffix280, retval);

					}
					break;

				default:
					goto loop134;
				}
			}

			loop134:
				;

			} finally { DebugExitSubRule(134); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("memberExpression", 48);
			LeaveRule("memberExpression", 48);
			Leave_memberExpression();
			if (state.backtracking > 0) { Memoize(input, 48, memberExpression_StartIndex); }
		}
		DebugLocation(251, 1);
		} finally { DebugExitRule(GrammarFileName, "memberExpression"); }
		return retval;

	}
	// $ANTLR end "memberExpression"

	public class memberExpressionSuffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_memberExpressionSuffix();
	partial void Leave_memberExpressionSuffix();

	// $ANTLR start "memberExpressionSuffix"
	// JavaScript.g:253:1: memberExpressionSuffix : ( indexSuffix | propertyReferenceSuffix );
	[GrammarRule("memberExpressionSuffix")]
	public JavaScriptParser.memberExpressionSuffix_return memberExpressionSuffix()
	{
		Enter_memberExpressionSuffix();
		EnterRule("memberExpressionSuffix", 49);
		TraceIn("memberExpressionSuffix", 49);
		JavaScriptParser.memberExpressionSuffix_return retval = new JavaScriptParser.memberExpressionSuffix_return();
		retval.Start = (IToken)input.LT(1);
		int memberExpressionSuffix_StartIndex = input.Index;
		object root_0 = null;

		JavaScriptParser.indexSuffix_return indexSuffix281 = default(JavaScriptParser.indexSuffix_return);
		JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix282 = default(JavaScriptParser.propertyReferenceSuffix_return);


		try { DebugEnterRule(GrammarFileName, "memberExpressionSuffix");
		DebugLocation(253, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 49)) { return retval; }
			// JavaScript.g:254:2: ( indexSuffix | propertyReferenceSuffix )
			int alt135=2;
			try { DebugEnterDecision(135, decisionCanBacktrack[135]);
			int LA135_0 = input.LA(1);

			if ((LA135_0==69))
			{
				alt135=1;
			}
			else if ((LA135_0==70))
			{
				alt135=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 135, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(135); }
			switch (alt135)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:254:4: indexSuffix
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(254, 4);
				PushFollow(Follow._indexSuffix_in_memberExpressionSuffix1514);
				indexSuffix281=indexSuffix();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, indexSuffix281.Tree, indexSuffix281, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:255:4: propertyReferenceSuffix
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(255, 4);
				PushFollow(Follow._propertyReferenceSuffix_in_memberExpressionSuffix1519);
				propertyReferenceSuffix282=propertyReferenceSuffix();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyReferenceSuffix282.Tree, propertyReferenceSuffix282, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("memberExpressionSuffix", 49);
			LeaveRule("memberExpressionSuffix", 49);
			Leave_memberExpressionSuffix();
			if (state.backtracking > 0) { Memoize(input, 49, memberExpressionSuffix_StartIndex); }
		}
		DebugLocation(256, 1);
		} finally { DebugExitRule(GrammarFileName, "memberExpressionSuffix"); }
		return retval;

	}
	// $ANTLR end "memberExpressionSuffix"

	public class callExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_callExpression();
	partial void Leave_callExpression();

	// $ANTLR start "callExpression"
	// JavaScript.g:258:1: callExpression : memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )* ;
	[GrammarRule("callExpression")]
	public JavaScriptParser.callExpression_return callExpression()
	{
		Enter_callExpression();
		EnterRule("callExpression", 50);
		TraceIn("callExpression", 50);
		JavaScriptParser.callExpression_return retval = new JavaScriptParser.callExpression_return();
		retval.Start = (IToken)input.LT(1);
		int callExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT284=null;
		IToken LT286=null;
		JavaScriptParser.memberExpression_return memberExpression283 = default(JavaScriptParser.memberExpression_return);
		JavaScriptParser.arguments_return arguments285 = default(JavaScriptParser.arguments_return);
		JavaScriptParser.callExpressionSuffix_return callExpressionSuffix287 = default(JavaScriptParser.callExpressionSuffix_return);

		object LT284_tree=null;
		object LT286_tree=null;

		try { DebugEnterRule(GrammarFileName, "callExpression");
		DebugLocation(258, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 50)) { return retval; }
			// JavaScript.g:259:2: ( memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )* )
			DebugEnterAlt(1);
			// JavaScript.g:259:4: memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(259, 4);
			PushFollow(Follow._memberExpression_in_callExpression1530);
			memberExpression283=memberExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression283.Tree, memberExpression283, retval);
			DebugLocation(259, 23);
			// JavaScript.g:259:23: ( LT )*
			try { DebugEnterSubRule(136);
			while (true)
			{
				int alt136=2;
				try { DebugEnterDecision(136, decisionCanBacktrack[136]);
				int LA136_0 = input.LA(1);

				if ((LA136_0==LT))
				{
					alt136=1;
				}


				} finally { DebugExitDecision(136); }
				switch ( alt136 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(259, 23);
					LT284=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_callExpression1532), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop136;
				}
			}

			loop136:
				;

			} finally { DebugExitSubRule(136); }

			DebugLocation(259, 26);
			PushFollow(Follow._arguments_in_callExpression1536);
			arguments285=arguments();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments285.Tree, arguments285, retval);
			DebugLocation(259, 36);
			// JavaScript.g:259:36: ( ( LT )* callExpressionSuffix )*
			try { DebugEnterSubRule(138);
			while (true)
			{
				int alt138=2;
				try { DebugEnterDecision(138, decisionCanBacktrack[138]);
				try
				{
					alt138 = dfa138.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(138); }
				switch ( alt138 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:259:37: ( LT )* callExpressionSuffix
					{
					DebugLocation(259, 39);
					// JavaScript.g:259:39: ( LT )*
					try { DebugEnterSubRule(137);
					while (true)
					{
						int alt137=2;
						try { DebugEnterDecision(137, decisionCanBacktrack[137]);
						int LA137_0 = input.LA(1);

						if ((LA137_0==LT))
						{
							alt137=1;
						}


						} finally { DebugExitDecision(137); }
						switch ( alt137 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(259, 39);
							LT286=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_callExpression1539), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop137;
						}
					}

					loop137:
						;

					} finally { DebugExitSubRule(137); }

					DebugLocation(259, 42);
					PushFollow(Follow._callExpressionSuffix_in_callExpression1543);
					callExpressionSuffix287=callExpressionSuffix();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, callExpressionSuffix287.Tree, callExpressionSuffix287, retval);

					}
					break;

				default:
					goto loop138;
				}
			}

			loop138:
				;

			} finally { DebugExitSubRule(138); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("callExpression", 50);
			LeaveRule("callExpression", 50);
			Leave_callExpression();
			if (state.backtracking > 0) { Memoize(input, 50, callExpression_StartIndex); }
		}
		DebugLocation(260, 1);
		} finally { DebugExitRule(GrammarFileName, "callExpression"); }
		return retval;

	}
	// $ANTLR end "callExpression"

	public class callExpressionSuffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_callExpressionSuffix();
	partial void Leave_callExpressionSuffix();

	// $ANTLR start "callExpressionSuffix"
	// JavaScript.g:262:1: callExpressionSuffix : ( arguments | indexSuffix | propertyReferenceSuffix );
	[GrammarRule("callExpressionSuffix")]
	public JavaScriptParser.callExpressionSuffix_return callExpressionSuffix()
	{
		Enter_callExpressionSuffix();
		EnterRule("callExpressionSuffix", 51);
		TraceIn("callExpressionSuffix", 51);
		JavaScriptParser.callExpressionSuffix_return retval = new JavaScriptParser.callExpressionSuffix_return();
		retval.Start = (IToken)input.LT(1);
		int callExpressionSuffix_StartIndex = input.Index;
		object root_0 = null;

		JavaScriptParser.arguments_return arguments288 = default(JavaScriptParser.arguments_return);
		JavaScriptParser.indexSuffix_return indexSuffix289 = default(JavaScriptParser.indexSuffix_return);
		JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix290 = default(JavaScriptParser.propertyReferenceSuffix_return);


		try { DebugEnterRule(GrammarFileName, "callExpressionSuffix");
		DebugLocation(262, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 51)) { return retval; }
			// JavaScript.g:263:2: ( arguments | indexSuffix | propertyReferenceSuffix )
			int alt139=3;
			try { DebugEnterDecision(139, decisionCanBacktrack[139]);
			switch (input.LA(1))
			{
			case 45:
				{
				alt139=1;
				}
				break;
			case 69:
				{
				alt139=2;
				}
				break;
			case 70:
				{
				alt139=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 139, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(139); }
			switch (alt139)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:263:4: arguments
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(263, 4);
				PushFollow(Follow._arguments_in_callExpressionSuffix1557);
				arguments288=arguments();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments288.Tree, arguments288, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:264:4: indexSuffix
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(264, 4);
				PushFollow(Follow._indexSuffix_in_callExpressionSuffix1562);
				indexSuffix289=indexSuffix();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, indexSuffix289.Tree, indexSuffix289, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:265:4: propertyReferenceSuffix
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(265, 4);
				PushFollow(Follow._propertyReferenceSuffix_in_callExpressionSuffix1567);
				propertyReferenceSuffix290=propertyReferenceSuffix();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyReferenceSuffix290.Tree, propertyReferenceSuffix290, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("callExpressionSuffix", 51);
			LeaveRule("callExpressionSuffix", 51);
			Leave_callExpressionSuffix();
			if (state.backtracking > 0) { Memoize(input, 51, callExpressionSuffix_StartIndex); }
		}
		DebugLocation(266, 1);
		} finally { DebugExitRule(GrammarFileName, "callExpressionSuffix"); }
		return retval;

	}
	// $ANTLR end "callExpressionSuffix"

	public class arguments_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_arguments();
	partial void Leave_arguments();

	// $ANTLR start "arguments"
	// JavaScript.g:268:1: arguments : '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* RPAREN ;
	[GrammarRule("arguments")]
	public JavaScriptParser.arguments_return arguments()
	{
		Enter_arguments();
		EnterRule("arguments", 52);
		TraceIn("arguments", 52);
		JavaScriptParser.arguments_return retval = new JavaScriptParser.arguments_return();
		retval.Start = (IToken)input.LT(1);
		int arguments_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal291=null;
		IToken LT292=null;
		IToken LT294=null;
		IToken char_literal295=null;
		IToken LT296=null;
		IToken LT298=null;
		IToken RPAREN299=null;
		JavaScriptParser.assignmentExpression_return assignmentExpression293 = default(JavaScriptParser.assignmentExpression_return);
		JavaScriptParser.assignmentExpression_return assignmentExpression297 = default(JavaScriptParser.assignmentExpression_return);

		object char_literal291_tree=null;
		object LT292_tree=null;
		object LT294_tree=null;
		object char_literal295_tree=null;
		object LT296_tree=null;
		object LT298_tree=null;
		object RPAREN299_tree=null;

		try { DebugEnterRule(GrammarFileName, "arguments");
		DebugLocation(268, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 52)) { return retval; }
			// JavaScript.g:269:2: ( '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* RPAREN )
			DebugEnterAlt(1);
			// JavaScript.g:269:4: '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* RPAREN
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(269, 4);
			char_literal291=(IToken)Match(input,45,Follow._45_in_arguments1578); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal291_tree = (object)adaptor.Create(char_literal291, retval);
			adaptor.AddChild(root_0, char_literal291_tree);
			}
			DebugLocation(269, 8);
			// JavaScript.g:269:8: ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )?
			int alt144=2;
			try { DebugEnterSubRule(144);
			try { DebugEnterDecision(144, decisionCanBacktrack[144]);
			try
			{
				alt144 = dfa144.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(144); }
			switch (alt144)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:269:9: ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )*
				{
				DebugLocation(269, 11);
				// JavaScript.g:269:11: ( LT )*
				try { DebugEnterSubRule(140);
				while (true)
				{
					int alt140=2;
					try { DebugEnterDecision(140, decisionCanBacktrack[140]);
					int LA140_0 = input.LA(1);

					if ((LA140_0==LT))
					{
						alt140=1;
					}


					} finally { DebugExitDecision(140); }
					switch ( alt140 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(269, 11);
						LT292=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arguments1581), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop140;
					}
				}

				loop140:
					;

				} finally { DebugExitSubRule(140); }

				DebugLocation(269, 14);
				PushFollow(Follow._assignmentExpression_in_arguments1585);
				assignmentExpression293=assignmentExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression293.Tree, assignmentExpression293, retval);
				DebugLocation(269, 35);
				// JavaScript.g:269:35: ( ( LT )* ',' ( LT )* assignmentExpression )*
				try { DebugEnterSubRule(143);
				while (true)
				{
					int alt143=2;
					try { DebugEnterDecision(143, decisionCanBacktrack[143]);
					try
					{
						alt143 = dfa143.Predict(input);
					}
					catch (NoViableAltException nvae)
					{
						DebugRecognitionException(nvae);
						throw;
					}
					} finally { DebugExitDecision(143); }
					switch ( alt143 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:269:36: ( LT )* ',' ( LT )* assignmentExpression
						{
						DebugLocation(269, 38);
						// JavaScript.g:269:38: ( LT )*
						try { DebugEnterSubRule(141);
						while (true)
						{
							int alt141=2;
							try { DebugEnterDecision(141, decisionCanBacktrack[141]);
							int LA141_0 = input.LA(1);

							if ((LA141_0==LT))
							{
								alt141=1;
							}


							} finally { DebugExitDecision(141); }
							switch ( alt141 )
							{
							case 1:
								DebugEnterAlt(1);
								// JavaScript.g:0:0: LT
								{
								DebugLocation(269, 38);
								LT294=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arguments1588), "LT"); if (state.failed) return retval;

								}
								break;

							default:
								goto loop141;
							}
						}

						loop141:
							;

						} finally { DebugExitSubRule(141); }

						DebugLocation(269, 41);
						char_literal295=(IToken)Match(input,46,Follow._46_in_arguments1592); if (state.failed) return retval;
						if ( state.backtracking==0 ) {
						char_literal295_tree = (object)adaptor.Create(char_literal295, retval);
						adaptor.AddChild(root_0, char_literal295_tree);
						}
						DebugLocation(269, 47);
						// JavaScript.g:269:47: ( LT )*
						try { DebugEnterSubRule(142);
						while (true)
						{
							int alt142=2;
							try { DebugEnterDecision(142, decisionCanBacktrack[142]);
							int LA142_0 = input.LA(1);

							if ((LA142_0==LT))
							{
								alt142=1;
							}


							} finally { DebugExitDecision(142); }
							switch ( alt142 )
							{
							case 1:
								DebugEnterAlt(1);
								// JavaScript.g:0:0: LT
								{
								DebugLocation(269, 47);
								LT296=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arguments1594), "LT"); if (state.failed) return retval;

								}
								break;

							default:
								goto loop142;
							}
						}

						loop142:
							;

						} finally { DebugExitSubRule(142); }

						DebugLocation(269, 50);
						PushFollow(Follow._assignmentExpression_in_arguments1598);
						assignmentExpression297=assignmentExpression();
						PopFollow();
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression297.Tree, assignmentExpression297, retval);

						}
						break;

					default:
						goto loop143;
					}
				}

				loop143:
					;

				} finally { DebugExitSubRule(143); }


				}
				break;

			}
			} finally { DebugExitSubRule(144); }

			DebugLocation(269, 77);
			// JavaScript.g:269:77: ( LT )*
			try { DebugEnterSubRule(145);
			while (true)
			{
				int alt145=2;
				try { DebugEnterDecision(145, decisionCanBacktrack[145]);
				int LA145_0 = input.LA(1);

				if ((LA145_0==LT))
				{
					alt145=1;
				}


				} finally { DebugExitDecision(145); }
				switch ( alt145 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(269, 77);
					LT298=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arguments1604), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop145;
				}
			}

			loop145:
				;

			} finally { DebugExitSubRule(145); }

			DebugLocation(269, 80);
			RPAREN299=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_arguments1608), "RPAREN"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RPAREN299_tree = (object)adaptor.Create(RPAREN299, retval);
			adaptor.AddChild(root_0, RPAREN299_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("arguments", 52);
			LeaveRule("arguments", 52);
			Leave_arguments();
			if (state.backtracking > 0) { Memoize(input, 52, arguments_StartIndex); }
		}
		DebugLocation(270, 1);
		} finally { DebugExitRule(GrammarFileName, "arguments"); }
		return retval;

	}
	// $ANTLR end "arguments"

	public class indexSuffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_indexSuffix();
	partial void Leave_indexSuffix();

	// $ANTLR start "indexSuffix"
	// JavaScript.g:272:1: indexSuffix : '[' ( LT )* expression ( LT )* RBRACK ;
	[GrammarRule("indexSuffix")]
	public JavaScriptParser.indexSuffix_return indexSuffix()
	{
		Enter_indexSuffix();
		EnterRule("indexSuffix", 53);
		TraceIn("indexSuffix", 53);
		JavaScriptParser.indexSuffix_return retval = new JavaScriptParser.indexSuffix_return();
		retval.Start = (IToken)input.LT(1);
		int indexSuffix_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal300=null;
		IToken LT301=null;
		IToken LT303=null;
		IToken RBRACK304=null;
		JavaScriptParser.expression_return expression302 = default(JavaScriptParser.expression_return);

		object char_literal300_tree=null;
		object LT301_tree=null;
		object LT303_tree=null;
		object RBRACK304_tree=null;

		try { DebugEnterRule(GrammarFileName, "indexSuffix");
		DebugLocation(272, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 53)) { return retval; }
			// JavaScript.g:273:2: ( '[' ( LT )* expression ( LT )* RBRACK )
			DebugEnterAlt(1);
			// JavaScript.g:273:4: '[' ( LT )* expression ( LT )* RBRACK
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(273, 4);
			char_literal300=(IToken)Match(input,69,Follow._69_in_indexSuffix1620); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal300_tree = (object)adaptor.Create(char_literal300, retval);
			adaptor.AddChild(root_0, char_literal300_tree);
			}
			DebugLocation(273, 10);
			// JavaScript.g:273:10: ( LT )*
			try { DebugEnterSubRule(146);
			while (true)
			{
				int alt146=2;
				try { DebugEnterDecision(146, decisionCanBacktrack[146]);
				int LA146_0 = input.LA(1);

				if ((LA146_0==LT))
				{
					alt146=1;
				}


				} finally { DebugExitDecision(146); }
				switch ( alt146 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(273, 10);
					LT301=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_indexSuffix1622), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop146;
				}
			}

			loop146:
				;

			} finally { DebugExitSubRule(146); }

			DebugLocation(273, 13);
			PushFollow(Follow._expression_in_indexSuffix1626);
			expression302=expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression302.Tree, expression302, retval);
			DebugLocation(273, 26);
			// JavaScript.g:273:26: ( LT )*
			try { DebugEnterSubRule(147);
			while (true)
			{
				int alt147=2;
				try { DebugEnterDecision(147, decisionCanBacktrack[147]);
				int LA147_0 = input.LA(1);

				if ((LA147_0==LT))
				{
					alt147=1;
				}


				} finally { DebugExitDecision(147); }
				switch ( alt147 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(273, 26);
					LT303=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_indexSuffix1628), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop147;
				}
			}

			loop147:
				;

			} finally { DebugExitSubRule(147); }

			DebugLocation(273, 29);
			RBRACK304=(IToken)new XToken((IToken)Match(input,RBRACK,Follow._RBRACK_in_indexSuffix1632), "RBRACK"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RBRACK304_tree = (object)adaptor.Create(RBRACK304, retval);
			adaptor.AddChild(root_0, RBRACK304_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("indexSuffix", 53);
			LeaveRule("indexSuffix", 53);
			Leave_indexSuffix();
			if (state.backtracking > 0) { Memoize(input, 53, indexSuffix_StartIndex); }
		}
		DebugLocation(274, 1);
		} finally { DebugExitRule(GrammarFileName, "indexSuffix"); }
		return retval;

	}
	// $ANTLR end "indexSuffix"

	public class propertyReferenceSuffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_propertyReferenceSuffix();
	partial void Leave_propertyReferenceSuffix();

	// $ANTLR start "propertyReferenceSuffix"
	// JavaScript.g:276:1: propertyReferenceSuffix : '.' ( LT )* Identifier ;
	[GrammarRule("propertyReferenceSuffix")]
	public JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix()
	{
		Enter_propertyReferenceSuffix();
		EnterRule("propertyReferenceSuffix", 54);
		TraceIn("propertyReferenceSuffix", 54);
		JavaScriptParser.propertyReferenceSuffix_return retval = new JavaScriptParser.propertyReferenceSuffix_return();
		retval.Start = (IToken)input.LT(1);
		int propertyReferenceSuffix_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal305=null;
		IToken LT306=null;
		IToken Identifier307=null;

		object char_literal305_tree=null;
		object LT306_tree=null;
		object Identifier307_tree=null;

		try { DebugEnterRule(GrammarFileName, "propertyReferenceSuffix");
		DebugLocation(276, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 54)) { return retval; }
			// JavaScript.g:277:2: ( '.' ( LT )* Identifier )
			DebugEnterAlt(1);
			// JavaScript.g:277:4: '.' ( LT )* Identifier
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(277, 4);
			char_literal305=(IToken)Match(input,70,Follow._70_in_propertyReferenceSuffix1645); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal305_tree = (object)adaptor.Create(char_literal305, retval);
			adaptor.AddChild(root_0, char_literal305_tree);
			}
			DebugLocation(277, 10);
			// JavaScript.g:277:10: ( LT )*
			try { DebugEnterSubRule(148);
			while (true)
			{
				int alt148=2;
				try { DebugEnterDecision(148, decisionCanBacktrack[148]);
				int LA148_0 = input.LA(1);

				if ((LA148_0==LT))
				{
					alt148=1;
				}


				} finally { DebugExitDecision(148); }
				switch ( alt148 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(277, 10);
					LT306=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_propertyReferenceSuffix1647), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop148;
				}
			}

			loop148:
				;

			} finally { DebugExitSubRule(148); }

			DebugLocation(277, 13);
			Identifier307=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_propertyReferenceSuffix1651), "Identifier"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			Identifier307_tree = (object)adaptor.Create(Identifier307, retval);
			adaptor.AddChild(root_0, Identifier307_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("propertyReferenceSuffix", 54);
			LeaveRule("propertyReferenceSuffix", 54);
			Leave_propertyReferenceSuffix();
			if (state.backtracking > 0) { Memoize(input, 54, propertyReferenceSuffix_StartIndex); }
		}
		DebugLocation(278, 1);
		} finally { DebugExitRule(GrammarFileName, "propertyReferenceSuffix"); }
		return retval;

	}
	// $ANTLR end "propertyReferenceSuffix"

	public class assignmentOperator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignmentOperator();
	partial void Leave_assignmentOperator();

	// $ANTLR start "assignmentOperator"
	// JavaScript.g:280:1: assignmentOperator : ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '>>>=' | '&=' | '^=' | '|=' );
	[GrammarRule("assignmentOperator")]
	public JavaScriptParser.assignmentOperator_return assignmentOperator()
	{
		Enter_assignmentOperator();
		EnterRule("assignmentOperator", 55);
		TraceIn("assignmentOperator", 55);
		JavaScriptParser.assignmentOperator_return retval = new JavaScriptParser.assignmentOperator_return();
		retval.Start = (IToken)input.LT(1);
		int assignmentOperator_StartIndex = input.Index;
		object root_0 = null;

		IToken set308=null;

		object set308_tree=null;

		try { DebugEnterRule(GrammarFileName, "assignmentOperator");
		DebugLocation(280, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 55)) { return retval; }
			// JavaScript.g:281:2: ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '>>>=' | '&=' | '^=' | '|=' )
			DebugEnterAlt(1);
			// JavaScript.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(281, 2);
			set308=(IToken)input.LT(1);
			if (input.LA(1)==49||(input.LA(1)>=71 && input.LA(1)<=81))
			{
				input.Consume();
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set308, retval));
				state.errorRecovery=false;state.failed=false;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignmentOperator", 55);
			LeaveRule("assignmentOperator", 55);
			Leave_assignmentOperator();
			if (state.backtracking > 0) { Memoize(input, 55, assignmentOperator_StartIndex); }
		}
		DebugLocation(282, 1);
		} finally { DebugExitRule(GrammarFileName, "assignmentOperator"); }
		return retval;

	}
	// $ANTLR end "assignmentOperator"

	public class conditionalExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_conditionalExpression();
	partial void Leave_conditionalExpression();

	// $ANTLR start "conditionalExpression"
	// JavaScript.g:284:1: conditionalExpression : logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )? ;
	[GrammarRule("conditionalExpression")]
	public JavaScriptParser.conditionalExpression_return conditionalExpression()
	{
		Enter_conditionalExpression();
		EnterRule("conditionalExpression", 56);
		TraceIn("conditionalExpression", 56);
		JavaScriptParser.conditionalExpression_return retval = new JavaScriptParser.conditionalExpression_return();
		retval.Start = (IToken)input.LT(1);
		int conditionalExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT310=null;
		IToken char_literal311=null;
		IToken LT312=null;
		IToken LT314=null;
		IToken char_literal315=null;
		IToken LT316=null;
		JavaScriptParser.logicalORExpression_return logicalORExpression309 = default(JavaScriptParser.logicalORExpression_return);
		JavaScriptParser.assignmentExpression_return assignmentExpression313 = default(JavaScriptParser.assignmentExpression_return);
		JavaScriptParser.assignmentExpression_return assignmentExpression317 = default(JavaScriptParser.assignmentExpression_return);

		object LT310_tree=null;
		object char_literal311_tree=null;
		object LT312_tree=null;
		object LT314_tree=null;
		object char_literal315_tree=null;
		object LT316_tree=null;

		try { DebugEnterRule(GrammarFileName, "conditionalExpression");
		DebugLocation(284, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 56)) { return retval; }
			// JavaScript.g:285:2: ( logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )? )
			DebugEnterAlt(1);
			// JavaScript.g:285:4: logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(285, 4);
			PushFollow(Follow._logicalORExpression_in_conditionalExpression1718);
			logicalORExpression309=logicalORExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalORExpression309.Tree, logicalORExpression309, retval);
			DebugLocation(285, 24);
			// JavaScript.g:285:24: ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?
			int alt153=2;
			try { DebugEnterSubRule(153);
			try { DebugEnterDecision(153, decisionCanBacktrack[153]);
			try
			{
				alt153 = dfa153.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(153); }
			switch (alt153)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:285:25: ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression
				{
				DebugLocation(285, 27);
				// JavaScript.g:285:27: ( LT )*
				try { DebugEnterSubRule(149);
				while (true)
				{
					int alt149=2;
					try { DebugEnterDecision(149, decisionCanBacktrack[149]);
					int LA149_0 = input.LA(1);

					if ((LA149_0==LT))
					{
						alt149=1;
					}


					} finally { DebugExitDecision(149); }
					switch ( alt149 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(285, 27);
						LT310=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpression1721), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop149;
					}
				}

				loop149:
					;

				} finally { DebugExitSubRule(149); }

				DebugLocation(285, 30);
				char_literal311=(IToken)Match(input,82,Follow._82_in_conditionalExpression1725); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal311_tree = (object)adaptor.Create(char_literal311, retval);
				adaptor.AddChild(root_0, char_literal311_tree);
				}
				DebugLocation(285, 36);
				// JavaScript.g:285:36: ( LT )*
				try { DebugEnterSubRule(150);
				while (true)
				{
					int alt150=2;
					try { DebugEnterDecision(150, decisionCanBacktrack[150]);
					int LA150_0 = input.LA(1);

					if ((LA150_0==LT))
					{
						alt150=1;
					}


					} finally { DebugExitDecision(150); }
					switch ( alt150 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(285, 36);
						LT312=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpression1727), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop150;
					}
				}

				loop150:
					;

				} finally { DebugExitSubRule(150); }

				DebugLocation(285, 39);
				PushFollow(Follow._assignmentExpression_in_conditionalExpression1731);
				assignmentExpression313=assignmentExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression313.Tree, assignmentExpression313, retval);
				DebugLocation(285, 62);
				// JavaScript.g:285:62: ( LT )*
				try { DebugEnterSubRule(151);
				while (true)
				{
					int alt151=2;
					try { DebugEnterDecision(151, decisionCanBacktrack[151]);
					int LA151_0 = input.LA(1);

					if ((LA151_0==LT))
					{
						alt151=1;
					}


					} finally { DebugExitDecision(151); }
					switch ( alt151 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(285, 62);
						LT314=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpression1733), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop151;
					}
				}

				loop151:
					;

				} finally { DebugExitSubRule(151); }

				DebugLocation(285, 65);
				char_literal315=(IToken)Match(input,60,Follow._60_in_conditionalExpression1737); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal315_tree = (object)adaptor.Create(char_literal315, retval);
				adaptor.AddChild(root_0, char_literal315_tree);
				}
				DebugLocation(285, 71);
				// JavaScript.g:285:71: ( LT )*
				try { DebugEnterSubRule(152);
				while (true)
				{
					int alt152=2;
					try { DebugEnterDecision(152, decisionCanBacktrack[152]);
					int LA152_0 = input.LA(1);

					if ((LA152_0==LT))
					{
						alt152=1;
					}


					} finally { DebugExitDecision(152); }
					switch ( alt152 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(285, 71);
						LT316=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpression1739), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop152;
					}
				}

				loop152:
					;

				} finally { DebugExitSubRule(152); }

				DebugLocation(285, 74);
				PushFollow(Follow._assignmentExpression_in_conditionalExpression1743);
				assignmentExpression317=assignmentExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression317.Tree, assignmentExpression317, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(153); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("conditionalExpression", 56);
			LeaveRule("conditionalExpression", 56);
			Leave_conditionalExpression();
			if (state.backtracking > 0) { Memoize(input, 56, conditionalExpression_StartIndex); }
		}
		DebugLocation(286, 1);
		} finally { DebugExitRule(GrammarFileName, "conditionalExpression"); }
		return retval;

	}
	// $ANTLR end "conditionalExpression"

	public class conditionalExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_conditionalExpressionNoIn();
	partial void Leave_conditionalExpressionNoIn();

	// $ANTLR start "conditionalExpressionNoIn"
	// JavaScript.g:288:1: conditionalExpressionNoIn : logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )? ;
	[GrammarRule("conditionalExpressionNoIn")]
	public JavaScriptParser.conditionalExpressionNoIn_return conditionalExpressionNoIn()
	{
		Enter_conditionalExpressionNoIn();
		EnterRule("conditionalExpressionNoIn", 57);
		TraceIn("conditionalExpressionNoIn", 57);
		JavaScriptParser.conditionalExpressionNoIn_return retval = new JavaScriptParser.conditionalExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int conditionalExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT319=null;
		IToken char_literal320=null;
		IToken LT321=null;
		IToken LT323=null;
		IToken char_literal324=null;
		IToken LT325=null;
		JavaScriptParser.logicalORExpressionNoIn_return logicalORExpressionNoIn318 = default(JavaScriptParser.logicalORExpressionNoIn_return);
		JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn322 = default(JavaScriptParser.assignmentExpressionNoIn_return);
		JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn326 = default(JavaScriptParser.assignmentExpressionNoIn_return);

		object LT319_tree=null;
		object char_literal320_tree=null;
		object LT321_tree=null;
		object LT323_tree=null;
		object char_literal324_tree=null;
		object LT325_tree=null;

		try { DebugEnterRule(GrammarFileName, "conditionalExpressionNoIn");
		DebugLocation(288, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 57)) { return retval; }
			// JavaScript.g:289:2: ( logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )? )
			DebugEnterAlt(1);
			// JavaScript.g:289:4: logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(289, 4);
			PushFollow(Follow._logicalORExpressionNoIn_in_conditionalExpressionNoIn1756);
			logicalORExpressionNoIn318=logicalORExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalORExpressionNoIn318.Tree, logicalORExpressionNoIn318, retval);
			DebugLocation(289, 28);
			// JavaScript.g:289:28: ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?
			int alt158=2;
			try { DebugEnterSubRule(158);
			try { DebugEnterDecision(158, decisionCanBacktrack[158]);
			try
			{
				alt158 = dfa158.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(158); }
			switch (alt158)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:289:29: ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn
				{
				DebugLocation(289, 31);
				// JavaScript.g:289:31: ( LT )*
				try { DebugEnterSubRule(154);
				while (true)
				{
					int alt154=2;
					try { DebugEnterDecision(154, decisionCanBacktrack[154]);
					int LA154_0 = input.LA(1);

					if ((LA154_0==LT))
					{
						alt154=1;
					}


					} finally { DebugExitDecision(154); }
					switch ( alt154 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(289, 31);
						LT319=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpressionNoIn1759), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop154;
					}
				}

				loop154:
					;

				} finally { DebugExitSubRule(154); }

				DebugLocation(289, 34);
				char_literal320=(IToken)Match(input,82,Follow._82_in_conditionalExpressionNoIn1763); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal320_tree = (object)adaptor.Create(char_literal320, retval);
				adaptor.AddChild(root_0, char_literal320_tree);
				}
				DebugLocation(289, 40);
				// JavaScript.g:289:40: ( LT )*
				try { DebugEnterSubRule(155);
				while (true)
				{
					int alt155=2;
					try { DebugEnterDecision(155, decisionCanBacktrack[155]);
					int LA155_0 = input.LA(1);

					if ((LA155_0==LT))
					{
						alt155=1;
					}


					} finally { DebugExitDecision(155); }
					switch ( alt155 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(289, 40);
						LT321=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpressionNoIn1765), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop155;
					}
				}

				loop155:
					;

				} finally { DebugExitSubRule(155); }

				DebugLocation(289, 43);
				PushFollow(Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn1769);
				assignmentExpressionNoIn322=assignmentExpressionNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn322.Tree, assignmentExpressionNoIn322, retval);
				DebugLocation(289, 70);
				// JavaScript.g:289:70: ( LT )*
				try { DebugEnterSubRule(156);
				while (true)
				{
					int alt156=2;
					try { DebugEnterDecision(156, decisionCanBacktrack[156]);
					int LA156_0 = input.LA(1);

					if ((LA156_0==LT))
					{
						alt156=1;
					}


					} finally { DebugExitDecision(156); }
					switch ( alt156 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(289, 70);
						LT323=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpressionNoIn1771), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop156;
					}
				}

				loop156:
					;

				} finally { DebugExitSubRule(156); }

				DebugLocation(289, 73);
				char_literal324=(IToken)Match(input,60,Follow._60_in_conditionalExpressionNoIn1775); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal324_tree = (object)adaptor.Create(char_literal324, retval);
				adaptor.AddChild(root_0, char_literal324_tree);
				}
				DebugLocation(289, 79);
				// JavaScript.g:289:79: ( LT )*
				try { DebugEnterSubRule(157);
				while (true)
				{
					int alt157=2;
					try { DebugEnterDecision(157, decisionCanBacktrack[157]);
					int LA157_0 = input.LA(1);

					if ((LA157_0==LT))
					{
						alt157=1;
					}


					} finally { DebugExitDecision(157); }
					switch ( alt157 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(289, 79);
						LT325=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_conditionalExpressionNoIn1777), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop157;
					}
				}

				loop157:
					;

				} finally { DebugExitSubRule(157); }

				DebugLocation(289, 82);
				PushFollow(Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn1781);
				assignmentExpressionNoIn326=assignmentExpressionNoIn();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn326.Tree, assignmentExpressionNoIn326, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(158); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("conditionalExpressionNoIn", 57);
			LeaveRule("conditionalExpressionNoIn", 57);
			Leave_conditionalExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 57, conditionalExpressionNoIn_StartIndex); }
		}
		DebugLocation(290, 1);
		} finally { DebugExitRule(GrammarFileName, "conditionalExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "conditionalExpressionNoIn"

	public class logicalORExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalORExpression();
	partial void Leave_logicalORExpression();

	// $ANTLR start "logicalORExpression"
	// JavaScript.g:292:1: logicalORExpression : logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )* ;
	[GrammarRule("logicalORExpression")]
	public JavaScriptParser.logicalORExpression_return logicalORExpression()
	{
		Enter_logicalORExpression();
		EnterRule("logicalORExpression", 58);
		TraceIn("logicalORExpression", 58);
		JavaScriptParser.logicalORExpression_return retval = new JavaScriptParser.logicalORExpression_return();
		retval.Start = (IToken)input.LT(1);
		int logicalORExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT328=null;
		IToken string_literal329=null;
		IToken LT330=null;
		JavaScriptParser.logicalANDExpression_return logicalANDExpression327 = default(JavaScriptParser.logicalANDExpression_return);
		JavaScriptParser.logicalANDExpression_return logicalANDExpression331 = default(JavaScriptParser.logicalANDExpression_return);

		object LT328_tree=null;
		object string_literal329_tree=null;
		object LT330_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalORExpression");
		DebugLocation(292, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 58)) { return retval; }
			// JavaScript.g:293:2: ( logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:293:4: logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(293, 4);
			PushFollow(Follow._logicalANDExpression_in_logicalORExpression1794);
			logicalANDExpression327=logicalANDExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpression327.Tree, logicalANDExpression327, retval);
			DebugLocation(293, 25);
			// JavaScript.g:293:25: ( ( LT )* '||' ( LT )* logicalANDExpression )*
			try { DebugEnterSubRule(161);
			while (true)
			{
				int alt161=2;
				try { DebugEnterDecision(161, decisionCanBacktrack[161]);
				try
				{
					alt161 = dfa161.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(161); }
				switch ( alt161 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:293:26: ( LT )* '||' ( LT )* logicalANDExpression
					{
					DebugLocation(293, 28);
					// JavaScript.g:293:28: ( LT )*
					try { DebugEnterSubRule(159);
					while (true)
					{
						int alt159=2;
						try { DebugEnterDecision(159, decisionCanBacktrack[159]);
						int LA159_0 = input.LA(1);

						if ((LA159_0==LT))
						{
							alt159=1;
						}


						} finally { DebugExitDecision(159); }
						switch ( alt159 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(293, 28);
							LT328=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalORExpression1797), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop159;
						}
					}

					loop159:
						;

					} finally { DebugExitSubRule(159); }

					DebugLocation(293, 31);
					string_literal329=(IToken)Match(input,83,Follow._83_in_logicalORExpression1801); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal329_tree = (object)adaptor.Create(string_literal329, retval);
					adaptor.AddChild(root_0, string_literal329_tree);
					}
					DebugLocation(293, 38);
					// JavaScript.g:293:38: ( LT )*
					try { DebugEnterSubRule(160);
					while (true)
					{
						int alt160=2;
						try { DebugEnterDecision(160, decisionCanBacktrack[160]);
						int LA160_0 = input.LA(1);

						if ((LA160_0==LT))
						{
							alt160=1;
						}


						} finally { DebugExitDecision(160); }
						switch ( alt160 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(293, 38);
							LT330=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalORExpression1803), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop160;
						}
					}

					loop160:
						;

					} finally { DebugExitSubRule(160); }

					DebugLocation(293, 41);
					PushFollow(Follow._logicalANDExpression_in_logicalORExpression1807);
					logicalANDExpression331=logicalANDExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpression331.Tree, logicalANDExpression331, retval);

					}
					break;

				default:
					goto loop161;
				}
			}

			loop161:
				;

			} finally { DebugExitSubRule(161); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalORExpression", 58);
			LeaveRule("logicalORExpression", 58);
			Leave_logicalORExpression();
			if (state.backtracking > 0) { Memoize(input, 58, logicalORExpression_StartIndex); }
		}
		DebugLocation(294, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalORExpression"); }
		return retval;

	}
	// $ANTLR end "logicalORExpression"

	public class logicalORExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalORExpressionNoIn();
	partial void Leave_logicalORExpressionNoIn();

	// $ANTLR start "logicalORExpressionNoIn"
	// JavaScript.g:296:1: logicalORExpressionNoIn : logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )* ;
	[GrammarRule("logicalORExpressionNoIn")]
	public JavaScriptParser.logicalORExpressionNoIn_return logicalORExpressionNoIn()
	{
		Enter_logicalORExpressionNoIn();
		EnterRule("logicalORExpressionNoIn", 59);
		TraceIn("logicalORExpressionNoIn", 59);
		JavaScriptParser.logicalORExpressionNoIn_return retval = new JavaScriptParser.logicalORExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int logicalORExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT333=null;
		IToken string_literal334=null;
		IToken LT335=null;
		JavaScriptParser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn332 = default(JavaScriptParser.logicalANDExpressionNoIn_return);
		JavaScriptParser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn336 = default(JavaScriptParser.logicalANDExpressionNoIn_return);

		object LT333_tree=null;
		object string_literal334_tree=null;
		object LT335_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalORExpressionNoIn");
		DebugLocation(296, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 59)) { return retval; }
			// JavaScript.g:297:2: ( logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:297:4: logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(297, 4);
			PushFollow(Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn1821);
			logicalANDExpressionNoIn332=logicalANDExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpressionNoIn332.Tree, logicalANDExpressionNoIn332, retval);
			DebugLocation(297, 29);
			// JavaScript.g:297:29: ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*
			try { DebugEnterSubRule(164);
			while (true)
			{
				int alt164=2;
				try { DebugEnterDecision(164, decisionCanBacktrack[164]);
				try
				{
					alt164 = dfa164.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(164); }
				switch ( alt164 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:297:30: ( LT )* '||' ( LT )* logicalANDExpressionNoIn
					{
					DebugLocation(297, 32);
					// JavaScript.g:297:32: ( LT )*
					try { DebugEnterSubRule(162);
					while (true)
					{
						int alt162=2;
						try { DebugEnterDecision(162, decisionCanBacktrack[162]);
						int LA162_0 = input.LA(1);

						if ((LA162_0==LT))
						{
							alt162=1;
						}


						} finally { DebugExitDecision(162); }
						switch ( alt162 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(297, 32);
							LT333=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalORExpressionNoIn1824), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop162;
						}
					}

					loop162:
						;

					} finally { DebugExitSubRule(162); }

					DebugLocation(297, 35);
					string_literal334=(IToken)Match(input,83,Follow._83_in_logicalORExpressionNoIn1828); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal334_tree = (object)adaptor.Create(string_literal334, retval);
					adaptor.AddChild(root_0, string_literal334_tree);
					}
					DebugLocation(297, 42);
					// JavaScript.g:297:42: ( LT )*
					try { DebugEnterSubRule(163);
					while (true)
					{
						int alt163=2;
						try { DebugEnterDecision(163, decisionCanBacktrack[163]);
						int LA163_0 = input.LA(1);

						if ((LA163_0==LT))
						{
							alt163=1;
						}


						} finally { DebugExitDecision(163); }
						switch ( alt163 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(297, 42);
							LT335=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalORExpressionNoIn1830), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop163;
						}
					}

					loop163:
						;

					} finally { DebugExitSubRule(163); }

					DebugLocation(297, 45);
					PushFollow(Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn1834);
					logicalANDExpressionNoIn336=logicalANDExpressionNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpressionNoIn336.Tree, logicalANDExpressionNoIn336, retval);

					}
					break;

				default:
					goto loop164;
				}
			}

			loop164:
				;

			} finally { DebugExitSubRule(164); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalORExpressionNoIn", 59);
			LeaveRule("logicalORExpressionNoIn", 59);
			Leave_logicalORExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 59, logicalORExpressionNoIn_StartIndex); }
		}
		DebugLocation(298, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalORExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "logicalORExpressionNoIn"

	public class logicalANDExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalANDExpression();
	partial void Leave_logicalANDExpression();

	// $ANTLR start "logicalANDExpression"
	// JavaScript.g:300:1: logicalANDExpression : bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )* ;
	[GrammarRule("logicalANDExpression")]
	public JavaScriptParser.logicalANDExpression_return logicalANDExpression()
	{
		Enter_logicalANDExpression();
		EnterRule("logicalANDExpression", 60);
		TraceIn("logicalANDExpression", 60);
		JavaScriptParser.logicalANDExpression_return retval = new JavaScriptParser.logicalANDExpression_return();
		retval.Start = (IToken)input.LT(1);
		int logicalANDExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT338=null;
		IToken string_literal339=null;
		IToken LT340=null;
		JavaScriptParser.bitwiseORExpression_return bitwiseORExpression337 = default(JavaScriptParser.bitwiseORExpression_return);
		JavaScriptParser.bitwiseORExpression_return bitwiseORExpression341 = default(JavaScriptParser.bitwiseORExpression_return);

		object LT338_tree=null;
		object string_literal339_tree=null;
		object LT340_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalANDExpression");
		DebugLocation(300, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 60)) { return retval; }
			// JavaScript.g:301:2: ( bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:301:4: bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(301, 4);
			PushFollow(Follow._bitwiseORExpression_in_logicalANDExpression1848);
			bitwiseORExpression337=bitwiseORExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpression337.Tree, bitwiseORExpression337, retval);
			DebugLocation(301, 24);
			// JavaScript.g:301:24: ( ( LT )* '&&' ( LT )* bitwiseORExpression )*
			try { DebugEnterSubRule(167);
			while (true)
			{
				int alt167=2;
				try { DebugEnterDecision(167, decisionCanBacktrack[167]);
				try
				{
					alt167 = dfa167.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(167); }
				switch ( alt167 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:301:25: ( LT )* '&&' ( LT )* bitwiseORExpression
					{
					DebugLocation(301, 27);
					// JavaScript.g:301:27: ( LT )*
					try { DebugEnterSubRule(165);
					while (true)
					{
						int alt165=2;
						try { DebugEnterDecision(165, decisionCanBacktrack[165]);
						int LA165_0 = input.LA(1);

						if ((LA165_0==LT))
						{
							alt165=1;
						}


						} finally { DebugExitDecision(165); }
						switch ( alt165 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(301, 27);
							LT338=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalANDExpression1851), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop165;
						}
					}

					loop165:
						;

					} finally { DebugExitSubRule(165); }

					DebugLocation(301, 30);
					string_literal339=(IToken)Match(input,84,Follow._84_in_logicalANDExpression1855); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal339_tree = (object)adaptor.Create(string_literal339, retval);
					adaptor.AddChild(root_0, string_literal339_tree);
					}
					DebugLocation(301, 37);
					// JavaScript.g:301:37: ( LT )*
					try { DebugEnterSubRule(166);
					while (true)
					{
						int alt166=2;
						try { DebugEnterDecision(166, decisionCanBacktrack[166]);
						int LA166_0 = input.LA(1);

						if ((LA166_0==LT))
						{
							alt166=1;
						}


						} finally { DebugExitDecision(166); }
						switch ( alt166 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(301, 37);
							LT340=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalANDExpression1857), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop166;
						}
					}

					loop166:
						;

					} finally { DebugExitSubRule(166); }

					DebugLocation(301, 40);
					PushFollow(Follow._bitwiseORExpression_in_logicalANDExpression1861);
					bitwiseORExpression341=bitwiseORExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpression341.Tree, bitwiseORExpression341, retval);

					}
					break;

				default:
					goto loop167;
				}
			}

			loop167:
				;

			} finally { DebugExitSubRule(167); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalANDExpression", 60);
			LeaveRule("logicalANDExpression", 60);
			Leave_logicalANDExpression();
			if (state.backtracking > 0) { Memoize(input, 60, logicalANDExpression_StartIndex); }
		}
		DebugLocation(302, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalANDExpression"); }
		return retval;

	}
	// $ANTLR end "logicalANDExpression"

	public class logicalANDExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logicalANDExpressionNoIn();
	partial void Leave_logicalANDExpressionNoIn();

	// $ANTLR start "logicalANDExpressionNoIn"
	// JavaScript.g:304:1: logicalANDExpressionNoIn : bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )* ;
	[GrammarRule("logicalANDExpressionNoIn")]
	public JavaScriptParser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn()
	{
		Enter_logicalANDExpressionNoIn();
		EnterRule("logicalANDExpressionNoIn", 61);
		TraceIn("logicalANDExpressionNoIn", 61);
		JavaScriptParser.logicalANDExpressionNoIn_return retval = new JavaScriptParser.logicalANDExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int logicalANDExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT343=null;
		IToken string_literal344=null;
		IToken LT345=null;
		JavaScriptParser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn342 = default(JavaScriptParser.bitwiseORExpressionNoIn_return);
		JavaScriptParser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn346 = default(JavaScriptParser.bitwiseORExpressionNoIn_return);

		object LT343_tree=null;
		object string_literal344_tree=null;
		object LT345_tree=null;

		try { DebugEnterRule(GrammarFileName, "logicalANDExpressionNoIn");
		DebugLocation(304, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 61)) { return retval; }
			// JavaScript.g:305:2: ( bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:305:4: bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(305, 4);
			PushFollow(Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1875);
			bitwiseORExpressionNoIn342=bitwiseORExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpressionNoIn342.Tree, bitwiseORExpressionNoIn342, retval);
			DebugLocation(305, 28);
			// JavaScript.g:305:28: ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*
			try { DebugEnterSubRule(170);
			while (true)
			{
				int alt170=2;
				try { DebugEnterDecision(170, decisionCanBacktrack[170]);
				try
				{
					alt170 = dfa170.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(170); }
				switch ( alt170 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:305:29: ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn
					{
					DebugLocation(305, 31);
					// JavaScript.g:305:31: ( LT )*
					try { DebugEnterSubRule(168);
					while (true)
					{
						int alt168=2;
						try { DebugEnterDecision(168, decisionCanBacktrack[168]);
						int LA168_0 = input.LA(1);

						if ((LA168_0==LT))
						{
							alt168=1;
						}


						} finally { DebugExitDecision(168); }
						switch ( alt168 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(305, 31);
							LT343=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalANDExpressionNoIn1878), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop168;
						}
					}

					loop168:
						;

					} finally { DebugExitSubRule(168); }

					DebugLocation(305, 34);
					string_literal344=(IToken)Match(input,84,Follow._84_in_logicalANDExpressionNoIn1882); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal344_tree = (object)adaptor.Create(string_literal344, retval);
					adaptor.AddChild(root_0, string_literal344_tree);
					}
					DebugLocation(305, 41);
					// JavaScript.g:305:41: ( LT )*
					try { DebugEnterSubRule(169);
					while (true)
					{
						int alt169=2;
						try { DebugEnterDecision(169, decisionCanBacktrack[169]);
						int LA169_0 = input.LA(1);

						if ((LA169_0==LT))
						{
							alt169=1;
						}


						} finally { DebugExitDecision(169); }
						switch ( alt169 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(305, 41);
							LT345=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_logicalANDExpressionNoIn1884), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop169;
						}
					}

					loop169:
						;

					} finally { DebugExitSubRule(169); }

					DebugLocation(305, 44);
					PushFollow(Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1888);
					bitwiseORExpressionNoIn346=bitwiseORExpressionNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpressionNoIn346.Tree, bitwiseORExpressionNoIn346, retval);

					}
					break;

				default:
					goto loop170;
				}
			}

			loop170:
				;

			} finally { DebugExitSubRule(170); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("logicalANDExpressionNoIn", 61);
			LeaveRule("logicalANDExpressionNoIn", 61);
			Leave_logicalANDExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 61, logicalANDExpressionNoIn_StartIndex); }
		}
		DebugLocation(306, 1);
		} finally { DebugExitRule(GrammarFileName, "logicalANDExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "logicalANDExpressionNoIn"

	public class bitwiseORExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseORExpression();
	partial void Leave_bitwiseORExpression();

	// $ANTLR start "bitwiseORExpression"
	// JavaScript.g:308:1: bitwiseORExpression : bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )* ;
	[GrammarRule("bitwiseORExpression")]
	public JavaScriptParser.bitwiseORExpression_return bitwiseORExpression()
	{
		Enter_bitwiseORExpression();
		EnterRule("bitwiseORExpression", 62);
		TraceIn("bitwiseORExpression", 62);
		JavaScriptParser.bitwiseORExpression_return retval = new JavaScriptParser.bitwiseORExpression_return();
		retval.Start = (IToken)input.LT(1);
		int bitwiseORExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT348=null;
		IToken char_literal349=null;
		IToken LT350=null;
		JavaScriptParser.bitwiseXORExpression_return bitwiseXORExpression347 = default(JavaScriptParser.bitwiseXORExpression_return);
		JavaScriptParser.bitwiseXORExpression_return bitwiseXORExpression351 = default(JavaScriptParser.bitwiseXORExpression_return);

		object LT348_tree=null;
		object char_literal349_tree=null;
		object LT350_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseORExpression");
		DebugLocation(308, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 62)) { return retval; }
			// JavaScript.g:309:2: ( bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:309:4: bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(309, 4);
			PushFollow(Follow._bitwiseXORExpression_in_bitwiseORExpression1902);
			bitwiseXORExpression347=bitwiseXORExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpression347.Tree, bitwiseXORExpression347, retval);
			DebugLocation(309, 25);
			// JavaScript.g:309:25: ( ( LT )* '|' ( LT )* bitwiseXORExpression )*
			try { DebugEnterSubRule(173);
			while (true)
			{
				int alt173=2;
				try { DebugEnterDecision(173, decisionCanBacktrack[173]);
				try
				{
					alt173 = dfa173.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(173); }
				switch ( alt173 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:309:26: ( LT )* '|' ( LT )* bitwiseXORExpression
					{
					DebugLocation(309, 28);
					// JavaScript.g:309:28: ( LT )*
					try { DebugEnterSubRule(171);
					while (true)
					{
						int alt171=2;
						try { DebugEnterDecision(171, decisionCanBacktrack[171]);
						int LA171_0 = input.LA(1);

						if ((LA171_0==LT))
						{
							alt171=1;
						}


						} finally { DebugExitDecision(171); }
						switch ( alt171 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(309, 28);
							LT348=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseORExpression1905), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop171;
						}
					}

					loop171:
						;

					} finally { DebugExitSubRule(171); }

					DebugLocation(309, 31);
					char_literal349=(IToken)Match(input,85,Follow._85_in_bitwiseORExpression1909); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal349_tree = (object)adaptor.Create(char_literal349, retval);
					adaptor.AddChild(root_0, char_literal349_tree);
					}
					DebugLocation(309, 37);
					// JavaScript.g:309:37: ( LT )*
					try { DebugEnterSubRule(172);
					while (true)
					{
						int alt172=2;
						try { DebugEnterDecision(172, decisionCanBacktrack[172]);
						int LA172_0 = input.LA(1);

						if ((LA172_0==LT))
						{
							alt172=1;
						}


						} finally { DebugExitDecision(172); }
						switch ( alt172 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(309, 37);
							LT350=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseORExpression1911), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop172;
						}
					}

					loop172:
						;

					} finally { DebugExitSubRule(172); }

					DebugLocation(309, 40);
					PushFollow(Follow._bitwiseXORExpression_in_bitwiseORExpression1915);
					bitwiseXORExpression351=bitwiseXORExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpression351.Tree, bitwiseXORExpression351, retval);

					}
					break;

				default:
					goto loop173;
				}
			}

			loop173:
				;

			} finally { DebugExitSubRule(173); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseORExpression", 62);
			LeaveRule("bitwiseORExpression", 62);
			Leave_bitwiseORExpression();
			if (state.backtracking > 0) { Memoize(input, 62, bitwiseORExpression_StartIndex); }
		}
		DebugLocation(310, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseORExpression"); }
		return retval;

	}
	// $ANTLR end "bitwiseORExpression"

	public class bitwiseORExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseORExpressionNoIn();
	partial void Leave_bitwiseORExpressionNoIn();

	// $ANTLR start "bitwiseORExpressionNoIn"
	// JavaScript.g:312:1: bitwiseORExpressionNoIn : bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )* ;
	[GrammarRule("bitwiseORExpressionNoIn")]
	public JavaScriptParser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn()
	{
		Enter_bitwiseORExpressionNoIn();
		EnterRule("bitwiseORExpressionNoIn", 63);
		TraceIn("bitwiseORExpressionNoIn", 63);
		JavaScriptParser.bitwiseORExpressionNoIn_return retval = new JavaScriptParser.bitwiseORExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int bitwiseORExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT353=null;
		IToken char_literal354=null;
		IToken LT355=null;
		JavaScriptParser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn352 = default(JavaScriptParser.bitwiseXORExpressionNoIn_return);
		JavaScriptParser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn356 = default(JavaScriptParser.bitwiseXORExpressionNoIn_return);

		object LT353_tree=null;
		object char_literal354_tree=null;
		object LT355_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseORExpressionNoIn");
		DebugLocation(312, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 63)) { return retval; }
			// JavaScript.g:313:2: ( bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:313:4: bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(313, 4);
			PushFollow(Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1929);
			bitwiseXORExpressionNoIn352=bitwiseXORExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpressionNoIn352.Tree, bitwiseXORExpressionNoIn352, retval);
			DebugLocation(313, 29);
			// JavaScript.g:313:29: ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*
			try { DebugEnterSubRule(176);
			while (true)
			{
				int alt176=2;
				try { DebugEnterDecision(176, decisionCanBacktrack[176]);
				try
				{
					alt176 = dfa176.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(176); }
				switch ( alt176 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:313:30: ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn
					{
					DebugLocation(313, 32);
					// JavaScript.g:313:32: ( LT )*
					try { DebugEnterSubRule(174);
					while (true)
					{
						int alt174=2;
						try { DebugEnterDecision(174, decisionCanBacktrack[174]);
						int LA174_0 = input.LA(1);

						if ((LA174_0==LT))
						{
							alt174=1;
						}


						} finally { DebugExitDecision(174); }
						switch ( alt174 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(313, 32);
							LT353=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseORExpressionNoIn1932), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop174;
						}
					}

					loop174:
						;

					} finally { DebugExitSubRule(174); }

					DebugLocation(313, 35);
					char_literal354=(IToken)Match(input,85,Follow._85_in_bitwiseORExpressionNoIn1936); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal354_tree = (object)adaptor.Create(char_literal354, retval);
					adaptor.AddChild(root_0, char_literal354_tree);
					}
					DebugLocation(313, 41);
					// JavaScript.g:313:41: ( LT )*
					try { DebugEnterSubRule(175);
					while (true)
					{
						int alt175=2;
						try { DebugEnterDecision(175, decisionCanBacktrack[175]);
						int LA175_0 = input.LA(1);

						if ((LA175_0==LT))
						{
							alt175=1;
						}


						} finally { DebugExitDecision(175); }
						switch ( alt175 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(313, 41);
							LT355=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseORExpressionNoIn1938), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop175;
						}
					}

					loop175:
						;

					} finally { DebugExitSubRule(175); }

					DebugLocation(313, 44);
					PushFollow(Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1942);
					bitwiseXORExpressionNoIn356=bitwiseXORExpressionNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpressionNoIn356.Tree, bitwiseXORExpressionNoIn356, retval);

					}
					break;

				default:
					goto loop176;
				}
			}

			loop176:
				;

			} finally { DebugExitSubRule(176); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseORExpressionNoIn", 63);
			LeaveRule("bitwiseORExpressionNoIn", 63);
			Leave_bitwiseORExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 63, bitwiseORExpressionNoIn_StartIndex); }
		}
		DebugLocation(314, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseORExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "bitwiseORExpressionNoIn"

	public class bitwiseXORExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseXORExpression();
	partial void Leave_bitwiseXORExpression();

	// $ANTLR start "bitwiseXORExpression"
	// JavaScript.g:316:1: bitwiseXORExpression : bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )* ;
	[GrammarRule("bitwiseXORExpression")]
	public JavaScriptParser.bitwiseXORExpression_return bitwiseXORExpression()
	{
		Enter_bitwiseXORExpression();
		EnterRule("bitwiseXORExpression", 64);
		TraceIn("bitwiseXORExpression", 64);
		JavaScriptParser.bitwiseXORExpression_return retval = new JavaScriptParser.bitwiseXORExpression_return();
		retval.Start = (IToken)input.LT(1);
		int bitwiseXORExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT358=null;
		IToken char_literal359=null;
		IToken LT360=null;
		JavaScriptParser.bitwiseANDExpression_return bitwiseANDExpression357 = default(JavaScriptParser.bitwiseANDExpression_return);
		JavaScriptParser.bitwiseANDExpression_return bitwiseANDExpression361 = default(JavaScriptParser.bitwiseANDExpression_return);

		object LT358_tree=null;
		object char_literal359_tree=null;
		object LT360_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseXORExpression");
		DebugLocation(316, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 64)) { return retval; }
			// JavaScript.g:317:2: ( bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:317:4: bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(317, 4);
			PushFollow(Follow._bitwiseANDExpression_in_bitwiseXORExpression1956);
			bitwiseANDExpression357=bitwiseANDExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpression357.Tree, bitwiseANDExpression357, retval);
			DebugLocation(317, 25);
			// JavaScript.g:317:25: ( ( LT )* '^' ( LT )* bitwiseANDExpression )*
			try { DebugEnterSubRule(179);
			while (true)
			{
				int alt179=2;
				try { DebugEnterDecision(179, decisionCanBacktrack[179]);
				try
				{
					alt179 = dfa179.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(179); }
				switch ( alt179 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:317:26: ( LT )* '^' ( LT )* bitwiseANDExpression
					{
					DebugLocation(317, 28);
					// JavaScript.g:317:28: ( LT )*
					try { DebugEnterSubRule(177);
					while (true)
					{
						int alt177=2;
						try { DebugEnterDecision(177, decisionCanBacktrack[177]);
						int LA177_0 = input.LA(1);

						if ((LA177_0==LT))
						{
							alt177=1;
						}


						} finally { DebugExitDecision(177); }
						switch ( alt177 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(317, 28);
							LT358=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseXORExpression1959), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop177;
						}
					}

					loop177:
						;

					} finally { DebugExitSubRule(177); }

					DebugLocation(317, 31);
					char_literal359=(IToken)Match(input,86,Follow._86_in_bitwiseXORExpression1963); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal359_tree = (object)adaptor.Create(char_literal359, retval);
					adaptor.AddChild(root_0, char_literal359_tree);
					}
					DebugLocation(317, 37);
					// JavaScript.g:317:37: ( LT )*
					try { DebugEnterSubRule(178);
					while (true)
					{
						int alt178=2;
						try { DebugEnterDecision(178, decisionCanBacktrack[178]);
						int LA178_0 = input.LA(1);

						if ((LA178_0==LT))
						{
							alt178=1;
						}


						} finally { DebugExitDecision(178); }
						switch ( alt178 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(317, 37);
							LT360=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseXORExpression1965), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop178;
						}
					}

					loop178:
						;

					} finally { DebugExitSubRule(178); }

					DebugLocation(317, 40);
					PushFollow(Follow._bitwiseANDExpression_in_bitwiseXORExpression1969);
					bitwiseANDExpression361=bitwiseANDExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpression361.Tree, bitwiseANDExpression361, retval);

					}
					break;

				default:
					goto loop179;
				}
			}

			loop179:
				;

			} finally { DebugExitSubRule(179); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseXORExpression", 64);
			LeaveRule("bitwiseXORExpression", 64);
			Leave_bitwiseXORExpression();
			if (state.backtracking > 0) { Memoize(input, 64, bitwiseXORExpression_StartIndex); }
		}
		DebugLocation(318, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseXORExpression"); }
		return retval;

	}
	// $ANTLR end "bitwiseXORExpression"

	public class bitwiseXORExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseXORExpressionNoIn();
	partial void Leave_bitwiseXORExpressionNoIn();

	// $ANTLR start "bitwiseXORExpressionNoIn"
	// JavaScript.g:320:1: bitwiseXORExpressionNoIn : bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )* ;
	[GrammarRule("bitwiseXORExpressionNoIn")]
	public JavaScriptParser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn()
	{
		Enter_bitwiseXORExpressionNoIn();
		EnterRule("bitwiseXORExpressionNoIn", 65);
		TraceIn("bitwiseXORExpressionNoIn", 65);
		JavaScriptParser.bitwiseXORExpressionNoIn_return retval = new JavaScriptParser.bitwiseXORExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int bitwiseXORExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT363=null;
		IToken char_literal364=null;
		IToken LT365=null;
		JavaScriptParser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn362 = default(JavaScriptParser.bitwiseANDExpressionNoIn_return);
		JavaScriptParser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn366 = default(JavaScriptParser.bitwiseANDExpressionNoIn_return);

		object LT363_tree=null;
		object char_literal364_tree=null;
		object LT365_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseXORExpressionNoIn");
		DebugLocation(320, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 65)) { return retval; }
			// JavaScript.g:321:2: ( bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:321:4: bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(321, 4);
			PushFollow(Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1983);
			bitwiseANDExpressionNoIn362=bitwiseANDExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpressionNoIn362.Tree, bitwiseANDExpressionNoIn362, retval);
			DebugLocation(321, 29);
			// JavaScript.g:321:29: ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*
			try { DebugEnterSubRule(182);
			while (true)
			{
				int alt182=2;
				try { DebugEnterDecision(182, decisionCanBacktrack[182]);
				try
				{
					alt182 = dfa182.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(182); }
				switch ( alt182 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:321:30: ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn
					{
					DebugLocation(321, 32);
					// JavaScript.g:321:32: ( LT )*
					try { DebugEnterSubRule(180);
					while (true)
					{
						int alt180=2;
						try { DebugEnterDecision(180, decisionCanBacktrack[180]);
						int LA180_0 = input.LA(1);

						if ((LA180_0==LT))
						{
							alt180=1;
						}


						} finally { DebugExitDecision(180); }
						switch ( alt180 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(321, 32);
							LT363=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseXORExpressionNoIn1986), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop180;
						}
					}

					loop180:
						;

					} finally { DebugExitSubRule(180); }

					DebugLocation(321, 35);
					char_literal364=(IToken)Match(input,86,Follow._86_in_bitwiseXORExpressionNoIn1990); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal364_tree = (object)adaptor.Create(char_literal364, retval);
					adaptor.AddChild(root_0, char_literal364_tree);
					}
					DebugLocation(321, 41);
					// JavaScript.g:321:41: ( LT )*
					try { DebugEnterSubRule(181);
					while (true)
					{
						int alt181=2;
						try { DebugEnterDecision(181, decisionCanBacktrack[181]);
						int LA181_0 = input.LA(1);

						if ((LA181_0==LT))
						{
							alt181=1;
						}


						} finally { DebugExitDecision(181); }
						switch ( alt181 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(321, 41);
							LT365=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseXORExpressionNoIn1992), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop181;
						}
					}

					loop181:
						;

					} finally { DebugExitSubRule(181); }

					DebugLocation(321, 44);
					PushFollow(Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1996);
					bitwiseANDExpressionNoIn366=bitwiseANDExpressionNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpressionNoIn366.Tree, bitwiseANDExpressionNoIn366, retval);

					}
					break;

				default:
					goto loop182;
				}
			}

			loop182:
				;

			} finally { DebugExitSubRule(182); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseXORExpressionNoIn", 65);
			LeaveRule("bitwiseXORExpressionNoIn", 65);
			Leave_bitwiseXORExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 65, bitwiseXORExpressionNoIn_StartIndex); }
		}
		DebugLocation(322, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseXORExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "bitwiseXORExpressionNoIn"

	public class bitwiseANDExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseANDExpression();
	partial void Leave_bitwiseANDExpression();

	// $ANTLR start "bitwiseANDExpression"
	// JavaScript.g:324:1: bitwiseANDExpression : equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )* ;
	[GrammarRule("bitwiseANDExpression")]
	public JavaScriptParser.bitwiseANDExpression_return bitwiseANDExpression()
	{
		Enter_bitwiseANDExpression();
		EnterRule("bitwiseANDExpression", 66);
		TraceIn("bitwiseANDExpression", 66);
		JavaScriptParser.bitwiseANDExpression_return retval = new JavaScriptParser.bitwiseANDExpression_return();
		retval.Start = (IToken)input.LT(1);
		int bitwiseANDExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT368=null;
		IToken char_literal369=null;
		IToken LT370=null;
		JavaScriptParser.equalityExpression_return equalityExpression367 = default(JavaScriptParser.equalityExpression_return);
		JavaScriptParser.equalityExpression_return equalityExpression371 = default(JavaScriptParser.equalityExpression_return);

		object LT368_tree=null;
		object char_literal369_tree=null;
		object LT370_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseANDExpression");
		DebugLocation(324, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 66)) { return retval; }
			// JavaScript.g:325:2: ( equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:325:4: equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(325, 4);
			PushFollow(Follow._equalityExpression_in_bitwiseANDExpression2010);
			equalityExpression367=equalityExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression367.Tree, equalityExpression367, retval);
			DebugLocation(325, 23);
			// JavaScript.g:325:23: ( ( LT )* '&' ( LT )* equalityExpression )*
			try { DebugEnterSubRule(185);
			while (true)
			{
				int alt185=2;
				try { DebugEnterDecision(185, decisionCanBacktrack[185]);
				try
				{
					alt185 = dfa185.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(185); }
				switch ( alt185 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:325:24: ( LT )* '&' ( LT )* equalityExpression
					{
					DebugLocation(325, 26);
					// JavaScript.g:325:26: ( LT )*
					try { DebugEnterSubRule(183);
					while (true)
					{
						int alt183=2;
						try { DebugEnterDecision(183, decisionCanBacktrack[183]);
						int LA183_0 = input.LA(1);

						if ((LA183_0==LT))
						{
							alt183=1;
						}


						} finally { DebugExitDecision(183); }
						switch ( alt183 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(325, 26);
							LT368=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseANDExpression2013), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop183;
						}
					}

					loop183:
						;

					} finally { DebugExitSubRule(183); }

					DebugLocation(325, 29);
					char_literal369=(IToken)Match(input,87,Follow._87_in_bitwiseANDExpression2017); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal369_tree = (object)adaptor.Create(char_literal369, retval);
					adaptor.AddChild(root_0, char_literal369_tree);
					}
					DebugLocation(325, 35);
					// JavaScript.g:325:35: ( LT )*
					try { DebugEnterSubRule(184);
					while (true)
					{
						int alt184=2;
						try { DebugEnterDecision(184, decisionCanBacktrack[184]);
						int LA184_0 = input.LA(1);

						if ((LA184_0==LT))
						{
							alt184=1;
						}


						} finally { DebugExitDecision(184); }
						switch ( alt184 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(325, 35);
							LT370=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseANDExpression2019), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop184;
						}
					}

					loop184:
						;

					} finally { DebugExitSubRule(184); }

					DebugLocation(325, 38);
					PushFollow(Follow._equalityExpression_in_bitwiseANDExpression2023);
					equalityExpression371=equalityExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression371.Tree, equalityExpression371, retval);

					}
					break;

				default:
					goto loop185;
				}
			}

			loop185:
				;

			} finally { DebugExitSubRule(185); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseANDExpression", 66);
			LeaveRule("bitwiseANDExpression", 66);
			Leave_bitwiseANDExpression();
			if (state.backtracking > 0) { Memoize(input, 66, bitwiseANDExpression_StartIndex); }
		}
		DebugLocation(326, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseANDExpression"); }
		return retval;

	}
	// $ANTLR end "bitwiseANDExpression"

	public class bitwiseANDExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_bitwiseANDExpressionNoIn();
	partial void Leave_bitwiseANDExpressionNoIn();

	// $ANTLR start "bitwiseANDExpressionNoIn"
	// JavaScript.g:328:1: bitwiseANDExpressionNoIn : equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )* ;
	[GrammarRule("bitwiseANDExpressionNoIn")]
	public JavaScriptParser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn()
	{
		Enter_bitwiseANDExpressionNoIn();
		EnterRule("bitwiseANDExpressionNoIn", 67);
		TraceIn("bitwiseANDExpressionNoIn", 67);
		JavaScriptParser.bitwiseANDExpressionNoIn_return retval = new JavaScriptParser.bitwiseANDExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int bitwiseANDExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT373=null;
		IToken char_literal374=null;
		IToken LT375=null;
		JavaScriptParser.equalityExpressionNoIn_return equalityExpressionNoIn372 = default(JavaScriptParser.equalityExpressionNoIn_return);
		JavaScriptParser.equalityExpressionNoIn_return equalityExpressionNoIn376 = default(JavaScriptParser.equalityExpressionNoIn_return);

		object LT373_tree=null;
		object char_literal374_tree=null;
		object LT375_tree=null;

		try { DebugEnterRule(GrammarFileName, "bitwiseANDExpressionNoIn");
		DebugLocation(328, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 67)) { return retval; }
			// JavaScript.g:329:2: ( equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:329:4: equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(329, 4);
			PushFollow(Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2037);
			equalityExpressionNoIn372=equalityExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpressionNoIn372.Tree, equalityExpressionNoIn372, retval);
			DebugLocation(329, 27);
			// JavaScript.g:329:27: ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*
			try { DebugEnterSubRule(188);
			while (true)
			{
				int alt188=2;
				try { DebugEnterDecision(188, decisionCanBacktrack[188]);
				try
				{
					alt188 = dfa188.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(188); }
				switch ( alt188 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:329:28: ( LT )* '&' ( LT )* equalityExpressionNoIn
					{
					DebugLocation(329, 30);
					// JavaScript.g:329:30: ( LT )*
					try { DebugEnterSubRule(186);
					while (true)
					{
						int alt186=2;
						try { DebugEnterDecision(186, decisionCanBacktrack[186]);
						int LA186_0 = input.LA(1);

						if ((LA186_0==LT))
						{
							alt186=1;
						}


						} finally { DebugExitDecision(186); }
						switch ( alt186 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(329, 30);
							LT373=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseANDExpressionNoIn2040), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop186;
						}
					}

					loop186:
						;

					} finally { DebugExitSubRule(186); }

					DebugLocation(329, 33);
					char_literal374=(IToken)Match(input,87,Follow._87_in_bitwiseANDExpressionNoIn2044); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal374_tree = (object)adaptor.Create(char_literal374, retval);
					adaptor.AddChild(root_0, char_literal374_tree);
					}
					DebugLocation(329, 39);
					// JavaScript.g:329:39: ( LT )*
					try { DebugEnterSubRule(187);
					while (true)
					{
						int alt187=2;
						try { DebugEnterDecision(187, decisionCanBacktrack[187]);
						int LA187_0 = input.LA(1);

						if ((LA187_0==LT))
						{
							alt187=1;
						}


						} finally { DebugExitDecision(187); }
						switch ( alt187 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(329, 39);
							LT375=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_bitwiseANDExpressionNoIn2046), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop187;
						}
					}

					loop187:
						;

					} finally { DebugExitSubRule(187); }

					DebugLocation(329, 42);
					PushFollow(Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2050);
					equalityExpressionNoIn376=equalityExpressionNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpressionNoIn376.Tree, equalityExpressionNoIn376, retval);

					}
					break;

				default:
					goto loop188;
				}
			}

			loop188:
				;

			} finally { DebugExitSubRule(188); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("bitwiseANDExpressionNoIn", 67);
			LeaveRule("bitwiseANDExpressionNoIn", 67);
			Leave_bitwiseANDExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 67, bitwiseANDExpressionNoIn_StartIndex); }
		}
		DebugLocation(330, 1);
		} finally { DebugExitRule(GrammarFileName, "bitwiseANDExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "bitwiseANDExpressionNoIn"

	public class equalityExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_equalityExpression();
	partial void Leave_equalityExpression();

	// $ANTLR start "equalityExpression"
	// JavaScript.g:332:1: equalityExpression : relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )* ;
	[GrammarRule("equalityExpression")]
	public JavaScriptParser.equalityExpression_return equalityExpression()
	{
		Enter_equalityExpression();
		EnterRule("equalityExpression", 68);
		TraceIn("equalityExpression", 68);
		JavaScriptParser.equalityExpression_return retval = new JavaScriptParser.equalityExpression_return();
		retval.Start = (IToken)input.LT(1);
		int equalityExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT378=null;
		IToken set379=null;
		IToken LT380=null;
		JavaScriptParser.relationalExpression_return relationalExpression377 = default(JavaScriptParser.relationalExpression_return);
		JavaScriptParser.relationalExpression_return relationalExpression381 = default(JavaScriptParser.relationalExpression_return);

		object LT378_tree=null;
		object set379_tree=null;
		object LT380_tree=null;

		try { DebugEnterRule(GrammarFileName, "equalityExpression");
		DebugLocation(332, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 68)) { return retval; }
			// JavaScript.g:333:2: ( relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:333:4: relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(333, 4);
			PushFollow(Follow._relationalExpression_in_equalityExpression2064);
			relationalExpression377=relationalExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpression377.Tree, relationalExpression377, retval);
			DebugLocation(333, 25);
			// JavaScript.g:333:25: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*
			try { DebugEnterSubRule(191);
			while (true)
			{
				int alt191=2;
				try { DebugEnterDecision(191, decisionCanBacktrack[191]);
				try
				{
					alt191 = dfa191.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(191); }
				switch ( alt191 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:333:26: ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression
					{
					DebugLocation(333, 28);
					// JavaScript.g:333:28: ( LT )*
					try { DebugEnterSubRule(189);
					while (true)
					{
						int alt189=2;
						try { DebugEnterDecision(189, decisionCanBacktrack[189]);
						int LA189_0 = input.LA(1);

						if ((LA189_0==LT))
						{
							alt189=1;
						}


						} finally { DebugExitDecision(189); }
						switch ( alt189 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(333, 28);
							LT378=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_equalityExpression2067), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop189;
						}
					}

					loop189:
						;

					} finally { DebugExitSubRule(189); }

					DebugLocation(333, 31);
					set379=(IToken)input.LT(1);
					if ((input.LA(1)>=88 && input.LA(1)<=91))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set379, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(333, 63);
					// JavaScript.g:333:63: ( LT )*
					try { DebugEnterSubRule(190);
					while (true)
					{
						int alt190=2;
						try { DebugEnterDecision(190, decisionCanBacktrack[190]);
						int LA190_0 = input.LA(1);

						if ((LA190_0==LT))
						{
							alt190=1;
						}


						} finally { DebugExitDecision(190); }
						switch ( alt190 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(333, 63);
							LT380=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_equalityExpression2087), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop190;
						}
					}

					loop190:
						;

					} finally { DebugExitSubRule(190); }

					DebugLocation(333, 66);
					PushFollow(Follow._relationalExpression_in_equalityExpression2091);
					relationalExpression381=relationalExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpression381.Tree, relationalExpression381, retval);

					}
					break;

				default:
					goto loop191;
				}
			}

			loop191:
				;

			} finally { DebugExitSubRule(191); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("equalityExpression", 68);
			LeaveRule("equalityExpression", 68);
			Leave_equalityExpression();
			if (state.backtracking > 0) { Memoize(input, 68, equalityExpression_StartIndex); }
		}
		DebugLocation(334, 1);
		} finally { DebugExitRule(GrammarFileName, "equalityExpression"); }
		return retval;

	}
	// $ANTLR end "equalityExpression"

	public class equalityExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_equalityExpressionNoIn();
	partial void Leave_equalityExpressionNoIn();

	// $ANTLR start "equalityExpressionNoIn"
	// JavaScript.g:336:1: equalityExpressionNoIn : relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )* ;
	[GrammarRule("equalityExpressionNoIn")]
	public JavaScriptParser.equalityExpressionNoIn_return equalityExpressionNoIn()
	{
		Enter_equalityExpressionNoIn();
		EnterRule("equalityExpressionNoIn", 69);
		TraceIn("equalityExpressionNoIn", 69);
		JavaScriptParser.equalityExpressionNoIn_return retval = new JavaScriptParser.equalityExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int equalityExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT383=null;
		IToken set384=null;
		IToken LT385=null;
		JavaScriptParser.relationalExpressionNoIn_return relationalExpressionNoIn382 = default(JavaScriptParser.relationalExpressionNoIn_return);
		JavaScriptParser.relationalExpressionNoIn_return relationalExpressionNoIn386 = default(JavaScriptParser.relationalExpressionNoIn_return);

		object LT383_tree=null;
		object set384_tree=null;
		object LT385_tree=null;

		try { DebugEnterRule(GrammarFileName, "equalityExpressionNoIn");
		DebugLocation(336, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 69)) { return retval; }
			// JavaScript.g:337:2: ( relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )* )
			DebugEnterAlt(1);
			// JavaScript.g:337:4: relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(337, 4);
			PushFollow(Follow._relationalExpressionNoIn_in_equalityExpressionNoIn2104);
			relationalExpressionNoIn382=relationalExpressionNoIn();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpressionNoIn382.Tree, relationalExpressionNoIn382, retval);
			DebugLocation(337, 29);
			// JavaScript.g:337:29: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*
			try { DebugEnterSubRule(194);
			while (true)
			{
				int alt194=2;
				try { DebugEnterDecision(194, decisionCanBacktrack[194]);
				try
				{
					alt194 = dfa194.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(194); }
				switch ( alt194 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:337:30: ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn
					{
					DebugLocation(337, 32);
					// JavaScript.g:337:32: ( LT )*
					try { DebugEnterSubRule(192);
					while (true)
					{
						int alt192=2;
						try { DebugEnterDecision(192, decisionCanBacktrack[192]);
						int LA192_0 = input.LA(1);

						if ((LA192_0==LT))
						{
							alt192=1;
						}


						} finally { DebugExitDecision(192); }
						switch ( alt192 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(337, 32);
							LT383=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_equalityExpressionNoIn2107), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop192;
						}
					}

					loop192:
						;

					} finally { DebugExitSubRule(192); }

					DebugLocation(337, 35);
					set384=(IToken)input.LT(1);
					if ((input.LA(1)>=88 && input.LA(1)<=91))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set384, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(337, 67);
					// JavaScript.g:337:67: ( LT )*
					try { DebugEnterSubRule(193);
					while (true)
					{
						int alt193=2;
						try { DebugEnterDecision(193, decisionCanBacktrack[193]);
						int LA193_0 = input.LA(1);

						if ((LA193_0==LT))
						{
							alt193=1;
						}


						} finally { DebugExitDecision(193); }
						switch ( alt193 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(337, 67);
							LT385=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_equalityExpressionNoIn2127), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop193;
						}
					}

					loop193:
						;

					} finally { DebugExitSubRule(193); }

					DebugLocation(337, 70);
					PushFollow(Follow._relationalExpressionNoIn_in_equalityExpressionNoIn2131);
					relationalExpressionNoIn386=relationalExpressionNoIn();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpressionNoIn386.Tree, relationalExpressionNoIn386, retval);

					}
					break;

				default:
					goto loop194;
				}
			}

			loop194:
				;

			} finally { DebugExitSubRule(194); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("equalityExpressionNoIn", 69);
			LeaveRule("equalityExpressionNoIn", 69);
			Leave_equalityExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 69, equalityExpressionNoIn_StartIndex); }
		}
		DebugLocation(338, 1);
		} finally { DebugExitRule(GrammarFileName, "equalityExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "equalityExpressionNoIn"

	public class relationalExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_relationalExpression();
	partial void Leave_relationalExpression();

	// $ANTLR start "relationalExpression"
	// JavaScript.g:340:1: relationalExpression : shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )* ;
	[GrammarRule("relationalExpression")]
	public JavaScriptParser.relationalExpression_return relationalExpression()
	{
		Enter_relationalExpression();
		EnterRule("relationalExpression", 70);
		TraceIn("relationalExpression", 70);
		JavaScriptParser.relationalExpression_return retval = new JavaScriptParser.relationalExpression_return();
		retval.Start = (IToken)input.LT(1);
		int relationalExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT388=null;
		IToken set389=null;
		IToken LT390=null;
		JavaScriptParser.shiftExpression_return shiftExpression387 = default(JavaScriptParser.shiftExpression_return);
		JavaScriptParser.shiftExpression_return shiftExpression391 = default(JavaScriptParser.shiftExpression_return);

		object LT388_tree=null;
		object set389_tree=null;
		object LT390_tree=null;

		try { DebugEnterRule(GrammarFileName, "relationalExpression");
		DebugLocation(340, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 70)) { return retval; }
			// JavaScript.g:341:2: ( shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:341:4: shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(341, 4);
			PushFollow(Follow._shiftExpression_in_relationalExpression2145);
			shiftExpression387=shiftExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression387.Tree, shiftExpression387, retval);
			DebugLocation(341, 20);
			// JavaScript.g:341:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*
			try { DebugEnterSubRule(197);
			while (true)
			{
				int alt197=2;
				try { DebugEnterDecision(197, decisionCanBacktrack[197]);
				try
				{
					alt197 = dfa197.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(197); }
				switch ( alt197 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:341:21: ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression
					{
					DebugLocation(341, 23);
					// JavaScript.g:341:23: ( LT )*
					try { DebugEnterSubRule(195);
					while (true)
					{
						int alt195=2;
						try { DebugEnterDecision(195, decisionCanBacktrack[195]);
						int LA195_0 = input.LA(1);

						if ((LA195_0==LT))
						{
							alt195=1;
						}


						} finally { DebugExitDecision(195); }
						switch ( alt195 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(341, 23);
							LT388=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_relationalExpression2148), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop195;
						}
					}

					loop195:
						;

					} finally { DebugExitSubRule(195); }

					DebugLocation(341, 26);
					set389=(IToken)input.LT(1);
					if (input.LA(1)==55||(input.LA(1)>=92 && input.LA(1)<=96))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set389, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(341, 76);
					// JavaScript.g:341:76: ( LT )*
					try { DebugEnterSubRule(196);
					while (true)
					{
						int alt196=2;
						try { DebugEnterDecision(196, decisionCanBacktrack[196]);
						int LA196_0 = input.LA(1);

						if ((LA196_0==LT))
						{
							alt196=1;
						}


						} finally { DebugExitDecision(196); }
						switch ( alt196 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(341, 76);
							LT390=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_relationalExpression2176), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop196;
						}
					}

					loop196:
						;

					} finally { DebugExitSubRule(196); }

					DebugLocation(341, 79);
					PushFollow(Follow._shiftExpression_in_relationalExpression2180);
					shiftExpression391=shiftExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression391.Tree, shiftExpression391, retval);

					}
					break;

				default:
					goto loop197;
				}
			}

			loop197:
				;

			} finally { DebugExitSubRule(197); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("relationalExpression", 70);
			LeaveRule("relationalExpression", 70);
			Leave_relationalExpression();
			if (state.backtracking > 0) { Memoize(input, 70, relationalExpression_StartIndex); }
		}
		DebugLocation(342, 1);
		} finally { DebugExitRule(GrammarFileName, "relationalExpression"); }
		return retval;

	}
	// $ANTLR end "relationalExpression"

	public class relationalExpressionNoIn_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_relationalExpressionNoIn();
	partial void Leave_relationalExpressionNoIn();

	// $ANTLR start "relationalExpressionNoIn"
	// JavaScript.g:344:1: relationalExpressionNoIn : shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )* ;
	[GrammarRule("relationalExpressionNoIn")]
	public JavaScriptParser.relationalExpressionNoIn_return relationalExpressionNoIn()
	{
		Enter_relationalExpressionNoIn();
		EnterRule("relationalExpressionNoIn", 71);
		TraceIn("relationalExpressionNoIn", 71);
		JavaScriptParser.relationalExpressionNoIn_return retval = new JavaScriptParser.relationalExpressionNoIn_return();
		retval.Start = (IToken)input.LT(1);
		int relationalExpressionNoIn_StartIndex = input.Index;
		object root_0 = null;

		IToken LT393=null;
		IToken set394=null;
		IToken LT395=null;
		JavaScriptParser.shiftExpression_return shiftExpression392 = default(JavaScriptParser.shiftExpression_return);
		JavaScriptParser.shiftExpression_return shiftExpression396 = default(JavaScriptParser.shiftExpression_return);

		object LT393_tree=null;
		object set394_tree=null;
		object LT395_tree=null;

		try { DebugEnterRule(GrammarFileName, "relationalExpressionNoIn");
		DebugLocation(344, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 71)) { return retval; }
			// JavaScript.g:345:2: ( shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:345:4: shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(345, 4);
			PushFollow(Follow._shiftExpression_in_relationalExpressionNoIn2193);
			shiftExpression392=shiftExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression392.Tree, shiftExpression392, retval);
			DebugLocation(345, 20);
			// JavaScript.g:345:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*
			try { DebugEnterSubRule(200);
			while (true)
			{
				int alt200=2;
				try { DebugEnterDecision(200, decisionCanBacktrack[200]);
				try
				{
					alt200 = dfa200.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(200); }
				switch ( alt200 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:345:21: ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression
					{
					DebugLocation(345, 23);
					// JavaScript.g:345:23: ( LT )*
					try { DebugEnterSubRule(198);
					while (true)
					{
						int alt198=2;
						try { DebugEnterDecision(198, decisionCanBacktrack[198]);
						int LA198_0 = input.LA(1);

						if ((LA198_0==LT))
						{
							alt198=1;
						}


						} finally { DebugExitDecision(198); }
						switch ( alt198 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(345, 23);
							LT393=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_relationalExpressionNoIn2196), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop198;
						}
					}

					loop198:
						;

					} finally { DebugExitSubRule(198); }

					DebugLocation(345, 26);
					set394=(IToken)input.LT(1);
					if ((input.LA(1)>=92 && input.LA(1)<=96))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set394, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(345, 69);
					// JavaScript.g:345:69: ( LT )*
					try { DebugEnterSubRule(199);
					while (true)
					{
						int alt199=2;
						try { DebugEnterDecision(199, decisionCanBacktrack[199]);
						int LA199_0 = input.LA(1);

						if ((LA199_0==LT))
						{
							alt199=1;
						}


						} finally { DebugExitDecision(199); }
						switch ( alt199 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(345, 69);
							LT395=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_relationalExpressionNoIn2220), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop199;
						}
					}

					loop199:
						;

					} finally { DebugExitSubRule(199); }

					DebugLocation(345, 72);
					PushFollow(Follow._shiftExpression_in_relationalExpressionNoIn2224);
					shiftExpression396=shiftExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression396.Tree, shiftExpression396, retval);

					}
					break;

				default:
					goto loop200;
				}
			}

			loop200:
				;

			} finally { DebugExitSubRule(200); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("relationalExpressionNoIn", 71);
			LeaveRule("relationalExpressionNoIn", 71);
			Leave_relationalExpressionNoIn();
			if (state.backtracking > 0) { Memoize(input, 71, relationalExpressionNoIn_StartIndex); }
		}
		DebugLocation(346, 1);
		} finally { DebugExitRule(GrammarFileName, "relationalExpressionNoIn"); }
		return retval;

	}
	// $ANTLR end "relationalExpressionNoIn"

	public class shiftExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_shiftExpression();
	partial void Leave_shiftExpression();

	// $ANTLR start "shiftExpression"
	// JavaScript.g:348:1: shiftExpression : additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )* ;
	[GrammarRule("shiftExpression")]
	public JavaScriptParser.shiftExpression_return shiftExpression()
	{
		Enter_shiftExpression();
		EnterRule("shiftExpression", 72);
		TraceIn("shiftExpression", 72);
		JavaScriptParser.shiftExpression_return retval = new JavaScriptParser.shiftExpression_return();
		retval.Start = (IToken)input.LT(1);
		int shiftExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT398=null;
		IToken set399=null;
		IToken LT400=null;
		JavaScriptParser.additiveExpression_return additiveExpression397 = default(JavaScriptParser.additiveExpression_return);
		JavaScriptParser.additiveExpression_return additiveExpression401 = default(JavaScriptParser.additiveExpression_return);

		object LT398_tree=null;
		object set399_tree=null;
		object LT400_tree=null;

		try { DebugEnterRule(GrammarFileName, "shiftExpression");
		DebugLocation(348, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 72)) { return retval; }
			// JavaScript.g:349:2: ( additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:349:4: additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(349, 4);
			PushFollow(Follow._additiveExpression_in_shiftExpression2237);
			additiveExpression397=additiveExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression397.Tree, additiveExpression397, retval);
			DebugLocation(349, 23);
			// JavaScript.g:349:23: ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*
			try { DebugEnterSubRule(203);
			while (true)
			{
				int alt203=2;
				try { DebugEnterDecision(203, decisionCanBacktrack[203]);
				try
				{
					alt203 = dfa203.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(203); }
				switch ( alt203 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:349:24: ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression
					{
					DebugLocation(349, 26);
					// JavaScript.g:349:26: ( LT )*
					try { DebugEnterSubRule(201);
					while (true)
					{
						int alt201=2;
						try { DebugEnterDecision(201, decisionCanBacktrack[201]);
						int LA201_0 = input.LA(1);

						if ((LA201_0==LT))
						{
							alt201=1;
						}


						} finally { DebugExitDecision(201); }
						switch ( alt201 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(349, 26);
							LT398=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_shiftExpression2240), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop201;
						}
					}

					loop201:
						;

					} finally { DebugExitSubRule(201); }

					DebugLocation(349, 29);
					set399=(IToken)input.LT(1);
					if ((input.LA(1)>=97 && input.LA(1)<=99))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set399, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(349, 53);
					// JavaScript.g:349:53: ( LT )*
					try { DebugEnterSubRule(202);
					while (true)
					{
						int alt202=2;
						try { DebugEnterDecision(202, decisionCanBacktrack[202]);
						int LA202_0 = input.LA(1);

						if ((LA202_0==LT))
						{
							alt202=1;
						}


						} finally { DebugExitDecision(202); }
						switch ( alt202 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(349, 53);
							LT400=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_shiftExpression2256), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop202;
						}
					}

					loop202:
						;

					} finally { DebugExitSubRule(202); }

					DebugLocation(349, 56);
					PushFollow(Follow._additiveExpression_in_shiftExpression2260);
					additiveExpression401=additiveExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression401.Tree, additiveExpression401, retval);

					}
					break;

				default:
					goto loop203;
				}
			}

			loop203:
				;

			} finally { DebugExitSubRule(203); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("shiftExpression", 72);
			LeaveRule("shiftExpression", 72);
			Leave_shiftExpression();
			if (state.backtracking > 0) { Memoize(input, 72, shiftExpression_StartIndex); }
		}
		DebugLocation(350, 1);
		} finally { DebugExitRule(GrammarFileName, "shiftExpression"); }
		return retval;

	}
	// $ANTLR end "shiftExpression"

	public class additiveExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_additiveExpression();
	partial void Leave_additiveExpression();

	// $ANTLR start "additiveExpression"
	// JavaScript.g:352:1: additiveExpression : multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )* ;
	[GrammarRule("additiveExpression")]
	public JavaScriptParser.additiveExpression_return additiveExpression()
	{
		Enter_additiveExpression();
		EnterRule("additiveExpression", 73);
		TraceIn("additiveExpression", 73);
		JavaScriptParser.additiveExpression_return retval = new JavaScriptParser.additiveExpression_return();
		retval.Start = (IToken)input.LT(1);
		int additiveExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT403=null;
		IToken set404=null;
		IToken LT405=null;
		JavaScriptParser.multiplicativeExpression_return multiplicativeExpression402 = default(JavaScriptParser.multiplicativeExpression_return);
		JavaScriptParser.multiplicativeExpression_return multiplicativeExpression406 = default(JavaScriptParser.multiplicativeExpression_return);

		object LT403_tree=null;
		object set404_tree=null;
		object LT405_tree=null;

		try { DebugEnterRule(GrammarFileName, "additiveExpression");
		DebugLocation(352, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 73)) { return retval; }
			// JavaScript.g:353:2: ( multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:353:4: multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(353, 4);
			PushFollow(Follow._multiplicativeExpression_in_additiveExpression2273);
			multiplicativeExpression402=multiplicativeExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression402.Tree, multiplicativeExpression402, retval);
			DebugLocation(353, 29);
			// JavaScript.g:353:29: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*
			try { DebugEnterSubRule(206);
			while (true)
			{
				int alt206=2;
				try { DebugEnterDecision(206, decisionCanBacktrack[206]);
				try
				{
					alt206 = dfa206.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(206); }
				switch ( alt206 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:353:30: ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression
					{
					DebugLocation(353, 32);
					// JavaScript.g:353:32: ( LT )*
					try { DebugEnterSubRule(204);
					while (true)
					{
						int alt204=2;
						try { DebugEnterDecision(204, decisionCanBacktrack[204]);
						int LA204_0 = input.LA(1);

						if ((LA204_0==LT))
						{
							alt204=1;
						}


						} finally { DebugExitDecision(204); }
						switch ( alt204 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(353, 32);
							LT403=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_additiveExpression2276), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop204;
						}
					}

					loop204:
						;

					} finally { DebugExitSubRule(204); }

					DebugLocation(353, 35);
					set404=(IToken)input.LT(1);
					if ((input.LA(1)>=100 && input.LA(1)<=101))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set404, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(353, 49);
					// JavaScript.g:353:49: ( LT )*
					try { DebugEnterSubRule(205);
					while (true)
					{
						int alt205=2;
						try { DebugEnterDecision(205, decisionCanBacktrack[205]);
						int LA205_0 = input.LA(1);

						if ((LA205_0==LT))
						{
							alt205=1;
						}


						} finally { DebugExitDecision(205); }
						switch ( alt205 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(353, 49);
							LT405=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_additiveExpression2288), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop205;
						}
					}

					loop205:
						;

					} finally { DebugExitSubRule(205); }

					DebugLocation(353, 52);
					PushFollow(Follow._multiplicativeExpression_in_additiveExpression2292);
					multiplicativeExpression406=multiplicativeExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression406.Tree, multiplicativeExpression406, retval);

					}
					break;

				default:
					goto loop206;
				}
			}

			loop206:
				;

			} finally { DebugExitSubRule(206); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("additiveExpression", 73);
			LeaveRule("additiveExpression", 73);
			Leave_additiveExpression();
			if (state.backtracking > 0) { Memoize(input, 73, additiveExpression_StartIndex); }
		}
		DebugLocation(354, 1);
		} finally { DebugExitRule(GrammarFileName, "additiveExpression"); }
		return retval;

	}
	// $ANTLR end "additiveExpression"

	public class multiplicativeExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_multiplicativeExpression();
	partial void Leave_multiplicativeExpression();

	// $ANTLR start "multiplicativeExpression"
	// JavaScript.g:356:1: multiplicativeExpression : unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )* ;
	[GrammarRule("multiplicativeExpression")]
	public JavaScriptParser.multiplicativeExpression_return multiplicativeExpression()
	{
		Enter_multiplicativeExpression();
		EnterRule("multiplicativeExpression", 74);
		TraceIn("multiplicativeExpression", 74);
		JavaScriptParser.multiplicativeExpression_return retval = new JavaScriptParser.multiplicativeExpression_return();
		retval.Start = (IToken)input.LT(1);
		int multiplicativeExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken LT408=null;
		IToken set409=null;
		IToken LT410=null;
		JavaScriptParser.unaryExpression_return unaryExpression407 = default(JavaScriptParser.unaryExpression_return);
		JavaScriptParser.unaryExpression_return unaryExpression411 = default(JavaScriptParser.unaryExpression_return);

		object LT408_tree=null;
		object set409_tree=null;
		object LT410_tree=null;

		try { DebugEnterRule(GrammarFileName, "multiplicativeExpression");
		DebugLocation(356, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 74)) { return retval; }
			// JavaScript.g:357:2: ( unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )* )
			DebugEnterAlt(1);
			// JavaScript.g:357:4: unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(357, 4);
			PushFollow(Follow._unaryExpression_in_multiplicativeExpression2305);
			unaryExpression407=unaryExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression407.Tree, unaryExpression407, retval);
			DebugLocation(357, 20);
			// JavaScript.g:357:20: ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*
			try { DebugEnterSubRule(209);
			while (true)
			{
				int alt209=2;
				try { DebugEnterDecision(209, decisionCanBacktrack[209]);
				try
				{
					alt209 = dfa209.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(209); }
				switch ( alt209 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:357:21: ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression
					{
					DebugLocation(357, 23);
					// JavaScript.g:357:23: ( LT )*
					try { DebugEnterSubRule(207);
					while (true)
					{
						int alt207=2;
						try { DebugEnterDecision(207, decisionCanBacktrack[207]);
						int LA207_0 = input.LA(1);

						if ((LA207_0==LT))
						{
							alt207=1;
						}


						} finally { DebugExitDecision(207); }
						switch ( alt207 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(357, 23);
							LT408=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_multiplicativeExpression2308), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop207;
						}
					}

					loop207:
						;

					} finally { DebugExitSubRule(207); }

					DebugLocation(357, 26);
					set409=(IToken)input.LT(1);
					if ((input.LA(1)>=102 && input.LA(1)<=104))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set409, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(357, 46);
					// JavaScript.g:357:46: ( LT )*
					try { DebugEnterSubRule(208);
					while (true)
					{
						int alt208=2;
						try { DebugEnterDecision(208, decisionCanBacktrack[208]);
						int LA208_0 = input.LA(1);

						if ((LA208_0==LT))
						{
							alt208=1;
						}


						} finally { DebugExitDecision(208); }
						switch ( alt208 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(357, 46);
							LT410=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_multiplicativeExpression2324), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop208;
						}
					}

					loop208:
						;

					} finally { DebugExitSubRule(208); }

					DebugLocation(357, 49);
					PushFollow(Follow._unaryExpression_in_multiplicativeExpression2328);
					unaryExpression411=unaryExpression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression411.Tree, unaryExpression411, retval);

					}
					break;

				default:
					goto loop209;
				}
			}

			loop209:
				;

			} finally { DebugExitSubRule(209); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("multiplicativeExpression", 74);
			LeaveRule("multiplicativeExpression", 74);
			Leave_multiplicativeExpression();
			if (state.backtracking > 0) { Memoize(input, 74, multiplicativeExpression_StartIndex); }
		}
		DebugLocation(358, 1);
		} finally { DebugExitRule(GrammarFileName, "multiplicativeExpression"); }
		return retval;

	}
	// $ANTLR end "multiplicativeExpression"

	public class unaryExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_unaryExpression();
	partial void Leave_unaryExpression();

	// $ANTLR start "unaryExpression"
	// JavaScript.g:360:1: unaryExpression : ( postfixExpression | ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression );
	[GrammarRule("unaryExpression")]
	public JavaScriptParser.unaryExpression_return unaryExpression()
	{
		Enter_unaryExpression();
		EnterRule("unaryExpression", 75);
		TraceIn("unaryExpression", 75);
		JavaScriptParser.unaryExpression_return retval = new JavaScriptParser.unaryExpression_return();
		retval.Start = (IToken)input.LT(1);
		int unaryExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken set413=null;
		JavaScriptParser.postfixExpression_return postfixExpression412 = default(JavaScriptParser.postfixExpression_return);
		JavaScriptParser.unaryExpression_return unaryExpression414 = default(JavaScriptParser.unaryExpression_return);

		object set413_tree=null;

		try { DebugEnterRule(GrammarFileName, "unaryExpression");
		DebugLocation(360, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 75)) { return retval; }
			// JavaScript.g:361:2: ( postfixExpression | ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression )
			int alt210=2;
			try { DebugEnterDecision(210, decisionCanBacktrack[210]);
			int LA210_0 = input.LA(1);

			if (((LA210_0>=NULL && LA210_0<=THIS)||(LA210_0>=Identifier && LA210_0<=RegularExpressionLiteral)||(LA210_0>=44 && LA210_0<=45)||LA210_0==47||(LA210_0>=68 && LA210_0<=69)))
			{
				alt210=1;
			}
			else if (((LA210_0>=100 && LA210_0<=101)||(LA210_0>=105 && LA210_0<=111)))
			{
				alt210=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 210, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(210); }
			switch (alt210)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:361:4: postfixExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(361, 4);
				PushFollow(Follow._postfixExpression_in_unaryExpression2341);
				postfixExpression412=postfixExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, postfixExpression412.Tree, postfixExpression412, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:362:4: ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(362, 4);
				set413=(IToken)input.LT(1);
				if ((input.LA(1)>=100 && input.LA(1)<=101)||(input.LA(1)>=105 && input.LA(1)<=111))
				{
					input.Consume();
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set413, retval));
					state.errorRecovery=false;state.failed=false;
				}
				else
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					throw mse;
				}

				DebugLocation(362, 73);
				PushFollow(Follow._unaryExpression_in_unaryExpression2382);
				unaryExpression414=unaryExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression414.Tree, unaryExpression414, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("unaryExpression", 75);
			LeaveRule("unaryExpression", 75);
			Leave_unaryExpression();
			if (state.backtracking > 0) { Memoize(input, 75, unaryExpression_StartIndex); }
		}
		DebugLocation(363, 1);
		} finally { DebugExitRule(GrammarFileName, "unaryExpression"); }
		return retval;

	}
	// $ANTLR end "unaryExpression"

	public class postfixExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_postfixExpression();
	partial void Leave_postfixExpression();

	// $ANTLR start "postfixExpression"
	// JavaScript.g:365:1: postfixExpression : leftHandSideExpression ( '++' | '--' )? ;
	[GrammarRule("postfixExpression")]
	public JavaScriptParser.postfixExpression_return postfixExpression()
	{
		Enter_postfixExpression();
		EnterRule("postfixExpression", 76);
		TraceIn("postfixExpression", 76);
		JavaScriptParser.postfixExpression_return retval = new JavaScriptParser.postfixExpression_return();
		retval.Start = (IToken)input.LT(1);
		int postfixExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken set416=null;
		JavaScriptParser.leftHandSideExpression_return leftHandSideExpression415 = default(JavaScriptParser.leftHandSideExpression_return);

		object set416_tree=null;

		try { DebugEnterRule(GrammarFileName, "postfixExpression");
		DebugLocation(365, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 76)) { return retval; }
			// JavaScript.g:366:2: ( leftHandSideExpression ( '++' | '--' )? )
			DebugEnterAlt(1);
			// JavaScript.g:366:4: leftHandSideExpression ( '++' | '--' )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(366, 4);
			PushFollow(Follow._leftHandSideExpression_in_postfixExpression2394);
			leftHandSideExpression415=leftHandSideExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression415.Tree, leftHandSideExpression415, retval);
			DebugLocation(366, 27);
			// JavaScript.g:366:27: ( '++' | '--' )?
			int alt211=2;
			try { DebugEnterSubRule(211);
			try { DebugEnterDecision(211, decisionCanBacktrack[211]);
			try
			{
				alt211 = dfa211.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(211); }
			switch (alt211)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:
				{
				DebugLocation(366, 27);
				set416=(IToken)input.LT(1);
				if ((input.LA(1)>=108 && input.LA(1)<=109))
				{
					input.Consume();
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set416, retval));
					state.errorRecovery=false;state.failed=false;
				}
				else
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					throw mse;
				}


				}
				break;

			}
			} finally { DebugExitSubRule(211); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("postfixExpression", 76);
			LeaveRule("postfixExpression", 76);
			Leave_postfixExpression();
			if (state.backtracking > 0) { Memoize(input, 76, postfixExpression_StartIndex); }
		}
		DebugLocation(367, 1);
		} finally { DebugExitRule(GrammarFileName, "postfixExpression"); }
		return retval;

	}
	// $ANTLR end "postfixExpression"

	public class primaryExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_primaryExpression();
	partial void Leave_primaryExpression();

	// $ANTLR start "primaryExpression"
	// JavaScript.g:369:1: primaryExpression : ( THIS | Identifier | literal | arrayLiteral | objectLiteral | '(' ( LT )* expression ( LT )* RPAREN );
	[GrammarRule("primaryExpression")]
	public JavaScriptParser.primaryExpression_return primaryExpression()
	{
		Enter_primaryExpression();
		EnterRule("primaryExpression", 77);
		TraceIn("primaryExpression", 77);
		JavaScriptParser.primaryExpression_return retval = new JavaScriptParser.primaryExpression_return();
		retval.Start = (IToken)input.LT(1);
		int primaryExpression_StartIndex = input.Index;
		object root_0 = null;

		IToken THIS417=null;
		IToken Identifier418=null;
		IToken char_literal422=null;
		IToken LT423=null;
		IToken LT425=null;
		IToken RPAREN426=null;
		JavaScriptParser.literal_return literal419 = default(JavaScriptParser.literal_return);
		JavaScriptParser.arrayLiteral_return arrayLiteral420 = default(JavaScriptParser.arrayLiteral_return);
		JavaScriptParser.objectLiteral_return objectLiteral421 = default(JavaScriptParser.objectLiteral_return);
		JavaScriptParser.expression_return expression424 = default(JavaScriptParser.expression_return);

		object THIS417_tree=null;
		object Identifier418_tree=null;
		object char_literal422_tree=null;
		object LT423_tree=null;
		object LT425_tree=null;
		object RPAREN426_tree=null;

		try { DebugEnterRule(GrammarFileName, "primaryExpression");
		DebugLocation(369, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 77)) { return retval; }
			// JavaScript.g:370:2: ( THIS | Identifier | literal | arrayLiteral | objectLiteral | '(' ( LT )* expression ( LT )* RPAREN )
			int alt214=6;
			try { DebugEnterDecision(214, decisionCanBacktrack[214]);
			switch (input.LA(1))
			{
			case THIS:
				{
				alt214=1;
				}
				break;
			case Identifier:
				{
				alt214=2;
				}
				break;
			case NULL:
			case TRUE:
			case FALSE:
			case NumericLiteral:
			case StringLiteral:
			case RegularExpressionLiteral:
				{
				alt214=3;
				}
				break;
			case 69:
				{
				alt214=4;
				}
				break;
			case 47:
				{
				alt214=5;
				}
				break;
			case 45:
				{
				alt214=6;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 214, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(214); }
			switch (alt214)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:370:4: THIS
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(370, 4);
				THIS417=(IToken)new XToken((IToken)Match(input,THIS,Follow._THIS_in_primaryExpression2414), "THIS"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				THIS417_tree = (object)adaptor.Create(THIS417, retval);
				adaptor.AddChild(root_0, THIS417_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:371:4: Identifier
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(371, 4);
				Identifier418=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_primaryExpression2419), "Identifier"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				Identifier418_tree = (object)adaptor.Create(Identifier418, retval);
				adaptor.AddChild(root_0, Identifier418_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:372:4: literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(372, 4);
				PushFollow(Follow._literal_in_primaryExpression2424);
				literal419=literal();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, literal419.Tree, literal419, retval);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// JavaScript.g:373:4: arrayLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(373, 4);
				PushFollow(Follow._arrayLiteral_in_primaryExpression2429);
				arrayLiteral420=arrayLiteral();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arrayLiteral420.Tree, arrayLiteral420, retval);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// JavaScript.g:374:4: objectLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(374, 4);
				PushFollow(Follow._objectLiteral_in_primaryExpression2434);
				objectLiteral421=objectLiteral();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, objectLiteral421.Tree, objectLiteral421, retval);

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// JavaScript.g:375:4: '(' ( LT )* expression ( LT )* RPAREN
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(375, 4);
				char_literal422=(IToken)Match(input,45,Follow._45_in_primaryExpression2439); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal422_tree = (object)adaptor.Create(char_literal422, retval);
				adaptor.AddChild(root_0, char_literal422_tree);
				}
				DebugLocation(375, 10);
				// JavaScript.g:375:10: ( LT )*
				try { DebugEnterSubRule(212);
				while (true)
				{
					int alt212=2;
					try { DebugEnterDecision(212, decisionCanBacktrack[212]);
					int LA212_0 = input.LA(1);

					if ((LA212_0==LT))
					{
						alt212=1;
					}


					} finally { DebugExitDecision(212); }
					switch ( alt212 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(375, 10);
						LT423=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_primaryExpression2441), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop212;
					}
				}

				loop212:
					;

				} finally { DebugExitSubRule(212); }

				DebugLocation(375, 13);
				PushFollow(Follow._expression_in_primaryExpression2445);
				expression424=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression424.Tree, expression424, retval);
				DebugLocation(375, 26);
				// JavaScript.g:375:26: ( LT )*
				try { DebugEnterSubRule(213);
				while (true)
				{
					int alt213=2;
					try { DebugEnterDecision(213, decisionCanBacktrack[213]);
					int LA213_0 = input.LA(1);

					if ((LA213_0==LT))
					{
						alt213=1;
					}


					} finally { DebugExitDecision(213); }
					switch ( alt213 )
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:0:0: LT
						{
						DebugLocation(375, 26);
						LT425=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_primaryExpression2447), "LT"); if (state.failed) return retval;

						}
						break;

					default:
						goto loop213;
					}
				}

				loop213:
					;

				} finally { DebugExitSubRule(213); }

				DebugLocation(375, 29);
				RPAREN426=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_primaryExpression2451), "RPAREN"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				RPAREN426_tree = (object)adaptor.Create(RPAREN426, retval);
				adaptor.AddChild(root_0, RPAREN426_tree);
				}

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("primaryExpression", 77);
			LeaveRule("primaryExpression", 77);
			Leave_primaryExpression();
			if (state.backtracking > 0) { Memoize(input, 77, primaryExpression_StartIndex); }
		}
		DebugLocation(376, 1);
		} finally { DebugExitRule(GrammarFileName, "primaryExpression"); }
		return retval;

	}
	// $ANTLR end "primaryExpression"

	public class arrayLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_arrayLiteral();
	partial void Leave_arrayLiteral();

	// $ANTLR start "arrayLiteral"
	// JavaScript.g:379:1: arrayLiteral : '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* RBRACK ;
	[GrammarRule("arrayLiteral")]
	public JavaScriptParser.arrayLiteral_return arrayLiteral()
	{
		Enter_arrayLiteral();
		EnterRule("arrayLiteral", 78);
		TraceIn("arrayLiteral", 78);
		JavaScriptParser.arrayLiteral_return retval = new JavaScriptParser.arrayLiteral_return();
		retval.Start = (IToken)input.LT(1);
		int arrayLiteral_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal427=null;
		IToken LT428=null;
		IToken LT430=null;
		IToken char_literal431=null;
		IToken LT432=null;
		IToken LT434=null;
		IToken RBRACK435=null;
		JavaScriptParser.assignmentExpression_return assignmentExpression429 = default(JavaScriptParser.assignmentExpression_return);
		JavaScriptParser.assignmentExpression_return assignmentExpression433 = default(JavaScriptParser.assignmentExpression_return);

		object char_literal427_tree=null;
		object LT428_tree=null;
		object LT430_tree=null;
		object char_literal431_tree=null;
		object LT432_tree=null;
		object LT434_tree=null;
		object RBRACK435_tree=null;

		try { DebugEnterRule(GrammarFileName, "arrayLiteral");
		DebugLocation(379, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 78)) { return retval; }
			// JavaScript.g:380:2: ( '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* RBRACK )
			DebugEnterAlt(1);
			// JavaScript.g:380:4: '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* RBRACK
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(380, 4);
			char_literal427=(IToken)Match(input,69,Follow._69_in_arrayLiteral2464); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal427_tree = (object)adaptor.Create(char_literal427, retval);
			adaptor.AddChild(root_0, char_literal427_tree);
			}
			DebugLocation(380, 10);
			// JavaScript.g:380:10: ( LT )*
			try { DebugEnterSubRule(215);
			while (true)
			{
				int alt215=2;
				try { DebugEnterDecision(215, decisionCanBacktrack[215]);
				int LA215_0 = input.LA(1);

				if ((LA215_0==LT))
				{
					int LA215_2 = input.LA(2);

					if ((EvaluatePredicate(synpred279_JavaScript_fragment)))
					{
						alt215=1;
					}


				}


				} finally { DebugExitDecision(215); }
				switch ( alt215 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(380, 10);
					LT428=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arrayLiteral2466), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop215;
				}
			}

			loop215:
				;

			} finally { DebugExitSubRule(215); }

			DebugLocation(380, 13);
			// JavaScript.g:380:13: ( assignmentExpression )?
			int alt216=2;
			try { DebugEnterSubRule(216);
			try { DebugEnterDecision(216, decisionCanBacktrack[216]);
			int LA216_0 = input.LA(1);

			if (((LA216_0>=NULL && LA216_0<=THIS)||(LA216_0>=Identifier && LA216_0<=RegularExpressionLiteral)||(LA216_0>=44 && LA216_0<=45)||LA216_0==47||(LA216_0>=68 && LA216_0<=69)||(LA216_0>=100 && LA216_0<=101)||(LA216_0>=105 && LA216_0<=111)))
			{
				alt216=1;
			}
			} finally { DebugExitDecision(216); }
			switch (alt216)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: assignmentExpression
				{
				DebugLocation(380, 13);
				PushFollow(Follow._assignmentExpression_in_arrayLiteral2470);
				assignmentExpression429=assignmentExpression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression429.Tree, assignmentExpression429, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(216); }

			DebugLocation(380, 35);
			// JavaScript.g:380:35: ( ( LT )* ',' ( ( LT )* assignmentExpression )? )*
			try { DebugEnterSubRule(220);
			while (true)
			{
				int alt220=2;
				try { DebugEnterDecision(220, decisionCanBacktrack[220]);
				try
				{
					alt220 = dfa220.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(220); }
				switch ( alt220 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:380:36: ( LT )* ',' ( ( LT )* assignmentExpression )?
					{
					DebugLocation(380, 38);
					// JavaScript.g:380:38: ( LT )*
					try { DebugEnterSubRule(217);
					while (true)
					{
						int alt217=2;
						try { DebugEnterDecision(217, decisionCanBacktrack[217]);
						int LA217_0 = input.LA(1);

						if ((LA217_0==LT))
						{
							alt217=1;
						}


						} finally { DebugExitDecision(217); }
						switch ( alt217 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(380, 38);
							LT430=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arrayLiteral2474), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop217;
						}
					}

					loop217:
						;

					} finally { DebugExitSubRule(217); }

					DebugLocation(380, 41);
					char_literal431=(IToken)Match(input,46,Follow._46_in_arrayLiteral2478); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal431_tree = (object)adaptor.Create(char_literal431, retval);
					adaptor.AddChild(root_0, char_literal431_tree);
					}
					DebugLocation(380, 45);
					// JavaScript.g:380:45: ( ( LT )* assignmentExpression )?
					int alt219=2;
					try { DebugEnterSubRule(219);
					try { DebugEnterDecision(219, decisionCanBacktrack[219]);
					try
					{
						alt219 = dfa219.Predict(input);
					}
					catch (NoViableAltException nvae)
					{
						DebugRecognitionException(nvae);
						throw;
					}
					} finally { DebugExitDecision(219); }
					switch (alt219)
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:380:46: ( LT )* assignmentExpression
						{
						DebugLocation(380, 48);
						// JavaScript.g:380:48: ( LT )*
						try { DebugEnterSubRule(218);
						while (true)
						{
							int alt218=2;
							try { DebugEnterDecision(218, decisionCanBacktrack[218]);
							int LA218_0 = input.LA(1);

							if ((LA218_0==LT))
							{
								alt218=1;
							}


							} finally { DebugExitDecision(218); }
							switch ( alt218 )
							{
							case 1:
								DebugEnterAlt(1);
								// JavaScript.g:0:0: LT
								{
								DebugLocation(380, 48);
								LT432=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arrayLiteral2481), "LT"); if (state.failed) return retval;

								}
								break;

							default:
								goto loop218;
							}
						}

						loop218:
							;

						} finally { DebugExitSubRule(218); }

						DebugLocation(380, 51);
						PushFollow(Follow._assignmentExpression_in_arrayLiteral2485);
						assignmentExpression433=assignmentExpression();
						PopFollow();
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression433.Tree, assignmentExpression433, retval);

						}
						break;

					}
					} finally { DebugExitSubRule(219); }


					}
					break;

				default:
					goto loop220;
				}
			}

			loop220:
				;

			} finally { DebugExitSubRule(220); }

			DebugLocation(380, 78);
			// JavaScript.g:380:78: ( LT )*
			try { DebugEnterSubRule(221);
			while (true)
			{
				int alt221=2;
				try { DebugEnterDecision(221, decisionCanBacktrack[221]);
				int LA221_0 = input.LA(1);

				if ((LA221_0==LT))
				{
					alt221=1;
				}


				} finally { DebugExitDecision(221); }
				switch ( alt221 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(380, 78);
					LT434=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_arrayLiteral2491), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop221;
				}
			}

			loop221:
				;

			} finally { DebugExitSubRule(221); }

			DebugLocation(380, 81);
			RBRACK435=(IToken)new XToken((IToken)Match(input,RBRACK,Follow._RBRACK_in_arrayLiteral2495), "RBRACK"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RBRACK435_tree = (object)adaptor.Create(RBRACK435, retval);
			adaptor.AddChild(root_0, RBRACK435_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("arrayLiteral", 78);
			LeaveRule("arrayLiteral", 78);
			Leave_arrayLiteral();
			if (state.backtracking > 0) { Memoize(input, 78, arrayLiteral_StartIndex); }
		}
		DebugLocation(381, 1);
		} finally { DebugExitRule(GrammarFileName, "arrayLiteral"); }
		return retval;

	}
	// $ANTLR end "arrayLiteral"

	public class objectLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_objectLiteral();
	partial void Leave_objectLiteral();

	// $ANTLR start "objectLiteral"
	// JavaScript.g:384:1: objectLiteral : '{' ( LT )* ( propertyNameAndValue )? ( ( LT )* ',' ( ( LT )* propertyNameAndValue )? )* ( LT )* RBRACE ;
	[GrammarRule("objectLiteral")]
	public JavaScriptParser.objectLiteral_return objectLiteral()
	{
		Enter_objectLiteral();
		EnterRule("objectLiteral", 79);
		TraceIn("objectLiteral", 79);
		JavaScriptParser.objectLiteral_return retval = new JavaScriptParser.objectLiteral_return();
		retval.Start = (IToken)input.LT(1);
		int objectLiteral_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal436=null;
		IToken LT437=null;
		IToken LT439=null;
		IToken char_literal440=null;
		IToken LT441=null;
		IToken LT443=null;
		IToken RBRACE444=null;
		JavaScriptParser.propertyNameAndValue_return propertyNameAndValue438 = default(JavaScriptParser.propertyNameAndValue_return);
		JavaScriptParser.propertyNameAndValue_return propertyNameAndValue442 = default(JavaScriptParser.propertyNameAndValue_return);

		object char_literal436_tree=null;
		object LT437_tree=null;
		object LT439_tree=null;
		object char_literal440_tree=null;
		object LT441_tree=null;
		object LT443_tree=null;
		object RBRACE444_tree=null;

		try { DebugEnterRule(GrammarFileName, "objectLiteral");
		DebugLocation(384, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 79)) { return retval; }
			// JavaScript.g:385:2: ( '{' ( LT )* ( propertyNameAndValue )? ( ( LT )* ',' ( ( LT )* propertyNameAndValue )? )* ( LT )* RBRACE )
			DebugEnterAlt(1);
			// JavaScript.g:385:4: '{' ( LT )* ( propertyNameAndValue )? ( ( LT )* ',' ( ( LT )* propertyNameAndValue )? )* ( LT )* RBRACE
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(385, 4);
			char_literal436=(IToken)Match(input,47,Follow._47_in_objectLiteral2514); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal436_tree = (object)adaptor.Create(char_literal436, retval);
			adaptor.AddChild(root_0, char_literal436_tree);
			}
			DebugLocation(385, 10);
			// JavaScript.g:385:10: ( LT )*
			try { DebugEnterSubRule(222);
			while (true)
			{
				int alt222=2;
				try { DebugEnterDecision(222, decisionCanBacktrack[222]);
				int LA222_0 = input.LA(1);

				if ((LA222_0==LT))
				{
					int LA222_2 = input.LA(2);

					if ((EvaluatePredicate(synpred286_JavaScript_fragment)))
					{
						alt222=1;
					}


				}


				} finally { DebugExitDecision(222); }
				switch ( alt222 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(385, 10);
					LT437=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_objectLiteral2516), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop222;
				}
			}

			loop222:
				;

			} finally { DebugExitSubRule(222); }

			DebugLocation(385, 13);
			// JavaScript.g:385:13: ( propertyNameAndValue )?
			int alt223=2;
			try { DebugEnterSubRule(223);
			try { DebugEnterDecision(223, decisionCanBacktrack[223]);
			int LA223_0 = input.LA(1);

			if (((LA223_0>=Identifier && LA223_0<=StringLiteral)))
			{
				alt223=1;
			}
			} finally { DebugExitDecision(223); }
			switch (alt223)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:0:0: propertyNameAndValue
				{
				DebugLocation(385, 13);
				PushFollow(Follow._propertyNameAndValue_in_objectLiteral2520);
				propertyNameAndValue438=propertyNameAndValue();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyNameAndValue438.Tree, propertyNameAndValue438, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(223); }

			DebugLocation(385, 35);
			// JavaScript.g:385:35: ( ( LT )* ',' ( ( LT )* propertyNameAndValue )? )*
			try { DebugEnterSubRule(227);
			while (true)
			{
				int alt227=2;
				try { DebugEnterDecision(227, decisionCanBacktrack[227]);
				try
				{
					alt227 = dfa227.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(227); }
				switch ( alt227 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:385:36: ( LT )* ',' ( ( LT )* propertyNameAndValue )?
					{
					DebugLocation(385, 38);
					// JavaScript.g:385:38: ( LT )*
					try { DebugEnterSubRule(224);
					while (true)
					{
						int alt224=2;
						try { DebugEnterDecision(224, decisionCanBacktrack[224]);
						int LA224_0 = input.LA(1);

						if ((LA224_0==LT))
						{
							alt224=1;
						}


						} finally { DebugExitDecision(224); }
						switch ( alt224 )
						{
						case 1:
							DebugEnterAlt(1);
							// JavaScript.g:0:0: LT
							{
							DebugLocation(385, 38);
							LT439=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_objectLiteral2524), "LT"); if (state.failed) return retval;

							}
							break;

						default:
							goto loop224;
						}
					}

					loop224:
						;

					} finally { DebugExitSubRule(224); }

					DebugLocation(385, 41);
					char_literal440=(IToken)Match(input,46,Follow._46_in_objectLiteral2528); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal440_tree = (object)adaptor.Create(char_literal440, retval);
					adaptor.AddChild(root_0, char_literal440_tree);
					}
					DebugLocation(385, 45);
					// JavaScript.g:385:45: ( ( LT )* propertyNameAndValue )?
					int alt226=2;
					try { DebugEnterSubRule(226);
					try { DebugEnterDecision(226, decisionCanBacktrack[226]);
					try
					{
						alt226 = dfa226.Predict(input);
					}
					catch (NoViableAltException nvae)
					{
						DebugRecognitionException(nvae);
						throw;
					}
					} finally { DebugExitDecision(226); }
					switch (alt226)
					{
					case 1:
						DebugEnterAlt(1);
						// JavaScript.g:385:46: ( LT )* propertyNameAndValue
						{
						DebugLocation(385, 48);
						// JavaScript.g:385:48: ( LT )*
						try { DebugEnterSubRule(225);
						while (true)
						{
							int alt225=2;
							try { DebugEnterDecision(225, decisionCanBacktrack[225]);
							int LA225_0 = input.LA(1);

							if ((LA225_0==LT))
							{
								alt225=1;
							}


							} finally { DebugExitDecision(225); }
							switch ( alt225 )
							{
							case 1:
								DebugEnterAlt(1);
								// JavaScript.g:0:0: LT
								{
								DebugLocation(385, 48);
								LT441=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_objectLiteral2531), "LT"); if (state.failed) return retval;

								}
								break;

							default:
								goto loop225;
							}
						}

						loop225:
							;

						} finally { DebugExitSubRule(225); }

						DebugLocation(385, 51);
						PushFollow(Follow._propertyNameAndValue_in_objectLiteral2535);
						propertyNameAndValue442=propertyNameAndValue();
						PopFollow();
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyNameAndValue442.Tree, propertyNameAndValue442, retval);

						}
						break;

					}
					} finally { DebugExitSubRule(226); }


					}
					break;

				default:
					goto loop227;
				}
			}

			loop227:
				;

			} finally { DebugExitSubRule(227); }

			DebugLocation(385, 78);
			// JavaScript.g:385:78: ( LT )*
			try { DebugEnterSubRule(228);
			while (true)
			{
				int alt228=2;
				try { DebugEnterDecision(228, decisionCanBacktrack[228]);
				int LA228_0 = input.LA(1);

				if ((LA228_0==LT))
				{
					alt228=1;
				}


				} finally { DebugExitDecision(228); }
				switch ( alt228 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(385, 78);
					LT443=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_objectLiteral2541), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop228;
				}
			}

			loop228:
				;

			} finally { DebugExitSubRule(228); }

			DebugLocation(385, 81);
			RBRACE444=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_objectLiteral2545), "RBRACE"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RBRACE444_tree = (object)adaptor.Create(RBRACE444, retval);
			adaptor.AddChild(root_0, RBRACE444_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("objectLiteral", 79);
			LeaveRule("objectLiteral", 79);
			Leave_objectLiteral();
			if (state.backtracking > 0) { Memoize(input, 79, objectLiteral_StartIndex); }
		}
		DebugLocation(386, 1);
		} finally { DebugExitRule(GrammarFileName, "objectLiteral"); }
		return retval;

	}
	// $ANTLR end "objectLiteral"

	public class propertyNameAndValue_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_propertyNameAndValue();
	partial void Leave_propertyNameAndValue();

	// $ANTLR start "propertyNameAndValue"
	// JavaScript.g:388:1: propertyNameAndValue : propertyName ( LT )* ':' ( LT )* assignmentExpression ;
	[GrammarRule("propertyNameAndValue")]
	public JavaScriptParser.propertyNameAndValue_return propertyNameAndValue()
	{
		Enter_propertyNameAndValue();
		EnterRule("propertyNameAndValue", 80);
		TraceIn("propertyNameAndValue", 80);
		JavaScriptParser.propertyNameAndValue_return retval = new JavaScriptParser.propertyNameAndValue_return();
		retval.Start = (IToken)input.LT(1);
		int propertyNameAndValue_StartIndex = input.Index;
		object root_0 = null;

		IToken LT446=null;
		IToken char_literal447=null;
		IToken LT448=null;
		JavaScriptParser.propertyName_return propertyName445 = default(JavaScriptParser.propertyName_return);
		JavaScriptParser.assignmentExpression_return assignmentExpression449 = default(JavaScriptParser.assignmentExpression_return);

		object LT446_tree=null;
		object char_literal447_tree=null;
		object LT448_tree=null;

		try { DebugEnterRule(GrammarFileName, "propertyNameAndValue");
		DebugLocation(388, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 80)) { return retval; }
			// JavaScript.g:389:2: ( propertyName ( LT )* ':' ( LT )* assignmentExpression )
			DebugEnterAlt(1);
			// JavaScript.g:389:4: propertyName ( LT )* ':' ( LT )* assignmentExpression
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(389, 4);
			PushFollow(Follow._propertyName_in_propertyNameAndValue2557);
			propertyName445=propertyName();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyName445.Tree, propertyName445, retval);
			DebugLocation(389, 19);
			// JavaScript.g:389:19: ( LT )*
			try { DebugEnterSubRule(229);
			while (true)
			{
				int alt229=2;
				try { DebugEnterDecision(229, decisionCanBacktrack[229]);
				int LA229_0 = input.LA(1);

				if ((LA229_0==LT))
				{
					alt229=1;
				}


				} finally { DebugExitDecision(229); }
				switch ( alt229 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(389, 19);
					LT446=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_propertyNameAndValue2559), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop229;
				}
			}

			loop229:
				;

			} finally { DebugExitSubRule(229); }

			DebugLocation(389, 22);
			char_literal447=(IToken)Match(input,60,Follow._60_in_propertyNameAndValue2563); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal447_tree = (object)adaptor.Create(char_literal447, retval);
			adaptor.AddChild(root_0, char_literal447_tree);
			}
			DebugLocation(389, 28);
			// JavaScript.g:389:28: ( LT )*
			try { DebugEnterSubRule(230);
			while (true)
			{
				int alt230=2;
				try { DebugEnterDecision(230, decisionCanBacktrack[230]);
				int LA230_0 = input.LA(1);

				if ((LA230_0==LT))
				{
					alt230=1;
				}


				} finally { DebugExitDecision(230); }
				switch ( alt230 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(389, 28);
					LT448=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_propertyNameAndValue2565), "LT"); if (state.failed) return retval;

					}
					break;

				default:
					goto loop230;
				}
			}

			loop230:
				;

			} finally { DebugExitSubRule(230); }

			DebugLocation(389, 31);
			PushFollow(Follow._assignmentExpression_in_propertyNameAndValue2569);
			assignmentExpression449=assignmentExpression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression449.Tree, assignmentExpression449, retval);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("propertyNameAndValue", 80);
			LeaveRule("propertyNameAndValue", 80);
			Leave_propertyNameAndValue();
			if (state.backtracking > 0) { Memoize(input, 80, propertyNameAndValue_StartIndex); }
		}
		DebugLocation(390, 1);
		} finally { DebugExitRule(GrammarFileName, "propertyNameAndValue"); }
		return retval;

	}
	// $ANTLR end "propertyNameAndValue"

	public class propertyName_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_propertyName();
	partial void Leave_propertyName();

	// $ANTLR start "propertyName"
	// JavaScript.g:392:1: propertyName : ( Identifier | stringliteral | numericliteral );
	[GrammarRule("propertyName")]
	public JavaScriptParser.propertyName_return propertyName()
	{
		Enter_propertyName();
		EnterRule("propertyName", 81);
		TraceIn("propertyName", 81);
		JavaScriptParser.propertyName_return retval = new JavaScriptParser.propertyName_return();
		retval.Start = (IToken)input.LT(1);
		int propertyName_StartIndex = input.Index;
		object root_0 = null;

		IToken Identifier450=null;
		JavaScriptParser.stringliteral_return stringliteral451 = default(JavaScriptParser.stringliteral_return);
		JavaScriptParser.numericliteral_return numericliteral452 = default(JavaScriptParser.numericliteral_return);

		object Identifier450_tree=null;

		try { DebugEnterRule(GrammarFileName, "propertyName");
		DebugLocation(392, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 81)) { return retval; }
			// JavaScript.g:393:2: ( Identifier | stringliteral | numericliteral )
			int alt231=3;
			try { DebugEnterDecision(231, decisionCanBacktrack[231]);
			switch (input.LA(1))
			{
			case Identifier:
				{
				alt231=1;
				}
				break;
			case StringLiteral:
				{
				alt231=2;
				}
				break;
			case NumericLiteral:
				{
				alt231=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 231, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(231); }
			switch (alt231)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:393:4: Identifier
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(393, 4);
				Identifier450=(IToken)new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_propertyName2580), "Identifier"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				Identifier450_tree = (object)adaptor.Create(Identifier450, retval);
				adaptor.AddChild(root_0, Identifier450_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:394:4: stringliteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(394, 4);
				PushFollow(Follow._stringliteral_in_propertyName2585);
				stringliteral451=stringliteral();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, stringliteral451.Tree, stringliteral451, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:395:4: numericliteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(395, 4);
				PushFollow(Follow._numericliteral_in_propertyName2590);
				numericliteral452=numericliteral();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, numericliteral452.Tree, numericliteral452, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("propertyName", 81);
			LeaveRule("propertyName", 81);
			Leave_propertyName();
			if (state.backtracking > 0) { Memoize(input, 81, propertyName_StartIndex); }
		}
		DebugLocation(396, 1);
		} finally { DebugExitRule(GrammarFileName, "propertyName"); }
		return retval;

	}
	// $ANTLR end "propertyName"

	public class literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_literal();
	partial void Leave_literal();

	// $ANTLR start "literal"
	// JavaScript.g:399:1: literal : ( NULL | TRUE | FALSE | stringliteral | numericliteral | regularExpressionLiteral );
	[GrammarRule("literal")]
	public JavaScriptParser.literal_return literal()
	{
		Enter_literal();
		EnterRule("literal", 82);
		TraceIn("literal", 82);
		JavaScriptParser.literal_return retval = new JavaScriptParser.literal_return();
		retval.Start = (IToken)input.LT(1);
		int literal_StartIndex = input.Index;
		object root_0 = null;

		IToken NULL453=null;
		IToken TRUE454=null;
		IToken FALSE455=null;
		JavaScriptParser.stringliteral_return stringliteral456 = default(JavaScriptParser.stringliteral_return);
		JavaScriptParser.numericliteral_return numericliteral457 = default(JavaScriptParser.numericliteral_return);
		JavaScriptParser.regularExpressionLiteral_return regularExpressionLiteral458 = default(JavaScriptParser.regularExpressionLiteral_return);

		object NULL453_tree=null;
		object TRUE454_tree=null;
		object FALSE455_tree=null;

		try { DebugEnterRule(GrammarFileName, "literal");
		DebugLocation(399, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 82)) { return retval; }
			// JavaScript.g:400:2: ( NULL | TRUE | FALSE | stringliteral | numericliteral | regularExpressionLiteral )
			int alt232=6;
			try { DebugEnterDecision(232, decisionCanBacktrack[232]);
			switch (input.LA(1))
			{
			case NULL:
				{
				alt232=1;
				}
				break;
			case TRUE:
				{
				alt232=2;
				}
				break;
			case FALSE:
				{
				alt232=3;
				}
				break;
			case StringLiteral:
				{
				alt232=4;
				}
				break;
			case NumericLiteral:
				{
				alt232=5;
				}
				break;
			case RegularExpressionLiteral:
				{
				alt232=6;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 232, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(232); }
			switch (alt232)
			{
			case 1:
				DebugEnterAlt(1);
				// JavaScript.g:400:4: NULL
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(400, 4);
				NULL453=(IToken)new XToken((IToken)Match(input,NULL,Follow._NULL_in_literal2602), "NULL"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				NULL453_tree = (object)adaptor.Create(NULL453, retval);
				adaptor.AddChild(root_0, NULL453_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// JavaScript.g:401:4: TRUE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(401, 4);
				TRUE454=(IToken)new XToken((IToken)Match(input,TRUE,Follow._TRUE_in_literal2607), "TRUE"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				TRUE454_tree = (object)adaptor.Create(TRUE454, retval);
				adaptor.AddChild(root_0, TRUE454_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// JavaScript.g:402:4: FALSE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(402, 4);
				FALSE455=(IToken)new XToken((IToken)Match(input,FALSE,Follow._FALSE_in_literal2612), "FALSE"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				FALSE455_tree = (object)adaptor.Create(FALSE455, retval);
				adaptor.AddChild(root_0, FALSE455_tree);
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// JavaScript.g:403:4: stringliteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(403, 4);
				PushFollow(Follow._stringliteral_in_literal2617);
				stringliteral456=stringliteral();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, stringliteral456.Tree, stringliteral456, retval);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// JavaScript.g:404:4: numericliteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(404, 4);
				PushFollow(Follow._numericliteral_in_literal2622);
				numericliteral457=numericliteral();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, numericliteral457.Tree, numericliteral457, retval);

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// JavaScript.g:405:4: regularExpressionLiteral
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(405, 4);
				PushFollow(Follow._regularExpressionLiteral_in_literal2627);
				regularExpressionLiteral458=regularExpressionLiteral();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, regularExpressionLiteral458.Tree, regularExpressionLiteral458, retval);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("literal", 82);
			LeaveRule("literal", 82);
			Leave_literal();
			if (state.backtracking > 0) { Memoize(input, 82, literal_StartIndex); }
		}
		DebugLocation(406, 1);
		} finally { DebugExitRule(GrammarFileName, "literal"); }
		return retval;

	}
	// $ANTLR end "literal"

	public class numericliteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_numericliteral();
	partial void Leave_numericliteral();

	// $ANTLR start "numericliteral"
	// JavaScript.g:408:1: numericliteral : NumericLiteral ;
	[GrammarRule("numericliteral")]
	public JavaScriptParser.numericliteral_return numericliteral()
	{
		Enter_numericliteral();
		EnterRule("numericliteral", 83);
		TraceIn("numericliteral", 83);
		JavaScriptParser.numericliteral_return retval = new JavaScriptParser.numericliteral_return();
		retval.Start = (IToken)input.LT(1);
		int numericliteral_StartIndex = input.Index;
		object root_0 = null;

		IToken NumericLiteral459=null;

		object NumericLiteral459_tree=null;

		try { DebugEnterRule(GrammarFileName, "numericliteral");
		DebugLocation(408, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 83)) { return retval; }
			// JavaScript.g:409:2: ( NumericLiteral )
			DebugEnterAlt(1);
			// JavaScript.g:409:4: NumericLiteral
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(409, 4);
			NumericLiteral459=(IToken)new XToken((IToken)Match(input,NumericLiteral,Follow._NumericLiteral_in_numericliteral2638), "NumericLiteral"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			NumericLiteral459_tree = (object)adaptor.Create(NumericLiteral459, retval);
			adaptor.AddChild(root_0, NumericLiteral459_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("numericliteral", 83);
			LeaveRule("numericliteral", 83);
			Leave_numericliteral();
			if (state.backtracking > 0) { Memoize(input, 83, numericliteral_StartIndex); }
		}
		DebugLocation(410, 1);
		} finally { DebugExitRule(GrammarFileName, "numericliteral"); }
		return retval;

	}
	// $ANTLR end "numericliteral"

	public class stringliteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_stringliteral();
	partial void Leave_stringliteral();

	// $ANTLR start "stringliteral"
	// JavaScript.g:412:1: stringliteral : StringLiteral ;
	[GrammarRule("stringliteral")]
	public JavaScriptParser.stringliteral_return stringliteral()
	{
		Enter_stringliteral();
		EnterRule("stringliteral", 84);
		TraceIn("stringliteral", 84);
		JavaScriptParser.stringliteral_return retval = new JavaScriptParser.stringliteral_return();
		retval.Start = (IToken)input.LT(1);
		int stringliteral_StartIndex = input.Index;
		object root_0 = null;

		IToken StringLiteral460=null;

		object StringLiteral460_tree=null;

		try { DebugEnterRule(GrammarFileName, "stringliteral");
		DebugLocation(412, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 84)) { return retval; }
			// JavaScript.g:413:2: ( StringLiteral )
			DebugEnterAlt(1);
			// JavaScript.g:413:4: StringLiteral
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(413, 4);
			StringLiteral460=(IToken)new XToken((IToken)Match(input,StringLiteral,Follow._StringLiteral_in_stringliteral2650), "StringLiteral"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			StringLiteral460_tree = (object)adaptor.Create(StringLiteral460, retval);
			adaptor.AddChild(root_0, StringLiteral460_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("stringliteral", 84);
			LeaveRule("stringliteral", 84);
			Leave_stringliteral();
			if (state.backtracking > 0) { Memoize(input, 84, stringliteral_StartIndex); }
		}
		DebugLocation(414, 1);
		} finally { DebugExitRule(GrammarFileName, "stringliteral"); }
		return retval;

	}
	// $ANTLR end "stringliteral"

	public class regularExpressionLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_regularExpressionLiteral();
	partial void Leave_regularExpressionLiteral();

	// $ANTLR start "regularExpressionLiteral"
	// JavaScript.g:416:1: regularExpressionLiteral : RegularExpressionLiteral ;
	[GrammarRule("regularExpressionLiteral")]
	public JavaScriptParser.regularExpressionLiteral_return regularExpressionLiteral()
	{
		Enter_regularExpressionLiteral();
		EnterRule("regularExpressionLiteral", 85);
		TraceIn("regularExpressionLiteral", 85);
		JavaScriptParser.regularExpressionLiteral_return retval = new JavaScriptParser.regularExpressionLiteral_return();
		retval.Start = (IToken)input.LT(1);
		int regularExpressionLiteral_StartIndex = input.Index;
		object root_0 = null;

		IToken RegularExpressionLiteral461=null;

		object RegularExpressionLiteral461_tree=null;

		try { DebugEnterRule(GrammarFileName, "regularExpressionLiteral");
		DebugLocation(416, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 85)) { return retval; }
			// JavaScript.g:417:2: ( RegularExpressionLiteral )
			DebugEnterAlt(1);
			// JavaScript.g:417:4: RegularExpressionLiteral
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(417, 4);
			RegularExpressionLiteral461=(IToken)new XToken((IToken)Match(input,RegularExpressionLiteral,Follow._RegularExpressionLiteral_in_regularExpressionLiteral2661), "RegularExpressionLiteral"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			RegularExpressionLiteral461_tree = (object)adaptor.Create(RegularExpressionLiteral461, retval);
			adaptor.AddChild(root_0, RegularExpressionLiteral461_tree);
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("regularExpressionLiteral", 85);
			LeaveRule("regularExpressionLiteral", 85);
			Leave_regularExpressionLiteral();
			if (state.backtracking > 0) { Memoize(input, 85, regularExpressionLiteral_StartIndex); }
		}
		DebugLocation(418, 1);
		} finally { DebugExitRule(GrammarFileName, "regularExpressionLiteral"); }
		return retval;

	}
	// $ANTLR end "regularExpressionLiteral"

	partial void Enter_synpred1_JavaScript_fragment();
	partial void Leave_synpred1_JavaScript_fragment();

	// $ANTLR start synpred1_JavaScript
	public void synpred1_JavaScript_fragment()
	{
		Enter_synpred1_JavaScript_fragment();
		EnterRule("synpred1_JavaScript_fragment", 86);
		TraceIn("synpred1_JavaScript_fragment", 86);
		try
		{
			// JavaScript.g:31:4: ( ';' )
			DebugEnterAlt(1);
			// JavaScript.g:31:4: ';'
			{
			DebugLocation(31, 4);
			Match(input,43,Follow._43_in_synpred1_JavaScript122); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred1_JavaScript_fragment", 86);
			LeaveRule("synpred1_JavaScript_fragment", 86);
			Leave_synpred1_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred1_JavaScript

	partial void Enter_synpred2_JavaScript_fragment();
	partial void Leave_synpred2_JavaScript_fragment();

	// $ANTLR start synpred2_JavaScript
	public void synpred2_JavaScript_fragment()
	{
		Enter_synpred2_JavaScript_fragment();
		EnterRule("synpred2_JavaScript_fragment", 87);
		TraceIn("synpred2_JavaScript_fragment", 87);
		try
		{
			// JavaScript.g:32:4: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:32:4: LT
			{
			DebugLocation(32, 4);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred2_JavaScript127), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred2_JavaScript_fragment", 87);
			LeaveRule("synpred2_JavaScript_fragment", 87);
			Leave_synpred2_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred2_JavaScript

	partial void Enter_synpred10_JavaScript_fragment();
	partial void Leave_synpred10_JavaScript_fragment();

	// $ANTLR start synpred10_JavaScript
	public void synpred10_JavaScript_fragment()
	{
		Enter_synpred10_JavaScript_fragment();
		EnterRule("synpred10_JavaScript_fragment", 95);
		TraceIn("synpred10_JavaScript_fragment", 95);
		try
		{
			// JavaScript.g:48:4: ( functionDeclaration )
			DebugEnterAlt(1);
			// JavaScript.g:48:4: functionDeclaration
			{
			DebugLocation(48, 4);
			PushFollow(Follow._functionDeclaration_in_synpred10_JavaScript203);
			functionDeclaration();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred10_JavaScript_fragment", 95);
			LeaveRule("synpred10_JavaScript_fragment", 95);
			Leave_synpred10_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred10_JavaScript

	partial void Enter_synpred14_JavaScript_fragment();
	partial void Leave_synpred14_JavaScript_fragment();

	// $ANTLR start synpred14_JavaScript
	public void synpred14_JavaScript_fragment()
	{
		Enter_synpred14_JavaScript_fragment();
		EnterRule("synpred14_JavaScript_fragment", 99);
		TraceIn("synpred14_JavaScript_fragment", 99);
		try
		{
			// JavaScript.g:58:15: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:58:15: LT
			{
			DebugLocation(58, 15);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred14_JavaScript253), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred14_JavaScript_fragment", 99);
			LeaveRule("synpred14_JavaScript_fragment", 99);
			Leave_synpred14_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred14_JavaScript

	partial void Enter_synpred24_JavaScript_fragment();
	partial void Leave_synpred24_JavaScript_fragment();

	// $ANTLR start synpred24_JavaScript
	public void synpred24_JavaScript_fragment()
	{
		Enter_synpred24_JavaScript_fragment();
		EnterRule("synpred24_JavaScript_fragment", 109);
		TraceIn("synpred24_JavaScript_fragment", 109);
		try
		{
			// JavaScript.g:66:8: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:66:8: LT
			{
			DebugLocation(66, 8);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred24_JavaScript325), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred24_JavaScript_fragment", 109);
			LeaveRule("synpred24_JavaScript_fragment", 109);
			Leave_synpred24_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred24_JavaScript

	partial void Enter_synpred27_JavaScript_fragment();
	partial void Leave_synpred27_JavaScript_fragment();

	// $ANTLR start synpred27_JavaScript
	public void synpred27_JavaScript_fragment()
	{
		Enter_synpred27_JavaScript_fragment();
		EnterRule("synpred27_JavaScript_fragment", 112);
		TraceIn("synpred27_JavaScript_fragment", 112);
		try
		{
			// JavaScript.g:71:4: ( statementBlock )
			DebugEnterAlt(1);
			// JavaScript.g:71:4: statementBlock
			{
			DebugLocation(71, 4);
			PushFollow(Follow._statementBlock_in_synpred27_JavaScript348);
			statementBlock();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred27_JavaScript_fragment", 112);
			LeaveRule("synpred27_JavaScript_fragment", 112);
			Leave_synpred27_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred27_JavaScript

	partial void Enter_synpred30_JavaScript_fragment();
	partial void Leave_synpred30_JavaScript_fragment();

	// $ANTLR start synpred30_JavaScript
	public void synpred30_JavaScript_fragment()
	{
		Enter_synpred30_JavaScript_fragment();
		EnterRule("synpred30_JavaScript_fragment", 115);
		TraceIn("synpred30_JavaScript_fragment", 115);
		try
		{
			// JavaScript.g:74:4: ( expressionStatement )
			DebugEnterAlt(1);
			// JavaScript.g:74:4: expressionStatement
			{
			DebugLocation(74, 4);
			PushFollow(Follow._expressionStatement_in_synpred30_JavaScript363);
			expressionStatement();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred30_JavaScript_fragment", 115);
			LeaveRule("synpred30_JavaScript_fragment", 115);
			Leave_synpred30_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred30_JavaScript

	partial void Enter_synpred37_JavaScript_fragment();
	partial void Leave_synpred37_JavaScript_fragment();

	// $ANTLR start synpred37_JavaScript
	public void synpred37_JavaScript_fragment()
	{
		Enter_synpred37_JavaScript_fragment();
		EnterRule("synpred37_JavaScript_fragment", 122);
		TraceIn("synpred37_JavaScript_fragment", 122);
		try
		{
			// JavaScript.g:81:4: ( labelledStatement )
			DebugEnterAlt(1);
			// JavaScript.g:81:4: labelledStatement
			{
			DebugLocation(81, 4);
			PushFollow(Follow._labelledStatement_in_synpred37_JavaScript398);
			labelledStatement();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred37_JavaScript_fragment", 122);
			LeaveRule("synpred37_JavaScript_fragment", 122);
			Leave_synpred37_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred37_JavaScript

	partial void Enter_synpred40_JavaScript_fragment();
	partial void Leave_synpred40_JavaScript_fragment();

	// $ANTLR start synpred40_JavaScript
	public void synpred40_JavaScript_fragment()
	{
		Enter_synpred40_JavaScript_fragment();
		EnterRule("synpred40_JavaScript_fragment", 125);
		TraceIn("synpred40_JavaScript_fragment", 125);
		try
		{
			// JavaScript.g:88:8: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:88:8: LT
			{
			DebugLocation(88, 8);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred40_JavaScript427), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred40_JavaScript_fragment", 125);
			LeaveRule("synpred40_JavaScript_fragment", 125);
			Leave_synpred40_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred40_JavaScript

	partial void Enter_synpred64_JavaScript_fragment();
	partial void Leave_synpred64_JavaScript_fragment();

	// $ANTLR start synpred64_JavaScript
	public void synpred64_JavaScript_fragment()
	{
		Enter_synpred64_JavaScript_fragment();
		EnterRule("synpred64_JavaScript_fragment", 149);
		TraceIn("synpred64_JavaScript_fragment", 149);
		try
		{
			// JavaScript.g:132:62: ( ( LT )* 'else' ( LT )* statement )
			DebugEnterAlt(1);
			// JavaScript.g:132:62: ( LT )* 'else' ( LT )* statement
			{
			DebugLocation(132, 64);
			// JavaScript.g:132:64: ( LT )*
			try { DebugEnterSubRule(247);
			while (true)
			{
				int alt247=2;
				try { DebugEnterDecision(247, decisionCanBacktrack[247]);
				int LA247_0 = input.LA(1);

				if ((LA247_0==LT))
				{
					alt247=1;
				}


				} finally { DebugExitDecision(247); }
				switch ( alt247 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(132, 62);
					new XToken((IToken)Match(input,LT,Follow._LT_in_synpred64_JavaScript676), "LT"); if (state.failed) return;

					}
					break;

				default:
					goto loop247;
				}
			}

			loop247:
				;

			} finally { DebugExitSubRule(247); }

			DebugLocation(132, 67);
			Match(input,51,Follow._51_in_synpred64_JavaScript680); if (state.failed) return;
			DebugLocation(132, 76);
			// JavaScript.g:132:76: ( LT )*
			try { DebugEnterSubRule(248);
			while (true)
			{
				int alt248=2;
				try { DebugEnterDecision(248, decisionCanBacktrack[248]);
				int LA248_0 = input.LA(1);

				if ((LA248_0==LT))
				{
					alt248=1;
				}


				} finally { DebugExitDecision(248); }
				switch ( alt248 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(132, 74);
					new XToken((IToken)Match(input,LT,Follow._LT_in_synpred64_JavaScript682), "LT"); if (state.failed) return;

					}
					break;

				default:
					goto loop248;
				}
			}

			loop248:
				;

			} finally { DebugExitSubRule(248); }

			DebugLocation(132, 79);
			PushFollow(Follow._statement_in_synpred64_JavaScript686);
			statement();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred64_JavaScript_fragment", 149);
			LeaveRule("synpred64_JavaScript_fragment", 149);
			Leave_synpred64_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred64_JavaScript

	partial void Enter_synpred67_JavaScript_fragment();
	partial void Leave_synpred67_JavaScript_fragment();

	// $ANTLR start synpred67_JavaScript
	public void synpred67_JavaScript_fragment()
	{
		Enter_synpred67_JavaScript_fragment();
		EnterRule("synpred67_JavaScript_fragment", 152);
		TraceIn("synpred67_JavaScript_fragment", 152);
		try
		{
			// JavaScript.g:138:4: ( forStatement )
			DebugEnterAlt(1);
			// JavaScript.g:138:4: forStatement
			{
			DebugLocation(138, 4);
			PushFollow(Follow._forStatement_in_synpred67_JavaScript710);
			forStatement();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred67_JavaScript_fragment", 152);
			LeaveRule("synpred67_JavaScript_fragment", 152);
			Leave_synpred67_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred67_JavaScript

	partial void Enter_synpred96_JavaScript_fragment();
	partial void Leave_synpred96_JavaScript_fragment();

	// $ANTLR start synpred96_JavaScript
	public void synpred96_JavaScript_fragment()
	{
		Enter_synpred96_JavaScript_fragment();
		EnterRule("synpred96_JavaScript_fragment", 181);
		TraceIn("synpred96_JavaScript_fragment", 181);
		try
		{
			// JavaScript.g:169:15: ( Identifier )
			DebugEnterAlt(1);
			// JavaScript.g:169:15: Identifier
			{
			DebugLocation(169, 15);
			new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_synpred96_JavaScript963), "Identifier"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred96_JavaScript_fragment", 181);
			LeaveRule("synpred96_JavaScript_fragment", 181);
			Leave_synpred96_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred96_JavaScript

	partial void Enter_synpred97_JavaScript_fragment();
	partial void Leave_synpred97_JavaScript_fragment();

	// $ANTLR start synpred97_JavaScript
	public void synpred97_JavaScript_fragment()
	{
		Enter_synpred97_JavaScript_fragment();
		EnterRule("synpred97_JavaScript_fragment", 182);
		TraceIn("synpred97_JavaScript_fragment", 182);
		try
		{
			// JavaScript.g:173:12: ( Identifier )
			DebugEnterAlt(1);
			// JavaScript.g:173:12: Identifier
			{
			DebugLocation(173, 12);
			new XToken((IToken)Match(input,Identifier,Follow._Identifier_in_synpred97_JavaScript979), "Identifier"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred97_JavaScript_fragment", 182);
			LeaveRule("synpred97_JavaScript_fragment", 182);
			Leave_synpred97_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred97_JavaScript

	partial void Enter_synpred98_JavaScript_fragment();
	partial void Leave_synpred98_JavaScript_fragment();

	// $ANTLR start synpred98_JavaScript
	public void synpred98_JavaScript_fragment()
	{
		Enter_synpred98_JavaScript_fragment();
		EnterRule("synpred98_JavaScript_fragment", 183);
		TraceIn("synpred98_JavaScript_fragment", 183);
		try
		{
			// JavaScript.g:177:13: ( expression )
			DebugEnterAlt(1);
			// JavaScript.g:177:13: expression
			{
			DebugLocation(177, 13);
			PushFollow(Follow._expression_in_synpred98_JavaScript995);
			expression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred98_JavaScript_fragment", 183);
			LeaveRule("synpred98_JavaScript_fragment", 183);
			Leave_synpred98_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred98_JavaScript

	partial void Enter_synpred118_JavaScript_fragment();
	partial void Leave_synpred118_JavaScript_fragment();

	// $ANTLR start synpred118_JavaScript
	public void synpred118_JavaScript_fragment()
	{
		Enter_synpred118_JavaScript_fragment();
		EnterRule("synpred118_JavaScript_fragment", 203);
		TraceIn("synpred118_JavaScript_fragment", 203);
		try
		{
			// JavaScript.g:197:36: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:197:36: LT
			{
			DebugLocation(197, 36);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred118_JavaScript1163), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred118_JavaScript_fragment", 203);
			LeaveRule("synpred118_JavaScript_fragment", 203);
			Leave_synpred118_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred118_JavaScript

	partial void Enter_synpred121_JavaScript_fragment();
	partial void Leave_synpred121_JavaScript_fragment();

	// $ANTLR start synpred121_JavaScript
	public void synpred121_JavaScript_fragment()
	{
		Enter_synpred121_JavaScript_fragment();
		EnterRule("synpred121_JavaScript_fragment", 206);
		TraceIn("synpred121_JavaScript_fragment", 206);
		try
		{
			// JavaScript.g:201:23: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:201:23: LT
			{
			DebugLocation(201, 23);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred121_JavaScript1188), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred121_JavaScript_fragment", 206);
			LeaveRule("synpred121_JavaScript_fragment", 206);
			Leave_synpred121_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred121_JavaScript

	partial void Enter_synpred139_JavaScript_fragment();
	partial void Leave_synpred139_JavaScript_fragment();

	// $ANTLR start synpred139_JavaScript
	public void synpred139_JavaScript_fragment()
	{
		Enter_synpred139_JavaScript_fragment();
		EnterRule("synpred139_JavaScript_fragment", 224);
		TraceIn("synpred139_JavaScript_fragment", 224);
		try
		{
			// JavaScript.g:230:4: ( conditionalExpression )
			DebugEnterAlt(1);
			// JavaScript.g:230:4: conditionalExpression
			{
			DebugLocation(230, 4);
			PushFollow(Follow._conditionalExpression_in_synpred139_JavaScript1373);
			conditionalExpression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred139_JavaScript_fragment", 224);
			LeaveRule("synpred139_JavaScript_fragment", 224);
			Leave_synpred139_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred139_JavaScript

	partial void Enter_synpred142_JavaScript_fragment();
	partial void Leave_synpred142_JavaScript_fragment();

	// $ANTLR start synpred142_JavaScript
	public void synpred142_JavaScript_fragment()
	{
		Enter_synpred142_JavaScript_fragment();
		EnterRule("synpred142_JavaScript_fragment", 227);
		TraceIn("synpred142_JavaScript_fragment", 227);
		try
		{
			// JavaScript.g:235:4: ( conditionalExpressionNoIn )
			DebugEnterAlt(1);
			// JavaScript.g:235:4: conditionalExpressionNoIn
			{
			DebugLocation(235, 4);
			PushFollow(Follow._conditionalExpressionNoIn_in_synpred142_JavaScript1402);
			conditionalExpressionNoIn();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred142_JavaScript_fragment", 227);
			LeaveRule("synpred142_JavaScript_fragment", 227);
			Leave_synpred142_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred142_JavaScript

	partial void Enter_synpred145_JavaScript_fragment();
	partial void Leave_synpred145_JavaScript_fragment();

	// $ANTLR start synpred145_JavaScript
	public void synpred145_JavaScript_fragment()
	{
		Enter_synpred145_JavaScript_fragment();
		EnterRule("synpred145_JavaScript_fragment", 230);
		TraceIn("synpred145_JavaScript_fragment", 230);
		try
		{
			// JavaScript.g:240:4: ( callExpression )
			DebugEnterAlt(1);
			// JavaScript.g:240:4: callExpression
			{
			DebugLocation(240, 4);
			PushFollow(Follow._callExpression_in_synpred145_JavaScript1431);
			callExpression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred145_JavaScript_fragment", 230);
			LeaveRule("synpred145_JavaScript_fragment", 230);
			Leave_synpred145_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred145_JavaScript

	partial void Enter_synpred146_JavaScript_fragment();
	partial void Leave_synpred146_JavaScript_fragment();

	// $ANTLR start synpred146_JavaScript
	public void synpred146_JavaScript_fragment()
	{
		Enter_synpred146_JavaScript_fragment();
		EnterRule("synpred146_JavaScript_fragment", 231);
		TraceIn("synpred146_JavaScript_fragment", 231);
		try
		{
			// JavaScript.g:245:4: ( memberExpression )
			DebugEnterAlt(1);
			// JavaScript.g:245:4: memberExpression
			{
			DebugLocation(245, 4);
			PushFollow(Follow._memberExpression_in_synpred146_JavaScript1448);
			memberExpression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred146_JavaScript_fragment", 231);
			LeaveRule("synpred146_JavaScript_fragment", 231);
			Leave_synpred146_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred146_JavaScript

	partial void Enter_synpred153_JavaScript_fragment();
	partial void Leave_synpred153_JavaScript_fragment();

	// $ANTLR start synpred153_JavaScript
	public void synpred153_JavaScript_fragment()
	{
		Enter_synpred153_JavaScript_fragment();
		EnterRule("synpred153_JavaScript_fragment", 238);
		TraceIn("synpred153_JavaScript_fragment", 238);
		try
		{
			// JavaScript.g:250:91: ( ( LT )* memberExpressionSuffix )
			DebugEnterAlt(1);
			// JavaScript.g:250:91: ( LT )* memberExpressionSuffix
			{
			DebugLocation(250, 93);
			// JavaScript.g:250:93: ( LT )*
			try { DebugEnterSubRule(262);
			while (true)
			{
				int alt262=2;
				try { DebugEnterDecision(262, decisionCanBacktrack[262]);
				int LA262_0 = input.LA(1);

				if ((LA262_0==LT))
				{
					alt262=1;
				}


				} finally { DebugExitDecision(262); }
				switch ( alt262 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(250, 91);
					new XToken((IToken)Match(input,LT,Follow._LT_in_synpred153_JavaScript1496), "LT"); if (state.failed) return;

					}
					break;

				default:
					goto loop262;
				}
			}

			loop262:
				;

			} finally { DebugExitSubRule(262); }

			DebugLocation(250, 96);
			PushFollow(Follow._memberExpressionSuffix_in_synpred153_JavaScript1500);
			memberExpressionSuffix();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred153_JavaScript_fragment", 238);
			LeaveRule("synpred153_JavaScript_fragment", 238);
			Leave_synpred153_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred153_JavaScript

	partial void Enter_synpred157_JavaScript_fragment();
	partial void Leave_synpred157_JavaScript_fragment();

	// $ANTLR start synpred157_JavaScript
	public void synpred157_JavaScript_fragment()
	{
		Enter_synpred157_JavaScript_fragment();
		EnterRule("synpred157_JavaScript_fragment", 242);
		TraceIn("synpred157_JavaScript_fragment", 242);
		try
		{
			// JavaScript.g:259:37: ( ( LT )* callExpressionSuffix )
			DebugEnterAlt(1);
			// JavaScript.g:259:37: ( LT )* callExpressionSuffix
			{
			DebugLocation(259, 39);
			// JavaScript.g:259:39: ( LT )*
			try { DebugEnterSubRule(263);
			while (true)
			{
				int alt263=2;
				try { DebugEnterDecision(263, decisionCanBacktrack[263]);
				int LA263_0 = input.LA(1);

				if ((LA263_0==LT))
				{
					alt263=1;
				}


				} finally { DebugExitDecision(263); }
				switch ( alt263 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(259, 37);
					new XToken((IToken)Match(input,LT,Follow._LT_in_synpred157_JavaScript1539), "LT"); if (state.failed) return;

					}
					break;

				default:
					goto loop263;
				}
			}

			loop263:
				;

			} finally { DebugExitSubRule(263); }

			DebugLocation(259, 42);
			PushFollow(Follow._callExpressionSuffix_in_synpred157_JavaScript1543);
			callExpressionSuffix();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred157_JavaScript_fragment", 242);
			LeaveRule("synpred157_JavaScript_fragment", 242);
			Leave_synpred157_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred157_JavaScript

	partial void Enter_synpred255_JavaScript_fragment();
	partial void Leave_synpred255_JavaScript_fragment();

	// $ANTLR start synpred255_JavaScript
	public void synpred255_JavaScript_fragment()
	{
		Enter_synpred255_JavaScript_fragment();
		EnterRule("synpred255_JavaScript_fragment", 340);
		TraceIn("synpred255_JavaScript_fragment", 340);
		try
		{
			// JavaScript.g:353:30: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )
			DebugEnterAlt(1);
			// JavaScript.g:353:30: ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression
			{
			DebugLocation(353, 32);
			// JavaScript.g:353:32: ( LT )*
			try { DebugEnterSubRule(308);
			while (true)
			{
				int alt308=2;
				try { DebugEnterDecision(308, decisionCanBacktrack[308]);
				int LA308_0 = input.LA(1);

				if ((LA308_0==LT))
				{
					alt308=1;
				}


				} finally { DebugExitDecision(308); }
				switch ( alt308 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(353, 30);
					new XToken((IToken)Match(input,LT,Follow._LT_in_synpred255_JavaScript2276), "LT"); if (state.failed) return;

					}
					break;

				default:
					goto loop308;
				}
			}

			loop308:
				;

			} finally { DebugExitSubRule(308); }

			DebugLocation(353, 35);
			if ((input.LA(1)>=100 && input.LA(1)<=101))
			{
				input.Consume();
				state.errorRecovery=false;state.failed=false;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return;}
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}

			DebugLocation(353, 49);
			// JavaScript.g:353:49: ( LT )*
			try { DebugEnterSubRule(309);
			while (true)
			{
				int alt309=2;
				try { DebugEnterDecision(309, decisionCanBacktrack[309]);
				int LA309_0 = input.LA(1);

				if ((LA309_0==LT))
				{
					alt309=1;
				}


				} finally { DebugExitDecision(309); }
				switch ( alt309 )
				{
				case 1:
					DebugEnterAlt(1);
					// JavaScript.g:0:0: LT
					{
					DebugLocation(353, 47);
					new XToken((IToken)Match(input,LT,Follow._LT_in_synpred255_JavaScript2288), "LT"); if (state.failed) return;

					}
					break;

				default:
					goto loop309;
				}
			}

			loop309:
				;

			} finally { DebugExitSubRule(309); }

			DebugLocation(353, 52);
			PushFollow(Follow._multiplicativeExpression_in_synpred255_JavaScript2292);
			multiplicativeExpression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred255_JavaScript_fragment", 340);
			LeaveRule("synpred255_JavaScript_fragment", 340);
			Leave_synpred255_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred255_JavaScript

	partial void Enter_synpred279_JavaScript_fragment();
	partial void Leave_synpred279_JavaScript_fragment();

	// $ANTLR start synpred279_JavaScript
	public void synpred279_JavaScript_fragment()
	{
		Enter_synpred279_JavaScript_fragment();
		EnterRule("synpred279_JavaScript_fragment", 364);
		TraceIn("synpred279_JavaScript_fragment", 364);
		try
		{
			// JavaScript.g:380:8: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:380:8: LT
			{
			DebugLocation(380, 8);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred279_JavaScript2466), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred279_JavaScript_fragment", 364);
			LeaveRule("synpred279_JavaScript_fragment", 364);
			Leave_synpred279_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred279_JavaScript

	partial void Enter_synpred286_JavaScript_fragment();
	partial void Leave_synpred286_JavaScript_fragment();

	// $ANTLR start synpred286_JavaScript
	public void synpred286_JavaScript_fragment()
	{
		Enter_synpred286_JavaScript_fragment();
		EnterRule("synpred286_JavaScript_fragment", 371);
		TraceIn("synpred286_JavaScript_fragment", 371);
		try
		{
			// JavaScript.g:385:8: ( LT )
			DebugEnterAlt(1);
			// JavaScript.g:385:8: LT
			{
			DebugLocation(385, 8);
			new XToken((IToken)Match(input,LT,Follow._LT_in_synpred286_JavaScript2516), "LT"); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred286_JavaScript_fragment", 371);
			LeaveRule("synpred286_JavaScript_fragment", 371);
			Leave_synpred286_JavaScript_fragment();
		}
	}
	// $ANTLR end synpred286_JavaScript
	#endregion Rules

	#region Synpreds
	private bool EvaluatePredicate(System.Action fragment)
	{
		bool success = false;
		state.backtracking++;
		try { DebugBeginBacktrack(state.backtracking);
		int start = input.Mark();
		try
		{
			fragment();
		}
		catch ( RecognitionException re )
		{
			System.Console.Error.WriteLine("impossible: "+re);
		}
		success = !state.failed;
		input.Rewind(start);
		} finally { DebugEndBacktrack(state.backtracking, success); }
		state.backtracking--;
		state.failed=false;
		return success;
	}
	#endregion Synpreds


	#region DFA
	DFA1 dfa1;
	DFA5 dfa5;
	DFA6 dfa6;
	DFA18 dfa18;
	DFA17 dfa17;
	DFA23 dfa23;
	DFA28 dfa28;
	DFA32 dfa32;
	DFA35 dfa35;
	DFA37 dfa37;
	DFA39 dfa39;
	DFA59 dfa59;
	DFA62 dfa62;
	DFA65 dfa65;
	DFA80 dfa80;
	DFA92 dfa92;
	DFA96 dfa96;
	DFA95 dfa95;
	DFA108 dfa108;
	DFA117 dfa117;
	DFA120 dfa120;
	DFA123 dfa123;
	DFA126 dfa126;
	DFA127 dfa127;
	DFA129 dfa129;
	DFA134 dfa134;
	DFA138 dfa138;
	DFA144 dfa144;
	DFA143 dfa143;
	DFA153 dfa153;
	DFA158 dfa158;
	DFA161 dfa161;
	DFA164 dfa164;
	DFA167 dfa167;
	DFA170 dfa170;
	DFA173 dfa173;
	DFA176 dfa176;
	DFA179 dfa179;
	DFA182 dfa182;
	DFA185 dfa185;
	DFA188 dfa188;
	DFA191 dfa191;
	DFA194 dfa194;
	DFA197 dfa197;
	DFA200 dfa200;
	DFA203 dfa203;
	DFA206 dfa206;
	DFA209 dfa209;
	DFA211 dfa211;
	DFA220 dfa220;
	DFA219 dfa219;
	DFA227 dfa227;
	DFA226 dfa226;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa1 = new DFA1( this, SpecialStateTransition1 );
		dfa5 = new DFA5( this );
		dfa6 = new DFA6( this, SpecialStateTransition6 );
		dfa18 = new DFA18( this );
		dfa17 = new DFA17( this );
		dfa23 = new DFA23( this, SpecialStateTransition23 );
		dfa28 = new DFA28( this );
		dfa32 = new DFA32( this );
		dfa35 = new DFA35( this );
		dfa37 = new DFA37( this );
		dfa39 = new DFA39( this );
		dfa59 = new DFA59( this );
		dfa62 = new DFA62( this );
		dfa65 = new DFA65( this );
		dfa80 = new DFA80( this, SpecialStateTransition80 );
		dfa92 = new DFA92( this );
		dfa96 = new DFA96( this );
		dfa95 = new DFA95( this );
		dfa108 = new DFA108( this );
		dfa117 = new DFA117( this );
		dfa120 = new DFA120( this );
		dfa123 = new DFA123( this, SpecialStateTransition123 );
		dfa126 = new DFA126( this, SpecialStateTransition126 );
		dfa127 = new DFA127( this, SpecialStateTransition127 );
		dfa129 = new DFA129( this, SpecialStateTransition129 );
		dfa134 = new DFA134( this, SpecialStateTransition134 );
		dfa138 = new DFA138( this, SpecialStateTransition138 );
		dfa144 = new DFA144( this );
		dfa143 = new DFA143( this );
		dfa153 = new DFA153( this );
		dfa158 = new DFA158( this );
		dfa161 = new DFA161( this );
		dfa164 = new DFA164( this );
		dfa167 = new DFA167( this );
		dfa170 = new DFA170( this );
		dfa173 = new DFA173( this );
		dfa176 = new DFA176( this );
		dfa179 = new DFA179( this );
		dfa182 = new DFA182( this );
		dfa185 = new DFA185( this );
		dfa188 = new DFA188( this );
		dfa191 = new DFA191( this );
		dfa194 = new DFA194( this );
		dfa197 = new DFA197( this );
		dfa200 = new DFA200( this );
		dfa203 = new DFA203( this );
		dfa206 = new DFA206( this, SpecialStateTransition206 );
		dfa209 = new DFA209( this );
		dfa211 = new DFA211( this, SpecialStateTransition211 );
		dfa220 = new DFA220( this );
		dfa219 = new DFA219( this );
		dfa227 = new DFA227( this );
		dfa226 = new DFA226( this );
	}

	private class DFA1 : DFA
	{
		private const string DFA1_eotS =
			"\xB\xFFFF";
		private const string DFA1_eofS =
			"\x1\x5\x4\xFFFF\x1\xA\x4\xFFFF\x1\x9";
		private const string DFA1_minS =
			"\x1\x4\x2\x0\x2\xFFFF\x1\x4\x4\xFFFF\x1\x0";
		private const string DFA1_maxS =
			"\x1\x6F\x2\x0\x2\xFFFF\x1\x6F\x4\xFFFF\x1\x0";
		private const string DFA1_acceptS =
			"\x3\xFFFF\x1\x3\x1\x4\x1\xFFFF\x1\x6\x1\x1\x1\x2\x1\x5\x1\xFFFF";
		private const string DFA1_specialS =
			"\x1\xFFFF\x1\x0\x1\x1\x8\xFFFF}>";
		private static readonly string[] DFA1_transitionS =
			{
				"\x4\x6\x2\xFFFF\x1\x6\x1\x2\x1\x3\x1\x4\x4\x6\x19\xFFFF\x1\x1\x2\x6"+
				"\x1\xFFFF\x2\x6\x1\xFFFF\x5\x6\x1\xFFFF\x4\x6\x1\xFFFF\x5\x6\x2\xFFFF"+
				"\x2\x6\x1E\xFFFF\x2\x6\x3\xFFFF\x7\x6",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"",
				"",
				"\x4\x9\x2\xFFFF\x2\x9\x2\xFFFF\x4\x9\x19\xFFFF\x3\x9\x1\xFFFF\x2\x9"+
				"\x1\xFFFF\x5\x9\x1\xFFFF\x4\x9\x1\xFFFF\x5\x9\x2\xFFFF\x2\x9\x1E\xFFFF"+
				"\x2\x9\x3\xFFFF\x7\x9",
				"",
				"",
				"",
				"",
				"\x1\xFFFF"
			};

		private static readonly short[] DFA1_eot = DFA.UnpackEncodedString(DFA1_eotS);
		private static readonly short[] DFA1_eof = DFA.UnpackEncodedString(DFA1_eofS);
		private static readonly char[] DFA1_min = DFA.UnpackEncodedStringToUnsignedChars(DFA1_minS);
		private static readonly char[] DFA1_max = DFA.UnpackEncodedStringToUnsignedChars(DFA1_maxS);
		private static readonly short[] DFA1_accept = DFA.UnpackEncodedString(DFA1_acceptS);
		private static readonly short[] DFA1_special = DFA.UnpackEncodedString(DFA1_specialS);
		private static readonly short[][] DFA1_transition;

		static DFA1()
		{
			int numStates = DFA1_transitionS.Length;
			DFA1_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA1_transition[i] = DFA.UnpackEncodedString(DFA1_transitionS[i]);
			}
		}

		public DFA1( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 1;
			this.eot = DFA1_eot;
			this.eof = DFA1_eof;
			this.min = DFA1_min;
			this.max = DFA1_max;
			this.accept = DFA1_accept;
			this.special = DFA1_special;
			this.transition = DFA1_transition;
		}

		public override string Description { get { return "30:1: statementEnd : ( ';' | LT | Comment | LineComment | EOF | {...}?);"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition1(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA1_1 = input.LA(1);


				int index1_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred1_JavaScript_fragment)) ) {s = 7;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 6;}


				input.Seek(index1_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA1_2 = input.LA(1);


				int index1_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred2_JavaScript_fragment)) ) {s = 8;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 6;}


				input.Seek(index1_2);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 1, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA5 : DFA
	{
		private const string DFA5_eotS =
			"\x4\xFFFF";
		private const string DFA5_eofS =
			"\x2\x2\x2\xFFFF";
		private const string DFA5_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA5_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA5_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA5_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA5_transitionS =
			{
				"\x4\x3\x2\xFFFF\x1\x2\x1\x1\x2\xFFFF\x4\x3\x19\xFFFF\x3\x3\x1\xFFFF"+
				"\x2\x3\x1\xFFFF\x1\x3\x1\xFFFF\x3\x3\x1\xFFFF\x4\x3\x1\xFFFF\x1\x3\x2"+
				"\xFFFF\x2\x3\x2\xFFFF\x2\x3\x1E\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"\x4\x3\x2\xFFFF\x1\x2\x1\x1\x2\xFFFF\x4\x3\x19\xFFFF\x3\x3\x1\xFFFF"+
				"\x2\x3\x1\xFFFF\x1\x3\x1\xFFFF\x3\x3\x1\xFFFF\x4\x3\x1\xFFFF\x1\x3\x2"+
				"\xFFFF\x2\x3\x2\xFFFF\x2\x3\x1E\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"",
				""
			};

		private static readonly short[] DFA5_eot = DFA.UnpackEncodedString(DFA5_eotS);
		private static readonly short[] DFA5_eof = DFA.UnpackEncodedString(DFA5_eofS);
		private static readonly char[] DFA5_min = DFA.UnpackEncodedStringToUnsignedChars(DFA5_minS);
		private static readonly char[] DFA5_max = DFA.UnpackEncodedStringToUnsignedChars(DFA5_maxS);
		private static readonly short[] DFA5_accept = DFA.UnpackEncodedString(DFA5_acceptS);
		private static readonly short[] DFA5_special = DFA.UnpackEncodedString(DFA5_specialS);
		private static readonly short[][] DFA5_transition;

		static DFA5()
		{
			int numStates = DFA5_transitionS.Length;
			DFA5_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA5_transition[i] = DFA.UnpackEncodedString(DFA5_transitionS[i]);
			}
		}

		public DFA5( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 5;
			this.eot = DFA5_eot;
			this.eof = DFA5_eof;
			this.min = DFA5_min;
			this.max = DFA5_max;
			this.accept = DFA5_accept;
			this.special = DFA5_special;
			this.transition = DFA5_transition;
		}

		public override string Description { get { return "()* loopback of 44:18: ( ( LT )* sourceElement )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA6 : DFA
	{
		private const string DFA6_eotS =
			"\x1D\xFFFF";
		private const string DFA6_eofS =
			"\x1D\xFFFF";
		private const string DFA6_minS =
			"\x1\x4\x1\x0\x1B\xFFFF";
		private const string DFA6_maxS =
			"\x1\x6F\x1\x0\x1B\xFFFF";
		private const string DFA6_acceptS =
			"\x2\xFFFF\x1\x2\x19\xFFFF\x1\x1";
		private const string DFA6_specialS =
			"\x1\xFFFF\x1\x0\x1B\xFFFF}>";
		private static readonly string[] DFA6_transitionS =
			{
				"\x4\x2\x6\xFFFF\x4\x2\x19\xFFFF\x1\x2\x1\x1\x1\x2\x1\xFFFF\x2\x2\x1"+
				"\xFFFF\x1\x2\x1\xFFFF\x3\x2\x1\xFFFF\x4\x2\x1\xFFFF\x1\x2\x2\xFFFF\x2"+
				"\x2\x2\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA6_eot = DFA.UnpackEncodedString(DFA6_eotS);
		private static readonly short[] DFA6_eof = DFA.UnpackEncodedString(DFA6_eofS);
		private static readonly char[] DFA6_min = DFA.UnpackEncodedStringToUnsignedChars(DFA6_minS);
		private static readonly char[] DFA6_max = DFA.UnpackEncodedStringToUnsignedChars(DFA6_maxS);
		private static readonly short[] DFA6_accept = DFA.UnpackEncodedString(DFA6_acceptS);
		private static readonly short[] DFA6_special = DFA.UnpackEncodedString(DFA6_specialS);
		private static readonly short[][] DFA6_transition;

		static DFA6()
		{
			int numStates = DFA6_transitionS.Length;
			DFA6_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA6_transition[i] = DFA.UnpackEncodedString(DFA6_transitionS[i]);
			}
		}

		public DFA6( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 6;
			this.eot = DFA6_eot;
			this.eof = DFA6_eof;
			this.min = DFA6_min;
			this.max = DFA6_max;
			this.accept = DFA6_accept;
			this.special = DFA6_special;
			this.transition = DFA6_transition;
		}

		public override string Description { get { return "47:1: sourceElement : ( functionDeclaration | statement );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition6(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA6_1 = input.LA(1);


				int index6_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred10_JavaScript_fragment)) ) {s = 28;}

				else if ( (true) ) {s = 2;}


				input.Seek(index6_1);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 6, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA18 : DFA
	{
		private const string DFA18_eotS =
			"\x4\xFFFF";
		private const string DFA18_eofS =
			"\x4\xFFFF";
		private const string DFA18_minS =
			"\x2\x9\x2\xFFFF";
		private const string DFA18_maxS =
			"\x2\xE\x2\xFFFF";
		private const string DFA18_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA18_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA18_transitionS =
			{
				"\x1\x3\x1\xFFFF\x1\x1\x2\xFFFF\x1\x2",
				"\x1\x3\x1\xFFFF\x1\x1\x2\xFFFF\x1\x2",
				"",
				""
			};

		private static readonly short[] DFA18_eot = DFA.UnpackEncodedString(DFA18_eotS);
		private static readonly short[] DFA18_eof = DFA.UnpackEncodedString(DFA18_eofS);
		private static readonly char[] DFA18_min = DFA.UnpackEncodedStringToUnsignedChars(DFA18_minS);
		private static readonly char[] DFA18_max = DFA.UnpackEncodedStringToUnsignedChars(DFA18_maxS);
		private static readonly short[] DFA18_accept = DFA.UnpackEncodedString(DFA18_acceptS);
		private static readonly short[] DFA18_special = DFA.UnpackEncodedString(DFA18_specialS);
		private static readonly short[][] DFA18_transition;

		static DFA18()
		{
			int numStates = DFA18_transitionS.Length;
			DFA18_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA18_transition[i] = DFA.UnpackEncodedString(DFA18_transitionS[i]);
			}
		}

		public DFA18( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 18;
			this.eot = DFA18_eot;
			this.eof = DFA18_eof;
			this.min = DFA18_min;
			this.max = DFA18_max;
			this.accept = DFA18_accept;
			this.special = DFA18_special;
			this.transition = DFA18_transition;
		}

		public override string Description { get { return "62:8: ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA17 : DFA
	{
		private const string DFA17_eotS =
			"\x4\xFFFF";
		private const string DFA17_eofS =
			"\x4\xFFFF";
		private const string DFA17_minS =
			"\x2\x9\x2\xFFFF";
		private const string DFA17_maxS =
			"\x2\x2E\x2\xFFFF";
		private const string DFA17_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA17_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA17_transitionS =
			{
				"\x1\x2\x1\xFFFF\x1\x1\x22\xFFFF\x1\x3",
				"\x1\x2\x1\xFFFF\x1\x1\x22\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA17_eot = DFA.UnpackEncodedString(DFA17_eotS);
		private static readonly short[] DFA17_eof = DFA.UnpackEncodedString(DFA17_eofS);
		private static readonly char[] DFA17_min = DFA.UnpackEncodedStringToUnsignedChars(DFA17_minS);
		private static readonly char[] DFA17_max = DFA.UnpackEncodedStringToUnsignedChars(DFA17_maxS);
		private static readonly short[] DFA17_accept = DFA.UnpackEncodedString(DFA17_acceptS);
		private static readonly short[] DFA17_special = DFA.UnpackEncodedString(DFA17_specialS);
		private static readonly short[][] DFA17_transition;

		static DFA17()
		{
			int numStates = DFA17_transitionS.Length;
			DFA17_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA17_transition[i] = DFA.UnpackEncodedString(DFA17_transitionS[i]);
			}
		}

		public DFA17( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 17;
			this.eot = DFA17_eot;
			this.eof = DFA17_eof;
			this.min = DFA17_min;
			this.max = DFA17_max;
			this.accept = DFA17_accept;
			this.special = DFA17_special;
			this.transition = DFA17_transition;
		}

		public override string Description { get { return "()* loopback of 62:25: ( ( LT )* ',' ( LT )* Identifier )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA23 : DFA
	{
		private const string DFA23_eotS =
			"\x1E\xFFFF";
		private const string DFA23_eofS =
			"\x1E\xFFFF";
		private const string DFA23_minS =
			"\x1\x4\x1\x0\x3\xFFFF\x1\x0\x18\xFFFF";
		private const string DFA23_maxS =
			"\x1\x6F\x1\x0\x3\xFFFF\x1\x0\x18\xFFFF";
		private const string DFA23_acceptS =
			"\x2\xFFFF\x1\x2\x1\x3\x1\x4\xC\xFFFF\x1\x5\x1\x6\x2\xFFFF\x1\x7\x1\x8"+
			"\x1\x9\x1\xA\x1\xC\x1\xD\x1\xE\x1\x1\x1\xB";
		private const string DFA23_specialS =
			"\x1\xFFFF\x1\x0\x3\xFFFF\x1\x1\x18\xFFFF}>";
		private static readonly string[] DFA23_transitionS =
			{
				"\x4\x4\x6\xFFFF\x1\x5\x3\x4\x19\xFFFF\x1\x3\x2\x4\x1\xFFFF\x1\x1\x1"+
				"\x2\x1\xFFFF\x1\x11\x1\xFFFF\x3\x12\x1\xFFFF\x1\x15\x1\x16\x1\x17\x1"+
				"\x18\x1\xFFFF\x1\x19\x2\xFFFF\x1\x1A\x1\x1B\x2\xFFFF\x2\x4\x1E\xFFFF"+
				"\x2\x4\x3\xFFFF\x7\x4",
				"\x1\xFFFF",
				"",
				"",
				"",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA23_eot = DFA.UnpackEncodedString(DFA23_eotS);
		private static readonly short[] DFA23_eof = DFA.UnpackEncodedString(DFA23_eofS);
		private static readonly char[] DFA23_min = DFA.UnpackEncodedStringToUnsignedChars(DFA23_minS);
		private static readonly char[] DFA23_max = DFA.UnpackEncodedStringToUnsignedChars(DFA23_maxS);
		private static readonly short[] DFA23_accept = DFA.UnpackEncodedString(DFA23_acceptS);
		private static readonly short[] DFA23_special = DFA.UnpackEncodedString(DFA23_specialS);
		private static readonly short[][] DFA23_transition;

		static DFA23()
		{
			int numStates = DFA23_transitionS.Length;
			DFA23_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA23_transition[i] = DFA.UnpackEncodedString(DFA23_transitionS[i]);
			}
		}

		public DFA23( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 23;
			this.eot = DFA23_eot;
			this.eof = DFA23_eof;
			this.min = DFA23_min;
			this.max = DFA23_max;
			this.accept = DFA23_accept;
			this.special = DFA23_special;
			this.transition = DFA23_transition;
		}

		public override string Description { get { return "70:1: statement : ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition23(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA23_1 = input.LA(1);


				int index23_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_JavaScript_fragment)) ) {s = 28;}

				else if ( (EvaluatePredicate(synpred30_JavaScript_fragment)) ) {s = 4;}


				input.Seek(index23_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA23_5 = input.LA(1);


				int index23_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred30_JavaScript_fragment)) ) {s = 4;}

				else if ( (EvaluatePredicate(synpred37_JavaScript_fragment)) ) {s = 29;}


				input.Seek(index23_5);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 23, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA28 : DFA
	{
		private const string DFA28_eotS =
			"\x4\xFFFF";
		private const string DFA28_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA28_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA28_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA28_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA28_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA28_transitionS =
			{
				"\x4\x3\x2\xFFFF\x1\x2\x1\x1\x2\xFFFF\x4\x3\x19\xFFFF\x3\x3\x1\xFFFF"+
				"\x2\x3\x1\xFFFF\x1\x3\x1\xFFFF\x3\x3\x1\xFFFF\x4\x3\x1\xFFFF\x1\x3\x2"+
				"\x2\x2\x3\x2\xFFFF\x2\x3\x1E\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"\x4\x3\x2\xFFFF\x1\x2\x1\x1\x2\xFFFF\x4\x3\x19\xFFFF\x3\x3\x1\xFFFF"+
				"\x2\x3\x1\xFFFF\x1\x3\x1\xFFFF\x3\x3\x1\xFFFF\x4\x3\x1\xFFFF\x1\x3\x2"+
				"\x2\x2\x3\x2\xFFFF\x2\x3\x1E\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"",
				""
			};

		private static readonly short[] DFA28_eot = DFA.UnpackEncodedString(DFA28_eotS);
		private static readonly short[] DFA28_eof = DFA.UnpackEncodedString(DFA28_eofS);
		private static readonly char[] DFA28_min = DFA.UnpackEncodedStringToUnsignedChars(DFA28_minS);
		private static readonly char[] DFA28_max = DFA.UnpackEncodedStringToUnsignedChars(DFA28_maxS);
		private static readonly short[] DFA28_accept = DFA.UnpackEncodedString(DFA28_acceptS);
		private static readonly short[] DFA28_special = DFA.UnpackEncodedString(DFA28_specialS);
		private static readonly short[][] DFA28_transition;

		static DFA28()
		{
			int numStates = DFA28_transitionS.Length;
			DFA28_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA28_transition[i] = DFA.UnpackEncodedString(DFA28_transitionS[i]);
			}
		}

		public DFA28( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 28;
			this.eot = DFA28_eot;
			this.eof = DFA28_eof;
			this.min = DFA28_min;
			this.max = DFA28_max;
			this.accept = DFA28_accept;
			this.special = DFA28_special;
			this.transition = DFA28_transition;
		}

		public override string Description { get { return "()* loopback of 92:14: ( ( LT )* statement )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA32 : DFA
	{
		private const string DFA32_eotS =
			"\x5\xFFFF";
		private const string DFA32_eofS =
			"\x1\x1\x1\xFFFF\x1\x1\x1\xFFFF\x1\x1";
		private const string DFA32_minS =
			"\x1\x4\x1\xFFFF\x1\x4\x1\xFFFF\x1\x4";
		private const string DFA32_maxS =
			"\x1\x6F\x1\xFFFF\x1\x6F\x1\xFFFF\x1\x6F";
		private const string DFA32_acceptS =
			"\x1\xFFFF\x1\x2\x1\xFFFF\x1\x1\x1\xFFFF";
		private const string DFA32_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA32_transitionS =
			{
				"\x4\x1\x2\xFFFF\x1\x1\x1\x2\x6\x1\x19\xFFFF\x3\x1\x1\x3\x2\x1\x1\xFFFF"+
				"\x5\x1\x1\xFFFF\x4\x1\x1\xFFFF\x5\x1\x2\xFFFF\x2\x1\x1E\xFFFF\x2\x1"+
				"\x3\xFFFF\x7\x1",
				"",
				"\x4\x1\x2\xFFFF\x1\x1\x1\x4\x2\xFFFF\x4\x1\x19\xFFFF\x3\x1\x1\x3\x2"+
				"\x1\x1\xFFFF\x5\x1\x1\xFFFF\x4\x1\x1\xFFFF\x5\x1\x2\xFFFF\x2\x1\x1E"+
				"\xFFFF\x2\x1\x3\xFFFF\x7\x1",
				"",
				"\x4\x1\x2\xFFFF\x1\x1\x1\x4\x2\xFFFF\x4\x1\x19\xFFFF\x3\x1\x1\x3\x2"+
				"\x1\x1\xFFFF\x5\x1\x1\xFFFF\x4\x1\x1\xFFFF\x5\x1\x2\xFFFF\x2\x1\x1E"+
				"\xFFFF\x2\x1\x3\xFFFF\x7\x1"
			};

		private static readonly short[] DFA32_eot = DFA.UnpackEncodedString(DFA32_eotS);
		private static readonly short[] DFA32_eof = DFA.UnpackEncodedString(DFA32_eofS);
		private static readonly char[] DFA32_min = DFA.UnpackEncodedStringToUnsignedChars(DFA32_minS);
		private static readonly char[] DFA32_max = DFA.UnpackEncodedStringToUnsignedChars(DFA32_maxS);
		private static readonly short[] DFA32_accept = DFA.UnpackEncodedString(DFA32_acceptS);
		private static readonly short[] DFA32_special = DFA.UnpackEncodedString(DFA32_specialS);
		private static readonly short[][] DFA32_transition;

		static DFA32()
		{
			int numStates = DFA32_transitionS.Length;
			DFA32_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA32_transition[i] = DFA.UnpackEncodedString(DFA32_transitionS[i]);
			}
		}

		public DFA32( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 32;
			this.eot = DFA32_eot;
			this.eof = DFA32_eof;
			this.min = DFA32_min;
			this.max = DFA32_max;
			this.accept = DFA32_accept;
			this.special = DFA32_special;
			this.transition = DFA32_transition;
		}

		public override string Description { get { return "()* loopback of 100:24: ( ( LT )* ',' ( LT )* variableDeclaration )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA35 : DFA
	{
		private const string DFA35_eotS =
			"\x4\xFFFF";
		private const string DFA35_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA35_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA35_maxS =
			"\x2\x2E\x2\xFFFF";
		private const string DFA35_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA35_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA35_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA35_eot = DFA.UnpackEncodedString(DFA35_eotS);
		private static readonly short[] DFA35_eof = DFA.UnpackEncodedString(DFA35_eofS);
		private static readonly char[] DFA35_min = DFA.UnpackEncodedStringToUnsignedChars(DFA35_minS);
		private static readonly char[] DFA35_max = DFA.UnpackEncodedStringToUnsignedChars(DFA35_maxS);
		private static readonly short[] DFA35_accept = DFA.UnpackEncodedString(DFA35_acceptS);
		private static readonly short[] DFA35_special = DFA.UnpackEncodedString(DFA35_specialS);
		private static readonly short[][] DFA35_transition;

		static DFA35()
		{
			int numStates = DFA35_transitionS.Length;
			DFA35_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA35_transition[i] = DFA.UnpackEncodedString(DFA35_transitionS[i]);
			}
		}

		public DFA35( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 35;
			this.eot = DFA35_eot;
			this.eof = DFA35_eof;
			this.min = DFA35_min;
			this.max = DFA35_max;
			this.accept = DFA35_accept;
			this.special = DFA35_special;
			this.transition = DFA35_transition;
		}

		public override string Description { get { return "()* loopback of 104:28: ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA37 : DFA
	{
		private const string DFA37_eotS =
			"\x5\xFFFF";
		private const string DFA37_eofS =
			"\x2\x3\x2\xFFFF\x1\x3";
		private const string DFA37_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA37_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA37_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2\x1\xFFFF";
		private const string DFA37_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA37_transitionS =
			{
				"\x4\x3\x2\xFFFF\x1\x3\x1\x1\x6\x3\x19\xFFFF\x6\x3\x1\x2\x5\x3\x1\xFFFF"+
				"\x4\x3\x1\xFFFF\x5\x3\x2\xFFFF\x2\x3\x1E\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"\x4\x3\x2\xFFFF\x1\x3\x1\x4\x2\xFFFF\x4\x3\x19\xFFFF\x6\x3\x1\x2\x5"+
				"\x3\x1\xFFFF\x4\x3\x1\xFFFF\x5\x3\x2\xFFFF\x2\x3\x1E\xFFFF\x2\x3\x3"+
				"\xFFFF\x7\x3",
				"",
				"",
				"\x4\x3\x2\xFFFF\x1\x3\x1\x4\x2\xFFFF\x4\x3\x19\xFFFF\x6\x3\x1\x2\x5"+
				"\x3\x1\xFFFF\x4\x3\x1\xFFFF\x5\x3\x2\xFFFF\x2\x3\x1E\xFFFF\x2\x3\x3"+
				"\xFFFF\x7\x3"
			};

		private static readonly short[] DFA37_eot = DFA.UnpackEncodedString(DFA37_eotS);
		private static readonly short[] DFA37_eof = DFA.UnpackEncodedString(DFA37_eofS);
		private static readonly char[] DFA37_min = DFA.UnpackEncodedStringToUnsignedChars(DFA37_minS);
		private static readonly char[] DFA37_max = DFA.UnpackEncodedStringToUnsignedChars(DFA37_maxS);
		private static readonly short[] DFA37_accept = DFA.UnpackEncodedString(DFA37_acceptS);
		private static readonly short[] DFA37_special = DFA.UnpackEncodedString(DFA37_specialS);
		private static readonly short[][] DFA37_transition;

		static DFA37()
		{
			int numStates = DFA37_transitionS.Length;
			DFA37_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA37_transition[i] = DFA.UnpackEncodedString(DFA37_transitionS[i]);
			}
		}

		public DFA37( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 37;
			this.eot = DFA37_eot;
			this.eof = DFA37_eof;
			this.min = DFA37_min;
			this.max = DFA37_max;
			this.accept = DFA37_accept;
			this.special = DFA37_special;
			this.transition = DFA37_transition;
		}

		public override string Description { get { return "108:15: ( ( LT )* initialiser )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA39 : DFA
	{
		private const string DFA39_eotS =
			"\x4\xFFFF";
		private const string DFA39_eofS =
			"\x1\x3\x3\xFFFF";
		private const string DFA39_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA39_maxS =
			"\x2\x37\x2\xFFFF";
		private const string DFA39_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA39_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA39_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x3\x2\xFFFF\x1\x3\x2\xFFFF\x1\x2\x5\xFFFF\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x3\x2\xFFFF\x1\x3\x2\xFFFF\x1\x2\x5\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA39_eot = DFA.UnpackEncodedString(DFA39_eotS);
		private static readonly short[] DFA39_eof = DFA.UnpackEncodedString(DFA39_eofS);
		private static readonly char[] DFA39_min = DFA.UnpackEncodedStringToUnsignedChars(DFA39_minS);
		private static readonly char[] DFA39_max = DFA.UnpackEncodedStringToUnsignedChars(DFA39_maxS);
		private static readonly short[] DFA39_accept = DFA.UnpackEncodedString(DFA39_acceptS);
		private static readonly short[] DFA39_special = DFA.UnpackEncodedString(DFA39_specialS);
		private static readonly short[][] DFA39_transition;

		static DFA39()
		{
			int numStates = DFA39_transitionS.Length;
			DFA39_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA39_transition[i] = DFA.UnpackEncodedString(DFA39_transitionS[i]);
			}
		}

		public DFA39( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 39;
			this.eot = DFA39_eot;
			this.eof = DFA39_eof;
			this.min = DFA39_min;
			this.max = DFA39_max;
			this.accept = DFA39_accept;
			this.special = DFA39_special;
			this.transition = DFA39_transition;
		}

		public override string Description { get { return "112:15: ( ( LT )* initialiserNoIn )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA59 : DFA
	{
		private const string DFA59_eotS =
			"\x4\xFFFF";
		private const string DFA59_eofS =
			"\x4\xFFFF";
		private const string DFA59_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA59_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA59_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA59_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA59_transitionS =
			{
				"\x4\x2\x3\xFFFF\x1\x1\x2\xFFFF\x4\x2\x19\xFFFF\x1\x3\x2\x2\x1\xFFFF"+
				"\x2\x2\x13\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x4\x2\x3\xFFFF\x1\x1\x2\xFFFF\x4\x2\x19\xFFFF\x1\x3\x2\x2\x1\xFFFF"+
				"\x2\x2\x13\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"",
				""
			};

		private static readonly short[] DFA59_eot = DFA.UnpackEncodedString(DFA59_eotS);
		private static readonly short[] DFA59_eof = DFA.UnpackEncodedString(DFA59_eofS);
		private static readonly char[] DFA59_min = DFA.UnpackEncodedStringToUnsignedChars(DFA59_minS);
		private static readonly char[] DFA59_max = DFA.UnpackEncodedStringToUnsignedChars(DFA59_maxS);
		private static readonly short[] DFA59_accept = DFA.UnpackEncodedString(DFA59_acceptS);
		private static readonly short[] DFA59_special = DFA.UnpackEncodedString(DFA59_specialS);
		private static readonly short[][] DFA59_transition;

		static DFA59()
		{
			int numStates = DFA59_transitionS.Length;
			DFA59_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA59_transition[i] = DFA.UnpackEncodedString(DFA59_transitionS[i]);
			}
		}

		public DFA59( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 59;
			this.eot = DFA59_eot;
			this.eof = DFA59_eof;
			this.min = DFA59_min;
			this.max = DFA59_max;
			this.accept = DFA59_accept;
			this.special = DFA59_special;
			this.transition = DFA59_transition;
		}

		public override string Description { get { return "151:19: ( ( LT )* forStatementInitialiserPart )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA62 : DFA
	{
		private const string DFA62_eotS =
			"\x4\xFFFF";
		private const string DFA62_eofS =
			"\x4\xFFFF";
		private const string DFA62_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA62_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA62_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA62_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA62_transitionS =
			{
				"\x4\x2\x3\xFFFF\x1\x1\x2\xFFFF\x4\x2\x19\xFFFF\x1\x3\x2\x2\x1\xFFFF"+
				"\x1\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x4\x2\x3\xFFFF\x1\x1\x2\xFFFF\x4\x2\x19\xFFFF\x1\x3\x2\x2\x1\xFFFF"+
				"\x1\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"",
				""
			};

		private static readonly short[] DFA62_eot = DFA.UnpackEncodedString(DFA62_eotS);
		private static readonly short[] DFA62_eof = DFA.UnpackEncodedString(DFA62_eofS);
		private static readonly char[] DFA62_min = DFA.UnpackEncodedStringToUnsignedChars(DFA62_minS);
		private static readonly char[] DFA62_max = DFA.UnpackEncodedStringToUnsignedChars(DFA62_maxS);
		private static readonly short[] DFA62_accept = DFA.UnpackEncodedString(DFA62_acceptS);
		private static readonly short[] DFA62_special = DFA.UnpackEncodedString(DFA62_specialS);
		private static readonly short[][] DFA62_transition;

		static DFA62()
		{
			int numStates = DFA62_transitionS.Length;
			DFA62_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA62_transition[i] = DFA.UnpackEncodedString(DFA62_transitionS[i]);
			}
		}

		public DFA62( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 62;
			this.eot = DFA62_eot;
			this.eof = DFA62_eof;
			this.min = DFA62_min;
			this.max = DFA62_max;
			this.accept = DFA62_accept;
			this.special = DFA62_special;
			this.transition = DFA62_transition;
		}

		public override string Description { get { return "151:64: ( ( LT )* expression )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA65 : DFA
	{
		private const string DFA65_eotS =
			"\x4\xFFFF";
		private const string DFA65_eofS =
			"\x4\xFFFF";
		private const string DFA65_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA65_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA65_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA65_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA65_transitionS =
			{
				"\x4\x2\x1\xFFFF\x1\x3\x1\xFFFF\x1\x1\x2\xFFFF\x4\x2\x1A\xFFFF\x2\x2"+
				"\x1\xFFFF\x1\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x4\x2\x1\xFFFF\x1\x3\x1\xFFFF\x1\x1\x2\xFFFF\x4\x2\x1A\xFFFF\x2\x2"+
				"\x1\xFFFF\x1\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"",
				""
			};

		private static readonly short[] DFA65_eot = DFA.UnpackEncodedString(DFA65_eotS);
		private static readonly short[] DFA65_eof = DFA.UnpackEncodedString(DFA65_eofS);
		private static readonly char[] DFA65_min = DFA.UnpackEncodedStringToUnsignedChars(DFA65_minS);
		private static readonly char[] DFA65_max = DFA.UnpackEncodedStringToUnsignedChars(DFA65_maxS);
		private static readonly short[] DFA65_accept = DFA.UnpackEncodedString(DFA65_acceptS);
		private static readonly short[] DFA65_special = DFA.UnpackEncodedString(DFA65_specialS);
		private static readonly short[][] DFA65_transition;

		static DFA65()
		{
			int numStates = DFA65_transitionS.Length;
			DFA65_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA65_transition[i] = DFA.UnpackEncodedString(DFA65_transitionS[i]);
			}
		}

		public DFA65( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 65;
			this.eot = DFA65_eot;
			this.eof = DFA65_eof;
			this.min = DFA65_min;
			this.max = DFA65_max;
			this.accept = DFA65_accept;
			this.special = DFA65_special;
			this.transition = DFA65_transition;
		}

		public override string Description { get { return "151:92: ( ( LT )* expression )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA80 : DFA
	{
		private const string DFA80_eotS =
			"\x25\xFFFF";
		private const string DFA80_eofS =
			"\x1\xF\x24\xFFFF";
		private const string DFA80_minS =
			"\x1\x4\xE\x0\x16\xFFFF";
		private const string DFA80_maxS =
			"\x1\x6F\xE\x0\x16\xFFFF";
		private const string DFA80_acceptS =
			"\xF\xFFFF\x1\x2\x14\xFFFF\x1\x1";
		private const string DFA80_specialS =
			"\x1\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1\x9"+
			"\x1\xA\x1\xB\x1\xC\x1\xD\x16\xFFFF}>";
		private static readonly string[] DFA80_transitionS =
			{
				"\x1\x3\x1\x4\x1\x5\x1\x1\x2\xFFFF\x4\xF\x1\x2\x1\x7\x1\x6\x1\x8\x19"+
				"\xFFFF\x1\xF\x1\xC\x1\xB\x1\xFFFF\x1\xA\x1\xF\x1\xFFFF\x5\xF\x1\xFFFF"+
				"\x4\xF\x1\xFFFF\x5\xF\x2\xFFFF\x1\xD\x1\x9\x1E\xFFFF\x2\xE\x3\xFFFF"+
				"\x7\xE",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA80_eot = DFA.UnpackEncodedString(DFA80_eotS);
		private static readonly short[] DFA80_eof = DFA.UnpackEncodedString(DFA80_eofS);
		private static readonly char[] DFA80_min = DFA.UnpackEncodedStringToUnsignedChars(DFA80_minS);
		private static readonly char[] DFA80_max = DFA.UnpackEncodedStringToUnsignedChars(DFA80_maxS);
		private static readonly short[] DFA80_accept = DFA.UnpackEncodedString(DFA80_acceptS);
		private static readonly short[] DFA80_special = DFA.UnpackEncodedString(DFA80_specialS);
		private static readonly short[][] DFA80_transition;

		static DFA80()
		{
			int numStates = DFA80_transitionS.Length;
			DFA80_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA80_transition[i] = DFA.UnpackEncodedString(DFA80_transitionS[i]);
			}
		}

		public DFA80( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 80;
			this.eot = DFA80_eot;
			this.eof = DFA80_eof;
			this.min = DFA80_min;
			this.max = DFA80_max;
			this.accept = DFA80_accept;
			this.special = DFA80_special;
			this.transition = DFA80_transition;
		}

		public override string Description { get { return "177:13: ( expression )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition80(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA80_1 = input.LA(1);


				int index80_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA80_2 = input.LA(1);


				int index80_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA80_3 = input.LA(1);


				int index80_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA80_4 = input.LA(1);


				int index80_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA80_5 = input.LA(1);


				int index80_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA80_6 = input.LA(1);


				int index80_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA80_7 = input.LA(1);


				int index80_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA80_8 = input.LA(1);


				int index80_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA80_9 = input.LA(1);


				int index80_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA80_10 = input.LA(1);


				int index80_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA80_11 = input.LA(1);


				int index80_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA80_12 = input.LA(1);


				int index80_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA80_13 = input.LA(1);


				int index80_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_13);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA80_14 = input.LA(1);


				int index80_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred98_JavaScript_fragment)) ) {s = 36;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 15;}


				input.Seek(index80_14);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 80, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA92 : DFA
	{
		private const string DFA92_eotS =
			"\x4\xFFFF";
		private const string DFA92_eofS =
			"\x4\xFFFF";
		private const string DFA92_minS =
			"\x2\xA\x2\xFFFF";
		private const string DFA92_maxS =
			"\x2\x3F\x2\xFFFF";
		private const string DFA92_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA92_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA92_transitionS =
			{
				"\x1\x2\x1\x1\x32\xFFFF\x1\x3\x1\x2",
				"\x1\x2\x1\x1\x32\xFFFF\x1\x3\x1\x2",
				"",
				""
			};

		private static readonly short[] DFA92_eot = DFA.UnpackEncodedString(DFA92_eotS);
		private static readonly short[] DFA92_eof = DFA.UnpackEncodedString(DFA92_eofS);
		private static readonly char[] DFA92_min = DFA.UnpackEncodedStringToUnsignedChars(DFA92_minS);
		private static readonly char[] DFA92_max = DFA.UnpackEncodedStringToUnsignedChars(DFA92_maxS);
		private static readonly short[] DFA92_accept = DFA.UnpackEncodedString(DFA92_acceptS);
		private static readonly short[] DFA92_special = DFA.UnpackEncodedString(DFA92_specialS);
		private static readonly short[][] DFA92_transition;

		static DFA92()
		{
			int numStates = DFA92_transitionS.Length;
			DFA92_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA92_transition[i] = DFA.UnpackEncodedString(DFA92_transitionS[i]);
			}
		}

		public DFA92( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 92;
			this.eot = DFA92_eot;
			this.eof = DFA92_eof;
			this.min = DFA92_min;
			this.max = DFA92_max;
			this.accept = DFA92_accept;
			this.special = DFA92_special;
			this.transition = DFA92_transition;
		}

		public override string Description { get { return "()* loopback of 193:8: ( ( LT )* caseClause )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA96 : DFA
	{
		private const string DFA96_eotS =
			"\x4\xFFFF";
		private const string DFA96_eofS =
			"\x4\xFFFF";
		private const string DFA96_minS =
			"\x2\xA\x2\xFFFF";
		private const string DFA96_maxS =
			"\x2\x3F\x2\xFFFF";
		private const string DFA96_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA96_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA96_transitionS =
			{
				"\x1\x3\x1\x1\x33\xFFFF\x1\x2",
				"\x1\x3\x1\x1\x33\xFFFF\x1\x2",
				"",
				""
			};

		private static readonly short[] DFA96_eot = DFA.UnpackEncodedString(DFA96_eotS);
		private static readonly short[] DFA96_eof = DFA.UnpackEncodedString(DFA96_eofS);
		private static readonly char[] DFA96_min = DFA.UnpackEncodedStringToUnsignedChars(DFA96_minS);
		private static readonly char[] DFA96_max = DFA.UnpackEncodedStringToUnsignedChars(DFA96_maxS);
		private static readonly short[] DFA96_accept = DFA.UnpackEncodedString(DFA96_acceptS);
		private static readonly short[] DFA96_special = DFA.UnpackEncodedString(DFA96_specialS);
		private static readonly short[][] DFA96_transition;

		static DFA96()
		{
			int numStates = DFA96_transitionS.Length;
			DFA96_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA96_transition[i] = DFA.UnpackEncodedString(DFA96_transitionS[i]);
			}
		}

		public DFA96( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 96;
			this.eot = DFA96_eot;
			this.eof = DFA96_eof;
			this.min = DFA96_min;
			this.max = DFA96_max;
			this.accept = DFA96_accept;
			this.special = DFA96_special;
			this.transition = DFA96_transition;
		}

		public override string Description { get { return "193:27: ( ( LT )* defaultClause ( ( LT )* caseClause )* )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA95 : DFA
	{
		private const string DFA95_eotS =
			"\x4\xFFFF";
		private const string DFA95_eofS =
			"\x4\xFFFF";
		private const string DFA95_minS =
			"\x2\xA\x2\xFFFF";
		private const string DFA95_maxS =
			"\x2\x3E\x2\xFFFF";
		private const string DFA95_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA95_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA95_transitionS =
			{
				"\x1\x2\x1\x1\x32\xFFFF\x1\x3",
				"\x1\x2\x1\x1\x32\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA95_eot = DFA.UnpackEncodedString(DFA95_eotS);
		private static readonly short[] DFA95_eof = DFA.UnpackEncodedString(DFA95_eofS);
		private static readonly char[] DFA95_min = DFA.UnpackEncodedStringToUnsignedChars(DFA95_minS);
		private static readonly char[] DFA95_max = DFA.UnpackEncodedStringToUnsignedChars(DFA95_maxS);
		private static readonly short[] DFA95_accept = DFA.UnpackEncodedString(DFA95_acceptS);
		private static readonly short[] DFA95_special = DFA.UnpackEncodedString(DFA95_specialS);
		private static readonly short[][] DFA95_transition;

		static DFA95()
		{
			int numStates = DFA95_transitionS.Length;
			DFA95_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA95_transition[i] = DFA.UnpackEncodedString(DFA95_transitionS[i]);
			}
		}

		public DFA95( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 95;
			this.eot = DFA95_eot;
			this.eof = DFA95_eof;
			this.min = DFA95_min;
			this.max = DFA95_max;
			this.accept = DFA95_accept;
			this.special = DFA95_special;
			this.transition = DFA95_transition;
		}

		public override string Description { get { return "()* loopback of 193:47: ( ( LT )* caseClause )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA108 : DFA
	{
		private const string DFA108_eotS =
			"\x4\xFFFF";
		private const string DFA108_eofS =
			"\x2\x3\x2\xFFFF";
		private const string DFA108_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA108_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA108_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA108_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA108_transitionS =
			{
				"\x4\x3\x2\xFFFF\x1\x3\x1\x1\x2\xFFFF\x4\x3\x19\xFFFF\x3\x3\x1\xFFFF"+
				"\x2\x3\x1\xFFFF\x5\x3\x1\xFFFF\x4\x3\x1\xFFFF\x5\x3\x1\xFFFF\x1\x2\x2"+
				"\x3\x1E\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"\x4\x3\x2\xFFFF\x1\x3\x1\x1\x2\xFFFF\x4\x3\x19\xFFFF\x3\x3\x1\xFFFF"+
				"\x2\x3\x1\xFFFF\x5\x3\x1\xFFFF\x4\x3\x1\xFFFF\x5\x3\x1\xFFFF\x1\x2\x2"+
				"\x3\x1E\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"",
				""
			};

		private static readonly short[] DFA108_eot = DFA.UnpackEncodedString(DFA108_eotS);
		private static readonly short[] DFA108_eof = DFA.UnpackEncodedString(DFA108_eofS);
		private static readonly char[] DFA108_min = DFA.UnpackEncodedStringToUnsignedChars(DFA108_minS);
		private static readonly char[] DFA108_max = DFA.UnpackEncodedStringToUnsignedChars(DFA108_maxS);
		private static readonly short[] DFA108_accept = DFA.UnpackEncodedString(DFA108_acceptS);
		private static readonly short[] DFA108_special = DFA.UnpackEncodedString(DFA108_specialS);
		private static readonly short[][] DFA108_transition;

		static DFA108()
		{
			int numStates = DFA108_transitionS.Length;
			DFA108_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA108_transition[i] = DFA.UnpackEncodedString(DFA108_transitionS[i]);
			}
		}

		public DFA108( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 108;
			this.eot = DFA108_eot;
			this.eof = DFA108_eof;
			this.min = DFA108_min;
			this.max = DFA108_max;
			this.accept = DFA108_accept;
			this.special = DFA108_special;
			this.transition = DFA108_transition;
		}

		public override string Description { get { return "209:64: ( ( LT )* finallyClause )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA117 : DFA
	{
		private const string DFA117_eotS =
			"\x5\xFFFF";
		private const string DFA117_eofS =
			"\x1\x1\x1\xFFFF\x1\x1\x1\xFFFF\x1\x1";
		private const string DFA117_minS =
			"\x1\x4\x1\xFFFF\x1\x4\x1\xFFFF\x1\x4";
		private const string DFA117_maxS =
			"\x1\x6F\x1\xFFFF\x1\x6F\x1\xFFFF\x1\x6F";
		private const string DFA117_acceptS =
			"\x1\xFFFF\x1\x2\x1\xFFFF\x1\x1\x1\xFFFF";
		private const string DFA117_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA117_transitionS =
			{
				"\x7\x1\x1\x2\x6\x1\x19\xFFFF\x3\x1\x1\x3\x2\x1\x1\xFFFF\x5\x1\x1\xFFFF"+
				"\xA\x1\x2\xFFFF\x2\x1\x1E\xFFFF\x2\x1\x3\xFFFF\x7\x1",
				"",
				"\x7\x1\x1\x4\x2\xFFFF\x4\x1\x19\xFFFF\x3\x1\x1\x3\x2\x1\x1\xFFFF\x5"+
				"\x1\x1\xFFFF\xA\x1\x2\xFFFF\x2\x1\x1E\xFFFF\x2\x1\x3\xFFFF\x7\x1",
				"",
				"\x7\x1\x1\x4\x2\xFFFF\x4\x1\x19\xFFFF\x3\x1\x1\x3\x2\x1\x1\xFFFF\x5"+
				"\x1\x1\xFFFF\xA\x1\x2\xFFFF\x2\x1\x1E\xFFFF\x2\x1\x3\xFFFF\x7\x1"
			};

		private static readonly short[] DFA117_eot = DFA.UnpackEncodedString(DFA117_eotS);
		private static readonly short[] DFA117_eof = DFA.UnpackEncodedString(DFA117_eofS);
		private static readonly char[] DFA117_min = DFA.UnpackEncodedStringToUnsignedChars(DFA117_minS);
		private static readonly char[] DFA117_max = DFA.UnpackEncodedStringToUnsignedChars(DFA117_maxS);
		private static readonly short[] DFA117_accept = DFA.UnpackEncodedString(DFA117_acceptS);
		private static readonly short[] DFA117_special = DFA.UnpackEncodedString(DFA117_specialS);
		private static readonly short[][] DFA117_transition;

		static DFA117()
		{
			int numStates = DFA117_transitionS.Length;
			DFA117_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA117_transition[i] = DFA.UnpackEncodedString(DFA117_transitionS[i]);
			}
		}

		public DFA117( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 117;
			this.eot = DFA117_eot;
			this.eof = DFA117_eof;
			this.min = DFA117_min;
			this.max = DFA117_max;
			this.accept = DFA117_accept;
			this.special = DFA117_special;
			this.transition = DFA117_transition;
		}

		public override string Description { get { return "()* loopback of 222:25: ( ( LT )* ',' ( LT )* assignmentExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA120 : DFA
	{
		private const string DFA120_eotS =
			"\x4\xFFFF";
		private const string DFA120_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA120_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA120_maxS =
			"\x2\x2E\x2\xFFFF";
		private const string DFA120_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA120_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA120_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA120_eot = DFA.UnpackEncodedString(DFA120_eotS);
		private static readonly short[] DFA120_eof = DFA.UnpackEncodedString(DFA120_eofS);
		private static readonly char[] DFA120_min = DFA.UnpackEncodedStringToUnsignedChars(DFA120_minS);
		private static readonly char[] DFA120_max = DFA.UnpackEncodedStringToUnsignedChars(DFA120_maxS);
		private static readonly short[] DFA120_accept = DFA.UnpackEncodedString(DFA120_acceptS);
		private static readonly short[] DFA120_special = DFA.UnpackEncodedString(DFA120_specialS);
		private static readonly short[][] DFA120_transition;

		static DFA120()
		{
			int numStates = DFA120_transitionS.Length;
			DFA120_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA120_transition[i] = DFA.UnpackEncodedString(DFA120_transitionS[i]);
			}
		}

		public DFA120( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 120;
			this.eot = DFA120_eot;
			this.eof = DFA120_eof;
			this.min = DFA120_min;
			this.max = DFA120_max;
			this.accept = DFA120_accept;
			this.special = DFA120_special;
			this.transition = DFA120_transition;
		}

		public override string Description { get { return "()* loopback of 226:29: ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA123 : DFA
	{
		private const string DFA123_eotS =
			"\x10\xFFFF";
		private const string DFA123_eofS =
			"\x10\xFFFF";
		private const string DFA123_minS =
			"\x1\x4\xD\x0\x2\xFFFF";
		private const string DFA123_maxS =
			"\x1\x6F\xD\x0\x2\xFFFF";
		private const string DFA123_acceptS =
			"\xE\xFFFF\x1\x1\x1\x2";
		private const string DFA123_specialS =
			"\x1\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1\x9"+
			"\x1\xA\x1\xB\x1\xC\x2\xFFFF}>";
		private static readonly string[] DFA123_transitionS =
			{
				"\x1\x3\x1\x4\x1\x5\x1\x1\x6\xFFFF\x1\x2\x1\x7\x1\x6\x1\x8\x1A\xFFFF"+
				"\x1\xC\x1\xB\x1\xFFFF\x1\xA\x14\xFFFF\x1\xD\x1\x9\x1E\xFFFF\x2\xE\x3"+
				"\xFFFF\x7\xE",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"",
				""
			};

		private static readonly short[] DFA123_eot = DFA.UnpackEncodedString(DFA123_eotS);
		private static readonly short[] DFA123_eof = DFA.UnpackEncodedString(DFA123_eofS);
		private static readonly char[] DFA123_min = DFA.UnpackEncodedStringToUnsignedChars(DFA123_minS);
		private static readonly char[] DFA123_max = DFA.UnpackEncodedStringToUnsignedChars(DFA123_maxS);
		private static readonly short[] DFA123_accept = DFA.UnpackEncodedString(DFA123_acceptS);
		private static readonly short[] DFA123_special = DFA.UnpackEncodedString(DFA123_specialS);
		private static readonly short[][] DFA123_transition;

		static DFA123()
		{
			int numStates = DFA123_transitionS.Length;
			DFA123_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA123_transition[i] = DFA.UnpackEncodedString(DFA123_transitionS[i]);
			}
		}

		public DFA123( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 123;
			this.eot = DFA123_eot;
			this.eof = DFA123_eof;
			this.min = DFA123_min;
			this.max = DFA123_max;
			this.accept = DFA123_accept;
			this.special = DFA123_special;
			this.transition = DFA123_transition;
		}

		public override string Description { get { return "229:1: assignmentExpression : ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition123(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA123_1 = input.LA(1);


				int index123_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA123_2 = input.LA(1);


				int index123_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA123_3 = input.LA(1);


				int index123_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA123_4 = input.LA(1);


				int index123_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA123_5 = input.LA(1);


				int index123_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA123_6 = input.LA(1);


				int index123_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA123_7 = input.LA(1);


				int index123_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA123_8 = input.LA(1);


				int index123_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA123_9 = input.LA(1);


				int index123_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA123_10 = input.LA(1);


				int index123_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA123_11 = input.LA(1);


				int index123_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA123_12 = input.LA(1);


				int index123_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA123_13 = input.LA(1);


				int index123_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred139_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index123_13);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 123, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA126 : DFA
	{
		private const string DFA126_eotS =
			"\x10\xFFFF";
		private const string DFA126_eofS =
			"\x10\xFFFF";
		private const string DFA126_minS =
			"\x1\x4\xD\x0\x2\xFFFF";
		private const string DFA126_maxS =
			"\x1\x6F\xD\x0\x2\xFFFF";
		private const string DFA126_acceptS =
			"\xE\xFFFF\x1\x1\x1\x2";
		private const string DFA126_specialS =
			"\x1\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1\x9"+
			"\x1\xA\x1\xB\x1\xC\x2\xFFFF}>";
		private static readonly string[] DFA126_transitionS =
			{
				"\x1\x3\x1\x4\x1\x5\x1\x1\x6\xFFFF\x1\x2\x1\x7\x1\x6\x1\x8\x1A\xFFFF"+
				"\x1\xC\x1\xB\x1\xFFFF\x1\xA\x14\xFFFF\x1\xD\x1\x9\x1E\xFFFF\x2\xE\x3"+
				"\xFFFF\x7\xE",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"",
				""
			};

		private static readonly short[] DFA126_eot = DFA.UnpackEncodedString(DFA126_eotS);
		private static readonly short[] DFA126_eof = DFA.UnpackEncodedString(DFA126_eofS);
		private static readonly char[] DFA126_min = DFA.UnpackEncodedStringToUnsignedChars(DFA126_minS);
		private static readonly char[] DFA126_max = DFA.UnpackEncodedStringToUnsignedChars(DFA126_maxS);
		private static readonly short[] DFA126_accept = DFA.UnpackEncodedString(DFA126_acceptS);
		private static readonly short[] DFA126_special = DFA.UnpackEncodedString(DFA126_specialS);
		private static readonly short[][] DFA126_transition;

		static DFA126()
		{
			int numStates = DFA126_transitionS.Length;
			DFA126_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA126_transition[i] = DFA.UnpackEncodedString(DFA126_transitionS[i]);
			}
		}

		public DFA126( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 126;
			this.eot = DFA126_eot;
			this.eof = DFA126_eof;
			this.min = DFA126_min;
			this.max = DFA126_max;
			this.accept = DFA126_accept;
			this.special = DFA126_special;
			this.transition = DFA126_transition;
		}

		public override string Description { get { return "234:1: assignmentExpressionNoIn : ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition126(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA126_1 = input.LA(1);


				int index126_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA126_2 = input.LA(1);


				int index126_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA126_3 = input.LA(1);


				int index126_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA126_4 = input.LA(1);


				int index126_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA126_5 = input.LA(1);


				int index126_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA126_6 = input.LA(1);


				int index126_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA126_7 = input.LA(1);


				int index126_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA126_8 = input.LA(1);


				int index126_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA126_9 = input.LA(1);


				int index126_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA126_10 = input.LA(1);


				int index126_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA126_11 = input.LA(1);


				int index126_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA126_12 = input.LA(1);


				int index126_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA126_13 = input.LA(1);


				int index126_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred142_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index126_13);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 126, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA127 : DFA
	{
		private const string DFA127_eotS =
			"\x10\xFFFF";
		private const string DFA127_eofS =
			"\x10\xFFFF";
		private const string DFA127_minS =
			"\x1\x4\xD\x0\x2\xFFFF";
		private const string DFA127_maxS =
			"\x1\x45\xD\x0\x2\xFFFF";
		private const string DFA127_acceptS =
			"\xE\xFFFF\x1\x1\x1\x2";
		private const string DFA127_specialS =
			"\x1\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1\x9"+
			"\x1\xA\x1\xB\x1\xC\x2\xFFFF}>";
		private static readonly string[] DFA127_transitionS =
			{
				"\x1\x3\x1\x4\x1\x5\x1\x1\x6\xFFFF\x1\x2\x1\x7\x1\x6\x1\x8\x1A\xFFFF"+
				"\x1\xC\x1\xB\x1\xFFFF\x1\xA\x14\xFFFF\x1\xD\x1\x9",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"",
				""
			};

		private static readonly short[] DFA127_eot = DFA.UnpackEncodedString(DFA127_eotS);
		private static readonly short[] DFA127_eof = DFA.UnpackEncodedString(DFA127_eofS);
		private static readonly char[] DFA127_min = DFA.UnpackEncodedStringToUnsignedChars(DFA127_minS);
		private static readonly char[] DFA127_max = DFA.UnpackEncodedStringToUnsignedChars(DFA127_maxS);
		private static readonly short[] DFA127_accept = DFA.UnpackEncodedString(DFA127_acceptS);
		private static readonly short[] DFA127_special = DFA.UnpackEncodedString(DFA127_specialS);
		private static readonly short[][] DFA127_transition;

		static DFA127()
		{
			int numStates = DFA127_transitionS.Length;
			DFA127_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA127_transition[i] = DFA.UnpackEncodedString(DFA127_transitionS[i]);
			}
		}

		public DFA127( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 127;
			this.eot = DFA127_eot;
			this.eof = DFA127_eof;
			this.min = DFA127_min;
			this.max = DFA127_max;
			this.accept = DFA127_accept;
			this.special = DFA127_special;
			this.transition = DFA127_transition;
		}

		public override string Description { get { return "239:1: leftHandSideExpression : ( callExpression | newExpression );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition127(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA127_1 = input.LA(1);


				int index127_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA127_2 = input.LA(1);


				int index127_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA127_3 = input.LA(1);


				int index127_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA127_4 = input.LA(1);


				int index127_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA127_5 = input.LA(1);


				int index127_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA127_6 = input.LA(1);


				int index127_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA127_7 = input.LA(1);


				int index127_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA127_8 = input.LA(1);


				int index127_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA127_9 = input.LA(1);


				int index127_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA127_10 = input.LA(1);


				int index127_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA127_11 = input.LA(1);


				int index127_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA127_12 = input.LA(1);


				int index127_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA127_13 = input.LA(1);


				int index127_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred145_JavaScript_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index127_13);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 127, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA129 : DFA
	{
		private const string DFA129_eotS =
			"\xF\xFFFF";
		private const string DFA129_eofS =
			"\xF\xFFFF";
		private const string DFA129_minS =
			"\x1\x4\xC\xFFFF\x1\x0\x1\xFFFF";
		private const string DFA129_maxS =
			"\x1\x45\xC\xFFFF\x1\x0\x1\xFFFF";
		private const string DFA129_acceptS =
			"\x1\xFFFF\x1\x1\xC\xFFFF\x1\x2";
		private const string DFA129_specialS =
			"\xD\xFFFF\x1\x0\x1\xFFFF}>";
		private static readonly string[] DFA129_transitionS =
			{
				"\x4\x1\x6\xFFFF\x4\x1\x1A\xFFFF\x2\x1\x1\xFFFF\x1\x1\x14\xFFFF\x1\xD"+
				"\x1\x1",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\xFFFF",
				""
			};

		private static readonly short[] DFA129_eot = DFA.UnpackEncodedString(DFA129_eotS);
		private static readonly short[] DFA129_eof = DFA.UnpackEncodedString(DFA129_eofS);
		private static readonly char[] DFA129_min = DFA.UnpackEncodedStringToUnsignedChars(DFA129_minS);
		private static readonly char[] DFA129_max = DFA.UnpackEncodedStringToUnsignedChars(DFA129_maxS);
		private static readonly short[] DFA129_accept = DFA.UnpackEncodedString(DFA129_acceptS);
		private static readonly short[] DFA129_special = DFA.UnpackEncodedString(DFA129_specialS);
		private static readonly short[][] DFA129_transition;

		static DFA129()
		{
			int numStates = DFA129_transitionS.Length;
			DFA129_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA129_transition[i] = DFA.UnpackEncodedString(DFA129_transitionS[i]);
			}
		}

		public DFA129( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 129;
			this.eot = DFA129_eot;
			this.eof = DFA129_eof;
			this.min = DFA129_min;
			this.max = DFA129_max;
			this.accept = DFA129_accept;
			this.special = DFA129_special;
			this.transition = DFA129_transition;
		}

		public override string Description { get { return "244:1: newExpression : ( memberExpression | 'new' ( LT )* newExpression );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition129(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA129_13 = input.LA(1);


				int index129_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred146_JavaScript_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 14;}


				input.Seek(index129_13);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 129, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA134 : DFA
	{
		private const string DFA134_eotS =
			"\x37\xFFFF";
		private const string DFA134_eofS =
			"\x1\x2\x36\xFFFF";
		private const string DFA134_minS =
			"\x1\x4\x1\x0\x1E\xFFFF\x1\x0\x16\xFFFF";
		private const string DFA134_maxS =
			"\x1\x6F\x1\x0\x1E\xFFFF\x1\x0\x16\xFFFF";
		private const string DFA134_acceptS =
			"\x2\xFFFF\x1\x2\x33\xFFFF\x1\x1";
		private const string DFA134_specialS =
			"\x1\xFFFF\x1\x0\x1E\xFFFF\x1\x1\x16\xFFFF}>";
		private static readonly string[] DFA134_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x17\x2\x2\xFFFF\x1\x2\x1\x20\x1\x36\x29"+
				"\x2",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA134_eot = DFA.UnpackEncodedString(DFA134_eotS);
		private static readonly short[] DFA134_eof = DFA.UnpackEncodedString(DFA134_eofS);
		private static readonly char[] DFA134_min = DFA.UnpackEncodedStringToUnsignedChars(DFA134_minS);
		private static readonly char[] DFA134_max = DFA.UnpackEncodedStringToUnsignedChars(DFA134_maxS);
		private static readonly short[] DFA134_accept = DFA.UnpackEncodedString(DFA134_acceptS);
		private static readonly short[] DFA134_special = DFA.UnpackEncodedString(DFA134_specialS);
		private static readonly short[][] DFA134_transition;

		static DFA134()
		{
			int numStates = DFA134_transitionS.Length;
			DFA134_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA134_transition[i] = DFA.UnpackEncodedString(DFA134_transitionS[i]);
			}
		}

		public DFA134( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 134;
			this.eot = DFA134_eot;
			this.eof = DFA134_eof;
			this.min = DFA134_min;
			this.max = DFA134_max;
			this.accept = DFA134_accept;
			this.special = DFA134_special;
			this.transition = DFA134_transition;
		}

		public override string Description { get { return "()* loopback of 250:90: ( ( LT )* memberExpressionSuffix )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition134(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA134_1 = input.LA(1);


				int index134_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred153_JavaScript_fragment)) ) {s = 54;}

				else if ( (true) ) {s = 2;}


				input.Seek(index134_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA134_32 = input.LA(1);


				int index134_32 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred153_JavaScript_fragment)) ) {s = 54;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 2;}


				input.Seek(index134_32);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 134, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA138 : DFA
	{
		private const string DFA138_eotS =
			"\x37\xFFFF";
		private const string DFA138_eofS =
			"\x1\x2\x36\xFFFF";
		private const string DFA138_minS =
			"\x1\x4\x1\x0\x1E\xFFFF\x2\x0\x15\xFFFF";
		private const string DFA138_maxS =
			"\x1\x6F\x1\x0\x1E\xFFFF\x2\x0\x15\xFFFF";
		private const string DFA138_acceptS =
			"\x2\xFFFF\x1\x2\x33\xFFFF\x1\x1";
		private const string DFA138_specialS =
			"\x1\xFFFF\x1\x0\x1E\xFFFF\x1\x1\x1\x2\x15\xFFFF}>";
		private static readonly string[] DFA138_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x2\x2\x1\x21\x14\x2\x2\xFFFF\x1\x2\x1"+
				"\x20\x1\x36\x29\x2",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA138_eot = DFA.UnpackEncodedString(DFA138_eotS);
		private static readonly short[] DFA138_eof = DFA.UnpackEncodedString(DFA138_eofS);
		private static readonly char[] DFA138_min = DFA.UnpackEncodedStringToUnsignedChars(DFA138_minS);
		private static readonly char[] DFA138_max = DFA.UnpackEncodedStringToUnsignedChars(DFA138_maxS);
		private static readonly short[] DFA138_accept = DFA.UnpackEncodedString(DFA138_acceptS);
		private static readonly short[] DFA138_special = DFA.UnpackEncodedString(DFA138_specialS);
		private static readonly short[][] DFA138_transition;

		static DFA138()
		{
			int numStates = DFA138_transitionS.Length;
			DFA138_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA138_transition[i] = DFA.UnpackEncodedString(DFA138_transitionS[i]);
			}
		}

		public DFA138( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 138;
			this.eot = DFA138_eot;
			this.eof = DFA138_eof;
			this.min = DFA138_min;
			this.max = DFA138_max;
			this.accept = DFA138_accept;
			this.special = DFA138_special;
			this.transition = DFA138_transition;
		}

		public override string Description { get { return "()* loopback of 259:36: ( ( LT )* callExpressionSuffix )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition138(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA138_1 = input.LA(1);


				int index138_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred157_JavaScript_fragment)) ) {s = 54;}

				else if ( (true) ) {s = 2;}


				input.Seek(index138_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA138_32 = input.LA(1);


				int index138_32 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred157_JavaScript_fragment)) ) {s = 54;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 2;}


				input.Seek(index138_32);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA138_33 = input.LA(1);


				int index138_33 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred157_JavaScript_fragment)) ) {s = 54;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 2;}


				input.Seek(index138_33);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 138, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA144 : DFA
	{
		private const string DFA144_eotS =
			"\x4\xFFFF";
		private const string DFA144_eofS =
			"\x4\xFFFF";
		private const string DFA144_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA144_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA144_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA144_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA144_transitionS =
			{
				"\x4\x2\x1\xFFFF\x1\x3\x1\xFFFF\x1\x1\x2\xFFFF\x4\x2\x1A\xFFFF\x2\x2"+
				"\x1\xFFFF\x1\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x4\x2\x1\xFFFF\x1\x3\x1\xFFFF\x1\x1\x2\xFFFF\x4\x2\x1A\xFFFF\x2\x2"+
				"\x1\xFFFF\x1\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"",
				""
			};

		private static readonly short[] DFA144_eot = DFA.UnpackEncodedString(DFA144_eotS);
		private static readonly short[] DFA144_eof = DFA.UnpackEncodedString(DFA144_eofS);
		private static readonly char[] DFA144_min = DFA.UnpackEncodedStringToUnsignedChars(DFA144_minS);
		private static readonly char[] DFA144_max = DFA.UnpackEncodedStringToUnsignedChars(DFA144_maxS);
		private static readonly short[] DFA144_accept = DFA.UnpackEncodedString(DFA144_acceptS);
		private static readonly short[] DFA144_special = DFA.UnpackEncodedString(DFA144_specialS);
		private static readonly short[][] DFA144_transition;

		static DFA144()
		{
			int numStates = DFA144_transitionS.Length;
			DFA144_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA144_transition[i] = DFA.UnpackEncodedString(DFA144_transitionS[i]);
			}
		}

		public DFA144( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 144;
			this.eot = DFA144_eot;
			this.eof = DFA144_eof;
			this.min = DFA144_min;
			this.max = DFA144_max;
			this.accept = DFA144_accept;
			this.special = DFA144_special;
			this.transition = DFA144_transition;
		}

		public override string Description { get { return "269:8: ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA143 : DFA
	{
		private const string DFA143_eotS =
			"\x4\xFFFF";
		private const string DFA143_eofS =
			"\x4\xFFFF";
		private const string DFA143_minS =
			"\x2\x9\x2\xFFFF";
		private const string DFA143_maxS =
			"\x2\x2E\x2\xFFFF";
		private const string DFA143_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA143_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA143_transitionS =
			{
				"\x1\x2\x1\xFFFF\x1\x1\x22\xFFFF\x1\x3",
				"\x1\x2\x1\xFFFF\x1\x1\x22\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA143_eot = DFA.UnpackEncodedString(DFA143_eotS);
		private static readonly short[] DFA143_eof = DFA.UnpackEncodedString(DFA143_eofS);
		private static readonly char[] DFA143_min = DFA.UnpackEncodedStringToUnsignedChars(DFA143_minS);
		private static readonly char[] DFA143_max = DFA.UnpackEncodedStringToUnsignedChars(DFA143_maxS);
		private static readonly short[] DFA143_accept = DFA.UnpackEncodedString(DFA143_acceptS);
		private static readonly short[] DFA143_special = DFA.UnpackEncodedString(DFA143_specialS);
		private static readonly short[][] DFA143_transition;

		static DFA143()
		{
			int numStates = DFA143_transitionS.Length;
			DFA143_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA143_transition[i] = DFA.UnpackEncodedString(DFA143_transitionS[i]);
			}
		}

		public DFA143( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 143;
			this.eot = DFA143_eot;
			this.eof = DFA143_eof;
			this.min = DFA143_min;
			this.max = DFA143_max;
			this.accept = DFA143_accept;
			this.special = DFA143_special;
			this.transition = DFA143_transition;
		}

		public override string Description { get { return "()* loopback of 269:35: ( ( LT )* ',' ( LT )* assignmentExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA153 : DFA
	{
		private const string DFA153_eotS =
			"\x5\xFFFF";
		private const string DFA153_eofS =
			"\x2\x3\x2\xFFFF\x1\x3";
		private const string DFA153_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA153_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA153_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2\x1\xFFFF";
		private const string DFA153_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA153_transitionS =
			{
				"\x7\x3\x1\x1\x6\x3\x19\xFFFF\x6\x3\x1\xFFFF\x5\x3\x1\xFFFF\xA\x3\x2"+
				"\xFFFF\x2\x3\xC\xFFFF\x1\x2\x11\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"\x7\x3\x1\x4\x2\xFFFF\x4\x3\x19\xFFFF\x6\x3\x1\xFFFF\x5\x3\x1\xFFFF"+
				"\xA\x3\x2\xFFFF\x2\x3\xC\xFFFF\x1\x2\x11\xFFFF\x2\x3\x3\xFFFF\x7\x3",
				"",
				"",
				"\x7\x3\x1\x4\x2\xFFFF\x4\x3\x19\xFFFF\x6\x3\x1\xFFFF\x5\x3\x1\xFFFF"+
				"\xA\x3\x2\xFFFF\x2\x3\xC\xFFFF\x1\x2\x11\xFFFF\x2\x3\x3\xFFFF\x7\x3"
			};

		private static readonly short[] DFA153_eot = DFA.UnpackEncodedString(DFA153_eotS);
		private static readonly short[] DFA153_eof = DFA.UnpackEncodedString(DFA153_eofS);
		private static readonly char[] DFA153_min = DFA.UnpackEncodedStringToUnsignedChars(DFA153_minS);
		private static readonly char[] DFA153_max = DFA.UnpackEncodedStringToUnsignedChars(DFA153_maxS);
		private static readonly short[] DFA153_accept = DFA.UnpackEncodedString(DFA153_acceptS);
		private static readonly short[] DFA153_special = DFA.UnpackEncodedString(DFA153_specialS);
		private static readonly short[][] DFA153_transition;

		static DFA153()
		{
			int numStates = DFA153_transitionS.Length;
			DFA153_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA153_transition[i] = DFA.UnpackEncodedString(DFA153_transitionS[i]);
			}
		}

		public DFA153( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 153;
			this.eot = DFA153_eot;
			this.eof = DFA153_eof;
			this.min = DFA153_min;
			this.max = DFA153_max;
			this.accept = DFA153_accept;
			this.special = DFA153_special;
			this.transition = DFA153_transition;
		}

		public override string Description { get { return "285:24: ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA158 : DFA
	{
		private const string DFA158_eotS =
			"\x4\xFFFF";
		private const string DFA158_eofS =
			"\x1\x3\x3\xFFFF";
		private const string DFA158_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA158_maxS =
			"\x2\x52\x2\xFFFF";
		private const string DFA158_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA158_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA158_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x3\x2\xFFFF\x1\x3\x8\xFFFF\x1\x3\x4\xFFFF\x1\x3"+
				"\x15\xFFFF\x1\x2",
				"\x1\x1\x1F\xFFFF\x1\x3\x2\xFFFF\x1\x3\x8\xFFFF\x1\x3\x4\xFFFF\x1\x3"+
				"\x15\xFFFF\x1\x2",
				"",
				""
			};

		private static readonly short[] DFA158_eot = DFA.UnpackEncodedString(DFA158_eotS);
		private static readonly short[] DFA158_eof = DFA.UnpackEncodedString(DFA158_eofS);
		private static readonly char[] DFA158_min = DFA.UnpackEncodedStringToUnsignedChars(DFA158_minS);
		private static readonly char[] DFA158_max = DFA.UnpackEncodedStringToUnsignedChars(DFA158_maxS);
		private static readonly short[] DFA158_accept = DFA.UnpackEncodedString(DFA158_acceptS);
		private static readonly short[] DFA158_special = DFA.UnpackEncodedString(DFA158_specialS);
		private static readonly short[][] DFA158_transition;

		static DFA158()
		{
			int numStates = DFA158_transitionS.Length;
			DFA158_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA158_transition[i] = DFA.UnpackEncodedString(DFA158_transitionS[i]);
			}
		}

		public DFA158( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 158;
			this.eot = DFA158_eot;
			this.eof = DFA158_eof;
			this.min = DFA158_min;
			this.max = DFA158_max;
			this.accept = DFA158_accept;
			this.special = DFA158_special;
			this.transition = DFA158_transition;
		}

		public override string Description { get { return "289:28: ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA161 : DFA
	{
		private const string DFA161_eotS =
			"\x5\xFFFF";
		private const string DFA161_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA161_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA161_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA161_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA161_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA161_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF\xA\x2\x2"+
				"\xFFFF\x2\x2\xC\xFFFF\x1\x2\x1\x3\x10\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x1\x2\x1\x3\x10\xFFFF\x2\x2\x3\xFFFF"+
				"\x7\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x1\x2\x1\x3\x10\xFFFF\x2\x2\x3\xFFFF"+
				"\x7\x2"
			};

		private static readonly short[] DFA161_eot = DFA.UnpackEncodedString(DFA161_eotS);
		private static readonly short[] DFA161_eof = DFA.UnpackEncodedString(DFA161_eofS);
		private static readonly char[] DFA161_min = DFA.UnpackEncodedStringToUnsignedChars(DFA161_minS);
		private static readonly char[] DFA161_max = DFA.UnpackEncodedStringToUnsignedChars(DFA161_maxS);
		private static readonly short[] DFA161_accept = DFA.UnpackEncodedString(DFA161_acceptS);
		private static readonly short[] DFA161_special = DFA.UnpackEncodedString(DFA161_specialS);
		private static readonly short[][] DFA161_transition;

		static DFA161()
		{
			int numStates = DFA161_transitionS.Length;
			DFA161_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA161_transition[i] = DFA.UnpackEncodedString(DFA161_transitionS[i]);
			}
		}

		public DFA161( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 161;
			this.eot = DFA161_eot;
			this.eof = DFA161_eof;
			this.min = DFA161_min;
			this.max = DFA161_max;
			this.accept = DFA161_accept;
			this.special = DFA161_special;
			this.transition = DFA161_transition;
		}

		public override string Description { get { return "()* loopback of 293:25: ( ( LT )* '||' ( LT )* logicalANDExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA164 : DFA
	{
		private const string DFA164_eotS =
			"\x4\xFFFF";
		private const string DFA164_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA164_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA164_maxS =
			"\x2\x53\x2\xFFFF";
		private const string DFA164_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA164_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA164_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x1\x2\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x1\x2\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA164_eot = DFA.UnpackEncodedString(DFA164_eotS);
		private static readonly short[] DFA164_eof = DFA.UnpackEncodedString(DFA164_eofS);
		private static readonly char[] DFA164_min = DFA.UnpackEncodedStringToUnsignedChars(DFA164_minS);
		private static readonly char[] DFA164_max = DFA.UnpackEncodedStringToUnsignedChars(DFA164_maxS);
		private static readonly short[] DFA164_accept = DFA.UnpackEncodedString(DFA164_acceptS);
		private static readonly short[] DFA164_special = DFA.UnpackEncodedString(DFA164_specialS);
		private static readonly short[][] DFA164_transition;

		static DFA164()
		{
			int numStates = DFA164_transitionS.Length;
			DFA164_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA164_transition[i] = DFA.UnpackEncodedString(DFA164_transitionS[i]);
			}
		}

		public DFA164( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 164;
			this.eot = DFA164_eot;
			this.eof = DFA164_eof;
			this.min = DFA164_min;
			this.max = DFA164_max;
			this.accept = DFA164_accept;
			this.special = DFA164_special;
			this.transition = DFA164_transition;
		}

		public override string Description { get { return "()* loopback of 297:29: ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA167 : DFA
	{
		private const string DFA167_eotS =
			"\x5\xFFFF";
		private const string DFA167_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA167_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA167_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA167_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA167_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA167_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF\xA\x2\x2"+
				"\xFFFF\x2\x2\xC\xFFFF\x2\x2\x1\x3\xF\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x2\x2\x1\x3\xF\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x2\x2\x1\x3\xF\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2"
			};

		private static readonly short[] DFA167_eot = DFA.UnpackEncodedString(DFA167_eotS);
		private static readonly short[] DFA167_eof = DFA.UnpackEncodedString(DFA167_eofS);
		private static readonly char[] DFA167_min = DFA.UnpackEncodedStringToUnsignedChars(DFA167_minS);
		private static readonly char[] DFA167_max = DFA.UnpackEncodedStringToUnsignedChars(DFA167_maxS);
		private static readonly short[] DFA167_accept = DFA.UnpackEncodedString(DFA167_acceptS);
		private static readonly short[] DFA167_special = DFA.UnpackEncodedString(DFA167_specialS);
		private static readonly short[][] DFA167_transition;

		static DFA167()
		{
			int numStates = DFA167_transitionS.Length;
			DFA167_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA167_transition[i] = DFA.UnpackEncodedString(DFA167_transitionS[i]);
			}
		}

		public DFA167( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 167;
			this.eot = DFA167_eot;
			this.eof = DFA167_eof;
			this.min = DFA167_min;
			this.max = DFA167_max;
			this.accept = DFA167_accept;
			this.special = DFA167_special;
			this.transition = DFA167_transition;
		}

		public override string Description { get { return "()* loopback of 301:24: ( ( LT )* '&&' ( LT )* bitwiseORExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA170 : DFA
	{
		private const string DFA170_eotS =
			"\x4\xFFFF";
		private const string DFA170_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA170_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA170_maxS =
			"\x2\x54\x2\xFFFF";
		private const string DFA170_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA170_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA170_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x2\x2\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x2\x2\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA170_eot = DFA.UnpackEncodedString(DFA170_eotS);
		private static readonly short[] DFA170_eof = DFA.UnpackEncodedString(DFA170_eofS);
		private static readonly char[] DFA170_min = DFA.UnpackEncodedStringToUnsignedChars(DFA170_minS);
		private static readonly char[] DFA170_max = DFA.UnpackEncodedStringToUnsignedChars(DFA170_maxS);
		private static readonly short[] DFA170_accept = DFA.UnpackEncodedString(DFA170_acceptS);
		private static readonly short[] DFA170_special = DFA.UnpackEncodedString(DFA170_specialS);
		private static readonly short[][] DFA170_transition;

		static DFA170()
		{
			int numStates = DFA170_transitionS.Length;
			DFA170_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA170_transition[i] = DFA.UnpackEncodedString(DFA170_transitionS[i]);
			}
		}

		public DFA170( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 170;
			this.eot = DFA170_eot;
			this.eof = DFA170_eof;
			this.min = DFA170_min;
			this.max = DFA170_max;
			this.accept = DFA170_accept;
			this.special = DFA170_special;
			this.transition = DFA170_transition;
		}

		public override string Description { get { return "()* loopback of 305:28: ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA173 : DFA
	{
		private const string DFA173_eotS =
			"\x5\xFFFF";
		private const string DFA173_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA173_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA173_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA173_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA173_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA173_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF\xA\x2\x2"+
				"\xFFFF\x2\x2\xC\xFFFF\x3\x2\x1\x3\xE\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x3\x2\x1\x3\xE\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x3\x2\x1\x3\xE\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2"
			};

		private static readonly short[] DFA173_eot = DFA.UnpackEncodedString(DFA173_eotS);
		private static readonly short[] DFA173_eof = DFA.UnpackEncodedString(DFA173_eofS);
		private static readonly char[] DFA173_min = DFA.UnpackEncodedStringToUnsignedChars(DFA173_minS);
		private static readonly char[] DFA173_max = DFA.UnpackEncodedStringToUnsignedChars(DFA173_maxS);
		private static readonly short[] DFA173_accept = DFA.UnpackEncodedString(DFA173_acceptS);
		private static readonly short[] DFA173_special = DFA.UnpackEncodedString(DFA173_specialS);
		private static readonly short[][] DFA173_transition;

		static DFA173()
		{
			int numStates = DFA173_transitionS.Length;
			DFA173_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA173_transition[i] = DFA.UnpackEncodedString(DFA173_transitionS[i]);
			}
		}

		public DFA173( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 173;
			this.eot = DFA173_eot;
			this.eof = DFA173_eof;
			this.min = DFA173_min;
			this.max = DFA173_max;
			this.accept = DFA173_accept;
			this.special = DFA173_special;
			this.transition = DFA173_transition;
		}

		public override string Description { get { return "()* loopback of 309:25: ( ( LT )* '|' ( LT )* bitwiseXORExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA176 : DFA
	{
		private const string DFA176_eotS =
			"\x4\xFFFF";
		private const string DFA176_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA176_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA176_maxS =
			"\x2\x55\x2\xFFFF";
		private const string DFA176_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA176_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA176_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x3\x2\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x3\x2\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA176_eot = DFA.UnpackEncodedString(DFA176_eotS);
		private static readonly short[] DFA176_eof = DFA.UnpackEncodedString(DFA176_eofS);
		private static readonly char[] DFA176_min = DFA.UnpackEncodedStringToUnsignedChars(DFA176_minS);
		private static readonly char[] DFA176_max = DFA.UnpackEncodedStringToUnsignedChars(DFA176_maxS);
		private static readonly short[] DFA176_accept = DFA.UnpackEncodedString(DFA176_acceptS);
		private static readonly short[] DFA176_special = DFA.UnpackEncodedString(DFA176_specialS);
		private static readonly short[][] DFA176_transition;

		static DFA176()
		{
			int numStates = DFA176_transitionS.Length;
			DFA176_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA176_transition[i] = DFA.UnpackEncodedString(DFA176_transitionS[i]);
			}
		}

		public DFA176( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 176;
			this.eot = DFA176_eot;
			this.eof = DFA176_eof;
			this.min = DFA176_min;
			this.max = DFA176_max;
			this.accept = DFA176_accept;
			this.special = DFA176_special;
			this.transition = DFA176_transition;
		}

		public override string Description { get { return "()* loopback of 313:29: ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA179 : DFA
	{
		private const string DFA179_eotS =
			"\x5\xFFFF";
		private const string DFA179_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA179_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA179_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA179_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA179_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA179_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF\xA\x2\x2"+
				"\xFFFF\x2\x2\xC\xFFFF\x4\x2\x1\x3\xD\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x4\x2\x1\x3\xD\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x4\x2\x1\x3\xD\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2"
			};

		private static readonly short[] DFA179_eot = DFA.UnpackEncodedString(DFA179_eotS);
		private static readonly short[] DFA179_eof = DFA.UnpackEncodedString(DFA179_eofS);
		private static readonly char[] DFA179_min = DFA.UnpackEncodedStringToUnsignedChars(DFA179_minS);
		private static readonly char[] DFA179_max = DFA.UnpackEncodedStringToUnsignedChars(DFA179_maxS);
		private static readonly short[] DFA179_accept = DFA.UnpackEncodedString(DFA179_acceptS);
		private static readonly short[] DFA179_special = DFA.UnpackEncodedString(DFA179_specialS);
		private static readonly short[][] DFA179_transition;

		static DFA179()
		{
			int numStates = DFA179_transitionS.Length;
			DFA179_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA179_transition[i] = DFA.UnpackEncodedString(DFA179_transitionS[i]);
			}
		}

		public DFA179( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 179;
			this.eot = DFA179_eot;
			this.eof = DFA179_eof;
			this.min = DFA179_min;
			this.max = DFA179_max;
			this.accept = DFA179_accept;
			this.special = DFA179_special;
			this.transition = DFA179_transition;
		}

		public override string Description { get { return "()* loopback of 317:25: ( ( LT )* '^' ( LT )* bitwiseANDExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA182 : DFA
	{
		private const string DFA182_eotS =
			"\x4\xFFFF";
		private const string DFA182_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA182_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA182_maxS =
			"\x2\x56\x2\xFFFF";
		private const string DFA182_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA182_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA182_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x4\x2\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x4\x2\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA182_eot = DFA.UnpackEncodedString(DFA182_eotS);
		private static readonly short[] DFA182_eof = DFA.UnpackEncodedString(DFA182_eofS);
		private static readonly char[] DFA182_min = DFA.UnpackEncodedStringToUnsignedChars(DFA182_minS);
		private static readonly char[] DFA182_max = DFA.UnpackEncodedStringToUnsignedChars(DFA182_maxS);
		private static readonly short[] DFA182_accept = DFA.UnpackEncodedString(DFA182_acceptS);
		private static readonly short[] DFA182_special = DFA.UnpackEncodedString(DFA182_specialS);
		private static readonly short[][] DFA182_transition;

		static DFA182()
		{
			int numStates = DFA182_transitionS.Length;
			DFA182_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA182_transition[i] = DFA.UnpackEncodedString(DFA182_transitionS[i]);
			}
		}

		public DFA182( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 182;
			this.eot = DFA182_eot;
			this.eof = DFA182_eof;
			this.min = DFA182_min;
			this.max = DFA182_max;
			this.accept = DFA182_accept;
			this.special = DFA182_special;
			this.transition = DFA182_transition;
		}

		public override string Description { get { return "()* loopback of 321:29: ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA185 : DFA
	{
		private const string DFA185_eotS =
			"\x5\xFFFF";
		private const string DFA185_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA185_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA185_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA185_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA185_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA185_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF\xA\x2\x2"+
				"\xFFFF\x2\x2\xC\xFFFF\x5\x2\x1\x3\xC\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x5\x2\x1\x3\xC\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x5\x2\x1\x3\xC\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2"
			};

		private static readonly short[] DFA185_eot = DFA.UnpackEncodedString(DFA185_eotS);
		private static readonly short[] DFA185_eof = DFA.UnpackEncodedString(DFA185_eofS);
		private static readonly char[] DFA185_min = DFA.UnpackEncodedStringToUnsignedChars(DFA185_minS);
		private static readonly char[] DFA185_max = DFA.UnpackEncodedStringToUnsignedChars(DFA185_maxS);
		private static readonly short[] DFA185_accept = DFA.UnpackEncodedString(DFA185_acceptS);
		private static readonly short[] DFA185_special = DFA.UnpackEncodedString(DFA185_specialS);
		private static readonly short[][] DFA185_transition;

		static DFA185()
		{
			int numStates = DFA185_transitionS.Length;
			DFA185_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA185_transition[i] = DFA.UnpackEncodedString(DFA185_transitionS[i]);
			}
		}

		public DFA185( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 185;
			this.eot = DFA185_eot;
			this.eof = DFA185_eof;
			this.min = DFA185_min;
			this.max = DFA185_max;
			this.accept = DFA185_accept;
			this.special = DFA185_special;
			this.transition = DFA185_transition;
		}

		public override string Description { get { return "()* loopback of 325:23: ( ( LT )* '&' ( LT )* equalityExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA188 : DFA
	{
		private const string DFA188_eotS =
			"\x4\xFFFF";
		private const string DFA188_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA188_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA188_maxS =
			"\x2\x57\x2\xFFFF";
		private const string DFA188_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA188_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA188_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x5\x2\x1\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x5\x2\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA188_eot = DFA.UnpackEncodedString(DFA188_eotS);
		private static readonly short[] DFA188_eof = DFA.UnpackEncodedString(DFA188_eofS);
		private static readonly char[] DFA188_min = DFA.UnpackEncodedStringToUnsignedChars(DFA188_minS);
		private static readonly char[] DFA188_max = DFA.UnpackEncodedStringToUnsignedChars(DFA188_maxS);
		private static readonly short[] DFA188_accept = DFA.UnpackEncodedString(DFA188_acceptS);
		private static readonly short[] DFA188_special = DFA.UnpackEncodedString(DFA188_specialS);
		private static readonly short[][] DFA188_transition;

		static DFA188()
		{
			int numStates = DFA188_transitionS.Length;
			DFA188_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA188_transition[i] = DFA.UnpackEncodedString(DFA188_transitionS[i]);
			}
		}

		public DFA188( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 188;
			this.eot = DFA188_eot;
			this.eof = DFA188_eof;
			this.min = DFA188_min;
			this.max = DFA188_max;
			this.accept = DFA188_accept;
			this.special = DFA188_special;
			this.transition = DFA188_transition;
		}

		public override string Description { get { return "()* loopback of 329:27: ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA191 : DFA
	{
		private const string DFA191_eotS =
			"\x5\xFFFF";
		private const string DFA191_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA191_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA191_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA191_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA191_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA191_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF\xA\x2\x2"+
				"\xFFFF\x2\x2\xC\xFFFF\x6\x2\x4\x3\x8\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x6\x2\x4\x3\x8\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\xFFFF"+
				"\xA\x2\x2\xFFFF\x2\x2\xC\xFFFF\x6\x2\x4\x3\x8\xFFFF\x2\x2\x3\xFFFF\x7"+
				"\x2"
			};

		private static readonly short[] DFA191_eot = DFA.UnpackEncodedString(DFA191_eotS);
		private static readonly short[] DFA191_eof = DFA.UnpackEncodedString(DFA191_eofS);
		private static readonly char[] DFA191_min = DFA.UnpackEncodedStringToUnsignedChars(DFA191_minS);
		private static readonly char[] DFA191_max = DFA.UnpackEncodedStringToUnsignedChars(DFA191_maxS);
		private static readonly short[] DFA191_accept = DFA.UnpackEncodedString(DFA191_acceptS);
		private static readonly short[] DFA191_special = DFA.UnpackEncodedString(DFA191_specialS);
		private static readonly short[][] DFA191_transition;

		static DFA191()
		{
			int numStates = DFA191_transitionS.Length;
			DFA191_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA191_transition[i] = DFA.UnpackEncodedString(DFA191_transitionS[i]);
			}
		}

		public DFA191( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 191;
			this.eot = DFA191_eot;
			this.eof = DFA191_eof;
			this.min = DFA191_min;
			this.max = DFA191_max;
			this.accept = DFA191_accept;
			this.special = DFA191_special;
			this.transition = DFA191_transition;
		}

		public override string Description { get { return "()* loopback of 333:25: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA194 : DFA
	{
		private const string DFA194_eotS =
			"\x4\xFFFF";
		private const string DFA194_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA194_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA194_maxS =
			"\x2\x5B\x2\xFFFF";
		private const string DFA194_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA194_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA194_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x6\x2\x4\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\x6\x2\x4\x3",
				"",
				""
			};

		private static readonly short[] DFA194_eot = DFA.UnpackEncodedString(DFA194_eotS);
		private static readonly short[] DFA194_eof = DFA.UnpackEncodedString(DFA194_eofS);
		private static readonly char[] DFA194_min = DFA.UnpackEncodedStringToUnsignedChars(DFA194_minS);
		private static readonly char[] DFA194_max = DFA.UnpackEncodedStringToUnsignedChars(DFA194_maxS);
		private static readonly short[] DFA194_accept = DFA.UnpackEncodedString(DFA194_acceptS);
		private static readonly short[] DFA194_special = DFA.UnpackEncodedString(DFA194_specialS);
		private static readonly short[][] DFA194_transition;

		static DFA194()
		{
			int numStates = DFA194_transitionS.Length;
			DFA194_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA194_transition[i] = DFA.UnpackEncodedString(DFA194_transitionS[i]);
			}
		}

		public DFA194( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 194;
			this.eot = DFA194_eot;
			this.eof = DFA194_eof;
			this.min = DFA194_min;
			this.max = DFA194_max;
			this.accept = DFA194_accept;
			this.special = DFA194_special;
			this.transition = DFA194_transition;
		}

		public override string Description { get { return "()* loopback of 337:29: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA197 : DFA
	{
		private const string DFA197_eotS =
			"\x5\xFFFF";
		private const string DFA197_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA197_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA197_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA197_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA197_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA197_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\x3\xA\x2\x2\xFFFF"+
				"\x2\x2\xC\xFFFF\xA\x2\x5\x3\x3\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\x3\xA"+
				"\x2\x2\xFFFF\x2\x2\xC\xFFFF\xA\x2\x5\x3\x3\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x5\x2\x1\x3\xA"+
				"\x2\x2\xFFFF\x2\x2\xC\xFFFF\xA\x2\x5\x3\x3\xFFFF\x2\x2\x3\xFFFF\x7\x2"
			};

		private static readonly short[] DFA197_eot = DFA.UnpackEncodedString(DFA197_eotS);
		private static readonly short[] DFA197_eof = DFA.UnpackEncodedString(DFA197_eofS);
		private static readonly char[] DFA197_min = DFA.UnpackEncodedStringToUnsignedChars(DFA197_minS);
		private static readonly char[] DFA197_max = DFA.UnpackEncodedStringToUnsignedChars(DFA197_maxS);
		private static readonly short[] DFA197_accept = DFA.UnpackEncodedString(DFA197_acceptS);
		private static readonly short[] DFA197_special = DFA.UnpackEncodedString(DFA197_specialS);
		private static readonly short[][] DFA197_transition;

		static DFA197()
		{
			int numStates = DFA197_transitionS.Length;
			DFA197_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA197_transition[i] = DFA.UnpackEncodedString(DFA197_transitionS[i]);
			}
		}

		public DFA197( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 197;
			this.eot = DFA197_eot;
			this.eof = DFA197_eof;
			this.min = DFA197_min;
			this.max = DFA197_max;
			this.accept = DFA197_accept;
			this.special = DFA197_special;
			this.transition = DFA197_transition;
		}

		public override string Description { get { return "()* loopback of 341:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA200 : DFA
	{
		private const string DFA200_eotS =
			"\x4\xFFFF";
		private const string DFA200_eofS =
			"\x1\x2\x3\xFFFF";
		private const string DFA200_minS =
			"\x2\xB\x2\xFFFF";
		private const string DFA200_maxS =
			"\x2\x60\x2\xFFFF";
		private const string DFA200_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA200_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA200_transitionS =
			{
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\xA\x2\x5\x3",
				"\x1\x1\x1F\xFFFF\x1\x2\x2\xFFFF\x1\x2\x8\xFFFF\x1\x2\x4\xFFFF\x1\x2"+
				"\x15\xFFFF\xA\x2\x5\x3",
				"",
				""
			};

		private static readonly short[] DFA200_eot = DFA.UnpackEncodedString(DFA200_eotS);
		private static readonly short[] DFA200_eof = DFA.UnpackEncodedString(DFA200_eofS);
		private static readonly char[] DFA200_min = DFA.UnpackEncodedStringToUnsignedChars(DFA200_minS);
		private static readonly char[] DFA200_max = DFA.UnpackEncodedStringToUnsignedChars(DFA200_maxS);
		private static readonly short[] DFA200_accept = DFA.UnpackEncodedString(DFA200_acceptS);
		private static readonly short[] DFA200_special = DFA.UnpackEncodedString(DFA200_specialS);
		private static readonly short[][] DFA200_transition;

		static DFA200()
		{
			int numStates = DFA200_transitionS.Length;
			DFA200_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA200_transition[i] = DFA.UnpackEncodedString(DFA200_transitionS[i]);
			}
		}

		public DFA200( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 200;
			this.eot = DFA200_eot;
			this.eof = DFA200_eof;
			this.min = DFA200_min;
			this.max = DFA200_max;
			this.accept = DFA200_accept;
			this.special = DFA200_special;
			this.transition = DFA200_transition;
		}

		public override string Description { get { return "()* loopback of 345:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA203 : DFA
	{
		private const string DFA203_eotS =
			"\x5\xFFFF";
		private const string DFA203_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA203_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA203_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA203_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA203_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA203_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF\x2\x2\xC"+
				"\xFFFF\xF\x2\x3\x3\x2\x2\x3\xFFFF\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF"+
				"\x2\x2\xC\xFFFF\xF\x2\x3\x3\x2\x2\x3\xFFFF\x7\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF"+
				"\x2\x2\xC\xFFFF\xF\x2\x3\x3\x2\x2\x3\xFFFF\x7\x2"
			};

		private static readonly short[] DFA203_eot = DFA.UnpackEncodedString(DFA203_eotS);
		private static readonly short[] DFA203_eof = DFA.UnpackEncodedString(DFA203_eofS);
		private static readonly char[] DFA203_min = DFA.UnpackEncodedStringToUnsignedChars(DFA203_minS);
		private static readonly char[] DFA203_max = DFA.UnpackEncodedStringToUnsignedChars(DFA203_maxS);
		private static readonly short[] DFA203_accept = DFA.UnpackEncodedString(DFA203_acceptS);
		private static readonly short[] DFA203_special = DFA.UnpackEncodedString(DFA203_specialS);
		private static readonly short[][] DFA203_transition;

		static DFA203()
		{
			int numStates = DFA203_transitionS.Length;
			DFA203_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA203_transition[i] = DFA.UnpackEncodedString(DFA203_transitionS[i]);
			}
		}

		public DFA203( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 203;
			this.eot = DFA203_eot;
			this.eof = DFA203_eof;
			this.min = DFA203_min;
			this.max = DFA203_max;
			this.accept = DFA203_accept;
			this.special = DFA203_special;
			this.transition = DFA203_transition;
		}

		public override string Description { get { return "()* loopback of 349:23: ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA206 : DFA
	{
		private const string DFA206_eotS =
			"\x34\xFFFF";
		private const string DFA206_eofS =
			"\x1\x2\x33\xFFFF";
		private const string DFA206_minS =
			"\x1\x4\x1\x0\x1C\xFFFF\x1\x0\x15\xFFFF";
		private const string DFA206_maxS =
			"\x1\x6F\x1\x0\x1C\xFFFF\x1\x0\x15\xFFFF";
		private const string DFA206_acceptS =
			"\x2\xFFFF\x1\x2\x30\xFFFF\x1\x1";
		private const string DFA206_specialS =
			"\x1\xFFFF\x1\x0\x1C\xFFFF\x1\x1\x15\xFFFF}>";
		private static readonly string[] DFA206_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF\x2\x2\xC"+
				"\xFFFF\x12\x2\x2\x1E\x3\xFFFF\x7\x2",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA206_eot = DFA.UnpackEncodedString(DFA206_eotS);
		private static readonly short[] DFA206_eof = DFA.UnpackEncodedString(DFA206_eofS);
		private static readonly char[] DFA206_min = DFA.UnpackEncodedStringToUnsignedChars(DFA206_minS);
		private static readonly char[] DFA206_max = DFA.UnpackEncodedStringToUnsignedChars(DFA206_maxS);
		private static readonly short[] DFA206_accept = DFA.UnpackEncodedString(DFA206_acceptS);
		private static readonly short[] DFA206_special = DFA.UnpackEncodedString(DFA206_specialS);
		private static readonly short[][] DFA206_transition;

		static DFA206()
		{
			int numStates = DFA206_transitionS.Length;
			DFA206_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA206_transition[i] = DFA.UnpackEncodedString(DFA206_transitionS[i]);
			}
		}

		public DFA206( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 206;
			this.eot = DFA206_eot;
			this.eof = DFA206_eof;
			this.min = DFA206_min;
			this.max = DFA206_max;
			this.accept = DFA206_accept;
			this.special = DFA206_special;
			this.transition = DFA206_transition;
		}

		public override string Description { get { return "()* loopback of 353:29: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition206(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA206_1 = input.LA(1);


				int index206_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred255_JavaScript_fragment)) ) {s = 51;}

				else if ( (true) ) {s = 2;}


				input.Seek(index206_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA206_30 = input.LA(1);


				int index206_30 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred255_JavaScript_fragment)) ) {s = 51;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 2;}


				input.Seek(index206_30);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 206, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA209 : DFA
	{
		private const string DFA209_eotS =
			"\x5\xFFFF";
		private const string DFA209_eofS =
			"\x2\x2\x2\xFFFF\x1\x2";
		private const string DFA209_minS =
			"\x2\x4\x2\xFFFF\x1\x4";
		private const string DFA209_maxS =
			"\x2\x6F\x2\xFFFF\x1\x6F";
		private const string DFA209_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF";
		private const string DFA209_specialS =
			"\x5\xFFFF}>";
		private static readonly string[] DFA209_transitionS =
			{
				"\x7\x2\x1\x1\x6\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF\x2\x2\xC"+
				"\xFFFF\x14\x2\x3\x3\x7\x2",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF"+
				"\x2\x2\xC\xFFFF\x14\x2\x3\x3\x7\x2",
				"",
				"",
				"\x7\x2\x1\x4\x2\xFFFF\x4\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF"+
				"\x2\x2\xC\xFFFF\x14\x2\x3\x3\x7\x2"
			};

		private static readonly short[] DFA209_eot = DFA.UnpackEncodedString(DFA209_eotS);
		private static readonly short[] DFA209_eof = DFA.UnpackEncodedString(DFA209_eofS);
		private static readonly char[] DFA209_min = DFA.UnpackEncodedStringToUnsignedChars(DFA209_minS);
		private static readonly char[] DFA209_max = DFA.UnpackEncodedStringToUnsignedChars(DFA209_maxS);
		private static readonly short[] DFA209_accept = DFA.UnpackEncodedString(DFA209_acceptS);
		private static readonly short[] DFA209_special = DFA.UnpackEncodedString(DFA209_specialS);
		private static readonly short[][] DFA209_transition;

		static DFA209()
		{
			int numStates = DFA209_transitionS.Length;
			DFA209_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA209_transition[i] = DFA.UnpackEncodedString(DFA209_transitionS[i]);
			}
		}

		public DFA209( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 209;
			this.eot = DFA209_eot;
			this.eof = DFA209_eof;
			this.min = DFA209_min;
			this.max = DFA209_max;
			this.accept = DFA209_accept;
			this.special = DFA209_special;
			this.transition = DFA209_transition;
		}

		public override string Description { get { return "()* loopback of 357:20: ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA211 : DFA
	{
		private const string DFA211_eotS =
			"\x36\xFFFF";
		private const string DFA211_eofS =
			"\x1\x2\x35\xFFFF";
		private const string DFA211_minS =
			"\x1\x4\x1\x0\x34\xFFFF";
		private const string DFA211_maxS =
			"\x1\x6F\x1\x0\x34\xFFFF";
		private const string DFA211_acceptS =
			"\x2\xFFFF\x1\x2\x32\xFFFF\x1\x1";
		private const string DFA211_specialS =
			"\x1\xFFFF\x1\x0\x34\xFFFF}>";
		private static readonly string[] DFA211_transitionS =
			{
				"\xE\x2\x19\xFFFF\x6\x2\x1\xFFFF\x10\x2\x2\xFFFF\x2\x2\xC\xFFFF\x1A"+
				"\x2\x2\x1\x2\x2",
				"\x1\xFFFF",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA211_eot = DFA.UnpackEncodedString(DFA211_eotS);
		private static readonly short[] DFA211_eof = DFA.UnpackEncodedString(DFA211_eofS);
		private static readonly char[] DFA211_min = DFA.UnpackEncodedStringToUnsignedChars(DFA211_minS);
		private static readonly char[] DFA211_max = DFA.UnpackEncodedStringToUnsignedChars(DFA211_maxS);
		private static readonly short[] DFA211_accept = DFA.UnpackEncodedString(DFA211_acceptS);
		private static readonly short[] DFA211_special = DFA.UnpackEncodedString(DFA211_specialS);
		private static readonly short[][] DFA211_transition;

		static DFA211()
		{
			int numStates = DFA211_transitionS.Length;
			DFA211_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA211_transition[i] = DFA.UnpackEncodedString(DFA211_transitionS[i]);
			}
		}

		public DFA211( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 211;
			this.eot = DFA211_eot;
			this.eof = DFA211_eof;
			this.min = DFA211_min;
			this.max = DFA211_max;
			this.accept = DFA211_accept;
			this.special = DFA211_special;
			this.transition = DFA211_transition;
		}

		public override string Description { get { return "366:27: ( '++' | '--' )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition211(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA211_1 = input.LA(1);


				int index211_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (!((( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )))) ) {s = 53;}

				else if ( (( input.LA(-1) == RBRACE || input.LA(1) == RBRACE )) ) {s = 2;}


				input.Seek(index211_1);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 211, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA220 : DFA
	{
		private const string DFA220_eotS =
			"\x4\xFFFF";
		private const string DFA220_eofS =
			"\x4\xFFFF";
		private const string DFA220_minS =
			"\x2\x8\x2\xFFFF";
		private const string DFA220_maxS =
			"\x2\x2E\x2\xFFFF";
		private const string DFA220_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA220_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA220_transitionS =
			{
				"\x1\x2\x2\xFFFF\x1\x1\x22\xFFFF\x1\x3",
				"\x1\x2\x2\xFFFF\x1\x1\x22\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA220_eot = DFA.UnpackEncodedString(DFA220_eotS);
		private static readonly short[] DFA220_eof = DFA.UnpackEncodedString(DFA220_eofS);
		private static readonly char[] DFA220_min = DFA.UnpackEncodedStringToUnsignedChars(DFA220_minS);
		private static readonly char[] DFA220_max = DFA.UnpackEncodedStringToUnsignedChars(DFA220_maxS);
		private static readonly short[] DFA220_accept = DFA.UnpackEncodedString(DFA220_acceptS);
		private static readonly short[] DFA220_special = DFA.UnpackEncodedString(DFA220_specialS);
		private static readonly short[][] DFA220_transition;

		static DFA220()
		{
			int numStates = DFA220_transitionS.Length;
			DFA220_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA220_transition[i] = DFA.UnpackEncodedString(DFA220_transitionS[i]);
			}
		}

		public DFA220( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 220;
			this.eot = DFA220_eot;
			this.eof = DFA220_eof;
			this.min = DFA220_min;
			this.max = DFA220_max;
			this.accept = DFA220_accept;
			this.special = DFA220_special;
			this.transition = DFA220_transition;
		}

		public override string Description { get { return "()* loopback of 380:35: ( ( LT )* ',' ( ( LT )* assignmentExpression )? )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA219 : DFA
	{
		private const string DFA219_eotS =
			"\x4\xFFFF";
		private const string DFA219_eofS =
			"\x4\xFFFF";
		private const string DFA219_minS =
			"\x2\x4\x2\xFFFF";
		private const string DFA219_maxS =
			"\x2\x6F\x2\xFFFF";
		private const string DFA219_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA219_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA219_transitionS =
			{
				"\x4\x2\x1\x3\x2\xFFFF\x1\x1\x2\xFFFF\x4\x2\x1A\xFFFF\x2\x2\x1\x3\x1"+
				"\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"\x4\x2\x1\x3\x2\xFFFF\x1\x1\x2\xFFFF\x4\x2\x1A\xFFFF\x2\x2\x1\x3\x1"+
				"\x2\x14\xFFFF\x2\x2\x1E\xFFFF\x2\x2\x3\xFFFF\x7\x2",
				"",
				""
			};

		private static readonly short[] DFA219_eot = DFA.UnpackEncodedString(DFA219_eotS);
		private static readonly short[] DFA219_eof = DFA.UnpackEncodedString(DFA219_eofS);
		private static readonly char[] DFA219_min = DFA.UnpackEncodedStringToUnsignedChars(DFA219_minS);
		private static readonly char[] DFA219_max = DFA.UnpackEncodedStringToUnsignedChars(DFA219_maxS);
		private static readonly short[] DFA219_accept = DFA.UnpackEncodedString(DFA219_acceptS);
		private static readonly short[] DFA219_special = DFA.UnpackEncodedString(DFA219_specialS);
		private static readonly short[][] DFA219_transition;

		static DFA219()
		{
			int numStates = DFA219_transitionS.Length;
			DFA219_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA219_transition[i] = DFA.UnpackEncodedString(DFA219_transitionS[i]);
			}
		}

		public DFA219( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 219;
			this.eot = DFA219_eot;
			this.eof = DFA219_eof;
			this.min = DFA219_min;
			this.max = DFA219_max;
			this.accept = DFA219_accept;
			this.special = DFA219_special;
			this.transition = DFA219_transition;
		}

		public override string Description { get { return "380:45: ( ( LT )* assignmentExpression )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA227 : DFA
	{
		private const string DFA227_eotS =
			"\x4\xFFFF";
		private const string DFA227_eofS =
			"\x4\xFFFF";
		private const string DFA227_minS =
			"\x2\xA\x2\xFFFF";
		private const string DFA227_maxS =
			"\x2\x2E\x2\xFFFF";
		private const string DFA227_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1";
		private const string DFA227_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA227_transitionS =
			{
				"\x1\x2\x1\x1\x22\xFFFF\x1\x3",
				"\x1\x2\x1\x1\x22\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA227_eot = DFA.UnpackEncodedString(DFA227_eotS);
		private static readonly short[] DFA227_eof = DFA.UnpackEncodedString(DFA227_eofS);
		private static readonly char[] DFA227_min = DFA.UnpackEncodedStringToUnsignedChars(DFA227_minS);
		private static readonly char[] DFA227_max = DFA.UnpackEncodedStringToUnsignedChars(DFA227_maxS);
		private static readonly short[] DFA227_accept = DFA.UnpackEncodedString(DFA227_acceptS);
		private static readonly short[] DFA227_special = DFA.UnpackEncodedString(DFA227_specialS);
		private static readonly short[][] DFA227_transition;

		static DFA227()
		{
			int numStates = DFA227_transitionS.Length;
			DFA227_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA227_transition[i] = DFA.UnpackEncodedString(DFA227_transitionS[i]);
			}
		}

		public DFA227( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 227;
			this.eot = DFA227_eot;
			this.eof = DFA227_eof;
			this.min = DFA227_min;
			this.max = DFA227_max;
			this.accept = DFA227_accept;
			this.special = DFA227_special;
			this.transition = DFA227_transition;
		}

		public override string Description { get { return "()* loopback of 385:35: ( ( LT )* ',' ( ( LT )* propertyNameAndValue )? )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA226 : DFA
	{
		private const string DFA226_eotS =
			"\x4\xFFFF";
		private const string DFA226_eofS =
			"\x4\xFFFF";
		private const string DFA226_minS =
			"\x2\xA\x2\xFFFF";
		private const string DFA226_maxS =
			"\x2\x2E\x2\xFFFF";
		private const string DFA226_acceptS =
			"\x2\xFFFF\x1\x1\x1\x2";
		private const string DFA226_specialS =
			"\x4\xFFFF}>";
		private static readonly string[] DFA226_transitionS =
			{
				"\x1\x3\x1\x1\x2\xFFFF\x3\x2\x1D\xFFFF\x1\x3",
				"\x1\x3\x1\x1\x2\xFFFF\x3\x2\x1D\xFFFF\x1\x3",
				"",
				""
			};

		private static readonly short[] DFA226_eot = DFA.UnpackEncodedString(DFA226_eotS);
		private static readonly short[] DFA226_eof = DFA.UnpackEncodedString(DFA226_eofS);
		private static readonly char[] DFA226_min = DFA.UnpackEncodedStringToUnsignedChars(DFA226_minS);
		private static readonly char[] DFA226_max = DFA.UnpackEncodedStringToUnsignedChars(DFA226_maxS);
		private static readonly short[] DFA226_accept = DFA.UnpackEncodedString(DFA226_acceptS);
		private static readonly short[] DFA226_special = DFA.UnpackEncodedString(DFA226_specialS);
		private static readonly short[][] DFA226_transition;

		static DFA226()
		{
			int numStates = DFA226_transitionS.Length;
			DFA226_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA226_transition[i] = DFA.UnpackEncodedString(DFA226_transitionS[i]);
			}
		}

		public DFA226( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 226;
			this.eot = DFA226_eot;
			this.eof = DFA226_eof;
			this.min = DFA226_min;
			this.max = DFA226_max;
			this.accept = DFA226_accept;
			this.special = DFA226_special;
			this.transition = DFA226_transition;
		}

		public override string Description { get { return "385:45: ( ( LT )* propertyNameAndValue )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}


	#endregion DFA

	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _43_in_statementEnd122 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_statementEnd127 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Comment_in_statementEnd132 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LineComment_in_statementEnd137 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _EOF_in_statementEnd142 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_program159 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _sourceElements_in_program163 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _LT_in_program165 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _EOF_in_program169 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _sourceElement_in_sourceElements182 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_sourceElements185 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _sourceElement_in_sourceElements189 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _functionDeclaration_in_sourceElement203 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _statement_in_sourceElement208 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _44_in_functionDeclaration221 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_functionDeclaration223 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _Identifier_in_functionDeclaration227 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_functionDeclaration229 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _formalParameterList_in_functionDeclaration233 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _LT_in_functionDeclaration235 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _functionBody_in_functionDeclaration239 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _44_in_functionExpression251 = new BitSet(new ulong[]{0x200000004800UL});
		public static readonly BitSet _LT_in_functionExpression253 = new BitSet(new ulong[]{0x200000004800UL});
		public static readonly BitSet _Identifier_in_functionExpression257 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_functionExpression260 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _formalParameterList_in_functionExpression264 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _LT_in_functionExpression266 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _functionBody_in_functionExpression270 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _45_in_formalParameterList282 = new BitSet(new ulong[]{0x4A00UL});
		public static readonly BitSet _LT_in_formalParameterList285 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _Identifier_in_formalParameterList289 = new BitSet(new ulong[]{0x400000000A00UL});
		public static readonly BitSet _LT_in_formalParameterList292 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_formalParameterList296 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_formalParameterList298 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _Identifier_in_formalParameterList302 = new BitSet(new ulong[]{0x400000000A00UL});
		public static readonly BitSet _LT_in_formalParameterList308 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_formalParameterList312 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _47_in_functionBody323 = new BitSet(new ulong[]{0x2F75B8000003CCF0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_functionBody325 = new BitSet(new ulong[]{0x2F75B8000003CCF0UL,0xFE3000000033UL});
		public static readonly BitSet _sourceElements_in_functionBody329 = new BitSet(new ulong[]{0xC00UL});
		public static readonly BitSet _LT_in_functionBody332 = new BitSet(new ulong[]{0xC00UL});
		public static readonly BitSet _RBRACE_in_functionBody336 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _statementBlock_in_statement348 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _variableStatement_in_statement353 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _emptyStatement_in_statement358 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expressionStatement_in_statement363 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ifStatement_in_statement368 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _iterationStatement_in_statement373 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _continueStatement_in_statement378 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _breakStatement_in_statement383 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _returnStatement_in_statement388 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _withStatement_in_statement393 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _labelledStatement_in_statement398 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _switchStatement_in_statement403 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _throwStatement_in_statement408 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _tryStatement_in_statement413 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _47_in_statementBlock425 = new BitSet(new ulong[]{0x2F75B8000003CCF0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_statementBlock427 = new BitSet(new ulong[]{0x2F75B8000003CCF0UL,0xFE3000000033UL});
		public static readonly BitSet _statementList_in_statementBlock431 = new BitSet(new ulong[]{0xC00UL});
		public static readonly BitSet _LT_in_statementBlock434 = new BitSet(new ulong[]{0xC00UL});
		public static readonly BitSet _RBRACE_in_statementBlock438 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _statement_in_statementList450 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_statementList453 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_statementList457 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _48_in_variableStatement471 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_variableStatement473 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _variableDeclarationList_in_variableStatement477 = new BitSet(new ulong[]{0x80000003800UL});
		public static readonly BitSet _statementEnd_in_variableStatement479 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _variableDeclaration_in_variableDeclarationList491 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _LT_in_variableDeclarationList494 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_variableDeclarationList498 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_variableDeclarationList500 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _variableDeclaration_in_variableDeclarationList504 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _variableDeclarationNoIn_in_variableDeclarationListNoIn518 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _LT_in_variableDeclarationListNoIn521 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_variableDeclarationListNoIn525 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_variableDeclarationListNoIn527 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _variableDeclarationNoIn_in_variableDeclarationListNoIn531 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _Identifier_in_variableDeclaration545 = new BitSet(new ulong[]{0x2000000000802UL});
		public static readonly BitSet _LT_in_variableDeclaration548 = new BitSet(new ulong[]{0x2000000000800UL});
		public static readonly BitSet _initialiser_in_variableDeclaration552 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_variableDeclarationNoIn566 = new BitSet(new ulong[]{0x2000000000802UL});
		public static readonly BitSet _LT_in_variableDeclarationNoIn569 = new BitSet(new ulong[]{0x2000000000800UL});
		public static readonly BitSet _initialiserNoIn_in_variableDeclarationNoIn573 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _49_in_initialiser587 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_initialiser589 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_initialiser593 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _49_in_initialiserNoIn605 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_initialiserNoIn607 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_initialiserNoIn611 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _43_in_emptyStatement623 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expression_in_expressionStatement635 = new BitSet(new ulong[]{0x80000003800UL});
		public static readonly BitSet _statementEnd_in_expressionStatement637 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _50_in_ifStatement649 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_ifStatement651 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_ifStatement655 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_ifStatement657 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_ifStatement661 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_ifStatement663 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_ifStatement667 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_ifStatement669 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_ifStatement673 = new BitSet(new ulong[]{0x8000000000802UL});
		public static readonly BitSet _LT_in_ifStatement676 = new BitSet(new ulong[]{0x8000000000800UL});
		public static readonly BitSet _51_in_ifStatement680 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_ifStatement682 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_ifStatement686 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _doWhileStatement_in_iterationStatement700 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _whileStatement_in_iterationStatement705 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _forStatement_in_iterationStatement710 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _forInStatement_in_iterationStatement715 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _52_in_doWhileStatement727 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_doWhileStatement729 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_doWhileStatement733 = new BitSet(new ulong[]{0x20000000000800UL});
		public static readonly BitSet _LT_in_doWhileStatement735 = new BitSet(new ulong[]{0x20000000000800UL});
		public static readonly BitSet _53_in_doWhileStatement739 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_doWhileStatement741 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_doWhileStatement745 = new BitSet(new ulong[]{0xB0000003C0F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_doWhileStatement747 = new BitSet(new ulong[]{0x200UL});
		public static readonly BitSet _RPAREN_in_doWhileStatement749 = new BitSet(new ulong[]{0x80000003800UL});
		public static readonly BitSet _statementEnd_in_doWhileStatement751 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _53_in_whileStatement763 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_whileStatement765 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_whileStatement769 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_whileStatement771 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_whileStatement775 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_whileStatement777 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_whileStatement781 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_whileStatement783 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_whileStatement787 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _54_in_forStatement799 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_forStatement801 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_forStatement805 = new BitSet(new ulong[]{0x1B8000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_forStatement808 = new BitSet(new ulong[]{0x1B0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _forStatementInitialiserPart_in_forStatement812 = new BitSet(new ulong[]{0x80000000800UL});
		public static readonly BitSet _LT_in_forStatement816 = new BitSet(new ulong[]{0x80000000800UL});
		public static readonly BitSet _43_in_forStatement820 = new BitSet(new ulong[]{0xB8000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_forStatement823 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_forStatement827 = new BitSet(new ulong[]{0x80000000800UL});
		public static readonly BitSet _LT_in_forStatement831 = new BitSet(new ulong[]{0x80000000800UL});
		public static readonly BitSet _43_in_forStatement835 = new BitSet(new ulong[]{0xB0000003CAF0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_forStatement838 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_forStatement842 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_forStatement846 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_forStatement850 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_forStatement852 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_forStatement856 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expressionNoIn_in_forStatementInitialiserPart868 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_forStatementInitialiserPart873 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_forStatementInitialiserPart875 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _variableDeclarationListNoIn_in_forStatementInitialiserPart879 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _54_in_forInStatement891 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_forInStatement893 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_forInStatement897 = new BitSet(new ulong[]{0x1B0000003C8F0UL,0x30UL});
		public static readonly BitSet _LT_in_forInStatement899 = new BitSet(new ulong[]{0x1B0000003C8F0UL,0x30UL});
		public static readonly BitSet _forInStatementInitialiserPart_in_forInStatement903 = new BitSet(new ulong[]{0x80000000000800UL});
		public static readonly BitSet _LT_in_forInStatement905 = new BitSet(new ulong[]{0x80000000000800UL});
		public static readonly BitSet _55_in_forInStatement909 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_forInStatement911 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_forInStatement915 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_forInStatement917 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_forInStatement921 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_forInStatement923 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_forInStatement927 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _leftHandSideExpression_in_forInStatementInitialiserPart939 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_forInStatementInitialiserPart944 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_forInStatementInitialiserPart946 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _variableDeclarationNoIn_in_forInStatementInitialiserPart950 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _56_in_continueStatement961 = new BitSet(new ulong[]{0x80000007800UL});
		public static readonly BitSet _Identifier_in_continueStatement963 = new BitSet(new ulong[]{0x80000003800UL});
		public static readonly BitSet _statementEnd_in_continueStatement966 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _57_in_breakStatement977 = new BitSet(new ulong[]{0x80000007800UL});
		public static readonly BitSet _Identifier_in_breakStatement979 = new BitSet(new ulong[]{0x80000003800UL});
		public static readonly BitSet _statementEnd_in_breakStatement982 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _58_in_returnStatement993 = new BitSet(new ulong[]{0xB8000003F8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_returnStatement995 = new BitSet(new ulong[]{0x80000003800UL});
		public static readonly BitSet _statementEnd_in_returnStatement998 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _59_in_withStatement1010 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_withStatement1012 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_withStatement1016 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_withStatement1018 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_withStatement1022 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_withStatement1024 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_withStatement1028 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_withStatement1030 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_withStatement1034 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_labelledStatement1045 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _LT_in_labelledStatement1047 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _60_in_labelledStatement1051 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_labelledStatement1053 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_labelledStatement1057 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _61_in_switchStatement1069 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_switchStatement1071 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_switchStatement1075 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_switchStatement1077 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_switchStatement1081 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_switchStatement1083 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_switchStatement1087 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _LT_in_switchStatement1089 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _caseBlock_in_switchStatement1093 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _47_in_caseBlock1105 = new BitSet(new ulong[]{0xC000000000000C00UL});
		public static readonly BitSet _LT_in_caseBlock1108 = new BitSet(new ulong[]{0x4000000000000800UL});
		public static readonly BitSet _caseClause_in_caseBlock1112 = new BitSet(new ulong[]{0xC000000000000C00UL});
		public static readonly BitSet _LT_in_caseBlock1117 = new BitSet(new ulong[]{0x8000000000000800UL});
		public static readonly BitSet _defaultClause_in_caseBlock1121 = new BitSet(new ulong[]{0x4000000000000C00UL});
		public static readonly BitSet _LT_in_caseBlock1124 = new BitSet(new ulong[]{0x4000000000000800UL});
		public static readonly BitSet _caseClause_in_caseBlock1128 = new BitSet(new ulong[]{0x4000000000000C00UL});
		public static readonly BitSet _LT_in_caseBlock1134 = new BitSet(new ulong[]{0xC00UL});
		public static readonly BitSet _RBRACE_in_caseBlock1138 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _62_in_caseClause1149 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_caseClause1151 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_caseClause1155 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _LT_in_caseClause1157 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _60_in_caseClause1161 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_caseClause1163 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _statementList_in_caseClause1167 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _63_in_defaultClause1180 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _LT_in_defaultClause1182 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _60_in_defaultClause1186 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_defaultClause1188 = new BitSet(new ulong[]{0x2F75B8000003C8F2UL,0xFE3000000033UL});
		public static readonly BitSet _statementList_in_defaultClause1192 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _64_in_throwStatement1205 = new BitSet(new ulong[]{0xB0000003C0F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_throwStatement1207 = new BitSet(new ulong[]{0x80000003800UL});
		public static readonly BitSet _statementEnd_in_throwStatement1209 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _65_in_tryStatement1220 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _LT_in_tryStatement1222 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _statementBlock_in_tryStatement1226 = new BitSet(new ulong[]{0x800UL,0xCUL});
		public static readonly BitSet _LT_in_tryStatement1228 = new BitSet(new ulong[]{0x800UL,0xCUL});
		public static readonly BitSet _finallyClause_in_tryStatement1233 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _catchClause_in_tryStatement1237 = new BitSet(new ulong[]{0x802UL,0x8UL});
		public static readonly BitSet _LT_in_tryStatement1240 = new BitSet(new ulong[]{0x800UL,0x8UL});
		public static readonly BitSet _finallyClause_in_tryStatement1244 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _66_in_catchClause1265 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_catchClause1267 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _45_in_catchClause1271 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_catchClause1273 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _Identifier_in_catchClause1277 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_catchClause1279 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_catchClause1283 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _LT_in_catchClause1285 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _statementBlock_in_catchClause1289 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _67_in_finallyClause1301 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _LT_in_finallyClause1303 = new BitSet(new ulong[]{0x800000000800UL});
		public static readonly BitSet _statementBlock_in_finallyClause1307 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _assignmentExpression_in_expression1319 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _LT_in_expression1322 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_expression1326 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_expression1328 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_expression1332 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn1346 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _LT_in_expressionNoIn1349 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_expressionNoIn1353 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_expressionNoIn1355 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn1359 = new BitSet(new ulong[]{0x400000000802UL});
		public static readonly BitSet _conditionalExpression_in_assignmentExpression1373 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _leftHandSideExpression_in_assignmentExpression1378 = new BitSet(new ulong[]{0x2000000000800UL,0x3FF80UL});
		public static readonly BitSet _LT_in_assignmentExpression1380 = new BitSet(new ulong[]{0x2000000000800UL,0x3FF80UL});
		public static readonly BitSet _assignmentOperator_in_assignmentExpression1384 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_assignmentExpression1386 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_assignmentExpression1390 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _conditionalExpressionNoIn_in_assignmentExpressionNoIn1402 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _leftHandSideExpression_in_assignmentExpressionNoIn1407 = new BitSet(new ulong[]{0x2000000000800UL,0x3FF80UL});
		public static readonly BitSet _LT_in_assignmentExpressionNoIn1409 = new BitSet(new ulong[]{0x2000000000800UL,0x3FF80UL});
		public static readonly BitSet _assignmentOperator_in_assignmentExpressionNoIn1413 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_assignmentExpressionNoIn1415 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_assignmentExpressionNoIn1419 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _callExpression_in_leftHandSideExpression1431 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _newExpression_in_leftHandSideExpression1436 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _memberExpression_in_newExpression1448 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _68_in_newExpression1453 = new BitSet(new ulong[]{0xB0000003C8F0UL,0x30UL});
		public static readonly BitSet _LT_in_newExpression1455 = new BitSet(new ulong[]{0xB0000003C8F0UL,0x30UL});
		public static readonly BitSet _newExpression_in_newExpression1459 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _primaryExpression_in_memberExpression1472 = new BitSet(new ulong[]{0x802UL,0x60UL});
		public static readonly BitSet _functionExpression_in_memberExpression1476 = new BitSet(new ulong[]{0x802UL,0x60UL});
		public static readonly BitSet _68_in_memberExpression1480 = new BitSet(new ulong[]{0xB0000003C8F0UL,0x30UL});
		public static readonly BitSet _LT_in_memberExpression1482 = new BitSet(new ulong[]{0xB0000003C8F0UL,0x30UL});
		public static readonly BitSet _memberExpression_in_memberExpression1486 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_memberExpression1488 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _arguments_in_memberExpression1492 = new BitSet(new ulong[]{0x802UL,0x60UL});
		public static readonly BitSet _LT_in_memberExpression1496 = new BitSet(new ulong[]{0x800UL,0x60UL});
		public static readonly BitSet _memberExpressionSuffix_in_memberExpression1500 = new BitSet(new ulong[]{0x802UL,0x60UL});
		public static readonly BitSet _indexSuffix_in_memberExpressionSuffix1514 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _propertyReferenceSuffix_in_memberExpressionSuffix1519 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _memberExpression_in_callExpression1530 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _LT_in_callExpression1532 = new BitSet(new ulong[]{0x200000000800UL});
		public static readonly BitSet _arguments_in_callExpression1536 = new BitSet(new ulong[]{0x200000000802UL,0x60UL});
		public static readonly BitSet _LT_in_callExpression1539 = new BitSet(new ulong[]{0x200000000800UL,0x60UL});
		public static readonly BitSet _callExpressionSuffix_in_callExpression1543 = new BitSet(new ulong[]{0x200000000802UL,0x60UL});
		public static readonly BitSet _arguments_in_callExpressionSuffix1557 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _indexSuffix_in_callExpressionSuffix1562 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _propertyReferenceSuffix_in_callExpressionSuffix1567 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _45_in_arguments1578 = new BitSet(new ulong[]{0xB0000003CAF0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_arguments1581 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_arguments1585 = new BitSet(new ulong[]{0x400000000A00UL});
		public static readonly BitSet _LT_in_arguments1588 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_arguments1592 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_arguments1594 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_arguments1598 = new BitSet(new ulong[]{0x400000000A00UL});
		public static readonly BitSet _LT_in_arguments1604 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_arguments1608 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _69_in_indexSuffix1620 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_indexSuffix1622 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_indexSuffix1626 = new BitSet(new ulong[]{0x900UL});
		public static readonly BitSet _LT_in_indexSuffix1628 = new BitSet(new ulong[]{0x900UL});
		public static readonly BitSet _RBRACK_in_indexSuffix1632 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _70_in_propertyReferenceSuffix1645 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _LT_in_propertyReferenceSuffix1647 = new BitSet(new ulong[]{0x4800UL});
		public static readonly BitSet _Identifier_in_propertyReferenceSuffix1651 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_assignmentOperator0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _logicalORExpression_in_conditionalExpression1718 = new BitSet(new ulong[]{0x802UL,0x40000UL});
		public static readonly BitSet _LT_in_conditionalExpression1721 = new BitSet(new ulong[]{0x800UL,0x40000UL});
		public static readonly BitSet _82_in_conditionalExpression1725 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_conditionalExpression1727 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_conditionalExpression1731 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _LT_in_conditionalExpression1733 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _60_in_conditionalExpression1737 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_conditionalExpression1739 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_conditionalExpression1743 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _logicalORExpressionNoIn_in_conditionalExpressionNoIn1756 = new BitSet(new ulong[]{0x802UL,0x40000UL});
		public static readonly BitSet _LT_in_conditionalExpressionNoIn1759 = new BitSet(new ulong[]{0x800UL,0x40000UL});
		public static readonly BitSet _82_in_conditionalExpressionNoIn1763 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_conditionalExpressionNoIn1765 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn1769 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _LT_in_conditionalExpressionNoIn1771 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _60_in_conditionalExpressionNoIn1775 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_conditionalExpressionNoIn1777 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn1781 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _logicalANDExpression_in_logicalORExpression1794 = new BitSet(new ulong[]{0x802UL,0x80000UL});
		public static readonly BitSet _LT_in_logicalORExpression1797 = new BitSet(new ulong[]{0x800UL,0x80000UL});
		public static readonly BitSet _83_in_logicalORExpression1801 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_logicalORExpression1803 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _logicalANDExpression_in_logicalORExpression1807 = new BitSet(new ulong[]{0x802UL,0x80000UL});
		public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn1821 = new BitSet(new ulong[]{0x802UL,0x80000UL});
		public static readonly BitSet _LT_in_logicalORExpressionNoIn1824 = new BitSet(new ulong[]{0x800UL,0x80000UL});
		public static readonly BitSet _83_in_logicalORExpressionNoIn1828 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_logicalORExpressionNoIn1830 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn1834 = new BitSet(new ulong[]{0x802UL,0x80000UL});
		public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression1848 = new BitSet(new ulong[]{0x802UL,0x100000UL});
		public static readonly BitSet _LT_in_logicalANDExpression1851 = new BitSet(new ulong[]{0x800UL,0x100000UL});
		public static readonly BitSet _84_in_logicalANDExpression1855 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_logicalANDExpression1857 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression1861 = new BitSet(new ulong[]{0x802UL,0x100000UL});
		public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1875 = new BitSet(new ulong[]{0x802UL,0x100000UL});
		public static readonly BitSet _LT_in_logicalANDExpressionNoIn1878 = new BitSet(new ulong[]{0x800UL,0x100000UL});
		public static readonly BitSet _84_in_logicalANDExpressionNoIn1882 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_logicalANDExpressionNoIn1884 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1888 = new BitSet(new ulong[]{0x802UL,0x100000UL});
		public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression1902 = new BitSet(new ulong[]{0x802UL,0x200000UL});
		public static readonly BitSet _LT_in_bitwiseORExpression1905 = new BitSet(new ulong[]{0x800UL,0x200000UL});
		public static readonly BitSet _85_in_bitwiseORExpression1909 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_bitwiseORExpression1911 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression1915 = new BitSet(new ulong[]{0x802UL,0x200000UL});
		public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1929 = new BitSet(new ulong[]{0x802UL,0x200000UL});
		public static readonly BitSet _LT_in_bitwiseORExpressionNoIn1932 = new BitSet(new ulong[]{0x800UL,0x200000UL});
		public static readonly BitSet _85_in_bitwiseORExpressionNoIn1936 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_bitwiseORExpressionNoIn1938 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1942 = new BitSet(new ulong[]{0x802UL,0x200000UL});
		public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression1956 = new BitSet(new ulong[]{0x802UL,0x400000UL});
		public static readonly BitSet _LT_in_bitwiseXORExpression1959 = new BitSet(new ulong[]{0x800UL,0x400000UL});
		public static readonly BitSet _86_in_bitwiseXORExpression1963 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_bitwiseXORExpression1965 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression1969 = new BitSet(new ulong[]{0x802UL,0x400000UL});
		public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1983 = new BitSet(new ulong[]{0x802UL,0x400000UL});
		public static readonly BitSet _LT_in_bitwiseXORExpressionNoIn1986 = new BitSet(new ulong[]{0x800UL,0x400000UL});
		public static readonly BitSet _86_in_bitwiseXORExpressionNoIn1990 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_bitwiseXORExpressionNoIn1992 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1996 = new BitSet(new ulong[]{0x802UL,0x400000UL});
		public static readonly BitSet _equalityExpression_in_bitwiseANDExpression2010 = new BitSet(new ulong[]{0x802UL,0x800000UL});
		public static readonly BitSet _LT_in_bitwiseANDExpression2013 = new BitSet(new ulong[]{0x800UL,0x800000UL});
		public static readonly BitSet _87_in_bitwiseANDExpression2017 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_bitwiseANDExpression2019 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _equalityExpression_in_bitwiseANDExpression2023 = new BitSet(new ulong[]{0x802UL,0x800000UL});
		public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2037 = new BitSet(new ulong[]{0x802UL,0x800000UL});
		public static readonly BitSet _LT_in_bitwiseANDExpressionNoIn2040 = new BitSet(new ulong[]{0x800UL,0x800000UL});
		public static readonly BitSet _87_in_bitwiseANDExpressionNoIn2044 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_bitwiseANDExpressionNoIn2046 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2050 = new BitSet(new ulong[]{0x802UL,0x800000UL});
		public static readonly BitSet _relationalExpression_in_equalityExpression2064 = new BitSet(new ulong[]{0x802UL,0xF000000UL});
		public static readonly BitSet _LT_in_equalityExpression2067 = new BitSet(new ulong[]{0x800UL,0xF000000UL});
		public static readonly BitSet _set_in_equalityExpression2071 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_equalityExpression2087 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _relationalExpression_in_equalityExpression2091 = new BitSet(new ulong[]{0x802UL,0xF000000UL});
		public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn2104 = new BitSet(new ulong[]{0x802UL,0xF000000UL});
		public static readonly BitSet _LT_in_equalityExpressionNoIn2107 = new BitSet(new ulong[]{0x800UL,0xF000000UL});
		public static readonly BitSet _set_in_equalityExpressionNoIn2111 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_equalityExpressionNoIn2127 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn2131 = new BitSet(new ulong[]{0x802UL,0xF000000UL});
		public static readonly BitSet _shiftExpression_in_relationalExpression2145 = new BitSet(new ulong[]{0x80000000000802UL,0x1F0000000UL});
		public static readonly BitSet _LT_in_relationalExpression2148 = new BitSet(new ulong[]{0x80000000000800UL,0x1F0000000UL});
		public static readonly BitSet _set_in_relationalExpression2152 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_relationalExpression2176 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _shiftExpression_in_relationalExpression2180 = new BitSet(new ulong[]{0x80000000000802UL,0x1F0000000UL});
		public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn2193 = new BitSet(new ulong[]{0x802UL,0x1F0000000UL});
		public static readonly BitSet _LT_in_relationalExpressionNoIn2196 = new BitSet(new ulong[]{0x800UL,0x1F0000000UL});
		public static readonly BitSet _set_in_relationalExpressionNoIn2200 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_relationalExpressionNoIn2220 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn2224 = new BitSet(new ulong[]{0x802UL,0x1F0000000UL});
		public static readonly BitSet _additiveExpression_in_shiftExpression2237 = new BitSet(new ulong[]{0x802UL,0xE00000000UL});
		public static readonly BitSet _LT_in_shiftExpression2240 = new BitSet(new ulong[]{0x800UL,0xE00000000UL});
		public static readonly BitSet _set_in_shiftExpression2244 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_shiftExpression2256 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _additiveExpression_in_shiftExpression2260 = new BitSet(new ulong[]{0x802UL,0xE00000000UL});
		public static readonly BitSet _multiplicativeExpression_in_additiveExpression2273 = new BitSet(new ulong[]{0x802UL,0x3000000000UL});
		public static readonly BitSet _LT_in_additiveExpression2276 = new BitSet(new ulong[]{0x800UL,0x3000000000UL});
		public static readonly BitSet _set_in_additiveExpression2280 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_additiveExpression2288 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _multiplicativeExpression_in_additiveExpression2292 = new BitSet(new ulong[]{0x802UL,0x3000000000UL});
		public static readonly BitSet _unaryExpression_in_multiplicativeExpression2305 = new BitSet(new ulong[]{0x802UL,0x1C000000000UL});
		public static readonly BitSet _LT_in_multiplicativeExpression2308 = new BitSet(new ulong[]{0x800UL,0x1C000000000UL});
		public static readonly BitSet _set_in_multiplicativeExpression2312 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_multiplicativeExpression2324 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _unaryExpression_in_multiplicativeExpression2328 = new BitSet(new ulong[]{0x802UL,0x1C000000000UL});
		public static readonly BitSet _postfixExpression_in_unaryExpression2341 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_unaryExpression2346 = new BitSet(new ulong[]{0xB0000003C0F0UL,0xFE3000000030UL});
		public static readonly BitSet _unaryExpression_in_unaryExpression2382 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _leftHandSideExpression_in_postfixExpression2394 = new BitSet(new ulong[]{0x2UL,0x300000000000UL});
		public static readonly BitSet _set_in_postfixExpression2396 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _THIS_in_primaryExpression2414 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_primaryExpression2419 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _literal_in_primaryExpression2424 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _arrayLiteral_in_primaryExpression2429 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _objectLiteral_in_primaryExpression2434 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _45_in_primaryExpression2439 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_primaryExpression2441 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _expression_in_primaryExpression2445 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _LT_in_primaryExpression2447 = new BitSet(new ulong[]{0xA00UL});
		public static readonly BitSet _RPAREN_in_primaryExpression2451 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _69_in_arrayLiteral2464 = new BitSet(new ulong[]{0xF0000003C9F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_arrayLiteral2466 = new BitSet(new ulong[]{0xF0000003C9F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_arrayLiteral2470 = new BitSet(new ulong[]{0x400000000900UL});
		public static readonly BitSet _LT_in_arrayLiteral2474 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_arrayLiteral2478 = new BitSet(new ulong[]{0xF0000003C9F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_arrayLiteral2481 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_arrayLiteral2485 = new BitSet(new ulong[]{0x400000000900UL});
		public static readonly BitSet _LT_in_arrayLiteral2491 = new BitSet(new ulong[]{0x900UL});
		public static readonly BitSet _RBRACK_in_arrayLiteral2495 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _47_in_objectLiteral2514 = new BitSet(new ulong[]{0x40000001CC00UL});
		public static readonly BitSet _LT_in_objectLiteral2516 = new BitSet(new ulong[]{0x40000001CC00UL});
		public static readonly BitSet _propertyNameAndValue_in_objectLiteral2520 = new BitSet(new ulong[]{0x400000000C00UL});
		public static readonly BitSet _LT_in_objectLiteral2524 = new BitSet(new ulong[]{0x400000000800UL});
		public static readonly BitSet _46_in_objectLiteral2528 = new BitSet(new ulong[]{0x40000001CC00UL});
		public static readonly BitSet _LT_in_objectLiteral2531 = new BitSet(new ulong[]{0x1C800UL});
		public static readonly BitSet _propertyNameAndValue_in_objectLiteral2535 = new BitSet(new ulong[]{0x400000000C00UL});
		public static readonly BitSet _LT_in_objectLiteral2541 = new BitSet(new ulong[]{0xC00UL});
		public static readonly BitSet _RBRACE_in_objectLiteral2545 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _propertyName_in_propertyNameAndValue2557 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _LT_in_propertyNameAndValue2559 = new BitSet(new ulong[]{0x1000000000000800UL});
		public static readonly BitSet _60_in_propertyNameAndValue2563 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_propertyNameAndValue2565 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _assignmentExpression_in_propertyNameAndValue2569 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_propertyName2580 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _stringliteral_in_propertyName2585 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _numericliteral_in_propertyName2590 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NULL_in_literal2602 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _TRUE_in_literal2607 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FALSE_in_literal2612 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _stringliteral_in_literal2617 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _numericliteral_in_literal2622 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _regularExpressionLiteral_in_literal2627 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NumericLiteral_in_numericliteral2638 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _StringLiteral_in_stringliteral2650 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _RegularExpressionLiteral_in_regularExpressionLiteral2661 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _43_in_synpred1_JavaScript122 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred2_JavaScript127 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _functionDeclaration_in_synpred10_JavaScript203 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred14_JavaScript253 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred24_JavaScript325 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _statementBlock_in_synpred27_JavaScript348 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expressionStatement_in_synpred30_JavaScript363 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _labelledStatement_in_synpred37_JavaScript398 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred40_JavaScript427 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred64_JavaScript676 = new BitSet(new ulong[]{0x8000000000800UL});
		public static readonly BitSet _51_in_synpred64_JavaScript680 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _LT_in_synpred64_JavaScript682 = new BitSet(new ulong[]{0x2F75B8000003C8F0UL,0xFE3000000033UL});
		public static readonly BitSet _statement_in_synpred64_JavaScript686 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _forStatement_in_synpred67_JavaScript710 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_synpred96_JavaScript963 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_synpred97_JavaScript979 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expression_in_synpred98_JavaScript995 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred118_JavaScript1163 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred121_JavaScript1188 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _conditionalExpression_in_synpred139_JavaScript1373 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _conditionalExpressionNoIn_in_synpred142_JavaScript1402 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _callExpression_in_synpred145_JavaScript1431 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _memberExpression_in_synpred146_JavaScript1448 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred153_JavaScript1496 = new BitSet(new ulong[]{0x800UL,0x60UL});
		public static readonly BitSet _memberExpressionSuffix_in_synpred153_JavaScript1500 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred157_JavaScript1539 = new BitSet(new ulong[]{0x200000000800UL,0x60UL});
		public static readonly BitSet _callExpressionSuffix_in_synpred157_JavaScript1543 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred255_JavaScript2276 = new BitSet(new ulong[]{0x800UL,0x3000000000UL});
		public static readonly BitSet _set_in_synpred255_JavaScript2280 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _LT_in_synpred255_JavaScript2288 = new BitSet(new ulong[]{0xB0000003C8F0UL,0xFE3000000030UL});
		public static readonly BitSet _multiplicativeExpression_in_synpred255_JavaScript2292 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred279_JavaScript2466 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _LT_in_synpred286_JavaScript2516 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}
