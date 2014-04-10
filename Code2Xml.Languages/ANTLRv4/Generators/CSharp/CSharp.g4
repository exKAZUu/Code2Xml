grammar CSharp;

test
	: 'abc' Eof
;

//namespaceName
//	: namespaceOrTypeName
//;
//typeName
//	: namespaceOrTypeName
//;
//namespaceOrTypeName
//	: Identifier typeArgumentList?
//	| namespaceOrTypeName '.' Identifier typeArgumentList?
//	| qualifiedAliasMember
//;
//type
//	: valueType
//	| referenceType
//	| typeParameter
//	| pointerType
//;
//valueType
//	: structType
//	| enumType
//;
//structType
//	: typeName
//	| simpleType
//	| nullableType
//;
//simpleType
//	: numericType
//	| 'bool'
//;
//numericType
//	: integralType
//	| floatingPointType
//	| 'decimal'
//;
//integralType
//	: 'sbyte'
//	| 'byte'
//	| 'short'
//	| 'ushort'
//	| 'int'
//	| 'uint'
//	| 'long'
//	| 'ulong'
//	| 'char'
//;
//floatingPointType
//	: 'float'
//	| 'double'
//;
//nullableType
//	: nonNullableValueType '?'
//;
//nonNullableValueType
//	: type
//;
//enumType
//	: typeName
//;
//referenceType
//	: classType
//	| interfaceType
//	| arrayType
//	| delegateType
//;
//classType
//	: typeName
//	| 'object'
//	| 'dynamic'
//	| 'string'
//;
//interfaceType
//	: typeName
//;
//delegateType
//	: typeName
//;
//rankSpecifiers
//	: rankSpecifier
//	| rankSpecifiers rankSpecifier
//;
//rankSpecifier
//	: '[' dimSeparators? ']'
//;
//dimSeparators
//	: ','
//	| dimSeparators ','
//;
//typeArgumentList
//	: '<' typeArguments '>'
//;
//typeArguments
//	: typeArgument
//	| typeArguments ',' typeArgument
//;
//typeArgument
//	: type
//;
//variableReference
//	: expression
//;
//argumentList
//	: argument
//	| argumentList ',' argument
//;
//argument
//	: argumentName? argumentValue
//;
//argumentName
//	: Identifier ':'
//;
//argumentValue
//	: expression
//	| 'ref' variableReference
//	| 'out' variableReference
//;
//primaryExpression
//	: primaryNoArrayCreationExpression
//	| arrayCreationExpression
//;
//primaryNoArrayCreationExpression
//	: literal
//	| simpleName
//	| parenthesizedExpression
//	| memberAccess
//	| invocationExpression
//	| elementAccess
//	| thisAccess
//	| baseAccess
//	| postIncrementExpression
//	| postDecrementExpression
//	| objectCreationExpression
//	| delegateCreationExpression
//	| anonymousObjectCreationExpression
//	| typeofExpression
//	| checkedExpression
//	| uncheckedExpression
//	| defaultValueExpression
//	| anonymousMethodExpression
//	| pointerMemberAccess
//	| pointerElementAccess
//	| sizeofExpression
//;
//simpleName
//	: Identifier typeArgumentList?
//;
//parenthesizedExpression
//	: '(' expression ')'
//;
//memberAccess
//	: primaryExpression '.' Identifier typeArgumentList?
//	| predefinedType '.' Identifier typeArgumentList?
//	| qualifiedAliasMember '.' Identifier
//;
//predefinedType
//	: 'bool'	| 'byte'	| 'char'	| 'decimal'	| 'double'	| 'float'	| 'int'		| 'long'
//	| 'object'	| 'sbyte'	| 'short'	| 'string'	| 'uint'	| 'ulong'	| 'ushort'
//;
//invocationExpression
//	: primaryExpression '(' argumentList? ')'
//;
//elementAccess
//	: primaryNoArrayCreationExpression '[' argumentList ']'
//;
//thisAccess
//	: 'this'
//;
//baseAccess
//	: 'base' '.' Identifier
//	| 'base' '[' argumentList ']'
//;
//postIncrementExpression
//	: primaryExpression '++'
//;
//postDecrementExpression
//	: primaryExpression '--'
//;
//objectCreationExpression
//	: 'new' type '(' argumentList? ')' objectOrCollectionInitializer?
//	| 'new' type objectOrCollectionInitializer
//;
//objectOrCollectionInitializer
//	: objectInitializer
//	| collectionInitializer
//;
//objectInitializer
//	: '{' memberInitializerList? '}'
//	| '{' memberInitializerList ',' '}'
//;
//memberInitializerList
//	: memberInitializer
//	| memberInitializerList ',' memberInitializer
//;
//memberInitializer
//	: Identifier '=' initializerValue
//;
//initializerValue
//	: expression
//	| objectOrCollectionInitializer
//;
//collectionInitializer
//	: '{' elementInitializerList '}'
//	| '{' elementInitializerList ',' '}'
//;
//elementInitializerList
//	: elementInitializer
//	| elementInitializerList ',' elementInitializer
//;
//elementInitializer
//	: nonAssignmentExpression
//	| '{' expressionList '}'
//;
//expressionList
//	: expression
//	| expressionList ',' expression
//;
//arrayCreationExpression
//	: 'new' nonArrayType '[' expressionList ']' rankSpecifiers? arrayInitializer?
//	| 'new' arrayType arrayInitializer
//	| 'new' rankSpecifier arrayInitializer
//;
//delegateCreationExpression
//	: 'new' delegateType '(' expression ')'
//;
//anonymousObjectCreationExpression
//	: 'new' anonymousObjectInitializer
//;
//anonymousObjectInitializer
//	: '{' memberDeclaratorList? '}'
//	| '{' memberDeclaratorList ',' '}'
//;
//memberDeclaratorList
//	: memberDeclarator
//	| memberDeclaratorList ',' memberDeclarator
//;
//memberDeclarator
//	: simpleName
//	| memberAccess
//	| Identifier '=' expression
//;
//typeofExpression
//	: 'typeof' '(' type ')'
//	| 'typeof' '(' unboundTypeName ')'
//	| 'typeof' '(' 'void' ')'
//;
//unboundTypeName
//	: Identifier genericDimensionSpecifier?
//	| Identifier '::' Identifier genericDimensionSpecifier?
//	| unboundTypeName '.' Identifier genericDimensionSpecifier?
//;
//genericDimensionSpecifier
//	: '<' commas? '>'
//;
//commas
//	: ','
//	| commas ','
//;
//checkedExpression
//	: 'checked' '(' expression ')'
//;
//uncheckedExpression
//	: 'unchecked' '(' expression ')'
//;
//defaultValueExpression
//	: 'default' '(' type ')'
//;
//unaryExpression
//	: primaryExpression
//	| '+' unaryExpression
//	| '-' unaryExpression
//	| '!' unaryExpression
//	| '~' unaryExpression
//	| preIncrementExpression
//	| preDecrementExpression
//	| castExpression
//	| pointerIndirectionExpression
//	| addressofExpression
//;
//preIncrementExpression
//	: '++' unaryExpression
//;
//preDecrementExpression
//	: '--' unaryExpression
//;
//castExpression
//	: '(' type ')' unaryExpression
//;
//multiplicativeExpression
//	: unaryExpression
//	| multiplicativeExpression '*' unaryExpression
//	| multiplicativeExpression '/' unaryExpression
//	| multiplicativeExpression '%' unaryExpression
//;
//additiveExpression
//	: multiplicativeExpression
//	| additiveExpression '+' multiplicativeExpression
//	| additiveExpression '-' multiplicativeExpression
//;
//shiftExpression
//	: additiveExpression
//	| shiftExpression '<<' additiveExpression
//	| shiftExpression '>>' additiveExpression
//;
//relationalExpression
//	: shiftExpression
//	| relationalExpression '<' shiftExpression
//	| relationalExpression '>' shiftExpression
//	| relationalExpression '<=' shiftExpression
//	| relationalExpression '>=' shiftExpression
//	| relationalExpression 'is' type
//	| relationalExpression 'as' type
//;
//equalityExpression
//	: relationalExpression
//	| equalityExpression '==' relationalExpression
//	| equalityExpression '!=' relationalExpression
//;
//andExpression
//	: equalityExpression
//	| andExpression '&' equalityExpression
//;
//exclusiveOrExpression
//	: andExpression
//	| exclusiveOrExpression '^' andExpression
//;
//inclusiveOrExpression
//	: exclusiveOrExpression
//	| inclusiveOrExpression '|' exclusiveOrExpression
//;
//conditionalAndExpression
//	: inclusiveOrExpression
//	| conditionalAndExpression '&&' inclusiveOrExpression
//;
//conditionalOrExpression
//	: conditionalAndExpression
//	| conditionalOrExpression '||' conditionalAndExpression
//;
//nullCoalescingExpression
//	: conditionalOrExpression
//	| conditionalOrExpression '??' nullCoalescingExpression
//;
//conditionalExpression
//	: nullCoalescingExpression
//	| nullCoalescingExpression '?' expression ':' expression
//;
//lambdaExpression
//	: anonymousFunctionSignature '=>' anonymousFunctionBody
//;
//anonymousMethodExpression
//	: 'delegate' explicitAnonymousFunctionSignature? block
//;
//anonymousFunctionSignature
//	: explicitAnonymousFunctionSignature
//	| implicitAnonymousFunctionSignature
//;
//explicitAnonymousFunctionSignature
//	: '(' explicitAnonymousFunctionParameterList? ')'
//;
//explicitAnonymousFunctionParameterList
//	: explicitAnonymousFunctionParameter
//	| explicitAnonymousFunctionParameterList ',' explicitAnonymousFunctionParameter
//;
//explicitAnonymousFunctionParameter
//	: anonymousFunctionParameterModifier? type Identifier
//;
//anonymousFunctionParameterModifier
//	: 'ref'
//	| 'out'
//;
//implicitAnonymousFunctionSignature
//	: '(' implicitAnonymousFunctionParameterList? ')'
//	| implicitAnonymousFunctionParameter
//;
//implicitAnonymousFunctionParameterList
//	: implicitAnonymousFunctionParameter
//	| implicitAnonymousFunctionParameterList ',' implicitAnonymousFunctionParameter
//;
//implicitAnonymousFunctionParameter
//	: Identifier
//;
//anonymousFunctionBody
//	: expression
//	| block
//;
//queryExpression
//	: fromClause queryBody
//;
//fromClause
//	: 'from' type? Identifier 'in' expression
//;
//queryBody
//	: queryBodyClauses? selectOrGroupClause queryContinuation?
//;
//queryBodyClauses
//	: queryBodyClause
//	| queryBodyClauses queryBodyClause
//;
//queryBodyClause
//	: fromClause
//	| letClause
//	| whereClause
//	| joinClause
//	| joinIntoClause
//	| orderbyClause
//;
//letClause
//	: 'let' Identifier '=' expression
//;
//whereClause
//	: 'where' booleanExpression
//;
//joinClause
//	: 'join' type? Identifier 'in' expression 'on' expression 'equals' expression
//;
//joinIntoClause
//	: 'join' type? Identifier 'in' expression 'on' expression 'equals' expression 'into' Identifier
//;
//orderbyClause
//	: 'orderby' orderings
//;
//orderings
//	: ordering
//	| orderings ',' ordering
//;
//ordering
//	: expression orderingDirection?
//;
//orderingDirection
//	: 'ascending'
//	| 'descending'
//;
//selectOrGroupClause
//	: selectClause
//	| groupClause
//;
//selectClause
//	: 'select' expression
//;
//groupClause
//	: 'group' expression 'by' expression
//;
//queryContinuation
//	: 'into' Identifier queryBody
//;
//assignment
//	: unaryExpression assignmentOperator expression
//;
//assignmentOperator
//	: '='
//	| '+='
//	| '-='
//	| '*='
//	| '/='
//	| '%='
//	| '&='
//	| '|='
//	| '^='
//	| '<<='
//	| '>>='
//;
//expression
//	: nonAssignmentExpression
//	| assignment
//;
//nonAssignmentExpression
//	: conditionalExpression
//	| lambdaExpression
//	| queryExpression
//;
//constantExpression
//	: expression
//;
//booleanExpression
//	: expression
//;
//statement
//	: labeledStatement
//	| declarationStatement
//	| embeddedStatement
//;
//embeddedStatement
//	: block
//	| emptyStatement
//	| expressionStatement
//	| selectionStatement
//	| iterationStatement
//	| jumpStatement
//	| tryStatement
//	| checkedStatement
//	| uncheckedStatement
//	| lockStatement
//	| usingStatement
//	| yieldStatement
//	| unsafeStatement
//	| fixedStatement
//;
//block
//	: '{' statementList? '}'
//;
//statementList
//	: statement
//	| statementList statement
//;
//emptyStatement
//	: ';'
//;
//labeledStatement
//	: Identifier ':' statement
//;
//declarationStatement
//	: localVariableDeclaration ';'
//	| localConstantDeclaration ';'
//;
//localVariableDeclaration
//	: localVariableType localVariableDeclarators
//;
//localVariableType
//	: type
//	| 'var'
//;
//localVariableDeclarators
//	: localVariableDeclarator
//	| localVariableDeclarators ',' localVariableDeclarator
//;
//localVariableDeclarator
//	: Identifier
//	| Identifier '=' localVariableInitializer
//;
//localVariableInitializer
//	: expression
//	| arrayInitializer
//;
//localConstantDeclaration
//	: 'const' type constantDeclarators
//;
//expressionStatement
//	: statementExpression ';'
//;
//statementExpression
//	: invocationExpression
//	| objectCreationExpression
//	| assignment
//	| postIncrementExpression
//	| postDecrementExpression
//	| preIncrementExpression
//	| preDecrementExpression
//;
//selectionStatement
//	: ifStatement
//	| switchStatement
//;
//ifStatement
//	: 'if' '(' booleanExpression ')' embeddedStatement
//	| 'if' '(' booleanExpression ')' embeddedStatement 'else' embeddedStatement
//;
//switchStatement
//	: 'switch' '(' expression ')' switchBlock
//;
//switchBlock
//	: '{' switchSections? '}'
//;
//switchSections
//	: switchSection
//	| switchSections switchSection
//;
//switchSection
//	: switchLabels statementList
//;
//switchLabels
//	: switchLabel
//	| switchLabels switchLabel
//;
//switchLabel
//	: 'case' constantExpression ':'
//	| 'default' ':'
//;
//iterationStatement
//	: whileStatement
//	| doStatement
//	| forStatement
//	| foreachStatement
//;
//whileStatement
//	: 'while' '(' booleanExpression ')' embeddedStatement
//;
//doStatement
//	: 'do' embeddedStatement 'while' '(' booleanExpression ')' ';'
//;
//forStatement
//	: 'for' '(' forInitializer? ';' forCondition? ';' forIterator? ')' embeddedStatement
//;
//forInitializer
//	: localVariableDeclaration
//	| statementExpressionList
//;
//forCondition
//	: booleanExpression
//;
//forIterator
//	: statementExpressionList
//;
//statementExpressionList
//	: statementExpression
//	| statementExpressionList ',' statementExpression
//;
//foreachStatement
//	: 'foreach' '(' localVariableType Identifier 'in' expression ')' embeddedStatement
//;
//jumpStatement
//	: breakStatement
//	| continueStatement
//	| gotoStatement
//	| returnStatement
//	| throwStatement
//;
//breakStatement
//	: 'break' ';'
//;
//continueStatement
//	: 'continue' ';'
//;
//gotoStatement
//	: 'goto' Identifier ';'
//	| 'goto' 'case' constantExpression ';'
//	| 'goto' 'default' ';'
//;
//returnStatement
//	: 'return' expression? ';'
//;
//throwStatement
//	: 'throw' expression? ';'
//;
//tryStatement
//	: 'try' block catchClauses
//	| 'try' block finallyClause
//	| 'try' block catchClauses finallyClause
//;
//catchClauses
//	: specificCatchClauses generalCatchClause?
//	| specificCatchClauses? generalCatchClause
//;
//specificCatchClauses
//	: specificCatchClause
//	| specificCatchClauses specificCatchClause
//;
//specificCatchClause
//	: 'catch' '(' classType Identifier? ')' block
//;
//generalCatchClause
//	: 'catch' block
//;
//finallyClause
//	: 'finally' block
//;
//checkedStatement
//	: 'checked' block
//;
//uncheckedStatement
//	: 'unchecked' block
//;
//lockStatement
//	: 'lock' '(' expression ')' embeddedStatement
//;
//usingStatement
//	: 'using' '(' resourceAcquisition ')' embeddedStatement
//;
//resourceAcquisition
//	: localVariableDeclaration
//	| expression
//;
//yieldStatement
//	: 'yield' 'return' expression ';'
//	| 'yield' 'break' ';'
//;
//compilationUnit
//	: externAliasDirectives? usingDirectives? globalAttributes? Eof
//	| namespaceMemberDeclarations? Eof
//;
//namespaceDeclaration
//	: 'namespace' qualifiedIdentifier namespaceBody ';'?
//;
//qualifiedIdentifier
//	: Identifier
//	| qualifiedIdentifier '.' Identifier
//;
//namespaceBody
//	: '{' externAliasDirectives? usingDirectives? namespaceMemberDeclarations? '}'
//;
//externAliasDirectives
//	: externAliasDirective
//	| externAliasDirectives externAliasDirective
//;
//externAliasDirective
//	: 'extern' 'alias' Identifier ';'
//;
//usingDirectives
//	: usingDirective
//	| usingDirectives usingDirective
//;
//usingDirective
//	: usingAliasDirective
//	| usingNamespaceDirective
//;
//usingAliasDirective
//	: 'using' Identifier '=' namespaceOrTypeName ';'
//;
//usingNamespaceDirective
//	: 'using' namespaceName ';'
//;
//namespaceMemberDeclarations
//	: namespaceMemberDeclaration
//	| namespaceMemberDeclarations namespaceMemberDeclaration
//;
//namespaceMemberDeclaration
//	: namespaceDeclaration
//	| typeDeclaration
//;
//typeDeclaration
//	: classDeclaration
//	| structDeclaration
//	| interfaceDeclaration
//	| enumDeclaration
//	| delegateDeclaration
//;
//qualifiedAliasMember
//	: Identifier '::' Identifier typeArgumentList?
//;
//classDeclaration
//	: attributes? classModifiers? 'partial'? 'class' Identifier typeParameterList?
//	| classBase? typeParameterConstraintsClauses? classBody ';'?
//;
//classModifiers
//	: classModifier
//	| classModifiers classModifier
//;
//classModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'abstract'
//	| 'sealed'
//	| 'static'
//	| 'unsafe'
//;
//typeParameterList
//	: '<' typeParameters '>'
//;
//typeParameters
//	: attributes? typeParameter
//	| typeParameters ',' attributes? typeParameter
//;
//typeParameter
//	: Identifier
//;
//classBase
//	: ':' classType
//	| ':' interfaceTypeList
//	| ':' classType ',' interfaceTypeList
//;
//interfaceTypeList
//	: interfaceType
//	| interfaceTypeList ',' interfaceType
//;
//typeParameterConstraintsClauses
//	: typeParameterConstraintsClause
//	| typeParameterConstraintsClauses typeParameterConstraintsClause
//;
//typeParameterConstraintsClause
//	: 'where' typeParameter ':' typeParameterConstraints
//;
//typeParameterConstraints
//	: primaryConstraint
//	| secondaryConstraints
//	| constructorConstraint
//	| primaryConstraint ',' secondaryConstraints
//	| primaryConstraint ',' constructorConstraint
//	| secondaryConstraints ',' constructorConstraint
//	| primaryConstraint ',' secondaryConstraints ',' constructorConstraint
//;
//primaryConstraint
//	: classType
//	| 'class'
//	| 'struct'
//;
//secondaryConstraints
//	: interfaceType
//	| typeParameter
//	| secondaryConstraints ',' interfaceType
//	| secondaryConstraints ',' typeParameter
//;
//constructorConstraint
//	: 'new' '(' ')'
//;
//classBody
//	: '{' classMemberDeclarations? '}'
//;
//classMemberDeclarations
//	: classMemberDeclaration
//	| classMemberDeclarations classMemberDeclaration
//;
//classMemberDeclaration
//	: constantDeclaration
//	| fieldDeclaration
//	| methodDeclaration
//	| propertyDeclaration
//	| eventDeclaration
//	| indexerDeclaration
//	| operatorDeclaration
//	| constructorDeclaration
//	| destructorDeclaration
//	| staticConstructorDeclaration
//	| typeDeclaration
//;
//constantDeclaration
//	: attributes? constantModifiers? 'const' type constantDeclarators ';'
//;
//constantModifiers
//	: constantModifier
//	| constantModifiers constantModifier
//;
//constantModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//;
//constantDeclarators
//	: constantDeclarator
//	| constantDeclarators ',' constantDeclarator
//;
//constantDeclarator
//	: Identifier '=' constantExpression
//;
//fieldDeclaration
//	: attributes? fieldModifiers? type variableDeclarators ';'
//;
//fieldModifiers
//	: fieldModifier
//	| fieldModifiers fieldModifier
//;
//fieldModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'static'
//	| 'readonly'
//	| 'volatile'
//	| 'unsafe'
//;
//variableDeclarators
//	: variableDeclarator
//	| variableDeclarators ',' variableDeclarator
//;
//variableDeclarator
//	: Identifier
//	| Identifier '=' variableInitializer
//;
//methodDeclaration
//	: methodHeader methodBody
//;
//methodHeader
//	: attributes? methodModifiers? 'partial'? returnType memberName typeParameterList?
//	| '(' formalParameterList? ')' typeParameterConstraintsClauses?
//;
//methodModifiers
//	: methodModifier
//	| methodModifiers methodModifier
//;
//methodModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'static'
//	| 'virtual'
//	| 'sealed'
//	| 'override'
//	| 'abstract'
//	| 'extern'
//	| 'unsafe'
//;
//returnType
//	: type
//	| 'void'
//;
//memberName
//	: Identifier
//	| interfaceType '.' Identifier
//;
//methodBody
//	: block
//	| ';'
//;
//formalParameterList
//	: fixedParameters
//	| fixedParameters ',' parameterArray
//	| parameterArray
//;
//fixedParameters
//	: fixedParameter
//	| fixedParameters ',' fixedParameter
//;
//fixedParameter
//	: attributes? parameterModifier? type Identifier defaultArgument?
//;
//defaultArgument
//	: '=' expression
//;
//parameterModifier
//	: 'ref'
//	| 'out'
//	| 'this'
//;
//parameterArray
//	: attributes? 'params' arrayType Identifier
//;
//propertyDeclaration
//	: attributes? propertyModifiers? type memberName '{' accessorDeclarations '}'
//;
//propertyModifiers
//	: propertyModifier
//	| propertyModifiers propertyModifier
//;
//propertyModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'static'
//	| 'virtual'
//	| 'sealed'
//	| 'override'
//	| 'abstract'
//	| 'extern'
//	| 'unsafe'
//;
//accessorDeclarations
//	: getAccessorDeclaration setAccessorDeclaration?
//	| setAccessorDeclaration getAccessorDeclaration?
//;
//getAccessorDeclaration
//	: attributes? accessorModifier? 'get' accessorBody
//;
//setAccessorDeclaration
//	: attributes? accessorModifier? 'set' accessorBody
//;
//accessorModifier
//	: 'protected'
//	| 'internal'
//	| 'private'
//	| 'protected' 'internal'
//	| 'internal' 'protected'
//;
//accessorBody
//	: block
//	| ';'
//;
//eventDeclaration
//	: attributes? eventModifiers? 'event' type variableDeclarators ';'
//	| attributes? eventModifiers? 'event' type memberName '{' eventAccessorDeclarations '}'
//;
//eventModifiers
//	: eventModifier
//	| eventModifiers eventModifier
//;
//eventModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'static'
//	| 'virtual'
//	| 'sealed'
//	| 'override'
//	| 'abstract'
//	| 'extern'
//	| 'unsafe'
//;
//eventAccessorDeclarations
//	: addAccessorDeclaration removeAccessorDeclaration
//	| removeAccessorDeclaration addAccessorDeclaration
//;
//addAccessorDeclaration
//	: attributes? 'add' block
//;
//removeAccessorDeclaration
//	: attributes? 'remove' block
//;
//indexerDeclaration
//	: attributes? indexerModifiers? indexerDeclarator '{' accessorDeclarations '}'
//;
//indexerModifiers
//	: indexerModifier
//	| indexerModifiers indexerModifier
//;
//indexerModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'virtual'
//	| 'sealed'
//	| 'override'
//	| 'abstract'
//	| 'extern'
//	| 'unsafe'
//;
//indexerDeclarator
//	: type 'this' '[' formalParameterList ']'
//	| type interfaceType '.' 'this' '[' formalParameterList ']'
//;
//operatorDeclaration
//	: attributes? operatorModifiers operatorDeclarator operatorBody
//;
//operatorModifiers
//	: operatorModifier
//	| operatorModifiers operatorModifier
//;
//operatorModifier
//	: 'public'
//	| 'static'
//	| 'extern'
//	| 'unsafe'
//;
//operatorDeclarator
//	: unaryOperatorDeclarator
//	| binaryOperatorDeclarator
//	| conversionOperatorDeclarator
//;
//unaryOperatorDeclarator
//	: type 'operator' overloadableUnaryOperator '(' type Identifier ')'
//;
//overloadableUnaryOperator
//	: '+' | '-' | '!' | '~' | '++' | '--' | 'true' | 'false'
//;
//binaryOperatorDeclarator
//	: type 'operator' overloadableBinaryOperator '(' type Identifier ',' type Identifier ')'
//;
//overloadableBinaryOperator
//	: '+'
//	| '-'
//	| '*'
//	| '/'
//	| '%'
//	| '&'
//	| '|'
//	| '^'
//	| '<<'
//	| '>>'
//	| '=='
//	| '!='
//	| '>'
//	| '<'
//	| '>='
//	| '<='
//;
//conversionOperatorDeclarator
//	: 'implicit' 'operator' type '(' type Identifier ')'
//	| 'explicit' 'operator' type '(' type Identifier ')'
//;
//operatorBody
//	: block
//	| ';'
//;
//constructorDeclaration
//	: attributes? constructorModifiers? constructorDeclarator constructorBody
//;
//constructorModifiers
//	: constructorModifier
//	| constructorModifiers constructorModifier
//;
//constructorModifier
//	: 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'extern'
//	| 'unsafe'
//;
//constructorDeclarator
//	: Identifier '(' formalParameterList? ')' constructorInitializer?
//;
//constructorInitializer
//	: ':' 'base' '(' argumentList? ')'
//	| ':' 'this' '(' argumentList? ')'
//;
//constructorBody
//	: block
//	| ';'
//;
//staticConstructorDeclaration
//	: attributes? staticConstructorModifiers Identifier '(' ')' staticConstructorBody
//;
//staticConstructorModifiers
//	: 'extern'? 'unsafe'? 'static'
//	| 'unsafe'? 'extern'? 'static'
//	| 'extern'? 'static' 'unsafe'?
//	| 'unsafe'? 'static' 'extern'?
//	| 'static' 'extern'? 'unsafe'?
//	| 'static' 'unsafe'? 'extern'?
//;
//staticConstructorBody
//	: block
//	| ';'
//;
//destructorDeclaration
//	: attributes? 'extern'? '~' Identifier '(' ')' destructorBody
//	| attributes? 'extern'? 'unsafe'? '~' Identifier '(' ')' destructorBody
//	| attributes? 'unsafe'? 'extern'? '~' Identifier '(' ')' destructorBody
//;
//destructorBody
//	: block
//	| ';'
//;
//structDeclaration
//	: attributes? structModifiers? 'partial'? 'struct' Identifier typeParameterList?
//	| structInterfaces? typeParameterConstraintsClauses? structBody ';'?
//;
//structModifiers
//	: structModifier
//	| structModifiers structModifier
//;
//structModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'unsafe'
//;
//structInterfaces
//	: ':' interfaceTypeList
//;
//structBody
//	: '{' structMemberDeclarations? '}'
//;
//structMemberDeclarations
//	: structMemberDeclaration
//	| structMemberDeclarations structMemberDeclaration
//;
//structMemberDeclaration
//	: constantDeclaration
//	| fieldDeclaration
//	| methodDeclaration
//	| propertyDeclaration
//	| eventDeclaration
//	| indexerDeclaration
//	| operatorDeclaration
//	| constructorDeclaration
//	| staticConstructorDeclaration
//	| typeDeclaration
//	| fixedSizeBufferDeclaration
//;
//arrayType
//	: nonArrayType rankSpecifiers
//;
//nonArrayType
//	: type
//;
//arrayInitializer
//	: '{' variableInitializerList? '}'
//	| '{' variableInitializerList ',' '}'
//;
//variableInitializerList
//	: variableInitializer
//	| variableInitializerList ',' variableInitializer
//;
//variableInitializer
//	: expression
//	| arrayInitializer
//;
//interfaceDeclaration
//	: attributes? interfaceModifiers? 'partial'? 'interface'
//	| Identifier variantTypeParameterList? interfaceBase?
//	| typeParameterConstraintsClauses? interfaceBody ';'?
//;
//interfaceModifiers
//	: interfaceModifier
//	| interfaceModifiers interfaceModifier
//;
//interfaceModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'unsafe'
//;
//variantTypeParameterList
//	: '<' variantTypeParameters '>'
//;
//variantTypeParameters
//	: attributes? varianceAnnotation? typeParameter
//	| variantTypeParameters ',' attributes? varianceAnnotation? typeParameter
//;
//varianceAnnotation
//	: 'in'
//	| 'out'
//;
//interfaceBase
//	: ':' interfaceTypeList
//;
//interfaceBody
//	: '{' interfaceMemberDeclarations? '}'
//;
//interfaceMemberDeclarations
//	: interfaceMemberDeclaration
//	| interfaceMemberDeclarations interfaceMemberDeclaration
//;
//interfaceMemberDeclaration
//	: interfaceMethodDeclaration
//	| interfacePropertyDeclaration
//	| interfaceEventDeclaration
//	| interfaceIndexerDeclaration
//;
//interfaceMethodDeclaration
//	: attributes? 'new'? returnType Identifier typeParameterList
//	| '(' formalParameterList? ')' typeParameterConstraintsClauses? ';'
//;
//interfacePropertyDeclaration
//	: attributes? 'new'? type Identifier '{' interfaceAccessors '}'
//;
//interfaceAccessors
//	: attributes? 'get' ';'
//	| attributes? 'set' ';'
//	| attributes? 'get' ';' attributes? 'set' ';'
//	| attributes? 'set' ';' attributes? 'get' ';'
//;
//interfaceEventDeclaration
//	: attributes? 'new'? 'event' type Identifier ';'
//;
//interfaceIndexerDeclaration
//	: attributes? 'new'? type 'this' '[' formalParameterList ']' '{' interfaceAccessors '}'
//;
//enumDeclaration
//	: attributes? enumModifiers? 'enum' Identifier enumBase? enumBody ';'?
//;
//enumBase
//	: ':' integralType
//;
//enumBody
//	: '{' enumMemberDeclarations? '}'
//	| '{' enumMemberDeclarations ',' '}'
//;
//enumModifiers
//	: enumModifier
//	| enumModifiers enumModifier
//;
//enumModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//;
//enumMemberDeclarations
//	: enumMemberDeclaration
//	| enumMemberDeclarations ',' enumMemberDeclaration
//;
//enumMemberDeclaration
//	: attributes? Identifier
//	| attributes? Identifier '=' constantExpression
//;
//delegateDeclaration
//	: attributes? delegateModifiers? 'delegate' returnType
//	| Identifier variantTypeParameterList?
//	| '(' formalParameterList? ')' typeParameterConstraintsClauses? ';'
//;
//delegateModifiers
//	: delegateModifier
//	| delegateModifiers delegateModifier
//;
//delegateModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'unsafe'
//;
//globalAttributes
//	: globalAttributeSections
//;
//globalAttributeSections
//	: globalAttributeSection
//	| globalAttributeSections globalAttributeSection
//;
//globalAttributeSection
//	: '[' globalAttributeTargetSpecifier attributeList ']'
//	| '[' globalAttributeTargetSpecifier attributeList ',' ']'
//;
//globalAttributeTargetSpecifier
//	: globalAttributeTarget ':'
//;
//globalAttributeTarget
//	: 'assembly'
//	| 'module'
//;
//attributes
//	: attributeSections
//;
//attributeSections
//	: attributeSection
//	| attributeSections attributeSection
//;
//attributeSection
//	: '[' attributeTargetSpecifier? attributeList ']'
//	| '[' attributeTargetSpecifier? attributeList ',' ']'
//;
//attributeTargetSpecifier
//	: attributeTarget ':'
//;
//attributeTarget
//	: 'field'
//	| 'event'
//	| 'method'
//	| 'param'
//	| 'property'
//	| 'return'
//	| 'type'
//;
//attributeList
//	: attribute
//	| attributeList ',' attribute
//;
//attribute
//	: attributeName attributeArguments?
//;
//attributeName
//	: typeName
//;
//attributeArguments
//	: '(' positionalArgumentList? ')'
//	| '(' positionalArgumentList ',' namedArgumentList ')'
//	| '(' namedArgumentList ')'
//;
//positionalArgumentList
//	: positionalArgument
//	| positionalArgumentList ',' positionalArgument
//;
//positionalArgument
//	: argumentName? attributeArgumentExpression
//;
//namedArgumentList
//	: namedArgument
//	| namedArgumentList ',' namedArgument
//;
//namedArgument
//	: Identifier '=' attributeArgumentExpression
//;
//attributeArgumentExpression
//	: expression
//;
//unsafeStatement
//	: 'unsafe' block
//;
//pointerType
//	: unmanagedType '*'
//	| 'void' '*'
//;
//unmanagedType
//	: type
//;
//pointerIndirectionExpression
//	: '*' unaryExpression
//;
//pointerMemberAccess
//	: primaryExpression '->' Identifier typeArgumentList?
//;
//pointerElementAccess
//	: primaryNoArrayCreationExpression '[' expression ']'
//;
//addressofExpression
//	: '&' unaryExpression
//;
//sizeofExpression
//	: 'sizeof' '(' unmanagedType ')'
//;
//fixedStatement
//	: 'fixed' '(' pointerType fixedPointerDeclarators ')' embeddedStatement
//;
//fixedPointerDeclarators
//	: fixedPointerDeclarator
//	| fixedPointerDeclarators ',' fixedPointerDeclarator
//;
//fixedPointerDeclarator
//	: Identifier '=' fixedPointerInitializer
//;
//fixedPointerInitializer
//	: '&' variableReference
//	| expression
//;
//fixedSizeBufferDeclaration
//	: attributes? fixedSizeBufferModifiers? 'fixed' bufferElementType
//	| fixedSizeBufferDeclarators ';'
//;
//fixedSizeBufferModifiers
//	: fixedSizeBufferModifier
//	| fixedSizeBufferModifier fixedSizeBufferModifiers
//;
//fixedSizeBufferModifier
//	: 'new'
//	| 'public'
//	| 'protected'
//	| 'internal'
//	| 'private'
//	| 'unsafe'
//;
//bufferElementType
//	: type
//;
//fixedSizeBufferDeclarators
//	: fixedSizeBufferDeclarator
//	| fixedSizeBufferDeclarator fixedSizeBufferDeclarators
//;
//fixedSizeBufferDeclarator
//	: Identifier '[' constantExpression ']'
//;
//stackallocInitializer
//	: 'stackalloc' unmanagedType '[' expression ']'
//;
//literal
//	: BooleanLiteral
//	| IntegerLiteral
//	| RealLiteral
//	| CharacterLiteral
//	| StringLiteral
//	| NullLiteral
//;




//fragment
//NewLine
//	: [\u000D\u000A\u0085\u2028\u2029]
//;
//SingleLineComment
//	: '//' InputCharacters?
//;
//fragment
//InputCharacters
//	: ~[\u000D\u000A\u0085\u2028\u2029]+
//;
//DelimitedComment
//	: '/*' DelimitedCommentText? '*'+ '/'
//;
//fragment
//DelimitedCommentText
//	: DelimitedCommentSection+
//;
//fragment
//DelimitedCommentSection
//	: '/'
//	| '*'* ~[/*]
//;
//fragment
//Whitespace
//	: [\u0020\u00A0\u1680\u180E\u2000\u202F\u205F\u3000\u0009\u000B\u000C]+
//;
//fragment
//UnicodeEscapeSequence
//	: '\\u' HexDigit HexDigit HexDigit HexDigit
//	| '\\U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit
//;
//Identifier
//	: IdentifierStartCharacter IdentifierPartCharacter+
//;
//fragment
//IdentifierStartCharacter
//	: LetterCharacter
//	| '_'
//	| '@'
//	| UnicodeEscapeSequence
//;
//fragment
//IdentifierPartCharacter
//	: LetterCharacter
//	| DecimalDigitCharacter
//	| ConnectingCharacter
//	| CombiningCharacter
//	| FormattingCharacter
//	| UnicodeEscapeSequence
//;
//fragment
//LetterCharacter
//	: [\u0041-\u005A\u0061-\u007A\u00AA\u00B5\u00BA\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u02C1\u02C6-\u02D1\u02E0-\u02E4\u02EC\u02EE\u0370-\u0374\u0376-\u0377\u037A-\u037D\u0386\u0388-\u038A\u038C\u038E-\u03A1\u03A3-\u03F5\u03F7-\u0481\u048A-\u0523\u0531-\u0556\u0559\u0561-\u0587\u05D0-\u05EA\u05F0-\u05F2\u0621-\u064A\u066E-\u066F\u0671-\u06D3\u06D5\u06E5-\u06E6\u06EE-\u06EF\u06FA-\u06FC\u06FF\u0710\u0712-\u072F\u074D-\u07A5\u07B1\u07CA-\u07EA\u07F4-\u07F5\u07FA\u0904-\u0939\u093D\u0950\u0958-\u0961\u0971-\u0972\u097B-\u097F\u0985-\u098C\u098F-\u0990\u0993-\u09A8\u09AA-\u09B0\u09B2\u09B6-\u09B9\u09BD\u09CE\u09DC-\u09DD\u09DF-\u09E1\u09F0-\u09F1\u0A05-\u0A0A\u0A0F-\u0A10\u0A13-\u0A28\u0A2A-\u0A30\u0A32-\u0A33\u0A35-\u0A36\u0A38-\u0A39\u0A59-\u0A5C\u0A5E\u0A72-\u0A74\u0A85-\u0A8D\u0A8F-\u0A91\u0A93-\u0AA8\u0AAA-\u0AB0\u0AB2-\u0AB3\u0AB5-\u0AB9\u0ABD\u0AD0\u0AE0-\u0AE1\u0B05-\u0B0C\u0B0F-\u0B10\u0B13-\u0B28\u0B2A-\u0B30\u0B32-\u0B33\u0B35-\u0B39\u0B3D\u0B5C-\u0B5D\u0B5F-\u0B61\u0B71\u0B83\u0B85-\u0B8A\u0B8E-\u0B90\u0B92-\u0B95\u0B99-\u0B9A\u0B9C\u0B9E-\u0B9F\u0BA3-\u0BA4\u0BA8-\u0BAA\u0BAE-\u0BB9\u0BD0\u0C05-\u0C0C\u0C0E-\u0C10\u0C12-\u0C28\u0C2A-\u0C33\u0C35-\u0C39\u0C3D\u0C58-\u0C59\u0C60-\u0C61\u0C85-\u0C8C\u0C8E-\u0C90\u0C92-\u0CA8\u0CAA-\u0CB3\u0CB5-\u0CB9\u0CBD\u0CDE\u0CE0-\u0CE1\u0D05-\u0D0C\u0D0E-\u0D10\u0D12-\u0D28\u0D2A-\u0D39\u0D3D\u0D60-\u0D61\u0D7A-\u0D7F\u0D85-\u0D96\u0D9A-\u0DB1\u0DB3-\u0DBB\u0DBD\u0DC0-\u0DC6\u0E01-\u0E30\u0E32-\u0E33\u0E40-\u0E46\u0E81-\u0E82\u0E84\u0E87-\u0E88\u0E8A\u0E8D\u0E94-\u0E97\u0E99-\u0E9F\u0EA1-\u0EA3\u0EA5\u0EA7\u0EAA-\u0EAB\u0EAD-\u0EB0\u0EB2-\u0EB3\u0EBD\u0EC0-\u0EC4\u0EC6\u0EDC-\u0EDD\u0F00\u0F40-\u0F47\u0F49-\u0F6C\u0F88-\u0F8B\u1000-\u102A\u103F\u1050-\u1055\u105A-\u105D\u1061\u1065-\u1066\u106E-\u1070\u1075-\u1081\u108E\u10A0-\u10C5\u10D0-\u10FA\u10FC\u1100-\u1159\u115F-\u11A2\u11A8-\u11F9\u1200-\u1248\u124A-\u124D\u1250-\u1256\u1258\u125A-\u125D\u1260-\u1288\u128A-\u128D\u1290-\u12B0\u12B2-\u12B5\u12B8-\u12BE\u12C0\u12C2-\u12C5\u12C8-\u12D6\u12D8-\u1310\u1312-\u1315\u1318-\u135A\u1380-\u138F\u13A0-\u13F4\u1401-\u166C\u166F-\u1676\u1681-\u169A\u16A0-\u16EA\u16EE-\u16F0\u1700-\u170C\u170E-\u1711\u1720-\u1731\u1740-\u1751\u1760-\u176C\u176E-\u1770\u1780-\u17B3\u17D7\u17DC\u1820-\u1877\u1880-\u18A8\u18AA\u1900-\u191C\u1950-\u196D\u1970-\u1974\u1980-\u19A9\u19C1-\u19C7\u1A00-\u1A16\u1B05-\u1B33\u1B45-\u1B4B\u1B83-\u1BA0\u1BAE-\u1BAF\u1C00-\u1C23\u1C4D-\u1C4F\u1C5A-\u1C7D\u1D00-\u1DBF\u1E00-\u1F15\u1F18-\u1F1D\u1F20-\u1F45\u1F48-\u1F4D\u1F50-\u1F57\u1F59\u1F5B\u1F5D\u1F5F-\u1F7D\u1F80-\u1FB4\u1FB6-\u1FBC\u1FBE\u1FC2-\u1FC4\u1FC6-\u1FCC\u1FD0-\u1FD3\u1FD6-\u1FDB\u1FE0-\u1FEC\u1FF2-\u1FF4\u1FF6-\u1FFC\u2071\u207F\u2090-\u2094\u2102\u2107\u210A-\u2113\u2115\u2119-\u211D\u2124\u2126\u2128\u212A-\u212D\u212F-\u2139\u213C-\u213F\u2145-\u2149\u214E\u2160-\u2188\u2C00-\u2C2E\u2C30-\u2C5E\u2C60-\u2C6F\u2C71-\u2C7D\u2C80-\u2CE4\u2D00-\u2D25\u2D30-\u2D65\u2D6F\u2D80-\u2D96\u2DA0-\u2DA6\u2DA8-\u2DAE\u2DB0-\u2DB6\u2DB8-\u2DBE\u2DC0-\u2DC6\u2DC8-\u2DCE\u2DD0-\u2DD6\u2DD8-\u2DDE\u2E2F\u3005-\u3007\u3021-\u3029\u3031-\u3035\u3038-\u303C\u3041-\u3096\u309D-\u309F\u30A1-\u30FA\u30FC-\u30FF\u3105-\u312D\u3131-\u318E\u31A0-\u31B7\u31F0-\u31FF\u3400-\u4DB5\u4E00-\u9FC3\uA000-\uA48C\uA500-\uA60C\uA610-\uA61F\uA62A-\uA62B\uA640-\uA65F\uA662-\uA66E\uA67F-\uA697\uA717-\uA71F\uA722-\uA788\uA78B-\uA78C\uA7FB-\uA801\uA803-\uA805\uA807-\uA80A\uA80C-\uA822\uA840-\uA873\uA882-\uA8B3\uA90A-\uA925\uA930-\uA946\uAA00-\uAA28\uAA40-\uAA42\uAA44-\uAA4B\uAC00-\uD7A3\uF900-\uFA2D\uFA30-\uFA6A\uFA70-\uFAD9\uFB00-\uFB06\uFB13-\uFB17\uFB1D\uFB1F-\uFB28\uFB2A-\uFB36\uFB38-\uFB3C\uFB3E\uFB40-\uFB41\uFB43-\uFB44\uFB46-\uFBB1\uFBD3-\uFD3D\uFD50-\uFD8F\uFD92-\uFDC7\uFDF0-\uFDFB\uFE70-\uFE74\uFE76-\uFEFC\uFF21-\uFF3A\uFF41-\uFF5A\uFF66-\uFFBE\uFFC2-\uFFC7\uFFCA-\uFFCF\uFFD2-\uFFD7\uFFDA-\uFFDC]
//;
//fragment
//CombiningCharacter
//	: [\u0300-\u036F\u0483-\u0487\u0591-\u05BD\u05BF\u05C1-\u05C2\u05C4-\u05C5\u05C7\u0610-\u061A\u064B-\u065E\u0670\u06D6-\u06DC\u06DF-\u06E4\u06E7-\u06E8\u06EA-\u06ED\u0711\u0730-\u074A\u07A6-\u07B0\u07EB-\u07F3\u0901-\u0903\u093C\u093E-\u094D\u0951-\u0954\u0962-\u0963\u0981-\u0983\u09BC\u09BE-\u09C4\u09C7-\u09C8\u09CB-\u09CD\u09D7\u09E2-\u09E3\u0A01-\u0A03\u0A3C\u0A3E-\u0A42\u0A47-\u0A48\u0A4B-\u0A4D\u0A51\u0A70-\u0A71\u0A75\u0A81-\u0A83\u0ABC\u0ABE-\u0AC5\u0AC7-\u0AC9\u0ACB-\u0ACD\u0AE2-\u0AE3\u0B01-\u0B03\u0B3C\u0B3E-\u0B44\u0B47-\u0B48\u0B4B-\u0B4D\u0B56-\u0B57\u0B62-\u0B63\u0B82\u0BBE-\u0BC2\u0BC6-\u0BC8\u0BCA-\u0BCD\u0BD7\u0C01-\u0C03\u0C3E-\u0C44\u0C46-\u0C48\u0C4A-\u0C4D\u0C55-\u0C56\u0C62-\u0C63\u0C82-\u0C83\u0CBC\u0CBE-\u0CC4\u0CC6-\u0CC8\u0CCA-\u0CCD\u0CD5-\u0CD6\u0CE2-\u0CE3\u0D02-\u0D03\u0D3E-\u0D44\u0D46-\u0D48\u0D4A-\u0D4D\u0D57\u0D62-\u0D63\u0D82-\u0D83\u0DCA\u0DCF-\u0DD4\u0DD6\u0DD8-\u0DDF\u0DF2-\u0DF3\u0E31\u0E34-\u0E3A\u0E47-\u0E4E\u0EB1\u0EB4-\u0EB9\u0EBB-\u0EBC\u0EC8-\u0ECD\u0F18-\u0F19\u0F35\u0F37\u0F39\u0F3E-\u0F3F\u0F71-\u0F84\u0F86-\u0F87\u0F90-\u0F97\u0F99-\u0FBC\u0FC6\u102B-\u103E\u1056-\u1059\u105E-\u1060\u1062-\u1064\u1067-\u106D\u1071-\u1074\u1082-\u108D\u108F\u135F\u1712-\u1714\u1732-\u1734\u1752-\u1753\u1772-\u1773\u17B6-\u17D3\u17DD\u180B-\u180D\u18A9\u1920-\u192B\u1930-\u193B\u19B0-\u19C0\u19C8-\u19C9\u1A17-\u1A1B\u1B00-\u1B04\u1B34-\u1B44\u1B6B-\u1B73\u1B80-\u1B82\u1BA1-\u1BAA\u1C24-\u1C37\u1DC0-\u1DE6\u1DFE-\u1DFF\u20D0-\u20DC\u20E1\u20E5-\u20F0\u2DE0-\u2DFF\u302A-\u302F\u3099-\u309A\uA66F\uA67C-\uA67D\uA802\uA806\uA80B\uA823-\uA827\uA880-\uA881\uA8B4-\uA8C4\uA926-\uA92D\uA947-\uA953\uAA29-\uAA36\uAA43\uAA4C-\uAA4D\uFB1E\uFE00-\uFE0F\uFE20-\uFE26]
//;
//fragment
//DecimalDigitCharacter
//	: [\u0030-\u0039\u0660-\u0669\u06F0-\u06F9\u07C0-\u07C9\u0966-\u096F\u09E6-\u09EF\u0A66-\u0A6F\u0AE6-\u0AEF\u0B66-\u0B6F\u0BE6-\u0BEF\u0C66-\u0C6F\u0CE6-\u0CEF\u0D66-\u0D6F\u0E50-\u0E59\u0ED0-\u0ED9\u0F20-\u0F29\u1040-\u1049\u1090-\u1099\u17E0-\u17E9\u1810-\u1819\u1946-\u194F\u19D0-\u19D9\u1B50-\u1B59\u1BB0-\u1BB9\u1C40-\u1C49\u1C50-\u1C59\uA620-\uA629\uA8D0-\uA8D9\uA900-\uA909\uAA50-\uAA59\uFF10-\uFF19]
//;
//fragment
//ConnectingCharacter
//	: [\u005F\u203F-\u2040\u2054\uFE33-\uFE34\uFE4D-\uFE4F\uFF3F]
//;
//fragment
//FormattingCharacter
//	: [\u0600-\u0603\u06DD\u070F\u17B4-\u17B5\u200B-\u200F\u202A-\u202E\u2060-\u2064\u206A-\u206F\uFEFF\uFFF9-\uFFFB]
//;
//BooleanLiteral
//	: 'true'
//	| 'false'
//;
//IntegerLiteral
//	: DecimalIntegerLiteral
//	| HexadecimalIntegerLiteral
//;
//fragment
//DecimalIntegerLiteral
//	: DecimalDigits IntegerTypeSuffix?
//;
//fragment
//DecimalDigits
//	: DecimalDigit+
//;
//fragment
//DecimalDigit
//	: [0-9]
//;
//fragment
//IntegerTypeSuffix
//	: 'U' | 'u' | 'L' | 'l' | 'UL' | 'Ul' | 'uL' | 'ul' | 'LU' | 'Lu' | 'lU' | 'lu'
//;
//fragment
//HexadecimalIntegerLiteral
//	: '0x' HexDigits IntegerTypeSuffix?
//	| '0X' HexDigits IntegerTypeSuffix?
//;
//fragment
//HexDigits
//	: HexDigit+
//;
//fragment
//HexDigit
//	: [0-9a-fA-F]
//;
//RealLiteral
//	: DecimalDigits '.' DecimalDigits ExponentPart? RealTypeSuffix?
//	| '.' DecimalDigits ExponentPart? RealTypeSuffix?
//	| DecimalDigits ExponentPart RealTypeSuffix?
//	| DecimalDigits RealTypeSuffix
//;
//fragment
//ExponentPart
//	: 'e' Sign? DecimalDigits
//	| 'E' Sign? DecimalDigits
//;
//fragment
//Sign
//	: '+' | '-'
//;
//fragment
//RealTypeSuffix
//	: 'F' | 'f' | 'D' | 'd' | 'M' | 'm'
//;
//CharacterLiteral
//	: '\'' Character '\''
//;
//fragment
//Character
//	: SingleCharacter
//	| SimpleEscapeSequence
//	| HexadecimalEscapeSequence
//	| UnicodeEscapeSequence
//;
//fragment
//SingleCharacter
//	: ~[\u0027\u005C\u000D\u000A\u0085\u2028\u2029]
//;
//fragment
//SimpleEscapeSequence
//	: '\'' | '\"' | '\\' | '\0' | '\a' | '\b' | '\f' | '\n' | '\r' | '\t' | '\v'
//;
//fragment
//HexadecimalEscapeSequence
//	: '\x' HexDigit HexDigit? HexDigit? HexDigit?
//;
//StringLiteral
//	: RegularStringLiteral
//	| VerbatimStringLiteral
//;
//fragment
//RegularStringLiteral
//	: '"' RegularStringLiteralCharacters? '"'
//;
//fragment
//RegularStringLiteralCharacters
//	: RegularStringLiteralCharacter+
//;
//fragment
//RegularStringLiteralCharacter
//	: SingleRegularStringLiteralCharacter
//	| SimpleEscapeSequence
//	| HexadecimalEscapeSequence
//	| UnicodeEscapeSequence
//;
//fragment
//SingleRegularStringLiteralCharacter
//	: ~[\u0022\u005C\u000D\u000A\u0085\u2028\u2029]
//;
//fragment
//VerbatimStringLiteral
//	: '@"' VerbatimStringLiteralCharacters? '"'
//;
//fragment
//VerbatimStringLiteralCharacters
//	: VerbatimStringLiteralCharacter+
//;
//fragment
//VerbatimStringLiteralCharacter
//	: SingleVerbatimStringLiteralCharacter
//	| QuoteEscapeSequence
//;
//fragment
//SingleVerbatimStringLiteralCharacter
//	: ~['"']
//;
//fragment
//QuoteEscapeSequence
//	: '""'
//;
//NullLiteral
//	: 'null'
//;
//OperatorOrPunctuator
//	: '{'		'}'		'['		']'		'('		')'		'.'		','		':'		';'
//	| '+'		'-'		'*'		'/'		'%'		'&'		'|'		'^'		'!'		'~'
//	| '='		'<'		'>'		'?'		'??'	'::'	'++'	'--'	'&&'	'||'
//	| '>'		'=='	'!='	'<='	'>='	'+='	'='		'*='	'/='	'%='
//	| '&='		'|='	'^='	'<<'	'<<='	'=>'
//;
//fragment
//PpExpression
//	: Whitespace? PpOrExpression Whitespace?
//;
//fragment
//PpOrExpression
//	: PpAndExpression (Whitespace? '||' Whitespace? PpAndExpression)*
//;
//fragment
//PpAndExpression
//	: PpEqualityExpression (Whitespace? '&&' Whitespace? PpEqualityExpression)*
//;
//fragment
//PpEqualityExpression
//	: PpUnaryExpression (Whitespace? ('==' | '!=') Whitespace? PpUnaryExpression)*
//;
//fragment
//PpUnaryExpression
//	: PpPrimaryExpression
//	| '!' Whitespace? PpUnaryExpression
//;
//fragment
//PpPrimaryExpression
//	: 'true'
//	| 'false'
//	| Identifier
//	| '(' Whitespace? PpExpression Whitespace? ')'
//;
//PpDeclaration
//	: (Whitespace? '#' Whitespace? 'define' Whitespace Identifier PpNewLine
//	| Whitespace? '#' Whitespace? 'undef' Whitespace Identifier PpNewLine)
//    -> channel(HIDDEN)
//;
//fragment
//PpNewLine
//	: Whitespace? SingleLineComment? NewLine
//    -> channel(HIDDEN)
//;
//PpIfSection
//	: Whitespace? '#' Whitespace? 'if' Whitespace PpExpression PpNewLine // ConditionalSection?
//    -> channel(HIDDEN)
//;
//PpElifSection
//	: Whitespace? '#' Whitespace? 'elif' Whitespace PpExpression PpNewLine // ConditionalSection?
//    -> channel(HIDDEN)
//;
//PpElseSection
//	: Whitespace? '#' Whitespace? 'else' PpNewLine // ConditionalSection?
//    -> channel(HIDDEN)
//;
//PpEndif
//	: Whitespace? '#' Whitespace? 'endif' PpNewLine
//    -> channel(HIDDEN)
//;
//PpDiagnostic
//	: (Whitespace? '#' Whitespace? 'error' PpMessage
//	| Whitespace? '#' Whitespace? 'warning' PpMessage)
//    -> channel(HIDDEN)
//;
//fragment
//PpMessage
//	: NewLine
//	| Whitespace InputCharacters? NewLine
//;
//PpStartRegion
//	: Whitespace? '#' Whitespace? 'region' PpMessage
//    -> channel(HIDDEN)
//;
//PpEndRegion
//	: Whitespace? '#' Whitespace? 'endregion' PpMessage
//    -> channel(HIDDEN)
//;
//PpLine
//	: Whitespace? '#' Whitespace? 'line' Whitespace LineIndicator PpNewLine
//    -> channel(HIDDEN)
//;
//fragment
//LineIndicator
//	: DecimalDigits Whitespace FileName
//	| DecimalDigits
//	| 'default'
//	| 'hidden'
//;
//fragment
//FileName
//	: '"' ~["]+ '"'
//;
//PpPragma
//	: Whitespace? '#' Whitespace? 'pragma' Whitespace PragmaBody PpNewLine
//    -> channel(HIDDEN)
//;
//fragment
//PragmaBody
//	: PragmaWarningBody
//;
//fragment
//PragmaWarningBody
//	: 'warning' Whitespace WarningAction
//	| 'warning' Whitespace WarningAction Whitespace WarningList
//;
//fragment
//WarningAction
//	: 'disable'
//	| 'restore'
//;
//fragment
//WarningList
//	: DecimalDigits (Whitespace? ',' Whitespace? DecimalDigits)*
//;
