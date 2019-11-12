Option Strict On
Option Infer On

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices
''' <summary>
''' The code within this file concentrates on how to open an existing Excel file, 
''' select a worksheet, close the file and cleanup all objects used to open and 
''' select a worksheet. Any code beyond this is here to prove we opened a file, 
''' select a worksheet.
''' 
''' For the majority of routines a sheet name is passed in and we loop thru the 
''' Worksheets interface to select a worksheet. This requires more code then 
''' selecting a worksheet by natural order using an integer to select a worksheet. 
''' More likely than not a sheet name is more common than ordinal position especially 
''' since sheets can be moved by a user at will.
''' </summary>
''' <remarks></remarks>
Module OpenWorkSheets
    ''' <summary>
    ''' Opens a valid Excel file, reads A1 cell from Sheet name passed
    ''' </summary>
    ''' <param name="FileName">Excel file to open</param>
    ''' <param name="SheetName">Sheet to read</param>
    ''' <remarks>
    ''' 1. Properly cleans up objects w/o call to GC
    ''' 2. Does not attempt to create the file first.
    ''' </remarks>
    Public Sub OpenExcel(ByVal FileName As String, ByVal SheetName As String, ByVal CellAddress As String)

        If IO.File.Exists(FileName) Then

            Dim Proceed As Boolean = False

            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing
            Dim xlCells As Excel.Range = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count
                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then
                    Proceed = True
                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing

            Next
            If Proceed Then
                xlCells = xlWorkSheet.Range(CellAddress)

                MessageBox.Show(String.Format("{0} = '{1}'", CellAddress, xlCells.Value))
            Else
                MessageBox.Show(SheetName & " not found.")
            End If


            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlCells)
            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)
        Else
            MessageBox.Show("'" & FileName & "' not located. Try one of the write examples first.")
        End If
    End Sub
    ''' <summary>
    ''' Read three cells into a StringBuilder. Lesson here is how
    ''' we work with cell references.
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="SheetName"></param>
    ''' <remarks></remarks>
    Public Sub OpenExcel(ByVal FileName As String, ByVal SheetName As String)

        If IO.File.Exists(FileName) Then

            Dim Proceed As Boolean = False
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing
            Dim xlCells As Excel.Range = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets


            '
            ' For/Next finds our sheet
            '
            For x As Integer = 1 To xlWorkSheets.Count
                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then
                    Proceed = True
                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing

            Next
            If Proceed Then
                Dim sb As New System.Text.StringBuilder

                Dim Cells As String() = {"B2", "B3", "B4"}
                For Each cell In Cells
                    xlCells = xlWorkSheet.Range(cell)
                    sb.AppendLine(String.Format("{0} = '{1}'", cell, xlCells.Value))
                    ReleaseComObject(xlCells)
                Next
                MessageBox.Show(sb.ToString)
            Else
                MessageBox.Show(SheetName & " not found.")
            End If


            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlCells)
            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)
        Else
            MessageBox.Show("'" & FileName & "' not located. Try one of the write examples first.")
        End If
    End Sub
    ''' <summary>
    ''' Open Excel file, select sheet by ordinal position
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="SheetIndex">Ordinal position inside of a workbook</param>
    ''' <remarks>
    ''' The ordinal value needs to have been retrived using Automation or OpenXML methods,
    ''' not by OleDb. Both automation and OpenXml return sheets by natural order, for instance,
    ''' we have the following sheets
    ''' 
    ''' Sheet2
    ''' Sheet1
    ''' Sheet3
    ''' 
    ''' OleDb returns Sheet1, Sheet2, Sheet3 while automation and OpenXml returns them as shown
    ''' above.
    ''' </remarks>
    Public Sub OpenSheetByIndex(ByVal FileName As String, ByVal SheetIndex As Integer)

        If IO.File.Exists(FileName) Then

            Dim Proceed As Boolean = False

            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing
            Dim xlCells As Excel.Range = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            xlWorkSheet = CType(xlWorkSheets(SheetIndex), Excel.Worksheet)
            Dim sb As New System.Text.StringBuilder

            Dim Cells As String() = {"B2", "B3", "B4"}
            For Each cell In Cells
                xlCells = xlWorkSheet.Range(cell)
                sb.AppendLine(String.Format("{0} = '{1}'", cell, xlCells.Value))
                ReleaseComObject(xlCells)
            Next
            MessageBox.Show(sb.ToString)

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlCells)
            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)
        Else
            MessageBox.Show("'" & FileName & "' not located. Try one of the write examples first.")
        End If
    End Sub
    ''' <summary>
    ''' Get used rows for a specific worksheet
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="SheetName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Includes empty rows
    ''' </remarks>
    Public Function UsedRows(ByVal FileName As String, ByVal SheetName As String) As Integer
        Dim RowsUsed As Integer = -1

        If IO.File.Exists(FileName) Then
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count
                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then
                    Dim xlCells As Excel.Range = Nothing
                    xlCells = xlWorkSheet.Cells

                    RowsUsed = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row

                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlCells)
                    xlCells = Nothing

                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing

            Next

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)
        Else
            Throw New Exception("'" & FileName & "' not found.")
        End If

        Return RowsUsed

    End Function
    ''' <summary>
    ''' Demonstrates opening an Excel file, closes and release memory 
    ''' w/o calling the GC for all objects except one which is commented
    ''' below in the code. The idea here is that say for whatever reason
    ''' you do not have time to properly dispose of memory this is an 
    ''' option.
    ''' 
    ''' While open write data to the sheet name passed in.
    ''' 
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="SheetName"></param>
    ''' <remarks></remarks>
    Public Sub OpenExcelWriteData(ByVal FileName As String, ByVal SheetName As String)
        Dim Proceed As Boolean = False

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBooks As Excel.Workbooks = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim xlWorkSheets As Excel.Sheets = Nothing
        Dim xlRange1 As Excel.Range = Nothing
        Dim xlInterior As Excel.Interior = Nothing
        Dim xlColumns As Excel.Range = Nothing

        xlApp = New Excel.Application
        xlApp.DisplayAlerts = False
        xlWorkBooks = xlApp.Workbooks
        xlWorkBook = xlWorkBooks.Open(FileName)

        xlApp.Visible = False

        xlWorkSheets = xlWorkBook.Sheets

        For x As Integer = 1 To xlWorkSheets.Count
            xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

            If xlWorkSheet.Name = SheetName Then
                Proceed = True
                Exit For
            End If

            Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
            xlWorkSheet = Nothing

        Next

        If Proceed Then
            Dim DictCellData As New Dictionary(Of String, String) _
                From
                    {
                        {"A1", "Month"},
                        {"A2", "January"},
                        {"A3", "February"},
                        {"A4", "March"},
                        {"A5", "April"},
                        {"B1", "Money Spent"},
                        {"B2", "1000.00"},
                        {"B3", "1500.00"},
                        {"B4", "1200.00"},
                        {"B5", "1100.00"}
                    }

            ' Write cell, dispose object, repeat...
            For Each Item In DictCellData
                xlRange1 = xlWorkSheet.Range(Item.Key)
                xlRange1.Value = Item.Value
                Marshal.FinalReleaseComObject(xlRange1)
                xlRange1 = Nothing
            Next

            xlRange1 = xlWorkSheet.Range("A6")
            xlRange1.Value = "Total Expense"
            xlRange1.AddComment("This is the actual total expense.")

            Marshal.FinalReleaseComObject(xlRange1)
            xlRange1 = Nothing

            xlRange1 = xlWorkSheet.Range("A7")
            xlRange1.Value = "Average Expense"
            Marshal.FinalReleaseComObject(xlRange1)
            xlRange1 = Nothing

            xlRange1 = xlWorkSheet.Range("B6")
            xlRange1.Formula = "=Sum(B2:B5)"
            Marshal.FinalReleaseComObject(xlRange1)
            xlRange1 = Nothing

            xlRange1 = xlWorkSheet.Range("B7")
            xlRange1.Formula = "=Average(B2:B5)"
            Marshal.FinalReleaseComObject(xlRange1)
            xlRange1 = Nothing

            xlRange1 = xlWorkSheet.Range("A1:B1,A6:A7")
            xlInterior = xlRange1.Interior
            xlInterior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

            Dim TheFont = xlRange1.Font

            TheFont.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            TheFont.Name = "Tahoma"
            TheFont.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
            TheFont.Bold = True

            Marshal.FinalReleaseComObject(TheFont)
            TheFont = Nothing

            xlRange1 = xlWorkSheet.Range("B2:B7")
            xlRange1.NumberFormat = "$#,##0.00"

            ' ******************************************************************
            ' An example of moving past tunneling and only calling the GC
            ' for one object. This can be avoided but wanted to show one
            ' example of calling the GC surrounded by other objects that
            ' need not call the GC.
            ' ******************************************************************
            xlColumns = CType(xlRange1.Columns("A:B"), Excel.Range)
            xlColumns.EntireColumn.AutoFit()
            releaseObject(xlColumns, True)

            Marshal.FinalReleaseComObject(xlRange1)
            xlRange1 = Nothing

            xlWorkSheet.SaveAs(FileName)
        Else
            ' IMPORTANT NOTE
            ' For production throw an exception, for demoing a message
            ' This demo the only way the sheet does not exists if someone
            ' really tried to mess with this code outside with MS-Excel.
            '
            MessageBox.Show(SheetName & " not located.")
        End If

        xlWorkBook.Close()
        xlApp.UserControl = True
        xlApp.Quit()

        ReleaseComObject(xlInterior)
        ReleaseComObject(xlRange1)
        ReleaseComObject(xlWorkSheets)
        ReleaseComObject(xlWorkSheet)
        ReleaseComObject(xlWorkBook)
        ReleaseComObject(xlWorkBooks)
        ReleaseComObject(xlApp)
    End Sub
End Module
