use master  
--create DataBase  
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB  
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'OrderManagement' )  
DROP DATABASE OrderManagement  
GO  
  
CREATE DATABASE OrderManagement  
GO  
  
USE OrderManagement  
GO  
  
  
  
-- Create OrderMasters Table  
  
CREATE TABLE [dbo].[OrderMasters](   
[Order_No] INT IDENTITY PRIMARY KEY,   
[Table_ID] [varchar](20) NOT NULL,   
[Description] [varchar](200) NOT NULL,   
[Order_DATE] [datetime] NOT NULL,   
[Waiter_Name] [varchar](20) NOT NULL  
)  
  
  
-- Insert OrderMasters sample data  
  
INSERT INTO [OrderMasters]   
          ([Table_ID] ,[Description],[Order_DATE],[Waiter_Name])   
    VALUES   
          ('T1','Order for Table T1',GETDATE(),'SHANU' )   
      
INSERT INTO [OrderMasters]   
          ([Table_ID] ,[Description],[Order_DATE],[Waiter_Name])   
    VALUES   
           ('T2','Order for Table T2',GETDATE(),'Afraz' )   
           
INSERT INTO [OrderMasters]   
          ([Table_ID] ,[Description],[Order_DATE],[Waiter_Name])   
     VALUES   
             ('T3','Order for Table T3',GETDATE(),'Afreen')   
              
  
              
CREATE TABLE [dbo].[OrderDetails](   
  [Order_Detail_No] INT IDENTITY PRIMARY KEY,  
 [Order_No] INT,  
 [Item_Name] [varchar](20) NOT NULL,    
 [Notes] [varchar](200) NOT NULL,   
[QTY]  INT NOT NULL,   
 [Price] INT NOT NULL   
 )  
  
--Now let¡¯s insert the 3 items for the above Order No 'Ord_001'.   
  
INSERT INTO [OrderDetails]   
          ( [Order_No],[Item_Name],[Notes],[QTY] ,[Price])   
   VALUES   
          (1,'Ice Cream','Need very Cold',2 ,160)   
  
INSERT INTO [OrderDetails]   
          ([Order_No],[Item_Name],[Notes],[QTY] ,[Price])   
   VALUES   
          (1,'Coffee','Hot and more Suger',1 ,80)   
           
  
          INSERT INTO [OrderDetails]   
          ([Order_No],[Item_Name],[Notes],[QTY] ,[Price])   
   VALUES   
          (1,'Burger','Spicy',3 ,140)   
           
          INSERT INTO [OrderDetails]   
          ([Order_No],[Item_Name],[Notes],[QTY] ,[Price])   
   VALUES   
          (2,'Pizza','More Chees and Large',1 ,350)   
  
           
          INSERT INTO [OrderDetails]   
          ([Order_No],[Item_Name],[Notes],[QTY] ,[Price])   
   VALUES   
          (2,'Cola','Need very Cold',3 ,50)   
           
          INSERT INTO [OrderDetails]   
          ([Order_No],[Item_Name],[Notes],[QTY] ,[Price])   
   VALUES   
          (3,'IDLY','Hot',3 ,40)   
  
          INSERT INTO [OrderDetails]   
          ([Order_No],[Item_Name],[Notes],[QTY] ,[Price])   
   VALUES   
          (3,'Thosa','Hot',3 ,50)   
  
-- To Select and test Order Master and Details  
  
Select * FROM OrderMasters  
  
Select * From OrderDetails  