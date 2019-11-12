Public Class aFrm1

    '' for wave sounds
    Public soundPlay As New System.Media.SoundPlayer

    Private Sub aFrm1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        soundPlay.Stop()
    End Sub

    Private Sub aFrm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Left = CInt((Me.ClientSize.Width - Label1.Width) / 2)
        Button1.Left = CInt((Me.ClientSize.Width - Button1.Width) / 2)
        soundPlay.SoundLocation = Application.StartupPath & "\alarm.wav"
        soundPlay.PlayLooping()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class