# Bing Maps for JavaScript Sample
## Requires
- 
## License
- MS-LPL
## Technologies
- Bing Maps
- Windows 8
## Topics
- Controls
- Bing Maps
## Updated
- 10/03/2012
## Description

<p><span style="font-size:medium"><strong>Introduction</strong></span></p>
<p><span style="font-size:small">This sample shows how to use the Bing Maps SDK for Windows Store apps using JavaScript. It contains all the code you need to get started adding Bing Maps to your Windows Store app.</span></p>
<p><span style="font-size:medium"><strong>Description</strong></span></p>
<p><span style="font-size:small">This sample demonstrates the Bing Maps SDK for Windows Store apps using JavaScript. It contains all the code you need to get started adding Bing Maps to your Windows 8 Store app including basic map API samples that use entities
 (Pushpin, Polygon, TileLayer, Infobox) and modules (Search, Traffic, Venue Maps, Driving Directions). It also shows how to call the Bing Maps REST Services APIs and how to render the results.&nbsp;</span></p>
<p><span style="font-size:small">All <a href="http://msdn.microsoft.com/en-us/library/gg427610.aspx">
Bing Maps AJAX v7 Control APIs</a> are supported in Windows Store apps. However, to load the map APIs, you need to call load module (Microsoft.Maps.loadModule('Microsoft.Maps.Map', { callback: userCallback });), where userCallback is the callback function that
 is called when the map is initialized.</span></p>
<h1><span style="font-size:medium"><strong>Building the Sample</strong></span></h1>
<p><span style="font-size:small">To run this sample you must install the <a href="http://go.microsoft.com/fwlink/?LinkID=264993&clcid=0x409">
Bing Maps SDK for Windows Store apps</a> and get a <a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx">
Bing Maps key</a> for Windows Store apps. You must also have Windows 8 and Visual Studio 2012.</span></p>
<p><span style="font-size:small">Open the sample in Visual Studio and insert your Bing Maps key where it says &ldquo;INSERT_YOUR_BING_MAPS_KEY&rdquo; in the source code. Detailed instructions are provided below.&nbsp;</span></p>
<ul>
<li><span style="font-size:small">Add a reference to&nbsp;Bing Maps SDK for C#, C&#43;&#43;, or Visual Basic.</span>
</li><li><span style="font-size:small">Set the&nbsp;Active solution platform&nbsp;in Visual Studio to one of the following options.&nbsp;
</span>
<ul>
<li><span style="font-size:small">C#, Visual Basic:&nbsp;ARM,&nbsp;x86&nbsp;or&nbsp;x64</span>
</li><li><span style="font-size:small">C&#43;&#43;:&nbsp;ARM,&nbsp;Win32&nbsp;or&nbsp;x64</span>
</li><li><span style="font-size:small">If you are using C# or Visual basic, you must add a reference to&nbsp;Microsoft Visual C&#43;&#43; Runtime Package.</span>
</li><li><span style="font-size:small">Build the sample</span> </li></ul>
</li></ul>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:medium"><strong>More Information</strong></span></p>
<p><span style="font-size:small">For more information about how to use the Bing Maps AJAX Control 7.0 in your Windows Store app, see
<a href="http://go.microsoft.com/fwlink/?LinkID=244450" target="_blank">Developing a Windows Store app</a>.. You can also test drive the control using the
<a href="http://go.microsoft.com/fwlink/?LinkID=217283&clcid=0x409">interactive SDK</a> on the Bing Maps Account Center and check out other
<a href="http://go.microsoft.com/fwlink/?LinkId=245652">code samples</a> on the MSDN Code Gallery.</span></p>
<p><span style="font-size:small">Questions? Need help? Post your questions on the
<a href="http://social.msdn.microsoft.com/Forums/en-US/bingmapswindows8/threads">
Bing Maps forum</a> for help from the product team and other community members.</span></p>
<p><span style="font-size:small"><strong>System Requirements</strong></span></p>
<ul>
<li><span style="font-size:small">Windows 8 RTM </span></li><li><span style="font-size:small">Visual Studio 2012 RTM </span></li></ul>
