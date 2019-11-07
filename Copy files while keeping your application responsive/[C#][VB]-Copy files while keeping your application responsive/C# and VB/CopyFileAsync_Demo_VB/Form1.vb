Public Class Form1
    Private Async Sub cmdCopyFilesAsync_Click(sender As Object, e As EventArgs) Handles cmdCopyFilesAsync.Click
        Dim FileCount As Integer = Await CopyFilesAsync()
        MessageBox.Show("Copied " & FileCount.ToString & " files")
    End Sub
    Async Function CopyFilesAsync() As Task(Of Integer)
        Dim FileCount As Integer = 0
        Dim DestinationFile As String = ""

        For Each currentFile As String In IO.Directory.EnumerateFiles(txtStartDirectory.Text)

            Using sourceStream As IO.FileStream = IO.File.Open(currentFile, IO.FileMode.Open)

                DestinationFile = IO.Path.Combine(txtEndDirectory.Text, IO.Path.GetFileName(currentFile))

                Using destinationStream As IO.FileStream = IO.File.Create(DestinationFile)
                    Await sourceStream.CopyToAsync(destinationStream)
                    Me.BeginInvoke(
                        Sub()
                            lblFrom.Text = "Copying: " & currentFile
                            lblToo.Text = "To: : " & DestinationFile
                        End Sub)

                    ' Slow things down for demoing
                    Await Task.Delay(100)

                    FileCount += 1
                End Using

            End Using

        Next

        Return FileCount

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Locations = New GetFolders.Locations
        txtStartDirectory.Text = Locations.SourceFolder
        txtEndDirectory.Text = Locations.DestinationFolder
        ActiveControl = cmdCopyFilesAsync
    End Sub
End Class
