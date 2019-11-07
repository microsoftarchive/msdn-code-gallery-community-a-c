Imports System.IO
Imports OfficeOpenXml
Imports System.Data.SqlClient

Public Class SamplePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CreateXLSXFile(sender As Object, e As EventArgs) Handles btnGenerateXLSX.Click
        GenerateXLSXFile(CreateDataTable())
    End Sub

    Private Sub GenerateXLSXFile(tbl As DataTable)

        Dim excelPackage = New ExcelPackage

        Dim excelWorksheet = excelPackage.Workbook.Worksheets.Add("DemoPage")

        excelWorksheet.Cells("A1").LoadFromDataTable(tbl, True)

        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx")

        Dim stream As MemoryStream = New MemoryStream(excelPackage.GetAsByteArray())

        Response.OutputStream.Write(stream.ToArray(), 0, stream.ToArray().Length)

        Response.Flush()

        Response.Close()

    End Sub

    Private Function CreateDataTable() As DataTable

        Dim dataTable As New DataTable("DT")
        Dim conString As String = "Data Source=.;Initial Catalog=Sample.CreateXLSx.Database;UID=ExcelDemoUser;Password=password"

        Dim con = New SqlConnection(conString)
        con.Open()

        Dim sql As String = "SELECT * FROM country;"
        Dim cmd As New SqlCommand(sql, con)

        Dim adaptor = New SqlDataAdapter

        adaptor.SelectCommand = cmd
        adaptor.Fill(dataTable)
        con.Close()

        Return dataTable


    End Function

    


End Class