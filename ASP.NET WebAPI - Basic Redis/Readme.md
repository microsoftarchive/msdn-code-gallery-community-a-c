# ASP.NET WebAPI - Basic Redis
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET Web API
- WebAPI
- ASP.NET Web API 2
- redis
## Topics
- C#
- ASP.NET Web API
- redis
## Updated
- 09/15/2014
## Description

<div>
<div>
<p>This article walks you through configuration Redis and made basic operations using .net C# client.</p>
<p>Redis is one of the fastest and feature-rich key-value stores to come from the&nbsp;NoSQL&nbsp;movement. It is similar to memcached but the dataset is not volatile, and values can either be strings lists, sets, sorted sets or hashes.</p>
<p>You can download the Redis Client in any one of the following ways:</p>
<ul type="disc">
<li><span>Packaged by default in&nbsp;</span><a href="https://github.com/ServiceStack/ServiceStack/downloads"><span>ServiceStack.dll</span></a>
</li><li><span>Available to download separately as a stand-alone&nbsp;</span><a href="https://github.com/ServiceStack/ServiceStack.Redis/downloads"><span>ServiceStack.Redis.dll</span></a>
</li><li><span>As Source Code via Git:&nbsp;git clone git://github.com/ServiceStack/ServiceStack.Redis.git</span>
</li><li><span>For those interested in having a GUI admin tool to visualize your Redis data should check out the&nbsp;</span><a href="http://www.servicestack.net/mythz_blog/?p=381"><span>Redis Admin UI</span></a>
</li></ul>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">STEP 1 - Create ASP.NET WebAPI 2 Application</span></strong></p>
<p lang="en-US">I will be using Visual Studio 2013 as my development environment. Our first step will be to create an ASP.NET Web Application project based on the&nbsp;Web&nbsp;API&nbsp;template.</p>
<ul type="disc">
<li lang="en-US"><span>Open Visual Studio 2013 and create a new project of type ASP.NET Web Application.</span>
</li><li lang="en-US"><span>On this project I create a solution called WebAPI.</span> </li></ul>
<p lang="en-US">&nbsp;&nbsp;<img id="125453" src="125453-1.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<ul type="disc">
<li><span>Press OK, and a new screen will appear, with several options of template to use on our project.</span>
</li><li><span>Select the option WebAPI.</span> </li></ul>
<p lang="en-US">&nbsp;<img id="125454" src="125454-2.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<ul type="disc">
<li><span>The solution will be created.</span> </li></ul>
<p>&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 2 - Install Nuget</strong></span></p>
<p>Now in order to use Redis as CacheManager we need to install a Nuget package.</p>
<p>So on the Visual Studio 2013, select the follow menu option:</p>
<p>Tools-&gt; Library Package manager -&gt; Manage NuGet Packages for Solution</p>
<p>Search for Redis and select the option Install.</p>
<p>&nbsp;<img id="125455" src="125455-3.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>This option, will install automatically the Nuget Package.</p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 3 - Start Redis</span></strong></p>
<p><span>First&nbsp; download the latest .exe package from here </span><a href="https://github.com/rgl/redis/downloads">https://github.com/rgl/redis/downloads</a><span>&nbsp;(choose the appropriate latest 32 or 64 bit version).</span></p>
<p>Run the redis-server.exe executable file. This will start redis in command line.</p>
<p>As you see the redis is now running on port 6379 on local machine.</p>
<p><img id="125456" src="125456-4.png" alt="" width="600" height="400" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 4 - Create basic Redis class</span></strong></p>
<p lang="en-US">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    public class RedisController : ApiController
    {
        // GET: api/Redis/key
        public string Get(string key)
        {
            using (var redis = new RedisClient(&quot;localhost&quot;, 6379))
            {
                return redis.GetEntry(key);
            }  
        }

        // POST: api/Redis
        public void Post(string key, string keyValue)
        {
            using (var redis = new RedisClient(&quot;localhost&quot;, 6379))
            {
                redis.SetEntry(key, keyValue);
            }
        }        
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;ServiceStack.Redis;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net.Http;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Http;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WebApi2.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RedisController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET:&nbsp;api/Redis/key</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Get(<span class="cs__keyword">string</span>&nbsp;key)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;redis&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RedisClient(<span class="cs__string">&quot;localhost&quot;</span>,&nbsp;<span class="cs__number">6379</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;redis.GetEntry(key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;POST:&nbsp;api/Redis</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Post(<span class="cs__keyword">string</span>&nbsp;key,&nbsp;<span class="cs__keyword">string</span>&nbsp;keyValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;redis&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RedisClient(<span class="cs__string">&quot;localhost&quot;</span>,&nbsp;<span class="cs__number">6379</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;redis.SetEntry(key,&nbsp;keyValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;&nbsp;
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 5 - Test aplication</span></strong></p>
<p lang="en-US">Use postman to post some values into Redis.</p>
<p><img id="125457" src="125457-5.png" alt="" width="600" height="200" style="display:block; margin-left:auto; margin-right:auto">&nbsp;</p>
<p><span>Call api/Redis and verify that the return is the 10, value send to the key &quot;Test&quot;, on postman.</span></p>
<p><img id="125458" src="125458-6.png" alt="" width="600" height="130" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">Resources</span></strong></p>
<p lang="en-US">Some good resources about Signal could be found here:</p>
<ul type="disc">
<li lang="en-US"><span>My personal blog:&nbsp;</span><a href="http://joaoeduardosousa.wordpress.com/"><span>http://joaoeduardosousa.wordpress.com/
</span></a></li><li><span lang="en-US">ServiceStack: </span><a href="https://github.com/ServiceStack/ServiceStack.Redis/wiki/IRedisClient"><span lang="pt">https://github.com/ServiceStack/ServiceStack.Redis/wiki/IRedisClient</span></a>
</li></ul>
</div>
</div>
