using Code2Xml.Core.Antlr;
using System;
// $ANTLR 3.3 Nov 30, 2010 12:50:56 Lua.g 2011-06-08 19:06:16

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
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
public partial class LuaParser : Antlr.Runtime.Parser, IAntlrParser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "NAME", "INT", "FLOAT", "EXP", "HEX", "NORMALSTRING", "CHARSTRING", "LONGSTRING", "EscapeSequence", "UnicodeEscape", "OctalEscape", "HexDigit", "COMMENT", "LINE_COMMENT", "WS", "NEWLINE", "';'", "'='", "'do'", "'end'", "'while'", "'repeat'", "'until'", "'if'", "'then'", "'elseif'", "'else'", "'for'", "','", "'in'", "'function'", "'local'", "'return'", "'break'", "'.'", "':'", "'nil'", "'false'", "'true'", "'...'", "'('", "')'", "'['", "']'", "'{'", "'}'", "'+'", "'-'", "'*'", "'/'", "'^'", "'%'", "'..'", "'<'", "'<='", "'>'", "'>='", "'=='", "'~='", "'and'", "'or'", "'not'", "'#'"
	};
	public const int EOF=-1;
	public const int T__20=20;
	public const int T__21=21;
	public const int T__22=22;
	public const int T__23=23;
	public const int T__24=24;
	public const int T__25=25;
	public const int T__26=26;
	public const int T__27=27;
	public const int T__28=28;
	public const int T__29=29;
	public const int T__30=30;
	public const int T__31=31;
	public const int T__32=32;
	public const int T__33=33;
	public const int T__34=34;
	public const int T__35=35;
	public const int T__36=36;
	public const int T__37=37;
	public const int T__38=38;
	public const int T__39=39;
	public const int T__40=40;
	public const int T__41=41;
	public const int T__42=42;
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
	public const int NAME=4;
	public const int INT=5;
	public const int FLOAT=6;
	public const int EXP=7;
	public const int HEX=8;
	public const int NORMALSTRING=9;
	public const int CHARSTRING=10;
	public const int LONGSTRING=11;
	public const int EscapeSequence=12;
	public const int UnicodeEscape=13;
	public const int OctalEscape=14;
	public const int HexDigit=15;
	public const int COMMENT=16;
	public const int LINE_COMMENT=17;
	public const int WS=18;
	public const int NEWLINE=19;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false, false, false, true, false, 
				false, false, false, false, false, true, false, true, false, true, true, 
				true, true, false, false, false, false, false, false, false, false, 
				false, false, false, false, , , , , false, , , 
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public LuaParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public LuaParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		XmlTreeAdaptor treeAdaptor = null;
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new XmlTreeAdaptor();

		OnCreated();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	void CreateTreeAdaptor(ref XmlTreeAdaptor adaptor) {}

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

	public override string[] TokenNames { get { return LuaParser.tokenNames; } }
	public override string GrammarFileName { get { return "Lua.g"; } }



 	protected virtual void OnCreated() {}
	protected virtual void EnterRule(string ruleName, int ruleIndex) {}
	protected virtual void LeaveRule(string ruleName, int ruleIndex) {}

    public class chunk_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_chunk() {}
    protected virtual void Leave_chunk() {}

    // $ANTLR start "chunk"
    // Lua.g:23:1: chunk : ( stat ( ';' )? )* ( laststat ( ';' )? )? ;
    [GrammarRule("chunk")]
    public LuaParser.chunk_return chunk()
    {

        LuaParser.chunk_return retval = new LuaParser.chunk_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal2=null;
        IToken char_literal4=null;
        LuaParser.stat_return stat1 = default(LuaParser.stat_return);
        LuaParser.laststat_return laststat3 = default(LuaParser.laststat_return);

        object char_literal2_tree=null;
        object char_literal4_tree=null;

    	try { DebugEnterRule(GrammarFileName, "chunk");
    	DebugLocation(23, 41);
    	try
    	{
    		// Lua.g:23:7: ( ( stat ( ';' )? )* ( laststat ( ';' )? )? )
    		DebugEnterAlt(1);
    		// Lua.g:23:9: ( stat ( ';' )? )* ( laststat ( ';' )? )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(23, 9);
    		// Lua.g:23:9: ( stat ( ';' )? )*
    		try { DebugEnterSubRule(2);
    		while (true)
    		{
    			int alt2=2;
    			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
    			int LA2_0 = input.LA(1);

    			if ((LA2_0==NAME||LA2_0==22||(LA2_0>=24 && LA2_0<=25)||LA2_0==27||LA2_0==31||(LA2_0>=34 && LA2_0<=35)||LA2_0==44))
    			{
    				alt2=1;
    			}


    			} finally { DebugExitDecision(2); }
    			switch ( alt2 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:23:10: stat ( ';' )?
    				{
    				DebugLocation(23, 10);
    				PushFollow(Follow._stat_in_chunk37);
    				stat1=stat();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, stat1.Tree, stat1, retval);
    				DebugLocation(23, 15);
    				// Lua.g:23:15: ( ';' )?
    				int alt1=2;
    				try { DebugEnterSubRule(1);
    				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
    				int LA1_0 = input.LA(1);

    				if ((LA1_0==20))
    				{
    					alt1=1;
    				}
    				} finally { DebugExitDecision(1); }
    				switch (alt1)
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Lua.g:23:16: ';'
    					{
    					DebugLocation(23, 16);
    					char_literal2=(IToken)Match(input,20,Follow._20_in_chunk40); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal2_tree = (object)adaptor.Create(char_literal2, retval);
    					adaptor.AddChild(root_0, char_literal2_tree);
    					}

    					}
    					break;

    				}
    				} finally { DebugExitSubRule(1); }


    				}
    				break;

    			default:
    				goto loop2;
    			}
    		}

    		loop2:
    			;

    		} finally { DebugExitSubRule(2); }

    		DebugLocation(23, 24);
    		// Lua.g:23:24: ( laststat ( ';' )? )?
    		int alt4=2;
    		try { DebugEnterSubRule(4);
    		try { DebugEnterDecision(4, decisionCanBacktrack[4]);
    		int LA4_0 = input.LA(1);

    		if (((LA4_0>=36 && LA4_0<=37)))
    		{
    			alt4=1;
    		}
    		} finally { DebugExitDecision(4); }
    		switch (alt4)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:23:25: laststat ( ';' )?
    			{
    			DebugLocation(23, 25);
    			PushFollow(Follow._laststat_in_chunk47);
    			laststat3=laststat();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, laststat3.Tree, laststat3, retval);
    			DebugLocation(23, 34);
    			// Lua.g:23:34: ( ';' )?
    			int alt3=2;
    			try { DebugEnterSubRule(3);
    			try { DebugEnterDecision(3, decisionCanBacktrack[3]);
    			int LA3_0 = input.LA(1);

    			if ((LA3_0==20))
    			{
    				alt3=1;
    			}
    			} finally { DebugExitDecision(3); }
    			switch (alt3)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:23:35: ';'
    				{
    				DebugLocation(23, 35);
    				char_literal4=(IToken)Match(input,20,Follow._20_in_chunk50); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal4_tree = (object)adaptor.Create(char_literal4, retval);
    				adaptor.AddChild(root_0, char_literal4_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(3); }


    			}
    			break;

    		}
    		} finally { DebugExitSubRule(4); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(23, 41);
    	} finally { DebugExitRule(GrammarFileName, "chunk"); }
    	return retval;

    }
    // $ANTLR end "chunk"

    public class block_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_block() {}
    protected virtual void Leave_block() {}

    // $ANTLR start "block"
    // Lua.g:25:1: block : chunk ;
    [GrammarRule("block")]
    public LuaParser.block_return block()
    {

        LuaParser.block_return retval = new LuaParser.block_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        LuaParser.chunk_return chunk5 = default(LuaParser.chunk_return);


    	try { DebugEnterRule(GrammarFileName, "block");
    	DebugLocation(25, 13);
    	try
    	{
    		// Lua.g:25:7: ( chunk )
    		DebugEnterAlt(1);
    		// Lua.g:25:9: chunk
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(25, 9);
    		PushFollow(Follow._chunk_in_block62);
    		chunk5=chunk();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, chunk5.Tree, chunk5, retval);

    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(25, 13);
    	} finally { DebugExitRule(GrammarFileName, "block"); }
    	return retval;

    }
    // $ANTLR end "block"

    public class stat_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_stat() {}
    protected virtual void Leave_stat() {}

    // $ANTLR start "stat"
    // Lua.g:27:1: stat : ( varlist1 '=' explist1 | functioncall | 'do' block 'end' | 'while' exp 'do' block 'end' | 'repeat' block 'until' exp | 'if' exp 'then' block ( 'elseif' exp 'then' block )* ( 'else' block )? 'end' | 'for' NAME '=' exp ',' exp ( ',' exp )? 'do' block 'end' | 'for' namelist 'in' explist1 'do' block 'end' | 'function' funcname funcbody | 'local' 'function' NAME funcbody | 'local' namelist ( '=' explist1 )? );
    [GrammarRule("stat")]
    public LuaParser.stat_return stat()
    {

        LuaParser.stat_return retval = new LuaParser.stat_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal7=null;
        IToken string_literal10=null;
        IToken string_literal12=null;
        IToken string_literal13=null;
        IToken string_literal15=null;
        IToken string_literal17=null;
        IToken string_literal18=null;
        IToken string_literal20=null;
        IToken string_literal22=null;
        IToken string_literal24=null;
        IToken string_literal26=null;
        IToken string_literal28=null;
        IToken string_literal30=null;
        IToken string_literal32=null;
        IToken string_literal33=null;
        IToken NAME34=null;
        IToken char_literal35=null;
        IToken char_literal37=null;
        IToken char_literal39=null;
        IToken string_literal41=null;
        IToken string_literal43=null;
        IToken string_literal44=null;
        IToken string_literal46=null;
        IToken string_literal48=null;
        IToken string_literal50=null;
        IToken string_literal51=null;
        IToken string_literal54=null;
        IToken string_literal55=null;
        IToken NAME56=null;
        IToken string_literal58=null;
        IToken char_literal60=null;
        LuaParser.varlist1_return varlist16 = default(LuaParser.varlist1_return);
        LuaParser.explist1_return explist18 = default(LuaParser.explist1_return);
        LuaParser.functioncall_return functioncall9 = default(LuaParser.functioncall_return);
        LuaParser.block_return block11 = default(LuaParser.block_return);
        LuaParser.exp_return exp14 = default(LuaParser.exp_return);
        LuaParser.block_return block16 = default(LuaParser.block_return);
        LuaParser.block_return block19 = default(LuaParser.block_return);
        LuaParser.exp_return exp21 = default(LuaParser.exp_return);
        LuaParser.exp_return exp23 = default(LuaParser.exp_return);
        LuaParser.block_return block25 = default(LuaParser.block_return);
        LuaParser.exp_return exp27 = default(LuaParser.exp_return);
        LuaParser.block_return block29 = default(LuaParser.block_return);
        LuaParser.block_return block31 = default(LuaParser.block_return);
        LuaParser.exp_return exp36 = default(LuaParser.exp_return);
        LuaParser.exp_return exp38 = default(LuaParser.exp_return);
        LuaParser.exp_return exp40 = default(LuaParser.exp_return);
        LuaParser.block_return block42 = default(LuaParser.block_return);
        LuaParser.namelist_return namelist45 = default(LuaParser.namelist_return);
        LuaParser.explist1_return explist147 = default(LuaParser.explist1_return);
        LuaParser.block_return block49 = default(LuaParser.block_return);
        LuaParser.funcname_return funcname52 = default(LuaParser.funcname_return);
        LuaParser.funcbody_return funcbody53 = default(LuaParser.funcbody_return);
        LuaParser.funcbody_return funcbody57 = default(LuaParser.funcbody_return);
        LuaParser.namelist_return namelist59 = default(LuaParser.namelist_return);
        LuaParser.explist1_return explist161 = default(LuaParser.explist1_return);

        object char_literal7_tree=null;
        object string_literal10_tree=null;
        object string_literal12_tree=null;
        object string_literal13_tree=null;
        object string_literal15_tree=null;
        object string_literal17_tree=null;
        object string_literal18_tree=null;
        object string_literal20_tree=null;
        object string_literal22_tree=null;
        object string_literal24_tree=null;
        object string_literal26_tree=null;
        object string_literal28_tree=null;
        object string_literal30_tree=null;
        object string_literal32_tree=null;
        object string_literal33_tree=null;
        object NAME34_tree=null;
        object char_literal35_tree=null;
        object char_literal37_tree=null;
        object char_literal39_tree=null;
        object string_literal41_tree=null;
        object string_literal43_tree=null;
        object string_literal44_tree=null;
        object string_literal46_tree=null;
        object string_literal48_tree=null;
        object string_literal50_tree=null;
        object string_literal51_tree=null;
        object string_literal54_tree=null;
        object string_literal55_tree=null;
        object NAME56_tree=null;
        object string_literal58_tree=null;
        object char_literal60_tree=null;

    	try { DebugEnterRule(GrammarFileName, "stat");
    	DebugLocation(27, 34);
    	try
    	{
    		// Lua.g:27:6: ( varlist1 '=' explist1 | functioncall | 'do' block 'end' | 'while' exp 'do' block 'end' | 'repeat' block 'until' exp | 'if' exp 'then' block ( 'elseif' exp 'then' block )* ( 'else' block )? 'end' | 'for' NAME '=' exp ',' exp ( ',' exp )? 'do' block 'end' | 'for' namelist 'in' explist1 'do' block 'end' | 'function' funcname funcbody | 'local' 'function' NAME funcbody | 'local' namelist ( '=' explist1 )? )
    		int alt9=11;
    		try { DebugEnterDecision(9, decisionCanBacktrack[9]);
    		try
    		{
    			alt9 = dfa9.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(9); }
    		switch (alt9)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:27:9: varlist1 '=' explist1
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(27, 9);
    			PushFollow(Follow._varlist1_in_stat71);
    			varlist16=varlist1();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, varlist16.Tree, varlist16, retval);
    			DebugLocation(27, 18);
    			char_literal7=(IToken)Match(input,21,Follow._21_in_stat73); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal7_tree = (object)adaptor.Create(char_literal7, retval);
    			adaptor.AddChild(root_0, char_literal7_tree);
    			}
    			DebugLocation(27, 22);
    			PushFollow(Follow._explist1_in_stat75);
    			explist18=explist1();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, explist18.Tree, explist18, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:28:2: functioncall
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(28, 2);
    			PushFollow(Follow._functioncall_in_stat81);
    			functioncall9=functioncall();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, functioncall9.Tree, functioncall9, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Lua.g:29:2: 'do' block 'end'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(29, 2);
    			string_literal10=(IToken)Match(input,22,Follow._22_in_stat87); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal10_tree = (object)adaptor.Create(string_literal10, retval);
    			adaptor.AddChild(root_0, string_literal10_tree);
    			}
    			DebugLocation(29, 7);
    			PushFollow(Follow._block_in_stat89);
    			block11=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block11.Tree, block11, retval);
    			DebugLocation(29, 13);
    			string_literal12=(IToken)Match(input,23,Follow._23_in_stat91); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal12_tree = (object)adaptor.Create(string_literal12, retval);
    			adaptor.AddChild(root_0, string_literal12_tree);
    			}

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Lua.g:30:2: 'while' exp 'do' block 'end'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(30, 2);
    			string_literal13=(IToken)Match(input,24,Follow._24_in_stat97); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal13_tree = (object)adaptor.Create(string_literal13, retval);
    			adaptor.AddChild(root_0, string_literal13_tree);
    			}
    			DebugLocation(30, 10);
    			PushFollow(Follow._exp_in_stat99);
    			exp14=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp14.Tree, exp14, retval);
    			DebugLocation(30, 14);
    			string_literal15=(IToken)Match(input,22,Follow._22_in_stat101); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal15_tree = (object)adaptor.Create(string_literal15, retval);
    			adaptor.AddChild(root_0, string_literal15_tree);
    			}
    			DebugLocation(30, 19);
    			PushFollow(Follow._block_in_stat103);
    			block16=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block16.Tree, block16, retval);
    			DebugLocation(30, 25);
    			string_literal17=(IToken)Match(input,23,Follow._23_in_stat105); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal17_tree = (object)adaptor.Create(string_literal17, retval);
    			adaptor.AddChild(root_0, string_literal17_tree);
    			}

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Lua.g:31:2: 'repeat' block 'until' exp
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(31, 2);
    			string_literal18=(IToken)Match(input,25,Follow._25_in_stat111); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal18_tree = (object)adaptor.Create(string_literal18, retval);
    			adaptor.AddChild(root_0, string_literal18_tree);
    			}
    			DebugLocation(31, 11);
    			PushFollow(Follow._block_in_stat113);
    			block19=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block19.Tree, block19, retval);
    			DebugLocation(31, 17);
    			string_literal20=(IToken)Match(input,26,Follow._26_in_stat115); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal20_tree = (object)adaptor.Create(string_literal20, retval);
    			adaptor.AddChild(root_0, string_literal20_tree);
    			}
    			DebugLocation(31, 25);
    			PushFollow(Follow._exp_in_stat117);
    			exp21=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp21.Tree, exp21, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Lua.g:32:2: 'if' exp 'then' block ( 'elseif' exp 'then' block )* ( 'else' block )? 'end'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(32, 2);
    			string_literal22=(IToken)Match(input,27,Follow._27_in_stat123); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal22_tree = (object)adaptor.Create(string_literal22, retval);
    			adaptor.AddChild(root_0, string_literal22_tree);
    			}
    			DebugLocation(32, 7);
    			PushFollow(Follow._exp_in_stat125);
    			exp23=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp23.Tree, exp23, retval);
    			DebugLocation(32, 11);
    			string_literal24=(IToken)Match(input,28,Follow._28_in_stat127); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal24_tree = (object)adaptor.Create(string_literal24, retval);
    			adaptor.AddChild(root_0, string_literal24_tree);
    			}
    			DebugLocation(32, 18);
    			PushFollow(Follow._block_in_stat129);
    			block25=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block25.Tree, block25, retval);
    			DebugLocation(32, 24);
    			// Lua.g:32:24: ( 'elseif' exp 'then' block )*
    			try { DebugEnterSubRule(5);
    			while (true)
    			{
    				int alt5=2;
    				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
    				int LA5_0 = input.LA(1);

    				if ((LA5_0==29))
    				{
    					alt5=1;
    				}


    				} finally { DebugExitDecision(5); }
    				switch ( alt5 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Lua.g:32:25: 'elseif' exp 'then' block
    					{
    					DebugLocation(32, 25);
    					string_literal26=(IToken)Match(input,29,Follow._29_in_stat132); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					string_literal26_tree = (object)adaptor.Create(string_literal26, retval);
    					adaptor.AddChild(root_0, string_literal26_tree);
    					}
    					DebugLocation(32, 34);
    					PushFollow(Follow._exp_in_stat134);
    					exp27=exp();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp27.Tree, exp27, retval);
    					DebugLocation(32, 38);
    					string_literal28=(IToken)Match(input,28,Follow._28_in_stat136); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					string_literal28_tree = (object)adaptor.Create(string_literal28, retval);
    					adaptor.AddChild(root_0, string_literal28_tree);
    					}
    					DebugLocation(32, 45);
    					PushFollow(Follow._block_in_stat138);
    					block29=block();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block29.Tree, block29, retval);

    					}
    					break;

    				default:
    					goto loop5;
    				}
    			}

    			loop5:
    				;

    			} finally { DebugExitSubRule(5); }

    			DebugLocation(32, 53);
    			// Lua.g:32:53: ( 'else' block )?
    			int alt6=2;
    			try { DebugEnterSubRule(6);
    			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
    			int LA6_0 = input.LA(1);

    			if ((LA6_0==30))
    			{
    				alt6=1;
    			}
    			} finally { DebugExitDecision(6); }
    			switch (alt6)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:32:54: 'else' block
    				{
    				DebugLocation(32, 54);
    				string_literal30=(IToken)Match(input,30,Follow._30_in_stat143); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal30_tree = (object)adaptor.Create(string_literal30, retval);
    				adaptor.AddChild(root_0, string_literal30_tree);
    				}
    				DebugLocation(32, 61);
    				PushFollow(Follow._block_in_stat145);
    				block31=block();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block31.Tree, block31, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(6); }

    			DebugLocation(32, 69);
    			string_literal32=(IToken)Match(input,23,Follow._23_in_stat149); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal32_tree = (object)adaptor.Create(string_literal32, retval);
    			adaptor.AddChild(root_0, string_literal32_tree);
    			}

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Lua.g:33:2: 'for' NAME '=' exp ',' exp ( ',' exp )? 'do' block 'end'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(33, 2);
    			string_literal33=(IToken)Match(input,31,Follow._31_in_stat155); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal33_tree = (object)adaptor.Create(string_literal33, retval);
    			adaptor.AddChild(root_0, string_literal33_tree);
    			}
    			DebugLocation(33, 8);
    			NAME34=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_stat157), "NAME"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			NAME34_tree = (object)adaptor.Create(NAME34, retval);
    			adaptor.AddChild(root_0, NAME34_tree);
    			}
    			DebugLocation(33, 13);
    			char_literal35=(IToken)Match(input,21,Follow._21_in_stat159); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal35_tree = (object)adaptor.Create(char_literal35, retval);
    			adaptor.AddChild(root_0, char_literal35_tree);
    			}
    			DebugLocation(33, 17);
    			PushFollow(Follow._exp_in_stat161);
    			exp36=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp36.Tree, exp36, retval);
    			DebugLocation(33, 21);
    			char_literal37=(IToken)Match(input,32,Follow._32_in_stat163); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal37_tree = (object)adaptor.Create(char_literal37, retval);
    			adaptor.AddChild(root_0, char_literal37_tree);
    			}
    			DebugLocation(33, 25);
    			PushFollow(Follow._exp_in_stat165);
    			exp38=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp38.Tree, exp38, retval);
    			DebugLocation(33, 29);
    			// Lua.g:33:29: ( ',' exp )?
    			int alt7=2;
    			try { DebugEnterSubRule(7);
    			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
    			int LA7_0 = input.LA(1);

    			if ((LA7_0==32))
    			{
    				alt7=1;
    			}
    			} finally { DebugExitDecision(7); }
    			switch (alt7)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:33:30: ',' exp
    				{
    				DebugLocation(33, 30);
    				char_literal39=(IToken)Match(input,32,Follow._32_in_stat168); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal39_tree = (object)adaptor.Create(char_literal39, retval);
    				adaptor.AddChild(root_0, char_literal39_tree);
    				}
    				DebugLocation(33, 34);
    				PushFollow(Follow._exp_in_stat170);
    				exp40=exp();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp40.Tree, exp40, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(7); }

    			DebugLocation(33, 40);
    			string_literal41=(IToken)Match(input,22,Follow._22_in_stat174); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal41_tree = (object)adaptor.Create(string_literal41, retval);
    			adaptor.AddChild(root_0, string_literal41_tree);
    			}
    			DebugLocation(33, 45);
    			PushFollow(Follow._block_in_stat176);
    			block42=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block42.Tree, block42, retval);
    			DebugLocation(33, 51);
    			string_literal43=(IToken)Match(input,23,Follow._23_in_stat178); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal43_tree = (object)adaptor.Create(string_literal43, retval);
    			adaptor.AddChild(root_0, string_literal43_tree);
    			}

    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// Lua.g:34:2: 'for' namelist 'in' explist1 'do' block 'end'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(34, 2);
    			string_literal44=(IToken)Match(input,31,Follow._31_in_stat184); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal44_tree = (object)adaptor.Create(string_literal44, retval);
    			adaptor.AddChild(root_0, string_literal44_tree);
    			}
    			DebugLocation(34, 8);
    			PushFollow(Follow._namelist_in_stat186);
    			namelist45=namelist();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, namelist45.Tree, namelist45, retval);
    			DebugLocation(34, 17);
    			string_literal46=(IToken)Match(input,33,Follow._33_in_stat188); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal46_tree = (object)adaptor.Create(string_literal46, retval);
    			adaptor.AddChild(root_0, string_literal46_tree);
    			}
    			DebugLocation(34, 22);
    			PushFollow(Follow._explist1_in_stat190);
    			explist147=explist1();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, explist147.Tree, explist147, retval);
    			DebugLocation(34, 31);
    			string_literal48=(IToken)Match(input,22,Follow._22_in_stat192); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal48_tree = (object)adaptor.Create(string_literal48, retval);
    			adaptor.AddChild(root_0, string_literal48_tree);
    			}
    			DebugLocation(34, 36);
    			PushFollow(Follow._block_in_stat194);
    			block49=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block49.Tree, block49, retval);
    			DebugLocation(34, 42);
    			string_literal50=(IToken)Match(input,23,Follow._23_in_stat196); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal50_tree = (object)adaptor.Create(string_literal50, retval);
    			adaptor.AddChild(root_0, string_literal50_tree);
    			}

    			}
    			break;
    		case 9:
    			DebugEnterAlt(9);
    			// Lua.g:35:2: 'function' funcname funcbody
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(35, 2);
    			string_literal51=(IToken)Match(input,34,Follow._34_in_stat202); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal51_tree = (object)adaptor.Create(string_literal51, retval);
    			adaptor.AddChild(root_0, string_literal51_tree);
    			}
    			DebugLocation(35, 13);
    			PushFollow(Follow._funcname_in_stat204);
    			funcname52=funcname();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, funcname52.Tree, funcname52, retval);
    			DebugLocation(35, 22);
    			PushFollow(Follow._funcbody_in_stat206);
    			funcbody53=funcbody();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, funcbody53.Tree, funcbody53, retval);

    			}
    			break;
    		case 10:
    			DebugEnterAlt(10);
    			// Lua.g:36:2: 'local' 'function' NAME funcbody
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(36, 2);
    			string_literal54=(IToken)Match(input,35,Follow._35_in_stat212); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal54_tree = (object)adaptor.Create(string_literal54, retval);
    			adaptor.AddChild(root_0, string_literal54_tree);
    			}
    			DebugLocation(36, 10);
    			string_literal55=(IToken)Match(input,34,Follow._34_in_stat214); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal55_tree = (object)adaptor.Create(string_literal55, retval);
    			adaptor.AddChild(root_0, string_literal55_tree);
    			}
    			DebugLocation(36, 21);
    			NAME56=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_stat216), "NAME"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			NAME56_tree = (object)adaptor.Create(NAME56, retval);
    			adaptor.AddChild(root_0, NAME56_tree);
    			}
    			DebugLocation(36, 26);
    			PushFollow(Follow._funcbody_in_stat218);
    			funcbody57=funcbody();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, funcbody57.Tree, funcbody57, retval);

    			}
    			break;
    		case 11:
    			DebugEnterAlt(11);
    			// Lua.g:37:2: 'local' namelist ( '=' explist1 )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(37, 2);
    			string_literal58=(IToken)Match(input,35,Follow._35_in_stat224); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal58_tree = (object)adaptor.Create(string_literal58, retval);
    			adaptor.AddChild(root_0, string_literal58_tree);
    			}
    			DebugLocation(37, 10);
    			PushFollow(Follow._namelist_in_stat226);
    			namelist59=namelist();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, namelist59.Tree, namelist59, retval);
    			DebugLocation(37, 19);
    			// Lua.g:37:19: ( '=' explist1 )?
    			int alt8=2;
    			try { DebugEnterSubRule(8);
    			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
    			int LA8_0 = input.LA(1);

    			if ((LA8_0==21))
    			{
    				alt8=1;
    			}
    			} finally { DebugExitDecision(8); }
    			switch (alt8)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:37:20: '=' explist1
    				{
    				DebugLocation(37, 20);
    				char_literal60=(IToken)Match(input,21,Follow._21_in_stat229); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal60_tree = (object)adaptor.Create(char_literal60, retval);
    				adaptor.AddChild(root_0, char_literal60_tree);
    				}
    				DebugLocation(37, 24);
    				PushFollow(Follow._explist1_in_stat231);
    				explist161=explist1();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, explist161.Tree, explist161, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(8); }


    			}
    			break;

    		}
    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(37, 34);
    	} finally { DebugExitRule(GrammarFileName, "stat"); }
    	return retval;

    }
    // $ANTLR end "stat"

    public class laststat_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_laststat() {}
    protected virtual void Leave_laststat() {}

    // $ANTLR start "laststat"
    // Lua.g:39:1: laststat : ( 'return' ( explist1 )? | 'break' );
    [GrammarRule("laststat")]
    public LuaParser.laststat_return laststat()
    {

        LuaParser.laststat_return retval = new LuaParser.laststat_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken string_literal62=null;
        IToken string_literal64=null;
        LuaParser.explist1_return explist163 = default(LuaParser.explist1_return);

        object string_literal62_tree=null;
        object string_literal64_tree=null;

    	try { DebugEnterRule(GrammarFileName, "laststat");
    	DebugLocation(39, 41);
    	try
    	{
    		// Lua.g:39:10: ( 'return' ( explist1 )? | 'break' )
    		int alt11=2;
    		try { DebugEnterDecision(11, decisionCanBacktrack[11]);
    		int LA11_0 = input.LA(1);

    		if ((LA11_0==36))
    		{
    			alt11=1;
    		}
    		else if ((LA11_0==37))
    		{
    			alt11=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 11, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(11); }
    		switch (alt11)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:39:12: 'return' ( explist1 )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(39, 12);
    			string_literal62=(IToken)Match(input,36,Follow._36_in_laststat242); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal62_tree = (object)adaptor.Create(string_literal62, retval);
    			adaptor.AddChild(root_0, string_literal62_tree);
    			}
    			DebugLocation(39, 21);
    			// Lua.g:39:21: ( explist1 )?
    			int alt10=2;
    			try { DebugEnterSubRule(10);
    			try { DebugEnterDecision(10, decisionCanBacktrack[10]);
    			int LA10_0 = input.LA(1);

    			if (((LA10_0>=NAME && LA10_0<=LONGSTRING)||LA10_0==34||(LA10_0>=40 && LA10_0<=44)||LA10_0==48||LA10_0==51||(LA10_0>=65 && LA10_0<=66)))
    			{
    				alt10=1;
    			}
    			} finally { DebugExitDecision(10); }
    			switch (alt10)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:39:22: explist1
    				{
    				DebugLocation(39, 22);
    				PushFollow(Follow._explist1_in_laststat245);
    				explist163=explist1();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, explist163.Tree, explist163, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(10); }


    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:39:35: 'break'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(39, 35);
    			string_literal64=(IToken)Match(input,37,Follow._37_in_laststat251); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal64_tree = (object)adaptor.Create(string_literal64, retval);
    			adaptor.AddChild(root_0, string_literal64_tree);
    			}

    			}
    			break;

    		}
    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(39, 41);
    	} finally { DebugExitRule(GrammarFileName, "laststat"); }
    	return retval;

    }
    // $ANTLR end "laststat"

    public class funcname_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_funcname() {}
    protected virtual void Leave_funcname() {}

    // $ANTLR start "funcname"
    // Lua.g:41:1: funcname : NAME ( '.' NAME )* ( ':' NAME )? ;
    [GrammarRule("funcname")]
    public LuaParser.funcname_return funcname()
    {

        LuaParser.funcname_return retval = new LuaParser.funcname_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken NAME65=null;
        IToken char_literal66=null;
        IToken NAME67=null;
        IToken char_literal68=null;
        IToken NAME69=null;

        object NAME65_tree=null;
        object char_literal66_tree=null;
        object NAME67_tree=null;
        object char_literal68_tree=null;
        object NAME69_tree=null;

    	try { DebugEnterRule(GrammarFileName, "funcname");
    	DebugLocation(41, 40);
    	try
    	{
    		// Lua.g:41:10: ( NAME ( '.' NAME )* ( ':' NAME )? )
    		DebugEnterAlt(1);
    		// Lua.g:41:12: NAME ( '.' NAME )* ( ':' NAME )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(41, 12);
    		NAME65=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_funcname259), "NAME"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		NAME65_tree = (object)adaptor.Create(NAME65, retval);
    		adaptor.AddChild(root_0, NAME65_tree);
    		}
    		DebugLocation(41, 17);
    		// Lua.g:41:17: ( '.' NAME )*
    		try { DebugEnterSubRule(12);
    		while (true)
    		{
    			int alt12=2;
    			try { DebugEnterDecision(12, decisionCanBacktrack[12]);
    			int LA12_0 = input.LA(1);

    			if ((LA12_0==38))
    			{
    				alt12=1;
    			}


    			} finally { DebugExitDecision(12); }
    			switch ( alt12 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:41:18: '.' NAME
    				{
    				DebugLocation(41, 18);
    				char_literal66=(IToken)Match(input,38,Follow._38_in_funcname262); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal66_tree = (object)adaptor.Create(char_literal66, retval);
    				adaptor.AddChild(root_0, char_literal66_tree);
    				}
    				DebugLocation(41, 22);
    				NAME67=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_funcname264), "NAME"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				NAME67_tree = (object)adaptor.Create(NAME67, retval);
    				adaptor.AddChild(root_0, NAME67_tree);
    				}

    				}
    				break;

    			default:
    				goto loop12;
    			}
    		}

    		loop12:
    			;

    		} finally { DebugExitSubRule(12); }

    		DebugLocation(41, 29);
    		// Lua.g:41:29: ( ':' NAME )?
    		int alt13=2;
    		try { DebugEnterSubRule(13);
    		try { DebugEnterDecision(13, decisionCanBacktrack[13]);
    		int LA13_0 = input.LA(1);

    		if ((LA13_0==39))
    		{
    			alt13=1;
    		}
    		} finally { DebugExitDecision(13); }
    		switch (alt13)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:41:30: ':' NAME
    			{
    			DebugLocation(41, 30);
    			char_literal68=(IToken)Match(input,39,Follow._39_in_funcname269); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal68_tree = (object)adaptor.Create(char_literal68, retval);
    			adaptor.AddChild(root_0, char_literal68_tree);
    			}
    			DebugLocation(41, 34);
    			NAME69=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_funcname271), "NAME"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			NAME69_tree = (object)adaptor.Create(NAME69, retval);
    			adaptor.AddChild(root_0, NAME69_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(13); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(41, 40);
    	} finally { DebugExitRule(GrammarFileName, "funcname"); }
    	return retval;

    }
    // $ANTLR end "funcname"

    public class varlist1_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_varlist1() {}
    protected virtual void Leave_varlist1() {}

    // $ANTLR start "varlist1"
    // Lua.g:43:1: varlist1 : var ( ',' var )* ;
    [GrammarRule("varlist1")]
    public LuaParser.varlist1_return varlist1()
    {

        LuaParser.varlist1_return retval = new LuaParser.varlist1_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal71=null;
        LuaParser.var_return var70 = default(LuaParser.var_return);
        LuaParser.var_return var72 = default(LuaParser.var_return);

        object char_literal71_tree=null;

    	try { DebugEnterRule(GrammarFileName, "varlist1");
    	DebugLocation(43, 25);
    	try
    	{
    		// Lua.g:43:10: ( var ( ',' var )* )
    		DebugEnterAlt(1);
    		// Lua.g:43:12: var ( ',' var )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(43, 12);
    		PushFollow(Follow._var_in_varlist1282);
    		var70=var();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, var70.Tree, var70, retval);
    		DebugLocation(43, 16);
    		// Lua.g:43:16: ( ',' var )*
    		try { DebugEnterSubRule(14);
    		while (true)
    		{
    			int alt14=2;
    			try { DebugEnterDecision(14, decisionCanBacktrack[14]);
    			int LA14_0 = input.LA(1);

    			if ((LA14_0==32))
    			{
    				alt14=1;
    			}


    			} finally { DebugExitDecision(14); }
    			switch ( alt14 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:43:17: ',' var
    				{
    				DebugLocation(43, 17);
    				char_literal71=(IToken)Match(input,32,Follow._32_in_varlist1285); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal71_tree = (object)adaptor.Create(char_literal71, retval);
    				adaptor.AddChild(root_0, char_literal71_tree);
    				}
    				DebugLocation(43, 21);
    				PushFollow(Follow._var_in_varlist1287);
    				var72=var();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, var72.Tree, var72, retval);

    				}
    				break;

    			default:
    				goto loop14;
    			}
    		}

    		loop14:
    			;

    		} finally { DebugExitSubRule(14); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(43, 25);
    	} finally { DebugExitRule(GrammarFileName, "varlist1"); }
    	return retval;

    }
    // $ANTLR end "varlist1"

    public class namelist_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_namelist() {}
    protected virtual void Leave_namelist() {}

    // $ANTLR start "namelist"
    // Lua.g:46:1: namelist : NAME ( ',' NAME )* ;
    [GrammarRule("namelist")]
    public LuaParser.namelist_return namelist()
    {

        LuaParser.namelist_return retval = new LuaParser.namelist_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken NAME73=null;
        IToken char_literal74=null;
        IToken NAME75=null;

        object NAME73_tree=null;
        object char_literal74_tree=null;
        object NAME75_tree=null;

    	try { DebugEnterRule(GrammarFileName, "namelist");
    	DebugLocation(46, 27);
    	try
    	{
    		// Lua.g:46:10: ( NAME ( ',' NAME )* )
    		DebugEnterAlt(1);
    		// Lua.g:46:12: NAME ( ',' NAME )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(46, 12);
    		NAME73=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_namelist298), "NAME"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		NAME73_tree = (object)adaptor.Create(NAME73, retval);
    		adaptor.AddChild(root_0, NAME73_tree);
    		}
    		DebugLocation(46, 17);
    		// Lua.g:46:17: ( ',' NAME )*
    		try { DebugEnterSubRule(15);
    		while (true)
    		{
    			int alt15=2;
    			try { DebugEnterDecision(15, decisionCanBacktrack[15]);
    			int LA15_0 = input.LA(1);

    			if ((LA15_0==32))
    			{
    				int LA15_2 = input.LA(2);

    				if ((LA15_2==NAME))
    				{
    					alt15=1;
    				}


    			}


    			} finally { DebugExitDecision(15); }
    			switch ( alt15 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:46:18: ',' NAME
    				{
    				DebugLocation(46, 18);
    				char_literal74=(IToken)Match(input,32,Follow._32_in_namelist301); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal74_tree = (object)adaptor.Create(char_literal74, retval);
    				adaptor.AddChild(root_0, char_literal74_tree);
    				}
    				DebugLocation(46, 22);
    				NAME75=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_namelist303), "NAME"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				NAME75_tree = (object)adaptor.Create(NAME75, retval);
    				adaptor.AddChild(root_0, NAME75_tree);
    				}

    				}
    				break;

    			default:
    				goto loop15;
    			}
    		}

    		loop15:
    			;

    		} finally { DebugExitSubRule(15); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(46, 27);
    	} finally { DebugExitRule(GrammarFileName, "namelist"); }
    	return retval;

    }
    // $ANTLR end "namelist"

    public class explist1_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_explist1() {}
    protected virtual void Leave_explist1() {}

    // $ANTLR start "explist1"
    // Lua.g:48:1: explist1 : ( exp ',' )* exp ;
    [GrammarRule("explist1")]
    public LuaParser.explist1_return explist1()
    {

        LuaParser.explist1_return retval = new LuaParser.explist1_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal77=null;
        LuaParser.exp_return exp76 = default(LuaParser.exp_return);
        LuaParser.exp_return exp78 = default(LuaParser.exp_return);

        object char_literal77_tree=null;

    	try { DebugEnterRule(GrammarFileName, "explist1");
    	DebugLocation(48, 25);
    	try
    	{
    		// Lua.g:48:10: ( ( exp ',' )* exp )
    		DebugEnterAlt(1);
    		// Lua.g:48:12: ( exp ',' )* exp
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(48, 12);
    		// Lua.g:48:12: ( exp ',' )*
    		try { DebugEnterSubRule(16);
    		while (true)
    		{
    			int alt16=2;
    			try { DebugEnterDecision(16, decisionCanBacktrack[16]);
    			try
    			{
    				alt16 = dfa16.Predict(input);
    			}
    			catch (NoViableAltException nvae)
    			{
    				DebugRecognitionException(nvae);
    				throw;
    			}
    			} finally { DebugExitDecision(16); }
    			switch ( alt16 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:48:13: exp ','
    				{
    				DebugLocation(48, 13);
    				PushFollow(Follow._exp_in_explist1314);
    				exp76=exp();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp76.Tree, exp76, retval);
    				DebugLocation(48, 17);
    				char_literal77=(IToken)Match(input,32,Follow._32_in_explist1316); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal77_tree = (object)adaptor.Create(char_literal77, retval);
    				adaptor.AddChild(root_0, char_literal77_tree);
    				}

    				}
    				break;

    			default:
    				goto loop16;
    			}
    		}

    		loop16:
    			;

    		} finally { DebugExitSubRule(16); }

    		DebugLocation(48, 23);
    		PushFollow(Follow._exp_in_explist1320);
    		exp78=exp();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp78.Tree, exp78, retval);

    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(48, 25);
    	} finally { DebugExitRule(GrammarFileName, "explist1"); }
    	return retval;

    }
    // $ANTLR end "explist1"

    public class exp_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_exp() {}
    protected virtual void Leave_exp() {}

    // $ANTLR start "exp"
    // Lua.g:50:1: exp : ( 'nil' | 'false' | 'true' | lua_number | lua_string | '...' | function | prefixexp | tableconstructor | unop exp ) ( binop exp )* ;
    [GrammarRule("exp")]
    public LuaParser.exp_return exp()
    {

        LuaParser.exp_return retval = new LuaParser.exp_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken string_literal79=null;
        IToken string_literal80=null;
        IToken string_literal81=null;
        IToken string_literal84=null;
        LuaParser.lua_number_return lua_number82 = default(LuaParser.lua_number_return);
        LuaParser.lua_string_return lua_string83 = default(LuaParser.lua_string_return);
        LuaParser.function_return function85 = default(LuaParser.function_return);
        LuaParser.prefixexp_return prefixexp86 = default(LuaParser.prefixexp_return);
        LuaParser.tableconstructor_return tableconstructor87 = default(LuaParser.tableconstructor_return);
        LuaParser.unop_return unop88 = default(LuaParser.unop_return);
        LuaParser.exp_return exp89 = default(LuaParser.exp_return);
        LuaParser.binop_return binop90 = default(LuaParser.binop_return);
        LuaParser.exp_return exp91 = default(LuaParser.exp_return);

        object string_literal79_tree=null;
        object string_literal80_tree=null;
        object string_literal81_tree=null;
        object string_literal84_tree=null;

    	try { DebugEnterRule(GrammarFileName, "exp");
    	DebugLocation(50, 134);
    	try
    	{
    		// Lua.g:50:5: ( ( 'nil' | 'false' | 'true' | lua_number | lua_string | '...' | function | prefixexp | tableconstructor | unop exp ) ( binop exp )* )
    		DebugEnterAlt(1);
    		// Lua.g:50:8: ( 'nil' | 'false' | 'true' | lua_number | lua_string | '...' | function | prefixexp | tableconstructor | unop exp ) ( binop exp )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(50, 8);
    		// Lua.g:50:8: ( 'nil' | 'false' | 'true' | lua_number | lua_string | '...' | function | prefixexp | tableconstructor | unop exp )
    		int alt17=10;
    		try { DebugEnterSubRule(17);
    		try { DebugEnterDecision(17, decisionCanBacktrack[17]);
    		switch (input.LA(1))
    		{
    		case 40:
    			{
    			alt17=1;
    			}
    			break;
    		case 41:
    			{
    			alt17=2;
    			}
    			break;
    		case 42:
    			{
    			alt17=3;
    			}
    			break;
    		case INT:
    		case FLOAT:
    		case EXP:
    		case HEX:
    			{
    			alt17=4;
    			}
    			break;
    		case NORMALSTRING:
    		case CHARSTRING:
    		case LONGSTRING:
    			{
    			alt17=5;
    			}
    			break;
    		case 43:
    			{
    			alt17=6;
    			}
    			break;
    		case 34:
    			{
    			alt17=7;
    			}
    			break;
    		case NAME:
    		case 44:
    			{
    			alt17=8;
    			}
    			break;
    		case 48:
    			{
    			alt17=9;
    			}
    			break;
    		case 51:
    		case 65:
    		case 66:
    			{
    			alt17=10;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 17, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(17); }
    		switch (alt17)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:50:9: 'nil'
    			{
    			DebugLocation(50, 9);
    			string_literal79=(IToken)Match(input,40,Follow._40_in_exp330); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal79_tree = (object)adaptor.Create(string_literal79, retval);
    			adaptor.AddChild(root_0, string_literal79_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:50:17: 'false'
    			{
    			DebugLocation(50, 17);
    			string_literal80=(IToken)Match(input,41,Follow._41_in_exp334); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal80_tree = (object)adaptor.Create(string_literal80, retval);
    			adaptor.AddChild(root_0, string_literal80_tree);
    			}

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Lua.g:50:27: 'true'
    			{
    			DebugLocation(50, 27);
    			string_literal81=(IToken)Match(input,42,Follow._42_in_exp338); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal81_tree = (object)adaptor.Create(string_literal81, retval);
    			adaptor.AddChild(root_0, string_literal81_tree);
    			}

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Lua.g:50:36: lua_number
    			{
    			DebugLocation(50, 36);
    			PushFollow(Follow._lua_number_in_exp342);
    			lua_number82=lua_number();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, lua_number82.Tree, lua_number82, retval);

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Lua.g:50:49: lua_string
    			{
    			DebugLocation(50, 49);
    			PushFollow(Follow._lua_string_in_exp346);
    			lua_string83=lua_string();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, lua_string83.Tree, lua_string83, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Lua.g:50:62: '...'
    			{
    			DebugLocation(50, 62);
    			string_literal84=(IToken)Match(input,43,Follow._43_in_exp350); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal84_tree = (object)adaptor.Create(string_literal84, retval);
    			adaptor.AddChild(root_0, string_literal84_tree);
    			}

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Lua.g:50:70: function
    			{
    			DebugLocation(50, 70);
    			PushFollow(Follow._function_in_exp354);
    			function85=function();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, function85.Tree, function85, retval);

    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// Lua.g:50:81: prefixexp
    			{
    			DebugLocation(50, 81);
    			PushFollow(Follow._prefixexp_in_exp358);
    			prefixexp86=prefixexp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, prefixexp86.Tree, prefixexp86, retval);

    			}
    			break;
    		case 9:
    			DebugEnterAlt(9);
    			// Lua.g:50:93: tableconstructor
    			{
    			DebugLocation(50, 93);
    			PushFollow(Follow._tableconstructor_in_exp362);
    			tableconstructor87=tableconstructor();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, tableconstructor87.Tree, tableconstructor87, retval);

    			}
    			break;
    		case 10:
    			DebugEnterAlt(10);
    			// Lua.g:50:112: unop exp
    			{
    			DebugLocation(50, 112);
    			PushFollow(Follow._unop_in_exp366);
    			unop88=unop();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unop88.Tree, unop88, retval);
    			DebugLocation(50, 117);
    			PushFollow(Follow._exp_in_exp368);
    			exp89=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp89.Tree, exp89, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(17); }

    		DebugLocation(50, 122);
    		// Lua.g:50:122: ( binop exp )*
    		try { DebugEnterSubRule(18);
    		while (true)
    		{
    			int alt18=2;
    			try { DebugEnterDecision(18, decisionCanBacktrack[18]);
    			int LA18_0 = input.LA(1);

    			if (((LA18_0>=50 && LA18_0<=64)))
    			{
    				int LA18_2 = input.LA(2);

    				if ((EvaluatePredicate(synpred35_Lua_fragment)))
    				{
    					alt18=1;
    				}


    			}


    			} finally { DebugExitDecision(18); }
    			switch ( alt18 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:50:123: binop exp
    				{
    				DebugLocation(50, 123);
    				PushFollow(Follow._binop_in_exp372);
    				binop90=binop();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, binop90.Tree, binop90, retval);
    				DebugLocation(50, 129);
    				PushFollow(Follow._exp_in_exp374);
    				exp91=exp();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp91.Tree, exp91, retval);

    				}
    				break;

    			default:
    				goto loop18;
    			}
    		}

    		loop18:
    			;

    		} finally { DebugExitSubRule(18); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(50, 134);
    	} finally { DebugExitRule(GrammarFileName, "exp"); }
    	return retval;

    }
    // $ANTLR end "exp"

    public class var_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_var() {}
    protected virtual void Leave_var() {}

    // $ANTLR start "var"
    // Lua.g:52:1: var : ( NAME | '(' exp ')' varSuffix ) ( varSuffix )* ;
    [GrammarRule("var")]
    public LuaParser.var_return var()
    {

        LuaParser.var_return retval = new LuaParser.var_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken NAME92=null;
        IToken char_literal93=null;
        IToken char_literal95=null;
        LuaParser.exp_return exp94 = default(LuaParser.exp_return);
        LuaParser.varSuffix_return varSuffix96 = default(LuaParser.varSuffix_return);
        LuaParser.varSuffix_return varSuffix97 = default(LuaParser.varSuffix_return);

        object NAME92_tree=null;
        object char_literal93_tree=null;
        object char_literal95_tree=null;

    	try { DebugEnterRule(GrammarFileName, "var");
    	DebugLocation(52, 46);
    	try
    	{
    		// Lua.g:52:4: ( ( NAME | '(' exp ')' varSuffix ) ( varSuffix )* )
    		DebugEnterAlt(1);
    		// Lua.g:52:6: ( NAME | '(' exp ')' varSuffix ) ( varSuffix )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(52, 6);
    		// Lua.g:52:6: ( NAME | '(' exp ')' varSuffix )
    		int alt19=2;
    		try { DebugEnterSubRule(19);
    		try { DebugEnterDecision(19, decisionCanBacktrack[19]);
    		int LA19_0 = input.LA(1);

    		if ((LA19_0==NAME))
    		{
    			alt19=1;
    		}
    		else if ((LA19_0==44))
    		{
    			alt19=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 19, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(19); }
    		switch (alt19)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:52:7: NAME
    			{
    			DebugLocation(52, 7);
    			NAME92=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_var385), "NAME"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			NAME92_tree = (object)adaptor.Create(NAME92, retval);
    			adaptor.AddChild(root_0, NAME92_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:52:14: '(' exp ')' varSuffix
    			{
    			DebugLocation(52, 14);
    			char_literal93=(IToken)Match(input,44,Follow._44_in_var389); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal93_tree = (object)adaptor.Create(char_literal93, retval);
    			adaptor.AddChild(root_0, char_literal93_tree);
    			}
    			DebugLocation(52, 18);
    			PushFollow(Follow._exp_in_var391);
    			exp94=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp94.Tree, exp94, retval);
    			DebugLocation(52, 22);
    			char_literal95=(IToken)Match(input,45,Follow._45_in_var393); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal95_tree = (object)adaptor.Create(char_literal95, retval);
    			adaptor.AddChild(root_0, char_literal95_tree);
    			}
    			DebugLocation(52, 26);
    			PushFollow(Follow._varSuffix_in_var395);
    			varSuffix96=varSuffix();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, varSuffix96.Tree, varSuffix96, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(19); }

    		DebugLocation(52, 37);
    		// Lua.g:52:37: ( varSuffix )*
    		try { DebugEnterSubRule(20);
    		while (true)
    		{
    			int alt20=2;
    			try { DebugEnterDecision(20, decisionCanBacktrack[20]);
    			try
    			{
    				alt20 = dfa20.Predict(input);
    			}
    			catch (NoViableAltException nvae)
    			{
    				DebugRecognitionException(nvae);
    				throw;
    			}
    			} finally { DebugExitDecision(20); }
    			switch ( alt20 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:0:0: varSuffix
    				{
    				DebugLocation(52, 37);
    				PushFollow(Follow._varSuffix_in_var398);
    				varSuffix97=varSuffix();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, varSuffix97.Tree, varSuffix97, retval);

    				}
    				break;

    			default:
    				goto loop20;
    			}
    		}

    		loop20:
    			;

    		} finally { DebugExitSubRule(20); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(52, 46);
    	} finally { DebugExitRule(GrammarFileName, "var"); }
    	return retval;

    }
    // $ANTLR end "var"

    public class prefixexp_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_prefixexp() {}
    protected virtual void Leave_prefixexp() {}

    // $ANTLR start "prefixexp"
    // Lua.g:54:1: prefixexp : varOrExp ( nameAndArgs )* ;
    [GrammarRule("prefixexp")]
    public LuaParser.prefixexp_return prefixexp()
    {

        LuaParser.prefixexp_return retval = new LuaParser.prefixexp_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        LuaParser.varOrExp_return varOrExp98 = default(LuaParser.varOrExp_return);
        LuaParser.nameAndArgs_return nameAndArgs99 = default(LuaParser.nameAndArgs_return);


    	try { DebugEnterRule(GrammarFileName, "prefixexp");
    	DebugLocation(54, 32);
    	try
    	{
    		// Lua.g:54:10: ( varOrExp ( nameAndArgs )* )
    		DebugEnterAlt(1);
    		// Lua.g:54:12: varOrExp ( nameAndArgs )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(54, 12);
    		PushFollow(Follow._varOrExp_in_prefixexp406);
    		varOrExp98=varOrExp();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, varOrExp98.Tree, varOrExp98, retval);
    		DebugLocation(54, 21);
    		// Lua.g:54:21: ( nameAndArgs )*
    		try { DebugEnterSubRule(21);
    		while (true)
    		{
    			int alt21=2;
    			try { DebugEnterDecision(21, decisionCanBacktrack[21]);
    			try
    			{
    				alt21 = dfa21.Predict(input);
    			}
    			catch (NoViableAltException nvae)
    			{
    				DebugRecognitionException(nvae);
    				throw;
    			}
    			} finally { DebugExitDecision(21); }
    			switch ( alt21 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:0:0: nameAndArgs
    				{
    				DebugLocation(54, 21);
    				PushFollow(Follow._nameAndArgs_in_prefixexp408);
    				nameAndArgs99=nameAndArgs();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nameAndArgs99.Tree, nameAndArgs99, retval);

    				}
    				break;

    			default:
    				goto loop21;
    			}
    		}

    		loop21:
    			;

    		} finally { DebugExitSubRule(21); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(54, 32);
    	} finally { DebugExitRule(GrammarFileName, "prefixexp"); }
    	return retval;

    }
    // $ANTLR end "prefixexp"

    public class functioncall_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_functioncall() {}
    protected virtual void Leave_functioncall() {}

    // $ANTLR start "functioncall"
    // Lua.g:56:1: functioncall : varOrExp ( nameAndArgs )+ ;
    [GrammarRule("functioncall")]
    public LuaParser.functioncall_return functioncall()
    {

        LuaParser.functioncall_return retval = new LuaParser.functioncall_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        LuaParser.varOrExp_return varOrExp100 = default(LuaParser.varOrExp_return);
        LuaParser.nameAndArgs_return nameAndArgs101 = default(LuaParser.nameAndArgs_return);


    	try { DebugEnterRule(GrammarFileName, "functioncall");
    	DebugLocation(56, 35);
    	try
    	{
    		// Lua.g:56:13: ( varOrExp ( nameAndArgs )+ )
    		DebugEnterAlt(1);
    		// Lua.g:56:15: varOrExp ( nameAndArgs )+
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(56, 15);
    		PushFollow(Follow._varOrExp_in_functioncall416);
    		varOrExp100=varOrExp();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, varOrExp100.Tree, varOrExp100, retval);
    		DebugLocation(56, 24);
    		// Lua.g:56:24: ( nameAndArgs )+
    		int cnt22=0;
    		try { DebugEnterSubRule(22);
    		while (true)
    		{
    			int alt22=2;
    			try { DebugEnterDecision(22, decisionCanBacktrack[22]);
    			try
    			{
    				alt22 = dfa22.Predict(input);
    			}
    			catch (NoViableAltException nvae)
    			{
    				DebugRecognitionException(nvae);
    				throw;
    			}
    			} finally { DebugExitDecision(22); }
    			switch (alt22)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:0:0: nameAndArgs
    				{
    				DebugLocation(56, 24);
    				PushFollow(Follow._nameAndArgs_in_functioncall418);
    				nameAndArgs101=nameAndArgs();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nameAndArgs101.Tree, nameAndArgs101, retval);

    				}
    				break;

    			default:
    				if (cnt22 >= 1)
    					goto loop22;

    				if (state.backtracking>0) {state.failed=true; return retval;}
    				EarlyExitException eee22 = new EarlyExitException( 22, input );
    				DebugRecognitionException(eee22);
    				throw eee22;
    			}
    			cnt22++;
    		}
    		loop22:
    			;

    		} finally { DebugExitSubRule(22); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(56, 35);
    	} finally { DebugExitRule(GrammarFileName, "functioncall"); }
    	return retval;

    }
    // $ANTLR end "functioncall"

    public class varOrExp_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_varOrExp() {}
    protected virtual void Leave_varOrExp() {}

    // $ANTLR start "varOrExp"
    // Lua.g:66:1: varOrExp : ( var | '(' exp ')' );
    [GrammarRule("varOrExp")]
    public LuaParser.varOrExp_return varOrExp()
    {

        LuaParser.varOrExp_return retval = new LuaParser.varOrExp_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal103=null;
        IToken char_literal105=null;
        LuaParser.var_return var102 = default(LuaParser.var_return);
        LuaParser.exp_return exp104 = default(LuaParser.exp_return);

        object char_literal103_tree=null;
        object char_literal105_tree=null;

    	try { DebugEnterRule(GrammarFileName, "varOrExp");
    	DebugLocation(66, 27);
    	try
    	{
    		// Lua.g:66:9: ( var | '(' exp ')' )
    		int alt23=2;
    		try { DebugEnterDecision(23, decisionCanBacktrack[23]);
    		int LA23_0 = input.LA(1);

    		if ((LA23_0==NAME))
    		{
    			alt23=1;
    		}
    		else if ((LA23_0==44))
    		{
    			int LA23_2 = input.LA(2);

    			if ((EvaluatePredicate(synpred40_Lua_fragment)))
    			{
    				alt23=1;
    			}
    			else if ((true))
    			{
    				alt23=2;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 23, 2, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 23, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(23); }
    		switch (alt23)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:66:11: var
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(66, 11);
    			PushFollow(Follow._var_in_varOrExp429);
    			var102=var();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, var102.Tree, var102, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:66:17: '(' exp ')'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(66, 17);
    			char_literal103=(IToken)Match(input,44,Follow._44_in_varOrExp433); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal103_tree = (object)adaptor.Create(char_literal103, retval);
    			adaptor.AddChild(root_0, char_literal103_tree);
    			}
    			DebugLocation(66, 21);
    			PushFollow(Follow._exp_in_varOrExp435);
    			exp104=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp104.Tree, exp104, retval);
    			DebugLocation(66, 25);
    			char_literal105=(IToken)Match(input,45,Follow._45_in_varOrExp437); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal105_tree = (object)adaptor.Create(char_literal105, retval);
    			adaptor.AddChild(root_0, char_literal105_tree);
    			}

    			}
    			break;

    		}
    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(66, 27);
    	} finally { DebugExitRule(GrammarFileName, "varOrExp"); }
    	return retval;

    }
    // $ANTLR end "varOrExp"

    public class nameAndArgs_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_nameAndArgs() {}
    protected virtual void Leave_nameAndArgs() {}

    // $ANTLR start "nameAndArgs"
    // Lua.g:68:1: nameAndArgs : ( ':' NAME )? args ;
    [GrammarRule("nameAndArgs")]
    public LuaParser.nameAndArgs_return nameAndArgs()
    {

        LuaParser.nameAndArgs_return retval = new LuaParser.nameAndArgs_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal106=null;
        IToken NAME107=null;
        LuaParser.args_return args108 = default(LuaParser.args_return);

        object char_literal106_tree=null;
        object NAME107_tree=null;

    	try { DebugEnterRule(GrammarFileName, "nameAndArgs");
    	DebugLocation(68, 29);
    	try
    	{
    		// Lua.g:68:12: ( ( ':' NAME )? args )
    		DebugEnterAlt(1);
    		// Lua.g:68:14: ( ':' NAME )? args
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(68, 14);
    		// Lua.g:68:14: ( ':' NAME )?
    		int alt24=2;
    		try { DebugEnterSubRule(24);
    		try { DebugEnterDecision(24, decisionCanBacktrack[24]);
    		int LA24_0 = input.LA(1);

    		if ((LA24_0==39))
    		{
    			alt24=1;
    		}
    		} finally { DebugExitDecision(24); }
    		switch (alt24)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:68:15: ':' NAME
    			{
    			DebugLocation(68, 15);
    			char_literal106=(IToken)Match(input,39,Follow._39_in_nameAndArgs445); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal106_tree = (object)adaptor.Create(char_literal106, retval);
    			adaptor.AddChild(root_0, char_literal106_tree);
    			}
    			DebugLocation(68, 19);
    			NAME107=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_nameAndArgs447), "NAME"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			NAME107_tree = (object)adaptor.Create(NAME107, retval);
    			adaptor.AddChild(root_0, NAME107_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(24); }

    		DebugLocation(68, 26);
    		PushFollow(Follow._args_in_nameAndArgs451);
    		args108=args();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, args108.Tree, args108, retval);

    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(68, 29);
    	} finally { DebugExitRule(GrammarFileName, "nameAndArgs"); }
    	return retval;

    }
    // $ANTLR end "nameAndArgs"

    public class varSuffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_varSuffix() {}
    protected virtual void Leave_varSuffix() {}

    // $ANTLR start "varSuffix"
    // Lua.g:70:1: varSuffix : ( nameAndArgs )* ( '[' exp ']' | '.' NAME ) ;
    [GrammarRule("varSuffix")]
    public LuaParser.varSuffix_return varSuffix()
    {

        LuaParser.varSuffix_return retval = new LuaParser.varSuffix_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal110=null;
        IToken char_literal112=null;
        IToken char_literal113=null;
        IToken NAME114=null;
        LuaParser.nameAndArgs_return nameAndArgs109 = default(LuaParser.nameAndArgs_return);
        LuaParser.exp_return exp111 = default(LuaParser.exp_return);

        object char_literal110_tree=null;
        object char_literal112_tree=null;
        object char_literal113_tree=null;
        object NAME114_tree=null;

    	try { DebugEnterRule(GrammarFileName, "varSuffix");
    	DebugLocation(70, 48);
    	try
    	{
    		// Lua.g:70:10: ( ( nameAndArgs )* ( '[' exp ']' | '.' NAME ) )
    		DebugEnterAlt(1);
    		// Lua.g:70:12: ( nameAndArgs )* ( '[' exp ']' | '.' NAME )
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(70, 12);
    		// Lua.g:70:12: ( nameAndArgs )*
    		try { DebugEnterSubRule(25);
    		while (true)
    		{
    			int alt25=2;
    			try { DebugEnterDecision(25, decisionCanBacktrack[25]);
    			int LA25_0 = input.LA(1);

    			if (((LA25_0>=NORMALSTRING && LA25_0<=LONGSTRING)||LA25_0==39||LA25_0==44||LA25_0==48))
    			{
    				alt25=1;
    			}


    			} finally { DebugExitDecision(25); }
    			switch ( alt25 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:0:0: nameAndArgs
    				{
    				DebugLocation(70, 12);
    				PushFollow(Follow._nameAndArgs_in_varSuffix458);
    				nameAndArgs109=nameAndArgs();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nameAndArgs109.Tree, nameAndArgs109, retval);

    				}
    				break;

    			default:
    				goto loop25;
    			}
    		}

    		loop25:
    			;

    		} finally { DebugExitSubRule(25); }

    		DebugLocation(70, 25);
    		// Lua.g:70:25: ( '[' exp ']' | '.' NAME )
    		int alt26=2;
    		try { DebugEnterSubRule(26);
    		try { DebugEnterDecision(26, decisionCanBacktrack[26]);
    		int LA26_0 = input.LA(1);

    		if ((LA26_0==46))
    		{
    			alt26=1;
    		}
    		else if ((LA26_0==38))
    		{
    			alt26=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 26, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(26); }
    		switch (alt26)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:70:26: '[' exp ']'
    			{
    			DebugLocation(70, 26);
    			char_literal110=(IToken)Match(input,46,Follow._46_in_varSuffix462); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal110_tree = (object)adaptor.Create(char_literal110, retval);
    			adaptor.AddChild(root_0, char_literal110_tree);
    			}
    			DebugLocation(70, 30);
    			PushFollow(Follow._exp_in_varSuffix464);
    			exp111=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp111.Tree, exp111, retval);
    			DebugLocation(70, 34);
    			char_literal112=(IToken)Match(input,47,Follow._47_in_varSuffix466); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal112_tree = (object)adaptor.Create(char_literal112, retval);
    			adaptor.AddChild(root_0, char_literal112_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:70:40: '.' NAME
    			{
    			DebugLocation(70, 40);
    			char_literal113=(IToken)Match(input,38,Follow._38_in_varSuffix470); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal113_tree = (object)adaptor.Create(char_literal113, retval);
    			adaptor.AddChild(root_0, char_literal113_tree);
    			}
    			DebugLocation(70, 44);
    			NAME114=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_varSuffix472), "NAME"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			NAME114_tree = (object)adaptor.Create(NAME114, retval);
    			adaptor.AddChild(root_0, NAME114_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(26); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(70, 48);
    	} finally { DebugExitRule(GrammarFileName, "varSuffix"); }
    	return retval;

    }
    // $ANTLR end "varSuffix"

    public class args_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_args() {}
    protected virtual void Leave_args() {}

    // $ANTLR start "args"
    // Lua.g:72:1: args : ( '(' ( explist1 )? ')' | tableconstructor | lua_string );
    [GrammarRule("args")]
    public LuaParser.args_return args()
    {

        LuaParser.args_return retval = new LuaParser.args_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal115=null;
        IToken char_literal117=null;
        LuaParser.explist1_return explist1116 = default(LuaParser.explist1_return);
        LuaParser.tableconstructor_return tableconstructor118 = default(LuaParser.tableconstructor_return);
        LuaParser.lua_string_return lua_string119 = default(LuaParser.lua_string_return);

        object char_literal115_tree=null;
        object char_literal117_tree=null;

    	try { DebugEnterRule(GrammarFileName, "args");
    	DebugLocation(72, 60);
    	try
    	{
    		// Lua.g:72:6: ( '(' ( explist1 )? ')' | tableconstructor | lua_string )
    		int alt28=3;
    		try { DebugEnterDecision(28, decisionCanBacktrack[28]);
    		switch (input.LA(1))
    		{
    		case 44:
    			{
    			alt28=1;
    			}
    			break;
    		case 48:
    			{
    			alt28=2;
    			}
    			break;
    		case NORMALSTRING:
    		case CHARSTRING:
    		case LONGSTRING:
    			{
    			alt28=3;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 28, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(28); }
    		switch (alt28)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:72:9: '(' ( explist1 )? ')'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(72, 9);
    			char_literal115=(IToken)Match(input,44,Follow._44_in_args482); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal115_tree = (object)adaptor.Create(char_literal115, retval);
    			adaptor.AddChild(root_0, char_literal115_tree);
    			}
    			DebugLocation(72, 13);
    			// Lua.g:72:13: ( explist1 )?
    			int alt27=2;
    			try { DebugEnterSubRule(27);
    			try { DebugEnterDecision(27, decisionCanBacktrack[27]);
    			int LA27_0 = input.LA(1);

    			if (((LA27_0>=NAME && LA27_0<=LONGSTRING)||LA27_0==34||(LA27_0>=40 && LA27_0<=44)||LA27_0==48||LA27_0==51||(LA27_0>=65 && LA27_0<=66)))
    			{
    				alt27=1;
    			}
    			} finally { DebugExitDecision(27); }
    			switch (alt27)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:72:14: explist1
    				{
    				DebugLocation(72, 14);
    				PushFollow(Follow._explist1_in_args485);
    				explist1116=explist1();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, explist1116.Tree, explist1116, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(27); }

    			DebugLocation(72, 25);
    			char_literal117=(IToken)Match(input,45,Follow._45_in_args489); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal117_tree = (object)adaptor.Create(char_literal117, retval);
    			adaptor.AddChild(root_0, char_literal117_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:72:31: tableconstructor
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(72, 31);
    			PushFollow(Follow._tableconstructor_in_args493);
    			tableconstructor118=tableconstructor();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, tableconstructor118.Tree, tableconstructor118, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Lua.g:72:50: lua_string
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(72, 50);
    			PushFollow(Follow._lua_string_in_args497);
    			lua_string119=lua_string();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, lua_string119.Tree, lua_string119, retval);

    			}
    			break;

    		}
    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(72, 60);
    	} finally { DebugExitRule(GrammarFileName, "args"); }
    	return retval;

    }
    // $ANTLR end "args"

    public class function_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_function() {}
    protected virtual void Leave_function() {}

    // $ANTLR start "function"
    // Lua.g:74:1: function : 'function' funcbody ;
    [GrammarRule("function")]
    public LuaParser.function_return function()
    {

        LuaParser.function_return retval = new LuaParser.function_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken string_literal120=null;
        LuaParser.funcbody_return funcbody121 = default(LuaParser.funcbody_return);

        object string_literal120_tree=null;

    	try { DebugEnterRule(GrammarFileName, "function");
    	DebugLocation(74, 30);
    	try
    	{
    		// Lua.g:74:10: ( 'function' funcbody )
    		DebugEnterAlt(1);
    		// Lua.g:74:12: 'function' funcbody
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(74, 12);
    		string_literal120=(IToken)Match(input,34,Follow._34_in_function506); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal120_tree = (object)adaptor.Create(string_literal120, retval);
    		adaptor.AddChild(root_0, string_literal120_tree);
    		}
    		DebugLocation(74, 23);
    		PushFollow(Follow._funcbody_in_function508);
    		funcbody121=funcbody();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, funcbody121.Tree, funcbody121, retval);

    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(74, 30);
    	} finally { DebugExitRule(GrammarFileName, "function"); }
    	return retval;

    }
    // $ANTLR end "function"

    public class funcbody_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_funcbody() {}
    protected virtual void Leave_funcbody() {}

    // $ANTLR start "funcbody"
    // Lua.g:76:1: funcbody : '(' ( parlist1 )? ')' block 'end' ;
    [GrammarRule("funcbody")]
    public LuaParser.funcbody_return funcbody()
    {

        LuaParser.funcbody_return retval = new LuaParser.funcbody_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal122=null;
        IToken char_literal124=null;
        IToken string_literal126=null;
        LuaParser.parlist1_return parlist1123 = default(LuaParser.parlist1_return);
        LuaParser.block_return block125 = default(LuaParser.block_return);

        object char_literal122_tree=null;
        object char_literal124_tree=null;
        object string_literal126_tree=null;

    	try { DebugEnterRule(GrammarFileName, "funcbody");
    	DebugLocation(76, 42);
    	try
    	{
    		// Lua.g:76:10: ( '(' ( parlist1 )? ')' block 'end' )
    		DebugEnterAlt(1);
    		// Lua.g:76:12: '(' ( parlist1 )? ')' block 'end'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(76, 12);
    		char_literal122=(IToken)Match(input,44,Follow._44_in_funcbody516); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal122_tree = (object)adaptor.Create(char_literal122, retval);
    		adaptor.AddChild(root_0, char_literal122_tree);
    		}
    		DebugLocation(76, 16);
    		// Lua.g:76:16: ( parlist1 )?
    		int alt29=2;
    		try { DebugEnterSubRule(29);
    		try { DebugEnterDecision(29, decisionCanBacktrack[29]);
    		int LA29_0 = input.LA(1);

    		if ((LA29_0==NAME||LA29_0==43))
    		{
    			alt29=1;
    		}
    		} finally { DebugExitDecision(29); }
    		switch (alt29)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:76:17: parlist1
    			{
    			DebugLocation(76, 17);
    			PushFollow(Follow._parlist1_in_funcbody519);
    			parlist1123=parlist1();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, parlist1123.Tree, parlist1123, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(29); }

    		DebugLocation(76, 28);
    		char_literal124=(IToken)Match(input,45,Follow._45_in_funcbody523); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal124_tree = (object)adaptor.Create(char_literal124, retval);
    		adaptor.AddChild(root_0, char_literal124_tree);
    		}
    		DebugLocation(76, 32);
    		PushFollow(Follow._block_in_funcbody525);
    		block125=block();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block125.Tree, block125, retval);
    		DebugLocation(76, 38);
    		string_literal126=(IToken)Match(input,23,Follow._23_in_funcbody527); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal126_tree = (object)adaptor.Create(string_literal126, retval);
    		adaptor.AddChild(root_0, string_literal126_tree);
    		}

    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(76, 42);
    	} finally { DebugExitRule(GrammarFileName, "funcbody"); }
    	return retval;

    }
    // $ANTLR end "funcbody"

    public class parlist1_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_parlist1() {}
    protected virtual void Leave_parlist1() {}

    // $ANTLR start "parlist1"
    // Lua.g:78:1: parlist1 : ( namelist ( ',' '...' )? | '...' );
    [GrammarRule("parlist1")]
    public LuaParser.parlist1_return parlist1()
    {

        LuaParser.parlist1_return retval = new LuaParser.parlist1_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal128=null;
        IToken string_literal129=null;
        IToken string_literal130=null;
        LuaParser.namelist_return namelist127 = default(LuaParser.namelist_return);

        object char_literal128_tree=null;
        object string_literal129_tree=null;
        object string_literal130_tree=null;

    	try { DebugEnterRule(GrammarFileName, "parlist1");
    	DebugLocation(78, 40);
    	try
    	{
    		// Lua.g:78:10: ( namelist ( ',' '...' )? | '...' )
    		int alt31=2;
    		try { DebugEnterDecision(31, decisionCanBacktrack[31]);
    		int LA31_0 = input.LA(1);

    		if ((LA31_0==NAME))
    		{
    			alt31=1;
    		}
    		else if ((LA31_0==43))
    		{
    			alt31=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 31, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(31); }
    		switch (alt31)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:78:12: namelist ( ',' '...' )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(78, 12);
    			PushFollow(Follow._namelist_in_parlist1535);
    			namelist127=namelist();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, namelist127.Tree, namelist127, retval);
    			DebugLocation(78, 21);
    			// Lua.g:78:21: ( ',' '...' )?
    			int alt30=2;
    			try { DebugEnterSubRule(30);
    			try { DebugEnterDecision(30, decisionCanBacktrack[30]);
    			int LA30_0 = input.LA(1);

    			if ((LA30_0==32))
    			{
    				alt30=1;
    			}
    			} finally { DebugExitDecision(30); }
    			switch (alt30)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:78:22: ',' '...'
    				{
    				DebugLocation(78, 22);
    				char_literal128=(IToken)Match(input,32,Follow._32_in_parlist1538); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal128_tree = (object)adaptor.Create(char_literal128, retval);
    				adaptor.AddChild(root_0, char_literal128_tree);
    				}
    				DebugLocation(78, 26);
    				string_literal129=(IToken)Match(input,43,Follow._43_in_parlist1540); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal129_tree = (object)adaptor.Create(string_literal129, retval);
    				adaptor.AddChild(root_0, string_literal129_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(30); }


    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:78:36: '...'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(78, 36);
    			string_literal130=(IToken)Match(input,43,Follow._43_in_parlist1546); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal130_tree = (object)adaptor.Create(string_literal130, retval);
    			adaptor.AddChild(root_0, string_literal130_tree);
    			}

    			}
    			break;

    		}
    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(78, 40);
    	} finally { DebugExitRule(GrammarFileName, "parlist1"); }
    	return retval;

    }
    // $ANTLR end "parlist1"

    public class tableconstructor_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_tableconstructor() {}
    protected virtual void Leave_tableconstructor() {}

    // $ANTLR start "tableconstructor"
    // Lua.g:80:1: tableconstructor : '{' ( fieldlist )? '}' ;
    [GrammarRule("tableconstructor")]
    public LuaParser.tableconstructor_return tableconstructor()
    {

        LuaParser.tableconstructor_return retval = new LuaParser.tableconstructor_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal131=null;
        IToken char_literal133=null;
        LuaParser.fieldlist_return fieldlist132 = default(LuaParser.fieldlist_return);

        object char_literal131_tree=null;
        object char_literal133_tree=null;

    	try { DebugEnterRule(GrammarFileName, "tableconstructor");
    	DebugLocation(80, 39);
    	try
    	{
    		// Lua.g:80:18: ( '{' ( fieldlist )? '}' )
    		DebugEnterAlt(1);
    		// Lua.g:80:20: '{' ( fieldlist )? '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(80, 20);
    		char_literal131=(IToken)Match(input,48,Follow._48_in_tableconstructor554); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal131_tree = (object)adaptor.Create(char_literal131, retval);
    		adaptor.AddChild(root_0, char_literal131_tree);
    		}
    		DebugLocation(80, 24);
    		// Lua.g:80:24: ( fieldlist )?
    		int alt32=2;
    		try { DebugEnterSubRule(32);
    		try { DebugEnterDecision(32, decisionCanBacktrack[32]);
    		int LA32_0 = input.LA(1);

    		if (((LA32_0>=NAME && LA32_0<=LONGSTRING)||LA32_0==34||(LA32_0>=40 && LA32_0<=44)||LA32_0==46||LA32_0==48||LA32_0==51||(LA32_0>=65 && LA32_0<=66)))
    		{
    			alt32=1;
    		}
    		} finally { DebugExitDecision(32); }
    		switch (alt32)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:80:25: fieldlist
    			{
    			DebugLocation(80, 25);
    			PushFollow(Follow._fieldlist_in_tableconstructor557);
    			fieldlist132=fieldlist();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, fieldlist132.Tree, fieldlist132, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(32); }

    		DebugLocation(80, 37);
    		char_literal133=(IToken)Match(input,49,Follow._49_in_tableconstructor561); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal133_tree = (object)adaptor.Create(char_literal133, retval);
    		adaptor.AddChild(root_0, char_literal133_tree);
    		}

    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(80, 39);
    	} finally { DebugExitRule(GrammarFileName, "tableconstructor"); }
    	return retval;

    }
    // $ANTLR end "tableconstructor"

    public class fieldlist_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_fieldlist() {}
    protected virtual void Leave_fieldlist() {}

    // $ANTLR start "fieldlist"
    // Lua.g:82:1: fieldlist : field ( fieldsep field )* ( fieldsep )? ;
    [GrammarRule("fieldlist")]
    public LuaParser.fieldlist_return fieldlist()
    {

        LuaParser.fieldlist_return retval = new LuaParser.fieldlist_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        LuaParser.field_return field134 = default(LuaParser.field_return);
        LuaParser.fieldsep_return fieldsep135 = default(LuaParser.fieldsep_return);
        LuaParser.field_return field136 = default(LuaParser.field_return);
        LuaParser.fieldsep_return fieldsep137 = default(LuaParser.fieldsep_return);


    	try { DebugEnterRule(GrammarFileName, "fieldlist");
    	DebugLocation(82, 47);
    	try
    	{
    		// Lua.g:82:11: ( field ( fieldsep field )* ( fieldsep )? )
    		DebugEnterAlt(1);
    		// Lua.g:82:13: field ( fieldsep field )* ( fieldsep )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(82, 13);
    		PushFollow(Follow._field_in_fieldlist569);
    		field134=field();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, field134.Tree, field134, retval);
    		DebugLocation(82, 19);
    		// Lua.g:82:19: ( fieldsep field )*
    		try { DebugEnterSubRule(33);
    		while (true)
    		{
    			int alt33=2;
    			try { DebugEnterDecision(33, decisionCanBacktrack[33]);
    			int LA33_0 = input.LA(1);

    			if ((LA33_0==20||LA33_0==32))
    			{
    				int LA33_1 = input.LA(2);

    				if (((LA33_1>=NAME && LA33_1<=LONGSTRING)||LA33_1==34||(LA33_1>=40 && LA33_1<=44)||LA33_1==46||LA33_1==48||LA33_1==51||(LA33_1>=65 && LA33_1<=66)))
    				{
    					alt33=1;
    				}


    			}


    			} finally { DebugExitDecision(33); }
    			switch ( alt33 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:82:20: fieldsep field
    				{
    				DebugLocation(82, 20);
    				PushFollow(Follow._fieldsep_in_fieldlist572);
    				fieldsep135=fieldsep();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, fieldsep135.Tree, fieldsep135, retval);
    				DebugLocation(82, 29);
    				PushFollow(Follow._field_in_fieldlist574);
    				field136=field();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, field136.Tree, field136, retval);

    				}
    				break;

    			default:
    				goto loop33;
    			}
    		}

    		loop33:
    			;

    		} finally { DebugExitSubRule(33); }

    		DebugLocation(82, 37);
    		// Lua.g:82:37: ( fieldsep )?
    		int alt34=2;
    		try { DebugEnterSubRule(34);
    		try { DebugEnterDecision(34, decisionCanBacktrack[34]);
    		int LA34_0 = input.LA(1);

    		if ((LA34_0==20||LA34_0==32))
    		{
    			alt34=1;
    		}
    		} finally { DebugExitDecision(34); }
    		switch (alt34)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:82:38: fieldsep
    			{
    			DebugLocation(82, 38);
    			PushFollow(Follow._fieldsep_in_fieldlist579);
    			fieldsep137=fieldsep();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, fieldsep137.Tree, fieldsep137, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(34); }


    		}

    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(82, 47);
    	} finally { DebugExitRule(GrammarFileName, "fieldlist"); }
    	return retval;

    }
    // $ANTLR end "fieldlist"

    public class field_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_field() {}
    protected virtual void Leave_field() {}

    // $ANTLR start "field"
    // Lua.g:84:1: field : ( '[' exp ']' '=' exp | NAME '=' exp | exp );
    [GrammarRule("field")]
    public LuaParser.field_return field()
    {

        LuaParser.field_return retval = new LuaParser.field_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken char_literal138=null;
        IToken char_literal140=null;
        IToken char_literal141=null;
        IToken NAME143=null;
        IToken char_literal144=null;
        LuaParser.exp_return exp139 = default(LuaParser.exp_return);
        LuaParser.exp_return exp142 = default(LuaParser.exp_return);
        LuaParser.exp_return exp145 = default(LuaParser.exp_return);
        LuaParser.exp_return exp146 = default(LuaParser.exp_return);

        object char_literal138_tree=null;
        object char_literal140_tree=null;
        object char_literal141_tree=null;
        object NAME143_tree=null;
        object char_literal144_tree=null;

    	try { DebugEnterRule(GrammarFileName, "field");
    	DebugLocation(84, 48);
    	try
    	{
    		// Lua.g:84:7: ( '[' exp ']' '=' exp | NAME '=' exp | exp )
    		int alt35=3;
    		try { DebugEnterDecision(35, decisionCanBacktrack[35]);
    		switch (input.LA(1))
    		{
    		case 46:
    			{
    			alt35=1;
    			}
    			break;
    		case NAME:
    			{
    			int LA35_2 = input.LA(2);

    			if ((LA35_2==21))
    			{
    				alt35=2;
    			}
    			else if ((LA35_2==EOF||(LA35_2>=NORMALSTRING && LA35_2<=LONGSTRING)||LA35_2==20||LA35_2==32||(LA35_2>=38 && LA35_2<=39)||LA35_2==44||LA35_2==46||(LA35_2>=48 && LA35_2<=64)))
    			{
    				alt35=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 35, 2, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case INT:
    		case FLOAT:
    		case EXP:
    		case HEX:
    		case NORMALSTRING:
    		case CHARSTRING:
    		case LONGSTRING:
    		case 34:
    		case 40:
    		case 41:
    		case 42:
    		case 43:
    		case 44:
    		case 48:
    		case 51:
    		case 65:
    		case 66:
    			{
    			alt35=3;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 35, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(35); }
    		switch (alt35)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:84:9: '[' exp ']' '=' exp
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(84, 9);
    			char_literal138=(IToken)Match(input,46,Follow._46_in_field589); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal138_tree = (object)adaptor.Create(char_literal138, retval);
    			adaptor.AddChild(root_0, char_literal138_tree);
    			}
    			DebugLocation(84, 13);
    			PushFollow(Follow._exp_in_field591);
    			exp139=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp139.Tree, exp139, retval);
    			DebugLocation(84, 17);
    			char_literal140=(IToken)Match(input,47,Follow._47_in_field593); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal140_tree = (object)adaptor.Create(char_literal140, retval);
    			adaptor.AddChild(root_0, char_literal140_tree);
    			}
    			DebugLocation(84, 21);
    			char_literal141=(IToken)Match(input,21,Follow._21_in_field595); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal141_tree = (object)adaptor.Create(char_literal141, retval);
    			adaptor.AddChild(root_0, char_literal141_tree);
    			}
    			DebugLocation(84, 25);
    			PushFollow(Follow._exp_in_field597);
    			exp142=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp142.Tree, exp142, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:84:31: NAME '=' exp
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(84, 31);
    			NAME143=(IToken)new XToken((IToken)Match(input,NAME,Follow._NAME_in_field601), "NAME"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			NAME143_tree = (object)adaptor.Create(NAME143, retval);
    			adaptor.AddChild(root_0, NAME143_tree);
    			}
    			DebugLocation(84, 36);
    			char_literal144=(IToken)Match(input,21,Follow._21_in_field603); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal144_tree = (object)adaptor.Create(char_literal144, retval);
    			adaptor.AddChild(root_0, char_literal144_tree);
    			}
    			DebugLocation(84, 40);
    			PushFollow(Follow._exp_in_field605);
    			exp145=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp145.Tree, exp145, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Lua.g:84:46: exp
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(84, 46);
    			PushFollow(Follow._exp_in_field609);
    			exp146=exp();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exp146.Tree, exp146, retval);

    			}
    			break;

    		}
    		retval.Stop = (IToken)input.LT(-1);

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(84, 48);
    	} finally { DebugExitRule(GrammarFileName, "field"); }
    	return retval;

    }
    // $ANTLR end "field"

    public class fieldsep_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_fieldsep() {}
    protected virtual void Leave_fieldsep() {}

    // $ANTLR start "fieldsep"
    // Lua.g:86:1: fieldsep : ( ',' | ';' );
    [GrammarRule("fieldsep")]
    public LuaParser.fieldsep_return fieldsep()
    {

        LuaParser.fieldsep_return retval = new LuaParser.fieldsep_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken set147=null;

        object set147_tree=null;

    	try { DebugEnterRule(GrammarFileName, "fieldsep");
    	DebugLocation(86, 20);
    	try
    	{
    		// Lua.g:86:10: ( ',' | ';' )
    		DebugEnterAlt(1);
    		// Lua.g:
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(86, 10);
    		set147=(IToken)input.LT(1);
    		if (input.LA(1)==20||input.LA(1)==32)
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set147, retval));
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

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(86, 20);
    	} finally { DebugExitRule(GrammarFileName, "fieldsep"); }
    	return retval;

    }
    // $ANTLR end "fieldsep"

    public class binop_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_binop() {}
    protected virtual void Leave_binop() {}

    // $ANTLR start "binop"
    // Lua.g:88:1: binop : ( '+' | '-' | '*' | '/' | '^' | '%' | '..' | '<' | '<=' | '>' | '>=' | '==' | '~=' | 'and' | 'or' );
    [GrammarRule("binop")]
    public LuaParser.binop_return binop()
    {

        LuaParser.binop_return retval = new LuaParser.binop_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken set148=null;

        object set148_tree=null;

    	try { DebugEnterRule(GrammarFileName, "binop");
    	DebugLocation(88, 15);
    	try
    	{
    		// Lua.g:88:7: ( '+' | '-' | '*' | '/' | '^' | '%' | '..' | '<' | '<=' | '>' | '>=' | '==' | '~=' | 'and' | 'or' )
    		DebugEnterAlt(1);
    		// Lua.g:
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(88, 7);
    		set148=(IToken)input.LT(1);
    		if ((input.LA(1)>=50 && input.LA(1)<=64))
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set148, retval));
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

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(90, 15);
    	} finally { DebugExitRule(GrammarFileName, "binop"); }
    	return retval;

    }
    // $ANTLR end "binop"

    public class unop_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_unop() {}
    protected virtual void Leave_unop() {}

    // $ANTLR start "unop"
    // Lua.g:92:1: unop : ( '-' | 'not' | '#' );
    [GrammarRule("unop")]
    public LuaParser.unop_return unop()
    {

        LuaParser.unop_return retval = new LuaParser.unop_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken set149=null;

        object set149_tree=null;

    	try { DebugEnterRule(GrammarFileName, "unop");
    	DebugLocation(92, 24);
    	try
    	{
    		// Lua.g:92:6: ( '-' | 'not' | '#' )
    		DebugEnterAlt(1);
    		// Lua.g:
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(92, 6);
    		set149=(IToken)input.LT(1);
    		if (input.LA(1)==51||(input.LA(1)>=65 && input.LA(1)<=66))
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set149, retval));
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

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(92, 24);
    	} finally { DebugExitRule(GrammarFileName, "unop"); }
    	return retval;

    }
    // $ANTLR end "unop"

    public class lua_number_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_lua_number() {}
    protected virtual void Leave_lua_number() {}

    // $ANTLR start "lua_number"
    // Lua.g:94:1: lua_number : ( INT | FLOAT | EXP | HEX );
    [GrammarRule("lua_number")]
    public LuaParser.lua_number_return lua_number()
    {

        LuaParser.lua_number_return retval = new LuaParser.lua_number_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken set150=null;

        object set150_tree=null;

    	try { DebugEnterRule(GrammarFileName, "lua_number");
    	DebugLocation(94, 36);
    	try
    	{
    		// Lua.g:94:12: ( INT | FLOAT | EXP | HEX )
    		DebugEnterAlt(1);
    		// Lua.g:
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(94, 12);
    		set150=(IToken)input.LT(1);
    		if ((input.LA(1)>=INT && input.LA(1)<=HEX))
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set150, retval));
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

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(94, 36);
    	} finally { DebugExitRule(GrammarFileName, "lua_number"); }
    	return retval;

    }
    // $ANTLR end "lua_number"

    public class lua_string_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_lua_string() {}
    protected virtual void Leave_lua_string() {}

    // $ANTLR start "lua_string"
    // Lua.g:96:1: lua_string : ( NORMALSTRING | CHARSTRING | LONGSTRING );
    [GrammarRule("lua_string")]
    public LuaParser.lua_string_return lua_string()
    {

        LuaParser.lua_string_return retval = new LuaParser.lua_string_return();
        retval.Start = (IToken)input.LT(1);

        object root_0 = null;

        IToken set151=null;

        object set151_tree=null;

    	try { DebugEnterRule(GrammarFileName, "lua_string");
    	DebugLocation(96, 51);
    	try
    	{
    		// Lua.g:96:12: ( NORMALSTRING | CHARSTRING | LONGSTRING )
    		DebugEnterAlt(1);
    		// Lua.g:
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(96, 12);
    		set151=(IToken)input.LT(1);
    		if ((input.LA(1)>=NORMALSTRING && input.LA(1)<=LONGSTRING))
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set151, retval));
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

    		if ( (state.backtracking==0) ) {

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
        }
     	DebugLocation(96, 51);
    	} finally { DebugExitRule(GrammarFileName, "lua_string"); }
    	return retval;

    }
    // $ANTLR end "lua_string"

    protected virtual void Enter_synpred5_Lua_fragment() {}
    protected virtual void Leave_synpred5_Lua_fragment() {}

    // $ANTLR start synpred5_Lua
    public void synpred5_Lua_fragment()
    {
    	// Lua.g:27:9: ( varlist1 '=' explist1 )
    	DebugEnterAlt(1);
    	// Lua.g:27:9: varlist1 '=' explist1
    	{
    	DebugLocation(27, 9);
    	PushFollow(Follow._varlist1_in_synpred5_Lua71);
    	varlist1();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(27, 18);
    	Match(input,21,Follow._21_in_synpred5_Lua73); if (state.failed) return;
    	DebugLocation(27, 22);
    	PushFollow(Follow._explist1_in_synpred5_Lua75);
    	explist1();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred5_Lua

    protected virtual void Enter_synpred6_Lua_fragment() {}
    protected virtual void Leave_synpred6_Lua_fragment() {}

    // $ANTLR start synpred6_Lua
    public void synpred6_Lua_fragment()
    {
    	// Lua.g:28:2: ( functioncall )
    	DebugEnterAlt(1);
    	// Lua.g:28:2: functioncall
    	{
    	DebugLocation(28, 2);
    	PushFollow(Follow._functioncall_in_synpred6_Lua81);
    	functioncall();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred6_Lua

    protected virtual void Enter_synpred14_Lua_fragment() {}
    protected virtual void Leave_synpred14_Lua_fragment() {}

    // $ANTLR start synpred14_Lua
    public void synpred14_Lua_fragment()
    {
    	// Lua.g:33:2: ( 'for' NAME '=' exp ',' exp ( ',' exp )? 'do' block 'end' )
    	DebugEnterAlt(1);
    	// Lua.g:33:2: 'for' NAME '=' exp ',' exp ( ',' exp )? 'do' block 'end'
    	{
    	DebugLocation(33, 2);
    	Match(input,31,Follow._31_in_synpred14_Lua155); if (state.failed) return;
    	DebugLocation(33, 8);
    	new XToken((IToken)Match(input,NAME,Follow._NAME_in_synpred14_Lua157), "NAME"); if (state.failed) return;
    	DebugLocation(33, 13);
    	Match(input,21,Follow._21_in_synpred14_Lua159); if (state.failed) return;
    	DebugLocation(33, 17);
    	PushFollow(Follow._exp_in_synpred14_Lua161);
    	exp();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(33, 21);
    	Match(input,32,Follow._32_in_synpred14_Lua163); if (state.failed) return;
    	DebugLocation(33, 25);
    	PushFollow(Follow._exp_in_synpred14_Lua165);
    	exp();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(33, 29);
    	// Lua.g:33:29: ( ',' exp )?
    	int alt40=2;
    	try { DebugEnterSubRule(40);
    	try { DebugEnterDecision(40, decisionCanBacktrack[40]);
    	int LA40_0 = input.LA(1);

    	if ((LA40_0==32))
    	{
    		alt40=1;
    	}
    	} finally { DebugExitDecision(40); }
    	switch (alt40)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Lua.g:33:30: ',' exp
    		{
    		DebugLocation(33, 30);
    		Match(input,32,Follow._32_in_synpred14_Lua168); if (state.failed) return;
    		DebugLocation(33, 34);
    		PushFollow(Follow._exp_in_synpred14_Lua170);
    		exp();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(40); }

    	DebugLocation(33, 40);
    	Match(input,22,Follow._22_in_synpred14_Lua174); if (state.failed) return;
    	DebugLocation(33, 45);
    	PushFollow(Follow._block_in_synpred14_Lua176);
    	block();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(33, 51);
    	Match(input,23,Follow._23_in_synpred14_Lua178); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred14_Lua

    protected virtual void Enter_synpred15_Lua_fragment() {}
    protected virtual void Leave_synpred15_Lua_fragment() {}

    // $ANTLR start synpred15_Lua
    public void synpred15_Lua_fragment()
    {
    	// Lua.g:34:2: ( 'for' namelist 'in' explist1 'do' block 'end' )
    	DebugEnterAlt(1);
    	// Lua.g:34:2: 'for' namelist 'in' explist1 'do' block 'end'
    	{
    	DebugLocation(34, 2);
    	Match(input,31,Follow._31_in_synpred15_Lua184); if (state.failed) return;
    	DebugLocation(34, 8);
    	PushFollow(Follow._namelist_in_synpred15_Lua186);
    	namelist();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(34, 17);
    	Match(input,33,Follow._33_in_synpred15_Lua188); if (state.failed) return;
    	DebugLocation(34, 22);
    	PushFollow(Follow._explist1_in_synpred15_Lua190);
    	explist1();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(34, 31);
    	Match(input,22,Follow._22_in_synpred15_Lua192); if (state.failed) return;
    	DebugLocation(34, 36);
    	PushFollow(Follow._block_in_synpred15_Lua194);
    	block();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(34, 42);
    	Match(input,23,Follow._23_in_synpred15_Lua196); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred15_Lua

    protected virtual void Enter_synpred17_Lua_fragment() {}
    protected virtual void Leave_synpred17_Lua_fragment() {}

    // $ANTLR start synpred17_Lua
    public void synpred17_Lua_fragment()
    {
    	// Lua.g:36:2: ( 'local' 'function' NAME funcbody )
    	DebugEnterAlt(1);
    	// Lua.g:36:2: 'local' 'function' NAME funcbody
    	{
    	DebugLocation(36, 2);
    	Match(input,35,Follow._35_in_synpred17_Lua212); if (state.failed) return;
    	DebugLocation(36, 10);
    	Match(input,34,Follow._34_in_synpred17_Lua214); if (state.failed) return;
    	DebugLocation(36, 21);
    	new XToken((IToken)Match(input,NAME,Follow._NAME_in_synpred17_Lua216), "NAME"); if (state.failed) return;
    	DebugLocation(36, 26);
    	PushFollow(Follow._funcbody_in_synpred17_Lua218);
    	funcbody();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred17_Lua

    protected virtual void Enter_synpred25_Lua_fragment() {}
    protected virtual void Leave_synpred25_Lua_fragment() {}

    // $ANTLR start synpred25_Lua
    public void synpred25_Lua_fragment()
    {
    	// Lua.g:48:13: ( exp ',' )
    	DebugEnterAlt(1);
    	// Lua.g:48:13: exp ','
    	{
    	DebugLocation(48, 13);
    	PushFollow(Follow._exp_in_synpred25_Lua314);
    	exp();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(48, 17);
    	Match(input,32,Follow._32_in_synpred25_Lua316); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred25_Lua

    protected virtual void Enter_synpred35_Lua_fragment() {}
    protected virtual void Leave_synpred35_Lua_fragment() {}

    // $ANTLR start synpred35_Lua
    public void synpred35_Lua_fragment()
    {
    	// Lua.g:50:123: ( binop exp )
    	DebugEnterAlt(1);
    	// Lua.g:50:123: binop exp
    	{
    	DebugLocation(50, 123);
    	PushFollow(Follow._binop_in_synpred35_Lua372);
    	binop();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(50, 129);
    	PushFollow(Follow._exp_in_synpred35_Lua374);
    	exp();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred35_Lua

    protected virtual void Enter_synpred37_Lua_fragment() {}
    protected virtual void Leave_synpred37_Lua_fragment() {}

    // $ANTLR start synpred37_Lua
    public void synpred37_Lua_fragment()
    {
    	// Lua.g:52:37: ( varSuffix )
    	DebugEnterAlt(1);
    	// Lua.g:52:37: varSuffix
    	{
    	DebugLocation(52, 37);
    	PushFollow(Follow._varSuffix_in_synpred37_Lua398);
    	varSuffix();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred37_Lua

    protected virtual void Enter_synpred38_Lua_fragment() {}
    protected virtual void Leave_synpred38_Lua_fragment() {}

    // $ANTLR start synpred38_Lua
    public void synpred38_Lua_fragment()
    {
    	// Lua.g:54:21: ( nameAndArgs )
    	DebugEnterAlt(1);
    	// Lua.g:54:21: nameAndArgs
    	{
    	DebugLocation(54, 21);
    	PushFollow(Follow._nameAndArgs_in_synpred38_Lua408);
    	nameAndArgs();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred38_Lua

    protected virtual void Enter_synpred39_Lua_fragment() {}
    protected virtual void Leave_synpred39_Lua_fragment() {}

    // $ANTLR start synpred39_Lua
    public void synpred39_Lua_fragment()
    {
    	// Lua.g:56:24: ( nameAndArgs )
    	DebugEnterAlt(1);
    	// Lua.g:56:24: nameAndArgs
    	{
    	DebugLocation(56, 24);
    	PushFollow(Follow._nameAndArgs_in_synpred39_Lua418);
    	nameAndArgs();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred39_Lua

    protected virtual void Enter_synpred40_Lua_fragment() {}
    protected virtual void Leave_synpred40_Lua_fragment() {}

    // $ANTLR start synpred40_Lua
    public void synpred40_Lua_fragment()
    {
    	// Lua.g:66:11: ( var )
    	DebugEnterAlt(1);
    	// Lua.g:66:11: var
    	{
    	DebugLocation(66, 11);
    	PushFollow(Follow._var_in_synpred40_Lua429);
    	var();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred40_Lua
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
	DFA9 dfa9;
	DFA16 dfa16;
	DFA20 dfa20;
	DFA21 dfa21;
	DFA22 dfa22;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa9 = new DFA9( this, SpecialStateTransition9 );
		dfa16 = new DFA16( this, SpecialStateTransition16 );
		dfa20 = new DFA20( this, SpecialStateTransition20 );
		dfa21 = new DFA21( this, SpecialStateTransition21 );
		dfa22 = new DFA22( this, SpecialStateTransition22 );
	}

	private class DFA9 : DFA
	{
		private const string DFA9_eotS =
			"\x10\uffff";
		private const string DFA9_eofS =
			"\x10\uffff";
		private const string DFA9_minS =
			"\x01\x04\x02\x00\x04\uffff\x01\x00\x01\uffff\x01\x00\x06\uffff";
		private const string DFA9_maxS =
			"\x01\x2c\x02\x00\x04\uffff\x01\x00\x01\uffff\x01\x00\x06\uffff";
		private const string DFA9_acceptS =
			"\x03\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\uffff\x01\x09\x01\uffff"+
			"\x01\x01\x01\x02\x01\x07\x01\x08\x01\x0a\x01\x0b";
		private const string DFA9_specialS =
			"\x01\uffff\x01\x00\x01\x01\x04\uffff\x01\x02\x01\uffff\x01\x03\x06\uffff}>";
		private static readonly string[] DFA9_transitionS =
			{
				"\x01\x01\x11\uffff\x01\x03\x01\uffff\x01\x04\x01\x05\x01\uffff\x01"+
				"\x06\x03\uffff\x01\x07\x02\uffff\x01\x08\x01\x09\x08\uffff\x01\x02",
				"\x01\uffff",
				"\x01\uffff",
				"",
				"",
				"",
				"",
				"\x01\uffff",
				"",
				"\x01\uffff",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA9_eot = DFA.UnpackEncodedString(DFA9_eotS);
		private static readonly short[] DFA9_eof = DFA.UnpackEncodedString(DFA9_eofS);
		private static readonly char[] DFA9_min = DFA.UnpackEncodedStringToUnsignedChars(DFA9_minS);
		private static readonly char[] DFA9_max = DFA.UnpackEncodedStringToUnsignedChars(DFA9_maxS);
		private static readonly short[] DFA9_accept = DFA.UnpackEncodedString(DFA9_acceptS);
		private static readonly short[] DFA9_special = DFA.UnpackEncodedString(DFA9_specialS);
		private static readonly short[][] DFA9_transition;

		static DFA9()
		{
			int numStates = DFA9_transitionS.Length;
			DFA9_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA9_transition[i] = DFA.UnpackEncodedString(DFA9_transitionS[i]);
			}
		}

		public DFA9( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 9;
			this.eot = DFA9_eot;
			this.eof = DFA9_eof;
			this.min = DFA9_min;
			this.max = DFA9_max;
			this.accept = DFA9_accept;
			this.special = DFA9_special;
			this.transition = DFA9_transition;
		}

		public override string Description { get { return "27:1: stat : ( varlist1 '=' explist1 | functioncall | 'do' block 'end' | 'while' exp 'do' block 'end' | 'repeat' block 'until' exp | 'if' exp 'then' block ( 'elseif' exp 'then' block )* ( 'else' block )? 'end' | 'for' NAME '=' exp ',' exp ( ',' exp )? 'do' block 'end' | 'for' namelist 'in' explist1 'do' block 'end' | 'function' funcname funcbody | 'local' 'function' NAME funcbody | 'local' namelist ( '=' explist1 )? );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition9(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA9_1 = input.LA(1);


				int index9_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred5_Lua_fragment)) ) {s = 10;}

				else if ( (EvaluatePredicate(synpred6_Lua_fragment)) ) {s = 11;}


				input.Seek(index9_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA9_2 = input.LA(1);


				int index9_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred5_Lua_fragment)) ) {s = 10;}

				else if ( (EvaluatePredicate(synpred6_Lua_fragment)) ) {s = 11;}


				input.Seek(index9_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA9_7 = input.LA(1);


				int index9_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred14_Lua_fragment)) ) {s = 12;}

				else if ( (EvaluatePredicate(synpred15_Lua_fragment)) ) {s = 13;}


				input.Seek(index9_7);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA9_9 = input.LA(1);


				int index9_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred17_Lua_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 15;}


				input.Seek(index9_9);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 9, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA16 : DFA
	{
		private const string DFA16_eotS =
			"\x0e\uffff";
		private const string DFA16_eofS =
			"\x0e\uffff";
		private const string DFA16_minS =
			"\x01\x04\x0b\x00\x02\uffff";
		private const string DFA16_maxS =
			"\x01\x42\x0b\x00\x02\uffff";
		private const string DFA16_acceptS =
			"\x0c\uffff\x01\x01\x01\x02";
		private const string DFA16_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x02\uffff}>";
		private static readonly string[] DFA16_transitionS =
			{
				"\x01\x08\x04\x04\x03\x05\x16\uffff\x01\x07\x05\uffff\x01\x01\x01\x02"+
				"\x01\x03\x01\x06\x01\x09\x03\uffff\x01\x0a\x02\uffff\x01\x0b\x0d\uffff"+
				"\x02\x0b",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"",
				""
			};

		private static readonly short[] DFA16_eot = DFA.UnpackEncodedString(DFA16_eotS);
		private static readonly short[] DFA16_eof = DFA.UnpackEncodedString(DFA16_eofS);
		private static readonly char[] DFA16_min = DFA.UnpackEncodedStringToUnsignedChars(DFA16_minS);
		private static readonly char[] DFA16_max = DFA.UnpackEncodedStringToUnsignedChars(DFA16_maxS);
		private static readonly short[] DFA16_accept = DFA.UnpackEncodedString(DFA16_acceptS);
		private static readonly short[] DFA16_special = DFA.UnpackEncodedString(DFA16_specialS);
		private static readonly short[][] DFA16_transition;

		static DFA16()
		{
			int numStates = DFA16_transitionS.Length;
			DFA16_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA16_transition[i] = DFA.UnpackEncodedString(DFA16_transitionS[i]);
			}
		}

		public DFA16( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 16;
			this.eot = DFA16_eot;
			this.eof = DFA16_eof;
			this.min = DFA16_min;
			this.max = DFA16_max;
			this.accept = DFA16_accept;
			this.special = DFA16_special;
			this.transition = DFA16_transition;
		}

		public override string Description { get { return "()* loopback of 48:12: ( exp ',' )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition16(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA16_1 = input.LA(1);


				int index16_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA16_2 = input.LA(1);


				int index16_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA16_3 = input.LA(1);


				int index16_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA16_4 = input.LA(1);


				int index16_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA16_5 = input.LA(1);


				int index16_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA16_6 = input.LA(1);


				int index16_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA16_7 = input.LA(1);


				int index16_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA16_8 = input.LA(1);


				int index16_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA16_9 = input.LA(1);


				int index16_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA16_10 = input.LA(1);


				int index16_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA16_11 = input.LA(1);


				int index16_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred25_Lua_fragment)) ) {s = 12;}

				else if ( (true) ) {s = 13;}


				input.Seek(index16_11);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 16, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA20 : DFA
	{
		private const string DFA20_eotS =
			"\x1e\uffff";
		private const string DFA20_eofS =
			"\x01\x01\x1d\uffff";
		private const string DFA20_minS =
			"\x01\x04\x02\uffff\x04\x00\x17\uffff";
		private const string DFA20_maxS =
			"\x01\x40\x02\uffff\x04\x00\x17\uffff";
		private const string DFA20_acceptS =
			"\x01\uffff\x01\x02\x1a\uffff\x01\x01\x01\uffff";
		private const string DFA20_specialS =
			"\x03\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x17\uffff}>";
		private static readonly string[] DFA20_transitionS =
			{
				"\x01\x01\x04\uffff\x03\x06\x08\uffff\x0d\x01\x01\uffff\x04\x01\x01"+
				"\x1c\x01\x03\x04\uffff\x01\x04\x01\x01\x01\x1c\x01\x01\x01\x05\x10\x01",
				"",
				"",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
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

		private static readonly short[] DFA20_eot = DFA.UnpackEncodedString(DFA20_eotS);
		private static readonly short[] DFA20_eof = DFA.UnpackEncodedString(DFA20_eofS);
		private static readonly char[] DFA20_min = DFA.UnpackEncodedStringToUnsignedChars(DFA20_minS);
		private static readonly char[] DFA20_max = DFA.UnpackEncodedStringToUnsignedChars(DFA20_maxS);
		private static readonly short[] DFA20_accept = DFA.UnpackEncodedString(DFA20_acceptS);
		private static readonly short[] DFA20_special = DFA.UnpackEncodedString(DFA20_specialS);
		private static readonly short[][] DFA20_transition;

		static DFA20()
		{
			int numStates = DFA20_transitionS.Length;
			DFA20_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA20_transition[i] = DFA.UnpackEncodedString(DFA20_transitionS[i]);
			}
		}

		public DFA20( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 20;
			this.eot = DFA20_eot;
			this.eof = DFA20_eof;
			this.min = DFA20_min;
			this.max = DFA20_max;
			this.accept = DFA20_accept;
			this.special = DFA20_special;
			this.transition = DFA20_transition;
		}

		public override string Description { get { return "()* loopback of 52:37: ( varSuffix )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition20(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA20_3 = input.LA(1);


				int index20_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred37_Lua_fragment)) ) {s = 28;}

				else if ( (true) ) {s = 1;}


				input.Seek(index20_3);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA20_4 = input.LA(1);


				int index20_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred37_Lua_fragment)) ) {s = 28;}

				else if ( (true) ) {s = 1;}


				input.Seek(index20_4);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA20_5 = input.LA(1);


				int index20_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred37_Lua_fragment)) ) {s = 28;}

				else if ( (true) ) {s = 1;}


				input.Seek(index20_5);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA20_6 = input.LA(1);


				int index20_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred37_Lua_fragment)) ) {s = 28;}

				else if ( (true) ) {s = 1;}


				input.Seek(index20_6);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 20, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA21 : DFA
	{
		private const string DFA21_eotS =
			"\x1b\uffff";
		private const string DFA21_eofS =
			"\x01\x01\x1a\uffff";
		private const string DFA21_minS =
			"\x01\x04\x0b\uffff\x01\x00\x0e\uffff";
		private const string DFA21_maxS =
			"\x01\x40\x0b\uffff\x01\x00\x0e\uffff";
		private const string DFA21_acceptS =
			"\x01\uffff\x01\x02\x16\uffff\x01\x01\x02\uffff";
		private const string DFA21_specialS =
			"\x0c\uffff\x01\x00\x0e\uffff}>";
		private static readonly string[] DFA21_transitionS =
			{
				"\x01\x01\x04\uffff\x03\x18\x08\uffff\x01\x01\x01\uffff\x0b\x01\x01"+
				"\uffff\x04\x01\x01\uffff\x01\x18\x04\uffff\x01\x0c\x01\x01\x01\uffff"+
				"\x01\x01\x01\x18\x10\x01",
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
				"\x01\uffff",
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

		private static readonly short[] DFA21_eot = DFA.UnpackEncodedString(DFA21_eotS);
		private static readonly short[] DFA21_eof = DFA.UnpackEncodedString(DFA21_eofS);
		private static readonly char[] DFA21_min = DFA.UnpackEncodedStringToUnsignedChars(DFA21_minS);
		private static readonly char[] DFA21_max = DFA.UnpackEncodedStringToUnsignedChars(DFA21_maxS);
		private static readonly short[] DFA21_accept = DFA.UnpackEncodedString(DFA21_acceptS);
		private static readonly short[] DFA21_special = DFA.UnpackEncodedString(DFA21_specialS);
		private static readonly short[][] DFA21_transition;

		static DFA21()
		{
			int numStates = DFA21_transitionS.Length;
			DFA21_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA21_transition[i] = DFA.UnpackEncodedString(DFA21_transitionS[i]);
			}
		}

		public DFA21( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 21;
			this.eot = DFA21_eot;
			this.eof = DFA21_eof;
			this.min = DFA21_min;
			this.max = DFA21_max;
			this.accept = DFA21_accept;
			this.special = DFA21_special;
			this.transition = DFA21_transition;
		}

		public override string Description { get { return "()* loopback of 54:21: ( nameAndArgs )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition21(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA21_12 = input.LA(1);


				int index21_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred38_Lua_fragment)) ) {s = 24;}

				else if ( (true) ) {s = 1;}


				input.Seek(index21_12);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 21, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA22 : DFA
	{
		private const string DFA22_eotS =
			"\x15\uffff";
		private const string DFA22_eofS =
			"\x01\x01\x14\uffff";
		private const string DFA22_minS =
			"\x01\x04\x09\uffff\x01\x00\x0a\uffff";
		private const string DFA22_maxS =
			"\x01\x30\x09\uffff\x01\x00\x0a\uffff";
		private const string DFA22_acceptS =
			"\x01\uffff\x01\x02\x10\uffff\x01\x01\x02\uffff";
		private const string DFA22_specialS =
			"\x0a\uffff\x01\x00\x0a\uffff}>";
		private static readonly string[] DFA22_transitionS =
			{
				"\x01\x01\x04\uffff\x03\x12\x08\uffff\x01\x01\x01\uffff\x06\x01\x01"+
				"\uffff\x03\x01\x02\uffff\x04\x01\x01\uffff\x01\x12\x04\uffff\x01\x0a"+
				"\x03\uffff\x01\x12",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x01\uffff",
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

		private static readonly short[] DFA22_eot = DFA.UnpackEncodedString(DFA22_eotS);
		private static readonly short[] DFA22_eof = DFA.UnpackEncodedString(DFA22_eofS);
		private static readonly char[] DFA22_min = DFA.UnpackEncodedStringToUnsignedChars(DFA22_minS);
		private static readonly char[] DFA22_max = DFA.UnpackEncodedStringToUnsignedChars(DFA22_maxS);
		private static readonly short[] DFA22_accept = DFA.UnpackEncodedString(DFA22_acceptS);
		private static readonly short[] DFA22_special = DFA.UnpackEncodedString(DFA22_specialS);
		private static readonly short[][] DFA22_transition;

		static DFA22()
		{
			int numStates = DFA22_transitionS.Length;
			DFA22_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA22_transition[i] = DFA.UnpackEncodedString(DFA22_transitionS[i]);
			}
		}

		public DFA22( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 22;
			this.eot = DFA22_eot;
			this.eof = DFA22_eof;
			this.min = DFA22_min;
			this.max = DFA22_max;
			this.accept = DFA22_accept;
			this.special = DFA22_special;
			this.transition = DFA22_transition;
		}

		public override string Description { get { return "()+ loopback of 56:24: ( nameAndArgs )+"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition22(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA22_10 = input.LA(1);


				int index22_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred39_Lua_fragment)) ) {s = 18;}

				else if ( (true) ) {s = 1;}


				input.Seek(index22_10);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 22, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}

	#endregion DFA

	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _stat_in_chunk37 = new BitSet(new ulong[]{0x0000103C8B500012UL});
		public static readonly BitSet _20_in_chunk40 = new BitSet(new ulong[]{0x0000103C8B500012UL});
		public static readonly BitSet _laststat_in_chunk47 = new BitSet(new ulong[]{0x0000000000100002UL});
		public static readonly BitSet _20_in_chunk50 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _chunk_in_block62 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _varlist1_in_stat71 = new BitSet(new ulong[]{0x0000000000200000UL});
		public static readonly BitSet _21_in_stat73 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _explist1_in_stat75 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _functioncall_in_stat81 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _22_in_stat87 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat89 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_stat91 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _24_in_stat97 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_stat99 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet _22_in_stat101 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat103 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_stat105 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _25_in_stat111 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat113 = new BitSet(new ulong[]{0x0000000004000000UL});
		public static readonly BitSet _26_in_stat115 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_stat117 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _27_in_stat123 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_stat125 = new BitSet(new ulong[]{0x0000000010000000UL});
		public static readonly BitSet _28_in_stat127 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat129 = new BitSet(new ulong[]{0x0000000060800000UL});
		public static readonly BitSet _29_in_stat132 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_stat134 = new BitSet(new ulong[]{0x0000000010000000UL});
		public static readonly BitSet _28_in_stat136 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat138 = new BitSet(new ulong[]{0x0000000060800000UL});
		public static readonly BitSet _30_in_stat143 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat145 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_stat149 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _31_in_stat155 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_stat157 = new BitSet(new ulong[]{0x0000000000200000UL});
		public static readonly BitSet _21_in_stat159 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_stat161 = new BitSet(new ulong[]{0x0000000100000000UL});
		public static readonly BitSet _32_in_stat163 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_stat165 = new BitSet(new ulong[]{0x0000000100400000UL});
		public static readonly BitSet _32_in_stat168 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_stat170 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet _22_in_stat174 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat176 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_stat178 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _31_in_stat184 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _namelist_in_stat186 = new BitSet(new ulong[]{0x0000000200000000UL});
		public static readonly BitSet _33_in_stat188 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _explist1_in_stat190 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet _22_in_stat192 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_stat194 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_stat196 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _34_in_stat202 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _funcname_in_stat204 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet _funcbody_in_stat206 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _35_in_stat212 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _34_in_stat214 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_stat216 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet _funcbody_in_stat218 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _35_in_stat224 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _namelist_in_stat226 = new BitSet(new ulong[]{0x0000000000200002UL});
		public static readonly BitSet _21_in_stat229 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _explist1_in_stat231 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _36_in_laststat242 = new BitSet(new ulong[]{0x00091F0400000FF2UL,0x0000000000000006UL});
		public static readonly BitSet _explist1_in_laststat245 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _37_in_laststat251 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NAME_in_funcname259 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet _38_in_funcname262 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_funcname264 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet _39_in_funcname269 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_funcname271 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _var_in_varlist1282 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet _32_in_varlist1285 = new BitSet(new ulong[]{0x0000100000000010UL});
		public static readonly BitSet _var_in_varlist1287 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet _NAME_in_namelist298 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet _32_in_namelist301 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_namelist303 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet _exp_in_explist1314 = new BitSet(new ulong[]{0x0000000100000000UL});
		public static readonly BitSet _32_in_explist1316 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_explist1320 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _40_in_exp330 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _41_in_exp334 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _42_in_exp338 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _lua_number_in_exp342 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _lua_string_in_exp346 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _43_in_exp350 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _function_in_exp354 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _prefixexp_in_exp358 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _tableconstructor_in_exp362 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _unop_in_exp366 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_exp368 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _binop_in_exp372 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_exp374 = new BitSet(new ulong[]{0xFFFC000000000002UL,0x0000000000000001UL});
		public static readonly BitSet _NAME_in_var385 = new BitSet(new ulong[]{0x000150C000000E02UL});
		public static readonly BitSet _44_in_var389 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_var391 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet _45_in_var393 = new BitSet(new ulong[]{0x000150C000000E00UL});
		public static readonly BitSet _varSuffix_in_var395 = new BitSet(new ulong[]{0x000150C000000E02UL});
		public static readonly BitSet _varSuffix_in_var398 = new BitSet(new ulong[]{0x000150C000000E02UL});
		public static readonly BitSet _varOrExp_in_prefixexp406 = new BitSet(new ulong[]{0x0001108000000E02UL});
		public static readonly BitSet _nameAndArgs_in_prefixexp408 = new BitSet(new ulong[]{0x0001108000000E02UL});
		public static readonly BitSet _varOrExp_in_functioncall416 = new BitSet(new ulong[]{0x0001108000000E00UL});
		public static readonly BitSet _nameAndArgs_in_functioncall418 = new BitSet(new ulong[]{0x0001108000000E02UL});
		public static readonly BitSet _var_in_varOrExp429 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _44_in_varOrExp433 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_varOrExp435 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet _45_in_varOrExp437 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _39_in_nameAndArgs445 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_nameAndArgs447 = new BitSet(new ulong[]{0x0001108000000E00UL});
		public static readonly BitSet _args_in_nameAndArgs451 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _nameAndArgs_in_varSuffix458 = new BitSet(new ulong[]{0x000150C000000E00UL});
		public static readonly BitSet _46_in_varSuffix462 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_varSuffix464 = new BitSet(new ulong[]{0x0000800000000000UL});
		public static readonly BitSet _47_in_varSuffix466 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _38_in_varSuffix470 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_varSuffix472 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _44_in_args482 = new BitSet(new ulong[]{0x00093F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _explist1_in_args485 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet _45_in_args489 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _tableconstructor_in_args493 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _lua_string_in_args497 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _34_in_function506 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet _funcbody_in_function508 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _44_in_funcbody516 = new BitSet(new ulong[]{0x0000280000000010UL});
		public static readonly BitSet _parlist1_in_funcbody519 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet _45_in_funcbody523 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_funcbody525 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_funcbody527 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _namelist_in_parlist1535 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet _32_in_parlist1538 = new BitSet(new ulong[]{0x0000080000000000UL});
		public static readonly BitSet _43_in_parlist1540 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _43_in_parlist1546 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _48_in_tableconstructor554 = new BitSet(new ulong[]{0x000B5F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _fieldlist_in_tableconstructor557 = new BitSet(new ulong[]{0x0002000000000000UL});
		public static readonly BitSet _49_in_tableconstructor561 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _field_in_fieldlist569 = new BitSet(new ulong[]{0x0000000100100002UL});
		public static readonly BitSet _fieldsep_in_fieldlist572 = new BitSet(new ulong[]{0x00095F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _field_in_fieldlist574 = new BitSet(new ulong[]{0x0000000100100002UL});
		public static readonly BitSet _fieldsep_in_fieldlist579 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _46_in_field589 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_field591 = new BitSet(new ulong[]{0x0000800000000000UL});
		public static readonly BitSet _47_in_field593 = new BitSet(new ulong[]{0x0000000000200000UL});
		public static readonly BitSet _21_in_field595 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_field597 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NAME_in_field601 = new BitSet(new ulong[]{0x0000000000200000UL});
		public static readonly BitSet _21_in_field603 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_field605 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _exp_in_field609 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _set_in_fieldsep0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _set_in_binop0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _set_in_unop0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _set_in_lua_number0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _set_in_lua_string0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _varlist1_in_synpred5_Lua71 = new BitSet(new ulong[]{0x0000000000200000UL});
		public static readonly BitSet _21_in_synpred5_Lua73 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _explist1_in_synpred5_Lua75 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _functioncall_in_synpred6_Lua81 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _31_in_synpred14_Lua155 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_synpred14_Lua157 = new BitSet(new ulong[]{0x0000000000200000UL});
		public static readonly BitSet _21_in_synpred14_Lua159 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_synpred14_Lua161 = new BitSet(new ulong[]{0x0000000100000000UL});
		public static readonly BitSet _32_in_synpred14_Lua163 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_synpred14_Lua165 = new BitSet(new ulong[]{0x0000000100400000UL});
		public static readonly BitSet _32_in_synpred14_Lua168 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_synpred14_Lua170 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet _22_in_synpred14_Lua174 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_synpred14_Lua176 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_synpred14_Lua178 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _31_in_synpred15_Lua184 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _namelist_in_synpred15_Lua186 = new BitSet(new ulong[]{0x0000000200000000UL});
		public static readonly BitSet _33_in_synpred15_Lua188 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _explist1_in_synpred15_Lua190 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet _22_in_synpred15_Lua192 = new BitSet(new ulong[]{0x0000103C8B500010UL});
		public static readonly BitSet _block_in_synpred15_Lua194 = new BitSet(new ulong[]{0x0000000000800000UL});
		public static readonly BitSet _23_in_synpred15_Lua196 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _35_in_synpred17_Lua212 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _34_in_synpred17_Lua214 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _NAME_in_synpred17_Lua216 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet _funcbody_in_synpred17_Lua218 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _exp_in_synpred25_Lua314 = new BitSet(new ulong[]{0x0000000100000000UL});
		public static readonly BitSet _32_in_synpred25_Lua316 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _binop_in_synpred35_Lua372 = new BitSet(new ulong[]{0x00091F0400000FF0UL,0x0000000000000006UL});
		public static readonly BitSet _exp_in_synpred35_Lua374 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _varSuffix_in_synpred37_Lua398 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _nameAndArgs_in_synpred38_Lua408 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _nameAndArgs_in_synpred39_Lua418 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _var_in_synpred40_Lua429 = new BitSet(new ulong[]{0x0000000000000002UL});

	}
	#endregion Follow sets
}
