Imports System.ComponentModel

Public Class DataGridViewPasswordTextBoxColumn
    Inherits System.Windows.Forms.DataGridViewColumn

    Private _passwordChar As Char
    Private _useSystemPasswordChar As Boolean

    <Category("Password")> _
    Public Property PasswordChar() As Char
        Get
            Return Me._passwordChar
        End Get
        Set(ByVal value As Char)
            If Me._passwordChar <> value Then
                Me._passwordChar = value

                Dim cell As DataGridViewPasswordTextBoxCell = TryCast(Me.CellTemplate, DataGridViewPasswordTextBoxCell)

                If cell IsNot Nothing Then
                    'Update the template cell.
                    cell.PasswordChar = value
                End If

                If Me.DataGridView IsNot Nothing Then
                    'Update each existing cell in the column.
                    For Each row As DataGridViewRow In Me.DataGridView.Rows
                        cell = TryCast(row.Cells(Me.Index), DataGridViewPasswordTextBoxCell)

                        If cell IsNot Nothing Then
                            cell.PasswordChar = value
                        End If
                    Next

                    'Force a repaint so the grid reflects the current property value.
                    Me.DataGridView.Refresh()
                End If
            End If
        End Set
    End Property

    <Category("Password")> _
    Public Property UseSystemPasswordChar() As Boolean
        Get
            Return Me._useSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            If Me._useSystemPasswordChar <> value Then
                Me._useSystemPasswordChar = value

                Dim cell As DataGridViewPasswordTextBoxCell = TryCast(Me.CellTemplate, DataGridViewPasswordTextBoxCell)

                If cell IsNot Nothing Then
                    'Update the template cell.
                    cell.UseSystemPasswordChar = value
                End If

                If Me.DataGridView IsNot Nothing Then
                    'Update each existing cell in the column.
                    For Each row As DataGridViewRow In Me.DataGridView.Rows
                        cell = TryCast(row.Cells(Me.Index), DataGridViewPasswordTextBoxCell)

                        If cell IsNot Nothing Then
                            cell.UseSystemPasswordChar = value
                        End If
                    Next

                    'Force a repaint so the grid reflects the current property value.
                    Me.DataGridView.Refresh()
                End If
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New(New DataGridViewPasswordTextBoxCell)
    End Sub

    Public Overrides Function Clone() As Object
        Dim copy As DataGridViewPasswordTextBoxColumn = DirectCast(MyBase.Clone(), DataGridViewPasswordTextBoxColumn)

        copy.PasswordChar = Me._passwordChar
        copy.UseSystemPasswordChar = Me._useSystemPasswordChar

        Return copy
    End Function

End Class
