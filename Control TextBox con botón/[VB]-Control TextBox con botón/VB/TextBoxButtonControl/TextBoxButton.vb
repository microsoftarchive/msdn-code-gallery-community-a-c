Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class TextBoxButton
    Inherits TextBox

    Private ReadOnly _button As Button

    Public Sub New()
        _button = New Button() With { _
            .Cursor = Cursors.Default, _
            .TabStop = False, _
            .BackgroundImage = My.Resources.ellipsis, _
            .BackgroundImageLayout = ImageLayout.Zoom}
        Me.Controls.Add(_button)
        PosicionarBoton()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        PosicionarBoton()
    End Sub

    Private Sub PosicionarBoton()
        _button.Size = New Size(Me.ClientSize.Height, Me.ClientSize.Height)
        _button.Location = New Point(Me.ClientSize.Width - _button.Width, 0)
        SendMessage(Me.Handle, &HD3, 2, _button.Width << 16)
    End Sub

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" ( _
                ByVal hWnd As IntPtr, ByVal msg As IntPtr, ByVal wp As IntPtr, _
                ByVal lp As IntPtr) _
            As IntPtr

    <Category("Action")> _
    Public Custom Event ButtonClick As EventHandler
        AddHandler(value As EventHandler)
            AddHandler _button.Click, value
        End AddHandler

        RemoveHandler(value As EventHandler)
            RemoveHandler _button.Click, value
        End RemoveHandler

        RaiseEvent(sender As Object, e As EventArgs)
        End RaiseEvent
    End Event

    Private _buttonImage As Image

    <Category("Appearance"), Description("Imagen del botón")> _
    Public Property ButtonImage() As Image
        Get
            Return _buttonImage
        End Get
        Set(ByVal value As Image)
            _buttonImage = value
            If _buttonImage Is Nothing Then
                _button.BackgroundImage = My.Resources.ellipsis
            Else
                _button.BackgroundImage = _buttonImage
            End If
        End Set
    End Property

End Class
