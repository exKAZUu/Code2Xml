[![Build Status](https://secure.travis-ci.org/exKAZUu/Code2Xml.png?branch=master)](http://travis-ci.org/exKAZUu/Code2Xml)

# Requirements
* NuGet
Install NuGet with Extension Manager
* Code Contracts
http://research.microsoft.com/en-us/projects/contracts/

# How to build
1. Right click the solution icon in the Solution Explorer.
2. Click 'Enable NuGet Package Restore'.
3. Build the solution.

# How to use
    var code = @"class Klass { List<String> l = new ArrayList<>(); }";
    var processor = new JavaProcessor();
    var xml = processor.GenerateXml(code, true);
    Console.WriteLine(xml);
