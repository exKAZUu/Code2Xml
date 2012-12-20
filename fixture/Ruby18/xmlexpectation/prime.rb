<block startline="1">
  <defn startline="1">
    <Symbol>prime_table</Symbol>
    <args startline="1">
      <Symbol>max</Symbol>
    </args>
    <lasgn startline="2">
      <Symbol>result</Symbol>
      <call startline="2">
        <const startline="2">
          <Symbol>Array</Symbol>
        </const>
        <Symbol>new</Symbol>
        <call startline="2">
          <lvar startline="2">
            <Symbol>max</Symbol>
          </lvar>
          <Symbol>+</Symbol>
          <lit startline="2">
            <Fixnum>1</Fixnum>
          </lit>
        </call>
        <true startline="2"></true>
      </call>
    </lasgn>
    <attrasgn startline="3">
      <lvar startline="3">
        <Symbol>result</Symbol>
      </lvar>
      <Symbol>[]=</Symbol>
      <lit startline="3">
        <Fixnum>0</Fixnum>
      </lit>
      <attrasgn startline="3">
        <lvar startline="3">
          <Symbol>result</Symbol>
        </lvar>
        <Symbol>[]=</Symbol>
        <lit startline="3">
          <Fixnum>1</Fixnum>
        </lit>
        <false startline="3"></false>
      </attrasgn>
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
              <lvar startline="4">
                <Symbol>max</Symbol>
              </lvar>
            </call>
            <Symbol>ceil</Symbol>
          </call>
        </dot2>
        <Symbol>each</Symbol>
      </call>
      <args startline="9">
        <Symbol>i</Symbol>
      </args>
      <block startline="5">
        <if startline="5">
          <call startline="5">
            <lvar startline="5">
              <Symbol>result</Symbol>
            </lvar>
            <Symbol>[]</Symbol>
            <lvar startline="5">
              <Symbol>i</Symbol>
            </lvar>
          </call>
          <nil />
          <next startline="5"></next>
        </if>
        <iter startline="6">
          <call startline="6">
            <call startline="6">
              <lvar startline="6">
                <Symbol>i</Symbol>
              </lvar>
              <Symbol>*</Symbol>
              <lit startline="6">
                <Fixnum>2</Fixnum>
              </lit>
            </call>
            <Symbol>step</Symbol>
            <lvar startline="6">
              <Symbol>max</Symbol>
            </lvar>
            <lvar startline="6">
              <Symbol>i</Symbol>
            </lvar>
          </call>
          <args startline="8">
            <Symbol>j</Symbol>
          </args>
          <attrasgn startline="7">
            <lvar startline="7">
              <Symbol>result</Symbol>
            </lvar>
            <Symbol>[]=</Symbol>
            <lvar startline="7">
              <Symbol>j</Symbol>
            </lvar>
            <false startline="7"></false>
          </attrasgn>
        </iter>
      </block>
    </iter>
    <lvar startline="10">
      <Symbol>result</Symbol>
    </lvar>
  </defn>
  <defn startline="13">
    <Symbol>prime_list</Symbol>
    <args startline="13">
      <Symbol>table</Symbol>
    </args>
    <lasgn startline="14">
      <Symbol>result</Symbol>
      <array startline="14"></array>
    </lasgn>
    <iter startline="15">
      <call startline="15">
        <lvar startline="15">
          <Symbol>table</Symbol>
        </lvar>
        <Symbol>each_with_index</Symbol>
      </call>
      <args startline="15">
        <Symbol>b</Symbol>
        <Symbol>i</Symbol>
      </args>
      <if startline="16">
        <lvar startline="16">
          <Symbol>b</Symbol>
        </lvar>
        <call startline="16">
          <lvar startline="16">
            <Symbol>result</Symbol>
          </lvar>
          <Symbol>&lt;&lt;</Symbol>
          <lvar startline="16">
            <Symbol>i</Symbol>
          </lvar>
        </call>
        <nil />
      </if>
    </iter>
    <lvar startline="18">
      <Symbol>result</Symbol>
    </lvar>
  </defn>
  <defn startline="21">
    <Symbol>prime_check_table</Symbol>
    <args startline="21">
      <Symbol>min</Symbol>
      <Symbol>max</Symbol>
      <Symbol>primes</Symbol>
    </args>
    <lasgn startline="22">
      <Symbol>result</Symbol>
      <call startline="22">
        <const startline="22">
          <Symbol>Array</Symbol>
        </const>
        <Symbol>new</Symbol>
        <call startline="22">
          <call startline="22">
            <lvar startline="22">
              <Symbol>max</Symbol>
            </lvar>
            <Symbol>-</Symbol>
            <lvar startline="22">
              <Symbol>min</Symbol>
            </lvar>
          </call>
          <Symbol>+</Symbol>
          <lit startline="22">
            <Fixnum>1</Fixnum>
          </lit>
        </call>
        <true startline="22"></true>
      </call>
    </lasgn>
    <if startline="23">
      <call startline="23">
        <lvar startline="23">
          <Symbol>min</Symbol>
        </lvar>
        <Symbol>==</Symbol>
        <lit startline="23">
          <Fixnum>1</Fixnum>
        </lit>
      </call>
      <attrasgn startline="23">
        <lvar startline="23">
          <Symbol>result</Symbol>
        </lvar>
        <Symbol>[]=</Symbol>
        <lit startline="23">
          <Fixnum>0</Fixnum>
        </lit>
        <false startline="23"></false>
      </attrasgn>
      <nil />
    </if>
    <lasgn startline="24">
      <Symbol>maxsq</Symbol>
      <call startline="24">
        <call startline="24">
          <const startline="24">
            <Symbol>Math</Symbol>
          </const>
          <Symbol>sqrt</Symbol>
          <lvar startline="24">
            <Symbol>max</Symbol>
          </lvar>
        </call>
        <Symbol>ceil</Symbol>
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
            <lvar startline="26">
              <Symbol>i</Symbol>
            </lvar>
          </call>
        </lasgn>
        <Symbol>&lt;=</Symbol>
        <lvar startline="26">
          <Symbol>maxsq</Symbol>
        </lvar>
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
                  <lvar startline="27">
                    <Symbol>p</Symbol>
                  </lvar>
                </call>
                <Symbol>-</Symbol>
                <lit startline="27">
                  <Fixnum>1</Fixnum>
                </lit>
              </call>
              <Symbol>-</Symbol>
              <call startline="27">
                <call startline="27">
                  <call startline="27">
                    <lvar startline="27">
                      <Symbol>min</Symbol>
                    </lvar>
                    <Symbol>+</Symbol>
                    <lvar startline="27">
                      <Symbol>p</Symbol>
                    </lvar>
                  </call>
                  <Symbol>-</Symbol>
                  <lit startline="27">
                    <Fixnum>1</Fixnum>
                  </lit>
                </call>
                <Symbol>%</Symbol>
                <lvar startline="27">
                  <Symbol>p</Symbol>
                </lvar>
              </call>
            </call>
            <Symbol>step</Symbol>
            <lvar startline="27">
              <Symbol>max</Symbol>
            </lvar>
            <lvar startline="27">
              <Symbol>p</Symbol>
            </lvar>
          </call>
          <args startline="29">
            <Symbol>j</Symbol>
          </args>
          <attrasgn startline="28">
            <lvar startline="28">
              <Symbol>result</Symbol>
            </lvar>
            <Symbol>[]=</Symbol>
            <call startline="28">
              <lvar startline="28">
                <Symbol>j</Symbol>
              </lvar>
              <Symbol>-</Symbol>
              <lvar startline="28">
                <Symbol>min</Symbol>
              </lvar>
            </call>
            <false startline="28"></false>
          </attrasgn>
        </iter>
        <lasgn startline="30">
          <Symbol>i</Symbol>
          <call startline="30">
            <lvar startline="30">
              <Symbol>i</Symbol>
            </lvar>
            <Symbol>+</Symbol>
            <lit startline="30">
              <Fixnum>1</Fixnum>
            </lit>
          </call>
        </lasgn>
      </block>
      <TrueClass>true</TrueClass>
    </while>
    <return startline="32">
      <lvar startline="32">
        <Symbol>result</Symbol>
      </lvar>
    </return>
  </defn>
  <defn startline="35">
    <Symbol>show_primes</Symbol>
    <args startline="35">
      <Symbol>min</Symbol>
      <Symbol>offset</Symbol>
      <Symbol>max</Symbol>
      <Symbol>table</Symbol>
    </args>
    <while startline="36">
      <call startline="36">
        <lvar startline="36">
          <Symbol>min</Symbol>
        </lvar>
        <Symbol>&lt;=</Symbol>
        <lvar startline="36">
          <Symbol>max</Symbol>
        </lvar>
      </call>
      <block startline="37">
        <if startline="37">
          <call startline="37">
            <lvar startline="37">
              <Symbol>table</Symbol>
            </lvar>
            <Symbol>[]</Symbol>
            <lvar startline="37">
              <Symbol>min</Symbol>
            </lvar>
          </call>
          <call startline="37">
            <nil />
            <Symbol>puts</Symbol>
            <call startline="37">
              <lvar startline="37">
                <Symbol>min</Symbol>
              </lvar>
              <Symbol>+</Symbol>
              <lvar startline="37">
                <Symbol>offset</Symbol>
              </lvar>
            </call>
          </call>
          <nil />
        </if>
        <lasgn startline="38">
          <Symbol>min</Symbol>
          <call startline="38">
            <lvar startline="38">
              <Symbol>min</Symbol>
            </lvar>
            <Symbol>+</Symbol>
            <lit startline="38">
              <Fixnum>2</Fixnum>
            </lit>
          </call>
        </lasgn>
      </block>
      <TrueClass>true</TrueClass>
    </while>
  </defn>
  <if startline="42">
    <call startline="42">
      <str startline="42">
        <String>(string)</String>
      </str>
      <Symbol>==</Symbol>
      <gvar startline="42">
        <Symbol>$0</Symbol>
      </gvar>
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
          <lvar startline="44">
            <Symbol>max_prime</Symbol>
          </lvar>
        </call>
      </lasgn>
      <lasgn startline="45">
        <Symbol>primes</Symbol>
        <call startline="45">
          <nil />
          <Symbol>prime_list</Symbol>
          <lvar startline="45">
            <Symbol>table</Symbol>
          </lvar>
        </call>
      </lasgn>
      <call startline="46">
        <lvar startline="46">
          <Symbol>primes</Symbol>
        </lvar>
        <Symbol>&lt;&lt;</Symbol>
        <lit startline="46">
          <Fixnum>1000000000</Fixnum>
        </lit>
      </call>
      <iter startline="48">
        <call startline="48">
          <call startline="48">
            <call startline="48">
              <call startline="48">
                <nil />
                <Symbol>gets</Symbol>
              </call>
              <Symbol>chomp</Symbol>
            </call>
            <Symbol>to_i</Symbol>
          </call>
          <Symbol>times</Symbol>
        </call>
        <args startline="67">
          <Symbol>i</Symbol>
        </args>
        <block startline="49">
          <if startline="49">
            <call startline="49">
              <lvar startline="49">
                <Symbol>i</Symbol>
              </lvar>
              <Symbol>==</Symbol>
              <lit startline="49">
                <Fixnum>0</Fixnum>
              </lit>
            </call>
            <nil />
            <call startline="49">
              <nil />
              <Symbol>puts</Symbol>
            </call>
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
                    </call>
                    <Symbol>split</Symbol>
                  </call>
                  <Symbol>map</Symbol>
                </call>
                <args startline="50">
                  <Symbol>s</Symbol>
                </args>
                <call startline="50">
                  <lvar startline="50">
                    <Symbol>s</Symbol>
                  </lvar>
                  <Symbol>to_i</Symbol>
                </call>
              </iter>
            </to_ary>
          </masgn>
          <if startline="51">
            <call startline="51">
              <lvar startline="51">
                <Symbol>min</Symbol>
              </lvar>
              <Symbol>&lt;=</Symbol>
              <lit startline="51">
                <Fixnum>2</Fixnum>
              </lit>
            </call>
            <call startline="51">
              <nil />
              <Symbol>puts</Symbol>
              <lit startline="51">
                <Fixnum>2</Fixnum>
              </lit>
            </call>
            <nil />
          </if>
          <if startline="53">
            <call startline="53">
              <call startline="53">
                <lvar startline="53">
                  <Symbol>min</Symbol>
                </lvar>
                <Symbol>&amp;</Symbol>
                <lit startline="53">
                  <Fixnum>1</Fixnum>
                </lit>
              </call>
              <Symbol>==</Symbol>
              <lit startline="53">
                <Fixnum>0</Fixnum>
              </lit>
            </call>
            <lasgn startline="53">
              <Symbol>min</Symbol>
              <call startline="53">
                <lvar startline="53">
                  <Symbol>min</Symbol>
                </lvar>
                <Symbol>+</Symbol>
                <lit startline="53">
                  <Fixnum>1</Fixnum>
                </lit>
              </call>
            </lasgn>
            <nil />
          </if>
          <if startline="54">
            <call startline="54">
              <call startline="54">
                <lvar startline="54">
                  <Symbol>max</Symbol>
                </lvar>
                <Symbol>&amp;</Symbol>
                <lit startline="54">
                  <Fixnum>1</Fixnum>
                </lit>
              </call>
              <Symbol>==</Symbol>
              <lit startline="54">
                <Fixnum>0</Fixnum>
              </lit>
            </call>
            <lasgn startline="54">
              <Symbol>max</Symbol>
              <call startline="54">
                <lvar startline="54">
                  <Symbol>max</Symbol>
                </lvar>
                <Symbol>-</Symbol>
                <lit startline="54">
                  <Fixnum>1</Fixnum>
                </lit>
              </call>
            </lasgn>
            <nil />
          </if>
          <if startline="56">
            <call startline="56">
              <lvar startline="56">
                <Symbol>max</Symbol>
              </lvar>
              <Symbol>&lt;=</Symbol>
              <lvar startline="56">
                <Symbol>max_prime</Symbol>
              </lvar>
            </call>
            <call startline="57">
              <nil />
              <Symbol>show_primes</Symbol>
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
            </call>
            <block startline="59">
              <if startline="59">
                <call startline="59">
                  <lvar startline="59">
                    <Symbol>min</Symbol>
                  </lvar>
                  <Symbol>&lt;=</Symbol>
                  <lvar startline="59">
                    <Symbol>max_prime</Symbol>
                  </lvar>
                </call>
                <block startline="60">
                  <call startline="60">
                    <nil />
                    <Symbol>show_primes</Symbol>
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
                  </call>
                  <lasgn startline="61">
                    <Symbol>min</Symbol>
                    <call startline="61">
                      <lvar startline="61">
                        <Symbol>max_prime</Symbol>
                      </lvar>
                      <Symbol>+</Symbol>
                      <lit startline="61">
                        <Fixnum>1</Fixnum>
                      </lit>
                    </call>
                  </lasgn>
                  <if startline="62">
                    <call startline="62">
                      <call startline="62">
                        <lvar startline="62">
                          <Symbol>min</Symbol>
                        </lvar>
                        <Symbol>&amp;</Symbol>
                        <lit startline="62">
                          <Fixnum>1</Fixnum>
                        </lit>
                      </call>
                      <Symbol>==</Symbol>
                      <lit startline="62">
                        <Fixnum>0</Fixnum>
                      </lit>
                    </call>
                    <lasgn startline="62">
                      <Symbol>min</Symbol>
                      <call startline="62">
                        <lvar startline="62">
                          <Symbol>min</Symbol>
                        </lvar>
                        <Symbol>+</Symbol>
                        <lit startline="62">
                          <Fixnum>1</Fixnum>
                        </lit>
                      </call>
                    </lasgn>
                    <nil />
                  </if>
                </block>
                <nil />
              </if>
              <lasgn startline="64">
                <Symbol>result</Symbol>
                <call startline="64">
                  <nil />
                  <Symbol>prime_check_table</Symbol>
                  <lvar startline="64">
                    <Symbol>min</Symbol>
                  </lvar>
                  <lvar startline="64">
                    <Symbol>max</Symbol>
                  </lvar>
                  <lvar startline="64">
                    <Symbol>primes</Symbol>
                  </lvar>
                </call>
              </lasgn>
              <call startline="65">
                <nil />
                <Symbol>show_primes</Symbol>
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
                  <lvar startline="65">
                    <Symbol>min</Symbol>
                  </lvar>
                </call>
                <lvar startline="65">
                  <Symbol>result</Symbol>
                </lvar>
              </call>
            </block>
          </if>
        </block>
      </iter>
    </block>
    <nil />
  </if>
  <lasgn startline="70">
    <Symbol>x</Symbol>
    <lit startline="70">
      <Fixnum>1</Fixnum>
    </lit>
  </lasgn>
  <case startline="71">
    <lvar startline="71">
      <Symbol>x</Symbol>
    </lvar>
    <when startline="72">
      <array startline="73">
        <lit startline="72">
          <Fixnum>1</Fixnum>
        </lit>
      </array>
      <call startline="73">
        <nil />
        <Symbol>p</Symbol>
        <str startline="73">
          <String>1</String>
        </str>
      </call>
    </when>
    <when startline="74">
      <array startline="75">
        <lit startline="74">
          <Fixnum>2</Fixnum>
        </lit>
      </array>
      <call startline="75">
        <nil />
        <Symbol>p</Symbol>
        <str startline="75">
          <String>2</String>
        </str>
      </call>
    </when>
    <call startline="77">
      <nil />
      <Symbol>p</Symbol>
      <str startline="77">
        <String>else</String>
      </str>
    </call>
  </case>
  <if startline="82">
    <call startline="80">
      <lvar startline="80">
        <Symbol>x</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <lit startline="80">
        <Fixnum>1</Fixnum>
      </lit>
    </call>
    <str startline="80">
      <String>a</String>
    </str>
    <str startline="80">
      <String>b</String>
    </str>
  </if>
  <while startline="82">
    <call startline="82">
      <lvar startline="82">
        <Symbol>x</Symbol>
      </lvar>
      <Symbol>&gt;=</Symbol>
      <lit startline="82">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <block startline="82">
      <call startline="82">
        <nil />
        <Symbol>p</Symbol>
        <str startline="82">
          <String>a</String>
        </str>
      </call>
      <call startline="82">
        <nil />
        <Symbol>p</Symbol>
        <str startline="82">
          <String>a</String>
        </str>
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
      <lit startline="83">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="83">
      <nil />
      <Symbol>p</Symbol>
      <str startline="83">
        <String>a</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </while>
  <until startline="85">
    <call startline="85">
      <lvar startline="85">
        <Symbol>x</Symbol>
      </lvar>
      <Symbol>&lt;</Symbol>
      <lit startline="85">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="86">
      <nil />
      <Symbol>p</Symbol>
      <str startline="86">
        <String>a</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </until>
  <for startline="89">
    <array startline="89"></array>
    <lasgn startline="89">
      <Symbol>y</Symbol>
    </lasgn>
    <call startline="90">
      <nil />
      <Symbol>p</Symbol>
      <str startline="90">
        <String>c</String>
      </str>
    </call>
  </for>
  <defn startline="93">
    <Symbol>a</Symbol>
    <args startline="93"></args>
    <call startline="94">
      <nil />
      <Symbol>p</Symbol>
      <str startline="94">
        <String>c</String>
      </str>
    </call>
  </defn>
  <iter startline="97">
    <call startline="97">
      <array startline="97"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="99">
      <Symbol>b</Symbol>
    </args>
    <call startline="98">
      <nil />
      <Symbol>p</Symbol>
      <lvar startline="98">
        <Symbol>b</Symbol>
      </lvar>
    </call>
  </iter>
  <iter startline="101">
    <call startline="101">
      <array startline="101"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="103">
      <Symbol>b</Symbol>
    </args>
    <call startline="102">
      <nil />
      <Symbol>p</Symbol>
      <lvar startline="102">
        <Symbol>b</Symbol>
      </lvar>
    </call>
  </iter>
</block>