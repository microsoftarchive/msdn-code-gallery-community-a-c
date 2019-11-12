Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports ColorCode

Namespace SelectPdf.Samples
	Public Partial Class Samples
		Inherits System.Web.UI.MasterPage

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Request.Url.AbsolutePath.ToLower().Contains("default.aspx") Then
                LitCode.Visible = False
            Else
                Try
                    LitCode.Text = "<h1>Sample Code Vb.Net</h1><br/><br/>"
                    Dim code As String = System.IO.File.ReadAllText(Server.MapPath(Request.Url.AbsolutePath) + ".vb")
                    LitCode.Text = LitCode.Text & "<div style='width=90%; overflow: auto; border: 1px solid #DDDDDD; padding: 10px;'>" & New CodeColorizer().Colorize(code, Languages.VbDotNet) & "</div>"
                Catch
                    LitCode.Visible = False
                End Try
            End If
        End Sub
	End Class
End Namespace
