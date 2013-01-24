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
grammar C;
options {
	backtrack=true;
	memoize=true;
	k=2;
	output=AST;
	language=CSharp3;
}

scope Symbols {
	// only track types in order to get parser working
	HashSet<string> types; 
}

@members {
	boolean isTypeName(String name) {
		for (int i = Symbols_stack.size()-1; i>=0; i--) {
			Symbols_scope scope = (Symbols_scope)Symbols_stack.get(i);
			if ( scope.types.contains(name) ) {
				return true;
			}
		}
		return false;
	}
}

translation_unit
scope Symbols; // entire file is a scope
@init {
  $Symbols::types = new HashSet<string>();
}
	: external_declaration+
	;

/** Either a function definition or any other kind of C decl/def.
 *  The LL(*) analysis algorithm fails to deal with this due to
 *  recursion in the declarator rules.  I'm putting in a
 *  manual predicate here so that we don't backtrack over
 *  the entire function.  Further, you get a better error
 *  as errors within the function itself don't make it fail
 *  to predict that it's a function.  Weird errors previously.
 *  Remember: the goal is to avoid backtrack like the plague
 *  because it makes debugging, actions, and errors harder.
 *
 *  Note that k=1 results in a much smaller predictor for the 
 *  fixed lookahead; k=2 made a few extra thousand lines. ;)
 *  I'll have to optimize that in the future.
 */
external_declaration
options {k=1;}
	: ( declaration_specifiers? declarator declaration* '{' )=> function_definition
	| declaration
	;

function_definition
scope Symbols; // put parameters and locals into same scope for now
@init {
  $Symbols::types = new HashSet<string>();
}
	:	declaration_specifiers? declarator
		(	declaration+ compound_statement	// K&R style
		|	compound_statement				// ANSI style
		)
	;

declaration
scope {
  boolean isTypedef;
}
@init {
  $declaration::isTypedef = false;
}
	: gcc_extension_specifier? 'typedef' declaration_specifiers? { $declaration::isTypedef = true; }  // for gcc
	  init_declarator_list ';' // special case, looking for typedef	
	| declaration_specifiers init_declarator_list? ';'
	;

declaration_specifiers
	:   (   storage_class_specifier
		|   type_specifier
		|   type_qualifier
		|   gcc_function_specifier
		|   gcc_declaration_specifier
		)+
	;

init_declarator_list
	: init_declarator (',' init_declarator)*
	;

init_declarator
	: declarator ('=' initializer)?
	;

storage_class_specifier
	: 'extern'
	| 'static'
	| 'auto'
	| 'register'
	;

type_specifier
	: 'void'
	| 'char'
	| 'short'
	| 'int'
	| 'long'
	| 'float'
	| 'double'
	| 'signed'
	| 'unsigned'
	| struct_or_union_specifier
	| enum_specifier
	| type_id
	| gcc_typeof
	;

type_id
	:   {isTypeName(input.LT(1).getText())}? IDENTIFIER
//    	{System.out.println($IDENTIFIER.text+" is a type");}
	;

struct_or_union_specifier
options {k=3;}
scope Symbols; // structs are scopes
@init {
  $Symbols::types = new HashSet<string>();
}
	: struct_or_union gcc_attribute_list? IDENTIFIER? '{' struct_declaration_list '}'
	| struct_or_union gcc_attribute_list? IDENTIFIER
	;

struct_or_union
	: 'struct'
	| 'union'
	;

struct_declaration_list
	: struct_declaration+
	;

struct_declaration
	: specifier_qualifier_list struct_declarator_list ';'
	| ';' // for gcc
	;

specifier_qualifier_list
	: ( type_qualifier | type_specifier | gcc_declaration_specifier)+
	;

struct_declarator_list
	: struct_declarator (',' struct_declarator)*
	;

struct_declarator
	: declarator
	| declarator? ':' constant_expression gcc_attribute_list?
	;

enum_specifier
options {k=4;}
	: 'enum' gcc_attribute_list? IDENTIFIER? '{' enumerator_list '}'
	| 'enum' gcc_attribute_list? IDENTIFIER
	;

enumerator_list
	: enumerator (',' enumerator)*
	;

enumerator
	: IDENTIFIER ('=' constant_expression)?
	;

type_qualifier
	: 'const'
	| 'volatile'
	| 'restrict'		// for gcc
	| '__const'			// for gcc
	| '__volatile'		// for gcc
	| '__restrict'		// for gcc
	| '__const__'		// for gcc
	| '__volatile__'	// for gcc
	| '__restrict__'	// for gcc
	;

declarator
	: pointer? direct_declarator gcc_asm_expression? gcc_attribute_list?
	| pointer
	;

direct_declarator
	:   (	IDENTIFIER
			{
			if ($declaration.size() > 0 && $declaration::isTypedef) {
				$Symbols::types.add($IDENTIFIER.text);
				//Console.WriteLine("define type "+$IDENTIFIER.text);
			}
			}
		|	'(' gcc_attribute_list? declarator ')'
		)
		declarator_suffix*
	;

declarator_suffix
	:   '[' constant_expression ']'
	|   '[' ']'
	|   '(' parameter_type_list ')'
	|   '(' identifier_list ')'
	|   '(' ')'
	;

pointer		// for gcc
	: ('*' (type_qualifier | gcc_attribute)*)+
	;

parameter_type_list
	: parameter_list (',' '...')?
	;

parameter_list
	: parameter_declaration (',' parameter_declaration)*
	;

parameter_declaration
	: declaration_specifiers (declarator|abstract_declarator)*
	;

identifier_list
	: IDENTIFIER (',' IDENTIFIER)*
	;

type_name
	: specifier_qualifier_list abstract_declarator?
	;

abstract_declarator
	: pointer
	| pointer? direct_abstract_declarator gcc_asm_expression? gcc_attribute_list?
	;

direct_abstract_declarator
	: ( '(' gcc_attribute_list? abstract_declarator ')' | abstract_declarator_suffix ) abstract_declarator_suffix*
	;

abstract_declarator_suffix
	:	'[' gcc_array_type_modifier* constant_expression? ']'
	|	'[' gcc_array_type_modifier* '*' ']'
	|	'(' parameter_type_list? ')'
	;
	
initializer
	: assignment_expression
	| '{' initializer_list ','? '}'
	;

initializer_list
	: designation?
	  initializer
	  (',' designation? initializer)*
	;

designation
	: designator+ '=' ;

designator
	: '[' constant_expression ']'
	| '.' IDENTIFIER
	  // GCC extension
	| '[' constant_expression '...' constant_expression ']'
	;


// E x p r e s s i o n s

argument_expression_list
	:   assignment_expression (',' assignment_expression)*
	;

additive_expression
	: (multiplicative_expression) ('+' multiplicative_expression | '-' multiplicative_expression)*
	;

multiplicative_expression
	: (cast_expression) ('*' cast_expression | '/' cast_expression | '%' cast_expression)*
	;

cast_expression
	: '(' type_name ')' cast_expression
	| unary_expression
	;

unary_expression
	: postfix_expression
	| '++' unary_expression
	| '--' unary_expression
	| unary_operator cast_expression
	| 'sizeof' unary_expression
	| 'sizeof' '(' type_name ')'
	// gcc extension
	| '__alignof__' unary_expression
	| '__alignof__' '(' type_name ')'
	| gcc_extension_specifier cast_expression
	;

postfix_expression
	:   primary_expression
		(   '[' expression ']'
		|   '(' ')'
		|   '(' argument_expression_list ')'
		|   '.' IDENTIFIER
		|   '->' IDENTIFIER
		|   '++'
		|   '--'
		)*
	| gcc_builtin_va_arg
	| gcc_builtin_offsetof
	;

unary_operator
	: '&'
	| '*'
	| '+'
	| '-'
	| '~'
	| '!'
	;

primary_expression
	: IDENTIFIER
	| constant
	| '(' expression ')'
	| gcc_statement_expression
	;

constant
	:   hex_literal
	|   octal_literal
	|   decimal_literal
	|   character_literal
	|   string_literal
	|   floating_point_literal
	;

hex_literal
	:	HEX_LITERAL
	;

octal_literal
	:	OCTAL_LITERAL
	;

decimal_literal
	:	DECIMAL_LITERAL
	;

character_literal
	:	CHARACTER_LITERAL
	;

string_literal
	:	STRING_LITERAL+
	;

floating_point_literal
	:	FLOATING_POINT_LITERAL
	;

/////

expression
	: assignment_expression (',' assignment_expression)*
	;

constant_expression
	: conditional_expression
	;

assignment_expression
	: lvalue assignment_operator assignment_expression
	| conditional_expression
	;
	
lvalue
	:	unary_expression
	;

assignment_operator
	: '='
	| '*='
	| '/='
	| '%='
	| '+='
	| '-='
	| '<<='
	| '>>='
	| '&='
	| '^='
	| '|='
	;

conditional_expression
	: logical_or_expression ('?' expression ':' conditional_expression)?
	// gcc extension
	| logical_or_expression '?' ':' conditional_expression
	;

logical_or_expression
	: logical_and_expression ('||' logical_and_expression)*
	;

logical_and_expression
	: inclusive_or_expression ('&&' inclusive_or_expression)*
	;

inclusive_or_expression
	: exclusive_or_expression ('|' exclusive_or_expression)*
	;

exclusive_or_expression
	: and_expression ('^' and_expression)*
	;

and_expression
	: equality_expression ('&' equality_expression)*
	;
equality_expression
	: relational_expression (('=='|'!=') relational_expression)*
	;

relational_expression
	: shift_expression (('<'|'>'|'<='|'>=') shift_expression)*
	;

shift_expression
	: additive_expression (('<<'|'>>') additive_expression)*
	;

// S t a t e m e n t s

statement
	: labeled_statement
	| compound_statement
	| expression_statement
	| selection_statement
	| iteration_statement
	| jump_statement
	| gcc_asm_statement
	;

labeled_statement
	: IDENTIFIER ':' statement
	| 'case' constant_expression ':' statement
	| 'default' ':' statement
	;

compound_statement
scope Symbols; // blocks have a scope of symbols
@init {
  $Symbols::types = new HashSet<string>();
}
	: '{' block_item* '}'
	;

block_item
	: declaration | statement
	;

expression_statement
	: ';'
	| expression ';'
	;

selection_statement
	: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
	| 'switch' '(' expression ')' statement
	;

iteration_statement
	: 'while' '(' expression ')' statement
	| 'do' statement 'while' '(' expression ')' ';'
	| 'for' '(' expression_statement expression_statement expression? ')' statement
	;

jump_statement
	: 'goto' IDENTIFIER ';'
	| 'continue' ';'
	| 'break' ';'
	| 'return' ';'
	| 'return' expression ';'
	;

// -------------------------------- start gcc extension --------------------------------

gcc_function_specifier
	: 'inline'
	| '__inline__'
	| '__inline'
	| '__builtin_va_list'
	;

gcc_extension_specifier
	: '__extension__'
	;

gcc_declaration_specifier
	: gcc_attribute
	| gcc_extension_specifier
	;

gcc_attribute_list
	: gcc_attribute+
	;

gcc_attribute
	: '__attribute__' '(' '(' gcc_attribute_parameter_list ')' ')'
	;

gcc_attribute_parameter_list
	: gcc_attribute_parameter (',' gcc_attribute_parameter)*
	;

gcc_attribute_parameter
	: gcc_attribute_name
	| gcc_attribute_name '(' (assignment_expression (',' assignment_expression)*)? ')'
	;

gcc_attribute_name
	: IDENTIFIER
	| storage_class_specifier
	| type_specifier
	| type_qualifier
	| gcc_function_specifier
	;

gcc_asm_statement :   gcc_asm_expression ';' ;

gcc_asm_expression :   ( '__asm__' | 'asm' )
					   ( type_qualifier )?
					   '('
					   expression expression?
						 (
						  ':' ( gcc_asm_operand ( ',' gcc_asm_operand )* )?
							(
							 ':' ( gcc_asm_operand ( ',' gcc_asm_operand )* )?
							   (
								':'   gcc_asm_clobber ( ',' gcc_asm_clobber )*
							   )?
							)?
						 )?
					   ')'
				   ;

gcc_asm_operand :   ( '[' IDENTIFIER ']' )? string_literal '(' expression ')' ;

gcc_asm_clobber :   string_literal ;


gcc_statement_expression
	: '(' compound_statement ')'
	;

gcc_array_type_modifier_list
	: gcc_array_type_modifier+
	;

gcc_array_type_modifier
	: type_qualifier
	| gcc_attribute
	;

gcc_builtin_va_arg
	: '__builtin_va_arg' '(' assignment_expression ',' type_name ')'
	;

gcc_typeof
	: 'typeof' '(' ( type_name | assignment_expression ) ')'
	;

gcc_builtin_offsetof
	: '__builtin_offsetof' '(' type_name ',' offsetof_member_designator ')'
	;
	 
offsetof_member_designator
	: IDENTIFIER ('.' IDENTIFIER | '[' expression ']')*
	;
// --------------------------------- end gcc extension ---------------------------------

IDENTIFIER
	:	LETTER (LETTER|'0'..'9')*
	;
	
fragment
LETTER
	:	'$'
	|	'A'..'Z'
	|	'a'..'z'
	|	'_'
	;

CHARACTER_LITERAL
	:   '\'' ( EscapeSequence | ~('\''|'\\') ) '\''
	;

STRING_LITERAL
	:  '"' ( EscapeSequence | ~('\\'|'"') )* '"'
	;

HEX_LITERAL : '0' ('x'|'X') HexDigit+ IntegerTypeSuffix? ;

DECIMAL_LITERAL : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;

OCTAL_LITERAL : '0' ('0'..'7')+ IntegerTypeSuffix? ;

fragment
HexDigit : ('0'..'9'|'a'..'f'|'A'..'F') ;

fragment
IntegerTypeSuffix
	:	('u'|'U')? ('l'|'L')
	|	('u'|'U')  ('l'|'L')?
	|	('u'|'U')? ('l'|'L') ('l'|'L')
	;

FLOATING_POINT_LITERAL
	:   ('0'..'9')+ '.' ('0'..'9')* Exponent? FloatTypeSuffix?
	|   '.' ('0'..'9')+ Exponent? FloatTypeSuffix?
	|   ('0'..'9')+ Exponent FloatTypeSuffix?
	|   ('0'..'9')+ Exponent? FloatTypeSuffix
	;

fragment
Exponent : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;

fragment
FloatTypeSuffix : ('f'|'F'|'d'|'D') ;

fragment
EscapeSequence
	:   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
	|   OctalEscape
	;

fragment
OctalEscape
	:   '\\' ('0'..'3') ('0'..'7') ('0'..'7')
	|   '\\' ('0'..'7') ('0'..'7')
	|   '\\' ('0'..'7')
	;

fragment
UnicodeEscape
	:   '\\' 'u' HexDigit HexDigit HexDigit HexDigit
	;

WS  :  (' '|'\r'|'\t'|'\u000C'|'\n') {Skip();}
	;

COMMENT
	:   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
	;

LINE_COMMENT
	: '//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
	;

// ignore #line info for now
LINE_COMMAND 
	: '#' ~('\n'|'\r')* '\r'? '\n' {Skip();}
	;
