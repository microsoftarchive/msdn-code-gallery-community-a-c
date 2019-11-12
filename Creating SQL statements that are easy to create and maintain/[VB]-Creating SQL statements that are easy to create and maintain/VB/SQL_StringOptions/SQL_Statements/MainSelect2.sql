SELECT 
    OrderDate, 
    EnterDate, 
    JobStartDate, 
    JobCompleteDate, 
    LoadDate, 
    OrderID,
    CI.Customer_Name, 
    JobName,
    U.Firstname + ' ' + U.Lastname As FullName, 
    Orders.Status 
FROM OpenOrders As Orders 
LEFT JOIN Users As U ON U.login = Orders.FullName 
LEFT JOIN Customer_Information As CI ON Sch.CustomerID = CI.Customer_ID 
WHERE W1
ORDER BY 
    LoadDate ASC, EnterDate ASC