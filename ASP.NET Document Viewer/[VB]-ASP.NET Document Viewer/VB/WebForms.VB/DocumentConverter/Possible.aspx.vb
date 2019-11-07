Imports GleamTech.AspNet
Imports GleamTech.DocumentUltimate
Imports GleamTech.Examples

Namespace DocumentConverter
    Public Class PossiblePage
        Inherits Page

	Protected InputFormatCount As Integer
	Protected OutputFormatCount As Integer
	Protected ResultHandlerUrl As String

	Protected Sub Page_Load(sender As Object, e As EventArgs)
		PopulateInputFormats()
		PopulateOutputFormats()

		ResultHandlerUrl = ExamplesConfiguration.GetDynamicDownloadUrl(ResultHandlerName, 
            New NameValueCollection() From { 
			    {"version", DateTime.UtcNow.Ticks.ToString()} 
		    })
	End Sub

	Private Sub PopulateInputFormats()
		Dim inputFormats1 = New Dictionary(Of String, List(Of ListItem))()

		For Each formatInfo As DocumentFormatInfo In DocumentFormatInfo.Enumerate(DocumentFormatSupport.Load)
			Dim groupData As List(Of ListItem) = Nothing
			If Not inputFormats1.TryGetValue(formatInfo.Group.Description, groupData) Then
				groupData = New List(Of ListItem)()
				inputFormats1.Add(formatInfo.Group.Description, groupData)
			End If
			groupData.Add(New ListItem(formatInfo.Description, formatInfo.Value.ToString()))
			InputFormatCount += 1
		Next

		InputFormats.DataSource = inputFormats1
		InputFormats.DataBind()
	End Sub

	Private Sub PopulateOutputFormats()
		Dim outputFormats1 = New Dictionary(Of String, List(Of ListItem))()

		For Each formatInfo As DocumentFormatInfo In DocumentFormatInfo.Enumerate(DocumentFormatSupport.Save)
			Dim groupData As List(Of ListItem) = Nothing
			If Not outputFormats1.TryGetValue(formatInfo.Group.Description, groupData) Then
				groupData = New List(Of ListItem)()
				outputFormats1.Add(formatInfo.Group.Description, groupData)
			End If
			groupData.Add(New ListItem(formatInfo.Description, formatInfo.Value.ToString()))
			OutputFormatCount += 1
		Next

		OutputFormats.DataSource = outputFormats1
		OutputFormats.DataBind()
	End Sub

        Public Shared Sub ResultHandler(context As IHttpContext)
            Dim inputFormat = DirectCast([Enum].Parse(GetType(DocumentFormat), context.Request("inputFormat")), DocumentFormat)
            Dim outputFormat = DirectCast([Enum].Parse(GetType(DocumentFormat), context.Request("outputFormat")), DocumentFormat)

            context.Response.Output.Write("<center>")

            If DocumentUltimate.DocumentConverter.CanConvert(inputFormat, outputFormat) Then
                context.Response.Output.Write(String.Format("<span style=""color: green; font-weight: bold"">Direct conversion from {0} to {1} is possible</span>", inputFormat, outputFormat))

                For Each engine As DocumentEngine In [Enum](Of DocumentEngine).GetValues()
                    If DocumentUltimate.DocumentConverter.CanConvert(inputFormat, outputFormat, engine) Then
                        context.Response.Output.Write(String.Format(
                        "<br/><span style=""color: green; font-weight: bold"">Via {0} Engine &#x2713;</span>",
                        engine))
                    Else
                        context.Response.Output.Write(String.Format(
                        "<br/><span style=""color: red; font-weight: bold"">Via {0} Engine &#x2717;</span>",
                        engine))
                    End If
                Next
            Else
                context.Response.Output.Write(String.Format("<span style=""color: red; font-weight: bold"">Direct conversion from {0} to {1} is not possible</span>", inputFormat, outputFormat))
            End If

            context.Response.Output.Write("</center>")
        End Sub

        Private Shared ReadOnly Property ResultHandlerName() As String
		Get
			If m_resultHandlerName Is Nothing Then
				m_resultHandlerName = "ResultHandler"
				ExamplesConfiguration.RegisterDynamicDownloadHandler(m_resultHandlerName, AddressOf ResultHandler)
			End If

			Return m_resultHandlerName
		End Get
	End Property
	Private Shared m_resultHandlerName As String
    End Class
End Namespace