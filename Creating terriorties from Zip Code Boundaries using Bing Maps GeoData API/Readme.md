# Creating terriorties from Zip Code Boundaries using Bing Maps GeoData API
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- SQL Server
- SQL Azure
- Bing Maps
- Bing Spatial Data Services
## Topics
- SQL Server
- ZIP Code lookup
- Bing Spatial Data Services
## Updated
- 10/08/2015
## Description

<h1>Introduction</h1>
<p>Often it is useful to be able to create custom territories from existing, well known,&nbsp;boundaries. Zip Code boundaries are fairly commonly used to create sales territories. This code sample shows how to take simple&nbsp;zip code information, retrieve
 their boundaries from the Bing Maps GeoData API, combine them together to form a single shape and then generate a Well Known Text format of the shape which can easily be used in Bing Maps and other spatial tools such as SQL.</p>
<p>You can find documentation on the Bing Maps GeoData API here: <a href="https://msdn.microsoft.com/en-us/library/dn306801.aspx">
https://msdn.microsoft.com/en-us/library/dn306801.aspx</a></p>
<p>This code sample also makes use of the SQL Spatial library to do the complex task of combining the boundaries together. Note that this does not require having SQL installed. You can find this library on Nuget here:
<span style="text-decoration:underline"><span style="color:#0066cc">https://www.nuget.org/packages/Microsoft.SqlServer.Types</span></span><span style="text-decoration:underline"><span style="color:#0066cc"><br>
</span></span></p>
<h1>Building the Sample</h1>
<p>To build this sample, open the MainWindows.xaml.cs file and insert your Bing Maps key where it says &quot;Your_Bing_Maps_Key&quot;. Then press the debug button.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This code sample uses a list of zip codes to build a territory. Each zip code also has a coordinate assigned to it. This is a coordinate that is within the boundary of the zip code. If you don't have this you can easily geocode your zip code data ahead of
 time. By using coordinates with the Geodata API you reduce the need to regeocode these zip codes which would save on transactions. You can also find lists of zip codes with coordinates online fairly easily. Here is a screenshot of what this simple&nbsp;app
 looks like:</p>
<p><img id="143114" src="143114-territorybuilder.png" alt="" width="511" height="343"></p>
<p><strong>Tip</strong>: If you use this code with one of the Bing Maps controls either directly or via a webserivce, be sure to pas a session key from the map control to the code rather than using a hard coded Bing Maps key. This will make the requests to
 the GeoData API non-billable.</p>
<p>If you are building a web based app, you can find a well known Text importing module for Bing Maps V7 here:
<span style="text-decoration:underline"><span style="color:#0066cc">http://bingmapsv7modules.codeplex.com/wikipage?title=Well%20Known%20Text%20Reader%2fWriter</span></span><strong></strong></p>
<p>If you are building a WPF, Windows 8&#43; or Windows Phone app with Bing Maps, take a look at this library which provides an easy way to import Well Known Text into Bing Maps:
<a href="http://mapstoolbox.codeplex.com">http://mapstoolbox.codeplex.com</a></p>
