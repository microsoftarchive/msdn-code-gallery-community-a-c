# Creating a “real life” CRUD API App for DocumentDB
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Azure API App
- Azure DocumentDB
## Topics
- Web API
- DocumentDB
- Azure API App
## Updated
- 01/11/2016
## Description

<h1>Introduction</h1>
<p><em>DocumentDB is a highly scalable, NoSQL document database service in Azure. On azure.microsoft.com you can find a lot information about DocumentDB. For example how you can create a DocumentDB or how to build your first app. But in a &ldquo;real life&rdquo;
 scenario (for example in project for a customer) this information is probably not enough or even relevant because the samples are often console applications and maybe you want to create a Mobile or a Web App. Often you also need to modify the data from the
 client or add meta data to it. For example a creation date or an order status. Therefore its good practice to create a custom Web API to handle the inserts, updates, deletes and data retrievals. There you have complete control on the object that is sent by
 the client. But how do you do that if you want to store the data in DocumentDB?&nbsp; In that case it can take quite some time to find the additional info that you need. Therefore I created an API App to show how you can insert, update, delete or get a customer
 order and how to add additional (meta data) to the orders! The sample can easily&nbsp;be modified for other type of objects.</em></p>
<p><em>&nbsp;</em></p>
<p><em>The following methods are implemented in the API App:</em></p>
<p><em>- Create an Order&nbsp; <br>
- Read an Order by Id<br>
- Update an Order<br>
- Delete an order <br>
<br>
<img id="147209" src="https://i1.code.msdn.s-msft.com/creating-a-real-life-crud-96cc034e/image/file/147209/1/swagger.png" alt="" width="602" height="291"></em></p>
<h1><em>&nbsp;</em></h1>
<h4>Create an Order</h4>
<p>When an object is stored in DocumentDB is automatically a guid created for the object. This guid is sent back to client and can be used to retrieve the order.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;CreateOrder(ClientOrder&nbsp;order)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;id&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;a&nbsp;server&nbsp;order&nbsp;with&nbsp;extra&nbsp;properties</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServerOrder&nbsp;s&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServerOrder();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;s.customer&nbsp;=&nbsp;order.customer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;s.item&nbsp;=&nbsp;order.item;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Add&nbsp;meta&nbsp;data&nbsp;to&nbsp;the&nbsp;order</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;s.OrderStatus&nbsp;=&nbsp;<span class="cs__string">&quot;in&nbsp;progress&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;s.CreationDate&nbsp;=&nbsp;DateTime.UtcNow;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;a&nbsp;Document&nbsp;client</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DocumentClient(<span class="cs__keyword">new</span>&nbsp;Uri(endpointUrl),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;authorizationKey))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pathLink&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;dbs/{0}/colls/{1}&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;databaseId,&nbsp;collectionId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResourceResponse&lt;Document&gt;&nbsp;doc&nbsp;=&nbsp;await&nbsp;client.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateDocumentAsync(pathLink,&nbsp;s);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Return&nbsp;the&nbsp;created&nbsp;id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;id&nbsp;=&nbsp;doc.Resource.Id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;id;&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information, see the blogpost: <a href="http://www.ithero.nl/post/2016/01/11/Creating-a-real-life-CRUD-API-App-for-DocumentDB.aspx">
Creating a &ldquo;real life&rdquo; CRUD API App for DocumentDB</a></em></p>
