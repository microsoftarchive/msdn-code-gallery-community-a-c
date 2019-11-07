using System;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http;
using System.Net.Http.Formatting;

namespace CloudLoadTestingClient
{
    public class CltHttpClientWrapper
    {
        public async static Task<T> Get<T>(string url)
        {
            try
            {
                using (var client = GetELSClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(GetElsUrl(url)).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default(T);
            }
        }
        public async static Task<T> Post<T>(string url, HttpContent httpContent)
        {
            using (var client = GetELSClient())
            {
                using (HttpResponseMessage response = client.PostAsync(GetElsUrl(url), httpContent).Result)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ValidateHttpStatusCode(response, responseBody);
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
            }
        }

        public async static Task Patch(string url, HttpContent httpContent)
        {
            try
            {
                using (var client = GetELSClient())
                {
                    using (HttpResponseMessage response = client.PatchAsync(GetElsUrl(url), httpContent).Result)
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static Uri GetElsUrl(string relativePath)
        {
            if (!relativePath.Contains("?"))
                return
                    new Uri(string.Concat(ConfigurationManager.AppSettings["ElsOnlineAccountUrl"], relativePath,
                        ApiVersion));
            else
            {
                var appendedApiVersion = ApiVersion.Replace("?", "&");
                return
                    new Uri(string.Concat(ConfigurationManager.AppSettings["ElsOnlineAccountUrl"], relativePath,
                        appendedApiVersion));
            }
        }
        private static HttpClient GetELSClient()
        {
            var vsoAccountpersonalAccessToken = ConfigurationManager.AppSettings["VSOnlineAccountPersonalAccessToken"];
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("user-agent", "API-Sample-Revision-1");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format(CultureInfo.InvariantCulture, " :{0}",  vsoAccountpersonalAccessToken))));
            return client;
        }

        private static void ValidateHttpStatusCode(HttpResponseMessage response, string responseBody)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (!string.IsNullOrWhiteSpace(responseBody))
                {
                    var error = JsonConvert.DeserializeObject<HttpError>(responseBody);
                    throw new Exception(error.Message);
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        private const String ApiVersion = "?api-version=1.0";
    }
}
