Module StringExtensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function RemoveLineFeeds(ByVal sender As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(sender, "[\n\r]", "")
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Function TrimQueryText(ByVal value As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(value.TrimStart, " {2,}", " ")
    End Function
    ''' <summary>
    ''' Used to flatted/collaspe demo sql statements.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' All major databases do not care about tabs, line feeds and spaces for a sql statement.
    ''' For this demo I wanted to display sql nicely which is what this extension does.
    ''' </remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Public Function CollaspeText(ByVal sender As String) As String
        Return sender.TrimStart.RemoveLineFeeds.TrimQueryText
    End Function
    ''' <summary>
    ''' Remove double quotes from a string
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Function RemoveDoubleQuotes(ByVal value As String) As String
        If String.IsNullOrEmpty(value) Then
            Return String.Empty
        End If
        Return System.Text.RegularExpressions.Regex.Replace(value, "[""]", String.Empty)
    End Function
End Module
