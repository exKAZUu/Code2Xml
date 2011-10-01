<defn startline="1">
  <Symbol>fibonacci</Symbol>
  <args startline="1">
    <Symbol>n</Symbol>
  </args>
  <scope startline="7">
    <block startline="7">
      <if startline="2">
        <call startline="2">
          <lvar startline="2">
            <Symbol>n</Symbol>
          </lvar>
          <Symbol>&lt;</Symbol>
          <arglist startline="2">
            <lit startline="2">
              <Fixnum>2</Fixnum>
            </lit>
          </arglist>
        </call>
        <block>
          <return startline="4">
            <lvar startline="4">
              <Symbol>n</Symbol>
            </lvar>
          </return>
        </block>
        <block>
          <return startline="6">
            <call startline="5">
              <call startline="5">
                <nil />
                <Symbol>fibonacci</Symbol>
                <arglist startline="5">
                  <call startline="5">
                    <lvar startline="5">
                      <Symbol>n</Symbol>
                    </lvar>
                    <Symbol>-</Symbol>
                    <arglist startline="5">
                      <lit startline="5">
                        <Fixnum>1</Fixnum>
                      </lit>
                    </arglist>
                  </call>
                </arglist>
              </call>
              <Symbol>+</Symbol>
              <arglist startline="6">
                <call startline="5">
                  <nil />
                  <Symbol>fibonacci</Symbol>
                  <arglist startline="5">
                    <call startline="5">
                      <lvar startline="5">
                        <Symbol>n</Symbol>
                      </lvar>
                      <Symbol>-</Symbol>
                      <arglist startline="5">
                        <lit startline="5">
                          <Fixnum>2</Fixnum>
                        </lit>
                      </arglist>
                    </call>
                  </arglist>
                </call>
              </arglist>
            </call>
          </return>
        </block>
      </if>
    </block>
  </scope>
</defn>