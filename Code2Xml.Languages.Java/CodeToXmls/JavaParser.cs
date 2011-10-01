using Code2Xml.Core.Antlr;
using System;
// $ANTLR 3.3 Nov 30, 2010 12:50:56 Java.g 2011-07-01 10:48:38

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

/** A Java 1.5 grammar for ANTLR v3 derived from the spec
 *
 *  This is a very close representation of the spec; the changes
 *  are comestic (remove left recursion) and also fixes (the spec
 *  isn't exactly perfect).  I have run this on the 1.4.2 source
 *  and some nasty looking enums from 1.5, but have not really
 *  tested for 1.5 compatibility.
 *
 *  I built this with: java -Xmx100M org.antlr.Tool java.g
 *  and got two errors that are ok (for now):
 *  java.g:691:9: Decision can match input such as
 *    "'0'..'9'{'E', 'e'}{'+', '-'}'0'..'9'{'D', 'F', 'd', 'f'}"
 *    using multiple alternatives: 3, 4
 *  As a result, alternative(s) 4 were disabled for that input
 *  java.g:734:35: Decision can match input such as "{'$', 'A'..'Z',
 *    '_', 'a'..'z', '\u00C0'..'\u00D6', '\u00D8'..'\u00F6',
 *    '\u00F8'..'\u1FFF', '\u3040'..'\u318F', '\u3300'..'\u337F',
 *    '\u3400'..'\u3D2D', '\u4E00'..'\u9FFF', '\uF900'..'\uFAFF'}"
 *    using multiple alternatives: 1, 2
 *  As a result, alternative(s) 2 were disabled for that input
 *
 *  You can turn enum on/off as a keyword :)
 *
 *  Version 1.0 -- initial release July 5, 2006 (requires 3.0b2 or higher)
 *
 *  Primary author: Terence Parr, July 2006
 *
 *  Version 1.0.1 -- corrections by Koen Vanderkimpen & Marko van Dooren,
 *      October 25, 2006;
 *      fixed normalInterfaceDeclaration: now uses typeParameters instead
 *          of typeParameter (according to JLS, 3rd edition)
 *      fixed castExpression: no longer allows expression next to type
 *          (according to semantics in JLS, in contrast with syntax in JLS)
 *
 *  Version 1.0.2 -- Terence Parr, Nov 27, 2006
 *      java spec I built this from had some bizarre for-loop control.
 *          Looked weird and so I looked elsewhere...Yep, it's messed up.
 *          simplified.
 *
 *  Version 1.0.3 -- Chris Hogue, Feb 26, 2007
 *      Factored out an annotationName rule and used it in the annotation rule.
 *          Not sure why, but typeName wasn't recognizing references to inner
 *          annotations (e.g. @InterfaceName.InnerAnnotation())
 *      Factored out the elementValue section of an annotation reference.  Created
 *          elementValuePair and elementValuePairs rules, then used them in the
 *          annotation rule.  Allows it to recognize annotation references with
 *          multiple, comma separated attributes.
 *      Updated elementValueArrayInitializer so that it allows multiple elements.
 *          (It was only allowing 0 or 1 element).
 *      Updated localVariableDeclaration to allow annotations.  Interestingly the JLS
 *          doesn't appear to indicate this is legal, but it does work as of at least
 *          JDK 1.5.0_06.
 *      Moved the Identifier portion of annotationTypeElementRest to annotationMethodRest.
 *          Because annotationConstantRest already references variableDeclarator which
 *          has the Identifier portion in it, the parser would fail on constants in
 *          annotation definitions because it expected two identifiers.
 *      Added optional trailing ';' to the alternatives in annotationTypeElementRest.
 *          Wouldn't handle an inner interface that has a trailing ';'.
 *      Swapped the expression and type rule reference order in castExpression to
 *          make it check for genericized casts first.  It was failing to recognize a
 *          statement like  "Class<Byte> TYPE = (Class<Byte>)...;" because it was seeing
 *          'Class<Byte' in the cast expression as a less than expression, then failing
 *          on the '>'.
 *      Changed createdName to use typeArguments instead of nonWildcardTypeArguments.
 *         
 *      Changed the 'this' alternative in primary to allow 'identifierSuffix' rather than
 *          just 'arguments'.  The case it couldn't handle was a call to an explicit
 *          generic method invocation (e.g. this.<E>doSomething()).  Using identifierSuffix
 *          may be overly aggressive--perhaps should create a more constrained thisSuffix rule?
 *
 *  Version 1.0.4 -- Hiroaki Nakamura, May 3, 2007
 *
 *  Fixed formalParameterDecls, localVariableDeclaration, forInit,
 *  and forVarControl to use variableModifier* not 'final'? (annotation)?
 *
 *  Version 1.0.5 -- Terence, June 21, 2007
 *  --a[i].foo didn't work. Fixed unaryExpression
 *
 *  Version 1.0.6 -- John Ridgway, March 17, 2008
 *      Made "assert" a switchable keyword like "enum".
 *      Fixed compilationUnit to disallow "annotation importDeclaration ...".
 *      Changed "Identifier ('.' Identifier)*" to "qualifiedName" in more
 *          places.
 *      Changed modifier* and/or variableModifier* to classOrInterfaceModifiers,
 *          modifiers or variableModifiers, as appropriate.
 *      Renamed "bound" to "typeBound" to better match language in the JLS.
 *      Added "memberDeclaration" which rewrites to methodDeclaration or
 *      fieldDeclaration and pulled type into memberDeclaration.  So we parse
 *          type and then move on to decide whether we're dealing with a field
 *          or a method.
 *      Modified "constructorDeclaration" to use "constructorBody" instead of
 *          "methodBody".  constructorBody starts with explicitConstructorInvocation,
 *          then goes on to blockStatement*.  Pulling explicitConstructorInvocation
 *          out of expressions allowed me to simplify "primary".
 *      Changed variableDeclarator to simplify it.
 *      Changed type to use classOrInterfaceType, thus simplifying it; of course
 *          I then had to add classOrInterfaceType, but it is used in several
 *          places.
 *      Fixed annotations, old version allowed "@X(y,z)", which is illegal.
 *      Added optional comma to end of "elementValueArrayInitializer"; as per JLS.
 *      Changed annotationTypeElementRest to use normalClassDeclaration and
 *          normalInterfaceDeclaration rather than classDeclaration and
 *          interfaceDeclaration, thus getting rid of a couple of grammar ambiguities.
 *      Split localVariableDeclaration into localVariableDeclarationStatement
 *          (includes the terminating semi-colon) and localVariableDeclaration.
 *          This allowed me to use localVariableDeclaration in "forInit" clauses,
 *           simplifying them.
 *      Changed switchBlockStatementGroup to use multiple labels.  This adds an
 *          ambiguity, but if one uses appropriately greedy parsing it yields the
 *           parse that is closest to the meaning of the switch statement.
 *      Renamed "forVarControl" to "enhancedForControl" -- JLS language.
 *      Added semantic predicates to test for shift operations rather than other
 *          things.  Thus, for instance, the string "< <" will never be treated
 *          as a left-shift operator.
 *      In "creator" we rule out "nonWildcardTypeArguments" on arrayCreation,
 *          which are illegal.
 *      Moved "nonWildcardTypeArguments into innerCreator.
 *      Removed 'super' superSuffix from explicitGenericInvocation, since that
 *          is only used in explicitConstructorInvocation at the beginning of a
 *           constructorBody.  (This is part of the simplification of expressions
 *           mentioned earlier.)
 *      Simplified primary (got rid of those things that are only used in
 *          explicitConstructorInvocation).
 *      Lexer -- removed "Exponent?" from FloatingPointLiteral choice 4, since it
 *          led to an ambiguity.
 *
 *      This grammar successfully parses every .java file in the JDK 1.5 source
 *          tree (excluding those whose file names include '-', which are not
 *          valid Java compilation units).
 *
 *  Known remaining problems:
 *      "Letter" and "JavaIDDigit" are wrong.  The actual specification of
 *      "Letter" should be "a character for which the method
 *      Character.isJavaIdentifierStart(int) returns true."  A "Java
 *      letter-or-digit is a character for which the method
 *      Character.isJavaIdentifierPart(int) returns true."
 */
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class JavaParser : Antlr.Runtime.Parser, IAntlrParser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "IDENTIFIER", "INTLITERAL", "LONGLITERAL", "FLOATLITERAL", "DOUBLELITERAL", "CHARLITERAL", "STRINGLITERAL", "TRUE", "FALSE", "NULL", "IntegerNumber", "LongSuffix", "HexPrefix", "HexDigit", "Exponent", "NonIntegerNumber", "FloatSuffix", "DoubleSuffix", "EscapeSequence", "WS", "COMMENT", "LINE_COMMENT", "ABSTRACT", "ASSERT", "BOOLEAN", "BREAK", "BYTE", "CASE", "CATCH", "CHAR", "CLASS", "CONST", "CONTINUE", "DEFAULT", "DO", "DOUBLE", "ELSE", "ENUM", "EXTENDS", "FINAL", "FINALLY", "FLOAT", "FOR", "GOTO", "IF", "IMPLEMENTS", "IMPORT", "INSTANCEOF", "INT", "INTERFACE", "LONG", "NATIVE", "NEW", "PACKAGE", "PRIVATE", "PROTECTED", "PUBLIC", "RETURN", "SHORT", "STATIC", "STRICTFP", "SUPER", "SWITCH", "SYNCHRONIZED", "THIS", "THROW", "THROWS", "TRANSIENT", "TRY", "VOID", "VOLATILE", "WHILE", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "LBRACKET", "RBRACKET", "SEMI", "COMMA", "DOT", "ELLIPSIS", "EQ", "BANG", "TILDE", "QUES", "COLON", "EQEQ", "AMPAMP", "BARBAR", "PLUSPLUS", "SUBSUB", "PLUS", "SUB", "STAR", "SLASH", "AMP", "BAR", "CARET", "PERCENT", "PLUSEQ", "SUBEQ", "STAREQ", "SLASHEQ", "AMPEQ", "BAREQ", "CARETEQ", "PERCENTEQ", "MONKEYS_AT", "BANGEQ", "GT", "LT", "IdentifierStart", "IdentifierPart", "SurrogateIdentifer"
	};
	public const int EOF=-1;
	public const int IDENTIFIER=4;
	public const int INTLITERAL=5;
	public const int LONGLITERAL=6;
	public const int FLOATLITERAL=7;
	public const int DOUBLELITERAL=8;
	public const int CHARLITERAL=9;
	public const int STRINGLITERAL=10;
	public const int TRUE=11;
	public const int FALSE=12;
	public const int NULL=13;
	public const int IntegerNumber=14;
	public const int LongSuffix=15;
	public const int HexPrefix=16;
	public const int HexDigit=17;
	public const int Exponent=18;
	public const int NonIntegerNumber=19;
	public const int FloatSuffix=20;
	public const int DoubleSuffix=21;
	public const int EscapeSequence=22;
	public const int WS=23;
	public const int COMMENT=24;
	public const int LINE_COMMENT=25;
	public const int ABSTRACT=26;
	public const int ASSERT=27;
	public const int BOOLEAN=28;
	public const int BREAK=29;
	public const int BYTE=30;
	public const int CASE=31;
	public const int CATCH=32;
	public const int CHAR=33;
	public const int CLASS=34;
	public const int CONST=35;
	public const int CONTINUE=36;
	public const int DEFAULT=37;
	public const int DO=38;
	public const int DOUBLE=39;
	public const int ELSE=40;
	public const int ENUM=41;
	public const int EXTENDS=42;
	public const int FINAL=43;
	public const int FINALLY=44;
	public const int FLOAT=45;
	public const int FOR=46;
	public const int GOTO=47;
	public const int IF=48;
	public const int IMPLEMENTS=49;
	public const int IMPORT=50;
	public const int INSTANCEOF=51;
	public const int INT=52;
	public const int INTERFACE=53;
	public const int LONG=54;
	public const int NATIVE=55;
	public const int NEW=56;
	public const int PACKAGE=57;
	public const int PRIVATE=58;
	public const int PROTECTED=59;
	public const int PUBLIC=60;
	public const int RETURN=61;
	public const int SHORT=62;
	public const int STATIC=63;
	public const int STRICTFP=64;
	public const int SUPER=65;
	public const int SWITCH=66;
	public const int SYNCHRONIZED=67;
	public const int THIS=68;
	public const int THROW=69;
	public const int THROWS=70;
	public const int TRANSIENT=71;
	public const int TRY=72;
	public const int VOID=73;
	public const int VOLATILE=74;
	public const int WHILE=75;
	public const int LPAREN=76;
	public const int RPAREN=77;
	public const int LBRACE=78;
	public const int RBRACE=79;
	public const int LBRACKET=80;
	public const int RBRACKET=81;
	public const int SEMI=82;
	public const int COMMA=83;
	public const int DOT=84;
	public const int ELLIPSIS=85;
	public const int EQ=86;
	public const int BANG=87;
	public const int TILDE=88;
	public const int QUES=89;
	public const int COLON=90;
	public const int EQEQ=91;
	public const int AMPAMP=92;
	public const int BARBAR=93;
	public const int PLUSPLUS=94;
	public const int SUBSUB=95;
	public const int PLUS=96;
	public const int SUB=97;
	public const int STAR=98;
	public const int SLASH=99;
	public const int AMP=100;
	public const int BAR=101;
	public const int CARET=102;
	public const int PERCENT=103;
	public const int PLUSEQ=104;
	public const int SUBEQ=105;
	public const int STAREQ=106;
	public const int SLASHEQ=107;
	public const int AMPEQ=108;
	public const int BAREQ=109;
	public const int CARETEQ=110;
	public const int PERCENTEQ=111;
	public const int MONKEYS_AT=112;
	public const int BANGEQ=113;
	public const int GT=114;
	public const int LT=115;
	public const int IdentifierStart=116;
	public const int IdentifierPart=117;
	public const int SurrogateIdentifer=118;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, true, false, false, false, false, false, false, false, false, 
				false, true, false, false, true, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				true, false, false, false, false, false, false, false, true, false, 
				false, true, false, false, false, false, false, false, true, false, 
				false, false, true, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				true, true, false, false, false, true, false, false, false, false, false, 
				false, false, false, false, false, true, false, false, true, false, 
				false, false, true, false, false, false, true, false, false, false, 
				true, false, false, false, false, false, true, true, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, true, true, true, true, 
				true, true, false, false, false, false, false, false, true, false, false, 
				false, true, false, true, false, true, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, , , false, false, true, false, , , false, false, , , false, 
				false, , , , , , , , , , , , , false, 
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public JavaParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public JavaParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		this.state.ruleMemo = new System.Collections.Generic.Dictionary<int, int>[391+1];

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

	public override string[] TokenNames { get { return JavaParser.tokenNames; } }
	public override string GrammarFileName { get { return "Java.g"; } }



 	protected virtual void OnCreated() {}
	protected virtual void EnterRule(string ruleName, int ruleIndex) {}
	protected virtual void LeaveRule(string ruleName, int ruleIndex) {}

    public class compilationUnit_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_compilationUnit() {}
    protected virtual void Leave_compilationUnit() {}

    // $ANTLR start "compilationUnit"
    // Java.g:294:1: compilationUnit : ( ( annotations )? packageDeclaration )? ( importDeclaration )* ( typeDeclaration )* ;
    [GrammarRule("compilationUnit")]
    public JavaParser.compilationUnit_return compilationUnit()
    {

        JavaParser.compilationUnit_return retval = new JavaParser.compilationUnit_return();
        retval.Start = (IToken)input.LT(1);
        int compilationUnit_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.annotations_return annotations1 = default(JavaParser.annotations_return);
        JavaParser.packageDeclaration_return packageDeclaration2 = default(JavaParser.packageDeclaration_return);
        JavaParser.importDeclaration_return importDeclaration3 = default(JavaParser.importDeclaration_return);
        JavaParser.typeDeclaration_return typeDeclaration4 = default(JavaParser.typeDeclaration_return);


    	try { DebugEnterRule(GrammarFileName, "compilationUnit");
    	DebugLocation(294, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 1)) { return retval; }
    		// Java.g:299:5: ( ( ( annotations )? packageDeclaration )? ( importDeclaration )* ( typeDeclaration )* )
    		DebugEnterAlt(1);
    		// Java.g:299:9: ( ( annotations )? packageDeclaration )? ( importDeclaration )* ( typeDeclaration )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(299, 9);
    		// Java.g:299:9: ( ( annotations )? packageDeclaration )?
    		int alt2=2;
    		try { DebugEnterSubRule(2);
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
    			// Java.g:299:13: ( annotations )? packageDeclaration
    			{
    			DebugLocation(299, 13);
    			// Java.g:299:13: ( annotations )?
    			int alt1=2;
    			try { DebugEnterSubRule(1);
    			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
    			int LA1_0 = input.LA(1);

    			if ((LA1_0==MONKEYS_AT))
    			{
    				alt1=1;
    			}
    			} finally { DebugExitDecision(1); }
    			switch (alt1)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:299:14: annotations
    				{
    				DebugLocation(299, 14);
    				PushFollow(Follow._annotations_in_compilationUnit100);
    				annotations1=annotations();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotations1.Tree, annotations1, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(1); }

    			DebugLocation(301, 13);
    			PushFollow(Follow._packageDeclaration_in_compilationUnit129);
    			packageDeclaration2=packageDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, packageDeclaration2.Tree, packageDeclaration2, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(2); }

    		DebugLocation(303, 9);
    		// Java.g:303:9: ( importDeclaration )*
    		try { DebugEnterSubRule(3);
    		while (true)
    		{
    			int alt3=2;
    			try { DebugEnterDecision(3, decisionCanBacktrack[3]);
    			int LA3_0 = input.LA(1);

    			if ((LA3_0==IMPORT))
    			{
    				alt3=1;
    			}


    			} finally { DebugExitDecision(3); }
    			switch ( alt3 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:303:10: importDeclaration
    				{
    				DebugLocation(303, 10);
    				PushFollow(Follow._importDeclaration_in_compilationUnit151);
    				importDeclaration3=importDeclaration();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, importDeclaration3.Tree, importDeclaration3, retval);

    				}
    				break;

    			default:
    				goto loop3;
    			}
    		}

    		loop3:
    			;

    		} finally { DebugExitSubRule(3); }

    		DebugLocation(305, 9);
    		// Java.g:305:9: ( typeDeclaration )*
    		try { DebugEnterSubRule(4);
    		while (true)
    		{
    			int alt4=2;
    			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
    			int LA4_0 = input.LA(1);

    			if ((LA4_0==IDENTIFIER||LA4_0==ABSTRACT||LA4_0==BOOLEAN||LA4_0==BYTE||(LA4_0>=CHAR && LA4_0<=CLASS)||LA4_0==DOUBLE||LA4_0==ENUM||LA4_0==FINAL||LA4_0==FLOAT||(LA4_0>=INT && LA4_0<=NATIVE)||(LA4_0>=PRIVATE && LA4_0<=PUBLIC)||(LA4_0>=SHORT && LA4_0<=STRICTFP)||LA4_0==SYNCHRONIZED||LA4_0==TRANSIENT||(LA4_0>=VOID && LA4_0<=VOLATILE)||LA4_0==SEMI||LA4_0==MONKEYS_AT||LA4_0==LT))
    			{
    				alt4=1;
    			}


    			} finally { DebugExitDecision(4); }
    			switch ( alt4 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:305:10: typeDeclaration
    				{
    				DebugLocation(305, 10);
    				PushFollow(Follow._typeDeclaration_in_compilationUnit173);
    				typeDeclaration4=typeDeclaration();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeDeclaration4.Tree, typeDeclaration4, retval);

    				}
    				break;

    			default:
    				goto loop4;
    			}
    		}

    		loop4:
    			;

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
            if (state.backtracking > 0) { Memoize(input, 1, compilationUnit_StartIndex); }
        }
     	DebugLocation(307, 4);
    	} finally { DebugExitRule(GrammarFileName, "compilationUnit"); }
    	return retval;

    }
    // $ANTLR end "compilationUnit"

    public class packageDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_packageDeclaration() {}
    protected virtual void Leave_packageDeclaration() {}

    // $ANTLR start "packageDeclaration"
    // Java.g:309:1: packageDeclaration : 'package' qualifiedName ';' ;
    [GrammarRule("packageDeclaration")]
    public JavaParser.packageDeclaration_return packageDeclaration()
    {

        JavaParser.packageDeclaration_return retval = new JavaParser.packageDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int packageDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal5=null;
        IToken char_literal7=null;
        JavaParser.qualifiedName_return qualifiedName6 = default(JavaParser.qualifiedName_return);

        object string_literal5_tree=null;
        object char_literal7_tree=null;

    	try { DebugEnterRule(GrammarFileName, "packageDeclaration");
    	DebugLocation(309, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 2)) { return retval; }
    		// Java.g:310:5: ( 'package' qualifiedName ';' )
    		DebugEnterAlt(1);
    		// Java.g:310:9: 'package' qualifiedName ';'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(310, 9);
    		string_literal5=(IToken)new XToken((IToken)Match(input,PACKAGE,Follow._PACKAGE_in_packageDeclaration204), "PACKAGE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal5_tree = (object)adaptor.Create(string_literal5, retval);
    		adaptor.AddChild(root_0, string_literal5_tree);
    		}
    		DebugLocation(310, 19);
    		PushFollow(Follow._qualifiedName_in_packageDeclaration206);
    		qualifiedName6=qualifiedName();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, qualifiedName6.Tree, qualifiedName6, retval);
    		DebugLocation(311, 9);
    		char_literal7=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_packageDeclaration216), "SEMI"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal7_tree = (object)adaptor.Create(char_literal7, retval);
    		adaptor.AddChild(root_0, char_literal7_tree);
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
            if (state.backtracking > 0) { Memoize(input, 2, packageDeclaration_StartIndex); }
        }
     	DebugLocation(312, 4);
    	} finally { DebugExitRule(GrammarFileName, "packageDeclaration"); }
    	return retval;

    }
    // $ANTLR end "packageDeclaration"

    public class importDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_importDeclaration() {}
    protected virtual void Leave_importDeclaration() {}

    // $ANTLR start "importDeclaration"
    // Java.g:314:1: importDeclaration : ( 'import' ( 'static' )? IDENTIFIER '.' '*' ';' | 'import' ( 'static' )? IDENTIFIER ( '.' IDENTIFIER )+ ( '.' '*' )? ';' );
    [GrammarRule("importDeclaration")]
    public JavaParser.importDeclaration_return importDeclaration()
    {

        JavaParser.importDeclaration_return retval = new JavaParser.importDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int importDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal8=null;
        IToken string_literal9=null;
        IToken IDENTIFIER10=null;
        IToken char_literal11=null;
        IToken char_literal12=null;
        IToken char_literal13=null;
        IToken string_literal14=null;
        IToken string_literal15=null;
        IToken IDENTIFIER16=null;
        IToken char_literal17=null;
        IToken IDENTIFIER18=null;
        IToken char_literal19=null;
        IToken char_literal20=null;
        IToken char_literal21=null;

        object string_literal8_tree=null;
        object string_literal9_tree=null;
        object IDENTIFIER10_tree=null;
        object char_literal11_tree=null;
        object char_literal12_tree=null;
        object char_literal13_tree=null;
        object string_literal14_tree=null;
        object string_literal15_tree=null;
        object IDENTIFIER16_tree=null;
        object char_literal17_tree=null;
        object IDENTIFIER18_tree=null;
        object char_literal19_tree=null;
        object char_literal20_tree=null;
        object char_literal21_tree=null;

    	try { DebugEnterRule(GrammarFileName, "importDeclaration");
    	DebugLocation(314, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 3)) { return retval; }
    		// Java.g:315:5: ( 'import' ( 'static' )? IDENTIFIER '.' '*' ';' | 'import' ( 'static' )? IDENTIFIER ( '.' IDENTIFIER )+ ( '.' '*' )? ';' )
    		int alt9=2;
    		try { DebugEnterDecision(9, decisionCanBacktrack[9]);
    		int LA9_0 = input.LA(1);

    		if ((LA9_0==IMPORT))
    		{
    			int LA9_1 = input.LA(2);

    			if ((LA9_1==STATIC))
    			{
    				int LA9_2 = input.LA(3);

    				if ((LA9_2==IDENTIFIER))
    				{
    					int LA9_3 = input.LA(4);

    					if ((LA9_3==DOT))
    					{
    						int LA9_4 = input.LA(5);

    						if ((LA9_4==STAR))
    						{
    							alt9=1;
    						}
    						else if ((LA9_4==IDENTIFIER))
    						{
    							alt9=2;
    						}
    						else
    						{
    							if (state.backtracking>0) {state.failed=true; return retval;}
    							NoViableAltException nvae = new NoViableAltException("", 9, 4, input);

    							DebugRecognitionException(nvae);
    							throw nvae;
    						}
    					}
    					else
    					{
    						if (state.backtracking>0) {state.failed=true; return retval;}
    						NoViableAltException nvae = new NoViableAltException("", 9, 3, input);

    						DebugRecognitionException(nvae);
    						throw nvae;
    					}
    				}
    				else
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					NoViableAltException nvae = new NoViableAltException("", 9, 2, input);

    					DebugRecognitionException(nvae);
    					throw nvae;
    				}
    			}
    			else if ((LA9_1==IDENTIFIER))
    			{
    				int LA9_3 = input.LA(3);

    				if ((LA9_3==DOT))
    				{
    					int LA9_4 = input.LA(4);

    					if ((LA9_4==STAR))
    					{
    						alt9=1;
    					}
    					else if ((LA9_4==IDENTIFIER))
    					{
    						alt9=2;
    					}
    					else
    					{
    						if (state.backtracking>0) {state.failed=true; return retval;}
    						NoViableAltException nvae = new NoViableAltException("", 9, 4, input);

    						DebugRecognitionException(nvae);
    						throw nvae;
    					}
    				}
    				else
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					NoViableAltException nvae = new NoViableAltException("", 9, 3, input);

    					DebugRecognitionException(nvae);
    					throw nvae;
    				}
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 9, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 9, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(9); }
    		switch (alt9)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:315:9: 'import' ( 'static' )? IDENTIFIER '.' '*' ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(315, 9);
    			string_literal8=(IToken)new XToken((IToken)Match(input,IMPORT,Follow._IMPORT_in_importDeclaration237), "IMPORT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal8_tree = (object)adaptor.Create(string_literal8, retval);
    			adaptor.AddChild(root_0, string_literal8_tree);
    			}
    			DebugLocation(316, 9);
    			// Java.g:316:9: ( 'static' )?
    			int alt5=2;
    			try { DebugEnterSubRule(5);
    			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
    			int LA5_0 = input.LA(1);

    			if ((LA5_0==STATIC))
    			{
    				alt5=1;
    			}
    			} finally { DebugExitDecision(5); }
    			switch (alt5)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:316:10: 'static'
    				{
    				DebugLocation(316, 10);
    				string_literal9=(IToken)new XToken((IToken)Match(input,STATIC,Follow._STATIC_in_importDeclaration249), "STATIC"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal9_tree = (object)adaptor.Create(string_literal9, retval);
    				adaptor.AddChild(root_0, string_literal9_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(5); }

    			DebugLocation(318, 9);
    			IDENTIFIER10=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_importDeclaration270), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER10_tree = (object)adaptor.Create(IDENTIFIER10, retval);
    			adaptor.AddChild(root_0, IDENTIFIER10_tree);
    			}
    			DebugLocation(318, 20);
    			char_literal11=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_importDeclaration272), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal11_tree = (object)adaptor.Create(char_literal11, retval);
    			adaptor.AddChild(root_0, char_literal11_tree);
    			}
    			DebugLocation(318, 24);
    			char_literal12=(IToken)new XToken((IToken)Match(input,STAR,Follow._STAR_in_importDeclaration274), "STAR"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal12_tree = (object)adaptor.Create(char_literal12, retval);
    			adaptor.AddChild(root_0, char_literal12_tree);
    			}
    			DebugLocation(319, 9);
    			char_literal13=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_importDeclaration284), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal13_tree = (object)adaptor.Create(char_literal13, retval);
    			adaptor.AddChild(root_0, char_literal13_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:320:9: 'import' ( 'static' )? IDENTIFIER ( '.' IDENTIFIER )+ ( '.' '*' )? ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(320, 9);
    			string_literal14=(IToken)new XToken((IToken)Match(input,IMPORT,Follow._IMPORT_in_importDeclaration301), "IMPORT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal14_tree = (object)adaptor.Create(string_literal14, retval);
    			adaptor.AddChild(root_0, string_literal14_tree);
    			}
    			DebugLocation(321, 9);
    			// Java.g:321:9: ( 'static' )?
    			int alt6=2;
    			try { DebugEnterSubRule(6);
    			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
    			int LA6_0 = input.LA(1);

    			if ((LA6_0==STATIC))
    			{
    				alt6=1;
    			}
    			} finally { DebugExitDecision(6); }
    			switch (alt6)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:321:10: 'static'
    				{
    				DebugLocation(321, 10);
    				string_literal15=(IToken)new XToken((IToken)Match(input,STATIC,Follow._STATIC_in_importDeclaration313), "STATIC"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal15_tree = (object)adaptor.Create(string_literal15, retval);
    				adaptor.AddChild(root_0, string_literal15_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(6); }

    			DebugLocation(323, 9);
    			IDENTIFIER16=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_importDeclaration334), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER16_tree = (object)adaptor.Create(IDENTIFIER16, retval);
    			adaptor.AddChild(root_0, IDENTIFIER16_tree);
    			}
    			DebugLocation(324, 9);
    			// Java.g:324:9: ( '.' IDENTIFIER )+
    			int cnt7=0;
    			try { DebugEnterSubRule(7);
    			while (true)
    			{
    				int alt7=2;
    				try { DebugEnterDecision(7, decisionCanBacktrack[7]);
    				int LA7_0 = input.LA(1);

    				if ((LA7_0==DOT))
    				{
    					int LA7_1 = input.LA(2);

    					if ((LA7_1==IDENTIFIER))
    					{
    						alt7=1;
    					}


    				}


    				} finally { DebugExitDecision(7); }
    				switch (alt7)
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:324:10: '.' IDENTIFIER
    					{
    					DebugLocation(324, 10);
    					char_literal17=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_importDeclaration345), "DOT"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal17_tree = (object)adaptor.Create(char_literal17, retval);
    					adaptor.AddChild(root_0, char_literal17_tree);
    					}
    					DebugLocation(324, 14);
    					IDENTIFIER18=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_importDeclaration347), "IDENTIFIER"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					IDENTIFIER18_tree = (object)adaptor.Create(IDENTIFIER18, retval);
    					adaptor.AddChild(root_0, IDENTIFIER18_tree);
    					}

    					}
    					break;

    				default:
    					if (cnt7 >= 1)
    						goto loop7;

    					if (state.backtracking>0) {state.failed=true; return retval;}
    					EarlyExitException eee7 = new EarlyExitException( 7, input );
    					DebugRecognitionException(eee7);
    					throw eee7;
    				}
    				cnt7++;
    			}
    			loop7:
    				;

    			} finally { DebugExitSubRule(7); }

    			DebugLocation(326, 9);
    			// Java.g:326:9: ( '.' '*' )?
    			int alt8=2;
    			try { DebugEnterSubRule(8);
    			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
    			int LA8_0 = input.LA(1);

    			if ((LA8_0==DOT))
    			{
    				alt8=1;
    			}
    			} finally { DebugExitDecision(8); }
    			switch (alt8)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:326:10: '.' '*'
    				{
    				DebugLocation(326, 10);
    				char_literal19=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_importDeclaration369), "DOT"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal19_tree = (object)adaptor.Create(char_literal19, retval);
    				adaptor.AddChild(root_0, char_literal19_tree);
    				}
    				DebugLocation(326, 14);
    				char_literal20=(IToken)new XToken((IToken)Match(input,STAR,Follow._STAR_in_importDeclaration371), "STAR"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal20_tree = (object)adaptor.Create(char_literal20, retval);
    				adaptor.AddChild(root_0, char_literal20_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(8); }

    			DebugLocation(328, 9);
    			char_literal21=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_importDeclaration392), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal21_tree = (object)adaptor.Create(char_literal21, retval);
    			adaptor.AddChild(root_0, char_literal21_tree);
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
            if (state.backtracking > 0) { Memoize(input, 3, importDeclaration_StartIndex); }
        }
     	DebugLocation(329, 4);
    	} finally { DebugExitRule(GrammarFileName, "importDeclaration"); }
    	return retval;

    }
    // $ANTLR end "importDeclaration"

    public class qualifiedImportName_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_qualifiedImportName() {}
    protected virtual void Leave_qualifiedImportName() {}

    // $ANTLR start "qualifiedImportName"
    // Java.g:331:1: qualifiedImportName : IDENTIFIER ( '.' IDENTIFIER )* ;
    [GrammarRule("qualifiedImportName")]
    public JavaParser.qualifiedImportName_return qualifiedImportName()
    {

        JavaParser.qualifiedImportName_return retval = new JavaParser.qualifiedImportName_return();
        retval.Start = (IToken)input.LT(1);
        int qualifiedImportName_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER22=null;
        IToken char_literal23=null;
        IToken IDENTIFIER24=null;

        object IDENTIFIER22_tree=null;
        object char_literal23_tree=null;
        object IDENTIFIER24_tree=null;

    	try { DebugEnterRule(GrammarFileName, "qualifiedImportName");
    	DebugLocation(331, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 4)) { return retval; }
    		// Java.g:332:5: ( IDENTIFIER ( '.' IDENTIFIER )* )
    		DebugEnterAlt(1);
    		// Java.g:332:9: IDENTIFIER ( '.' IDENTIFIER )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(332, 9);
    		IDENTIFIER22=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_qualifiedImportName412), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER22_tree = (object)adaptor.Create(IDENTIFIER22, retval);
    		adaptor.AddChild(root_0, IDENTIFIER22_tree);
    		}
    		DebugLocation(333, 9);
    		// Java.g:333:9: ( '.' IDENTIFIER )*
    		try { DebugEnterSubRule(10);
    		while (true)
    		{
    			int alt10=2;
    			try { DebugEnterDecision(10, decisionCanBacktrack[10]);
    			int LA10_0 = input.LA(1);

    			if ((LA10_0==DOT))
    			{
    				alt10=1;
    			}


    			} finally { DebugExitDecision(10); }
    			switch ( alt10 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:333:10: '.' IDENTIFIER
    				{
    				DebugLocation(333, 10);
    				char_literal23=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_qualifiedImportName423), "DOT"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal23_tree = (object)adaptor.Create(char_literal23, retval);
    				adaptor.AddChild(root_0, char_literal23_tree);
    				}
    				DebugLocation(333, 14);
    				IDENTIFIER24=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_qualifiedImportName425), "IDENTIFIER"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				IDENTIFIER24_tree = (object)adaptor.Create(IDENTIFIER24, retval);
    				adaptor.AddChild(root_0, IDENTIFIER24_tree);
    				}

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
            if (state.backtracking > 0) { Memoize(input, 4, qualifiedImportName_StartIndex); }
        }
     	DebugLocation(335, 4);
    	} finally { DebugExitRule(GrammarFileName, "qualifiedImportName"); }
    	return retval;

    }
    // $ANTLR end "qualifiedImportName"

    public class typeDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeDeclaration() {}
    protected virtual void Leave_typeDeclaration() {}

    // $ANTLR start "typeDeclaration"
    // Java.g:337:1: typeDeclaration : ( classOrInterfaceDeclaration | ';' );
    [GrammarRule("typeDeclaration")]
    public JavaParser.typeDeclaration_return typeDeclaration()
    {

        JavaParser.typeDeclaration_return retval = new JavaParser.typeDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int typeDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal26=null;
        JavaParser.classOrInterfaceDeclaration_return classOrInterfaceDeclaration25 = default(JavaParser.classOrInterfaceDeclaration_return);

        object char_literal26_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeDeclaration");
    	DebugLocation(337, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 5)) { return retval; }
    		// Java.g:338:5: ( classOrInterfaceDeclaration | ';' )
    		int alt11=2;
    		try { DebugEnterDecision(11, decisionCanBacktrack[11]);
    		int LA11_0 = input.LA(1);

    		if ((LA11_0==IDENTIFIER||LA11_0==ABSTRACT||LA11_0==BOOLEAN||LA11_0==BYTE||(LA11_0>=CHAR && LA11_0<=CLASS)||LA11_0==DOUBLE||LA11_0==ENUM||LA11_0==FINAL||LA11_0==FLOAT||(LA11_0>=INT && LA11_0<=NATIVE)||(LA11_0>=PRIVATE && LA11_0<=PUBLIC)||(LA11_0>=SHORT && LA11_0<=STRICTFP)||LA11_0==SYNCHRONIZED||LA11_0==TRANSIENT||(LA11_0>=VOID && LA11_0<=VOLATILE)||LA11_0==MONKEYS_AT||LA11_0==LT))
    		{
    			alt11=1;
    		}
    		else if ((LA11_0==SEMI))
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
    			// Java.g:338:9: classOrInterfaceDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(338, 9);
    			PushFollow(Follow._classOrInterfaceDeclaration_in_typeDeclaration456);
    			classOrInterfaceDeclaration25=classOrInterfaceDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classOrInterfaceDeclaration25.Tree, classOrInterfaceDeclaration25, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:339:9: ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(339, 9);
    			char_literal26=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_typeDeclaration466), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal26_tree = (object)adaptor.Create(char_literal26, retval);
    			adaptor.AddChild(root_0, char_literal26_tree);
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
            if (state.backtracking > 0) { Memoize(input, 5, typeDeclaration_StartIndex); }
        }
     	DebugLocation(340, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeDeclaration"); }
    	return retval;

    }
    // $ANTLR end "typeDeclaration"

    public class classOrInterfaceDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_classOrInterfaceDeclaration() {}
    protected virtual void Leave_classOrInterfaceDeclaration() {}

    // $ANTLR start "classOrInterfaceDeclaration"
    // Java.g:342:1: classOrInterfaceDeclaration : ( classDeclaration | interfaceDeclaration );
    [GrammarRule("classOrInterfaceDeclaration")]
    public JavaParser.classOrInterfaceDeclaration_return classOrInterfaceDeclaration()
    {

        JavaParser.classOrInterfaceDeclaration_return retval = new JavaParser.classOrInterfaceDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int classOrInterfaceDeclaration_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.classDeclaration_return classDeclaration27 = default(JavaParser.classDeclaration_return);
        JavaParser.interfaceDeclaration_return interfaceDeclaration28 = default(JavaParser.interfaceDeclaration_return);


    	try { DebugEnterRule(GrammarFileName, "classOrInterfaceDeclaration");
    	DebugLocation(342, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 6)) { return retval; }
    		// Java.g:343:5: ( classDeclaration | interfaceDeclaration )
    		int alt12=2;
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
    			// Java.g:343:10: classDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(343, 10);
    			PushFollow(Follow._classDeclaration_in_classOrInterfaceDeclaration487);
    			classDeclaration27=classDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classDeclaration27.Tree, classDeclaration27, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:344:9: interfaceDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(344, 9);
    			PushFollow(Follow._interfaceDeclaration_in_classOrInterfaceDeclaration497);
    			interfaceDeclaration28=interfaceDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceDeclaration28.Tree, interfaceDeclaration28, retval);

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
            if (state.backtracking > 0) { Memoize(input, 6, classOrInterfaceDeclaration_StartIndex); }
        }
     	DebugLocation(345, 4);
    	} finally { DebugExitRule(GrammarFileName, "classOrInterfaceDeclaration"); }
    	return retval;

    }
    // $ANTLR end "classOrInterfaceDeclaration"

    public class modifiers_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_modifiers() {}
    protected virtual void Leave_modifiers() {}

    // $ANTLR start "modifiers"
    // Java.g:348:1: modifiers : ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )* ;
    [GrammarRule("modifiers")]
    public JavaParser.modifiers_return modifiers()
    {

        JavaParser.modifiers_return retval = new JavaParser.modifiers_return();
        retval.Start = (IToken)input.LT(1);
        int modifiers_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal30=null;
        IToken string_literal31=null;
        IToken string_literal32=null;
        IToken string_literal33=null;
        IToken string_literal34=null;
        IToken string_literal35=null;
        IToken string_literal36=null;
        IToken string_literal37=null;
        IToken string_literal38=null;
        IToken string_literal39=null;
        IToken string_literal40=null;
        JavaParser.annotation_return annotation29 = default(JavaParser.annotation_return);

        object string_literal30_tree=null;
        object string_literal31_tree=null;
        object string_literal32_tree=null;
        object string_literal33_tree=null;
        object string_literal34_tree=null;
        object string_literal35_tree=null;
        object string_literal36_tree=null;
        object string_literal37_tree=null;
        object string_literal38_tree=null;
        object string_literal39_tree=null;
        object string_literal40_tree=null;

    	try { DebugEnterRule(GrammarFileName, "modifiers");
    	DebugLocation(348, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 7)) { return retval; }
    		// Java.g:349:5: ( ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )* )
    		DebugEnterAlt(1);
    		// Java.g:350:5: ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(350, 5);
    		// Java.g:350:5: ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )*
    		try { DebugEnterSubRule(13);
    		while (true)
    		{
    			int alt13=13;
    			try { DebugEnterDecision(13, decisionCanBacktrack[13]);
    			try
    			{
    				alt13 = dfa13.Predict(input);
    			}
    			catch (NoViableAltException nvae)
    			{
    				DebugRecognitionException(nvae);
    				throw;
    			}
    			} finally { DebugExitDecision(13); }
    			switch ( alt13 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:350:10: annotation
    				{
    				DebugLocation(350, 10);
    				PushFollow(Follow._annotation_in_modifiers532);
    				annotation29=annotation();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotation29.Tree, annotation29, retval);

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Java.g:351:9: 'public'
    				{
    				DebugLocation(351, 9);
    				string_literal30=(IToken)new XToken((IToken)Match(input,PUBLIC,Follow._PUBLIC_in_modifiers542), "PUBLIC"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal30_tree = (object)adaptor.Create(string_literal30, retval);
    				adaptor.AddChild(root_0, string_literal30_tree);
    				}

    				}
    				break;
    			case 3:
    				DebugEnterAlt(3);
    				// Java.g:352:9: 'protected'
    				{
    				DebugLocation(352, 9);
    				string_literal31=(IToken)new XToken((IToken)Match(input,PROTECTED,Follow._PROTECTED_in_modifiers552), "PROTECTED"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal31_tree = (object)adaptor.Create(string_literal31, retval);
    				adaptor.AddChild(root_0, string_literal31_tree);
    				}

    				}
    				break;
    			case 4:
    				DebugEnterAlt(4);
    				// Java.g:353:9: 'private'
    				{
    				DebugLocation(353, 9);
    				string_literal32=(IToken)new XToken((IToken)Match(input,PRIVATE,Follow._PRIVATE_in_modifiers562), "PRIVATE"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal32_tree = (object)adaptor.Create(string_literal32, retval);
    				adaptor.AddChild(root_0, string_literal32_tree);
    				}

    				}
    				break;
    			case 5:
    				DebugEnterAlt(5);
    				// Java.g:354:9: 'static'
    				{
    				DebugLocation(354, 9);
    				string_literal33=(IToken)new XToken((IToken)Match(input,STATIC,Follow._STATIC_in_modifiers572), "STATIC"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal33_tree = (object)adaptor.Create(string_literal33, retval);
    				adaptor.AddChild(root_0, string_literal33_tree);
    				}

    				}
    				break;
    			case 6:
    				DebugEnterAlt(6);
    				// Java.g:355:9: 'abstract'
    				{
    				DebugLocation(355, 9);
    				string_literal34=(IToken)new XToken((IToken)Match(input,ABSTRACT,Follow._ABSTRACT_in_modifiers582), "ABSTRACT"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal34_tree = (object)adaptor.Create(string_literal34, retval);
    				adaptor.AddChild(root_0, string_literal34_tree);
    				}

    				}
    				break;
    			case 7:
    				DebugEnterAlt(7);
    				// Java.g:356:9: 'final'
    				{
    				DebugLocation(356, 9);
    				string_literal35=(IToken)new XToken((IToken)Match(input,FINAL,Follow._FINAL_in_modifiers592), "FINAL"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal35_tree = (object)adaptor.Create(string_literal35, retval);
    				adaptor.AddChild(root_0, string_literal35_tree);
    				}

    				}
    				break;
    			case 8:
    				DebugEnterAlt(8);
    				// Java.g:357:9: 'native'
    				{
    				DebugLocation(357, 9);
    				string_literal36=(IToken)new XToken((IToken)Match(input,NATIVE,Follow._NATIVE_in_modifiers602), "NATIVE"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal36_tree = (object)adaptor.Create(string_literal36, retval);
    				adaptor.AddChild(root_0, string_literal36_tree);
    				}

    				}
    				break;
    			case 9:
    				DebugEnterAlt(9);
    				// Java.g:358:9: 'synchronized'
    				{
    				DebugLocation(358, 9);
    				string_literal37=(IToken)new XToken((IToken)Match(input,SYNCHRONIZED,Follow._SYNCHRONIZED_in_modifiers612), "SYNCHRONIZED"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal37_tree = (object)adaptor.Create(string_literal37, retval);
    				adaptor.AddChild(root_0, string_literal37_tree);
    				}

    				}
    				break;
    			case 10:
    				DebugEnterAlt(10);
    				// Java.g:359:9: 'transient'
    				{
    				DebugLocation(359, 9);
    				string_literal38=(IToken)new XToken((IToken)Match(input,TRANSIENT,Follow._TRANSIENT_in_modifiers622), "TRANSIENT"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal38_tree = (object)adaptor.Create(string_literal38, retval);
    				adaptor.AddChild(root_0, string_literal38_tree);
    				}

    				}
    				break;
    			case 11:
    				DebugEnterAlt(11);
    				// Java.g:360:9: 'volatile'
    				{
    				DebugLocation(360, 9);
    				string_literal39=(IToken)new XToken((IToken)Match(input,VOLATILE,Follow._VOLATILE_in_modifiers632), "VOLATILE"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal39_tree = (object)adaptor.Create(string_literal39, retval);
    				adaptor.AddChild(root_0, string_literal39_tree);
    				}

    				}
    				break;
    			case 12:
    				DebugEnterAlt(12);
    				// Java.g:361:9: 'strictfp'
    				{
    				DebugLocation(361, 9);
    				string_literal40=(IToken)new XToken((IToken)Match(input,STRICTFP,Follow._STRICTFP_in_modifiers642), "STRICTFP"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal40_tree = (object)adaptor.Create(string_literal40, retval);
    				adaptor.AddChild(root_0, string_literal40_tree);
    				}

    				}
    				break;

    			default:
    				goto loop13;
    			}
    		}

    		loop13:
    			;

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
            if (state.backtracking > 0) { Memoize(input, 7, modifiers_StartIndex); }
        }
     	DebugLocation(363, 4);
    	} finally { DebugExitRule(GrammarFileName, "modifiers"); }
    	return retval;

    }
    // $ANTLR end "modifiers"

    public class variableModifiers_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_variableModifiers() {}
    protected virtual void Leave_variableModifiers() {}

    // $ANTLR start "variableModifiers"
    // Java.g:366:1: variableModifiers : ( 'final' | annotation )* ;
    [GrammarRule("variableModifiers")]
    public JavaParser.variableModifiers_return variableModifiers()
    {

        JavaParser.variableModifiers_return retval = new JavaParser.variableModifiers_return();
        retval.Start = (IToken)input.LT(1);
        int variableModifiers_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal41=null;
        JavaParser.annotation_return annotation42 = default(JavaParser.annotation_return);

        object string_literal41_tree=null;

    	try { DebugEnterRule(GrammarFileName, "variableModifiers");
    	DebugLocation(366, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 8)) { return retval; }
    		// Java.g:367:5: ( ( 'final' | annotation )* )
    		DebugEnterAlt(1);
    		// Java.g:367:9: ( 'final' | annotation )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(367, 9);
    		// Java.g:367:9: ( 'final' | annotation )*
    		try { DebugEnterSubRule(14);
    		while (true)
    		{
    			int alt14=3;
    			try { DebugEnterDecision(14, decisionCanBacktrack[14]);
    			int LA14_0 = input.LA(1);

    			if ((LA14_0==FINAL))
    			{
    				alt14=1;
    			}
    			else if ((LA14_0==MONKEYS_AT))
    			{
    				alt14=2;
    			}


    			} finally { DebugExitDecision(14); }
    			switch ( alt14 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:367:13: 'final'
    				{
    				DebugLocation(367, 13);
    				string_literal41=(IToken)new XToken((IToken)Match(input,FINAL,Follow._FINAL_in_variableModifiers674), "FINAL"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal41_tree = (object)adaptor.Create(string_literal41, retval);
    				adaptor.AddChild(root_0, string_literal41_tree);
    				}

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Java.g:368:13: annotation
    				{
    				DebugLocation(368, 13);
    				PushFollow(Follow._annotation_in_variableModifiers688);
    				annotation42=annotation();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotation42.Tree, annotation42, retval);

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
            if (state.backtracking > 0) { Memoize(input, 8, variableModifiers_StartIndex); }
        }
     	DebugLocation(370, 4);
    	} finally { DebugExitRule(GrammarFileName, "variableModifiers"); }
    	return retval;

    }
    // $ANTLR end "variableModifiers"

    public class classDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_classDeclaration() {}
    protected virtual void Leave_classDeclaration() {}

    // $ANTLR start "classDeclaration"
    // Java.g:373:1: classDeclaration : ( normalClassDeclaration | enumDeclaration );
    [GrammarRule("classDeclaration")]
    public JavaParser.classDeclaration_return classDeclaration()
    {

        JavaParser.classDeclaration_return retval = new JavaParser.classDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int classDeclaration_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.normalClassDeclaration_return normalClassDeclaration43 = default(JavaParser.normalClassDeclaration_return);
        JavaParser.enumDeclaration_return enumDeclaration44 = default(JavaParser.enumDeclaration_return);


    	try { DebugEnterRule(GrammarFileName, "classDeclaration");
    	DebugLocation(373, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 9)) { return retval; }
    		// Java.g:374:5: ( normalClassDeclaration | enumDeclaration )
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
    			// Java.g:374:9: normalClassDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(374, 9);
    			PushFollow(Follow._normalClassDeclaration_in_classDeclaration724);
    			normalClassDeclaration43=normalClassDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, normalClassDeclaration43.Tree, normalClassDeclaration43, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:375:9: enumDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(375, 9);
    			PushFollow(Follow._enumDeclaration_in_classDeclaration734);
    			enumDeclaration44=enumDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, enumDeclaration44.Tree, enumDeclaration44, retval);

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
            if (state.backtracking > 0) { Memoize(input, 9, classDeclaration_StartIndex); }
        }
     	DebugLocation(376, 4);
    	} finally { DebugExitRule(GrammarFileName, "classDeclaration"); }
    	return retval;

    }
    // $ANTLR end "classDeclaration"

    public class normalClassDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_normalClassDeclaration() {}
    protected virtual void Leave_normalClassDeclaration() {}

    // $ANTLR start "normalClassDeclaration"
    // Java.g:378:1: normalClassDeclaration : modifiers 'class' IDENTIFIER ( typeParameters )? ( 'extends' type )? ( 'implements' typeList )? classBody ;
    [GrammarRule("normalClassDeclaration")]
    public JavaParser.normalClassDeclaration_return normalClassDeclaration()
    {

        JavaParser.normalClassDeclaration_return retval = new JavaParser.normalClassDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int normalClassDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal46=null;
        IToken IDENTIFIER47=null;
        IToken string_literal49=null;
        IToken string_literal51=null;
        JavaParser.modifiers_return modifiers45 = default(JavaParser.modifiers_return);
        JavaParser.typeParameters_return typeParameters48 = default(JavaParser.typeParameters_return);
        JavaParser.type_return type50 = default(JavaParser.type_return);
        JavaParser.typeList_return typeList52 = default(JavaParser.typeList_return);
        JavaParser.classBody_return classBody53 = default(JavaParser.classBody_return);

        object string_literal46_tree=null;
        object IDENTIFIER47_tree=null;
        object string_literal49_tree=null;
        object string_literal51_tree=null;

    	try { DebugEnterRule(GrammarFileName, "normalClassDeclaration");
    	DebugLocation(378, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 10)) { return retval; }
    		// Java.g:379:5: ( modifiers 'class' IDENTIFIER ( typeParameters )? ( 'extends' type )? ( 'implements' typeList )? classBody )
    		DebugEnterAlt(1);
    		// Java.g:379:9: modifiers 'class' IDENTIFIER ( typeParameters )? ( 'extends' type )? ( 'implements' typeList )? classBody
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(379, 9);
    		PushFollow(Follow._modifiers_in_normalClassDeclaration754);
    		modifiers45=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers45.Tree, modifiers45, retval);
    		DebugLocation(379, 20);
    		string_literal46=(IToken)new XToken((IToken)Match(input,CLASS,Follow._CLASS_in_normalClassDeclaration757), "CLASS"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal46_tree = (object)adaptor.Create(string_literal46, retval);
    		adaptor.AddChild(root_0, string_literal46_tree);
    		}
    		DebugLocation(379, 28);
    		IDENTIFIER47=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_normalClassDeclaration759), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER47_tree = (object)adaptor.Create(IDENTIFIER47, retval);
    		adaptor.AddChild(root_0, IDENTIFIER47_tree);
    		}
    		DebugLocation(380, 9);
    		// Java.g:380:9: ( typeParameters )?
    		int alt16=2;
    		try { DebugEnterSubRule(16);
    		try { DebugEnterDecision(16, decisionCanBacktrack[16]);
    		int LA16_0 = input.LA(1);

    		if ((LA16_0==LT))
    		{
    			alt16=1;
    		}
    		} finally { DebugExitDecision(16); }
    		switch (alt16)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:380:10: typeParameters
    			{
    			DebugLocation(380, 10);
    			PushFollow(Follow._typeParameters_in_normalClassDeclaration770);
    			typeParameters48=typeParameters();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameters48.Tree, typeParameters48, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(16); }

    		DebugLocation(382, 9);
    		// Java.g:382:9: ( 'extends' type )?
    		int alt17=2;
    		try { DebugEnterSubRule(17);
    		try { DebugEnterDecision(17, decisionCanBacktrack[17]);
    		int LA17_0 = input.LA(1);

    		if ((LA17_0==EXTENDS))
    		{
    			alt17=1;
    		}
    		} finally { DebugExitDecision(17); }
    		switch (alt17)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:382:10: 'extends' type
    			{
    			DebugLocation(382, 10);
    			string_literal49=(IToken)new XToken((IToken)Match(input,EXTENDS,Follow._EXTENDS_in_normalClassDeclaration792), "EXTENDS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal49_tree = (object)adaptor.Create(string_literal49, retval);
    			adaptor.AddChild(root_0, string_literal49_tree);
    			}
    			DebugLocation(382, 20);
    			PushFollow(Follow._type_in_normalClassDeclaration794);
    			type50=type();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type50.Tree, type50, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(17); }

    		DebugLocation(384, 9);
    		// Java.g:384:9: ( 'implements' typeList )?
    		int alt18=2;
    		try { DebugEnterSubRule(18);
    		try { DebugEnterDecision(18, decisionCanBacktrack[18]);
    		int LA18_0 = input.LA(1);

    		if ((LA18_0==IMPLEMENTS))
    		{
    			alt18=1;
    		}
    		} finally { DebugExitDecision(18); }
    		switch (alt18)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:384:10: 'implements' typeList
    			{
    			DebugLocation(384, 10);
    			string_literal51=(IToken)new XToken((IToken)Match(input,IMPLEMENTS,Follow._IMPLEMENTS_in_normalClassDeclaration816), "IMPLEMENTS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal51_tree = (object)adaptor.Create(string_literal51, retval);
    			adaptor.AddChild(root_0, string_literal51_tree);
    			}
    			DebugLocation(384, 23);
    			PushFollow(Follow._typeList_in_normalClassDeclaration818);
    			typeList52=typeList();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeList52.Tree, typeList52, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(18); }

    		DebugLocation(386, 9);
    		PushFollow(Follow._classBody_in_normalClassDeclaration851);
    		classBody53=classBody();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classBody53.Tree, classBody53, retval);

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
            if (state.backtracking > 0) { Memoize(input, 10, normalClassDeclaration_StartIndex); }
        }
     	DebugLocation(387, 4);
    	} finally { DebugExitRule(GrammarFileName, "normalClassDeclaration"); }
    	return retval;

    }
    // $ANTLR end "normalClassDeclaration"

    public class typeParameters_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeParameters() {}
    protected virtual void Leave_typeParameters() {}

    // $ANTLR start "typeParameters"
    // Java.g:390:1: typeParameters : '<' typeParameter ( ',' typeParameter )* '>' ;
    [GrammarRule("typeParameters")]
    public JavaParser.typeParameters_return typeParameters()
    {

        JavaParser.typeParameters_return retval = new JavaParser.typeParameters_return();
        retval.Start = (IToken)input.LT(1);
        int typeParameters_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal54=null;
        IToken char_literal56=null;
        IToken char_literal58=null;
        JavaParser.typeParameter_return typeParameter55 = default(JavaParser.typeParameter_return);
        JavaParser.typeParameter_return typeParameter57 = default(JavaParser.typeParameter_return);

        object char_literal54_tree=null;
        object char_literal56_tree=null;
        object char_literal58_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeParameters");
    	DebugLocation(390, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 11)) { return retval; }
    		// Java.g:391:5: ( '<' typeParameter ( ',' typeParameter )* '>' )
    		DebugEnterAlt(1);
    		// Java.g:391:9: '<' typeParameter ( ',' typeParameter )* '>'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(391, 9);
    		char_literal54=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_typeParameters872), "LT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal54_tree = (object)adaptor.Create(char_literal54, retval);
    		adaptor.AddChild(root_0, char_literal54_tree);
    		}
    		DebugLocation(392, 13);
    		PushFollow(Follow._typeParameter_in_typeParameters886);
    		typeParameter55=typeParameter();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameter55.Tree, typeParameter55, retval);
    		DebugLocation(393, 13);
    		// Java.g:393:13: ( ',' typeParameter )*
    		try { DebugEnterSubRule(19);
    		while (true)
    		{
    			int alt19=2;
    			try { DebugEnterDecision(19, decisionCanBacktrack[19]);
    			int LA19_0 = input.LA(1);

    			if ((LA19_0==COMMA))
    			{
    				alt19=1;
    			}


    			} finally { DebugExitDecision(19); }
    			switch ( alt19 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:393:14: ',' typeParameter
    				{
    				DebugLocation(393, 14);
    				char_literal56=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_typeParameters901), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal56_tree = (object)adaptor.Create(char_literal56, retval);
    				adaptor.AddChild(root_0, char_literal56_tree);
    				}
    				DebugLocation(393, 18);
    				PushFollow(Follow._typeParameter_in_typeParameters903);
    				typeParameter57=typeParameter();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameter57.Tree, typeParameter57, retval);

    				}
    				break;

    			default:
    				goto loop19;
    			}
    		}

    		loop19:
    			;

    		} finally { DebugExitSubRule(19); }

    		DebugLocation(395, 9);
    		char_literal58=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_typeParameters928), "GT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal58_tree = (object)adaptor.Create(char_literal58, retval);
    		adaptor.AddChild(root_0, char_literal58_tree);
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
            if (state.backtracking > 0) { Memoize(input, 11, typeParameters_StartIndex); }
        }
     	DebugLocation(396, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeParameters"); }
    	return retval;

    }
    // $ANTLR end "typeParameters"

    public class typeParameter_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeParameter() {}
    protected virtual void Leave_typeParameter() {}

    // $ANTLR start "typeParameter"
    // Java.g:398:1: typeParameter : IDENTIFIER ( 'extends' typeBound )? ;
    [GrammarRule("typeParameter")]
    public JavaParser.typeParameter_return typeParameter()
    {

        JavaParser.typeParameter_return retval = new JavaParser.typeParameter_return();
        retval.Start = (IToken)input.LT(1);
        int typeParameter_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER59=null;
        IToken string_literal60=null;
        JavaParser.typeBound_return typeBound61 = default(JavaParser.typeBound_return);

        object IDENTIFIER59_tree=null;
        object string_literal60_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeParameter");
    	DebugLocation(398, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 12)) { return retval; }
    		// Java.g:399:5: ( IDENTIFIER ( 'extends' typeBound )? )
    		DebugEnterAlt(1);
    		// Java.g:399:9: IDENTIFIER ( 'extends' typeBound )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(399, 9);
    		IDENTIFIER59=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_typeParameter948), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER59_tree = (object)adaptor.Create(IDENTIFIER59, retval);
    		adaptor.AddChild(root_0, IDENTIFIER59_tree);
    		}
    		DebugLocation(400, 9);
    		// Java.g:400:9: ( 'extends' typeBound )?
    		int alt20=2;
    		try { DebugEnterSubRule(20);
    		try { DebugEnterDecision(20, decisionCanBacktrack[20]);
    		int LA20_0 = input.LA(1);

    		if ((LA20_0==EXTENDS))
    		{
    			alt20=1;
    		}
    		} finally { DebugExitDecision(20); }
    		switch (alt20)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:400:10: 'extends' typeBound
    			{
    			DebugLocation(400, 10);
    			string_literal60=(IToken)new XToken((IToken)Match(input,EXTENDS,Follow._EXTENDS_in_typeParameter959), "EXTENDS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal60_tree = (object)adaptor.Create(string_literal60, retval);
    			adaptor.AddChild(root_0, string_literal60_tree);
    			}
    			DebugLocation(400, 20);
    			PushFollow(Follow._typeBound_in_typeParameter961);
    			typeBound61=typeBound();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeBound61.Tree, typeBound61, retval);

    			}
    			break;

    		}
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
            if (state.backtracking > 0) { Memoize(input, 12, typeParameter_StartIndex); }
        }
     	DebugLocation(402, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeParameter"); }
    	return retval;

    }
    // $ANTLR end "typeParameter"

    public class typeBound_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeBound() {}
    protected virtual void Leave_typeBound() {}

    // $ANTLR start "typeBound"
    // Java.g:405:1: typeBound : type ( '&' type )* ;
    [GrammarRule("typeBound")]
    public JavaParser.typeBound_return typeBound()
    {

        JavaParser.typeBound_return retval = new JavaParser.typeBound_return();
        retval.Start = (IToken)input.LT(1);
        int typeBound_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal63=null;
        JavaParser.type_return type62 = default(JavaParser.type_return);
        JavaParser.type_return type64 = default(JavaParser.type_return);

        object char_literal63_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeBound");
    	DebugLocation(405, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 13)) { return retval; }
    		// Java.g:406:5: ( type ( '&' type )* )
    		DebugEnterAlt(1);
    		// Java.g:406:9: type ( '&' type )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(406, 9);
    		PushFollow(Follow._type_in_typeBound993);
    		type62=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type62.Tree, type62, retval);
    		DebugLocation(407, 9);
    		// Java.g:407:9: ( '&' type )*
    		try { DebugEnterSubRule(21);
    		while (true)
    		{
    			int alt21=2;
    			try { DebugEnterDecision(21, decisionCanBacktrack[21]);
    			int LA21_0 = input.LA(1);

    			if ((LA21_0==AMP))
    			{
    				alt21=1;
    			}


    			} finally { DebugExitDecision(21); }
    			switch ( alt21 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:407:10: '&' type
    				{
    				DebugLocation(407, 10);
    				char_literal63=(IToken)new XToken((IToken)Match(input,AMP,Follow._AMP_in_typeBound1004), "AMP"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal63_tree = (object)adaptor.Create(char_literal63, retval);
    				adaptor.AddChild(root_0, char_literal63_tree);
    				}
    				DebugLocation(407, 14);
    				PushFollow(Follow._type_in_typeBound1006);
    				type64=type();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type64.Tree, type64, retval);

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
            if (state.backtracking > 0) { Memoize(input, 13, typeBound_StartIndex); }
        }
     	DebugLocation(409, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeBound"); }
    	return retval;

    }
    // $ANTLR end "typeBound"

    public class enumDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_enumDeclaration() {}
    protected virtual void Leave_enumDeclaration() {}

    // $ANTLR start "enumDeclaration"
    // Java.g:412:1: enumDeclaration : modifiers ( 'enum' ) IDENTIFIER ( 'implements' typeList )? enumBody ;
    [GrammarRule("enumDeclaration")]
    public JavaParser.enumDeclaration_return enumDeclaration()
    {

        JavaParser.enumDeclaration_return retval = new JavaParser.enumDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int enumDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal66=null;
        IToken IDENTIFIER67=null;
        IToken string_literal68=null;
        JavaParser.modifiers_return modifiers65 = default(JavaParser.modifiers_return);
        JavaParser.typeList_return typeList69 = default(JavaParser.typeList_return);
        JavaParser.enumBody_return enumBody70 = default(JavaParser.enumBody_return);

        object string_literal66_tree=null;
        object IDENTIFIER67_tree=null;
        object string_literal68_tree=null;

    	try { DebugEnterRule(GrammarFileName, "enumDeclaration");
    	DebugLocation(412, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 14)) { return retval; }
    		// Java.g:413:5: ( modifiers ( 'enum' ) IDENTIFIER ( 'implements' typeList )? enumBody )
    		DebugEnterAlt(1);
    		// Java.g:413:9: modifiers ( 'enum' ) IDENTIFIER ( 'implements' typeList )? enumBody
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(413, 9);
    		PushFollow(Follow._modifiers_in_enumDeclaration1038);
    		modifiers65=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers65.Tree, modifiers65, retval);
    		DebugLocation(414, 9);
    		// Java.g:414:9: ( 'enum' )
    		DebugEnterAlt(1);
    		// Java.g:414:10: 'enum'
    		{
    		DebugLocation(414, 10);
    		string_literal66=(IToken)new XToken((IToken)Match(input,ENUM,Follow._ENUM_in_enumDeclaration1050), "ENUM"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal66_tree = (object)adaptor.Create(string_literal66, retval);
    		adaptor.AddChild(root_0, string_literal66_tree);
    		}

    		}

    		DebugLocation(416, 9);
    		IDENTIFIER67=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_enumDeclaration1071), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER67_tree = (object)adaptor.Create(IDENTIFIER67, retval);
    		adaptor.AddChild(root_0, IDENTIFIER67_tree);
    		}
    		DebugLocation(417, 9);
    		// Java.g:417:9: ( 'implements' typeList )?
    		int alt22=2;
    		try { DebugEnterSubRule(22);
    		try { DebugEnterDecision(22, decisionCanBacktrack[22]);
    		int LA22_0 = input.LA(1);

    		if ((LA22_0==IMPLEMENTS))
    		{
    			alt22=1;
    		}
    		} finally { DebugExitDecision(22); }
    		switch (alt22)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:417:10: 'implements' typeList
    			{
    			DebugLocation(417, 10);
    			string_literal68=(IToken)new XToken((IToken)Match(input,IMPLEMENTS,Follow._IMPLEMENTS_in_enumDeclaration1082), "IMPLEMENTS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal68_tree = (object)adaptor.Create(string_literal68, retval);
    			adaptor.AddChild(root_0, string_literal68_tree);
    			}
    			DebugLocation(417, 23);
    			PushFollow(Follow._typeList_in_enumDeclaration1084);
    			typeList69=typeList();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeList69.Tree, typeList69, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(22); }

    		DebugLocation(419, 9);
    		PushFollow(Follow._enumBody_in_enumDeclaration1105);
    		enumBody70=enumBody();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, enumBody70.Tree, enumBody70, retval);

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
            if (state.backtracking > 0) { Memoize(input, 14, enumDeclaration_StartIndex); }
        }
     	DebugLocation(420, 4);
    	} finally { DebugExitRule(GrammarFileName, "enumDeclaration"); }
    	return retval;

    }
    // $ANTLR end "enumDeclaration"

    public class enumBody_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_enumBody() {}
    protected virtual void Leave_enumBody() {}

    // $ANTLR start "enumBody"
    // Java.g:423:1: enumBody : '{' ( enumConstants )? ( ',' )? ( enumBodyDeclarations )? '}' ;
    [GrammarRule("enumBody")]
    public JavaParser.enumBody_return enumBody()
    {

        JavaParser.enumBody_return retval = new JavaParser.enumBody_return();
        retval.Start = (IToken)input.LT(1);
        int enumBody_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal71=null;
        IToken char_literal73=null;
        IToken char_literal75=null;
        JavaParser.enumConstants_return enumConstants72 = default(JavaParser.enumConstants_return);
        JavaParser.enumBodyDeclarations_return enumBodyDeclarations74 = default(JavaParser.enumBodyDeclarations_return);

        object char_literal71_tree=null;
        object char_literal73_tree=null;
        object char_literal75_tree=null;

    	try { DebugEnterRule(GrammarFileName, "enumBody");
    	DebugLocation(423, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 15)) { return retval; }
    		// Java.g:424:5: ( '{' ( enumConstants )? ( ',' )? ( enumBodyDeclarations )? '}' )
    		DebugEnterAlt(1);
    		// Java.g:424:9: '{' ( enumConstants )? ( ',' )? ( enumBodyDeclarations )? '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(424, 9);
    		char_literal71=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_enumBody1130), "LBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal71_tree = (object)adaptor.Create(char_literal71, retval);
    		adaptor.AddChild(root_0, char_literal71_tree);
    		}
    		DebugLocation(425, 9);
    		// Java.g:425:9: ( enumConstants )?
    		int alt23=2;
    		try { DebugEnterSubRule(23);
    		try { DebugEnterDecision(23, decisionCanBacktrack[23]);
    		int LA23_0 = input.LA(1);

    		if ((LA23_0==IDENTIFIER||LA23_0==MONKEYS_AT))
    		{
    			alt23=1;
    		}
    		} finally { DebugExitDecision(23); }
    		switch (alt23)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:425:10: enumConstants
    			{
    			DebugLocation(425, 10);
    			PushFollow(Follow._enumConstants_in_enumBody1141);
    			enumConstants72=enumConstants();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, enumConstants72.Tree, enumConstants72, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(23); }

    		DebugLocation(427, 9);
    		// Java.g:427:9: ( ',' )?
    		int alt24=2;
    		try { DebugEnterSubRule(24);
    		try { DebugEnterDecision(24, decisionCanBacktrack[24]);
    		int LA24_0 = input.LA(1);

    		if ((LA24_0==COMMA))
    		{
    			alt24=1;
    		}
    		} finally { DebugExitDecision(24); }
    		switch (alt24)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:0:0: ','
    			{
    			DebugLocation(427, 9);
    			char_literal73=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_enumBody1163), "COMMA"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal73_tree = (object)adaptor.Create(char_literal73, retval);
    			adaptor.AddChild(root_0, char_literal73_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(24); }

    		DebugLocation(428, 9);
    		// Java.g:428:9: ( enumBodyDeclarations )?
    		int alt25=2;
    		try { DebugEnterSubRule(25);
    		try { DebugEnterDecision(25, decisionCanBacktrack[25]);
    		int LA25_0 = input.LA(1);

    		if ((LA25_0==SEMI))
    		{
    			alt25=1;
    		}
    		} finally { DebugExitDecision(25); }
    		switch (alt25)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:428:10: enumBodyDeclarations
    			{
    			DebugLocation(428, 10);
    			PushFollow(Follow._enumBodyDeclarations_in_enumBody1176);
    			enumBodyDeclarations74=enumBodyDeclarations();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, enumBodyDeclarations74.Tree, enumBodyDeclarations74, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(25); }

    		DebugLocation(430, 9);
    		char_literal75=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_enumBody1198), "RBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal75_tree = (object)adaptor.Create(char_literal75, retval);
    		adaptor.AddChild(root_0, char_literal75_tree);
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
            if (state.backtracking > 0) { Memoize(input, 15, enumBody_StartIndex); }
        }
     	DebugLocation(431, 4);
    	} finally { DebugExitRule(GrammarFileName, "enumBody"); }
    	return retval;

    }
    // $ANTLR end "enumBody"

    public class enumConstants_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_enumConstants() {}
    protected virtual void Leave_enumConstants() {}

    // $ANTLR start "enumConstants"
    // Java.g:433:1: enumConstants : enumConstant ( ',' enumConstant )* ;
    [GrammarRule("enumConstants")]
    public JavaParser.enumConstants_return enumConstants()
    {

        JavaParser.enumConstants_return retval = new JavaParser.enumConstants_return();
        retval.Start = (IToken)input.LT(1);
        int enumConstants_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal77=null;
        JavaParser.enumConstant_return enumConstant76 = default(JavaParser.enumConstant_return);
        JavaParser.enumConstant_return enumConstant78 = default(JavaParser.enumConstant_return);

        object char_literal77_tree=null;

    	try { DebugEnterRule(GrammarFileName, "enumConstants");
    	DebugLocation(433, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 16)) { return retval; }
    		// Java.g:434:5: ( enumConstant ( ',' enumConstant )* )
    		DebugEnterAlt(1);
    		// Java.g:434:9: enumConstant ( ',' enumConstant )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(434, 9);
    		PushFollow(Follow._enumConstant_in_enumConstants1218);
    		enumConstant76=enumConstant();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, enumConstant76.Tree, enumConstant76, retval);
    		DebugLocation(435, 9);
    		// Java.g:435:9: ( ',' enumConstant )*
    		try { DebugEnterSubRule(26);
    		while (true)
    		{
    			int alt26=2;
    			try { DebugEnterDecision(26, decisionCanBacktrack[26]);
    			int LA26_0 = input.LA(1);

    			if ((LA26_0==COMMA))
    			{
    				int LA26_1 = input.LA(2);

    				if ((LA26_1==IDENTIFIER||LA26_1==MONKEYS_AT))
    				{
    					alt26=1;
    				}


    			}


    			} finally { DebugExitDecision(26); }
    			switch ( alt26 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:435:10: ',' enumConstant
    				{
    				DebugLocation(435, 10);
    				char_literal77=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_enumConstants1229), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal77_tree = (object)adaptor.Create(char_literal77, retval);
    				adaptor.AddChild(root_0, char_literal77_tree);
    				}
    				DebugLocation(435, 14);
    				PushFollow(Follow._enumConstant_in_enumConstants1231);
    				enumConstant78=enumConstant();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, enumConstant78.Tree, enumConstant78, retval);

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
            if (state.backtracking > 0) { Memoize(input, 16, enumConstants_StartIndex); }
        }
     	DebugLocation(437, 4);
    	} finally { DebugExitRule(GrammarFileName, "enumConstants"); }
    	return retval;

    }
    // $ANTLR end "enumConstants"

    public class enumConstant_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_enumConstant() {}
    protected virtual void Leave_enumConstant() {}

    // $ANTLR start "enumConstant"
    // Java.g:439:1: enumConstant : ( annotations )? IDENTIFIER ( arguments )? ( classBody )? ;
    [GrammarRule("enumConstant")]
    public JavaParser.enumConstant_return enumConstant()
    {

        JavaParser.enumConstant_return retval = new JavaParser.enumConstant_return();
        retval.Start = (IToken)input.LT(1);
        int enumConstant_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER80=null;
        JavaParser.annotations_return annotations79 = default(JavaParser.annotations_return);
        JavaParser.arguments_return arguments81 = default(JavaParser.arguments_return);
        JavaParser.classBody_return classBody82 = default(JavaParser.classBody_return);

        object IDENTIFIER80_tree=null;

    	try { DebugEnterRule(GrammarFileName, "enumConstant");
    	DebugLocation(439, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 17)) { return retval; }
    		// Java.g:444:5: ( ( annotations )? IDENTIFIER ( arguments )? ( classBody )? )
    		DebugEnterAlt(1);
    		// Java.g:444:9: ( annotations )? IDENTIFIER ( arguments )? ( classBody )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(444, 9);
    		// Java.g:444:9: ( annotations )?
    		int alt27=2;
    		try { DebugEnterSubRule(27);
    		try { DebugEnterDecision(27, decisionCanBacktrack[27]);
    		int LA27_0 = input.LA(1);

    		if ((LA27_0==MONKEYS_AT))
    		{
    			alt27=1;
    		}
    		} finally { DebugExitDecision(27); }
    		switch (alt27)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:444:10: annotations
    			{
    			DebugLocation(444, 10);
    			PushFollow(Follow._annotations_in_enumConstant1265);
    			annotations79=annotations();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotations79.Tree, annotations79, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(27); }

    		DebugLocation(446, 9);
    		IDENTIFIER80=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_enumConstant1286), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER80_tree = (object)adaptor.Create(IDENTIFIER80, retval);
    		adaptor.AddChild(root_0, IDENTIFIER80_tree);
    		}
    		DebugLocation(447, 9);
    		// Java.g:447:9: ( arguments )?
    		int alt28=2;
    		try { DebugEnterSubRule(28);
    		try { DebugEnterDecision(28, decisionCanBacktrack[28]);
    		int LA28_0 = input.LA(1);

    		if ((LA28_0==LPAREN))
    		{
    			alt28=1;
    		}
    		} finally { DebugExitDecision(28); }
    		switch (alt28)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:447:10: arguments
    			{
    			DebugLocation(447, 10);
    			PushFollow(Follow._arguments_in_enumConstant1297);
    			arguments81=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments81.Tree, arguments81, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(28); }

    		DebugLocation(449, 9);
    		// Java.g:449:9: ( classBody )?
    		int alt29=2;
    		try { DebugEnterSubRule(29);
    		try { DebugEnterDecision(29, decisionCanBacktrack[29]);
    		int LA29_0 = input.LA(1);

    		if ((LA29_0==LBRACE))
    		{
    			alt29=1;
    		}
    		} finally { DebugExitDecision(29); }
    		switch (alt29)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:449:10: classBody
    			{
    			DebugLocation(449, 10);
    			PushFollow(Follow._classBody_in_enumConstant1319);
    			classBody82=classBody();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classBody82.Tree, classBody82, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(29); }


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
            if (state.backtracking > 0) { Memoize(input, 17, enumConstant_StartIndex); }
        }
     	DebugLocation(453, 4);
    	} finally { DebugExitRule(GrammarFileName, "enumConstant"); }
    	return retval;

    }
    // $ANTLR end "enumConstant"

    public class enumBodyDeclarations_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_enumBodyDeclarations() {}
    protected virtual void Leave_enumBodyDeclarations() {}

    // $ANTLR start "enumBodyDeclarations"
    // Java.g:455:1: enumBodyDeclarations : ';' ( classBodyDeclaration )* ;
    [GrammarRule("enumBodyDeclarations")]
    public JavaParser.enumBodyDeclarations_return enumBodyDeclarations()
    {

        JavaParser.enumBodyDeclarations_return retval = new JavaParser.enumBodyDeclarations_return();
        retval.Start = (IToken)input.LT(1);
        int enumBodyDeclarations_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal83=null;
        JavaParser.classBodyDeclaration_return classBodyDeclaration84 = default(JavaParser.classBodyDeclaration_return);

        object char_literal83_tree=null;

    	try { DebugEnterRule(GrammarFileName, "enumBodyDeclarations");
    	DebugLocation(455, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 18)) { return retval; }
    		// Java.g:456:5: ( ';' ( classBodyDeclaration )* )
    		DebugEnterAlt(1);
    		// Java.g:456:9: ';' ( classBodyDeclaration )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(456, 9);
    		char_literal83=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_enumBodyDeclarations1360), "SEMI"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal83_tree = (object)adaptor.Create(char_literal83, retval);
    		adaptor.AddChild(root_0, char_literal83_tree);
    		}
    		DebugLocation(457, 9);
    		// Java.g:457:9: ( classBodyDeclaration )*
    		try { DebugEnterSubRule(30);
    		while (true)
    		{
    			int alt30=2;
    			try { DebugEnterDecision(30, decisionCanBacktrack[30]);
    			int LA30_0 = input.LA(1);

    			if ((LA30_0==IDENTIFIER||LA30_0==ABSTRACT||LA30_0==BOOLEAN||LA30_0==BYTE||(LA30_0>=CHAR && LA30_0<=CLASS)||LA30_0==DOUBLE||LA30_0==ENUM||LA30_0==FINAL||LA30_0==FLOAT||(LA30_0>=INT && LA30_0<=NATIVE)||(LA30_0>=PRIVATE && LA30_0<=PUBLIC)||(LA30_0>=SHORT && LA30_0<=STRICTFP)||LA30_0==SYNCHRONIZED||LA30_0==TRANSIENT||(LA30_0>=VOID && LA30_0<=VOLATILE)||LA30_0==LBRACE||LA30_0==SEMI||LA30_0==MONKEYS_AT||LA30_0==LT))
    			{
    				alt30=1;
    			}


    			} finally { DebugExitDecision(30); }
    			switch ( alt30 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:457:10: classBodyDeclaration
    				{
    				DebugLocation(457, 10);
    				PushFollow(Follow._classBodyDeclaration_in_enumBodyDeclarations1372);
    				classBodyDeclaration84=classBodyDeclaration();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classBodyDeclaration84.Tree, classBodyDeclaration84, retval);

    				}
    				break;

    			default:
    				goto loop30;
    			}
    		}

    		loop30:
    			;

    		} finally { DebugExitSubRule(30); }


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
            if (state.backtracking > 0) { Memoize(input, 18, enumBodyDeclarations_StartIndex); }
        }
     	DebugLocation(459, 4);
    	} finally { DebugExitRule(GrammarFileName, "enumBodyDeclarations"); }
    	return retval;

    }
    // $ANTLR end "enumBodyDeclarations"

    public class interfaceDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_interfaceDeclaration() {}
    protected virtual void Leave_interfaceDeclaration() {}

    // $ANTLR start "interfaceDeclaration"
    // Java.g:461:1: interfaceDeclaration : ( normalInterfaceDeclaration | annotationTypeDeclaration );
    [GrammarRule("interfaceDeclaration")]
    public JavaParser.interfaceDeclaration_return interfaceDeclaration()
    {

        JavaParser.interfaceDeclaration_return retval = new JavaParser.interfaceDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int interfaceDeclaration_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.normalInterfaceDeclaration_return normalInterfaceDeclaration85 = default(JavaParser.normalInterfaceDeclaration_return);
        JavaParser.annotationTypeDeclaration_return annotationTypeDeclaration86 = default(JavaParser.annotationTypeDeclaration_return);


    	try { DebugEnterRule(GrammarFileName, "interfaceDeclaration");
    	DebugLocation(461, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 19)) { return retval; }
    		// Java.g:462:5: ( normalInterfaceDeclaration | annotationTypeDeclaration )
    		int alt31=2;
    		try { DebugEnterDecision(31, decisionCanBacktrack[31]);
    		try
    		{
    			alt31 = dfa31.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(31); }
    		switch (alt31)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:462:9: normalInterfaceDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(462, 9);
    			PushFollow(Follow._normalInterfaceDeclaration_in_interfaceDeclaration1403);
    			normalInterfaceDeclaration85=normalInterfaceDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, normalInterfaceDeclaration85.Tree, normalInterfaceDeclaration85, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:463:9: annotationTypeDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(463, 9);
    			PushFollow(Follow._annotationTypeDeclaration_in_interfaceDeclaration1413);
    			annotationTypeDeclaration86=annotationTypeDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotationTypeDeclaration86.Tree, annotationTypeDeclaration86, retval);

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
            if (state.backtracking > 0) { Memoize(input, 19, interfaceDeclaration_StartIndex); }
        }
     	DebugLocation(464, 4);
    	} finally { DebugExitRule(GrammarFileName, "interfaceDeclaration"); }
    	return retval;

    }
    // $ANTLR end "interfaceDeclaration"

    public class normalInterfaceDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_normalInterfaceDeclaration() {}
    protected virtual void Leave_normalInterfaceDeclaration() {}

    // $ANTLR start "normalInterfaceDeclaration"
    // Java.g:466:1: normalInterfaceDeclaration : modifiers 'interface' IDENTIFIER ( typeParameters )? ( 'extends' typeList )? interfaceBody ;
    [GrammarRule("normalInterfaceDeclaration")]
    public JavaParser.normalInterfaceDeclaration_return normalInterfaceDeclaration()
    {

        JavaParser.normalInterfaceDeclaration_return retval = new JavaParser.normalInterfaceDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int normalInterfaceDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal88=null;
        IToken IDENTIFIER89=null;
        IToken string_literal91=null;
        JavaParser.modifiers_return modifiers87 = default(JavaParser.modifiers_return);
        JavaParser.typeParameters_return typeParameters90 = default(JavaParser.typeParameters_return);
        JavaParser.typeList_return typeList92 = default(JavaParser.typeList_return);
        JavaParser.interfaceBody_return interfaceBody93 = default(JavaParser.interfaceBody_return);

        object string_literal88_tree=null;
        object IDENTIFIER89_tree=null;
        object string_literal91_tree=null;

    	try { DebugEnterRule(GrammarFileName, "normalInterfaceDeclaration");
    	DebugLocation(466, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 20)) { return retval; }
    		// Java.g:467:5: ( modifiers 'interface' IDENTIFIER ( typeParameters )? ( 'extends' typeList )? interfaceBody )
    		DebugEnterAlt(1);
    		// Java.g:467:9: modifiers 'interface' IDENTIFIER ( typeParameters )? ( 'extends' typeList )? interfaceBody
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(467, 9);
    		PushFollow(Follow._modifiers_in_normalInterfaceDeclaration1437);
    		modifiers87=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers87.Tree, modifiers87, retval);
    		DebugLocation(467, 19);
    		string_literal88=(IToken)new XToken((IToken)Match(input,INTERFACE,Follow._INTERFACE_in_normalInterfaceDeclaration1439), "INTERFACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal88_tree = (object)adaptor.Create(string_literal88, retval);
    		adaptor.AddChild(root_0, string_literal88_tree);
    		}
    		DebugLocation(467, 31);
    		IDENTIFIER89=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_normalInterfaceDeclaration1441), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER89_tree = (object)adaptor.Create(IDENTIFIER89, retval);
    		adaptor.AddChild(root_0, IDENTIFIER89_tree);
    		}
    		DebugLocation(468, 9);
    		// Java.g:468:9: ( typeParameters )?
    		int alt32=2;
    		try { DebugEnterSubRule(32);
    		try { DebugEnterDecision(32, decisionCanBacktrack[32]);
    		int LA32_0 = input.LA(1);

    		if ((LA32_0==LT))
    		{
    			alt32=1;
    		}
    		} finally { DebugExitDecision(32); }
    		switch (alt32)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:468:10: typeParameters
    			{
    			DebugLocation(468, 10);
    			PushFollow(Follow._typeParameters_in_normalInterfaceDeclaration1452);
    			typeParameters90=typeParameters();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameters90.Tree, typeParameters90, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(32); }

    		DebugLocation(470, 9);
    		// Java.g:470:9: ( 'extends' typeList )?
    		int alt33=2;
    		try { DebugEnterSubRule(33);
    		try { DebugEnterDecision(33, decisionCanBacktrack[33]);
    		int LA33_0 = input.LA(1);

    		if ((LA33_0==EXTENDS))
    		{
    			alt33=1;
    		}
    		} finally { DebugExitDecision(33); }
    		switch (alt33)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:470:10: 'extends' typeList
    			{
    			DebugLocation(470, 10);
    			string_literal91=(IToken)new XToken((IToken)Match(input,EXTENDS,Follow._EXTENDS_in_normalInterfaceDeclaration1474), "EXTENDS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal91_tree = (object)adaptor.Create(string_literal91, retval);
    			adaptor.AddChild(root_0, string_literal91_tree);
    			}
    			DebugLocation(470, 20);
    			PushFollow(Follow._typeList_in_normalInterfaceDeclaration1476);
    			typeList92=typeList();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeList92.Tree, typeList92, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(33); }

    		DebugLocation(472, 9);
    		PushFollow(Follow._interfaceBody_in_normalInterfaceDeclaration1497);
    		interfaceBody93=interfaceBody();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceBody93.Tree, interfaceBody93, retval);

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
            if (state.backtracking > 0) { Memoize(input, 20, normalInterfaceDeclaration_StartIndex); }
        }
     	DebugLocation(473, 4);
    	} finally { DebugExitRule(GrammarFileName, "normalInterfaceDeclaration"); }
    	return retval;

    }
    // $ANTLR end "normalInterfaceDeclaration"

    public class typeList_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeList() {}
    protected virtual void Leave_typeList() {}

    // $ANTLR start "typeList"
    // Java.g:475:1: typeList : type ( ',' type )* ;
    [GrammarRule("typeList")]
    public JavaParser.typeList_return typeList()
    {

        JavaParser.typeList_return retval = new JavaParser.typeList_return();
        retval.Start = (IToken)input.LT(1);
        int typeList_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal95=null;
        JavaParser.type_return type94 = default(JavaParser.type_return);
        JavaParser.type_return type96 = default(JavaParser.type_return);

        object char_literal95_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeList");
    	DebugLocation(475, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 21)) { return retval; }
    		// Java.g:476:5: ( type ( ',' type )* )
    		DebugEnterAlt(1);
    		// Java.g:476:9: type ( ',' type )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(476, 9);
    		PushFollow(Follow._type_in_typeList1517);
    		type94=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type94.Tree, type94, retval);
    		DebugLocation(477, 9);
    		// Java.g:477:9: ( ',' type )*
    		try { DebugEnterSubRule(34);
    		while (true)
    		{
    			int alt34=2;
    			try { DebugEnterDecision(34, decisionCanBacktrack[34]);
    			int LA34_0 = input.LA(1);

    			if ((LA34_0==COMMA))
    			{
    				alt34=1;
    			}


    			} finally { DebugExitDecision(34); }
    			switch ( alt34 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:477:10: ',' type
    				{
    				DebugLocation(477, 10);
    				char_literal95=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_typeList1528), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal95_tree = (object)adaptor.Create(char_literal95, retval);
    				adaptor.AddChild(root_0, char_literal95_tree);
    				}
    				DebugLocation(477, 14);
    				PushFollow(Follow._type_in_typeList1530);
    				type96=type();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type96.Tree, type96, retval);

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
            if (state.backtracking > 0) { Memoize(input, 21, typeList_StartIndex); }
        }
     	DebugLocation(479, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeList"); }
    	return retval;

    }
    // $ANTLR end "typeList"

    public class classBody_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_classBody() {}
    protected virtual void Leave_classBody() {}

    // $ANTLR start "classBody"
    // Java.g:481:1: classBody : '{' ( classBodyDeclaration )* '}' ;
    [GrammarRule("classBody")]
    public JavaParser.classBody_return classBody()
    {

        JavaParser.classBody_return retval = new JavaParser.classBody_return();
        retval.Start = (IToken)input.LT(1);
        int classBody_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal97=null;
        IToken char_literal99=null;
        JavaParser.classBodyDeclaration_return classBodyDeclaration98 = default(JavaParser.classBodyDeclaration_return);

        object char_literal97_tree=null;
        object char_literal99_tree=null;

    	try { DebugEnterRule(GrammarFileName, "classBody");
    	DebugLocation(481, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 22)) { return retval; }
    		// Java.g:482:5: ( '{' ( classBodyDeclaration )* '}' )
    		DebugEnterAlt(1);
    		// Java.g:482:9: '{' ( classBodyDeclaration )* '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(482, 9);
    		char_literal97=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_classBody1561), "LBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal97_tree = (object)adaptor.Create(char_literal97, retval);
    		adaptor.AddChild(root_0, char_literal97_tree);
    		}
    		DebugLocation(483, 9);
    		// Java.g:483:9: ( classBodyDeclaration )*
    		try { DebugEnterSubRule(35);
    		while (true)
    		{
    			int alt35=2;
    			try { DebugEnterDecision(35, decisionCanBacktrack[35]);
    			int LA35_0 = input.LA(1);

    			if ((LA35_0==IDENTIFIER||LA35_0==ABSTRACT||LA35_0==BOOLEAN||LA35_0==BYTE||(LA35_0>=CHAR && LA35_0<=CLASS)||LA35_0==DOUBLE||LA35_0==ENUM||LA35_0==FINAL||LA35_0==FLOAT||(LA35_0>=INT && LA35_0<=NATIVE)||(LA35_0>=PRIVATE && LA35_0<=PUBLIC)||(LA35_0>=SHORT && LA35_0<=STRICTFP)||LA35_0==SYNCHRONIZED||LA35_0==TRANSIENT||(LA35_0>=VOID && LA35_0<=VOLATILE)||LA35_0==LBRACE||LA35_0==SEMI||LA35_0==MONKEYS_AT||LA35_0==LT))
    			{
    				alt35=1;
    			}


    			} finally { DebugExitDecision(35); }
    			switch ( alt35 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:483:10: classBodyDeclaration
    				{
    				DebugLocation(483, 10);
    				PushFollow(Follow._classBodyDeclaration_in_classBody1573);
    				classBodyDeclaration98=classBodyDeclaration();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classBodyDeclaration98.Tree, classBodyDeclaration98, retval);

    				}
    				break;

    			default:
    				goto loop35;
    			}
    		}

    		loop35:
    			;

    		} finally { DebugExitSubRule(35); }

    		DebugLocation(485, 9);
    		char_literal99=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_classBody1595), "RBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal99_tree = (object)adaptor.Create(char_literal99, retval);
    		adaptor.AddChild(root_0, char_literal99_tree);
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
            if (state.backtracking > 0) { Memoize(input, 22, classBody_StartIndex); }
        }
     	DebugLocation(486, 4);
    	} finally { DebugExitRule(GrammarFileName, "classBody"); }
    	return retval;

    }
    // $ANTLR end "classBody"

    public class interfaceBody_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_interfaceBody() {}
    protected virtual void Leave_interfaceBody() {}

    // $ANTLR start "interfaceBody"
    // Java.g:488:1: interfaceBody : '{' ( interfaceBodyDeclaration )* '}' ;
    [GrammarRule("interfaceBody")]
    public JavaParser.interfaceBody_return interfaceBody()
    {

        JavaParser.interfaceBody_return retval = new JavaParser.interfaceBody_return();
        retval.Start = (IToken)input.LT(1);
        int interfaceBody_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal100=null;
        IToken char_literal102=null;
        JavaParser.interfaceBodyDeclaration_return interfaceBodyDeclaration101 = default(JavaParser.interfaceBodyDeclaration_return);

        object char_literal100_tree=null;
        object char_literal102_tree=null;

    	try { DebugEnterRule(GrammarFileName, "interfaceBody");
    	DebugLocation(488, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 23)) { return retval; }
    		// Java.g:489:5: ( '{' ( interfaceBodyDeclaration )* '}' )
    		DebugEnterAlt(1);
    		// Java.g:489:9: '{' ( interfaceBodyDeclaration )* '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(489, 9);
    		char_literal100=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_interfaceBody1615), "LBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal100_tree = (object)adaptor.Create(char_literal100, retval);
    		adaptor.AddChild(root_0, char_literal100_tree);
    		}
    		DebugLocation(490, 9);
    		// Java.g:490:9: ( interfaceBodyDeclaration )*
    		try { DebugEnterSubRule(36);
    		while (true)
    		{
    			int alt36=2;
    			try { DebugEnterDecision(36, decisionCanBacktrack[36]);
    			int LA36_0 = input.LA(1);

    			if ((LA36_0==IDENTIFIER||LA36_0==ABSTRACT||LA36_0==BOOLEAN||LA36_0==BYTE||(LA36_0>=CHAR && LA36_0<=CLASS)||LA36_0==DOUBLE||LA36_0==ENUM||LA36_0==FINAL||LA36_0==FLOAT||(LA36_0>=INT && LA36_0<=NATIVE)||(LA36_0>=PRIVATE && LA36_0<=PUBLIC)||(LA36_0>=SHORT && LA36_0<=STRICTFP)||LA36_0==SYNCHRONIZED||LA36_0==TRANSIENT||(LA36_0>=VOID && LA36_0<=VOLATILE)||LA36_0==SEMI||LA36_0==MONKEYS_AT||LA36_0==LT))
    			{
    				alt36=1;
    			}


    			} finally { DebugExitDecision(36); }
    			switch ( alt36 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:490:10: interfaceBodyDeclaration
    				{
    				DebugLocation(490, 10);
    				PushFollow(Follow._interfaceBodyDeclaration_in_interfaceBody1627);
    				interfaceBodyDeclaration101=interfaceBodyDeclaration();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceBodyDeclaration101.Tree, interfaceBodyDeclaration101, retval);

    				}
    				break;

    			default:
    				goto loop36;
    			}
    		}

    		loop36:
    			;

    		} finally { DebugExitSubRule(36); }

    		DebugLocation(492, 9);
    		char_literal102=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_interfaceBody1649), "RBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal102_tree = (object)adaptor.Create(char_literal102, retval);
    		adaptor.AddChild(root_0, char_literal102_tree);
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
            if (state.backtracking > 0) { Memoize(input, 23, interfaceBody_StartIndex); }
        }
     	DebugLocation(493, 4);
    	} finally { DebugExitRule(GrammarFileName, "interfaceBody"); }
    	return retval;

    }
    // $ANTLR end "interfaceBody"

    public class classBodyDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_classBodyDeclaration() {}
    protected virtual void Leave_classBodyDeclaration() {}

    // $ANTLR start "classBodyDeclaration"
    // Java.g:495:1: classBodyDeclaration : ( ';' | ( 'static' )? block | memberDecl );
    [GrammarRule("classBodyDeclaration")]
    public JavaParser.classBodyDeclaration_return classBodyDeclaration()
    {

        JavaParser.classBodyDeclaration_return retval = new JavaParser.classBodyDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int classBodyDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal103=null;
        IToken string_literal104=null;
        JavaParser.block_return block105 = default(JavaParser.block_return);
        JavaParser.memberDecl_return memberDecl106 = default(JavaParser.memberDecl_return);

        object char_literal103_tree=null;
        object string_literal104_tree=null;

    	try { DebugEnterRule(GrammarFileName, "classBodyDeclaration");
    	DebugLocation(495, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 24)) { return retval; }
    		// Java.g:496:5: ( ';' | ( 'static' )? block | memberDecl )
    		int alt38=3;
    		try { DebugEnterDecision(38, decisionCanBacktrack[38]);
    		switch (input.LA(1))
    		{
    		case SEMI:
    			{
    			alt38=1;
    			}
    			break;
    		case STATIC:
    			{
    			int LA38_2 = input.LA(2);

    			if ((LA38_2==LBRACE))
    			{
    				alt38=2;
    			}
    			else if ((LA38_2==IDENTIFIER||LA38_2==ABSTRACT||LA38_2==BOOLEAN||LA38_2==BYTE||(LA38_2>=CHAR && LA38_2<=CLASS)||LA38_2==DOUBLE||LA38_2==ENUM||LA38_2==FINAL||LA38_2==FLOAT||(LA38_2>=INT && LA38_2<=NATIVE)||(LA38_2>=PRIVATE && LA38_2<=PUBLIC)||(LA38_2>=SHORT && LA38_2<=STRICTFP)||LA38_2==SYNCHRONIZED||LA38_2==TRANSIENT||(LA38_2>=VOID && LA38_2<=VOLATILE)||LA38_2==MONKEYS_AT||LA38_2==LT))
    			{
    				alt38=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 38, 2, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case LBRACE:
    			{
    			alt38=2;
    			}
    			break;
    		case IDENTIFIER:
    		case ABSTRACT:
    		case BOOLEAN:
    		case BYTE:
    		case CHAR:
    		case CLASS:
    		case DOUBLE:
    		case ENUM:
    		case FINAL:
    		case FLOAT:
    		case INT:
    		case INTERFACE:
    		case LONG:
    		case NATIVE:
    		case PRIVATE:
    		case PROTECTED:
    		case PUBLIC:
    		case SHORT:
    		case STRICTFP:
    		case SYNCHRONIZED:
    		case TRANSIENT:
    		case VOID:
    		case VOLATILE:
    		case MONKEYS_AT:
    		case LT:
    			{
    			alt38=3;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 38, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(38); }
    		switch (alt38)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:496:9: ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(496, 9);
    			char_literal103=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_classBodyDeclaration1669), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal103_tree = (object)adaptor.Create(char_literal103, retval);
    			adaptor.AddChild(root_0, char_literal103_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:497:9: ( 'static' )? block
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(497, 9);
    			// Java.g:497:9: ( 'static' )?
    			int alt37=2;
    			try { DebugEnterSubRule(37);
    			try { DebugEnterDecision(37, decisionCanBacktrack[37]);
    			int LA37_0 = input.LA(1);

    			if ((LA37_0==STATIC))
    			{
    				alt37=1;
    			}
    			} finally { DebugExitDecision(37); }
    			switch (alt37)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:497:10: 'static'
    				{
    				DebugLocation(497, 10);
    				string_literal104=(IToken)new XToken((IToken)Match(input,STATIC,Follow._STATIC_in_classBodyDeclaration1680), "STATIC"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal104_tree = (object)adaptor.Create(string_literal104, retval);
    				adaptor.AddChild(root_0, string_literal104_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(37); }

    			DebugLocation(499, 9);
    			PushFollow(Follow._block_in_classBodyDeclaration1702);
    			block105=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block105.Tree, block105, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:500:9: memberDecl
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(500, 9);
    			PushFollow(Follow._memberDecl_in_classBodyDeclaration1712);
    			memberDecl106=memberDecl();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, memberDecl106.Tree, memberDecl106, retval);

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
            if (state.backtracking > 0) { Memoize(input, 24, classBodyDeclaration_StartIndex); }
        }
     	DebugLocation(501, 4);
    	} finally { DebugExitRule(GrammarFileName, "classBodyDeclaration"); }
    	return retval;

    }
    // $ANTLR end "classBodyDeclaration"

    public class memberDecl_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_memberDecl() {}
    protected virtual void Leave_memberDecl() {}

    // $ANTLR start "memberDecl"
    // Java.g:503:1: memberDecl : ( fieldDeclaration | methodDeclaration | classDeclaration | interfaceDeclaration );
    [GrammarRule("memberDecl")]
    public JavaParser.memberDecl_return memberDecl()
    {

        JavaParser.memberDecl_return retval = new JavaParser.memberDecl_return();
        retval.Start = (IToken)input.LT(1);
        int memberDecl_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.fieldDeclaration_return fieldDeclaration107 = default(JavaParser.fieldDeclaration_return);
        JavaParser.methodDeclaration_return methodDeclaration108 = default(JavaParser.methodDeclaration_return);
        JavaParser.classDeclaration_return classDeclaration109 = default(JavaParser.classDeclaration_return);
        JavaParser.interfaceDeclaration_return interfaceDeclaration110 = default(JavaParser.interfaceDeclaration_return);


    	try { DebugEnterRule(GrammarFileName, "memberDecl");
    	DebugLocation(503, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 25)) { return retval; }
    		// Java.g:504:5: ( fieldDeclaration | methodDeclaration | classDeclaration | interfaceDeclaration )
    		int alt39=4;
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
    			// Java.g:504:10: fieldDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(504, 10);
    			PushFollow(Follow._fieldDeclaration_in_memberDecl1733);
    			fieldDeclaration107=fieldDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, fieldDeclaration107.Tree, fieldDeclaration107, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:505:10: methodDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(505, 10);
    			PushFollow(Follow._methodDeclaration_in_memberDecl1744);
    			methodDeclaration108=methodDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, methodDeclaration108.Tree, methodDeclaration108, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:506:10: classDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(506, 10);
    			PushFollow(Follow._classDeclaration_in_memberDecl1755);
    			classDeclaration109=classDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classDeclaration109.Tree, classDeclaration109, retval);

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:507:10: interfaceDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(507, 10);
    			PushFollow(Follow._interfaceDeclaration_in_memberDecl1766);
    			interfaceDeclaration110=interfaceDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceDeclaration110.Tree, interfaceDeclaration110, retval);

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
            if (state.backtracking > 0) { Memoize(input, 25, memberDecl_StartIndex); }
        }
     	DebugLocation(508, 4);
    	} finally { DebugExitRule(GrammarFileName, "memberDecl"); }
    	return retval;

    }
    // $ANTLR end "memberDecl"

    public class methodDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_methodDeclaration() {}
    protected virtual void Leave_methodDeclaration() {}

    // $ANTLR start "methodDeclaration"
    // Java.g:511:1: methodDeclaration : ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' | modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' ) );
    [GrammarRule("methodDeclaration")]
    public JavaParser.methodDeclaration_return methodDeclaration()
    {

        JavaParser.methodDeclaration_return retval = new JavaParser.methodDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int methodDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER113=null;
        IToken string_literal115=null;
        IToken char_literal117=null;
        IToken char_literal120=null;
        IToken string_literal124=null;
        IToken IDENTIFIER125=null;
        IToken char_literal127=null;
        IToken char_literal128=null;
        IToken string_literal129=null;
        IToken char_literal132=null;
        JavaParser.modifiers_return modifiers111 = default(JavaParser.modifiers_return);
        JavaParser.typeParameters_return typeParameters112 = default(JavaParser.typeParameters_return);
        JavaParser.formalParameters_return formalParameters114 = default(JavaParser.formalParameters_return);
        JavaParser.qualifiedNameList_return qualifiedNameList116 = default(JavaParser.qualifiedNameList_return);
        JavaParser.explicitConstructorInvocation_return explicitConstructorInvocation118 = default(JavaParser.explicitConstructorInvocation_return);
        JavaParser.blockStatement_return blockStatement119 = default(JavaParser.blockStatement_return);
        JavaParser.modifiers_return modifiers121 = default(JavaParser.modifiers_return);
        JavaParser.typeParameters_return typeParameters122 = default(JavaParser.typeParameters_return);
        JavaParser.type_return type123 = default(JavaParser.type_return);
        JavaParser.formalParameters_return formalParameters126 = default(JavaParser.formalParameters_return);
        JavaParser.qualifiedNameList_return qualifiedNameList130 = default(JavaParser.qualifiedNameList_return);
        JavaParser.block_return block131 = default(JavaParser.block_return);

        object IDENTIFIER113_tree=null;
        object string_literal115_tree=null;
        object char_literal117_tree=null;
        object char_literal120_tree=null;
        object string_literal124_tree=null;
        object IDENTIFIER125_tree=null;
        object char_literal127_tree=null;
        object char_literal128_tree=null;
        object string_literal129_tree=null;
        object char_literal132_tree=null;

    	try { DebugEnterRule(GrammarFileName, "methodDeclaration");
    	DebugLocation(511, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 26)) { return retval; }
    		// Java.g:512:5: ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' | modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' ) )
    		int alt49=2;
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
    		switch (alt49)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:514:10: modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(514, 10);
    			PushFollow(Follow._modifiers_in_methodDeclaration1804);
    			modifiers111=modifiers();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers111.Tree, modifiers111, retval);
    			DebugLocation(515, 9);
    			// Java.g:515:9: ( typeParameters )?
    			int alt40=2;
    			try { DebugEnterSubRule(40);
    			try { DebugEnterDecision(40, decisionCanBacktrack[40]);
    			int LA40_0 = input.LA(1);

    			if ((LA40_0==LT))
    			{
    				alt40=1;
    			}
    			} finally { DebugExitDecision(40); }
    			switch (alt40)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:515:10: typeParameters
    				{
    				DebugLocation(515, 10);
    				PushFollow(Follow._typeParameters_in_methodDeclaration1815);
    				typeParameters112=typeParameters();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameters112.Tree, typeParameters112, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(40); }

    			DebugLocation(517, 9);
    			IDENTIFIER113=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_methodDeclaration1836), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER113_tree = (object)adaptor.Create(IDENTIFIER113, retval);
    			adaptor.AddChild(root_0, IDENTIFIER113_tree);
    			}
    			DebugLocation(518, 9);
    			PushFollow(Follow._formalParameters_in_methodDeclaration1846);
    			formalParameters114=formalParameters();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, formalParameters114.Tree, formalParameters114, retval);
    			DebugLocation(519, 9);
    			// Java.g:519:9: ( 'throws' qualifiedNameList )?
    			int alt41=2;
    			try { DebugEnterSubRule(41);
    			try { DebugEnterDecision(41, decisionCanBacktrack[41]);
    			int LA41_0 = input.LA(1);

    			if ((LA41_0==THROWS))
    			{
    				alt41=1;
    			}
    			} finally { DebugExitDecision(41); }
    			switch (alt41)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:519:10: 'throws' qualifiedNameList
    				{
    				DebugLocation(519, 10);
    				string_literal115=(IToken)new XToken((IToken)Match(input,THROWS,Follow._THROWS_in_methodDeclaration1857), "THROWS"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal115_tree = (object)adaptor.Create(string_literal115, retval);
    				adaptor.AddChild(root_0, string_literal115_tree);
    				}
    				DebugLocation(519, 19);
    				PushFollow(Follow._qualifiedNameList_in_methodDeclaration1859);
    				qualifiedNameList116=qualifiedNameList();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, qualifiedNameList116.Tree, qualifiedNameList116, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(41); }

    			DebugLocation(521, 9);
    			char_literal117=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_methodDeclaration1880), "LBRACE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal117_tree = (object)adaptor.Create(char_literal117, retval);
    			adaptor.AddChild(root_0, char_literal117_tree);
    			}
    			DebugLocation(522, 9);
    			// Java.g:522:9: ( explicitConstructorInvocation )?
    			int alt42=2;
    			try { DebugEnterSubRule(42);
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
    				// Java.g:522:10: explicitConstructorInvocation
    				{
    				DebugLocation(522, 10);
    				PushFollow(Follow._explicitConstructorInvocation_in_methodDeclaration1892);
    				explicitConstructorInvocation118=explicitConstructorInvocation();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, explicitConstructorInvocation118.Tree, explicitConstructorInvocation118, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(42); }

    			DebugLocation(524, 9);
    			// Java.g:524:9: ( blockStatement )*
    			try { DebugEnterSubRule(43);
    			while (true)
    			{
    				int alt43=2;
    				try { DebugEnterDecision(43, decisionCanBacktrack[43]);
    				int LA43_0 = input.LA(1);

    				if (((LA43_0>=IDENTIFIER && LA43_0<=NULL)||(LA43_0>=ABSTRACT && LA43_0<=BYTE)||(LA43_0>=CHAR && LA43_0<=CLASS)||LA43_0==CONTINUE||(LA43_0>=DO && LA43_0<=DOUBLE)||LA43_0==ENUM||LA43_0==FINAL||(LA43_0>=FLOAT && LA43_0<=FOR)||LA43_0==IF||(LA43_0>=INT && LA43_0<=NEW)||(LA43_0>=PRIVATE && LA43_0<=THROW)||(LA43_0>=TRANSIENT && LA43_0<=LPAREN)||LA43_0==LBRACE||LA43_0==SEMI||(LA43_0>=BANG && LA43_0<=TILDE)||(LA43_0>=PLUSPLUS && LA43_0<=SUB)||LA43_0==MONKEYS_AT||LA43_0==LT))
    				{
    					alt43=1;
    				}


    				} finally { DebugExitDecision(43); }
    				switch ( alt43 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:524:10: blockStatement
    					{
    					DebugLocation(524, 10);
    					PushFollow(Follow._blockStatement_in_methodDeclaration1914);
    					blockStatement119=blockStatement();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, blockStatement119.Tree, blockStatement119, retval);

    					}
    					break;

    				default:
    					goto loop43;
    				}
    			}

    			loop43:
    				;

    			} finally { DebugExitSubRule(43); }

    			DebugLocation(526, 9);
    			char_literal120=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_methodDeclaration1935), "RBRACE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal120_tree = (object)adaptor.Create(char_literal120, retval);
    			adaptor.AddChild(root_0, char_literal120_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:527:9: modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' )
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(527, 9);
    			PushFollow(Follow._modifiers_in_methodDeclaration1945);
    			modifiers121=modifiers();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers121.Tree, modifiers121, retval);
    			DebugLocation(528, 9);
    			// Java.g:528:9: ( typeParameters )?
    			int alt44=2;
    			try { DebugEnterSubRule(44);
    			try { DebugEnterDecision(44, decisionCanBacktrack[44]);
    			int LA44_0 = input.LA(1);

    			if ((LA44_0==LT))
    			{
    				alt44=1;
    			}
    			} finally { DebugExitDecision(44); }
    			switch (alt44)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:528:10: typeParameters
    				{
    				DebugLocation(528, 10);
    				PushFollow(Follow._typeParameters_in_methodDeclaration1956);
    				typeParameters122=typeParameters();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameters122.Tree, typeParameters122, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(44); }

    			DebugLocation(530, 9);
    			// Java.g:530:9: ( type | 'void' )
    			int alt45=2;
    			try { DebugEnterSubRule(45);
    			try { DebugEnterDecision(45, decisionCanBacktrack[45]);
    			int LA45_0 = input.LA(1);

    			if ((LA45_0==IDENTIFIER||LA45_0==BOOLEAN||LA45_0==BYTE||LA45_0==CHAR||LA45_0==DOUBLE||LA45_0==FLOAT||LA45_0==INT||LA45_0==LONG||LA45_0==SHORT))
    			{
    				alt45=1;
    			}
    			else if ((LA45_0==VOID))
    			{
    				alt45=2;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 45, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			} finally { DebugExitDecision(45); }
    			switch (alt45)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:530:10: type
    				{
    				DebugLocation(530, 10);
    				PushFollow(Follow._type_in_methodDeclaration1978);
    				type123=type();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type123.Tree, type123, retval);

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Java.g:531:13: 'void'
    				{
    				DebugLocation(531, 13);
    				string_literal124=(IToken)new XToken((IToken)Match(input,VOID,Follow._VOID_in_methodDeclaration1992), "VOID"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal124_tree = (object)adaptor.Create(string_literal124, retval);
    				adaptor.AddChild(root_0, string_literal124_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(45); }

    			DebugLocation(533, 9);
    			IDENTIFIER125=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_methodDeclaration2012), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER125_tree = (object)adaptor.Create(IDENTIFIER125, retval);
    			adaptor.AddChild(root_0, IDENTIFIER125_tree);
    			}
    			DebugLocation(534, 9);
    			PushFollow(Follow._formalParameters_in_methodDeclaration2022);
    			formalParameters126=formalParameters();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, formalParameters126.Tree, formalParameters126, retval);
    			DebugLocation(535, 9);
    			// Java.g:535:9: ( '[' ']' )*
    			try { DebugEnterSubRule(46);
    			while (true)
    			{
    				int alt46=2;
    				try { DebugEnterDecision(46, decisionCanBacktrack[46]);
    				int LA46_0 = input.LA(1);

    				if ((LA46_0==LBRACKET))
    				{
    					alt46=1;
    				}


    				} finally { DebugExitDecision(46); }
    				switch ( alt46 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:535:10: '[' ']'
    					{
    					DebugLocation(535, 10);
    					char_literal127=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_methodDeclaration2033), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal127_tree = (object)adaptor.Create(char_literal127, retval);
    					adaptor.AddChild(root_0, char_literal127_tree);
    					}
    					DebugLocation(535, 14);
    					char_literal128=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_methodDeclaration2035), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal128_tree = (object)adaptor.Create(char_literal128, retval);
    					adaptor.AddChild(root_0, char_literal128_tree);
    					}

    					}
    					break;

    				default:
    					goto loop46;
    				}
    			}

    			loop46:
    				;

    			} finally { DebugExitSubRule(46); }

    			DebugLocation(537, 9);
    			// Java.g:537:9: ( 'throws' qualifiedNameList )?
    			int alt47=2;
    			try { DebugEnterSubRule(47);
    			try { DebugEnterDecision(47, decisionCanBacktrack[47]);
    			int LA47_0 = input.LA(1);

    			if ((LA47_0==THROWS))
    			{
    				alt47=1;
    			}
    			} finally { DebugExitDecision(47); }
    			switch (alt47)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:537:10: 'throws' qualifiedNameList
    				{
    				DebugLocation(537, 10);
    				string_literal129=(IToken)new XToken((IToken)Match(input,THROWS,Follow._THROWS_in_methodDeclaration2057), "THROWS"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal129_tree = (object)adaptor.Create(string_literal129, retval);
    				adaptor.AddChild(root_0, string_literal129_tree);
    				}
    				DebugLocation(537, 19);
    				PushFollow(Follow._qualifiedNameList_in_methodDeclaration2059);
    				qualifiedNameList130=qualifiedNameList();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, qualifiedNameList130.Tree, qualifiedNameList130, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(47); }

    			DebugLocation(539, 9);
    			// Java.g:539:9: ( block | ';' )
    			int alt48=2;
    			try { DebugEnterSubRule(48);
    			try { DebugEnterDecision(48, decisionCanBacktrack[48]);
    			int LA48_0 = input.LA(1);

    			if ((LA48_0==LBRACE))
    			{
    				alt48=1;
    			}
    			else if ((LA48_0==SEMI))
    			{
    				alt48=2;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 48, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			} finally { DebugExitDecision(48); }
    			switch (alt48)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:540:13: block
    				{
    				DebugLocation(540, 13);
    				PushFollow(Follow._block_in_methodDeclaration2114);
    				block131=block();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block131.Tree, block131, retval);

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Java.g:541:13: ';'
    				{
    				DebugLocation(541, 13);
    				char_literal132=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_methodDeclaration2128), "SEMI"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal132_tree = (object)adaptor.Create(char_literal132, retval);
    				adaptor.AddChild(root_0, char_literal132_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(48); }


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
            if (state.backtracking > 0) { Memoize(input, 26, methodDeclaration_StartIndex); }
        }
     	DebugLocation(543, 4);
    	} finally { DebugExitRule(GrammarFileName, "methodDeclaration"); }
    	return retval;

    }
    // $ANTLR end "methodDeclaration"

    public class fieldDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_fieldDeclaration() {}
    protected virtual void Leave_fieldDeclaration() {}

    // $ANTLR start "fieldDeclaration"
    // Java.g:546:1: fieldDeclaration : modifiers type variableDeclarator ( ',' variableDeclarator )* ';' ;
    [GrammarRule("fieldDeclaration")]
    public JavaParser.fieldDeclaration_return fieldDeclaration()
    {

        JavaParser.fieldDeclaration_return retval = new JavaParser.fieldDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int fieldDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal136=null;
        IToken char_literal138=null;
        JavaParser.modifiers_return modifiers133 = default(JavaParser.modifiers_return);
        JavaParser.type_return type134 = default(JavaParser.type_return);
        JavaParser.variableDeclarator_return variableDeclarator135 = default(JavaParser.variableDeclarator_return);
        JavaParser.variableDeclarator_return variableDeclarator137 = default(JavaParser.variableDeclarator_return);

        object char_literal136_tree=null;
        object char_literal138_tree=null;

    	try { DebugEnterRule(GrammarFileName, "fieldDeclaration");
    	DebugLocation(546, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 27)) { return retval; }
    		// Java.g:547:5: ( modifiers type variableDeclarator ( ',' variableDeclarator )* ';' )
    		DebugEnterAlt(1);
    		// Java.g:547:9: modifiers type variableDeclarator ( ',' variableDeclarator )* ';'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(547, 9);
    		PushFollow(Follow._modifiers_in_fieldDeclaration2160);
    		modifiers133=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers133.Tree, modifiers133, retval);
    		DebugLocation(548, 9);
    		PushFollow(Follow._type_in_fieldDeclaration2170);
    		type134=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type134.Tree, type134, retval);
    		DebugLocation(549, 9);
    		PushFollow(Follow._variableDeclarator_in_fieldDeclaration2180);
    		variableDeclarator135=variableDeclarator();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableDeclarator135.Tree, variableDeclarator135, retval);
    		DebugLocation(550, 9);
    		// Java.g:550:9: ( ',' variableDeclarator )*
    		try { DebugEnterSubRule(50);
    		while (true)
    		{
    			int alt50=2;
    			try { DebugEnterDecision(50, decisionCanBacktrack[50]);
    			int LA50_0 = input.LA(1);

    			if ((LA50_0==COMMA))
    			{
    				alt50=1;
    			}


    			} finally { DebugExitDecision(50); }
    			switch ( alt50 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:550:10: ',' variableDeclarator
    				{
    				DebugLocation(550, 10);
    				char_literal136=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_fieldDeclaration2191), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal136_tree = (object)adaptor.Create(char_literal136, retval);
    				adaptor.AddChild(root_0, char_literal136_tree);
    				}
    				DebugLocation(550, 14);
    				PushFollow(Follow._variableDeclarator_in_fieldDeclaration2193);
    				variableDeclarator137=variableDeclarator();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableDeclarator137.Tree, variableDeclarator137, retval);

    				}
    				break;

    			default:
    				goto loop50;
    			}
    		}

    		loop50:
    			;

    		} finally { DebugExitSubRule(50); }

    		DebugLocation(552, 9);
    		char_literal138=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_fieldDeclaration2214), "SEMI"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal138_tree = (object)adaptor.Create(char_literal138, retval);
    		adaptor.AddChild(root_0, char_literal138_tree);
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
            if (state.backtracking > 0) { Memoize(input, 27, fieldDeclaration_StartIndex); }
        }
     	DebugLocation(553, 4);
    	} finally { DebugExitRule(GrammarFileName, "fieldDeclaration"); }
    	return retval;

    }
    // $ANTLR end "fieldDeclaration"

    public class variableDeclarator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_variableDeclarator() {}
    protected virtual void Leave_variableDeclarator() {}

    // $ANTLR start "variableDeclarator"
    // Java.g:555:1: variableDeclarator : IDENTIFIER ( '[' ']' )* ( '=' variableInitializer )? ;
    [GrammarRule("variableDeclarator")]
    public JavaParser.variableDeclarator_return variableDeclarator()
    {

        JavaParser.variableDeclarator_return retval = new JavaParser.variableDeclarator_return();
        retval.Start = (IToken)input.LT(1);
        int variableDeclarator_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER139=null;
        IToken char_literal140=null;
        IToken char_literal141=null;
        IToken char_literal142=null;
        JavaParser.variableInitializer_return variableInitializer143 = default(JavaParser.variableInitializer_return);

        object IDENTIFIER139_tree=null;
        object char_literal140_tree=null;
        object char_literal141_tree=null;
        object char_literal142_tree=null;

    	try { DebugEnterRule(GrammarFileName, "variableDeclarator");
    	DebugLocation(555, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 28)) { return retval; }
    		// Java.g:556:5: ( IDENTIFIER ( '[' ']' )* ( '=' variableInitializer )? )
    		DebugEnterAlt(1);
    		// Java.g:556:9: IDENTIFIER ( '[' ']' )* ( '=' variableInitializer )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(556, 9);
    		IDENTIFIER139=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_variableDeclarator2234), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER139_tree = (object)adaptor.Create(IDENTIFIER139, retval);
    		adaptor.AddChild(root_0, IDENTIFIER139_tree);
    		}
    		DebugLocation(557, 9);
    		// Java.g:557:9: ( '[' ']' )*
    		try { DebugEnterSubRule(51);
    		while (true)
    		{
    			int alt51=2;
    			try { DebugEnterDecision(51, decisionCanBacktrack[51]);
    			int LA51_0 = input.LA(1);

    			if ((LA51_0==LBRACKET))
    			{
    				alt51=1;
    			}


    			} finally { DebugExitDecision(51); }
    			switch ( alt51 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:557:10: '[' ']'
    				{
    				DebugLocation(557, 10);
    				char_literal140=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_variableDeclarator2245), "LBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal140_tree = (object)adaptor.Create(char_literal140, retval);
    				adaptor.AddChild(root_0, char_literal140_tree);
    				}
    				DebugLocation(557, 14);
    				char_literal141=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_variableDeclarator2247), "RBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal141_tree = (object)adaptor.Create(char_literal141, retval);
    				adaptor.AddChild(root_0, char_literal141_tree);
    				}

    				}
    				break;

    			default:
    				goto loop51;
    			}
    		}

    		loop51:
    			;

    		} finally { DebugExitSubRule(51); }

    		DebugLocation(559, 9);
    		// Java.g:559:9: ( '=' variableInitializer )?
    		int alt52=2;
    		try { DebugEnterSubRule(52);
    		try { DebugEnterDecision(52, decisionCanBacktrack[52]);
    		int LA52_0 = input.LA(1);

    		if ((LA52_0==EQ))
    		{
    			alt52=1;
    		}
    		} finally { DebugExitDecision(52); }
    		switch (alt52)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:559:10: '=' variableInitializer
    			{
    			DebugLocation(559, 10);
    			char_literal142=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_variableDeclarator2269), "EQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal142_tree = (object)adaptor.Create(char_literal142, retval);
    			adaptor.AddChild(root_0, char_literal142_tree);
    			}
    			DebugLocation(559, 14);
    			PushFollow(Follow._variableInitializer_in_variableDeclarator2271);
    			variableInitializer143=variableInitializer();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableInitializer143.Tree, variableInitializer143, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(52); }


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
            if (state.backtracking > 0) { Memoize(input, 28, variableDeclarator_StartIndex); }
        }
     	DebugLocation(561, 4);
    	} finally { DebugExitRule(GrammarFileName, "variableDeclarator"); }
    	return retval;

    }
    // $ANTLR end "variableDeclarator"

    public class interfaceBodyDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_interfaceBodyDeclaration() {}
    protected virtual void Leave_interfaceBodyDeclaration() {}

    // $ANTLR start "interfaceBodyDeclaration"
    // Java.g:563:1: interfaceBodyDeclaration : ( interfaceFieldDeclaration | interfaceMethodDeclaration | interfaceDeclaration | classDeclaration | ';' );
    [GrammarRule("interfaceBodyDeclaration")]
    public JavaParser.interfaceBodyDeclaration_return interfaceBodyDeclaration()
    {

        JavaParser.interfaceBodyDeclaration_return retval = new JavaParser.interfaceBodyDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int interfaceBodyDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal148=null;
        JavaParser.interfaceFieldDeclaration_return interfaceFieldDeclaration144 = default(JavaParser.interfaceFieldDeclaration_return);
        JavaParser.interfaceMethodDeclaration_return interfaceMethodDeclaration145 = default(JavaParser.interfaceMethodDeclaration_return);
        JavaParser.interfaceDeclaration_return interfaceDeclaration146 = default(JavaParser.interfaceDeclaration_return);
        JavaParser.classDeclaration_return classDeclaration147 = default(JavaParser.classDeclaration_return);

        object char_literal148_tree=null;

    	try { DebugEnterRule(GrammarFileName, "interfaceBodyDeclaration");
    	DebugLocation(563, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 29)) { return retval; }
    		// Java.g:567:5: ( interfaceFieldDeclaration | interfaceMethodDeclaration | interfaceDeclaration | classDeclaration | ';' )
    		int alt53=5;
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
    			// Java.g:568:9: interfaceFieldDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(568, 9);
    			PushFollow(Follow._interfaceFieldDeclaration_in_interfaceBodyDeclaration2310);
    			interfaceFieldDeclaration144=interfaceFieldDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceFieldDeclaration144.Tree, interfaceFieldDeclaration144, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:569:9: interfaceMethodDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(569, 9);
    			PushFollow(Follow._interfaceMethodDeclaration_in_interfaceBodyDeclaration2320);
    			interfaceMethodDeclaration145=interfaceMethodDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceMethodDeclaration145.Tree, interfaceMethodDeclaration145, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:570:9: interfaceDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(570, 9);
    			PushFollow(Follow._interfaceDeclaration_in_interfaceBodyDeclaration2330);
    			interfaceDeclaration146=interfaceDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceDeclaration146.Tree, interfaceDeclaration146, retval);

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:571:9: classDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(571, 9);
    			PushFollow(Follow._classDeclaration_in_interfaceBodyDeclaration2340);
    			classDeclaration147=classDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classDeclaration147.Tree, classDeclaration147, retval);

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:572:9: ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(572, 9);
    			char_literal148=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_interfaceBodyDeclaration2350), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal148_tree = (object)adaptor.Create(char_literal148, retval);
    			adaptor.AddChild(root_0, char_literal148_tree);
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
            if (state.backtracking > 0) { Memoize(input, 29, interfaceBodyDeclaration_StartIndex); }
        }
     	DebugLocation(573, 4);
    	} finally { DebugExitRule(GrammarFileName, "interfaceBodyDeclaration"); }
    	return retval;

    }
    // $ANTLR end "interfaceBodyDeclaration"

    public class interfaceMethodDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_interfaceMethodDeclaration() {}
    protected virtual void Leave_interfaceMethodDeclaration() {}

    // $ANTLR start "interfaceMethodDeclaration"
    // Java.g:575:1: interfaceMethodDeclaration : modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ';' ;
    [GrammarRule("interfaceMethodDeclaration")]
    public JavaParser.interfaceMethodDeclaration_return interfaceMethodDeclaration()
    {

        JavaParser.interfaceMethodDeclaration_return retval = new JavaParser.interfaceMethodDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int interfaceMethodDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal152=null;
        IToken IDENTIFIER153=null;
        IToken char_literal155=null;
        IToken char_literal156=null;
        IToken string_literal157=null;
        IToken char_literal159=null;
        JavaParser.modifiers_return modifiers149 = default(JavaParser.modifiers_return);
        JavaParser.typeParameters_return typeParameters150 = default(JavaParser.typeParameters_return);
        JavaParser.type_return type151 = default(JavaParser.type_return);
        JavaParser.formalParameters_return formalParameters154 = default(JavaParser.formalParameters_return);
        JavaParser.qualifiedNameList_return qualifiedNameList158 = default(JavaParser.qualifiedNameList_return);

        object string_literal152_tree=null;
        object IDENTIFIER153_tree=null;
        object char_literal155_tree=null;
        object char_literal156_tree=null;
        object string_literal157_tree=null;
        object char_literal159_tree=null;

    	try { DebugEnterRule(GrammarFileName, "interfaceMethodDeclaration");
    	DebugLocation(575, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 30)) { return retval; }
    		// Java.g:576:5: ( modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ';' )
    		DebugEnterAlt(1);
    		// Java.g:576:9: modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ';'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(576, 9);
    		PushFollow(Follow._modifiers_in_interfaceMethodDeclaration2370);
    		modifiers149=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers149.Tree, modifiers149, retval);
    		DebugLocation(577, 9);
    		// Java.g:577:9: ( typeParameters )?
    		int alt54=2;
    		try { DebugEnterSubRule(54);
    		try { DebugEnterDecision(54, decisionCanBacktrack[54]);
    		int LA54_0 = input.LA(1);

    		if ((LA54_0==LT))
    		{
    			alt54=1;
    		}
    		} finally { DebugExitDecision(54); }
    		switch (alt54)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:577:10: typeParameters
    			{
    			DebugLocation(577, 10);
    			PushFollow(Follow._typeParameters_in_interfaceMethodDeclaration2381);
    			typeParameters150=typeParameters();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameters150.Tree, typeParameters150, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(54); }

    		DebugLocation(579, 9);
    		// Java.g:579:9: ( type | 'void' )
    		int alt55=2;
    		try { DebugEnterSubRule(55);
    		try { DebugEnterDecision(55, decisionCanBacktrack[55]);
    		int LA55_0 = input.LA(1);

    		if ((LA55_0==IDENTIFIER||LA55_0==BOOLEAN||LA55_0==BYTE||LA55_0==CHAR||LA55_0==DOUBLE||LA55_0==FLOAT||LA55_0==INT||LA55_0==LONG||LA55_0==SHORT))
    		{
    			alt55=1;
    		}
    		else if ((LA55_0==VOID))
    		{
    			alt55=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 55, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(55); }
    		switch (alt55)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:579:10: type
    			{
    			DebugLocation(579, 10);
    			PushFollow(Follow._type_in_interfaceMethodDeclaration2403);
    			type151=type();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type151.Tree, type151, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:580:10: 'void'
    			{
    			DebugLocation(580, 10);
    			string_literal152=(IToken)new XToken((IToken)Match(input,VOID,Follow._VOID_in_interfaceMethodDeclaration2414), "VOID"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal152_tree = (object)adaptor.Create(string_literal152, retval);
    			adaptor.AddChild(root_0, string_literal152_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(55); }

    		DebugLocation(582, 9);
    		IDENTIFIER153=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_interfaceMethodDeclaration2434), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER153_tree = (object)adaptor.Create(IDENTIFIER153, retval);
    		adaptor.AddChild(root_0, IDENTIFIER153_tree);
    		}
    		DebugLocation(583, 9);
    		PushFollow(Follow._formalParameters_in_interfaceMethodDeclaration2444);
    		formalParameters154=formalParameters();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, formalParameters154.Tree, formalParameters154, retval);
    		DebugLocation(584, 9);
    		// Java.g:584:9: ( '[' ']' )*
    		try { DebugEnterSubRule(56);
    		while (true)
    		{
    			int alt56=2;
    			try { DebugEnterDecision(56, decisionCanBacktrack[56]);
    			int LA56_0 = input.LA(1);

    			if ((LA56_0==LBRACKET))
    			{
    				alt56=1;
    			}


    			} finally { DebugExitDecision(56); }
    			switch ( alt56 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:584:10: '[' ']'
    				{
    				DebugLocation(584, 10);
    				char_literal155=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_interfaceMethodDeclaration2455), "LBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal155_tree = (object)adaptor.Create(char_literal155, retval);
    				adaptor.AddChild(root_0, char_literal155_tree);
    				}
    				DebugLocation(584, 14);
    				char_literal156=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_interfaceMethodDeclaration2457), "RBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal156_tree = (object)adaptor.Create(char_literal156, retval);
    				adaptor.AddChild(root_0, char_literal156_tree);
    				}

    				}
    				break;

    			default:
    				goto loop56;
    			}
    		}

    		loop56:
    			;

    		} finally { DebugExitSubRule(56); }

    		DebugLocation(586, 9);
    		// Java.g:586:9: ( 'throws' qualifiedNameList )?
    		int alt57=2;
    		try { DebugEnterSubRule(57);
    		try { DebugEnterDecision(57, decisionCanBacktrack[57]);
    		int LA57_0 = input.LA(1);

    		if ((LA57_0==THROWS))
    		{
    			alt57=1;
    		}
    		} finally { DebugExitDecision(57); }
    		switch (alt57)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:586:10: 'throws' qualifiedNameList
    			{
    			DebugLocation(586, 10);
    			string_literal157=(IToken)new XToken((IToken)Match(input,THROWS,Follow._THROWS_in_interfaceMethodDeclaration2479), "THROWS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal157_tree = (object)adaptor.Create(string_literal157, retval);
    			adaptor.AddChild(root_0, string_literal157_tree);
    			}
    			DebugLocation(586, 19);
    			PushFollow(Follow._qualifiedNameList_in_interfaceMethodDeclaration2481);
    			qualifiedNameList158=qualifiedNameList();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, qualifiedNameList158.Tree, qualifiedNameList158, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(57); }

    		DebugLocation(587, 12);
    		char_literal159=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_interfaceMethodDeclaration2494), "SEMI"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal159_tree = (object)adaptor.Create(char_literal159, retval);
    		adaptor.AddChild(root_0, char_literal159_tree);
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
            if (state.backtracking > 0) { Memoize(input, 30, interfaceMethodDeclaration_StartIndex); }
        }
     	DebugLocation(588, 4);
    	} finally { DebugExitRule(GrammarFileName, "interfaceMethodDeclaration"); }
    	return retval;

    }
    // $ANTLR end "interfaceMethodDeclaration"

    public class interfaceFieldDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_interfaceFieldDeclaration() {}
    protected virtual void Leave_interfaceFieldDeclaration() {}

    // $ANTLR start "interfaceFieldDeclaration"
    // Java.g:590:1: interfaceFieldDeclaration : modifiers type variableDeclarator ( ',' variableDeclarator )* ';' ;
    [GrammarRule("interfaceFieldDeclaration")]
    public JavaParser.interfaceFieldDeclaration_return interfaceFieldDeclaration()
    {

        JavaParser.interfaceFieldDeclaration_return retval = new JavaParser.interfaceFieldDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int interfaceFieldDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal163=null;
        IToken char_literal165=null;
        JavaParser.modifiers_return modifiers160 = default(JavaParser.modifiers_return);
        JavaParser.type_return type161 = default(JavaParser.type_return);
        JavaParser.variableDeclarator_return variableDeclarator162 = default(JavaParser.variableDeclarator_return);
        JavaParser.variableDeclarator_return variableDeclarator164 = default(JavaParser.variableDeclarator_return);

        object char_literal163_tree=null;
        object char_literal165_tree=null;

    	try { DebugEnterRule(GrammarFileName, "interfaceFieldDeclaration");
    	DebugLocation(590, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 31)) { return retval; }
    		// Java.g:596:5: ( modifiers type variableDeclarator ( ',' variableDeclarator )* ';' )
    		DebugEnterAlt(1);
    		// Java.g:596:9: modifiers type variableDeclarator ( ',' variableDeclarator )* ';'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(596, 9);
    		PushFollow(Follow._modifiers_in_interfaceFieldDeclaration2516);
    		modifiers160=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers160.Tree, modifiers160, retval);
    		DebugLocation(596, 19);
    		PushFollow(Follow._type_in_interfaceFieldDeclaration2518);
    		type161=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type161.Tree, type161, retval);
    		DebugLocation(596, 24);
    		PushFollow(Follow._variableDeclarator_in_interfaceFieldDeclaration2520);
    		variableDeclarator162=variableDeclarator();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableDeclarator162.Tree, variableDeclarator162, retval);
    		DebugLocation(597, 9);
    		// Java.g:597:9: ( ',' variableDeclarator )*
    		try { DebugEnterSubRule(58);
    		while (true)
    		{
    			int alt58=2;
    			try { DebugEnterDecision(58, decisionCanBacktrack[58]);
    			int LA58_0 = input.LA(1);

    			if ((LA58_0==COMMA))
    			{
    				alt58=1;
    			}


    			} finally { DebugExitDecision(58); }
    			switch ( alt58 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:597:10: ',' variableDeclarator
    				{
    				DebugLocation(597, 10);
    				char_literal163=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_interfaceFieldDeclaration2531), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal163_tree = (object)adaptor.Create(char_literal163, retval);
    				adaptor.AddChild(root_0, char_literal163_tree);
    				}
    				DebugLocation(597, 14);
    				PushFollow(Follow._variableDeclarator_in_interfaceFieldDeclaration2533);
    				variableDeclarator164=variableDeclarator();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableDeclarator164.Tree, variableDeclarator164, retval);

    				}
    				break;

    			default:
    				goto loop58;
    			}
    		}

    		loop58:
    			;

    		} finally { DebugExitSubRule(58); }

    		DebugLocation(599, 9);
    		char_literal165=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_interfaceFieldDeclaration2554), "SEMI"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal165_tree = (object)adaptor.Create(char_literal165, retval);
    		adaptor.AddChild(root_0, char_literal165_tree);
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
            if (state.backtracking > 0) { Memoize(input, 31, interfaceFieldDeclaration_StartIndex); }
        }
     	DebugLocation(600, 4);
    	} finally { DebugExitRule(GrammarFileName, "interfaceFieldDeclaration"); }
    	return retval;

    }
    // $ANTLR end "interfaceFieldDeclaration"

    public class type_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_type() {}
    protected virtual void Leave_type() {}

    // $ANTLR start "type"
    // Java.g:603:1: type : ( classOrInterfaceType ( '[' ']' )* | primitiveType ( '[' ']' )* );
    [GrammarRule("type")]
    public JavaParser.type_return type()
    {

        JavaParser.type_return retval = new JavaParser.type_return();
        retval.Start = (IToken)input.LT(1);
        int type_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal167=null;
        IToken char_literal168=null;
        IToken char_literal170=null;
        IToken char_literal171=null;
        JavaParser.classOrInterfaceType_return classOrInterfaceType166 = default(JavaParser.classOrInterfaceType_return);
        JavaParser.primitiveType_return primitiveType169 = default(JavaParser.primitiveType_return);

        object char_literal167_tree=null;
        object char_literal168_tree=null;
        object char_literal170_tree=null;
        object char_literal171_tree=null;

    	try { DebugEnterRule(GrammarFileName, "type");
    	DebugLocation(603, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 32)) { return retval; }
    		// Java.g:604:5: ( classOrInterfaceType ( '[' ']' )* | primitiveType ( '[' ']' )* )
    		int alt61=2;
    		try { DebugEnterDecision(61, decisionCanBacktrack[61]);
    		int LA61_0 = input.LA(1);

    		if ((LA61_0==IDENTIFIER))
    		{
    			alt61=1;
    		}
    		else if ((LA61_0==BOOLEAN||LA61_0==BYTE||LA61_0==CHAR||LA61_0==DOUBLE||LA61_0==FLOAT||LA61_0==INT||LA61_0==LONG||LA61_0==SHORT))
    		{
    			alt61=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 61, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(61); }
    		switch (alt61)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:604:9: classOrInterfaceType ( '[' ']' )*
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(604, 9);
    			PushFollow(Follow._classOrInterfaceType_in_type2575);
    			classOrInterfaceType166=classOrInterfaceType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classOrInterfaceType166.Tree, classOrInterfaceType166, retval);
    			DebugLocation(605, 9);
    			// Java.g:605:9: ( '[' ']' )*
    			try { DebugEnterSubRule(59);
    			while (true)
    			{
    				int alt59=2;
    				try { DebugEnterDecision(59, decisionCanBacktrack[59]);
    				int LA59_0 = input.LA(1);

    				if ((LA59_0==LBRACKET))
    				{
    					alt59=1;
    				}


    				} finally { DebugExitDecision(59); }
    				switch ( alt59 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:605:10: '[' ']'
    					{
    					DebugLocation(605, 10);
    					char_literal167=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_type2586), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal167_tree = (object)adaptor.Create(char_literal167, retval);
    					adaptor.AddChild(root_0, char_literal167_tree);
    					}
    					DebugLocation(605, 14);
    					char_literal168=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_type2588), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal168_tree = (object)adaptor.Create(char_literal168, retval);
    					adaptor.AddChild(root_0, char_literal168_tree);
    					}

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
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:607:9: primitiveType ( '[' ']' )*
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(607, 9);
    			PushFollow(Follow._primitiveType_in_type2609);
    			primitiveType169=primitiveType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, primitiveType169.Tree, primitiveType169, retval);
    			DebugLocation(608, 9);
    			// Java.g:608:9: ( '[' ']' )*
    			try { DebugEnterSubRule(60);
    			while (true)
    			{
    				int alt60=2;
    				try { DebugEnterDecision(60, decisionCanBacktrack[60]);
    				int LA60_0 = input.LA(1);

    				if ((LA60_0==LBRACKET))
    				{
    					alt60=1;
    				}


    				} finally { DebugExitDecision(60); }
    				switch ( alt60 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:608:10: '[' ']'
    					{
    					DebugLocation(608, 10);
    					char_literal170=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_type2620), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal170_tree = (object)adaptor.Create(char_literal170, retval);
    					adaptor.AddChild(root_0, char_literal170_tree);
    					}
    					DebugLocation(608, 14);
    					char_literal171=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_type2622), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal171_tree = (object)adaptor.Create(char_literal171, retval);
    					adaptor.AddChild(root_0, char_literal171_tree);
    					}

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
            if (state.backtracking > 0) { Memoize(input, 32, type_StartIndex); }
        }
     	DebugLocation(610, 4);
    	} finally { DebugExitRule(GrammarFileName, "type"); }
    	return retval;

    }
    // $ANTLR end "type"

    public class classOrInterfaceType_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_classOrInterfaceType() {}
    protected virtual void Leave_classOrInterfaceType() {}

    // $ANTLR start "classOrInterfaceType"
    // Java.g:613:1: classOrInterfaceType : IDENTIFIER ( typeArguments )? ( '.' IDENTIFIER ( typeArguments )? )* ;
    [GrammarRule("classOrInterfaceType")]
    public JavaParser.classOrInterfaceType_return classOrInterfaceType()
    {

        JavaParser.classOrInterfaceType_return retval = new JavaParser.classOrInterfaceType_return();
        retval.Start = (IToken)input.LT(1);
        int classOrInterfaceType_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER172=null;
        IToken char_literal174=null;
        IToken IDENTIFIER175=null;
        JavaParser.typeArguments_return typeArguments173 = default(JavaParser.typeArguments_return);
        JavaParser.typeArguments_return typeArguments176 = default(JavaParser.typeArguments_return);

        object IDENTIFIER172_tree=null;
        object char_literal174_tree=null;
        object IDENTIFIER175_tree=null;

    	try { DebugEnterRule(GrammarFileName, "classOrInterfaceType");
    	DebugLocation(613, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 33)) { return retval; }
    		// Java.g:614:5: ( IDENTIFIER ( typeArguments )? ( '.' IDENTIFIER ( typeArguments )? )* )
    		DebugEnterAlt(1);
    		// Java.g:614:9: IDENTIFIER ( typeArguments )? ( '.' IDENTIFIER ( typeArguments )? )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(614, 9);
    		IDENTIFIER172=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_classOrInterfaceType2654), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER172_tree = (object)adaptor.Create(IDENTIFIER172, retval);
    		adaptor.AddChild(root_0, IDENTIFIER172_tree);
    		}
    		DebugLocation(615, 9);
    		// Java.g:615:9: ( typeArguments )?
    		int alt62=2;
    		try { DebugEnterSubRule(62);
    		try { DebugEnterDecision(62, decisionCanBacktrack[62]);
    		int LA62_0 = input.LA(1);

    		if ((LA62_0==LT))
    		{
    			int LA62_1 = input.LA(2);

    			if ((LA62_1==IDENTIFIER||LA62_1==BOOLEAN||LA62_1==BYTE||LA62_1==CHAR||LA62_1==DOUBLE||LA62_1==FLOAT||LA62_1==INT||LA62_1==LONG||LA62_1==SHORT||LA62_1==QUES))
    			{
    				alt62=1;
    			}
    		}
    		} finally { DebugExitDecision(62); }
    		switch (alt62)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:615:10: typeArguments
    			{
    			DebugLocation(615, 10);
    			PushFollow(Follow._typeArguments_in_classOrInterfaceType2665);
    			typeArguments173=typeArguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeArguments173.Tree, typeArguments173, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(62); }

    		DebugLocation(617, 9);
    		// Java.g:617:9: ( '.' IDENTIFIER ( typeArguments )? )*
    		try { DebugEnterSubRule(64);
    		while (true)
    		{
    			int alt64=2;
    			try { DebugEnterDecision(64, decisionCanBacktrack[64]);
    			int LA64_0 = input.LA(1);

    			if ((LA64_0==DOT))
    			{
    				alt64=1;
    			}


    			} finally { DebugExitDecision(64); }
    			switch ( alt64 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:617:10: '.' IDENTIFIER ( typeArguments )?
    				{
    				DebugLocation(617, 10);
    				char_literal174=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_classOrInterfaceType2687), "DOT"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal174_tree = (object)adaptor.Create(char_literal174, retval);
    				adaptor.AddChild(root_0, char_literal174_tree);
    				}
    				DebugLocation(617, 14);
    				IDENTIFIER175=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_classOrInterfaceType2689), "IDENTIFIER"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				IDENTIFIER175_tree = (object)adaptor.Create(IDENTIFIER175, retval);
    				adaptor.AddChild(root_0, IDENTIFIER175_tree);
    				}
    				DebugLocation(618, 13);
    				// Java.g:618:13: ( typeArguments )?
    				int alt63=2;
    				try { DebugEnterSubRule(63);
    				try { DebugEnterDecision(63, decisionCanBacktrack[63]);
    				int LA63_0 = input.LA(1);

    				if ((LA63_0==LT))
    				{
    					int LA63_1 = input.LA(2);

    					if ((LA63_1==IDENTIFIER||LA63_1==BOOLEAN||LA63_1==BYTE||LA63_1==CHAR||LA63_1==DOUBLE||LA63_1==FLOAT||LA63_1==INT||LA63_1==LONG||LA63_1==SHORT||LA63_1==QUES))
    					{
    						alt63=1;
    					}
    				}
    				} finally { DebugExitDecision(63); }
    				switch (alt63)
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:618:14: typeArguments
    					{
    					DebugLocation(618, 14);
    					PushFollow(Follow._typeArguments_in_classOrInterfaceType2704);
    					typeArguments176=typeArguments();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeArguments176.Tree, typeArguments176, retval);

    					}
    					break;

    				}
    				} finally { DebugExitSubRule(63); }


    				}
    				break;

    			default:
    				goto loop64;
    			}
    		}

    		loop64:
    			;

    		} finally { DebugExitSubRule(64); }


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
            if (state.backtracking > 0) { Memoize(input, 33, classOrInterfaceType_StartIndex); }
        }
     	DebugLocation(621, 4);
    	} finally { DebugExitRule(GrammarFileName, "classOrInterfaceType"); }
    	return retval;

    }
    // $ANTLR end "classOrInterfaceType"

    public class primitiveType_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_primitiveType() {}
    protected virtual void Leave_primitiveType() {}

    // $ANTLR start "primitiveType"
    // Java.g:623:1: primitiveType : ( 'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' );
    [GrammarRule("primitiveType")]
    public JavaParser.primitiveType_return primitiveType()
    {

        JavaParser.primitiveType_return retval = new JavaParser.primitiveType_return();
        retval.Start = (IToken)input.LT(1);
        int primitiveType_StartIndex = input.Index;
        object root_0 = null;

        IToken set177=null;

        object set177_tree=null;

    	try { DebugEnterRule(GrammarFileName, "primitiveType");
    	DebugLocation(623, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 34)) { return retval; }
    		// Java.g:624:5: ( 'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' )
    		DebugEnterAlt(1);
    		// Java.g:
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(624, 5);
    		set177=(IToken)input.LT(1);
    		if (input.LA(1)==BOOLEAN||input.LA(1)==BYTE||input.LA(1)==CHAR||input.LA(1)==DOUBLE||input.LA(1)==FLOAT||input.LA(1)==INT||input.LA(1)==LONG||input.LA(1)==SHORT)
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set177, retval));
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
            if (state.backtracking > 0) { Memoize(input, 34, primitiveType_StartIndex); }
        }
     	DebugLocation(632, 4);
    	} finally { DebugExitRule(GrammarFileName, "primitiveType"); }
    	return retval;

    }
    // $ANTLR end "primitiveType"

    public class typeArguments_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeArguments() {}
    protected virtual void Leave_typeArguments() {}

    // $ANTLR start "typeArguments"
    // Java.g:634:1: typeArguments : '<' typeArgument ( ',' typeArgument )* '>' ;
    [GrammarRule("typeArguments")]
    public JavaParser.typeArguments_return typeArguments()
    {

        JavaParser.typeArguments_return retval = new JavaParser.typeArguments_return();
        retval.Start = (IToken)input.LT(1);
        int typeArguments_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal178=null;
        IToken char_literal180=null;
        IToken char_literal182=null;
        JavaParser.typeArgument_return typeArgument179 = default(JavaParser.typeArgument_return);
        JavaParser.typeArgument_return typeArgument181 = default(JavaParser.typeArgument_return);

        object char_literal178_tree=null;
        object char_literal180_tree=null;
        object char_literal182_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeArguments");
    	DebugLocation(634, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 35)) { return retval; }
    		// Java.g:635:5: ( '<' typeArgument ( ',' typeArgument )* '>' )
    		DebugEnterAlt(1);
    		// Java.g:635:9: '<' typeArgument ( ',' typeArgument )* '>'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(635, 9);
    		char_literal178=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_typeArguments2841), "LT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal178_tree = (object)adaptor.Create(char_literal178, retval);
    		adaptor.AddChild(root_0, char_literal178_tree);
    		}
    		DebugLocation(635, 13);
    		PushFollow(Follow._typeArgument_in_typeArguments2843);
    		typeArgument179=typeArgument();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeArgument179.Tree, typeArgument179, retval);
    		DebugLocation(636, 9);
    		// Java.g:636:9: ( ',' typeArgument )*
    		try { DebugEnterSubRule(65);
    		while (true)
    		{
    			int alt65=2;
    			try { DebugEnterDecision(65, decisionCanBacktrack[65]);
    			int LA65_0 = input.LA(1);

    			if ((LA65_0==COMMA))
    			{
    				alt65=1;
    			}


    			} finally { DebugExitDecision(65); }
    			switch ( alt65 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:636:10: ',' typeArgument
    				{
    				DebugLocation(636, 10);
    				char_literal180=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_typeArguments2854), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal180_tree = (object)adaptor.Create(char_literal180, retval);
    				adaptor.AddChild(root_0, char_literal180_tree);
    				}
    				DebugLocation(636, 14);
    				PushFollow(Follow._typeArgument_in_typeArguments2856);
    				typeArgument181=typeArgument();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeArgument181.Tree, typeArgument181, retval);

    				}
    				break;

    			default:
    				goto loop65;
    			}
    		}

    		loop65:
    			;

    		} finally { DebugExitSubRule(65); }

    		DebugLocation(638, 9);
    		char_literal182=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_typeArguments2878), "GT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal182_tree = (object)adaptor.Create(char_literal182, retval);
    		adaptor.AddChild(root_0, char_literal182_tree);
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
            if (state.backtracking > 0) { Memoize(input, 35, typeArguments_StartIndex); }
        }
     	DebugLocation(639, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeArguments"); }
    	return retval;

    }
    // $ANTLR end "typeArguments"

    public class typeArgument_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeArgument() {}
    protected virtual void Leave_typeArgument() {}

    // $ANTLR start "typeArgument"
    // Java.g:641:1: typeArgument : ( type | '?' ( ( 'extends' | 'super' ) type )? );
    [GrammarRule("typeArgument")]
    public JavaParser.typeArgument_return typeArgument()
    {

        JavaParser.typeArgument_return retval = new JavaParser.typeArgument_return();
        retval.Start = (IToken)input.LT(1);
        int typeArgument_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal184=null;
        IToken set185=null;
        JavaParser.type_return type183 = default(JavaParser.type_return);
        JavaParser.type_return type186 = default(JavaParser.type_return);

        object char_literal184_tree=null;
        object set185_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeArgument");
    	DebugLocation(641, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 36)) { return retval; }
    		// Java.g:642:5: ( type | '?' ( ( 'extends' | 'super' ) type )? )
    		int alt67=2;
    		try { DebugEnterDecision(67, decisionCanBacktrack[67]);
    		int LA67_0 = input.LA(1);

    		if ((LA67_0==IDENTIFIER||LA67_0==BOOLEAN||LA67_0==BYTE||LA67_0==CHAR||LA67_0==DOUBLE||LA67_0==FLOAT||LA67_0==INT||LA67_0==LONG||LA67_0==SHORT))
    		{
    			alt67=1;
    		}
    		else if ((LA67_0==QUES))
    		{
    			alt67=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 67, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(67); }
    		switch (alt67)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:642:9: type
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(642, 9);
    			PushFollow(Follow._type_in_typeArgument2898);
    			type183=type();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type183.Tree, type183, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:643:9: '?' ( ( 'extends' | 'super' ) type )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(643, 9);
    			char_literal184=(IToken)new XToken((IToken)Match(input,QUES,Follow._QUES_in_typeArgument2908), "QUES"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal184_tree = (object)adaptor.Create(char_literal184, retval);
    			adaptor.AddChild(root_0, char_literal184_tree);
    			}
    			DebugLocation(644, 9);
    			// Java.g:644:9: ( ( 'extends' | 'super' ) type )?
    			int alt66=2;
    			try { DebugEnterSubRule(66);
    			try { DebugEnterDecision(66, decisionCanBacktrack[66]);
    			int LA66_0 = input.LA(1);

    			if ((LA66_0==EXTENDS||LA66_0==SUPER))
    			{
    				alt66=1;
    			}
    			} finally { DebugExitDecision(66); }
    			switch (alt66)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:645:13: ( 'extends' | 'super' ) type
    				{
    				DebugLocation(645, 13);
    				set185=(IToken)input.LT(1);
    				if (input.LA(1)==EXTENDS||input.LA(1)==SUPER)
    				{
    					input.Consume();
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set185, retval));
    					state.errorRecovery=false;state.failed=false;
    				}
    				else
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					throw mse;
    				}

    				DebugLocation(648, 13);
    				PushFollow(Follow._type_in_typeArgument2976);
    				type186=type();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type186.Tree, type186, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(66); }


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
            if (state.backtracking > 0) { Memoize(input, 36, typeArgument_StartIndex); }
        }
     	DebugLocation(650, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeArgument"); }
    	return retval;

    }
    // $ANTLR end "typeArgument"

    public class qualifiedNameList_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_qualifiedNameList() {}
    protected virtual void Leave_qualifiedNameList() {}

    // $ANTLR start "qualifiedNameList"
    // Java.g:652:1: qualifiedNameList : qualifiedName ( ',' qualifiedName )* ;
    [GrammarRule("qualifiedNameList")]
    public JavaParser.qualifiedNameList_return qualifiedNameList()
    {

        JavaParser.qualifiedNameList_return retval = new JavaParser.qualifiedNameList_return();
        retval.Start = (IToken)input.LT(1);
        int qualifiedNameList_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal188=null;
        JavaParser.qualifiedName_return qualifiedName187 = default(JavaParser.qualifiedName_return);
        JavaParser.qualifiedName_return qualifiedName189 = default(JavaParser.qualifiedName_return);

        object char_literal188_tree=null;

    	try { DebugEnterRule(GrammarFileName, "qualifiedNameList");
    	DebugLocation(652, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 37)) { return retval; }
    		// Java.g:653:5: ( qualifiedName ( ',' qualifiedName )* )
    		DebugEnterAlt(1);
    		// Java.g:653:9: qualifiedName ( ',' qualifiedName )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(653, 9);
    		PushFollow(Follow._qualifiedName_in_qualifiedNameList3007);
    		qualifiedName187=qualifiedName();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, qualifiedName187.Tree, qualifiedName187, retval);
    		DebugLocation(654, 9);
    		// Java.g:654:9: ( ',' qualifiedName )*
    		try { DebugEnterSubRule(68);
    		while (true)
    		{
    			int alt68=2;
    			try { DebugEnterDecision(68, decisionCanBacktrack[68]);
    			int LA68_0 = input.LA(1);

    			if ((LA68_0==COMMA))
    			{
    				alt68=1;
    			}


    			} finally { DebugExitDecision(68); }
    			switch ( alt68 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:654:10: ',' qualifiedName
    				{
    				DebugLocation(654, 10);
    				char_literal188=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_qualifiedNameList3018), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal188_tree = (object)adaptor.Create(char_literal188, retval);
    				adaptor.AddChild(root_0, char_literal188_tree);
    				}
    				DebugLocation(654, 14);
    				PushFollow(Follow._qualifiedName_in_qualifiedNameList3020);
    				qualifiedName189=qualifiedName();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, qualifiedName189.Tree, qualifiedName189, retval);

    				}
    				break;

    			default:
    				goto loop68;
    			}
    		}

    		loop68:
    			;

    		} finally { DebugExitSubRule(68); }


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
            if (state.backtracking > 0) { Memoize(input, 37, qualifiedNameList_StartIndex); }
        }
     	DebugLocation(656, 4);
    	} finally { DebugExitRule(GrammarFileName, "qualifiedNameList"); }
    	return retval;

    }
    // $ANTLR end "qualifiedNameList"

    public class formalParameters_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_formalParameters() {}
    protected virtual void Leave_formalParameters() {}

    // $ANTLR start "formalParameters"
    // Java.g:658:1: formalParameters : '(' ( formalParameterDecls )? ')' ;
    [GrammarRule("formalParameters")]
    public JavaParser.formalParameters_return formalParameters()
    {

        JavaParser.formalParameters_return retval = new JavaParser.formalParameters_return();
        retval.Start = (IToken)input.LT(1);
        int formalParameters_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal190=null;
        IToken char_literal192=null;
        JavaParser.formalParameterDecls_return formalParameterDecls191 = default(JavaParser.formalParameterDecls_return);

        object char_literal190_tree=null;
        object char_literal192_tree=null;

    	try { DebugEnterRule(GrammarFileName, "formalParameters");
    	DebugLocation(658, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 38)) { return retval; }
    		// Java.g:659:5: ( '(' ( formalParameterDecls )? ')' )
    		DebugEnterAlt(1);
    		// Java.g:659:9: '(' ( formalParameterDecls )? ')'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(659, 9);
    		char_literal190=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_formalParameters3051), "LPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal190_tree = (object)adaptor.Create(char_literal190, retval);
    		adaptor.AddChild(root_0, char_literal190_tree);
    		}
    		DebugLocation(660, 9);
    		// Java.g:660:9: ( formalParameterDecls )?
    		int alt69=2;
    		try { DebugEnterSubRule(69);
    		try { DebugEnterDecision(69, decisionCanBacktrack[69]);
    		int LA69_0 = input.LA(1);

    		if ((LA69_0==IDENTIFIER||LA69_0==BOOLEAN||LA69_0==BYTE||LA69_0==CHAR||LA69_0==DOUBLE||LA69_0==FINAL||LA69_0==FLOAT||LA69_0==INT||LA69_0==LONG||LA69_0==SHORT||LA69_0==MONKEYS_AT))
    		{
    			alt69=1;
    		}
    		} finally { DebugExitDecision(69); }
    		switch (alt69)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:660:10: formalParameterDecls
    			{
    			DebugLocation(660, 10);
    			PushFollow(Follow._formalParameterDecls_in_formalParameters3062);
    			formalParameterDecls191=formalParameterDecls();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, formalParameterDecls191.Tree, formalParameterDecls191, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(69); }

    		DebugLocation(662, 9);
    		char_literal192=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_formalParameters3084), "RPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal192_tree = (object)adaptor.Create(char_literal192, retval);
    		adaptor.AddChild(root_0, char_literal192_tree);
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
            if (state.backtracking > 0) { Memoize(input, 38, formalParameters_StartIndex); }
        }
     	DebugLocation(663, 4);
    	} finally { DebugExitRule(GrammarFileName, "formalParameters"); }
    	return retval;

    }
    // $ANTLR end "formalParameters"

    public class formalParameterDecls_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_formalParameterDecls() {}
    protected virtual void Leave_formalParameterDecls() {}

    // $ANTLR start "formalParameterDecls"
    // Java.g:665:1: formalParameterDecls : ( ellipsisParameterDecl | normalParameterDecl ( ',' normalParameterDecl )* | ( normalParameterDecl ',' )+ ellipsisParameterDecl );
    [GrammarRule("formalParameterDecls")]
    public JavaParser.formalParameterDecls_return formalParameterDecls()
    {

        JavaParser.formalParameterDecls_return retval = new JavaParser.formalParameterDecls_return();
        retval.Start = (IToken)input.LT(1);
        int formalParameterDecls_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal195=null;
        IToken char_literal198=null;
        JavaParser.ellipsisParameterDecl_return ellipsisParameterDecl193 = default(JavaParser.ellipsisParameterDecl_return);
        JavaParser.normalParameterDecl_return normalParameterDecl194 = default(JavaParser.normalParameterDecl_return);
        JavaParser.normalParameterDecl_return normalParameterDecl196 = default(JavaParser.normalParameterDecl_return);
        JavaParser.normalParameterDecl_return normalParameterDecl197 = default(JavaParser.normalParameterDecl_return);
        JavaParser.ellipsisParameterDecl_return ellipsisParameterDecl199 = default(JavaParser.ellipsisParameterDecl_return);

        object char_literal195_tree=null;
        object char_literal198_tree=null;

    	try { DebugEnterRule(GrammarFileName, "formalParameterDecls");
    	DebugLocation(665, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 39)) { return retval; }
    		// Java.g:666:5: ( ellipsisParameterDecl | normalParameterDecl ( ',' normalParameterDecl )* | ( normalParameterDecl ',' )+ ellipsisParameterDecl )
    		int alt72=3;
    		try { DebugEnterDecision(72, decisionCanBacktrack[72]);
    		switch (input.LA(1))
    		{
    		case FINAL:
    			{
    			int LA72_1 = input.LA(2);

    			if ((EvaluatePredicate(synpred96_Java_fragment)))
    			{
    				alt72=1;
    			}
    			else if ((EvaluatePredicate(synpred98_Java_fragment)))
    			{
    				alt72=2;
    			}
    			else if ((true))
    			{
    				alt72=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 72, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case MONKEYS_AT:
    			{
    			int LA72_2 = input.LA(2);

    			if ((EvaluatePredicate(synpred96_Java_fragment)))
    			{
    				alt72=1;
    			}
    			else if ((EvaluatePredicate(synpred98_Java_fragment)))
    			{
    				alt72=2;
    			}
    			else if ((true))
    			{
    				alt72=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 72, 2, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case IDENTIFIER:
    			{
    			int LA72_3 = input.LA(2);

    			if ((EvaluatePredicate(synpred96_Java_fragment)))
    			{
    				alt72=1;
    			}
    			else if ((EvaluatePredicate(synpred98_Java_fragment)))
    			{
    				alt72=2;
    			}
    			else if ((true))
    			{
    				alt72=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 72, 3, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case BOOLEAN:
    		case BYTE:
    		case CHAR:
    		case DOUBLE:
    		case FLOAT:
    		case INT:
    		case LONG:
    		case SHORT:
    			{
    			int LA72_4 = input.LA(2);

    			if ((EvaluatePredicate(synpred96_Java_fragment)))
    			{
    				alt72=1;
    			}
    			else if ((EvaluatePredicate(synpred98_Java_fragment)))
    			{
    				alt72=2;
    			}
    			else if ((true))
    			{
    				alt72=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 72, 4, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
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
    			// Java.g:666:9: ellipsisParameterDecl
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(666, 9);
    			PushFollow(Follow._ellipsisParameterDecl_in_formalParameterDecls3104);
    			ellipsisParameterDecl193=ellipsisParameterDecl();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, ellipsisParameterDecl193.Tree, ellipsisParameterDecl193, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:667:9: normalParameterDecl ( ',' normalParameterDecl )*
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(667, 9);
    			PushFollow(Follow._normalParameterDecl_in_formalParameterDecls3114);
    			normalParameterDecl194=normalParameterDecl();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, normalParameterDecl194.Tree, normalParameterDecl194, retval);
    			DebugLocation(668, 9);
    			// Java.g:668:9: ( ',' normalParameterDecl )*
    			try { DebugEnterSubRule(70);
    			while (true)
    			{
    				int alt70=2;
    				try { DebugEnterDecision(70, decisionCanBacktrack[70]);
    				int LA70_0 = input.LA(1);

    				if ((LA70_0==COMMA))
    				{
    					alt70=1;
    				}


    				} finally { DebugExitDecision(70); }
    				switch ( alt70 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:668:10: ',' normalParameterDecl
    					{
    					DebugLocation(668, 10);
    					char_literal195=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_formalParameterDecls3125), "COMMA"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal195_tree = (object)adaptor.Create(char_literal195, retval);
    					adaptor.AddChild(root_0, char_literal195_tree);
    					}
    					DebugLocation(668, 14);
    					PushFollow(Follow._normalParameterDecl_in_formalParameterDecls3127);
    					normalParameterDecl196=normalParameterDecl();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, normalParameterDecl196.Tree, normalParameterDecl196, retval);

    					}
    					break;

    				default:
    					goto loop70;
    				}
    			}

    			loop70:
    				;

    			} finally { DebugExitSubRule(70); }


    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:670:9: ( normalParameterDecl ',' )+ ellipsisParameterDecl
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(670, 9);
    			// Java.g:670:9: ( normalParameterDecl ',' )+
    			int cnt71=0;
    			try { DebugEnterSubRule(71);
    			while (true)
    			{
    				int alt71=2;
    				try { DebugEnterDecision(71, decisionCanBacktrack[71]);
    				switch (input.LA(1))
    				{
    				case FINAL:
    					{
    					int LA71_1 = input.LA(2);

    					if ((EvaluatePredicate(synpred99_Java_fragment)))
    					{
    						alt71=1;
    					}


    					}
    					break;
    				case MONKEYS_AT:
    					{
    					int LA71_2 = input.LA(2);

    					if ((EvaluatePredicate(synpred99_Java_fragment)))
    					{
    						alt71=1;
    					}


    					}
    					break;
    				case IDENTIFIER:
    					{
    					int LA71_3 = input.LA(2);

    					if ((EvaluatePredicate(synpred99_Java_fragment)))
    					{
    						alt71=1;
    					}


    					}
    					break;
    				case BOOLEAN:
    				case BYTE:
    				case CHAR:
    				case DOUBLE:
    				case FLOAT:
    				case INT:
    				case LONG:
    				case SHORT:
    					{
    					int LA71_4 = input.LA(2);

    					if ((EvaluatePredicate(synpred99_Java_fragment)))
    					{
    						alt71=1;
    					}


    					}
    					break;

    				}

    				} finally { DebugExitDecision(71); }
    				switch (alt71)
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:670:10: normalParameterDecl ','
    					{
    					DebugLocation(670, 10);
    					PushFollow(Follow._normalParameterDecl_in_formalParameterDecls3149);
    					normalParameterDecl197=normalParameterDecl();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, normalParameterDecl197.Tree, normalParameterDecl197, retval);
    					DebugLocation(671, 9);
    					char_literal198=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_formalParameterDecls3159), "COMMA"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal198_tree = (object)adaptor.Create(char_literal198, retval);
    					adaptor.AddChild(root_0, char_literal198_tree);
    					}

    					}
    					break;

    				default:
    					if (cnt71 >= 1)
    						goto loop71;

    					if (state.backtracking>0) {state.failed=true; return retval;}
    					EarlyExitException eee71 = new EarlyExitException( 71, input );
    					DebugRecognitionException(eee71);
    					throw eee71;
    				}
    				cnt71++;
    			}
    			loop71:
    				;

    			} finally { DebugExitSubRule(71); }

    			DebugLocation(673, 9);
    			PushFollow(Follow._ellipsisParameterDecl_in_formalParameterDecls3181);
    			ellipsisParameterDecl199=ellipsisParameterDecl();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, ellipsisParameterDecl199.Tree, ellipsisParameterDecl199, retval);

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
            if (state.backtracking > 0) { Memoize(input, 39, formalParameterDecls_StartIndex); }
        }
     	DebugLocation(674, 4);
    	} finally { DebugExitRule(GrammarFileName, "formalParameterDecls"); }
    	return retval;

    }
    // $ANTLR end "formalParameterDecls"

    public class normalParameterDecl_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_normalParameterDecl() {}
    protected virtual void Leave_normalParameterDecl() {}

    // $ANTLR start "normalParameterDecl"
    // Java.g:676:1: normalParameterDecl : variableModifiers type IDENTIFIER ( '[' ']' )* ;
    [GrammarRule("normalParameterDecl")]
    public JavaParser.normalParameterDecl_return normalParameterDecl()
    {

        JavaParser.normalParameterDecl_return retval = new JavaParser.normalParameterDecl_return();
        retval.Start = (IToken)input.LT(1);
        int normalParameterDecl_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER202=null;
        IToken char_literal203=null;
        IToken char_literal204=null;
        JavaParser.variableModifiers_return variableModifiers200 = default(JavaParser.variableModifiers_return);
        JavaParser.type_return type201 = default(JavaParser.type_return);

        object IDENTIFIER202_tree=null;
        object char_literal203_tree=null;
        object char_literal204_tree=null;

    	try { DebugEnterRule(GrammarFileName, "normalParameterDecl");
    	DebugLocation(676, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 40)) { return retval; }
    		// Java.g:677:5: ( variableModifiers type IDENTIFIER ( '[' ']' )* )
    		DebugEnterAlt(1);
    		// Java.g:677:9: variableModifiers type IDENTIFIER ( '[' ']' )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(677, 9);
    		PushFollow(Follow._variableModifiers_in_normalParameterDecl3201);
    		variableModifiers200=variableModifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableModifiers200.Tree, variableModifiers200, retval);
    		DebugLocation(677, 27);
    		PushFollow(Follow._type_in_normalParameterDecl3203);
    		type201=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type201.Tree, type201, retval);
    		DebugLocation(677, 32);
    		IDENTIFIER202=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_normalParameterDecl3205), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER202_tree = (object)adaptor.Create(IDENTIFIER202, retval);
    		adaptor.AddChild(root_0, IDENTIFIER202_tree);
    		}
    		DebugLocation(678, 9);
    		// Java.g:678:9: ( '[' ']' )*
    		try { DebugEnterSubRule(73);
    		while (true)
    		{
    			int alt73=2;
    			try { DebugEnterDecision(73, decisionCanBacktrack[73]);
    			int LA73_0 = input.LA(1);

    			if ((LA73_0==LBRACKET))
    			{
    				alt73=1;
    			}


    			} finally { DebugExitDecision(73); }
    			switch ( alt73 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:678:10: '[' ']'
    				{
    				DebugLocation(678, 10);
    				char_literal203=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_normalParameterDecl3216), "LBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal203_tree = (object)adaptor.Create(char_literal203, retval);
    				adaptor.AddChild(root_0, char_literal203_tree);
    				}
    				DebugLocation(678, 14);
    				char_literal204=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_normalParameterDecl3218), "RBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal204_tree = (object)adaptor.Create(char_literal204, retval);
    				adaptor.AddChild(root_0, char_literal204_tree);
    				}

    				}
    				break;

    			default:
    				goto loop73;
    			}
    		}

    		loop73:
    			;

    		} finally { DebugExitSubRule(73); }


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
            if (state.backtracking > 0) { Memoize(input, 40, normalParameterDecl_StartIndex); }
        }
     	DebugLocation(680, 4);
    	} finally { DebugExitRule(GrammarFileName, "normalParameterDecl"); }
    	return retval;

    }
    // $ANTLR end "normalParameterDecl"

    public class ellipsisParameterDecl_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_ellipsisParameterDecl() {}
    protected virtual void Leave_ellipsisParameterDecl() {}

    // $ANTLR start "ellipsisParameterDecl"
    // Java.g:682:1: ellipsisParameterDecl : variableModifiers type '...' IDENTIFIER ;
    [GrammarRule("ellipsisParameterDecl")]
    public JavaParser.ellipsisParameterDecl_return ellipsisParameterDecl()
    {

        JavaParser.ellipsisParameterDecl_return retval = new JavaParser.ellipsisParameterDecl_return();
        retval.Start = (IToken)input.LT(1);
        int ellipsisParameterDecl_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal207=null;
        IToken IDENTIFIER208=null;
        JavaParser.variableModifiers_return variableModifiers205 = default(JavaParser.variableModifiers_return);
        JavaParser.type_return type206 = default(JavaParser.type_return);

        object string_literal207_tree=null;
        object IDENTIFIER208_tree=null;

    	try { DebugEnterRule(GrammarFileName, "ellipsisParameterDecl");
    	DebugLocation(682, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 41)) { return retval; }
    		// Java.g:683:5: ( variableModifiers type '...' IDENTIFIER )
    		DebugEnterAlt(1);
    		// Java.g:683:9: variableModifiers type '...' IDENTIFIER
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(683, 9);
    		PushFollow(Follow._variableModifiers_in_ellipsisParameterDecl3249);
    		variableModifiers205=variableModifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableModifiers205.Tree, variableModifiers205, retval);
    		DebugLocation(684, 9);
    		PushFollow(Follow._type_in_ellipsisParameterDecl3259);
    		type206=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type206.Tree, type206, retval);
    		DebugLocation(684, 15);
    		string_literal207=(IToken)new XToken((IToken)Match(input,ELLIPSIS,Follow._ELLIPSIS_in_ellipsisParameterDecl3262), "ELLIPSIS"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal207_tree = (object)adaptor.Create(string_literal207, retval);
    		adaptor.AddChild(root_0, string_literal207_tree);
    		}
    		DebugLocation(685, 9);
    		IDENTIFIER208=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_ellipsisParameterDecl3272), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER208_tree = (object)adaptor.Create(IDENTIFIER208, retval);
    		adaptor.AddChild(root_0, IDENTIFIER208_tree);
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
            if (state.backtracking > 0) { Memoize(input, 41, ellipsisParameterDecl_StartIndex); }
        }
     	DebugLocation(686, 4);
    	} finally { DebugExitRule(GrammarFileName, "ellipsisParameterDecl"); }
    	return retval;

    }
    // $ANTLR end "ellipsisParameterDecl"

    public class explicitConstructorInvocation_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_explicitConstructorInvocation() {}
    protected virtual void Leave_explicitConstructorInvocation() {}

    // $ANTLR start "explicitConstructorInvocation"
    // Java.g:689:1: explicitConstructorInvocation : ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' | primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';' );
    [GrammarRule("explicitConstructorInvocation")]
    public JavaParser.explicitConstructorInvocation_return explicitConstructorInvocation()
    {

        JavaParser.explicitConstructorInvocation_return retval = new JavaParser.explicitConstructorInvocation_return();
        retval.Start = (IToken)input.LT(1);
        int explicitConstructorInvocation_StartIndex = input.Index;
        object root_0 = null;

        IToken set210=null;
        IToken char_literal212=null;
        IToken char_literal214=null;
        IToken string_literal216=null;
        IToken char_literal218=null;
        JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments209 = default(JavaParser.nonWildcardTypeArguments_return);
        JavaParser.arguments_return arguments211 = default(JavaParser.arguments_return);
        JavaParser.primary_return primary213 = default(JavaParser.primary_return);
        JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments215 = default(JavaParser.nonWildcardTypeArguments_return);
        JavaParser.arguments_return arguments217 = default(JavaParser.arguments_return);

        object set210_tree=null;
        object char_literal212_tree=null;
        object char_literal214_tree=null;
        object string_literal216_tree=null;
        object char_literal218_tree=null;

    	try { DebugEnterRule(GrammarFileName, "explicitConstructorInvocation");
    	DebugLocation(689, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 42)) { return retval; }
    		// Java.g:690:5: ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' | primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';' )
    		int alt76=2;
    		try { DebugEnterDecision(76, decisionCanBacktrack[76]);
    		try
    		{
    			alt76 = dfa76.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(76); }
    		switch (alt76)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:690:9: ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(690, 9);
    			// Java.g:690:9: ( nonWildcardTypeArguments )?
    			int alt74=2;
    			try { DebugEnterSubRule(74);
    			try { DebugEnterDecision(74, decisionCanBacktrack[74]);
    			int LA74_0 = input.LA(1);

    			if ((LA74_0==LT))
    			{
    				alt74=1;
    			}
    			} finally { DebugExitDecision(74); }
    			switch (alt74)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:690:10: nonWildcardTypeArguments
    				{
    				DebugLocation(690, 10);
    				PushFollow(Follow._nonWildcardTypeArguments_in_explicitConstructorInvocation3294);
    				nonWildcardTypeArguments209=nonWildcardTypeArguments();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nonWildcardTypeArguments209.Tree, nonWildcardTypeArguments209, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(74); }

    			DebugLocation(692, 9);
    			set210=(IToken)input.LT(1);
    			if (input.LA(1)==SUPER||input.LA(1)==THIS)
    			{
    				input.Consume();
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set210, retval));
    				state.errorRecovery=false;state.failed=false;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				MismatchedSetException mse = new MismatchedSetException(null,input);
    				DebugRecognitionException(mse);
    				throw mse;
    			}

    			DebugLocation(695, 9);
    			PushFollow(Follow._arguments_in_explicitConstructorInvocation3352);
    			arguments211=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments211.Tree, arguments211, retval);
    			DebugLocation(695, 19);
    			char_literal212=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_explicitConstructorInvocation3354), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal212_tree = (object)adaptor.Create(char_literal212, retval);
    			adaptor.AddChild(root_0, char_literal212_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:697:9: primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(697, 9);
    			PushFollow(Follow._primary_in_explicitConstructorInvocation3365);
    			primary213=primary();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, primary213.Tree, primary213, retval);
    			DebugLocation(698, 9);
    			char_literal214=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_explicitConstructorInvocation3375), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal214_tree = (object)adaptor.Create(char_literal214, retval);
    			adaptor.AddChild(root_0, char_literal214_tree);
    			}
    			DebugLocation(699, 9);
    			// Java.g:699:9: ( nonWildcardTypeArguments )?
    			int alt75=2;
    			try { DebugEnterSubRule(75);
    			try { DebugEnterDecision(75, decisionCanBacktrack[75]);
    			int LA75_0 = input.LA(1);

    			if ((LA75_0==LT))
    			{
    				alt75=1;
    			}
    			} finally { DebugExitDecision(75); }
    			switch (alt75)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:699:10: nonWildcardTypeArguments
    				{
    				DebugLocation(699, 10);
    				PushFollow(Follow._nonWildcardTypeArguments_in_explicitConstructorInvocation3386);
    				nonWildcardTypeArguments215=nonWildcardTypeArguments();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nonWildcardTypeArguments215.Tree, nonWildcardTypeArguments215, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(75); }

    			DebugLocation(701, 9);
    			string_literal216=(IToken)new XToken((IToken)Match(input,SUPER,Follow._SUPER_in_explicitConstructorInvocation3407), "SUPER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal216_tree = (object)adaptor.Create(string_literal216, retval);
    			adaptor.AddChild(root_0, string_literal216_tree);
    			}
    			DebugLocation(702, 9);
    			PushFollow(Follow._arguments_in_explicitConstructorInvocation3417);
    			arguments217=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments217.Tree, arguments217, retval);
    			DebugLocation(702, 19);
    			char_literal218=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_explicitConstructorInvocation3419), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal218_tree = (object)adaptor.Create(char_literal218, retval);
    			adaptor.AddChild(root_0, char_literal218_tree);
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
            if (state.backtracking > 0) { Memoize(input, 42, explicitConstructorInvocation_StartIndex); }
        }
     	DebugLocation(703, 4);
    	} finally { DebugExitRule(GrammarFileName, "explicitConstructorInvocation"); }
    	return retval;

    }
    // $ANTLR end "explicitConstructorInvocation"

    public class qualifiedName_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_qualifiedName() {}
    protected virtual void Leave_qualifiedName() {}

    // $ANTLR start "qualifiedName"
    // Java.g:705:1: qualifiedName : IDENTIFIER ( '.' IDENTIFIER )* ;
    [GrammarRule("qualifiedName")]
    public JavaParser.qualifiedName_return qualifiedName()
    {

        JavaParser.qualifiedName_return retval = new JavaParser.qualifiedName_return();
        retval.Start = (IToken)input.LT(1);
        int qualifiedName_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER219=null;
        IToken char_literal220=null;
        IToken IDENTIFIER221=null;

        object IDENTIFIER219_tree=null;
        object char_literal220_tree=null;
        object IDENTIFIER221_tree=null;

    	try { DebugEnterRule(GrammarFileName, "qualifiedName");
    	DebugLocation(705, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 43)) { return retval; }
    		// Java.g:706:5: ( IDENTIFIER ( '.' IDENTIFIER )* )
    		DebugEnterAlt(1);
    		// Java.g:706:9: IDENTIFIER ( '.' IDENTIFIER )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(706, 9);
    		IDENTIFIER219=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_qualifiedName3439), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER219_tree = (object)adaptor.Create(IDENTIFIER219, retval);
    		adaptor.AddChild(root_0, IDENTIFIER219_tree);
    		}
    		DebugLocation(707, 9);
    		// Java.g:707:9: ( '.' IDENTIFIER )*
    		try { DebugEnterSubRule(77);
    		while (true)
    		{
    			int alt77=2;
    			try { DebugEnterDecision(77, decisionCanBacktrack[77]);
    			int LA77_0 = input.LA(1);

    			if ((LA77_0==DOT))
    			{
    				alt77=1;
    			}


    			} finally { DebugExitDecision(77); }
    			switch ( alt77 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:707:10: '.' IDENTIFIER
    				{
    				DebugLocation(707, 10);
    				char_literal220=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_qualifiedName3450), "DOT"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal220_tree = (object)adaptor.Create(char_literal220, retval);
    				adaptor.AddChild(root_0, char_literal220_tree);
    				}
    				DebugLocation(707, 14);
    				IDENTIFIER221=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_qualifiedName3452), "IDENTIFIER"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				IDENTIFIER221_tree = (object)adaptor.Create(IDENTIFIER221, retval);
    				adaptor.AddChild(root_0, IDENTIFIER221_tree);
    				}

    				}
    				break;

    			default:
    				goto loop77;
    			}
    		}

    		loop77:
    			;

    		} finally { DebugExitSubRule(77); }


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
            if (state.backtracking > 0) { Memoize(input, 43, qualifiedName_StartIndex); }
        }
     	DebugLocation(709, 4);
    	} finally { DebugExitRule(GrammarFileName, "qualifiedName"); }
    	return retval;

    }
    // $ANTLR end "qualifiedName"

    public class annotations_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_annotations() {}
    protected virtual void Leave_annotations() {}

    // $ANTLR start "annotations"
    // Java.g:711:1: annotations : ( annotation )+ ;
    [GrammarRule("annotations")]
    public JavaParser.annotations_return annotations()
    {

        JavaParser.annotations_return retval = new JavaParser.annotations_return();
        retval.Start = (IToken)input.LT(1);
        int annotations_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.annotation_return annotation222 = default(JavaParser.annotation_return);


    	try { DebugEnterRule(GrammarFileName, "annotations");
    	DebugLocation(711, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 44)) { return retval; }
    		// Java.g:712:5: ( ( annotation )+ )
    		DebugEnterAlt(1);
    		// Java.g:712:9: ( annotation )+
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(712, 9);
    		// Java.g:712:9: ( annotation )+
    		int cnt78=0;
    		try { DebugEnterSubRule(78);
    		while (true)
    		{
    			int alt78=2;
    			try { DebugEnterDecision(78, decisionCanBacktrack[78]);
    			int LA78_0 = input.LA(1);

    			if ((LA78_0==MONKEYS_AT))
    			{
    				alt78=1;
    			}


    			} finally { DebugExitDecision(78); }
    			switch (alt78)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:712:10: annotation
    				{
    				DebugLocation(712, 10);
    				PushFollow(Follow._annotation_in_annotations3484);
    				annotation222=annotation();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotation222.Tree, annotation222, retval);

    				}
    				break;

    			default:
    				if (cnt78 >= 1)
    					goto loop78;

    				if (state.backtracking>0) {state.failed=true; return retval;}
    				EarlyExitException eee78 = new EarlyExitException( 78, input );
    				DebugRecognitionException(eee78);
    				throw eee78;
    			}
    			cnt78++;
    		}
    		loop78:
    			;

    		} finally { DebugExitSubRule(78); }


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
            if (state.backtracking > 0) { Memoize(input, 44, annotations_StartIndex); }
        }
     	DebugLocation(714, 4);
    	} finally { DebugExitRule(GrammarFileName, "annotations"); }
    	return retval;

    }
    // $ANTLR end "annotations"

    public class annotation_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_annotation() {}
    protected virtual void Leave_annotation() {}

    // $ANTLR start "annotation"
    // Java.g:716:1: annotation : '@' qualifiedName ( '(' ( elementValuePairs | elementValue )? ')' )? ;
    [GrammarRule("annotation")]
    public JavaParser.annotation_return annotation()
    {

        JavaParser.annotation_return retval = new JavaParser.annotation_return();
        retval.Start = (IToken)input.LT(1);
        int annotation_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal223=null;
        IToken char_literal225=null;
        IToken char_literal228=null;
        JavaParser.qualifiedName_return qualifiedName224 = default(JavaParser.qualifiedName_return);
        JavaParser.elementValuePairs_return elementValuePairs226 = default(JavaParser.elementValuePairs_return);
        JavaParser.elementValue_return elementValue227 = default(JavaParser.elementValue_return);

        object char_literal223_tree=null;
        object char_literal225_tree=null;
        object char_literal228_tree=null;

    	try { DebugEnterRule(GrammarFileName, "annotation");
    	DebugLocation(716, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 45)) { return retval; }
    		// Java.g:721:5: ( '@' qualifiedName ( '(' ( elementValuePairs | elementValue )? ')' )? )
    		DebugEnterAlt(1);
    		// Java.g:721:9: '@' qualifiedName ( '(' ( elementValuePairs | elementValue )? ')' )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(721, 9);
    		char_literal223=(IToken)new XToken((IToken)Match(input,MONKEYS_AT,Follow._MONKEYS_AT_in_annotation3517), "MONKEYS_AT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal223_tree = (object)adaptor.Create(char_literal223, retval);
    		adaptor.AddChild(root_0, char_literal223_tree);
    		}
    		DebugLocation(721, 13);
    		PushFollow(Follow._qualifiedName_in_annotation3519);
    		qualifiedName224=qualifiedName();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, qualifiedName224.Tree, qualifiedName224, retval);
    		DebugLocation(722, 9);
    		// Java.g:722:9: ( '(' ( elementValuePairs | elementValue )? ')' )?
    		int alt80=2;
    		try { DebugEnterSubRule(80);
    		try { DebugEnterDecision(80, decisionCanBacktrack[80]);
    		int LA80_0 = input.LA(1);

    		if ((LA80_0==LPAREN))
    		{
    			alt80=1;
    		}
    		} finally { DebugExitDecision(80); }
    		switch (alt80)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:722:13: '(' ( elementValuePairs | elementValue )? ')'
    			{
    			DebugLocation(722, 13);
    			char_literal225=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_annotation3533), "LPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal225_tree = (object)adaptor.Create(char_literal225, retval);
    			adaptor.AddChild(root_0, char_literal225_tree);
    			}
    			DebugLocation(723, 19);
    			// Java.g:723:19: ( elementValuePairs | elementValue )?
    			int alt79=3;
    			try { DebugEnterSubRule(79);
    			try { DebugEnterDecision(79, decisionCanBacktrack[79]);
    			int LA79_0 = input.LA(1);

    			if ((LA79_0==IDENTIFIER))
    			{
    				int LA79_1 = input.LA(2);

    				if ((LA79_1==EQ))
    				{
    					alt79=1;
    				}
    				else if ((LA79_1==INSTANCEOF||(LA79_1>=LPAREN && LA79_1<=RPAREN)||LA79_1==LBRACKET||LA79_1==DOT||LA79_1==QUES||(LA79_1>=EQEQ && LA79_1<=PERCENT)||(LA79_1>=BANGEQ && LA79_1<=LT)))
    				{
    					alt79=2;
    				}
    			}
    			else if (((LA79_0>=INTLITERAL && LA79_0<=NULL)||LA79_0==BOOLEAN||LA79_0==BYTE||LA79_0==CHAR||LA79_0==DOUBLE||LA79_0==FLOAT||LA79_0==INT||LA79_0==LONG||LA79_0==NEW||LA79_0==SHORT||LA79_0==SUPER||LA79_0==THIS||LA79_0==VOID||LA79_0==LPAREN||LA79_0==LBRACE||(LA79_0>=BANG && LA79_0<=TILDE)||(LA79_0>=PLUSPLUS && LA79_0<=SUB)||LA79_0==MONKEYS_AT))
    			{
    				alt79=2;
    			}
    			} finally { DebugExitDecision(79); }
    			switch (alt79)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:723:23: elementValuePairs
    				{
    				DebugLocation(723, 23);
    				PushFollow(Follow._elementValuePairs_in_annotation3560);
    				elementValuePairs226=elementValuePairs();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValuePairs226.Tree, elementValuePairs226, retval);

    				}
    				break;
    			case 2:
    				DebugEnterAlt(2);
    				// Java.g:724:23: elementValue
    				{
    				DebugLocation(724, 23);
    				PushFollow(Follow._elementValue_in_annotation3584);
    				elementValue227=elementValue();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValue227.Tree, elementValue227, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(79); }

    			DebugLocation(726, 13);
    			char_literal228=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_annotation3620), "RPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal228_tree = (object)adaptor.Create(char_literal228, retval);
    			adaptor.AddChild(root_0, char_literal228_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(80); }


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
            if (state.backtracking > 0) { Memoize(input, 45, annotation_StartIndex); }
        }
     	DebugLocation(728, 4);
    	} finally { DebugExitRule(GrammarFileName, "annotation"); }
    	return retval;

    }
    // $ANTLR end "annotation"

    public class elementValuePairs_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_elementValuePairs() {}
    protected virtual void Leave_elementValuePairs() {}

    // $ANTLR start "elementValuePairs"
    // Java.g:730:1: elementValuePairs : elementValuePair ( ',' elementValuePair )* ;
    [GrammarRule("elementValuePairs")]
    public JavaParser.elementValuePairs_return elementValuePairs()
    {

        JavaParser.elementValuePairs_return retval = new JavaParser.elementValuePairs_return();
        retval.Start = (IToken)input.LT(1);
        int elementValuePairs_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal230=null;
        JavaParser.elementValuePair_return elementValuePair229 = default(JavaParser.elementValuePair_return);
        JavaParser.elementValuePair_return elementValuePair231 = default(JavaParser.elementValuePair_return);

        object char_literal230_tree=null;

    	try { DebugEnterRule(GrammarFileName, "elementValuePairs");
    	DebugLocation(730, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 46)) { return retval; }
    		// Java.g:731:5: ( elementValuePair ( ',' elementValuePair )* )
    		DebugEnterAlt(1);
    		// Java.g:731:9: elementValuePair ( ',' elementValuePair )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(731, 9);
    		PushFollow(Follow._elementValuePair_in_elementValuePairs3652);
    		elementValuePair229=elementValuePair();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValuePair229.Tree, elementValuePair229, retval);
    		DebugLocation(732, 9);
    		// Java.g:732:9: ( ',' elementValuePair )*
    		try { DebugEnterSubRule(81);
    		while (true)
    		{
    			int alt81=2;
    			try { DebugEnterDecision(81, decisionCanBacktrack[81]);
    			int LA81_0 = input.LA(1);

    			if ((LA81_0==COMMA))
    			{
    				alt81=1;
    			}


    			} finally { DebugExitDecision(81); }
    			switch ( alt81 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:732:10: ',' elementValuePair
    				{
    				DebugLocation(732, 10);
    				char_literal230=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_elementValuePairs3663), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal230_tree = (object)adaptor.Create(char_literal230, retval);
    				adaptor.AddChild(root_0, char_literal230_tree);
    				}
    				DebugLocation(732, 14);
    				PushFollow(Follow._elementValuePair_in_elementValuePairs3665);
    				elementValuePair231=elementValuePair();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValuePair231.Tree, elementValuePair231, retval);

    				}
    				break;

    			default:
    				goto loop81;
    			}
    		}

    		loop81:
    			;

    		} finally { DebugExitSubRule(81); }


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
            if (state.backtracking > 0) { Memoize(input, 46, elementValuePairs_StartIndex); }
        }
     	DebugLocation(734, 4);
    	} finally { DebugExitRule(GrammarFileName, "elementValuePairs"); }
    	return retval;

    }
    // $ANTLR end "elementValuePairs"

    public class elementValuePair_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_elementValuePair() {}
    protected virtual void Leave_elementValuePair() {}

    // $ANTLR start "elementValuePair"
    // Java.g:736:1: elementValuePair : IDENTIFIER '=' elementValue ;
    [GrammarRule("elementValuePair")]
    public JavaParser.elementValuePair_return elementValuePair()
    {

        JavaParser.elementValuePair_return retval = new JavaParser.elementValuePair_return();
        retval.Start = (IToken)input.LT(1);
        int elementValuePair_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER232=null;
        IToken char_literal233=null;
        JavaParser.elementValue_return elementValue234 = default(JavaParser.elementValue_return);

        object IDENTIFIER232_tree=null;
        object char_literal233_tree=null;

    	try { DebugEnterRule(GrammarFileName, "elementValuePair");
    	DebugLocation(736, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 47)) { return retval; }
    		// Java.g:737:5: ( IDENTIFIER '=' elementValue )
    		DebugEnterAlt(1);
    		// Java.g:737:9: IDENTIFIER '=' elementValue
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(737, 9);
    		IDENTIFIER232=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_elementValuePair3696), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER232_tree = (object)adaptor.Create(IDENTIFIER232, retval);
    		adaptor.AddChild(root_0, IDENTIFIER232_tree);
    		}
    		DebugLocation(737, 20);
    		char_literal233=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_elementValuePair3698), "EQ"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal233_tree = (object)adaptor.Create(char_literal233, retval);
    		adaptor.AddChild(root_0, char_literal233_tree);
    		}
    		DebugLocation(737, 24);
    		PushFollow(Follow._elementValue_in_elementValuePair3700);
    		elementValue234=elementValue();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValue234.Tree, elementValue234, retval);

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
            if (state.backtracking > 0) { Memoize(input, 47, elementValuePair_StartIndex); }
        }
     	DebugLocation(738, 4);
    	} finally { DebugExitRule(GrammarFileName, "elementValuePair"); }
    	return retval;

    }
    // $ANTLR end "elementValuePair"

    public class elementValue_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_elementValue() {}
    protected virtual void Leave_elementValue() {}

    // $ANTLR start "elementValue"
    // Java.g:740:1: elementValue : ( conditionalExpression | annotation | elementValueArrayInitializer );
    [GrammarRule("elementValue")]
    public JavaParser.elementValue_return elementValue()
    {

        JavaParser.elementValue_return retval = new JavaParser.elementValue_return();
        retval.Start = (IToken)input.LT(1);
        int elementValue_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.conditionalExpression_return conditionalExpression235 = default(JavaParser.conditionalExpression_return);
        JavaParser.annotation_return annotation236 = default(JavaParser.annotation_return);
        JavaParser.elementValueArrayInitializer_return elementValueArrayInitializer237 = default(JavaParser.elementValueArrayInitializer_return);


    	try { DebugEnterRule(GrammarFileName, "elementValue");
    	DebugLocation(740, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 48)) { return retval; }
    		// Java.g:741:5: ( conditionalExpression | annotation | elementValueArrayInitializer )
    		int alt82=3;
    		try { DebugEnterDecision(82, decisionCanBacktrack[82]);
    		switch (input.LA(1))
    		{
    		case IDENTIFIER:
    		case INTLITERAL:
    		case LONGLITERAL:
    		case FLOATLITERAL:
    		case DOUBLELITERAL:
    		case CHARLITERAL:
    		case STRINGLITERAL:
    		case TRUE:
    		case FALSE:
    		case NULL:
    		case BOOLEAN:
    		case BYTE:
    		case CHAR:
    		case DOUBLE:
    		case FLOAT:
    		case INT:
    		case LONG:
    		case NEW:
    		case SHORT:
    		case SUPER:
    		case THIS:
    		case VOID:
    		case LPAREN:
    		case BANG:
    		case TILDE:
    		case PLUSPLUS:
    		case SUBSUB:
    		case PLUS:
    		case SUB:
    			{
    			alt82=1;
    			}
    			break;
    		case MONKEYS_AT:
    			{
    			alt82=2;
    			}
    			break;
    		case LBRACE:
    			{
    			alt82=3;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 82, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(82); }
    		switch (alt82)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:741:9: conditionalExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(741, 9);
    			PushFollow(Follow._conditionalExpression_in_elementValue3720);
    			conditionalExpression235=conditionalExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, conditionalExpression235.Tree, conditionalExpression235, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:742:9: annotation
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(742, 9);
    			PushFollow(Follow._annotation_in_elementValue3730);
    			annotation236=annotation();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotation236.Tree, annotation236, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:743:9: elementValueArrayInitializer
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(743, 9);
    			PushFollow(Follow._elementValueArrayInitializer_in_elementValue3740);
    			elementValueArrayInitializer237=elementValueArrayInitializer();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValueArrayInitializer237.Tree, elementValueArrayInitializer237, retval);

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
            if (state.backtracking > 0) { Memoize(input, 48, elementValue_StartIndex); }
        }
     	DebugLocation(744, 4);
    	} finally { DebugExitRule(GrammarFileName, "elementValue"); }
    	return retval;

    }
    // $ANTLR end "elementValue"

    public class elementValueArrayInitializer_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_elementValueArrayInitializer() {}
    protected virtual void Leave_elementValueArrayInitializer() {}

    // $ANTLR start "elementValueArrayInitializer"
    // Java.g:746:1: elementValueArrayInitializer : '{' ( elementValue ( ',' elementValue )* )? ( ',' )? '}' ;
    [GrammarRule("elementValueArrayInitializer")]
    public JavaParser.elementValueArrayInitializer_return elementValueArrayInitializer()
    {

        JavaParser.elementValueArrayInitializer_return retval = new JavaParser.elementValueArrayInitializer_return();
        retval.Start = (IToken)input.LT(1);
        int elementValueArrayInitializer_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal238=null;
        IToken char_literal240=null;
        IToken char_literal242=null;
        IToken char_literal243=null;
        JavaParser.elementValue_return elementValue239 = default(JavaParser.elementValue_return);
        JavaParser.elementValue_return elementValue241 = default(JavaParser.elementValue_return);

        object char_literal238_tree=null;
        object char_literal240_tree=null;
        object char_literal242_tree=null;
        object char_literal243_tree=null;

    	try { DebugEnterRule(GrammarFileName, "elementValueArrayInitializer");
    	DebugLocation(746, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 49)) { return retval; }
    		// Java.g:747:5: ( '{' ( elementValue ( ',' elementValue )* )? ( ',' )? '}' )
    		DebugEnterAlt(1);
    		// Java.g:747:9: '{' ( elementValue ( ',' elementValue )* )? ( ',' )? '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(747, 9);
    		char_literal238=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_elementValueArrayInitializer3760), "LBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal238_tree = (object)adaptor.Create(char_literal238, retval);
    		adaptor.AddChild(root_0, char_literal238_tree);
    		}
    		DebugLocation(748, 9);
    		// Java.g:748:9: ( elementValue ( ',' elementValue )* )?
    		int alt84=2;
    		try { DebugEnterSubRule(84);
    		try { DebugEnterDecision(84, decisionCanBacktrack[84]);
    		int LA84_0 = input.LA(1);

    		if (((LA84_0>=IDENTIFIER && LA84_0<=NULL)||LA84_0==BOOLEAN||LA84_0==BYTE||LA84_0==CHAR||LA84_0==DOUBLE||LA84_0==FLOAT||LA84_0==INT||LA84_0==LONG||LA84_0==NEW||LA84_0==SHORT||LA84_0==SUPER||LA84_0==THIS||LA84_0==VOID||LA84_0==LPAREN||LA84_0==LBRACE||(LA84_0>=BANG && LA84_0<=TILDE)||(LA84_0>=PLUSPLUS && LA84_0<=SUB)||LA84_0==MONKEYS_AT))
    		{
    			alt84=1;
    		}
    		} finally { DebugExitDecision(84); }
    		switch (alt84)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:748:10: elementValue ( ',' elementValue )*
    			{
    			DebugLocation(748, 10);
    			PushFollow(Follow._elementValue_in_elementValueArrayInitializer3771);
    			elementValue239=elementValue();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValue239.Tree, elementValue239, retval);
    			DebugLocation(749, 13);
    			// Java.g:749:13: ( ',' elementValue )*
    			try { DebugEnterSubRule(83);
    			while (true)
    			{
    				int alt83=2;
    				try { DebugEnterDecision(83, decisionCanBacktrack[83]);
    				int LA83_0 = input.LA(1);

    				if ((LA83_0==COMMA))
    				{
    					int LA83_1 = input.LA(2);

    					if (((LA83_1>=IDENTIFIER && LA83_1<=NULL)||LA83_1==BOOLEAN||LA83_1==BYTE||LA83_1==CHAR||LA83_1==DOUBLE||LA83_1==FLOAT||LA83_1==INT||LA83_1==LONG||LA83_1==NEW||LA83_1==SHORT||LA83_1==SUPER||LA83_1==THIS||LA83_1==VOID||LA83_1==LPAREN||LA83_1==LBRACE||(LA83_1>=BANG && LA83_1<=TILDE)||(LA83_1>=PLUSPLUS && LA83_1<=SUB)||LA83_1==MONKEYS_AT))
    					{
    						alt83=1;
    					}


    				}


    				} finally { DebugExitDecision(83); }
    				switch ( alt83 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:749:14: ',' elementValue
    					{
    					DebugLocation(749, 14);
    					char_literal240=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_elementValueArrayInitializer3786), "COMMA"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal240_tree = (object)adaptor.Create(char_literal240, retval);
    					adaptor.AddChild(root_0, char_literal240_tree);
    					}
    					DebugLocation(749, 18);
    					PushFollow(Follow._elementValue_in_elementValueArrayInitializer3788);
    					elementValue241=elementValue();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValue241.Tree, elementValue241, retval);

    					}
    					break;

    				default:
    					goto loop83;
    				}
    			}

    			loop83:
    				;

    			} finally { DebugExitSubRule(83); }


    			}
    			break;

    		}
    		} finally { DebugExitSubRule(84); }

    		DebugLocation(751, 12);
    		// Java.g:751:12: ( ',' )?
    		int alt85=2;
    		try { DebugEnterSubRule(85);
    		try { DebugEnterDecision(85, decisionCanBacktrack[85]);
    		int LA85_0 = input.LA(1);

    		if ((LA85_0==COMMA))
    		{
    			alt85=1;
    		}
    		} finally { DebugExitDecision(85); }
    		switch (alt85)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:751:13: ','
    			{
    			DebugLocation(751, 13);
    			char_literal242=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_elementValueArrayInitializer3817), "COMMA"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal242_tree = (object)adaptor.Create(char_literal242, retval);
    			adaptor.AddChild(root_0, char_literal242_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(85); }

    		DebugLocation(751, 19);
    		char_literal243=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_elementValueArrayInitializer3821), "RBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal243_tree = (object)adaptor.Create(char_literal243, retval);
    		adaptor.AddChild(root_0, char_literal243_tree);
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
            if (state.backtracking > 0) { Memoize(input, 49, elementValueArrayInitializer_StartIndex); }
        }
     	DebugLocation(752, 4);
    	} finally { DebugExitRule(GrammarFileName, "elementValueArrayInitializer"); }
    	return retval;

    }
    // $ANTLR end "elementValueArrayInitializer"

    public class annotationTypeDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_annotationTypeDeclaration() {}
    protected virtual void Leave_annotationTypeDeclaration() {}

    // $ANTLR start "annotationTypeDeclaration"
    // Java.g:755:1: annotationTypeDeclaration : modifiers '@' 'interface' IDENTIFIER annotationTypeBody ;
    [GrammarRule("annotationTypeDeclaration")]
    public JavaParser.annotationTypeDeclaration_return annotationTypeDeclaration()
    {

        JavaParser.annotationTypeDeclaration_return retval = new JavaParser.annotationTypeDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int annotationTypeDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal245=null;
        IToken string_literal246=null;
        IToken IDENTIFIER247=null;
        JavaParser.modifiers_return modifiers244 = default(JavaParser.modifiers_return);
        JavaParser.annotationTypeBody_return annotationTypeBody248 = default(JavaParser.annotationTypeBody_return);

        object char_literal245_tree=null;
        object string_literal246_tree=null;
        object IDENTIFIER247_tree=null;

    	try { DebugEnterRule(GrammarFileName, "annotationTypeDeclaration");
    	DebugLocation(755, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 50)) { return retval; }
    		// Java.g:759:5: ( modifiers '@' 'interface' IDENTIFIER annotationTypeBody )
    		DebugEnterAlt(1);
    		// Java.g:759:9: modifiers '@' 'interface' IDENTIFIER annotationTypeBody
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(759, 9);
    		PushFollow(Follow._modifiers_in_annotationTypeDeclaration3844);
    		modifiers244=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers244.Tree, modifiers244, retval);
    		DebugLocation(759, 19);
    		char_literal245=(IToken)new XToken((IToken)Match(input,MONKEYS_AT,Follow._MONKEYS_AT_in_annotationTypeDeclaration3846), "MONKEYS_AT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal245_tree = (object)adaptor.Create(char_literal245, retval);
    		adaptor.AddChild(root_0, char_literal245_tree);
    		}
    		DebugLocation(760, 9);
    		string_literal246=(IToken)new XToken((IToken)Match(input,INTERFACE,Follow._INTERFACE_in_annotationTypeDeclaration3856), "INTERFACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal246_tree = (object)adaptor.Create(string_literal246, retval);
    		adaptor.AddChild(root_0, string_literal246_tree);
    		}
    		DebugLocation(761, 9);
    		IDENTIFIER247=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_annotationTypeDeclaration3866), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER247_tree = (object)adaptor.Create(IDENTIFIER247, retval);
    		adaptor.AddChild(root_0, IDENTIFIER247_tree);
    		}
    		DebugLocation(762, 9);
    		PushFollow(Follow._annotationTypeBody_in_annotationTypeDeclaration3876);
    		annotationTypeBody248=annotationTypeBody();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotationTypeBody248.Tree, annotationTypeBody248, retval);

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
            if (state.backtracking > 0) { Memoize(input, 50, annotationTypeDeclaration_StartIndex); }
        }
     	DebugLocation(763, 4);
    	} finally { DebugExitRule(GrammarFileName, "annotationTypeDeclaration"); }
    	return retval;

    }
    // $ANTLR end "annotationTypeDeclaration"

    public class annotationTypeBody_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_annotationTypeBody() {}
    protected virtual void Leave_annotationTypeBody() {}

    // $ANTLR start "annotationTypeBody"
    // Java.g:766:1: annotationTypeBody : '{' ( annotationTypeElementDeclaration )* '}' ;
    [GrammarRule("annotationTypeBody")]
    public JavaParser.annotationTypeBody_return annotationTypeBody()
    {

        JavaParser.annotationTypeBody_return retval = new JavaParser.annotationTypeBody_return();
        retval.Start = (IToken)input.LT(1);
        int annotationTypeBody_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal249=null;
        IToken char_literal251=null;
        JavaParser.annotationTypeElementDeclaration_return annotationTypeElementDeclaration250 = default(JavaParser.annotationTypeElementDeclaration_return);

        object char_literal249_tree=null;
        object char_literal251_tree=null;

    	try { DebugEnterRule(GrammarFileName, "annotationTypeBody");
    	DebugLocation(766, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 51)) { return retval; }
    		// Java.g:767:5: ( '{' ( annotationTypeElementDeclaration )* '}' )
    		DebugEnterAlt(1);
    		// Java.g:767:9: '{' ( annotationTypeElementDeclaration )* '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(767, 9);
    		char_literal249=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_annotationTypeBody3897), "LBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal249_tree = (object)adaptor.Create(char_literal249, retval);
    		adaptor.AddChild(root_0, char_literal249_tree);
    		}
    		DebugLocation(768, 9);
    		// Java.g:768:9: ( annotationTypeElementDeclaration )*
    		try { DebugEnterSubRule(86);
    		while (true)
    		{
    			int alt86=2;
    			try { DebugEnterDecision(86, decisionCanBacktrack[86]);
    			int LA86_0 = input.LA(1);

    			if ((LA86_0==IDENTIFIER||LA86_0==ABSTRACT||LA86_0==BOOLEAN||LA86_0==BYTE||(LA86_0>=CHAR && LA86_0<=CLASS)||LA86_0==DOUBLE||LA86_0==ENUM||LA86_0==FINAL||LA86_0==FLOAT||(LA86_0>=INT && LA86_0<=NATIVE)||(LA86_0>=PRIVATE && LA86_0<=PUBLIC)||(LA86_0>=SHORT && LA86_0<=STRICTFP)||LA86_0==SYNCHRONIZED||LA86_0==TRANSIENT||(LA86_0>=VOID && LA86_0<=VOLATILE)||LA86_0==SEMI||LA86_0==MONKEYS_AT||LA86_0==LT))
    			{
    				alt86=1;
    			}


    			} finally { DebugExitDecision(86); }
    			switch ( alt86 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:768:10: annotationTypeElementDeclaration
    				{
    				DebugLocation(768, 10);
    				PushFollow(Follow._annotationTypeElementDeclaration_in_annotationTypeBody3909);
    				annotationTypeElementDeclaration250=annotationTypeElementDeclaration();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotationTypeElementDeclaration250.Tree, annotationTypeElementDeclaration250, retval);

    				}
    				break;

    			default:
    				goto loop86;
    			}
    		}

    		loop86:
    			;

    		} finally { DebugExitSubRule(86); }

    		DebugLocation(770, 9);
    		char_literal251=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_annotationTypeBody3931), "RBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal251_tree = (object)adaptor.Create(char_literal251, retval);
    		adaptor.AddChild(root_0, char_literal251_tree);
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
            if (state.backtracking > 0) { Memoize(input, 51, annotationTypeBody_StartIndex); }
        }
     	DebugLocation(771, 4);
    	} finally { DebugExitRule(GrammarFileName, "annotationTypeBody"); }
    	return retval;

    }
    // $ANTLR end "annotationTypeBody"

    public class annotationTypeElementDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_annotationTypeElementDeclaration() {}
    protected virtual void Leave_annotationTypeElementDeclaration() {}

    // $ANTLR start "annotationTypeElementDeclaration"
    // Java.g:773:1: annotationTypeElementDeclaration : ( annotationMethodDeclaration | interfaceFieldDeclaration | normalClassDeclaration | normalInterfaceDeclaration | enumDeclaration | annotationTypeDeclaration | ';' );
    [GrammarRule("annotationTypeElementDeclaration")]
    public JavaParser.annotationTypeElementDeclaration_return annotationTypeElementDeclaration()
    {

        JavaParser.annotationTypeElementDeclaration_return retval = new JavaParser.annotationTypeElementDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int annotationTypeElementDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal258=null;
        JavaParser.annotationMethodDeclaration_return annotationMethodDeclaration252 = default(JavaParser.annotationMethodDeclaration_return);
        JavaParser.interfaceFieldDeclaration_return interfaceFieldDeclaration253 = default(JavaParser.interfaceFieldDeclaration_return);
        JavaParser.normalClassDeclaration_return normalClassDeclaration254 = default(JavaParser.normalClassDeclaration_return);
        JavaParser.normalInterfaceDeclaration_return normalInterfaceDeclaration255 = default(JavaParser.normalInterfaceDeclaration_return);
        JavaParser.enumDeclaration_return enumDeclaration256 = default(JavaParser.enumDeclaration_return);
        JavaParser.annotationTypeDeclaration_return annotationTypeDeclaration257 = default(JavaParser.annotationTypeDeclaration_return);

        object char_literal258_tree=null;

    	try { DebugEnterRule(GrammarFileName, "annotationTypeElementDeclaration");
    	DebugLocation(773, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 52)) { return retval; }
    		// Java.g:777:5: ( annotationMethodDeclaration | interfaceFieldDeclaration | normalClassDeclaration | normalInterfaceDeclaration | enumDeclaration | annotationTypeDeclaration | ';' )
    		int alt87=7;
    		try { DebugEnterDecision(87, decisionCanBacktrack[87]);
    		try
    		{
    			alt87 = dfa87.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(87); }
    		switch (alt87)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:777:9: annotationMethodDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(777, 9);
    			PushFollow(Follow._annotationMethodDeclaration_in_annotationTypeElementDeclaration3953);
    			annotationMethodDeclaration252=annotationMethodDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotationMethodDeclaration252.Tree, annotationMethodDeclaration252, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:778:9: interfaceFieldDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(778, 9);
    			PushFollow(Follow._interfaceFieldDeclaration_in_annotationTypeElementDeclaration3963);
    			interfaceFieldDeclaration253=interfaceFieldDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, interfaceFieldDeclaration253.Tree, interfaceFieldDeclaration253, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:779:9: normalClassDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(779, 9);
    			PushFollow(Follow._normalClassDeclaration_in_annotationTypeElementDeclaration3973);
    			normalClassDeclaration254=normalClassDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, normalClassDeclaration254.Tree, normalClassDeclaration254, retval);

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:780:9: normalInterfaceDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(780, 9);
    			PushFollow(Follow._normalInterfaceDeclaration_in_annotationTypeElementDeclaration3983);
    			normalInterfaceDeclaration255=normalInterfaceDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, normalInterfaceDeclaration255.Tree, normalInterfaceDeclaration255, retval);

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:781:9: enumDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(781, 9);
    			PushFollow(Follow._enumDeclaration_in_annotationTypeElementDeclaration3993);
    			enumDeclaration256=enumDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, enumDeclaration256.Tree, enumDeclaration256, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Java.g:782:9: annotationTypeDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(782, 9);
    			PushFollow(Follow._annotationTypeDeclaration_in_annotationTypeElementDeclaration4003);
    			annotationTypeDeclaration257=annotationTypeDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, annotationTypeDeclaration257.Tree, annotationTypeDeclaration257, retval);

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Java.g:783:9: ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(783, 9);
    			char_literal258=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_annotationTypeElementDeclaration4013), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal258_tree = (object)adaptor.Create(char_literal258, retval);
    			adaptor.AddChild(root_0, char_literal258_tree);
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
            if (state.backtracking > 0) { Memoize(input, 52, annotationTypeElementDeclaration_StartIndex); }
        }
     	DebugLocation(784, 4);
    	} finally { DebugExitRule(GrammarFileName, "annotationTypeElementDeclaration"); }
    	return retval;

    }
    // $ANTLR end "annotationTypeElementDeclaration"

    public class annotationMethodDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_annotationMethodDeclaration() {}
    protected virtual void Leave_annotationMethodDeclaration() {}

    // $ANTLR start "annotationMethodDeclaration"
    // Java.g:786:1: annotationMethodDeclaration : modifiers type IDENTIFIER '(' ')' ( 'default' elementValue )? ';' ;
    [GrammarRule("annotationMethodDeclaration")]
    public JavaParser.annotationMethodDeclaration_return annotationMethodDeclaration()
    {

        JavaParser.annotationMethodDeclaration_return retval = new JavaParser.annotationMethodDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int annotationMethodDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER261=null;
        IToken char_literal262=null;
        IToken char_literal263=null;
        IToken string_literal264=null;
        IToken char_literal266=null;
        JavaParser.modifiers_return modifiers259 = default(JavaParser.modifiers_return);
        JavaParser.type_return type260 = default(JavaParser.type_return);
        JavaParser.elementValue_return elementValue265 = default(JavaParser.elementValue_return);

        object IDENTIFIER261_tree=null;
        object char_literal262_tree=null;
        object char_literal263_tree=null;
        object string_literal264_tree=null;
        object char_literal266_tree=null;

    	try { DebugEnterRule(GrammarFileName, "annotationMethodDeclaration");
    	DebugLocation(786, 8);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 53)) { return retval; }
    		// Java.g:787:5: ( modifiers type IDENTIFIER '(' ')' ( 'default' elementValue )? ';' )
    		DebugEnterAlt(1);
    		// Java.g:787:9: modifiers type IDENTIFIER '(' ')' ( 'default' elementValue )? ';'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(787, 9);
    		PushFollow(Follow._modifiers_in_annotationMethodDeclaration4033);
    		modifiers259=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers259.Tree, modifiers259, retval);
    		DebugLocation(787, 19);
    		PushFollow(Follow._type_in_annotationMethodDeclaration4035);
    		type260=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type260.Tree, type260, retval);
    		DebugLocation(787, 24);
    		IDENTIFIER261=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_annotationMethodDeclaration4037), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER261_tree = (object)adaptor.Create(IDENTIFIER261, retval);
    		adaptor.AddChild(root_0, IDENTIFIER261_tree);
    		}
    		DebugLocation(788, 9);
    		char_literal262=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_annotationMethodDeclaration4047), "LPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal262_tree = (object)adaptor.Create(char_literal262, retval);
    		adaptor.AddChild(root_0, char_literal262_tree);
    		}
    		DebugLocation(788, 13);
    		char_literal263=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_annotationMethodDeclaration4049), "RPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal263_tree = (object)adaptor.Create(char_literal263, retval);
    		adaptor.AddChild(root_0, char_literal263_tree);
    		}
    		DebugLocation(788, 17);
    		// Java.g:788:17: ( 'default' elementValue )?
    		int alt88=2;
    		try { DebugEnterSubRule(88);
    		try { DebugEnterDecision(88, decisionCanBacktrack[88]);
    		int LA88_0 = input.LA(1);

    		if ((LA88_0==DEFAULT))
    		{
    			alt88=1;
    		}
    		} finally { DebugExitDecision(88); }
    		switch (alt88)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:788:18: 'default' elementValue
    			{
    			DebugLocation(788, 18);
    			string_literal264=(IToken)new XToken((IToken)Match(input,DEFAULT,Follow._DEFAULT_in_annotationMethodDeclaration4052), "DEFAULT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal264_tree = (object)adaptor.Create(string_literal264, retval);
    			adaptor.AddChild(root_0, string_literal264_tree);
    			}
    			DebugLocation(788, 28);
    			PushFollow(Follow._elementValue_in_annotationMethodDeclaration4054);
    			elementValue265=elementValue();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, elementValue265.Tree, elementValue265, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(88); }

    		DebugLocation(790, 9);
    		char_literal266=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_annotationMethodDeclaration4083), "SEMI"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal266_tree = (object)adaptor.Create(char_literal266, retval);
    		adaptor.AddChild(root_0, char_literal266_tree);
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
            if (state.backtracking > 0) { Memoize(input, 53, annotationMethodDeclaration_StartIndex); }
        }
     	DebugLocation(791, 8);
    	} finally { DebugExitRule(GrammarFileName, "annotationMethodDeclaration"); }
    	return retval;

    }
    // $ANTLR end "annotationMethodDeclaration"

    public class block_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_block() {}
    protected virtual void Leave_block() {}

    // $ANTLR start "block"
    // Java.g:793:1: block : '{' ( blockStatement )* '}' ;
    [GrammarRule("block")]
    public JavaParser.block_return block()
    {

        JavaParser.block_return retval = new JavaParser.block_return();
        retval.Start = (IToken)input.LT(1);
        int block_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal267=null;
        IToken char_literal269=null;
        JavaParser.blockStatement_return blockStatement268 = default(JavaParser.blockStatement_return);

        object char_literal267_tree=null;
        object char_literal269_tree=null;

    	try { DebugEnterRule(GrammarFileName, "block");
    	DebugLocation(793, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 54)) { return retval; }
    		// Java.g:794:5: ( '{' ( blockStatement )* '}' )
    		DebugEnterAlt(1);
    		// Java.g:794:9: '{' ( blockStatement )* '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(794, 9);
    		char_literal267=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_block4107), "LBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal267_tree = (object)adaptor.Create(char_literal267, retval);
    		adaptor.AddChild(root_0, char_literal267_tree);
    		}
    		DebugLocation(795, 9);
    		// Java.g:795:9: ( blockStatement )*
    		try { DebugEnterSubRule(89);
    		while (true)
    		{
    			int alt89=2;
    			try { DebugEnterDecision(89, decisionCanBacktrack[89]);
    			int LA89_0 = input.LA(1);

    			if (((LA89_0>=IDENTIFIER && LA89_0<=NULL)||(LA89_0>=ABSTRACT && LA89_0<=BYTE)||(LA89_0>=CHAR && LA89_0<=CLASS)||LA89_0==CONTINUE||(LA89_0>=DO && LA89_0<=DOUBLE)||LA89_0==ENUM||LA89_0==FINAL||(LA89_0>=FLOAT && LA89_0<=FOR)||LA89_0==IF||(LA89_0>=INT && LA89_0<=NEW)||(LA89_0>=PRIVATE && LA89_0<=THROW)||(LA89_0>=TRANSIENT && LA89_0<=LPAREN)||LA89_0==LBRACE||LA89_0==SEMI||(LA89_0>=BANG && LA89_0<=TILDE)||(LA89_0>=PLUSPLUS && LA89_0<=SUB)||LA89_0==MONKEYS_AT||LA89_0==LT))
    			{
    				alt89=1;
    			}


    			} finally { DebugExitDecision(89); }
    			switch ( alt89 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:795:10: blockStatement
    				{
    				DebugLocation(795, 10);
    				PushFollow(Follow._blockStatement_in_block4118);
    				blockStatement268=blockStatement();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, blockStatement268.Tree, blockStatement268, retval);

    				}
    				break;

    			default:
    				goto loop89;
    			}
    		}

    		loop89:
    			;

    		} finally { DebugExitSubRule(89); }

    		DebugLocation(797, 9);
    		char_literal269=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_block4139), "RBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal269_tree = (object)adaptor.Create(char_literal269, retval);
    		adaptor.AddChild(root_0, char_literal269_tree);
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
            if (state.backtracking > 0) { Memoize(input, 54, block_StartIndex); }
        }
     	DebugLocation(798, 4);
    	} finally { DebugExitRule(GrammarFileName, "block"); }
    	return retval;

    }
    // $ANTLR end "block"

    public class blockStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_blockStatement() {}
    protected virtual void Leave_blockStatement() {}

    // $ANTLR start "blockStatement"
    // Java.g:824:1: blockStatement : ( localVariableDeclarationStatement | classOrInterfaceDeclaration | statement );
    [GrammarRule("blockStatement")]
    public JavaParser.blockStatement_return blockStatement()
    {

        JavaParser.blockStatement_return retval = new JavaParser.blockStatement_return();
        retval.Start = (IToken)input.LT(1);
        int blockStatement_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.localVariableDeclarationStatement_return localVariableDeclarationStatement270 = default(JavaParser.localVariableDeclarationStatement_return);
        JavaParser.classOrInterfaceDeclaration_return classOrInterfaceDeclaration271 = default(JavaParser.classOrInterfaceDeclaration_return);
        JavaParser.statement_return statement272 = default(JavaParser.statement_return);


    	try { DebugEnterRule(GrammarFileName, "blockStatement");
    	DebugLocation(824, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 55)) { return retval; }
    		// Java.g:825:5: ( localVariableDeclarationStatement | classOrInterfaceDeclaration | statement )
    		int alt90=3;
    		try { DebugEnterDecision(90, decisionCanBacktrack[90]);
    		try
    		{
    			alt90 = dfa90.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(90); }
    		switch (alt90)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:825:9: localVariableDeclarationStatement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(825, 9);
    			PushFollow(Follow._localVariableDeclarationStatement_in_blockStatement4161);
    			localVariableDeclarationStatement270=localVariableDeclarationStatement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, localVariableDeclarationStatement270.Tree, localVariableDeclarationStatement270, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:826:9: classOrInterfaceDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(826, 9);
    			PushFollow(Follow._classOrInterfaceDeclaration_in_blockStatement4171);
    			classOrInterfaceDeclaration271=classOrInterfaceDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classOrInterfaceDeclaration271.Tree, classOrInterfaceDeclaration271, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:827:9: statement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(827, 9);
    			PushFollow(Follow._statement_in_blockStatement4181);
    			statement272=statement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement272.Tree, statement272, retval);

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
            if (state.backtracking > 0) { Memoize(input, 55, blockStatement_StartIndex); }
        }
     	DebugLocation(828, 4);
    	} finally { DebugExitRule(GrammarFileName, "blockStatement"); }
    	return retval;

    }
    // $ANTLR end "blockStatement"

    public class localVariableDeclarationStatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_localVariableDeclarationStatement() {}
    protected virtual void Leave_localVariableDeclarationStatement() {}

    // $ANTLR start "localVariableDeclarationStatement"
    // Java.g:831:1: localVariableDeclarationStatement : localVariableDeclaration ';' ;
    [GrammarRule("localVariableDeclarationStatement")]
    public JavaParser.localVariableDeclarationStatement_return localVariableDeclarationStatement()
    {

        JavaParser.localVariableDeclarationStatement_return retval = new JavaParser.localVariableDeclarationStatement_return();
        retval.Start = (IToken)input.LT(1);
        int localVariableDeclarationStatement_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal274=null;
        JavaParser.localVariableDeclaration_return localVariableDeclaration273 = default(JavaParser.localVariableDeclaration_return);

        object char_literal274_tree=null;

    	try { DebugEnterRule(GrammarFileName, "localVariableDeclarationStatement");
    	DebugLocation(831, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 56)) { return retval; }
    		// Java.g:832:5: ( localVariableDeclaration ';' )
    		DebugEnterAlt(1);
    		// Java.g:832:9: localVariableDeclaration ';'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(832, 9);
    		PushFollow(Follow._localVariableDeclaration_in_localVariableDeclarationStatement4202);
    		localVariableDeclaration273=localVariableDeclaration();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, localVariableDeclaration273.Tree, localVariableDeclaration273, retval);
    		DebugLocation(833, 9);
    		char_literal274=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_localVariableDeclarationStatement4212), "SEMI"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal274_tree = (object)adaptor.Create(char_literal274, retval);
    		adaptor.AddChild(root_0, char_literal274_tree);
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
            if (state.backtracking > 0) { Memoize(input, 56, localVariableDeclarationStatement_StartIndex); }
        }
     	DebugLocation(834, 4);
    	} finally { DebugExitRule(GrammarFileName, "localVariableDeclarationStatement"); }
    	return retval;

    }
    // $ANTLR end "localVariableDeclarationStatement"

    public class localVariableDeclaration_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_localVariableDeclaration() {}
    protected virtual void Leave_localVariableDeclaration() {}

    // $ANTLR start "localVariableDeclaration"
    // Java.g:836:1: localVariableDeclaration : variableModifiers type variableDeclarator ( ',' variableDeclarator )* ;
    [GrammarRule("localVariableDeclaration")]
    public JavaParser.localVariableDeclaration_return localVariableDeclaration()
    {

        JavaParser.localVariableDeclaration_return retval = new JavaParser.localVariableDeclaration_return();
        retval.Start = (IToken)input.LT(1);
        int localVariableDeclaration_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal278=null;
        JavaParser.variableModifiers_return variableModifiers275 = default(JavaParser.variableModifiers_return);
        JavaParser.type_return type276 = default(JavaParser.type_return);
        JavaParser.variableDeclarator_return variableDeclarator277 = default(JavaParser.variableDeclarator_return);
        JavaParser.variableDeclarator_return variableDeclarator279 = default(JavaParser.variableDeclarator_return);

        object char_literal278_tree=null;

    	try { DebugEnterRule(GrammarFileName, "localVariableDeclaration");
    	DebugLocation(836, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 57)) { return retval; }
    		// Java.g:837:5: ( variableModifiers type variableDeclarator ( ',' variableDeclarator )* )
    		DebugEnterAlt(1);
    		// Java.g:837:9: variableModifiers type variableDeclarator ( ',' variableDeclarator )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(837, 9);
    		PushFollow(Follow._variableModifiers_in_localVariableDeclaration4232);
    		variableModifiers275=variableModifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableModifiers275.Tree, variableModifiers275, retval);
    		DebugLocation(837, 27);
    		PushFollow(Follow._type_in_localVariableDeclaration4234);
    		type276=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type276.Tree, type276, retval);
    		DebugLocation(838, 9);
    		PushFollow(Follow._variableDeclarator_in_localVariableDeclaration4244);
    		variableDeclarator277=variableDeclarator();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableDeclarator277.Tree, variableDeclarator277, retval);
    		DebugLocation(839, 9);
    		// Java.g:839:9: ( ',' variableDeclarator )*
    		try { DebugEnterSubRule(91);
    		while (true)
    		{
    			int alt91=2;
    			try { DebugEnterDecision(91, decisionCanBacktrack[91]);
    			int LA91_0 = input.LA(1);

    			if ((LA91_0==COMMA))
    			{
    				alt91=1;
    			}


    			} finally { DebugExitDecision(91); }
    			switch ( alt91 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:839:10: ',' variableDeclarator
    				{
    				DebugLocation(839, 10);
    				char_literal278=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_localVariableDeclaration4255), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal278_tree = (object)adaptor.Create(char_literal278, retval);
    				adaptor.AddChild(root_0, char_literal278_tree);
    				}
    				DebugLocation(839, 14);
    				PushFollow(Follow._variableDeclarator_in_localVariableDeclaration4257);
    				variableDeclarator279=variableDeclarator();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableDeclarator279.Tree, variableDeclarator279, retval);

    				}
    				break;

    			default:
    				goto loop91;
    			}
    		}

    		loop91:
    			;

    		} finally { DebugExitSubRule(91); }


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
            if (state.backtracking > 0) { Memoize(input, 57, localVariableDeclaration_StartIndex); }
        }
     	DebugLocation(841, 4);
    	} finally { DebugExitRule(GrammarFileName, "localVariableDeclaration"); }
    	return retval;

    }
    // $ANTLR end "localVariableDeclaration"

    public class statement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_statement() {}
    protected virtual void Leave_statement() {}

    // $ANTLR start "statement"
    // Java.g:843:1: statement : ( block | ( 'assert' ) expression ( ':' expression )? ';' | 'assert' expression ( ':' expression )? ';' | 'if' parExpression statement ( 'else' statement )? | forstatement | 'while' parExpression statement | 'do' statement 'while' parExpression ';' | trystatement | 'switch' parExpression '{' switchBlockStatementGroups '}' | 'synchronized' parExpression block | 'return' ( expression )? ';' | 'throw' expression ';' | 'break' ( IDENTIFIER )? ';' | 'continue' ( IDENTIFIER )? ';' | expression ';' | IDENTIFIER ':' statement | ';' );
    [GrammarRule("statement")]
    public JavaParser.statement_return statement()
    {

        JavaParser.statement_return retval = new JavaParser.statement_return();
        retval.Start = (IToken)input.LT(1);
        int statement_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal281=null;
        IToken char_literal283=null;
        IToken char_literal285=null;
        IToken string_literal286=null;
        IToken char_literal288=null;
        IToken char_literal290=null;
        IToken string_literal291=null;
        IToken string_literal294=null;
        IToken string_literal297=null;
        IToken string_literal300=null;
        IToken string_literal302=null;
        IToken char_literal304=null;
        IToken string_literal306=null;
        IToken char_literal308=null;
        IToken char_literal310=null;
        IToken string_literal311=null;
        IToken string_literal314=null;
        IToken char_literal316=null;
        IToken string_literal317=null;
        IToken char_literal319=null;
        IToken string_literal320=null;
        IToken IDENTIFIER321=null;
        IToken char_literal322=null;
        IToken string_literal323=null;
        IToken IDENTIFIER324=null;
        IToken char_literal325=null;
        IToken char_literal327=null;
        IToken IDENTIFIER328=null;
        IToken char_literal329=null;
        IToken char_literal331=null;
        JavaParser.block_return block280 = default(JavaParser.block_return);
        JavaParser.expression_return expression282 = default(JavaParser.expression_return);
        JavaParser.expression_return expression284 = default(JavaParser.expression_return);
        JavaParser.expression_return expression287 = default(JavaParser.expression_return);
        JavaParser.expression_return expression289 = default(JavaParser.expression_return);
        JavaParser.parExpression_return parExpression292 = default(JavaParser.parExpression_return);
        JavaParser.statement_return statement293 = default(JavaParser.statement_return);
        JavaParser.statement_return statement295 = default(JavaParser.statement_return);
        JavaParser.forstatement_return forstatement296 = default(JavaParser.forstatement_return);
        JavaParser.parExpression_return parExpression298 = default(JavaParser.parExpression_return);
        JavaParser.statement_return statement299 = default(JavaParser.statement_return);
        JavaParser.statement_return statement301 = default(JavaParser.statement_return);
        JavaParser.parExpression_return parExpression303 = default(JavaParser.parExpression_return);
        JavaParser.trystatement_return trystatement305 = default(JavaParser.trystatement_return);
        JavaParser.parExpression_return parExpression307 = default(JavaParser.parExpression_return);
        JavaParser.switchBlockStatementGroups_return switchBlockStatementGroups309 = default(JavaParser.switchBlockStatementGroups_return);
        JavaParser.parExpression_return parExpression312 = default(JavaParser.parExpression_return);
        JavaParser.block_return block313 = default(JavaParser.block_return);
        JavaParser.expression_return expression315 = default(JavaParser.expression_return);
        JavaParser.expression_return expression318 = default(JavaParser.expression_return);
        JavaParser.expression_return expression326 = default(JavaParser.expression_return);
        JavaParser.statement_return statement330 = default(JavaParser.statement_return);

        object string_literal281_tree=null;
        object char_literal283_tree=null;
        object char_literal285_tree=null;
        object string_literal286_tree=null;
        object char_literal288_tree=null;
        object char_literal290_tree=null;
        object string_literal291_tree=null;
        object string_literal294_tree=null;
        object string_literal297_tree=null;
        object string_literal300_tree=null;
        object string_literal302_tree=null;
        object char_literal304_tree=null;
        object string_literal306_tree=null;
        object char_literal308_tree=null;
        object char_literal310_tree=null;
        object string_literal311_tree=null;
        object string_literal314_tree=null;
        object char_literal316_tree=null;
        object string_literal317_tree=null;
        object char_literal319_tree=null;
        object string_literal320_tree=null;
        object IDENTIFIER321_tree=null;
        object char_literal322_tree=null;
        object string_literal323_tree=null;
        object IDENTIFIER324_tree=null;
        object char_literal325_tree=null;
        object char_literal327_tree=null;
        object IDENTIFIER328_tree=null;
        object char_literal329_tree=null;
        object char_literal331_tree=null;

    	try { DebugEnterRule(GrammarFileName, "statement");
    	DebugLocation(843, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 58)) { return retval; }
    		// Java.g:844:5: ( block | ( 'assert' ) expression ( ':' expression )? ';' | 'assert' expression ( ':' expression )? ';' | 'if' parExpression statement ( 'else' statement )? | forstatement | 'while' parExpression statement | 'do' statement 'while' parExpression ';' | trystatement | 'switch' parExpression '{' switchBlockStatementGroups '}' | 'synchronized' parExpression block | 'return' ( expression )? ';' | 'throw' expression ';' | 'break' ( IDENTIFIER )? ';' | 'continue' ( IDENTIFIER )? ';' | expression ';' | IDENTIFIER ':' statement | ';' )
    		int alt98=17;
    		try { DebugEnterDecision(98, decisionCanBacktrack[98]);
    		try
    		{
    			alt98 = dfa98.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(98); }
    		switch (alt98)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:844:9: block
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(844, 9);
    			PushFollow(Follow._block_in_statement4288);
    			block280=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block280.Tree, block280, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:846:9: ( 'assert' ) expression ( ':' expression )? ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(846, 9);
    			// Java.g:846:9: ( 'assert' )
    			DebugEnterAlt(1);
    			// Java.g:846:10: 'assert'
    			{
    			DebugLocation(846, 10);
    			string_literal281=(IToken)new XToken((IToken)Match(input,ASSERT,Follow._ASSERT_in_statement4312), "ASSERT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal281_tree = (object)adaptor.Create(string_literal281, retval);
    			adaptor.AddChild(root_0, string_literal281_tree);
    			}

    			}

    			DebugLocation(848, 9);
    			PushFollow(Follow._expression_in_statement4332);
    			expression282=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression282.Tree, expression282, retval);
    			DebugLocation(848, 20);
    			// Java.g:848:20: ( ':' expression )?
    			int alt92=2;
    			try { DebugEnterSubRule(92);
    			try { DebugEnterDecision(92, decisionCanBacktrack[92]);
    			int LA92_0 = input.LA(1);

    			if ((LA92_0==COLON))
    			{
    				alt92=1;
    			}
    			} finally { DebugExitDecision(92); }
    			switch (alt92)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:848:21: ':' expression
    				{
    				DebugLocation(848, 21);
    				char_literal283=(IToken)new XToken((IToken)Match(input,COLON,Follow._COLON_in_statement4335), "COLON"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal283_tree = (object)adaptor.Create(char_literal283, retval);
    				adaptor.AddChild(root_0, char_literal283_tree);
    				}
    				DebugLocation(848, 25);
    				PushFollow(Follow._expression_in_statement4337);
    				expression284=expression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression284.Tree, expression284, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(92); }

    			DebugLocation(848, 38);
    			char_literal285=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4341), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal285_tree = (object)adaptor.Create(char_literal285, retval);
    			adaptor.AddChild(root_0, char_literal285_tree);
    			}

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:849:9: 'assert' expression ( ':' expression )? ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(849, 9);
    			string_literal286=(IToken)new XToken((IToken)Match(input,ASSERT,Follow._ASSERT_in_statement4351), "ASSERT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal286_tree = (object)adaptor.Create(string_literal286, retval);
    			adaptor.AddChild(root_0, string_literal286_tree);
    			}
    			DebugLocation(849, 19);
    			PushFollow(Follow._expression_in_statement4354);
    			expression287=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression287.Tree, expression287, retval);
    			DebugLocation(849, 30);
    			// Java.g:849:30: ( ':' expression )?
    			int alt93=2;
    			try { DebugEnterSubRule(93);
    			try { DebugEnterDecision(93, decisionCanBacktrack[93]);
    			int LA93_0 = input.LA(1);

    			if ((LA93_0==COLON))
    			{
    				alt93=1;
    			}
    			} finally { DebugExitDecision(93); }
    			switch (alt93)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:849:31: ':' expression
    				{
    				DebugLocation(849, 31);
    				char_literal288=(IToken)new XToken((IToken)Match(input,COLON,Follow._COLON_in_statement4357), "COLON"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal288_tree = (object)adaptor.Create(char_literal288, retval);
    				adaptor.AddChild(root_0, char_literal288_tree);
    				}
    				DebugLocation(849, 35);
    				PushFollow(Follow._expression_in_statement4359);
    				expression289=expression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression289.Tree, expression289, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(93); }

    			DebugLocation(849, 48);
    			char_literal290=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4363), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal290_tree = (object)adaptor.Create(char_literal290, retval);
    			adaptor.AddChild(root_0, char_literal290_tree);
    			}

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:850:9: 'if' parExpression statement ( 'else' statement )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(850, 9);
    			string_literal291=(IToken)new XToken((IToken)Match(input,IF,Follow._IF_in_statement4385), "IF"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal291_tree = (object)adaptor.Create(string_literal291, retval);
    			adaptor.AddChild(root_0, string_literal291_tree);
    			}
    			DebugLocation(850, 14);
    			PushFollow(Follow._parExpression_in_statement4387);
    			parExpression292=parExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, parExpression292.Tree, parExpression292, retval);
    			DebugLocation(850, 28);
    			PushFollow(Follow._statement_in_statement4389);
    			statement293=statement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement293.Tree, statement293, retval);
    			DebugLocation(850, 38);
    			// Java.g:850:38: ( 'else' statement )?
    			int alt94=2;
    			try { DebugEnterSubRule(94);
    			try { DebugEnterDecision(94, decisionCanBacktrack[94]);
    			int LA94_0 = input.LA(1);

    			if ((LA94_0==ELSE))
    			{
    				int LA94_1 = input.LA(2);

    				if ((EvaluatePredicate(synpred133_Java_fragment)))
    				{
    					alt94=1;
    				}
    			}
    			} finally { DebugExitDecision(94); }
    			switch (alt94)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:850:39: 'else' statement
    				{
    				DebugLocation(850, 39);
    				string_literal294=(IToken)new XToken((IToken)Match(input,ELSE,Follow._ELSE_in_statement4392), "ELSE"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal294_tree = (object)adaptor.Create(string_literal294, retval);
    				adaptor.AddChild(root_0, string_literal294_tree);
    				}
    				DebugLocation(850, 46);
    				PushFollow(Follow._statement_in_statement4394);
    				statement295=statement();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement295.Tree, statement295, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(94); }


    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:851:9: forstatement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(851, 9);
    			PushFollow(Follow._forstatement_in_statement4416);
    			forstatement296=forstatement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, forstatement296.Tree, forstatement296, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Java.g:852:9: 'while' parExpression statement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(852, 9);
    			string_literal297=(IToken)new XToken((IToken)Match(input,WHILE,Follow._WHILE_in_statement4426), "WHILE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal297_tree = (object)adaptor.Create(string_literal297, retval);
    			adaptor.AddChild(root_0, string_literal297_tree);
    			}
    			DebugLocation(852, 17);
    			PushFollow(Follow._parExpression_in_statement4428);
    			parExpression298=parExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, parExpression298.Tree, parExpression298, retval);
    			DebugLocation(852, 31);
    			PushFollow(Follow._statement_in_statement4430);
    			statement299=statement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement299.Tree, statement299, retval);

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Java.g:853:9: 'do' statement 'while' parExpression ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(853, 9);
    			string_literal300=(IToken)new XToken((IToken)Match(input,DO,Follow._DO_in_statement4440), "DO"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal300_tree = (object)adaptor.Create(string_literal300, retval);
    			adaptor.AddChild(root_0, string_literal300_tree);
    			}
    			DebugLocation(853, 14);
    			PushFollow(Follow._statement_in_statement4442);
    			statement301=statement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement301.Tree, statement301, retval);
    			DebugLocation(853, 24);
    			string_literal302=(IToken)new XToken((IToken)Match(input,WHILE,Follow._WHILE_in_statement4444), "WHILE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal302_tree = (object)adaptor.Create(string_literal302, retval);
    			adaptor.AddChild(root_0, string_literal302_tree);
    			}
    			DebugLocation(853, 32);
    			PushFollow(Follow._parExpression_in_statement4446);
    			parExpression303=parExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, parExpression303.Tree, parExpression303, retval);
    			DebugLocation(853, 46);
    			char_literal304=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4448), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal304_tree = (object)adaptor.Create(char_literal304, retval);
    			adaptor.AddChild(root_0, char_literal304_tree);
    			}

    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// Java.g:854:9: trystatement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(854, 9);
    			PushFollow(Follow._trystatement_in_statement4458);
    			trystatement305=trystatement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, trystatement305.Tree, trystatement305, retval);

    			}
    			break;
    		case 9:
    			DebugEnterAlt(9);
    			// Java.g:855:9: 'switch' parExpression '{' switchBlockStatementGroups '}'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(855, 9);
    			string_literal306=(IToken)new XToken((IToken)Match(input,SWITCH,Follow._SWITCH_in_statement4468), "SWITCH"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal306_tree = (object)adaptor.Create(string_literal306, retval);
    			adaptor.AddChild(root_0, string_literal306_tree);
    			}
    			DebugLocation(855, 18);
    			PushFollow(Follow._parExpression_in_statement4470);
    			parExpression307=parExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, parExpression307.Tree, parExpression307, retval);
    			DebugLocation(855, 32);
    			char_literal308=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_statement4472), "LBRACE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal308_tree = (object)adaptor.Create(char_literal308, retval);
    			adaptor.AddChild(root_0, char_literal308_tree);
    			}
    			DebugLocation(855, 36);
    			PushFollow(Follow._switchBlockStatementGroups_in_statement4474);
    			switchBlockStatementGroups309=switchBlockStatementGroups();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, switchBlockStatementGroups309.Tree, switchBlockStatementGroups309, retval);
    			DebugLocation(855, 63);
    			char_literal310=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_statement4476), "RBRACE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal310_tree = (object)adaptor.Create(char_literal310, retval);
    			adaptor.AddChild(root_0, char_literal310_tree);
    			}

    			}
    			break;
    		case 10:
    			DebugEnterAlt(10);
    			// Java.g:856:9: 'synchronized' parExpression block
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(856, 9);
    			string_literal311=(IToken)new XToken((IToken)Match(input,SYNCHRONIZED,Follow._SYNCHRONIZED_in_statement4486), "SYNCHRONIZED"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal311_tree = (object)adaptor.Create(string_literal311, retval);
    			adaptor.AddChild(root_0, string_literal311_tree);
    			}
    			DebugLocation(856, 24);
    			PushFollow(Follow._parExpression_in_statement4488);
    			parExpression312=parExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, parExpression312.Tree, parExpression312, retval);
    			DebugLocation(856, 38);
    			PushFollow(Follow._block_in_statement4490);
    			block313=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block313.Tree, block313, retval);

    			}
    			break;
    		case 11:
    			DebugEnterAlt(11);
    			// Java.g:857:9: 'return' ( expression )? ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(857, 9);
    			string_literal314=(IToken)new XToken((IToken)Match(input,RETURN,Follow._RETURN_in_statement4500), "RETURN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal314_tree = (object)adaptor.Create(string_literal314, retval);
    			adaptor.AddChild(root_0, string_literal314_tree);
    			}
    			DebugLocation(857, 18);
    			// Java.g:857:18: ( expression )?
    			int alt95=2;
    			try { DebugEnterSubRule(95);
    			try { DebugEnterDecision(95, decisionCanBacktrack[95]);
    			int LA95_0 = input.LA(1);

    			if (((LA95_0>=IDENTIFIER && LA95_0<=NULL)||LA95_0==BOOLEAN||LA95_0==BYTE||LA95_0==CHAR||LA95_0==DOUBLE||LA95_0==FLOAT||LA95_0==INT||LA95_0==LONG||LA95_0==NEW||LA95_0==SHORT||LA95_0==SUPER||LA95_0==THIS||LA95_0==VOID||LA95_0==LPAREN||(LA95_0>=BANG && LA95_0<=TILDE)||(LA95_0>=PLUSPLUS && LA95_0<=SUB)))
    			{
    				alt95=1;
    			}
    			} finally { DebugExitDecision(95); }
    			switch (alt95)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:857:19: expression
    				{
    				DebugLocation(857, 19);
    				PushFollow(Follow._expression_in_statement4503);
    				expression315=expression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression315.Tree, expression315, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(95); }

    			DebugLocation(857, 33);
    			char_literal316=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4508), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal316_tree = (object)adaptor.Create(char_literal316, retval);
    			adaptor.AddChild(root_0, char_literal316_tree);
    			}

    			}
    			break;
    		case 12:
    			DebugEnterAlt(12);
    			// Java.g:858:9: 'throw' expression ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(858, 9);
    			string_literal317=(IToken)new XToken((IToken)Match(input,THROW,Follow._THROW_in_statement4518), "THROW"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal317_tree = (object)adaptor.Create(string_literal317, retval);
    			adaptor.AddChild(root_0, string_literal317_tree);
    			}
    			DebugLocation(858, 17);
    			PushFollow(Follow._expression_in_statement4520);
    			expression318=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression318.Tree, expression318, retval);
    			DebugLocation(858, 28);
    			char_literal319=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4522), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal319_tree = (object)adaptor.Create(char_literal319, retval);
    			adaptor.AddChild(root_0, char_literal319_tree);
    			}

    			}
    			break;
    		case 13:
    			DebugEnterAlt(13);
    			// Java.g:859:9: 'break' ( IDENTIFIER )? ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(859, 9);
    			string_literal320=(IToken)new XToken((IToken)Match(input,BREAK,Follow._BREAK_in_statement4532), "BREAK"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal320_tree = (object)adaptor.Create(string_literal320, retval);
    			adaptor.AddChild(root_0, string_literal320_tree);
    			}
    			DebugLocation(860, 13);
    			// Java.g:860:13: ( IDENTIFIER )?
    			int alt96=2;
    			try { DebugEnterSubRule(96);
    			try { DebugEnterDecision(96, decisionCanBacktrack[96]);
    			int LA96_0 = input.LA(1);

    			if ((LA96_0==IDENTIFIER))
    			{
    				alt96=1;
    			}
    			} finally { DebugExitDecision(96); }
    			switch (alt96)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:860:14: IDENTIFIER
    				{
    				DebugLocation(860, 14);
    				IDENTIFIER321=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_statement4547), "IDENTIFIER"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				IDENTIFIER321_tree = (object)adaptor.Create(IDENTIFIER321, retval);
    				adaptor.AddChild(root_0, IDENTIFIER321_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(96); }

    			DebugLocation(861, 16);
    			char_literal322=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4564), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal322_tree = (object)adaptor.Create(char_literal322, retval);
    			adaptor.AddChild(root_0, char_literal322_tree);
    			}

    			}
    			break;
    		case 14:
    			DebugEnterAlt(14);
    			// Java.g:862:9: 'continue' ( IDENTIFIER )? ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(862, 9);
    			string_literal323=(IToken)new XToken((IToken)Match(input,CONTINUE,Follow._CONTINUE_in_statement4574), "CONTINUE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal323_tree = (object)adaptor.Create(string_literal323, retval);
    			adaptor.AddChild(root_0, string_literal323_tree);
    			}
    			DebugLocation(863, 13);
    			// Java.g:863:13: ( IDENTIFIER )?
    			int alt97=2;
    			try { DebugEnterSubRule(97);
    			try { DebugEnterDecision(97, decisionCanBacktrack[97]);
    			int LA97_0 = input.LA(1);

    			if ((LA97_0==IDENTIFIER))
    			{
    				alt97=1;
    			}
    			} finally { DebugExitDecision(97); }
    			switch (alt97)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:863:14: IDENTIFIER
    				{
    				DebugLocation(863, 14);
    				IDENTIFIER324=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_statement4589), "IDENTIFIER"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				IDENTIFIER324_tree = (object)adaptor.Create(IDENTIFIER324, retval);
    				adaptor.AddChild(root_0, IDENTIFIER324_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(97); }

    			DebugLocation(864, 16);
    			char_literal325=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4606), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal325_tree = (object)adaptor.Create(char_literal325, retval);
    			adaptor.AddChild(root_0, char_literal325_tree);
    			}

    			}
    			break;
    		case 15:
    			DebugEnterAlt(15);
    			// Java.g:865:9: expression ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(865, 9);
    			PushFollow(Follow._expression_in_statement4616);
    			expression326=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression326.Tree, expression326, retval);
    			DebugLocation(865, 21);
    			char_literal327=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4619), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal327_tree = (object)adaptor.Create(char_literal327, retval);
    			adaptor.AddChild(root_0, char_literal327_tree);
    			}

    			}
    			break;
    		case 16:
    			DebugEnterAlt(16);
    			// Java.g:866:9: IDENTIFIER ':' statement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(866, 9);
    			IDENTIFIER328=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_statement4634), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER328_tree = (object)adaptor.Create(IDENTIFIER328, retval);
    			adaptor.AddChild(root_0, IDENTIFIER328_tree);
    			}
    			DebugLocation(866, 20);
    			char_literal329=(IToken)new XToken((IToken)Match(input,COLON,Follow._COLON_in_statement4636), "COLON"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal329_tree = (object)adaptor.Create(char_literal329, retval);
    			adaptor.AddChild(root_0, char_literal329_tree);
    			}
    			DebugLocation(866, 24);
    			PushFollow(Follow._statement_in_statement4638);
    			statement330=statement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement330.Tree, statement330, retval);

    			}
    			break;
    		case 17:
    			DebugEnterAlt(17);
    			// Java.g:867:9: ';'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(867, 9);
    			char_literal331=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_statement4648), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal331_tree = (object)adaptor.Create(char_literal331, retval);
    			adaptor.AddChild(root_0, char_literal331_tree);
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
            if (state.backtracking > 0) { Memoize(input, 58, statement_StartIndex); }
        }
     	DebugLocation(869, 4);
    	} finally { DebugExitRule(GrammarFileName, "statement"); }
    	return retval;

    }
    // $ANTLR end "statement"

    public class switchBlockStatementGroups_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_switchBlockStatementGroups() {}
    protected virtual void Leave_switchBlockStatementGroups() {}

    // $ANTLR start "switchBlockStatementGroups"
    // Java.g:871:1: switchBlockStatementGroups : ( switchBlockStatementGroup )* ;
    [GrammarRule("switchBlockStatementGroups")]
    public JavaParser.switchBlockStatementGroups_return switchBlockStatementGroups()
    {

        JavaParser.switchBlockStatementGroups_return retval = new JavaParser.switchBlockStatementGroups_return();
        retval.Start = (IToken)input.LT(1);
        int switchBlockStatementGroups_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.switchBlockStatementGroup_return switchBlockStatementGroup332 = default(JavaParser.switchBlockStatementGroup_return);


    	try { DebugEnterRule(GrammarFileName, "switchBlockStatementGroups");
    	DebugLocation(871, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 59)) { return retval; }
    		// Java.g:872:5: ( ( switchBlockStatementGroup )* )
    		DebugEnterAlt(1);
    		// Java.g:872:9: ( switchBlockStatementGroup )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(872, 9);
    		// Java.g:872:9: ( switchBlockStatementGroup )*
    		try { DebugEnterSubRule(99);
    		while (true)
    		{
    			int alt99=2;
    			try { DebugEnterDecision(99, decisionCanBacktrack[99]);
    			int LA99_0 = input.LA(1);

    			if ((LA99_0==CASE||LA99_0==DEFAULT))
    			{
    				alt99=1;
    			}


    			} finally { DebugExitDecision(99); }
    			switch ( alt99 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:872:10: switchBlockStatementGroup
    				{
    				DebugLocation(872, 10);
    				PushFollow(Follow._switchBlockStatementGroup_in_switchBlockStatementGroups4670);
    				switchBlockStatementGroup332=switchBlockStatementGroup();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, switchBlockStatementGroup332.Tree, switchBlockStatementGroup332, retval);

    				}
    				break;

    			default:
    				goto loop99;
    			}
    		}

    		loop99:
    			;

    		} finally { DebugExitSubRule(99); }


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
            if (state.backtracking > 0) { Memoize(input, 59, switchBlockStatementGroups_StartIndex); }
        }
     	DebugLocation(873, 4);
    	} finally { DebugExitRule(GrammarFileName, "switchBlockStatementGroups"); }
    	return retval;

    }
    // $ANTLR end "switchBlockStatementGroups"

    public class switchBlockStatementGroup_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_switchBlockStatementGroup() {}
    protected virtual void Leave_switchBlockStatementGroup() {}

    // $ANTLR start "switchBlockStatementGroup"
    // Java.g:875:1: switchBlockStatementGroup : switchLabel ( blockStatement )* ;
    [GrammarRule("switchBlockStatementGroup")]
    public JavaParser.switchBlockStatementGroup_return switchBlockStatementGroup()
    {

        JavaParser.switchBlockStatementGroup_return retval = new JavaParser.switchBlockStatementGroup_return();
        retval.Start = (IToken)input.LT(1);
        int switchBlockStatementGroup_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.switchLabel_return switchLabel333 = default(JavaParser.switchLabel_return);
        JavaParser.blockStatement_return blockStatement334 = default(JavaParser.blockStatement_return);


    	try { DebugEnterRule(GrammarFileName, "switchBlockStatementGroup");
    	DebugLocation(875, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 60)) { return retval; }
    		// Java.g:876:5: ( switchLabel ( blockStatement )* )
    		DebugEnterAlt(1);
    		// Java.g:877:9: switchLabel ( blockStatement )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(877, 9);
    		PushFollow(Follow._switchLabel_in_switchBlockStatementGroup4699);
    		switchLabel333=switchLabel();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, switchLabel333.Tree, switchLabel333, retval);
    		DebugLocation(878, 9);
    		// Java.g:878:9: ( blockStatement )*
    		try { DebugEnterSubRule(100);
    		while (true)
    		{
    			int alt100=2;
    			try { DebugEnterDecision(100, decisionCanBacktrack[100]);
    			int LA100_0 = input.LA(1);

    			if (((LA100_0>=IDENTIFIER && LA100_0<=NULL)||(LA100_0>=ABSTRACT && LA100_0<=BYTE)||(LA100_0>=CHAR && LA100_0<=CLASS)||LA100_0==CONTINUE||(LA100_0>=DO && LA100_0<=DOUBLE)||LA100_0==ENUM||LA100_0==FINAL||(LA100_0>=FLOAT && LA100_0<=FOR)||LA100_0==IF||(LA100_0>=INT && LA100_0<=NEW)||(LA100_0>=PRIVATE && LA100_0<=THROW)||(LA100_0>=TRANSIENT && LA100_0<=LPAREN)||LA100_0==LBRACE||LA100_0==SEMI||(LA100_0>=BANG && LA100_0<=TILDE)||(LA100_0>=PLUSPLUS && LA100_0<=SUB)||LA100_0==MONKEYS_AT||LA100_0==LT))
    			{
    				alt100=1;
    			}


    			} finally { DebugExitDecision(100); }
    			switch ( alt100 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:878:10: blockStatement
    				{
    				DebugLocation(878, 10);
    				PushFollow(Follow._blockStatement_in_switchBlockStatementGroup4710);
    				blockStatement334=blockStatement();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, blockStatement334.Tree, blockStatement334, retval);

    				}
    				break;

    			default:
    				goto loop100;
    			}
    		}

    		loop100:
    			;

    		} finally { DebugExitSubRule(100); }


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
            if (state.backtracking > 0) { Memoize(input, 60, switchBlockStatementGroup_StartIndex); }
        }
     	DebugLocation(880, 4);
    	} finally { DebugExitRule(GrammarFileName, "switchBlockStatementGroup"); }
    	return retval;

    }
    // $ANTLR end "switchBlockStatementGroup"

    public class switchLabel_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_switchLabel() {}
    protected virtual void Leave_switchLabel() {}

    // $ANTLR start "switchLabel"
    // Java.g:882:1: switchLabel : ( 'case' expression ':' | 'default' ':' );
    [GrammarRule("switchLabel")]
    public JavaParser.switchLabel_return switchLabel()
    {

        JavaParser.switchLabel_return retval = new JavaParser.switchLabel_return();
        retval.Start = (IToken)input.LT(1);
        int switchLabel_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal335=null;
        IToken char_literal337=null;
        IToken string_literal338=null;
        IToken char_literal339=null;
        JavaParser.expression_return expression336 = default(JavaParser.expression_return);

        object string_literal335_tree=null;
        object char_literal337_tree=null;
        object string_literal338_tree=null;
        object char_literal339_tree=null;

    	try { DebugEnterRule(GrammarFileName, "switchLabel");
    	DebugLocation(882, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 61)) { return retval; }
    		// Java.g:883:5: ( 'case' expression ':' | 'default' ':' )
    		int alt101=2;
    		try { DebugEnterDecision(101, decisionCanBacktrack[101]);
    		int LA101_0 = input.LA(1);

    		if ((LA101_0==CASE))
    		{
    			alt101=1;
    		}
    		else if ((LA101_0==DEFAULT))
    		{
    			alt101=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 101, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(101); }
    		switch (alt101)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:883:9: 'case' expression ':'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(883, 9);
    			string_literal335=(IToken)new XToken((IToken)Match(input,CASE,Follow._CASE_in_switchLabel4741), "CASE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal335_tree = (object)adaptor.Create(string_literal335, retval);
    			adaptor.AddChild(root_0, string_literal335_tree);
    			}
    			DebugLocation(883, 16);
    			PushFollow(Follow._expression_in_switchLabel4743);
    			expression336=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression336.Tree, expression336, retval);
    			DebugLocation(883, 27);
    			char_literal337=(IToken)new XToken((IToken)Match(input,COLON,Follow._COLON_in_switchLabel4745), "COLON"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal337_tree = (object)adaptor.Create(char_literal337, retval);
    			adaptor.AddChild(root_0, char_literal337_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:884:9: 'default' ':'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(884, 9);
    			string_literal338=(IToken)new XToken((IToken)Match(input,DEFAULT,Follow._DEFAULT_in_switchLabel4755), "DEFAULT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal338_tree = (object)adaptor.Create(string_literal338, retval);
    			adaptor.AddChild(root_0, string_literal338_tree);
    			}
    			DebugLocation(884, 19);
    			char_literal339=(IToken)new XToken((IToken)Match(input,COLON,Follow._COLON_in_switchLabel4757), "COLON"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal339_tree = (object)adaptor.Create(char_literal339, retval);
    			adaptor.AddChild(root_0, char_literal339_tree);
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
            if (state.backtracking > 0) { Memoize(input, 61, switchLabel_StartIndex); }
        }
     	DebugLocation(885, 4);
    	} finally { DebugExitRule(GrammarFileName, "switchLabel"); }
    	return retval;

    }
    // $ANTLR end "switchLabel"

    public class trystatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_trystatement() {}
    protected virtual void Leave_trystatement() {}

    // $ANTLR start "trystatement"
    // Java.g:888:1: trystatement : 'try' block ( catches 'finally' block | catches | 'finally' block ) ;
    [GrammarRule("trystatement")]
    public JavaParser.trystatement_return trystatement()
    {

        JavaParser.trystatement_return retval = new JavaParser.trystatement_return();
        retval.Start = (IToken)input.LT(1);
        int trystatement_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal340=null;
        IToken string_literal343=null;
        IToken string_literal346=null;
        JavaParser.block_return block341 = default(JavaParser.block_return);
        JavaParser.catches_return catches342 = default(JavaParser.catches_return);
        JavaParser.block_return block344 = default(JavaParser.block_return);
        JavaParser.catches_return catches345 = default(JavaParser.catches_return);
        JavaParser.block_return block347 = default(JavaParser.block_return);

        object string_literal340_tree=null;
        object string_literal343_tree=null;
        object string_literal346_tree=null;

    	try { DebugEnterRule(GrammarFileName, "trystatement");
    	DebugLocation(888, 5);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 62)) { return retval; }
    		// Java.g:889:5: ( 'try' block ( catches 'finally' block | catches | 'finally' block ) )
    		DebugEnterAlt(1);
    		// Java.g:889:9: 'try' block ( catches 'finally' block | catches | 'finally' block )
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(889, 9);
    		string_literal340=(IToken)new XToken((IToken)Match(input,TRY,Follow._TRY_in_trystatement4778), "TRY"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal340_tree = (object)adaptor.Create(string_literal340, retval);
    		adaptor.AddChild(root_0, string_literal340_tree);
    		}
    		DebugLocation(889, 15);
    		PushFollow(Follow._block_in_trystatement4780);
    		block341=block();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block341.Tree, block341, retval);
    		DebugLocation(890, 9);
    		// Java.g:890:9: ( catches 'finally' block | catches | 'finally' block )
    		int alt102=3;
    		try { DebugEnterSubRule(102);
    		try { DebugEnterDecision(102, decisionCanBacktrack[102]);
    		int LA102_0 = input.LA(1);

    		if ((LA102_0==CATCH))
    		{
    			int LA102_1 = input.LA(2);

    			if ((EvaluatePredicate(synpred153_Java_fragment)))
    			{
    				alt102=1;
    			}
    			else if ((EvaluatePredicate(synpred154_Java_fragment)))
    			{
    				alt102=2;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 102, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else if ((LA102_0==FINALLY))
    		{
    			alt102=3;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 102, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(102); }
    		switch (alt102)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:890:13: catches 'finally' block
    			{
    			DebugLocation(890, 13);
    			PushFollow(Follow._catches_in_trystatement4794);
    			catches342=catches();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, catches342.Tree, catches342, retval);
    			DebugLocation(890, 21);
    			string_literal343=(IToken)new XToken((IToken)Match(input,FINALLY,Follow._FINALLY_in_trystatement4796), "FINALLY"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal343_tree = (object)adaptor.Create(string_literal343, retval);
    			adaptor.AddChild(root_0, string_literal343_tree);
    			}
    			DebugLocation(890, 31);
    			PushFollow(Follow._block_in_trystatement4798);
    			block344=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block344.Tree, block344, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:891:13: catches
    			{
    			DebugLocation(891, 13);
    			PushFollow(Follow._catches_in_trystatement4812);
    			catches345=catches();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, catches345.Tree, catches345, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:892:13: 'finally' block
    			{
    			DebugLocation(892, 13);
    			string_literal346=(IToken)new XToken((IToken)Match(input,FINALLY,Follow._FINALLY_in_trystatement4826), "FINALLY"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal346_tree = (object)adaptor.Create(string_literal346, retval);
    			adaptor.AddChild(root_0, string_literal346_tree);
    			}
    			DebugLocation(892, 23);
    			PushFollow(Follow._block_in_trystatement4828);
    			block347=block();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block347.Tree, block347, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(102); }


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
            if (state.backtracking > 0) { Memoize(input, 62, trystatement_StartIndex); }
        }
     	DebugLocation(894, 5);
    	} finally { DebugExitRule(GrammarFileName, "trystatement"); }
    	return retval;

    }
    // $ANTLR end "trystatement"

    public class catches_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_catches() {}
    protected virtual void Leave_catches() {}

    // $ANTLR start "catches"
    // Java.g:896:1: catches : catchClause ( catchClause )* ;
    [GrammarRule("catches")]
    public JavaParser.catches_return catches()
    {

        JavaParser.catches_return retval = new JavaParser.catches_return();
        retval.Start = (IToken)input.LT(1);
        int catches_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.catchClause_return catchClause348 = default(JavaParser.catchClause_return);
        JavaParser.catchClause_return catchClause349 = default(JavaParser.catchClause_return);


    	try { DebugEnterRule(GrammarFileName, "catches");
    	DebugLocation(896, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 63)) { return retval; }
    		// Java.g:897:5: ( catchClause ( catchClause )* )
    		DebugEnterAlt(1);
    		// Java.g:897:9: catchClause ( catchClause )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(897, 9);
    		PushFollow(Follow._catchClause_in_catches4859);
    		catchClause348=catchClause();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, catchClause348.Tree, catchClause348, retval);
    		DebugLocation(898, 9);
    		// Java.g:898:9: ( catchClause )*
    		try { DebugEnterSubRule(103);
    		while (true)
    		{
    			int alt103=2;
    			try { DebugEnterDecision(103, decisionCanBacktrack[103]);
    			int LA103_0 = input.LA(1);

    			if ((LA103_0==CATCH))
    			{
    				alt103=1;
    			}


    			} finally { DebugExitDecision(103); }
    			switch ( alt103 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:898:10: catchClause
    				{
    				DebugLocation(898, 10);
    				PushFollow(Follow._catchClause_in_catches4870);
    				catchClause349=catchClause();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, catchClause349.Tree, catchClause349, retval);

    				}
    				break;

    			default:
    				goto loop103;
    			}
    		}

    		loop103:
    			;

    		} finally { DebugExitSubRule(103); }


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
            if (state.backtracking > 0) { Memoize(input, 63, catches_StartIndex); }
        }
     	DebugLocation(900, 4);
    	} finally { DebugExitRule(GrammarFileName, "catches"); }
    	return retval;

    }
    // $ANTLR end "catches"

    public class catchClause_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_catchClause() {}
    protected virtual void Leave_catchClause() {}

    // $ANTLR start "catchClause"
    // Java.g:902:1: catchClause : 'catch' '(' formalParameter ')' block ;
    [GrammarRule("catchClause")]
    public JavaParser.catchClause_return catchClause()
    {

        JavaParser.catchClause_return retval = new JavaParser.catchClause_return();
        retval.Start = (IToken)input.LT(1);
        int catchClause_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal350=null;
        IToken char_literal351=null;
        IToken char_literal353=null;
        JavaParser.formalParameter_return formalParameter352 = default(JavaParser.formalParameter_return);
        JavaParser.block_return block354 = default(JavaParser.block_return);

        object string_literal350_tree=null;
        object char_literal351_tree=null;
        object char_literal353_tree=null;

    	try { DebugEnterRule(GrammarFileName, "catchClause");
    	DebugLocation(902, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 64)) { return retval; }
    		// Java.g:903:5: ( 'catch' '(' formalParameter ')' block )
    		DebugEnterAlt(1);
    		// Java.g:903:9: 'catch' '(' formalParameter ')' block
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(903, 9);
    		string_literal350=(IToken)new XToken((IToken)Match(input,CATCH,Follow._CATCH_in_catchClause4901), "CATCH"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal350_tree = (object)adaptor.Create(string_literal350, retval);
    		adaptor.AddChild(root_0, string_literal350_tree);
    		}
    		DebugLocation(903, 17);
    		char_literal351=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_catchClause4903), "LPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal351_tree = (object)adaptor.Create(char_literal351, retval);
    		adaptor.AddChild(root_0, char_literal351_tree);
    		}
    		DebugLocation(903, 21);
    		PushFollow(Follow._formalParameter_in_catchClause4905);
    		formalParameter352=formalParameter();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, formalParameter352.Tree, formalParameter352, retval);
    		DebugLocation(904, 9);
    		char_literal353=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_catchClause4915), "RPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal353_tree = (object)adaptor.Create(char_literal353, retval);
    		adaptor.AddChild(root_0, char_literal353_tree);
    		}
    		DebugLocation(904, 13);
    		PushFollow(Follow._block_in_catchClause4917);
    		block354=block();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, block354.Tree, block354, retval);

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
            if (state.backtracking > 0) { Memoize(input, 64, catchClause_StartIndex); }
        }
     	DebugLocation(905, 4);
    	} finally { DebugExitRule(GrammarFileName, "catchClause"); }
    	return retval;

    }
    // $ANTLR end "catchClause"

    public class formalParameter_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_formalParameter() {}
    protected virtual void Leave_formalParameter() {}

    // $ANTLR start "formalParameter"
    // Java.g:907:1: formalParameter : variableModifiers type IDENTIFIER ( '[' ']' )* ;
    [GrammarRule("formalParameter")]
    public JavaParser.formalParameter_return formalParameter()
    {

        JavaParser.formalParameter_return retval = new JavaParser.formalParameter_return();
        retval.Start = (IToken)input.LT(1);
        int formalParameter_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER357=null;
        IToken char_literal358=null;
        IToken char_literal359=null;
        JavaParser.variableModifiers_return variableModifiers355 = default(JavaParser.variableModifiers_return);
        JavaParser.type_return type356 = default(JavaParser.type_return);

        object IDENTIFIER357_tree=null;
        object char_literal358_tree=null;
        object char_literal359_tree=null;

    	try { DebugEnterRule(GrammarFileName, "formalParameter");
    	DebugLocation(907, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 65)) { return retval; }
    		// Java.g:908:5: ( variableModifiers type IDENTIFIER ( '[' ']' )* )
    		DebugEnterAlt(1);
    		// Java.g:908:9: variableModifiers type IDENTIFIER ( '[' ']' )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(908, 9);
    		PushFollow(Follow._variableModifiers_in_formalParameter4938);
    		variableModifiers355=variableModifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableModifiers355.Tree, variableModifiers355, retval);
    		DebugLocation(908, 27);
    		PushFollow(Follow._type_in_formalParameter4940);
    		type356=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type356.Tree, type356, retval);
    		DebugLocation(908, 32);
    		IDENTIFIER357=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_formalParameter4942), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER357_tree = (object)adaptor.Create(IDENTIFIER357, retval);
    		adaptor.AddChild(root_0, IDENTIFIER357_tree);
    		}
    		DebugLocation(909, 9);
    		// Java.g:909:9: ( '[' ']' )*
    		try { DebugEnterSubRule(104);
    		while (true)
    		{
    			int alt104=2;
    			try { DebugEnterDecision(104, decisionCanBacktrack[104]);
    			int LA104_0 = input.LA(1);

    			if ((LA104_0==LBRACKET))
    			{
    				alt104=1;
    			}


    			} finally { DebugExitDecision(104); }
    			switch ( alt104 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:909:10: '[' ']'
    				{
    				DebugLocation(909, 10);
    				char_literal358=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_formalParameter4953), "LBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal358_tree = (object)adaptor.Create(char_literal358, retval);
    				adaptor.AddChild(root_0, char_literal358_tree);
    				}
    				DebugLocation(909, 14);
    				char_literal359=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_formalParameter4955), "RBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal359_tree = (object)adaptor.Create(char_literal359, retval);
    				adaptor.AddChild(root_0, char_literal359_tree);
    				}

    				}
    				break;

    			default:
    				goto loop104;
    			}
    		}

    		loop104:
    			;

    		} finally { DebugExitSubRule(104); }


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
            if (state.backtracking > 0) { Memoize(input, 65, formalParameter_StartIndex); }
        }
     	DebugLocation(911, 4);
    	} finally { DebugExitRule(GrammarFileName, "formalParameter"); }
    	return retval;

    }
    // $ANTLR end "formalParameter"

    public class forstatement_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_forstatement() {}
    protected virtual void Leave_forstatement() {}

    // $ANTLR start "forstatement"
    // Java.g:913:1: forstatement : ( 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement | 'for' '(' ( forInit )? ';' ( expression )? ';' ( expressionList )? ')' statement );
    [GrammarRule("forstatement")]
    public JavaParser.forstatement_return forstatement()
    {

        JavaParser.forstatement_return retval = new JavaParser.forstatement_return();
        retval.Start = (IToken)input.LT(1);
        int forstatement_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal360=null;
        IToken char_literal361=null;
        IToken IDENTIFIER364=null;
        IToken char_literal365=null;
        IToken char_literal367=null;
        IToken string_literal369=null;
        IToken char_literal370=null;
        IToken char_literal372=null;
        IToken char_literal374=null;
        IToken char_literal376=null;
        JavaParser.variableModifiers_return variableModifiers362 = default(JavaParser.variableModifiers_return);
        JavaParser.type_return type363 = default(JavaParser.type_return);
        JavaParser.expression_return expression366 = default(JavaParser.expression_return);
        JavaParser.statement_return statement368 = default(JavaParser.statement_return);
        JavaParser.forInit_return forInit371 = default(JavaParser.forInit_return);
        JavaParser.expression_return expression373 = default(JavaParser.expression_return);
        JavaParser.expressionList_return expressionList375 = default(JavaParser.expressionList_return);
        JavaParser.statement_return statement377 = default(JavaParser.statement_return);

        object string_literal360_tree=null;
        object char_literal361_tree=null;
        object IDENTIFIER364_tree=null;
        object char_literal365_tree=null;
        object char_literal367_tree=null;
        object string_literal369_tree=null;
        object char_literal370_tree=null;
        object char_literal372_tree=null;
        object char_literal374_tree=null;
        object char_literal376_tree=null;

    	try { DebugEnterRule(GrammarFileName, "forstatement");
    	DebugLocation(913, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 66)) { return retval; }
    		// Java.g:914:5: ( 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement | 'for' '(' ( forInit )? ';' ( expression )? ';' ( expressionList )? ')' statement )
    		int alt108=2;
    		try { DebugEnterDecision(108, decisionCanBacktrack[108]);
    		int LA108_0 = input.LA(1);

    		if ((LA108_0==FOR))
    		{
    			int LA108_1 = input.LA(2);

    			if ((EvaluatePredicate(synpred157_Java_fragment)))
    			{
    				alt108=1;
    			}
    			else if ((true))
    			{
    				alt108=2;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 108, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 108, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(108); }
    		switch (alt108)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:916:9: 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(916, 9);
    			string_literal360=(IToken)new XToken((IToken)Match(input,FOR,Follow._FOR_in_forstatement5004), "FOR"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal360_tree = (object)adaptor.Create(string_literal360, retval);
    			adaptor.AddChild(root_0, string_literal360_tree);
    			}
    			DebugLocation(916, 15);
    			char_literal361=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_forstatement5006), "LPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal361_tree = (object)adaptor.Create(char_literal361, retval);
    			adaptor.AddChild(root_0, char_literal361_tree);
    			}
    			DebugLocation(916, 19);
    			PushFollow(Follow._variableModifiers_in_forstatement5008);
    			variableModifiers362=variableModifiers();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableModifiers362.Tree, variableModifiers362, retval);
    			DebugLocation(916, 37);
    			PushFollow(Follow._type_in_forstatement5010);
    			type363=type();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type363.Tree, type363, retval);
    			DebugLocation(916, 42);
    			IDENTIFIER364=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_forstatement5012), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER364_tree = (object)adaptor.Create(IDENTIFIER364, retval);
    			adaptor.AddChild(root_0, IDENTIFIER364_tree);
    			}
    			DebugLocation(916, 53);
    			char_literal365=(IToken)new XToken((IToken)Match(input,COLON,Follow._COLON_in_forstatement5014), "COLON"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal365_tree = (object)adaptor.Create(char_literal365, retval);
    			adaptor.AddChild(root_0, char_literal365_tree);
    			}
    			DebugLocation(917, 9);
    			PushFollow(Follow._expression_in_forstatement5025);
    			expression366=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression366.Tree, expression366, retval);
    			DebugLocation(917, 20);
    			char_literal367=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_forstatement5027), "RPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal367_tree = (object)adaptor.Create(char_literal367, retval);
    			adaptor.AddChild(root_0, char_literal367_tree);
    			}
    			DebugLocation(917, 24);
    			PushFollow(Follow._statement_in_forstatement5029);
    			statement368=statement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement368.Tree, statement368, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:920:9: 'for' '(' ( forInit )? ';' ( expression )? ';' ( expressionList )? ')' statement
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(920, 9);
    			string_literal369=(IToken)new XToken((IToken)Match(input,FOR,Follow._FOR_in_forstatement5061), "FOR"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal369_tree = (object)adaptor.Create(string_literal369, retval);
    			adaptor.AddChild(root_0, string_literal369_tree);
    			}
    			DebugLocation(920, 15);
    			char_literal370=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_forstatement5063), "LPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal370_tree = (object)adaptor.Create(char_literal370, retval);
    			adaptor.AddChild(root_0, char_literal370_tree);
    			}
    			DebugLocation(921, 17);
    			// Java.g:921:17: ( forInit )?
    			int alt105=2;
    			try { DebugEnterSubRule(105);
    			try { DebugEnterDecision(105, decisionCanBacktrack[105]);
    			int LA105_0 = input.LA(1);

    			if (((LA105_0>=IDENTIFIER && LA105_0<=NULL)||LA105_0==BOOLEAN||LA105_0==BYTE||LA105_0==CHAR||LA105_0==DOUBLE||LA105_0==FINAL||LA105_0==FLOAT||LA105_0==INT||LA105_0==LONG||LA105_0==NEW||LA105_0==SHORT||LA105_0==SUPER||LA105_0==THIS||LA105_0==VOID||LA105_0==LPAREN||(LA105_0>=BANG && LA105_0<=TILDE)||(LA105_0>=PLUSPLUS && LA105_0<=SUB)||LA105_0==MONKEYS_AT))
    			{
    				alt105=1;
    			}
    			} finally { DebugExitDecision(105); }
    			switch (alt105)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:921:18: forInit
    				{
    				DebugLocation(921, 18);
    				PushFollow(Follow._forInit_in_forstatement5083);
    				forInit371=forInit();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, forInit371.Tree, forInit371, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(105); }

    			DebugLocation(922, 20);
    			char_literal372=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_forstatement5104), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal372_tree = (object)adaptor.Create(char_literal372, retval);
    			adaptor.AddChild(root_0, char_literal372_tree);
    			}
    			DebugLocation(923, 17);
    			// Java.g:923:17: ( expression )?
    			int alt106=2;
    			try { DebugEnterSubRule(106);
    			try { DebugEnterDecision(106, decisionCanBacktrack[106]);
    			int LA106_0 = input.LA(1);

    			if (((LA106_0>=IDENTIFIER && LA106_0<=NULL)||LA106_0==BOOLEAN||LA106_0==BYTE||LA106_0==CHAR||LA106_0==DOUBLE||LA106_0==FLOAT||LA106_0==INT||LA106_0==LONG||LA106_0==NEW||LA106_0==SHORT||LA106_0==SUPER||LA106_0==THIS||LA106_0==VOID||LA106_0==LPAREN||(LA106_0>=BANG && LA106_0<=TILDE)||(LA106_0>=PLUSPLUS && LA106_0<=SUB)))
    			{
    				alt106=1;
    			}
    			} finally { DebugExitDecision(106); }
    			switch (alt106)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:923:18: expression
    				{
    				DebugLocation(923, 18);
    				PushFollow(Follow._expression_in_forstatement5124);
    				expression373=expression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression373.Tree, expression373, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(106); }

    			DebugLocation(924, 20);
    			char_literal374=(IToken)new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_forstatement5145), "SEMI"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal374_tree = (object)adaptor.Create(char_literal374, retval);
    			adaptor.AddChild(root_0, char_literal374_tree);
    			}
    			DebugLocation(925, 17);
    			// Java.g:925:17: ( expressionList )?
    			int alt107=2;
    			try { DebugEnterSubRule(107);
    			try { DebugEnterDecision(107, decisionCanBacktrack[107]);
    			int LA107_0 = input.LA(1);

    			if (((LA107_0>=IDENTIFIER && LA107_0<=NULL)||LA107_0==BOOLEAN||LA107_0==BYTE||LA107_0==CHAR||LA107_0==DOUBLE||LA107_0==FLOAT||LA107_0==INT||LA107_0==LONG||LA107_0==NEW||LA107_0==SHORT||LA107_0==SUPER||LA107_0==THIS||LA107_0==VOID||LA107_0==LPAREN||(LA107_0>=BANG && LA107_0<=TILDE)||(LA107_0>=PLUSPLUS && LA107_0<=SUB)))
    			{
    				alt107=1;
    			}
    			} finally { DebugExitDecision(107); }
    			switch (alt107)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:925:18: expressionList
    				{
    				DebugLocation(925, 18);
    				PushFollow(Follow._expressionList_in_forstatement5165);
    				expressionList375=expressionList();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expressionList375.Tree, expressionList375, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(107); }

    			DebugLocation(926, 20);
    			char_literal376=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_forstatement5186), "RPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal376_tree = (object)adaptor.Create(char_literal376, retval);
    			adaptor.AddChild(root_0, char_literal376_tree);
    			}
    			DebugLocation(926, 24);
    			PushFollow(Follow._statement_in_forstatement5188);
    			statement377=statement();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, statement377.Tree, statement377, retval);

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
            if (state.backtracking > 0) { Memoize(input, 66, forstatement_StartIndex); }
        }
     	DebugLocation(927, 4);
    	} finally { DebugExitRule(GrammarFileName, "forstatement"); }
    	return retval;

    }
    // $ANTLR end "forstatement"

    public class forInit_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_forInit() {}
    protected virtual void Leave_forInit() {}

    // $ANTLR start "forInit"
    // Java.g:929:1: forInit : ( localVariableDeclaration | expressionList );
    [GrammarRule("forInit")]
    public JavaParser.forInit_return forInit()
    {

        JavaParser.forInit_return retval = new JavaParser.forInit_return();
        retval.Start = (IToken)input.LT(1);
        int forInit_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.localVariableDeclaration_return localVariableDeclaration378 = default(JavaParser.localVariableDeclaration_return);
        JavaParser.expressionList_return expressionList379 = default(JavaParser.expressionList_return);


    	try { DebugEnterRule(GrammarFileName, "forInit");
    	DebugLocation(929, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 67)) { return retval; }
    		// Java.g:930:5: ( localVariableDeclaration | expressionList )
    		int alt109=2;
    		try { DebugEnterDecision(109, decisionCanBacktrack[109]);
    		try
    		{
    			alt109 = dfa109.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(109); }
    		switch (alt109)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:930:9: localVariableDeclaration
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(930, 9);
    			PushFollow(Follow._localVariableDeclaration_in_forInit5208);
    			localVariableDeclaration378=localVariableDeclaration();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, localVariableDeclaration378.Tree, localVariableDeclaration378, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:931:9: expressionList
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(931, 9);
    			PushFollow(Follow._expressionList_in_forInit5218);
    			expressionList379=expressionList();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expressionList379.Tree, expressionList379, retval);

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
            if (state.backtracking > 0) { Memoize(input, 67, forInit_StartIndex); }
        }
     	DebugLocation(932, 4);
    	} finally { DebugExitRule(GrammarFileName, "forInit"); }
    	return retval;

    }
    // $ANTLR end "forInit"

    public class parExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_parExpression() {}
    protected virtual void Leave_parExpression() {}

    // $ANTLR start "parExpression"
    // Java.g:934:1: parExpression : '(' expression ')' ;
    [GrammarRule("parExpression")]
    public JavaParser.parExpression_return parExpression()
    {

        JavaParser.parExpression_return retval = new JavaParser.parExpression_return();
        retval.Start = (IToken)input.LT(1);
        int parExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal380=null;
        IToken char_literal382=null;
        JavaParser.expression_return expression381 = default(JavaParser.expression_return);

        object char_literal380_tree=null;
        object char_literal382_tree=null;

    	try { DebugEnterRule(GrammarFileName, "parExpression");
    	DebugLocation(934, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 68)) { return retval; }
    		// Java.g:935:5: ( '(' expression ')' )
    		DebugEnterAlt(1);
    		// Java.g:935:9: '(' expression ')'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(935, 9);
    		char_literal380=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_parExpression5238), "LPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal380_tree = (object)adaptor.Create(char_literal380, retval);
    		adaptor.AddChild(root_0, char_literal380_tree);
    		}
    		DebugLocation(935, 13);
    		PushFollow(Follow._expression_in_parExpression5240);
    		expression381=expression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression381.Tree, expression381, retval);
    		DebugLocation(935, 24);
    		char_literal382=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_parExpression5242), "RPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal382_tree = (object)adaptor.Create(char_literal382, retval);
    		adaptor.AddChild(root_0, char_literal382_tree);
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
            if (state.backtracking > 0) { Memoize(input, 68, parExpression_StartIndex); }
        }
     	DebugLocation(936, 4);
    	} finally { DebugExitRule(GrammarFileName, "parExpression"); }
    	return retval;

    }
    // $ANTLR end "parExpression"

    public class expressionList_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_expressionList() {}
    protected virtual void Leave_expressionList() {}

    // $ANTLR start "expressionList"
    // Java.g:938:1: expressionList : expression ( ',' expression )* ;
    [GrammarRule("expressionList")]
    public JavaParser.expressionList_return expressionList()
    {

        JavaParser.expressionList_return retval = new JavaParser.expressionList_return();
        retval.Start = (IToken)input.LT(1);
        int expressionList_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal384=null;
        JavaParser.expression_return expression383 = default(JavaParser.expression_return);
        JavaParser.expression_return expression385 = default(JavaParser.expression_return);

        object char_literal384_tree=null;

    	try { DebugEnterRule(GrammarFileName, "expressionList");
    	DebugLocation(938, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 69)) { return retval; }
    		// Java.g:939:5: ( expression ( ',' expression )* )
    		DebugEnterAlt(1);
    		// Java.g:939:9: expression ( ',' expression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(939, 9);
    		PushFollow(Follow._expression_in_expressionList5262);
    		expression383=expression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression383.Tree, expression383, retval);
    		DebugLocation(940, 9);
    		// Java.g:940:9: ( ',' expression )*
    		try { DebugEnterSubRule(110);
    		while (true)
    		{
    			int alt110=2;
    			try { DebugEnterDecision(110, decisionCanBacktrack[110]);
    			int LA110_0 = input.LA(1);

    			if ((LA110_0==COMMA))
    			{
    				alt110=1;
    			}


    			} finally { DebugExitDecision(110); }
    			switch ( alt110 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:940:10: ',' expression
    				{
    				DebugLocation(940, 10);
    				char_literal384=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_expressionList5273), "COMMA"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal384_tree = (object)adaptor.Create(char_literal384, retval);
    				adaptor.AddChild(root_0, char_literal384_tree);
    				}
    				DebugLocation(940, 14);
    				PushFollow(Follow._expression_in_expressionList5275);
    				expression385=expression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression385.Tree, expression385, retval);

    				}
    				break;

    			default:
    				goto loop110;
    			}
    		}

    		loop110:
    			;

    		} finally { DebugExitSubRule(110); }


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
            if (state.backtracking > 0) { Memoize(input, 69, expressionList_StartIndex); }
        }
     	DebugLocation(942, 4);
    	} finally { DebugExitRule(GrammarFileName, "expressionList"); }
    	return retval;

    }
    // $ANTLR end "expressionList"

    public class expression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_expression() {}
    protected virtual void Leave_expression() {}

    // $ANTLR start "expression"
    // Java.g:945:1: expression : conditionalExpression ( assignmentOperator expression )? ;
    [GrammarRule("expression")]
    public JavaParser.expression_return expression()
    {

        JavaParser.expression_return retval = new JavaParser.expression_return();
        retval.Start = (IToken)input.LT(1);
        int expression_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.conditionalExpression_return conditionalExpression386 = default(JavaParser.conditionalExpression_return);
        JavaParser.assignmentOperator_return assignmentOperator387 = default(JavaParser.assignmentOperator_return);
        JavaParser.expression_return expression388 = default(JavaParser.expression_return);


    	try { DebugEnterRule(GrammarFileName, "expression");
    	DebugLocation(945, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 70)) { return retval; }
    		// Java.g:946:5: ( conditionalExpression ( assignmentOperator expression )? )
    		DebugEnterAlt(1);
    		// Java.g:946:9: conditionalExpression ( assignmentOperator expression )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(946, 9);
    		PushFollow(Follow._conditionalExpression_in_expression5307);
    		conditionalExpression386=conditionalExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, conditionalExpression386.Tree, conditionalExpression386, retval);
    		DebugLocation(947, 9);
    		// Java.g:947:9: ( assignmentOperator expression )?
    		int alt111=2;
    		try { DebugEnterSubRule(111);
    		try { DebugEnterDecision(111, decisionCanBacktrack[111]);
    		int LA111_0 = input.LA(1);

    		if ((LA111_0==EQ||(LA111_0>=PLUSEQ && LA111_0<=PERCENTEQ)||(LA111_0>=GT && LA111_0<=LT)))
    		{
    			alt111=1;
    		}
    		} finally { DebugExitDecision(111); }
    		switch (alt111)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:947:10: assignmentOperator expression
    			{
    			DebugLocation(947, 10);
    			PushFollow(Follow._assignmentOperator_in_expression5318);
    			assignmentOperator387=assignmentOperator();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, assignmentOperator387.Tree, assignmentOperator387, retval);
    			DebugLocation(947, 29);
    			PushFollow(Follow._expression_in_expression5320);
    			expression388=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression388.Tree, expression388, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(111); }


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
            if (state.backtracking > 0) { Memoize(input, 70, expression_StartIndex); }
        }
     	DebugLocation(949, 4);
    	} finally { DebugExitRule(GrammarFileName, "expression"); }
    	return retval;

    }
    // $ANTLR end "expression"

    public class assignmentOperator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_assignmentOperator() {}
    protected virtual void Leave_assignmentOperator() {}

    // $ANTLR start "assignmentOperator"
    // Java.g:952:1: assignmentOperator : ( '=' | '+=' | '-=' | '*=' | '/=' | '&=' | '|=' | '^=' | '%=' | '<' '<' '=' | '>' '>' '>' '=' | '>' '>' '=' );
    [GrammarRule("assignmentOperator")]
    public JavaParser.assignmentOperator_return assignmentOperator()
    {

        JavaParser.assignmentOperator_return retval = new JavaParser.assignmentOperator_return();
        retval.Start = (IToken)input.LT(1);
        int assignmentOperator_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal389=null;
        IToken string_literal390=null;
        IToken string_literal391=null;
        IToken string_literal392=null;
        IToken string_literal393=null;
        IToken string_literal394=null;
        IToken string_literal395=null;
        IToken string_literal396=null;
        IToken string_literal397=null;
        IToken char_literal398=null;
        IToken char_literal399=null;
        IToken char_literal400=null;
        IToken char_literal401=null;
        IToken char_literal402=null;
        IToken char_literal403=null;
        IToken char_literal404=null;
        IToken char_literal405=null;
        IToken char_literal406=null;
        IToken char_literal407=null;

        object char_literal389_tree=null;
        object string_literal390_tree=null;
        object string_literal391_tree=null;
        object string_literal392_tree=null;
        object string_literal393_tree=null;
        object string_literal394_tree=null;
        object string_literal395_tree=null;
        object string_literal396_tree=null;
        object string_literal397_tree=null;
        object char_literal398_tree=null;
        object char_literal399_tree=null;
        object char_literal400_tree=null;
        object char_literal401_tree=null;
        object char_literal402_tree=null;
        object char_literal403_tree=null;
        object char_literal404_tree=null;
        object char_literal405_tree=null;
        object char_literal406_tree=null;
        object char_literal407_tree=null;

    	try { DebugEnterRule(GrammarFileName, "assignmentOperator");
    	DebugLocation(952, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 71)) { return retval; }
    		// Java.g:953:5: ( '=' | '+=' | '-=' | '*=' | '/=' | '&=' | '|=' | '^=' | '%=' | '<' '<' '=' | '>' '>' '>' '=' | '>' '>' '=' )
    		int alt112=12;
    		try { DebugEnterDecision(112, decisionCanBacktrack[112]);
    		try
    		{
    			alt112 = dfa112.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(112); }
    		switch (alt112)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:953:9: '='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(953, 9);
    			char_literal389=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_assignmentOperator5352), "EQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal389_tree = (object)adaptor.Create(char_literal389, retval);
    			adaptor.AddChild(root_0, char_literal389_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:954:9: '+='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(954, 9);
    			string_literal390=(IToken)new XToken((IToken)Match(input,PLUSEQ,Follow._PLUSEQ_in_assignmentOperator5362), "PLUSEQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal390_tree = (object)adaptor.Create(string_literal390, retval);
    			adaptor.AddChild(root_0, string_literal390_tree);
    			}

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:955:9: '-='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(955, 9);
    			string_literal391=(IToken)new XToken((IToken)Match(input,SUBEQ,Follow._SUBEQ_in_assignmentOperator5372), "SUBEQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal391_tree = (object)adaptor.Create(string_literal391, retval);
    			adaptor.AddChild(root_0, string_literal391_tree);
    			}

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:956:9: '*='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(956, 9);
    			string_literal392=(IToken)new XToken((IToken)Match(input,STAREQ,Follow._STAREQ_in_assignmentOperator5382), "STAREQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal392_tree = (object)adaptor.Create(string_literal392, retval);
    			adaptor.AddChild(root_0, string_literal392_tree);
    			}

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:957:9: '/='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(957, 9);
    			string_literal393=(IToken)new XToken((IToken)Match(input,SLASHEQ,Follow._SLASHEQ_in_assignmentOperator5392), "SLASHEQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal393_tree = (object)adaptor.Create(string_literal393, retval);
    			adaptor.AddChild(root_0, string_literal393_tree);
    			}

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Java.g:958:9: '&='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(958, 9);
    			string_literal394=(IToken)new XToken((IToken)Match(input,AMPEQ,Follow._AMPEQ_in_assignmentOperator5402), "AMPEQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal394_tree = (object)adaptor.Create(string_literal394, retval);
    			adaptor.AddChild(root_0, string_literal394_tree);
    			}

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Java.g:959:9: '|='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(959, 9);
    			string_literal395=(IToken)new XToken((IToken)Match(input,BAREQ,Follow._BAREQ_in_assignmentOperator5412), "BAREQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal395_tree = (object)adaptor.Create(string_literal395, retval);
    			adaptor.AddChild(root_0, string_literal395_tree);
    			}

    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// Java.g:960:9: '^='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(960, 9);
    			string_literal396=(IToken)new XToken((IToken)Match(input,CARETEQ,Follow._CARETEQ_in_assignmentOperator5422), "CARETEQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal396_tree = (object)adaptor.Create(string_literal396, retval);
    			adaptor.AddChild(root_0, string_literal396_tree);
    			}

    			}
    			break;
    		case 9:
    			DebugEnterAlt(9);
    			// Java.g:961:9: '%='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(961, 9);
    			string_literal397=(IToken)new XToken((IToken)Match(input,PERCENTEQ,Follow._PERCENTEQ_in_assignmentOperator5432), "PERCENTEQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal397_tree = (object)adaptor.Create(string_literal397, retval);
    			adaptor.AddChild(root_0, string_literal397_tree);
    			}

    			}
    			break;
    		case 10:
    			DebugEnterAlt(10);
    			// Java.g:962:10: '<' '<' '='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(962, 10);
    			char_literal398=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_assignmentOperator5443), "LT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal398_tree = (object)adaptor.Create(char_literal398, retval);
    			adaptor.AddChild(root_0, char_literal398_tree);
    			}
    			DebugLocation(962, 14);
    			char_literal399=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_assignmentOperator5445), "LT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal399_tree = (object)adaptor.Create(char_literal399, retval);
    			adaptor.AddChild(root_0, char_literal399_tree);
    			}
    			DebugLocation(962, 18);
    			char_literal400=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_assignmentOperator5447), "EQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal400_tree = (object)adaptor.Create(char_literal400, retval);
    			adaptor.AddChild(root_0, char_literal400_tree);
    			}

    			}
    			break;
    		case 11:
    			DebugEnterAlt(11);
    			// Java.g:963:10: '>' '>' '>' '='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(963, 10);
    			char_literal401=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_assignmentOperator5458), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal401_tree = (object)adaptor.Create(char_literal401, retval);
    			adaptor.AddChild(root_0, char_literal401_tree);
    			}
    			DebugLocation(963, 14);
    			char_literal402=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_assignmentOperator5460), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal402_tree = (object)adaptor.Create(char_literal402, retval);
    			adaptor.AddChild(root_0, char_literal402_tree);
    			}
    			DebugLocation(963, 18);
    			char_literal403=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_assignmentOperator5462), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal403_tree = (object)adaptor.Create(char_literal403, retval);
    			adaptor.AddChild(root_0, char_literal403_tree);
    			}
    			DebugLocation(963, 22);
    			char_literal404=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_assignmentOperator5464), "EQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal404_tree = (object)adaptor.Create(char_literal404, retval);
    			adaptor.AddChild(root_0, char_literal404_tree);
    			}

    			}
    			break;
    		case 12:
    			DebugEnterAlt(12);
    			// Java.g:964:10: '>' '>' '='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(964, 10);
    			char_literal405=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_assignmentOperator5475), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal405_tree = (object)adaptor.Create(char_literal405, retval);
    			adaptor.AddChild(root_0, char_literal405_tree);
    			}
    			DebugLocation(964, 14);
    			char_literal406=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_assignmentOperator5477), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal406_tree = (object)adaptor.Create(char_literal406, retval);
    			adaptor.AddChild(root_0, char_literal406_tree);
    			}
    			DebugLocation(964, 18);
    			char_literal407=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_assignmentOperator5479), "EQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal407_tree = (object)adaptor.Create(char_literal407, retval);
    			adaptor.AddChild(root_0, char_literal407_tree);
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
            if (state.backtracking > 0) { Memoize(input, 71, assignmentOperator_StartIndex); }
        }
     	DebugLocation(965, 4);
    	} finally { DebugExitRule(GrammarFileName, "assignmentOperator"); }
    	return retval;

    }
    // $ANTLR end "assignmentOperator"

    public class conditionalExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_conditionalExpression() {}
    protected virtual void Leave_conditionalExpression() {}

    // $ANTLR start "conditionalExpression"
    // Java.g:968:1: conditionalExpression : conditionalOrExpression ( '?' expression ':' conditionalExpression )? ;
    [GrammarRule("conditionalExpression")]
    public JavaParser.conditionalExpression_return conditionalExpression()
    {

        JavaParser.conditionalExpression_return retval = new JavaParser.conditionalExpression_return();
        retval.Start = (IToken)input.LT(1);
        int conditionalExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal409=null;
        IToken char_literal411=null;
        JavaParser.conditionalOrExpression_return conditionalOrExpression408 = default(JavaParser.conditionalOrExpression_return);
        JavaParser.expression_return expression410 = default(JavaParser.expression_return);
        JavaParser.conditionalExpression_return conditionalExpression412 = default(JavaParser.conditionalExpression_return);

        object char_literal409_tree=null;
        object char_literal411_tree=null;

    	try { DebugEnterRule(GrammarFileName, "conditionalExpression");
    	DebugLocation(968, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 72)) { return retval; }
    		// Java.g:969:5: ( conditionalOrExpression ( '?' expression ':' conditionalExpression )? )
    		DebugEnterAlt(1);
    		// Java.g:969:9: conditionalOrExpression ( '?' expression ':' conditionalExpression )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(969, 9);
    		PushFollow(Follow._conditionalOrExpression_in_conditionalExpression5500);
    		conditionalOrExpression408=conditionalOrExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, conditionalOrExpression408.Tree, conditionalOrExpression408, retval);
    		DebugLocation(970, 9);
    		// Java.g:970:9: ( '?' expression ':' conditionalExpression )?
    		int alt113=2;
    		try { DebugEnterSubRule(113);
    		try { DebugEnterDecision(113, decisionCanBacktrack[113]);
    		int LA113_0 = input.LA(1);

    		if ((LA113_0==QUES))
    		{
    			alt113=1;
    		}
    		} finally { DebugExitDecision(113); }
    		switch (alt113)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:970:10: '?' expression ':' conditionalExpression
    			{
    			DebugLocation(970, 10);
    			char_literal409=(IToken)new XToken((IToken)Match(input,QUES,Follow._QUES_in_conditionalExpression5511), "QUES"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal409_tree = (object)adaptor.Create(char_literal409, retval);
    			adaptor.AddChild(root_0, char_literal409_tree);
    			}
    			DebugLocation(970, 14);
    			PushFollow(Follow._expression_in_conditionalExpression5513);
    			expression410=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression410.Tree, expression410, retval);
    			DebugLocation(970, 25);
    			char_literal411=(IToken)new XToken((IToken)Match(input,COLON,Follow._COLON_in_conditionalExpression5515), "COLON"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal411_tree = (object)adaptor.Create(char_literal411, retval);
    			adaptor.AddChild(root_0, char_literal411_tree);
    			}
    			DebugLocation(970, 29);
    			PushFollow(Follow._conditionalExpression_in_conditionalExpression5517);
    			conditionalExpression412=conditionalExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, conditionalExpression412.Tree, conditionalExpression412, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(113); }


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
            if (state.backtracking > 0) { Memoize(input, 72, conditionalExpression_StartIndex); }
        }
     	DebugLocation(972, 4);
    	} finally { DebugExitRule(GrammarFileName, "conditionalExpression"); }
    	return retval;

    }
    // $ANTLR end "conditionalExpression"

    public class conditionalOrExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_conditionalOrExpression() {}
    protected virtual void Leave_conditionalOrExpression() {}

    // $ANTLR start "conditionalOrExpression"
    // Java.g:974:1: conditionalOrExpression : conditionalAndExpression ( '||' conditionalAndExpression )* ;
    [GrammarRule("conditionalOrExpression")]
    public JavaParser.conditionalOrExpression_return conditionalOrExpression()
    {

        JavaParser.conditionalOrExpression_return retval = new JavaParser.conditionalOrExpression_return();
        retval.Start = (IToken)input.LT(1);
        int conditionalOrExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal414=null;
        JavaParser.conditionalAndExpression_return conditionalAndExpression413 = default(JavaParser.conditionalAndExpression_return);
        JavaParser.conditionalAndExpression_return conditionalAndExpression415 = default(JavaParser.conditionalAndExpression_return);

        object string_literal414_tree=null;

    	try { DebugEnterRule(GrammarFileName, "conditionalOrExpression");
    	DebugLocation(974, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 73)) { return retval; }
    		// Java.g:975:5: ( conditionalAndExpression ( '||' conditionalAndExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:975:9: conditionalAndExpression ( '||' conditionalAndExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(975, 9);
    		PushFollow(Follow._conditionalAndExpression_in_conditionalOrExpression5548);
    		conditionalAndExpression413=conditionalAndExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, conditionalAndExpression413.Tree, conditionalAndExpression413, retval);
    		DebugLocation(976, 9);
    		// Java.g:976:9: ( '||' conditionalAndExpression )*
    		try { DebugEnterSubRule(114);
    		while (true)
    		{
    			int alt114=2;
    			try { DebugEnterDecision(114, decisionCanBacktrack[114]);
    			int LA114_0 = input.LA(1);

    			if ((LA114_0==BARBAR))
    			{
    				alt114=1;
    			}


    			} finally { DebugExitDecision(114); }
    			switch ( alt114 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:976:10: '||' conditionalAndExpression
    				{
    				DebugLocation(976, 10);
    				string_literal414=(IToken)new XToken((IToken)Match(input,BARBAR,Follow._BARBAR_in_conditionalOrExpression5559), "BARBAR"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal414_tree = (object)adaptor.Create(string_literal414, retval);
    				adaptor.AddChild(root_0, string_literal414_tree);
    				}
    				DebugLocation(976, 15);
    				PushFollow(Follow._conditionalAndExpression_in_conditionalOrExpression5561);
    				conditionalAndExpression415=conditionalAndExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, conditionalAndExpression415.Tree, conditionalAndExpression415, retval);

    				}
    				break;

    			default:
    				goto loop114;
    			}
    		}

    		loop114:
    			;

    		} finally { DebugExitSubRule(114); }


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
            if (state.backtracking > 0) { Memoize(input, 73, conditionalOrExpression_StartIndex); }
        }
     	DebugLocation(978, 4);
    	} finally { DebugExitRule(GrammarFileName, "conditionalOrExpression"); }
    	return retval;

    }
    // $ANTLR end "conditionalOrExpression"

    public class conditionalAndExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_conditionalAndExpression() {}
    protected virtual void Leave_conditionalAndExpression() {}

    // $ANTLR start "conditionalAndExpression"
    // Java.g:980:1: conditionalAndExpression : inclusiveOrExpression ( '&&' inclusiveOrExpression )* ;
    [GrammarRule("conditionalAndExpression")]
    public JavaParser.conditionalAndExpression_return conditionalAndExpression()
    {

        JavaParser.conditionalAndExpression_return retval = new JavaParser.conditionalAndExpression_return();
        retval.Start = (IToken)input.LT(1);
        int conditionalAndExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal417=null;
        JavaParser.inclusiveOrExpression_return inclusiveOrExpression416 = default(JavaParser.inclusiveOrExpression_return);
        JavaParser.inclusiveOrExpression_return inclusiveOrExpression418 = default(JavaParser.inclusiveOrExpression_return);

        object string_literal417_tree=null;

    	try { DebugEnterRule(GrammarFileName, "conditionalAndExpression");
    	DebugLocation(980, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 74)) { return retval; }
    		// Java.g:981:5: ( inclusiveOrExpression ( '&&' inclusiveOrExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:981:9: inclusiveOrExpression ( '&&' inclusiveOrExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(981, 9);
    		PushFollow(Follow._inclusiveOrExpression_in_conditionalAndExpression5592);
    		inclusiveOrExpression416=inclusiveOrExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, inclusiveOrExpression416.Tree, inclusiveOrExpression416, retval);
    		DebugLocation(982, 9);
    		// Java.g:982:9: ( '&&' inclusiveOrExpression )*
    		try { DebugEnterSubRule(115);
    		while (true)
    		{
    			int alt115=2;
    			try { DebugEnterDecision(115, decisionCanBacktrack[115]);
    			int LA115_0 = input.LA(1);

    			if ((LA115_0==AMPAMP))
    			{
    				alt115=1;
    			}


    			} finally { DebugExitDecision(115); }
    			switch ( alt115 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:982:10: '&&' inclusiveOrExpression
    				{
    				DebugLocation(982, 10);
    				string_literal417=(IToken)new XToken((IToken)Match(input,AMPAMP,Follow._AMPAMP_in_conditionalAndExpression5603), "AMPAMP"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				string_literal417_tree = (object)adaptor.Create(string_literal417, retval);
    				adaptor.AddChild(root_0, string_literal417_tree);
    				}
    				DebugLocation(982, 15);
    				PushFollow(Follow._inclusiveOrExpression_in_conditionalAndExpression5605);
    				inclusiveOrExpression418=inclusiveOrExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, inclusiveOrExpression418.Tree, inclusiveOrExpression418, retval);

    				}
    				break;

    			default:
    				goto loop115;
    			}
    		}

    		loop115:
    			;

    		} finally { DebugExitSubRule(115); }


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
            if (state.backtracking > 0) { Memoize(input, 74, conditionalAndExpression_StartIndex); }
        }
     	DebugLocation(984, 4);
    	} finally { DebugExitRule(GrammarFileName, "conditionalAndExpression"); }
    	return retval;

    }
    // $ANTLR end "conditionalAndExpression"

    public class inclusiveOrExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_inclusiveOrExpression() {}
    protected virtual void Leave_inclusiveOrExpression() {}

    // $ANTLR start "inclusiveOrExpression"
    // Java.g:986:1: inclusiveOrExpression : exclusiveOrExpression ( '|' exclusiveOrExpression )* ;
    [GrammarRule("inclusiveOrExpression")]
    public JavaParser.inclusiveOrExpression_return inclusiveOrExpression()
    {

        JavaParser.inclusiveOrExpression_return retval = new JavaParser.inclusiveOrExpression_return();
        retval.Start = (IToken)input.LT(1);
        int inclusiveOrExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal420=null;
        JavaParser.exclusiveOrExpression_return exclusiveOrExpression419 = default(JavaParser.exclusiveOrExpression_return);
        JavaParser.exclusiveOrExpression_return exclusiveOrExpression421 = default(JavaParser.exclusiveOrExpression_return);

        object char_literal420_tree=null;

    	try { DebugEnterRule(GrammarFileName, "inclusiveOrExpression");
    	DebugLocation(986, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 75)) { return retval; }
    		// Java.g:987:5: ( exclusiveOrExpression ( '|' exclusiveOrExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:987:9: exclusiveOrExpression ( '|' exclusiveOrExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(987, 9);
    		PushFollow(Follow._exclusiveOrExpression_in_inclusiveOrExpression5636);
    		exclusiveOrExpression419=exclusiveOrExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exclusiveOrExpression419.Tree, exclusiveOrExpression419, retval);
    		DebugLocation(988, 9);
    		// Java.g:988:9: ( '|' exclusiveOrExpression )*
    		try { DebugEnterSubRule(116);
    		while (true)
    		{
    			int alt116=2;
    			try { DebugEnterDecision(116, decisionCanBacktrack[116]);
    			int LA116_0 = input.LA(1);

    			if ((LA116_0==BAR))
    			{
    				alt116=1;
    			}


    			} finally { DebugExitDecision(116); }
    			switch ( alt116 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:988:10: '|' exclusiveOrExpression
    				{
    				DebugLocation(988, 10);
    				char_literal420=(IToken)new XToken((IToken)Match(input,BAR,Follow._BAR_in_inclusiveOrExpression5647), "BAR"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal420_tree = (object)adaptor.Create(char_literal420, retval);
    				adaptor.AddChild(root_0, char_literal420_tree);
    				}
    				DebugLocation(988, 14);
    				PushFollow(Follow._exclusiveOrExpression_in_inclusiveOrExpression5649);
    				exclusiveOrExpression421=exclusiveOrExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, exclusiveOrExpression421.Tree, exclusiveOrExpression421, retval);

    				}
    				break;

    			default:
    				goto loop116;
    			}
    		}

    		loop116:
    			;

    		} finally { DebugExitSubRule(116); }


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
            if (state.backtracking > 0) { Memoize(input, 75, inclusiveOrExpression_StartIndex); }
        }
     	DebugLocation(990, 4);
    	} finally { DebugExitRule(GrammarFileName, "inclusiveOrExpression"); }
    	return retval;

    }
    // $ANTLR end "inclusiveOrExpression"

    public class exclusiveOrExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_exclusiveOrExpression() {}
    protected virtual void Leave_exclusiveOrExpression() {}

    // $ANTLR start "exclusiveOrExpression"
    // Java.g:992:1: exclusiveOrExpression : andExpression ( '^' andExpression )* ;
    [GrammarRule("exclusiveOrExpression")]
    public JavaParser.exclusiveOrExpression_return exclusiveOrExpression()
    {

        JavaParser.exclusiveOrExpression_return retval = new JavaParser.exclusiveOrExpression_return();
        retval.Start = (IToken)input.LT(1);
        int exclusiveOrExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal423=null;
        JavaParser.andExpression_return andExpression422 = default(JavaParser.andExpression_return);
        JavaParser.andExpression_return andExpression424 = default(JavaParser.andExpression_return);

        object char_literal423_tree=null;

    	try { DebugEnterRule(GrammarFileName, "exclusiveOrExpression");
    	DebugLocation(992, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 76)) { return retval; }
    		// Java.g:993:5: ( andExpression ( '^' andExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:993:9: andExpression ( '^' andExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(993, 9);
    		PushFollow(Follow._andExpression_in_exclusiveOrExpression5680);
    		andExpression422=andExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, andExpression422.Tree, andExpression422, retval);
    		DebugLocation(994, 9);
    		// Java.g:994:9: ( '^' andExpression )*
    		try { DebugEnterSubRule(117);
    		while (true)
    		{
    			int alt117=2;
    			try { DebugEnterDecision(117, decisionCanBacktrack[117]);
    			int LA117_0 = input.LA(1);

    			if ((LA117_0==CARET))
    			{
    				alt117=1;
    			}


    			} finally { DebugExitDecision(117); }
    			switch ( alt117 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:994:10: '^' andExpression
    				{
    				DebugLocation(994, 10);
    				char_literal423=(IToken)new XToken((IToken)Match(input,CARET,Follow._CARET_in_exclusiveOrExpression5691), "CARET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal423_tree = (object)adaptor.Create(char_literal423, retval);
    				adaptor.AddChild(root_0, char_literal423_tree);
    				}
    				DebugLocation(994, 14);
    				PushFollow(Follow._andExpression_in_exclusiveOrExpression5693);
    				andExpression424=andExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, andExpression424.Tree, andExpression424, retval);

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
            if (state.backtracking > 0) { Memoize(input, 76, exclusiveOrExpression_StartIndex); }
        }
     	DebugLocation(996, 4);
    	} finally { DebugExitRule(GrammarFileName, "exclusiveOrExpression"); }
    	return retval;

    }
    // $ANTLR end "exclusiveOrExpression"

    public class andExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_andExpression() {}
    protected virtual void Leave_andExpression() {}

    // $ANTLR start "andExpression"
    // Java.g:998:1: andExpression : equalityExpression ( '&' equalityExpression )* ;
    [GrammarRule("andExpression")]
    public JavaParser.andExpression_return andExpression()
    {

        JavaParser.andExpression_return retval = new JavaParser.andExpression_return();
        retval.Start = (IToken)input.LT(1);
        int andExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal426=null;
        JavaParser.equalityExpression_return equalityExpression425 = default(JavaParser.equalityExpression_return);
        JavaParser.equalityExpression_return equalityExpression427 = default(JavaParser.equalityExpression_return);

        object char_literal426_tree=null;

    	try { DebugEnterRule(GrammarFileName, "andExpression");
    	DebugLocation(998, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 77)) { return retval; }
    		// Java.g:999:5: ( equalityExpression ( '&' equalityExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:999:9: equalityExpression ( '&' equalityExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(999, 9);
    		PushFollow(Follow._equalityExpression_in_andExpression5724);
    		equalityExpression425=equalityExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, equalityExpression425.Tree, equalityExpression425, retval);
    		DebugLocation(1000, 9);
    		// Java.g:1000:9: ( '&' equalityExpression )*
    		try { DebugEnterSubRule(118);
    		while (true)
    		{
    			int alt118=2;
    			try { DebugEnterDecision(118, decisionCanBacktrack[118]);
    			int LA118_0 = input.LA(1);

    			if ((LA118_0==AMP))
    			{
    				alt118=1;
    			}


    			} finally { DebugExitDecision(118); }
    			switch ( alt118 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1000:10: '&' equalityExpression
    				{
    				DebugLocation(1000, 10);
    				char_literal426=(IToken)new XToken((IToken)Match(input,AMP,Follow._AMP_in_andExpression5735), "AMP"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal426_tree = (object)adaptor.Create(char_literal426, retval);
    				adaptor.AddChild(root_0, char_literal426_tree);
    				}
    				DebugLocation(1000, 14);
    				PushFollow(Follow._equalityExpression_in_andExpression5737);
    				equalityExpression427=equalityExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, equalityExpression427.Tree, equalityExpression427, retval);

    				}
    				break;

    			default:
    				goto loop118;
    			}
    		}

    		loop118:
    			;

    		} finally { DebugExitSubRule(118); }


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
            if (state.backtracking > 0) { Memoize(input, 77, andExpression_StartIndex); }
        }
     	DebugLocation(1002, 4);
    	} finally { DebugExitRule(GrammarFileName, "andExpression"); }
    	return retval;

    }
    // $ANTLR end "andExpression"

    public class equalityExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_equalityExpression() {}
    protected virtual void Leave_equalityExpression() {}

    // $ANTLR start "equalityExpression"
    // Java.g:1004:1: equalityExpression : instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression )* ;
    [GrammarRule("equalityExpression")]
    public JavaParser.equalityExpression_return equalityExpression()
    {

        JavaParser.equalityExpression_return retval = new JavaParser.equalityExpression_return();
        retval.Start = (IToken)input.LT(1);
        int equalityExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken set429=null;
        JavaParser.instanceOfExpression_return instanceOfExpression428 = default(JavaParser.instanceOfExpression_return);
        JavaParser.instanceOfExpression_return instanceOfExpression430 = default(JavaParser.instanceOfExpression_return);

        object set429_tree=null;

    	try { DebugEnterRule(GrammarFileName, "equalityExpression");
    	DebugLocation(1004, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 78)) { return retval; }
    		// Java.g:1005:5: ( instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:1005:9: instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1005, 9);
    		PushFollow(Follow._instanceOfExpression_in_equalityExpression5768);
    		instanceOfExpression428=instanceOfExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, instanceOfExpression428.Tree, instanceOfExpression428, retval);
    		DebugLocation(1006, 9);
    		// Java.g:1006:9: ( ( '==' | '!=' ) instanceOfExpression )*
    		try { DebugEnterSubRule(119);
    		while (true)
    		{
    			int alt119=2;
    			try { DebugEnterDecision(119, decisionCanBacktrack[119]);
    			int LA119_0 = input.LA(1);

    			if ((LA119_0==EQEQ||LA119_0==BANGEQ))
    			{
    				alt119=1;
    			}


    			} finally { DebugExitDecision(119); }
    			switch ( alt119 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1007:13: ( '==' | '!=' ) instanceOfExpression
    				{
    				DebugLocation(1007, 13);
    				set429=(IToken)input.LT(1);
    				if (input.LA(1)==EQEQ||input.LA(1)==BANGEQ)
    				{
    					input.Consume();
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set429, retval));
    					state.errorRecovery=false;state.failed=false;
    				}
    				else
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					throw mse;
    				}

    				DebugLocation(1010, 13);
    				PushFollow(Follow._instanceOfExpression_in_equalityExpression5845);
    				instanceOfExpression430=instanceOfExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, instanceOfExpression430.Tree, instanceOfExpression430, retval);

    				}
    				break;

    			default:
    				goto loop119;
    			}
    		}

    		loop119:
    			;

    		} finally { DebugExitSubRule(119); }


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
            if (state.backtracking > 0) { Memoize(input, 78, equalityExpression_StartIndex); }
        }
     	DebugLocation(1012, 4);
    	} finally { DebugExitRule(GrammarFileName, "equalityExpression"); }
    	return retval;

    }
    // $ANTLR end "equalityExpression"

    public class instanceOfExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_instanceOfExpression() {}
    protected virtual void Leave_instanceOfExpression() {}

    // $ANTLR start "instanceOfExpression"
    // Java.g:1014:1: instanceOfExpression : relationalExpression ( 'instanceof' type )? ;
    [GrammarRule("instanceOfExpression")]
    public JavaParser.instanceOfExpression_return instanceOfExpression()
    {

        JavaParser.instanceOfExpression_return retval = new JavaParser.instanceOfExpression_return();
        retval.Start = (IToken)input.LT(1);
        int instanceOfExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal432=null;
        JavaParser.relationalExpression_return relationalExpression431 = default(JavaParser.relationalExpression_return);
        JavaParser.type_return type433 = default(JavaParser.type_return);

        object string_literal432_tree=null;

    	try { DebugEnterRule(GrammarFileName, "instanceOfExpression");
    	DebugLocation(1014, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 79)) { return retval; }
    		// Java.g:1015:5: ( relationalExpression ( 'instanceof' type )? )
    		DebugEnterAlt(1);
    		// Java.g:1015:9: relationalExpression ( 'instanceof' type )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1015, 9);
    		PushFollow(Follow._relationalExpression_in_instanceOfExpression5876);
    		relationalExpression431=relationalExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, relationalExpression431.Tree, relationalExpression431, retval);
    		DebugLocation(1016, 9);
    		// Java.g:1016:9: ( 'instanceof' type )?
    		int alt120=2;
    		try { DebugEnterSubRule(120);
    		try { DebugEnterDecision(120, decisionCanBacktrack[120]);
    		int LA120_0 = input.LA(1);

    		if ((LA120_0==INSTANCEOF))
    		{
    			alt120=1;
    		}
    		} finally { DebugExitDecision(120); }
    		switch (alt120)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1016:10: 'instanceof' type
    			{
    			DebugLocation(1016, 10);
    			string_literal432=(IToken)new XToken((IToken)Match(input,INSTANCEOF,Follow._INSTANCEOF_in_instanceOfExpression5887), "INSTANCEOF"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal432_tree = (object)adaptor.Create(string_literal432, retval);
    			adaptor.AddChild(root_0, string_literal432_tree);
    			}
    			DebugLocation(1016, 23);
    			PushFollow(Follow._type_in_instanceOfExpression5889);
    			type433=type();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type433.Tree, type433, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(120); }


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
            if (state.backtracking > 0) { Memoize(input, 79, instanceOfExpression_StartIndex); }
        }
     	DebugLocation(1018, 4);
    	} finally { DebugExitRule(GrammarFileName, "instanceOfExpression"); }
    	return retval;

    }
    // $ANTLR end "instanceOfExpression"

    public class relationalExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_relationalExpression() {}
    protected virtual void Leave_relationalExpression() {}

    // $ANTLR start "relationalExpression"
    // Java.g:1020:1: relationalExpression : shiftExpression ( relationalOp shiftExpression )* ;
    [GrammarRule("relationalExpression")]
    public JavaParser.relationalExpression_return relationalExpression()
    {

        JavaParser.relationalExpression_return retval = new JavaParser.relationalExpression_return();
        retval.Start = (IToken)input.LT(1);
        int relationalExpression_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.shiftExpression_return shiftExpression434 = default(JavaParser.shiftExpression_return);
        JavaParser.relationalOp_return relationalOp435 = default(JavaParser.relationalOp_return);
        JavaParser.shiftExpression_return shiftExpression436 = default(JavaParser.shiftExpression_return);


    	try { DebugEnterRule(GrammarFileName, "relationalExpression");
    	DebugLocation(1020, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 80)) { return retval; }
    		// Java.g:1021:5: ( shiftExpression ( relationalOp shiftExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:1021:9: shiftExpression ( relationalOp shiftExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1021, 9);
    		PushFollow(Follow._shiftExpression_in_relationalExpression5920);
    		shiftExpression434=shiftExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, shiftExpression434.Tree, shiftExpression434, retval);
    		DebugLocation(1022, 9);
    		// Java.g:1022:9: ( relationalOp shiftExpression )*
    		try { DebugEnterSubRule(121);
    		while (true)
    		{
    			int alt121=2;
    			try { DebugEnterDecision(121, decisionCanBacktrack[121]);
    			int LA121_0 = input.LA(1);

    			if ((LA121_0==LT))
    			{
    				int LA121_2 = input.LA(2);

    				if (((LA121_2>=IDENTIFIER && LA121_2<=NULL)||LA121_2==BOOLEAN||LA121_2==BYTE||LA121_2==CHAR||LA121_2==DOUBLE||LA121_2==FLOAT||LA121_2==INT||LA121_2==LONG||LA121_2==NEW||LA121_2==SHORT||LA121_2==SUPER||LA121_2==THIS||LA121_2==VOID||LA121_2==LPAREN||(LA121_2>=EQ && LA121_2<=TILDE)||(LA121_2>=PLUSPLUS && LA121_2<=SUB)))
    				{
    					alt121=1;
    				}


    			}
    			else if ((LA121_0==GT))
    			{
    				int LA121_3 = input.LA(2);

    				if (((LA121_3>=IDENTIFIER && LA121_3<=NULL)||LA121_3==BOOLEAN||LA121_3==BYTE||LA121_3==CHAR||LA121_3==DOUBLE||LA121_3==FLOAT||LA121_3==INT||LA121_3==LONG||LA121_3==NEW||LA121_3==SHORT||LA121_3==SUPER||LA121_3==THIS||LA121_3==VOID||LA121_3==LPAREN||(LA121_3>=EQ && LA121_3<=TILDE)||(LA121_3>=PLUSPLUS && LA121_3<=SUB)))
    				{
    					alt121=1;
    				}


    			}


    			} finally { DebugExitDecision(121); }
    			switch ( alt121 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1022:10: relationalOp shiftExpression
    				{
    				DebugLocation(1022, 10);
    				PushFollow(Follow._relationalOp_in_relationalExpression5931);
    				relationalOp435=relationalOp();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, relationalOp435.Tree, relationalOp435, retval);
    				DebugLocation(1022, 23);
    				PushFollow(Follow._shiftExpression_in_relationalExpression5933);
    				shiftExpression436=shiftExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, shiftExpression436.Tree, shiftExpression436, retval);

    				}
    				break;

    			default:
    				goto loop121;
    			}
    		}

    		loop121:
    			;

    		} finally { DebugExitSubRule(121); }


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
            if (state.backtracking > 0) { Memoize(input, 80, relationalExpression_StartIndex); }
        }
     	DebugLocation(1024, 4);
    	} finally { DebugExitRule(GrammarFileName, "relationalExpression"); }
    	return retval;

    }
    // $ANTLR end "relationalExpression"

    public class relationalOp_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_relationalOp() {}
    protected virtual void Leave_relationalOp() {}

    // $ANTLR start "relationalOp"
    // Java.g:1026:1: relationalOp : ( '<' '=' | '>' '=' | '<' | '>' );
    [GrammarRule("relationalOp")]
    public JavaParser.relationalOp_return relationalOp()
    {

        JavaParser.relationalOp_return retval = new JavaParser.relationalOp_return();
        retval.Start = (IToken)input.LT(1);
        int relationalOp_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal437=null;
        IToken char_literal438=null;
        IToken char_literal439=null;
        IToken char_literal440=null;
        IToken char_literal441=null;
        IToken char_literal442=null;

        object char_literal437_tree=null;
        object char_literal438_tree=null;
        object char_literal439_tree=null;
        object char_literal440_tree=null;
        object char_literal441_tree=null;
        object char_literal442_tree=null;

    	try { DebugEnterRule(GrammarFileName, "relationalOp");
    	DebugLocation(1026, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 81)) { return retval; }
    		// Java.g:1027:5: ( '<' '=' | '>' '=' | '<' | '>' )
    		int alt122=4;
    		try { DebugEnterDecision(122, decisionCanBacktrack[122]);
    		int LA122_0 = input.LA(1);

    		if ((LA122_0==LT))
    		{
    			int LA122_1 = input.LA(2);

    			if ((LA122_1==EQ))
    			{
    				alt122=1;
    			}
    			else if (((LA122_1>=IDENTIFIER && LA122_1<=NULL)||LA122_1==BOOLEAN||LA122_1==BYTE||LA122_1==CHAR||LA122_1==DOUBLE||LA122_1==FLOAT||LA122_1==INT||LA122_1==LONG||LA122_1==NEW||LA122_1==SHORT||LA122_1==SUPER||LA122_1==THIS||LA122_1==VOID||LA122_1==LPAREN||(LA122_1>=BANG && LA122_1<=TILDE)||(LA122_1>=PLUSPLUS && LA122_1<=SUB)))
    			{
    				alt122=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 122, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else if ((LA122_0==GT))
    		{
    			int LA122_2 = input.LA(2);

    			if ((LA122_2==EQ))
    			{
    				alt122=2;
    			}
    			else if (((LA122_2>=IDENTIFIER && LA122_2<=NULL)||LA122_2==BOOLEAN||LA122_2==BYTE||LA122_2==CHAR||LA122_2==DOUBLE||LA122_2==FLOAT||LA122_2==INT||LA122_2==LONG||LA122_2==NEW||LA122_2==SHORT||LA122_2==SUPER||LA122_2==THIS||LA122_2==VOID||LA122_2==LPAREN||(LA122_2>=BANG && LA122_2<=TILDE)||(LA122_2>=PLUSPLUS && LA122_2<=SUB)))
    			{
    				alt122=4;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 122, 2, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 122, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(122); }
    		switch (alt122)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1027:10: '<' '='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1027, 10);
    			char_literal437=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_relationalOp5965), "LT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal437_tree = (object)adaptor.Create(char_literal437, retval);
    			adaptor.AddChild(root_0, char_literal437_tree);
    			}
    			DebugLocation(1027, 14);
    			char_literal438=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_relationalOp5967), "EQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal438_tree = (object)adaptor.Create(char_literal438, retval);
    			adaptor.AddChild(root_0, char_literal438_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1028:10: '>' '='
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1028, 10);
    			char_literal439=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_relationalOp5978), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal439_tree = (object)adaptor.Create(char_literal439, retval);
    			adaptor.AddChild(root_0, char_literal439_tree);
    			}
    			DebugLocation(1028, 14);
    			char_literal440=(IToken)new XToken((IToken)Match(input,EQ,Follow._EQ_in_relationalOp5980), "EQ"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal440_tree = (object)adaptor.Create(char_literal440, retval);
    			adaptor.AddChild(root_0, char_literal440_tree);
    			}

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1029:9: '<'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1029, 9);
    			char_literal441=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_relationalOp5990), "LT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal441_tree = (object)adaptor.Create(char_literal441, retval);
    			adaptor.AddChild(root_0, char_literal441_tree);
    			}

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:1030:9: '>'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1030, 9);
    			char_literal442=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_relationalOp6000), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal442_tree = (object)adaptor.Create(char_literal442, retval);
    			adaptor.AddChild(root_0, char_literal442_tree);
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
            if (state.backtracking > 0) { Memoize(input, 81, relationalOp_StartIndex); }
        }
     	DebugLocation(1031, 4);
    	} finally { DebugExitRule(GrammarFileName, "relationalOp"); }
    	return retval;

    }
    // $ANTLR end "relationalOp"

    public class shiftExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_shiftExpression() {}
    protected virtual void Leave_shiftExpression() {}

    // $ANTLR start "shiftExpression"
    // Java.g:1033:1: shiftExpression : additiveExpression ( shiftOp additiveExpression )* ;
    [GrammarRule("shiftExpression")]
    public JavaParser.shiftExpression_return shiftExpression()
    {

        JavaParser.shiftExpression_return retval = new JavaParser.shiftExpression_return();
        retval.Start = (IToken)input.LT(1);
        int shiftExpression_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.additiveExpression_return additiveExpression443 = default(JavaParser.additiveExpression_return);
        JavaParser.shiftOp_return shiftOp444 = default(JavaParser.shiftOp_return);
        JavaParser.additiveExpression_return additiveExpression445 = default(JavaParser.additiveExpression_return);


    	try { DebugEnterRule(GrammarFileName, "shiftExpression");
    	DebugLocation(1033, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 82)) { return retval; }
    		// Java.g:1034:5: ( additiveExpression ( shiftOp additiveExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:1034:9: additiveExpression ( shiftOp additiveExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1034, 9);
    		PushFollow(Follow._additiveExpression_in_shiftExpression6020);
    		additiveExpression443=additiveExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, additiveExpression443.Tree, additiveExpression443, retval);
    		DebugLocation(1035, 9);
    		// Java.g:1035:9: ( shiftOp additiveExpression )*
    		try { DebugEnterSubRule(123);
    		while (true)
    		{
    			int alt123=2;
    			try { DebugEnterDecision(123, decisionCanBacktrack[123]);
    			int LA123_0 = input.LA(1);

    			if ((LA123_0==LT))
    			{
    				int LA123_1 = input.LA(2);

    				if ((LA123_1==LT))
    				{
    					int LA123_4 = input.LA(3);

    					if (((LA123_4>=IDENTIFIER && LA123_4<=NULL)||LA123_4==BOOLEAN||LA123_4==BYTE||LA123_4==CHAR||LA123_4==DOUBLE||LA123_4==FLOAT||LA123_4==INT||LA123_4==LONG||LA123_4==NEW||LA123_4==SHORT||LA123_4==SUPER||LA123_4==THIS||LA123_4==VOID||LA123_4==LPAREN||(LA123_4>=BANG && LA123_4<=TILDE)||(LA123_4>=PLUSPLUS && LA123_4<=SUB)))
    					{
    						alt123=1;
    					}


    				}


    			}
    			else if ((LA123_0==GT))
    			{
    				int LA123_2 = input.LA(2);

    				if ((LA123_2==GT))
    				{
    					int LA123_5 = input.LA(3);

    					if ((LA123_5==GT))
    					{
    						int LA123_7 = input.LA(4);

    						if (((LA123_7>=IDENTIFIER && LA123_7<=NULL)||LA123_7==BOOLEAN||LA123_7==BYTE||LA123_7==CHAR||LA123_7==DOUBLE||LA123_7==FLOAT||LA123_7==INT||LA123_7==LONG||LA123_7==NEW||LA123_7==SHORT||LA123_7==SUPER||LA123_7==THIS||LA123_7==VOID||LA123_7==LPAREN||(LA123_7>=BANG && LA123_7<=TILDE)||(LA123_7>=PLUSPLUS && LA123_7<=SUB)))
    						{
    							alt123=1;
    						}


    					}
    					else if (((LA123_5>=IDENTIFIER && LA123_5<=NULL)||LA123_5==BOOLEAN||LA123_5==BYTE||LA123_5==CHAR||LA123_5==DOUBLE||LA123_5==FLOAT||LA123_5==INT||LA123_5==LONG||LA123_5==NEW||LA123_5==SHORT||LA123_5==SUPER||LA123_5==THIS||LA123_5==VOID||LA123_5==LPAREN||(LA123_5>=BANG && LA123_5<=TILDE)||(LA123_5>=PLUSPLUS && LA123_5<=SUB)))
    					{
    						alt123=1;
    					}


    				}


    			}


    			} finally { DebugExitDecision(123); }
    			switch ( alt123 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1035:10: shiftOp additiveExpression
    				{
    				DebugLocation(1035, 10);
    				PushFollow(Follow._shiftOp_in_shiftExpression6031);
    				shiftOp444=shiftOp();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, shiftOp444.Tree, shiftOp444, retval);
    				DebugLocation(1035, 18);
    				PushFollow(Follow._additiveExpression_in_shiftExpression6033);
    				additiveExpression445=additiveExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, additiveExpression445.Tree, additiveExpression445, retval);

    				}
    				break;

    			default:
    				goto loop123;
    			}
    		}

    		loop123:
    			;

    		} finally { DebugExitSubRule(123); }


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
            if (state.backtracking > 0) { Memoize(input, 82, shiftExpression_StartIndex); }
        }
     	DebugLocation(1037, 4);
    	} finally { DebugExitRule(GrammarFileName, "shiftExpression"); }
    	return retval;

    }
    // $ANTLR end "shiftExpression"

    public class shiftOp_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_shiftOp() {}
    protected virtual void Leave_shiftOp() {}

    // $ANTLR start "shiftOp"
    // Java.g:1040:1: shiftOp : ( '<' '<' | '>' '>' '>' | '>' '>' );
    [GrammarRule("shiftOp")]
    public JavaParser.shiftOp_return shiftOp()
    {

        JavaParser.shiftOp_return retval = new JavaParser.shiftOp_return();
        retval.Start = (IToken)input.LT(1);
        int shiftOp_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal446=null;
        IToken char_literal447=null;
        IToken char_literal448=null;
        IToken char_literal449=null;
        IToken char_literal450=null;
        IToken char_literal451=null;
        IToken char_literal452=null;

        object char_literal446_tree=null;
        object char_literal447_tree=null;
        object char_literal448_tree=null;
        object char_literal449_tree=null;
        object char_literal450_tree=null;
        object char_literal451_tree=null;
        object char_literal452_tree=null;

    	try { DebugEnterRule(GrammarFileName, "shiftOp");
    	DebugLocation(1040, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 83)) { return retval; }
    		// Java.g:1041:5: ( '<' '<' | '>' '>' '>' | '>' '>' )
    		int alt124=3;
    		try { DebugEnterDecision(124, decisionCanBacktrack[124]);
    		int LA124_0 = input.LA(1);

    		if ((LA124_0==LT))
    		{
    			alt124=1;
    		}
    		else if ((LA124_0==GT))
    		{
    			int LA124_2 = input.LA(2);

    			if ((LA124_2==GT))
    			{
    				int LA124_3 = input.LA(3);

    				if ((LA124_3==GT))
    				{
    					alt124=2;
    				}
    				else if (((LA124_3>=IDENTIFIER && LA124_3<=NULL)||LA124_3==BOOLEAN||LA124_3==BYTE||LA124_3==CHAR||LA124_3==DOUBLE||LA124_3==FLOAT||LA124_3==INT||LA124_3==LONG||LA124_3==NEW||LA124_3==SHORT||LA124_3==SUPER||LA124_3==THIS||LA124_3==VOID||LA124_3==LPAREN||(LA124_3>=BANG && LA124_3<=TILDE)||(LA124_3>=PLUSPLUS && LA124_3<=SUB)))
    				{
    					alt124=3;
    				}
    				else
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					NoViableAltException nvae = new NoViableAltException("", 124, 3, input);

    					DebugRecognitionException(nvae);
    					throw nvae;
    				}
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 124, 2, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 124, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(124); }
    		switch (alt124)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1041:10: '<' '<'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1041, 10);
    			char_literal446=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_shiftOp6066), "LT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal446_tree = (object)adaptor.Create(char_literal446, retval);
    			adaptor.AddChild(root_0, char_literal446_tree);
    			}
    			DebugLocation(1041, 14);
    			char_literal447=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_shiftOp6068), "LT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal447_tree = (object)adaptor.Create(char_literal447, retval);
    			adaptor.AddChild(root_0, char_literal447_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1042:10: '>' '>' '>'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1042, 10);
    			char_literal448=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_shiftOp6079), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal448_tree = (object)adaptor.Create(char_literal448, retval);
    			adaptor.AddChild(root_0, char_literal448_tree);
    			}
    			DebugLocation(1042, 14);
    			char_literal449=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_shiftOp6081), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal449_tree = (object)adaptor.Create(char_literal449, retval);
    			adaptor.AddChild(root_0, char_literal449_tree);
    			}
    			DebugLocation(1042, 18);
    			char_literal450=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_shiftOp6083), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal450_tree = (object)adaptor.Create(char_literal450, retval);
    			adaptor.AddChild(root_0, char_literal450_tree);
    			}

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1043:10: '>' '>'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1043, 10);
    			char_literal451=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_shiftOp6094), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal451_tree = (object)adaptor.Create(char_literal451, retval);
    			adaptor.AddChild(root_0, char_literal451_tree);
    			}
    			DebugLocation(1043, 14);
    			char_literal452=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_shiftOp6096), "GT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal452_tree = (object)adaptor.Create(char_literal452, retval);
    			adaptor.AddChild(root_0, char_literal452_tree);
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
            if (state.backtracking > 0) { Memoize(input, 83, shiftOp_StartIndex); }
        }
     	DebugLocation(1044, 4);
    	} finally { DebugExitRule(GrammarFileName, "shiftOp"); }
    	return retval;

    }
    // $ANTLR end "shiftOp"

    public class additiveExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_additiveExpression() {}
    protected virtual void Leave_additiveExpression() {}

    // $ANTLR start "additiveExpression"
    // Java.g:1047:1: additiveExpression : multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )* ;
    [GrammarRule("additiveExpression")]
    public JavaParser.additiveExpression_return additiveExpression()
    {

        JavaParser.additiveExpression_return retval = new JavaParser.additiveExpression_return();
        retval.Start = (IToken)input.LT(1);
        int additiveExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken set454=null;
        JavaParser.multiplicativeExpression_return multiplicativeExpression453 = default(JavaParser.multiplicativeExpression_return);
        JavaParser.multiplicativeExpression_return multiplicativeExpression455 = default(JavaParser.multiplicativeExpression_return);

        object set454_tree=null;

    	try { DebugEnterRule(GrammarFileName, "additiveExpression");
    	DebugLocation(1047, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 84)) { return retval; }
    		// Java.g:1048:5: ( multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:1048:9: multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1048, 9);
    		PushFollow(Follow._multiplicativeExpression_in_additiveExpression6117);
    		multiplicativeExpression453=multiplicativeExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, multiplicativeExpression453.Tree, multiplicativeExpression453, retval);
    		DebugLocation(1049, 9);
    		// Java.g:1049:9: ( ( '+' | '-' ) multiplicativeExpression )*
    		try { DebugEnterSubRule(125);
    		while (true)
    		{
    			int alt125=2;
    			try { DebugEnterDecision(125, decisionCanBacktrack[125]);
    			int LA125_0 = input.LA(1);

    			if (((LA125_0>=PLUS && LA125_0<=SUB)))
    			{
    				alt125=1;
    			}


    			} finally { DebugExitDecision(125); }
    			switch ( alt125 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1050:13: ( '+' | '-' ) multiplicativeExpression
    				{
    				DebugLocation(1050, 13);
    				set454=(IToken)input.LT(1);
    				if ((input.LA(1)>=PLUS && input.LA(1)<=SUB))
    				{
    					input.Consume();
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set454, retval));
    					state.errorRecovery=false;state.failed=false;
    				}
    				else
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					throw mse;
    				}

    				DebugLocation(1053, 13);
    				PushFollow(Follow._multiplicativeExpression_in_additiveExpression6194);
    				multiplicativeExpression455=multiplicativeExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, multiplicativeExpression455.Tree, multiplicativeExpression455, retval);

    				}
    				break;

    			default:
    				goto loop125;
    			}
    		}

    		loop125:
    			;

    		} finally { DebugExitSubRule(125); }


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
            if (state.backtracking > 0) { Memoize(input, 84, additiveExpression_StartIndex); }
        }
     	DebugLocation(1055, 4);
    	} finally { DebugExitRule(GrammarFileName, "additiveExpression"); }
    	return retval;

    }
    // $ANTLR end "additiveExpression"

    public class multiplicativeExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_multiplicativeExpression() {}
    protected virtual void Leave_multiplicativeExpression() {}

    // $ANTLR start "multiplicativeExpression"
    // Java.g:1057:1: multiplicativeExpression : unaryExpression ( ( '*' | '/' | '%' ) unaryExpression )* ;
    [GrammarRule("multiplicativeExpression")]
    public JavaParser.multiplicativeExpression_return multiplicativeExpression()
    {

        JavaParser.multiplicativeExpression_return retval = new JavaParser.multiplicativeExpression_return();
        retval.Start = (IToken)input.LT(1);
        int multiplicativeExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken set457=null;
        JavaParser.unaryExpression_return unaryExpression456 = default(JavaParser.unaryExpression_return);
        JavaParser.unaryExpression_return unaryExpression458 = default(JavaParser.unaryExpression_return);

        object set457_tree=null;

    	try { DebugEnterRule(GrammarFileName, "multiplicativeExpression");
    	DebugLocation(1057, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 85)) { return retval; }
    		// Java.g:1058:5: ( unaryExpression ( ( '*' | '/' | '%' ) unaryExpression )* )
    		DebugEnterAlt(1);
    		// Java.g:1059:9: unaryExpression ( ( '*' | '/' | '%' ) unaryExpression )*
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1059, 9);
    		PushFollow(Follow._unaryExpression_in_multiplicativeExpression6232);
    		unaryExpression456=unaryExpression();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression456.Tree, unaryExpression456, retval);
    		DebugLocation(1060, 9);
    		// Java.g:1060:9: ( ( '*' | '/' | '%' ) unaryExpression )*
    		try { DebugEnterSubRule(126);
    		while (true)
    		{
    			int alt126=2;
    			try { DebugEnterDecision(126, decisionCanBacktrack[126]);
    			int LA126_0 = input.LA(1);

    			if (((LA126_0>=STAR && LA126_0<=SLASH)||LA126_0==PERCENT))
    			{
    				alt126=1;
    			}


    			} finally { DebugExitDecision(126); }
    			switch ( alt126 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1061:13: ( '*' | '/' | '%' ) unaryExpression
    				{
    				DebugLocation(1061, 13);
    				set457=(IToken)input.LT(1);
    				if ((input.LA(1)>=STAR && input.LA(1)<=SLASH)||input.LA(1)==PERCENT)
    				{
    					input.Consume();
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set457, retval));
    					state.errorRecovery=false;state.failed=false;
    				}
    				else
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					MismatchedSetException mse = new MismatchedSetException(null,input);
    					DebugRecognitionException(mse);
    					throw mse;
    				}

    				DebugLocation(1065, 13);
    				PushFollow(Follow._unaryExpression_in_multiplicativeExpression6327);
    				unaryExpression458=unaryExpression();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression458.Tree, unaryExpression458, retval);

    				}
    				break;

    			default:
    				goto loop126;
    			}
    		}

    		loop126:
    			;

    		} finally { DebugExitSubRule(126); }


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
            if (state.backtracking > 0) { Memoize(input, 85, multiplicativeExpression_StartIndex); }
        }
     	DebugLocation(1067, 4);
    	} finally { DebugExitRule(GrammarFileName, "multiplicativeExpression"); }
    	return retval;

    }
    // $ANTLR end "multiplicativeExpression"

    public class unaryExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_unaryExpression() {}
    protected virtual void Leave_unaryExpression() {}

    // $ANTLR start "unaryExpression"
    // Java.g:1069:1: unaryExpression : ( '+' unaryExpression | '-' unaryExpression | '++' unaryExpression | '--' unaryExpression | unaryExpressionNotPlusMinus );
    [GrammarRule("unaryExpression")]
    public JavaParser.unaryExpression_return unaryExpression()
    {

        JavaParser.unaryExpression_return retval = new JavaParser.unaryExpression_return();
        retval.Start = (IToken)input.LT(1);
        int unaryExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal459=null;
        IToken char_literal461=null;
        IToken string_literal463=null;
        IToken string_literal465=null;
        JavaParser.unaryExpression_return unaryExpression460 = default(JavaParser.unaryExpression_return);
        JavaParser.unaryExpression_return unaryExpression462 = default(JavaParser.unaryExpression_return);
        JavaParser.unaryExpression_return unaryExpression464 = default(JavaParser.unaryExpression_return);
        JavaParser.unaryExpression_return unaryExpression466 = default(JavaParser.unaryExpression_return);
        JavaParser.unaryExpressionNotPlusMinus_return unaryExpressionNotPlusMinus467 = default(JavaParser.unaryExpressionNotPlusMinus_return);

        object char_literal459_tree=null;
        object char_literal461_tree=null;
        object string_literal463_tree=null;
        object string_literal465_tree=null;

    	try { DebugEnterRule(GrammarFileName, "unaryExpression");
    	DebugLocation(1069, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 86)) { return retval; }
    		// Java.g:1074:5: ( '+' unaryExpression | '-' unaryExpression | '++' unaryExpression | '--' unaryExpression | unaryExpressionNotPlusMinus )
    		int alt127=5;
    		try { DebugEnterDecision(127, decisionCanBacktrack[127]);
    		switch (input.LA(1))
    		{
    		case PLUS:
    			{
    			alt127=1;
    			}
    			break;
    		case SUB:
    			{
    			alt127=2;
    			}
    			break;
    		case PLUSPLUS:
    			{
    			alt127=3;
    			}
    			break;
    		case SUBSUB:
    			{
    			alt127=4;
    			}
    			break;
    		case IDENTIFIER:
    		case INTLITERAL:
    		case LONGLITERAL:
    		case FLOATLITERAL:
    		case DOUBLELITERAL:
    		case CHARLITERAL:
    		case STRINGLITERAL:
    		case TRUE:
    		case FALSE:
    		case NULL:
    		case BOOLEAN:
    		case BYTE:
    		case CHAR:
    		case DOUBLE:
    		case FLOAT:
    		case INT:
    		case LONG:
    		case NEW:
    		case SHORT:
    		case SUPER:
    		case THIS:
    		case VOID:
    		case LPAREN:
    		case BANG:
    		case TILDE:
    			{
    			alt127=5;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 127, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(127); }
    		switch (alt127)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1074:9: '+' unaryExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1074, 9);
    			char_literal459=(IToken)new XToken((IToken)Match(input,PLUS,Follow._PLUS_in_unaryExpression6360), "PLUS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal459_tree = (object)adaptor.Create(char_literal459, retval);
    			adaptor.AddChild(root_0, char_literal459_tree);
    			}
    			DebugLocation(1074, 14);
    			PushFollow(Follow._unaryExpression_in_unaryExpression6363);
    			unaryExpression460=unaryExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression460.Tree, unaryExpression460, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1075:9: '-' unaryExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1075, 9);
    			char_literal461=(IToken)new XToken((IToken)Match(input,SUB,Follow._SUB_in_unaryExpression6373), "SUB"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal461_tree = (object)adaptor.Create(char_literal461, retval);
    			adaptor.AddChild(root_0, char_literal461_tree);
    			}
    			DebugLocation(1075, 13);
    			PushFollow(Follow._unaryExpression_in_unaryExpression6375);
    			unaryExpression462=unaryExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression462.Tree, unaryExpression462, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1076:9: '++' unaryExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1076, 9);
    			string_literal463=(IToken)new XToken((IToken)Match(input,PLUSPLUS,Follow._PLUSPLUS_in_unaryExpression6385), "PLUSPLUS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal463_tree = (object)adaptor.Create(string_literal463, retval);
    			adaptor.AddChild(root_0, string_literal463_tree);
    			}
    			DebugLocation(1076, 14);
    			PushFollow(Follow._unaryExpression_in_unaryExpression6387);
    			unaryExpression464=unaryExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression464.Tree, unaryExpression464, retval);

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:1077:9: '--' unaryExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1077, 9);
    			string_literal465=(IToken)new XToken((IToken)Match(input,SUBSUB,Follow._SUBSUB_in_unaryExpression6397), "SUBSUB"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal465_tree = (object)adaptor.Create(string_literal465, retval);
    			adaptor.AddChild(root_0, string_literal465_tree);
    			}
    			DebugLocation(1077, 14);
    			PushFollow(Follow._unaryExpression_in_unaryExpression6399);
    			unaryExpression466=unaryExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression466.Tree, unaryExpression466, retval);

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:1078:9: unaryExpressionNotPlusMinus
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1078, 9);
    			PushFollow(Follow._unaryExpressionNotPlusMinus_in_unaryExpression6409);
    			unaryExpressionNotPlusMinus467=unaryExpressionNotPlusMinus();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpressionNotPlusMinus467.Tree, unaryExpressionNotPlusMinus467, retval);

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
            if (state.backtracking > 0) { Memoize(input, 86, unaryExpression_StartIndex); }
        }
     	DebugLocation(1079, 4);
    	} finally { DebugExitRule(GrammarFileName, "unaryExpression"); }
    	return retval;

    }
    // $ANTLR end "unaryExpression"

    public class unaryExpressionNotPlusMinus_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_unaryExpressionNotPlusMinus() {}
    protected virtual void Leave_unaryExpressionNotPlusMinus() {}

    // $ANTLR start "unaryExpressionNotPlusMinus"
    // Java.g:1081:1: unaryExpressionNotPlusMinus : ( '~' unaryExpression | '!' unaryExpression | castExpression | primary ( selector )* ( '++' | '--' )? );
    [GrammarRule("unaryExpressionNotPlusMinus")]
    public JavaParser.unaryExpressionNotPlusMinus_return unaryExpressionNotPlusMinus()
    {

        JavaParser.unaryExpressionNotPlusMinus_return retval = new JavaParser.unaryExpressionNotPlusMinus_return();
        retval.Start = (IToken)input.LT(1);
        int unaryExpressionNotPlusMinus_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal468=null;
        IToken char_literal470=null;
        IToken set475=null;
        JavaParser.unaryExpression_return unaryExpression469 = default(JavaParser.unaryExpression_return);
        JavaParser.unaryExpression_return unaryExpression471 = default(JavaParser.unaryExpression_return);
        JavaParser.castExpression_return castExpression472 = default(JavaParser.castExpression_return);
        JavaParser.primary_return primary473 = default(JavaParser.primary_return);
        JavaParser.selector_return selector474 = default(JavaParser.selector_return);

        object char_literal468_tree=null;
        object char_literal470_tree=null;
        object set475_tree=null;

    	try { DebugEnterRule(GrammarFileName, "unaryExpressionNotPlusMinus");
    	DebugLocation(1081, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 87)) { return retval; }
    		// Java.g:1082:5: ( '~' unaryExpression | '!' unaryExpression | castExpression | primary ( selector )* ( '++' | '--' )? )
    		int alt130=4;
    		try { DebugEnterDecision(130, decisionCanBacktrack[130]);
    		try
    		{
    			alt130 = dfa130.Predict(input);
    		}
    		catch (NoViableAltException nvae)
    		{
    			DebugRecognitionException(nvae);
    			throw;
    		}
    		} finally { DebugExitDecision(130); }
    		switch (alt130)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1082:9: '~' unaryExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1082, 9);
    			char_literal468=(IToken)new XToken((IToken)Match(input,TILDE,Follow._TILDE_in_unaryExpressionNotPlusMinus6429), "TILDE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal468_tree = (object)adaptor.Create(char_literal468, retval);
    			adaptor.AddChild(root_0, char_literal468_tree);
    			}
    			DebugLocation(1082, 13);
    			PushFollow(Follow._unaryExpression_in_unaryExpressionNotPlusMinus6431);
    			unaryExpression469=unaryExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression469.Tree, unaryExpression469, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1083:9: '!' unaryExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1083, 9);
    			char_literal470=(IToken)new XToken((IToken)Match(input,BANG,Follow._BANG_in_unaryExpressionNotPlusMinus6441), "BANG"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal470_tree = (object)adaptor.Create(char_literal470, retval);
    			adaptor.AddChild(root_0, char_literal470_tree);
    			}
    			DebugLocation(1083, 13);
    			PushFollow(Follow._unaryExpression_in_unaryExpressionNotPlusMinus6443);
    			unaryExpression471=unaryExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression471.Tree, unaryExpression471, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1084:9: castExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1084, 9);
    			PushFollow(Follow._castExpression_in_unaryExpressionNotPlusMinus6453);
    			castExpression472=castExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, castExpression472.Tree, castExpression472, retval);

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:1085:9: primary ( selector )* ( '++' | '--' )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1085, 9);
    			PushFollow(Follow._primary_in_unaryExpressionNotPlusMinus6463);
    			primary473=primary();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, primary473.Tree, primary473, retval);
    			DebugLocation(1086, 9);
    			// Java.g:1086:9: ( selector )*
    			try { DebugEnterSubRule(128);
    			while (true)
    			{
    				int alt128=2;
    				try { DebugEnterDecision(128, decisionCanBacktrack[128]);
    				int LA128_0 = input.LA(1);

    				if ((LA128_0==LBRACKET||LA128_0==DOT))
    				{
    					alt128=1;
    				}


    				} finally { DebugExitDecision(128); }
    				switch ( alt128 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1086:10: selector
    					{
    					DebugLocation(1086, 10);
    					PushFollow(Follow._selector_in_unaryExpressionNotPlusMinus6474);
    					selector474=selector();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, selector474.Tree, selector474, retval);

    					}
    					break;

    				default:
    					goto loop128;
    				}
    			}

    			loop128:
    				;

    			} finally { DebugExitSubRule(128); }

    			DebugLocation(1088, 9);
    			// Java.g:1088:9: ( '++' | '--' )?
    			int alt129=2;
    			try { DebugEnterSubRule(129);
    			try { DebugEnterDecision(129, decisionCanBacktrack[129]);
    			int LA129_0 = input.LA(1);

    			if (((LA129_0>=PLUSPLUS && LA129_0<=SUBSUB)))
    			{
    				alt129=1;
    			}
    			} finally { DebugExitDecision(129); }
    			switch (alt129)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:
    				{
    				DebugLocation(1088, 9);
    				set475=(IToken)input.LT(1);
    				if ((input.LA(1)>=PLUSPLUS && input.LA(1)<=SUBSUB))
    				{
    					input.Consume();
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set475, retval));
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
    			} finally { DebugExitSubRule(129); }


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
            if (state.backtracking > 0) { Memoize(input, 87, unaryExpressionNotPlusMinus_StartIndex); }
        }
     	DebugLocation(1091, 4);
    	} finally { DebugExitRule(GrammarFileName, "unaryExpressionNotPlusMinus"); }
    	return retval;

    }
    // $ANTLR end "unaryExpressionNotPlusMinus"

    public class castExpression_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_castExpression() {}
    protected virtual void Leave_castExpression() {}

    // $ANTLR start "castExpression"
    // Java.g:1093:1: castExpression : ( '(' primitiveType ')' unaryExpression | '(' type ')' unaryExpressionNotPlusMinus );
    [GrammarRule("castExpression")]
    public JavaParser.castExpression_return castExpression()
    {

        JavaParser.castExpression_return retval = new JavaParser.castExpression_return();
        retval.Start = (IToken)input.LT(1);
        int castExpression_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal476=null;
        IToken char_literal478=null;
        IToken char_literal480=null;
        IToken char_literal482=null;
        JavaParser.primitiveType_return primitiveType477 = default(JavaParser.primitiveType_return);
        JavaParser.unaryExpression_return unaryExpression479 = default(JavaParser.unaryExpression_return);
        JavaParser.type_return type481 = default(JavaParser.type_return);
        JavaParser.unaryExpressionNotPlusMinus_return unaryExpressionNotPlusMinus483 = default(JavaParser.unaryExpressionNotPlusMinus_return);

        object char_literal476_tree=null;
        object char_literal478_tree=null;
        object char_literal480_tree=null;
        object char_literal482_tree=null;

    	try { DebugEnterRule(GrammarFileName, "castExpression");
    	DebugLocation(1093, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 88)) { return retval; }
    		// Java.g:1094:5: ( '(' primitiveType ')' unaryExpression | '(' type ')' unaryExpressionNotPlusMinus )
    		int alt131=2;
    		try { DebugEnterDecision(131, decisionCanBacktrack[131]);
    		int LA131_0 = input.LA(1);

    		if ((LA131_0==LPAREN))
    		{
    			int LA131_1 = input.LA(2);

    			if ((EvaluatePredicate(synpred206_Java_fragment)))
    			{
    				alt131=1;
    			}
    			else if ((true))
    			{
    				alt131=2;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 131, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 131, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(131); }
    		switch (alt131)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1094:9: '(' primitiveType ')' unaryExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1094, 9);
    			char_literal476=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_castExpression6544), "LPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal476_tree = (object)adaptor.Create(char_literal476, retval);
    			adaptor.AddChild(root_0, char_literal476_tree);
    			}
    			DebugLocation(1094, 13);
    			PushFollow(Follow._primitiveType_in_castExpression6546);
    			primitiveType477=primitiveType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, primitiveType477.Tree, primitiveType477, retval);
    			DebugLocation(1094, 27);
    			char_literal478=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_castExpression6548), "RPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal478_tree = (object)adaptor.Create(char_literal478, retval);
    			adaptor.AddChild(root_0, char_literal478_tree);
    			}
    			DebugLocation(1094, 31);
    			PushFollow(Follow._unaryExpression_in_castExpression6550);
    			unaryExpression479=unaryExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpression479.Tree, unaryExpression479, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1095:9: '(' type ')' unaryExpressionNotPlusMinus
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1095, 9);
    			char_literal480=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_castExpression6560), "LPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal480_tree = (object)adaptor.Create(char_literal480, retval);
    			adaptor.AddChild(root_0, char_literal480_tree);
    			}
    			DebugLocation(1095, 13);
    			PushFollow(Follow._type_in_castExpression6562);
    			type481=type();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type481.Tree, type481, retval);
    			DebugLocation(1095, 18);
    			char_literal482=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_castExpression6564), "RPAREN"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal482_tree = (object)adaptor.Create(char_literal482, retval);
    			adaptor.AddChild(root_0, char_literal482_tree);
    			}
    			DebugLocation(1095, 22);
    			PushFollow(Follow._unaryExpressionNotPlusMinus_in_castExpression6566);
    			unaryExpressionNotPlusMinus483=unaryExpressionNotPlusMinus();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, unaryExpressionNotPlusMinus483.Tree, unaryExpressionNotPlusMinus483, retval);

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
            if (state.backtracking > 0) { Memoize(input, 88, castExpression_StartIndex); }
        }
     	DebugLocation(1096, 4);
    	} finally { DebugExitRule(GrammarFileName, "castExpression"); }
    	return retval;

    }
    // $ANTLR end "castExpression"

    public class primary_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_primary() {}
    protected virtual void Leave_primary() {}

    // $ANTLR start "primary"
    // Java.g:1098:1: primary : ( parExpression | 'this' ( '.' IDENTIFIER )* ( identifierSuffix )? | IDENTIFIER ( '.' IDENTIFIER )* ( identifierSuffix )? | 'super' superSuffix | literal | creator | primitiveType ( '[' ']' )* '.' 'class' | 'void' '.' 'class' );
    [GrammarRule("primary")]
    public JavaParser.primary_return primary()
    {

        JavaParser.primary_return retval = new JavaParser.primary_return();
        retval.Start = (IToken)input.LT(1);
        int primary_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal485=null;
        IToken char_literal486=null;
        IToken IDENTIFIER487=null;
        IToken IDENTIFIER489=null;
        IToken char_literal490=null;
        IToken IDENTIFIER491=null;
        IToken string_literal493=null;
        IToken char_literal498=null;
        IToken char_literal499=null;
        IToken char_literal500=null;
        IToken string_literal501=null;
        IToken string_literal502=null;
        IToken char_literal503=null;
        IToken string_literal504=null;
        JavaParser.parExpression_return parExpression484 = default(JavaParser.parExpression_return);
        JavaParser.identifierSuffix_return identifierSuffix488 = default(JavaParser.identifierSuffix_return);
        JavaParser.identifierSuffix_return identifierSuffix492 = default(JavaParser.identifierSuffix_return);
        JavaParser.superSuffix_return superSuffix494 = default(JavaParser.superSuffix_return);
        JavaParser.literal_return literal495 = default(JavaParser.literal_return);
        JavaParser.creator_return creator496 = default(JavaParser.creator_return);
        JavaParser.primitiveType_return primitiveType497 = default(JavaParser.primitiveType_return);

        object string_literal485_tree=null;
        object char_literal486_tree=null;
        object IDENTIFIER487_tree=null;
        object IDENTIFIER489_tree=null;
        object char_literal490_tree=null;
        object IDENTIFIER491_tree=null;
        object string_literal493_tree=null;
        object char_literal498_tree=null;
        object char_literal499_tree=null;
        object char_literal500_tree=null;
        object string_literal501_tree=null;
        object string_literal502_tree=null;
        object char_literal503_tree=null;
        object string_literal504_tree=null;

    	try { DebugEnterRule(GrammarFileName, "primary");
    	DebugLocation(1098, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 89)) { return retval; }
    		// Java.g:1102:5: ( parExpression | 'this' ( '.' IDENTIFIER )* ( identifierSuffix )? | IDENTIFIER ( '.' IDENTIFIER )* ( identifierSuffix )? | 'super' superSuffix | literal | creator | primitiveType ( '[' ']' )* '.' 'class' | 'void' '.' 'class' )
    		int alt137=8;
    		try { DebugEnterDecision(137, decisionCanBacktrack[137]);
    		switch (input.LA(1))
    		{
    		case LPAREN:
    			{
    			alt137=1;
    			}
    			break;
    		case THIS:
    			{
    			alt137=2;
    			}
    			break;
    		case IDENTIFIER:
    			{
    			alt137=3;
    			}
    			break;
    		case SUPER:
    			{
    			alt137=4;
    			}
    			break;
    		case INTLITERAL:
    		case LONGLITERAL:
    		case FLOATLITERAL:
    		case DOUBLELITERAL:
    		case CHARLITERAL:
    		case STRINGLITERAL:
    		case TRUE:
    		case FALSE:
    		case NULL:
    			{
    			alt137=5;
    			}
    			break;
    		case NEW:
    			{
    			alt137=6;
    			}
    			break;
    		case BOOLEAN:
    		case BYTE:
    		case CHAR:
    		case DOUBLE:
    		case FLOAT:
    		case INT:
    		case LONG:
    		case SHORT:
    			{
    			alt137=7;
    			}
    			break;
    		case VOID:
    			{
    			alt137=8;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 137, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(137); }
    		switch (alt137)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1102:9: parExpression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1102, 9);
    			PushFollow(Follow._parExpression_in_primary6588);
    			parExpression484=parExpression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, parExpression484.Tree, parExpression484, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1103:9: 'this' ( '.' IDENTIFIER )* ( identifierSuffix )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1103, 9);
    			string_literal485=(IToken)new XToken((IToken)Match(input,THIS,Follow._THIS_in_primary6610), "THIS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal485_tree = (object)adaptor.Create(string_literal485, retval);
    			adaptor.AddChild(root_0, string_literal485_tree);
    			}
    			DebugLocation(1104, 9);
    			// Java.g:1104:9: ( '.' IDENTIFIER )*
    			try { DebugEnterSubRule(132);
    			while (true)
    			{
    				int alt132=2;
    				try { DebugEnterDecision(132, decisionCanBacktrack[132]);
    				int LA132_0 = input.LA(1);

    				if ((LA132_0==DOT))
    				{
    					int LA132_2 = input.LA(2);

    					if ((LA132_2==IDENTIFIER))
    					{
    						int LA132_3 = input.LA(3);

    						if ((EvaluatePredicate(synpred208_Java_fragment)))
    						{
    							alt132=1;
    						}


    					}


    				}


    				} finally { DebugExitDecision(132); }
    				switch ( alt132 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1104:10: '.' IDENTIFIER
    					{
    					DebugLocation(1104, 10);
    					char_literal486=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_primary6621), "DOT"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal486_tree = (object)adaptor.Create(char_literal486, retval);
    					adaptor.AddChild(root_0, char_literal486_tree);
    					}
    					DebugLocation(1104, 14);
    					IDENTIFIER487=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_primary6623), "IDENTIFIER"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					IDENTIFIER487_tree = (object)adaptor.Create(IDENTIFIER487, retval);
    					adaptor.AddChild(root_0, IDENTIFIER487_tree);
    					}

    					}
    					break;

    				default:
    					goto loop132;
    				}
    			}

    			loop132:
    				;

    			} finally { DebugExitSubRule(132); }

    			DebugLocation(1106, 9);
    			// Java.g:1106:9: ( identifierSuffix )?
    			int alt133=2;
    			try { DebugEnterSubRule(133);
    			try { DebugEnterDecision(133, decisionCanBacktrack[133]);
    			try
    			{
    				alt133 = dfa133.Predict(input);
    			}
    			catch (NoViableAltException nvae)
    			{
    				DebugRecognitionException(nvae);
    				throw;
    			}
    			} finally { DebugExitDecision(133); }
    			switch (alt133)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1106:10: identifierSuffix
    				{
    				DebugLocation(1106, 10);
    				PushFollow(Follow._identifierSuffix_in_primary6645);
    				identifierSuffix488=identifierSuffix();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, identifierSuffix488.Tree, identifierSuffix488, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(133); }


    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1108:9: IDENTIFIER ( '.' IDENTIFIER )* ( identifierSuffix )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1108, 9);
    			IDENTIFIER489=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_primary6666), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER489_tree = (object)adaptor.Create(IDENTIFIER489, retval);
    			adaptor.AddChild(root_0, IDENTIFIER489_tree);
    			}
    			DebugLocation(1109, 9);
    			// Java.g:1109:9: ( '.' IDENTIFIER )*
    			try { DebugEnterSubRule(134);
    			while (true)
    			{
    				int alt134=2;
    				try { DebugEnterDecision(134, decisionCanBacktrack[134]);
    				int LA134_0 = input.LA(1);

    				if ((LA134_0==DOT))
    				{
    					int LA134_2 = input.LA(2);

    					if ((LA134_2==IDENTIFIER))
    					{
    						int LA134_3 = input.LA(3);

    						if ((EvaluatePredicate(synpred211_Java_fragment)))
    						{
    							alt134=1;
    						}


    					}


    				}


    				} finally { DebugExitDecision(134); }
    				switch ( alt134 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1109:10: '.' IDENTIFIER
    					{
    					DebugLocation(1109, 10);
    					char_literal490=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_primary6677), "DOT"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal490_tree = (object)adaptor.Create(char_literal490, retval);
    					adaptor.AddChild(root_0, char_literal490_tree);
    					}
    					DebugLocation(1109, 14);
    					IDENTIFIER491=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_primary6679), "IDENTIFIER"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					IDENTIFIER491_tree = (object)adaptor.Create(IDENTIFIER491, retval);
    					adaptor.AddChild(root_0, IDENTIFIER491_tree);
    					}

    					}
    					break;

    				default:
    					goto loop134;
    				}
    			}

    			loop134:
    				;

    			} finally { DebugExitSubRule(134); }

    			DebugLocation(1111, 9);
    			// Java.g:1111:9: ( identifierSuffix )?
    			int alt135=2;
    			try { DebugEnterSubRule(135);
    			try { DebugEnterDecision(135, decisionCanBacktrack[135]);
    			try
    			{
    				alt135 = dfa135.Predict(input);
    			}
    			catch (NoViableAltException nvae)
    			{
    				DebugRecognitionException(nvae);
    				throw;
    			}
    			} finally { DebugExitDecision(135); }
    			switch (alt135)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1111:10: identifierSuffix
    				{
    				DebugLocation(1111, 10);
    				PushFollow(Follow._identifierSuffix_in_primary6701);
    				identifierSuffix492=identifierSuffix();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, identifierSuffix492.Tree, identifierSuffix492, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(135); }


    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:1113:9: 'super' superSuffix
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1113, 9);
    			string_literal493=(IToken)new XToken((IToken)Match(input,SUPER,Follow._SUPER_in_primary6722), "SUPER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal493_tree = (object)adaptor.Create(string_literal493, retval);
    			adaptor.AddChild(root_0, string_literal493_tree);
    			}
    			DebugLocation(1114, 9);
    			PushFollow(Follow._superSuffix_in_primary6732);
    			superSuffix494=superSuffix();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, superSuffix494.Tree, superSuffix494, retval);

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:1115:9: literal
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1115, 9);
    			PushFollow(Follow._literal_in_primary6742);
    			literal495=literal();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, literal495.Tree, literal495, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Java.g:1116:9: creator
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1116, 9);
    			PushFollow(Follow._creator_in_primary6752);
    			creator496=creator();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, creator496.Tree, creator496, retval);

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Java.g:1117:9: primitiveType ( '[' ']' )* '.' 'class'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1117, 9);
    			PushFollow(Follow._primitiveType_in_primary6762);
    			primitiveType497=primitiveType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, primitiveType497.Tree, primitiveType497, retval);
    			DebugLocation(1118, 9);
    			// Java.g:1118:9: ( '[' ']' )*
    			try { DebugEnterSubRule(136);
    			while (true)
    			{
    				int alt136=2;
    				try { DebugEnterDecision(136, decisionCanBacktrack[136]);
    				int LA136_0 = input.LA(1);

    				if ((LA136_0==LBRACKET))
    				{
    					alt136=1;
    				}


    				} finally { DebugExitDecision(136); }
    				switch ( alt136 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1118:10: '[' ']'
    					{
    					DebugLocation(1118, 10);
    					char_literal498=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_primary6773), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal498_tree = (object)adaptor.Create(char_literal498, retval);
    					adaptor.AddChild(root_0, char_literal498_tree);
    					}
    					DebugLocation(1118, 14);
    					char_literal499=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_primary6775), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal499_tree = (object)adaptor.Create(char_literal499, retval);
    					adaptor.AddChild(root_0, char_literal499_tree);
    					}

    					}
    					break;

    				default:
    					goto loop136;
    				}
    			}

    			loop136:
    				;

    			} finally { DebugExitSubRule(136); }

    			DebugLocation(1120, 9);
    			char_literal500=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_primary6796), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal500_tree = (object)adaptor.Create(char_literal500, retval);
    			adaptor.AddChild(root_0, char_literal500_tree);
    			}
    			DebugLocation(1120, 13);
    			string_literal501=(IToken)new XToken((IToken)Match(input,CLASS,Follow._CLASS_in_primary6798), "CLASS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal501_tree = (object)adaptor.Create(string_literal501, retval);
    			adaptor.AddChild(root_0, string_literal501_tree);
    			}

    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// Java.g:1121:9: 'void' '.' 'class'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1121, 9);
    			string_literal502=(IToken)new XToken((IToken)Match(input,VOID,Follow._VOID_in_primary6808), "VOID"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal502_tree = (object)adaptor.Create(string_literal502, retval);
    			adaptor.AddChild(root_0, string_literal502_tree);
    			}
    			DebugLocation(1121, 16);
    			char_literal503=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_primary6810), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal503_tree = (object)adaptor.Create(char_literal503, retval);
    			adaptor.AddChild(root_0, char_literal503_tree);
    			}
    			DebugLocation(1121, 20);
    			string_literal504=(IToken)new XToken((IToken)Match(input,CLASS,Follow._CLASS_in_primary6812), "CLASS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal504_tree = (object)adaptor.Create(string_literal504, retval);
    			adaptor.AddChild(root_0, string_literal504_tree);
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
            if (state.backtracking > 0) { Memoize(input, 89, primary_StartIndex); }
        }
     	DebugLocation(1122, 4);
    	} finally { DebugExitRule(GrammarFileName, "primary"); }
    	return retval;

    }
    // $ANTLR end "primary"

    public class superSuffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_superSuffix() {}
    protected virtual void Leave_superSuffix() {}

    // $ANTLR start "superSuffix"
    // Java.g:1125:1: superSuffix : ( arguments | '.' ( typeArguments )? IDENTIFIER ( arguments )? );
    [GrammarRule("superSuffix")]
    public JavaParser.superSuffix_return superSuffix()
    {

        JavaParser.superSuffix_return retval = new JavaParser.superSuffix_return();
        retval.Start = (IToken)input.LT(1);
        int superSuffix_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal506=null;
        IToken IDENTIFIER508=null;
        JavaParser.arguments_return arguments505 = default(JavaParser.arguments_return);
        JavaParser.typeArguments_return typeArguments507 = default(JavaParser.typeArguments_return);
        JavaParser.arguments_return arguments509 = default(JavaParser.arguments_return);

        object char_literal506_tree=null;
        object IDENTIFIER508_tree=null;

    	try { DebugEnterRule(GrammarFileName, "superSuffix");
    	DebugLocation(1125, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 90)) { return retval; }
    		// Java.g:1126:5: ( arguments | '.' ( typeArguments )? IDENTIFIER ( arguments )? )
    		int alt140=2;
    		try { DebugEnterDecision(140, decisionCanBacktrack[140]);
    		int LA140_0 = input.LA(1);

    		if ((LA140_0==LPAREN))
    		{
    			alt140=1;
    		}
    		else if ((LA140_0==DOT))
    		{
    			alt140=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 140, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(140); }
    		switch (alt140)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1126:9: arguments
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1126, 9);
    			PushFollow(Follow._arguments_in_superSuffix6838);
    			arguments505=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments505.Tree, arguments505, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1127:9: '.' ( typeArguments )? IDENTIFIER ( arguments )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1127, 9);
    			char_literal506=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_superSuffix6848), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal506_tree = (object)adaptor.Create(char_literal506, retval);
    			adaptor.AddChild(root_0, char_literal506_tree);
    			}
    			DebugLocation(1127, 13);
    			// Java.g:1127:13: ( typeArguments )?
    			int alt138=2;
    			try { DebugEnterSubRule(138);
    			try { DebugEnterDecision(138, decisionCanBacktrack[138]);
    			int LA138_0 = input.LA(1);

    			if ((LA138_0==LT))
    			{
    				alt138=1;
    			}
    			} finally { DebugExitDecision(138); }
    			switch (alt138)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1127:14: typeArguments
    				{
    				DebugLocation(1127, 14);
    				PushFollow(Follow._typeArguments_in_superSuffix6851);
    				typeArguments507=typeArguments();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeArguments507.Tree, typeArguments507, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(138); }

    			DebugLocation(1129, 9);
    			IDENTIFIER508=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_superSuffix6872), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER508_tree = (object)adaptor.Create(IDENTIFIER508, retval);
    			adaptor.AddChild(root_0, IDENTIFIER508_tree);
    			}
    			DebugLocation(1130, 9);
    			// Java.g:1130:9: ( arguments )?
    			int alt139=2;
    			try { DebugEnterSubRule(139);
    			try { DebugEnterDecision(139, decisionCanBacktrack[139]);
    			int LA139_0 = input.LA(1);

    			if ((LA139_0==LPAREN))
    			{
    				alt139=1;
    			}
    			} finally { DebugExitDecision(139); }
    			switch (alt139)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1130:10: arguments
    				{
    				DebugLocation(1130, 10);
    				PushFollow(Follow._arguments_in_superSuffix6883);
    				arguments509=arguments();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments509.Tree, arguments509, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(139); }


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
            if (state.backtracking > 0) { Memoize(input, 90, superSuffix_StartIndex); }
        }
     	DebugLocation(1132, 4);
    	} finally { DebugExitRule(GrammarFileName, "superSuffix"); }
    	return retval;

    }
    // $ANTLR end "superSuffix"

    public class identifierSuffix_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_identifierSuffix() {}
    protected virtual void Leave_identifierSuffix() {}

    // $ANTLR start "identifierSuffix"
    // Java.g:1135:1: identifierSuffix : ( ( '[' ']' )+ '.' 'class' | ( '[' expression ']' )+ | arguments | '.' 'class' | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' arguments | innerCreator );
    [GrammarRule("identifierSuffix")]
    public JavaParser.identifierSuffix_return identifierSuffix()
    {

        JavaParser.identifierSuffix_return retval = new JavaParser.identifierSuffix_return();
        retval.Start = (IToken)input.LT(1);
        int identifierSuffix_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal510=null;
        IToken char_literal511=null;
        IToken char_literal512=null;
        IToken string_literal513=null;
        IToken char_literal514=null;
        IToken char_literal516=null;
        IToken char_literal518=null;
        IToken string_literal519=null;
        IToken char_literal520=null;
        IToken IDENTIFIER522=null;
        IToken char_literal524=null;
        IToken string_literal525=null;
        IToken char_literal526=null;
        IToken string_literal527=null;
        JavaParser.expression_return expression515 = default(JavaParser.expression_return);
        JavaParser.arguments_return arguments517 = default(JavaParser.arguments_return);
        JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments521 = default(JavaParser.nonWildcardTypeArguments_return);
        JavaParser.arguments_return arguments523 = default(JavaParser.arguments_return);
        JavaParser.arguments_return arguments528 = default(JavaParser.arguments_return);
        JavaParser.innerCreator_return innerCreator529 = default(JavaParser.innerCreator_return);

        object char_literal510_tree=null;
        object char_literal511_tree=null;
        object char_literal512_tree=null;
        object string_literal513_tree=null;
        object char_literal514_tree=null;
        object char_literal516_tree=null;
        object char_literal518_tree=null;
        object string_literal519_tree=null;
        object char_literal520_tree=null;
        object IDENTIFIER522_tree=null;
        object char_literal524_tree=null;
        object string_literal525_tree=null;
        object char_literal526_tree=null;
        object string_literal527_tree=null;

    	try { DebugEnterRule(GrammarFileName, "identifierSuffix");
    	DebugLocation(1135, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 91)) { return retval; }
    		// Java.g:1136:5: ( ( '[' ']' )+ '.' 'class' | ( '[' expression ']' )+ | arguments | '.' 'class' | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' arguments | innerCreator )
    		int alt143=8;
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
    		switch (alt143)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1136:9: ( '[' ']' )+ '.' 'class'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1136, 9);
    			// Java.g:1136:9: ( '[' ']' )+
    			int cnt141=0;
    			try { DebugEnterSubRule(141);
    			while (true)
    			{
    				int alt141=2;
    				try { DebugEnterDecision(141, decisionCanBacktrack[141]);
    				int LA141_0 = input.LA(1);

    				if ((LA141_0==LBRACKET))
    				{
    					alt141=1;
    				}


    				} finally { DebugExitDecision(141); }
    				switch (alt141)
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1136:10: '[' ']'
    					{
    					DebugLocation(1136, 10);
    					char_literal510=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_identifierSuffix6916), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal510_tree = (object)adaptor.Create(char_literal510, retval);
    					adaptor.AddChild(root_0, char_literal510_tree);
    					}
    					DebugLocation(1136, 14);
    					char_literal511=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_identifierSuffix6918), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal511_tree = (object)adaptor.Create(char_literal511, retval);
    					adaptor.AddChild(root_0, char_literal511_tree);
    					}

    					}
    					break;

    				default:
    					if (cnt141 >= 1)
    						goto loop141;

    					if (state.backtracking>0) {state.failed=true; return retval;}
    					EarlyExitException eee141 = new EarlyExitException( 141, input );
    					DebugRecognitionException(eee141);
    					throw eee141;
    				}
    				cnt141++;
    			}
    			loop141:
    				;

    			} finally { DebugExitSubRule(141); }

    			DebugLocation(1138, 9);
    			char_literal512=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_identifierSuffix6939), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal512_tree = (object)adaptor.Create(char_literal512, retval);
    			adaptor.AddChild(root_0, char_literal512_tree);
    			}
    			DebugLocation(1138, 13);
    			string_literal513=(IToken)new XToken((IToken)Match(input,CLASS,Follow._CLASS_in_identifierSuffix6941), "CLASS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal513_tree = (object)adaptor.Create(string_literal513, retval);
    			adaptor.AddChild(root_0, string_literal513_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1139:9: ( '[' expression ']' )+
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1139, 9);
    			// Java.g:1139:9: ( '[' expression ']' )+
    			int cnt142=0;
    			try { DebugEnterSubRule(142);
    			while (true)
    			{
    				int alt142=2;
    				try { DebugEnterDecision(142, decisionCanBacktrack[142]);
    				try
    				{
    					alt142 = dfa142.Predict(input);
    				}
    				catch (NoViableAltException nvae)
    				{
    					DebugRecognitionException(nvae);
    					throw;
    				}
    				} finally { DebugExitDecision(142); }
    				switch (alt142)
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1139:10: '[' expression ']'
    					{
    					DebugLocation(1139, 10);
    					char_literal514=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_identifierSuffix6952), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal514_tree = (object)adaptor.Create(char_literal514, retval);
    					adaptor.AddChild(root_0, char_literal514_tree);
    					}
    					DebugLocation(1139, 14);
    					PushFollow(Follow._expression_in_identifierSuffix6954);
    					expression515=expression();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression515.Tree, expression515, retval);
    					DebugLocation(1139, 25);
    					char_literal516=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_identifierSuffix6956), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal516_tree = (object)adaptor.Create(char_literal516, retval);
    					adaptor.AddChild(root_0, char_literal516_tree);
    					}

    					}
    					break;

    				default:
    					if (cnt142 >= 1)
    						goto loop142;

    					if (state.backtracking>0) {state.failed=true; return retval;}
    					EarlyExitException eee142 = new EarlyExitException( 142, input );
    					DebugRecognitionException(eee142);
    					throw eee142;
    				}
    				cnt142++;
    			}
    			loop142:
    				;

    			} finally { DebugExitSubRule(142); }


    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1141:9: arguments
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1141, 9);
    			PushFollow(Follow._arguments_in_identifierSuffix6977);
    			arguments517=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments517.Tree, arguments517, retval);

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:1142:9: '.' 'class'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1142, 9);
    			char_literal518=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_identifierSuffix6987), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal518_tree = (object)adaptor.Create(char_literal518, retval);
    			adaptor.AddChild(root_0, char_literal518_tree);
    			}
    			DebugLocation(1142, 13);
    			string_literal519=(IToken)new XToken((IToken)Match(input,CLASS,Follow._CLASS_in_identifierSuffix6989), "CLASS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal519_tree = (object)adaptor.Create(string_literal519, retval);
    			adaptor.AddChild(root_0, string_literal519_tree);
    			}

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:1143:9: '.' nonWildcardTypeArguments IDENTIFIER arguments
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1143, 9);
    			char_literal520=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_identifierSuffix6999), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal520_tree = (object)adaptor.Create(char_literal520, retval);
    			adaptor.AddChild(root_0, char_literal520_tree);
    			}
    			DebugLocation(1143, 13);
    			PushFollow(Follow._nonWildcardTypeArguments_in_identifierSuffix7001);
    			nonWildcardTypeArguments521=nonWildcardTypeArguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nonWildcardTypeArguments521.Tree, nonWildcardTypeArguments521, retval);
    			DebugLocation(1143, 38);
    			IDENTIFIER522=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_identifierSuffix7003), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER522_tree = (object)adaptor.Create(IDENTIFIER522, retval);
    			adaptor.AddChild(root_0, IDENTIFIER522_tree);
    			}
    			DebugLocation(1143, 49);
    			PushFollow(Follow._arguments_in_identifierSuffix7005);
    			arguments523=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments523.Tree, arguments523, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Java.g:1144:9: '.' 'this'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1144, 9);
    			char_literal524=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_identifierSuffix7015), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal524_tree = (object)adaptor.Create(char_literal524, retval);
    			adaptor.AddChild(root_0, char_literal524_tree);
    			}
    			DebugLocation(1144, 13);
    			string_literal525=(IToken)new XToken((IToken)Match(input,THIS,Follow._THIS_in_identifierSuffix7017), "THIS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal525_tree = (object)adaptor.Create(string_literal525, retval);
    			adaptor.AddChild(root_0, string_literal525_tree);
    			}

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Java.g:1145:9: '.' 'super' arguments
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1145, 9);
    			char_literal526=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_identifierSuffix7027), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal526_tree = (object)adaptor.Create(char_literal526, retval);
    			adaptor.AddChild(root_0, char_literal526_tree);
    			}
    			DebugLocation(1145, 13);
    			string_literal527=(IToken)new XToken((IToken)Match(input,SUPER,Follow._SUPER_in_identifierSuffix7029), "SUPER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal527_tree = (object)adaptor.Create(string_literal527, retval);
    			adaptor.AddChild(root_0, string_literal527_tree);
    			}
    			DebugLocation(1145, 21);
    			PushFollow(Follow._arguments_in_identifierSuffix7031);
    			arguments528=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments528.Tree, arguments528, retval);

    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// Java.g:1146:9: innerCreator
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1146, 9);
    			PushFollow(Follow._innerCreator_in_identifierSuffix7041);
    			innerCreator529=innerCreator();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, innerCreator529.Tree, innerCreator529, retval);

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
            if (state.backtracking > 0) { Memoize(input, 91, identifierSuffix_StartIndex); }
        }
     	DebugLocation(1147, 4);
    	} finally { DebugExitRule(GrammarFileName, "identifierSuffix"); }
    	return retval;

    }
    // $ANTLR end "identifierSuffix"

    public class selector_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_selector() {}
    protected virtual void Leave_selector() {}

    // $ANTLR start "selector"
    // Java.g:1150:1: selector : ( '.' IDENTIFIER ( arguments )? | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' superSuffix | innerCreator | '[' expression ']' );
    [GrammarRule("selector")]
    public JavaParser.selector_return selector()
    {

        JavaParser.selector_return retval = new JavaParser.selector_return();
        retval.Start = (IToken)input.LT(1);
        int selector_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal530=null;
        IToken IDENTIFIER531=null;
        IToken char_literal533=null;
        IToken IDENTIFIER535=null;
        IToken char_literal537=null;
        IToken string_literal538=null;
        IToken char_literal539=null;
        IToken string_literal540=null;
        IToken char_literal543=null;
        IToken char_literal545=null;
        JavaParser.arguments_return arguments532 = default(JavaParser.arguments_return);
        JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments534 = default(JavaParser.nonWildcardTypeArguments_return);
        JavaParser.arguments_return arguments536 = default(JavaParser.arguments_return);
        JavaParser.superSuffix_return superSuffix541 = default(JavaParser.superSuffix_return);
        JavaParser.innerCreator_return innerCreator542 = default(JavaParser.innerCreator_return);
        JavaParser.expression_return expression544 = default(JavaParser.expression_return);

        object char_literal530_tree=null;
        object IDENTIFIER531_tree=null;
        object char_literal533_tree=null;
        object IDENTIFIER535_tree=null;
        object char_literal537_tree=null;
        object string_literal538_tree=null;
        object char_literal539_tree=null;
        object string_literal540_tree=null;
        object char_literal543_tree=null;
        object char_literal545_tree=null;

    	try { DebugEnterRule(GrammarFileName, "selector");
    	DebugLocation(1150, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 92)) { return retval; }
    		// Java.g:1151:5: ( '.' IDENTIFIER ( arguments )? | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' superSuffix | innerCreator | '[' expression ']' )
    		int alt145=6;
    		try { DebugEnterDecision(145, decisionCanBacktrack[145]);
    		int LA145_0 = input.LA(1);

    		if ((LA145_0==DOT))
    		{
    			switch (input.LA(2))
    			{
    			case IDENTIFIER:
    				{
    				alt145=1;
    				}
    				break;
    			case THIS:
    				{
    				alt145=3;
    				}
    				break;
    			case SUPER:
    				{
    				alt145=4;
    				}
    				break;
    			case NEW:
    				{
    				alt145=5;
    				}
    				break;
    			case LT:
    				{
    				alt145=2;
    				}
    				break;
    			default:
    				{
    					if (state.backtracking>0) {state.failed=true; return retval;}
    					NoViableAltException nvae = new NoViableAltException("", 145, 1, input);

    					DebugRecognitionException(nvae);
    					throw nvae;
    				}
    			}

    		}
    		else if ((LA145_0==LBRACKET))
    		{
    			alt145=6;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 145, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(145); }
    		switch (alt145)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1151:9: '.' IDENTIFIER ( arguments )?
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1151, 9);
    			char_literal530=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_selector7063), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal530_tree = (object)adaptor.Create(char_literal530, retval);
    			adaptor.AddChild(root_0, char_literal530_tree);
    			}
    			DebugLocation(1151, 13);
    			IDENTIFIER531=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_selector7065), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER531_tree = (object)adaptor.Create(IDENTIFIER531, retval);
    			adaptor.AddChild(root_0, IDENTIFIER531_tree);
    			}
    			DebugLocation(1151, 24);
    			// Java.g:1151:24: ( arguments )?
    			int alt144=2;
    			try { DebugEnterSubRule(144);
    			try { DebugEnterDecision(144, decisionCanBacktrack[144]);
    			int LA144_0 = input.LA(1);

    			if ((LA144_0==LPAREN))
    			{
    				alt144=1;
    			}
    			} finally { DebugExitDecision(144); }
    			switch (alt144)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:0:0: arguments
    				{
    				DebugLocation(1151, 24);
    				PushFollow(Follow._arguments_in_selector7067);
    				arguments532=arguments();
    				PopFollow();
    				if (state.failed) return retval;
    				if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments532.Tree, arguments532, retval);

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(144); }


    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1152:9: '.' nonWildcardTypeArguments IDENTIFIER arguments
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1152, 9);
    			char_literal533=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_selector7078), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal533_tree = (object)adaptor.Create(char_literal533, retval);
    			adaptor.AddChild(root_0, char_literal533_tree);
    			}
    			DebugLocation(1152, 13);
    			PushFollow(Follow._nonWildcardTypeArguments_in_selector7080);
    			nonWildcardTypeArguments534=nonWildcardTypeArguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nonWildcardTypeArguments534.Tree, nonWildcardTypeArguments534, retval);
    			DebugLocation(1152, 38);
    			IDENTIFIER535=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_selector7082), "IDENTIFIER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			IDENTIFIER535_tree = (object)adaptor.Create(IDENTIFIER535, retval);
    			adaptor.AddChild(root_0, IDENTIFIER535_tree);
    			}
    			DebugLocation(1152, 49);
    			PushFollow(Follow._arguments_in_selector7084);
    			arguments536=arguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments536.Tree, arguments536, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1153:9: '.' 'this'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1153, 9);
    			char_literal537=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_selector7095), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal537_tree = (object)adaptor.Create(char_literal537, retval);
    			adaptor.AddChild(root_0, char_literal537_tree);
    			}
    			DebugLocation(1153, 13);
    			string_literal538=(IToken)new XToken((IToken)Match(input,THIS,Follow._THIS_in_selector7097), "THIS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal538_tree = (object)adaptor.Create(string_literal538, retval);
    			adaptor.AddChild(root_0, string_literal538_tree);
    			}

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:1154:9: '.' 'super' superSuffix
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1154, 9);
    			char_literal539=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_selector7107), "DOT"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal539_tree = (object)adaptor.Create(char_literal539, retval);
    			adaptor.AddChild(root_0, char_literal539_tree);
    			}
    			DebugLocation(1154, 13);
    			string_literal540=(IToken)new XToken((IToken)Match(input,SUPER,Follow._SUPER_in_selector7109), "SUPER"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal540_tree = (object)adaptor.Create(string_literal540, retval);
    			adaptor.AddChild(root_0, string_literal540_tree);
    			}
    			DebugLocation(1155, 9);
    			PushFollow(Follow._superSuffix_in_selector7119);
    			superSuffix541=superSuffix();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, superSuffix541.Tree, superSuffix541, retval);

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:1156:9: innerCreator
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1156, 9);
    			PushFollow(Follow._innerCreator_in_selector7129);
    			innerCreator542=innerCreator();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, innerCreator542.Tree, innerCreator542, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Java.g:1157:9: '[' expression ']'
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1157, 9);
    			char_literal543=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_selector7139), "LBRACKET"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal543_tree = (object)adaptor.Create(char_literal543, retval);
    			adaptor.AddChild(root_0, char_literal543_tree);
    			}
    			DebugLocation(1157, 13);
    			PushFollow(Follow._expression_in_selector7141);
    			expression544=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression544.Tree, expression544, retval);
    			DebugLocation(1157, 24);
    			char_literal545=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_selector7143), "RBRACKET"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal545_tree = (object)adaptor.Create(char_literal545, retval);
    			adaptor.AddChild(root_0, char_literal545_tree);
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
            if (state.backtracking > 0) { Memoize(input, 92, selector_StartIndex); }
        }
     	DebugLocation(1158, 4);
    	} finally { DebugExitRule(GrammarFileName, "selector"); }
    	return retval;

    }
    // $ANTLR end "selector"

    public class creator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_creator() {}
    protected virtual void Leave_creator() {}

    // $ANTLR start "creator"
    // Java.g:1160:1: creator : ( 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest | 'new' classOrInterfaceType classCreatorRest | arrayCreator );
    [GrammarRule("creator")]
    public JavaParser.creator_return creator()
    {

        JavaParser.creator_return retval = new JavaParser.creator_return();
        retval.Start = (IToken)input.LT(1);
        int creator_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal546=null;
        IToken string_literal550=null;
        JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments547 = default(JavaParser.nonWildcardTypeArguments_return);
        JavaParser.classOrInterfaceType_return classOrInterfaceType548 = default(JavaParser.classOrInterfaceType_return);
        JavaParser.classCreatorRest_return classCreatorRest549 = default(JavaParser.classCreatorRest_return);
        JavaParser.classOrInterfaceType_return classOrInterfaceType551 = default(JavaParser.classOrInterfaceType_return);
        JavaParser.classCreatorRest_return classCreatorRest552 = default(JavaParser.classCreatorRest_return);
        JavaParser.arrayCreator_return arrayCreator553 = default(JavaParser.arrayCreator_return);

        object string_literal546_tree=null;
        object string_literal550_tree=null;

    	try { DebugEnterRule(GrammarFileName, "creator");
    	DebugLocation(1160, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 93)) { return retval; }
    		// Java.g:1161:5: ( 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest | 'new' classOrInterfaceType classCreatorRest | arrayCreator )
    		int alt146=3;
    		try { DebugEnterDecision(146, decisionCanBacktrack[146]);
    		int LA146_0 = input.LA(1);

    		if ((LA146_0==NEW))
    		{
    			int LA146_1 = input.LA(2);

    			if ((EvaluatePredicate(synpred237_Java_fragment)))
    			{
    				alt146=1;
    			}
    			else if ((EvaluatePredicate(synpred238_Java_fragment)))
    			{
    				alt146=2;
    			}
    			else if ((true))
    			{
    				alt146=3;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 146, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 146, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(146); }
    		switch (alt146)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1161:9: 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1161, 9);
    			string_literal546=(IToken)new XToken((IToken)Match(input,NEW,Follow._NEW_in_creator7163), "NEW"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal546_tree = (object)adaptor.Create(string_literal546, retval);
    			adaptor.AddChild(root_0, string_literal546_tree);
    			}
    			DebugLocation(1161, 15);
    			PushFollow(Follow._nonWildcardTypeArguments_in_creator7165);
    			nonWildcardTypeArguments547=nonWildcardTypeArguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nonWildcardTypeArguments547.Tree, nonWildcardTypeArguments547, retval);
    			DebugLocation(1161, 40);
    			PushFollow(Follow._classOrInterfaceType_in_creator7167);
    			classOrInterfaceType548=classOrInterfaceType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classOrInterfaceType548.Tree, classOrInterfaceType548, retval);
    			DebugLocation(1161, 61);
    			PushFollow(Follow._classCreatorRest_in_creator7169);
    			classCreatorRest549=classCreatorRest();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classCreatorRest549.Tree, classCreatorRest549, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1162:9: 'new' classOrInterfaceType classCreatorRest
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1162, 9);
    			string_literal550=(IToken)new XToken((IToken)Match(input,NEW,Follow._NEW_in_creator7179), "NEW"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal550_tree = (object)adaptor.Create(string_literal550, retval);
    			adaptor.AddChild(root_0, string_literal550_tree);
    			}
    			DebugLocation(1162, 15);
    			PushFollow(Follow._classOrInterfaceType_in_creator7181);
    			classOrInterfaceType551=classOrInterfaceType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classOrInterfaceType551.Tree, classOrInterfaceType551, retval);
    			DebugLocation(1162, 36);
    			PushFollow(Follow._classCreatorRest_in_creator7183);
    			classCreatorRest552=classCreatorRest();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classCreatorRest552.Tree, classCreatorRest552, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1163:9: arrayCreator
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1163, 9);
    			PushFollow(Follow._arrayCreator_in_creator7193);
    			arrayCreator553=arrayCreator();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arrayCreator553.Tree, arrayCreator553, retval);

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
            if (state.backtracking > 0) { Memoize(input, 93, creator_StartIndex); }
        }
     	DebugLocation(1164, 4);
    	} finally { DebugExitRule(GrammarFileName, "creator"); }
    	return retval;

    }
    // $ANTLR end "creator"

    public class arrayCreator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_arrayCreator() {}
    protected virtual void Leave_arrayCreator() {}

    // $ANTLR start "arrayCreator"
    // Java.g:1166:1: arrayCreator : ( 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer | 'new' createdName '[' expression ']' ( '[' expression ']' )* ( '[' ']' )* );
    [GrammarRule("arrayCreator")]
    public JavaParser.arrayCreator_return arrayCreator()
    {

        JavaParser.arrayCreator_return retval = new JavaParser.arrayCreator_return();
        retval.Start = (IToken)input.LT(1);
        int arrayCreator_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal554=null;
        IToken char_literal556=null;
        IToken char_literal557=null;
        IToken char_literal558=null;
        IToken char_literal559=null;
        IToken string_literal561=null;
        IToken char_literal563=null;
        IToken char_literal565=null;
        IToken char_literal566=null;
        IToken char_literal568=null;
        IToken char_literal569=null;
        IToken char_literal570=null;
        JavaParser.createdName_return createdName555 = default(JavaParser.createdName_return);
        JavaParser.arrayInitializer_return arrayInitializer560 = default(JavaParser.arrayInitializer_return);
        JavaParser.createdName_return createdName562 = default(JavaParser.createdName_return);
        JavaParser.expression_return expression564 = default(JavaParser.expression_return);
        JavaParser.expression_return expression567 = default(JavaParser.expression_return);

        object string_literal554_tree=null;
        object char_literal556_tree=null;
        object char_literal557_tree=null;
        object char_literal558_tree=null;
        object char_literal559_tree=null;
        object string_literal561_tree=null;
        object char_literal563_tree=null;
        object char_literal565_tree=null;
        object char_literal566_tree=null;
        object char_literal568_tree=null;
        object char_literal569_tree=null;
        object char_literal570_tree=null;

    	try { DebugEnterRule(GrammarFileName, "arrayCreator");
    	DebugLocation(1166, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 94)) { return retval; }
    		// Java.g:1167:5: ( 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer | 'new' createdName '[' expression ']' ( '[' expression ']' )* ( '[' ']' )* )
    		int alt150=2;
    		try { DebugEnterDecision(150, decisionCanBacktrack[150]);
    		int LA150_0 = input.LA(1);

    		if ((LA150_0==NEW))
    		{
    			int LA150_1 = input.LA(2);

    			if ((EvaluatePredicate(synpred240_Java_fragment)))
    			{
    				alt150=1;
    			}
    			else if ((true))
    			{
    				alt150=2;
    			}
    			else
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 150, 1, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 150, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(150); }
    		switch (alt150)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1167:9: 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1167, 9);
    			string_literal554=(IToken)new XToken((IToken)Match(input,NEW,Follow._NEW_in_arrayCreator7213), "NEW"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal554_tree = (object)adaptor.Create(string_literal554, retval);
    			adaptor.AddChild(root_0, string_literal554_tree);
    			}
    			DebugLocation(1167, 15);
    			PushFollow(Follow._createdName_in_arrayCreator7215);
    			createdName555=createdName();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, createdName555.Tree, createdName555, retval);
    			DebugLocation(1168, 9);
    			char_literal556=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_arrayCreator7225), "LBRACKET"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal556_tree = (object)adaptor.Create(char_literal556, retval);
    			adaptor.AddChild(root_0, char_literal556_tree);
    			}
    			DebugLocation(1168, 13);
    			char_literal557=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_arrayCreator7227), "RBRACKET"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal557_tree = (object)adaptor.Create(char_literal557, retval);
    			adaptor.AddChild(root_0, char_literal557_tree);
    			}
    			DebugLocation(1169, 9);
    			// Java.g:1169:9: ( '[' ']' )*
    			try { DebugEnterSubRule(147);
    			while (true)
    			{
    				int alt147=2;
    				try { DebugEnterDecision(147, decisionCanBacktrack[147]);
    				int LA147_0 = input.LA(1);

    				if ((LA147_0==LBRACKET))
    				{
    					alt147=1;
    				}


    				} finally { DebugExitDecision(147); }
    				switch ( alt147 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1169:10: '[' ']'
    					{
    					DebugLocation(1169, 10);
    					char_literal558=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_arrayCreator7238), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal558_tree = (object)adaptor.Create(char_literal558, retval);
    					adaptor.AddChild(root_0, char_literal558_tree);
    					}
    					DebugLocation(1169, 14);
    					char_literal559=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_arrayCreator7240), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal559_tree = (object)adaptor.Create(char_literal559, retval);
    					adaptor.AddChild(root_0, char_literal559_tree);
    					}

    					}
    					break;

    				default:
    					goto loop147;
    				}
    			}

    			loop147:
    				;

    			} finally { DebugExitSubRule(147); }

    			DebugLocation(1171, 9);
    			PushFollow(Follow._arrayInitializer_in_arrayCreator7261);
    			arrayInitializer560=arrayInitializer();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arrayInitializer560.Tree, arrayInitializer560, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1173:9: 'new' createdName '[' expression ']' ( '[' expression ']' )* ( '[' ']' )*
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1173, 9);
    			string_literal561=(IToken)new XToken((IToken)Match(input,NEW,Follow._NEW_in_arrayCreator7272), "NEW"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal561_tree = (object)adaptor.Create(string_literal561, retval);
    			adaptor.AddChild(root_0, string_literal561_tree);
    			}
    			DebugLocation(1173, 15);
    			PushFollow(Follow._createdName_in_arrayCreator7274);
    			createdName562=createdName();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, createdName562.Tree, createdName562, retval);
    			DebugLocation(1174, 9);
    			char_literal563=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_arrayCreator7284), "LBRACKET"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal563_tree = (object)adaptor.Create(char_literal563, retval);
    			adaptor.AddChild(root_0, char_literal563_tree);
    			}
    			DebugLocation(1174, 13);
    			PushFollow(Follow._expression_in_arrayCreator7286);
    			expression564=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression564.Tree, expression564, retval);
    			DebugLocation(1175, 9);
    			char_literal565=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_arrayCreator7296), "RBRACKET"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal565_tree = (object)adaptor.Create(char_literal565, retval);
    			adaptor.AddChild(root_0, char_literal565_tree);
    			}
    			DebugLocation(1176, 9);
    			// Java.g:1176:9: ( '[' expression ']' )*
    			try { DebugEnterSubRule(148);
    			while (true)
    			{
    				int alt148=2;
    				try { DebugEnterDecision(148, decisionCanBacktrack[148]);
    				try
    				{
    					alt148 = dfa148.Predict(input);
    				}
    				catch (NoViableAltException nvae)
    				{
    					DebugRecognitionException(nvae);
    					throw;
    				}
    				} finally { DebugExitDecision(148); }
    				switch ( alt148 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1176:13: '[' expression ']'
    					{
    					DebugLocation(1176, 13);
    					char_literal566=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_arrayCreator7310), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal566_tree = (object)adaptor.Create(char_literal566, retval);
    					adaptor.AddChild(root_0, char_literal566_tree);
    					}
    					DebugLocation(1176, 17);
    					PushFollow(Follow._expression_in_arrayCreator7312);
    					expression567=expression();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression567.Tree, expression567, retval);
    					DebugLocation(1177, 13);
    					char_literal568=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_arrayCreator7326), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal568_tree = (object)adaptor.Create(char_literal568, retval);
    					adaptor.AddChild(root_0, char_literal568_tree);
    					}

    					}
    					break;

    				default:
    					goto loop148;
    				}
    			}

    			loop148:
    				;

    			} finally { DebugExitSubRule(148); }

    			DebugLocation(1179, 9);
    			// Java.g:1179:9: ( '[' ']' )*
    			try { DebugEnterSubRule(149);
    			while (true)
    			{
    				int alt149=2;
    				try { DebugEnterDecision(149, decisionCanBacktrack[149]);
    				int LA149_0 = input.LA(1);

    				if ((LA149_0==LBRACKET))
    				{
    					int LA149_2 = input.LA(2);

    					if ((LA149_2==RBRACKET))
    					{
    						alt149=1;
    					}


    				}


    				} finally { DebugExitDecision(149); }
    				switch ( alt149 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1179:10: '[' ']'
    					{
    					DebugLocation(1179, 10);
    					char_literal569=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_arrayCreator7348), "LBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal569_tree = (object)adaptor.Create(char_literal569, retval);
    					adaptor.AddChild(root_0, char_literal569_tree);
    					}
    					DebugLocation(1179, 14);
    					char_literal570=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_arrayCreator7350), "RBRACKET"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal570_tree = (object)adaptor.Create(char_literal570, retval);
    					adaptor.AddChild(root_0, char_literal570_tree);
    					}

    					}
    					break;

    				default:
    					goto loop149;
    				}
    			}

    			loop149:
    				;

    			} finally { DebugExitSubRule(149); }


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
            if (state.backtracking > 0) { Memoize(input, 94, arrayCreator_StartIndex); }
        }
     	DebugLocation(1181, 4);
    	} finally { DebugExitRule(GrammarFileName, "arrayCreator"); }
    	return retval;

    }
    // $ANTLR end "arrayCreator"

    public class variableInitializer_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_variableInitializer() {}
    protected virtual void Leave_variableInitializer() {}

    // $ANTLR start "variableInitializer"
    // Java.g:1183:1: variableInitializer : ( arrayInitializer | expression );
    [GrammarRule("variableInitializer")]
    public JavaParser.variableInitializer_return variableInitializer()
    {

        JavaParser.variableInitializer_return retval = new JavaParser.variableInitializer_return();
        retval.Start = (IToken)input.LT(1);
        int variableInitializer_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.arrayInitializer_return arrayInitializer571 = default(JavaParser.arrayInitializer_return);
        JavaParser.expression_return expression572 = default(JavaParser.expression_return);


    	try { DebugEnterRule(GrammarFileName, "variableInitializer");
    	DebugLocation(1183, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 95)) { return retval; }
    		// Java.g:1184:5: ( arrayInitializer | expression )
    		int alt151=2;
    		try { DebugEnterDecision(151, decisionCanBacktrack[151]);
    		int LA151_0 = input.LA(1);

    		if ((LA151_0==LBRACE))
    		{
    			alt151=1;
    		}
    		else if (((LA151_0>=IDENTIFIER && LA151_0<=NULL)||LA151_0==BOOLEAN||LA151_0==BYTE||LA151_0==CHAR||LA151_0==DOUBLE||LA151_0==FLOAT||LA151_0==INT||LA151_0==LONG||LA151_0==NEW||LA151_0==SHORT||LA151_0==SUPER||LA151_0==THIS||LA151_0==VOID||LA151_0==LPAREN||(LA151_0>=BANG && LA151_0<=TILDE)||(LA151_0>=PLUSPLUS && LA151_0<=SUB)))
    		{
    			alt151=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 151, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(151); }
    		switch (alt151)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1184:9: arrayInitializer
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1184, 9);
    			PushFollow(Follow._arrayInitializer_in_variableInitializer7381);
    			arrayInitializer571=arrayInitializer();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arrayInitializer571.Tree, arrayInitializer571, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1185:9: expression
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1185, 9);
    			PushFollow(Follow._expression_in_variableInitializer7391);
    			expression572=expression();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expression572.Tree, expression572, retval);

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
            if (state.backtracking > 0) { Memoize(input, 95, variableInitializer_StartIndex); }
        }
     	DebugLocation(1186, 4);
    	} finally { DebugExitRule(GrammarFileName, "variableInitializer"); }
    	return retval;

    }
    // $ANTLR end "variableInitializer"

    public class arrayInitializer_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_arrayInitializer() {}
    protected virtual void Leave_arrayInitializer() {}

    // $ANTLR start "arrayInitializer"
    // Java.g:1188:1: arrayInitializer : '{' ( variableInitializer ( ',' variableInitializer )* )? ( ',' )? '}' ;
    [GrammarRule("arrayInitializer")]
    public JavaParser.arrayInitializer_return arrayInitializer()
    {

        JavaParser.arrayInitializer_return retval = new JavaParser.arrayInitializer_return();
        retval.Start = (IToken)input.LT(1);
        int arrayInitializer_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal573=null;
        IToken char_literal575=null;
        IToken char_literal577=null;
        IToken char_literal578=null;
        JavaParser.variableInitializer_return variableInitializer574 = default(JavaParser.variableInitializer_return);
        JavaParser.variableInitializer_return variableInitializer576 = default(JavaParser.variableInitializer_return);

        object char_literal573_tree=null;
        object char_literal575_tree=null;
        object char_literal577_tree=null;
        object char_literal578_tree=null;

    	try { DebugEnterRule(GrammarFileName, "arrayInitializer");
    	DebugLocation(1188, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 96)) { return retval; }
    		// Java.g:1189:5: ( '{' ( variableInitializer ( ',' variableInitializer )* )? ( ',' )? '}' )
    		DebugEnterAlt(1);
    		// Java.g:1189:9: '{' ( variableInitializer ( ',' variableInitializer )* )? ( ',' )? '}'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1189, 9);
    		char_literal573=(IToken)new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_arrayInitializer7411), "LBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal573_tree = (object)adaptor.Create(char_literal573, retval);
    		adaptor.AddChild(root_0, char_literal573_tree);
    		}
    		DebugLocation(1190, 13);
    		// Java.g:1190:13: ( variableInitializer ( ',' variableInitializer )* )?
    		int alt153=2;
    		try { DebugEnterSubRule(153);
    		try { DebugEnterDecision(153, decisionCanBacktrack[153]);
    		int LA153_0 = input.LA(1);

    		if (((LA153_0>=IDENTIFIER && LA153_0<=NULL)||LA153_0==BOOLEAN||LA153_0==BYTE||LA153_0==CHAR||LA153_0==DOUBLE||LA153_0==FLOAT||LA153_0==INT||LA153_0==LONG||LA153_0==NEW||LA153_0==SHORT||LA153_0==SUPER||LA153_0==THIS||LA153_0==VOID||LA153_0==LPAREN||LA153_0==LBRACE||(LA153_0>=BANG && LA153_0<=TILDE)||(LA153_0>=PLUSPLUS && LA153_0<=SUB)))
    		{
    			alt153=1;
    		}
    		} finally { DebugExitDecision(153); }
    		switch (alt153)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1190:14: variableInitializer ( ',' variableInitializer )*
    			{
    			DebugLocation(1190, 14);
    			PushFollow(Follow._variableInitializer_in_arrayInitializer7427);
    			variableInitializer574=variableInitializer();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableInitializer574.Tree, variableInitializer574, retval);
    			DebugLocation(1191, 17);
    			// Java.g:1191:17: ( ',' variableInitializer )*
    			try { DebugEnterSubRule(152);
    			while (true)
    			{
    				int alt152=2;
    				try { DebugEnterDecision(152, decisionCanBacktrack[152]);
    				int LA152_0 = input.LA(1);

    				if ((LA152_0==COMMA))
    				{
    					int LA152_1 = input.LA(2);

    					if (((LA152_1>=IDENTIFIER && LA152_1<=NULL)||LA152_1==BOOLEAN||LA152_1==BYTE||LA152_1==CHAR||LA152_1==DOUBLE||LA152_1==FLOAT||LA152_1==INT||LA152_1==LONG||LA152_1==NEW||LA152_1==SHORT||LA152_1==SUPER||LA152_1==THIS||LA152_1==VOID||LA152_1==LPAREN||LA152_1==LBRACE||(LA152_1>=BANG && LA152_1<=TILDE)||(LA152_1>=PLUSPLUS && LA152_1<=SUB)))
    					{
    						alt152=1;
    					}


    				}


    				} finally { DebugExitDecision(152); }
    				switch ( alt152 )
    				{
    				case 1:
    					DebugEnterAlt(1);
    					// Java.g:1191:18: ',' variableInitializer
    					{
    					DebugLocation(1191, 18);
    					char_literal575=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_arrayInitializer7446), "COMMA"); if (state.failed) return retval;
    					if ( state.backtracking==0 ) {
    					char_literal575_tree = (object)adaptor.Create(char_literal575, retval);
    					adaptor.AddChild(root_0, char_literal575_tree);
    					}
    					DebugLocation(1191, 22);
    					PushFollow(Follow._variableInitializer_in_arrayInitializer7448);
    					variableInitializer576=variableInitializer();
    					PopFollow();
    					if (state.failed) return retval;
    					if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableInitializer576.Tree, variableInitializer576, retval);

    					}
    					break;

    				default:
    					goto loop152;
    				}
    			}

    			loop152:
    				;

    			} finally { DebugExitSubRule(152); }


    			}
    			break;

    		}
    		} finally { DebugExitSubRule(153); }

    		DebugLocation(1194, 13);
    		// Java.g:1194:13: ( ',' )?
    		int alt154=2;
    		try { DebugEnterSubRule(154);
    		try { DebugEnterDecision(154, decisionCanBacktrack[154]);
    		int LA154_0 = input.LA(1);

    		if ((LA154_0==COMMA))
    		{
    			alt154=1;
    		}
    		} finally { DebugExitDecision(154); }
    		switch (alt154)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1194:14: ','
    			{
    			DebugLocation(1194, 14);
    			char_literal577=(IToken)new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_arrayInitializer7498), "COMMA"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			char_literal577_tree = (object)adaptor.Create(char_literal577, retval);
    			adaptor.AddChild(root_0, char_literal577_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(154); }

    		DebugLocation(1195, 9);
    		char_literal578=(IToken)new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_arrayInitializer7511), "RBRACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal578_tree = (object)adaptor.Create(char_literal578, retval);
    		adaptor.AddChild(root_0, char_literal578_tree);
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
            if (state.backtracking > 0) { Memoize(input, 96, arrayInitializer_StartIndex); }
        }
     	DebugLocation(1196, 4);
    	} finally { DebugExitRule(GrammarFileName, "arrayInitializer"); }
    	return retval;

    }
    // $ANTLR end "arrayInitializer"

    public class createdName_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_createdName() {}
    protected virtual void Leave_createdName() {}

    // $ANTLR start "createdName"
    // Java.g:1199:1: createdName : ( classOrInterfaceType | primitiveType );
    [GrammarRule("createdName")]
    public JavaParser.createdName_return createdName()
    {

        JavaParser.createdName_return retval = new JavaParser.createdName_return();
        retval.Start = (IToken)input.LT(1);
        int createdName_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.classOrInterfaceType_return classOrInterfaceType579 = default(JavaParser.classOrInterfaceType_return);
        JavaParser.primitiveType_return primitiveType580 = default(JavaParser.primitiveType_return);


    	try { DebugEnterRule(GrammarFileName, "createdName");
    	DebugLocation(1199, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 97)) { return retval; }
    		// Java.g:1200:5: ( classOrInterfaceType | primitiveType )
    		int alt155=2;
    		try { DebugEnterDecision(155, decisionCanBacktrack[155]);
    		int LA155_0 = input.LA(1);

    		if ((LA155_0==IDENTIFIER))
    		{
    			alt155=1;
    		}
    		else if ((LA155_0==BOOLEAN||LA155_0==BYTE||LA155_0==CHAR||LA155_0==DOUBLE||LA155_0==FLOAT||LA155_0==INT||LA155_0==LONG||LA155_0==SHORT))
    		{
    			alt155=2;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			NoViableAltException nvae = new NoViableAltException("", 155, 0, input);

    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(155); }
    		switch (alt155)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1200:9: classOrInterfaceType
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1200, 9);
    			PushFollow(Follow._classOrInterfaceType_in_createdName7545);
    			classOrInterfaceType579=classOrInterfaceType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classOrInterfaceType579.Tree, classOrInterfaceType579, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1201:9: primitiveType
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1201, 9);
    			PushFollow(Follow._primitiveType_in_createdName7555);
    			primitiveType580=primitiveType();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, primitiveType580.Tree, primitiveType580, retval);

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
            if (state.backtracking > 0) { Memoize(input, 97, createdName_StartIndex); }
        }
     	DebugLocation(1202, 4);
    	} finally { DebugExitRule(GrammarFileName, "createdName"); }
    	return retval;

    }
    // $ANTLR end "createdName"

    public class innerCreator_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_innerCreator() {}
    protected virtual void Leave_innerCreator() {}

    // $ANTLR start "innerCreator"
    // Java.g:1204:1: innerCreator : '.' 'new' ( nonWildcardTypeArguments )? IDENTIFIER ( typeArguments )? classCreatorRest ;
    [GrammarRule("innerCreator")]
    public JavaParser.innerCreator_return innerCreator()
    {

        JavaParser.innerCreator_return retval = new JavaParser.innerCreator_return();
        retval.Start = (IToken)input.LT(1);
        int innerCreator_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal581=null;
        IToken string_literal582=null;
        IToken IDENTIFIER584=null;
        JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments583 = default(JavaParser.nonWildcardTypeArguments_return);
        JavaParser.typeArguments_return typeArguments585 = default(JavaParser.typeArguments_return);
        JavaParser.classCreatorRest_return classCreatorRest586 = default(JavaParser.classCreatorRest_return);

        object char_literal581_tree=null;
        object string_literal582_tree=null;
        object IDENTIFIER584_tree=null;

    	try { DebugEnterRule(GrammarFileName, "innerCreator");
    	DebugLocation(1204, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 98)) { return retval; }
    		// Java.g:1205:5: ( '.' 'new' ( nonWildcardTypeArguments )? IDENTIFIER ( typeArguments )? classCreatorRest )
    		DebugEnterAlt(1);
    		// Java.g:1205:9: '.' 'new' ( nonWildcardTypeArguments )? IDENTIFIER ( typeArguments )? classCreatorRest
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1205, 9);
    		char_literal581=(IToken)new XToken((IToken)Match(input,DOT,Follow._DOT_in_innerCreator7576), "DOT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal581_tree = (object)adaptor.Create(char_literal581, retval);
    		adaptor.AddChild(root_0, char_literal581_tree);
    		}
    		DebugLocation(1205, 13);
    		string_literal582=(IToken)new XToken((IToken)Match(input,NEW,Follow._NEW_in_innerCreator7578), "NEW"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal582_tree = (object)adaptor.Create(string_literal582, retval);
    		adaptor.AddChild(root_0, string_literal582_tree);
    		}
    		DebugLocation(1206, 9);
    		// Java.g:1206:9: ( nonWildcardTypeArguments )?
    		int alt156=2;
    		try { DebugEnterSubRule(156);
    		try { DebugEnterDecision(156, decisionCanBacktrack[156]);
    		int LA156_0 = input.LA(1);

    		if ((LA156_0==LT))
    		{
    			alt156=1;
    		}
    		} finally { DebugExitDecision(156); }
    		switch (alt156)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1206:10: nonWildcardTypeArguments
    			{
    			DebugLocation(1206, 10);
    			PushFollow(Follow._nonWildcardTypeArguments_in_innerCreator7589);
    			nonWildcardTypeArguments583=nonWildcardTypeArguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nonWildcardTypeArguments583.Tree, nonWildcardTypeArguments583, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(156); }

    		DebugLocation(1208, 9);
    		IDENTIFIER584=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_innerCreator7610), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER584_tree = (object)adaptor.Create(IDENTIFIER584, retval);
    		adaptor.AddChild(root_0, IDENTIFIER584_tree);
    		}
    		DebugLocation(1209, 9);
    		// Java.g:1209:9: ( typeArguments )?
    		int alt157=2;
    		try { DebugEnterSubRule(157);
    		try { DebugEnterDecision(157, decisionCanBacktrack[157]);
    		int LA157_0 = input.LA(1);

    		if ((LA157_0==LT))
    		{
    			alt157=1;
    		}
    		} finally { DebugExitDecision(157); }
    		switch (alt157)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1209:10: typeArguments
    			{
    			DebugLocation(1209, 10);
    			PushFollow(Follow._typeArguments_in_innerCreator7621);
    			typeArguments585=typeArguments();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeArguments585.Tree, typeArguments585, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(157); }

    		DebugLocation(1211, 9);
    		PushFollow(Follow._classCreatorRest_in_innerCreator7642);
    		classCreatorRest586=classCreatorRest();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classCreatorRest586.Tree, classCreatorRest586, retval);

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
            if (state.backtracking > 0) { Memoize(input, 98, innerCreator_StartIndex); }
        }
     	DebugLocation(1212, 4);
    	} finally { DebugExitRule(GrammarFileName, "innerCreator"); }
    	return retval;

    }
    // $ANTLR end "innerCreator"

    public class classCreatorRest_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_classCreatorRest() {}
    protected virtual void Leave_classCreatorRest() {}

    // $ANTLR start "classCreatorRest"
    // Java.g:1215:1: classCreatorRest : arguments ( classBody )? ;
    [GrammarRule("classCreatorRest")]
    public JavaParser.classCreatorRest_return classCreatorRest()
    {

        JavaParser.classCreatorRest_return retval = new JavaParser.classCreatorRest_return();
        retval.Start = (IToken)input.LT(1);
        int classCreatorRest_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.arguments_return arguments587 = default(JavaParser.arguments_return);
        JavaParser.classBody_return classBody588 = default(JavaParser.classBody_return);


    	try { DebugEnterRule(GrammarFileName, "classCreatorRest");
    	DebugLocation(1215, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 99)) { return retval; }
    		// Java.g:1216:5: ( arguments ( classBody )? )
    		DebugEnterAlt(1);
    		// Java.g:1216:9: arguments ( classBody )?
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1216, 9);
    		PushFollow(Follow._arguments_in_classCreatorRest7663);
    		arguments587=arguments();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, arguments587.Tree, arguments587, retval);
    		DebugLocation(1217, 9);
    		// Java.g:1217:9: ( classBody )?
    		int alt158=2;
    		try { DebugEnterSubRule(158);
    		try { DebugEnterDecision(158, decisionCanBacktrack[158]);
    		int LA158_0 = input.LA(1);

    		if ((LA158_0==LBRACE))
    		{
    			alt158=1;
    		}
    		} finally { DebugExitDecision(158); }
    		switch (alt158)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1217:10: classBody
    			{
    			DebugLocation(1217, 10);
    			PushFollow(Follow._classBody_in_classCreatorRest7674);
    			classBody588=classBody();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, classBody588.Tree, classBody588, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(158); }


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
            if (state.backtracking > 0) { Memoize(input, 99, classCreatorRest_StartIndex); }
        }
     	DebugLocation(1219, 4);
    	} finally { DebugExitRule(GrammarFileName, "classCreatorRest"); }
    	return retval;

    }
    // $ANTLR end "classCreatorRest"

    public class nonWildcardTypeArguments_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_nonWildcardTypeArguments() {}
    protected virtual void Leave_nonWildcardTypeArguments() {}

    // $ANTLR start "nonWildcardTypeArguments"
    // Java.g:1222:1: nonWildcardTypeArguments : '<' typeList '>' ;
    [GrammarRule("nonWildcardTypeArguments")]
    public JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments()
    {

        JavaParser.nonWildcardTypeArguments_return retval = new JavaParser.nonWildcardTypeArguments_return();
        retval.Start = (IToken)input.LT(1);
        int nonWildcardTypeArguments_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal589=null;
        IToken char_literal591=null;
        JavaParser.typeList_return typeList590 = default(JavaParser.typeList_return);

        object char_literal589_tree=null;
        object char_literal591_tree=null;

    	try { DebugEnterRule(GrammarFileName, "nonWildcardTypeArguments");
    	DebugLocation(1222, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 100)) { return retval; }
    		// Java.g:1223:5: ( '<' typeList '>' )
    		DebugEnterAlt(1);
    		// Java.g:1223:9: '<' typeList '>'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1223, 9);
    		char_literal589=(IToken)new XToken((IToken)Match(input,LT,Follow._LT_in_nonWildcardTypeArguments7706), "LT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal589_tree = (object)adaptor.Create(char_literal589, retval);
    		adaptor.AddChild(root_0, char_literal589_tree);
    		}
    		DebugLocation(1223, 13);
    		PushFollow(Follow._typeList_in_nonWildcardTypeArguments7708);
    		typeList590=typeList();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeList590.Tree, typeList590, retval);
    		DebugLocation(1224, 9);
    		char_literal591=(IToken)new XToken((IToken)Match(input,GT,Follow._GT_in_nonWildcardTypeArguments7718), "GT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal591_tree = (object)adaptor.Create(char_literal591, retval);
    		adaptor.AddChild(root_0, char_literal591_tree);
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
            if (state.backtracking > 0) { Memoize(input, 100, nonWildcardTypeArguments_StartIndex); }
        }
     	DebugLocation(1225, 4);
    	} finally { DebugExitRule(GrammarFileName, "nonWildcardTypeArguments"); }
    	return retval;

    }
    // $ANTLR end "nonWildcardTypeArguments"

    public class arguments_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_arguments() {}
    protected virtual void Leave_arguments() {}

    // $ANTLR start "arguments"
    // Java.g:1227:1: arguments : '(' ( expressionList )? ')' ;
    [GrammarRule("arguments")]
    public JavaParser.arguments_return arguments()
    {

        JavaParser.arguments_return retval = new JavaParser.arguments_return();
        retval.Start = (IToken)input.LT(1);
        int arguments_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal592=null;
        IToken char_literal594=null;
        JavaParser.expressionList_return expressionList593 = default(JavaParser.expressionList_return);

        object char_literal592_tree=null;
        object char_literal594_tree=null;

    	try { DebugEnterRule(GrammarFileName, "arguments");
    	DebugLocation(1227, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 101)) { return retval; }
    		// Java.g:1228:5: ( '(' ( expressionList )? ')' )
    		DebugEnterAlt(1);
    		// Java.g:1228:9: '(' ( expressionList )? ')'
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1228, 9);
    		char_literal592=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_arguments7738), "LPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal592_tree = (object)adaptor.Create(char_literal592, retval);
    		adaptor.AddChild(root_0, char_literal592_tree);
    		}
    		DebugLocation(1228, 13);
    		// Java.g:1228:13: ( expressionList )?
    		int alt159=2;
    		try { DebugEnterSubRule(159);
    		try { DebugEnterDecision(159, decisionCanBacktrack[159]);
    		int LA159_0 = input.LA(1);

    		if (((LA159_0>=IDENTIFIER && LA159_0<=NULL)||LA159_0==BOOLEAN||LA159_0==BYTE||LA159_0==CHAR||LA159_0==DOUBLE||LA159_0==FLOAT||LA159_0==INT||LA159_0==LONG||LA159_0==NEW||LA159_0==SHORT||LA159_0==SUPER||LA159_0==THIS||LA159_0==VOID||LA159_0==LPAREN||(LA159_0>=BANG && LA159_0<=TILDE)||(LA159_0>=PLUSPLUS && LA159_0<=SUB)))
    		{
    			alt159=1;
    		}
    		} finally { DebugExitDecision(159); }
    		switch (alt159)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1228:14: expressionList
    			{
    			DebugLocation(1228, 14);
    			PushFollow(Follow._expressionList_in_arguments7741);
    			expressionList593=expressionList();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, expressionList593.Tree, expressionList593, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(159); }

    		DebugLocation(1229, 12);
    		char_literal594=(IToken)new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_arguments7754), "RPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal594_tree = (object)adaptor.Create(char_literal594, retval);
    		adaptor.AddChild(root_0, char_literal594_tree);
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
            if (state.backtracking > 0) { Memoize(input, 101, arguments_StartIndex); }
        }
     	DebugLocation(1230, 4);
    	} finally { DebugExitRule(GrammarFileName, "arguments"); }
    	return retval;

    }
    // $ANTLR end "arguments"

    public class intLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_intLiteral() {}
    protected virtual void Leave_intLiteral() {}

    // $ANTLR start "intLiteral"
    // Java.g:1232:1: intLiteral : INTLITERAL ;
    [GrammarRule("intLiteral")]
    public JavaParser.intLiteral_return intLiteral()
    {

        JavaParser.intLiteral_return retval = new JavaParser.intLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int intLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken INTLITERAL595=null;

        object INTLITERAL595_tree=null;

    	try { DebugEnterRule(GrammarFileName, "intLiteral");
    	DebugLocation(1232, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 102)) { return retval; }
    		// Java.g:1233:2: ( INTLITERAL )
    		DebugEnterAlt(1);
    		// Java.g:1233:4: INTLITERAL
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1233, 4);
    		INTLITERAL595=(IToken)new XToken((IToken)Match(input,INTLITERAL,Follow._INTLITERAL_in_intLiteral7768), "INTLITERAL"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		INTLITERAL595_tree = (object)adaptor.Create(INTLITERAL595, retval);
    		adaptor.AddChild(root_0, INTLITERAL595_tree);
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
            if (state.backtracking > 0) { Memoize(input, 102, intLiteral_StartIndex); }
        }
     	DebugLocation(1234, 1);
    	} finally { DebugExitRule(GrammarFileName, "intLiteral"); }
    	return retval;

    }
    // $ANTLR end "intLiteral"

    public class longLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_longLiteral() {}
    protected virtual void Leave_longLiteral() {}

    // $ANTLR start "longLiteral"
    // Java.g:1236:1: longLiteral : LONGLITERAL ;
    [GrammarRule("longLiteral")]
    public JavaParser.longLiteral_return longLiteral()
    {

        JavaParser.longLiteral_return retval = new JavaParser.longLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int longLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken LONGLITERAL596=null;

        object LONGLITERAL596_tree=null;

    	try { DebugEnterRule(GrammarFileName, "longLiteral");
    	DebugLocation(1236, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 103)) { return retval; }
    		// Java.g:1237:2: ( LONGLITERAL )
    		DebugEnterAlt(1);
    		// Java.g:1237:4: LONGLITERAL
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1237, 4);
    		LONGLITERAL596=(IToken)new XToken((IToken)Match(input,LONGLITERAL,Follow._LONGLITERAL_in_longLiteral7779), "LONGLITERAL"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		LONGLITERAL596_tree = (object)adaptor.Create(LONGLITERAL596, retval);
    		adaptor.AddChild(root_0, LONGLITERAL596_tree);
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
            if (state.backtracking > 0) { Memoize(input, 103, longLiteral_StartIndex); }
        }
     	DebugLocation(1238, 1);
    	} finally { DebugExitRule(GrammarFileName, "longLiteral"); }
    	return retval;

    }
    // $ANTLR end "longLiteral"

    public class floatLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_floatLiteral() {}
    protected virtual void Leave_floatLiteral() {}

    // $ANTLR start "floatLiteral"
    // Java.g:1240:1: floatLiteral : FLOATLITERAL ;
    [GrammarRule("floatLiteral")]
    public JavaParser.floatLiteral_return floatLiteral()
    {

        JavaParser.floatLiteral_return retval = new JavaParser.floatLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int floatLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken FLOATLITERAL597=null;

        object FLOATLITERAL597_tree=null;

    	try { DebugEnterRule(GrammarFileName, "floatLiteral");
    	DebugLocation(1240, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 104)) { return retval; }
    		// Java.g:1241:2: ( FLOATLITERAL )
    		DebugEnterAlt(1);
    		// Java.g:1241:4: FLOATLITERAL
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1241, 4);
    		FLOATLITERAL597=(IToken)new XToken((IToken)Match(input,FLOATLITERAL,Follow._FLOATLITERAL_in_floatLiteral7790), "FLOATLITERAL"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		FLOATLITERAL597_tree = (object)adaptor.Create(FLOATLITERAL597, retval);
    		adaptor.AddChild(root_0, FLOATLITERAL597_tree);
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
            if (state.backtracking > 0) { Memoize(input, 104, floatLiteral_StartIndex); }
        }
     	DebugLocation(1242, 1);
    	} finally { DebugExitRule(GrammarFileName, "floatLiteral"); }
    	return retval;

    }
    // $ANTLR end "floatLiteral"

    public class doubleLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_doubleLiteral() {}
    protected virtual void Leave_doubleLiteral() {}

    // $ANTLR start "doubleLiteral"
    // Java.g:1244:1: doubleLiteral : DOUBLELITERAL ;
    [GrammarRule("doubleLiteral")]
    public JavaParser.doubleLiteral_return doubleLiteral()
    {

        JavaParser.doubleLiteral_return retval = new JavaParser.doubleLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int doubleLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken DOUBLELITERAL598=null;

        object DOUBLELITERAL598_tree=null;

    	try { DebugEnterRule(GrammarFileName, "doubleLiteral");
    	DebugLocation(1244, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 105)) { return retval; }
    		// Java.g:1245:2: ( DOUBLELITERAL )
    		DebugEnterAlt(1);
    		// Java.g:1245:4: DOUBLELITERAL
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1245, 4);
    		DOUBLELITERAL598=(IToken)new XToken((IToken)Match(input,DOUBLELITERAL,Follow._DOUBLELITERAL_in_doubleLiteral7801), "DOUBLELITERAL"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		DOUBLELITERAL598_tree = (object)adaptor.Create(DOUBLELITERAL598, retval);
    		adaptor.AddChild(root_0, DOUBLELITERAL598_tree);
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
            if (state.backtracking > 0) { Memoize(input, 105, doubleLiteral_StartIndex); }
        }
     	DebugLocation(1246, 1);
    	} finally { DebugExitRule(GrammarFileName, "doubleLiteral"); }
    	return retval;

    }
    // $ANTLR end "doubleLiteral"

    public class charLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_charLiteral() {}
    protected virtual void Leave_charLiteral() {}

    // $ANTLR start "charLiteral"
    // Java.g:1248:1: charLiteral : CHARLITERAL ;
    [GrammarRule("charLiteral")]
    public JavaParser.charLiteral_return charLiteral()
    {

        JavaParser.charLiteral_return retval = new JavaParser.charLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int charLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken CHARLITERAL599=null;

        object CHARLITERAL599_tree=null;

    	try { DebugEnterRule(GrammarFileName, "charLiteral");
    	DebugLocation(1248, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 106)) { return retval; }
    		// Java.g:1249:2: ( CHARLITERAL )
    		DebugEnterAlt(1);
    		// Java.g:1249:4: CHARLITERAL
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1249, 4);
    		CHARLITERAL599=(IToken)new XToken((IToken)Match(input,CHARLITERAL,Follow._CHARLITERAL_in_charLiteral7812), "CHARLITERAL"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		CHARLITERAL599_tree = (object)adaptor.Create(CHARLITERAL599, retval);
    		adaptor.AddChild(root_0, CHARLITERAL599_tree);
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
            if (state.backtracking > 0) { Memoize(input, 106, charLiteral_StartIndex); }
        }
     	DebugLocation(1250, 1);
    	} finally { DebugExitRule(GrammarFileName, "charLiteral"); }
    	return retval;

    }
    // $ANTLR end "charLiteral"

    public class stringLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_stringLiteral() {}
    protected virtual void Leave_stringLiteral() {}

    // $ANTLR start "stringLiteral"
    // Java.g:1252:1: stringLiteral : STRINGLITERAL ;
    [GrammarRule("stringLiteral")]
    public JavaParser.stringLiteral_return stringLiteral()
    {

        JavaParser.stringLiteral_return retval = new JavaParser.stringLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int stringLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken STRINGLITERAL600=null;

        object STRINGLITERAL600_tree=null;

    	try { DebugEnterRule(GrammarFileName, "stringLiteral");
    	DebugLocation(1252, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 107)) { return retval; }
    		// Java.g:1253:2: ( STRINGLITERAL )
    		DebugEnterAlt(1);
    		// Java.g:1253:4: STRINGLITERAL
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1253, 4);
    		STRINGLITERAL600=(IToken)new XToken((IToken)Match(input,STRINGLITERAL,Follow._STRINGLITERAL_in_stringLiteral7823), "STRINGLITERAL"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		STRINGLITERAL600_tree = (object)adaptor.Create(STRINGLITERAL600, retval);
    		adaptor.AddChild(root_0, STRINGLITERAL600_tree);
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
            if (state.backtracking > 0) { Memoize(input, 107, stringLiteral_StartIndex); }
        }
     	DebugLocation(1254, 1);
    	} finally { DebugExitRule(GrammarFileName, "stringLiteral"); }
    	return retval;

    }
    // $ANTLR end "stringLiteral"

    public class trueLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_trueLiteral() {}
    protected virtual void Leave_trueLiteral() {}

    // $ANTLR start "trueLiteral"
    // Java.g:1256:1: trueLiteral : TRUE ;
    [GrammarRule("trueLiteral")]
    public JavaParser.trueLiteral_return trueLiteral()
    {

        JavaParser.trueLiteral_return retval = new JavaParser.trueLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int trueLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken TRUE601=null;

        object TRUE601_tree=null;

    	try { DebugEnterRule(GrammarFileName, "trueLiteral");
    	DebugLocation(1256, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 108)) { return retval; }
    		// Java.g:1257:2: ( TRUE )
    		DebugEnterAlt(1);
    		// Java.g:1257:4: TRUE
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1257, 4);
    		TRUE601=(IToken)new XToken((IToken)Match(input,TRUE,Follow._TRUE_in_trueLiteral7834), "TRUE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		TRUE601_tree = (object)adaptor.Create(TRUE601, retval);
    		adaptor.AddChild(root_0, TRUE601_tree);
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
            if (state.backtracking > 0) { Memoize(input, 108, trueLiteral_StartIndex); }
        }
     	DebugLocation(1258, 1);
    	} finally { DebugExitRule(GrammarFileName, "trueLiteral"); }
    	return retval;

    }
    // $ANTLR end "trueLiteral"

    public class falseLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_falseLiteral() {}
    protected virtual void Leave_falseLiteral() {}

    // $ANTLR start "falseLiteral"
    // Java.g:1260:1: falseLiteral : FALSE ;
    [GrammarRule("falseLiteral")]
    public JavaParser.falseLiteral_return falseLiteral()
    {

        JavaParser.falseLiteral_return retval = new JavaParser.falseLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int falseLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken FALSE602=null;

        object FALSE602_tree=null;

    	try { DebugEnterRule(GrammarFileName, "falseLiteral");
    	DebugLocation(1260, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 109)) { return retval; }
    		// Java.g:1261:2: ( FALSE )
    		DebugEnterAlt(1);
    		// Java.g:1261:4: FALSE
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1261, 4);
    		FALSE602=(IToken)new XToken((IToken)Match(input,FALSE,Follow._FALSE_in_falseLiteral7845), "FALSE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		FALSE602_tree = (object)adaptor.Create(FALSE602, retval);
    		adaptor.AddChild(root_0, FALSE602_tree);
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
            if (state.backtracking > 0) { Memoize(input, 109, falseLiteral_StartIndex); }
        }
     	DebugLocation(1262, 1);
    	} finally { DebugExitRule(GrammarFileName, "falseLiteral"); }
    	return retval;

    }
    // $ANTLR end "falseLiteral"

    public class nullLiteral_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_nullLiteral() {}
    protected virtual void Leave_nullLiteral() {}

    // $ANTLR start "nullLiteral"
    // Java.g:1264:1: nullLiteral : NULL ;
    [GrammarRule("nullLiteral")]
    public JavaParser.nullLiteral_return nullLiteral()
    {

        JavaParser.nullLiteral_return retval = new JavaParser.nullLiteral_return();
        retval.Start = (IToken)input.LT(1);
        int nullLiteral_StartIndex = input.Index;
        object root_0 = null;

        IToken NULL603=null;

        object NULL603_tree=null;

    	try { DebugEnterRule(GrammarFileName, "nullLiteral");
    	DebugLocation(1264, 1);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 110)) { return retval; }
    		// Java.g:1265:2: ( NULL )
    		DebugEnterAlt(1);
    		// Java.g:1265:4: NULL
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1265, 4);
    		NULL603=(IToken)new XToken((IToken)Match(input,NULL,Follow._NULL_in_nullLiteral7856), "NULL"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		NULL603_tree = (object)adaptor.Create(NULL603, retval);
    		adaptor.AddChild(root_0, NULL603_tree);
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
            if (state.backtracking > 0) { Memoize(input, 110, nullLiteral_StartIndex); }
        }
     	DebugLocation(1266, 1);
    	} finally { DebugExitRule(GrammarFileName, "nullLiteral"); }
    	return retval;

    }
    // $ANTLR end "nullLiteral"

    public class literal_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_literal() {}
    protected virtual void Leave_literal() {}

    // $ANTLR start "literal"
    // Java.g:1268:1: literal : ( intLiteral | longLiteral | floatLiteral | doubleLiteral | charLiteral | stringLiteral | trueLiteral | falseLiteral | nullLiteral );
    [GrammarRule("literal")]
    public JavaParser.literal_return literal()
    {

        JavaParser.literal_return retval = new JavaParser.literal_return();
        retval.Start = (IToken)input.LT(1);
        int literal_StartIndex = input.Index;
        object root_0 = null;

        JavaParser.intLiteral_return intLiteral604 = default(JavaParser.intLiteral_return);
        JavaParser.longLiteral_return longLiteral605 = default(JavaParser.longLiteral_return);
        JavaParser.floatLiteral_return floatLiteral606 = default(JavaParser.floatLiteral_return);
        JavaParser.doubleLiteral_return doubleLiteral607 = default(JavaParser.doubleLiteral_return);
        JavaParser.charLiteral_return charLiteral608 = default(JavaParser.charLiteral_return);
        JavaParser.stringLiteral_return stringLiteral609 = default(JavaParser.stringLiteral_return);
        JavaParser.trueLiteral_return trueLiteral610 = default(JavaParser.trueLiteral_return);
        JavaParser.falseLiteral_return falseLiteral611 = default(JavaParser.falseLiteral_return);
        JavaParser.nullLiteral_return nullLiteral612 = default(JavaParser.nullLiteral_return);


    	try { DebugEnterRule(GrammarFileName, "literal");
    	DebugLocation(1268, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 111)) { return retval; }
    		// Java.g:1269:5: ( intLiteral | longLiteral | floatLiteral | doubleLiteral | charLiteral | stringLiteral | trueLiteral | falseLiteral | nullLiteral )
    		int alt160=9;
    		try { DebugEnterDecision(160, decisionCanBacktrack[160]);
    		switch (input.LA(1))
    		{
    		case INTLITERAL:
    			{
    			alt160=1;
    			}
    			break;
    		case LONGLITERAL:
    			{
    			alt160=2;
    			}
    			break;
    		case FLOATLITERAL:
    			{
    			alt160=3;
    			}
    			break;
    		case DOUBLELITERAL:
    			{
    			alt160=4;
    			}
    			break;
    		case CHARLITERAL:
    			{
    			alt160=5;
    			}
    			break;
    		case STRINGLITERAL:
    			{
    			alt160=6;
    			}
    			break;
    		case TRUE:
    			{
    			alt160=7;
    			}
    			break;
    		case FALSE:
    			{
    			alt160=8;
    			}
    			break;
    		case NULL:
    			{
    			alt160=9;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 160, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(160); }
    		switch (alt160)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1269:9: intLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1269, 9);
    			PushFollow(Follow._intLiteral_in_literal7873);
    			intLiteral604=intLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, intLiteral604.Tree, intLiteral604, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1270:9: longLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1270, 9);
    			PushFollow(Follow._longLiteral_in_literal7883);
    			longLiteral605=longLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, longLiteral605.Tree, longLiteral605, retval);

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1271:9: floatLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1271, 9);
    			PushFollow(Follow._floatLiteral_in_literal7893);
    			floatLiteral606=floatLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, floatLiteral606.Tree, floatLiteral606, retval);

    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// Java.g:1272:9: doubleLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1272, 9);
    			PushFollow(Follow._doubleLiteral_in_literal7903);
    			doubleLiteral607=doubleLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, doubleLiteral607.Tree, doubleLiteral607, retval);

    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// Java.g:1273:9: charLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1273, 9);
    			PushFollow(Follow._charLiteral_in_literal7913);
    			charLiteral608=charLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, charLiteral608.Tree, charLiteral608, retval);

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// Java.g:1274:9: stringLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1274, 9);
    			PushFollow(Follow._stringLiteral_in_literal7923);
    			stringLiteral609=stringLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, stringLiteral609.Tree, stringLiteral609, retval);

    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// Java.g:1275:9: trueLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1275, 9);
    			PushFollow(Follow._trueLiteral_in_literal7933);
    			trueLiteral610=trueLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, trueLiteral610.Tree, trueLiteral610, retval);

    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// Java.g:1276:9: falseLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1276, 9);
    			PushFollow(Follow._falseLiteral_in_literal7943);
    			falseLiteral611=falseLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, falseLiteral611.Tree, falseLiteral611, retval);

    			}
    			break;
    		case 9:
    			DebugEnterAlt(9);
    			// Java.g:1277:9: nullLiteral
    			{
    			root_0 = (object)adaptor.Nil();

    			DebugLocation(1277, 9);
    			PushFollow(Follow._nullLiteral_in_literal7953);
    			nullLiteral612=nullLiteral();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, nullLiteral612.Tree, nullLiteral612, retval);

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
            if (state.backtracking > 0) { Memoize(input, 111, literal_StartIndex); }
        }
     	DebugLocation(1278, 4);
    	} finally { DebugExitRule(GrammarFileName, "literal"); }
    	return retval;

    }
    // $ANTLR end "literal"

    public class classHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_classHeader() {}
    protected virtual void Leave_classHeader() {}

    // $ANTLR start "classHeader"
    // Java.g:1280:1: classHeader : modifiers 'class' IDENTIFIER ;
    [GrammarRule("classHeader")]
    public JavaParser.classHeader_return classHeader()
    {

        JavaParser.classHeader_return retval = new JavaParser.classHeader_return();
        retval.Start = (IToken)input.LT(1);
        int classHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal614=null;
        IToken IDENTIFIER615=null;
        JavaParser.modifiers_return modifiers613 = default(JavaParser.modifiers_return);

        object string_literal614_tree=null;
        object IDENTIFIER615_tree=null;

    	try { DebugEnterRule(GrammarFileName, "classHeader");
    	DebugLocation(1280, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 112)) { return retval; }
    		// Java.g:1285:5: ( modifiers 'class' IDENTIFIER )
    		DebugEnterAlt(1);
    		// Java.g:1285:9: modifiers 'class' IDENTIFIER
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1285, 9);
    		PushFollow(Follow._modifiers_in_classHeader7977);
    		modifiers613=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers613.Tree, modifiers613, retval);
    		DebugLocation(1285, 19);
    		string_literal614=(IToken)new XToken((IToken)Match(input,CLASS,Follow._CLASS_in_classHeader7979), "CLASS"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal614_tree = (object)adaptor.Create(string_literal614, retval);
    		adaptor.AddChild(root_0, string_literal614_tree);
    		}
    		DebugLocation(1285, 27);
    		IDENTIFIER615=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_classHeader7981), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER615_tree = (object)adaptor.Create(IDENTIFIER615, retval);
    		adaptor.AddChild(root_0, IDENTIFIER615_tree);
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
            if (state.backtracking > 0) { Memoize(input, 112, classHeader_StartIndex); }
        }
     	DebugLocation(1286, 4);
    	} finally { DebugExitRule(GrammarFileName, "classHeader"); }
    	return retval;

    }
    // $ANTLR end "classHeader"

    public class enumHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_enumHeader() {}
    protected virtual void Leave_enumHeader() {}

    // $ANTLR start "enumHeader"
    // Java.g:1288:1: enumHeader : modifiers ( 'enum' | IDENTIFIER ) IDENTIFIER ;
    [GrammarRule("enumHeader")]
    public JavaParser.enumHeader_return enumHeader()
    {

        JavaParser.enumHeader_return retval = new JavaParser.enumHeader_return();
        retval.Start = (IToken)input.LT(1);
        int enumHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken set617=null;
        IToken IDENTIFIER618=null;
        JavaParser.modifiers_return modifiers616 = default(JavaParser.modifiers_return);

        object set617_tree=null;
        object IDENTIFIER618_tree=null;

    	try { DebugEnterRule(GrammarFileName, "enumHeader");
    	DebugLocation(1288, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 113)) { return retval; }
    		// Java.g:1289:5: ( modifiers ( 'enum' | IDENTIFIER ) IDENTIFIER )
    		DebugEnterAlt(1);
    		// Java.g:1289:9: modifiers ( 'enum' | IDENTIFIER ) IDENTIFIER
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1289, 9);
    		PushFollow(Follow._modifiers_in_enumHeader8001);
    		modifiers616=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers616.Tree, modifiers616, retval);
    		DebugLocation(1289, 19);
    		set617=(IToken)input.LT(1);
    		if (input.LA(1)==IDENTIFIER||input.LA(1)==ENUM)
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set617, retval));
    			state.errorRecovery=false;state.failed=false;
    		}
    		else
    		{
    			if (state.backtracking>0) {state.failed=true; return retval;}
    			MismatchedSetException mse = new MismatchedSetException(null,input);
    			DebugRecognitionException(mse);
    			throw mse;
    		}

    		DebugLocation(1289, 39);
    		IDENTIFIER618=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_enumHeader8009), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER618_tree = (object)adaptor.Create(IDENTIFIER618, retval);
    		adaptor.AddChild(root_0, IDENTIFIER618_tree);
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
            if (state.backtracking > 0) { Memoize(input, 113, enumHeader_StartIndex); }
        }
     	DebugLocation(1290, 4);
    	} finally { DebugExitRule(GrammarFileName, "enumHeader"); }
    	return retval;

    }
    // $ANTLR end "enumHeader"

    public class interfaceHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_interfaceHeader() {}
    protected virtual void Leave_interfaceHeader() {}

    // $ANTLR start "interfaceHeader"
    // Java.g:1292:1: interfaceHeader : modifiers 'interface' IDENTIFIER ;
    [GrammarRule("interfaceHeader")]
    public JavaParser.interfaceHeader_return interfaceHeader()
    {

        JavaParser.interfaceHeader_return retval = new JavaParser.interfaceHeader_return();
        retval.Start = (IToken)input.LT(1);
        int interfaceHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal620=null;
        IToken IDENTIFIER621=null;
        JavaParser.modifiers_return modifiers619 = default(JavaParser.modifiers_return);

        object string_literal620_tree=null;
        object IDENTIFIER621_tree=null;

    	try { DebugEnterRule(GrammarFileName, "interfaceHeader");
    	DebugLocation(1292, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 114)) { return retval; }
    		// Java.g:1293:5: ( modifiers 'interface' IDENTIFIER )
    		DebugEnterAlt(1);
    		// Java.g:1293:9: modifiers 'interface' IDENTIFIER
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1293, 9);
    		PushFollow(Follow._modifiers_in_interfaceHeader8029);
    		modifiers619=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers619.Tree, modifiers619, retval);
    		DebugLocation(1293, 19);
    		string_literal620=(IToken)new XToken((IToken)Match(input,INTERFACE,Follow._INTERFACE_in_interfaceHeader8031), "INTERFACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal620_tree = (object)adaptor.Create(string_literal620, retval);
    		adaptor.AddChild(root_0, string_literal620_tree);
    		}
    		DebugLocation(1293, 31);
    		IDENTIFIER621=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_interfaceHeader8033), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER621_tree = (object)adaptor.Create(IDENTIFIER621, retval);
    		adaptor.AddChild(root_0, IDENTIFIER621_tree);
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
            if (state.backtracking > 0) { Memoize(input, 114, interfaceHeader_StartIndex); }
        }
     	DebugLocation(1294, 4);
    	} finally { DebugExitRule(GrammarFileName, "interfaceHeader"); }
    	return retval;

    }
    // $ANTLR end "interfaceHeader"

    public class annotationHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_annotationHeader() {}
    protected virtual void Leave_annotationHeader() {}

    // $ANTLR start "annotationHeader"
    // Java.g:1296:1: annotationHeader : modifiers '@' 'interface' IDENTIFIER ;
    [GrammarRule("annotationHeader")]
    public JavaParser.annotationHeader_return annotationHeader()
    {

        JavaParser.annotationHeader_return retval = new JavaParser.annotationHeader_return();
        retval.Start = (IToken)input.LT(1);
        int annotationHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken char_literal623=null;
        IToken string_literal624=null;
        IToken IDENTIFIER625=null;
        JavaParser.modifiers_return modifiers622 = default(JavaParser.modifiers_return);

        object char_literal623_tree=null;
        object string_literal624_tree=null;
        object IDENTIFIER625_tree=null;

    	try { DebugEnterRule(GrammarFileName, "annotationHeader");
    	DebugLocation(1296, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 115)) { return retval; }
    		// Java.g:1297:5: ( modifiers '@' 'interface' IDENTIFIER )
    		DebugEnterAlt(1);
    		// Java.g:1297:9: modifiers '@' 'interface' IDENTIFIER
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1297, 9);
    		PushFollow(Follow._modifiers_in_annotationHeader8053);
    		modifiers622=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers622.Tree, modifiers622, retval);
    		DebugLocation(1297, 19);
    		char_literal623=(IToken)new XToken((IToken)Match(input,MONKEYS_AT,Follow._MONKEYS_AT_in_annotationHeader8055), "MONKEYS_AT"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal623_tree = (object)adaptor.Create(char_literal623, retval);
    		adaptor.AddChild(root_0, char_literal623_tree);
    		}
    		DebugLocation(1297, 23);
    		string_literal624=(IToken)new XToken((IToken)Match(input,INTERFACE,Follow._INTERFACE_in_annotationHeader8057), "INTERFACE"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		string_literal624_tree = (object)adaptor.Create(string_literal624, retval);
    		adaptor.AddChild(root_0, string_literal624_tree);
    		}
    		DebugLocation(1297, 35);
    		IDENTIFIER625=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_annotationHeader8059), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER625_tree = (object)adaptor.Create(IDENTIFIER625, retval);
    		adaptor.AddChild(root_0, IDENTIFIER625_tree);
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
            if (state.backtracking > 0) { Memoize(input, 115, annotationHeader_StartIndex); }
        }
     	DebugLocation(1298, 4);
    	} finally { DebugExitRule(GrammarFileName, "annotationHeader"); }
    	return retval;

    }
    // $ANTLR end "annotationHeader"

    public class typeHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_typeHeader() {}
    protected virtual void Leave_typeHeader() {}

    // $ANTLR start "typeHeader"
    // Java.g:1300:1: typeHeader : modifiers ( 'class' | 'enum' | ( ( '@' )? 'interface' ) ) IDENTIFIER ;
    [GrammarRule("typeHeader")]
    public JavaParser.typeHeader_return typeHeader()
    {

        JavaParser.typeHeader_return retval = new JavaParser.typeHeader_return();
        retval.Start = (IToken)input.LT(1);
        int typeHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal627=null;
        IToken string_literal628=null;
        IToken char_literal629=null;
        IToken string_literal630=null;
        IToken IDENTIFIER631=null;
        JavaParser.modifiers_return modifiers626 = default(JavaParser.modifiers_return);

        object string_literal627_tree=null;
        object string_literal628_tree=null;
        object char_literal629_tree=null;
        object string_literal630_tree=null;
        object IDENTIFIER631_tree=null;

    	try { DebugEnterRule(GrammarFileName, "typeHeader");
    	DebugLocation(1300, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 116)) { return retval; }
    		// Java.g:1301:5: ( modifiers ( 'class' | 'enum' | ( ( '@' )? 'interface' ) ) IDENTIFIER )
    		DebugEnterAlt(1);
    		// Java.g:1301:9: modifiers ( 'class' | 'enum' | ( ( '@' )? 'interface' ) ) IDENTIFIER
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1301, 9);
    		PushFollow(Follow._modifiers_in_typeHeader8079);
    		modifiers626=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers626.Tree, modifiers626, retval);
    		DebugLocation(1301, 19);
    		// Java.g:1301:19: ( 'class' | 'enum' | ( ( '@' )? 'interface' ) )
    		int alt162=3;
    		try { DebugEnterSubRule(162);
    		try { DebugEnterDecision(162, decisionCanBacktrack[162]);
    		switch (input.LA(1))
    		{
    		case CLASS:
    			{
    			alt162=1;
    			}
    			break;
    		case ENUM:
    			{
    			alt162=2;
    			}
    			break;
    		case INTERFACE:
    		case MONKEYS_AT:
    			{
    			alt162=3;
    			}
    			break;
    		default:
    			{
    				if (state.backtracking>0) {state.failed=true; return retval;}
    				NoViableAltException nvae = new NoViableAltException("", 162, 0, input);

    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(162); }
    		switch (alt162)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1301:20: 'class'
    			{
    			DebugLocation(1301, 20);
    			string_literal627=(IToken)new XToken((IToken)Match(input,CLASS,Follow._CLASS_in_typeHeader8082), "CLASS"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal627_tree = (object)adaptor.Create(string_literal627, retval);
    			adaptor.AddChild(root_0, string_literal627_tree);
    			}

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1301:28: 'enum'
    			{
    			DebugLocation(1301, 28);
    			string_literal628=(IToken)new XToken((IToken)Match(input,ENUM,Follow._ENUM_in_typeHeader8084), "ENUM"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal628_tree = (object)adaptor.Create(string_literal628, retval);
    			adaptor.AddChild(root_0, string_literal628_tree);
    			}

    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// Java.g:1301:35: ( ( '@' )? 'interface' )
    			{
    			DebugLocation(1301, 35);
    			// Java.g:1301:35: ( ( '@' )? 'interface' )
    			DebugEnterAlt(1);
    			// Java.g:1301:36: ( '@' )? 'interface'
    			{
    			DebugLocation(1301, 36);
    			// Java.g:1301:36: ( '@' )?
    			int alt161=2;
    			try { DebugEnterSubRule(161);
    			try { DebugEnterDecision(161, decisionCanBacktrack[161]);
    			int LA161_0 = input.LA(1);

    			if ((LA161_0==MONKEYS_AT))
    			{
    				alt161=1;
    			}
    			} finally { DebugExitDecision(161); }
    			switch (alt161)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:0:0: '@'
    				{
    				DebugLocation(1301, 36);
    				char_literal629=(IToken)new XToken((IToken)Match(input,MONKEYS_AT,Follow._MONKEYS_AT_in_typeHeader8087), "MONKEYS_AT"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal629_tree = (object)adaptor.Create(char_literal629, retval);
    				adaptor.AddChild(root_0, char_literal629_tree);
    				}

    				}
    				break;

    			}
    			} finally { DebugExitSubRule(161); }

    			DebugLocation(1301, 42);
    			string_literal630=(IToken)new XToken((IToken)Match(input,INTERFACE,Follow._INTERFACE_in_typeHeader8091), "INTERFACE"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal630_tree = (object)adaptor.Create(string_literal630, retval);
    			adaptor.AddChild(root_0, string_literal630_tree);
    			}

    			}


    			}
    			break;

    		}
    		} finally { DebugExitSubRule(162); }

    		DebugLocation(1301, 56);
    		IDENTIFIER631=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_typeHeader8095), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER631_tree = (object)adaptor.Create(IDENTIFIER631, retval);
    		adaptor.AddChild(root_0, IDENTIFIER631_tree);
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
            if (state.backtracking > 0) { Memoize(input, 116, typeHeader_StartIndex); }
        }
     	DebugLocation(1302, 4);
    	} finally { DebugExitRule(GrammarFileName, "typeHeader"); }
    	return retval;

    }
    // $ANTLR end "typeHeader"

    public class methodHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_methodHeader() {}
    protected virtual void Leave_methodHeader() {}

    // $ANTLR start "methodHeader"
    // Java.g:1304:1: methodHeader : modifiers ( typeParameters )? ( type | 'void' )? IDENTIFIER '(' ;
    [GrammarRule("methodHeader")]
    public JavaParser.methodHeader_return methodHeader()
    {

        JavaParser.methodHeader_return retval = new JavaParser.methodHeader_return();
        retval.Start = (IToken)input.LT(1);
        int methodHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken string_literal635=null;
        IToken IDENTIFIER636=null;
        IToken char_literal637=null;
        JavaParser.modifiers_return modifiers632 = default(JavaParser.modifiers_return);
        JavaParser.typeParameters_return typeParameters633 = default(JavaParser.typeParameters_return);
        JavaParser.type_return type634 = default(JavaParser.type_return);

        object string_literal635_tree=null;
        object IDENTIFIER636_tree=null;
        object char_literal637_tree=null;

    	try { DebugEnterRule(GrammarFileName, "methodHeader");
    	DebugLocation(1304, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 117)) { return retval; }
    		// Java.g:1305:5: ( modifiers ( typeParameters )? ( type | 'void' )? IDENTIFIER '(' )
    		DebugEnterAlt(1);
    		// Java.g:1305:9: modifiers ( typeParameters )? ( type | 'void' )? IDENTIFIER '('
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1305, 9);
    		PushFollow(Follow._modifiers_in_methodHeader8115);
    		modifiers632=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers632.Tree, modifiers632, retval);
    		DebugLocation(1305, 19);
    		// Java.g:1305:19: ( typeParameters )?
    		int alt163=2;
    		try { DebugEnterSubRule(163);
    		try { DebugEnterDecision(163, decisionCanBacktrack[163]);
    		int LA163_0 = input.LA(1);

    		if ((LA163_0==LT))
    		{
    			alt163=1;
    		}
    		} finally { DebugExitDecision(163); }
    		switch (alt163)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:0:0: typeParameters
    			{
    			DebugLocation(1305, 19);
    			PushFollow(Follow._typeParameters_in_methodHeader8117);
    			typeParameters633=typeParameters();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, typeParameters633.Tree, typeParameters633, retval);

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(163); }

    		DebugLocation(1305, 35);
    		// Java.g:1305:35: ( type | 'void' )?
    		int alt164=3;
    		try { DebugEnterSubRule(164);
    		try { DebugEnterDecision(164, decisionCanBacktrack[164]);
    		switch (input.LA(1))
    		{
    		case IDENTIFIER:
    			{
    			int LA164_1 = input.LA(2);

    			if ((LA164_1==IDENTIFIER||LA164_1==LBRACKET||LA164_1==DOT||LA164_1==LT))
    			{
    				alt164=1;
    			}
    			}
    			break;
    		case BOOLEAN:
    		case BYTE:
    		case CHAR:
    		case DOUBLE:
    		case FLOAT:
    		case INT:
    		case LONG:
    		case SHORT:
    			{
    			alt164=1;
    			}
    			break;
    		case VOID:
    			{
    			alt164=2;
    			}
    			break;
    		}

    		} finally { DebugExitDecision(164); }
    		switch (alt164)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1305:36: type
    			{
    			DebugLocation(1305, 36);
    			PushFollow(Follow._type_in_methodHeader8121);
    			type634=type();
    			PopFollow();
    			if (state.failed) return retval;
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type634.Tree, type634, retval);

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// Java.g:1305:41: 'void'
    			{
    			DebugLocation(1305, 41);
    			string_literal635=(IToken)new XToken((IToken)Match(input,VOID,Follow._VOID_in_methodHeader8123), "VOID"); if (state.failed) return retval;
    			if ( state.backtracking==0 ) {
    			string_literal635_tree = (object)adaptor.Create(string_literal635, retval);
    			adaptor.AddChild(root_0, string_literal635_tree);
    			}

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(164); }

    		DebugLocation(1305, 50);
    		IDENTIFIER636=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_methodHeader8127), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER636_tree = (object)adaptor.Create(IDENTIFIER636, retval);
    		adaptor.AddChild(root_0, IDENTIFIER636_tree);
    		}
    		DebugLocation(1305, 61);
    		char_literal637=(IToken)new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_methodHeader8129), "LPAREN"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		char_literal637_tree = (object)adaptor.Create(char_literal637, retval);
    		adaptor.AddChild(root_0, char_literal637_tree);
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
            if (state.backtracking > 0) { Memoize(input, 117, methodHeader_StartIndex); }
        }
     	DebugLocation(1306, 4);
    	} finally { DebugExitRule(GrammarFileName, "methodHeader"); }
    	return retval;

    }
    // $ANTLR end "methodHeader"

    public class fieldHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_fieldHeader() {}
    protected virtual void Leave_fieldHeader() {}

    // $ANTLR start "fieldHeader"
    // Java.g:1308:1: fieldHeader : modifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) ;
    [GrammarRule("fieldHeader")]
    public JavaParser.fieldHeader_return fieldHeader()
    {

        JavaParser.fieldHeader_return retval = new JavaParser.fieldHeader_return();
        retval.Start = (IToken)input.LT(1);
        int fieldHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER640=null;
        IToken char_literal641=null;
        IToken char_literal642=null;
        IToken set643=null;
        JavaParser.modifiers_return modifiers638 = default(JavaParser.modifiers_return);
        JavaParser.type_return type639 = default(JavaParser.type_return);

        object IDENTIFIER640_tree=null;
        object char_literal641_tree=null;
        object char_literal642_tree=null;
        object set643_tree=null;

    	try { DebugEnterRule(GrammarFileName, "fieldHeader");
    	DebugLocation(1308, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 118)) { return retval; }
    		// Java.g:1309:5: ( modifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) )
    		DebugEnterAlt(1);
    		// Java.g:1309:9: modifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' )
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1309, 9);
    		PushFollow(Follow._modifiers_in_fieldHeader8149);
    		modifiers638=modifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, modifiers638.Tree, modifiers638, retval);
    		DebugLocation(1309, 19);
    		PushFollow(Follow._type_in_fieldHeader8151);
    		type639=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type639.Tree, type639, retval);
    		DebugLocation(1309, 24);
    		IDENTIFIER640=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_fieldHeader8153), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER640_tree = (object)adaptor.Create(IDENTIFIER640, retval);
    		adaptor.AddChild(root_0, IDENTIFIER640_tree);
    		}
    		DebugLocation(1309, 35);
    		// Java.g:1309:35: ( '[' ']' )*
    		try { DebugEnterSubRule(165);
    		while (true)
    		{
    			int alt165=2;
    			try { DebugEnterDecision(165, decisionCanBacktrack[165]);
    			int LA165_0 = input.LA(1);

    			if ((LA165_0==LBRACKET))
    			{
    				alt165=1;
    			}


    			} finally { DebugExitDecision(165); }
    			switch ( alt165 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1309:36: '[' ']'
    				{
    				DebugLocation(1309, 36);
    				char_literal641=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_fieldHeader8156), "LBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal641_tree = (object)adaptor.Create(char_literal641, retval);
    				adaptor.AddChild(root_0, char_literal641_tree);
    				}
    				DebugLocation(1309, 39);
    				char_literal642=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_fieldHeader8157), "RBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal642_tree = (object)adaptor.Create(char_literal642, retval);
    				adaptor.AddChild(root_0, char_literal642_tree);
    				}

    				}
    				break;

    			default:
    				goto loop165;
    			}
    		}

    		loop165:
    			;

    		} finally { DebugExitSubRule(165); }

    		DebugLocation(1309, 45);
    		set643=(IToken)input.LT(1);
    		if ((input.LA(1)>=SEMI && input.LA(1)<=COMMA)||input.LA(1)==EQ)
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set643, retval));
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
            if (state.backtracking > 0) { Memoize(input, 118, fieldHeader_StartIndex); }
        }
     	DebugLocation(1310, 4);
    	} finally { DebugExitRule(GrammarFileName, "fieldHeader"); }
    	return retval;

    }
    // $ANTLR end "fieldHeader"

    public class localVariableHeader_return : XParserRuleReturnScope, IAstRuleReturnScope<object>
    {
    	private object _tree;
    	public object Tree { get { return _tree; } set { _tree = value; } }
    }

    protected virtual void Enter_localVariableHeader() {}
    protected virtual void Leave_localVariableHeader() {}

    // $ANTLR start "localVariableHeader"
    // Java.g:1312:1: localVariableHeader : variableModifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) ;
    [GrammarRule("localVariableHeader")]
    public JavaParser.localVariableHeader_return localVariableHeader()
    {

        JavaParser.localVariableHeader_return retval = new JavaParser.localVariableHeader_return();
        retval.Start = (IToken)input.LT(1);
        int localVariableHeader_StartIndex = input.Index;
        object root_0 = null;

        IToken IDENTIFIER646=null;
        IToken char_literal647=null;
        IToken char_literal648=null;
        IToken set649=null;
        JavaParser.variableModifiers_return variableModifiers644 = default(JavaParser.variableModifiers_return);
        JavaParser.type_return type645 = default(JavaParser.type_return);

        object IDENTIFIER646_tree=null;
        object char_literal647_tree=null;
        object char_literal648_tree=null;
        object set649_tree=null;

    	try { DebugEnterRule(GrammarFileName, "localVariableHeader");
    	DebugLocation(1312, 4);
    	try
    	{
    		if (state.backtracking > 0 && AlreadyParsedRule(input, 119)) { return retval; }
    		// Java.g:1313:5: ( variableModifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) )
    		DebugEnterAlt(1);
    		// Java.g:1313:9: variableModifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' )
    		{
    		root_0 = (object)adaptor.Nil();

    		DebugLocation(1313, 9);
    		PushFollow(Follow._variableModifiers_in_localVariableHeader8187);
    		variableModifiers644=variableModifiers();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, variableModifiers644.Tree, variableModifiers644, retval);
    		DebugLocation(1313, 27);
    		PushFollow(Follow._type_in_localVariableHeader8189);
    		type645=type();
    		PopFollow();
    		if (state.failed) return retval;
    		if ( (state.backtracking==0) ) adaptor.AddChild(root_0, type645.Tree, type645, retval);
    		DebugLocation(1313, 32);
    		IDENTIFIER646=(IToken)new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_localVariableHeader8191), "IDENTIFIER"); if (state.failed) return retval;
    		if ( state.backtracking==0 ) {
    		IDENTIFIER646_tree = (object)adaptor.Create(IDENTIFIER646, retval);
    		adaptor.AddChild(root_0, IDENTIFIER646_tree);
    		}
    		DebugLocation(1313, 43);
    		// Java.g:1313:43: ( '[' ']' )*
    		try { DebugEnterSubRule(166);
    		while (true)
    		{
    			int alt166=2;
    			try { DebugEnterDecision(166, decisionCanBacktrack[166]);
    			int LA166_0 = input.LA(1);

    			if ((LA166_0==LBRACKET))
    			{
    				alt166=1;
    			}


    			} finally { DebugExitDecision(166); }
    			switch ( alt166 )
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// Java.g:1313:44: '[' ']'
    				{
    				DebugLocation(1313, 44);
    				char_literal647=(IToken)new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_localVariableHeader8194), "LBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal647_tree = (object)adaptor.Create(char_literal647, retval);
    				adaptor.AddChild(root_0, char_literal647_tree);
    				}
    				DebugLocation(1313, 47);
    				char_literal648=(IToken)new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_localVariableHeader8195), "RBRACKET"); if (state.failed) return retval;
    				if ( state.backtracking==0 ) {
    				char_literal648_tree = (object)adaptor.Create(char_literal648, retval);
    				adaptor.AddChild(root_0, char_literal648_tree);
    				}

    				}
    				break;

    			default:
    				goto loop166;
    			}
    		}

    		loop166:
    			;

    		} finally { DebugExitSubRule(166); }

    		DebugLocation(1313, 53);
    		set649=(IToken)input.LT(1);
    		if ((input.LA(1)>=SEMI && input.LA(1)<=COMMA)||input.LA(1)==EQ)
    		{
    			input.Consume();
    			if ( (state.backtracking==0) ) adaptor.AddChild(root_0, (object)adaptor.Create(set649, retval));
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
            if (state.backtracking > 0) { Memoize(input, 119, localVariableHeader_StartIndex); }
        }
     	DebugLocation(1314, 4);
    	} finally { DebugExitRule(GrammarFileName, "localVariableHeader"); }
    	return retval;

    }
    // $ANTLR end "localVariableHeader"

    protected virtual void Enter_synpred2_Java_fragment() {}
    protected virtual void Leave_synpred2_Java_fragment() {}

    // $ANTLR start synpred2_Java
    public void synpred2_Java_fragment()
    {
    	// Java.g:299:13: ( ( annotations )? packageDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:299:13: ( annotations )? packageDeclaration
    	{
    	DebugLocation(299, 13);
    	// Java.g:299:13: ( annotations )?
    	int alt167=2;
    	try { DebugEnterSubRule(167);
    	try { DebugEnterDecision(167, decisionCanBacktrack[167]);
    	int LA167_0 = input.LA(1);

    	if ((LA167_0==MONKEYS_AT))
    	{
    		alt167=1;
    	}
    	} finally { DebugExitDecision(167); }
    	switch (alt167)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Java.g:299:14: annotations
    		{
    		DebugLocation(299, 14);
    		PushFollow(Follow._annotations_in_synpred2_Java100);
    		annotations();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(167); }

    	DebugLocation(301, 13);
    	PushFollow(Follow._packageDeclaration_in_synpred2_Java129);
    	packageDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred2_Java

    protected virtual void Enter_synpred12_Java_fragment() {}
    protected virtual void Leave_synpred12_Java_fragment() {}

    // $ANTLR start synpred12_Java
    public void synpred12_Java_fragment()
    {
    	// Java.g:343:10: ( classDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:343:10: classDeclaration
    	{
    	DebugLocation(343, 10);
    	PushFollow(Follow._classDeclaration_in_synpred12_Java487);
    	classDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred12_Java

    protected virtual void Enter_synpred27_Java_fragment() {}
    protected virtual void Leave_synpred27_Java_fragment() {}

    // $ANTLR start synpred27_Java
    public void synpred27_Java_fragment()
    {
    	// Java.g:374:9: ( normalClassDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:374:9: normalClassDeclaration
    	{
    	DebugLocation(374, 9);
    	PushFollow(Follow._normalClassDeclaration_in_synpred27_Java724);
    	normalClassDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred27_Java

    protected virtual void Enter_synpred43_Java_fragment() {}
    protected virtual void Leave_synpred43_Java_fragment() {}

    // $ANTLR start synpred43_Java
    public void synpred43_Java_fragment()
    {
    	// Java.g:462:9: ( normalInterfaceDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:462:9: normalInterfaceDeclaration
    	{
    	DebugLocation(462, 9);
    	PushFollow(Follow._normalInterfaceDeclaration_in_synpred43_Java1403);
    	normalInterfaceDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred43_Java

    protected virtual void Enter_synpred52_Java_fragment() {}
    protected virtual void Leave_synpred52_Java_fragment() {}

    // $ANTLR start synpred52_Java
    public void synpred52_Java_fragment()
    {
    	// Java.g:504:10: ( fieldDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:504:10: fieldDeclaration
    	{
    	DebugLocation(504, 10);
    	PushFollow(Follow._fieldDeclaration_in_synpred52_Java1733);
    	fieldDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred52_Java

    protected virtual void Enter_synpred53_Java_fragment() {}
    protected virtual void Leave_synpred53_Java_fragment() {}

    // $ANTLR start synpred53_Java
    public void synpred53_Java_fragment()
    {
    	// Java.g:505:10: ( methodDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:505:10: methodDeclaration
    	{
    	DebugLocation(505, 10);
    	PushFollow(Follow._methodDeclaration_in_synpred53_Java1744);
    	methodDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred53_Java

    protected virtual void Enter_synpred54_Java_fragment() {}
    protected virtual void Leave_synpred54_Java_fragment() {}

    // $ANTLR start synpred54_Java
    public void synpred54_Java_fragment()
    {
    	// Java.g:506:10: ( classDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:506:10: classDeclaration
    	{
    	DebugLocation(506, 10);
    	PushFollow(Follow._classDeclaration_in_synpred54_Java1755);
    	classDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred54_Java

    protected virtual void Enter_synpred57_Java_fragment() {}
    protected virtual void Leave_synpred57_Java_fragment() {}

    // $ANTLR start synpred57_Java
    public void synpred57_Java_fragment()
    {
    	// Java.g:522:10: ( explicitConstructorInvocation )
    	DebugEnterAlt(1);
    	// Java.g:522:10: explicitConstructorInvocation
    	{
    	DebugLocation(522, 10);
    	PushFollow(Follow._explicitConstructorInvocation_in_synpred57_Java1892);
    	explicitConstructorInvocation();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred57_Java

    protected virtual void Enter_synpred59_Java_fragment() {}
    protected virtual void Leave_synpred59_Java_fragment() {}

    // $ANTLR start synpred59_Java
    public void synpred59_Java_fragment()
    {
    	// Java.g:514:10: ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' )
    	DebugEnterAlt(1);
    	// Java.g:514:10: modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}'
    	{
    	DebugLocation(514, 10);
    	PushFollow(Follow._modifiers_in_synpred59_Java1804);
    	modifiers();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(515, 9);
    	// Java.g:515:9: ( typeParameters )?
    	int alt170=2;
    	try { DebugEnterSubRule(170);
    	try { DebugEnterDecision(170, decisionCanBacktrack[170]);
    	int LA170_0 = input.LA(1);

    	if ((LA170_0==LT))
    	{
    		alt170=1;
    	}
    	} finally { DebugExitDecision(170); }
    	switch (alt170)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Java.g:515:10: typeParameters
    		{
    		DebugLocation(515, 10);
    		PushFollow(Follow._typeParameters_in_synpred59_Java1815);
    		typeParameters();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(170); }

    	DebugLocation(517, 9);
    	new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_synpred59_Java1836), "IDENTIFIER"); if (state.failed) return;
    	DebugLocation(518, 9);
    	PushFollow(Follow._formalParameters_in_synpred59_Java1846);
    	formalParameters();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(519, 9);
    	// Java.g:519:9: ( 'throws' qualifiedNameList )?
    	int alt171=2;
    	try { DebugEnterSubRule(171);
    	try { DebugEnterDecision(171, decisionCanBacktrack[171]);
    	int LA171_0 = input.LA(1);

    	if ((LA171_0==THROWS))
    	{
    		alt171=1;
    	}
    	} finally { DebugExitDecision(171); }
    	switch (alt171)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Java.g:519:10: 'throws' qualifiedNameList
    		{
    		DebugLocation(519, 10);
    		new XToken((IToken)Match(input,THROWS,Follow._THROWS_in_synpred59_Java1857), "THROWS"); if (state.failed) return;
    		DebugLocation(519, 19);
    		PushFollow(Follow._qualifiedNameList_in_synpred59_Java1859);
    		qualifiedNameList();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(171); }

    	DebugLocation(521, 9);
    	new XToken((IToken)Match(input,LBRACE,Follow._LBRACE_in_synpred59_Java1880), "LBRACE"); if (state.failed) return;
    	DebugLocation(522, 9);
    	// Java.g:522:9: ( explicitConstructorInvocation )?
    	int alt172=2;
    	try { DebugEnterSubRule(172);
    	try { DebugEnterDecision(172, decisionCanBacktrack[172]);
    	try
    	{
    		alt172 = dfa172.Predict(input);
    	}
    	catch (NoViableAltException nvae)
    	{
    		DebugRecognitionException(nvae);
    		throw;
    	}
    	} finally { DebugExitDecision(172); }
    	switch (alt172)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Java.g:522:10: explicitConstructorInvocation
    		{
    		DebugLocation(522, 10);
    		PushFollow(Follow._explicitConstructorInvocation_in_synpred59_Java1892);
    		explicitConstructorInvocation();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(172); }

    	DebugLocation(524, 9);
    	// Java.g:524:9: ( blockStatement )*
    	try { DebugEnterSubRule(173);
    	while (true)
    	{
    		int alt173=2;
    		try { DebugEnterDecision(173, decisionCanBacktrack[173]);
    		int LA173_0 = input.LA(1);

    		if (((LA173_0>=IDENTIFIER && LA173_0<=NULL)||(LA173_0>=ABSTRACT && LA173_0<=BYTE)||(LA173_0>=CHAR && LA173_0<=CLASS)||LA173_0==CONTINUE||(LA173_0>=DO && LA173_0<=DOUBLE)||LA173_0==ENUM||LA173_0==FINAL||(LA173_0>=FLOAT && LA173_0<=FOR)||LA173_0==IF||(LA173_0>=INT && LA173_0<=NEW)||(LA173_0>=PRIVATE && LA173_0<=THROW)||(LA173_0>=TRANSIENT && LA173_0<=LPAREN)||LA173_0==LBRACE||LA173_0==SEMI||(LA173_0>=BANG && LA173_0<=TILDE)||(LA173_0>=PLUSPLUS && LA173_0<=SUB)||LA173_0==MONKEYS_AT||LA173_0==LT))
    		{
    			alt173=1;
    		}


    		} finally { DebugExitDecision(173); }
    		switch ( alt173 )
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:524:10: blockStatement
    			{
    			DebugLocation(524, 10);
    			PushFollow(Follow._blockStatement_in_synpred59_Java1914);
    			blockStatement();
    			PopFollow();
    			if (state.failed) return;

    			}
    			break;

    		default:
    			goto loop173;
    		}
    	}

    	loop173:
    		;

    	} finally { DebugExitSubRule(173); }

    	DebugLocation(526, 9);
    	new XToken((IToken)Match(input,RBRACE,Follow._RBRACE_in_synpred59_Java1935), "RBRACE"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred59_Java

    protected virtual void Enter_synpred68_Java_fragment() {}
    protected virtual void Leave_synpred68_Java_fragment() {}

    // $ANTLR start synpred68_Java
    public void synpred68_Java_fragment()
    {
    	// Java.g:568:9: ( interfaceFieldDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:568:9: interfaceFieldDeclaration
    	{
    	DebugLocation(568, 9);
    	PushFollow(Follow._interfaceFieldDeclaration_in_synpred68_Java2310);
    	interfaceFieldDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred68_Java

    protected virtual void Enter_synpred69_Java_fragment() {}
    protected virtual void Leave_synpred69_Java_fragment() {}

    // $ANTLR start synpred69_Java
    public void synpred69_Java_fragment()
    {
    	// Java.g:569:9: ( interfaceMethodDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:569:9: interfaceMethodDeclaration
    	{
    	DebugLocation(569, 9);
    	PushFollow(Follow._interfaceMethodDeclaration_in_synpred69_Java2320);
    	interfaceMethodDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred69_Java

    protected virtual void Enter_synpred70_Java_fragment() {}
    protected virtual void Leave_synpred70_Java_fragment() {}

    // $ANTLR start synpred70_Java
    public void synpred70_Java_fragment()
    {
    	// Java.g:570:9: ( interfaceDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:570:9: interfaceDeclaration
    	{
    	DebugLocation(570, 9);
    	PushFollow(Follow._interfaceDeclaration_in_synpred70_Java2330);
    	interfaceDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred70_Java

    protected virtual void Enter_synpred71_Java_fragment() {}
    protected virtual void Leave_synpred71_Java_fragment() {}

    // $ANTLR start synpred71_Java
    public void synpred71_Java_fragment()
    {
    	// Java.g:571:9: ( classDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:571:9: classDeclaration
    	{
    	DebugLocation(571, 9);
    	PushFollow(Follow._classDeclaration_in_synpred71_Java2340);
    	classDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred71_Java

    protected virtual void Enter_synpred96_Java_fragment() {}
    protected virtual void Leave_synpred96_Java_fragment() {}

    // $ANTLR start synpred96_Java
    public void synpred96_Java_fragment()
    {
    	// Java.g:666:9: ( ellipsisParameterDecl )
    	DebugEnterAlt(1);
    	// Java.g:666:9: ellipsisParameterDecl
    	{
    	DebugLocation(666, 9);
    	PushFollow(Follow._ellipsisParameterDecl_in_synpred96_Java3104);
    	ellipsisParameterDecl();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred96_Java

    protected virtual void Enter_synpred98_Java_fragment() {}
    protected virtual void Leave_synpred98_Java_fragment() {}

    // $ANTLR start synpred98_Java
    public void synpred98_Java_fragment()
    {
    	// Java.g:667:9: ( normalParameterDecl ( ',' normalParameterDecl )* )
    	DebugEnterAlt(1);
    	// Java.g:667:9: normalParameterDecl ( ',' normalParameterDecl )*
    	{
    	DebugLocation(667, 9);
    	PushFollow(Follow._normalParameterDecl_in_synpred98_Java3114);
    	normalParameterDecl();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(668, 9);
    	// Java.g:668:9: ( ',' normalParameterDecl )*
    	try { DebugEnterSubRule(176);
    	while (true)
    	{
    		int alt176=2;
    		try { DebugEnterDecision(176, decisionCanBacktrack[176]);
    		int LA176_0 = input.LA(1);

    		if ((LA176_0==COMMA))
    		{
    			alt176=1;
    		}


    		} finally { DebugExitDecision(176); }
    		switch ( alt176 )
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:668:10: ',' normalParameterDecl
    			{
    			DebugLocation(668, 10);
    			new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_synpred98_Java3125), "COMMA"); if (state.failed) return;
    			DebugLocation(668, 14);
    			PushFollow(Follow._normalParameterDecl_in_synpred98_Java3127);
    			normalParameterDecl();
    			PopFollow();
    			if (state.failed) return;

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
    }
    // $ANTLR end synpred98_Java

    protected virtual void Enter_synpred99_Java_fragment() {}
    protected virtual void Leave_synpred99_Java_fragment() {}

    // $ANTLR start synpred99_Java
    public void synpred99_Java_fragment()
    {
    	// Java.g:670:10: ( normalParameterDecl ',' )
    	DebugEnterAlt(1);
    	// Java.g:670:10: normalParameterDecl ','
    	{
    	DebugLocation(670, 10);
    	PushFollow(Follow._normalParameterDecl_in_synpred99_Java3149);
    	normalParameterDecl();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(671, 9);
    	new XToken((IToken)Match(input,COMMA,Follow._COMMA_in_synpred99_Java3159), "COMMA"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred99_Java

    protected virtual void Enter_synpred103_Java_fragment() {}
    protected virtual void Leave_synpred103_Java_fragment() {}

    // $ANTLR start synpred103_Java
    public void synpred103_Java_fragment()
    {
    	// Java.g:690:9: ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' )
    	DebugEnterAlt(1);
    	// Java.g:690:9: ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';'
    	{
    	DebugLocation(690, 9);
    	// Java.g:690:9: ( nonWildcardTypeArguments )?
    	int alt177=2;
    	try { DebugEnterSubRule(177);
    	try { DebugEnterDecision(177, decisionCanBacktrack[177]);
    	int LA177_0 = input.LA(1);

    	if ((LA177_0==LT))
    	{
    		alt177=1;
    	}
    	} finally { DebugExitDecision(177); }
    	switch (alt177)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Java.g:690:10: nonWildcardTypeArguments
    		{
    		DebugLocation(690, 10);
    		PushFollow(Follow._nonWildcardTypeArguments_in_synpred103_Java3294);
    		nonWildcardTypeArguments();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(177); }

    	DebugLocation(692, 9);
    	if (input.LA(1)==SUPER||input.LA(1)==THIS)
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

    	DebugLocation(695, 9);
    	PushFollow(Follow._arguments_in_synpred103_Java3352);
    	arguments();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(695, 19);
    	new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_synpred103_Java3354), "SEMI"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred103_Java

    protected virtual void Enter_synpred117_Java_fragment() {}
    protected virtual void Leave_synpred117_Java_fragment() {}

    // $ANTLR start synpred117_Java
    public void synpred117_Java_fragment()
    {
    	// Java.g:777:9: ( annotationMethodDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:777:9: annotationMethodDeclaration
    	{
    	DebugLocation(777, 9);
    	PushFollow(Follow._annotationMethodDeclaration_in_synpred117_Java3953);
    	annotationMethodDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred117_Java

    protected virtual void Enter_synpred118_Java_fragment() {}
    protected virtual void Leave_synpred118_Java_fragment() {}

    // $ANTLR start synpred118_Java
    public void synpred118_Java_fragment()
    {
    	// Java.g:778:9: ( interfaceFieldDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:778:9: interfaceFieldDeclaration
    	{
    	DebugLocation(778, 9);
    	PushFollow(Follow._interfaceFieldDeclaration_in_synpred118_Java3963);
    	interfaceFieldDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred118_Java

    protected virtual void Enter_synpred119_Java_fragment() {}
    protected virtual void Leave_synpred119_Java_fragment() {}

    // $ANTLR start synpred119_Java
    public void synpred119_Java_fragment()
    {
    	// Java.g:779:9: ( normalClassDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:779:9: normalClassDeclaration
    	{
    	DebugLocation(779, 9);
    	PushFollow(Follow._normalClassDeclaration_in_synpred119_Java3973);
    	normalClassDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred119_Java

    protected virtual void Enter_synpred120_Java_fragment() {}
    protected virtual void Leave_synpred120_Java_fragment() {}

    // $ANTLR start synpred120_Java
    public void synpred120_Java_fragment()
    {
    	// Java.g:780:9: ( normalInterfaceDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:780:9: normalInterfaceDeclaration
    	{
    	DebugLocation(780, 9);
    	PushFollow(Follow._normalInterfaceDeclaration_in_synpred120_Java3983);
    	normalInterfaceDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred120_Java

    protected virtual void Enter_synpred121_Java_fragment() {}
    protected virtual void Leave_synpred121_Java_fragment() {}

    // $ANTLR start synpred121_Java
    public void synpred121_Java_fragment()
    {
    	// Java.g:781:9: ( enumDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:781:9: enumDeclaration
    	{
    	DebugLocation(781, 9);
    	PushFollow(Follow._enumDeclaration_in_synpred121_Java3993);
    	enumDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred121_Java

    protected virtual void Enter_synpred122_Java_fragment() {}
    protected virtual void Leave_synpred122_Java_fragment() {}

    // $ANTLR start synpred122_Java
    public void synpred122_Java_fragment()
    {
    	// Java.g:782:9: ( annotationTypeDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:782:9: annotationTypeDeclaration
    	{
    	DebugLocation(782, 9);
    	PushFollow(Follow._annotationTypeDeclaration_in_synpred122_Java4003);
    	annotationTypeDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred122_Java

    protected virtual void Enter_synpred125_Java_fragment() {}
    protected virtual void Leave_synpred125_Java_fragment() {}

    // $ANTLR start synpred125_Java
    public void synpred125_Java_fragment()
    {
    	// Java.g:825:9: ( localVariableDeclarationStatement )
    	DebugEnterAlt(1);
    	// Java.g:825:9: localVariableDeclarationStatement
    	{
    	DebugLocation(825, 9);
    	PushFollow(Follow._localVariableDeclarationStatement_in_synpred125_Java4161);
    	localVariableDeclarationStatement();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred125_Java

    protected virtual void Enter_synpred126_Java_fragment() {}
    protected virtual void Leave_synpred126_Java_fragment() {}

    // $ANTLR start synpred126_Java
    public void synpred126_Java_fragment()
    {
    	// Java.g:826:9: ( classOrInterfaceDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:826:9: classOrInterfaceDeclaration
    	{
    	DebugLocation(826, 9);
    	PushFollow(Follow._classOrInterfaceDeclaration_in_synpred126_Java4171);
    	classOrInterfaceDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred126_Java

    protected virtual void Enter_synpred130_Java_fragment() {}
    protected virtual void Leave_synpred130_Java_fragment() {}

    // $ANTLR start synpred130_Java
    public void synpred130_Java_fragment()
    {
    	// Java.g:846:9: ( ( 'assert' ) expression ( ':' expression )? ';' )
    	DebugEnterAlt(1);
    	// Java.g:846:9: ( 'assert' ) expression ( ':' expression )? ';'
    	{
    	DebugLocation(846, 9);
    	// Java.g:846:9: ( 'assert' )
    	DebugEnterAlt(1);
    	// Java.g:846:10: 'assert'
    	{
    	DebugLocation(846, 10);
    	new XToken((IToken)Match(input,ASSERT,Follow._ASSERT_in_synpred130_Java4312), "ASSERT"); if (state.failed) return;

    	}

    	DebugLocation(848, 9);
    	PushFollow(Follow._expression_in_synpred130_Java4332);
    	expression();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(848, 20);
    	// Java.g:848:20: ( ':' expression )?
    	int alt180=2;
    	try { DebugEnterSubRule(180);
    	try { DebugEnterDecision(180, decisionCanBacktrack[180]);
    	int LA180_0 = input.LA(1);

    	if ((LA180_0==COLON))
    	{
    		alt180=1;
    	}
    	} finally { DebugExitDecision(180); }
    	switch (alt180)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Java.g:848:21: ':' expression
    		{
    		DebugLocation(848, 21);
    		new XToken((IToken)Match(input,COLON,Follow._COLON_in_synpred130_Java4335), "COLON"); if (state.failed) return;
    		DebugLocation(848, 25);
    		PushFollow(Follow._expression_in_synpred130_Java4337);
    		expression();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(180); }

    	DebugLocation(848, 38);
    	new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_synpred130_Java4341), "SEMI"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred130_Java

    protected virtual void Enter_synpred132_Java_fragment() {}
    protected virtual void Leave_synpred132_Java_fragment() {}

    // $ANTLR start synpred132_Java
    public void synpred132_Java_fragment()
    {
    	// Java.g:849:9: ( 'assert' expression ( ':' expression )? ';' )
    	DebugEnterAlt(1);
    	// Java.g:849:9: 'assert' expression ( ':' expression )? ';'
    	{
    	DebugLocation(849, 9);
    	new XToken((IToken)Match(input,ASSERT,Follow._ASSERT_in_synpred132_Java4351), "ASSERT"); if (state.failed) return;
    	DebugLocation(849, 19);
    	PushFollow(Follow._expression_in_synpred132_Java4354);
    	expression();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(849, 30);
    	// Java.g:849:30: ( ':' expression )?
    	int alt181=2;
    	try { DebugEnterSubRule(181);
    	try { DebugEnterDecision(181, decisionCanBacktrack[181]);
    	int LA181_0 = input.LA(1);

    	if ((LA181_0==COLON))
    	{
    		alt181=1;
    	}
    	} finally { DebugExitDecision(181); }
    	switch (alt181)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// Java.g:849:31: ':' expression
    		{
    		DebugLocation(849, 31);
    		new XToken((IToken)Match(input,COLON,Follow._COLON_in_synpred132_Java4357), "COLON"); if (state.failed) return;
    		DebugLocation(849, 35);
    		PushFollow(Follow._expression_in_synpred132_Java4359);
    		expression();
    		PopFollow();
    		if (state.failed) return;

    		}
    		break;

    	}
    	} finally { DebugExitSubRule(181); }

    	DebugLocation(849, 48);
    	new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_synpred132_Java4363), "SEMI"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred132_Java

    protected virtual void Enter_synpred133_Java_fragment() {}
    protected virtual void Leave_synpred133_Java_fragment() {}

    // $ANTLR start synpred133_Java
    public void synpred133_Java_fragment()
    {
    	// Java.g:850:39: ( 'else' statement )
    	DebugEnterAlt(1);
    	// Java.g:850:39: 'else' statement
    	{
    	DebugLocation(850, 39);
    	new XToken((IToken)Match(input,ELSE,Follow._ELSE_in_synpred133_Java4392), "ELSE"); if (state.failed) return;
    	DebugLocation(850, 46);
    	PushFollow(Follow._statement_in_synpred133_Java4394);
    	statement();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred133_Java

    protected virtual void Enter_synpred148_Java_fragment() {}
    protected virtual void Leave_synpred148_Java_fragment() {}

    // $ANTLR start synpred148_Java
    public void synpred148_Java_fragment()
    {
    	// Java.g:865:9: ( expression ';' )
    	DebugEnterAlt(1);
    	// Java.g:865:9: expression ';'
    	{
    	DebugLocation(865, 9);
    	PushFollow(Follow._expression_in_synpred148_Java4616);
    	expression();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(865, 21);
    	new XToken((IToken)Match(input,SEMI,Follow._SEMI_in_synpred148_Java4619), "SEMI"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred148_Java

    protected virtual void Enter_synpred149_Java_fragment() {}
    protected virtual void Leave_synpred149_Java_fragment() {}

    // $ANTLR start synpred149_Java
    public void synpred149_Java_fragment()
    {
    	// Java.g:866:9: ( IDENTIFIER ':' statement )
    	DebugEnterAlt(1);
    	// Java.g:866:9: IDENTIFIER ':' statement
    	{
    	DebugLocation(866, 9);
    	new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_synpred149_Java4634), "IDENTIFIER"); if (state.failed) return;
    	DebugLocation(866, 20);
    	new XToken((IToken)Match(input,COLON,Follow._COLON_in_synpred149_Java4636), "COLON"); if (state.failed) return;
    	DebugLocation(866, 24);
    	PushFollow(Follow._statement_in_synpred149_Java4638);
    	statement();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred149_Java

    protected virtual void Enter_synpred153_Java_fragment() {}
    protected virtual void Leave_synpred153_Java_fragment() {}

    // $ANTLR start synpred153_Java
    public void synpred153_Java_fragment()
    {
    	// Java.g:890:13: ( catches 'finally' block )
    	DebugEnterAlt(1);
    	// Java.g:890:13: catches 'finally' block
    	{
    	DebugLocation(890, 13);
    	PushFollow(Follow._catches_in_synpred153_Java4794);
    	catches();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(890, 21);
    	new XToken((IToken)Match(input,FINALLY,Follow._FINALLY_in_synpred153_Java4796), "FINALLY"); if (state.failed) return;
    	DebugLocation(890, 31);
    	PushFollow(Follow._block_in_synpred153_Java4798);
    	block();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred153_Java

    protected virtual void Enter_synpred154_Java_fragment() {}
    protected virtual void Leave_synpred154_Java_fragment() {}

    // $ANTLR start synpred154_Java
    public void synpred154_Java_fragment()
    {
    	// Java.g:891:13: ( catches )
    	DebugEnterAlt(1);
    	// Java.g:891:13: catches
    	{
    	DebugLocation(891, 13);
    	PushFollow(Follow._catches_in_synpred154_Java4812);
    	catches();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred154_Java

    protected virtual void Enter_synpred157_Java_fragment() {}
    protected virtual void Leave_synpred157_Java_fragment() {}

    // $ANTLR start synpred157_Java
    public void synpred157_Java_fragment()
    {
    	// Java.g:916:9: ( 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement )
    	DebugEnterAlt(1);
    	// Java.g:916:9: 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement
    	{
    	DebugLocation(916, 9);
    	new XToken((IToken)Match(input,FOR,Follow._FOR_in_synpred157_Java5004), "FOR"); if (state.failed) return;
    	DebugLocation(916, 15);
    	new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_synpred157_Java5006), "LPAREN"); if (state.failed) return;
    	DebugLocation(916, 19);
    	PushFollow(Follow._variableModifiers_in_synpred157_Java5008);
    	variableModifiers();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(916, 37);
    	PushFollow(Follow._type_in_synpred157_Java5010);
    	type();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(916, 42);
    	new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_synpred157_Java5012), "IDENTIFIER"); if (state.failed) return;
    	DebugLocation(916, 53);
    	new XToken((IToken)Match(input,COLON,Follow._COLON_in_synpred157_Java5014), "COLON"); if (state.failed) return;
    	DebugLocation(917, 9);
    	PushFollow(Follow._expression_in_synpred157_Java5025);
    	expression();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(917, 20);
    	new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_synpred157_Java5027), "RPAREN"); if (state.failed) return;
    	DebugLocation(917, 24);
    	PushFollow(Follow._statement_in_synpred157_Java5029);
    	statement();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred157_Java

    protected virtual void Enter_synpred161_Java_fragment() {}
    protected virtual void Leave_synpred161_Java_fragment() {}

    // $ANTLR start synpred161_Java
    public void synpred161_Java_fragment()
    {
    	// Java.g:930:9: ( localVariableDeclaration )
    	DebugEnterAlt(1);
    	// Java.g:930:9: localVariableDeclaration
    	{
    	DebugLocation(930, 9);
    	PushFollow(Follow._localVariableDeclaration_in_synpred161_Java5208);
    	localVariableDeclaration();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred161_Java

    protected virtual void Enter_synpred202_Java_fragment() {}
    protected virtual void Leave_synpred202_Java_fragment() {}

    // $ANTLR start synpred202_Java
    public void synpred202_Java_fragment()
    {
    	// Java.g:1084:9: ( castExpression )
    	DebugEnterAlt(1);
    	// Java.g:1084:9: castExpression
    	{
    	DebugLocation(1084, 9);
    	PushFollow(Follow._castExpression_in_synpred202_Java6453);
    	castExpression();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred202_Java

    protected virtual void Enter_synpred206_Java_fragment() {}
    protected virtual void Leave_synpred206_Java_fragment() {}

    // $ANTLR start synpred206_Java
    public void synpred206_Java_fragment()
    {
    	// Java.g:1094:9: ( '(' primitiveType ')' unaryExpression )
    	DebugEnterAlt(1);
    	// Java.g:1094:9: '(' primitiveType ')' unaryExpression
    	{
    	DebugLocation(1094, 9);
    	new XToken((IToken)Match(input,LPAREN,Follow._LPAREN_in_synpred206_Java6544), "LPAREN"); if (state.failed) return;
    	DebugLocation(1094, 13);
    	PushFollow(Follow._primitiveType_in_synpred206_Java6546);
    	primitiveType();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(1094, 27);
    	new XToken((IToken)Match(input,RPAREN,Follow._RPAREN_in_synpred206_Java6548), "RPAREN"); if (state.failed) return;
    	DebugLocation(1094, 31);
    	PushFollow(Follow._unaryExpression_in_synpred206_Java6550);
    	unaryExpression();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred206_Java

    protected virtual void Enter_synpred208_Java_fragment() {}
    protected virtual void Leave_synpred208_Java_fragment() {}

    // $ANTLR start synpred208_Java
    public void synpred208_Java_fragment()
    {
    	// Java.g:1104:10: ( '.' IDENTIFIER )
    	DebugEnterAlt(1);
    	// Java.g:1104:10: '.' IDENTIFIER
    	{
    	DebugLocation(1104, 10);
    	new XToken((IToken)Match(input,DOT,Follow._DOT_in_synpred208_Java6621), "DOT"); if (state.failed) return;
    	DebugLocation(1104, 14);
    	new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_synpred208_Java6623), "IDENTIFIER"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred208_Java

    protected virtual void Enter_synpred209_Java_fragment() {}
    protected virtual void Leave_synpred209_Java_fragment() {}

    // $ANTLR start synpred209_Java
    public void synpred209_Java_fragment()
    {
    	// Java.g:1106:10: ( identifierSuffix )
    	DebugEnterAlt(1);
    	// Java.g:1106:10: identifierSuffix
    	{
    	DebugLocation(1106, 10);
    	PushFollow(Follow._identifierSuffix_in_synpred209_Java6645);
    	identifierSuffix();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred209_Java

    protected virtual void Enter_synpred211_Java_fragment() {}
    protected virtual void Leave_synpred211_Java_fragment() {}

    // $ANTLR start synpred211_Java
    public void synpred211_Java_fragment()
    {
    	// Java.g:1109:10: ( '.' IDENTIFIER )
    	DebugEnterAlt(1);
    	// Java.g:1109:10: '.' IDENTIFIER
    	{
    	DebugLocation(1109, 10);
    	new XToken((IToken)Match(input,DOT,Follow._DOT_in_synpred211_Java6677), "DOT"); if (state.failed) return;
    	DebugLocation(1109, 14);
    	new XToken((IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_synpred211_Java6679), "IDENTIFIER"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred211_Java

    protected virtual void Enter_synpred212_Java_fragment() {}
    protected virtual void Leave_synpred212_Java_fragment() {}

    // $ANTLR start synpred212_Java
    public void synpred212_Java_fragment()
    {
    	// Java.g:1111:10: ( identifierSuffix )
    	DebugEnterAlt(1);
    	// Java.g:1111:10: identifierSuffix
    	{
    	DebugLocation(1111, 10);
    	PushFollow(Follow._identifierSuffix_in_synpred212_Java6701);
    	identifierSuffix();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred212_Java

    protected virtual void Enter_synpred224_Java_fragment() {}
    protected virtual void Leave_synpred224_Java_fragment() {}

    // $ANTLR start synpred224_Java
    public void synpred224_Java_fragment()
    {
    	// Java.g:1139:10: ( '[' expression ']' )
    	DebugEnterAlt(1);
    	// Java.g:1139:10: '[' expression ']'
    	{
    	DebugLocation(1139, 10);
    	new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_synpred224_Java6952), "LBRACKET"); if (state.failed) return;
    	DebugLocation(1139, 14);
    	PushFollow(Follow._expression_in_synpred224_Java6954);
    	expression();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(1139, 25);
    	new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_synpred224_Java6956), "RBRACKET"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred224_Java

    protected virtual void Enter_synpred237_Java_fragment() {}
    protected virtual void Leave_synpred237_Java_fragment() {}

    // $ANTLR start synpred237_Java
    public void synpred237_Java_fragment()
    {
    	// Java.g:1161:9: ( 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest )
    	DebugEnterAlt(1);
    	// Java.g:1161:9: 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest
    	{
    	DebugLocation(1161, 9);
    	new XToken((IToken)Match(input,NEW,Follow._NEW_in_synpred237_Java7163), "NEW"); if (state.failed) return;
    	DebugLocation(1161, 15);
    	PushFollow(Follow._nonWildcardTypeArguments_in_synpred237_Java7165);
    	nonWildcardTypeArguments();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(1161, 40);
    	PushFollow(Follow._classOrInterfaceType_in_synpred237_Java7167);
    	classOrInterfaceType();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(1161, 61);
    	PushFollow(Follow._classCreatorRest_in_synpred237_Java7169);
    	classCreatorRest();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred237_Java

    protected virtual void Enter_synpred238_Java_fragment() {}
    protected virtual void Leave_synpred238_Java_fragment() {}

    // $ANTLR start synpred238_Java
    public void synpred238_Java_fragment()
    {
    	// Java.g:1162:9: ( 'new' classOrInterfaceType classCreatorRest )
    	DebugEnterAlt(1);
    	// Java.g:1162:9: 'new' classOrInterfaceType classCreatorRest
    	{
    	DebugLocation(1162, 9);
    	new XToken((IToken)Match(input,NEW,Follow._NEW_in_synpred238_Java7179), "NEW"); if (state.failed) return;
    	DebugLocation(1162, 15);
    	PushFollow(Follow._classOrInterfaceType_in_synpred238_Java7181);
    	classOrInterfaceType();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(1162, 36);
    	PushFollow(Follow._classCreatorRest_in_synpred238_Java7183);
    	classCreatorRest();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred238_Java

    protected virtual void Enter_synpred240_Java_fragment() {}
    protected virtual void Leave_synpred240_Java_fragment() {}

    // $ANTLR start synpred240_Java
    public void synpred240_Java_fragment()
    {
    	// Java.g:1167:9: ( 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer )
    	DebugEnterAlt(1);
    	// Java.g:1167:9: 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer
    	{
    	DebugLocation(1167, 9);
    	new XToken((IToken)Match(input,NEW,Follow._NEW_in_synpred240_Java7213), "NEW"); if (state.failed) return;
    	DebugLocation(1167, 15);
    	PushFollow(Follow._createdName_in_synpred240_Java7215);
    	createdName();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(1168, 9);
    	new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_synpred240_Java7225), "LBRACKET"); if (state.failed) return;
    	DebugLocation(1168, 13);
    	new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_synpred240_Java7227), "RBRACKET"); if (state.failed) return;
    	DebugLocation(1169, 9);
    	// Java.g:1169:9: ( '[' ']' )*
    	try { DebugEnterSubRule(194);
    	while (true)
    	{
    		int alt194=2;
    		try { DebugEnterDecision(194, decisionCanBacktrack[194]);
    		int LA194_0 = input.LA(1);

    		if ((LA194_0==LBRACKET))
    		{
    			alt194=1;
    		}


    		} finally { DebugExitDecision(194); }
    		switch ( alt194 )
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// Java.g:1169:10: '[' ']'
    			{
    			DebugLocation(1169, 10);
    			new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_synpred240_Java7238), "LBRACKET"); if (state.failed) return;
    			DebugLocation(1169, 14);
    			new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_synpred240_Java7240), "RBRACKET"); if (state.failed) return;

    			}
    			break;

    		default:
    			goto loop194;
    		}
    	}

    	loop194:
    		;

    	} finally { DebugExitSubRule(194); }

    	DebugLocation(1171, 9);
    	PushFollow(Follow._arrayInitializer_in_synpred240_Java7261);
    	arrayInitializer();
    	PopFollow();
    	if (state.failed) return;

    	}
    }
    // $ANTLR end synpred240_Java

    protected virtual void Enter_synpred241_Java_fragment() {}
    protected virtual void Leave_synpred241_Java_fragment() {}

    // $ANTLR start synpred241_Java
    public void synpred241_Java_fragment()
    {
    	// Java.g:1176:13: ( '[' expression ']' )
    	DebugEnterAlt(1);
    	// Java.g:1176:13: '[' expression ']'
    	{
    	DebugLocation(1176, 13);
    	new XToken((IToken)Match(input,LBRACKET,Follow._LBRACKET_in_synpred241_Java7310), "LBRACKET"); if (state.failed) return;
    	DebugLocation(1176, 17);
    	PushFollow(Follow._expression_in_synpred241_Java7312);
    	expression();
    	PopFollow();
    	if (state.failed) return;
    	DebugLocation(1177, 13);
    	new XToken((IToken)Match(input,RBRACKET,Follow._RBRACKET_in_synpred241_Java7326), "RBRACKET"); if (state.failed) return;

    	}
    }
    // $ANTLR end synpred241_Java
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
	DFA2 dfa2;
	DFA12 dfa12;
	DFA13 dfa13;
	DFA15 dfa15;
	DFA31 dfa31;
	DFA39 dfa39;
	DFA49 dfa49;
	DFA42 dfa42;
	DFA53 dfa53;
	DFA76 dfa76;
	DFA87 dfa87;
	DFA90 dfa90;
	DFA98 dfa98;
	DFA109 dfa109;
	DFA112 dfa112;
	DFA130 dfa130;
	DFA133 dfa133;
	DFA135 dfa135;
	DFA143 dfa143;
	DFA142 dfa142;
	DFA148 dfa148;
	DFA172 dfa172;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa2 = new DFA2( this, SpecialStateTransition2 );
		dfa12 = new DFA12( this, SpecialStateTransition12 );
		dfa13 = new DFA13( this );
		dfa15 = new DFA15( this, SpecialStateTransition15 );
		dfa31 = new DFA31( this, SpecialStateTransition31 );
		dfa39 = new DFA39( this, SpecialStateTransition39 );
		dfa49 = new DFA49( this, SpecialStateTransition49 );
		dfa42 = new DFA42( this, SpecialStateTransition42 );
		dfa53 = new DFA53( this, SpecialStateTransition53 );
		dfa76 = new DFA76( this, SpecialStateTransition76 );
		dfa87 = new DFA87( this, SpecialStateTransition87 );
		dfa90 = new DFA90( this, SpecialStateTransition90 );
		dfa98 = new DFA98( this, SpecialStateTransition98 );
		dfa109 = new DFA109( this, SpecialStateTransition109 );
		dfa112 = new DFA112( this );
		dfa130 = new DFA130( this, SpecialStateTransition130 );
		dfa133 = new DFA133( this, SpecialStateTransition133 );
		dfa135 = new DFA135( this, SpecialStateTransition135 );
		dfa143 = new DFA143( this );
		dfa142 = new DFA142( this, SpecialStateTransition142 );
		dfa148 = new DFA148( this, SpecialStateTransition148 );
		dfa172 = new DFA172( this, SpecialStateTransition172 );
	}

	private class DFA2 : DFA
	{
		private const string DFA2_eotS =
			"\x14\uffff";
		private const string DFA2_eofS =
			"\x01\x03\x13\uffff";
		private const string DFA2_minS =
			"\x01\x1a\x01\x00\x12\uffff";
		private const string DFA2_maxS =
			"\x01\x70\x01\x00\x12\uffff";
		private const string DFA2_acceptS =
			"\x02\uffff\x01\x01\x01\x02\x10\uffff";
		private const string DFA2_specialS =
			"\x01\uffff\x01\x00\x12\uffff}>";
		private static readonly string[] DFA2_transitionS =
			{
				"\x01\x03\x07\uffff\x01\x03\x06\uffff\x01\x03\x01\uffff\x01\x03\x06"+
				"\uffff\x01\x03\x02\uffff\x01\x03\x01\uffff\x01\x03\x01\uffff\x01\x02"+
				"\x03\x03\x02\uffff\x02\x03\x02\uffff\x01\x03\x03\uffff\x01\x03\x02\uffff"+
				"\x01\x03\x07\uffff\x01\x03\x1d\uffff\x01\x01",
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

		public override string Description { get { return "299:9: ( ( annotations )? packageDeclaration )?"; } }

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
				int LA2_1 = input.LA(1);


				int index2_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred2_Java_fragment)) ) {s = 2;}

				else if ( (true) ) {s = 3;}


				input.Seek(index2_1);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 2, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA12 : DFA
	{
		private const string DFA12_eotS =
			"\x10\uffff";
		private const string DFA12_eofS =
			"\x10\uffff";
		private const string DFA12_minS =
			"\x01\x1a\x0c\x00\x03\uffff";
		private const string DFA12_maxS =
			"\x01\x70\x0c\x00\x03\uffff";
		private const string DFA12_acceptS =
			"\x0d\uffff\x01\x01\x01\uffff\x01\x02";
		private const string DFA12_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x03\uffff}>";
		private static readonly string[] DFA12_transitionS =
			{
				"\x01\x06\x07\uffff\x01\x0d\x06\uffff\x01\x0d\x01\uffff\x01\x07\x09"+
				"\uffff\x01\x0f\x01\uffff\x01\x08\x02\uffff\x01\x04\x01\x03\x01\x02\x02"+
				"\uffff\x01\x05\x01\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a\x02\uffff"+
				"\x01\x0b\x25\uffff\x01\x01",
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
				"\x01\uffff",
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

		public DFA12( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "342:1: classOrInterfaceDeclaration : ( classDeclaration | interfaceDeclaration );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition12(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA12_1 = input.LA(1);


				int index12_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA12_2 = input.LA(1);


				int index12_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA12_3 = input.LA(1);


				int index12_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA12_4 = input.LA(1);


				int index12_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA12_5 = input.LA(1);


				int index12_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA12_6 = input.LA(1);


				int index12_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA12_7 = input.LA(1);


				int index12_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA12_8 = input.LA(1);


				int index12_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA12_9 = input.LA(1);


				int index12_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA12_10 = input.LA(1);


				int index12_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA12_11 = input.LA(1);


				int index12_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA12_12 = input.LA(1);


				int index12_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred12_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 15;}


				input.Seek(index12_12);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 12, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA13 : DFA
	{
		private const string DFA13_eotS =
			"\x0f\uffff";
		private const string DFA13_eofS =
			"\x0f\uffff";
		private const string DFA13_minS =
			"\x01\x04\x01\uffff\x01\x04\x0c\uffff";
		private const string DFA13_maxS =
			"\x01\x73\x01\uffff\x01\x35\x0c\uffff";
		private const string DFA13_acceptS =
			"\x01\uffff\x01\x0d\x01\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06"+
			"\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x01";
		private const string DFA13_specialS =
			"\x0f\uffff}>";
		private static readonly string[] DFA13_transitionS =
			{
				"\x01\x01\x15\uffff\x01\x07\x01\uffff\x01\x01\x01\uffff\x01\x01\x02"+
				"\uffff\x02\x01\x04\uffff\x01\x01\x01\uffff\x01\x01\x01\uffff\x01\x08"+
				"\x01\uffff\x01\x01\x06\uffff\x03\x01\x01\x09\x02\uffff\x01\x05\x01\x04"+
				"\x01\x03\x01\uffff\x01\x01\x01\x06\x01\x0d\x02\uffff\x01\x0a\x03\uffff"+
				"\x01\x0b\x01\uffff\x01\x01\x01\x0c\x25\uffff\x01\x02\x02\uffff\x01\x01",
				"",
				"\x01\x0e\x30\uffff\x01\x01",
				"",
				"",
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

		private static readonly short[] DFA13_eot = DFA.UnpackEncodedString(DFA13_eotS);
		private static readonly short[] DFA13_eof = DFA.UnpackEncodedString(DFA13_eofS);
		private static readonly char[] DFA13_min = DFA.UnpackEncodedStringToUnsignedChars(DFA13_minS);
		private static readonly char[] DFA13_max = DFA.UnpackEncodedStringToUnsignedChars(DFA13_maxS);
		private static readonly short[] DFA13_accept = DFA.UnpackEncodedString(DFA13_acceptS);
		private static readonly short[] DFA13_special = DFA.UnpackEncodedString(DFA13_specialS);
		private static readonly short[][] DFA13_transition;

		static DFA13()
		{
			int numStates = DFA13_transitionS.Length;
			DFA13_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA13_transition[i] = DFA.UnpackEncodedString(DFA13_transitionS[i]);
			}
		}

		public DFA13( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 13;
			this.eot = DFA13_eot;
			this.eof = DFA13_eof;
			this.min = DFA13_min;
			this.max = DFA13_max;
			this.accept = DFA13_accept;
			this.special = DFA13_special;
			this.transition = DFA13_transition;
		}

		public override string Description { get { return "()* loopback of 350:5: ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA15 : DFA
	{
		private const string DFA15_eotS =
			"\x0f\uffff";
		private const string DFA15_eofS =
			"\x0f\uffff";
		private const string DFA15_minS =
			"\x01\x1a\x0c\x00\x02\uffff";
		private const string DFA15_maxS =
			"\x01\x70\x0c\x00\x02\uffff";
		private const string DFA15_acceptS =
			"\x0d\uffff\x01\x01\x01\x02";
		private const string DFA15_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x02\uffff}>";
		private static readonly string[] DFA15_transitionS =
			{
				"\x01\x06\x07\uffff\x01\x0d\x06\uffff\x01\x0e\x01\uffff\x01\x07\x0b"+
				"\uffff\x01\x08\x02\uffff\x01\x04\x01\x03\x01\x02\x02\uffff\x01\x05\x01"+
				"\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a\x02\uffff\x01\x0b\x25\uffff"+
				"\x01\x01",
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
				"\x01\uffff",
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

		public DFA15( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "373:1: classDeclaration : ( normalClassDeclaration | enumDeclaration );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition15(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA15_1 = input.LA(1);


				int index15_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA15_2 = input.LA(1);


				int index15_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA15_3 = input.LA(1);


				int index15_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA15_4 = input.LA(1);


				int index15_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA15_5 = input.LA(1);


				int index15_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA15_6 = input.LA(1);


				int index15_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA15_7 = input.LA(1);


				int index15_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA15_8 = input.LA(1);


				int index15_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA15_9 = input.LA(1);


				int index15_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA15_10 = input.LA(1);


				int index15_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA15_11 = input.LA(1);


				int index15_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA15_12 = input.LA(1);


				int index15_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred27_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index15_12);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 15, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA31 : DFA
	{
		private const string DFA31_eotS =
			"\x0f\uffff";
		private const string DFA31_eofS =
			"\x0f\uffff";
		private const string DFA31_minS =
			"\x01\x1a\x0c\x00\x02\uffff";
		private const string DFA31_maxS =
			"\x01\x70\x0c\x00\x02\uffff";
		private const string DFA31_acceptS =
			"\x0d\uffff\x01\x01\x01\x02";
		private const string DFA31_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x02\uffff}>";
		private static readonly string[] DFA31_transitionS =
			{
				"\x01\x06\x10\uffff\x01\x07\x09\uffff\x01\x0d\x01\uffff\x01\x08\x02"+
				"\uffff\x01\x04\x01\x03\x01\x02\x02\uffff\x01\x05\x01\x0c\x02\uffff\x01"+
				"\x09\x03\uffff\x01\x0a\x02\uffff\x01\x0b\x25\uffff\x01\x01",
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
				"\x01\uffff",
				"",
				""
			};

		private static readonly short[] DFA31_eot = DFA.UnpackEncodedString(DFA31_eotS);
		private static readonly short[] DFA31_eof = DFA.UnpackEncodedString(DFA31_eofS);
		private static readonly char[] DFA31_min = DFA.UnpackEncodedStringToUnsignedChars(DFA31_minS);
		private static readonly char[] DFA31_max = DFA.UnpackEncodedStringToUnsignedChars(DFA31_maxS);
		private static readonly short[] DFA31_accept = DFA.UnpackEncodedString(DFA31_acceptS);
		private static readonly short[] DFA31_special = DFA.UnpackEncodedString(DFA31_specialS);
		private static readonly short[][] DFA31_transition;

		static DFA31()
		{
			int numStates = DFA31_transitionS.Length;
			DFA31_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA31_transition[i] = DFA.UnpackEncodedString(DFA31_transitionS[i]);
			}
		}

		public DFA31( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 31;
			this.eot = DFA31_eot;
			this.eof = DFA31_eof;
			this.min = DFA31_min;
			this.max = DFA31_max;
			this.accept = DFA31_accept;
			this.special = DFA31_special;
			this.transition = DFA31_transition;
		}

		public override string Description { get { return "461:1: interfaceDeclaration : ( normalInterfaceDeclaration | annotationTypeDeclaration );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition31(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA31_1 = input.LA(1);


				int index31_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA31_2 = input.LA(1);


				int index31_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA31_3 = input.LA(1);


				int index31_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA31_4 = input.LA(1);


				int index31_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA31_5 = input.LA(1);


				int index31_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA31_6 = input.LA(1);


				int index31_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA31_7 = input.LA(1);


				int index31_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA31_8 = input.LA(1);


				int index31_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA31_9 = input.LA(1);


				int index31_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA31_10 = input.LA(1);


				int index31_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA31_11 = input.LA(1);


				int index31_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA31_12 = input.LA(1);


				int index31_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred43_Java_fragment)) ) {s = 13;}

				else if ( (true) ) {s = 14;}


				input.Seek(index31_12);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 31, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA39 : DFA
	{
		private const string DFA39_eotS =
			"\x15\uffff";
		private const string DFA39_eofS =
			"\x15\uffff";
		private const string DFA39_minS =
			"\x01\x04\x0e\x00\x06\uffff";
		private const string DFA39_maxS =
			"\x01\x73\x0e\x00\x06\uffff";
		private const string DFA39_acceptS =
			"\x0f\uffff\x01\x02\x01\uffff\x01\x03\x01\uffff\x01\x04\x01\x01";
		private const string DFA39_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x06\uffff}>";
		private static readonly string[] DFA39_transitionS =
			{
				"\x01\x0d\x15\uffff\x01\x06\x01\uffff\x01\x0e\x01\uffff\x01\x0e\x02"+
				"\uffff\x01\x0e\x01\x11\x04\uffff\x01\x0e\x01\uffff\x01\x11\x01\uffff"+
				"\x01\x07\x01\uffff\x01\x0e\x06\uffff\x01\x0e\x01\x13\x01\x0e\x01\x08"+
				"\x02\uffff\x01\x04\x01\x03\x01\x02\x01\uffff\x01\x0e\x01\x05\x01\x0c"+
				"\x02\uffff\x01\x09\x03\uffff\x01\x0a\x01\uffff\x01\x0f\x01\x0b\x25\uffff"+
				"\x01\x01\x02\uffff\x01\x0f",
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
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"",
				"",
				"",
				"",
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

		public override string Description { get { return "503:1: memberDecl : ( fieldDeclaration | methodDeclaration | classDeclaration | interfaceDeclaration );"; } }

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
				int LA39_1 = input.LA(1);


				int index39_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA39_2 = input.LA(1);


				int index39_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA39_3 = input.LA(1);


				int index39_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA39_4 = input.LA(1);


				int index39_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA39_5 = input.LA(1);


				int index39_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA39_6 = input.LA(1);


				int index39_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA39_7 = input.LA(1);


				int index39_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA39_8 = input.LA(1);


				int index39_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA39_9 = input.LA(1);


				int index39_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA39_10 = input.LA(1);


				int index39_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA39_11 = input.LA(1);


				int index39_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA39_12 = input.LA(1);


				int index39_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred54_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 19;}


				input.Seek(index39_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA39_13 = input.LA(1);


				int index39_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}


				input.Seek(index39_13);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA39_14 = input.LA(1);


				int index39_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred52_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred53_Java_fragment)) ) {s = 15;}


				input.Seek(index39_14);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 39, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA49 : DFA
	{
		private const string DFA49_eotS =
			"\x12\uffff";
		private const string DFA49_eofS =
			"\x12\uffff";
		private const string DFA49_minS =
			"\x01\x04\x0e\x00\x03\uffff";
		private const string DFA49_maxS =
			"\x01\x73\x0e\x00\x03\uffff";
		private const string DFA49_acceptS =
			"\x0f\uffff\x01\x02\x01\uffff\x01\x01";
		private const string DFA49_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x03\uffff}>";
		private static readonly string[] DFA49_transitionS =
			{
				"\x01\x0e\x15\uffff\x01\x06\x01\uffff\x01\x0f\x01\uffff\x01\x0f\x02"+
				"\uffff\x01\x0f\x05\uffff\x01\x0f\x03\uffff\x01\x07\x01\uffff\x01\x0f"+
				"\x06\uffff\x01\x0f\x01\uffff\x01\x0f\x01\x08\x02\uffff\x01\x04\x01\x03"+
				"\x01\x02\x01\uffff\x01\x0f\x01\x05\x01\x0c\x02\uffff\x01\x09\x03\uffff"+
				"\x01\x0a\x01\uffff\x01\x0f\x01\x0b\x25\uffff\x01\x01\x02\uffff\x01\x0d",
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
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
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

		public DFA49( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "511:1: methodDeclaration : ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' | modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' ) );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition49(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA49_1 = input.LA(1);


				int index49_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA49_2 = input.LA(1);


				int index49_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA49_3 = input.LA(1);


				int index49_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA49_4 = input.LA(1);


				int index49_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA49_5 = input.LA(1);


				int index49_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA49_6 = input.LA(1);


				int index49_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA49_7 = input.LA(1);


				int index49_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA49_8 = input.LA(1);


				int index49_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA49_9 = input.LA(1);


				int index49_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA49_10 = input.LA(1);


				int index49_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA49_11 = input.LA(1);


				int index49_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA49_12 = input.LA(1);


				int index49_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA49_13 = input.LA(1);


				int index49_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_13);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA49_14 = input.LA(1);


				int index49_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred59_Java_fragment)) ) {s = 17;}

				else if ( (true) ) {s = 15;}


				input.Seek(index49_14);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 49, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA42 : DFA
	{
		private const string DFA42_eotS =
			"\x35\uffff";
		private const string DFA42_eofS =
			"\x35\uffff";
		private const string DFA42_minS =
			"\x01\x04\x01\uffff\x10\x00\x23\uffff";
		private const string DFA42_maxS =
			"\x01\x73\x01\uffff\x10\x00\x23\uffff";
		private const string DFA42_acceptS =
			"\x01\uffff\x01\x01\x10\uffff\x01\x02\x22\uffff";
		private const string DFA42_specialS =
			"\x02\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f"+
			"\x23\uffff}>";
		private static readonly string[] DFA42_transitionS =
			{
				"\x01\x05\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01"+
				"\x0d\x01\x0e\x0c\uffff\x02\x12\x01\x10\x01\x12\x01\x10\x02\uffff\x01"+
				"\x10\x01\x12\x01\uffff\x01\x12\x01\uffff\x01\x12\x01\x10\x01\uffff\x01"+
				"\x12\x01\uffff\x01\x12\x01\uffff\x01\x10\x01\x12\x01\uffff\x01\x12\x03"+
				"\uffff\x01\x10\x01\x12\x01\x10\x01\x12\x01\x0f\x01\uffff\x04\x12\x01"+
				"\x10\x02\x12\x01\x04\x02\x12\x01\x02\x01\x12\x01\uffff\x02\x12\x01\x11"+
				"\x02\x12\x01\x03\x01\uffff\x02\x12\x02\uffff\x01\x12\x04\uffff\x02\x12"+
				"\x05\uffff\x04\x12\x0e\uffff\x01\x12\x02\uffff\x01\x01",
				"",
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
				"\x01\uffff",
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
				"",
				"",
				"",
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

		public DFA42( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
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

		public override string Description { get { return "522:9: ( explicitConstructorInvocation )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition42(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA42_2 = input.LA(1);


				int index42_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_2);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA42_3 = input.LA(1);


				int index42_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_3);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA42_4 = input.LA(1);


				int index42_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_4);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA42_5 = input.LA(1);


				int index42_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_5);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA42_6 = input.LA(1);


				int index42_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_6);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA42_7 = input.LA(1);


				int index42_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_7);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA42_8 = input.LA(1);


				int index42_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_8);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA42_9 = input.LA(1);


				int index42_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_9);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA42_10 = input.LA(1);


				int index42_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_10);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA42_11 = input.LA(1);


				int index42_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_11);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA42_12 = input.LA(1);


				int index42_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_12);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA42_13 = input.LA(1);


				int index42_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_13);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA42_14 = input.LA(1);


				int index42_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_14);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA42_15 = input.LA(1);


				int index42_15 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_15);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA42_16 = input.LA(1);


				int index42_16 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_16);
				if ( s>=0 ) return s;
				break;
			case 15:
				int LA42_17 = input.LA(1);


				int index42_17 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index42_17);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 42, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA53 : DFA
	{
		private const string DFA53_eotS =
			"\x16\uffff";
		private const string DFA53_eofS =
			"\x16\uffff";
		private const string DFA53_minS =
			"\x01\x04\x0e\x00\x07\uffff";
		private const string DFA53_maxS =
			"\x01\x73\x0e\x00\x07\uffff";
		private const string DFA53_acceptS =
			"\x0f\uffff\x01\x02\x01\uffff\x01\x03\x01\x04\x01\uffff\x01\x05\x01\x01";
		private const string DFA53_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x07\uffff}>";
		private static readonly string[] DFA53_transitionS =
			{
				"\x01\x0d\x15\uffff\x01\x06\x01\uffff\x01\x0e\x01\uffff\x01\x0e\x02"+
				"\uffff\x01\x0e\x01\x12\x04\uffff\x01\x0e\x01\uffff\x01\x12\x01\uffff"+
				"\x01\x07\x01\uffff\x01\x0e\x06\uffff\x01\x0e\x01\x11\x01\x0e\x01\x08"+
				"\x02\uffff\x01\x04\x01\x03\x01\x02\x01\uffff\x01\x0e\x01\x05\x01\x0c"+
				"\x02\uffff\x01\x09\x03\uffff\x01\x0a\x01\uffff\x01\x0f\x01\x0b\x07\uffff"+
				"\x01\x14\x1d\uffff\x01\x01\x02\uffff\x01\x0f",
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
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"",
				"",
				"",
				"",
				"",
				"",
				""
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

		public override string Description { get { return "563:1: interfaceBodyDeclaration : ( interfaceFieldDeclaration | interfaceMethodDeclaration | interfaceDeclaration | classDeclaration | ';' );"; } }

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
				int LA53_1 = input.LA(1);


				int index53_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA53_2 = input.LA(1);


				int index53_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA53_3 = input.LA(1);


				int index53_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA53_4 = input.LA(1);


				int index53_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA53_5 = input.LA(1);


				int index53_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA53_6 = input.LA(1);


				int index53_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA53_7 = input.LA(1);


				int index53_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA53_8 = input.LA(1);


				int index53_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA53_9 = input.LA(1);


				int index53_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA53_10 = input.LA(1);


				int index53_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA53_11 = input.LA(1);


				int index53_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA53_12 = input.LA(1);


				int index53_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred70_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred71_Java_fragment)) ) {s = 18;}


				input.Seek(index53_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA53_13 = input.LA(1);


				int index53_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}


				input.Seek(index53_13);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA53_14 = input.LA(1);


				int index53_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred68_Java_fragment)) ) {s = 21;}

				else if ( (EvaluatePredicate(synpred69_Java_fragment)) ) {s = 15;}


				input.Seek(index53_14);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 53, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA76 : DFA
	{
		private const string DFA76_eotS =
			"\x12\uffff";
		private const string DFA76_eofS =
			"\x12\uffff";
		private const string DFA76_minS =
			"\x01\x04\x01\uffff\x01\x00\x01\uffff\x01\x00\x0d\uffff";
		private const string DFA76_maxS =
			"\x01\x73\x01\uffff\x01\x00\x01\uffff\x01\x00\x0d\uffff";
		private const string DFA76_acceptS =
			"\x01\uffff\x01\x01\x01\uffff\x01\x02\x0e\uffff";
		private const string DFA76_specialS =
			"\x02\uffff\x01\x00\x01\uffff\x01\x01\x0d\uffff}>";
		private static readonly string[] DFA76_transitionS =
			{
				"\x0a\x03\x0e\uffff\x01\x03\x01\uffff\x01\x03\x02\uffff\x01\x03\x05"+
				"\uffff\x01\x03\x05\uffff\x01\x03\x06\uffff\x01\x03\x01\uffff\x01\x03"+
				"\x01\uffff\x01\x03\x05\uffff\x01\x03\x02\uffff\x01\x04\x02\uffff\x01"+
				"\x02\x04\uffff\x01\x03\x02\uffff\x01\x03\x26\uffff\x01\x01",
				"",
				"\x01\uffff",
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
				""
			};

		private static readonly short[] DFA76_eot = DFA.UnpackEncodedString(DFA76_eotS);
		private static readonly short[] DFA76_eof = DFA.UnpackEncodedString(DFA76_eofS);
		private static readonly char[] DFA76_min = DFA.UnpackEncodedStringToUnsignedChars(DFA76_minS);
		private static readonly char[] DFA76_max = DFA.UnpackEncodedStringToUnsignedChars(DFA76_maxS);
		private static readonly short[] DFA76_accept = DFA.UnpackEncodedString(DFA76_acceptS);
		private static readonly short[] DFA76_special = DFA.UnpackEncodedString(DFA76_specialS);
		private static readonly short[][] DFA76_transition;

		static DFA76()
		{
			int numStates = DFA76_transitionS.Length;
			DFA76_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA76_transition[i] = DFA.UnpackEncodedString(DFA76_transitionS[i]);
			}
		}

		public DFA76( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 76;
			this.eot = DFA76_eot;
			this.eof = DFA76_eof;
			this.min = DFA76_min;
			this.max = DFA76_max;
			this.accept = DFA76_accept;
			this.special = DFA76_special;
			this.transition = DFA76_transition;
		}

		public override string Description { get { return "689:1: explicitConstructorInvocation : ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' | primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition76(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA76_2 = input.LA(1);


				int index76_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred103_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 3;}


				input.Seek(index76_2);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA76_4 = input.LA(1);


				int index76_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred103_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 3;}


				input.Seek(index76_4);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 76, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA87 : DFA
	{
		private const string DFA87_eotS =
			"\x16\uffff";
		private const string DFA87_eofS =
			"\x16\uffff";
		private const string DFA87_minS =
			"\x01\x04\x0e\x00\x07\uffff";
		private const string DFA87_maxS =
			"\x01\x70\x0e\x00\x07\uffff";
		private const string DFA87_acceptS =
			"\x0f\uffff\x01\x03\x01\x04\x01\x05\x01\x07\x01\x01\x01\x02\x01\x06";
		private const string DFA87_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x07\uffff}>";
		private static readonly string[] DFA87_transitionS =
			{
				"\x01\x0d\x15\uffff\x01\x06\x01\uffff\x01\x0e\x01\uffff\x01\x0e\x02"+
				"\uffff\x01\x0e\x01\x0f\x04\uffff\x01\x0e\x01\uffff\x01\x11\x01\uffff"+
				"\x01\x07\x01\uffff\x01\x0e\x06\uffff\x01\x0e\x01\x10\x01\x0e\x01\x08"+
				"\x02\uffff\x01\x04\x01\x03\x01\x02\x01\uffff\x01\x0e\x01\x05\x01\x0c"+
				"\x02\uffff\x01\x09\x03\uffff\x01\x0a\x02\uffff\x01\x0b\x07\uffff\x01"+
				"\x12\x1d\uffff\x01\x01",
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
				"\x01\uffff",
				"\x01\uffff",
				"\x01\uffff",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA87_eot = DFA.UnpackEncodedString(DFA87_eotS);
		private static readonly short[] DFA87_eof = DFA.UnpackEncodedString(DFA87_eofS);
		private static readonly char[] DFA87_min = DFA.UnpackEncodedStringToUnsignedChars(DFA87_minS);
		private static readonly char[] DFA87_max = DFA.UnpackEncodedStringToUnsignedChars(DFA87_maxS);
		private static readonly short[] DFA87_accept = DFA.UnpackEncodedString(DFA87_acceptS);
		private static readonly short[] DFA87_special = DFA.UnpackEncodedString(DFA87_specialS);
		private static readonly short[][] DFA87_transition;

		static DFA87()
		{
			int numStates = DFA87_transitionS.Length;
			DFA87_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA87_transition[i] = DFA.UnpackEncodedString(DFA87_transitionS[i]);
			}
		}

		public DFA87( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 87;
			this.eot = DFA87_eot;
			this.eof = DFA87_eof;
			this.min = DFA87_min;
			this.max = DFA87_max;
			this.accept = DFA87_accept;
			this.special = DFA87_special;
			this.transition = DFA87_transition;
		}

		public override string Description { get { return "773:1: annotationTypeElementDeclaration : ( annotationMethodDeclaration | interfaceFieldDeclaration | normalClassDeclaration | normalInterfaceDeclaration | enumDeclaration | annotationTypeDeclaration | ';' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition87(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA87_1 = input.LA(1);


				int index87_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA87_2 = input.LA(1);


				int index87_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA87_3 = input.LA(1);


				int index87_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA87_4 = input.LA(1);


				int index87_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA87_5 = input.LA(1);


				int index87_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_5);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA87_6 = input.LA(1);


				int index87_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_6);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA87_7 = input.LA(1);


				int index87_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_7);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA87_8 = input.LA(1);


				int index87_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_8);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA87_9 = input.LA(1);


				int index87_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_9);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA87_10 = input.LA(1);


				int index87_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_10);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA87_11 = input.LA(1);


				int index87_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_11);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA87_12 = input.LA(1);


				int index87_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}

				else if ( (EvaluatePredicate(synpred119_Java_fragment)) ) {s = 15;}

				else if ( (EvaluatePredicate(synpred120_Java_fragment)) ) {s = 16;}

				else if ( (EvaluatePredicate(synpred121_Java_fragment)) ) {s = 17;}

				else if ( (EvaluatePredicate(synpred122_Java_fragment)) ) {s = 21;}


				input.Seek(index87_12);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA87_13 = input.LA(1);


				int index87_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}


				input.Seek(index87_13);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA87_14 = input.LA(1);


				int index87_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred117_Java_fragment)) ) {s = 19;}

				else if ( (EvaluatePredicate(synpred118_Java_fragment)) ) {s = 20;}


				input.Seek(index87_14);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 87, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA90 : DFA
	{
		private const string DFA90_eotS =
			"\x34\uffff";
		private const string DFA90_eofS =
			"\x34\uffff";
		private const string DFA90_minS =
			"\x01\x04\x04\x00\x06\uffff\x01\x00\x28\uffff";
		private const string DFA90_maxS =
			"\x01\x70\x04\x00\x06\uffff\x01\x00\x28\uffff";
		private const string DFA90_acceptS =
			"\x05\uffff\x01\x02\x0c\uffff\x01\x03\x20\uffff\x01\x01";
		private const string DFA90_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x06\uffff\x01\x04\x28\uffff}>";
		private static readonly string[] DFA90_transitionS =
			{
				"\x01\x03\x09\x12\x0c\uffff\x01\x05\x01\x12\x01\x04\x01\x12\x01\x04"+
				"\x02\uffff\x01\x04\x01\x05\x01\uffff\x01\x12\x01\uffff\x01\x12\x01\x04"+
				"\x01\uffff\x01\x05\x01\uffff\x01\x01\x01\uffff\x01\x04\x01\x12\x01\uffff"+
				"\x01\x12\x03\uffff\x01\x04\x01\x05\x01\x04\x01\x05\x01\x12\x01\uffff"+
				"\x03\x05\x01\x12\x01\x04\x02\x05\x02\x12\x01\x0b\x02\x12\x01\uffff\x01"+
				"\x05\x02\x12\x01\x05\x02\x12\x01\uffff\x01\x12\x03\uffff\x01\x12\x04"+
				"\uffff\x02\x12\x05\uffff\x04\x12\x0e\uffff\x01\x02",
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
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
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

		private static readonly short[] DFA90_eot = DFA.UnpackEncodedString(DFA90_eotS);
		private static readonly short[] DFA90_eof = DFA.UnpackEncodedString(DFA90_eofS);
		private static readonly char[] DFA90_min = DFA.UnpackEncodedStringToUnsignedChars(DFA90_minS);
		private static readonly char[] DFA90_max = DFA.UnpackEncodedStringToUnsignedChars(DFA90_maxS);
		private static readonly short[] DFA90_accept = DFA.UnpackEncodedString(DFA90_acceptS);
		private static readonly short[] DFA90_special = DFA.UnpackEncodedString(DFA90_specialS);
		private static readonly short[][] DFA90_transition;

		static DFA90()
		{
			int numStates = DFA90_transitionS.Length;
			DFA90_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA90_transition[i] = DFA.UnpackEncodedString(DFA90_transitionS[i]);
			}
		}

		public DFA90( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 90;
			this.eot = DFA90_eot;
			this.eof = DFA90_eof;
			this.min = DFA90_min;
			this.max = DFA90_max;
			this.accept = DFA90_accept;
			this.special = DFA90_special;
			this.transition = DFA90_transition;
		}

		public override string Description { get { return "824:1: blockStatement : ( localVariableDeclarationStatement | classOrInterfaceDeclaration | statement );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition90(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA90_1 = input.LA(1);


				int index90_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred125_Java_fragment)) ) {s = 51;}

				else if ( (EvaluatePredicate(synpred126_Java_fragment)) ) {s = 5;}


				input.Seek(index90_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA90_2 = input.LA(1);


				int index90_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred125_Java_fragment)) ) {s = 51;}

				else if ( (EvaluatePredicate(synpred126_Java_fragment)) ) {s = 5;}


				input.Seek(index90_2);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA90_3 = input.LA(1);


				int index90_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred125_Java_fragment)) ) {s = 51;}

				else if ( (true) ) {s = 18;}


				input.Seek(index90_3);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA90_4 = input.LA(1);


				int index90_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred125_Java_fragment)) ) {s = 51;}

				else if ( (true) ) {s = 18;}


				input.Seek(index90_4);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA90_11 = input.LA(1);


				int index90_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred126_Java_fragment)) ) {s = 5;}

				else if ( (true) ) {s = 18;}


				input.Seek(index90_11);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 90, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA98 : DFA
	{
		private const string DFA98_eotS =
			"\x28\uffff";
		private const string DFA98_eofS =
			"\x28\uffff";
		private const string DFA98_minS =
			"\x01\x04\x01\uffff\x01\x00\x13\uffff\x01\x00\x11\uffff";
		private const string DFA98_maxS =
			"\x01\x61\x01\uffff\x01\x00\x13\uffff\x01\x00\x11\uffff";
		private const string DFA98_acceptS =
			"\x01\uffff\x01\x01\x01\uffff\x01\x04\x01\x05\x01\x06\x01\x07\x01\x08"+
			"\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x15\uffff\x01"+
			"\x11\x01\x02\x01\x03\x01\x10";
		private const string DFA98_specialS =
			"\x02\uffff\x01\x00\x13\uffff\x01\x01\x11\uffff}>";
		private static readonly string[] DFA98_transitionS =
			{
				"\x01\x16\x09\x0e\x0d\uffff\x01\x02\x01\x0e\x01\x0c\x01\x0e\x02\uffff"+
				"\x01\x0e\x02\uffff\x01\x0d\x01\uffff\x01\x06\x01\x0e\x05\uffff\x01\x0e"+
				"\x01\x04\x01\uffff\x01\x03\x03\uffff\x01\x0e\x01\uffff\x01\x0e\x01\uffff"+
				"\x01\x0e\x04\uffff\x01\x0a\x01\x0e\x02\uffff\x01\x0e\x01\x08\x01\x09"+
				"\x01\x0e\x01\x0b\x02\uffff\x01\x07\x01\x0e\x01\uffff\x01\x05\x01\x0e"+
				"\x01\uffff\x01\x01\x03\uffff\x01\x24\x04\uffff\x02\x0e\x05\uffff\x04"+
				"\x0e",
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
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA98_eot = DFA.UnpackEncodedString(DFA98_eotS);
		private static readonly short[] DFA98_eof = DFA.UnpackEncodedString(DFA98_eofS);
		private static readonly char[] DFA98_min = DFA.UnpackEncodedStringToUnsignedChars(DFA98_minS);
		private static readonly char[] DFA98_max = DFA.UnpackEncodedStringToUnsignedChars(DFA98_maxS);
		private static readonly short[] DFA98_accept = DFA.UnpackEncodedString(DFA98_acceptS);
		private static readonly short[] DFA98_special = DFA.UnpackEncodedString(DFA98_specialS);
		private static readonly short[][] DFA98_transition;

		static DFA98()
		{
			int numStates = DFA98_transitionS.Length;
			DFA98_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA98_transition[i] = DFA.UnpackEncodedString(DFA98_transitionS[i]);
			}
		}

		public DFA98( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 98;
			this.eot = DFA98_eot;
			this.eof = DFA98_eof;
			this.min = DFA98_min;
			this.max = DFA98_max;
			this.accept = DFA98_accept;
			this.special = DFA98_special;
			this.transition = DFA98_transition;
		}

		public override string Description { get { return "843:1: statement : ( block | ( 'assert' ) expression ( ':' expression )? ';' | 'assert' expression ( ':' expression )? ';' | 'if' parExpression statement ( 'else' statement )? | forstatement | 'while' parExpression statement | 'do' statement 'while' parExpression ';' | trystatement | 'switch' parExpression '{' switchBlockStatementGroups '}' | 'synchronized' parExpression block | 'return' ( expression )? ';' | 'throw' expression ';' | 'break' ( IDENTIFIER )? ';' | 'continue' ( IDENTIFIER )? ';' | expression ';' | IDENTIFIER ':' statement | ';' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition98(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA98_2 = input.LA(1);


				int index98_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred130_Java_fragment)) ) {s = 37;}

				else if ( (EvaluatePredicate(synpred132_Java_fragment)) ) {s = 38;}


				input.Seek(index98_2);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA98_22 = input.LA(1);


				int index98_22 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred148_Java_fragment)) ) {s = 14;}

				else if ( (EvaluatePredicate(synpred149_Java_fragment)) ) {s = 39;}


				input.Seek(index98_22);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 98, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA109 : DFA
	{
		private const string DFA109_eotS =
			"\x19\uffff";
		private const string DFA109_eofS =
			"\x19\uffff";
		private const string DFA109_minS =
			"\x01\x04\x02\uffff\x02\x00\x14\uffff";
		private const string DFA109_maxS =
			"\x01\x70\x02\uffff\x02\x00\x14\uffff";
		private const string DFA109_acceptS =
			"\x01\uffff\x01\x01\x03\uffff\x01\x02\x13\uffff";
		private const string DFA109_specialS =
			"\x03\uffff\x01\x00\x01\x01\x14\uffff}>";
		private static readonly string[] DFA109_transitionS =
			{
				"\x01\x03\x09\x05\x0e\uffff\x01\x04\x01\uffff\x01\x04\x02\uffff\x01"+
				"\x04\x05\uffff\x01\x04\x03\uffff\x01\x01\x01\uffff\x01\x04\x06\uffff"+
				"\x01\x04\x01\uffff\x01\x04\x01\uffff\x01\x05\x05\uffff\x01\x04\x02\uffff"+
				"\x01\x05\x02\uffff\x01\x05\x04\uffff\x01\x05\x02\uffff\x01\x05\x0a\uffff"+
				"\x02\x05\x05\uffff\x04\x05\x0e\uffff\x01\x01",
				"",
				"",
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
				""
			};

		private static readonly short[] DFA109_eot = DFA.UnpackEncodedString(DFA109_eotS);
		private static readonly short[] DFA109_eof = DFA.UnpackEncodedString(DFA109_eofS);
		private static readonly char[] DFA109_min = DFA.UnpackEncodedStringToUnsignedChars(DFA109_minS);
		private static readonly char[] DFA109_max = DFA.UnpackEncodedStringToUnsignedChars(DFA109_maxS);
		private static readonly short[] DFA109_accept = DFA.UnpackEncodedString(DFA109_acceptS);
		private static readonly short[] DFA109_special = DFA.UnpackEncodedString(DFA109_specialS);
		private static readonly short[][] DFA109_transition;

		static DFA109()
		{
			int numStates = DFA109_transitionS.Length;
			DFA109_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA109_transition[i] = DFA.UnpackEncodedString(DFA109_transitionS[i]);
			}
		}

		public DFA109( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 109;
			this.eot = DFA109_eot;
			this.eof = DFA109_eof;
			this.min = DFA109_min;
			this.max = DFA109_max;
			this.accept = DFA109_accept;
			this.special = DFA109_special;
			this.transition = DFA109_transition;
		}

		public override string Description { get { return "929:1: forInit : ( localVariableDeclaration | expressionList );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition109(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA109_3 = input.LA(1);


				int index109_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred161_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 5;}


				input.Seek(index109_3);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA109_4 = input.LA(1);


				int index109_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred161_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 5;}


				input.Seek(index109_4);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 109, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA112 : DFA
	{
		private const string DFA112_eotS =
			"\x0f\uffff";
		private const string DFA112_eofS =
			"\x0f\uffff";
		private const string DFA112_minS =
			"\x01\x56\x0a\uffff\x01\x72\x01\x56\x02\uffff";
		private const string DFA112_maxS =
			"\x01\x73\x0a\uffff\x02\x72\x02\uffff";
		private const string DFA112_acceptS =
			"\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
			"\x08\x01\x09\x01\x0a\x02\uffff\x01\x0b\x01\x0c";
		private const string DFA112_specialS =
			"\x0f\uffff}>";
		private static readonly string[] DFA112_transitionS =
			{
				"\x01\x01\x11\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07"+
				"\x01\x08\x01\x09\x02\uffff\x01\x0b\x01\x0a",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x01\x0c",
				"\x01\x0e\x1b\uffff\x01\x0d",
				"",
				""
			};

		private static readonly short[] DFA112_eot = DFA.UnpackEncodedString(DFA112_eotS);
		private static readonly short[] DFA112_eof = DFA.UnpackEncodedString(DFA112_eofS);
		private static readonly char[] DFA112_min = DFA.UnpackEncodedStringToUnsignedChars(DFA112_minS);
		private static readonly char[] DFA112_max = DFA.UnpackEncodedStringToUnsignedChars(DFA112_maxS);
		private static readonly short[] DFA112_accept = DFA.UnpackEncodedString(DFA112_acceptS);
		private static readonly short[] DFA112_special = DFA.UnpackEncodedString(DFA112_specialS);
		private static readonly short[][] DFA112_transition;

		static DFA112()
		{
			int numStates = DFA112_transitionS.Length;
			DFA112_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA112_transition[i] = DFA.UnpackEncodedString(DFA112_transitionS[i]);
			}
		}

		public DFA112( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 112;
			this.eot = DFA112_eot;
			this.eof = DFA112_eof;
			this.min = DFA112_min;
			this.max = DFA112_max;
			this.accept = DFA112_accept;
			this.special = DFA112_special;
			this.transition = DFA112_transition;
		}

		public override string Description { get { return "952:1: assignmentOperator : ( '=' | '+=' | '-=' | '*=' | '/=' | '&=' | '|=' | '^=' | '%=' | '<' '<' '=' | '>' '>' '>' '=' | '>' '>' '=' );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA130 : DFA
	{
		private const string DFA130_eotS =
			"\x14\uffff";
		private const string DFA130_eofS =
			"\x14\uffff";
		private const string DFA130_minS =
			"\x01\x04\x02\uffff\x01\x00\x10\uffff";
		private const string DFA130_maxS =
			"\x01\x58\x02\uffff\x01\x00\x10\uffff";
		private const string DFA130_acceptS =
			"\x01\uffff\x01\x01\x01\x02\x01\uffff\x01\x04\x0e\uffff\x01\x03";
		private const string DFA130_specialS =
			"\x03\uffff\x01\x00\x10\uffff}>";
		private static readonly string[] DFA130_transitionS =
			{
				"\x0a\x04\x0e\uffff\x01\x04\x01\uffff\x01\x04\x02\uffff\x01\x04\x05"+
				"\uffff\x01\x04\x05\uffff\x01\x04\x06\uffff\x01\x04\x01\uffff\x01\x04"+
				"\x01\uffff\x01\x04\x05\uffff\x01\x04\x02\uffff\x01\x04\x02\uffff\x01"+
				"\x04\x04\uffff\x01\x04\x02\uffff\x01\x03\x0a\uffff\x01\x02\x01\x01",
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
				"",
				"",
				""
			};

		private static readonly short[] DFA130_eot = DFA.UnpackEncodedString(DFA130_eotS);
		private static readonly short[] DFA130_eof = DFA.UnpackEncodedString(DFA130_eofS);
		private static readonly char[] DFA130_min = DFA.UnpackEncodedStringToUnsignedChars(DFA130_minS);
		private static readonly char[] DFA130_max = DFA.UnpackEncodedStringToUnsignedChars(DFA130_maxS);
		private static readonly short[] DFA130_accept = DFA.UnpackEncodedString(DFA130_acceptS);
		private static readonly short[] DFA130_special = DFA.UnpackEncodedString(DFA130_specialS);
		private static readonly short[][] DFA130_transition;

		static DFA130()
		{
			int numStates = DFA130_transitionS.Length;
			DFA130_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA130_transition[i] = DFA.UnpackEncodedString(DFA130_transitionS[i]);
			}
		}

		public DFA130( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 130;
			this.eot = DFA130_eot;
			this.eof = DFA130_eof;
			this.min = DFA130_min;
			this.max = DFA130_max;
			this.accept = DFA130_accept;
			this.special = DFA130_special;
			this.transition = DFA130_transition;
		}

		public override string Description { get { return "1081:1: unaryExpressionNotPlusMinus : ( '~' unaryExpression | '!' unaryExpression | castExpression | primary ( selector )* ( '++' | '--' )? );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition130(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA130_3 = input.LA(1);


				int index130_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred202_Java_fragment)) ) {s = 19;}

				else if ( (true) ) {s = 4;}


				input.Seek(index130_3);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 130, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA133 : DFA
	{
		private const string DFA133_eotS =
			"\x21\uffff";
		private const string DFA133_eofS =
			"\x01\x04\x20\uffff";
		private const string DFA133_minS =
			"\x01\x33\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		private const string DFA133_maxS =
			"\x01\x73\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		private const string DFA133_acceptS =
			"\x02\uffff\x01\x01\x01\uffff\x01\x02\x1c\uffff";
		private const string DFA133_specialS =
			"\x01\uffff\x01\x00\x01\uffff\x01\x01\x1d\uffff}>";
		private static readonly string[] DFA133_transitionS =
			{
				"\x01\x04\x18\uffff\x01\x02\x01\x04\x01\uffff\x01\x04\x01\x01\x03\x04"+
				"\x01\x03\x01\uffff\x01\x04\x02\uffff\x17\x04\x01\uffff\x03\x04",
				"\x01\uffff",
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
				"",
				"",
				"",
				"",
				"",
				"",
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

		private static readonly short[] DFA133_eot = DFA.UnpackEncodedString(DFA133_eotS);
		private static readonly short[] DFA133_eof = DFA.UnpackEncodedString(DFA133_eofS);
		private static readonly char[] DFA133_min = DFA.UnpackEncodedStringToUnsignedChars(DFA133_minS);
		private static readonly char[] DFA133_max = DFA.UnpackEncodedStringToUnsignedChars(DFA133_maxS);
		private static readonly short[] DFA133_accept = DFA.UnpackEncodedString(DFA133_acceptS);
		private static readonly short[] DFA133_special = DFA.UnpackEncodedString(DFA133_specialS);
		private static readonly short[][] DFA133_transition;

		static DFA133()
		{
			int numStates = DFA133_transitionS.Length;
			DFA133_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA133_transition[i] = DFA.UnpackEncodedString(DFA133_transitionS[i]);
			}
		}

		public DFA133( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 133;
			this.eot = DFA133_eot;
			this.eof = DFA133_eof;
			this.min = DFA133_min;
			this.max = DFA133_max;
			this.accept = DFA133_accept;
			this.special = DFA133_special;
			this.transition = DFA133_transition;
		}

		public override string Description { get { return "1106:9: ( identifierSuffix )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition133(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA133_1 = input.LA(1);


				int index133_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred209_Java_fragment)) ) {s = 2;}

				else if ( (true) ) {s = 4;}


				input.Seek(index133_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA133_3 = input.LA(1);


				int index133_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred209_Java_fragment)) ) {s = 2;}

				else if ( (true) ) {s = 4;}


				input.Seek(index133_3);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 133, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA135 : DFA
	{
		private const string DFA135_eotS =
			"\x21\uffff";
		private const string DFA135_eofS =
			"\x01\x04\x20\uffff";
		private const string DFA135_minS =
			"\x01\x33\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		private const string DFA135_maxS =
			"\x01\x73\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		private const string DFA135_acceptS =
			"\x02\uffff\x01\x01\x01\uffff\x01\x02\x1c\uffff";
		private const string DFA135_specialS =
			"\x01\uffff\x01\x00\x01\uffff\x01\x01\x1d\uffff}>";
		private static readonly string[] DFA135_transitionS =
			{
				"\x01\x04\x18\uffff\x01\x02\x01\x04\x01\uffff\x01\x04\x01\x01\x03\x04"+
				"\x01\x03\x01\uffff\x01\x04\x02\uffff\x17\x04\x01\uffff\x03\x04",
				"\x01\uffff",
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
				"",
				"",
				"",
				"",
				"",
				"",
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

		private static readonly short[] DFA135_eot = DFA.UnpackEncodedString(DFA135_eotS);
		private static readonly short[] DFA135_eof = DFA.UnpackEncodedString(DFA135_eofS);
		private static readonly char[] DFA135_min = DFA.UnpackEncodedStringToUnsignedChars(DFA135_minS);
		private static readonly char[] DFA135_max = DFA.UnpackEncodedStringToUnsignedChars(DFA135_maxS);
		private static readonly short[] DFA135_accept = DFA.UnpackEncodedString(DFA135_acceptS);
		private static readonly short[] DFA135_special = DFA.UnpackEncodedString(DFA135_specialS);
		private static readonly short[][] DFA135_transition;

		static DFA135()
		{
			int numStates = DFA135_transitionS.Length;
			DFA135_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA135_transition[i] = DFA.UnpackEncodedString(DFA135_transitionS[i]);
			}
		}

		public DFA135( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 135;
			this.eot = DFA135_eot;
			this.eof = DFA135_eof;
			this.min = DFA135_min;
			this.max = DFA135_max;
			this.accept = DFA135_accept;
			this.special = DFA135_special;
			this.transition = DFA135_transition;
		}

		public override string Description { get { return "1111:9: ( identifierSuffix )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition135(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA135_1 = input.LA(1);


				int index135_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred212_Java_fragment)) ) {s = 2;}

				else if ( (true) ) {s = 4;}


				input.Seek(index135_1);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA135_3 = input.LA(1);


				int index135_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred212_Java_fragment)) ) {s = 2;}

				else if ( (true) ) {s = 4;}


				input.Seek(index135_3);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 135, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA143 : DFA
	{
		private const string DFA143_eotS =
			"\x0b\uffff";
		private const string DFA143_eofS =
			"\x0b\uffff";
		private const string DFA143_minS =
			"\x01\x4c\x01\x04\x01\uffff\x01\x22\x07\uffff";
		private const string DFA143_maxS =
			"\x01\x54\x01\x61\x01\uffff\x01\x73\x07\uffff";
		private const string DFA143_acceptS =
			"\x02\uffff\x01\x03\x01\uffff\x01\x01\x01\x02\x01\x04\x01\x06\x01\x07"+
			"\x01\x08\x01\x05";
		private const string DFA143_specialS =
			"\x0b\uffff}>";
		private static readonly string[] DFA143_transitionS =
			{
				"\x01\x02\x03\uffff\x01\x01\x03\uffff\x01\x03",
				"\x0a\x05\x0e\uffff\x01\x05\x01\uffff\x01\x05\x02\uffff\x01\x05\x05"+
				"\uffff\x01\x05\x05\uffff\x01\x05\x06\uffff\x01\x05\x01\uffff\x01\x05"+
				"\x01\uffff\x01\x05\x05\uffff\x01\x05\x02\uffff\x01\x05\x02\uffff\x01"+
				"\x05\x04\uffff\x01\x05\x02\uffff\x01\x05\x04\uffff\x01\x04\x05\uffff"+
				"\x02\x05\x05\uffff\x04\x05",
				"",
				"\x01\x06\x15\uffff\x01\x09\x08\uffff\x01\x08\x02\uffff\x01\x07\x2e"+
				"\uffff\x01\x0a",
				"",
				"",
				"",
				"",
				"",
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

		public override string Description { get { return "1135:1: identifierSuffix : ( ( '[' ']' )+ '.' 'class' | ( '[' expression ']' )+ | arguments | '.' 'class' | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' arguments | innerCreator );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA142 : DFA
	{
		private const string DFA142_eotS =
			"\x21\uffff";
		private const string DFA142_eofS =
			"\x01\x01\x20\uffff";
		private const string DFA142_minS =
			"\x01\x33\x01\uffff\x01\x00\x1e\uffff";
		private const string DFA142_maxS =
			"\x01\x73\x01\uffff\x01\x00\x1e\uffff";
		private const string DFA142_acceptS =
			"\x01\uffff\x01\x02\x1e\uffff\x01\x01";
		private const string DFA142_specialS =
			"\x02\uffff\x01\x00\x1e\uffff}>";
		private static readonly string[] DFA142_transitionS =
			{
				"\x01\x01\x19\uffff\x01\x01\x01\uffff\x01\x01\x01\x02\x04\x01\x01\uffff"+
				"\x01\x01\x02\uffff\x17\x01\x01\uffff\x03\x01",
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
				"",
				"",
				"",
				"",
				"",
				"",
				"",
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

		private static readonly short[] DFA142_eot = DFA.UnpackEncodedString(DFA142_eotS);
		private static readonly short[] DFA142_eof = DFA.UnpackEncodedString(DFA142_eofS);
		private static readonly char[] DFA142_min = DFA.UnpackEncodedStringToUnsignedChars(DFA142_minS);
		private static readonly char[] DFA142_max = DFA.UnpackEncodedStringToUnsignedChars(DFA142_maxS);
		private static readonly short[] DFA142_accept = DFA.UnpackEncodedString(DFA142_acceptS);
		private static readonly short[] DFA142_special = DFA.UnpackEncodedString(DFA142_specialS);
		private static readonly short[][] DFA142_transition;

		static DFA142()
		{
			int numStates = DFA142_transitionS.Length;
			DFA142_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA142_transition[i] = DFA.UnpackEncodedString(DFA142_transitionS[i]);
			}
		}

		public DFA142( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 142;
			this.eot = DFA142_eot;
			this.eof = DFA142_eof;
			this.min = DFA142_min;
			this.max = DFA142_max;
			this.accept = DFA142_accept;
			this.special = DFA142_special;
			this.transition = DFA142_transition;
		}

		public override string Description { get { return "()+ loopback of 1139:9: ( '[' expression ']' )+"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition142(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA142_2 = input.LA(1);


				int index142_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred224_Java_fragment)) ) {s = 32;}

				else if ( (true) ) {s = 1;}


				input.Seek(index142_2);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 142, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA148 : DFA
	{
		private const string DFA148_eotS =
			"\x21\uffff";
		private const string DFA148_eofS =
			"\x01\x02\x20\uffff";
		private const string DFA148_minS =
			"\x01\x33\x01\x00\x1f\uffff";
		private const string DFA148_maxS =
			"\x01\x73\x01\x00\x1f\uffff";
		private const string DFA148_acceptS =
			"\x02\uffff\x01\x02\x1d\uffff\x01\x01";
		private const string DFA148_specialS =
			"\x01\uffff\x01\x00\x1f\uffff}>";
		private static readonly string[] DFA148_transitionS =
			{
				"\x01\x02\x19\uffff\x01\x02\x01\uffff\x01\x02\x01\x01\x04\x02\x01\uffff"+
				"\x01\x02\x02\uffff\x17\x02\x01\uffff\x03\x02",
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

		private static readonly short[] DFA148_eot = DFA.UnpackEncodedString(DFA148_eotS);
		private static readonly short[] DFA148_eof = DFA.UnpackEncodedString(DFA148_eofS);
		private static readonly char[] DFA148_min = DFA.UnpackEncodedStringToUnsignedChars(DFA148_minS);
		private static readonly char[] DFA148_max = DFA.UnpackEncodedStringToUnsignedChars(DFA148_maxS);
		private static readonly short[] DFA148_accept = DFA.UnpackEncodedString(DFA148_acceptS);
		private static readonly short[] DFA148_special = DFA.UnpackEncodedString(DFA148_specialS);
		private static readonly short[][] DFA148_transition;

		static DFA148()
		{
			int numStates = DFA148_transitionS.Length;
			DFA148_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA148_transition[i] = DFA.UnpackEncodedString(DFA148_transitionS[i]);
			}
		}

		public DFA148( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 148;
			this.eot = DFA148_eot;
			this.eof = DFA148_eof;
			this.min = DFA148_min;
			this.max = DFA148_max;
			this.accept = DFA148_accept;
			this.special = DFA148_special;
			this.transition = DFA148_transition;
		}

		public override string Description { get { return "()* loopback of 1176:9: ( '[' expression ']' )*"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition148(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA148_1 = input.LA(1);


				int index148_1 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred241_Java_fragment)) ) {s = 32;}

				else if ( (true) ) {s = 2;}


				input.Seek(index148_1);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 148, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA172 : DFA
	{
		private const string DFA172_eotS =
			"\x35\uffff";
		private const string DFA172_eofS =
			"\x35\uffff";
		private const string DFA172_minS =
			"\x01\x04\x01\uffff\x10\x00\x23\uffff";
		private const string DFA172_maxS =
			"\x01\x73\x01\uffff\x10\x00\x23\uffff";
		private const string DFA172_acceptS =
			"\x01\uffff\x01\x01\x10\uffff\x01\x02\x22\uffff";
		private const string DFA172_specialS =
			"\x02\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
			"\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f"+
			"\x23\uffff}>";
		private static readonly string[] DFA172_transitionS =
			{
				"\x01\x05\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01"+
				"\x0d\x01\x0e\x0c\uffff\x02\x12\x01\x10\x01\x12\x01\x10\x02\uffff\x01"+
				"\x10\x01\x12\x01\uffff\x01\x12\x01\uffff\x01\x12\x01\x10\x01\uffff\x01"+
				"\x12\x01\uffff\x01\x12\x01\uffff\x01\x10\x01\x12\x01\uffff\x01\x12\x03"+
				"\uffff\x01\x10\x01\x12\x01\x10\x01\x12\x01\x0f\x01\uffff\x04\x12\x01"+
				"\x10\x02\x12\x01\x04\x02\x12\x01\x02\x01\x12\x01\uffff\x02\x12\x01\x11"+
				"\x02\x12\x01\x03\x01\uffff\x02\x12\x02\uffff\x01\x12\x04\uffff\x02\x12"+
				"\x05\uffff\x04\x12\x0e\uffff\x01\x12\x02\uffff\x01\x01",
				"",
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
				"\x01\uffff",
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
				"",
				"",
				"",
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

		private static readonly short[] DFA172_eot = DFA.UnpackEncodedString(DFA172_eotS);
		private static readonly short[] DFA172_eof = DFA.UnpackEncodedString(DFA172_eofS);
		private static readonly char[] DFA172_min = DFA.UnpackEncodedStringToUnsignedChars(DFA172_minS);
		private static readonly char[] DFA172_max = DFA.UnpackEncodedStringToUnsignedChars(DFA172_maxS);
		private static readonly short[] DFA172_accept = DFA.UnpackEncodedString(DFA172_acceptS);
		private static readonly short[] DFA172_special = DFA.UnpackEncodedString(DFA172_specialS);
		private static readonly short[][] DFA172_transition;

		static DFA172()
		{
			int numStates = DFA172_transitionS.Length;
			DFA172_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA172_transition[i] = DFA.UnpackEncodedString(DFA172_transitionS[i]);
			}
		}

		public DFA172( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 172;
			this.eot = DFA172_eot;
			this.eof = DFA172_eof;
			this.min = DFA172_min;
			this.max = DFA172_max;
			this.accept = DFA172_accept;
			this.special = DFA172_special;
			this.transition = DFA172_transition;
		}

		public override string Description { get { return "522:9: ( explicitConstructorInvocation )?"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition172(DFA dfa, int s, IIntStream _input)
	{
		ITokenStream input = (ITokenStream)_input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA172_2 = input.LA(1);


				int index172_2 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_2);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA172_3 = input.LA(1);


				int index172_3 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_3);
				if ( s>=0 ) return s;
				break;
			case 2:
				int LA172_4 = input.LA(1);


				int index172_4 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_4);
				if ( s>=0 ) return s;
				break;
			case 3:
				int LA172_5 = input.LA(1);


				int index172_5 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_5);
				if ( s>=0 ) return s;
				break;
			case 4:
				int LA172_6 = input.LA(1);


				int index172_6 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_6);
				if ( s>=0 ) return s;
				break;
			case 5:
				int LA172_7 = input.LA(1);


				int index172_7 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_7);
				if ( s>=0 ) return s;
				break;
			case 6:
				int LA172_8 = input.LA(1);


				int index172_8 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_8);
				if ( s>=0 ) return s;
				break;
			case 7:
				int LA172_9 = input.LA(1);


				int index172_9 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_9);
				if ( s>=0 ) return s;
				break;
			case 8:
				int LA172_10 = input.LA(1);


				int index172_10 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_10);
				if ( s>=0 ) return s;
				break;
			case 9:
				int LA172_11 = input.LA(1);


				int index172_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_11);
				if ( s>=0 ) return s;
				break;
			case 10:
				int LA172_12 = input.LA(1);


				int index172_12 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_12);
				if ( s>=0 ) return s;
				break;
			case 11:
				int LA172_13 = input.LA(1);


				int index172_13 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_13);
				if ( s>=0 ) return s;
				break;
			case 12:
				int LA172_14 = input.LA(1);


				int index172_14 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_14);
				if ( s>=0 ) return s;
				break;
			case 13:
				int LA172_15 = input.LA(1);


				int index172_15 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_15);
				if ( s>=0 ) return s;
				break;
			case 14:
				int LA172_16 = input.LA(1);


				int index172_16 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_16);
				if ( s>=0 ) return s;
				break;
			case 15:
				int LA172_17 = input.LA(1);


				int index172_17 = input.Index;
				input.Rewind();
				s = -1;
				if ( (EvaluatePredicate(synpred57_Java_fragment)) ) {s = 1;}

				else if ( (true) ) {s = 18;}


				input.Seek(index172_17);
				if ( s>=0 ) return s;
				break;
		}
		if (state.backtracking > 0) {state.failed=true; return -1;}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 172, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}

	#endregion DFA

	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _annotations_in_compilationUnit100 = new BitSet(new ulong[]{0x0200000000000000UL});
		public static readonly BitSet _packageDeclaration_in_compilationUnit129 = new BitSet(new ulong[]{0x9CA40A0404000002UL,0x0001000000040489UL});
		public static readonly BitSet _importDeclaration_in_compilationUnit151 = new BitSet(new ulong[]{0x9CA40A0404000002UL,0x0001000000040489UL});
		public static readonly BitSet _typeDeclaration_in_compilationUnit173 = new BitSet(new ulong[]{0x9CA00A0404000002UL,0x0001000000040489UL});
		public static readonly BitSet _PACKAGE_in_packageDeclaration204 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _qualifiedName_in_packageDeclaration206 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_packageDeclaration216 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IMPORT_in_importDeclaration237 = new BitSet(new ulong[]{0x8000000000000010UL});
		public static readonly BitSet _STATIC_in_importDeclaration249 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_importDeclaration270 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet _DOT_in_importDeclaration272 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000400000000UL});
		public static readonly BitSet _STAR_in_importDeclaration274 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_importDeclaration284 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IMPORT_in_importDeclaration301 = new BitSet(new ulong[]{0x8000000000000010UL});
		public static readonly BitSet _STATIC_in_importDeclaration313 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_importDeclaration334 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet _DOT_in_importDeclaration345 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_importDeclaration347 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000140000UL});
		public static readonly BitSet _DOT_in_importDeclaration369 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000400000000UL});
		public static readonly BitSet _STAR_in_importDeclaration371 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_importDeclaration392 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IDENTIFIER_in_qualifiedImportName412 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet _DOT_in_qualifiedImportName423 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_qualifiedImportName425 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet _classOrInterfaceDeclaration_in_typeDeclaration456 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SEMI_in_typeDeclaration466 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classDeclaration_in_classOrInterfaceDeclaration487 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceDeclaration_in_classOrInterfaceDeclaration497 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotation_in_modifiers532 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _PUBLIC_in_modifiers542 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _PROTECTED_in_modifiers552 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _PRIVATE_in_modifiers562 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _STATIC_in_modifiers572 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _ABSTRACT_in_modifiers582 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _FINAL_in_modifiers592 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _NATIVE_in_modifiers602 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _SYNCHRONIZED_in_modifiers612 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _TRANSIENT_in_modifiers622 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _VOLATILE_in_modifiers632 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _STRICTFP_in_modifiers642 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet _FINAL_in_variableModifiers674 = new BitSet(new ulong[]{0x0000080000000002UL,0x0001000000000000UL});
		public static readonly BitSet _annotation_in_variableModifiers688 = new BitSet(new ulong[]{0x0000080000000002UL,0x0001000000000000UL});
		public static readonly BitSet _normalClassDeclaration_in_classDeclaration724 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _enumDeclaration_in_classDeclaration734 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_normalClassDeclaration754 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _CLASS_in_normalClassDeclaration757 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_normalClassDeclaration759 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet _typeParameters_in_normalClassDeclaration770 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet _EXTENDS_in_normalClassDeclaration792 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_normalClassDeclaration794 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet _IMPLEMENTS_in_normalClassDeclaration816 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _typeList_in_normalClassDeclaration818 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet _classBody_in_normalClassDeclaration851 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LT_in_typeParameters872 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _typeParameter_in_typeParameters886 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet _COMMA_in_typeParameters901 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _typeParameter_in_typeParameters903 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet _GT_in_typeParameters928 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IDENTIFIER_in_typeParameter948 = new BitSet(new ulong[]{0x0000040000000002UL});
		public static readonly BitSet _EXTENDS_in_typeParameter959 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _typeBound_in_typeParameter961 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _type_in_typeBound993 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet _AMP_in_typeBound1004 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_typeBound1006 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet _modifiers_in_enumDeclaration1038 = new BitSet(new ulong[]{0x0000020000000000UL});
		public static readonly BitSet _ENUM_in_enumDeclaration1050 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_enumDeclaration1071 = new BitSet(new ulong[]{0x0002000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _IMPLEMENTS_in_enumDeclaration1082 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _typeList_in_enumDeclaration1084 = new BitSet(new ulong[]{0x0002000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _enumBody_in_enumDeclaration1105 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACE_in_enumBody1130 = new BitSet(new ulong[]{0x0000000000000010UL,0x00010000000C8000UL});
		public static readonly BitSet _enumConstants_in_enumBody1141 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C8000UL});
		public static readonly BitSet _COMMA_in_enumBody1163 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000048000UL});
		public static readonly BitSet _enumBodyDeclarations_in_enumBody1176 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet _RBRACE_in_enumBody1198 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _enumConstant_in_enumConstants1218 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_enumConstants1229 = new BitSet(new ulong[]{0x0000000000000010UL,0x0001000000000000UL});
		public static readonly BitSet _enumConstant_in_enumConstants1231 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _annotations_in_enumConstant1265 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_enumConstant1286 = new BitSet(new ulong[]{0x0002040000000002UL,0x0008000000005000UL});
		public static readonly BitSet _arguments_in_enumConstant1297 = new BitSet(new ulong[]{0x0002040000000002UL,0x0008000000004000UL});
		public static readonly BitSet _classBody_in_enumConstant1319 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SEMI_in_enumBodyDeclarations1360 = new BitSet(new ulong[]{0xDCF02A8654000012UL,0x0009000000044689UL});
		public static readonly BitSet _classBodyDeclaration_in_enumBodyDeclarations1372 = new BitSet(new ulong[]{0xDCF02A8654000012UL,0x0009000000044689UL});
		public static readonly BitSet _normalInterfaceDeclaration_in_interfaceDeclaration1403 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotationTypeDeclaration_in_interfaceDeclaration1413 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_normalInterfaceDeclaration1437 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet _INTERFACE_in_normalInterfaceDeclaration1439 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_normalInterfaceDeclaration1441 = new BitSet(new ulong[]{0x0000040000000000UL,0x0008000000004000UL});
		public static readonly BitSet _typeParameters_in_normalInterfaceDeclaration1452 = new BitSet(new ulong[]{0x0000040000000000UL,0x0008000000004000UL});
		public static readonly BitSet _EXTENDS_in_normalInterfaceDeclaration1474 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _typeList_in_normalInterfaceDeclaration1476 = new BitSet(new ulong[]{0x0000040000000000UL,0x0008000000004000UL});
		public static readonly BitSet _interfaceBody_in_normalInterfaceDeclaration1497 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _type_in_typeList1517 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_typeList1528 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_typeList1530 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _LBRACE_in_classBody1561 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x000900000004C689UL});
		public static readonly BitSet _classBodyDeclaration_in_classBody1573 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x000900000004C689UL});
		public static readonly BitSet _RBRACE_in_classBody1595 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACE_in_interfaceBody1615 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0009000000048689UL});
		public static readonly BitSet _interfaceBodyDeclaration_in_interfaceBody1627 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0009000000048689UL});
		public static readonly BitSet _RBRACE_in_interfaceBody1649 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SEMI_in_classBodyDeclaration1669 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _STATIC_in_classBodyDeclaration1680 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _block_in_classBodyDeclaration1702 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _memberDecl_in_classBodyDeclaration1712 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _fieldDeclaration_in_memberDecl1733 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _methodDeclaration_in_memberDecl1744 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classDeclaration_in_memberDecl1755 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceDeclaration_in_memberDecl1766 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_methodDeclaration1804 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet _typeParameters_in_methodDeclaration1815 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_methodDeclaration1836 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _formalParameters_in_methodDeclaration1846 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004040UL});
		public static readonly BitSet _THROWS_in_methodDeclaration1857 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _qualifiedNameList_in_methodDeclaration1859 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _LBRACE_in_methodDeclaration1880 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _explicitConstructorInvocation_in_methodDeclaration1892 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _blockStatement_in_methodDeclaration1914 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _RBRACE_in_methodDeclaration1935 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_methodDeclaration1945 = new BitSet(new ulong[]{0x4050208250000010UL,0x0008000000000200UL});
		public static readonly BitSet _typeParameters_in_methodDeclaration1956 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000000000200UL});
		public static readonly BitSet _type_in_methodDeclaration1978 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _VOID_in_methodDeclaration1992 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_methodDeclaration2012 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _formalParameters_in_methodDeclaration2022 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000054040UL});
		public static readonly BitSet _LBRACKET_in_methodDeclaration2033 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_methodDeclaration2035 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000054040UL});
		public static readonly BitSet _THROWS_in_methodDeclaration2057 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _qualifiedNameList_in_methodDeclaration2059 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000044000UL});
		public static readonly BitSet _block_in_methodDeclaration2114 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SEMI_in_methodDeclaration2128 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_fieldDeclaration2160 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_fieldDeclaration2170 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _variableDeclarator_in_fieldDeclaration2180 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet _COMMA_in_fieldDeclaration2191 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _variableDeclarator_in_fieldDeclaration2193 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet _SEMI_in_fieldDeclaration2214 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IDENTIFIER_in_variableDeclarator2234 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000410000UL});
		public static readonly BitSet _LBRACKET_in_variableDeclarator2245 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_variableDeclarator2247 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000410000UL});
		public static readonly BitSet _EQ_in_variableDeclarator2269 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1805212UL});
		public static readonly BitSet _variableInitializer_in_variableDeclarator2271 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceFieldDeclaration_in_interfaceBodyDeclaration2310 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceMethodDeclaration_in_interfaceBodyDeclaration2320 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceDeclaration_in_interfaceBodyDeclaration2330 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classDeclaration_in_interfaceBodyDeclaration2340 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SEMI_in_interfaceBodyDeclaration2350 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_interfaceMethodDeclaration2370 = new BitSet(new ulong[]{0x4050208250000010UL,0x0008000000000200UL});
		public static readonly BitSet _typeParameters_in_interfaceMethodDeclaration2381 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000000000200UL});
		public static readonly BitSet _type_in_interfaceMethodDeclaration2403 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _VOID_in_interfaceMethodDeclaration2414 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_interfaceMethodDeclaration2434 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _formalParameters_in_interfaceMethodDeclaration2444 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000050040UL});
		public static readonly BitSet _LBRACKET_in_interfaceMethodDeclaration2455 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_interfaceMethodDeclaration2457 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000050040UL});
		public static readonly BitSet _THROWS_in_interfaceMethodDeclaration2479 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _qualifiedNameList_in_interfaceMethodDeclaration2481 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_interfaceMethodDeclaration2494 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_interfaceFieldDeclaration2516 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_interfaceFieldDeclaration2518 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _variableDeclarator_in_interfaceFieldDeclaration2520 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet _COMMA_in_interfaceFieldDeclaration2531 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _variableDeclarator_in_interfaceFieldDeclaration2533 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet _SEMI_in_interfaceFieldDeclaration2554 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classOrInterfaceType_in_type2575 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_type2586 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_type2588 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _primitiveType_in_type2609 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_type2620 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_type2622 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _IDENTIFIER_in_classOrInterfaceType2654 = new BitSet(new ulong[]{0x0000000000000002UL,0x0008000000100000UL});
		public static readonly BitSet _typeArguments_in_classOrInterfaceType2665 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet _DOT_in_classOrInterfaceType2687 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_classOrInterfaceType2689 = new BitSet(new ulong[]{0x0000000000000002UL,0x0008000000100000UL});
		public static readonly BitSet _typeArguments_in_classOrInterfaceType2704 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet _set_in_primitiveType0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LT_in_typeArguments2841 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000002000000UL});
		public static readonly BitSet _typeArgument_in_typeArguments2843 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet _COMMA_in_typeArguments2854 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000002000000UL});
		public static readonly BitSet _typeArgument_in_typeArguments2856 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet _GT_in_typeArguments2878 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _type_in_typeArgument2898 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _QUES_in_typeArgument2908 = new BitSet(new ulong[]{0x0000040000000002UL,0x0000000000000002UL});
		public static readonly BitSet _set_in_typeArgument2932 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_typeArgument2976 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _qualifiedName_in_qualifiedNameList3007 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_qualifiedNameList3018 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _qualifiedName_in_qualifiedNameList3020 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _LPAREN_in_formalParameters3051 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000002000UL});
		public static readonly BitSet _formalParameterDecls_in_formalParameters3062 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_formalParameters3084 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _ellipsisParameterDecl_in_formalParameterDecls3104 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalParameterDecl_in_formalParameterDecls3114 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_formalParameterDecls3125 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet _normalParameterDecl_in_formalParameterDecls3127 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _normalParameterDecl_in_formalParameterDecls3149 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_formalParameterDecls3159 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet _ellipsisParameterDecl_in_formalParameterDecls3181 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _variableModifiers_in_normalParameterDecl3201 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_normalParameterDecl3203 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_normalParameterDecl3205 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_normalParameterDecl3216 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_normalParameterDecl3218 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _variableModifiers_in_ellipsisParameterDecl3249 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_ellipsisParameterDecl3259 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000200000UL});
		public static readonly BitSet _ELLIPSIS_in_ellipsisParameterDecl3262 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_ellipsisParameterDecl3272 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_explicitConstructorInvocation3294 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000012UL});
		public static readonly BitSet _set_in_explicitConstructorInvocation3320 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_explicitConstructorInvocation3352 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_explicitConstructorInvocation3354 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _primary_in_explicitConstructorInvocation3365 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet _DOT_in_explicitConstructorInvocation3375 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000002UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_explicitConstructorInvocation3386 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000002UL});
		public static readonly BitSet _SUPER_in_explicitConstructorInvocation3407 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_explicitConstructorInvocation3417 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_explicitConstructorInvocation3419 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IDENTIFIER_in_qualifiedName3439 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet _DOT_in_qualifiedName3450 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_qualifiedName3452 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet _annotation_in_annotations3484 = new BitSet(new ulong[]{0x0000000000000002UL,0x0001000000000000UL});
		public static readonly BitSet _MONKEYS_AT_in_annotation3517 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _qualifiedName_in_annotation3519 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
		public static readonly BitSet _LPAREN_in_annotation3533 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1807212UL});
		public static readonly BitSet _elementValuePairs_in_annotation3560 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _elementValue_in_annotation3584 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_annotation3620 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _elementValuePair_in_elementValuePairs3652 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_elementValuePairs3663 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _elementValuePair_in_elementValuePairs3665 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _IDENTIFIER_in_elementValuePair3696 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet _EQ_in_elementValuePair3698 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1805212UL});
		public static readonly BitSet _elementValue_in_elementValuePair3700 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _conditionalExpression_in_elementValue3720 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotation_in_elementValue3730 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _elementValueArrayInitializer_in_elementValue3740 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACE_in_elementValueArrayInitializer3760 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C188D212UL});
		public static readonly BitSet _elementValue_in_elementValueArrayInitializer3771 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet _COMMA_in_elementValueArrayInitializer3786 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1805212UL});
		public static readonly BitSet _elementValue_in_elementValueArrayInitializer3788 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet _COMMA_in_elementValueArrayInitializer3817 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet _RBRACE_in_elementValueArrayInitializer3821 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_annotationTypeDeclaration3844 = new BitSet(new ulong[]{0x0000000000000000UL,0x0001000000000000UL});
		public static readonly BitSet _MONKEYS_AT_in_annotationTypeDeclaration3846 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet _INTERFACE_in_annotationTypeDeclaration3856 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_annotationTypeDeclaration3866 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _annotationTypeBody_in_annotationTypeDeclaration3876 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACE_in_annotationTypeBody3897 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0001000000048489UL});
		public static readonly BitSet _annotationTypeElementDeclaration_in_annotationTypeBody3909 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0001000000048489UL});
		public static readonly BitSet _RBRACE_in_annotationTypeBody3931 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotationMethodDeclaration_in_annotationTypeElementDeclaration3953 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceFieldDeclaration_in_annotationTypeElementDeclaration3963 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalClassDeclaration_in_annotationTypeElementDeclaration3973 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalInterfaceDeclaration_in_annotationTypeElementDeclaration3983 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _enumDeclaration_in_annotationTypeElementDeclaration3993 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotationTypeDeclaration_in_annotationTypeElementDeclaration4003 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SEMI_in_annotationTypeElementDeclaration4013 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_annotationMethodDeclaration4033 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_annotationMethodDeclaration4035 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_annotationMethodDeclaration4037 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _LPAREN_in_annotationMethodDeclaration4047 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_annotationMethodDeclaration4049 = new BitSet(new ulong[]{0x0000002000000000UL,0x0000000000040000UL});
		public static readonly BitSet _DEFAULT_in_annotationMethodDeclaration4052 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1805212UL});
		public static readonly BitSet _elementValue_in_annotationMethodDeclaration4054 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_annotationMethodDeclaration4083 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACE_in_block4107 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _blockStatement_in_block4118 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _RBRACE_in_block4139 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _localVariableDeclarationStatement_in_blockStatement4161 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classOrInterfaceDeclaration_in_blockStatement4171 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _statement_in_blockStatement4181 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _localVariableDeclaration_in_localVariableDeclarationStatement4202 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_localVariableDeclarationStatement4212 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _variableModifiers_in_localVariableDeclaration4232 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_localVariableDeclaration4234 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _variableDeclarator_in_localVariableDeclaration4244 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_localVariableDeclaration4255 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _variableDeclarator_in_localVariableDeclaration4257 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _block_in_statement4288 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _ASSERT_in_statement4312 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_statement4332 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet _COLON_in_statement4335 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_statement4337 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4341 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _ASSERT_in_statement4351 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_statement4354 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet _COLON_in_statement4357 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_statement4359 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4363 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IF_in_statement4385 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _parExpression_in_statement4387 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_statement4389 = new BitSet(new ulong[]{0x0000010000000002UL});
		public static readonly BitSet _ELSE_in_statement4392 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_statement4394 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _forstatement_in_statement4416 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _WHILE_in_statement4426 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _parExpression_in_statement4428 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_statement4430 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DO_in_statement4440 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_statement4442 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
		public static readonly BitSet _WHILE_in_statement4444 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _parExpression_in_statement4446 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4448 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _trystatement_in_statement4458 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SWITCH_in_statement4468 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _parExpression_in_statement4470 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _LBRACE_in_statement4472 = new BitSet(new ulong[]{0x0000002080000000UL,0x0000000000008000UL});
		public static readonly BitSet _switchBlockStatementGroups_in_statement4474 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet _RBRACE_in_statement4476 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SYNCHRONIZED_in_statement4486 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _parExpression_in_statement4488 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _block_in_statement4490 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _RETURN_in_statement4500 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1841212UL});
		public static readonly BitSet _expression_in_statement4503 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4508 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _THROW_in_statement4518 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_statement4520 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4522 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _BREAK_in_statement4532 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000040000UL});
		public static readonly BitSet _IDENTIFIER_in_statement4547 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4564 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _CONTINUE_in_statement4574 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000040000UL});
		public static readonly BitSet _IDENTIFIER_in_statement4589 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4606 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _expression_in_statement4616 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_statement4619 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IDENTIFIER_in_statement4634 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet _COLON_in_statement4636 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_statement4638 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SEMI_in_statement4648 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _switchBlockStatementGroup_in_switchBlockStatementGroups4670 = new BitSet(new ulong[]{0x0000002080000002UL});
		public static readonly BitSet _switchLabel_in_switchBlockStatementGroup4699 = new BitSet(new ulong[]{0xFDF16AD67C003FF2UL,0x00090003C1845FBFUL});
		public static readonly BitSet _blockStatement_in_switchBlockStatementGroup4710 = new BitSet(new ulong[]{0xFDF16AD67C003FF2UL,0x00090003C1845FBFUL});
		public static readonly BitSet _CASE_in_switchLabel4741 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_switchLabel4743 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet _COLON_in_switchLabel4745 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DEFAULT_in_switchLabel4755 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet _COLON_in_switchLabel4757 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _TRY_in_trystatement4778 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _block_in_trystatement4780 = new BitSet(new ulong[]{0x0000100100000000UL});
		public static readonly BitSet _catches_in_trystatement4794 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet _FINALLY_in_trystatement4796 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _block_in_trystatement4798 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _catches_in_trystatement4812 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _FINALLY_in_trystatement4826 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _block_in_trystatement4828 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _catchClause_in_catches4859 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet _catchClause_in_catches4870 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet _CATCH_in_catchClause4901 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _LPAREN_in_catchClause4903 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet _formalParameter_in_catchClause4905 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_catchClause4915 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _block_in_catchClause4917 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _variableModifiers_in_formalParameter4938 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_formalParameter4940 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_formalParameter4942 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_formalParameter4953 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_formalParameter4955 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _FOR_in_forstatement5004 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _LPAREN_in_forstatement5006 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet _variableModifiers_in_forstatement5008 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_forstatement5010 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_forstatement5012 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet _COLON_in_forstatement5014 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_forstatement5025 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_forstatement5027 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_forstatement5029 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _FOR_in_forstatement5061 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _LPAREN_in_forstatement5063 = new BitSet(new ulong[]{0x4150288250003FF0UL,0x00090003C1841212UL});
		public static readonly BitSet _forInit_in_forstatement5083 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_forstatement5104 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1841212UL});
		public static readonly BitSet _expression_in_forstatement5124 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_forstatement5145 = new BitSet(new ulong[]{0x4150288250003FF0UL,0x00090003C1803212UL});
		public static readonly BitSet _expressionList_in_forstatement5165 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_forstatement5186 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_forstatement5188 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _localVariableDeclaration_in_forInit5208 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _expressionList_in_forInit5218 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LPAREN_in_parExpression5238 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_parExpression5240 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_parExpression5242 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _expression_in_expressionList5262 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_expressionList5273 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_expressionList5275 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _conditionalExpression_in_expression5307 = new BitSet(new ulong[]{0x0000000000000002UL,0x000CFF0000400000UL});
		public static readonly BitSet _assignmentOperator_in_expression5318 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_expression5320 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _EQ_in_assignmentOperator5352 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _PLUSEQ_in_assignmentOperator5362 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SUBEQ_in_assignmentOperator5372 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _STAREQ_in_assignmentOperator5382 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SLASHEQ_in_assignmentOperator5392 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _AMPEQ_in_assignmentOperator5402 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _BAREQ_in_assignmentOperator5412 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _CARETEQ_in_assignmentOperator5422 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _PERCENTEQ_in_assignmentOperator5432 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LT_in_assignmentOperator5443 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet _LT_in_assignmentOperator5445 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet _EQ_in_assignmentOperator5447 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _GT_in_assignmentOperator5458 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet _GT_in_assignmentOperator5460 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet _GT_in_assignmentOperator5462 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet _EQ_in_assignmentOperator5464 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _GT_in_assignmentOperator5475 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet _GT_in_assignmentOperator5477 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet _EQ_in_assignmentOperator5479 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _conditionalOrExpression_in_conditionalExpression5500 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000002000000UL});
		public static readonly BitSet _QUES_in_conditionalExpression5511 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_conditionalExpression5513 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet _COLON_in_conditionalExpression5515 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _conditionalExpression_in_conditionalExpression5517 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _conditionalAndExpression_in_conditionalOrExpression5548 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000020000000UL});
		public static readonly BitSet _BARBAR_in_conditionalOrExpression5559 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _conditionalAndExpression_in_conditionalOrExpression5561 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000020000000UL});
		public static readonly BitSet _inclusiveOrExpression_in_conditionalAndExpression5592 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000010000000UL});
		public static readonly BitSet _AMPAMP_in_conditionalAndExpression5603 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _inclusiveOrExpression_in_conditionalAndExpression5605 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000010000000UL});
		public static readonly BitSet _exclusiveOrExpression_in_inclusiveOrExpression5636 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000002000000000UL});
		public static readonly BitSet _BAR_in_inclusiveOrExpression5647 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _exclusiveOrExpression_in_inclusiveOrExpression5649 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000002000000000UL});
		public static readonly BitSet _andExpression_in_exclusiveOrExpression5680 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000004000000000UL});
		public static readonly BitSet _CARET_in_exclusiveOrExpression5691 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _andExpression_in_exclusiveOrExpression5693 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000004000000000UL});
		public static readonly BitSet _equalityExpression_in_andExpression5724 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet _AMP_in_andExpression5735 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _equalityExpression_in_andExpression5737 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet _instanceOfExpression_in_equalityExpression5768 = new BitSet(new ulong[]{0x0000000000000002UL,0x0002000008000000UL});
		public static readonly BitSet _set_in_equalityExpression5795 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _instanceOfExpression_in_equalityExpression5845 = new BitSet(new ulong[]{0x0000000000000002UL,0x0002000008000000UL});
		public static readonly BitSet _relationalExpression_in_instanceOfExpression5876 = new BitSet(new ulong[]{0x0008000000000002UL});
		public static readonly BitSet _INSTANCEOF_in_instanceOfExpression5887 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_instanceOfExpression5889 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _shiftExpression_in_relationalExpression5920 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet _relationalOp_in_relationalExpression5931 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _shiftExpression_in_relationalExpression5933 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet _LT_in_relationalOp5965 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet _EQ_in_relationalOp5967 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _GT_in_relationalOp5978 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet _EQ_in_relationalOp5980 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LT_in_relationalOp5990 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _GT_in_relationalOp6000 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _additiveExpression_in_shiftExpression6020 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet _shiftOp_in_shiftExpression6031 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _additiveExpression_in_shiftExpression6033 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet _LT_in_shiftOp6066 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet _LT_in_shiftOp6068 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _GT_in_shiftOp6079 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet _GT_in_shiftOp6081 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet _GT_in_shiftOp6083 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _GT_in_shiftOp6094 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet _GT_in_shiftOp6096 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _multiplicativeExpression_in_additiveExpression6117 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000300000000UL});
		public static readonly BitSet _set_in_additiveExpression6144 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _multiplicativeExpression_in_additiveExpression6194 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000300000000UL});
		public static readonly BitSet _unaryExpression_in_multiplicativeExpression6232 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000008C00000000UL});
		public static readonly BitSet _set_in_multiplicativeExpression6259 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_multiplicativeExpression6327 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000008C00000000UL});
		public static readonly BitSet _PLUS_in_unaryExpression6360 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_unaryExpression6363 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SUB_in_unaryExpression6373 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_unaryExpression6375 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _PLUSPLUS_in_unaryExpression6385 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_unaryExpression6387 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SUBSUB_in_unaryExpression6397 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_unaryExpression6399 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _unaryExpressionNotPlusMinus_in_unaryExpression6409 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _TILDE_in_unaryExpressionNotPlusMinus6429 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_unaryExpressionNotPlusMinus6431 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _BANG_in_unaryExpressionNotPlusMinus6441 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_unaryExpressionNotPlusMinus6443 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _castExpression_in_unaryExpressionNotPlusMinus6453 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _primary_in_unaryExpressionNotPlusMinus6463 = new BitSet(new ulong[]{0x0000000000000002UL,0x00000000C0110000UL});
		public static readonly BitSet _selector_in_unaryExpressionNotPlusMinus6474 = new BitSet(new ulong[]{0x0000000000000002UL,0x00000000C0110000UL});
		public static readonly BitSet _set_in_unaryExpressionNotPlusMinus6495 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LPAREN_in_castExpression6544 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _primitiveType_in_castExpression6546 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_castExpression6548 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_castExpression6550 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LPAREN_in_castExpression6560 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_castExpression6562 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_castExpression6564 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpressionNotPlusMinus_in_castExpression6566 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _parExpression_in_primary6588 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _THIS_in_primary6610 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet _DOT_in_primary6621 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_primary6623 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet _identifierSuffix_in_primary6645 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IDENTIFIER_in_primary6666 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet _DOT_in_primary6677 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_primary6679 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet _identifierSuffix_in_primary6701 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _SUPER_in_primary6722 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000101000UL});
		public static readonly BitSet _superSuffix_in_primary6732 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _literal_in_primary6742 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _creator_in_primary6752 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _primitiveType_in_primary6762 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000110000UL});
		public static readonly BitSet _LBRACKET_in_primary6773 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_primary6775 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000110000UL});
		public static readonly BitSet _DOT_in_primary6796 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _CLASS_in_primary6798 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _VOID_in_primary6808 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet _DOT_in_primary6810 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _CLASS_in_primary6812 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _arguments_in_superSuffix6838 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_superSuffix6848 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet _typeArguments_in_superSuffix6851 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_superSuffix6872 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_superSuffix6883 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACKET_in_identifierSuffix6916 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_identifierSuffix6918 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000110000UL});
		public static readonly BitSet _DOT_in_identifierSuffix6939 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _CLASS_in_identifierSuffix6941 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACKET_in_identifierSuffix6952 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_identifierSuffix6954 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_identifierSuffix6956 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _arguments_in_identifierSuffix6977 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_identifierSuffix6987 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _CLASS_in_identifierSuffix6989 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_identifierSuffix6999 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_identifierSuffix7001 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_identifierSuffix7003 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_identifierSuffix7005 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_identifierSuffix7015 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
		public static readonly BitSet _THIS_in_identifierSuffix7017 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_identifierSuffix7027 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000002UL});
		public static readonly BitSet _SUPER_in_identifierSuffix7029 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_identifierSuffix7031 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _innerCreator_in_identifierSuffix7041 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_selector7063 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_selector7065 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_selector7067 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_selector7078 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_selector7080 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_selector7082 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_selector7084 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_selector7095 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
		public static readonly BitSet _THIS_in_selector7097 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_selector7107 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000002UL});
		public static readonly BitSet _SUPER_in_selector7109 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000101000UL});
		public static readonly BitSet _superSuffix_in_selector7119 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _innerCreator_in_selector7129 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACKET_in_selector7139 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_selector7141 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_selector7143 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NEW_in_creator7163 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_creator7165 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _classOrInterfaceType_in_creator7167 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _classCreatorRest_in_creator7169 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NEW_in_creator7179 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _classOrInterfaceType_in_creator7181 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _classCreatorRest_in_creator7183 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _arrayCreator_in_creator7193 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NEW_in_arrayCreator7213 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _createdName_in_arrayCreator7215 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_arrayCreator7225 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_arrayCreator7227 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet _LBRACKET_in_arrayCreator7238 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_arrayCreator7240 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet _arrayInitializer_in_arrayCreator7261 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NEW_in_arrayCreator7272 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _createdName_in_arrayCreator7274 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_arrayCreator7284 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_arrayCreator7286 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_arrayCreator7296 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_arrayCreator7310 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_arrayCreator7312 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_arrayCreator7326 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_arrayCreator7348 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_arrayCreator7350 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet _arrayInitializer_in_variableInitializer7381 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _expression_in_variableInitializer7391 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACE_in_arrayInitializer7411 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C188D212UL});
		public static readonly BitSet _variableInitializer_in_arrayInitializer7427 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet _COMMA_in_arrayInitializer7446 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1805212UL});
		public static readonly BitSet _variableInitializer_in_arrayInitializer7448 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet _COMMA_in_arrayInitializer7498 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet _RBRACE_in_arrayInitializer7511 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classOrInterfaceType_in_createdName7545 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _primitiveType_in_createdName7555 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_innerCreator7576 = new BitSet(new ulong[]{0x0100000000000000UL});
		public static readonly BitSet _NEW_in_innerCreator7578 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_innerCreator7589 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_innerCreator7610 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000001000UL});
		public static readonly BitSet _typeArguments_in_innerCreator7621 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _classCreatorRest_in_innerCreator7642 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _arguments_in_classCreatorRest7663 = new BitSet(new ulong[]{0x0002040000000002UL,0x0008000000004000UL});
		public static readonly BitSet _classBody_in_classCreatorRest7674 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LT_in_nonWildcardTypeArguments7706 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _typeList_in_nonWildcardTypeArguments7708 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet _GT_in_nonWildcardTypeArguments7718 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LPAREN_in_arguments7738 = new BitSet(new ulong[]{0x4150288250003FF0UL,0x00090003C1803212UL});
		public static readonly BitSet _expressionList_in_arguments7741 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_arguments7754 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _INTLITERAL_in_intLiteral7768 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LONGLITERAL_in_longLiteral7779 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _FLOATLITERAL_in_floatLiteral7790 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOUBLELITERAL_in_doubleLiteral7801 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _CHARLITERAL_in_charLiteral7812 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _STRINGLITERAL_in_stringLiteral7823 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _TRUE_in_trueLiteral7834 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _FALSE_in_falseLiteral7845 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NULL_in_nullLiteral7856 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _intLiteral_in_literal7873 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _longLiteral_in_literal7883 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _floatLiteral_in_literal7893 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _doubleLiteral_in_literal7903 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _charLiteral_in_literal7913 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _stringLiteral_in_literal7923 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _trueLiteral_in_literal7933 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _falseLiteral_in_literal7943 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _nullLiteral_in_literal7953 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_classHeader7977 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet _CLASS_in_classHeader7979 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_classHeader7981 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_enumHeader8001 = new BitSet(new ulong[]{0x0000020000000010UL});
		public static readonly BitSet _set_in_enumHeader8003 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_enumHeader8009 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_interfaceHeader8029 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet _INTERFACE_in_interfaceHeader8031 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_interfaceHeader8033 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_annotationHeader8053 = new BitSet(new ulong[]{0x0000000000000000UL,0x0001000000000000UL});
		public static readonly BitSet _MONKEYS_AT_in_annotationHeader8055 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet _INTERFACE_in_annotationHeader8057 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_annotationHeader8059 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_typeHeader8079 = new BitSet(new ulong[]{0x0020020400000000UL,0x0001000000000000UL});
		public static readonly BitSet _CLASS_in_typeHeader8082 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _ENUM_in_typeHeader8084 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _MONKEYS_AT_in_typeHeader8087 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet _INTERFACE_in_typeHeader8091 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_typeHeader8095 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_methodHeader8115 = new BitSet(new ulong[]{0x4050208250000010UL,0x0008000000000200UL});
		public static readonly BitSet _typeParameters_in_methodHeader8117 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000000000200UL});
		public static readonly BitSet _type_in_methodHeader8121 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _VOID_in_methodHeader8123 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_methodHeader8127 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _LPAREN_in_methodHeader8129 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_fieldHeader8149 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_fieldHeader8151 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_fieldHeader8153 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet _LBRACKET_in_fieldHeader8156 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_fieldHeader8157 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet _set_in_fieldHeader8161 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _variableModifiers_in_localVariableHeader8187 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_localVariableHeader8189 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_localVariableHeader8191 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet _LBRACKET_in_localVariableHeader8194 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_localVariableHeader8195 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet _set_in_localVariableHeader8199 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotations_in_synpred2_Java100 = new BitSet(new ulong[]{0x0200000000000000UL});
		public static readonly BitSet _packageDeclaration_in_synpred2_Java129 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classDeclaration_in_synpred12_Java487 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalClassDeclaration_in_synpred27_Java724 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalInterfaceDeclaration_in_synpred43_Java1403 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _fieldDeclaration_in_synpred52_Java1733 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _methodDeclaration_in_synpred53_Java1744 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classDeclaration_in_synpred54_Java1755 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _explicitConstructorInvocation_in_synpred57_Java1892 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _modifiers_in_synpred59_Java1804 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet _typeParameters_in_synpred59_Java1815 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_synpred59_Java1836 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _formalParameters_in_synpred59_Java1846 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004040UL});
		public static readonly BitSet _THROWS_in_synpred59_Java1857 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _qualifiedNameList_in_synpred59_Java1859 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _LBRACE_in_synpred59_Java1880 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _explicitConstructorInvocation_in_synpred59_Java1892 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _blockStatement_in_synpred59_Java1914 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet _RBRACE_in_synpred59_Java1935 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceFieldDeclaration_in_synpred68_Java2310 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceMethodDeclaration_in_synpred69_Java2320 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceDeclaration_in_synpred70_Java2330 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classDeclaration_in_synpred71_Java2340 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _ellipsisParameterDecl_in_synpred96_Java3104 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalParameterDecl_in_synpred98_Java3114 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_synpred98_Java3125 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet _normalParameterDecl_in_synpred98_Java3127 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet _normalParameterDecl_in_synpred99_Java3149 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000080000UL});
		public static readonly BitSet _COMMA_in_synpred99_Java3159 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_synpred103_Java3294 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000012UL});
		public static readonly BitSet _set_in_synpred103_Java3320 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _arguments_in_synpred103_Java3352 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_synpred103_Java3354 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotationMethodDeclaration_in_synpred117_Java3953 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _interfaceFieldDeclaration_in_synpred118_Java3963 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalClassDeclaration_in_synpred119_Java3973 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _normalInterfaceDeclaration_in_synpred120_Java3983 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _enumDeclaration_in_synpred121_Java3993 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _annotationTypeDeclaration_in_synpred122_Java4003 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _localVariableDeclarationStatement_in_synpred125_Java4161 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _classOrInterfaceDeclaration_in_synpred126_Java4171 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _ASSERT_in_synpred130_Java4312 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_synpred130_Java4332 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet _COLON_in_synpred130_Java4335 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_synpred130_Java4337 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_synpred130_Java4341 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _ASSERT_in_synpred132_Java4351 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_synpred132_Java4354 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet _COLON_in_synpred132_Java4357 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_synpred132_Java4359 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_synpred132_Java4363 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _ELSE_in_synpred133_Java4392 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_synpred133_Java4394 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _expression_in_synpred148_Java4616 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet _SEMI_in_synpred148_Java4619 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _IDENTIFIER_in_synpred149_Java4634 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet _COLON_in_synpred149_Java4636 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_synpred149_Java4638 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _catches_in_synpred153_Java4794 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet _FINALLY_in_synpred153_Java4796 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet _block_in_synpred153_Java4798 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _catches_in_synpred154_Java4812 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _FOR_in_synpred157_Java5004 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _LPAREN_in_synpred157_Java5006 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet _variableModifiers_in_synpred157_Java5008 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _type_in_synpred157_Java5010 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_synpred157_Java5012 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet _COLON_in_synpred157_Java5014 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_synpred157_Java5025 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_synpred157_Java5027 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet _statement_in_synpred157_Java5029 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _localVariableDeclaration_in_synpred161_Java5208 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _castExpression_in_synpred202_Java6453 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LPAREN_in_synpred206_Java6544 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _primitiveType_in_synpred206_Java6546 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet _RPAREN_in_synpred206_Java6548 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _unaryExpression_in_synpred206_Java6550 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_synpred208_Java6621 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_synpred208_Java6623 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _identifierSuffix_in_synpred209_Java6645 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _DOT_in_synpred211_Java6677 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _IDENTIFIER_in_synpred211_Java6679 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _identifierSuffix_in_synpred212_Java6701 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACKET_in_synpred224_Java6952 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_synpred224_Java6954 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_synpred224_Java6956 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NEW_in_synpred237_Java7163 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet _nonWildcardTypeArguments_in_synpred237_Java7165 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _classOrInterfaceType_in_synpred237_Java7167 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _classCreatorRest_in_synpred237_Java7169 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NEW_in_synpred238_Java7179 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet _classOrInterfaceType_in_synpred238_Java7181 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet _classCreatorRest_in_synpred238_Java7183 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _NEW_in_synpred240_Java7213 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet _createdName_in_synpred240_Java7215 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000010000UL});
		public static readonly BitSet _LBRACKET_in_synpred240_Java7225 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_synpred240_Java7227 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet _LBRACKET_in_synpred240_Java7238 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_synpred240_Java7240 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet _arrayInitializer_in_synpred240_Java7261 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet _LBRACKET_in_synpred241_Java7310 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet _expression_in_synpred241_Java7312 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet _RBRACKET_in_synpred241_Java7326 = new BitSet(new ulong[]{0x0000000000000002UL});

	}
	#endregion Follow sets
}
