Imports FormHelpers
Imports FileCopierLibrary
Imports Extensions

''' <summary>
''' Uses class from FileCopierLibrary
''' </summary>
''' <remarks></remarks>
Public Class Form1
    Private f As New frmProgressForm
    Private Async Sub cmdCopyFiles_Click(sender As Object, e As EventArgs) Handles cmdCopyFiles.Click
        If String.IsNullOrWhiteSpace(txtStartDirectory.Text) OrElse String.IsNullOrWhiteSpace(txtEndDirectory.Text) Then
            MessageBox.Show("Requires both folder")
            Exit Sub
        End If

        If Not IO.Directory.Exists(txtStartDirectory.Text) Then
            MessageBox.Show("Failed to find source folder")
            Exit Sub
        End If

        If Not IO.Directory.Exists(txtEndDirectory.Text) Then
            MessageBox.Show("Failed to find destination folder")
            Exit Sub
        End If

        Dim DestinationFile As String = ""
        Dim Copier As New CustomFileCopier()
        AddHandler Copier.OnProgressChanged, AddressOf Progress1
        f = New frmProgressForm
        f.Show()
        CenterForm(f, Me)
        For Each currentFile As String In IO.Directory.EnumerateFiles(txtStartDirectory.Text)

            DestinationFile = IO.Path.Combine(txtEndDirectory.Text, IO.Path.GetFileName(currentFile))

            f.UpdateSource(currentFile)
            f.UpdateDestination(DestinationFile)

            Copier.SourceFilePath = currentFile
            Copier.DestFilePath = DestinationFile

            Copier.Copy()

            If chkSlowProcessDown.Checked Then
                Await Task.Delay(80)
            End If

            If f.CancelFlag Then
                Exit For
            End If
        Next

        f.Dispose()

    End Sub
    Private Sub Progress1(Percentage As Integer, ByRef Cancel As Boolean)
        f.UpdateProgressBar(Percentage)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Locations = New GetFolders.Locations
        txtStartDirectory.Text = Locations.SourceFolder
        txtEndDirectory.Text = Locations.DestinationFolder
        ActiveControl = cmdCopyFiles
    End Sub
End Class
