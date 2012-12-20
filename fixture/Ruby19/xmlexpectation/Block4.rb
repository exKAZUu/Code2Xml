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
    <nil />
    <nil />
  </if>
  <if startline="4">
    <call startline="4">
      <lvar startline="4">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>!=</Symbol>
      <lit startline="4">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <nil />
    <nil />
  </if>
  <case startline="6">
    <lvar startline="6">
      <Symbol>i</Symbol>
    </lvar>
    <when startline="7">
      <array startline="8">
        <lit startline="7">
          <Fixnum>0</Fixnum>
        </lit>
      </array>
      <call startline="8">
        <nil />
        <Symbol>p</Symbol>
        <str startline="8">
          <String>test</String>
        </str>
      </call>
    </when>
    <nil />
  </case>
  <while startline="11">
    <call startline="11">
      <lvar startline="11">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>!=</Symbol>
      <lit startline="11">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="11">
      <nil />
      <Symbol>p</Symbol>
      <str startline="11">
        <String>test</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </while>
  <until startline="12">
    <call startline="12">
      <lvar startline="12">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <lit startline="12">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="12">
      <nil />
      <Symbol>p</Symbol>
      <str startline="12">
        <String>test</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </until>
  <for startline="13">
    <array startline="13"></array>
    <lasgn startline="13">
      <Symbol>y</Symbol>
    </lasgn>
    <call startline="13">
      <nil />
      <Symbol>p</Symbol>
      <str startline="13">
        <String>test</String>
      </str>
    </call>
  </for>
  <iter startline="14">
    <call startline="14">
      <nil />
      <Symbol>loop</Symbol>
    </call>
    <args startline="14"></args>
    <call startline="14">
      <nil />
      <Symbol>p</Symbol>
      <str startline="14">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="15">
    <call startline="15">
      <nil />
      <Symbol>loop</Symbol>
    </call>
    <args startline="15"></args>
    <call startline="15">
      <nil />
      <Symbol>p</Symbol>
      <str startline="15">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="16">
    <call startline="16">
      <array startline="16"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="16">
      <Symbol>b</Symbol>
    </args>
    <call startline="16">
      <nil />
      <Symbol>p</Symbol>
      <str startline="16">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="17">
    <call startline="17">
      <array startline="17"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="17">
      <Symbol>b</Symbol>
    </args>
    <call startline="17">
      <nil />
      <Symbol>p</Symbol>
      <str startline="17">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="18">
    <call startline="18">
      <nil />
      <Symbol>lambda</Symbol>
    </call>
    <args startline="18">
      <Symbol>x</Symbol>
    </args>
    <call startline="18">
      <nil />
      <Symbol>p</Symbol>
      <str startline="18">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="19">
    <call startline="19">
      <nil />
      <Symbol>lambda</Symbol>
    </call>
    <args startline="19">
      <Symbol>x</Symbol>
    </args>
    <call startline="19">
      <nil />
      <Symbol>p</Symbol>
      <str startline="19">
        <String>test</String>
      </str>
    </call>
  </iter>
  <lasgn startline="21">
    <Symbol>i</Symbol>
    <lit startline="21">
      <Fixnum>0</Fixnum>
    </lit>
  </lasgn>
  <if startline="23">
    <call startline="23">
      <lvar startline="23">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <lit startline="23">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="24">
      <nil />
      <Symbol>p</Symbol>
      <str startline="24">
        <String>test</String>
      </str>
    </call>
    <nil />
  </if>
  <if startline="27">
    <call startline="27">
      <lvar startline="27">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>!=</Symbol>
      <lit startline="27">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <nil />
    <call startline="28">
      <nil />
      <Symbol>p</Symbol>
      <str startline="28">
        <String>test</String>
      </str>
    </call>
  </if>
  <case startline="31">
    <lvar startline="31">
      <Symbol>i</Symbol>
    </lvar>
    <when startline="32">
      <array startline="33">
        <lit startline="32">
          <Fixnum>0</Fixnum>
        </lit>
      </array>
      <call startline="33">
        <nil />
        <Symbol>p</Symbol>
        <str startline="33">
          <String>test</String>
        </str>
      </call>
    </when>
    <nil />
  </case>
  <while startline="36">
    <call startline="36">
      <lvar startline="36">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>!=</Symbol>
      <lit startline="36">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="37">
      <nil />
      <Symbol>p</Symbol>
      <str startline="37">
        <String>test</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </while>
  <until startline="40">
    <call startline="40">
      <lvar startline="40">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <lit startline="40">
        <Fixnum>0</Fixnum>
      </lit>
    </call>
    <call startline="41">
      <nil />
      <Symbol>p</Symbol>
      <str startline="41">
        <String>test</String>
      </str>
    </call>
    <TrueClass>true</TrueClass>
  </until>
  <for startline="44">
    <array startline="44"></array>
    <lasgn startline="44">
      <Symbol>y</Symbol>
    </lasgn>
    <call startline="45">
      <nil />
      <Symbol>p</Symbol>
      <str startline="45">
        <String>test</String>
      </str>
    </call>
  </for>
  <iter startline="48">
    <call startline="48">
      <nil />
      <Symbol>loop</Symbol>
    </call>
    <args startline="50"></args>
    <call startline="49">
      <nil />
      <Symbol>p</Symbol>
      <str startline="49">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="52">
    <call startline="52">
      <nil />
      <Symbol>loop</Symbol>
    </call>
    <args startline="54"></args>
    <call startline="53">
      <nil />
      <Symbol>p</Symbol>
      <str startline="53">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="56">
    <call startline="56">
      <array startline="56"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="56">
      <Symbol>b</Symbol>
    </args>
    <call startline="57">
      <nil />
      <Symbol>p</Symbol>
      <str startline="57">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="60">
    <call startline="60">
      <array startline="60"></array>
      <Symbol>each</Symbol>
    </call>
    <args startline="60">
      <Symbol>b</Symbol>
    </args>
    <call startline="61">
      <nil />
      <Symbol>p</Symbol>
      <str startline="61">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="64">
    <call startline="64">
      <nil />
      <Symbol>lambda</Symbol>
    </call>
    <args startline="64">
      <Symbol>x</Symbol>
    </args>
    <call startline="65">
      <nil />
      <Symbol>p</Symbol>
      <str startline="65">
        <String>test</String>
      </str>
    </call>
  </iter>
  <iter startline="68">
    <call startline="68">
      <nil />
      <Symbol>lambda</Symbol>
    </call>
    <args startline="68">
      <Symbol>x</Symbol>
    </args>
    <call startline="69">
      <nil />
      <Symbol>p</Symbol>
      <str startline="69">
        <String>test</String>
      </str>
    </call>
  </iter>
</block>