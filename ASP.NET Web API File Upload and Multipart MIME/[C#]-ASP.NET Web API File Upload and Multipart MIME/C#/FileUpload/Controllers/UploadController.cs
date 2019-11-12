using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

public class UploadController : ApiController
{
    public async Task<HttpResponseMessage> PostFile()
    {
        // Check if the request contains multipart/form-data.
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }

        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);

        try
        {
            StringBuilder sb = new StringBuilder(); // Holds the response body

            // Read the form data and return an async task.
            await Request.Content.ReadAsMultipartAsync(provider);

            // This illustrates how to get the form data.
            foreach (var key in provider.FormData.AllKeys)
            {
                foreach (var val in provider.FormData.GetValues(key))
                {
                    sb.Append(string.Format("{0}: {1}\n", key, val));
                }
            }

            // This illustrates how to get the file names for uploaded files.
            foreach (var file in provider.FileData)
            {
                FileInfo fileInfo = new FileInfo(file.LocalFileName);
                sb.Append(string.Format("Uploaded file: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent(sb.ToString())
            };
        }
        catch (System.Exception e)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        }
    }

}