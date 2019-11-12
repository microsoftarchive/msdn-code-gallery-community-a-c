Imports WebApplication
Partial Class Profile
  Inherits System.Web.UI.Page
  Private Setting As SubSite
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Setting = CurrentSetting()
    If Request("u") <> "" Then
      Response.RedirectPermanent(Href(Setting.Name, False, "homeuser.aspx", "u", Request("u")), True)
    End If
    Response.RedirectPermanent(Href(Setting.Name, False, "default.aspx"), True)
  End Sub
End Class
