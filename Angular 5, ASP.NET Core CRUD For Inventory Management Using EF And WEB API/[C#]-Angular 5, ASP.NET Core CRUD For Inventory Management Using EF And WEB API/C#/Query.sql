USE MASTER     
GO     
     
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB     
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'InventoryPDB' )     
DROP DATABASE InventoryPDB     
GO     
     
CREATE DATABASE InventoryPDB     
GO     
     
USE InventoryPDB     
GO     
     
     
-- 1) //////////// StudentMasters     
     
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'InventoryMaster' )     
DROP TABLE InventoryMaster     
GO     
     
CREATE TABLE [dbo].[InventoryMaster](     
        [InventoryID] INT IDENTITY PRIMARY KEY,     
        [ItemName] [varchar](100) NOT NULL,        
        [StockQty]  int NOT NULL,        
        [ReorderQty] int NOT NULL,        
        [PriorityStatus] int NOT NULL     -- 0 for low and 1 for High 
)     
     
-- insert sample data to Student Master table     
INSERT INTO [InventoryMaster]   ([ItemName],[StockQty],[ReorderQty],[PriorityStatus])     
     VALUES ('HardDisk',500,300,0)     
     
INSERT INTO [InventoryMaster]   ([ItemName],[StockQty],[ReorderQty],[PriorityStatus])     
     VALUES ('Mouse',600,550,1)  

	 INSERT INTO [InventoryMaster]   ([ItemName],[StockQty],[ReorderQty],[PriorityStatus])     
     VALUES ('USB',3500,3000,0)  
          
          
     select * from InventoryMaster  