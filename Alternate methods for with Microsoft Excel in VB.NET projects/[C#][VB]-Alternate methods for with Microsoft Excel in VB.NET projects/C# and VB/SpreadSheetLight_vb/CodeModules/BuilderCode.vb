Public Module BuilderCode
    ''' <summary>
    ''' Generic method to open Excel. You will need to pay attention
    ''' to how your data is written in regards to IMEX setting which 
    ''' is 1 here but might need it to be different for your data.
    ''' Also HDR is set to No, other setting is Yes.
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Simplified version of my more advance function
    ''' </remarks>
    Public Function ConnectionString(ByVal FileName As String) As String
        Dim Builder As New OleDb.OleDbConnectionStringBuilder
        If IO.Path.GetExtension(FileName).ToUpper = ".XLS" Then
            Builder.Provider = "Microsoft.Jet.OLEDB.4.0"
            Builder.Add("Extended Properties", "Excel 8.0;IMEX=1;HDR=Yes;")
        Else
            Builder.Provider = "Microsoft.ACE.OLEDB.12.0"
            Builder.Add("Extended Properties", "Excel 12.0;IMEX=1;HDR=Yes;")
        End If

        Builder.DataSource = FileName

        Return Builder.ConnectionString

    End Function
End Module

