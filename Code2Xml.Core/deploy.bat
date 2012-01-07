mkdir nuspec
copy *.nuspec nuspec /y
cd nuspec
mkdir lib
copy ..\bin\Release\Antlr3.Runtime.* lib\
copy ..\bin\Release\Code2Xml.Core.* lib\
del *.nupkg
FOR %%f IN (*.nuspec) DO (
	nuget pack %%f
)
FOR %%f IN (*.nupkg) DO (
	nuget push %%f
)
