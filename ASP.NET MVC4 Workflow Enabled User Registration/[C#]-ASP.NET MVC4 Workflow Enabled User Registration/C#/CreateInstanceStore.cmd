@echo off

:createStore
SET INSTANCESTORE=RegistrationInstanceStore
SET SQLSERVER=(LocalDb)\v11.0
if not .%1 == . SET INSTANCESTORE=%1
Echo Dropping instance store %INSTANCESTORE%
sqlcmd.exe -S %SQLSERVER% -Q "drop database %INSTANCESTORE%"
sqlcmd.exe -S %SQLSERVER% -Q "create database %INSTANCESTORE%"
Echo Creating instance store %INSTANCESTORE%
sqlcmd.exe -S %SQLSERVER% -d %INSTANCESTORE% -i "%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\SQL\en\SqlWorkflowInstanceStoreSchema.sql"
sqlcmd.exe -S %SQLSERVER% -d %INSTANCESTORE% -i "%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\SQL\en\SqlWorkflowInstanceStoreLogic.sql"
echo Workflow Persistence store %INSTANCESTORE% successfully created on server %SQLSERVER%
:end

