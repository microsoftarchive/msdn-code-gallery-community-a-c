Imports System.Data.SqlClient
Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.DocumentUltimate
Imports GleamTech.DocumentUltimate.AspNet

Namespace DocumentViewer
    Public Class StreamPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ' The document handler type which provides a custom way of loading the input files.
            ' This class should implement IDocumentHandler interface and should have a parameterless
            ' constructor so that it can be instantiated internally when necessary.
            ' Value of Document property will be passed to this handler which should open 
            ' and return a readable stream according to that file identifier.
            ' See below for CustomDocumentHandler class which implements IDocumentHandler interface
            documentViewer.DocumentHandlerType = GetType(CustomDocumentHandler)

            ' If a custom document handler is provided via DocumentHandlerType property, then
            ' this value will be passed to that handler which should open and return a readable stream according 
            ' to this file identifier. 
            ' So it can be any string value that your IDocumentHandler implementation understands.
            documentViewer.Document = "~/App_Data/ExampleFiles/Default.docx"


            ' ---------------------------------------------
            ' Here is an example (commented out) for loading a document from database.
            ' See below for DbDocumentHandler class which implements IDocumentHandler interface.
            ' This loads the document with passed ID (176) from the database

            'documentViewer.DocumentHandlerType = typeof(DbDocumentHandler);
            'documentViewer.Document = "176"; ' a file path or identifier
            ' When you need to pass custom parameters along with the input file to your handler implementation,
            ' use documentViewer.DocumentHandlerParameters property to set your parameters.
            ' These will be passed to the methods of your handler implementation:
            'documentViewer.DocumentHandlerParameters.Set("connectionString", "SOME CONNECTION STRING")
            ' ---------------------------------------------


            ' ---------------------------------------------
            ' When you don't have a file on disk and implementing IDocumentHandler interface is not convenient, 
            ' you can use documentViewer.DocumentSource property to load documents from a stream or a byte array. 
            ' Note that your stream or byte array will be copied to the cache folder if not already exists 
            ' when you load via DocumentSource because DocumentViewer needs to access your document 
            ' out of the context of the host page (i.e. serialization is needed). 

            ' Load document from a stream:
            'documentViewer.DocumentSource = New DocumentSource(
            '    New DocumentInfo(uniqueId, fileName), 
            '    New StreamResult(stream)
            ')

            ' Load document from a byte array:
            'documentViewer.DocumentSource = New DocumentSource(
            '    New DocumentInfo(uniqueId, fileName), 
            '    byteArray
            ')
            ' ---------------------------------------------

        End Sub
    End Class


    ' Implement IDocumentHandler interface to provide a custom way of loading the input files.
    ' You can instruct DocumentViewer to use this handler by setting DocumentViewer.DocumentHandlerType
    ' property to type of this class, i.e. typeof(CustomDocumentHandler)
    ' For the simplicity of this example, we are getting a stream from a file on disk.
    ' Otherwise the stream can come from network or a database or even a zip file.
    Public Class CustomDocumentHandler
        Implements IDocumentHandler

        ' Get the document information required for the current input file.
        ' This is called before loading the document for determining the cache key and document format.
        '
        ' inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        ' the input file that was requested to be loaded in DocumentViewer
        '
        ' Return a DocumentInfo instance initialized with required information from this method.
        Public Function GetInfo(inputFile As String, handlerParameters As DocumentHandlerParameters) As DocumentInfo Implements IDocumentHandler.GetInfo

            Dim physicalPath = Hosting.ResolvePhysicalPath(inputFile)
            Dim fileInfo As New FileInfo(physicalPath)

            ' uniqueId parameter (required):
            ' The unique identifier that will be used for generating the cache key for this document.
            ' For instance, it can be an ID from your database table or a simple file name; 
            ' you just need to make sure this ID varies for each different document so that they are cached correctly.
            ' For example for files on disk,
            ' we internally use a string combination of file extension, file size and file date for uniquely
            ' identifying them, this way cache collisions do not occur and we can resuse the cached file
            ' even if the file name before extension is changed (because it's still the same document).
            Dim uniqueId = String.Concat(
                fileInfo.Extension.ToLowerInvariant(), 
                fileInfo.Length, 
                fileInfo.LastWriteTimeUtc.Ticks)

            ' fileName parameter (optional but recommended):
            ' The file name which will be used for display purposes such as when downloading the document
            ' within DocumentViewer> or for the subfolder name prefix in cache folder. 
            ' It will also be used to determine the document format from extension if format 
            ' parameter is not specified. If not specified or empty, uniqueId will be used 
            ' as the file name.
            Dim fileName = fileInfo.Name

            Return New DocumentInfo(uniqueId, fileName)

        End Function

        ' Open a readable stream for the current input file.
        '
        ' inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        ' the input file that was requested to be loaded in DocumentViewer
        '
        ' inputOptions parameter will be determined according to the input document format
        ' Usually you will not need to check this parameter as inputFile parameter should be sufficient
        ' for you to locate and open a corresponding stream.
        '
        ' Return a StreamResult instance initialized with a readable System.IO.Stream object.
        Public Function OpenRead(inputFile As String, inputOptions As InputOptions, handlerParameters As DocumentHandlerParameters) As StreamResult Implements IDocumentHandler.OpenRead

            Dim physicalPath = Hosting.ResolvePhysicalPath(inputFile)
            Dim stream = File.OpenRead(physicalPath)

            Return New StreamResult(stream)

        End Function

    End Class


    ' This is a sample IDocumentHandler implementation for loading a document from database.
    ' You can instruct DocumentViewer to use this handler by setting DocumentViewer.DocumentHandlerType
    ' property to type of this class, i.e. typeof(DbDocumentHandler)
    ' This sample demonstrates raw db access with System.Data objects
    ' but you can use any type of db access (e.g. Entity Framework), the idea is same.
    Public Class DbDocumentHandler
        Implements IDocumentHandler

        ' Get the document information required for the current input file.
        ' This is called for determining the cache key and document format whenever 
        ' DocumentViewer requests a document.
        '
        ' inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        ' the input file that was requested to be loaded in DocumentViewer
        '
        ' Return a DocumentInfo instance initialized with required information from this method.
        Public Function GetInfo(inputFile As String, handlerParameters As DocumentHandlerParameters) As DocumentInfo Implements IDocumentHandler.GetInfo
            Dim fileId = inputFile
            Dim fileName As String

            ' Get your parameters that were set in documentViewer.DocumentHandlerParameters property
            ' The type for the generic Get<T> method should be the same as the set value's type.
            Dim connectionString = handlerParameters.Get(Of String)("connectionString")

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim sql = "SELECT FileName FROM FileTable WHERE FileId=" + fileId
                Using command As New SqlCommand(sql, connection)
                    Using reader = command.ExecuteReader()
                        If Not reader.Read() Then
                            Throw New Exception("File not found")
                        End If

                        ' read the file name from the selected row (first column in above query)
                        fileName = reader.GetString(0)
                    End Using
                End Using
            End Using

            ' uniqueId parameter (required):
            ' The unique identifier that will be used for generating the cache key for this document.
            ' For instance, it can be an ID from your database table or a simple file name; 
            ' you just need to make sure this ID varies for each different document so that they are cached correctly.
            ' For example for files on disk,
            ' we internally use a string combination of file extension, file size and file date for uniquely
            ' identifying them, this way cache collisions do not occur and we can resuse the cached file
            ' even if the file name before extension is changed (because it's still the same document).                

            ' fileName parameter (optional but recommended):
            ' The file name which will be used for display purposes such as when downloading the document
            ' within DocumentViewer> or for the subfolder name prefix in cache folder. 
            ' It will also be used to determine the document format from extension if format 
            ' parameter is not specified. If not specified or empty, uniqueId will be used 
            ' as the file name.                    
            Return New DocumentInfo(fileId, fileName)
        End Function

        ' Open a readable stream for the current input file.
        ' This is called only when necessary, i.e first time the document is loaded. For consecutive views
        ' as long as cached files are valid, it will not be called. This can be also called when "Download"
        ' button is clicked to download the original document.

        ' inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        ' the input file that was requested to be loaded in DocumentViewer
        '
        ' inputOptions parameter will be determined according to the input document format
        ' Usually you will not need to check this parameter as inputFile parameter should be sufficient
        ' for you to locate and open a corresponding stream.
        '
        ' Return a StreamResult instance initialized with a readable System.IO.Stream object.
        Public Function OpenRead(inputFile As String, inputOptions As InputOptions, handlerParameters As DocumentHandlerParameters) As StreamResult Implements IDocumentHandler.OpenRead
            Dim fileId = inputFile
            Dim fileBytes As Byte()

            ' Get your parameters that were set in documentViewer.DocumentHandlerParameters property
            ' The type for the generic Get<T> method should be the same as the set value's type.
            Dim connectionString = handlerParameters.Get(Of String)("connectionString")

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim sql = "SELECT FileBytes FROM FileTable WHERE FileId=" + fileId
                Using command As New SqlCommand(sql)
                    Using reader = command.ExecuteReader()
                        If Not reader.Read() Then
                            Throw New Exception("File not found")
                        End If

                        ' read the file data from the selected row (first column in above query)
                        fileBytes = CType(reader.GetValue(0), Byte())
                    End Using
                End Using
            End Using

            ' We need to return a stream that has the file contents here.
            ' As we don't have a stream but a byte array, we can wrap it with a MemoryStream.
            Dim stream As New MemoryStream(fileBytes)
            Return New StreamResult(stream)
        End Function
    End Class

End NameSpace