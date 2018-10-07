Set-Location -Path externals
$env:elskomnewpth = Join-Path (Get-Location) Els_kom_new
if(!(Test-Path -Path $env:elskomnewpth))
{
    git clone -q https://github.com/Elskom/Els_kom_new.git --recursive
    Set-Location -Path Els_kom_new/PCbuild
    nuget restore
    msbuild pcbuild.sln /nologo /verbosity:m /m
    Set-Location -Path ../..
}
else
{
    Set-Location -Path Els_kom_new/PCbuild
    git pull -q
    nuget restore
    msbuild pcbuild.sln /nologo /verbosity:m /m
    Set-Location -Path ../..
}
Set-Location -Path ..
