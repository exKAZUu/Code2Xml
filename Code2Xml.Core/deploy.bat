mkdir nuspec
copy *.nuspec nuspec /y
cd nuspec
mkdir lib
copy ..\bin\Release\*.dll lib\
copy ..\bin\Release\*.pdb lib\
del lib\Paraiba.*
del *.nupkg
FOR %%f IN (*.nuspec) DO (
	nuget pack %%f
)
FOR %%f IN (*.nupkg) DO (
	nuget push %%f
)
cd ..\
