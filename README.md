Code2Xml [![Build Status](https://secure.travis-ci.org/exKAZUu/Code2Xml.png?branch=master)](http://travis-ci.org/exKAZUu/Code2Xml)
=================

# Overview

Code2Xml is a parser collection that inter-converts source code and XML-based concrete syntax trees (CSTs) supporting multiple programming languages.

# How to Use

## Sample Code using CstGenerator

- https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Core.Tests/Samples/CstGeneratorSample.cs
  - Inter-Convert between CST, XML and code for C#, Java and Lua.
- https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Core.Tests/Samples/AnalysisAndTransformationSample.cs
  - CountIfInJava: Count if statements to measure cyclomatic complexity
  - ModifyIfConditionInC: Modify all condition expressions to measure branch coverage
  - ReplaceStatementWithPassInPython: Replace each statement with `pass` statement to conduct mutation testing
  - RemoveStatementInCSharp: Remove each statement to conduct mutation testing
- https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Core.Tests/Samples/CstManipulationSample.cs
  - ProcessIdentifiers: Extract identifiers including a method name
  - ProcessComments: Extract comments
  - InsertStatements: Insert a statement into each method
  - RemoveHiddenTokens: Remove all the hidden tokens (e.g. whitespace)
  - RemoveSingleNodes: Remove child nodes which has no sibling node
- https://github.com/exKAZUu/Code2Xml/blob/master/Code2Xml.Languages/Tests/Samples/CstSerializationSample.cs
  - Serialize CST as a text or a binary

```C#
[Test] public void ParseJavaText() {
    const string originalCode = @"class Klass {}";
    var gen = CstGenerators.JavaUsingAntlr3;

    /*** Code <=> CST ***/
    var cst = gen.GenerateTreeFromCodeText(originalCode);
    Assert.That(cst.Code, Is.EqualTo(originalCode));
    // GenerateCodeFromTree() invokes Code
    Assert.That(gen.GenerateCodeFromTree(cst), Is.EqualTo(originalCode));

    /*** CST <=> XML ***/
    var xml = cst.ToXml();
    Assert.That(CstNode.FromXml(xml).Code, Is.EqualTo(originalCode));
    // GenerateXmlFromTree() invokes ToXml()
    Assert.That(gen.GenerateXmlFromTree(cst).ToString(),
        Is.EqualTo(xml.ToString()));
    // GenerateTreeFromXml() invokes CstNode.FromXml()
    Assert.That(gen.GenerateTreeFromXml(xml).Code,
        Is.EqualTo(originalCode));

    /*** Code <=> XML (via CST) ***/
    // GenerateXmlFromCodeText() invokes GenerateTreeFromCodeText() and ToXml()
    Assert.That(gen.GenerateXmlFromCodeText(originalCode).ToString(),
        Is.EqualTo(xml.ToString()));
    // GenerateCodeFromXml() invokes CstNode.FromXml() and Code
    Assert.That(gen.GenerateCodeFromXml(xml),
        Is.EqualTo(originalCode));
}
```

## Sample Tools
* https://github.com/exKAZUu/SimpleOpenCodeCoverageFramework
* https://github.com/exKAZUu/XMutator

## Requirements
* NuGet
You can install NuGet Package Manager with Extension Manager.  
* Code Contracts
http://research.microsoft.com/en-us/projects/contracts/
* Python 2.x for parsing Python 2.x
* Python 3.x for parsing Python 3.x
* Ruby 2.x for parsing Ruby 1.8.x, 1.9.x and 2.0.x

## Project Structure
- Code2Xml.Core.Generators.ANTLRv3
Provides ```CstGenerator``` classes for C, C#, Java, JavaScript, Lua and PHP.

- Code2Xml.Core.Generators.ANTLRv4
Provides ```CstGenerator``` classes for C, Clojure, ECMAScript, Erlang, GarryLua, Java, Lua, ObjectiveC, Python3, R, Smalltalk, Switft and Verilog2001.

- Code2Xml.Core.Generators.ExternalGenerators
Provides ```CstGenerator``` classes for Python and Ruby.

## Other Information

- [Syntax Tree Structure](Schema.md)
- [Performance](Performance.md)

# How to Develop / Contribute

## How to Build

1. ```git submodule update --init``` at the root directory
1. Open ```Code2Xml.sln```
1. Right click the ```Code2Xml``` solution in Solution Explorer.
1. Select ```Enable NuGet Package Restore```.
1. Build the solution.
