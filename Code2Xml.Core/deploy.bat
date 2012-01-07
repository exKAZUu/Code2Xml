del *.nupkg
FOR %%f IN (*.csproj) DO (
	nuget pack %%f -Prop Configuration=Release
)
FOR %%f IN (*.nupkg) DO (
	nuget push %%f
)
