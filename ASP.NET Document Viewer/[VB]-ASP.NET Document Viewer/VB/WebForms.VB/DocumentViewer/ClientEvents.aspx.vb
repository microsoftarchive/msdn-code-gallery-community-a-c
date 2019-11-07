
Namespace DocumentViewer
    Public Class ClientEventsPage
        Inherits Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            DocumentViewer.Document = exampleFileSelector.SelectedFile
        End Sub

    End Class
End NameSpace
