
Namespace DocumentViewer
    Public Class OverviewPage
        Inherits Page

	    Protected Sub Page_Load(sender As Object, e As EventArgs)
		    documentViewer.Document = exampleFileSelector.SelectedFile
	    End Sub

    End Class
End NameSpace