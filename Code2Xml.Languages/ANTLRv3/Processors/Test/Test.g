grammar Test;

options {
    backtrack = true; 
    memoize   = true;
    output    = AST;
    language  = CSharp3;
}

public
compilation_unit
	: assignment+
	;

assignment
	: Identifier '=' assignment
	| addition
	;

addition
    : multiplication ('+' multiplication)*
    ;

multiplication
    : primary ('*' primary)*
    ;

primary
	: Identifier
	| IntegerLiteral 
	| '(' assignment ')'
	| Identifier '=' assignment
	;

Identifier
	: IdentifierStart IdentifierPart*
	;

fragment
IdentifierStart
	: '@' | '_' | 'A'..'Z' | 'a'..'z'
	;

fragment
IdentifierPart
	: 'A'..'Z' | 'a'..'z' | '0'..'9' | '_'
	;

IntegerLiteral:
	Decimal_digits
	;

fragment
Decimal_digits:
	DECIMAL_DIGIT+
	;

fragment
DECIMAL_DIGIT:
	'0'..'9'
	;

WS:
    (' '  |  '\r'  |  '\t'  |  '\n'  ) 
    { $channel=HIDDEN; }
	;
