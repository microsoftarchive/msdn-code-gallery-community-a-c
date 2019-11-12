# CRUD Operation With JSON File Data In C#
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- JSON
- Json.NET
## Topics
- Performance
- WebBrowser
## Updated
- 08/17/2017
## Description

<h1>Introduction</h1>
<p><em>This article will demonstrate how to implement CRUD functionality with JSON file in a project using C# code.&nbsp;<br>
As we know, JSON [JavaScript Object Notation] is a subset of JavaScript and is very lightweight data exchange format. Sometimes, we want to use such type of storage in a project from where we can access data very quickly. We do not want to go with creating
 connection and check connection availability and do not want to be dependent on another server because it&rsquo;s time-consuming.</em></p>
<p><em><br>
Just for example, if a project has no database connectivity and would like to store single user information, here we can use a JSON file to store such data. Therefore, this article gives you an idea how you can perform CRUD operations on JSON files and use
 JSON files as a database.<br>
Implementation<br>
<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><em>For this demonstration, we will use the following JSON format. So, create a console application in Visual Studio using C# and add a JSON file named &quot;user.json&quot;. &nbsp;Add the following line of code inside the user.json file so that we can perform
 CRUD operation on this.&nbsp;<br>
Therefore, this JSON file contains user information like user id, name, address, experiences etc. The next code will show you the process to selecting user data, updating the existing data, inserting the new experience, and deleting the user experience.&nbsp;</em></em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><em><span>JavaScript</span></em></em></div>
<div class="pluginLinkHolder"><em><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></em></div>
<em><em><span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;id&quot;</span>:&nbsp;<span class="js__num">123</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;name&quot;</span>:&nbsp;<span class="js__string">&quot;Mukesh&nbsp;Kumar&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;address&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;street&quot;</span>:&nbsp;<span class="js__string">&quot;El&nbsp;Camino&nbsp;Real&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;city&quot;</span>:&nbsp;<span class="js__string">&quot;New&nbsp;Delhi&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;zipcode&quot;</span>:&nbsp;<span class="js__num">95014</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;experiences&quot;</span>:&nbsp;[&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;companyid&quot;</span>:&nbsp;<span class="js__num">77</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;companyname&quot;</span>:&nbsp;<span class="js__string">&quot;Mind&nbsp;Tree&nbsp;LTD&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;companyid&quot;</span>:&nbsp;<span class="js__num">89</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;companyname&quot;</span>:&nbsp;<span class="js__string">&quot;TCS&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;companyid&quot;</span>:&nbsp;<span class="js__num">22</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;companyname&quot;</span>:&nbsp;<span class="js__string">&quot;Hello&nbsp;World&nbsp;LTD&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;],&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;phoneNumber&quot;</span>:&nbsp;<span class="js__num">9988664422</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;role&quot;</span>:&nbsp;<span class="js__string">&quot;Developer&quot;</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;</pre>
</div>
</em></em></div>
</div>
<div class="endscriptcode"><em><em>Add the following namespace to access Newtonsoft.Json methods and properties.</em></em></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><em><em><em><em>
<div class="preview">
<pre class="js"><strong>using&nbsp;Newtonsoft.Json.Linq;&nbsp;</strong></pre>
</div>
</em></em></em></em></div>
<div class="endscriptcode">
<div class="endscriptcode"><em><em>&nbsp;</em></em></div>
</div>
<div class="endscriptcode"><em><em>First, we will see how can we read the JSON file and access all data points from that JSON file. After reading file data, first, parse the JSON data using JObject.Parse, which will parse and return JObject. Once you get
 JObject, which is nothing but an array, we can directly access all data points to pass key.<br>
To access the nested data points, we need to iterate on JObject or JArray. Following is the whole code to access all the data points from existing JSON file.&nbsp;</em></em></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;GetUserDetails()&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;json&nbsp;=&nbsp;File.ReadAllText(jsonFile);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;jObject&nbsp;=&nbsp;JObject.Parse(json);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(jObject&nbsp;!=&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;ID&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;jObject[<span class="js__string">&quot;id&quot;</span>].ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Name&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;jObject[<span class="js__string">&quot;name&quot;</span>].ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;address&nbsp;=&nbsp;jObject[<span class="js__string">&quot;address&quot;</span>];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Street&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;address[<span class="js__string">&quot;street&quot;</span>].ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;City&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;address[<span class="js__string">&quot;city&quot;</span>].ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Zipcode&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;address[<span class="js__string">&quot;zipcode&quot;</span>]);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JArray&nbsp;experiencesArrary&nbsp;=&nbsp;(JArray)jObject[<span class="js__string">&quot;experiences&quot;</span>];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(experiencesArrary&nbsp;!=&nbsp;null)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;item&nbsp;<span class="js__operator">in</span>&nbsp;experiencesArrary)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;company&nbsp;Id&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;item[<span class="js__string">&quot;companyid&quot;</span>]);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;company&nbsp;Name&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;item[<span class="js__string">&quot;companyname&quot;</span>].ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Phone&nbsp;Number&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;jObject[<span class="js__string">&quot;phoneNumber&quot;</span>].ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Role&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;jObject[<span class="js__string">&quot;role&quot;</span>].ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - JsonAddAndUpdate.zip</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ..</em></p>
<p><em><a href="http://www.c-sharpcorner.com/article/crud-operation-with-json-file-data-in-c-sharp/">http://www.c-sharpcorner.com/article/crud-operation-with-json-file-data-in-c-sharp/</a><br>
</em></p>
