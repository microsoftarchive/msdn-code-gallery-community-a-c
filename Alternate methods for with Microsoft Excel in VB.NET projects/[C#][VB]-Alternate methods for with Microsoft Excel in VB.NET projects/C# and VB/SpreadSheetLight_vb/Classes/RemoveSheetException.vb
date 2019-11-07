Public Class RemoveSheetException
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(pSheetname As String)
        MyBase.New($"Can not remove currently active worksheet {pSheetname}")
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class
