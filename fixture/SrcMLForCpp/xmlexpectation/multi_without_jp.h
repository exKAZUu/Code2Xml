<unit xmlns="http://www.sdml.info/srcML/src" xmlns:cpp="http://www.sdml.info/srcML/cpp" language="C++">
  <function_decl>
    <type>
      <name>void</name>
    </type> <name>Add</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>Sub</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>Mul</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name>d</name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>LongMul</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>

<function_decl><type><name>unsigned</name></type> <name>Div</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name>d</name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>LongDiv</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>quot</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>res</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>int</name></type> <name>DivCheck</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>quot</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>res</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>

<function_decl><type><name>int</name></type> <name>Compare</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>LeftShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>LongLeftShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>RightShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>LongRightShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>Initialize</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>c</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>

<function_decl><type><name>void</name></type> <name>Copy</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>int</name></type> <name>ZeroCheck</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>int</name></type> <name>Degree</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>

<function_decl><type><name>void</name></type> <name>ToDecimal</name><parameter_list>(<param><decl><type><name>unsigned</name> []</type></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>w</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>ToHex</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>w</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>unsigned</name></type> <name>ToHexDiv</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>z</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>int</name></type> <name>ToHexZeroCheck</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>z</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>

<function_decl><type><name>void</name></type> <name>Display</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>
<function_decl><type><name>void</name></type> <name>DisplayHex</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list>;</function_decl>











<function><type><name>void</name></type> <name>Add</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>,<name>j</name>, <name>s</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>unsigned</name></type> <name>x</name></decl>;</decl_stmt>
    <expr_stmt><expr><name>s</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>s</name></expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)<block>{
        <expr_stmt><expr><name>x</name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>+<name><name>b</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt>
        <if>if<condition>(<expr><name>x</name> &lt;= 0xffff</expr>)</condition><then><block>{ 
            <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = <name>x</name></expr>;</expr_stmt>
        }</block></then> <else>else <block>{         
            <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = <name>x</name> &amp; 0xffff</expr>;</expr_stmt>
                         
            <expr_stmt><expr><name>j</name> = <name>i</name>+1</expr>;</expr_stmt>     
            <while>while<condition>(<expr><name><name>a</name><index>[<expr><name>j</name></expr>]</index></name> == 0xffff</expr>)</condition> <expr_stmt><expr><name><name>a</name><index>[<expr><name>j</name>++</expr>]</index></name> = 0</expr>;</expr_stmt></while>
            <expr_stmt><expr><name><name>a</name><index>[<expr><name>j</name></expr>]</index></name>++</expr>;</expr_stmt>
        }</block></else></if>
    }</block></for>
}</block></function>




<function><type><name>void</name></type> <name>Sub</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>,<name>j</name>, <name>s</name></decl>;</decl_stmt>
    <expr_stmt><expr><name>s</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>s</name></expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)<block>{
        <if>if<condition>(<expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>&gt;=<name><name>b</name><index>[<expr><name>i</name></expr>]</index></name></expr>)</condition><then><block>{  
            <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> - <name><name>b</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt>
        }</block></then> <else>else <block>{         
            <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = (0x10000 + <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>) - <name><name>b</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt>
            <expr_stmt><expr><name>j</name> = <name>i</name>+1</expr>;</expr_stmt>     
            <while>while<condition>(<expr><name><name>a</name><index>[<expr><name>j</name></expr>]</index></name> == 0</expr>)</condition> <expr_stmt><expr><name><name>a</name><index>[<expr><name>j</name>++</expr>]</index></name> = 0xffff</expr>;</expr_stmt></while>
            <expr_stmt><expr><name><name>a</name><index>[<expr><name>j</name></expr>]</index></name>--</expr>;</expr_stmt>
        }</block></else></if>
    }</block></for>
}</block></function>





<function><type><name>void</name></type> <name>Mul</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name>d</name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>, <name>s</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>unsigned</name></type> <name>x</name>, <name>q</name></decl>;</decl_stmt>

    <expr_stmt><expr><name>s</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><name>q</name> = 0</expr>;</expr_stmt>               

    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>s</name>+1</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)<block>{
        <expr_stmt><expr><name>x</name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>*<name>d</name> + <name>q</name></expr>;</expr_stmt>  
                         
        <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = <name>x</name> &amp; 0xffff</expr>;</expr_stmt>
        <expr_stmt><expr><name>q</name> = <name>x</name>&gt;&gt;16</expr>;</expr_stmt>
                         
                         
    }</block></for>
}</block></function>





<function><type><name>void</name></type> <name>LongMul</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>,<name>j</name>,<name>k</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>int</name></type> <name>s</name>,<name>t</name></decl>;</decl_stmt>
	
    <decl_stmt><decl><type><name>unsigned</name></type> <name>x</name>, <name>q</name>, <name><name>c</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt>

    <expr_stmt><expr><name>s</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><name>t</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>       

    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>s</name></expr>;</condition> <incr><expr><name>i</name>++</expr></incr>)<block>{
        <for>for(<init><expr><name>j</name> = 0</expr>;</init> <condition><expr><name>j</name>&lt;=<name>t</name></expr>;</condition> <incr><expr><name>j</name>++</expr></incr>)<block>{
            <expr_stmt><expr><name>x</name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>*<name><name>b</name><index>[<expr><name>j</name></expr>]</index></name></expr>;</expr_stmt> <expr_stmt><expr><name>k</name> = <name>i</name>+<name>j</name></expr>;</expr_stmt>
                         
            <while>while<condition>(<expr><name>x</name>&gt;0</expr>)</condition><block>{
                <expr_stmt><expr><name>q</name> = <name><name>c</name><index>[<expr><name>k</name></expr>]</index></name> + <name>x</name></expr>;</expr_stmt>
                <expr_stmt><expr><name><name>c</name><index>[<expr><name>k</name></expr>]</index></name> = <name>q</name> &amp; 0xffff</expr>;</expr_stmt>
                <expr_stmt><expr><name>x</name> = <name>q</name>&gt;&gt;16</expr>;</expr_stmt>
                         
                         
                <expr_stmt><expr><name>k</name>++</expr>;</expr_stmt>     
            }</block></while>
        }</block></for>
    }</block></for>
    <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>c</name></expr></argument>,<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
}</block></function>





<function><type><name>unsigned</name></type> <name>Div</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name>d</name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>,<name>x</name>,<name>q</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>unsigned</name></type> <name>res</name></decl>;</decl_stmt>
    <expr_stmt><expr><name>res</name> = 0</expr>;</expr_stmt>             
    
    <expr_stmt><expr><name>i</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>       
    <while>while<condition>(<expr><name>i</name>&gt;=0</expr>)</condition><block>{
        <expr_stmt><expr><name>x</name> = (<name>res</name>&lt;&lt;16) + <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt>
                         
                         
        <expr_stmt><expr><name>q</name> = <name>x</name>/<name>d</name></expr>;</expr_stmt>         
        <expr_stmt><expr><name>res</name> = <name>x</name> - <name>q</name>*<name>d</name></expr>;</expr_stmt>   
        <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = <name>q</name></expr>;</expr_stmt>
        <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>             
    }</block></while>
    <return>return <expr><name>res</name></expr>;</return>
}</block></function>




<function><type><name>void</name></type> <name>LongDiv</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>, 
             <param><decl><type><name>unsigned</name></type> <name><name>quot</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>res</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>s</name>, <name>t</name>, <name>k</name>, <name>sh</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>int</name></type> <name>i</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>unsigned</name></type> <name>x</name>, <name>D</name>, <name>Q</name></decl>;</decl_stmt>
	
    <decl_stmt><decl><type><name>unsigned</name></type> <name><name>c</name><index>[<expr>500</expr>]</index></name>, <name><name>d</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt>
    
    
    <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>res</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>quot</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <if>if<condition>(<expr><call><name>Compare</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>b</name></expr></argument>)</argument_list></call> == -1</expr>)</condition><then> <return>return;</return></then></if>

    
    <expr_stmt><expr><name>t</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    
    
    
    

    <expr_stmt><expr><name>sh</name>=0</expr>;</expr_stmt>
    <expr_stmt><expr><name>x</name> = <name><name>b</name><index>[<expr><name>t</name></expr>]</index></name></expr>;</expr_stmt>
    <while>while<condition>( <expr>(<name>x</name> &amp;(0x8000)) == 0</expr>)</condition><block>{
        <expr_stmt><expr><name>x</name> = <name>x</name>&lt;&lt;1</expr>;</expr_stmt>
        <expr_stmt><expr><name>sh</name>++</expr>;</expr_stmt>
    }</block></while>

    <expr_stmt><expr><call><name>LeftShift</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>LeftShift</name><argument_list>(<argument><expr><name>b</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <while>while<condition>(<expr>1</expr>)</condition><block>{
        <expr_stmt><expr><name>s</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>res</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                                     
        <if>if<condition>(<expr><name><name>res</name><index>[<expr><name>s</name></expr>]</index></name> &gt;= <name><name>b</name><index>[<expr><name>t</name></expr>]</index></name></expr>)</condition><then><block>{          
            <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt> 
            <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>t</name></expr>;</condition><incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>c</name><index>[<expr><name>s</name>-<name>t</name>+<name>i</name></expr>]</index></name> = <name><name>b</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt></for>
            <expr_stmt><expr><name>k</name> = <call><name>Compare</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            <if>if<condition>(<expr><name>k</name> == 1 || <name>k</name> == 0</expr>)</condition><then><block>{
                <expr_stmt><expr><name><name>quot</name><index>[<expr><name>s</name>-<name>t</name></expr>]</index></name> = 1</expr>;</expr_stmt>
                <expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            }</block></then> <else>else <block>{
                <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>d</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                <for>for(<init><expr><name>i</name>=0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>t</name></expr>;</condition><incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>c</name><index>[<expr><name>s</name>-<name>t</name>-1+<name>i</name></expr>]</index></name>=<name><name>b</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt></for>
                <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>c</name></expr></argument>,<argument><expr><name>d</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>            
                <expr_stmt><expr><name>D</name> = 0xffff</expr>;</expr_stmt>
                <expr_stmt><expr><call><name>Mul</name><argument_list>(<argument><expr><name>c</name></expr></argument>,<argument><expr><name>D</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                <while>while<condition>(<expr>1</expr>)</condition><block>{
                    <expr_stmt><expr><name>k</name> = <call><name>Compare</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                    <if>if<condition>(<expr><name>k</name> == 1 || <name>k</name> ==  0</expr>)</condition><then> <break>break;</break></then></if>
                    <expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>c</name></expr></argument>,<argument><expr><name>d</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                    <expr_stmt><expr><name>D</name>--</expr>;</expr_stmt>
                }</block></while>
                <expr_stmt><expr><name><name>quot</name><index>[<expr><name>s</name>-<name>t</name>-1</expr>]</index></name> = <name>D</name></expr>;</expr_stmt>
                <expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            }</block></else></if>
        }</block></then> <else>else <block>{                      
            <expr_stmt><expr><name>x</name> = (<name><name>res</name><index>[<expr><name>s</name></expr>]</index></name>&lt;&lt;16) + <name><name>res</name><index>[<expr><name>s</name>-1</expr>]</index></name></expr>;</expr_stmt>
            <expr_stmt><expr><name>Q</name> = <name>x</name> / <name><name>b</name><index>[<expr><name>t</name></expr>]</index></name></expr>;</expr_stmt>
            <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>d</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            <for>for(<init><expr><name>i</name>=0</expr>;</init><condition><expr><name>i</name>&lt;=<name>t</name></expr>;</condition><incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>c</name><index>[<expr><name>s</name>-<name>t</name>-1+<name>i</name></expr>]</index></name> = <name><name>b</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt></for>
            <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>c</name></expr></argument>,<argument><expr><name>d</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            <expr_stmt><expr><call><name>Mul</name><argument_list>(<argument><expr><name>c</name></expr></argument>, <argument><expr><name>Q</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
            <while>while<condition>(<expr>1</expr>)</condition><block>{
                <expr_stmt><expr><name>k</name> = <call><name>Compare</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                <if>if<condition>(<expr><name>k</name> == 1 || <name>k</name> == 0</expr>)</condition><then> <break>break;</break></then></if>
                <expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>c</name></expr></argument>,<argument><expr><name>d</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
                <expr_stmt><expr><name>Q</name>--</expr>;</expr_stmt>
            }</block></while>
            <expr_stmt><expr><name><name>quot</name><index>[<expr><name>s</name>-<name>t</name>-1</expr>]</index></name> = <name>Q</name></expr>;</expr_stmt>
            <expr_stmt><expr><call><name>Sub</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        }</block></else></if>
        <expr_stmt><expr><name>k</name> = <call><name>Compare</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <if>if<condition>(<expr><name>k</name> == -1</expr>)</condition><then> <break>break;</break></then></if>
    }</block></while>
    <expr_stmt><expr><call><name>RightShift</name><argument_list>(<argument><expr><name>res</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>RightShift</name><argument_list>(<argument><expr><name>b</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
}</block></function>





<function><type><name>int</name></type> <name>DivCheck</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>quot</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>res</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    
	<decl_stmt><decl><type><name>unsigned</name></type> <name><name>c</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt>
    <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>b</name></expr></argument>,<argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>LongMul</name><argument_list>(<argument><expr><name>c</name></expr></argument>, <argument><expr><name>quot</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>Add</name><argument_list>(<argument><expr><name>c</name></expr></argument>, <argument><expr><name>res</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <if>if<condition>(<expr><call><name>Compare</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>c</name></expr></argument>)</argument_list></call> ==0</expr>)</condition><then> <return>return <expr>1</expr>;</return></then></if>
    <return>return <expr>0</expr>;</return>
}</block></function>




<function><type><name>int</name></type> <name>Compare</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>s</name>,<name>t</name></decl>;</decl_stmt>

    <expr_stmt><expr><name>s</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><name>t</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <if>if<condition>(<expr><name>s</name>&lt;<name>t</name></expr>)</condition><then> <return>return <expr>-1</expr>;</return></then></if>
    <if>if<condition>(<expr><name>s</name>&gt;<name>t</name></expr>)</condition><then> <return>return <expr>1</expr>;</return></then></if>
    <while>while<condition>(<expr><name>s</name>&gt;0 &amp;&amp; <name><name>a</name><index>[<expr><name>s</name></expr>]</index></name>==<name><name>b</name><index>[<expr><name>s</name></expr>]</index></name></expr>)</condition> <expr_stmt><expr><name>s</name>--</expr>;</expr_stmt></while>
    <if>if<condition>(<expr><name><name>a</name><index>[<expr><name>s</name></expr>]</index></name>&lt;<name><name>b</name><index>[<expr><name>s</name></expr>]</index></name></expr>)</condition><then> <return>return <expr>-1</expr>;</return></then></if>
    <if>if<condition>(<expr><name><name>a</name><index>[<expr><name>s</name></expr>]</index></name>&gt;<name><name>b</name><index>[<expr><name>s</name></expr>]</index></name></expr>)</condition><then> <return>return <expr>1</expr>;</return></then></if>
    <return>return <expr>0</expr>;</return>
}</block></function>



<function><type><name>void</name></type> <name>LeftShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>, <name>x</name></decl>;</decl_stmt>
    <if>if<condition>(<expr><name>sh</name> == 0</expr>)</condition><then> <return>return;</return></then></if>

    <expr_stmt><expr><name>i</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    
    <expr_stmt><expr><name>x</name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>&lt;&lt;<name>sh</name></expr>;</expr_stmt>
    <if>if<condition>(<expr><name>x</name> &gt; 0xffff</expr>)</condition><then> <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name>+1</expr>]</index></name> |= (<name>x</name>&gt;&gt;16)</expr>;</expr_stmt></then></if>
    <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = <name>x</name> &amp; 0xffff</expr>;</expr_stmt>
    <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>
    
    <while>while<condition>(<expr><name>i</name>&gt;=0</expr>)</condition><block>{
        <expr_stmt><expr><name>x</name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>&lt;&lt;<name>sh</name></expr>;</expr_stmt>
        <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name>+1</expr>]</index></name> |= (<name>x</name>&gt;&gt;16)</expr>;</expr_stmt>
        <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = <name>x</name> &amp; 0xffff</expr>;</expr_stmt>
        <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>
    }</block></while>
}</block></function>



<function><type><name>void</name></type> <name>LongLeftShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>, <name>u</name></decl>;</decl_stmt>
	
    <decl_stmt><decl><type><name>unsigned</name></type> <name><name>temp</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt>
    <if>if<condition>(<expr><name>sh</name> &lt; 16</expr>)</condition><then><block>{
        <expr_stmt><expr><call><name>LeftShift</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    }</block></then> <else>else <block>{
        <expr_stmt><expr><name>u</name> = <name>sh</name>/16</expr>;</expr_stmt>
        <expr_stmt><expr><name>sh</name> = <name>sh</name> - <name>u</name>*16</expr>;</expr_stmt>
        
        <expr_stmt><expr><name>i</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>temp</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <while>while<condition>(<expr><name>i</name>&gt;=0</expr>)</condition><block>{
            <expr_stmt><expr><name><name>temp</name><index>[<expr><name>i</name>+<name>u</name></expr>]</index></name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt>
            <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>
        }</block></while>
        <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>temp</name></expr></argument>, <argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <expr_stmt><expr><call><name>LeftShift</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    }</block></else></if>
}</block></function>


<function><type><name>void</name></type> <name>RightShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>, <name>j</name>, <name>x</name></decl>;</decl_stmt>
    <if>if<condition>(<expr><name>sh</name>==0</expr>)</condition><then> <return>return;</return></then></if>

    <expr_stmt><expr><name>i</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    
	
    <expr_stmt><expr><name>i</name> = 500-1</expr>;</expr_stmt>
    <while>while<condition>(<expr><name>i</name>&gt;0 &amp;&amp; <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>==0</expr>)</condition> <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt></while>
    
    <expr_stmt><expr><name><name>a</name><index>[<expr>0</expr>]</index></name> = <name><name>a</name><index>[<expr>0</expr>]</index></name>&gt;&gt;<name>sh</name></expr>;</expr_stmt>
    <expr_stmt><expr><name>j</name>=1</expr>;</expr_stmt>
    
    <while>while<condition>(<expr><name>j</name>&lt;=<name>i</name></expr>)</condition><block>{
        <expr_stmt><expr><name>x</name> = (<name><name>a</name><index>[<expr><name>j</name></expr>]</index></name>&lt;&lt;16)&gt;&gt;<name>sh</name></expr>;</expr_stmt>
        <expr_stmt><expr><name><name>a</name><index>[<expr><name>j</name>-1</expr>]</index></name>|= (<name>x</name> &amp; 0xffff)</expr>;</expr_stmt>
        <expr_stmt><expr><name><name>a</name><index>[<expr><name>j</name></expr>]</index></name> = <name>x</name>&gt;&gt;16</expr>;</expr_stmt>
        <expr_stmt><expr><name>j</name>++</expr>;</expr_stmt>
    }</block></while>
}</block></function>



<function><type><name>void</name></type> <name>LongRightShift</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>int</name></type> <name>sh</name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>, <name>u</name></decl>;</decl_stmt>
	
    <decl_stmt><decl><type><name>unsigned</name></type> <name><name>temp</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt>
    <if>if<condition>(<expr><name>sh</name> &lt; 16</expr>)</condition><then><block>{
        <expr_stmt><expr><call><name>RightShift</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    }</block></then> <else>else <block>{
        <expr_stmt><expr><name>u</name> = <name>sh</name>/16</expr>;</expr_stmt>
        <expr_stmt><expr><name>sh</name> = <name>sh</name> - <name>u</name>*16</expr>;</expr_stmt>

        <expr_stmt><expr><name>i</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>temp</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <while>while<condition>(<expr><name>i</name>&gt;=<name>u</name></expr>)</condition><block>{
            <expr_stmt><expr><name><name>temp</name><index>[<expr><name>i</name>-<name>u</name></expr>]</index></name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt>
            <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>
        }</block></while>
        <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>temp</name></expr></argument>, <argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <expr_stmt><expr><call><name>RightShift</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>sh</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    }</block></else></if>
}</block></function>




<function><type><name>void</name></type> <name>Initialize</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>c</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>,<name>t</name></decl>;</decl_stmt>
    <expr_stmt><expr><name>t</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>c</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>t</name></expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>c</name><index>[<expr><name>i</name></expr>]</index></name> = 0</expr>;</expr_stmt></for>
}</block></function>




<function><type><name>void</name></type> <name>Copy</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>b</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>,<name>s</name></decl>;</decl_stmt>
    <expr_stmt><expr><name>s</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>Initialize</name><argument_list>(<argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;=<name>s</name></expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>b</name><index>[<expr><name>i</name></expr>]</index></name> = <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt></for>
}</block></function>




<function><type><name>int</name></type> <name>ZeroCheck</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>,<name>j</name> =<init> <expr>0</expr></init></decl>;</decl_stmt>
	
    <for>for(<init><expr><name>i</name> = 500-1</expr>;</init> <condition><expr><name>i</name>&gt;=0</expr>;</condition> <incr><expr><name>i</name>--</expr></incr>)<block>{
        <if>if<condition>(<expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> !=0</expr> )</condition><then><block>{
            <expr_stmt><expr><name>j</name> = -1</expr>;</expr_stmt>
            <break>break;</break>
        }</block></then></if>
    }</block></for>
    <return>return <expr><name>j</name></expr>;</return>
}</block></function>




<function><type><name>int</name></type> <name>Degree</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list><block>{
	
    <decl_stmt><decl><type><name>int</name></type> <name>i</name> =<init> <expr>500-1</expr></init></decl>;</decl_stmt>
    <while>while<condition>(<expr><name>i</name>&gt;0 &amp;&amp; <name><name>a</name><index>[<expr><name>i</name></expr>]</index></name>==0</expr>)</condition> <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt></while>
    <return>return <expr><name>i</name></expr>;</return>
}</block></function>


<function><type><name>void</name></type> <name>ToDecimal</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>w</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name></decl>;</decl_stmt>
	
    <decl_stmt><decl><type><name>unsigned</name></type> <name><name>b</name><index>[<expr>500</expr>]</index></name></decl>;</decl_stmt>
    <expr_stmt><expr><call><name>Copy</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>b</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
	
    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;601</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>w</name><index>[<expr><name>i</name></expr>]</index></name> = 0</expr>;</expr_stmt></for>
    <expr_stmt><expr><name>i</name> = 0</expr>;</expr_stmt>
    <while>while<condition>( <expr><call><name>ZeroCheck</name><argument_list>(<argument><expr><name>b</name></expr></argument>)</argument_list></call>==-1</expr> )</condition> <expr_stmt><expr><name><name>w</name><index>[<expr><name>i</name>++</expr>]</index></name> = <call><name>Div</name><argument_list>(<argument><expr><name>b</name></expr></argument>, <argument><expr>10000</expr></argument>)</argument_list></call></expr>;</expr_stmt></while>

}</block></function>


<function><type><name>void</name></type> <name>ToHex</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>w</name><index>[]</index></name></decl></param>, <param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name></decl>;</decl_stmt>
	
    <decl_stmt><decl><type><name>unsigned</name></type> <name><name>z</name><index>[<expr>601</expr>]</index></name></decl>;</decl_stmt>
	
    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;601</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>z</name><index>[<expr><name>i</name></expr>]</index></name> = <name><name>w</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt></for>
    <for>for(<init><expr><name>i</name> = 0</expr>;</init> <condition><expr><name>i</name>&lt;500</expr>;</condition> <incr><expr><name>i</name>++</expr></incr>) <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name></expr>]</index></name> = 0</expr>;</expr_stmt></for>
    <expr_stmt><expr><name>i</name> = 0</expr>;</expr_stmt>
    <while>while<condition>( <expr><call><name>ToHexZeroCheck</name><argument_list>(<argument><expr><name>z</name></expr></argument>)</argument_list></call> == -1</expr>)</condition> <expr_stmt><expr><name><name>a</name><index>[<expr><name>i</name>++</expr>]</index></name> = <call><name>ToHexDiv</name><argument_list>(<argument><expr><name>z</name></expr></argument>)</argument_list></call></expr>;</expr_stmt></while>
}</block></function>



<function><type><name>unsigned</name></type> <name>ToHexDiv</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>z</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name></decl>;</decl_stmt>
    <decl_stmt><decl><type><name>unsigned</name></type> <name>x</name>, <name>q</name>, <name>res</name></decl>;</decl_stmt>

    <expr_stmt><expr><name>res</name> = 0</expr>;</expr_stmt>
    
    
	
    <expr_stmt><expr><name>i</name> = 601-1</expr>;</expr_stmt>
    <while>while<condition>(<expr><name>i</name>&gt;0 &amp;&amp; <name><name>z</name><index>[<expr><name>i</name></expr>]</index></name>==0</expr>)</condition><expr_stmt><expr><name>i</name>--</expr>;</expr_stmt></while>

    <while>while<condition>(<expr><name>i</name>&gt;=0</expr>)</condition><block>{
        <expr_stmt><expr><name>x</name> = <name>res</name>*10000 + <name><name>z</name><index>[<expr><name>i</name></expr>]</index></name></expr>;</expr_stmt>
        <expr_stmt><expr><name>q</name> = (<name>x</name>&gt;&gt;16)</expr>;</expr_stmt>
        <expr_stmt><expr><name>res</name> = <name>x</name> - (<name>q</name>&lt;&lt;16)</expr>;</expr_stmt>
        <expr_stmt><expr><name><name>z</name><index>[<expr><name>i</name></expr>]</index></name> = <name>q</name></expr>;</expr_stmt>
        <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>
    }</block></while>
    <return>return <expr><name>res</name></expr>;</return>
}</block></function>



<function><type><name>int</name></type> <name>ToHexZeroCheck</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>z</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name>, <name>j</name> =<init> <expr>0</expr></init></decl>;</decl_stmt>
	
    <for>for(<init><expr><name>i</name> = 601-1</expr>;</init><condition><expr><name>i</name>&gt;=0</expr>;</condition><incr><expr><name>i</name>--</expr></incr>)<block>{
        <if>if<condition>(<expr><name><name>z</name><index>[<expr><name>i</name></expr>]</index></name> != 0</expr>)</condition><then><block>{
            <expr_stmt><expr><name>j</name> = -1</expr>;</expr_stmt>
            <break>break;</break>
        }</block></then></if>
    }</block></for>
    <return>return <expr><name>j</name></expr>;</return>
}</block></function>



<function><type><name>void</name></type> <name>Display</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name></decl>;</decl_stmt>
	
    <decl_stmt><decl><type><name>unsigned</name></type> <name><name>w</name><index>[<expr>601</expr>]</index></name></decl>;</decl_stmt>       
    <expr_stmt><expr><call><name>ToDecimal</name><argument_list>(<argument><expr><name>a</name></expr></argument>, <argument><expr><name>w</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>

    <expr_stmt><expr><name>i</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>w</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"%4.1u "</expr></argument>, <argument><expr><name><name>w</name><index>[<expr><name>i</name></expr>]</index></name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>
    <while>while<condition>(<expr><name>i</name>&gt;=0</expr>)</condition><block>{
        <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"%4.4u "</expr></argument>, <argument><expr><name><name>w</name><index>[<expr><name>i</name></expr>]</index></name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
        <expr_stmt><expr><name>i</name>--</expr>;</expr_stmt>
    }</block></while>
    <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"\n"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
}</block></function>


<function><type><name>void</name></type> <name>DisplayHex</name><parameter_list>(<param><decl><type><name>unsigned</name></type> <name><name>a</name><index>[]</index></name></decl></param>)</parameter_list><block>{
    <decl_stmt><decl><type><name>int</name></type> <name>i</name></decl>;</decl_stmt>
    <expr_stmt><expr><name>i</name> = <call><name>Degree</name><argument_list>(<argument><expr><name>a</name></expr></argument>)</argument_list></call></expr>;</expr_stmt>
    <while>while<condition>(<expr><name>i</name>&gt;=0</expr>)</condition> <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"%4.4x "</expr></argument>, <argument><expr><name><name>a</name><index>[<expr><name>i</name>--</expr>]</index></name></expr></argument>)</argument_list></call></expr>;</expr_stmt></while>
    <expr_stmt><expr><call><name>printf</name><argument_list>(<argument><expr>"\n"</expr></argument>)</argument_list></call></expr>;</expr_stmt>
}</block></function>
</unit>