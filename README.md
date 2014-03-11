Code2Xml [![Build Status](https://secure.travis-ci.org/exKAZUu/Code2Xml.png?branch=master)](http://travis-ci.org/exKAZUu/Code2Xml)
=================

# How to Use

## Sample Code using Processor

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
  // Load a suitable processor by retrieving an extension (e.g. .lua)
	var processor = Processors.GetProcessorByPath(path);
  // To read file, please pass a FileInfo instance
	var xml = processor.GenerateXml(new FileInfo(path));
	var code = processor.GenerateCode(xml);
	Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
}
```

Note that ```Processor``` class is introduced in Code2Xml 2.x instead of ```CodeToXml``` and ```XmlToCode``` classes.  

## Requirements
* NuGet
You can install NuGet Package Manager with Extension Manager.  
* Code Contracts
http://research.microsoft.com/en-us/projects/contracts/
* Python 2.x for parsing Python 2.x
* Python 3.x for parsing Python 3.x
* Ruby 2.x for parsing Ruby 1.8.x, 1.9.x and 2.0.x

## Project Structure
- Code2Xml.Languages.ANTLRv3.dll  
Provides ```Processor``` classes for C, C#, Java, JavaScript, Lua and PHP.

- Code2Xml.Languages.ExternalProcessors.dll  
Provides ```Processor``` classes for Python and Ruby.

- Code2Xml.Languages.Obsolete.dll  
Provides ```CodeToXml``` and ```XmlToCode``` classes, which are obsolete, for C, C#, Java, JavaScript, Lua, Python and Ruby.

- Code2Xml.Languages.ANTLRv4.dll (under experiment)  
Provides ```Processor``` classes for C, Clojure, Erlang, Java, Lua, ObjectiveC, R and Verilog2001.

## Other Information

- [Syntax Tree Structure](Schema.md)
- [Performance](Performance.md)

# How to Develop / Contribute

## How to Build

1. ```git submodule update --init``` at the root directory
1. ```git submodule update --init``` at the ```ParserTests``` directory
1. Open ```Code2Xml.sln```
1. Right click the ```Code2Xml``` solution in Solution Explorer.
1. Select ```Enable NuGet Package Restore```.
1. Build the solution.
