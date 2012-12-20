<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C">
  <function>
    <type>
      <name>int</name>
    </type>
    <name>test</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>
    <block>{
 <if>if<condition>(<expr><name>n</name> &gt; 10</expr>)</condition><then><block>{
  <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"aaa"</expr></argument>)</argument_list></call></expr>;</expr_stmt><if>if<condition>(<expr><name>n</name> &lt; 30</expr>)</condition><then><block>{
   <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"bbb"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
  }</block></then></if>
 }</block></then><else>else<block>{
  <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"ccc"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
 }</block></else></if>
}</block>
  </function>
</unit>