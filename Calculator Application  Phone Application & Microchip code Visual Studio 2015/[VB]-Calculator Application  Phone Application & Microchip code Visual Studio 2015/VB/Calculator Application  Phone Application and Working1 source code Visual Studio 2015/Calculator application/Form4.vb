Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ProcID As Integer
        Dim c As Integer
        Dim d As Integer
        Me.TopMost = True
        ProcID = Form1a.TextBox2.Text
        TextBox1.Text = ProcID
        AppActivate(ProcID)
        c = TextBox1.Text
        d = TextBox2.Text
        My.Computer.Keyboard.SendKeys(c, True)
        My.Computer.Keyboard.SendKeys("~", True)
        My.Computer.Keyboard.SendKeys(d, True)
        My.Computer.Keyboard.SendKeys("~", True)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1a.Show()
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class