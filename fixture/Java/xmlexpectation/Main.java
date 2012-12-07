<compilationUnit>
  <importDeclaration>
    <IMPORT startline="1" startpos="0">import</IMPORT>
    <IDENTIFIER startline="1" startpos="7">java</IDENTIFIER>
    <DOT startline="1" startpos="11">.</DOT>
    <IDENTIFIER startline="1" startpos="12">io</IDENTIFIER>
    <DOT startline="1" startpos="14">.</DOT>
    <IDENTIFIER startline="1" startpos="15">File</IDENTIFIER>
    <SEMI startline="1" startpos="19">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="2" startpos="0">import</IMPORT>
    <IDENTIFIER startline="2" startpos="7">java</IDENTIFIER>
    <DOT startline="2" startpos="11">.</DOT>
    <IDENTIFIER startline="2" startpos="12">io</IDENTIFIER>
    <DOT startline="2" startpos="14">.</DOT>
    <IDENTIFIER startline="2" startpos="15">IOException</IDENTIFIER>
    <SEMI startline="2" startpos="26">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="4" startpos="0">import</IMPORT>
    <IDENTIFIER startline="4" startpos="7">numericLiterals</IDENTIFIER>
    <DOT startline="4" startpos="22">.</DOT>
    <IDENTIFIER startline="4" startpos="23">BinaryLiterals</IDENTIFIER>
    <SEMI startline="4" startpos="37">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="5" startpos="0">import</IMPORT>
    <IDENTIFIER startline="5" startpos="7">numericLiterals</IDENTIFIER>
    <DOT startline="5" startpos="22">.</DOT>
    <IDENTIFIER startline="5" startpos="23">State</IDENTIFIER>
    <SEMI startline="5" startpos="28">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="6" startpos="0">import</IMPORT>
    <IDENTIFIER startline="6" startpos="7">stringSwitch</IDENTIFIER>
    <DOT startline="6" startpos="19">.</DOT>
    <IDENTIFIER startline="6" startpos="20">StringInSwitchStatements</IDENTIFIER>
    <SEMI startline="6" startpos="44">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="7" startpos="0">import</IMPORT>
    <IDENTIFIER startline="7" startpos="7">diamonds</IDENTIFIER>
    <DOT startline="7" startpos="15">.</DOT>
    <IDENTIFIER startline="7" startpos="16">TypeInference</IDENTIFIER>
    <SEMI startline="7" startpos="29">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="8" startpos="0">import</IMPORT>
    <IDENTIFIER startline="8" startpos="7">diamonds</IDENTIFIER>
    <DOT startline="8" startpos="15">.</DOT>
    <IDENTIFIER startline="8" startpos="16">InstanceGetter</IDENTIFIER>
    <SEMI startline="8" startpos="30">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="9" startpos="0">import</IMPORT>
    <IDENTIFIER startline="9" startpos="7">tryWithStatements</IDENTIFIER>
    <DOT startline="9" startpos="24">.</DOT>
    <IDENTIFIER startline="9" startpos="25">TryWithStatements</IDENTIFIER>
    <SEMI startline="9" startpos="42">;</SEMI>
  </importDeclaration>
  <importDeclaration>
    <IMPORT startline="10" startpos="0">import</IMPORT>
    <IDENTIFIER startline="10" startpos="7">multipleException</IDENTIFIER>
    <DOT startline="10" startpos="24">.</DOT>
    <STAR startline="10" startpos="25">*</STAR>
    <SEMI startline="10" startpos="26">;</SEMI>
  </importDeclaration>
  <typeDeclaration>
    <classOrInterfaceDeclaration>
      <classDeclaration>
        <normalClassDeclaration>
          <modifiers>
            <PUBLIC startline="12" startpos="0">public</PUBLIC>
          </modifiers>
          <CLASS startline="12" startpos="7">class</CLASS>
          <IDENTIFIER startline="12" startpos="13">Main</IDENTIFIER>
          <classBody>
            <LBRACE startline="12" startpos="18">{</LBRACE>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="13" startpos="1">public</PUBLIC>
                    <STATIC startline="13" startpos="8">static</STATIC>
                  </modifiers>
                  <VOID startline="13" startpos="15">void</VOID>
                  <IDENTIFIER startline="13" startpos="20">main</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="13" startpos="24">(</LPAREN>
                    <formalParameterDecls>
                      <normalParameterDecl>
                        <variableModifiers />
                        <type>
                          <classOrInterfaceType>
                            <IDENTIFIER startline="13" startpos="25">String</IDENTIFIER>
                          </classOrInterfaceType>
                          <LBRACKET startline="13" startpos="31">[</LBRACKET>
                          <RBRACKET startline="13" startpos="32">]</RBRACKET>
                        </type>
                        <IDENTIFIER startline="13" startpos="34">args</IDENTIFIER>
                      </normalParameterDecl>
                    </formalParameterDecls>
                    <RPAREN startline="13" startpos="38">)</RPAREN>
                  </formalParameters>
                  <block>
                    <LBRACE startline="13" startpos="40">{</LBRACE>
                    <blockStatement>
                      <localVariableDeclarationStatement>
                        <localVariableDeclaration>
                          <variableModifiers />
                          <type>
                            <classOrInterfaceType>
                              <IDENTIFIER startline="14" startpos="4">BinaryLiterals</IDENTIFIER>
                            </classOrInterfaceType>
                          </type>
                          <variableDeclarator>
                            <IDENTIFIER startline="14" startpos="19">binary</IDENTIFIER>
                            <EQ startline="14" startpos="26">=</EQ>
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
                                                              <creator>
                                                                <NEW startline="14" startpos="28">new</NEW>
                                                                <classOrInterfaceType>
                                                                  <IDENTIFIER startline="14" startpos="32">BinaryLiterals</IDENTIFIER>
                                                                </classOrInterfaceType>
                                                                <classCreatorRest>
                                                                  <arguments>
                                                                    <LPAREN startline="14" startpos="46">(</LPAREN>
                                                                    <RPAREN startline="14" startpos="47">)</RPAREN>
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
                            </variableInitializer>
                          </variableDeclarator>
                        </localVariableDeclaration>
                        <SEMI startline="14" startpos="48">;</SEMI>
                      </localVariableDeclarationStatement>
                    </blockStatement>
                    <blockStatement>
                      <localVariableDeclarationStatement>
                        <localVariableDeclaration>
                          <variableModifiers />
                          <type>
                            <classOrInterfaceType>
                              <IDENTIFIER startline="15" startpos="4">State</IDENTIFIER>
                            </classOrInterfaceType>
                          </type>
                          <variableDeclarator>
                            <IDENTIFIER startline="15" startpos="10">state</IDENTIFIER>
                            <EQ startline="15" startpos="16">=</EQ>
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
                                                              <creator>
                                                                <NEW startline="15" startpos="18">new</NEW>
                                                                <classOrInterfaceType>
                                                                  <IDENTIFIER startline="15" startpos="22">State</IDENTIFIER>
                                                                </classOrInterfaceType>
                                                                <classCreatorRest>
                                                                  <arguments>
                                                                    <LPAREN startline="15" startpos="27">(</LPAREN>
                                                                    <RPAREN startline="15" startpos="28">)</RPAREN>
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
                            </variableInitializer>
                          </variableDeclarator>
                        </localVariableDeclaration>
                        <SEMI startline="15" startpos="29">;</SEMI>
                      </localVariableDeclarationStatement>
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
                                                        <IDENTIFIER startline="16" startpos="4">binary</IDENTIFIER>
                                                        <DOT startline="16" startpos="10">.</DOT>
                                                        <IDENTIFIER startline="16" startpos="11">decodeInstruction</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="16" startpos="28">(</LPAREN>
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
                                                                                              <IDENTIFIER startline="16" startpos="29">binary</IDENTIFIER>
                                                                                              <DOT startline="16" startpos="35">.</DOT>
                                                                                              <IDENTIFIER startline="16" startpos="36">aByte</IDENTIFIER>
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
                                                              <COMMA startline="16" startpos="41">,</COMMA>
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
                                                                                              <IDENTIFIER startline="16" startpos="43">state</IDENTIFIER>
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
                                                            <RPAREN startline="16" startpos="48">)</RPAREN>
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
                        <SEMI startline="16" startpos="49">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <localVariableDeclarationStatement>
                        <localVariableDeclaration>
                          <variableModifiers />
                          <type>
                            <classOrInterfaceType>
                              <IDENTIFIER startline="18" startpos="4">StringInSwitchStatements</IDENTIFIER>
                            </classOrInterfaceType>
                          </type>
                          <variableDeclarator>
                            <IDENTIFIER startline="18" startpos="29">strings</IDENTIFIER>
                            <EQ startline="18" startpos="37">=</EQ>
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
                                                              <creator>
                                                                <NEW startline="18" startpos="39">new</NEW>
                                                                <classOrInterfaceType>
                                                                  <IDENTIFIER startline="18" startpos="43">StringInSwitchStatements</IDENTIFIER>
                                                                </classOrInterfaceType>
                                                                <classCreatorRest>
                                                                  <arguments>
                                                                    <LPAREN startline="18" startpos="67">(</LPAREN>
                                                                    <RPAREN startline="18" startpos="68">)</RPAREN>
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
                            </variableInitializer>
                          </variableDeclarator>
                        </localVariableDeclaration>
                        <SEMI startline="18" startpos="69">;</SEMI>
                      </localVariableDeclarationStatement>
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
                                                        <IDENTIFIER startline="19" startpos="4">System</IDENTIFIER>
                                                        <DOT startline="19" startpos="10">.</DOT>
                                                        <IDENTIFIER startline="19" startpos="11">out</IDENTIFIER>
                                                        <DOT startline="19" startpos="14">.</DOT>
                                                        <IDENTIFIER startline="19" startpos="15">println</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="19" startpos="22">(</LPAREN>
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
                                                                                              <IDENTIFIER startline="19" startpos="23">strings</IDENTIFIER>
                                                                                              <DOT startline="19" startpos="30">.</DOT>
                                                                                              <IDENTIFIER startline="19" startpos="31">getTypeOfDayWithSwitchStatement</IDENTIFIER>
                                                                                              <identifierSuffix>
                                                                                                <arguments>
                                                                                                  <LPAREN startline="19" startpos="62">(</LPAREN>
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
                                                                                                                                        <STRINGLITERAL startline="19" startpos="63">"Wednesday"</STRINGLITERAL>
                                                                                                                                      </stringLiteral>
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
                                                                                                  <RPAREN startline="19" startpos="74">)</RPAREN>
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
                                                            </expressionList>
                                                            <RPAREN startline="19" startpos="75">)</RPAREN>
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
                        <SEMI startline="19" startpos="76">;</SEMI>
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
                                                        <IDENTIFIER startline="20" startpos="4">System</IDENTIFIER>
                                                        <DOT startline="20" startpos="10">.</DOT>
                                                        <IDENTIFIER startline="20" startpos="11">out</IDENTIFIER>
                                                        <DOT startline="20" startpos="14">.</DOT>
                                                        <IDENTIFIER startline="20" startpos="15">println</IDENTIFIER>
                                                        <identifierSuffix>
                                                          <arguments>
                                                            <LPAREN startline="20" startpos="22">(</LPAREN>
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
                                                                                              <IDENTIFIER startline="20" startpos="23">strings</IDENTIFIER>
                                                                                              <DOT startline="20" startpos="30">.</DOT>
                                                                                              <IDENTIFIER startline="20" startpos="31">getTypeOfDayWithSwitchStatement</IDENTIFIER>
                                                                                              <identifierSuffix>
                                                                                                <arguments>
                                                                                                  <LPAREN startline="20" startpos="62">(</LPAREN>
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
                                                                                                                                        <STRINGLITERAL startline="20" startpos="63">"Sunday"</STRINGLITERAL>
                                                                                                                                      </stringLiteral>
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
                                                                                                  <RPAREN startline="20" startpos="71">)</RPAREN>
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
                                                            </expressionList>
                                                            <RPAREN startline="20" startpos="72">)</RPAREN>
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
                        <SEMI startline="20" startpos="73">;</SEMI>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <localVariableDeclarationStatement>
                        <localVariableDeclaration>
                          <variableModifiers />
                          <type>
                            <classOrInterfaceType>
                              <IDENTIFIER startline="22" startpos="4">TypeInference</IDENTIFIER>
                              <typeArguments>
                                <LT startline="22" startpos="17">&lt;</LT>
                                <typeArgument>
                                  <type>
                                    <classOrInterfaceType>
                                      <IDENTIFIER startline="22" startpos="18">String</IDENTIFIER>
                                    </classOrInterfaceType>
                                  </type>
                                </typeArgument>
                                <GT startline="22" startpos="24">&gt;</GT>
                              </typeArguments>
                            </classOrInterfaceType>
                          </type>
                          <variableDeclarator>
                            <IDENTIFIER startline="22" startpos="26">typeinference</IDENTIFIER>
                            <EQ startline="22" startpos="40">=</EQ>
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
                                                              <IDENTIFIER startline="22" startpos="42">InstanceGetter</IDENTIFIER>
                                                              <DOT startline="22" startpos="56">.</DOT>
                                                              <IDENTIFIER startline="22" startpos="57">getInstance</IDENTIFIER>
                                                              <identifierSuffix>
                                                                <arguments>
                                                                  <LPAREN startline="22" startpos="68">(</LPAREN>
                                                                  <RPAREN startline="22" startpos="69">)</RPAREN>
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
                            </variableInitializer>
                          </variableDeclarator>
                        </localVariableDeclaration>
                        <SEMI startline="22" startpos="70">;</SEMI>
                      </localVariableDeclarationStatement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <trystatement>
                          <TRY startline="24" startpos="4">try</TRY>
                          <block>
                            <LBRACE startline="24" startpos="8">{</LBRACE>
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
                                                                <IDENTIFIER startline="25" startpos="4">System</IDENTIFIER>
                                                                <DOT startline="25" startpos="10">.</DOT>
                                                                <IDENTIFIER startline="25" startpos="11">out</IDENTIFIER>
                                                                <DOT startline="25" startpos="14">.</DOT>
                                                                <IDENTIFIER startline="25" startpos="15">println</IDENTIFIER>
                                                                <identifierSuffix>
                                                                  <arguments>
                                                                    <LPAREN startline="25" startpos="22">(</LPAREN>
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
                                                                                                      <IDENTIFIER startline="25" startpos="23">TryWithStatements</IDENTIFIER>
                                                                                                      <DOT startline="25" startpos="40">.</DOT>
                                                                                                      <IDENTIFIER startline="25" startpos="41">readFirstLineFromFile</IDENTIFIER>
                                                                                                      <identifierSuffix>
                                                                                                        <arguments>
                                                                                                          <LPAREN startline="25" startpos="62">(</LPAREN>
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
                                                                                                                                                <STRINGLITERAL startline="25" startpos="63">"test.txt"</STRINGLITERAL>
                                                                                                                                              </stringLiteral>
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
                                                                                                          <RPAREN startline="25" startpos="73">)</RPAREN>
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
                                                                    </expressionList>
                                                                    <RPAREN startline="25" startpos="74">)</RPAREN>
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
                                <SEMI startline="25" startpos="75">;</SEMI>
                              </statement>
                            </blockStatement>
                            <RBRACE startline="26" startpos="4">}</RBRACE>
                          </block>
                          <catches>
                            <catchClause>
                              <CATCH startline="26" startpos="6">catch</CATCH>
                              <LPAREN startline="26" startpos="12">(</LPAREN>
                              <formalParameter>
                                <variableModifiers />
                                <catchType>
                                  <type>
                                    <classOrInterfaceType>
                                      <IDENTIFIER startline="26" startpos="13">IOException</IDENTIFIER>
                                    </classOrInterfaceType>
                                  </type>
                                </catchType>
                                <IDENTIFIER startline="26" startpos="25">e</IDENTIFIER>
                              </formalParameter>
                              <RPAREN startline="26" startpos="26">)</RPAREN>
                              <block>
                                <LBRACE startline="26" startpos="28">{</LBRACE>
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
                                                                    <IDENTIFIER startline="27" startpos="5">e</IDENTIFIER>
                                                                    <DOT startline="27" startpos="6">.</DOT>
                                                                    <IDENTIFIER startline="27" startpos="7">printStackTrace</IDENTIFIER>
                                                                    <identifierSuffix>
                                                                      <arguments>
                                                                        <LPAREN startline="27" startpos="22">(</LPAREN>
                                                                        <RPAREN startline="27" startpos="23">)</RPAREN>
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
                                    <SEMI startline="27" startpos="24">;</SEMI>
                                  </statement>
                                </blockStatement>
                                <RBRACE startline="28" startpos="4">}</RBRACE>
                              </block>
                            </catchClause>
                          </catches>
                        </trystatement>
                      </statement>
                    </blockStatement>
                    <blockStatement>
                      <localVariableDeclarationStatement>
                        <localVariableDeclaration>
                          <variableModifiers />
                          <type>
                            <classOrInterfaceType>
                              <IDENTIFIER startline="30" startpos="4">CatchingMultipleException</IDENTIFIER>
                            </classOrInterfaceType>
                          </type>
                          <variableDeclarator>
                            <IDENTIFIER startline="30" startpos="30">exception</IDENTIFIER>
                            <EQ startline="30" startpos="40">=</EQ>
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
                                                              <creator>
                                                                <NEW startline="30" startpos="42">new</NEW>
                                                                <classOrInterfaceType>
                                                                  <IDENTIFIER startline="30" startpos="46">CatchingMultipleException</IDENTIFIER>
                                                                </classOrInterfaceType>
                                                                <classCreatorRest>
                                                                  <arguments>
                                                                    <LPAREN startline="30" startpos="71">(</LPAREN>
                                                                    <RPAREN startline="30" startpos="72">)</RPAREN>
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
                            </variableInitializer>
                          </variableDeclarator>
                        </localVariableDeclaration>
                        <SEMI startline="30" startpos="73">;</SEMI>
                      </localVariableDeclarationStatement>
                    </blockStatement>
                    <blockStatement>
                      <statement>
                        <trystatement>
                          <TRY startline="31" startpos="4">try</TRY>
                          <block>
                            <LBRACE startline="31" startpos="8">{</LBRACE>
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
                                                                <IDENTIFIER startline="32" startpos="5">exception</IDENTIFIER>
                                                                <DOT startline="32" startpos="14">.</DOT>
                                                                <IDENTIFIER startline="32" startpos="15">rethrowException</IDENTIFIER>
                                                                <identifierSuffix>
                                                                  <arguments>
                                                                    <LPAREN startline="32" startpos="31">(</LPAREN>
                                                                    <RPAREN startline="32" startpos="32">)</RPAREN>
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
                                <SEMI startline="32" startpos="33">;</SEMI>
                              </statement>
                            </blockStatement>
                            <RBRACE startline="33" startpos="4">}</RBRACE>
                          </block>
                          <catches>
                            <catchClause>
                              <CATCH startline="33" startpos="6">catch</CATCH>
                              <LPAREN startline="33" startpos="12">(</LPAREN>
                              <formalParameter>
                                <variableModifiers />
                                <catchType>
                                  <type>
                                    <classOrInterfaceType>
                                      <IDENTIFIER startline="33" startpos="13">FirstException</IDENTIFIER>
                                    </classOrInterfaceType>
                                  </type>
                                  <BAR startline="33" startpos="28">|</BAR>
                                  <type>
                                    <classOrInterfaceType>
                                      <IDENTIFIER startline="33" startpos="30">LastException</IDENTIFIER>
                                    </classOrInterfaceType>
                                  </type>
                                </catchType>
                                <IDENTIFIER startline="33" startpos="44">e</IDENTIFIER>
                              </formalParameter>
                              <RPAREN startline="33" startpos="45">)</RPAREN>
                              <block>
                                <LBRACE startline="33" startpos="47">{</LBRACE>
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
                                                                    <IDENTIFIER startline="34" startpos="5">System</IDENTIFIER>
                                                                    <DOT startline="34" startpos="11">.</DOT>
                                                                    <IDENTIFIER startline="34" startpos="12">out</IDENTIFIER>
                                                                    <DOT startline="34" startpos="15">.</DOT>
                                                                    <IDENTIFIER startline="34" startpos="16">println</IDENTIFIER>
                                                                    <identifierSuffix>
                                                                      <arguments>
                                                                        <LPAREN startline="34" startpos="23">(</LPAREN>
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
                                                                                                              <STRINGLITERAL startline="34" startpos="24">"catched!"</STRINGLITERAL>
                                                                                                            </stringLiteral>
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
                                                                        <RPAREN startline="34" startpos="34">)</RPAREN>
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
                                    <SEMI startline="34" startpos="35">;</SEMI>
                                  </statement>
                                </blockStatement>
                                <RBRACE startline="35" startpos="4">}</RBRACE>
                              </block>
                            </catchClause>
                          </catches>
                        </trystatement>
                      </statement>
                    </blockStatement>
                    <RBRACE startline="36" startpos="3">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <RBRACE startline="37" startpos="0">}</RBRACE>
          </classBody>
        </normalClassDeclaration>
      </classDeclaration>
    </classOrInterfaceDeclaration>
  </typeDeclaration>
</compilationUnit>