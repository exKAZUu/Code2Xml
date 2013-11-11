rd nuspec /s /q
mkdir nuspec
copy *.nuspec nuspec /y
cd nuspec
mkdir lib
copy ..\Code2Xml.Tools\Console\bin\Release\*.dll lib\
copy ..\Code2Xml.Tools\Console\bin\Release\*.pdb lib\
del lib\*ANTLRv4*
del lib\Paraiba.*
del lib\Antlr*
FOR %%f IN (*.nuspec) DO (
	nuget pack %%f
)
FOR %%f IN (*.nupkg) DO (
	nuget push %%f
)
cd ..\
