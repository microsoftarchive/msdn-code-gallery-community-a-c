# ChatApp-NodeJS-Socket.io
## Requires
- 
## License
- MIT
## Technologies
- MongoDB
- Node.js
- mongoose
- Socket.io
- Chat App
## Topics
- MongoDB
- Node.js
- mongoose
- Socket.io
## Updated
- 12/04/2017
## Description

<div class="fx-toc x_fx-toc-id-12595">
<h2 class="fx-toc-title">Table of contents</h2>
<ul class="fx-toc-list x_level-1">
<li><a href="http://sibeeshpassion.com/?p=12595#introduction">Introduction</a> </li><li><a href="http://sibeeshpassion.com/?p=12595#source-code">Source Code</a> </li><li><a href="http://sibeeshpassion.com/?p=12595#background">Background</a> </li><li><a href="http://sibeeshpassion.com/?p=12595#setting-up-node-application">Setting up Node application</a>
<ul class="toc-even x_level-2">
<li><a href="http://sibeeshpassion.com/?p=12595#creating-an-app-using-express">Creating an App using Express</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#running-our-application-on-browser">Running our application on browser</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#creating-index-page">Creating Index page</a>
</li></ul>
</li><li><a href="http://sibeeshpassion.com/?p=12595#start-developing-the-chat-app">Start developing the chat app</a>
<ul class="toc-even x_level-2">
<li><a href="http://sibeeshpassion.com/?p=12595#create-model-from-page-data">Create model from page data</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#setting-up-database">Setting up database</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#creating-a-post-request">Creating a Post request</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#creating-a-get-request-for-all-the-chat-data">Creating a Get request for all the chat data</a>
</li></ul>
</li><li><a href="http://sibeeshpassion.com/?p=12595#implementing-socket-io">Implementing Socket.io</a>
<ul class="toc-even x_level-2">
<li><a href="http://sibeeshpassion.com/?p=12595#require-the-package">Require the package</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#enabling-the-connection">Enabling the connection</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#listen-using-new-http-server">Listen using new http server</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#changes-in-script">Changes in script</a>
</li><li><a href="http://sibeeshpassion.com/?p=12595#emits-the-event">Emits the event</a>
</li></ul>
</li><li><a href="http://sibeeshpassion.com/?p=12595#todo">Todo</a> </li><li><a href="http://sibeeshpassion.com/?p=12595#conclusion">Conclusion</a> </li><li><a href="http://sibeeshpassion.com/?p=12595#your-turn-what-do-you-think">Your turn. What do you think?</a>
</li></ul>
</div>
<h3><span id="introduction">Introduction</span></h3>
<p>In this article, we are going to a chat application in&nbsp;<a href="http://sibeeshpassion.com/category/Node-JS/">Node JS</a>&nbsp; with the back end&nbsp;<a href="http://sibeeshpassion.com/category/MongoDB">MongoDB.</a>&nbsp; We will also be using&nbsp;<a href="http://sibeeshpassion.com/tag/Mongoose/">Mongoose</a>&nbsp;for
 creating the MongoDB models and&nbsp;<a href="http://sibeeshpassion.com/tag/Socket.io/">Socket.io</a>&nbsp;for making multi directional chats on multiple client window. If you are really new to the Node JS, I strongly recommend you to read some articles on
 the same&nbsp;<a href="http://sibeeshpassion.com/category/Node-JS/">here</a>. You can also see how you can create a sample Node application with MongoDB and Mongoose&nbsp;<a href="http://sibeeshpassion.com/using-mongodb-on-node-js-application-using-mongoose/">here</a>.&nbsp;At
 the end of this article, I guarantee that you will be having some basic knowledge on the mentioned technologies. I hope you will like this article.</p>
<h3><span id="source-code">Source Code</span></h3>
<p>You can always clone or download the source code&nbsp;<a href="https://code.msdn.microsoft.com/Node-MongoDB-Mongoose-40fc3ad4">here</a></p>
<div class="code-block x_code-block-1">&lt;ins class=&quot;adsbygoogle&quot;&gt;&lt;/ins&gt;</div>
<h3><span id="background">Background</span></h3>
<p>Creating a chat application is always an interesting this to do. And it is a good way to learn a lot, because you are creating some interactions on your application. And with the release of few technologies we can create such application without any hassle.
 It is much more easier than ever. Here we are also going to create a chat application. A basic knowledge of Node JS, MongoDB, JavaScript, JQuery is more than enough to create this project. So, please be with me. Let&rsquo;s just skip the talking and start
 developing.</p>
<h3>At the end of this download, you can see a chat applciation as preceding</h3>
<div class="wp-caption x_alignnone" id="attachment_12598"><a href="http://sibeeshpassion.com/wp-content/uploads/2017/12/Socket.io-Output-e1512388473997.png"><img class="size-full x_wp-image-12598" src="-socket.io-output-e1512388473997.png" alt="Socket.io Output" width="634" height="596"></a>
<p class="wp-caption-text">Socket.io Output</p>
</div>
<p>Please make sure that you are getting the chats in the second instance when you send it from the first instance of the browser and vice versa.</p>
<h3>Conclusion</h3>
<p>Thanks a lot for reading. Did I miss anything that you may think which is needed? Could you find this post as useful? I hope you liked this article. Please share me your valuable suggestions and feedback.</p>
