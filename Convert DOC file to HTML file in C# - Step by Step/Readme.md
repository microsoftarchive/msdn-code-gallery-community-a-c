# Convert DOC file to HTML file in C# - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Office
- .NET Framework
- .NET Framework 4.0
- Visual C#
## Topics
- Controls
- C#
- ASP.NET
- How to
- Office 2010 101 code samples
## Updated
- 10/28/2016
## Description

<h1>Introduction</h1>
<p><em>This is a C # example to convert DOC files into HTML file under .Net using MS Office Automation via a C# UseOffice library. Only the .Net platform, installed package of MS Office and nothing else.</em></p>
<p><em><strong>UseOffice</strong><span>&nbsp;.Net is a&nbsp;</span><strong>robust .Net component</strong><span>&nbsp;to convert between&nbsp;</span><strong>DOC, DOCX, XLS, RTF, PPT, PDF&nbsp;</strong><span>and&nbsp;</span><strong>HTML</strong><span>&nbsp;formats</span><strong>&nbsp;</strong><span>with
 tables, images, fonts, colors etc. Our component is just a class library, it requires Microsoft Office installed. You can install any version of MS Office from: 2000, XP, 2003, 2007, 2010 or 2013.</span><em>&nbsp;</em><br>
</em></p>
<h1>Main Functions</h1>
<h1><em style="font-size:10px"><img id="162795" src="162795-doctohtml.png" alt="" width="800" height="407"></em></h1>
<h1>How to do it:</h1>
<p><em>So, here we'll show you in details how to convert any DOC files in HTML documents using C#.</em></p>
<p><em><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we've the DOC file: sample.doc (please see in att. file) and we need to create &nbsp;a HTML document.</em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;doc to html&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;SautinSoft.UseOffice.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to convert our&nbsp;<em>sample.doc&nbsp;</em>into&nbsp;<em>sample.html</em></em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the UseOffice.Net library we've created a HTML document.</em></p>
<p><em>&nbsp;</em></p>
<p>&nbsp;</p>
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

			//Convert DOC file to HTML file	
			
            SautinSoft.UseOffice u = new SautinSoft.UseOffice();

			//Path to any local file
			string inputFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),@&quot;d:\Tempos\sample.doc&quot;));
			//Path to output resulted file
			string outputFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),@&quot;d:\Tempos\sample.html&quot;));

			//Prepare UseOffice .Net, loads MS Word in memory
			int ret = u.InitWord();			

			//Return values:
			//0 - Loading successfully
			//1 - Can't load MS Word&reg; library in memory 

			if (ret==1)			
				return;
			
			//Converting
			ret = u.ConvertFile(inputFilePath, outputFilePath, SautinSoft.UseOffice.eDirection.DOC_to_HTML);

			//Release MS Word from memory
			u.CloseWord();

			//0 - Converting successfully
			//1 - Can't open input file. Check that you are using full local path to input file, URL and relative path are not supported
			//2 - Can't create output file. Please check that you have permissions to write by this path or probably this path already used by another application
			//3 - Converting failed, please contact with our Support Team
			//4 - MS Office isn't installed. The component requires that any of these versions of MS Office should be installed: 2000, XP, 2003, 2007 or 2010
			if(ret==0 )
			{
				//Show produced file
				System.Diagnostics.Process.Start(outputFilePath);
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Convert&nbsp;DOC&nbsp;file&nbsp;to&nbsp;HTML&nbsp;file&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SautinSoft.UseOffice&nbsp;u&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SautinSoft.UseOffice();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Path&nbsp;to&nbsp;any&nbsp;local&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;inputFilePath&nbsp;=&nbsp;Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),@<span class="cs__string">&quot;d:\Tempos\sample.doc&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Path&nbsp;to&nbsp;output&nbsp;resulted&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;outputFilePath&nbsp;=&nbsp;Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),@<span class="cs__string">&quot;d:\Tempos\sample.html&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Prepare&nbsp;UseOffice&nbsp;.Net,&nbsp;loads&nbsp;MS&nbsp;Word&nbsp;in&nbsp;memory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;ret&nbsp;=&nbsp;u.InitWord();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Return&nbsp;values:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//0&nbsp;-&nbsp;Loading&nbsp;successfully</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//1&nbsp;-&nbsp;Can't&nbsp;load&nbsp;MS&nbsp;Word&reg;&nbsp;library&nbsp;in&nbsp;memory&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ret==<span class="cs__number">1</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Converting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ret&nbsp;=&nbsp;u.ConvertFile(inputFilePath,&nbsp;outputFilePath,&nbsp;SautinSoft.UseOffice.eDirection.DOC_to_HTML);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Release&nbsp;MS&nbsp;Word&nbsp;from&nbsp;memory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;u.CloseWord();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//0&nbsp;-&nbsp;Converting&nbsp;successfully</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//1&nbsp;-&nbsp;Can't&nbsp;open&nbsp;input&nbsp;file.&nbsp;Check&nbsp;that&nbsp;you&nbsp;are&nbsp;using&nbsp;full&nbsp;local&nbsp;path&nbsp;to&nbsp;input&nbsp;file,&nbsp;URL&nbsp;and&nbsp;relative&nbsp;path&nbsp;are&nbsp;not&nbsp;supported</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//2&nbsp;-&nbsp;Can't&nbsp;create&nbsp;output&nbsp;file.&nbsp;Please&nbsp;check&nbsp;that&nbsp;you&nbsp;have&nbsp;permissions&nbsp;to&nbsp;write&nbsp;by&nbsp;this&nbsp;path&nbsp;or&nbsp;probably&nbsp;this&nbsp;path&nbsp;already&nbsp;used&nbsp;by&nbsp;another&nbsp;application</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//3&nbsp;-&nbsp;Converting&nbsp;failed,&nbsp;please&nbsp;contact&nbsp;with&nbsp;our&nbsp;Support&nbsp;Team</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//4&nbsp;-&nbsp;MS&nbsp;Office&nbsp;isn't&nbsp;installed.&nbsp;The&nbsp;component&nbsp;requires&nbsp;that&nbsp;any&nbsp;of&nbsp;these&nbsp;versions&nbsp;of&nbsp;MS&nbsp;Office&nbsp;should&nbsp;be&nbsp;installed:&nbsp;2000,&nbsp;XP,&nbsp;2003,&nbsp;2007&nbsp;or&nbsp;2010</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(ret==<span class="cs__number">0</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Show&nbsp;produced&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(outputFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
Product Home:&nbsp;<a href="http://sautinsoft.com/convert-rtf-html-doc-docx-xls-xlsx-ppt-to-pdf-net-library/overview.php">UseOffice.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/convert-rtf-html-doc-docx-xls-xlsx-ppt-to-pdf-net-library/free-download.php">UseOffice.Net</a></em><br>
</em></div>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 2.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that UseOffice.Net is entirely written in managed C#, which makes it absolutely
 standalone and an independent library</em></p>
<p class="CommonText"><em><span class="style3">Requires MS Office&reg;</span><span>, any version: 2000, XP, 2003, 2007, 2010 or 2013</span></em></p>
