Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text

Public Class Form1
    Private rand As New Random()
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        PictureBox1.Image.Dispose()
        code = ""
        CreateImage()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        If TextBox1.Text = code.ToString() Then
            MessageBox.Show("Proceed")
            Close()
        Else
            MessageBox.Show("Incorrect entry")
        End If
    End Sub

    Private Sub CreateImage()
        Dim code As String = GetRandomText()
        Dim bitmap As New Bitmap(200, 50, PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(bitmap)
        Dim pen As New Pen(Color.Yellow)
        Dim rect As New Rectangle(0, 0, 200, 50)
        Dim b As New SolidBrush(Color.Black)
        Dim White As New SolidBrush(Color.White)
        Dim counter As Integer = 0
        g.DrawRectangle(pen, rect)
        g.FillRectangle(b, rect)
        For i As Integer = 0 To code.Length - 1
            g.DrawString(code(i).ToString(), New Font("Georgia", 10 + rand.[Next](14, 18)), White, New PointF(10 + counter, 10))
            counter += 20
        Next
        DrawRandomLines(g)
        If File.Exists("d:/tempimage.bmp") Then
            Try
                File.Delete("d:/tempimage.bmp")
                bitmap.Save("d:/tempimage.bmp")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            bitmap.Save("d:/tempimage.bmp")
        End If
        g.Dispose()
        bitmap.Dispose()
        PictureBox1.Image = Image.FromFile("d:/tempimage.bmp")
    End Sub
    Private Function GetRandomPoints() As Point()
        Dim points As Point() = {New Point(rand.[Next](10, 150), rand.[Next](10, 150)), New Point(rand.[Next](10, 100), rand.[Next](10, 100))}
        Return points
    End Function
    Private code As String
    Private Function GetRandomText() As String
        Dim randomText As New StringBuilder()
        If [String].IsNullOrEmpty(code) Then
            Dim alphabets As String = "abcdefghijklmnopqrstuvwxyz1234567890"
            Dim r As New Random()
            For j As Integer = 0 To 5
                randomText.Append(alphabets(r.[Next](alphabets.Length)))
            Next
            code = randomText.ToString()
        End If
        Return code
    End Function

    Private Sub DrawRandomLines(ByVal g As Graphics)
        Dim green As New SolidBrush(Color.Green)
        'For Creating Lines on The Captcha
        For i As Integer = 0 To 19
            g.DrawLines(New Pen(green, 2), GetRandomPoints())
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateImage()
    End Sub
End Class
