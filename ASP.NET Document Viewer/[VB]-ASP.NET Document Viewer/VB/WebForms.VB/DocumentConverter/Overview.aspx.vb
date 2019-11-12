Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.DocumentUltimate
Imports GleamTech.Examples
Imports GleamTech.IO
Imports GleamTech.Util

Namespace DocumentConverter
    Public Class OverviewPage
        Inherits Page

        Protected InputFormat As String
        Protected ConvertHandlerUrl As String

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            Dim inputDocument = exampleFileSelector.SelectedFile
            Dim fileInfo = New FileInfo(inputDocument)

            Dim inputFormat1 = DocumentFormatInfo.[Get](inputDocument)
            InputFormat = If(inputFormat1 IsNot Nothing, inputFormat1.Description, "(not supported)")

            PopulatePossibleOutputFormats(inputDocument)

            ConvertHandlerUrl = ExamplesConfiguration.GetDynamicDownloadUrl(ConvertHandlerName, 
                New NameValueCollection() From {
                    {"inputDocument", ExamplesConfiguration.ProtectString(inputDocument)},
                    {"version", fileInfo.LastWriteTimeUtc.Ticks & "-" & fileInfo.Length}
                })
        End Sub

        Private Sub PopulatePossibleOutputFormats(inputDocument As String)
            Dim outputFormats1 = New Dictionary(Of String, List(Of ListItem))()

            For Each format As DocumentFormat In DocumentUltimate.DocumentConverter.EnumeratePossibleOutputFormats(inputDocument)
                Dim formatInfo = DocumentFormatInfo.[Get](Format)

                Dim groupData As List(Of ListItem) = Nothing
                If Not outputFormats1.TryGetValue(formatInfo.Group.Description, groupData) Then
                    groupData = New List(Of ListItem)()
                    outputFormats1.Add(formatInfo.Group.Description, groupData)
                End If
                groupData.Add(New ListItem(formatInfo.Description, formatInfo.Value.ToString()))
            Next

            If outputFormats1.Count = 0 Then
                outputFormats1.Add("(not supported)", New List(Of ListItem)())
            End If

            OutputFormats.DataSource = outputFormats1
            OutputFormats.DataBind()
        End Sub

        Public Shared Sub ConvertHandler(context As IHttpContext)
            Dim result As DocumentConverterResult

            Try
                Dim inputDocument = New BackSlashPath(ExamplesConfiguration.UnprotectString(context.Request("inputDocument")))
                Dim outputFormat = DirectCast([Enum].Parse(GetType(DocumentFormat), context.Request("outputFormat")), DocumentFormat)
                Dim fileName = inputDocument.FileNameWithoutExtension + "." + DocumentFormatInfo.[Get](outputFormat).DefaultExtension
                Dim outputPath = ConvertedPath.Append(context.Session.Id).Append(fileName)
                Dim outputDocument = outputPath.Append(fileName)

                If Directory.Exists(outputPath) Then
                    Directory.Delete(outputPath, True)
                End If
                Directory.CreateDirectory(outputPath)
                result = DocumentUltimate.DocumentConverter.Convert(inputDocument, outputDocument, outputFormat)
            Catch exception As Exception
                context.Response.Output.Write("<span style=""color: red; font-weight: bold"">Conversion failed</span><br/>")
                context.Response.Output.Write(exception.Message)
                Return
            End Try

            context.Response.Output.Write("<span style=""color: green; font-weight: bold"">Conversion successful</span>")
            context.Response.Output.Write("<br/>Conversion time: " & result.ElapsedTime.ToString())
            context.Response.Output.Write("<br/>Output files:")

            If result.OutputFiles.Length > 1 Then
                context.Response.Output.Write(Convert.ToString(" - ") & GetZipDownloadLink(New FileInfo(result.OutputFiles(0)).Directory))
            End If

            context.Response.Output.Write("<br/><ol>")
            For Each outputFile As String In result.OutputFiles
                If outputFile.EndsWith("\") Then
                    Dim directoryInfo = New DirectoryInfo(outputFile)
                    context.Response.Output.Write(String.Format("<br/><li><b>{0}\</b> - {1}</li>", directoryInfo.Name, GetZipDownloadLink(directoryInfo)))
                Else
                    Dim fileInfo = New FileInfo(outputFile)
                    context.Response.Output.Write(String.Format("<br/><li><b>{0}</b> ({1} bytes) - {2}</li>", fileInfo.Name, fileInfo.Length, GetDownloadLink(fileInfo)))
                End If
            Next
            context.Response.Output.Write("<br/></ol>")
        End Sub

        Private Shared Function GetDownloadLink(fileInfo As FileInfo) As String
            Return String.Format("<a href=""{0}"">Download</a>", ExamplesConfiguration.GetDownloadUrl(fileInfo.FullName, fileInfo.LastWriteTimeUtc.Ticks.ToString()))
        End Function

        Private Shared Function GetZipDownloadLink(directoryInfo As DirectoryInfo) As String
            Return String.Format("<a href=""{0}"">Download as Zip</a>", ExamplesConfiguration.GetDynamicDownloadUrl(ZipDownloadHandlerName, New NameValueCollection() From {
                {"path", ExamplesConfiguration.ProtectString(directoryInfo.FullName)},
                {"version", directoryInfo.LastWriteTimeUtc.Ticks.ToString()}
            }))
        End Function

        Public Shared Sub ZipDownloadHandler(context As IHttpContext)
            Dim path = New BackSlashPath(ExamplesConfiguration.UnprotectString(context.Request("path"))).RemoveTrailingSlash()

            Dim fileResponse = New FileResponse(context, 0)
            fileResponse.Transmit(Sub(targetStream, copyFileCallback)
                                      QuickZip.Zip(targetStream, Directory.EnumerateFileSystemEntries(path))
                                  End Sub, path.FileName + ".zip", 0)

        End Sub

        Private Shared ReadOnly Property ConvertHandlerName() As String
            Get
                If m_convertHandlerName Is Nothing Then
                    m_convertHandlerName = "ConvertHandler"
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(m_convertHandlerName, AddressOf ConvertHandler)
                End If

                Return m_convertHandlerName
            End Get
        End Property
        Private Shared m_convertHandlerName As String

        Private Shared ReadOnly Property ZipDownloadHandlerName() As String
            Get
                If m_zipDownloadHandlerName Is Nothing Then
                    m_zipDownloadHandlerName = "ZipDownloadHandler"
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(m_zipDownloadHandlerName, AddressOf ZipDownloadHandler)
                End If

                Return m_zipDownloadHandlerName
            End Get
        End Property
        Private Shared m_zipDownloadHandlerName As String

        Private Shared ReadOnly ConvertedPath As BackSlashPath = Hosting.ResolvePhysicalPath("~/App_Data/ConvertedDocuments")
    End Class
End Namespace