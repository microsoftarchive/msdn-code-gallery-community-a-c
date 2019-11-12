# Convert HTML to PDF in Azure Websites with EVO HTML to PDF Converter
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Microsoft Azure
- ASP.NET MVC
## Topics
- HTML to PDF
- PDF API
- Html To Pdf Conversion
- HTML to PDF Converter for Azure
## Updated
- 01/22/2016
## Description

<p><a href="http://www.evopdf.com/">EVO HTML to PDF Converter Library for .NET</a> can be used directly in web roles and worker roles of Azure Cloud Services and in applications running on Azure Virtual Machines but it cannot be used in Azure Websites directly
 because of the restrictions imposed by Azure App Services environment.</p>
<p>For Azure Websites we developed a solution consisting in a service that you can deploy as a separate Azure Worker Role and a client library that you can link directly into your Azure Website to call that service completely transparent for you. The API of
 the client library is almost identical to the general .NET library API.</p>
<p>The converter offers full support for HTML5, CSS3, JavaScript, SVG, web fonts, page breaks control with CSS and from API, automatically repeated HTML table header and footer, live URLs and internal links, automatically generated hierarchical bookmarks and
 table of contents, automatically generated fillable PDF forms and allows you to digitally sign and password protect the generated PDF documents.</p>
<h1>Building the Sample</h1>
<p>You can download from here the demo website for Azure. I<span>n order to run the demo website for HTML to PDF Conversion</span><span>&nbsp;you first have to publish the HTML to PDF Server in Azure. The client library for .NET that you reference in your application
 will know how to connect to the HTML to PDF Server to convert HTML to PDF, to Image or to SVG.
</span></p>
<p>The service for Azure cloud there is in the package for Azure you can donwload from&nbsp;<a href="http://www.evopdf.com/azure-html-to-pdf-converter.aspx">EVO HTML to PDF Converter for Azure</a>&nbsp;web page. You can find detailed installation and uninstallation
 instructions in the&nbsp;<em>Readme.txt</em>&nbsp;file from the root of the downloaded package.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;convertToPdfButton_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;server&nbsp;IP&nbsp;and&nbsp;port</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;serverIP&nbsp;=&nbsp;textBoxServerIP.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">uint</span>&nbsp;serverPort&nbsp;=&nbsp;<span class="cs__keyword">uint</span>.Parse(textBoxServerPort.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;HTML&nbsp;to&nbsp;PDF&nbsp;converter&nbsp;object&nbsp;with&nbsp;default&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HtmlToPdfConverter&nbsp;htmlToPdfConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdfConverter(serverIP,&nbsp;serverPort);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;optional&nbsp;service&nbsp;password</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textBoxServicePassword.Text.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.ServicePassword&nbsp;=&nbsp;textBoxServicePassword.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;HTML&nbsp;Viewer&nbsp;width&nbsp;in&nbsp;pixels&nbsp;which&nbsp;is&nbsp;the&nbsp;equivalent&nbsp;in&nbsp;converter&nbsp;of&nbsp;the&nbsp;browser&nbsp;window&nbsp;width</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.HtmlViewerWidth&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(htmlViewerWidthTextBox.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;HTML&nbsp;viewer&nbsp;height&nbsp;in&nbsp;pixels&nbsp;to&nbsp;convert&nbsp;the&nbsp;top&nbsp;part&nbsp;of&nbsp;a&nbsp;HTML&nbsp;page&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Leave&nbsp;it&nbsp;not&nbsp;set&nbsp;to&nbsp;convert&nbsp;the&nbsp;entire&nbsp;HTML</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(htmlViewerHeightTextBox.Text.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.HtmlViewerHeight&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(htmlViewerHeightTextBox.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;PDF&nbsp;page&nbsp;size&nbsp;which&nbsp;can&nbsp;be&nbsp;a&nbsp;predefined&nbsp;size&nbsp;like&nbsp;A4&nbsp;or&nbsp;a&nbsp;custom&nbsp;size&nbsp;in&nbsp;points&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Leave&nbsp;it&nbsp;not&nbsp;set&nbsp;to&nbsp;have&nbsp;a&nbsp;default&nbsp;A4&nbsp;PDF&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.PdfDocumentOptions.PdfPageSize&nbsp;=&nbsp;SelectedPdfPageSize();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;PDF&nbsp;page&nbsp;orientation&nbsp;to&nbsp;Portrait&nbsp;or&nbsp;Landscape</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Leave&nbsp;it&nbsp;not&nbsp;set&nbsp;to&nbsp;have&nbsp;a&nbsp;default&nbsp;Portrait&nbsp;orientation&nbsp;for&nbsp;PDF&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation&nbsp;=&nbsp;SelectedPdfPageOrientation();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;the&nbsp;maximum&nbsp;time&nbsp;in&nbsp;seconds&nbsp;to&nbsp;wait&nbsp;for&nbsp;HTML&nbsp;page&nbsp;to&nbsp;be&nbsp;loaded&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Leave&nbsp;it&nbsp;not&nbsp;set&nbsp;for&nbsp;a&nbsp;default&nbsp;60&nbsp;seconds&nbsp;maximum&nbsp;wait&nbsp;time</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.NavigationTimeout&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(navigationTimeoutTextBox.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;an&nbsp;adddional&nbsp;delay&nbsp;in&nbsp;seconds&nbsp;to&nbsp;wait&nbsp;for&nbsp;JavaScript&nbsp;or&nbsp;AJAX&nbsp;calls&nbsp;after&nbsp;page&nbsp;load&nbsp;completed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;this&nbsp;property&nbsp;to&nbsp;0&nbsp;if&nbsp;you&nbsp;don't&nbsp;need&nbsp;to&nbsp;wait&nbsp;for&nbsp;such&nbsp;asynchcronous&nbsp;operations&nbsp;to&nbsp;finish</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(conversionDelayTextBox.Text.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.ConversionDelay&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(conversionDelayTextBox.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;buffer&nbsp;to&nbsp;receive&nbsp;the&nbsp;generated&nbsp;PDF&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;outPdfBuffer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(convertUrlRadioButton.Checked)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;urlTextBox.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Convert&nbsp;the&nbsp;HTML&nbsp;page&nbsp;given&nbsp;by&nbsp;an&nbsp;URL&nbsp;to&nbsp;a&nbsp;PDF&nbsp;document&nbsp;in&nbsp;a&nbsp;memory&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;outPdfBuffer&nbsp;=&nbsp;htmlToPdfConverter.ConvertUrl(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;htmlString&nbsp;=&nbsp;htmlStringTextBox.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;baseUrl&nbsp;=&nbsp;baseUrlTextBox.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Convert&nbsp;a&nbsp;HTML&nbsp;string&nbsp;with&nbsp;a&nbsp;base&nbsp;URL&nbsp;to&nbsp;a&nbsp;PDF&nbsp;document&nbsp;in&nbsp;a&nbsp;memory&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;outPdfBuffer&nbsp;=&nbsp;htmlToPdfConverter.ConvertHtml(htmlString,&nbsp;baseUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Send&nbsp;the&nbsp;PDF&nbsp;as&nbsp;response&nbsp;to&nbsp;browser</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;response&nbsp;content&nbsp;type</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Response.AddHeader(<span class="cs__string">&quot;Content-Type&quot;</span>,&nbsp;<span class="cs__string">&quot;application/pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Instruct&nbsp;the&nbsp;browser&nbsp;to&nbsp;open&nbsp;the&nbsp;PDF&nbsp;file&nbsp;as&nbsp;an&nbsp;attachment&nbsp;or&nbsp;inline</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Response.AddHeader(<span class="cs__string">&quot;Content-Disposition&quot;</span>,&nbsp;String.Format(<span class="cs__string">&quot;{0};&nbsp;filename=Getting_Started.pdf;&nbsp;size={1}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openInlineCheckBox.Checked&nbsp;?&nbsp;<span class="cs__string">&quot;inline&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;attachment&quot;</span>,&nbsp;outPdfBuffer.Length.ToString()));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Write&nbsp;the&nbsp;PDF&nbsp;document&nbsp;buffer&nbsp;to&nbsp;HTTP&nbsp;response</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Response.BinaryWrite(outPdfBuffer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;End&nbsp;the&nbsp;HTTP&nbsp;response&nbsp;and&nbsp;stop&nbsp;the&nbsp;current&nbsp;page&nbsp;processing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Response.End();&nbsp;
}</pre>
</div>
</div>
</div>
