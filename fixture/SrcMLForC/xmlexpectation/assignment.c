<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C">
  <function>
    <type>
      <name>int</name>
    </type>
    <name>assignment</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>
    <block>{
 <if>if<condition>(<expr><name>n</name> == 1</expr>)</condition><then><block>{
  <expr_stmt><expr><name>a</name> = 1+1</expr>;</expr_stmt><expr_stmt><expr><name>b</name>++</expr>;</expr_stmt>
 }</block></then><else>else <if>if<condition>(<expr><name>n</name> == 2</expr>)</condition><then><block>{
  <expr_stmt><expr><name>a</name> = 2 + 2</expr>;</expr_stmt><expr_stmt><expr><name>b</name>--</expr>;</expr_stmt>
 }</block></then><else>else <if>if <condition>(<expr><name>n</name> == 3</expr>)</condition><then><block>{
  <return>return <expr><name>n</name></expr>;</return>
 }</block></then><else>else<block>{
  <return>return <expr>10</expr>;</return>
 }</block></else></if></else></if></else></if>
}</block>
  </function>
</unit>