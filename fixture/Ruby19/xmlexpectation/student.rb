<block startline="1">
  <class startline="1">
    <Symbol>Student</Symbol>
    <nil />
    <defn startline="2">
      <Symbol>initialize</Symbol>
      <args startline="2">
        <Symbol>name</Symbol>
      </args>
      <iasgn startline="3">
        <Symbol>@name</Symbol>
        <lvar startline="3">
          <Symbol>name</Symbol>
        </lvar>
      </iasgn>
    </defn>
    <defn startline="6">
      <Symbol>name</Symbol>
      <args startline="6"></args>
      <ivar startline="7">
        <Symbol>@name</Symbol>
      </ivar>
    </defn>
  </class>
  <lasgn startline="11">
    <Symbol>students</Symbol>
    <call startline="11">
      <const startline="11">
        <Symbol>Array</Symbol>
      </const>
      <Symbol>new</Symbol>
      <lit startline="11">
        <Fixnum>2</Fixnum>
      </lit>
    </call>
  </lasgn>
  <attrasgn startline="12">
    <lvar startline="12">
      <Symbol>students</Symbol>
    </lvar>
    <Symbol>[]=</Symbol>
    <lit startline="12">
      <Fixnum>0</Fixnum>
    </lit>
    <call startline="12">
      <const startline="12">
        <Symbol>Student</Symbol>
      </const>
      <Symbol>new</Symbol>
      <str startline="12">
        <String>Tom</String>
      </str>
    </call>
  </attrasgn>
  <attrasgn startline="13">
    <lvar startline="13">
      <Symbol>students</Symbol>
    </lvar>
    <Symbol>[]=</Symbol>
    <lit startline="13">
      <Fixnum>1</Fixnum>
    </lit>
    <call startline="13">
      <const startline="13">
        <Symbol>Student</Symbol>
      </const>
      <Symbol>new</Symbol>
      <str startline="13">
        <String>Anna</String>
      </str>
    </call>
  </attrasgn>
  <for startline="15">
    <lvar startline="15">
      <Symbol>students</Symbol>
    </lvar>
    <lasgn startline="15">
      <Symbol>student</Symbol>
    </lasgn>
    <call startline="16">
      <nil />
      <Symbol>puts</Symbol>
      <call startline="16">
        <lvar startline="16">
          <Symbol>student</Symbol>
        </lvar>
        <Symbol>name</Symbol>
      </call>
    </call>
  </for>
</block>