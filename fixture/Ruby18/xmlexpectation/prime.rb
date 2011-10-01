<block startline="1">
  <defn startline="1">
    <Symbol>prime_table</Symbol>
    <args startline="1">
      <Symbol>max</Symbol>
    </args>
    <scope startline="11">
      <block startline="2">
        <lasgn startline="2">
          <Symbol>result</Symbol>
          <call startline="2">
            <const startline="2">
              <Symbol>Array</Symbol>
            </const>
            <Symbol>new</Symbol>
            <arglist startline="2">
              <call startline="2">
                <lvar startline="2">
                  <Symbol>max</Symbol>
                </lvar>
                <Symbol>+</Symbol>
                <arglist startline="2">
                  <lit startline="2">
                    <Fixnum>1</Fixnum>
                  </lit>
                </arglist>
              </call>
              <true startline="2" />
            </arglist>
          </call>
        </lasgn>
        <attrasgn startline="3">
          <lvar startline="3">
            <Symbol>result</Symbol>
          </lvar>
          <Symbol>[]=</Symbol>
          <arglist startline="3">
            <lit startline="3">
              <Fixnum>0</Fixnum>
            </lit>
            <attrasgn startline="3">
              <lvar startline="3">
                <Symbol>result</Symbol>
              </lvar>
              <Symbol>[]=</Symbol>
              <arglist startline="3">
                <lit startline="3">
                  <Fixnum>1</Fixnum>
                </lit>
                <false startline="4" />
              </arglist>
            </attrasgn>
          </arglist>
        </attrasgn>
        <iter startline="4">
          <call startline="4">
            <dot2 startline="4">
              <lit startline="4">
                <Fixnum>2</Fixnum>
              </lit>
              <call startline="4">
                <call startline="4">
                  <const startline="4">
                    <Symbol>Math</Symbol>
                  </const>
                  <Symbol>sqrt</Symbol>
                  <arglist startline="4">
                    <lvar startline="4">
                      <Symbol>max</Symbol>
                    </lvar>
                  </arglist>
                </call>
                <Symbol>ceil</Symbol>
                <arglist startline="4" />
              </call>
            </dot2>
            <Symbol>each</Symbol>
            <arglist startline="4" />
          </call>
          <lasgn startline="4">
            <Symbol>i</Symbol>
          </lasgn>
          <block startline="5">
            <if startline="5">
              <call startline="5">
                <lvar startline="5">
                  <Symbol>result</Symbol>
                </lvar>
                <Symbol>[]</Symbol>
                <arglist startline="5">
                  <lvar startline="5">
                    <Symbol>i</Symbol>
                  </lvar>
                </arglist>
              </call>
              <block />
              <block>
                <next startline="5" />
              </block>
            </if>
            <iter startline="6">
              <call startline="6">
                <call startline="6">
                  <lvar startline="6">
                    <Symbol>i</Symbol>
                  </lvar>
                  <Symbol>*</Symbol>
                  <arglist startline="6">
                    <lit startline="6">
                      <Fixnum>2</Fixnum>
                    </lit>
                  </arglist>
                </call>
                <Symbol>step</Symbol>
                <arglist startline="6">
                  <lvar startline="6">
                    <Symbol>max</Symbol>
                  </lvar>
                  <lvar startline="6">
                    <Symbol>i</Symbol>
                  </lvar>
                </arglist>
              </call>
              <lasgn startline="6">
                <Symbol>j</Symbol>
              </lasgn>
              <block>
                <attrasgn startline="7">
                  <lvar startline="7">
                    <Symbol>result</Symbol>
                  </lvar>
                  <Symbol>[]=</Symbol>
                  <arglist startline="7">
                    <lvar startline="7">
                      <Symbol>j</Symbol>
                    </lvar>
                    <false startline="8" />
                  </arglist>
                </attrasgn>
              </block>
            </iter>
          </block>
        </iter>
        <lvar startline="11">
          <Symbol>result</Symbol>
        </lvar>
      </block>
    </scope>
  </defn>
  <defn startline="13">
    <Symbol>prime_list</Symbol>
    <args startline="13">
      <Symbol>table</Symbol>
    </args>
    <scope startline="19">
      <block startline="14">
        <lasgn startline="14">
          <Symbol>result</Symbol>
          <array startline="14" />
        </lasgn>
        <iter startline="15">
          <call startline="15">
            <lvar startline="15">
              <Symbol>table</Symbol>
            </lvar>
            <Symbol>each_with_index</Symbol>
            <arglist startline="15" />
          </call>
          <masgn startline="15">
            <array startline="15">
              <lasgn startline="15">
                <Symbol>b</Symbol>
              </lasgn>
              <lasgn startline="15">
                <Symbol>i</Symbol>
              </lasgn>
            </array>
          </masgn>
          <block>
            <if startline="16">
              <lvar startline="17">
                <Symbol>b</Symbol>
              </lvar>
              <block>
                <call startline="16">
                  <lvar startline="16">
                    <Symbol>result</Symbol>
                  </lvar>
                  <Symbol>&lt;&lt;</Symbol>
                  <arglist startline="16">
                    <lvar startline="16">
                      <Symbol>i</Symbol>
                    </lvar>
                  </arglist>
                </call>
              </block>
              <block />
            </if>
          </block>
        </iter>
        <lvar startline="19">
          <Symbol>result</Symbol>
        </lvar>
      </block>
    </scope>
  </defn>
  <defn startline="21">
    <Symbol>prime_check_table</Symbol>
    <args startline="21">
      <Symbol>min</Symbol>
      <Symbol>max</Symbol>
      <Symbol>primes</Symbol>
    </args>
    <scope startline="33">
      <block startline="22">
        <lasgn startline="22">
          <Symbol>result</Symbol>
          <call startline="22">
            <const startline="22">
              <Symbol>Array</Symbol>
            </const>
            <Symbol>new</Symbol>
            <arglist startline="22">
              <call startline="22">
                <call startline="22">
                  <lvar startline="22">
                    <Symbol>max</Symbol>
                  </lvar>
                  <Symbol>-</Symbol>
                  <arglist startline="22">
                    <lvar startline="22">
                      <Symbol>min</Symbol>
                    </lvar>
                  </arglist>
                </call>
                <Symbol>+</Symbol>
                <arglist startline="22">
                  <lit startline="22">
                    <Fixnum>1</Fixnum>
                  </lit>
                </arglist>
              </call>
              <true startline="22" />
            </arglist>
          </call>
        </lasgn>
        <if startline="23">
          <call startline="23">
            <lvar startline="23">
              <Symbol>min</Symbol>
            </lvar>
            <Symbol>==</Symbol>
            <arglist startline="24">
              <lit startline="23">
                <Fixnum>1</Fixnum>
              </lit>
            </arglist>
          </call>
          <block>
            <attrasgn startline="23">
              <lvar startline="23">
                <Symbol>result</Symbol>
              </lvar>
              <Symbol>[]=</Symbol>
              <arglist startline="23">
                <lit startline="23">
                  <Fixnum>0</Fixnum>
                </lit>
                <false startline="23" />
              </arglist>
            </attrasgn>
          </block>
          <block />
        </if>
        <lasgn startline="24">
          <Symbol>maxsq</Symbol>
          <call startline="24">
            <call startline="24">
              <const startline="24">
                <Symbol>Math</Symbol>
              </const>
              <Symbol>sqrt</Symbol>
              <arglist startline="24">
                <lvar startline="24">
                  <Symbol>max</Symbol>
                </lvar>
              </arglist>
            </call>
            <Symbol>ceil</Symbol>
            <arglist startline="25" />
          </call>
        </lasgn>
        <lasgn startline="25">
          <Symbol>i</Symbol>
          <lit startline="25">
            <Fixnum>1</Fixnum>
          </lit>
        </lasgn>
        <while startline="26">
          <call startline="26">
            <lasgn startline="26">
              <Symbol>p</Symbol>
              <call startline="26">
                <lvar startline="26">
                  <Symbol>primes</Symbol>
                </lvar>
                <Symbol>[]</Symbol>
                <arglist startline="26">
                  <lvar startline="26">
                    <Symbol>i</Symbol>
                  </lvar>
                </arglist>
              </call>
            </lasgn>
            <Symbol>&lt;=</Symbol>
            <arglist startline="27">
              <lvar startline="27">
                <Symbol>maxsq</Symbol>
              </lvar>
            </arglist>
          </call>
          <block startline="27">
            <iter startline="27">
              <call startline="27">
                <call startline="27">
                  <call startline="27">
                    <call startline="27">
                      <lvar startline="27">
                        <Symbol>min</Symbol>
                      </lvar>
                      <Symbol>+</Symbol>
                      <arglist startline="27">
                        <lvar startline="27">
                          <Symbol>p</Symbol>
                        </lvar>
                      </arglist>
                    </call>
                    <Symbol>-</Symbol>
                    <arglist startline="27">
                      <lit startline="27">
                        <Fixnum>1</Fixnum>
                      </lit>
                    </arglist>
                  </call>
                  <Symbol>-</Symbol>
                  <arglist startline="27">
                    <call startline="27">
                      <call startline="27">
                        <call startline="27">
                          <lvar startline="27">
                            <Symbol>min</Symbol>
                          </lvar>
                          <Symbol>+</Symbol>
                          <arglist startline="27">
                            <lvar startline="27">
                              <Symbol>p</Symbol>
                            </lvar>
                          </arglist>
                        </call>
                        <Symbol>-</Symbol>
                        <arglist startline="27">
                          <lit startline="27">
                            <Fixnum>1</Fixnum>
                          </lit>
                        </arglist>
                      </call>
                      <Symbol>%</Symbol>
                      <arglist startline="27">
                        <lvar startline="27">
                          <Symbol>p</Symbol>
                        </lvar>
                      </arglist>
                    </call>
                  </arglist>
                </call>
                <Symbol>step</Symbol>
                <arglist startline="27">
                  <lvar startline="27">
                    <Symbol>max</Symbol>
                  </lvar>
                  <lvar startline="27">
                    <Symbol>p</Symbol>
                  </lvar>
                </arglist>
              </call>
              <lasgn startline="27">
                <Symbol>j</Symbol>
              </lasgn>
              <block>
                <attrasgn startline="28">
                  <lvar startline="28">
                    <Symbol>result</Symbol>
                  </lvar>
                  <Symbol>[]=</Symbol>
                  <arglist startline="28">
                    <call startline="28">
                      <lvar startline="28">
                        <Symbol>j</Symbol>
                      </lvar>
                      <Symbol>-</Symbol>
                      <arglist startline="28">
                        <lvar startline="28">
                          <Symbol>min</Symbol>
                        </lvar>
                      </arglist>
                    </call>
                    <false startline="29" />
                  </arglist>
                </attrasgn>
              </block>
            </iter>
            <lasgn startline="30">
              <Symbol>i</Symbol>
              <call startline="31">
                <lvar startline="31">
                  <Symbol>i</Symbol>
                </lvar>
                <Symbol>+</Symbol>
                <arglist startline="31">
                  <lit startline="30">
                    <Fixnum>1</Fixnum>
                  </lit>
                </arglist>
              </call>
            </lasgn>
          </block>
          <TrueClass>true</TrueClass>
        </while>
        <return startline="33">
          <lvar startline="33">
            <Symbol>result</Symbol>
          </lvar>
        </return>
      </block>
    </scope>
  </defn>
  <defn startline="35">
    <Symbol>show_primes</Symbol>
    <args startline="35">
      <Symbol>min</Symbol>
      <Symbol>offset</Symbol>
      <Symbol>max</Symbol>
      <Symbol>table</Symbol>
    </args>
    <scope startline="40">
      <block startline="40">
        <while startline="36">
          <call startline="36">
            <lvar startline="36">
              <Symbol>min</Symbol>
            </lvar>
            <Symbol>&lt;=</Symbol>
            <arglist startline="37">
              <lvar startline="37">
                <Symbol>max</Symbol>
              </lvar>
            </arglist>
          </call>
          <block startline="37">
            <if startline="37">
              <call startline="37">
                <lvar startline="37">
                  <Symbol>table</Symbol>
                </lvar>
                <Symbol>[]</Symbol>
                <arglist startline="37">
                  <lvar startline="37">
                    <Symbol>min</Symbol>
                  </lvar>
                </arglist>
              </call>
              <block>
                <call startline="37">
                  <nil />
                  <Symbol>puts</Symbol>
                  <arglist startline="37">
                    <call startline="37">
                      <lvar startline="37">
                        <Symbol>min</Symbol>
                      </lvar>
                      <Symbol>+</Symbol>
                      <arglist startline="37">
                        <lvar startline="37">
                          <Symbol>offset</Symbol>
                        </lvar>
                      </arglist>
                    </call>
                  </arglist>
                </call>
              </block>
              <block />
            </if>
            <lasgn startline="38">
              <Symbol>min</Symbol>
              <call startline="39">
                <lvar startline="39">
                  <Symbol>min</Symbol>
                </lvar>
                <Symbol>+</Symbol>
                <arglist startline="39">
                  <lit startline="38">
                    <Fixnum>2</Fixnum>
                  </lit>
                </arglist>
              </call>
            </lasgn>
          </block>
          <TrueClass>true</TrueClass>
        </while>
      </block>
    </scope>
  </defn>
  <if startline="42">
    <call startline="42">
      <str startline="42">
        <String>(string)</String>
      </str>
      <Symbol>==</Symbol>
      <arglist startline="43">
        <gvar startline="43">
          <Symbol>$0</Symbol>
        </gvar>
      </arglist>
    </call>
    <block startline="43">
      <lasgn startline="43">
        <Symbol>max_prime</Symbol>
        <lit startline="43">
          <Fixnum>50000</Fixnum>
        </lit>
      </lasgn>
      <lasgn startline="44">
        <Symbol>table</Symbol>
        <call startline="44">
          <nil />
          <Symbol>prime_table</Symbol>
          <arglist startline="44">
            <lvar startline="44">
              <Symbol>max_prime</Symbol>
            </lvar>
          </arglist>
        </call>
      </lasgn>
      <lasgn startline="45">
        <Symbol>primes</Symbol>
        <call startline="45">
          <nil />
          <Symbol>prime_list</Symbol>
          <arglist startline="45">
            <lvar startline="45">
              <Symbol>table</Symbol>
            </lvar>
          </arglist>
        </call>
      </lasgn>
      <call startline="46">
        <lvar startline="46">
          <Symbol>primes</Symbol>
        </lvar>
        <Symbol>&lt;&lt;</Symbol>
        <arglist startline="47">
          <lit startline="46">
            <Fixnum>1000000000</Fixnum>
          </lit>
        </arglist>
      </call>
      <iter startline="48">
        <call startline="48">
          <call startline="48">
            <call startline="48">
              <call startline="48">
                <nil />
                <Symbol>gets</Symbol>
                <arglist startline="48" />
              </call>
              <Symbol>chomp</Symbol>
              <arglist startline="48" />
            </call>
            <Symbol>to_i</Symbol>
            <arglist startline="48" />
          </call>
          <Symbol>times</Symbol>
          <arglist startline="48" />
        </call>
        <lasgn startline="48">
          <Symbol>i</Symbol>
        </lasgn>
        <block startline="49">
          <if startline="49">
            <call startline="49">
              <lvar startline="49">
                <Symbol>i</Symbol>
              </lvar>
              <Symbol>==</Symbol>
              <arglist startline="50">
                <lit startline="49">
                  <Fixnum>0</Fixnum>
                </lit>
              </arglist>
            </call>
            <block />
            <block>
              <call startline="49">
                <nil />
                <Symbol>puts</Symbol>
                <arglist startline="49" />
              </call>
            </block>
          </if>
          <masgn startline="50">
            <array startline="50">
              <lasgn startline="50">
                <Symbol>min</Symbol>
              </lasgn>
              <lasgn startline="50">
                <Symbol>max</Symbol>
              </lasgn>
            </array>
            <to_ary startline="51">
              <iter startline="50">
                <call startline="50">
                  <call startline="50">
                    <call startline="50">
                      <nil />
                      <Symbol>gets</Symbol>
                      <arglist startline="50" />
                    </call>
                    <Symbol>split</Symbol>
                    <arglist startline="50" />
                  </call>
                  <Symbol>map</Symbol>
                  <arglist startline="50" />
                </call>
                <lasgn startline="50">
                  <Symbol>s</Symbol>
                </lasgn>
                <block>
                  <call startline="50">
                    <lvar startline="50">
                      <Symbol>s</Symbol>
                    </lvar>
                    <Symbol>to_i</Symbol>
                    <arglist startline="50" />
                  </call>
                </block>
              </iter>
            </to_ary>
          </masgn>
          <if startline="51">
            <call startline="51">
              <lvar startline="51">
                <Symbol>min</Symbol>
              </lvar>
              <Symbol>&lt;=</Symbol>
              <arglist startline="52">
                <lit startline="51">
                  <Fixnum>2</Fixnum>
                </lit>
              </arglist>
            </call>
            <block>
              <call startline="51">
                <nil />
                <Symbol>puts</Symbol>
                <arglist startline="51">
                  <lit startline="51">
                    <Fixnum>2</Fixnum>
                  </lit>
                </arglist>
              </call>
            </block>
            <block />
          </if>
          <if startline="53">
            <call startline="53">
              <call startline="53">
                <lvar startline="53">
                  <Symbol>min</Symbol>
                </lvar>
                <Symbol>&amp;</Symbol>
                <arglist startline="53">
                  <lit startline="53">
                    <Fixnum>1</Fixnum>
                  </lit>
                </arglist>
              </call>
              <Symbol>==</Symbol>
              <arglist startline="54">
                <lit startline="53">
                  <Fixnum>0</Fixnum>
                </lit>
              </arglist>
            </call>
            <block>
              <lasgn startline="53">
                <Symbol>min</Symbol>
                <call startline="53">
                  <lvar startline="53">
                    <Symbol>min</Symbol>
                  </lvar>
                  <Symbol>+</Symbol>
                  <arglist startline="53">
                    <lit startline="53">
                      <Fixnum>1</Fixnum>
                    </lit>
                  </arglist>
                </call>
              </lasgn>
            </block>
            <block />
          </if>
          <if startline="54">
            <call startline="54">
              <call startline="54">
                <lvar startline="54">
                  <Symbol>max</Symbol>
                </lvar>
                <Symbol>&amp;</Symbol>
                <arglist startline="54">
                  <lit startline="54">
                    <Fixnum>1</Fixnum>
                  </lit>
                </arglist>
              </call>
              <Symbol>==</Symbol>
              <arglist startline="55">
                <lit startline="54">
                  <Fixnum>0</Fixnum>
                </lit>
              </arglist>
            </call>
            <block>
              <lasgn startline="54">
                <Symbol>max</Symbol>
                <call startline="54">
                  <lvar startline="54">
                    <Symbol>max</Symbol>
                  </lvar>
                  <Symbol>-</Symbol>
                  <arglist startline="54">
                    <lit startline="54">
                      <Fixnum>1</Fixnum>
                    </lit>
                  </arglist>
                </call>
              </lasgn>
            </block>
            <block />
          </if>
          <if startline="56">
            <call startline="56">
              <lvar startline="56">
                <Symbol>max</Symbol>
              </lvar>
              <Symbol>&lt;=</Symbol>
              <arglist startline="57">
                <lvar startline="57">
                  <Symbol>max_prime</Symbol>
                </lvar>
              </arglist>
            </call>
            <block>
              <call startline="57">
                <nil />
                <Symbol>show_primes</Symbol>
                <arglist startline="57">
                  <lvar startline="57">
                    <Symbol>min</Symbol>
                  </lvar>
                  <lit startline="57">
                    <Fixnum>0</Fixnum>
                  </lit>
                  <lvar startline="57">
                    <Symbol>max</Symbol>
                  </lvar>
                  <lvar startline="57">
                    <Symbol>table</Symbol>
                  </lvar>
                </arglist>
              </call>
            </block>
            <block startline="59">
              <if startline="59">
                <call startline="59">
                  <lvar startline="59">
                    <Symbol>min</Symbol>
                  </lvar>
                  <Symbol>&lt;=</Symbol>
                  <arglist startline="60">
                    <lvar startline="60">
                      <Symbol>max_prime</Symbol>
                    </lvar>
                  </arglist>
                </call>
                <block startline="60">
                  <call startline="60">
                    <nil />
                    <Symbol>show_primes</Symbol>
                    <arglist startline="60">
                      <lvar startline="60">
                        <Symbol>min</Symbol>
                      </lvar>
                      <lit startline="60">
                        <Fixnum>0</Fixnum>
                      </lit>
                      <lvar startline="60">
                        <Symbol>max_prime</Symbol>
                      </lvar>
                      <lvar startline="60">
                        <Symbol>table</Symbol>
                      </lvar>
                    </arglist>
                  </call>
                  <lasgn startline="61">
                    <Symbol>min</Symbol>
                    <call startline="61">
                      <lvar startline="61">
                        <Symbol>max_prime</Symbol>
                      </lvar>
                      <Symbol>+</Symbol>
                      <arglist startline="62">
                        <lit startline="61">
                          <Fixnum>1</Fixnum>
                        </lit>
                      </arglist>
                    </call>
                  </lasgn>
                  <if startline="62">
                    <call startline="62">
                      <call startline="62">
                        <lvar startline="62">
                          <Symbol>min</Symbol>
                        </lvar>
                        <Symbol>&amp;</Symbol>
                        <arglist startline="62">
                          <lit startline="62">
                            <Fixnum>1</Fixnum>
                          </lit>
                        </arglist>
                      </call>
                      <Symbol>==</Symbol>
                      <arglist startline="63">
                        <lit startline="62">
                          <Fixnum>0</Fixnum>
                        </lit>
                      </arglist>
                    </call>
                    <block>
                      <lasgn startline="62">
                        <Symbol>min</Symbol>
                        <call startline="62">
                          <lvar startline="62">
                            <Symbol>min</Symbol>
                          </lvar>
                          <Symbol>+</Symbol>
                          <arglist startline="62">
                            <lit startline="62">
                              <Fixnum>1</Fixnum>
                            </lit>
                          </arglist>
                        </call>
                      </lasgn>
                    </block>
                    <block />
                  </if>
                </block>
                <block />
              </if>
              <lasgn startline="64">
                <Symbol>result</Symbol>
                <call startline="64">
                  <nil />
                  <Symbol>prime_check_table</Symbol>
                  <arglist startline="64">
                    <lvar startline="64">
                      <Symbol>min</Symbol>
                    </lvar>
                    <lvar startline="64">
                      <Symbol>max</Symbol>
                    </lvar>
                    <lvar startline="64">
                      <Symbol>primes</Symbol>
                    </lvar>
                  </arglist>
                </call>
              </lasgn>
              <call startline="65">
                <nil />
                <Symbol>show_primes</Symbol>
                <arglist startline="65">
                  <lit startline="65">
                    <Fixnum>0</Fixnum>
                  </lit>
                  <lvar startline="65">
                    <Symbol>min</Symbol>
                  </lvar>
                  <call startline="65">
                    <lvar startline="65">
                      <Symbol>max</Symbol>
                    </lvar>
                    <Symbol>-</Symbol>
                    <arglist startline="65">
                      <lvar startline="65">
                        <Symbol>min</Symbol>
                      </lvar>
                    </arglist>
                  </call>
                  <lvar startline="65">
                    <Symbol>result</Symbol>
                  </lvar>
                </arglist>
              </call>
            </block>
          </if>
        </block>
      </iter>
    </block>
    <block />
  </if>
  <lasgn startline="70">
    <Symbol>x</Symbol>
    <lit startline="70">
      <Fixnum>1</Fixnum>
    </lit>
  </lasgn>
  <case startline="72">
    <lvar startline="72">
      <Symbol>x</Symbol>
    </lvar>
    <when startline="72">
      <array startline="73">
        <lit startline="72">
          <Fixnum>1</Fixnum>
        </lit>
      </array>
      <call startline="74">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="74">
          <str startline="73">
            <String>1</String>
          </str>
        </arglist>
      </call>
    </when>
    <when startline="74">
      <array startline="75">
        <lit startline="74">
          <Fixnum>2</Fixnum>
        </lit>
      </array>
      <call startline="76">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="76">
          <str startline="75">
            <String>2</String>
          </str>
        </arglist>
      </call>
    </when>
    <call startline="78">
      <nil />
      <Symbol>p</Symbol>
      <arglist startline="78">
        <str startline="77">
          <String>else</String>
        </str>
      </arglist>
    </call>
  </case>
  <if startline="81">
    <call startline="80">
      <lvar startline="80">
        <Symbol>x</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="80">
        <lit startline="80">
          <Fixnum>1</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <str startline="80">
        <String>a</String>
      </str>
    </block>
    <block>
      <str startline="80">
        <String>b</String>
      </str>
    </block>
  </if>
  <while startline="82">
    <call startline="82">
      <lvar startline="82">
        <Symbol>x</Symbol>
      </lvar>
      <Symbol>&gt;=</Symbol>
      <arglist startline="82">
        <lit startline="82">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block startline="82">
      <call startline="82">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="82">
          <str startline="82">
            <String>a</String>
          </str>
        </arglist>
      </call>
      <call startline="82">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="82">
          <str startline="82">
            <String>a</String>
          </str>
        </arglist>
      </call>
    </block>
    <TrueClass>true</TrueClass>
  </while>
  <while startline="83">
    <call startline="83">
      <lvar startline="83">
        <Symbol>x</Symbol>
      </lvar>
      <Symbol>&gt;=</Symbol>
      <arglist startline="83">
        <lit startline="83">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <call startline="83">
      <nil />
      <Symbol>p</Symbol>
      <arglist startline="83">
        <str startline="83">
          <String>a</String>
        </str>
      </arglist>
    </call>
    <TrueClass>true</TrueClass>
  </while>
  <until startline="85">
    <call startline="85">
      <lvar startline="85">
        <Symbol>x</Symbol>
      </lvar>
      <Symbol>&lt;</Symbol>
      <arglist startline="85">
        <lit startline="85">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="87">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="87">
          <str startline="86">
            <String>a</String>
          </str>
        </arglist>
      </call>
    </block>
    <TrueClass>true</TrueClass>
  </until>
  <for startline="89">
    <array startline="89" />
    <lasgn startline="89">
      <Symbol>y</Symbol>
    </lasgn>
    <block>
      <call startline="91">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="91">
          <str startline="90">
            <String>c</String>
          </str>
        </arglist>
      </call>
    </block>
  </for>
  <defn startline="93">
    <Symbol>a</Symbol>
    <args startline="93" />
    <scope startline="95">
      <block startline="95">
        <call startline="95">
          <nil />
          <Symbol>p</Symbol>
          <arglist startline="95">
            <str startline="94">
              <String>c</String>
            </str>
          </arglist>
        </call>
      </block>
    </scope>
  </defn>
  <iter startline="97">
    <call startline="97">
      <array startline="97" />
      <Symbol>each</Symbol>
      <arglist startline="97" />
    </call>
    <lasgn startline="97">
      <Symbol>b</Symbol>
    </lasgn>
    <block>
      <call startline="99">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="99">
          <lvar startline="99">
            <Symbol>b</Symbol>
          </lvar>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="101">
    <call startline="101">
      <array startline="101" />
      <Symbol>each</Symbol>
      <arglist startline="101" />
    </call>
    <lasgn startline="101">
      <Symbol>b</Symbol>
    </lasgn>
    <block>
      <call startline="103">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="103">
          <lvar startline="103">
            <Symbol>b</Symbol>
          </lvar>
        </arglist>
      </call>
    </block>
  </iter>
</block>