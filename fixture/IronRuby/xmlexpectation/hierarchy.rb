<block startline="1">
  <class startline="1">
    <Symbol>A</Symbol>
    <Nil />
    <scope startline="4">
      <defn startline="2">
        <Symbol>a</Symbol>
        <args startline="3" />
        <scope startline="3">
          <block startline="3">
            <nil startline="3" />
          </block>
        </scope>
      </defn>
    </scope>
  </class>
  <module startline="6">
    <Symbol>B</Symbol>
    <scope startline="9">
      <defn startline="7">
        <Symbol>b</Symbol>
        <args startline="8" />
        <scope startline="8">
          <block startline="8">
            <nil startline="8" />
          </block>
        </scope>
      </defn>
    </scope>
  </module>
  <class startline="11">
    <Symbol>C</Symbol>
    <Nil />
    <scope startline="16">
      <module startline="12">
        <Symbol>CC</Symbol>
        <scope startline="15">
          <defn startline="13">
            <Symbol>cc</Symbol>
            <args startline="14" />
            <scope startline="14">
              <block startline="14">
                <nil startline="14" />
              </block>
            </scope>
          </defn>
        </scope>
      </module>
    </scope>
  </class>
  <sclass startline="18">
    <const startline="19">
      <Symbol>C</Symbol>
    </const>
    <scope startline="21">
      <defn startline="19">
        <Symbol>c</Symbol>
        <args startline="20" />
        <scope startline="20">
          <block startline="20">
            <nil startline="20" />
          </block>
        </scope>
      </defn>
    </scope>
  </sclass>
  <sclass startline="23">
    <call startline="23">
      <const startline="23">
        <Symbol>C</Symbol>
      </const>
      <Symbol>new</Symbol>
      <arglist startline="24" />
    </call>
    <scope startline="26">
      <defn startline="24">
        <Symbol>c2</Symbol>
        <args startline="25" />
        <scope startline="25">
          <block startline="25">
            <nil startline="25" />
          </block>
        </scope>
      </defn>
    </scope>
  </sclass>
  <lasgn startline="28">
    <Symbol>c3</Symbol>
    <call startline="28">
      <const startline="28">
        <Symbol>C</Symbol>
      </const>
      <Symbol>new</Symbol>
      <arglist startline="29" />
    </call>
  </lasgn>
  <sclass startline="29">
    <lvar startline="30">
      <Symbol>c3</Symbol>
    </lvar>
    <scope startline="30" />
  </sclass>
  <defn startline="32">
    <Symbol>z</Symbol>
    <args startline="33" />
    <scope startline="33">
      <block startline="33">
        <nil startline="33" />
      </block>
    </scope>
  </defn>
</block>