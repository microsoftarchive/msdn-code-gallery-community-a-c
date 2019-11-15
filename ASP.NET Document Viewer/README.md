# ASP.NET Document Viewer
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET
## Topics
- asp.net document viewer
## Updated
- 08/08/2019
## Description

<h1>DocumentUltimate: ASP.NET Document Viewer</h1>
<p>DocumentUltimate is an ASP.NET Document Viewer and Converter which supports both ASP.NET MVC and ASP.NET WebForms web applications/web sites. DocumentUltimate can also be used with .NET desktop applications for conversion between several document formats.</p>
<ul>
<li>View almost any document type (70&#43; file formats, including PDF &amp; Microsoft Office).
</li><li>HTML5 Zero-footprint viewer. </li><li>Convert between document types. </li></ul>
<p><img id="153277" src="https://i1.code.msdn.s-msft.com/aspnet-document-viewer-6d83ecc3/image/file/153277/1/documentultimate-screenshot.png" alt="" width="736" height="546"></p>
<p><strong>Note:</strong> This project&nbsp;contains a fully working version of the product, however without a license key it will run in trial mode. For more information, please see&nbsp;<a href="http://www.gleamtech.com/documentultimate">DocumentUltimate:
 ASP.NET Document Viewer</a>&nbsp;product page.</p>
<div>
<h3 style="margin-top:24px; margin-bottom:16px; font-size:1.25em; font-weight:600; line-height:1.25; color:#24292e">
To use DocumentUltimate in an ASP.NET MVC Project, do the following in Visual Studio:</h3>
<ol style="padding-left:2em; margin-top:0px; margin-bottom:16px; color:#24292e; font-size:16px">
<li>
<p style="margin-top:16px; margin-bottom:16px">Add references to DocumentUltimate assemblies. There are two ways to perform this:</p>
<ul style="padding-left:2em; margin-top:0px; margin-bottom:0px">
<li>
<p style="margin-top:16px; margin-bottom:16px">Add reference to&nbsp;<span style="font-weight:600">GleamTech.Core.dll</span>&nbsp;and&nbsp;<span style="font-weight:600">GleamTech.DocumentUltimate.dll</span>&nbsp;found in &quot;Bin&quot; folder of DocumentUltimate-vX.X.X.X.zip
 package which you already downloaded and extracted.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Or install NuGet package and add references automatically via NuGet Package Manager in Visual Studio: Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Package Manager Console</span>&nbsp;and
 run this command:</p>
<p style="margin-top:16px; margin-bottom:16px"><code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">Install-Package DocumentUltimate -Source https://get.gleamtech.com/nuget/default/</code></p>
<p style="margin-top:16px; margin-bottom:16px">If you prefer using the user interface when working with NuGet, you can also install the package this way:</p>
<ul style="padding-left:2em; margin-top:0px; margin-bottom:0px">
<li>
<p style="margin-top:16px; margin-bottom:16px">&nbsp;GleamTech has its own NuGet feed so first you need to add this feed to be able to find GleamTech's packages. Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Package Manager
 Settings</span>&nbsp;and then click the&nbsp;<span style="font-weight:600">&#43;</span>&nbsp;button to add a new package source. Enter&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">GleamTech</code>&nbsp;in&nbsp;<span style="font-weight:600">Name</span>&nbsp;field
 and&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">https://get.gleamtech.com/nuget/default/</code>&nbsp;in&nbsp;<span style="font-weight:600">Source</span>field
 and click&nbsp;<span style="font-weight:600">OK</span>.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Manage NuGet Packages for Solution</span>, select&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">GleamTech</code>&nbsp;or&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">All</code>&nbsp;in
 the Package source dropdown on the top right. Now enter&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimate</code>&nbsp;in the search field, and
 click&nbsp;<span style="font-weight:600">Install</span>&nbsp;button on the found package.</p>
</li></ul>
</li></ul>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Set DocumentUltimate's global configuration. For example, you may want to set the license key and the cache path. Insert some of the following lines (if overriding a default value is required) into the&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">Application_Start</code>&nbsp;method
 of your&nbsp;<span style="font-weight:600">Global.asax.cs</span>:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal"><span class="pl-c" style="color:#6a737d">//Set this property only if you have a valid license key, otherwise do not</span>
<span class="pl-c" style="color:#6a737d">//set it so DocumentUltimate runs in trial mode.</span>
<span class="pl-en" style="color:#6f42c1">DocumentUltimateConfiguration.Current.LicenseKey</span> = &quot;QQJDJLJP34...&quot;;

<span class="pl-c" style="color:#6a737d">//The default CacheLocation value is &quot;~/App_Data/DocumentCache&quot;</span>
<span class="pl-c" style="color:#6a737d">//Both virtual and physical paths are allowed (or a Location instance for one of the supported </span>
<span class="pl-c" style="color:#6a737d">//file systems like Amazon S3 and Azure Blob).</span>
<span class="pl-en" style="color:#6f42c1">DocumentUltimateWebConfiguration.Current.CacheLocation</span> = &quot;~/App_Data/DocumentCache&quot;;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Alternatively you can specify the configuration in&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">&lt;appSettings&gt;</code>&nbsp;tag
 of your Web.config.</p>
<div class="highlight highlight-text-xml" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">key</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>DocumentUltimate:LicenseKey<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">value</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>QQJDJLJP34...<span class="pl-pds">&quot;</span></span> /&gt;
&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">key</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>DocumentUltimateWeb:CacheLocation<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">value</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>~/App_Data/DocumentCache<span class="pl-pds">&quot;</span></span> /&gt;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">As you would notice,&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimate:</code>&nbsp;prefix maps
 to&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimateConfiguration.Current</code>&nbsp;and&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimateWeb:</code>&nbsp;prefix
 maps to&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimateWebConfiguration.Current</code>.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Open one of your View pages (eg. Index.cshtml) and at the top of your page add the necessary namespaces:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">@<span class="pl-k" style="color:#d73a49">using</span> <span class="pl-en" style="color:#6f42c1">GleamTech.AspNet.Mvc</span>
@<span class="pl-k" style="color:#d73a49">using</span> <span class="pl-en" style="color:#6f42c1">GleamTech.DocumentUltimate</span>
@<span class="pl-k" style="color:#d73a49">using</span> <span class="pl-en" style="color:#6f42c1">GleamTech.DocumentUltimate.AspNet</span>
@<span class="pl-k" style="color:#d73a49">using</span> <span class="pl-en" style="color:#6f42c1">GleamTech.DocumentUltimate.AspNet.UI</span></pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Alternatively you can add the namespaces globally in&nbsp;<span style="font-weight:600">Views/web.config</span>&nbsp;under<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">&lt;system.web.webPages.razor&gt;/&lt;pages&gt;/&lt;namespaces&gt;</code>&nbsp;tag
 to avoid adding namespaces in your pages every time:</p>
<div class="highlight highlight-text-xml" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">namespace</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.AspNet.Mvc<span class="pl-pds">&quot;</span></span> /&gt;
&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">namespace</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate<span class="pl-pds">&quot;</span></span> /&gt;
&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">namespace</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate.AspNet<span class="pl-pds">&quot;</span></span> /&gt;
&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">namespace</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate.AspNet.UI<span class="pl-pds">&quot;</span></span> /&gt;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Now in your page insert these lines:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">&lt;!DOCTYPE html&gt;
@{
    <span class="pl-k" style="color:#d73a49">var</span> <span class="pl-en" style="color:#6f42c1">documentViewer </span>= <span class="pl-k" style="color:#d73a49">new</span> <span class="pl-en" style="color:#6f42c1">DocumentViewer</span>
    {
        Width = <span class="pl-c1" style="color:#005cc5">800</span>,
        Height = <span class="pl-c1" style="color:#005cc5">600</span>,
        Document = <span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>~/Documents/Document.docx<span class="pl-pds">&quot;</span></span>
    };
}
&lt;<span class="pl-en" style="color:#6f42c1">html</span>&gt;
    &lt;head&gt;
        &lt;title&gt;Document Viewer&lt;/title&gt;
        @this.<span class="pl-en" style="color:#6f42c1">RenderHead</span>(documentViewer)
    &lt;/head&gt;
    &lt;body&gt;
        @this.<span class="pl-en" style="color:#6f42c1">RenderBody</span>(documentViewer)
    &lt;/body&gt;
&lt;/html&gt;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">This will render a DocumentViewer control in the page which loads and displays the source document &quot;~/Documents/Document.docx&quot;. Upon first view, internally DocumentViewer will convert the source document to PDF
 (used for &quot;Download as Pdf&quot; and also for next conversion step) and then to XPZ (a special web-friendly format which DocumentViewer uses to actually render documents in the browser). So in this case the user will see &quot;please wait awhile...&quot; message in the viewer
 for a few seconds. These generated PDF and XPZ files will be cached and upon consecutive page views, the document will be served directly from the cache so the user will see the document instantly on second viewing. When you modify the source document, the
 cached files are invalidated so your original document and the corresponding cached files are always synced automatically. Note that it's also possible to pre-cache documents via&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentCache.PreCacheDocument</code>&nbsp;method
 (e.g. when your user uploads a document).</p>
</li></ol>
<h3 style="margin-top:24px; margin-bottom:16px; font-size:1.25em; font-weight:600; line-height:1.25; color:#24292e">
<a id="user-content-to-use-documentultimate-in-an-aspnet-webforms-project-do-the-following-in-visual-studio" class="anchor" href="https://github.com/GleamTech/DocumentUltimate#to-use-documentultimate-in-an-aspnet-webforms-project-do-the-following-in-visual-studio" style="background-color:transparent; color:#0366d6; float:left; padding-right:4px; margin-left:-20px; line-height:1"></a>To
 use DocumentUltimate in an ASP.NET WebForms Project, do the following in Visual Studio:</h3>
<ol style="padding-left:2em; margin-top:0px; color:#24292e; font-size:16px; margin-bottom:0px!important">
<li>
<p style="margin-top:16px; margin-bottom:16px">Add references to DocumentUltimate assemblies. There are two ways to perform this:</p>
<ul style="padding-left:2em; margin-top:0px; margin-bottom:0px">
<li>
<p style="margin-top:16px; margin-bottom:16px">Add reference to&nbsp;<span style="font-weight:600">GleamTech.Core.dll</span>&nbsp;and&nbsp;<span style="font-weight:600">GleamTech.DocumentUltimate.dll</span>&nbsp;found in &quot;Bin&quot; folder of DocumentUltimate-vX.X.X.X.zip
 package which you already downloaded and extracted.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Or install NuGet package and add references automatically via NuGet Package Manager in Visual Studio: Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Package Manager Console</span>&nbsp;and
 run this command:</p>
<p style="margin-top:16px; margin-bottom:16px"><code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">Install-Package DocumentUltimate -Source https://get.gleamtech.com/nuget/default/</code></p>
<p style="margin-top:16px; margin-bottom:16px">If you prefer using the user interface when working with NuGet, you can also install the package this way:</p>
<ul style="padding-left:2em; margin-top:0px; margin-bottom:0px">
<li>
<p style="margin-top:16px; margin-bottom:16px">&nbsp;GleamTech has its own NuGet feed so first you need to add this feed to be able to find GleamTech's packages. Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Package Manager
 Settings</span>&nbsp;and then click the&nbsp;<span style="font-weight:600">&#43;</span>&nbsp;button to add a new package source. Enter&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">GleamTech</code>&nbsp;in&nbsp;<span style="font-weight:600">Name</span>&nbsp;field
 and&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">https://get.gleamtech.com/nuget/default/</code>&nbsp;in&nbsp;<span style="font-weight:600">Source</span>field
 and click&nbsp;<span style="font-weight:600">OK</span>.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Go to&nbsp;<span style="font-weight:600">Tools -&gt; NuGet Package Manager -&gt; Manage NuGet Packages for Solution</span>, select&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">GleamTech</code>&nbsp;or&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">All</code>&nbsp;in
 the Package source dropdown on the top right. Now enter&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimate</code>&nbsp;in the search field, and
 click&nbsp;<span style="font-weight:600">Install</span>&nbsp;button on the found package.</p>
</li></ul>
</li></ul>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Set DocumentUltimate's global configuration. For example, you may want to set the license key and the cache path. Insert some of the following lines (if overriding a default value is required) into the&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">Application_Start</code>&nbsp;method
 of your&nbsp;<span style="font-weight:600">Global.asax.cs</span>:</p>
<div class="highlight highlight-source-cs" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal"><span class="pl-c" style="color:#6a737d">//Set this property only if you have a valid license key, otherwise do not</span>
<span class="pl-c" style="color:#6a737d">//set it so DocumentUltimate runs in trial mode.</span>
<span class="pl-en" style="color:#6f42c1">DocumentUltimateConfiguration.Current.LicenseKey</span> = &quot;QQJDJLJP34...&quot;;

<span class="pl-c" style="color:#6a737d">//The default CacheLocation value is &quot;~/App_Data/DocumentCache&quot;</span>
<span class="pl-c" style="color:#6a737d">//Both virtual and physical paths are allowed (or a Location instance for one of the supported </span>
<span class="pl-c" style="color:#6a737d">//file systems like Amazon S3 and Azure Blob).</span>
<span class="pl-en" style="color:#6f42c1">DocumentUltimateWebConfiguration.Current.CacheLocation</span> = &quot;~/App_Data/DocumentCache&quot;;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Alternatively you can specify the configuration in&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">&lt;appSettings&gt;</code>&nbsp;tag
 of your Web.config.</p>
<div class="highlight highlight-text-xml" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">key</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>DocumentUltimate:LicenseKey<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">value</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>QQJDJLJP34...<span class="pl-pds">&quot;</span></span> /&gt;
&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">key</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>DocumentUltimateWeb:CacheLocation<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">value</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>~/App_Data/DocumentCache<span class="pl-pds">&quot;</span></span> /&gt;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">As you would notice,&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimate:</code>&nbsp;prefix maps
 to&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimateConfiguration.Current</code>&nbsp;and&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimateWeb:</code>&nbsp;prefix
 maps to&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentUltimateWebConfiguration.Current</code>.</p>
</li><li style="margin-top:0.25em">
<p style="margin-top:16px; margin-bottom:16px">Open one of your pages (eg. Default.aspx) and at the top of your page add add the necessary namespaces:</p>
<div class="highlight highlight-text-html-asp" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal"><span class="pl-s1"><span class="pl-pse">&lt;%</span>@ Register TagPrefix<span class="pl-k" style="color:#d73a49">=</span><span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech<span class="pl-pds">&quot;</span></span> Namespace<span class="pl-k" style="color:#d73a49">=</span><span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate<span class="pl-pds">&quot;</span></span> Assembly<span class="pl-k" style="color:#d73a49">=</span><span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate<span class="pl-pds">&quot;</span></span> <span class="pl-pse">%&gt;</span></span>
<span class="pl-s1"><span class="pl-pse">&lt;%</span>@ Register TagPrefix<span class="pl-k" style="color:#d73a49">=</span><span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech<span class="pl-pds">&quot;</span></span> Namespace<span class="pl-k" style="color:#d73a49">=</span><span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate.AspNet.WebForms<span class="pl-pds">&quot;</span></span> Assembly<span class="pl-k" style="color:#d73a49">=</span><span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate<span class="pl-pds">&quot;</span></span> <span class="pl-pse">%&gt;</span></span></pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Alternatively you can add the namespaces globally in&nbsp;<span style="font-weight:600">Web.config</span>&nbsp;under&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">&lt;system.web&gt;/&lt;pages&gt;/&lt;controls&gt;</code>&nbsp;tag
 to avoid adding namespaces in your pages every time:</p>
<div class="highlight highlight-text-xml" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">tagPrefix</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">namespace</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">assembly</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate<span class="pl-pds">&quot;</span></span> /&gt;
&lt;<span class="pl-ent" style="color:#22863a">add</span> <span class="pl-e" style="color:#6f42c1">tagPrefix</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">namespace</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate.AspNet.WebForms<span class="pl-pds">&quot;</span></span> <span class="pl-e" style="color:#6f42c1">assembly</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>GleamTech.DocumentUltimate<span class="pl-pds">&quot;</span></span> /&gt;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">Now in your page insert these lines:</p>
<div class="highlight highlight-text-html-asp" style="margin-bottom:16px">
<pre style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; margin-top:0px; margin-bottom:0px; word-wrap:normal; padding:16px; overflow:auto; line-height:1.45; background-color:#f6f8fa; word-break:normal">&lt;!DOCTYPE html&gt;
&lt;<span class="pl-ent" style="color:#22863a">html</span>&gt;
    &lt;<span class="pl-ent" style="color:#22863a">head</span> <span class="pl-e" style="color:#6f42c1">runat</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>server<span class="pl-pds">&quot;</span></span>&gt;
        &lt;<span class="pl-ent" style="color:#22863a">title</span>&gt;Document Viewer&lt;/<span class="pl-ent" style="color:#22863a">title</span>&gt;
    &lt;/<span class="pl-ent" style="color:#22863a">head</span>&gt;
    &lt;<span class="pl-ent" style="color:#22863a">body</span>&gt;
        &lt;<span class="pl-ent" style="color:#22863a">GleamTech:DocumentViewerControl</span> <span class="pl-e" style="color:#6f42c1">runat</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>server<span class="pl-pds">&quot;</span></span> 
            <span class="pl-e" style="color:#6f42c1">Width</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>800<span class="pl-pds">&quot;</span></span> 
            <span class="pl-e" style="color:#6f42c1">Height</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>600<span class="pl-pds">&quot;</span></span> 
            <span class="pl-e" style="color:#6f42c1">Document</span>=<span class="pl-s" style="color:#032f62"><span class="pl-pds">&quot;</span>~/Documents/Document.docx<span class="pl-pds">&quot;</span></span> /&gt;
    &lt;/<span class="pl-ent" style="color:#22863a">body</span>&gt;
&lt;/<span class="pl-ent" style="color:#22863a">html</span>&gt;</pre>
</div>
<p style="margin-top:16px; margin-bottom:16px">This will render a DocumentViewer control in the page which loads and displays the source document &quot;~/Documents/Document.docx&quot;. Upon first view, internally DocumentViewer will convert the source document to PDF
 (used for &quot;Download as Pdf&quot; and also for next conversion step) and then to XPZ (a special web-friendly format which DocumentViewer uses to actually render documents in the browser). So in this case the user will see &quot;please wait awhile...&quot; message in the viewer
 for a few seconds. These generated PDF and XPZ files will be cached and upon consecutive page views, the document will be served directly from the cache so the user will see the document instantly on second viewing. When you modify the source document, the
 cached files are invalidated so your original document and the corresponding cached files are always synced automatically. Note that it's also possible to pre-cache documents via&nbsp;<code style="font-family:SFMono-Regular,Consolas,&quot;Liberation Mono&quot;,Menlo,Courier,monospace; font-size:13.6px; padding:0.2em 0.4em; margin:0px">DocumentCache.PreCacheDocument</code>&nbsp;method
 (e.g. when your user uploads a document).</p>
</li></ol>
</div>
