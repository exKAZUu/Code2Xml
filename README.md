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
	```Processor``` class is introduced instead of ```CodeToXml``` and ```XmlToCode``` classes

## Sample code using ```Processor```
	[Test] public void ParseJavaText() {
		var originalCode = @"class Klass {}";
		var xml = Processors.JavaUsingAntlr3.GenerateXml(originalCode);
		var code = Processors.JavaUsingAntlr3.GenerateCode(xml);
		Assert.That(code, Is.EqualTo(originalCode));
	}

	[Test] public void ParseCSharpFile() {
		var path = Fixture.GetInputCodePath("CSharp", "Student.cs");
		// To read file, please pass a FileInfo instance
		var xml = Processors.CSharpUsingAntlr3.GenerateXml(new FileInfo(path));
		var code = Processors.CSharpUsingAntlr3.GenerateCode(xml);
		Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
	}

	[Test] public void ParseLuaFileUsingFilePath() {
		var path = Fixture.GetInputCodePath("Lua", "Block1.lua");
		// To read file, please pass a FileInfo instance
		var processor = Processors.GetProcessorByPath(path);
		var xml = processor.GenerateXml(new FileInfo(path));
		var code = processor.GenerateCode(xml);
		Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
	}

## [Obsolete!] Sample code using ```CodeToXml``` and ```XmlToCode``` classes
	[Test] public void ParseJavaText() {
		var originalCode = @"class Klass {}";
		var xml = JavaCodeToXml.Instance.Generate(originalCode);
		var code = JavaXmlToCode.Instance.Generate(xml);
		Assert.That(code, Is.EqualTo(originalCode));
	}

	[Test] public void ParseCSharpFile() {
		var path = Fixture.GetInputCodePath("CSharp", "Student.cs");
		var xml = CSharpCodeToXml.Instance.GenerateFromFile(path);
		var code = CSharpXmlToCode.Instance.Generate(xml);
		Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
	}

	[Test] public void ParseLuaFileUsingFilePath() {
		var path = Fixture.GetInputCodePath("Lua", "Block1.lua");
		var codeToXml = PluginManager.GetCodeToXmlByPath(path);
		var xml = codeToXml.GenerateFromFile(path);
		var code = codeToXml.XmlToCode.Generate(xml);
		Assert.That(code, Is.EqualTo(File.ReadAllText(path)));
	}
