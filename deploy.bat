cd .nuget
nuget Update -self
set nuget=%cd%\nuget
del *.old
cd ..
rd nuspec /s /q
mkdir nuspec
copy *.nuspec nuspec /y
cd nuspec
mkdir lib
copy ..\Code2Xml.Core\bin\Release\*.dll lib\
copy ..\Code2Xml.Core\bin\Release\*.pdb lib\
del lib\TreeDotNet.*
del lib\Paraiba.*
del lib\Antlr*
FOR %%f IN (*.nuspec) DO (
	%nuget% pack %%f
)
FOR %%f IN (*.nupkg) DO (
	%nuget% push %%f -Source https://www.nuget.org/api/v2/package
)
cd ..\
