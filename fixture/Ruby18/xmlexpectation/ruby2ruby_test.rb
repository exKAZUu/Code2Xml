<block startline="1">
  <lasgn startline="1">
    <Symbol>i</Symbol>
    <lit startline="1">
      <Fixnum>0</Fixnum>
    </lit>
  </lasgn>
  <if startline="2">
    <call startline="2">
      <lvar startline="2">
        <Symbol>i</Symbol>
      </lvar>
      <Symbol>==</Symbol>
      <arglist startline="2">
        <lit startline="2">
          <Fixnum>0</Fixnum>
        </lit>
      </arglist>
    </call>
    <block>
      <call startline="3">
        <nil />
        <Symbol>p</Symbol>
        <arglist startline="3">
          <lvar startline="3">
            <Symbol>i</Symbol>
          </lvar>
        </arglist>
      </call>
    </block>
    <block />
  </if>
</block>