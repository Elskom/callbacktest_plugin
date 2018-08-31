Set-Location -Path externals
$env:elskomnewpth = Join-Path (Get-Location) Els_kom_new
if(!(Test-Path -Path $env:elskomnewpth))
{
    git clone -q https://github.com/Elskom/Els_kom_new.git --branch add-plugins-installer-form --recursive
    Set-Location -Path Els_kom_new
    msbuild PCbuild/pcbuild.sln /nologo /verbosity:m /m
    Set-Location -Path ..
}
else
{
    Set-Location -Path Els_kom_new
    git pull -q
    msbuild PCbuild/pcbuild.sln /nologo /verbosity:m /m
    Set-Location -Path ..
}
Set-Location -Path ..
