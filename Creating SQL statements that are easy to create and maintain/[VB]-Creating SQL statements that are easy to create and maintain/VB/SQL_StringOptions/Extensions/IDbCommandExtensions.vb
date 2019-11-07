Module IDbCommandExtensions
    ''' <summary>
    ''' Used to show an SQL statement with actual values
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Public Function ActualCommandText(ByVal sender As IDbCommand) As String
        Dim sb As New System.Text.StringBuilder(sender.CommandText)
        Dim EmptyParameterNames =
            (
                From T In sender.Parameters.Cast(Of IDataParameter)()
                Where String.IsNullOrWhiteSpace(T.ParameterName)
            ).FirstOrDefault

        If EmptyParameterNames IsNot Nothing Then
            Return sender.CommandText
        End If

        For Each p As IDataParameter In sender.Parameters

            Select Case p.DbType
                Case DbType.AnsiString, DbType.AnsiStringFixedLength, DbType.Date, DbType.DateTime, DbType.DateTime2, DbType.Guid, DbType.String, DbType.StringFixedLength, DbType.Time, DbType.Xml
                    If p.ParameterName(0) = "@" Then
                        If p.Value Is Nothing Then
                            Throw New Exception("no value given for parameter '" & p.ParameterName & "'")
                        End If
                        sb = sb.Replace(p.ParameterName, String.Format("'{0}'", p.Value.ToString.Replace("'", "''")))
                    Else
                        sb = sb.Replace(String.Concat("@", p.ParameterName), String.Format("'{0}'", p.Value.ToString.Replace("'", "''")))
                    End If
                Case Else
                    sb = sb.Replace(p.ParameterName, p.Value.ToString)
            End Select
        Next

        Return sb.ToString

    End Function
End Module
