Imports PluginContracts

Class MainWindow
    Private _Plugins As Dictionary(Of String, IPlugin)

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Plugins = New Dictionary(Of String, IPlugin)
        Dim plugins As ICollection(Of IPlugin) = PluginLoader.LoadPlugins("Plugins")

        If plugins Is Nothing Then
            Close()
            System.Windows.MessageBox.Show("No plugins loaded. Application Closed.")
            Return
        End If

        For Each item In plugins
            _Plugins.Add(item.Name, item)

            Dim b = New Button With {
                .Content = item.Name}
            AddHandler b.Click, AddressOf b_Click
            PluginGrid.Children.Add(b)
        Next

    End Sub

    Private Sub b_Click(sender As Object, e As RoutedEventArgs)
        Dim b As Button = sender
        If b IsNot Nothing Then
            Dim key As String = b.Content.ToString()
            If _Plugins.ContainsKey(key) Then
                Dim plugin As IPlugin = _Plugins(key)
                plugin.DoSomething()
            End If
        End If
    End Sub

End Class
