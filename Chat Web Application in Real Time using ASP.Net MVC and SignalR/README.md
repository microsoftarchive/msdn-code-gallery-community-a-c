# Chat Web Application in Real Time using ASP.Net MVC and SignalR
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- AJAX
- ASP.NET
- jQuery
- Javascript
- HTML5
- ASP.NET MVC 4
- SignalR
- Modernizr
- ASP.NET SignalR
- Real Time
## Topics
- C#
- AJAX
- ASP.NET
- ASP.NET MVC
- jQuery
- Javascript
- HTML5
- Chat
- ASP.NET MVC 4
- SignalR
- Real-time web
- ASP.NET SignalR
## Updated
- 10/11/2013
## Description

<h1>Introduction</h1>
<p><em>The ASP.NET SignalR is an open source library that facilitates the implementation of real-time communication, updates / notifications asynchronously in an application.</em></p>
<p><em>The SignalR ASP.Net is an abstraction of a connection, it works behind the scenes setting the best type of transport in two different levels of abstraction which causes an impression of a persistent connection.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><strong><em>How to start?</em></strong></p>
<p><strong><em>You need Visual Studio 2010 SP1 or Visual Studio 2012</em></strong></p>
<p><em><br>
</em><em>Start a project ASP.Net MVC</em></p>
<p><em>Install ASP.Net SignalR Nuget by:</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">Install-Package&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.AspNet.SignalR.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.SignalR">Microsoft.AspNet.SignalR</a></pre>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<p><em></p>
<div class="endscriptcode">&nbsp;<em><strong>Add an empty Controller</strong></em></div>
</em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
<div class="preview">
<pre class="js">public&nbsp;class&nbsp;ChatController&nbsp;:&nbsp;Controller&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</pre>
<p><em><strong>Create a View</strong></em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="js__string">&quot;Chat&nbsp;B&aacute;sico&quot;</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;apelido&quot;</span>&nbsp;&gt;Seu&nbsp;Apelido:&lt;<span class="js__reg_exp">/label&gt;&lt;input&nbsp;type=&quot;text&quot;&nbsp;name=&quot;apelido&quot;&nbsp;id=&quot;apelido&quot;&nbsp;/</span>&gt;&lt;br&nbsp;/&gt;&nbsp;
&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;mensagem&quot;</span>&nbsp;&gt;Mensagem:&lt;<span class="js__reg_exp">/label&gt;&lt;input&nbsp;type=&quot;text&quot;&nbsp;name=&quot;mensagem&quot;&nbsp;id=&quot;mensagem&quot;&nbsp;maxlength=&quot;100&quot;&nbsp;/</span>&gt;&nbsp;
&lt;div&nbsp;id=<span class="js__string">&quot;chatWindow&quot;</span>&nbsp;style=<span class="js__string">&quot;width:&nbsp;100%;&nbsp;height:&nbsp;300px;&nbsp;overflow:&nbsp;scroll;&nbsp;border:&nbsp;1px&nbsp;solid&nbsp;grey&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;
&lt;!--&nbsp;Referenciando&nbsp;os&nbsp;scripts&nbsp;adicionados&nbsp;ao&nbsp;Bundle&nbsp;--&gt;&nbsp;
@Scripts.Render(<span class="js__string">&quot;~/bundles/jquery&quot;</span>)&nbsp;
@Scripts.Render(<span class="js__string">&quot;~/bundles/SignalR&quot;</span>)&nbsp;
&nbsp;
&lt;!--&nbsp;Referencia&nbsp;para&nbsp;o&nbsp;script&nbsp;de&nbsp;Hub&nbsp;criado&nbsp;automaticamente&nbsp;--&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;/signalr/hubs&quot;</span>&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Declarando&nbsp;um&nbsp;proxy&nbsp;de&nbsp;referencia&nbsp;ao&nbsp;Hub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;chatHub&nbsp;=&nbsp;$.connection.chat;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Criando&nbsp;a&nbsp;fun&ccedil;&atilde;o&nbsp;que&nbsp;ser&aacute;&nbsp;chamada&nbsp;pelo&nbsp;Hub&nbsp;para&nbsp;distribuir&nbsp;as&nbsp;mensagens&nbsp;aos&nbsp;clientes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Por&nbsp;conven&ccedil;&atilde;o&nbsp;as&nbsp;chamadas&nbsp;aos&nbsp;m&eacute;todos&nbsp;s&atilde;o&nbsp;feitas&nbsp;em&nbsp;&quot;camelCase&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chatHub.transmitirMensagem&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(apelido,&nbsp;msg)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Area&nbsp;do&nbsp;chat</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;chatWin&nbsp;=&nbsp;$(<span class="js__string">&quot;#chatWindow&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Publicando&nbsp;a&nbsp;mensagem&nbsp;no&nbsp;chat</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chatWin.html(chatWin.html()&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;b&gt;&quot;</span>&nbsp;&#43;&nbsp;apelido&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/b&gt;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;msg&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;br&nbsp;/&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Iniciando&nbsp;a&nbsp;conex&atilde;o&nbsp;com&nbsp;o&nbsp;Hub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.connection.hub.start();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Validando&nbsp;o&nbsp;bot&atilde;o&nbsp;enter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(document).keypress(<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(e.which&nbsp;==&nbsp;<span class="js__num">13</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Chamando&nbsp;o&nbsp;m&eacute;todo&nbsp;de&nbsp;transmiss&atilde;o&nbsp;de&nbsp;mensagem&nbsp;no&nbsp;Hub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chatHub.enviarMensagem($(<span class="js__string">&quot;#apelido&quot;</span>).val(),&nbsp;$(<span class="js__string">&quot;#mensagem&quot;</span>).val());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Limpando&nbsp;o&nbsp;texto&nbsp;da&nbsp;mensagem.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#mensagem&quot;</span>).val(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em><strong>Create a Hub</strong></em></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;Chat&nbsp;:&nbsp;Hub&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;EnviarMensagem(string&nbsp;apelido,&nbsp;string&nbsp;mensagem)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.TransmitirMensagem(apelido,&nbsp;mensagem);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>When running the project open a second instance of a Web browser (try different browsers) and test the chat conversation.&nbsp;</em></p>
<p><img src="-chatsignalr.jpg" alt="ASP.Net SignalR"></p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>It's incredibly easy, is not it? The client calls methods on the Hub (server) as if they were local methods and the methods call methods on the server client as if they were methods on the server.</em></p>
<p><em><strong>I want to know and learn more!</strong></em></p>
<p><em><strong>&nbsp;</strong><br>
Read these two sites:</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<ul>
<em>
<li><em><a href="http://www.asp.net/signalr" target="_blank">http://www.asp.net/signalr</a></em>
</em></li><li><em><em><a href="http://signalr.net" target="_blank">http://signalr.net</a></em>
</em></li></ul>
<p><em>&nbsp;</em></p>
<p><em></p>
<p>&nbsp;</p>
<p><em><a href="http://channel9.msdn.com/Events/TechEd/NorthAmerica/2012/DEV305" target="_blank">Watch this great video</a> that was recorded at TechEd 2012 by one of the developers of SignalR ASP.Net.</em></p>
</em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em><br>
<a href="http://eduardopires.net.br/Repositorio/SignalR_eBook.pdf" target="_blank">Read this Free eBook</a> MVP JM Aguilar, I've read and recommend (English)</em></p>
<p>&nbsp;</p>
<p><em>The example of the chat is the most simple and classic to use in real-time communication, but the possibilities of use are endless, add SignalR ASP.Net on your expertise and make profit.</em></p>
<p><em>See more at: <a href="http://eduardopires.net.br/2013/04/aspnet-signalr-introducao-e-utilizacao/" target="_blank">
http://eduardopires.net.br/2013/04/aspnet-signalr-introducao-e-utilizacao/</a><br>
</em></p>
