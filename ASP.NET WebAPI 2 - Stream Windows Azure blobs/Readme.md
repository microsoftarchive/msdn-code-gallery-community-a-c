# ASP.NET WebAPI 2 - Stream Windows Azure blobs
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
- ASP.NET MVC 4
- ASP.NET Web API
- ASP.NET 4.5
- Windows Azure Storage Blobs
- ASP.NET MVC 5
- ASP.NET Web API 2
## Topics
- Microsoft Azure
- ASP.NET MVC
- Azure Blob Storage
- ASP.NET Web API
- ASP.NET MVC 5
## Updated
- 03/29/2014
## Description

<p lang="en-US">With this article, I will show all steps you need to complete to create an ASP.NET WebAPI 2 to upload and download your documents to an Windows Azure Storage.</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 1 - Install Windows Azure SDK for .NET</strong></span></p>
<p lang="en-US">This could be done through Microsoft Web Platform Installer</p>
<p lang="en-US">Select the option Add on item Windows Azure SDK for .NET (VS 2013) -2.2, and the component will be installed on your machine.</p>
<p>&nbsp;</p>
<p><img id="111368" src="111368-5187.publish1.png" alt="" width="550" height="374"></p>
<p>&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 2 - Create Azure Account</strong></span></p>
<p lang="en-US">You need to get a Windows Azure account. Everyone can open a Windows Azure account for free.</p>
<p lang="en-US">Check the link below for more information.</p>
<p lang="en-US"><a href="http://www.windowsazure.com/en-us/pricing/free-trial/">http://www.windowsazure.com/en-us/pricing/free-trial/&nbsp;</a></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 3 - Create Blob Storage on Windows Azure</strong></span></p>
<p lang="en-US">After get access to an Azure Account, we need to create a blob storage.</p>
<p lang="en-US">So for that we need to select the option New on the left bottom of our web page and then select the option Data Services -&gt; Storage -&gt; Quick Create and give a name to your storage.</p>
<p lang="en-US">On this case our blob storage will have the name &quot;blobstorages&quot;.</p>
<p lang="en-US">&nbsp;</p>
<p><img id="111370" src="111370-2.png" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p lang="en-US">After create the blob storage, we need to get the keys that will be used on Web API to access to storage.</p>
<p lang="en-US">For that, select the created storage and on the bottom of the page check the option Manage Access Keys.</p>
<p lang="en-US">This option, give us the name of our storage and the key.</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><img id="111372" src="111372-3.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US">Now that we have our storage and the credentials to connect, the next step will be the creation of a container, where we will put our documents.</p>
<p lang="en-US">Select the option Create Container and give a name to it (on this example, the container will be named &quot;documents&quot;).</p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><img id="111373" src="111373-4.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 4 - Create ASP.NET WebAPI 2 Application</span></strong></p>
<p lang="en-US">I will be using Visual Studio 2013 as my development environment. Our first step will be to create an ASP.NET Web Application project based on the&nbsp;Web&nbsp;API&nbsp;template.</p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2013 and create a new project of type ASP.NET Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called WebAPI.</span> </li></ul>
<p lang="en-US">&nbsp;</p>
<p lang="en-US"><img id="111377" src="111377-5.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option WebAPI.</span> </li><li>The solution will be created.&nbsp; </li></ul>
<p><img id="111383" src="111383-6.png" alt="" width="600" height="400"></p>
<ul type="disc">
<li><span>Set the connection string to connect to the Azure blobs. You can just add the following setting to your Web.config.</span>
</li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden"> &lt;connectionStrings&gt;
    &lt;add name=&quot;Azure&quot; connectionString=&quot;DefaultEndpointsProtocol=https;AccountName=blobstorages;AccountKey=&#43;wMZaUv/...&quot; /&gt;
  &lt;/connectionStrings&gt;</pre>
<div class="preview">
<pre class="xml">&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Azure&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;DefaultEndpointsProtocol=https;AccountName=blobstorages;AccountKey=&#43;wMZaUv/...&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/connectionStrings&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Now in order to interact with the Azure Blobs, you need to add the reference to the following assemblies:</p>
<ul type="disc">
<li><span>Microsoft.WindowsAzure.Storage</span> </li></ul>
<p>&nbsp;</p>
<p>For that we will install a Nuget Package named Windows Azure Storage, as I show on the next image.</p>
<p>So on the Visual Studio 2013, select the follow menu option:</p>
<p>Tools-&gt; Library Package manager -&gt; Manage NuGet Packages for Solution</p>
<p>Search for Windows Azure Storage and select the option Install.&nbsp;</p>
<p>&nbsp;</p>
<p><img id="111379" src="111379-7.png" alt="" width="600" height="400"></p>
<p lang="en-US">&nbsp;</p>
<p>This option, will install automatically the Nuget Package.</p>
<p>The next step will be, the creation of our controller.</p>
<p><span>ApiController implements an HTTP POST action handling the file upload. Note that the action returns&nbsp;</span><span>Task&lt;T&gt;</span><span>&nbsp;as we read the file asynchronously.</span></p>
<p>The first thing we do is check that the content is indeed &quot;multipart/form-data&quot;. The second thing we do is creating a MultipartFormDataStreamProvider which gives you control over where the content ends up. In this case we save the file in the folder &quot;App_Data&quot;.
 It also contains information about the files stored.</p>
<p><span>If you want complete control over how the file is written and what file name is used then you can derive from MultipartFormDataStreamProvider, override the functionality you want and use that StreamProvider instead.</span></p>
<p><span>Once the read operation has completed we check the at is done we read the content asynchronously and when that task has completed we generate a response.</span></p>
<p>&nbsp;</p>
<p><span><img id="111380" src="111380-8.png" alt="" width="600" height="400"></span></p>
<p>Now, let&rsquo;s create the Web API actions. Below, I&rsquo;ve created a simple DocumentController that will support the following actions:</p>
<ul type="disc">
<li><span>POST: Will upload files, this will only support&nbsp;multipart/form-data&nbsp;format</span>
</li><li><span>GET: Will list the files that have been uploaded</span> </li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public async Task&lt;HttpResponseMessage&gt; Post()
        {
            var context = new StorageContext();

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            // Get and create the container
            var blobContainer = context.BlobClient.GetContainerReference(CONTAINER);
            blobContainer.CreateIfNotExists();

            string root = HttpContext.Current.Server.MapPath(&quot;~/App_Data&quot;);
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names for uploaded files.
                foreach (var fileData in provider.FileData)
                {
                    var filename = fileData.LocalFileName;
                    var blob = blobContainer.GetBlockBlobReference(filename);

                    using (var filestream = File.OpenRead(fileData.LocalFileName))
                    {
                        blob.UploadFromStream(filestream);
                    }
                    File.Delete(fileData.LocalFileName);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;HttpResponseMessage&gt;&nbsp;Post()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StorageContext();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Check&nbsp;if&nbsp;the&nbsp;request&nbsp;contains&nbsp;multipart/form-data.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!Request.Content.IsMimeMultipartContent())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseException(HttpStatusCode.UnsupportedMediaType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;and&nbsp;create&nbsp;the&nbsp;container</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;blobContainer&nbsp;=&nbsp;context.BlobClient.GetContainerReference(CONTAINER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blobContainer.CreateIfNotExists();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;root&nbsp;=&nbsp;HttpContext.Current.Server.MapPath(<span class="cs__string">&quot;~/App_Data&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;provider&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MultipartFormDataStreamProvider(root);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Read&nbsp;the&nbsp;form&nbsp;data&nbsp;and&nbsp;return&nbsp;an&nbsp;async&nbsp;task.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Request.Content.ReadAsMultipartAsync(provider);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;illustrates&nbsp;how&nbsp;to&nbsp;get&nbsp;the&nbsp;file&nbsp;names&nbsp;for&nbsp;uploaded&nbsp;files.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;fileData&nbsp;<span class="cs__keyword">in</span>&nbsp;provider.FileData)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;filename&nbsp;=&nbsp;fileData.LocalFileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;blob&nbsp;=&nbsp;blobContainer.GetBlockBlobReference(filename);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;filestream&nbsp;=&nbsp;File.OpenRead(fileData.LocalFileName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blob.UploadFromStream(filestream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File.Delete(fileData.LocalFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Request.CreateResponse(HttpStatusCode.OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(System.Exception&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Request.CreateErrorResponse(HttpStatusCode.InternalServerError,&nbsp;e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public async Task&lt;HttpResponseMessage&gt; Get(string id)
        {
            var context = new StorageContext();

            // Get and create the container
            var blobContainer = context.BlobClient.GetContainerReference(CONTAINER);
            blobContainer.CreateIfNotExists();

            var blob = blobContainer.GetBlockBlobReference(id);

            var blobExists = await blob.ExistsAsync();
            if (!blobExists)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, &quot;File not found&quot;);
            }

            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            Stream blobStream = await blob.OpenReadAsync();

            message.Content = new StreamContent(blobStream);
            message.Content.Headers.ContentLength = blob.Properties.Length;
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(blob.Properties.ContentType);
            message.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue(&quot;attachment&quot;)
            {
                FileName = blob.Name,
                Size = blob.Properties.Length
            };

            return message;
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;HttpResponseMessage&gt;&nbsp;Get(<span class="cs__keyword">string</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StorageContext();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;and&nbsp;create&nbsp;the&nbsp;container</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;blobContainer&nbsp;=&nbsp;context.BlobClient.GetContainerReference(CONTAINER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blobContainer.CreateIfNotExists();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;blob&nbsp;=&nbsp;blobContainer.GetBlockBlobReference(id);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;blobExists&nbsp;=&nbsp;await&nbsp;blob.ExistsAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!blobExists)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Request.CreateErrorResponse(HttpStatusCode.NotFound,&nbsp;<span class="cs__string">&quot;File&nbsp;not&nbsp;found&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;message&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessage(HttpStatusCode.OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;blobStream&nbsp;=&nbsp;await&nbsp;blob.OpenReadAsync();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Content&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamContent(blobStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Content.Headers.ContentLength&nbsp;=&nbsp;blob.Properties.Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Content.Headers.ContentType&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Net.Http.Headers.MediaTypeHeaderValue(blob.Properties.ContentType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Content.Headers.ContentDisposition&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Net.Http.Headers.ContentDispositionHeaderValue(<span class="cs__string">&quot;attachment&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileName&nbsp;=&nbsp;blob.Name,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;blob.Properties.Length&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Running the Web application, this will be our result. On the API menu, exists an help page, with all the actions implemented.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="111381" src="111381-9.png" alt="" width="600" height="400"></p>
<p lang="en-US"><strong><span style="font-size:small">STEP 5 - Test with a client</span></strong></p>
<p>HttpClient is an extensible API for accessing any services or web sites exposed over HTTP.</p>
<p>The HttpClient API was introduced as part of the WCF Web API but is now available as part of ASP.NET Web API in.NET Framework 4.5. You can use HttpClient to access Web API methods from a code-behind file and from services such as WCF.</p>
<p>The code snippet shown creates an HttpClient object and uses it for asynchronous access to sample API methods. Refer the code comments to understand the code snippet.</p>
<p>First we need to add a&nbsp;Nuget&nbsp;package named System.Net.HTTP that contains the required classes&nbsp;</p>
<p>With that in place we can start using the HttpClient instead.&nbsp;</p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">Windows Azure Resources</span></strong></p>
<p lang="en-US">Some good resources about Windows Azure could be found here:</p>
<ul type="disc">
<li lang="en-US"><span><a href="https://www.windowsazure.com/en-us/">Windows Azure Portal</a></span>
</li></ul>
<ul type="disc">
<li lang="en-US"><span>My personal blog:&nbsp;</span><span><a href="http://joaoeduardosousa.wordpress.com/">http://joaoeduardosousa.wordpress.com/</a></span>
</li></ul>
<p><span><br>
</span></p>
<p lang="en-US">&nbsp;</p>
