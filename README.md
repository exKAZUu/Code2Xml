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
## Structure
	- Code2Xml.Languages.ANTLRv3.dll
	- Code2Xml.Languages.ANTLRv4.dll
	- Code2Xml.Languages.ExternalProcessors.dll
	- Code2Xml.Languages.Obsolete.dll

    var code = @"class Klass { List<String> l = new ArrayList<>(); }";
    var processor = new JavaProcessor();
    var xml = processor.GenerateXml(code, true);
    Console.WriteLine(xml);

# Changes from Code2Xml 1.x to 2.x
	```LanguageProcessor``` class is introduced instead of ```CodeToXml``` and ```XmlToCode``` classes