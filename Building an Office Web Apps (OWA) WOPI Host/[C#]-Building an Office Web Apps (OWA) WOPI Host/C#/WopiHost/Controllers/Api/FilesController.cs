using MainWeb.Helpers;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Http;

namespace WopiHost.Controllers
{
    /// <summary>
    /// File controller
    /// </summary>
    [RoutePrefix("api/wopi")]
    public class FilesController : ApiController
    {
        IFileHelper _fileHelper;
        IKeyGen _keyGen;
        /// <summary>
        /// Base constructor
        /// </summary>
        public FilesController()
            : this(new FileHelper(), new KeyGen())
        {
        }

        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="fileHelper">File helper implementation</param>
        /// <param name="keyGen">KeyGen helper implementation</param>
        public FilesController(IFileHelper fileHelper, IKeyGen keyGen)
        {
            _fileHelper = fileHelper;
            _keyGen = keyGen;

        }

        /// <summary>
        /// Returns the metadata about an office document
        /// </summary>
        /// <param name="name">filename</param>
        /// <param name="access_token">access token generated for this server</param>
        /// <returns></returns>
        [Route("files/{name}/")]
        public CheckFileInfo GetFileInfo(string name, string access_token)
        {
            Validate(name, access_token);

            var fileInfo = _fileHelper.GetFileInfo(name);

            bool updateEnabled = false;
            if (bool.TryParse(WebConfigurationManager.AppSettings["updateEnabled"].ToString(), out updateEnabled))
            {
                fileInfo.SupportsUpdate = updateEnabled;
                fileInfo.UserCanWrite = updateEnabled;
                fileInfo.SupportsLocks = updateEnabled;
            }

            return fileInfo;
        }

        // GET api/<controller>/5
        /// <summary>
        /// Get a single file contents
        /// </summary>
        /// <param name="name">filename</param>
        /// <returns>a file stream</returns>
        [Route("files/{name}/contents")]
        public HttpResponseMessage Get(string name, string access_token)
        {
            try
            {
                Validate(name, access_token);
                var file = HostingEnvironment.MapPath("~/App_Data/" + name);
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(file, FileMode.Open, FileAccess.Read);

                responseMessage.Content = new StreamContent(stream);
                responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return responseMessage;

            }
            catch (Exception ex)
            {
                var errorResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                var stream = new MemoryStream(UTF8Encoding.Default.GetBytes(ex.Message ?? ""));
                errorResponseMessage.Content = new StreamContent(stream);
                return errorResponseMessage;
            }

        }


        // POST api/<controller>


        /// <summary>
        /// Not implemented, but will provide editing (simple)
        /// </summary>
        /// <param name="access_token"></param>
        [Route("files/{name}/contents")]
        public async void Post(string name, [FromUri] string access_token)
        {
            var body = await Request.Content.ReadAsByteArrayAsync();

            var appData = HostingEnvironment.MapPath("~/App_Data/");
            var fileExt = name.Substring(name.LastIndexOf('.') + 1);

            var outFile = Path.Combine(
                appData,name);
                //Guid.NewGuid().ToString() +
                //"_" +
                //name);

            //var fi = new FileInfo(outFile);

            File.WriteAllBytes(outFile, body);

        }

        // Action saves the request’s content into an Azure blob 
        public Task PostUploadfile(string destinationBlobName)
        {
            // string should come from URL, we’ll read content body ourselves.
            Stream azureStream = File.Open("", FileMode.OpenOrCreate); ;// OpenAzureStorage(destinationBlobName); // stream to write to azure
            return this.Request.Content.CopyToAsync(azureStream); // upload body contents to azure. 
        }

        void Validate(string name, string access_token)
        {
            //var decoded = access_token);
            var isValid = _keyGen.Validate(name, access_token);
            if (!isValid)
                throw new SecurityException("Access token doesn't match calculated token");
        }

    }
}