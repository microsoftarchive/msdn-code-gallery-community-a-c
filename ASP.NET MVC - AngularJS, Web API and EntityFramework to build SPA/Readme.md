# ASP.NET MVC - AngularJS, Web API and EntityFramework to build SPA
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET MVC
- WebAPI
- EF6
- AngularJS
## Topics
- C#
- ASP.NET MVC
- EF6
- AngularJS
- MVC 5 with WebAPI
## Updated
- 11/16/2014
## Description

<p lang="en-US"><span style="font-size:small"><strong>Introduction</strong></span></p>
<p><span>This article walks you through the steps for create a web application using AngularJS, that uses WebApi to communicate between client and server side.</span></p>
<p>&nbsp;</p>
<p><strong style="font-size:small">STEP 1 - Create ASP.NET Web Api Application</strong></p>
<p>Check the link below, to see all the steps to create a Web Api wtih Entity Framework code first implementation.</p>
<p><a href="http://social.technet.microsoft.com/wiki/contents/articles/26795.asp-net-webapi-entity-framework-code-first.aspx">http://social.technet.microsoft.com/wiki/contents/articles/26795.asp-net-webapi-entity-framework-code-first.aspx</a></p>
<p>&nbsp;</p>
<p lang="en-US"><strong><span style="font-size:small">STEP 2 - Install Nuget</span></strong></p>
<p>Now in order to use Entity Framework we need to install a Nuget package.</p>
<p>So on the Visual Studio 2013, select the follow menu option:</p>
<p>Tools-&gt; Library Package manager -&gt; Manage NuGet Packages for Solution</p>
<p>Search for AngularJs and select the option Install.</p>
<p><img id="129671" src="129671-1.png" alt="" width="600" height="400">&nbsp;</p>
<p>This option, will install automatically the Nuget Package.</p>
<p>&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 3 - Create Javascript controller</strong></span></p>
<p>Now add a new javascript file (contactController.js) in scripts directory and add angular functions.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">function contactController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data
    $http.get('/api/Contact/').success(function (data) {
        $scope.Contacts = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = &quot;An Error has occured while loading posts!&quot;;
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.Contact.editMode = !this.Contact.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Used to save a record after edit
    $scope.save = function () {
        alert(&quot;Edit&quot;);
        $scope.loading = true;
        var frien = this.Contact;
        alert(emp);
        $http.put('/api/Contact/', frien).success(function (data) {
            alert(&quot;Saved Successfully!!&quot;);
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = &quot;An Error has occured while Saving Contact! &quot; &#43; data;
            $scope.loading = false;

        });
    };

    //Used to add a new record
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Contact/', this.newContact).success(function (data) {
            alert(&quot;Added Successfully!!&quot;);
            $scope.addMode = false;
            $scope.Contacts.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = &quot;An Error has occured while Adding Contact! &quot; &#43; data;
            $scope.loading = false;

        });
    };

    //Used to edit a record
    $scope.deleteContact = function () {
        $scope.loading = true;
        var Contactid = this.Contact.ContactId;
        $http.delete('/api/Contact/' &#43; Contactid).success(function (data) {
            alert(&quot;Deleted Successfully!!&quot;);
            $.each($scope.Contacts, function (i) {
                if ($scope.Contacts[i].ContactId === Contactid) {
                    $scope.Contacts.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = &quot;An Error has occured while Saving Contact! &quot; &#43; data;
            $scope.loading = false;

        });
    };

}
</pre>
<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;contactController($scope,&nbsp;$http)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.addMode&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Used&nbsp;to&nbsp;display&nbsp;the&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/Contact/'</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Contacts&nbsp;=&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.toggleEdit&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.Contact.editMode&nbsp;=&nbsp;!<span class="js__operator">this</span>.Contact.editMode;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.toggleAdd&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.addMode&nbsp;=&nbsp;!$scope.addMode;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Used&nbsp;to&nbsp;save&nbsp;a&nbsp;record&nbsp;after&nbsp;edit</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.save&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Edit&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;frien&nbsp;=&nbsp;<span class="js__operator">this</span>.Contact;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(emp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.put(<span class="js__string">'/api/Contact/'</span>,&nbsp;frien).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Saved&nbsp;Successfully!!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emp.editMode&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).error(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;Saving&nbsp;Contact!&nbsp;&quot;</span>&nbsp;&#43;&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Used&nbsp;to&nbsp;add&nbsp;a&nbsp;new&nbsp;record</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.add&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.post(<span class="js__string">'/api/Contact/'</span>,&nbsp;<span class="js__operator">this</span>.newContact).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Added&nbsp;Successfully!!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.addMode&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Contacts.push(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).error(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;Adding&nbsp;Contact!&nbsp;&quot;</span>&nbsp;&#43;&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Used&nbsp;to&nbsp;edit&nbsp;a&nbsp;record</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.deleteContact&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Contactid&nbsp;=&nbsp;<span class="js__operator">this</span>.Contact.ContactId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.<span class="js__operator">delete</span>(<span class="js__string">'/api/Contact/'</span>&nbsp;&#43;&nbsp;Contactid).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Deleted&nbsp;Successfully!!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each($scope.Contacts,&nbsp;<span class="js__operator">function</span>&nbsp;(i)&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;($scope.Contacts[i].ContactId&nbsp;===&nbsp;Contactid)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Contacts.splice(i,&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).error(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;Saving&nbsp;Contact!&nbsp;&quot;</span>&nbsp;&#43;&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</h1>
<p lang="en-US"><span style="font-size:small"><strong>STEP 4- Create View</strong></span></p>
<p>On BundlesConfig file add these lines of code.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> bundles.Add(new ScriptBundle(&quot;~/bundles/angularjs&quot;).Include(
                      &quot;~/Scripts/angular.js&quot;,
                      &quot;~/Scripts/contactController.js&quot;));
</pre>
<div class="preview">
<pre class="csharp">&nbsp;bundles.Add(<span class="cs__keyword">new</span>&nbsp;ScriptBundle(<span class="cs__string">&quot;~/bundles/angularjs&quot;</span>).Include(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;~/Scripts/angular.js&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;~/Scripts/contactController.js&quot;</span>));&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<p>Open _Layout.cshtml page from Shared folder and add these two lines to render angularJS and contactController in application.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">@Scripts.Render(&quot;~/bundles/angularjs&quot;)
</pre>
<div class="preview">
<pre class="js">@Scripts.Render(<span class="js__string">&quot;~/bundles/angularjs&quot;</span>)&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Now let&rsquo;s work on View.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@{
    Layout = &quot;~/Views/Shared/_Layout.cshtml&quot;;
}

&lt;h2&gt;Contacts&lt;/h2&gt;

&lt;div ng-app=&quot;&quot; ng-controller=&quot;contactController&quot; class=&quot;container&quot;&gt;
    &lt;strong class=&quot;error&quot;&gt;{{&nbsp;error&nbsp;}}&lt;/strong&gt;    

    &lt;div class=&quot;row&quot;&gt;
        &lt;div class=&quot;logs-table col-xs-12&quot;&gt;
            &lt;table class=&quot;table table-bordered table-hover&quot; style=&quot;width:100%&quot;&gt;
                &lt;tr&gt;
                    &lt;th&gt;Id&lt;/th&gt;
                    &lt;th&gt;Name&lt;/th&gt;
                    &lt;th&gt;Address&lt;/th&gt;
                    &lt;th&gt;City&lt;/th&gt;
                    &lt;th&gt;Country&lt;/th&gt;
                &lt;/tr&gt;

                &lt;tr ng-repeat=&quot;contact in contacts&quot;&gt;
                    &lt;td&gt;{{&nbsp;contact.Id&nbsp;}}&lt;/td&gt;
                    &lt;td&gt;{{&nbsp;contact.Name&nbsp;}}&lt;/td&gt;
                    &lt;td&gt;{{&nbsp;contact.Address&nbsp;}}&lt;/td&gt;
                    &lt;td&gt;{{&nbsp;contact.City&nbsp;}}&lt;/td&gt;
                    &lt;td&gt;{{&nbsp;contact.Country&nbsp;}}&lt;/td&gt;
                &lt;/tr&gt;
            &lt;/table&gt;
        &lt;/div&gt;
    &lt;/div&gt;
&lt;/div&gt;


</pre>
<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Layout&nbsp;=&nbsp;<span class="js__string">&quot;~/Views/Shared/_Layout.cshtml&quot;</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&lt;h2&gt;Contacts&lt;/h2&gt;&nbsp;
&nbsp;
&lt;div&nbsp;ng-app=<span class="js__string">&quot;&quot;</span>&nbsp;ng-controller=<span class="js__string">&quot;contactController&quot;</span>&nbsp;class=<span class="js__string">&quot;container&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;strong&nbsp;class=<span class="js__string">&quot;error&quot;</span>&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;error&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/strong&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;row&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;logs-table&nbsp;col-xs-12&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;class=<span class="js__string">&quot;table&nbsp;table-bordered&nbsp;table-hover&quot;</span>&nbsp;style=<span class="js__string">&quot;width:100%&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Id&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Name&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Address&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;City&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Country&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;ng-repeat=<span class="js__string">&quot;contact&nbsp;in&nbsp;contacts&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;contact.Id&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;contact.Name&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;contact.Address&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;contact.City&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__brace">{</span><span class="js__brace">{</span>&nbsp;contact.Country&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p lang="en-US"><span style="font-size:small"><strong>STEP 5 - Run application</strong></span></p>
<p>Run application to see output:</p>
<p><img id="129672" src="129672-2.png" alt="" width="600" height="200"></p>
<p><strong>Resources</strong></p>
<p lang="en-US"><strong>Some good resources about Windows Azure could be found here:</strong></p>
<ul type="disc">
<li lang="en-US"><span>My personal blog:&nbsp;</span><a href="http://joaoeduardosousa.wordpress.com/"><span>http://joaoeduardosousa.wordpress.com/
</span></a></li><li><span>Angular UI: </span><a href="http://angular-ui.github.io/"><span>http://angular-ui.github.io/</span></a>
</li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
