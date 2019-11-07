Public Class StackOverFlow1QuestionMixedTypesForm
    Private ops As New Operations
    Private helper As UtilityLibrary.StringHelpers = New UtilityLibrary.StringHelpers
    Private Sub StackOverFlow1QuestionMixedTypesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = Nothing
        Dim fileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StackOverFlow.xlsx")
        Dim dt = ops.StackOverFlowExample1(fileName, "Sheet1", "A")

        DataGridView1.DataSource = dt

        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.HeaderText = helper.AddSpacesToSentence(col.HeaderText, True)
        Next
        DataGridView1.Columns("DoubleData").DefaultCellStyle.NullValue = "(String)"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.DataSource = Nothing
        Dim fileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StackOverFlow.xlsx")
        Dim dt = ops.StackOverFlowExample2(fileName, "Sheet2")

        DataGridView1.DataSource = dt

        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.HeaderText = helper.AddSpacesToSentence(col.HeaderText, True)
        Next
        DataGridView1.Columns("DoubleData").DefaultCellStyle.NullValue = "(String)"
        DataGridView1.Columns("StringData").DefaultCellStyle.NullValue = "(Double)"
    End Sub
End Class