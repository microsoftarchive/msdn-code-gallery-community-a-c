Public Class DataGridViewPasswordTextBoxCell
    Inherits System.Windows.Forms.DataGridViewTextBoxCell

    Private _passwordChar As Char
    Private _useSystemPasswordChar As Boolean

    Private editingControlPasswordChar As Char
    Private editingControlUseSystemPasswordChar As Boolean

    Public Property PasswordChar() As Char
        Get
            Return Me._passwordChar
        End Get
        Set(ByVal value As Char)
            Me._passwordChar = value
        End Set
    End Property

    Public Property UseSystemPasswordChar() As Boolean
        Get
            Return Me._useSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            Me._useSystemPasswordChar = value
        End Set
    End Property

    Public Overrides Function Clone() As Object
        Dim copy As DataGridViewPasswordTextBoxCell = DirectCast(MyBase.Clone(), DataGridViewPasswordTextBoxCell)

        copy.PasswordChar = Me._passwordChar
        copy.UseSystemPasswordChar = Me._useSystemPasswordChar

        Return copy
    End Function

    Protected Overrides Function GetFormattedValue(ByVal value As Object, _
                                                   ByVal rowIndex As Integer, _
                                                   ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, _
                                                   ByVal valueTypeConverter As System.ComponentModel.TypeConverter, _
                                                   ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, _
                                                   ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object
        Dim formattedValue As Object

        If Me._useSystemPasswordChar AndAlso value IsNot Nothing Then
            'Display the system password character in place of each actual character.
            'TODO: Determine the actual system password character instead of hard-coding this value.
            formattedValue = New String(Convert.ToChar(&H25CF), CStr(value).Length)
        ElseIf Me._passwordChar <> Char.MinValue AndAlso value IsNot Nothing Then
            'Display the user-defined password character in place of each actual character.
            formattedValue = New String(Me._passwordChar, CStr(value).Length)
        Else
            'Display the value as is.
            formattedValue = MyBase.GetFormattedValue(value, _
                                                      rowIndex, _
                                                      cellStyle, _
                                                      valueTypeConverter, _
                                                      formattedValueTypeConverter, _
                                                      context)
        End If

        Return formattedValue
    End Function

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
                                                  ByVal initialFormattedValue As Object, _
                                                  ByVal dataGridViewCellStyle As System.Windows.Forms.DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

        With DirectCast(Me.DataGridView.EditingControl, TextBox)
            'Remember the current password properties of the editing control.
            Me.editingControlPasswordChar = .PasswordChar
            Me.editingControlUseSystemPasswordChar = .UseSystemPasswordChar

            'Set the new password properties of the editing control.
            .PasswordChar = Me._passwordChar
            .UseSystemPasswordChar = Me._useSystemPasswordChar
        End With
    End Sub

    Public Overrides Sub DetachEditingControl()
        MyBase.DetachEditingControl()

        With DirectCast(Me.DataGridView.EditingControl, TextBox)
            'Reset the old password properties of the editing control.
            .PasswordChar = Me.editingControlPasswordChar
            .UseSystemPasswordChar = Me.editingControlUseSystemPasswordChar
        End With
    End Sub

End Class
