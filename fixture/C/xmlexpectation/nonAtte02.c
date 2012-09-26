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
      </declaration_specifiers>
      <init_declarator_list>
        <init_declarator>
          <declarator>
            <direct_declarator>
              <IDENTIFIER startline="1" startpos="22">__dev32_t</IDENTIFIER>
            </direct_declarator>
          </declarator>
        </init_declarator>
      </init_declarator_list>
      <TOKEN startline="1" startpos="31">;</TOKEN>
    </declaration>
  </external_declaration>
  <external_declaration>
    <declaration>
      <TOKEN startline="2" startpos="0">typedef</TOKEN>
      <declaration_specifiers>
        <type_specifier>
          <type_id>
            <IDENTIFIER startline="2" startpos="8">__dev32_t</IDENTIFIER>
          </type_id>
        </type_specifier>
      </declaration_specifiers>
      <init_declarator_list>
        <init_declarator>
          <declarator>
            <direct_declarator>
              <IDENTIFIER startline="2" startpos="18">dev_t</IDENTIFIER>
            </direct_declarator>
          </declarator>
        </init_declarator>
      </init_declarator_list>
      <TOKEN startline="2" startpos="23">;</TOKEN>
    </declaration>
  </external_declaration>
  <external_declaration>
    <function_definition>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="4" startpos="0">static</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="4" startpos="7">__inline</TOKEN>
        </gcc_function_specifier>
        <type_specifier>
          <TOKEN startline="4" startpos="16">unsigned</TOKEN>
        </type_specifier>
        <type_specifier>
          <TOKEN startline="4" startpos="25">short</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <declarator>
        <direct_declarator>
          <IDENTIFIER startline="5" startpos="0">bswap_16</IDENTIFIER>
          <declarator_suffix>
            <TOKEN startline="5" startpos="9">(</TOKEN>
            <parameter_type_list>
              <parameter_list>
                <parameter_declaration>
                  <declaration_specifiers>
                    <type_specifier>
                      <TOKEN startline="5" startpos="10">unsigned</TOKEN>
                    </type_specifier>
                    <type_specifier>
                      <TOKEN startline="5" startpos="19">short</TOKEN>
                    </type_specifier>
                  </declaration_specifiers>
                  <declarator>
                    <direct_declarator>
                      <IDENTIFIER startline="5" startpos="25">__x</IDENTIFIER>
                    </direct_declarator>
                  </declarator>
                </parameter_declaration>
              </parameter_list>
            </parameter_type_list>
            <TOKEN startline="5" startpos="28">)</TOKEN>
          </declarator_suffix>
        </direct_declarator>
      </declarator>
      <compound_statement>
        <TOKEN startline="6" startpos="0">{</TOKEN>
        <statement_list>
          <statement>
            <jump_statement>
              <TOKEN startline="7" startpos="2">return</TOKEN>
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
                                                <TOKEN startline="7" startpos="9">(</TOKEN>
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
                                                                                  <IDENTIFIER startline="7" startpos="10">__x</IDENTIFIER>
                                                                                </primary_expression>
                                                                              </postfix_expression>
                                                                            </unary_expression>
                                                                          </cast_expression>
                                                                        </multiplicative_expression>
                                                                      </additive_expression>
                                                                      <TOKEN startline="7" startpos="14">&gt;&gt;</TOKEN>
                                                                      <additive_expression>
                                                                        <multiplicative_expression>
                                                                          <cast_expression>
                                                                            <unary_expression>
                                                                              <postfix_expression>
                                                                                <primary_expression>
                                                                                  <constant>
                                                                                    <decimal_literal>
                                                                                      <DECIMAL_LITERAL startline="7" startpos="17">8</DECIMAL_LITERAL>
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
                                                <TOKEN startline="7" startpos="18">)</TOKEN>
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
                          <TOKEN startline="7" startpos="20">|</TOKEN>
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
                                                <TOKEN startline="7" startpos="22">(</TOKEN>
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
                                                                                  <IDENTIFIER startline="7" startpos="23">__x</IDENTIFIER>
                                                                                </primary_expression>
                                                                              </postfix_expression>
                                                                            </unary_expression>
                                                                          </cast_expression>
                                                                        </multiplicative_expression>
                                                                      </additive_expression>
                                                                      <TOKEN startline="7" startpos="27">&lt;&lt;</TOKEN>
                                                                      <additive_expression>
                                                                        <multiplicative_expression>
                                                                          <cast_expression>
                                                                            <unary_expression>
                                                                              <postfix_expression>
                                                                                <primary_expression>
                                                                                  <constant>
                                                                                    <decimal_literal>
                                                                                      <DECIMAL_LITERAL startline="7" startpos="30">8</DECIMAL_LITERAL>
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
                                                <TOKEN startline="7" startpos="31">)</TOKEN>
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
              <TOKEN startline="7" startpos="32">;</TOKEN>
            </jump_statement>
          </statement>
        </statement_list>
        <TOKEN startline="8" startpos="0">}</TOKEN>
      </compound_statement>
    </function_definition>
  </external_declaration>
  <external_declaration>
    <function_definition>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="10" startpos="0">static</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="10" startpos="7">__inline</TOKEN>
        </gcc_function_specifier>
        <type_specifier>
          <TOKEN startline="10" startpos="16">unsigned</TOKEN>
        </type_specifier>
        <type_specifier>
          <TOKEN startline="10" startpos="25">int</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <declarator>
        <direct_declarator>
          <IDENTIFIER startline="11" startpos="0">bswap_32</IDENTIFIER>
          <declarator_suffix>
            <TOKEN startline="11" startpos="9">(</TOKEN>
            <parameter_type_list>
              <parameter_list>
                <parameter_declaration>
                  <declaration_specifiers>
                    <type_specifier>
                      <TOKEN startline="11" startpos="10">unsigned</TOKEN>
                    </type_specifier>
                    <type_specifier>
                      <TOKEN startline="11" startpos="19">int</TOKEN>
                    </type_specifier>
                  </declaration_specifiers>
                  <declarator>
                    <direct_declarator>
                      <IDENTIFIER startline="11" startpos="23">__x</IDENTIFIER>
                    </direct_declarator>
                  </declarator>
                </parameter_declaration>
              </parameter_list>
            </parameter_type_list>
            <TOKEN startline="11" startpos="26">)</TOKEN>
          </declarator_suffix>
        </direct_declarator>
      </declarator>
      <compound_statement>
        <TOKEN startline="12" startpos="0">{</TOKEN>
        <statement_list>
          <statement>
            <jump_statement>
              <TOKEN startline="13" startpos="2">return</TOKEN>
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
                                                <TOKEN startline="13" startpos="9">(</TOKEN>
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
                                                                                  <IDENTIFIER startline="13" startpos="10">bswap_16</IDENTIFIER>
                                                                                </primary_expression>
                                                                                <TOKEN startline="13" startpos="19">(</TOKEN>
                                                                                <argument_expression_list>
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
                                                                                                                  <IDENTIFIER startline="13" startpos="20">__x</IDENTIFIER>
                                                                                                                </primary_expression>
                                                                                                              </postfix_expression>
                                                                                                            </unary_expression>
                                                                                                          </cast_expression>
                                                                                                        </multiplicative_expression>
                                                                                                      </additive_expression>
                                                                                                    </shift_expression>
                                                                                                  </relational_expression>
                                                                                                </equality_expression>
                                                                                                <TOKEN startline="13" startpos="24">&amp;</TOKEN>
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
                                                                                                                    <hex_literal>
                                                                                                                      <HEX_LITERAL startline="13" startpos="26">0xffff</HEX_LITERAL>
                                                                                                                    </hex_literal>
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
                                                                                </argument_expression_list>
                                                                                <TOKEN startline="13" startpos="32">)</TOKEN>
                                                                              </postfix_expression>
                                                                            </unary_expression>
                                                                          </cast_expression>
                                                                        </multiplicative_expression>
                                                                      </additive_expression>
                                                                      <TOKEN startline="13" startpos="34">&lt;&lt;</TOKEN>
                                                                      <additive_expression>
                                                                        <multiplicative_expression>
                                                                          <cast_expression>
                                                                            <unary_expression>
                                                                              <postfix_expression>
                                                                                <primary_expression>
                                                                                  <constant>
                                                                                    <decimal_literal>
                                                                                      <DECIMAL_LITERAL startline="13" startpos="37">16</DECIMAL_LITERAL>
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
                                                <TOKEN startline="13" startpos="39">)</TOKEN>
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
                          <TOKEN startline="13" startpos="41">|</TOKEN>
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
                                                <TOKEN startline="13" startpos="43">(</TOKEN>
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
                                                                                  <IDENTIFIER startline="13" startpos="44">bswap_16</IDENTIFIER>
                                                                                </primary_expression>
                                                                                <TOKEN startline="13" startpos="53">(</TOKEN>
                                                                                <argument_expression_list>
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
                                                                                                                  <IDENTIFIER startline="13" startpos="54">__x</IDENTIFIER>
                                                                                                                </primary_expression>
                                                                                                              </postfix_expression>
                                                                                                            </unary_expression>
                                                                                                          </cast_expression>
                                                                                                        </multiplicative_expression>
                                                                                                      </additive_expression>
                                                                                                      <TOKEN startline="13" startpos="58">&gt;&gt;</TOKEN>
                                                                                                      <additive_expression>
                                                                                                        <multiplicative_expression>
                                                                                                          <cast_expression>
                                                                                                            <unary_expression>
                                                                                                              <postfix_expression>
                                                                                                                <primary_expression>
                                                                                                                  <constant>
                                                                                                                    <decimal_literal>
                                                                                                                      <DECIMAL_LITERAL startline="13" startpos="61">16</DECIMAL_LITERAL>
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
                                                                                </argument_expression_list>
                                                                                <TOKEN startline="13" startpos="63">)</TOKEN>
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
                                                <TOKEN startline="13" startpos="64">)</TOKEN>
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
              <TOKEN startline="13" startpos="65">;</TOKEN>
            </jump_statement>
          </statement>
        </statement_list>
        <TOKEN startline="14" startpos="0">}</TOKEN>
      </compound_statement>
    </function_definition>
  </external_declaration>
  <external_declaration>
    <function_definition>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="16" startpos="0">static</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="16" startpos="7">__inline</TOKEN>
        </gcc_function_specifier>
        <type_specifier>
          <TOKEN startline="16" startpos="16">unsigned</TOKEN>
        </type_specifier>
        <type_specifier>
          <TOKEN startline="16" startpos="25">long</TOKEN>
        </type_specifier>
        <type_specifier>
          <TOKEN startline="16" startpos="30">long</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <declarator>
        <direct_declarator>
          <IDENTIFIER startline="17" startpos="0">bswap_64</IDENTIFIER>
          <declarator_suffix>
            <TOKEN startline="17" startpos="9">(</TOKEN>
            <parameter_type_list>
              <parameter_list>
                <parameter_declaration>
                  <declaration_specifiers>
                    <type_specifier>
                      <TOKEN startline="17" startpos="10">unsigned</TOKEN>
                    </type_specifier>
                    <type_specifier>
                      <TOKEN startline="17" startpos="19">long</TOKEN>
                    </type_specifier>
                    <type_specifier>
                      <TOKEN startline="17" startpos="24">long</TOKEN>
                    </type_specifier>
                  </declaration_specifiers>
                  <declarator>
                    <direct_declarator>
                      <IDENTIFIER startline="17" startpos="29">__x</IDENTIFIER>
                    </direct_declarator>
                  </declarator>
                </parameter_declaration>
              </parameter_list>
            </parameter_type_list>
            <TOKEN startline="17" startpos="32">)</TOKEN>
          </declarator_suffix>
        </direct_declarator>
      </declarator>
      <compound_statement>
        <TOKEN startline="18" startpos="0">{</TOKEN>
        <statement_list>
          <statement>
            <jump_statement>
              <TOKEN startline="19" startpos="2">return</TOKEN>
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
                                                <TOKEN startline="19" startpos="9">(</TOKEN>
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
                                                                                  <TOKEN startline="19" startpos="10">(</TOKEN>
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
                                                                                                              <TOKEN startline="19" startpos="11">(</TOKEN>
                                                                                                              <type_name>
                                                                                                                <specifier_qualifier_list>
                                                                                                                  <type_specifier>
                                                                                                                    <TOKEN startline="19" startpos="12">unsigned</TOKEN>
                                                                                                                  </type_specifier>
                                                                                                                  <type_specifier>
                                                                                                                    <TOKEN startline="19" startpos="21">long</TOKEN>
                                                                                                                  </type_specifier>
                                                                                                                  <type_specifier>
                                                                                                                    <TOKEN startline="19" startpos="26">long</TOKEN>
                                                                                                                  </type_specifier>
                                                                                                                </specifier_qualifier_list>
                                                                                                              </type_name>
                                                                                                              <TOKEN startline="19" startpos="30">)</TOKEN>
                                                                                                              <cast_expression>
                                                                                                                <unary_expression>
                                                                                                                  <postfix_expression>
                                                                                                                    <primary_expression>
                                                                                                                      <IDENTIFIER startline="19" startpos="32">bswap_32</IDENTIFIER>
                                                                                                                    </primary_expression>
                                                                                                                    <TOKEN startline="19" startpos="41">(</TOKEN>
                                                                                                                    <argument_expression_list>
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
                                                                                                                                                      <IDENTIFIER startline="19" startpos="42">__x</IDENTIFIER>
                                                                                                                                                    </primary_expression>
                                                                                                                                                  </postfix_expression>
                                                                                                                                                </unary_expression>
                                                                                                                                              </cast_expression>
                                                                                                                                            </multiplicative_expression>
                                                                                                                                          </additive_expression>
                                                                                                                                        </shift_expression>
                                                                                                                                      </relational_expression>
                                                                                                                                    </equality_expression>
                                                                                                                                    <TOKEN startline="19" startpos="46">&amp;</TOKEN>
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
                                                                                                                                                        <hex_literal>
                                                                                                                                                          <HEX_LITERAL startline="19" startpos="48">0xffffffffull</HEX_LITERAL>
                                                                                                                                                        </hex_literal>
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
                                                                                                                    </argument_expression_list>
                                                                                                                    <TOKEN startline="19" startpos="61">)</TOKEN>
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
                                                                                  </expression>
                                                                                  <TOKEN startline="19" startpos="62">)</TOKEN>
                                                                                </primary_expression>
                                                                              </postfix_expression>
                                                                            </unary_expression>
                                                                          </cast_expression>
                                                                        </multiplicative_expression>
                                                                      </additive_expression>
                                                                      <TOKEN startline="19" startpos="64">&lt;&lt;</TOKEN>
                                                                      <additive_expression>
                                                                        <multiplicative_expression>
                                                                          <cast_expression>
                                                                            <unary_expression>
                                                                              <postfix_expression>
                                                                                <primary_expression>
                                                                                  <constant>
                                                                                    <decimal_literal>
                                                                                      <DECIMAL_LITERAL startline="19" startpos="67">32</DECIMAL_LITERAL>
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
                                                <TOKEN startline="19" startpos="69">)</TOKEN>
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
                          <TOKEN startline="19" startpos="71">|</TOKEN>
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
                                                <TOKEN startline="19" startpos="73">(</TOKEN>
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
                                                                                  <IDENTIFIER startline="19" startpos="74">bswap_32</IDENTIFIER>
                                                                                </primary_expression>
                                                                                <TOKEN startline="19" startpos="83">(</TOKEN>
                                                                                <argument_expression_list>
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
                                                                                                                  <IDENTIFIER startline="19" startpos="84">__x</IDENTIFIER>
                                                                                                                </primary_expression>
                                                                                                              </postfix_expression>
                                                                                                            </unary_expression>
                                                                                                          </cast_expression>
                                                                                                        </multiplicative_expression>
                                                                                                      </additive_expression>
                                                                                                      <TOKEN startline="19" startpos="88">&gt;&gt;</TOKEN>
                                                                                                      <additive_expression>
                                                                                                        <multiplicative_expression>
                                                                                                          <cast_expression>
                                                                                                            <unary_expression>
                                                                                                              <postfix_expression>
                                                                                                                <primary_expression>
                                                                                                                  <constant>
                                                                                                                    <decimal_literal>
                                                                                                                      <DECIMAL_LITERAL startline="19" startpos="91">32</DECIMAL_LITERAL>
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
                                                                                </argument_expression_list>
                                                                                <TOKEN startline="19" startpos="93">)</TOKEN>
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
                                                <TOKEN startline="19" startpos="94">)</TOKEN>
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
              <TOKEN startline="19" startpos="95">;</TOKEN>
            </jump_statement>
          </statement>
        </statement_list>
        <TOKEN startline="20" startpos="0">}</TOKEN>
      </compound_statement>
    </function_definition>
  </external_declaration>
  <external_declaration>
    <declaration>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="22" startpos="0">extern</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="22" startpos="7">__inline__</TOKEN>
        </gcc_function_specifier>
        <gcc_declaration_specifier>
          <gcc_attribute>
            <TOKEN startline="22" startpos="18">__attribute__</TOKEN>
            <TOKEN startline="22" startpos="32">(</TOKEN>
            <TOKEN startline="22" startpos="33">(</TOKEN>
            <gcc_attribute_parameter_list>
              <gcc_attribute_parameter>
                <gcc_attribute_name>
                  <IDENTIFIER startline="22" startpos="34">__always_inline__</IDENTIFIER>
                </gcc_attribute_name>
              </gcc_attribute_parameter>
            </gcc_attribute_parameter_list>
            <TOKEN startline="22" startpos="51">)</TOKEN>
            <TOKEN startline="22" startpos="52">)</TOKEN>
          </gcc_attribute>
        </gcc_declaration_specifier>
        <type_specifier>
          <TOKEN startline="22" startpos="54">int</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <init_declarator_list>
        <init_declarator>
          <declarator>
            <direct_declarator>
              <IDENTIFIER startline="22" startpos="58">gnu_dev_major</IDENTIFIER>
              <declarator_suffix>
                <TOKEN startline="22" startpos="71">(</TOKEN>
                <parameter_type_list>
                  <parameter_list>
                    <parameter_declaration>
                      <declaration_specifiers>
                        <type_specifier>
                          <type_id>
                            <IDENTIFIER startline="22" startpos="72">dev_t</IDENTIFIER>
                          </type_id>
                        </type_specifier>
                      </declaration_specifiers>
                    </parameter_declaration>
                  </parameter_list>
                </parameter_type_list>
                <TOKEN startline="22" startpos="77">)</TOKEN>
              </declarator_suffix>
            </direct_declarator>
          </declarator>
        </init_declarator>
      </init_declarator_list>
      <TOKEN startline="22" startpos="78">;</TOKEN>
    </declaration>
  </external_declaration>
  <external_declaration>
    <declaration>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="23" startpos="0">extern</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="23" startpos="7">__inline__</TOKEN>
        </gcc_function_specifier>
        <gcc_declaration_specifier>
          <gcc_attribute>
            <TOKEN startline="23" startpos="18">__attribute__</TOKEN>
            <TOKEN startline="23" startpos="32">(</TOKEN>
            <TOKEN startline="23" startpos="33">(</TOKEN>
            <gcc_attribute_parameter_list>
              <gcc_attribute_parameter>
                <gcc_attribute_name>
                  <IDENTIFIER startline="23" startpos="34">__always_inline__</IDENTIFIER>
                </gcc_attribute_name>
              </gcc_attribute_parameter>
            </gcc_attribute_parameter_list>
            <TOKEN startline="23" startpos="51">)</TOKEN>
            <TOKEN startline="23" startpos="52">)</TOKEN>
          </gcc_attribute>
        </gcc_declaration_specifier>
        <type_specifier>
          <TOKEN startline="23" startpos="54">int</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <init_declarator_list>
        <init_declarator>
          <declarator>
            <direct_declarator>
              <IDENTIFIER startline="23" startpos="58">gnu_dev_minor</IDENTIFIER>
              <declarator_suffix>
                <TOKEN startline="23" startpos="71">(</TOKEN>
                <parameter_type_list>
                  <parameter_list>
                    <parameter_declaration>
                      <declaration_specifiers>
                        <type_specifier>
                          <type_id>
                            <IDENTIFIER startline="23" startpos="72">dev_t</IDENTIFIER>
                          </type_id>
                        </type_specifier>
                      </declaration_specifiers>
                    </parameter_declaration>
                  </parameter_list>
                </parameter_type_list>
                <TOKEN startline="23" startpos="77">)</TOKEN>
              </declarator_suffix>
            </direct_declarator>
          </declarator>
        </init_declarator>
      </init_declarator_list>
      <TOKEN startline="23" startpos="78">;</TOKEN>
    </declaration>
  </external_declaration>
  <external_declaration>
    <declaration>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="24" startpos="0">extern</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="24" startpos="7">__inline__</TOKEN>
        </gcc_function_specifier>
        <gcc_declaration_specifier>
          <gcc_attribute>
            <TOKEN startline="24" startpos="18">__attribute__</TOKEN>
            <TOKEN startline="24" startpos="32">(</TOKEN>
            <TOKEN startline="24" startpos="33">(</TOKEN>
            <gcc_attribute_parameter_list>
              <gcc_attribute_parameter>
                <gcc_attribute_name>
                  <IDENTIFIER startline="24" startpos="34">__always_inline__</IDENTIFIER>
                </gcc_attribute_name>
              </gcc_attribute_parameter>
            </gcc_attribute_parameter_list>
            <TOKEN startline="24" startpos="51">)</TOKEN>
            <TOKEN startline="24" startpos="52">)</TOKEN>
          </gcc_attribute>
        </gcc_declaration_specifier>
        <type_specifier>
          <type_id>
            <IDENTIFIER startline="24" startpos="54">dev_t</IDENTIFIER>
          </type_id>
        </type_specifier>
      </declaration_specifiers>
      <init_declarator_list>
        <init_declarator>
          <declarator>
            <direct_declarator>
              <IDENTIFIER startline="24" startpos="60">gnu_dev_makedev</IDENTIFIER>
              <declarator_suffix>
                <TOKEN startline="24" startpos="75">(</TOKEN>
                <parameter_type_list>
                  <parameter_list>
                    <parameter_declaration>
                      <declaration_specifiers>
                        <type_specifier>
                          <TOKEN startline="24" startpos="76">int</TOKEN>
                        </type_specifier>
                      </declaration_specifiers>
                    </parameter_declaration>
                    <TOKEN startline="24" startpos="79">,</TOKEN>
                    <parameter_declaration>
                      <declaration_specifiers>
                        <type_specifier>
                          <TOKEN startline="24" startpos="81">int</TOKEN>
                        </type_specifier>
                      </declaration_specifiers>
                    </parameter_declaration>
                  </parameter_list>
                </parameter_type_list>
                <TOKEN startline="24" startpos="84">)</TOKEN>
              </declarator_suffix>
            </direct_declarator>
          </declarator>
        </init_declarator>
      </init_declarator_list>
      <TOKEN startline="24" startpos="85">;</TOKEN>
    </declaration>
  </external_declaration>
  <external_declaration>
    <function_definition>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="26" startpos="0">extern</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="26" startpos="7">__inline__</TOKEN>
        </gcc_function_specifier>
        <gcc_declaration_specifier>
          <gcc_attribute>
            <TOKEN startline="26" startpos="18">__attribute__</TOKEN>
            <TOKEN startline="26" startpos="32">(</TOKEN>
            <TOKEN startline="26" startpos="33">(</TOKEN>
            <gcc_attribute_parameter_list>
              <gcc_attribute_parameter>
                <gcc_attribute_name>
                  <IDENTIFIER startline="26" startpos="34">__always_inline__</IDENTIFIER>
                </gcc_attribute_name>
              </gcc_attribute_parameter>
            </gcc_attribute_parameter_list>
            <TOKEN startline="26" startpos="51">)</TOKEN>
            <TOKEN startline="26" startpos="52">)</TOKEN>
          </gcc_attribute>
        </gcc_declaration_specifier>
        <type_specifier>
          <TOKEN startline="26" startpos="54">int</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <declarator>
        <direct_declarator>
          <IDENTIFIER startline="27" startpos="0">gnu_dev_major</IDENTIFIER>
          <declarator_suffix>
            <TOKEN startline="27" startpos="13">(</TOKEN>
            <parameter_type_list>
              <parameter_list>
                <parameter_declaration>
                  <declaration_specifiers>
                    <type_specifier>
                      <type_id>
                        <IDENTIFIER startline="27" startpos="14">dev_t</IDENTIFIER>
                      </type_id>
                    </type_specifier>
                  </declaration_specifiers>
                  <declarator>
                    <direct_declarator>
                      <IDENTIFIER startline="27" startpos="20">dev</IDENTIFIER>
                    </direct_declarator>
                  </declarator>
                </parameter_declaration>
              </parameter_list>
            </parameter_type_list>
            <TOKEN startline="27" startpos="23">)</TOKEN>
          </declarator_suffix>
        </direct_declarator>
      </declarator>
      <compound_statement>
        <TOKEN startline="28" startpos="0">{</TOKEN>
        <statement_list>
          <statement>
            <jump_statement>
              <TOKEN startline="29" startpos="1">return</TOKEN>
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
                                          <TOKEN startline="29" startpos="8">(</TOKEN>
                                          <type_name>
                                            <specifier_qualifier_list>
                                              <type_specifier>
                                                <TOKEN startline="29" startpos="9">int</TOKEN>
                                              </type_specifier>
                                            </specifier_qualifier_list>
                                          </type_name>
                                          <TOKEN startline="29" startpos="12">)</TOKEN>
                                          <cast_expression>
                                            <unary_expression>
                                              <postfix_expression>
                                                <primary_expression>
                                                  <TOKEN startline="29" startpos="13">(</TOKEN>
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
                                                                                    <TOKEN startline="29" startpos="14">(</TOKEN>
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
                                                                                                                      <TOKEN startline="29" startpos="15">(</TOKEN>
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
                                                                                                                                                        <IDENTIFIER startline="29" startpos="16">dev</IDENTIFIER>
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
                                                                                                                      <TOKEN startline="29" startpos="19">)</TOKEN>
                                                                                                                    </primary_expression>
                                                                                                                  </postfix_expression>
                                                                                                                </unary_expression>
                                                                                                              </cast_expression>
                                                                                                            </multiplicative_expression>
                                                                                                          </additive_expression>
                                                                                                          <TOKEN startline="29" startpos="21">&gt;&gt;</TOKEN>
                                                                                                          <additive_expression>
                                                                                                            <multiplicative_expression>
                                                                                                              <cast_expression>
                                                                                                                <unary_expression>
                                                                                                                  <postfix_expression>
                                                                                                                    <primary_expression>
                                                                                                                      <constant>
                                                                                                                        <decimal_literal>
                                                                                                                          <DECIMAL_LITERAL startline="29" startpos="24">16</DECIMAL_LITERAL>
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
                                                                                    <TOKEN startline="29" startpos="26">)</TOKEN>
                                                                                  </primary_expression>
                                                                                </postfix_expression>
                                                                              </unary_expression>
                                                                            </cast_expression>
                                                                          </multiplicative_expression>
                                                                        </additive_expression>
                                                                      </shift_expression>
                                                                    </relational_expression>
                                                                  </equality_expression>
                                                                  <TOKEN startline="29" startpos="28">&amp;</TOKEN>
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
                                                                                      <hex_literal>
                                                                                        <HEX_LITERAL startline="29" startpos="30">0xffff</HEX_LITERAL>
                                                                                      </hex_literal>
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
                                                  <TOKEN startline="29" startpos="36">)</TOKEN>
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
              </expression>
              <TOKEN startline="29" startpos="37">;</TOKEN>
            </jump_statement>
          </statement>
        </statement_list>
        <TOKEN startline="30" startpos="0">}</TOKEN>
      </compound_statement>
    </function_definition>
  </external_declaration>
  <external_declaration>
    <function_definition>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="32" startpos="0">extern</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="32" startpos="7">__inline__</TOKEN>
        </gcc_function_specifier>
        <gcc_declaration_specifier>
          <gcc_attribute>
            <TOKEN startline="32" startpos="18">__attribute__</TOKEN>
            <TOKEN startline="32" startpos="32">(</TOKEN>
            <TOKEN startline="32" startpos="33">(</TOKEN>
            <gcc_attribute_parameter_list>
              <gcc_attribute_parameter>
                <gcc_attribute_name>
                  <IDENTIFIER startline="32" startpos="34">__always_inline__</IDENTIFIER>
                </gcc_attribute_name>
              </gcc_attribute_parameter>
            </gcc_attribute_parameter_list>
            <TOKEN startline="32" startpos="51">)</TOKEN>
            <TOKEN startline="32" startpos="52">)</TOKEN>
          </gcc_attribute>
        </gcc_declaration_specifier>
        <type_specifier>
          <TOKEN startline="32" startpos="54">int</TOKEN>
        </type_specifier>
      </declaration_specifiers>
      <declarator>
        <direct_declarator>
          <IDENTIFIER startline="33" startpos="0">gnu_dev_minor</IDENTIFIER>
          <declarator_suffix>
            <TOKEN startline="33" startpos="13">(</TOKEN>
            <parameter_type_list>
              <parameter_list>
                <parameter_declaration>
                  <declaration_specifiers>
                    <type_specifier>
                      <type_id>
                        <IDENTIFIER startline="33" startpos="14">dev_t</IDENTIFIER>
                      </type_id>
                    </type_specifier>
                  </declaration_specifiers>
                  <declarator>
                    <direct_declarator>
                      <IDENTIFIER startline="33" startpos="20">dev</IDENTIFIER>
                    </direct_declarator>
                  </declarator>
                </parameter_declaration>
              </parameter_list>
            </parameter_type_list>
            <TOKEN startline="33" startpos="23">)</TOKEN>
          </declarator_suffix>
        </direct_declarator>
      </declarator>
      <compound_statement>
        <TOKEN startline="34" startpos="0">{</TOKEN>
        <statement_list>
          <statement>
            <jump_statement>
              <TOKEN startline="35" startpos="1">return</TOKEN>
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
                                          <TOKEN startline="35" startpos="8">(</TOKEN>
                                          <type_name>
                                            <specifier_qualifier_list>
                                              <type_specifier>
                                                <TOKEN startline="35" startpos="9">int</TOKEN>
                                              </type_specifier>
                                            </specifier_qualifier_list>
                                          </type_name>
                                          <TOKEN startline="35" startpos="12">)</TOKEN>
                                          <cast_expression>
                                            <unary_expression>
                                              <postfix_expression>
                                                <primary_expression>
                                                  <TOKEN startline="35" startpos="13">(</TOKEN>
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
                                                                                    <TOKEN startline="35" startpos="14">(</TOKEN>
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
                                                                                                                      <IDENTIFIER startline="35" startpos="15">dev</IDENTIFIER>
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
                                                                                    <TOKEN startline="35" startpos="18">)</TOKEN>
                                                                                  </primary_expression>
                                                                                </postfix_expression>
                                                                              </unary_expression>
                                                                            </cast_expression>
                                                                          </multiplicative_expression>
                                                                        </additive_expression>
                                                                      </shift_expression>
                                                                    </relational_expression>
                                                                  </equality_expression>
                                                                  <TOKEN startline="35" startpos="20">&amp;</TOKEN>
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
                                                                                      <hex_literal>
                                                                                        <HEX_LITERAL startline="35" startpos="22">0xffff</HEX_LITERAL>
                                                                                      </hex_literal>
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
                                                  <TOKEN startline="35" startpos="28">)</TOKEN>
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
              </expression>
              <TOKEN startline="35" startpos="29">;</TOKEN>
            </jump_statement>
          </statement>
        </statement_list>
        <TOKEN startline="36" startpos="0">}</TOKEN>
      </compound_statement>
    </function_definition>
  </external_declaration>
  <external_declaration>
    <function_definition>
      <declaration_specifiers>
        <storage_class_specifier>
          <TOKEN startline="38" startpos="0">extern</TOKEN>
        </storage_class_specifier>
        <gcc_function_specifier>
          <TOKEN startline="38" startpos="7">__inline__</TOKEN>
        </gcc_function_specifier>
        <gcc_declaration_specifier>
          <gcc_attribute>
            <TOKEN startline="38" startpos="18">__attribute__</TOKEN>
            <TOKEN startline="38" startpos="32">(</TOKEN>
            <TOKEN startline="38" startpos="33">(</TOKEN>
            <gcc_attribute_parameter_list>
              <gcc_attribute_parameter>
                <gcc_attribute_name>
                  <IDENTIFIER startline="38" startpos="34">__always_inline__</IDENTIFIER>
                </gcc_attribute_name>
              </gcc_attribute_parameter>
            </gcc_attribute_parameter_list>
            <TOKEN startline="38" startpos="51">)</TOKEN>
            <TOKEN startline="38" startpos="52">)</TOKEN>
          </gcc_attribute>
        </gcc_declaration_specifier>
        <type_specifier>
          <type_id>
            <IDENTIFIER startline="38" startpos="54">dev_t</IDENTIFIER>
          </type_id>
        </type_specifier>
      </declaration_specifiers>
      <declarator>
        <direct_declarator>
          <IDENTIFIER startline="39" startpos="0">gnu_dev_makedev</IDENTIFIER>
          <declarator_suffix>
            <TOKEN startline="39" startpos="15">(</TOKEN>
            <parameter_type_list>
              <parameter_list>
                <parameter_declaration>
                  <declaration_specifiers>
                    <type_specifier>
                      <TOKEN startline="39" startpos="16">int</TOKEN>
                    </type_specifier>
                  </declaration_specifiers>
                  <declarator>
                    <direct_declarator>
                      <IDENTIFIER startline="39" startpos="20">maj</IDENTIFIER>
                    </direct_declarator>
                  </declarator>
                </parameter_declaration>
                <TOKEN startline="39" startpos="23">,</TOKEN>
                <parameter_declaration>
                  <declaration_specifiers>
                    <type_specifier>
                      <TOKEN startline="39" startpos="25">int</TOKEN>
                    </type_specifier>
                  </declaration_specifiers>
                  <declarator>
                    <direct_declarator>
                      <IDENTIFIER startline="39" startpos="29">min</IDENTIFIER>
                    </direct_declarator>
                  </declarator>
                </parameter_declaration>
              </parameter_list>
            </parameter_type_list>
            <TOKEN startline="39" startpos="32">)</TOKEN>
          </declarator_suffix>
        </direct_declarator>
      </declarator>
      <compound_statement>
        <TOKEN startline="40" startpos="0">{</TOKEN>
        <statement_list>
          <statement>
            <jump_statement>
              <TOKEN startline="41" startpos="1">return</TOKEN>
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
                                                <TOKEN startline="41" startpos="8">(</TOKEN>
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
                                                                                  <TOKEN startline="41" startpos="9">(</TOKEN>
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
                                                                                                                    <TOKEN startline="41" startpos="10">(</TOKEN>
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
                                                                                                                                                      <IDENTIFIER startline="41" startpos="11">maj</IDENTIFIER>
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
                                                                                                                    <TOKEN startline="41" startpos="14">)</TOKEN>
                                                                                                                  </primary_expression>
                                                                                                                </postfix_expression>
                                                                                                              </unary_expression>
                                                                                                            </cast_expression>
                                                                                                          </multiplicative_expression>
                                                                                                        </additive_expression>
                                                                                                        <TOKEN startline="41" startpos="16">&lt;&lt;</TOKEN>
                                                                                                        <additive_expression>
                                                                                                          <multiplicative_expression>
                                                                                                            <cast_expression>
                                                                                                              <unary_expression>
                                                                                                                <postfix_expression>
                                                                                                                  <primary_expression>
                                                                                                                    <constant>
                                                                                                                      <decimal_literal>
                                                                                                                        <DECIMAL_LITERAL startline="41" startpos="19">16</DECIMAL_LITERAL>
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
                                                                                  <TOKEN startline="41" startpos="21">)</TOKEN>
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
                                                            <TOKEN startline="41" startpos="23">|</TOKEN>
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
                                                                                  <TOKEN startline="41" startpos="25">(</TOKEN>
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
                                                                                                                    <TOKEN startline="41" startpos="26">(</TOKEN>
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
                                                                                                                                                      <IDENTIFIER startline="41" startpos="27">min</IDENTIFIER>
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
                                                                                                                    <TOKEN startline="41" startpos="30">)</TOKEN>
                                                                                                                  </primary_expression>
                                                                                                                </postfix_expression>
                                                                                                              </unary_expression>
                                                                                                            </cast_expression>
                                                                                                          </multiplicative_expression>
                                                                                                        </additive_expression>
                                                                                                      </shift_expression>
                                                                                                    </relational_expression>
                                                                                                  </equality_expression>
                                                                                                  <TOKEN startline="41" startpos="32">&amp;</TOKEN>
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
                                                                                                                      <hex_literal>
                                                                                                                        <HEX_LITERAL startline="41" startpos="34">0xffff</HEX_LITERAL>
                                                                                                                      </hex_literal>
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
                                                                                  <TOKEN startline="41" startpos="40">)</TOKEN>
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
                                                <TOKEN startline="41" startpos="41">)</TOKEN>
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
              <TOKEN startline="41" startpos="42">;</TOKEN>
            </jump_statement>
          </statement>
        </statement_list>
        <TOKEN startline="42" startpos="0">}</TOKEN>
      </compound_statement>
    </function_definition>
  </external_declaration>
</translation_unit>