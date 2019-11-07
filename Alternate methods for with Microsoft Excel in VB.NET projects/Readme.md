# Alternate methods for with Microsoft Excel in VB.NET projects
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Excel
- Microsoft Office Excel 2007
- VB.Net
- Excel 2010
- export to excel
- Excel 2013
- SpreadsheetLight
## Topics
- Excel
- Excel Automation
- Class Library
- Generate Excel Workbook
- Third Party Libraries
## Updated
- 03/01/2018
## Description

<h1>Building the Sample</h1>
<p><span style="font-size:small"><a href="http://spreadsheetlight.com/">SpreadSheet library</a> has a dependency on a NugGet package DocumentFormat.OpenXml where when downloaded from NuGet installs the lastest version. For SpreadSheetLight to work select version
 2.5.0.&nbsp;</span></p>
<p><span style="font-size:small">For the included solution first thing to do is right click on the Solution and select &quot;restore NuGet Packages&quot; followed by cleaning then rebuilding the solution.</span></p>
<p><span style="font-size:small">There is one form set as the main form. Each form has a clearly defined name, to try out the code go into project properties and change the startup form, rebuild/run.</span></p>
<p><span style="font-size:small"><img id="173889" src="173889-openxml.jpg" alt="" width="335" height="147"><br>
</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">This code sample provides an alternate from Excel automation and OleDb methods for working with Excel 2007 format files and does not work with the older format (.xls). Although the code samples are desktop based, they can be
 used for web applications also.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small">Just about every developer at one time or another has a requirement to export, import data from various sources. A common examples</span></p>
<ul>
<li><span style="font-size:small">Export DataGridView data to Excel WorkSheet</span>
</li><li><span style="font-size:small">Import Excel WorkSheet data to another source such as a DataTable or database table.</span>
</li><li><span style="font-size:small">Insert new data into a WorkSheet</span> </li><li><span style="font-size:small">Delete existing data from a WorkSheet</span> </li><li><span style="font-size:small">Edit existing data from a WorkSheet (which means one needs to locate existing data).</span>
</li></ul>
<p><span style="font-size:small">Things to consider when looking at soultions</span></p>
<ul>
<li><span style="font-size:small">Will formatting of cells be required</span> </li><li><span style="font-size:small">Is there requirements to add/remove/rename WorkSheets</span>
</li><li><span style="font-size:small">Will images and charts need to be considered</span>
</li></ul>
<p><span style="font-size:small">The above considerations if needed will mean using OleDb methods are not viable as you can not format cells, remove WorkSheets or work with images and charts or formulas.</span></p>
<p><span style="font-size:small">Must at this point will look towards Excel automation which can handle all those considerations yet comes at a price and the prices are.</span></p>
<ul>
<li><span style="font-size:small">Writing a good deal of code where the path to compete a task is daunting because there are no great examples on the web.</span>
</li><li><span style="font-size:small">Most developers never consider (until it smacks them in the face) disposal of objects used to work with Excel.&nbsp;Although this is about VB.NET I direct you to my
<a href="https://code.msdn.microsoft.com/Excel-patterns-for-c8df167d?redir=0">code sample</a> on this topic for C# and one of my VB.NET
<a href="https://code.msdn.microsoft.com/Basics-of-using-Excel-4453945d?redir=0">
code samples</a> which uses pretty much the same pattern, another <a href="https://code.msdn.microsoft.com/Excel-and-OleDb-basics-to-95adc5a1?redir=0">
code sample</a> (VB.NET and C#) for working with OleDb which goes along with the first set of bullets.</span>
</li></ul>
<p><span style="font-size:small">With the above in mind, I would suggest the following options</span></p>
<ul>
<li><span style="font-size:small">Consider using a paid third party library dedicated to working with Excel where most don't require Excel to be installed such as
<a href="https://www.aspose.com/products/cells?gclid=CjwKEAjwja_JBRD8idHpxaz0t3wSJAB4rXW5k-edQUYWFrcdaHk22N6mSd3udB-llnVR9bAG3fPoURoChLTw_wcB">
Aspose Cells</a>, <a href="https://www.gemboxsoftware.com/">GemBox</a>, or <a href="https://www.nuget.org/packages/EPPlus/">
EPPlus</a>. All these libraries are pay to use.</span> </li><li><span style="font-size:small">Another option that is no cost, <a href="https://msdn.microsoft.com/en-us/library/office/bb448854.aspx?f=255&MSPPError=-2147217396">
Open XML SDK</a> which requires a great deal of knowledge to properly compete even simple task.</span>
</li><li><span style="font-size:small">Using a free edition of a library, <a href="http://spreadsheetlight.com/">
SpreadSheetLight</a> which has a paid version too.&nbsp;</span> </li></ul>
<p><span style="font-size:small">What I recommend is trying out SpreadSheetLight if on a budget while if funds are available Aspose Cells.</span></p>
<p>&nbsp;</p>
<h1>Let's get into examples</h1>
<p><img id="173891" src="173891-24.jpg" alt="" width="321" height="492"></p>
<p><img id="173892" src="173892-02.jpg" alt="" width="260" height="308"></p>
<p><span style="font-size:small">Best of best worlds for most tasked needed when working with Excel is SpreadSheetLight. The attached solution works solely with SpreadSheetLight.&nbsp;</span></p>
<p><span style="font-size:small">The main disadvantages of this library for VB.NET is that there are zero code samples for VB.NET. If you have no C# skills and attempt to convert to VB.NET while learning this library my guess is one will get frustrated and
 give up. This is one of the main reasons I wrote the code samples.</span></p>
<p><span style="font-size:small">I suggest downloading the solution along with downloading the SpreadSheet help file from their site.</span></p>
<p><span style="font-size:small">Let's look at what it takes to open an Excel file to a Worksheet via Excel automation.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Option Strict On
Option Infer Off

Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel

Public Module OpenWorkBookSimple
    Public Sub OpenExcelSimple(ByVal FileName As String, ByVal SheetName As String)

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

                Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing

            Next
            If Proceed Then
                Dim sb As New Text.StringBuilder

                Dim Cells As String() = {&quot;A1&quot;, &quot;B2&quot;, &quot;B3&quot;, &quot;B4&quot;}
                For Each cell As String In Cells
                    Try
                        xlCells = xlWorkSheet.Range(cell)
                        sb.AppendLine(String.Format(&quot;{0} = '{1}'&quot;, cell, xlCells.Value))
                    Catch ex As Exception
                        ReleaseExcelObject(xlCells)
                    End Try
                Next
            Else
                ' sheet not found
            End If

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseExcelObject(xlCells)
            ReleaseExcelObject(xlWorkSheets)
            ReleaseExcelObject(xlWorkSheet)
            ReleaseExcelObject(xlWorkBook)
            ReleaseExcelObject(xlWorkBooks)
            ReleaseExcelObject(xlApp)
        Else
            ' file does not exists
        End If
    End Sub
    Private Sub ReleaseExcelObject(ByVal excelObject As Object)
        Try
            If excelObject IsNot Nothing Then
                Marshal.ReleaseComObject(excelObject)
                excelObject = Nothing
            End If
        Catch ex As Exception
            excelObject = Nothing
        End Try
    End Sub
End Module
</pre>
<div class="preview">
<pre class="js">Option&nbsp;Strict&nbsp;On&nbsp;
Option&nbsp;Infer&nbsp;Off&nbsp;
&nbsp;
Imports&nbsp;System.Runtime.InteropServices&nbsp;
Imports&nbsp;Excel&nbsp;=&nbsp;Microsoft.Office.Interop.Excel&nbsp;
&nbsp;
Public&nbsp;Module&nbsp;OpenWorkBookSimple&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;OpenExcelSimple(ByVal&nbsp;FileName&nbsp;As&nbsp;<span class="js__object">String</span>,&nbsp;ByVal&nbsp;SheetName&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;IO.File.Exists(FileName)&nbsp;Then&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Proceed&nbsp;As&nbsp;<span class="js__object">Boolean</span>&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlApp&nbsp;As&nbsp;Excel.Application&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkBooks&nbsp;As&nbsp;Excel.Workbooks&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkBook&nbsp;As&nbsp;Excel.Workbook&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkSheet&nbsp;As&nbsp;Excel.Worksheet&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkSheets&nbsp;As&nbsp;Excel.Sheets&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlCells&nbsp;As&nbsp;Excel.Range&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp&nbsp;=&nbsp;New&nbsp;Excel.Application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.DisplayAlerts&nbsp;=&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkBooks&nbsp;=&nbsp;xlApp.Workbooks&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkBook&nbsp;=&nbsp;xlWorkBooks.Open(FileName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.Visible&nbsp;=&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheets&nbsp;=&nbsp;xlWorkBook.Sheets&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;For/Next&nbsp;finds&nbsp;our&nbsp;sheet&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;x&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">1</span>&nbsp;To&nbsp;xlWorkSheets.Count&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;CType(xlWorkSheets(x),&nbsp;Excel.Worksheet)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;xlWorkSheet.Name&nbsp;=&nbsp;SheetName&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Proceed&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exit&nbsp;For&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(xlWorkSheet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;Proceed&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;Text.StringBuilder&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Cells&nbsp;As&nbsp;<span class="js__object">String</span>()&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;A1&quot;</span>,&nbsp;<span class="js__string">&quot;B2&quot;</span>,&nbsp;<span class="js__string">&quot;B3&quot;</span>,&nbsp;<span class="js__string">&quot;B4&quot;</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;cell&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;In&nbsp;Cells&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlCells&nbsp;=&nbsp;xlWorkSheet.Range(cell)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="js__object">String</span>.Format(<span class="js__string">&quot;{0}&nbsp;=&nbsp;'{1}'&quot;</span>,&nbsp;cell,&nbsp;xlCells.Value))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseExcelObject(xlCells)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;sheet&nbsp;not&nbsp;found&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkBook.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.UserControl&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.Quit()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseExcelObject(xlCells)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseExcelObject(xlWorkSheets)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseExcelObject(xlWorkSheet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseExcelObject(xlWorkBook)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseExcelObject(xlWorkBooks)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseExcelObject(xlApp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;file&nbsp;does&nbsp;not&nbsp;exists&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;ReleaseExcelObject(ByVal&nbsp;excelObject&nbsp;As&nbsp;<span class="js__object">Object</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;excelObject&nbsp;IsNot&nbsp;Nothing&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.ReleaseComObject(excelObject)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelObject&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelObject&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
End&nbsp;Module&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Sample operation with SpreadSheetLight</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Sub OpenExcelSimple(ByVal FileName As String, ByVal SheetName As String)
    Using sl As New SLDocument(FileName, SheetName)
        Dim sb As New Text.StringBuilder
        Dim Cells As String() = {&quot;A1&quot;, &quot;B2&quot;, &quot;B3&quot;, &quot;B4&quot;}
        For Each cell As String In Cells
            sb.AppendLine(String.Format(&quot;{0} = '{1}'&quot;, cell, sl.GetCellValueAsString(cell)))
        Next
    End Using
End Sub</pre>
<div class="preview">
<pre class="js">Public&nbsp;Sub&nbsp;OpenExcelSimple(ByVal&nbsp;FileName&nbsp;As&nbsp;<span class="js__object">String</span>,&nbsp;ByVal&nbsp;SheetName&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;sl&nbsp;As&nbsp;New&nbsp;SLDocument(FileName,&nbsp;SheetName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;Text.StringBuilder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Cells&nbsp;As&nbsp;<span class="js__object">String</span>()&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;A1&quot;</span>,&nbsp;<span class="js__string">&quot;B2&quot;</span>,&nbsp;<span class="js__string">&quot;B3&quot;</span>,&nbsp;<span class="js__string">&quot;B4&quot;</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;cell&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;In&nbsp;Cells&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="js__object">String</span>.Format(<span class="js__string">&quot;{0}&nbsp;=&nbsp;'{1}'&quot;</span>,&nbsp;cell,&nbsp;sl.GetCellValueAsString(cell)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">Removing a WorkSheet with Excel automation</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Option Strict On
Option Infer On
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Module DeleteSheetDemo
    Public Sub DeleteSheet(ByVal FileName As String, ByVal SheetName As String)
        Dim Proceed As Boolean = False

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBooks As Excel.Workbooks = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim xlWorkSheets As Excel.Sheets = Nothing
        Dim xlRange1 As Excel.Range = Nothing


        xlApp = New Excel.Application
        xlApp.DisplayAlerts = False
        xlWorkBooks = xlApp.Workbooks
        xlWorkBook = xlWorkBooks.Open(FileName)

        xlApp.Visible = False

        xlWorkSheets = xlWorkBook.Sheets

        For x As Integer = 1 To xlWorkSheets.Count
            xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

            If xlWorkSheet.Name = SheetName Then

                xlWorkSheet.Delete()
                Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing

                xlWorkSheets.Add(Before:=xlWorkBook.Worksheets(1))
                For y As Integer = 1 To xlWorkSheets.Count
                    xlWorkSheet = CType(xlWorkSheets(y), Excel.Worksheet)
                    If xlWorkSheet.Name = SheetName Then
                        xlWorkSheet.Name = &quot;Sheet1&quot;
                    End If
                Next
                xlWorkBook.SaveAs(FileName)

                Exit For
            End If

            Marshal.FinalReleaseComObject(xlWorkSheet)
            xlWorkSheet = Nothing

        Next


        xlWorkBook.Close()
        xlApp.UserControl = True
        xlApp.Quit()


        ReleaseComObject(xlRange1)
        ReleaseComObject(xlWorkSheets)
        ReleaseComObject(xlWorkSheet)
        ReleaseComObject(xlWorkBook)
        ReleaseComObject(xlWorkBooks)
        ReleaseComObject(xlApp)
    End Sub
    Private Sub ReleaseComObject(ByVal obj As Object)
        Try
            Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub

End Module
</pre>
<div class="preview">
<pre class="js">Option&nbsp;Strict&nbsp;On&nbsp;
Option&nbsp;Infer&nbsp;On&nbsp;
Imports&nbsp;Excel&nbsp;=&nbsp;Microsoft.Office.Interop.Excel&nbsp;
Imports&nbsp;System.Runtime.InteropServices&nbsp;
Module&nbsp;DeleteSheetDemo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;DeleteSheet(ByVal&nbsp;FileName&nbsp;As&nbsp;<span class="js__object">String</span>,&nbsp;ByVal&nbsp;SheetName&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Proceed&nbsp;As&nbsp;<span class="js__object">Boolean</span>&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlApp&nbsp;As&nbsp;Excel.Application&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkBooks&nbsp;As&nbsp;Excel.Workbooks&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkBook&nbsp;As&nbsp;Excel.Workbook&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkSheet&nbsp;As&nbsp;Excel.Worksheet&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlWorkSheets&nbsp;As&nbsp;Excel.Sheets&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;xlRange1&nbsp;As&nbsp;Excel.Range&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp&nbsp;=&nbsp;New&nbsp;Excel.Application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.DisplayAlerts&nbsp;=&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkBooks&nbsp;=&nbsp;xlApp.Workbooks&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkBook&nbsp;=&nbsp;xlWorkBooks.Open(FileName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.Visible&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheets&nbsp;=&nbsp;xlWorkBook.Sheets&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;x&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">1</span>&nbsp;To&nbsp;xlWorkSheets.Count&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;CType(xlWorkSheets(x),&nbsp;Excel.Worksheet)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;xlWorkSheet.Name&nbsp;=&nbsp;SheetName&nbsp;Then&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet.Delete()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(xlWorkSheet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheets.Add(Before:=xlWorkBook.Worksheets(<span class="js__num">1</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;y&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">1</span>&nbsp;To&nbsp;xlWorkSheets.Count&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;CType(xlWorkSheets(y),&nbsp;Excel.Worksheet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;xlWorkSheet.Name&nbsp;=&nbsp;SheetName&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet.Name&nbsp;=&nbsp;<span class="js__string">&quot;Sheet1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkBook.SaveAs(FileName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exit&nbsp;For&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(xlWorkSheet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlWorkBook.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.UserControl&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xlApp.Quit()&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseComObject(xlRange1)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseComObject(xlWorkSheets)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseComObject(xlWorkSheet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseComObject(xlWorkBook)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseComObject(xlWorkBooks)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseComObject(xlApp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;ReleaseComObject(ByVal&nbsp;obj&nbsp;As&nbsp;<span class="js__object">Object</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.ReleaseComObject(obj)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;obj&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;obj&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
End&nbsp;Module&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Using SpreadSheetLight where I have added validation/assertion and is still less code then above.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function RemoveWorkSheet(ByVal pExcelFileName As String, ByVal pSheetName As String) As Boolean
    Using sl As New SLDocument(pExcelFileName)
        Dim workSheets = sl.GetSheetNames(False)
        If workSheets.Any(Function(sheetName) sheetName.ToLower = pSheetName.ToLower) Then
            '
            ' The current worksheet can not be renamed, we check for this and change
            ' the current worksheet if it's the current worksheet.
            '
            If workSheets.Count &gt; 1 Then
                Dim sheet = sl.GetSheetNames.FirstOrDefault(Function(sName) sName.ToLower &lt;&gt; pSheetName.ToLower)
                sl.SelectWorksheet(sl.GetSheetNames.FirstOrDefault(Function(sName) sName.ToLower &lt;&gt; pSheetName.ToLower))
            ElseIf workSheets.Count = 1 Then
                Throw New Exception(&quot;Can not delete the sole worksheet&quot;)
            End If

            sl.DeleteWorksheet(pSheetName)
            sl.Save()

            Return True
        Else
            Return False
        End If
    End Using

End Function</pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;RemoveWorkSheet(ByVal&nbsp;pExcelFileName&nbsp;As&nbsp;<span class="js__object">String</span>,&nbsp;ByVal&nbsp;pSheetName&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;As&nbsp;<span class="js__object">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;sl&nbsp;As&nbsp;New&nbsp;SLDocument(pExcelFileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;workSheets&nbsp;=&nbsp;sl.GetSheetNames(False)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;workSheets.Any(<span class="js__object">Function</span>(sheetName)&nbsp;sheetName.ToLower&nbsp;=&nbsp;pSheetName.ToLower)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;The&nbsp;current&nbsp;worksheet&nbsp;can&nbsp;not&nbsp;be&nbsp;renamed,&nbsp;we&nbsp;check&nbsp;<span class="js__statement">for</span>&nbsp;<span class="js__operator">this</span>&nbsp;and&nbsp;change&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'&nbsp;the&nbsp;current&nbsp;worksheet&nbsp;if&nbsp;it'</span>s&nbsp;the&nbsp;current&nbsp;worksheet.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;workSheets.Count&nbsp;&gt;&nbsp;<span class="js__num">1</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sheet&nbsp;=&nbsp;sl.GetSheetNames.FirstOrDefault(<span class="js__object">Function</span>(sName)&nbsp;sName.ToLower&nbsp;&lt;&gt;&nbsp;pSheetName.ToLower)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sl.SelectWorksheet(sl.GetSheetNames.FirstOrDefault(<span class="js__object">Function</span>(sName)&nbsp;sName.ToLower&nbsp;&lt;&gt;&nbsp;pSheetName.ToLower))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ElseIf&nbsp;workSheets.Count&nbsp;=&nbsp;<span class="js__num">1</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Throw&nbsp;New&nbsp;Exception(<span class="js__string">&quot;Can&nbsp;not&nbsp;delete&nbsp;the&nbsp;sole&nbsp;worksheet&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sl.DeleteWorksheet(pSheetName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sl.Save()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;
End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Some of the demos I have included in the solution.</span></div>
<div class="endscriptcode">
<ul>
<li><span style="font-size:small">Add, remove, rename WorkSheets</span> </li><li><span style="font-size:small">Export DataTable (shown in a DataGridView) to Excel, could also be from a List(Of T)</span>
</li><li><span style="font-size:small">Import WorkSheet into a DataTable. You can do the same with say a concrete class and populate a List(Of T) where T is the concrete class.&nbsp;</span>
</li><li><span style="font-size:small">Get statistics e.g. last row/column, sheet names and more.</span>
</li><li><span style="font-size:small">Does a sheet exists.</span> </li><li><span style="font-size:small">Column headers</span> </li><li><span style="font-size:small">Inserting a new row into a WorkSheet</span> </li><li><span style="font-size:small">Inserting a image into a WorkSheet</span> </li><li><span style="font-size:small">Import a tab delimited text file into a WorkSheet.</span>
</li><li><span style="font-size:small">Showing simple formatting of cells and data.</span>
</li></ul>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:medium"><strong>Ending thoughts</strong></span></div>
</div>
<div class="endscriptcode"><span style="font-size:small">Everyone's&nbsp;has different requirements and bugets. If you feel that what I have presented in reqards to SpreadSheetLight is a viable option for you then learn more via the help file before getting
 deep into a solution as even though it's very easy to use it's a large library and can take time to learn more advance operations which is best to do outside a business project.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Hopefully these code samples prove helpful to you.&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><strong>5/31/2017</strong> added another code sample which shows how to find the last row in a specific column and write data to that column/row.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><strong>6/1/2017</strong> added code sample which shows how to begin withing with mixed data types in a WorkSheet which originated from a StackOverFlow thread.&nbsp;</span></div>
