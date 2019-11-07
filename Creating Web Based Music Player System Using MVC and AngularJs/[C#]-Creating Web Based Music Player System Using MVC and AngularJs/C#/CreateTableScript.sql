-- =============================================                                  
-- Author      : Shanu                                    
-- Create date : 2016-02-28                                 
-- Description : To Create Database                            
                               
-- =============================================    
--Script to create DB,Table and sample Insert data    
USE MASTER;    
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB    
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'musicPlayerDB' )    
BEGIN    
ALTER DATABASE musicPlayerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE    
DROP DATABASE musicPlayerDB ;    
END    
    
    
CREATE DATABASE musicPlayerDB    
GO    
    
USE musicPlayerDB    
GO    

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'AlbumMaster' )    
DROP TABLE AlbumMaster    
GO    
    
CREATE TABLE AlbumMaster    
(    
   AlbumID int identity(1,1),  
   AlbumName VARCHAR(200)  NOT NULL ,  
   ImageName VARCHAR(500)  NOT NULL 
CONSTRAINT [PK_AlbumMaster] PRIMARY KEY CLUSTERED          
(         
  [AlbumID] ASC    
   
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]         
) ON [PRIMARY]       

 Insert into AlbumMaster(AlbumName,ImageName) Values('RedAlbum','RedAlbum.jpg')

select * from AlbumMaster  

  
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'MusicPlayerMaster' )    
DROP TABLE MusicPlayerMaster    
GO    
    
CREATE TABLE MusicPlayerMaster    
(    
   MusicID int identity(1,1), 
   SingerName VARCHAR(100)  NOT NULL ,  
   AlbumName VARCHAR(200)  NOT NULL , 
    MusicFileName VARCHAR(500)  NOT NULL, 
   Description VARCHAR(100) NOT NULL,  
 
CONSTRAINT [PK_MusicPlayerMaster] PRIMARY KEY CLUSTERED          
(         
  [MusicID] ASC    
   
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]         
) ON [PRIMARY]       
  
select * from MusicPlayerMaster  