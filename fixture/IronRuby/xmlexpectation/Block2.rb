<block startline="1">
  <lasgn startline="1">
    <Symbol>i</Symbol>
    <lit startline="1">
      <Fixnum>0</Fixnum>
    </lit>
  </lasgn>
  <if startline="3">
    <call startline="3">
      <lvar startline="3">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="3">
        <lit startline="3">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="5">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="5">
          <str startline="4">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <block />
  </if>
  <if startline="6">
    <call startline="6">
      <lvar startline="6">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="6">
        <lit startline="6">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="8">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="8">
          <str startline="7">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <block />
  </if>
  <case startline="11">
    <lvar startline="11">
      <Symbol>i</Symbol>
    </lvar>
    <when startline="11">
      <array startline="12">
        <lit startline="11">
          <Fixnum>0</Fixnum>
        </lit>
      </array>
      <call startline="13">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="13">
          <str startline="12">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </when>
    <Nil />
  </case>
  <until startline="15">
    <call startline="15">
      <lvar startline="15">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="15">
        <lit startline="15">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="17">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="17">
          <str startline="16">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <TrueClass>true</TrueClass>
  </until>
  <until startline="19">
    <call startline="19">
      <lvar startline="19">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="19">
        <lit startline="19">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="21">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="21">
          <str startline="20">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <TrueClass>true</TrueClass>
  </until>
  <for startline="23">
    <array startline="23" />
    <lasgn startline="23">
      <Symbol>y</Symbol>
    </lasgn>
    <block>
      <call startline="25">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="25">
          <str startline="24">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </for>
  <iter startline="27">
    <call startline="29">
      <Nil />
      <Symbol>loop</Symbol>
      <arglist startline="29" />
    </call>
    <Nil />
    <block>
      <call startline="29">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="29">
          <str startline="28">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="31">
    <call startline="33">
      <Nil />
      <Symbol>loop</Symbol>
      <arglist startline="33" />
    </call>
    <Nil />
    <block>
      <call startline="33">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="33">
          <str startline="32">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="35">
    <call startline="35">
      <array startline="35" />
      <Symbol>each</Symbol>
      <arglist startline="35" />
    </call>
    <lasgn startline="35">
      <Symbol>b</Symbol>
    </lasgn>
    <block>
      <call startline="37">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="37">
          <str startline="36">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="39">
    <call startline="39">
      <array startline="39" />
      <Symbol>each</Symbol>
      <arglist startline="39" />
    </call>
    <lasgn startline="39">
      <Symbol>b</Symbol>
    </lasgn>
    <block>
      <call startline="41">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="41">
          <str startline="40">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="43">
    <call startline="45">
      <Nil />
      <Symbol>lambda</Symbol>
      <arglist startline="45" />
    </call>
    <lasgn startline="43">
      <Symbol>x</Symbol>
    </lasgn>
    <block>
      <call startline="45">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="45">
          <str startline="44">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="47">
    <call startline="49">
      <Nil />
      <Symbol>lambda</Symbol>
      <arglist startline="49" />
    </call>
    <lasgn startline="47">
      <Symbol>x</Symbol>
    </lasgn>
    <block>
      <call startline="49">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="49">
          <str startline="48">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
</block>