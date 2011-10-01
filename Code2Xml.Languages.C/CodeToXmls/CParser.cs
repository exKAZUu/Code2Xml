using Code2Xml.Core.Antlr;
using System;
// $ANTLR 3.3 Nov 30, 2010 12:50:56 C.g 2011-06-08 18:58:13

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

/** ANSI C ANTLR v3 grammar

Translated from Jutta Degener's 1995 ANSI C yacc grammar by Terence Parr
July 2006.  The lexical rules were taken from the Java grammar.

Jutta says: "In 1985, Jeff Lee published his Yacc grammar (which
is accompanied by a matching Lex specification) for the April 30, 1985 draft
version of the ANSI C standard.  Tom Stockfisch reposted it to net.sources in
1987; that original, as mentioned in the answer to question 17.25 of the
comp.lang.c FAQ, can be ftp'ed from ftp.uu.net,
   file usenet/net.sources/ansi.c.grammar.Z.
I intend to keep this version as close to the current C Standard grammar as
possible; please let me know if you discover discrepancies. Jutta Degener, 1995"

Generally speaking, you need symbol table info to parse C; typedefs
define types and then IDENTIFIERS are either types or plain IDs.  I'm doing
the min necessary here tracking only type names.  This is a good example
of the global scope (called Symbols).  Every rule that declares its usage
of Symbols pushes a new copy on the stack effectively creating a new
symbol scope.  Also note rule declaration declares a rule scope that
lets any invoked rule see isTypedef boolean.  It's much easier than
passing that info down as parameters.  Very clean.  Rule
direct_declarator can then easily determine whether the IDENTIFIER
should be declared as a type name.

I have only tested this on a single file, though it is 3500 lines.

This grammar requires ANTLR v3.0.1 or higher.

Terence Parr
July 2006
*/
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class CParser : Antlr.Runtime.Parser, IAntlrParser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "IDENTIFIER", "HEX_LITERAL", "OCTAL_LITERAL", "DECIMAL_LITERAL", "CHARACTER_LITERAL", "STRING_LITERAL", "FLOATING_POINT_LITERAL", "LETTER", "EscapeSequence", "HexDigit", "IntegerTypeSuffix", "Exponent", "FloatTypeSuffix", "OctalEscape", "UnicodeEscape", "WS", "COMMENT", "LINE_COMMENT", "LINE_COMMAND", "'typedef'", "';'", "','", "'='", "'extern'", "'static'", "'auto'", "'register'", "'void'", "'char'", "'short'", "'int'", "'long'", "'float'", "'double'", "'signed'", "'unsigned'", "'{'", "'}'", "'struct'", "'union'", "':'", "'enum'", "'const'", "'volatile'", "'('", "')'", "'['", "']'", "'*'", "'...'", "'+'", "'-'", "'/'", "'%'", "'++'", "'--'", "'sizeof'", "'.'", "'->'", "'&'", "'~'", "'!'", "'*='", "'/='", "'%='", "'+='", "'-='", "'<<='", "'>>='", "'&='", "'^='", "'|='", "'?'", "'||'", "'&&'", "'|'", "'^'", "'=='", "'!='", "'<'", "'>'", "'<='", "'>='", "'<<'", "'>>'", "'case'", "'default'", "'if'", "'else'", "'switch'", "'while'", "'do'", "'for'", "'goto'", "'continue'", "'break'", "'return'"
	};
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

	protected class Symbols_scope
	{
		public Set types;
	}
	partial void Symbols_scopeInit( Symbols_scope scope );
	partial void Symbols_scopeAfter( Symbols_scope scope );
	protected Stack<Symbols_scope> Symbols_stack = new Stack<Symbols_scope>();

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, true, true, false, false, true, false, false, true, false, false, 
				false, false, false, false, true, false, false, false, false, false, 
				false, false, true, false, true, true, true, true, true, false, false, 
				true, false, false, true, false, false, true, false, false, false, false, 
				false, false, false, true, true, false, false, false, false, true, false, 
				false, false, false, false, false, false, false, false, false, false, 
				true, false, false, false, false, false, false, false, false, true, 
				false, , , , , false, false, false, , 
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public CParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public CParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		this.state.ruleMemo = new System.Collections.Generic.Dictionary<int, int>[219+1];

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

	public override string[] TokenNames { get { return CParser.tokenNames; } }
	public override string GrammarFileName { get { return "C.g"; } }


		boolean isTypeName(String name) {
			for (int i = Symbols_stack.size()-1; i>=0; i--) {
				Symbols_scope scope = (Symbols_scope)Symbols_stack.get(i);
				if ( scope.types.contains(name) ) {
					return true;
				}
			}
			return false;
		}


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class translation_unit_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_translation_unit();
	partial void Leave_translation_unit();

	// $ANTLR start "translation_unit"
	// C.g:58:1: translation_unit : ( external_declaration )+ ;
	[GrammarRule("translation_unit")]
	public CParser.translation_unit_return translation_unit()
	{
		Enter_translation_unit();
		EnterRule("translation_unit", 1);
		TraceIn("translation_unit", 1);
		Symbols_stack.Push(new Symbols_scope());Symbols_scopeInit(Symbols_stack.Peek());

		CParser.translation_unit_return retval = new CParser.translation_unit_return();
		retval.Start = (IToken)input.LT(1);
		int translation_unit_StartIndex = input.Index;
		object root_0 = null;

		CParser.external_declaration_return external_declaration1 = default(CParser.external_declaration_return);



		  ((Symbols_scope)Symbols_stack.Peek()).types = new HashSet();

		try { DebugEnterRule(GrammarFileName, "translation_unit");
		DebugLocation(58, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 1)) { return retval; }
			// C.g:63:2: ( ( external_declaration )+ )
			DebugEnterAlt(1);
			// C.g:63:4: ( external_declaration )+
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(63, 4);
			// C.g:63:4: ( external_declaration )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
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
					// C.g:0:0: external_declaration
					{
					DebugLocation(63, 4);
					PushFollow(Follow._external_declaration_in_translation_unit86);
					external_declaration1=external_declaration();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, external_declaration1.Tree, external_declaration1, retval);

					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					if (state.backtracking>0) {state.failed=true; return retval;}
					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;

			} finally { DebugExitSubRule(1); }


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
			TraceOut("translation_unit", 1);
			LeaveRule("translation_unit", 1);
			Leave_translation_unit();
			if (state.backtracking > 0) { Memoize(input, 1, translation_unit_StartIndex); }
			Symbols_scopeAfter(Symbols_stack.Peek());Symbols_stack.Pop();

		}
		DebugLocation(64, 1);
		} finally { DebugExitRule(GrammarFileName, "translation_unit"); }
		return retval;

	}
	// $ANTLR end "translation_unit"

	public class external_declaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_external_declaration();
	partial void Leave_external_declaration();

	// $ANTLR start "external_declaration"
	// C.g:66:1: external_declaration options {k=1; } : ( ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition | declaration );
	[GrammarRule("external_declaration")]
	public CParser.external_declaration_return external_declaration()
	{
		Enter_external_declaration();
		EnterRule("external_declaration", 2);
		TraceIn("external_declaration", 2);
		CParser.external_declaration_return retval = new CParser.external_declaration_return();
		retval.Start = (IToken)input.LT(1);
		int external_declaration_StartIndex = input.Index;
		object root_0 = null;

		CParser.function_definition_return function_definition2 = default(CParser.function_definition_return);
		CParser.declaration_return declaration3 = default(CParser.declaration_return);


		try { DebugEnterRule(GrammarFileName, "external_declaration");
		DebugLocation(66, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 2)) { return retval; }
			// C.g:82:2: ( ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition | declaration )
			int alt2=2;
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			try
			{
				alt2 = dfa2.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:82:4: ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(82, 62);
				PushFollow(Follow._function_definition_in_external_declaration122);
				function_definition2=function_definition();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, function_definition2.Tree, function_definition2, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:83:4: declaration
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(83, 4);
				PushFollow(Follow._declaration_in_external_declaration127);
				declaration3=declaration();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration3.Tree, declaration3, retval);

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
			TraceOut("external_declaration", 2);
			LeaveRule("external_declaration", 2);
			Leave_external_declaration();
			if (state.backtracking > 0) { Memoize(input, 2, external_declaration_StartIndex); }
		}
		DebugLocation(84, 1);
		} finally { DebugExitRule(GrammarFileName, "external_declaration"); }
		return retval;

	}
	// $ANTLR end "external_declaration"

	public class function_definition_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_function_definition();
	partial void Leave_function_definition();

	// $ANTLR start "function_definition"
	// C.g:86:1: function_definition : ( declaration_specifiers )? declarator ( ( declaration )+ compound_statement | compound_statement ) ;
	[GrammarRule("function_definition")]
	public CParser.function_definition_return function_definition()
	{
		Enter_function_definition();
		EnterRule("function_definition", 3);
		TraceIn("function_definition", 3);
		Symbols_stack.Push(new Symbols_scope());Symbols_scopeInit(Symbols_stack.Peek());

		CParser.function_definition_return retval = new CParser.function_definition_return();
		retval.Start = (IToken)input.LT(1);
		int function_definition_StartIndex = input.Index;
		object root_0 = null;

		CParser.declaration_specifiers_return declaration_specifiers4 = default(CParser.declaration_specifiers_return);
		CParser.declarator_return declarator5 = default(CParser.declarator_return);
		CParser.declaration_return declaration6 = default(CParser.declaration_return);
		CParser.compound_statement_return compound_statement7 = default(CParser.compound_statement_return);
		CParser.compound_statement_return compound_statement8 = default(CParser.compound_statement_return);



		  ((Symbols_scope)Symbols_stack.Peek()).types = new HashSet();

		try { DebugEnterRule(GrammarFileName, "function_definition");
		DebugLocation(86, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 3)) { return retval; }
			// C.g:91:2: ( ( declaration_specifiers )? declarator ( ( declaration )+ compound_statement | compound_statement ) )
			DebugEnterAlt(1);
			// C.g:91:4: ( declaration_specifiers )? declarator ( ( declaration )+ compound_statement | compound_statement )
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(91, 4);
			// C.g:91:4: ( declaration_specifiers )?
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
				// C.g:0:0: declaration_specifiers
				{
				DebugLocation(91, 4);
				PushFollow(Follow._declaration_specifiers_in_function_definition149);
				declaration_specifiers4=declaration_specifiers();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers4.Tree, declaration_specifiers4, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(3); }

			DebugLocation(91, 28);
			PushFollow(Follow._declarator_in_function_definition152);
			declarator5=declarator();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator5.Tree, declarator5, retval);
			DebugLocation(92, 3);
			// C.g:92:3: ( ( declaration )+ compound_statement | compound_statement )
			int alt5=2;
			try { DebugEnterSubRule(5);
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
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:92:5: ( declaration )+ compound_statement
				{
				DebugLocation(92, 5);
				// C.g:92:5: ( declaration )+
				int cnt4=0;
				try { DebugEnterSubRule(4);
				while (true)
				{
					int alt4=2;
					try { DebugEnterDecision(4, decisionCanBacktrack[4]);
					try
					{
						alt4 = dfa4.Predict(input);
					}
					catch (NoViableAltException nvae)
					{
						DebugRecognitionException(nvae);
						throw;
					}
					} finally { DebugExitDecision(4); }
					switch (alt4)
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:0:0: declaration
						{
						DebugLocation(92, 5);
						PushFollow(Follow._declaration_in_function_definition158);
						declaration6=declaration();
						PopFollow();
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration6.Tree, declaration6, retval);

						}
						break;

					default:
						if (cnt4 >= 1)
							goto loop4;

						if (state.backtracking>0) {state.failed=true; return retval;}
						EarlyExitException eee4 = new EarlyExitException( 4, input );
						DebugRecognitionException(eee4);
						throw eee4;
					}
					cnt4++;
				}
				loop4:
					;

				} finally { DebugExitSubRule(4); }

				DebugLocation(92, 18);
				PushFollow(Follow._compound_statement_in_function_definition161);
				compound_statement7=compound_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, compound_statement7.Tree, compound_statement7, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:93:5: compound_statement
				{
				DebugLocation(93, 5);
				PushFollow(Follow._compound_statement_in_function_definition168);
				compound_statement8=compound_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, compound_statement8.Tree, compound_statement8, retval);

				}
				break;

			}
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
			TraceOut("function_definition", 3);
			LeaveRule("function_definition", 3);
			Leave_function_definition();
			if (state.backtracking > 0) { Memoize(input, 3, function_definition_StartIndex); }
			Symbols_scopeAfter(Symbols_stack.Peek());Symbols_stack.Pop();

		}
		DebugLocation(95, 1);
		} finally { DebugExitRule(GrammarFileName, "function_definition"); }
		return retval;

	}
	// $ANTLR end "function_definition"

	protected class declaration_scope
	{
		public boolean isTypedef;
	}
	partial void declaration_scopeInit( declaration_scope scope );
	partial void declaration_scopeAfter( declaration_scope scope );
	protected Stack<declaration_scope> declaration_stack = new Stack<declaration_scope>();

	public class declaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_declaration();
	partial void Leave_declaration();

	// $ANTLR start "declaration"
	// C.g:97:1: declaration : ( 'typedef' ( declaration_specifiers )? init_declarator_list ';' | declaration_specifiers ( init_declarator_list )? ';' );
	[GrammarRule("declaration")]
	public CParser.declaration_return declaration()
	{
		Enter_declaration();
		EnterRule("declaration", 4);
		TraceIn("declaration", 4);
		declaration_stack.Push(new declaration_scope());declaration_scopeInit(declaration_stack.Peek());
		CParser.declaration_return retval = new CParser.declaration_return();
		retval.Start = (IToken)input.LT(1);
		int declaration_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal9=null;
		IToken char_literal12=null;
		IToken char_literal15=null;
		CParser.declaration_specifiers_return declaration_specifiers10 = default(CParser.declaration_specifiers_return);
		CParser.init_declarator_list_return init_declarator_list11 = default(CParser.init_declarator_list_return);
		CParser.declaration_specifiers_return declaration_specifiers13 = default(CParser.declaration_specifiers_return);
		CParser.init_declarator_list_return init_declarator_list14 = default(CParser.init_declarator_list_return);

		object string_literal9_tree=null;
		object char_literal12_tree=null;
		object char_literal15_tree=null;


		  ((declaration_scope)declaration_stack.Peek()).isTypedef = false;

		try { DebugEnterRule(GrammarFileName, "declaration");
		DebugLocation(97, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 4)) { return retval; }
			// C.g:104:2: ( 'typedef' ( declaration_specifiers )? init_declarator_list ';' | declaration_specifiers ( init_declarator_list )? ';' )
			int alt8=2;
			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
			try
			{
				alt8 = dfa8.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(8); }
			switch (alt8)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:104:4: 'typedef' ( declaration_specifiers )? init_declarator_list ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(104, 4);
				string_literal9=(IToken)Match(input,23,Follow._23_in_declaration196); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal9_tree = (object)adaptor.Create(string_literal9, retval);
				adaptor.AddChild(root_0, string_literal9_tree);
				}
				DebugLocation(104, 14);
				// C.g:104:14: ( declaration_specifiers )?
				int alt6=2;
				try { DebugEnterSubRule(6);
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
					// C.g:0:0: declaration_specifiers
					{
					DebugLocation(104, 14);
					PushFollow(Follow._declaration_specifiers_in_declaration198);
					declaration_specifiers10=declaration_specifiers();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers10.Tree, declaration_specifiers10, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(6); }

				DebugLocation(104, 38);
				if ( state.backtracking == 0 )
				{
					((declaration_scope)declaration_stack.Peek()).isTypedef =true;
				}
				DebugLocation(105, 4);
				PushFollow(Follow._init_declarator_list_in_declaration206);
				init_declarator_list11=init_declarator_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator_list11.Tree, init_declarator_list11, retval);
				DebugLocation(105, 25);
				char_literal12=(IToken)Match(input,24,Follow._24_in_declaration208); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal12_tree = (object)adaptor.Create(char_literal12, retval);
				adaptor.AddChild(root_0, char_literal12_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:106:4: declaration_specifiers ( init_declarator_list )? ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(106, 4);
				PushFollow(Follow._declaration_specifiers_in_declaration214);
				declaration_specifiers13=declaration_specifiers();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers13.Tree, declaration_specifiers13, retval);
				DebugLocation(106, 27);
				// C.g:106:27: ( init_declarator_list )?
				int alt7=2;
				try { DebugEnterSubRule(7);
				try { DebugEnterDecision(7, decisionCanBacktrack[7]);
				int LA7_0 = input.LA(1);

				if ((LA7_0==IDENTIFIER||LA7_0==48||LA7_0==52))
				{
					alt7=1;
				}
				} finally { DebugExitDecision(7); }
				switch (alt7)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: init_declarator_list
					{
					DebugLocation(106, 27);
					PushFollow(Follow._init_declarator_list_in_declaration216);
					init_declarator_list14=init_declarator_list();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator_list14.Tree, init_declarator_list14, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(7); }

				DebugLocation(106, 49);
				char_literal15=(IToken)Match(input,24,Follow._24_in_declaration219); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal15_tree = (object)adaptor.Create(char_literal15, retval);
				adaptor.AddChild(root_0, char_literal15_tree);
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
			TraceOut("declaration", 4);
			LeaveRule("declaration", 4);
			Leave_declaration();
			if (state.backtracking > 0) { Memoize(input, 4, declaration_StartIndex); }
			declaration_scopeAfter(declaration_stack.Peek());declaration_stack.Pop();
		}
		DebugLocation(107, 1);
		} finally { DebugExitRule(GrammarFileName, "declaration"); }
		return retval;

	}
	// $ANTLR end "declaration"

	public class declaration_specifiers_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_declaration_specifiers();
	partial void Leave_declaration_specifiers();

	// $ANTLR start "declaration_specifiers"
	// C.g:109:1: declaration_specifiers : ( storage_class_specifier | type_specifier | type_qualifier )+ ;
	[GrammarRule("declaration_specifiers")]
	public CParser.declaration_specifiers_return declaration_specifiers()
	{
		Enter_declaration_specifiers();
		EnterRule("declaration_specifiers", 5);
		TraceIn("declaration_specifiers", 5);
		CParser.declaration_specifiers_return retval = new CParser.declaration_specifiers_return();
		retval.Start = (IToken)input.LT(1);
		int declaration_specifiers_StartIndex = input.Index;
		object root_0 = null;

		CParser.storage_class_specifier_return storage_class_specifier16 = default(CParser.storage_class_specifier_return);
		CParser.type_specifier_return type_specifier17 = default(CParser.type_specifier_return);
		CParser.type_qualifier_return type_qualifier18 = default(CParser.type_qualifier_return);


		try { DebugEnterRule(GrammarFileName, "declaration_specifiers");
		DebugLocation(109, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 5)) { return retval; }
			// C.g:110:2: ( ( storage_class_specifier | type_specifier | type_qualifier )+ )
			DebugEnterAlt(1);
			// C.g:110:6: ( storage_class_specifier | type_specifier | type_qualifier )+
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(110, 6);
			// C.g:110:6: ( storage_class_specifier | type_specifier | type_qualifier )+
			int cnt9=0;
			try { DebugEnterSubRule(9);
			while (true)
			{
				int alt9=4;
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
					// C.g:110:10: storage_class_specifier
					{
					DebugLocation(110, 10);
					PushFollow(Follow._storage_class_specifier_in_declaration_specifiers236);
					storage_class_specifier16=storage_class_specifier();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, storage_class_specifier16.Tree, storage_class_specifier16, retval);

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C.g:111:7: type_specifier
					{
					DebugLocation(111, 7);
					PushFollow(Follow._type_specifier_in_declaration_specifiers244);
					type_specifier17=type_specifier();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_specifier17.Tree, type_specifier17, retval);

					}
					break;
				case 3:
					DebugEnterAlt(3);
					// C.g:112:13: type_qualifier
					{
					DebugLocation(112, 13);
					PushFollow(Follow._type_qualifier_in_declaration_specifiers258);
					type_qualifier18=type_qualifier();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_qualifier18.Tree, type_qualifier18, retval);

					}
					break;

				default:
					if (cnt9 >= 1)
						goto loop9;

					if (state.backtracking>0) {state.failed=true; return retval;}
					EarlyExitException eee9 = new EarlyExitException( 9, input );
					DebugRecognitionException(eee9);
					throw eee9;
				}
				cnt9++;
			}
			loop9:
				;

			} finally { DebugExitSubRule(9); }


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
			TraceOut("declaration_specifiers", 5);
			LeaveRule("declaration_specifiers", 5);
			Leave_declaration_specifiers();
			if (state.backtracking > 0) { Memoize(input, 5, declaration_specifiers_StartIndex); }
		}
		DebugLocation(114, 1);
		} finally { DebugExitRule(GrammarFileName, "declaration_specifiers"); }
		return retval;

	}
	// $ANTLR end "declaration_specifiers"

	public class init_declarator_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_init_declarator_list();
	partial void Leave_init_declarator_list();

	// $ANTLR start "init_declarator_list"
	// C.g:116:1: init_declarator_list : init_declarator ( ',' init_declarator )* ;
	[GrammarRule("init_declarator_list")]
	public CParser.init_declarator_list_return init_declarator_list()
	{
		Enter_init_declarator_list();
		EnterRule("init_declarator_list", 6);
		TraceIn("init_declarator_list", 6);
		CParser.init_declarator_list_return retval = new CParser.init_declarator_list_return();
		retval.Start = (IToken)input.LT(1);
		int init_declarator_list_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal20=null;
		CParser.init_declarator_return init_declarator19 = default(CParser.init_declarator_return);
		CParser.init_declarator_return init_declarator21 = default(CParser.init_declarator_return);

		object char_literal20_tree=null;

		try { DebugEnterRule(GrammarFileName, "init_declarator_list");
		DebugLocation(116, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 6)) { return retval; }
			// C.g:117:2: ( init_declarator ( ',' init_declarator )* )
			DebugEnterAlt(1);
			// C.g:117:4: init_declarator ( ',' init_declarator )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(117, 4);
			PushFollow(Follow._init_declarator_in_init_declarator_list280);
			init_declarator19=init_declarator();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator19.Tree, init_declarator19, retval);
			DebugLocation(117, 20);
			// C.g:117:20: ( ',' init_declarator )*
			try { DebugEnterSubRule(10);
			while (true)
			{
				int alt10=2;
				try { DebugEnterDecision(10, decisionCanBacktrack[10]);
				int LA10_0 = input.LA(1);

				if ((LA10_0==25))
				{
					alt10=1;
				}


				} finally { DebugExitDecision(10); }
				switch ( alt10 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:117:21: ',' init_declarator
					{
					DebugLocation(117, 21);
					char_literal20=(IToken)Match(input,25,Follow._25_in_init_declarator_list283); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal20_tree = (object)adaptor.Create(char_literal20, retval);
					adaptor.AddChild(root_0, char_literal20_tree);
					}
					DebugLocation(117, 25);
					PushFollow(Follow._init_declarator_in_init_declarator_list285);
					init_declarator21=init_declarator();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator21.Tree, init_declarator21, retval);

					}
					break;

				default:
					goto loop10;
				}
			}

			loop10:
				;

			} finally { DebugExitSubRule(10); }


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
			TraceOut("init_declarator_list", 6);
			LeaveRule("init_declarator_list", 6);
			Leave_init_declarator_list();
			if (state.backtracking > 0) { Memoize(input, 6, init_declarator_list_StartIndex); }
		}
		DebugLocation(118, 1);
		} finally { DebugExitRule(GrammarFileName, "init_declarator_list"); }
		return retval;

	}
	// $ANTLR end "init_declarator_list"

	public class init_declarator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_init_declarator();
	partial void Leave_init_declarator();

	// $ANTLR start "init_declarator"
	// C.g:120:1: init_declarator : declarator ( '=' initializer )? ;
	[GrammarRule("init_declarator")]
	public CParser.init_declarator_return init_declarator()
	{
		Enter_init_declarator();
		EnterRule("init_declarator", 7);
		TraceIn("init_declarator", 7);
		CParser.init_declarator_return retval = new CParser.init_declarator_return();
		retval.Start = (IToken)input.LT(1);
		int init_declarator_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal23=null;
		CParser.declarator_return declarator22 = default(CParser.declarator_return);
		CParser.initializer_return initializer24 = default(CParser.initializer_return);

		object char_literal23_tree=null;

		try { DebugEnterRule(GrammarFileName, "init_declarator");
		DebugLocation(120, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 7)) { return retval; }
			// C.g:121:2: ( declarator ( '=' initializer )? )
			DebugEnterAlt(1);
			// C.g:121:4: declarator ( '=' initializer )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(121, 4);
			PushFollow(Follow._declarator_in_init_declarator298);
			declarator22=declarator();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator22.Tree, declarator22, retval);
			DebugLocation(121, 15);
			// C.g:121:15: ( '=' initializer )?
			int alt11=2;
			try { DebugEnterSubRule(11);
			try { DebugEnterDecision(11, decisionCanBacktrack[11]);
			int LA11_0 = input.LA(1);

			if ((LA11_0==26))
			{
				alt11=1;
			}
			} finally { DebugExitDecision(11); }
			switch (alt11)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:121:16: '=' initializer
				{
				DebugLocation(121, 16);
				char_literal23=(IToken)Match(input,26,Follow._26_in_init_declarator301); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal23_tree = (object)adaptor.Create(char_literal23, retval);
				adaptor.AddChild(root_0, char_literal23_tree);
				}
				DebugLocation(121, 20);
				PushFollow(Follow._initializer_in_init_declarator303);
				initializer24=initializer();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer24.Tree, initializer24, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(11); }


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
			TraceOut("init_declarator", 7);
			LeaveRule("init_declarator", 7);
			Leave_init_declarator();
			if (state.backtracking > 0) { Memoize(input, 7, init_declarator_StartIndex); }
		}
		DebugLocation(122, 1);
		} finally { DebugExitRule(GrammarFileName, "init_declarator"); }
		return retval;

	}
	// $ANTLR end "init_declarator"

	public class storage_class_specifier_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_storage_class_specifier();
	partial void Leave_storage_class_specifier();

	// $ANTLR start "storage_class_specifier"
	// C.g:124:1: storage_class_specifier : ( 'extern' | 'static' | 'auto' | 'register' );
	[GrammarRule("storage_class_specifier")]
	public CParser.storage_class_specifier_return storage_class_specifier()
	{
		Enter_storage_class_specifier();
		EnterRule("storage_class_specifier", 8);
		TraceIn("storage_class_specifier", 8);
		CParser.storage_class_specifier_return retval = new CParser.storage_class_specifier_return();
		retval.Start = (IToken)input.LT(1);
		int storage_class_specifier_StartIndex = input.Index;
		object root_0 = null;

		IToken set25=null;

		object set25_tree=null;

		try { DebugEnterRule(GrammarFileName, "storage_class_specifier");
		DebugLocation(124, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 8)) { return retval; }
			// C.g:125:2: ( 'extern' | 'static' | 'auto' | 'register' )
			DebugEnterAlt(1);
			// C.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(125, 2);
			set25=(IToken)input.LT(1);
			if ((input.LA(1)>=27 && input.LA(1)<=30))
			{
				input.Consume();
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set25, retval));
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
			TraceOut("storage_class_specifier", 8);
			LeaveRule("storage_class_specifier", 8);
			Leave_storage_class_specifier();
			if (state.backtracking > 0) { Memoize(input, 8, storage_class_specifier_StartIndex); }
		}
		DebugLocation(129, 1);
		} finally { DebugExitRule(GrammarFileName, "storage_class_specifier"); }
		return retval;

	}
	// $ANTLR end "storage_class_specifier"

	public class type_specifier_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_type_specifier();
	partial void Leave_type_specifier();

	// $ANTLR start "type_specifier"
	// C.g:131:1: type_specifier : ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | struct_or_union_specifier | enum_specifier | type_id );
	[GrammarRule("type_specifier")]
	public CParser.type_specifier_return type_specifier()
	{
		Enter_type_specifier();
		EnterRule("type_specifier", 9);
		TraceIn("type_specifier", 9);
		CParser.type_specifier_return retval = new CParser.type_specifier_return();
		retval.Start = (IToken)input.LT(1);
		int type_specifier_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal26=null;
		IToken string_literal27=null;
		IToken string_literal28=null;
		IToken string_literal29=null;
		IToken string_literal30=null;
		IToken string_literal31=null;
		IToken string_literal32=null;
		IToken string_literal33=null;
		IToken string_literal34=null;
		CParser.struct_or_union_specifier_return struct_or_union_specifier35 = default(CParser.struct_or_union_specifier_return);
		CParser.enum_specifier_return enum_specifier36 = default(CParser.enum_specifier_return);
		CParser.type_id_return type_id37 = default(CParser.type_id_return);

		object string_literal26_tree=null;
		object string_literal27_tree=null;
		object string_literal28_tree=null;
		object string_literal29_tree=null;
		object string_literal30_tree=null;
		object string_literal31_tree=null;
		object string_literal32_tree=null;
		object string_literal33_tree=null;
		object string_literal34_tree=null;

		try { DebugEnterRule(GrammarFileName, "type_specifier");
		DebugLocation(131, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 9)) { return retval; }
			// C.g:132:2: ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | struct_or_union_specifier | enum_specifier | type_id )
			int alt12=12;
			try { DebugEnterDecision(12, decisionCanBacktrack[12]);
			try
			{
				alt12 = dfa12.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(12); }
			switch (alt12)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:132:4: 'void'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(132, 4);
				string_literal26=(IToken)Match(input,31,Follow._31_in_type_specifier342); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal26_tree = (object)adaptor.Create(string_literal26, retval);
				adaptor.AddChild(root_0, string_literal26_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:133:4: 'char'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(133, 4);
				string_literal27=(IToken)Match(input,32,Follow._32_in_type_specifier347); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal27_tree = (object)adaptor.Create(string_literal27, retval);
				adaptor.AddChild(root_0, string_literal27_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:134:4: 'short'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(134, 4);
				string_literal28=(IToken)Match(input,33,Follow._33_in_type_specifier352); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal28_tree = (object)adaptor.Create(string_literal28, retval);
				adaptor.AddChild(root_0, string_literal28_tree);
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:135:4: 'int'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(135, 4);
				string_literal29=(IToken)Match(input,34,Follow._34_in_type_specifier357); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal29_tree = (object)adaptor.Create(string_literal29, retval);
				adaptor.AddChild(root_0, string_literal29_tree);
				}

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C.g:136:4: 'long'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(136, 4);
				string_literal30=(IToken)Match(input,35,Follow._35_in_type_specifier362); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal30_tree = (object)adaptor.Create(string_literal30, retval);
				adaptor.AddChild(root_0, string_literal30_tree);
				}

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// C.g:137:4: 'float'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(137, 4);
				string_literal31=(IToken)Match(input,36,Follow._36_in_type_specifier367); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal31_tree = (object)adaptor.Create(string_literal31, retval);
				adaptor.AddChild(root_0, string_literal31_tree);
				}

				}
				break;
			case 7:
				DebugEnterAlt(7);
				// C.g:138:4: 'double'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(138, 4);
				string_literal32=(IToken)Match(input,37,Follow._37_in_type_specifier372); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal32_tree = (object)adaptor.Create(string_literal32, retval);
				adaptor.AddChild(root_0, string_literal32_tree);
				}

				}
				break;
			case 8:
				DebugEnterAlt(8);
				// C.g:139:4: 'signed'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(139, 4);
				string_literal33=(IToken)Match(input,38,Follow._38_in_type_specifier377); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal33_tree = (object)adaptor.Create(string_literal33, retval);
				adaptor.AddChild(root_0, string_literal33_tree);
				}

				}
				break;
			case 9:
				DebugEnterAlt(9);
				// C.g:140:4: 'unsigned'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(140, 4);
				string_literal34=(IToken)Match(input,39,Follow._39_in_type_specifier382); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal34_tree = (object)adaptor.Create(string_literal34, retval);
				adaptor.AddChild(root_0, string_literal34_tree);
				}

				}
				break;
			case 10:
				DebugEnterAlt(10);
				// C.g:141:4: struct_or_union_specifier
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(141, 4);
				PushFollow(Follow._struct_or_union_specifier_in_type_specifier387);
				struct_or_union_specifier35=struct_or_union_specifier();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_or_union_specifier35.Tree, struct_or_union_specifier35, retval);

				}
				break;
			case 11:
				DebugEnterAlt(11);
				// C.g:142:4: enum_specifier
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(142, 4);
				PushFollow(Follow._enum_specifier_in_type_specifier392);
				enum_specifier36=enum_specifier();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enum_specifier36.Tree, enum_specifier36, retval);

				}
				break;
			case 12:
				DebugEnterAlt(12);
				// C.g:143:4: type_id
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(143, 4);
				PushFollow(Follow._type_id_in_type_specifier397);
				type_id37=type_id();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_id37.Tree, type_id37, retval);

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
			TraceOut("type_specifier", 9);
			LeaveRule("type_specifier", 9);
			Leave_type_specifier();
			if (state.backtracking > 0) { Memoize(input, 9, type_specifier_StartIndex); }
		}
		DebugLocation(144, 1);
		} finally { DebugExitRule(GrammarFileName, "type_specifier"); }
		return retval;

	}
	// $ANTLR end "type_specifier"

	public class type_id_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_type_id();
	partial void Leave_type_id();

	// $ANTLR start "type_id"
	// C.g:146:1: type_id : {...}? IDENTIFIER ;
	[GrammarRule("type_id")]
	public CParser.type_id_return type_id()
	{
		Enter_type_id();
		EnterRule("type_id", 10);
		TraceIn("type_id", 10);
		CParser.type_id_return retval = new CParser.type_id_return();
		retval.Start = (IToken)input.LT(1);
		int type_id_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENTIFIER38=null;

		object IDENTIFIER38_tree=null;

		try { DebugEnterRule(GrammarFileName, "type_id");
		DebugLocation(146, 4);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 10)) { return retval; }
			// C.g:147:5: ({...}? IDENTIFIER )
			DebugEnterAlt(1);
			// C.g:147:9: {...}? IDENTIFIER
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(147, 9);
			if (!((isTypeName(input.LT(1).getText()))))
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				throw new FailedPredicateException(input, "type_id", "isTypeName(input.LT(1).getText())");
			}
			DebugLocation(147, 46);
			IDENTIFIER38=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_type_id415), "IDENTIFIER"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			IDENTIFIER38_tree = (object)adaptor.Create(IDENTIFIER38, retval);
			adaptor.AddChild(root_0, IDENTIFIER38_tree);
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
			TraceOut("type_id", 10);
			LeaveRule("type_id", 10);
			Leave_type_id();
			if (state.backtracking > 0) { Memoize(input, 10, type_id_StartIndex); }
		}
		DebugLocation(149, 4);
		} finally { DebugExitRule(GrammarFileName, "type_id"); }
		return retval;

	}
	// $ANTLR end "type_id"

	public class struct_or_union_specifier_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_struct_or_union_specifier();
	partial void Leave_struct_or_union_specifier();

	// $ANTLR start "struct_or_union_specifier"
	// C.g:151:1: struct_or_union_specifier options {k=3; } : ( struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}' | struct_or_union IDENTIFIER );
	[GrammarRule("struct_or_union_specifier")]
	public CParser.struct_or_union_specifier_return struct_or_union_specifier()
	{
		Enter_struct_or_union_specifier();
		EnterRule("struct_or_union_specifier", 11);
		TraceIn("struct_or_union_specifier", 11);
		Symbols_stack.Push(new Symbols_scope());Symbols_scopeInit(Symbols_stack.Peek());

		CParser.struct_or_union_specifier_return retval = new CParser.struct_or_union_specifier_return();
		retval.Start = (IToken)input.LT(1);
		int struct_or_union_specifier_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENTIFIER40=null;
		IToken char_literal41=null;
		IToken char_literal43=null;
		IToken IDENTIFIER45=null;
		CParser.struct_or_union_return struct_or_union39 = default(CParser.struct_or_union_return);
		CParser.struct_declaration_list_return struct_declaration_list42 = default(CParser.struct_declaration_list_return);
		CParser.struct_or_union_return struct_or_union44 = default(CParser.struct_or_union_return);

		object IDENTIFIER40_tree=null;
		object char_literal41_tree=null;
		object char_literal43_tree=null;
		object IDENTIFIER45_tree=null;


		  ((Symbols_scope)Symbols_stack.Peek()).types = new HashSet();

		try { DebugEnterRule(GrammarFileName, "struct_or_union_specifier");
		DebugLocation(151, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 11)) { return retval; }
			// C.g:157:2: ( struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}' | struct_or_union IDENTIFIER )
			int alt14=2;
			try { DebugEnterDecision(14, decisionCanBacktrack[14]);
			try
			{
				alt14 = dfa14.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(14); }
			switch (alt14)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:157:4: struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(157, 4);
				PushFollow(Follow._struct_or_union_in_struct_or_union_specifier448);
				struct_or_union39=struct_or_union();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_or_union39.Tree, struct_or_union39, retval);
				DebugLocation(157, 20);
				// C.g:157:20: ( IDENTIFIER )?
				int alt13=2;
				try { DebugEnterSubRule(13);
				try { DebugEnterDecision(13, decisionCanBacktrack[13]);
				int LA13_0 = input.LA(1);

				if ((LA13_0==IDENTIFIER))
				{
					alt13=1;
				}
				} finally { DebugExitDecision(13); }
				switch (alt13)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: IDENTIFIER
					{
					DebugLocation(157, 20);
					IDENTIFIER40=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_struct_or_union_specifier450), "IDENTIFIER"); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					IDENTIFIER40_tree = (object)adaptor.Create(IDENTIFIER40, retval);
					adaptor.AddChild(root_0, IDENTIFIER40_tree);
					}

					}
					break;

				}
				} finally { DebugExitSubRule(13); }

				DebugLocation(157, 32);
				char_literal41=(IToken)Match(input,40,Follow._40_in_struct_or_union_specifier453); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal41_tree = (object)adaptor.Create(char_literal41, retval);
				adaptor.AddChild(root_0, char_literal41_tree);
				}
				DebugLocation(157, 36);
				PushFollow(Follow._struct_declaration_list_in_struct_or_union_specifier455);
				struct_declaration_list42=struct_declaration_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declaration_list42.Tree, struct_declaration_list42, retval);
				DebugLocation(157, 60);
				char_literal43=(IToken)Match(input,41,Follow._41_in_struct_or_union_specifier457); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal43_tree = (object)adaptor.Create(char_literal43, retval);
				adaptor.AddChild(root_0, char_literal43_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:158:4: struct_or_union IDENTIFIER
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(158, 4);
				PushFollow(Follow._struct_or_union_in_struct_or_union_specifier462);
				struct_or_union44=struct_or_union();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_or_union44.Tree, struct_or_union44, retval);
				DebugLocation(158, 20);
				IDENTIFIER45=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_struct_or_union_specifier464), "IDENTIFIER"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENTIFIER45_tree = (object)adaptor.Create(IDENTIFIER45, retval);
				adaptor.AddChild(root_0, IDENTIFIER45_tree);
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
			TraceOut("struct_or_union_specifier", 11);
			LeaveRule("struct_or_union_specifier", 11);
			Leave_struct_or_union_specifier();
			if (state.backtracking > 0) { Memoize(input, 11, struct_or_union_specifier_StartIndex); }
			Symbols_scopeAfter(Symbols_stack.Peek());Symbols_stack.Pop();

		}
		DebugLocation(159, 1);
		} finally { DebugExitRule(GrammarFileName, "struct_or_union_specifier"); }
		return retval;

	}
	// $ANTLR end "struct_or_union_specifier"

	public class struct_or_union_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_struct_or_union();
	partial void Leave_struct_or_union();

	// $ANTLR start "struct_or_union"
	// C.g:161:1: struct_or_union : ( 'struct' | 'union' );
	[GrammarRule("struct_or_union")]
	public CParser.struct_or_union_return struct_or_union()
	{
		Enter_struct_or_union();
		EnterRule("struct_or_union", 12);
		TraceIn("struct_or_union", 12);
		CParser.struct_or_union_return retval = new CParser.struct_or_union_return();
		retval.Start = (IToken)input.LT(1);
		int struct_or_union_StartIndex = input.Index;
		object root_0 = null;

		IToken set46=null;

		object set46_tree=null;

		try { DebugEnterRule(GrammarFileName, "struct_or_union");
		DebugLocation(161, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 12)) { return retval; }
			// C.g:162:2: ( 'struct' | 'union' )
			DebugEnterAlt(1);
			// C.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(162, 2);
			set46=(IToken)input.LT(1);
			if ((input.LA(1)>=42 && input.LA(1)<=43))
			{
				input.Consume();
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set46, retval));
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
			TraceOut("struct_or_union", 12);
			LeaveRule("struct_or_union", 12);
			Leave_struct_or_union();
			if (state.backtracking > 0) { Memoize(input, 12, struct_or_union_StartIndex); }
		}
		DebugLocation(164, 1);
		} finally { DebugExitRule(GrammarFileName, "struct_or_union"); }
		return retval;

	}
	// $ANTLR end "struct_or_union"

	public class struct_declaration_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_struct_declaration_list();
	partial void Leave_struct_declaration_list();

	// $ANTLR start "struct_declaration_list"
	// C.g:166:1: struct_declaration_list : ( struct_declaration )+ ;
	[GrammarRule("struct_declaration_list")]
	public CParser.struct_declaration_list_return struct_declaration_list()
	{
		Enter_struct_declaration_list();
		EnterRule("struct_declaration_list", 13);
		TraceIn("struct_declaration_list", 13);
		CParser.struct_declaration_list_return retval = new CParser.struct_declaration_list_return();
		retval.Start = (IToken)input.LT(1);
		int struct_declaration_list_StartIndex = input.Index;
		object root_0 = null;

		CParser.struct_declaration_return struct_declaration47 = default(CParser.struct_declaration_return);


		try { DebugEnterRule(GrammarFileName, "struct_declaration_list");
		DebugLocation(166, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 13)) { return retval; }
			// C.g:167:2: ( ( struct_declaration )+ )
			DebugEnterAlt(1);
			// C.g:167:4: ( struct_declaration )+
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(167, 4);
			// C.g:167:4: ( struct_declaration )+
			int cnt15=0;
			try { DebugEnterSubRule(15);
			while (true)
			{
				int alt15=2;
				try { DebugEnterDecision(15, decisionCanBacktrack[15]);
				try
				{
					alt15 = dfa15.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(15); }
				switch (alt15)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: struct_declaration
					{
					DebugLocation(167, 4);
					PushFollow(Follow._struct_declaration_in_struct_declaration_list491);
					struct_declaration47=struct_declaration();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declaration47.Tree, struct_declaration47, retval);

					}
					break;

				default:
					if (cnt15 >= 1)
						goto loop15;

					if (state.backtracking>0) {state.failed=true; return retval;}
					EarlyExitException eee15 = new EarlyExitException( 15, input );
					DebugRecognitionException(eee15);
					throw eee15;
				}
				cnt15++;
			}
			loop15:
				;

			} finally { DebugExitSubRule(15); }


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
			TraceOut("struct_declaration_list", 13);
			LeaveRule("struct_declaration_list", 13);
			Leave_struct_declaration_list();
			if (state.backtracking > 0) { Memoize(input, 13, struct_declaration_list_StartIndex); }
		}
		DebugLocation(168, 1);
		} finally { DebugExitRule(GrammarFileName, "struct_declaration_list"); }
		return retval;

	}
	// $ANTLR end "struct_declaration_list"

	public class struct_declaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_struct_declaration();
	partial void Leave_struct_declaration();

	// $ANTLR start "struct_declaration"
	// C.g:170:1: struct_declaration : specifier_qualifier_list struct_declarator_list ';' ;
	[GrammarRule("struct_declaration")]
	public CParser.struct_declaration_return struct_declaration()
	{
		Enter_struct_declaration();
		EnterRule("struct_declaration", 14);
		TraceIn("struct_declaration", 14);
		CParser.struct_declaration_return retval = new CParser.struct_declaration_return();
		retval.Start = (IToken)input.LT(1);
		int struct_declaration_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal50=null;
		CParser.specifier_qualifier_list_return specifier_qualifier_list48 = default(CParser.specifier_qualifier_list_return);
		CParser.struct_declarator_list_return struct_declarator_list49 = default(CParser.struct_declarator_list_return);

		object char_literal50_tree=null;

		try { DebugEnterRule(GrammarFileName, "struct_declaration");
		DebugLocation(170, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 14)) { return retval; }
			// C.g:171:2: ( specifier_qualifier_list struct_declarator_list ';' )
			DebugEnterAlt(1);
			// C.g:171:4: specifier_qualifier_list struct_declarator_list ';'
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(171, 4);
			PushFollow(Follow._specifier_qualifier_list_in_struct_declaration503);
			specifier_qualifier_list48=specifier_qualifier_list();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, specifier_qualifier_list48.Tree, specifier_qualifier_list48, retval);
			DebugLocation(171, 29);
			PushFollow(Follow._struct_declarator_list_in_struct_declaration505);
			struct_declarator_list49=struct_declarator_list();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declarator_list49.Tree, struct_declarator_list49, retval);
			DebugLocation(171, 52);
			char_literal50=(IToken)Match(input,24,Follow._24_in_struct_declaration507); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal50_tree = (object)adaptor.Create(char_literal50, retval);
			adaptor.AddChild(root_0, char_literal50_tree);
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
			TraceOut("struct_declaration", 14);
			LeaveRule("struct_declaration", 14);
			Leave_struct_declaration();
			if (state.backtracking > 0) { Memoize(input, 14, struct_declaration_StartIndex); }
		}
		DebugLocation(172, 1);
		} finally { DebugExitRule(GrammarFileName, "struct_declaration"); }
		return retval;

	}
	// $ANTLR end "struct_declaration"

	public class specifier_qualifier_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_specifier_qualifier_list();
	partial void Leave_specifier_qualifier_list();

	// $ANTLR start "specifier_qualifier_list"
	// C.g:174:1: specifier_qualifier_list : ( type_qualifier | type_specifier )+ ;
	[GrammarRule("specifier_qualifier_list")]
	public CParser.specifier_qualifier_list_return specifier_qualifier_list()
	{
		Enter_specifier_qualifier_list();
		EnterRule("specifier_qualifier_list", 15);
		TraceIn("specifier_qualifier_list", 15);
		CParser.specifier_qualifier_list_return retval = new CParser.specifier_qualifier_list_return();
		retval.Start = (IToken)input.LT(1);
		int specifier_qualifier_list_StartIndex = input.Index;
		object root_0 = null;

		CParser.type_qualifier_return type_qualifier51 = default(CParser.type_qualifier_return);
		CParser.type_specifier_return type_specifier52 = default(CParser.type_specifier_return);


		try { DebugEnterRule(GrammarFileName, "specifier_qualifier_list");
		DebugLocation(174, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 15)) { return retval; }
			// C.g:175:2: ( ( type_qualifier | type_specifier )+ )
			DebugEnterAlt(1);
			// C.g:175:4: ( type_qualifier | type_specifier )+
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(175, 4);
			// C.g:175:4: ( type_qualifier | type_specifier )+
			int cnt16=0;
			try { DebugEnterSubRule(16);
			while (true)
			{
				int alt16=3;
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
				switch (alt16)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:175:6: type_qualifier
					{
					DebugLocation(175, 6);
					PushFollow(Follow._type_qualifier_in_specifier_qualifier_list520);
					type_qualifier51=type_qualifier();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_qualifier51.Tree, type_qualifier51, retval);

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C.g:175:23: type_specifier
					{
					DebugLocation(175, 23);
					PushFollow(Follow._type_specifier_in_specifier_qualifier_list524);
					type_specifier52=type_specifier();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_specifier52.Tree, type_specifier52, retval);

					}
					break;

				default:
					if (cnt16 >= 1)
						goto loop16;

					if (state.backtracking>0) {state.failed=true; return retval;}
					EarlyExitException eee16 = new EarlyExitException( 16, input );
					DebugRecognitionException(eee16);
					throw eee16;
				}
				cnt16++;
			}
			loop16:
				;

			} finally { DebugExitSubRule(16); }


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
			TraceOut("specifier_qualifier_list", 15);
			LeaveRule("specifier_qualifier_list", 15);
			Leave_specifier_qualifier_list();
			if (state.backtracking > 0) { Memoize(input, 15, specifier_qualifier_list_StartIndex); }
		}
		DebugLocation(176, 1);
		} finally { DebugExitRule(GrammarFileName, "specifier_qualifier_list"); }
		return retval;

	}
	// $ANTLR end "specifier_qualifier_list"

	public class struct_declarator_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_struct_declarator_list();
	partial void Leave_struct_declarator_list();

	// $ANTLR start "struct_declarator_list"
	// C.g:178:1: struct_declarator_list : struct_declarator ( ',' struct_declarator )* ;
	[GrammarRule("struct_declarator_list")]
	public CParser.struct_declarator_list_return struct_declarator_list()
	{
		Enter_struct_declarator_list();
		EnterRule("struct_declarator_list", 16);
		TraceIn("struct_declarator_list", 16);
		CParser.struct_declarator_list_return retval = new CParser.struct_declarator_list_return();
		retval.Start = (IToken)input.LT(1);
		int struct_declarator_list_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal54=null;
		CParser.struct_declarator_return struct_declarator53 = default(CParser.struct_declarator_return);
		CParser.struct_declarator_return struct_declarator55 = default(CParser.struct_declarator_return);

		object char_literal54_tree=null;

		try { DebugEnterRule(GrammarFileName, "struct_declarator_list");
		DebugLocation(178, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 16)) { return retval; }
			// C.g:179:2: ( struct_declarator ( ',' struct_declarator )* )
			DebugEnterAlt(1);
			// C.g:179:4: struct_declarator ( ',' struct_declarator )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(179, 4);
			PushFollow(Follow._struct_declarator_in_struct_declarator_list538);
			struct_declarator53=struct_declarator();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declarator53.Tree, struct_declarator53, retval);
			DebugLocation(179, 22);
			// C.g:179:22: ( ',' struct_declarator )*
			try { DebugEnterSubRule(17);
			while (true)
			{
				int alt17=2;
				try { DebugEnterDecision(17, decisionCanBacktrack[17]);
				int LA17_0 = input.LA(1);

				if ((LA17_0==25))
				{
					alt17=1;
				}


				} finally { DebugExitDecision(17); }
				switch ( alt17 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:179:23: ',' struct_declarator
					{
					DebugLocation(179, 23);
					char_literal54=(IToken)Match(input,25,Follow._25_in_struct_declarator_list541); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal54_tree = (object)adaptor.Create(char_literal54, retval);
					adaptor.AddChild(root_0, char_literal54_tree);
					}
					DebugLocation(179, 27);
					PushFollow(Follow._struct_declarator_in_struct_declarator_list543);
					struct_declarator55=struct_declarator();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declarator55.Tree, struct_declarator55, retval);

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
			TraceOut("struct_declarator_list", 16);
			LeaveRule("struct_declarator_list", 16);
			Leave_struct_declarator_list();
			if (state.backtracking > 0) { Memoize(input, 16, struct_declarator_list_StartIndex); }
		}
		DebugLocation(180, 1);
		} finally { DebugExitRule(GrammarFileName, "struct_declarator_list"); }
		return retval;

	}
	// $ANTLR end "struct_declarator_list"

	public class struct_declarator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_struct_declarator();
	partial void Leave_struct_declarator();

	// $ANTLR start "struct_declarator"
	// C.g:182:1: struct_declarator : ( declarator ( ':' constant_expression )? | ':' constant_expression );
	[GrammarRule("struct_declarator")]
	public CParser.struct_declarator_return struct_declarator()
	{
		Enter_struct_declarator();
		EnterRule("struct_declarator", 17);
		TraceIn("struct_declarator", 17);
		CParser.struct_declarator_return retval = new CParser.struct_declarator_return();
		retval.Start = (IToken)input.LT(1);
		int struct_declarator_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal57=null;
		IToken char_literal59=null;
		CParser.declarator_return declarator56 = default(CParser.declarator_return);
		CParser.constant_expression_return constant_expression58 = default(CParser.constant_expression_return);
		CParser.constant_expression_return constant_expression60 = default(CParser.constant_expression_return);

		object char_literal57_tree=null;
		object char_literal59_tree=null;

		try { DebugEnterRule(GrammarFileName, "struct_declarator");
		DebugLocation(182, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 17)) { return retval; }
			// C.g:183:2: ( declarator ( ':' constant_expression )? | ':' constant_expression )
			int alt19=2;
			try { DebugEnterDecision(19, decisionCanBacktrack[19]);
			int LA19_0 = input.LA(1);

			if ((LA19_0==IDENTIFIER||LA19_0==48||LA19_0==52))
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
				// C.g:183:4: declarator ( ':' constant_expression )?
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(183, 4);
				PushFollow(Follow._declarator_in_struct_declarator556);
				declarator56=declarator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator56.Tree, declarator56, retval);
				DebugLocation(183, 15);
				// C.g:183:15: ( ':' constant_expression )?
				int alt18=2;
				try { DebugEnterSubRule(18);
				try { DebugEnterDecision(18, decisionCanBacktrack[18]);
				int LA18_0 = input.LA(1);

				if ((LA18_0==44))
				{
					alt18=1;
				}
				} finally { DebugExitDecision(18); }
				switch (alt18)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:183:16: ':' constant_expression
					{
					DebugLocation(183, 16);
					char_literal57=(IToken)Match(input,44,Follow._44_in_struct_declarator559); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal57_tree = (object)adaptor.Create(char_literal57, retval);
					adaptor.AddChild(root_0, char_literal57_tree);
					}
					DebugLocation(183, 20);
					PushFollow(Follow._constant_expression_in_struct_declarator561);
					constant_expression58=constant_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression58.Tree, constant_expression58, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(18); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:184:4: ':' constant_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(184, 4);
				char_literal59=(IToken)Match(input,44,Follow._44_in_struct_declarator568); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal59_tree = (object)adaptor.Create(char_literal59, retval);
				adaptor.AddChild(root_0, char_literal59_tree);
				}
				DebugLocation(184, 8);
				PushFollow(Follow._constant_expression_in_struct_declarator570);
				constant_expression60=constant_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression60.Tree, constant_expression60, retval);

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
			TraceOut("struct_declarator", 17);
			LeaveRule("struct_declarator", 17);
			Leave_struct_declarator();
			if (state.backtracking > 0) { Memoize(input, 17, struct_declarator_StartIndex); }
		}
		DebugLocation(185, 1);
		} finally { DebugExitRule(GrammarFileName, "struct_declarator"); }
		return retval;

	}
	// $ANTLR end "struct_declarator"

	public class enum_specifier_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_enum_specifier();
	partial void Leave_enum_specifier();

	// $ANTLR start "enum_specifier"
	// C.g:187:1: enum_specifier options {k=3; } : ( 'enum' '{' enumerator_list '}' | 'enum' IDENTIFIER '{' enumerator_list '}' | 'enum' IDENTIFIER );
	[GrammarRule("enum_specifier")]
	public CParser.enum_specifier_return enum_specifier()
	{
		Enter_enum_specifier();
		EnterRule("enum_specifier", 18);
		TraceIn("enum_specifier", 18);
		CParser.enum_specifier_return retval = new CParser.enum_specifier_return();
		retval.Start = (IToken)input.LT(1);
		int enum_specifier_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal61=null;
		IToken char_literal62=null;
		IToken char_literal64=null;
		IToken string_literal65=null;
		IToken IDENTIFIER66=null;
		IToken char_literal67=null;
		IToken char_literal69=null;
		IToken string_literal70=null;
		IToken IDENTIFIER71=null;
		CParser.enumerator_list_return enumerator_list63 = default(CParser.enumerator_list_return);
		CParser.enumerator_list_return enumerator_list68 = default(CParser.enumerator_list_return);

		object string_literal61_tree=null;
		object char_literal62_tree=null;
		object char_literal64_tree=null;
		object string_literal65_tree=null;
		object IDENTIFIER66_tree=null;
		object char_literal67_tree=null;
		object char_literal69_tree=null;
		object string_literal70_tree=null;
		object IDENTIFIER71_tree=null;

		try { DebugEnterRule(GrammarFileName, "enum_specifier");
		DebugLocation(187, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 18)) { return retval; }
			// C.g:189:2: ( 'enum' '{' enumerator_list '}' | 'enum' IDENTIFIER '{' enumerator_list '}' | 'enum' IDENTIFIER )
			int alt20=3;
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
			switch (alt20)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:189:4: 'enum' '{' enumerator_list '}'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(189, 4);
				string_literal61=(IToken)Match(input,45,Follow._45_in_enum_specifier588); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal61_tree = (object)adaptor.Create(string_literal61, retval);
				adaptor.AddChild(root_0, string_literal61_tree);
				}
				DebugLocation(189, 11);
				char_literal62=(IToken)Match(input,40,Follow._40_in_enum_specifier590); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal62_tree = (object)adaptor.Create(char_literal62, retval);
				adaptor.AddChild(root_0, char_literal62_tree);
				}
				DebugLocation(189, 15);
				PushFollow(Follow._enumerator_list_in_enum_specifier592);
				enumerator_list63=enumerator_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator_list63.Tree, enumerator_list63, retval);
				DebugLocation(189, 31);
				char_literal64=(IToken)Match(input,41,Follow._41_in_enum_specifier594); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal64_tree = (object)adaptor.Create(char_literal64, retval);
				adaptor.AddChild(root_0, char_literal64_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:190:4: 'enum' IDENTIFIER '{' enumerator_list '}'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(190, 4);
				string_literal65=(IToken)Match(input,45,Follow._45_in_enum_specifier599); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal65_tree = (object)adaptor.Create(string_literal65, retval);
				adaptor.AddChild(root_0, string_literal65_tree);
				}
				DebugLocation(190, 11);
				IDENTIFIER66=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_enum_specifier601), "IDENTIFIER"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENTIFIER66_tree = (object)adaptor.Create(IDENTIFIER66, retval);
				adaptor.AddChild(root_0, IDENTIFIER66_tree);
				}
				DebugLocation(190, 22);
				char_literal67=(IToken)Match(input,40,Follow._40_in_enum_specifier603); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal67_tree = (object)adaptor.Create(char_literal67, retval);
				adaptor.AddChild(root_0, char_literal67_tree);
				}
				DebugLocation(190, 26);
				PushFollow(Follow._enumerator_list_in_enum_specifier605);
				enumerator_list68=enumerator_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator_list68.Tree, enumerator_list68, retval);
				DebugLocation(190, 42);
				char_literal69=(IToken)Match(input,41,Follow._41_in_enum_specifier607); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal69_tree = (object)adaptor.Create(char_literal69, retval);
				adaptor.AddChild(root_0, char_literal69_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:191:4: 'enum' IDENTIFIER
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(191, 4);
				string_literal70=(IToken)Match(input,45,Follow._45_in_enum_specifier612); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal70_tree = (object)adaptor.Create(string_literal70, retval);
				adaptor.AddChild(root_0, string_literal70_tree);
				}
				DebugLocation(191, 11);
				IDENTIFIER71=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_enum_specifier614), "IDENTIFIER"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENTIFIER71_tree = (object)adaptor.Create(IDENTIFIER71, retval);
				adaptor.AddChild(root_0, IDENTIFIER71_tree);
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
			TraceOut("enum_specifier", 18);
			LeaveRule("enum_specifier", 18);
			Leave_enum_specifier();
			if (state.backtracking > 0) { Memoize(input, 18, enum_specifier_StartIndex); }
		}
		DebugLocation(192, 1);
		} finally { DebugExitRule(GrammarFileName, "enum_specifier"); }
		return retval;

	}
	// $ANTLR end "enum_specifier"

	public class enumerator_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_enumerator_list();
	partial void Leave_enumerator_list();

	// $ANTLR start "enumerator_list"
	// C.g:194:1: enumerator_list : enumerator ( ',' enumerator )* ;
	[GrammarRule("enumerator_list")]
	public CParser.enumerator_list_return enumerator_list()
	{
		Enter_enumerator_list();
		EnterRule("enumerator_list", 19);
		TraceIn("enumerator_list", 19);
		CParser.enumerator_list_return retval = new CParser.enumerator_list_return();
		retval.Start = (IToken)input.LT(1);
		int enumerator_list_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal73=null;
		CParser.enumerator_return enumerator72 = default(CParser.enumerator_return);
		CParser.enumerator_return enumerator74 = default(CParser.enumerator_return);

		object char_literal73_tree=null;

		try { DebugEnterRule(GrammarFileName, "enumerator_list");
		DebugLocation(194, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 19)) { return retval; }
			// C.g:195:2: ( enumerator ( ',' enumerator )* )
			DebugEnterAlt(1);
			// C.g:195:4: enumerator ( ',' enumerator )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(195, 4);
			PushFollow(Follow._enumerator_in_enumerator_list625);
			enumerator72=enumerator();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator72.Tree, enumerator72, retval);
			DebugLocation(195, 15);
			// C.g:195:15: ( ',' enumerator )*
			try { DebugEnterSubRule(21);
			while (true)
			{
				int alt21=2;
				try { DebugEnterDecision(21, decisionCanBacktrack[21]);
				int LA21_0 = input.LA(1);

				if ((LA21_0==25))
				{
					alt21=1;
				}


				} finally { DebugExitDecision(21); }
				switch ( alt21 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:195:16: ',' enumerator
					{
					DebugLocation(195, 16);
					char_literal73=(IToken)Match(input,25,Follow._25_in_enumerator_list628); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal73_tree = (object)adaptor.Create(char_literal73, retval);
					adaptor.AddChild(root_0, char_literal73_tree);
					}
					DebugLocation(195, 20);
					PushFollow(Follow._enumerator_in_enumerator_list630);
					enumerator74=enumerator();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator74.Tree, enumerator74, retval);

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
			TraceOut("enumerator_list", 19);
			LeaveRule("enumerator_list", 19);
			Leave_enumerator_list();
			if (state.backtracking > 0) { Memoize(input, 19, enumerator_list_StartIndex); }
		}
		DebugLocation(196, 1);
		} finally { DebugExitRule(GrammarFileName, "enumerator_list"); }
		return retval;

	}
	// $ANTLR end "enumerator_list"

	public class enumerator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_enumerator();
	partial void Leave_enumerator();

	// $ANTLR start "enumerator"
	// C.g:198:1: enumerator : IDENTIFIER ( '=' constant_expression )? ;
	[GrammarRule("enumerator")]
	public CParser.enumerator_return enumerator()
	{
		Enter_enumerator();
		EnterRule("enumerator", 20);
		TraceIn("enumerator", 20);
		CParser.enumerator_return retval = new CParser.enumerator_return();
		retval.Start = (IToken)input.LT(1);
		int enumerator_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENTIFIER75=null;
		IToken char_literal76=null;
		CParser.constant_expression_return constant_expression77 = default(CParser.constant_expression_return);

		object IDENTIFIER75_tree=null;
		object char_literal76_tree=null;

		try { DebugEnterRule(GrammarFileName, "enumerator");
		DebugLocation(198, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 20)) { return retval; }
			// C.g:199:2: ( IDENTIFIER ( '=' constant_expression )? )
			DebugEnterAlt(1);
			// C.g:199:4: IDENTIFIER ( '=' constant_expression )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(199, 4);
			IDENTIFIER75=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_enumerator643), "IDENTIFIER"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			IDENTIFIER75_tree = (object)adaptor.Create(IDENTIFIER75, retval);
			adaptor.AddChild(root_0, IDENTIFIER75_tree);
			}
			DebugLocation(199, 15);
			// C.g:199:15: ( '=' constant_expression )?
			int alt22=2;
			try { DebugEnterSubRule(22);
			try { DebugEnterDecision(22, decisionCanBacktrack[22]);
			int LA22_0 = input.LA(1);

			if ((LA22_0==26))
			{
				alt22=1;
			}
			} finally { DebugExitDecision(22); }
			switch (alt22)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:199:16: '=' constant_expression
				{
				DebugLocation(199, 16);
				char_literal76=(IToken)Match(input,26,Follow._26_in_enumerator646); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal76_tree = (object)adaptor.Create(char_literal76, retval);
				adaptor.AddChild(root_0, char_literal76_tree);
				}
				DebugLocation(199, 20);
				PushFollow(Follow._constant_expression_in_enumerator648);
				constant_expression77=constant_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression77.Tree, constant_expression77, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(22); }


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
			TraceOut("enumerator", 20);
			LeaveRule("enumerator", 20);
			Leave_enumerator();
			if (state.backtracking > 0) { Memoize(input, 20, enumerator_StartIndex); }
		}
		DebugLocation(200, 1);
		} finally { DebugExitRule(GrammarFileName, "enumerator"); }
		return retval;

	}
	// $ANTLR end "enumerator"

	public class type_qualifier_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_type_qualifier();
	partial void Leave_type_qualifier();

	// $ANTLR start "type_qualifier"
	// C.g:202:1: type_qualifier : ( 'const' | 'volatile' );
	[GrammarRule("type_qualifier")]
	public CParser.type_qualifier_return type_qualifier()
	{
		Enter_type_qualifier();
		EnterRule("type_qualifier", 21);
		TraceIn("type_qualifier", 21);
		CParser.type_qualifier_return retval = new CParser.type_qualifier_return();
		retval.Start = (IToken)input.LT(1);
		int type_qualifier_StartIndex = input.Index;
		object root_0 = null;

		IToken set78=null;

		object set78_tree=null;

		try { DebugEnterRule(GrammarFileName, "type_qualifier");
		DebugLocation(202, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 21)) { return retval; }
			// C.g:203:2: ( 'const' | 'volatile' )
			DebugEnterAlt(1);
			// C.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(203, 2);
			set78=(IToken)input.LT(1);
			if ((input.LA(1)>=46 && input.LA(1)<=47))
			{
				input.Consume();
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set78, retval));
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
			TraceOut("type_qualifier", 21);
			LeaveRule("type_qualifier", 21);
			Leave_type_qualifier();
			if (state.backtracking > 0) { Memoize(input, 21, type_qualifier_StartIndex); }
		}
		DebugLocation(205, 1);
		} finally { DebugExitRule(GrammarFileName, "type_qualifier"); }
		return retval;

	}
	// $ANTLR end "type_qualifier"

	public class declarator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_declarator();
	partial void Leave_declarator();

	// $ANTLR start "declarator"
	// C.g:207:1: declarator : ( ( pointer )? direct_declarator | pointer );
	[GrammarRule("declarator")]
	public CParser.declarator_return declarator()
	{
		Enter_declarator();
		EnterRule("declarator", 22);
		TraceIn("declarator", 22);
		CParser.declarator_return retval = new CParser.declarator_return();
		retval.Start = (IToken)input.LT(1);
		int declarator_StartIndex = input.Index;
		object root_0 = null;

		CParser.pointer_return pointer79 = default(CParser.pointer_return);
		CParser.direct_declarator_return direct_declarator80 = default(CParser.direct_declarator_return);
		CParser.pointer_return pointer81 = default(CParser.pointer_return);


		try { DebugEnterRule(GrammarFileName, "declarator");
		DebugLocation(207, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 22)) { return retval; }
			// C.g:208:2: ( ( pointer )? direct_declarator | pointer )
			int alt24=2;
			try { DebugEnterDecision(24, decisionCanBacktrack[24]);
			try
			{
				alt24 = dfa24.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(24); }
			switch (alt24)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:208:4: ( pointer )? direct_declarator
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(208, 4);
				// C.g:208:4: ( pointer )?
				int alt23=2;
				try { DebugEnterSubRule(23);
				try { DebugEnterDecision(23, decisionCanBacktrack[23]);
				int LA23_0 = input.LA(1);

				if ((LA23_0==52))
				{
					alt23=1;
				}
				} finally { DebugExitDecision(23); }
				switch (alt23)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: pointer
					{
					DebugLocation(208, 4);
					PushFollow(Follow._pointer_in_declarator677);
					pointer79=pointer();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer79.Tree, pointer79, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(23); }

				DebugLocation(208, 13);
				PushFollow(Follow._direct_declarator_in_declarator680);
				direct_declarator80=direct_declarator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, direct_declarator80.Tree, direct_declarator80, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:209:4: pointer
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(209, 4);
				PushFollow(Follow._pointer_in_declarator685);
				pointer81=pointer();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer81.Tree, pointer81, retval);

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
			TraceOut("declarator", 22);
			LeaveRule("declarator", 22);
			Leave_declarator();
			if (state.backtracking > 0) { Memoize(input, 22, declarator_StartIndex); }
		}
		DebugLocation(210, 1);
		} finally { DebugExitRule(GrammarFileName, "declarator"); }
		return retval;

	}
	// $ANTLR end "declarator"

	public class direct_declarator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_direct_declarator();
	partial void Leave_direct_declarator();

	// $ANTLR start "direct_declarator"
	// C.g:212:1: direct_declarator : ( IDENTIFIER | '(' declarator ')' ) ( declarator_suffix )* ;
	[GrammarRule("direct_declarator")]
	public CParser.direct_declarator_return direct_declarator()
	{
		Enter_direct_declarator();
		EnterRule("direct_declarator", 23);
		TraceIn("direct_declarator", 23);
		CParser.direct_declarator_return retval = new CParser.direct_declarator_return();
		retval.Start = (IToken)input.LT(1);
		int direct_declarator_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENTIFIER82=null;
		IToken char_literal83=null;
		IToken char_literal85=null;
		CParser.declarator_return declarator84 = default(CParser.declarator_return);
		CParser.declarator_suffix_return declarator_suffix86 = default(CParser.declarator_suffix_return);

		object IDENTIFIER82_tree=null;
		object char_literal83_tree=null;
		object char_literal85_tree=null;

		try { DebugEnterRule(GrammarFileName, "direct_declarator");
		DebugLocation(212, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 23)) { return retval; }
			// C.g:213:2: ( ( IDENTIFIER | '(' declarator ')' ) ( declarator_suffix )* )
			DebugEnterAlt(1);
			// C.g:213:6: ( IDENTIFIER | '(' declarator ')' ) ( declarator_suffix )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(213, 6);
			// C.g:213:6: ( IDENTIFIER | '(' declarator ')' )
			int alt25=2;
			try { DebugEnterSubRule(25);
			try { DebugEnterDecision(25, decisionCanBacktrack[25]);
			int LA25_0 = input.LA(1);

			if ((LA25_0==IDENTIFIER))
			{
				alt25=1;
			}
			else if ((LA25_0==48))
			{
				alt25=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 25, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(25); }
			switch (alt25)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:213:8: IDENTIFIER
				{
				DebugLocation(213, 8);
				IDENTIFIER82=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_direct_declarator700), "IDENTIFIER"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENTIFIER82_tree = (object)adaptor.Create(IDENTIFIER82, retval);
				adaptor.AddChild(root_0, IDENTIFIER82_tree);
				}
				DebugLocation(214, 4);
				if ( state.backtracking == 0 )
				{

								if (declaration_stack.size()>0&&((declaration_scope)declaration_stack.Peek()).isTypedef) {
									((Symbols_scope)Symbols_stack.Peek()).types.add((IDENTIFIER82!=null?IDENTIFIER82.Text:null));
									
								}
								
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:220:5: '(' declarator ')'
				{
				DebugLocation(220, 5);
				char_literal83=(IToken)Match(input,48,Follow._48_in_direct_declarator711); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal83_tree = (object)adaptor.Create(char_literal83, retval);
				adaptor.AddChild(root_0, char_literal83_tree);
				}
				DebugLocation(220, 9);
				PushFollow(Follow._declarator_in_direct_declarator713);
				declarator84=declarator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator84.Tree, declarator84, retval);
				DebugLocation(220, 20);
				char_literal85=(IToken)Match(input,49,Follow._49_in_direct_declarator715); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal85_tree = (object)adaptor.Create(char_literal85, retval);
				adaptor.AddChild(root_0, char_literal85_tree);
				}

				}
				break;

			}
			} finally { DebugExitSubRule(25); }

			DebugLocation(222, 9);
			// C.g:222:9: ( declarator_suffix )*
			try { DebugEnterSubRule(26);
			while (true)
			{
				int alt26=2;
				try { DebugEnterDecision(26, decisionCanBacktrack[26]);
				try
				{
					alt26 = dfa26.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(26); }
				switch ( alt26 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: declarator_suffix
					{
					DebugLocation(222, 9);
					PushFollow(Follow._declarator_suffix_in_direct_declarator729);
					declarator_suffix86=declarator_suffix();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator_suffix86.Tree, declarator_suffix86, retval);

					}
					break;

				default:
					goto loop26;
				}
			}

			loop26:
				;

			} finally { DebugExitSubRule(26); }


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
			TraceOut("direct_declarator", 23);
			LeaveRule("direct_declarator", 23);
			Leave_direct_declarator();
			if (state.backtracking > 0) { Memoize(input, 23, direct_declarator_StartIndex); }
		}
		DebugLocation(223, 1);
		} finally { DebugExitRule(GrammarFileName, "direct_declarator"); }
		return retval;

	}
	// $ANTLR end "direct_declarator"

	public class declarator_suffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_declarator_suffix();
	partial void Leave_declarator_suffix();

	// $ANTLR start "declarator_suffix"
	// C.g:225:1: declarator_suffix : ( '[' constant_expression ']' | '[' ']' | '(' parameter_type_list ')' | '(' identifier_list ')' | '(' ')' );
	[GrammarRule("declarator_suffix")]
	public CParser.declarator_suffix_return declarator_suffix()
	{
		Enter_declarator_suffix();
		EnterRule("declarator_suffix", 24);
		TraceIn("declarator_suffix", 24);
		CParser.declarator_suffix_return retval = new CParser.declarator_suffix_return();
		retval.Start = (IToken)input.LT(1);
		int declarator_suffix_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal87=null;
		IToken char_literal89=null;
		IToken char_literal90=null;
		IToken char_literal91=null;
		IToken char_literal92=null;
		IToken char_literal94=null;
		IToken char_literal95=null;
		IToken char_literal97=null;
		IToken char_literal98=null;
		IToken char_literal99=null;
		CParser.constant_expression_return constant_expression88 = default(CParser.constant_expression_return);
		CParser.parameter_type_list_return parameter_type_list93 = default(CParser.parameter_type_list_return);
		CParser.identifier_list_return identifier_list96 = default(CParser.identifier_list_return);

		object char_literal87_tree=null;
		object char_literal89_tree=null;
		object char_literal90_tree=null;
		object char_literal91_tree=null;
		object char_literal92_tree=null;
		object char_literal94_tree=null;
		object char_literal95_tree=null;
		object char_literal97_tree=null;
		object char_literal98_tree=null;
		object char_literal99_tree=null;

		try { DebugEnterRule(GrammarFileName, "declarator_suffix");
		DebugLocation(225, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 24)) { return retval; }
			// C.g:226:2: ( '[' constant_expression ']' | '[' ']' | '(' parameter_type_list ')' | '(' identifier_list ')' | '(' ')' )
			int alt27=5;
			try { DebugEnterDecision(27, decisionCanBacktrack[27]);
			try
			{
				alt27 = dfa27.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(27); }
			switch (alt27)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:226:6: '[' constant_expression ']'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(226, 6);
				char_literal87=(IToken)Match(input,50,Follow._50_in_declarator_suffix743); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal87_tree = (object)adaptor.Create(char_literal87, retval);
				adaptor.AddChild(root_0, char_literal87_tree);
				}
				DebugLocation(226, 10);
				PushFollow(Follow._constant_expression_in_declarator_suffix745);
				constant_expression88=constant_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression88.Tree, constant_expression88, retval);
				DebugLocation(226, 30);
				char_literal89=(IToken)Match(input,51,Follow._51_in_declarator_suffix747); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal89_tree = (object)adaptor.Create(char_literal89, retval);
				adaptor.AddChild(root_0, char_literal89_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:227:9: '[' ']'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(227, 9);
				char_literal90=(IToken)Match(input,50,Follow._50_in_declarator_suffix757); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal90_tree = (object)adaptor.Create(char_literal90, retval);
				adaptor.AddChild(root_0, char_literal90_tree);
				}
				DebugLocation(227, 13);
				char_literal91=(IToken)Match(input,51,Follow._51_in_declarator_suffix759); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal91_tree = (object)adaptor.Create(char_literal91, retval);
				adaptor.AddChild(root_0, char_literal91_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:228:9: '(' parameter_type_list ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(228, 9);
				char_literal92=(IToken)Match(input,48,Follow._48_in_declarator_suffix769); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal92_tree = (object)adaptor.Create(char_literal92, retval);
				adaptor.AddChild(root_0, char_literal92_tree);
				}
				DebugLocation(228, 13);
				PushFollow(Follow._parameter_type_list_in_declarator_suffix771);
				parameter_type_list93=parameter_type_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_type_list93.Tree, parameter_type_list93, retval);
				DebugLocation(228, 33);
				char_literal94=(IToken)Match(input,49,Follow._49_in_declarator_suffix773); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal94_tree = (object)adaptor.Create(char_literal94, retval);
				adaptor.AddChild(root_0, char_literal94_tree);
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:229:9: '(' identifier_list ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(229, 9);
				char_literal95=(IToken)Match(input,48,Follow._48_in_declarator_suffix783); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal95_tree = (object)adaptor.Create(char_literal95, retval);
				adaptor.AddChild(root_0, char_literal95_tree);
				}
				DebugLocation(229, 13);
				PushFollow(Follow._identifier_list_in_declarator_suffix785);
				identifier_list96=identifier_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, identifier_list96.Tree, identifier_list96, retval);
				DebugLocation(229, 29);
				char_literal97=(IToken)Match(input,49,Follow._49_in_declarator_suffix787); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal97_tree = (object)adaptor.Create(char_literal97, retval);
				adaptor.AddChild(root_0, char_literal97_tree);
				}

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C.g:230:9: '(' ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(230, 9);
				char_literal98=(IToken)Match(input,48,Follow._48_in_declarator_suffix797); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal98_tree = (object)adaptor.Create(char_literal98, retval);
				adaptor.AddChild(root_0, char_literal98_tree);
				}
				DebugLocation(230, 13);
				char_literal99=(IToken)Match(input,49,Follow._49_in_declarator_suffix799); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal99_tree = (object)adaptor.Create(char_literal99, retval);
				adaptor.AddChild(root_0, char_literal99_tree);
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
			TraceOut("declarator_suffix", 24);
			LeaveRule("declarator_suffix", 24);
			Leave_declarator_suffix();
			if (state.backtracking > 0) { Memoize(input, 24, declarator_suffix_StartIndex); }
		}
		DebugLocation(231, 1);
		} finally { DebugExitRule(GrammarFileName, "declarator_suffix"); }
		return retval;

	}
	// $ANTLR end "declarator_suffix"

	public class pointer_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_pointer();
	partial void Leave_pointer();

	// $ANTLR start "pointer"
	// C.g:233:1: pointer : ( '*' ( type_qualifier )+ ( pointer )? | '*' pointer | '*' );
	[GrammarRule("pointer")]
	public CParser.pointer_return pointer()
	{
		Enter_pointer();
		EnterRule("pointer", 25);
		TraceIn("pointer", 25);
		CParser.pointer_return retval = new CParser.pointer_return();
		retval.Start = (IToken)input.LT(1);
		int pointer_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal100=null;
		IToken char_literal103=null;
		IToken char_literal105=null;
		CParser.type_qualifier_return type_qualifier101 = default(CParser.type_qualifier_return);
		CParser.pointer_return pointer102 = default(CParser.pointer_return);
		CParser.pointer_return pointer104 = default(CParser.pointer_return);

		object char_literal100_tree=null;
		object char_literal103_tree=null;
		object char_literal105_tree=null;

		try { DebugEnterRule(GrammarFileName, "pointer");
		DebugLocation(233, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 25)) { return retval; }
			// C.g:234:2: ( '*' ( type_qualifier )+ ( pointer )? | '*' pointer | '*' )
			int alt30=3;
			try { DebugEnterDecision(30, decisionCanBacktrack[30]);
			try
			{
				alt30 = dfa30.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(30); }
			switch (alt30)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:234:4: '*' ( type_qualifier )+ ( pointer )?
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(234, 4);
				char_literal100=(IToken)Match(input,52,Follow._52_in_pointer810); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal100_tree = (object)adaptor.Create(char_literal100, retval);
				adaptor.AddChild(root_0, char_literal100_tree);
				}
				DebugLocation(234, 8);
				// C.g:234:8: ( type_qualifier )+
				int cnt28=0;
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
					switch (alt28)
					{
					case 1:
						DebugEnterAlt(1);
						// C.g:0:0: type_qualifier
						{
						DebugLocation(234, 8);
						PushFollow(Follow._type_qualifier_in_pointer812);
						type_qualifier101=type_qualifier();
						PopFollow();
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_qualifier101.Tree, type_qualifier101, retval);

						}
						break;

					default:
						if (cnt28 >= 1)
							goto loop28;

						if (state.backtracking>0) {state.failed=true; return retval;}
						EarlyExitException eee28 = new EarlyExitException( 28, input );
						DebugRecognitionException(eee28);
						throw eee28;
					}
					cnt28++;
				}
				loop28:
					;

				} finally { DebugExitSubRule(28); }

				DebugLocation(234, 24);
				// C.g:234:24: ( pointer )?
				int alt29=2;
				try { DebugEnterSubRule(29);
				try { DebugEnterDecision(29, decisionCanBacktrack[29]);
				try
				{
					alt29 = dfa29.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(29); }
				switch (alt29)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: pointer
					{
					DebugLocation(234, 24);
					PushFollow(Follow._pointer_in_pointer815);
					pointer102=pointer();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer102.Tree, pointer102, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(29); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:235:4: '*' pointer
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(235, 4);
				char_literal103=(IToken)Match(input,52,Follow._52_in_pointer821); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal103_tree = (object)adaptor.Create(char_literal103, retval);
				adaptor.AddChild(root_0, char_literal103_tree);
				}
				DebugLocation(235, 8);
				PushFollow(Follow._pointer_in_pointer823);
				pointer104=pointer();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer104.Tree, pointer104, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:236:4: '*'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(236, 4);
				char_literal105=(IToken)Match(input,52,Follow._52_in_pointer828); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal105_tree = (object)adaptor.Create(char_literal105, retval);
				adaptor.AddChild(root_0, char_literal105_tree);
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
			TraceOut("pointer", 25);
			LeaveRule("pointer", 25);
			Leave_pointer();
			if (state.backtracking > 0) { Memoize(input, 25, pointer_StartIndex); }
		}
		DebugLocation(237, 1);
		} finally { DebugExitRule(GrammarFileName, "pointer"); }
		return retval;

	}
	// $ANTLR end "pointer"

	public class parameter_type_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_parameter_type_list();
	partial void Leave_parameter_type_list();

	// $ANTLR start "parameter_type_list"
	// C.g:239:1: parameter_type_list : parameter_list ( ',' '...' )? ;
	[GrammarRule("parameter_type_list")]
	public CParser.parameter_type_list_return parameter_type_list()
	{
		Enter_parameter_type_list();
		EnterRule("parameter_type_list", 26);
		TraceIn("parameter_type_list", 26);
		CParser.parameter_type_list_return retval = new CParser.parameter_type_list_return();
		retval.Start = (IToken)input.LT(1);
		int parameter_type_list_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal107=null;
		IToken string_literal108=null;
		CParser.parameter_list_return parameter_list106 = default(CParser.parameter_list_return);

		object char_literal107_tree=null;
		object string_literal108_tree=null;

		try { DebugEnterRule(GrammarFileName, "parameter_type_list");
		DebugLocation(239, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 26)) { return retval; }
			// C.g:240:2: ( parameter_list ( ',' '...' )? )
			DebugEnterAlt(1);
			// C.g:240:4: parameter_list ( ',' '...' )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(240, 4);
			PushFollow(Follow._parameter_list_in_parameter_type_list839);
			parameter_list106=parameter_list();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_list106.Tree, parameter_list106, retval);
			DebugLocation(240, 19);
			// C.g:240:19: ( ',' '...' )?
			int alt31=2;
			try { DebugEnterSubRule(31);
			try { DebugEnterDecision(31, decisionCanBacktrack[31]);
			int LA31_0 = input.LA(1);

			if ((LA31_0==25))
			{
				alt31=1;
			}
			} finally { DebugExitDecision(31); }
			switch (alt31)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:240:20: ',' '...'
				{
				DebugLocation(240, 20);
				char_literal107=(IToken)Match(input,25,Follow._25_in_parameter_type_list842); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal107_tree = (object)adaptor.Create(char_literal107, retval);
				adaptor.AddChild(root_0, char_literal107_tree);
				}
				DebugLocation(240, 24);
				string_literal108=(IToken)Match(input,53,Follow._53_in_parameter_type_list844); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal108_tree = (object)adaptor.Create(string_literal108, retval);
				adaptor.AddChild(root_0, string_literal108_tree);
				}

				}
				break;

			}
			} finally { DebugExitSubRule(31); }


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
			TraceOut("parameter_type_list", 26);
			LeaveRule("parameter_type_list", 26);
			Leave_parameter_type_list();
			if (state.backtracking > 0) { Memoize(input, 26, parameter_type_list_StartIndex); }
		}
		DebugLocation(241, 1);
		} finally { DebugExitRule(GrammarFileName, "parameter_type_list"); }
		return retval;

	}
	// $ANTLR end "parameter_type_list"

	public class parameter_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_parameter_list();
	partial void Leave_parameter_list();

	// $ANTLR start "parameter_list"
	// C.g:243:1: parameter_list : parameter_declaration ( ',' parameter_declaration )* ;
	[GrammarRule("parameter_list")]
	public CParser.parameter_list_return parameter_list()
	{
		Enter_parameter_list();
		EnterRule("parameter_list", 27);
		TraceIn("parameter_list", 27);
		CParser.parameter_list_return retval = new CParser.parameter_list_return();
		retval.Start = (IToken)input.LT(1);
		int parameter_list_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal110=null;
		CParser.parameter_declaration_return parameter_declaration109 = default(CParser.parameter_declaration_return);
		CParser.parameter_declaration_return parameter_declaration111 = default(CParser.parameter_declaration_return);

		object char_literal110_tree=null;

		try { DebugEnterRule(GrammarFileName, "parameter_list");
		DebugLocation(243, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 27)) { return retval; }
			// C.g:244:2: ( parameter_declaration ( ',' parameter_declaration )* )
			DebugEnterAlt(1);
			// C.g:244:4: parameter_declaration ( ',' parameter_declaration )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(244, 4);
			PushFollow(Follow._parameter_declaration_in_parameter_list857);
			parameter_declaration109=parameter_declaration();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_declaration109.Tree, parameter_declaration109, retval);
			DebugLocation(244, 26);
			// C.g:244:26: ( ',' parameter_declaration )*
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
					// C.g:244:27: ',' parameter_declaration
					{
					DebugLocation(244, 27);
					char_literal110=(IToken)Match(input,25,Follow._25_in_parameter_list860); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal110_tree = (object)adaptor.Create(char_literal110, retval);
					adaptor.AddChild(root_0, char_literal110_tree);
					}
					DebugLocation(244, 31);
					PushFollow(Follow._parameter_declaration_in_parameter_list862);
					parameter_declaration111=parameter_declaration();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_declaration111.Tree, parameter_declaration111, retval);

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
			TraceOut("parameter_list", 27);
			LeaveRule("parameter_list", 27);
			Leave_parameter_list();
			if (state.backtracking > 0) { Memoize(input, 27, parameter_list_StartIndex); }
		}
		DebugLocation(245, 1);
		} finally { DebugExitRule(GrammarFileName, "parameter_list"); }
		return retval;

	}
	// $ANTLR end "parameter_list"

	public class parameter_declaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_parameter_declaration();
	partial void Leave_parameter_declaration();

	// $ANTLR start "parameter_declaration"
	// C.g:247:1: parameter_declaration : declaration_specifiers ( declarator | abstract_declarator )* ;
	[GrammarRule("parameter_declaration")]
	public CParser.parameter_declaration_return parameter_declaration()
	{
		Enter_parameter_declaration();
		EnterRule("parameter_declaration", 28);
		TraceIn("parameter_declaration", 28);
		CParser.parameter_declaration_return retval = new CParser.parameter_declaration_return();
		retval.Start = (IToken)input.LT(1);
		int parameter_declaration_StartIndex = input.Index;
		object root_0 = null;

		CParser.declaration_specifiers_return declaration_specifiers112 = default(CParser.declaration_specifiers_return);
		CParser.declarator_return declarator113 = default(CParser.declarator_return);
		CParser.abstract_declarator_return abstract_declarator114 = default(CParser.abstract_declarator_return);


		try { DebugEnterRule(GrammarFileName, "parameter_declaration");
		DebugLocation(247, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 28)) { return retval; }
			// C.g:248:2: ( declaration_specifiers ( declarator | abstract_declarator )* )
			DebugEnterAlt(1);
			// C.g:248:4: declaration_specifiers ( declarator | abstract_declarator )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(248, 4);
			PushFollow(Follow._declaration_specifiers_in_parameter_declaration875);
			declaration_specifiers112=declaration_specifiers();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers112.Tree, declaration_specifiers112, retval);
			DebugLocation(248, 27);
			// C.g:248:27: ( declarator | abstract_declarator )*
			try { DebugEnterSubRule(33);
			while (true)
			{
				int alt33=3;
				try { DebugEnterDecision(33, decisionCanBacktrack[33]);
				try
				{
					alt33 = dfa33.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(33); }
				switch ( alt33 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:248:28: declarator
					{
					DebugLocation(248, 28);
					PushFollow(Follow._declarator_in_parameter_declaration878);
					declarator113=declarator();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator113.Tree, declarator113, retval);

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C.g:248:39: abstract_declarator
					{
					DebugLocation(248, 39);
					PushFollow(Follow._abstract_declarator_in_parameter_declaration880);
					abstract_declarator114=abstract_declarator();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator114.Tree, abstract_declarator114, retval);

					}
					break;

				default:
					goto loop33;
				}
			}

			loop33:
				;

			} finally { DebugExitSubRule(33); }


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
			TraceOut("parameter_declaration", 28);
			LeaveRule("parameter_declaration", 28);
			Leave_parameter_declaration();
			if (state.backtracking > 0) { Memoize(input, 28, parameter_declaration_StartIndex); }
		}
		DebugLocation(249, 1);
		} finally { DebugExitRule(GrammarFileName, "parameter_declaration"); }
		return retval;

	}
	// $ANTLR end "parameter_declaration"

	public class identifier_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_identifier_list();
	partial void Leave_identifier_list();

	// $ANTLR start "identifier_list"
	// C.g:251:1: identifier_list : IDENTIFIER ( ',' IDENTIFIER )* ;
	[GrammarRule("identifier_list")]
	public CParser.identifier_list_return identifier_list()
	{
		Enter_identifier_list();
		EnterRule("identifier_list", 29);
		TraceIn("identifier_list", 29);
		CParser.identifier_list_return retval = new CParser.identifier_list_return();
		retval.Start = (IToken)input.LT(1);
		int identifier_list_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENTIFIER115=null;
		IToken char_literal116=null;
		IToken IDENTIFIER117=null;

		object IDENTIFIER115_tree=null;
		object char_literal116_tree=null;
		object IDENTIFIER117_tree=null;

		try { DebugEnterRule(GrammarFileName, "identifier_list");
		DebugLocation(251, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 29)) { return retval; }
			// C.g:252:2: ( IDENTIFIER ( ',' IDENTIFIER )* )
			DebugEnterAlt(1);
			// C.g:252:4: IDENTIFIER ( ',' IDENTIFIER )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(252, 4);
			IDENTIFIER115=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_identifier_list893), "IDENTIFIER"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			IDENTIFIER115_tree = (object)adaptor.Create(IDENTIFIER115, retval);
			adaptor.AddChild(root_0, IDENTIFIER115_tree);
			}
			DebugLocation(252, 15);
			// C.g:252:15: ( ',' IDENTIFIER )*
			try { DebugEnterSubRule(34);
			while (true)
			{
				int alt34=2;
				try { DebugEnterDecision(34, decisionCanBacktrack[34]);
				int LA34_0 = input.LA(1);

				if ((LA34_0==25))
				{
					alt34=1;
				}


				} finally { DebugExitDecision(34); }
				switch ( alt34 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:252:16: ',' IDENTIFIER
					{
					DebugLocation(252, 16);
					char_literal116=(IToken)Match(input,25,Follow._25_in_identifier_list896); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal116_tree = (object)adaptor.Create(char_literal116, retval);
					adaptor.AddChild(root_0, char_literal116_tree);
					}
					DebugLocation(252, 20);
					IDENTIFIER117=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_identifier_list898), "IDENTIFIER"); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					IDENTIFIER117_tree = (object)adaptor.Create(IDENTIFIER117, retval);
					adaptor.AddChild(root_0, IDENTIFIER117_tree);
					}

					}
					break;

				default:
					goto loop34;
				}
			}

			loop34:
				;

			} finally { DebugExitSubRule(34); }


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
			TraceOut("identifier_list", 29);
			LeaveRule("identifier_list", 29);
			Leave_identifier_list();
			if (state.backtracking > 0) { Memoize(input, 29, identifier_list_StartIndex); }
		}
		DebugLocation(253, 1);
		} finally { DebugExitRule(GrammarFileName, "identifier_list"); }
		return retval;

	}
	// $ANTLR end "identifier_list"

	public class type_name_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_type_name();
	partial void Leave_type_name();

	// $ANTLR start "type_name"
	// C.g:255:1: type_name : specifier_qualifier_list ( abstract_declarator )? ;
	[GrammarRule("type_name")]
	public CParser.type_name_return type_name()
	{
		Enter_type_name();
		EnterRule("type_name", 30);
		TraceIn("type_name", 30);
		CParser.type_name_return retval = new CParser.type_name_return();
		retval.Start = (IToken)input.LT(1);
		int type_name_StartIndex = input.Index;
		object root_0 = null;

		CParser.specifier_qualifier_list_return specifier_qualifier_list118 = default(CParser.specifier_qualifier_list_return);
		CParser.abstract_declarator_return abstract_declarator119 = default(CParser.abstract_declarator_return);


		try { DebugEnterRule(GrammarFileName, "type_name");
		DebugLocation(255, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 30)) { return retval; }
			// C.g:256:2: ( specifier_qualifier_list ( abstract_declarator )? )
			DebugEnterAlt(1);
			// C.g:256:4: specifier_qualifier_list ( abstract_declarator )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(256, 4);
			PushFollow(Follow._specifier_qualifier_list_in_type_name911);
			specifier_qualifier_list118=specifier_qualifier_list();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, specifier_qualifier_list118.Tree, specifier_qualifier_list118, retval);
			DebugLocation(256, 29);
			// C.g:256:29: ( abstract_declarator )?
			int alt35=2;
			try { DebugEnterSubRule(35);
			try { DebugEnterDecision(35, decisionCanBacktrack[35]);
			int LA35_0 = input.LA(1);

			if ((LA35_0==48||LA35_0==50||LA35_0==52))
			{
				alt35=1;
			}
			} finally { DebugExitDecision(35); }
			switch (alt35)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:0:0: abstract_declarator
				{
				DebugLocation(256, 29);
				PushFollow(Follow._abstract_declarator_in_type_name913);
				abstract_declarator119=abstract_declarator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator119.Tree, abstract_declarator119, retval);

				}
				break;

			}
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
			TraceOut("type_name", 30);
			LeaveRule("type_name", 30);
			Leave_type_name();
			if (state.backtracking > 0) { Memoize(input, 30, type_name_StartIndex); }
		}
		DebugLocation(257, 1);
		} finally { DebugExitRule(GrammarFileName, "type_name"); }
		return retval;

	}
	// $ANTLR end "type_name"

	public class abstract_declarator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_abstract_declarator();
	partial void Leave_abstract_declarator();

	// $ANTLR start "abstract_declarator"
	// C.g:259:1: abstract_declarator : ( pointer ( direct_abstract_declarator )? | direct_abstract_declarator );
	[GrammarRule("abstract_declarator")]
	public CParser.abstract_declarator_return abstract_declarator()
	{
		Enter_abstract_declarator();
		EnterRule("abstract_declarator", 31);
		TraceIn("abstract_declarator", 31);
		CParser.abstract_declarator_return retval = new CParser.abstract_declarator_return();
		retval.Start = (IToken)input.LT(1);
		int abstract_declarator_StartIndex = input.Index;
		object root_0 = null;

		CParser.pointer_return pointer120 = default(CParser.pointer_return);
		CParser.direct_abstract_declarator_return direct_abstract_declarator121 = default(CParser.direct_abstract_declarator_return);
		CParser.direct_abstract_declarator_return direct_abstract_declarator122 = default(CParser.direct_abstract_declarator_return);


		try { DebugEnterRule(GrammarFileName, "abstract_declarator");
		DebugLocation(259, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 31)) { return retval; }
			// C.g:260:2: ( pointer ( direct_abstract_declarator )? | direct_abstract_declarator )
			int alt37=2;
			try { DebugEnterDecision(37, decisionCanBacktrack[37]);
			int LA37_0 = input.LA(1);

			if ((LA37_0==52))
			{
				alt37=1;
			}
			else if ((LA37_0==48||LA37_0==50))
			{
				alt37=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 37, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(37); }
			switch (alt37)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:260:4: pointer ( direct_abstract_declarator )?
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(260, 4);
				PushFollow(Follow._pointer_in_abstract_declarator925);
				pointer120=pointer();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer120.Tree, pointer120, retval);
				DebugLocation(260, 12);
				// C.g:260:12: ( direct_abstract_declarator )?
				int alt36=2;
				try { DebugEnterSubRule(36);
				try { DebugEnterDecision(36, decisionCanBacktrack[36]);
				try
				{
					alt36 = dfa36.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(36); }
				switch (alt36)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: direct_abstract_declarator
					{
					DebugLocation(260, 12);
					PushFollow(Follow._direct_abstract_declarator_in_abstract_declarator927);
					direct_abstract_declarator121=direct_abstract_declarator();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, direct_abstract_declarator121.Tree, direct_abstract_declarator121, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(36); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:261:4: direct_abstract_declarator
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(261, 4);
				PushFollow(Follow._direct_abstract_declarator_in_abstract_declarator933);
				direct_abstract_declarator122=direct_abstract_declarator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, direct_abstract_declarator122.Tree, direct_abstract_declarator122, retval);

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
			TraceOut("abstract_declarator", 31);
			LeaveRule("abstract_declarator", 31);
			Leave_abstract_declarator();
			if (state.backtracking > 0) { Memoize(input, 31, abstract_declarator_StartIndex); }
		}
		DebugLocation(262, 1);
		} finally { DebugExitRule(GrammarFileName, "abstract_declarator"); }
		return retval;

	}
	// $ANTLR end "abstract_declarator"

	public class direct_abstract_declarator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_direct_abstract_declarator();
	partial void Leave_direct_abstract_declarator();

	// $ANTLR start "direct_abstract_declarator"
	// C.g:264:1: direct_abstract_declarator : ( '(' abstract_declarator ')' | abstract_declarator_suffix ) ( abstract_declarator_suffix )* ;
	[GrammarRule("direct_abstract_declarator")]
	public CParser.direct_abstract_declarator_return direct_abstract_declarator()
	{
		Enter_direct_abstract_declarator();
		EnterRule("direct_abstract_declarator", 32);
		TraceIn("direct_abstract_declarator", 32);
		CParser.direct_abstract_declarator_return retval = new CParser.direct_abstract_declarator_return();
		retval.Start = (IToken)input.LT(1);
		int direct_abstract_declarator_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal123=null;
		IToken char_literal125=null;
		CParser.abstract_declarator_return abstract_declarator124 = default(CParser.abstract_declarator_return);
		CParser.abstract_declarator_suffix_return abstract_declarator_suffix126 = default(CParser.abstract_declarator_suffix_return);
		CParser.abstract_declarator_suffix_return abstract_declarator_suffix127 = default(CParser.abstract_declarator_suffix_return);

		object char_literal123_tree=null;
		object char_literal125_tree=null;

		try { DebugEnterRule(GrammarFileName, "direct_abstract_declarator");
		DebugLocation(264, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 32)) { return retval; }
			// C.g:265:2: ( ( '(' abstract_declarator ')' | abstract_declarator_suffix ) ( abstract_declarator_suffix )* )
			DebugEnterAlt(1);
			// C.g:265:4: ( '(' abstract_declarator ')' | abstract_declarator_suffix ) ( abstract_declarator_suffix )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(265, 4);
			// C.g:265:4: ( '(' abstract_declarator ')' | abstract_declarator_suffix )
			int alt38=2;
			try { DebugEnterSubRule(38);
			try { DebugEnterDecision(38, decisionCanBacktrack[38]);
			try
			{
				alt38 = dfa38.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(38); }
			switch (alt38)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:265:6: '(' abstract_declarator ')'
				{
				DebugLocation(265, 6);
				char_literal123=(IToken)Match(input,48,Follow._48_in_direct_abstract_declarator946); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal123_tree = (object)adaptor.Create(char_literal123, retval);
				adaptor.AddChild(root_0, char_literal123_tree);
				}
				DebugLocation(265, 10);
				PushFollow(Follow._abstract_declarator_in_direct_abstract_declarator948);
				abstract_declarator124=abstract_declarator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator124.Tree, abstract_declarator124, retval);
				DebugLocation(265, 30);
				char_literal125=(IToken)Match(input,49,Follow._49_in_direct_abstract_declarator950); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal125_tree = (object)adaptor.Create(char_literal125, retval);
				adaptor.AddChild(root_0, char_literal125_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:265:36: abstract_declarator_suffix
				{
				DebugLocation(265, 36);
				PushFollow(Follow._abstract_declarator_suffix_in_direct_abstract_declarator954);
				abstract_declarator_suffix126=abstract_declarator_suffix();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator_suffix126.Tree, abstract_declarator_suffix126, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(38); }

			DebugLocation(265, 65);
			// C.g:265:65: ( abstract_declarator_suffix )*
			try { DebugEnterSubRule(39);
			while (true)
			{
				int alt39=2;
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
				switch ( alt39 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: abstract_declarator_suffix
					{
					DebugLocation(265, 65);
					PushFollow(Follow._abstract_declarator_suffix_in_direct_abstract_declarator958);
					abstract_declarator_suffix127=abstract_declarator_suffix();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator_suffix127.Tree, abstract_declarator_suffix127, retval);

					}
					break;

				default:
					goto loop39;
				}
			}

			loop39:
				;

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
			TraceOut("direct_abstract_declarator", 32);
			LeaveRule("direct_abstract_declarator", 32);
			Leave_direct_abstract_declarator();
			if (state.backtracking > 0) { Memoize(input, 32, direct_abstract_declarator_StartIndex); }
		}
		DebugLocation(266, 1);
		} finally { DebugExitRule(GrammarFileName, "direct_abstract_declarator"); }
		return retval;

	}
	// $ANTLR end "direct_abstract_declarator"

	public class abstract_declarator_suffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_abstract_declarator_suffix();
	partial void Leave_abstract_declarator_suffix();

	// $ANTLR start "abstract_declarator_suffix"
	// C.g:268:1: abstract_declarator_suffix : ( '[' ']' | '[' constant_expression ']' | '(' ')' | '(' parameter_type_list ')' );
	[GrammarRule("abstract_declarator_suffix")]
	public CParser.abstract_declarator_suffix_return abstract_declarator_suffix()
	{
		Enter_abstract_declarator_suffix();
		EnterRule("abstract_declarator_suffix", 33);
		TraceIn("abstract_declarator_suffix", 33);
		CParser.abstract_declarator_suffix_return retval = new CParser.abstract_declarator_suffix_return();
		retval.Start = (IToken)input.LT(1);
		int abstract_declarator_suffix_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal128=null;
		IToken char_literal129=null;
		IToken char_literal130=null;
		IToken char_literal132=null;
		IToken char_literal133=null;
		IToken char_literal134=null;
		IToken char_literal135=null;
		IToken char_literal137=null;
		CParser.constant_expression_return constant_expression131 = default(CParser.constant_expression_return);
		CParser.parameter_type_list_return parameter_type_list136 = default(CParser.parameter_type_list_return);

		object char_literal128_tree=null;
		object char_literal129_tree=null;
		object char_literal130_tree=null;
		object char_literal132_tree=null;
		object char_literal133_tree=null;
		object char_literal134_tree=null;
		object char_literal135_tree=null;
		object char_literal137_tree=null;

		try { DebugEnterRule(GrammarFileName, "abstract_declarator_suffix");
		DebugLocation(268, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 33)) { return retval; }
			// C.g:269:2: ( '[' ']' | '[' constant_expression ']' | '(' ')' | '(' parameter_type_list ')' )
			int alt40=4;
			try { DebugEnterDecision(40, decisionCanBacktrack[40]);
			try
			{
				alt40 = dfa40.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(40); }
			switch (alt40)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:269:4: '[' ']'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(269, 4);
				char_literal128=(IToken)Match(input,50,Follow._50_in_abstract_declarator_suffix970); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal128_tree = (object)adaptor.Create(char_literal128, retval);
				adaptor.AddChild(root_0, char_literal128_tree);
				}
				DebugLocation(269, 8);
				char_literal129=(IToken)Match(input,51,Follow._51_in_abstract_declarator_suffix972); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal129_tree = (object)adaptor.Create(char_literal129, retval);
				adaptor.AddChild(root_0, char_literal129_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:270:4: '[' constant_expression ']'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(270, 4);
				char_literal130=(IToken)Match(input,50,Follow._50_in_abstract_declarator_suffix977); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal130_tree = (object)adaptor.Create(char_literal130, retval);
				adaptor.AddChild(root_0, char_literal130_tree);
				}
				DebugLocation(270, 8);
				PushFollow(Follow._constant_expression_in_abstract_declarator_suffix979);
				constant_expression131=constant_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression131.Tree, constant_expression131, retval);
				DebugLocation(270, 28);
				char_literal132=(IToken)Match(input,51,Follow._51_in_abstract_declarator_suffix981); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal132_tree = (object)adaptor.Create(char_literal132, retval);
				adaptor.AddChild(root_0, char_literal132_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:271:4: '(' ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(271, 4);
				char_literal133=(IToken)Match(input,48,Follow._48_in_abstract_declarator_suffix986); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal133_tree = (object)adaptor.Create(char_literal133, retval);
				adaptor.AddChild(root_0, char_literal133_tree);
				}
				DebugLocation(271, 8);
				char_literal134=(IToken)Match(input,49,Follow._49_in_abstract_declarator_suffix988); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal134_tree = (object)adaptor.Create(char_literal134, retval);
				adaptor.AddChild(root_0, char_literal134_tree);
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:272:4: '(' parameter_type_list ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(272, 4);
				char_literal135=(IToken)Match(input,48,Follow._48_in_abstract_declarator_suffix993); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal135_tree = (object)adaptor.Create(char_literal135, retval);
				adaptor.AddChild(root_0, char_literal135_tree);
				}
				DebugLocation(272, 8);
				PushFollow(Follow._parameter_type_list_in_abstract_declarator_suffix995);
				parameter_type_list136=parameter_type_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_type_list136.Tree, parameter_type_list136, retval);
				DebugLocation(272, 28);
				char_literal137=(IToken)Match(input,49,Follow._49_in_abstract_declarator_suffix997); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal137_tree = (object)adaptor.Create(char_literal137, retval);
				adaptor.AddChild(root_0, char_literal137_tree);
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
			TraceOut("abstract_declarator_suffix", 33);
			LeaveRule("abstract_declarator_suffix", 33);
			Leave_abstract_declarator_suffix();
			if (state.backtracking > 0) { Memoize(input, 33, abstract_declarator_suffix_StartIndex); }
		}
		DebugLocation(273, 1);
		} finally { DebugExitRule(GrammarFileName, "abstract_declarator_suffix"); }
		return retval;

	}
	// $ANTLR end "abstract_declarator_suffix"

	public class initializer_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_initializer();
	partial void Leave_initializer();

	// $ANTLR start "initializer"
	// C.g:275:1: initializer : ( assignment_expression | '{' initializer_list ( ',' )? '}' );
	[GrammarRule("initializer")]
	public CParser.initializer_return initializer()
	{
		Enter_initializer();
		EnterRule("initializer", 34);
		TraceIn("initializer", 34);
		CParser.initializer_return retval = new CParser.initializer_return();
		retval.Start = (IToken)input.LT(1);
		int initializer_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal139=null;
		IToken char_literal141=null;
		IToken char_literal142=null;
		CParser.assignment_expression_return assignment_expression138 = default(CParser.assignment_expression_return);
		CParser.initializer_list_return initializer_list140 = default(CParser.initializer_list_return);

		object char_literal139_tree=null;
		object char_literal141_tree=null;
		object char_literal142_tree=null;

		try { DebugEnterRule(GrammarFileName, "initializer");
		DebugLocation(275, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 34)) { return retval; }
			// C.g:276:2: ( assignment_expression | '{' initializer_list ( ',' )? '}' )
			int alt42=2;
			try { DebugEnterDecision(42, decisionCanBacktrack[42]);
			try
			{
				alt42 = dfa42.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(42); }
			switch (alt42)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:276:4: assignment_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(276, 4);
				PushFollow(Follow._assignment_expression_in_initializer1009);
				assignment_expression138=assignment_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression138.Tree, assignment_expression138, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:277:4: '{' initializer_list ( ',' )? '}'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(277, 4);
				char_literal139=(IToken)Match(input,40,Follow._40_in_initializer1014); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal139_tree = (object)adaptor.Create(char_literal139, retval);
				adaptor.AddChild(root_0, char_literal139_tree);
				}
				DebugLocation(277, 8);
				PushFollow(Follow._initializer_list_in_initializer1016);
				initializer_list140=initializer_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer_list140.Tree, initializer_list140, retval);
				DebugLocation(277, 25);
				// C.g:277:25: ( ',' )?
				int alt41=2;
				try { DebugEnterSubRule(41);
				try { DebugEnterDecision(41, decisionCanBacktrack[41]);
				int LA41_0 = input.LA(1);

				if ((LA41_0==25))
				{
					alt41=1;
				}
				} finally { DebugExitDecision(41); }
				switch (alt41)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: ','
					{
					DebugLocation(277, 25);
					char_literal141=(IToken)Match(input,25,Follow._25_in_initializer1018); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal141_tree = (object)adaptor.Create(char_literal141, retval);
					adaptor.AddChild(root_0, char_literal141_tree);
					}

					}
					break;

				}
				} finally { DebugExitSubRule(41); }

				DebugLocation(277, 30);
				char_literal142=(IToken)Match(input,41,Follow._41_in_initializer1021); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal142_tree = (object)adaptor.Create(char_literal142, retval);
				adaptor.AddChild(root_0, char_literal142_tree);
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
			TraceOut("initializer", 34);
			LeaveRule("initializer", 34);
			Leave_initializer();
			if (state.backtracking > 0) { Memoize(input, 34, initializer_StartIndex); }
		}
		DebugLocation(278, 1);
		} finally { DebugExitRule(GrammarFileName, "initializer"); }
		return retval;

	}
	// $ANTLR end "initializer"

	public class initializer_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_initializer_list();
	partial void Leave_initializer_list();

	// $ANTLR start "initializer_list"
	// C.g:280:1: initializer_list : initializer ( ',' initializer )* ;
	[GrammarRule("initializer_list")]
	public CParser.initializer_list_return initializer_list()
	{
		Enter_initializer_list();
		EnterRule("initializer_list", 35);
		TraceIn("initializer_list", 35);
		CParser.initializer_list_return retval = new CParser.initializer_list_return();
		retval.Start = (IToken)input.LT(1);
		int initializer_list_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal144=null;
		CParser.initializer_return initializer143 = default(CParser.initializer_return);
		CParser.initializer_return initializer145 = default(CParser.initializer_return);

		object char_literal144_tree=null;

		try { DebugEnterRule(GrammarFileName, "initializer_list");
		DebugLocation(280, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 35)) { return retval; }
			// C.g:281:2: ( initializer ( ',' initializer )* )
			DebugEnterAlt(1);
			// C.g:281:4: initializer ( ',' initializer )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(281, 4);
			PushFollow(Follow._initializer_in_initializer_list1032);
			initializer143=initializer();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer143.Tree, initializer143, retval);
			DebugLocation(281, 16);
			// C.g:281:16: ( ',' initializer )*
			try { DebugEnterSubRule(43);
			while (true)
			{
				int alt43=2;
				try { DebugEnterDecision(43, decisionCanBacktrack[43]);
				try
				{
					alt43 = dfa43.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(43); }
				switch ( alt43 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:281:17: ',' initializer
					{
					DebugLocation(281, 17);
					char_literal144=(IToken)Match(input,25,Follow._25_in_initializer_list1035); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal144_tree = (object)adaptor.Create(char_literal144, retval);
					adaptor.AddChild(root_0, char_literal144_tree);
					}
					DebugLocation(281, 21);
					PushFollow(Follow._initializer_in_initializer_list1037);
					initializer145=initializer();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer145.Tree, initializer145, retval);

					}
					break;

				default:
					goto loop43;
				}
			}

			loop43:
				;

			} finally { DebugExitSubRule(43); }


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
			TraceOut("initializer_list", 35);
			LeaveRule("initializer_list", 35);
			Leave_initializer_list();
			if (state.backtracking > 0) { Memoize(input, 35, initializer_list_StartIndex); }
		}
		DebugLocation(282, 1);
		} finally { DebugExitRule(GrammarFileName, "initializer_list"); }
		return retval;

	}
	// $ANTLR end "initializer_list"

	public class argument_expression_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_argument_expression_list();
	partial void Leave_argument_expression_list();

	// $ANTLR start "argument_expression_list"
	// C.g:286:1: argument_expression_list : assignment_expression ( ',' assignment_expression )* ;
	[GrammarRule("argument_expression_list")]
	public CParser.argument_expression_list_return argument_expression_list()
	{
		Enter_argument_expression_list();
		EnterRule("argument_expression_list", 36);
		TraceIn("argument_expression_list", 36);
		CParser.argument_expression_list_return retval = new CParser.argument_expression_list_return();
		retval.Start = (IToken)input.LT(1);
		int argument_expression_list_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal147=null;
		CParser.assignment_expression_return assignment_expression146 = default(CParser.assignment_expression_return);
		CParser.assignment_expression_return assignment_expression148 = default(CParser.assignment_expression_return);

		object char_literal147_tree=null;

		try { DebugEnterRule(GrammarFileName, "argument_expression_list");
		DebugLocation(286, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 36)) { return retval; }
			// C.g:287:2: ( assignment_expression ( ',' assignment_expression )* )
			DebugEnterAlt(1);
			// C.g:287:6: assignment_expression ( ',' assignment_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(287, 6);
			PushFollow(Follow._assignment_expression_in_argument_expression_list1054);
			assignment_expression146=assignment_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression146.Tree, assignment_expression146, retval);
			DebugLocation(287, 28);
			// C.g:287:28: ( ',' assignment_expression )*
			try { DebugEnterSubRule(44);
			while (true)
			{
				int alt44=2;
				try { DebugEnterDecision(44, decisionCanBacktrack[44]);
				int LA44_0 = input.LA(1);

				if ((LA44_0==25))
				{
					alt44=1;
				}


				} finally { DebugExitDecision(44); }
				switch ( alt44 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:287:29: ',' assignment_expression
					{
					DebugLocation(287, 29);
					char_literal147=(IToken)Match(input,25,Follow._25_in_argument_expression_list1057); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal147_tree = (object)adaptor.Create(char_literal147, retval);
					adaptor.AddChild(root_0, char_literal147_tree);
					}
					DebugLocation(287, 33);
					PushFollow(Follow._assignment_expression_in_argument_expression_list1059);
					assignment_expression148=assignment_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression148.Tree, assignment_expression148, retval);

					}
					break;

				default:
					goto loop44;
				}
			}

			loop44:
				;

			} finally { DebugExitSubRule(44); }


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
			TraceOut("argument_expression_list", 36);
			LeaveRule("argument_expression_list", 36);
			Leave_argument_expression_list();
			if (state.backtracking > 0) { Memoize(input, 36, argument_expression_list_StartIndex); }
		}
		DebugLocation(288, 1);
		} finally { DebugExitRule(GrammarFileName, "argument_expression_list"); }
		return retval;

	}
	// $ANTLR end "argument_expression_list"

	public class additive_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_additive_expression();
	partial void Leave_additive_expression();

	// $ANTLR start "additive_expression"
	// C.g:290:1: additive_expression : ( multiplicative_expression ) ( '+' multiplicative_expression | '-' multiplicative_expression )* ;
	[GrammarRule("additive_expression")]
	public CParser.additive_expression_return additive_expression()
	{
		Enter_additive_expression();
		EnterRule("additive_expression", 37);
		TraceIn("additive_expression", 37);
		CParser.additive_expression_return retval = new CParser.additive_expression_return();
		retval.Start = (IToken)input.LT(1);
		int additive_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal150=null;
		IToken char_literal152=null;
		CParser.multiplicative_expression_return multiplicative_expression149 = default(CParser.multiplicative_expression_return);
		CParser.multiplicative_expression_return multiplicative_expression151 = default(CParser.multiplicative_expression_return);
		CParser.multiplicative_expression_return multiplicative_expression153 = default(CParser.multiplicative_expression_return);

		object char_literal150_tree=null;
		object char_literal152_tree=null;

		try { DebugEnterRule(GrammarFileName, "additive_expression");
		DebugLocation(290, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 37)) { return retval; }
			// C.g:291:2: ( ( multiplicative_expression ) ( '+' multiplicative_expression | '-' multiplicative_expression )* )
			DebugEnterAlt(1);
			// C.g:291:4: ( multiplicative_expression ) ( '+' multiplicative_expression | '-' multiplicative_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(291, 4);
			// C.g:291:4: ( multiplicative_expression )
			DebugEnterAlt(1);
			// C.g:291:5: multiplicative_expression
			{
			DebugLocation(291, 5);
			PushFollow(Follow._multiplicative_expression_in_additive_expression1073);
			multiplicative_expression149=multiplicative_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicative_expression149.Tree, multiplicative_expression149, retval);

			}

			DebugLocation(291, 32);
			// C.g:291:32: ( '+' multiplicative_expression | '-' multiplicative_expression )*
			try { DebugEnterSubRule(45);
			while (true)
			{
				int alt45=3;
				try { DebugEnterDecision(45, decisionCanBacktrack[45]);
				try
				{
					alt45 = dfa45.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(45); }
				switch ( alt45 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:291:33: '+' multiplicative_expression
					{
					DebugLocation(291, 33);
					char_literal150=(IToken)Match(input,54,Follow._54_in_additive_expression1077); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal150_tree = (object)adaptor.Create(char_literal150, retval);
					adaptor.AddChild(root_0, char_literal150_tree);
					}
					DebugLocation(291, 37);
					PushFollow(Follow._multiplicative_expression_in_additive_expression1079);
					multiplicative_expression151=multiplicative_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicative_expression151.Tree, multiplicative_expression151, retval);

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C.g:291:65: '-' multiplicative_expression
					{
					DebugLocation(291, 65);
					char_literal152=(IToken)Match(input,55,Follow._55_in_additive_expression1083); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal152_tree = (object)adaptor.Create(char_literal152, retval);
					adaptor.AddChild(root_0, char_literal152_tree);
					}
					DebugLocation(291, 69);
					PushFollow(Follow._multiplicative_expression_in_additive_expression1085);
					multiplicative_expression153=multiplicative_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicative_expression153.Tree, multiplicative_expression153, retval);

					}
					break;

				default:
					goto loop45;
				}
			}

			loop45:
				;

			} finally { DebugExitSubRule(45); }


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
			TraceOut("additive_expression", 37);
			LeaveRule("additive_expression", 37);
			Leave_additive_expression();
			if (state.backtracking > 0) { Memoize(input, 37, additive_expression_StartIndex); }
		}
		DebugLocation(292, 1);
		} finally { DebugExitRule(GrammarFileName, "additive_expression"); }
		return retval;

	}
	// $ANTLR end "additive_expression"

	public class multiplicative_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_multiplicative_expression();
	partial void Leave_multiplicative_expression();

	// $ANTLR start "multiplicative_expression"
	// C.g:294:1: multiplicative_expression : ( cast_expression ) ( '*' cast_expression | '/' cast_expression | '%' cast_expression )* ;
	[GrammarRule("multiplicative_expression")]
	public CParser.multiplicative_expression_return multiplicative_expression()
	{
		Enter_multiplicative_expression();
		EnterRule("multiplicative_expression", 38);
		TraceIn("multiplicative_expression", 38);
		CParser.multiplicative_expression_return retval = new CParser.multiplicative_expression_return();
		retval.Start = (IToken)input.LT(1);
		int multiplicative_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal155=null;
		IToken char_literal157=null;
		IToken char_literal159=null;
		CParser.cast_expression_return cast_expression154 = default(CParser.cast_expression_return);
		CParser.cast_expression_return cast_expression156 = default(CParser.cast_expression_return);
		CParser.cast_expression_return cast_expression158 = default(CParser.cast_expression_return);
		CParser.cast_expression_return cast_expression160 = default(CParser.cast_expression_return);

		object char_literal155_tree=null;
		object char_literal157_tree=null;
		object char_literal159_tree=null;

		try { DebugEnterRule(GrammarFileName, "multiplicative_expression");
		DebugLocation(294, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 38)) { return retval; }
			// C.g:295:2: ( ( cast_expression ) ( '*' cast_expression | '/' cast_expression | '%' cast_expression )* )
			DebugEnterAlt(1);
			// C.g:295:4: ( cast_expression ) ( '*' cast_expression | '/' cast_expression | '%' cast_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(295, 4);
			// C.g:295:4: ( cast_expression )
			DebugEnterAlt(1);
			// C.g:295:5: cast_expression
			{
			DebugLocation(295, 5);
			PushFollow(Follow._cast_expression_in_multiplicative_expression1099);
			cast_expression154=cast_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression154.Tree, cast_expression154, retval);

			}

			DebugLocation(295, 22);
			// C.g:295:22: ( '*' cast_expression | '/' cast_expression | '%' cast_expression )*
			try { DebugEnterSubRule(46);
			while (true)
			{
				int alt46=4;
				try { DebugEnterDecision(46, decisionCanBacktrack[46]);
				try
				{
					alt46 = dfa46.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(46); }
				switch ( alt46 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:295:23: '*' cast_expression
					{
					DebugLocation(295, 23);
					char_literal155=(IToken)Match(input,52,Follow._52_in_multiplicative_expression1103); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal155_tree = (object)adaptor.Create(char_literal155, retval);
					adaptor.AddChild(root_0, char_literal155_tree);
					}
					DebugLocation(295, 27);
					PushFollow(Follow._cast_expression_in_multiplicative_expression1105);
					cast_expression156=cast_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression156.Tree, cast_expression156, retval);

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C.g:295:45: '/' cast_expression
					{
					DebugLocation(295, 45);
					char_literal157=(IToken)Match(input,56,Follow._56_in_multiplicative_expression1109); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal157_tree = (object)adaptor.Create(char_literal157, retval);
					adaptor.AddChild(root_0, char_literal157_tree);
					}
					DebugLocation(295, 49);
					PushFollow(Follow._cast_expression_in_multiplicative_expression1111);
					cast_expression158=cast_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression158.Tree, cast_expression158, retval);

					}
					break;
				case 3:
					DebugEnterAlt(3);
					// C.g:295:67: '%' cast_expression
					{
					DebugLocation(295, 67);
					char_literal159=(IToken)Match(input,57,Follow._57_in_multiplicative_expression1115); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal159_tree = (object)adaptor.Create(char_literal159, retval);
					adaptor.AddChild(root_0, char_literal159_tree);
					}
					DebugLocation(295, 71);
					PushFollow(Follow._cast_expression_in_multiplicative_expression1117);
					cast_expression160=cast_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression160.Tree, cast_expression160, retval);

					}
					break;

				default:
					goto loop46;
				}
			}

			loop46:
				;

			} finally { DebugExitSubRule(46); }


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
			TraceOut("multiplicative_expression", 38);
			LeaveRule("multiplicative_expression", 38);
			Leave_multiplicative_expression();
			if (state.backtracking > 0) { Memoize(input, 38, multiplicative_expression_StartIndex); }
		}
		DebugLocation(296, 1);
		} finally { DebugExitRule(GrammarFileName, "multiplicative_expression"); }
		return retval;

	}
	// $ANTLR end "multiplicative_expression"

	public class cast_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_cast_expression();
	partial void Leave_cast_expression();

	// $ANTLR start "cast_expression"
	// C.g:298:1: cast_expression : ( '(' type_name ')' cast_expression | unary_expression );
	[GrammarRule("cast_expression")]
	public CParser.cast_expression_return cast_expression()
	{
		Enter_cast_expression();
		EnterRule("cast_expression", 39);
		TraceIn("cast_expression", 39);
		CParser.cast_expression_return retval = new CParser.cast_expression_return();
		retval.Start = (IToken)input.LT(1);
		int cast_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal161=null;
		IToken char_literal163=null;
		CParser.type_name_return type_name162 = default(CParser.type_name_return);
		CParser.cast_expression_return cast_expression164 = default(CParser.cast_expression_return);
		CParser.unary_expression_return unary_expression165 = default(CParser.unary_expression_return);

		object char_literal161_tree=null;
		object char_literal163_tree=null;

		try { DebugEnterRule(GrammarFileName, "cast_expression");
		DebugLocation(298, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 39)) { return retval; }
			// C.g:299:2: ( '(' type_name ')' cast_expression | unary_expression )
			int alt47=2;
			try { DebugEnterDecision(47, decisionCanBacktrack[47]);
			try
			{
				alt47 = dfa47.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(47); }
			switch (alt47)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:299:4: '(' type_name ')' cast_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(299, 4);
				char_literal161=(IToken)Match(input,48,Follow._48_in_cast_expression1130); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal161_tree = (object)adaptor.Create(char_literal161, retval);
				adaptor.AddChild(root_0, char_literal161_tree);
				}
				DebugLocation(299, 8);
				PushFollow(Follow._type_name_in_cast_expression1132);
				type_name162=type_name();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_name162.Tree, type_name162, retval);
				DebugLocation(299, 18);
				char_literal163=(IToken)Match(input,49,Follow._49_in_cast_expression1134); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal163_tree = (object)adaptor.Create(char_literal163, retval);
				adaptor.AddChild(root_0, char_literal163_tree);
				}
				DebugLocation(299, 22);
				PushFollow(Follow._cast_expression_in_cast_expression1136);
				cast_expression164=cast_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression164.Tree, cast_expression164, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:300:4: unary_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(300, 4);
				PushFollow(Follow._unary_expression_in_cast_expression1141);
				unary_expression165=unary_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression165.Tree, unary_expression165, retval);

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
			TraceOut("cast_expression", 39);
			LeaveRule("cast_expression", 39);
			Leave_cast_expression();
			if (state.backtracking > 0) { Memoize(input, 39, cast_expression_StartIndex); }
		}
		DebugLocation(301, 1);
		} finally { DebugExitRule(GrammarFileName, "cast_expression"); }
		return retval;

	}
	// $ANTLR end "cast_expression"

	public class unary_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_unary_expression();
	partial void Leave_unary_expression();

	// $ANTLR start "unary_expression"
	// C.g:303:1: unary_expression : ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' unary_expression | 'sizeof' '(' type_name ')' );
	[GrammarRule("unary_expression")]
	public CParser.unary_expression_return unary_expression()
	{
		Enter_unary_expression();
		EnterRule("unary_expression", 40);
		TraceIn("unary_expression", 40);
		CParser.unary_expression_return retval = new CParser.unary_expression_return();
		retval.Start = (IToken)input.LT(1);
		int unary_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal167=null;
		IToken string_literal169=null;
		IToken string_literal173=null;
		IToken string_literal175=null;
		IToken char_literal176=null;
		IToken char_literal178=null;
		CParser.postfix_expression_return postfix_expression166 = default(CParser.postfix_expression_return);
		CParser.unary_expression_return unary_expression168 = default(CParser.unary_expression_return);
		CParser.unary_expression_return unary_expression170 = default(CParser.unary_expression_return);
		CParser.unary_operator_return unary_operator171 = default(CParser.unary_operator_return);
		CParser.cast_expression_return cast_expression172 = default(CParser.cast_expression_return);
		CParser.unary_expression_return unary_expression174 = default(CParser.unary_expression_return);
		CParser.type_name_return type_name177 = default(CParser.type_name_return);

		object string_literal167_tree=null;
		object string_literal169_tree=null;
		object string_literal173_tree=null;
		object string_literal175_tree=null;
		object char_literal176_tree=null;
		object char_literal178_tree=null;

		try { DebugEnterRule(GrammarFileName, "unary_expression");
		DebugLocation(303, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 40)) { return retval; }
			// C.g:304:2: ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' unary_expression | 'sizeof' '(' type_name ')' )
			int alt48=6;
			try { DebugEnterDecision(48, decisionCanBacktrack[48]);
			try
			{
				alt48 = dfa48.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(48); }
			switch (alt48)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:304:4: postfix_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(304, 4);
				PushFollow(Follow._postfix_expression_in_unary_expression1152);
				postfix_expression166=postfix_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, postfix_expression166.Tree, postfix_expression166, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:305:4: '++' unary_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(305, 4);
				string_literal167=(IToken)Match(input,58,Follow._58_in_unary_expression1157); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal167_tree = (object)adaptor.Create(string_literal167, retval);
				adaptor.AddChild(root_0, string_literal167_tree);
				}
				DebugLocation(305, 9);
				PushFollow(Follow._unary_expression_in_unary_expression1159);
				unary_expression168=unary_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression168.Tree, unary_expression168, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:306:4: '--' unary_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(306, 4);
				string_literal169=(IToken)Match(input,59,Follow._59_in_unary_expression1164); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal169_tree = (object)adaptor.Create(string_literal169, retval);
				adaptor.AddChild(root_0, string_literal169_tree);
				}
				DebugLocation(306, 9);
				PushFollow(Follow._unary_expression_in_unary_expression1166);
				unary_expression170=unary_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression170.Tree, unary_expression170, retval);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:307:4: unary_operator cast_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(307, 4);
				PushFollow(Follow._unary_operator_in_unary_expression1171);
				unary_operator171=unary_operator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_operator171.Tree, unary_operator171, retval);
				DebugLocation(307, 19);
				PushFollow(Follow._cast_expression_in_unary_expression1173);
				cast_expression172=cast_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression172.Tree, cast_expression172, retval);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C.g:308:4: 'sizeof' unary_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(308, 4);
				string_literal173=(IToken)Match(input,60,Follow._60_in_unary_expression1178); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal173_tree = (object)adaptor.Create(string_literal173, retval);
				adaptor.AddChild(root_0, string_literal173_tree);
				}
				DebugLocation(308, 13);
				PushFollow(Follow._unary_expression_in_unary_expression1180);
				unary_expression174=unary_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression174.Tree, unary_expression174, retval);

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// C.g:309:4: 'sizeof' '(' type_name ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(309, 4);
				string_literal175=(IToken)Match(input,60,Follow._60_in_unary_expression1185); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal175_tree = (object)adaptor.Create(string_literal175, retval);
				adaptor.AddChild(root_0, string_literal175_tree);
				}
				DebugLocation(309, 13);
				char_literal176=(IToken)Match(input,48,Follow._48_in_unary_expression1187); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal176_tree = (object)adaptor.Create(char_literal176, retval);
				adaptor.AddChild(root_0, char_literal176_tree);
				}
				DebugLocation(309, 17);
				PushFollow(Follow._type_name_in_unary_expression1189);
				type_name177=type_name();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_name177.Tree, type_name177, retval);
				DebugLocation(309, 27);
				char_literal178=(IToken)Match(input,49,Follow._49_in_unary_expression1191); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal178_tree = (object)adaptor.Create(char_literal178, retval);
				adaptor.AddChild(root_0, char_literal178_tree);
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
			TraceOut("unary_expression", 40);
			LeaveRule("unary_expression", 40);
			Leave_unary_expression();
			if (state.backtracking > 0) { Memoize(input, 40, unary_expression_StartIndex); }
		}
		DebugLocation(310, 1);
		} finally { DebugExitRule(GrammarFileName, "unary_expression"); }
		return retval;

	}
	// $ANTLR end "unary_expression"

	public class postfix_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_postfix_expression();
	partial void Leave_postfix_expression();

	// $ANTLR start "postfix_expression"
	// C.g:312:1: postfix_expression : primary_expression ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )* ;
	[GrammarRule("postfix_expression")]
	public CParser.postfix_expression_return postfix_expression()
	{
		Enter_postfix_expression();
		EnterRule("postfix_expression", 41);
		TraceIn("postfix_expression", 41);
		CParser.postfix_expression_return retval = new CParser.postfix_expression_return();
		retval.Start = (IToken)input.LT(1);
		int postfix_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal180=null;
		IToken char_literal182=null;
		IToken char_literal183=null;
		IToken char_literal184=null;
		IToken char_literal185=null;
		IToken char_literal187=null;
		IToken char_literal188=null;
		IToken IDENTIFIER189=null;
		IToken string_literal190=null;
		IToken IDENTIFIER191=null;
		IToken string_literal192=null;
		IToken string_literal193=null;
		CParser.primary_expression_return primary_expression179 = default(CParser.primary_expression_return);
		CParser.expression_return expression181 = default(CParser.expression_return);
		CParser.argument_expression_list_return argument_expression_list186 = default(CParser.argument_expression_list_return);

		object char_literal180_tree=null;
		object char_literal182_tree=null;
		object char_literal183_tree=null;
		object char_literal184_tree=null;
		object char_literal185_tree=null;
		object char_literal187_tree=null;
		object char_literal188_tree=null;
		object IDENTIFIER189_tree=null;
		object string_literal190_tree=null;
		object IDENTIFIER191_tree=null;
		object string_literal192_tree=null;
		object string_literal193_tree=null;

		try { DebugEnterRule(GrammarFileName, "postfix_expression");
		DebugLocation(312, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 41)) { return retval; }
			// C.g:313:2: ( primary_expression ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )* )
			DebugEnterAlt(1);
			// C.g:313:6: primary_expression ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(313, 6);
			PushFollow(Follow._primary_expression_in_postfix_expression1204);
			primary_expression179=primary_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primary_expression179.Tree, primary_expression179, retval);
			DebugLocation(314, 9);
			// C.g:314:9: ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )*
			try { DebugEnterSubRule(49);
			while (true)
			{
				int alt49=8;
				try { DebugEnterDecision(49, decisionCanBacktrack[49]);
				try
				{
					alt49 = dfa49.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(49); }
				switch ( alt49 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:314:13: '[' expression ']'
					{
					DebugLocation(314, 13);
					char_literal180=(IToken)Match(input,50,Follow._50_in_postfix_expression1218); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal180_tree = (object)adaptor.Create(char_literal180, retval);
					adaptor.AddChild(root_0, char_literal180_tree);
					}
					DebugLocation(314, 17);
					PushFollow(Follow._expression_in_postfix_expression1220);
					expression181=expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression181.Tree, expression181, retval);
					DebugLocation(314, 28);
					char_literal182=(IToken)Match(input,51,Follow._51_in_postfix_expression1222); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal182_tree = (object)adaptor.Create(char_literal182, retval);
					adaptor.AddChild(root_0, char_literal182_tree);
					}

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// C.g:315:13: '(' ')'
					{
					DebugLocation(315, 13);
					char_literal183=(IToken)Match(input,48,Follow._48_in_postfix_expression1236); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal183_tree = (object)adaptor.Create(char_literal183, retval);
					adaptor.AddChild(root_0, char_literal183_tree);
					}
					DebugLocation(315, 17);
					char_literal184=(IToken)Match(input,49,Follow._49_in_postfix_expression1238); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal184_tree = (object)adaptor.Create(char_literal184, retval);
					adaptor.AddChild(root_0, char_literal184_tree);
					}

					}
					break;
				case 3:
					DebugEnterAlt(3);
					// C.g:316:13: '(' argument_expression_list ')'
					{
					DebugLocation(316, 13);
					char_literal185=(IToken)Match(input,48,Follow._48_in_postfix_expression1252); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal185_tree = (object)adaptor.Create(char_literal185, retval);
					adaptor.AddChild(root_0, char_literal185_tree);
					}
					DebugLocation(316, 17);
					PushFollow(Follow._argument_expression_list_in_postfix_expression1254);
					argument_expression_list186=argument_expression_list();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, argument_expression_list186.Tree, argument_expression_list186, retval);
					DebugLocation(316, 42);
					char_literal187=(IToken)Match(input,49,Follow._49_in_postfix_expression1256); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal187_tree = (object)adaptor.Create(char_literal187, retval);
					adaptor.AddChild(root_0, char_literal187_tree);
					}

					}
					break;
				case 4:
					DebugEnterAlt(4);
					// C.g:317:13: '.' IDENTIFIER
					{
					DebugLocation(317, 13);
					char_literal188=(IToken)Match(input,61,Follow._61_in_postfix_expression1270); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal188_tree = (object)adaptor.Create(char_literal188, retval);
					adaptor.AddChild(root_0, char_literal188_tree);
					}
					DebugLocation(317, 17);
					IDENTIFIER189=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_postfix_expression1272), "IDENTIFIER"); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					IDENTIFIER189_tree = (object)adaptor.Create(IDENTIFIER189, retval);
					adaptor.AddChild(root_0, IDENTIFIER189_tree);
					}

					}
					break;
				case 5:
					DebugEnterAlt(5);
					// C.g:318:13: '->' IDENTIFIER
					{
					DebugLocation(318, 13);
					string_literal190=(IToken)Match(input,62,Follow._62_in_postfix_expression1286); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal190_tree = (object)adaptor.Create(string_literal190, retval);
					adaptor.AddChild(root_0, string_literal190_tree);
					}
					DebugLocation(318, 18);
					IDENTIFIER191=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_postfix_expression1288), "IDENTIFIER"); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					IDENTIFIER191_tree = (object)adaptor.Create(IDENTIFIER191, retval);
					adaptor.AddChild(root_0, IDENTIFIER191_tree);
					}

					}
					break;
				case 6:
					DebugEnterAlt(6);
					// C.g:319:13: '++'
					{
					DebugLocation(319, 13);
					string_literal192=(IToken)Match(input,58,Follow._58_in_postfix_expression1302); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal192_tree = (object)adaptor.Create(string_literal192, retval);
					adaptor.AddChild(root_0, string_literal192_tree);
					}

					}
					break;
				case 7:
					DebugEnterAlt(7);
					// C.g:320:13: '--'
					{
					DebugLocation(320, 13);
					string_literal193=(IToken)Match(input,59,Follow._59_in_postfix_expression1316); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal193_tree = (object)adaptor.Create(string_literal193, retval);
					adaptor.AddChild(root_0, string_literal193_tree);
					}

					}
					break;

				default:
					goto loop49;
				}
			}

			loop49:
				;

			} finally { DebugExitSubRule(49); }


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
			TraceOut("postfix_expression", 41);
			LeaveRule("postfix_expression", 41);
			Leave_postfix_expression();
			if (state.backtracking > 0) { Memoize(input, 41, postfix_expression_StartIndex); }
		}
		DebugLocation(322, 1);
		} finally { DebugExitRule(GrammarFileName, "postfix_expression"); }
		return retval;

	}
	// $ANTLR end "postfix_expression"

	public class unary_operator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_unary_operator();
	partial void Leave_unary_operator();

	// $ANTLR start "unary_operator"
	// C.g:324:1: unary_operator : ( '&' | '*' | '+' | '-' | '~' | '!' );
	[GrammarRule("unary_operator")]
	public CParser.unary_operator_return unary_operator()
	{
		Enter_unary_operator();
		EnterRule("unary_operator", 42);
		TraceIn("unary_operator", 42);
		CParser.unary_operator_return retval = new CParser.unary_operator_return();
		retval.Start = (IToken)input.LT(1);
		int unary_operator_StartIndex = input.Index;
		object root_0 = null;

		IToken set194=null;

		object set194_tree=null;

		try { DebugEnterRule(GrammarFileName, "unary_operator");
		DebugLocation(324, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 42)) { return retval; }
			// C.g:325:2: ( '&' | '*' | '+' | '-' | '~' | '!' )
			DebugEnterAlt(1);
			// C.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(325, 2);
			set194=(IToken)input.LT(1);
			if (input.LA(1)==52||(input.LA(1)>=54 && input.LA(1)<=55)||(input.LA(1)>=63 && input.LA(1)<=65))
			{
				input.Consume();
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set194, retval));
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
			TraceOut("unary_operator", 42);
			LeaveRule("unary_operator", 42);
			Leave_unary_operator();
			if (state.backtracking > 0) { Memoize(input, 42, unary_operator_StartIndex); }
		}
		DebugLocation(331, 1);
		} finally { DebugExitRule(GrammarFileName, "unary_operator"); }
		return retval;

	}
	// $ANTLR end "unary_operator"

	public class primary_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_primary_expression();
	partial void Leave_primary_expression();

	// $ANTLR start "primary_expression"
	// C.g:333:1: primary_expression : ( IDENTIFIER | constant | '(' expression ')' );
	[GrammarRule("primary_expression")]
	public CParser.primary_expression_return primary_expression()
	{
		Enter_primary_expression();
		EnterRule("primary_expression", 43);
		TraceIn("primary_expression", 43);
		CParser.primary_expression_return retval = new CParser.primary_expression_return();
		retval.Start = (IToken)input.LT(1);
		int primary_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENTIFIER195=null;
		IToken char_literal197=null;
		IToken char_literal199=null;
		CParser.constant_return constant196 = default(CParser.constant_return);
		CParser.expression_return expression198 = default(CParser.expression_return);

		object IDENTIFIER195_tree=null;
		object char_literal197_tree=null;
		object char_literal199_tree=null;

		try { DebugEnterRule(GrammarFileName, "primary_expression");
		DebugLocation(333, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 43)) { return retval; }
			// C.g:334:2: ( IDENTIFIER | constant | '(' expression ')' )
			int alt50=3;
			try { DebugEnterDecision(50, decisionCanBacktrack[50]);
			switch (input.LA(1))
			{
			case IDENTIFIER:
				{
				alt50=1;
				}
				break;
			case HEX_LITERAL:
			case OCTAL_LITERAL:
			case DECIMAL_LITERAL:
			case CHARACTER_LITERAL:
			case STRING_LITERAL:
			case FLOATING_POINT_LITERAL:
				{
				alt50=2;
				}
				break;
			case 48:
				{
				alt50=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 50, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(50); }
			switch (alt50)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:334:4: IDENTIFIER
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(334, 4);
				IDENTIFIER195=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_primary_expression1374), "IDENTIFIER"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENTIFIER195_tree = (object)adaptor.Create(IDENTIFIER195, retval);
				adaptor.AddChild(root_0, IDENTIFIER195_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:335:4: constant
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(335, 4);
				PushFollow(Follow._constant_in_primary_expression1379);
				constant196=constant();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant196.Tree, constant196, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:336:4: '(' expression ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(336, 4);
				char_literal197=(IToken)Match(input,48,Follow._48_in_primary_expression1384); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal197_tree = (object)adaptor.Create(char_literal197, retval);
				adaptor.AddChild(root_0, char_literal197_tree);
				}
				DebugLocation(336, 8);
				PushFollow(Follow._expression_in_primary_expression1386);
				expression198=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression198.Tree, expression198, retval);
				DebugLocation(336, 19);
				char_literal199=(IToken)Match(input,49,Follow._49_in_primary_expression1388); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal199_tree = (object)adaptor.Create(char_literal199, retval);
				adaptor.AddChild(root_0, char_literal199_tree);
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
			TraceOut("primary_expression", 43);
			LeaveRule("primary_expression", 43);
			Leave_primary_expression();
			if (state.backtracking > 0) { Memoize(input, 43, primary_expression_StartIndex); }
		}
		DebugLocation(337, 1);
		} finally { DebugExitRule(GrammarFileName, "primary_expression"); }
		return retval;

	}
	// $ANTLR end "primary_expression"

	public class constant_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_constant();
	partial void Leave_constant();

	// $ANTLR start "constant"
	// C.g:339:1: constant : ( hex_literal | octal_literal | decimal_literal | character_literal | string_literal | floating_point_literal );
	[GrammarRule("constant")]
	public CParser.constant_return constant()
	{
		Enter_constant();
		EnterRule("constant", 44);
		TraceIn("constant", 44);
		CParser.constant_return retval = new CParser.constant_return();
		retval.Start = (IToken)input.LT(1);
		int constant_StartIndex = input.Index;
		object root_0 = null;

		CParser.hex_literal_return hex_literal200 = default(CParser.hex_literal_return);
		CParser.octal_literal_return octal_literal201 = default(CParser.octal_literal_return);
		CParser.decimal_literal_return decimal_literal202 = default(CParser.decimal_literal_return);
		CParser.character_literal_return character_literal203 = default(CParser.character_literal_return);
		CParser.string_literal_return string_literal204 = default(CParser.string_literal_return);
		CParser.floating_point_literal_return floating_point_literal205 = default(CParser.floating_point_literal_return);


		try { DebugEnterRule(GrammarFileName, "constant");
		DebugLocation(339, 4);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 44)) { return retval; }
			// C.g:340:5: ( hex_literal | octal_literal | decimal_literal | character_literal | string_literal | floating_point_literal )
			int alt51=6;
			try { DebugEnterDecision(51, decisionCanBacktrack[51]);
			switch (input.LA(1))
			{
			case HEX_LITERAL:
				{
				alt51=1;
				}
				break;
			case OCTAL_LITERAL:
				{
				alt51=2;
				}
				break;
			case DECIMAL_LITERAL:
				{
				alt51=3;
				}
				break;
			case CHARACTER_LITERAL:
				{
				alt51=4;
				}
				break;
			case STRING_LITERAL:
				{
				alt51=5;
				}
				break;
			case FLOATING_POINT_LITERAL:
				{
				alt51=6;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 51, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(51); }
			switch (alt51)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:340:9: hex_literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(340, 9);
				PushFollow(Follow._hex_literal_in_constant1404);
				hex_literal200=hex_literal();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, hex_literal200.Tree, hex_literal200, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:341:9: octal_literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(341, 9);
				PushFollow(Follow._octal_literal_in_constant1414);
				octal_literal201=octal_literal();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, octal_literal201.Tree, octal_literal201, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:342:9: decimal_literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(342, 9);
				PushFollow(Follow._decimal_literal_in_constant1424);
				decimal_literal202=decimal_literal();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, decimal_literal202.Tree, decimal_literal202, retval);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:343:9: character_literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(343, 9);
				PushFollow(Follow._character_literal_in_constant1434);
				character_literal203=character_literal();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, character_literal203.Tree, character_literal203, retval);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C.g:344:9: string_literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(344, 9);
				PushFollow(Follow._string_literal_in_constant1444);
				string_literal204=string_literal();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, string_literal204.Tree, string_literal204, retval);

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// C.g:345:9: floating_point_literal
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(345, 9);
				PushFollow(Follow._floating_point_literal_in_constant1454);
				floating_point_literal205=floating_point_literal();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, floating_point_literal205.Tree, floating_point_literal205, retval);

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
			TraceOut("constant", 44);
			LeaveRule("constant", 44);
			Leave_constant();
			if (state.backtracking > 0) { Memoize(input, 44, constant_StartIndex); }
		}
		DebugLocation(346, 4);
		} finally { DebugExitRule(GrammarFileName, "constant"); }
		return retval;

	}
	// $ANTLR end "constant"

	public class hex_literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_hex_literal();
	partial void Leave_hex_literal();

	// $ANTLR start "hex_literal"
	// C.g:348:1: hex_literal : HEX_LITERAL ;
	[GrammarRule("hex_literal")]
	public CParser.hex_literal_return hex_literal()
	{
		Enter_hex_literal();
		EnterRule("hex_literal", 45);
		TraceIn("hex_literal", 45);
		CParser.hex_literal_return retval = new CParser.hex_literal_return();
		retval.Start = (IToken)input.LT(1);
		int hex_literal_StartIndex = input.Index;
		object root_0 = null;

		IToken HEX_LITERAL206=null;

		object HEX_LITERAL206_tree=null;

		try { DebugEnterRule(GrammarFileName, "hex_literal");
		DebugLocation(348, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 45)) { return retval; }
			// C.g:349:2: ( HEX_LITERAL )
			DebugEnterAlt(1);
			// C.g:349:4: HEX_LITERAL
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(349, 4);
			HEX_LITERAL206=(IToken)new XToken((IToken)Match(input,HEX_LITERAL,Follow._HEX_LITERAL_in_hex_literal1468), "HEX_LITERAL"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			HEX_LITERAL206_tree = (object)adaptor.Create(HEX_LITERAL206, retval);
			adaptor.AddChild(root_0, HEX_LITERAL206_tree);
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
			TraceOut("hex_literal", 45);
			LeaveRule("hex_literal", 45);
			Leave_hex_literal();
			if (state.backtracking > 0) { Memoize(input, 45, hex_literal_StartIndex); }
		}
		DebugLocation(350, 1);
		} finally { DebugExitRule(GrammarFileName, "hex_literal"); }
		return retval;

	}
	// $ANTLR end "hex_literal"

	public class octal_literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_octal_literal();
	partial void Leave_octal_literal();

	// $ANTLR start "octal_literal"
	// C.g:352:1: octal_literal : OCTAL_LITERAL ;
	[GrammarRule("octal_literal")]
	public CParser.octal_literal_return octal_literal()
	{
		Enter_octal_literal();
		EnterRule("octal_literal", 46);
		TraceIn("octal_literal", 46);
		CParser.octal_literal_return retval = new CParser.octal_literal_return();
		retval.Start = (IToken)input.LT(1);
		int octal_literal_StartIndex = input.Index;
		object root_0 = null;

		IToken OCTAL_LITERAL207=null;

		object OCTAL_LITERAL207_tree=null;

		try { DebugEnterRule(GrammarFileName, "octal_literal");
		DebugLocation(352, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 46)) { return retval; }
			// C.g:353:2: ( OCTAL_LITERAL )
			DebugEnterAlt(1);
			// C.g:353:4: OCTAL_LITERAL
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(353, 4);
			OCTAL_LITERAL207=(IToken)new XToken((IToken)Match(input,OCTAL_LITERAL,Follow._OCTAL_LITERAL_in_octal_literal1479), "OCTAL_LITERAL"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			OCTAL_LITERAL207_tree = (object)adaptor.Create(OCTAL_LITERAL207, retval);
			adaptor.AddChild(root_0, OCTAL_LITERAL207_tree);
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
			TraceOut("octal_literal", 46);
			LeaveRule("octal_literal", 46);
			Leave_octal_literal();
			if (state.backtracking > 0) { Memoize(input, 46, octal_literal_StartIndex); }
		}
		DebugLocation(354, 1);
		} finally { DebugExitRule(GrammarFileName, "octal_literal"); }
		return retval;

	}
	// $ANTLR end "octal_literal"

	public class decimal_literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_decimal_literal();
	partial void Leave_decimal_literal();

	// $ANTLR start "decimal_literal"
	// C.g:356:1: decimal_literal : DECIMAL_LITERAL ;
	[GrammarRule("decimal_literal")]
	public CParser.decimal_literal_return decimal_literal()
	{
		Enter_decimal_literal();
		EnterRule("decimal_literal", 47);
		TraceIn("decimal_literal", 47);
		CParser.decimal_literal_return retval = new CParser.decimal_literal_return();
		retval.Start = (IToken)input.LT(1);
		int decimal_literal_StartIndex = input.Index;
		object root_0 = null;

		IToken DECIMAL_LITERAL208=null;

		object DECIMAL_LITERAL208_tree=null;

		try { DebugEnterRule(GrammarFileName, "decimal_literal");
		DebugLocation(356, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 47)) { return retval; }
			// C.g:357:2: ( DECIMAL_LITERAL )
			DebugEnterAlt(1);
			// C.g:357:4: DECIMAL_LITERAL
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(357, 4);
			DECIMAL_LITERAL208=(IToken)new XToken((IToken)Match(input,DECIMAL_LITERAL,Follow._DECIMAL_LITERAL_in_decimal_literal1490), "DECIMAL_LITERAL"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			DECIMAL_LITERAL208_tree = (object)adaptor.Create(DECIMAL_LITERAL208, retval);
			adaptor.AddChild(root_0, DECIMAL_LITERAL208_tree);
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
			TraceOut("decimal_literal", 47);
			LeaveRule("decimal_literal", 47);
			Leave_decimal_literal();
			if (state.backtracking > 0) { Memoize(input, 47, decimal_literal_StartIndex); }
		}
		DebugLocation(358, 1);
		} finally { DebugExitRule(GrammarFileName, "decimal_literal"); }
		return retval;

	}
	// $ANTLR end "decimal_literal"

	public class character_literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_character_literal();
	partial void Leave_character_literal();

	// $ANTLR start "character_literal"
	// C.g:360:1: character_literal : CHARACTER_LITERAL ;
	[GrammarRule("character_literal")]
	public CParser.character_literal_return character_literal()
	{
		Enter_character_literal();
		EnterRule("character_literal", 48);
		TraceIn("character_literal", 48);
		CParser.character_literal_return retval = new CParser.character_literal_return();
		retval.Start = (IToken)input.LT(1);
		int character_literal_StartIndex = input.Index;
		object root_0 = null;

		IToken CHARACTER_LITERAL209=null;

		object CHARACTER_LITERAL209_tree=null;

		try { DebugEnterRule(GrammarFileName, "character_literal");
		DebugLocation(360, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 48)) { return retval; }
			// C.g:361:2: ( CHARACTER_LITERAL )
			DebugEnterAlt(1);
			// C.g:361:4: CHARACTER_LITERAL
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(361, 4);
			CHARACTER_LITERAL209=(IToken)new XToken((IToken)Match(input,CHARACTER_LITERAL,Follow._CHARACTER_LITERAL_in_character_literal1501), "CHARACTER_LITERAL"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			CHARACTER_LITERAL209_tree = (object)adaptor.Create(CHARACTER_LITERAL209, retval);
			adaptor.AddChild(root_0, CHARACTER_LITERAL209_tree);
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
			TraceOut("character_literal", 48);
			LeaveRule("character_literal", 48);
			Leave_character_literal();
			if (state.backtracking > 0) { Memoize(input, 48, character_literal_StartIndex); }
		}
		DebugLocation(362, 1);
		} finally { DebugExitRule(GrammarFileName, "character_literal"); }
		return retval;

	}
	// $ANTLR end "character_literal"

	public class string_literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_string_literal();
	partial void Leave_string_literal();

	// $ANTLR start "string_literal"
	// C.g:364:1: string_literal : STRING_LITERAL ;
	[GrammarRule("string_literal")]
	public CParser.string_literal_return string_literal()
	{
		Enter_string_literal();
		EnterRule("string_literal", 49);
		TraceIn("string_literal", 49);
		CParser.string_literal_return retval = new CParser.string_literal_return();
		retval.Start = (IToken)input.LT(1);
		int string_literal_StartIndex = input.Index;
		object root_0 = null;

		IToken STRING_LITERAL210=null;

		object STRING_LITERAL210_tree=null;

		try { DebugEnterRule(GrammarFileName, "string_literal");
		DebugLocation(364, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 49)) { return retval; }
			// C.g:365:2: ( STRING_LITERAL )
			DebugEnterAlt(1);
			// C.g:365:4: STRING_LITERAL
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(365, 4);
			STRING_LITERAL210=(IToken)new XToken((IToken)Match(input,STRING_LITERAL,Follow._STRING_LITERAL_in_string_literal1512), "STRING_LITERAL"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			STRING_LITERAL210_tree = (object)adaptor.Create(STRING_LITERAL210, retval);
			adaptor.AddChild(root_0, STRING_LITERAL210_tree);
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
			TraceOut("string_literal", 49);
			LeaveRule("string_literal", 49);
			Leave_string_literal();
			if (state.backtracking > 0) { Memoize(input, 49, string_literal_StartIndex); }
		}
		DebugLocation(366, 1);
		} finally { DebugExitRule(GrammarFileName, "string_literal"); }
		return retval;

	}
	// $ANTLR end "string_literal"

	public class floating_point_literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_floating_point_literal();
	partial void Leave_floating_point_literal();

	// $ANTLR start "floating_point_literal"
	// C.g:368:1: floating_point_literal : FLOATING_POINT_LITERAL ;
	[GrammarRule("floating_point_literal")]
	public CParser.floating_point_literal_return floating_point_literal()
	{
		Enter_floating_point_literal();
		EnterRule("floating_point_literal", 50);
		TraceIn("floating_point_literal", 50);
		CParser.floating_point_literal_return retval = new CParser.floating_point_literal_return();
		retval.Start = (IToken)input.LT(1);
		int floating_point_literal_StartIndex = input.Index;
		object root_0 = null;

		IToken FLOATING_POINT_LITERAL211=null;

		object FLOATING_POINT_LITERAL211_tree=null;

		try { DebugEnterRule(GrammarFileName, "floating_point_literal");
		DebugLocation(368, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 50)) { return retval; }
			// C.g:369:2: ( FLOATING_POINT_LITERAL )
			DebugEnterAlt(1);
			// C.g:369:4: FLOATING_POINT_LITERAL
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(369, 4);
			FLOATING_POINT_LITERAL211=(IToken)new XToken((IToken)Match(input,FLOATING_POINT_LITERAL,Follow._FLOATING_POINT_LITERAL_in_floating_point_literal1523), "FLOATING_POINT_LITERAL"); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			FLOATING_POINT_LITERAL211_tree = (object)adaptor.Create(FLOATING_POINT_LITERAL211, retval);
			adaptor.AddChild(root_0, FLOATING_POINT_LITERAL211_tree);
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
			TraceOut("floating_point_literal", 50);
			LeaveRule("floating_point_literal", 50);
			Leave_floating_point_literal();
			if (state.backtracking > 0) { Memoize(input, 50, floating_point_literal_StartIndex); }
		}
		DebugLocation(370, 1);
		} finally { DebugExitRule(GrammarFileName, "floating_point_literal"); }
		return retval;

	}
	// $ANTLR end "floating_point_literal"

	public class expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expression();
	partial void Leave_expression();

	// $ANTLR start "expression"
	// C.g:374:1: expression : assignment_expression ( ',' assignment_expression )* ;
	[GrammarRule("expression")]
	public CParser.expression_return expression()
	{
		Enter_expression();
		EnterRule("expression", 51);
		TraceIn("expression", 51);
		CParser.expression_return retval = new CParser.expression_return();
		retval.Start = (IToken)input.LT(1);
		int expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal213=null;
		CParser.assignment_expression_return assignment_expression212 = default(CParser.assignment_expression_return);
		CParser.assignment_expression_return assignment_expression214 = default(CParser.assignment_expression_return);

		object char_literal213_tree=null;

		try { DebugEnterRule(GrammarFileName, "expression");
		DebugLocation(374, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 51)) { return retval; }
			// C.g:375:2: ( assignment_expression ( ',' assignment_expression )* )
			DebugEnterAlt(1);
			// C.g:375:4: assignment_expression ( ',' assignment_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(375, 4);
			PushFollow(Follow._assignment_expression_in_expression1536);
			assignment_expression212=assignment_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression212.Tree, assignment_expression212, retval);
			DebugLocation(375, 26);
			// C.g:375:26: ( ',' assignment_expression )*
			try { DebugEnterSubRule(52);
			while (true)
			{
				int alt52=2;
				try { DebugEnterDecision(52, decisionCanBacktrack[52]);
				int LA52_0 = input.LA(1);

				if ((LA52_0==25))
				{
					alt52=1;
				}


				} finally { DebugExitDecision(52); }
				switch ( alt52 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:375:27: ',' assignment_expression
					{
					DebugLocation(375, 27);
					char_literal213=(IToken)Match(input,25,Follow._25_in_expression1539); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal213_tree = (object)adaptor.Create(char_literal213, retval);
					adaptor.AddChild(root_0, char_literal213_tree);
					}
					DebugLocation(375, 31);
					PushFollow(Follow._assignment_expression_in_expression1541);
					assignment_expression214=assignment_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression214.Tree, assignment_expression214, retval);

					}
					break;

				default:
					goto loop52;
				}
			}

			loop52:
				;

			} finally { DebugExitSubRule(52); }


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
			TraceOut("expression", 51);
			LeaveRule("expression", 51);
			Leave_expression();
			if (state.backtracking > 0) { Memoize(input, 51, expression_StartIndex); }
		}
		DebugLocation(376, 1);
		} finally { DebugExitRule(GrammarFileName, "expression"); }
		return retval;

	}
	// $ANTLR end "expression"

	public class constant_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_constant_expression();
	partial void Leave_constant_expression();

	// $ANTLR start "constant_expression"
	// C.g:378:1: constant_expression : conditional_expression ;
	[GrammarRule("constant_expression")]
	public CParser.constant_expression_return constant_expression()
	{
		Enter_constant_expression();
		EnterRule("constant_expression", 52);
		TraceIn("constant_expression", 52);
		CParser.constant_expression_return retval = new CParser.constant_expression_return();
		retval.Start = (IToken)input.LT(1);
		int constant_expression_StartIndex = input.Index;
		object root_0 = null;

		CParser.conditional_expression_return conditional_expression215 = default(CParser.conditional_expression_return);


		try { DebugEnterRule(GrammarFileName, "constant_expression");
		DebugLocation(378, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 52)) { return retval; }
			// C.g:379:2: ( conditional_expression )
			DebugEnterAlt(1);
			// C.g:379:4: conditional_expression
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(379, 4);
			PushFollow(Follow._conditional_expression_in_constant_expression1554);
			conditional_expression215=conditional_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditional_expression215.Tree, conditional_expression215, retval);

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
			TraceOut("constant_expression", 52);
			LeaveRule("constant_expression", 52);
			Leave_constant_expression();
			if (state.backtracking > 0) { Memoize(input, 52, constant_expression_StartIndex); }
		}
		DebugLocation(380, 1);
		} finally { DebugExitRule(GrammarFileName, "constant_expression"); }
		return retval;

	}
	// $ANTLR end "constant_expression"

	public class assignment_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignment_expression();
	partial void Leave_assignment_expression();

	// $ANTLR start "assignment_expression"
	// C.g:382:1: assignment_expression : ( lvalue assignment_operator assignment_expression | conditional_expression );
	[GrammarRule("assignment_expression")]
	public CParser.assignment_expression_return assignment_expression()
	{
		Enter_assignment_expression();
		EnterRule("assignment_expression", 53);
		TraceIn("assignment_expression", 53);
		CParser.assignment_expression_return retval = new CParser.assignment_expression_return();
		retval.Start = (IToken)input.LT(1);
		int assignment_expression_StartIndex = input.Index;
		object root_0 = null;

		CParser.lvalue_return lvalue216 = default(CParser.lvalue_return);
		CParser.assignment_operator_return assignment_operator217 = default(CParser.assignment_operator_return);
		CParser.assignment_expression_return assignment_expression218 = default(CParser.assignment_expression_return);
		CParser.conditional_expression_return conditional_expression219 = default(CParser.conditional_expression_return);


		try { DebugEnterRule(GrammarFileName, "assignment_expression");
		DebugLocation(382, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 53)) { return retval; }
			// C.g:383:2: ( lvalue assignment_operator assignment_expression | conditional_expression )
			int alt53=2;
			try { DebugEnterDecision(53, decisionCanBacktrack[53]);
			try
			{
				alt53 = dfa53.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(53); }
			switch (alt53)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:383:4: lvalue assignment_operator assignment_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(383, 4);
				PushFollow(Follow._lvalue_in_assignment_expression1565);
				lvalue216=lvalue();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, lvalue216.Tree, lvalue216, retval);
				DebugLocation(383, 11);
				PushFollow(Follow._assignment_operator_in_assignment_expression1567);
				assignment_operator217=assignment_operator();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_operator217.Tree, assignment_operator217, retval);
				DebugLocation(383, 31);
				PushFollow(Follow._assignment_expression_in_assignment_expression1569);
				assignment_expression218=assignment_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression218.Tree, assignment_expression218, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:384:4: conditional_expression
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(384, 4);
				PushFollow(Follow._conditional_expression_in_assignment_expression1574);
				conditional_expression219=conditional_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditional_expression219.Tree, conditional_expression219, retval);

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
			TraceOut("assignment_expression", 53);
			LeaveRule("assignment_expression", 53);
			Leave_assignment_expression();
			if (state.backtracking > 0) { Memoize(input, 53, assignment_expression_StartIndex); }
		}
		DebugLocation(385, 1);
		} finally { DebugExitRule(GrammarFileName, "assignment_expression"); }
		return retval;

	}
	// $ANTLR end "assignment_expression"

	public class lvalue_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_lvalue();
	partial void Leave_lvalue();

	// $ANTLR start "lvalue"
	// C.g:387:1: lvalue : unary_expression ;
	[GrammarRule("lvalue")]
	public CParser.lvalue_return lvalue()
	{
		Enter_lvalue();
		EnterRule("lvalue", 54);
		TraceIn("lvalue", 54);
		CParser.lvalue_return retval = new CParser.lvalue_return();
		retval.Start = (IToken)input.LT(1);
		int lvalue_StartIndex = input.Index;
		object root_0 = null;

		CParser.unary_expression_return unary_expression220 = default(CParser.unary_expression_return);


		try { DebugEnterRule(GrammarFileName, "lvalue");
		DebugLocation(387, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 54)) { return retval; }
			// C.g:388:2: ( unary_expression )
			DebugEnterAlt(1);
			// C.g:388:4: unary_expression
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(388, 4);
			PushFollow(Follow._unary_expression_in_lvalue1586);
			unary_expression220=unary_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression220.Tree, unary_expression220, retval);

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
			TraceOut("lvalue", 54);
			LeaveRule("lvalue", 54);
			Leave_lvalue();
			if (state.backtracking > 0) { Memoize(input, 54, lvalue_StartIndex); }
		}
		DebugLocation(389, 1);
		} finally { DebugExitRule(GrammarFileName, "lvalue"); }
		return retval;

	}
	// $ANTLR end "lvalue"

	public class assignment_operator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_assignment_operator();
	partial void Leave_assignment_operator();

	// $ANTLR start "assignment_operator"
	// C.g:391:1: assignment_operator : ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '&=' | '^=' | '|=' );
	[GrammarRule("assignment_operator")]
	public CParser.assignment_operator_return assignment_operator()
	{
		Enter_assignment_operator();
		EnterRule("assignment_operator", 55);
		TraceIn("assignment_operator", 55);
		CParser.assignment_operator_return retval = new CParser.assignment_operator_return();
		retval.Start = (IToken)input.LT(1);
		int assignment_operator_StartIndex = input.Index;
		object root_0 = null;

		IToken set221=null;

		object set221_tree=null;

		try { DebugEnterRule(GrammarFileName, "assignment_operator");
		DebugLocation(391, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 55)) { return retval; }
			// C.g:392:2: ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '&=' | '^=' | '|=' )
			DebugEnterAlt(1);
			// C.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(392, 2);
			set221=(IToken)input.LT(1);
			if (input.LA(1)==26||(input.LA(1)>=66 && input.LA(1)<=75))
			{
				input.Consume();
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set221, retval));
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
			TraceOut("assignment_operator", 55);
			LeaveRule("assignment_operator", 55);
			Leave_assignment_operator();
			if (state.backtracking > 0) { Memoize(input, 55, assignment_operator_StartIndex); }
		}
		DebugLocation(403, 1);
		} finally { DebugExitRule(GrammarFileName, "assignment_operator"); }
		return retval;

	}
	// $ANTLR end "assignment_operator"

	public class conditional_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_conditional_expression();
	partial void Leave_conditional_expression();

	// $ANTLR start "conditional_expression"
	// C.g:405:1: conditional_expression : logical_or_expression ( '?' expression ':' conditional_expression )? ;
	[GrammarRule("conditional_expression")]
	public CParser.conditional_expression_return conditional_expression()
	{
		Enter_conditional_expression();
		EnterRule("conditional_expression", 56);
		TraceIn("conditional_expression", 56);
		CParser.conditional_expression_return retval = new CParser.conditional_expression_return();
		retval.Start = (IToken)input.LT(1);
		int conditional_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal223=null;
		IToken char_literal225=null;
		CParser.logical_or_expression_return logical_or_expression222 = default(CParser.logical_or_expression_return);
		CParser.expression_return expression224 = default(CParser.expression_return);
		CParser.conditional_expression_return conditional_expression226 = default(CParser.conditional_expression_return);

		object char_literal223_tree=null;
		object char_literal225_tree=null;

		try { DebugEnterRule(GrammarFileName, "conditional_expression");
		DebugLocation(405, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 56)) { return retval; }
			// C.g:406:2: ( logical_or_expression ( '?' expression ':' conditional_expression )? )
			DebugEnterAlt(1);
			// C.g:406:4: logical_or_expression ( '?' expression ':' conditional_expression )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(406, 4);
			PushFollow(Follow._logical_or_expression_in_conditional_expression1658);
			logical_or_expression222=logical_or_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logical_or_expression222.Tree, logical_or_expression222, retval);
			DebugLocation(406, 26);
			// C.g:406:26: ( '?' expression ':' conditional_expression )?
			int alt54=2;
			try { DebugEnterSubRule(54);
			try { DebugEnterDecision(54, decisionCanBacktrack[54]);
			int LA54_0 = input.LA(1);

			if ((LA54_0==76))
			{
				alt54=1;
			}
			} finally { DebugExitDecision(54); }
			switch (alt54)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:406:27: '?' expression ':' conditional_expression
				{
				DebugLocation(406, 27);
				char_literal223=(IToken)Match(input,76,Follow._76_in_conditional_expression1661); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal223_tree = (object)adaptor.Create(char_literal223, retval);
				adaptor.AddChild(root_0, char_literal223_tree);
				}
				DebugLocation(406, 31);
				PushFollow(Follow._expression_in_conditional_expression1663);
				expression224=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression224.Tree, expression224, retval);
				DebugLocation(406, 42);
				char_literal225=(IToken)Match(input,44,Follow._44_in_conditional_expression1665); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal225_tree = (object)adaptor.Create(char_literal225, retval);
				adaptor.AddChild(root_0, char_literal225_tree);
				}
				DebugLocation(406, 46);
				PushFollow(Follow._conditional_expression_in_conditional_expression1667);
				conditional_expression226=conditional_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditional_expression226.Tree, conditional_expression226, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(54); }


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
			TraceOut("conditional_expression", 56);
			LeaveRule("conditional_expression", 56);
			Leave_conditional_expression();
			if (state.backtracking > 0) { Memoize(input, 56, conditional_expression_StartIndex); }
		}
		DebugLocation(407, 1);
		} finally { DebugExitRule(GrammarFileName, "conditional_expression"); }
		return retval;

	}
	// $ANTLR end "conditional_expression"

	public class logical_or_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logical_or_expression();
	partial void Leave_logical_or_expression();

	// $ANTLR start "logical_or_expression"
	// C.g:409:1: logical_or_expression : logical_and_expression ( '||' logical_and_expression )* ;
	[GrammarRule("logical_or_expression")]
	public CParser.logical_or_expression_return logical_or_expression()
	{
		Enter_logical_or_expression();
		EnterRule("logical_or_expression", 57);
		TraceIn("logical_or_expression", 57);
		CParser.logical_or_expression_return retval = new CParser.logical_or_expression_return();
		retval.Start = (IToken)input.LT(1);
		int logical_or_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal228=null;
		CParser.logical_and_expression_return logical_and_expression227 = default(CParser.logical_and_expression_return);
		CParser.logical_and_expression_return logical_and_expression229 = default(CParser.logical_and_expression_return);

		object string_literal228_tree=null;

		try { DebugEnterRule(GrammarFileName, "logical_or_expression");
		DebugLocation(409, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 57)) { return retval; }
			// C.g:410:2: ( logical_and_expression ( '||' logical_and_expression )* )
			DebugEnterAlt(1);
			// C.g:410:4: logical_and_expression ( '||' logical_and_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(410, 4);
			PushFollow(Follow._logical_and_expression_in_logical_or_expression1680);
			logical_and_expression227=logical_and_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logical_and_expression227.Tree, logical_and_expression227, retval);
			DebugLocation(410, 27);
			// C.g:410:27: ( '||' logical_and_expression )*
			try { DebugEnterSubRule(55);
			while (true)
			{
				int alt55=2;
				try { DebugEnterDecision(55, decisionCanBacktrack[55]);
				try
				{
					alt55 = dfa55.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(55); }
				switch ( alt55 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:410:28: '||' logical_and_expression
					{
					DebugLocation(410, 28);
					string_literal228=(IToken)Match(input,77,Follow._77_in_logical_or_expression1683); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal228_tree = (object)adaptor.Create(string_literal228, retval);
					adaptor.AddChild(root_0, string_literal228_tree);
					}
					DebugLocation(410, 33);
					PushFollow(Follow._logical_and_expression_in_logical_or_expression1685);
					logical_and_expression229=logical_and_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logical_and_expression229.Tree, logical_and_expression229, retval);

					}
					break;

				default:
					goto loop55;
				}
			}

			loop55:
				;

			} finally { DebugExitSubRule(55); }


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
			TraceOut("logical_or_expression", 57);
			LeaveRule("logical_or_expression", 57);
			Leave_logical_or_expression();
			if (state.backtracking > 0) { Memoize(input, 57, logical_or_expression_StartIndex); }
		}
		DebugLocation(411, 1);
		} finally { DebugExitRule(GrammarFileName, "logical_or_expression"); }
		return retval;

	}
	// $ANTLR end "logical_or_expression"

	public class logical_and_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_logical_and_expression();
	partial void Leave_logical_and_expression();

	// $ANTLR start "logical_and_expression"
	// C.g:413:1: logical_and_expression : inclusive_or_expression ( '&&' inclusive_or_expression )* ;
	[GrammarRule("logical_and_expression")]
	public CParser.logical_and_expression_return logical_and_expression()
	{
		Enter_logical_and_expression();
		EnterRule("logical_and_expression", 58);
		TraceIn("logical_and_expression", 58);
		CParser.logical_and_expression_return retval = new CParser.logical_and_expression_return();
		retval.Start = (IToken)input.LT(1);
		int logical_and_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal231=null;
		CParser.inclusive_or_expression_return inclusive_or_expression230 = default(CParser.inclusive_or_expression_return);
		CParser.inclusive_or_expression_return inclusive_or_expression232 = default(CParser.inclusive_or_expression_return);

		object string_literal231_tree=null;

		try { DebugEnterRule(GrammarFileName, "logical_and_expression");
		DebugLocation(413, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 58)) { return retval; }
			// C.g:414:2: ( inclusive_or_expression ( '&&' inclusive_or_expression )* )
			DebugEnterAlt(1);
			// C.g:414:4: inclusive_or_expression ( '&&' inclusive_or_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(414, 4);
			PushFollow(Follow._inclusive_or_expression_in_logical_and_expression1698);
			inclusive_or_expression230=inclusive_or_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, inclusive_or_expression230.Tree, inclusive_or_expression230, retval);
			DebugLocation(414, 28);
			// C.g:414:28: ( '&&' inclusive_or_expression )*
			try { DebugEnterSubRule(56);
			while (true)
			{
				int alt56=2;
				try { DebugEnterDecision(56, decisionCanBacktrack[56]);
				try
				{
					alt56 = dfa56.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(56); }
				switch ( alt56 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:414:29: '&&' inclusive_or_expression
					{
					DebugLocation(414, 29);
					string_literal231=(IToken)Match(input,78,Follow._78_in_logical_and_expression1701); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal231_tree = (object)adaptor.Create(string_literal231, retval);
					adaptor.AddChild(root_0, string_literal231_tree);
					}
					DebugLocation(414, 34);
					PushFollow(Follow._inclusive_or_expression_in_logical_and_expression1703);
					inclusive_or_expression232=inclusive_or_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, inclusive_or_expression232.Tree, inclusive_or_expression232, retval);

					}
					break;

				default:
					goto loop56;
				}
			}

			loop56:
				;

			} finally { DebugExitSubRule(56); }


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
			TraceOut("logical_and_expression", 58);
			LeaveRule("logical_and_expression", 58);
			Leave_logical_and_expression();
			if (state.backtracking > 0) { Memoize(input, 58, logical_and_expression_StartIndex); }
		}
		DebugLocation(415, 1);
		} finally { DebugExitRule(GrammarFileName, "logical_and_expression"); }
		return retval;

	}
	// $ANTLR end "logical_and_expression"

	public class inclusive_or_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_inclusive_or_expression();
	partial void Leave_inclusive_or_expression();

	// $ANTLR start "inclusive_or_expression"
	// C.g:417:1: inclusive_or_expression : exclusive_or_expression ( '|' exclusive_or_expression )* ;
	[GrammarRule("inclusive_or_expression")]
	public CParser.inclusive_or_expression_return inclusive_or_expression()
	{
		Enter_inclusive_or_expression();
		EnterRule("inclusive_or_expression", 59);
		TraceIn("inclusive_or_expression", 59);
		CParser.inclusive_or_expression_return retval = new CParser.inclusive_or_expression_return();
		retval.Start = (IToken)input.LT(1);
		int inclusive_or_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal234=null;
		CParser.exclusive_or_expression_return exclusive_or_expression233 = default(CParser.exclusive_or_expression_return);
		CParser.exclusive_or_expression_return exclusive_or_expression235 = default(CParser.exclusive_or_expression_return);

		object char_literal234_tree=null;

		try { DebugEnterRule(GrammarFileName, "inclusive_or_expression");
		DebugLocation(417, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 59)) { return retval; }
			// C.g:418:2: ( exclusive_or_expression ( '|' exclusive_or_expression )* )
			DebugEnterAlt(1);
			// C.g:418:4: exclusive_or_expression ( '|' exclusive_or_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(418, 4);
			PushFollow(Follow._exclusive_or_expression_in_inclusive_or_expression1716);
			exclusive_or_expression233=exclusive_or_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exclusive_or_expression233.Tree, exclusive_or_expression233, retval);
			DebugLocation(418, 28);
			// C.g:418:28: ( '|' exclusive_or_expression )*
			try { DebugEnterSubRule(57);
			while (true)
			{
				int alt57=2;
				try { DebugEnterDecision(57, decisionCanBacktrack[57]);
				try
				{
					alt57 = dfa57.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(57); }
				switch ( alt57 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:418:29: '|' exclusive_or_expression
					{
					DebugLocation(418, 29);
					char_literal234=(IToken)Match(input,79,Follow._79_in_inclusive_or_expression1719); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal234_tree = (object)adaptor.Create(char_literal234, retval);
					adaptor.AddChild(root_0, char_literal234_tree);
					}
					DebugLocation(418, 33);
					PushFollow(Follow._exclusive_or_expression_in_inclusive_or_expression1721);
					exclusive_or_expression235=exclusive_or_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exclusive_or_expression235.Tree, exclusive_or_expression235, retval);

					}
					break;

				default:
					goto loop57;
				}
			}

			loop57:
				;

			} finally { DebugExitSubRule(57); }


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
			TraceOut("inclusive_or_expression", 59);
			LeaveRule("inclusive_or_expression", 59);
			Leave_inclusive_or_expression();
			if (state.backtracking > 0) { Memoize(input, 59, inclusive_or_expression_StartIndex); }
		}
		DebugLocation(419, 1);
		} finally { DebugExitRule(GrammarFileName, "inclusive_or_expression"); }
		return retval;

	}
	// $ANTLR end "inclusive_or_expression"

	public class exclusive_or_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_exclusive_or_expression();
	partial void Leave_exclusive_or_expression();

	// $ANTLR start "exclusive_or_expression"
	// C.g:421:1: exclusive_or_expression : and_expression ( '^' and_expression )* ;
	[GrammarRule("exclusive_or_expression")]
	public CParser.exclusive_or_expression_return exclusive_or_expression()
	{
		Enter_exclusive_or_expression();
		EnterRule("exclusive_or_expression", 60);
		TraceIn("exclusive_or_expression", 60);
		CParser.exclusive_or_expression_return retval = new CParser.exclusive_or_expression_return();
		retval.Start = (IToken)input.LT(1);
		int exclusive_or_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal237=null;
		CParser.and_expression_return and_expression236 = default(CParser.and_expression_return);
		CParser.and_expression_return and_expression238 = default(CParser.and_expression_return);

		object char_literal237_tree=null;

		try { DebugEnterRule(GrammarFileName, "exclusive_or_expression");
		DebugLocation(421, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 60)) { return retval; }
			// C.g:422:2: ( and_expression ( '^' and_expression )* )
			DebugEnterAlt(1);
			// C.g:422:4: and_expression ( '^' and_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(422, 4);
			PushFollow(Follow._and_expression_in_exclusive_or_expression1734);
			and_expression236=and_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, and_expression236.Tree, and_expression236, retval);
			DebugLocation(422, 19);
			// C.g:422:19: ( '^' and_expression )*
			try { DebugEnterSubRule(58);
			while (true)
			{
				int alt58=2;
				try { DebugEnterDecision(58, decisionCanBacktrack[58]);
				try
				{
					alt58 = dfa58.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(58); }
				switch ( alt58 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:422:20: '^' and_expression
					{
					DebugLocation(422, 20);
					char_literal237=(IToken)Match(input,80,Follow._80_in_exclusive_or_expression1737); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal237_tree = (object)adaptor.Create(char_literal237, retval);
					adaptor.AddChild(root_0, char_literal237_tree);
					}
					DebugLocation(422, 24);
					PushFollow(Follow._and_expression_in_exclusive_or_expression1739);
					and_expression238=and_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, and_expression238.Tree, and_expression238, retval);

					}
					break;

				default:
					goto loop58;
				}
			}

			loop58:
				;

			} finally { DebugExitSubRule(58); }


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
			TraceOut("exclusive_or_expression", 60);
			LeaveRule("exclusive_or_expression", 60);
			Leave_exclusive_or_expression();
			if (state.backtracking > 0) { Memoize(input, 60, exclusive_or_expression_StartIndex); }
		}
		DebugLocation(423, 1);
		} finally { DebugExitRule(GrammarFileName, "exclusive_or_expression"); }
		return retval;

	}
	// $ANTLR end "exclusive_or_expression"

	public class and_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_and_expression();
	partial void Leave_and_expression();

	// $ANTLR start "and_expression"
	// C.g:425:1: and_expression : equality_expression ( '&' equality_expression )* ;
	[GrammarRule("and_expression")]
	public CParser.and_expression_return and_expression()
	{
		Enter_and_expression();
		EnterRule("and_expression", 61);
		TraceIn("and_expression", 61);
		CParser.and_expression_return retval = new CParser.and_expression_return();
		retval.Start = (IToken)input.LT(1);
		int and_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal240=null;
		CParser.equality_expression_return equality_expression239 = default(CParser.equality_expression_return);
		CParser.equality_expression_return equality_expression241 = default(CParser.equality_expression_return);

		object char_literal240_tree=null;

		try { DebugEnterRule(GrammarFileName, "and_expression");
		DebugLocation(425, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 61)) { return retval; }
			// C.g:426:2: ( equality_expression ( '&' equality_expression )* )
			DebugEnterAlt(1);
			// C.g:426:4: equality_expression ( '&' equality_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(426, 4);
			PushFollow(Follow._equality_expression_in_and_expression1752);
			equality_expression239=equality_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equality_expression239.Tree, equality_expression239, retval);
			DebugLocation(426, 24);
			// C.g:426:24: ( '&' equality_expression )*
			try { DebugEnterSubRule(59);
			while (true)
			{
				int alt59=2;
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
				switch ( alt59 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:426:25: '&' equality_expression
					{
					DebugLocation(426, 25);
					char_literal240=(IToken)Match(input,63,Follow._63_in_and_expression1755); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					char_literal240_tree = (object)adaptor.Create(char_literal240, retval);
					adaptor.AddChild(root_0, char_literal240_tree);
					}
					DebugLocation(426, 29);
					PushFollow(Follow._equality_expression_in_and_expression1757);
					equality_expression241=equality_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equality_expression241.Tree, equality_expression241, retval);

					}
					break;

				default:
					goto loop59;
				}
			}

			loop59:
				;

			} finally { DebugExitSubRule(59); }


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
			TraceOut("and_expression", 61);
			LeaveRule("and_expression", 61);
			Leave_and_expression();
			if (state.backtracking > 0) { Memoize(input, 61, and_expression_StartIndex); }
		}
		DebugLocation(427, 1);
		} finally { DebugExitRule(GrammarFileName, "and_expression"); }
		return retval;

	}
	// $ANTLR end "and_expression"

	public class equality_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_equality_expression();
	partial void Leave_equality_expression();

	// $ANTLR start "equality_expression"
	// C.g:428:1: equality_expression : relational_expression ( ( '==' | '!=' ) relational_expression )* ;
	[GrammarRule("equality_expression")]
	public CParser.equality_expression_return equality_expression()
	{
		Enter_equality_expression();
		EnterRule("equality_expression", 62);
		TraceIn("equality_expression", 62);
		CParser.equality_expression_return retval = new CParser.equality_expression_return();
		retval.Start = (IToken)input.LT(1);
		int equality_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken set243=null;
		CParser.relational_expression_return relational_expression242 = default(CParser.relational_expression_return);
		CParser.relational_expression_return relational_expression244 = default(CParser.relational_expression_return);

		object set243_tree=null;

		try { DebugEnterRule(GrammarFileName, "equality_expression");
		DebugLocation(428, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 62)) { return retval; }
			// C.g:429:2: ( relational_expression ( ( '==' | '!=' ) relational_expression )* )
			DebugEnterAlt(1);
			// C.g:429:4: relational_expression ( ( '==' | '!=' ) relational_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(429, 4);
			PushFollow(Follow._relational_expression_in_equality_expression1769);
			relational_expression242=relational_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relational_expression242.Tree, relational_expression242, retval);
			DebugLocation(429, 26);
			// C.g:429:26: ( ( '==' | '!=' ) relational_expression )*
			try { DebugEnterSubRule(60);
			while (true)
			{
				int alt60=2;
				try { DebugEnterDecision(60, decisionCanBacktrack[60]);
				try
				{
					alt60 = dfa60.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(60); }
				switch ( alt60 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:429:27: ( '==' | '!=' ) relational_expression
					{
					DebugLocation(429, 27);
					set243=(IToken)input.LT(1);
					if ((input.LA(1)>=81 && input.LA(1)<=82))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set243, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(429, 39);
					PushFollow(Follow._relational_expression_in_equality_expression1778);
					relational_expression244=relational_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relational_expression244.Tree, relational_expression244, retval);

					}
					break;

				default:
					goto loop60;
				}
			}

			loop60:
				;

			} finally { DebugExitSubRule(60); }


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
			TraceOut("equality_expression", 62);
			LeaveRule("equality_expression", 62);
			Leave_equality_expression();
			if (state.backtracking > 0) { Memoize(input, 62, equality_expression_StartIndex); }
		}
		DebugLocation(430, 1);
		} finally { DebugExitRule(GrammarFileName, "equality_expression"); }
		return retval;

	}
	// $ANTLR end "equality_expression"

	public class relational_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_relational_expression();
	partial void Leave_relational_expression();

	// $ANTLR start "relational_expression"
	// C.g:432:1: relational_expression : shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )* ;
	[GrammarRule("relational_expression")]
	public CParser.relational_expression_return relational_expression()
	{
		Enter_relational_expression();
		EnterRule("relational_expression", 63);
		TraceIn("relational_expression", 63);
		CParser.relational_expression_return retval = new CParser.relational_expression_return();
		retval.Start = (IToken)input.LT(1);
		int relational_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken set246=null;
		CParser.shift_expression_return shift_expression245 = default(CParser.shift_expression_return);
		CParser.shift_expression_return shift_expression247 = default(CParser.shift_expression_return);

		object set246_tree=null;

		try { DebugEnterRule(GrammarFileName, "relational_expression");
		DebugLocation(432, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 63)) { return retval; }
			// C.g:433:2: ( shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )* )
			DebugEnterAlt(1);
			// C.g:433:4: shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(433, 4);
			PushFollow(Follow._shift_expression_in_relational_expression1791);
			shift_expression245=shift_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shift_expression245.Tree, shift_expression245, retval);
			DebugLocation(433, 21);
			// C.g:433:21: ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*
			try { DebugEnterSubRule(61);
			while (true)
			{
				int alt61=2;
				try { DebugEnterDecision(61, decisionCanBacktrack[61]);
				try
				{
					alt61 = dfa61.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(61); }
				switch ( alt61 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:433:22: ( '<' | '>' | '<=' | '>=' ) shift_expression
					{
					DebugLocation(433, 22);
					set246=(IToken)input.LT(1);
					if ((input.LA(1)>=83 && input.LA(1)<=86))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set246, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(433, 42);
					PushFollow(Follow._shift_expression_in_relational_expression1804);
					shift_expression247=shift_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shift_expression247.Tree, shift_expression247, retval);

					}
					break;

				default:
					goto loop61;
				}
			}

			loop61:
				;

			} finally { DebugExitSubRule(61); }


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
			TraceOut("relational_expression", 63);
			LeaveRule("relational_expression", 63);
			Leave_relational_expression();
			if (state.backtracking > 0) { Memoize(input, 63, relational_expression_StartIndex); }
		}
		DebugLocation(434, 1);
		} finally { DebugExitRule(GrammarFileName, "relational_expression"); }
		return retval;

	}
	// $ANTLR end "relational_expression"

	public class shift_expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_shift_expression();
	partial void Leave_shift_expression();

	// $ANTLR start "shift_expression"
	// C.g:436:1: shift_expression : additive_expression ( ( '<<' | '>>' ) additive_expression )* ;
	[GrammarRule("shift_expression")]
	public CParser.shift_expression_return shift_expression()
	{
		Enter_shift_expression();
		EnterRule("shift_expression", 64);
		TraceIn("shift_expression", 64);
		CParser.shift_expression_return retval = new CParser.shift_expression_return();
		retval.Start = (IToken)input.LT(1);
		int shift_expression_StartIndex = input.Index;
		object root_0 = null;

		IToken set249=null;
		CParser.additive_expression_return additive_expression248 = default(CParser.additive_expression_return);
		CParser.additive_expression_return additive_expression250 = default(CParser.additive_expression_return);

		object set249_tree=null;

		try { DebugEnterRule(GrammarFileName, "shift_expression");
		DebugLocation(436, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 64)) { return retval; }
			// C.g:437:2: ( additive_expression ( ( '<<' | '>>' ) additive_expression )* )
			DebugEnterAlt(1);
			// C.g:437:4: additive_expression ( ( '<<' | '>>' ) additive_expression )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(437, 4);
			PushFollow(Follow._additive_expression_in_shift_expression1817);
			additive_expression248=additive_expression();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additive_expression248.Tree, additive_expression248, retval);
			DebugLocation(437, 24);
			// C.g:437:24: ( ( '<<' | '>>' ) additive_expression )*
			try { DebugEnterSubRule(62);
			while (true)
			{
				int alt62=2;
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
				switch ( alt62 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:437:25: ( '<<' | '>>' ) additive_expression
					{
					DebugLocation(437, 25);
					set249=(IToken)input.LT(1);
					if ((input.LA(1)>=87 && input.LA(1)<=88))
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set249, retval));
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(437, 37);
					PushFollow(Follow._additive_expression_in_shift_expression1826);
					additive_expression250=additive_expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additive_expression250.Tree, additive_expression250, retval);

					}
					break;

				default:
					goto loop62;
				}
			}

			loop62:
				;

			} finally { DebugExitSubRule(62); }


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
			TraceOut("shift_expression", 64);
			LeaveRule("shift_expression", 64);
			Leave_shift_expression();
			if (state.backtracking > 0) { Memoize(input, 64, shift_expression_StartIndex); }
		}
		DebugLocation(438, 1);
		} finally { DebugExitRule(GrammarFileName, "shift_expression"); }
		return retval;

	}
	// $ANTLR end "shift_expression"

	public class statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statement();
	partial void Leave_statement();

	// $ANTLR start "statement"
	// C.g:442:1: statement : ( labeled_statement | compound_statement | expression_statement | selection_statement | iteration_statement | jump_statement );
	[GrammarRule("statement")]
	public CParser.statement_return statement()
	{
		Enter_statement();
		EnterRule("statement", 65);
		TraceIn("statement", 65);
		CParser.statement_return retval = new CParser.statement_return();
		retval.Start = (IToken)input.LT(1);
		int statement_StartIndex = input.Index;
		object root_0 = null;

		CParser.labeled_statement_return labeled_statement251 = default(CParser.labeled_statement_return);
		CParser.compound_statement_return compound_statement252 = default(CParser.compound_statement_return);
		CParser.expression_statement_return expression_statement253 = default(CParser.expression_statement_return);
		CParser.selection_statement_return selection_statement254 = default(CParser.selection_statement_return);
		CParser.iteration_statement_return iteration_statement255 = default(CParser.iteration_statement_return);
		CParser.jump_statement_return jump_statement256 = default(CParser.jump_statement_return);


		try { DebugEnterRule(GrammarFileName, "statement");
		DebugLocation(442, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 65)) { return retval; }
			// C.g:443:2: ( labeled_statement | compound_statement | expression_statement | selection_statement | iteration_statement | jump_statement )
			int alt63=6;
			try { DebugEnterDecision(63, decisionCanBacktrack[63]);
			try
			{
				alt63 = dfa63.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(63); }
			switch (alt63)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:443:4: labeled_statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(443, 4);
				PushFollow(Follow._labeled_statement_in_statement1841);
				labeled_statement251=labeled_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, labeled_statement251.Tree, labeled_statement251, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:444:4: compound_statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(444, 4);
				PushFollow(Follow._compound_statement_in_statement1846);
				compound_statement252=compound_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, compound_statement252.Tree, compound_statement252, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:445:4: expression_statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(445, 4);
				PushFollow(Follow._expression_statement_in_statement1851);
				expression_statement253=expression_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression_statement253.Tree, expression_statement253, retval);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:446:4: selection_statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(446, 4);
				PushFollow(Follow._selection_statement_in_statement1856);
				selection_statement254=selection_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, selection_statement254.Tree, selection_statement254, retval);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C.g:447:4: iteration_statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(447, 4);
				PushFollow(Follow._iteration_statement_in_statement1861);
				iteration_statement255=iteration_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, iteration_statement255.Tree, iteration_statement255, retval);

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// C.g:448:4: jump_statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(448, 4);
				PushFollow(Follow._jump_statement_in_statement1866);
				jump_statement256=jump_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, jump_statement256.Tree, jump_statement256, retval);

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
			TraceOut("statement", 65);
			LeaveRule("statement", 65);
			Leave_statement();
			if (state.backtracking > 0) { Memoize(input, 65, statement_StartIndex); }
		}
		DebugLocation(449, 1);
		} finally { DebugExitRule(GrammarFileName, "statement"); }
		return retval;

	}
	// $ANTLR end "statement"

	public class labeled_statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_labeled_statement();
	partial void Leave_labeled_statement();

	// $ANTLR start "labeled_statement"
	// C.g:451:1: labeled_statement : ( IDENTIFIER ':' statement | 'case' constant_expression ':' statement | 'default' ':' statement );
	[GrammarRule("labeled_statement")]
	public CParser.labeled_statement_return labeled_statement()
	{
		Enter_labeled_statement();
		EnterRule("labeled_statement", 66);
		TraceIn("labeled_statement", 66);
		CParser.labeled_statement_return retval = new CParser.labeled_statement_return();
		retval.Start = (IToken)input.LT(1);
		int labeled_statement_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENTIFIER257=null;
		IToken char_literal258=null;
		IToken string_literal260=null;
		IToken char_literal262=null;
		IToken string_literal264=null;
		IToken char_literal265=null;
		CParser.statement_return statement259 = default(CParser.statement_return);
		CParser.constant_expression_return constant_expression261 = default(CParser.constant_expression_return);
		CParser.statement_return statement263 = default(CParser.statement_return);
		CParser.statement_return statement266 = default(CParser.statement_return);

		object IDENTIFIER257_tree=null;
		object char_literal258_tree=null;
		object string_literal260_tree=null;
		object char_literal262_tree=null;
		object string_literal264_tree=null;
		object char_literal265_tree=null;

		try { DebugEnterRule(GrammarFileName, "labeled_statement");
		DebugLocation(451, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 66)) { return retval; }
			// C.g:452:2: ( IDENTIFIER ':' statement | 'case' constant_expression ':' statement | 'default' ':' statement )
			int alt64=3;
			try { DebugEnterDecision(64, decisionCanBacktrack[64]);
			switch (input.LA(1))
			{
			case IDENTIFIER:
				{
				alt64=1;
				}
				break;
			case 89:
				{
				alt64=2;
				}
				break;
			case 90:
				{
				alt64=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 64, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(64); }
			switch (alt64)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:452:4: IDENTIFIER ':' statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(452, 4);
				IDENTIFIER257=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_labeled_statement1877), "IDENTIFIER"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENTIFIER257_tree = (object)adaptor.Create(IDENTIFIER257, retval);
				adaptor.AddChild(root_0, IDENTIFIER257_tree);
				}
				DebugLocation(452, 15);
				char_literal258=(IToken)Match(input,44,Follow._44_in_labeled_statement1879); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal258_tree = (object)adaptor.Create(char_literal258, retval);
				adaptor.AddChild(root_0, char_literal258_tree);
				}
				DebugLocation(452, 19);
				PushFollow(Follow._statement_in_labeled_statement1881);
				statement259=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement259.Tree, statement259, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:453:4: 'case' constant_expression ':' statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(453, 4);
				string_literal260=(IToken)Match(input,89,Follow._89_in_labeled_statement1886); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal260_tree = (object)adaptor.Create(string_literal260, retval);
				adaptor.AddChild(root_0, string_literal260_tree);
				}
				DebugLocation(453, 11);
				PushFollow(Follow._constant_expression_in_labeled_statement1888);
				constant_expression261=constant_expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression261.Tree, constant_expression261, retval);
				DebugLocation(453, 31);
				char_literal262=(IToken)Match(input,44,Follow._44_in_labeled_statement1890); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal262_tree = (object)adaptor.Create(char_literal262, retval);
				adaptor.AddChild(root_0, char_literal262_tree);
				}
				DebugLocation(453, 35);
				PushFollow(Follow._statement_in_labeled_statement1892);
				statement263=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement263.Tree, statement263, retval);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:454:4: 'default' ':' statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(454, 4);
				string_literal264=(IToken)Match(input,90,Follow._90_in_labeled_statement1897); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal264_tree = (object)adaptor.Create(string_literal264, retval);
				adaptor.AddChild(root_0, string_literal264_tree);
				}
				DebugLocation(454, 14);
				char_literal265=(IToken)Match(input,44,Follow._44_in_labeled_statement1899); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal265_tree = (object)adaptor.Create(char_literal265, retval);
				adaptor.AddChild(root_0, char_literal265_tree);
				}
				DebugLocation(454, 18);
				PushFollow(Follow._statement_in_labeled_statement1901);
				statement266=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement266.Tree, statement266, retval);

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
			TraceOut("labeled_statement", 66);
			LeaveRule("labeled_statement", 66);
			Leave_labeled_statement();
			if (state.backtracking > 0) { Memoize(input, 66, labeled_statement_StartIndex); }
		}
		DebugLocation(455, 1);
		} finally { DebugExitRule(GrammarFileName, "labeled_statement"); }
		return retval;

	}
	// $ANTLR end "labeled_statement"

	public class compound_statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_compound_statement();
	partial void Leave_compound_statement();

	// $ANTLR start "compound_statement"
	// C.g:457:1: compound_statement : '{' ( declaration )* ( statement_list )? '}' ;
	[GrammarRule("compound_statement")]
	public CParser.compound_statement_return compound_statement()
	{
		Enter_compound_statement();
		EnterRule("compound_statement", 67);
		TraceIn("compound_statement", 67);
		Symbols_stack.Push(new Symbols_scope());Symbols_scopeInit(Symbols_stack.Peek());

		CParser.compound_statement_return retval = new CParser.compound_statement_return();
		retval.Start = (IToken)input.LT(1);
		int compound_statement_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal267=null;
		IToken char_literal270=null;
		CParser.declaration_return declaration268 = default(CParser.declaration_return);
		CParser.statement_list_return statement_list269 = default(CParser.statement_list_return);

		object char_literal267_tree=null;
		object char_literal270_tree=null;


		  ((Symbols_scope)Symbols_stack.Peek()).types = new HashSet();

		try { DebugEnterRule(GrammarFileName, "compound_statement");
		DebugLocation(457, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 67)) { return retval; }
			// C.g:462:2: ( '{' ( declaration )* ( statement_list )? '}' )
			DebugEnterAlt(1);
			// C.g:462:4: '{' ( declaration )* ( statement_list )? '}'
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(462, 4);
			char_literal267=(IToken)Match(input,40,Follow._40_in_compound_statement1923); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal267_tree = (object)adaptor.Create(char_literal267, retval);
			adaptor.AddChild(root_0, char_literal267_tree);
			}
			DebugLocation(462, 8);
			// C.g:462:8: ( declaration )*
			try { DebugEnterSubRule(65);
			while (true)
			{
				int alt65=2;
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
				switch ( alt65 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: declaration
					{
					DebugLocation(462, 8);
					PushFollow(Follow._declaration_in_compound_statement1925);
					declaration268=declaration();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration268.Tree, declaration268, retval);

					}
					break;

				default:
					goto loop65;
				}
			}

			loop65:
				;

			} finally { DebugExitSubRule(65); }

			DebugLocation(462, 21);
			// C.g:462:21: ( statement_list )?
			int alt66=2;
			try { DebugEnterSubRule(66);
			try { DebugEnterDecision(66, decisionCanBacktrack[66]);
			try
			{
				alt66 = dfa66.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(66); }
			switch (alt66)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:0:0: statement_list
				{
				DebugLocation(462, 21);
				PushFollow(Follow._statement_list_in_compound_statement1928);
				statement_list269=statement_list();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement_list269.Tree, statement_list269, retval);

				}
				break;

			}
			} finally { DebugExitSubRule(66); }

			DebugLocation(462, 37);
			char_literal270=(IToken)Match(input,41,Follow._41_in_compound_statement1931); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			char_literal270_tree = (object)adaptor.Create(char_literal270, retval);
			adaptor.AddChild(root_0, char_literal270_tree);
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
			TraceOut("compound_statement", 67);
			LeaveRule("compound_statement", 67);
			Leave_compound_statement();
			if (state.backtracking > 0) { Memoize(input, 67, compound_statement_StartIndex); }
			Symbols_scopeAfter(Symbols_stack.Peek());Symbols_stack.Pop();

		}
		DebugLocation(463, 1);
		} finally { DebugExitRule(GrammarFileName, "compound_statement"); }
		return retval;

	}
	// $ANTLR end "compound_statement"

	public class statement_list_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_statement_list();
	partial void Leave_statement_list();

	// $ANTLR start "statement_list"
	// C.g:465:1: statement_list : ( statement )+ ;
	[GrammarRule("statement_list")]
	public CParser.statement_list_return statement_list()
	{
		Enter_statement_list();
		EnterRule("statement_list", 68);
		TraceIn("statement_list", 68);
		CParser.statement_list_return retval = new CParser.statement_list_return();
		retval.Start = (IToken)input.LT(1);
		int statement_list_StartIndex = input.Index;
		object root_0 = null;

		CParser.statement_return statement271 = default(CParser.statement_return);


		try { DebugEnterRule(GrammarFileName, "statement_list");
		DebugLocation(465, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 68)) { return retval; }
			// C.g:466:2: ( ( statement )+ )
			DebugEnterAlt(1);
			// C.g:466:4: ( statement )+
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(466, 4);
			// C.g:466:4: ( statement )+
			int cnt67=0;
			try { DebugEnterSubRule(67);
			while (true)
			{
				int alt67=2;
				try { DebugEnterDecision(67, decisionCanBacktrack[67]);
				try
				{
					alt67 = dfa67.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(67); }
				switch (alt67)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: statement
					{
					DebugLocation(466, 4);
					PushFollow(Follow._statement_in_statement_list1942);
					statement271=statement();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement271.Tree, statement271, retval);

					}
					break;

				default:
					if (cnt67 >= 1)
						goto loop67;

					if (state.backtracking>0) {state.failed=true; return retval;}
					EarlyExitException eee67 = new EarlyExitException( 67, input );
					DebugRecognitionException(eee67);
					throw eee67;
				}
				cnt67++;
			}
			loop67:
				;

			} finally { DebugExitSubRule(67); }


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
			TraceOut("statement_list", 68);
			LeaveRule("statement_list", 68);
			Leave_statement_list();
			if (state.backtracking > 0) { Memoize(input, 68, statement_list_StartIndex); }
		}
		DebugLocation(467, 1);
		} finally { DebugExitRule(GrammarFileName, "statement_list"); }
		return retval;

	}
	// $ANTLR end "statement_list"

	public class expression_statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expression_statement();
	partial void Leave_expression_statement();

	// $ANTLR start "expression_statement"
	// C.g:469:1: expression_statement : ( ';' | expression ';' );
	[GrammarRule("expression_statement")]
	public CParser.expression_statement_return expression_statement()
	{
		Enter_expression_statement();
		EnterRule("expression_statement", 69);
		TraceIn("expression_statement", 69);
		CParser.expression_statement_return retval = new CParser.expression_statement_return();
		retval.Start = (IToken)input.LT(1);
		int expression_statement_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal272=null;
		IToken char_literal274=null;
		CParser.expression_return expression273 = default(CParser.expression_return);

		object char_literal272_tree=null;
		object char_literal274_tree=null;

		try { DebugEnterRule(GrammarFileName, "expression_statement");
		DebugLocation(469, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 69)) { return retval; }
			// C.g:470:2: ( ';' | expression ';' )
			int alt68=2;
			try { DebugEnterDecision(68, decisionCanBacktrack[68]);
			try
			{
				alt68 = dfa68.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(68); }
			switch (alt68)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:470:4: ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(470, 4);
				char_literal272=(IToken)Match(input,24,Follow._24_in_expression_statement1954); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal272_tree = (object)adaptor.Create(char_literal272, retval);
				adaptor.AddChild(root_0, char_literal272_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:471:4: expression ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(471, 4);
				PushFollow(Follow._expression_in_expression_statement1959);
				expression273=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression273.Tree, expression273, retval);
				DebugLocation(471, 15);
				char_literal274=(IToken)Match(input,24,Follow._24_in_expression_statement1961); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal274_tree = (object)adaptor.Create(char_literal274, retval);
				adaptor.AddChild(root_0, char_literal274_tree);
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
			TraceOut("expression_statement", 69);
			LeaveRule("expression_statement", 69);
			Leave_expression_statement();
			if (state.backtracking > 0) { Memoize(input, 69, expression_statement_StartIndex); }
		}
		DebugLocation(472, 1);
		} finally { DebugExitRule(GrammarFileName, "expression_statement"); }
		return retval;

	}
	// $ANTLR end "expression_statement"

	public class selection_statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_selection_statement();
	partial void Leave_selection_statement();

	// $ANTLR start "selection_statement"
	// C.g:474:1: selection_statement : ( 'if' '(' expression ')' statement ( options {k=1; backtrack=false; } : 'else' statement )? | 'switch' '(' expression ')' statement );
	[GrammarRule("selection_statement")]
	public CParser.selection_statement_return selection_statement()
	{
		Enter_selection_statement();
		EnterRule("selection_statement", 70);
		TraceIn("selection_statement", 70);
		CParser.selection_statement_return retval = new CParser.selection_statement_return();
		retval.Start = (IToken)input.LT(1);
		int selection_statement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal275=null;
		IToken char_literal276=null;
		IToken char_literal278=null;
		IToken string_literal280=null;
		IToken string_literal282=null;
		IToken char_literal283=null;
		IToken char_literal285=null;
		CParser.expression_return expression277 = default(CParser.expression_return);
		CParser.statement_return statement279 = default(CParser.statement_return);
		CParser.statement_return statement281 = default(CParser.statement_return);
		CParser.expression_return expression284 = default(CParser.expression_return);
		CParser.statement_return statement286 = default(CParser.statement_return);

		object string_literal275_tree=null;
		object char_literal276_tree=null;
		object char_literal278_tree=null;
		object string_literal280_tree=null;
		object string_literal282_tree=null;
		object char_literal283_tree=null;
		object char_literal285_tree=null;

		try { DebugEnterRule(GrammarFileName, "selection_statement");
		DebugLocation(474, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 70)) { return retval; }
			// C.g:475:2: ( 'if' '(' expression ')' statement ( options {k=1; backtrack=false; } : 'else' statement )? | 'switch' '(' expression ')' statement )
			int alt70=2;
			try { DebugEnterDecision(70, decisionCanBacktrack[70]);
			int LA70_0 = input.LA(1);

			if ((LA70_0==91))
			{
				alt70=1;
			}
			else if ((LA70_0==93))
			{
				alt70=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 70, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(70); }
			switch (alt70)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:475:4: 'if' '(' expression ')' statement ( options {k=1; backtrack=false; } : 'else' statement )?
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(475, 4);
				string_literal275=(IToken)Match(input,91,Follow._91_in_selection_statement1972); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal275_tree = (object)adaptor.Create(string_literal275, retval);
				adaptor.AddChild(root_0, string_literal275_tree);
				}
				DebugLocation(475, 9);
				char_literal276=(IToken)Match(input,48,Follow._48_in_selection_statement1974); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal276_tree = (object)adaptor.Create(char_literal276, retval);
				adaptor.AddChild(root_0, char_literal276_tree);
				}
				DebugLocation(475, 13);
				PushFollow(Follow._expression_in_selection_statement1976);
				expression277=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression277.Tree, expression277, retval);
				DebugLocation(475, 24);
				char_literal278=(IToken)Match(input,49,Follow._49_in_selection_statement1978); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal278_tree = (object)adaptor.Create(char_literal278, retval);
				adaptor.AddChild(root_0, char_literal278_tree);
				}
				DebugLocation(475, 28);
				PushFollow(Follow._statement_in_selection_statement1980);
				statement279=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement279.Tree, statement279, retval);
				DebugLocation(475, 38);
				// C.g:475:38: ( options {k=1; backtrack=false; } : 'else' statement )?
				int alt69=2;
				try { DebugEnterSubRule(69);
				try { DebugEnterDecision(69, decisionCanBacktrack[69]);
				int LA69_0 = input.LA(1);

				if ((LA69_0==92))
				{
					int LA69_1 = input.LA(2);

					if ((true))
					{
						alt69=1;
					}
				}
				} finally { DebugExitDecision(69); }
				switch (alt69)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:475:71: 'else' statement
					{
					DebugLocation(475, 71);
					string_literal280=(IToken)Match(input,92,Follow._92_in_selection_statement1995); if (state.failed) return retval;
					if ( state.backtracking==0 ) {
					string_literal280_tree = (object)adaptor.Create(string_literal280, retval);
					adaptor.AddChild(root_0, string_literal280_tree);
					}
					DebugLocation(475, 78);
					PushFollow(Follow._statement_in_selection_statement1997);
					statement281=statement();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement281.Tree, statement281, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(69); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:476:4: 'switch' '(' expression ')' statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(476, 4);
				string_literal282=(IToken)Match(input,93,Follow._93_in_selection_statement2004); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal282_tree = (object)adaptor.Create(string_literal282, retval);
				adaptor.AddChild(root_0, string_literal282_tree);
				}
				DebugLocation(476, 13);
				char_literal283=(IToken)Match(input,48,Follow._48_in_selection_statement2006); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal283_tree = (object)adaptor.Create(char_literal283, retval);
				adaptor.AddChild(root_0, char_literal283_tree);
				}
				DebugLocation(476, 17);
				PushFollow(Follow._expression_in_selection_statement2008);
				expression284=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression284.Tree, expression284, retval);
				DebugLocation(476, 28);
				char_literal285=(IToken)Match(input,49,Follow._49_in_selection_statement2010); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal285_tree = (object)adaptor.Create(char_literal285, retval);
				adaptor.AddChild(root_0, char_literal285_tree);
				}
				DebugLocation(476, 32);
				PushFollow(Follow._statement_in_selection_statement2012);
				statement286=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement286.Tree, statement286, retval);

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
			TraceOut("selection_statement", 70);
			LeaveRule("selection_statement", 70);
			Leave_selection_statement();
			if (state.backtracking > 0) { Memoize(input, 70, selection_statement_StartIndex); }
		}
		DebugLocation(477, 1);
		} finally { DebugExitRule(GrammarFileName, "selection_statement"); }
		return retval;

	}
	// $ANTLR end "selection_statement"

	public class iteration_statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_iteration_statement();
	partial void Leave_iteration_statement();

	// $ANTLR start "iteration_statement"
	// C.g:479:1: iteration_statement : ( 'while' '(' expression ')' statement | 'do' statement 'while' '(' expression ')' ';' | 'for' '(' expression_statement expression_statement ( expression )? ')' statement );
	[GrammarRule("iteration_statement")]
	public CParser.iteration_statement_return iteration_statement()
	{
		Enter_iteration_statement();
		EnterRule("iteration_statement", 71);
		TraceIn("iteration_statement", 71);
		CParser.iteration_statement_return retval = new CParser.iteration_statement_return();
		retval.Start = (IToken)input.LT(1);
		int iteration_statement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal287=null;
		IToken char_literal288=null;
		IToken char_literal290=null;
		IToken string_literal292=null;
		IToken string_literal294=null;
		IToken char_literal295=null;
		IToken char_literal297=null;
		IToken char_literal298=null;
		IToken string_literal299=null;
		IToken char_literal300=null;
		IToken char_literal304=null;
		CParser.expression_return expression289 = default(CParser.expression_return);
		CParser.statement_return statement291 = default(CParser.statement_return);
		CParser.statement_return statement293 = default(CParser.statement_return);
		CParser.expression_return expression296 = default(CParser.expression_return);
		CParser.expression_statement_return expression_statement301 = default(CParser.expression_statement_return);
		CParser.expression_statement_return expression_statement302 = default(CParser.expression_statement_return);
		CParser.expression_return expression303 = default(CParser.expression_return);
		CParser.statement_return statement305 = default(CParser.statement_return);

		object string_literal287_tree=null;
		object char_literal288_tree=null;
		object char_literal290_tree=null;
		object string_literal292_tree=null;
		object string_literal294_tree=null;
		object char_literal295_tree=null;
		object char_literal297_tree=null;
		object char_literal298_tree=null;
		object string_literal299_tree=null;
		object char_literal300_tree=null;
		object char_literal304_tree=null;

		try { DebugEnterRule(GrammarFileName, "iteration_statement");
		DebugLocation(479, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 71)) { return retval; }
			// C.g:480:2: ( 'while' '(' expression ')' statement | 'do' statement 'while' '(' expression ')' ';' | 'for' '(' expression_statement expression_statement ( expression )? ')' statement )
			int alt72=3;
			try { DebugEnterDecision(72, decisionCanBacktrack[72]);
			switch (input.LA(1))
			{
			case 94:
				{
				alt72=1;
				}
				break;
			case 95:
				{
				alt72=2;
				}
				break;
			case 96:
				{
				alt72=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 72, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(72); }
			switch (alt72)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:480:4: 'while' '(' expression ')' statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(480, 4);
				string_literal287=(IToken)Match(input,94,Follow._94_in_iteration_statement2023); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal287_tree = (object)adaptor.Create(string_literal287, retval);
				adaptor.AddChild(root_0, string_literal287_tree);
				}
				DebugLocation(480, 12);
				char_literal288=(IToken)Match(input,48,Follow._48_in_iteration_statement2025); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal288_tree = (object)adaptor.Create(char_literal288, retval);
				adaptor.AddChild(root_0, char_literal288_tree);
				}
				DebugLocation(480, 16);
				PushFollow(Follow._expression_in_iteration_statement2027);
				expression289=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression289.Tree, expression289, retval);
				DebugLocation(480, 27);
				char_literal290=(IToken)Match(input,49,Follow._49_in_iteration_statement2029); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal290_tree = (object)adaptor.Create(char_literal290, retval);
				adaptor.AddChild(root_0, char_literal290_tree);
				}
				DebugLocation(480, 31);
				PushFollow(Follow._statement_in_iteration_statement2031);
				statement291=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement291.Tree, statement291, retval);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:481:4: 'do' statement 'while' '(' expression ')' ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(481, 4);
				string_literal292=(IToken)Match(input,95,Follow._95_in_iteration_statement2036); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal292_tree = (object)adaptor.Create(string_literal292, retval);
				adaptor.AddChild(root_0, string_literal292_tree);
				}
				DebugLocation(481, 9);
				PushFollow(Follow._statement_in_iteration_statement2038);
				statement293=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement293.Tree, statement293, retval);
				DebugLocation(481, 19);
				string_literal294=(IToken)Match(input,94,Follow._94_in_iteration_statement2040); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal294_tree = (object)adaptor.Create(string_literal294, retval);
				adaptor.AddChild(root_0, string_literal294_tree);
				}
				DebugLocation(481, 27);
				char_literal295=(IToken)Match(input,48,Follow._48_in_iteration_statement2042); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal295_tree = (object)adaptor.Create(char_literal295, retval);
				adaptor.AddChild(root_0, char_literal295_tree);
				}
				DebugLocation(481, 31);
				PushFollow(Follow._expression_in_iteration_statement2044);
				expression296=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression296.Tree, expression296, retval);
				DebugLocation(481, 42);
				char_literal297=(IToken)Match(input,49,Follow._49_in_iteration_statement2046); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal297_tree = (object)adaptor.Create(char_literal297, retval);
				adaptor.AddChild(root_0, char_literal297_tree);
				}
				DebugLocation(481, 46);
				char_literal298=(IToken)Match(input,24,Follow._24_in_iteration_statement2048); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal298_tree = (object)adaptor.Create(char_literal298, retval);
				adaptor.AddChild(root_0, char_literal298_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:482:4: 'for' '(' expression_statement expression_statement ( expression )? ')' statement
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(482, 4);
				string_literal299=(IToken)Match(input,96,Follow._96_in_iteration_statement2053); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal299_tree = (object)adaptor.Create(string_literal299, retval);
				adaptor.AddChild(root_0, string_literal299_tree);
				}
				DebugLocation(482, 10);
				char_literal300=(IToken)Match(input,48,Follow._48_in_iteration_statement2055); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal300_tree = (object)adaptor.Create(char_literal300, retval);
				adaptor.AddChild(root_0, char_literal300_tree);
				}
				DebugLocation(482, 14);
				PushFollow(Follow._expression_statement_in_iteration_statement2057);
				expression_statement301=expression_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression_statement301.Tree, expression_statement301, retval);
				DebugLocation(482, 35);
				PushFollow(Follow._expression_statement_in_iteration_statement2059);
				expression_statement302=expression_statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression_statement302.Tree, expression_statement302, retval);
				DebugLocation(482, 56);
				// C.g:482:56: ( expression )?
				int alt71=2;
				try { DebugEnterSubRule(71);
				try { DebugEnterDecision(71, decisionCanBacktrack[71]);
				try
				{
					alt71 = dfa71.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(71); }
				switch (alt71)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: expression
					{
					DebugLocation(482, 56);
					PushFollow(Follow._expression_in_iteration_statement2061);
					expression303=expression();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression303.Tree, expression303, retval);

					}
					break;

				}
				} finally { DebugExitSubRule(71); }

				DebugLocation(482, 68);
				char_literal304=(IToken)Match(input,49,Follow._49_in_iteration_statement2064); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal304_tree = (object)adaptor.Create(char_literal304, retval);
				adaptor.AddChild(root_0, char_literal304_tree);
				}
				DebugLocation(482, 72);
				PushFollow(Follow._statement_in_iteration_statement2066);
				statement305=statement();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement305.Tree, statement305, retval);

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
			TraceOut("iteration_statement", 71);
			LeaveRule("iteration_statement", 71);
			Leave_iteration_statement();
			if (state.backtracking > 0) { Memoize(input, 71, iteration_statement_StartIndex); }
		}
		DebugLocation(483, 1);
		} finally { DebugExitRule(GrammarFileName, "iteration_statement"); }
		return retval;

	}
	// $ANTLR end "iteration_statement"

	public class jump_statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_jump_statement();
	partial void Leave_jump_statement();

	// $ANTLR start "jump_statement"
	// C.g:485:1: jump_statement : ( 'goto' IDENTIFIER ';' | 'continue' ';' | 'break' ';' | 'return' ';' | 'return' expression ';' );
	[GrammarRule("jump_statement")]
	public CParser.jump_statement_return jump_statement()
	{
		Enter_jump_statement();
		EnterRule("jump_statement", 72);
		TraceIn("jump_statement", 72);
		CParser.jump_statement_return retval = new CParser.jump_statement_return();
		retval.Start = (IToken)input.LT(1);
		int jump_statement_StartIndex = input.Index;
		object root_0 = null;

		IToken string_literal306=null;
		IToken IDENTIFIER307=null;
		IToken char_literal308=null;
		IToken string_literal309=null;
		IToken char_literal310=null;
		IToken string_literal311=null;
		IToken char_literal312=null;
		IToken string_literal313=null;
		IToken char_literal314=null;
		IToken string_literal315=null;
		IToken char_literal317=null;
		CParser.expression_return expression316 = default(CParser.expression_return);

		object string_literal306_tree=null;
		object IDENTIFIER307_tree=null;
		object char_literal308_tree=null;
		object string_literal309_tree=null;
		object char_literal310_tree=null;
		object string_literal311_tree=null;
		object char_literal312_tree=null;
		object string_literal313_tree=null;
		object char_literal314_tree=null;
		object string_literal315_tree=null;
		object char_literal317_tree=null;

		try { DebugEnterRule(GrammarFileName, "jump_statement");
		DebugLocation(485, 1);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 72)) { return retval; }
			// C.g:486:2: ( 'goto' IDENTIFIER ';' | 'continue' ';' | 'break' ';' | 'return' ';' | 'return' expression ';' )
			int alt73=5;
			try { DebugEnterDecision(73, decisionCanBacktrack[73]);
			try
			{
				alt73 = dfa73.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(73); }
			switch (alt73)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:486:4: 'goto' IDENTIFIER ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(486, 4);
				string_literal306=(IToken)Match(input,97,Follow._97_in_jump_statement2077); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal306_tree = (object)adaptor.Create(string_literal306, retval);
				adaptor.AddChild(root_0, string_literal306_tree);
				}
				DebugLocation(486, 11);
				IDENTIFIER307=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_jump_statement2079), "IDENTIFIER"); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENTIFIER307_tree = (object)adaptor.Create(IDENTIFIER307, retval);
				adaptor.AddChild(root_0, IDENTIFIER307_tree);
				}
				DebugLocation(486, 22);
				char_literal308=(IToken)Match(input,24,Follow._24_in_jump_statement2081); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal308_tree = (object)adaptor.Create(char_literal308, retval);
				adaptor.AddChild(root_0, char_literal308_tree);
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C.g:487:4: 'continue' ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(487, 4);
				string_literal309=(IToken)Match(input,98,Follow._98_in_jump_statement2086); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal309_tree = (object)adaptor.Create(string_literal309, retval);
				adaptor.AddChild(root_0, string_literal309_tree);
				}
				DebugLocation(487, 15);
				char_literal310=(IToken)Match(input,24,Follow._24_in_jump_statement2088); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal310_tree = (object)adaptor.Create(char_literal310, retval);
				adaptor.AddChild(root_0, char_literal310_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C.g:488:4: 'break' ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(488, 4);
				string_literal311=(IToken)Match(input,99,Follow._99_in_jump_statement2093); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal311_tree = (object)adaptor.Create(string_literal311, retval);
				adaptor.AddChild(root_0, string_literal311_tree);
				}
				DebugLocation(488, 12);
				char_literal312=(IToken)Match(input,24,Follow._24_in_jump_statement2095); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal312_tree = (object)adaptor.Create(char_literal312, retval);
				adaptor.AddChild(root_0, char_literal312_tree);
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C.g:489:4: 'return' ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(489, 4);
				string_literal313=(IToken)Match(input,100,Follow._100_in_jump_statement2100); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal313_tree = (object)adaptor.Create(string_literal313, retval);
				adaptor.AddChild(root_0, string_literal313_tree);
				}
				DebugLocation(489, 13);
				char_literal314=(IToken)Match(input,24,Follow._24_in_jump_statement2102); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal314_tree = (object)adaptor.Create(char_literal314, retval);
				adaptor.AddChild(root_0, char_literal314_tree);
				}

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C.g:490:4: 'return' expression ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(490, 4);
				string_literal315=(IToken)Match(input,100,Follow._100_in_jump_statement2107); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				string_literal315_tree = (object)adaptor.Create(string_literal315, retval);
				adaptor.AddChild(root_0, string_literal315_tree);
				}
				DebugLocation(490, 13);
				PushFollow(Follow._expression_in_jump_statement2109);
				expression316=expression();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression316.Tree, expression316, retval);
				DebugLocation(490, 24);
				char_literal317=(IToken)Match(input,24,Follow._24_in_jump_statement2111); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				char_literal317_tree = (object)adaptor.Create(char_literal317, retval);
				adaptor.AddChild(root_0, char_literal317_tree);
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
			TraceOut("jump_statement", 72);
			LeaveRule("jump_statement", 72);
			Leave_jump_statement();
			if (state.backtracking > 0) { Memoize(input, 72, jump_statement_StartIndex); }
		}
		DebugLocation(491, 1);
		} finally { DebugExitRule(GrammarFileName, "jump_statement"); }
		return retval;

	}
	// $ANTLR end "jump_statement"

	partial void Enter_synpred2_C_fragment();
	partial void Leave_synpred2_C_fragment();

	// $ANTLR start synpred2_C
	public void synpred2_C_fragment()
	{
		Enter_synpred2_C_fragment();
		EnterRule("synpred2_C_fragment", 74);
		TraceIn("synpred2_C_fragment", 74);
		try
		{
			// C.g:82:6: ( declaration_specifiers )
			DebugEnterAlt(1);
			// C.g:82:6: declaration_specifiers
			{
			DebugLocation(82, 6);
			PushFollow(Follow._declaration_specifiers_in_synpred2_C109);
			declaration_specifiers();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred2_C_fragment", 74);
			LeaveRule("synpred2_C_fragment", 74);
			Leave_synpred2_C_fragment();
		}
	}
	// $ANTLR end synpred2_C

	partial void Enter_synpred4_C_fragment();
	partial void Leave_synpred4_C_fragment();

	// $ANTLR start synpred4_C
	public void synpred4_C_fragment()
	{
		Enter_synpred4_C_fragment();
		EnterRule("synpred4_C_fragment", 76);
		TraceIn("synpred4_C_fragment", 76);
		try
		{
			// C.g:82:4: ( ( declaration_specifiers )? declarator ( declaration )* '{' )
			DebugEnterAlt(1);
			// C.g:82:6: ( declaration_specifiers )? declarator ( declaration )* '{'
			{
			DebugLocation(82, 6);
			// C.g:82:6: ( declaration_specifiers )?
			int alt74=2;
			try { DebugEnterSubRule(74);
			try { DebugEnterDecision(74, decisionCanBacktrack[74]);
			try
			{
				alt74 = dfa74.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(74); }
			switch (alt74)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:0:0: declaration_specifiers
				{
				DebugLocation(82, 6);
				PushFollow(Follow._declaration_specifiers_in_synpred4_C109);
				declaration_specifiers();
				PopFollow();
				if (state.failed) return;

				}
				break;

			}
			} finally { DebugExitSubRule(74); }

			DebugLocation(82, 30);
			PushFollow(Follow._declarator_in_synpred4_C112);
			declarator();
			PopFollow();
			if (state.failed) return;
			DebugLocation(82, 41);
			// C.g:82:41: ( declaration )*
			try { DebugEnterSubRule(75);
			while (true)
			{
				int alt75=2;
				try { DebugEnterDecision(75, decisionCanBacktrack[75]);
				try
				{
					alt75 = dfa75.Predict(input);
				}
				catch (NoViableAltException nvae)
				{
					DebugRecognitionException(nvae);
					throw;
				}
				} finally { DebugExitDecision(75); }
				switch ( alt75 )
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: declaration
					{
					DebugLocation(82, 41);
					PushFollow(Follow._declaration_in_synpred4_C114);
					declaration();
					PopFollow();
					if (state.failed) return;

					}
					break;

				default:
					goto loop75;
				}
			}

			loop75:
				;

			} finally { DebugExitSubRule(75); }

			DebugLocation(82, 54);
			Match(input,40,Follow._40_in_synpred4_C117); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred4_C_fragment", 76);
			LeaveRule("synpred4_C_fragment", 76);
			Leave_synpred4_C_fragment();
		}
	}
	// $ANTLR end synpred4_C

	partial void Enter_synpred5_C_fragment();
	partial void Leave_synpred5_C_fragment();

	// $ANTLR start synpred5_C
	public void synpred5_C_fragment()
	{
		Enter_synpred5_C_fragment();
		EnterRule("synpred5_C_fragment", 77);
		TraceIn("synpred5_C_fragment", 77);
		try
		{
			// C.g:91:4: ( declaration_specifiers )
			DebugEnterAlt(1);
			// C.g:91:4: declaration_specifiers
			{
			DebugLocation(91, 4);
			PushFollow(Follow._declaration_specifiers_in_synpred5_C149);
			declaration_specifiers();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred5_C_fragment", 77);
			LeaveRule("synpred5_C_fragment", 77);
			Leave_synpred5_C_fragment();
		}
	}
	// $ANTLR end synpred5_C

	partial void Enter_synpred8_C_fragment();
	partial void Leave_synpred8_C_fragment();

	// $ANTLR start synpred8_C
	public void synpred8_C_fragment()
	{
		Enter_synpred8_C_fragment();
		EnterRule("synpred8_C_fragment", 80);
		TraceIn("synpred8_C_fragment", 80);
		try
		{
			// C.g:104:14: ( declaration_specifiers )
			DebugEnterAlt(1);
			// C.g:104:14: declaration_specifiers
			{
			DebugLocation(104, 14);
			PushFollow(Follow._declaration_specifiers_in_synpred8_C198);
			declaration_specifiers();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred8_C_fragment", 80);
			LeaveRule("synpred8_C_fragment", 80);
			Leave_synpred8_C_fragment();
		}
	}
	// $ANTLR end synpred8_C

	partial void Enter_synpred12_C_fragment();
	partial void Leave_synpred12_C_fragment();

	// $ANTLR start synpred12_C
	public void synpred12_C_fragment()
	{
		Enter_synpred12_C_fragment();
		EnterRule("synpred12_C_fragment", 84);
		TraceIn("synpred12_C_fragment", 84);
		try
		{
			// C.g:111:7: ( type_specifier )
			DebugEnterAlt(1);
			// C.g:111:7: type_specifier
			{
			DebugLocation(111, 7);
			PushFollow(Follow._type_specifier_in_synpred12_C244);
			type_specifier();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred12_C_fragment", 84);
			LeaveRule("synpred12_C_fragment", 84);
			Leave_synpred12_C_fragment();
		}
	}
	// $ANTLR end synpred12_C

	partial void Enter_synpred35_C_fragment();
	partial void Leave_synpred35_C_fragment();

	// $ANTLR start synpred35_C
	public void synpred35_C_fragment()
	{
		Enter_synpred35_C_fragment();
		EnterRule("synpred35_C_fragment", 107);
		TraceIn("synpred35_C_fragment", 107);
		try
		{
			// C.g:175:23: ( type_specifier )
			DebugEnterAlt(1);
			// C.g:175:23: type_specifier
			{
			DebugLocation(175, 23);
			PushFollow(Follow._type_specifier_in_synpred35_C524);
			type_specifier();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred35_C_fragment", 107);
			LeaveRule("synpred35_C_fragment", 107);
			Leave_synpred35_C_fragment();
		}
	}
	// $ANTLR end synpred35_C

	partial void Enter_synpred45_C_fragment();
	partial void Leave_synpred45_C_fragment();

	// $ANTLR start synpred45_C
	public void synpred45_C_fragment()
	{
		Enter_synpred45_C_fragment();
		EnterRule("synpred45_C_fragment", 117);
		TraceIn("synpred45_C_fragment", 117);
		try
		{
			// C.g:208:4: ( ( pointer )? direct_declarator )
			DebugEnterAlt(1);
			// C.g:208:4: ( pointer )? direct_declarator
			{
			DebugLocation(208, 4);
			// C.g:208:4: ( pointer )?
			int alt80=2;
			try { DebugEnterSubRule(80);
			try { DebugEnterDecision(80, decisionCanBacktrack[80]);
			int LA80_0 = input.LA(1);

			if ((LA80_0==52))
			{
				alt80=1;
			}
			} finally { DebugExitDecision(80); }
			switch (alt80)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:0:0: pointer
				{
				DebugLocation(208, 4);
				PushFollow(Follow._pointer_in_synpred45_C677);
				pointer();
				PopFollow();
				if (state.failed) return;

				}
				break;

			}
			} finally { DebugExitSubRule(80); }

			DebugLocation(208, 13);
			PushFollow(Follow._direct_declarator_in_synpred45_C680);
			direct_declarator();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred45_C_fragment", 117);
			LeaveRule("synpred45_C_fragment", 117);
			Leave_synpred45_C_fragment();
		}
	}
	// $ANTLR end synpred45_C

	partial void Enter_synpred47_C_fragment();
	partial void Leave_synpred47_C_fragment();

	// $ANTLR start synpred47_C
	public void synpred47_C_fragment()
	{
		Enter_synpred47_C_fragment();
		EnterRule("synpred47_C_fragment", 119);
		TraceIn("synpred47_C_fragment", 119);
		try
		{
			// C.g:222:9: ( declarator_suffix )
			DebugEnterAlt(1);
			// C.g:222:9: declarator_suffix
			{
			DebugLocation(222, 9);
			PushFollow(Follow._declarator_suffix_in_synpred47_C729);
			declarator_suffix();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred47_C_fragment", 119);
			LeaveRule("synpred47_C_fragment", 119);
			Leave_synpred47_C_fragment();
		}
	}
	// $ANTLR end synpred47_C

	partial void Enter_synpred50_C_fragment();
	partial void Leave_synpred50_C_fragment();

	// $ANTLR start synpred50_C
	public void synpred50_C_fragment()
	{
		Enter_synpred50_C_fragment();
		EnterRule("synpred50_C_fragment", 122);
		TraceIn("synpred50_C_fragment", 122);
		try
		{
			// C.g:228:9: ( '(' parameter_type_list ')' )
			DebugEnterAlt(1);
			// C.g:228:9: '(' parameter_type_list ')'
			{
			DebugLocation(228, 9);
			Match(input,48,Follow._48_in_synpred50_C769); if (state.failed) return;
			DebugLocation(228, 13);
			PushFollow(Follow._parameter_type_list_in_synpred50_C771);
			parameter_type_list();
			PopFollow();
			if (state.failed) return;
			DebugLocation(228, 33);
			Match(input,49,Follow._49_in_synpred50_C773); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred50_C_fragment", 122);
			LeaveRule("synpred50_C_fragment", 122);
			Leave_synpred50_C_fragment();
		}
	}
	// $ANTLR end synpred50_C

	partial void Enter_synpred51_C_fragment();
	partial void Leave_synpred51_C_fragment();

	// $ANTLR start synpred51_C
	public void synpred51_C_fragment()
	{
		Enter_synpred51_C_fragment();
		EnterRule("synpred51_C_fragment", 123);
		TraceIn("synpred51_C_fragment", 123);
		try
		{
			// C.g:229:9: ( '(' identifier_list ')' )
			DebugEnterAlt(1);
			// C.g:229:9: '(' identifier_list ')'
			{
			DebugLocation(229, 9);
			Match(input,48,Follow._48_in_synpred51_C783); if (state.failed) return;
			DebugLocation(229, 13);
			PushFollow(Follow._identifier_list_in_synpred51_C785);
			identifier_list();
			PopFollow();
			if (state.failed) return;
			DebugLocation(229, 29);
			Match(input,49,Follow._49_in_synpred51_C787); if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred51_C_fragment", 123);
			LeaveRule("synpred51_C_fragment", 123);
			Leave_synpred51_C_fragment();
		}
	}
	// $ANTLR end synpred51_C

	partial void Enter_synpred52_C_fragment();
	partial void Leave_synpred52_C_fragment();

	// $ANTLR start synpred52_C
	public void synpred52_C_fragment()
	{
		Enter_synpred52_C_fragment();
		EnterRule("synpred52_C_fragment", 124);
		TraceIn("synpred52_C_fragment", 124);
		try
		{
			// C.g:234:8: ( type_qualifier )
			DebugEnterAlt(1);
			// C.g:234:8: type_qualifier
			{
			DebugLocation(234, 8);
			PushFollow(Follow._type_qualifier_in_synpred52_C812);
			type_qualifier();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred52_C_fragment", 124);
			LeaveRule("synpred52_C_fragment", 124);
			Leave_synpred52_C_fragment();
		}
	}
	// $ANTLR end synpred52_C

	partial void Enter_synpred53_C_fragment();
	partial void Leave_synpred53_C_fragment();

	// $ANTLR start synpred53_C
	public void synpred53_C_fragment()
	{
		Enter_synpred53_C_fragment();
		EnterRule("synpred53_C_fragment", 125);
		TraceIn("synpred53_C_fragment", 125);
		try
		{
			// C.g:234:24: ( pointer )
			DebugEnterAlt(1);
			// C.g:234:24: pointer
			{
			DebugLocation(234, 24);
			PushFollow(Follow._pointer_in_synpred53_C815);
			pointer();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred53_C_fragment", 125);
			LeaveRule("synpred53_C_fragment", 125);
			Leave_synpred53_C_fragment();
		}
	}
	// $ANTLR end synpred53_C

	partial void Enter_synpred54_C_fragment();
	partial void Leave_synpred54_C_fragment();

	// $ANTLR start synpred54_C
	public void synpred54_C_fragment()
	{
		Enter_synpred54_C_fragment();
		EnterRule("synpred54_C_fragment", 126);
		TraceIn("synpred54_C_fragment", 126);
		try
		{
			// C.g:234:4: ( '*' ( type_qualifier )+ ( pointer )? )
			DebugEnterAlt(1);
			// C.g:234:4: '*' ( type_qualifier )+ ( pointer )?
			{
			DebugLocation(234, 4);
			Match(input,52,Follow._52_in_synpred54_C810); if (state.failed) return;
			DebugLocation(234, 8);
			// C.g:234:8: ( type_qualifier )+
			int cnt81=0;
			try { DebugEnterSubRule(81);
			while (true)
			{
				int alt81=2;
				try { DebugEnterDecision(81, decisionCanBacktrack[81]);
				int LA81_0 = input.LA(1);

				if (((LA81_0>=46 && LA81_0<=47)))
				{
					alt81=1;
				}


				} finally { DebugExitDecision(81); }
				switch (alt81)
				{
				case 1:
					DebugEnterAlt(1);
					// C.g:0:0: type_qualifier
					{
					DebugLocation(234, 8);
					PushFollow(Follow._type_qualifier_in_synpred54_C812);
					type_qualifier();
					PopFollow();
					if (state.failed) return;

					}
					break;

				default:
					if (cnt81 >= 1)
						goto loop81;

					if (state.backtracking>0) {state.failed=true; return;}
					EarlyExitException eee81 = new EarlyExitException( 81, input );
					DebugRecognitionException(eee81);
					throw eee81;
				}
				cnt81++;
			}
			loop81:
				;

			} finally { DebugExitSubRule(81); }

			DebugLocation(234, 24);
			// C.g:234:24: ( pointer )?
			int alt82=2;
			try { DebugEnterSubRule(82);
			try { DebugEnterDecision(82, decisionCanBacktrack[82]);
			int LA82_0 = input.LA(1);

			if ((LA82_0==52))
			{
				alt82=1;
			}
			} finally { DebugExitDecision(82); }
			switch (alt82)
			{
			case 1:
				DebugEnterAlt(1);
				// C.g:0:0: pointer
				{
				DebugLocation(234, 24);
				PushFollow(Follow._pointer_in_synpred54_C815);
				pointer();
				PopFollow();
				if (state.failed) return;

				}
				break;

			}
			} finally { DebugExitSubRule(82); }


			}

		}
		finally
		{
			TraceOut("synpred54_C_fragment", 126);
			LeaveRule("synpred54_C_fragment", 126);
			Leave_synpred54_C_fragment();
		}
	}
	// $ANTLR end synpred54_C

	partial void Enter_synpred55_C_fragment();
	partial void Leave_synpred55_C_fragment();

	// $ANTLR start synpred55_C
	public void synpred55_C_fragment()
	{
		Enter_synpred55_C_fragment();
		EnterRule("synpred55_C_fragment", 127);
		TraceIn("synpred55_C_fragment", 127);
		try
		{
			// C.g:235:4: ( '*' pointer )
			DebugEnterAlt(1);
			// C.g:235:4: '*' pointer
			{
			DebugLocation(235, 4);
			Match(input,52,Follow._52_in_synpred55_C821); if (state.failed) return;
			DebugLocation(235, 8);
			PushFollow(Follow._pointer_in_synpred55_C823);
			pointer();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred55_C_fragment", 127);
			LeaveRule("synpred55_C_fragment", 127);
			Leave_synpred55_C_fragment();
		}
	}
	// $ANTLR end synpred55_C

	partial void Enter_synpred58_C_fragment();
	partial void Leave_synpred58_C_fragment();

	// $ANTLR start synpred58_C
	public void synpred58_C_fragment()
	{
		Enter_synpred58_C_fragment();
		EnterRule("synpred58_C_fragment", 130);
		TraceIn("synpred58_C_fragment", 130);
		try
		{
			// C.g:248:28: ( declarator )
			DebugEnterAlt(1);
			// C.g:248:28: declarator
			{
			DebugLocation(248, 28);
			PushFollow(Follow._declarator_in_synpred58_C878);
			declarator();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred58_C_fragment", 130);
			LeaveRule("synpred58_C_fragment", 130);
			Leave_synpred58_C_fragment();
		}
	}
	// $ANTLR end synpred58_C

	partial void Enter_synpred59_C_fragment();
	partial void Leave_synpred59_C_fragment();

	// $ANTLR start synpred59_C
	public void synpred59_C_fragment()
	{
		Enter_synpred59_C_fragment();
		EnterRule("synpred59_C_fragment", 131);
		TraceIn("synpred59_C_fragment", 131);
		try
		{
			// C.g:248:39: ( abstract_declarator )
			DebugEnterAlt(1);
			// C.g:248:39: abstract_declarator
			{
			DebugLocation(248, 39);
			PushFollow(Follow._abstract_declarator_in_synpred59_C880);
			abstract_declarator();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred59_C_fragment", 131);
			LeaveRule("synpred59_C_fragment", 131);
			Leave_synpred59_C_fragment();
		}
	}
	// $ANTLR end synpred59_C

	partial void Enter_synpred62_C_fragment();
	partial void Leave_synpred62_C_fragment();

	// $ANTLR start synpred62_C
	public void synpred62_C_fragment()
	{
		Enter_synpred62_C_fragment();
		EnterRule("synpred62_C_fragment", 134);
		TraceIn("synpred62_C_fragment", 134);
		try
		{
			// C.g:260:12: ( direct_abstract_declarator )
			DebugEnterAlt(1);
			// C.g:260:12: direct_abstract_declarator
			{
			DebugLocation(260, 12);
			PushFollow(Follow._direct_abstract_declarator_in_synpred62_C927);
			direct_abstract_declarator();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred62_C_fragment", 134);
			LeaveRule("synpred62_C_fragment", 134);
			Leave_synpred62_C_fragment();
		}
	}
	// $ANTLR end synpred62_C

	partial void Enter_synpred65_C_fragment();
	partial void Leave_synpred65_C_fragment();

	// $ANTLR start synpred65_C
	public void synpred65_C_fragment()
	{
		Enter_synpred65_C_fragment();
		EnterRule("synpred65_C_fragment", 137);
		TraceIn("synpred65_C_fragment", 137);
		try
		{
			// C.g:265:65: ( abstract_declarator_suffix )
			DebugEnterAlt(1);
			// C.g:265:65: abstract_declarator_suffix
			{
			DebugLocation(265, 65);
			PushFollow(Follow._abstract_declarator_suffix_in_synpred65_C958);
			abstract_declarator_suffix();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred65_C_fragment", 137);
			LeaveRule("synpred65_C_fragment", 137);
			Leave_synpred65_C_fragment();
		}
	}
	// $ANTLR end synpred65_C

	partial void Enter_synpred78_C_fragment();
	partial void Leave_synpred78_C_fragment();

	// $ANTLR start synpred78_C
	public void synpred78_C_fragment()
	{
		Enter_synpred78_C_fragment();
		EnterRule("synpred78_C_fragment", 150);
		TraceIn("synpred78_C_fragment", 150);
		try
		{
			// C.g:299:4: ( '(' type_name ')' cast_expression )
			DebugEnterAlt(1);
			// C.g:299:4: '(' type_name ')' cast_expression
			{
			DebugLocation(299, 4);
			Match(input,48,Follow._48_in_synpred78_C1130); if (state.failed) return;
			DebugLocation(299, 8);
			PushFollow(Follow._type_name_in_synpred78_C1132);
			type_name();
			PopFollow();
			if (state.failed) return;
			DebugLocation(299, 18);
			Match(input,49,Follow._49_in_synpred78_C1134); if (state.failed) return;
			DebugLocation(299, 22);
			PushFollow(Follow._cast_expression_in_synpred78_C1136);
			cast_expression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred78_C_fragment", 150);
			LeaveRule("synpred78_C_fragment", 150);
			Leave_synpred78_C_fragment();
		}
	}
	// $ANTLR end synpred78_C

	partial void Enter_synpred83_C_fragment();
	partial void Leave_synpred83_C_fragment();

	// $ANTLR start synpred83_C
	public void synpred83_C_fragment()
	{
		Enter_synpred83_C_fragment();
		EnterRule("synpred83_C_fragment", 155);
		TraceIn("synpred83_C_fragment", 155);
		try
		{
			// C.g:308:4: ( 'sizeof' unary_expression )
			DebugEnterAlt(1);
			// C.g:308:4: 'sizeof' unary_expression
			{
			DebugLocation(308, 4);
			Match(input,60,Follow._60_in_synpred83_C1178); if (state.failed) return;
			DebugLocation(308, 13);
			PushFollow(Follow._unary_expression_in_synpred83_C1180);
			unary_expression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred83_C_fragment", 155);
			LeaveRule("synpred83_C_fragment", 155);
			Leave_synpred83_C_fragment();
		}
	}
	// $ANTLR end synpred83_C

	partial void Enter_synpred104_C_fragment();
	partial void Leave_synpred104_C_fragment();

	// $ANTLR start synpred104_C
	public void synpred104_C_fragment()
	{
		Enter_synpred104_C_fragment();
		EnterRule("synpred104_C_fragment", 176);
		TraceIn("synpred104_C_fragment", 176);
		try
		{
			// C.g:383:4: ( lvalue assignment_operator assignment_expression )
			DebugEnterAlt(1);
			// C.g:383:4: lvalue assignment_operator assignment_expression
			{
			DebugLocation(383, 4);
			PushFollow(Follow._lvalue_in_synpred104_C1565);
			lvalue();
			PopFollow();
			if (state.failed) return;
			DebugLocation(383, 11);
			PushFollow(Follow._assignment_operator_in_synpred104_C1567);
			assignment_operator();
			PopFollow();
			if (state.failed) return;
			DebugLocation(383, 31);
			PushFollow(Follow._assignment_expression_in_synpred104_C1569);
			assignment_expression();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred104_C_fragment", 176);
			LeaveRule("synpred104_C_fragment", 176);
			Leave_synpred104_C_fragment();
		}
	}
	// $ANTLR end synpred104_C

	partial void Enter_synpred136_C_fragment();
	partial void Leave_synpred136_C_fragment();

	// $ANTLR start synpred136_C
	public void synpred136_C_fragment()
	{
		Enter_synpred136_C_fragment();
		EnterRule("synpred136_C_fragment", 208);
		TraceIn("synpred136_C_fragment", 208);
		try
		{
			// C.g:462:8: ( declaration )
			DebugEnterAlt(1);
			// C.g:462:8: declaration
			{
			DebugLocation(462, 8);
			PushFollow(Follow._declaration_in_synpred136_C1925);
			declaration();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred136_C_fragment", 208);
			LeaveRule("synpred136_C_fragment", 208);
			Leave_synpred136_C_fragment();
		}
	}
	// $ANTLR end synpred136_C
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
	DFA2 dfa2;
	DFA3 dfa3;
	DFA5 dfa5;
	DFA4 dfa4;
	DFA8 dfa8;
	DFA6 dfa6;
	DFA9 dfa9;
	DFA12 dfa12;
	DFA14 dfa14;
	DFA15 dfa15;
	DFA16 dfa16;
	DFA20 dfa20;
	DFA24 dfa24;
	DFA26 dfa26;
	DFA27 dfa27;
	DFA30 dfa30;
	DFA28 dfa28;
	DFA29 dfa29;
	DFA32 dfa32;
	DFA33 dfa33;
	DFA36 dfa36;
	DFA38 dfa38;
	DFA39 dfa39;
	DFA40 dfa40;
	DFA42 dfa42;
	DFA43 dfa43;
	DFA45 dfa45;
	DFA46 dfa46;
	DFA47 dfa47;
	DFA48 dfa48;
	DFA49 dfa49;
	DFA53 dfa53;
	DFA55 dfa55;
	DFA56 dfa56;
	DFA57 dfa57;
	DFA58 dfa58;
	DFA59 dfa59;
	DFA60 dfa60;
	DFA61 dfa61;
	DFA62 dfa62;
	DFA63 dfa63;
	DFA65 dfa65;
	DFA66 dfa66;
	DFA67 dfa67;
	DFA68 dfa68;
	DFA71 dfa71;
	DFA73 dfa73;
	DFA74 dfa74;
	DFA75 dfa75;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa1 = new DFA1( this );
		dfa2 = new DFA2( this, SpecialStateTransition2 );
		dfa3 = new DFA3( this, SpecialStateTransition3 );
		dfa5 = new DFA5( this );
		dfa4 = new DFA4( this );
		dfa8 = new DFA8( this );
		dfa6 = new DFA6( this, SpecialStateTransition6 );
		dfa9 = new DFA9( this, SpecialStateTransition9 );
		dfa12 = new DFA12( this );
		dfa14 = new DFA14( this );
		dfa15 = new DFA15( this );
		dfa16 = new DFA16( this, SpecialStateTransition16 );
		dfa20 = new DFA20( this );
		dfa24 = new DFA24( this, SpecialStateTransition24 );
		dfa26 = new DFA26( this, SpecialStateTransition26 );
		dfa27 = new DFA27( this, SpecialStateTransition27 );
		dfa30 = new DFA30( this, SpecialStateTransition30 );
		dfa28 = new DFA28( this, SpecialStateTransition28 );
		dfa29 = new DFA29( this, SpecialStateTransition29 );
		dfa32 = new DFA32( this );
		dfa33 = new DFA33( this, SpecialStateTransition33 );
		dfa36 = new DFA36( this, SpecialStateTransition36 );
		dfa38 = new DFA38( this );
		dfa39 = new DFA39( this, SpecialStateTransition39 );
		dfa40 = new DFA40( this );
		dfa42 = new DFA42( this );
		dfa43 = new DFA43( this );
		dfa45 = new DFA45( this );
		dfa46 = new DFA46( this );
		dfa47 = new DFA47( this, SpecialStateTransition47 );
		dfa48 = new DFA48( this, SpecialStateTransition48 );
		dfa49 = new DFA49( this );
		dfa53 = new DFA53( this, SpecialStateTransition53 );
		dfa55 = new DFA55( this );
		dfa56 = new DFA56( this );
		dfa57 = new DFA57( this );
		dfa58 = new DFA58( this );
		dfa59 = new DFA59( this );
		dfa60 = new DFA60( this );
		dfa61 = new DFA61( this );
		dfa62 = new DFA62( this );
		dfa63 = new DFA63( this );
		dfa65 = new DFA65( this, SpecialStateTransition65 );
		dfa66 = new DFA66( this );
		dfa67 = new DFA67( this );
		dfa68 = new DFA68( this );
		dfa71 = new DFA71( this );
		dfa73 = new DFA73( this );
		dfa74 = new DFA74( this, SpecialStateTransition74 );
		dfa75 = new DFA75( this );
	}

	private class DFA1 : DFA
	{
		private const string DFA1_eotS =
			"\x13\xFFFF";
		private const string DFA1_eofS =
			"\x1\x1\x12\xFFFF";
		private const string DFA1_minS =
			"\x1\x4\x12\xFFFF";
		private const string DFA1_maxS =
			"\x1\x34\x12\xFFFF";
		private const string DFA1_acceptS =
			"\x1\xFFFF\x1\x2\x1\x1\x10\xFFFF";
		private const string DFA1_specialS =
			"\x13\xFFFF}>";
		private static readonly string[] DFA1_transitionS =
			{
				"\x1\x2\x12\xFFFF\x1\x2\x3\xFFFF\xD\x2\x2\xFFFF\x2\x2\x1\xFFFF\x4\x2"+
				"\x3\xFFFF\x1\x2",
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

		public DFA1( BaseRecognizer recognizer )
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

		public override string Description { get { return "()+ loopback of 63:4: ( external_declaration )+"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA2 : DFA
	{
		private const string DFA2_eotS =
			"\x12\xFFFF";
		private const string DFA2_eofS =
			"\x12\xFFFF";
		private const string DFA2_minS =
			"\x1\x4\xE\x0\x3\xFFFF";
		private const string DFA2_maxS =
			"\x1\x34\xE\x0\x3\xFFFF";
		private const string DFA2_acceptS =
			"\xF\xFFFF\x2\x1\x1\x2";
		private const string DFA2_specialS =
			"\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1\x9\x1\xA\x1"+
			"\xB\x1\xC\x1\xD\x1\xE\x3\xFFFF}>";
		private static readonly string[] DFA2_transitionS =
			{
				"\x1\xD\x12\xFFFF\x1\x11\x3\xFFFF\x4\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6"+
				"\x1\x7\x1\x8\x1\x9\x1\xA\x2\xFFFF\x2\xB\x1\xFFFF\x1\xC\x2\xE\x1\x10"+
				"\x3\xFFFF\x1\xF",
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
				""
			};

		private static readonly short[] DFA2_eot = DFA.UnpackEncodedString(DFA2_eotS);
		private static readonly short[] DFA2_eof = DFA.UnpackEncodedString(DFA2_eofS);
		private static readonly char[] DFA2_min = DFA.UnpackEncodedStringToUnsignedChars(DFA2_minS);
		private static readonly char[] DFA2_max = DFA.UnpackEncodedStringToUnsignedChars(DFA2_maxS);
		private static readonly short[] DFA2_accept = DFA.UnpackEncodedString(DFA2_acceptS);
		private static readonly short[] DFA2_special = DFA.UnpackEncodedString(DFA2_specialS);
		private static readonly short[][] DFA2_transition;

		static DFA2()
		{
			int numStates = DFA2_transitionS.Length;
			DFA2_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA2_transition[i] = DFA.UnpackEncodedString(DFA2_transitionS[i]);
			}
		}

		public DFA2( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 2;
			this.eot = DFA2_eot;
			this.eof = DFA2_eof;
			this.min = DFA2_min;
			this.max = DFA2_max;
			this.accept = DFA2_accept;
			this.special = DFA2_special;
			this.transition = DFA2_transition;
		}

		public override string Description { get { return "66:1: external_declaration options {k=1; } : ( ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition | declaration );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition2(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA2_0 = input.LA(1);


				int index2_0 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((LA2_0>=27 && LA2_0<=30)) ) {s = 1;}

				else if ( (LA2_0==31) ) {s = 2;}

				else if ( (LA2_0==32) ) {s = 3;}

				else if ( (LA2_0==33) ) {s = 4;}

				else if ( (LA2_0==34) ) {s = 5;}

				else if ( (LA2_0==35) ) {s = 6;}

				else if ( (LA2_0==36) ) {s = 7;}

				else if ( (LA2_0==37) ) {s = 8;}

				else if ( (LA2_0==38) ) {s = 9;}

				else if ( (LA2_0==39) ) {s = 10;}

				else if ( ((LA2_0>=42 && LA2_0<=43)) ) {s = 11;}

				else if ( (LA2_0==45) ) {s = 12;}

				else if ( (LA2_0==IDENTIFIER) ) {s = 13;}

				else if ( ((LA2_0>=46 && LA2_0<=47)) ) {s = 14;}

				else if ( (LA2_0==52) && (EvaluatePredicate(synpred4_C_fragment))) {s = 15;}

				else if ( (LA2_0==48) && (EvaluatePredicate(synpred4_C_fragment))) {s = 16;}

				else if ( (LA2_0==23) ) {s = 17;}


				input.Seek(index2_0);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA2_1 = input.LA(1);


				int index2_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_1);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA2_2 = input.LA(1);


				int index2_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_2);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA2_3 = input.LA(1);


				int index2_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_3);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA2_4 = input.LA(1);


				int index2_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_4);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA2_5 = input.LA(1);


				int index2_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_5);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA2_6 = input.LA(1);


				int index2_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_6);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA2_7 = input.LA(1);


				int index2_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_7);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA2_8 = input.LA(1);


				int index2_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_8);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA2_9 = input.LA(1);


				int index2_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_9);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA2_10 = input.LA(1);


				int index2_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_10);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA2_11 = input.LA(1);


				int index2_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_11);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA2_12 = input.LA(1);


				int index2_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_12);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA2_13 = input.LA(1);


				int index2_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (((EvaluatePredicate(synpred4_C_fragment)&&(isTypeName(input.LT(1).getText())))||EvaluatePredicate(synpred4_C_fragment))) ) {s = 16;}

				else if ( ((isTypeName(input.LT(1).getText()))) ) {s = 17;}


				input.Seek(index2_13);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA2_14 = input.LA(1);


				int index2_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred4_C_fragment)) ) {s = 16;}

				else if ( (true) ) {s = 17;}


				input.Seek(index2_14);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 2, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA3 : DFA
	{
		private const string DFA3_eotS =
			"\x24\xFFFF";
		private const string DFA3_eofS =
			"\x24\xFFFF";
		private const string DFA3_minS =
			"\x1\x4\xC\xFFFF\x1\x4\x4\xFFFF\xF\x0\x3\xFFFF";
		private const string DFA3_maxS =
			"\x1\x34\xC\xFFFF\x1\x34\x4\xFFFF\xF\x0\x3\xFFFF";
		private const string DFA3_acceptS =
			"\x1\xFFFF\x1\x1\xD\xFFFF\x1\x2\x14\xFFFF";
		private const string DFA3_specialS =
			"\x12\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1"+
			"\x9\x1\xA\x1\xB\x1\xC\x1\xD\x1\xE\x3\xFFFF}>";
		private static readonly string[] DFA3_transitionS =
			{
				"\x1\xD\x16\xFFFF\xD\x1\x2\xFFFF\x2\x1\x1\xFFFF\x3\x1\x1\xF\x3\xFFFF"+
				"\x1\xF",
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
				"\x1\x12\x12\xFFFF\x1\xF\x3\xFFFF\x4\x14\x1\x15\x1\x16\x1\x17\x1\x18"+
				"\x1\x19\x1\x1A\x1\x1B\x1\x1C\x1\x1D\x1\xF\x1\xFFFF\x2\x1E\x1\xFFFF\x1"+
				"\x1F\x2\x20\x1\x13\x1\xFFFF\x1\xF\x1\xFFFF\x1\x1",
				"",
				"",
				"",
				"",
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
				"\x1\xFFFF",
				"",
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

		public DFA3( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "91:4: ( declaration_specifiers )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition3(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA3_18 = input.LA(1);


				int index3_18 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_18);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA3_19 = input.LA(1);


				int index3_19 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_19);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA3_20 = input.LA(1);


				int index3_20 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_20);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA3_21 = input.LA(1);


				int index3_21 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_21);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA3_22 = input.LA(1);


				int index3_22 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_22);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA3_23 = input.LA(1);


				int index3_23 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_23);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA3_24 = input.LA(1);


				int index3_24 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_24);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA3_25 = input.LA(1);


				int index3_25 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_25);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA3_26 = input.LA(1);


				int index3_26 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_26);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA3_27 = input.LA(1);


				int index3_27 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_27);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA3_28 = input.LA(1);


				int index3_28 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_28);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA3_29 = input.LA(1);


				int index3_29 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_29);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA3_30 = input.LA(1);


				int index3_30 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_30);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA3_31 = input.LA(1);


				int index3_31 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_31);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA3_32 = input.LA(1);


				int index3_32 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred5_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index3_32);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 3, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA5 : DFA
	{
		private const string DFA5_eotS =
			"\x11\xFFFF";
		private const string DFA5_eofS =
			"\x11\xFFFF";
		private const string DFA5_minS =
			"\x1\x4\x10\xFFFF";
		private const string DFA5_maxS =
			"\x1\x2F\x10\xFFFF";
		private const string DFA5_acceptS =
			"\x1\xFFFF\x1\x1\xE\xFFFF\x1\x2";
		private const string DFA5_specialS =
			"\x11\xFFFF}>";
		private static readonly string[] DFA5_transitionS =
			{
				"\x1\x1\x12\xFFFF\x1\x1\x3\xFFFF\xD\x1\x1\x10\x1\xFFFF\x2\x1\x1\xFFFF"+
				"\x3\x1",
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

		public override string Description { get { return "92:3: ( ( declaration )+ compound_statement | compound_statement )"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA4 : DFA
	{
		private const string DFA4_eotS =
			"\x11\xFFFF";
		private const string DFA4_eofS =
			"\x11\xFFFF";
		private const string DFA4_minS =
			"\x1\x4\x10\xFFFF";
		private const string DFA4_maxS =
			"\x1\x2F\x10\xFFFF";
		private const string DFA4_acceptS =
			"\x1\xFFFF\x1\x2\x1\x1\xE\xFFFF";
		private const string DFA4_specialS =
			"\x11\xFFFF}>";
		private static readonly string[] DFA4_transitionS =
			{
				"\x1\x2\x12\xFFFF\x1\x2\x3\xFFFF\xD\x2\x1\x1\x1\xFFFF\x2\x2\x1\xFFFF"+
				"\x3\x2",
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

		private static readonly short[] DFA4_eot = DFA.UnpackEncodedString(DFA4_eotS);
		private static readonly short[] DFA4_eof = DFA.UnpackEncodedString(DFA4_eofS);
		private static readonly char[] DFA4_min = DFA.UnpackEncodedStringToUnsignedChars(DFA4_minS);
		private static readonly char[] DFA4_max = DFA.UnpackEncodedStringToUnsignedChars(DFA4_maxS);
		private static readonly short[] DFA4_accept = DFA.UnpackEncodedString(DFA4_acceptS);
		private static readonly short[] DFA4_special = DFA.UnpackEncodedString(DFA4_specialS);
		private static readonly short[][] DFA4_transition;

		static DFA4()
		{
			int numStates = DFA4_transitionS.Length;
			DFA4_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA4_transition[i] = DFA.UnpackEncodedString(DFA4_transitionS[i]);
			}
		}

		public DFA4( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 4;
			this.eot = DFA4_eot;
			this.eof = DFA4_eof;
			this.min = DFA4_min;
			this.max = DFA4_max;
			this.accept = DFA4_accept;
			this.special = DFA4_special;
			this.transition = DFA4_transition;
		}

		public override string Description { get { return "()+ loopback of 92:5: ( declaration )+"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA8 : DFA
	{
		private const string DFA8_eotS =
			"\x10\xFFFF";
		private const string DFA8_eofS =
			"\x10\xFFFF";
		private const string DFA8_minS =
			"\x1\x4\xF\xFFFF";
		private const string DFA8_maxS =
			"\x1\x2F\xF\xFFFF";
		private const string DFA8_acceptS =
			"\x1\xFFFF\x1\x1\x1\x2\xD\xFFFF";
		private const string DFA8_specialS =
			"\x10\xFFFF}>";
		private static readonly string[] DFA8_transitionS =
			{
				"\x1\x2\x12\xFFFF\x1\x1\x3\xFFFF\xD\x2\x2\xFFFF\x2\x2\x1\xFFFF\x3\x2",
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

		private static readonly short[] DFA8_eot = DFA.UnpackEncodedString(DFA8_eotS);
		private static readonly short[] DFA8_eof = DFA.UnpackEncodedString(DFA8_eofS);
		private static readonly char[] DFA8_min = DFA.UnpackEncodedStringToUnsignedChars(DFA8_minS);
		private static readonly char[] DFA8_max = DFA.UnpackEncodedStringToUnsignedChars(DFA8_maxS);
		private static readonly short[] DFA8_accept = DFA.UnpackEncodedString(DFA8_acceptS);
		private static readonly short[] DFA8_special = DFA.UnpackEncodedString(DFA8_specialS);
		private static readonly short[][] DFA8_transition;

		static DFA8()
		{
			int numStates = DFA8_transitionS.Length;
			DFA8_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA8_transition[i] = DFA.UnpackEncodedString(DFA8_transitionS[i]);
			}
		}

		public DFA8( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 8;
			this.eot = DFA8_eot;
			this.eof = DFA8_eof;
			this.min = DFA8_min;
			this.max = DFA8_max;
			this.accept = DFA8_accept;
			this.special = DFA8_special;
			this.transition = DFA8_transition;
		}

		public override string Description { get { return "97:1: declaration : ( 'typedef' ( declaration_specifiers )? init_declarator_list ';' | declaration_specifiers ( init_declarator_list )? ';' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA6 : DFA
	{
		private const string DFA6_eotS =
			"\x25\xFFFF";
		private const string DFA6_eofS =
			"\x25\xFFFF";
		private const string DFA6_minS =
			"\x1\x4\xC\xFFFF\x1\x4\x5\xFFFF\x1\x0\x11\xFFFF";
		private const string DFA6_maxS =
			"\x1\x34\xC\xFFFF\x1\x34\x5\xFFFF\x1\x0\x11\xFFFF";
		private const string DFA6_acceptS =
			"\x1\xFFFF\x1\x1\xD\xFFFF\x1\x2\x15\xFFFF";
		private const string DFA6_specialS =
			"\x13\xFFFF\x1\x0\x11\xFFFF}>";
		private static readonly string[] DFA6_transitionS =
			{
				"\x1\xD\x16\xFFFF\xD\x1\x2\xFFFF\x2\x1\x1\xFFFF\x3\x1\x1\xF\x3\xFFFF"+
				"\x1\xF",
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
				"\x1\x1\x13\xFFFF\x3\xF\xD\x1\x2\xFFFF\x2\x1\x1\xFFFF\x3\x1\x1\x13"+
				"\x1\xFFFF\x1\xF\x1\xFFFF\x1\x1",
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

		public override string Description { get { return "104:14: ( declaration_specifiers )?"; } }

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
				int LA6_19 = input.LA(1);


				int index6_19 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred8_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index6_19);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 6, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA9 : DFA
	{
		private const string DFA9_eotS =
			"\x2E\xFFFF";
		private const string DFA9_eofS =
			"\x1\x1\x2D\xFFFF";
		private const string DFA9_minS =
			"\x1\x4\x1\xFFFF\x1\x0\x2B\xFFFF";
		private const string DFA9_maxS =
			"\x1\x34\x1\xFFFF\x1\x0\x2B\xFFFF";
		private const string DFA9_acceptS =
			"\x1\xFFFF\x1\x4\x7\xFFFF\x1\x1\x1\x2\xA\xFFFF\x1\x3\x18\xFFFF";
		private const string DFA9_specialS =
			"\x2\xFFFF\x1\x0\x2B\xFFFF}>";
		private static readonly string[] DFA9_transitionS =
			{
				"\x1\x2\x13\xFFFF\x2\x1\x1\xFFFF\x4\x9\x9\xA\x2\xFFFF\x2\xA\x1\xFFFF"+
				"\x1\xA\x2\x15\x3\x1\x1\xFFFF\x1\x1",
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

		public override string Description { get { return "()+ loopback of 110:6: ( storage_class_specifier | type_specifier | type_qualifier )+"; } }

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
				int LA9_2 = input.LA(1);


				int index9_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred12_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 10;}

				else if ( (true) ) {s = 1;}


				input.Seek(index9_2);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 9, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA12 : DFA
	{
		private const string DFA12_eotS =
			"\xD\xFFFF";
		private const string DFA12_eofS =
			"\xD\xFFFF";
		private const string DFA12_minS =
			"\x1\x4\xC\xFFFF";
		private const string DFA12_maxS =
			"\x1\x2D\xC\xFFFF";
		private const string DFA12_acceptS =
			"\x1\xFFFF\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1\x9\x1\xA"+
			"\x1\xB\x1\xC";
		private const string DFA12_specialS =
			"\xD\xFFFF}>";
		private static readonly string[] DFA12_transitionS =
			{
				"\x1\xC\x1A\xFFFF\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1"+
				"\x9\x2\xFFFF\x2\xA\x1\xFFFF\x1\xB",
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

		private static readonly short[] DFA12_eot = DFA.UnpackEncodedString(DFA12_eotS);
		private static readonly short[] DFA12_eof = DFA.UnpackEncodedString(DFA12_eofS);
		private static readonly char[] DFA12_min = DFA.UnpackEncodedStringToUnsignedChars(DFA12_minS);
		private static readonly char[] DFA12_max = DFA.UnpackEncodedStringToUnsignedChars(DFA12_maxS);
		private static readonly short[] DFA12_accept = DFA.UnpackEncodedString(DFA12_acceptS);
		private static readonly short[] DFA12_special = DFA.UnpackEncodedString(DFA12_specialS);
		private static readonly short[][] DFA12_transition;

		static DFA12()
		{
			int numStates = DFA12_transitionS.Length;
			DFA12_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA12_transition[i] = DFA.UnpackEncodedString(DFA12_transitionS[i]);
			}
		}

		public DFA12( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 12;
			this.eot = DFA12_eot;
			this.eof = DFA12_eof;
			this.min = DFA12_min;
			this.max = DFA12_max;
			this.accept = DFA12_accept;
			this.special = DFA12_special;
			this.transition = DFA12_transition;
		}

		public override string Description { get { return "131:1: type_specifier : ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | struct_or_union_specifier | enum_specifier | type_id );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA14 : DFA
	{
		private const string DFA14_eotS =
			"\x1B\xFFFF";
		private const string DFA14_eofS =
			"\x2\xFFFF\x1\x5\x18\xFFFF";
		private const string DFA14_minS =
			"\x1\x2A\x2\x4\x18\xFFFF";
		private const string DFA14_maxS =
			"\x1\x2B\x1\x28\x1\x34\x18\xFFFF";
		private const string DFA14_acceptS =
			"\x3\xFFFF\x1\x1\x1\xFFFF\x1\x2\x15\xFFFF";
		private const string DFA14_specialS =
			"\x1B\xFFFF}>";
		private static readonly string[] DFA14_transitionS =
			{
				"\x2\x1",
				"\x1\x2\x23\xFFFF\x1\x3",
				"\x1\x5\x13\xFFFF\x2\x5\x1\xFFFF\xD\x5\x1\x3\x1\xFFFF\x9\x5\x1\xFFFF"+
				"\x1\x5",
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

		private static readonly short[] DFA14_eot = DFA.UnpackEncodedString(DFA14_eotS);
		private static readonly short[] DFA14_eof = DFA.UnpackEncodedString(DFA14_eofS);
		private static readonly char[] DFA14_min = DFA.UnpackEncodedStringToUnsignedChars(DFA14_minS);
		private static readonly char[] DFA14_max = DFA.UnpackEncodedStringToUnsignedChars(DFA14_maxS);
		private static readonly short[] DFA14_accept = DFA.UnpackEncodedString(DFA14_acceptS);
		private static readonly short[] DFA14_special = DFA.UnpackEncodedString(DFA14_specialS);
		private static readonly short[][] DFA14_transition;

		static DFA14()
		{
			int numStates = DFA14_transitionS.Length;
			DFA14_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA14_transition[i] = DFA.UnpackEncodedString(DFA14_transitionS[i]);
			}
		}

		public DFA14( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 14;
			this.eot = DFA14_eot;
			this.eof = DFA14_eof;
			this.min = DFA14_min;
			this.max = DFA14_max;
			this.accept = DFA14_accept;
			this.special = DFA14_special;
			this.transition = DFA14_transition;
		}

		public override string Description { get { return "151:1: struct_or_union_specifier options {k=3; } : ( struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}' | struct_or_union IDENTIFIER );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA15 : DFA
	{
		private const string DFA15_eotS =
			"\xF\xFFFF";
		private const string DFA15_eofS =
			"\xF\xFFFF";
		private const string DFA15_minS =
			"\x1\x4\xE\xFFFF";
		private const string DFA15_maxS =
			"\x1\x2F\xE\xFFFF";
		private const string DFA15_acceptS =
			"\x1\xFFFF\x1\x2\x1\x1\xC\xFFFF";
		private const string DFA15_specialS =
			"\xF\xFFFF}>";
		private static readonly string[] DFA15_transitionS =
			{
				"\x1\x2\x1A\xFFFF\x9\x2\x1\xFFFF\x1\x1\x2\x2\x1\xFFFF\x3\x2",
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

		private static readonly short[] DFA15_eot = DFA.UnpackEncodedString(DFA15_eotS);
		private static readonly short[] DFA15_eof = DFA.UnpackEncodedString(DFA15_eofS);
		private static readonly char[] DFA15_min = DFA.UnpackEncodedStringToUnsignedChars(DFA15_minS);
		private static readonly char[] DFA15_max = DFA.UnpackEncodedStringToUnsignedChars(DFA15_maxS);
		private static readonly short[] DFA15_accept = DFA.UnpackEncodedString(DFA15_acceptS);
		private static readonly short[] DFA15_special = DFA.UnpackEncodedString(DFA15_specialS);
		private static readonly short[][] DFA15_transition;

		static DFA15()
		{
			int numStates = DFA15_transitionS.Length;
			DFA15_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA15_transition[i] = DFA.UnpackEncodedString(DFA15_transitionS[i]);
			}
		}

		public DFA15( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 15;
			this.eot = DFA15_eot;
			this.eof = DFA15_eof;
			this.min = DFA15_min;
			this.max = DFA15_max;
			this.accept = DFA15_accept;
			this.special = DFA15_special;
			this.transition = DFA15_transition;
		}

		public override string Description { get { return "()+ loopback of 167:4: ( struct_declaration )+"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA16 : DFA
	{
		private const string DFA16_eotS =
			"\x27\xFFFF";
		private const string DFA16_eofS =
			"\x27\xFFFF";
		private const string DFA16_minS =
			"\x1\x4\x1\xFFFF\x1\x4\x10\xFFFF\x3\x0\x11\xFFFF";
		private const string DFA16_maxS =
			"\x1\x34\x1\xFFFF\x1\x34\x10\xFFFF\x3\x0\x11\xFFFF";
		private const string DFA16_acceptS =
			"\x1\xFFFF\x1\x3\x5\xFFFF\x1\x1\x1\x2\x1E\xFFFF";
		private const string DFA16_specialS =
			"\x13\xFFFF\x1\x0\x1\x1\x1\x2\x11\xFFFF}>";
		private static readonly string[] DFA16_transitionS =
			{
				"\x1\x2\x1A\xFFFF\x9\x8\x2\xFFFF\x2\x8\x1\x1\x1\x8\x2\x7\x3\x1\x1\xFFFF"+
				"\x1\x1",
				"",
				"\x1\x8\x13\xFFFF\x2\x1\x5\xFFFF\x9\x8\x2\xFFFF\x2\x8\x1\x15\x3\x8"+
				"\x1\x14\x1\x8\x1\x13\x1\xFFFF\x1\x8",
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

		public override string Description { get { return "()+ loopback of 175:4: ( type_qualifier | type_specifier )+"; } }

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
				int LA16_19 = input.LA(1);


				int index16_19 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred35_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 8;}

				else if ( (true) ) {s = 1;}


				input.Seek(index16_19);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA16_20 = input.LA(1);


				int index16_20 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred35_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 8;}

				else if ( (true) ) {s = 1;}


				input.Seek(index16_20);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA16_21 = input.LA(1);


				int index16_21 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred35_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 8;}

				else if ( (true) ) {s = 1;}


				input.Seek(index16_21);
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
			"\x1B\xFFFF";
		private const string DFA20_eofS =
			"\x3\xFFFF\x1\x5\x17\xFFFF";
		private const string DFA20_minS =
			"\x1\x2D\x1\x4\x1\xFFFF\x1\x4\x17\xFFFF";
		private const string DFA20_maxS =
			"\x1\x2D\x1\x28\x1\xFFFF\x1\x34\x17\xFFFF";
		private const string DFA20_acceptS =
			"\x2\xFFFF\x1\x1\x1\xFFFF\x1\x2\x1\x3\x15\xFFFF";
		private const string DFA20_specialS =
			"\x1B\xFFFF}>";
		private static readonly string[] DFA20_transitionS =
			{
				"\x1\x1",
				"\x1\x3\x23\xFFFF\x1\x2",
				"",
				"\x1\x5\x13\xFFFF\x2\x5\x1\xFFFF\xD\x5\x1\x4\x1\xFFFF\x9\x5\x1\xFFFF"+
				"\x1\x5",
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

		public DFA20( BaseRecognizer recognizer )
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

		public override string Description { get { return "187:1: enum_specifier options {k=3; } : ( 'enum' '{' enumerator_list '}' | 'enum' IDENTIFIER '{' enumerator_list '}' | 'enum' IDENTIFIER );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA24 : DFA
	{
		private const string DFA24_eotS =
			"\x1E\xFFFF";
		private const string DFA24_eofS =
			"\x1E\xFFFF";
		private const string DFA24_minS =
			"\x1\x4\x1\x0\x1C\xFFFF";
		private const string DFA24_maxS =
			"\x1\x34\x1\x0\x1C\xFFFF";
		private const string DFA24_acceptS =
			"\x2\xFFFF\x1\x1\x1A\xFFFF\x1\x2";
		private const string DFA24_specialS =
			"\x1\xFFFF\x1\x0\x1C\xFFFF}>";
		private static readonly string[] DFA24_transitionS =
			{
				"\x1\x2\x2B\xFFFF\x1\x2\x3\xFFFF\x1\x1",
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
				""
			};

		private static readonly short[] DFA24_eot = DFA.UnpackEncodedString(DFA24_eotS);
		private static readonly short[] DFA24_eof = DFA.UnpackEncodedString(DFA24_eofS);
		private static readonly char[] DFA24_min = DFA.UnpackEncodedStringToUnsignedChars(DFA24_minS);
		private static readonly char[] DFA24_max = DFA.UnpackEncodedStringToUnsignedChars(DFA24_maxS);
		private static readonly short[] DFA24_accept = DFA.UnpackEncodedString(DFA24_acceptS);
		private static readonly short[] DFA24_special = DFA.UnpackEncodedString(DFA24_specialS);
		private static readonly short[][] DFA24_transition;

		static DFA24()
		{
			int numStates = DFA24_transitionS.Length;
			DFA24_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA24_transition[i] = DFA.UnpackEncodedString(DFA24_transitionS[i]);
			}
		}

		public DFA24( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 24;
			this.eot = DFA24_eot;
			this.eof = DFA24_eof;
			this.min = DFA24_min;
			this.max = DFA24_max;
			this.accept = DFA24_accept;
			this.special = DFA24_special;
			this.transition = DFA24_transition;
		}

		public override string Description { get { return "207:1: declarator : ( ( pointer )? direct_declarator | pointer );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition24(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA24_1 = input.LA(1);


				int index24_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred45_C_fragment)) ) {s = 2;}

				else if ( (true) ) {s = 29;}


				input.Seek(index24_1);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 24, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA26 : DFA
	{
		private const string DFA26_eotS =
			"\x3A\xFFFF";
		private const string DFA26_eofS =
			"\x1\x1\x39\xFFFF";
		private const string DFA26_minS =
			"\x1\x4\x17\xFFFF\x2\x4\x1\x0\x1\xFFFF\x1\x0\x2\xFFFF\x1A\x0\x1\xFFFF";
		private const string DFA26_maxS =
			"\x1\x34\x17\xFFFF\x1\x34\x1\x41\x1\x0\x1\xFFFF\x1\x0\x2\xFFFF\x1A\x0"+
			"\x1\xFFFF";
		private const string DFA26_acceptS =
			"\x1\xFFFF\x1\x2\x37\xFFFF\x1\x1";
		private const string DFA26_specialS =
			"\x1A\xFFFF\x1\x0\x1\xFFFF\x1\x1\x2\xFFFF\x1\x2\x1\x3\x1\x4\x1\x5\x1"+
			"\x6\x1\x7\x1\x8\x1\x9\x1\xA\x1\xB\x1\xC\x1\xD\x1\xE\x1\xF\x1\x10\x1\x11"+
			"\x1\x12\x1\x13\x1\x14\x1\x15\x1\x16\x1\x17\x1\x18\x1\x19\x1\x1A\x1\x1B"+
			"\x1\xFFFF}>";
		private static readonly string[] DFA26_transitionS =
			{
				"\x1\x1\x12\xFFFF\x12\x1\x1\xFFFF\x6\x1\x1\x18\x1\x1\x1\x19\x1\xFFFF"+
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
				"\x1\x1C\x16\xFFFF\x4\x1F\x1\x20\x1\x21\x1\x22\x1\x23\x1\x24\x1\x25"+
				"\x1\x26\x1\x27\x1\x28\x2\xFFFF\x2\x29\x1\xFFFF\x1\x2A\x2\x2B\x1\x1\x1"+
				"\x1A\x1\x1\x1\xFFFF\x1\x1",
				"\x1\x2E\x1\x2F\x1\x30\x1\x31\x1\x32\x1\x33\x1\x34\x25\xFFFF\x1\x2D"+
				"\x2\xFFFF\x1\x2C\x1\x37\x1\xFFFF\x2\x37\x2\xFFFF\x1\x35\x1\x36\x1\x38"+
				"\x2\xFFFF\x3\x37",
				"\x1\xFFFF",
				"",
				"\x1\xFFFF",
				"",
				"",
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
				""
			};

		private static readonly short[] DFA26_eot = DFA.UnpackEncodedString(DFA26_eotS);
		private static readonly short[] DFA26_eof = DFA.UnpackEncodedString(DFA26_eofS);
		private static readonly char[] DFA26_min = DFA.UnpackEncodedStringToUnsignedChars(DFA26_minS);
		private static readonly char[] DFA26_max = DFA.UnpackEncodedStringToUnsignedChars(DFA26_maxS);
		private static readonly short[] DFA26_accept = DFA.UnpackEncodedString(DFA26_acceptS);
		private static readonly short[] DFA26_special = DFA.UnpackEncodedString(DFA26_specialS);
		private static readonly short[][] DFA26_transition;

		static DFA26()
		{
			int numStates = DFA26_transitionS.Length;
			DFA26_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA26_transition[i] = DFA.UnpackEncodedString(DFA26_transitionS[i]);
			}
		}

		public DFA26( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 26;
			this.eot = DFA26_eot;
			this.eof = DFA26_eof;
			this.min = DFA26_min;
			this.max = DFA26_max;
			this.accept = DFA26_accept;
			this.special = DFA26_special;
			this.transition = DFA26_transition;
		}

		public override string Description { get { return "()* loopback of 222:9: ( declarator_suffix )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition26(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA26_26 = input.LA(1);


				int index26_26 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_26);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA26_28 = input.LA(1);


				int index26_28 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_28);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA26_31 = input.LA(1);


				int index26_31 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_31);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA26_32 = input.LA(1);


				int index26_32 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_32);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA26_33 = input.LA(1);


				int index26_33 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_33);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA26_34 = input.LA(1);


				int index26_34 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_34);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA26_35 = input.LA(1);


				int index26_35 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_35);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA26_36 = input.LA(1);


				int index26_36 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_36);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA26_37 = input.LA(1);


				int index26_37 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_37);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA26_38 = input.LA(1);


				int index26_38 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_38);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA26_39 = input.LA(1);


				int index26_39 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_39);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA26_40 = input.LA(1);


				int index26_40 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_40);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA26_41 = input.LA(1);


				int index26_41 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_41);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA26_42 = input.LA(1);


				int index26_42 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_42);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA26_43 = input.LA(1);


				int index26_43 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_43);
				if ( s>=0 ) return s;
				break;
			case 15:
				int LA26_44 = input.LA(1);


				int index26_44 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_44);
				if ( s>=0 ) return s;
				break;
			case 16:
				int LA26_45 = input.LA(1);


				int index26_45 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_45);
				if ( s>=0 ) return s;
				break;
			case 17:
				int LA26_46 = input.LA(1);


				int index26_46 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_46);
				if ( s>=0 ) return s;
				break;
			case 18:
				int LA26_47 = input.LA(1);


				int index26_47 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_47);
				if ( s>=0 ) return s;
				break;
			case 19:
				int LA26_48 = input.LA(1);


				int index26_48 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_48);
				if ( s>=0 ) return s;
				break;
			case 20:
				int LA26_49 = input.LA(1);


				int index26_49 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_49);
				if ( s>=0 ) return s;
				break;
			case 21:
				int LA26_50 = input.LA(1);


				int index26_50 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_50);
				if ( s>=0 ) return s;
				break;
			case 22:
				int LA26_51 = input.LA(1);


				int index26_51 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_51);
				if ( s>=0 ) return s;
				break;
			case 23:
				int LA26_52 = input.LA(1);


				int index26_52 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_52);
				if ( s>=0 ) return s;
				break;
			case 24:
				int LA26_53 = input.LA(1);


				int index26_53 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_53);
				if ( s>=0 ) return s;
				break;
			case 25:
				int LA26_54 = input.LA(1);


				int index26_54 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_54);
				if ( s>=0 ) return s;
				break;
			case 26:
				int LA26_55 = input.LA(1);


				int index26_55 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_55);
				if ( s>=0 ) return s;
				break;
			case 27:
				int LA26_56 = input.LA(1);


				int index26_56 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred47_C_fragment)) ) {s = 57;}

				else if ( (true) ) {s = 1;}


				input.Seek(index26_56);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 26, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA27 : DFA
	{
		private const string DFA27_eotS =
			"\x20\xFFFF";
		private const string DFA27_eofS =
			"\x20\xFFFF";
		private const string DFA27_minS =
			"\x1\x30\x2\x4\x1A\xFFFF\x1\x0\x2\xFFFF";
		private const string DFA27_maxS =
			"\x1\x32\x1\x41\x1\x31\x1A\xFFFF\x1\x0\x2\xFFFF";
		private const string DFA27_acceptS =
			"\x3\xFFFF\x1\x2\x1\x1\xB\xFFFF\x1\x5\x1\x3\xD\xFFFF\x1\x4";
		private const string DFA27_specialS =
			"\x1D\xFFFF\x1\x0\x2\xFFFF}>";
		private static readonly string[] DFA27_transitionS =
			{
				"\x1\x2\x1\xFFFF\x1\x1",
				"\x7\x4\x25\xFFFF\x1\x4\x2\xFFFF\x1\x3\x1\x4\x1\xFFFF\x2\x4\x2\xFFFF"+
				"\x3\x4\x2\xFFFF\x3\x4",
				"\x1\x1D\x16\xFFFF\xD\x11\x2\xFFFF\x2\x11\x1\xFFFF\x3\x11\x1\xFFFF"+
				"\x1\x10",
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
				""
			};

		private static readonly short[] DFA27_eot = DFA.UnpackEncodedString(DFA27_eotS);
		private static readonly short[] DFA27_eof = DFA.UnpackEncodedString(DFA27_eofS);
		private static readonly char[] DFA27_min = DFA.UnpackEncodedStringToUnsignedChars(DFA27_minS);
		private static readonly char[] DFA27_max = DFA.UnpackEncodedStringToUnsignedChars(DFA27_maxS);
		private static readonly short[] DFA27_accept = DFA.UnpackEncodedString(DFA27_acceptS);
		private static readonly short[] DFA27_special = DFA.UnpackEncodedString(DFA27_specialS);
		private static readonly short[][] DFA27_transition;

		static DFA27()
		{
			int numStates = DFA27_transitionS.Length;
			DFA27_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA27_transition[i] = DFA.UnpackEncodedString(DFA27_transitionS[i]);
			}
		}

		public DFA27( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 27;
			this.eot = DFA27_eot;
			this.eof = DFA27_eof;
			this.min = DFA27_min;
			this.max = DFA27_max;
			this.accept = DFA27_accept;
			this.special = DFA27_special;
			this.transition = DFA27_transition;
		}

		public override string Description { get { return "225:1: declarator_suffix : ( '[' constant_expression ']' | '[' ']' | '(' parameter_type_list ')' | '(' identifier_list ')' | '(' ')' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition27(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA27_29 = input.LA(1);


				int index27_29 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred50_C_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred51_C_fragment)) ) {s = 31;}


				input.Seek(index27_29);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 27, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA30 : DFA
	{
		private const string DFA30_eotS =
			"\x1D\xFFFF";
		private const string DFA30_eofS =
			"\x1\xFFFF\x1\x4\x1B\xFFFF";
		private const string DFA30_minS =
			"\x1\x34\x1\x4\x2\x0\x19\xFFFF";
		private const string DFA30_maxS =
			"\x2\x34\x2\x0\x19\xFFFF";
		private const string DFA30_acceptS =
			"\x4\xFFFF\x1\x3\x16\xFFFF\x1\x1\x1\x2";
		private const string DFA30_specialS =
			"\x2\xFFFF\x1\x0\x1\x1\x19\xFFFF}>";
		private static readonly string[] DFA30_transitionS =
			{
				"\x1\x1",
				"\x1\x4\x12\xFFFF\x12\x4\x1\xFFFF\x4\x4\x2\x2\x3\x4\x1\xFFFF\x1\x3",
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
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA30_eot = DFA.UnpackEncodedString(DFA30_eotS);
		private static readonly short[] DFA30_eof = DFA.UnpackEncodedString(DFA30_eofS);
		private static readonly char[] DFA30_min = DFA.UnpackEncodedStringToUnsignedChars(DFA30_minS);
		private static readonly char[] DFA30_max = DFA.UnpackEncodedStringToUnsignedChars(DFA30_maxS);
		private static readonly short[] DFA30_accept = DFA.UnpackEncodedString(DFA30_acceptS);
		private static readonly short[] DFA30_special = DFA.UnpackEncodedString(DFA30_specialS);
		private static readonly short[][] DFA30_transition;

		static DFA30()
		{
			int numStates = DFA30_transitionS.Length;
			DFA30_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA30_transition[i] = DFA.UnpackEncodedString(DFA30_transitionS[i]);
			}
		}

		public DFA30( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 30;
			this.eot = DFA30_eot;
			this.eof = DFA30_eof;
			this.min = DFA30_min;
			this.max = DFA30_max;
			this.accept = DFA30_accept;
			this.special = DFA30_special;
			this.transition = DFA30_transition;
		}

		public override string Description { get { return "233:1: pointer : ( '*' ( type_qualifier )+ ( pointer )? | '*' pointer | '*' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition30(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA30_2 = input.LA(1);


				int index30_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred54_C_fragment)) ) {s = 27;}

				else if ( (true) ) {s = 4;}


				input.Seek(index30_2);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA30_3 = input.LA(1);


				int index30_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred55_C_fragment)) ) {s = 28;}

				else if ( (true) ) {s = 4;}


				input.Seek(index30_3);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 30, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA28 : DFA
	{
		private const string DFA28_eotS =
			"\x34\xFFFF";
		private const string DFA28_eofS =
			"\x1\x1\x33\xFFFF";
		private const string DFA28_minS =
			"\x1\x4\x10\xFFFF\x1\x0\x22\xFFFF";
		private const string DFA28_maxS =
			"\x1\x34\x10\xFFFF\x1\x0\x22\xFFFF";
		private const string DFA28_acceptS =
			"\x1\xFFFF\x1\x2\x31\xFFFF\x1\x1";
		private const string DFA28_specialS =
			"\x11\xFFFF\x1\x0\x22\xFFFF}>";
		private static readonly string[] DFA28_transitionS =
			{
				"\x1\x1\x12\xFFFF\x12\x1\x1\xFFFF\x4\x1\x2\x11\x3\x1\x1\xFFFF\x1\x1",
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

		public DFA28( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "()+ loopback of 234:8: ( type_qualifier )+"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition28(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA28_17 = input.LA(1);


				int index28_17 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_C_fragment)) ) {s = 51;}

				else if ( (true) ) {s = 1;}


				input.Seek(index28_17);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 28, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA29 : DFA
	{
		private const string DFA29_eotS =
			"\x34\xFFFF";
		private const string DFA29_eofS =
			"\x1\x2\x33\xFFFF";
		private const string DFA29_minS =
			"\x1\x4\x1\x0\x32\xFFFF";
		private const string DFA29_maxS =
			"\x1\x34\x1\x0\x32\xFFFF";
		private const string DFA29_acceptS =
			"\x2\xFFFF\x1\x2\x30\xFFFF\x1\x1";
		private const string DFA29_specialS =
			"\x1\xFFFF\x1\x0\x32\xFFFF}>";
		private static readonly string[] DFA29_transitionS =
			{
				"\x1\x2\x12\xFFFF\x12\x2\x1\xFFFF\x9\x2\x1\xFFFF\x1\x1",
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
				""
			};

		private static readonly short[] DFA29_eot = DFA.UnpackEncodedString(DFA29_eotS);
		private static readonly short[] DFA29_eof = DFA.UnpackEncodedString(DFA29_eofS);
		private static readonly char[] DFA29_min = DFA.UnpackEncodedStringToUnsignedChars(DFA29_minS);
		private static readonly char[] DFA29_max = DFA.UnpackEncodedStringToUnsignedChars(DFA29_maxS);
		private static readonly short[] DFA29_accept = DFA.UnpackEncodedString(DFA29_acceptS);
		private static readonly short[] DFA29_special = DFA.UnpackEncodedString(DFA29_specialS);
		private static readonly short[][] DFA29_transition;

		static DFA29()
		{
			int numStates = DFA29_transitionS.Length;
			DFA29_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA29_transition[i] = DFA.UnpackEncodedString(DFA29_transitionS[i]);
			}
		}

		public DFA29( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 29;
			this.eot = DFA29_eot;
			this.eof = DFA29_eof;
			this.min = DFA29_min;
			this.max = DFA29_max;
			this.accept = DFA29_accept;
			this.special = DFA29_special;
			this.transition = DFA29_transition;
		}

		public override string Description { get { return "234:24: ( pointer )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition29(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA29_1 = input.LA(1);


				int index29_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred53_C_fragment)) ) {s = 51;}

				else if ( (true) ) {s = 2;}


				input.Seek(index29_1);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 29, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA32 : DFA
	{
		private const string DFA32_eotS =
			"\x12\xFFFF";
		private const string DFA32_eofS =
			"\x12\xFFFF";
		private const string DFA32_minS =
			"\x1\x19\x1\x4\x10\xFFFF";
		private const string DFA32_maxS =
			"\x1\x31\x1\x35\x10\xFFFF";
		private const string DFA32_acceptS =
			"\x2\xFFFF\x1\x2\x1\xFFFF\x1\x1\xD\xFFFF";
		private const string DFA32_specialS =
			"\x12\xFFFF}>";
		private static readonly string[] DFA32_transitionS =
			{
				"\x1\x1\x17\xFFFF\x1\x2",
				"\x1\x4\x16\xFFFF\xD\x4\x2\xFFFF\x2\x4\x1\xFFFF\x3\x4\x5\xFFFF\x1\x2",
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

		public override string Description { get { return "()* loopback of 244:26: ( ',' parameter_declaration )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA33 : DFA
	{
		private const string DFA33_eotS =
			"\x22\xFFFF";
		private const string DFA33_eofS =
			"\x1\x1\x21\xFFFF";
		private const string DFA33_minS =
			"\x1\x4\x3\xFFFF\x1\x0\x1\xFFFF\x1\x4\xA\xFFFF\x3\x0\xE\xFFFF";
		private const string DFA33_maxS =
			"\x1\x34\x3\xFFFF\x1\x0\x1\xFFFF\x1\x34\xA\xFFFF\x3\x0\xE\xFFFF";
		private const string DFA33_acceptS =
			"\x1\xFFFF\x1\x3\x3\xFFFF\x1\x1\x1\xFFFF\x1\x2\x1A\xFFFF";
		private const string DFA33_specialS =
			"\x4\xFFFF\x1\x0\xC\xFFFF\x1\x1\x1\x2\x1\x3\xE\xFFFF}>";
		private static readonly string[] DFA33_transitionS =
			{
				"\x1\x5\x14\xFFFF\x1\x1\x16\xFFFF\x1\x6\x1\x1\x1\x7\x1\xFFFF\x1\x4",
				"",
				"",
				"",
				"\x1\xFFFF",
				"",
				"\x1\x12\x16\xFFFF\xD\x7\x2\xFFFF\x2\x7\x1\xFFFF\x3\x7\x1\x13\x2\x7"+
				"\x1\xFFFF\x1\x11",
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
				""
			};

		private static readonly short[] DFA33_eot = DFA.UnpackEncodedString(DFA33_eotS);
		private static readonly short[] DFA33_eof = DFA.UnpackEncodedString(DFA33_eofS);
		private static readonly char[] DFA33_min = DFA.UnpackEncodedStringToUnsignedChars(DFA33_minS);
		private static readonly char[] DFA33_max = DFA.UnpackEncodedStringToUnsignedChars(DFA33_maxS);
		private static readonly short[] DFA33_accept = DFA.UnpackEncodedString(DFA33_acceptS);
		private static readonly short[] DFA33_special = DFA.UnpackEncodedString(DFA33_specialS);
		private static readonly short[][] DFA33_transition;

		static DFA33()
		{
			int numStates = DFA33_transitionS.Length;
			DFA33_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA33_transition[i] = DFA.UnpackEncodedString(DFA33_transitionS[i]);
			}
		}

		public DFA33( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 33;
			this.eot = DFA33_eot;
			this.eof = DFA33_eof;
			this.min = DFA33_min;
			this.max = DFA33_max;
			this.accept = DFA33_accept;
			this.special = DFA33_special;
			this.transition = DFA33_transition;
		}

		public override string Description { get { return "()* loopback of 248:27: ( declarator | abstract_declarator )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition33(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA33_4 = input.LA(1);


				int index33_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred58_C_fragment)) ) {s = 5;}

				else if ( (EvaluatePredicate(synpred59_C_fragment)) ) {s = 7;}


				input.Seek(index33_4);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA33_17 = input.LA(1);


				int index33_17 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred58_C_fragment)) ) {s = 5;}

				else if ( (EvaluatePredicate(synpred59_C_fragment)) ) {s = 7;}


				input.Seek(index33_17);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA33_18 = input.LA(1);


				int index33_18 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred58_C_fragment)) ) {s = 5;}

				else if ( (EvaluatePredicate(synpred59_C_fragment)) ) {s = 7;}


				input.Seek(index33_18);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA33_19 = input.LA(1);


				int index33_19 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred58_C_fragment)) ) {s = 5;}

				else if ( (EvaluatePredicate(synpred59_C_fragment)) ) {s = 7;}


				input.Seek(index33_19);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 33, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA36 : DFA
	{
		private const string DFA36_eotS =
			"\x28\xFFFF";
		private const string DFA36_eofS =
			"\x1\x3\x27\xFFFF";
		private const string DFA36_minS =
			"\x3\x4\x5\xFFFF\x1F\x0\x1\xFFFF";
		private const string DFA36_maxS =
			"\x2\x34\x1\x41\x5\xFFFF\x1F\x0\x1\xFFFF";
		private const string DFA36_acceptS =
			"\x3\xFFFF\x1\x2\x23\xFFFF\x1\x1";
		private const string DFA36_specialS =
			"\x8\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1\x9"+
			"\x1\xA\x1\xB\x1\xC\x1\xD\x1\xE\x1\xF\x1\x10\x1\x11\x1\x12\x1\x13\x1\x14"+
			"\x1\x15\x1\x16\x1\x17\x1\x18\x1\x19\x1\x1A\x1\x1B\x1\x1C\x1\x1D\x1\x1E"+
			"\x1\xFFFF}>";
		private static readonly string[] DFA36_transitionS =
			{
				"\x1\x3\x14\xFFFF\x1\x3\x16\xFFFF\x1\x1\x1\x3\x1\x2\x1\xFFFF\x1\x3",
				"\x1\x18\x16\xFFFF\x4\xC\x1\xD\x1\xE\x1\xF\x1\x10\x1\x11\x1\x12\x1"+
				"\x13\x1\x14\x1\x15\x2\xFFFF\x2\x16\x1\xFFFF\x1\x17\x2\x19\x1\xA\x1\x8"+
				"\x1\xB\x1\xFFFF\x1\x9",
				"\x1\x1C\x1\x1D\x1\x1E\x1\x1F\x1\x20\x1\x21\x1\x22\x25\xFFFF\x1\x1B"+
				"\x2\xFFFF\x1\x1A\x1\x25\x1\xFFFF\x2\x25\x2\xFFFF\x1\x23\x1\x24\x1\x26"+
				"\x2\xFFFF\x3\x25",
				"",
				"",
				"",
				"",
				"",
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
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				""
			};

		private static readonly short[] DFA36_eot = DFA.UnpackEncodedString(DFA36_eotS);
		private static readonly short[] DFA36_eof = DFA.UnpackEncodedString(DFA36_eofS);
		private static readonly char[] DFA36_min = DFA.UnpackEncodedStringToUnsignedChars(DFA36_minS);
		private static readonly char[] DFA36_max = DFA.UnpackEncodedStringToUnsignedChars(DFA36_maxS);
		private static readonly short[] DFA36_accept = DFA.UnpackEncodedString(DFA36_acceptS);
		private static readonly short[] DFA36_special = DFA.UnpackEncodedString(DFA36_specialS);
		private static readonly short[][] DFA36_transition;

		static DFA36()
		{
			int numStates = DFA36_transitionS.Length;
			DFA36_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA36_transition[i] = DFA.UnpackEncodedString(DFA36_transitionS[i]);
			}
		}

		public DFA36( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 36;
			this.eot = DFA36_eot;
			this.eof = DFA36_eof;
			this.min = DFA36_min;
			this.max = DFA36_max;
			this.accept = DFA36_accept;
			this.special = DFA36_special;
			this.transition = DFA36_transition;
		}

		public override string Description { get { return "260:12: ( direct_abstract_declarator )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition36(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA36_8 = input.LA(1);


				int index36_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_8);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA36_9 = input.LA(1);


				int index36_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_9);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA36_10 = input.LA(1);


				int index36_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_10);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA36_11 = input.LA(1);


				int index36_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_11);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA36_12 = input.LA(1);


				int index36_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_12);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA36_13 = input.LA(1);


				int index36_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_13);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA36_14 = input.LA(1);


				int index36_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_14);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA36_15 = input.LA(1);


				int index36_15 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_15);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA36_16 = input.LA(1);


				int index36_16 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_16);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA36_17 = input.LA(1);


				int index36_17 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_17);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA36_18 = input.LA(1);


				int index36_18 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_18);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA36_19 = input.LA(1);


				int index36_19 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_19);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA36_20 = input.LA(1);


				int index36_20 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_20);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA36_21 = input.LA(1);


				int index36_21 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_21);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA36_22 = input.LA(1);


				int index36_22 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_22);
				if ( s>=0 ) return s;
				break;
			case 15:
				int LA36_23 = input.LA(1);


				int index36_23 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_23);
				if ( s>=0 ) return s;
				break;
			case 16:
				int LA36_24 = input.LA(1);


				int index36_24 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_24);
				if ( s>=0 ) return s;
				break;
			case 17:
				int LA36_25 = input.LA(1);


				int index36_25 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_25);
				if ( s>=0 ) return s;
				break;
			case 18:
				int LA36_26 = input.LA(1);


				int index36_26 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_26);
				if ( s>=0 ) return s;
				break;
			case 19:
				int LA36_27 = input.LA(1);


				int index36_27 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_27);
				if ( s>=0 ) return s;
				break;
			case 20:
				int LA36_28 = input.LA(1);


				int index36_28 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_28);
				if ( s>=0 ) return s;
				break;
			case 21:
				int LA36_29 = input.LA(1);


				int index36_29 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_29);
				if ( s>=0 ) return s;
				break;
			case 22:
				int LA36_30 = input.LA(1);


				int index36_30 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_30);
				if ( s>=0 ) return s;
				break;
			case 23:
				int LA36_31 = input.LA(1);


				int index36_31 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_31);
				if ( s>=0 ) return s;
				break;
			case 24:
				int LA36_32 = input.LA(1);


				int index36_32 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_32);
				if ( s>=0 ) return s;
				break;
			case 25:
				int LA36_33 = input.LA(1);


				int index36_33 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_33);
				if ( s>=0 ) return s;
				break;
			case 26:
				int LA36_34 = input.LA(1);


				int index36_34 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_34);
				if ( s>=0 ) return s;
				break;
			case 27:
				int LA36_35 = input.LA(1);


				int index36_35 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_35);
				if ( s>=0 ) return s;
				break;
			case 28:
				int LA36_36 = input.LA(1);


				int index36_36 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_36);
				if ( s>=0 ) return s;
				break;
			case 29:
				int LA36_37 = input.LA(1);


				int index36_37 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_37);
				if ( s>=0 ) return s;
				break;
			case 30:
				int LA36_38 = input.LA(1);


				int index36_38 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred62_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 3;}


				input.Seek(index36_38);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 36, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA38 : DFA
	{
		private const string DFA38_eotS =
			"\x15\xFFFF";
		private const string DFA38_eofS =
			"\x15\xFFFF";
		private const string DFA38_minS =
			"\x1\x30\x1\x4\x13\xFFFF";
		private const string DFA38_maxS =
			"\x1\x32\x1\x34\x13\xFFFF";
		private const string DFA38_acceptS =
			"\x2\xFFFF\x1\x2\x1\xFFFF\x1\x1\x10\xFFFF";
		private const string DFA38_specialS =
			"\x15\xFFFF}>";
		private static readonly string[] DFA38_transitionS =
			{
				"\x1\x1\x1\xFFFF\x1\x2",
				"\x1\x2\x16\xFFFF\xD\x2\x2\xFFFF\x2\x2\x1\xFFFF\x3\x2\x1\x4\x1\x2\x1"+
				"\x4\x1\xFFFF\x1\x4",
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

		private static readonly short[] DFA38_eot = DFA.UnpackEncodedString(DFA38_eotS);
		private static readonly short[] DFA38_eof = DFA.UnpackEncodedString(DFA38_eofS);
		private static readonly char[] DFA38_min = DFA.UnpackEncodedStringToUnsignedChars(DFA38_minS);
		private static readonly char[] DFA38_max = DFA.UnpackEncodedStringToUnsignedChars(DFA38_maxS);
		private static readonly short[] DFA38_accept = DFA.UnpackEncodedString(DFA38_acceptS);
		private static readonly short[] DFA38_special = DFA.UnpackEncodedString(DFA38_specialS);
		private static readonly short[][] DFA38_transition;

		static DFA38()
		{
			int numStates = DFA38_transitionS.Length;
			DFA38_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA38_transition[i] = DFA.UnpackEncodedString(DFA38_transitionS[i]);
			}
		}

		public DFA38( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 38;
			this.eot = DFA38_eot;
			this.eof = DFA38_eof;
			this.min = DFA38_min;
			this.max = DFA38_max;
			this.accept = DFA38_accept;
			this.special = DFA38_special;
			this.transition = DFA38_transition;
		}

		public override string Description { get { return "265:4: ( '(' abstract_declarator ')' | abstract_declarator_suffix )"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA39 : DFA
	{
		private const string DFA39_eotS =
			"\x28\xFFFF";
		private const string DFA39_eofS =
			"\x1\x1\x27\xFFFF";
		private const string DFA39_minS =
			"\x1\x4\x5\xFFFF\x2\x4\x1\x0\x1\xFFFF\x1\x0\x2\xFFFF\x1A\x0\x1\xFFFF";
		private const string DFA39_maxS =
			"\x1\x34\x5\xFFFF\x1\x34\x1\x41\x1\x0\x1\xFFFF\x1\x0\x2\xFFFF\x1A\x0"+
			"\x1\xFFFF";
		private const string DFA39_acceptS =
			"\x1\xFFFF\x1\x2\x25\xFFFF\x1\x1";
		private const string DFA39_specialS =
			"\x8\xFFFF\x1\x0\x1\xFFFF\x1\x1\x2\xFFFF\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6"+
			"\x1\x7\x1\x8\x1\x9\x1\xA\x1\xB\x1\xC\x1\xD\x1\xE\x1\xF\x1\x10\x1\x11"+
			"\x1\x12\x1\x13\x1\x14\x1\x15\x1\x16\x1\x17\x1\x18\x1\x19\x1\x1A\x1\x1B"+
			"\x1\xFFFF}>";
		private static readonly string[] DFA39_transitionS =
			{
				"\x1\x1\x14\xFFFF\x1\x1\x16\xFFFF\x1\x6\x1\x1\x1\x7\x1\xFFFF\x1\x1",
				"",
				"",
				"",
				"",
				"",
				"\x1\xA\x16\xFFFF\x4\xD\x1\xE\x1\xF\x1\x10\x1\x11\x1\x12\x1\x13\x1"+
				"\x14\x1\x15\x1\x16\x2\xFFFF\x2\x17\x1\xFFFF\x1\x18\x2\x19\x1\x1\x1\x8"+
				"\x1\x1\x1\xFFFF\x1\x1",
				"\x1\x1C\x1\x1D\x1\x1E\x1\x1F\x1\x20\x1\x21\x1\x22\x25\xFFFF\x1\x1B"+
				"\x2\xFFFF\x1\x1A\x1\x25\x1\xFFFF\x2\x25\x2\xFFFF\x1\x23\x1\x24\x1\x26"+
				"\x2\xFFFF\x3\x25",
				"\x1\xFFFF",
				"",
				"\x1\xFFFF",
				"",
				"",
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

		public DFA39( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "()* loopback of 265:65: ( abstract_declarator_suffix )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition39(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA39_8 = input.LA(1);


				int index39_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_8);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA39_10 = input.LA(1);


				int index39_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_10);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA39_13 = input.LA(1);


				int index39_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_13);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA39_14 = input.LA(1);


				int index39_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_14);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA39_15 = input.LA(1);


				int index39_15 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_15);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA39_16 = input.LA(1);


				int index39_16 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_16);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA39_17 = input.LA(1);


				int index39_17 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_17);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA39_18 = input.LA(1);


				int index39_18 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_18);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA39_19 = input.LA(1);


				int index39_19 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_19);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA39_20 = input.LA(1);


				int index39_20 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_20);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA39_21 = input.LA(1);


				int index39_21 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_21);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA39_22 = input.LA(1);


				int index39_22 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_22);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA39_23 = input.LA(1);


				int index39_23 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_23);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA39_24 = input.LA(1);


				int index39_24 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_24);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA39_25 = input.LA(1);


				int index39_25 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_25);
				if ( s>=0 ) return s;
				break;
			case 15:
				int LA39_26 = input.LA(1);


				int index39_26 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_26);
				if ( s>=0 ) return s;
				break;
			case 16:
				int LA39_27 = input.LA(1);


				int index39_27 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_27);
				if ( s>=0 ) return s;
				break;
			case 17:
				int LA39_28 = input.LA(1);


				int index39_28 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_28);
				if ( s>=0 ) return s;
				break;
			case 18:
				int LA39_29 = input.LA(1);


				int index39_29 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_29);
				if ( s>=0 ) return s;
				break;
			case 19:
				int LA39_30 = input.LA(1);


				int index39_30 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_30);
				if ( s>=0 ) return s;
				break;
			case 20:
				int LA39_31 = input.LA(1);


				int index39_31 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_31);
				if ( s>=0 ) return s;
				break;
			case 21:
				int LA39_32 = input.LA(1);


				int index39_32 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_32);
				if ( s>=0 ) return s;
				break;
			case 22:
				int LA39_33 = input.LA(1);


				int index39_33 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_33);
				if ( s>=0 ) return s;
				break;
			case 23:
				int LA39_34 = input.LA(1);


				int index39_34 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_34);
				if ( s>=0 ) return s;
				break;
			case 24:
				int LA39_35 = input.LA(1);


				int index39_35 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_35);
				if ( s>=0 ) return s;
				break;
			case 25:
				int LA39_36 = input.LA(1);


				int index39_36 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_36);
				if ( s>=0 ) return s;
				break;
			case 26:
				int LA39_37 = input.LA(1);


				int index39_37 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_37);
				if ( s>=0 ) return s;
				break;
			case 27:
				int LA39_38 = input.LA(1);


				int index39_38 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred65_C_fragment)) ) {s = 39;}

				else if ( (true) ) {s = 1;}


				input.Seek(index39_38);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 39, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA40 : DFA
	{
		private const string DFA40_eotS =
			"\x1F\xFFFF";
		private const string DFA40_eofS =
			"\x1F\xFFFF";
		private const string DFA40_minS =
			"\x1\x30\x2\x4\x1C\xFFFF";
		private const string DFA40_maxS =
			"\x1\x32\x1\x41\x1\x31\x1C\xFFFF";
		private const string DFA40_acceptS =
			"\x3\xFFFF\x1\x1\x1\x2\xB\xFFFF\x1\x3\x1\x4\xD\xFFFF";
		private const string DFA40_specialS =
			"\x1F\xFFFF}>";
		private static readonly string[] DFA40_transitionS =
			{
				"\x1\x2\x1\xFFFF\x1\x1",
				"\x7\x4\x25\xFFFF\x1\x4\x2\xFFFF\x1\x3\x1\x4\x1\xFFFF\x2\x4\x2\xFFFF"+
				"\x3\x4\x2\xFFFF\x3\x4",
				"\x1\x11\x16\xFFFF\xD\x11\x2\xFFFF\x2\x11\x1\xFFFF\x3\x11\x1\xFFFF"+
				"\x1\x10",
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

		private static readonly short[] DFA40_eot = DFA.UnpackEncodedString(DFA40_eotS);
		private static readonly short[] DFA40_eof = DFA.UnpackEncodedString(DFA40_eofS);
		private static readonly char[] DFA40_min = DFA.UnpackEncodedStringToUnsignedChars(DFA40_minS);
		private static readonly char[] DFA40_max = DFA.UnpackEncodedStringToUnsignedChars(DFA40_maxS);
		private static readonly short[] DFA40_accept = DFA.UnpackEncodedString(DFA40_acceptS);
		private static readonly short[] DFA40_special = DFA.UnpackEncodedString(DFA40_specialS);
		private static readonly short[][] DFA40_transition;

		static DFA40()
		{
			int numStates = DFA40_transitionS.Length;
			DFA40_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA40_transition[i] = DFA.UnpackEncodedString(DFA40_transitionS[i]);
			}
		}

		public DFA40( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 40;
			this.eot = DFA40_eot;
			this.eof = DFA40_eof;
			this.min = DFA40_min;
			this.max = DFA40_max;
			this.accept = DFA40_accept;
			this.special = DFA40_special;
			this.transition = DFA40_transition;
		}

		public override string Description { get { return "268:1: abstract_declarator_suffix : ( '[' ']' | '[' constant_expression ']' | '(' ')' | '(' parameter_type_list ')' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA42 : DFA
	{
		private const string DFA42_eotS =
			"\xE\xFFFF";
		private const string DFA42_eofS =
			"\xE\xFFFF";
		private const string DFA42_minS =
			"\x1\x4\xD\xFFFF";
		private const string DFA42_maxS =
			"\x1\x41\xD\xFFFF";
		private const string DFA42_acceptS =
			"\x1\xFFFF\x1\x1\xB\xFFFF\x1\x2";
		private const string DFA42_specialS =
			"\xE\xFFFF}>";
		private static readonly string[] DFA42_transitionS =
			{
				"\x7\x1\x1D\xFFFF\x1\xD\x7\xFFFF\x1\x1\x3\xFFFF\x1\x1\x1\xFFFF\x2\x1"+
				"\x2\xFFFF\x3\x1\x2\xFFFF\x3\x1",
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

		private static readonly short[] DFA42_eot = DFA.UnpackEncodedString(DFA42_eotS);
		private static readonly short[] DFA42_eof = DFA.UnpackEncodedString(DFA42_eofS);
		private static readonly char[] DFA42_min = DFA.UnpackEncodedStringToUnsignedChars(DFA42_minS);
		private static readonly char[] DFA42_max = DFA.UnpackEncodedStringToUnsignedChars(DFA42_maxS);
		private static readonly short[] DFA42_accept = DFA.UnpackEncodedString(DFA42_acceptS);
		private static readonly short[] DFA42_special = DFA.UnpackEncodedString(DFA42_specialS);
		private static readonly short[][] DFA42_transition;

		static DFA42()
		{
			int numStates = DFA42_transitionS.Length;
			DFA42_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA42_transition[i] = DFA.UnpackEncodedString(DFA42_transitionS[i]);
			}
		}

		public DFA42( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 42;
			this.eot = DFA42_eot;
			this.eof = DFA42_eof;
			this.min = DFA42_min;
			this.max = DFA42_max;
			this.accept = DFA42_accept;
			this.special = DFA42_special;
			this.transition = DFA42_transition;
		}

		public override string Description { get { return "275:1: initializer : ( assignment_expression | '{' initializer_list ( ',' )? '}' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA43 : DFA
	{
		private const string DFA43_eotS =
			"\x11\xFFFF";
		private const string DFA43_eofS =
			"\x11\xFFFF";
		private const string DFA43_minS =
			"\x1\x19\x1\x4\xF\xFFFF";
		private const string DFA43_maxS =
			"\x1\x29\x1\x41\xF\xFFFF";
		private const string DFA43_acceptS =
			"\x2\xFFFF\x1\x2\x1\xFFFF\x1\x1\xC\xFFFF";
		private const string DFA43_specialS =
			"\x11\xFFFF}>";
		private static readonly string[] DFA43_transitionS =
			{
				"\x1\x1\xF\xFFFF\x1\x2",
				"\x7\x4\x1D\xFFFF\x1\x4\x1\x2\x6\xFFFF\x1\x4\x3\xFFFF\x1\x4\x1\xFFFF"+
				"\x2\x4\x2\xFFFF\x3\x4\x2\xFFFF\x3\x4",
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

		private static readonly short[] DFA43_eot = DFA.UnpackEncodedString(DFA43_eotS);
		private static readonly short[] DFA43_eof = DFA.UnpackEncodedString(DFA43_eofS);
		private static readonly char[] DFA43_min = DFA.UnpackEncodedStringToUnsignedChars(DFA43_minS);
		private static readonly char[] DFA43_max = DFA.UnpackEncodedStringToUnsignedChars(DFA43_maxS);
		private static readonly short[] DFA43_accept = DFA.UnpackEncodedString(DFA43_acceptS);
		private static readonly short[] DFA43_special = DFA.UnpackEncodedString(DFA43_specialS);
		private static readonly short[][] DFA43_transition;

		static DFA43()
		{
			int numStates = DFA43_transitionS.Length;
			DFA43_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA43_transition[i] = DFA.UnpackEncodedString(DFA43_transitionS[i]);
			}
		}

		public DFA43( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 43;
			this.eot = DFA43_eot;
			this.eof = DFA43_eof;
			this.min = DFA43_min;
			this.max = DFA43_max;
			this.accept = DFA43_accept;
			this.special = DFA43_special;
			this.transition = DFA43_transition;
		}

		public override string Description { get { return "()* loopback of 281:16: ( ',' initializer )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA45 : DFA
	{
		private const string DFA45_eotS =
			"\x13\xFFFF";
		private const string DFA45_eofS =
			"\x1\x1\x12\xFFFF";
		private const string DFA45_minS =
			"\x1\x18\x12\xFFFF";
		private const string DFA45_maxS =
			"\x1\x58\x12\xFFFF";
		private const string DFA45_acceptS =
			"\x1\xFFFF\x1\x3\xF\xFFFF\x1\x1\x1\x2";
		private const string DFA45_specialS =
			"\x13\xFFFF}>";
		private static readonly string[] DFA45_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\x2\xFFFF\x1\x11\x1\x12\x7\xFFFF\x1\x1\xC\xFFFF\xD\x1",
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

		private static readonly short[] DFA45_eot = DFA.UnpackEncodedString(DFA45_eotS);
		private static readonly short[] DFA45_eof = DFA.UnpackEncodedString(DFA45_eofS);
		private static readonly char[] DFA45_min = DFA.UnpackEncodedStringToUnsignedChars(DFA45_minS);
		private static readonly char[] DFA45_max = DFA.UnpackEncodedStringToUnsignedChars(DFA45_maxS);
		private static readonly short[] DFA45_accept = DFA.UnpackEncodedString(DFA45_acceptS);
		private static readonly short[] DFA45_special = DFA.UnpackEncodedString(DFA45_specialS);
		private static readonly short[][] DFA45_transition;

		static DFA45()
		{
			int numStates = DFA45_transitionS.Length;
			DFA45_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA45_transition[i] = DFA.UnpackEncodedString(DFA45_transitionS[i]);
			}
		}

		public DFA45( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 45;
			this.eot = DFA45_eot;
			this.eof = DFA45_eof;
			this.min = DFA45_min;
			this.max = DFA45_max;
			this.accept = DFA45_accept;
			this.special = DFA45_special;
			this.transition = DFA45_transition;
		}

		public override string Description { get { return "()* loopback of 291:32: ( '+' multiplicative_expression | '-' multiplicative_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA46 : DFA
	{
		private const string DFA46_eotS =
			"\x16\xFFFF";
		private const string DFA46_eofS =
			"\x1\x1\x15\xFFFF";
		private const string DFA46_minS =
			"\x1\x18\x15\xFFFF";
		private const string DFA46_maxS =
			"\x1\x58\x15\xFFFF";
		private const string DFA46_acceptS =
			"\x1\xFFFF\x1\x4\x11\xFFFF\x1\x1\x1\x2\x1\x3";
		private const string DFA46_specialS =
			"\x16\xFFFF}>";
		private static readonly string[] DFA46_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\x1\x13\x1\xFFFF\x2\x1\x1\x14\x1\x15\x5\xFFFF\x1\x1\xC\xFFFF\xD\x1",
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

		private static readonly short[] DFA46_eot = DFA.UnpackEncodedString(DFA46_eotS);
		private static readonly short[] DFA46_eof = DFA.UnpackEncodedString(DFA46_eofS);
		private static readonly char[] DFA46_min = DFA.UnpackEncodedStringToUnsignedChars(DFA46_minS);
		private static readonly char[] DFA46_max = DFA.UnpackEncodedStringToUnsignedChars(DFA46_maxS);
		private static readonly short[] DFA46_accept = DFA.UnpackEncodedString(DFA46_acceptS);
		private static readonly short[] DFA46_special = DFA.UnpackEncodedString(DFA46_specialS);
		private static readonly short[][] DFA46_transition;

		static DFA46()
		{
			int numStates = DFA46_transitionS.Length;
			DFA46_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA46_transition[i] = DFA.UnpackEncodedString(DFA46_transitionS[i]);
			}
		}

		public DFA46( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 46;
			this.eot = DFA46_eot;
			this.eof = DFA46_eof;
			this.min = DFA46_min;
			this.max = DFA46_max;
			this.accept = DFA46_accept;
			this.special = DFA46_special;
			this.transition = DFA46_transition;
		}

		public override string Description { get { return "()* loopback of 295:22: ( '*' cast_expression | '/' cast_expression | '%' cast_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA47 : DFA
	{
		private const string DFA47_eotS =
			"\x25\xFFFF";
		private const string DFA47_eofS =
			"\x25\xFFFF";
		private const string DFA47_minS =
			"\x2\x4\x17\xFFFF\x1\x0\xB\xFFFF";
		private const string DFA47_maxS =
			"\x2\x41\x17\xFFFF\x1\x0\xB\xFFFF";
		private const string DFA47_acceptS =
			"\x2\xFFFF\x1\x2\xA\xFFFF\x1\x1\x17\xFFFF";
		private const string DFA47_specialS =
			"\x19\xFFFF\x1\x0\xB\xFFFF}>";
		private static readonly string[] DFA47_transitionS =
			{
				"\x7\x2\x25\xFFFF\x1\x1\x3\xFFFF\x1\x2\x1\xFFFF\x2\x2\x2\xFFFF\x3\x2"+
				"\x2\xFFFF\x3\x2",
				"\x1\x19\x6\x2\x14\xFFFF\x9\xD\x2\xFFFF\x2\xD\x1\xFFFF\x3\xD\x1\x2"+
				"\x3\xFFFF\x1\x2\x1\xFFFF\x2\x2\x2\xFFFF\x3\x2\x2\xFFFF\x3\x2",
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
				""
			};

		private static readonly short[] DFA47_eot = DFA.UnpackEncodedString(DFA47_eotS);
		private static readonly short[] DFA47_eof = DFA.UnpackEncodedString(DFA47_eofS);
		private static readonly char[] DFA47_min = DFA.UnpackEncodedStringToUnsignedChars(DFA47_minS);
		private static readonly char[] DFA47_max = DFA.UnpackEncodedStringToUnsignedChars(DFA47_maxS);
		private static readonly short[] DFA47_accept = DFA.UnpackEncodedString(DFA47_acceptS);
		private static readonly short[] DFA47_special = DFA.UnpackEncodedString(DFA47_specialS);
		private static readonly short[][] DFA47_transition;

		static DFA47()
		{
			int numStates = DFA47_transitionS.Length;
			DFA47_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA47_transition[i] = DFA.UnpackEncodedString(DFA47_transitionS[i]);
			}
		}

		public DFA47( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 47;
			this.eot = DFA47_eot;
			this.eof = DFA47_eof;
			this.min = DFA47_min;
			this.max = DFA47_max;
			this.accept = DFA47_accept;
			this.special = DFA47_special;
			this.transition = DFA47_transition;
		}

		public override string Description { get { return "298:1: cast_expression : ( '(' type_name ')' cast_expression | unary_expression );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition47(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA47_25 = input.LA(1);


				int index47_25 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred78_C_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 2;}


				input.Seek(index47_25);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 47, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA48 : DFA
	{
		private const string DFA48_eotS =
			"\x1A\xFFFF";
		private const string DFA48_eofS =
			"\x1A\xFFFF";
		private const string DFA48_minS =
			"\x1\x4\xB\xFFFF\x1\x4\x1\x0\xC\xFFFF";
		private const string DFA48_maxS =
			"\x1\x41\xB\xFFFF\x1\x41\x1\x0\xC\xFFFF";
		private const string DFA48_acceptS =
			"\x1\xFFFF\x1\x1\x7\xFFFF\x1\x2\x1\x3\x1\x4\x2\xFFFF\x1\x5\xA\xFFFF\x1"+
			"\x6";
		private const string DFA48_specialS =
			"\xD\xFFFF\x1\x0\xC\xFFFF}>";
		private static readonly string[] DFA48_transitionS =
			{
				"\x7\x1\x25\xFFFF\x1\x1\x3\xFFFF\x1\xB\x1\xFFFF\x2\xB\x2\xFFFF\x1\x9"+
				"\x1\xA\x1\xC\x2\xFFFF\x3\xB",
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
				"\x7\xE\x25\xFFFF\x1\xD\x3\xFFFF\x1\xE\x1\xFFFF\x2\xE\x2\xFFFF\x3\xE"+
				"\x2\xFFFF\x3\xE",
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
				""
			};

		private static readonly short[] DFA48_eot = DFA.UnpackEncodedString(DFA48_eotS);
		private static readonly short[] DFA48_eof = DFA.UnpackEncodedString(DFA48_eofS);
		private static readonly char[] DFA48_min = DFA.UnpackEncodedStringToUnsignedChars(DFA48_minS);
		private static readonly char[] DFA48_max = DFA.UnpackEncodedStringToUnsignedChars(DFA48_maxS);
		private static readonly short[] DFA48_accept = DFA.UnpackEncodedString(DFA48_acceptS);
		private static readonly short[] DFA48_special = DFA.UnpackEncodedString(DFA48_specialS);
		private static readonly short[][] DFA48_transition;

		static DFA48()
		{
			int numStates = DFA48_transitionS.Length;
			DFA48_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA48_transition[i] = DFA.UnpackEncodedString(DFA48_transitionS[i]);
			}
		}

		public DFA48( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 48;
			this.eot = DFA48_eot;
			this.eof = DFA48_eof;
			this.min = DFA48_min;
			this.max = DFA48_max;
			this.accept = DFA48_accept;
			this.special = DFA48_special;
			this.transition = DFA48_transition;
		}

		public override string Description { get { return "303:1: unary_expression : ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' unary_expression | 'sizeof' '(' type_name ')' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition48(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA48_13 = input.LA(1);


				int index48_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred83_C_fragment)) ) {s = 14;}

				else if ( (true) ) {s = 25;}


				input.Seek(index48_13);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 48, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA49 : DFA
	{
		private const string DFA49_eotS =
			"\x2A\xFFFF";
		private const string DFA49_eofS =
			"\x1\x1\x29\xFFFF";
		private const string DFA49_minS =
			"\x1\x18\x17\xFFFF\x1\x4\x11\xFFFF";
		private const string DFA49_maxS =
			"\x1\x58\x17\xFFFF\x1\x41\x11\xFFFF";
		private const string DFA49_acceptS =
			"\x1\xFFFF\x1\x8\x15\xFFFF\x1\x1\x1\xFFFF\x1\x4\x1\x5\x1\x6\x1\x7\x1"+
			"\x2\x1\x3\xB\xFFFF";
		private const string DFA49_specialS =
			"\x2A\xFFFF}>";
		private static readonly string[] DFA49_transitionS =
			{
				"\x3\x1\xE\xFFFF\x1\x1\x2\xFFFF\x1\x1\x3\xFFFF\x1\x18\x1\x1\x1\x17\x2"+
				"\x1\x1\xFFFF\x4\x1\x1\x1B\x1\x1C\x1\xFFFF\x1\x19\x1\x1A\x1\x1\x2\xFFFF"+
				"\x17\x1",
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
				"\x7\x1E\x25\xFFFF\x1\x1E\x1\x1D\x2\xFFFF\x1\x1E\x1\xFFFF\x2\x1E\x2"+
				"\xFFFF\x3\x1E\x2\xFFFF\x3\x1E",
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

		private static readonly short[] DFA49_eot = DFA.UnpackEncodedString(DFA49_eotS);
		private static readonly short[] DFA49_eof = DFA.UnpackEncodedString(DFA49_eofS);
		private static readonly char[] DFA49_min = DFA.UnpackEncodedStringToUnsignedChars(DFA49_minS);
		private static readonly char[] DFA49_max = DFA.UnpackEncodedStringToUnsignedChars(DFA49_maxS);
		private static readonly short[] DFA49_accept = DFA.UnpackEncodedString(DFA49_acceptS);
		private static readonly short[] DFA49_special = DFA.UnpackEncodedString(DFA49_specialS);
		private static readonly short[][] DFA49_transition;

		static DFA49()
		{
			int numStates = DFA49_transitionS.Length;
			DFA49_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA49_transition[i] = DFA.UnpackEncodedString(DFA49_transitionS[i]);
			}
		}

		public DFA49( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 49;
			this.eot = DFA49_eot;
			this.eof = DFA49_eof;
			this.min = DFA49_min;
			this.max = DFA49_max;
			this.accept = DFA49_accept;
			this.special = DFA49_special;
			this.transition = DFA49_transition;
		}

		public override string Description { get { return "()* loopback of 314:9: ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA53 : DFA
	{
		private const string DFA53_eotS =
			"\x119\xFFFF";
		private const string DFA53_eofS =
			"\x1\xFFFF\x7\x14\x111\xFFFF";
		private const string DFA53_minS =
			"\x1\x4\x7\x18\x5\x4\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF"+
			"\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\xC\x0"+
			"\xC\xFFFF\x30\x0";
		private const string DFA53_maxS =
			"\x1\x41\x7\x58\x5\x41\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF"+
			"\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\x6\x0\x16\xFFFF\xC\x0"+
			"\xC\xFFFF\x30\x0";
		private const string DFA53_acceptS =
			"\x13\xFFFF\x1\x1\x1\x2\x104\xFFFF";
		private const string DFA53_specialS =
			"\xD\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x16\xFFFF\x1\x6\x1\x7"+
			"\x1\x8\x1\x9\x1\xA\x1\xB\x16\xFFFF\x1\xC\x1\xD\x1\xE\x1\xF\x1\x10\x1"+
			"\x11\x16\xFFFF\x1\x12\x1\x13\x1\x14\x1\x15\x1\x16\x1\x17\x16\xFFFF\x1"+
			"\x18\x1\x19\x1\x1A\x1\x1B\x1\x1C\x1\x1D\x16\xFFFF\x1\x1E\x1\x1F\x1\x20"+
			"\x1\x21\x1\x22\x1\x23\x16\xFFFF\x1\x24\x1\x25\x1\x26\x1\x27\x1\x28\x1"+
			"\x29\x16\xFFFF\x1\x2A\x1\x2B\x1\x2C\x1\x2D\x1\x2E\x1\x2F\x1\x30\x1\x31"+
			"\x1\x32\x1\x33\x1\x34\x1\x35\xC\xFFFF\x1\x36\x1\x37\x1\x38\x1\x39\x1"+
			"\x3A\x1\x3B\x1\x3C\x1\x3D\x1\x3E\x1\x3F\x1\x40\x1\x41\x1\x42\x1\x43\x1"+
			"\x44\x1\x45\x1\x46\x1\x47\x1\x48\x1\x49\x1\x4A\x1\x4B\x1\x4C\x1\x4D\x1"+
			"\x4E\x1\x4F\x1\x50\x1\x51\x1\x52\x1\x53\x1\x54\x1\x55\x1\x56\x1\x57\x1"+
			"\x58\x1\x59\x1\x5A\x1\x5B\x1\x5C\x1\x5D\x1\x5E\x1\x5F\x1\x60\x1\x61\x1"+
			"\x62\x1\x63\x1\x64\x1\x65}>";
		private static readonly string[] DFA53_transitionS =
			{
				"\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x25\xFFFF\x1\x8\x3\xFFFF"+
				"\x1\xB\x1\xFFFF\x2\xB\x2\xFFFF\x1\x9\x1\xA\x1\xC\x2\xFFFF\x3\xB",
				"\x2\x14\x1\x13\xE\xFFFF\x1\x14\x2\xFFFF\x1\x14\x3\xFFFF\x1\xE\x1\x14"+
				"\x1\xD\x2\x14\x1\xFFFF\x4\x14\x1\x11\x1\x12\x1\xFFFF\x1\xF\x1\x10\x1"+
				"\x14\x2\xFFFF\xA\x13\xD\x14",
				"\x2\x14\x1\x13\xE\xFFFF\x1\x14\x2\xFFFF\x1\x14\x3\xFFFF\x1\x2A\x1"+
				"\x14\x1\x29\x2\x14\x1\xFFFF\x4\x14\x1\x2D\x1\x2E\x1\xFFFF\x1\x2B\x1"+
				"\x2C\x1\x14\x2\xFFFF\xA\x13\xD\x14",
				"\x2\x14\x1\x13\xE\xFFFF\x1\x14\x2\xFFFF\x1\x14\x3\xFFFF\x1\x46\x1"+
				"\x14\x1\x45\x2\x14\x1\xFFFF\x4\x14\x1\x49\x1\x4A\x1\xFFFF\x1\x47\x1"+
				"\x48\x1\x14\x2\xFFFF\xA\x13\xD\x14",
				"\x2\x14\x1\x13\xE\xFFFF\x1\x14\x2\xFFFF\x1\x14\x3\xFFFF\x1\x62\x1"+
				"\x14\x1\x61\x2\x14\x1\xFFFF\x4\x14\x1\x65\x1\x66\x1\xFFFF\x1\x63\x1"+
				"\x64\x1\x14\x2\xFFFF\xA\x13\xD\x14",
				"\x2\x14\x1\x13\xE\xFFFF\x1\x14\x2\xFFFF\x1\x14\x3\xFFFF\x1\x7E\x1"+
				"\x14\x1\x7D\x2\x14\x1\xFFFF\x4\x14\x1\x81\x1\x82\x1\xFFFF\x1\x7F\x1"+
				"\x80\x1\x14\x2\xFFFF\xA\x13\xD\x14",
				"\x2\x14\x1\x13\xE\xFFFF\x1\x14\x2\xFFFF\x1\x14\x3\xFFFF\x1\x9A\x1"+
				"\x14\x1\x99\x2\x14\x1\xFFFF\x4\x14\x1\x9D\x1\x9E\x1\xFFFF\x1\x9B\x1"+
				"\x9C\x1\x14\x2\xFFFF\xA\x13\xD\x14",
				"\x2\x14\x1\x13\xE\xFFFF\x1\x14\x2\xFFFF\x1\x14\x3\xFFFF\x1\xB6\x1"+
				"\x14\x1\xB5\x2\x14\x1\xFFFF\x4\x14\x1\xB9\x1\xBA\x1\xFFFF\x1\xB7\x1"+
				"\xB8\x1\x14\x2\xFFFF\xA\x13\xD\x14",
				"\x1\xD1\x1\xD2\x1\xD3\x1\xD4\x1\xD5\x1\xD6\x1\xD7\x14\xFFFF\x9\x14"+
				"\x2\xFFFF\x2\x14\x1\xFFFF\x3\x14\x1\xD8\x3\xFFFF\x1\xDB\x1\xFFFF\x2"+
				"\xDB\x2\xFFFF\x1\xD9\x1\xDA\x1\xDC\x2\xFFFF\x3\xDB",
				"\x1\xE9\x1\xEA\x1\xEB\x1\xEC\x1\xED\x1\xEE\x1\xEF\x25\xFFFF\x1\xF0"+
				"\x3\xFFFF\x1\xF3\x1\xFFFF\x2\xF3\x2\xFFFF\x1\xF1\x1\xF2\x1\xF4\x2\xFFFF"+
				"\x3\xF3",
				"\x1\xF5\x1\xF6\x1\xF7\x1\xF8\x1\xF9\x1\xFA\x1\xFB\x25\xFFFF\x1\xFC"+
				"\x3\xFFFF\x1\xFF\x1\xFFFF\x2\xFF\x2\xFFFF\x1\xFD\x1\xFE\x1\x100\x2\xFFFF"+
				"\x3\xFF",
				"\x1\x102\x1\x103\x1\x104\x1\x105\x1\x106\x1\x107\x1\x108\x25\xFFFF"+
				"\x1\x101\x3\xFFFF\x1\x10B\x1\xFFFF\x2\x10B\x2\xFFFF\x1\x109\x1\x10A"+
				"\x1\x10C\x2\xFFFF\x3\x10B",
				"\x1\x10E\x1\x10F\x1\x110\x1\x111\x1\x112\x1\x113\x1\x114\x25\xFFFF"+
				"\x1\x10D\x3\xFFFF\x1\x117\x1\xFFFF\x2\x117\x2\xFFFF\x1\x115\x1\x116"+
				"\x1\x118\x2\xFFFF\x3\x117",
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
				"",
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
				"",
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
				"",
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
				"",
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
				"",
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
				"",
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
				"",
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
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF",
				"\x1\xFFFF"
			};

		private static readonly short[] DFA53_eot = DFA.UnpackEncodedString(DFA53_eotS);
		private static readonly short[] DFA53_eof = DFA.UnpackEncodedString(DFA53_eofS);
		private static readonly char[] DFA53_min = DFA.UnpackEncodedStringToUnsignedChars(DFA53_minS);
		private static readonly char[] DFA53_max = DFA.UnpackEncodedStringToUnsignedChars(DFA53_maxS);
		private static readonly short[] DFA53_accept = DFA.UnpackEncodedString(DFA53_acceptS);
		private static readonly short[] DFA53_special = DFA.UnpackEncodedString(DFA53_specialS);
		private static readonly short[][] DFA53_transition;

		static DFA53()
		{
			int numStates = DFA53_transitionS.Length;
			DFA53_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA53_transition[i] = DFA.UnpackEncodedString(DFA53_transitionS[i]);
			}
		}

		public DFA53( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 53;
			this.eot = DFA53_eot;
			this.eof = DFA53_eof;
			this.min = DFA53_min;
			this.max = DFA53_max;
			this.accept = DFA53_accept;
			this.special = DFA53_special;
			this.transition = DFA53_transition;
		}

		public override string Description { get { return "382:1: assignment_expression : ( lvalue assignment_operator assignment_expression | conditional_expression );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition53(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA53_13 = input.LA(1);


				int index53_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_13);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA53_14 = input.LA(1);


				int index53_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_14);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA53_15 = input.LA(1);


				int index53_15 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_15);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA53_16 = input.LA(1);


				int index53_16 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_16);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA53_17 = input.LA(1);


				int index53_17 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_17);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA53_18 = input.LA(1);


				int index53_18 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_18);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA53_41 = input.LA(1);


				int index53_41 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_41);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA53_42 = input.LA(1);


				int index53_42 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_42);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA53_43 = input.LA(1);


				int index53_43 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_43);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA53_44 = input.LA(1);


				int index53_44 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_44);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA53_45 = input.LA(1);


				int index53_45 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_45);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA53_46 = input.LA(1);


				int index53_46 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_46);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA53_69 = input.LA(1);


				int index53_69 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_69);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA53_70 = input.LA(1);


				int index53_70 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_70);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA53_71 = input.LA(1);


				int index53_71 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_71);
				if ( s>=0 ) return s;
				break;
			case 15:
				int LA53_72 = input.LA(1);


				int index53_72 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_72);
				if ( s>=0 ) return s;
				break;
			case 16:
				int LA53_73 = input.LA(1);


				int index53_73 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_73);
				if ( s>=0 ) return s;
				break;
			case 17:
				int LA53_74 = input.LA(1);


				int index53_74 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_74);
				if ( s>=0 ) return s;
				break;
			case 18:
				int LA53_97 = input.LA(1);


				int index53_97 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_97);
				if ( s>=0 ) return s;
				break;
			case 19:
				int LA53_98 = input.LA(1);


				int index53_98 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_98);
				if ( s>=0 ) return s;
				break;
			case 20:
				int LA53_99 = input.LA(1);


				int index53_99 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_99);
				if ( s>=0 ) return s;
				break;
			case 21:
				int LA53_100 = input.LA(1);


				int index53_100 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_100);
				if ( s>=0 ) return s;
				break;
			case 22:
				int LA53_101 = input.LA(1);


				int index53_101 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_101);
				if ( s>=0 ) return s;
				break;
			case 23:
				int LA53_102 = input.LA(1);


				int index53_102 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_102);
				if ( s>=0 ) return s;
				break;
			case 24:
				int LA53_125 = input.LA(1);


				int index53_125 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_125);
				if ( s>=0 ) return s;
				break;
			case 25:
				int LA53_126 = input.LA(1);


				int index53_126 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_126);
				if ( s>=0 ) return s;
				break;
			case 26:
				int LA53_127 = input.LA(1);


				int index53_127 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_127);
				if ( s>=0 ) return s;
				break;
			case 27:
				int LA53_128 = input.LA(1);


				int index53_128 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_128);
				if ( s>=0 ) return s;
				break;
			case 28:
				int LA53_129 = input.LA(1);


				int index53_129 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_129);
				if ( s>=0 ) return s;
				break;
			case 29:
				int LA53_130 = input.LA(1);


				int index53_130 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_130);
				if ( s>=0 ) return s;
				break;
			case 30:
				int LA53_153 = input.LA(1);


				int index53_153 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_153);
				if ( s>=0 ) return s;
				break;
			case 31:
				int LA53_154 = input.LA(1);


				int index53_154 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_154);
				if ( s>=0 ) return s;
				break;
			case 32:
				int LA53_155 = input.LA(1);


				int index53_155 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_155);
				if ( s>=0 ) return s;
				break;
			case 33:
				int LA53_156 = input.LA(1);


				int index53_156 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_156);
				if ( s>=0 ) return s;
				break;
			case 34:
				int LA53_157 = input.LA(1);


				int index53_157 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_157);
				if ( s>=0 ) return s;
				break;
			case 35:
				int LA53_158 = input.LA(1);


				int index53_158 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_158);
				if ( s>=0 ) return s;
				break;
			case 36:
				int LA53_181 = input.LA(1);


				int index53_181 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_181);
				if ( s>=0 ) return s;
				break;
			case 37:
				int LA53_182 = input.LA(1);


				int index53_182 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_182);
				if ( s>=0 ) return s;
				break;
			case 38:
				int LA53_183 = input.LA(1);


				int index53_183 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_183);
				if ( s>=0 ) return s;
				break;
			case 39:
				int LA53_184 = input.LA(1);


				int index53_184 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_184);
				if ( s>=0 ) return s;
				break;
			case 40:
				int LA53_185 = input.LA(1);


				int index53_185 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_185);
				if ( s>=0 ) return s;
				break;
			case 41:
				int LA53_186 = input.LA(1);


				int index53_186 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_186);
				if ( s>=0 ) return s;
				break;
			case 42:
				int LA53_209 = input.LA(1);


				int index53_209 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_209);
				if ( s>=0 ) return s;
				break;
			case 43:
				int LA53_210 = input.LA(1);


				int index53_210 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_210);
				if ( s>=0 ) return s;
				break;
			case 44:
				int LA53_211 = input.LA(1);


				int index53_211 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_211);
				if ( s>=0 ) return s;
				break;
			case 45:
				int LA53_212 = input.LA(1);


				int index53_212 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_212);
				if ( s>=0 ) return s;
				break;
			case 46:
				int LA53_213 = input.LA(1);


				int index53_213 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_213);
				if ( s>=0 ) return s;
				break;
			case 47:
				int LA53_214 = input.LA(1);


				int index53_214 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_214);
				if ( s>=0 ) return s;
				break;
			case 48:
				int LA53_215 = input.LA(1);


				int index53_215 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_215);
				if ( s>=0 ) return s;
				break;
			case 49:
				int LA53_216 = input.LA(1);


				int index53_216 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_216);
				if ( s>=0 ) return s;
				break;
			case 50:
				int LA53_217 = input.LA(1);


				int index53_217 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_217);
				if ( s>=0 ) return s;
				break;
			case 51:
				int LA53_218 = input.LA(1);


				int index53_218 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_218);
				if ( s>=0 ) return s;
				break;
			case 52:
				int LA53_219 = input.LA(1);


				int index53_219 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_219);
				if ( s>=0 ) return s;
				break;
			case 53:
				int LA53_220 = input.LA(1);


				int index53_220 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_220);
				if ( s>=0 ) return s;
				break;
			case 54:
				int LA53_233 = input.LA(1);


				int index53_233 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_233);
				if ( s>=0 ) return s;
				break;
			case 55:
				int LA53_234 = input.LA(1);


				int index53_234 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_234);
				if ( s>=0 ) return s;
				break;
			case 56:
				int LA53_235 = input.LA(1);


				int index53_235 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_235);
				if ( s>=0 ) return s;
				break;
			case 57:
				int LA53_236 = input.LA(1);


				int index53_236 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_236);
				if ( s>=0 ) return s;
				break;
			case 58:
				int LA53_237 = input.LA(1);


				int index53_237 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_237);
				if ( s>=0 ) return s;
				break;
			case 59:
				int LA53_238 = input.LA(1);


				int index53_238 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_238);
				if ( s>=0 ) return s;
				break;
			case 60:
				int LA53_239 = input.LA(1);


				int index53_239 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_239);
				if ( s>=0 ) return s;
				break;
			case 61:
				int LA53_240 = input.LA(1);


				int index53_240 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_240);
				if ( s>=0 ) return s;
				break;
			case 62:
				int LA53_241 = input.LA(1);


				int index53_241 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_241);
				if ( s>=0 ) return s;
				break;
			case 63:
				int LA53_242 = input.LA(1);


				int index53_242 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_242);
				if ( s>=0 ) return s;
				break;
			case 64:
				int LA53_243 = input.LA(1);


				int index53_243 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_243);
				if ( s>=0 ) return s;
				break;
			case 65:
				int LA53_244 = input.LA(1);


				int index53_244 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_244);
				if ( s>=0 ) return s;
				break;
			case 66:
				int LA53_245 = input.LA(1);


				int index53_245 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_245);
				if ( s>=0 ) return s;
				break;
			case 67:
				int LA53_246 = input.LA(1);


				int index53_246 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_246);
				if ( s>=0 ) return s;
				break;
			case 68:
				int LA53_247 = input.LA(1);


				int index53_247 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_247);
				if ( s>=0 ) return s;
				break;
			case 69:
				int LA53_248 = input.LA(1);


				int index53_248 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_248);
				if ( s>=0 ) return s;
				break;
			case 70:
				int LA53_249 = input.LA(1);


				int index53_249 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_249);
				if ( s>=0 ) return s;
				break;
			case 71:
				int LA53_250 = input.LA(1);


				int index53_250 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_250);
				if ( s>=0 ) return s;
				break;
			case 72:
				int LA53_251 = input.LA(1);


				int index53_251 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_251);
				if ( s>=0 ) return s;
				break;
			case 73:
				int LA53_252 = input.LA(1);


				int index53_252 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_252);
				if ( s>=0 ) return s;
				break;
			case 74:
				int LA53_253 = input.LA(1);


				int index53_253 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_253);
				if ( s>=0 ) return s;
				break;
			case 75:
				int LA53_254 = input.LA(1);


				int index53_254 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_254);
				if ( s>=0 ) return s;
				break;
			case 76:
				int LA53_255 = input.LA(1);


				int index53_255 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_255);
				if ( s>=0 ) return s;
				break;
			case 77:
				int LA53_256 = input.LA(1);


				int index53_256 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_256);
				if ( s>=0 ) return s;
				break;
			case 78:
				int LA53_257 = input.LA(1);


				int index53_257 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_257);
				if ( s>=0 ) return s;
				break;
			case 79:
				int LA53_258 = input.LA(1);


				int index53_258 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_258);
				if ( s>=0 ) return s;
				break;
			case 80:
				int LA53_259 = input.LA(1);


				int index53_259 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_259);
				if ( s>=0 ) return s;
				break;
			case 81:
				int LA53_260 = input.LA(1);


				int index53_260 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_260);
				if ( s>=0 ) return s;
				break;
			case 82:
				int LA53_261 = input.LA(1);


				int index53_261 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_261);
				if ( s>=0 ) return s;
				break;
			case 83:
				int LA53_262 = input.LA(1);


				int index53_262 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_262);
				if ( s>=0 ) return s;
				break;
			case 84:
				int LA53_263 = input.LA(1);


				int index53_263 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_263);
				if ( s>=0 ) return s;
				break;
			case 85:
				int LA53_264 = input.LA(1);


				int index53_264 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_264);
				if ( s>=0 ) return s;
				break;
			case 86:
				int LA53_265 = input.LA(1);


				int index53_265 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_265);
				if ( s>=0 ) return s;
				break;
			case 87:
				int LA53_266 = input.LA(1);


				int index53_266 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_266);
				if ( s>=0 ) return s;
				break;
			case 88:
				int LA53_267 = input.LA(1);


				int index53_267 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_267);
				if ( s>=0 ) return s;
				break;
			case 89:
				int LA53_268 = input.LA(1);


				int index53_268 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_268);
				if ( s>=0 ) return s;
				break;
			case 90:
				int LA53_269 = input.LA(1);


				int index53_269 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_269);
				if ( s>=0 ) return s;
				break;
			case 91:
				int LA53_270 = input.LA(1);


				int index53_270 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_270);
				if ( s>=0 ) return s;
				break;
			case 92:
				int LA53_271 = input.LA(1);


				int index53_271 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_271);
				if ( s>=0 ) return s;
				break;
			case 93:
				int LA53_272 = input.LA(1);


				int index53_272 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_272);
				if ( s>=0 ) return s;
				break;
			case 94:
				int LA53_273 = input.LA(1);


				int index53_273 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_273);
				if ( s>=0 ) return s;
				break;
			case 95:
				int LA53_274 = input.LA(1);


				int index53_274 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_274);
				if ( s>=0 ) return s;
				break;
			case 96:
				int LA53_275 = input.LA(1);


				int index53_275 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_275);
				if ( s>=0 ) return s;
				break;
			case 97:
				int LA53_276 = input.LA(1);


				int index53_276 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_276);
				if ( s>=0 ) return s;
				break;
			case 98:
				int LA53_277 = input.LA(1);


				int index53_277 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_277);
				if ( s>=0 ) return s;
				break;
			case 99:
				int LA53_278 = input.LA(1);


				int index53_278 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_278);
				if ( s>=0 ) return s;
				break;
			case 100:
				int LA53_279 = input.LA(1);


				int index53_279 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_279);
				if ( s>=0 ) return s;
				break;
			case 101:
				int LA53_280 = input.LA(1);


				int index53_280 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred104_C_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 20;}


				input.Seek(index53_280);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 53, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA55 : DFA
	{
		private const string DFA55_eotS =
			"\xA\xFFFF";
		private const string DFA55_eofS =
			"\x1\x1\x9\xFFFF";
		private const string DFA55_minS =
			"\x1\x18\x9\xFFFF";
		private const string DFA55_maxS =
			"\x1\x4D\x9\xFFFF";
		private const string DFA55_acceptS =
			"\x1\xFFFF\x1\x2\x7\xFFFF\x1\x1";
		private const string DFA55_specialS =
			"\xA\xFFFF}>";
		private static readonly string[] DFA55_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\x18\xFFFF\x1\x1\x1\x9",
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

		private static readonly short[] DFA55_eot = DFA.UnpackEncodedString(DFA55_eotS);
		private static readonly short[] DFA55_eof = DFA.UnpackEncodedString(DFA55_eofS);
		private static readonly char[] DFA55_min = DFA.UnpackEncodedStringToUnsignedChars(DFA55_minS);
		private static readonly char[] DFA55_max = DFA.UnpackEncodedStringToUnsignedChars(DFA55_maxS);
		private static readonly short[] DFA55_accept = DFA.UnpackEncodedString(DFA55_acceptS);
		private static readonly short[] DFA55_special = DFA.UnpackEncodedString(DFA55_specialS);
		private static readonly short[][] DFA55_transition;

		static DFA55()
		{
			int numStates = DFA55_transitionS.Length;
			DFA55_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA55_transition[i] = DFA.UnpackEncodedString(DFA55_transitionS[i]);
			}
		}

		public DFA55( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 55;
			this.eot = DFA55_eot;
			this.eof = DFA55_eof;
			this.min = DFA55_min;
			this.max = DFA55_max;
			this.accept = DFA55_accept;
			this.special = DFA55_special;
			this.transition = DFA55_transition;
		}

		public override string Description { get { return "()* loopback of 410:27: ( '||' logical_and_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA56 : DFA
	{
		private const string DFA56_eotS =
			"\xB\xFFFF";
		private const string DFA56_eofS =
			"\x1\x1\xA\xFFFF";
		private const string DFA56_minS =
			"\x1\x18\xA\xFFFF";
		private const string DFA56_maxS =
			"\x1\x4E\xA\xFFFF";
		private const string DFA56_acceptS =
			"\x1\xFFFF\x1\x2\x8\xFFFF\x1\x1";
		private const string DFA56_specialS =
			"\xB\xFFFF}>";
		private static readonly string[] DFA56_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\x18\xFFFF\x2\x1\x1\xA",
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

		private static readonly short[] DFA56_eot = DFA.UnpackEncodedString(DFA56_eotS);
		private static readonly short[] DFA56_eof = DFA.UnpackEncodedString(DFA56_eofS);
		private static readonly char[] DFA56_min = DFA.UnpackEncodedStringToUnsignedChars(DFA56_minS);
		private static readonly char[] DFA56_max = DFA.UnpackEncodedStringToUnsignedChars(DFA56_maxS);
		private static readonly short[] DFA56_accept = DFA.UnpackEncodedString(DFA56_acceptS);
		private static readonly short[] DFA56_special = DFA.UnpackEncodedString(DFA56_specialS);
		private static readonly short[][] DFA56_transition;

		static DFA56()
		{
			int numStates = DFA56_transitionS.Length;
			DFA56_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA56_transition[i] = DFA.UnpackEncodedString(DFA56_transitionS[i]);
			}
		}

		public DFA56( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 56;
			this.eot = DFA56_eot;
			this.eof = DFA56_eof;
			this.min = DFA56_min;
			this.max = DFA56_max;
			this.accept = DFA56_accept;
			this.special = DFA56_special;
			this.transition = DFA56_transition;
		}

		public override string Description { get { return "()* loopback of 414:28: ( '&&' inclusive_or_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA57 : DFA
	{
		private const string DFA57_eotS =
			"\xC\xFFFF";
		private const string DFA57_eofS =
			"\x1\x1\xB\xFFFF";
		private const string DFA57_minS =
			"\x1\x18\xB\xFFFF";
		private const string DFA57_maxS =
			"\x1\x4F\xB\xFFFF";
		private const string DFA57_acceptS =
			"\x1\xFFFF\x1\x2\x9\xFFFF\x1\x1";
		private const string DFA57_specialS =
			"\xC\xFFFF}>";
		private static readonly string[] DFA57_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\x18\xFFFF\x3\x1\x1\xB",
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

		private static readonly short[] DFA57_eot = DFA.UnpackEncodedString(DFA57_eotS);
		private static readonly short[] DFA57_eof = DFA.UnpackEncodedString(DFA57_eofS);
		private static readonly char[] DFA57_min = DFA.UnpackEncodedStringToUnsignedChars(DFA57_minS);
		private static readonly char[] DFA57_max = DFA.UnpackEncodedStringToUnsignedChars(DFA57_maxS);
		private static readonly short[] DFA57_accept = DFA.UnpackEncodedString(DFA57_acceptS);
		private static readonly short[] DFA57_special = DFA.UnpackEncodedString(DFA57_specialS);
		private static readonly short[][] DFA57_transition;

		static DFA57()
		{
			int numStates = DFA57_transitionS.Length;
			DFA57_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA57_transition[i] = DFA.UnpackEncodedString(DFA57_transitionS[i]);
			}
		}

		public DFA57( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 57;
			this.eot = DFA57_eot;
			this.eof = DFA57_eof;
			this.min = DFA57_min;
			this.max = DFA57_max;
			this.accept = DFA57_accept;
			this.special = DFA57_special;
			this.transition = DFA57_transition;
		}

		public override string Description { get { return "()* loopback of 418:28: ( '|' exclusive_or_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA58 : DFA
	{
		private const string DFA58_eotS =
			"\xD\xFFFF";
		private const string DFA58_eofS =
			"\x1\x1\xC\xFFFF";
		private const string DFA58_minS =
			"\x1\x18\xC\xFFFF";
		private const string DFA58_maxS =
			"\x1\x50\xC\xFFFF";
		private const string DFA58_acceptS =
			"\x1\xFFFF\x1\x2\xA\xFFFF\x1\x1";
		private const string DFA58_specialS =
			"\xD\xFFFF}>";
		private static readonly string[] DFA58_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\x18\xFFFF\x4\x1\x1\xC",
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

		private static readonly short[] DFA58_eot = DFA.UnpackEncodedString(DFA58_eotS);
		private static readonly short[] DFA58_eof = DFA.UnpackEncodedString(DFA58_eofS);
		private static readonly char[] DFA58_min = DFA.UnpackEncodedStringToUnsignedChars(DFA58_minS);
		private static readonly char[] DFA58_max = DFA.UnpackEncodedStringToUnsignedChars(DFA58_maxS);
		private static readonly short[] DFA58_accept = DFA.UnpackEncodedString(DFA58_acceptS);
		private static readonly short[] DFA58_special = DFA.UnpackEncodedString(DFA58_specialS);
		private static readonly short[][] DFA58_transition;

		static DFA58()
		{
			int numStates = DFA58_transitionS.Length;
			DFA58_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA58_transition[i] = DFA.UnpackEncodedString(DFA58_transitionS[i]);
			}
		}

		public DFA58( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 58;
			this.eot = DFA58_eot;
			this.eof = DFA58_eof;
			this.min = DFA58_min;
			this.max = DFA58_max;
			this.accept = DFA58_accept;
			this.special = DFA58_special;
			this.transition = DFA58_transition;
		}

		public override string Description { get { return "()* loopback of 422:19: ( '^' and_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA59 : DFA
	{
		private const string DFA59_eotS =
			"\xE\xFFFF";
		private const string DFA59_eofS =
			"\x1\x1\xD\xFFFF";
		private const string DFA59_minS =
			"\x1\x18\xD\xFFFF";
		private const string DFA59_maxS =
			"\x1\x50\xD\xFFFF";
		private const string DFA59_acceptS =
			"\x1\xFFFF\x1\x2\xB\xFFFF\x1\x1";
		private const string DFA59_specialS =
			"\xE\xFFFF}>";
		private static readonly string[] DFA59_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\xB\xFFFF\x1\xD\xC\xFFFF\x5\x1",
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

		public override string Description { get { return "()* loopback of 426:24: ( '&' equality_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA60 : DFA
	{
		private const string DFA60_eotS =
			"\xF\xFFFF";
		private const string DFA60_eofS =
			"\x1\x1\xE\xFFFF";
		private const string DFA60_minS =
			"\x1\x18\xE\xFFFF";
		private const string DFA60_maxS =
			"\x1\x52\xE\xFFFF";
		private const string DFA60_acceptS =
			"\x1\xFFFF\x1\x2\xC\xFFFF\x1\x1";
		private const string DFA60_specialS =
			"\xF\xFFFF}>";
		private static readonly string[] DFA60_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\xB\xFFFF\x1\x1\xC\xFFFF\x5\x1\x2\xE",
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

		private static readonly short[] DFA60_eot = DFA.UnpackEncodedString(DFA60_eotS);
		private static readonly short[] DFA60_eof = DFA.UnpackEncodedString(DFA60_eofS);
		private static readonly char[] DFA60_min = DFA.UnpackEncodedStringToUnsignedChars(DFA60_minS);
		private static readonly char[] DFA60_max = DFA.UnpackEncodedStringToUnsignedChars(DFA60_maxS);
		private static readonly short[] DFA60_accept = DFA.UnpackEncodedString(DFA60_acceptS);
		private static readonly short[] DFA60_special = DFA.UnpackEncodedString(DFA60_specialS);
		private static readonly short[][] DFA60_transition;

		static DFA60()
		{
			int numStates = DFA60_transitionS.Length;
			DFA60_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA60_transition[i] = DFA.UnpackEncodedString(DFA60_transitionS[i]);
			}
		}

		public DFA60( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 60;
			this.eot = DFA60_eot;
			this.eof = DFA60_eof;
			this.min = DFA60_min;
			this.max = DFA60_max;
			this.accept = DFA60_accept;
			this.special = DFA60_special;
			this.transition = DFA60_transition;
		}

		public override string Description { get { return "()* loopback of 429:26: ( ( '==' | '!=' ) relational_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA61 : DFA
	{
		private const string DFA61_eotS =
			"\x10\xFFFF";
		private const string DFA61_eofS =
			"\x1\x1\xF\xFFFF";
		private const string DFA61_minS =
			"\x1\x18\xF\xFFFF";
		private const string DFA61_maxS =
			"\x1\x56\xF\xFFFF";
		private const string DFA61_acceptS =
			"\x1\xFFFF\x1\x2\xD\xFFFF\x1\x1";
		private const string DFA61_specialS =
			"\x10\xFFFF}>";
		private static readonly string[] DFA61_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\xB\xFFFF\x1\x1\xC\xFFFF\x7\x1\x4\xF",
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

		private static readonly short[] DFA61_eot = DFA.UnpackEncodedString(DFA61_eotS);
		private static readonly short[] DFA61_eof = DFA.UnpackEncodedString(DFA61_eofS);
		private static readonly char[] DFA61_min = DFA.UnpackEncodedStringToUnsignedChars(DFA61_minS);
		private static readonly char[] DFA61_max = DFA.UnpackEncodedStringToUnsignedChars(DFA61_maxS);
		private static readonly short[] DFA61_accept = DFA.UnpackEncodedString(DFA61_acceptS);
		private static readonly short[] DFA61_special = DFA.UnpackEncodedString(DFA61_specialS);
		private static readonly short[][] DFA61_transition;

		static DFA61()
		{
			int numStates = DFA61_transitionS.Length;
			DFA61_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA61_transition[i] = DFA.UnpackEncodedString(DFA61_transitionS[i]);
			}
		}

		public DFA61( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 61;
			this.eot = DFA61_eot;
			this.eof = DFA61_eof;
			this.min = DFA61_min;
			this.max = DFA61_max;
			this.accept = DFA61_accept;
			this.special = DFA61_special;
			this.transition = DFA61_transition;
		}

		public override string Description { get { return "()* loopback of 433:21: ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA62 : DFA
	{
		private const string DFA62_eotS =
			"\x11\xFFFF";
		private const string DFA62_eofS =
			"\x1\x1\x10\xFFFF";
		private const string DFA62_minS =
			"\x1\x18\x10\xFFFF";
		private const string DFA62_maxS =
			"\x1\x58\x10\xFFFF";
		private const string DFA62_acceptS =
			"\x1\xFFFF\x1\x2\xE\xFFFF\x1\x1";
		private const string DFA62_specialS =
			"\x11\xFFFF}>";
		private static readonly string[] DFA62_transitionS =
			{
				"\x2\x1\xF\xFFFF\x1\x1\x2\xFFFF\x1\x1\x4\xFFFF\x1\x1\x1\xFFFF\x1\x1"+
				"\xB\xFFFF\x1\x1\xC\xFFFF\xB\x1\x2\x10",
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

		public override string Description { get { return "()* loopback of 437:24: ( ( '<<' | '>>' ) additive_expression )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA63 : DFA
	{
		private const string DFA63_eotS =
			"\x32\xFFFF";
		private const string DFA63_eofS =
			"\x32\xFFFF";
		private const string DFA63_minS =
			"\x1\x4\x1\x18\x30\xFFFF";
		private const string DFA63_maxS =
			"\x1\x64\x1\x58\x30\xFFFF";
		private const string DFA63_acceptS =
			"\x2\xFFFF\x1\x1\x1\xFFFF\x1\x2\x1\x3\xB\xFFFF\x1\x4\x1\xFFFF\x1\x5\x2"+
			"\xFFFF\x1\x6\x1B\xFFFF";
		private const string DFA63_specialS =
			"\x32\xFFFF}>";
		private static readonly string[] DFA63_transitionS =
			{
				"\x1\x1\x6\x5\xD\xFFFF\x1\x5\xF\xFFFF\x1\x4\x7\xFFFF\x1\x5\x3\xFFFF"+
				"\x1\x5\x1\xFFFF\x2\x5\x2\xFFFF\x3\x5\x2\xFFFF\x3\x5\x17\xFFFF\x2\x2"+
				"\x1\x11\x1\xFFFF\x1\x11\x3\x13\x4\x16",
				"\x3\x5\x11\xFFFF\x1\x2\x3\xFFFF\x1\x5\x1\xFFFF\x1\x5\x1\xFFFF\x1\x5"+
				"\x1\xFFFF\x6\x5\x1\xFFFF\x3\x5\x2\xFFFF\x17\x5",
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

		private static readonly short[] DFA63_eot = DFA.UnpackEncodedString(DFA63_eotS);
		private static readonly short[] DFA63_eof = DFA.UnpackEncodedString(DFA63_eofS);
		private static readonly char[] DFA63_min = DFA.UnpackEncodedStringToUnsignedChars(DFA63_minS);
		private static readonly char[] DFA63_max = DFA.UnpackEncodedStringToUnsignedChars(DFA63_maxS);
		private static readonly short[] DFA63_accept = DFA.UnpackEncodedString(DFA63_acceptS);
		private static readonly short[] DFA63_special = DFA.UnpackEncodedString(DFA63_specialS);
		private static readonly short[][] DFA63_transition;

		static DFA63()
		{
			int numStates = DFA63_transitionS.Length;
			DFA63_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA63_transition[i] = DFA.UnpackEncodedString(DFA63_transitionS[i]);
			}
		}

		public DFA63( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 63;
			this.eot = DFA63_eot;
			this.eof = DFA63_eof;
			this.min = DFA63_min;
			this.max = DFA63_max;
			this.accept = DFA63_accept;
			this.special = DFA63_special;
			this.transition = DFA63_transition;
		}

		public override string Description { get { return "442:1: statement : ( labeled_statement | compound_statement | expression_statement | selection_statement | iteration_statement | jump_statement );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA65 : DFA
	{
		private const string DFA65_eotS =
			"\x4F\xFFFF";
		private const string DFA65_eofS =
			"\x4F\xFFFF";
		private const string DFA65_minS =
			"\x2\x4\x29\xFFFF\x1\x0\x5\xFFFF\x1\x0\xE\xFFFF\x1\x0\xE\xFFFF";
		private const string DFA65_maxS =
			"\x1\x64\x1\x58\x29\xFFFF\x1\x0\x5\xFFFF\x1\x0\xE\xFFFF\x1\x0\xE\xFFFF";
		private const string DFA65_acceptS =
			"\x2\xFFFF\x1\x2\x18\xFFFF\x1\x1\x33\xFFFF";
		private const string DFA65_specialS =
			"\x2B\xFFFF\x1\x0\x5\xFFFF\x1\x1\xE\xFFFF\x1\x2\xE\xFFFF}>";
		private static readonly string[] DFA65_transitionS =
			{
				"\x1\x1\x6\x2\xC\xFFFF\x1\x1B\x1\x2\x2\xFFFF\xD\x1B\x2\x2\x2\x1B\x1"+
				"\xFFFF\x3\x1B\x1\x2\x3\xFFFF\x1\x2\x1\xFFFF\x2\x2\x2\xFFFF\x3\x2\x2"+
				"\xFFFF\x3\x2\x17\xFFFF\x3\x2\x1\xFFFF\x8\x2",
				"\x1\x1B\x13\xFFFF\x1\x40\x2\x2\xD\x1B\x2\xFFFF\x2\x1B\x1\x2\x3\x1B"+
				"\x1\x2B\x1\xFFFF\x1\x2\x1\xFFFF\x1\x31\x1\xFFFF\x6\x2\x1\xFFFF\x3\x2"+
				"\x2\xFFFF\x17\x2",
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
				"\x1\xFFFF",
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

		public DFA65( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "()* loopback of 462:8: ( declaration )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition65(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA65_43 = input.LA(1);


				int index65_43 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred136_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 27;}

				else if ( (true) ) {s = 2;}


				input.Seek(index65_43);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA65_49 = input.LA(1);


				int index65_49 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred136_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 27;}

				else if ( (true) ) {s = 2;}


				input.Seek(index65_49);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA65_64 = input.LA(1);


				int index65_64 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred136_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 27;}

				else if ( (true) ) {s = 2;}


				input.Seek(index65_64);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 65, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA66 : DFA
	{
		private const string DFA66_eotS =
			"\x1B\xFFFF";
		private const string DFA66_eofS =
			"\x1B\xFFFF";
		private const string DFA66_minS =
			"\x1\x4\x1A\xFFFF";
		private const string DFA66_maxS =
			"\x1\x64\x1A\xFFFF";
		private const string DFA66_acceptS =
			"\x1\xFFFF\x1\x1\x18\xFFFF\x1\x2";
		private const string DFA66_specialS =
			"\x1B\xFFFF}>";
		private static readonly string[] DFA66_transitionS =
			{
				"\x7\x1\xD\xFFFF\x1\x1\xF\xFFFF\x1\x1\x1\x1A\x6\xFFFF\x1\x1\x3\xFFFF"+
				"\x1\x1\x1\xFFFF\x2\x1\x2\xFFFF\x3\x1\x2\xFFFF\x3\x1\x17\xFFFF\x3\x1"+
				"\x1\xFFFF\x8\x1",
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

		private static readonly short[] DFA66_eot = DFA.UnpackEncodedString(DFA66_eotS);
		private static readonly short[] DFA66_eof = DFA.UnpackEncodedString(DFA66_eofS);
		private static readonly char[] DFA66_min = DFA.UnpackEncodedStringToUnsignedChars(DFA66_minS);
		private static readonly char[] DFA66_max = DFA.UnpackEncodedStringToUnsignedChars(DFA66_maxS);
		private static readonly short[] DFA66_accept = DFA.UnpackEncodedString(DFA66_acceptS);
		private static readonly short[] DFA66_special = DFA.UnpackEncodedString(DFA66_specialS);
		private static readonly short[][] DFA66_transition;

		static DFA66()
		{
			int numStates = DFA66_transitionS.Length;
			DFA66_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA66_transition[i] = DFA.UnpackEncodedString(DFA66_transitionS[i]);
			}
		}

		public DFA66( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 66;
			this.eot = DFA66_eot;
			this.eof = DFA66_eof;
			this.min = DFA66_min;
			this.max = DFA66_max;
			this.accept = DFA66_accept;
			this.special = DFA66_special;
			this.transition = DFA66_transition;
		}

		public override string Description { get { return "462:21: ( statement_list )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA67 : DFA
	{
		private const string DFA67_eotS =
			"\x1C\xFFFF";
		private const string DFA67_eofS =
			"\x1\x1\x1B\xFFFF";
		private const string DFA67_minS =
			"\x1\x4\x1B\xFFFF";
		private const string DFA67_maxS =
			"\x1\x64\x1B\xFFFF";
		private const string DFA67_acceptS =
			"\x1\xFFFF\x1\x2\x1\xFFFF\x1\x1\x18\xFFFF";
		private const string DFA67_specialS =
			"\x1C\xFFFF}>";
		private static readonly string[] DFA67_transitionS =
			{
				"\x7\x3\xD\xFFFF\x1\x3\xF\xFFFF\x1\x3\x1\x1\x6\xFFFF\x1\x3\x3\xFFFF"+
				"\x1\x3\x1\xFFFF\x2\x3\x2\xFFFF\x3\x3\x2\xFFFF\x3\x3\x17\xFFFF\x3\x3"+
				"\x1\xFFFF\x8\x3",
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

		private static readonly short[] DFA67_eot = DFA.UnpackEncodedString(DFA67_eotS);
		private static readonly short[] DFA67_eof = DFA.UnpackEncodedString(DFA67_eofS);
		private static readonly char[] DFA67_min = DFA.UnpackEncodedStringToUnsignedChars(DFA67_minS);
		private static readonly char[] DFA67_max = DFA.UnpackEncodedStringToUnsignedChars(DFA67_maxS);
		private static readonly short[] DFA67_accept = DFA.UnpackEncodedString(DFA67_acceptS);
		private static readonly short[] DFA67_special = DFA.UnpackEncodedString(DFA67_specialS);
		private static readonly short[][] DFA67_transition;

		static DFA67()
		{
			int numStates = DFA67_transitionS.Length;
			DFA67_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA67_transition[i] = DFA.UnpackEncodedString(DFA67_transitionS[i]);
			}
		}

		public DFA67( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 67;
			this.eot = DFA67_eot;
			this.eof = DFA67_eof;
			this.min = DFA67_min;
			this.max = DFA67_max;
			this.accept = DFA67_accept;
			this.special = DFA67_special;
			this.transition = DFA67_transition;
		}

		public override string Description { get { return "()+ loopback of 466:4: ( statement )+"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA68 : DFA
	{
		private const string DFA68_eotS =
			"\xE\xFFFF";
		private const string DFA68_eofS =
			"\xE\xFFFF";
		private const string DFA68_minS =
			"\x1\x4\xD\xFFFF";
		private const string DFA68_maxS =
			"\x1\x41\xD\xFFFF";
		private const string DFA68_acceptS =
			"\x1\xFFFF\x1\x1\x1\x2\xB\xFFFF";
		private const string DFA68_specialS =
			"\xE\xFFFF}>";
		private static readonly string[] DFA68_transitionS =
			{
				"\x7\x2\xD\xFFFF\x1\x1\x17\xFFFF\x1\x2\x3\xFFFF\x1\x2\x1\xFFFF\x2\x2"+
				"\x2\xFFFF\x3\x2\x2\xFFFF\x3\x2",
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

		private static readonly short[] DFA68_eot = DFA.UnpackEncodedString(DFA68_eotS);
		private static readonly short[] DFA68_eof = DFA.UnpackEncodedString(DFA68_eofS);
		private static readonly char[] DFA68_min = DFA.UnpackEncodedStringToUnsignedChars(DFA68_minS);
		private static readonly char[] DFA68_max = DFA.UnpackEncodedStringToUnsignedChars(DFA68_maxS);
		private static readonly short[] DFA68_accept = DFA.UnpackEncodedString(DFA68_acceptS);
		private static readonly short[] DFA68_special = DFA.UnpackEncodedString(DFA68_specialS);
		private static readonly short[][] DFA68_transition;

		static DFA68()
		{
			int numStates = DFA68_transitionS.Length;
			DFA68_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA68_transition[i] = DFA.UnpackEncodedString(DFA68_transitionS[i]);
			}
		}

		public DFA68( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 68;
			this.eot = DFA68_eot;
			this.eof = DFA68_eof;
			this.min = DFA68_min;
			this.max = DFA68_max;
			this.accept = DFA68_accept;
			this.special = DFA68_special;
			this.transition = DFA68_transition;
		}

		public override string Description { get { return "469:1: expression_statement : ( ';' | expression ';' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA71 : DFA
	{
		private const string DFA71_eotS =
			"\xE\xFFFF";
		private const string DFA71_eofS =
			"\xE\xFFFF";
		private const string DFA71_minS =
			"\x1\x4\xD\xFFFF";
		private const string DFA71_maxS =
			"\x1\x41\xD\xFFFF";
		private const string DFA71_acceptS =
			"\x1\xFFFF\x1\x1\xB\xFFFF\x1\x2";
		private const string DFA71_specialS =
			"\xE\xFFFF}>";
		private static readonly string[] DFA71_transitionS =
			{
				"\x7\x1\x25\xFFFF\x1\x1\x1\xD\x2\xFFFF\x1\x1\x1\xFFFF\x2\x1\x2\xFFFF"+
				"\x3\x1\x2\xFFFF\x3\x1",
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

		private static readonly short[] DFA71_eot = DFA.UnpackEncodedString(DFA71_eotS);
		private static readonly short[] DFA71_eof = DFA.UnpackEncodedString(DFA71_eofS);
		private static readonly char[] DFA71_min = DFA.UnpackEncodedStringToUnsignedChars(DFA71_minS);
		private static readonly char[] DFA71_max = DFA.UnpackEncodedStringToUnsignedChars(DFA71_maxS);
		private static readonly short[] DFA71_accept = DFA.UnpackEncodedString(DFA71_acceptS);
		private static readonly short[] DFA71_special = DFA.UnpackEncodedString(DFA71_specialS);
		private static readonly short[][] DFA71_transition;

		static DFA71()
		{
			int numStates = DFA71_transitionS.Length;
			DFA71_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA71_transition[i] = DFA.UnpackEncodedString(DFA71_transitionS[i]);
			}
		}

		public DFA71( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 71;
			this.eot = DFA71_eot;
			this.eof = DFA71_eof;
			this.min = DFA71_min;
			this.max = DFA71_max;
			this.accept = DFA71_accept;
			this.special = DFA71_special;
			this.transition = DFA71_transition;
		}

		public override string Description { get { return "482:56: ( expression )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA73 : DFA
	{
		private const string DFA73_eotS =
			"\x12\xFFFF";
		private const string DFA73_eofS =
			"\x12\xFFFF";
		private const string DFA73_minS =
			"\x1\x61\x3\xFFFF\x1\x4\xD\xFFFF";
		private const string DFA73_maxS =
			"\x1\x64\x3\xFFFF\x1\x41\xD\xFFFF";
		private const string DFA73_acceptS =
			"\x1\xFFFF\x1\x1\x1\x2\x1\x3\x1\xFFFF\x1\x4\x1\x5\xB\xFFFF";
		private const string DFA73_specialS =
			"\x12\xFFFF}>";
		private static readonly string[] DFA73_transitionS =
			{
				"\x1\x1\x1\x2\x1\x3\x1\x4",
				"",
				"",
				"",
				"\x7\x6\xD\xFFFF\x1\x5\x17\xFFFF\x1\x6\x3\xFFFF\x1\x6\x1\xFFFF\x2\x6"+
				"\x2\xFFFF\x3\x6\x2\xFFFF\x3\x6",
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

		private static readonly short[] DFA73_eot = DFA.UnpackEncodedString(DFA73_eotS);
		private static readonly short[] DFA73_eof = DFA.UnpackEncodedString(DFA73_eofS);
		private static readonly char[] DFA73_min = DFA.UnpackEncodedStringToUnsignedChars(DFA73_minS);
		private static readonly char[] DFA73_max = DFA.UnpackEncodedStringToUnsignedChars(DFA73_maxS);
		private static readonly short[] DFA73_accept = DFA.UnpackEncodedString(DFA73_acceptS);
		private static readonly short[] DFA73_special = DFA.UnpackEncodedString(DFA73_specialS);
		private static readonly short[][] DFA73_transition;

		static DFA73()
		{
			int numStates = DFA73_transitionS.Length;
			DFA73_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA73_transition[i] = DFA.UnpackEncodedString(DFA73_transitionS[i]);
			}
		}

		public DFA73( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 73;
			this.eot = DFA73_eot;
			this.eof = DFA73_eof;
			this.min = DFA73_min;
			this.max = DFA73_max;
			this.accept = DFA73_accept;
			this.special = DFA73_special;
			this.transition = DFA73_transition;
		}

		public override string Description { get { return "485:1: jump_statement : ( 'goto' IDENTIFIER ';' | 'continue' ';' | 'break' ';' | 'return' ';' | 'return' expression ';' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA74 : DFA
	{
		private const string DFA74_eotS =
			"\x24\xFFFF";
		private const string DFA74_eofS =
			"\x24\xFFFF";
		private const string DFA74_minS =
			"\x1\x4\xC\xFFFF\x1\x4\x4\xFFFF\xF\x0\x3\xFFFF";
		private const string DFA74_maxS =
			"\x1\x34\xC\xFFFF\x1\x34\x4\xFFFF\xF\x0\x3\xFFFF";
		private const string DFA74_acceptS =
			"\x1\xFFFF\x1\x1\xD\xFFFF\x1\x2\x14\xFFFF";
		private const string DFA74_specialS =
			"\x12\xFFFF\x1\x0\x1\x1\x1\x2\x1\x3\x1\x4\x1\x5\x1\x6\x1\x7\x1\x8\x1"+
			"\x9\x1\xA\x1\xB\x1\xC\x1\xD\x1\xE\x3\xFFFF}>";
		private static readonly string[] DFA74_transitionS =
			{
				"\x1\xD\x16\xFFFF\xD\x1\x2\xFFFF\x2\x1\x1\xFFFF\x3\x1\x1\xF\x3\xFFFF"+
				"\x1\xF",
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
				"\x1\x12\x12\xFFFF\x1\xF\x3\xFFFF\x4\x14\x1\x15\x1\x16\x1\x17\x1\x18"+
				"\x1\x19\x1\x1A\x1\x1B\x1\x1C\x1\x1D\x1\xF\x1\xFFFF\x2\x1E\x1\xFFFF\x1"+
				"\x1F\x2\x20\x1\x13\x1\xFFFF\x1\xF\x1\xFFFF\x1\x1",
				"",
				"",
				"",
				"",
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
				"\x1\xFFFF",
				"",
				"",
				""
			};

		private static readonly short[] DFA74_eot = DFA.UnpackEncodedString(DFA74_eotS);
		private static readonly short[] DFA74_eof = DFA.UnpackEncodedString(DFA74_eofS);
		private static readonly char[] DFA74_min = DFA.UnpackEncodedStringToUnsignedChars(DFA74_minS);
		private static readonly char[] DFA74_max = DFA.UnpackEncodedStringToUnsignedChars(DFA74_maxS);
		private static readonly short[] DFA74_accept = DFA.UnpackEncodedString(DFA74_acceptS);
		private static readonly short[] DFA74_special = DFA.UnpackEncodedString(DFA74_specialS);
		private static readonly short[][] DFA74_transition;

		static DFA74()
		{
			int numStates = DFA74_transitionS.Length;
			DFA74_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA74_transition[i] = DFA.UnpackEncodedString(DFA74_transitionS[i]);
			}
		}

		public DFA74( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 74;
			this.eot = DFA74_eot;
			this.eof = DFA74_eof;
			this.min = DFA74_min;
			this.max = DFA74_max;
			this.accept = DFA74_accept;
			this.special = DFA74_special;
			this.transition = DFA74_transition;
		}

		public override string Description { get { return "82:6: ( declaration_specifiers )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition74(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA74_18 = input.LA(1);


				int index74_18 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_18);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA74_19 = input.LA(1);


				int index74_19 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_19);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA74_20 = input.LA(1);


				int index74_20 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_20);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA74_21 = input.LA(1);


				int index74_21 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_21);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA74_22 = input.LA(1);


				int index74_22 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_22);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA74_23 = input.LA(1);


				int index74_23 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_23);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA74_24 = input.LA(1);


				int index74_24 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_24);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA74_25 = input.LA(1);


				int index74_25 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_25);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA74_26 = input.LA(1);


				int index74_26 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_26);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA74_27 = input.LA(1);


				int index74_27 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_27);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA74_28 = input.LA(1);


				int index74_28 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_28);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA74_29 = input.LA(1);


				int index74_29 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_29);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA74_30 = input.LA(1);


				int index74_30 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_30);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA74_31 = input.LA(1);


				int index74_31 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_31);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA74_32 = input.LA(1);


				int index74_32 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((EvaluatePredicate(synpred2_C_fragment)&&(isTypeName(input.LT(1).getText())))) ) {s = 1;}

				else if ( (true) ) {s = 15;}


				input.Seek(index74_32);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 74, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA75 : DFA
	{
		private const string DFA75_eotS =
			"\x11\xFFFF";
		private const string DFA75_eofS =
			"\x11\xFFFF";
		private const string DFA75_minS =
			"\x1\x4\x10\xFFFF";
		private const string DFA75_maxS =
			"\x1\x2F\x10\xFFFF";
		private const string DFA75_acceptS =
			"\x1\xFFFF\x1\x2\x1\x1\xE\xFFFF";
		private const string DFA75_specialS =
			"\x11\xFFFF}>";
		private static readonly string[] DFA75_transitionS =
			{
				"\x1\x2\x12\xFFFF\x1\x2\x3\xFFFF\xD\x2\x1\x1\x1\xFFFF\x2\x2\x1\xFFFF"+
				"\x3\x2",
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

		private static readonly short[] DFA75_eot = DFA.UnpackEncodedString(DFA75_eotS);
		private static readonly short[] DFA75_eof = DFA.UnpackEncodedString(DFA75_eofS);
		private static readonly char[] DFA75_min = DFA.UnpackEncodedStringToUnsignedChars(DFA75_minS);
		private static readonly char[] DFA75_max = DFA.UnpackEncodedStringToUnsignedChars(DFA75_maxS);
		private static readonly short[] DFA75_accept = DFA.UnpackEncodedString(DFA75_acceptS);
		private static readonly short[] DFA75_special = DFA.UnpackEncodedString(DFA75_specialS);
		private static readonly short[][] DFA75_transition;

		static DFA75()
		{
			int numStates = DFA75_transitionS.Length;
			DFA75_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA75_transition[i] = DFA.UnpackEncodedString(DFA75_transitionS[i]);
			}
		}

		public DFA75( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 75;
			this.eot = DFA75_eot;
			this.eof = DFA75_eof;
			this.min = DFA75_min;
			this.max = DFA75_max;
			this.accept = DFA75_accept;
			this.special = DFA75_special;
			this.transition = DFA75_transition;
		}

		public override string Description { get { return "()* loopback of 82:41: ( declaration )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}


	#endregion DFA

	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _external_declaration_in_translation_unit86 = new BitSet(new ulong[]{0x11ECFFF8800012UL});
		public static readonly BitSet _function_definition_in_external_declaration122 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_in_external_declaration127 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_specifiers_in_function_definition149 = new BitSet(new ulong[]{0x11ECFFF8000010UL});
		public static readonly BitSet _declarator_in_function_definition152 = new BitSet(new ulong[]{0x11EDFFF8800010UL});
		public static readonly BitSet _declaration_in_function_definition158 = new BitSet(new ulong[]{0x11EDFFF8800010UL});
		public static readonly BitSet _compound_statement_in_function_definition161 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _compound_statement_in_function_definition168 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _23_in_declaration196 = new BitSet(new ulong[]{0x11ECFFF8000010UL});
		public static readonly BitSet _declaration_specifiers_in_declaration198 = new BitSet(new ulong[]{0x11ECFFF8000010UL});
		public static readonly BitSet _init_declarator_list_in_declaration206 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_declaration208 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_specifiers_in_declaration214 = new BitSet(new ulong[]{0x11ECFFF9000010UL});
		public static readonly BitSet _init_declarator_list_in_declaration216 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_declaration219 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _storage_class_specifier_in_declaration_specifiers236 = new BitSet(new ulong[]{0xECFFF8000012UL});
		public static readonly BitSet _type_specifier_in_declaration_specifiers244 = new BitSet(new ulong[]{0xECFFF8000012UL});
		public static readonly BitSet _type_qualifier_in_declaration_specifiers258 = new BitSet(new ulong[]{0xECFFF8000012UL});
		public static readonly BitSet _init_declarator_in_init_declarator_list280 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_init_declarator_list283 = new BitSet(new ulong[]{0x11ECFFF8000010UL});
		public static readonly BitSet _init_declarator_in_init_declarator_list285 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _declarator_in_init_declarator298 = new BitSet(new ulong[]{0x4000002UL});
		public static readonly BitSet _26_in_init_declarator301 = new BitSet(new ulong[]{0x9CD10100000007F0UL,0x3UL});
		public static readonly BitSet _initializer_in_init_declarator303 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_storage_class_specifier0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _31_in_type_specifier342 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _32_in_type_specifier347 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _33_in_type_specifier352 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _34_in_type_specifier357 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _35_in_type_specifier362 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _36_in_type_specifier367 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _37_in_type_specifier372 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _38_in_type_specifier377 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _39_in_type_specifier382 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _struct_or_union_specifier_in_type_specifier387 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _enum_specifier_in_type_specifier392 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _type_id_in_type_specifier397 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_type_id415 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _struct_or_union_in_struct_or_union_specifier448 = new BitSet(new ulong[]{0x10000000010UL});
		public static readonly BitSet _IDENTIFIER_in_struct_or_union_specifier450 = new BitSet(new ulong[]{0x10000000000UL});
		public static readonly BitSet _40_in_struct_or_union_specifier453 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _struct_declaration_list_in_struct_or_union_specifier455 = new BitSet(new ulong[]{0x20000000000UL});
		public static readonly BitSet _41_in_struct_or_union_specifier457 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _struct_or_union_in_struct_or_union_specifier462 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _IDENTIFIER_in_struct_or_union_specifier464 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_struct_or_union0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _struct_declaration_in_struct_declaration_list491 = new BitSet(new ulong[]{0xECFFF8000012UL});
		public static readonly BitSet _specifier_qualifier_list_in_struct_declaration503 = new BitSet(new ulong[]{0x11FCFFF8000010UL});
		public static readonly BitSet _struct_declarator_list_in_struct_declaration505 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_struct_declaration507 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _type_qualifier_in_specifier_qualifier_list520 = new BitSet(new ulong[]{0xECFFF8000012UL});
		public static readonly BitSet _type_specifier_in_specifier_qualifier_list524 = new BitSet(new ulong[]{0xECFFF8000012UL});
		public static readonly BitSet _struct_declarator_in_struct_declarator_list538 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_struct_declarator_list541 = new BitSet(new ulong[]{0x11FCFFF8000010UL});
		public static readonly BitSet _struct_declarator_in_struct_declarator_list543 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _declarator_in_struct_declarator556 = new BitSet(new ulong[]{0x100000000002UL});
		public static readonly BitSet _44_in_struct_declarator559 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _constant_expression_in_struct_declarator561 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _44_in_struct_declarator568 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _constant_expression_in_struct_declarator570 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _45_in_enum_specifier588 = new BitSet(new ulong[]{0x10000000000UL});
		public static readonly BitSet _40_in_enum_specifier590 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _enumerator_list_in_enum_specifier592 = new BitSet(new ulong[]{0x20000000000UL});
		public static readonly BitSet _41_in_enum_specifier594 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _45_in_enum_specifier599 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _IDENTIFIER_in_enum_specifier601 = new BitSet(new ulong[]{0x10000000000UL});
		public static readonly BitSet _40_in_enum_specifier603 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _enumerator_list_in_enum_specifier605 = new BitSet(new ulong[]{0x20000000000UL});
		public static readonly BitSet _41_in_enum_specifier607 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _45_in_enum_specifier612 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _IDENTIFIER_in_enum_specifier614 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _enumerator_in_enumerator_list625 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_enumerator_list628 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _enumerator_in_enumerator_list630 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _IDENTIFIER_in_enumerator643 = new BitSet(new ulong[]{0x4000002UL});
		public static readonly BitSet _26_in_enumerator646 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _constant_expression_in_enumerator648 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_type_qualifier0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointer_in_declarator677 = new BitSet(new ulong[]{0x11000000000010UL});
		public static readonly BitSet _direct_declarator_in_declarator680 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointer_in_declarator685 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_direct_declarator700 = new BitSet(new ulong[]{0x5000000000002UL});
		public static readonly BitSet _48_in_direct_declarator711 = new BitSet(new ulong[]{0x11ECFFF8000010UL});
		public static readonly BitSet _declarator_in_direct_declarator713 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_direct_declarator715 = new BitSet(new ulong[]{0x5000000000002UL});
		public static readonly BitSet _declarator_suffix_in_direct_declarator729 = new BitSet(new ulong[]{0x5000000000002UL});
		public static readonly BitSet _50_in_declarator_suffix743 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _constant_expression_in_declarator_suffix745 = new BitSet(new ulong[]{0x8000000000000UL});
		public static readonly BitSet _51_in_declarator_suffix747 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _50_in_declarator_suffix757 = new BitSet(new ulong[]{0x8000000000000UL});
		public static readonly BitSet _51_in_declarator_suffix759 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_declarator_suffix769 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _parameter_type_list_in_declarator_suffix771 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_declarator_suffix773 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_declarator_suffix783 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _identifier_list_in_declarator_suffix785 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_declarator_suffix787 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_declarator_suffix797 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_declarator_suffix799 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _52_in_pointer810 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _type_qualifier_in_pointer812 = new BitSet(new ulong[]{0x10ECFFF8000012UL});
		public static readonly BitSet _pointer_in_pointer815 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _52_in_pointer821 = new BitSet(new ulong[]{0x10000000000000UL});
		public static readonly BitSet _pointer_in_pointer823 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _52_in_pointer828 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _parameter_list_in_parameter_type_list839 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_parameter_type_list842 = new BitSet(new ulong[]{0x20000000000000UL});
		public static readonly BitSet _53_in_parameter_type_list844 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _parameter_declaration_in_parameter_list857 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_parameter_list860 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _parameter_declaration_in_parameter_list862 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _declaration_specifiers_in_parameter_declaration875 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _declarator_in_parameter_declaration878 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _abstract_declarator_in_parameter_declaration880 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _IDENTIFIER_in_identifier_list893 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_identifier_list896 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _IDENTIFIER_in_identifier_list898 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _specifier_qualifier_list_in_type_name911 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _abstract_declarator_in_type_name913 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointer_in_abstract_declarator925 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _direct_abstract_declarator_in_abstract_declarator927 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _direct_abstract_declarator_in_abstract_declarator933 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_direct_abstract_declarator946 = new BitSet(new ulong[]{0x15ECFFF8000010UL});
		public static readonly BitSet _abstract_declarator_in_direct_abstract_declarator948 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_direct_abstract_declarator950 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _abstract_declarator_suffix_in_direct_abstract_declarator954 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _abstract_declarator_suffix_in_direct_abstract_declarator958 = new BitSet(new ulong[]{0x15ECFFF8000012UL});
		public static readonly BitSet _50_in_abstract_declarator_suffix970 = new BitSet(new ulong[]{0x8000000000000UL});
		public static readonly BitSet _51_in_abstract_declarator_suffix972 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _50_in_abstract_declarator_suffix977 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _constant_expression_in_abstract_declarator_suffix979 = new BitSet(new ulong[]{0x8000000000000UL});
		public static readonly BitSet _51_in_abstract_declarator_suffix981 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_abstract_declarator_suffix986 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_abstract_declarator_suffix988 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_abstract_declarator_suffix993 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _parameter_type_list_in_abstract_declarator_suffix995 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_abstract_declarator_suffix997 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _assignment_expression_in_initializer1009 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _40_in_initializer1014 = new BitSet(new ulong[]{0x9CD10100000007F0UL,0x3UL});
		public static readonly BitSet _initializer_list_in_initializer1016 = new BitSet(new ulong[]{0x20002000000UL});
		public static readonly BitSet _25_in_initializer1018 = new BitSet(new ulong[]{0x20000000000UL});
		public static readonly BitSet _41_in_initializer1021 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _initializer_in_initializer_list1032 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_initializer_list1035 = new BitSet(new ulong[]{0x9CD10100000007F0UL,0x3UL});
		public static readonly BitSet _initializer_in_initializer_list1037 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _assignment_expression_in_argument_expression_list1054 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_argument_expression_list1057 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _assignment_expression_in_argument_expression_list1059 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _multiplicative_expression_in_additive_expression1073 = new BitSet(new ulong[]{0xC0000000000002UL});
		public static readonly BitSet _54_in_additive_expression1077 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _multiplicative_expression_in_additive_expression1079 = new BitSet(new ulong[]{0xC0000000000002UL});
		public static readonly BitSet _55_in_additive_expression1083 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _multiplicative_expression_in_additive_expression1085 = new BitSet(new ulong[]{0xC0000000000002UL});
		public static readonly BitSet _cast_expression_in_multiplicative_expression1099 = new BitSet(new ulong[]{0x310000000000002UL});
		public static readonly BitSet _52_in_multiplicative_expression1103 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _cast_expression_in_multiplicative_expression1105 = new BitSet(new ulong[]{0x310000000000002UL});
		public static readonly BitSet _56_in_multiplicative_expression1109 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _cast_expression_in_multiplicative_expression1111 = new BitSet(new ulong[]{0x310000000000002UL});
		public static readonly BitSet _57_in_multiplicative_expression1115 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _cast_expression_in_multiplicative_expression1117 = new BitSet(new ulong[]{0x310000000000002UL});
		public static readonly BitSet _48_in_cast_expression1130 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _type_name_in_cast_expression1132 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_cast_expression1134 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _cast_expression_in_cast_expression1136 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _unary_expression_in_cast_expression1141 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _postfix_expression_in_unary_expression1152 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _58_in_unary_expression1157 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _unary_expression_in_unary_expression1159 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _59_in_unary_expression1164 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _unary_expression_in_unary_expression1166 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _unary_operator_in_unary_expression1171 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _cast_expression_in_unary_expression1173 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _60_in_unary_expression1178 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _unary_expression_in_unary_expression1180 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _60_in_unary_expression1185 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_unary_expression1187 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _type_name_in_unary_expression1189 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_unary_expression1191 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _primary_expression_in_postfix_expression1204 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _50_in_postfix_expression1218 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_postfix_expression1220 = new BitSet(new ulong[]{0x8000000000000UL});
		public static readonly BitSet _51_in_postfix_expression1222 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _48_in_postfix_expression1236 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_postfix_expression1238 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _48_in_postfix_expression1252 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _argument_expression_list_in_postfix_expression1254 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_postfix_expression1256 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _61_in_postfix_expression1270 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _IDENTIFIER_in_postfix_expression1272 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _62_in_postfix_expression1286 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _IDENTIFIER_in_postfix_expression1288 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _58_in_postfix_expression1302 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _59_in_postfix_expression1316 = new BitSet(new ulong[]{0x6C05000000000002UL});
		public static readonly BitSet _set_in_unary_operator0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_primary_expression1374 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _constant_in_primary_expression1379 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_primary_expression1384 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_primary_expression1386 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_primary_expression1388 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _hex_literal_in_constant1404 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _octal_literal_in_constant1414 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _decimal_literal_in_constant1424 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _character_literal_in_constant1434 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _string_literal_in_constant1444 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _floating_point_literal_in_constant1454 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _HEX_LITERAL_in_hex_literal1468 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _OCTAL_LITERAL_in_octal_literal1479 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DECIMAL_LITERAL_in_decimal_literal1490 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CHARACTER_LITERAL_in_character_literal1501 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _STRING_LITERAL_in_string_literal1512 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FLOATING_POINT_LITERAL_in_floating_point_literal1523 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _assignment_expression_in_expression1536 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _25_in_expression1539 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _assignment_expression_in_expression1541 = new BitSet(new ulong[]{0x2000002UL});
		public static readonly BitSet _conditional_expression_in_constant_expression1554 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _lvalue_in_assignment_expression1565 = new BitSet(new ulong[]{0x4000000UL,0xFFCUL});
		public static readonly BitSet _assignment_operator_in_assignment_expression1567 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _assignment_expression_in_assignment_expression1569 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _conditional_expression_in_assignment_expression1574 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _unary_expression_in_lvalue1586 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_assignment_operator0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _logical_or_expression_in_conditional_expression1658 = new BitSet(new ulong[]{0x2UL,0x1000UL});
		public static readonly BitSet _76_in_conditional_expression1661 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_conditional_expression1663 = new BitSet(new ulong[]{0x100000000000UL});
		public static readonly BitSet _44_in_conditional_expression1665 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _conditional_expression_in_conditional_expression1667 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _logical_and_expression_in_logical_or_expression1680 = new BitSet(new ulong[]{0x2UL,0x2000UL});
		public static readonly BitSet _77_in_logical_or_expression1683 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _logical_and_expression_in_logical_or_expression1685 = new BitSet(new ulong[]{0x2UL,0x2000UL});
		public static readonly BitSet _inclusive_or_expression_in_logical_and_expression1698 = new BitSet(new ulong[]{0x2UL,0x4000UL});
		public static readonly BitSet _78_in_logical_and_expression1701 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _inclusive_or_expression_in_logical_and_expression1703 = new BitSet(new ulong[]{0x2UL,0x4000UL});
		public static readonly BitSet _exclusive_or_expression_in_inclusive_or_expression1716 = new BitSet(new ulong[]{0x2UL,0x8000UL});
		public static readonly BitSet _79_in_inclusive_or_expression1719 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _exclusive_or_expression_in_inclusive_or_expression1721 = new BitSet(new ulong[]{0x2UL,0x8000UL});
		public static readonly BitSet _and_expression_in_exclusive_or_expression1734 = new BitSet(new ulong[]{0x2UL,0x10000UL});
		public static readonly BitSet _80_in_exclusive_or_expression1737 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _and_expression_in_exclusive_or_expression1739 = new BitSet(new ulong[]{0x2UL,0x10000UL});
		public static readonly BitSet _equality_expression_in_and_expression1752 = new BitSet(new ulong[]{0x8000000000000002UL});
		public static readonly BitSet _63_in_and_expression1755 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _equality_expression_in_and_expression1757 = new BitSet(new ulong[]{0x8000000000000002UL});
		public static readonly BitSet _relational_expression_in_equality_expression1769 = new BitSet(new ulong[]{0x2UL,0x60000UL});
		public static readonly BitSet _set_in_equality_expression1772 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _relational_expression_in_equality_expression1778 = new BitSet(new ulong[]{0x2UL,0x60000UL});
		public static readonly BitSet _shift_expression_in_relational_expression1791 = new BitSet(new ulong[]{0x2UL,0x780000UL});
		public static readonly BitSet _set_in_relational_expression1794 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _shift_expression_in_relational_expression1804 = new BitSet(new ulong[]{0x2UL,0x780000UL});
		public static readonly BitSet _additive_expression_in_shift_expression1817 = new BitSet(new ulong[]{0x2UL,0x1800000UL});
		public static readonly BitSet _set_in_shift_expression1820 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _additive_expression_in_shift_expression1826 = new BitSet(new ulong[]{0x2UL,0x1800000UL});
		public static readonly BitSet _labeled_statement_in_statement1841 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _compound_statement_in_statement1846 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expression_statement_in_statement1851 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _selection_statement_in_statement1856 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _iteration_statement_in_statement1861 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _jump_statement_in_statement1866 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_labeled_statement1877 = new BitSet(new ulong[]{0x100000000000UL});
		public static readonly BitSet _44_in_labeled_statement1879 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_labeled_statement1881 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _89_in_labeled_statement1886 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _constant_expression_in_labeled_statement1888 = new BitSet(new ulong[]{0x100000000000UL});
		public static readonly BitSet _44_in_labeled_statement1890 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_labeled_statement1892 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _90_in_labeled_statement1897 = new BitSet(new ulong[]{0x100000000000UL});
		public static readonly BitSet _44_in_labeled_statement1899 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_labeled_statement1901 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _40_in_compound_statement1923 = new BitSet(new ulong[]{0x9CD1EFFFF98007F0UL,0x1FEE000003UL});
		public static readonly BitSet _declaration_in_compound_statement1925 = new BitSet(new ulong[]{0x9CD1EFFFF98007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_list_in_compound_statement1928 = new BitSet(new ulong[]{0x20000000000UL});
		public static readonly BitSet _41_in_compound_statement1931 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _statement_in_statement_list1942 = new BitSet(new ulong[]{0x9CD10100010007F2UL,0x1FEE000003UL});
		public static readonly BitSet _24_in_expression_statement1954 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expression_in_expression_statement1959 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_expression_statement1961 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _91_in_selection_statement1972 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_selection_statement1974 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_selection_statement1976 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_selection_statement1978 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_selection_statement1980 = new BitSet(new ulong[]{0x2UL,0x10000000UL});
		public static readonly BitSet _92_in_selection_statement1995 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_selection_statement1997 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _93_in_selection_statement2004 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_selection_statement2006 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_selection_statement2008 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_selection_statement2010 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_selection_statement2012 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _94_in_iteration_statement2023 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_iteration_statement2025 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_iteration_statement2027 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_iteration_statement2029 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_iteration_statement2031 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _95_in_iteration_statement2036 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_iteration_statement2038 = new BitSet(new ulong[]{0x0UL,0x40000000UL});
		public static readonly BitSet _94_in_iteration_statement2040 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_iteration_statement2042 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_iteration_statement2044 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_iteration_statement2046 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_iteration_statement2048 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _96_in_iteration_statement2053 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_iteration_statement2055 = new BitSet(new ulong[]{0x9CD10000010007F0UL,0x3UL});
		public static readonly BitSet _expression_statement_in_iteration_statement2057 = new BitSet(new ulong[]{0x9CD10000010007F0UL,0x3UL});
		public static readonly BitSet _expression_statement_in_iteration_statement2059 = new BitSet(new ulong[]{0x9CD30000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_iteration_statement2061 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_iteration_statement2064 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x1FEE000003UL});
		public static readonly BitSet _statement_in_iteration_statement2066 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _97_in_jump_statement2077 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _IDENTIFIER_in_jump_statement2079 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_jump_statement2081 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _98_in_jump_statement2086 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_jump_statement2088 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _99_in_jump_statement2093 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_jump_statement2095 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _100_in_jump_statement2100 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_jump_statement2102 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _100_in_jump_statement2107 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _expression_in_jump_statement2109 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _24_in_jump_statement2111 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_specifiers_in_synpred2_C109 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_specifiers_in_synpred4_C109 = new BitSet(new ulong[]{0x11ECFFF8000010UL});
		public static readonly BitSet _declarator_in_synpred4_C112 = new BitSet(new ulong[]{0x11EDFFF8800010UL});
		public static readonly BitSet _declaration_in_synpred4_C114 = new BitSet(new ulong[]{0x11EDFFF8800010UL});
		public static readonly BitSet _40_in_synpred4_C117 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_specifiers_in_synpred5_C149 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_specifiers_in_synpred8_C198 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _type_specifier_in_synpred12_C244 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _type_specifier_in_synpred35_C524 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointer_in_synpred45_C677 = new BitSet(new ulong[]{0x11000000000010UL});
		public static readonly BitSet _direct_declarator_in_synpred45_C680 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declarator_suffix_in_synpred47_C729 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_synpred50_C769 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _parameter_type_list_in_synpred50_C771 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_synpred50_C773 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_synpred51_C783 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _identifier_list_in_synpred51_C785 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_synpred51_C787 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _type_qualifier_in_synpred52_C812 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointer_in_synpred53_C815 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _52_in_synpred54_C810 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _type_qualifier_in_synpred54_C812 = new BitSet(new ulong[]{0x10ECFFF8000012UL});
		public static readonly BitSet _pointer_in_synpred54_C815 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _52_in_synpred55_C821 = new BitSet(new ulong[]{0x10000000000000UL});
		public static readonly BitSet _pointer_in_synpred55_C823 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declarator_in_synpred58_C878 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _abstract_declarator_in_synpred59_C880 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _direct_abstract_declarator_in_synpred62_C927 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _abstract_declarator_suffix_in_synpred65_C958 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _48_in_synpred78_C1130 = new BitSet(new ulong[]{0xECFFF8000010UL});
		public static readonly BitSet _type_name_in_synpred78_C1132 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_synpred78_C1134 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _cast_expression_in_synpred78_C1136 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _60_in_synpred83_C1178 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _unary_expression_in_synpred83_C1180 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _lvalue_in_synpred104_C1565 = new BitSet(new ulong[]{0x4000000UL,0xFFCUL});
		public static readonly BitSet _assignment_operator_in_synpred104_C1567 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x3UL});
		public static readonly BitSet _assignment_expression_in_synpred104_C1569 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _declaration_in_synpred136_C1925 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}
