-- =============================================                                
-- Author      : Shanu                                  
-- Create date : 2016-01-17                               
-- Description : To Create Database                          
                             
-- =============================================  
--Script to create DB,Table and sample Insert data  
USE MASTER;  
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB  
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'AttendanceDB' )  
BEGIN  
ALTER DATABASE AttendanceDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE  
DROP DATABASE AttendanceDB ;  
END  
  
  
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



-- 1) Stored procedure To Select all user roles 

-- Author      : Shanu                                                                
-- Create date : 2016-01-30                                                               
-- Description :select all AspNetRoles   all roll name                                             
-- Tables used :  AspNetRoles                                                            
-- Modifier    : Shanu                                                                
-- Modify date : 2016-01-30                                                                
-- =============================================  
-- To Select all user roles 
-- EXEC USP_UserRoles_Select ''
-- =============================================  
CREATE PROCEDURE [dbo].[USP_UserRoles_Select]   
(  
     @Rolename			   VARCHAR(30)     = ''	
      )       
AS                                                                
BEGIN    	
		 Select ID,Name
			FROM 
				AspNetRoles 
			WHERE
				Name like  @Rolename +'%'
END
			
-- 2) Stored procedure To Select all  Menu 

-- Author      : Shanu                                                                
-- Create date : 2016-01-30                                                               
-- Description :select all MenuMaster  detail                                          
-- Tables used :  MenuMaster                                                            
-- Modifier    : Shanu                                                                
-- Modify date : 2016-01-30                                                                
-- =============================================  
-- To Select all user roles 
-- EXEC USP_Menu_Select '',''
-- =============================================  
CREATE PROCEDURE [dbo].[USP_Menu_Select]                                              
   (                            
     @MenuID		   VARCHAR(30)     = '',
     @MenuName		   VARCHAR(30)     = ''	
      )                                                        
AS                                                                
BEGIN    

		 Select MenuIdentity ,  
			   MenuID ,  
			   MenuName ,
			   Parent_MenuID  ,
			   User_Roll, 
			   MenuFileName ,   
			   MenuURL ,  
			   USE_YN ,  
			   CreatedDate 
			FROM 
				MenuMaster 
			WHERE
				MenuID like  @MenuID +'%'
				AND MenuName like @MenuName +'%'
			--	AND USE_YN ='Y'
			ORDER BY
				MenuName,MenuID	
	
END

-- 3) Stored procedure To Select Menu by Logged in User Roll

-- Author      : Shanu                                                                
-- Create date : 2016-01-30                                                               
-- Description :select all AspNetRoles   all roll name                                             
-- Tables used :  AspNetRoles                                                            
-- Modifier    : Shanu                                                                
-- Modify date : 2016-01-30                                                                
-- =============================================  
-- To Select all user roles 
-- EXEC USP_MenubyUserRole_Select 'Admin'
-- =============================================  
CREATE PROCEDURE [dbo].[USP_MenubyUserRole_Select]   
(  
     @Rolename			   VARCHAR(30)     = ''	
      )       
AS                                                                
BEGIN    
      Select MenuIdentity ,  
			   MenuID ,  
			   MenuName ,
			   Parent_MenuID  ,
			   User_Roll, 
			   MenuFileName ,   
			   MenuURL ,  
			   USE_YN ,  
			   CreatedDate 
			FROM 
				MenuMaster 
			WHERE			
				 User_Roll = @Rolename
			    AND USE_YN ='Y'
			ORDER BY
				MenuName,MenuID		
		
END


-- 4) Stored procedure To Insert  Menu 

-- Author      : Shanu                                                                
-- Create date : 2016-01-30                                                               
-- Description :To Insert MenuMaster detail                                          
-- Tables used :  MenuMaster                                                            
-- Modifier    : Shanu                                                                
-- Modify date : 2016-01-30                                                                
-- =============================================  
-- To Select all user roles 
-- =============================================                              
CREATE PROCEDURE [dbo].[USP_Menu_Insert]                                              
   (                       
     @MenuID		    VARCHAR(30)     = '',
     @MenuName			VARCHAR(30)     = '',
     @Parent_MenuID		VARCHAR(30)     = '',
     @User_Roll		    VARCHAR(200)     = '',
	 @MenuFileName		VARCHAR(100)     = '',
	 @MenuURL		    VARCHAR(500)     = '',
	 @USE_YN			VARCHAR(1)     = ''
      )                                                        
AS                                                                
BEGIN    	
		IF NOT EXISTS (SELECT * FROM MenuMaster WHERE MenuID=@MenuID and MenuName=@MenuName)
			BEGIN

					INSERT INTO MenuMaster
					(  MenuID ,     MenuName ,	   Parent_MenuID  ,	   User_Roll, 	   MenuFileName ,   
					 MenuURL ,       USE_YN ,  	   CreatedDate )
					 VALUES (  @MenuID ,     @MenuName ,	   @Parent_MenuID  ,	   @User_Roll, 	   @MenuFileName ,   
					 @MenuURL ,       @USE_YN ,  	   GETDATE())
							   
					Select 'Inserted' as results
					    
			END
		 ELSE
			 BEGIN
					 Select 'Exists' as results
			  END

END

-- 5) Stored procedure To Update  Menu 

-- Author      : Shanu                                                                
-- Create date : 2016-01-30                                                               
-- Description :To Update MenuMaster detail                                          
-- Tables used :  MenuMaster                                                            
-- Modifier    : Shanu                                                                
-- Modify date : 2016-01-30                                                                
-- =============================================  
-- To Select all user roles 
-- =============================================                                
CREATE PROCEDURE [dbo].[USP_Menu_Update]                                              
   ( @MenuIdentity			   Int=0,                           
     @MenuID		    VARCHAR(30)     = '',
     @MenuName			VARCHAR(30)     = '',
     @Parent_MenuID		VARCHAR(30)     = '',
     @User_Roll		    VARCHAR(200)     = '',
	 @MenuFileName		VARCHAR(100)     = '',
	 @MenuURL		    VARCHAR(500)     = '',
	 @USE_YN			VARCHAR(1)     = ''
      )                                                        
AS                                                                
BEGIN    	
		IF  EXISTS (SELECT * FROM MenuMaster WHERE MenuIdentity=@MenuIdentity )
			BEGIN
					UPDATE MenuMaster SET
							MenuID=@MenuID,
							MenuName=MenuName,
							Parent_MenuID=@Parent_MenuID,
							User_Roll=@User_Roll,
							MenuFileName=@MenuFileName,
							MenuURL=@MenuURL,
							USE_YN=@USE_YN
					WHERE
					MenuIdentity=@MenuIdentity
							   
					Select 'updated' as results					    
			END
		 ELSE
			 BEGIN
					 Select 'Not Exists' as results
			  END
END


-- 6) Stored procedure To Delete  Menu 

-- Author      : Shanu                                                                
-- Create date : 2016-01-30                                                               
-- Description :To Delete MenuMaster detail                                          
-- Tables used :  MenuMaster                                                            
-- Modifier    : Shanu                                                                
-- Modify date : 2016-01-30                                                                
-- =============================================  
-- To Select all user roles 
-- =============================================                                                          
Create PROCEDURE [dbo].[USP_Menu_Delete]                                              
   ( @MenuIdentity	 Int=0 )                                                        
AS                                                                
BEGIN    	
		DELETE FROM MenuMaster WHERE MenuIdentity=@MenuIdentity			    
			
END