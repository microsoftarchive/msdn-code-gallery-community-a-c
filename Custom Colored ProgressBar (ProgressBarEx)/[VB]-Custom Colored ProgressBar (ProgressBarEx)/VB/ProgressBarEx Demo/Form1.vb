Public Class Form1
    Private WithEvents tmr As New Timer With {.Interval = 75}

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProgressBarEx5.Value = 0
        ProgressBarEx5.ShowPercentage = True
        ProgressBarEx5.ShowText = False
        tmr.Start()
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr.Tick
        ProgressBarEx5.Value += 1
        If ProgressBarEx5.Value = 100 Then
            tmr.Stop()
            ProgressBarEx5.ShowPercentage = False
            ProgressBarEx5.ShowText = True
            ProgressBarEx5.Text = "Finished"
        End If
    End Sub
End Class
