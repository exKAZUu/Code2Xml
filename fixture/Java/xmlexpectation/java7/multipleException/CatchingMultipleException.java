<compilationUnit>
  <packageDeclaration>
    <PACKAGE startline="1" startpos="0">package</PACKAGE>
    <qualifiedName>
      <IDENTIFIER startline="1" startpos="8">multipleException</IDENTIFIER>
    </qualifiedName>
    <SEMI startline="1" startpos="25">;</SEMI>
  </packageDeclaration>
  <typeDeclaration>
    <classOrInterfaceDeclaration>
      <classDeclaration>
        <normalClassDeclaration>
          <modifiers>
            <PUBLIC startline="3" startpos="0">public</PUBLIC>
          </modifiers>
          <CLASS startline="3" startpos="7">class</CLASS>
          <IDENTIFIER startline="3" startpos="13">CatchingMultipleException</IDENTIFIER>
          <classBody>
            <LBRACE startline="3" startpos="39">{</LBRACE>
            <classBodyDeclaration>
              <memberDecl>
                <methodDeclaration>
                  <modifiers>
                    <PUBLIC startline="5" startpos="3">public</PUBLIC>
                  </modifiers>
                  <VOID startline="5" startpos="10">void</VOID>
                  <IDENTIFIER startline="5" startpos="15">rethrowException</IDENTIFIER>
                  <formalParameters>
                    <LPAREN startline="5" startpos="31">(</LPAREN>
                    <RPAREN startline="5" startpos="32">)</RPAREN>
                  </formalParameters>
                  <THROWS startline="6" startpos="5">throws</THROWS>
                  <qualifiedNameList>
                    <qualifiedName>
                      <IDENTIFIER startline="6" startpos="12">FirstException</IDENTIFIER>
                    </qualifiedName>
                    <COMMA startline="6" startpos="26">,</COMMA>
                    <qualifiedName>
                      <IDENTIFIER startline="6" startpos="28">LastException</IDENTIFIER>
                    </qualifiedName>
                  </qualifiedNameList>
                  <block>
                    <LBRACE startline="6" startpos="42">{</LBRACE>
                    <RBRACE startline="7" startpos="3">}</RBRACE>
                  </block>
                </methodDeclaration>
              </memberDecl>
            </classBodyDeclaration>
            <RBRACE startline="8" startpos="0">}</RBRACE>
          </classBody>
        </normalClassDeclaration>
      </classDeclaration>
    </classOrInterfaceDeclaration>
  </typeDeclaration>
</compilationUnit>