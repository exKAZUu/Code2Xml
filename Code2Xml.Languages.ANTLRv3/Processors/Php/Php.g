//Todo: Labels and goto have been disabled, need to test on 5.3 

grammar Php;

options {
    backtrack = true; 
    memoize = true;
    k=2;
    output = AST;
    language=CSharp3;
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
    Dollar = '$';
    Colon = ':';
    Dot = '.';
    Ampersand = '&';
    Pipe = '|';
    Bang = '!';
    Plus = '+';
    Minus = '-';
    Asterisk = '*';
    Percent = '%';
    Forwardslash = '/'; 
    Tilde = '~';
    Equals = '=';
    New = 'new';
    Clone = 'clone';
    Echo = 'echo';
    If = 'if';
    Else = 'else';
    ElseIf = 'elseif';
    For = 'for';
    Foreach = 'foreach';
    While = 'while';
    Do = 'do';
    Switch = 'switch';
    Case = 'case';
    Default = 'default';
    Function = 'function';
    Break = 'break';
    Continue = 'continue';
    Goto = 'goto';
    Return = 'return';
    Global = 'global';
    Static = 'static';
    And = 'and';
    Or = 'or';
    Xor = 'xor';
    Instanceof = 'instanceof';

    List = 'list';
    
    Class = 'class';
    Interface = 'interface';
    Extends = 'extends';
    Implements = 'implements';
    Abstract = 'abstract';
    Var = 'var';
    Const = 'const';
    Modifiers;
    ClassDefinition;
    
    Block;
    Params;
    Apply;
    Member;
    Reference;
    Empty;
    Prefix;
    Postfix;
    IfExpression;
    Label;
    Cast;
    ForInit;
    ForCondition;
    ForUpdate;
    Field;
    Method;
}

@modifier { public }
@ctorModifier { public }

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
    private bool allowShortOpenTag = false;

    // Handle the first token, which will always be a BodyString.
    public IToken nextToken(){
        //The following code was pulled out from super.nextToken()
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

    /**
     * Property to enable short open tags
     * 
     * Returns true if short open tags are enabled
     * false if short open tags are disabled.
     * 
     */
    public boolean isAllowShortOpenTag(){
        return allowShortOpenTag;
    }

    /**
     * Property to enable short open tags.
     *
     * Set to true to enable short open tags and false 
     * to disable.
     */
    public void setAllowShortOpenTag(boolean val){
        allowShortOpenTag = val;
    }
}

public
prog : statement*;

statement
    : {expressionFollowsBodyString}?=> {expressionFollowsBodyString=false;} printExpr ';'!
    | ({expressionFollowsBodyString}?=>  {expressionFollowsBodyString=false;} printExpr? | simpleStatement?) BodyString {expressionFollowsBodyString = $BodyString.text.endsWith("<?=");}
    | '{' statement '}'
    | bracketedBlock
    | UnquotedString Colon statement
    | classDefinition
    | interfaceDefinition
    | complexStatement
    | simpleStatement ';'!
    ;

printExpr
    : expression
    ;

bracketedBlock
    : '{' stmts=statement* '}'
    ;

interfaceDefinition
    : Interface interfaceName=UnquotedString interfaceExtends?
        OpenCurlyBracket
        interfaceMember*
        CloseCurlyBracket
    ;

interfaceExtends
    : Extends UnquotedString (Comma! UnquotedString)*
    ;
interfaceMember
    : Const UnquotedString (Equals atom)? ';' 
    | fieldModifier* Function UnquotedString parametersDefinition ';'
    ;

classDefinition
    :   classModifier? 
        Class className=UnquotedString 
        (Extends extendsclass=UnquotedString)? 
        classImplements?
        OpenCurlyBracket
        classMember*
        CloseCurlyBracket 
    ;
    
classImplements
    :  Implements (UnquotedString (Comma! UnquotedString)*)
    ;

classMember
    : fieldModifier* Function UnquotedString parametersDefinition 
        (bracketedBlock | ';')
    | Var Dollar UnquotedString (Equals atom)? ';' 
    | Const UnquotedString (Equals atom)? ';' 
    | fieldModifier* (Dollar UnquotedString) (Equals atom)? ';' 
    ;

fieldDefinition
    : Dollar UnquotedString (Equals atom)? ';'
    ;
    
classModifier
    : 'abstract';
    
fieldModifier
    : AccessModifier | 'abstract' | 'static' 
    ;


complexStatement
    : If '(' ifCondition=expression ')' ifTrue=statement conditional?
    | For '(' forInit forCondition forUpdate ')' statement
    | Foreach '(' variable 'as' arrayEntry ')' statement
    | While '(' whileCondition=expression? ')' statement
    | Do statement While '(' doCondition=expression ')' ';'
    | Switch '(' expression ')' '{'cases'}'
    | functionDefinition
    ;

simpleStatement
    : Echo commaList
    | Global name (','! name)*
    | Static variable Equals! atom
    | Break Integer?
    | Continue Integer?
    | Goto UnquotedString
    | Return expression?
    | RequireOperator expression
    | expression
    ;


conditional
    : ElseIf '(' ifCondition=expression ')' ifTrue=statement conditional?
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
    : casestatement*  defaultcase
    ;

casestatement
    : Case expression ':'! statement*
    ;

defaultcase 
    : (Default ':'! statement*)
    ;

functionDefinition
    : Function UnquotedString parametersDefinition bracketedBlock
    ;

parametersDefinition
    : OpenRoundBracket (paramDef (Comma paramDef)*)? CloseRoundBracket
    ;

paramDef
    : paramName (Equals atom)?
    ;

paramName
    : Dollar UnquotedString
    | Ampersand Dollar UnquotedString
    ;

commaList
    : expression (','! expression)* 
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
    : listVariables ((Equals | AsignmentOperator) assignment) 
    | ternary
    ;

listVariables
    : List OpenRoundBracket! name (','! name)* CloseRoundBracket! 
    | name
    ;

ternary
    : logicalOr QuestionMark expression Colon expression
    | logicalOr
    ;
    
logicalOr
    : logicalAnd (LogicalOr logicalAnd)*
    ;

logicalAnd
    : bitwiseOr (LogicalAnd bitwiseOr)*
    ;
    
bitwiseOr
    : bitWiseAnd (Pipe bitWiseAnd)*
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
    | OpenRoundBracket PrimitiveType CloseRoundBracket increment
    | OpenRoundBracket! weakLogicalAnd CloseRoundBracket!
    | increment
    ;

increment
    : IncrementOperator name
    | name IncrementOperator
    | newOrClone
    ;

newOrClone
    : New nameOrFunctionCall
    | Clone name
    | atomOrReference
    ;

atomOrReference
    : atom
    | reference
    ;

arrayDeclaration
    : Array OpenRoundBracket (arrayEntry (Comma arrayEntry)*)? CloseRoundBracket
    ;

arrayEntry
    : (keyValuePair | expression)
    ;

keyValuePair
    : (expression ArrayAssign expression)
    ;

atom: SingleQuotedString | DoubleQuotedString | HereDoc | Integer | Real | Boolean | arrayDeclaration
    ;

//Need to be smarter with references, they have their own tower of application.
reference
    : Ampersand nameOrFunctionCall
    | nameOrFunctionCall
    ;

nameOrFunctionCall
    : name OpenRoundBracket (expression (Comma expression)*)? CloseRoundBracket
    | name
    ;

name: staticMemberAccess
    | memberAccess
    | variable
    ;
    
staticMemberAccess
    : UnquotedString '::' variable
    ;

memberAccess
    : variable 
        ( OpenSquareBracket expression CloseSquareBracket!
        | '->' UnquotedString)*
    ;
    
variable
    : Dollar variable
    | UnquotedString
    ;

BodyString 
    : '?>' BodyStringRest
    ;

fragment
BodyStringRest
    : {isAllowShortOpenTag()}?=> BodyStringRestShortTag
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
    

Array
    : ('a'|'A')('r'|'R')('r'|'R')('a'|'A')('y'|'Y')
    ;

RequireOperator
    : 'require' | 'require_once' | 'include' | 'include_once'
    ;

PrimitiveType
    : 'int'|'float'|'string'|'array'|'object'|'bool'
    ;

AccessModifier
    : 'public' | 'private' | 'protected' 
    ;

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

Boolean
    : 'true' | 'false'
    ;

SingleQuotedString
    : '\'' (('\\' '\'')=>'\\' '\''
    |         ('\\' '\\')=>'\\' '\\' 
    |         '\\' | ~ ('\'' | '\\'))* 
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

//Todo handle '\x7f' - '\xff'
UnquotedString
   : ('a'..'z' | 'A'..'Z' | '_')  ('a'..'z' | 'A'..'Z' | '0'..'9' | '_')*
   ;
   
//TODO: add error handling
fragment 
HereDocContents
    : {
        StringBuilder sb = new StringBuilder();
        while(input.LA(1)!='\n'){
            sb.append((char)input.LA(1));
            input.consume();
        }
        input.consume();
        String hereDocName = sb.toString();
        int hdnl = hereDocName.length();
        while(true){
            boolean matchEnd = true;
            for(int i = 0; i<hdnl; i++){
                if(input.LA(1)!=hereDocName.charAt(i)){
                    matchEnd=false;
                    break;
                }
                input.consume();
            }
            if(matchEnd==false){
                while(input.LA(1)!='\n'){
                    input.consume();
                }
                input.consume();
            }else{
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
	


