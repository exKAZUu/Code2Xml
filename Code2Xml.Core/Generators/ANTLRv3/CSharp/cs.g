grammar cs;

options {
	backtrack=true;
    memoize=true;
    output=AST;
    language=CSharp3;
}

@lexer::namespace { Code2Xml.Languages.ANTLRv3.Processors.CSharp }
@parser::namespace { Code2Xml.Languages.ANTLRv3.Processors.CSharp }

@lexer::header {
using System;
using System.Diagnostics;
}

@members
{
	private int _queryExpression = 0;

	protected bool is_class_modifier() 
	{
		return false;
	}
}

/********************************************************************************************
                          Parser section
*********************************************************************************************/

///////////////////////////////////////////////////////
public
compilation_unit:
//	extern_alias_directives?   
	using_directives?  	
	global_attributes?   
	namespace_declaration? 
	namespace_body
	;
namespace_declaration:
	'namespace'   qualified_identifier   namespace_block   ';'? 
	;
qualified_identifier:
	identifier ('.' identifier)* ;

qid:		// qualified_identifier v2
	qid_start qid_part* ;
qid_start:
	identifier ('::' identifier)? generic_argument_list?
	| 'this'
	| 'base'
	| predefined_type
	| literal ;		// 0.ToString() is legal
qid_part:
	access_operator   identifier   generic_argument_list?
	;

namespace_block:
	'{'   namespace_body   '}' ;
namespace_body:
	extern_alias_directives?   using_directives?   namespace_member_declarations? ;
extern_alias_directives:
	extern_alias_directive+ ;
extern_alias_directive:
	'extern'   'alias'   identifier  ';' ;
using_directives:
	using_directive+ ;
using_directive:
	(using_alias_directive
	| using_namespace_directive)
	;
using_alias_directive:
	'using'	  identifier   '='   namespace_or_type_name   ';' ;
using_namespace_directive:
	'using'   namespace_name   ';' ;
namespace_member_declarations:
	namespace_member_declaration+ ;
namespace_member_declaration:
	namespace_declaration
	| type_declaration ;
type_declaration:
	class_declaration
	| struct_declaration
	| interface_declaration
	| enum_declaration
	| delegate_declaration ;
qualified_alias_member:
	identifier   '::'   identifier   generic_argument_list? ;

// B.2.1 Basic Concepts
namespace_name
	: namespace_or_type_name ;
type_name: 
	namespace_or_type_name ;
namespace_or_type_name:
	identifier   generic_argument_list?  ('::' identifier   generic_argument_list?)? ('.'   identifier   generic_argument_list?)*   
//	| qualified_alias_member (the :: part)
    ;
           
// B.2.13 Attributes
global_attributes: 
	global_attribute+ ;
global_attribute: 
	'['   global_attribute_target_specifier   attribute_list   ','?   ']' ;
global_attribute_target_specifier: 
	global_attribute_target   ':' ;
global_attribute_target: 
	'assembly' | 'module' ;
attributes: 
	attribute_sections ;
attribute_sections: 
	attribute_section+ ;
attribute_section: 
	'['   attribute_target_specifier?   attribute_list   ','?   ']' ;
attribute_target_specifier: 
	attribute_target   ':' ;
attribute_target: 
	'field' | 'event' | 'method' | 'param' | 'property' | 'return' | 'type' ;
attribute_list: 
	attribute (',' attribute)* 
	; 
attribute: 
	type_name   attribute_arguments? ;
attribute_arguments: 
    '('
        (
              (identifier '=') => named_argument_list
            | positional_argument_list
        )?
    ')';
positional_argument_list: 
    positional_argument (',' ((identifier '=') => named_argument_list | positional_argument_list))?;
named_argument_list: 
    named_argument (',' named_argument_list)?;
positional_argument: 
    ((identifier ':') => identifier ':')? attribute_argument_expression ;
named_argument: 
    identifier '=' attribute_argument_expression ;
attribute_argument_expression: 
	expression ;

// B.2.2 Types

/* I'm going to ignore the mostly semantic bnf in the C Sharp spec and just do syntax */
type:
	non_array_type rank_specifier*
	;
non_nullable_type:
	(predefined_type | type_name)
		(   rank_specifier+   '*'*
			| ('*'+)?
		)
	| 'void'   '*'+ ;
non_array_type:
	  (predefined_type | type_name) ('*'+ | '?')?
	| 'void' '*'+
	;
type_list:
	type (',' type)* ;
class_type:
	type;
array_type:
	type;
integral_type: 
	'sbyte' | 'byte' | 'short' | 'ushort' | 'int' | 'uint' | 'long' | 'ulong' | 'char' ;
unmanaged_type:
	type;
pointer_type:
	type;
rank_specifiers: 
	rank_specifier+ ;        
rank_specifier: 
	'['   dim_separators?   ']' ;
 dim_separators: 
	','+ ;
generic_argument_list: 
	'<'   type_arguments   '>' ;
type_arguments: 
	type_argument (',' type_argument)* 
	; 
type_argument: 
	type ;
type_variable_name: 
	identifier ;


// B.2.3 Expressions
expression: 
	non_assignment_expression
	| assignment;
unary_expression: 
	cast_expression 			// primary_expression... has parenthesized_expression
	| '+'   unary_expression 
	| '-'   unary_expression 
	| '!'   unary_expression 
	| '~'   unary_expression 
	| '*'   unary_expression
	| await_expression 
	| pre_increment_expression 
	| pre_decrement_expression 
	| primary_or_array_creation_expression   '++'?   '--'?
	| pointer_indirection_expression
	| addressof_expression
	;
await_expression:
	'await' unary_expression ;
pre_increment_expression: 
	'++'   unary_expression ;
pre_decrement_expression: 
	'--'   unary_expression ;
pointer_indirection_expression:
	'*'   unary_expression ;
addressof_expression:
	'&'   unary_expression ;
non_assignment_expression:
	lambda_expression
	| query_expression 
	| conditional_expression;
assignment:
	unary_expression   assignment_operator   expression
	;
variable_reference: 
	expression  ;

argument_list: 
	argument (',' argument)*;
// 4.0
argument:
	argument_name   argument_value
	| argument_value;
argument_name:
	identifier   ':';
argument_value: 
	expression 
	| ref_variable_reference 
	| 'out'   variable_reference ;
ref_variable_reference:
	'ref' '('  
		((  namespace_or_type_name   |   predefined_type )   '*'*   rank_specifiers?
		| 'void'   '*'+   rank_specifiers?
		)   ')'   ref_variable_reference
	| 'ref' variable_reference;

primary_or_array_creation_expression:  
	primary_expression 
	| array_creation_expression ;

texpr:
	tmember ;

//tinvocation:
//	te1=telement   arguments?   (access_operator   te2=telement   arguments?)*;

tinvocation:
	tmember   tinvocation_part? ;
tinvocation_part:
	arguments+   (access_operator!   tinvocation)
	| arguments+   telement_part
	| arguments+ ;
	    
telement:               
	tmember   telement_part? ;
telement_part:
	bracket_expression+   (access_operator   telement)
	| bracket_expression+   tinvocation_part
	| bracket_expression+;
	
tmember:
	identifier   (access_operator   identifier)*;
	
primary_expression: 
	primary_expression_start   primary_expression_part*
	| delegate_creation_expression 			// new FooDelegate (int X, string Y)
	| sizeof_expression						// sizeof (struct)
	| checked_expression            		// checked (...
	| unchecked_expression          		// unchecked {...}
	| default_value_expression      		// default
	| anonymous_method_expression			// delegate (int foo) {}
	;
primary_expression_start:
	(predefined_type | identifier | literal)   generic_argument_list?
	| 'this'    bracket_expression?
	| 'base'    bracket_expression?
	| identifier   '::'   identifier
	| paren_expression   brackets_or_arguments?
	| object_creation_expression			// new Foo().Member
	| anonymous_object_creation_expression	// new {X}.X
	| typeof_expression						// typeof(Foo).Name
	;
primary_expression_part:
	  access_identifier   brackets_or_arguments?
	| brackets_or_arguments ;

element_part:
	access_identifier   bracket_expression+   primary_expression_part? 
	| bracket_expression ;
invocation_part:
	access_identifier   arguments   primary_expression_start? 
	| arguments;
	
member_part:
	access_identifier ;
access_identifier:
	access_operator   identifier   generic_argument_list? ;
paren_expression:	
	'('   expression   ')' ;
brackets_or_arguments:
	bracket_expression+   arguments?
	| arguments   bracket_expression* ;
access_operator:
	'.'  |  '->' ;
arguments: 
	'('   argument_list?   ')' ;
bracket_expression:
	'['   expression_list?   ']' ;

member_access:
	identifier   ('.'   primary_or_array_creation_expression)? //  generic_argument_list?
	;

invocation_expression:
	access arguments;
access:
	'(' expression ')' (  access		// cast expression
						| access_part)  // paren expression
	| qid_start   access_part? ;
// the recursive part
access_part:
	qid_part access_part?				// member access -- '.'   identifier
	| bracket_expression access_part?				// element access;  use rank_specifiers?	
	| arguments access_part? ;           // invocation followed by more invocation
expression_list: 
	expression  (',' expression)*
	; 
object_creation_expression: 
	'new'   type   
		( '('   argument_list?   ')'   object_or_collection_initializer?  
		  | object_or_collection_initializer )
	;
object_or_collection_initializer: 
	object_initializer 
	| collection_initializer ;

// object-initializer
//	Rectangle r = new Rectangle {
//		P1 = new Point { X = 0, Y = 1 },
//		P2 = new Point { X = 2, Y = 3 }
//	};
object_initializer: 
	'{'   member_initializer_list?   '}' 
	| '{'   member_initializer_list   ','   '}' ;
member_initializer_list: 
	member_initializer  (',' member_initializer)*
	; 
member_initializer: 
	identifier   '='   initializer_value ;
initializer_value: 
	expression 
	| object_or_collection_initializer ;
collection_initializer: 
	'{'   element_initializer_list   ','?   '}' ;
element_initializer_list: 
	element_initializer  (',' element_initializer)*
	; 
element_initializer: 
	non_assignment_expression 
	| '{'   expression_list   '}' ;
array_creation_expression: 
	'new'
		( non_array_type '[' expression_list ']' rank_specifiers? array_initializer?
 		| array_type array_initializer		// var a = new int[][] { };
		| rank_specifier array_initializer)	// var a = new [] { 1 };
	access_part?
	;
delegate_creation_expression: 
	'new'   type_name   '('   expression   ')' ;
anonymous_object_creation_expression: 
	'new'   anonymous_object_initializer ;
anonymous_object_initializer: 
	'{'   member_declarator_list?   '}' 
	| '{'   member_declarator_list   ','   '}';
member_declarator_list: 
	member_declarator  (',' member_declarator)*
	; 
member_declarator: 
	identifier   ( generic_argument_list
				 | '.' primary_or_array_creation_expression
				 | '=' expression)? ;
sizeof_expression:
	'sizeof'   '('   unmanaged_type   ')';
typeof_expression: 
	'typeof'   '('   type   ')' 
	| 'typeof' '('   unbound_type_name   ')' 
	| 'typeof' '(' 'void' ')' ;
// unbound type examples
//foo<bar<X<>>>
//bar::foo<>
//foo1::foo2::foo3<,,>
unbound_type_name:		// qualified_identifier v2
	unbound_type_name_start unbound_type_name_part* ;
unbound_type_name_start:
	identifier ('::' identifier)? generic_dimension_specifier?;
unbound_type_name_part:
	'.'   identifier   generic_dimension_specifier? ;
generic_dimension_specifier: 
	'<'   commas?   '>' ;
commas: 
	','+ ; 
checked_expression: 
	'checked'   '('   expression   ')' ;
unchecked_expression: 
	'unchecked'   '('   expression   ')' ;
default_value_expression: 
	'default'   '('   type   ')' ;
constant_expression:
	expression;
boolean_expression:
	expression;
anonymous_method_expression:
	'async'? 'delegate' explicit_anonymous_function_signature? block;
explicit_anonymous_function_signature:
	'('   explicit_anonymous_function_parameter_list?   ')' ;
explicit_anonymous_function_parameter_list:
	explicit_anonymous_function_parameter   (','   explicit_anonymous_function_parameter)*
	;
explicit_anonymous_function_parameter:
	anonymous_function_parameter_modifier?   type   identifier;
anonymous_function_parameter_modifier:
	'ref' | 'out';
// 4.0
variant_generic_parameter_list:
	'<'   variant_type_parameters   '>' ;
variant_type_parameters:
	variant_type_variable_name (',' variant_type_variable_name)* 
	;
variant_type_variable_name:
	attributes?   variance_annotation?   type_variable_name ;
variance_annotation:
	'in' | 'out' ;
	
generic_parameter_list:
	'<'   type_parameters   '>' ;
type_parameters:
	attributed_type_variable_name (',' attributed_type_variable_name)* 
	;
attributed_type_variable_name:
	attributes?   type_variable_name ;
cast_expression:
	'('  
		(
		(  namespace_or_type_name |  predefined_type )   '*'+   rank_specifiers?
		| (  namespace_or_type_name |  predefined_type )   '?'   rank_specifiers?
		| (  namespace_or_type_name |  predefined_type )   rank_specifiers?
		| 'void'   '*'*   rank_specifiers?		// for some reason you can cast to (void)
		)
    ')'   bracket_expression* unary_expression 
	;
multiplicative_expression:
	unary_expression (  ('*'|'/'|'%')   unary_expression)* ;
additive_expression:
	multiplicative_expression (('+'|'-')   multiplicative_expression)* ;
// >> check needed (no whitespace)
shift_expression:
	additive_expression (('<<'|'>' '>') additive_expression)* ;
relational_expression:
	shift_expression 
		(     (('<'|'>'|'<='|'>=')   shift_expression)*
			| ( ('is'|'as') ((non_nullable_type '?' expression ':' expression) => non_nullable_type
							| type)
			  )* 
		) ;
equality_expression:
	relational_expression
	   (('=='|'!=')   relational_expression)* ;
and_expression:
	equality_expression ('&'   equality_expression)* ;
exclusive_or_expression:
	and_expression ('^'   and_expression)* ;
inclusive_or_expression:
	exclusive_or_expression   ('|'   exclusive_or_expression)* ;
conditional_and_expression:
	inclusive_or_expression   ('&&'   inclusive_or_expression)* ;
conditional_or_expression:
	conditional_and_expression  ('||'   conditional_and_expression)* ;
null_coalescing_expression:
	conditional_or_expression   ('??'   null_coalescing_expression)*;
conditional_expression:
	null_coalescing_expression   ('?'   expression   ':'   expression)? ;


array_initializer:
	'{'   variable_initializer_list?   ','?   '}' ;
variable_initializer_list:
	variable_initializer (',' variable_initializer)* ;
// >>= check needed (no whitespace)
assignment_operator:
	'=' | '+=' | '-=' | '*=' | '/=' | '%=' | '&=' | '|=' | '^=' | '<<=' | '>' '>=' ;
lambda_expression:
	'async'? anonymous_function_signature   '=>'   anonymous_function_body;
anonymous_function_signature:
	explicit_anonymous_function_signature 
	| implicit_anonymous_function_signature;
implicit_anonymous_function_signature:
	'('   implicit_anonymous_function_parameter_list?   ')'
	| implicit_anonymous_function_parameter_list;
implicit_anonymous_function_parameter_list:
	implicit_anonymous_function_parameter   (','   implicit_anonymous_function_parameter)* ;
implicit_anonymous_function_parameter:
	identifier;
anonymous_function_body:
	expression
	| block ;

// B.2.12 Delegates
delegate_declaration:
	attributes?   delegate_modifiers?   'delegate'   return_type   identifier  variant_generic_parameter_list?   
		'('   formal_parameter_list?   ')'   type_parameter_constraints_clauses?   ';'
;
delegate_modifiers:
	delegate_modifier (delegate_modifier)* ;
delegate_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'unsafe' ;
query_expression:
	from_clause   query_body ;
from_clause:
	'from'   type?   identifier   'in'   expression ;
query_body:
	query_body_clauses?   select_or_group_clause   (('into') => query_continuation)?;
query_continuation:
	'into'   identifier   query_body;
query_body_clauses:
	query_body_clause+ ;
query_body_clause:
	from_clause
	| let_clause
	| where_clause
	| join_clause
	| orderby_clause;
join_clause:
	'join'   type?   identifier   'in'   expression   'on'   expression   'equals'   expression ('into' identifier)? ;
let_clause:
	'let'   identifier   '='   expression;
orderby_clause:
	'orderby'   ordering_list ;
ordering_list:
	ordering (',' ordering)* ;
ordering:
	expression    ordering_direction? ;
ordering_direction:
	'ascending'
	| 'descending' ;
select_or_group_clause:
	select_clause
	| group_clause ;
select_clause:
	'select'   expression ;
group_clause:
	'group' expression 'by' expression;
where_clause:
	'where'   boolean_expression ;


// Classes B.2.7
class_declaration
:
	attributes? class_modifiers?   'partial'?  'class'  identifier  generic_parameter_list?
		class_base?   type_parameter_constraints_clauses?   class_body   ';'?;
class_modifiers:
	class_modifier+ ;
class_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'abstract' | 'sealed' | 'static' | 'unsafe';
class_base:
	':'   class_type (',' interface_type_list)?
	| ':'   interface_type_list ;
interface_type_list:
	type_name (',' type_name)* 
	;
type_parameter_constraints_clauses:
	type_parameter_constraints_clause+ ;
type_parameter_constraints_clause:
	'where'   type_variable_name   ':'   type_parameter_constraint_list ;
type_parameter_constraint_list:
	(primary_constraint   		','   secondary_constraint_list   ','   constructor_constraint)
	| (primary_constraint   		','   secondary_constraint_list)
	| (primary_constraint   		','   constructor_constraint)
	| (secondary_constraint_list   	','   constructor_constraint)
	| primary_constraint
	| secondary_constraint_list
	| constructor_constraint ;

primary_constraint:
	class_type
	| 'class'
	| 'struct' ;
secondary_constraint_list:
	secondary_constraint (',' secondary_constraint)* 
	;
secondary_constraint:
	(type_name | type_variable_name) ;
constructor_constraint:
	'new'   '('   ')' ;
class_body:
	'{'   class_member_declarations?   '}' ;
class_member_declarations:
	class_member_declaration+ ;
class_member_declaration:
	constant_declaration
	| field_declaration
	| method_declaration
	| property_declaration
	| event_declaration
	| indexer_declaration
	| operator_declaration
	| constructor_declaration
	| destructor_declaration
	| static_constructor_declaration
	| type_declaration 
	| class_declaration ;
constant_declaration:
	attributes?   constant_modifiers?   'const'   type   constant_declarators   ';' ;
constant_modifiers:
	constant_modifier+ ;
constant_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' ;
field_declaration:
	attributes?   field_modifiers?   type   variable_declarators   ';'
	;
field_modifiers:
	field_modifier+ ;
field_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'readonly' | 'volatile' | 'unsafe' ;
variable_declarators:
	variable_declarator (',' variable_declarator)* ;
variable_declarator:
//	identifier ('='   variable_initializer)? ;
	type_name ('='   variable_initializer)? ;		// eg. event EventHandler IInterface.VariableName;
variable_initializer:
	expression	| array_initializer ;
//	| literal ;
method_declarations:
	method_declaration+ ;	
method_declaration:
	method_header   method_body 
	;
method_header:
	attributes?   method_modifiers?   'partial'?   return_type   member_name   generic_parameter_list?
			'('   formal_parameter_list?   ')'   type_parameter_constraints_clauses? ;
method_modifiers:
	method_modifier+ ;
method_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'virtual' | 'sealed' | 'override'
	| 'abstract' | 'extern' | 'unsafe'  | 'async' ;
return_type:
	type
	| 'void' '*'*;
method_body:
	block ;
formal_parameter_list:
	formal_parameter (',' formal_parameter)* 
	;
formal_parameter:
	fixed_parameter | parameter_array | '__arglist';	// __arglist is undocumented, see google
fixed_parameters:
	fixed_parameter+ ;
// 4.0
fixed_parameter:
	attributes?   parameter_modifier?   type   identifier default_argument?;
// 4.0
default_argument:
	'=' expression;
parameter_modifier:
	'ref' | 'out' | 'this' ;
parameter_array:
	attributes?   'params'?   array_type   identifier ;
property_declaration:
	attributes?   property_modifiers?   type   member_name   '{'   accessor_declarations   '}'
	;
property_modifiers:
	property_modifier+ ;
property_modifier
	:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'virtual' | 'sealed' | 'override' | 'abstract' | 'extern' | 'unsafe' ;
member_name:
	qid (generic_parameter_list qid_part)? ;		// IInterface<int>.Method logic added.
accessor_declarations:
	(get_accessor_declaration   set_accessor_declaration?)
	| (set_accessor_declaration   get_accessor_declaration?) ;
get_accessor_declaration:
	attributes?   accessor_modifier?   'get'   accessor_body ;
set_accessor_declaration:
	attributes?   accessor_modifier?   'set'   accessor_body ;
accessor_modifier:
	('public' | 'protected' | 'internal' | 'private' | ('protected'   'internal') | ('internal'   'protected'))	;
accessor_body:
	block 
	;
event_declaration:
	(	attributes?   event_modifiers?   'event'   type   variable_declarators   ';')
	| (	attributes?   event_modifiers?   'event'   type   member_name   '{'   event_accessor_declarations   '}') ;
event_modifiers:
	event_modifier+ ;
event_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'virtual' | 'sealed' | 'override' 
	| 'abstract' | 'extern' | 'unsafe' ;
event_accessor_declarations:
	(add_accessor_declaration   remove_accessor_declaration)
	| (remove_accessor_declaration   add_accessor_declaration) ;
add_accessor_declaration:
	attributes?   'add'   block ;
remove_accessor_declaration:
	attributes?   'remove'   block ;
indexer_declaration:
	attributes?   indexer_modifiers?   indexer_declarator   '{'   accessor_declarations   '}' ;
indexer_modifiers:
	indexer_modifier+ ;
indexer_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'virtual' | 'sealed' | 'override' | 'abstract' | 'extern' | 'unsafe' ;
indexer_declarator:
	type   (type_name '.')? 'this'   '['   formal_parameter_list   ']' ;
operator_declaration:
	attributes?   operator_modifiers   operator_declarator   operator_body ;
operator_modifiers:
	operator_modifier+ ;
operator_modifier:
	'public' | 'static' | 'extern' | 'unsafe' ;
operator_declarator:
	unary_operator_declarator
	| binary_operator_declarator
	| conversion_operator_declarator;
unary_operator_declarator:
	type   'operator'   overloadable_unary_operator   '('   type   identifier   ')' ;
overloadable_unary_operator:
	'+' |  '-' |  '!' |  '~' |  '++' |  '--' |  'true' |  'false' ;
binary_operator_declarator:
	type   'operator'   overloadable_binary_operator   '('   type   identifier   ','   type   identifier   ')' ;
// >> check needed
overloadable_binary_operator:
	'+' | '-' | '*' | '/' | '%' | '&' | '|' | '^' | '<<' | '>' '>' | '==' | '!=' | '>' | '<' | '>=' | '<=' ; 
conversion_operator_declarator:
	('implicit' | 'explicit')  'operator'   type   '('   type   identifier   ')' ;
operator_body:
	block ;
constructor_declaration:
	attributes?   constructor_modifiers?   constructor_declarator   constructor_body ;
constructor_modifiers:
	constructor_modifier+ ;
constructor_modifier:
	'public' | 'protected' | 'internal' | 'private' | 'extern' | 'unsafe' ; 
constructor_declarator:
	identifier   '('   formal_parameter_list?   ')'   constructor_initializer? ;
constructor_initializer:
	':'   ('base' | 'this')   '('   argument_list?   ')' ;
constructor_body:
	block ;
static_constructor_declaration:
	attributes?   static_constructor_modifiers  identifier   '('   ')'  static_constructor_body ;
static_constructor_modifiers:
	  'extern' 'unsafe' 'static'
	| 'extern' 'static' 'unsafe'?
	| 'unsafe' 'extern' 'static'
	| 'unsafe' 'static' 'extern'?
	| 'static' 'extern' 'unsafe'?
	| 'static' 'unsafe' 'extern'? 
	| 'extern'
	| 'unsafe'
	| 'static';
static_constructor_body:
	block ;
destructor_declaration:
	attributes?   destructor_modifiers?   '~'  identifier   '('   ')'    destructor_body ;
destructor_modifiers:
	('extern'? 'unsafe')
	| ('extern' 'unsafe'?) ;
destructor_body:
	block ;

///////////////////////////////////////////////////////
struct_declaration:
	attributes?   struct_modifiers?   'partial'?   'struct'   identifier   generic_parameter_list?
			struct_interfaces?   type_parameter_constraints_clauses?   struct_body   ';'? ;
struct_modifiers:
	struct_modifier+ ;
struct_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'unsafe' ;
struct_interfaces:
	':'   interface_type_list;
struct_body:
	'{'   struct_member_declarations?   '}';
struct_member_declarations:
	struct_member_declaration+ ;
struct_member_declaration:
	constant_declaration
	| fixed_size_buffer_declaration
	| field_declaration
	| method_declaration
	| property_declaration
	| event_declaration
	| indexer_declaration
	| operator_declaration
	| constructor_declaration
	| static_constructor_declaration
	| type_declaration ;
fixed_size_buffer_declaration:
	attributes? fixed_size_buffer_modifiers? 'fixed' type fixed_size_buffer_declarators ';' ;
fixed_size_buffer_modifiers:
	fixed_size_buffer_modifier+;
fixed_size_buffer_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'unsafe' ;
fixed_size_buffer_declarators:
	fixed_size_buffer_declarator (',' fixed_size_buffer_declarator)*;
fixed_size_buffer_declarator:
	identifier '[' constant_expression ']';

///////////////////////////////////////////////////////
interface_declaration:
	attributes?   interface_modifiers?   'partial'?   'interface'   identifier   variant_generic_parameter_list? 
    	interface_base?   type_parameter_constraints_clauses?   interface_body   ';'? 
;
interface_modifiers: 
	interface_modifier+ ;
interface_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'unsafe' ;
interface_base: 
   	':' interface_type_list ;
interface_body:
	'{'   interface_member_declarations?   '}' ;
interface_member_declarations:
	interface_member_declaration+ ;
interface_member_declaration:
	interface_property_declaration 
	| interface_method_declaration 
	| interface_event_declaration 
	| interface_indexer_declaration ;
interface_method_declaration:
	attributes?   'new'?   method_modifiers?  return_type   identifier   generic_parameter_list?
	    '('!   formal_parameter_list?   ')'!   type_parameter_constraints_clauses?   ';' ;
interface_property_declaration: 
	attributes?   'new'?   type   identifier   '{'   interface_accessor_declarations   '}' ;
interface_accessor_declarations:
	interface_get_accessor_declaration   interface_set_accessor_declaration?
	| interface_set_accessor_declaration   interface_get_accessor_declaration? ;
interface_get_accessor_declaration:
	attributes?   'get'   ';' ;		// no body / modifiers
interface_set_accessor_declaration:
	attributes?   'set'   ';' ;		// no body / modifiers
interface_event_declaration: 
	attributes?   'new'?   'event'   type   identifier   ';' ; 
interface_indexer_declaration: 
	attributes?    'new'?    type   'this'   '['   formal_parameter_list   ']'   '{'   interface_accessor_declarations   '}' ;

///////////////////////////////////////////////////////

enum_declaration:
	attributes?   enum_modifiers?   'enum'   identifier   enum_base?   enum_body   ';'? ;
	
enum_base:
	':'   integral_type ;
enum_body:
	'{' (enum_member_declarations ','?)?   '}' ;
enum_member_declarations:
	enum_member_declaration (',' enum_member_declaration)* ;
enum_member_declaration:
	attributes?   identifier   ('='   expression)? ;
enum_modifiers:
	enum_modifier+ ;
enum_modifier:
	'new' | 'public' | 'protected' | 'internal' | 'private' ;
///////////////////////////////////////////////////////

statement:
	labeled_statement
	| declaration_statement
	| embedded_statement ;
embedded_statement:
	block
	//| empty_statement	// TODO
	| expression_statement
	| selection_statement
	| iteration_statement
	| jump_statement
	| try_statement
	| checked_statement
	| unchecked_statement
	| lock_statement
	| using_statement 
	| yield_statement 
	| unsafe_statement
	| fixed_statement;
fixed_statement:
	'fixed'   '('   pointer_type fixed_pointer_declarators   ')'   embedded_statement ;
fixed_pointer_declarators:
	fixed_pointer_declarator   (','   fixed_pointer_declarator)* ;
fixed_pointer_declarator:
	identifier   '='   fixed_pointer_initializer ;
fixed_pointer_initializer:
	'&'   variable_reference   
	| expression;
unsafe_statement:
	'unsafe'   block;
block:
	';' 
	| '{'   statement_list?   '}' ;
statement_list:
	statement+ ;
empty_statement:
	';' ;
labeled_statement:
	identifier   ':'   statement ;
declaration_statement:
	(local_variable_declaration 
	| local_constant_declaration) ';' ;
local_variable_declaration:
	local_variable_type   local_variable_declarators ;
local_variable_type:
	type
	| 'var' 
	| 'dynamic';
local_variable_declarators:
	local_variable_declarator (',' local_variable_declarator)* ;
local_variable_declarator:
	identifier ('='   local_variable_initializer)? 
	; 
local_variable_initializer:
	expression
	| array_initializer 
	| stackalloc_initializer;
stackalloc_initializer:
	'stackalloc'   unmanaged_type   '['   expression   ']' ;
local_constant_declaration:
	'const'   type   constant_declarators ;
constant_declarators:
	constant_declarator (',' constant_declarator)* ;
constant_declarator:
	identifier   ('='   constant_expression)? ;
//	identifier   ('='   literal)? ;
expression_statement:
	expression   ';' ;
statement_expression:
	invocation_expression
	| object_creation_expression
	| assignment
	| unary_expression;
selection_statement:
	if_statement
	| switch_statement ;
if_statement:
	'if'   '('   boolean_expression   ')'   embedded_statement   else_statement?
	;
else_statement:
	'else'   embedded_statement	
	;
switch_statement:
	'switch'   '('   expression   ')'   switch_block ;
switch_block:
	'{'   switch_sections?   '}' ;
switch_sections:
	switch_section+ ;
switch_section:
	switch_labels   statement_list ;
switch_labels:
	switch_label+ ;
switch_label:
	('case'   constant_expression   ':')
	| ('default'   ':') ;
iteration_statement:
	while_statement
	| do_statement
	| for_statement
	| foreach_statement ;
while_statement:
	'while'   '('   boolean_expression   ')'   embedded_statement ;
do_statement:
	'do'   embedded_statement   'while'   '('   boolean_expression   ')'   ';' ;
for_statement:
	'for'   '('   for_initializer?   ';'   for_condition?   ';'   for_iterator?   ')'   embedded_statement ;
for_initializer:
	local_variable_declaration
	| statement_expression_list ;
for_condition:
	boolean_expression ;
for_iterator:
	statement_expression_list ;
statement_expression_list:
	statement_expression (',' statement_expression)* ;
foreach_statement:
	'foreach'   '('   local_variable_type   identifier   'in'   expression   ')'   embedded_statement ;
jump_statement:
	break_statement
	| continue_statement
	| goto_statement
	| return_statement
	| throw_statement ;
break_statement:
	'break'   ';' ;
continue_statement:
	'continue'   ';' ;
goto_statement:
	('goto'   identifier   ';')
	| ('goto'   'case'   constant_expression   ';')
	| ('goto'   'default'   ';') ;
return_statement:
	'return'   expression?   ';' ;
throw_statement:
	'throw'   expression?   ';' ;
try_statement:
      ('try'   block   catch_clauses   finally_clause?)
	| ('try'   block   finally_clause);
catch_clauses:
	(specific_catch_clauses   general_catch_clause?)
	| (specific_catch_clauses?   general_catch_clause) ;
specific_catch_clauses:
	specific_catch_clause+ ;
specific_catch_clause:
	'catch'   '('   class_type   identifier?   ')'   block ;
general_catch_clause:
	'catch'   block ;
finally_clause:
	'finally'   block ;
checked_statement:
	'checked'   block ;
unchecked_statement:
	'unchecked'   block ;
lock_statement:
	'lock'   '('  expression   ')'   embedded_statement ;
using_statement:
	'using'   '('    resource_acquisition   ')'    embedded_statement ;
resource_acquisition:
	local_variable_declaration
	| expression ;
yield_statement:
	('yield'   'return'   expression   ';')
	| ('yield'   'break'   ';') ;

literal:
	Real_literal
	| NUMBER
	| Hex_number
	| Character_literal
	| STRINGLITERAL
	| Verbatim_string_literal
	| TRUE
	| FALSE
	| NULL 
	;

///////////////////////////////////////////////////////
//	Lexar Section
///////////////////////////////////////////////////////

predefined_type:
	  'bool' | 'byte'   | 'char'   | 'decimal' | 'double' | 'float'  | 'int'    | 'long'   | 'object' | 'sbyte'  
	| 'short'  | 'string' | 'uint'   | 'ulong'  | 'ushort' ;

identifier:
	{_queryExpression == 0}? =>
 		( IDENTIFIER | 'add' | 'alias' | 'assembly' | 'module' | 'field' | 'method' | 'param' | 'property' | 'type'
		| 'yield' | 'pragma' | 'remove' | 'get' | 'set' | 'var' | '__arglist' | 'dynamic' | 'async' | 'await' | 'partial'
		| 'from' | 'into' | 'join' | 'on' | 'where' | 'orderby' | 'group' | 'by' | 'ascending' | 'descending' | 'equals' | 'select' | 'let')
	|	( IDENTIFIER | 'add' | 'alias' | 'assembly' | 'module' | 'field' | 'method' | 'param' | 'property' | 'type'
		| 'yield' | 'pragma' | 'remove' | 'get' | 'set' | 'var' | '__arglist' | 'dynamic' | 'async' | 'await' | 'partial')
	;

//keyword:
////	'abstract' | 'as' | 'base' | 'bool' | 'break' | 'byte' | 'case' |  'catch' | 'char' | 'checked' | 'class' | 'const' | 'continue' | 'decimal' | 'default' | 'delegate' | 'do' |	'double' | 'else' |	 'enum'  | 'event' | 'explicit' | 'extern' | 'false' | 'finally' | 'fixed' | 'float' | 'for' | 'foreach' | 'goto' | 'if' | 'implicit' | 'in' | 'int' | 'interface' | 'internal' | 'is' | 'lock' | 'long' | 'namespace' | 'new' | 'null' | 'object' | 'operator' | 'out' | 'override' | 'params' | 'private' | 'protected' | 'public' | 'readonly' | 'ref' | 'return' | 'sbyte' | 'sealed' | 'short' | 'sizeof' | 'stackalloc' | 'static' | 'string' | 'struct' | 'switch' | 'this' | 'throw' | 'true' | 'try' | 'typeof' | 'uint' | 'ulong' | 'unchecked' | 'unsafe' | 'ushort' | 'using' |	 'virtual' | 'void' | 'volatile' ;

//also_keyword:
//	'add' | 'alias' | 'assembly' | 'module' | 'field' | 'event' | 'method' | 'param' | 'property' | 'type' 
//	| 'yield' | 'from' | 'into' | 'join' | 'on' | 'where' | 'orderby' | 'group' | 'by' | 'ascending' | 'descending' 
//	| 'equals' | 'select' | 'pragma' | 'let' | 'remove' | 'set' | 'var' | '__arglist' | 'dynamic';

TRUE : 'true';
FALSE: 'false' ;
NULL : 'null' ;
DOT : '.' ;
PTR : '->' ;
MINUS : '-' ;
GT : '>' ;
USING : 'using';
ENUM : 'enum';
GET : 'get';
SET : 'set';
IF: 'if';
ELSE: 'else';
ELIF: 'elif';
ENDIF: 'endif';
DEFINE: 'define';
UNDEF: 'undef';
SEMI: ';';
RPAREN: ')';

WS:
    (' '  |  '\r'  |  '\t'  |  '\n'  |  '\uFEFF'  )     // C# code sometimes contains duplicated BOMs
    { $channel=HIDDEN; } ;
fragment
TS:
    (' '  |  '\t'  ) 
    ;
        
DOC_LINE_COMMENT
    : '///' ~('\n'|'\r')*  (('\r'|'\n')+ | EOF)
    { $channel=HIDDEN; } ;
LINE_COMMENT
    : '//' ~('\n'|'\r')*  (('\r'|'\n')+ | EOF)
    { $channel=HIDDEN; } ;
COMMENT:
   '/*'
   (options {greedy=false;} : . )* 
   '*/'
    { $channel=HIDDEN; } ;
STRINGLITERAL
    :
    '"' (EscapeSequence | ~('"' | '\\'))* '"' ;
Verbatim_string_literal:
    '@'   '"' Verbatim_string_literal_character* '"' ;
fragment
Verbatim_string_literal_character:
    '"' '"' | ~('"') ;
NUMBER:
    Decimal_digits INTEGER_TYPE_SUFFIX? ;
// For the rare case where 0.ToString() etc is used.
GooBall
@after		
{
	dil.Type = NUMBER;
	d.Type = DOT;
	s.Type = IDENTIFIER;
	Emit(dil); 
	Emit(d); 
	Emit(s); 
	Debug.WriteLine("\tFound GooBall {0}", $text); 
}
	:
	dil = Decimal_integer_literal d = Dot s = GooBallIdentifier
	;

fragment GooBallIdentifier
    : IdentifierStart IdentifierPart* ;

//---------------------------------------------------------
Real_literal:
    Decimal_digits   '.'   Decimal_digits   Exponent_part?   Real_type_suffix?
    | '.'   Decimal_digits   Exponent_part?   Real_type_suffix?
    | Decimal_digits   Exponent_part   Real_type_suffix?
    | Decimal_digits   Real_type_suffix ;
Character_literal:
    '\''
    (   EscapeSequence
    // upto 3 multi byte unicode chars
    |   ~( '\\' | '\'' | '\r' | '\n' )        
    |   ~( '\\' | '\'' | '\r' | '\n' ) ~( '\\' | '\'' | '\r' | '\n' )
    |   ~( '\\' | '\'' | '\r' | '\n' ) ~( '\\' | '\'' | '\r' | '\n' ) ~( '\\' | '\'' | '\r' | '\n' )
    )
    '\'' ;
IDENTIFIER:
    IdentifierStart IdentifierPart* ;
PRAGMA:
    //  ignore everything after the pragma since the escape's in strings etc. are different
    '#' TS* ('pragma' | 'region' | 'endregion' | 'line' | 'warning' | 'error') ~('\r'|'\n')* (('\r'|'\n')+ | EOF)
    { $channel=HIDDEN; } ;
PREPROCESSOR_DIRECTIVE:
    PP_CONDITIONAL
    { $channel=HIDDEN; } ;
fragment
PP_CONDITIONAL:
    (IF_TOKEN
    | ELSE_TOKEN
    | ENDIF_TOKEN
    | DEFINE_TOKEN
    | UNDEF_TOKEN)   TS*   (LINE_COMMENT | ('\r'|'\n')+ | EOF) ;
fragment
IF_TOKEN:
    ('#'   TS*  'if'   ( TS+ PP_EXPRESSION
	                   | ('(') => PP_PRIMARY_EXPRESSION
					   | ('!') => PP_UNARY_EXPRESSION
					   )
	)
        {
            // if our parent is processing check this if
            Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing.  IF_TOKEN");
            if (Processing.Count > 0 && Processing.Peek())
                Processing.Push(Returns.Pop());
            else
                Processing.Push(false);
        }
    ;
fragment
DEFINE_TOKEN:
    '#'   TS*   'define'   TS+   define = IDENTIFIER
    {
        MacroDefines.Add($define.Text);
    } ;
fragment
UNDEF_TOKEN:
    '#'   TS*   'undef'   TS+   define = IDENTIFIER
    {
        if (MacroDefines.Contains($define.Text))
            MacroDefines.Remove($define.Text);
    } ;
fragment
ELSE_TOKEN:
    ( '#'   TS*   e = 'else'
    | '#'   TS*   'elif'   (TS+ PP_EXPRESSION | '(' TS* PP_EXPRESSION TS* ')') )
    {
        // We are in an elif
        if ($e == null) {
            Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing.  ELIF_TOKEN");
            if (Processing.Count > 0 && !Processing.Peek()) {
                Processing.Pop();
                // if our parent was processing, do else logic
                Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing.  ELIF_TOKEN2");
                if (Processing.Count > 0 && Processing.Peek())
                    Processing.Push(Returns.Pop());
                else
                    Processing.Push(false);
            } else {
                Processing.Pop();
                Processing.Push(false);
            }
        } else {
            // we are in a else
            if (Processing.Count > 0) {
                bool bDoElse = !Processing.Pop();

                // if our parent was processing             
                Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing, ELSE_TOKEN");
                if (Processing.Count > 0 && Processing.Peek())
                    Processing.Push(bDoElse);
                else
                    Processing.Push(false);
            }
        }
    }
    ;
fragment
ENDIF_TOKEN:
    '#' TS* 'endif'
    {
        if (Processing.Count > 0)
            Processing.Pop();
    }
    ;
    
fragment
PP_EXPRESSION:
    PP_OR_EXPRESSION;
fragment
PP_OR_EXPRESSION:
    PP_AND_EXPRESSION       TS*     ('||'               TS* PP_AND_EXPRESSION
        {
            bool rt1 = Returns.Pop(), rt2 = Returns.Pop();
            Returns.Push(rt1 || rt2);
        }
        TS* )*
    ;
fragment
PP_AND_EXPRESSION:
    PP_EQUALITY_EXPRESSION  TS*     ('&&'               TS* PP_EQUALITY_EXPRESSION
        {
            bool rt1 = Returns.Pop(), rt2 = Returns.Pop();
            Returns.Push(rt1 && rt2);
        }
        TS* )*
    ;
fragment
PP_EQUALITY_EXPRESSION:
    PP_UNARY_EXPRESSION     TS*     (('=='| ne = '!=')  TS* PP_UNARY_EXPRESSION
        {
            bool rt1 = Returns.Pop(), rt2 = Returns.Pop();
            Returns.Push(rt1 == rt2 == ($ne == null));
        }
        TS* )*
    ;

fragment
PP_UNARY_EXPRESSION:
    '!' TS* PP_UNARY_EXPRESSION
        {
            Returns.Push(!Returns.Pop());
        }
	| PP_PRIMARY_EXPRESSION
    ;
fragment
PP_PRIMARY_EXPRESSION:
	  '(' TS* PP_EXPRESSION TS* ')'
    | IDENTIFIER  
        { 
            Returns.Push(MacroDefines.Contains($IDENTIFIER.Text));
        }
    ;


    
fragment
IdentifierStart
    :   '@' | '_' | 'A'..'Z' | 'a'..'z' | UnicodeEscapeSequence;
fragment
IdentifierPart
: 'A'..'Z' | 'a'..'z' | '0'..'9' | '_' | UnicodeEscapeSequence;
fragment
EscapeSequence 
    :   '\\' (
                 'b' 
             |   't' 
             |   'n' 
             |   'f' 
             |   'r'
             |   'v'
             |   'a'
             |   '\"' 
             |   '\'' 
             |   '\\'
             |   ('0'..'3') ('0'..'7') ('0'..'7')
             |   ('0'..'7') ('0'..'7') 
             |   ('0'..'7')
             |   'x'   HEX_DIGIT
             |   'x'   HEX_DIGIT   HEX_DIGIT
             |   'x'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT
             |   'x'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             |   'u'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             |   'U'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             ) ;

fragment
UnicodeEscapeSequence 
    :   '\\' (
                 'u'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             |   'U'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             ) ;

fragment
Decimal_integer_literal:
    Decimal_digits   INTEGER_TYPE_SUFFIX? ;
fragment
Dot:
    '.' ;
//--------------------------------------------------------
Hex_number:
    '0'('x'|'X')   HEX_DIGITS   INTEGER_TYPE_SUFFIX? ;
fragment
Decimal_digits:
    DECIMAL_DIGIT+ ;
fragment
DECIMAL_DIGIT:
    '0'..'9' ;
fragment
INTEGER_TYPE_SUFFIX:
    'U' | 'u' | 'L' | 'l' | 'UL' | 'Ul' | 'uL' | 'ul' | 'LU' | 'Lu' | 'lU' | 'lu' ;
fragment HEX_DIGITS:
    HEX_DIGIT+ ;
fragment HEX_DIGIT:
    '0'..'9'|'A'..'F'|'a'..'f' ;
fragment
Exponent_part:
    ('e'|'E')   Sign?   Decimal_digits;
fragment
Sign:
    '+'|'-' ;
fragment
Real_type_suffix:
    'F' | 'f' | 'D' | 'd' | 'M' | 'm' ;
