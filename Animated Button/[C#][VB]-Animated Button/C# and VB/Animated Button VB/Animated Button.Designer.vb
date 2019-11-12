<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnimatedButton
    Inherits System.Windows.Forms.Button

    'Control overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me._FPS = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        '_FPS
        '
        Me._FPS.Enabled = True
        Me._FPS.Interval = 1
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _FPS As System.Windows.Forms.Timer

End Class

