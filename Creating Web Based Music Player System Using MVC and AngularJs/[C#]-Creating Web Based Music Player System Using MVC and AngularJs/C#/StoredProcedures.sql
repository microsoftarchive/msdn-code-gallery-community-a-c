USE musicPlayerDB    
GO    

-- =============================================    
-- To Select all user roles   
-- EXEC USP_AlbumMaster_Select ''  
-- =============================================    
CREATE PROCEDURE [dbo].[USP_AlbumMaster_Select]     
(    
     @AlbumName            VARCHAR(100)     = ''      
      )         
AS                                                                  
BEGIN         
        SELECT  AlbumID,AlbumName , ImageName
        FROM AlbumMaster  
        WHERE  
                AlbumName like  @AlbumName +'%'  
				 Order By AlbumName
END 

-- To insert
-- EXEC [USP_Album_Insert] ''  
-- =============================================                                
CREATE PROCEDURE [dbo].[USP_Album_Insert]                                                
   ( 
     @AlbumName            VARCHAR(200)     = '',  
     @ImageName      VARCHAR(500)     = ''
      )                                                          
AS                                                                  
BEGIN         
        IF NOT EXISTS (SELECT * FROM AlbumMaster WHERE AlbumName=@AlbumName)  
            BEGIN  
  
                INSERT INTO [dbo].AlbumMaster (AlbumName ,ImageName  )
									 VALUES   (@AlbumName ,@ImageName )
                                 
                    Select 'Inserted' as results  
                          
            END  
         ELSE  
             BEGIN  
                     Select 'Exists' as results  
              END  
  
END  


-- 1) select all MusicPlayerMaster records       
  
-- Author      : Shanu                                                                  
-- Create date :  2016-08-23                                                                  
-- Description :select top 10 random kidsLearnerMaster records                                              
-- Tables used :  MusicPlayerMaster                                                              
-- Modifier    : Shanu                                                                  
-- Modify date : 2016-08-23                                                                 
-- =============================================    
-- To Select all user roles   
-- EXEC USP_MusicAlbum_SelectALL ''  
-- =============================================    
CREATE PROCEDURE [dbo].[USP_MusicAlbum_SelectALL]     
(    
     @AlbumName            VARCHAR(100)     = ''      
      )         
AS                                                                  
BEGIN         
        SELECT  MusicID, 
			   SingerName ,  
			   AlbumName , 
			   MusicFileName, 
			   Description   
        FROM MusicPlayerMaster  
        WHERE  
                AlbumName like  @AlbumName +'%'  
          
END 




-- 2) select all MusicPlayerMaster records       
  
-- Author      : Shanu                                                                  
-- Create date :  2016-08-23                                                                  
-- Description :Insert                                  
-- Tables used :  MusicPlayerMaster                                                              
-- Modifier    : Shanu                                                                  
-- Modify date : 2016-08-23                                                                 
-- =============================================    
-- To insert
-- EXEC USP_MusicAlbum_Insert ''  
-- =============================================                                
CREATE PROCEDURE [dbo].[USP_MusicAlbum_Insert]                                                
   (                         
     @SingerName         VARCHAR(100)     = '',  
     @AlbumName            VARCHAR(200)     = '', 
     @MusicFileName      VARCHAR(500)     = '',  
	 @Description      VARCHAR(100)     = ''
      )                                                          
AS                                                                  
BEGIN         
        IF NOT EXISTS (SELECT * FROM MusicPlayerMaster WHERE MusicFileName=@MusicFileName)  
            BEGIN  
  
                INSERT INTO [dbo].[MusicPlayerMaster]
           (SingerName ,AlbumName ,MusicFileName  ,Description)
     VALUES
            (@SingerName ,@AlbumName ,@MusicFileName  ,@Description)
                                 
                    Select 'Inserted' as results  
                          
            END  
         ELSE  
             BEGIN  
                     Select 'Exists' as results  
              END  
  
END  



-- 3) Update all MusicPlayerMaster records       
  
-- Author      : Shanu                                                                  
-- Create date :  2016-08-23                                                                  
-- Description :Update                                  
-- Tables used :  MusicPlayerMaster                                                              
-- Modifier    : Shanu                                                                  
-- Modify date : 2016-08-23                                                                 
-- =============================================    
-- To Select all user roles   
-- EXEC USP_MusicAlbum_Update ''  
-- =============================================   
Create PROCEDURE [dbo].[USP_MusicAlbum_Update]                                                
   (  
     @musicID       VARCHAR(20)     = '',    
     @SingerName         VARCHAR(100)     = '',  
     @AlbumName            VARCHAR(200)     = '', 
     @MusicFileName      VARCHAR(500)     = '',  
	 @Description      VARCHAR(100)     = ''
      )                                                          
AS                                                                  
BEGIN         
     UPDATE  [dbo].[MusicPlayerMaster]
					 SET [SingerName] = @SingerName,
					   [AlbumName] = @AlbumName,
					   [MusicFileName] = @MusicFileName,
					   [Description] = @Description 
                 WHERE   
				 musicID  = @musicID                 
            Select 'Updated' as results  
END  

-- 4) Update all MusicPlayerMaster records       
  
-- Author      : Shanu                                                                  
-- Create date :  2016-08-23                                                                  
-- Description :Delete                                  
-- Tables used :  MusicPlayerMaster                                                              
-- Modifier    : Shanu                                                                  
-- Modify date : 2016-08-23                                                                 
-- =============================================    
-- To Select all user roles   
-- EXEC USP_MusicAlbum_Delete ''  
-- =============================================   
Create PROCEDURE [dbo].[USP_MusicAlbum_Delete]                                                
   (  
     @musicID       VARCHAR(20)     = ''
      )                                                          
AS                                                                  
BEGIN         
     Delete from  [MusicPlayerMaster]   WHERE  musicID  = @musicID                 
            Select 'Deleted' as results  
END  