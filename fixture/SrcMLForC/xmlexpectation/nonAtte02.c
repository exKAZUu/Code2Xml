<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C">
  <typedef>typedef <type><name>unsigned</name><name>long</name></type><name>__dev32_t</name>;</typedef>
  <typedef>typedef <type><name>__dev32_t</name></type><name>dev_t</name>;</typedef>
  <function>
    <type>
      <name>static</name>
      <name>__inline</name>
      <name>unsigned</name>
      <name>short</name>
    </type>
    <name>bswap_16</name>
    <parameter_list>(<param><decl><type><name>unsigned</name><name>short</name></type><name>__x</name></decl></param>)</parameter_list>
    <block>{
  <return>return <expr>(<name>__x</name> &gt;&gt; 8) | (<name>__x</name> &lt;&lt; 8)</expr>;</return>
}</block>
  </function>
  <function>
    <type>
      <name>static</name>
      <name>__inline</name>
      <name>unsigned</name>
      <name>int</name>
    </type>
    <name>bswap_32</name>
    <parameter_list>(<param><decl><type><name>unsigned</name><name>int</name></type><name>__x</name></decl></param>)</parameter_list>
    <block>{
  <return>return <expr>(<call><name>bswap_16</name><argument_list>(<argument><expr><name>__x</name> &amp; 0xffff</expr></argument>)</argument_list></call> &lt;&lt; 16) | (<call><name>bswap_16</name><argument_list>(<argument><expr><name>__x</name> &gt;&gt; 16</expr></argument>)</argument_list></call>)</expr>;</return>
}</block>
  </function>
  <function>
    <type>
      <name>static</name>
      <name>__inline</name>
      <name>unsigned</name>
      <name>long</name>
      <name>long</name>
    </type>
    <name>bswap_64</name>
    <parameter_list>(<param><decl><type><name>unsigned</name><name>long</name><name>long</name></type><name>__x</name></decl></param>)</parameter_list>
    <block>{
  <return>return <expr>(((<name>unsigned</name><name>long</name><name>long</name>) <call><name>bswap_32</name><argument_list>(<argument><expr><name>__x</name> &amp; 0xffffffffull</expr></argument>)</argument_list></call>) &lt;&lt; 32) | (<call><name>bswap_32</name><argument_list>(<argument><expr><name>__x</name> &gt;&gt; 32</expr></argument>)</argument_list></call>)</expr>;</return>
}</block>
  </function>
  <decl_stmt>
    <decl>
      <type>
        <name>extern</name>
        <name>__inline__</name>
      </type>
      <name>__attribute__</name> ((<name>__always_inline__</name>)</decl>
  </decl_stmt>) <function_decl><type><name>int</name></type><name>gnu_dev_major</name><parameter_list>(<param><decl><type><name>dev_t</name></type></decl></param>)</parameter_list>;</function_decl><decl_stmt><decl><type><name>extern</name><name>__inline__</name></type><name>__attribute__</name> ((<name>__always_inline__</name>)</decl></decl_stmt>) <function_decl><type><name>int</name></type><name>gnu_dev_minor</name><parameter_list>(<param><decl><type><name>dev_t</name></type></decl></param>)</parameter_list>;</function_decl><decl_stmt><decl><type><name>extern</name><name>__inline__</name></type><name>__attribute__</name> ((<name>__always_inline__</name>)</decl></decl_stmt>) <function_decl><type><name>dev_t</name></type><name>gnu_dev_makedev</name><parameter_list>(<param><decl><type><name>int</name></type></decl></param>, <param><decl><type><name>int</name></type></decl></param>)</parameter_list>;</function_decl><decl_stmt><decl><type><name>extern</name><name>__inline__</name></type><name>__attribute__</name> ((<name>__always_inline__</name>)</decl></decl_stmt>) <function><type><name>int</name></type><name>gnu_dev_major</name><parameter_list>(<param><decl><type><name>dev_t</name></type><name>dev</name></decl></param>)</parameter_list><block>{
 <return>return <expr><call>(<name>int</name>)<argument_list>(<argument><expr>((<name>dev</name>) &gt;&gt; 16) &amp; 0xffff</expr></argument>)</argument_list></call></expr>;</return>
}</block></function><decl_stmt><decl><type><name>extern</name><name>__inline__</name></type><name>__attribute__</name> ((<name>__always_inline__</name>)</decl></decl_stmt>) <function><type><name>int</name></type><name>gnu_dev_minor</name><parameter_list>(<param><decl><type><name>dev_t</name></type><name>dev</name></decl></param>)</parameter_list><block>{
 <return>return <expr><call>(<name>int</name>)<argument_list>(<argument><expr>(<name>dev</name>) &amp; 0xffff</expr></argument>)</argument_list></call></expr>;</return>
}</block></function><decl_stmt><decl><type><name>extern</name><name>__inline__</name></type><name>__attribute__</name> ((<name>__always_inline__</name>)</decl></decl_stmt>) <function><type><name>dev_t</name></type><name>gnu_dev_makedev</name><parameter_list>(<param><decl><type><name>int</name></type><name>maj</name></decl></param>, <param><decl><type><name>int</name></type><name>min</name></decl></param>)</parameter_list><block>{
 <return>return <expr>(((<name>maj</name>) &lt;&lt; 16) | ((<name>min</name>) &amp; 0xffff))</expr>;</return>
}</block></function></unit>