Imports System.Data.OleDb
''' <summary>
''' Shows several methods to create SQL statements without the need to use string concatenation.
''' </summary>
''' <remarks>
''' Usually controls would be named in a meaningful manner which was not done here. Originally
''' this code was not expected to get this size.
''' </remarks>
Public Class frmMainForm
    WithEvents bsData As New BindingSource
    ''' <summary>
    ''' Responsible for displaying SQL results in a web browser on a child form.
    ''' </summary>
    ''' <param name="SelectStatement">SQL statement</param>
    ''' <param name="Style">Sets the background gradient for the web browser</param>
    ''' <remarks></remarks>
    Private Sub ShowStatement(ByVal SelectStatement As String, ByVal Style As String)
        Dim f As New frmView
        Dim Content =
                <html>
                    <head>
                        <style>
                            html, body {margin: 0;padding: 0;}
                            html {height: 100%;}
                            <%= Style %>
                            body {position: relative;	min-height: 100%;}
                            /*
                            * IE hack - IE doesn't know min-height but does incorrectly interpret
                            * height, effectively causing the same effect as min-height should in
                            * this case. Uses IE's root ghost hack to only apply to IE.
                            */
                            * html body {height: 100%;}
                            #head, #foot {position: absolute;padding: .5em 0;height: 1em;width: 100%;}
                            #head {top: 0;}
                            #foot {bottom: 0;}
                            #content {padding: 1.5em 2.5em;}
                        </style>
                        <script type="text/javascript">
                            function toBottom()
                            {
                                window.scrollTo(0, document.body.scrollHeight);
                            }
                        </script>
                    </head>
                    <body onload="toBottom()">
                        <div id="content">
                            <pre>
                                <%= SelectStatement %>
                            </pre>
                        </div>
                        <div id="foot" style="background: #FFFF00; text-align: center;font-size: 9px;font-family: verdana, arial, helvetica, sans-serif;">Demo by Kevininstructor</div>
                    </body>
                </html>.ToString

        Try
            f.WebBrowser1.DocumentText = Content
            f.ActiveControl = f.Button1
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try

    End Sub
    ''' <summary>
    ''' Demoing a simple SQL select, where clause is variable
    ''' Where clause field is setup as a string using apostrophes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Better to use parameters as in Button5 click event
    ''' </remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SelectStatement As String = My.SQL.GetSQL("MainSelect1.sql").Replace("StatusFilter", "SomeField = '" & ComboBox1.Text & "'")

        ShowStatement(SelectStatement, WebStyles.Button1Style)

    End Sub
    ''' <summary>
    ''' Demoing a simple SQL select, where clause is variable
    ''' Where clause field is setup as a integer, no apostrophes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Better to use parameters as in Button5 click event
    ''' </remarks>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SelectStatement As String = My.SQL.GetSQL("MainSelect1.sql").Replace("StatusFilter", "SomeField = " & ComboBox2.Text)

        ShowStatement(SelectStatement, WebStyles.Button2Style)

    End Sub

    ''' <summary>
    ''' SQL select where we use an anchor of WHERE W1 to insert a compound condition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' CreateWhereStringList return assist with placing AND between conditions as needed.
    ''' </remarks>
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Items As New List(Of String)

        If Not String.IsNullOrWhiteSpace(ComboBox3.Text) Then
            Items.Add("F1 ='" & ComboBox3.Text.Replace("'", "''") & "'")
            Items.Add("F2 =" & ComboBox4.Text)
        Else
            Items.Add("F2 =" & ComboBox4.Text)
        End If

        Dim SelectStatement As String = My.SQL.GetSQL("MainSelect2.sql").Replace("W1", CreateWhereStringList(Items.ToArray) & " ")

        ShowStatement(SelectStatement, WebStyles.Button3Style)

    End Sub
    ''' <summary>
    ''' Demoing XML literal and embedded expressions to create a SQL select statement. Same
    ''' issues with button1 code in that we need to use apostrophes to denote a string.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' When done properly this method is fine for small SQL statements of select, insert, update, delete
    ''' but can cause issues via the programmer forgetting things like leaving out apostrophes or using
    ''' apostrophes when not required etc.
    ''' </remarks>
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim StatusFilter As String = "SomeField ="
        Dim FilterOn As String = "SomeValue"
        Dim SelectStatement =
<SQL>
SELECT 
    OrderDate, 
    EnterDate, 
    JobStartDate, 
    JobCompleteDate, 
    LoadDate, 
    OrderID, 
    CI.Customer_Name, 
    JobName, 
    U.Firstname + ' ' + U.Lastname As FullName, 
    Orders.Status 
FROM 
    DoorDept_Orders_Open As Sch 
LEFT JOIN Users As U ON U.login = Orders.FullName 
LEFT JOIN Customer_Information As CI ON Orders.CustomerID = CI.Customer_ID 
WHERE Scheduled = 1 And <%= StatusFilter %>'<%= FilterOn %>' 
ORDER BY LoadDate ASC, EnterDate ASC                
</SQL>.Value

        ShowStatement(SelectStatement, WebStyles.Button4Style)

    End Sub
    ''' <summary>
    ''' An example of using parameterized command where the parameter indicates the value type.
    ''' Best method for doing SQL but when there are variable items in the where clause requires
    ''' more thought.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' You can use cmd.Parameters.AddWithValue also in place of creating parameters as done below.
    ''' The method for parameters below is ideal for working within a loop or for/next
    ''' 
    ''' NOTE: We never even attempt to connect to a database, only create the construct so you can
    ''' follow along.
    ''' </remarks>
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Using cn As New OleDbConnection With {.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb"}
            Using cmd As New OleDbCommand With {.Connection = cn}
                Dim P1 As New OleDbParameter With {.OleDbType = OleDbType.Integer, .ParameterName = "@SomeField"}
                Dim P2 As New OleDbParameter With {.OleDbType = OleDbType.LongVarChar, .ParameterName = "@AnotherField"}

                P1.Value = ComboBox5.Text
                P2.Value = ComboBox6.Text

                cmd.CommandText = My.SQL.GetSQL("MainSelect3.sql")
                cmd.Parameters.AddRange(New OleDbParameter() {P1, P2})
                ShowStatement(cmd.ActualCommandText, WebStyles.Button5Style)
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' Dynamically create a where clause for a select statement using selected rows in DataGridView1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Items =
        (
            From T In CType(bsData.DataSource, DataTable).AsEnumerable
            Where T.Field(Of Boolean)("Process")
            Select T
        ).ToList

        If Items.Count > 0 Then
            Dim Values = (From T In Items Select T.Field(Of Int32)("Identifier")).ToArray
            Dim SelectStatement =
                <T>
                    SELECT * 
                    FROM Categories 
                    WHERE CategoryID IN ( <%= String.Join(",", Values) %>)
                </T>.Value.CollaspeText

            ShowStatement(SelectStatement, WebStyles.Button3Style)

        Else
            MessageBox.Show("Nothing checked")
        End If
    End Sub

    Private Sub Figure4()
        Using cn As New OleDbConnection With
            {
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb"
            }
            Using cmd As New OleDbCommand With {.Connection = cn}
                Dim P1 As New OleDbParameter With
                    {
                        .OleDbType = OleDbType.Integer,
                        .ParameterName = "@SomeField"
                    }
                Dim P2 As New OleDbParameter With
                    {
                        .OleDbType = OleDbType.LongVarChar,
                        .ParameterName = "@AnotherField"
                    }

                P1.Value = ComboBox5.Text
                P2.Value = ComboBox6.Text

                cmd.CommandText = My.SQL.GetSQL("MainSelect3.sql")
                cmd.Parameters.AddRange(New OleDbParameter() {P1, P2})

                cn.Open()
                Dim dt As New DataTable
                dt.Load(cmd.ExecuteReader)
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' Setup UI controls used to work the SQL demos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ComboBox1.DataSource = (From T In Enumerable.Range(1, 20) Select "TEST" & T.ToString).ToList
        ComboBox1.SelectedIndex = 10
        ComboBox2.DataSource = (From T In Enumerable.Range(1, 20) Select CStr(T)).ToList
        ComboBox2.SelectedIndex = 7

        Dim Companies = _
            From line In My.Application.ResourceText("Customers.txt").Split(Environment.NewLine.ToCharArray)
            Where line.Length > 0
                Let Row = line.Split(","c)
            Select New With
              {
                 Key .Identifier = Row(0).RemoveDoubleQuotes,
                 Key .Company = Row(1).RemoveDoubleQuotes
               }

        ' All option is a blank entry, could be whatever you want like All or All names
        Dim allOption = New With {Key .Identifier = "ALL", Key .Company = ""}
        ComboBox3.DataSource = AddOptionForAllCompanies(Companies, allOption).ToList()
        ComboBox3.DisplayMember = "Company"
        ComboBox3.ValueMember = "Identifier"
        ComboBox4.DataSource = (From T In Enumerable.Range(1, 20) Select CStr(T)).ToList
        ComboBox4.SelectedIndex = 3

        'Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory)

        ComboBox5.DataSource = (From T In Enumerable.Range(100, 240) Select CStr(T)).ToList
        ComboBox5.SelectedIndex = 7

        ComboBox6.DataSource = New List(Of String) From {"hallo", "hello", "aloha", "Dia duit", "ya'at'eeh"}
        ComboBox5.SelectedIndex = 1

        LoadDataGridView()

        ' Activate button for OleDb Parameters
        ActiveControl = Button5

    End Sub
    Private Sub LoadDataGridView()
        Dim dt As New DataTable
        dt.Columns.AddRange(New DataColumn() {New DataColumn("Process", GetType(System.Boolean)), New DataColumn("Identifier", GetType(System.Int32)), New DataColumn("Category", GetType(System.String))})
        dt.Rows.Add(New Object() {False, 1, "Beverages"})
        dt.Rows.Add(New Object() {True, 2, "Condiments"})
        dt.Rows.Add(New Object() {True, 3, "Confections"})
        dt.Rows.Add(New Object() {False, 4, "Dairy Products"})
        dt.Rows.Add(New Object() {True, 5, "Grains/Cereals"})
        dt.Rows.Add(New Object() {True, 6, "Meat/Poultry"})
        dt.Rows.Add(New Object() {False, 7, "Produce"})
        dt.Rows.Add(New Object() {True, 8, "Seafood"})

        bsData.DataSource = dt
        DataGridView1.DataSource = bsData
        DataGridView1.Columns("Process").Width = 40
        DataGridView1.Columns("Identifier").Width = 20
        DataGridView1.Columns("Identifier").ReadOnly = True
        DataGridView1.Columns("Category").ReadOnly = True

        DataGridView1.CurrentCell = DataGridView1(2, 0)
    End Sub
    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub frmMainForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString(Me.Text, New System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.SlateGray, 10, -12)
    End Sub
    ''' <summary>
    ''' Sometimes I dislike my Vista theme, today is one of them so I colorize the GroupBoxes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GroupBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox1.Paint, GroupBox2.Paint, GroupBox3.Paint, GroupBox4.Paint
        Dim gb As GroupBox = CType(sender, GroupBox)
        Dim TRec As Rectangle = New Rectangle(0, 0, gb.Width, gb.Height)
        Dim GBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(TRec, Color.LightSteelBlue, Color.LimeGreen, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(GBrush, TRec)
    End Sub

    Private Sub cmdLive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLive.Click
        Dim f As New frmLiveForm

        Try
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try

    End Sub
End Class
