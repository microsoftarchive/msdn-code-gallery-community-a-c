Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Locations = New GetFolders.Locations
        txtStartDirectory.Text = Locations.SourceFolder
        txtEndDirectory.Text = Locations.DestinationFolder
        ActiveControl = cmdCopy
    End Sub
    Private Async Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        For Each file As String In IO.Directory.GetFiles(txtStartDirectory.Text)
            lblStatus.Text = String.Format("Copying {0} to {1}", file, IO.Path.Combine(txtEndDirectory.Text, IO.Path.GetFileName(file)))
            IO.File.Copy(file, IO.Path.Combine(txtEndDirectory.Text, IO.Path.GetFileName(file)), True)
            Await Task.Delay(200)
        Next
    End Sub
End Class
