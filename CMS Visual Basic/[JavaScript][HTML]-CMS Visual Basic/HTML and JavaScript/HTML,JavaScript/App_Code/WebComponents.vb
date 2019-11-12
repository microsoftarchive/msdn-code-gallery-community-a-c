'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports System.Xml.Serialization
Imports System.Reflection
Namespace WebApplication

	Public Module Components

		Function ControlItem(ByVal Href As String, ByVal Text As String, ByVal ToolTip As String, Optional ByVal Level As LevelMenuItem = LevelMenuItem.Topic) As Control
			Dim Ctrl As New System.Web.UI.WebControls.HyperLink
			Ctrl.NavigateUrl = Href
			Ctrl.ToolTip = EncodingAttribute(ToolTip)
			'Ctrl.Text = HttpUtility.HtmlEncode(Text)
			Ctrl.Controls.Add(TextControl(Text))
			Ctrl.CssClass = "m" & Level
      If Href = "" AndAlso Level = 0 Then
        If CurrentSetting.Aspect.MenuContractible Then
          Dim Idx As Integer = NextProgressive("idm0")
          Ctrl.ClientIDMode = ClientIDMode.Static
          Ctrl.ID = "idm0" & Idx
          'Ctrl.NavigateUrl = "#" & Ctrl.ID
          Ctrl.NavigateUrl = "javascript:SwitchExpand('" & Ctrl.ID & "')" 'Is not a bug! This link don't perform a jump at onClink!
          'Ctrl.TabIndex = Idx
        End If
      End If
      Return Ctrl
		End Function

		Enum LevelMenuItem
			Sphera
			Theme
			Topic
			SubTopic
			Voice
		End Enum

    Function ObjectToControl(ByVal Setting As SubSite, ByVal Obj As Object, Optional TablePropertyPhraseCorrispondence As StringDictionary = Nothing, Optional ByVal TablePropertyIdPhraseCorrispondence As Collections.Generic.Dictionary(Of String, Integer) = Nothing, Optional ByVal NamePhraseBooks As String = Nothing, Optional ByVal SetByRequest As HttpRequest = Nothing, Optional ByRef BackErrorSetByRequest As Boolean = False, Optional ByVal FilterExcludeProperties() As String = Nothing, Optional ByVal FilterIncludeProperties() As String = Nothing, Optional ByVal FilterArray As Boolean = False) As Control
      'This function transform a Object to a web control!
      'Parameters:
      'SetByRequest = Is used only in PostBack to setting the Obj
      'RetriveSetError = Return eventualli error in setting Obj operation


      Dim Control As New Control
      Control.EnableViewState = False
      Control.Controls.Add(ScriptByNameFile("ForceNumericInput.js"))
      Control.Controls.Add(ScriptByNameFile("AutoSizeTestArea.js"))
      Control.Controls.Add(ScriptByNameFile("ColorPick/jscolor.js"))

      NodeExplorer(Setting, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks, Obj, Obj.GetType, Control, SetByRequest, BackErrorSetByRequest, , Obj.GetType.Name, , , , FilterExcludeProperties, FilterIncludeProperties, FilterArray)
      Dim Literal As New Literal
      Literal.Text = ControlToText(Control)
      Return Literal
    End Function

    Private Sub NodeExplorer(ByVal Setting As SubSite, ByVal TablePropertyPhraseCorrispondence As StringDictionary, ByVal TablePropertyIdPhraseCorrispondence As Collections.Generic.Dictionary(Of String, Integer), ByVal NamePhraseBooks As String, ByRef Obj As Object, ByRef ObjType As Type, ByRef Control As Control, Optional ByVal SetByRequest As HttpRequest = Nothing, Optional ByRef BackError As Boolean = False, Optional ByVal Progressive As Integer = 0, Optional ByRef Name As String = Nothing, Optional ByRef FullName As String = Nothing, Optional ByVal Level As Integer = 0, Optional ByVal IdArray As Integer = -1, Optional ByVal FilterExcludeProperties() As String = Nothing, Optional ByVal FilterIncludeProperties() As String = Nothing, Optional ByVal FilterArray As Boolean = False)
      'Exclude and Include by filter if the filter is setting
      If (FilterExcludeProperties Is Nothing OrElse Not FilterExcludeProperties.Contains(Name)) AndAlso (FilterIncludeProperties Is Nothing OrElse FilterIncludeProperties.Contains(Name)) Then

        System.Diagnostics.Debug.WriteLine(Name)

        If (ObjType.IsValueType) OrElse ObjType.IsEquivalentTo(Type.GetType("System.String")) Then
          ' AndAlso Not ObjType.IsLayoutSequential
          'IsLayoutSequential filter the structure	(Structure IsValueType and IsLayoutSequential )
          Dim Title As Control
          Title = New WebControl(HtmlTextWriterTag.H3)
          Title.Controls.Add(TextControl(TextByTablePropertyPhraseCorrispondence(Name, ObjType.FullName, Setting, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks)))
          Control.Controls.Add(Title)
          ProcessValueTypeElement(Setting, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks, Obj, ObjType, Control, SetByRequest, BackError, FullName)
          Control.Controls.Add(BR)
        Else
          'Is a Class (Hete start a tree)
          Dim Panel As New WebControl(HtmlTextWriterTag.Fieldset)
          Control.Controls.Add(Panel)
          Panel.CssClass = "Menu"
          Dim ShowName As String
          ShowName = Name
          Dim SubObject As Object = Nothing
          Dim SubObjectName As String = Nothing
          Dim SubObjectType As Type = Nothing

          Dim Collection As Object = Nothing
          If ObjType.GetMethod("ToArray") IsNot Nothing AndAlso ObjType.GetMethod("Clear") IsNot Nothing Then
            Collection = Obj
            Obj = Obj.ToArray
            ObjType = Obj.GetType
          End If

          If ObjType.IsArray Then
            If SetByRequest IsNot Nothing AndAlso SetByRequest(FullName) IsNot Nothing Then
              'Is PostBack!	Then set the Object
              Dim UBoundArray As Integer
              If Obj Is Nothing Then
                UBoundArray = -1
              Else
                UBoundArray = UBound(Obj)
              End If
              Dim NewUBound As Integer = SetByRequest(FullName) - 1
              If UBoundArray <> NewUBound Then
                Try
                  Dim ReDimObj = Array.CreateInstance(Type.GetType(Obj.GetType.FullName.Substring(0, Obj.GetType.FullName.Length - 2)), NewUBound + 1)
                  For N As Integer = 0 To UBound(ReDimObj)
                    If N <= UBound(Obj) Then
                      ReDimObj(N) = Obj(N)
                    End If
                  Next
                  Obj = ReDimObj
                  'End Select
                  HttpContext.Current.Session("NoBackTo") = True
                  If Collection IsNot Nothing Then Collection.Clear()
                  For N As Integer = LBound(Obj) To UBound(Obj)
                    If Obj(N) Is Nothing Then
                      'Type of element in array
                      Dim TypeElement As Type = ObjType.GetElementType
                      'New istance by type
                      Obj(N) = Activator.CreateInstance(TypeElement)
                    End If
                    'Add all array elements to collection
                    If Collection IsNot Nothing Then Collection.Add(Obj(N))
                  Next
                Catch ex As Exception
                End Try
              End If
            End If

            'Add a imput to permit the redim of array
            Dim Count As Integer
            If Obj Is Nothing Then
              Count = -1
            Else
              Count = UBound(Obj) + 1
            End If
            Dim TextBox As New WebControls.TextBox
            TextBox.Attributes.Add("onkeypress", "return ForceNumericInput(this, event, false, true)")
            TextBox.Style.Add("text-align", "right")
            TextBox.ID = FullName
            TextBox.Attributes.Add("name", FullName)
            TextBox.Text = Count
            TextBox.Style.Add("margin-left", "20px")
            TextBox.Style.Add("margin-right", "20px")
            TextBox.Attributes.Add("onblur", "if(this.value<" & Count & "){if(confirm('" & AbjustForJavascriptString(Phrase(Setting.Language, 51)) & " '+(" & Count & "-this.value)+' " & AbjustForJavascriptString(Ask(Phrase(Setting.Language, 153), Setting.Language)) & "')){} else {this.value=" & Count & "}}if(this.value!=" & Count & "){var NoSaveNow=document.createElement('input');NoSaveNow.setAttribute('name', 'NoSaveNow');document.forms[0].appendChild(NoSaveNow);document.forms[0].submit()}")
            TextBox.Attributes.Add("onkeyup", "if(code==13){this.onblur()}")
            'Panel.Controls.Add(TextControl(JoinedTextToSpecedText(LetterAndDigit(Obj.GetType.Name))))
            Dim MainItem As Control = ControlItem(Nothing, JoinedTextToSpecedText(ShowName), Nothing, LevelMenuItem.Sphera)
            MainItem.Controls.Add(TextBox)
            MainItem.Controls.Add(TextControl(Phrase(Setting.Language, 153)))
            Panel.Controls.Add(MainItem)

            If Obj IsNot Nothing AndAlso FilterArray = False Then
              For Idx As Integer = LBound(Obj) To UBound(Obj)
                If Obj(Idx) IsNot Nothing Then
                  If Obj(Idx).GetType.IsPrimitive OrElse Obj(Idx).GetType.FullName = "System.String" Then
                    SubObjectName = Idx + 1
                  Else
                    SubObjectName = Left(Obj.GetType.Name, Len(Obj.GetType.Name) - 2) & " " & Idx + 1
                  End If

                  SubObjectType = Obj(Idx).GetType
                  Dim NewFullName As String
                  NewFullName = FullName & SubObjectName
                  NodeExplorer(Setting, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks, Obj(Idx), SubObjectType, Panel, SetByRequest, BackError, Progressive, SubObjectName, NewFullName, Level + 1, Idx, FilterExcludeProperties, FilterIncludeProperties, FilterArray)
                End If
              Next
            End If

            If Collection IsNot Nothing Then
              Obj = Collection
            End If

          Else
            Dim Title As Control = ControlItem(Nothing, JoinedTextToSpecedText(ShowName), Nothing, LevelMenuItem.Sphera)
            'Title.Controls.Add(New LiteralControl(JoinedTextToSpecedText(ObjType.Name) & Base1Index))
            Panel.Controls.Add(Title)

            'If Obj.GetType.GetMethod("GetDynamicMemberNames") IsNot Nothing AndAlso TypeOf Obj.GetDynamicMemberNames Is IEnumerable(Of String) Then
            If ObjType.GetMethod("GetDynamicMemberNames") IsNot Nothing AndAlso ObjType.GetMethod("GetDynamicMemberNames").ReturnType = GetType(IEnumerable(Of String)) Then
              'Is a dinamic object
              Dim Names() As String = Obj.GetDynamicMemberNames()
              For Each SubObjectName In Names
                SubObject = CallByName(Obj, SubObjectName, CallType.Get)
                SubObjectType = SubObject.GetType

                Dim NewFullName As String
                If FullName Is Nothing Then
                  NewFullName = SubObjectName
                Else
                  NewFullName = FullName & "." & SubObjectName
                End If
                NodeExplorer(Setting, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks, SubObject, SubObjectType, Panel, SetByRequest, BackError, Progressive, SubObjectName, NewFullName, Level + 1, -1, FilterExcludeProperties, FilterIncludeProperties, FilterArray)
                If SetByRequest IsNot Nothing Then
                  CallByName(Obj, SubObjectName, vbSet, SubObject)
                End If
              Next
            Else
              For Each Member As MemberInfo In ObjType.GetMembers
                'For Each Field As FieldInfo In ObjType.GetFields
                If Member.MemberType = MemberTypes.Field OrElse Member.MemberType = MemberTypes.Property Then
                  Dim Accept As Boolean
                  Accept = False
                  Select Case Member.MemberType
                    Case MemberTypes.Field
                      'Exclude Shared
                      Dim Field As FieldInfo = ObjType.GetField(Member.Name)
                      If Not Field.IsStatic Then
                        'Check if is read only
                        If Field.IsInitOnly = False Then
                          'Ignore Private & abstract classes
                          If Field.IsPublic Then
                            If Not ((Field.GetType.Attributes And System.Reflection.TypeAttributes.Abstract) = System.Reflection.TypeAttributes.Abstract) Then
                              Accept = True
                              SubObject = Field.GetValue(Obj)
                              SubObjectName = Field.Name
                              SubObjectType = Field.FieldType
                            End If
                          End If
                        End If
                      End If
                    Case MemberTypes.Property
                      Dim ThisProperty As PropertyInfo = ObjType.GetProperty(Member.Name)
                      'Ignore Private & abstract classes
                      Try
                        'Check if is read only
                        If ThisProperty.CanRead AndAlso ThisProperty.CanWrite Then
                          'If ThisProperty.GetValue(Obj, Nothing) = ThisProperty.GetValue(Obj, Nothing) Then
                          If ThisProperty.GetValue(Obj, Nothing).GetType.IsPublic Then
                            If Not ((ThisProperty.GetType.Attributes And System.Reflection.TypeAttributes.Abstract) = System.Reflection.TypeAttributes.Abstract) Then
                              SubObject = ThisProperty.GetValue(Obj, Nothing)
                              SubObjectName = ThisProperty.Name
                              SubObjectType = ThisProperty.PropertyType
                              Accept = True
                            End If
                          End If
                        End If
                      Catch ex As Exception

                      End Try
                  End Select
                  If Accept Then
                    Dim NewFullName As String
                    If FullName Is Nothing Then
                      NewFullName = SubObjectName
                    Else
                      NewFullName = FullName & "." & SubObjectName
                    End If
                    NodeExplorer(Setting, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks, SubObject, SubObjectType, Panel, SetByRequest, BackError, Progressive, SubObjectName, NewFullName, Level + 1, -1, FilterExcludeProperties, FilterIncludeProperties, FilterArray)
                    If SetByRequest IsNot Nothing Then
                      CallByName(Obj, SubObjectName, vbSet, SubObject)
                    End If
                  End If
                End If
              Next
            End If
          End If
        End If
      End If
    End Sub

    Private Sub ProcessValueTypeElement(ByVal Setting As SubSite, ByVal TablePropertyPhraseCorrispondence As StringDictionary, ByVal TablePropertyIdPhraseCorrispondence As Collections.Generic.Dictionary(Of String, Integer), ByVal NamePhraseBooks As String, ByRef Obj As Object, ByRef ObjType As Type, ByRef Control As Control, Optional ByVal SetByRequest As HttpRequest = Nothing, Optional ByRef BackError As Boolean = False, Optional ByVal FullName As String = Nothing)
      'Dim Type As Type = Obj.GetType

      'Set Object implementation for PostBack
      Dim ShowError As Label = Nothing

      If SetByRequest IsNot Nothing AndAlso SetByRequest(FullName) IsNot Nothing Then
        'Is PostBack!	Then set the Object
        Try
          If TypeOf Obj Is Date Then
            Obj = Date.ParseExact(SetByRequest(FullName), Setting.DateFormat, Globalization.CultureInfo.InvariantCulture)
          ElseIf TypeOf Obj Is Boolean Then
            Obj = SetByRequest(FullName) = "True"
          ElseIf ObjType.IsEnum Then
            Obj = String2Enum(ObjType, SetByRequest(FullName))
          ElseIf TypeOf Obj Is String Then
            Obj = SetByRequest(FullName)
          Else
            Obj = CTypeDynamic(SetByRequest(FullName), ObjType)
          End If
        Catch ex As Exception
          BackError = True
          ShowError = New Label
          ShowError.Text = HttpUtility.HtmlEncode(" " & Phrase(Setting.Language, 29))
          ShowError.ToolTip = EncodingAttribute(ex.Message)
          ShowError.CssClass = "Evidence"
        End Try
      End If

      If TypeOf Obj Is Boolean Then
        Dim List As WebControls.ListBox = ListItem({True, False}, Obj, {Phrase(Setting.Language, 126), Phrase(Setting.Language, 127)})
        List.ID = FullName
        List.Rows = 2
        Control.Controls.Add(List)
      ElseIf ObjType.IsEnum Then
        Dim Texts As String() = ObjType.GetEnumNames
        For Id As Integer = LBound(Texts) To UBound(Texts)
          Texts(Id) = TextByTablePropertyPhraseCorrispondence(Texts(Id), ObjType.FullName & "." & Texts(Id), Setting, TablePropertyPhraseCorrispondence, TablePropertyIdPhraseCorrispondence, NamePhraseBooks)
        Next
        Dim List As WebControls.ListBox = ListItem(ObjType.GetEnumNames, Obj.ToString, Texts)
        List.ID = FullName
        Control.Controls.Add(List)
      ElseIf ObjType.IsEquivalentTo(Type.GetType("System.String")) Then
        If InStr(FullName, "color", CompareMethod.Text) Then
          Dim Input As New WebControls.WebControl(HtmlTextWriterTag.Input)
          Input.Attributes.Add("name", FullName)
          Input.Attributes.Add("maxlength", 7)
          Input.Attributes.Add("size", 8)
          Input.Attributes.Add("value", Obj)
          Input.CssClass = "color"
          Control.Controls.Add(Input)
        Else
          Dim Textarea As New WebControls.WebControl(HtmlTextWriterTag.Textarea)
          Textarea.Style.Add("width", "100%")
          Textarea.ID = FullName
          Textarea.Controls.Add(Literal(Obj))
          Textarea.Attributes.Add("name", FullName)
          Textarea.Attributes.Add("onkeyup", "checkRows(this)")
          Textarea.Attributes.Add("onkeypress", "saveKeyCode(event)")
          Textarea.Attributes.Add("onload", "checkRows(this)")
          Control.Controls.Add(Textarea)
          Control.Controls.Add(Script("checkRows(document.getElementById(""" & Textarea.ID & """))", ScriptLanguage.javascript))
        End If
      Else
        Dim TextBox As New WebControls.TextBox
        If TypeOf Obj Is Integer OrElse TypeOf Obj Is Byte OrElse TypeOf Obj Is Decimal OrElse TypeOf Obj Is Long OrElse TypeOf Obj Is Short Then
          TextBox.Attributes.Add("onkeypress", "return ForceNumericInput(this, event, false, true)")
        ElseIf TypeOf Obj Is UInteger OrElse TypeOf Obj Is ULong OrElse TypeOf Obj Is UShort Then
          TextBox.Attributes.Add("onkeypress", "return ForceNumericInput(this, event, false, false)")
        ElseIf TypeOf Obj Is Single OrElse TypeOf Obj Is Double Then
          TextBox.Attributes.Add("onkeypress", "return ForceNumericInput(this, event, true, true)")
        End If
        If ObjType.IsEquivalentTo(Type.GetType("System.String")) Then
          TextBox.Style.Add("width", "100%")
        ElseIf Not TypeOf Obj Is Date Then
          TextBox.Style.Add("text-align", "right")
        End If
        TextBox.ID = FullName
        TextBox.Attributes.Add("name", FullName)
        Control.Controls.Add(TextBox)
        If TypeOf Obj Is Date Then
          TextBox.Text = CDate(Obj).ToString(Setting.DateFormat, Setting.Culture)
          Dim Label As New Label
          Label.Text = " " & Setting.DateFormat
          Control.Controls.Add(Label)
        Else
          TextBox.Text = Obj
        End If
        Control.Controls.Add(BR)
      End If

      If ShowError IsNot Nothing Then
        Control.Controls.Add(ShowError)
      End If

    End Sub

    Function IsColor(Text As String) As Boolean
      If Text <> "" AndAlso Text.StartsWith("#") Then
        If Text.Length = 4 OrElse Text.Length = 7 Then
          Return System.Text.RegularExpressions.Regex.IsMatch(Text, "^#?(([a-fA-F0-9]){3}){1,2}$")
        End If
      End If
      Return False
    End Function

    Private Function TextByTablePropertyPhraseCorrispondence(ByVal Name As String, ByVal FullNameType As String, ByVal Setting As SubSite, ByVal TablePropertyPhraseCorrispondence As StringDictionary, ByVal TablePropertyIdPhraseCorrispondence As Collections.Generic.Dictionary(Of String, Integer), ByVal NamePhraseBooks As String) As String
      If TablePropertyPhraseCorrispondence IsNot Nothing Then
        If TablePropertyPhraseCorrispondence.ContainsKey(Name) Then
          Return TablePropertyPhraseCorrispondence(Name)
        End If
        If TablePropertyPhraseCorrispondence.ContainsKey(FullNameType) Then
          Return TablePropertyPhraseCorrispondence(FullNameType)
        End If
      End If
      If TablePropertyIdPhraseCorrispondence IsNot Nothing Then
        'Dim Position As Integer = InStr(Name, "(")
        'Dim Key As String
        'If Position Then
        'Key = Name.Substring(0, Position - 1)
        'Else
        'Key = Name
        'End If
        If TablePropertyIdPhraseCorrispondence.ContainsKey(Name) Then
          Return Phrase(NamePhraseBooks, Setting.Language, TablePropertyIdPhraseCorrispondence(Name))
        End If
        If TablePropertyIdPhraseCorrispondence.ContainsKey(FullNameType) Then
          Return Phrase(NamePhraseBooks, Setting.Language, TablePropertyIdPhraseCorrispondence(FullNameType))
        End If
      End If
      Return JoinedTextToSpecedText(Name)
    End Function

		Public Function ListItem(ByVal Values As String(), ByVal Selected As String, Optional ByVal Texts As String() = Nothing) As WebControls.ListBox
			Dim List As New WebControls.ListBox
			Dim Id As Integer
			For Each Value As String In Values
				Dim Item As WebControls.ListItem
				Item = New WebControls.ListItem
				Item.Value = Value
				Item.Text = Value
				If Texts Is Nothing Then
					Item.Text = Value
				Else
					Item.Text = Texts(Id)
				End If
				If Value = Selected Then
					Item.Selected = True
				End If
				List.Items.Add(Item)
				Id += 1
			Next
			Return List
		End Function



		Public Class Trace
			Private CtrlCollection As New Collections.Generic.List(Of Control)
			'Private CtrlCollection As Array

			Sub AddElement(ByVal Text As String, Optional ByVal Tooltip As String = Nothing, Optional ByVal Url As String = Nothing)
				Dim Link As New HyperLink
				Link.NavigateUrl = Url
				Link.Text = HttpUtility.HtmlEncode(Text)
				Link.ToolTip = EncodingAttribute(Tooltip)
				Link.CssClass = "Trace"
				CtrlCollection.Add(Link)
			End Sub

			Function Controls(Optional ByVal Reverse As Boolean = False) As Control()
        Controls = Nothing
        If CtrlCollection.Count Then
          Controls = CtrlCollection.ToArray
          Dim Last As HyperLink = Controls.ElementAt(0)
          Last.Attributes.Add("rel", "index")
          If Reverse Then
            Array.Reverse(Controls)
          End If
        End If
        Return Controls
      End Function

		End Class

		Public Function Control(ByVal Tipe As HtmlTextWriterTag) As WebControls.WebControl
			Return New WebControls.WebControl(Tipe)
		End Function
    'Public Function EnhancedLinkIconTool(ByVal IconTool As IconToolType, Optional ByVal ToolTip As String = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Text As String = Nothing, Optional ByVal Target As String = Nothing, Optional ByVal OnClick As String = Nothing, Optional ByVal NoFollow As Boolean = False) As Control
    '	Dim Icon As HtmlControls.HtmlImage = Components.IconTool(IconTool, Text)

    '	Dim Link As New HyperLink

    '	Link.Controls.Add(Icon)
    '	If Text <> "" Then
    '		Link.Controls.Add(Literal(Text & " "))
    '		Icon.Attributes("title") = EncodingAttribute(Text)
    '	End If
    '	Link.ToolTip = EncodingAttribute(ToolTip)
    '	Link.NavigateUrl = Href
    '	Link.Target = Target
    '	If NoFollow Then
    '		Link.Attributes.Add("rel", "nofollow")
    '	End If
    '	If OnClick <> "" Then
    '		Link.Attributes.Add("onclick", OnClick)
    '	End If
    '	Dim Controls As New Control
    '	If Setup.SEO.GoogleOffGoogleOnTagsEnabled Then
    '		'Controls.Controls.Add(New LiteralControl("<!--googleoff: index-->"))
    '	End If
    '	Controls.Controls.Add(Link)
    '	If Setup.SEO.GoogleOffGoogleOnTagsEnabled Then
    '		'Controls.Controls.Add(New LiteralControl("<!--googleon: index-->"))
    '	End If
    '	Return Controls
    'End Function

		Public Function EnhancedLinkIcon(ByVal Skin As Skin, ByVal Icon As IconType, Optional ByVal ToolTip As String = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Text As String = Nothing, Optional ByVal Target As String = Nothing, Optional ByVal OnClick As String = Nothing, Optional ByVal NoFollow As Boolean = False) As HyperLink
			Dim Link As New HyperLink
			Dim CtrlIcon As Control = Components.Icon(Icon, Skin, Text)
			Link.Controls.Add(CtrlIcon)
			Link.Controls.Add(Literal(Text))
			Link.ToolTip = EncodingAttribute(ToolTip)
			Link.NavigateUrl = Href
			Link.Target = Target
			If NoFollow Then
				Link.Attributes.Add("rel", "nofollow")
			End If
			Return Link
		End Function

    Public Function Message(ByVal Text As String, Setting As SubSite, Optional ByVal ToolTip As String = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Type As MessageType = MessageType.Normal) As Control
      Dim Control As New WebControl(HtmlTextWriterTag.Label)
      Control.CssClass = "Message"
      Control.Controls.Add(Components.Icon(IconType.TechSupport, Setting.Skin, Text))

      Dim Msg As New HyperLink
      Msg.Text = HttpUtility.HtmlEncode(Text)
      Msg.ToolTip = EncodingAttribute(ToolTip)
      Msg.NavigateUrl = Href

      Control.Controls.Add(Msg)

      Return Control

    End Function
    Public Function Message(Setting As SubSite, ByVal IDText As Integer, Optional ByVal IDToolTip As Integer = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Type As MessageType = MessageType.Normal) As Control
      Dim Text As String = Phrase(Setting.Language, IDText)
      Return Message(Text, Setting, Phrase(Setting.Language, IDToolTip), Href, Type)
    End Function
    Enum MessageType
      Normal
      ErrorAlert
    End Enum
    Public Function BR() As LiteralControl
      'Return New WebControls.WebControl(HtmlTextWriterTag.Br)
      Return New LiteralControl("<br />")
    End Function
    'Public Function HR() As LiteralControl
    '	'Return New WebControl(HtmlTextWriterTag.Hr)
    '	Return New LiteralControl("<hr/>")
    'End Function
    'Enum DrowFonts
    '  Webdings = 0
    '  Wingdings = 1
    '  Wingdings2 = 2
    '  Wingdings3 = 3
    'End Enum

    Class CacheWidthHeight
      Private ElementAtLoad As Integer
      Property TableImageSize As WHN()
        Get
          SyncLock Cache
            If Cache.Count AndAlso Cache.Count <> ElementAtLoad Then
              Dim Elements(Cache.Count - 1) As WHN
              Dim N As Integer
              For Each NameFile As String In Cache.Keys
                Dim Element As WH = Cache(NameFile)
                Dim WHN As WHN
                WHN = New WHN
                WHN.NameFile = NameFile
                WHN.Width = Element.Width
                WHN.Height = Element.Height
                Elements(N) = WHN
                N += 1
              Next
              Return Elements
            End If
            Return Nothing
          End SyncLock
        End Get
        Set(ByVal value As WHN())
          SyncLock Cache
            ElementAtLoad = value.Count
            For Each Element As WHN In value
              Dim WH As New WH
              WH.Height = Element.Height
              WH.Width = Element.Width
              Cache.Add(Element.NameFile, WH)
            Next
          End SyncLock
        End Set
      End Property


      Private Cache As New Collections.Generic.Dictionary(Of String, WH)
      Private Class WH
        Public Width As Integer
        Public Height As Integer
      End Class
      Public Class WHN
        Public NameFile As String
        Public Width As Integer
        Public Height As Integer
      End Class

      Sub LoadWidthHeight(ByVal NameFileImage As String, ByRef Width As Integer, ByRef Height As Integer)
        SyncLock Cache
          Try
            If Cache.ContainsKey(NameFileImage) Then
              Dim WH As WH = Cache(NameFileImage)
              Width = WH.Width
              Height = WH.Height
            Else
              Dim Image As System.Drawing.Image = Drawing.Image.FromFile(MapPath(NameFileImage))
              Dim WH As New WH
              WH.Width = Image.Width
              WH.Height = Image.Height
              Cache.Add(NameFileImage, WH)
              Width = WH.Width
              Height = WH.Height
            End If
          Catch ex As Exception

          End Try
        End SyncLock

      End Sub
    End Class

    Public CacheImageSize As New CacheWidthHeight

    'Function IconTool(ByVal Logo As IconToolType, Optional ByVal AlternateText As String = Nothing) As HtmlControls.HtmlImage
    '  Dim Image As New HtmlControls.HtmlImage
    '  Image.Src = ImgagesResources & "/" & "toolicons" & "/" & Logo.ToString & ".gif"
    '  Image.Attributes("class") = "icon"
    '  Dim Width, Height As Integer
    '  CacheImageSize.LoadWidthHeight(Image.Src, Width, Height)
    '  Image.Width = Width
    '  Image.Height = Height
    '  If AlternateText <> "" Then
    '    Image.Attributes("alt") = EncodingAttribute(AlternateText)
    '  Else
    '    Image.Attributes("alt") = Logo.ToString
    '  End If
    '  Return Image
    'End Function

    Function Icon(ByVal Logo As IconType, ByVal Skin As Skin, Optional ByVal AlternateText As String = Nothing) As Control
      Dim Image As New HtmlControls.HtmlImage
      Dim Src As String = ImgagesResources & "/" & Skin.FolderIcons & "/" & Logo.ToString & ".png"
      Image.Attributes("src") = Src.Replace(" ", "%20")
      Dim Width, Height As Integer
      CacheImageSize.LoadWidthHeight(Src, Width, Height)
      Image.Attributes.Add("width", Width)
      Image.Attributes.Add("height", Height)
      If AlternateText <> "" Then
        AlternateText = EncodingAttribute(AlternateText)
        Image.Attributes("alt") = AlternateText
        Image.Attributes("title") = AlternateText
      Else
        Image.Attributes("alt") = Logo.ToString
      End If
      Dim Literal As New Literal 'Don't change this! HtmlImage control make a bug in the rendering
      Literal.Text = ControlToText(Image)
      Return Literal
    End Function

    'Enum IconToolType As Integer
    '  Cut
    '  Draw
    '  Paste
    '  Lock
    '  Print
    '  Save
    '  Tools
    '  Help
    '  Open
    '  Undo
    '  Redo
    '  Link
    '  Table
    '  Numbering
    '  Bullets
    '  Decrease_Ident
    '  Increase_Ident
    '  Bold
    '  Italic
    '  Underline
    '  Justify_Left
    '  Justify_Right
    '  Justify_Center
    '  User
    '  User_Check
    '  Reply
    '  Modify
    '  Lock_document
    '  Flag
    '  Premium
    '  Online
    '  Cr
    '  Hyperlink
    '  Cut2
    '  Medal1
    '  Medal2
    '  Medal3
    '  Medal4
    '  Fullscreen
    '  Back
    '  Right
    '  Left
    '  Up
    '  Down
    '  ZoomIn
    '  ZoomOut
    '  Star
    '  Logo
    '  Bottom
    '  Checked
    '  UnChecked
    '  Point
    'End Enum

    Enum IconType As Integer
      Home
      Email
      ControlPanel
      Favourites
      Folder
      Folder1
      Folder2
      FolderPics
      FolderPics1
      FolderVideo
      FolderVideo1
      Pics
      Search
      Users
      Document
      Globe
      Contacts
      Pen
      DocumentBlank
      Chat
      TechSupport
      Help
      MyIcons
      MusicPlayer
      'If add here elements REMEMBER to add cote to IconsNameFile Class!!
    End Enum

    'Function SrcIcon(ByVal Icon As IconType, Optional ByVal Skin As Skin = Nothing) As String
    '	If Skin Is Nothing Then
    '		Skin = CurrentSetting.Skin
    '	End If
    '	Dim File As String
    '	File = Icon.ToString
    '	File &= ".png"
    '	Return ImgagesResources & "/" & Skin.FolderIcons & "/" & File
    'End Function

    'Function SrcIconTool(ByVal Icon As IconToolType, Optional ByVal Skin As Skin = Nothing) As String
    '	If Skin Is Nothing Then
    '		Skin = CurrentSetting.Skin
    '	End If
    '	Dim File As String
    '	File = Icon.ToString
    '	File &= ".gif"
    '	Return ImgagesResources & "/" & Skin.FolderToolIcons & "/" & File
    'End Function

    Function Weathers(ByVal Setting As SubSite) As Control
      Dim Ctrl As New Control
      If Not Setting.Weathers Is Nothing Then
        For Each Locality As WeatherLocality In Setting.Weathers
          Try
            Ctrl.Controls.Add(Weather(Locality.WeatherCode, Locality.LocalityName, Setting.Language))
          Catch ex As Exception
          End Try
        Next
      End If
      Return Ctrl
    End Function
    Function Weather(ByVal WeatherCode As String, ByVal Locality As String, ByVal Language As LanguageManager.Language) As Control
      Dim Info As New WeatherManager.Weather(WeatherCode)
      If Info.Exist Then
        Dim Table As HtmlTable
        Table = Components.Table(5, 2, , True)
        Dim FirstRow As New HtmlTableRow
        Dim Cell As New HtmlTableCell
        Cell.ColSpan = 2
        FirstRow.Cells.Add(Cell)
        Table.Rows.Insert(0, FirstRow)
        'Table.Rows(1).Cells.RemoveAt(1)
        'Table.Rows(1).Cells(0).ColumnSpan = 1
        Table.Style.Add("width", "100%")
        If Not Info.HrefIcon Is Nothing Then
          Dim Image As New HtmlImage
          Image.Src = Info.HrefIcon
          Dim Width, Height As Integer
          CacheImageSize.LoadWidthHeight(Image.Src, Width, Height)
          Image.Width = Width
          Image.Height = Height
          Image.Alt = Info.Condition.ToString
          Table.Rows(0).Cells(0).Controls.Add(Image)
        End If
        AddLabel(Table.Rows(0).Cells(0), Locality)
        Dim HrefEarth As String = Href(CurrentSubSiteName, False, "earth.aspx", EarthManager.QueryStringParameters(Nothing, Nothing, Info.Latitude, Info.Longitude))
        Dim LogoEarth As Control = IconUnicode(IconName.Flag, , Locality & ": " & Phrase(Language, 1034), HrefEarth)
        Table.Rows(0).Cells(0).Controls.Add(LogoEarth)
        Dim Row As Integer = 1
        'Dim SubTable As Table
        'SubTable = Components.Table(5, 2, , True)

        FineWrite(Table.Rows(Row).Cells(0), Phrase(Language, 3032))  'Temperature
        FineWrite(Table.Rows(Row).Cells(1), Info.Temperature & " °C")
        Row += 1
        FineWrite(Table.Rows(Row).Cells(0), Phrase(Language, 3033)) 'Relative Humidity
        FineWrite(Table.Rows(Row).Cells(1), Info.RelativeHumidity & " %")
        If Info.Pressure Then
          Row += 1
          FineWrite(Table.Rows(Row).Cells(0), Phrase(Language, 3034)) 'Pressure
          FineWrite(Table.Rows(Row).Cells(1), Info.Pressure & " mb")
        End If
        Row += 1
        FineWrite(Table.Rows(Row).Cells(0), Phrase(Language, 3035)) 'Visibility
        FineWrite(Table.Rows(Row).Cells(1), Info.Visibility & " m")
        Row += 1
        FineWrite(Table.Rows(Row).Cells(0), Phrase(Language, 3036)) 'Wind
        FineWrite(Table.Rows(Row).Cells(1), Info.Wind & " m/s - " & Info.WindDegrees & "°")

        'Table.Rows(1).Cells(0).Controls.Add(Table)

        Dim Div As New WebControl(HtmlTextWriterTag.Div)
        Div.CssClass = "Weather"
        Div.Controls.Add(Table)
        Return Div
      End If
      Return Nothing
    End Function
    Private Sub FineWrite(ByVal Control As Control, ByVal Text As String)
      Dim Label As New Label
      Label.Text = Text
      Label.Style.Add("font-size", "smaller")
      Control.Controls.Add(Label)
    End Sub
    Public Function Emoticon(ByVal Name As Common.Emoticons) As WebControls.Image
      Dim Image As New WebControls.Image
      Image.ImageUrl = ImgagesResources & "/Emoticons/" & EmoticonFileName(Name)
      Dim Width, Height As Integer
      CacheImageSize.LoadWidthHeight(Image.ImageUrl, Width, Height)
      Image.Width = Width
      Image.Height = Height
      Return Image
    End Function
    Function Button(ByVal Setting As SubSite, ByVal Text As String, ByVal Href As String, Optional ByVal ToolTip As String = Nothing, Optional ByVal Icon As IconType = IconType.Globe, Optional ByVal Target As String = Nothing, Optional ByVal Nofollow As Boolean = False, Optional Itemprop As String = Nothing, Optional Rel As String = Nothing) As Control
      Text = FirstUpper(Text)
      If ToolTip = "" Then ToolTip = Text
      Dim Link As New WebControls.HyperLink
      If Itemprop IsNot Nothing Then
        Link.Attributes.Add("itemprop", Itemprop)
      End If
      Link.NavigateUrl = Href
      Link.ToolTip = EncodingAttribute(ToolTip)
      Link.Target = Target

      If Nofollow Then
        If Rel IsNot Nothing Then
          Rel &= " "
        End If
        Rel &= "nofollow"
      End If

      If Rel IsNot Nothing Then
        Link.Attributes.Add("rel", Rel)
      End If

      If Setting.Skin.SkinSetup IsNot Nothing AndAlso Not StrComp(Setting.Skin.SkinSetup.Variables("ButtonsWithIcons"), "false", CompareMethod.Text) = 0 Then
        Link.Controls.Add(Components.Icon(Icon, Setting.Skin, Text))
        Link.Controls.Add(BR)
      End If

      Link.Controls.Add(TextControl(Text))
      Link.CssClass = "Button"

      Return Link
    End Function

    Sub AddFotoAlbumSlideShow(Setting As SubSite, Button As Control, PhotoAlbum As String)
      If PhotoAlbum <> "" AndAlso Setting.Aspect.AddImageIntoTheBackgroundOfButtonPhotoAlbum Then
        Dim N As Integer
        Const MaxFoto As Integer = 5
        Dim JavaArray As New StringBuilder(100 * MaxFoto)
        Dim AllPhotos() As Integer = PhotoManager.AllPhotosName(PhotoAlbum)
        If AllPhotos IsNot Nothing AndAlso AllPhotos.Count > 0 Then
          For Each Id As Integer In AllPhotos
            N += 1
            Dim Photo As Photo = PhotoManager.Photo.Load(Id, PhotoAlbum)
            JavaArray.Append("""" & AbjustForJavascriptString(Photo.Src(Setting)) & """")
            If N = MaxFoto Then Exit For
            JavaArray.Append(",")
          Next
          Dim ScriptCode = "function imgchange" & Button.ClientID & "(){var photosurls=[" & JavaArray.ToString & "];var imgchange=imgchange" & Button.ClientID & ";if (typeof imgchange.photoidx=='undefined'){imgchange.photoidx=0;imgchange.button=document.getElementById('" & Button.ClientID & "')};imgchange.button.style.backgroundRepeat='repeat';imgchange.button.style.backgroundPosition='center';imgchange.button.style.backgroundImage=""url('""+photosurls[imgchange.photoidx]+""')"";imgchange.photoidx++;if(imgchange.photoidx>photosurls.length-1){imgchange.photoidx=0}}"
          ScriptCode &= "setInterval('imgchange" & Button.ClientID & "()',5000)"
          Dim ScriptControl As WebControl = Script(ScriptCode, ScriptLanguage.javascript)
          Button.Controls.Add(ScriptControl)
        End If
      End If
    End Sub

    'Function Icon(ByVal IconType As IconType, Optional ByVal AlternateText As String = Nothing, Optional ByVal Skin As Config.Skin = Nothing) As HtmlControls.HtmlImage
    '	Dim Image As New HtmlControls.HtmlImage
    '	Image.Src = SrcIcon(IconType, Skin)
    '	Dim Width, Height As Integer
    '	CacheImageSize.LoadWidthHeight(Image.Src, Width, Height)
    '	Image.Width = Width
    '	Image.Height = Height
    '	Image.Alt = EncodingAttribute(AlternateText)
    '	Return Image
    'End Function

    Function InfoUser(ByVal User As User, Optional ByVal Language As LanguageManager.Language = LanguageManager.Language.NotDefinite) As Control
      If Language = LanguageManager.Language.NotDefinite Then
        Language = User.Language
      End If
      Dim Table As HtmlTable = Components.Table(2, 2, HorizontalAlign.Left)
      Table.Rows(0).Cells(0).InnerText = Phrase(Language, 9) & ":" 'UserName
      Table.Rows(0).Cells(1).InnerText = User.Username
      Table.Rows(1).Cells(0).InnerText = Phrase(Language, 10) & ":"  'Password
      Table.Rows(1).Cells(1).InnerText = User.Password
      Return Table
    End Function
    Function ScriptByNameFile(ByVal FileNameInResourcesScriptsDirectory As String) As WebControl
      Return Script(ScriptLanguage.javascript, ScriptsResources & "/" & FileNameInResourcesScriptsDirectory)
    End Function
    Function Script(ByVal ScriptLanguage As ScriptLanguage, ByVal Src As String) As WebControl
      Script = New WebControl(HtmlTextWriterTag.Script)
      Script.Attributes.Add("src", Src)
      Script.Attributes.Add("type", ScriptType(ScriptLanguage))
    End Function

    Function Script(ByVal Code As String, ByVal ScriptLanguage As ScriptLanguage, ByVal ForControl As Control, ByVal ForEvent As String) As Control
      Return Script(Code, ScriptLanguage, "document.getElementById(""" & ForControl.ClientID & """)", ForEvent)
    End Function

    Function Script(ByVal Code As String, Optional ByVal ScriptLanguage As ScriptLanguage = ScriptLanguage.javascript, Optional ByVal ForControl As String = Nothing, Optional ByVal ForEvent As String = Nothing) As Control
      Dim Ctrl As New WebControls.WebControl(HtmlTextWriterTag.Script)
      Ctrl.EnableViewState = False
      'Ctrl.Attributes("language") = ScriptLanguage.ToString.ToLower
      Ctrl.Attributes("type") = ScriptType(ScriptLanguage)
      If ForControl <> "" Then
        Select Case ScriptLanguage
          Case Components.ScriptLanguage.vbscript
            Ctrl.Attributes("for") = ForControl
            Ctrl.Attributes("event") = ForEvent
          Case Else
            Code = ForControl & "." & ForEvent & "=function " & LetterAndDigit(ForControl) & "_" & ForEvent & "(){" & Code & "}"
        End Select
      End If
      Ctrl.Controls.Add(New LiteralControl("//<![CDATA[" & vbCrLf & Code & vbCrLf & "//]]>"))
      Return Ctrl
    End Function

    Function ScriptType(ByVal ScriptLanguage As ScriptLanguage) As String
      Return "text/" & ScriptLanguage.ToString.ToLower
    End Function
    Enum ScriptLanguage
      javascript
      jscript
      vbscript
    End Enum
    Function ScriptOutside(ByVal Source As SourceScript, Optional ByVal ScriptLanguage As ScriptLanguage = ScriptLanguage.javascript) As WebControl
      ScriptOutside = Components.Control(HtmlTextWriterTag.Script)
      ScriptOutside.Attributes.Add("src", "script.aspx?s=" & Source)
      ScriptOutside.Attributes.Add("language", ScriptLanguage.ToString)
      ScriptOutside.Attributes("type") = ScriptType(ScriptLanguage)
    End Function
    Public Enum SourceScript
      DetectTimeZoneOffset
    End Enum

    Function Flag(ByVal Language As LanguageManager.Language) As HtmlImage
      Dim Image As New HtmlImage
      Dim Acronym As String
      If Language = Language.Chinese Then
        Acronym = "CN"
      Else
        Acronym = LanguageManager.Acronym(Language)
      End If
      Image.Src = ImgagesResources & "/flags/" & Acronym & ".gif"
      Dim Width, Height As Integer
      CacheImageSize.LoadWidthHeight(Image.Src, Width, Height)
      Image.Width = Width
      Image.Height = Height
      Image.Alt = LanguageManager.LanguageDefinition(Language, Language)
      Return Image
    End Function
    Function Fieldset(ByVal Legend As String, Optional ByVal AddControl As Control = Nothing, Optional [Class] As String = Nothing) As WebControl
      Dim Text As New Literal
      Text.Text = Legend
      Return Fieldset(Text, AddControl, [Class])
    End Function
    Function Fieldset(ByVal Legend As Control, Optional ByVal AddControl As Control = Nothing, Optional [Class] As String = Nothing) As WebControl
      Dim CtrlFieldset As New WebControl(HtmlTextWriterTag.Fieldset)
      If [Class] IsNot Nothing Then
        CtrlFieldset.Attributes("class") = [Class]
      End If
      Dim CtrlLegend As New WebControl(HtmlTextWriterTag.Legend)
      CtrlLegend.Controls.Add(Legend)
      CtrlFieldset.Controls.Add(CtrlLegend)
      If AddControl IsNot Nothing Then
        CtrlFieldset.Controls.Add(AddControl)
      End If
      Return CtrlFieldset
    End Function

    Function Fieldset(ByVal Legend As String, ByVal InnerHtml As String) As WebControl
      Dim Html As New LiteralControl
      Html.Text = InnerHtml
      Return Fieldset(Legend, Html)
    End Function

    Function Ul(Optional ByVal AddControl As Control = Nothing) As WebControl
      'Draws lines of text as a bulleted list. 
      Dim Ctrl As New WebControls.WebControl(HtmlTextWriterTag.Ul)
      If AddControl IsNot Nothing Then
        Ctrl.Controls.Add(AddControl)
      End If
      Return Ctrl
    End Function
    Function Ol(Optional ByVal AddControl As Control = Nothing) As WebControl
      'Draws lines of text as an ordered list
      Dim Ctrl As New WebControls.WebControl(HtmlTextWriterTag.Ol)
      If AddControl IsNot Nothing Then
        Ctrl.Controls.Add(AddControl)
      End If
      Return Ctrl
    End Function
    Function Li(Optional ByVal AddControl As Control = Nothing) As WebControl
      'Draws lines of text as an ordered list
      Dim Ctrl As New WebControls.WebControl(HtmlTextWriterTag.Li)
      If AddControl IsNot Nothing Then
        Ctrl.Controls.Add(AddControl)
      End If
      Return Ctrl
    End Function

    Function AudioObject(ByVal Src As String, Optional ByVal Type As AudioType = AudioType.AutoDetectAudioType) As Control
      Try
        If Type = AudioType.AutoDetectAudioType Then
          Select Case Src.Remove(0, Src.LastIndexOf(".")).ToLower
            Case ".mid", ".midi"
              Type = AudioType.midi
            Case ".mp3", ".mpeg3"
              Type = AudioType.mpeg3
            Case ".wav"
              Type = AudioType.wav
            Case ".mod", ".iff"
              Type = AudioType.x_aiff
          End Select
        End If
      Catch ex As Exception
        Type = AudioType.mpeg3
      End Try
      Dim Ctrl As New HtmlGenericControl("object")
      Ctrl.Attributes.Add("data", Src)
      Ctrl.Attributes.Add("type", "audio/" & ReplaceBin(Type.ToString, "_", "-"))
      Ctrl.Style.Add("width", "320px")
      Ctrl.Style.Add("height", "24px")
      Return Ctrl
    End Function

    Enum AudioType
      AutoDetectAudioType
      midi
      mpeg3
      wav
      x_aiff 'amiga
    End Enum

    Function NewsPreview(ByVal Setting As SubSite, ByVal News As Collections.Generic.List(Of Notice), Optional ByVal MaxElement As Integer = 0) As Control
      If News IsNot Nothing Then
        If News.Count Then
          Dim Preview As New Control
          Dim N As Integer
          For Each Notice As Notice In News
            Dim NoticeControl As Control = Notice.Control(Setting)
            If NoticeControl IsNot Nothing Then
              N += 1
              Preview.Controls.Add(NoticeControl)
              If N = MaxElement Then
                Exit For
              End If
            End If
          Next
          If Not Preview Is Nothing Then
            If MaxElement Then
              Preview.Controls.Add(Button(Setting, Phrase(Setting.Language, 3090), Href(Setting.Name, False, "default.aspx", QueryKey.Show, DefaultPageShowType.News), , IconType.Globe))
            End If
            Return Fieldset(Phrase(Setting.Language, 2), Preview, "News")
          End If
        End If
      End If
      Return Nothing
    End Function

    Sub AddPageArchived(ByRef Where As Control, ByRef MasterPage As MasterPage, ByVal Archive As Integer, ByVal Page As Integer, ByVal HttpContext As HttpContext, ByVal DomainConfiguration As DomainConfiguration, ByRef Setting As Config.SubSite, Optional ByRef ReturnMetaTags As MetaTags = Nothing, Optional ByVal HomePage As Boolean = False, Optional ByVal AddDefaultLinks As Boolean = True, Optional ByVal AddCommentsButton As Boolean = True, Optional ByVal Level As Integer = 0, Optional ByVal Category As Integer = 0, Optional ByVal CharactersLimit As Integer = 0, Optional ByVal AddPdfButton As Boolean = True)
      If DomainConfiguration Is Nothing Then DomainConfiguration = CurrentDomainConfiguration()
      Dim Html As String = ReadAll(MenuManager.PageNameFile(Archive, Page, Setting.Language))
      Dim MetaTags As New MetaTags(Html)
      Dim CurrentUser As User = Authentication.CurrentUser

      Dim ShowDate As EnabledStatus
      Dim TagShowDate As String = MetaTags.MetaTag("ShowDate")
      Dim AuthorName As String = MetaTags.Author
      Dim Author As User = User.Load(AuthorName)
      If Author IsNot Nothing Then
        MasterPage.AddAuthors(Author)
      End If
      If TagShowDate <> "" Then
        ShowDate = TagShowDate
      End If
      If ShowDate = EnabledStatus.Default Then
        If Setting.Aspect.ShowTheDateInTheArticles Then
          ShowDate = EnabledStatus.Yes
        Else
          ShowDate = EnabledStatus.No
        End If
      End If

      Dim Body As String = Common.Body(Html)
      Dim BottomContent As New HtmlGenericControl("nav") 'Html5
      If CharactersLimit Then
        Body = TruncateText(InnerText(Body), CharactersLimit)
      Else
        TagNameToLower(Body)
      End If
      PluginManager.RaiseRenderingPageEvent(Archive, Page, Setting, HttpContext, Where, MetaTags, Body, BottomContent)
      Dim Control As New Control
      Where.Controls.Add(Control)

      If DomainConfiguration Is Nothing Then DomainConfiguration = CurrentDomainConfiguration()

      Dim TagDl As Boolean
      If ShowDate = EnabledStatus.No Then
        If Not HomePage AndAlso CharactersLimit <> 0 AndAlso Setting.SEO.AutoTagDlForThePages Then
          If MetaTags.Title <> "" AndAlso MetaTags.Title.Count(Function(c As Char) c = " "c) <= 1 Then
            Dim Status As SubSite.CerrelatedStructure.CorrelatedStatus = MetaTags.Collection("CorrelatedStatus")
            If Status = SubSite.CerrelatedStructure.CorrelatedStatus.Enabled Then
              TagDl = True
            End If
          End If
        End If
      End If

      Dim Item As HtmlGenericControl = New HtmlGenericControl("section") 'html5
      Item.Attributes.Add("itemscope", "itemscope")
      Item.Attributes.Add("itemtype", "http://schema.org/BlogPosting")
      Control.Controls.Add(Item)
      If TagDl Then
        Dim Dl = New HtmlGenericControl("dl")
        Item = Dl
      End If

      Dim HtmlTop As String = Nothing
      If TagDl Then
        If MetaTags.Title <> "" Then
          Dim Attrib As String = Nothing
          If MetaTags.Description <> "" Then
            Attrib &= " title=""" & HttpUtility.HtmlEncode(MetaTags.Description) & """ lang=""" & Acronym(Setting.Language) & """"
          Else
            Attrib &= " lang=""" & Acronym(Setting.Language) & """"
          End If
          HtmlTop = "<dt itemprop=""name"" class=""Title""" & Attrib & ">" & HttpUtility.HtmlEncode(MetaTags.Title) & "</dt>"
        End If
      Else
        If MetaTags.Title <> "" Then
          HtmlTop = "<a id=""" & LetterAndDigitReplaceSpace(MetaTags.Title) & """>" & HttpUtility.HtmlEncode(MetaTags.Title) & "</a> "
          If HomePage Then
            HtmlTop = "<h2 itemprop=""name"">" & HtmlTop & "</h2>"
          Else
            HtmlTop = "<h1 itemprop=""name"">" & HtmlTop & "</h1>"
          End If
        End If
        If MetaTags.Description <> "" Then
          HtmlTop &= "<h3 itemprop=""description"">" & HttpUtility.HtmlEncode(MetaTags.Description) & "</h3>"
        End If
      End If

      Item.Controls.Add(New LiteralControl(HtmlTop))

      Dim TextContainer As Control
      If TagDl Then
        TextContainer = New WebControl(HtmlTextWriterTag.Dd)
      Else
        TextContainer = New Control
      End If
      Item.Controls.Add(TextContainer)

      If ReturnMetaTags Is Nothing Then
        ReturnMetaTags = MetaTags
      Else
        ReturnMetaTags.Join(MetaTags)
        If InStr(ReturnMetaTags.KeyWords, MetaTags.Title, CompareMethod.Text) = 0 Then
          ReturnMetaTags.KeyWords &= IfStr(ReturnMetaTags.KeyWords <> "", ",", "") & MetaTags.Title
        End If
        If InStr(ReturnMetaTags.KeyWords, MetaTags.Description, CompareMethod.Text) = 0 Then
          ReturnMetaTags.KeyWords &= IfStr(ReturnMetaTags.KeyWords <> "", ",", "") & MetaTags.Description
        End If
      End If

      If CharactersLimit = 0 Then
        'Add photo (if exists) or Video
        Dim TagPhoto As String = MetaTags.MetaTag("Photo")
        Dim TagVideo As String = MetaTags.MetaTag("Video")

        If TagPhoto <> "" Or TagVideo <> "" Then
          Dim Align As String 'New WebControls.WebControl(HtmlTextWriterTag.Span)
          If HttpContext.Items("CountPhotos") Is Nothing Then
            HttpContext.Items("CountPhotos") = 1
          Else
            HttpContext.Items("CountPhotos") += 1
          End If

          If HttpContext.Items("CountPhotos") Mod 2 Then
            Align = "PhotoUnpair"
          Else
            Align = "PhotoPair"
          End If
          'TextContainer.Controls.Add(Align)

          'Add Photo
          If TagPhoto <> "" Then
            Dim Photo As Photo = Photo.Load(TagPhoto)
            If Photo IsNot Nothing Then
              Dim Box As HtmlControl = Photo.ControlThumbnail(Setting, , SizeImagePreview(HttpContext), , DomainConfiguration, HttpContext)  ' New WebControl(HtmlTextWriterTag.Span)
              Box.Attributes("class") &= " BoxElement " & Align
              'Box.Attributes.Add("class", "BoxElement " & Align)
              TextContainer.Controls.Add(Box)
            End If
          End If

          'Add Video
          If TagVideo <> "" Then
            Dim Box As WebControl = VideoObject(TagVideo, Setting, HttpContext)
            If Setting.Aspect.SizeOfVideoEmbedded = SubSite.AspectConfiguration.VideoSize.SameAsImagesPreviewConfiguration Then
              Box.CssClass = "BoxElement " & Align
            End If
            TextContainer.Controls.Add(Box)
          End If
        End If
      End If

      'Add poll
      If CharactersLimit = 0 Then
        PollManager.AddPoll(DomainConfiguration, Setting, Body, PollContext.Archine, PollStringToVotes(MetaTags.MetaTag("poll")), Archive, Page, Setting.Language)
      End If

      'Add date
      If ShowDate = EnabledStatus.Yes Then
        Dim PubDate As Date = TextToDate(MetaTags.MetaTag("date"))
        If PubDate <> Date.MinValue Then
          TextContainer.Controls.Add(DateControl(PubDate, Setting))
          TextContainer.Controls.Add(BR)
        End If
      End If

      'Add body
      UrlToLink(Body, Setting, DomainConfiguration)

      If AddDefaultLinks Then
        ContextualLink.AddContextualLinks(Body, Setting, Archive, Level, Category)
      End If
      If Setting.SEO.CopyPrevention.Pages Then
        Body = ObfuscateHtml(Body, Setting)
      End If
      Dim ArticleBody As New HtmlGenericControl("article") 'html5
      ArticleBody.Attributes.Add("itemprop", "articleBody")
      ArticleBody.InnerHtml = Body
      TextContainer.Controls.Add(ArticleBody)

      'Add author
      If Setting.Aspect.ShowTheAuthorInTheArticles Then
        If Author IsNot Nothing AndAlso Author.Username <> "" Then
          TextContainer.Controls.Add(BR)
          TextContainer.Controls.Add(QuickInfoUser(Setting, Author))
        End If
      End If

      Dim Canonical As String
      Canonical = MenuManager.ItemMenu.Href(Setting, Page, Archive, MetaTags.Title, True, DomainConfiguration)

      'Add a bar at bottom text position, and pass this to MasterPage to generate the RenderingPage events of plugin with this bar
      BottomContent.Style.Add("display", "table")
      If MasterPage IsNot Nothing Then
        MasterPage.AddBottomContent(BottomContent, Canonical)
      End If

      'Add Button PDF version
      If AddPdfButton Then
        Dim PdfEnabled As Boolean = Setting.EnablePdfVersion.Pages = EnabledStatus.Yes OrElse (Setting.EnablePdfVersion.Pages = EnabledStatus.Default AndAlso Setup.RenderingEngine.EnablePdfVersion.Pages = True)
        If PdfEnabled AndAlso PdfSupported(Setting.Language) Then
          Dim HrefPdf As String = PdfManager.HrefPdf(SourceType.Archive, DomainConfiguration, Setting.Name, Archive, Page, MetaTags.Title)
          Dim BtnPdf As WebControl = Components.Button(Setting, "PDF", HrefPdf, , IconType.Document)
          BottomContent.Controls.Add(BtnPdf)
        End If
      End If

      'Add Button Edit current page
      If CurrentUser.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
        Dim HrefEdit As String = Href(DomainConfiguration, Setting.Name, False, "edit.aspx", "archive", Archive, "lng", Setting.Language, "page", Page)
        Dim BtnEdit As WebControl = Components.Button(Setting, Phrase(Setting.Language, 3012), HrefEdit, , IconType.Pen, , True)
        BottomContent.Controls.Add(BtnEdit)
      End If

      If AddCommentsButton = True AndAlso MetaTags.MetaTag("EnabledComments") <> "False" Then
        'Block.Style.Add("clear", "right")
        'Add comments button
        Dim IdComments As Integer
        If MetaTags.MetaTag("IdComments") <> "" Then
          IdComments = MetaTags.MetaTag("IdComments")
        End If
        'Write a comments
        Dim HrefWriteComment As String
        If IdComments = 0 Then
          HrefWriteComment = Href(DomainConfiguration, Setting.Name, False, "forum.aspx", QueryKey.Reference, Archive & " " & Page & " " & Setting.Language, QueryKey.ForumId, ReservedForums.ArchiveComment, QueryKey.TopicId, IdComments, QueryKey.ActionForum, ForumManager.ActionType.NewTopic)
        Else
          HrefWriteComment = Href(DomainConfiguration, Setting.Name, False, "forum.aspx", QueryKey.ForumId, ReservedForums.ArchiveComment, QueryKey.TopicId, IdComments, QueryKey.ActionForum, ForumManager.ActionType.Reply)
        End If
        HrefWriteComment &= "#Edit"
        Dim BtnWriteComment As WebControl = Components.Button(Setting, Phrase(Setting.Language, 123), HrefWriteComment, , IconType.Pen, "_blank", True)
        If Setting.Aspect.SuggestTheBestChoiceByTheBlink Then
          MasterPage.Blink(BtnWriteComment)
        End If
        BottomContent.Controls.Add(BtnWriteComment)

        If IdComments Then
          'Read a comments
          Dim HrefComments As String = Href(DomainConfiguration, Setting.Name, False, "forum.aspx", QueryKey.Reference, Archive & " " & Page & " " & Setting.Language, QueryKey.ForumId, ReservedForums.ArchiveComment, QueryKey.TopicId, IdComments, QueryKey.ActionForum, ForumManager.ActionType.Show) & "#StartTopic"
          Dim BtnComments As WebControl = Components.Button(Setting, Phrase(Setting.Language, 129), HrefComments, , IconType.Document, , , "discussionUrl")
          BottomContent.Controls.Add(BtnComments)
        End If
      End If

      If HttpContext.Request.Browser.VBScript = True Then
        If Setting.IsTrue("MicrosoftAgent") Then
          Dim IdButton As Integer = Val(HttpContext.Items("LastIdContent")) + 1
          HttpContext.Items("LastIdContent") = IdButton
          TextContainer.ID = IdButton.ToString
          BottomContent.Controls.Add(Button(Setting, Phrase(Setting.Language, 3246), "vbscript:SpeechText(" & TextContainer.ClientID & ".innertext)", Nothing, IconType.MusicPlayer))
        End If
      End If

      If CharactersLimit Then
        'Show all
        Dim BtnComments As WebControl = Components.Button(Setting, Phrase(Setting.Language, 117), Canonical, , IconType.Document, , , "url")
        BottomContent.Controls.Add(BtnComments)
      End If

      'Control.Controls.Add(BottomContent) 'No correct: Don't validate a ItemProp "discussionUrl"
      Item.Controls.Add(BottomContent)  'OK is correct! Please don't change

      'Add photo album
      If CharactersLimit = 0 Then
        Dim NamePhotoAlbum As String = MetaTags.MetaTag("PhotoAlbum")
        If NamePhotoAlbum <> "" Then
          Dim PhotoAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(NamePhotoAlbum)
          If PhotoAlbum IsNot Nothing Then
            Control.Controls.Add(PhotoAlbum.ControlPhotos(Setting, True, DomainConfiguration, HttpContext))
            Control.Controls.Add(BR)
          End If
        End If
      End If
    End Sub

    Function IFrame(ByVal Width As String, ByVal Height As String, ByVal Src As String, Optional ByVal HtmlNoFrameSupport As String = Nothing, Optional Sandbox As String = "") As Control
      Dim Ctrl As New WebControls.WebControl(HtmlTextWriterTag.Iframe)

      If Sandbox IsNot Nothing Then
        'Anti Malware
        Ctrl.Attributes.Add("sandbox", Sandbox)
      End If

      Ctrl.Style.Add("width", Width)
      If Height IsNot Nothing Then
        Ctrl.Style.Add("height", Height)
      Else
        Ctrl.Style.Add("height", "2000px")
      End If

      Ctrl.Attributes("src") = Src
      If HtmlNoFrameSupport <> "" Then
        Dim Literal As New LiteralControl(HtmlNoFrameSupport)
        Ctrl.Controls.Add(Literal)
      End If
      Return Ctrl
    End Function

    Function PhoneNumber(ByVal PhoneContact As Configuration.ContactsConfiguration.PhoneContact, ByVal Language As LanguageManager.Language, ByVal Skin As Skin) As Control
      'Dim Table As New Table
      'Dim Row1 As WebControls.TableRow = Components.Row(2)
      Dim Box As New Control
      Select Case PhoneContact.Service
        Case Configuration.ContactsConfiguration.Service.Fax
        Case Configuration.ContactsConfiguration.Service.TechnicalSupport
          Box.Controls.Add(EnhancedLinkIcon(Skin, Components.IconType.TechSupport))
        Case Else
          Box.Controls.Add(EnhancedLinkIcon(Skin, Components.IconType.Help))
      End Select

      Dim Icon As WebControls.Label = IconUnicode(IconName.Thelephone, True)
      Box.Controls.Add(Icon)

      Dim Number As New WebControls.HyperLink
      Number.Style.Add("font-size", "larger")
      Number.Text = HttpUtility.HtmlEncode(PhoneContact.PhoneNumber)
      Number.NavigateUrl = "callto://" & CleanPhoneNumber(PhoneContact.PhoneNumber)
      Number.Attributes.Add("rel", "nofollow")
      Box.Controls.Add(Number)
      If PhoneContact.FreeCall Then
        Icon.ForeColor = System.Drawing.Color.Green
        Number.ForeColor = System.Drawing.Color.Green
        Box.Controls.Add(BR)
        Dim Text As New WebControls.Label
        Text.Style.Add("font-family", """Arial Black""")
        Text.Style.Add("font-size", "larger")
        Text.Text = Phrase(Language, 3197)
        Box.Controls.Add(Text)
      End If
      'Table.Rows.Add(Row1)

      Return Fieldset(PhoneContact.Text(Language), Box)

    End Function

    Function IconUnicode(Name As IconName, Optional Big As Boolean = False, Optional ToolTip As String = Nothing, Optional Href As String = Nothing, Optional Target As String = Nothing, Optional NoFollow As Boolean = True) As WebControl
      If Href IsNot Nothing Then
        Dim Icon As New WebControls.HyperLink
        Icon.CssClass = "icon"
        If Big Then
          Icon.Style.Add("font-size", "xx-large")
        Else
          Icon.Style.Add("font-size", "x-large")
        End If
        If ToolTip IsNot Nothing Then
          Icon.ToolTip = EncodingAttribute(ToolTip)
        End If
        Icon.NavigateUrl = Href 'HTML5
        If NoFollow Then
          Icon.Attributes.Add("rel", "nofollow")
        End If
        If Target IsNot Nothing Then
          Icon.Attributes.Add("target", Target)
        End If
        'Icon.Text = ChrW(Name)
        Icon.Text = Char.ConvertFromUtf32(Name)
        Return Icon
      Else
        Dim Icon As New WebControls.Label
        Icon.CssClass = "icon"
        If Big Then
          Icon.Style.Add("font-size", "xx-large")
        Else
          Icon.Style.Add("font-size", "x-large")
        End If
        If ToolTip IsNot Nothing Then
          Icon.ToolTip = EncodingAttribute(ToolTip)
        End If
        'Icon.Text = ChrW(Name)
        Icon.Text = Char.ConvertFromUtf32(Name)
        Return Icon
      End If
    End Function

    Function LabelWithIcon(Icon As IconName, Optional Text As String = Nothing, Optional Href As String = Nothing, Optional Target As String = Nothing, Optional NoFollow As Boolean = True) As Control
      Dim Label As New WebControls.HyperLink
      Label.CssClass = "label"
      Label.Controls.Add(IconUnicode(Icon))
      Label.Controls.Add(TextControl(Text))
      Label.ToolTip = EncodingAttribute(Text)
      Label.NavigateUrl = Href
      If NoFollow Then
        Label.Attributes.Add("rel", "nofollow")
      End If
      If Target IsNot Nothing Then
        Label.Attributes.Add("target", Target)
      End If
      Return Label
    End Function


    Enum IconName
      'http://www.alanwood.net/unicode/dingbats.html
      Anchor = 9875
      ArrowLeft = 8678
      ArrowRight = 8680
      ArrowUp = 8679
      ArrowDown = 8681
      Biohazard = 9763
      BlackStar = 9733
      Block = &H2297
      Bold = 119809
      BoxWithCheck = 9745
      BulletedList = 8788
      CircleBlack = 9899
      CheckMarkV = 10004
      CheckMarkX = 10008
      Conference = 10050
      Flag = &H25C9 '9873=no in Chrome
      Italic = 119868
      Underline = 95
      Undo = &H21B6
      LeftPointingIndex = 9754
      MalteseCross = 10016
      NotSmile = 9785
      One = 9312
      Paste = 10515
      Peace = 9774
      Pencil = 9998
      Redo = &H21B7
      ScissorBlack = 9986
      ScissorWhite = 9988
      Smile = 9787
      Sun = 9728
      Thelephone = 9742
      Three = 9314
      Two = 9313
      YinYang = 9775
      WritingHand = 9997
    End Enum

    Function CleanPhoneNumber(ByVal PhoneNumber As String) As String
      If PhoneNumber <> "" Then
        Dim StringBuilder As New System.Text.StringBuilder(PhoneNumber.Length)
        For Each C As Char In PhoneNumber.ToCharArray
          If Char.IsNumber(C) OrElse C = "+"c Then
            StringBuilder.Append(C)
          End If
        Next
        Return StringBuilder.ToString
      End If
      Return Nothing
    End Function

    Function CallCenter(ByVal Setting As SubSite) As Control
      Dim ShowFreeNumber As Boolean
      If Cookie("IsCustomer") <> "1" Then
        ShowFreeNumber = True
      End If
      Dim PhoneContact As Configuration.ContactsConfiguration.PhoneContact = Setting.PhoneContact(Configuration.ContactsConfiguration.Service.CustomerCare, ShowFreeNumber)
      If Not PhoneContact Is Nothing Then
        Dim Ctrl As New Control
        Dim ServiceCourtesy As New Label
        ServiceCourtesy.Text = Phrase(Setting.Language, 3200)
        Ctrl.Controls.Add(ServiceCourtesy)
        Ctrl.Controls.Add(PhoneNumber(PhoneContact, Setting.Language, Setting.Skin))
        Return (Fieldset(Phrase(Setting.Language, 3199), Ctrl))
      End If
      Return Nothing
    End Function

    Class BottomContent
      Public Canonical As String
      Public Bar As Control
    End Class

    Public MustInherit Class MasterPage
      Inherits System.Web.UI.MasterPage
      Public MustOverride ReadOnly Property Authors As Collections.Generic.List(Of User)
      Public MustOverride Sub AddAuthors(Author As User)
      Public MustOverride Sub AddItemService(ByVal Href As String, ByVal Text As String, ByVal ToolTip As String, Optional ByVal Level As Integer = 2)
      Public MustOverride Property User As User
      Public MustOverride Property Setting() As SubSite
      Public MustOverride Property Rating As Integer
      Public MustOverride Function AddButton(ByVal Text As String, ByVal Href As String, Optional ByVal ToolTip As String = Nothing, Optional ByVal Icon As IconType = Nothing, Optional ByVal Target As TargetForButton = TargetForButton.Self, Optional ByVal Nofollow As Boolean = False, Optional ByVal OnClick As String = Nothing, Optional Blink As Boolean = False) As WebControl
      Public MustOverride Sub AddButton(ByVal Button As ButtonsStandard, Optional Blink As Boolean = False)
      Public MustOverride Sub ShowElement(Optional ByRef LeftBar As Boolean = True, Optional ByRef RightBar As Boolean = True, Optional ByRef TopBar As Boolean = True, Optional ByRef BottomBar As Boolean = True)
      Public MustOverride Property UseGoogleOff() As Boolean
      Public MustOverride Property AdSenseDisabled() As Boolean
      Public MustOverride Property ContentPlaceHolder() As WebControls.ContentPlaceHolder
      Public MustOverride ReadOnly Property MainContainer As Control
      Public MustOverride ReadOnly Property UserToolsBar As Control
      Public MustOverride ReadOnly Property BottomContentCollection As Collections.Generic.List(Of BottomContent)
      Public MustOverride Sub AddBottomContent(ByVal Bar As Control, ByVal Canonical As String)
      Public MustOverride ReadOnly Property Left As Control
      Public MustOverride ReadOnly Property Top As Control
      Public MustOverride ReadOnly Property TopToLeft As Control
      Public MustOverride ReadOnly Property TopToRight As Control
      Public MustOverride ReadOnly Property Right As Control
      Public MustOverride ReadOnly Property Bottom As Control
      Public MustOverride Property ShowTopBar() As Boolean
      Public MustOverride Property ShowBottomBar() As Boolean
      Public MustOverride Property ShowLeftBar() As Boolean
      Public MustOverride Property ShowRightBar() As Boolean
      Public MustOverride Property ShowMenu() As Boolean
      Public MustOverride Property ShowMeteo() As Boolean
      Public MustOverride Property Author() As String
      Public MustOverride Property Description() As String
      Public MustOverride Property KeyWords() As String
      Public MustOverride Property Language() As String
      Public MustOverride Property ShortcutIcon() As String
      Public MustOverride Sub AddStyle(Css As String)
      Public MustOverride Property TitleDocument() As String
      Public MustOverride Sub SetTrace(ByVal ParamArray Controls() As Control)
      Public MustOverride Function MetaTag(ByVal Name As String) As HtmlMeta
      Public MustOverride Sub AddMetaTag(ByVal Name As String, ByVal Content As String, Optional ByVal HttpEquiv As String = Nothing)
      Public MustOverride Property OverlappingContent() As Boolean
      Public MustOverride Property MetaRevisitAfterDays() As Integer
      Public MustOverride Sub Blink(Control As Control)
      Public MustOverride Sub AddMessage(ByVal Text As String, Setting As SubSite, Optional ByVal ToolTip As String = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Type As MessageType = MessageType.Normal)
      Public MustOverride Sub AddMessage(Setting As SubSite, ByVal IDText As Integer, Optional ByVal IDToolTip As Integer = Nothing, Optional ByVal Href As String = Nothing, Optional ByVal Type As MessageType = MessageType.Normal)
      Public MustOverride Sub AddMessage(Control As Control)
      Enum TargetForButton
        Self
        Messenger
        Blank
      End Enum
      Sub AddHeader(ByVal Text As String)
        Dim Header As New LiteralControl
        Header.Text = Text
        Page.Header.Controls.Add(Header)
      End Sub
    End Class

    'Public MustInherit Class CardUser
    '	Inherits System.Web.UI.UserControl
    '	Shared Function CardUserControlName(ByVal User As User) As String
    '		If Not User Is Nothing Then
    '			Return "CardUser_" & User.Username
    '		End If
    '	End Function
    '	Public MustOverride Property User() As User
    '	Public MustOverride Property Hide() As Boolean
    '	Public MustOverride Function IDAssigned() As String
    '	Public MustOverride Property Setting() As SubSite
    '	Public MustOverride Property VisibleCloseButton() As Boolean
    'End Class

    Function OnlineUser(ByVal Setting As SubSite, Optional ByVal OnlyThisDomain As Boolean = Nothing, Optional ByVal Link As Boolean = True) As Control
      Dim ListRegistered, ListNotRegistered, ListCrawler As New WebControl(HtmlTextWriterTag.Div)
      Dim Result As New WebControls.WebControl(HtmlTextWriterTag.Fieldset)
      Dim Title As New WebControls.Label
      Title.Style.Add("font-size", "xx-larger")
      Title.Text = Phrase(Setting.Language, 148) & ": "
      Result.Controls.Add(Title)

      Dim CountRegistered, CountNotRegistered, CountCrawler As Integer
      SyncLock OnLineUsers

        Dim MyDomain As String = Nothing
        If OnlyThisDomain Then
          MyDomain = CurrentDomain()
        End If

        Dim User As User
        Dim Added As New Collections.Specialized.StringCollection
        For Each Online As OnlineUser In OnLineUsers.Values
          User = Online.User
          If Not OnlyThisDomain OrElse MyDomain = Online.Domain OrElse User.Username <> "" Then
            If User.Username = "" Then
              If Online.IsCrawler Then
                CountCrawler += 1
              Else
                CountNotRegistered += 1
              End If
              Dim IP As String = User.IP
              'Dim Flag As New WebControl(HtmlTextWriterTag.Img)
              'Flag.Attributes.Add("src", "ip2flag.aspx?ip=" & IP)
              Dim HyperLink As New HyperLink
              HyperLink.BorderWidth = 1
              HyperLink.Text = IP
              If IPIsBlocked(IP) Then
                HyperLink.Style.Add("text-decoration", "line-through")
              End If
              If Link Then
                HyperLink.NavigateUrl = NavigateUrlIpLookup & IP
                HyperLink.Target = "_blank"
              End If
              'List.Controls.Add(Flag)
              If Online.IsCrawler Then
                ListCrawler.Controls.Add(HyperLink)
                ListCrawler.Controls.Add(New LiteralControl("   "))
              Else
                ListNotRegistered.Controls.Add(HyperLink)
                ListNotRegistered.Controls.Add(New LiteralControl("   "))
              End If
            ElseIf Not Added.Contains(User.Username) Then
              Added.Add(User.Username)
              CountRegistered += 1
              ListRegistered.Controls.Add(QuickInfoUser(Setting, User))
              ListRegistered.Controls.Add(New LiteralControl("   "))
            End If
          End If
        Next
      End SyncLock

      Title.Text &= CountRegistered + CountNotRegistered + CountCrawler

      Dim PanelListRegistered As New Control
      PanelListRegistered.Controls.Add(AddTitle(Phrase(Setting.Language, 132) & ": " & CountRegistered))
      PanelListRegistered.Controls.Add(ListRegistered)

      Dim PanelListNotRegistered As New Control
      PanelListNotRegistered.Controls.Add(AddTitle(Phrase(Setting.Language, 133) & ": " & CountNotRegistered))
      PanelListNotRegistered.Controls.Add(ListNotRegistered)

      Dim PanelListCrawler As New Control
      PanelListCrawler.Controls.Add(AddTitle(Phrase(Setting.Language, 142) & ": " & CountCrawler))
      PanelListCrawler.Controls.Add(ListCrawler)

      Result.Controls.Add(PanelListRegistered)
      Result.Controls.Add(New LiteralControl("<hr />"))  'horizontal line

      Result.Controls.Add(PanelListNotRegistered)
      If Not Setup.Performance.InhibitSessionForCrawlers Then
        Result.Controls.Add(New LiteralControl("<hr />"))  'horizontal line

        Result.Controls.Add(PanelListCrawler)
      End If

      Return Result
    End Function

    Private Function AddTitle(ByVal Text As String) As Control
      Dim Title As New WebControl(HtmlTextWriterTag.H3)
      Title.Controls.Add(TextControl(Text))
      Return Title
    End Function

    Public Sub AddCells(ByRef Row As HtmlTableRow, ByVal Cells As Integer, Optional ByVal Nowrap As Boolean = False)
      For n As Integer = 1 To Cells
        Dim Cell As New HtmlTableCell
        If Nowrap Then
          Cell.Style.Add("white-Space", "nowrap") 'html5
        End If
        Row.Cells.Add(Cell)
      Next
    End Sub

    Public Sub AddHeaderCells(ByRef Row As HtmlTableRow, ByVal Cells As Integer, Optional ByVal Nowrap As Boolean = False)
      For n As Integer = 1 To Cells
        Dim cell As New HtmlTableCell("th")
        If Nowrap Then
          cell.Style.Add("white-Space", "nowrap") 'html5
        End If
        Row.Controls.Add(cell)
      Next
    End Sub

    Public Function Row(ByRef Cells As Integer, Optional ByRef HAlign As HorizontalAlign = HorizontalAlign.NotSet, Optional ByVal Nowrap As Boolean = False) As HtmlTableRow
      Dim NRow As New HtmlTableRow
      If HAlign Then
        NRow.Style.Add("text-align", LCase(HAlign.ToString)) 'html5
      End If
      AddCells(NRow, Cells, Nowrap)
      Return NRow
    End Function

    Public Function HeaderRow(ByRef Cells As Integer, Optional ByRef HAlign As HorizontalAlign = HorizontalAlign.NotSet, Optional ByVal Nowrap As Boolean = False) As HtmlTableRow
      Dim NRow As New HtmlTableRow
      If HAlign Then
        NRow.Style.Add("text-align", LCase(HAlign.ToString)) 'html5
      End If
      AddHeaderCells(NRow, Cells, Nowrap)
      Return NRow
    End Function

    Sub AddLabel(ByRef Control As HtmlTableCell, ByRef Text As String, Optional ByVal VerticalText As Boolean = False)
      If VerticalText Then
        Dim Label As New WebControls.Label
        Label.Attributes.Add("class", "VerticalText")
        Label.Controls.Add(TextControl(Text))
        Control.Controls.Add(Label)
      Else
        Control.Controls.Add(TextControl(Text))
      End If
    End Sub

    Function Link(ByVal NavigateUrl As String, Optional ByRef Text As String = Nothing, Optional ByVal ToolTip As String = Nothing, Optional ByVal Bold As Boolean = False, Optional ByVal Target As String = Nothing, Optional Rel As Rel = Rel.None, Optional Itemprop As String = Nothing) As WebControls.HyperLink
      Link = New WebControls.HyperLink
      If Itemprop IsNot Nothing Then
        Link.Attributes.Add("itemprop", Itemprop)
      End If
      If Rel <> Components.Rel.None Then
        Link.Attributes("rel") = Rel.ToString.ToLower
      End If
      Link.NavigateUrl = NavigateUrl
      If Bold Then
        Link.Style.Add("font-weight", "bold !important")
      End If
      Link.Text = HttpUtility.HtmlEncode(Text)
      Link.ToolTip = EncodingAttribute(ToolTip)
      Link.Target = Target
    End Function

    Enum Rel
      None
      Alternate
      Author
      Bookmark
      Help
      License
      [Next]
      Nofollow
      Noreferrer
      Prefetch
      Prev
      Search
      Tag
    End Enum

    Sub AddLiteral(ByRef Control As Control, ByRef Text As String)
      Dim Literal As New WebControls.Literal
      Literal.Text = Text
      Control.Controls.Add(Literal)
    End Sub

    Function Table(ByVal Rows As Integer, ByVal Columns As Integer, Optional ByRef HAlign As HorizontalAlign = HorizontalAlign.NotSet, Optional ByVal Nowrap As Boolean = False, Optional FirstIsHeader As Boolean = False) As HtmlTable
      Dim T As New HtmlTable
      For R As Integer = 1 To Rows
        If R = 1 AndAlso FirstIsHeader Then
          T.Rows.Add(HeaderRow(Columns, HAlign, Nowrap))
        Else
          T.Rows.Add(Row(Columns, HAlign, Nowrap))
        End If
      Next
      Return T
    End Function

    Function Literal(ByVal Text As String) As WebControls.Literal
      Dim Ctrl As New WebControls.Literal
      Ctrl.Text = Text
      Return Ctrl
    End Function

    Function PdfButton(ByVal Href As String) As Control
      Dim Pdf As New WebControls.HyperLink
      Pdf.CssClass = "Pdf"
      Pdf.Text = "Pdf"
      Pdf.ToolTip = "Pdf"
      Pdf.NavigateUrl = Href
      Return Pdf
    End Function

    Function FlashControl(ByRef FlashFile As String, ByVal Width As Integer, ByVal Height As Integer, Optional Hide As Boolean = False) As Control
      If InStr(FlashFile, "/") = 0 Then
        FlashFile = FlashResources & "/" & FlashFile
      End If
      Dim Obj As New WebControl(HtmlTextWriterTag.Object)
      Obj.Attributes.Add("type", "application/x-shockwave-flash")
      Obj.Attributes.Add("data", FlashFile)
      If Hide Then
        Obj.Width = 0
        Obj.Height = 0
      Else
        Obj.Width = Width
        Obj.Height = Height
      End If
      Obj.BorderWidth = 0

      'W3C valid code
      Obj.Controls.Add(Literal("<param name=""movie"" value=""" & FlashFile & """ />"))
      Obj.Controls.Add(Literal("<param name=""quality"" value=""High"" />"))

      Return Obj

    End Function

    Public Function ModPLayer() As WebControls.WebControl
      Dim Control As WebControl
      Control = FlashControl(FlashResources & "/BitboyApp.swf", 150, 57, Setup.RenderingEngine.HideModPlayer)
      Control.CssClass = "ModPlayer"
      Return Control
    End Function

    Enum FolderType
      Normal
      Pictures
      Videos
    End Enum

    Function Folder(ByVal Text As String, ByVal ToolTip As String, ByVal Href As String, ByRef Setting As Config.SubSite, Optional ByRef Level As Integer = 0, Optional ByVal FolderType As FolderType = Components.FolderType.Normal) As Control
      'Dim Text
      Dim Icon As IconType
      Dim Box As New WebControl(HtmlTextWriterTag.Span)
      Box.CssClass = "Folder"
      'Box.CssClass = "Menu"
      If Level = 0 Then
        Select Case FolderType
          Case Components.FolderType.Normal
            Icon = IconType.Folder1
          Case Components.FolderType.Pictures
            Icon = IconType.FolderPics1
          Case Components.FolderType.Videos
            Icon = IconType.FolderVideo1
        End Select
      Else
        Select Case FolderType
          Case Components.FolderType.Normal
            Icon = IconType.Folder
          Case Components.FolderType.Pictures
            Icon = IconType.FolderPics
          Case Components.FolderType.Videos
            Icon = IconType.FolderVideo
        End Select
        If Level < 0 Then
          'Arrow Right
          For N As Integer = 1 To -Level
            Box.Controls.Add(IconUnicode(IconName.ArrowLeft))
          Next
        ElseIf Level > 0 Then
          'Arrow Left
          For N As Integer = 1 To Level
            Box.Controls.Add(IconUnicode(IconName.ArrowRight))
          Next
        End If
      End If
      Box.Controls.Add(Components.EnhancedLinkIcon(Setting.Skin, Icon, ToolTip, Href, Text))
      Return Box
    End Function

    Sub AddTagSamp(ByRef Html As String)
      'Dim Subsite As SubSite = CurrentSetting()
      'Dim Html2 As String = ReplaceText(Html, "<p>", "")
      'Html2 = ReplaceText(Html, "</p>", "<br />")
      Dim Html2 As String = HtmlMapping(Html)
      Dim Paragraphs As String() = Split(Html2, vbLf)
      Dim Flag As Boolean = False
      Dim Position, EndLinePosition, CountLine As Integer

      Dim CodeBlocks As New List(Of List(Of Position))
      Dim CodeBlock As List(Of Position) = Nothing
      For Each Paragraph As String In Paragraphs
        CountLine += 1
        Position = InStr(Position + 1, Html, Paragraph)
        If Position <> 0 Then
          If IsCode(Paragraph) Then
            EndLinePosition = Position + Len(Paragraph)
            If Not Flag Then
              Flag = True
              CodeBlock = New List(Of Position)
              CodeBlocks.Add(CodeBlock)
            End If
            Dim StartEnd As New Position(Position, EndLinePosition)
            CodeBlock.Add(StartEnd)
          Else
            If Trim(Paragraph) <> "" Then
              If Flag Then
                Dim StartEnd As New Position(Position, EndLinePosition)
                CodeBlock.Add(StartEnd)
                Flag = False
              End If
            End If
          End If
          If CountLine = Paragraph.Count AndAlso Flag = True Then
            Dim StartEnd As New Position(Position, EndLinePosition)
            CodeBlock.Add(StartEnd)
          End If
        End If
      Next

      For N As Integer = CodeBlocks.Count - 1 To 0 Step -1
        CodeBlock = CodeBlocks(N)
        If CodeBlock.Count >= 3 Then
          Dim PositionOpenTag, PositionCloseTag As Integer
          PositionOpenTag = CodeBlock(0).StartPosition
          PositionCloseTag = CodeBlock(CodeBlock.Count - 1).EndPosition
          Dim PartBefore, Block, PartNext As String
          PartBefore = Html.Substring(0, PositionOpenTag - 1)
          Block = Mid(Html, PositionOpenTag, PositionCloseTag - PositionOpenTag)
          PartNext = Mid(Html, PositionCloseTag)
          Block = HttpUtility.HtmlEncode(InnerText(Block))
          Block = "<samp>" & ReplaceBin(Block, vbCrLf, "<br />") & "</samp>"
          Html = PartBefore & Block & PartNext
          'For NPosition As Integer = CodeBlock.Count - 1 To 0 Step -1
          '	Dim StartEnd As Position = CodeBlock(NPosition)
          '	If NPosition = CodeBlock.Count - 1 Then
          '		Html = Html.Substring(0, StartEnd.EndPosition - 1) & "</samp>" & Mid(Html, StartEnd.EndPosition)
          '	End If
          '	If NPosition = 0 Then
          '		Html = Html.Substring(0, StartEnd.StartPosition - 1) & "<samp>" & Mid(Html, StartEnd.StartPosition)
          '	End If
          'Next
        End If
      Next


    End Sub

    Private Class Position
      Public StartPosition As Integer
      Public EndPosition As Integer
      Sub New(ByVal StartPosition As Integer, ByVal EndPosition As Integer)
        Me.StartPosition = StartPosition
        Me.EndPosition = EndPosition
      End Sub
    End Class

    Private Function HtmlMapping(ByVal Html As String) As String
      If Html <> "" Then
        AddPoll(CurrentDomainConfiguration, CurrentSetting, Html, PollContext.Forum, Nothing)
        Html = ReplaceBin(Html, vbCr, "")
        Html = ReplaceBin(Html, vbLf, "")
        Html = ReplaceText(Html, "<p>", "")
        Html = ReplaceText(Html, "</p>", "<br />")

        Dim StringBuilder As New System.Text.StringBuilder(Html.Length)
        Dim Chr As Char
        Dim TagName As String = Nothing
        Dim ActionLevel As AcquiringTag = AcquiringTag.Open
        Dim Tag As Boolean, EndTagName As Boolean
        Dim NoInner As String = Nothing
        For N As Integer = 0 To Html.Length - 1
          Chr = Html.Chars(N)

          Select Case Chr
            Case "<"c
              Tag = True
              EndTagName = False
              TagName = ""
            Case ">"c
              Tag = False

              If TagName.StartsWith("!") Then
                ActionLevel = AcquiringTag.Neutral
              End If
              Select Case TagName
                Case "script", "style", "code", "samp", "h1", "h2", "h3", "h4", "h5", "h6", "address", "pre"
                  Select Case ActionLevel
                    Case AcquiringTag.Open
                      If NoInner Is Nothing Then
                        NoInner = TagName
                      End If
                    Case AcquiringTag.Close
                      If StrComp(NoInner, TagName) = 0 Then
                        NoInner = Nothing
                      End If
                  End Select
              End Select

              If NoInner Is Nothing Then
                If TagName.StartsWith("!") Then
                  'No action for this tags (join to mother)
                Else
                  Select Case TagName
                    Case "br"
                      StringBuilder.Append(vbLf)
                  End Select
                End If
              End If
              ActionLevel = AcquiringTag.Open
            Case Else
              If Tag Then
                If EndTagName = False Then
                  If Char.IsLetterOrDigit(Chr) OrElse Chr = "!"c Then
                    TagName &= Char.ToLower(Chr)
                  ElseIf Chr <> "/" Then
                    EndTagName = True
                  End If
                End If
                If Chr = "/"c Then
                  If TagName = "" Then
                    ActionLevel = AcquiringTag.Close
                  ElseIf Html.Chars(N + 1) = ">" Then
                    ActionLevel = AcquiringTag.Neutral
                  End If
                End If
              ElseIf NoInner Is Nothing Then
                StringBuilder.Append(Chr)
              End If
          End Select
        Next
        Return StringBuilder.ToString
      End If
      Return Nothing
    End Function
    Private Enum AcquiringTag
      Open
      Close
      Neutral
    End Enum

    Private Function IsCode(ByVal Html As String) As Boolean
      Dim Text As String
      'Text = Replace(Html, "&nbsp;", " ")
      Text = HttpUtility.HtmlDecode(Html)

      Dim TrimText As String = Trim(Text)

      'Remove emoticons
      If TrimText <> "" AndAlso TrimText.IndexOfAny("()-|".ToCharArray) <> -1 Then
        For Each N As Emoticons In [Enum].GetValues(GetType(Emoticons))
          TrimText = ReplaceBin(TrimText, HttpUtility.HtmlEncode(EmoticonShortcut(N)), "")
        Next
      End If

      If TrimText <> "" Then
        Dim LastChr As Char = TrimText(TrimText.Length - 1)
        If (Not Char.IsPunctuation(LastChr) OrElse LastChr = ")"c OrElse LastChr = "}"c OrElse LastChr = "{"c) OrElse LastChr = ";"c <> 0 Then

          'Verify if is a linee of list: 1).. 2).. 3).. 
          For Each Chr As Char In TrimText
            Dim Finded As Boolean
            If Char.IsNumber(Chr) Then
              Finded = True
            ElseIf Chr = ")" AndAlso Finded Then
              Return False
            Else
              Exit For
            End If
          Next

          'Veryfi if is a Rem
          If InStr(TrimText, "Rem ") Then
            Return True
          End If
          If TrimText(0) = "'"c AndAlso LastChr <> "'" Then
            Return True
          End If
          If InStr(TrimText, "//") <> 0 AndAlso InStr(TrimText, "://") = 0 Then
            'JavaScript Rem
            Return True
          End If
          If TrimText.StartsWith("*") OrElse TrimText.StartsWith("*/") Then
            'CSS Rem
            Return True
          End If

          'Verify if is a CSS class definition
          If TrimText.StartsWith(".") Then
            Return True
          End If

          'Verify if is a html code
          If InStr(TrimText, "<") AndAlso InStr(TrimText, ">") Then
            Return True
          End If
          If TrimText.StartsWith("<") OrElse TrimText.EndsWith(">") Then
            Return True
          End If

          'Verify if is a html JavaScript
          If InStr(TrimText, "{") OrElse InStr(TrimText, "}") Then
            Return True
          ElseIf TrimText.Last = ";"c Then
            Return True
          End If

          'Remove Rem Part and text into "" (for VB code)
          Dim StringBuilder As New StringBuilder(Len(TrimText))
          Dim InsideString As Boolean
          For Each Chr As Char In TrimText
            Select Case Chr
              Case """"
                InsideString = Not InsideString
              Case Else
                If InsideString = False Then
                  If Chr = "'" Then
                    'Hete start a Rem comment
                    Exit For
                  End If
                  StringBuilder.Append(Chr)
                End If
            End Select
          Next
          TrimText = StringBuilder.ToString

          If InStr(TrimText, "=") <> 0 OrElse InStr(TrimText, ">") <> 0 OrElse InStr(TrimText, "<") <> 0 Then
            'Verifi if is a mathematic operation code
            Dim MathKeys As String() = {"+", "-", "/", "\", "^", "*"}
            For Each MathKey In MathKeys
              If InStr(TrimText, MathKey) Then
                Return True
              End If
            Next

            'Verifi if is a string operation code
            If InStr(TrimText, "&") <> 0 OrElse InStr(TrimText, """") <> 0 Then
              Return True
            End If

          End If


          'Verify if into text have 2 consecutive words with lowers caracers
          Dim PartOfText, FirstWordFinded, HaveUpper As Boolean
          For Each Chr As Char In TrimText
            If Char.IsLetterOrDigit(Chr) Then
              If Char.IsUpper(Chr) Then
                HaveUpper = True
              End If

              If FirstWordFinded = True Then
                FirstWordFinded = False
                If PartOfText = True Then
                  If HaveUpper = False Then
                    Return False
                  End If
                End If
              End If
              PartOfText = True
            ElseIf Chr = " "c Then
              FirstWordFinded = True
            Else
              FirstWordFinded = False
              PartOfText = False
              HaveUpper = False
            End If
          Next

          'Verify if the text is not a all uppercase text
          If Text = UCase(Text) Then
            Return False
          End If

          Select Case TrimText.Last
            Case "."c, ":"c, "?"c, "!"c
            Case Else
              'Verify if is a "End If", "End Class", "End Sub" or similar
              Dim Space As Boolean
              Dim AllStartWithUpper As Boolean = True
              For Each Chr As Char In TrimText
                If Space AndAlso Char.IsLetter(Chr) Then
                  If Char.IsLower(Chr) Then
                    AllStartWithUpper = False
                    Exit For
                  End If
                End If
                If Chr = " "c Then
                  Space = True
                Else
                  Space = False
                End If
              Next
              If AllStartWithUpper Then
                Return True
              End If

              'Verify if contain "classname.property", or "classname.function" or similar
              Dim Dot As Boolean
              For Each Chr As Char In TrimText
                If Dot AndAlso Char.IsLetter(Chr) Then
                  Return True
                End If
                If Chr = "."c Then
                  Dot = True
                Else
                  Dot = False
                End If
              Next
          End Select

          'Verify if is a simple text without operator
          Dim IsNotSimpleText As Boolean
          For Each Chr As Char In TrimText
            If Char.IsLetter(Chr) Then
            ElseIf Char.IsNumber(Chr) Then
            Else
              Select Case Chr
                Case " "c, ","c, "'"c, "."c, "’"c, "‘"c, "!"c, "?"c, "¿"c, "？"c, "。"c, "，"c
                Case Else
                  IsNotSimpleText = True
                  Exit For
              End Select
            End If
          Next
          If Not IsNotSimpleText Then
            Return False
          End If

          'At the end is a Code text
          Return True
        Else
          'Verifi if is a rem
        End If
      End If
      Return False
    End Function

    Function TextControl(Text As String) As Control
      Return New LiteralControl(HtmlEncode(Text))
    End Function

    Function DateControl([Date] As Date, Setting As SubSite) As HtmlControl
      Dim PubDateLabel As New HtmlGenericControl("time")
      PubDateLabel.Attributes.Add("itemprop", "dateCreated")
      PubDateLabel.Attributes.Add("datetime", [Date].ToString("s"))
      PubDateLabel.InnerText = [Date].AddSeconds(CurrentUser.TimeOffsetSeconds).ToString(Setting.DateFormat, Setting.Culture)
      Return PubDateLabel
    End Function

  End Module

End Namespace
