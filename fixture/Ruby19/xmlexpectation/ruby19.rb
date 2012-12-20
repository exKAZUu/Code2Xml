<block startline="1">
  <defn startline="1">
    <Symbol>set_pixel</Symbol>
    <args startline="1">
      <Symbol>h</Symbol>
    </args>
    <attrasgn startline="3">
      <call startline="3">
        <ivar startline="3">
          <Symbol>@field</Symbol>
        </ivar>
        <Symbol>[]</Symbol>
        <call startline="3">
          <lvar startline="3">
            <Symbol>h</Symbol>
          </lvar>
          <Symbol>[]</Symbol>
          <lit startline="3">
            <Symbol>y</Symbol>
          </lit>
        </call>
      </call>
      <Symbol>[]=</Symbol>
      <call startline="3">
        <lvar startline="3">
          <Symbol>h</Symbol>
        </lvar>
        <Symbol>[]</Symbol>
        <lit startline="3">
          <Symbol>x</Symbol>
        </lit>
      </call>
      <call startline="3">
        <lvar startline="3">
          <Symbol>h</Symbol>
        </lvar>
        <Symbol>[]</Symbol>
        <lit startline="3">
          <Symbol>color</Symbol>
        </lit>
      </call>
    </attrasgn>
  </defn>
  <call startline="7">
    <nil />
    <Symbol>set_pixel</Symbol>
    <hash startline="7">
      <lit startline="7">
        <Symbol>x</Symbol>
      </lit>
      <lit startline="7">
        <Fixnum>30</Fixnum>
      </lit>
      <lit startline="7">
        <Symbol>y</Symbol>
      </lit>
      <lit startline="7">
        <Fixnum>50</Fixnum>
      </lit>
      <lit startline="7">
        <Symbol>color</Symbol>
      </lit>
      <str startline="7">
        <String>red</String>
      </str>
    </hash>
  </call>
  <call startline="8">
    <nil />
    <Symbol>set_pixel</Symbol>
    <hash startline="8">
      <lit startline="8">
        <Symbol>color</Symbol>
      </lit>
      <str startline="8">
        <String>black</String>
      </str>
      <lit startline="8">
        <Symbol>x</Symbol>
      </lit>
      <lit startline="8">
        <Fixnum>40</Fixnum>
      </lit>
      <lit startline="8">
        <Symbol>y</Symbol>
      </lit>
      <lit startline="8">
        <Fixnum>50</Fixnum>
      </lit>
    </hash>
  </call>
  <defn startline="10">
    <Symbol>foo</Symbol>
    <args startline="10">
      <Symbol>a</Symbol>
      <Symbol>b</Symbol>
      <Symbol>*ary</Symbol>
      <Symbol>z</Symbol>
    </args>
    <call startline="11">
      <nil />
      <Symbol>p</Symbol>
      <array startline="11">
        <lvar startline="11">
          <Symbol>a</Symbol>
        </lvar>
        <lvar startline="11">
          <Symbol>b</Symbol>
        </lvar>
        <lvar startline="11">
          <Symbol>ary</Symbol>
        </lvar>
        <lvar startline="11">
          <Symbol>z</Symbol>
        </lvar>
      </array>
    </call>
  </defn>
  <defn startline="14">
    <Symbol>foo</Symbol>
    <args startline="14">
      <Symbol>a</Symbol>
      <Symbol>b</Symbol>
      <Symbol>c</Symbol>
      <Symbol>d</Symbol>
    </args>
    <call startline="15">
      <nil />
      <Symbol>p</Symbol>
      <array startline="15">
        <lvar startline="15">
          <Symbol>a</Symbol>
        </lvar>
        <lvar startline="15">
          <Symbol>b</Symbol>
        </lvar>
        <lvar startline="15">
          <Symbol>c</Symbol>
        </lvar>
        <lvar startline="15">
          <Symbol>d</Symbol>
        </lvar>
      </array>
    </call>
  </defn>
  <lasgn startline="18">
    <Symbol>ary</Symbol>
    <array startline="18">
      <lit startline="18">
        <Fixnum>1</Fixnum>
      </lit>
      <lit startline="18">
        <Fixnum>2</Fixnum>
      </lit>
    </array>
  </lasgn>
  <call startline="20">
    <nil />
    <Symbol>foo</Symbol>
    <splat startline="20">
      <lvar startline="20">
        <Symbol>ary</Symbol>
      </lvar>
    </splat>
    <splat startline="20">
      <lvar startline="20">
        <Symbol>ary</Symbol>
      </lvar>
    </splat>
  </call>
  <call startline="22">
    <nil />
    <Symbol>foo</Symbol>
    <lit startline="22">
      <Fixnum>1</Fixnum>
    </lit>
    <lit startline="22">
      <Fixnum>2</Fixnum>
    </lit>
    <lit startline="22">
      <Fixnum>3</Fixnum>
    </lit>
    <lit startline="22">
      <Fixnum>4</Fixnum>
    </lit>
    <lit startline="22">
      <Fixnum>5</Fixnum>
    </lit>
  </call>
  <lasgn startline="24">
    <Symbol>add_1</Symbol>
    <iter startline="24">
      <call startline="24">
        <nil />
        <Symbol>lambda</Symbol>
      </call>
      <args startline="24">
        <Symbol>x</Symbol>
      </args>
      <call startline="24">
        <lvar startline="24">
          <Symbol>x</Symbol>
        </lvar>
        <Symbol>+</Symbol>
        <lit startline="24">
          <Fixnum>1</Fixnum>
        </lit>
      </call>
    </iter>
  </lasgn>
  <call startline="25">
    <nil />
    <Symbol>p</Symbol>
    <call startline="25">
      <lvar startline="25">
        <Symbol>add_1</Symbol>
      </lvar>
      <Symbol>call</Symbol>
      <lit startline="25">
        <Fixnum>42</Fixnum>
      </lit>
    </call>
  </call>
</block>