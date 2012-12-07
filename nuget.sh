#/bin/sh
mono --runtime=v4.0.30319 .nuget/NuGet.exe install NUnit.Runners -Version 2.6.1 -o packages
mono --runtime=v4.0.30319 .nuget/NuGet.exe install Code2Xml.Languages.Tests/packages.config -o packages
