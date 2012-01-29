mkdir nuspec
copy *.nuspec nuspec /y
cd nuspec
mkdir lib
copy ..\Code2Xml.Core\bin\Release\*.dll lib\
copy ..\Code2Xml.Core\bin\Release\*.pdb lib\
del lib\Paraiba.*
del *.nupkg
FOR %%f IN (*.nuspec) DO (
	nuget pack %%f
)
FOR %%f IN (*.nupkg) DO (
	nuget push %%f
)
cd ..\
rd nuspec /s /q
