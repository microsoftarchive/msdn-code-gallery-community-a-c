using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate;
using GleamTech.DocumentUltimate.AspNet;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer
{
    public partial class StreamPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The document handler type which provides a custom way of loading the input files.
            // This class should implement IDocumentHandler interface and should have a parameterless
            // constructor so that it can be instantiated internally when necessary.
            // Value of Document property will be passed to this handler which should open 
            // and return a readable stream according to that file identifier.
            // See below for CustomDocumentHandler class which implements IDocumentHandler interface
            documentViewer.DocumentHandlerType = typeof(CustomDocumentHandler);

            // If a custom document handler is provided via DocumentHandlerType property, then
            // this value will be passed to that handler which should open and return a readable stream according 
            // to this file identifier. 
            // So it can be any string value that your IDocumentHandler implementation understands.
            documentViewer.Document = "~/App_Data/ExampleFiles/Default.docx";


            //---------------------------------------------
            // Here is an example (commented out) for loading a document from database.
            // See below for DbDocumentHandler class which implements IDocumentHandler interface.
            // This loads the document with passed ID (176) from the database
            /*
            documentViewer.DocumentHandlerType = typeof(DbDocumentHandler);
            documentViewer.Document = "176"; // a file path or identifier
            
            // When you need to pass custom parameters along with the input file to your handler implementation,
            // use documentViewer.DocumentHandlerParameters property to set your parameters.
            // These will be passed to the methods of your handler implementation:
            documentViewer.DocumentHandlerParameters.Set("connectionString", "SOME CONNECTION STRING");
            */
            //---------------------------------------------


            //---------------------------------------------
            //When you don't have a file on disk and implementing IDocumentHandler interface is not convenient, 
            //you can use documentViewer.DocumentSource property to load documents from a stream or a byte array. 
            //Note that your stream or byte array will be copied to the cache folder if not already exists 
            //when you load via DocumentSource because DocumentViewer needs to access your document 
            //out of the context of the host page (i.e. serialization is needed). 

            //Load document from a stream:
            /*
            documentViewer.DocumentSource = new DocumentSource(
                new DocumentInfo(uniqueId, fileName),
                new StreamResult(stream)
            );
            */

            //Load document from a byte array:
            /*
            documentViewer.DocumentSource = new DocumentSource(
                new DocumentInfo(uniqueId, fileName),
                byteArray
            );
            */
            //---------------------------------------------
        }
    }

    // Implement IDocumentHandler interface to provide a custom way of loading the input files.
    // You can instruct DocumentViewer to use this handler by setting DocumentViewer.DocumentHandlerType
    // property to type of this class, i.e. typeof(CustomDocumentHandler)
    // For the simplicity of this example, we are getting a stream from a file on disk.
    // Otherwise the stream can come from network or a database or even a zip file.
    public class CustomDocumentHandler : IDocumentHandler
    {
        // Get the document information required for the current input file.
        // This is called before loading the document for determining the cache key and document format.
        //
        // inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        // the input file that was requested to be loaded in DocumentViewer
        //
        // Return a DocumentInfo instance initialized with required information from this method.
        public DocumentInfo GetInfo(string inputFile, DocumentHandlerParameters handlerParameters)
        {
            var physicalPath = Hosting.ResolvePhysicalPath(inputFile);
            var fileInfo = new FileInfo(physicalPath);

            return new DocumentInfo(
                // uniqueId parameter (required):
                // The unique identifier that will be used for generating the cache key for this document.
                // For instance, it can be an ID from your database table or a simple file name; 
                // you just need to make sure this ID varies for each different document so that they are cached correctly.
                // For example for files on disk,
                // we internally use a string combination of file extension, file size and file date for uniquely
                // identifying them, this way cache collisions do not occur and we can resuse the cached file
                // even if the file name before extension is changed (because it's still the same document).
                string.Concat(
                    fileInfo.Extension.ToLowerInvariant(),
                    fileInfo.Length,
                    fileInfo.LastWriteTimeUtc.Ticks),

                // fileName parameter (optional but recommended):
                // The file name which will be used for display purposes such as when downloading the document
                // within DocumentViewer> or for the subfolder name prefix in cache folder. 
                // It will also be used to determine the document format from extension if format 
                // parameter is not specified. If not specified or empty, uniqueId will be used 
                // as the file name.
                fileInfo.Name
            );
        }

        // Open a readable stream for the current input file.
        //
        // inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        // the input file that was requested to be loaded in DocumentViewer
        //
        // inputOptions parameter will be determined according to the input document format
        // Usually you will not need to check this parameter as inputFile parameter should be sufficient
        // for you to locate and open a corresponding stream.
        //
        // Return a StreamResult instance initialized with a readable System.IO.Stream object.
        public StreamResult OpenRead(string inputFile, InputOptions inputOptions, DocumentHandlerParameters handlerParameters)
        {
            var physicalPath = Hosting.ResolvePhysicalPath(inputFile);
            var stream = File.OpenRead(physicalPath);

            return new StreamResult(stream);
        }
    }

    // This is a sample IDocumentHandler implementation for loading a document from database.
    // You can instruct DocumentViewer to use this handler by setting DocumentViewer.DocumentHandlerType
    // property to type of this class, i.e. typeof(DbDocumentHandler)
    // This sample demonstrates raw db access with System.Data objects
    // but you can use any type of db access (e.g. Entity Framework), the idea is same.
    public class DbDocumentHandler : IDocumentHandler
    {

        // Get the document information required for the current input file.
        // This is called for determining the cache key and document format whenever 
        // DocumentViewer requests a document.
        // 
        // inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        // the input file that was requested to be loaded in DocumentViewer
        // 
        // Return a DocumentInfo instance initialized with required information from this method.
        public DocumentInfo GetInfo(string inputFile, DocumentHandlerParameters handlerParameters)
        {
            var fileId = inputFile;
            string fileName;

            // Get your parameters that were set in documentViewer.DocumentHandlerParameters property
            // The type for the generic Get<T> method should be the same as the set value's type.
            var connectionString = handlerParameters.Get<string>("connectionString");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = "SELECT FileName FROM FileTable WHERE FileId=" + fileId;
                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("File not found");

                    // read the file name from the selected row (first column in above query)
                    fileName = reader.GetString(0);
                }
            }

            return new DocumentInfo(
                // uniqueId parameter (required):
                // The unique identifier that will be used for generating the cache key for this document.
                // For instance, it can be an ID from your database table or a simple file name; 
                // you just need to make sure this ID varies for each different document so that they are cached correctly.
                // For example for files on disk,
                // we internally use a string combination of file extension, file size and file date for uniquely
                // identifying them, this way cache collisions do not occur and we can resuse the cached file
                // even if the file name before extension is changed (because it's still the same document).                
                fileId,

                // fileName parameter (optional but recommended):
                // The file name which will be used for display purposes such as when downloading the document
                // within DocumentViewer> or for the subfolder name prefix in cache folder. 
                // It will also be used to determine the document format from extension if format 
                // parameter is not specified. If not specified or empty, uniqueId will be used 
                // as the file name.                    
                fileName
            );
        }

        // Open a readable stream for the current input file.
        // This is called only when necessary, i.e first time the document is loaded. For consecutive views
        // as long as cached files are valid, it will not be called. This can be also called when "Download"
        // button is clicked to download the original document.
        // 
        // inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        // the input file that was requested to be loaded in DocumentViewer
        // 
        // inputOptions parameter will be determined according to the input document format
        // Usually you will not need to check this parameter as inputFile parameter should be sufficient
        // for you to locate and open a corresponding stream.
        // 
        // Return a StreamResult instance initialized with a readable System.IO.Stream object.
        public StreamResult OpenRead(string inputFile, InputOptions inputOptions, DocumentHandlerParameters handlerParameters)
        {
            var fileId = inputFile;
            byte[] fileBytes;

            // Get your parameters that were set in documentViewer.DocumentHandlerParameters property
            // The type for the generic Get<T> method should be the same as the set value's type.
            var connectionString = handlerParameters.Get<string>("connectionString");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = "SELECT FileBytes FROM FileTable WHERE FileId=" + fileId;
                using (var command = new SqlCommand(sql))
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("File not found");

                    // read the file data from the selected row (first column in above query)
                    fileBytes = (byte[])reader.GetValue(0);
                }
            }

            // We need to return a stream that has the file contents here.
            // As we don't have a stream but a byte array, we can wrap it with a MemoryStream.
            var stream = new MemoryStream(fileBytes);
            return new StreamResult(stream);
        }
    }
}