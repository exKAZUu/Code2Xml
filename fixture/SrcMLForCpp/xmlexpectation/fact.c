<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C++">
  <function>
    <type>
      <name>int</name>
    </type>
    <name>fact</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>
    <block>{
 <if>if<condition>(<expr><name>n</name> &lt;= 1</expr>)</condition><then><block>{
  <return>return <expr>1</expr>;</return>
 }</block></then><else>else<block>{
  <return>return <expr><name>n</name> * <call><name>fact</name><argument_list>(<argument><expr><name>n</name> - 1</expr></argument>)</argument_list></call></expr>;</return>
 }</block></else></if>
}</block>
  </function>
</unit>