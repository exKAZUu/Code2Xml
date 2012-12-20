<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C">
  <cpp:include>#<cpp:directive>include</cpp:directive><cpp:file>&lt;stdio.h&gt;</cpp:file></cpp:include>
  <cpp:include>#<cpp:directive>include</cpp:directive><cpp:file>&lt;math.h&gt;</cpp:file></cpp:include>
  <comment type="line">//#define N 500</comment>
  <comment type="line">//#define M 601</comment>
  <comment type="line">// log 16 =  1.204119982656</comment>
  <cpp:include>#<cpp:directive>include</cpp:directive><cpp:file>"multi.h"</cpp:file></cpp:include>
  <function_decl>
    <type>
      <name>int</name>
    </type>
    <name>NextPrime</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>;</function_decl>
  <function_decl>
    <type>
      <name>int</name>
    </type>
    <name>divisor</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>;</function_decl>
  <function>
    <type>
      <name>void</name>
    </type>
    <name>main</name>
    <parameter_list>()</parameter_list>
    <block>{
    <decl_stmt><decl><type><name>unsigned</name></type><name><name>Mersenne</name><index>[<expr>500</expr>]</index></name>, <name><name>S</name><index>[<expr>500</expr>]</index></name>, <name><name>T</name><index>[<expr>500</expr>]</index></name>, <name><name>quot</name><index>[<expr>500</expr>]</index></name>, <name><name>res</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt><decl_stmt><decl><type><name>int</name></type><name><name>a</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt><decl_stmt><decl><type><name>int</name></type><name>p</name>, <name>j</name>, <name>k</name>, <name>t</name>, <name>d</name>, <name>r</name></decl>;</decl_stmt><expr_stmt><expr><name>p</name> = 5</expr>;</expr_stmt><while>while<condition>(<expr><name>p</name> &lt;525</expr>)</condition><block>{
        
        <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>Mersenne</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><name><name>Mersenne</name><index>[<expr>0</expr>]</index></name> = 1</expr>;</expr_stmt><expr_stmt><expr><call><name>LongLeftShift</name><argument_list>(<argument><expr><name>Mersenne</name></expr></argument>, <argument><expr><name>p</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><name><name>a</name><index>[<expr>0</expr>]</index></name> = 1</expr>;</expr_stmt><expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>Mersenne</name></expr></argument>, <argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><comment type="line">// Mersenne = 2 ÁEp æ - 1</comment><expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"p = %d  \n"</expr></argument>, <argument><expr><name>p</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><comment type="line">// Display(Mersenne);</comment><expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>S</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><name><name>S</name><index>[<expr>0</expr>]</index></name> = 4</expr>;</expr_stmt><for>for(<init><expr><name>j</name> = 1</expr>;</init><condition><expr><name>j</name>&lt;<name>p</name>-1</expr>;</condition><incr><expr><name>j</name>++</expr></incr>)<block>{

            <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><call><name>LongMul</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><comment type="line">//  S -&gt; S^2</comment><expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><name><name>a</name><index>[<expr>0</expr>]</index></name> = 2</expr>;</expr_stmt><expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><comment type="line">//  S -&gt; S^2 - 2</comment><expr_stmt><expr><call><name>LongDiv</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>Mersenne</name></expr></argument>, <argument><expr><name>quot</name></expr></argument>, <argument><expr><name>res</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><if>if<condition>(<expr><call><name>DivCheck</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>Mersenne</name></expr></argument>, <argument><expr><name>quot</name></expr></argument>, <argument><expr><name>res</name></expr></argument>)</argument_list></call>==0</expr>)</condition><then><block>{
                    <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"DivCheck Failed\n"</expr></argument>)</argument_list></call></expr>;</expr_stmt><return>return;</return>
            }</block></then></if><expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>S</name></expr></argument>,<argument><expr><name>T</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><call><name>LongRightShift</name><argument_list>(<argument><expr><name>T</name></expr></argument>, <argument><expr><name>p</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><name>t</name> = <name>p</name>/16</expr>;</expr_stmt><expr_stmt><expr><name>r</name> = <name>p</name> - 16*<name>t</name></expr>;</expr_stmt><expr_stmt><expr><name>d</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>S</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><for>for(<init><expr><name>k</name> = <name>d</name></expr>;</init><condition><expr><name>k</name>&gt;<name>t</name></expr>;</condition><incr><expr><name>k</name>--</expr></incr>)<block>{
                <expr_stmt><expr><name><name>S</name><index>[<expr><name>k</name></expr>]</index></name> = 0</expr>;</expr_stmt>
            }</block></for><expr_stmt><expr><name><name>S</name><index>[<expr><name>t</name></expr>]</index></name> = (<name><name>S</name><index>[<expr><name>t</name></expr>]</index></name>&lt;&lt;(32-<name>r</name>))&gt;&gt;(32-<name>r</name>)</expr>;</expr_stmt><expr_stmt><expr><call><name>Add</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>T</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><name>k</name> = <call><name>Compare</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>Mersenne</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><if>if<condition>(<expr><name>k</name>==1 || <name>k</name>==0</expr>)</condition><then><block>{
                <expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>S</name></expr></argument>, <argument><expr><name>Mersenne</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            }</block></then></if><expr_stmt><expr><name>k</name> = <call><name>Compare</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>S</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><if>if<condition>(<expr><name>k</name>!=0</expr>)</condition><then><block>{
                <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"Something is wrong\n"</expr></argument>)</argument_list></call></expr>;</expr_stmt><return>return;</return>
            }</block></then></if>

 

        }</block></for><if>if<condition>(<expr><call><name>ZeroCheck</name><argument_list>(<argument><expr><name>S</name></expr></argument>)</argument_list></call>==0</expr>)</condition><then><expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"mersenne,   p = %d\n"</expr></argument>, <argument><expr><name>p</name></expr></argument>)</argument_list></call></expr>;</expr_stmt></then></if><expr_stmt><expr><name>p</name> = <name>p</name>+2</expr>;</expr_stmt><expr_stmt><expr><name>p</name> = <call><name>NextPrime</name><argument_list>(<argument><expr><name>p</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>   
    }</block></while>
}</block>
  </function>
  <comment type="line">// n ÈãÌÁE�¬ÌfE(&gt;=3) ðÔ·B</comment>
  <function>
    <type>
      <name>int</name>
    </type>
    <name>NextPrime</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>
    <block>{
    <if>if<condition>(<expr><name>n</name> &lt;3</expr>)</condition><then><expr_stmt><expr><name>n</name> = 3</expr>;</expr_stmt></then></if><if>if<condition>(<expr><name>n</name>%2 == 0</expr> )</condition><then><expr_stmt><expr><name>n</name>++</expr>;</expr_stmt></then></if><while>while<condition>(<expr><name>n</name> &gt; <call><name>divisor</name><argument_list>(<argument><expr><name>n</name></expr></argument>)</argument_list></call></expr>)</condition><expr_stmt><expr><name>n</name> = <name>n</name>+2</expr>;</expr_stmt></while><return>return <expr><name>n</name></expr>;</return>
}</block>
  </function>
  <comment type="line">// n ÌÁE�¬Ì³ÌñE(&gt;1) ðÔ·B</comment>
  <function>
    <type>
      <name>int</name>
    </type>
    <name>divisor</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>
    <block>{
    <decl_stmt><decl><type><name>int</name></type><name>s</name>,<name>i</name></decl>;</decl_stmt><if>if<condition>(<expr><name>n</name>%2 == 0</expr>)</condition><then><return>return <expr>2</expr>;</return></then></if><expr_stmt><expr><name>s</name> = (<name>int</name>) <call><name>sqrt</name><argument_list>(<argument><expr><name>n</name></expr></argument>)</argument_list></call></expr>;</expr_stmt><expr_stmt><expr><name>i</name> = 3</expr>;</expr_stmt><while>while<condition>(<expr><name>i</name> &lt;= <name>s</name></expr>)</condition><block>{
        <if>if<condition>(<expr><name>n</name>%<name>i</name> == 0</expr>)</condition><then><return>return <expr><name>i</name></expr>;</return></then></if><expr_stmt><expr><name>i</name> = <name>i</name>+2</expr>;</expr_stmt>
    }</block></while><return>return <expr><name>n</name></expr>;</return>
}</block>
  </function>
</unit>