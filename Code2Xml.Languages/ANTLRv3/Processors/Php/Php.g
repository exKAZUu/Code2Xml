// This grammar is derived from https://code.google.com/p/phpparser/
//Todo: Labels and goto have been disabled, need to test on 5.3 

grammar Php;

options {
	backtrack = true; 
	memoize   = true;
	output	= AST;
	language  = CSharp3;
}

tokens{
	SemiColon = ';';
	Comma = ',';
	OpenRoundBracket = '(';
	CloseRoundBracket = ')';
	OpenSquareBracket = '[';
	CloseSquareBracket = ']';
	OpenCurlyBracket = '{';
	CloseCurlyBracket = '}';
	ArrayAssign = '=>';
	LogicalOr = '||';
	LogicalAnd = '&&';
	ClassMember = '::';
	InstanceMember = '->';
	SuppressWarnings = '@';
	QuestionMark = '?';
	Colon = ':';
	Dot = '.';
	Ampersand = '&';
	Pipe = '|';
	Hat = '^';
	Bang = '!';
	Plus = '+';
	Minus = '-';
	Asterisk = '*';
	Percent = '%';
	Forwardslash = '/'; 
	Tilde = '~';
	Equals = '=';
}

@lexer::namespace { Code2Xml.Languages.ANTLRv3.Processors.Php }
@parser::namespace { Code2Xml.Languages.ANTLRv3.Processors.Php }

@lexer::header {
	using System;
	using System.Text;
}

@members{
	private bool expressionFollowsBodyString = false;
}

@lexer::members{
	public bool AllowShortOpenTag { get; set; }

	// Handle the first token, which will always be a BodyString.
	public override IToken NextToken(){
		//The following code was pulled out from base.NextToken()
		if (input.index() == 0) {
			try {
				state.token = null;
				state.channel = DefaultTokenChannel;
				state.tokenStartCharIndex = input.index();
				state.tokenStartCharPositionInLine = input.getCharPositionInLine();
				state.tokenStartLine = input.getLine();
				state.text = null;
				state.backtracking = 0;
				mBodyStringRest();
				state.type = BodyString;
				Emit();
				return state.token;
			} catch (NoViableAltException nva) {
				ReportError(nva);
				Recover(nva); // throw out current char and try again
			} catch (RecognitionException re) {
				ReportError(re);
				// match() routine has already called recover()
			}
		}
		return base.NextToken();
	}
}

public
prog :
	(BodyString {expressionFollowsBodyString = $BodyString.text.endsWith("<?=");} namespaceDefinition)?
	(useStatement | statement)*;

qualifiedNameWithAs
	: qualifiedName (As UnquotedString)?
	;

useStatement
	: Use qualifiedNameWithAs (',' qualifiedNameWithAs)* ';'
	;

namespaceDefinition
	: Namespace qualifiedName ';'
	;

namespaceBlock
	: Namespace qualifiedName bracketedBlock
	;

statement
	: {expressionFollowsBodyString}?=> {expressionFollowsBodyString=false;} printExpr ';'
	| ( {expressionFollowsBodyString}?=>  {expressionFollowsBodyString=false;} printExpr? | simpleStatement?)
		BodyString {expressionFollowsBodyString = $BodyString.text.endsWith("<?=");}
	| namespaceBlock
	| bracketedBlock
	| UnquotedString Colon statement
	| classDefinition
	| interfaceDefinition
	| complexStatement
	| simpleStatement? ';'
	;

printExpr
	: expression
	;

bracketedBlock
	: '{' statement* '}'
	;

interfaceDefinition
	: Interface qualifiedName interfaceExtends?
	  OpenCurlyBracket interfaceMember* CloseCurlyBracket
	;

interfaceExtends
	: Extends qualifiedName (Comma qualifiedName)*
	;

interfaceMember
	: constDefinition ';'
	| fieldModifier* Function qualifiedName parametersDefinition ';'
	;

classDefinition
	:   classModifier? 
		Class qualifiedName 
		(Extends qualifiedName)? 
		classImplements?
		OpenCurlyBracket
		classMember*
		CloseCurlyBracket 
	;
	
classImplements
	:  Implements (qualifiedName (Comma qualifiedName)*)
	;

classMember
	: fieldModifier* Function qualifiedName parametersDefinition (bracketedBlock | ';')
	| constDefinition ';'
	| varDefinition ';'
	| fieldDefinition ';'
	;

constDefinition
	: Const qualifiedName (Equals atom)? (',' qualifiedName (Equals atom)?)*
	;

varDefinition
	: Var VariableName (Equals atom)? (',' VariableName (Equals atom)?)*
	;

fieldDefinition
	: fieldModifier* VariableName (Equals atom)? (',' VariableName (Equals atom)?)*
	;
	
classModifier
	: Abstract;
	
fieldModifier
	: accessModifier | Abstract | Static
	;

complexStatement
	: If '(' expression ')' statement conditional?
	| For '(' forInit forCondition forUpdate ')' statement
	| Foreach '(' expression As arrayEntry ')' statement
	| While '(' expression? ')' statement
	| Do statement While '(' expression ')' ';'
	| Switch '(' expression ')' '{'cases'}'
	| tryStatement
	| functionDefinition
	;

tryStatement 
	: Try bracketedBlock
	  (Catch '(' qualifiedName variable ')' bracketedBlock)+
	  (Finally bracketedBlock)?
	;

simpleStatement
	: Echo commaList
	| Global variable (',' variable)*	// fixed
	| Static VariableName (Equals atom)? (',' VariableName (Equals atom)?)*
	| constDefinition
	| Break Integer?
	| Continue Integer?
	| Goto UnquotedString
	| Return expression?
	| Goto UnquotedString
	| Throw expression
	| expression
	;

conditional
	: ElseIf '(' expression ')' statement conditional?
	| Else statement
	;

forInit
	: commaList? ';'
	;

forCondition
	: commaList? ';'
	;
	
forUpdate
	: commaList?
	;

cases
	: casestatement* defaultcase casestatement*
	| casestatement+
	;

casestatement
	: Case expression (':'|';') statement*
	;

defaultcase 
	: (Default (':'|';') statement*)
	;

anonymousFunctionDefinition
	: Function parametersDefinition (Use parametersDefinition)? bracketedBlock
	;

functionDefinition
	: Function qualifiedName parametersDefinition bracketedBlock
	;

parametersDefinition
	: OpenRoundBracket (paramDef (Comma paramDef)*)? CloseRoundBracket
	;

paramDef
	: (primitiveType | qualifiedName)? paramName (Equals atom)?
	;

paramName
	: VariableName
	| Ampersand VariableName
	;

commaList
	: expression (',' expression)* 
	;
	
expression
	: weakLogicalOr
	;

weakLogicalOr
	: weakLogicalXor (Or weakLogicalXor)*
	;

weakLogicalXor
	: weakLogicalAnd (Xor weakLogicalAnd)*
	;
	
weakLogicalAnd
	: assignment (And assignment)*
	;

assignment
	: listVariables (Equals | AsignmentOperator) assignment
	| ternary
	;

listVariables
	: List OpenRoundBracket variable? (',' variable?)* CloseRoundBracket	// fixed
	| name
	;

ternary
	: logicalOr QuestionMark expression? Colon expression
	| logicalOr
	;
	
logicalOr
	: logicalAnd (LogicalOr logicalAnd)*
	;

logicalAnd
	: bitwiseOr (LogicalAnd bitwiseOr)*
	;
	
bitwiseOr
	: bitwiseXor (Pipe bitwiseXor)*
	;
	
bitwiseXor
	: bitWiseAnd (Hat bitWiseAnd)*
	;

bitWiseAnd
	: equalityCheck (Ampersand equalityCheck)*
	;

equalityCheck
	: comparisionCheck (EqualityOperator comparisionCheck)?
	;
	
comparisionCheck
	: bitWiseShift (ComparisionOperator bitWiseShift)?
	;

bitWiseShift
	: addition (ShiftOperator addition)*
	;
	
addition
	: multiplication ((Plus | Minus | Dot) multiplication)*
	;

multiplication
	: logicalNot ((Asterisk | Forwardslash | Percent) logicalNot)*
	;

logicalNot
	: Bang logicalNot
	| instanceOf
	;

instanceOf
	: negateOrCast (Instanceof negateOrCast)?
	;

negateOrCast
	: (Tilde | Minus | SuppressWarnings) increment
	| OpenRoundBracket primitiveType CloseRoundBracket increment
	| increment
	;

primitiveType
	: IntType | IntegerType | BoolType | BooleanType | FloatType | DoubleType
	| RealType | StringType | ArrayType | ObjectType | UnsetType
	;

increment
	: IncrementOperator name
	| name IncrementOperator
	| listVariables (Equals | AsignmentOperator) assignment
	| newOrClone
	| OpenRoundBracket expression CloseRoundBracket
	;

OP : ':=' ;

newOrClone
	// new $className(), new static
	: New (nameOrFunctionCall | constantOrStaticAccessor)
	| New Static functionArguments?
	| Clone name
	| atomOrReference
	;

atomOrReference
	: reference
	| atom
	;

arrayDeclaration
	: ArrayType OpenRoundBracket (arrayEntry (Comma arrayEntry)* Comma?)? CloseRoundBracket
	| OpenSquareBracket (arrayEntry (Comma arrayEntry)* Comma?)? CloseSquareBracket
	;

arrayEntry
	: (keyValuePair | expression)
	;

keyValuePair
	: (expression ArrayAssign expression)
	;

atom: SingleQuotedString
	| DoubleQuotedString
	| HereDoc
	| (Plus|Minus)? Integer
	| (Plus|Minus)? Real
	| boolean
	| Null
	| arrayDeclaration
	| requireOperator expression
	| constantOrStaticAccessor
	;

//Need to be smarter with references, they have their own tower of application.
reference
	: Ampersand nameOrFunctionCall
	| nameOrFunctionCall
	| anonymousFunctionDefinition
	;

functionArguments
	: OpenRoundBracket (expression (Comma expression)*)? CloseRoundBracket
	;

indexer
	: OpenSquareBracket expression? CloseSquareBracket
	| OpenCurlyBracket expression? CloseCurlyBracket
	;

// OK: $foo->$arr[1], $foo->{$arr}[1]
memberAccess
	: '->' (expression | '{' expression '}'
	  | New|Clone|Echo|If|Else|ElseIf|For|Foreach|While|Do|Try|Catch|Finally|Switch|Case|Default|Namespace|Function|Break|Continue|Goto|Return|Throw|Global|Static|And|Or|Xor|Instanceof|Null|List|Class|Interface|Extends|Implements|Abstract|Var|Const|As|Use|Require|RequireOnce|Include|IncludeOnce|Public|Private|Protected|True|False|HaltCompiler|Die|Empty|Exit|Eval|Isset
	  | IntType | IntegerType | BoolType | BooleanType | FloatType | DoubleType
	  | RealType | StringType | ObjectType
	  )
	;

nameOrFunctionCall
	: variableOrStaticAccessor functionArguments? (indexer | memberAccess functionArguments?)*
	| constantOrStaticAccessor functionArguments (indexer | memberAccess functionArguments?)*
	| constantOrStaticAccessor (indexer | memberAccess functionArguments?)+
	| predefinedFunctionName functionArguments?
	;

name
	// OK: $classname::CONST_VALUE, self::$my_static, \xxx\yyy::zzz()
	// NG: xxx::yyy\zzz()
	// OK: functionArguments indexer
	// NG: indexer functionArguments, functionArguments functionArguments
	: (variableOrStaticAccessor | constantOrStaticAccessor)
	  functionArguments?
	  ((indexer | memberAccess)* memberAccess functionArguments)*
	  (indexer | memberAccess)+
	| variableOrStaticAccessor
	;

variableOrStaticAccessor
	: (variable | qualifiedName) '::' variable
	| variable
	;

constantOrStaticAccessor
	: (variable | qualifiedName) '::' (UnquotedString
		  | IntType | IntegerType | BoolType | BooleanType | FloatType | DoubleType
		  | RealType | StringType | ObjectType
		  )
	| qualifiedName
	;
	
variable
	: variableVariable
	;

variableVariable
	: VariableName
	| '$' (variableVariable | '{' expression '}')
	;

// names don't accept any pre-defined keywords
qualifiedName
	: '\\'? (UnquotedString
		  | IntType | IntegerType | BoolType | BooleanType | FloatType | DoubleType
		  | RealType | StringType | ObjectType | Static
		  )
	( '\\' (UnquotedString
		  | IntType | IntegerType | BoolType | BooleanType | FloatType | DoubleType
		  | RealType | StringType | ObjectType
		  ))*
	;

requireOperator
	: Require | RequireOnce | Include | IncludeOnce
	;

accessModifier
	: Public | Private | Protected
	;

boolean
	: True | False
	;

predefinedFunctionName
	: HaltCompiler | Die | Empty | UnsetType | Eval | Exit | Isset
	;

BodyString 
	: '?>' BodyStringRest
	;

fragment
BodyStringRest
	: {AllowShortOpenTag}?=> BodyStringRestShortTag
	| (('<' ~ '?')=> '<' | ~'<' )* ('<?' ('php'|'='))?
	;

fragment
BodyStringRestShortTag
	: (('<' ~ '?')=> '<' | ~'<' )* ('<?' ('php'|'=')?)?
	;



MultilineComment	
	: '/*' (('*' ~ '/')=>'*' | ~ '*')* '*/' {$channel=HIDDEN;}
	;

SinglelineComment
	: '//'  (('?' ~'>')=>'?' | ~('\n'|'?'))* {$channel=HIDDEN;}
	;

UnixComment
	: '#' (('?' ~'>')=>'?' | ~('\n'|'?'))* {$channel=HIDDEN;}
	;

IntType
	: ('i'|'I')('n'|'N')('t'|'T')
	;

IntegerType
	: ('i'|'I')('n'|'N')('t'|'T')('e'|'E')('g'|'G')('e'|'E')('r'|'R')
	;

BoolType
	: ('b'|'B')('o'|'O')('o'|'O')('l'|'L')
	;

BooleanType
	: ('b'|'B')('o'|'O')('o'|'O')('l'|'L')('e'|'E')('a'|'A')('n'|'N')
	;

FloatType
	: ('f'|'F')('l'|'L')('o'|'O')('a'|'A')('t'|'T')
	;

DoubleType
	: ('d'|'D')('o'|'O')('u'|'U')('b'|'B')('l'|'L')('e'|'E')
	;

RealType
	: ('r'|'R')('e'|'E')('a'|'A')('l'|'L')
	;

StringType
	: ('s'|'S')('t'|'T')('r'|'R')('i'|'I')('n'|'N')('g'|'G')
	;

ObjectType
	: ('o'|'O')('b'|'B')('j'|'J')('e'|'E')('c'|'C')('t'|'T')
	;

UnsetType
	: ('u'|'U')('n'|'N')('s'|'S')('e'|'E')('t'|'T')
	;

ArrayType
	: ('a'|'A')('r'|'R')('r'|'R')('a'|'A')('y'|'Y')
	;

New : ('n'|'N')('e'|'E')('w'|'W');
Clone : ('c'|'C')('l'|'L')('o'|'O')('n'|'N')('e'|'E');
Echo : ('e'|'E')('c'|'C')('h'|'H')('o'|'O');
If : ('i'|'I')('f'|'F');
Else : ('e'|'E')('l'|'L')('s'|'S')('e'|'E');
ElseIf : ('e'|'E')('l'|'L')('s'|'S')('e'|'E')('i'|'I')('f'|'F');
For : ('f'|'F')('o'|'O')('r'|'R');
Foreach : ('f'|'F')('o'|'O')('r'|'R')('e'|'E')('a'|'A')('c'|'C')('h'|'H');
While : ('w'|'W')('h'|'H')('i'|'I')('l'|'L')('e'|'E');
Do : ('d'|'D')('o'|'O');
Try : ('t'|'T')('r'|'R')('y'|'Y');
Catch : ('c'|'C')('a'|'A')('t'|'T')('c'|'C')('h'|'H');
Finally : ('f'|'F')('i'|'I')('n'|'N')('a'|'A')('l'|'L')('l'|'L')('y'|'Y');
Switch : ('s'|'S')('w'|'W')('i'|'I')('t'|'T')('c'|'C')('h'|'H');
Case : ('c'|'C')('a'|'A')('s'|'S')('e'|'E');
Default : ('d'|'D')('e'|'E')('f'|'F')('a'|'A')('u'|'U')('l'|'L')('t'|'T');
Namespace : ('n'|'N')('a'|'A')('m'|'M')('e'|'E')('s'|'S')('p'|'P')('a'|'A')('c'|'C')('e'|'E');
Function : ('f'|'F')('u'|'U')('n'|'N')('c'|'C')('t'|'T')('i'|'I')('o'|'O')('n'|'N');
Break : ('b'|'B')('r'|'R')('e'|'E')('a'|'A')('k'|'K');
Continue : ('c'|'C')('o'|'O')('n'|'N')('t'|'T')('i'|'I')('n'|'N')('u'|'U')('e'|'E');
Goto : ('g'|'G')('o'|'O')('t'|'T')('o'|'O');
Return : ('r'|'R')('e'|'E')('t'|'T')('u'|'U')('r'|'R')('n'|'N');
Throw : ('t'|'T')('h'|'H')('r'|'R')('o'|'O')('w'|'W');
Global : ('g'|'G')('l'|'L')('o'|'O')('b'|'B')('a'|'A')('l'|'L');
Static : ('s'|'S')('t'|'T')('a'|'A')('t'|'T')('i'|'I')('c'|'C');
And : ('a'|'A')('n'|'N')('d'|'D');
Or : ('o'|'O')('r'|'R');
Xor : ('x'|'X')('o'|'O')('r'|'R');
Instanceof : ('i'|'I')('n'|'N')('s'|'S')('t'|'T')('a'|'A')('n'|'N')('c'|'C')('e'|'E')('o'|'O')('f'|'F');
Null : ('n'|'N')('u'|'U')('l'|'L')('l'|'L');
List : ('l'|'L')('i'|'I')('s'|'S')('t'|'T');
Class : ('c'|'C')('l'|'L')('a'|'A')('s'|'S')('s'|'S');
Interface : ('i'|'I')('n'|'N')('t'|'T')('e'|'E')('r'|'R')('f'|'F')('a'|'A')('c'|'C')('e'|'E');
Extends : ('e'|'E')('x'|'X')('t'|'T')('e'|'E')('n'|'N')('d'|'D')('s'|'S');
Implements : ('i'|'I')('m'|'M')('p'|'P')('l'|'L')('e'|'E')('m'|'M')('e'|'E')('n'|'N')('t'|'T')('s'|'S');
Abstract : ('a'|'A')('b'|'B')('s'|'S')('t'|'T')('r'|'R')('a'|'A')('c'|'C')('t'|'T');
Var : ('v'|'V')('a'|'A')('r'|'R');
Const : ('c'|'C')('o'|'O')('n'|'N')('s'|'S')('t'|'T');
As : ('a'|'A')('s'|'S');
Use : ('u'|'U')('s'|'S')('e'|'E');

Require : ('r'|'R')('e'|'E')('q'|'Q')('u'|'U')('i'|'I')('r'|'R')('e'|'E');
RequireOnce : ('r'|'R')('e'|'E')('q'|'Q')('u'|'U')('i'|'I')('r'|'R')('e'|'E')'_'('o'|'O')('n'|'N')('c'|'C')('e'|'E');
Include : ('i'|'I')('n'|'N')('c'|'C')('l'|'L')('u'|'U')('d'|'D')('e'|'E');
IncludeOnce : ('i'|'I')('n'|'N')('c'|'C')('l'|'L')('u'|'U')('d'|'D')('e'|'E')'_'('o'|'O')('n'|'N')('c'|'C')('e'|'E');
Public : ('p'|'P')('u'|'U')('b'|'B')('l'|'L')('i'|'I')('c'|'C');
Private : ('p'|'P')('r'|'R')('i'|'I')('v'|'V')('a'|'A')('t'|'T')('e'|'E');
Protected : ('p'|'P')('r'|'R')('o'|'O')('t'|'T')('e'|'E')('c'|'C')('t'|'T')('e'|'E')('d'|'D');
True : ('t'|'T')('r'|'R')('u'|'U')('e'|'E');
False : ('f'|'F')('a'|'A')('l'|'L')('s'|'S')('e'|'E');
HaltCompiler : '_''_'('h'|'H')('a'|'A')('l'|'L')('t'|'T')'_'('c'|'C')('o'|'O')('m'|'M')('p'|'P')('i'|'I')('l'|'L')('e'|'E')('r'|'R');
Die : ('d'|'D')('i'|'I')('e'|'E');
Empty : ('e'|'E')('m'|'M')('p'|'P')('t'|'T')('y'|'Y');
Exit : ('e'|'E')('x'|'X')('i'|'I')('t'|'T');
Eval : ('e'|'E')('v'|'V')('a'|'A')('l'|'L');
Isset : ('i'|'I')('s'|'S')('s'|'S')('e'|'E')('t'|'T');

fragment
Decimal	
	:('1'..'9' ('0'..'9')*)|'0'
	;
fragment
Hexadecimal
	: '0'('x'|'X')('0'..'9'|'a'..'f'|'A'..'F')+
	;
	
fragment
Octal
	: '0'('0'..'7')+
	;
Integer
	:Octal|Decimal|Hexadecimal
	;
	
fragment
Digits
	: '0'..'9'+
	;
	
fragment
DNum
	:(('.' Digits)=>('.' Digits)|(Digits '.' Digits?))
	;
	
fragment
Exponent_DNum
	:((Digits|DNum)('e'|'E')('+''-')?Digits)
	;
	
Real
	: DNum|Exponent_DNum
	;

SingleQuotedString
	: '\'' (('\\' '\'')=>'\\' '\''
	|		 ('\\' '\\')=>'\\' '\\' 
	|		 '\\' | ~ ('\'' | '\\'))* 
	  '\''
	;

fragment
EscapeCharector
	: 'n' | 'r' | 't' | '\\' | '$' | '"' | Digits | 'x'
	;

DoubleQuotedString
	: '"'  ( ('\\' EscapeCharector)=> '\\' EscapeCharector 
	| '\\' 
	| ~('\\'|'"') )* 
	  '"'
	;

HereDoc 
	: '<<<' HereDocContents
	;

// variable names accept any lexer keywords
VariableName
	: '$' UnquotedStringBody
	;

//Todo handle '\x7f' - '\xff'
UnquotedString
   : UnquotedStringBody
   ;

fragment
UnquotedStringBody
   : ('a'..'z' | 'A'..'Z' | '_')  ('a'..'z' | 'A'..'Z' | '0'..'9' | '_')*
   ;
   
//TODO: add error handling
fragment 
HereDocContents
	: {
		// Please see also Code2Xml.Languages.ANTLRv3.Core.ExtensionForParser
		var sb = new StringBuilder();
		while (input.LA(1) != '\n') {
			sb.append((char)input.LA(1));
			input.consume();
		}
		input.consume();
		var hereDocName = sb.toString().TrimEnd();
		var hdnl = hereDocName.length();
		while (true) {
			var matchEnd = true;
			for (int i = 0; i < hdnl; i++) {
				if (input.LA(1) != hereDocName.charAt(i)) {
					matchEnd = false;
					break;
				}
				input.consume();
			}
			if (matchEnd == false) {
				while (input.LA(1) != '\n') {
					input.consume();
				}
				input.consume();
			} else {
				break;
			}
		}
	}
	;

AsignmentOperator
	: '+='|'-='|'*='|'/='|'.='|'%='|'&='|'|='|'^='|'<<='|'>>='
	;
	
EqualityOperator
	: '==' | '!=' | '===' | '!=='
	;

ComparisionOperator
	: '<' | '<=' | '>' | '>=' | '<>'
	;
	
ShiftOperator
	: '<<' | '>>'
	;

IncrementOperator
	: '--'|'++'
	;

fragment
Eol : '\n'
	;

WhiteSpace
@init{
	$channel=HIDDEN;
}
	:	(' '| '\t'| '\n'|'\r')*
	;
