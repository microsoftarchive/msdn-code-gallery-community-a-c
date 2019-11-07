Imports WebApplication
Partial Class css
  Inherits System.Web.UI.Page
  Private Styles As New System.Collections.Specialized.StringCollection
  Private Setups As New System.Collections.Specialized.StringCollection
	Private NameSkin As String
	Private Media As String
	Private SubSiteName As String
	Shared ObjSync As New Object
  Const UseCache As Boolean = True
  Protected Sub css_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		'Response.AddHeader("Expires", Now.AddMonths(1).ToString("r"))
		Response.Cache.SetExpires(Now.AddMonths(1))

		Const NameDefault As String = "default"
		SubSiteName = CurrentSubSiteName()
		NameSkin = Page.Request("skin")
		Media = Page.Request("media")	'handheld or print

    Dim CssData As String = Nothing

		If (UseCache AndAlso Not IsLocal()) AndAlso Config.Skin.CacheSkin.ContainsKey(CacheKey) Then
			'Read Css from cache
			CssData = Config.Skin.CacheSkin(CacheKey)
		Else
			If NameSkin = "" Then NameSkin = NameDefault
			If IO.File.Exists(MapPath(SkinsSubDirectory & "\" & NameSkin & ".xml")) = False Then
				NameSkin = NameDefault
			End If
			Dim Skin As Skin = Config.Skin.Load(NameSkin)

			Styles = Skin.Styles
			Setups = Skin.Setups

			If Styles.Count = 0 Then
				Styles.Add(NameDefault)
			End If

			If Setups.Count = 0 Then
				Setups.Add(NameDefault)
			End If

			Dim AllStyles As New Collections.Specialized.StringCollection
			For Each Style As String In Styles
				AllStyles.Add(Style)
			Next
			If Media = "handheld" OrElse Media = "print" Then
				AllStyles.Add(Media & ".media")
			End If

			For Each Style As String In AllStyles
				CssData &= ReadAll(File(Style))
			Next
			ReplaceValues(CssData)

			'Minify CSS
			Dim StringBuilder As New StringBuilder(CssData.Length)
			For Each C As Char In CssData
				Dim LastSpace As Boolean
				If C = " "c Then
					If Not LastSpace Then
						StringBuilder.Append(C)
					End If
					LastSpace = True
				ElseIf C = vbTab Then
				Else
					StringBuilder.Append(C)
					LastSpace = False
				End If
			Next

			StringBuilder.Replace(vbTab, "")
      StringBuilder.Replace(": ", ":")
			StringBuilder.Replace("; ", ";")
			StringBuilder.Replace("; ", ";")
			StringBuilder.Replace(" }", "}")
			StringBuilder.Replace("} ", "}")
			StringBuilder.Replace(" {", "{")
			StringBuilder.Replace("{ ", "{")
			CssData = StringBuilder.ToString
			StringBuilder.Clear()
			Dim Lines() As String = CssData.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
			For Each Line As String In Lines
				Line = Trim(Line)
				Dim Position As Integer = InStr(Line, "/*")
				If Position Then
					Line = Left(Line, Position - 1)
				End If
				StringBuilder.Append(Line)
			Next
			CssData = StringBuilder.ToString

      If UseCache AndAlso Not IsLocal() Then
        SyncLock ObjSync
          If Not Config.Skin.CacheSkin.ContainsKey(CacheKey) AndAlso UseCache Then
            'Add Css to cache
            Config.Skin.CacheSkin.Add(CacheKey, CssData)
          End If
        End SyncLock
      End If
		End If

		Response.ContentType = "text/css;charset=utf-8"
		Response.Write(CssData)
		Response.End()
	End Sub

	Function CacheKey() As String
		If Media = "" AndAlso Request.Browser.IsMobileDevice = True Then
			Media = "handheld"
		End If
		If Skin.SkinUseCustomSetup.ContainsKey(SubSiteName) Then
			Return "!" & SubSiteName & vbTab & Media
		Else
			Return NameSkin & vbTab & Media
		End If
	End Function

	Function File(ByVal NameStyle As String) As String
		Return MapPath(SkinsSubDirectory & "\styles\" & NameStyle & ".css")
	End Function

  Sub ReplaceValues(ByRef Data As String)
    'Variables.Comparer = SortCriterion
    Dim Variables(-1) As KeyValue
    Dim SkinSetup As SkinSetup = SkinSetup.Load(Setups)
    If SkinSetup IsNot Nothing Then
      Dim KeyValue As KeyValue
			For Each Key As String In SkinSetup.Variables.Keys
				Dim Value As String = SkinSetup.Variables(Key)
				KeyValue = New KeyValue
				KeyValue.Value = Value
				KeyValue.Key = Key
				Dim KeyExists As Boolean
				KeyExists = False
				For Each Variable As KeyValue In Variables
					If StrComp(Variable.Key, Key, CompareMethod.Text) = 0 Then
						Variables.SetValue(KeyValue, Array.IndexOf(Variables, Variable))
						KeyExists = True
						Exit For
					End If
				Next
				If Not KeyExists Then
					Array.Resize(Variables, Variables.Length + 1)
					Variables(UBound(Variables)) = KeyValue
				End If
			Next

    End If
		Dim SortCriterion As IComparer = New KeyLenComparer

    System.Array.Sort(Variables, SortCriterion)

    For Each KeyValue As KeyValue In Variables
      Data = ReplaceText(Data, "$" & KeyValue.Key, KeyValue.Value)
    Next

  End Sub


  Public Class KeyLenComparer
    Implements IComparer
    Public Function Compare(ByVal KeyValue1 As Object, ByVal KeyValue2 As Object) As Integer Implements IComparer.Compare
      Dim L1 As Integer = Len(KeyValue1.key)
      Dim L2 As Integer = Len(KeyValue2.key)
      Select Case L1
        Case Is > L2
          Return -1
        Case Is < L2
          Return 1
        Case Else
          Return 0
      End Select
    End Function 'Compare
  End Class 'SizeComparer
  Class KeyValue
    Public Key As String
    Public Value As String
  End Class

End Class

