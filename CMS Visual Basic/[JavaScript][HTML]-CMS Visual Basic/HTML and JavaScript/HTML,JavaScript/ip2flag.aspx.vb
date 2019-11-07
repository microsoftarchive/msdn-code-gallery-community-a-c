Imports WebApplication
Partial Class ip2flag
    Inherits System.Web.UI.Page

  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    Dim Ip As String = Request("ip")
    IpToCountryFlag(Ip)
  End Sub
End Class
