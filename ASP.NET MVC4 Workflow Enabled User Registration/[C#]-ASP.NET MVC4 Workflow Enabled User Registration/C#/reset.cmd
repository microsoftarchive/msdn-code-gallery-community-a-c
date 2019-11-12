call CreateInstanceStore.cmd
sqlcmd.exe -S "(LocalDB)\v11.0" -d aspnet-MvcApplication1-2012416133820 -i "ClearMembership.sql"
rd /s /q c:\mailbox
md c:\mailbox