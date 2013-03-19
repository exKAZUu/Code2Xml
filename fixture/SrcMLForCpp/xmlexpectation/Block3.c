<unit language="C++">
  <include>#<directive>include</directive> <file>&lt;stdio.h&gt;</file></include>

<function><type><name>int</name></type> <name>main</name><parameter_list>()</parameter_list> <block>{
	<decl_stmt><decl><type><name>int</name></type> <name>i</name> =<init> <expr>0</expr></init></decl>;</decl_stmt>
	
	<if>if <condition>(<expr><name>i</name> == 0</expr>)</condition><then><empty_stmt>;</empty_stmt></then></if>
	
	<switch>switch<condition>(<expr><name>i</name></expr>)</condition><empty_stmt>;</empty_stmt></switch>
	
	<while>while <condition>(<expr><name>i</name> != 0</expr>)</condition><empty_stmt>;</empty_stmt></while>

	<do>do <empty_stmt>;</empty_stmt> while <condition>(<expr><name>i</name> != 0</expr>)</condition>;</do>
	
	<for>for (<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name> &lt; 0</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)<empty_stmt>;</empty_stmt></for>
	
	<if>if <condition>(<expr><name>i</name> == 0</expr>)</condition><then> <block>{}</block></then></if>
	
	<switch>switch<condition>(<expr><name>i</name></expr>)</condition> <block>{}</block></switch>
	
	<while>while <condition>(<expr><name>i</name> != 0</expr>)</condition> <block>{}</block></while>

	<do>do <block>{}</block> while <condition>(<expr><name>i</name> != 0</expr>)</condition>;</do>
	
	<for>for (<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name> &lt; 0</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <block>{}</block></for>

	<return>return <expr>0</expr>;</return>
}</block></function>
</unit>