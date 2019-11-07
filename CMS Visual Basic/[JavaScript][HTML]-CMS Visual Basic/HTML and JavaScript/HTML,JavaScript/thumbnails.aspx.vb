Imports WebApplication
Imports System.Xml.Serialization

Partial Class thumbnails
	Inherits System.Web.UI.Page
	Private Setting As Config.SubSite

	Protected Sub thumbnails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    '++++++++ Compatibility old query string Key. Implemented 25/12/2012
    If Request.QueryString("album") IsNot Nothing Then Response.RedirectPermanent(ReplaceBin(AbsoluteUri(Request), "album=", QueryKey.ViewAlbum & "="), True)
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    Dim Album As String = Request.QueryString(QueryKey.ViewAlbum)
		Dim Operation As PhotoManager.Operations = Val(Request.QueryString("operation"))
		Setting = CurrentSetting()
		If Operation = PhotoManager.Operations.MakeJavascriptPhotosList OrElse Operation = Operations.ViewXML Then
      Dim PhotoAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(Album)
      If PhotoAlbum IsNot Nothing Then
        Dim ListPhotos As New ListPhotos
        Dim FirstItem As New TextValue
        FirstItem.text = Phrase(Setting.Language, 3066)
        FirstItem.value = ""
        ListPhotos.item.Add(FirstItem)
        AddPhotos(ListPhotos, PhotoAlbum, Setting.Language, , Request.QueryString("author"))
        If Request.QueryString("AddAlbum") <> "" Then
          Dim AddAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(Request.QueryString("AddAlbum"))
          AddPhotos(ListPhotos, AddAlbum, Setting.Language, , Request.QueryString("author"))
        End If

        Select Case Operation
          Case Operations.ViewXML
            Response.ContentType = "text/xml;charset=utf-8"
            Dim xml As New XmlSerializer(GetType(ListPhotos))
            Dim xmlns As New XmlSerializerNamespaces
            xmlns.Add(String.Empty, String.Empty)
            xml.Serialize(Response.OutputStream, ListPhotos, xmlns)
          Case Operations.MakeJavascriptPhotosList
            Response.ContentType = "text/javascript"
            Dim Texts As String = Nothing
            Dim Values As String = Nothing
            For Each TextValue As TextValue In ListPhotos.item
              'If the client perform the "unescape", need replace the "%" with "%25"
              Texts &= IfStr(Texts IsNot Nothing, ",", "") & """" & ReplaceBin(AbjustForJavascriptString(TextValue.text), "%", "%25") & """"
              'If the client perform the "unescape", need replace the "%" with "%25"
              Values &= IfStr(Values IsNot Nothing, ",", "") & """" & ReplaceBin(AbjustForJavascriptString(TextValue.value), "%", "%25") & """"
            Next
            Texts = "var Texts=new Array(" & Texts & ");"
            Values = "var Values=new Array(" & Values & ");"
            Response.Write(Texts & Values & "setTimeout(""UpdateImageList(Texts,Values)"",1);")
        End Select
      End If
      Response.End()
    Else
      'Template = New Template(Me, Setting, True, , False, False, , , False)
      Dim MasterPage As MasterPage = SetMasterPage(Me, , False, True)
      Dim ActualOperation As PhotoManager.Operations
      Dim ObjAlbum As PhotoAlbum = PhotoManager.PhotoAlbum.Load(Album)

      If ObjAlbum Is Nothing Then
        RedirectToHomePage(Setting)
      End If

      Dim AlbumLower As String = Album.ToLower

      If AlbumLower.StartsWith("users") Then
        Dim Author As Authentication.User = Authentication.User.Load(ObjAlbum.Author)
        If Author IsNot Nothing Then
          RedirectToAppropriateSubSite(Author, Setting)
        Else
          Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
        End If
      Else
        RedirectToSubSiteWithAppropriateForum(AlbumLower, Setting)
        RedirectToSubSiteWithAppropriatePhotoAlbum(AlbumLower, Setting)
      End If

      MasterPage.TitleDocument = ObjAlbum.Title(Setting.Language)
      MasterPage.Description = ObjAlbum.Description(Setting.Language)
      MasterPage.Author = ObjAlbum.Author

      If Page.IsPostBack Then
        Call Submit(ObjAlbum)
        ActualOperation = PhotoManager.Operations.View
      Else
        ActualOperation = Operation
      End If

      AddControlOperations(ObjAlbum, ActualOperation)
      AddAlbumNavigator(ObjAlbum)
      If ActualOperation = PhotoManager.Operations.View Then
        PhotoOperations.Visible = False
        AddThumbnail(ObjAlbum)
      Else
        PhotoOperations.Operation(PhotoManager.TypeObject.PhotoAlbum, Operation, Setting.Language)
        PhotoOperations.PhraseTitle = Phrase(Setting.Language, 101)
        PhotoOperations.PhraseDescription = Phrase(Setting.Language, 102)
        Select Case Operation
          Case PhotoManager.Operations.CreateSubFotoAlbum
          Case PhotoManager.Operations.Delete
            PhotoOperations.Alert = Ask(Phrase(Setting.Language, 57, 58), Setting.Language)
          Case PhotoManager.Operations.Edit
            PhotoOperations.TitleValue = ObjAlbum.Title(Setting.Language)
            PhotoOperations.DescriptionValue = ObjAlbum.Description(Setting.Language)
        End Select
      End If
    End If
  End Sub

  Sub AddThumbnail(ByVal Album As PhotoManager.PhotoAlbum)
    PlaceHolder1.Controls.Add(Album.ControlPhotos(Setting))
  End Sub

  Sub AddControlOperations(ByVal Album As PhotoManager.PhotoAlbum, ByVal ActualOperation As PhotoManager.Operations)
    PlaceHolder1.Controls.Add(Album.ControlOperations(CurrentUser, Setting, ActualOperation))
  End Sub

  Sub AddAlbumNavigator(ByVal Album As PhotoManager.PhotoAlbum)
    PlaceHolder1.Controls.Add(Album.Navigator(Setting))
  End Sub

  Private Sub Submit(ByVal ObjAlbum As PhotoManager.PhotoAlbum)
    Dim Operation As PhotoManager.Operations = Val(Request.QueryString("operation"))
    Select Case Operation
      Case PhotoManager.Operations.CreateSubFotoAlbum
        Dim SubPhotoAlbum As PhotoManager.PhotoAlbum = ObjAlbum.CreateSubFotoAlbum(CurrentUser, Setting)
        SubPhotoAlbum.Title(Setting.Language) = Request(PhotoOperations.TitleName)
        SubPhotoAlbum.Description(Setting.Language) = Request(PhotoOperations.DescriptionName)
        'SuBFotoAlbum.Title(Setting.Language) = title.Value
        'SuBFotoAlbum.Description(Setting.Language) = description.Value
        SubPhotoAlbum.Save()
        Response.Redirect(Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, SubPhotoAlbum.Name))
        'Response.Redirect(Page.Request.ServerVariables("URL") & "?ss=" & Request.QueryString("ss") & "&album=" & SubPhotoAlbum.Name)
      Case PhotoManager.Operations.Delete
        ObjAlbum.Delete(CurrentUser, Setting)
        Dim ParentAlbum As PhotoManager.PhotoAlbum = ObjAlbum.Parent
        If IsNothing(ParentAlbum) Then
          RedirectToHomePage(Setting)
        Else
          Response.Redirect(Href(Setting.Name, False, "thumbnails.aspx", QueryKey.ViewAlbum, ParentAlbum.Name))
          'Response.Redirect(Page.Request.ServerVariables("URL") & "?ss=" & Request.QueryString("ss") & "&album=" & ParentAlbum.Name)
        End If
      Case PhotoManager.Operations.Edit
        ObjAlbum.Edit(CurrentUser, Setting, Request(PhotoOperations.TitleName), Request(PhotoOperations.DescriptionName))
    End Select
  End Sub
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

End Class