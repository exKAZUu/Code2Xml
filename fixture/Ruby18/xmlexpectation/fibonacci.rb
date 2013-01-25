<defn startline="1">
  <Symbol>fibonacci</Symbol>
  <args startline="1">
    <Symbol>n</Symbol>
  </args>
  <if startline="2">
    <call startline="2">
      <lvar startline="2">
        <Symbol>n</Symbol>
      </lvar>
      <Symbol>&lt;</Symbol>
      <lit startline="2">
        <Fixnum>2</Fixnum>
      </lit>
    </call>
    <return startline="3">
      <lvar startline="3">
        <Symbol>n</Symbol>
      </lvar>
    </return>
    <return startline="5">
      <call startline="5">
        <call startline="5">
          <nil />
          <Symbol>fibonacci</Symbol>
          <call startline="5">
            <lvar startline="5">
              <Symbol>n</Symbol>
            </lvar>
            <Symbol>-</Symbol>
            <lit startline="5">
              <Fixnum>1</Fixnum>
            </lit>
          </call>
        </call>
        <Symbol>+</Symbol>
        <call startline="5">
          <nil />
          <Symbol>fibonacci</Symbol>
          <call startline="5">
            <lvar startline="5">
              <Symbol>n</Symbol>
            </lvar>
            <Symbol>-</Symbol>
            <lit startline="5">
              <Fixnum>2</Fixnum>
            </lit>
          </call>
        </call>
      </call>
    </return>
  </if>
</defn>