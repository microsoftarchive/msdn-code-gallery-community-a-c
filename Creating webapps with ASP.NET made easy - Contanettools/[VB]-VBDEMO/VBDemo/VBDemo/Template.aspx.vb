Option Explicit On
Option Strict On
Imports ContaNet.Tools
Public Class Template
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rv As New ContaNet.Tools.NSCore(Page, "", Style, DropDownMenu, ToolBar)
        Dim rs As New ContaNet.Tools.NSShow(Page)

        Select Case rv.Funct

        End Select

    End Sub

    Function Style() As ContaNet.Tools.NSStyles
        Dim s As New ContaNet.Tools.NSStyles
        Return s
    End Function

    Function DropDownMenu() As ContaNet.Tools.NSDropDownMenu
        Dim d As New ContaNet.Tools.NSDropDownMenu
        Return d
    End Function

    Function Toolbar() As ContaNet.Tools.NSToolBar
        Dim t As New ContaNet.Tools.NSToolBar
        Return t
    End Function

End Class