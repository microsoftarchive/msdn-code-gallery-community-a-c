
Imports System.Data.OleDb


Partial Class CustomPages_DBSQL
    Inherits System.Web.UI.Page
    Private Shared con As OleDbConnection
    Private Shared cmd As OleDbCommand
    Public Sub handlePanels(ByVal pTsk1 As Boolean, ByVal pIns1 As Boolean, ByVal pDel1 As Boolean, ByVal pUp1 As Boolean)
        pTsk.Visible = pTsk1
        pIns.Visible = pIns1
        pDel.Visible = pDel1
        pUp.Visible = pUp1
        TxtInsContact.Text = ""
        TxtName.Text = ""
        TxtUpContact.Text = ""
        TxtUpName.Text = ""
        If pTsk1 Then
            Label2.Text = "Tasks"
        ElseIf pIns1 Then
            Label2.Text = "Insert"
        ElseIf pDel1 Then
            Label2.Text = "Delete"
        ElseIf pUp1 Then
            Label2.Text = "Update"
        End If
    End Sub

    Private Sub CustomPages_DBSQL_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
    End Sub
    Private Function getQueryResult(query As String, Optional ByVal j As Short = 0) As String
        con.Open()
        Dim data As String = ""
        cmd = New OleDbCommand(query, con)
        If j = 1 Then
            data = cmd.ExecuteScalar()
        Else
            data = cmd.ExecuteNonQuery()
        End If
        con.Close()
        GridView1.DataBind()
        Return data
    End Function

    Private Sub BtIns_Click(sender As Object, e As EventArgs) Handles BtIns.Click
        handlePanels(False, True, False, False)
    End Sub

    Private Sub BtDel_Click(sender As Object, e As EventArgs) Handles BtDel.Click
        Dim i As Short
        Try
            i = getQueryResult("select max(id) from AccessEmp;", 1)
            handlePanels(False, False, True, False)
            Dim j As Short
            DropDownDelID.Items.Clear()
            For j = 1 To i
                DropDownDelID.Items.Add(j)
            Next
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub BtUp_Click(sender As Object, e As EventArgs) Handles BtUp.Click
        Dim i As Short
        Try
            i = getQueryResult("select max(id) from AccessEmp;", 1)
            handlePanels(False, False, False, True)
            Dim j As Short
            DropDownUpID.Items.Clear()
            For j = 1 To i
                DropDownUpID.Items.Add(j)
            Next
            DropDownUpID_SelectedIndexChanged(Me, e)
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub BtCancel_Click(sender As Object, e As EventArgs) Handles BtUpCancel.Click, BtDelCancel.Click, BtInsCancel.Click
        handlePanels(True, False, False, False)
    End Sub

    Private Sub BtInsIns_Click(sender As Object, e As EventArgs) Handles BtInsIns.Click
        If TxtName.Text <> "" Then
            Dim i As Short
            Try
                i = getQueryResult("select max(id) from AccessEmp;", 1)
            Catch ex As Exception
                con.Close()
                i = 0
            End Try
            Dim Emp_Contact As Integer
            If Integer.TryParse(TxtInsContact.Text, Emp_Contact) Then
                getQueryResult(String.Format("insert into AccessEmp values({0},'{1}','{2}',{3});", i + 1, TxtName.Text, DropDownDeptIns.SelectedItem.Text, Emp_Contact))
                BtCancel_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub BtDelDel_Click(sender As Object, e As EventArgs) Handles BtDelDel.Click
        Dim i = DropDownDelID.SelectedIndex
        Dim j = getQueryResult("select max(id) from AccessEmp;", 1)
        getQueryResult(String.Format("delete from AccessEmp where id={0}", i + 1))
        Dim k As Short
        For k = i + 2 To j
            getQueryResult(String.Format("update AccessEmp set id={1} where id={0}", k, k - 1))
        Next
        BtCancel_Click(sender, e)
    End Sub

    Private Sub BtUpIns_Click(sender As Object, e As EventArgs) Handles BtUpIns.Click
        If TxtUpName.Text <> "" Then
            Dim Emp_Contact As Integer
            If Integer.TryParse(TxtUpContact.Text, Emp_Contact) Then
                Dim i = DropDownUpID.SelectedIndex
                getQueryResult(String.Format("update AccessEmp set Emp_Name='{1}',Emp_Dept='{2}',Emp_Contact={3} where id={0}", i + 1, TxtUpName.Text, DropDownDeptUp.SelectedValue, TxtUpContact.Text))
                BtCancel_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub DropDownUpID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownUpID.SelectedIndexChanged
        TxtUpName.Text = getQueryResult(String.Format("select Emp_Name from AccessEmp where id={0};", DropDownUpID.SelectedValue), 1)
        DropDownDeptUp.Text = getQueryResult(String.Format("select Emp_Dept from AccessEmp where id={0};", DropDownUpID.SelectedValue), 1)
        TxtUpContact.Text = getQueryResult(String.Format("select Emp_Contact from AccessEmp where id={0};", DropDownUpID.SelectedValue), 1)
    End Sub

End Class
