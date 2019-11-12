# ASP.NET CORE 2.0 uses SignalR technology
## Requires
- Visual Studio 2017
## License
- MS-LPL
## Technologies
- SignalR
- Digital Signal Processing
- ASP.NET SignalR
- SignalR 2.0
- ASP.NET Core
## Topics
- ASP.NET SignalR
## Updated
- 09/28/2017
## Description

<h2><span><em>1-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Introduction</em></span></h2>
<h2><span><em>2-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Environment to build</em></span></h2>
<div class="slate-resizable-image-embed x_x_x_slate-image-embed__resize-full-width">
<img src=":-aaia_wdgaaaaaqaaaaaaaamsaaaajdg1yzzin2q1lwuxymutngfhyy1hzjfmltawnze0ode4mmvjng.png" alt=""></div>
<h2>1-&nbsp;&nbsp;&nbsp;&nbsp;<span style="text-decoration:underline">&nbsp;Introduction</span></h2>
<p>The ASP.NET Core 1.x.x release does not include SignalR technology and development plans. Time has passed quickly, Microsoft has released a preview version of. NET Core 2.0 Preview 2, not far from the official version, the above also mentioned in the ASP.NET
 Core 2.0 SignalR will be as important components and MVC and other frameworks released together. Its development team also fulfilled the commitment to use TypeScript to rewrite its javascript client, the server side will be close to the ASP.NET Core development,
 such as will be integrated into the ASP.NET Core dependent injection framework.</p>
<h2>2-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="text-decoration:underline">Environment to build</span></h2>
<p>To use SignalR in ASP.NET Core 2.0, first reference Microsoft.AspNetCore.SignalR, Microsoft.AspNetCore.SignalR.Http two package packages.</p>
<p>At present, ASP.NET Core 2.0 and SignalR are also in a preview version, so NUGET cannot find the SignalR package, would like to add a reference we have to go to MyGet look up. Since the use of MyGet, it is necessary to add NuGet source for the project.</p>
<h3>a.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<em><span style="text-decoration:underline">&nbsp;Add the NuGet source</span></em></h3>
<p>In the program root directory to create a new file for the NuGet.Config contents are as follows:</p>
<pre><span class="hljs-meta">&lt;?</span>xml version=<span class="hljs-string">&quot;1.0&quot;</span> encoding=<span class="hljs-string">&quot;utf-8&quot;</span><span class="hljs-meta">?&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">configuration</span>&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">packageSources</span>&gt;</span>
        <span class="hljs-tag">&lt;<span class="hljs-name">clear</span>/&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">add</span> <span class="hljs-attr">key</span>=<span class="hljs-string">&quot;aspnetcidev&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;https://dotnet.myget.org/F/aspnetcore-ci-dev/api/v3/index.json&quot;</span>/&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">add</span> <span class="hljs-attr">key</span>=<span class="hljs-string">&quot;api.nuget.org&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;https://api.nuget.org/v3/index.json&quot;</span>/&gt;</span>
    <span class="hljs-tag">&lt;/<span class="hljs-name">packageSources</span>&gt;</span>
&#65279;<span class="hljs-tag">&lt;/<span class="hljs-name">configuration</span>&gt;</span>
</pre>
<h3><em>b.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="text-decoration:underline">Edit the project file csproj</span></em></h3>
<p>Add the references to the two packages mentioned above:</p>
<pre>&nbsp; <span class="hljs-tag">&lt;<span class="hljs-name">PackageReference</span> <span class="hljs-attr">Include</span>=<span class="hljs-string">&quot;Microsoft.AspNetCore.All&quot;</span> <span class="hljs-attr">Version</span>=<span class="hljs-string">&quot;2.0.0&quot;</span> /&gt;</span>
&nbsp; <span class="hljs-tag">&lt;<span class="hljs-name">PackageReference</span> <span class="hljs-attr">Include</span>=<span class="hljs-string">&quot;Microsoft.AspNetCore.SignalR&quot;</span> <span class="hljs-attr">Version</span>=<span class="hljs-string">&quot;1.0.0-alpha1-final&quot;</span> /&gt;</span>
&nbsp; <span class="hljs-tag">&lt;<span class="hljs-name">PackageReference</span> <span class="hljs-attr">Include</span>=<span class="hljs-string">&quot;Microsoft.AspNetCore.SignalR.Http&quot;</span> <span class="hljs-attr">Version</span>=<span class="hljs-string">&quot;0.0.1-alpha&quot;</span> /&gt;</span>
</pre>
<p>I am using the current highest in this example, of course the version number is likely to change every day, the latest version of the SignalR is not compatible with the .NET Core SDK 2.0 Preview 1 by default when creating the project Microsoft.AspNetCore.All
 this package Version, here also modify the revised version number: Microsoft.AspNetCore.All 2.0.0-preview3-26040.</p>
<p>Of course, you can also use dotnet cli to add the package reference:</p>
<p>Of course, you can also use dotnet cli to add the package reference:</p>
<pre>dotnet add <span class="hljs-keyword">package</span> Microsoft.AspNetCore.SignalR --<span class="hljs-keyword">version</span> <span class="hljs-number">1.0</span>.1-alpha-<span class="hljs-keyword">final</span> --source https:<span class="hljs-comment">//dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json</span>

dotnet add <span class="hljs-keyword">package</span> Microsoft.AspNetCore.SignalR.Http --<span class="hljs-keyword">version</span> <span class="hljs-number">0.0</span>.1-alpha --source https:<span class="hljs-comment">//dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json</span>
</pre>
<h3>c.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<em><span style="text-decoration:underline">Add the configuration code</span></em></h3>
<p>We need to Startup class in the ConfigureServices method to add the following code:</p>
<pre><span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">ConfigureServices</span><span class="hljs-params">(IServiceCollection services)</span>
</span>{
    services.AddSignalR();
}
</pre>
<p>Add the following code to the Configure method in the Startup class:</p>
<pre><span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Configure</span><span class="hljs-params">(IApplicationBuilder app, IHostingEnvironment env)</span>
</span>{
    app.UseStaticFiles();
    app.UseSignalR(routes =&gt;
    {
        routes.MapHub&lt;Chat&gt;(<span class="hljs-string">&quot;hubs&quot;</span>);
    });
}
</pre>
<h3>d.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<em><span style="text-decoration:underline">Add a HUB class</span></em></h3>
<pre><span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">Chat</span> : <span class="hljs-title">Hub</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">async</span> Task <span class="hljs-title">OnConnectedAsync</span>()
    </span>{
        <span class="hljs-keyword">await</span> Clients.All.InvokeAsync(<span class="hljs-string">&quot;Send&quot;</span>, <span class="hljs-string">$&quot;<span class="hljs-subst">{Context.ConnectionId}</span> joined&quot;</span>);
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">async</span> Task <span class="hljs-title">OnDisconnectedAsync</span>(<span class="hljs-params">Exception ex</span>)
    </span>{
        <span class="hljs-keyword">await</span> Clients.All.InvokeAsync(<span class="hljs-string">&quot;Send&quot;</span>, <span class="hljs-string">$&quot;<span class="hljs-subst">{Context.ConnectionId}</span> left&quot;</span>);
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> Task <span class="hljs-title">Send</span>(<span class="hljs-params"><span class="hljs-keyword">string</span> message</span>)
    </span>{
        <span class="hljs-keyword">return</span> Clients.All.InvokeAsync(<span class="hljs-string">&quot;Send&quot;</span>, <span class="hljs-string">$&quot;<span class="hljs-subst">{Context.ConnectionId}</span>: <span class="hljs-subst">{message}</span>&quot;</span>);
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> Task <span class="hljs-title">SendToGroup</span>(<span class="hljs-params"><span class="hljs-keyword">string</span> groupName, <span class="hljs-keyword">string</span> message</span>)
    </span>{
        <span class="hljs-keyword">return</span> Clients.Group(groupName).InvokeAsync(<span class="hljs-string">&quot;Send&quot;</span>, <span class="hljs-string">$&quot;<span class="hljs-subst">{Context.ConnectionId}</span>@<span class="hljs-subst">{groupName}</span>: <span class="hljs-subst">{message}</span>&quot;</span>);
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">async</span> Task <span class="hljs-title">JoinGroup</span>(<span class="hljs-params"><span class="hljs-keyword">string</span> groupName</span>)
    </span>{
        <span class="hljs-keyword">await</span> Groups.AddAsync(Context.ConnectionId, groupName);

        <span class="hljs-keyword">await</span> Clients.Group(groupName).InvokeAsync(<span class="hljs-string">&quot;Send&quot;</span>, <span class="hljs-string">$&quot;<span class="hljs-subst">{Context.ConnectionId}</span> joined <span class="hljs-subst">{groupName}</span>&quot;</span>);
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">async</span> Task <span class="hljs-title">LeaveGroup</span>(<span class="hljs-params"><span class="hljs-keyword">string</span> groupName</span>)
    </span>{
        <span class="hljs-keyword">await</span> Groups.RemoveAsync(Context.ConnectionId, groupName);

        <span class="hljs-keyword">await</span> Clients.Group(groupName).InvokeAsync(<span class="hljs-string">&quot;Send&quot;</span>, <span class="hljs-string">$&quot;<span class="hljs-subst">{Context.ConnectionId}</span> left <span class="hljs-subst">{groupName}</span>&quot;</span>);
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> Task <span class="hljs-title">Echo</span>(<span class="hljs-params"><span class="hljs-keyword">string</span> message</span>)
    </span>{
        <span class="hljs-keyword">return</span> Clients.Client(Context.ConnectionId).InvokeAsync(<span class="hljs-string">&quot;Send&quot;</span>, <span class="hljs-string">$&quot;<span class="hljs-subst">{Context.ConnectionId}</span>: <span class="hljs-subst">{message}</span>&quot;</span>);
    }
}
</pre>
<h3>e.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<em><span style="text-decoration:underline">&nbsp;Client support</span></em></h3>
<p>In the wwwroot directory to create a chat.html called Html static file, reads as follows:</p>
<pre><span class="hljs-meta">&lt;!DOCTYPE html&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">html</span>&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">head</span>&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">meta</span> <span class="hljs-attr">charset</span>=<span class="hljs-string">&quot;utf-8&quot;</span> /&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">title</span>&gt;&lt;/<span class="hljs-name">title</span>&gt;</span>
<span class="hljs-tag">&lt;/<span class="hljs-name">head</span>&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">body</span>&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">h1</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;head1&quot;</span>&gt;&lt;/<span class="hljs-name">h1</span>&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">div</span>&gt;</span>
        <span class="hljs-tag">&lt;<span class="hljs-name">select</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;formatType&quot;</span>&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">option</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;json&quot;</span>&gt;</span>json<span class="hljs-tag">&lt;/<span class="hljs-name">option</span>&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">option</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;line&quot;</span>&gt;</span>line<span class="hljs-tag">&lt;/<span class="hljs-name">option</span>&gt;</span>
        <span class="hljs-tag">&lt;/<span class="hljs-name">select</span>&gt;</span>

        <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;connect&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Connect&quot;</span> /&gt;</span>
        <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;disconnect&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Disconnect&quot;</span> /&gt;</span>
    <span class="hljs-tag">&lt;/<span class="hljs-name">div</span>&gt;</span>


    <span class="hljs-tag">&lt;<span class="hljs-name">h4</span>&gt;</span>To Everybody<span class="hljs-tag">&lt;/<span class="hljs-name">h4</span>&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">form</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;form-inline&quot;</span>&gt;</span>
        <span class="hljs-tag">&lt;<span class="hljs-name">div</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;input-append&quot;</span>&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;text&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;message-text&quot;</span> <span class="hljs-attr">placeholder</span>=<span class="hljs-string">&quot;Type a message, name or group&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;broadcast&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Broadcast&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;broadcast-exceptme&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Broadcast (All Except Me)&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;join&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Enter Name&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;join-group&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Join Group&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;leave-group&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Leave Group&quot;</span> /&gt;</span>
        <span class="hljs-tag">&lt;/<span class="hljs-name">div</span>&gt;</span>
    <span class="hljs-tag">&lt;/<span class="hljs-name">form</span>&gt;</span>

    <span class="hljs-tag">&lt;<span class="hljs-name">h4</span>&gt;</span>To Me<span class="hljs-tag">&lt;/<span class="hljs-name">h4</span>&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">form</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;form-inline&quot;</span>&gt;</span>
        <span class="hljs-tag">&lt;<span class="hljs-name">div</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;input-append&quot;</span>&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;text&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;me-message-text&quot;</span> <span class="hljs-attr">placeholder</span>=<span class="hljs-string">&quot;Type a message&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;send&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Send to me&quot;</span> /&gt;</span>
        <span class="hljs-tag">&lt;/<span class="hljs-name">div</span>&gt;</span>
    <span class="hljs-tag">&lt;/<span class="hljs-name">form</span>&gt;</span>

    <span class="hljs-tag">&lt;<span class="hljs-name">h4</span>&gt;</span>Private Message<span class="hljs-tag">&lt;/<span class="hljs-name">h4</span>&gt;</span>
    <span class="hljs-tag">&lt;<span class="hljs-name">form</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;form-inline&quot;</span>&gt;</span>
        <span class="hljs-tag">&lt;<span class="hljs-name">div</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;input-prepend input-append&quot;</span>&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;text&quot;</span> <span class="hljs-attr">name</span>=<span class="hljs-string">&quot;private-message&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;private-message-text&quot;</span> <span class="hljs-attr">placeholder</span>=<span class="hljs-string">&quot;Type a message&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;text&quot;</span> <span class="hljs-attr">name</span>=<span class="hljs-string">&quot;user&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;target&quot;</span> <span class="hljs-attr">placeholder</span>=<span class="hljs-string">&quot;Type a user or group name&quot;</span> /&gt;</span>

            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;privatemsg&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Send to user&quot;</span> /&gt;</span>
            <span class="hljs-tag">&lt;<span class="hljs-name">input</span> <span class="hljs-attr">type</span>=<span class="hljs-string">&quot;button&quot;</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;groupmsg&quot;</span> <span class="hljs-attr">class</span>=<span class="hljs-string">&quot;btn&quot;</span> <span class="hljs-attr">value</span>=<span class="hljs-string">&quot;Send to group&quot;</span> /&gt;</span>
        <span class="hljs-tag">&lt;/<span class="hljs-name">div</span>&gt;</span>
    <span class="hljs-tag">&lt;/<span class="hljs-name">form</span>&gt;</span>

    <span class="hljs-tag">&lt;<span class="hljs-name">ul</span> <span class="hljs-attr">id</span>=<span class="hljs-string">&quot;message-list&quot;</span>&gt;&lt;/<span class="hljs-name">ul</span>&gt;</span>
<span class="hljs-tag">&lt;/<span class="hljs-name">body</span>&gt;</span>
<span class="hljs-tag">&lt;/<span class="hljs-name">html</span>&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">script</span> <span class="hljs-attr">src</span>=<span class="hljs-string">&quot;signalr-client.js&quot;</span>&gt;&lt;/<span class="hljs-name">script</span>&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">script</span> <span class="hljs-attr">src</span>=<span class="hljs-string">&quot;utils.js&quot;</span>&gt;&lt;/<span class="hljs-name">script</span>&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">script</span>&gt;</span>
<span class="hljs-keyword">var</span> isConnected = <span class="hljs-literal">false</span>;
<span class="hljs-function"><span class="hljs-keyword">function</span> <span class="hljs-title">invoke</span>(<span class="hljs-params">connection, method, ...args</span>) </span>{
    <span class="hljs-keyword">if</span> (!isConnected) {
        <span class="hljs-keyword">return</span>;
    }
    <span class="hljs-keyword">var</span> argsArray = <span class="hljs-built_in">Array</span>.prototype.slice.call(<span class="hljs-built_in">arguments</span>);
    connection.invoke.apply(connection, argsArray.slice(<span class="hljs-number">1</span>))
            .then(result =&gt; {
                <span class="hljs-built_in">console</span>.log(<span class="hljs-string">&quot;invocation completed successfully: &quot;</span> &#43; (result === <span class="hljs-literal">null</span> ? <span class="hljs-string">'(null)'</span> : result));

                <span class="hljs-keyword">if</span> (result) {
                    addLine(<span class="hljs-string">'message-list'</span>, result);
                }
            })
            .catch(err =&gt; {
                addLine(<span class="hljs-string">'message-list'</span>, err, <span class="hljs-string">'red'</span>);
            });
}

<span class="hljs-function"><span class="hljs-keyword">function</span> <span class="hljs-title">getText</span>(<span class="hljs-params">id</span>) </span>{
    <span class="hljs-keyword">return</span> <span class="hljs-built_in">document</span>.getElementById(id).value;
}

<span class="hljs-keyword">let</span> transportType = signalR.TransportType[getParameterByName(<span class="hljs-string">'transport'</span>)] || signalR.TransportType.WebSockets;

<span class="hljs-built_in">document</span>.getElementById(<span class="hljs-string">'head1'</span>).innerHTML = signalR.TransportType[transportType];

<span class="hljs-keyword">let</span> connectButton = <span class="hljs-built_in">document</span>.getElementById(<span class="hljs-string">'connect'</span>);
<span class="hljs-keyword">let</span> disconnectButton = <span class="hljs-built_in">document</span>.getElementById(<span class="hljs-string">'disconnect'</span>);
disconnectButton.disabled = <span class="hljs-literal">true</span>;
<span class="hljs-keyword">var</span> connection;

click(<span class="hljs-string">'connect'</span>, event =&gt; {
    connectButton.disabled = <span class="hljs-literal">true</span>;
    disconnectButton.disabled = <span class="hljs-literal">false</span>;
    <span class="hljs-keyword">let</span> http = <span class="hljs-keyword">new</span> signalR.HttpConnection(<span class="hljs-string">`http://<span class="hljs-subst">${document.location.host}</span>/hubs`</span>, { transport: transportType });
    connection = <span class="hljs-keyword">new</span> signalR.HubConnection(http);
    connection.on(<span class="hljs-string">'Send'</span>, msg =&gt; {
        addLine(<span class="hljs-string">'message-list'</span>, msg);
    });

    connection.onClosed = e =&gt; {
        <span class="hljs-keyword">if</span> (e) {
            addLine(<span class="hljs-string">'message-list'</span>, <span class="hljs-string">'Connection closed with error: '</span> &#43; e, <span class="hljs-string">'red'</span>);
        }
        <span class="hljs-keyword">else</span> {
            addLine(<span class="hljs-string">'message-list'</span>, <span class="hljs-string">'Disconnected'</span>, <span class="hljs-string">'green'</span>);
        }
    }

    connection.start()
        .then(() =&gt; {
            isConnected = <span class="hljs-literal">true</span>;
            addLine(<span class="hljs-string">'message-list'</span>, <span class="hljs-string">'Connected successfully'</span>, <span class="hljs-string">'green'</span>);
        })
        .catch(err =&gt; {
            addLine(<span class="hljs-string">'message-list'</span>, err, <span class="hljs-string">'red'</span>);
        });
});

click(<span class="hljs-string">'disconnect'</span>, event =&gt; {
    connectButton.disabled = <span class="hljs-literal">false</span>;
    disconnectButton.disabled = <span class="hljs-literal">true</span>;
    connection.stop()
        .then(() =&gt; {
            isConnected = <span class="hljs-literal">false</span>;
        });
});

click(<span class="hljs-string">'broadcast'</span>, event =&gt; {
    <span class="hljs-keyword">let</span> data = getText(<span class="hljs-string">'message-text'</span>);
    invoke(connection, <span class="hljs-string">'Send'</span>, data);
});

click(<span class="hljs-string">'join-group'</span>, event =&gt; {
    <span class="hljs-keyword">let</span> groupName = getText(<span class="hljs-string">'message-text'</span>);
    invoke(connection, <span class="hljs-string">'JoinGroup'</span>, groupName);
});

click(<span class="hljs-string">'leave-group'</span>, event =&gt; {
    <span class="hljs-keyword">let</span> groupName = getText(<span class="hljs-string">'message-text'</span>);
    invoke(connection, <span class="hljs-string">'LeaveGroup'</span>, groupName);
});

click(<span class="hljs-string">'groupmsg'</span>, event =&gt; {
    <span class="hljs-keyword">let</span> groupName = getText(<span class="hljs-string">'target'</span>);
    <span class="hljs-keyword">let</span> message = getText(<span class="hljs-string">'private-message-text'</span>);
    invoke(connection, <span class="hljs-string">'SendToGroup'</span>, groupName, message);
});

click(<span class="hljs-string">'send'</span>, event =&gt; {
    <span class="hljs-keyword">let</span> data = getText(<span class="hljs-string">'me-message-text'</span>);
    invoke(connection, <span class="hljs-string">'Echo'</span>, data);
});

<span class="hljs-tag">&lt;/<span class="hljs-name">script</span>&gt;</span>
</pre>
<p>It is worth noting that you may find that there is no signalr-client.js this document, how does it come, there are two ways:</p>
<p>The first kind is to download the SignalR source code, find the Client-TS project, compile the TypeScript can be obtained.</p>
<p>The second kind of relatively simple through Npm can be obtained online:</p>
<p>npm install signalr-client --registry&nbsp;<a rel="nofollow noopener" href="https://dotnet.myget.org/f/aspnetcore-ci-dev/npm/" target="_blank">https://dotnet.myget.org/f/aspnetcore-ci-dev/npm/</a></p>
