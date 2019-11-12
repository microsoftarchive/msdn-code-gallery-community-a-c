using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleEF6.Models;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net.Http.Headers;

namespace SampleEF6.Controllers
{
    public class ReportController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public async Task<HttpResponseMessage> GetXLSReport()
        {
            string fileName = string.Concat("Contacts.xls");
            string filePath = HttpContext.Current.Server.MapPath("~/Report/" + fileName);

            ContactController contact = new ContactController();
            List<Contact> contacList = contact.Get().ToList();

            await SampleEF6.Report.ReportGenerator.GenerateXLS(contacList, filePath);

            HttpResponseMessage result = null;
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = fileName;

            return result;
        }
    }
}