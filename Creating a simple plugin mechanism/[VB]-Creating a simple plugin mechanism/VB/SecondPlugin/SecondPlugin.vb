Imports PluginContracts

Public Class SecondPlugin
    Implements IPlugin

    Public Sub DoSomething() Implements IPlugin.DoSomething
        System.Windows.MessageBox.Show("Do Something in Second Plugin")
    End Sub

    Public ReadOnly Property Name As String Implements IPlugin.Name
        Get
            Name = "Second Plugin"
        End Get
    End Property
End Class
