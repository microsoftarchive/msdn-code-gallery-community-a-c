''' <summary>
''' 
''' </summary>
''' <remarks>
''' Could have used constants rather than functions
''' </remarks>
Public Module ProjectGlobals
    ''' <summary>
    ''' Customer table primary key
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CustomerIdentifier() As String
        Return "Identifier"
    End Function
    ''' <summary>
    ''' Order table primary key
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OrderIdentifier() As String
        Return "OrderID"
    End Function
    Public Function RemoveFilterIdentifier() As String
        Return "0"
    End Function
End Module
