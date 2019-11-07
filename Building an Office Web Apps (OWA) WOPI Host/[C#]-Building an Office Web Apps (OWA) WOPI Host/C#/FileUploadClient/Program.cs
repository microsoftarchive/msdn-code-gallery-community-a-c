using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileUploadClient
{
    class Program
    {
        static string s_url =  "http://localhost:55574/api/upload";
        static void Main(string[] args)
        {
            //Test1();
            Test();
        }



        static void Test()
        {

            HttpClient httpClient = new HttpClient();

            using (var filestream1 = File.OpenRead("test.docx"))
            using (var filestream2 = File.OpenRead("test2.txt")) 
            using (var content = new MultipartFormDataContent())
            {
                content.Add(CreateFileContent(filestream1, "test.docx", "application/octet-stream"));
                content.Add(CreateFileContent(filestream2, "test2.txt", "application/octet-stream"));

                var response = httpClient.PostAsync(s_url, content).Result;

                response.EnsureSuccessStatusCode();

                var txtResponse = response.Content.ReadAsStringAsync().Result;

                var obj = JsonConvert.DeserializeObject<FileResult[]>(txtResponse);

            }
        }

        static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"files\"",
                FileName = "\"" + fileName + "\""
            }; // the extra quotes are key here
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return fileContent;
        }


        //private static void Test1()
        //{
        //    Uri webService = new Uri(s_url);
        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, webService);
        //    requestMessage.Headers.ExpectContinue = false;

        //    MultipartFormDataContent multiPartContent = new MultipartFormDataContent("----MyGreatBoundary");
        //    ByteArrayContent byteArrayContent = new ByteArrayContent(ReadFile("test.txt"));
        //    byteArrayContent.Headers.Add("Content-Type", "application/octet-stream");
        //    multiPartContent.Add(byteArrayContent, "this is the name of the content", "test.txt");
        //    requestMessage.Content = multiPartContent;

        //    HttpClient httpClient = new HttpClient();

        //    Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        //    HttpResponseMessage httpResponse = httpRequest.Result;

        //    Console.ReadLine();
        //}

        //static byte[] ReadFile(string fileName)
        //{
        //    var rv = File.ReadAllBytes("test.txt");
        //    return rv;
        //}
    }

    public class FileResult
    {
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
