$env:SOLUTION_NAME = "Jaguar.NetCore.DAL"

function DownloadWithRetry([string] $url, [string] $downloadLocation, [int] $retries) 
{
    while($true)
    {
        try
        {
            Invoke-WebRequest $url -OutFile $downloadLocation
            break
        }
        catch
        {
            $exceptionMessage = $_.Exception.Message
            Write-Host "Error al descargar '$url': $exceptionMessage"
            if ($retries -gt 0) {
                $retries--
                Write-Host "Esperando 10 segundos antes de volver a intentar. Intentos restantes: $retries"
                Start-Sleep -Seconds 10

            }
            else 
            {
                $exception = $_.Exception
                throw $exception
            }
        }
    }
}

cd $PSScriptRoot

$repoFolder = $PSScriptRoot

$buildZip="https://github.com/huchim/Jaguar.Build/archive/master.zip"

# Iniciar con punto, para evitar que se copie.
$buildFolder = ".build"
$buildFile="$buildFolder\build.ps1"

if (!(Test-Path $buildFolder)) {
    Write-Host "Descargando compilador $buildZip"    
    
    $tempFolder=$env:TEMP + "\Build-" + [guid]::NewGuid()
    New-Item -Path "$tempFolder" -Type directory | Out-Null

    $localZipFile="$tempFolder\build.zip"
    
    DownloadWithRetry -url $buildZip -downloadLocation $localZipFile -retries 6
	Write-Host "Descomprimiendo descarga."    
	
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    [System.IO.Compression.ZipFile]::ExtractToDirectory($localZipFile, $tempFolder)
    
    New-Item -Path "$buildFolder" -Type directory | Out-Null
    copy-item "$tempFolder\**\*" $buildFolder -Recurse

    # Cleanup
    if (Test-Path $tempFolder) {
		Write-Host "Eliminando archivos temporales."
        Remove-Item -Recurse -Force $tempFolder
    }
}

 &"$buildFile" $args