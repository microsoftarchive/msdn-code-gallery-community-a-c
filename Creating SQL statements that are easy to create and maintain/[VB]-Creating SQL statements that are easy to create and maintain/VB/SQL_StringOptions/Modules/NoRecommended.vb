''' <summary>
''' Contains not the best ideas for creating SQL statements.
''' </summary>
''' <remarks></remarks>
Module NoRecommended
    ''' <summary>
    ''' Some actually used this but unless you alter the color in the IDE it is
    ''' not possible to read the data. Hence XML literals are best.
    ''' </summary>
    ''' <remarks>
    ''' DO NOT use this.
    ''' </remarks>
    Private Sub Stuff1()
        ' Have fun reading this :-)
        Dim HardToRead As String =
<T>
    <![CDATA[
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
ORDER BY 
    LoadDate ASC, EnterDate ASC
]]>
</T>.Value
        Console.WriteLine(HardToRead)
    End Sub
    ''' <summary>
    ''' There is no good reason to concatenate strings like this.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Stuff2()
        Dim BadBadBad As String = _
            "SELECT " &
            "    OrderDate,  " &
            "    EnterDate,  " &
            "    JobStartDate,  " &
            "    JobCompleteDate,  " &
            "    LoadDate,  " &
            "    OrderID, " &
            "    CI.Customer_Name,  " &
            "    JobName, " &
            "    U.Firstname + ' ' + U.Lastname As FullName,  " &
            "    Orders.Status  " &
            "FROM OpenOrders As Orders  " &
            "LEFT JOIN Users As U ON U.login = Orders.FullName  " &
            "LEFT JOIN Customer_Information As CI ON Sch.CustomerID = CI.Customer_ID  " &
            "ORDER BY  " &
            "    LoadDate ASC, EnterDate ASC "
    End Sub
End Module
