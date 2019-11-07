# ASP.NET Web API: Sending Form-Url-Encoded Data
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
## Topics
- ASP.NET Web API
## Updated
- 09/21/2012
## Description

<p>Sample code for the tutorial at <a href="http://www.asp.net/web-api/overview/working-with-http/sending-html-form-data,-part-1">
http://www.asp.net/web-api/overview/working-with-http/sending-html-form-data,-part-1</a></p>
<p>&nbsp;<strong>[Excerpt]</strong></p>
<h2>Part 1: Form-urlencoded Data</h2>
<p>This article shows how to post form-urlencoded data to a Web API controller.</p>
<ul>
<li><a href="#overview_of_html_forms">Overview of HTML Forms</a> </li><li><a href="#sending_complex_types">Sending Complex Types</a> </li><li><a href="#sending_form_data_via_ajax">Sending Form Data via AJAX</a> </li><li><a href="#sending_simple_types">Sending Simple Types</a> </li></ul>
<h2 id="overview_of_html_forms">Overview of HTML Forms</h2>
<p>Forms use either GET or POST to send data to the server. The <strong>method</strong> attribute of the
<strong>form</strong> element gives the HTTP method:</p>
<pre class="prettyprint">&lt;form action=&quot;api/values&quot; method=&quot;get&quot;&gt;</pre>
<p>The default method is GET. Using GET, the form data is encoded in the URI as a query string. Using POST, the form data is placed in the request body, and the
<strong>enctype</strong> attribute specifies the format.</p>
<ul>
<li><strong>&nbsp;application/x-www-form-urlencoded</strong>: Form data is encoded as name/value pairs, similar to a URI query string. This is the default format for POST.
</li><li><strong>multipart/form-data</strong>: Form data is encoded as a multipart MIME message. Use this format if you are uploading a file to the server.
</li></ul>
<p>This article looks at POST with application/x-www-form-urlencoded encoding.</p>
<p>&nbsp;</p>
<h2 id="sending_complex_types">Sending Complex Types</h2>
<p>Typically, you will send a complex type, composed of values from several form controls. Consider the following model:</p>
<pre class="prettyprint">namespace FormEncode.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Update
    {
        [Required]
        [MaxLength(140)]
        public string Status { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}</pre>
<p>The <code>Update</code> class represents a status update. Here is a Web API controller that accepts an
<code>Update</code> object via POST.</p>
<pre class="prettyprint">namespace FormEncode.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using FormEncode.Models;

    public class UpdatesController : ApiController
    {
        static readonly Dictionary&lt;Guid, Update&gt; updates = new Dictionary&lt;Guid,Update&gt;();

        [HttpPost]
        [ActionName(&quot;Complex&quot;)]
        public HttpResponseMessage PostComplex(Update update)
        {
            if (ModelState.IsValid)
            {
                var id = Guid.NewGuid();
                updates[id] = update;
                return ResponseFromPost(update, id);
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
                var resp = Request.CreateResponse(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
        }

        // Create a 201 response for a POST action.
        private HttpResponseMessage ResponseFromPost(Update update, Guid id)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.Created);
            resp.Content = new StringContent(update.Status);
            resp.Headers.Location = 
                new Uri(Url.Link(&quot;DefaultApi&quot;, new { action = &quot;status&quot;, id = id }));
            return resp;
        }
    }
}</pre>
