
Namespace My
    ''' <summary>
    ''' Contains wrappers for common dialog operations where the intent is to keep
    ''' method based and easy to maintain.
    ''' </summary>
    ''' <remarks></remarks>
    <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
    Partial Friend Class _Dialogs
        ''' <summary>
        ''' Defaults to Tilde, used for breaking lines in dialogs
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LineBreakChar As String = "~"
        Private Function CreateLineBreaks(ByVal Text As String) As String
            Return Text.Replace(LineBreakChar, Environment.NewLine)
        End Function
        ''' <summary>
        ''' Ask question with NO as the default button
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Question(ByVal Text As String) As Boolean
            Return (MessageBox.Show(CreateLineBreaks(Text), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        Public Function Question(ByVal Text As String, ByVal Title As String) As Boolean
            Return (MessageBox.Show(CreateLineBreaks(Text), Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        ''' <summary>
        ''' Ask question
        ''' </summary>
        ''' <param name="Text">Question to ask</param>
        ''' <param name="Title">Text for dialog caption</param>
        ''' <param name="DefaultButton">Which button is the default</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Question(ByVal Text As String, ByVal Title As String, ByVal DefaultButton As MsgBoxResult) As Boolean
            Dim db As MessageBoxDefaultButton
            If DefaultButton = MsgBoxResult.No Then
                db = MessageBoxDefaultButton.Button2
            End If
            Return (MessageBox.Show(CreateLineBreaks(Text), Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, db) = MsgBoxResult.Yes)
        End Function
        ''' <summary>
        ''' Shows text in dialog with information icon
        ''' </summary>
        ''' <param name="Text">Message to display</param>
        ''' <remarks></remarks>
        Public Sub InformationDialog(ByVal Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        ''' <summary>
        ''' Shows text in dialog with information icon
        ''' </summary>
        ''' <param name="Text">Message to display</param>
        ''' <param name="Title"></param>
        ''' <remarks></remarks>
        Public Sub InformationDialog(ByVal Text As String, ByVal Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Public Sub WarningDialog(ByVal Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub
        Public Sub WarningDialog(ByVal Text As String, ByVal Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub
        ''' <summary>
        ''' For displaying error/exception text with Error icon
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <remarks></remarks>
        Public Sub ExceptionDialog(ByVal Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        ''' <summary>
        ''' For displaying error/exception text with Error icon
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <param name="Title"></param>
        ''' <remarks></remarks>
        Public Sub ExceptionDialog(ByVal Text As String, ByVal Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        Public Sub ExceptionDialog(ByVal Text As String, ByVal Title As String, ByVal ex As Exception)
            Dim Message As String = String.Concat(Text, Environment.NewLine, ex.Message)
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ex"></param>
        ''' <param name="Text"></param>
        ''' <param name="Title"></param>
        ''' <remarks>
        ''' </remarks>
        Public Sub ExceptionDialog(ByVal ex As Exception, ByVal Text As String, ByVal Title As String)
            MessageBox.Show(String.Format("{0}{1}{2}", Text, Environment.NewLine, ex.Message), Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
    End Class

    <HideModuleName()>
    Friend Module Karens_Dialogs
        Private instance As New ThreadSafeObjectProvider(Of _Dialogs)
        ReadOnly Property Dialogs() As _Dialogs
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
