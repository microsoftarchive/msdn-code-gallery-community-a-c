USE HotelDB    
GO       

-- =============================================    
-- To Select all Hotels   
-- EXEC USP_HotelMaster_Select ''  
-- =============================================    
CREATE PROCEDURE [dbo].[USP_HotelMaster_Select]     
(    
     @RoomNo            VARCHAR(100)     = ''      
      )         
AS                                                                  
BEGIN         
        SELECT  RoomID,RoomNo , RoomType,Prize
        FROM HotelMaster  
        WHERE  
                RoomNo like  @RoomNo +'%'  
				 Order By RoomNo
END 

-- To insert
-- EXEC [USP_Hotel_Insert] ''  
-- =============================================                                
CREATE PROCEDURE [dbo].[USP_Hotel_Insert]                                                
   ( 
     @RoomNo            VARCHAR(100)     = '',  
     @RoomType      VARCHAR(100)     = '',
	  @Prize      VARCHAR(100)     = ''
      )                                                          
AS                                                                  
BEGIN         
        IF NOT EXISTS (SELECT * FROM HotelMaster WHERE RoomNo=@RoomNo)  
            BEGIN  
  
                INSERT INTO HotelMaster (RoomNo,RoomType,Prize)
									 VALUES   (@RoomNo,@RoomType,@Prize)
                                 
                    Select 'Inserted' as results  
                          
            END  
         ELSE  
             BEGIN  
                     Select 'Exists' as results  
              END  
  
END  
                                                 
-- =============================================    
-- To Select all RoomBooking  
-- EXEC USP_RoomBooking_SelectALL ''  
-- =============================================    
CREATE PROCEDURE [dbo].[USP_RoomBooking_SelectALL]     
(    
     @RoomID            VARCHAR(100)     = ''      
      )         
AS                                                                  
BEGIN         
        SELECT   A.RoomNo,
				B.BookingID, 
			    B.RoomID ,  
			    B.BookedDateFR, 
			    B.BookedDateTO, 
		        B.BookingStatus ,  
		        B.PaymentStatus,  
		        B.AdvancePayed, 
		        B.TotalAmountPayed 
        FROM HotelMaster A
			Inner join RoomBooking B
			ON A.RoomID=B.RoomID
        WHERE  
                A.RoomID like  @RoomID +'%'  
          
END 
 
-- To insert
-- EXEC USP_RoomBooking_Insert ''  
-- =============================================                                
CREATE PROCEDURE [dbo].[USP_RoomBooking_Insert]                                                
   (                         
     @BookingID  VARCHAR(100)     = '',  
	 @RoomID   VARCHAR(100)     = '',    
	@BookedDateFR  VARCHAR(100)     = '',  
	@BookedDateTO  VARCHAR(100)     = '',  
	@BookingStatus   VARCHAR(100)     = '',    
	@PaymentStatus  VARCHAR(100)     = '',   
	@AdvancePayed VARCHAR(100)     = '',  
	@TotalAmountPayed   VARCHAR(100)     = '' 
      )                                                          
AS                                                                  
BEGIN       
        IF NOT EXISTS (SELECT * FROM RoomBooking WHERE RoomID=@RoomID )
            BEGIN  
  
                INSERT INTO RoomBooking
           (RoomID ,  BookedDateFR,  BookedDateTO, BookingStatus , PaymentStatus, AdvancePayed, TotalAmountPayed )
     VALUES
            ( @RoomID ,  @BookedDateFR,  @BookedDateTO, @BookingStatus , @PaymentStatus, @AdvancePayed, @TotalAmountPayed )
                                 
                    Select 'Inserted' as results  
                          
            END  
         ELSE  
             BEGIN  
					 UPDATE  RoomBooking
					 SET 	BookedDateFR     = @BookedDateFR , 
							BookedDateTO     = @BookedDateTO, 
							BookingStatus    = @BookingStatus,  
							PaymentStatus    = @PaymentStatus,  
							AdvancePayed     = @AdvancePayed, 
							TotalAmountPayed = @TotalAmountPayed
						 WHERE   
						RoomID = @RoomID
				              
               Select 'Updated' as results  
                      
              END   
END  

                                                    
-- =============================================    
-- To Select all user roles   
-- EXEC USP_RoomBooking_Delete ''  
-- =============================================   
Create PROCEDURE [dbo].[USP_RoomBooking_Delete]                                                
   (  
     @BookingID       VARCHAR(20)     = ''
      )                                                          
AS                                                                  
BEGIN         
		 Delete from  RoomBooking  WHERE  BookingID  = @BookingID                 
            Select 'Deleted' as results  
END  


-- =============================================    
-- To Select all Hotels   
-- EXEC USP_HotelStatus_Select ''  
-- =============================================    
Create PROCEDURE [dbo].[USP_HotelStatus_Select]     
(    
     @RoomNo            VARCHAR(100)     = ''      
      )         
AS                                                                  
BEGIN         
       SELECT   A.RoomNo,		  
			   ISNULL(B.BookedDateFR, '' ) as BookedDateFR, 
			   ISNULL(B.BookedDateTO, '' ) as BookedDateTO, 
		       ISNULL(B.BookingStatus, 'Free' ) as BookingStatus,  
		       ISNULL(B.PaymentStatus, '' ) as PaymentStatus,  
		       ISNULL(B.AdvancePayed, '0' ) as AdvancePayed, 
		       ISNULL(B.TotalAmountPayed, '0$' ) as TotalAmountPayed
        FROM HotelMaster A
		Left Outer join RoomBooking B
		ON A.RoomNo=B.RoomID
		Order By  A.RoomNo
END 
 