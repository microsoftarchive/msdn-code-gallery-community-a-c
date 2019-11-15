# AngularJS Master-Detail Page for Apache Cordova
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- Javascript
- HTML5
- Visual Studio 2013
- AngularJS
- Windows Phone 8.1
## Topics
- Navigation
- Cross Platform Code Reuse
- Multi-Device Hybrid Apps
- Apache Cordvoa Tooling
## Updated
- 07/16/2015
## Description

<h1>Introduction</h1>
<p>The AngularJS Master-Detail Sample shows you how to create a cross-platform, multi-page&nbsp;app using&nbsp;Visual Studio Tools&nbsp;for Apache Cordova&nbsp;(CTP3) in Visual Studio 2013 Update 4. The extension enables the creation of cross-platform apps
 using Apache Cordova that can run on Android, iOS, and Windows.</p>
<h1>Description</h1>
<p>The sample creates a master-detail list using AngularJS in a Multi-Device Hybrid App. This sample demonstrates the following:</p>
<ul>
<li>AngularJS routing for multi-page apps using the routing module (ngRoute) and partial pages.
</li><li>MVC design using the AngularJS controller (ngController) and AngularJS templates.
</li><li>Data binding (ngModel). </li><li>Simple search function using the AngularJS filter. </li><li>JSON data files&nbsp;that provide the data model. </li><li>Page animations using CSS3 <strong>@keyframes </strong>rules. </li></ul>
<p>This sample demonstrates flexible UI design techniques for building cross-platform UI. (For a sample that uses Ionic for cross-platform UI, MVC, and AngularJS routing, see&nbsp;<a href="https://code.msdn.microsoft.com/Ionic-SideMenu-Starter-8e905eb5">Ionic
 SideMenu Template for Cordova</a>.) Flexible design techniques present in the Master-Detail sample include:</p>
<ul>
<li>Use of CSS3 FlexBox </li><li>Use of&nbsp;<strong>@media&nbsp;</strong>queries to handle different display sizes and orientations
</li></ul>
<p>The app creates a two-column master-detail view. The master-list appears in the left column. When you select a link, the AngularJS routing module loads a partial page (a separate HTML file) into the right column. The master list and the details page are
 populated with data from JSON files using declarative binding in an AngularJS template (in index.html).</p>
<p>Although AngularJS also includes an animation module, I created page animations directly using CSS3
<strong>@keyframes</strong>. (In many cases, I find that working directly with CSS3 is quicker and more flexible than using more indirect methods.)</p>
<p>The sample uses only Web technologies and does not use any native API access via plugins. The sample has been tested on:</p>
<ul>
<li>Android (Visuall Studio Emulator for Android, available in Visual Studio 2015 Preview)
</li><li>iOS (Ripple and iOS Simulator) </li><li>Windows 8.1 </li><li>Windows Phone 8.1 </li></ul>
<h1>Updates</h1>
<p>On 9/30/14, updated UI.</p>
<ul>
<li>Reworked CSS to&nbsp;support dynamic switching between horizontal scrolling master-list at the top (portrait mode) and a vertical scrolling master-list on the left (landscape mode).
</li><li>Made UI more flexible for use as an x-plat template (more use of CSS3 FlexBox, less hardcoded values).
<br>
<strong>Note</strong>: On Android &lt;4.4, vh and vw units are not supported, so min-height and min-width&nbsp;properties are set. For iOS,&nbsp;vh and vw&nbsp;units are partially supported, and a special JS handler is implemented. For more info, see
<a href="http://caniuse.com/#feat=viewport-units">http://caniuse.com/#feat=viewport-units</a>
</li><li>Streamlined CSS styles and <strong>@media </strong>queries, and eliminated platform overrides in CSS (made it more generic).
</li></ul>
<p>On 11/17/14, uploaded a new version&nbsp;built with Visual Studio 2015 Preview (not compatible with VS 2015 RC). It should be fully compatible with Visual Studio 2013 Update 4.</p>
<ul>
<li>Note: due to a Cordova issue with the temporary key, described in <a href="http://msopentech.com/blog/2014/11/11/cordova-certificate-issue-were-working-on-it/">
this page</a>, the /res/native/windows folder contains CordovaApp_TemporayKey.pfx. Cordova will be releasing a fix to this issue. If you are using VS 2013 Update 4, move this file to /res/cert/windows8.
</li></ul>
<p>On 11/18/14, UX work; replaced standard links with buttons. Buttons now load the partial pages into the view using the routing module.</p>
<h1>Customizing the sample for other multi-page apps</h1>
<p>The &lt;div <strong>ng-view</strong>&gt;&lt;/div&gt; element in index.html specifies where partial pages get loaded in the DOM tree. If you want to create an app that loads partial pages as full-screen pages (without nesting inside other DOM elements, as
 in this sample),&nbsp;re-write the markup in index.html like this:</p>
<pre>&lt;body <strong>ng-app</strong>=&quot;angularApp&quot;&gt;</pre>
<pre>&nbsp;&nbsp;&nbsp; &lt;div <strong>ng-view</strong>&gt;&lt;/div&gt;</pre>
<pre>&nbsp;&nbsp;&nbsp; &lt;!-- script refs --&gt;<br></pre>
<pre>&lt;/body&gt;</pre>
<p>You will also need to&nbsp;modify app.js and controllers.js, respectively,&nbsp;to support any new application routes and controllers.</p>
<h1>Requirements</h1>
<ul>
<li>Visual Studio 2013 Update&nbsp;4 (Professional, Ultimate, or Premium) </li><li>The Visual Studio Tools for Apache Cordova extension for Visual Studio (a separate download in VS 2013 Update 4).
</li><li>Specific platforms have other requirements. For more info, see <strong>Install the Multi-Device Hybrid Apps Extension
</strong>(<a href="http://msdn.microsoft.com/library/dn757054.aspx">http://msdn.microsoft.com/library/dn757054.aspx</a>).
</li></ul>
<p>Note: The sample for use with Visual Studio 2015 RC or later is on github:&nbsp;<a href="https://github.com/Mikejo5001/angularjs-navigation-master-detail">https://github.com/Mikejo5001/angularjs-navigation-master-detail</a></p>
<h1>Build and Run the app</h1>
<ol>
<li>After downloading the .zip, rename the .zip to remove spaces in the filename, and then move the .zip to a folder that does not contain spaces (this resolves a Cordova&nbsp;issue with spaces in the path name for Windows build targets).
</li><li>Extract the .zip file. </li><li>In Visual Studio, open the solution file (.sln) for the project. </li><li>If you are targeting Windows and are using VS 2013 Update 4, move the CordovaApp_TemporaryKey.pfx file to /res/cert/windows8. (For more info, see Updates section for 11/17/14).
</li><li>Press F5 to build and deploy the app.<br>
The first time you build the app in VS, a PowerShell script referenced in the .jsproj file will download the required AngularJS framework files.
<br>
<strong>Note:</strong> If the framework files (in /scripts/frameworks/) do not download, you will need to unblock the PowerShell script from running. For more info, see this post (<a href="http://stackoverflow.com/questions/24410962/winjs-sample-code-js-file-missing">http://stackoverflow.com/questions/24410962/winjs-sample-code-js-file-missing</a>).
</li><li>Fore more info on using the extension, see <strong>Getting Started with Multi-Device Hybrid Apps
</strong>(<a href="http://msdn.microsoft.com/library/dn771545.aspx">http://msdn.microsoft.com/library/dn771545.aspx</a>).
</li></ol>
<p>The following screenshot shows the sample app running in the Ripple Emulator (Nexus [Galaxy]), in landscape orientation.</p>
<p><img id="126309" src="http://i1.code.msdn.s-msft.com/windowsapps/angularjs-detail-sample-7a409e5e/image/file/126309/1/angularjs-master-detail-android.png" alt="" width="612" height="323"></p>
<p>&nbsp;</p>
<p>The next screenshot shows the sample app running in portrait mode (Nexus [Galaxy]).</p>
<p>&nbsp;</p>
<p><img id="126310" src="http://i1.code.msdn.s-msft.com/windowsapps/angularjs-detail-sample-7a409e5e/image/file/126310/1/angularjs-master-detail-android-landscape.png" alt="" width="319" height="613"></p>
