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
    <call startline="3">
      <nil />
      <Symbol>p</Symbol>
      <str startline="3">
        <String>test</String>
      </str>
    </call>
    <nil />
  </if>
  <if startline="4">
    <call startline="4">
      <lvar startline="4">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <lit startline="4">
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
  <until startline="11">
    <call startline="11">
      <lvar startline="11">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
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
  </until>
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
</block>