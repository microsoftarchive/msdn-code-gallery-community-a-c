# Azure Web Role and Worker Role Communication using Queues
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Microsoft Azure
- Worker Role
- Windows Azure Cloud Services
- Web Role
- Windows Azure Storage Queues
- Windows Azure Storage Tables
- Azure Cloud Services
## Topics
- Asynchronous Programming
- Microsoft Azure
- Windows Azure Storage
- How to
- backgroundworker
- Cloud
## Updated
- 05/09/2016
## Description

<h1>Introduction</h1>
<p>This uploaded project is a simple illustration of how a worker role could be triggered by a web role via a queue. &nbsp;The project was inspired by the forum post:
<a href="https://social.msdn.microsoft.com/Forums/azure/en-US/a0bf110b-6dde-42fb-8920-c62c058e328b/worker-role-does-not-start-when-deploying-web-application-on-azure-cloud-service?forum=windowsazuredevelopment">
Worker role does not start when deploying web application on azure cloud service</a>.</p>
<p>The scenario here is a website will provide a user the ability to launch a console application on the worker role virtual machine. &nbsp;In this project, an Azure Queue is used to provide a means of triggering the activity on the worker role. &nbsp;In order
 to show that the activity completed, a message is written to an Azure Table. &nbsp;The architecture is shown below:</p>
<p><img id="152782" src="152782-2016-05-09_15-12-26.jpg" alt="" width="708" height="501"></p>
<p>The project was created using the Visual Studio Cloud Service template and consists of a worker and web role. &nbsp;The web role is MVC and supports two buttons:
<em>Send Message</em> and <em>Clear Message</em>. &nbsp;The site will poll the web server for messages written to an Azure Table. &nbsp;The
<em>Send Message</em>&nbsp;button will cause a message to be written to the queue where the
<em>Clear Message</em>&nbsp;will clear the messages on the page and remove the row in the table.</p>
<p>The worker role repeats the following steps:</p>
<ul>
<li>Reads a message from the queue </li><li>Launches a process on the worker role virtual machine </li><li>Writes the result to the Azure Table </li><li>Deletes the message from the queue </li></ul>
<p><em>Please note the project is just a sample and is not meant to more to provide inspiration than to show a complete solution. &nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p>The project is build using nuget packages so should not require any special steps to get the solution to build.</p>
<p>In order to run the sample project, an Azure Storage and an Azure Cloud Service will need to be created.</p>
<p>The Azure Storage settings will need to be set in the web and worker role. &nbsp;These are hard coded in the methods and can be found by searching for &quot;[key]&quot;. &nbsp;There are four places to update:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">CloudStorageAccount&nbsp;storageAccount&nbsp;=&nbsp;CloudStorageAccount.Parse(<span class="cs__string">&quot;DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The project can be then published to a suitable Azure environment:</div>
<div class="endscriptcode"><img id="152783" src="152783-2016-05-10_15-06-11.jpg" alt="" width="319" height="222"></div>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Web Role</span></p>
<p>The three main methods in the controller to highlight are <em>Clear Messages, Get Message,
</em>and <em>Send Message.</em></p>
<p><strong><em>Clear Message</em></strong></p>
<p><strong><em>&nbsp;</em></strong></p>
<p><strong><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;ClearMessages()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudStorageAccount&nbsp;storageAccount&nbsp;=&nbsp;CloudStorageAccount.Parse(<span class="cs__string">&quot;DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudTableClient&nbsp;tableClient&nbsp;=&nbsp;storageAccount.CreateCloudTableClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudTable&nbsp;table&nbsp;=&nbsp;tableClient.GetTableReference(<span class="cs__string">&quot;mytable&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;table&nbsp;if&nbsp;it&nbsp;doesn't&nbsp;exist.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;table.CreateIfNotExists();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;read&nbsp;the&nbsp;latest&nbsp;messages&nbsp;from&nbsp;the&nbsp;table&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TableOperation&nbsp;retrieveOperation&nbsp;=&nbsp;TableOperation.Retrieve&lt;MyMessages&gt;(<span class="cs__string">&quot;Partition0&quot;</span>,&nbsp;<span class="cs__string">&quot;Row0&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Execute&nbsp;the&nbsp;retrieve&nbsp;operation.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TableResult&nbsp;retrievedResult&nbsp;=&nbsp;table.Execute(retrieveOperation);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(retrievedResult.Result&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableOperation&nbsp;deleteOperation&nbsp;=&nbsp;TableOperation.Delete((MyMessages)retrievedResult.Result);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Execute(deleteOperation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
</em>
<div class="endscriptcode"><em>Get Message</em></div>
</strong>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetMessage()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudStorageAccount&nbsp;storageAccount&nbsp;=&nbsp;CloudStorageAccount.Parse(<span class="cs__string">&quot;DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudTableClient&nbsp;tableClient&nbsp;=&nbsp;storageAccount.CreateCloudTableClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudTable&nbsp;table&nbsp;=&nbsp;tableClient.GetTableReference(<span class="cs__string">&quot;mytable&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;table&nbsp;if&nbsp;it&nbsp;doesn't&nbsp;exist.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;table.CreateIfNotExists();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;read&nbsp;the&nbsp;latest&nbsp;messages&nbsp;from&nbsp;the&nbsp;table&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TableOperation&nbsp;retrieveOperation&nbsp;=&nbsp;TableOperation.Retrieve&lt;MyMessages&gt;(<span class="cs__string">&quot;Partition0&quot;</span>,&nbsp;<span class="cs__string">&quot;Row0&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Execute&nbsp;the&nbsp;retrieve&nbsp;operation.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TableResult&nbsp;retrievedResult&nbsp;=&nbsp;table.Execute(retrieveOperation);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(retrievedResult.Result&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;((MyMessages)retrievedResult.Result).Messages;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Failed&nbsp;to&nbsp;retrieve&nbsp;the&nbsp;messages&quot;</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong><em>Send Message</em></strong></div>
<p>&nbsp;</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SendMessage()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudStorageAccount&nbsp;storageAccount&nbsp;=&nbsp;CloudStorageAccount.Parse(<span class="cs__string">&quot;DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudQueueClient&nbsp;queueClient&nbsp;=&nbsp;storageAccount.CreateCloudQueueClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudQueue&nbsp;queue&nbsp;=&nbsp;queueClient.GetQueueReference(<span class="cs__string">&quot;myqueue&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;queue&nbsp;if&nbsp;it&nbsp;doesn't&nbsp;already&nbsp;exist</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;queue.CreateIfNotExists();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;send&nbsp;a&nbsp;message&nbsp;to&nbsp;the&nbsp;queue</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudQueueMessage&nbsp;message&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CloudQueueMessage(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Sending&nbsp;at&nbsp;{0}&nbsp;from&nbsp;{1}&quot;</span>,&nbsp;DateTime.Now,&nbsp;RoleEnvironment.));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;queue.AddMessage(message);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span>Worker Role</span></h1>
<p>In the worker role's RunAsync method, the following steps are performed:</p>
<p>Setup the storage account table and queue clients:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">CloudStorageAccount&nbsp;storageAccount&nbsp;=&nbsp;CloudStorageAccount.Parse(<span class="js__string">&quot;DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]&quot;</span>);&nbsp;
CloudQueueClient&nbsp;queueClient&nbsp;=&nbsp;storageAccount.CreateCloudQueueClient();&nbsp;
CloudQueue&nbsp;queue&nbsp;=&nbsp;queueClient.GetQueueReference(<span class="js__string">&quot;myqueue&quot;</span>);&nbsp;
CloudTableClient&nbsp;tableClient&nbsp;=&nbsp;storageAccount.CreateCloudTableClient();&nbsp;
CloudTable&nbsp;table&nbsp;=&nbsp;tableClient.GetTableReference(<span class="js__string">&quot;mytable&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Until a cancellation request is recieved, get the next message from the queue:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">while</span>&nbsp;(!cancellationToken.IsCancellationRequested)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;next&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudQueueMessage&nbsp;retrievedMessage&nbsp;=&nbsp;queue.GetMessage();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(retrievedMessage&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{</pre>
</div>
</div>
</div>
<div class="endscriptcode">Launch a process and read the result (messages is a StringBuilder):</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;filename&nbsp;=&nbsp;RoleEnvironment.IsEmulated&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;?&nbsp;@<span class="cs__string">&quot;c:\windows\system32\cmd.exe&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;@<span class="cs__string">&quot;d:\windows\system32\cmd.exe&quot;</span>;&nbsp;
&nbsp;
var&nbsp;processStartInfo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ProcessStartInfo()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Arguments&nbsp;=&nbsp;<span class="cs__string">&quot;/c&nbsp;echo&nbsp;\&quot;test&nbsp;message&nbsp;from&nbsp;a&nbsp;process&nbsp;on&nbsp;the&nbsp;worker&nbsp;vm\&quot;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FileName&nbsp;=&nbsp;filename,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RedirectStandardOutput&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UseShellExecute&nbsp;=&nbsp;<span class="cs__keyword">false</span>&nbsp;
};&nbsp;
&nbsp;
var&nbsp;process&nbsp;=&nbsp;Process.Start(processStartInfo);&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;(var&nbsp;streamReader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(process.StandardOutput.BaseStream))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;messages.AppendLine(streamReader.ReadToEnd()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;at&nbsp;&quot;</span>&nbsp;&#43;&nbsp;DateTime.Now.ToString()&nbsp;&#43;<span class="cs__string">&quot;&nbsp;on&nbsp;&quot;</span>&nbsp;&#43;&nbsp;RoleEnvironment.CurrentRoleInstance);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">The result is then saved to an Azure Table and the Azure Queue messages is deleted:</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;read&nbsp;the&nbsp;latest&nbsp;messages&nbsp;from&nbsp;the&nbsp;table&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
TableOperation&nbsp;retrieveOperation&nbsp;=&nbsp;TableOperation.Retrieve&lt;MyMessages&gt;(<span class="cs__string">&quot;Partition0&quot;</span>,&nbsp;<span class="cs__string">&quot;Row0&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Execute&nbsp;the&nbsp;retrieve&nbsp;operation.</span>&nbsp;
TableResult&nbsp;retrievedResult&nbsp;=&nbsp;table.Execute(retrieveOperation);&nbsp;
&nbsp;
MyMessages&nbsp;myMessages&nbsp;=&nbsp;retrievedResult.Result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;?&nbsp;<span class="cs__keyword">new</span>&nbsp;MyMessages&nbsp;{&nbsp;PartitionKey&nbsp;=&nbsp;<span class="cs__string">&quot;Partition0&quot;</span>,&nbsp;RowKey&nbsp;=&nbsp;<span class="cs__string">&quot;Row0&quot;</span>,&nbsp;LastUpdated&nbsp;=&nbsp;DateTime.Now&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;(MyMessages)retrievedResult.Result;&nbsp;
&nbsp;
&nbsp;
messages.AppendLine(myMessages.Messages);&nbsp;
&nbsp;
...&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;replace&nbsp;the&nbsp;messages</span>&nbsp;
myMessages.Messages&nbsp;=&nbsp;messages.ToString();&nbsp;
myMessages.LastUpdated&nbsp;=&nbsp;DateTime.Now;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;Replace&nbsp;TableOperation.</span>&nbsp;
TableOperation&nbsp;replaceOperation&nbsp;=&nbsp;TableOperation.InsertOrReplace(myMessages);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Execute&nbsp;the&nbsp;operation.</span>&nbsp;
var&nbsp;result&nbsp;=&nbsp;table.Execute(replaceOperation);&nbsp;
&nbsp;
<span class="cs__com">//Process&nbsp;the&nbsp;message&nbsp;in&nbsp;less&nbsp;than&nbsp;30&nbsp;seconds,&nbsp;and&nbsp;then&nbsp;delete&nbsp;the&nbsp;message</span>&nbsp;
queue.DeleteMessage(retrievedMessage);</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">Where to from here?</h1>
<div class="endscriptcode">The project is just a rough illustration and is provided here as an illustration of how simple interconnecting roles via a queue is. &nbsp;As with many
<em>hello world</em>&nbsp;type examples, there are many pitfalls once it is adapted to the real world. &nbsp;</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Please comment if a particular aspect should be expanded upon. &nbsp;Hope it save someone some effort!</div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="preview"></div>
</div>
</div>
