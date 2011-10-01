<chunk>
  <stat>
    <varlist1>
      <var>
        <NAME startline="1" startpos="0">i</NAME>
      </var>
    </varlist1>
    <TOKEN startline="1" startpos="2">=</TOKEN>
    <explist1>
      <exp>
        <lua_number>
          <TOKEN startline="1" startpos="4">0</TOKEN>
        </lua_number>
      </exp>
    </explist1>
  </stat>
  <stat>
    <TOKEN startline="2" startpos="0">if</TOKEN>
    <exp>
      <prefixexp>
        <varOrExp>
          <var>
            <NAME startline="2" startpos="3">i</NAME>
          </var>
        </varOrExp>
      </prefixexp>
      <binop>
        <TOKEN startline="2" startpos="5">==</TOKEN>
      </binop>
      <exp>
        <lua_number>
          <TOKEN startline="2" startpos="8">0</TOKEN>
        </lua_number>
      </exp>
    </exp>
    <TOKEN startline="2" startpos="10">then</TOKEN>
    <block>
      <chunk>
        <stat>
          <functioncall>
            <varOrExp>
              <var>
                <NAME startline="2" startpos="15">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="2" startpos="20">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="2" startpos="21">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="2" startpos="27">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="2" startpos="29">end</TOKEN>
  </stat>
  <stat>
    <TOKEN startline="4" startpos="0">while</TOKEN>
    <exp>
      <prefixexp>
        <varOrExp>
          <var>
            <NAME startline="4" startpos="6">i</NAME>
          </var>
        </varOrExp>
      </prefixexp>
      <binop>
        <TOKEN startline="4" startpos="8">~=</TOKEN>
      </binop>
      <exp>
        <lua_number>
          <TOKEN startline="4" startpos="11">0</TOKEN>
        </lua_number>
      </exp>
    </exp>
    <TOKEN startline="4" startpos="13">do</TOKEN>
    <block>
      <chunk>
        <stat>
          <functioncall>
            <varOrExp>
              <var>
                <NAME startline="4" startpos="16">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="4" startpos="21">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="4" startpos="22">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="4" startpos="28">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="4" startpos="30">end</TOKEN>
  </stat>
  <stat>
    <TOKEN startline="6" startpos="0">repeat</TOKEN>
    <block>
      <chunk>
        <stat>
          <functioncall>
            <varOrExp>
              <var>
                <NAME startline="6" startpos="7">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="6" startpos="12">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="6" startpos="13">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="6" startpos="19">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="6" startpos="21">until</TOKEN>
    <exp>
      <prefixexp>
        <varOrExp>
          <var>
            <NAME startline="6" startpos="27">i</NAME>
          </var>
        </varOrExp>
      </prefixexp>
      <binop>
        <TOKEN startline="6" startpos="29">==</TOKEN>
      </binop>
      <exp>
        <lua_number>
          <TOKEN startline="6" startpos="32">0</TOKEN>
        </lua_number>
      </exp>
    </exp>
  </stat>
  <stat>
    <TOKEN startline="8" startpos="0">for</TOKEN>
    <NAME startline="8" startpos="4">j</NAME>
    <TOKEN startline="8" startpos="6">=</TOKEN>
    <exp>
      <lua_number>
        <TOKEN startline="8" startpos="8">0</TOKEN>
      </lua_number>
    </exp>
    <TOKEN startline="8" startpos="9">,</TOKEN>
    <exp>
      <lua_number>
        <TOKEN startline="8" startpos="11">1</TOKEN>
      </lua_number>
    </exp>
    <TOKEN startline="8" startpos="12">,</TOKEN>
    <exp>
      <lua_number>
        <TOKEN startline="8" startpos="14">1</TOKEN>
      </lua_number>
    </exp>
    <TOKEN startline="8" startpos="16">do</TOKEN>
    <block>
      <chunk>
        <stat>
          <functioncall>
            <varOrExp>
              <var>
                <NAME startline="8" startpos="19">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="8" startpos="24">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="8" startpos="25">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="8" startpos="31">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="8" startpos="33">end</TOKEN>
  </stat>
</chunk>