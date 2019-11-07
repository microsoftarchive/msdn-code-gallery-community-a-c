Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Script.Serialization

Namespace Account
	Public NotInheritable Class AccountHelpers
		Private Sub New()
		End Sub
		Public Shared Sub Require(errors As IList(Of String), fieldValue As String, [error] As String)
			If [String].IsNullOrEmpty(fieldValue) Then
				errors.Add([error])
			End If
		End Sub

		Public Shared Sub WriteJsonResponse(response As HttpResponse, errors As List(Of String))
			WriteJsonResponse(response, New With { _
				Key .success = errors.Count = 0, _
				Key .errors = errors _
			})
		End Sub

		Public Shared Sub WriteJsonResponse(response As HttpResponse, errors As List(Of String), redirect As String)
			WriteJsonResponse(response, New With { _
				Key .success = errors.Count = 0, _
				Key .errors = errors, _
				Key .redirect = redirect _
			})
		End Sub

		Public Shared Sub WriteJsonResponse(response As HttpResponse, model As Object)
			Dim serializer = New JavaScriptSerializer()
			Dim json As String = serializer.Serialize(model)
			response.Write(json)
			response.[End]()
		End Sub
	End Class
End Namespace
