-- Create Database InvnetoryManagement
CREATE DATABASE InvnetoryManagement;

-- Use Database
use InvnetoryManagement;

-- If you get safeupdate error in Mysql use this
SET SQL_SAFE_UPDATES = 0;

-- 1) Create table Item Master
CREATE TABLE ItemMaster
(
Item_Code int NOT NULL AUTO_INCREMENT,
Item_Name  varchar(100)  NOT NULL,
Price int,
TAX1 int,
Description varchar(100) ,
IN_DATE datetime,
IN_USR_ID varchar(50) , 
DeleteStatus varchar(10),
PRIMARY KEY (Item_Code)
);
-- Insert sample Record to Univ Master
insert into ItemMaster(Item_Name,Price,TAX1,Description,IN_DATE,IN_USR_ID,DeleteStatus) values ('headPhone',600,2,'head Phone',now(),'SHANU','N');
insert into ItemMaster(Item_Name,Price,TAX1,Description,IN_DATE,IN_USR_ID,DeleteStatus) values ('Mouse',30,0,'Mousee',now(),'SHANU','N');

--  test Select Statement
select * from ItemMaster;
-- End 1) 

-- Stored procedure to search by ItemCode and Item Name
DELIMITER //
CREATE PROCEDURE USP_SelectItemmaster(IN P_ItemCode varchar(100),IN P_ItemName varchar(100))
BEGIN
    SELECT  Item_Code,
			Item_Name,
			Price,
            TAX1,
            Description,
            IN_DATE,
            IN_USR_ID,
            DeleteStatus            
			FROM 
            ItemMaster 
            where
            Item_Code like  CONCAT(TRIM(IFNULL(P_ItemCode, '')), '%') 
            and Item_Name like  CONCAT(TRIM(IFNULL(P_ItemName, '')), '%')
            AND DeleteStatus='N';
END //
DELIMITER ;


  CALL  USP_SelectItemmaster('','')
  
drop procedure USP_InsertItemmaster
  -- Insert Stored Procedure for Item master
DELIMITER //
CREATE PROCEDURE USP_InsertItemmaster(IN P_Item_Name varchar(100),
IN P_Price int,
IN P_TAX1 int,
IN P_Description varchar(100),
IN P_IN_USR_ID varchar(100)
)
BEGIN
 IF NOT EXISTS(SELECT 1 FROM ItemMaster WHERE Item_Name=P_Item_Name and DeleteStatus='N') THEN
  BEGIN
  
     insert into ItemMaster(Item_Name,
							Price,
							TAX1,
							Description,
							IN_DATE,
							IN_USR_ID,
							DeleteStatus)      
			values (P_Item_Name,
					P_Price,
                    P_TAX1,
                    P_Description,
                    now(),
                    P_IN_USR_ID,
                    'N');
                    select "inserted" as "Result";
    end;
 ELSE

 select "Exists" as "Result";

 ENd IF;
END //

DELIMITER ;

  -- Update Stored Procedure for Item master
DELIMITER //
CREATE PROCEDURE USP_UpdateItemmaster(IN P_Item_Code int,
IN P_Item_Name varchar(100),
IN P_Price int,
IN P_TAX1 int,
IN P_Description varchar(100),
IN P_IN_USR_ID varchar(100)
)
BEGIN
 update ItemMaster SET 
					Price=P_Price,
                    TAX1=P_TAX1,
					Description=P_Description
 where Item_Code=P_Item_Code;
 select "updated" as "Result";

END //
DELIMITER ;



update ItemMaster SET DeleteStatus='N' 