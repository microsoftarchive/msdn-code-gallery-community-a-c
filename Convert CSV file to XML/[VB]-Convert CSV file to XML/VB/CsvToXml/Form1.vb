Imports System.IO

Public Class Form1

    Private Sub CsvToXml(_inputFile As String, _dataName As String, _separator As Char, _outputFile As String, Optional _fieldnames() As String = Nothing)
        Dim dt As New DataTable(_dataName)
        Dim firstRow As Boolean = True

        Using sr As New StreamReader(_inputFile)
            While Not (sr.EndOfStream)
                Dim fields() As String = sr.ReadLine.Split(_separator)

                If firstRow Then
                    For ii As Integer = 0 To fields.Count - 1
                        Dim _fName As String = ""
                        If IsNothing(_fieldnames) Then
                            _fName = "Field" & ii.ToString("000")
                        Else
                            _fName = _fieldnames(ii)
                        End If
                        dt.Columns.Add(_fName)
                    Next
                    firstRow = False
                End If

                dt.Rows.Add(fields)
            End While

            dt.WriteXml(_outputFile)
            dt.Dispose()
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fieldNames() As String = {"Id", "Name", "Age"}
        CsvToXml("c:\temp\example.txt", "TempTable", ";", "c:\temp\example.xml", fieldNames)
    End Sub
End Class
