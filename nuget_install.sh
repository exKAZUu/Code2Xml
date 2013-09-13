#/bin/sh
mono --runtime=v4.0.30319 .nuget/NuGet.exe install NUnit.Runners -Version 2.6.2 -o packages

find . -type f -name packages.config | while read FILE
do
    mono --runtime=v4.0.30319 .nuget/NuGet.exe install ${FILE} -o packages
done
