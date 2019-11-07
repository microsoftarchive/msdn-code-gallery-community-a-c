# Asp.Net Multilingual WebSite
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- asp.net 4.0
## Topics
- ASP.NET Web API
- ASP.net Multi language support
## Updated
- 01/26/2015
## Description

<h1>Introduction</h1>
<p><em>&nbsp;</em>This sample is developed to provide the solution to Multilanguage support for the ASP.Net&nbsp;web application with .Net 4.0.</p>
<h1><span>Building the Sample</span></h1>
<p>This application / website is developed with the use of ASP.Net 4.0 framework.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-family:Calibri"><span style="font-size:small">This application / web site can be used as an example for multilingual web application by implicit localization.
</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-family:Calibri"><span style="font-size:small">In this application we have made use of resource files to store the strings from different languages.
</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-family:Calibri"><span style="font-size:small">This way of implementing the Multilanguage application is called implicit localization. In implicit localization, you specify that control properties
 should automatically be read from a resource file, but you do not need to explicitly specify which properties are localized.
</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-family:Calibri"><span style="font-size:small">Then, you create a resource file with localized values for specific properties. At run time, ASP.NET examines the controls on the page. If the
 control is marked to use implicit localization, ASP.NET looks through the resource file for the page. If it finds property settings for the marked control, ASP.NET substitutes the values in the resource file for those in the control.
</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-family:Calibri"><span style="font-size:small">This application currently supports only two languages such and EN-US (English) and FR-FR (French).</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-family:Calibri"><span style="font-size:small">An effective way to create localized Web pages is to use resource objects for your page's text and controls. By using properties placed in resource
 objects, ASP.NET can select the correct property at run time according to the user's language and culture. The process is straightforward:</span></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-18pt; margin:0cm 0cm 0pt 36pt">
<span style="font-family:Symbol"><span><span style="font-size:small">&middot;</span><span style="font:7pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:Calibri"><span style="font-size:small">A set of resource files (.resx), one file for each language, stores localized text.</span></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-18pt; margin:0cm 0cm 0pt 36pt">
<span style="font-family:Symbol"><span><span style="font-size:small">&middot;</span><span style="font:7pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:Calibri"><span style="font-size:small">In your page, you indicate that controls should use resources for their property values.
</span></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-18pt; margin:0cm 0cm 10pt 36pt">
<span style="font-family:Symbol"><span><span style="font-size:small">&middot;</span><span style="font:7pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:small"><span style="font-family:Calibri">At run time, the browser indicates the user's preferred language, ASP.NET selects the appropriate .resx file, and the controls' property values are derived from the resource
 file.</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Below are the steps to be performed to make the web application as Multilingual.</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Begin with go to the solution explorer and click on the .aspx page.
</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Go to the design of the .aspx page this will open the design of the aspx page as shown below.</span></span><span style="font-size:small"><span style="font-family:Calibri"><span>&nbsp;</span></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri"><span><img id="93998" src="93998-imageone.jpg" alt="" width="630" height="343"></span></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Click on the Tool menu in visual studio and then click on the &ldquo;Generate Local Resource&rdquo; which will add the resource file for the current
 selected aspx page under the App_LocalResources. <span>&nbsp;</span></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri"><span>&nbsp;<img id="93999" src="93999-imagetwo.jpg" alt="" width="630" height="343"></span></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">In solution explorer we are able to see the resource files which are created and also there are some files which are created for French language.</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri"><span>&nbsp;<img id="94000" src="94000-imagethree.jpg" alt="" width="630" height="343"></span></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Default.aspx.resx file we have similar file for French language as Default.aspx.fr.resx</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri"><strong>NOTE:
</strong></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Every new language and culture combination requires a unique resource file. To add other cultures, you can use your default file as a starting
 point. The simple way of creating resource file for different cultures and locales is by using the ISO codes.</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">The ISO codes are placed between the page name and the .resx file name extension, as in Default.aspx.FR-Fr.resx. To specify a culturally neutral
 language, you would eliminate the country code, such as Sample.aspx.fr.resx for the French language.<strong>&nbsp;</strong></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><strong><span style="font-family:Calibri; font-size:small">&nbsp;</span></strong></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><strong><span style="font-size:small"><span style="font-family:Calibri">Steps to Add new resource file for new language (<span class="input">en-gb</span>) supported by application.</span></span></strong></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Below are the steps to be performed to add support for new language in the application.</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri"><span>&nbsp;<img id="94001" src="94001-imagefour.jpg" alt="" width="630" height="343"></span></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Right Click on Default.aspx.resx file and click &ldquo;Copy&rdquo;</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri"><span>&nbsp;<img id="94002" src="94002-imagefive.jpg" alt="" width="630" height="343"></span></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Right Click on &ldquo;App_LocalResource&rdquo; folder and click &ldquo;Paste&rdquo; this will create the new resource file as &ldquo;Copy of Default.aspx.resx&rdquo;
 rename the file as &ldquo;Default.aspx.<span class="input">en-gb</span>.resx&rdquo; and save the file.</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">&nbsp;<img id="94003" src="94003-imagesix.jpg" alt="" width="630" height="343"></span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-size:small"><span style="font-family:Calibri">Resource file will get created for the &ldquo;en-gb&rdquo; culture.
</span></span></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><strong><span style="font-family:Calibri; font-size:small">&nbsp;Test the Application</span></strong></p>
<p class="MsoNormal" style="margin:0cm 0cm 10pt"><span style="font-family:Calibri; font-size:small">To test the application for different languages run the application by clicking the Ctrl &#43; F5 and once the application is launched then go to Internet Explorer&nbsp;click
 on &quot;Tools&quot; -&gt; &quot;Internet Options&quot; -&gt; &quot;Languages&quot; and selecte language with which you want to test the application and make the language as your first language using &quot;Move up&quot; button click &quot;OK&quot; and then click F5 you should be able to see the changes as
 per the new language selected.</span></p>
<p>&nbsp;Test with&nbsp;language as &quot;EN-US&quot;.</p>
<p>&nbsp;<img id="94047" src="94047-imageeight.jpg" alt="" width="615" height="446"></p>
<p>&nbsp;</p>
<p>&nbsp;Test with&nbsp;language as &quot;FR-Fr&quot;.</p>
<p>&nbsp;<img id="94006" src="94006-imageseven.jpg" alt="" width="603" height="384"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Code is part of solution file uploaded.</pre>
<div class="preview">
<pre class="csharp">Code&nbsp;<span class="cs__keyword">is</span>&nbsp;part&nbsp;of&nbsp;solution&nbsp;file&nbsp;uploaded.</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<h1>&nbsp;</h1>
<h1>More Information</h1>
<p>For More information please visit the MSDN website :</p>
<p>http://msdn.microsoft.com/en-us/library/fw69ke6f(v=vs.100).aspx</p>
<p><span style="font-family:Times New Roman; font-size:small">&nbsp;</span></p>
<p style="margin:0in 0in 0pt"><span style="font-family:Credit Suisse Type Light; font-size:x-small">We can also do the translation using Bing and Google API&rsquo;s.</span></p>
<p><span style="font-family:Times New Roman; font-size:small">&nbsp;</span><span style="font-family:&quot;Credit Suisse Type Light&quot;,&quot;sans-serif&quot;; font-size:10pt"><a href="http://www.societyinpocket.com/"><span style="color:#0000ff">www.societyinpocket.com</span></a>
 is the live example of Language translation using Google API&rsquo;s i have come across.</span></p>
<p>&nbsp;</p>
<div id="_mcePaste" class="mcePaste" style="width:1px; height:1px; overflow:hidden; top:0px; left:-10000px">
</div>
