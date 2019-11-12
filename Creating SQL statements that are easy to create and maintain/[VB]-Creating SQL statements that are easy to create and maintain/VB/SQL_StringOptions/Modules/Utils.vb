Module Utils
    Function AddOptionForAllCompanies(Of T)(ByVal sequence As IEnumerable(Of T), ByVal allOption As T) As IEnumerable(Of T)
        Return (New T() {allOption}).Union(sequence)
    End Function
    Function CreateWhereStringList(ByVal items() As String) As String
        Dim separator As String = " and "
        Dim lastSeparator As String = " and "
        Dim Result As String = String.Join(separator, items)
        Dim i As Integer = Result.LastIndexOf(separator)
        If i > -1 Then
            Result = Result.Remove(i, separator.Length)
            Result = Result.Insert(i, lastSeparator)
        End If
        Return Result
    End Function
    Function CreateStringList(ByVal items() As String, ByVal separator As String, ByVal lastSeparator As String) As String
        Dim Result As String = String.Join(separator, items)
        Dim i As Integer = Result.LastIndexOf(separator)
        If i > -1 Then
            Result = Result.Remove(i, separator.Length)
            Result = Result.Insert(i, lastSeparator)
        End If
        Return Result
    End Function

End Module
