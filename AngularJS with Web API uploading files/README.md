# AngularJS with Web API: uploading files
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Javascript
- HTML5
- AngularJS
- ASP.NET Web API 2
## Topics
- ASP.NET
- Javascript
- HTML5
- ASP.NET Web API
- AngularJS
- file upload
## Updated
- 04/06/2015
## Description

<h2>Introduction</h2>
<p>This sample demonstrates how to create a file manager with AngularJS and Web API. It consists of an AngularJS single page application which allows a user to browse and delete images files from the server (IIS or IIS Express) and upload new files as well.
 It also shows how to create a Web API controller to support the required server side operations.</p>
<p>If you are gong to be deploying to Azure then please also have look at the companion sample
<a href="https://code.msdn.microsoft.com/AngularJS-with-Web-API-c05b3511" target="_blank">
here</a> which covers uploading to an Azure Container.</p>
<p><img id="128420" src="128420-screenshot.png" alt="" width="600" height="400"></p>
<p>Please note that all code snippets in this description are partial and only contain the relevant lines of code. To view the full code please download the sample. Also the approach taken in this sample has been to make the code as clear as possible to highlight
 the overall concept. In a real world scenario another design may preferable.</p>
<h2><span>Building the Sample</span></h2>
<p>This sample has the solution level NuGet packages removed to make it smaller for downloading. If you do not have NuGet Package Restore enabled run NuGet and it should prompt you to restore the missing packages.</p>
<h2>Description</h2>
<p>The sample is a Visual Studio Web API project with no Authentication. A couple of configuration changes have been made to the default settings. In
<strong>BundleConfig</strong> the line <strong>BundleTable.EnableOptimizations = true;</strong> has been commented out. This will stop the SPA scripts (bundled as app) from being bundled and minified, making it easier to step through the client code when it
 is running in browser. Also in <strong>WebApiConfig</strong> the JSON formatting has been set to camelcase.</p>
<p>The main elements of the solution are as follows.</p>
<h3>Web Api</h3>
<p>The <strong>PhotoController</strong>&nbsp;defines the actions to get information about uploaded photos (not the actual files themselves), add new ones and delete existing files.&nbsp;<span>It's worth noting at this point that an existing file will be overwritten
 if a new file with the same file name is uploaded.</span></p>
<p>The controller uses&nbsp;<span><strong>Local</strong></span><strong>PhotoManager
</strong>to provide all required file IO functionality. Of particular interest is the Add method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;IEnumerable&lt;PhotoViewModel&gt;&gt;&nbsp;Add(HttpRequestMessage&nbsp;request)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;provider&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PhotoMultipartFormDataStreamProvider(<span class="cs__keyword">this</span>.workingFolder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;request.Content.ReadAsMultipartAsync(provider);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;photos&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;PhotoViewModel&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>(var&nbsp;file&nbsp;<span class="cs__keyword">in</span>&nbsp;provider.FileData)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fileInfo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileInfo(file.LocalFileName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;photos.Add(<span class="cs__keyword">new</span>&nbsp;PhotoViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;fileInfo.Name,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Created&nbsp;=&nbsp;fileInfo.CreationTime,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Modified&nbsp;=&nbsp;fileInfo.LastWriteTime,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;fileInfo.Length&nbsp;/<span class="cs__number">1024</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;photos;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span>It creates an instance of the&nbsp;</span><strong>PhotoMultipartFormDataStreamProvider</strong>,&nbsp;derived&nbsp;from&nbsp;<strong>MultipartFormDataStreamProvider</strong> to save the files with their original names the derived class rather using
 computed names.</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PhotoMultipartFormDataStreamProvider&nbsp;:&nbsp;MultipartFormDataStreamProvider&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;PhotoMultipartFormDataStreamProvider(<span class="cs__keyword">string</span>&nbsp;path)&nbsp;:&nbsp;<span class="cs__keyword">base</span>(path)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders&nbsp;headers)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Make&nbsp;the&nbsp;file&nbsp;name&nbsp;URL&nbsp;safe&nbsp;and&nbsp;then&nbsp;use&nbsp;it&nbsp;&amp;&nbsp;is&nbsp;the&nbsp;only&nbsp;disallowed&nbsp;url&nbsp;character&nbsp;allowed&nbsp;in&nbsp;a&nbsp;windows&nbsp;filename</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;name&nbsp;=&nbsp;!<span class="cs__keyword">string</span>.IsNullOrWhiteSpace(headers.ContentDisposition.FileName)&nbsp;?&nbsp;headers.ContentDisposition.FileName&nbsp;:&nbsp;<span class="cs__string">&quot;NoName&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;name.Trim(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">char</span>[]&nbsp;{&nbsp;<span class="cs__string">'&quot;'</span>&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Replace(<span class="cs__string">&quot;&amp;&quot;</span>,&nbsp;<span class="cs__string">&quot;and&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h3>AngularJS</h3>
<p>The SPA is in the afolder called <strong>app</strong> under the project root. It is a basic, AngularJS application with a module called
<strong>Photo</strong>.&nbsp;</p>
<p><img id="128422" src="128422-appfolders.jpg" alt="" width="219" height="327"></p>
<p>&nbsp;</p>
<p>Here is an overview of the components under the photo module and their purpose:&nbsp;</p>
<ul>
<li>The <strong>photos </strong>controller and view: shows a list of existing photos on in the Album folder on the server and allows the user to delete them.
</li><li>The <strong>photoManager</strong>: a service which encapsulates the functionality to load photos, add new photos and delete existing ones.&nbsp;
</li><li>The <strong>photoManagerClient</strong>: a resource service to communicate with the PhotoController.
</li><li>The <strong>egPhotoUploader</strong>: a directive which allows the user to select local files and then upload them.
</li></ul>
<p>Hopefully most of the code above should be easy enough to step through. The <strong>
egPhotoUploader</strong> however does need some explanation as it needs to overcome a couple of limitations Angular.</p>
<h3>egPhotoUploader</h3>
<p>The template for the directive is a multipart/form-data&nbsp;form. Angular does not have a native way of binding to the files on a multiple file input element so two custom directives are needed.</p>
<p>The first, called&nbsp;<strong>egFiles</strong>&nbsp;is used to bind the files. The directive also exposes a boolean property&nbsp;<strong>hasFiles</strong>&nbsp;allowing the the parent directive (or controller) to know whether any files have been selected.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;file&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;newPhotos&quot;</span>&nbsp;<span class="html__attr_name">accept</span>=<span class="html__attr_value">&quot;image/*&quot;</span>&nbsp;<span class="html__attr_name">eg-files</span>=<span class="html__attr_value">&quot;photos&quot;</span>&nbsp;<span class="html__attr_name">has-files</span>=<span class="html__attr_value">&quot;hasFiles&quot;</span>&nbsp;multiple<span class="html__tag_start">&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The second, <strong>egUploader</strong>&nbsp;binds the function to be used when uploading the files. It expects the function to return a promise and will reset the parent form to clear the files when the promise is resolved.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-primary&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;button&quot;</span>&nbsp;<span class="html__attr_name">eg-upload</span>=<span class="html__attr_value">&quot;upload(photos)&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;upload&quot;</span><span class="html__tag_start">&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<h2>Summary</h2>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p>If you have any questions or suggestions for improvement regarding this sample please feel free to leave them in the Q and A section.</p>
<div></div>
