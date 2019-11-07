Public Class Form1
    WithEvents bsAnswers As New BindingSource
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtAnswers As New DataTable

        dtAnswers.Columns.AddRange(New DataColumn() _
            {
                New DataColumn("IsSelected", GetType(System.Boolean)),
                New DataColumn("Answer", GetType(System.Boolean)),
                New DataColumn("OptionName", GetType(System.String))
            }
        )

        dtAnswers.Rows.Add(New Object() {False, False, "2003"})
        dtAnswers.Rows.Add(New Object() {False, True, "2007"})
        dtAnswers.Rows.Add(New Object() {False, False, "2010"})

        bsAnswers.DataSource = dtAnswers
        DataGridView1.DataSource = bsAnswers

    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Value As Boolean = CBool(DataGridView1.Rows(e.RowIndex).Cells("SelectionColumn").Value)
        If Value Then
            Dim Index As Integer = e.RowIndex
            For row As Integer = 0 To DataGridView1.Rows.Count - 1
                If row <> Index Then
                    DataGridView1.Rows(row).Cells("SelectionColumn").Value = False
                End If
            Next
        Else
            DataGridView1.Rows(e.RowIndex).Cells("SelectionColumn").Value = True
            Dim Index As Integer = e.RowIndex
            For row As Integer = 0 To DataGridView1.Rows.Count - 1
                If row <> Index Then
                    DataGridView1.Rows(row).Cells("SelectionColumn").Value = False
                End If
            Next
        End If

        ' Force cell painting
        DataGridView1.CurrentCell = DataGridView1(0, e.RowIndex)

    End Sub
    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged( _
        ByVal sender As Object, _
        ByVal e As EventArgs) _
    Handles DataGridView1.CurrentCellDirtyStateChanged

        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.EndEdit()
        End If
    End Sub
    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting

        If e.ColumnIndex = DataGridView1.Columns("SelectionColumn").Index AndAlso e.RowIndex >= 0 Then
            e.PaintBackground(e.ClipBounds, True)

            Dim rectButton As Rectangle

            rectButton.Width = 14
            rectButton.Height = 14
            rectButton.X = e.CellBounds.X + (e.CellBounds.Width - rectButton.Width) \ 2
            rectButton.Y = e.CellBounds.Y + (e.CellBounds.Height - rectButton.Height) \ 2

            If IsDBNull(e.Value) OrElse CBool(e.Value) = False Then
                ControlPaint.DrawRadioButton(e.Graphics, rectButton, ButtonState.Normal)
            Else
                ControlPaint.DrawRadioButton(e.Graphics, rectButton, ButtonState.Checked)
            End If

            e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus)
            e.Handled = True

        End If
    End Sub

    Private Sub cmdSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelected.Click

        Dim Selection =
            (
                From T In CType(bsAnswers.DataSource, DataTable).AsEnumerable
                Where T.Field(Of Boolean)("IsSelected")
                Select
                    Answer = T.Field(Of String)("OptionName"),
                    Correct = T.Field(Of Boolean)("Answer")
            ).FirstOrDefault

        If Selection IsNot Nothing Then
            If Selection.Correct Then
                MessageBox.Show("You selected '" & Selection.Answer & "' which is correct")
            Else
                MessageBox.Show("You selected '" & Selection.Answer & "' which is not correct")
            End If

        Else
            MessageBox.Show("Please make a selection")
        End If

    End Sub
End Class
