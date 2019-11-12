Public Class frmPrincipal

    Private cuenta As Integer = 100

    Private Sub btnIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciar.Click
        Try
            Me.btnIniciar.Enabled = False
            cuenta = Me.NumericUpDown1.Value
            Me.BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show("Excepción controlada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Delegate Sub AddNumeroDelegate(ByVal number As Integer)

    Private Sub AddNumero(ByVal number As Integer)
        If txtProgreso.InvokeRequired Then
            txtProgreso.Invoke(New AddNumeroDelegate(AddressOf AddNumero), number)
        Else
            txtProgreso.AppendText("Elemento " & (number + 1).ToString() & " procesandose.." + Environment.NewLine)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim i As Integer
            While i < cuenta
                BackgroundWorker1.ReportProgress(100 * i / cuenta, "Procesando (" & i & "/" & cuenta & ") elementos...")
                AddNumero(i)
                Threading.Thread.Sleep(100)
                i += 1
            End While
            BackgroundWorker1.ReportProgress(100, "Completado!")
            e.Result = True
        Catch ex As Exception
            e.Result = False
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Me.btnIniciar.Enabled = True
        Catch ex As Exception
            Me.btnIniciar.Enabled = True
            MessageBox.Show("Excepción controlada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            ProgressBar1.Value = e.ProgressPercentage
            lblEstado.Text = e.UserState
        Catch ex As Exception
            MessageBox.Show("Excepción controlada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
