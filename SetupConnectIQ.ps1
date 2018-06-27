## Depends on Java
## choco install jdk8 -y
## choco install javaruntime -y

Add-Type -AssemblyName System.IO.Compression.FileSystem;
Import-Module Microsoft.Powershell.Management;

function New-TemporaryDirectory {
    $parent = [System.IO.Path]::GetTempPath()
    [string] $name = [System.Guid]::NewGuid()
    New-Item -ItemType Directory -Path (Join-Path $parent $name)
}

function Unzip
{
    param([string]$zipfile, [string]$outpath)

    [System.IO.Compression.ZipFile]::ExtractToDirectory($zipfile, $outpath)
}

function AppendToPath
{
    param([string] $pathToAppend)

    if($env:Path.Contains($pathToAppend))
    {
       return; 
    }

    $env:Path += ";$pathToAppend";

    [Environment]::SetEnvironmentVariable( "Path", $env:Path, [System.EnvironmentVariableTarget]::Machine )
}

$downloadPath = New-TemporaryDirectory;
$downloadFilePath = "$downloadPath\connectiq-sdk.zip";
$downloadFilePath;

$sdkUrl = "https://developer.garmin.com/downloads/connect-iq/sdks/connectiq-sdk-win-2.4.7.zip";
Invoke-WebRequest -Uri $sdkUrl -OutFile "$downloadFilePath";

$unzippedFolderPath = "$downloadPath\Unzipped\";
Unzip "$downloadFilePath" $unzippedFolderPath -f;

$finalDestination = "C:\ConnectIQ-SDK";
Copy-Item -Path "$unzippedFolderPath" -Destination "$finalDestination" -Force -Recurse;

AppendToPath "$finalDestination\Unzipped\bin\";