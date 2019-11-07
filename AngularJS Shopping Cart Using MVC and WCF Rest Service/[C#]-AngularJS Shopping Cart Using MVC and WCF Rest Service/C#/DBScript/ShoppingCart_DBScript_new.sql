-- =============================================                                
-- Author      : Shanu                                
-- Create date : 2015-03-20                                
-- Description : To Create Database,Table and Sample Insert Query                             
-- Latest                                
-- Modifier    : Shanu                                
-- Modify date : 2015-03-20                            
-- =============================================
--Script to create DB,Table and sample Insert data
USE MASTER
GO
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'ShoppingDB' )
DROP DATABASE ShoppingDB
GO

CREATE DATABASE ShoppingDB
GO

USE ShoppingDB
GO

-- 1) //////////// ToysDetails table
-- Create Table  ToysDetails ,This table will be used to store the details like Toys Information 

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ItemDetails' )
DROP TABLE ItemDetails
GO

CREATE TABLE ItemDetails
(
   Item_ID int identity(1,1),
   Item_Name VARCHAR(100)  NOT NULL,
   Item_Price int  NOT NULL,
   Image_Name VARCHAR(100)  NOT NULL,
   Description VARCHAR(100)  NOT NULL,
   AddedBy VARCHAR(100)  NOT NULL,
CONSTRAINT [PK_ItemDetails] PRIMARY KEY CLUSTERED      
(     
  [Item_ID] ASC     
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]     
) ON [PRIMARY]   

GO

-- Insert the sample records to the ToysDetails Table
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('Access Point','Access Point for Wifi use',950,'AccessPoint.png','Shanu')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('CD','Compact Disk',350,'CD.png','Afraz')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('Desktop Computer','Desktop Computer',1400,'DesktopComputer.png','Shanu')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('DVD','Digital Versatile Disc',1390,'DVD.png','Raj')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('DVD Player','DVD Player',450,'DVDPlayer.png','Afraz')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('Floppy','Floppy',1250,'Floppy.png','Mak')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('HDD','Hard Disk',950,'HDD.png','Albert')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('MobilePhone','Mobile Phone',1150,'MobilePhone.png','Gowri')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('Mouse','Mouse',399,'Mouse.png','Afraz')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('MP3 Player ','Multi MediaPlayer',897,'MultimediaPlayer.png','Shanu')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('Notebook','Notebook',750,'Notebook.png','Shanu')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('Printer','Printer',675,'Printer.png','Kim')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('RAM','Random Access Memory ',1950,'RAM.png','Jack')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('Smart Phone','Smart Phone',679,'SmartPhone.png','Lee')
Insert into ItemDetails(Item_Name,Description,Item_Price,Image_Name,AddedBy) values('USB','USB',950,'USB.png','Shanu')



select * from ItemDetails

