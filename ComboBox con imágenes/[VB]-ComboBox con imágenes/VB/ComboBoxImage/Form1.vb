Public Class Form1

    Public Sub New()

        InitializeComponent()

        cmbImages.DropDownStyle = ComboBoxStyle.DropDownList
        cmbImages.DrawMode = DrawMode.OwnerDrawFixed
        cmbImages.Items.AddRange( _
            Enumerable.Repeat(Of String)("", listImages.Images.Count).ToArray())

    End Sub

    Private Sub cmbImages_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbImages.DrawItem
        e.DrawBackground()
        e.DrawFocusRectangle()
        If e.Index >= 0 Then
            If e.Index < listImages.Images.Count Then
                Dim img As Image = New Bitmap(listImages.Images(e.Index), New Size(32, 32))
                e.Graphics.DrawImage(img, New PointF(e.Bounds.Left, e.Bounds.Top))
            End If
            e.Graphics.DrawString(String.Format("Minion {0}", e.Index + 1) _
                                      , e.Font, New SolidBrush(e.ForeColor) _
                                      , e.Bounds.Left + 32, e.Bounds.Top)
        End If
    End Sub

    Private Sub cmbImages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbImages.SelectedIndexChanged
        Dim combo As ComboBox = CType(sender, ComboBox)
        If combo.SelectedIndex >= 0 Then
            picImage.Image = listImages.Images(combo.SelectedIndex)
        Else
            picImage.Image = Nothing
        End If
    End Sub
End Class
