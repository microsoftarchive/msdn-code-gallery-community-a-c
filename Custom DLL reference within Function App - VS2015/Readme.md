# Custom DLL reference within Function App - VS2015
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Azure Functions
## Topics
- Azure FunctionApp
## Updated
- 08/29/2017
## Description

<h1>Introduction</h1>
<p><em>When Function App requires external assembly to perform actions following will explain the steps to follow</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>1. Create new VS project with .Net Core Class Library</em></p>
<p><em>2. Add logic to perform an action within the librabry class and build it with net462 compatible framework&nbsp;</em></p>
<p><em>3. Create a new project AzureFunction, from Cloud Templates</em></p>
<p><em>4. Right click add &quot;New Azure Function&quot;, select required filter (Manual trigger in this example)</em></p>
<p><em>5. In run.csx file add reference #r &lt;yourLibraryProjectName&gt;.dll, add function logic which uses methods from the library</em></p>
<p><em>6. In project.json file of the Function, add dependency &quot;System.Runtime&quot;: &quot;4.1.0&quot; for framework net46</em></p>
<p><em>7. Right click and publish the app to Azure</em></p>
<p><em>8. Upon successful deployment, Open the function (function <em>created &nbsp;above</em>) in the Azure Portal and on the right side browse to the verify files run.csx, function.json, project.json, project.json.lock exist</em></p>
<p><em>9. Browse to the root function app container --&gt; All Settings --&gt; Development tools --&gt; Console</em></p>
<p><em>10. Console path begins at &quot;D:\home\site\wwwroot&quot;, browse to your function : cd &lt;yourfunctionname&gt;. DIR helps in copying the name correctly</em></p>
<p><em>11. Delete project.json.lock file : rm project.json.lock</em></p>
<p><em>12. Create bin folder : mkdir bin</em></p>
<p><em>13. Close editor and g</em><em>o back to the Function --&gt; View Files. Now bin folder should be visible</em></p>
<p><em>14. Due to Function App known bug, manually upload System.Runtime.dll (4.1.0), custom library dll in the bin folder</em></p>
<p><em>15. Restart the FunctionApp</em></p>
<p>&nbsp;</p>
<h1>Sample</h1>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">#r &quot;SampleToSupportFunction.dll&quot;

using System;
using System.Xml;
using System.Text;
using System.IO;
using SampleToSupportFunction;

public static void Run(string input, TraceWriter log)
{
    log.Info($&quot;C# Timer trigger function executed at: {DateTime.Now}&quot;);
    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(&quot;Eastern Standard Time&quot;);
    var timeToString = Utility.GetDateBytimeZone(easternZone);
    log.Info($&quot;Time is : {timeToString}&quot;);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__preproc">#r&nbsp;&quot;SampleToSupportFunction.dll</span>&quot;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Xml;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SampleToSupportFunction;&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Run(<span class="cs__keyword">string</span>&nbsp;input,&nbsp;TraceWriter&nbsp;log)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;log.Info($<span class="cs__string">&quot;C#&nbsp;Timer&nbsp;trigger&nbsp;function&nbsp;executed&nbsp;at:&nbsp;{DateTime.Now}&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TimeZoneInfo&nbsp;easternZone&nbsp;=&nbsp;TimeZoneInfo.FindSystemTimeZoneById(<span class="cs__string">&quot;Eastern&nbsp;Standard&nbsp;Time&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;timeToString&nbsp;=&nbsp;Utility.GetDateBytimeZone(easternZone);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;log.Info($<span class="cs__string">&quot;Time&nbsp;is&nbsp;:&nbsp;{timeToString}&quot;</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>NetCore Project: SampleToSupportFunction, class&nbsp;</em><em>Utility.cs</em>
</li><li><em>AzureFunction Project: SampleFunction, run.csx<br>
</em></li></ul>
<h1>More Information</h1>
<p>Azure Function:&nbsp;https://azure.microsoft.com/en-us/services/functions/</p>
<p><em>Bug Info: https://github.com/dotnet/cli/issues/4171</em></p>
