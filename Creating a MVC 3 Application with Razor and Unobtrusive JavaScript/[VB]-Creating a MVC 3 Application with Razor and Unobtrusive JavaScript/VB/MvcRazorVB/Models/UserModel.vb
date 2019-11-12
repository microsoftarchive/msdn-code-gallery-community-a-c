Imports System.ComponentModel.DataAnnotations
Public Class UserModel

    <Required(), StringLength(6, MinimumLength:=3), Display(Name:="User Name"), RegularExpression("(\S)+", ErrorMessage:="White space is not allowed"), ScaffoldColumn(False)>
    Public Property UserName() As String

    <Required(), StringLength(8, MinimumLength:=3), Display(Name:="First Name")>
    Public Property FirstName() As String
    <Required(), StringLength(9, MinimumLength:=2), Display(Name:="Last Name")>
    Public Property LastName() As String
    <Required()>
    Public Property City() As String

End Class

Public Class Users

    Public Sub New()
        _usrList.Add(New UserModel With {.UserName = "BenM", .FirstName = "Ben", .LastName = "Miller", .City = "Seattle"})
        _usrList.Add(New UserModel With {.UserName = "AnnB", .FirstName = "Ann", .LastName = "Beebe", .City = "Boston"})
    End Sub

    Public _usrList As New List(Of UserModel)()

    Public Sub Update(ByVal umToUpdate As UserModel)

        For Each um As UserModel In _usrList
            If um.UserName = umToUpdate.UserName Then
                _usrList.Remove(um)
                _usrList.Add(umToUpdate)
                Exit For
            End If
        Next um
    End Sub

    Public Sub Create(ByVal umToUpdate As UserModel)
        For Each um As UserModel In _usrList
            If um.UserName = umToUpdate.UserName Then
                Throw New InvalidOperationException("Duplicat username: " & um.UserName)
            End If
        Next um
        _usrList.Add(umToUpdate)
    End Sub

    Public Sub Remove(ByVal usrName As String)

        For Each um As UserModel In _usrList
            If um.UserName = usrName Then
                _usrList.Remove(um)
                Exit For
            End If
        Next um
    End Sub

    Public Function GetUser(ByVal uid As String) As UserModel
        Dim usrMdl As UserModel = Nothing

        For Each um As UserModel In _usrList
            If um.UserName = uid Then
                usrMdl = um
            End If
        Next um

        Return usrMdl
    End Function

End Class
