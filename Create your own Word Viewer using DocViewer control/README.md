# Create your own Word Viewer using DocViewer control
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Class Library
- Windows Forms
- WPF
## Topics
- Doc Viewer
- Word document viewer
- DocViewer control
## Updated
- 11/16/2016
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This sample presents how to create a simple Word document viewer in Windows Forms to open and close Word files using Spire.DocViewer control.</span><em>&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">How to</span></p>
<p><span style="font-size:small; font-weight:bold; background-color:#ffffff; color:#ff0000">Step 1:
</span><strong><span style="font-size:small; background-color:#ffffff; color:#ff0000">Download
</span><span style="font-size:small; background-color:#ffffff; color:#ff0000"><a href="http://www.e-iceblue.com/Introduce/word-viewer-net-introduce.html">Spire.DocViewer</a>, add DocViewer Control to VS Toolbox.</span></strong></p>
<p><span style="font-size:small; font-weight:bold; background-color:#ffffff; color:#ff0000"><img id="130883" src="130883-7.png" alt="" width="296" height="155" style="float:left"><br>
</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small; color:#ff0000">Step 2: Create a Windows Forms application, design your Form1 as below.</span></strong></p>
<ul>
<li><span style="font-size:small">Add &quot;Open&quot; button to open an existing Word file.</span>
</li><li><span style="font-size:small">Add &quot;Close&quot; button to shut down the open file.</span>
</li><li><span style="font-size:small">Drag &quot;DocDocumentViewer Control&quot; into Form1, which is used to display Word document.</span>
</li></ul>
<p><img id="130884" src="130884-6.png" alt="" width="700" height="294"></p>
<p><span style="color:#ff0000"><strong><span style="font-size:small">Step 3: In the Open click event,</span></strong>
<strong><span style="font-size:small">create an OpenFileDialog to select the correct file type that you want to open. Call LoadFromFile method from DocDocumentViewer to load the Word file.</span></strong></span><strong>
<br>
</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnOpen_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//open&nbsp;a&nbsp;DOC&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OpenFileDialog&nbsp;dialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OpenFileDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dialog.Filter&nbsp;=&nbsp;<span class="cs__string">&quot;Word97-2003&nbsp;files(*.doc)|*.doc|Word2007-2010&nbsp;files&nbsp;(*.docx)|*.docx|All&nbsp;files&nbsp;(*.*)|*.*&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dialog.Title&nbsp;=&nbsp;<span class="cs__string">&quot;Select&nbsp;a&nbsp;DOC&nbsp;file&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dialog.Multiselect&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dialog.InitialDirectory&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.Path.GetFullPath.aspx" target="_blank" title="Auto generated link to System.IO.Path.GetFullPath">System.IO.Path.GetFullPath</a>(@<span class="cs__string">&quot;..\..\..\..\..\..\Data&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DialogResult&nbsp;result&nbsp;=&nbsp;dialog.ShowDialog();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;==&nbsp;DialogResult.OK)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Load&nbsp;DOC&nbsp;document&nbsp;from&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.docDocumentViewer1.LoadFromFile(dialog.FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message,&nbsp;<span class="cs__string">&quot;Error!&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</strong>
<p></p>
<p><span style="color:#ff0000"><strong><span style="font-size:small">Step 4: Close the open file.</span></strong></span></p>
<p><strong>&nbsp;</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;btnClose_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Close&nbsp;current&nbsp;doc&nbsp;document.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.docDocumentViewer1.CloseDocument();&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
</strong>
<p></p>
<p><span style="font-size:small"><strong><span style="color:#000000">Run the code and open with a sample file:</span></strong></span></p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong></p>
<div class="endscriptcode"><img id="130914" src="https://i1.code.msdn.s-msft.com/create-your-own-word-63c926b1/image/file/130914/1/9.png" alt="" width="652" height="284"></div>
</strong>
<p></p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p style="text-align:justify"><span style="font-size:small"><strong>Spire.DocViewer for .NET</strong> is a powerful Word Viewer component for developers to display, convert and interact with Word Documents easily. When developers use Spire.DocViewer for .NET
 within their own .NET application, they do not require any additional installation to manipulate Word Documents with high performance and strong stability.</span></p>
<p style="text-align:justify"><br>
<span style="font-size:small">Spire.DocViewer for .NET expresses scalability, time-saving and cost-effective to view and print Word Documents. Developers can render Word Documents by using Word elements including text, paragraph, image, list, table, bookmark
 etc. Furthermore, Spire.DocViewer for .NET allows developers to load all versions of Word Documents and convert Word Documents to PDF, HTML and RTF.</span></p>
<p><strong><span style="font-size:small">Related Links:</span></strong></p>
<p><span style="font-size:small">Website: <a href="http://www.e-iceblue.com">www.e-iceblue.com</a></span></p>
<p><span style="font-size:small">Product: <a href="http://www.e-iceblue.com/Introduce/word-viewer-net-introduce.html">
Spire.DocViewer</a></span><a href="http://www.e-iceblue.com/Introduce/word-viewer-net-introduce.html"></a></p>
