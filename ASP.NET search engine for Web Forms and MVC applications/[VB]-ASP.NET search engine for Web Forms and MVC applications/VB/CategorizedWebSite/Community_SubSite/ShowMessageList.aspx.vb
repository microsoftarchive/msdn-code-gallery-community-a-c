Imports System.IO

Partial Public Class ShowMessageList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim messages() As String = readMessages(Request.MapPath("messages.txt"))
        Dim ds As ArrayList = CreateDataSource(messages)
        For Each message As String In ds
            Panel1.Controls.Add(New LiteralControl("<p>"))
            Panel1.Controls.Add(New LiteralControl(message))
            Panel1.Controls.Add(New LiteralControl("</p>"))
        Next
    End Sub

    Private Function CreateDataSource(ByVal messages() As String) As ArrayList
        Dim r As ArrayList = New ArrayList
        For Each mes As String In messages
            r.Add(mes.Split(Microsoft.VisualBasic.ChrW(124))(1).Replace(vbCr & vbLf, "<br />"))
        Next
        Return r
    End Function

    Private Function readMessages(ByVal path As String) As String()
        Dim r As StreamReader = New StreamReader(path)
        Dim body As String = r.ReadToEnd
        r.Close()
        Return body.Split(New Char() {vbLf})
    End Function
End Class