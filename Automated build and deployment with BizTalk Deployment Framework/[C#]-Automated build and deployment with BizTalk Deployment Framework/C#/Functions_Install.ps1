# Import general helpers using dot operator
. .\Functions_General.ps1

# Load parameters
$settings = Import-Csv Settings_DeploymentEnvironment.csv
foreach($setting in $settings)
{
    # Program Files directory where application should be installed
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "programFilesDirectory") { $programFilesDirectory = $setting.'Name;Value'.Split(";")[1].Trim() }
    
    # Suffix as set in in the ProductName section of the BTDF project file. By default this is " for BizTalk".
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "productNameSuffix") { $productNameSuffix = $setting.'Name;Value'.Split(";")[1].TrimEnd() }
}

# Install applications
function InstallBizTalkApplications([string]$msiDirectory)
{
    # Clear log files
    ClearLogFiles $msiDirectory

    # Get MSI's to be installed
    $files = GetMsiFiles $msiDirectory

    # Loop through MSI files
    foreach($file in $files)
    {
        # Install application
        InstallBizTalkApplication $file
    }
}

# Install BizTalk application
function InstallBizTalkApplication([System.IO.FileInfo]$fileInfo)
{
    # Get application name and version
    # We assume msi file name is in the format ApplicationName-Version
    $application = $fileInfo.BaseName.Split("-")[0]
    $version = $fileInfo.BaseName.Split("-")[1]

    # Directory where MSI resides
    $msiDirectory = $fileInfo.Directory

    # Set log name
    $logFileName = "$msiDirectory\$application.log"

    # Set installer path
    $msiPath = $fileInfo.FullName

    # Install application
    Start-Process -FilePath "msiexec.exe" -ArgumentList "/i ""$msiPath"" /passive /log ""$logFileName"" INSTALLDIR=""$programFilesDirectory\$application$productNameSuffix\$version""" -Wait -Passthru | Out-Null
    
    # Check if installation was successful
    if((Select-String -Path $logFileName -Pattern "success or error status: 0" -Quiet) -eq "true")
    {
        Write-Host "$application installed successfully" -ForegroundColor Green
    }
    else
    {
        Write-Host "$application not installed successfully" -ForegroundColor Red
    }
}