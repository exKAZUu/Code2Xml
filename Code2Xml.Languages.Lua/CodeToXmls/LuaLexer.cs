using Code2Xml.Core.Antlr;
// $ANTLR 3.3 Nov 30, 2010 12:50:56 Lua.g 2011-06-08 19:06:17

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

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class LuaLexer : Antlr.Runtime.Lexer
{
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

	public LuaLexer()
	{
		OnCreated();
	}

	public LuaLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public LuaLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "Lua.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];

 
	protected virtual void OnCreated() {}
	protected virtual void EnterRule(string ruleName, int ruleIndex) {}
	protected virtual void LeaveRule(string ruleName, int ruleIndex) {}

    protected virtual void Enter_T__20() {}
    protected virtual void Leave_T__20() {}

    // $ANTLR start "T__20"
    [GrammarRule("T__20")]
    private void mT__20()
    {

    		try
    		{
    		int _type = T__20;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:7:7: ( ';' )
    		DebugEnterAlt(1);
    		// Lua.g:7:9: ';'
    		{
    		DebugLocation(7, 9);
    		Match(';'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__20"

    protected virtual void Enter_T__21() {}
    protected virtual void Leave_T__21() {}

    // $ANTLR start "T__21"
    [GrammarRule("T__21")]
    private void mT__21()
    {

    		try
    		{
    		int _type = T__21;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:8:7: ( '=' )
    		DebugEnterAlt(1);
    		// Lua.g:8:9: '='
    		{
    		DebugLocation(8, 9);
    		Match('='); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__21"

    protected virtual void Enter_T__22() {}
    protected virtual void Leave_T__22() {}

    // $ANTLR start "T__22"
    [GrammarRule("T__22")]
    private void mT__22()
    {

    		try
    		{
    		int _type = T__22;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:9:7: ( 'do' )
    		DebugEnterAlt(1);
    		// Lua.g:9:9: 'do'
    		{
    		DebugLocation(9, 9);
    		Match("do"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__22"

    protected virtual void Enter_T__23() {}
    protected virtual void Leave_T__23() {}

    // $ANTLR start "T__23"
    [GrammarRule("T__23")]
    private void mT__23()
    {

    		try
    		{
    		int _type = T__23;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:10:7: ( 'end' )
    		DebugEnterAlt(1);
    		// Lua.g:10:9: 'end'
    		{
    		DebugLocation(10, 9);
    		Match("end"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__23"

    protected virtual void Enter_T__24() {}
    protected virtual void Leave_T__24() {}

    // $ANTLR start "T__24"
    [GrammarRule("T__24")]
    private void mT__24()
    {

    		try
    		{
    		int _type = T__24;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:11:7: ( 'while' )
    		DebugEnterAlt(1);
    		// Lua.g:11:9: 'while'
    		{
    		DebugLocation(11, 9);
    		Match("while"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__24"

    protected virtual void Enter_T__25() {}
    protected virtual void Leave_T__25() {}

    // $ANTLR start "T__25"
    [GrammarRule("T__25")]
    private void mT__25()
    {

    		try
    		{
    		int _type = T__25;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:12:7: ( 'repeat' )
    		DebugEnterAlt(1);
    		// Lua.g:12:9: 'repeat'
    		{
    		DebugLocation(12, 9);
    		Match("repeat"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__25"

    protected virtual void Enter_T__26() {}
    protected virtual void Leave_T__26() {}

    // $ANTLR start "T__26"
    [GrammarRule("T__26")]
    private void mT__26()
    {

    		try
    		{
    		int _type = T__26;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:13:7: ( 'until' )
    		DebugEnterAlt(1);
    		// Lua.g:13:9: 'until'
    		{
    		DebugLocation(13, 9);
    		Match("until"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__26"

    protected virtual void Enter_T__27() {}
    protected virtual void Leave_T__27() {}

    // $ANTLR start "T__27"
    [GrammarRule("T__27")]
    private void mT__27()
    {

    		try
    		{
    		int _type = T__27;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:14:7: ( 'if' )
    		DebugEnterAlt(1);
    		// Lua.g:14:9: 'if'
    		{
    		DebugLocation(14, 9);
    		Match("if"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__27"

    protected virtual void Enter_T__28() {}
    protected virtual void Leave_T__28() {}

    // $ANTLR start "T__28"
    [GrammarRule("T__28")]
    private void mT__28()
    {

    		try
    		{
    		int _type = T__28;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:15:7: ( 'then' )
    		DebugEnterAlt(1);
    		// Lua.g:15:9: 'then'
    		{
    		DebugLocation(15, 9);
    		Match("then"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__28"

    protected virtual void Enter_T__29() {}
    protected virtual void Leave_T__29() {}

    // $ANTLR start "T__29"
    [GrammarRule("T__29")]
    private void mT__29()
    {

    		try
    		{
    		int _type = T__29;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:16:7: ( 'elseif' )
    		DebugEnterAlt(1);
    		// Lua.g:16:9: 'elseif'
    		{
    		DebugLocation(16, 9);
    		Match("elseif"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__29"

    protected virtual void Enter_T__30() {}
    protected virtual void Leave_T__30() {}

    // $ANTLR start "T__30"
    [GrammarRule("T__30")]
    private void mT__30()
    {

    		try
    		{
    		int _type = T__30;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:17:7: ( 'else' )
    		DebugEnterAlt(1);
    		// Lua.g:17:9: 'else'
    		{
    		DebugLocation(17, 9);
    		Match("else"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__30"

    protected virtual void Enter_T__31() {}
    protected virtual void Leave_T__31() {}

    // $ANTLR start "T__31"
    [GrammarRule("T__31")]
    private void mT__31()
    {

    		try
    		{
    		int _type = T__31;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:18:7: ( 'for' )
    		DebugEnterAlt(1);
    		// Lua.g:18:9: 'for'
    		{
    		DebugLocation(18, 9);
    		Match("for"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__31"

    protected virtual void Enter_T__32() {}
    protected virtual void Leave_T__32() {}

    // $ANTLR start "T__32"
    [GrammarRule("T__32")]
    private void mT__32()
    {

    		try
    		{
    		int _type = T__32;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:19:7: ( ',' )
    		DebugEnterAlt(1);
    		// Lua.g:19:9: ','
    		{
    		DebugLocation(19, 9);
    		Match(','); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__32"

    protected virtual void Enter_T__33() {}
    protected virtual void Leave_T__33() {}

    // $ANTLR start "T__33"
    [GrammarRule("T__33")]
    private void mT__33()
    {

    		try
    		{
    		int _type = T__33;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:20:7: ( 'in' )
    		DebugEnterAlt(1);
    		// Lua.g:20:9: 'in'
    		{
    		DebugLocation(20, 9);
    		Match("in"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__33"

    protected virtual void Enter_T__34() {}
    protected virtual void Leave_T__34() {}

    // $ANTLR start "T__34"
    [GrammarRule("T__34")]
    private void mT__34()
    {

    		try
    		{
    		int _type = T__34;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:21:7: ( 'function' )
    		DebugEnterAlt(1);
    		// Lua.g:21:9: 'function'
    		{
    		DebugLocation(21, 9);
    		Match("function"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__34"

    protected virtual void Enter_T__35() {}
    protected virtual void Leave_T__35() {}

    // $ANTLR start "T__35"
    [GrammarRule("T__35")]
    private void mT__35()
    {

    		try
    		{
    		int _type = T__35;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:22:7: ( 'local' )
    		DebugEnterAlt(1);
    		// Lua.g:22:9: 'local'
    		{
    		DebugLocation(22, 9);
    		Match("local"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__35"

    protected virtual void Enter_T__36() {}
    protected virtual void Leave_T__36() {}

    // $ANTLR start "T__36"
    [GrammarRule("T__36")]
    private void mT__36()
    {

    		try
    		{
    		int _type = T__36;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:23:7: ( 'return' )
    		DebugEnterAlt(1);
    		// Lua.g:23:9: 'return'
    		{
    		DebugLocation(23, 9);
    		Match("return"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__36"

    protected virtual void Enter_T__37() {}
    protected virtual void Leave_T__37() {}

    // $ANTLR start "T__37"
    [GrammarRule("T__37")]
    private void mT__37()
    {

    		try
    		{
    		int _type = T__37;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:24:7: ( 'break' )
    		DebugEnterAlt(1);
    		// Lua.g:24:9: 'break'
    		{
    		DebugLocation(24, 9);
    		Match("break"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__37"

    protected virtual void Enter_T__38() {}
    protected virtual void Leave_T__38() {}

    // $ANTLR start "T__38"
    [GrammarRule("T__38")]
    private void mT__38()
    {

    		try
    		{
    		int _type = T__38;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:25:7: ( '.' )
    		DebugEnterAlt(1);
    		// Lua.g:25:9: '.'
    		{
    		DebugLocation(25, 9);
    		Match('.'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__38"

    protected virtual void Enter_T__39() {}
    protected virtual void Leave_T__39() {}

    // $ANTLR start "T__39"
    [GrammarRule("T__39")]
    private void mT__39()
    {

    		try
    		{
    		int _type = T__39;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:26:7: ( ':' )
    		DebugEnterAlt(1);
    		// Lua.g:26:9: ':'
    		{
    		DebugLocation(26, 9);
    		Match(':'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__39"

    protected virtual void Enter_T__40() {}
    protected virtual void Leave_T__40() {}

    // $ANTLR start "T__40"
    [GrammarRule("T__40")]
    private void mT__40()
    {

    		try
    		{
    		int _type = T__40;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:27:7: ( 'nil' )
    		DebugEnterAlt(1);
    		// Lua.g:27:9: 'nil'
    		{
    		DebugLocation(27, 9);
    		Match("nil"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__40"

    protected virtual void Enter_T__41() {}
    protected virtual void Leave_T__41() {}

    // $ANTLR start "T__41"
    [GrammarRule("T__41")]
    private void mT__41()
    {

    		try
    		{
    		int _type = T__41;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:28:7: ( 'false' )
    		DebugEnterAlt(1);
    		// Lua.g:28:9: 'false'
    		{
    		DebugLocation(28, 9);
    		Match("false"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__41"

    protected virtual void Enter_T__42() {}
    protected virtual void Leave_T__42() {}

    // $ANTLR start "T__42"
    [GrammarRule("T__42")]
    private void mT__42()
    {

    		try
    		{
    		int _type = T__42;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:29:7: ( 'true' )
    		DebugEnterAlt(1);
    		// Lua.g:29:9: 'true'
    		{
    		DebugLocation(29, 9);
    		Match("true"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__42"

    protected virtual void Enter_T__43() {}
    protected virtual void Leave_T__43() {}

    // $ANTLR start "T__43"
    [GrammarRule("T__43")]
    private void mT__43()
    {

    		try
    		{
    		int _type = T__43;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:30:7: ( '...' )
    		DebugEnterAlt(1);
    		// Lua.g:30:9: '...'
    		{
    		DebugLocation(30, 9);
    		Match("..."); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__43"

    protected virtual void Enter_T__44() {}
    protected virtual void Leave_T__44() {}

    // $ANTLR start "T__44"
    [GrammarRule("T__44")]
    private void mT__44()
    {

    		try
    		{
    		int _type = T__44;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:31:7: ( '(' )
    		DebugEnterAlt(1);
    		// Lua.g:31:9: '('
    		{
    		DebugLocation(31, 9);
    		Match('('); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__44"

    protected virtual void Enter_T__45() {}
    protected virtual void Leave_T__45() {}

    // $ANTLR start "T__45"
    [GrammarRule("T__45")]
    private void mT__45()
    {

    		try
    		{
    		int _type = T__45;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:32:7: ( ')' )
    		DebugEnterAlt(1);
    		// Lua.g:32:9: ')'
    		{
    		DebugLocation(32, 9);
    		Match(')'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__45"

    protected virtual void Enter_T__46() {}
    protected virtual void Leave_T__46() {}

    // $ANTLR start "T__46"
    [GrammarRule("T__46")]
    private void mT__46()
    {

    		try
    		{
    		int _type = T__46;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:33:7: ( '[' )
    		DebugEnterAlt(1);
    		// Lua.g:33:9: '['
    		{
    		DebugLocation(33, 9);
    		Match('['); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__46"

    protected virtual void Enter_T__47() {}
    protected virtual void Leave_T__47() {}

    // $ANTLR start "T__47"
    [GrammarRule("T__47")]
    private void mT__47()
    {

    		try
    		{
    		int _type = T__47;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:34:7: ( ']' )
    		DebugEnterAlt(1);
    		// Lua.g:34:9: ']'
    		{
    		DebugLocation(34, 9);
    		Match(']'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__47"

    protected virtual void Enter_T__48() {}
    protected virtual void Leave_T__48() {}

    // $ANTLR start "T__48"
    [GrammarRule("T__48")]
    private void mT__48()
    {

    		try
    		{
    		int _type = T__48;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:35:7: ( '{' )
    		DebugEnterAlt(1);
    		// Lua.g:35:9: '{'
    		{
    		DebugLocation(35, 9);
    		Match('{'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__48"

    protected virtual void Enter_T__49() {}
    protected virtual void Leave_T__49() {}

    // $ANTLR start "T__49"
    [GrammarRule("T__49")]
    private void mT__49()
    {

    		try
    		{
    		int _type = T__49;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:36:7: ( '}' )
    		DebugEnterAlt(1);
    		// Lua.g:36:9: '}'
    		{
    		DebugLocation(36, 9);
    		Match('}'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__49"

    protected virtual void Enter_T__50() {}
    protected virtual void Leave_T__50() {}

    // $ANTLR start "T__50"
    [GrammarRule("T__50")]
    private void mT__50()
    {

    		try
    		{
    		int _type = T__50;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:37:7: ( '+' )
    		DebugEnterAlt(1);
    		// Lua.g:37:9: '+'
    		{
    		DebugLocation(37, 9);
    		Match('+'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__50"

    protected virtual void Enter_T__51() {}
    protected virtual void Leave_T__51() {}

    // $ANTLR start "T__51"
    [GrammarRule("T__51")]
    private void mT__51()
    {

    		try
    		{
    		int _type = T__51;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:38:7: ( '-' )
    		DebugEnterAlt(1);
    		// Lua.g:38:9: '-'
    		{
    		DebugLocation(38, 9);
    		Match('-'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__51"

    protected virtual void Enter_T__52() {}
    protected virtual void Leave_T__52() {}

    // $ANTLR start "T__52"
    [GrammarRule("T__52")]
    private void mT__52()
    {

    		try
    		{
    		int _type = T__52;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:39:7: ( '*' )
    		DebugEnterAlt(1);
    		// Lua.g:39:9: '*'
    		{
    		DebugLocation(39, 9);
    		Match('*'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__52"

    protected virtual void Enter_T__53() {}
    protected virtual void Leave_T__53() {}

    // $ANTLR start "T__53"
    [GrammarRule("T__53")]
    private void mT__53()
    {

    		try
    		{
    		int _type = T__53;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:40:7: ( '/' )
    		DebugEnterAlt(1);
    		// Lua.g:40:9: '/'
    		{
    		DebugLocation(40, 9);
    		Match('/'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__53"

    protected virtual void Enter_T__54() {}
    protected virtual void Leave_T__54() {}

    // $ANTLR start "T__54"
    [GrammarRule("T__54")]
    private void mT__54()
    {

    		try
    		{
    		int _type = T__54;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:41:7: ( '^' )
    		DebugEnterAlt(1);
    		// Lua.g:41:9: '^'
    		{
    		DebugLocation(41, 9);
    		Match('^'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__54"

    protected virtual void Enter_T__55() {}
    protected virtual void Leave_T__55() {}

    // $ANTLR start "T__55"
    [GrammarRule("T__55")]
    private void mT__55()
    {

    		try
    		{
    		int _type = T__55;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:42:7: ( '%' )
    		DebugEnterAlt(1);
    		// Lua.g:42:9: '%'
    		{
    		DebugLocation(42, 9);
    		Match('%'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__55"

    protected virtual void Enter_T__56() {}
    protected virtual void Leave_T__56() {}

    // $ANTLR start "T__56"
    [GrammarRule("T__56")]
    private void mT__56()
    {

    		try
    		{
    		int _type = T__56;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:43:7: ( '..' )
    		DebugEnterAlt(1);
    		// Lua.g:43:9: '..'
    		{
    		DebugLocation(43, 9);
    		Match(".."); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__56"

    protected virtual void Enter_T__57() {}
    protected virtual void Leave_T__57() {}

    // $ANTLR start "T__57"
    [GrammarRule("T__57")]
    private void mT__57()
    {

    		try
    		{
    		int _type = T__57;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:44:7: ( '<' )
    		DebugEnterAlt(1);
    		// Lua.g:44:9: '<'
    		{
    		DebugLocation(44, 9);
    		Match('<'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__57"

    protected virtual void Enter_T__58() {}
    protected virtual void Leave_T__58() {}

    // $ANTLR start "T__58"
    [GrammarRule("T__58")]
    private void mT__58()
    {

    		try
    		{
    		int _type = T__58;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:45:7: ( '<=' )
    		DebugEnterAlt(1);
    		// Lua.g:45:9: '<='
    		{
    		DebugLocation(45, 9);
    		Match("<="); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__58"

    protected virtual void Enter_T__59() {}
    protected virtual void Leave_T__59() {}

    // $ANTLR start "T__59"
    [GrammarRule("T__59")]
    private void mT__59()
    {

    		try
    		{
    		int _type = T__59;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:46:7: ( '>' )
    		DebugEnterAlt(1);
    		// Lua.g:46:9: '>'
    		{
    		DebugLocation(46, 9);
    		Match('>'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__59"

    protected virtual void Enter_T__60() {}
    protected virtual void Leave_T__60() {}

    // $ANTLR start "T__60"
    [GrammarRule("T__60")]
    private void mT__60()
    {

    		try
    		{
    		int _type = T__60;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:47:7: ( '>=' )
    		DebugEnterAlt(1);
    		// Lua.g:47:9: '>='
    		{
    		DebugLocation(47, 9);
    		Match(">="); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__60"

    protected virtual void Enter_T__61() {}
    protected virtual void Leave_T__61() {}

    // $ANTLR start "T__61"
    [GrammarRule("T__61")]
    private void mT__61()
    {

    		try
    		{
    		int _type = T__61;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:48:7: ( '==' )
    		DebugEnterAlt(1);
    		// Lua.g:48:9: '=='
    		{
    		DebugLocation(48, 9);
    		Match("=="); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__61"

    protected virtual void Enter_T__62() {}
    protected virtual void Leave_T__62() {}

    // $ANTLR start "T__62"
    [GrammarRule("T__62")]
    private void mT__62()
    {

    		try
    		{
    		int _type = T__62;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:49:7: ( '~=' )
    		DebugEnterAlt(1);
    		// Lua.g:49:9: '~='
    		{
    		DebugLocation(49, 9);
    		Match("~="); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__62"

    protected virtual void Enter_T__63() {}
    protected virtual void Leave_T__63() {}

    // $ANTLR start "T__63"
    [GrammarRule("T__63")]
    private void mT__63()
    {

    		try
    		{
    		int _type = T__63;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:50:7: ( 'and' )
    		DebugEnterAlt(1);
    		// Lua.g:50:9: 'and'
    		{
    		DebugLocation(50, 9);
    		Match("and"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__63"

    protected virtual void Enter_T__64() {}
    protected virtual void Leave_T__64() {}

    // $ANTLR start "T__64"
    [GrammarRule("T__64")]
    private void mT__64()
    {

    		try
    		{
    		int _type = T__64;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:51:7: ( 'or' )
    		DebugEnterAlt(1);
    		// Lua.g:51:9: 'or'
    		{
    		DebugLocation(51, 9);
    		Match("or"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__64"

    protected virtual void Enter_T__65() {}
    protected virtual void Leave_T__65() {}

    // $ANTLR start "T__65"
    [GrammarRule("T__65")]
    private void mT__65()
    {

    		try
    		{
    		int _type = T__65;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:52:7: ( 'not' )
    		DebugEnterAlt(1);
    		// Lua.g:52:9: 'not'
    		{
    		DebugLocation(52, 9);
    		Match("not"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__65"

    protected virtual void Enter_T__66() {}
    protected virtual void Leave_T__66() {}

    // $ANTLR start "T__66"
    [GrammarRule("T__66")]
    private void mT__66()
    {

    		try
    		{
    		int _type = T__66;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:53:7: ( '#' )
    		DebugEnterAlt(1);
    		// Lua.g:53:9: '#'
    		{
    		DebugLocation(53, 9);
    		Match('#'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "T__66"

    protected virtual void Enter_NAME() {}
    protected virtual void Leave_NAME() {}

    // $ANTLR start "NAME"
    [GrammarRule("NAME")]
    private void mNAME()
    {

    		try
    		{
    		int _type = NAME;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:101:6: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
    		DebugEnterAlt(1);
    		// Lua.g:101:7: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
    		{
    		DebugLocation(101, 7);
    		if ((input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
    		{
    			input.Consume();

    		}
    		else
    		{
    			MismatchedSetException mse = new MismatchedSetException(null,input);
    			DebugRecognitionException(mse);
    			Recover(mse);
    			throw mse;}

    		DebugLocation(101, 30);
    		// Lua.g:101:30: ( options {greedy=true; } : 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
    		try { DebugEnterSubRule(1);
    		while (true)
    		{
    			int alt1=5;
    			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
    			switch (input.LA(1))
    			{
    			case 'a':
    			case 'b':
    			case 'c':
    			case 'd':
    			case 'e':
    			case 'f':
    			case 'g':
    			case 'h':
    			case 'i':
    			case 'j':
    			case 'k':
    			case 'l':
    			case 'm':
    			case 'n':
    			case 'o':
    			case 'p':
    			case 'q':
    			case 'r':
    			case 's':
    			case 't':
    			case 'u':
    			case 'v':
    			case 'w':
    			case 'x':
    			case 'y':
    			case 'z':
    				{
    				alt1=1;
    				}
    				break;
    			case 'A':
    			case 'B':
    			case 'C':
    			case 'D':
    			case 'E':
    			case 'F':
    			case 'G':
    			case 'H':
    			case 'I':
    			case 'J':
    			case 'K':
    			case 'L':
    			case 'M':
    			case 'N':
    			case 'O':
    			case 'P':
    			case 'Q':
    			case 'R':
    			case 'S':
    			case 'T':
    			case 'U':
    			case 'V':
    			case 'W':
    			case 'X':
    			case 'Y':
    			case 'Z':
    				{
    				alt1=2;
    				}
    				break;
    			case '_':
    				{
    				alt1=3;
    				}
    				break;
    			case '0':
    			case '1':
    			case '2':
    			case '3':
    			case '4':
    			case '5':
    			case '6':
    			case '7':
    			case '8':
    			case '9':
    				{
    				alt1=4;
    				}
    				break;

    			}

    			} finally { DebugExitDecision(1); }
    			switch ( alt1 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:101:54: 'a' .. 'z'
    				{
    				DebugLocation(101, 54);
    				MatchRange('a','z'); 

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Lua.g:101:63: 'A' .. 'Z'
    				{
    				DebugLocation(101, 63);
    				MatchRange('A','Z'); 

    				}
    				break;
    			case 3:
    				DebugEnterAlt(3);
    				// Lua.g:101:72: '_'
    				{
    				DebugLocation(101, 72);
    				Match('_'); 

    				}
    				break;
    			case 4:
    				DebugEnterAlt(4);
    				// Lua.g:101:76: '0' .. '9'
    				{
    				DebugLocation(101, 76);
    				MatchRange('0','9'); 

    				}
    				break;

    			default:
    				goto loop1;
    			}
    		}

    		loop1:
    			;

    		} finally { DebugExitSubRule(1); }


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "NAME"

    protected virtual void Enter_INT() {}
    protected virtual void Leave_INT() {}

    // $ANTLR start "INT"
    [GrammarRule("INT")]
    private void mINT()
    {

    		try
    		{
    		int _type = INT;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:104:5: ( ( '0' .. '9' )+ )
    		DebugEnterAlt(1);
    		// Lua.g:104:7: ( '0' .. '9' )+
    		{
    		DebugLocation(104, 7);
    		// Lua.g:104:7: ( '0' .. '9' )+
    		int cnt2=0;
    		try { DebugEnterSubRule(2);
    		while (true)
    		{
    			int alt2=2;
    			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
    			int LA2_0 = input.LA(1);

    			if (((LA2_0>='0' && LA2_0<='9')))
    			{
    				alt2=1;
    			}


    			} finally { DebugExitDecision(2); }
    			switch (alt2)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:104:8: '0' .. '9'
    				{
    				DebugLocation(104, 8);
    				MatchRange('0','9'); 

    				}
    				break;

    			default:
    				if (cnt2 >= 1)
    					goto loop2;

    				EarlyExitException eee2 = new EarlyExitException( 2, input );
    				DebugRecognitionException(eee2);
    				throw eee2;
    			}
    			cnt2++;
    		}
    		loop2:
    			;

    		} finally { DebugExitSubRule(2); }


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "INT"

    protected virtual void Enter_FLOAT() {}
    protected virtual void Leave_FLOAT() {}

    // $ANTLR start "FLOAT"
    [GrammarRule("FLOAT")]
    private void mFLOAT()
    {

    		try
    		{
    		int _type = FLOAT;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:106:8: ( INT '.' INT )
    		DebugEnterAlt(1);
    		// Lua.g:106:9: INT '.' INT
    		{
    		DebugLocation(106, 9);
    		mINT(); 
    		DebugLocation(106, 13);
    		Match('.'); 
    		DebugLocation(106, 17);
    		mINT(); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "FLOAT"

    protected virtual void Enter_EXP() {}
    protected virtual void Leave_EXP() {}

    // $ANTLR start "EXP"
    [GrammarRule("EXP")]
    private void mEXP()
    {

    		try
    		{
    		int _type = EXP;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:108:5: ( ( INT | FLOAT ) ( 'E' | 'e' ) ( '-' )? INT )
    		DebugEnterAlt(1);
    		// Lua.g:108:7: ( INT | FLOAT ) ( 'E' | 'e' ) ( '-' )? INT
    		{
    		DebugLocation(108, 7);
    		// Lua.g:108:7: ( INT | FLOAT )
    		int alt3=2;
    		try { DebugEnterSubRule(3);
    		try { DebugEnterDecision(3, decisionCanBacktrack[3]);
    		try
    		{
    			alt3 = dfa3.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(3); }
    		switch (alt3)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:108:8: INT
    			{
    			DebugLocation(108, 8);
    			mINT(); 

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:108:13: FLOAT
    			{
    			DebugLocation(108, 13);
    			mFLOAT(); 

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(3); }

    		DebugLocation(108, 20);
    		if (input.LA(1)=='E'||input.LA(1)=='e')
    		{
    			input.Consume();

    		}
    		else
    		{
    			MismatchedSetException mse = new MismatchedSetException(null,input);
    			DebugRecognitionException(mse);
    			Recover(mse);
    			throw mse;}

    		DebugLocation(108, 30);
    		// Lua.g:108:30: ( '-' )?
    		int alt4=2;
    		try { DebugEnterSubRule(4);
    		try { DebugEnterDecision(4, decisionCanBacktrack[4]);
    		int LA4_0 = input.LA(1);

    		if ((LA4_0=='-'))
    		{
    			alt4=1;
    		}
    		} finally { DebugExitDecision(4); }
    		switch (alt4)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:108:31: '-'
    			{
    			DebugLocation(108, 31);
    			Match('-'); 

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(4); }

    		DebugLocation(108, 37);
    		mINT(); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "EXP"

    protected virtual void Enter_HEX() {}
    protected virtual void Leave_HEX() {}

    // $ANTLR start "HEX"
    [GrammarRule("HEX")]
    private void mHEX()
    {

    		try
    		{
    		int _type = HEX;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:110:5: ( '0x' ( '0' .. '9' | 'a' .. 'f' )+ )
    		DebugEnterAlt(1);
    		// Lua.g:110:6: '0x' ( '0' .. '9' | 'a' .. 'f' )+
    		{
    		DebugLocation(110, 6);
    		Match("0x"); 

    		DebugLocation(110, 11);
    		// Lua.g:110:11: ( '0' .. '9' | 'a' .. 'f' )+
    		int cnt5=0;
    		try { DebugEnterSubRule(5);
    		while (true)
    		{
    			int alt5=2;
    			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
    			int LA5_0 = input.LA(1);

    			if (((LA5_0>='0' && LA5_0<='9')||(LA5_0>='a' && LA5_0<='f')))
    			{
    				alt5=1;
    			}


    			} finally { DebugExitDecision(5); }
    			switch (alt5)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:
    				{
    				DebugLocation(110, 11);
    				if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='a' && input.LA(1)<='f'))
    				{
    					input.Consume();

    				}
    				else
    				{
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					Recover(mse);
    					throw mse;}


    				}
    				break;

    			default:
    				if (cnt5 >= 1)
    					goto loop5;

    				EarlyExitException eee5 = new EarlyExitException( 5, input );
    				DebugRecognitionException(eee5);
    				throw eee5;
    			}
    			cnt5++;
    		}
    		loop5:
    			;

    		} finally { DebugExitSubRule(5); }


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "HEX"

    protected virtual void Enter_NORMALSTRING() {}
    protected virtual void Leave_NORMALSTRING() {}

    // $ANTLR start "NORMALSTRING"
    [GrammarRule("NORMALSTRING")]
    private void mNORMALSTRING()
    {

    		try
    		{
    		int _type = NORMALSTRING;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:115:5: ( '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"' )
    		DebugEnterAlt(1);
    		// Lua.g:115:8: '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"'
    		{
    		DebugLocation(115, 8);
    		Match('\"'); 
    		DebugLocation(115, 12);
    		// Lua.g:115:12: ( EscapeSequence | ~ ( '\\\\' | '\"' ) )*
    		try { DebugEnterSubRule(6);
    		while (true)
    		{
    			int alt6=3;
    			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
    			int LA6_0 = input.LA(1);

    			if ((LA6_0=='\\'))
    			{
    				alt6=1;
    			}
    			else if (((LA6_0>='\u0000' && LA6_0<='!')||(LA6_0>='#' && LA6_0<='[')||(LA6_0>=']' && LA6_0<='\uFFFF')))
    			{
    				alt6=2;
    			}


    			} finally { DebugExitDecision(6); }
    			switch ( alt6 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:115:14: EscapeSequence
    				{
    				DebugLocation(115, 14);
    				mEscapeSequence(); 

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Lua.g:115:31: ~ ( '\\\\' | '\"' )
    				{
    				DebugLocation(115, 31);
    				if ((input.LA(1)>='\u0000' && input.LA(1)<='!')||(input.LA(1)>='#' && input.LA(1)<='[')||(input.LA(1)>=']' && input.LA(1)<='\uFFFF'))
    				{
    					input.Consume();

    				}
    				else
    				{
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					Recover(mse);
    					throw mse;}


    				}
    				break;

    			default:
    				goto loop6;
    			}
    		}

    		loop6:
    			;

    		} finally { DebugExitSubRule(6); }

    		DebugLocation(115, 46);
    		Match('\"'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "NORMALSTRING"

    protected virtual void Enter_CHARSTRING() {}
    protected virtual void Leave_CHARSTRING() {}

    // $ANTLR start "CHARSTRING"
    [GrammarRule("CHARSTRING")]
    private void mCHARSTRING()
    {

    		try
    		{
    		int _type = CHARSTRING;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:119:4: ( '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )* '\\'' )
    		DebugEnterAlt(1);
    		// Lua.g:119:6: '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )* '\\''
    		{
    		DebugLocation(119, 6);
    		Match('\''); 
    		DebugLocation(119, 11);
    		// Lua.g:119:11: ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )*
    		try { DebugEnterSubRule(7);
    		while (true)
    		{
    			int alt7=3;
    			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
    			int LA7_0 = input.LA(1);

    			if ((LA7_0=='\\'))
    			{
    				alt7=1;
    			}
    			else if (((LA7_0>='\u0000' && LA7_0<='&')||(LA7_0>='(' && LA7_0<='[')||(LA7_0>=']' && LA7_0<='\uFFFF')))
    			{
    				alt7=2;
    			}


    			} finally { DebugExitDecision(7); }
    			switch ( alt7 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:119:13: EscapeSequence
    				{
    				DebugLocation(119, 13);
    				mEscapeSequence(); 

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Lua.g:119:30: ~ ( '\\'' | '\\\\' )
    				{
    				DebugLocation(119, 30);
    				if ((input.LA(1)>='\u0000' && input.LA(1)<='&')||(input.LA(1)>='(' && input.LA(1)<='[')||(input.LA(1)>=']' && input.LA(1)<='\uFFFF'))
    				{
    					input.Consume();

    				}
    				else
    				{
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					Recover(mse);
    					throw mse;}


    				}
    				break;

    			default:
    				goto loop7;
    			}
    		}

    		loop7:
    			;

    		} finally { DebugExitSubRule(7); }

    		DebugLocation(119, 46);
    		Match('\''); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "CHARSTRING"

    protected virtual void Enter_LONGSTRING() {}
    protected virtual void Leave_LONGSTRING() {}

    // $ANTLR start "LONGSTRING"
    [GrammarRule("LONGSTRING")]
    private void mLONGSTRING()
    {

    		try
    		{
    		int _type = LONGSTRING;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:123:2: ( '[' ( '=' )* '[' ( EscapeSequence | ~ ( '\\\\' | ']' ) )* ']' ( '=' )* ']' )
    		DebugEnterAlt(1);
    		// Lua.g:123:4: '[' ( '=' )* '[' ( EscapeSequence | ~ ( '\\\\' | ']' ) )* ']' ( '=' )* ']'
    		{
    		DebugLocation(123, 4);
    		Match('['); 
    		DebugLocation(123, 7);
    		// Lua.g:123:7: ( '=' )*
    		try { DebugEnterSubRule(8);
    		while (true)
    		{
    			int alt8=2;
    			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
    			int LA8_0 = input.LA(1);

    			if ((LA8_0=='='))
    			{
    				alt8=1;
    			}


    			} finally { DebugExitDecision(8); }
    			switch ( alt8 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:123:8: '='
    				{
    				DebugLocation(123, 8);
    				Match('='); 

    				}
    				break;

    			default:
    				goto loop8;
    			}
    		}

    		loop8:
    			;

    		} finally { DebugExitSubRule(8); }

    		DebugLocation(123, 13);
    		Match('['); 
    		DebugLocation(123, 17);
    		// Lua.g:123:17: ( EscapeSequence | ~ ( '\\\\' | ']' ) )*
    		try { DebugEnterSubRule(9);
    		while (true)
    		{
    			int alt9=3;
    			try { DebugEnterDecision(9, decisionCanBacktrack[9]);
    			int LA9_0 = input.LA(1);

    			if ((LA9_0=='\\'))
    			{
    				alt9=1;
    			}
    			else if (((LA9_0>='\u0000' && LA9_0<='[')||(LA9_0>='^' && LA9_0<='\uFFFF')))
    			{
    				alt9=2;
    			}


    			} finally { DebugExitDecision(9); }
    			switch ( alt9 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:123:19: EscapeSequence
    				{
    				DebugLocation(123, 19);
    				mEscapeSequence(); 

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Lua.g:123:36: ~ ( '\\\\' | ']' )
    				{
    				DebugLocation(123, 36);
    				if ((input.LA(1)>='\u0000' && input.LA(1)<='[')||(input.LA(1)>='^' && input.LA(1)<='\uFFFF'))
    				{
    					input.Consume();

    				}
    				else
    				{
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					Recover(mse);
    					throw mse;}


    				}
    				break;

    			default:
    				goto loop9;
    			}
    		}

    		loop9:
    			;

    		} finally { DebugExitSubRule(9); }

    		DebugLocation(123, 51);
    		Match(']'); 
    		DebugLocation(123, 54);
    		// Lua.g:123:54: ( '=' )*
    		try { DebugEnterSubRule(10);
    		while (true)
    		{
    			int alt10=2;
    			try { DebugEnterDecision(10, decisionCanBacktrack[10]);
    			int LA10_0 = input.LA(1);

    			if ((LA10_0=='='))
    			{
    				alt10=1;
    			}


    			} finally { DebugExitDecision(10); }
    			switch ( alt10 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:123:55: '='
    				{
    				DebugLocation(123, 55);
    				Match('='); 

    				}
    				break;

    			default:
    				goto loop10;
    			}
    		}

    		loop10:
    			;

    		} finally { DebugExitSubRule(10); }

    		DebugLocation(123, 60);
    		Match(']'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "LONGSTRING"

    protected virtual void Enter_EscapeSequence() {}
    protected virtual void Leave_EscapeSequence() {}

    // $ANTLR start "EscapeSequence"
    [GrammarRule("EscapeSequence")]
    private void mEscapeSequence()
    {

    		try
    		{
    		// Lua.g:128:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) | UnicodeEscape | OctalEscape )
    		int alt11=3;
    		try { DebugEnterDecision(11, decisionCanBacktrack[11]);
    		int LA11_0 = input.LA(1);

    		if ((LA11_0=='\\'))
    		{
    			switch (input.LA(2))
    			{
    			case '\"':
    			case '\'':
    			case '\\':
    			case 'b':
    			case 'f':
    			case 'n':
    			case 'r':
    			case 't':
    				{
    				alt11=1;
    				}
    				break;
    			case 'u':
    				{
    				alt11=2;
    				}
    				break;
    			case '0':
    			case '1':
    			case '2':
    			case '3':
    			case '4':
    			case '5':
    			case '6':
    			case '7':
    				{
    				alt11=3;
    				}
    				break;
    			default:
    				{
    					NoViableAltException nvae = new NoViableAltException("", 11, 1, input);

    					DebugRecognitionException(nvae);
    					throw nvae;
    				}
    			}

    		}
    		else
    		{
    			NoViableAltException nvae = new NoViableAltException("", 11, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(11); }
    		switch (alt11)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:128:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
    			{
    			DebugLocation(128, 9);
    			Match('\\'); 
    			DebugLocation(128, 14);
    			if (input.LA(1)=='\"'||input.LA(1)=='\''||input.LA(1)=='\\'||input.LA(1)=='b'||input.LA(1)=='f'||input.LA(1)=='n'||input.LA(1)=='r'||input.LA(1)=='t')
    			{
    				input.Consume();

    			}
    			else
    			{
    				MismatchedSetException mse = new MismatchedSetException(null,input);
    				DebugRecognitionException(mse);
    				Recover(mse);
    				throw mse;}


    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:129:9: UnicodeEscape
    			{
    			DebugLocation(129, 9);
    			mUnicodeEscape(); 

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Lua.g:130:9: OctalEscape
    			{
    			DebugLocation(130, 9);
    			mOctalEscape(); 

    			}
    			break;

    		}
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "EscapeSequence"

    protected virtual void Enter_OctalEscape() {}
    protected virtual void Leave_OctalEscape() {}

    // $ANTLR start "OctalEscape"
    [GrammarRule("OctalEscape")]
    private void mOctalEscape()
    {

    		try
    		{
    		// Lua.g:135:5: ( '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) )
    		int alt12=3;
    		try { DebugEnterDecision(12, decisionCanBacktrack[12]);
    		int LA12_0 = input.LA(1);

    		if ((LA12_0=='\\'))
    		{
    			int LA12_1 = input.LA(2);

    			if (((LA12_1>='0' && LA12_1<='3')))
    			{
    				int LA12_2 = input.LA(3);

    				if (((LA12_2>='0' && LA12_2<='7')))
    				{
    					int LA12_4 = input.LA(4);

    					if (((LA12_4>='0' && LA12_4<='7')))
    					{
    						alt12=1;
    					}
    					else
    					{
    						alt12=2;}
    				}
    				else
    				{
    					alt12=3;}
    			}
    			else if (((LA12_1>='4' && LA12_1<='7')))
    			{
    				int LA12_3 = input.LA(3);

    				if (((LA12_3>='0' && LA12_3<='7')))
    				{
    					alt12=2;
    				}
    				else
    				{
    					alt12=3;}
    			}
    			else
    			{
    				NoViableAltException nvae = new NoViableAltException("", 12, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			NoViableAltException nvae = new NoViableAltException("", 12, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(12); }
    		switch (alt12)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:135:9: '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' )
    			{
    			DebugLocation(135, 9);
    			Match('\\'); 
    			DebugLocation(135, 14);
    			// Lua.g:135:14: ( '0' .. '3' )
    			DebugEnterAlt(1);
    			// Lua.g:135:15: '0' .. '3'
    			{
    			DebugLocation(135, 15);
    			MatchRange('0','3'); 

    			}

    			DebugLocation(135, 25);
    			// Lua.g:135:25: ( '0' .. '7' )
    			DebugEnterAlt(1);
    			// Lua.g:135:26: '0' .. '7'
    			{
    			DebugLocation(135, 26);
    			MatchRange('0','7'); 

    			}

    			DebugLocation(135, 36);
    			// Lua.g:135:36: ( '0' .. '7' )
    			DebugEnterAlt(1);
    			// Lua.g:135:37: '0' .. '7'
    			{
    			DebugLocation(135, 37);
    			MatchRange('0','7'); 

    			}


    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Lua.g:136:9: '\\\\' ( '0' .. '7' ) ( '0' .. '7' )
    			{
    			DebugLocation(136, 9);
    			Match('\\'); 
    			DebugLocation(136, 14);
    			// Lua.g:136:14: ( '0' .. '7' )
    			DebugEnterAlt(1);
    			// Lua.g:136:15: '0' .. '7'
    			{
    			DebugLocation(136, 15);
    			MatchRange('0','7'); 

    			}

    			DebugLocation(136, 25);
    			// Lua.g:136:25: ( '0' .. '7' )
    			DebugEnterAlt(1);
    			// Lua.g:136:26: '0' .. '7'
    			{
    			DebugLocation(136, 26);
    			MatchRange('0','7'); 

    			}


    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Lua.g:137:9: '\\\\' ( '0' .. '7' )
    			{
    			DebugLocation(137, 9);
    			Match('\\'); 
    			DebugLocation(137, 14);
    			// Lua.g:137:14: ( '0' .. '7' )
    			DebugEnterAlt(1);
    			// Lua.g:137:15: '0' .. '7'
    			{
    			DebugLocation(137, 15);
    			MatchRange('0','7'); 

    			}


    			}
    			break;

    		}
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "OctalEscape"

    protected virtual void Enter_UnicodeEscape() {}
    protected virtual void Leave_UnicodeEscape() {}

    // $ANTLR start "UnicodeEscape"
    [GrammarRule("UnicodeEscape")]
    private void mUnicodeEscape()
    {

    		try
    		{
    		// Lua.g:142:5: ( '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit )
    		DebugEnterAlt(1);
    		// Lua.g:142:9: '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit
    		{
    		DebugLocation(142, 9);
    		Match('\\'); 
    		DebugLocation(142, 14);
    		Match('u'); 
    		DebugLocation(142, 18);
    		mHexDigit(); 
    		DebugLocation(142, 27);
    		mHexDigit(); 
    		DebugLocation(142, 36);
    		mHexDigit(); 
    		DebugLocation(142, 45);
    		mHexDigit(); 

    		}

    	}
    	finally
    	{
        }
    }
    // $ANTLR end "UnicodeEscape"

    protected virtual void Enter_HexDigit() {}
    protected virtual void Leave_HexDigit() {}

    // $ANTLR start "HexDigit"
    [GrammarRule("HexDigit")]
    private void mHexDigit()
    {

    		try
    		{
    		// Lua.g:146:10: ( ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' ) )
    		DebugEnterAlt(1);
    		// Lua.g:146:12: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )
    		{
    		DebugLocation(146, 12);
    		if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='F')||(input.LA(1)>='a' && input.LA(1)<='f'))
    		{
    			input.Consume();

    		}
    		else
    		{
    			MismatchedSetException mse = new MismatchedSetException(null,input);
    			DebugRecognitionException(mse);
    			Recover(mse);
    			throw mse;}


    		}

    	}
    	finally
    	{
        }
    }
    // $ANTLR end "HexDigit"

    protected virtual void Enter_COMMENT() {}
    protected virtual void Leave_COMMENT() {}

    // $ANTLR start "COMMENT"
    [GrammarRule("COMMENT")]
    private void mCOMMENT()
    {

    		try
    		{
    		int _type = COMMENT;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:150:5: ( '--[[' ( options {greedy=false; } : . )* ']]' )
    		DebugEnterAlt(1);
    		// Lua.g:150:9: '--[[' ( options {greedy=false; } : . )* ']]'
    		{
    		DebugLocation(150, 9);
    		Match("--[["); 

    		DebugLocation(150, 16);
    		// Lua.g:150:16: ( options {greedy=false; } : . )*
    		try { DebugEnterSubRule(13);
    		while (true)
    		{
    			int alt13=2;
    			try { DebugEnterDecision(13, decisionCanBacktrack[13]);
    			int LA13_0 = input.LA(1);

    			if ((LA13_0==']'))
    			{
    				int LA13_1 = input.LA(2);

    				if ((LA13_1==']'))
    				{
    					alt13=2;
    				}
    				else if (((LA13_1>='\u0000' && LA13_1<='\\')||(LA13_1>='^' && LA13_1<='\uFFFF')))
    				{
    					alt13=1;
    				}


    			}
    			else if (((LA13_0>='\u0000' && LA13_0<='\\')||(LA13_0>='^' && LA13_0<='\uFFFF')))
    			{
    				alt13=1;
    			}


    			} finally { DebugExitDecision(13); }
    			switch ( alt13 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:150:44: .
    				{
    				DebugLocation(150, 44);
    				MatchAny(); 

    				}
    				break;

    			default:
    				goto loop13;
    			}
    		}

    		loop13:
    			;

    		} finally { DebugExitSubRule(13); }

    		DebugLocation(150, 49);
    		Match("]]"); 

    		DebugLocation(150, 54);
    		Skip();

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "COMMENT"

    protected virtual void Enter_LINE_COMMENT() {}
    protected virtual void Leave_LINE_COMMENT() {}

    // $ANTLR start "LINE_COMMENT"
    [GrammarRule("LINE_COMMENT")]
    private void mLINE_COMMENT()
    {

    		try
    		{
    		int _type = LINE_COMMENT;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:154:5: ( '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
    		DebugEnterAlt(1);
    		// Lua.g:154:7: '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
    		{
    		DebugLocation(154, 7);
    		Match("--"); 

    		DebugLocation(154, 12);
    		// Lua.g:154:12: (~ ( '\\n' | '\\r' ) )*
    		try { DebugEnterSubRule(14);
    		while (true)
    		{
    			int alt14=2;
    			try { DebugEnterDecision(14, decisionCanBacktrack[14]);
    			int LA14_0 = input.LA(1);

    			if (((LA14_0>='\u0000' && LA14_0<='\t')||(LA14_0>='\u000B' && LA14_0<='\f')||(LA14_0>='\u000E' && LA14_0<='\uFFFF')))
    			{
    				alt14=1;
    			}


    			} finally { DebugExitDecision(14); }
    			switch ( alt14 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Lua.g:154:12: ~ ( '\\n' | '\\r' )
    				{
    				DebugLocation(154, 12);
    				if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='\uFFFF'))
    				{
    					input.Consume();

    				}
    				else
    				{
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					Recover(mse);
    					throw mse;}


    				}
    				break;

    			default:
    				goto loop14;
    			}
    		}

    		loop14:
    			;

    		} finally { DebugExitSubRule(14); }

    		DebugLocation(154, 26);
    		// Lua.g:154:26: ( '\\r' )?
    		int alt15=2;
    		try { DebugEnterSubRule(15);
    		try { DebugEnterDecision(15, decisionCanBacktrack[15]);
    		int LA15_0 = input.LA(1);

    		if ((LA15_0=='\r'))
    		{
    			alt15=1;
    		}
    		} finally { DebugExitDecision(15); }
    		switch (alt15)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:154:26: '\\r'
    			{
    			DebugLocation(154, 26);
    			Match('\r'); 

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(15); }

    		DebugLocation(154, 32);
    		Match('\n'); 
    		DebugLocation(154, 37);
    		Skip();

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "LINE_COMMENT"

    protected virtual void Enter_WS() {}
    protected virtual void Leave_WS() {}

    // $ANTLR start "WS"
    [GrammarRule("WS")]
    private void mWS()
    {

    		try
    		{
    		int _type = WS;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:158:5: ( ( ' ' | '\\t' | '\\u000C' ) )
    		DebugEnterAlt(1);
    		// Lua.g:158:8: ( ' ' | '\\t' | '\\u000C' )
    		{
    		DebugLocation(158, 8);
    		if (input.LA(1)=='\t'||input.LA(1)=='\f'||input.LA(1)==' ')
    		{
    			input.Consume();

    		}
    		else
    		{
    			MismatchedSetException mse = new MismatchedSetException(null,input);
    			DebugRecognitionException(mse);
    			Recover(mse);
    			throw mse;}

    		DebugLocation(158, 28);
    		Skip();

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "WS"

    protected virtual void Enter_NEWLINE() {}
    protected virtual void Leave_NEWLINE() {}

    // $ANTLR start "NEWLINE"
    [GrammarRule("NEWLINE")]
    private void mNEWLINE()
    {

    		try
    		{
    		int _type = NEWLINE;
    		int _channel = DefaultTokenChannel;
    		// Lua.g:161:9: ( ( '\\r' )? '\\n' )
    		DebugEnterAlt(1);
    		// Lua.g:161:11: ( '\\r' )? '\\n'
    		{
    		DebugLocation(161, 11);
    		// Lua.g:161:11: ( '\\r' )?
    		int alt16=2;
    		try { DebugEnterSubRule(16);
    		try { DebugEnterDecision(16, decisionCanBacktrack[16]);
    		int LA16_0 = input.LA(1);

    		if ((LA16_0=='\r'))
    		{
    			alt16=1;
    		}
    		} finally { DebugExitDecision(16); }
    		switch (alt16)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Lua.g:161:12: '\\r'
    			{
    			DebugLocation(161, 12);
    			Match('\r'); 

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(16); }

    		DebugLocation(161, 19);
    		Match('\n'); 
    		DebugLocation(161, 24);
    		Skip();

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
        }
    }
    // $ANTLR end "NEWLINE"

    public override void mTokens()
    {
    	// Lua.g:1:8: ( T__20 | T__21 | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | NAME | INT | FLOAT | EXP | HEX | NORMALSTRING | CHARSTRING | LONGSTRING | COMMENT | LINE_COMMENT | WS | NEWLINE )
    	int alt17=59;
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
    	switch (alt17)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Lua.g:1:10: T__20
    		{
    		DebugLocation(1, 10);
    		mT__20(); 

    		}
    		break;
    	case 2:
    		DebugEnterAlt(2);
    		// Lua.g:1:16: T__21
    		{
    		DebugLocation(1, 16);
    		mT__21(); 

    		}
    		break;
    	case 3:
    		DebugEnterAlt(3);
    		// Lua.g:1:22: T__22
    		{
    		DebugLocation(1, 22);
    		mT__22(); 

    		}
    		break;
    	case 4:
    		DebugEnterAlt(4);
    		// Lua.g:1:28: T__23
    		{
    		DebugLocation(1, 28);
    		mT__23(); 

    		}
    		break;
    	case 5:
    		DebugEnterAlt(5);
    		// Lua.g:1:34: T__24
    		{
    		DebugLocation(1, 34);
    		mT__24(); 

    		}
    		break;
    	case 6:
    		DebugEnterAlt(6);
    		// Lua.g:1:40: T__25
    		{
    		DebugLocation(1, 40);
    		mT__25(); 

    		}
    		break;
    	case 7:
    		DebugEnterAlt(7);
    		// Lua.g:1:46: T__26
    		{
    		DebugLocation(1, 46);
    		mT__26(); 

    		}
    		break;
    	case 8:
    		DebugEnterAlt(8);
    		// Lua.g:1:52: T__27
    		{
    		DebugLocation(1, 52);
    		mT__27(); 

    		}
    		break;
    	case 9:
    		DebugEnterAlt(9);
    		// Lua.g:1:58: T__28
    		{
    		DebugLocation(1, 58);
    		mT__28(); 

    		}
    		break;
    	case 10:
    		DebugEnterAlt(10);
    		// Lua.g:1:64: T__29
    		{
    		DebugLocation(1, 64);
    		mT__29(); 

    		}
    		break;
    	case 11:
    		DebugEnterAlt(11);
    		// Lua.g:1:70: T__30
    		{
    		DebugLocation(1, 70);
    		mT__30(); 

    		}
    		break;
    	case 12:
    		DebugEnterAlt(12);
    		// Lua.g:1:76: T__31
    		{
    		DebugLocation(1, 76);
    		mT__31(); 

    		}
    		break;
    	case 13:
    		DebugEnterAlt(13);
    		// Lua.g:1:82: T__32
    		{
    		DebugLocation(1, 82);
    		mT__32(); 

    		}
    		break;
    	case 14:
    		DebugEnterAlt(14);
    		// Lua.g:1:88: T__33
    		{
    		DebugLocation(1, 88);
    		mT__33(); 

    		}
    		break;
    	case 15:
    		DebugEnterAlt(15);
    		// Lua.g:1:94: T__34
    		{
    		DebugLocation(1, 94);
    		mT__34(); 

    		}
    		break;
    	case 16:
    		DebugEnterAlt(16);
    		// Lua.g:1:100: T__35
    		{
    		DebugLocation(1, 100);
    		mT__35(); 

    		}
    		break;
    	case 17:
    		DebugEnterAlt(17);
    		// Lua.g:1:106: T__36
    		{
    		DebugLocation(1, 106);
    		mT__36(); 

    		}
    		break;
    	case 18:
    		DebugEnterAlt(18);
    		// Lua.g:1:112: T__37
    		{
    		DebugLocation(1, 112);
    		mT__37(); 

    		}
    		break;
    	case 19:
    		DebugEnterAlt(19);
    		// Lua.g:1:118: T__38
    		{
    		DebugLocation(1, 118);
    		mT__38(); 

    		}
    		break;
    	case 20:
    		DebugEnterAlt(20);
    		// Lua.g:1:124: T__39
    		{
    		DebugLocation(1, 124);
    		mT__39(); 

    		}
    		break;
    	case 21:
    		DebugEnterAlt(21);
    		// Lua.g:1:130: T__40
    		{
    		DebugLocation(1, 130);
    		mT__40(); 

    		}
    		break;
    	case 22:
    		DebugEnterAlt(22);
    		// Lua.g:1:136: T__41
    		{
    		DebugLocation(1, 136);
    		mT__41(); 

    		}
    		break;
    	case 23:
    		DebugEnterAlt(23);
    		// Lua.g:1:142: T__42
    		{
    		DebugLocation(1, 142);
    		mT__42(); 

    		}
    		break;
    	case 24:
    		DebugEnterAlt(24);
    		// Lua.g:1:148: T__43
    		{
    		DebugLocation(1, 148);
    		mT__43(); 

    		}
    		break;
    	case 25:
    		DebugEnterAlt(25);
    		// Lua.g:1:154: T__44
    		{
    		DebugLocation(1, 154);
    		mT__44(); 

    		}
    		break;
    	case 26:
    		DebugEnterAlt(26);
    		// Lua.g:1:160: T__45
    		{
    		DebugLocation(1, 160);
    		mT__45(); 

    		}
    		break;
    	case 27:
    		DebugEnterAlt(27);
    		// Lua.g:1:166: T__46
    		{
    		DebugLocation(1, 166);
    		mT__46(); 

    		}
    		break;
    	case 28:
    		DebugEnterAlt(28);
    		// Lua.g:1:172: T__47
    		{
    		DebugLocation(1, 172);
    		mT__47(); 

    		}
    		break;
    	case 29:
    		DebugEnterAlt(29);
    		// Lua.g:1:178: T__48
    		{
    		DebugLocation(1, 178);
    		mT__48(); 

    		}
    		break;
    	case 30:
    		DebugEnterAlt(30);
    		// Lua.g:1:184: T__49
    		{
    		DebugLocation(1, 184);
    		mT__49(); 

    		}
    		break;
    	case 31:
    		DebugEnterAlt(31);
    		// Lua.g:1:190: T__50
    		{
    		DebugLocation(1, 190);
    		mT__50(); 

    		}
    		break;
    	case 32:
    		DebugEnterAlt(32);
    		// Lua.g:1:196: T__51
    		{
    		DebugLocation(1, 196);
    		mT__51(); 

    		}
    		break;
    	case 33:
    		DebugEnterAlt(33);
    		// Lua.g:1:202: T__52
    		{
    		DebugLocation(1, 202);
    		mT__52(); 

    		}
    		break;
    	case 34:
    		DebugEnterAlt(34);
    		// Lua.g:1:208: T__53
    		{
    		DebugLocation(1, 208);
    		mT__53(); 

    		}
    		break;
    	case 35:
    		DebugEnterAlt(35);
    		// Lua.g:1:214: T__54
    		{
    		DebugLocation(1, 214);
    		mT__54(); 

    		}
    		break;
    	case 36:
    		DebugEnterAlt(36);
    		// Lua.g:1:220: T__55
    		{
    		DebugLocation(1, 220);
    		mT__55(); 

    		}
    		break;
    	case 37:
    		DebugEnterAlt(37);
    		// Lua.g:1:226: T__56
    		{
    		DebugLocation(1, 226);
    		mT__56(); 

    		}
    		break;
    	case 38:
    		DebugEnterAlt(38);
    		// Lua.g:1:232: T__57
    		{
    		DebugLocation(1, 232);
    		mT__57(); 

    		}
    		break;
    	case 39:
    		DebugEnterAlt(39);
    		// Lua.g:1:238: T__58
    		{
    		DebugLocation(1, 238);
    		mT__58(); 

    		}
    		break;
    	case 40:
    		DebugEnterAlt(40);
    		// Lua.g:1:244: T__59
    		{
    		DebugLocation(1, 244);
    		mT__59(); 

    		}
    		break;
    	case 41:
    		DebugEnterAlt(41);
    		// Lua.g:1:250: T__60
    		{
    		DebugLocation(1, 250);
    		mT__60(); 

    		}
    		break;
    	case 42:
    		DebugEnterAlt(42);
    		// Lua.g:1:256: T__61
    		{
    		DebugLocation(1, 256);
    		mT__61(); 

    		}
    		break;
    	case 43:
    		DebugEnterAlt(43);
    		// Lua.g:1:262: T__62
    		{
    		DebugLocation(1, 262);
    		mT__62(); 

    		}
    		break;
    	case 44:
    		DebugEnterAlt(44);
    		// Lua.g:1:268: T__63
    		{
    		DebugLocation(1, 268);
    		mT__63(); 

    		}
    		break;
    	case 45:
    		DebugEnterAlt(45);
    		// Lua.g:1:274: T__64
    		{
    		DebugLocation(1, 274);
    		mT__64(); 

    		}
    		break;
    	case 46:
    		DebugEnterAlt(46);
    		// Lua.g:1:280: T__65
    		{
    		DebugLocation(1, 280);
    		mT__65(); 

    		}
    		break;
    	case 47:
    		DebugEnterAlt(47);
    		// Lua.g:1:286: T__66
    		{
    		DebugLocation(1, 286);
    		mT__66(); 

    		}
    		break;
    	case 48:
    		DebugEnterAlt(48);
    		// Lua.g:1:292: NAME
    		{
    		DebugLocation(1, 292);
    		mNAME(); 

    		}
    		break;
    	case 49:
    		DebugEnterAlt(49);
    		// Lua.g:1:297: INT
    		{
    		DebugLocation(1, 297);
    		mINT(); 

    		}
    		break;
    	case 50:
    		DebugEnterAlt(50);
    		// Lua.g:1:301: FLOAT
    		{
    		DebugLocation(1, 301);
    		mFLOAT(); 

    		}
    		break;
    	case 51:
    		DebugEnterAlt(51);
    		// Lua.g:1:307: EXP
    		{
    		DebugLocation(1, 307);
    		mEXP(); 

    		}
    		break;
    	case 52:
    		DebugEnterAlt(52);
    		// Lua.g:1:311: HEX
    		{
    		DebugLocation(1, 311);
    		mHEX(); 

    		}
    		break;
    	case 53:
    		DebugEnterAlt(53);
    		// Lua.g:1:315: NORMALSTRING
    		{
    		DebugLocation(1, 315);
    		mNORMALSTRING(); 

    		}
    		break;
    	case 54:
    		DebugEnterAlt(54);
    		// Lua.g:1:328: CHARSTRING
    		{
    		DebugLocation(1, 328);
    		mCHARSTRING(); 

    		}
    		break;
    	case 55:
    		DebugEnterAlt(55);
    		// Lua.g:1:339: LONGSTRING
    		{
    		DebugLocation(1, 339);
    		mLONGSTRING(); 

    		}
    		break;
    	case 56:
    		DebugEnterAlt(56);
    		// Lua.g:1:350: COMMENT
    		{
    		DebugLocation(1, 350);
    		mCOMMENT(); 

    		}
    		break;
    	case 57:
    		DebugEnterAlt(57);
    		// Lua.g:1:358: LINE_COMMENT
    		{
    		DebugLocation(1, 358);
    		mLINE_COMMENT(); 

    		}
    		break;
    	case 58:
    		DebugEnterAlt(58);
    		// Lua.g:1:371: WS
    		{
    		DebugLocation(1, 371);
    		mWS(); 

    		}
    		break;
    	case 59:
    		DebugEnterAlt(59);
    		// Lua.g:1:374: NEWLINE
    		{
    		DebugLocation(1, 374);
    		mNEWLINE(); 

    		}
    		break;

    	}

    }


	#region DFA
	DFA3 dfa3;
	DFA17 dfa17;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa3 = new DFA3(this);
		dfa17 = new DFA17(this, SpecialStateTransition17);
	}

	private class DFA3 : DFA
	{
		private const string DFA3_eotS =
			"\x04\uffff";
		private const string DFA3_eofS =
			"\x04\uffff";
		private const string DFA3_minS =
			"\x01\x30\x01\x2e\x02\uffff";
		private const string DFA3_maxS =
			"\x01\x39\x01\x65\x02\uffff";
		private const string DFA3_acceptS =
			"\x02\uffff\x01\x01\x01\x02";
		private const string DFA3_specialS =
			"\x04\uffff}>";
		private static readonly string[] DFA3_transitionS =
			{
				"\x0a\x01",
				"\x01\x03\x01\uffff\x0a\x01\x0b\uffff\x01\x02\x1f\uffff\x01\x02",
				"",
				""
			};

		private static readonly short[] DFA3_eot = DFA.UnpackEncodedString(DFA3_eotS);
		private static readonly short[] DFA3_eof = DFA.UnpackEncodedString(DFA3_eofS);
		private static readonly char[] DFA3_min = DFA.UnpackEncodedStringToUnsignedChars(DFA3_minS);
		private static readonly char[] DFA3_max = DFA.UnpackEncodedStringToUnsignedChars(DFA3_maxS);
		private static readonly short[] DFA3_accept = DFA.UnpackEncodedString(DFA3_acceptS);
		private static readonly short[] DFA3_special = DFA.UnpackEncodedString(DFA3_specialS);
		private static readonly short[][] DFA3_transition;

		static DFA3()
		{
			int numStates = DFA3_transitionS.Length;
			DFA3_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA3_transition[i] = DFA.UnpackEncodedString(DFA3_transitionS[i]);
			}
		}

		public DFA3( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 3;
			this.eot = DFA3_eot;
			this.eof = DFA3_eof;
			this.min = DFA3_min;
			this.max = DFA3_max;
			this.accept = DFA3_accept;
			this.special = DFA3_special;
			this.transition = DFA3_transition;
		}

		public override string Description { get { return "108:7: ( INT | FLOAT )"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA17 : DFA
	{
		private const string DFA17_eotS =
			"\x02\uffff\x01\x2b\x08\x23\x01\uffff\x02\x23\x01\x3c\x01\uffff\x01\x23"+
			"\x02\uffff\x01\x3f\x04\uffff\x01\x42\x04\uffff\x01\x44\x01\x46\x01\uffff"+
			"\x02\x23\x02\uffff\x02\x4a\x06\uffff\x01\x4d\x05\x23\x01\x54\x01\x55"+
			"\x07\x23\x01\x5e\x01\uffff\x02\x23\x08\uffff\x01\x23\x01\x64\x05\uffff"+
			"\x01\x66\x05\x23\x02\uffff\x02\x23\x01\x6e\x04\x23\x02\uffff\x01\x73"+
			"\x01\x74\x02\uffff\x01\x76\x01\uffff\x01\x77\x01\uffff\x01\x79\x04\x23"+
			"\x01\x7e\x01\x7f\x01\uffff\x04\x23\x05\uffff\x01\x23\x01\uffff\x01\u0089"+
			"\x02\x23\x01\u008c\x02\uffff\x01\x23\x01\u008e\x01\u008f\x01\u0090\x02"+
			"\uffff\x01\x62\x01\uffff\x01\u0093\x01\uffff\x01\u0094\x01\u0095\x01"+
			"\uffff\x01\x23\x03\uffff\x01\u0092\x04\uffff\x01\x23\x01\u0098\x01\uffff";
		private const string DFA17_eofS =
			"\u0099\uffff";
		private const string DFA17_minS =
			"\x01\x09\x01\uffff\x01\x3d\x01\x6f\x01\x6c\x01\x68\x01\x65\x01\x6e\x01"+
			"\x66\x01\x68\x01\x61\x01\uffff\x01\x6f\x01\x72\x01\x2e\x01\uffff\x01"+
			"\x69\x02\uffff\x01\x3d\x04\uffff\x01\x2d\x04\uffff\x02\x3d\x01\uffff"+
			"\x01\x6e\x01\x72\x02\uffff\x02\x2e\x06\uffff\x01\x30\x01\x64\x01\x73"+
			"\x01\x69\x01\x70\x01\x74\x02\x30\x01\x65\x01\x75\x01\x72\x01\x6e\x01"+
			"\x6c\x01\x63\x01\x65\x01\x2e\x01\uffff\x01\x6c\x01\x74\x02\uffff\x01"+
			"\x00\x05\uffff\x01\x64\x01\x30\x02\uffff\x01\x30\x02\uffff\x01\x30\x01"+
			"\x65\x01\x6c\x01\x65\x01\x75\x01\x69\x02\uffff\x01\x6e\x01\x65\x01\x30"+
			"\x01\x63\x01\x73\x02\x61\x02\uffff\x02\x30\x01\x00\x01\uffff\x01\x30"+
			"\x01\uffff\x01\x30\x01\uffff\x01\x30\x01\x65\x01\x61\x01\x72\x01\x6c"+
			"\x02\x30\x01\uffff\x01\x74\x01\x65\x01\x6c\x01\x6b\x02\uffff\x01\x00"+
			"\x02\uffff\x01\x66\x01\uffff\x01\x30\x01\x74\x01\x6e\x01\x30\x02\uffff"+
			"\x01\x69\x03\x30\x04\x00\x01\x30\x01\uffff\x02\x30\x01\uffff\x01\x6f"+
			"\x03\uffff\x01\x00\x04\uffff\x01\x6e\x01\x30\x01\uffff";
		private const string DFA17_maxS =
			"\x01\x7e\x01\uffff\x01\x3d\x01\x6f\x01\x6e\x01\x68\x01\x65\x02\x6e\x01"+
			"\x72\x01\x75\x01\uffff\x01\x6f\x01\x72\x01\x2e\x01\uffff\x01\x6f\x02"+
			"\uffff\x01\x5b\x04\uffff\x01\x2d\x04\uffff\x02\x3d\x01\uffff\x01\x6e"+
			"\x01\x72\x02\uffff\x01\x78\x01\x65\x06\uffff\x01\x7a\x01\x64\x01\x73"+
			"\x01\x69\x02\x74\x02\x7a\x01\x65\x01\x75\x01\x72\x01\x6e\x01\x6c\x01"+
			"\x63\x01\x65\x01\x2e\x01\uffff\x01\x6c\x01\x74\x02\uffff\x01\uffff\x05"+
			"\uffff\x01\x64\x01\x7a\x02\uffff\x01\x39\x02\uffff\x01\x7a\x01\x65\x01"+
			"\x6c\x01\x65\x01\x75\x01\x69\x02\uffff\x01\x6e\x01\x65\x01\x7a\x01\x63"+
			"\x01\x73\x02\x61\x02\uffff\x02\x7a\x01\uffff\x01\uffff\x01\x7a\x01\uffff"+
			"\x01\x65\x01\uffff\x01\x7a\x01\x65\x01\x61\x01\x72\x01\x6c\x02\x7a\x01"+
			"\uffff\x01\x74\x01\x65\x01\x6c\x01\x6b\x02\uffff\x01\uffff\x02\uffff"+
			"\x01\x66\x01\uffff\x01\x7a\x01\x74\x01\x6e\x01\x7a\x02\uffff\x01\x69"+
			"\x03\x7a\x04\uffff\x01\x7a\x01\uffff\x02\x7a\x01\uffff\x01\x6f\x03\uffff"+
			"\x01\uffff\x04\uffff\x01\x6e\x01\x7a\x01\uffff";
		private const string DFA17_acceptS =
			"\x01\uffff\x01\x01\x09\uffff\x01\x0d\x03\uffff\x01\x14\x01\uffff\x01"+
			"\x19\x01\x1a\x01\uffff\x01\x1c\x01\x1d\x01\x1e\x01\x1f\x01\uffff\x01"+
			"\x21\x01\x22\x01\x23\x01\x24\x02\uffff\x01\x2b\x02\uffff\x01\x2f\x01"+
			"\x30\x02\uffff\x01\x35\x01\x36\x01\x3a\x01\x3b\x01\x2a\x01\x02\x10\uffff"+
			"\x01\x13\x02\uffff\x01\x1b\x01\x37\x01\uffff\x01\x20\x01\x27\x01\x26"+
			"\x01\x29\x01\x28\x02\uffff\x01\x34\x01\x31\x01\uffff\x01\x33\x01\x03"+
			"\x06\uffff\x01\x08\x01\x0e\x07\uffff\x01\x18\x01\x25\x03\uffff\x01\x39"+
			"\x01\uffff\x01\x2d\x01\uffff\x01\x04\x07\uffff\x01\x0c\x04\uffff\x01"+
			"\x15\x01\x2e\x01\uffff\x01\x2c\x01\x32\x01\uffff\x01\x0b\x04\uffff\x01"+
			"\x09\x01\x17\x09\uffff\x01\x05\x02\uffff\x01\x07\x01\uffff\x01\x16\x01"+
			"\x10\x01\x12\x01\uffff\x01\x38\x01\x0a\x01\x06\x01\x11\x02\uffff\x01"+
			"\x0f";
		private const string DFA17_specialS =
			"\x41\uffff\x01\x01\x1f\uffff\x01\x03\x13\uffff\x01\x06\x0e\uffff\x01"+
			"\x04\x01\x00\x01\x02\x01\x07\x09\uffff\x01\x05\x07\uffff}>";
		private static readonly string[] DFA17_transitionS =
			{
				"\x01\x28\x01\x29\x01\uffff\x01\x28\x01\x29\x12\uffff\x01\x28\x01\uffff"+
				"\x01\x26\x01\x22\x01\uffff\x01\x1c\x01\uffff\x01\x27\x01\x11\x01\x12"+
				"\x01\x19\x01\x17\x01\x0b\x01\x18\x01\x0e\x01\x1a\x01\x24\x09\x25\x01"+
				"\x0f\x01\x01\x01\x1d\x01\x02\x01\x1e\x02\uffff\x1a\x23\x01\x13\x01\uffff"+
				"\x01\x14\x01\x1b\x01\x23\x01\uffff\x01\x20\x01\x0d\x01\x23\x01\x03\x01"+
				"\x04\x01\x0a\x02\x23\x01\x08\x02\x23\x01\x0c\x01\x23\x01\x10\x01\x21"+
				"\x02\x23\x01\x06\x01\x23\x01\x09\x01\x07\x01\x23\x01\x05\x03\x23\x01"+
				"\x15\x01\uffff\x01\x16\x01\x1f",
				"",
				"\x01\x2a",
				"\x01\x2c",
				"\x01\x2e\x01\uffff\x01\x2d",
				"\x01\x2f",
				"\x01\x30",
				"\x01\x31",
				"\x01\x32\x07\uffff\x01\x33",
				"\x01\x34\x09\uffff\x01\x35",
				"\x01\x38\x0d\uffff\x01\x36\x05\uffff\x01\x37",
				"",
				"\x01\x39",
				"\x01\x3a",
				"\x01\x3b",
				"",
				"\x01\x3d\x05\uffff\x01\x3e",
				"",
				"",
				"\x01\x40\x1d\uffff\x01\x40",
				"",
				"",
				"",
				"",
				"\x01\x41",
				"",
				"",
				"",
				"",
				"\x01\x43",
				"\x01\x45",
				"",
				"\x01\x47",
				"\x01\x48",
				"",
				"",
				"\x01\x4b\x01\uffff\x0a\x25\x0b\uffff\x01\x4c\x1f\uffff\x01\x4c\x12"+
				"\uffff\x01\x49",
				"\x01\x4b\x01\uffff\x0a\x25\x0b\uffff\x01\x4c\x1f\uffff\x01\x4c",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x01\x4e",
				"\x01\x4f",
				"\x01\x50",
				"\x01\x51\x03\uffff\x01\x52",
				"\x01\x53",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x01\x56",
				"\x01\x57",
				"\x01\x58",
				"\x01\x59",
				"\x01\x5a",
				"\x01\x5b",
				"\x01\x5c",
				"\x01\x5d",
				"",
				"\x01\x5f",
				"\x01\x60",
				"",
				"",
				"\x5b\x62\x01\x61\uffa4\x62",
				"",
				"",
				"",
				"",
				"",
				"\x01\x63",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"",
				"",
				"\x0a\x65",
				"",
				"",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x01\x67",
				"\x01\x68",
				"\x01\x69",
				"\x01\x6a",
				"\x01\x6b",
				"",
				"",
				"\x01\x6c",
				"\x01\x6d",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x01\x6f",
				"\x01\x70",
				"\x01\x71",
				"\x01\x72",
				"",
				"",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x5b\x62\x01\x75\uffa4\x62",
				"",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"",
				"\x0a\x65\x0b\uffff\x01\x4c\x1f\uffff\x01\x4c",
				"",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x08\x23\x01"+
				"\x78\x11\x23",
				"\x01\x7a",
				"\x01\x7b",
				"\x01\x7c",
				"\x01\x7d",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"",
				"\x01\u0080",
				"\x01\u0081",
				"\x01\u0082",
				"\x01\u0083",
				"",
				"",
				"\x0a\u0087\x01\u0086\x02\u0087\x01\u0085\x4f\u0087\x01\u0084\uffa2"+
				"\u0087",
				"",
				"",
				"\x01\u0088",
				"",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x01\u008a",
				"\x01\u008b",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"",
				"",
				"\x01\u008d",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x0a\u0087\x01\u0086\x02\u0087\x01\u0085\x4f\u0087\x01\u0091\uffa2"+
				"\u0087",
				"\x0a\u0092\x01\u0086\ufff5\u0092",
				"\x00\u0092",
				"\x0a\u0087\x01\u0086\x02\u0087\x01\u0085\x4f\u0087\x01\u0084\uffa2"+
				"\u0087",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
				"",
				"\x01\u0096",
				"",
				"",
				"",
				"\x0a\u0087\x01\u0086\x02\u0087\x01\u0085\x4f\u0087\x01\u0091\uffa2"+
				"\u0087",
				"",
				"",
				"",
				"",
				"\x01\u0097",
				"\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a\x23",
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

		public DFA17( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "1:1: Tokens : ( T__20 | T__21 | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | NAME | INT | FLOAT | EXP | HEX | NORMALSTRING | CHARSTRING | LONGSTRING | COMMENT | LINE_COMMENT | WS | NEWLINE );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition17(DFA dfa, int s, IIntStream _input)
	{
		IIntStream input = _input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA17_133 = input.LA(1);

				s = -1;
				if ( ((LA17_133>='\u0000' && LA17_133<='\t')||(LA17_133>='\u000B' && LA17_133<='\uFFFF')) ) {s = 146;}

				else if ( (LA17_133=='\n') ) {s = 134;}

				if ( s>=0 ) return s;
				break;
			case 1:
				int LA17_65 = input.LA(1);

				s = -1;
				if ( (LA17_65=='[') ) {s = 97;}

				else if ( ((LA17_65>='\u0000' && LA17_65<='Z')||(LA17_65>='\\' && LA17_65<='\uFFFF')) ) {s = 98;}

				if ( s>=0 ) return s;
				break;
			case 2:
				int LA17_134 = input.LA(1);

				s = -1;
				if ( ((LA17_134>='\u0000' && LA17_134<='\uFFFF')) ) {s = 146;}

				else s = 98;

				if ( s>=0 ) return s;
				break;
			case 3:
				int LA17_97 = input.LA(1);

				s = -1;
				if ( (LA17_97=='[') ) {s = 117;}

				else if ( ((LA17_97>='\u0000' && LA17_97<='Z')||(LA17_97>='\\' && LA17_97<='\uFFFF')) ) {s = 98;}

				if ( s>=0 ) return s;
				break;
			case 4:
				int LA17_132 = input.LA(1);

				s = -1;
				if ( (LA17_132==']') ) {s = 145;}

				else if ( (LA17_132=='\r') ) {s = 133;}

				else if ( (LA17_132=='\n') ) {s = 134;}

				else if ( ((LA17_132>='\u0000' && LA17_132<='\t')||(LA17_132>='\u000B' && LA17_132<='\f')||(LA17_132>='\u000E' && LA17_132<='\\')||(LA17_132>='^' && LA17_132<='\uFFFF')) ) {s = 135;}

				if ( s>=0 ) return s;
				break;
			case 5:
				int LA17_145 = input.LA(1);

				s = -1;
				if ( (LA17_145==']') ) {s = 145;}

				else if ( (LA17_145=='\r') ) {s = 133;}

				else if ( (LA17_145=='\n') ) {s = 134;}

				else if ( ((LA17_145>='\u0000' && LA17_145<='\t')||(LA17_145>='\u000B' && LA17_145<='\f')||(LA17_145>='\u000E' && LA17_145<='\\')||(LA17_145>='^' && LA17_145<='\uFFFF')) ) {s = 135;}

				else s = 146;

				if ( s>=0 ) return s;
				break;
			case 6:
				int LA17_117 = input.LA(1);

				s = -1;
				if ( (LA17_117==']') ) {s = 132;}

				else if ( (LA17_117=='\r') ) {s = 133;}

				else if ( (LA17_117=='\n') ) {s = 134;}

				else if ( ((LA17_117>='\u0000' && LA17_117<='\t')||(LA17_117>='\u000B' && LA17_117<='\f')||(LA17_117>='\u000E' && LA17_117<='\\')||(LA17_117>='^' && LA17_117<='\uFFFF')) ) {s = 135;}

				if ( s>=0 ) return s;
				break;
			case 7:
				int LA17_135 = input.LA(1);

				s = -1;
				if ( (LA17_135==']') ) {s = 132;}

				else if ( (LA17_135=='\r') ) {s = 133;}

				else if ( (LA17_135=='\n') ) {s = 134;}

				else if ( ((LA17_135>='\u0000' && LA17_135<='\t')||(LA17_135>='\u000B' && LA17_135<='\f')||(LA17_135>='\u000E' && LA17_135<='\\')||(LA17_135>='^' && LA17_135<='\uFFFF')) ) {s = 135;}

				if ( s>=0 ) return s;
				break;
		}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 17, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
 
	#endregion

}
