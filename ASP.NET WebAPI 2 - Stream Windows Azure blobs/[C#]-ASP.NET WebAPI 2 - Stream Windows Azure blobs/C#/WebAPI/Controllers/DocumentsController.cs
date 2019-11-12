using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DocumentsController : ApiController
    {
        private const string CONTAINER = "documents";

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post()
        {
            var context = new StorageContext();

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            // Get and create the container
            var blobContainer = context.BlobClient.GetContainerReference(CONTAINER);
            blobContainer.CreateIfNotExists();

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names for uploaded files.
                foreach (var fileData in provider.FileData)
                {
                    var filename = fileData.LocalFileName;
                    var blob = blobContainer.GetBlockBlobReference(filename);

                    using (var filestream = File.OpenRead(fileData.LocalFileName))
                    {
                        blob.UploadFromStream(filestream);
                    }
                    File.Delete(fileData.LocalFileName);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        // GET api/<controller>/{id}
        public async Task<HttpResponseMessage> Get(string id)
        {
            var context = new StorageContext();

            // Get and create the container
            var blobContainer = context.BlobClient.GetContainerReference(CONTAINER);
            blobContainer.CreateIfNotExists();

            var blob = blobContainer.GetBlockBlobReference(id);

            var blobExists = await blob.ExistsAsync();
            if (!blobExists)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "File not found");
            }

            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            Stream blobStream = await blob.OpenReadAsync();

            message.Content = new StreamContent(blobStream);
            message.Content.Headers.ContentLength = blob.Properties.Length;
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(blob.Properties.ContentType);
            message.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = blob.Name,
                Size = blob.Properties.Length
            };

            return message;
        }
    }
}