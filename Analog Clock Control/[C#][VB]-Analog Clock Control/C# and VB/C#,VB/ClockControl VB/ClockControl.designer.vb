Namespace ClockControl 
    Partial Class ClockControl 
        #Region "IContainer" 
 
        ''' <summary> 
        ''' Required designer variable. 
        ''' </summary> 
        Private components As System.ComponentModel.IContainer = Nothing 
 
        #End Region 
 
        #Region "Dispose" 
 
        ''' <summary> 
        ''' Clean up any resources being used. 
        ''' </summary> 
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param> 
        Protected Overrides Sub Dispose(disposing As Boolean) 
            If disposing AndAlso (components IsNot Nothing) Then 
                components.Dispose() 
            End If 
            MyBase.Dispose(disposing) 
        End Sub 
 
        #End Region 
 
        #Region "Component Designer generated code" 
 
        #Region "Initialize Component" 
 
        ''' <summary> 
        ''' Required method for Designer support - do not modify  
        ''' the contents of this method with the code editor. 
        ''' </summary> 
        Private Sub InitializeComponent() 
            components = New System.ComponentModel.Container() 
        End Sub 
 
        #End Region 
 
        #End Region 
    End Class 
End Namespace 
