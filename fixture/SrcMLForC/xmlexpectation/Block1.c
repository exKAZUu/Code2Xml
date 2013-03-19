<unit language="C">
  <include>#<directive>include</directive> <file>&lt;stdio.h&gt;</file></include>

<function><type><name>int</name></type> <name>main</name><parameter_list>()</parameter_list> <block>{
	<decl_stmt><decl><type><name>int</name></type> <name>i</name> =<init> <expr>0</expr></init></decl>;</decl_stmt>
	
	<if>if <condition>(<expr><name>i</name> == 0</expr>)</condition><then>
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt></then></if>
	
	<if>if <condition>(<expr><name>i</name> &lt;= 0 &amp;&amp; (<name>i</name> &gt;= 0 || <name>i</name> != 0)</expr>)</condition><then>
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt></then></if>
	
	<switch>switch<condition>(<expr><name>i</name></expr>)</condition></switch>
		<case>case <expr>0</expr>:
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
	
	<while>while <condition>(<expr><name>i</name> != 0</expr>)</condition>
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt></while>
	
	<do>do
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
	while <condition>(<expr><name>i</name> != 0</expr>)</condition>;</do>
	
	<for>for (<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name> &lt; 0</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)
		<expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"test"</expr></argument>)</argument_list></call></expr>;</expr_stmt></for>
	<return>return <expr>0</expr>;</return>
</case>}</block></function>
</unit>