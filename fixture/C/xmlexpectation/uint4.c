<translation_unit>
  <external_declaration>
    <declaration>
      <TOKEN startline="1" startpos="0">typedef</TOKEN>
      <declaration_specifiers>
        <type_specifier>
          <TOKEN startline="1" startpos="8">unsigned</TOKEN>
        </type_specifier>
        <type_specifier>
          <TOKEN startline="1" startpos="17">long</TOKEN>
        </type_specifier>
        <type_specifier>
          <TOKEN startline="1" startpos="22">int</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <init_declarator_list>
        <init_declarator>
          <declarator>
            <direct_declarator>
              <IDENTIFIER startline="1" startpos="26">UINT4</IDENTIFIER>
            </direct_declarator>
          </declarator>
        </init_declarator>
      </init_declarator_list>
      <TOKEN startline="1" startpos="31">;</TOKEN>
    </declaration>
  </external_declaration>
  <external_declaration>
    <function_definition>
      <declaration_specifiers>
        <type_specifier>
          <TOKEN startline="3" startpos="0">int</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <declarator>
        <direct_declarator>
          <IDENTIFIER startline="3" startpos="4">main</IDENTIFIER>
          <declarator_suffix>
            <TOKEN startline="3" startpos="8">(</TOKEN>
            <TOKEN startline="3" startpos="9">)</TOKEN>
          </declarator_suffix>
        </direct_declarator>
      </declarator>
      <compound_statement>
        <TOKEN startline="3" startpos="11">{</TOKEN>
        <block_item>
          <declaration>
            <declaration_specifiers>
              <type_specifier>
                <TOKEN startline="4" startpos="1">int</TOKEN>
              </type_specifier>
            </declaration_specifiers>
            <init_declarator_list>
              <init_declarator>
                <declarator>
                  <direct_declarator>
                    <IDENTIFIER startline="4" startpos="5">a</IDENTIFIER>
                  </direct_declarator>
                </declarator>
                <TOKEN startline="4" startpos="7">=</TOKEN>
                <initializer>
                  <assignment_expression>
                    <conditional_expression>
                      <logical_or_expression>
                        <logical_and_expression>
                          <inclusive_or_expression>
                            <exclusive_or_expression>
                              <and_expression>
                                <equality_expression>
                                  <relational_expression>
                                    <shift_expression>
                                      <additive_expression>
                                        <multiplicative_expression>
                                          <cast_expression>
                                            <unary_expression>
                                              <unary_operator>
                                                <TOKEN startline="4" startpos="9">-</TOKEN>
                                              </unary_operator>
                                              <cast_expression>
                                                <unary_expression>
                                                  <postfix_expression>
                                                    <primary_expression>
                                                      <constant>
                                                        <decimal_literal>
                                                          <DECIMAL_LITERAL startline="4" startpos="10">1</DECIMAL_LITERAL>
                                                        </decimal_literal>
                                                      </constant>
                                                    </primary_expression>
                                                  </postfix_expression>
                                                </unary_expression>
                                              </cast_expression>
                                            </unary_expression>
                                          </cast_expression>
                                        </multiplicative_expression>
                                      </additive_expression>
                                    </shift_expression>
                                  </relational_expression>
                                </equality_expression>
                              </and_expression>
                            </exclusive_or_expression>
                          </inclusive_or_expression>
                        </logical_and_expression>
                      </logical_or_expression>
                    </conditional_expression>
                  </assignment_expression>
                </initializer>
              </init_declarator>
            </init_declarator_list>
            <TOKEN startline="4" startpos="11">;</TOKEN>
          </declaration>
        </block_item>
        <block_item>
          <declaration>
            <declaration_specifiers>
              <type_specifier>
                <type_id>
                  <IDENTIFIER startline="5" startpos="1">UINT4</IDENTIFIER>
                </type_id>
              </type_specifier>
            </declaration_specifiers>
            <init_declarator_list>
              <init_declarator>
                <declarator>
                  <direct_declarator>
                    <IDENTIFIER startline="5" startpos="7">b</IDENTIFIER>
                  </direct_declarator>
                </declarator>
              </init_declarator>
            </init_declarator_list>
            <TOKEN startline="5" startpos="8">;</TOKEN>
          </declaration>
        </block_item>
        <block_item>
          <statement>
            <selection_statement>
              <TOKEN startline="6" startpos="1">if</TOKEN>
              <TOKEN startline="6" startpos="4">(</TOKEN>
              <expression>
                <assignment_expression>
                  <conditional_expression>
                    <logical_or_expression>
                      <logical_and_expression>
                        <inclusive_or_expression>
                          <exclusive_or_expression>
                            <and_expression>
                              <equality_expression>
                                <relational_expression>
                                  <shift_expression>
                                    <additive_expression>
                                      <multiplicative_expression>
                                        <cast_expression>
                                          <unary_expression>
                                            <postfix_expression>
                                              <primary_expression>
                                                <IDENTIFIER startline="6" startpos="5">a</IDENTIFIER>
                                              </primary_expression>
                                            </postfix_expression>
                                          </unary_expression>
                                        </cast_expression>
                                      </multiplicative_expression>
                                    </additive_expression>
                                  </shift_expression>
                                </relational_expression>
                                <TOKEN startline="6" startpos="7">==</TOKEN>
                                <relational_expression>
                                  <shift_expression>
                                    <additive_expression>
                                      <multiplicative_expression>
                                        <cast_expression>
                                          <unary_expression>
                                            <postfix_expression>
                                              <primary_expression>
                                                <constant>
                                                  <decimal_literal>
                                                    <DECIMAL_LITERAL startline="6" startpos="10">1</DECIMAL_LITERAL>
                                                  </decimal_literal>
                                                </constant>
                                              </primary_expression>
                                            </postfix_expression>
                                          </unary_expression>
                                        </cast_expression>
                                      </multiplicative_expression>
                                    </additive_expression>
                                  </shift_expression>
                                </relational_expression>
                              </equality_expression>
                            </and_expression>
                          </exclusive_or_expression>
                        </inclusive_or_expression>
                      </logical_and_expression>
                    </logical_or_expression>
                  </conditional_expression>
                </assignment_expression>
              </expression>
              <TOKEN startline="6" startpos="11">)</TOKEN>
              <statement>
                <expression_statement>
                  <expression>
                    <assignment_expression>
                      <lvalue>
                        <unary_expression>
                          <postfix_expression>
                            <primary_expression>
                              <IDENTIFIER startline="7" startpos="2">b</IDENTIFIER>
                            </primary_expression>
                          </postfix_expression>
                        </unary_expression>
                      </lvalue>
                      <assignment_operator>
                        <TOKEN startline="7" startpos="4">=</TOKEN>
                      </assignment_operator>
                      <assignment_expression>
                        <conditional_expression>
                          <logical_or_expression>
                            <logical_and_expression>
                              <inclusive_or_expression>
                                <exclusive_or_expression>
                                  <and_expression>
                                    <equality_expression>
                                      <relational_expression>
                                        <shift_expression>
                                          <additive_expression>
                                            <multiplicative_expression>
                                              <cast_expression>
                                                <TOKEN startline="7" startpos="6">(</TOKEN>
                                                <type_name>
                                                  <specifier_qualifier_list>
                                                    <type_specifier>
                                                      <type_id>
                                                        <IDENTIFIER startline="7" startpos="7">UINT4</IDENTIFIER>
                                                      </type_id>
                                                    </type_specifier>
                                                  </specifier_qualifier_list>
                                                </type_name>
                                                <TOKEN startline="7" startpos="12">)</TOKEN>
                                                <cast_expression>
                                                  <unary_expression>
                                                    <postfix_expression>
                                                      <primary_expression>
                                                        <IDENTIFIER startline="7" startpos="13">a</IDENTIFIER>
                                                      </primary_expression>
                                                    </postfix_expression>
                                                  </unary_expression>
                                                </cast_expression>
                                              </cast_expression>
                                            </multiplicative_expression>
                                          </additive_expression>
                                        </shift_expression>
                                      </relational_expression>
                                    </equality_expression>
                                  </and_expression>
                                </exclusive_or_expression>
                              </inclusive_or_expression>
                            </logical_and_expression>
                          </logical_or_expression>
                        </conditional_expression>
                      </assignment_expression>
                    </assignment_expression>
                  </expression>
                  <TOKEN startline="7" startpos="14">;</TOKEN>
                </expression_statement>
              </statement>
            </selection_statement>
          </statement>
        </block_item>
        <block_item>
          <statement>
            <jump_statement>
              <TOKEN startline="8" startpos="1">return</TOKEN>
              <expression>
                <assignment_expression>
                  <conditional_expression>
                    <logical_or_expression>
                      <logical_and_expression>
                        <inclusive_or_expression>
                          <exclusive_or_expression>
                            <and_expression>
                              <equality_expression>
                                <relational_expression>
                                  <shift_expression>
                                    <additive_expression>
                                      <multiplicative_expression>
                                        <cast_expression>
                                          <unary_expression>
                                            <postfix_expression>
                                              <primary_expression>
                                                <constant>
                                                  <decimal_literal>
                                                    <DECIMAL_LITERAL startline="8" startpos="8">0</DECIMAL_LITERAL>
                                                  </decimal_literal>
                                                </constant>
                                              </primary_expression>
                                            </postfix_expression>
                                          </unary_expression>
                                        </cast_expression>
                                      </multiplicative_expression>
                                    </additive_expression>
                                  </shift_expression>
                                </relational_expression>
                              </equality_expression>
                            </and_expression>
                          </exclusive_or_expression>
                        </inclusive_or_expression>
                      </logical_and_expression>
                    </logical_or_expression>
                  </conditional_expression>
                </assignment_expression>
              </expression>
              <TOKEN startline="8" startpos="9">;</TOKEN>
            </jump_statement>
          </statement>
        </block_item>
        <TOKEN startline="9" startpos="0">}</TOKEN>
      </compound_statement>
    </function_definition>
  </external_declaration>
</translation_unit>