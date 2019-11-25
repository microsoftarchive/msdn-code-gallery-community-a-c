Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim NUM1, NUM2, RESULT As Integer
        NUM1 = Val(TextBox1.Text)
        NUM2 = Val(TextBox2.Text)
        RESULT = NUM1 + NUM2
        TextBox3.Text = RESULT
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim NUM1, NUM2, RESULT As Integer
        NUM1 = Val(TextBox1.Text)
        NUM2 = Val(TextBox2.Text)
        RESULT = NUM1 - NUM2
        TextBox3.Text = RESULT
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim NUM1, NUM2, RESULT As Integer
        NUM1 = Val(TextBox1.Text)
        NUM2 = Val(TextBox2.Text)
        RESULT = NUM1 * NUM2
        TextBox3.Text = RESULT
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim NUM1, NUM2, RESULT As Integer
        NUM1 = Val(TextBox1.Text)
        NUM2 = Val(TextBox2.Text)
        RESULT = NUM1 / NUM2
        TextBox3.Text = RESULT
    End Sub
End Class
