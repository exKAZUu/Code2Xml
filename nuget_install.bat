set MyDir=%~p0

REM Should be use NUnit.Runners 2.6.1 for Mono on Travis-CI
".nuget/NuGet.exe" install NUnit.Runners -Version 2.6.1 -o packages

for /D %%d in (*) do (
    if exist %%d\packages.config (
        "%MyDir%.nuget\NuGet.exe" install "%%d\packages.config" -o "%MyDir%packages"
    )
)
