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
}

# Undeploy applications
function UndeployBizTalkApplications([string[]]$applicationsInOrderOfUndeployment, [string[]]$versions)
{
    # Loop through applications to be undeployed
    for($index = 0; $index -lt $applicationsInOrderOfUndeployment.Length; $index++)
    {
        # Deploy application
        UndeployBizTalkApplication $applicationsInOrderOfUndeployment[$index] $versions[$index]
    }

    # Return number of errors
    return $errorCount
}

# Undeploy a BizTalk application
function UndeployBizTalkApplication([string]$application, [string]$version)
{
    # Execute undeployment
    $exitCode = (Start-Process -FilePath "$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" -ArgumentList """$programFilesDirectory\$application$productNameSuffix\$version\Deployment\Deployment.btdfproj"" /t:Undeploy /p:DeployBizTalkMgmtDB=$deployBizTalkMgmtDB /p:Configuration=Server" -Wait -Passthru).ExitCode
    
    if($exitCode -eq 0)
    {
        Write-Host "$application undeployed successfully" -ForegroundColor Green
    }
    else
    {
        Write-Host "$application not undeployed successfully" -ForegroundColor Red
    }
}