<unit language="C++">
  <include>#<directive>include</directive> <file>&lt;stdio.h&gt;</file></include>

<function><type><name>int</name></type> <name>main</name><parameter_list>()</parameter_list> <block>{
	<decl_stmt><decl><type><name>int</name></type> <name>i</name> =<init> <expr>0</expr></init></decl>;</decl_stmt>
	
	<if>if <condition>(<expr><name>i</name> == 0</expr>)</condition><then> <block>{
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
	}</block></then></if>
	
	<switch>switch<condition>(<expr><name>i</name></expr>)</condition> <block>{
		<case>case <expr>0</expr>:
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
	</case>}</block></switch>
	
	<while>while <condition>(<expr><name>i</name> != 0</expr>)</condition> <block>{
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
	}</block></while>
	
	<do>do <block>{
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
	}</block> while <condition>(<expr><name>i</name> != 0</expr>)</condition>;</do>
	
	<for>for (<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name> &lt; 0</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <block>{
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
	}</block></for>
	<return>return <expr>0</expr>;</return>
}</block></function>
</unit>