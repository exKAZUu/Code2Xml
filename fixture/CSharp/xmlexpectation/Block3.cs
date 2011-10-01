<compilation_unit>
  <using_directives>
    <using_directive>
      <using_namespace_directive>
        <USING startline="1" startpos="0">using</USING>
        <namespace_name>
          <namespace_or_type_name>
            <identifier>
              <IDENTIFIER startline="1" startpos="6">System</IDENTIFIER>
            </identifier>
          </namespace_or_type_name>
        </namespace_name>
        <SEMI startline="1" startpos="12">;</SEMI>
      </using_namespace_directive>
    </using_directive>
    <using_directive>
      <using_namespace_directive>
        <USING startline="2" startpos="0">using</USING>
        <namespace_name>
          <namespace_or_type_name>
            <identifier>
              <IDENTIFIER startline="2" startpos="6">System</IDENTIFIER>
            </identifier>
            <DOT startline="2" startpos="12">.</DOT>
            <identifier>
              <IDENTIFIER startline="2" startpos="13">Collections</IDENTIFIER>
            </identifier>
            <DOT startline="2" startpos="24">.</DOT>
            <identifier>
              <IDENTIFIER startline="2" startpos="25">Generic</IDENTIFIER>
            </identifier>
          </namespace_or_type_name>
        </namespace_name>
        <SEMI startline="2" startpos="32">;</SEMI>
      </using_namespace_directive>
    </using_directive>
    <using_directive>
      <using_namespace_directive>
        <USING startline="3" startpos="0">using</USING>
        <namespace_name>
          <namespace_or_type_name>
            <identifier>
              <IDENTIFIER startline="3" startpos="6">System</IDENTIFIER>
            </identifier>
            <DOT startline="3" startpos="12">.</DOT>
            <identifier>
              <IDENTIFIER startline="3" startpos="13">Linq</IDENTIFIER>
            </identifier>
          </namespace_or_type_name>
        </namespace_name>
        <SEMI startline="3" startpos="17">;</SEMI>
      </using_namespace_directive>
    </using_directive>
    <using_directive>
      <using_namespace_directive>
        <USING startline="4" startpos="0">using</USING>
        <namespace_name>
          <namespace_or_type_name>
            <identifier>
              <IDENTIFIER startline="4" startpos="6">System</IDENTIFIER>
            </identifier>
            <DOT startline="4" startpos="12">.</DOT>
            <identifier>
              <IDENTIFIER startline="4" startpos="13">Text</IDENTIFIER>
            </identifier>
          </namespace_or_type_name>
        </namespace_name>
        <SEMI startline="4" startpos="17">;</SEMI>
      </using_namespace_directive>
    </using_directive>
  </using_directives>
  <namespace_declaration>
    <TOKEN startline="6" startpos="0">namespace</TOKEN>
    <qualified_identifier>
      <identifier>
        <IDENTIFIER startline="6" startpos="10">Code2XmlTest</IDENTIFIER>
      </identifier>
    </qualified_identifier>
    <namespace_block>
      <TOKEN startline="7" startpos="0">{</TOKEN>
      <namespace_body>
        <namespace_member_declarations>
          <namespace_member_declaration>
            <type_declaration>
              <class_declaration>
                <TOKEN startline="8" startpos="1">class</TOKEN>
                <identifier>
                  <IDENTIFIER startline="8" startpos="7">Block3</IDENTIFIER>
                </identifier>
                <class_body>
                  <TOKEN startline="9" startpos="1">{</TOKEN>
                  <class_member_declarations>
                    <class_member_declaration>
                      <method_declaration>
                        <method_header>
                          <method_modifiers>
                            <method_modifier>
                              <TOKEN startline="10" startpos="2">public</TOKEN>
                            </method_modifier>
                          </method_modifiers>
                          <return_type>
                            <TOKEN startline="10" startpos="9">void</TOKEN>
                          </return_type>
                          <member_name>
                            <qid>
                              <qid_start>
                                <identifier>
                                  <IDENTIFIER startline="10" startpos="14">method3</IDENTIFIER>
                                </identifier>
                              </qid_start>
                            </qid>
                          </member_name>
                          <TOKEN startline="10" startpos="21">(</TOKEN>
                          <RPAREN startline="10" startpos="22">)</RPAREN>
                        </method_header>
                        <method_body>
                          <block>
                            <TOKEN startline="11" startpos="2">{</TOKEN>
                            <statement_list>
                              <statement>
                                <declaration_statement>
                                  <local_variable_declaration>
                                    <local_variable_type>
                                      <type>
                                        <predefined_type>
                                          <TOKEN startline="12" startpos="3">int</TOKEN>
                                        </predefined_type>
                                      </type>
                                    </local_variable_type>
                                    <local_variable_declarators>
                                      <local_variable_declarator>
                                        <identifier>
                                          <IDENTIFIER startline="12" startpos="7">i</IDENTIFIER>
                                        </identifier>
                                        <TOKEN startline="12" startpos="9">=</TOKEN>
                                        <local_variable_initializer>
                                          <expression>
                                            <non_assignment_expression>
                                              <conditional_expression>
                                                <null_coalescing_expression>
                                                  <conditional_or_expression>
                                                    <conditional_and_expression>
                                                      <inclusive_or_expression>
                                                        <exclusive_or_expression>
                                                          <and_expression>
                                                            <equality_expression>
                                                              <relational_expression>
                                                                <shift_expression>
                                                                  <additive_expression>
                                                                    <multiplicative_expression>
                                                                      <unary_expression>
                                                                        <primary_or_array_creation_expression>
                                                                          <primary_expression>
                                                                            <primary_expression_start>
                                                                              <literal>
                                                                                <TOKEN startline="12" startpos="11">0</TOKEN>
                                                                              </literal>
                                                                            </primary_expression_start>
                                                                          </primary_expression>
                                                                        </primary_or_array_creation_expression>
                                                                      </unary_expression>
                                                                    </multiplicative_expression>
                                                                  </additive_expression>
                                                                </shift_expression>
                                                              </relational_expression>
                                                            </equality_expression>
                                                          </and_expression>
                                                        </exclusive_or_expression>
                                                      </inclusive_or_expression>
                                                    </conditional_and_expression>
                                                  </conditional_or_expression>
                                                </null_coalescing_expression>
                                              </conditional_expression>
                                            </non_assignment_expression>
                                          </expression>
                                        </local_variable_initializer>
                                      </local_variable_declarator>
                                    </local_variable_declarators>
                                  </local_variable_declaration>
                                  <SEMI startline="12" startpos="12">;</SEMI>
                                </declaration_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <selection_statement>
                                    <if_statement>
                                      <IF startline="14" startpos="3">if</IF>
                                      <TOKEN startline="14" startpos="6">(</TOKEN>
                                      <boolean_expression>
                                        <expression>
                                          <non_assignment_expression>
                                            <conditional_expression>
                                              <null_coalescing_expression>
                                                <conditional_or_expression>
                                                  <conditional_and_expression>
                                                    <inclusive_or_expression>
                                                      <exclusive_or_expression>
                                                        <and_expression>
                                                          <equality_expression>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <identifier>
                                                                              <IDENTIFIER startline="14" startpos="7">i</IDENTIFIER>
                                                                            </identifier>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                            <TOKEN startline="14" startpos="9">==</TOKEN>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <literal>
                                                                              <TOKEN startline="14" startpos="12">0</TOKEN>
                                                                            </literal>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                          </equality_expression>
                                                        </and_expression>
                                                      </exclusive_or_expression>
                                                    </inclusive_or_expression>
                                                  </conditional_and_expression>
                                                </conditional_or_expression>
                                              </null_coalescing_expression>
                                            </conditional_expression>
                                          </non_assignment_expression>
                                        </expression>
                                      </boolean_expression>
                                      <RPAREN startline="14" startpos="13">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <SEMI startline="14" startpos="15">;</SEMI>
                                        </block>
                                      </embedded_statement>
                                    </if_statement>
                                  </selection_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <while_statement>
                                      <TOKEN startline="16" startpos="3">while</TOKEN>
                                      <TOKEN startline="16" startpos="9">(</TOKEN>
                                      <boolean_expression>
                                        <expression>
                                          <non_assignment_expression>
                                            <conditional_expression>
                                              <null_coalescing_expression>
                                                <conditional_or_expression>
                                                  <conditional_and_expression>
                                                    <inclusive_or_expression>
                                                      <exclusive_or_expression>
                                                        <and_expression>
                                                          <equality_expression>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <identifier>
                                                                              <IDENTIFIER startline="16" startpos="10">i</IDENTIFIER>
                                                                            </identifier>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                            <TOKEN startline="16" startpos="12">!=</TOKEN>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <literal>
                                                                              <TOKEN startline="16" startpos="15">0</TOKEN>
                                                                            </literal>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                          </equality_expression>
                                                        </and_expression>
                                                      </exclusive_or_expression>
                                                    </inclusive_or_expression>
                                                  </conditional_and_expression>
                                                </conditional_or_expression>
                                              </null_coalescing_expression>
                                            </conditional_expression>
                                          </non_assignment_expression>
                                        </expression>
                                      </boolean_expression>
                                      <RPAREN startline="16" startpos="16">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <SEMI startline="16" startpos="18">;</SEMI>
                                        </block>
                                      </embedded_statement>
                                    </while_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <do_statement>
                                      <TOKEN startline="18" startpos="3">do</TOKEN>
                                      <embedded_statement>
                                        <block>
                                          <SEMI startline="18" startpos="6">;</SEMI>
                                        </block>
                                      </embedded_statement>
                                      <TOKEN startline="18" startpos="8">while</TOKEN>
                                      <TOKEN startline="18" startpos="14">(</TOKEN>
                                      <boolean_expression>
                                        <expression>
                                          <non_assignment_expression>
                                            <conditional_expression>
                                              <null_coalescing_expression>
                                                <conditional_or_expression>
                                                  <conditional_and_expression>
                                                    <inclusive_or_expression>
                                                      <exclusive_or_expression>
                                                        <and_expression>
                                                          <equality_expression>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <identifier>
                                                                              <IDENTIFIER startline="18" startpos="15">i</IDENTIFIER>
                                                                            </identifier>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                            <TOKEN startline="18" startpos="17">!=</TOKEN>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <literal>
                                                                              <TOKEN startline="18" startpos="20">0</TOKEN>
                                                                            </literal>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                          </equality_expression>
                                                        </and_expression>
                                                      </exclusive_or_expression>
                                                    </inclusive_or_expression>
                                                  </conditional_and_expression>
                                                </conditional_or_expression>
                                              </null_coalescing_expression>
                                            </conditional_expression>
                                          </non_assignment_expression>
                                        </expression>
                                      </boolean_expression>
                                      <RPAREN startline="18" startpos="21">)</RPAREN>
                                      <SEMI startline="18" startpos="22">;</SEMI>
                                    </do_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <for_statement>
                                      <TOKEN startline="20" startpos="3">for</TOKEN>
                                      <TOKEN startline="20" startpos="7">(</TOKEN>
                                      <for_initializer>
                                        <statement_expression_list>
                                          <statement_expression>
                                            <assignment>
                                              <unary_expression>
                                                <primary_or_array_creation_expression>
                                                  <primary_expression>
                                                    <primary_expression_start>
                                                      <identifier>
                                                        <IDENTIFIER startline="20" startpos="8">i</IDENTIFIER>
                                                      </identifier>
                                                    </primary_expression_start>
                                                  </primary_expression>
                                                </primary_or_array_creation_expression>
                                              </unary_expression>
                                              <assignment_operator>
                                                <TOKEN startline="20" startpos="10">=</TOKEN>
                                              </assignment_operator>
                                              <expression>
                                                <non_assignment_expression>
                                                  <conditional_expression>
                                                    <null_coalescing_expression>
                                                      <conditional_or_expression>
                                                        <conditional_and_expression>
                                                          <inclusive_or_expression>
                                                            <exclusive_or_expression>
                                                              <and_expression>
                                                                <equality_expression>
                                                                  <relational_expression>
                                                                    <shift_expression>
                                                                      <additive_expression>
                                                                        <multiplicative_expression>
                                                                          <unary_expression>
                                                                            <primary_or_array_creation_expression>
                                                                              <primary_expression>
                                                                                <primary_expression_start>
                                                                                  <literal>
                                                                                    <TOKEN startline="20" startpos="12">0</TOKEN>
                                                                                  </literal>
                                                                                </primary_expression_start>
                                                                              </primary_expression>
                                                                            </primary_or_array_creation_expression>
                                                                          </unary_expression>
                                                                        </multiplicative_expression>
                                                                      </additive_expression>
                                                                    </shift_expression>
                                                                  </relational_expression>
                                                                </equality_expression>
                                                              </and_expression>
                                                            </exclusive_or_expression>
                                                          </inclusive_or_expression>
                                                        </conditional_and_expression>
                                                      </conditional_or_expression>
                                                    </null_coalescing_expression>
                                                  </conditional_expression>
                                                </non_assignment_expression>
                                              </expression>
                                            </assignment>
                                          </statement_expression>
                                        </statement_expression_list>
                                      </for_initializer>
                                      <SEMI startline="20" startpos="13">;</SEMI>
                                      <for_condition>
                                        <boolean_expression>
                                          <expression>
                                            <non_assignment_expression>
                                              <conditional_expression>
                                                <null_coalescing_expression>
                                                  <conditional_or_expression>
                                                    <conditional_and_expression>
                                                      <inclusive_or_expression>
                                                        <exclusive_or_expression>
                                                          <and_expression>
                                                            <equality_expression>
                                                              <relational_expression>
                                                                <shift_expression>
                                                                  <additive_expression>
                                                                    <multiplicative_expression>
                                                                      <unary_expression>
                                                                        <primary_or_array_creation_expression>
                                                                          <primary_expression>
                                                                            <primary_expression_start>
                                                                              <identifier>
                                                                                <IDENTIFIER startline="20" startpos="15">i</IDENTIFIER>
                                                                              </identifier>
                                                                            </primary_expression_start>
                                                                          </primary_expression>
                                                                        </primary_or_array_creation_expression>
                                                                      </unary_expression>
                                                                    </multiplicative_expression>
                                                                  </additive_expression>
                                                                </shift_expression>
                                                                <TOKEN startline="20" startpos="17">&lt;</TOKEN>
                                                                <shift_expression>
                                                                  <additive_expression>
                                                                    <multiplicative_expression>
                                                                      <unary_expression>
                                                                        <primary_or_array_creation_expression>
                                                                          <primary_expression>
                                                                            <primary_expression_start>
                                                                              <literal>
                                                                                <TOKEN startline="20" startpos="19">0</TOKEN>
                                                                              </literal>
                                                                            </primary_expression_start>
                                                                          </primary_expression>
                                                                        </primary_or_array_creation_expression>
                                                                      </unary_expression>
                                                                    </multiplicative_expression>
                                                                  </additive_expression>
                                                                </shift_expression>
                                                              </relational_expression>
                                                            </equality_expression>
                                                          </and_expression>
                                                        </exclusive_or_expression>
                                                      </inclusive_or_expression>
                                                    </conditional_and_expression>
                                                  </conditional_or_expression>
                                                </null_coalescing_expression>
                                              </conditional_expression>
                                            </non_assignment_expression>
                                          </expression>
                                        </boolean_expression>
                                      </for_condition>
                                      <SEMI startline="20" startpos="20">;</SEMI>
                                      <for_iterator>
                                        <statement_expression_list>
                                          <statement_expression>
                                            <unary_expression>
                                              <primary_or_array_creation_expression>
                                                <primary_expression>
                                                  <primary_expression_start>
                                                    <identifier>
                                                      <IDENTIFIER startline="20" startpos="22">i</IDENTIFIER>
                                                    </identifier>
                                                  </primary_expression_start>
                                                </primary_expression>
                                              </primary_or_array_creation_expression>
                                              <TOKEN startline="20" startpos="23">++</TOKEN>
                                            </unary_expression>
                                          </statement_expression>
                                        </statement_expression_list>
                                      </for_iterator>
                                      <RPAREN startline="20" startpos="25">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <SEMI startline="20" startpos="27">;</SEMI>
                                        </block>
                                      </embedded_statement>
                                    </for_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <foreach_statement>
                                      <TOKEN startline="22" startpos="3">foreach</TOKEN>
                                      <TOKEN startline="22" startpos="11">(</TOKEN>
                                      <local_variable_type>
                                        <type>
                                          <type_name>
                                            <namespace_or_type_name>
                                              <identifier>
                                                <also_keyword>
                                                  <TOKEN startline="22" startpos="12">var</TOKEN>
                                                </also_keyword>
                                              </identifier>
                                            </namespace_or_type_name>
                                          </type_name>
                                        </type>
                                      </local_variable_type>
                                      <identifier>
                                        <IDENTIFIER startline="22" startpos="16">j</IDENTIFIER>
                                      </identifier>
                                      <TOKEN startline="22" startpos="18">in</TOKEN>
                                      <expression>
                                        <non_assignment_expression>
                                          <conditional_expression>
                                            <null_coalescing_expression>
                                              <conditional_or_expression>
                                                <conditional_and_expression>
                                                  <inclusive_or_expression>
                                                    <exclusive_or_expression>
                                                      <and_expression>
                                                        <equality_expression>
                                                          <relational_expression>
                                                            <shift_expression>
                                                              <additive_expression>
                                                                <multiplicative_expression>
                                                                  <unary_expression>
                                                                    <primary_or_array_creation_expression>
                                                                      <array_creation_expression>
                                                                        <TOKEN startline="22" startpos="21">new</TOKEN>
                                                                        <rank_specifier>
                                                                          <TOKEN startline="22" startpos="24">[</TOKEN>
                                                                          <TOKEN startline="22" startpos="25">]</TOKEN>
                                                                        </rank_specifier>
                                                                        <array_initializer>
                                                                          <TOKEN startline="22" startpos="27">{</TOKEN>
                                                                          <variable_initializer_list>
                                                                            <variable_initializer>
                                                                              <expression>
                                                                                <non_assignment_expression>
                                                                                  <conditional_expression>
                                                                                    <null_coalescing_expression>
                                                                                      <conditional_or_expression>
                                                                                        <conditional_and_expression>
                                                                                          <inclusive_or_expression>
                                                                                            <exclusive_or_expression>
                                                                                              <and_expression>
                                                                                                <equality_expression>
                                                                                                  <relational_expression>
                                                                                                    <shift_expression>
                                                                                                      <additive_expression>
                                                                                                        <multiplicative_expression>
                                                                                                          <unary_expression>
                                                                                                            <primary_or_array_creation_expression>
                                                                                                              <primary_expression>
                                                                                                                <primary_expression_start>
                                                                                                                  <literal>
                                                                                                                    <TOKEN startline="22" startpos="29">1</TOKEN>
                                                                                                                  </literal>
                                                                                                                </primary_expression_start>
                                                                                                              </primary_expression>
                                                                                                            </primary_or_array_creation_expression>
                                                                                                          </unary_expression>
                                                                                                        </multiplicative_expression>
                                                                                                      </additive_expression>
                                                                                                    </shift_expression>
                                                                                                  </relational_expression>
                                                                                                </equality_expression>
                                                                                              </and_expression>
                                                                                            </exclusive_or_expression>
                                                                                          </inclusive_or_expression>
                                                                                        </conditional_and_expression>
                                                                                      </conditional_or_expression>
                                                                                    </null_coalescing_expression>
                                                                                  </conditional_expression>
                                                                                </non_assignment_expression>
                                                                              </expression>
                                                                            </variable_initializer>
                                                                            <TOKEN startline="22" startpos="30">,</TOKEN>
                                                                            <variable_initializer>
                                                                              <expression>
                                                                                <non_assignment_expression>
                                                                                  <conditional_expression>
                                                                                    <null_coalescing_expression>
                                                                                      <conditional_or_expression>
                                                                                        <conditional_and_expression>
                                                                                          <inclusive_or_expression>
                                                                                            <exclusive_or_expression>
                                                                                              <and_expression>
                                                                                                <equality_expression>
                                                                                                  <relational_expression>
                                                                                                    <shift_expression>
                                                                                                      <additive_expression>
                                                                                                        <multiplicative_expression>
                                                                                                          <unary_expression>
                                                                                                            <primary_or_array_creation_expression>
                                                                                                              <primary_expression>
                                                                                                                <primary_expression_start>
                                                                                                                  <literal>
                                                                                                                    <TOKEN startline="22" startpos="32">2</TOKEN>
                                                                                                                  </literal>
                                                                                                                </primary_expression_start>
                                                                                                              </primary_expression>
                                                                                                            </primary_or_array_creation_expression>
                                                                                                          </unary_expression>
                                                                                                        </multiplicative_expression>
                                                                                                      </additive_expression>
                                                                                                    </shift_expression>
                                                                                                  </relational_expression>
                                                                                                </equality_expression>
                                                                                              </and_expression>
                                                                                            </exclusive_or_expression>
                                                                                          </inclusive_or_expression>
                                                                                        </conditional_and_expression>
                                                                                      </conditional_or_expression>
                                                                                    </null_coalescing_expression>
                                                                                  </conditional_expression>
                                                                                </non_assignment_expression>
                                                                              </expression>
                                                                            </variable_initializer>
                                                                          </variable_initializer_list>
                                                                          <TOKEN startline="22" startpos="34">}</TOKEN>
                                                                        </array_initializer>
                                                                      </array_creation_expression>
                                                                    </primary_or_array_creation_expression>
                                                                  </unary_expression>
                                                                </multiplicative_expression>
                                                              </additive_expression>
                                                            </shift_expression>
                                                          </relational_expression>
                                                        </equality_expression>
                                                      </and_expression>
                                                    </exclusive_or_expression>
                                                  </inclusive_or_expression>
                                                </conditional_and_expression>
                                              </conditional_or_expression>
                                            </null_coalescing_expression>
                                          </conditional_expression>
                                        </non_assignment_expression>
                                      </expression>
                                      <RPAREN startline="22" startpos="35">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <SEMI startline="22" startpos="37">;</SEMI>
                                        </block>
                                      </embedded_statement>
                                    </foreach_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <declaration_statement>
                                  <local_variable_declaration>
                                    <local_variable_type>
                                      <type>
                                        <type_name>
                                          <namespace_or_type_name>
                                            <identifier>
                                              <IDENTIFIER startline="24" startpos="3">Action</IDENTIFIER>
                                            </identifier>
                                          </namespace_or_type_name>
                                        </type_name>
                                      </type>
                                    </local_variable_type>
                                    <local_variable_declarators>
                                      <local_variable_declarator>
                                        <identifier>
                                          <IDENTIFIER startline="24" startpos="10">act</IDENTIFIER>
                                        </identifier>
                                        <TOKEN startline="24" startpos="14">=</TOKEN>
                                        <local_variable_initializer>
                                          <expression>
                                            <non_assignment_expression>
                                              <lambda_expression>
                                                <anonymous_function_signature>
                                                  <explicit_anonymous_function_signature>
                                                    <TOKEN startline="24" startpos="16">(</TOKEN>
                                                    <RPAREN startline="24" startpos="17">)</RPAREN>
                                                  </explicit_anonymous_function_signature>
                                                </anonymous_function_signature>
                                                <TOKEN startline="24" startpos="19">=&gt;</TOKEN>
                                                <anonymous_function_body>
                                                  <expression>
                                                    <non_assignment_expression>
                                                      <conditional_expression>
                                                        <null_coalescing_expression>
                                                          <conditional_or_expression>
                                                            <conditional_and_expression>
                                                              <inclusive_or_expression>
                                                                <exclusive_or_expression>
                                                                  <and_expression>
                                                                    <equality_expression>
                                                                      <relational_expression>
                                                                        <shift_expression>
                                                                          <additive_expression>
                                                                            <multiplicative_expression>
                                                                              <unary_expression>
                                                                                <primary_or_array_creation_expression>
                                                                                  <primary_expression>
                                                                                    <primary_expression_start>
                                                                                      <identifier>
                                                                                        <IDENTIFIER startline="24" startpos="22">Console</IDENTIFIER>
                                                                                      </identifier>
                                                                                    </primary_expression_start>
                                                                                    <primary_expression_part>
                                                                                      <access_identifier>
                                                                                        <access_operator>
                                                                                          <TOKEN startline="24" startpos="29">.</TOKEN>
                                                                                        </access_operator>
                                                                                        <identifier>
                                                                                          <IDENTIFIER startline="24" startpos="30">WriteLine</IDENTIFIER>
                                                                                        </identifier>
                                                                                      </access_identifier>
                                                                                      <brackets_or_arguments>
                                                                                        <arguments>
                                                                                          <TOKEN startline="24" startpos="39">(</TOKEN>
                                                                                          <argument_list>
                                                                                            <argument>
                                                                                              <argument_value>
                                                                                                <expression>
                                                                                                  <non_assignment_expression>
                                                                                                    <conditional_expression>
                                                                                                      <null_coalescing_expression>
                                                                                                        <conditional_or_expression>
                                                                                                          <conditional_and_expression>
                                                                                                            <inclusive_or_expression>
                                                                                                              <exclusive_or_expression>
                                                                                                                <and_expression>
                                                                                                                  <equality_expression>
                                                                                                                    <relational_expression>
                                                                                                                      <shift_expression>
                                                                                                                        <additive_expression>
                                                                                                                          <multiplicative_expression>
                                                                                                                            <unary_expression>
                                                                                                                              <primary_or_array_creation_expression>
                                                                                                                                <primary_expression>
                                                                                                                                  <primary_expression_start>
                                                                                                                                    <identifier>
                                                                                                                                      <IDENTIFIER startline="24" startpos="40">i</IDENTIFIER>
                                                                                                                                    </identifier>
                                                                                                                                  </primary_expression_start>
                                                                                                                                </primary_expression>
                                                                                                                              </primary_or_array_creation_expression>
                                                                                                                            </unary_expression>
                                                                                                                          </multiplicative_expression>
                                                                                                                        </additive_expression>
                                                                                                                      </shift_expression>
                                                                                                                    </relational_expression>
                                                                                                                  </equality_expression>
                                                                                                                </and_expression>
                                                                                                              </exclusive_or_expression>
                                                                                                            </inclusive_or_expression>
                                                                                                          </conditional_and_expression>
                                                                                                        </conditional_or_expression>
                                                                                                      </null_coalescing_expression>
                                                                                                    </conditional_expression>
                                                                                                  </non_assignment_expression>
                                                                                                </expression>
                                                                                              </argument_value>
                                                                                            </argument>
                                                                                          </argument_list>
                                                                                          <RPAREN startline="24" startpos="41">)</RPAREN>
                                                                                        </arguments>
                                                                                      </brackets_or_arguments>
                                                                                    </primary_expression_part>
                                                                                  </primary_expression>
                                                                                </primary_or_array_creation_expression>
                                                                              </unary_expression>
                                                                            </multiplicative_expression>
                                                                          </additive_expression>
                                                                        </shift_expression>
                                                                      </relational_expression>
                                                                    </equality_expression>
                                                                  </and_expression>
                                                                </exclusive_or_expression>
                                                              </inclusive_or_expression>
                                                            </conditional_and_expression>
                                                          </conditional_or_expression>
                                                        </null_coalescing_expression>
                                                      </conditional_expression>
                                                    </non_assignment_expression>
                                                  </expression>
                                                </anonymous_function_body>
                                              </lambda_expression>
                                            </non_assignment_expression>
                                          </expression>
                                        </local_variable_initializer>
                                      </local_variable_declarator>
                                    </local_variable_declarators>
                                  </local_variable_declaration>
                                  <SEMI startline="24" startpos="42">;</SEMI>
                                </declaration_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <selection_statement>
                                    <if_statement>
                                      <IF startline="26" startpos="3">if</IF>
                                      <TOKEN startline="26" startpos="6">(</TOKEN>
                                      <boolean_expression>
                                        <expression>
                                          <non_assignment_expression>
                                            <conditional_expression>
                                              <null_coalescing_expression>
                                                <conditional_or_expression>
                                                  <conditional_and_expression>
                                                    <inclusive_or_expression>
                                                      <exclusive_or_expression>
                                                        <and_expression>
                                                          <equality_expression>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <identifier>
                                                                              <IDENTIFIER startline="26" startpos="7">i</IDENTIFIER>
                                                                            </identifier>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                            <TOKEN startline="26" startpos="9">==</TOKEN>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <literal>
                                                                              <TOKEN startline="26" startpos="12">0</TOKEN>
                                                                            </literal>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                          </equality_expression>
                                                        </and_expression>
                                                      </exclusive_or_expression>
                                                    </inclusive_or_expression>
                                                  </conditional_and_expression>
                                                </conditional_or_expression>
                                              </null_coalescing_expression>
                                            </conditional_expression>
                                          </non_assignment_expression>
                                        </expression>
                                      </boolean_expression>
                                      <RPAREN startline="26" startpos="13">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <TOKEN startline="27" startpos="3">{</TOKEN>
                                          <TOKEN startline="28" startpos="3">}</TOKEN>
                                        </block>
                                      </embedded_statement>
                                    </if_statement>
                                  </selection_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <selection_statement>
                                    <switch_statement>
                                      <TOKEN startline="30" startpos="3">switch</TOKEN>
                                      <TOKEN startline="30" startpos="10">(</TOKEN>
                                      <expression>
                                        <non_assignment_expression>
                                          <conditional_expression>
                                            <null_coalescing_expression>
                                              <conditional_or_expression>
                                                <conditional_and_expression>
                                                  <inclusive_or_expression>
                                                    <exclusive_or_expression>
                                                      <and_expression>
                                                        <equality_expression>
                                                          <relational_expression>
                                                            <shift_expression>
                                                              <additive_expression>
                                                                <multiplicative_expression>
                                                                  <unary_expression>
                                                                    <primary_or_array_creation_expression>
                                                                      <primary_expression>
                                                                        <primary_expression_start>
                                                                          <identifier>
                                                                            <IDENTIFIER startline="30" startpos="11">i</IDENTIFIER>
                                                                          </identifier>
                                                                        </primary_expression_start>
                                                                      </primary_expression>
                                                                    </primary_or_array_creation_expression>
                                                                  </unary_expression>
                                                                </multiplicative_expression>
                                                              </additive_expression>
                                                            </shift_expression>
                                                          </relational_expression>
                                                        </equality_expression>
                                                      </and_expression>
                                                    </exclusive_or_expression>
                                                  </inclusive_or_expression>
                                                </conditional_and_expression>
                                              </conditional_or_expression>
                                            </null_coalescing_expression>
                                          </conditional_expression>
                                        </non_assignment_expression>
                                      </expression>
                                      <RPAREN startline="30" startpos="12">)</RPAREN>
                                      <switch_block>
                                        <TOKEN startline="31" startpos="3">{</TOKEN>
                                        <TOKEN startline="32" startpos="3">}</TOKEN>
                                      </switch_block>
                                    </switch_statement>
                                  </selection_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <while_statement>
                                      <TOKEN startline="34" startpos="3">while</TOKEN>
                                      <TOKEN startline="34" startpos="9">(</TOKEN>
                                      <boolean_expression>
                                        <expression>
                                          <non_assignment_expression>
                                            <conditional_expression>
                                              <null_coalescing_expression>
                                                <conditional_or_expression>
                                                  <conditional_and_expression>
                                                    <inclusive_or_expression>
                                                      <exclusive_or_expression>
                                                        <and_expression>
                                                          <equality_expression>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <identifier>
                                                                              <IDENTIFIER startline="34" startpos="10">i</IDENTIFIER>
                                                                            </identifier>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                            <TOKEN startline="34" startpos="12">!=</TOKEN>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <literal>
                                                                              <TOKEN startline="34" startpos="15">0</TOKEN>
                                                                            </literal>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                          </equality_expression>
                                                        </and_expression>
                                                      </exclusive_or_expression>
                                                    </inclusive_or_expression>
                                                  </conditional_and_expression>
                                                </conditional_or_expression>
                                              </null_coalescing_expression>
                                            </conditional_expression>
                                          </non_assignment_expression>
                                        </expression>
                                      </boolean_expression>
                                      <RPAREN startline="34" startpos="16">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <TOKEN startline="35" startpos="3">{</TOKEN>
                                          <TOKEN startline="36" startpos="3">}</TOKEN>
                                        </block>
                                      </embedded_statement>
                                    </while_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <do_statement>
                                      <TOKEN startline="38" startpos="3">do</TOKEN>
                                      <embedded_statement>
                                        <block>
                                          <TOKEN startline="39" startpos="3">{</TOKEN>
                                          <TOKEN startline="40" startpos="3">}</TOKEN>
                                        </block>
                                      </embedded_statement>
                                      <TOKEN startline="40" startpos="5">while</TOKEN>
                                      <TOKEN startline="40" startpos="11">(</TOKEN>
                                      <boolean_expression>
                                        <expression>
                                          <non_assignment_expression>
                                            <conditional_expression>
                                              <null_coalescing_expression>
                                                <conditional_or_expression>
                                                  <conditional_and_expression>
                                                    <inclusive_or_expression>
                                                      <exclusive_or_expression>
                                                        <and_expression>
                                                          <equality_expression>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <identifier>
                                                                              <IDENTIFIER startline="40" startpos="12">i</IDENTIFIER>
                                                                            </identifier>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                            <TOKEN startline="40" startpos="14">!=</TOKEN>
                                                            <relational_expression>
                                                              <shift_expression>
                                                                <additive_expression>
                                                                  <multiplicative_expression>
                                                                    <unary_expression>
                                                                      <primary_or_array_creation_expression>
                                                                        <primary_expression>
                                                                          <primary_expression_start>
                                                                            <literal>
                                                                              <TOKEN startline="40" startpos="17">0</TOKEN>
                                                                            </literal>
                                                                          </primary_expression_start>
                                                                        </primary_expression>
                                                                      </primary_or_array_creation_expression>
                                                                    </unary_expression>
                                                                  </multiplicative_expression>
                                                                </additive_expression>
                                                              </shift_expression>
                                                            </relational_expression>
                                                          </equality_expression>
                                                        </and_expression>
                                                      </exclusive_or_expression>
                                                    </inclusive_or_expression>
                                                  </conditional_and_expression>
                                                </conditional_or_expression>
                                              </null_coalescing_expression>
                                            </conditional_expression>
                                          </non_assignment_expression>
                                        </expression>
                                      </boolean_expression>
                                      <RPAREN startline="40" startpos="18">)</RPAREN>
                                      <SEMI startline="40" startpos="19">;</SEMI>
                                    </do_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <for_statement>
                                      <TOKEN startline="42" startpos="3">for</TOKEN>
                                      <TOKEN startline="42" startpos="7">(</TOKEN>
                                      <for_initializer>
                                        <statement_expression_list>
                                          <statement_expression>
                                            <assignment>
                                              <unary_expression>
                                                <primary_or_array_creation_expression>
                                                  <primary_expression>
                                                    <primary_expression_start>
                                                      <identifier>
                                                        <IDENTIFIER startline="42" startpos="8">i</IDENTIFIER>
                                                      </identifier>
                                                    </primary_expression_start>
                                                  </primary_expression>
                                                </primary_or_array_creation_expression>
                                              </unary_expression>
                                              <assignment_operator>
                                                <TOKEN startline="42" startpos="10">=</TOKEN>
                                              </assignment_operator>
                                              <expression>
                                                <non_assignment_expression>
                                                  <conditional_expression>
                                                    <null_coalescing_expression>
                                                      <conditional_or_expression>
                                                        <conditional_and_expression>
                                                          <inclusive_or_expression>
                                                            <exclusive_or_expression>
                                                              <and_expression>
                                                                <equality_expression>
                                                                  <relational_expression>
                                                                    <shift_expression>
                                                                      <additive_expression>
                                                                        <multiplicative_expression>
                                                                          <unary_expression>
                                                                            <primary_or_array_creation_expression>
                                                                              <primary_expression>
                                                                                <primary_expression_start>
                                                                                  <literal>
                                                                                    <TOKEN startline="42" startpos="12">0</TOKEN>
                                                                                  </literal>
                                                                                </primary_expression_start>
                                                                              </primary_expression>
                                                                            </primary_or_array_creation_expression>
                                                                          </unary_expression>
                                                                        </multiplicative_expression>
                                                                      </additive_expression>
                                                                    </shift_expression>
                                                                  </relational_expression>
                                                                </equality_expression>
                                                              </and_expression>
                                                            </exclusive_or_expression>
                                                          </inclusive_or_expression>
                                                        </conditional_and_expression>
                                                      </conditional_or_expression>
                                                    </null_coalescing_expression>
                                                  </conditional_expression>
                                                </non_assignment_expression>
                                              </expression>
                                            </assignment>
                                          </statement_expression>
                                        </statement_expression_list>
                                      </for_initializer>
                                      <SEMI startline="42" startpos="13">;</SEMI>
                                      <for_condition>
                                        <boolean_expression>
                                          <expression>
                                            <non_assignment_expression>
                                              <conditional_expression>
                                                <null_coalescing_expression>
                                                  <conditional_or_expression>
                                                    <conditional_and_expression>
                                                      <inclusive_or_expression>
                                                        <exclusive_or_expression>
                                                          <and_expression>
                                                            <equality_expression>
                                                              <relational_expression>
                                                                <shift_expression>
                                                                  <additive_expression>
                                                                    <multiplicative_expression>
                                                                      <unary_expression>
                                                                        <primary_or_array_creation_expression>
                                                                          <primary_expression>
                                                                            <primary_expression_start>
                                                                              <identifier>
                                                                                <IDENTIFIER startline="42" startpos="15">i</IDENTIFIER>
                                                                              </identifier>
                                                                            </primary_expression_start>
                                                                          </primary_expression>
                                                                        </primary_or_array_creation_expression>
                                                                      </unary_expression>
                                                                    </multiplicative_expression>
                                                                  </additive_expression>
                                                                </shift_expression>
                                                                <TOKEN startline="42" startpos="17">&lt;</TOKEN>
                                                                <shift_expression>
                                                                  <additive_expression>
                                                                    <multiplicative_expression>
                                                                      <unary_expression>
                                                                        <primary_or_array_creation_expression>
                                                                          <primary_expression>
                                                                            <primary_expression_start>
                                                                              <literal>
                                                                                <TOKEN startline="42" startpos="19">0</TOKEN>
                                                                              </literal>
                                                                            </primary_expression_start>
                                                                          </primary_expression>
                                                                        </primary_or_array_creation_expression>
                                                                      </unary_expression>
                                                                    </multiplicative_expression>
                                                                  </additive_expression>
                                                                </shift_expression>
                                                              </relational_expression>
                                                            </equality_expression>
                                                          </and_expression>
                                                        </exclusive_or_expression>
                                                      </inclusive_or_expression>
                                                    </conditional_and_expression>
                                                  </conditional_or_expression>
                                                </null_coalescing_expression>
                                              </conditional_expression>
                                            </non_assignment_expression>
                                          </expression>
                                        </boolean_expression>
                                      </for_condition>
                                      <SEMI startline="42" startpos="20">;</SEMI>
                                      <for_iterator>
                                        <statement_expression_list>
                                          <statement_expression>
                                            <unary_expression>
                                              <primary_or_array_creation_expression>
                                                <primary_expression>
                                                  <primary_expression_start>
                                                    <identifier>
                                                      <IDENTIFIER startline="42" startpos="22">i</IDENTIFIER>
                                                    </identifier>
                                                  </primary_expression_start>
                                                </primary_expression>
                                              </primary_or_array_creation_expression>
                                              <TOKEN startline="42" startpos="23">++</TOKEN>
                                            </unary_expression>
                                          </statement_expression>
                                        </statement_expression_list>
                                      </for_iterator>
                                      <RPAREN startline="42" startpos="25">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <TOKEN startline="43" startpos="3">{</TOKEN>
                                          <TOKEN startline="44" startpos="3">}</TOKEN>
                                        </block>
                                      </embedded_statement>
                                    </for_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <embedded_statement>
                                  <iteration_statement>
                                    <foreach_statement>
                                      <TOKEN startline="46" startpos="3">foreach</TOKEN>
                                      <TOKEN startline="46" startpos="11">(</TOKEN>
                                      <local_variable_type>
                                        <type>
                                          <type_name>
                                            <namespace_or_type_name>
                                              <identifier>
                                                <also_keyword>
                                                  <TOKEN startline="46" startpos="12">var</TOKEN>
                                                </also_keyword>
                                              </identifier>
                                            </namespace_or_type_name>
                                          </type_name>
                                        </type>
                                      </local_variable_type>
                                      <identifier>
                                        <IDENTIFIER startline="46" startpos="16">j</IDENTIFIER>
                                      </identifier>
                                      <TOKEN startline="46" startpos="18">in</TOKEN>
                                      <expression>
                                        <non_assignment_expression>
                                          <conditional_expression>
                                            <null_coalescing_expression>
                                              <conditional_or_expression>
                                                <conditional_and_expression>
                                                  <inclusive_or_expression>
                                                    <exclusive_or_expression>
                                                      <and_expression>
                                                        <equality_expression>
                                                          <relational_expression>
                                                            <shift_expression>
                                                              <additive_expression>
                                                                <multiplicative_expression>
                                                                  <unary_expression>
                                                                    <primary_or_array_creation_expression>
                                                                      <array_creation_expression>
                                                                        <TOKEN startline="46" startpos="21">new</TOKEN>
                                                                        <rank_specifier>
                                                                          <TOKEN startline="46" startpos="24">[</TOKEN>
                                                                          <TOKEN startline="46" startpos="25">]</TOKEN>
                                                                        </rank_specifier>
                                                                        <array_initializer>
                                                                          <TOKEN startline="46" startpos="27">{</TOKEN>
                                                                          <variable_initializer_list>
                                                                            <variable_initializer>
                                                                              <expression>
                                                                                <non_assignment_expression>
                                                                                  <conditional_expression>
                                                                                    <null_coalescing_expression>
                                                                                      <conditional_or_expression>
                                                                                        <conditional_and_expression>
                                                                                          <inclusive_or_expression>
                                                                                            <exclusive_or_expression>
                                                                                              <and_expression>
                                                                                                <equality_expression>
                                                                                                  <relational_expression>
                                                                                                    <shift_expression>
                                                                                                      <additive_expression>
                                                                                                        <multiplicative_expression>
                                                                                                          <unary_expression>
                                                                                                            <primary_or_array_creation_expression>
                                                                                                              <primary_expression>
                                                                                                                <primary_expression_start>
                                                                                                                  <literal>
                                                                                                                    <TOKEN startline="46" startpos="29">1</TOKEN>
                                                                                                                  </literal>
                                                                                                                </primary_expression_start>
                                                                                                              </primary_expression>
                                                                                                            </primary_or_array_creation_expression>
                                                                                                          </unary_expression>
                                                                                                        </multiplicative_expression>
                                                                                                      </additive_expression>
                                                                                                    </shift_expression>
                                                                                                  </relational_expression>
                                                                                                </equality_expression>
                                                                                              </and_expression>
                                                                                            </exclusive_or_expression>
                                                                                          </inclusive_or_expression>
                                                                                        </conditional_and_expression>
                                                                                      </conditional_or_expression>
                                                                                    </null_coalescing_expression>
                                                                                  </conditional_expression>
                                                                                </non_assignment_expression>
                                                                              </expression>
                                                                            </variable_initializer>
                                                                            <TOKEN startline="46" startpos="30">,</TOKEN>
                                                                            <variable_initializer>
                                                                              <expression>
                                                                                <non_assignment_expression>
                                                                                  <conditional_expression>
                                                                                    <null_coalescing_expression>
                                                                                      <conditional_or_expression>
                                                                                        <conditional_and_expression>
                                                                                          <inclusive_or_expression>
                                                                                            <exclusive_or_expression>
                                                                                              <and_expression>
                                                                                                <equality_expression>
                                                                                                  <relational_expression>
                                                                                                    <shift_expression>
                                                                                                      <additive_expression>
                                                                                                        <multiplicative_expression>
                                                                                                          <unary_expression>
                                                                                                            <primary_or_array_creation_expression>
                                                                                                              <primary_expression>
                                                                                                                <primary_expression_start>
                                                                                                                  <literal>
                                                                                                                    <TOKEN startline="46" startpos="32">2</TOKEN>
                                                                                                                  </literal>
                                                                                                                </primary_expression_start>
                                                                                                              </primary_expression>
                                                                                                            </primary_or_array_creation_expression>
                                                                                                          </unary_expression>
                                                                                                        </multiplicative_expression>
                                                                                                      </additive_expression>
                                                                                                    </shift_expression>
                                                                                                  </relational_expression>
                                                                                                </equality_expression>
                                                                                              </and_expression>
                                                                                            </exclusive_or_expression>
                                                                                          </inclusive_or_expression>
                                                                                        </conditional_and_expression>
                                                                                      </conditional_or_expression>
                                                                                    </null_coalescing_expression>
                                                                                  </conditional_expression>
                                                                                </non_assignment_expression>
                                                                              </expression>
                                                                            </variable_initializer>
                                                                          </variable_initializer_list>
                                                                          <TOKEN startline="46" startpos="34">}</TOKEN>
                                                                        </array_initializer>
                                                                      </array_creation_expression>
                                                                    </primary_or_array_creation_expression>
                                                                  </unary_expression>
                                                                </multiplicative_expression>
                                                              </additive_expression>
                                                            </shift_expression>
                                                          </relational_expression>
                                                        </equality_expression>
                                                      </and_expression>
                                                    </exclusive_or_expression>
                                                  </inclusive_or_expression>
                                                </conditional_and_expression>
                                              </conditional_or_expression>
                                            </null_coalescing_expression>
                                          </conditional_expression>
                                        </non_assignment_expression>
                                      </expression>
                                      <RPAREN startline="46" startpos="35">)</RPAREN>
                                      <embedded_statement>
                                        <block>
                                          <TOKEN startline="47" startpos="3">{</TOKEN>
                                          <TOKEN startline="48" startpos="3">}</TOKEN>
                                        </block>
                                      </embedded_statement>
                                    </foreach_statement>
                                  </iteration_statement>
                                </embedded_statement>
                              </statement>
                              <statement>
                                <declaration_statement>
                                  <local_variable_declaration>
                                    <local_variable_type>
                                      <type>
                                        <type_name>
                                          <namespace_or_type_name>
                                            <identifier>
                                              <IDENTIFIER startline="50" startpos="3">Action</IDENTIFIER>
                                            </identifier>
                                          </namespace_or_type_name>
                                        </type_name>
                                      </type>
                                    </local_variable_type>
                                    <local_variable_declarators>
                                      <local_variable_declarator>
                                        <identifier>
                                          <IDENTIFIER startline="50" startpos="10">act1</IDENTIFIER>
                                        </identifier>
                                        <TOKEN startline="50" startpos="15">=</TOKEN>
                                        <local_variable_initializer>
                                          <expression>
                                            <non_assignment_expression>
                                              <lambda_expression>
                                                <anonymous_function_signature>
                                                  <explicit_anonymous_function_signature>
                                                    <TOKEN startline="50" startpos="17">(</TOKEN>
                                                    <RPAREN startline="50" startpos="18">)</RPAREN>
                                                  </explicit_anonymous_function_signature>
                                                </anonymous_function_signature>
                                                <TOKEN startline="50" startpos="20">=&gt;</TOKEN>
                                                <anonymous_function_body>
                                                  <block>
                                                    <TOKEN startline="50" startpos="23">{</TOKEN>
                                                    <statement_list>
                                                      <statement>
                                                        <embedded_statement>
                                                          <expression_statement>
                                                            <expression>
                                                              <non_assignment_expression>
                                                                <conditional_expression>
                                                                  <null_coalescing_expression>
                                                                    <conditional_or_expression>
                                                                      <conditional_and_expression>
                                                                        <inclusive_or_expression>
                                                                          <exclusive_or_expression>
                                                                            <and_expression>
                                                                              <equality_expression>
                                                                                <relational_expression>
                                                                                  <shift_expression>
                                                                                    <additive_expression>
                                                                                      <multiplicative_expression>
                                                                                        <unary_expression>
                                                                                          <primary_or_array_creation_expression>
                                                                                            <primary_expression>
                                                                                              <primary_expression_start>
                                                                                                <identifier>
                                                                                                  <IDENTIFIER startline="51" startpos="4">Console</IDENTIFIER>
                                                                                                </identifier>
                                                                                              </primary_expression_start>
                                                                                              <primary_expression_part>
                                                                                                <access_identifier>
                                                                                                  <access_operator>
                                                                                                    <TOKEN startline="51" startpos="11">.</TOKEN>
                                                                                                  </access_operator>
                                                                                                  <identifier>
                                                                                                    <IDENTIFIER startline="51" startpos="12">WriteLine</IDENTIFIER>
                                                                                                  </identifier>
                                                                                                </access_identifier>
                                                                                                <brackets_or_arguments>
                                                                                                  <arguments>
                                                                                                    <TOKEN startline="51" startpos="21">(</TOKEN>
                                                                                                    <argument_list>
                                                                                                      <argument>
                                                                                                        <argument_value>
                                                                                                          <expression>
                                                                                                            <non_assignment_expression>
                                                                                                              <conditional_expression>
                                                                                                                <null_coalescing_expression>
                                                                                                                  <conditional_or_expression>
                                                                                                                    <conditional_and_expression>
                                                                                                                      <inclusive_or_expression>
                                                                                                                        <exclusive_or_expression>
                                                                                                                          <and_expression>
                                                                                                                            <equality_expression>
                                                                                                                              <relational_expression>
                                                                                                                                <shift_expression>
                                                                                                                                  <additive_expression>
                                                                                                                                    <multiplicative_expression>
                                                                                                                                      <unary_expression>
                                                                                                                                        <primary_or_array_creation_expression>
                                                                                                                                          <primary_expression>
                                                                                                                                            <primary_expression_start>
                                                                                                                                              <identifier>
                                                                                                                                                <IDENTIFIER startline="51" startpos="22">i</IDENTIFIER>
                                                                                                                                              </identifier>
                                                                                                                                            </primary_expression_start>
                                                                                                                                          </primary_expression>
                                                                                                                                        </primary_or_array_creation_expression>
                                                                                                                                      </unary_expression>
                                                                                                                                    </multiplicative_expression>
                                                                                                                                  </additive_expression>
                                                                                                                                </shift_expression>
                                                                                                                              </relational_expression>
                                                                                                                            </equality_expression>
                                                                                                                          </and_expression>
                                                                                                                        </exclusive_or_expression>
                                                                                                                      </inclusive_or_expression>
                                                                                                                    </conditional_and_expression>
                                                                                                                  </conditional_or_expression>
                                                                                                                </null_coalescing_expression>
                                                                                                              </conditional_expression>
                                                                                                            </non_assignment_expression>
                                                                                                          </expression>
                                                                                                        </argument_value>
                                                                                                      </argument>
                                                                                                    </argument_list>
                                                                                                    <RPAREN startline="51" startpos="23">)</RPAREN>
                                                                                                  </arguments>
                                                                                                </brackets_or_arguments>
                                                                                              </primary_expression_part>
                                                                                            </primary_expression>
                                                                                          </primary_or_array_creation_expression>
                                                                                        </unary_expression>
                                                                                      </multiplicative_expression>
                                                                                    </additive_expression>
                                                                                  </shift_expression>
                                                                                </relational_expression>
                                                                              </equality_expression>
                                                                            </and_expression>
                                                                          </exclusive_or_expression>
                                                                        </inclusive_or_expression>
                                                                      </conditional_and_expression>
                                                                    </conditional_or_expression>
                                                                  </null_coalescing_expression>
                                                                </conditional_expression>
                                                              </non_assignment_expression>
                                                            </expression>
                                                            <SEMI startline="51" startpos="24">;</SEMI>
                                                          </expression_statement>
                                                        </embedded_statement>
                                                      </statement>
                                                    </statement_list>
                                                    <TOKEN startline="52" startpos="3">}</TOKEN>
                                                  </block>
                                                </anonymous_function_body>
                                              </lambda_expression>
                                            </non_assignment_expression>
                                          </expression>
                                        </local_variable_initializer>
                                      </local_variable_declarator>
                                    </local_variable_declarators>
                                  </local_variable_declaration>
                                  <SEMI startline="52" startpos="4">;</SEMI>
                                </declaration_statement>
                              </statement>
                              <statement>
                                <declaration_statement>
                                  <local_variable_declaration>
                                    <local_variable_type>
                                      <type>
                                        <type_name>
                                          <namespace_or_type_name>
                                            <identifier>
                                              <IDENTIFIER startline="54" startpos="3">Action</IDENTIFIER>
                                            </identifier>
                                          </namespace_or_type_name>
                                        </type_name>
                                      </type>
                                    </local_variable_type>
                                    <local_variable_declarators>
                                      <local_variable_declarator>
                                        <identifier>
                                          <IDENTIFIER startline="54" startpos="10">act2</IDENTIFIER>
                                        </identifier>
                                        <TOKEN startline="54" startpos="15">=</TOKEN>
                                        <local_variable_initializer>
                                          <expression>
                                            <non_assignment_expression>
                                              <conditional_expression>
                                                <null_coalescing_expression>
                                                  <conditional_or_expression>
                                                    <conditional_and_expression>
                                                      <inclusive_or_expression>
                                                        <exclusive_or_expression>
                                                          <and_expression>
                                                            <equality_expression>
                                                              <relational_expression>
                                                                <shift_expression>
                                                                  <additive_expression>
                                                                    <multiplicative_expression>
                                                                      <unary_expression>
                                                                        <primary_or_array_creation_expression>
                                                                          <primary_expression>
                                                                            <anonymous_method_expression>
                                                                              <TOKEN startline="54" startpos="17">delegate</TOKEN>
                                                                              <block>
                                                                                <TOKEN startline="54" startpos="26">{</TOKEN>
                                                                                <statement_list>
                                                                                  <statement>
                                                                                    <embedded_statement>
                                                                                      <expression_statement>
                                                                                        <expression>
                                                                                          <non_assignment_expression>
                                                                                            <conditional_expression>
                                                                                              <null_coalescing_expression>
                                                                                                <conditional_or_expression>
                                                                                                  <conditional_and_expression>
                                                                                                    <inclusive_or_expression>
                                                                                                      <exclusive_or_expression>
                                                                                                        <and_expression>
                                                                                                          <equality_expression>
                                                                                                            <relational_expression>
                                                                                                              <shift_expression>
                                                                                                                <additive_expression>
                                                                                                                  <multiplicative_expression>
                                                                                                                    <unary_expression>
                                                                                                                      <primary_or_array_creation_expression>
                                                                                                                        <primary_expression>
                                                                                                                          <primary_expression_start>
                                                                                                                            <identifier>
                                                                                                                              <IDENTIFIER startline="55" startpos="4">Console</IDENTIFIER>
                                                                                                                            </identifier>
                                                                                                                          </primary_expression_start>
                                                                                                                          <primary_expression_part>
                                                                                                                            <access_identifier>
                                                                                                                              <access_operator>
                                                                                                                                <TOKEN startline="55" startpos="11">.</TOKEN>
                                                                                                                              </access_operator>
                                                                                                                              <identifier>
                                                                                                                                <IDENTIFIER startline="55" startpos="12">WriteLine</IDENTIFIER>
                                                                                                                              </identifier>
                                                                                                                            </access_identifier>
                                                                                                                            <brackets_or_arguments>
                                                                                                                              <arguments>
                                                                                                                                <TOKEN startline="55" startpos="21">(</TOKEN>
                                                                                                                                <argument_list>
                                                                                                                                  <argument>
                                                                                                                                    <argument_value>
                                                                                                                                      <expression>
                                                                                                                                        <non_assignment_expression>
                                                                                                                                          <conditional_expression>
                                                                                                                                            <null_coalescing_expression>
                                                                                                                                              <conditional_or_expression>
                                                                                                                                                <conditional_and_expression>
                                                                                                                                                  <inclusive_or_expression>
                                                                                                                                                    <exclusive_or_expression>
                                                                                                                                                      <and_expression>
                                                                                                                                                        <equality_expression>
                                                                                                                                                          <relational_expression>
                                                                                                                                                            <shift_expression>
                                                                                                                                                              <additive_expression>
                                                                                                                                                                <multiplicative_expression>
                                                                                                                                                                  <unary_expression>
                                                                                                                                                                    <primary_or_array_creation_expression>
                                                                                                                                                                      <primary_expression>
                                                                                                                                                                        <primary_expression_start>
                                                                                                                                                                          <identifier>
                                                                                                                                                                            <IDENTIFIER startline="55" startpos="22">i</IDENTIFIER>
                                                                                                                                                                          </identifier>
                                                                                                                                                                        </primary_expression_start>
                                                                                                                                                                      </primary_expression>
                                                                                                                                                                    </primary_or_array_creation_expression>
                                                                                                                                                                  </unary_expression>
                                                                                                                                                                </multiplicative_expression>
                                                                                                                                                              </additive_expression>
                                                                                                                                                            </shift_expression>
                                                                                                                                                          </relational_expression>
                                                                                                                                                        </equality_expression>
                                                                                                                                                      </and_expression>
                                                                                                                                                    </exclusive_or_expression>
                                                                                                                                                  </inclusive_or_expression>
                                                                                                                                                </conditional_and_expression>
                                                                                                                                              </conditional_or_expression>
                                                                                                                                            </null_coalescing_expression>
                                                                                                                                          </conditional_expression>
                                                                                                                                        </non_assignment_expression>
                                                                                                                                      </expression>
                                                                                                                                    </argument_value>
                                                                                                                                  </argument>
                                                                                                                                </argument_list>
                                                                                                                                <RPAREN startline="55" startpos="23">)</RPAREN>
                                                                                                                              </arguments>
                                                                                                                            </brackets_or_arguments>
                                                                                                                          </primary_expression_part>
                                                                                                                        </primary_expression>
                                                                                                                      </primary_or_array_creation_expression>
                                                                                                                    </unary_expression>
                                                                                                                  </multiplicative_expression>
                                                                                                                </additive_expression>
                                                                                                              </shift_expression>
                                                                                                            </relational_expression>
                                                                                                          </equality_expression>
                                                                                                        </and_expression>
                                                                                                      </exclusive_or_expression>
                                                                                                    </inclusive_or_expression>
                                                                                                  </conditional_and_expression>
                                                                                                </conditional_or_expression>
                                                                                              </null_coalescing_expression>
                                                                                            </conditional_expression>
                                                                                          </non_assignment_expression>
                                                                                        </expression>
                                                                                        <SEMI startline="55" startpos="24">;</SEMI>
                                                                                      </expression_statement>
                                                                                    </embedded_statement>
                                                                                  </statement>
                                                                                </statement_list>
                                                                                <TOKEN startline="56" startpos="3">}</TOKEN>
                                                                              </block>
                                                                            </anonymous_method_expression>
                                                                          </primary_expression>
                                                                        </primary_or_array_creation_expression>
                                                                      </unary_expression>
                                                                    </multiplicative_expression>
                                                                  </additive_expression>
                                                                </shift_expression>
                                                              </relational_expression>
                                                            </equality_expression>
                                                          </and_expression>
                                                        </exclusive_or_expression>
                                                      </inclusive_or_expression>
                                                    </conditional_and_expression>
                                                  </conditional_or_expression>
                                                </null_coalescing_expression>
                                              </conditional_expression>
                                            </non_assignment_expression>
                                          </expression>
                                        </local_variable_initializer>
                                      </local_variable_declarator>
                                    </local_variable_declarators>
                                  </local_variable_declaration>
                                  <SEMI startline="56" startpos="4">;</SEMI>
                                </declaration_statement>
                              </statement>
                            </statement_list>
                            <TOKEN startline="57" startpos="2">}</TOKEN>
                          </block>
                        </method_body>
                      </method_declaration>
                    </class_member_declaration>
                  </class_member_declarations>
                  <TOKEN startline="58" startpos="1">}</TOKEN>
                </class_body>
              </class_declaration>
            </type_declaration>
          </namespace_member_declaration>
        </namespace_member_declarations>
      </namespace_body>
      <TOKEN startline="59" startpos="0">}</TOKEN>
    </namespace_block>
  </namespace_declaration>
  <namespace_body />
</compilation_unit>