# ASP.net Web API CRUD Operations using WPF Client
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- WPF
- XAML
- ASP.NET MVC
- Visual Studio 2012
## Topics
- AJAX
- ASP.NET
- WPF
- Data Access
- ASP.NET MVC
- WPF Data Binding
- ASP.NET Web API
- Web API
## Updated
- 11/10/2012
## Description

<h2 id="InstallNuGet">Install NuGet Package Manager</h2>
<p><span style="font-size:small">NuGet Package Manager is the easiest way to add the Web API Client library to a project. If you do not have NuGet Package Manager already installed, install it as follows.</span></p>
<ol>
<li><span style="font-size:small">Start Visual Studio.</span> </li><li><span style="font-size:small">From the&nbsp;<strong>Tools</strong>&nbsp;menu, select&nbsp;<strong>Extensions and Updates</strong>.</span>
</li><li><span style="font-size:small">In the&nbsp;<strong>Extensions and Updates</strong>&nbsp;dialog, select&nbsp;<strong>Online</strong>.</span>
</li><li><span style="font-size:small">If you don't see &quot;NuGet Package Manager&quot;, type &quot;nuget package manager&quot; in the search box.</span>
</li><li><span style="font-size:small">Select the NuGet Package Manager and click&nbsp;<strong>Download</strong>.</span>
</li><li><span style="font-size:small">After the download completes, you will be prompted to install.</span>
</li><li><span style="font-size:small">After the installation completes, you might be prompted to restart Visual Studio.</span>
</li></ol>
<p><img src="-webapi_selfhost03.png?cdn_id=2012-10-31-001" alt=""></p>
<h2 id="InstallClientLib">Install the Web API Client Libraries</h2>
<p><span style="font-size:small">After NuGet Package Manager is installed, add the Web API Client Libraries package to your project.</span></p>
<ol>
<li><span style="font-size:small">From the&nbsp;<strong>Tools</strong>&nbsp;menu, select&nbsp;<strong>Library Package Manager</strong>.&nbsp;<em>Note</em>: If do you not see this menu item, make sure that NuGet Package Manager installed correctly.</span>
</li><li><span style="font-size:small">Select&nbsp;<strong>Manage NuGet Packages for Solution...</strong></span>
</li><li><span style="font-size:small">In the&nbsp;<strong>Manage NugGet Packages</strong>&nbsp;dialog, select&nbsp;<strong>Online</strong>.</span>
</li><li><span style="font-size:small">In the search box, type &quot;Microsoft.AspNet.WebApi.Client&quot;.</span>
</li><li><span style="font-size:small">Select the ASP.NET Web API Self Host package and click&nbsp;<strong>Install</strong>.</span>
</li><li><span style="font-size:small">After the package installs, click&nbsp;<strong>Close</strong>&nbsp;to close the dialog.</span>
</li></ol>
<p><img src="-httpclient09.png?cdn_id=2012-10-31-001" alt=""></p>
<p><em>&nbsp;&nbsp;</em></p>
<h2>Asynchronous Calls</h2>
<p><span style="font-size:small"><strong>HttpClient</strong>&nbsp;is designed to be non-blocking. Potentially long-running operations are implemented as asynchonrous methods, such as&nbsp;<strong>GetAsync</strong>&nbsp;and&nbsp;<strong>PostAsync</strong>. These
 methods return without waiting for the operation to complete.&nbsp;The asynchronous methods of&nbsp;<strong>HttpClient</strong>&nbsp;return&nbsp;<strong>Task</strong>&nbsp;objects that represent the asynchronous operation.</span></p>
<h2>Code: C# (Get a Student in WPF from Web API ASP.net)</h2>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//on&nbsp;button&nbsp;click&nbsp;call&nbsp;Web&nbsp;api&nbsp;Get&nbsp;by&nbsp;ID&nbsp;method</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;btnGetStudent_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
<span class="cs__com">//Initialize&nbsp;HTTP&nbsp;Client</span>&nbsp;
&nbsp;
HttpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
client.BaseAddress&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;http://localhost:60792&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.DefaultRequestHeaders.Accept.Add(<span class="cs__keyword">new</span>&nbsp;MediaTypeWithQualityHeaderValue(<span class="cs__string">&quot;application/json&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;response&nbsp;=&nbsp;await&nbsp;client.GetAsync(<span class="cs__string">&quot;/api/student/&quot;</span>&nbsp;&#43;&nbsp;txtID.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.EnsureSuccessStatusCode();&nbsp;<span class="cs__com">//&nbsp;Throw&nbsp;on&nbsp;error&nbsp;code.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;students&nbsp;=&nbsp;await&nbsp;response.Content.ReadAsAsync&lt;Student&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentDetailsPanel.Visibility&nbsp;=&nbsp;Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentDetailsPanel.DataContext&nbsp;=&nbsp;students;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Student&nbsp;not&nbsp;Found&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p></p>
<h2>Code: C# (Post a Students from WPF to Web API ASP.net)</h2>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Post&nbsp;a&nbsp;Student</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;btnNewStudent_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
<span class="cs__com">//Initialize&nbsp;HTTP&nbsp;Client</span>&nbsp;
HttpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
client.BaseAddress&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;http://localhost:60792&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.DefaultRequestHeaders.Accept.Add(<span class="cs__keyword">new</span>&nbsp;MediaTypeWithQualityHeaderValue(<span class="cs__string">&quot;application/json&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;student&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Student()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name&nbsp;=&nbsp;txtStudentName.Text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;id&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(txtStudentID.Text),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gender&nbsp;=&nbsp;cbxGender.SelectedItem.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;age&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(txtAge.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;client.PostAsJsonAsync(<span class="cs__string">&quot;/api/student/&quot;</span>,&nbsp;student);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.EnsureSuccessStatusCode();&nbsp;<span class="cs__com">//&nbsp;Throw&nbsp;on&nbsp;error&nbsp;code.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Student&nbsp;Added&nbsp;Successfully&quot;</span>,&nbsp;<span class="cs__string">&quot;Result&quot;</span>,&nbsp;MessageBoxButton.OK,&nbsp;MessageBoxImage.Information);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentsListView.ItemsSource&nbsp;=&nbsp;await&nbsp;GetAllStudents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentsListView.ScrollIntoView(studentsListView.ItemContainerGenerator.Items[studentsListView.Items.Count&nbsp;-&nbsp;<span class="cs__number">1</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Student&nbsp;not&nbsp;Added,&nbsp;May&nbsp;be&nbsp;due&nbsp;to&nbsp;Duplicate&nbsp;ID&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;Screenshot of WPF Application:</h1>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="70423" src="70423-output.png" alt="" width="525" height="500"></div>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
