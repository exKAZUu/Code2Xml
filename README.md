Code2Xml [![Build Status](https://secure.travis-ci.org/exKAZUu/Code2Xml.png?branch=master)](http://travis-ci.org/exKAZUu/Code2Xml)
=================

# How to Use

## Requirements
* NuGet
You can install NuGet Package Manager with Extension Manager.  
* Code Contracts
http://research.microsoft.com/en-us/projects/contracts/
* Python 2.x for parsing Python 2.x
* Python 3.x for parsing Python 3.x
* Ruby 2.x for parsing Ruby 1.8.x, 1.9.x and 2.0.x

## Structure
- Code2Xml.Languages.ANTLRv3.dll  
Provides ```Processor``` classes for C, C#, Java, JavaScript, Lua and PHP.

- Code2Xml.Languages.ExternalProcessors.dll  
Provides ```Processor``` classes for Python and Ruby.

- Code2Xml.Languages.Obsolete.dll  
Provides ```CodeToXml``` and ```XmlToCode``` classes, which are obsolete, for C, C#, Java, JavaScript, Lua, Python and Ruby.

- Code2Xml.Languages.ANTLRv4.dll (under experiment)  
Provides ```Processor``` classes for C, Clojure, Erlang, Java, Lua, ObjectiveC, R and Verilog2001.

## Sample code using Processor

- https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/Tests/Samples/ProcessorSample.cs
  - Parse C#, Java and Lua code.
- https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/Tests/Samples/ManipulationSample.cs
  - ProcessIdentifiers: Extract identifiers including a method name
  - ProcessComments: Extract comments
  - InsertStatements: Insert a statement into each method

```C#
[Test] public void ParseJavaText() {
	var originalCode = @"class Klass {}";
	var xml = Processors.JavaUsingAntlr3.GenerateXml(originalCode);
	var code = Processors.JavaUsingAntlr3.GenerateCode(xml);
	Assert.That(code, Is.EqualTo(originalCode));
}

[Test] public void ParseCSharpFile() {
	var path = Fixture.GetInputCodePath("CSharp", "Student.cs"); // Get a path of a test file
	// To read file, please pass a FileInfo instance
	var xml = Processors.CSharpUsingAntlr3.GenerateXml(new FileInfo(path));
	var code = Processors.CSharpUsingAntlr3.GenerateCode(xml);
	Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
}

[Test] public void ParseLuaFileUsingFilePath() {
	var path = Fixture.GetInputCodePath("Lua", "Block1.lua"); // Get a path of a test file
	// To read file, please pass a FileInfo instance
	var processor = Processors.GetProcessorByPath(path);
	var xml = processor.GenerateXml(new FileInfo(path));
	var code = processor.GenerateCode(xml);
	Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
}
```

Note that ```Processor``` class is introduced instead of ```CodeToXml``` and ```XmlToCode``` classes.  
So please use ```Processor``` and ```Processors``` classes.

### [Obsolete!] Sample code using CodeToXml and XmlToCode

- https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/Tests/Samples/CodeToXmlSample.cs

```C#
[Test] public void ParseJavaText() {
	var originalCode = @"class Klass {}";
	var xml = JavaCodeToXml.Instance.Generate(originalCode);
	var code = JavaXmlToCode.Instance.Generate(xml);
	Assert.That(code, Is.EqualTo(originalCode));
}

[Test] public void ParseCSharpFile() {
	var path = Fixture.GetInputCodePath("CSharp", "Student.cs"); // Get a path of a test file
	var xml = CSharpCodeToXml.Instance.GenerateFromFile(path);
	var code = CSharpXmlToCode.Instance.Generate(xml);
	Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
}

[Test] public void ParseLuaFileUsingFilePath() {
	var path = Fixture.GetInputCodePath("Lua", "Block1.lua"); // Get a path of a test file
	var codeToXml = PluginManager.GetCodeToXmlByPath(path);
	var xml = codeToXml.GenerateFromFile(path);
	var code = codeToXml.XmlToCode.Generate(xml);
	Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
}
```

## How it works

For example, ```CSharpProcessorUsingAntlr3``` class generates the two following xml files corresponding to ```class K {}``` and ```class K { void m() {} }```.

    <compilation_unit id="0">
      .. snip ..
              <class_declaration id="50">
      .. snip ..
                <class_body id="621">
                  <TOKENS id="char_literal667">
                    <WS hidden=" " startline="1" startpos="7" endline="1" endpos="8" />
                    <TOKEN startline="1" startpos="8" endline="1" endpos="9">{</TOKEN>
                  </TOKENS>
                  <TOKENS id="char_literal669">
                    <WS hidden=" " startline="1" startpos="9" endline="1" endpos="10" />
                    <TOKEN startline="1" startpos="10" endline="1" endpos="11">}</TOKEN>
                  </TOKENS>
                </class_body>
              </class_declaration>
            </type_declaration>
      .. snip ..
    </compilation_unit>

and

    <compilation_unit id="0">
      .. snip ..
              <class_declaration id="50">
      .. snip ..
                <class_body id="621">
                  <TOKENS id="char_literal667">
                    <WS hidden=" " startline="1" startpos="7" endline="1" endpos="8" />
                    <TOKEN startline="1" startpos="8" endline="1" endpos="9">{</TOKEN>
                  </TOKENS>
                  <class_member_declarations id="668">
                    <class_member_declaration id="670">
                      <method_declaration id="673">
                        <method_header id="707">
      .. snip ..
                        </method_header>
                        <method_body id="708">
      .. snip ..
                        </method_body>
                      </method_declaration>
                    </class_member_declaration>
                  </class_member_declarations>
                  <TOKENS id="char_literal669">
                    <WS hidden=" " startline="1" startpos="21" endline="1" endpos="22" />
                    <TOKEN startline="1" startpos="22" endline="1" endpos="23">}</TOKEN>
                  </TOKENS>
                </class_body>
              </class_declaration>
            </type_declaration>
      .. snip ..
    </compilation_unit>

```class_body``` element in the first xml contains only two tokens of ```{``` and ```}```,
in contrast, one in the second xml contains also ```class_member_declarations``` element corresponding to ```void m() {}```.
This difference is caused by the ANTLR EBNF grammar ([cs.g](https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/ANTLRv3/Processors/CSharp/cs.g "cs.g")) that has the following parsing rule.

    class_body:	'{'   class_member_declarations?   '}' ;

This rule indicates that ```class_body``` elements can have one or no ```class_member_declarations``` element.

# How to Build
1. ```git submodule update --init``` at the root directory
1. ```git submodule update --init``` at the ```ParserTests``` directory
1. Open ```Code2Xml.sln```
1. Right click the ```Code2Xml``` solution in Solution Explorer.
1. Select ```Enable NuGet Package Restore```.
1. Build the solution.

