# Import general helpers using dot operator
. .\Functions_General.ps1

# Load parameters
$settings = Import-Csv Settings_BuildEnvironment.csv
foreach($setting in $settings)
{
    # The directory where the BizTalk projects are stored
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "projectsBaseDirectory") { $projectsBaseDirectory = $setting.'Name;Value'.Split(";")[1].Trim() }
    
    # The directory where the MSI's should be saved to
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "installersOutputDirectory") { $installersOutputDirectory = $setting.'Name;Value'.Split(";")[1].Trim() }
    
    # Directory where Visual Studio resides
    if($setting.'Name;Value'.Split(";")[0].Trim() -eq "visualStudioDirectory") { $visualStudioDirectory = $setting.'Name;Value'.Split(";")[1].Trim() }
}

# Build and create installers for multiple BizTalk applications
function BuildAndCreateBizTalkInstallers([string[]]$applications, [string]$project)
{
    # Loop trough applications
    foreach($application in $applications)
    {
        BuildAndCreateBizTalkInstaller $application $project
    }
}

# Build a BizTalk application and create an MSI installer
function BuildAndCreateBizTalkInstaller([string]$application, [string]$project)
{
    BuildBizTalkApplication $application $project
    BuildBizTalkMsi $application $project
}

# Build a BizTalk application
function BuildBizTalkApplication([string]$application, [string]$project)
{
    # Set directory where the BizTalk projects for the current project are stored
    $projectsDirectory = "$projectsBaseDirectory\$project"
    
    # Clear log files and old installers
    ClearLogFiles $application
    
    # Build application
    Write-Host "Building $application" -ForegroundColor Cyan
    $exitCode = (Start-Process -FilePath "$visualStudioDirectory\Common7\IDE\devenv.exe" -ArgumentList """$projectsDirectory\$application\$application.sln"" /Build Release /Out $application.log" -PassThru -Wait).ExitCode

    # Check result
    if($exitCode -eq 0 -and (Select-String -Path "$application.log" -Pattern "0 failed" -Quiet) -eq "true")
    {
        Write-Host "$application built succesfully" -ForegroundColor Green
    }
    else
    {
        Write-Host "$application not built succesfully" -ForegroundColor Red
        WaitForKeyPress
    }
}

# Build MSI for a BizTalk application
function BuildBizTalkMsi([string]$application, [string]$project)
{
    # Set directory where the BizTalk projects for the current project are stored
    $projectsDirectory = "$projectsBaseDirectory\$project"
    
    # Build installer
    $exitCode = (Start-Process -FilePath """$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe""" -ArgumentList "/t:Installer /p:Configuration=Release ""$projectsDirectory\$application\Deployment\Deployment.btdfproj"" /l:FileLogger,Microsoft.Build.Engine;logfile=$application.msi.log" -PassThru -Wait).ExitCode

    # Check result
    if($exitCode -eq 0)
    {
        Write-Host "MSI for $application built succesfully" -ForegroundColor Green
    }
    else
    {
        Write-Host "MSI for $application not built succesfully" -ForegroundColor Red
        WaitForKeyPress
    }

    # Copy installer
    copy "$projectsDirectory\$application\Deployment\bin\Release\*.msi" "$installersOutputDirectory"
}