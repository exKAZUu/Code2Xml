using Code2Xml.Core.Antlr;
// $ANTLR 3.3 Nov 30, 2010 12:50:56 C.g 2011-06-08 18:58:15

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class CLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
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
	public const int IDENTIFIER=4;
	public const int HEX_LITERAL=5;
	public const int OCTAL_LITERAL=6;
	public const int DECIMAL_LITERAL=7;
	public const int CHARACTER_LITERAL=8;
	public const int STRING_LITERAL=9;
	public const int FLOATING_POINT_LITERAL=10;
	public const int LETTER=11;
	public const int EscapeSequence=12;
	public const int HexDigit=13;
	public const int IntegerTypeSuffix=14;
	public const int Exponent=15;
	public const int FloatTypeSuffix=16;
	public const int OctalEscape=17;
	public const int UnicodeEscape=18;
	public const int WS=19;
	public const int COMMENT=20;
	public const int LINE_COMMENT=21;
	public const int LINE_COMMAND=22;

    // delegates
    // delegators

	public CLexer()
	{
		OnCreated();
	}

	public CLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public CLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "C.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_T__23();
	partial void Leave_T__23();

	// $ANTLR start "T__23"
	[GrammarRule("T__23")]
	private void mT__23()
	{
		Enter_T__23();
		EnterRule("T__23", 1);
		TraceIn("T__23", 1);
		try
		{
			int _type = T__23;
			int _channel = DefaultTokenChannel;
			// C.g:7:7: ( 'typedef' )
			DebugEnterAlt(1);
			// C.g:7:9: 'typedef'
			{
			DebugLocation(7, 9);
			Match("typedef"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__23", 1);
			LeaveRule("T__23", 1);
			Leave_T__23();
		}
	}
	// $ANTLR end "T__23"

	partial void Enter_T__24();
	partial void Leave_T__24();

	// $ANTLR start "T__24"
	[GrammarRule("T__24")]
	private void mT__24()
	{
		Enter_T__24();
		EnterRule("T__24", 2);
		TraceIn("T__24", 2);
		try
		{
			int _type = T__24;
			int _channel = DefaultTokenChannel;
			// C.g:8:7: ( ';' )
			DebugEnterAlt(1);
			// C.g:8:9: ';'
			{
			DebugLocation(8, 9);
			Match(';'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__24", 2);
			LeaveRule("T__24", 2);
			Leave_T__24();
		}
	}
	// $ANTLR end "T__24"

	partial void Enter_T__25();
	partial void Leave_T__25();

	// $ANTLR start "T__25"
	[GrammarRule("T__25")]
	private void mT__25()
	{
		Enter_T__25();
		EnterRule("T__25", 3);
		TraceIn("T__25", 3);
		try
		{
			int _type = T__25;
			int _channel = DefaultTokenChannel;
			// C.g:9:7: ( ',' )
			DebugEnterAlt(1);
			// C.g:9:9: ','
			{
			DebugLocation(9, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__25", 3);
			LeaveRule("T__25", 3);
			Leave_T__25();
		}
	}
	// $ANTLR end "T__25"

	partial void Enter_T__26();
	partial void Leave_T__26();

	// $ANTLR start "T__26"
	[GrammarRule("T__26")]
	private void mT__26()
	{
		Enter_T__26();
		EnterRule("T__26", 4);
		TraceIn("T__26", 4);
		try
		{
			int _type = T__26;
			int _channel = DefaultTokenChannel;
			// C.g:10:7: ( '=' )
			DebugEnterAlt(1);
			// C.g:10:9: '='
			{
			DebugLocation(10, 9);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__26", 4);
			LeaveRule("T__26", 4);
			Leave_T__26();
		}
	}
	// $ANTLR end "T__26"

	partial void Enter_T__27();
	partial void Leave_T__27();

	// $ANTLR start "T__27"
	[GrammarRule("T__27")]
	private void mT__27()
	{
		Enter_T__27();
		EnterRule("T__27", 5);
		TraceIn("T__27", 5);
		try
		{
			int _type = T__27;
			int _channel = DefaultTokenChannel;
			// C.g:11:7: ( 'extern' )
			DebugEnterAlt(1);
			// C.g:11:9: 'extern'
			{
			DebugLocation(11, 9);
			Match("extern"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__27", 5);
			LeaveRule("T__27", 5);
			Leave_T__27();
		}
	}
	// $ANTLR end "T__27"

	partial void Enter_T__28();
	partial void Leave_T__28();

	// $ANTLR start "T__28"
	[GrammarRule("T__28")]
	private void mT__28()
	{
		Enter_T__28();
		EnterRule("T__28", 6);
		TraceIn("T__28", 6);
		try
		{
			int _type = T__28;
			int _channel = DefaultTokenChannel;
			// C.g:12:7: ( 'static' )
			DebugEnterAlt(1);
			// C.g:12:9: 'static'
			{
			DebugLocation(12, 9);
			Match("static"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__28", 6);
			LeaveRule("T__28", 6);
			Leave_T__28();
		}
	}
	// $ANTLR end "T__28"

	partial void Enter_T__29();
	partial void Leave_T__29();

	// $ANTLR start "T__29"
	[GrammarRule("T__29")]
	private void mT__29()
	{
		Enter_T__29();
		EnterRule("T__29", 7);
		TraceIn("T__29", 7);
		try
		{
			int _type = T__29;
			int _channel = DefaultTokenChannel;
			// C.g:13:7: ( 'auto' )
			DebugEnterAlt(1);
			// C.g:13:9: 'auto'
			{
			DebugLocation(13, 9);
			Match("auto"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__29", 7);
			LeaveRule("T__29", 7);
			Leave_T__29();
		}
	}
	// $ANTLR end "T__29"

	partial void Enter_T__30();
	partial void Leave_T__30();

	// $ANTLR start "T__30"
	[GrammarRule("T__30")]
	private void mT__30()
	{
		Enter_T__30();
		EnterRule("T__30", 8);
		TraceIn("T__30", 8);
		try
		{
			int _type = T__30;
			int _channel = DefaultTokenChannel;
			// C.g:14:7: ( 'register' )
			DebugEnterAlt(1);
			// C.g:14:9: 'register'
			{
			DebugLocation(14, 9);
			Match("register"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__30", 8);
			LeaveRule("T__30", 8);
			Leave_T__30();
		}
	}
	// $ANTLR end "T__30"

	partial void Enter_T__31();
	partial void Leave_T__31();

	// $ANTLR start "T__31"
	[GrammarRule("T__31")]
	private void mT__31()
	{
		Enter_T__31();
		EnterRule("T__31", 9);
		TraceIn("T__31", 9);
		try
		{
			int _type = T__31;
			int _channel = DefaultTokenChannel;
			// C.g:15:7: ( 'void' )
			DebugEnterAlt(1);
			// C.g:15:9: 'void'
			{
			DebugLocation(15, 9);
			Match("void"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__31", 9);
			LeaveRule("T__31", 9);
			Leave_T__31();
		}
	}
	// $ANTLR end "T__31"

	partial void Enter_T__32();
	partial void Leave_T__32();

	// $ANTLR start "T__32"
	[GrammarRule("T__32")]
	private void mT__32()
	{
		Enter_T__32();
		EnterRule("T__32", 10);
		TraceIn("T__32", 10);
		try
		{
			int _type = T__32;
			int _channel = DefaultTokenChannel;
			// C.g:16:7: ( 'char' )
			DebugEnterAlt(1);
			// C.g:16:9: 'char'
			{
			DebugLocation(16, 9);
			Match("char"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__32", 10);
			LeaveRule("T__32", 10);
			Leave_T__32();
		}
	}
	// $ANTLR end "T__32"

	partial void Enter_T__33();
	partial void Leave_T__33();

	// $ANTLR start "T__33"
	[GrammarRule("T__33")]
	private void mT__33()
	{
		Enter_T__33();
		EnterRule("T__33", 11);
		TraceIn("T__33", 11);
		try
		{
			int _type = T__33;
			int _channel = DefaultTokenChannel;
			// C.g:17:7: ( 'short' )
			DebugEnterAlt(1);
			// C.g:17:9: 'short'
			{
			DebugLocation(17, 9);
			Match("short"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__33", 11);
			LeaveRule("T__33", 11);
			Leave_T__33();
		}
	}
	// $ANTLR end "T__33"

	partial void Enter_T__34();
	partial void Leave_T__34();

	// $ANTLR start "T__34"
	[GrammarRule("T__34")]
	private void mT__34()
	{
		Enter_T__34();
		EnterRule("T__34", 12);
		TraceIn("T__34", 12);
		try
		{
			int _type = T__34;
			int _channel = DefaultTokenChannel;
			// C.g:18:7: ( 'int' )
			DebugEnterAlt(1);
			// C.g:18:9: 'int'
			{
			DebugLocation(18, 9);
			Match("int"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__34", 12);
			LeaveRule("T__34", 12);
			Leave_T__34();
		}
	}
	// $ANTLR end "T__34"

	partial void Enter_T__35();
	partial void Leave_T__35();

	// $ANTLR start "T__35"
	[GrammarRule("T__35")]
	private void mT__35()
	{
		Enter_T__35();
		EnterRule("T__35", 13);
		TraceIn("T__35", 13);
		try
		{
			int _type = T__35;
			int _channel = DefaultTokenChannel;
			// C.g:19:7: ( 'long' )
			DebugEnterAlt(1);
			// C.g:19:9: 'long'
			{
			DebugLocation(19, 9);
			Match("long"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__35", 13);
			LeaveRule("T__35", 13);
			Leave_T__35();
		}
	}
	// $ANTLR end "T__35"

	partial void Enter_T__36();
	partial void Leave_T__36();

	// $ANTLR start "T__36"
	[GrammarRule("T__36")]
	private void mT__36()
	{
		Enter_T__36();
		EnterRule("T__36", 14);
		TraceIn("T__36", 14);
		try
		{
			int _type = T__36;
			int _channel = DefaultTokenChannel;
			// C.g:20:7: ( 'float' )
			DebugEnterAlt(1);
			// C.g:20:9: 'float'
			{
			DebugLocation(20, 9);
			Match("float"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__36", 14);
			LeaveRule("T__36", 14);
			Leave_T__36();
		}
	}
	// $ANTLR end "T__36"

	partial void Enter_T__37();
	partial void Leave_T__37();

	// $ANTLR start "T__37"
	[GrammarRule("T__37")]
	private void mT__37()
	{
		Enter_T__37();
		EnterRule("T__37", 15);
		TraceIn("T__37", 15);
		try
		{
			int _type = T__37;
			int _channel = DefaultTokenChannel;
			// C.g:21:7: ( 'double' )
			DebugEnterAlt(1);
			// C.g:21:9: 'double'
			{
			DebugLocation(21, 9);
			Match("double"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__37", 15);
			LeaveRule("T__37", 15);
			Leave_T__37();
		}
	}
	// $ANTLR end "T__37"

	partial void Enter_T__38();
	partial void Leave_T__38();

	// $ANTLR start "T__38"
	[GrammarRule("T__38")]
	private void mT__38()
	{
		Enter_T__38();
		EnterRule("T__38", 16);
		TraceIn("T__38", 16);
		try
		{
			int _type = T__38;
			int _channel = DefaultTokenChannel;
			// C.g:22:7: ( 'signed' )
			DebugEnterAlt(1);
			// C.g:22:9: 'signed'
			{
			DebugLocation(22, 9);
			Match("signed"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__38", 16);
			LeaveRule("T__38", 16);
			Leave_T__38();
		}
	}
	// $ANTLR end "T__38"

	partial void Enter_T__39();
	partial void Leave_T__39();

	// $ANTLR start "T__39"
	[GrammarRule("T__39")]
	private void mT__39()
	{
		Enter_T__39();
		EnterRule("T__39", 17);
		TraceIn("T__39", 17);
		try
		{
			int _type = T__39;
			int _channel = DefaultTokenChannel;
			// C.g:23:7: ( 'unsigned' )
			DebugEnterAlt(1);
			// C.g:23:9: 'unsigned'
			{
			DebugLocation(23, 9);
			Match("unsigned"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__39", 17);
			LeaveRule("T__39", 17);
			Leave_T__39();
		}
	}
	// $ANTLR end "T__39"

	partial void Enter_T__40();
	partial void Leave_T__40();

	// $ANTLR start "T__40"
	[GrammarRule("T__40")]
	private void mT__40()
	{
		Enter_T__40();
		EnterRule("T__40", 18);
		TraceIn("T__40", 18);
		try
		{
			int _type = T__40;
			int _channel = DefaultTokenChannel;
			// C.g:24:7: ( '{' )
			DebugEnterAlt(1);
			// C.g:24:9: '{'
			{
			DebugLocation(24, 9);
			Match('{'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__40", 18);
			LeaveRule("T__40", 18);
			Leave_T__40();
		}
	}
	// $ANTLR end "T__40"

	partial void Enter_T__41();
	partial void Leave_T__41();

	// $ANTLR start "T__41"
	[GrammarRule("T__41")]
	private void mT__41()
	{
		Enter_T__41();
		EnterRule("T__41", 19);
		TraceIn("T__41", 19);
		try
		{
			int _type = T__41;
			int _channel = DefaultTokenChannel;
			// C.g:25:7: ( '}' )
			DebugEnterAlt(1);
			// C.g:25:9: '}'
			{
			DebugLocation(25, 9);
			Match('}'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__41", 19);
			LeaveRule("T__41", 19);
			Leave_T__41();
		}
	}
	// $ANTLR end "T__41"

	partial void Enter_T__42();
	partial void Leave_T__42();

	// $ANTLR start "T__42"
	[GrammarRule("T__42")]
	private void mT__42()
	{
		Enter_T__42();
		EnterRule("T__42", 20);
		TraceIn("T__42", 20);
		try
		{
			int _type = T__42;
			int _channel = DefaultTokenChannel;
			// C.g:26:7: ( 'struct' )
			DebugEnterAlt(1);
			// C.g:26:9: 'struct'
			{
			DebugLocation(26, 9);
			Match("struct"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__42", 20);
			LeaveRule("T__42", 20);
			Leave_T__42();
		}
	}
	// $ANTLR end "T__42"

	partial void Enter_T__43();
	partial void Leave_T__43();

	// $ANTLR start "T__43"
	[GrammarRule("T__43")]
	private void mT__43()
	{
		Enter_T__43();
		EnterRule("T__43", 21);
		TraceIn("T__43", 21);
		try
		{
			int _type = T__43;
			int _channel = DefaultTokenChannel;
			// C.g:27:7: ( 'union' )
			DebugEnterAlt(1);
			// C.g:27:9: 'union'
			{
			DebugLocation(27, 9);
			Match("union"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__43", 21);
			LeaveRule("T__43", 21);
			Leave_T__43();
		}
	}
	// $ANTLR end "T__43"

	partial void Enter_T__44();
	partial void Leave_T__44();

	// $ANTLR start "T__44"
	[GrammarRule("T__44")]
	private void mT__44()
	{
		Enter_T__44();
		EnterRule("T__44", 22);
		TraceIn("T__44", 22);
		try
		{
			int _type = T__44;
			int _channel = DefaultTokenChannel;
			// C.g:28:7: ( ':' )
			DebugEnterAlt(1);
			// C.g:28:9: ':'
			{
			DebugLocation(28, 9);
			Match(':'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__44", 22);
			LeaveRule("T__44", 22);
			Leave_T__44();
		}
	}
	// $ANTLR end "T__44"

	partial void Enter_T__45();
	partial void Leave_T__45();

	// $ANTLR start "T__45"
	[GrammarRule("T__45")]
	private void mT__45()
	{
		Enter_T__45();
		EnterRule("T__45", 23);
		TraceIn("T__45", 23);
		try
		{
			int _type = T__45;
			int _channel = DefaultTokenChannel;
			// C.g:29:7: ( 'enum' )
			DebugEnterAlt(1);
			// C.g:29:9: 'enum'
			{
			DebugLocation(29, 9);
			Match("enum"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__45", 23);
			LeaveRule("T__45", 23);
			Leave_T__45();
		}
	}
	// $ANTLR end "T__45"

	partial void Enter_T__46();
	partial void Leave_T__46();

	// $ANTLR start "T__46"
	[GrammarRule("T__46")]
	private void mT__46()
	{
		Enter_T__46();
		EnterRule("T__46", 24);
		TraceIn("T__46", 24);
		try
		{
			int _type = T__46;
			int _channel = DefaultTokenChannel;
			// C.g:30:7: ( 'const' )
			DebugEnterAlt(1);
			// C.g:30:9: 'const'
			{
			DebugLocation(30, 9);
			Match("const"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__46", 24);
			LeaveRule("T__46", 24);
			Leave_T__46();
		}
	}
	// $ANTLR end "T__46"

	partial void Enter_T__47();
	partial void Leave_T__47();

	// $ANTLR start "T__47"
	[GrammarRule("T__47")]
	private void mT__47()
	{
		Enter_T__47();
		EnterRule("T__47", 25);
		TraceIn("T__47", 25);
		try
		{
			int _type = T__47;
			int _channel = DefaultTokenChannel;
			// C.g:31:7: ( 'volatile' )
			DebugEnterAlt(1);
			// C.g:31:9: 'volatile'
			{
			DebugLocation(31, 9);
			Match("volatile"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__47", 25);
			LeaveRule("T__47", 25);
			Leave_T__47();
		}
	}
	// $ANTLR end "T__47"

	partial void Enter_T__48();
	partial void Leave_T__48();

	// $ANTLR start "T__48"
	[GrammarRule("T__48")]
	private void mT__48()
	{
		Enter_T__48();
		EnterRule("T__48", 26);
		TraceIn("T__48", 26);
		try
		{
			int _type = T__48;
			int _channel = DefaultTokenChannel;
			// C.g:32:7: ( '(' )
			DebugEnterAlt(1);
			// C.g:32:9: '('
			{
			DebugLocation(32, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__48", 26);
			LeaveRule("T__48", 26);
			Leave_T__48();
		}
	}
	// $ANTLR end "T__48"

	partial void Enter_T__49();
	partial void Leave_T__49();

	// $ANTLR start "T__49"
	[GrammarRule("T__49")]
	private void mT__49()
	{
		Enter_T__49();
		EnterRule("T__49", 27);
		TraceIn("T__49", 27);
		try
		{
			int _type = T__49;
			int _channel = DefaultTokenChannel;
			// C.g:33:7: ( ')' )
			DebugEnterAlt(1);
			// C.g:33:9: ')'
			{
			DebugLocation(33, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__49", 27);
			LeaveRule("T__49", 27);
			Leave_T__49();
		}
	}
	// $ANTLR end "T__49"

	partial void Enter_T__50();
	partial void Leave_T__50();

	// $ANTLR start "T__50"
	[GrammarRule("T__50")]
	private void mT__50()
	{
		Enter_T__50();
		EnterRule("T__50", 28);
		TraceIn("T__50", 28);
		try
		{
			int _type = T__50;
			int _channel = DefaultTokenChannel;
			// C.g:34:7: ( '[' )
			DebugEnterAlt(1);
			// C.g:34:9: '['
			{
			DebugLocation(34, 9);
			Match('['); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__50", 28);
			LeaveRule("T__50", 28);
			Leave_T__50();
		}
	}
	// $ANTLR end "T__50"

	partial void Enter_T__51();
	partial void Leave_T__51();

	// $ANTLR start "T__51"
	[GrammarRule("T__51")]
	private void mT__51()
	{
		Enter_T__51();
		EnterRule("T__51", 29);
		TraceIn("T__51", 29);
		try
		{
			int _type = T__51;
			int _channel = DefaultTokenChannel;
			// C.g:35:7: ( ']' )
			DebugEnterAlt(1);
			// C.g:35:9: ']'
			{
			DebugLocation(35, 9);
			Match(']'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__51", 29);
			LeaveRule("T__51", 29);
			Leave_T__51();
		}
	}
	// $ANTLR end "T__51"

	partial void Enter_T__52();
	partial void Leave_T__52();

	// $ANTLR start "T__52"
	[GrammarRule("T__52")]
	private void mT__52()
	{
		Enter_T__52();
		EnterRule("T__52", 30);
		TraceIn("T__52", 30);
		try
		{
			int _type = T__52;
			int _channel = DefaultTokenChannel;
			// C.g:36:7: ( '*' )
			DebugEnterAlt(1);
			// C.g:36:9: '*'
			{
			DebugLocation(36, 9);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__52", 30);
			LeaveRule("T__52", 30);
			Leave_T__52();
		}
	}
	// $ANTLR end "T__52"

	partial void Enter_T__53();
	partial void Leave_T__53();

	// $ANTLR start "T__53"
	[GrammarRule("T__53")]
	private void mT__53()
	{
		Enter_T__53();
		EnterRule("T__53", 31);
		TraceIn("T__53", 31);
		try
		{
			int _type = T__53;
			int _channel = DefaultTokenChannel;
			// C.g:37:7: ( '...' )
			DebugEnterAlt(1);
			// C.g:37:9: '...'
			{
			DebugLocation(37, 9);
			Match("..."); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__53", 31);
			LeaveRule("T__53", 31);
			Leave_T__53();
		}
	}
	// $ANTLR end "T__53"

	partial void Enter_T__54();
	partial void Leave_T__54();

	// $ANTLR start "T__54"
	[GrammarRule("T__54")]
	private void mT__54()
	{
		Enter_T__54();
		EnterRule("T__54", 32);
		TraceIn("T__54", 32);
		try
		{
			int _type = T__54;
			int _channel = DefaultTokenChannel;
			// C.g:38:7: ( '+' )
			DebugEnterAlt(1);
			// C.g:38:9: '+'
			{
			DebugLocation(38, 9);
			Match('+'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__54", 32);
			LeaveRule("T__54", 32);
			Leave_T__54();
		}
	}
	// $ANTLR end "T__54"

	partial void Enter_T__55();
	partial void Leave_T__55();

	// $ANTLR start "T__55"
	[GrammarRule("T__55")]
	private void mT__55()
	{
		Enter_T__55();
		EnterRule("T__55", 33);
		TraceIn("T__55", 33);
		try
		{
			int _type = T__55;
			int _channel = DefaultTokenChannel;
			// C.g:39:7: ( '-' )
			DebugEnterAlt(1);
			// C.g:39:9: '-'
			{
			DebugLocation(39, 9);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__55", 33);
			LeaveRule("T__55", 33);
			Leave_T__55();
		}
	}
	// $ANTLR end "T__55"

	partial void Enter_T__56();
	partial void Leave_T__56();

	// $ANTLR start "T__56"
	[GrammarRule("T__56")]
	private void mT__56()
	{
		Enter_T__56();
		EnterRule("T__56", 34);
		TraceIn("T__56", 34);
		try
		{
			int _type = T__56;
			int _channel = DefaultTokenChannel;
			// C.g:40:7: ( '/' )
			DebugEnterAlt(1);
			// C.g:40:9: '/'
			{
			DebugLocation(40, 9);
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__56", 34);
			LeaveRule("T__56", 34);
			Leave_T__56();
		}
	}
	// $ANTLR end "T__56"

	partial void Enter_T__57();
	partial void Leave_T__57();

	// $ANTLR start "T__57"
	[GrammarRule("T__57")]
	private void mT__57()
	{
		Enter_T__57();
		EnterRule("T__57", 35);
		TraceIn("T__57", 35);
		try
		{
			int _type = T__57;
			int _channel = DefaultTokenChannel;
			// C.g:41:7: ( '%' )
			DebugEnterAlt(1);
			// C.g:41:9: '%'
			{
			DebugLocation(41, 9);
			Match('%'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__57", 35);
			LeaveRule("T__57", 35);
			Leave_T__57();
		}
	}
	// $ANTLR end "T__57"

	partial void Enter_T__58();
	partial void Leave_T__58();

	// $ANTLR start "T__58"
	[GrammarRule("T__58")]
	private void mT__58()
	{
		Enter_T__58();
		EnterRule("T__58", 36);
		TraceIn("T__58", 36);
		try
		{
			int _type = T__58;
			int _channel = DefaultTokenChannel;
			// C.g:42:7: ( '++' )
			DebugEnterAlt(1);
			// C.g:42:9: '++'
			{
			DebugLocation(42, 9);
			Match("++"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__58", 36);
			LeaveRule("T__58", 36);
			Leave_T__58();
		}
	}
	// $ANTLR end "T__58"

	partial void Enter_T__59();
	partial void Leave_T__59();

	// $ANTLR start "T__59"
	[GrammarRule("T__59")]
	private void mT__59()
	{
		Enter_T__59();
		EnterRule("T__59", 37);
		TraceIn("T__59", 37);
		try
		{
			int _type = T__59;
			int _channel = DefaultTokenChannel;
			// C.g:43:7: ( '--' )
			DebugEnterAlt(1);
			// C.g:43:9: '--'
			{
			DebugLocation(43, 9);
			Match("--"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__59", 37);
			LeaveRule("T__59", 37);
			Leave_T__59();
		}
	}
	// $ANTLR end "T__59"

	partial void Enter_T__60();
	partial void Leave_T__60();

	// $ANTLR start "T__60"
	[GrammarRule("T__60")]
	private void mT__60()
	{
		Enter_T__60();
		EnterRule("T__60", 38);
		TraceIn("T__60", 38);
		try
		{
			int _type = T__60;
			int _channel = DefaultTokenChannel;
			// C.g:44:7: ( 'sizeof' )
			DebugEnterAlt(1);
			// C.g:44:9: 'sizeof'
			{
			DebugLocation(44, 9);
			Match("sizeof"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__60", 38);
			LeaveRule("T__60", 38);
			Leave_T__60();
		}
	}
	// $ANTLR end "T__60"

	partial void Enter_T__61();
	partial void Leave_T__61();

	// $ANTLR start "T__61"
	[GrammarRule("T__61")]
	private void mT__61()
	{
		Enter_T__61();
		EnterRule("T__61", 39);
		TraceIn("T__61", 39);
		try
		{
			int _type = T__61;
			int _channel = DefaultTokenChannel;
			// C.g:45:7: ( '.' )
			DebugEnterAlt(1);
			// C.g:45:9: '.'
			{
			DebugLocation(45, 9);
			Match('.'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__61", 39);
			LeaveRule("T__61", 39);
			Leave_T__61();
		}
	}
	// $ANTLR end "T__61"

	partial void Enter_T__62();
	partial void Leave_T__62();

	// $ANTLR start "T__62"
	[GrammarRule("T__62")]
	private void mT__62()
	{
		Enter_T__62();
		EnterRule("T__62", 40);
		TraceIn("T__62", 40);
		try
		{
			int _type = T__62;
			int _channel = DefaultTokenChannel;
			// C.g:46:7: ( '->' )
			DebugEnterAlt(1);
			// C.g:46:9: '->'
			{
			DebugLocation(46, 9);
			Match("->"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__62", 40);
			LeaveRule("T__62", 40);
			Leave_T__62();
		}
	}
	// $ANTLR end "T__62"

	partial void Enter_T__63();
	partial void Leave_T__63();

	// $ANTLR start "T__63"
	[GrammarRule("T__63")]
	private void mT__63()
	{
		Enter_T__63();
		EnterRule("T__63", 41);
		TraceIn("T__63", 41);
		try
		{
			int _type = T__63;
			int _channel = DefaultTokenChannel;
			// C.g:47:7: ( '&' )
			DebugEnterAlt(1);
			// C.g:47:9: '&'
			{
			DebugLocation(47, 9);
			Match('&'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__63", 41);
			LeaveRule("T__63", 41);
			Leave_T__63();
		}
	}
	// $ANTLR end "T__63"

	partial void Enter_T__64();
	partial void Leave_T__64();

	// $ANTLR start "T__64"
	[GrammarRule("T__64")]
	private void mT__64()
	{
		Enter_T__64();
		EnterRule("T__64", 42);
		TraceIn("T__64", 42);
		try
		{
			int _type = T__64;
			int _channel = DefaultTokenChannel;
			// C.g:48:7: ( '~' )
			DebugEnterAlt(1);
			// C.g:48:9: '~'
			{
			DebugLocation(48, 9);
			Match('~'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__64", 42);
			LeaveRule("T__64", 42);
			Leave_T__64();
		}
	}
	// $ANTLR end "T__64"

	partial void Enter_T__65();
	partial void Leave_T__65();

	// $ANTLR start "T__65"
	[GrammarRule("T__65")]
	private void mT__65()
	{
		Enter_T__65();
		EnterRule("T__65", 43);
		TraceIn("T__65", 43);
		try
		{
			int _type = T__65;
			int _channel = DefaultTokenChannel;
			// C.g:49:7: ( '!' )
			DebugEnterAlt(1);
			// C.g:49:9: '!'
			{
			DebugLocation(49, 9);
			Match('!'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__65", 43);
			LeaveRule("T__65", 43);
			Leave_T__65();
		}
	}
	// $ANTLR end "T__65"

	partial void Enter_T__66();
	partial void Leave_T__66();

	// $ANTLR start "T__66"
	[GrammarRule("T__66")]
	private void mT__66()
	{
		Enter_T__66();
		EnterRule("T__66", 44);
		TraceIn("T__66", 44);
		try
		{
			int _type = T__66;
			int _channel = DefaultTokenChannel;
			// C.g:50:7: ( '*=' )
			DebugEnterAlt(1);
			// C.g:50:9: '*='
			{
			DebugLocation(50, 9);
			Match("*="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__66", 44);
			LeaveRule("T__66", 44);
			Leave_T__66();
		}
	}
	// $ANTLR end "T__66"

	partial void Enter_T__67();
	partial void Leave_T__67();

	// $ANTLR start "T__67"
	[GrammarRule("T__67")]
	private void mT__67()
	{
		Enter_T__67();
		EnterRule("T__67", 45);
		TraceIn("T__67", 45);
		try
		{
			int _type = T__67;
			int _channel = DefaultTokenChannel;
			// C.g:51:7: ( '/=' )
			DebugEnterAlt(1);
			// C.g:51:9: '/='
			{
			DebugLocation(51, 9);
			Match("/="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__67", 45);
			LeaveRule("T__67", 45);
			Leave_T__67();
		}
	}
	// $ANTLR end "T__67"

	partial void Enter_T__68();
	partial void Leave_T__68();

	// $ANTLR start "T__68"
	[GrammarRule("T__68")]
	private void mT__68()
	{
		Enter_T__68();
		EnterRule("T__68", 46);
		TraceIn("T__68", 46);
		try
		{
			int _type = T__68;
			int _channel = DefaultTokenChannel;
			// C.g:52:7: ( '%=' )
			DebugEnterAlt(1);
			// C.g:52:9: '%='
			{
			DebugLocation(52, 9);
			Match("%="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__68", 46);
			LeaveRule("T__68", 46);
			Leave_T__68();
		}
	}
	// $ANTLR end "T__68"

	partial void Enter_T__69();
	partial void Leave_T__69();

	// $ANTLR start "T__69"
	[GrammarRule("T__69")]
	private void mT__69()
	{
		Enter_T__69();
		EnterRule("T__69", 47);
		TraceIn("T__69", 47);
		try
		{
			int _type = T__69;
			int _channel = DefaultTokenChannel;
			// C.g:53:7: ( '+=' )
			DebugEnterAlt(1);
			// C.g:53:9: '+='
			{
			DebugLocation(53, 9);
			Match("+="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__69", 47);
			LeaveRule("T__69", 47);
			Leave_T__69();
		}
	}
	// $ANTLR end "T__69"

	partial void Enter_T__70();
	partial void Leave_T__70();

	// $ANTLR start "T__70"
	[GrammarRule("T__70")]
	private void mT__70()
	{
		Enter_T__70();
		EnterRule("T__70", 48);
		TraceIn("T__70", 48);
		try
		{
			int _type = T__70;
			int _channel = DefaultTokenChannel;
			// C.g:54:7: ( '-=' )
			DebugEnterAlt(1);
			// C.g:54:9: '-='
			{
			DebugLocation(54, 9);
			Match("-="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__70", 48);
			LeaveRule("T__70", 48);
			Leave_T__70();
		}
	}
	// $ANTLR end "T__70"

	partial void Enter_T__71();
	partial void Leave_T__71();

	// $ANTLR start "T__71"
	[GrammarRule("T__71")]
	private void mT__71()
	{
		Enter_T__71();
		EnterRule("T__71", 49);
		TraceIn("T__71", 49);
		try
		{
			int _type = T__71;
			int _channel = DefaultTokenChannel;
			// C.g:55:7: ( '<<=' )
			DebugEnterAlt(1);
			// C.g:55:9: '<<='
			{
			DebugLocation(55, 9);
			Match("<<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__71", 49);
			LeaveRule("T__71", 49);
			Leave_T__71();
		}
	}
	// $ANTLR end "T__71"

	partial void Enter_T__72();
	partial void Leave_T__72();

	// $ANTLR start "T__72"
	[GrammarRule("T__72")]
	private void mT__72()
	{
		Enter_T__72();
		EnterRule("T__72", 50);
		TraceIn("T__72", 50);
		try
		{
			int _type = T__72;
			int _channel = DefaultTokenChannel;
			// C.g:56:7: ( '>>=' )
			DebugEnterAlt(1);
			// C.g:56:9: '>>='
			{
			DebugLocation(56, 9);
			Match(">>="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__72", 50);
			LeaveRule("T__72", 50);
			Leave_T__72();
		}
	}
	// $ANTLR end "T__72"

	partial void Enter_T__73();
	partial void Leave_T__73();

	// $ANTLR start "T__73"
	[GrammarRule("T__73")]
	private void mT__73()
	{
		Enter_T__73();
		EnterRule("T__73", 51);
		TraceIn("T__73", 51);
		try
		{
			int _type = T__73;
			int _channel = DefaultTokenChannel;
			// C.g:57:7: ( '&=' )
			DebugEnterAlt(1);
			// C.g:57:9: '&='
			{
			DebugLocation(57, 9);
			Match("&="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__73", 51);
			LeaveRule("T__73", 51);
			Leave_T__73();
		}
	}
	// $ANTLR end "T__73"

	partial void Enter_T__74();
	partial void Leave_T__74();

	// $ANTLR start "T__74"
	[GrammarRule("T__74")]
	private void mT__74()
	{
		Enter_T__74();
		EnterRule("T__74", 52);
		TraceIn("T__74", 52);
		try
		{
			int _type = T__74;
			int _channel = DefaultTokenChannel;
			// C.g:58:7: ( '^=' )
			DebugEnterAlt(1);
			// C.g:58:9: '^='
			{
			DebugLocation(58, 9);
			Match("^="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__74", 52);
			LeaveRule("T__74", 52);
			Leave_T__74();
		}
	}
	// $ANTLR end "T__74"

	partial void Enter_T__75();
	partial void Leave_T__75();

	// $ANTLR start "T__75"
	[GrammarRule("T__75")]
	private void mT__75()
	{
		Enter_T__75();
		EnterRule("T__75", 53);
		TraceIn("T__75", 53);
		try
		{
			int _type = T__75;
			int _channel = DefaultTokenChannel;
			// C.g:59:7: ( '|=' )
			DebugEnterAlt(1);
			// C.g:59:9: '|='
			{
			DebugLocation(59, 9);
			Match("|="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__75", 53);
			LeaveRule("T__75", 53);
			Leave_T__75();
		}
	}
	// $ANTLR end "T__75"

	partial void Enter_T__76();
	partial void Leave_T__76();

	// $ANTLR start "T__76"
	[GrammarRule("T__76")]
	private void mT__76()
	{
		Enter_T__76();
		EnterRule("T__76", 54);
		TraceIn("T__76", 54);
		try
		{
			int _type = T__76;
			int _channel = DefaultTokenChannel;
			// C.g:60:7: ( '?' )
			DebugEnterAlt(1);
			// C.g:60:9: '?'
			{
			DebugLocation(60, 9);
			Match('?'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__76", 54);
			LeaveRule("T__76", 54);
			Leave_T__76();
		}
	}
	// $ANTLR end "T__76"

	partial void Enter_T__77();
	partial void Leave_T__77();

	// $ANTLR start "T__77"
	[GrammarRule("T__77")]
	private void mT__77()
	{
		Enter_T__77();
		EnterRule("T__77", 55);
		TraceIn("T__77", 55);
		try
		{
			int _type = T__77;
			int _channel = DefaultTokenChannel;
			// C.g:61:7: ( '||' )
			DebugEnterAlt(1);
			// C.g:61:9: '||'
			{
			DebugLocation(61, 9);
			Match("||"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__77", 55);
			LeaveRule("T__77", 55);
			Leave_T__77();
		}
	}
	// $ANTLR end "T__77"

	partial void Enter_T__78();
	partial void Leave_T__78();

	// $ANTLR start "T__78"
	[GrammarRule("T__78")]
	private void mT__78()
	{
		Enter_T__78();
		EnterRule("T__78", 56);
		TraceIn("T__78", 56);
		try
		{
			int _type = T__78;
			int _channel = DefaultTokenChannel;
			// C.g:62:7: ( '&&' )
			DebugEnterAlt(1);
			// C.g:62:9: '&&'
			{
			DebugLocation(62, 9);
			Match("&&"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__78", 56);
			LeaveRule("T__78", 56);
			Leave_T__78();
		}
	}
	// $ANTLR end "T__78"

	partial void Enter_T__79();
	partial void Leave_T__79();

	// $ANTLR start "T__79"
	[GrammarRule("T__79")]
	private void mT__79()
	{
		Enter_T__79();
		EnterRule("T__79", 57);
		TraceIn("T__79", 57);
		try
		{
			int _type = T__79;
			int _channel = DefaultTokenChannel;
			// C.g:63:7: ( '|' )
			DebugEnterAlt(1);
			// C.g:63:9: '|'
			{
			DebugLocation(63, 9);
			Match('|'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__79", 57);
			LeaveRule("T__79", 57);
			Leave_T__79();
		}
	}
	// $ANTLR end "T__79"

	partial void Enter_T__80();
	partial void Leave_T__80();

	// $ANTLR start "T__80"
	[GrammarRule("T__80")]
	private void mT__80()
	{
		Enter_T__80();
		EnterRule("T__80", 58);
		TraceIn("T__80", 58);
		try
		{
			int _type = T__80;
			int _channel = DefaultTokenChannel;
			// C.g:64:7: ( '^' )
			DebugEnterAlt(1);
			// C.g:64:9: '^'
			{
			DebugLocation(64, 9);
			Match('^'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__80", 58);
			LeaveRule("T__80", 58);
			Leave_T__80();
		}
	}
	// $ANTLR end "T__80"

	partial void Enter_T__81();
	partial void Leave_T__81();

	// $ANTLR start "T__81"
	[GrammarRule("T__81")]
	private void mT__81()
	{
		Enter_T__81();
		EnterRule("T__81", 59);
		TraceIn("T__81", 59);
		try
		{
			int _type = T__81;
			int _channel = DefaultTokenChannel;
			// C.g:65:7: ( '==' )
			DebugEnterAlt(1);
			// C.g:65:9: '=='
			{
			DebugLocation(65, 9);
			Match("=="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__81", 59);
			LeaveRule("T__81", 59);
			Leave_T__81();
		}
	}
	// $ANTLR end "T__81"

	partial void Enter_T__82();
	partial void Leave_T__82();

	// $ANTLR start "T__82"
	[GrammarRule("T__82")]
	private void mT__82()
	{
		Enter_T__82();
		EnterRule("T__82", 60);
		TraceIn("T__82", 60);
		try
		{
			int _type = T__82;
			int _channel = DefaultTokenChannel;
			// C.g:66:7: ( '!=' )
			DebugEnterAlt(1);
			// C.g:66:9: '!='
			{
			DebugLocation(66, 9);
			Match("!="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__82", 60);
			LeaveRule("T__82", 60);
			Leave_T__82();
		}
	}
	// $ANTLR end "T__82"

	partial void Enter_T__83();
	partial void Leave_T__83();

	// $ANTLR start "T__83"
	[GrammarRule("T__83")]
	private void mT__83()
	{
		Enter_T__83();
		EnterRule("T__83", 61);
		TraceIn("T__83", 61);
		try
		{
			int _type = T__83;
			int _channel = DefaultTokenChannel;
			// C.g:67:7: ( '<' )
			DebugEnterAlt(1);
			// C.g:67:9: '<'
			{
			DebugLocation(67, 9);
			Match('<'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__83", 61);
			LeaveRule("T__83", 61);
			Leave_T__83();
		}
	}
	// $ANTLR end "T__83"

	partial void Enter_T__84();
	partial void Leave_T__84();

	// $ANTLR start "T__84"
	[GrammarRule("T__84")]
	private void mT__84()
	{
		Enter_T__84();
		EnterRule("T__84", 62);
		TraceIn("T__84", 62);
		try
		{
			int _type = T__84;
			int _channel = DefaultTokenChannel;
			// C.g:68:7: ( '>' )
			DebugEnterAlt(1);
			// C.g:68:9: '>'
			{
			DebugLocation(68, 9);
			Match('>'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__84", 62);
			LeaveRule("T__84", 62);
			Leave_T__84();
		}
	}
	// $ANTLR end "T__84"

	partial void Enter_T__85();
	partial void Leave_T__85();

	// $ANTLR start "T__85"
	[GrammarRule("T__85")]
	private void mT__85()
	{
		Enter_T__85();
		EnterRule("T__85", 63);
		TraceIn("T__85", 63);
		try
		{
			int _type = T__85;
			int _channel = DefaultTokenChannel;
			// C.g:69:7: ( '<=' )
			DebugEnterAlt(1);
			// C.g:69:9: '<='
			{
			DebugLocation(69, 9);
			Match("<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__85", 63);
			LeaveRule("T__85", 63);
			Leave_T__85();
		}
	}
	// $ANTLR end "T__85"

	partial void Enter_T__86();
	partial void Leave_T__86();

	// $ANTLR start "T__86"
	[GrammarRule("T__86")]
	private void mT__86()
	{
		Enter_T__86();
		EnterRule("T__86", 64);
		TraceIn("T__86", 64);
		try
		{
			int _type = T__86;
			int _channel = DefaultTokenChannel;
			// C.g:70:7: ( '>=' )
			DebugEnterAlt(1);
			// C.g:70:9: '>='
			{
			DebugLocation(70, 9);
			Match(">="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__86", 64);
			LeaveRule("T__86", 64);
			Leave_T__86();
		}
	}
	// $ANTLR end "T__86"

	partial void Enter_T__87();
	partial void Leave_T__87();

	// $ANTLR start "T__87"
	[GrammarRule("T__87")]
	private void mT__87()
	{
		Enter_T__87();
		EnterRule("T__87", 65);
		TraceIn("T__87", 65);
		try
		{
			int _type = T__87;
			int _channel = DefaultTokenChannel;
			// C.g:71:7: ( '<<' )
			DebugEnterAlt(1);
			// C.g:71:9: '<<'
			{
			DebugLocation(71, 9);
			Match("<<"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__87", 65);
			LeaveRule("T__87", 65);
			Leave_T__87();
		}
	}
	// $ANTLR end "T__87"

	partial void Enter_T__88();
	partial void Leave_T__88();

	// $ANTLR start "T__88"
	[GrammarRule("T__88")]
	private void mT__88()
	{
		Enter_T__88();
		EnterRule("T__88", 66);
		TraceIn("T__88", 66);
		try
		{
			int _type = T__88;
			int _channel = DefaultTokenChannel;
			// C.g:72:7: ( '>>' )
			DebugEnterAlt(1);
			// C.g:72:9: '>>'
			{
			DebugLocation(72, 9);
			Match(">>"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__88", 66);
			LeaveRule("T__88", 66);
			Leave_T__88();
		}
	}
	// $ANTLR end "T__88"

	partial void Enter_T__89();
	partial void Leave_T__89();

	// $ANTLR start "T__89"
	[GrammarRule("T__89")]
	private void mT__89()
	{
		Enter_T__89();
		EnterRule("T__89", 67);
		TraceIn("T__89", 67);
		try
		{
			int _type = T__89;
			int _channel = DefaultTokenChannel;
			// C.g:73:7: ( 'case' )
			DebugEnterAlt(1);
			// C.g:73:9: 'case'
			{
			DebugLocation(73, 9);
			Match("case"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__89", 67);
			LeaveRule("T__89", 67);
			Leave_T__89();
		}
	}
	// $ANTLR end "T__89"

	partial void Enter_T__90();
	partial void Leave_T__90();

	// $ANTLR start "T__90"
	[GrammarRule("T__90")]
	private void mT__90()
	{
		Enter_T__90();
		EnterRule("T__90", 68);
		TraceIn("T__90", 68);
		try
		{
			int _type = T__90;
			int _channel = DefaultTokenChannel;
			// C.g:74:7: ( 'default' )
			DebugEnterAlt(1);
			// C.g:74:9: 'default'
			{
			DebugLocation(74, 9);
			Match("default"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__90", 68);
			LeaveRule("T__90", 68);
			Leave_T__90();
		}
	}
	// $ANTLR end "T__90"

	partial void Enter_T__91();
	partial void Leave_T__91();

	// $ANTLR start "T__91"
	[GrammarRule("T__91")]
	private void mT__91()
	{
		Enter_T__91();
		EnterRule("T__91", 69);
		TraceIn("T__91", 69);
		try
		{
			int _type = T__91;
			int _channel = DefaultTokenChannel;
			// C.g:75:7: ( 'if' )
			DebugEnterAlt(1);
			// C.g:75:9: 'if'
			{
			DebugLocation(75, 9);
			Match("if"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__91", 69);
			LeaveRule("T__91", 69);
			Leave_T__91();
		}
	}
	// $ANTLR end "T__91"

	partial void Enter_T__92();
	partial void Leave_T__92();

	// $ANTLR start "T__92"
	[GrammarRule("T__92")]
	private void mT__92()
	{
		Enter_T__92();
		EnterRule("T__92", 70);
		TraceIn("T__92", 70);
		try
		{
			int _type = T__92;
			int _channel = DefaultTokenChannel;
			// C.g:76:7: ( 'else' )
			DebugEnterAlt(1);
			// C.g:76:9: 'else'
			{
			DebugLocation(76, 9);
			Match("else"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__92", 70);
			LeaveRule("T__92", 70);
			Leave_T__92();
		}
	}
	// $ANTLR end "T__92"

	partial void Enter_T__93();
	partial void Leave_T__93();

	// $ANTLR start "T__93"
	[GrammarRule("T__93")]
	private void mT__93()
	{
		Enter_T__93();
		EnterRule("T__93", 71);
		TraceIn("T__93", 71);
		try
		{
			int _type = T__93;
			int _channel = DefaultTokenChannel;
			// C.g:77:7: ( 'switch' )
			DebugEnterAlt(1);
			// C.g:77:9: 'switch'
			{
			DebugLocation(77, 9);
			Match("switch"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__93", 71);
			LeaveRule("T__93", 71);
			Leave_T__93();
		}
	}
	// $ANTLR end "T__93"

	partial void Enter_T__94();
	partial void Leave_T__94();

	// $ANTLR start "T__94"
	[GrammarRule("T__94")]
	private void mT__94()
	{
		Enter_T__94();
		EnterRule("T__94", 72);
		TraceIn("T__94", 72);
		try
		{
			int _type = T__94;
			int _channel = DefaultTokenChannel;
			// C.g:78:7: ( 'while' )
			DebugEnterAlt(1);
			// C.g:78:9: 'while'
			{
			DebugLocation(78, 9);
			Match("while"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__94", 72);
			LeaveRule("T__94", 72);
			Leave_T__94();
		}
	}
	// $ANTLR end "T__94"

	partial void Enter_T__95();
	partial void Leave_T__95();

	// $ANTLR start "T__95"
	[GrammarRule("T__95")]
	private void mT__95()
	{
		Enter_T__95();
		EnterRule("T__95", 73);
		TraceIn("T__95", 73);
		try
		{
			int _type = T__95;
			int _channel = DefaultTokenChannel;
			// C.g:79:7: ( 'do' )
			DebugEnterAlt(1);
			// C.g:79:9: 'do'
			{
			DebugLocation(79, 9);
			Match("do"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__95", 73);
			LeaveRule("T__95", 73);
			Leave_T__95();
		}
	}
	// $ANTLR end "T__95"

	partial void Enter_T__96();
	partial void Leave_T__96();

	// $ANTLR start "T__96"
	[GrammarRule("T__96")]
	private void mT__96()
	{
		Enter_T__96();
		EnterRule("T__96", 74);
		TraceIn("T__96", 74);
		try
		{
			int _type = T__96;
			int _channel = DefaultTokenChannel;
			// C.g:80:7: ( 'for' )
			DebugEnterAlt(1);
			// C.g:80:9: 'for'
			{
			DebugLocation(80, 9);
			Match("for"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__96", 74);
			LeaveRule("T__96", 74);
			Leave_T__96();
		}
	}
	// $ANTLR end "T__96"

	partial void Enter_T__97();
	partial void Leave_T__97();

	// $ANTLR start "T__97"
	[GrammarRule("T__97")]
	private void mT__97()
	{
		Enter_T__97();
		EnterRule("T__97", 75);
		TraceIn("T__97", 75);
		try
		{
			int _type = T__97;
			int _channel = DefaultTokenChannel;
			// C.g:81:7: ( 'goto' )
			DebugEnterAlt(1);
			// C.g:81:9: 'goto'
			{
			DebugLocation(81, 9);
			Match("goto"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__97", 75);
			LeaveRule("T__97", 75);
			Leave_T__97();
		}
	}
	// $ANTLR end "T__97"

	partial void Enter_T__98();
	partial void Leave_T__98();

	// $ANTLR start "T__98"
	[GrammarRule("T__98")]
	private void mT__98()
	{
		Enter_T__98();
		EnterRule("T__98", 76);
		TraceIn("T__98", 76);
		try
		{
			int _type = T__98;
			int _channel = DefaultTokenChannel;
			// C.g:82:7: ( 'continue' )
			DebugEnterAlt(1);
			// C.g:82:9: 'continue'
			{
			DebugLocation(82, 9);
			Match("continue"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__98", 76);
			LeaveRule("T__98", 76);
			Leave_T__98();
		}
	}
	// $ANTLR end "T__98"

	partial void Enter_T__99();
	partial void Leave_T__99();

	// $ANTLR start "T__99"
	[GrammarRule("T__99")]
	private void mT__99()
	{
		Enter_T__99();
		EnterRule("T__99", 77);
		TraceIn("T__99", 77);
		try
		{
			int _type = T__99;
			int _channel = DefaultTokenChannel;
			// C.g:83:7: ( 'break' )
			DebugEnterAlt(1);
			// C.g:83:9: 'break'
			{
			DebugLocation(83, 9);
			Match("break"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__99", 77);
			LeaveRule("T__99", 77);
			Leave_T__99();
		}
	}
	// $ANTLR end "T__99"

	partial void Enter_T__100();
	partial void Leave_T__100();

	// $ANTLR start "T__100"
	[GrammarRule("T__100")]
	private void mT__100()
	{
		Enter_T__100();
		EnterRule("T__100", 78);
		TraceIn("T__100", 78);
		try
		{
			int _type = T__100;
			int _channel = DefaultTokenChannel;
			// C.g:84:8: ( 'return' )
			DebugEnterAlt(1);
			// C.g:84:10: 'return'
			{
			DebugLocation(84, 10);
			Match("return"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__100", 78);
			LeaveRule("T__100", 78);
			Leave_T__100();
		}
	}
	// $ANTLR end "T__100"

	partial void Enter_IDENTIFIER();
	partial void Leave_IDENTIFIER();

	// $ANTLR start "IDENTIFIER"
	[GrammarRule("IDENTIFIER")]
	private void mIDENTIFIER()
	{
		Enter_IDENTIFIER();
		EnterRule("IDENTIFIER", 79);
		TraceIn("IDENTIFIER", 79);
		try
		{
			int _type = IDENTIFIER;
			int _channel = DefaultTokenChannel;
			// C.g:494:2: ( LETTER ( LETTER | '0' .. '9' )* )
			DebugEnterAlt(1);
			// C.g:494:4: LETTER ( LETTER | '0' .. '9' )*
			{
			DebugLocation(494, 4);
			mLETTER(); 
			DebugLocation(494, 11);
			// C.g:494:11: ( LETTER | '0' .. '9' )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0=='$'||(LA1_0>='0' && LA1_0<='9')||(LA1_0>='A' && LA1_0<='Z')||LA1_0=='_'||(LA1_0>='a' && LA1_0<='z')))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:
					{
					DebugLocation(494, 11);
					if (input.LA(1)=='$'||(input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
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
			TraceOut("IDENTIFIER", 79);
			LeaveRule("IDENTIFIER", 79);
			Leave_IDENTIFIER();
		}
	}
	// $ANTLR end "IDENTIFIER"

	partial void Enter_LETTER();
	partial void Leave_LETTER();

	// $ANTLR start "LETTER"
	[GrammarRule("LETTER")]
	private void mLETTER()
	{
		Enter_LETTER();
		EnterRule("LETTER", 80);
		TraceIn("LETTER", 80);
		try
		{
			// C.g:499:2: ( '$' | 'A' .. 'Z' | 'a' .. 'z' | '_' )
			DebugEnterAlt(1);
			// C.g:
			{
			DebugLocation(499, 2);
			if (input.LA(1)=='$'||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
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
			TraceOut("LETTER", 80);
			LeaveRule("LETTER", 80);
			Leave_LETTER();
		}
	}
	// $ANTLR end "LETTER"

	partial void Enter_CHARACTER_LITERAL();
	partial void Leave_CHARACTER_LITERAL();

	// $ANTLR start "CHARACTER_LITERAL"
	[GrammarRule("CHARACTER_LITERAL")]
	private void mCHARACTER_LITERAL()
	{
		Enter_CHARACTER_LITERAL();
		EnterRule("CHARACTER_LITERAL", 81);
		TraceIn("CHARACTER_LITERAL", 81);
		try
		{
			int _type = CHARACTER_LITERAL;
			int _channel = DefaultTokenChannel;
			// C.g:506:5: ( '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) ) '\\'' )
			DebugEnterAlt(1);
			// C.g:506:9: '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) ) '\\''
			{
			DebugLocation(506, 9);
			Match('\''); 
			DebugLocation(506, 14);
			// C.g:506:14: ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )
			int alt2=2;
			try { DebugEnterSubRule(2);
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			int LA2_0 = input.LA(1);

			if ((LA2_0=='\\'))
			{
				alt2=1;
			}
			else if (((LA2_0>='\u0000' && LA2_0<='&')||(LA2_0>='(' && LA2_0<='[')||(LA2_0>=']' && LA2_0<='\uFFFF')))
			{
				alt2=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:506:16: EscapeSequence
				{
				DebugLocation(506, 16);
				mEscapeSequence(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:506:33: ~ ( '\\'' | '\\\\' )
				{
				DebugLocation(506, 33);
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

			}
			} finally { DebugExitSubRule(2); }

			DebugLocation(506, 48);
			Match('\''); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CHARACTER_LITERAL", 81);
			LeaveRule("CHARACTER_LITERAL", 81);
			Leave_CHARACTER_LITERAL();
		}
	}
	// $ANTLR end "CHARACTER_LITERAL"

	partial void Enter_STRING_LITERAL();
	partial void Leave_STRING_LITERAL();

	// $ANTLR start "STRING_LITERAL"
	[GrammarRule("STRING_LITERAL")]
	private void mSTRING_LITERAL()
	{
		Enter_STRING_LITERAL();
		EnterRule("STRING_LITERAL", 82);
		TraceIn("STRING_LITERAL", 82);
		try
		{
			int _type = STRING_LITERAL;
			int _channel = DefaultTokenChannel;
			// C.g:510:5: ( '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"' )
			DebugEnterAlt(1);
			// C.g:510:8: '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"'
			{
			DebugLocation(510, 8);
			Match('\"'); 
			DebugLocation(510, 12);
			// C.g:510:12: ( EscapeSequence | ~ ( '\\\\' | '\"' ) )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=3;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0=='\\'))
				{
					alt3=1;
				}
				else if (((LA3_0>='\u0000' && LA3_0<='!')||(LA3_0>='#' && LA3_0<='[')||(LA3_0>=']' && LA3_0<='\uFFFF')))
				{
					alt3=2;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:510:14: EscapeSequence
					{
					DebugLocation(510, 14);
					mEscapeSequence(); 

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C.g:510:31: ~ ( '\\\\' | '\"' )
					{
					DebugLocation(510, 31);
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
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }

			DebugLocation(510, 46);
			Match('\"'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("STRING_LITERAL", 82);
			LeaveRule("STRING_LITERAL", 82);
			Leave_STRING_LITERAL();
		}
	}
	// $ANTLR end "STRING_LITERAL"

	partial void Enter_HEX_LITERAL();
	partial void Leave_HEX_LITERAL();

	// $ANTLR start "HEX_LITERAL"
	[GrammarRule("HEX_LITERAL")]
	private void mHEX_LITERAL()
	{
		Enter_HEX_LITERAL();
		EnterRule("HEX_LITERAL", 83);
		TraceIn("HEX_LITERAL", 83);
		try
		{
			int _type = HEX_LITERAL;
			int _channel = DefaultTokenChannel;
			// C.g:513:13: ( '0' ( 'x' | 'X' ) ( HexDigit )+ ( IntegerTypeSuffix )? )
			DebugEnterAlt(1);
			// C.g:513:15: '0' ( 'x' | 'X' ) ( HexDigit )+ ( IntegerTypeSuffix )?
			{
			DebugLocation(513, 15);
			Match('0'); 
			DebugLocation(513, 19);
			if (input.LA(1)=='X'||input.LA(1)=='x')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}

			DebugLocation(513, 29);
			// C.g:513:29: ( HexDigit )+
			int cnt4=0;
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, decisionCanBacktrack[4]);
				int LA4_0 = input.LA(1);

				if (((LA4_0>='0' && LA4_0<='9')||(LA4_0>='A' && LA4_0<='F')||(LA4_0>='a' && LA4_0<='f')))
				{
					alt4=1;
				}


				} finally { DebugExitDecision(4); }
				switch (alt4)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:513:29: HexDigit
					{
					DebugLocation(513, 29);
					mHexDigit(); 

					}
					break;

				default:
					if (cnt4 >= 1)
						goto loop4;

					EarlyExitException eee4 = new EarlyExitException( 4, input );
					DebugRecognitionException(eee4);
					throw eee4;
				}
				cnt4++;
			}
			loop4:
				;

			} finally { DebugExitSubRule(4); }

			DebugLocation(513, 39);
			// C.g:513:39: ( IntegerTypeSuffix )?
			int alt5=2;
			try { DebugEnterSubRule(5);
			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
			int LA5_0 = input.LA(1);

			if ((LA5_0=='L'||LA5_0=='U'||LA5_0=='l'||LA5_0=='u'))
			{
				alt5=1;
			}
			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:513:39: IntegerTypeSuffix
				{
				DebugLocation(513, 39);
				mIntegerTypeSuffix(); 

				}
				break;

			}
			} finally { DebugExitSubRule(5); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("HEX_LITERAL", 83);
			LeaveRule("HEX_LITERAL", 83);
			Leave_HEX_LITERAL();
		}
	}
	// $ANTLR end "HEX_LITERAL"

	partial void Enter_DECIMAL_LITERAL();
	partial void Leave_DECIMAL_LITERAL();

	// $ANTLR start "DECIMAL_LITERAL"
	[GrammarRule("DECIMAL_LITERAL")]
	private void mDECIMAL_LITERAL()
	{
		Enter_DECIMAL_LITERAL();
		EnterRule("DECIMAL_LITERAL", 84);
		TraceIn("DECIMAL_LITERAL", 84);
		try
		{
			int _type = DECIMAL_LITERAL;
			int _channel = DefaultTokenChannel;
			// C.g:515:17: ( ( '0' | '1' .. '9' ( '0' .. '9' )* ) ( IntegerTypeSuffix )? )
			DebugEnterAlt(1);
			// C.g:515:19: ( '0' | '1' .. '9' ( '0' .. '9' )* ) ( IntegerTypeSuffix )?
			{
			DebugLocation(515, 19);
			// C.g:515:19: ( '0' | '1' .. '9' ( '0' .. '9' )* )
			int alt7=2;
			try { DebugEnterSubRule(7);
			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
			int LA7_0 = input.LA(1);

			if ((LA7_0=='0'))
			{
				alt7=1;
			}
			else if (((LA7_0>='1' && LA7_0<='9')))
			{
				alt7=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 7, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:515:20: '0'
				{
				DebugLocation(515, 20);
				Match('0'); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:515:26: '1' .. '9' ( '0' .. '9' )*
				{
				DebugLocation(515, 26);
				MatchRange('1','9'); 
				DebugLocation(515, 35);
				// C.g:515:35: ( '0' .. '9' )*
				try { DebugEnterSubRule(6);
				while (true)
				{
					int alt6=2;
					try { DebugEnterDecision(6, decisionCanBacktrack[6]);
					int LA6_0 = input.LA(1);

					if (((LA6_0>='0' && LA6_0<='9')))
					{
						alt6=1;
					}


					} finally { DebugExitDecision(6); }
					switch ( alt6 )
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:515:35: '0' .. '9'
						{
						DebugLocation(515, 35);
						MatchRange('0','9'); 

						}
						break;

					default:
						goto loop6;
					}
				}

				loop6:
					;

				} finally { DebugExitSubRule(6); }


				}
				break;

			}
			} finally { DebugExitSubRule(7); }

			DebugLocation(515, 46);
			// C.g:515:46: ( IntegerTypeSuffix )?
			int alt8=2;
			try { DebugEnterSubRule(8);
			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
			int LA8_0 = input.LA(1);

			if ((LA8_0=='L'||LA8_0=='U'||LA8_0=='l'||LA8_0=='u'))
			{
				alt8=1;
			}
			} finally { DebugExitDecision(8); }
			switch (alt8)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:515:46: IntegerTypeSuffix
				{
				DebugLocation(515, 46);
				mIntegerTypeSuffix(); 

				}
				break;

			}
			} finally { DebugExitSubRule(8); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DECIMAL_LITERAL", 84);
			LeaveRule("DECIMAL_LITERAL", 84);
			Leave_DECIMAL_LITERAL();
		}
	}
	// $ANTLR end "DECIMAL_LITERAL"

	partial void Enter_OCTAL_LITERAL();
	partial void Leave_OCTAL_LITERAL();

	// $ANTLR start "OCTAL_LITERAL"
	[GrammarRule("OCTAL_LITERAL")]
	private void mOCTAL_LITERAL()
	{
		Enter_OCTAL_LITERAL();
		EnterRule("OCTAL_LITERAL", 85);
		TraceIn("OCTAL_LITERAL", 85);
		try
		{
			int _type = OCTAL_LITERAL;
			int _channel = DefaultTokenChannel;
			// C.g:517:15: ( '0' ( '0' .. '7' )+ ( IntegerTypeSuffix )? )
			DebugEnterAlt(1);
			// C.g:517:17: '0' ( '0' .. '7' )+ ( IntegerTypeSuffix )?
			{
			DebugLocation(517, 17);
			Match('0'); 
			DebugLocation(517, 21);
			// C.g:517:21: ( '0' .. '7' )+
			int cnt9=0;
			try { DebugEnterSubRule(9);
			while (true)
			{
				int alt9=2;
				try { DebugEnterDecision(9, decisionCanBacktrack[9]);
				int LA9_0 = input.LA(1);

				if (((LA9_0>='0' && LA9_0<='7')))
				{
					alt9=1;
				}


				} finally { DebugExitDecision(9); }
				switch (alt9)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:517:22: '0' .. '7'
					{
					DebugLocation(517, 22);
					MatchRange('0','7'); 

					}
					break;

				default:
					if (cnt9 >= 1)
						goto loop9;

					EarlyExitException eee9 = new EarlyExitException( 9, input );
					DebugRecognitionException(eee9);
					throw eee9;
				}
				cnt9++;
			}
			loop9:
				;

			} finally { DebugExitSubRule(9); }

			DebugLocation(517, 33);
			// C.g:517:33: ( IntegerTypeSuffix )?
			int alt10=2;
			try { DebugEnterSubRule(10);
			try { DebugEnterDecision(10, decisionCanBacktrack[10]);
			int LA10_0 = input.LA(1);

			if ((LA10_0=='L'||LA10_0=='U'||LA10_0=='l'||LA10_0=='u'))
			{
				alt10=1;
			}
			} finally { DebugExitDecision(10); }
			switch (alt10)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:517:33: IntegerTypeSuffix
				{
				DebugLocation(517, 33);
				mIntegerTypeSuffix(); 

				}
				break;

			}
			} finally { DebugExitSubRule(10); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("OCTAL_LITERAL", 85);
			LeaveRule("OCTAL_LITERAL", 85);
			Leave_OCTAL_LITERAL();
		}
	}
	// $ANTLR end "OCTAL_LITERAL"

	partial void Enter_HexDigit();
	partial void Leave_HexDigit();

	// $ANTLR start "HexDigit"
	[GrammarRule("HexDigit")]
	private void mHexDigit()
	{
		Enter_HexDigit();
		EnterRule("HexDigit", 86);
		TraceIn("HexDigit", 86);
		try
		{
			// C.g:520:10: ( ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' ) )
			DebugEnterAlt(1);
			// C.g:520:12: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )
			{
			DebugLocation(520, 12);
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
			TraceOut("HexDigit", 86);
			LeaveRule("HexDigit", 86);
			Leave_HexDigit();
		}
	}
	// $ANTLR end "HexDigit"

	partial void Enter_IntegerTypeSuffix();
	partial void Leave_IntegerTypeSuffix();

	// $ANTLR start "IntegerTypeSuffix"
	[GrammarRule("IntegerTypeSuffix")]
	private void mIntegerTypeSuffix()
	{
		Enter_IntegerTypeSuffix();
		EnterRule("IntegerTypeSuffix", 87);
		TraceIn("IntegerTypeSuffix", 87);
		try
		{
			// C.g:524:2: ( ( 'u' | 'U' )? ( 'l' | 'L' ) | ( 'u' | 'U' ) ( 'l' | 'L' )? )
			int alt13=2;
			try { DebugEnterDecision(13, decisionCanBacktrack[13]);
			int LA13_0 = input.LA(1);

			if ((LA13_0=='U'||LA13_0=='u'))
			{
				int LA13_1 = input.LA(2);

				if ((LA13_1=='L'||LA13_1=='l'))
				{
					alt13=1;
				}
				else
				{
					alt13=2;}
			}
			else if ((LA13_0=='L'||LA13_0=='l'))
			{
				alt13=1;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 13, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(13); }
			switch (alt13)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:524:4: ( 'u' | 'U' )? ( 'l' | 'L' )
				{
				DebugLocation(524, 4);
				// C.g:524:4: ( 'u' | 'U' )?
				int alt11=2;
				try { DebugEnterSubRule(11);
				try { DebugEnterDecision(11, decisionCanBacktrack[11]);
				int LA11_0 = input.LA(1);

				if ((LA11_0=='U'||LA11_0=='u'))
				{
					alt11=1;
				}
				} finally { DebugExitDecision(11); }
				switch (alt11)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:
					{
					DebugLocation(524, 4);
					if (input.LA(1)=='U'||input.LA(1)=='u')
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

				}
				} finally { DebugExitSubRule(11); }

				DebugLocation(524, 15);
				if (input.LA(1)=='L'||input.LA(1)=='l')
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
				// C.g:525:4: ( 'u' | 'U' ) ( 'l' | 'L' )?
				{
				DebugLocation(525, 4);
				if (input.LA(1)=='U'||input.LA(1)=='u')
				{
					input.Consume();

				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					Recover(mse);
					throw mse;}

				DebugLocation(525, 15);
				// C.g:525:15: ( 'l' | 'L' )?
				int alt12=2;
				try { DebugEnterSubRule(12);
				try { DebugEnterDecision(12, decisionCanBacktrack[12]);
				int LA12_0 = input.LA(1);

				if ((LA12_0=='L'||LA12_0=='l'))
				{
					alt12=1;
				}
				} finally { DebugExitDecision(12); }
				switch (alt12)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:
					{
					DebugLocation(525, 15);
					if (input.LA(1)=='L'||input.LA(1)=='l')
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

				}
				} finally { DebugExitSubRule(12); }


				}
				break;

			}
		}
		finally
		{
			TraceOut("IntegerTypeSuffix", 87);
			LeaveRule("IntegerTypeSuffix", 87);
			Leave_IntegerTypeSuffix();
		}
	}
	// $ANTLR end "IntegerTypeSuffix"

	partial void Enter_FLOATING_POINT_LITERAL();
	partial void Leave_FLOATING_POINT_LITERAL();

	// $ANTLR start "FLOATING_POINT_LITERAL"
	[GrammarRule("FLOATING_POINT_LITERAL")]
	private void mFLOATING_POINT_LITERAL()
	{
		Enter_FLOATING_POINT_LITERAL();
		EnterRule("FLOATING_POINT_LITERAL", 88);
		TraceIn("FLOATING_POINT_LITERAL", 88);
		try
		{
			int _type = FLOATING_POINT_LITERAL;
			int _channel = DefaultTokenChannel;
			// C.g:529:5: ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )? | '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )? | ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )? | ( '0' .. '9' )+ ( Exponent )? FloatTypeSuffix )
			int alt25=4;
			try { DebugEnterDecision(25, decisionCanBacktrack[25]);
			try
			{
				alt25 = dfa25.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(25); }
			switch (alt25)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:529:9: ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )?
				{
				DebugLocation(529, 9);
				// C.g:529:9: ( '0' .. '9' )+
				int cnt14=0;
				try { DebugEnterSubRule(14);
				while (true)
				{
					int alt14=2;
					try { DebugEnterDecision(14, decisionCanBacktrack[14]);
					int LA14_0 = input.LA(1);

					if (((LA14_0>='0' && LA14_0<='9')))
					{
						alt14=1;
					}


					} finally { DebugExitDecision(14); }
					switch (alt14)
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:529:10: '0' .. '9'
						{
						DebugLocation(529, 10);
						MatchRange('0','9'); 

						}
						break;

					default:
						if (cnt14 >= 1)
							goto loop14;

						EarlyExitException eee14 = new EarlyExitException( 14, input );
						DebugRecognitionException(eee14);
						throw eee14;
					}
					cnt14++;
				}
				loop14:
					;

				} finally { DebugExitSubRule(14); }

				DebugLocation(529, 21);
				Match('.'); 
				DebugLocation(529, 25);
				// C.g:529:25: ( '0' .. '9' )*
				try { DebugEnterSubRule(15);
				while (true)
				{
					int alt15=2;
					try { DebugEnterDecision(15, decisionCanBacktrack[15]);
					int LA15_0 = input.LA(1);

					if (((LA15_0>='0' && LA15_0<='9')))
					{
						alt15=1;
					}


					} finally { DebugExitDecision(15); }
					switch ( alt15 )
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:529:26: '0' .. '9'
						{
						DebugLocation(529, 26);
						MatchRange('0','9'); 

						}
						break;

					default:
						goto loop15;
					}
				}

				loop15:
					;

				} finally { DebugExitSubRule(15); }

				DebugLocation(529, 37);
				// C.g:529:37: ( Exponent )?
				int alt16=2;
				try { DebugEnterSubRule(16);
				try { DebugEnterDecision(16, decisionCanBacktrack[16]);
				int LA16_0 = input.LA(1);

				if ((LA16_0=='E'||LA16_0=='e'))
				{
					alt16=1;
				}
				} finally { DebugExitDecision(16); }
				switch (alt16)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:529:37: Exponent
					{
					DebugLocation(529, 37);
					mExponent(); 

					}
					break;

				}
				} finally { DebugExitSubRule(16); }

				DebugLocation(529, 47);
				// C.g:529:47: ( FloatTypeSuffix )?
				int alt17=2;
				try { DebugEnterSubRule(17);
				try { DebugEnterDecision(17, decisionCanBacktrack[17]);
				int LA17_0 = input.LA(1);

				if ((LA17_0=='D'||LA17_0=='F'||LA17_0=='d'||LA17_0=='f'))
				{
					alt17=1;
				}
				} finally { DebugExitDecision(17); }
				switch (alt17)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:529:47: FloatTypeSuffix
					{
					DebugLocation(529, 47);
					mFloatTypeSuffix(); 

					}
					break;

				}
				} finally { DebugExitSubRule(17); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:530:9: '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )?
				{
				DebugLocation(530, 9);
				Match('.'); 
				DebugLocation(530, 13);
				// C.g:530:13: ( '0' .. '9' )+
				int cnt18=0;
				try { DebugEnterSubRule(18);
				while (true)
				{
					int alt18=2;
					try { DebugEnterDecision(18, decisionCanBacktrack[18]);
					int LA18_0 = input.LA(1);

					if (((LA18_0>='0' && LA18_0<='9')))
					{
						alt18=1;
					}


					} finally { DebugExitDecision(18); }
					switch (alt18)
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:530:14: '0' .. '9'
						{
						DebugLocation(530, 14);
						MatchRange('0','9'); 

						}
						break;

					default:
						if (cnt18 >= 1)
							goto loop18;

						EarlyExitException eee18 = new EarlyExitException( 18, input );
						DebugRecognitionException(eee18);
						throw eee18;
					}
					cnt18++;
				}
				loop18:
					;

				} finally { DebugExitSubRule(18); }

				DebugLocation(530, 25);
				// C.g:530:25: ( Exponent )?
				int alt19=2;
				try { DebugEnterSubRule(19);
				try { DebugEnterDecision(19, decisionCanBacktrack[19]);
				int LA19_0 = input.LA(1);

				if ((LA19_0=='E'||LA19_0=='e'))
				{
					alt19=1;
				}
				} finally { DebugExitDecision(19); }
				switch (alt19)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:530:25: Exponent
					{
					DebugLocation(530, 25);
					mExponent(); 

					}
					break;

				}
				} finally { DebugExitSubRule(19); }

				DebugLocation(530, 35);
				// C.g:530:35: ( FloatTypeSuffix )?
				int alt20=2;
				try { DebugEnterSubRule(20);
				try { DebugEnterDecision(20, decisionCanBacktrack[20]);
				int LA20_0 = input.LA(1);

				if ((LA20_0=='D'||LA20_0=='F'||LA20_0=='d'||LA20_0=='f'))
				{
					alt20=1;
				}
				} finally { DebugExitDecision(20); }
				switch (alt20)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:530:35: FloatTypeSuffix
					{
					DebugLocation(530, 35);
					mFloatTypeSuffix(); 

					}
					break;

				}
				} finally { DebugExitSubRule(20); }


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:531:9: ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )?
				{
				DebugLocation(531, 9);
				// C.g:531:9: ( '0' .. '9' )+
				int cnt21=0;
				try { DebugEnterSubRule(21);
				while (true)
				{
					int alt21=2;
					try { DebugEnterDecision(21, decisionCanBacktrack[21]);
					int LA21_0 = input.LA(1);

					if (((LA21_0>='0' && LA21_0<='9')))
					{
						alt21=1;
					}


					} finally { DebugExitDecision(21); }
					switch (alt21)
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:531:10: '0' .. '9'
						{
						DebugLocation(531, 10);
						MatchRange('0','9'); 

						}
						break;

					default:
						if (cnt21 >= 1)
							goto loop21;

						EarlyExitException eee21 = new EarlyExitException( 21, input );
						DebugRecognitionException(eee21);
						throw eee21;
					}
					cnt21++;
				}
				loop21:
					;

				} finally { DebugExitSubRule(21); }

				DebugLocation(531, 21);
				mExponent(); 
				DebugLocation(531, 30);
				// C.g:531:30: ( FloatTypeSuffix )?
				int alt22=2;
				try { DebugEnterSubRule(22);
				try { DebugEnterDecision(22, decisionCanBacktrack[22]);
				int LA22_0 = input.LA(1);

				if ((LA22_0=='D'||LA22_0=='F'||LA22_0=='d'||LA22_0=='f'))
				{
					alt22=1;
				}
				} finally { DebugExitDecision(22); }
				switch (alt22)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:531:30: FloatTypeSuffix
					{
					DebugLocation(531, 30);
					mFloatTypeSuffix(); 

					}
					break;

				}
				} finally { DebugExitSubRule(22); }


				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:532:9: ( '0' .. '9' )+ ( Exponent )? FloatTypeSuffix
				{
				DebugLocation(532, 9);
				// C.g:532:9: ( '0' .. '9' )+
				int cnt23=0;
				try { DebugEnterSubRule(23);
				while (true)
				{
					int alt23=2;
					try { DebugEnterDecision(23, decisionCanBacktrack[23]);
					int LA23_0 = input.LA(1);

					if (((LA23_0>='0' && LA23_0<='9')))
					{
						alt23=1;
					}


					} finally { DebugExitDecision(23); }
					switch (alt23)
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:532:10: '0' .. '9'
						{
						DebugLocation(532, 10);
						MatchRange('0','9'); 

						}
						break;

					default:
						if (cnt23 >= 1)
							goto loop23;

						EarlyExitException eee23 = new EarlyExitException( 23, input );
						DebugRecognitionException(eee23);
						throw eee23;
					}
					cnt23++;
				}
				loop23:
					;

				} finally { DebugExitSubRule(23); }

				DebugLocation(532, 21);
				// C.g:532:21: ( Exponent )?
				int alt24=2;
				try { DebugEnterSubRule(24);
				try { DebugEnterDecision(24, decisionCanBacktrack[24]);
				int LA24_0 = input.LA(1);

				if ((LA24_0=='E'||LA24_0=='e'))
				{
					alt24=1;
				}
				} finally { DebugExitDecision(24); }
				switch (alt24)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:532:21: Exponent
					{
					DebugLocation(532, 21);
					mExponent(); 

					}
					break;

				}
				} finally { DebugExitSubRule(24); }

				DebugLocation(532, 31);
				mFloatTypeSuffix(); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FLOATING_POINT_LITERAL", 88);
			LeaveRule("FLOATING_POINT_LITERAL", 88);
			Leave_FLOATING_POINT_LITERAL();
		}
	}
	// $ANTLR end "FLOATING_POINT_LITERAL"

	partial void Enter_Exponent();
	partial void Leave_Exponent();

	// $ANTLR start "Exponent"
	[GrammarRule("Exponent")]
	private void mExponent()
	{
		Enter_Exponent();
		EnterRule("Exponent", 89);
		TraceIn("Exponent", 89);
		try
		{
			// C.g:536:10: ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )
			DebugEnterAlt(1);
			// C.g:536:12: ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+
			{
			DebugLocation(536, 12);
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

			DebugLocation(536, 22);
			// C.g:536:22: ( '+' | '-' )?
			int alt26=2;
			try { DebugEnterSubRule(26);
			try { DebugEnterDecision(26, decisionCanBacktrack[26]);
			int LA26_0 = input.LA(1);

			if ((LA26_0=='+'||LA26_0=='-'))
			{
				alt26=1;
			}
			} finally { DebugExitDecision(26); }
			switch (alt26)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:
				{
				DebugLocation(536, 22);
				if (input.LA(1)=='+'||input.LA(1)=='-')
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

			}
			} finally { DebugExitSubRule(26); }

			DebugLocation(536, 33);
			// C.g:536:33: ( '0' .. '9' )+
			int cnt27=0;
			try { DebugEnterSubRule(27);
			while (true)
			{
				int alt27=2;
				try { DebugEnterDecision(27, decisionCanBacktrack[27]);
				int LA27_0 = input.LA(1);

				if (((LA27_0>='0' && LA27_0<='9')))
				{
					alt27=1;
				}


				} finally { DebugExitDecision(27); }
				switch (alt27)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:536:34: '0' .. '9'
					{
					DebugLocation(536, 34);
					MatchRange('0','9'); 

					}
					break;

				default:
					if (cnt27 >= 1)
						goto loop27;

					EarlyExitException eee27 = new EarlyExitException( 27, input );
					DebugRecognitionException(eee27);
					throw eee27;
				}
				cnt27++;
			}
			loop27:
				;

			} finally { DebugExitSubRule(27); }


			}

		}
		finally
		{
			TraceOut("Exponent", 89);
			LeaveRule("Exponent", 89);
			Leave_Exponent();
		}
	}
	// $ANTLR end "Exponent"

	partial void Enter_FloatTypeSuffix();
	partial void Leave_FloatTypeSuffix();

	// $ANTLR start "FloatTypeSuffix"
	[GrammarRule("FloatTypeSuffix")]
	private void mFloatTypeSuffix()
	{
		Enter_FloatTypeSuffix();
		EnterRule("FloatTypeSuffix", 90);
		TraceIn("FloatTypeSuffix", 90);
		try
		{
			// C.g:539:17: ( ( 'f' | 'F' | 'd' | 'D' ) )
			DebugEnterAlt(1);
			// C.g:539:19: ( 'f' | 'F' | 'd' | 'D' )
			{
			DebugLocation(539, 19);
			if (input.LA(1)=='D'||input.LA(1)=='F'||input.LA(1)=='d'||input.LA(1)=='f')
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
			TraceOut("FloatTypeSuffix", 90);
			LeaveRule("FloatTypeSuffix", 90);
			Leave_FloatTypeSuffix();
		}
	}
	// $ANTLR end "FloatTypeSuffix"

	partial void Enter_EscapeSequence();
	partial void Leave_EscapeSequence();

	// $ANTLR start "EscapeSequence"
	[GrammarRule("EscapeSequence")]
	private void mEscapeSequence()
	{
		Enter_EscapeSequence();
		EnterRule("EscapeSequence", 91);
		TraceIn("EscapeSequence", 91);
		try
		{
			// C.g:543:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) | OctalEscape )
			int alt28=2;
			try { DebugEnterDecision(28, decisionCanBacktrack[28]);
			int LA28_0 = input.LA(1);

			if ((LA28_0=='\\'))
			{
				int LA28_1 = input.LA(2);

				if ((LA28_1=='\"'||LA28_1=='\''||LA28_1=='\\'||LA28_1=='b'||LA28_1=='f'||LA28_1=='n'||LA28_1=='r'||LA28_1=='t'))
				{
					alt28=1;
				}
				else if (((LA28_1>='0' && LA28_1<='7')))
				{
					alt28=2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 28, 1, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 28, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(28); }
			switch (alt28)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:543:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
				{
				DebugLocation(543, 9);
				Match('\\'); 
				DebugLocation(543, 14);
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
				// C.g:544:9: OctalEscape
				{
				DebugLocation(544, 9);
				mOctalEscape(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("EscapeSequence", 91);
			LeaveRule("EscapeSequence", 91);
			Leave_EscapeSequence();
		}
	}
	// $ANTLR end "EscapeSequence"

	partial void Enter_OctalEscape();
	partial void Leave_OctalEscape();

	// $ANTLR start "OctalEscape"
	[GrammarRule("OctalEscape")]
	private void mOctalEscape()
	{
		Enter_OctalEscape();
		EnterRule("OctalEscape", 92);
		TraceIn("OctalEscape", 92);
		try
		{
			// C.g:549:5: ( '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) )
			int alt29=3;
			try { DebugEnterDecision(29, decisionCanBacktrack[29]);
			int LA29_0 = input.LA(1);

			if ((LA29_0=='\\'))
			{
				int LA29_1 = input.LA(2);

				if (((LA29_1>='0' && LA29_1<='3')))
				{
					int LA29_2 = input.LA(3);

					if (((LA29_2>='0' && LA29_2<='7')))
					{
						int LA29_4 = input.LA(4);

						if (((LA29_4>='0' && LA29_4<='7')))
						{
							alt29=1;
						}
						else
						{
							alt29=2;}
					}
					else
					{
						alt29=3;}
				}
				else if (((LA29_1>='4' && LA29_1<='7')))
				{
					int LA29_3 = input.LA(3);

					if (((LA29_3>='0' && LA29_3<='7')))
					{
						alt29=2;
					}
					else
					{
						alt29=3;}
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 29, 1, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 29, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(29); }
			switch (alt29)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:549:9: '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' )
				{
				DebugLocation(549, 9);
				Match('\\'); 
				DebugLocation(549, 14);
				// C.g:549:14: ( '0' .. '3' )
				DebugEnterAlt(1);
				// C.g:549:15: '0' .. '3'
				{
				DebugLocation(549, 15);
				MatchRange('0','3'); 

				}

				DebugLocation(549, 25);
				// C.g:549:25: ( '0' .. '7' )
				DebugEnterAlt(1);
				// C.g:549:26: '0' .. '7'
				{
				DebugLocation(549, 26);
				MatchRange('0','7'); 

				}

				DebugLocation(549, 36);
				// C.g:549:36: ( '0' .. '7' )
				DebugEnterAlt(1);
				// C.g:549:37: '0' .. '7'
				{
				DebugLocation(549, 37);
				MatchRange('0','7'); 

				}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:550:9: '\\\\' ( '0' .. '7' ) ( '0' .. '7' )
				{
				DebugLocation(550, 9);
				Match('\\'); 
				DebugLocation(550, 14);
				// C.g:550:14: ( '0' .. '7' )
				DebugEnterAlt(1);
				// C.g:550:15: '0' .. '7'
				{
				DebugLocation(550, 15);
				MatchRange('0','7'); 

				}

				DebugLocation(550, 25);
				// C.g:550:25: ( '0' .. '7' )
				DebugEnterAlt(1);
				// C.g:550:26: '0' .. '7'
				{
				DebugLocation(550, 26);
				MatchRange('0','7'); 

				}


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:551:9: '\\\\' ( '0' .. '7' )
				{
				DebugLocation(551, 9);
				Match('\\'); 
				DebugLocation(551, 14);
				// C.g:551:14: ( '0' .. '7' )
				DebugEnterAlt(1);
				// C.g:551:15: '0' .. '7'
				{
				DebugLocation(551, 15);
				MatchRange('0','7'); 

				}


				}
				break;

			}
		}
		finally
		{
			TraceOut("OctalEscape", 92);
			LeaveRule("OctalEscape", 92);
			Leave_OctalEscape();
		}
	}
	// $ANTLR end "OctalEscape"

	partial void Enter_UnicodeEscape();
	partial void Leave_UnicodeEscape();

	// $ANTLR start "UnicodeEscape"
	[GrammarRule("UnicodeEscape")]
	private void mUnicodeEscape()
	{
		Enter_UnicodeEscape();
		EnterRule("UnicodeEscape", 93);
		TraceIn("UnicodeEscape", 93);
		try
		{
			// C.g:556:5: ( '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit )
			DebugEnterAlt(1);
			// C.g:556:9: '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit
			{
			DebugLocation(556, 9);
			Match('\\'); 
			DebugLocation(556, 14);
			Match('u'); 
			DebugLocation(556, 18);
			mHexDigit(); 
			DebugLocation(556, 27);
			mHexDigit(); 
			DebugLocation(556, 36);
			mHexDigit(); 
			DebugLocation(556, 45);
			mHexDigit(); 

			}

		}
		finally
		{
			TraceOut("UnicodeEscape", 93);
			LeaveRule("UnicodeEscape", 93);
			Leave_UnicodeEscape();
		}
	}
	// $ANTLR end "UnicodeEscape"

	partial void Enter_WS();
	partial void Leave_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		Enter_WS();
		EnterRule("WS", 94);
		TraceIn("WS", 94);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// C.g:559:5: ( ( ' ' | '\\r' | '\\t' | '\\u000C' | '\\n' ) )
			DebugEnterAlt(1);
			// C.g:559:8: ( ' ' | '\\r' | '\\t' | '\\u000C' | '\\n' )
			{
			DebugLocation(559, 8);
			if ((input.LA(1)>='\t' && input.LA(1)<='\n')||(input.LA(1)>='\f' && input.LA(1)<='\r')||input.LA(1)==' ')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}

			DebugLocation(559, 38);
			_channel=Hidden;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 94);
			LeaveRule("WS", 94);
			Leave_WS();
		}
	}
	// $ANTLR end "WS"

	partial void Enter_COMMENT();
	partial void Leave_COMMENT();

	// $ANTLR start "COMMENT"
	[GrammarRule("COMMENT")]
	private void mCOMMENT()
	{
		Enter_COMMENT();
		EnterRule("COMMENT", 95);
		TraceIn("COMMENT", 95);
		try
		{
			int _type = COMMENT;
			int _channel = DefaultTokenChannel;
			// C.g:563:5: ( '/*' ( options {greedy=false; } : . )* '*/' )
			DebugEnterAlt(1);
			// C.g:563:9: '/*' ( options {greedy=false; } : . )* '*/'
			{
			DebugLocation(563, 9);
			Match("/*"); 

			DebugLocation(563, 14);
			// C.g:563:14: ( options {greedy=false; } : . )*
			try { DebugEnterSubRule(30);
			while (true)
			{
				int alt30=2;
				try { DebugEnterDecision(30, decisionCanBacktrack[30]);
				int LA30_0 = input.LA(1);

				if ((LA30_0=='*'))
				{
					int LA30_1 = input.LA(2);

					if ((LA30_1=='/'))
					{
						alt30=2;
					}
					else if (((LA30_1>='\u0000' && LA30_1<='.')||(LA30_1>='0' && LA30_1<='\uFFFF')))
					{
						alt30=1;
					}


				}
				else if (((LA30_0>='\u0000' && LA30_0<=')')||(LA30_0>='+' && LA30_0<='\uFFFF')))
				{
					alt30=1;
				}


				} finally { DebugExitDecision(30); }
				switch ( alt30 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:563:42: .
					{
					DebugLocation(563, 42);
					MatchAny(); 

					}
					break;

				default:
					goto loop30;
				}
			}

			loop30:
				;

			} finally { DebugExitSubRule(30); }

			DebugLocation(563, 47);
			Match("*/"); 

			DebugLocation(563, 52);
			_channel=Hidden;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMENT", 95);
			LeaveRule("COMMENT", 95);
			Leave_COMMENT();
		}
	}
	// $ANTLR end "COMMENT"

	partial void Enter_LINE_COMMENT();
	partial void Leave_LINE_COMMENT();

	// $ANTLR start "LINE_COMMENT"
	[GrammarRule("LINE_COMMENT")]
	private void mLINE_COMMENT()
	{
		Enter_LINE_COMMENT();
		EnterRule("LINE_COMMENT", 96);
		TraceIn("LINE_COMMENT", 96);
		try
		{
			int _type = LINE_COMMENT;
			int _channel = DefaultTokenChannel;
			// C.g:567:5: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
			DebugEnterAlt(1);
			// C.g:567:7: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
			{
			DebugLocation(567, 7);
			Match("//"); 

			DebugLocation(567, 12);
			// C.g:567:12: (~ ( '\\n' | '\\r' ) )*
			try { DebugEnterSubRule(31);
			while (true)
			{
				int alt31=2;
				try { DebugEnterDecision(31, decisionCanBacktrack[31]);
				int LA31_0 = input.LA(1);

				if (((LA31_0>='\u0000' && LA31_0<='\t')||(LA31_0>='\u000B' && LA31_0<='\f')||(LA31_0>='\u000E' && LA31_0<='\uFFFF')))
				{
					alt31=1;
				}


				} finally { DebugExitDecision(31); }
				switch ( alt31 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:567:12: ~ ( '\\n' | '\\r' )
					{
					DebugLocation(567, 12);
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
					goto loop31;
				}
			}

			loop31:
				;

			} finally { DebugExitSubRule(31); }

			DebugLocation(567, 26);
			// C.g:567:26: ( '\\r' )?
			int alt32=2;
			try { DebugEnterSubRule(32);
			try { DebugEnterDecision(32, decisionCanBacktrack[32]);
			int LA32_0 = input.LA(1);

			if ((LA32_0=='\r'))
			{
				alt32=1;
			}
			} finally { DebugExitDecision(32); }
			switch (alt32)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:567:26: '\\r'
				{
				DebugLocation(567, 26);
				Match('\r'); 

				}
				break;

			}
			} finally { DebugExitSubRule(32); }

			DebugLocation(567, 32);
			Match('\n'); 
			DebugLocation(567, 37);
			_channel=Hidden;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LINE_COMMENT", 96);
			LeaveRule("LINE_COMMENT", 96);
			Leave_LINE_COMMENT();
		}
	}
	// $ANTLR end "LINE_COMMENT"

	partial void Enter_LINE_COMMAND();
	partial void Leave_LINE_COMMAND();

	// $ANTLR start "LINE_COMMAND"
	[GrammarRule("LINE_COMMAND")]
	private void mLINE_COMMAND()
	{
		Enter_LINE_COMMAND();
		EnterRule("LINE_COMMAND", 97);
		TraceIn("LINE_COMMAND", 97);
		try
		{
			int _type = LINE_COMMAND;
			int _channel = DefaultTokenChannel;
			// C.g:572:5: ( '#' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
			DebugEnterAlt(1);
			// C.g:572:7: '#' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
			{
			DebugLocation(572, 7);
			Match('#'); 
			DebugLocation(572, 11);
			// C.g:572:11: (~ ( '\\n' | '\\r' ) )*
			try { DebugEnterSubRule(33);
			while (true)
			{
				int alt33=2;
				try { DebugEnterDecision(33, decisionCanBacktrack[33]);
				int LA33_0 = input.LA(1);

				if (((LA33_0>='\u0000' && LA33_0<='\t')||(LA33_0>='\u000B' && LA33_0<='\f')||(LA33_0>='\u000E' && LA33_0<='\uFFFF')))
				{
					alt33=1;
				}


				} finally { DebugExitDecision(33); }
				switch ( alt33 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:572:11: ~ ( '\\n' | '\\r' )
					{
					DebugLocation(572, 11);
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
					goto loop33;
				}
			}

			loop33:
				;

			} finally { DebugExitSubRule(33); }

			DebugLocation(572, 25);
			// C.g:572:25: ( '\\r' )?
			int alt34=2;
			try { DebugEnterSubRule(34);
			try { DebugEnterDecision(34, decisionCanBacktrack[34]);
			int LA34_0 = input.LA(1);

			if ((LA34_0=='\r'))
			{
				alt34=1;
			}
			} finally { DebugExitDecision(34); }
			switch (alt34)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:572:25: '\\r'
				{
				DebugLocation(572, 25);
				Match('\r'); 

				}
				break;

			}
			} finally { DebugExitSubRule(34); }

			DebugLocation(572, 31);
			Match('\n'); 
			DebugLocation(572, 36);
			_channel=Hidden;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LINE_COMMAND", 97);
			LeaveRule("LINE_COMMAND", 97);
			Leave_LINE_COMMAND();
		}
	}
	// $ANTLR end "LINE_COMMAND"

	public override void mTokens()
	{
		// C.g:1:8: ( T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | T__67 | T__68 | T__69 | T__70 | T__71 | T__72 | T__73 | T__74 | T__75 | T__76 | T__77 | T__78 | T__79 | T__80 | T__81 | T__82 | T__83 | T__84 | T__85 | T__86 | T__87 | T__88 | T__89 | T__90 | T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | IDENTIFIER | CHARACTER_LITERAL | STRING_LITERAL | HEX_LITERAL | DECIMAL_LITERAL | OCTAL_LITERAL | FLOATING_POINT_LITERAL | WS | COMMENT | LINE_COMMENT | LINE_COMMAND )
		int alt35=89;
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
		switch (alt35)
		{
		case 1:
			DebugEnterAlt(1);
			// C.g:1:10: T__23
			{
			DebugLocation(1, 10);
			mT__23(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// C.g:1:16: T__24
			{
			DebugLocation(1, 16);
			mT__24(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// C.g:1:22: T__25
			{
			DebugLocation(1, 22);
			mT__25(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// C.g:1:28: T__26
			{
			DebugLocation(1, 28);
			mT__26(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// C.g:1:34: T__27
			{
			DebugLocation(1, 34);
			mT__27(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// C.g:1:40: T__28
			{
			DebugLocation(1, 40);
			mT__28(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// C.g:1:46: T__29
			{
			DebugLocation(1, 46);
			mT__29(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// C.g:1:52: T__30
			{
			DebugLocation(1, 52);
			mT__30(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// C.g:1:58: T__31
			{
			DebugLocation(1, 58);
			mT__31(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// C.g:1:64: T__32
			{
			DebugLocation(1, 64);
			mT__32(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// C.g:1:70: T__33
			{
			DebugLocation(1, 70);
			mT__33(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// C.g:1:76: T__34
			{
			DebugLocation(1, 76);
			mT__34(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// C.g:1:82: T__35
			{
			DebugLocation(1, 82);
			mT__35(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// C.g:1:88: T__36
			{
			DebugLocation(1, 88);
			mT__36(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// C.g:1:94: T__37
			{
			DebugLocation(1, 94);
			mT__37(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// C.g:1:100: T__38
			{
			DebugLocation(1, 100);
			mT__38(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// C.g:1:106: T__39
			{
			DebugLocation(1, 106);
			mT__39(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// C.g:1:112: T__40
			{
			DebugLocation(1, 112);
			mT__40(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// C.g:1:118: T__41
			{
			DebugLocation(1, 118);
			mT__41(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// C.g:1:124: T__42
			{
			DebugLocation(1, 124);
			mT__42(); 

			}
			break;
		case 21:
			DebugEnterAlt(21);
			// C.g:1:130: T__43
			{
			DebugLocation(1, 130);
			mT__43(); 

			}
			break;
		case 22:
			DebugEnterAlt(22);
			// C.g:1:136: T__44
			{
			DebugLocation(1, 136);
			mT__44(); 

			}
			break;
		case 23:
			DebugEnterAlt(23);
			// C.g:1:142: T__45
			{
			DebugLocation(1, 142);
			mT__45(); 

			}
			break;
		case 24:
			DebugEnterAlt(24);
			// C.g:1:148: T__46
			{
			DebugLocation(1, 148);
			mT__46(); 

			}
			break;
		case 25:
			DebugEnterAlt(25);
			// C.g:1:154: T__47
			{
			DebugLocation(1, 154);
			mT__47(); 

			}
			break;
		case 26:
			DebugEnterAlt(26);
			// C.g:1:160: T__48
			{
			DebugLocation(1, 160);
			mT__48(); 

			}
			break;
		case 27:
			DebugEnterAlt(27);
			// C.g:1:166: T__49
			{
			DebugLocation(1, 166);
			mT__49(); 

			}
			break;
		case 28:
			DebugEnterAlt(28);
			// C.g:1:172: T__50
			{
			DebugLocation(1, 172);
			mT__50(); 

			}
			break;
		case 29:
			DebugEnterAlt(29);
			// C.g:1:178: T__51
			{
			DebugLocation(1, 178);
			mT__51(); 

			}
			break;
		case 30:
			DebugEnterAlt(30);
			// C.g:1:184: T__52
			{
			DebugLocation(1, 184);
			mT__52(); 

			}
			break;
		case 31:
			DebugEnterAlt(31);
			// C.g:1:190: T__53
			{
			DebugLocation(1, 190);
			mT__53(); 

			}
			break;
		case 32:
			DebugEnterAlt(32);
			// C.g:1:196: T__54
			{
			DebugLocation(1, 196);
			mT__54(); 

			}
			break;
		case 33:
			DebugEnterAlt(33);
			// C.g:1:202: T__55
			{
			DebugLocation(1, 202);
			mT__55(); 

			}
			break;
		case 34:
			DebugEnterAlt(34);
			// C.g:1:208: T__56
			{
			DebugLocation(1, 208);
			mT__56(); 

			}
			break;
		case 35:
			DebugEnterAlt(35);
			// C.g:1:214: T__57
			{
			DebugLocation(1, 214);
			mT__57(); 

			}
			break;
		case 36:
			DebugEnterAlt(36);
			// C.g:1:220: T__58
			{
			DebugLocation(1, 220);
			mT__58(); 

			}
			break;
		case 37:
			DebugEnterAlt(37);
			// C.g:1:226: T__59
			{
			DebugLocation(1, 226);
			mT__59(); 

			}
			break;
		case 38:
			DebugEnterAlt(38);
			// C.g:1:232: T__60
			{
			DebugLocation(1, 232);
			mT__60(); 

			}
			break;
		case 39:
			DebugEnterAlt(39);
			// C.g:1:238: T__61
			{
			DebugLocation(1, 238);
			mT__61(); 

			}
			break;
		case 40:
			DebugEnterAlt(40);
			// C.g:1:244: T__62
			{
			DebugLocation(1, 244);
			mT__62(); 

			}
			break;
		case 41:
			DebugEnterAlt(41);
			// C.g:1:250: T__63
			{
			DebugLocation(1, 250);
			mT__63(); 

			}
			break;
		case 42:
			DebugEnterAlt(42);
			// C.g:1:256: T__64
			{
			DebugLocation(1, 256);
			mT__64(); 

			}
			break;
		case 43:
			DebugEnterAlt(43);
			// C.g:1:262: T__65
			{
			DebugLocation(1, 262);
			mT__65(); 

			}
			break;
		case 44:
			DebugEnterAlt(44);
			// C.g:1:268: T__66
			{
			DebugLocation(1, 268);
			mT__66(); 

			}
			break;
		case 45:
			DebugEnterAlt(45);
			// C.g:1:274: T__67
			{
			DebugLocation(1, 274);
			mT__67(); 

			}
			break;
		case 46:
			DebugEnterAlt(46);
			// C.g:1:280: T__68
			{
			DebugLocation(1, 280);
			mT__68(); 

			}
			break;
		case 47:
			DebugEnterAlt(47);
			// C.g:1:286: T__69
			{
			DebugLocation(1, 286);
			mT__69(); 

			}
			break;
		case 48:
			DebugEnterAlt(48);
			// C.g:1:292: T__70
			{
			DebugLocation(1, 292);
			mT__70(); 

			}
			break;
		case 49:
			DebugEnterAlt(49);
			// C.g:1:298: T__71
			{
			DebugLocation(1, 298);
			mT__71(); 

			}
			break;
		case 50:
			DebugEnterAlt(50);
			// C.g:1:304: T__72
			{
			DebugLocation(1, 304);
			mT__72(); 

			}
			break;
		case 51:
			DebugEnterAlt(51);
			// C.g:1:310: T__73
			{
			DebugLocation(1, 310);
			mT__73(); 

			}
			break;
		case 52:
			DebugEnterAlt(52);
			// C.g:1:316: T__74
			{
			DebugLocation(1, 316);
			mT__74(); 

			}
			break;
		case 53:
			DebugEnterAlt(53);
			// C.g:1:322: T__75
			{
			DebugLocation(1, 322);
			mT__75(); 

			}
			break;
		case 54:
			DebugEnterAlt(54);
			// C.g:1:328: T__76
			{
			DebugLocation(1, 328);
			mT__76(); 

			}
			break;
		case 55:
			DebugEnterAlt(55);
			// C.g:1:334: T__77
			{
			DebugLocation(1, 334);
			mT__77(); 

			}
			break;
		case 56:
			DebugEnterAlt(56);
			// C.g:1:340: T__78
			{
			DebugLocation(1, 340);
			mT__78(); 

			}
			break;
		case 57:
			DebugEnterAlt(57);
			// C.g:1:346: T__79
			{
			DebugLocation(1, 346);
			mT__79(); 

			}
			break;
		case 58:
			DebugEnterAlt(58);
			// C.g:1:352: T__80
			{
			DebugLocation(1, 352);
			mT__80(); 

			}
			break;
		case 59:
			DebugEnterAlt(59);
			// C.g:1:358: T__81
			{
			DebugLocation(1, 358);
			mT__81(); 

			}
			break;
		case 60:
			DebugEnterAlt(60);
			// C.g:1:364: T__82
			{
			DebugLocation(1, 364);
			mT__82(); 

			}
			break;
		case 61:
			DebugEnterAlt(61);
			// C.g:1:370: T__83
			{
			DebugLocation(1, 370);
			mT__83(); 

			}
			break;
		case 62:
			DebugEnterAlt(62);
			// C.g:1:376: T__84
			{
			DebugLocation(1, 376);
			mT__84(); 

			}
			break;
		case 63:
			DebugEnterAlt(63);
			// C.g:1:382: T__85
			{
			DebugLocation(1, 382);
			mT__85(); 

			}
			break;
		case 64:
			DebugEnterAlt(64);
			// C.g:1:388: T__86
			{
			DebugLocation(1, 388);
			mT__86(); 

			}
			break;
		case 65:
			DebugEnterAlt(65);
			// C.g:1:394: T__87
			{
			DebugLocation(1, 394);
			mT__87(); 

			}
			break;
		case 66:
			DebugEnterAlt(66);
			// C.g:1:400: T__88
			{
			DebugLocation(1, 400);
			mT__88(); 

			}
			break;
		case 67:
			DebugEnterAlt(67);
			// C.g:1:406: T__89
			{
			DebugLocation(1, 406);
			mT__89(); 

			}
			break;
		case 68:
			DebugEnterAlt(68);
			// C.g:1:412: T__90
			{
			DebugLocation(1, 412);
			mT__90(); 

			}
			break;
		case 69:
			DebugEnterAlt(69);
			// C.g:1:418: T__91
			{
			DebugLocation(1, 418);
			mT__91(); 

			}
			break;
		case 70:
			DebugEnterAlt(70);
			// C.g:1:424: T__92
			{
			DebugLocation(1, 424);
			mT__92(); 

			}
			break;
		case 71:
			DebugEnterAlt(71);
			// C.g:1:430: T__93
			{
			DebugLocation(1, 430);
			mT__93(); 

			}
			break;
		case 72:
			DebugEnterAlt(72);
			// C.g:1:436: T__94
			{
			DebugLocation(1, 436);
			mT__94(); 

			}
			break;
		case 73:
			DebugEnterAlt(73);
			// C.g:1:442: T__95
			{
			DebugLocation(1, 442);
			mT__95(); 

			}
			break;
		case 74:
			DebugEnterAlt(74);
			// C.g:1:448: T__96
			{
			DebugLocation(1, 448);
			mT__96(); 

			}
			break;
		case 75:
			DebugEnterAlt(75);
			// C.g:1:454: T__97
			{
			DebugLocation(1, 454);
			mT__97(); 

			}
			break;
		case 76:
			DebugEnterAlt(76);
			// C.g:1:460: T__98
			{
			DebugLocation(1, 460);
			mT__98(); 

			}
			break;
		case 77:
			DebugEnterAlt(77);
			// C.g:1:466: T__99
			{
			DebugLocation(1, 466);
			mT__99(); 

			}
			break;
		case 78:
			DebugEnterAlt(78);
			// C.g:1:472: T__100
			{
			DebugLocation(1, 472);
			mT__100(); 

			}
			break;
		case 79:
			DebugEnterAlt(79);
			// C.g:1:479: IDENTIFIER
			{
			DebugLocation(1, 479);
			mIDENTIFIER(); 

			}
			break;
		case 80:
			DebugEnterAlt(80);
			// C.g:1:490: CHARACTER_LITERAL
			{
			DebugLocation(1, 490);
			mCHARACTER_LITERAL(); 

			}
			break;
		case 81:
			DebugEnterAlt(81);
			// C.g:1:508: STRING_LITERAL
			{
			DebugLocation(1, 508);
			mSTRING_LITERAL(); 

			}
			break;
		case 82:
			DebugEnterAlt(82);
			// C.g:1:523: HEX_LITERAL
			{
			DebugLocation(1, 523);
			mHEX_LITERAL(); 

			}
			break;
		case 83:
			DebugEnterAlt(83);
			// C.g:1:535: DECIMAL_LITERAL
			{
			DebugLocation(1, 535);
			mDECIMAL_LITERAL(); 

			}
			break;
		case 84:
			DebugEnterAlt(84);
			// C.g:1:551: OCTAL_LITERAL
			{
			DebugLocation(1, 551);
			mOCTAL_LITERAL(); 

			}
			break;
		case 85:
			DebugEnterAlt(85);
			// C.g:1:565: FLOATING_POINT_LITERAL
			{
			DebugLocation(1, 565);
			mFLOATING_POINT_LITERAL(); 

			}
			break;
		case 86:
			DebugEnterAlt(86);
			// C.g:1:588: WS
			{
			DebugLocation(1, 588);
			mWS(); 

			}
			break;
		case 87:
			DebugEnterAlt(87);
			// C.g:1:591: COMMENT
			{
			DebugLocation(1, 591);
			mCOMMENT(); 

			}
			break;
		case 88:
			DebugEnterAlt(88);
			// C.g:1:599: LINE_COMMENT
			{
			DebugLocation(1, 599);
			mLINE_COMMENT(); 

			}
			break;
		case 89:
			DebugEnterAlt(89);
			// C.g:1:612: LINE_COMMAND
			{
			DebugLocation(1, 612);
			mLINE_COMMAND(); 

			}
			break;

		}

	}


	#region DFA
	DFA25 dfa25;
	DFA35 dfa35;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa25 = new DFA25(this);
		dfa35 = new DFA35(this);
	}

	private class DFA25 : DFA
	{
		private const string DFA25_eotS =
			"\x7\xFFFF\x1\x8\x2\xFFFF";
		private const string DFA25_eofS =
			"\xA\xFFFF";
		private const string DFA25_minS =
			"\x2\x2E\x2\xFFFF\x1\x2B\x1\xFFFF\x2\x30\x2\xFFFF";
		private const string DFA25_maxS =
			"\x1\x39\x1\x66\x2\xFFFF\x1\x39\x1\xFFFF\x1\x39\x1\x66\x2\xFFFF";
		private const string DFA25_acceptS =
			"\x2\xFFFF\x1\x2\x1\x1\x1\xFFFF\x1\x4\x2\xFFFF\x2\x3";
		private const string DFA25_specialS =
			"\xA\xFFFF}>";
		private static readonly string[] DFA25_transitionS =
			{
				"\x1\x2\x1\xFFFF\xA\x1",
				"\x1\x3\x1\xFFFF\xA\x1\xA\xFFFF\x1\x5\x1\x4\x1\x5\x1D\xFFFF\x1\x5\x1"+
				"\x4\x1\x5",
				"",
				"",
				"\x1\x6\x1\xFFFF\x1\x6\x2\xFFFF\xA\x7",
				"",
				"\xA\x7",
				"\xA\x7\xA\xFFFF\x1\x9\x1\xFFFF\x1\x9\x1D\xFFFF\x1\x9\x1\xFFFF\x1\x9",
				"",
				""
			};

		private static readonly short[] DFA25_eot = DFA.UnpackEncodedString(DFA25_eotS);
		private static readonly short[] DFA25_eof = DFA.UnpackEncodedString(DFA25_eofS);
		private static readonly char[] DFA25_min = DFA.UnpackEncodedStringToUnsignedChars(DFA25_minS);
		private static readonly char[] DFA25_max = DFA.UnpackEncodedStringToUnsignedChars(DFA25_maxS);
		private static readonly short[] DFA25_accept = DFA.UnpackEncodedString(DFA25_acceptS);
		private static readonly short[] DFA25_special = DFA.UnpackEncodedString(DFA25_specialS);
		private static readonly short[][] DFA25_transition;

		static DFA25()
		{
			int numStates = DFA25_transitionS.Length;
			DFA25_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA25_transition[i] = DFA.UnpackEncodedString(DFA25_transitionS[i]);
			}
		}

		public DFA25( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 25;
			this.eot = DFA25_eot;
			this.eof = DFA25_eof;
			this.min = DFA25_min;
			this.max = DFA25_max;
			this.accept = DFA25_accept;
			this.special = DFA25_special;
			this.transition = DFA25_transition;
		}

		public override string Description { get { return "528:1: FLOATING_POINT_LITERAL : ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )? | '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )? | ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )? | ( '0' .. '9' )+ ( Exponent )? FloatTypeSuffix );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA35 : DFA
	{
		private const string DFA35_eotS =
			"\x1\xFFFF\x1\x28\x2\xFFFF\x1\x31\xB\x28\x7\xFFFF\x1\x48\x1\x4A\x1\x4E"+
			"\x1\x52\x1\x56\x1\x58\x1\x5B\x1\xFFFF\x1\x5D\x1\x60\x1\x63\x1\x65\x1"+
			"\x68\x1\xFFFF\x3\x28\x3\xFFFF\x2\x6D\x2\xFFFF\x1\x28\x2\xFFFF\xE\x28"+
			"\x1\x83\x3\x28\x1\x88\x2\x28\x17\xFFFF\x1\x8D\x2\xFFFF\x1\x8F\x7\xFFFF"+
			"\x3\x28\x2\xFFFF\x1\x93\x1\x6D\x12\x28\x1\xA7\x1\xFFFF\x2\x28\x1\xAA"+
			"\x1\x28\x1\xFFFF\x3\x28\x4\xFFFF\x3\x28\x1\xFFFF\x2\x28\x1\xB4\x1\xB5"+
			"\x6\x28\x1\xBC\x2\x28\x1\xBF\x1\x28\x1\xC1\x2\x28\x1\xC4\x1\xFFFF\x1"+
			"\xC5\x1\x28\x1\xFFFF\x5\x28\x1\xCC\x3\x28\x2\xFFFF\x2\x28\x1\xD2\x3\x28"+
			"\x1\xFFFF\x2\x28\x1\xFFFF\x1\x28\x1\xFFFF\x1\xD9\x1\x28\x2\xFFFF\x1\xDB"+
			"\x3\x28\x1\xDF\x1\xE0\x1\xFFFF\x1\xE1\x1\x28\x1\xE3\x1\xE4\x1\xE5\x1"+
			"\xFFFF\x1\xE6\x1\xE7\x1\xE8\x1\x28\x1\xEA\x1\x28\x1\xFFFF\x1\x28\x1\xFFFF"+
			"\x1\xED\x2\x28\x3\xFFFF\x1\xF0\x6\xFFFF\x1\x28\x1\xFFFF\x2\x28\x1\xFFFF"+
			"\x1\xF4\x1\x28\x1\xFFFF\x1\xF6\x1\xF7\x1\xF8\x1\xFFFF\x1\xF9\x4\xFFFF";
		private const string DFA35_eofS =
			"\xFA\xFFFF";
		private const string DFA35_minS =
			"\x1\x9\x1\x79\x2\xFFFF\x1\x3D\x1\x6C\x1\x68\x1\x75\x1\x65\x1\x6F\x1"+
			"\x61\x1\x66\x1\x6F\x1\x6C\x1\x65\x1\x6E\x7\xFFFF\x1\x3D\x1\x2E\x1\x2B"+
			"\x1\x2D\x1\x2A\x1\x3D\x1\x26\x1\xFFFF\x1\x3D\x1\x3C\x3\x3D\x1\xFFFF\x1"+
			"\x68\x1\x6F\x1\x72\x3\xFFFF\x2\x2E\x2\xFFFF\x1\x70\x2\xFFFF\x1\x74\x1"+
			"\x75\x1\x73\x1\x61\x1\x6F\x1\x67\x1\x69\x1\x74\x1\x67\x1\x69\x1\x61\x1"+
			"\x6E\x1\x73\x1\x74\x1\x24\x1\x6E\x1\x6F\x1\x72\x1\x24\x1\x66\x1\x69\x17"+
			"\xFFFF\x1\x3D\x2\xFFFF\x1\x3D\x7\xFFFF\x1\x69\x1\x74\x1\x65\x2\xFFFF"+
			"\x2\x2E\x2\x65\x1\x6D\x1\x65\x1\x74\x1\x75\x1\x72\x1\x6E\x1\x65\x1\x74"+
			"\x1\x6F\x1\x69\x1\x75\x1\x64\x1\x61\x1\x72\x1\x73\x1\x65\x1\x24\x1\xFFFF"+
			"\x1\x67\x1\x61\x1\x24\x1\x62\x1\xFFFF\x1\x61\x1\x69\x1\x6F\x4\xFFFF\x1"+
			"\x6C\x1\x6F\x1\x61\x1\xFFFF\x1\x64\x1\x72\x2\x24\x1\x69\x1\x63\x1\x74"+
			"\x1\x65\x1\x6F\x1\x63\x1\x24\x1\x73\x1\x72\x1\x24\x1\x74\x1\x24\x1\x74"+
			"\x1\x69\x1\x24\x1\xFFFF\x1\x24\x1\x74\x1\xFFFF\x1\x6C\x1\x75\x1\x67\x1"+
			"\x6E\x1\x65\x1\x24\x1\x6B\x1\x65\x1\x6E\x2\xFFFF\x1\x63\x1\x74\x1\x24"+
			"\x1\x64\x1\x66\x1\x68\x1\xFFFF\x1\x74\x1\x6E\x1\xFFFF\x1\x69\x1\xFFFF"+
			"\x1\x24\x1\x6E\x2\xFFFF\x1\x24\x1\x65\x1\x6C\x1\x6E\x2\x24\x1\xFFFF\x1"+
			"\x24\x1\x66\x3\x24\x1\xFFFF\x3\x24\x1\x65\x1\x24\x1\x6C\x1\xFFFF\x1\x75"+
			"\x1\xFFFF\x1\x24\x1\x74\x1\x65\x3\xFFFF\x1\x24\x6\xFFFF\x1\x72\x1\xFFFF"+
			"\x2\x65\x1\xFFFF\x1\x24\x1\x64\x1\xFFFF\x3\x24\x1\xFFFF\x1\x24\x4\xFFFF";
		private const string DFA35_maxS =
			"\x1\x7E\x1\x79\x2\xFFFF\x1\x3D\x1\x78\x1\x77\x1\x75\x1\x65\x2\x6F\x1"+
			"\x6E\x3\x6F\x1\x6E\x7\xFFFF\x1\x3D\x1\x39\x1\x3D\x1\x3E\x3\x3D\x1\xFFFF"+
			"\x2\x3D\x1\x3E\x1\x3D\x1\x7C\x1\xFFFF\x1\x68\x1\x6F\x1\x72\x3\xFFFF\x1"+
			"\x78\x1\x66\x2\xFFFF\x1\x70\x2\xFFFF\x1\x74\x1\x75\x1\x73\x1\x72\x1\x6F"+
			"\x1\x7A\x1\x69\x2\x74\x1\x6C\x1\x61\x1\x6E\x1\x73\x1\x74\x1\x7A\x1\x6E"+
			"\x1\x6F\x1\x72\x1\x7A\x1\x66\x1\x73\x17\xFFFF\x1\x3D\x2\xFFFF\x1\x3D"+
			"\x7\xFFFF\x1\x69\x1\x74\x1\x65\x2\xFFFF\x2\x66\x2\x65\x1\x6D\x1\x65\x1"+
			"\x74\x1\x75\x1\x72\x1\x6E\x1\x65\x1\x74\x1\x6F\x1\x69\x1\x75\x1\x64\x1"+
			"\x61\x1\x72\x1\x74\x1\x65\x1\x7A\x1\xFFFF\x1\x67\x1\x61\x1\x7A\x1\x62"+
			"\x1\xFFFF\x1\x61\x1\x69\x1\x6F\x4\xFFFF\x1\x6C\x1\x6F\x1\x61\x1\xFFFF"+
			"\x1\x64\x1\x72\x2\x7A\x1\x69\x1\x63\x1\x74\x1\x65\x1\x6F\x1\x63\x1\x7A"+
			"\x1\x73\x1\x72\x1\x7A\x1\x74\x1\x7A\x1\x74\x1\x69\x1\x7A\x1\xFFFF\x1"+
			"\x7A\x1\x74\x1\xFFFF\x1\x6C\x1\x75\x1\x67\x1\x6E\x1\x65\x1\x7A\x1\x6B"+
			"\x1\x65\x1\x6E\x2\xFFFF\x1\x63\x1\x74\x1\x7A\x1\x64\x1\x66\x1\x68\x1"+
			"\xFFFF\x1\x74\x1\x6E\x1\xFFFF\x1\x69\x1\xFFFF\x1\x7A\x1\x6E\x2\xFFFF"+
			"\x1\x7A\x1\x65\x1\x6C\x1\x6E\x2\x7A\x1\xFFFF\x1\x7A\x1\x66\x3\x7A\x1"+
			"\xFFFF\x3\x7A\x1\x65\x1\x7A\x1\x6C\x1\xFFFF\x1\x75\x1\xFFFF\x1\x7A\x1"+
			"\x74\x1\x65\x3\xFFFF\x1\x7A\x6\xFFFF\x1\x72\x1\xFFFF\x2\x65\x1\xFFFF"+
			"\x1\x7A\x1\x64\x1\xFFFF\x3\x7A\x1\xFFFF\x1\x7A\x4\xFFFF";
		private const string DFA35_acceptS =
			"\x2\xFFFF\x1\x2\x1\x3\xC\xFFFF\x1\x12\x1\x13\x1\x16\x1\x1A\x1\x1B\x1"+
			"\x1C\x1\x1D\x7\xFFFF\x1\x2A\x5\xFFFF\x1\x36\x3\xFFFF\x1\x4F\x1\x50\x1"+
			"\x51\x2\xFFFF\x1\x56\x1\x59\x1\xFFFF\x1\x3B\x1\x4\x15\xFFFF\x1\x2C\x1"+
			"\x1E\x1\x1F\x1\x27\x1\x55\x1\x24\x1\x2F\x1\x20\x1\x25\x1\x28\x1\x30\x1"+
			"\x21\x1\x2D\x1\x57\x1\x58\x1\x22\x1\x2E\x1\x23\x1\x33\x1\x38\x1\x29\x1"+
			"\x3C\x1\x2B\x1\xFFFF\x1\x3F\x1\x3D\x1\xFFFF\x1\x40\x1\x3E\x1\x34\x1\x3A"+
			"\x1\x35\x1\x37\x1\x39\x3\xFFFF\x1\x52\x1\x53\x15\xFFFF\x1\x45\x4\xFFFF"+
			"\x1\x49\x3\xFFFF\x1\x31\x1\x41\x1\x32\x1\x42\x3\xFFFF\x1\x54\x13\xFFFF"+
			"\x1\xC\x2\xFFFF\x1\x4A\x9\xFFFF\x1\x17\x1\x46\x6\xFFFF\x1\x7\x2\xFFFF"+
			"\x1\x9\x1\xFFFF\x1\xA\x2\xFFFF\x1\x43\x1\xD\x6\xFFFF\x1\x4B\x5\xFFFF"+
			"\x1\xB\x6\xFFFF\x1\x18\x1\xFFFF\x1\xE\x3\xFFFF\x1\x15\x1\x48\x1\x4D\x1"+
			"\xFFFF\x1\x5\x1\x6\x1\x14\x1\x10\x1\x26\x1\x47\x1\xFFFF\x1\x4E\x2\xFFFF"+
			"\x1\xF\x2\xFFFF\x1\x1\x3\xFFFF\x1\x44\x1\xFFFF\x1\x8\x1\x19\x1\x4C\x1"+
			"\x11";
		private const string DFA35_specialS =
			"\xFA\xFFFF}>";
		private static readonly string[] DFA35_transitionS =
			{
				"\x2\x2D\x1\xFFFF\x2\x2D\x12\xFFFF\x1\x2D\x1\x1F\x1\x2A\x1\x2E\x1\x28"+
				"\x1\x1C\x1\x1D\x1\x29\x1\x13\x1\x14\x1\x17\x1\x19\x1\x3\x1\x1A\x1\x18"+
				"\x1\x1B\x1\x2B\x9\x2C\x1\x12\x1\x2\x1\x20\x1\x4\x1\x21\x1\x24\x1\xFFFF"+
				"\x1A\x28\x1\x15\x1\xFFFF\x1\x16\x1\x22\x1\x28\x1\xFFFF\x1\x7\x1\x27"+
				"\x1\xA\x1\xE\x1\x5\x1\xD\x1\x26\x1\x28\x1\xB\x2\x28\x1\xC\x5\x28\x1"+
				"\x8\x1\x6\x1\x1\x1\xF\x1\x9\x1\x25\x3\x28\x1\x10\x1\x23\x1\x11\x1\x1E",
				"\x1\x2F",
				"",
				"",
				"\x1\x30",
				"\x1\x34\x1\xFFFF\x1\x33\x9\xFFFF\x1\x32",
				"\x1\x36\x1\x37\xA\xFFFF\x1\x35\x2\xFFFF\x1\x38",
				"\x1\x39",
				"\x1\x3A",
				"\x1\x3B",
				"\x1\x3E\x6\xFFFF\x1\x3C\x6\xFFFF\x1\x3D",
				"\x1\x40\x7\xFFFF\x1\x3F",
				"\x1\x41",
				"\x1\x42\x2\xFFFF\x1\x43",
				"\x1\x45\x9\xFFFF\x1\x44",
				"\x1\x46",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x47",
				"\x1\x49\x1\xFFFF\xA\x4B",
				"\x1\x4C\x11\xFFFF\x1\x4D",
				"\x1\x4F\xF\xFFFF\x1\x51\x1\x50",
				"\x1\x54\x4\xFFFF\x1\x55\xD\xFFFF\x1\x53",
				"\x1\x57",
				"\x1\x5A\x16\xFFFF\x1\x59",
				"",
				"\x1\x5C",
				"\x1\x5E\x1\x5F",
				"\x1\x62\x1\x61",
				"\x1\x64",
				"\x1\x66\x3E\xFFFF\x1\x67",
				"",
				"\x1\x69",
				"\x1\x6A",
				"\x1\x6B",
				"",
				"",
				"",
				"\x1\x4B\x1\xFFFF\x8\x6E\x2\x4B\xA\xFFFF\x3\x4B\x11\xFFFF\x1\x6C\xB"+
				"\xFFFF\x3\x4B\x11\xFFFF\x1\x6C",
				"\x1\x4B\x1\xFFFF\xA\x6F\xA\xFFFF\x3\x4B\x1D\xFFFF\x3\x4B",
				"",
				"",
				"\x1\x70",
				"",
				"",
				"\x1\x71",
				"\x1\x72",
				"\x1\x73",
				"\x1\x74\x10\xFFFF\x1\x75",
				"\x1\x76",
				"\x1\x77\x12\xFFFF\x1\x78",
				"\x1\x79",
				"\x1\x7A",
				"\x1\x7B\xC\xFFFF\x1\x7C",
				"\x1\x7D\x2\xFFFF\x1\x7E",
				"\x1\x7F",
				"\x1\x80",
				"\x1\x81",
				"\x1\x82",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x84",
				"\x1\x85",
				"\x1\x86",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x14\x28\x1\x87\x5\x28",
				"\x1\x89",
				"\x1\x8B\x9\xFFFF\x1\x8A",
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
				"\x1\x8C",
				"",
				"",
				"\x1\x8E",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x90",
				"\x1\x91",
				"\x1\x92",
				"",
				"",
				"\x1\x4B\x1\xFFFF\x8\x6E\x2\x4B\xA\xFFFF\x3\x4B\x1D\xFFFF\x3\x4B",
				"\x1\x4B\x1\xFFFF\xA\x6F\xA\xFFFF\x3\x4B\x1D\xFFFF\x3\x4B",
				"\x1\x94",
				"\x1\x95",
				"\x1\x96",
				"\x1\x97",
				"\x1\x98",
				"\x1\x99",
				"\x1\x9A",
				"\x1\x9B",
				"\x1\x9C",
				"\x1\x9D",
				"\x1\x9E",
				"\x1\x9F",
				"\x1\xA0",
				"\x1\xA1",
				"\x1\xA2",
				"\x1\xA3",
				"\x1\xA4\x1\xA5",
				"\x1\xA6",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"",
				"\x1\xA8",
				"\x1\xA9",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xAB",
				"",
				"\x1\xAC",
				"\x1\xAD",
				"\x1\xAE",
				"",
				"",
				"",
				"",
				"\x1\xAF",
				"\x1\xB0",
				"\x1\xB1",
				"",
				"\x1\xB2",
				"\x1\xB3",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xB6",
				"\x1\xB7",
				"\x1\xB8",
				"\x1\xB9",
				"\x1\xBA",
				"\x1\xBB",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xBD",
				"\x1\xBE",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xC0",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xC2",
				"\x1\xC3",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xC6",
				"",
				"\x1\xC7",
				"\x1\xC8",
				"\x1\xC9",
				"\x1\xCA",
				"\x1\xCB",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xCD",
				"\x1\xCE",
				"\x1\xCF",
				"",
				"",
				"\x1\xD0",
				"\x1\xD1",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xD3",
				"\x1\xD4",
				"\x1\xD5",
				"",
				"\x1\xD6",
				"\x1\xD7",
				"",
				"\x1\xD8",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xDA",
				"",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xDC",
				"\x1\xDD",
				"\x1\xDE",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xE2",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xE9",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xEB",
				"",
				"\x1\xEC",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xEE",
				"\x1\xEF",
				"",
				"",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\xF1",
				"",
				"\x1\xF2",
				"\x1\xF3",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\xF5",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"",
				"\x1\x28\xB\xFFFF\xA\x28\x7\xFFFF\x1A\x28\x4\xFFFF\x1\x28\x1\xFFFF"+
				"\x1A\x28",
				"",
				"",
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

		public override string Description { get { return "1:1: Tokens : ( T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | T__67 | T__68 | T__69 | T__70 | T__71 | T__72 | T__73 | T__74 | T__75 | T__76 | T__77 | T__78 | T__79 | T__80 | T__81 | T__82 | T__83 | T__84 | T__85 | T__86 | T__87 | T__88 | T__89 | T__90 | T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | IDENTIFIER | CHARACTER_LITERAL | STRING_LITERAL | HEX_LITERAL | DECIMAL_LITERAL | OCTAL_LITERAL | FLOATING_POINT_LITERAL | WS | COMMENT | LINE_COMMENT | LINE_COMMAND );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

 
	#endregion

}
