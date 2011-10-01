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
      <call startline="3">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="3">
          <str startline="3">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <block />
  </if>
  <if startline="4">
    <call startline="4">
      <lvar startline="4">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="4">
        <lit startline="4">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="4">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="4">
          <str startline="4">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <block />
  </if>
  <case startline="7">
    <lvar startline="7">
      <Symbol>i</Symbol>
    </lvar>
    <when startline="7">
      <array startline="8">
        <lit startline="7">
          <Fixnum>0</Fixnum>
        </lit>
      </array>
      <call startline="9">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="9">
          <str startline="8">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </when>
    <Nil />
  </case>
  <until startline="11">
    <call startline="11">
      <lvar startline="11">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="11">
        <lit startline="11">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="11">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="11">
          <str startline="11">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <TrueClass>true</TrueClass>
  </until>
  <until startline="12">
    <call startline="12">
      <lvar startline="12">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="12">
        <lit startline="12">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="12">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="12">
          <str startline="12">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
    <TrueClass>true</TrueClass>
  </until>
  <for startline="13">
    <array startline="13" />
    <lasgn startline="13">
      <Symbol>y</Symbol>
    </lasgn>
    <block>
      <call startline="13">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="13">
          <str startline="13">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </for>
  <iter startline="14">
    <call startline="14">
      <Nil />
      <Symbol>loop</Symbol>
      <arglist startline="14" />
    </call>
    <Nil />
    <block>
      <call startline="14">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="14">
          <str startline="14">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="15">
    <call startline="15">
      <Nil />
      <Symbol>loop</Symbol>
      <arglist startline="15" />
    </call>
    <Nil />
    <block>
      <call startline="15">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="15">
          <str startline="15">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="16">
    <call startline="16">
      <array startline="16" />
      <Symbol>each</Symbol>
      <arglist startline="16" />
    </call>
    <lasgn startline="16">
      <Symbol>b</Symbol>
    </lasgn>
    <block>
      <call startline="16">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="16">
          <str startline="16">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="17">
    <call startline="17">
      <array startline="17" />
      <Symbol>each</Symbol>
      <arglist startline="17" />
    </call>
    <lasgn startline="17">
      <Symbol>b</Symbol>
    </lasgn>
    <block>
      <call startline="17">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="17">
          <str startline="17">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="18">
    <call startline="18">
      <Nil />
      <Symbol>lambda</Symbol>
      <arglist startline="18" />
    </call>
    <lasgn startline="18">
      <Symbol>x</Symbol>
    </lasgn>
    <block>
      <call startline="18">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="18">
          <str startline="18">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
  <iter startline="19">
    <call startline="19">
      <Nil />
      <Symbol>lambda</Symbol>
      <arglist startline="19" />
    </call>
    <lasgn startline="19">
      <Symbol>x</Symbol>
    </lasgn>
    <block>
      <call startline="19">
        <Nil />
        <Symbol>p</Symbol>
        <arglist startline="19">
          <str startline="19">
            <String>test</String>
          </str>
        </arglist>
      </call>
    </block>
  </iter>
</block>