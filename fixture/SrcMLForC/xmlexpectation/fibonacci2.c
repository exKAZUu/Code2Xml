<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C">
  <function>
    <type>
      <name>int</name>
    </type>
    <name>fibonacci2</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>
    <block>{
 <if>if<condition>(<expr><name>n</name> &lt; 0</expr>)</condition><then><block>{
  <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"aaaa"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
 }</block></then><else>else <if>if<condition>(<expr><name>n</name> == 1 || <name>n</name> == 2</expr>)</condition><then><block>{
  <return>return <expr>1</expr>;</return>
 }</block></then><else>else<block>{
  <return>return <expr><call><name>fibonacci2</name><argument_list>(<argument><expr><name>n</name> - 1</expr></argument>)</argument_list></call> + <call><name>fibonacci2</name><argument_list>(<argument><expr><name>n</name> - 2</expr></argument>)</argument_list></call></expr>;</return>
 }</block></else></if></else></if>
}</block>
  </function>
</unit>