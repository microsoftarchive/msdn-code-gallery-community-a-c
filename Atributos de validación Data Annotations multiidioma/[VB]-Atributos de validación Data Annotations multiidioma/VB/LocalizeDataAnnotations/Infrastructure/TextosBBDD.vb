Imports System.Threading

Public NotInheritable Class TextosBBDD

    Private Shared _textos As DataTable

    Public Shared Function Recuperar(textoID As String) As String
        If _textos Is Nothing Then
            _textos = New DataTable()
            _textos.ReadXml(HttpContext.Current.Server.MapPath("~/Content/Textos.xml"))
        End If
        Dim idioma As String = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName
        If idioma <> "en" Then idioma = "es"
        Dim row As DataRow = _textos.Rows.Find(New Object() {textoID, idioma})
        If row IsNot Nothing Then
            Return row("Texto").ToString()
        Else
            Return Nothing
        End If
    End Function

End Class
