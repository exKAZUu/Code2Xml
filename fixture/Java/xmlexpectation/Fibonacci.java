<compilationUnit>
  <typeDeclaration>
    <classOrInterfaceDeclaration>
      <classDeclaration>
        <normalClassDeclaration>
          <modifiers>
            <PUBLIC startline="1" startpos="0">public</PUBLIC>
            <STATIC startline="1" startpos="7">static</STATIC>
          </modifiers>
          <CLASS startline="1" startpos="14">class</CLASS>
          <IDENTIFIER startline="1" startpos="20">Fibonacci</IDENTIFIER>
          <classBody>
            <LBRACE startline="1" startpos="30">{</LBRACE>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="2" startpos="2">public</PUBLIC>
                    <STATIC startline="2" startpos="9">static</STATIC>
                  </modifiers>
                  <type>
                    <primitiveType>
                      <TOKEN startline="2" startpos="16">int</TOKEN>
                    </primitiveType>
                  </type>
                  <IDENTIFIER startline="2" startpos="20">fibonacci</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="2" startpos="29">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <primitiveType>
                            <TOKEN startline="2" startpos="30">int</TOKEN>
                          </primitiveType>
                        </type>
                        <IDENTIFIER startline="2" startpos="34">n</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="2" startpos="35">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="2" startpos="37">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <IF startline="3" startpos="4">if</IF>
                        <parExpression>
                          <LPAREN startline="3" startpos="7">(</LPAREN>
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
                                                          <IDENTIFIER startline="3" startpos="8">n</IDENTIFIER>
                                                        </primary>
                                                      </unaryExpressionNotPlusMinus>
                                                    </unaryExpression>
                                                  </multiplicativeExpression>
                                                </additiveExpression>
                                              </shiftExpression>
                                              <relationalOp>
                                                <LT startline="3" startpos="10">&lt;</LT>
                                              </relationalOp>
                                              <shiftExpression>
                                                <additiveExpression>
                                                  <multiplicativeExpression>
                                                    <unaryExpression>
                                                      <unaryExpressionNotPlusMinus>
                                                        <primary>
                                                          <literal>
                                                            <intLiteral>
                                                              <INTLITERAL startline="3" startpos="12">2</INTLITERAL>
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
                          <RPAREN startline="3" startpos="13">)</RPAREN>
                        </parExpression>
                        <statement>
                          <block>
                            <LBRACE startline="3" startpos="15">{</LBRACE>
                            <blockStatement>
                              <statement>
                                <RETURN startline="4" startpos="6">return</RETURN>
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
                                                                <IDENTIFIER startline="4" startpos="13">n</IDENTIFIER>
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
                                <SEMI startline="4" startpos="14">;</SEMI>
                              </statement>
                            </blockStatement>
                            <RBRACE startline="5" startpos="4">}</RBRACE>
                          </block>
                        </statement>
                        <ELSE startline="6" startpos="4">else</ELSE>
                        <statement>
                          <block>
                            <LBRACE startline="6" startpos="9">{</LBRACE>
                            <blockStatement>
                              <statement>
                                <RETURN startline="7" startpos="6">return</RETURN>
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
                                                                <IDENTIFIER startline="7" startpos="13">fibonacci</IDENTIFIER>
                                                                <identifierSuffix>
                                                                  <arguments>
                                                                    <LPAREN startline="7" startpos="22">(</LPAREN>
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
                                                                                                      <IDENTIFIER startline="7" startpos="23">n</IDENTIFIER>
                                                                                                    </primary>
                                                                                                  </unaryExpressionNotPlusMinus>
                                                                                                </unaryExpression>
                                                                                              </multiplicativeExpression>
                                                                                              <TOKEN startline="7" startpos="25">-</TOKEN>
                                                                                              <multiplicativeExpression>
                                                                                                <unaryExpression>
                                                                                                  <unaryExpressionNotPlusMinus>
                                                                                                    <primary>
                                                                                                      <literal>
                                                                                                        <intLiteral>
                                                                                                          <INTLITERAL startline="7" startpos="27">1</INTLITERAL>
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
                                                                    </expressionList>
                                                                    <RPAREN startline="7" startpos="28">)</RPAREN>
                                                                  </arguments>
                                                                </identifierSuffix>
                                                              </primary>
                                                            </unaryExpressionNotPlusMinus>
                                                          </unaryExpression>
                                                        </multiplicativeExpression>
                                                        <TOKEN startline="7" startpos="30">+</TOKEN>
                                                        <multiplicativeExpression>
                                                          <unaryExpression>
                                                            <unaryExpressionNotPlusMinus>
                                                              <primary>
                                                                <IDENTIFIER startline="7" startpos="32">fibonacci</IDENTIFIER>
                                                                <identifierSuffix>
                                                                  <arguments>
                                                                    <LPAREN startline="7" startpos="41">(</LPAREN>
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
                                                                                                      <IDENTIFIER startline="7" startpos="42">n</IDENTIFIER>
                                                                                                    </primary>
                                                                                                  </unaryExpressionNotPlusMinus>
                                                                                                </unaryExpression>
                                                                                              </multiplicativeExpression>
                                                                                              <TOKEN startline="7" startpos="44">-</TOKEN>
                                                                                              <multiplicativeExpression>
                                                                                                <unaryExpression>
                                                                                                  <unaryExpressionNotPlusMinus>
                                                                                                    <primary>
                                                                                                      <literal>
                                                                                                        <intLiteral>
                                                                                                          <INTLITERAL startline="7" startpos="46">2</INTLITERAL>
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
                                                                    </expressionList>
                                                                    <RPAREN startline="7" startpos="47">)</RPAREN>
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
                                <SEMI startline="7" startpos="48">;</SEMI>
                              </statement>
                            </blockStatement>
                            <RBRACE startline="8" startpos="4">}</RBRACE>
                          </block>
                        </statement>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="9" startpos="2">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <RBRACE startline="10" startpos="0">}</RBRACE>
          </classBody>
        </normalClassDeclaration>
      </classDeclaration>
    </classOrInterfaceDeclaration>
  </typeDeclaration>
</compilationUnit>