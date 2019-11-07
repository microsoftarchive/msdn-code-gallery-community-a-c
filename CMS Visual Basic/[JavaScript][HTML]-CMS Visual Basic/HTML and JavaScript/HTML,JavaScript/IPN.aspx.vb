Imports WebApplication
Partial Class IPN
  Inherits System.Web.UI.Page
	Private ServicePaid As String
  Private IdOrder As String

  Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
    Dim ThisError As System.Exception = Server.GetLastError
    Try
      Extension.Log("IPN", 1000, "ERROR" & vbCrLf, HttpContext.Current.Request.UserHostAddress & vbCrLf, ThisError.Message & vbCrLf, ThisError.Source & vbCrLf, ThisError.StackTrace & vbCrLf)
    Catch ex As Exception
    End Try
  End Sub
	'Private Setting As Config.SubSite

  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    'Setting = CurrentSetting()
    Try
      Extension.Log("IPN", 1000, Request.Form("item_number"), Request.UserHostAddress, HostUser, HttpContext.Current.Request.UserHostAddress)
    Catch ex As Exception
    End Try
    If Request.Form("item_number") <> "" Then
      Dim Value As String() = Split(Request.Form("item_number"), "|")
      ServicePaid = Value(0)
      IdOrder = Value(1)
      PayManager.Delivery(ServicePaid, IdOrder)
      Response.End()
    End If
  End Sub
End Class
