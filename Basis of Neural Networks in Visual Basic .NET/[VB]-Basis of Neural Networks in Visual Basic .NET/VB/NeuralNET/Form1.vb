Imports NeuralNET.NeuralNet

Public Class Form1

    Dim network As NeuralNetwork

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim layerList As New List(Of Integer)
        With layerList
            .Add(2)
            .Add(4)
            .Add(2)
        End With

        network = New NeuralNetwork(21.5, layerList)

        Button3_Click(sender, e)
        PictureBox1.Refresh()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim inputs As New List(Of Double)
        inputs.Add(txtIn01.Text)
        inputs.Add(txtIn02.Text)


        Dim ots As List(Of Double) = network.Execute(inputs)
        txtOt01.Text = ots(0)
        txtOt02.Text = ots(1)
        Button3_Click(sender, e)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim inputs As New List(Of Double)
        inputs.Add(txtVal01.Text)
        inputs.Add(txtVal02.Text)

        Dim otputs As New List(Of Double)
        otputs.Add(txtVal02.Text)
        otputs.Add(txtVal01.Text)

        Dim tot As Long = CLng(txtIter.Text)
        For ii = 0 To tot - 1
            network.Train(inputs, otputs)
            Application.DoEvents()

            Dim rOut As List(Of Double) = network.Execute(inputs)
            txtOut01.Text = rOut.Item(0)
            txtOut02.Text = rOut.Item(1)

            labProgress.Text = (ii + 1).ToString & " / " & tot.ToString & " ( " & ((ii * 100) / tot).ToString("000.00") & "% )"
        Next ii

        Button3_Click(sender, e)
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        network.Draw(e.Graphics, 250, PictureBox1.Height - 45, 30, 60, 60, Color.RoyalBlue, Color.Gray, Color.Black)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = network.ToString
    End Sub

End Class
