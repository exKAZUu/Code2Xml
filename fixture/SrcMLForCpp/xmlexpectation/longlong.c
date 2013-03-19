<unit language="C++">
<function><type><name>static</name> <name>__inline</name> <name>unsigned</name> <name>long</name> <name>long</name></type> <name>bswap_64</name> <parameter_list>(<param><decl><type><name>unsigned</name> <name>long</name> <name>long</name></type> <name>__x</name></decl></param>)</parameter_list>
<block>{
  <return>return <expr>(((<name>unsigned</name> <name>long</name> <name>long</name>) <call><name>bswap_32</name> <argument_list>(<argument><expr><name>__x</name> &amp; 0xffffffffull</expr></argument>)</argument_list></call>) &lt;&lt; 32) | (<call><name>bswap_32</name> <argument_list>(<argument><expr><name>__x</name> &gt;&gt; 32</expr></argument>)</argument_list></call>)</expr>;</return>
}</block></function>
</unit>