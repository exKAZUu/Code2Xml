<compilationUnit>
  <packageDeclaration>
    <PACKAGE startline="1" startpos="0">package</PACKAGE>
    <qualifiedName>
      <IDENTIFIER startline="1" startpos="8">tryWithStatements</IDENTIFIER>
    </qualifiedName>
    <SEMI startline="1" startpos="25">;</SEMI>
  </packageDeclaration>
  <importDeclaration>
    <IMPORT startline="3" startpos="0">import</IMPORT>
    <IDENTIFIER startline="3" startpos="7">java</IDENTIFIER>
    <DOT startline="3" startpos="11">.</DOT>
    <IDENTIFIER startline="3" startpos="12">io</IDENTIFIER>
    <DOT startline="3" startpos="14">.</DOT>
    <IDENTIFIER startline="3" startpos="15">BufferedReader</IDENTIFIER>
    <SEMI startline="3" startpos="29">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="4" startpos="0">import</IMPORT>
    <IDENTIFIER startline="4" startpos="7">java</IDENTIFIER>
    <DOT startline="4" startpos="11">.</DOT>
    <IDENTIFIER startline="4" startpos="12">io</IDENTIFIER>
    <DOT startline="4" startpos="14">.</DOT>
    <IDENTIFIER startline="4" startpos="15">FileReader</IDENTIFIER>
    <SEMI startline="4" startpos="25">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="5" startpos="0">import</IMPORT>
    <IDENTIFIER startline="5" startpos="7">java</IDENTIFIER>
    <DOT startline="5" startpos="11">.</DOT>
    <IDENTIFIER startline="5" startpos="12">io</IDENTIFIER>
    <DOT startline="5" startpos="14">.</DOT>
    <IDENTIFIER startline="5" startpos="15">IOException</IDENTIFIER>
    <SEMI startline="5" startpos="26">;</SEMI>
  </importDeclaration>
  <typeDeclaration>
    <classOrInterfaceDeclaration>
      <classDeclaration>
        <normalClassDeclaration>
          <modifiers>
            <PUBLIC startline="7" startpos="0">public</PUBLIC>
          </modifiers>
          <CLASS startline="7" startpos="7">class</CLASS>
          <IDENTIFIER startline="7" startpos="13">TryWithStatements</IDENTIFIER>
          <classBody>
            <LBRACE startline="7" startpos="31">{</LBRACE>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="8" startpos="3">public</PUBLIC>
                    <STATIC startline="8" startpos="10">static</STATIC>
                  </modifiers>
                  <type>
                    <classOrInterfaceType>
                      <IDENTIFIER startline="8" startpos="17">String</IDENTIFIER>
                    </classOrInterfaceType>
                  </type>
                  <IDENTIFIER startline="8" startpos="24">readFirstLineFromFile</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="8" startpos="45">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <classOrInterfaceType>
                            <IDENTIFIER startline="8" startpos="46">String</IDENTIFIER>
                          </classOrInterfaceType>
                        </type>
                        <IDENTIFIER startline="8" startpos="53">path</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="8" startpos="57">)</RPAREN>
                  </formalParameters>
                  <THROWS startline="8" startpos="59">throws</THROWS>
                  <qualifiedNameList>
                    <qualifiedName>
                      <IDENTIFIER startline="8" startpos="66">IOException</IDENTIFIER>
                    </qualifiedName>
                  </qualifiedNameList>
                  <block>
                    <LBRACE startline="8" startpos="78">{</LBRACE>
                    <blockStatement>
                      <statement>
                        <trystatement>
                          <tryWithResourcesStatement>
                            <TRY startline="9" startpos="6">try</TRY>
                            <resourceSpecification>
                              <LPAREN startline="9" startpos="10">(</LPAREN>
                              <resources>
                                <resource>
                                  <variableModifiers />
                                  <type>
                                    <classOrInterfaceType>
                                      <IDENTIFIER startline="9" startpos="11">BufferedReader</IDENTIFIER>
                                    </classOrInterfaceType>
                                  </type>
                                  <IDENTIFIER startline="9" startpos="26">br</IDENTIFIER>
                                  <EQ startline="9" startpos="29">=</EQ>
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
                                                                  <creator>
                                                                    <NEW startline="9" startpos="31">new</NEW>
                                                                    <classOrInterfaceType>
                                                                      <IDENTIFIER startline="9" startpos="35">BufferedReader</IDENTIFIER>
                                                                    </classOrInterfaceType>
                                                                    <classCreatorRest>
                                                                      <arguments>
                                                                        <LPAREN startline="9" startpos="49">(</LPAREN>
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
                                                                                                          <creator>
                                                                                                            <NEW startline="9" startpos="50">new</NEW>
                                                                                                            <classOrInterfaceType>
                                                                                                              <IDENTIFIER startline="9" startpos="54">FileReader</IDENTIFIER>
                                                                                                            </classOrInterfaceType>
                                                                                                            <classCreatorRest>
                                                                                                              <arguments>
                                                                                                                <LPAREN startline="9" startpos="64">(</LPAREN>
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
                                                                                                                                                  <IDENTIFIER startline="9" startpos="65">path</IDENTIFIER>
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
                                                                                                                <RPAREN startline="9" startpos="69">)</RPAREN>
                                                                                                              </arguments>
                                                                                                            </classCreatorRest>
                                                                                                          </creator>
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
                                                                        <RPAREN startline="9" startpos="70">)</RPAREN>
                                                                      </arguments>
                                                                    </classCreatorRest>
                                                                  </creator>
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
                                </resource>
                              </resources>
                              <RPAREN startline="9" startpos="71">)</RPAREN>
                            </resourceSpecification>
                            <block>
                              <LBRACE startline="9" startpos="73">{</LBRACE>
                              <blockStatement>
                                <statement>
                                  <RETURN startline="10" startpos="8">return</RETURN>
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
                                                                  <IDENTIFIER startline="10" startpos="15">br</IDENTIFIER>
                                                                  <DOT startline="10" startpos="17">.</DOT>
                                                                  <IDENTIFIER startline="10" startpos="18">readLine</IDENTIFIER>
                                                                  <identifierSuffix>
                                                                    <arguments>
                                                                      <LPAREN startline="10" startpos="26">(</LPAREN>
                                                                      <RPAREN startline="10" startpos="27">)</RPAREN>
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
                                  <SEMI startline="10" startpos="28">;</SEMI>
                                </statement>
                              </blockStatement>
                              <RBRACE startline="11" startpos="6">}</RBRACE>
                            </block>
                          </tryWithResourcesStatement>
                        </trystatement>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="12" startpos="4">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <RBRACE startline="13" startpos="0">}</RBRACE>
          </classBody>
        </normalClassDeclaration>
      </classDeclaration>
    </classOrInterfaceDeclaration>
  </typeDeclaration>
</compilationUnit>