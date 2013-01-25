<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C++">
  <function>
    <type>
      <name>int</name>
    </type>
    <name>emptyTest</name>
    <parameter_list>(<param><decl><type><name>int</name></type><name>n</name></decl></param>)</parameter_list>
    <block>{
 <if>if<condition>(<expr><name>n</name> == 10</expr>)</condition><then><empty_stmt>;</empty_stmt></then></if>
}</block>
  </function>
</unit>