Public Module EnumExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToEnum(Of T)(ByVal sender As String) As T

        Dim TheType As Type = GetType(T)

        If [Enum].IsDefined(GetType(T), sender) Then
            Return CType(System.Enum.Parse(TheType, sender, True), T)
        Else
            Dim BaseType As String = TheType.ToString
            Dim Pos As Integer = BaseType.IndexOf("+")
            Dim ErrorMsg As String = ""
            If Pos > -1 Then
                Dim EnumName As String = BaseType.Substring(Pos + 1)
                ErrorMsg = String.Format("'{0}' not a member of '{1}'", sender, EnumName)
            Else
                ErrorMsg = String.Format("{0} not a member of {1}", sender, TheType)
            End If
            Throw New Exception(ErrorMsg)
        End If
    End Function
End Module
