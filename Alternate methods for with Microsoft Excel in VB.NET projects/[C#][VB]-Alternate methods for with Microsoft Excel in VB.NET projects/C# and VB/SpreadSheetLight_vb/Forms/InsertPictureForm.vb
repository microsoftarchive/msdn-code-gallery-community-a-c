Imports System.IO

Public Class InsertPictureForm
    Private ops As New Operations
    Private imageFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "theroad.jpg")
    Private excelFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InsertImage.xlsx")
    Private Sub InsertPictureForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim img As Image
        Using ms As New MemoryStream(IO.File.ReadAllBytes(imageFileName))
            img = Image.FromStream(ms)
        End Using

        PictureBox1.Image = img
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ops.InsertImage(excelFileName, "RoadSheet", imageFileName) Then
            Process.Start(excelFileName)
            Close()
        Else
            Console.WriteLine(ops.Exception.Message)
        End If
    End Sub
End Class