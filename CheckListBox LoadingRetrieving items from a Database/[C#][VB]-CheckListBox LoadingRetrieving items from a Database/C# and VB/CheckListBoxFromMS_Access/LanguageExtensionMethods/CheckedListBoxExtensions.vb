Public Module CheckedListBoxExtensions
    ''' <summary>
    ''' Find item, set check state
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="Text">text to locate case insensitive</param>
    ''' <param name="Checked">set check state to</param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub FindItemAndSetChecked(ByVal sender As CheckedListBox, ByVal Text As String, ByVal Checked As Boolean)
        Dim Result =
            (
                From this In sender.Items.Cast(Of String)() _
                .Select(Function(item, index) New With {.Item = item, .Index = index})
                Where this.Item.ToLower = Text.ToLower
            ).FirstOrDefault

        If Result IsNot Nothing Then
            sender.SetItemChecked(Result.Index, Checked)
        End If

    End Sub
End Module
