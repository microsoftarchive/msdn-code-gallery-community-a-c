namespace FormEncode.Controllers
{
    using FormEncode.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;

    public class UpdatesController : ApiController
    {
        static readonly Dictionary<Guid, Update> updates = new Dictionary<Guid, Update>();

        [HttpPost]
        [ActionName("Complex")]
        public HttpResponseMessage PostComplex(Update update)
        {
            if (ModelState.IsValid && update != null)
            {
                update.Status = HttpUtility.HtmlEncode(update.Status);

                var id = Guid.NewGuid();
                updates[id] = update;

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(update.Status)
                };
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ActionName("Simple")]
        public HttpResponseMessage PostSimple([FromBody] string value)
        {
            if (value != null)
            {
                Update update = new Update()
                {
                    Status = HttpUtility.HtmlEncode(value),
                    Date = DateTime.UtcNow
                };

                var id = Guid.NewGuid();
                updates[id] = update;

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(update.Status)
                };
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        public Update Status(Guid id)
        {
            Update update;
            if (updates.TryGetValue(id, out update))
            {
                return update;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}
