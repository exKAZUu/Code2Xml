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
                <NAME startline="3" startpos="1">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="3" startpos="6">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="3" startpos="7">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="3" startpos="13">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="4" startpos="0">end</TOKEN>
  </stat>
  <stat>
    <TOKEN startline="6" startpos="0">while</TOKEN>
    <exp>
      <prefixexp>
        <varOrExp>
          <var>
            <NAME startline="6" startpos="6">i</NAME>
          </var>
        </varOrExp>
      </prefixexp>
      <binop>
        <TOKEN startline="6" startpos="8">~=</TOKEN>
      </binop>
      <exp>
        <lua_number>
          <TOKEN startline="6" startpos="11">0</TOKEN>
        </lua_number>
      </exp>
    </exp>
    <TOKEN startline="6" startpos="13">do</TOKEN>
    <block>
      <chunk>
        <stat>
          <functioncall>
            <varOrExp>
              <var>
                <NAME startline="7" startpos="1">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="7" startpos="6">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="7" startpos="7">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="7" startpos="13">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="8" startpos="0">end</TOKEN>
  </stat>
  <stat>
    <TOKEN startline="10" startpos="0">repeat</TOKEN>
    <block>
      <chunk>
        <stat>
          <functioncall>
            <varOrExp>
              <var>
                <NAME startline="11" startpos="1">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="11" startpos="6">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="11" startpos="7">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="11" startpos="13">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="12" startpos="0">until</TOKEN>
    <exp>
      <prefixexp>
        <varOrExp>
          <var>
            <NAME startline="12" startpos="6">i</NAME>
          </var>
        </varOrExp>
      </prefixexp>
      <binop>
        <TOKEN startline="12" startpos="8">==</TOKEN>
      </binop>
      <exp>
        <lua_number>
          <TOKEN startline="12" startpos="11">0</TOKEN>
        </lua_number>
      </exp>
    </exp>
  </stat>
  <stat>
    <TOKEN startline="14" startpos="0">for</TOKEN>
    <NAME startline="14" startpos="4">j</NAME>
    <TOKEN startline="14" startpos="6">=</TOKEN>
    <exp>
      <lua_number>
        <TOKEN startline="14" startpos="8">0</TOKEN>
      </lua_number>
    </exp>
    <TOKEN startline="14" startpos="9">,</TOKEN>
    <exp>
      <lua_number>
        <TOKEN startline="14" startpos="11">1</TOKEN>
      </lua_number>
    </exp>
    <TOKEN startline="14" startpos="12">,</TOKEN>
    <exp>
      <lua_number>
        <TOKEN startline="14" startpos="14">1</TOKEN>
      </lua_number>
    </exp>
    <TOKEN startline="14" startpos="16">do</TOKEN>
    <block>
      <chunk>
        <stat>
          <functioncall>
            <varOrExp>
              <var>
                <NAME startline="15" startpos="1">print</NAME>
              </var>
            </varOrExp>
            <nameAndArgs>
              <args>
                <TOKEN startline="15" startpos="6">(</TOKEN>
                <explist1>
                  <exp>
                    <lua_string>
                      <TOKEN startline="15" startpos="7">"test"</TOKEN>
                    </lua_string>
                  </exp>
                </explist1>
                <TOKEN startline="15" startpos="13">)</TOKEN>
              </args>
            </nameAndArgs>
          </functioncall>
        </stat>
      </chunk>
    </block>
    <TOKEN startline="16" startpos="0">end</TOKEN>
  </stat>
</chunk>