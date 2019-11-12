Module ExcelExtensions
    ''' <summary>
    ''' Will be used in next article I wrote
    ''' </summary>
    ''' <param name="Index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ExcelColumnName(ByVal Index As Integer) As String
        Dim chars = New Char() _
            {
                "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c,
                "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c,
                "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c
            }

        Index -= 1
        Dim columnName As String
        Dim quotient = Index \ 26
        If quotient > 0 Then
            columnName = ExcelColumnName(quotient) + chars(Index Mod 26)
        Else
            columnName = chars(Index Mod 26).ToString()
        End If
        Return columnName
    End Function
End Module
