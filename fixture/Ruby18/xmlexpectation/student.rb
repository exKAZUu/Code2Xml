<block startline="1">
  <class startline="1">
    <Symbol>Student</Symbol>
    <nil />
    <scope startline="9">
      <block startline="2">
        <defn startline="2">
          <Symbol>initialize</Symbol>
          <args startline="2">
            <Symbol>name</Symbol>
          </args>
          <scope startline="4">
            <block startline="4">
              <iasgn startline="3">
                <Symbol>@name</Symbol>
                <lvar startline="4">
                  <Symbol>name</Symbol>
                </lvar>
              </iasgn>
            </block>
          </scope>
        </defn>
        <defn startline="6">
          <Symbol>name</Symbol>
          <args startline="6" />
          <scope startline="8">
            <block startline="8">
              <ivar startline="8">
                <Symbol>@name</Symbol>
              </ivar>
            </block>
          </scope>
        </defn>
      </block>
    </scope>
  </class>
  <lasgn startline="11">
    <Symbol>students</Symbol>
    <call startline="11">
      <const startline="11">
        <Symbol>Array</Symbol>
      </const>
      <Symbol>new</Symbol>
      <arglist startline="11">
        <lit startline="11">
          <Fixnum>2</Fixnum>
        </lit>
      </arglist>
    </call>
  </lasgn>
  <attrasgn startline="12">
    <lvar startline="12">
      <Symbol>students</Symbol>
    </lvar>
    <Symbol>[]=</Symbol>
    <arglist startline="12">
      <lit startline="12">
        <Fixnum>0</Fixnum>
      </lit>
      <call startline="12">
        <const startline="12">
          <Symbol>Student</Symbol>
        </const>
        <Symbol>new</Symbol>
        <arglist startline="12">
          <str startline="12">
            <String>Tom</String>
          </str>
        </arglist>
      </call>
    </arglist>
  </attrasgn>
  <attrasgn startline="13">
    <lvar startline="13">
      <Symbol>students</Symbol>
    </lvar>
    <Symbol>[]=</Symbol>
    <arglist startline="13">
      <lit startline="13">
        <Fixnum>1</Fixnum>
      </lit>
      <call startline="13">
        <const startline="13">
          <Symbol>Student</Symbol>
        </const>
        <Symbol>new</Symbol>
        <arglist startline="13">
          <str startline="13">
            <String>Anna</String>
          </str>
        </arglist>
      </call>
    </arglist>
  </attrasgn>
  <for startline="15">
    <lvar startline="16">
      <Symbol>students</Symbol>
    </lvar>
    <lasgn startline="15">
      <Symbol>student</Symbol>
    </lasgn>
    <block>
      <call startline="17">
        <nil />
        <Symbol>puts</Symbol>
        <arglist startline="17">
          <call startline="16">
            <lvar startline="16">
              <Symbol>student</Symbol>
            </lvar>
            <Symbol>name</Symbol>
            <arglist startline="17" />
          </call>
        </arglist>
      </call>
    </block>
  </for>
</block>