# Load parameters
$settings = Import-Csv Settings_DeploymentEnvironment.csv
foreach($setting in $settings)
{
    # Directory where BizTalk installation resides
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "bizTalkServerInstallationDirectory") { $bizTalkServerInstallationDirectory = $setting.'Name;Value'.Split(";")[1].Trim() }
    
    # Database server for the environment
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "databaseServer") { $databaseServer = $setting.'Name;Value'.Split(";")[1].Trim() }
}

# Wait for user to press key to continue
function WaitForKeyPress()
{
    Read-Host "Press ENTER key to continue..."
}

# Clear log files for a specific application
function ClearLogFiles([string]$application)
{
    del "$application*.log"
}

# Check if IIS should be reset during the deployment
function CheckIfIISShouldBeReset()
{
    # Check if user wants to reset IIS
    if((GetYesNoAnswer "Do you want to do an iisreset after the deployment?") -eq "y")
    {
        return $true
    }
	else
	{
		return $false
	}
}

# Check if hostinstances should be restarted during the deployment
function CheckIfHostinstancesShouldBeRestarted()
{
    # Check if user wants to 
    if((GetYesNoAnswer "Do you want to restart the host instances after the deployment?") -eq "y")
    {
        return $true
    }
	else
	{
		return $false
	}
}

# Ask the user a question, and wait for a y or n answer
function GetYesNoAnswer([string]$question)
{
    while("y", "n" -notcontains $answer)
    {
	    $answer = Read-Host "$question (y/n)"
    }

    return $answer
}

# Do IIS reset
function DoIISReset()
{
    Write-Host "Doing IIS reset" -ForegroundColor Cyan
    while(!$result)
    {
        iisreset
        $result = $?
    }
}

# Do hostinstances restart
function DoHostInstancesRestart()
{
    Write-Host "Bouncing BizTalk host instances" -ForegroundColor Cyan
    cscript.exe "$bizTalkServerInstallationDirectory\SDK\Samples\ApplicationDeployment\VisualStudioHostRestart\RestartBizTalkHostInstances.vbs"
}

# Run a SQL command file
function ExecuteSqlFile([string]$sqlFilePath)
{
    Start-Process -FilePath "sqlcmd" -ArgumentList "-S $databaseServer -i ""$sqlFilePath""" -Wait -Passthru | Out-Null
}

# Import registry file
function ImportRegistryFile([string]$registryFilePath)
{
    regedit /s "$registryFilePath"
}

# Get registry files in a directory
function GetRegistryFiles([string]$directory)
{
    # Get registry files
    return Get-ChildItem "$directory" -Filter *.reg
}

# Get SQL files in a directory
function GetSQLFiles([string]$directory)
{
    # Get SQL files
    return Get-ChildItem "$directory" -Filter *.sql
}

# Get MSI files in a directory
function GetMsiFiles([string]$directory)
{
    # Get MSI files
    return Get-ChildItem "$directory" -Filter *.msi
}