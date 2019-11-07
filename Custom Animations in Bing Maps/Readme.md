# Custom Animations in Bing Maps
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- Javascript
- Visual Basic .NET
- Bing Maps
- HTML5
- Windows Runtime
- Windows 8
- Windows Store app
- Windows 8.1
## Topics
- Animation
- Graphics
- C#
- XAML
- Javascript
- Visual Basic .NET
- Bing Maps
- Animations
- XAML Animation
- Windows Store app
## Updated
- 03/12/2017
## Description

<h1>Introduction</h1>
<p>Bing Maps is a very powerful mapping platform that is often used for creating engaging user experiences. The fluid interactive maps make for a great canvas when visualizing location based data. In this code sample we are going to take a look at how to make
 the user experience a little more engaging by adding custom animations that can be used in both Bing Maps V7 and JavScript based Windows 8 Store apps.&nbsp;</p>
<p>This code sample is part of a series of blog posts:</p>
<ul>
<li><a href="http://blogs.bing.com/maps/2014/08/07/bring-your-maps-to-life-creating-animations-with-bing-maps-javascript/">Bring Your Maps to Life: Creating Animations with Bing Maps (JavaScript)</a>
</li><li><a href="http://blogs.bing.com/maps/2014/09/25/part-2-bring-your-maps-to-life-creating-animations-with-bing-maps-net/">Part 2 &ndash; Bring your maps to life: Creating animations with Bing Maps (.NET)</a>
</li></ul>
<h1><span>Building the Sample</span></h1>
<p>To run the samples you must install the <a href="http://visualstudiogallery.msdn.microsoft.com/224eb93a-ebc4-46ba-9be7-90ee777ad9e1">
Bing Maps SDK for Windows Store apps</a>&nbsp;and get a <a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx">
Bing Maps key</a> for Windows Store apps. You must also have Windows 8.1 and Visual Studio 2013.</p>
<p>Any of the code samples that use Bing Maps will have a string, &ldquo;YOUR_BING_MAPS_KEY&rdquo;, in the code where you will need to specify your Bing Maps key.</p>
<p>If you are using Bing Maps in a C# or Visual Basic app you will need to perform the following steps for your app project to work correctly with Bing Maps.</p>
<ul>
<li>Add a reference to&nbsp;Bing Maps SDK for C#, C&#43;&#43;, or Visual Basic if the reference isn&rsquo;t already there.
</li><li>Set the&nbsp;Active solution platform&nbsp;in Visual Studio to one of the following; ARM,&nbsp;x86&nbsp;or&nbsp;x64
</li><li>Add a reference to&nbsp;Microsoft Visual C&#43;&#43; Runtime Package. &nbsp;
<ul>
</ul>
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This code sample shows how to create several different types of animations. Here is are some fo the animations that are included:</p>
<table>
<tbody>
<tr>
<td>Scaling Pushpin when hovered</td>
<td>&nbsp;<img id="119862" src="119862-scalingpin.gif" alt="" width="94" height="110"></td>
</tr>
<tr>
<td>Drop a Pushpin</td>
<td><img id="119863" src="119863-droppin.gif" alt="" width="60" height="179"></td>
</tr>
<tr>
<td>Bounce a Pushpin</td>
<td><img id="119866" src="119866-bouncepin.gif" alt="" width="60" height="179"><br>
</td>
</tr>
<tr>
<td>Animate Pushpin along a straight line path</td>
<td><img id="119865" src="119865-pinonstraightpath.gif" alt="" width="237" height="90"></td>
</tr>
<tr>
<td>Animate Pushpin along a geodesic path</td>
<td><img id="119867" src="119867-pinongeodesicpath.gif" alt="" width="237" height="89"></td>
</tr>
<tr>
<td>Animate the drawing of a straight line path</td>
<td><img id="119868" src="119868-drawstraightpath.gif" alt="" width="231" height="67"></td>
</tr>
<tr>
<td>Animate the drawing of a geodesic path</td>
<td><img id="119869" src="119869-drawgeodesicpath.gif" alt="" width="228" height="80"></td>
</tr>
</tbody>
</table>
