Option Strict On
Option Infer On

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices

Module CreateFileCode
    Public Sub CreateFileIfMissing(ByVal FileName As String, ByVal ShowMessageBox As Boolean)

        If Not IO.File.Exists(FileName) Then

            If ShowMessageBox Then
                MessageBox.Show("Creating '" & FileName & "'")
            End If

            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False

            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Add()

            xlWorkBook.SaveAs(FileName)

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            If Not xlWorkBook Is Nothing Then
                Marshal.FinalReleaseComObject(xlWorkBook)
                xlWorkBook = Nothing
            End If

            If Not xlWorkBooks Is Nothing Then
                Marshal.FinalReleaseComObject(xlWorkBooks)
                xlWorkBooks = Nothing
            End If

            If Not xlApp Is Nothing Then
                Marshal.FinalReleaseComObject(xlApp)
                xlApp = Nothing
            End If
            If ShowMessageBox Then
                MessageBox.Show("'" & FileName & "' has been created.")
            End If

            Dim Info As New ExcelInfo(ExcelFileName)

            If Info.GetInformation Then
                Dim Sheets = Info.Sheets
                ' Moving from Sheet3 to Sheet1 is done because we want Sheet1 to be the Active Worksheet
                ' when this file is opened by a user via Excel.
                Sheets.Reverse()
                For Each sheet In Sheets
                    OpenExcelWriteData(ExcelFileName, sheet)
                Next
            End If
        End If
    End Sub
End Module
