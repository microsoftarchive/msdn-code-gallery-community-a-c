# CRUD Operation in Elasticsearch using C# and NEST
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- JSON
- ES
- Elasticsearch
## Topics
- C#
- JSON
- ES
- Elasticsearch
## Updated
- 08/08/2016
## Description

<h2>Introduction</h2>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">In
 our previous artilce. </span></p>
<ul>
<li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12.9px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; color:#0076a3; background-color:#ffffff"><a href="http://social.technet.microsoft.com/wiki/contents/articles/34476.searching-data-in-elasticsearch-using-c.aspx" target="_blank" style="margin:0px; padding:0px; outline:0px; border:currentcolor; color:#0076a3; line-height:16.12px; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; list-style-type:none; background-color:#ffffff">Searching
 data in Elasticsearch using C# </a></span></li></ul>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">We
 have seen in details about Elasticsearch, how to configure and perform a search operation.
</span></p>
<p>In this article we will see how to do CRUD (Create/Read/Update and Delete) operation in Elasticsearch using C# and NEST (.NET client for Elasticsearch). The example is made of C# use under WinForm. This article is specially focusing on newcomers and anyone
 new wants to learn or thinking of using ES in their .NET program. This sample illustrates a way to let user to perform CRUD operation in Elasticsearch from their WinForm app.</p>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">In
 this article we are going to see how we can, </span></p>
<ul>
<li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">Create
 a document in Elasticsearch </span></li><li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">Setup
 our development enviroment </span></li><li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">How
 we can Insert data to ES </span></li><li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">How
 we can Search data in ES </span></li><li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">How
 we can Update data in ES </span></li><li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">How
 we can Delete data in ES </span></li></ul>
<h2>Getting Started</h2>
<p><img id="157969" src="157969-se003.png" alt="" width="800" height="388"></p>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">Before
 we start writing code we must to reference NEST in our project, that of making libraries accessible to the solution.</span></p>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">&nbsp;</span><span style="font-size:1.17em"><strong>Referencing
 NEST</strong></span></p>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">As
 discussed in the previous article, first we need to download the .NET client for Elasticsearch which is
<a href="https://github.com/elastic/elasticsearch-net" target="_blank" style="margin:0px; padding:0px; outline:0px; border:currentcolor; color:#0076a3; line-height:16.12px; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; list-style-type:none; background-color:#ffffff">
NEST</a>. To reference NEST within our project,that is make its libraries accessible to the solution, use the Nuget Package Manager Console Window to run the below command to install the NEST client
</span></p>
<ul>
<li><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">PM&gt;
 Install-Package NEST </span></li></ul>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">When
 finished, we will see project References included the references those related to NEST.
<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/8715.devSetup01.png"><img src="http://social.technet.microsoft.com/wiki/resized-image.ashx/__size/350x0/__key/communityserver-wikis-components-files/00-00-00-00-05/8715.devSetup01.png" alt="" style="border-width:0px; border-style:solid"></a><br>
</span></p>
<p><span style="margin:0px; padding:0px; outline:0px; line-height:16.12px; font-size:12px; font-style:inherit; font-weight:inherit; list-style-type:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; background-color:#ffffff">We
 are now ready to use the Elasticsearch NEST client regarding the development of our CRUD.
</span></p>
<h2>Sample Data</h2>
<p>You could use the attached data in the project folder and do a bulk insert into ES or you can use your own data. If you use you own data please change the index name in the GetDocument.cs code to your index name and type to your type name. Also you need
 to update the response model in DocumentAttributes.cs and UpdateDocumentAttributes.cs
<br>
<br>
<br>
Sample code will be look like as follows</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DataTable&nbsp;getAllDocument()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;dataTable&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable(<span class="cs__string">&quot;character&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataTable.Columns.Add(<span class="cs__string">&quot;ID&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataTable.Columns.Add(<span class="cs__string">&quot;Name&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataTable.Columns.Add(<span class="cs__string">&quot;Original&nbsp;Voice&nbsp;Actor&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataTable.Columns.Add(<span class="cs__string">&quot;Animated&nbsp;Debut&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;ConnectionToES.EsClient().Search&lt;DocumentAttributes&gt;(s&nbsp;=&gt;&nbsp;s&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Index(<span class="cs__string">&quot;disney&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Type(<span class="cs__string">&quot;character&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.From(<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Size(<span class="cs__number">1000</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Query(q&nbsp;=&gt;&nbsp;q.MatchAll()));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;hit&nbsp;<span class="cs__keyword">in</span>&nbsp;response.Hits)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataTable.Rows.Add(hit.Id.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hit.Source.name.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hit.Source.original_voice_actor.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hit.Source.animated_debut.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;dataTable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Technicalities:</h2>
<p>This application performs CRUD operation in Elasticsearch. Necessary reference need to add into the project solution and data need to store in Elasticsearch.</p>
<h2>Note</h2>
<ul>
<li>Article detailed the creation of this project: <a href="http://social.technet.microsoft.com/wiki/contents/articles/35095.crud-operation-in-elasticsearch-using-c-and-nest.aspx" target="_blank" style="margin:0px; padding:0px; outline:0px; border:currentcolor; color:#0076a3; line-height:16.12px; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:12px; list-style-type:none; background-color:#ffffff">
CRUD Operation in Elasticsearch using C# and NEST </a></li><li>For more about query DSL please see this page <a href="https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl.html" target="_blank">
Query DSL </a></li><li>More about Elasticsearch visit <a href="https://www.elastic.co/" target="_blank">
website </a></li></ul>
