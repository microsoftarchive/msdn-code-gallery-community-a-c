'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports Microsoft.VisualBasic
Imports System.Xml.Serialization

Namespace WebApplication

  Public Module PhotoManager
    Function EnabledToMaintainOriginalImageSize(ByVal User As User, ByVal Setting As SubSite) As Boolean
      Return User.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior
    End Function

    Public MustInherit Class Thumbnail
      Inherits System.Web.UI.UserControl
      Public MustOverride Property src() As String
      Public MustOverride Property Target_Blank() As Boolean
      Public MustOverride Property Href() As String
      Public MustOverride Property Title() As String
      Public MustOverride Property Description() As String
      Public MustOverride Property Size() As Integer
      Public MustOverride Property FixHeight() As Boolean
    End Class

    Public MustInherit Class ImageBox
      Inherits System.Web.UI.UserControl
      Public MustOverride Sub SetImage(ByVal Photo As Photo, ByVal Setting As SubSite, Optional ByVal Size As Integer = Nothing)
    End Class

    Sub AddScriptClientPreviewPhoto(ByVal PhotoList As WebControl, ByVal ImagePreview As Control)
      Dim NamePrviewControl As String = ImagePreview.ClientID
      'Add script client code to preview photo
      Dim ScriptCode1 As String = _
      "showpreview(document.getElementById(""" & PhotoList.ClientID & """).value);" & vbCrLf
      PhotoList.Parent.Controls.Add(Script(ScriptCode1, Components.ScriptLanguage.javascript, PhotoList, "onchange"))

      Dim ScriptCode2 As String = _
      "function showpreview(imgcode){" & vbCrLf & _
       "if (imgcode){" & vbCrLf & _
         "parts=imgcode.split(""."");" & vbCrLf & _
         "document.getElementById(""" & NamePrviewControl & """).src=""viewthumb.aspx?album=""+parts[0]+""&id=""+parts[1];" & vbCrLf & _
       "}else{document.getElementById(""" & NamePrviewControl & """).src="""";}" & vbCrLf & _
      "}" & vbCrLf & _
      "showpreview(document.getElementById(""" & PhotoList.ClientID & """).value)"
      PhotoList.Parent.Controls.Add(Script(ScriptCode2, Components.ScriptLanguage.javascript))
    End Sub

    Sub AddScriptClientPopulateListPhotos(ByRef WhereSorceSelector As Control, ByVal PhotoList As WebControl, ByVal RadioButtonsText() As String, ByVal Checked As Integer, ByVal SelectedValue As String, ByVal DefaultJavascriptPhotosList As Integer, ByVal ParamArray JavascriptPhotosList() As String)
      'Not add radio button if RadioButtonsText() is nothing

      Dim ScriptLoadSource As String = _
      "function LoadSource(N){" & vbCrLf & _
      "switch(N){" & vbCrLf
      If JavascriptPhotosList IsNot Nothing Then
        For Each Src As String In JavascriptPhotosList
          If Src <> "" Then
            Dim N As Integer
            If Not RadioButtonsText Is Nothing Then
              Dim Radio As New Web.UI.WebControls.RadioButton
              Radio.ID = N & "Radio"
              Radio.GroupName = "PhotoSource"
              Radio.Text = RadioButtonsText(N)
              Radio.Attributes.Add("onclick", "LoadSource(" & N & ")")
              If Checked = N Then
                Radio.Checked = True
              End If
              WhereSorceSelector.Controls.Add(BR)
              WhereSorceSelector.Controls.Add(Radio)
            End If
            ScriptLoadSource &= _
            "case " & N & ":" & vbCrLf & _
            "UPDLIST(""" & Src & """);break;" & vbCrLf
            N += 1
          End If
        Next
      End If
      ScriptLoadSource &= _
      "}" & vbCrLf & _
      "}" & vbCrLf & _
      "function UPDLIST(src){" & vbCrLf & _
       "xhead=document.getElementsByTagName('head')[0];" & vbCrLf & _
       "xscript=document.createElement('script');" & vbCrLf & _
       "xscript.language='javascript';" & vbCrLf & _
       "xscript.type= 'text/javascript';" & vbCrLf & _
       "xscript.src=src;" & vbCrLf & _
       "xhead.appendChild(xscript);" & vbCrLf & _
      "}"


      PhotoList.Parent.Controls.Add(Script(ScriptLoadSource, Components.ScriptLanguage.javascript))


      Dim ScriptPopulate As String = _
      "function UpdateImageList(Texts,Values){" & vbCrLf & _
       "showpreview("""");" & vbCrLf & _
       "var PhotoList=document.getElementById(""" & PhotoList.ClientID & """);" & vbCrLf & _
       "PhotoList.length=0;" & vbCrLf & _
      "for (nidx = 0; nidx < Texts.length; nidx++){" & vbCrLf & _
       "var oOpt = document.createElement(""OPTION"");" & vbCrLf & _
       "oOpt.text = unescape(Texts[nidx]);" & vbCrLf & _
       "oOpt.value = unescape(Values[nidx]);" & vbCrLf & _
       "if (oOpt.value==""""){oOpt.style.color = ""Red"";oOpt.style.backgroundColor = ""Yellow"";}" & vbCrLf
      If SelectedValue <> "" Then
        ScriptPopulate &= "if (oOpt.value==""" & AbjustForJavascriptString(SelectedValue) & """){oOpt.selected=true;showpreview(""" & AbjustForJavascriptString(SelectedValue) & """);}" & vbCrLf
      End If
      ScriptPopulate &= "try{PhotoList.add(oOpt, null);}catch(ex){PhotoList.add(oOpt);}" & vbCrLf & _
      "}" & vbCrLf & _
       "oOpt = null;" & vbCrLf & _
      "}"

      PhotoList.Parent.Controls.Add(Script(ScriptPopulate, Components.ScriptLanguage.javascript))

      If Not RadioButtonsText Is Nothing Then
        Dim CodeLoad As String
        CodeLoad = "LoadSource(" & Checked & ");" & vbCrLf
        PhotoList.Parent.Controls.Add(Script(CodeLoad, Components.ScriptLanguage.javascript))
      End If

    End Sub

    Public Sub SetPhotoList(ByVal PhotoList As Control, ByVal ImgPreview As Control, ByVal Setting As SubSite, ByVal TagPhotoSelect As String, ByVal DefaultJavascriptPhotosList As Integer, ByVal ParamArray JavascriptPhotosList() As String)

      AddScriptClientPopulateListPhotos(Nothing, PhotoList, Nothing, Nothing, TagPhotoSelect, DefaultJavascriptPhotosList, JavascriptPhotosList)

      'Add code preview photo
      AddScriptClientPreviewPhoto(PhotoList, ImgPreview)

      'Dim Code As String = "LoadSource(0);"
      'ScriptPlaceHolder.Controls.Add(Script(Code, ScriptLanguage.javascript))

    End Sub

    Function JavascriptPhotosList(ByVal Setting As SubSite, ByVal PhotoAlbum As String, Optional ByVal OnlyOfAuthor As String = Nothing, Optional ByVal AdditionalPhotoAlbum As String = Nothing) As String
      If OnlyOfAuthor <> "" Then
        Return Common.Href(Setting.Name, False, "thumbnails.aspx", "operation", PhotoManager.Operations.MakeJavascriptPhotosList, QueryKey.ViewAlbum, PhotoAlbum, "AddAlbum", AdditionalPhotoAlbum, "author", OnlyOfAuthor)
      Else
        Return Common.Href(Setting.Name, False, "thumbnails.aspx", "operation", PhotoManager.Operations.MakeJavascriptPhotosList, QueryKey.ViewAlbum, PhotoAlbum, "AddAlbum", AdditionalPhotoAlbum)
      End If
    End Function

    Public Sub AddPhotos(ByRef ListPhotos As ListPhotos, ByVal Album As PhotoAlbum, ByVal Language As LanguageManager.Language, Optional ByVal IncludeSunfolder As Boolean = True, Optional ByVal OnlyThisAuthor As String = Nothing)
      'add name PhotoAlbum
      If Album IsNot Nothing Then
        Dim ItemAlbum As New TextValue
        ItemAlbum.text = "[" & UCase(TruncateText(Album.Title(Language), 30)) & "]:"
        ListPhotos.item.Add(ItemAlbum)
        For Each Photo As Photo In Album.PhotosSortedByTitle(Language)
          If OnlyThisAuthor = Nothing Or StrComp(Photo.Author, OnlyThisAuthor, CompareMethod.Text) = 0 Then
            Dim TextValue As New TextValue
            Dim Text As String = Photo.Title(Language)
            If Photo.Description(Language) <> "" Then
              Text &= " (" & TruncateText(Photo.Description(Language), 30) & ")"
            End If
            If Text = "" Then
              Text = Photo.Name
            End If
            TextValue.text = Text
            TextValue.value = Photo.NameCode
            ListPhotos.item.Add(TextValue)
          End If
        Next
        For Each SubAlbum As PhotoAlbum In Album.PhotoAlbums(False)
          AddPhotos(ListPhotos, SubAlbum, Language, IncludeSunfolder, OnlyThisAuthor)
        Next
      End If
    End Sub
    Public Class ListPhotos
      <XmlElementAttribute("item")> _
      Public item As New TextValues
    End Class
    Public Class TextValues
      Inherits CollectionBase

      Public Sub Add(ByVal Item As TextValue)
        Dim I As Integer = List.Add(Item)
      End Sub

      Default Public ReadOnly Property Item(ByVal Index As Integer) As TextValue
        Get
          Return CType(List.Item(Index), TextValue)
        End Get
      End Property
    End Class

    Public Function ExtensionFile(ByVal Format As Photo.ImageType) As String
      If Format = Photo.ImageType.Jpeg Then
        Return "jpg"
      Else
        Return Format.ToString
      End If
    End Function
    Enum EditablePermission As Integer
      None = 0
      Author = 1
      Permitted = -1
      OnlyIfEmpty = 2
    End Enum
    Enum Operations As Integer
      View
      UploadPhotos
      Edit
      CreateSubFotoAlbum
      Delete
      ViewXML
      MakeJavascriptPhotosList
    End Enum

    Class Attributes
      Public Deletable As Permission
      Public Editable As EditablePermission
      Public Hide As Boolean
      Public AddPermitted As Permission
      Public SubPhotoAlbumsNotCreatable As Boolean
      Public SubLevel As Integer
      Public Author As String
      Public Title As String
      Public Description As String
      Public Container As String
      Public Name As String
      Public TypeObject As TypeObject
    End Class
    Enum TypeObject
      Photo = 0
      PhotoAlbum = 1
    End Enum
    Enum Permission
      None = 0
      Author = 1
      Permitted = -1
    End Enum

    Private Function OperationAvailable(ByRef User As Authentication.User, ByRef Setting As SubSite, ByRef Attributes As Attributes, ByRef Operation As Operations) As Boolean
      Select Case Attributes.TypeObject
        Case TypeObject.PhotoAlbum
        Case TypeObject.Photo
          Select Case Operation
            Case Operations.Delete, Operations.Edit, Operations.View
            Case Else
              Return False
              Exit Function
          End Select
      End Select

      If User.Role(Setting.Name) >= Authentication.User.RoleType.WebMaster Then
        Return True
      Else
        Select Case Operation
          Case Operations.View
            If Attributes.Hide = True Then
              Return EnableUserAtOperations(User, Attributes.Author, Setting)
            End If
          Case Operations.CreateSubFotoAlbum
            If Attributes.SubLevel < MaxSubLevelPhotoAlbum Then
              If Attributes.SubPhotoAlbumsNotCreatable = False Then
                If Attributes.AddPermitted = Permission.Permitted Then
                  Return True
                Else
                  Return EnableUserAtOperations(User, Attributes.Author, Setting)
                End If
              End If
            End If
          Case Operations.Delete
            Select Case Attributes.Deletable
              Case Permission.Permitted
                Return True
              Case Permission.Author
                Return EnableUserAtOperations(User, Attributes.Author, Setting)
            End Select
          Case Operations.Edit
            Select Case Attributes.Editable
              Case EditablePermission.Permitted
                Return True
              Case EditablePermission.Author
                Return EnableUserAtOperations(User, Attributes.Author, Setting)
              Case EditablePermission.OnlyIfEmpty
                If IsNothing(Attributes.Title) And IsNothing(Attributes.Description) Then
                  Return True
                End If
            End Select
          Case Operations.UploadPhotos
            Select Case Attributes.AddPermitted
              Case Permission.Permitted
                Return True
              Case Permission.Author
                Return EnableUserAtOperations(User, Attributes.Author, Setting)
            End Select
        End Select
      End If
      Return False
    End Function
    Public Function DescriptionOperation(ByRef Operation As Operations, ByRef TypeObject As TypeObject, ByRef Language As LanguageManager.Language) As String
      Dim NObj As Integer
      Select Case TypeObject
        Case TypeObject.Photo
          NObj = 104
        Case TypeObject.PhotoAlbum
          NObj = 103
      End Select
      Select Case Operation
        Case Operations.View
          Return Phrase(Language, 53, NObj)
        Case Operations.CreateSubFotoAlbum
          Return Phrase(Language, 50, NObj)
        Case Operations.Delete
          Select Case TypeObject
            Case TypeObject.Photo
              Return Phrase(Language, 51, NObj)
            Case TypeObject.PhotoAlbum
              Return Phrase(Language, 51, NObj, 54)
          End Select
        Case Operations.Edit
          Return Phrase(Language, 52, NObj)
        Case Operations.UploadPhotos
          Return Phrase(Language, 56, 104)
      End Select
      Return Nothing
    End Function
    Public Function ControlOperations(ByRef User As Authentication.User, ByRef Attributes As Attributes, ByVal Setting As SubSite, Optional ByRef ActualOperationState As Operations = Operations.View) As Control
      Dim Box As New HtmlGenericControl("nav") ' New  WebControl(HtmlTextWriterTag.Fieldset)
      Dim Href As String = Nothing
      Dim LastOperation As Operations
      LastOperation = Operations.Delete
      For Operation As Operations = Operations.View To LastOperation
        If Operation <> ActualOperationState Then
          If OperationAvailable(User, Setting, Attributes, Operation) Then
            Dim Text As String = DescriptionOperation(Operation, Attributes.TypeObject, Setting.Language)
            Select Case Attributes.TypeObject
              Case TypeObject.Photo
                Href = Common.Href(Setting.Name, False, "showphoto.aspx", QueryKey.ShowPhotoAlbumId, Attributes.Container, QueryKey.ShowPhotoId, Attributes.Name, QueryKey.PhotoOperation, Operation)
              Case TypeObject.PhotoAlbum
                If Operation = Operations.UploadPhotos Then
                  Href = Common.Href(Setting.Name, False, "uploadphoto.aspx", "album", Attributes.Name)
                Else
                  Href = Common.Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, Attributes.Name, "operation", Operation)
                End If
            End Select
            Box.Controls.Add(LabelWithIcon(IconName.CheckMarkV, Text, Href))
          End If
        End If
      Next
      If Box.Controls.Count Then
        Dim Ctrl As New WebControl(HtmlTextWriterTag.Fieldset)
        Ctrl.BorderStyle = BorderStyle.None
        Box.Attributes.Add("class", "Menu")
        Ctrl.Controls.Add(Box)
        Return Ctrl
      Else
        Return New Control
      End If
    End Function

    Private Const MaxSubLevelPhotoAlbum As Integer = 7
    Public PhotoAlbumsDirectory As String = PhotoAlbums_Sub_Directory
    Public Function AllPhotosName(ByRef Album As String) As Integer()
      Dim Path As String = MapPath(PhotoAlbumsDirectory & "/" & Album)
      Path = Path.TrimEnd("/\".ToCharArray)
      If IO.Directory.Exists(Path) Then
        Dim P As Integer = Len(Path) + 1
        Dim Files As String() = IO.Directory.GetFiles(Path, "*.img.xml")
        Dim Names(UBound(Files)) As Integer
        Dim N As Integer
        For Each File As String In Files
          Names(N) = Val(File.Substring(P))
          N += 1
        Next
        If Names.Length > 1 Then
          Array.Sort(Names)
        End If
        Return Names
      End If
      Return Nothing
    End Function

    Private Function AllParents(ByRef PhotoAlbum As PhotoAlbum) As Collections.Generic.List(Of PhotoAlbum)
      Dim ParentPhotoAlbum As PhotoAlbum = PhotoAlbum
      Dim Albums As New Collections.Generic.List(Of PhotoAlbum)
      Do
        Albums.Add(ParentPhotoAlbum)
        ParentPhotoAlbum = ParentPhotoAlbum.Parent
      Loop Until ParentPhotoAlbum Is Nothing
      AllParents = Albums
    End Function

    Private Function AllPhotoAlbumsName(ByRef Album As String) As Array
      Dim Path As String = MapPath(PhotoAlbumsDirectory & "/" & Album)
      If IO.Directory.Exists(Path) Then
        Dim P As Integer = Len(Path) + 1
        Dim Directories As String() = IO.Directory.GetDirectories(Path)
        Dim Names(UBound(Directories)) As String
        Dim N As Integer
        For Each Directory As String In Directories
          Names(N) = Directory.Substring(P)
          N += 1
        Next
        If Names IsNot Nothing AndAlso Names.Length > 1 Then
          Array.Sort(Names)
        End If
        Return Names
      End If
      Return Nothing
    End Function

    Public Function Photos(ByRef Album As String) As Collections.Generic.Dictionary(Of Integer, Photo)
      Dim Collection As New Collections.Generic.Dictionary(Of Integer, Photo)
      Dim Names As Integer() = AllPhotosName(Album)
      If Names IsNot Nothing Then
        Dim Photo As Photo
        For Each Name As Integer In Names
          Photo = Photo.Load(Name, Album)
          Collection.Add(Name, Photo)
        Next
      End If
      Return Collection
    End Function

    Public Function GetRandomPhotos(ByVal Album As String, MaxQuantity As Integer, Optional Random As Random = Nothing) As Collections.Generic.List(Of Photo)
      Dim Result As New Collections.Generic.List(Of Photo)
      Dim Path As String = MapPath(PhotoAlbumsDirectory & "/" & Album)
      Dim Directory As New System.IO.DirectoryInfo(Path)
      Dim ExcludeName As New Collections.Generic.List(Of Integer)
      If Directory.Exists Then
        Dim Files As System.IO.FileInfo() = Directory.GetFiles("*.img.xml")
        If Files IsNot Nothing AndAlso Files.Length <> 0 Then
          If Random Is Nothing Then
            Random = New Random
          End If
          Dim NamePhoto As Integer
          For N = 1 To MaxQuantity
            If ExcludeName.Count < Files.Length Then
              Do
                Dim File As System.IO.FileInfo = Files(Random.Next(Files.Count))
                NamePhoto = Val(File.Name)
              Loop Until Not ExcludeName.Contains(NamePhoto)
              ExcludeName.Add(NamePhoto)
              Result.Add(PhotoManager.Photo.Load(NamePhoto, Album))
            Else
              Exit For
            End If
          Next
        End If
      End If
      Return Result
    End Function

    Public Function GetRandomPhoto(ByVal Album As String, Optional ByVal ExcludeName As Collections.Generic.List(Of Integer) = Nothing, Optional Random As Random = Nothing) As Photo
      Dim Path As String = MapPath(PhotoAlbumsDirectory & "/" & Album)
      Dim Directory As New System.IO.DirectoryInfo(Path)
      If Directory.Exists Then
        Dim Files As System.IO.FileInfo() = Directory.GetFiles("*.img.xml")
        If Files IsNot Nothing AndAlso Files.Length <> 0 Then
          If ExcludeName Is Nothing OrElse ExcludeName.Count < Files.Length Then
            If Random Is Nothing Then
              Random = New Random
            End If
            Dim NamePhoto As Integer
            Do
              Dim File As System.IO.FileInfo = Files(Random.Next(Files.Count))
              NamePhoto = Val(File.Name)
            Loop Until ExcludeName Is Nothing OrElse Not ExcludeName.Contains(NamePhoto)
            Dim Photo As Photo = PhotoManager.Photo.Load(NamePhoto, Album)
            Return Photo
          End If
        End If
      End If
      Return Nothing
    End Function

    Private Function PhotoAlbums(ByRef PhotoAlbum As PhotoAlbum, Optional ByRef IncludeParents As Boolean = True) As Collections.Generic.List(Of PhotoAlbum)
      Dim Collection As Collections.Generic.List(Of PhotoAlbum)
      Dim SubPhotoAlbum As PhotoAlbum
      If IncludeParents Then
        Collection = AllParents(PhotoAlbum)
      Else
        Collection = New Collections.Generic.List(Of PhotoAlbum)
      End If
      Dim PAs As Array = AllPhotoAlbumsName(PhotoAlbum.Name)
      If Not IsNothing(PAs) Then
        For Each Name As String In PAs
          SubPhotoAlbum = PhotoAlbum.Load(PhotoAlbum.Name & "/" & Name)
          If SubPhotoAlbum IsNot Nothing Then
            Collection.Add(SubPhotoAlbum)
          End If
        Next
      End If
      Return Collection
    End Function

    Public Function AddPhoto(ByRef Image As System.Drawing.Image, ByRef Album As String, Optional ByRef Name As String = "", Optional ByRef Size As Integer = 0, Optional ByRef Width As Integer = 0, Optional ByRef Height As Integer = 0) As Photo.ImageType
      'Size omesso => Size = vaolere di default (400)
      'Size = 0 => L'immagine manterra' le dimensioni originali

      If Album = "" Then
        Album = "default"
      End If

      If Name = "" Then
        Name = NewNamePhoto(Album)
      End If
      Dim ImageFormat As Drawing.Imaging.ImageFormat
      Dim Format As Photo.ImageType
      If Size Then
        ImageManager.ImageResize(Image, Size, True)
        'Image = Extension.Thumbnail(Image, Size)
        ImageFormat = Drawing.Imaging.ImageFormat.Jpeg
        Format = Photo.ImageType.Jpeg
      Else
        If Image.PixelFormat And Drawing.Imaging.PixelFormat.Indexed Then
          ImageFormat = Drawing.Imaging.ImageFormat.Gif
          Format = Photo.ImageType.Gif
        Else
          ImageFormat = Drawing.Imaging.ImageFormat.Jpeg
          Format = Photo.ImageType.Jpeg
        End If
      End If
      Dim PathFile As String = MapPath(Config.PhotoAlbums_Sub_Directory & "/" & Album & "/" & Name & "." & ExtensionFile(Format))
      Try
        Image.Save(PathFile, ImageFormat)
      Catch ex As Exception
        Image.Dispose()
        FileManager.Delete(PathFile)
        Throw ex
      End Try
      Return Format
    End Function

    Const DefaultPhotoAlbum As String = "default"

    Private Function NewNamePhoto(ByRef Album As String) As Integer
      Dim Path As String = MapPath(PhotoAlbumsDirectory & "/" & Album & "/")
      Dim FSO As System.IO.File
      Dim n As Integer, Xfile As String
      Do
        n = n + 1
        Xfile = CStr(n) & ".img.xml"
      Loop Until IO.File.Exists(Path & Xfile) = False
      FSO = Nothing
      NewNamePhoto = n
    End Function

    Private Function NewNamePhotoAlbum(ByRef Album As String) As String
      Dim Path As String = MapPath(PhotoAlbumsDirectory)
      Dim FSO As System.IO.Directory
      Dim n As Integer, Xfile As String
      Do
        n = n + 1
        Xfile = Album & "/a" & n
      Loop Until IO.Directory.Exists(Path & "/" & Xfile) = False
      FSO = Nothing
      NewNamePhotoAlbum = Xfile
    End Function

    Public Class PhotoAlbum
      Public Shared Load As New Extension.Cache(AddressOf LoadObject, 100, GetType(PhotoAlbum))
      Shared Function Path(ByVal Name As String) As String
        Return MapPath(PhotoAlbumsDirectory & "/" & Name)
      End Function

      Shared Function NameFileSetting(ByVal Name As String) As String
        Return PhotoAlbum.Path(Name) & "/dir.xml"
      End Function

      Sub SaveXml()
        Dim Path As String = PhotoAlbum.Path(Name)
        If Not System.IO.Directory.Exists(Path) Then
          System.IO.Directory.CreateDirectory(Path)
        End If
        Serialize(Me, NameFileSetting(Name))
      End Sub

      Private Shared Function LoadObject(ByVal Name As String) As Object
        'This function is made for use with cache class in delegate (return a Object)
        Return LoadXml(Name)
      End Function

      Shared Function LoadXml(ByRef Name As String) As PhotoAlbum
        Name = ReplaceBin(Name, "\", "/") 'Rename for retrocompatibility
        Dim PhotoAlbum As PhotoAlbum = Deserialize(NameFileSetting(Name), GetType(PhotoAlbum))
        PhotoAlbum.Name = Name
        Return PhotoAlbum
      End Function

      Public Function Control(ByRef Setting As Config.SubSite, Optional ByRef RelativeSubLevel As Integer = 0, Optional ByRef HrefCurrentLevel As Boolean = False) As Control
        Control = ControlPhotoAlbum(Me, Setting, RelativeSubLevel, HrefCurrentLevel)
      End Function

      Public Function ControlPhotos(ByRef Setting As Config.SubSite, Optional ByVal Target_Blank As Boolean = False, Optional ByVal DomainConfiguration As DomainConfiguration = Nothing, Optional ByVal HttpContext As HttpContext = Nothing) As Control
        If DomainConfiguration Is Nothing Then DomainConfiguration = CurrentDomainConfiguration()
        Dim Box As New HtmlGenericControl("section") 'html5
        Box.Attributes.Add("itemscope", "itemscope")
        Box.Attributes.Add("itemtype", "http://schema.org/ImageGallery")

        Dim Title As String = Me.Title(Setting.Language)
        If Title <> "" Then
          Dim H1 As New WebControl(HtmlTextWriterTag.H1)
          H1.Controls.Add(TextControl(Title))
          H1.Attributes.Add("itemprop", "name")
          Box.Controls.Add(H1)
        End If

        Dim Description As String = Me.Description(Setting.Language)
        If Me.Name.ToLower.StartsWith("users") Then
          Dim Author As Authentication.User = Authentication.User.Load(Me.Author)
          Dim Link As New HyperLink
          Link.Text = HttpUtility.HtmlEncode(Description)
          If Author IsNot Nothing Then
            Link.NavigateUrl = Author.Href(Setting)
          End If
          Dim H2 As New WebControl(HtmlTextWriterTag.H2)
          H2.Controls.Add(Link)
          Box.Controls.Add(H2)
        Else
          If Description <> "" Then
            Dim H2 As New WebControl(HtmlTextWriterTag.H2)
            H2.Controls.Add(TextControl(Description))
            H2.Attributes.Add("itemprop", "description")
            Box.Controls.Add(H2)
          End If
        End If

        'Box.CssClass = "Menu"
        For Each Photo As PhotoManager.Photo In Me.Photos.Values
          Dim CtrlPhoto As Control = Photo.ControlThumbnail(Setting, Target_Blank, SizeThumbnail(HttpContext), ThumbnailBoxMode.Gallery, DomainConfiguration, HttpContext)
          'Dim Align As New WebControl(HtmlTextWriterTag.Span)
          'Align.Style.Add("float", "left")
          'Align.Controls.Add(CtrlPhoto)
          Box.Controls.Add(CtrlPhoto)
        Next
        Return Box
      End Function
      Public Function PhotoAlbums(Optional ByRef IncludeParents As Boolean = True) As Collections.Generic.List(Of PhotoAlbum)
        PhotoAlbums = PhotoManager.PhotoAlbums(Me, IncludeParents)
      End Function
      Public Function Navigator(ByRef Setting As Config.SubSite, Optional ByRef IncludeParents As Boolean = True, Optional ByRef HrefCurrentLevel As Boolean = False) As Control

        Dim Box As New HtmlGenericControl("nav")
        For Each PhotoAlbum As PhotoManager.PhotoAlbum In Me.PhotoAlbums
          Box.Controls.Add(PhotoAlbum.Control(Setting, Me.SubLevel, HrefCurrentLevel))
        Next
        If Box.Controls.Count Then
          Dim Ctrl As New WebControl(HtmlTextWriterTag.Fieldset)
          Ctrl.BorderStyle = BorderStyle.None
          Box.Attributes.Add("class", "Menu")
          Ctrl.Controls.Add(Box)
          Return Ctrl
        Else
          Return New Control
        End If
      End Function
      Public Function Photos() As Collections.Generic.Dictionary(Of Integer, Photo)
        Return PhotoManager.Photos(Me.Name)
      End Function
      Public Function PhotosSortedByTitle(ByVal Language As LanguageManager.Language) As Collections.Generic.List(Of Photo)
        Dim PhotosSorted As New Collections.Generic.List(Of Photo)
        For Each Photo As Photo In Photos.Values
          PhotosSorted.Add(Photo)
        Next
        Dim Comparer As New Photo.ComparerPhotoByTitle(Language)
        PhotosSorted.Sort(Comparer)
        Return PhotosSorted
      End Function
      <XmlIgnore()> Public Name As String = DefaultPhotoAlbum
      Public SubLevel As Integer
      Public Author As String
      Public Created As Date = Now.ToUniversalTime
      Public Property Title(ByVal Language As LanguageManager.Language) As String
        Get
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
            Title = L.Title
          Else
            Title = ""
          End If
        End Get
        Set(ByVal Value As String)
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
          Else
            L = New LiteralLanguage
            L.Language = Language
            Localization.Add(Language, L)
          End If
          L.Title = Value
        End Set
      End Property
      Public Property Description(ByVal Language As LanguageManager.Language) As String
        Get
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
            Description = L.Description
          Else
            Description = ""
          End If
        End Get
        Set(ByVal Value As String)
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
          Else
            L = New LiteralLanguage
            L.Language = Language
            Localization.Add(Language, L)
          End If
          L.Description = Value
        End Set
      End Property
      Private Localization As New Collections.Generic.Dictionary(Of LanguageManager.Language, LiteralLanguage)

      Public Property LocalizationArray As LiteralLanguage()
        Get
          'Use to serializze collection Localization
          Dim Array(Localization.Count - 1) As LiteralLanguage
          Dim n As Integer
          For Each Key As Integer In Localization.Keys
            Array(n) = Localization(Key)
            n += 1
          Next
          Return Array
        End Get
        Set(ByVal value As LiteralLanguage())
          'Use to deserializze collection CollectionUserRating
          '	Dim I As ICollection(Of KeyValuePair(Of String, Integer)) = Roles
          For Each Element As LiteralLanguage In value
            Localization.Add(Element.Language, Element)
          Next
        End Set
      End Property

      Public Class LiteralLanguage
        Public Language As LanguageManager.Language
        Public Title As String
        Public Description As String
        Sub New(ByVal Language As LanguageManager.Language, ByVal Title As String, ByVal Description As String)
          Me.Language = Language
          Me.Title = Title
          Me.Description = Description
        End Sub
        Sub New()
        End Sub
      End Class
      Public SubPhotoAlbumsNotCreatable As Boolean
      Public Function Parent() As PhotoAlbum
        If IsRoot = False Then
          Dim p As Integer = InStrRev(Me.Name, "/")
          If p Then
            Dim Album As String = Left(Me.Name, p - 1)
            Return PhotoAlbum.Load(Album)
          End If
        End If
        Return Nothing
      End Function
      Public Property IsRoot() As Boolean
        Get
          If Me.Name = "" Or Me.Name = DefaultPhotoAlbum Then
            IsRoot = True
          Else
            IsRoot = _IsRoot
          End If
        End Get
        Set(ByVal Value As Boolean)
          _IsRoot = Value
        End Set
      End Property
      Private _IsRoot As Boolean
      Public Hide As Boolean = False
      Public Editable As EditablePermission = EditablePermission.Author
      Public AddPermitted As Permission = Permission.Author
      Public Exists As Boolean
      Public Deletable As Permission = Permission.Author
      Sub Save()
        If Name = "" Then
          Name = DefaultPhotoAlbum
        End If

        Dim Path As String = MapPath(PhotoAlbumsDirectory & "/" & Me.Name)
        If System.IO.Directory.Exists(Path) = False Then
          System.IO.Directory.CreateDirectory(Path)
        End If

        SaveXml()
        Load(Name) = Me
        Pipeline.NotifyChangement(GetType(PhotoAlbum), Name)
      End Sub

      Function CreateSubFotoAlbum(ByRef User As Authentication.User, ByRef Setting As SubSite) As PhotoAlbum
        If OperationAvailable(User, Setting, Operations.CreateSubFotoAlbum) Then
          Return CreateSubFotoAlbum(User)
        End If
        Return Nothing
      End Function
      Function CreateSubFotoAlbum(Optional ByVal User As Authentication.User = Nothing) As PhotoAlbum
        Dim PhotoAlbum As PhotoAlbum = New PhotoAlbum
        PhotoAlbum.Name = NewNamePhotoAlbum(Me.Name)
        System.IO.Directory.CreateDirectory(MapPath(PhotoAlbumsDirectory & "/" & PhotoAlbum.Name))
        PhotoAlbum.SubLevel = Me.SubLevel + 1
        If User IsNot Nothing Then
          PhotoAlbum.Author = User.Username
        End If
        PhotoAlbum.Save()
        Return PhotoAlbum
      End Function
      Sub Delete(ByRef User As Authentication.User, ByRef Setting As SubSite)
        If OperationAvailable(User, Setting, Operations.Delete) Then
          Dim PathPosition As String = MapPath(PhotoAlbumsDirectory & "/" & Me.Name)
          If InStr(PathPosition, ":") Then    'controllo per la sicurezza assoluta di non eliminare directory importanti
            If Len(Config.ReadWriteDirectory) Then      'controllo per la sicurezza assoluta di non eliminare directory importanti
              If Len(Config.PhotoAlbums_Sub_Directory) Then      'controllo per la sicurezza assoluta di non eliminare directory importanti
                If InStr(PathPosition, ReplaceBin(Config.PhotoAlbums_Sub_Directory, "/", "\"), CompareMethod.Binary) Then
                  'Strong control to verify accident delete of important directory!
                  If PathPosition.StartsWith(MapPath(ReadWriteDirectory)) Then
                    If Len(PathPosition) > Len(ReadWriteDirectory) Then
                      DeleteDirectory(PathPosition)
                    End If
                  End If
                  Me.Exists = False
                End If
              End If
            End If
          End If
        End If
      End Sub
      Sub Edit(ByRef User As Authentication.User, ByRef Setting As SubSite, ByRef Title As String, ByRef Description As String)
        If OperationAvailable(User, Setting, Operations.Edit) Then
          Me.Title(Setting.Language) = Title
          Me.Description(Setting.Language) = Description
          Me.Save()
        End If
      End Sub
      Public Function Attributes(ByVal User As Authentication.User, ByVal Language As LanguageManager.Language) As Attributes
        Dim Available As New Attributes
        Available.AddPermitted = Me.AddPermitted
        Available.Author = Me.Author
        'Available.Container = Me.Album
        Available.Deletable = Me.Deletable
        Available.Description = Me.Description(Language)
        Available.Editable = Me.Editable
        Available.Hide = Me.Hide
        Available.Name = Me.Name
        Available.SubLevel = Me.SubLevel
        Available.SubPhotoAlbumsNotCreatable = Me.SubPhotoAlbumsNotCreatable
        Available.Title = Me.Title(Language)
        Available.TypeObject = TypeObject.PhotoAlbum
        Return Available
      End Function
      Public Function OperationAvailable(ByRef User As Authentication.User, ByRef Setting As SubSite, ByRef Operation As Operations) As Boolean
        Return PhotoManager.OperationAvailable(User, Setting, Me.Attributes(User, Setting.Language), Operation)
      End Function
      Private Function EnableUserAtOperations(ByRef User As Authentication.User, ByRef Setting As SubSite) As Boolean
        Return PhotoManager.EnableUserAtOperations(User, Me.Author, Setting)
      End Function
      Public Function ControlOperations(ByRef User As Authentication.User, ByVal Setting As SubSite, Optional ByRef ActualOperationState As Operations = Operations.View) As Control
        Return PhotoManager.ControlOperations(User, Me.Attributes(User, Setting.Language), Setting, ActualOperationState)
      End Function
    End Class
    Public Class Photo
      Implements IDisposable
      Private Stream As System.IO.Stream

      Protected Overridable Overloads Sub Dispose(ByVal Disposing As Boolean)
        If _Image IsNot Nothing Then
          _Image.Dispose()
          _Image = Nothing
        End If
        If Stream IsNot Nothing Then
          Stream.Close()
          Stream.Dispose()
          Stream = Nothing
        End If
      End Sub

      Public Overloads Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
        Dispose(True)
      End Sub

      Protected Overrides Sub Finalize()
        Dispose(False)
      End Sub

      Public Format As ImageType
      Enum ImageType
        Jpeg
        Gif
        Png
      End Enum
      Public Function ImageFormat() As Drawing.Imaging.ImageFormat
        Select Case Format
          Case ImageType.Gif
            Return Drawing.Imaging.ImageFormat.Gif
          Case ImageType.Jpeg
            Return Drawing.Imaging.ImageFormat.Jpeg
          Case ImageType.Png
            Return Drawing.Imaging.ImageFormat.Png
        End Select
        Return Nothing
      End Function

      Public Function MimeType() As String
        Return "image/" & Format.ToString
      End Function

      Function Src(ByVal Setting As SubSite, Optional ByRef Size As Integer = Nothing, Optional ColorTone As ColorTone = ColorTone.Default) As String
        'Size -1 = full (original size)
        'This is the most powerful of the StringBuilder, do not change!
        Dim Url As String = Href(Setting.Name, False, "viewimg.aspx", QueryKey.AlbumName, Me.Album, QueryKey.ImageName, Me.Name, QueryKey.LanguageImage, Setting.Language)
        If Size = -1 Then
          'Size = System.Math.Max(Width, Height)
          Url &= "&fullsize=" & Size
        Else
          If Size AndAlso Size <> ShowDefaultImageSize Then
            Url &= "&size=" & Size
          End If
        End If
        If ColorTone <> ColorTone.Default Then
          Url &= "&tone=" & ColorTone
        End If
        Return Url
      End Function

      Function SrcThumbnail(ByVal Setting As SubSite, Optional ByVal Size As Integer = 0, Optional ByVal HttpContext As HttpContext = Nothing, Optional ColorTone As ColorTone = ColorTone.Default) As String
        If Size = 0 Then
          Size = SizeThumbnail
        End If
        'This is the most powerful of the StringBuilder, do not change!
        Dim Url As String = Href(Setting.Name, False, "viewimg.aspx", QueryKey.AlbumName, Me.Album, QueryKey.ImageName, Me.Name, QueryKey.LanguageImage, Setting.Language, QueryKey.Size, Size)
        If ColorTone <> ColorTone.Default Then
          Url &= "&" & QueryKey.ImageColorTone & "=" & ColorTone
        End If
        Return Url
      End Function
      Public Function Navigator(ByRef Setting As Config.SubSite, Optional ByRef IncludeParents As Boolean = True, Optional ByRef HrefCurrentLevel As Boolean = True) As Control
        Return Me.PhotoAlbum.Navigator(Setting, IncludeParents, HrefCurrentLevel)
      End Function
      Function PhotoAlbum() As PhotoManager.PhotoAlbum
        Return PhotoManager.PhotoAlbum.Load(Me.Album)
      End Function
      Public Function ControlThumbnail(ByRef Setting As Config.SubSite, Optional ByVal Target_Blank As Boolean = False, Optional ByVal Size As Integer = Nothing, Optional ByVal BoxMode As ThumbnailBoxMode = ThumbnailBoxMode.Thumbnail, Optional ByVal DomainConfiguration As DomainConfiguration = Nothing, Optional ByVal HttpContext As HttpContext = Nothing) As Control
        If DomainConfiguration Is Nothing Then DomainConfiguration = CurrentDomainConfiguration()
        Return PhotoManager.ControlThumbnail(Me, Setting, Target_Blank, Size, BoxMode, DomainConfiguration, HttpContext)
      End Function
      Public Function ControlPhoto(ByRef Setting As Config.SubSite) As Control
        Return PhotoManager.ControlPhoto(Me, Setting)
      End Function

      <XmlIgnore()> Public Album As String = DefaultPhotoAlbum
      <XmlIgnore()> Public Name As Integer
      Function NameCode() As String
        Return Me.Album & "." & Me.Name & "." & DateToText(Me.Created)
      End Function
      Public Deletable As Permission = Permission.Author
      Public Editable As EditablePermission = EditablePermission.Author
      Public Function Image(Setting As SubSite) As System.Drawing.Image
        If _Image Is Nothing Then
          Try
            _Image = Drawing.Image.FromFile(NameFileImage)
            GC.ReRegisterForFinalize(Me)
            If _Image Is Nothing Then
              Return Nothing
            End If
            If Width = 0 Then
              Width = _Image.Width
              Height = _Image.Height
              Me.Save()
            End If
            _Image = ApplyColorTone(_Image, Setting)
          Catch ex As Exception
            Log("LoadImageError", 100, Me.Album, Me.Name, NameFileImage, ex.Message, ex.Source, ex.StackTrace)
          End Try
        End If
        Return _Image
      End Function

      Sub SetImage(ByVal Image As System.Drawing.Image)
        _Image = Image
        Width = _Image.Width
        Height = _Image.Height
        Image_Is_Updated = True
        GC.ReRegisterForFinalize(Me)
      End Sub

      Private _Image As System.Drawing.Image
      Public Width As Integer
      Public Height As Integer

      Private Image_Is_Updated As Boolean
      Sub FromStream(ByRef Stream As System.IO.Stream, Optional ByVal MaintainOriginal As Boolean = False)
        MaintainOriginalFormat = MaintainOriginal
        SetImage(Drawing.Image.FromStream(Stream))

        '!important: Don't enable the next line! The Dispose statement will generate a error in the function "Photo.Save"
        'Stream.Dispose()

        SetExif()
        Image_Is_Updated = True
      End Sub

      Sub FromUrl(ByRef Url As String, Optional ByVal MaintainOriginal As Boolean = False)
        MaintainOriginalFormat = MaintainOriginal
        Dim WC As New System.Net.WebClient
        Stream = WC.OpenRead(Url)
        SetImage(Drawing.Image.FromStream(Stream))

        '!important: Don't enable the next line! The Dispose statement will generate a error in the function "Photo.Save"
        'Stream.Dispose()

        SetExif()
        Image_Is_Updated = True
      End Sub

      'EXIF data
      Public Taken As Date
      Public CameraBrand As String
      Public CameraModel As String
      Public ExposureTime As Single
      Public FNumber As Single
      Public ISO As Integer
      Public MaxAperture As Integer
      Public Flash As Integer
      Public FocalLength As Single  'X mm
      Public Latitude As Double
      Public Longitude As Double

      Private Sub SetExif()
        If _Image IsNot Nothing Then

          Dim PropertyItem As Drawing.Imaging.PropertyItem
          'Geo
          Dim LatitudeA, LatitudeB, LatitudeC As UInt32
          Dim LatitudeRef As String = Nothing
          Dim LongitudeA, LongitudeB, LongitudeC As UInt32
          Dim LongitudeRef As String = Nothing

          Dim N32 As Integer = 0
          Dim N32B As Integer = 0
          For Each Id As Integer In _Image.PropertyIdList
            'Dim H As String = Hex(Id)
            PropertyItem = _Image.GetPropertyItem(Id)
            Try
              Select Case Id
                Case 1
                  LatitudeRef = ExifText(PropertyItem)
                Case 2
                  ExifRational(PropertyItem, LatitudeA, LatitudeB, LatitudeC)
                  Latitude = LatitudeA + LatitudeB / 60 + LatitudeC / 3600
                Case 3
                  LongitudeRef = ExifText(PropertyItem)
                Case 4
                  ExifRational(PropertyItem, LongitudeA, LongitudeB, LongitudeC)
                  Longitude = LongitudeA + LongitudeB / 60 + LatitudeC / 3600
                Case 271
                  CameraBrand = ExifText(PropertyItem)
                Case 272
                  CameraModel = ExifText(PropertyItem)
                Case 306, 36867
                  'Convert date taken metadata to a DateTime object
                  Dim Text = ExifText(PropertyItem)
                  Dim SecondHalf As String = Text.Substring(Text.IndexOf(" "), (Text.Length - Text.IndexOf(" ")))
                  Dim FirstHalf As String = Text.Substring(0, 10)
                  FirstHalf = ReplaceBin(FirstHalf, ":", "-")
                  Text = FirstHalf & SecondHalf
                  Taken = DateTime.Parse(Text, Globalization.CultureInfo.InvariantCulture)
                Case 33434
                  ExifRational(PropertyItem, N32, N32B)
                  ExposureTime = N32 / N32B
                Case 33437
                  ExifRational(PropertyItem, N32, N32B)
                  FNumber = N32 / N32B
                Case &H8827
                  ISO = ExifN16(PropertyItem)
                Case 37381
                  ExifRational(PropertyItem, N32, N32B)
                  MaxAperture = N32 / N32B
                Case 37385
                  Flash = ExifN16(PropertyItem)
                Case 37386
                  ExifRational(PropertyItem, N32, N32B)
                  FocalLength = N32 / N32B
              End Select
            Catch ex As Exception
              'Exif error
            End Try
          Next
          If LatitudeRef <> "" Then
            If LatitudeRef = "S" Then
              LatitudeRef = -Latitude
            End If
          End If
          If LongitudeRef <> "" Then
            If LongitudeRef = "O" Then
              LongitudeRef = -LongitudeRef
            End If
          End If
        End If
      End Sub
      Private Function ExifText(PropertyItem As Drawing.Imaging.PropertyItem) As String
        Dim Result As String = Encoding.UTF8.GetString(PropertyItem.Value)
        Return Result.TrimEnd(Chr(0))
      End Function
      Private Function ExifTextUtf16(PropertyItem As Drawing.Imaging.PropertyItem) As String
        Dim Result As String = Encoding.GetEncoding("utf-16LE").GetString(PropertyItem.Value)
        Return Result.TrimEnd(Chr(0))
      End Function
      Private Function ExifN16(PropertyItem As Drawing.Imaging.PropertyItem) As Integer
        Return Convert.ToUInt16(PropertyItem.Value(0)) Or Convert.ToUInt16(PropertyItem.Value(1)) << 8
      End Function
      Private Sub ExifRational(PropertyItem As Drawing.Imaging.PropertyItem, ByRef N32 As UInt32, Optional ByRef N32B As UInt32 = 0, Optional ByRef N32C As UInt32 = 0)
        N32 = Convert.ToUInt32(PropertyItem.Value(0)) Or Convert.ToUInt32(PropertyItem.Value(1)) << 8 Or Convert.ToUInt32(PropertyItem.Value(2)) << 16 Or Convert.ToUInt32(PropertyItem.Value(3)) << 24
        If PropertyItem.Len = 8 Then
          N32B = Convert.ToUInt32(PropertyItem.Value(4)) Or Convert.ToUInt32(PropertyItem.Value(5)) << 8 Or Convert.ToUInt32(PropertyItem.Value(6)) << 16 Or Convert.ToUInt32(PropertyItem.Value(7)) << 24
        End If
        If PropertyItem.Len = 24 Then
          N32B = Convert.ToUInt32(PropertyItem.Value(8)) Or Convert.ToUInt32(PropertyItem.Value(9)) << 8 Or Convert.ToUInt32(PropertyItem.Value(10)) << 16 Or Convert.ToUInt32(PropertyItem.Value(11)) << 24
        End If
      End Sub

      Function ExifInfo(Setting As SubSite) As Control
        Dim Div As New WebControl(HtmlTextWriterTag.Div)
        If Taken <> Date.MinValue Then
          Div.Controls.Add(TextControl(Phrase(Setting.Language, 409) & "=" & Taken.ToString(Setting.DateTimeFormat)))
          Div.Controls.Add(BR)
        End If
        If CameraBrand <> "" Then
          Div.Controls.Add(TextControl(Phrase(Setting.Language, 324) & "=" & CameraBrand))
          Div.Controls.Add(BR)
        End If
        If CameraModel <> "" Then
          Div.Controls.Add(TextControl(Phrase(Setting.Language, 325) & "=" & CameraModel))
          Div.Controls.Add(BR)
        End If
        If ExposureTime Then
          Dim Exposure As String = Nothing
          If ExposureTime < 1 Then
            Exposure = "1/" & CInt(1 / ExposureTime) & " "
          End If
          Dim SecString As String = System.Math.Round(ExposureTime, 3).ToString(Globalization.CultureInfo.InvariantCulture) & " sec."
          If Exposure <> "" Then
            SecString = "(" & SecString & ")"
          End If
          Exposure &= SecString
          Div.Controls.Add(TextControl(Phrase(Setting.Language, 326) & "=" & Exposure))
          Div.Controls.Add(BR)
        End If
        If FNumber Then
          Div.Controls.Add(TextControl("F-number" & "=" & Math.Round(FNumber, 2).ToString(Globalization.CultureInfo.InvariantCulture)))
          Div.Controls.Add(BR)
        End If
        If ISO Then
          Div.Controls.Add(TextControl("ISO" & "=" & ISO))
          Div.Controls.Add(BR)
        End If
        If MaxAperture Then
          Div.Controls.Add(TextControl("Max Aperture" & "=" & Math.Round(MaxAperture, 2).ToString(Globalization.CultureInfo.InvariantCulture)))
          Div.Controls.Add(BR)
        End If
        If Flash Then
          Div.Controls.Add(TextControl("Flash" & "=" & Hex(Flash)))
          Div.Controls.Add(BR)
        End If
        If FocalLength Then
          Div.Controls.Add(TextControl(Phrase(Setting.Language, 327) & "=" & Math.Round(FocalLength, 2).ToString(Globalization.CultureInfo.InvariantCulture) & " mm"))
          Div.Controls.Add(BR)
        End If
        If Latitude OrElse Longitude Then
          Div.Controls.Add(TextControl(Phrase(Setting.Language, 3031) & "="))
          Dim Link As New HyperLink
          Link.Text = Math.Round(Latitude, 4).ToString(Globalization.CultureInfo.InvariantCulture) & " " & Math.Round(Longitude, 4).ToString(Globalization.CultureInfo.InvariantCulture)
          Link.NavigateUrl = Href(Setting.Name, False, "earth.aspx", EarthManager.QueryStringParameters(Nothing, Nothing, Math.Round(Latitude, 4).ToString(Globalization.CultureInfo.InvariantCulture), Math.Round(Longitude, 4).ToString(Globalization.CultureInfo.InvariantCulture)))
          'Link.NavigateUrl = Href(Setting.Name, False, "earth.aspx", "la", Math.Round(Latitude, 4).ToString(Globalization.CultureInfo.InvariantCulture), "lo", Math.Round(Longitude, 4).ToString(Globalization.CultureInfo.InvariantCulture))
          Div.Controls.Add(Link)
          Div.Controls.Add(BR)
        End If
        If Div.Controls.Count Then
          Div.CssClass = "Menu"
          Return Div
        End If
        Return Nothing
      End Function

      Private MaintainOriginalFormat As Boolean
      Public Author As String
      Public Created As Date = Now.ToUniversalTime
      Public IdComments As Integer
      Public Hide As Boolean = False
      Public Exists As Boolean

      Public Function PreviousPhoto() As Integer
        Return NextPhoto(True)
      End Function

      Public Function NextPhoto(Optional ByVal Reverse As Boolean = False) As Integer
        Dim Photos As Integer() = AllPhotosName(Me.Album)
        If Reverse Then Array.Reverse(Photos)
        Dim s As Integer = Array.IndexOf(Photos, Me.Name)
        For n As Integer = s + 1 To UBound(Photos)
          Dim Photo As PhotoManager.Photo
          Photo = Photo.Load(Photos(n), Album)
          If Photo.Hide = False Then
            Return Photo.Name
          End If
        Next
        Return 0
      End Function

      Public Property Title(ByVal Language As LanguageManager.Language) As String
        Get
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
            Title = L.Title
          Else
            Title = ""
          End If
        End Get
        Set(ByVal Value As String)
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
          Else
            L = New LiteralLanguage
            L.Language = Language
            Localization.Add(Language, L)
          End If
          L.Title = Value
        End Set
      End Property

      Public Property Description(ByVal Language As LanguageManager.Language) As String
        Get
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
            Description = L.Description
          Else
            Description = ""
          End If
        End Get
        Set(ByVal Value As String)
          Dim L As LiteralLanguage
          If Localization.ContainsKey(Language) Then
            L = Localization(Language)
          Else
            L = New LiteralLanguage
            L.Language = Language
            Localization.Add(Language, L)
          End If
          L.Description = Value
        End Set
      End Property
      Private Localization As New Collections.Generic.Dictionary(Of LanguageManager.Language, LiteralLanguage)

      Public Property LocalizationArray As LiteralLanguage()
        Get
          'Use to serializze collection Localization
          Dim Array(Localization.Count - 1) As LiteralLanguage
          Dim n As Integer
          For Each Key As Integer In Localization.Keys
            Array(n) = Localization(Key)
            n += 1
          Next
          Return Array
        End Get
        Set(ByVal value As LiteralLanguage())
          'Use to deserializze collection CollectionUserRating
          '	Dim I As ICollection(Of KeyValuePair(Of String, Integer)) = Roles
          For Each Element As LiteralLanguage In value
            Localization.Add(Element.Language, Element)
          Next
        End Set
      End Property

      Public Class LiteralLanguage
        Public Language As LanguageManager.Language
        Public Title As String
        Public Description As String
        Sub New(ByVal Language As LanguageManager.Language, ByVal Title As String, ByVal Description As String)
          Me.Language = Language
          Me.Title = Title
          Me.Description = Description
        End Sub
        Sub New()
        End Sub
      End Class

      Shared Function NameFileSetting(ByVal Album As String, ByVal Name As Integer) As String
        Return MapPath(PhotoAlbumsDirectory & "/" & Album & "/" & Name & ".img.xml")
      End Function

      Function NameFileImage() As String
        NameFileImage = MapPath(PhotoAlbumsDirectory & "/" & Album & "/" & Name & "." & ExtensionFile(Format))
      End Function
      Private _RemoteNameFileImage As String
      Function RemoteNameFileImage() As String
        RemoteNameFileImage = _RemoteNameFileImage
      End Function
      Private _RemoteNameFileThumbnail As String
      Function RemoteNameFileThumbnail() As String
        RemoteNameFileThumbnail = _RemoteNameFileThumbnail
      End Function
      Private _RemoteUrl As String
      Function RemoteUrl() As String
        RemoteUrl = _RemoteUrl
      End Function

      Sub SaveXml()
        Serialize(Me, NameFileSetting(Album, Name))
      End Sub

      Shared Function LoadXml(ByVal Album As String, ByVal Name As Integer) As Photo
        Dim File As String = NameFileSetting(Album, Name)
        If IO.File.Exists(File) Then
          Dim Photo As Photo = Deserialize(File, GetType(Photo))
          Photo.Name = Name
          Photo.Album = Album
          Return Photo
        End If
        Return Nothing
      End Function

      Sub Save(Optional ByRef User As Authentication.User = Nothing)
        If Me.Album = "" Then
          Me.Album = DefaultPhotoAlbum
        End If
        If Me.Name = 0 Then
          Me.Name = NewNamePhoto(Album)
        End If
        If Image_Is_Updated Then
          Image_Is_Updated = False
          If MaintainOriginalFormat Then
            Format = AddPhoto(_Image, Me.Album, Me.Name, 0)
          Else
            'resize
            Format = AddPhoto(_Image, Me.Album, Me.Name, Setup.RenderingEngine.UploadImageResize)
          End If
          Me.Created = Now.ToUniversalTime
          If IsNothing(User) = False Then
            Me.Author = User.Username
          End If
        End If

        SaveXml()
      End Sub

      Shared Function Load(Optional ByRef Name As Integer = Nothing, Optional ByRef Album As String = Nothing) As Photo
        Album = ReplaceBin(Album, "\", "/") 'Rename for retrocompatibility
        Dim NewPhoto As Photo = LoadXml(Album, Name)
        If NewPhoto IsNot Nothing Then
          NewPhoto.Exists = True
          NewPhoto.Name = Name
          NewPhoto.Album = Album
          Return NewPhoto
        End If
        Return Nothing
      End Function

      Shared Function Load(ByVal NameCode As String) As Photo
        Try
          Dim Elements As String() = Split(NameCode, ".")
          If UBound(Elements) = 2 Then
            Dim Photo As Photo = Photo.Load(CInt(Elements(1)), Elements(0))
            If Photo.Created.ToString = TextToDate(Elements(2)).ToString Then
              Return Photo
            End If
          End If
        Catch ex As Exception
        End Try
        Return Nothing
      End Function

      Private Function NewRemotePhotoNameFile() As String
        Dim Last As Long = Extension.Value("LastRemotePhonoName")
        Last = Last + 1
        Extension.Value("LastRemotePhonoName") = Last
        Return CStr(Last)
      End Function

      Public Function OperationAvailable(ByRef User As Authentication.User, ByVal Setting As SubSite, ByRef Operation As Operations) As Boolean
        Return PhotoManager.OperationAvailable(User, Setting, Me.Attributes(User, Setting.Language), Operation)
      End Function

      Sub Delete(ByRef User As Authentication.User, ByVal Setting As SubSite)
        If OperationAvailable(User, Setting, Operations.Delete) Then
          If Me.Exists Then
            FileManager.Delete(NameFileSetting(Album, Name))

            FileManager.Delete(Me.NameFileImage)
            'delete comment
            If IdComments <> 0 Then
              Topic.Delete(ReservedForums.PhotoComment, IdComments)
            End If
          End If
        End If
      End Sub

      Sub Edit(ByRef User As Authentication.User, ByRef Setting As SubSite, ByRef Title As String, ByRef Description As String)
        If OperationAvailable(User, Setting, Operations.Edit) Then
          Me.Title(Setting.Language) = Title
          Me.Description(Setting.Language) = Description
          Me.Save()
        End If
      End Sub

      Private Function EnableUserAtOperations(ByRef User As Authentication.User, ByRef Setting As SubSite) As Boolean
        Return PhotoManager.EnableUserAtOperations(User, Me.Author, Setting)
      End Function

      Public Function Attributes(ByVal User As Authentication.User, ByVal Language As LanguageManager.Language) As Attributes
        Dim Available As New Attributes
        'Available.AddPermitted = Me.AddPermitted
        Available.Author = Me.Author
        Available.Container = Me.Album
        Available.Deletable = Me.Deletable
        Available.Description = Me.Description(Language)
        Available.Editable = Me.Editable
        Available.Hide = Me.Hide
        Available.Name = Me.Name
        'Available.SubLevel = Me.SubLevel
        'Available.SubPhotoAlbumsNotCreatable = Me.SubPhotoAlbumsNotCreatable
        Available.Title = Me.Title(Language)
        Available.TypeObject = TypeObject.Photo
        Return Available
      End Function

      Public Function ControlOperations(ByRef User As Authentication.User, ByVal Setting As SubSite, Optional ByRef ActualOperationState As Operations = Operations.View) As Control
        Return PhotoManager.ControlOperations(User, Me.Attributes(User, Setting.Language), Setting, ActualOperationState)
      End Function

      Public Class ComparerPhotoByTitle
        Implements Collections.Generic.IComparer(Of Photo)
        Public Language As LanguageManager.Language
        Public Function Compare(ByVal Photo1 As Photo, ByVal Photo2 As Photo) As Integer Implements Collections.Generic.IComparer(Of Photo).Compare
          ' Compare y and x in reverse order.
          Return StrComp(Photo1.Title(Language), Photo2.Title(Language), CompareMethod.Text)
        End Function
        Public Sub New(ByVal Language As LanguageManager.Language)
          Me.Language = Language
        End Sub
      End Class
    End Class

    Private Function EnableUserAtOperations(ByRef User As Authentication.User, ByRef Author As String, ByRef Setting As SubSite) As Boolean
      If User.Role(Setting.Name) > Authentication.User.RoleType.Visitors Then
        If User.Role(Setting.Name) >= Authentication.User.RoleType.AdministratorJunior Then
          Return True
        ElseIf User.Username = Author Then
          Return True
        End If
      End If
      Return False
    End Function
    Function HrefPhotoAlbum(ByVal PhotoAlbum As String, ByVal Setting As Config.SubSite, Optional ByVal Domain As DomainConfiguration = Nothing) As String
      If Domain Is Nothing Then Domain = CurrentDomainConfiguration()
      Return Common.Href(Domain, Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, PhotoAlbum)
    End Function
    Function HrefPhoto(ByVal PhotoAlbum As String, ByVal PhotoName As String, ByVal Setting As Config.SubSite, Optional ByVal Domain As DomainConfiguration = Nothing) As String
      If Domain Is Nothing Then Domain = CurrentDomainConfiguration()
      Dim Jump As String = Nothing
      If Setup.RenderingEngine.TheLinkOfThumbnailsContainsAJumpToImagePosition = True Then
        Jump = "#TableImg"
      End If
      Return Common.Href(Domain, Setting.Name, False, "showphoto.aspx", QueryKey.ShowPhotoAlbumId, PhotoAlbum, QueryKey.ShowPhotoId, PhotoName) & Jump
    End Function

    Private Function ControlPhotoAlbum(ByRef PhotoAlbum As PhotoAlbum, ByRef Setting As Config.SubSite, ByRef RelativeSubLevel As Integer, Optional ByRef HrefCurrentLevel As Boolean = False, Optional ByVal Domain As DomainConfiguration = Nothing) As Control
      Dim Href As String = Nothing, AddTx As String = Nothing
      If (PhotoAlbum.SubLevel <> RelativeSubLevel) Or HrefCurrentLevel Then
        Href = HrefPhotoAlbum(PhotoAlbum.Name, Setting, Domain)
      End If
      Dim Level As Integer
      If PhotoAlbum.SubLevel = RelativeSubLevel Then
        AddTx = " (" & Phrase(Setting.Language, 55) & ")"
      Else
        'If PhotoAlbum.SubLevel < RelativeSubLevel Then
        'Level = RelativeSubLevel - PhotoAlbum.SubLevel
        'ElseIf PhotoAlbum.SubLevel > RelativeSubLevel Then
        Level = PhotoAlbum.SubLevel - RelativeSubLevel
        'End If
      End If
      Return Components.Folder(PhotoAlbum.Title(Setting.Language) & AddTx, PhotoAlbum.Description(Setting.Language), Href, Setting, Level, FolderType.Pictures)
    End Function

    Private Function ControlThumbnail(ByRef Photo As Photo, ByRef Setting As Config.SubSite, Optional ByVal Target_Blank As Boolean = False, Optional ByVal Size As Integer = Nothing, Optional ByVal BoxMode As ThumbnailBoxMode = ThumbnailBoxMode.Thumbnail, Optional ByVal DomainConfiguration As DomainConfiguration = Nothing, Optional ByVal HttpContext As HttpContext = Nothing) As Control
      If Size = 0 Then
        Size = SizeThumbnail(HttpContext)
      End If
      Dim Width, Height As Integer
      If Photo.Width Then
        ' Get width
        If Photo.Width > Photo.Height Then
          Width = Size
        Else
          Width = Size * Photo.Width / Photo.Height
        End If
        ' Get height
        If Photo.Height > Photo.Width Then
          Height = Size
        Else
          Height = Size * Photo.Height / Photo.Width
        End If
      End If

      Dim Control As New HtmlGenericControl("figure") 'html5
      Control.Attributes.Add("class", "Thumbnail")
      Control.Attributes.Add("itemscope", "itemscope")
      Control.Attributes.Add("itemtype", "http://schema.org/ImageObject")

      If BoxMode = ThumbnailBoxMode.Gallery Then
        Control.Style.Add("width", (Size + 120).ToString & "px")
        Control.Style.Add("height", (Size + 180).ToString & "px")
      ElseIf BoxMode = ThumbnailBoxMode.Avatar Then
        Control.Style.Add("width", "100%")
      Else
        Control.Style.Add("width", (Size + 10).ToString & "px")
      End If

      If DomainConfiguration Is Nothing Then DomainConfiguration = CurrentDomainConfiguration()

      Dim A As New WebControl(HtmlTextWriterTag.A)
      Control.Controls.Add(A)
      Dim Img As New WebControl(HtmlTextWriterTag.Img)
      Img.Attributes.Add("itemprop", "contentURL")

      If Target_Blank Then
        A.Attributes.Add("target", "_blank")
      End If
      A.Attributes.Add("href", HrefPhoto(Photo.Album, Photo.Name, Setting, DomainConfiguration))
      If Size < SizeImagePreview(HttpContext) Then
        Img.CssClass = "thumb"
      Else
        Img.CssClass = "photo"
      End If

      Dim PhotoOfUser As Boolean = Photo.Album.StartsWith("users/") OrElse Photo.Album.StartsWith("forum/")
      If (Setting.SEO.PhotoObfuscation.PhotoOfUsers = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser) OrElse (Setting.SEO.PhotoObfuscation.PhotoOfWebsite = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser = False) Then
        SetCrop(A, Img, Width, Height)
      Else
        If Width Then
          Img.Width = Width
          Img.Height = Height
        End If
        A.Controls.Add(Img)
      End If

      Img.Attributes("src") = Photo.SrcThumbnail(Setting, Size, HttpContext)
      Dim Alt As String = Photo.Title(Setting.Language)
      If Photo.Description(Setting.Language) <> "" Then
        Alt &= ": " & Photo.Description(Setting.Language)
      End If

      If Alt = "" Then
        Alt = Phrase(Setting.Language, 104)
      Else
        Alt = EncodingAttribute(Alt)
      End If

      Img.Attributes.Add("alt", Alt)
      Img.ToolTip = Alt

      Control.Controls.Add(BR)

      Dim Box As New HtmlGenericControl("figcaption")
      Control.Controls.Add(Box)

      Dim Dl As New WebControl(HtmlTextWriterTag.Dl)
      Box.Controls.Add(Dl)

      Dim Title As New WebControl(HtmlTextWriterTag.Dt)
      Title.Attributes.Add("itemprop", "name")
      Title.Controls.Add(TextControl(Photo.Title(Setting.Language)))
      Dl.Controls.Add(Title)

      Dim Description As New WebControl(HtmlTextWriterTag.Dd)
      Description.Attributes.Add("itemprop", "description")
      Description.Controls.Add(ControlDescription(Photo.Description(Setting.Language), Setting))

      Dl.Controls.Add(Description)

      Return Control
    End Function

    Enum ThumbnailBoxMode
      Thumbnail
      Gallery
      Avatar
    End Enum

    Public Function ControlPhoto(ByRef Photo As Photo, ByRef Setting As Config.SubSite) As Control
      Dim Author As User = User.Load(Photo.Author)
      If Author IsNot Nothing Then
        Dim Page As Page = HttpContext.Current.Handler
        Dim MasterPage As MasterPage = Page.Master
        MasterPage.AddAuthors(Author)
      End If
      Dim Width, Height As Integer
      Dim Size As Integer = Config.ShowDefaultImageSize(HttpContext.Current)
      If Photo.Width Then
        ' Get width
        If Photo.Width > Photo.Height Then
          Width = Size
        Else
          Width = Size * Photo.Width / Photo.Height
        End If
        ' Get height
        If Photo.Height > Photo.Width Then
          Height = Size
        Else
          Height = Size * Photo.Height / Photo.Width
        End If
      End If

      '	Dim Control As New Control
      Dim Control As New HtmlGenericControl("figure") 'html5
      Control.Attributes.Add("itemscope", "itemscope")
      Control.Attributes.Add("itemtype", "http://schema.org/ImageObject")

      Dim H1 As New WebControl(HtmlTextWriterTag.H1)
      H1.Attributes.Add("itemprop", "name")

      Control.Controls.Add(H1)
      H1.Controls.Add(TextControl(Photo.Title(Setting.Language)))

      Dim Img As New WebControl(HtmlTextWriterTag.Img)
      Img.CssClass = "photo"

      Img.Attributes.Add("itemprop", "contentURL")
      Img.Attributes("src") = Photo.Src(Setting, Size)
      Dim Alt As String = Photo.Title(Setting.Language)
      If Photo.Description(Setting.Language) <> "" Then
        Alt &= ": " & Photo.Description(Setting.Language)
      End If

      If Alt = "" Then
        Alt = Phrase(Setting.Language, 104)
      Else
        Alt = EncodingAttribute(Alt)
      End If

      Img.Attributes.Add("alt", Alt)
      Img.ToolTip = Alt

      Dim PhotoOfUser As Boolean = Photo.Album.StartsWith("users/") OrElse Photo.Album.StartsWith("forum/")
      If (Setting.SEO.PhotoObfuscation.PhotoOfUsers = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser) OrElse (Setting.SEO.PhotoObfuscation.PhotoOfWebsite = SubSite.SeoFunctions.PhotoObfuscationSetup.PhotoObfuscationType.MakeThemOriginal AndAlso PhotoOfUser = False) Then
        SetCrop(Control, Img, Width, Height)
      Else
        If Width Then
          Img.Width = Width
          Img.Height = Height
        End If
        Control.Controls.Add(Img)
      End If

      Dim Figcaption As New HtmlGenericControl("figcaption")
      Figcaption.Attributes.Add("itemprop", "description")
      Control.Controls.Add(Figcaption)
      Figcaption.Controls.Add(ControlDescription(Photo.Description(Setting.Language), Setting))

      Return Control
    End Function

    Private Function ControlDescription(Description As String, Setting As SubSite) As Control
      Description = HtmlEncode(Description)
      ContextualLink.AddLinks(Description, Setting, CurrentDomainConfiguration, Setting.MainArchive)
      If Setting.SEO.CopyPrevention.Pages Then
        Description = ObfuscateHtml(Description, Setting)
      End If
      Return New LiteralControl(Description)
    End Function

    Private Sub SetCrop(Control As Control, Img As WebControl, Width As Integer, Height As Integer)
      Img.CssClass &= " IO"
      Dim NewWidth, NewHeight As Integer
      'New size after rotation
      Dim Radians As Double = Math.PI / 18 '(18=180*10) 10° Angle rotation
      NewHeight = CInt(Height * Math.Cos(Radians) + Width * Math.Sin(Radians))
      NewWidth = CInt(Height * Math.Sin(Radians) + Width * Math.Cos(Radians))
      'Size of outside box after rotation
      Dim WidthBox, HeightBox As Double

      HeightBox = NewHeight * Math.Cos(Radians) + NewWidth * Math.Sin(Radians)
      WidthBox = NewHeight * Math.Sin(Radians) + NewWidth * Math.Cos(Radians)

      Img.Style.Add("position", "absolute")
      Img.Style.Add("top", (CInt(-1 + (NewHeight - HeightBox) / 2.0!)).ToString & "px")
      Img.Style.Add("left", (CInt(-1 + (NewWidth - WidthBox) / 2.0!)).ToString & "px")
      Img.Width = CInt(1.02 * NewWidth)
      Img.Height = CInt(1.02 * NewHeight)

      Dim Crop As New WebControl(HtmlTextWriterTag.Div)
      Crop.CssClass = "crop"
      'Crop.Style.Add("border-style", "inset")
      Crop.Style.Add("overflow", "hidden")
      Crop.Style.Add("position", "relative")
      Crop.Width = Width
      Crop.Height = Height
      Crop.Controls.Add(Img)
      Control.Controls.Add(Crop)
    End Sub



  End Module

End Namespace
