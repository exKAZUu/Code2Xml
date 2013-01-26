set MyDir=%~p0
".nuget/NuGet.exe" install NUnit.Runners -Version 2.6.1 -o packages

for /D %%d in (*) do (
    if exist %%d\packages.config (
        "%MyDir%.nuget\NuGet.exe" install "%%d\packages.config" -o "%MyDir%packages"
    )
)
