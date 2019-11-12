# Import general helpers using dot operator
. .\Functions_General.ps1

# Uninstall applications
function UninstallBizTalkApplications($msiDirectory)
{
    # Get MSI's to be installed
    $files = GetMsiFiles $msiDirectory

    # Loop through MSI files
    foreach($file in $files)
    {
        UninstallBizTalkApplication $file
    }
}

# Uninstall BizTalk application
function UninstallBizTalkApplication([System.IO.FileInfo]$fileInfo)
{
    # Get application name
    $applicationName = $fileInfo.BaseName.Split("-")[0]

    # Set installer path
    $msiPath = $fileInfo.FullName

    # Uninstall application
    $exitCode = (Start-Process -FilePath "msiexec.exe" -ArgumentList "/x ""$msiPath"" /qn" -Wait -Passthru).ExitCode

    # Check if uninstalling was successful
    if($exitCode -eq 0)
    {
        Write-Host "$applicationName uninstalled successfully" -ForegroundColor Green
    }
    else
    {
        Write-Host "$applicationName not uninstalled successfully" -ForegroundColor Red
    }
}