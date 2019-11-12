Public Module Extensions
    <System.Runtime.CompilerServices.Extension>
    Public Function ExcelColumnName(ByVal Index As Integer) As String
        Dim chars = New Char() {"A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c,
                                "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c}

        Index -= 1
        Dim columnName As String = Nothing
        Dim quotient = Index \ 26
        If quotient > 0 Then
            columnName = ExcelColumnName(quotient) & chars(Index Mod 26)
        Else
            columnName = chars(Index Mod 26).ToString()
        End If
        Return columnName
    End Function
    ''' <summary>
    ''' Expand all columns excluding in this case Orders column
    ''' </summary>
    ''' <param name="sender"></param>
    <Runtime.CompilerServices.Extension>
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            ' ensure we are not attempting to do this on a Entity
            If col.ValueType.Name <> "ICollection`1" Then
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        Next
    End Sub

End Module
