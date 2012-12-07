<compilationUnit>
  <packageDeclaration>
    <PACKAGE startline="1" startpos="0">package</PACKAGE>
    <qualifiedName>
      <IDENTIFIER startline="1" startpos="8">numericLiterals</IDENTIFIER>
    </qualifiedName>
    <SEMI startline="1" startpos="23">;</SEMI>
  </packageDeclaration>
  <typeDeclaration>
    <classOrInterfaceDeclaration>
      <classDeclaration>
        <normalClassDeclaration>
          <modifiers>
            <PUBLIC startline="2" startpos="0">public</PUBLIC>
          </modifiers>
          <CLASS startline="2" startpos="7">class</CLASS>
          <IDENTIFIER startline="2" startpos="13">State</IDENTIFIER>
          <classBody>
            <LBRACE startline="2" startpos="19">{</LBRACE>
            <classBodyDeclaration>
              <memberDecl>
                <fieldDeclaration>
                  <modifiers>
                    <PRIVATE startline="3" startpos="1">private</PRIVATE>
                  </modifiers>
                  <type>
                    <primitiveType>
                      <TOKEN startline="3" startpos="9">int</TOKEN>
                    </primitiveType>
                  </type>
                  <variableDeclarator>
                    <IDENTIFIER startline="3" startpos="13">address</IDENTIFIER>
                    <EQ startline="3" startpos="21">=</EQ>
                    <variableInitializer>
                      <expression>
                        <conditionalExpression>
                          <conditionalOrExpression>
                            <conditionalAndExpression>
                              <inclusiveOrExpression>
                                <exclusiveOrExpression>
                                  <andExpression>
                                    <equalityExpression>
                                      <instanceOfExpression>
                                        <relationalExpression>
                                          <shiftExpression>
                                            <additiveExpression>
                                              <multiplicativeExpression>
                                                <unaryExpression>
                                                  <unaryExpressionNotPlusMinus>
                                                    <primary>
                                                      <literal>
                                                        <intLiteral>
                                                          <INTLITERAL startline="3" startpos="23">0</INTLITERAL>
                                                        </intLiteral>
                                                      </literal>
                                                    </primary>
                                                  </unaryExpressionNotPlusMinus>
                                                </unaryExpression>
                                              </multiplicativeExpression>
                                            </additiveExpression>
                                          </shiftExpression>
                                        </relationalExpression>
                                      </instanceOfExpression>
                                    </equalityExpression>
                                  </andExpression>
                                </exclusiveOrExpression>
                              </inclusiveOrExpression>
                            </conditionalAndExpression>
                          </conditionalOrExpression>
                        </conditionalExpression>
                      </expression>
                    </variableInitializer>
                  </variableDeclarator>
                  <SEMI startline="3" startpos="24">;</SEMI>
                </fieldDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="5" startpos="1">public</PUBLIC>
                  </modifiers>
                  <type>
                    <classOrInterfaceType>
                      <IDENTIFIER startline="5" startpos="8">State</IDENTIFIER>
                    </classOrInterfaceType>
                  </type>
                  <IDENTIFIER startline="5" startpos="14">nop</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="5" startpos="17">(</LPAREN>
                    <RPAREN startline="5" startpos="18">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="5" startpos="20">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <RETURN startline="6" startpos="2">return</RETURN>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <THIS startline="6" startpos="9">this</THIS>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="6" startpos="13">;</SEMI>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="7" startpos="1">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <classBodyDeclaration>
              <SEMI startline="7" startpos="2">;</SEMI>
            </classBodyDeclaration>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="9" startpos="1">public</PUBLIC>
                  </modifiers>
                  <type>
                    <classOrInterfaceType>
                      <IDENTIFIER startline="9" startpos="8">State</IDENTIFIER>
                    </classOrInterfaceType>
                  </type>
                  <IDENTIFIER startline="9" startpos="14">copyAccumTo</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="9" startpos="25">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <primitiveType>
                            <TOKEN startline="9" startpos="26">int</TOKEN>
                          </primitiveType>
                        </type>
                        <IDENTIFIER startline="9" startpos="30">register</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="9" startpos="38">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="9" startpos="40">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="10" startpos="2">address</IDENTIFIER>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                          <assignmentOperator>
                            <EQ startline="10" startpos="10">=</EQ>
                          </assignmentOperator>
                          <expression>
                            <conditionalExpression>
                              <conditionalOrExpression>
                                <conditionalAndExpression>
                                  <inclusiveOrExpression>
                                    <exclusiveOrExpression>
                                      <andExpression>
                                        <equalityExpression>
                                          <instanceOfExpression>
                                            <relationalExpression>
                                              <shiftExpression>
                                                <additiveExpression>
                                                  <multiplicativeExpression>
                                                    <unaryExpression>
                                                      <unaryExpressionNotPlusMinus>
                                                        <primary>
                                                          <IDENTIFIER startline="10" startpos="12">register</IDENTIFIER>
                                                        </primary>
                                                      </unaryExpressionNotPlusMinus>
                                                    </unaryExpression>
                                                  </multiplicativeExpression>
                                                </additiveExpression>
                                              </shiftExpression>
                                            </relationalExpression>
                                          </instanceOfExpression>
                                        </equalityExpression>
                                      </andExpression>
                                    </exclusiveOrExpression>
                                  </inclusiveOrExpression>
                                </conditionalAndExpression>
                              </conditionalOrExpression>
                            </conditionalExpression>
                          </expression>
                        </expression>
                        <SEMI startline="10" startpos="20">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="11" startpos="2">System</IDENTIFIER>
                                                        <DOT startline="11" startpos="8">.</DOT>
                                                        <IDENTIFIER startline="11" startpos="9">out</IDENTIFIER>
                                                        <DOT startline="11" startpos="12">.</DOT>
                                                        <IDENTIFIER startline="11" startpos="13">println</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="11" startpos="20">(</LPAREN>
                                                            <expressionList>
                                                              <expression>
                                                                <conditionalExpression>
                                                                  <conditionalOrExpression>
                                                                    <conditionalAndExpression>
                                                                      <inclusiveOrExpression>
                                                                        <exclusiveOrExpression>
                                                                          <andExpression>
                                                                            <equalityExpression>
                                                                              <instanceOfExpression>
                                                                                <relationalExpression>
                                                                                  <shiftExpression>
                                                                                    <additiveExpression>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <literal>
                                                                                                <stringLiteral>
                                                                                                  <STRINGLITERAL startline="11" startpos="21">"address: "</STRINGLITERAL>
                                                                                                </stringLiteral>
                                                                                              </literal>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                      <TOKEN startline="11" startpos="33">+</TOKEN>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <IDENTIFIER startline="11" startpos="35">address</IDENTIFIER>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                    </additiveExpression>
                                                                                  </shiftExpression>
                                                                                </relationalExpression>
                                                                              </instanceOfExpression>
                                                                            </equalityExpression>
                                                                          </andExpression>
                                                                        </exclusiveOrExpression>
                                                                      </inclusiveOrExpression>
                                                                    </conditionalAndExpression>
                                                                  </conditionalOrExpression>
                                                                </conditionalExpression>
                                                              </expression>
                                                            </expressionList>
                                                            <RPAREN startline="11" startpos="42">)</RPAREN>
                                                          </arguments>
                                                        </identifierSuffix>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="11" startpos="43">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <RETURN startline="12" startpos="2">return</RETURN>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <THIS startline="12" startpos="9">this</THIS>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="12" startpos="13">;</SEMI>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="13" startpos="1">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="15" startpos="1">public</PUBLIC>
                  </modifiers>
                  <type>
                    <classOrInterfaceType>
                      <IDENTIFIER startline="15" startpos="8">State</IDENTIFIER>
                    </classOrInterfaceType>
                  </type>
                  <IDENTIFIER startline="15" startpos="14">addToAccum</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="15" startpos="24">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <primitiveType>
                            <TOKEN startline="15" startpos="25">int</TOKEN>
                          </primitiveType>
                        </type>
                        <IDENTIFIER startline="15" startpos="29">register</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="15" startpos="37">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="15" startpos="39">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="16" startpos="2">address</IDENTIFIER>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                          <assignmentOperator>
                            <PLUSEQ startline="16" startpos="10">+=</PLUSEQ>
                          </assignmentOperator>
                          <expression>
                            <conditionalExpression>
                              <conditionalOrExpression>
                                <conditionalAndExpression>
                                  <inclusiveOrExpression>
                                    <exclusiveOrExpression>
                                      <andExpression>
                                        <equalityExpression>
                                          <instanceOfExpression>
                                            <relationalExpression>
                                              <shiftExpression>
                                                <additiveExpression>
                                                  <multiplicativeExpression>
                                                    <unaryExpression>
                                                      <unaryExpressionNotPlusMinus>
                                                        <primary>
                                                          <IDENTIFIER startline="16" startpos="13">register</IDENTIFIER>
                                                        </primary>
                                                      </unaryExpressionNotPlusMinus>
                                                    </unaryExpression>
                                                  </multiplicativeExpression>
                                                </additiveExpression>
                                              </shiftExpression>
                                            </relationalExpression>
                                          </instanceOfExpression>
                                        </equalityExpression>
                                      </andExpression>
                                    </exclusiveOrExpression>
                                  </inclusiveOrExpression>
                                </conditionalAndExpression>
                              </conditionalOrExpression>
                            </conditionalExpression>
                          </expression>
                        </expression>
                        <SEMI startline="16" startpos="21">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="17" startpos="2">System</IDENTIFIER>
                                                        <DOT startline="17" startpos="8">.</DOT>
                                                        <IDENTIFIER startline="17" startpos="9">out</IDENTIFIER>
                                                        <DOT startline="17" startpos="12">.</DOT>
                                                        <IDENTIFIER startline="17" startpos="13">println</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="17" startpos="20">(</LPAREN>
                                                            <expressionList>
                                                              <expression>
                                                                <conditionalExpression>
                                                                  <conditionalOrExpression>
                                                                    <conditionalAndExpression>
                                                                      <inclusiveOrExpression>
                                                                        <exclusiveOrExpression>
                                                                          <andExpression>
                                                                            <equalityExpression>
                                                                              <instanceOfExpression>
                                                                                <relationalExpression>
                                                                                  <shiftExpression>
                                                                                    <additiveExpression>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <literal>
                                                                                                <stringLiteral>
                                                                                                  <STRINGLITERAL startline="17" startpos="21">"address: "</STRINGLITERAL>
                                                                                                </stringLiteral>
                                                                                              </literal>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                      <TOKEN startline="17" startpos="33">+</TOKEN>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <IDENTIFIER startline="17" startpos="35">address</IDENTIFIER>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                    </additiveExpression>
                                                                                  </shiftExpression>
                                                                                </relationalExpression>
                                                                              </instanceOfExpression>
                                                                            </equalityExpression>
                                                                          </andExpression>
                                                                        </exclusiveOrExpression>
                                                                      </inclusiveOrExpression>
                                                                    </conditionalAndExpression>
                                                                  </conditionalOrExpression>
                                                                </conditionalExpression>
                                                              </expression>
                                                            </expressionList>
                                                            <RPAREN startline="17" startpos="42">)</RPAREN>
                                                          </arguments>
                                                        </identifierSuffix>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="17" startpos="43">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <RETURN startline="18" startpos="2">return</RETURN>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <THIS startline="18" startpos="9">this</THIS>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="18" startpos="13">;</SEMI>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="19" startpos="1">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="21" startpos="1">public</PUBLIC>
                  </modifiers>
                  <type>
                    <classOrInterfaceType>
                      <IDENTIFIER startline="21" startpos="8">State</IDENTIFIER>
                    </classOrInterfaceType>
                  </type>
                  <IDENTIFIER startline="21" startpos="14">subFromAccum</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="21" startpos="26">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <primitiveType>
                            <TOKEN startline="21" startpos="27">int</TOKEN>
                          </primitiveType>
                        </type>
                        <IDENTIFIER startline="21" startpos="31">register</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="21" startpos="39">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="21" startpos="41">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="22" startpos="2">address</IDENTIFIER>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                          <assignmentOperator>
                            <SUBEQ startline="22" startpos="10">-=</SUBEQ>
                          </assignmentOperator>
                          <expression>
                            <conditionalExpression>
                              <conditionalOrExpression>
                                <conditionalAndExpression>
                                  <inclusiveOrExpression>
                                    <exclusiveOrExpression>
                                      <andExpression>
                                        <equalityExpression>
                                          <instanceOfExpression>
                                            <relationalExpression>
                                              <shiftExpression>
                                                <additiveExpression>
                                                  <multiplicativeExpression>
                                                    <unaryExpression>
                                                      <unaryExpressionNotPlusMinus>
                                                        <primary>
                                                          <IDENTIFIER startline="22" startpos="13">register</IDENTIFIER>
                                                        </primary>
                                                      </unaryExpressionNotPlusMinus>
                                                    </unaryExpression>
                                                  </multiplicativeExpression>
                                                </additiveExpression>
                                              </shiftExpression>
                                            </relationalExpression>
                                          </instanceOfExpression>
                                        </equalityExpression>
                                      </andExpression>
                                    </exclusiveOrExpression>
                                  </inclusiveOrExpression>
                                </conditionalAndExpression>
                              </conditionalOrExpression>
                            </conditionalExpression>
                          </expression>
                        </expression>
                        <SEMI startline="22" startpos="21">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="23" startpos="2">System</IDENTIFIER>
                                                        <DOT startline="23" startpos="8">.</DOT>
                                                        <IDENTIFIER startline="23" startpos="9">out</IDENTIFIER>
                                                        <DOT startline="23" startpos="12">.</DOT>
                                                        <IDENTIFIER startline="23" startpos="13">println</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="23" startpos="20">(</LPAREN>
                                                            <expressionList>
                                                              <expression>
                                                                <conditionalExpression>
                                                                  <conditionalOrExpression>
                                                                    <conditionalAndExpression>
                                                                      <inclusiveOrExpression>
                                                                        <exclusiveOrExpression>
                                                                          <andExpression>
                                                                            <equalityExpression>
                                                                              <instanceOfExpression>
                                                                                <relationalExpression>
                                                                                  <shiftExpression>
                                                                                    <additiveExpression>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <literal>
                                                                                                <stringLiteral>
                                                                                                  <STRINGLITERAL startline="23" startpos="21">"address: "</STRINGLITERAL>
                                                                                                </stringLiteral>
                                                                                              </literal>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                      <TOKEN startline="23" startpos="33">+</TOKEN>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <IDENTIFIER startline="23" startpos="35">address</IDENTIFIER>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                    </additiveExpression>
                                                                                  </shiftExpression>
                                                                                </relationalExpression>
                                                                              </instanceOfExpression>
                                                                            </equalityExpression>
                                                                          </andExpression>
                                                                        </exclusiveOrExpression>
                                                                      </inclusiveOrExpression>
                                                                    </conditionalAndExpression>
                                                                  </conditionalOrExpression>
                                                                </conditionalExpression>
                                                              </expression>
                                                            </expressionList>
                                                            <RPAREN startline="23" startpos="42">)</RPAREN>
                                                          </arguments>
                                                        </identifierSuffix>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="23" startpos="43">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <RETURN startline="24" startpos="2">return</RETURN>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <THIS startline="24" startpos="9">this</THIS>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="24" startpos="13">;</SEMI>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="25" startpos="1">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="27" startpos="1">public</PUBLIC>
                  </modifiers>
                  <type>
                    <classOrInterfaceType>
                      <IDENTIFIER startline="27" startpos="8">State</IDENTIFIER>
                    </classOrInterfaceType>
                  </type>
                  <IDENTIFIER startline="27" startpos="14">multiplyAccumBy</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="27" startpos="29">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <primitiveType>
                            <TOKEN startline="27" startpos="30">int</TOKEN>
                          </primitiveType>
                        </type>
                        <IDENTIFIER startline="27" startpos="34">register</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="27" startpos="42">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="27" startpos="44">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="28" startpos="2">address</IDENTIFIER>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                          <assignmentOperator>
                            <STAREQ startline="28" startpos="10">*=</STAREQ>
                          </assignmentOperator>
                          <expression>
                            <conditionalExpression>
                              <conditionalOrExpression>
                                <conditionalAndExpression>
                                  <inclusiveOrExpression>
                                    <exclusiveOrExpression>
                                      <andExpression>
                                        <equalityExpression>
                                          <instanceOfExpression>
                                            <relationalExpression>
                                              <shiftExpression>
                                                <additiveExpression>
                                                  <multiplicativeExpression>
                                                    <unaryExpression>
                                                      <unaryExpressionNotPlusMinus>
                                                        <primary>
                                                          <IDENTIFIER startline="28" startpos="13">register</IDENTIFIER>
                                                        </primary>
                                                      </unaryExpressionNotPlusMinus>
                                                    </unaryExpression>
                                                  </multiplicativeExpression>
                                                </additiveExpression>
                                              </shiftExpression>
                                            </relationalExpression>
                                          </instanceOfExpression>
                                        </equalityExpression>
                                      </andExpression>
                                    </exclusiveOrExpression>
                                  </inclusiveOrExpression>
                                </conditionalAndExpression>
                              </conditionalOrExpression>
                            </conditionalExpression>
                          </expression>
                        </expression>
                        <SEMI startline="28" startpos="21">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="29" startpos="2">System</IDENTIFIER>
                                                        <DOT startline="29" startpos="8">.</DOT>
                                                        <IDENTIFIER startline="29" startpos="9">out</IDENTIFIER>
                                                        <DOT startline="29" startpos="12">.</DOT>
                                                        <IDENTIFIER startline="29" startpos="13">println</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="29" startpos="20">(</LPAREN>
                                                            <expressionList>
                                                              <expression>
                                                                <conditionalExpression>
                                                                  <conditionalOrExpression>
                                                                    <conditionalAndExpression>
                                                                      <inclusiveOrExpression>
                                                                        <exclusiveOrExpression>
                                                                          <andExpression>
                                                                            <equalityExpression>
                                                                              <instanceOfExpression>
                                                                                <relationalExpression>
                                                                                  <shiftExpression>
                                                                                    <additiveExpression>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <literal>
                                                                                                <stringLiteral>
                                                                                                  <STRINGLITERAL startline="29" startpos="21">"address: "</STRINGLITERAL>
                                                                                                </stringLiteral>
                                                                                              </literal>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                      <TOKEN startline="29" startpos="33">+</TOKEN>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <IDENTIFIER startline="29" startpos="35">address</IDENTIFIER>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                    </additiveExpression>
                                                                                  </shiftExpression>
                                                                                </relationalExpression>
                                                                              </instanceOfExpression>
                                                                            </equalityExpression>
                                                                          </andExpression>
                                                                        </exclusiveOrExpression>
                                                                      </inclusiveOrExpression>
                                                                    </conditionalAndExpression>
                                                                  </conditionalOrExpression>
                                                                </conditionalExpression>
                                                              </expression>
                                                            </expressionList>
                                                            <RPAREN startline="29" startpos="42">)</RPAREN>
                                                          </arguments>
                                                        </identifierSuffix>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="29" startpos="43">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <RETURN startline="30" startpos="2">return</RETURN>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <THIS startline="30" startpos="9">this</THIS>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="30" startpos="13">;</SEMI>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="31" startpos="1">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="33" startpos="1">public</PUBLIC>
                  </modifiers>
                  <type>
                    <classOrInterfaceType>
                      <IDENTIFIER startline="33" startpos="8">State</IDENTIFIER>
                    </classOrInterfaceType>
                  </type>
                  <IDENTIFIER startline="33" startpos="14">divideAccumBy</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="33" startpos="27">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <primitiveType>
                            <TOKEN startline="33" startpos="28">int</TOKEN>
                          </primitiveType>
                        </type>
                        <IDENTIFIER startline="33" startpos="32">register</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="33" startpos="40">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="33" startpos="42">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="34" startpos="2">address</IDENTIFIER>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                          <assignmentOperator>
                            <SLASHEQ startline="34" startpos="10">/=</SLASHEQ>
                          </assignmentOperator>
                          <expression>
                            <conditionalExpression>
                              <conditionalOrExpression>
                                <conditionalAndExpression>
                                  <inclusiveOrExpression>
                                    <exclusiveOrExpression>
                                      <andExpression>
                                        <equalityExpression>
                                          <instanceOfExpression>
                                            <relationalExpression>
                                              <shiftExpression>
                                                <additiveExpression>
                                                  <multiplicativeExpression>
                                                    <unaryExpression>
                                                      <unaryExpressionNotPlusMinus>
                                                        <primary>
                                                          <IDENTIFIER startline="34" startpos="13">register</IDENTIFIER>
                                                        </primary>
                                                      </unaryExpressionNotPlusMinus>
                                                    </unaryExpression>
                                                  </multiplicativeExpression>
                                                </additiveExpression>
                                              </shiftExpression>
                                            </relationalExpression>
                                          </instanceOfExpression>
                                        </equalityExpression>
                                      </andExpression>
                                    </exclusiveOrExpression>
                                  </inclusiveOrExpression>
                                </conditionalAndExpression>
                              </conditionalOrExpression>
                            </conditionalExpression>
                          </expression>
                        </expression>
                        <SEMI startline="34" startpos="21">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <IDENTIFIER startline="35" startpos="2">System</IDENTIFIER>
                                                        <DOT startline="35" startpos="8">.</DOT>
                                                        <IDENTIFIER startline="35" startpos="9">out</IDENTIFIER>
                                                        <DOT startline="35" startpos="12">.</DOT>
                                                        <IDENTIFIER startline="35" startpos="13">println</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="35" startpos="20">(</LPAREN>
                                                            <expressionList>
                                                              <expression>
                                                                <conditionalExpression>
                                                                  <conditionalOrExpression>
                                                                    <conditionalAndExpression>
                                                                      <inclusiveOrExpression>
                                                                        <exclusiveOrExpression>
                                                                          <andExpression>
                                                                            <equalityExpression>
                                                                              <instanceOfExpression>
                                                                                <relationalExpression>
                                                                                  <shiftExpression>
                                                                                    <additiveExpression>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <literal>
                                                                                                <stringLiteral>
                                                                                                  <STRINGLITERAL startline="35" startpos="21">"address: "</STRINGLITERAL>
                                                                                                </stringLiteral>
                                                                                              </literal>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                      <TOKEN startline="35" startpos="33">+</TOKEN>
                                                                                      <multiplicativeExpression>
                                                                                        <unaryExpression>
                                                                                          <unaryExpressionNotPlusMinus>
                                                                                            <primary>
                                                                                              <IDENTIFIER startline="35" startpos="35">address</IDENTIFIER>
                                                                                            </primary>
                                                                                          </unaryExpressionNotPlusMinus>
                                                                                        </unaryExpression>
                                                                                      </multiplicativeExpression>
                                                                                    </additiveExpression>
                                                                                  </shiftExpression>
                                                                                </relationalExpression>
                                                                              </instanceOfExpression>
                                                                            </equalityExpression>
                                                                          </andExpression>
                                                                        </exclusiveOrExpression>
                                                                      </inclusiveOrExpression>
                                                                    </conditionalAndExpression>
                                                                  </conditionalOrExpression>
                                                                </conditionalExpression>
                                                              </expression>
                                                            </expressionList>
                                                            <RPAREN startline="35" startpos="42">)</RPAREN>
                                                          </arguments>
                                                        </identifierSuffix>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="35" startpos="43">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <RETURN startline="36" startpos="2">return</RETURN>
                        <expression>
                          <conditionalExpression>
                            <conditionalOrExpression>
                              <conditionalAndExpression>
                                <inclusiveOrExpression>
                                  <exclusiveOrExpression>
                                    <andExpression>
                                      <equalityExpression>
                                        <instanceOfExpression>
                                          <relationalExpression>
                                            <shiftExpression>
                                              <additiveExpression>
                                                <multiplicativeExpression>
                                                  <unaryExpression>
                                                    <unaryExpressionNotPlusMinus>
                                                      <primary>
                                                        <THIS startline="36" startpos="9">this</THIS>
                                                      </primary>
                                                    </unaryExpressionNotPlusMinus>
                                                  </unaryExpression>
                                                </multiplicativeExpression>
                                              </additiveExpression>
                                            </shiftExpression>
                                          </relationalExpression>
                                        </instanceOfExpression>
                                      </equalityExpression>
                                    </andExpression>
                                  </exclusiveOrExpression>
                                </inclusiveOrExpression>
                              </conditionalAndExpression>
                            </conditionalOrExpression>
                          </conditionalExpression>
                        </expression>
                        <SEMI startline="36" startpos="13">;</SEMI>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="37" startpos="1">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <RBRACE startline="39" startpos="0">}</RBRACE>
          </classBody>
        </normalClassDeclaration>
      </classDeclaration>
    </classOrInterfaceDeclaration>
  </typeDeclaration>
</compilationUnit>