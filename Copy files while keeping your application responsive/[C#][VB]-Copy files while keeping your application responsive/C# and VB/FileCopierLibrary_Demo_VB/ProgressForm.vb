Public Class frmProgressForm
    Public CancelFlag As Boolean = False
    Public Delegate Sub UpdateSourceDelegate(ByVal value As String)
    Public Sub UpdateSource(ByVal value As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateSourceDelegate(AddressOf UpdateSource), value)
        Else
            lblSource.Text = value
        End If
    End Sub
    Public Delegate Sub UpdateDestinationDelegate(ByVal value As String)
    Public Sub UpdateDestination(ByVal value As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateSourceDelegate(AddressOf UpdateDestination), value)
        Else
            lblDestination.Text = value
        End If
    End Sub
    Public Delegate Sub UpdateProgressBarDelegate(ByVal value As Integer)
    Public Sub UpdateProgressBar(ByVal SoFar As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateProgressBarDelegate(AddressOf UpdateProgressBar), SoFar)
        Else
            Me.ProgressBar1.Value = SoFar
        End If
    End Sub


    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        CancelFlag = True
    End Sub
End Class