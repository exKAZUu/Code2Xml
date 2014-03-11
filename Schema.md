# Syntax Tree Structure

## How It Works

For example, ```CSharpProcessorUsingAntlr3``` class generates the two following xml files corresponding to ```class K {}``` and ```class K { void m() {} }```.

    <compilation_unit id="0">
      .. snip ..
              <class_declaration id="50">
      .. snip ..
                <class_body id="621">
                  <TOKENS id="char_literal667">
                    <WS hidden=" " startline="1" startpos="7" endline="1" endpos="8" />
                    <TOKEN startline="1" startpos="8" endline="1" endpos="9">{</TOKEN>
                  </TOKENS>
                  <TOKENS id="char_literal669">
                    <WS hidden=" " startline="1" startpos="9" endline="1" endpos="10" />
                    <TOKEN startline="1" startpos="10" endline="1" endpos="11">}</TOKEN>
                  </TOKENS>
                </class_body>
              </class_declaration>
            </type_declaration>
      .. snip ..
    </compilation_unit>

and

    <compilation_unit id="0">
      .. snip ..
              <class_declaration id="50">
      .. snip ..
                <class_body id="621">
                  <TOKENS id="char_literal667">
                    <WS hidden=" " startline="1" startpos="7" endline="1" endpos="8" />
                    <TOKEN startline="1" startpos="8" endline="1" endpos="9">{</TOKEN>
                  </TOKENS>
                  <class_member_declarations id="668">
                    <class_member_declaration id="670">
                      <method_declaration id="673">
                        <method_header id="707">
      .. snip ..
                        </method_header>
                        <method_body id="708">
      .. snip ..
                        </method_body>
                      </method_declaration>
                    </class_member_declaration>
                  </class_member_declarations>
                  <TOKENS id="char_literal669">
                    <WS hidden=" " startline="1" startpos="21" endline="1" endpos="22" />
                    <TOKEN startline="1" startpos="22" endline="1" endpos="23">}</TOKEN>
                  </TOKENS>
                </class_body>
              </class_declaration>
            </type_declaration>
      .. snip ..
    </compilation_unit>

The ```class_body``` element in the first xml contains only two tokens of ```{``` and ```}```,
in contrast, one in the second xml contains also the ```class_member_declarations``` element corresponding to ```void m() {}```.
This difference is caused by the ANTLR EBNF grammar ([cs.g](https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/ANTLRv3/Processors/CSharp/cs.g "cs.g")) that has the following parsing rule.

    class_body: '{' class_member_declarations? '}' ;

This rule indicates that the ```class_body``` elements can have one or no ```class_member_declarations``` element.

## What Is ID Attribute

As you can see, each non-terminal node, whose name starts a lower letter, has an ```id``` attribute.
The ```id``` value identifies the location where the corresponding node appears in reft sides of the EBNF rules.
For example, the ```id``` value indicates that a ```multiplicative_expression``` element corresponds to the first or second ```multiplicative_expression``` rules in the ```additive_expression``` rule.

    additive_expression: multiplicative_expression ( ('+'|'-') multiplicative_expression )* ;

Assume that unique integers as ```id``` values are annotated in the rule as follows.

    additive_expression:
      multiplicative_expression<id: 1> ( ('+'<id: 2> | '-'<id: 3>) multiplicative_expression<id: 4> )* ;
    
Then, one possible xml may be as follows.

    <additive_expression>
      <multiplicative_expression id="1">
        .. snip ..
      </multiplicative_expression>
      <TOKENS>
        <TOKEN id="2">+</TOKEN>
      </TOKENS>
      <multiplicative_expression id="4">
        .. snip ..
      </multiplicative_expression>
      <TOKENS>
        <TOKEN id="3">-</TOKEN>
      </TOKENS>
      <multiplicative_expression id="4">
        .. snip ..
      </multiplicative_expression>
    </additive_expression>

As another example, the ```id``` values can also identify the locatoin of the corresponding non-terminal node.

    bracket_expression: '[' expression_list? ']' ;
    element_initializer: non_assignment_expression  | '{' expression_list '}' ;

Assume that unique integers as ```id``` values are annotated in the rule as follows.

    bracket_expression: '['<id: 5> expression_list<id: 6>? ']'<id: 7> ;
    element_initializer:
      non_assignment_expression<id: 8> | '{'<id: 9> expression_list<id: 10> '}'<id: 11> ;
