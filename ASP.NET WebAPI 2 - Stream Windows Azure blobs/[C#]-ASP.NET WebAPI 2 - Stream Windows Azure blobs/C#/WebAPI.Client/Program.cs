using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; 
using System.Net.Http.Headers; 


namespace WebAPI.Client
{
    class Program
    {
        private static readonly Uri _address = new Uri("http://localhost:53798/");

        private static HttpClient _client = null;

        static void Main(string[] args)
        {
            using (var client = new HttpClient()) 
            using (var content = new MultipartFormDataContent()) 
            {
                InitializeSystem();

                UploadDocument();

                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();
            } 
        }

        private static void InitializeSystem()
        {
            _client = new HttpClient();
            _client.BaseAddress = _address;
        }

        //fileContent.Headers.ContentLocation = new Uri()

        private static void UploadDocument()
        {
            // Add test file 
            var httpContent = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes(@"C:\Program Files (x86)\DevScope\SmartDocumentor\Demos\Samples\Input\BCP00000001.tif"));
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "BCP00000001.tif"
            };

            httpContent.Add(fileContent);
            
            // Make a call to Web API 
            string requestEndpoint = "api/Post";

            var response = _client.PostAsync(requestEndpoint, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("UploadDocument Post with success.");                 
            }
            else
            {
                Console.WriteLine("UploadDocument Post with error.");
                Console.WriteLine(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.ReasonPhrase));
            }
        }
    }
}
