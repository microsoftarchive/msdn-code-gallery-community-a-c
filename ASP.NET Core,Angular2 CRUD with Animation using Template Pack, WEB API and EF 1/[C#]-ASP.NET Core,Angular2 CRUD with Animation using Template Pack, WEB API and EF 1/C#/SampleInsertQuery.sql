USE MASTER  
GO  
--1) Check  
--for the Database Exists.If the database is exist then drop and create new DB  
IF EXISTS(SELECT [name] FROM sys.databases WHERE [name] = 'StudentsDB')  
DROP DATABASE StudentsDB  
GO  
CREATE DATABASE StudentsDB  
GO  
USE StudentsDB  
GO  
--1) //////////// StudentMasters  
IF EXISTS(SELECT [name] FROM sys.tables WHERE [name] = 'StudentMasters')  
DROP TABLE StudentMasters  
GO  
CREATE TABLE[dbo].[StudentMasters](  
        [StdID] INT IDENTITY PRIMARY KEY, [StdName][varchar](100) NOT NULL, [Email][varchar](100) NOT NULL, [Phone][varchar](20) NOT NULL, [Address][varchar](200) NOT NULL  
    )  
    --insert sample data to Student Master table  
INSERT INTO[StudentMasters]([StdName], [Email], [Phone], [Address])  
VALUES('Shanu', 'syedshanumcain@gmail.com', '01030550007', 'Madurai,India')  
INSERT INTO[StudentMasters]([StdName], [Email], [Phone], [Address])  
VALUES('Afraz', 'Afraz@afrazmail.com', '01030550006', 'Madurai,India')  
INSERT INTO[StudentMasters]([StdName], [Email], [Phone], [Address])  
VALUES('Afreen', 'Afreen@afreenmail.com', '01030550005', 'Madurai,India')  

select * from[StudentMasters]  