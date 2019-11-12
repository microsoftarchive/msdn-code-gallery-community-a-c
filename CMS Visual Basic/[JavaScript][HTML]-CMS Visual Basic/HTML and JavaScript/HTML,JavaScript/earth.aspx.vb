Imports WebApplication
Partial Class earth
	Inherits System.Web.UI.Page
	Private Setting As SubSite
  Public MasterPage As Components.MasterPage
	'Private Template As Template

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		'template = Common.LoadTemplate(Me, Setting, True, , False, False, , False)
		MasterPage = SetMasterPage(Me, , False, True)
		'MasterPage.ShowRightBar = False 'Hide Google Adds
		Setting = CurrentSetting()

    '++++++++ Compatibility old query string Key. Implemented 25/12/2012
    If Request.QueryString("c") IsNot Nothing Then Response.RedirectPermanent(ReplaceBin(AbsoluteUri(Request), "c=", QueryKey.City & "="), True)
    Dim Url As String = AbsoluteUri(Request)
    If Request.QueryString("s") IsNot Nothing Then Url = ReplaceBin(Url, "&s=", "&" & QueryKey.Country & "=") : Url = ReplaceBin(Url, "?s=", "?" & QueryKey.Country & "=")
    If String.Compare(Url, AbsoluteUri(Request), False) <> 0 Then Response.RedirectPermanent(Url, True)
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    If Me.City.Text = "" Then
      If Request(QueryKey.City) IsNot Nothing Then
        Me.City.Text = Request(QueryKey.City)
      End If
    End If

    If Me.Country.Text = "" Then
      If Request(QueryKey.Country) IsNot Nothing Then
        Me.Country.Text = Request(QueryKey.Country)
      End If
    End If

    If Latitude.Text = "" Then
      If Request(QueryKey.Latitude) IsNot Nothing Then
        Latitude.Text = Request(QueryKey.Latitude)
      End If
    End If

    If Longitude.Text = "" Then
      If Request(QueryKey.Longitude) IsNot Nothing Then
        Longitude.Text = Request(QueryKey.Longitude)
      End If
    End If

    MasterPage.TitleDocument = Me.City.Text
    MasterPage.KeyWords = Me.City.Text
    If Me.Country.Text <> "" Then
      MasterPage.TitleDocument &= " (" & Me.Country.Text & ")"
      MasterPage.KeyWords &= "," & Me.Country.Text
    End If
    MasterPage.Description = MasterPage.TitleDocument

    Dim AllCity As Collections.Generic.List(Of City) = Nothing
    If Me.City.Text <> "" Then
      AllCity = Tables.FindCity(Me.City.Text)
      If AllCity IsNot Nothing Then
        AllCity = AllCity.GetRange(0, AllCity.Count) 'Get a copy
        If Country.Text <> "" Then
          For N As Integer = AllCity.Count - 1 To 0 Step -1
            If StrComp(CountryName(AllCity(N)), Country.Text, CompareMethod.Text) <> 0 Then
              AllCity.Remove(AllCity(N))
            End If
          Next
        End If
      End If
    End If

    Dim City As City
    If AllCity IsNot Nothing Then
      If AllCity.Count = 1 Then
        'If only one city with this name, show map of this siti, elese sho city list
        City = AllCity(0)
        SetCityInformations(City)
      Else
        PanelCityList.Visible = True
        For Each City In AllCity
          Dim LinkCity As New HyperLink
          LinkCity.Text = HttpUtility.HtmlEncode(City.City & " (" & CountryName(City) & " - " & RegionName(City) & ")")
          LinkCity.NavigateUrl = Href(Setting.Name, False, "earth.aspx", EarthManager.QueryStringParameters(City.City, Tables.CountryName(City), City.Latitude, City.Longitude))
          PanelCityList.Controls.Add(LinkCity)
          PanelCityList.Controls.Add(BR)
        Next
      End If
    End If

    If Latitude.Text <> "" And Longitude.Text <> "" Then
      ShowMap(Latitude.Text, Longitude.Text)
    End If

    If Legend.Controls.Count = 0 Then
      Legend.Attributes.Add("display", "none")
    End If
  End Sub

	Private Sub SetCityInformations(ByVal City As City)
    If City IsNot Nothing Then
      Dim Culture As Globalization.CultureInfo = New Globalization.CultureInfo("en-US")
      Legend.Attributes.Add("itemscope", "itemscope")
      Legend.Attributes.Add("itemtype", "http://schema.org/GeoCoordinates")
      Dim LabelCity As New Label
      LabelCity.Text = City.City
      LabelCity.Attributes.Add("itemprop", "name")
      Legend.Controls.Add(LabelCity)
      Legend.Controls.Add(New LiteralControl(" ("))
      Dim LabelLatitude As New Label
      LabelLatitude.Text = City.Latitude.ToString(Culture)
      LabelLatitude.ToolTip = Phrase(Setting.Language, 115)
      LabelLatitude.Attributes.Add("itemprop", "latitude")
      Legend.Controls.Add(LabelLatitude)
      Legend.Controls.Add(New LiteralControl("-"))
      Dim LabelLongitude As New Label
      LabelLongitude.Text = City.Longitude.ToString(Culture)
      LabelLongitude.ToolTip = Phrase(Setting.Language, 116)
      LabelLongitude.Attributes.Add("itemprop", "latitude")
      Legend.Controls.Add(LabelLongitude)
      Legend.Controls.Add(New LiteralControl(")"))

      Me.City.Text = City.City
      Me.Country.Text = CountryName(City)
      Latitude.Text = City.Latitude.ToString(Culture)
      Longitude.Text = City.Longitude.ToString(Culture)
    End If
	End Sub

	Private Sub ShowMap(ByVal Latitude As String, ByVal Longitude As String)
		'This script must be insert in html head
		Dim CodeHeader As String = "<script type=""text/javascript"" src=""http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2""></script><script type=""text/javascript"">var map = null;function GetMap(){map = new VEMap('myMap');map.LoadMap(new VELatLong(" & Latitude & ", " & Longitude & "), 10 ,'h' ,false);}</script>"
		AddLiteral(Page.Header, CodeHeader)

		Dim Code As String = "<div id='myMap' style=""position:relative; width:100%; height:550px;""></div>"
		Code &= "<script type=""text/javascript"">document.body.onload=GetMap();</script>"
		AddLiteral(PlaceHolderMap, Code)
		'Dim Ctrl As Object = Page.Controls(0).Controls(3)
		'Ctrl.Attributes.Add("onload", "GetMap();")
	End Sub

	Protected Sub ShowPosition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowPosition.Click
		City.Text = ""
		Country.Text = ""
	End Sub

End Class
