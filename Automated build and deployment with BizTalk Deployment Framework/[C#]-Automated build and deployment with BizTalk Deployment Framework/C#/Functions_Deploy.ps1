# Import custom functions
. .\Functions_General.ps1

# Load parameters
$settings = Import-Csv Settings_DeploymentEnvironment.csv
foreach($setting in $settings)
{
    # Program Files directory where application should be installed
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "programFilesDirectory") { $programFilesDirectory = $setting.'Name;Value'.Split(";")[1].Trim() }
    
    # Suffix as set in in the ProductName section of the BTDF project file. By default this is " for BizTalk".
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "productNameSuffix") { $productNameSuffix = $setting.'Name;Value'.Split(";")[1].TrimEnd() }
    
    # Indicator if we should deploy to the BizTalkMgmtDB database from this server. In multi-server environments this should be true on 1 server, and false on the others 
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "deployBizTalkMgmtDB") { $deployBizTalkMgmtDB = $setting.'Name;Value'.Split(";")[1].Trim() }
    
    # Name of the BTDF environment settings file for this environment. 
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "environmentSettingsFileName") { $environmentSettingsFileName = $setting.'Name;Value'.Split(";")[1].Trim() }
}

# Deploy applications
function DeployBizTalkApplications([string[]]$applicationsInOrderOfDeployment, [string[]]$versions, [string]$scriptsDirectory)
{
    # Check which restarts should be done
	$resetIIS = CheckIfIISShouldBeReset
	$restartHostInstances = CheckIfHostinstancesShouldBeRestarted

    # Loop through applications to be deployed
    for($index = 0; $index -lt $applicationsInOrderOfDeployment.Length; $index++)
    {
        # Deploy application
        DeployBizTalkApplication $applicationsInOrderOfDeployment[$index] $versions[$index]
    }

    # Get SQL files to be executed
    $sqlFiles = GetSQLFiles $scriptsDirectory

    # Loop through SQL files
    foreach($sqlFile in $sqlFiles)
    {
        # Execute SQL file
        ExecuteSqlFile $sqlFile
    }

    # Get registry files to be imported
    $registryFiles = GetRegistryFiles $scriptsDirectory

    # Loop through registry files
    foreach($registryFile in $registryFiles)
    {
        # Import registry file
        ImportRegistryFile $registryFile
    }

    # Do restarts
    if($resetIIS)
    {
        DoIISReset
    }
    if($restartHostInstances)
    {
        DoHostInstancesRestart 
    }
}

# Deploy a BizTalk application
function DeployBizTalkApplication([string]$application, [string]$version)
{
    # Set log file
    $logFileName = "$programFilesDirectory\$application$productNameSuffix\$version\DeployResults\DeployResults.txt"

    # Execute deployment
    $exitCode = (Start-Process -FilePath "$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" -ArgumentList "/p:DeployBizTalkMgmtDB=$deployBizTalkMgmtDB;Configuration=Server;SkipUndeploy=true /target:Deploy /l:FileLogger,Microsoft.Build.Engine;logfile=""$programFilesDirectory\$application$productNameSuffix\$version\DeployResults\DeployResults.txt"" ""$programFilesDirectory\$application$productNameSuffix\$version\Deployment\Deployment.btdfproj"" /p:ENV_SETTINGS=""$programFilesDirectory\$application$productNameSuffix\$version\Deployment\EnvironmentSettings\$environmentSettingsFileName.xml""" -Wait -Passthru).ExitCode
    
    # Check if deployment was successful
    if($exitCode -eq 0 -and (Select-String -Path $logFileName -Pattern "0 Error(s)" -Quiet) -eq "true")
    {
        Write-Host "$application deployed successfully" -ForegroundColor Green
    }
    else
    {
        Write-Host "$application not deployed successfully" -ForegroundColor Red
    }
}