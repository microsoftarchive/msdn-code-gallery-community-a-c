create procedure [dbo].[backupdb]
as
BACKUP DATABASE [test] TO  DISK = N'C:\copia\test.bak' 
WITH NOFORMAT, NOINIT,  NAME = N'test-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10