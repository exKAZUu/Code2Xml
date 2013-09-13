#/bin/sh

# Should be use NUnit.Runners 2.6.1 for Mono on Travis-CI
mono --runtime=v4.0.30319 .nuget/NuGet.exe install NUnit.Runners -Version 2.6.1 -o packages

find . -type f -name packages.config | while read FILE
do
    mono --runtime=v4.0.30319 .nuget/NuGet.exe install ${FILE} -o packages
done
