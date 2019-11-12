# Basic WinSock Sockets Programming with C# and .NET
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Sockets
- System.Net Namespace
- TCP/IP
- system.net.sockets
- Winsock
## Topics
- Sockets
- Networking
- Network Programming
- TCP/IP Client/Server
- Winsock
- client server programming
## Updated
- 01/07/2014
## Description

<h1>Introduction</h1>
<p><em>Have you ever wondered how your web browser connects to a website? &nbsp;Or how that IM client on your phone works? &nbsp;The answer is sockets. &nbsp;Sockets are a very powerful way to connect computers, and to exchange any sort of information that
 you would like between them using a network like the Internet. &nbsp;You can even use sockets to control a computer remotely. This example will show you the basics of how sockets work, and will introduce you to <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Sockets.aspx" target="_blank" title="Auto generated link to System.Net.Sockets">System.Net.Sockets</a>, a Microsoft library for implementing
 sockets on the .NET platform.</em></p>
<h1>Description</h1>
<p>A long time ago, when most servers were based on Unix, and the Internet didn't really exist, AT&amp;T needed a way to communicate between computers. &nbsp;So they invented an API called Sockets and it became part of the Unix operating system. &nbsp;Later,
 Microsoft developed a similar API called Winsock, and it has shipped with every version of Windows ever (well almost).</p>
<p>Sockets allows two computers to exchange data using a connection that they both control. &nbsp;One computer is called the client, and the other is called the server. &nbsp;The server sets up a socket and listens for a client computer to connect. &nbsp;The
 client connects to the server at a well known address (usually an IP address) and a port that has a number (like port 80 for web servers).</p>
<p>In this sample, we will set up a server on our local computer, and we will connect to it from a client that is also on our local computer. &nbsp;To begin, we will define some basic socket components that we need to make the client and server sockets function.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.aspx" target="_blank" title="Auto generated link to System.Net">System.Net</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Sockets.aspx" target="_blank" title="Auto generated link to System.Net.Sockets">System.Net.Sockets</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;cSharpChat&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;OSCoreServer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;DEFAULT_SERVER&nbsp;=&nbsp;<span class="cs__string">&quot;localhost&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;DEFAULT_PORT&nbsp;=&nbsp;<span class="cs__number">804</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Server&nbsp;socket&nbsp;stuff</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.Sockets.Socket&nbsp;serverSocket;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.Sockets.SocketInformation&nbsp;serverSocketInfo;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Client&nbsp;socket&nbsp;stuff</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.Sockets.Socket&nbsp;clientSocket;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.Sockets.SocketInformation&nbsp;clientSocketInfo;&nbsp;
&nbsp;
.........</pre>
</div>
</div>
</div>
<p>In the above code snippet, I have added two using statements to my code so that I can access the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Sockets.aspx" target="_blank" title="Auto generated link to System.Net.Sockets">System.Net.Sockets</a> API in the Windows .NET framework. &nbsp;Then, within a namespace that I made up, I have added a class that will represent both my client
 and server code. &nbsp;I called it OSCoreServer. &nbsp;In that class, I have defined a constant that represents the name of my default server, and the default port to connect to that server. &nbsp;Finally, I have defined a server socket, and a structure that
 holds information about that socket, and a client socket with a similar information structure.</p>
<p>The first thing that this class will need to do is to start up a server socket that can listen for clients. &nbsp;We are going to start our server up on the localhost (your local computer) at port 804. &nbsp;We could use any port, but I happen to know that
 port 804 is unoccupied by other servers that might be running on your computer, so we will use this one. &nbsp;Here is the Startup method.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Startup()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;chat&nbsp;server&nbsp;always&nbsp;starts&nbsp;up&nbsp;on&nbsp;the&nbsp;localhost,&nbsp;using&nbsp;the&nbsp;default&nbsp;port</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPHostEntry&nbsp;hostInfo&nbsp;=&nbsp;Dns.GetHostByName(DEFAULT_SERVER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPAddress&nbsp;serverAddr&nbsp;=&nbsp;hostInfo.AddressList[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;serverEndPoint&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IPEndPoint(serverAddr,&nbsp;DEFAULT_PORT);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;listener&nbsp;socket&nbsp;and&nbsp;bind&nbsp;it&nbsp;to&nbsp;the&nbsp;endpoint</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverSocket&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Sockets.Socket.aspx" target="_blank" title="Auto generated link to System.Net.Sockets.Socket">System.Net.Sockets.Socket</a>(System.Net.Sockets.AddressFamily.InterNetwork,&nbsp;System.Net.Sockets.SocketType.Stream,&nbsp;System.Net.Sockets.ProtocolType.Tcp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverSocket.Bind(serverEndPoint);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;serverSocket.LocalEndPoint.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;As you can see in the method above, we first take the name of the default server and look it up in our Domain Name Services (Dns) records so that we can find the IP address of the server. &nbsp;Our server is using &quot;localhost&quot;,
 so our IP will always be 127.0.0.1. &nbsp;This value gets put in to the AddressList array at position 0, so we retrieve it from there and then create an IPEndPoint at this address, and our default port, which is 804. &nbsp;Next we create a server socket using
 parameters that will let the socket talk over TCP/IP, which are the Internet protocols. &nbsp;Then we bind the new server socket to our endpoint address and port. &nbsp;If all of this happens successfully, we return the IP and port as a string so that our
 controlling program will know where we set up the server.</div>
<p>&nbsp;</p>
<p>Now that our server socket is set up, we can listen on that socket for any clients that might connect to it. &nbsp;That is done by simply calling the Listen method, as shown below.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Listen()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;backlog&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverSocket.Listen(backlog);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Server&nbsp;listening&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Failed&nbsp;to&nbsp;listen&quot;</span>&nbsp;&#43;&nbsp;ex.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Don't worry about the backlog parameter in the Listen method, it is not important in our simple example. &nbsp;In a real server, it would help control how many clients can connect to the server.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Now that we have a server listening, we can send it some text data from a client. &nbsp;We do that using our client socket, like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;SendData(<span class="cs__keyword">string</span>&nbsp;textdata)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">string</span>.IsNullOrEmpty(textdata))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textdata.Trim().ToLower()&nbsp;==&nbsp;<span class="cs__string">&quot;exit&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;chat&nbsp;client&nbsp;always&nbsp;starts&nbsp;up&nbsp;on&nbsp;the&nbsp;localhost,&nbsp;using&nbsp;the&nbsp;default&nbsp;port</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPHostEntry&nbsp;hostInfo&nbsp;=&nbsp;Dns.GetHostByName(DEFAULT_SERVER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPAddress&nbsp;serverAddr&nbsp;=&nbsp;hostInfo.AddressList[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;clientEndPoint&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IPEndPoint(serverAddr,&nbsp;DEFAULT_PORT);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;client&nbsp;socket&nbsp;and&nbsp;connect&nbsp;it&nbsp;to&nbsp;the&nbsp;endpoint</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Sockets.Socket.aspx" target="_blank" title="Auto generated link to System.Net.Sockets.Socket">System.Net.Sockets.Socket</a>(System.Net.Sockets.AddressFamily.InterNetwork,&nbsp;System.Net.Sockets.SocketType.Stream,&nbsp;System.Net.Sockets.ProtocolType.Tcp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket.Connect(clientEndPoint);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;byData&nbsp;=&nbsp;System.Text.Encoding.ASCII.GetBytes(textdata);&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket.Send(byData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;In the code above, we check to see if there is data to send in our string parameter, then we set up a client endpoint, which is exactly the same as setting up a server endpoint. &nbsp;But instead of listening on this client
 socket, we connect it to the server socket by calling the Connect method. &nbsp;Then we convert our text data to a byte array and use the Send method to transfer that data over the network to our server. &nbsp;Finally, we close the client socket.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">When the server socket that is listening for clients senses a connection, we must receive the data from the connection. &nbsp;That is done like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ReceiveData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.Sockets.Socket&nbsp;receiveSocket;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[<span class="cs__number">256</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveSocket&nbsp;=&nbsp;serverSocket.Accept();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bytesrecd&nbsp;=&nbsp;receiveSocket.Receive(buffer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveSocket.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Text.Encoding&nbsp;encoding&nbsp;=&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.Encoding.UTF8.aspx" target="_blank" title="Auto generated link to System.Text.Encoding.UTF8">System.Text.Encoding.UTF8</a>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;encoding.GetString(buffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;To receive data, we need another temporary socket. &nbsp;We do this so the listener socket can continue to listen for other clients. &nbsp;This receive socket is created using the Accept method on the listener socket. &nbsp;Then
 we use the Receive method on the receive socket to get the received data into a byte array. &nbsp;We can then close the receive socket as it is no longer needed. &nbsp;The received data is encoded, so we must decode it before we can put it into a string. &nbsp;In
 the case of IP, the encoding is UTF8. &nbsp;Once the array is decoded we can pass it back to our program.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">To use our WinSock server class, I created a console application. &nbsp;The app is really simple, and it looks like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;OSCoreServer&nbsp;server&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OSCoreServer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//string&nbsp;remoteServerName&nbsp;=&nbsp;server.ParseArgs(args);</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;serverInfo&nbsp;=&nbsp;server.Startup();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Server&nbsp;started&nbsp;at:&quot;</span>&nbsp;&#43;&nbsp;serverInfo);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverInfo&nbsp;=&nbsp;server.Listen();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(serverInfo);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;datatosend&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;server.SendData(datatosend);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverInfo&nbsp;=&nbsp;server.ReceiveData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(serverInfo);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//exit</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The console app program contains a static version of the OSCoreServer class. &nbsp;When the program starts up, it starts up the server using the Startup() method. &nbsp;Then it writes out the information about where the server
 started (the IP address and port). &nbsp;Then the server begins to Listen for client connections. &nbsp;We simulate a client connection by reading the console for text that you type in on the command line. &nbsp;Then we invoke the SendData() method, passing
 in the typed in data. &nbsp;Then we use the ReceiveData() method to retrieve the data on the server side and write out the data that was sent. &nbsp;Finally, we wait for the user to press enter, and exit the program.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Here is a screenshot of the program in action:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="106696" src="106696-capture.png" alt="" width="677" height="343"></div>
</div>
</div>
This is very simple example, and it lacks some very basic abilities that a real sockets server would need, like the ability to receive multiple client connections, and the ability to stay alive between connections. &nbsp;It also lacks good error checking. &nbsp;But
 it does demonstrate the basic concepts of sockets programming and it might be a good launching point for your own explorations of client server programming in .NET. &nbsp;Who knows, you might create the next big Internet app.</div>
