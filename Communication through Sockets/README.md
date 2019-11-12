# Communication through Sockets
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
- Sockets
- Async
- system.net.sockets
## Topics
- Sockets
- Messaging
- Chat
## Updated
- 09/18/2012
## Description

<h1>Introduction</h1>
<p><em>Sockets are just an easy and powerful way to transfer data between distributed systems. As an example, you can use it to send messages between users connected in a network. You can go further more to tranfer files and play &quot;distributed&quot; games. It's ability
 to shared between many users is really an important advantage that you may need at any time to build your application.</em></p>
<h1>How does it work ?</h1>
<p><em>In this sample, I started by creating a simple to start program. It's a Server-Client application. First of all, a connection wil be established. The client will type a message to send to the server, the server will capture it, write it's own reply,
 then send it to the client which will receive it. After that the connection will be closed.</em></p>
<h1>What this app can't do ?</h1>
<ul>
<li>Both the client and the server could just send and receive one message. </li><li>The transfer of data could be done just inside the same computer. </li><li>You can't send more than 1024 bytes of data every time. </li></ul>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><em>This application requires Visual Studio 2012 or Express for Windows 8.</em></p>
<p><em>You can download it from&nbsp;<a href="http://www.microsoft.com/visualstudio/11/en-us">http://www.microsoft.com/visualstudio/11/en-us</a>.</em></p>
<p><em>Then, just open the solution, and click F5 to run it immediately.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:center"><span style="font-size:xx-small">&nbsp; <object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams"
 value="deferredLoad=false,duration=0,m=http://i1.code.msdn.s-msft.com/communication-through-91a2582b/image/file/64886/1/demo.wmv,autostart=false,autohide=true,showembed=true" /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion"
 value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="http://i1.code.msdn.s-msft.com/communication-through-91a2582b/image/file/64886/1/demo.wmv" /> <param name="id" value="64886" /> <param name="name" value="demo.wmv"
 /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span> </object>
<br>
<a id="http://i1.code.msdn.s-msft.com/communication-through-91a2582b/image/file/64886/1/demo.wmv" href="http://i1.code.msdn.s-msft.com/communication-through-91a2582b/image/file/64886/1/demo.wmv"></a></span></p>
<p style="text-align:center"><span style="font-size:xx-small"><a id="http://i1.code.msdn.s-msft.com/communication-through-91a2582b/image/file/64886/1/demo.wmv" href="http://i1.code.msdn.s-msft.com/communication-through-91a2582b/image/file/64886/1/demo.wmv">Download
 video</a></span></p>
<p style="text-align:center"><span style="font-size:xx-small"><br>
</span></p>
<p><em>&nbsp; &nbsp;<img id="64881" src="64881-houssem%20dellai%20socket.jpg" alt="" width="649" height="500"><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Connect_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;one&nbsp;SocketPermission&nbsp;for&nbsp;socket&nbsp;access&nbsp;restrictions&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SocketPermission&nbsp;permission&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SocketPermission(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NetworkAccess.Connect,&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Connection&nbsp;permission&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TransportType.Tcp,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Defines&nbsp;transport&nbsp;types&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Gets&nbsp;the&nbsp;IP&nbsp;addresses&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SocketPermission.AllPorts&nbsp;<span class="cs__com">//&nbsp;All&nbsp;ports&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Ensures&nbsp;the&nbsp;code&nbsp;to&nbsp;have&nbsp;permission&nbsp;to&nbsp;access&nbsp;a&nbsp;Socket&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;permission.Demand();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Resolves&nbsp;a&nbsp;host&nbsp;name&nbsp;to&nbsp;an&nbsp;IPHostEntry&nbsp;instance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPHostEntry&nbsp;ipHost&nbsp;=&nbsp;Dns.GetHostEntry(<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Gets&nbsp;first&nbsp;IP&nbsp;address&nbsp;associated&nbsp;with&nbsp;a&nbsp;localhost&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPAddress&nbsp;ipAddr&nbsp;=&nbsp;ipHost.AddressList[<span class="cs__number">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Creates&nbsp;a&nbsp;network&nbsp;endpoint&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPEndPoint&nbsp;ipEndPoint&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IPEndPoint(ipAddr,&nbsp;<span class="cs__number">4510</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;one&nbsp;Socket&nbsp;object&nbsp;to&nbsp;setup&nbsp;Tcp&nbsp;connection&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;senderSock&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Socket(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ipAddr.AddressFamily,<span class="cs__com">//&nbsp;Specifies&nbsp;the&nbsp;addressing&nbsp;scheme&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SocketType.Stream,&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;type&nbsp;of&nbsp;socket&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProtocolType.Tcp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Specifies&nbsp;the&nbsp;protocols&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;senderSock.NoDelay&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Using&nbsp;the&nbsp;Nagle&nbsp;algorithm&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Establishes&nbsp;a&nbsp;connection&nbsp;to&nbsp;a&nbsp;remote&nbsp;host&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;senderSock.Connect(ipEndPoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Socket&nbsp;connected&nbsp;to&nbsp;&quot;</span>&nbsp;&#43;&nbsp;senderSock.RemoteEndPoint.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exc)&nbsp;{&nbsp;MessageBox.Show(exc.ToString());&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Sending&nbsp;message&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&lt;Client&nbsp;Quit&gt;&nbsp;is&nbsp;the&nbsp;sign&nbsp;for&nbsp;end&nbsp;of&nbsp;data&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;theMessageToSend&nbsp;=&nbsp;tbMsg.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;msg&nbsp;=&nbsp;Encoding.Unicode.GetBytes(theMessageToSend&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;Client&nbsp;Quit&gt;&quot;</span>);<span class="cs__com">///</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Sends&nbsp;data&nbsp;to&nbsp;a&nbsp;connected&nbsp;Socket.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;bytesSend&nbsp;=&nbsp;senderSock.Send(msg);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReceiveDataFromServer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exc)&nbsp;{&nbsp;MessageBox.Show(exc.ToString());&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>How I started ?</h1>
<p>I build this app using the code of&nbsp;<a href="http://code.msdn.microsoft.com/CSSocketClient-fbce0679" target="_blank">Socket communication in C#</a>.</p>
<h1>More Information</h1>
<p><em>For more information, y<em>ou can post on the Q&amp;A area or contact me on: houssem.dellai@ieee.org.</em></em></p>
<address><span style="font-size:small; color:#3366ff"><em><em>Please don't forget to rate my application and to
<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Houssem%20Dellai" target="_blank">
see my other samples here</a>.</em></em></span></address>
