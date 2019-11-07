-- =============================================                                  
-- Author      : Shanu                                    
-- Create date : 2016-10-20                                 
-- Description : To Create Database                            
                               
-- =============================================    
--Script to create DB,Table and sample Insert data    
USE MASTER;    
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB    
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'HotelDB' )    
BEGIN    
ALTER DATABASE HotelDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE    
DROP DATABASE HotelDB ;    
END    
    
    
CREATE DATABASE HotelDB    
GO    
    
USE HotelDB    
GO    

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'HotelMaster' )    
DROP TABLE HotelMaster    
GO    
    
CREATE TABLE HotelMaster    
(    
  RoomID int identity(1,1),  
   RoomNo VARCHAR(100)  NOT NULL ,  
   RoomType VARCHAR(100)  NOT NULL ,
   Prize	VARCHAR(100)  NOT NULL 
CONSTRAINT [PK_HotelMaster] PRIMARY KEY CLUSTERED          
(         
  RoomID ASC    
   
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]         
) ON [PRIMARY]       

 Insert into HotelMaster(RoomNo,RoomType,Prize) Values('101','Single','50$')
  Insert into HotelMaster(RoomNo,RoomType,Prize) Values('102','Double','80$')

select * from HotelMaster  

  
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'RoomBooking' )    
DROP TABLE RoomBooking    
GO    
    
CREATE TABLE RoomBooking    
(    
    BookingID int identity(1,1), 
    RoomID int ,  
    BookedDateFR VARCHAR(20)  NOT NULL , 
    BookedDateTO VARCHAR(20)  NOT NULL ,
   BookingStatus VARCHAR(100) NOT NULL,  
  PaymentStatus VARCHAR(100) NOT NULL, 
  AdvancePayed VARCHAR(100) NOT NULL,
 TotalAmountPayed VARCHAR(100) NOT NULL,
CONSTRAINT [PK_RoomBooking] PRIMARY KEY CLUSTERED          
(         
  [BookingID] ASC    
   
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]         
) ON [PRIMARY]       
  
select * from RoomBooking  