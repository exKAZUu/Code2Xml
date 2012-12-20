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
      <lit startline="3">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="4">
      <nil />
      <Symbol>p</Symbol>
      <str startline="4">
        <String>test</String>
      </str>
    </call>
    <nil />
  </if>
  <if startline="6">
    <call startline="6">
      <lvar startline="6">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>!=</Symbol>
      <lit startline="6">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <nil />
    <call startline="7">
      <nil />
      <Symbol>p</Symbol>
      <str startline="7">
        <String>test</String>
      </str>
    </call>
  </if>
  <case startline="10">
    <lvar startline="10">
      <Symbol>i</Symbol>
    </lvar>
    <when startline="11">
      <array startline="12">
        <lit startline="11">
          <Fixnum>0</Fixnum>
        </lit>
      </array>
      <call startline="12">
        <nil />
        <Symbol>p</Symbol>
        <str startline="12">
          <String>test</String>
        </str>
      </call>
    </when>
    <nil />
  </case>
  <while startline="15">
    <call startline="15">
      <lvar startline="15">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>!=</Symbol>
      <lit startline="15">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="16">
      <nil />
      <Symbol>p</Symbol>
      <str startline="16">
        <String>test</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </while>
  <until startline="19">
    <call startline="19">
      <lvar startline="19">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <lit startline="19">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="20">
      <nil />
      <Symbol>p</Symbol>
      <str startline="20">
        <String>test</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </until>
  <for startline="23">
    <array startline="23"></array>
    <lasgn startline="23">
      <Symbol>y</Symbol>
    </lasgn>
    <call startline="24">
      <nil />
      <Symbol>p</Symbol>
      <str startline="24">
        <String>test</String>
      </str>
    </call>
  </for>
  <iter startline="27">
    <call startline="27">
      <nil />
      <Symbol>loop</Symbol>
    </call>
    <args startline="29"></args>
    <call startline="28">
      <nil />
      <Symbol>p</Symbol>
      <str startline="28">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="31">
    <call startline="31">
      <nil />
      <Symbol>loop</Symbol>
    </call>
    <args startline="33"></args>
    <call startline="32">
      <nil />
      <Symbol>p</Symbol>
      <str startline="32">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="35">
    <call startline="35">
      <array startline="35"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="35">
      <Symbol>b</Symbol>
    </args>
    <call startline="36">
      <nil />
      <Symbol>p</Symbol>
      <str startline="36">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="39">
    <call startline="39">
      <array startline="39"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="39">
      <Symbol>b</Symbol>
    </args>
    <call startline="40">
      <nil />
      <Symbol>p</Symbol>
      <str startline="40">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="43">
    <call startline="43">
      <nil />
      <Symbol>lambda</Symbol>
    </call>
    <args startline="43">
      <Symbol>x</Symbol>
    </args>
    <call startline="44">
      <nil />
      <Symbol>p</Symbol>
      <str startline="44">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="47">
    <call startline="47">
      <nil />
      <Symbol>lambda</Symbol>
    </call>
    <args startline="47">
      <Symbol>x</Symbol>
    </args>
    <call startline="48">
      <nil />
      <Symbol>p</Symbol>
      <str startline="48">
        <String>test</String>
      </str>
    </call>
  </iter>
</block>