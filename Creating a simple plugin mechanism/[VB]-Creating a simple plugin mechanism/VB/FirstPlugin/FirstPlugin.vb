Imports PluginContracts

Public Class FirstPlugin
    Implements IPlugin


    Public Sub DoSomething() Implements IPlugin.DoSomething
        System.Windows.MessageBox.Show("Do Something in First Plugin")
    End Sub

    Public ReadOnly Property Name As String Implements IPlugin.Name
        Get
            Name = "First Plugin"
        End Get
    End Property
End Class
