Public Class Form1

    Delegate Sub UpDateProcessBarDelegate(ByVal FileName As String, ByVal Counter As Integer)
    Private Waiting As Boolean = False
    Private StartDirectory As String = ""
    Private EndDirectory As String = ""
    Private FileCount As Integer = 0
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MessageBox.Show("Done")
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim Files As List(Of String) = (From t In IO.Directory.GetFiles(StartDirectory) Select IO.Path.GetFileName(t)).ToList

        FileCount = Files.Count

        Dim UpdateListBoxDel As UpDateProcessBarDelegate = New UpDateProcessBarDelegate(AddressOf UpdateProgressBar)
        Dim Counter As Integer = 1

        For Each file In Files
            Threading.Thread.Sleep(30)

            IO.File.Copy(IO.Path.Combine(StartDirectory, file), IO.Path.Combine(EndDirectory, file), True)

            If Not BackgroundWorker1.CancellationPending Then
                Me.Invoke(UpdateListBoxDel, file, Counter)
                Counter += 1
            Else
                Exit For
            End If
        Next
    End Sub
    Private Sub cmdCopyFolder_Click(sender As Object, e As EventArgs) Handles cmdCopyFolder.Click
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub
    Public Sub UpdateProgressBar(ByVal FileName As String, ByVal Counter As Integer)
        Me.ProgressBar1.Value = CInt((Counter / Me.FileCount) * 100)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Locations = New GetFolders.Locations
        txtStartDirectory.Text = Locations.SourceFolder
        StartDirectory = Locations.SourceFolder
        txtEndDirectory.Text = Locations.DestinationFolder
        EndDirectory = Locations.DestinationFolder
        ActiveControl = cmdCopyFolder
    End Sub
End Class
