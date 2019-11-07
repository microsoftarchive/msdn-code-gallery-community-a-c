'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications
Imports Microsoft.VisualBasic
Namespace WebApplication
	Public Module Skype

		Public Function IsValidSkypeUserName(ByVal Text As String) As Boolean
			For Each Chr As Char In Text.ToCharArray
				If Not (Char.IsLetterOrDigit(Chr) Or Chr = "."c Or Chr = "_"c Or Chr = ","c Or Chr = "@"c Or Chr = "-"c) Then
					Return False
				End If
			Next
			Return True
		End Function

		Public Function SkypeHyperLink(ByVal SkypeUserName As String) As WebControls.HyperLink
			Dim HyperLink As New WebControls.HyperLink
			HyperLink.NavigateUrl = SkypeUrl(SkypeUserName)
			HyperLink.ImageUrl = "http://mystatus.skype.com/smallicon/" & ImgOnlineSkypeUser(SkypeUserName)
			HyperLink.Width = 16
			HyperLink.Height = 16
			HyperLink.ToolTip = "Skype"
			Return HyperLink
		End Function

		Private Function ImgOnlineSkypeUser(ByVal SkypeUserName As String) As String
      ImgOnlineSkypeUser = Nothing
      For Each Chr As Char In SkypeUserName.ToCharArray
        If Char.IsLetterOrDigit(Chr) Then
          ImgOnlineSkypeUser &= Chr
        Else
          ImgOnlineSkypeUser &= "-" & Right("00" & Hex(Asc(Chr)), 2)
        End If
      Next
		End Function

		Public Function SkypeUrl(ByVal SkypeUserName As String) As String
			If SkypeUserName <> "" Then
				If SkypeUserName.StartsWith("+") Then
					Return "skype:" & SkypeUserName & "?call"
				Else
					Return "skype:" & String2HexHtml(SkypeUserName) & "?call"
				End If
			End If
      Return Nothing
    End Function

	End Module
End Namespace

