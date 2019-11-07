# Convert DOC (DOCX) file to PDF file in C# - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- COM
- C#
- Silverlight
- ASP.NET
- Office
- IIS
- Windows Forms
- Microsoft Azure
- Windows 7
- .NET Framework
- Windows
- Office 365
- Office 2010
- Visual C#
- Office Development
## Topics
- COM
- C#
- Silverlight
- ASP.NET
- User Interface
- Windows Forms
- custom controls
- Office 365
- COM Interop
- .NET 4
- How to
- Office 2010 101 code samples
## Updated
- 01/27/2016
## Description

<h1>Introduction</h1>
<p>This is a C # example to convert DOC (DOCX) files into PDF under .Net using MS Office Automation via a free C# PDF library. Only the .Net platform, installed package of MS Office and nothing else.</p>
<p><strong>With help of UseOffice .Net you will be able to create such applications as:</strong></p>
<ul>
<li>
<p>Convert word to pdf.</p>
</li><li>
<p>Doc / DocX to pdf converter.</p>
</li></ul>
<h1>Main Functions</h1>
<p><img id="147861" src="147861-useoffice.png" alt=""></p>
<h1>How to do it:</h1>
<p><em>So, here we'll show you in details how to convert any DOC (DOCX) files in PDF documents using C#.</em></p>
<p><em><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we've the DOCX file: odissey.docx (please see in att. file) and we need to create &nbsp;a PDF document.</em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;docx to pdf&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;SautinSoft.UseOffice.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to convert our
<em>odissey.docx&nbsp;</em>into&nbsp;<em>odissey.pdf</em></em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the UseOffice.Net library we've created a PDF document.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.IO;
using System.Collections;
using SautinSoft;

namespace Sample
{
	class Test
	{
		
		static void Main(string[] args)
		{

			SautinSoft.UseOffice u = new SautinSoft.UseOffice();
            // You may download the latest version of SDK here: 
            // www.sautinsoft.com/convert-rtf-html-doc-docx-xls-xlsx-ppt-to-pdf-net-library/free-download.php 
            string inFile = @&quot;c:\Odissey.docx&quot;;
			string outFile = Path.ChangeExtension(inFile,&quot;.pdf&quot;);

			//Prepare UseOffice .Net, loads MS Word in memory
            if (u.InitWord() == 0)
            {
                u.ConvertFile(inFile, outFile, SautinSoft.UseOffice.eDirection.DOCX_to_PDF);
                //Release MS Word from memory
                u.CloseWord();
            }
		}
	}
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Test&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SautinSoft.UseOffice&nbsp;u&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SautinSoft.UseOffice();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;www.sautinsoft.com/convert-rtf-html-doc-docx-xls-xlsx-ppt-to-pdf-net-library/free-download.php&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;inFile&nbsp;=&nbsp;@<span class="cs__string">&quot;c:\Odissey.docx&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;outFile&nbsp;=&nbsp;Path.ChangeExtension(inFile,<span class="cs__string">&quot;.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Prepare&nbsp;UseOffice&nbsp;.Net,&nbsp;loads&nbsp;MS&nbsp;Word&nbsp;in&nbsp;memory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(u.InitWord()&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;u.ConvertFile(inFile,&nbsp;outFile,&nbsp;SautinSoft.UseOffice.eDirection.DOCX_to_PDF);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Release&nbsp;MS&nbsp;Word&nbsp;from&nbsp;memory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;u.CloseWord();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1>Source Code Files</h1>
<div><em>Related Links:</em></div>
<div><em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home: <a href="http://sautinsoft.com/convert-rtf-html-doc-docx-xls-xlsx-ppt-to-pdf-net-library/overview.php">
UseOffice.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/convert-rtf-html-doc-docx-xls-xlsx-ppt-to-pdf-net-library/free-download.php">UseOffice.Net</a></em><br>
</em></div>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 2.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that UseOffice.Net is entirely written in managed C#, which makes it absolutely
 standalone and an independent library</em></p>
<p class="CommonText"><em><span class="style3">Requires MS Office&reg;</span><span>, any version: 2000, XP, 2003, 2007, 2010 or 2013</span></em></p>
