using MainWeb.Helpers;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Http;

namespace WopHost.Controllers.Api
{
    public class UploadController : ApiController
    {
        const string s_storagePath = "~/App_Data";

        string _rootStoragePath;


        /// <summary>
        /// Provides multiple file upload from an HTTP client
        /// </summary>
        /// <returns>array of files uploaded and links on OWA</returns>
        public async Task<List<Link>> PostFile()
        {
            // Check if the request contains multipart/form-data. 
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            _rootStoragePath = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(_rootStoragePath);

            try
            {
                StringBuilder sb = new StringBuilder(); // Holds the response body 

                // Read the form data and return an async task. 
                await Request.Content.ReadAsMultipartAsync(provider);

                var files = RenameFiles(provider);
                var rv = BuildLinks(files);

                foreach (var file in files)
                {
                    sb.Append(string.Format("Uploaded file: {0}\n", file));
                }

                return rv;
            }
            catch (Exception e)
            {
                throw new ApplicationException("failed to accept files", e);
            }
        }

        List<Link> BuildLinks(List<Link> files)
        {
            var xml = WebConfigurationManager.AppSettings["appDiscoveryXml"];
            var wopiServer = WebConfigurationManager.AppSettings["appWopiServer"]; 
            WopiAppHelper wopiHelper = new WopiAppHelper(HostingEnvironment.MapPath(xml));
            
            foreach (Link link in files)
            {
                try
                {
                    var tlink = wopiHelper.GetDocumentLink(wopiServer + link.FileName);
                    link.Url = tlink;
                }
                catch (ArgumentException ex)
                {
                    link.Url = "bad file ext: " + ex.Message;
                }
            }

            return files;
        }

        List<Link> RenameFiles(MultipartFormDataStreamProvider provider)
        {
            List<Link> rv = new List<Link>();
            foreach (MultipartFileData fileData in provider.FileData)
            {
                if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                {
                    throw new ApplicationException("invalid request format, must set content disposition header");
                }
                string fileName = fileData.Headers.ContentDisposition.FileName;
                if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                {
                    fileName = Path.GetFileName(fileName);
                }

                //fileName = fileName.Replace(" ", string.Empty);
                
                string targetFile = Path.Combine(_rootStoragePath, fileName);
                if (System.IO.File.Exists(targetFile))
                {
                   File.Delete(targetFile); 
                }

                File.Move(fileData.LocalFileName, targetFile);
                rv.Add(new Link { FileName = fileName });
            }

            return rv;
        }
    }
}
