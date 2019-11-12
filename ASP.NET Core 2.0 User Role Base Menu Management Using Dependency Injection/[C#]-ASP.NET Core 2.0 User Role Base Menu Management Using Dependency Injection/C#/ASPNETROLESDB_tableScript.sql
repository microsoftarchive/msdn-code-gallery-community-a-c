USE MASTER       
GO       
       
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB       
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'AttendanceDB' )       
DROP DATABASE AttendanceDB       
GO       
       
CREATE DATABASE AttendanceDB       
GO       
        

USE AttendanceDB    
GO    
  
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'MenuMaster' )    
DROP TABLE MenuMaster    
GO    
    
CREATE TABLE MenuMaster    
(    
   MenuIdentity int identity(1,1),    
   MenuID VARCHAR(30)  NOT NULL,    
   MenuName VARCHAR(30)  NOT NULL,  
   Parent_MenuID  VARCHAR(30)  NOT NULL,  
   User_Roll [varchar](256) NOT NULL,   
   MenuFileName VARCHAR(100) NOT NULL,     
   MenuURL VARCHAR(500) NOT NULL,    
   USE_YN Char(1) DEFAULT 'Y',    
   CreatedDate datetime    
CONSTRAINT [PK_MenuMaster] PRIMARY KEY CLUSTERED          
(         
  [MenuIdentity] ASC   ,    
  [MenuID] ASC,    
  [MenuName] ASC      
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]         
) ON [PRIMARY]       
   
select * from MenuMaster  
-- Insert Admin User Details
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('AUSER','ADMIN Dashboard','*','ADMIN','INDEX','ADMINC','Y',getDate())  
 Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('AAbout','About Admin','*','ADMIN','INDEX','ADMINAC','Y',getDate())   
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('LStock','Live Stock','AUSER','ADMIN','INDEX','StockC','Y',getDate())     
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('Profile','User Details','AUSER','ADMIN','INDEX','MemberC','Y',getDate())   
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('MUSER','Manager Dashboard','*','ADMIN','INDEX','ManagerC','Y',getDate())  
 Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('MAbout','About Manager','*','ADMIN','INDEX','ManagerAC','Y',getDate())   
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('Accounts','Account Details','MUSER','ADMIN','INDEX','AccountC','Y',getDate())    
	Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('Inventory','Inventory Details','MUSER','ADMIN','INDEX','InventoryC','Y',getDate())  

-- Insert Manager User Details 
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('MUSER','Manager Dashboard','*','Manager','INDEX','ManagerC','Y',getDate())  
 Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('MAbout','About Manager','*','Manager','INDEX','ManagerAC','Y',getDate())   
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('Accounts','Account Details','MUSER','Manager','INDEX','AccountC','Y',getDate())     
Insert into MenuMaster(MenuID ,MenuName,Parent_MenuID,User_Roll,MenuFileName,MenuURL,USE_YN,CreatedDate)
	Values('Inventory','Inventory Details','MUSER','Manager','INDEX','InventoryC','Y',getDate())   


select * from MenuMaster 

select * from AspnetUserRoles