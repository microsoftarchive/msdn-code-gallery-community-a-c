# ASP.NET MVC5 - AngularJS, Create PDF file using Microsoft Report
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Entity Framework
- MVC
- WebAPI
- AngularJS
- ReportViewer
## Topics
- C#
- ASP.NET
- MVC
- WebAPI
- AngularJS
- ReportViewer
## Updated
- 11/18/2014
## Description

<p lang="en-US"><strong><span style="font-size:small">Introduction</span></strong></p>
<p><span>This article walks you through the steps for create a report in Word or PDF format using Microsoft Report without using Report Viewer.</span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">STEP 1 - Create ASP.NET Web Application</span></strong></p>
<p>Check the link below, to see all the steps to create a Web Api wtih Entity Framework code first implementation.</p>
<p><a href="http://social.technet.microsoft.com/wiki/contents/articles/26795.asp-net-webapi-entity-framework-code-first.aspx">http://social.technet.microsoft.com/wiki/contents/articles/26795.asp-net-webapi-entity-framework-code-first.aspx</a></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 2 - Install Microsoft Report Viewer Runtime into Machine</span></strong></p>
<p lang="en-US">To have the ability to create reports into your project, you will need to install the Runtime of Microsoft Report Viewer.</p>
<p lang="en-US">Follow the link below and download it according with your visual studio version:</p>
<p><a href="http://www.microsoft.com/en-us/download/details.aspx?id=35747">http://www.microsoft.com/en-us/download/details.aspx?id=35747</a></p>
<p><img id="129752" src="129752-1.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 3 - Create Report</span></strong></p>
<p>Add new item to our project of type Report.</p>
<p>For that on the left menu select Reporting option and then select Report item like on the image below.</p>
<p>Call it Contacts.rdlc.</p>
<p><img id="129753" src="129753-2.png" alt="" width="600" height="400"></p>
<p lang="en-US">Create new datasource associated with our connection string defined on web.config.</p>
<p>Select next button.</p>
<p><img id="129754" src="129754-3.png" alt="" width="600" height="400"></p>
<p>On this demo we will use table Contacts defined on our database.</p>
<p><img id="129755" src="129755-4.png" alt="" width="600" height="400"></p>
<p>Rename the dataset to DataSetContacts, and press the OK option.</p>
<p><img id="129756" src="129756-5.png" alt="" width="600" height="400"></p>
<p>After the creation of dataset we need to design our report.</p>
<p>For that create a table with three columns like on the image below.</p>
<p>This will display the Name, Address and City of each contact existent on the database table.</p>
<p><img id="129758" src="129758-6.png" alt="" width="600" height="400"></p>
<p><strong><span style="font-size:small">STEP 4 - PDF Generate Class</span></strong></p>
<p>Create new controller called ReportControllers and had the GetPDFreport method:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
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
        // GET api/&lt;controller&gt;
        [HttpGet]
        public async Task&lt;HttpResponseMessage&gt; GetPDFReport()
        {
            string fileName = string.Concat(&quot;Contacts.pdf&quot;);
            string filePath = HttpContext.Current.Server.MapPath(&quot;~/Report/&quot; &#43; fileName);

            ContactController contact = new ContactController();
            List&lt;Contact&gt; contacList = contact.Get().ToList();

            await SampleEF6.Report.ReportGenerator.GeneratePDF(contacList, filePath);

            HttpResponseMessage result = null;
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue(&quot;attachment&quot;);
            result.Content.Headers.ContentDisposition.FileName = fileName;

            return result;
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity.Infrastructure;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net.Http;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Http;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SampleEF6.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net.Http.Headers;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SampleEF6.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ReportController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET&nbsp;api/&lt;controller&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;HttpResponseMessage&gt;&nbsp;GetPDFReport()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;fileName&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Concat(<span class="cs__string">&quot;Contacts.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;filePath&nbsp;=&nbsp;HttpContext.Current.Server.MapPath(<span class="cs__string">&quot;~/Report/&quot;</span>&nbsp;&#43;&nbsp;fileName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactController&nbsp;contact&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactController();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Contact&gt;&nbsp;contacList&nbsp;=&nbsp;contact.Get().ToList();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;SampleEF6.Report.ReportGenerator.GeneratePDF(contacList,&nbsp;filePath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;Request.CreateResponse(HttpStatusCode.OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.Content&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamContent(<span class="cs__keyword">new</span>&nbsp;FileStream(filePath,&nbsp;FileMode.Open));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.Content.Headers.ContentDisposition&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContentDispositionHeaderValue(<span class="cs__string">&quot;attachment&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.Content.Headers.ContentDisposition.FileName&nbsp;=&nbsp;fileName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Create the GeneratePDF method like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Microsoft.Reporting.WebForms;
using SampleEF6.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace SampleEF6.Report
{
    public class ReportGenerator
    {
        public static string Report = &quot;SampleEF6.Report.Contacts.rdlc&quot;;

        public static Task GeneratePDF(List&lt;Contact&gt; datasource, string filePath)
        {
            return Task.Run(() =&gt;
            {
                string binPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, &quot;bin&quot;);
                var assembly = Assembly.Load(System.IO.File.ReadAllBytes(binPath &#43; &quot;\\SampleEF6.dll&quot;));

                using (Stream stream = assembly.GetManifestResourceStream(Report))
                {
                    var viewer = new ReportViewer();
                    viewer.LocalReport.EnableExternalImages = true;
                    viewer.LocalReport.LoadReportDefinition(stream);

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string filenameExtension;

                    viewer.LocalReport.DataSources.Add(new ReportDataSource(&quot;DataSetContacts&quot;, datasource));

                    viewer.LocalReport.Refresh();

                    byte[] bytes = viewer.LocalReport.Render(
                        &quot;PDF&quot;, null, out mimeType, out encoding, out filenameExtension,
                        out streamids, out warnings);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            });
        }
    }
}</pre>
<div class="preview">
<pre class="js">using&nbsp;Microsoft.Reporting.WebForms;&nbsp;
using&nbsp;SampleEF6.Models;&nbsp;
using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.IO;&nbsp;
using&nbsp;System.Linq;&nbsp;
using&nbsp;System.Reflection;&nbsp;
using&nbsp;System.Threading.Tasks;&nbsp;
using&nbsp;System.Web;&nbsp;
&nbsp;
namespace&nbsp;SampleEF6.Report&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ReportGenerator&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;string&nbsp;Report&nbsp;=&nbsp;<span class="js__string">&quot;SampleEF6.Report.Contacts.rdlc&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;Task&nbsp;GeneratePDF(List&lt;Contact&gt;&nbsp;datasource,&nbsp;string&nbsp;filePath)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Task.Run(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;binPath&nbsp;=&nbsp;System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,&nbsp;<span class="js__string">&quot;bin&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;assembly&nbsp;=&nbsp;Assembly.Load(System.IO.File.ReadAllBytes(binPath&nbsp;&#43;&nbsp;<span class="js__string">&quot;\\SampleEF6.dll&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(Stream&nbsp;stream&nbsp;=&nbsp;assembly.GetManifestResourceStream(Report))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;viewer&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ReportViewer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;viewer.LocalReport.EnableExternalImages&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;viewer.LocalReport.LoadReportDefinition(stream);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Warning[]&nbsp;warnings;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string[]&nbsp;streamids;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;mimeType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;encoding;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;filenameExtension;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;viewer.LocalReport.DataSources.Add(<span class="js__operator">new</span>&nbsp;ReportDataSource(<span class="js__string">&quot;DataSetContacts&quot;</span>,&nbsp;datasource));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;viewer.LocalReport.Refresh();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;byte[]&nbsp;bytes&nbsp;=&nbsp;viewer.LocalReport.Render(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;PDF&quot;</span>,&nbsp;null,&nbsp;out&nbsp;mimeType,&nbsp;out&nbsp;encoding,&nbsp;out&nbsp;filenameExtension,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;out&nbsp;streamids,&nbsp;out&nbsp;warnings);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(FileStream&nbsp;fs&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FileStream(filePath,&nbsp;FileMode.Create))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fs.Write(bytes,&nbsp;<span class="js__num">0</span>,&nbsp;bytes.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 5 - Run Application</span></strong></p>
<p><img id="129759" src="129759-7.png" alt="" width="600" height="400"></p>
<p><span style="font-size:small"><strong>Resources</strong></span></p>
<p lang="en-US"><strong>Some good resources about Windows Azure could be found here:</strong></p>
<ul type="disc">
<li lang="en-US"><span>My personal blog:&nbsp;</span><a href="http://joaoeduardosousa.wordpress.com/"><span>http://joaoeduardosousa.wordpress.com/ &nbsp; &nbsp; &nbsp;</span></a>
</li></ul>
