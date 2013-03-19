<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C++">
  <cpp:include>#<cpp:directive>include</cpp:directive> <cpp:file>&lt;stdio.h&gt;</cpp:file></cpp:include>


<function><type><name>int</name></type> <name>main</name><parameter_list>(<param><decl><type><name>void</name></type></decl></param>)</parameter_list>
<block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>, <name>j</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>double</name></type> <name><name>x</name><index>[<expr>3</expr>]</index></name> =<init> <expr><block>{<expr>-33.0</expr>, <expr>9.0</expr>, <expr>6.0</expr>}</block></expr></init></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>double</name></type> <name><name>a</name><index>[<expr>3</expr>]</index><index>[<expr>3</expr>]</index></name> =<init> <expr><block>{<expr><block>{<expr>2.0</expr>, <expr>4.0</expr>, <expr>6.0</expr>}</block></expr>, 
                      <expr><block>{<expr>3.0</expr>, <expr>8.0</expr>, <expr>7.0</expr>}</block></expr>, 
                      <expr><block>{<expr>5.0</expr>, <expr>7.0</expr>, <expr>12345678901234567890.0</expr>}</block></expr>}</block></expr></init></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>double</name></type> <name><name>y</name><index>[<expr>3</expr>]</index></name></decl>;</decl_stmt>


    <comment type="block">/*  print matrix and vector  */</comment>
    <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"x = \n"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <for>for (<init><expr><name>i</name>=0</expr>;</init> <condition><expr><name>i</name>&lt;3</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <block>{
        <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"%6.2f\n"</expr></argument>, <argument><expr><name><name>x</name><index>[<expr><name>i</name></expr>]</index></name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    }</block></for>

    <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"A = \n"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <for>for (<init><expr><name>i</name>=0</expr>;</init> <condition><expr><name>i</name>&lt;3</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <block>{
        <for>for (<init><expr><name>j</name>=0</expr>;</init> <condition><expr><name>j</name>&lt;3</expr>;</condition> <incr><expr><name>j</name>++</expr></incr>) <block>{
            <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>" %6.5f"</expr></argument>, <argument><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index><index>[<expr><name>j</name></expr>]</index></name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        }</block></for>
        <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"\n"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
    }</block></for>


    <comment type="block">/*  multiplication  */</comment>
    <for>for(<init><expr><name>i</name>=0</expr>;</init> <condition><expr><name>i</name>&lt;3</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)<block>{
        <expr_stmt><expr><name><name>y</name><index>[<expr><name>i</name></expr>]</index></name> = 0.0</expr>;</expr_stmt>
        <for>for(<init><expr><name>j</name>=0</expr>;</init> <condition><expr><name>j</name>&lt;3</expr>;</condition> <incr><expr><name>j</name>++</expr></incr>)<block>{
            <expr_stmt><expr><name><name>y</name><index>[<expr><name>i</name></expr>]</index></name> += <name><name>a</name><index>[<expr><name>i</name></expr>]</index><index>[<expr><name>j</name></expr>]</index></name>*<name><name>x</name><index>[<expr><name>j</name></expr>]</index></name></expr>;</expr_stmt>
        }</block></for>
    }</block></for>


    <comment type="block">/*  print answer  */</comment>            
    <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"A*x = \n"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <for>for(<init><expr><name>i</name>=0</expr>;</init> <condition><expr><name>i</name>&lt;3</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)<block>{
        <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"%6.2f\n"</expr></argument>, <argument><expr><name><name>y</name><index>[<expr><name>i</name></expr>]</index></name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    }</block></for>


    <return>return <expr>0</expr>;</return>
}</block></function>
</unit>