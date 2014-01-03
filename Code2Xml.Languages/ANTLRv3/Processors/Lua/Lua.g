/*
BSD License

Copyright (c) 2013, Kazunori Sakamoto
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
3. Neither the NAME of Rainer Schuster nor the NAMEs of its contributors
   may be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

This grammar file derived from:

    Lua 5.2 Reference Manual
    http://www.lua.org/manual/5.2/manual.html

    Lua 5.1 grammar written by Nicolai Mainiero
    http://www.antlr3.org/grammar/1178608849736/Lua.g

I tested my grammar with Test suite for Lua 5.2 (http://www.lua.org/tests/5.2/)
*/

grammar Lua;

options {
    output=AST;
    backtrack=true;
    memoize=true;
    language=CSharp3;
}

@lexer::namespace { Code2Xml.Languages.ANTLRv3.Processors.Lua }
@parser::namespace { Code2Xml.Languages.ANTLRv3.Processors.Lua }

public
chunk
    : shebang? block
    ;

shebang
	: '#' '!' ~('\n'|'\r')* ('\n'|'\r');

block
    : stat* retstat?
    ;

stat
    : ';'
    | varlist '=' explist
    | functioncall
    | label
    | 'break'
    | 'goto' NAME
    | 'do' block 'end'
    | 'while' exp 'do' block 'end'
    | 'repeat' block 'until' exp
    | 'if' exp 'then' block ('elseif' exp 'then' block)* ('else' block)? 'end'
    | 'for' NAME '=' exp ',' exp (',' exp)? 'do' block 'end'
    | 'for' namelist 'in' explist 'do' block 'end'
    | 'function' funcname funcbody
    | 'local' 'function' NAME funcbody
    | 'local' namelist ('=' explist)?
    ;

retstat
    : 'return' explist? ';'?
    ;

label
    : '::' NAME '::'
    ;

funcname
    : NAME ('.' NAME)* (':' NAME)?
    ;

varlist
    : var (',' var)*
    ;

namelist
    : NAME (',' NAME)*
    ;

explist
    : exp (',' exp)*
    ;

exp
    : ('nil' | 'false' | 'true' | number | string | '...' | functiondef
    | prefixexp | tableconstructor | unop exp) (binop exp)*
	;

var
    : (NAME | '(' exp ')' varSuffix) varSuffix*
    ;

prefixexp
    : varOrExp nameAndArgs*
    ;

functioncall
    : varOrExp nameAndArgs+
    ;

varOrExp
    : var | '(' exp ')'
    ;

nameAndArgs
    : (':' NAME)? args
    ;

varSuffix
    : nameAndArgs* ('[' exp ']' | '.' NAME)
    ;

/*
var
    : NAME | prefixexp '[' exp ']' | prefixexp '.' NAME
    ;

prefixexp
    : var | functioncall | '(' exp ')'
    ;

functioncall
    : prefixexp args | prefixexp ':' NAME args 
    ;
*/

args
    : '(' explist? ')' | tableconstructor | string
    ;

functiondef
    : 'function' funcbody
    ;

funcbody
    : '(' parlist? ')' block 'end'
    ;

parlist
    : namelist (',' '...')? | '...'
    ;

tableconstructor
    : '{' fieldlist? '}'
    ;

fieldlist
    : field (fieldsep field)* fieldsep?
    ;

field
    : '[' exp ']' '=' exp | NAME '=' exp | exp
    ;

fieldsep
    : ',' | ';'
    ;

binop
    : '+' | '-' | '*' | '/' | '^' | '%' | '..'
    | '<' | '<=' | '>' | '>=' | '==' | '~='
    | 'and' | 'or'
    ;

unop
    : '-' | 'not' | '#'
    ;

number
    : INT | HEX | FLOAT | HEX_FLOAT
    ;

string
    : NORMALSTRING | CHARSTRING | LONGSTRING
    ;

// LEXER


	
NAME
    : ('a'..'z'|'A'..'Z'|'_')('a'..'z'|'A'..'Z'|'_'|'0'..'9')*
    ;

NORMALSTRING
    : '"' ( EscapeSequence | ~('\\'|'"') )* '"' 
    ;

CHARSTRING
    : '\'' ( EscapeSequence | ~('\''|'\\') )* '\''
    ;

// ANTLR 4 can process NESTED_STR correctly
LONGSTRING
    : '[[' ( options {greedy=false;} : . )* ']]'
    | '[=[' ( options {greedy=false;} : . )* ']=]'
    | '[==[' ( options {greedy=false;} : . )* ']==]'
    | '[===[' ( options {greedy=false;} : . )* ']===]'
    | '[====[' ( options {greedy=false;} : . )* ']====]'
    | '[=====[' ( options {greedy=false;} : . )* ']=====]'
    | '[======[' ( options {greedy=false;} : . )* ']======]'
    | '[=======[' ( options {greedy=false;} : . )* ']=======]'
    | '[========[' ( options {greedy=false;} : . )* ']========]'
    | '[=========[' ( options {greedy=false;} : . )* ']=========]'
    | '[==========[' ( options {greedy=false;} : . )* ']==========]'
    ;

INT
    : Digit+
    ;

HEX
    : '0' ('x'|'X') HexDigit+
    ;

FLOAT
    : Digit+ '.' Digit* ExponentPart?
    | '.' Digit+ ExponentPart?
    | Digit+ ExponentPart
    ;

HEX_FLOAT
    : '0' ('x'|'X') HexDigit+ '.' HexDigit* HexExponentPart?
    | '0' ('x'|'X') '.' HexDigit+ HexExponentPart?
    | '0' ('x'|'X') HexDigit+ HexExponentPart
    ;

fragment
ExponentPart
    : ('e'|'E') ('+'|'-')? Digit+
    ;

fragment
HexExponentPart
    : ('p'|'P') ('+'|'-')? Digit+
    ;

fragment
EscapeSequence
    : '\\' ('a'|'b'|'f'|'n'|'r'|'t'|'v'|'z'|'\"'|'\''|'\\')
	| '\\' '\r'? '\n'
    | DecimalEscape
    | HexEscape
    ;
    
fragment
DecimalEscape
    : '\\' Digit
    | '\\' Digit Digit
    | '\\' '0'..'2' Digit Digit
    ;
    
fragment
HexEscape
    : '\\' 'x' HexDigit HexDigit
    ;

fragment
Digit
    : '0'..'9'
    ;

fragment
HexDigit
    : ('0'..'9'|'a'..'f'|'A'..'F')
    ;

COMMENT
    : '--'
	( '[[' ( options {greedy=false;} : . )* ']]'
    | '[=[' ( options {greedy=false;} : . )* ']=]'
    | '[==[' ( options {greedy=false;} : . )* ']==]'
    | '[===[' ( options {greedy=false;} : . )* ']===]'
    | '[====[' ( options {greedy=false;} : . )* ']====]'
    | '[=====[' ( options {greedy=false;} : . )* ']=====]'
    | '[======[' ( options {greedy=false;} : . )* ']======]'
    | '[=======[' ( options {greedy=false;} : . )* ']=======]'
    | '[========[' ( options {greedy=false;} : . )* ']========]'
    | '[=========[' ( options {greedy=false;} : . )* ']=========]'
    | '[==========[' ( options {greedy=false;} : . )* ']==========]')
	{$channel=Hidden;}
    ;
    
LINE_COMMENT
	: '--' ~('\n'|'\r')* {$channel=Hidden;}
    ;
    
WS  
    : (' '|'\t'|'\u000C')+ {$channel=Hidden;}
    ;
    
NEWLINE
    : '\r'? '\n' {$channel=Hidden;}
    ;

SHEBANG
	: '#' '!' ~('\n'|'\r')* {$channel=Hidden;}
	;
