Public Module DateCultureInfo
    Public Function DateSeparator() As String
        Return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
    End Function
    Public Function CurrentDateFormat() As String
        Return String.Format("MM{0}dd{0}yyyy", DateSeparator)
    End Function
    Public Function TimeSepartor() As String
        Return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator
    End Function
End Module
