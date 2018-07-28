Set-Location -Path externals
$env:elskomnewpth = Join-Path (Get-Location) Els_kom_new
if(!(Test-Path -Path $env:elskomnewpth))
{
    git clone -q https://github.com/Elskom/Els_kom_new.git
    Set-Location -Path Els_kom_new/externals
    git clone -q https://github.com/Elskom/ZLIB.NET.git
    Set-Location -Path ../../..
}
else
{
    Set-Location -Path Els_kom_new
    try
    {
        $env:ELS_KOM_REPO_HEAD = Join-Path (Get-Location) .git/HEAD
        $stream = [System.IO.StreamReader]::new($env:ELS_KOM_REPO_HEAD)
        $env:ELS_KOM_CURRENT_COMMIT_ID = $stream.ReadLine()
    }
    finally
    {
        $stream.close()
    }
    git pull -q
    try
    {
        $stream = [System.IO.StreamReader]::new($env:ELS_KOM_REPO_HEAD)
        $env:ELS_KOM_NEW_COMMIT_ID = $stream.ReadLine()
    }
    finally
    {
        $stream.close()
    }
    Set-Location -Path ..
}
if (!($env:ELS_KOM_NEW_COMMIT_ID -eq $env:ELS_KOM_CURRENT_COMMIT_ID))
{
    Set-Location -Path Els_kom_new
    msbuild PCbuild/pcbuild.sln /nologo /verbosity:m /m
    Set-Location -Path ../../
}
