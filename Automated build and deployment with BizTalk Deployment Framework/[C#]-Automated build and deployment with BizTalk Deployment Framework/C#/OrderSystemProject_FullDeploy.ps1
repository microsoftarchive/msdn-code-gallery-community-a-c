# Project specific settings
$oldInstallersDirectory = "F:\tmp\R9"
$newInstallersDirectory = "F:\tmp\R10"
$newApplications = @("Contoso.OrderSystem.Orders", "Contoso.OrderSystem.Invoices", "Contoso.OrderSystem.Payments")
$oldApplications = @("Contoso.OrderSystem.Payments", "Contoso.OrderSystem.Invoices", "Contoso.OrderSystem.Orders")
$oldVersions = @("1.0.0", "1.0.0", "1.0.0")
$newVersions = @("1.0.0", "1.0.0", "1.0.0")

# Import custom functions
. .\Functions_Deploy.ps1
. .\Functions_Undeploy.ps1
. .\Functions_Install.ps1
. .\Functions_Uninstall.ps1

# Undeploy the applications
UndeployBizTalkApplications $oldApplications $oldVersions

# Wait for user to continue
WaitForKeyPress

# Uninstall the applications
UninstallBizTalkApplications $oldInstallersDirectory

# Wait for user to continue
WaitForKeyPress

# Install the applications
InstallBizTalkApplications $newInstallersDirectory

# Wait for user to continue
WaitForKeyPress

# Deploy the applications
DeployBizTalkApplications $newApplications $newVersions $newInstallersDirectory

# Wait for user to exit
WaitForKeyPress