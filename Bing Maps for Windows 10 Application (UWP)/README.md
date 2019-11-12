# Bing Maps for Windows 10 Application (UWP)
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Bing Maps
- Windows Phone
- universal windows app
- Windows 10
## Topics
- C#
- Bing Maps
- Windows Phone
- universal app
- Windows 10
## Updated
- 01/05/2016
## Description

<h1>Introduction</h1>
<div id="pastingspan1" style="text-align:justify">After beginning your universal app with creating your wonderful
<a href="https://code.msdn.microsoft.com/Splash-Screen-in-Universal-42c0b57a">splashcreen</a>, the MapControl is now part of the Windows.UI.Xaml.Controls namespace. If you've created a previous application that integrates with the old Bing Maps control, you'll
 find the new implementation minimal since the changes are only slight.</div>
<h1><span>Building the Sample</span></h1>
<p>1- First of all you have to navigate to your <a href="https://dev.windows.com/overview">
developer dashboard</a> in the Windows Dev Center.<strong>&nbsp;</strong></p>
<p>2- If you haven't yet, <a href="https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj657967.aspx">
reserve your app's name</a>.</p>
<p><img id="146660" src="146660-1.png" alt="" width="749" height="339"><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>3- Look for the <strong>Services</strong> section in the left navigation menu, and expand it to show the
<strong>Maps</strong> page.</p>
<p><img id="146661" src="146661-2.png" alt="" width="831" height="388"></p>
<p>4- Click <strong>Get token</strong>, the <strong>ApplicationID</strong> and <strong>
AuthenticationToken</strong> will be generated and will appear on this page.<em><br>
</em></p>
<p><em><img id="146662" src="146662-3.png" alt="" width="826" height="410"></em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Maps</span>:MapControl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Map&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">MapServiceToken</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;your&nbsp;mapservicetoken&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ZoomInteractionMode</span>=<span class="xaml__attr_value">&quot;GestureAndControl&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">LandmarksVisible</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">IsRightTapEnabled</span>=<span class="xaml__attr_value">&quot;true&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<h1><img id="146663" src="146663-4.png" alt="" width="1283" height="955"></h1>
<p style="text-align:justify">There are some major improvements with the updates to the universal app model that will see more controls across WinRT being unified so that they can be used across multiple devices and multiple platforms.</p>
<p style="text-align:justify">This makes it much easier for developers to create maps within their applications in an MVVM friendly way with the freedom to customise them as they wish.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p style="text-align:justify">Let me know in the comments below if you've had a go with the Windows 10 SDK and what you think of some of the changes you've found!
<strong>&nbsp;</strong><em>&nbsp;</em></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainPage.xaml&nbsp;- summary for this source code file.</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information , you can contact me through my website : <a href="http://www.hjaiejchourouk.com">
hjaiejchourouk.com/</a></em></p>
