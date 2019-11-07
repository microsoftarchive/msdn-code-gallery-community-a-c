Class MainWindow 
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim data As New Data With {
            .HeaderNameText = "Header2",
            .Items = New List(Of String) From {"Itmes1", "Items2"}}

        Me.DataContext = data
    End Sub

End Class
