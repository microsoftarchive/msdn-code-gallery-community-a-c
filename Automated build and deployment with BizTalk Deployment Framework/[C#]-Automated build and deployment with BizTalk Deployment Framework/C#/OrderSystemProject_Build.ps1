# Project specific settings
$projectName = "OrderSystem"
$applications = @("Contoso.OrderSystem.Orders", "Contoso.OrderSystem.Invoices", "Contoso.OrderSystem.Payments")

# Import custom functions
. .\Functions_Build.ps1

# Build the applications
BuildAndCreateBizTalkInstallers $applications $projectName

# Wait for user to exit
WaitForKeyPress