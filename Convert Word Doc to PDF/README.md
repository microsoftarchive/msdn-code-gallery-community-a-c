# Convert Word Doc to PDF
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- LEADTOOLS
## Topics
- Document Conversion
- Converting DOCX/DOC/HTML/RTF to PDF/XPS/Image
- HTML to SVG
- SVG to PDF
- HTML to SVG Converter
- Convert Word to SVG
- Convert PDF to SVG
- DXF to SVG
- DXF to PDF
## Updated
- 02/01/2017
## Description

<h1><a id="user-content-introduction" class="anchor" href="#introduction"></a>Introduction</h1>
<p>LEAD is continuously updating and adding new features to LEADTOOLS. One feature that was rolled into Version 19 after the initial release includes enhanced
<a href="https://www.leadtools.com/sdk/formats/svg">SVG support</a>. This enhancement allows users to load document and vector formats as SVG, which can then be handed off to other parts of LEADTOOLS such as the Document Writers. In other words, you can convert
 from formats such as DOC, PDF, DWG, DXF, etc. to other document formats such as PDF/A, HTML, and SVG without rasterization or OCR.</p>
<h1><a id="user-content-description" class="anchor" href="#description"></a>Description</h1>
<p>This C/C&#43;&#43; console application project shows how to use LEADTOOLS to convert a Word DOC to document-based PDF. LEADTOOLS SDKs include flexible and time-tested imaging technology for .NET, C/C&#43;&#43;, WinRT, Objective-C, SWIFT, Java, and web development. With
 extensive support for more than 150 file formats and more than 200 image processing functions, LEADTOOLS is the most mature and industry recognized imaging SDK available.</p>
<h2><a id="user-content-source-files" class="anchor" href="#source-files"></a>Source Files</h2>
<p>Once you have installed LEADTOOLS, create a folder called <code>Git</code> in the
<code>{LEADTOOLSInstallDir}\Examples</code> folder. Extract the ZIP file contents into the
<code>Git</code> folder. This should result in a folder structure like <code>C:\LEADTOOLS 19\Examples\GIT\ConvertPdfToTif</code></p>
<p>The project references and output path are relative to this specific folder location. If you installed LEADTOOLS V19 in the setup's default folder, then no changes are required to run the sample.</p>
<p>However, if you changed the default install folder, then you will need to review and update the
<code>filePath</code> and <code>licenseFile</code> variables.</p>
<h3><a id="user-content-maincpp" class="anchor" href="#maincpp"></a>main.cpp</h3>
<p>First, you need to update the developer key and paths to the LEADTOOLS license, source, and target files.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;TODO:&nbsp;Update&nbsp;with&nbsp;your&nbsp;LEADTOOLS&nbsp;license&nbsp;information.</span>&nbsp;
swprintf_s(ltsupport::szLicPath,&nbsp;(L_MAXPATH)&nbsp;/&nbsp;(<span class="cpp__keyword">sizeof</span>&nbsp;ltsupport::szLicPath[<span class="cpp__number">0</span>]),&nbsp;_T(<span class="cpp__string">&quot;D:\\GitHub\\LEADTOOLS\\eval-license-files.lic&quot;</span>));&nbsp;
swprintf_s(ltsupport::szDevKey,&nbsp;(L_MAXPATH)&nbsp;/&nbsp;(<span class="cpp__keyword">sizeof</span>&nbsp;ltsupport::szDevKey[<span class="cpp__number">0</span>]),&nbsp;_T(<span class="cpp__string">&quot;{YourDeveloperKey}&quot;</span>));&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;TODO:&nbsp;Also,&nbsp;update&nbsp;the&nbsp;paths&nbsp;to&nbsp;these&nbsp;files</span>&nbsp;
L_TCHAR&nbsp;<span class="cpp__keyword">const</span>&nbsp;szSourceDocument[]&nbsp;=&nbsp;_T(<span class="cpp__string">&quot;D:\\GitHub\\LEADTOOLS\\press-release.doc&quot;</span>);&nbsp;
L_TCHAR&nbsp;<span class="cpp__keyword">const</span>&nbsp;szTargetDocument[]&nbsp;=&nbsp;_T(<span class="cpp__string">&quot;D:\\GitHub\\LEADTOOLS\\press-release.pdf&quot;</span>);&nbsp;
L_TCHAR&nbsp;<span class="cpp__keyword">const</span>&nbsp;szSourceVector[]&nbsp;=&nbsp;_T(<span class="cpp__string">&quot;D:\\GitHub\\LEADTOOLS\\random.dxf&quot;</span>);&nbsp;
L_TCHAR&nbsp;<span class="cpp__keyword">const</span>&nbsp;szTargetVector[]&nbsp;=&nbsp;_T(<span class="cpp__string">&quot;D:\\GitHub\\LEADTOOLS\\random.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h3><a id="user-content-convert2pdfcpp" class="anchor" href="#convert2pdfcpp"></a>convert2pdf.cpp</h3>
<p>LoadFileAsSVG() will load any supported document format as an SVG in memory.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">BOOL</span>&nbsp;LoadFileAsSvg(<span class="cpp__keyword">const</span>&nbsp;L_TCHAR*&nbsp;sourceFile,&nbsp;L_UCHAR**&nbsp;buffer,&nbsp;L_UINT*&nbsp;bufferSize)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;L_INT&nbsp;nRet&nbsp;=&nbsp;ERROR_FILE_FORMAT;&nbsp;
&nbsp;&nbsp;&nbsp;L_BOOL&nbsp;canLoad&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;nRet&nbsp;=&nbsp;L_CanLoadSvg((L_TCHAR*)sourceFile,&nbsp;&amp;canLoad,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(canLoad)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Setup&nbsp;the&nbsp;doc&nbsp;options&nbsp;to&nbsp;improve&nbsp;the&nbsp;quality&nbsp;to&nbsp;print&nbsp;level&nbsp;dpi</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RASTERIZEDOCOPTIONS&nbsp;docOptions&nbsp;=&nbsp;{&nbsp;<span class="cpp__number">0</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_GetRasterizeDocOptions(&amp;docOptions,&nbsp;<span class="cpp__keyword">sizeof</span>(RASTERIZEDOCOPTIONS));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docOptions.uXResolution&nbsp;=&nbsp;<span class="cpp__number">300</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docOptions.uYResolution&nbsp;=&nbsp;<span class="cpp__number">300</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SetRasterizeDocOptions(&amp;docOptions);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LOADSVGOPTIONS&nbsp;svgOptions&nbsp;=&nbsp;{&nbsp;<span class="cpp__number">0</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;svgOptions.uStructSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(LOADSVGOPTIONS);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nRet&nbsp;=&nbsp;L_LoadSvg((L_TCHAR*)sourceFile,&nbsp;&amp;svgOptions,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(ltsupport::DisplayError(nRet,&nbsp;_T(<span class="cpp__string">&quot;L_LoadSvg&quot;</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nRet&nbsp;=&nbsp;L_SvgSaveDocumentMemory(svgOptions.SvgHandle,&nbsp;buffer,&nbsp;bufferSize,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ltsupport::DisplayError(nRet,&nbsp;_T(<span class="cpp__string">&quot;L_SvgSaveDocumentMemory&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Free&nbsp;the&nbsp;source&nbsp;SVG&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nRet&nbsp;=&nbsp;L_SvgFreeNode(svgOptions.SvgHandle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ltsupport::DisplayError(nRet,&nbsp;_T(<span class="cpp__string">&quot;L_SvgFreeNode&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;svgOptions.SvgHandle&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;{&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>SaveAsPdf() converts the in-memory SVG to a PDF file.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">void</span>&nbsp;SaveAsPdf(<span class="cpp__keyword">const</span>&nbsp;L_TCHAR*&nbsp;targetFile,&nbsp;<span class="cpp__keyword">const</span>&nbsp;L_UCHAR*&nbsp;svgBuffer,&nbsp;L_UINT&nbsp;bufferSize)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;L_INT&nbsp;nRet;&nbsp;
&nbsp;&nbsp;&nbsp;L_SvgNodeHandle&nbsp;hSvgDocument;&nbsp;
&nbsp;&nbsp;&nbsp;nRet&nbsp;=&nbsp;L_SvgLoadDocumentMemory(svgBuffer,&nbsp;bufferSize,&nbsp;&amp;hSvgDocument,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!ltsupport::DisplayError(nRet,&nbsp;_T(<span class="cpp__string">&quot;L_SvgLoadDocumentMemory&quot;</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Check&nbsp;if&nbsp;we&nbsp;need&nbsp;to&nbsp;flat&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_BOOL&nbsp;isFlat&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgIsFlatDocument(hSvgDocument,&nbsp;&amp;isFlat);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!isFlat)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgNodeHandle&nbsp;hFlatDocHandle&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgFlatDocument(hSvgDocument,&nbsp;&amp;hFlatDocHandle,&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgFreeNode(hSvgDocument);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hSvgDocument&nbsp;=&nbsp;hFlatDocHandle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgBounds&nbsp;bounds&nbsp;=&nbsp;{&nbsp;<span class="cpp__number">0</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgGetBounds(hSvgDocument,&nbsp;&amp;bounds,&nbsp;<span class="cpp__keyword">sizeof</span>(L_SvgBounds));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!bounds.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgCalculateBounds(hSvgDocument,&nbsp;FALSE);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Create&nbsp;the&nbsp;PDF&nbsp;from&nbsp;the&nbsp;SVG&nbsp;object&nbsp;in&nbsp;memory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreatePdf(targetFile,&nbsp;hSvgDocument);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Free&nbsp;memory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L_SvgFreeNode(hSvgDocument);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hSvgDocument&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h4><a id="user-content-supports-more-than-just-pdf" class="anchor" href="#supports-more-than-just-pdf"></a>Supports More Than Just PDF</h4>
<p>Changing the output format to something other than PDF is trivial. Just find the call to L_DocWriterInit() in CreatePdf() in convert2PDF.cpp and change the format.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus">nRet&nbsp;=&nbsp;L_DocWriterInit(&nbsp;
&nbsp;&nbsp;&nbsp;&amp;hDocWriter,&nbsp;
&nbsp;&nbsp;&nbsp;(L_TCHAR*)targetFile,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;DOCUMENTFORMAT_PDF,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;NULL,&nbsp;NULL,&nbsp;NULL);</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><a id="user-content-more-information" class="anchor" href="#more-information"></a>More Information</h1>
<p>If you have any questions, do not hesitate to contact <a href="mailto:support@leadtools.com">
support@leadtools.com</a></p>
<p>Download a free LEADTOOLS Evaluation SDK: <a href="https://www.leadtools.com/downloads?category=main">
https://www.leadtools.com/downloads?category=main</a></p>
<p>Read more about LEADTOOLS: <a href="https://www.leadtools.com">https://www.leadtools.com/sdk/svg</a></p>
