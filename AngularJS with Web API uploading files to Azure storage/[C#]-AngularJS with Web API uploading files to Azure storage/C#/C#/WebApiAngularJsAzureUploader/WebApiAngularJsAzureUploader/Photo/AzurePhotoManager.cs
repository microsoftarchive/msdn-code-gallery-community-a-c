using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebApiAngularJsAzureUploader.Models;

namespace WebApiAngularJsAzureUploader.Photo
{
    public class AzurePhotoManager : IPhotoManager
    {
        private CloudStorageAccount StorageAccount {get; set;}
        private string ContainerName { get; set; }
        
        public AzurePhotoManager(CloudStorageAccount storageAccount, string containerName)
        {
            this.StorageAccount = storageAccount;
            this.ContainerName = containerName;
        }        

        public async Task<IEnumerable<PhotoViewModel>> Get()
        {
            //note the browser will get the actual images directly from the container we are not passing actual files back just references
            CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer photoContainer = blobClient.GetContainerReference(this.ContainerName);

            if (! await photoContainer.ExistsAsync())
            {
                await photoContainer.CreateAsync(BlobContainerPublicAccessType.Blob, null, null);                
            }

            var photos = new List<PhotoViewModel>();
            var blobItems = photoContainer.ListBlobs();

            foreach (CloudBlockBlob blobItem in blobItems.Where(bi => bi.GetType() == typeof(CloudBlockBlob)))
            {
                await blobItem.FetchAttributesAsync();

                photos.Add(new PhotoViewModel
                {
                    Name = blobItem.Name,
                    Size = blobItem.Properties.Length / 1024,
                    Created = blobItem.Metadata["Created"] == null ? DateTime.Now : DateTime.Parse(blobItem.Metadata["Created"]),
                    Modified = ((DateTimeOffset)blobItem.Properties.LastModified).DateTime,
                    Url = blobItem.Uri.AbsoluteUri
                });                    
            }
     
            return photos;
        }

        public async Task<PhotoActionResult> Delete(string fileName)
        {
            CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer photoContainer = blobClient.GetContainerReference(this.ContainerName);

            try
            {
                var blob = await photoContainer.GetBlobReferenceFromServerAsync(fileName);
                await blob.DeleteAsync();

                return new PhotoActionResult { Successful = true, Message = fileName + "deleted successfully" };
            }
            catch(Exception ex)
            {
                return new PhotoActionResult { Successful = false, Message = "error deleting fileName " + ex.GetBaseException().Message };
            }
        }

        public async Task<IEnumerable<PhotoViewModel>> Add(HttpRequestMessage request)
        {
            CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer photoContainer = blobClient.GetContainerReference(this.ContainerName);

            var provider = new AzureBlobMultipartFormDataStreamProvider(photoContainer);

            await request.Content.ReadAsMultipartAsync(provider);

            var photos = new List<PhotoViewModel>();

            foreach (var file in provider.FileData)
            {
                //the LocalFileName is going to be the absolute Uri of the blob (see GetStream)
                //use it to get the blob info to return to the client
                var blob = await photoContainer.GetBlobReferenceFromServerAsync(file.LocalFileName);
                await blob.FetchAttributesAsync();

                photos.Add(new PhotoViewModel
                {
                    Name = blob.Name,
                    Size = blob.Properties.Length / 1024,
                    Created = blob.Metadata["Created"] == null ? DateTime.Now : DateTime.Parse(blob.Metadata["Created"]),
                    Modified = ((DateTimeOffset)blob.Properties.LastModified).DateTime,
                    Url = blob.Uri.AbsoluteUri
                });
            }

            return photos;      
        }

        public async Task<bool> FileExists(string fileName)
        {
            CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer photoContainer = blobClient.GetContainerReference(this.ContainerName);

            var blob = await photoContainer.GetBlobReferenceFromServerAsync(fileName);
            return await blob.ExistsAsync();
        }
    }
}