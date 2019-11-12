Imports Microsoft.Azure
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Blob
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks

''' <summary>
''' Azure Storage Blob Sample - Demonstrate how to use the Blob Storage service. 
''' Blob storage stores unstructured data such as text, binary data, documents or media files. 
''' Blobs can be accessed from anywhere in the world via HTTP or HTTPS.
'''
''' Note: This sample uses the .NET 4.6 asynchronous programming model to demonstrate how to call the Storage Service using the 
''' storage client libraries asynchronous API's. When used in real applications this approach enables you to improve the 
''' responsiveness of your application. Calls to the storage service are prefixed by the await keyword. 
''' 
''' Documentation References: 
''' - What is a Storage Account - http://azure.microsoft.com/en-us/documentation/articles/storage-whatis-account/
''' - Getting Started with Blobs - http://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/
''' - Blob Service Concepts - http://msdn.microsoft.com/en-us/library/dd179376.aspx 
''' - Blob Service REST API - http://msdn.microsoft.com/en-us/library/dd135733.aspx
''' - Blob Service C# API - http://go.microsoft.com/fwlink/?LinkID=398944
''' - Delegating Access with Shared Access Signatures - http://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-shared-access-signature-part-1/
''' - Storage Emulator - http://msdn.microsoft.com/en-us/library/azure/hh403989.aspx
''' - Asynchronous Programming with Async and Await  - http://msdn.microsoft.com/en-us/library/hh191443.aspx
''' </summary>
Public Class Program
    ' *************************************************************************************************************************
    ' Instructions: This sample can be run using either the Azure Storage Emulator that installs as part of this SDK - or by
    ' updating the App.Config file with your AccountName and Key. 
    ' 
    ' To run the sample using the Storage Emulator (default option)
    '      1. Start the Azure Storage Emulator (once only) by pressing the Start button or the Windows key and searching for it
    '         by typing "Azure Storage Emulator". Select it from the list of applications to start it.
    '      2. Set breakpoints and run the project using F10. 
    ' 
    ' To run the sample using the Storage Service
    '      1. Open the app.config file and comment out the connection string for the emulator (UseDevelopmentStorage=True) and
    '         uncomment the connection string for the storage service (AccountName=[]...)
    '      2. Create a Storage Account through the Azure Portal and provide your [AccountName] and [AccountKey] in 
    '         the App.Config file. See http://go.microsoft.com/fwlink/?LinkId=325277 for more information
    '      3. Set breakpoints and run the project using F10. 
    ' 
    ' *************************************************************************************************************************
    Public Shared Sub Main(args As String())
        Console.WriteLine("Azure Storage Blob Sample" & vbLf & " ")

        ' Block blob basics
        Console.WriteLine("Block Blob Sample")
        BasicStorageBlockBlobOperationsAsync().Wait()

        ' Page blob basics
        Console.WriteLine(vbLf & "Page Blob Sample")
        BasicStoragePageBlobOperationsAsync().Wait()

        Console.WriteLine("Press any key to exit")
        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Basic operations to work with block blobs
    ''' </summary>
    ''' <returns>Task</returns>
    Private Shared Async Function BasicStorageBlockBlobOperationsAsync() As Task
        Const ImageToUpload As String = "HelloWorld.png"

        ' Retrieve storage account information from connection string
        ' How to create a storage connection string - http://msdn.microsoft.com/en-us/library/azure/ee758697.aspx
        Dim storageAccount As CloudStorageAccount = CreateStorageAccountFromConnectionString(CloudConfigurationManager.GetSetting("StorageConnectionString"))

        ' Create a blob client for interacting with the blob service.
        Dim blobClient As CloudBlobClient = storageAccount.CreateCloudBlobClient()

        ' Create a container for organizing blobs within the storage account.
        Console.WriteLine("1. Creating Container")
        Dim container As CloudBlobContainer = blobClient.GetContainerReference("democontainerblockblob")
        Try
            Await container.CreateIfNotExistsAsync()
        Catch generatedExceptionName As StorageException
            Console.WriteLine("If you are running with the default configuration please make sure you have started the storage emulator. Press the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.")
            Console.ReadLine()
            Throw
        End Try

        ' To view the uploaded blob in a browser, you have two options. The first option is to use a Shared Access Signature (SAS) token to delegate 
        ' access to the resource. See the documentation links at the top for more information on SAS. The second approach is to set permissions 
        ' to allow public access to blobs in this container. Uncomment the line below to use this approach. Then you can view the image 
        ' using: https://[InsertYourStorageAccountNameHere].blob.core.windows.net/democontainer/HelloWorld.png
        ' await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

        ' Upload a BlockBlob to the newly created container
        Console.WriteLine("2. Uploading BlockBlob")
        Dim blockBlob As CloudBlockBlob = container.GetBlockBlobReference(ImageToUpload)
        Await blockBlob.UploadFromFileAsync(ImageToUpload, FileMode.Open)

        ' List all the blobs in the container 
        Console.WriteLine("3. List Blobs in Container")
        For Each blob As IListBlobItem In container.ListBlobs()
            ' Blob type will be CloudBlockBlob, CloudPageBlob or CloudBlobDirectory
            ' Use blob.GetType() and cast to appropriate type to gain access to properties specific to each type
            Console.WriteLine("- {0} (type: {1})", blob.Uri, blob.[GetType]())
        Next

        ' Download a blob to your file system
        Console.WriteLine("4. Download Blob from {0}", blockBlob.Uri.AbsoluteUri)
        Await blockBlob.DownloadToFileAsync(String.Format("./CopyOf{0}", ImageToUpload), FileMode.Create)

        ' Clean up after the demo 
        Console.WriteLine("5. Delete block Blob")
        Await blockBlob.DeleteAsync()

        ' When you delete a container it could take several seconds before you can recreate a container with the same
        ' name - hence to enable you to run the demo in quick succession the container is not deleted. If you want 
        ' to delete the container uncomment the line of code below. 
        'Console.WriteLine("6. Delete Container");
        'await container.DeleteAsync();
    End Function

    ''' <summary>
    ''' Basic operations to work with page blobs
    ''' </summary>
    ''' <returns>Task</returns>
    Private Shared Async Function BasicStoragePageBlobOperationsAsync() As Task
        Const PageBlobName As String = "samplepageblob"

        ' Retrieve storage account information from connection string
        ' How to create a storage connection string - http://msdn.microsoft.com/en-us/library/azure/ee758697.aspx
        Dim storageAccount As CloudStorageAccount = CreateStorageAccountFromConnectionString(CloudConfigurationManager.GetSetting("StorageConnectionString"))

        ' Create a blob client for interacting with the blob service.
        Dim blobClient As CloudBlobClient = storageAccount.CreateCloudBlobClient()

        ' Create a container for organizing blobs within the storage account.
        Console.WriteLine("1. Creating Container")
        Dim container As CloudBlobContainer = blobClient.GetContainerReference("democontainerpageblob")
        Await container.CreateIfNotExistsAsync()

        ' Create a page blob in the newly created container.  
        Console.WriteLine("2. Creating Page Blob")
        Dim pageBlob As CloudPageBlob = container.GetPageBlobReference(PageBlobName)
        'size
        Await pageBlob.CreateAsync(512 * 2)
        ' size needs to be multiple of 512 bytes
        ' Write to a page blob 
        Console.WriteLine("2. Write to a Page Blob")
        Dim samplePagedata As Byte() = New Byte(511) {}
        Dim random As New Random()
        random.NextBytes(samplePagedata)
        Await pageBlob.UploadFromByteArrayAsync(samplePagedata, 0, samplePagedata.Length)

        ' List all blobs in this container. Because a container can contain a large number of blobs the results 
        ' are returned in segments (pages) with a maximum of 5000 blobs per segment. You can define a smaller size
        ' using the maxResults parameter on ListBlobsSegmentedAsync.
        Console.WriteLine("3. List Blobs in Container")
        Dim token As BlobContinuationToken = Nothing
        Do
            Dim resultSegment As BlobResultSegment = Await container.ListBlobsSegmentedAsync(token)
            token = resultSegment.ContinuationToken
            For Each blob As IListBlobItem In resultSegment.Results
                ' Blob type will be CloudBlockBlob, CloudPageBlob or CloudBlobDirectory
                Console.WriteLine("{0} (type: {1}", blob.Uri, blob.[GetType]())
            Next
        Loop While token IsNot Nothing

        ' Read from a page blob
        'Console.WriteLine("4. Read from a Page Blob");
        Dim bytesRead As Integer = Await pageBlob.DownloadRangeToByteArrayAsync(samplePagedata, 0, 0, samplePagedata.Count())

        ' Clean up after the demo 
        Console.WriteLine("5. Delete page Blob")
        Await pageBlob.DeleteAsync()

        ' When you delete a container it could take several seconds before you can recreate a container with the same
        ' name - hence to enable you to run the demo in quick succession the container is not deleted. If you want 
        ' to delete the container uncomment the line of code below. 
        'Console.WriteLine("6. Delete Container");
        'await container.DeleteAsync();
    End Function

    ''' <summary>
    ''' Validates the connection string information in app.config and throws an exception if it looks like 
    ''' the user hasn't updated this to valid values. 
    ''' </summary>
    ''' <param name="storageConnectionString">The storage connection string</param>
    ''' <returns>CloudStorageAccount object</returns>
    Private Shared Function CreateStorageAccountFromConnectionString(storageConnectionString As String) As CloudStorageAccount
        Dim storageAccount As CloudStorageAccount
        Try
            storageAccount = CloudStorageAccount.Parse(storageConnectionString)
        Catch generatedExceptionName As FormatException
            Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.")
            Console.ReadLine()
            Throw
        Catch generatedExceptionName As ArgumentException
            Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.")
            Console.ReadLine()
            Throw
        End Try

        Return storageAccount
    End Function

End Class
