'
' Needed for several properties setters 
'
Imports DOS = DocumentFormat.OpenXml.Spreadsheet
Imports SpreadsheetLight
Imports SpreadsheetLight.Drawing
''' <summary>
''' Sample methods for common Excel operations. There are so many more
''' to explore by examining the help file and reviewing sample code yet
''' the sample code is all C#.
''' </summary>
Public Class Operations
    ''' <summary>
    ''' date used to show in DataGridView which in turn gets exported to Excel
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadCustomersFromXml() As DataTable
        Dim ds As New DataSet
        ds.ReadXmlSchema(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xsd"))
        ds.ReadXml(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xml"))
        ds.Tables("Customer").Columns.Add(New DataColumn With {.ColumnName = "MyDate", .DataType = GetType(DateTime), .DefaultValue = Now})

        Dim counter As Integer = 1
        For Each row As DataRow In ds.Tables("Customer").Rows
            row.SetField(Of DateTime)("MyDate", row.Field(Of DateTime)("MyDate").AddDays(counter))
            counter += 1
        Next

        Return ds.Tables("Customer")

    End Function
    Private theExportFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExportSample.xlsx")
    Public ReadOnly Property ExportFileName As String
        Get
            Return theExportFileName
        End Get
    End Property
    Private theImportFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sample2.xlsx")
    Public ReadOnly Property ImportFileName As String
        Get
            Return theImportFileName
        End Get
    End Property
    Private theAddDeleteRenameFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AddDeleteRename.xlsx")
    Public ReadOnly Property AddDeleteRenameFileName As String
        Get
            Return theAddDeleteRenameFileName
        End Get
    End Property
    Private theException As Exception
    Public ReadOnly Property Exception As Exception
        Get
            Return theException
        End Get
    End Property
    ''' <summary>
    ''' Basic export of DataTable to a worksheet
    ''' </summary>
    ''' <param name="table"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' How did I figure this out? 
    ''' Used Google to search for operations I wanted.
    ''' Total time to write 99.99% of code, 30 minutes first time
    ''' How long to do the column header (LOL), 15 minutes on top of the 30 to figure out the colors.
    ''' Why 15 minutes, because I was exploring and having fun.
    ''' </remarks>
    Public Function ExportDataTable(ByVal table As DataTable) As Boolean
        Try
            Using sl As New SLDocument(ExportFileName)
                Dim startRow As Integer = 1
                Dim startColumn As Integer = 1

                ' redundent
                sl.SelectWorksheet("Sheet1")

                ' clear cells if this is ran more than once and the row or column count changes
                sl.ClearCellContent()

                ' import DataTable with column headers
                sl.ImportDataTable(startRow, startColumn, table, True)

                ' set the Date style
                Dim dateStyle = sl.CreateStyle
                dateStyle.FormatCode = "mm-dd-yyyy"

                sl.SetCellStyle(2, table.Columns("MyDate").Ordinal + 1, table.Rows.Count - 1, table.Columns("MyDate").Ordinal + 1, dateStyle)

                ' set the column header stype
                Dim headerSyle = sl.CreateStyle
                headerSyle.Font.FontColor = Color.White
                headerSyle.Font.Strike = False
                headerSyle.Fill.SetPattern(DOS.PatternValues.Solid, Color.Green, Color.White)
                headerSyle.Font.Underline = DOS.UnderlineValues.None
                headerSyle.Font.Bold = True
                headerSyle.Font.Italic = False
                sl.SetCellStyle(1, 1, 1, table.Columns.Count, headerSyle)

                ' auto-fit the columns
                sl.AutoFitColumn(1, table.Columns.Count)

                ' save back to the Excel file - see also sl.SaveAs
                sl.Save()

            End Using
            Return True
        Catch ex As Exception
            theException = ex
            Return False
        End Try
    End Function
    ''' <summary>
    ''' This may appear simple yet it's an important sample as it shows
    ''' how to write to one row below the last used row in a column which is
    ''' not simple with any angle used e.g. Excel automation for example.
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="DateColumn"></param>
    ''' <param name="TimeColumn"></param>
    ''' <param name="theDate"></param>
    ''' <returns></returns>
    Public Function WriteDateAndTime(ByVal FileName As String, ByVal DateColumn As String, ByVal TimeColumn As String, ByVal theDate As Date) As Boolean

        Try
            '
            ' No check to see if sheet exists
            '
            Using demoSheet As New SLDocument(FileName)
                demoSheet.SelectWorksheet("Demo")
                Dim stats As SLWorksheetStatistics = demoSheet.GetWorksheetStatistics
                Dim emptyRowIndex As Integer = 0

                For xRow As Integer = 1 To stats.EndRowIndex
                    emptyRowIndex = xRow + 1
                    If Not demoSheet.HasCellValue($"{DateColumn}{xRow}") Then
                        Exit For
                    End If
                Next
                Dim dateColIndex = SLConvert.ToColumnIndex(DateColumn)
                Dim timeColIndex = SLConvert.ToColumnIndex(DateColumn)
                Dim dateStyle = demoSheet.CreateStyle

                ' note in Excel this is seen as custom format
                dateStyle.FormatCode = "mm-dd-yyyy"

                ' it's possible that we have a virgin work sheet thus no rows exists.
                If emptyRowIndex = 0 Then
                    emptyRowIndex = 1
                End If

                ' next four methods return a boolean if you like to check that the set methods were successful
                Dim success1 As Boolean = demoSheet.SetCellValue($"{DateColumn}{emptyRowIndex}", theDate)
                Dim success2 As Boolean = demoSheet.SetCellStyle(emptyRowIndex, dateColIndex, emptyRowIndex, dateColIndex, dateStyle)
                Dim success3 As Boolean = demoSheet.SetCellValue($"{TimeColumn}{emptyRowIndex}", theDate.ToShortTimeString)
                demoSheet.AutoFitColumn(DateColumn)

                demoSheet.Save()

                Return success1 AndAlso success2 AndAlso success3

            End Using

        Catch ex As Exception
            theException = ex
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pFileName">Valid Excel .xlsx file to read</param>
    ''' <param name="pSheetName">Existing Worksheet in pFileName</param>
    ''' <param name="pColumn">Column name e.g. A</param>
    ''' <param name="pHasHeader">Indicates first row has column names</param>
    ''' <returns>
    ''' DataTable with two columns, first column indicates the row index data
    ''' was read from while the second column is the actual data.
    ''' </returns>
    ''' <remarks>
    ''' See method below also
    ''' </remarks>
    Public Function StackOverFlowExample1(ByVal pFileName As String, ByVal pSheetName As String, ByVal pColumn As String, Optional ByVal pHasHeader As Boolean = True) As DataTable

        Dim startIndex As Integer = 0
        If pHasHeader Then
            startIndex = 1
        End If

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn With {.ColumnName = "RowIndex", .DataType = GetType(Integer)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "StringData", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "DoubleData", .DataType = GetType(Double)})

        Using sl As New SLDocument(pFileName, pSheetName)
            Dim stats As SLWorksheetStatistics = sl.GetWorksheetStatistics
            Dim iStartColumnIndex = SLConvert.ToColumnIndex(pColumn)

            Dim doubleValue As Double = 0
            Dim isDouble As Boolean = False

            For row = stats.StartRowIndex + startIndex To stats.EndRowIndex
                If Double.TryParse(sl.GetCellValueAsString(row, iStartColumnIndex), doubleValue) Then
                    dt.Rows.Add(New Object() {row - 1, sl.GetCellValueAsString(row, iStartColumnIndex), doubleValue})
                Else
                    dt.Rows.Add(New Object() {row - 1, sl.GetCellValueAsString(row, iStartColumnIndex)})
                End If
            Next

        End Using

        Return dt

    End Function
    ''' <summary>
    ''' Variant of the method above
    ''' </summary>
    ''' <param name="pFileName">Valid Excel .xlsx file to read</param>
    ''' <param name="pSheetName">Existing Worksheet in pFileName</param>
    ''' <param name="pHasHeader">Indicates first row has column names</param>
    ''' <returns></returns>
    Public Function StackOverFlowExample2(ByVal pFileName As String, ByVal pSheetName As String, Optional ByVal pHasHeader As Boolean = True) As DataTable

        Dim startIndex As Integer = 0
        If pHasHeader Then
            startIndex = 1
        End If

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn With {.ColumnName = "RowIndex", .DataType = GetType(Integer)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Code", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "DoubleData", .DataType = GetType(Double)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "StringData", .DataType = GetType(String)})

        Using sl As New SLDocument(pFileName, pSheetName)
            Dim stats As SLWorksheetStatistics = sl.GetWorksheetStatistics
            Dim iCodeColumnIndex = SLConvert.ToColumnIndex("A")
            Dim iDoubleColumnIndex = SLConvert.ToColumnIndex("B")

            Dim doubleValue As Double = 0
            Dim codeValue As String = ""
            Dim isDouble As Boolean = False

            For row = stats.StartRowIndex + startIndex To stats.EndRowIndex
                If Double.TryParse(sl.GetCellValueAsString(row, iDoubleColumnIndex), doubleValue) Then
                    dt.Rows.Add(New Object() {row - 1, sl.GetCellValueAsString(row, iCodeColumnIndex), doubleValue})
                Else
                    dt.Rows.Add(New Object() {row - 1, sl.GetCellValueAsString(row, iCodeColumnIndex), Nothing, sl.GetCellValueAsString(row, iDoubleColumnIndex)})
                End If
            Next

        End Using

        Return dt

    End Function

    Public Function BuildImportTable() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn With {.ColumnName = "Id", .DataType = GetType(Integer)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "CompanyName", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "ContactName", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "ContactTitle", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Street", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "City", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "PostalCode", .DataType = GetType(Integer)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Country", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Phone", .DataType = GetType(String)})

        Return dt
    End Function
    ''' <summary>
    ''' Read a Worksheet into a DataTable
    ''' </summary>
    ''' <returns></returns>
    Public Function ImportFromExcel() As DataTable

        Dim dt As DataTable = BuildImportTable()

        ' read a specific sheet when opening the excel file
        Using sl As New SLDocument(ImportFileName, "Customers")

            Dim stats As SLWorksheetStatistics = sl.GetWorksheetStatistics

            Dim iStartColumnIndex = stats.StartColumnIndex

            For row = stats.StartRowIndex + 1 To stats.EndRowIndex

                dt.Rows.Add(
                    sl.GetCellValueAsInt32(row, iStartColumnIndex),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 1),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 2),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 3),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 4),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 5),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 6),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 7),
                    sl.GetCellValueAsString(row, iStartColumnIndex + 8)
                    )

            Next

        End Using

        Return dt

    End Function
    Public Sub OpenExcelSimple(ByVal FileName As String, ByVal SheetName As String)
        Using sl As New SLDocument(FileName, SheetName)
            Dim sb As New Text.StringBuilder
            Dim Cells As String() = {"A1", "B2", "B3", "B4"}
            For Each cell As String In Cells
                sb.AppendLine(String.Format("{0} = '{1}'", cell, sl.GetCellValueAsString(cell)))
            Next
        End Using
    End Sub


    ''' <summary>
    ''' demonstrate how to get used columns in the format a a letter rather than an integer
    ''' </summary>
    ''' <returns></returns>
    Public Function UsedCellsInCustomerWorkSheet() As String()
        Using sl As New SLDocument(ImportFileName, "Customers")
            Dim stats As SLWorksheetStatistics = sl.GetWorksheetStatistics
            Dim ColumnNames As IEnumerable(Of String) = Enumerable.Range(1, stats.EndColumnIndex).Select(Function(cellIndex) SLConvert.ToColumnName(cellIndex))
            Return ColumnNames.ToArray
        End Using
    End Function
    ''' <summary>
    ''' Get Column names for ImportFileName, sheet Customers
    ''' </summary>
    ''' <returns></returns>
    Public Function ColumnHeaders() As List(Of String)
        Using sl As New SLDocument(ImportFileName, "Customers")
            Dim stats As SLWorksheetStatistics = sl.GetWorksheetStatistics
            Return Enumerable.Range(1, stats.EndColumnIndex).Select(Function(cellIndex) sl.GetCellValueAsString($"{SLConvert.ToColumnName(cellIndex)}1")).ToList
        End Using
    End Function
    ''' <summary>
    ''' Get column headers for a worksheet
    ''' </summary>
    ''' <param name="FileName">Valid Excel 2007+ file</param>
    ''' <param name="SheetName">Existing Worksheet in FileName</param>
    ''' <returns></returns>
    Public Function ColumnHeaders(ByVal FileName As String, ByVal SheetName As String) As List(Of String)
        Using sl As New SLDocument(FileName, SheetName)
            Dim stats As SLWorksheetStatistics = sl.GetWorksheetStatistics
            Return Enumerable.Range(1, stats.EndColumnIndex).Select(Function(cellIndex) sl.GetCellValueAsString($"{SLConvert.ToColumnName(cellIndex)}1")).ToList
        End Using
    End Function
    Public UsedRowsColumns As Dictionary(Of String, String)
    Public Function GetInformation() As Boolean
        UsedRowsColumns = New Dictionary(Of String, String)()
        Using sl As New SLDocument(ImportFileName)
            Dim sheetNames = sl.GetSheetNames(False)
            For Each sheetName As String In sheetNames
                If sl.SelectWorksheet(sheetName) Then
                    Dim stats As SLWorksheetStatistics = sl.GetWorksheetStatistics()
                    UsedRowsColumns.Add(sheetName, $"{stats.EndColumnIndex.ExcelColumnName()}:{stats.EndRowIndex}")
                End If
            Next
            Return UsedRowsColumns.Count = sheetNames.Count
        End Using
    End Function
    Public Function CanOpen(ByVal pFileName As String) As Boolean
        Try
            Using sl As New SLDocument(pFileName)
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function SheetNames() As List(Of String)
        Using sl As New SLDocument(AddDeleteRenameFileName)
            Return sl.GetSheetNames(False)
        End Using
    End Function
    ''' <summary>
    ''' Get Sheetnames for a valid Excel 2007+ file
    ''' </summary>
    ''' <param name="pFileName">Existing file</param>
    ''' <returns></returns>
    Public Function SheetNames(ByVal pFileName As String) As List(Of String)
        Using sl As New SLDocument(pFileName)
            Return sl.GetSheetNames(False)
        End Using
    End Function
    Public Function SheetExists(ByVal pSheetName As String) As Boolean
        Using sl As New SLDocument(AddDeleteRenameFileName)
            Return sl.GetSheetNames(False).Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower)
        End Using
    End Function
    ''' <summary>
    ''' Determine if a worksheet exists in a valid Excel 2007+ file
    ''' </summary>
    ''' <param name="pFileName">Existing file</param>
    ''' <param name="pSheetName">Sheet to check</param>
    ''' <returns></returns>
    Public Function SheetExists(ByVal pFileName As String, ByVal pSheetName As String) As Boolean
        Using sl As New SLDocument(pFileName)
            Return sl.GetSheetNames(False).Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower)
        End Using
    End Function
    ''' <summary>
    ''' Model for adding a new worksheet to an existing file  (not file name is hard-coded)
    ''' </summary>
    ''' <param name="pSheetName"></param>
    ''' <returns></returns>
    Public Function AddNewSheet(ByVal pSheetName As String) As Boolean
        Using sl As New SLDocument(AddDeleteRenameFileName)
            If Not sl.GetSheetNames(False).Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower) Then
                sl.AddWorksheet(pSheetName)
                sl.Save()
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    ''' <summary>
    ''' Model for removing a worksheet (note file name is hard-coded)
    ''' </summary>
    ''' <param name="pSheetName"></param>
    ''' <returns></returns>
    Public Function RemoveWorkSheet(ByVal pSheetName As String) As Boolean
        Using sl As New SLDocument(AddDeleteRenameFileName)
            Dim workSheets = sl.GetSheetNames(False)
            If workSheets.Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower) Then
                '
                ' The current worksheet can not be renamed, we check for this and change
                ' the current worksheet if it's the current worksheet.
                '
                If workSheets.Count > 1 Then
                    Dim sheet = sl.GetSheetNames.FirstOrDefault(Function(sName) sName.ToLower <> pSheetName.ToLower)
                    sl.SelectWorksheet(sl.GetSheetNames.FirstOrDefault(Function(sName) sName.ToLower <> pSheetName.ToLower))
                ElseIf workSheets.Count = 1 Then
                    Throw New Exception("Can not delete the sole worksheet")
                End If

                sl.DeleteWorksheet(pSheetName)
                sl.Save()

                Return True
            Else
                Return False
            End If
        End Using

    End Function
    Public Function RemoveWorkSheet(ByVal pExcelFileName As String, ByVal pSheetName As String) As Boolean
        Using sl As New SLDocument(pExcelFileName)
            Dim workSheets = sl.GetSheetNames(False)
            If workSheets.Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower) Then
                '
                ' The current worksheet can not be renamed, we check for this and change
                ' the current worksheet if it's the current worksheet.
                '
                If workSheets.Count > 1 Then
                    Dim sheet = sl.GetSheetNames.FirstOrDefault(Function(sName) sName.ToLower <> pSheetName.ToLower)
                    sl.SelectWorksheet(sl.GetSheetNames.FirstOrDefault(Function(sName) sName.ToLower <> pSheetName.ToLower))
                ElseIf workSheets.Count = 1 Then
                    Throw New Exception("Can not delete the sole worksheet")
                End If

                sl.DeleteWorksheet(pSheetName)
                sl.Save()

                Return True
            Else
                Return False
            End If
        End Using

    End Function

    ''' <summary>
    ''' 
    ''' Rename a worksheet
    ''' </summary>
    ''' <param name="pSheetName">Current worksheet name</param>
    ''' <param name="pNewWorkSheetName">New worksheet name</param>
    ''' <returns></returns>
    Public Function RenameWorkSheet(ByVal pSheetName As String, ByVal pNewWorkSheetName As String) As Boolean
        Using sl As New SLDocument(AddDeleteRenameFileName)
            If sl.GetSheetNames(False).Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower) Then

                sl.RenameWorksheet(pSheetName, pNewWorkSheetName)
                sl.Save()
                Return True
            Else
                Return False
            End If
        End Using

    End Function
    ''' <summary>
    ''' Rename a worksheet
    ''' </summary>
    ''' <param name="pFileName">Existing file</param>
    ''' <param name="pSheetName">Existing sheet</param>
    ''' <param name="pNewWorkSheetName">New sheet name</param>
    ''' <returns></returns>
    Public Function RenameWorkSheet(ByVal pFileName As String, ByVal pSheetName As String, ByVal pNewWorkSheetName As String) As Boolean
        Using sl As New SLDocument(pFileName)
            If sl.GetSheetNames(False).Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower) Then

                sl.RenameWorksheet(pSheetName, pNewWorkSheetName)
                sl.Save()
                Return True
            Else
                Return False
            End If
        End Using

    End Function
    ''' <summary>
    ''' Simple method to insert data into row 1, pushing existing data down one row.
    ''' By changing the parameters to InsertRow you can insert in another location.
    ''' </summary>
    ''' <param name="pFileName">Existing file</param>
    ''' <param name="pSheetName">Existing sheet</param>
    ''' <param name="pCellValues">a list with three items</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Of course you can use different data then a List(Of String) e.g. a DataRow, a item
    ''' in a List(Of T) are some examples.
    ''' </remarks>
    Public Function InsertNewRow(ByVal pFileName As String, ByVal pSheetName As String, ByVal pCellValues As List(Of String)) As Boolean
        Try
            Using sl As New SLDocument(pFileName, pSheetName)
                sl.InsertRow(1, 1)
                sl.SetCellValue("A1", pCellValues(0))
                sl.SetCellValue("B1", pCellValues(1))
                sl.SetCellValue("C1", pCellValues(2))
                sl.Save()
                Return True
            End Using
        Catch ex As Exception
            theException = ex
            Return False
        End Try
    End Function
    Public Function InsertImage(ByVal pExcelFileName As String, pSheetName As String, pImageFileName As String) As Boolean
        Try
            Using sl As New SLDocument(pExcelFileName)
                Dim sheetNames = sl.GetSheetNames(False)
                If sheetNames.FirstOrDefault(Function(sheet) sheet.ToLower = pSheetName.ToLower) IsNot Nothing Then
                    If sheetNames.Contains("Sheet1") Then
                        sl.SelectWorksheet("Sheet1")
                    Else
                        theException = New RemoveSheetException("Can not remove current worksheet")
                        Return False
                    End If

                    sl.DeleteWorksheet(pSheetName)
                    sl.AddWorksheet(pSheetName)

                End If

                sl.SelectWorksheet(pSheetName)

                Dim image As SLPicture = New SLPicture(pImageFileName)
                image.SetPosition(5.5, 0.5)
                sl.InsertPicture(image)

                sl.Save()
            End Using
            Return True
        Catch ex As Exception
            theException = ex
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Import simple tab delimited text file where all columns are strings.
    ''' If Sheet1 exists, remove it.
    ''' Set several column widths
    ''' </summary>
    ''' <param name="pTextFileName">Existing file</param>
    ''' <param name="pExcelFileName">Excel file name which exists</param>
    ''' <param name="pSheetName">Desired sheet name</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Be sure to check out the various options for formatting data types
    ''' other than strings in the SpreadSheetLight help file under SLTextImportOptions
    ''' </remarks>
    Public Function ImportTabDelimitedTextFile(ByVal pTextFileName As String, pExcelFileName As String, ByVal pSheetName As String) As Boolean
        Try
            Using sl As New SLDocument(pExcelFileName)
                Dim sheets = sl.GetSheetNames(False)
                If sheets.Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower) Then
                    sl.SelectWorksheet(pSheetName)
                    sl.ClearCellContent()
                Else
                    sl.AddWorksheet(pSheetName)
                End If

                Dim tio As SLTextImportOptions = New SLTextImportOptions

                sl.ImportText(pTextFileName, "A1", tio)

                ' demoing setting column widths
                sl.AutoFitColumn("A")
                sl.SetColumnWidth(2, 5)

                ' do not need Sheet1
                If sheets.FirstOrDefault(Function(sheetName) sheetName.ToLower = "sheet1") IsNot Nothing Then
                    If Not pSheetName.ToLower = "sheet1" Then
                        sl.DeleteWorksheet("Sheet1")
                    End If
                End If

                sl.Save()

                Return True
            End Using
        Catch ex As Exception
            theException = ex
            Return False
        End Try
        Return True
    End Function
End Class
