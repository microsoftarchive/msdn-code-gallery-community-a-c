# Chat Bot using Microsoft Bot Framework and Cognitive Services (LUIS)
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API 2
- Microsoft Bot Framework
- Cognitive Services
## Topics
- Microsoft Bot Framework
- Chat Bot
- Cognitive Services
- Language Understanding Intelligent Services
## Updated
- 08/05/2016
## Description

<p><span lang="en"><span><br>
</span></span></p>
<h1>Introduction</h1>
<p>A Visual Studio 2015 project which shows how to use the Microsoft Bot Framework V1 in an ASP.NET Web API web application project to create a chat bot, using the API &quot;LUIS&quot; - Language Understanding Intelligent Services (Cognitive Services APIs).</p>
<p>The code illustrates the following topics:</p>
<ul>
<li>Creating a Web API project in Visual Studio 2015 </li><li>Working with Microsoft.Bot.Builder and Microsoft.Bot.Connector </li><li>Writing async code </li><li>Receiving the message of users </li><li>Reply the message to users </li><li>Integrating with &quot;LUIS&quot; API (Cognitive Services) </li><li>Serializing JSON responses </li></ul>
<p><span id="result_box" lang="en"><span>A</span> <span>tutorial</span> <span>video</span>
<span>of all creation</span> <span>in this example</span><span>,</span> <span>you find on this</span>
<span>link: <a title="https://www.youtube.com/watch?v=L-0vBW6dVSY" href="https://www.youtube.com/watch?v=L-0vBW6dVSY" target="_blank">
https://www.youtube.com/watch?v=L-0vBW6dVSY</a></span></span></p>
<p><span lang="en"><span><br>
</span></span></p>
<h1>Getting Started</h1>
<p>To build and run this sample as-is, you must have Visual Studio 2015</p>
<p>In most cases you can run the application by following these steps:</p>
<ol>
<li>Download and extract the .zip file. </li><li>Open the solution file in Visual Studio. </li><li>Build the solution, which automatically installs the missing NuGet packages. </li><li>Create a LUIS Service in <a title="https://www.luis.ai" href="https://www.luis.ai" target="_blank">
LUIS.ai</a>. </li><li>Run the application. </li><li>Test with Bot Emulator in localhost (download <a title="https://aka.ms/bf-v1-emulator" href="https://aka.ms/bf-v1-emulator" target="_blank">
here</a> and install). </li><li>[Optional] Publish your application in Microsoft Azure or other hosting. </li><li>[Optional] Create your Bot in portal of Bot Connector <a title="https://dev.botframework.com/bots/new" href="https://dev.botframework.com/bots/new" target="_blank">
here</a> linking with your address of your application published. </li><li>[Optional] Test with Bot Emulator with address of your application. </li></ol>
<p><span id="result_box" class="short_text" lang="en"><span>Got questions?</span>
<span>Watch</span> <span>the video tutorial</span> <a title="https://www.youtube.com/watch?v=L-0vBW6dVSY" href="https://www.youtube.com/watch?v=L-0vBW6dVSY" target="_blank">
<span>here</span></a></span></p>
<p><span lang="en"><span><br>
</span></span></p>
<h1>Source Code Overview</h1>
<p>The <em>ChatBot</em> folder includes the following folders and files</p>
<ul>
<li><em>App_Start</em> folder - Holds the WebApiConfig file. </li><li><em>Controllers</em> - Holds the MessagesController class. </li><li><em>Serialization</em> folder - Holds the<span id="result_box" lang="en"> <span>
modeling</span> <span>classes</span> <span>that represents the response</span> <span>
in</span> <span>JSON</span> <span>format to</span> <span>the request</span> <span>
LUIS</span> <span>API</span></span>. </li><li><em>Services</em> folder - Holds the LUIS class - <span id="result_box" lang="en">
<span>Authenticates</span><span>,</span> <span>request</span> <span>and returns</span>
<span>the response</span> <span>to</span> <span>the sent message</span></span>. </li><li><em>Web.Config</em> file - Holds the configuration of Web API and keys &quot;AppID&quot; and &quot;AppSecret&quot; of your bot to connect in Bot Connector Service.
</li></ul>
<p><span lang="en"><span><br>
</span></span></p>
<h1>More Information</h1>
<p><span id="result_box" lang="en"><span>This project</span> <span>is</span> <span>
maintained and updated</span> <span>on GitHub</span><span>.</span> Enter<span> <a title="https://github.com/andreluizsecco/ChatBotSample" href="https://github.com/andreluizsecco/ChatBotSample" target="_blank">
here</a></span></span></p>
<p>Author: Andr&eacute; Luiz Secco</p>
<p>Twitter: <a title="https://twitter.com/andre_secco" href="https://twitter.com/andre_secco" target="_blank">
@andre_secco</a></p>
<p>GitHub: <a title="https://github.com/andreluizsecco" href="https://github.com/andreluizsecco" target="_blank">
andreluizsecco</a></p>
