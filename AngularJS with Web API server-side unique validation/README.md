# AngularJS with Web API: server-side unique validation
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Javascript
- HTML5
- AngularJS
- ASP.NET Web API 2
## Topics
- ASP.NET
- Entity Framework
- Paging
- HTML5
- ASP.NET Web API
- AngularJS
- unique Validation
## Updated
- 11/17/2015
## Description

<h1>Introduction</h1>
<p>This sample demonstrates how to implement unique constraint validation and error handling in an AngularJS single page application (SPA) served by a Web API controller. Two approaches are demonstrated:</p>
<ul>
<li><strong>simple: (validation on save)</strong>&nbsp;when saving an entity any errors caused by a unique property value already existing are returned to the SPA. Those errors can then be handled, informing the user that the offending property value is not
 unique. </li><li><strong>advanced:&nbsp;(interactive field level validation)&nbsp;</strong>when entering a new value for a unique property the SPA checks, via an API call, whether the value is 'available'. If it is not an error is reported to the user and the user cannot
 save the new record until the error has been rectified. </li></ul>
<p><img id="144842" src="144842-advancedpage2.png" alt="" width="704" height="384"></p>
<p>The approaches are not exclusive, and in a real world application can be used together. In this simplified scenario the user only has the option to add a new record but the same appproach can be taken for updating existing entities.</p>
<p><span>Please note that all code snippets in this description are partial and only contain the relevant lines of code. To view the full code please download the sample.</span></p>
<h1><span>Building the Sample</span></h1>
<p>This sample has the solution level NuGet packages removed to make it smaller for downloading. If you do not have NuGet Package Restore enabled run NuGet and it should prompt you to restore the missing packages. The sample DbContext uses a connection string
 called <strong>bookConn</strong>&nbsp;(in <strong>web.config</strong>). This is set to use LocalDb and the database will be initialized the first time the context is queried.</p>
<h1>Description</h1>
<h2>The model</h2>
<p>The sample has a simple Entity Framwork model (see the <strong>SampleContext</strong>) with a single entity called
<strong>Book. </strong>Book&nbsp;has a unique property&nbsp;<strong>Title.</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Book&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Book()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Index(IsUnique&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="cs__number">255</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[MinLength(<span class="cs__number">1</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Title&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="cs__number">255</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[MinLength(<span class="cs__number">1</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Author&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Web API</h2>
<p>There are couple of configuration changes for the Web API:</p>
<ul>
<li>in <strong>BundleConfig</strong> the line <strong>BundleTable.EnableOptimizations = true</strong>; has been commented out. This will stop the SPA scripts (bundled as app) from being bundled and minified, making it easier to step through the client code
 when it is running in the browser, </li><li>in <strong>WebApiConfig </strong>the JSON formatting has been set to camel case to make it easier to work with data returned from the Web API in Angular.
</li></ul>
<p>The BookController is a standard Web API 2 Entity Framework controller with two changes to provide the functionality required.</p>
<p>1. When saving a new book the Post action will catch any DbUpdateExceptions and return a BadRequest response containing the base exception message.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;POST:&nbsp;api/Books</span>&nbsp;
[ResponseType(<span class="cs__keyword">typeof</span>(Book))]&nbsp;
<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;IHttpActionResult&gt;&nbsp;Post(Book&nbsp;book)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;BadRequest(ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;db.Books.Add(book);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;db.SaveChangesAsync();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(DbUpdateException&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;BadRequest(ex.GetBaseException().Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;CreatedAtRoute(<span class="cs__string">&quot;DefaultApi&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id&nbsp;=&nbsp;book.Id&nbsp;},&nbsp;book);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>2. A new action <strong>TitleAvailable</strong>&nbsp;has been added. This accepts a title value and returns an OK (200) response or Bad request (400) depending on whether any existing books have the same title (case insensitive). Note this action is a POST
 action with the title in the body rather then a GET with the title in the URL. This is to allow for special characters in the title.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[HttpPost]&nbsp;
[ResponseType(<span class="cs__keyword">typeof</span>(<span class="cs__keyword">bool</span>))]&nbsp;
[Route(<span class="cs__string">&quot;api/books/titleavailable&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;IHttpActionResult&gt;&nbsp;TitleAvailable(TitleAvailableBindingModel&nbsp;query)&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Thread.Sleep.aspx" target="_blank" title="Auto generated link to System.Threading.Thread.Sleep">System.Threading.Thread.Sleep</a>(<span class="cs__number">2000</span>);&nbsp;<span class="cs__com">//slow&nbsp;down&nbsp;the&nbsp;response&nbsp;to&nbsp;see&nbsp;the&nbsp;async&nbsp;checking&nbsp;validation&nbsp;working</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;titleTaken&nbsp;=&nbsp;await&nbsp;db.Books.AnyAsync(b&nbsp;=&gt;&nbsp;query.Title.ToLower()&nbsp;==&nbsp;b.Title.ToLower());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Ok(<span class="cs__keyword">new</span>&nbsp;{&nbsp;titleAvailable&nbsp;=&nbsp;!titleTaken&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><span style="font-size:1.5em">SPA side (AngularJS)</span></h3>
<p>The SPA is in the app folder under the project root. It is a basic, single module SPA with two views to show the different approaches to the unique property validation.</p>
<p><img id="126783" src="126783-appfolders.jpg" alt="" width="163" height="145"></p>
<p>A resource service called <strong>bookClientSvc</strong> is used by both examples to communicate with the Book controller. A custom action called&nbsp;<strong>titleAvailable</strong> has been added which maps to the action of the same name on the controller.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">angular&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.module(<span class="js__string">'app'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.factory(<span class="js__string">'bookClientSvc'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($resource)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$resource(<span class="js__string">&quot;api/books/:id&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;id:&nbsp;<span class="js__string">&quot;@id&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'titleAvailable'</span>:&nbsp;<span class="js__brace">{</span>&nbsp;method:&nbsp;<span class="js__string">'POST'</span>,&nbsp;url:&nbsp;<span class="js__string">'api/books/titleAvailable'</span>,&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;title:&nbsp;<span class="js__string">'@title'</span>&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><span style="font-size:1.17em">Simple approach</span></h3>
<p>This example is made up of a view (<strong>simple.html</strong>) and a controller (<strong>simpleCtrl.js</strong>).</p>
<p><img id="126784" src="126784-simplefolders.jpg" alt="" width="140" height="56"></p>
<p>A user can enter a new book and as long as values have been provided for the title and author they can then click the save button. This will call the save function on the controller (see below). If the title of the new book is not unique the promise returned
 by the <strong>bookClientSvc save</strong> function will be rejected and any error returned.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;save()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.newBookForm.$valid)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.status.busy&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.status.message&nbsp;=&nbsp;<span class="js__string">&quot;saving&nbsp;book&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bookClientSvc.save($scope.book)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.$promise&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.then(<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.status.message&nbsp;=&nbsp;<span class="js__string">&quot;ready&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.books.push($scope.book);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(result.data&nbsp;&amp;&amp;&nbsp;result.data.message.indexOf(<span class="js__string">&quot;Cannot&nbsp;insert&nbsp;duplicate&nbsp;key&nbsp;row&nbsp;in&nbsp;object&nbsp;'dbo.Books'&nbsp;with&nbsp;unique&nbsp;index&nbsp;'IX_Title'&quot;</span>)&nbsp;&gt;&nbsp;-<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.status.message&nbsp;=&nbsp;<span class="js__string">&quot;a&nbsp;book&nbsp;with&nbsp;that&nbsp;title&nbsp;already&nbsp;exists&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.newBookForm.title.$setValidity(<span class="js__string">&quot;unique&quot;</span>,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.status.message&nbsp;=&nbsp;<span class="js__string">&quot;something&nbsp;went&nbsp;wrong&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="js__string">'finally'</span>](<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.status.busy&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>If the error is a unique validation error a custom validity property is set on the title which will then be show to the user (see the
<strong>has-error</strong> and <strong>ng-show</strong> bindings below).</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;newBookForm&quot;</span>&nbsp;<span class="html__attr_name">role</span>=<span class="html__attr_value">&quot;form&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;status.busy&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span>&nbsp;<span class="html__attr_name">ng-class</span>=<span class="html__attr_value">&quot;{'has-error':&nbsp;newBookForm.title.$error.unique&nbsp;||&nbsp;newBookForm.title.$error.required&nbsp;&amp;&amp;&nbsp;newBookForm.title.$touched}&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;title&quot;</span><span class="html__tag_start">&gt;</span>title<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;title&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__attr_name">ng-model</span>=<span class="html__attr_value">&quot;book.title&quot;</span>&nbsp;<span class="html__attr_name">ng-change</span>=<span class="html__attr_value">&quot;resetTitle()&quot;</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;enter&nbsp;title&quot;</span>&nbsp;<span class="html__attr_name">min</span>=<span class="html__attr_value">&quot;1&quot;</span>&nbsp;<span class="html__attr_name">max</span>=<span class="html__attr_value">&quot;255&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;status.busy&quot;</span>&nbsp;required<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-messages&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;newBookForm.title.$error&quot;</span>&nbsp;<span class="html__attr_name">ng-show</span>=<span class="html__attr_value">&quot;newBookForm.title.$touched&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-message&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&quot;</span>&nbsp;<span class="html__attr_name">when</span>=<span class="html__attr_value">&quot;required&quot;</span><span class="html__tag_start">&gt;</span>required&lt;/ng-message&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-message&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&quot;</span>&nbsp;<span class="html__attr_name">when</span>=<span class="html__attr_value">&quot;unique&quot;</span><span class="html__tag_start">&gt;</span>title&nbsp;must&nbsp;be&nbsp;unique&lt;/ng-message&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ng-messages&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
<span class="html__tag_end">&lt;/form&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Finally if any changes are made to the title after the validation error has been set it needs to be cleared again. This is done by the
<strong>resetTitle</strong> function (called by the <strong>ngChange</strong>&nbsp;directive on the title input).</p>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;resetTitle()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.newBookForm.title.$setValidity(<span class="js__string">&quot;unique&quot;</span>,&nbsp;true);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h3>Advanced approach</h3>
<p>This example is made up of a view (<strong>advanced.html</strong>), a controller (<strong>simpleCtrl.js</strong>) and also a directive&nbsp;<strong>unique.js</strong>.</p>
<p><img id="126785" src="126785-advanced.jpg" alt="" width="151" height="73"></p>
<p>The view is similar to the previous example however the <strong>unique</strong>&nbsp;directive has been declared on the title input with a function from the controller,
<strong>checkTitle</strong>&nbsp;passed as a parameter to it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;newBookForm&quot;</span>&nbsp;<span class="html__attr_name">role</span>=<span class="html__attr_value">&quot;form&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;status.busy&quot;</span>&nbsp;<span class="html__attr_name">ng-submit</span>=<span class="html__attr_value">&quot;save()&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span>&nbsp;<span class="html__attr_name">ng-class</span>=<span class="html__attr_value">&quot;{'has-error':&nbsp;newBookForm.title.$error.unique&nbsp;||&nbsp;newBookForm.title.$error.required&nbsp;&amp;&amp;&nbsp;newBookForm.title.$touched}&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;title&quot;</span><span class="html__tag_start">&gt;</span>title<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;title&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__attr_name">ng-model</span>=<span class="html__attr_value">&quot;book.title&quot;</span>&nbsp;<span class="html__attr_name">ng-model-options</span>=<span class="html__attr_value">&quot;{debounce:&nbsp;500}&quot;</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;enter&nbsp;title&quot;</span>&nbsp;<span class="html__attr_name">min</span>=<span class="html__attr_value">&quot;1&quot;</span>&nbsp;<span class="html__attr_name">max</span>=<span class="html__attr_value">&quot;255&quot;</span>&nbsp;<span class="html__attr_name">unique</span>=<span class="html__attr_value">&quot;checkTitle(title)&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;status.busy&quot;</span>&nbsp;required<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&quot;</span>&nbsp;<span class="html__attr_name">ng-if</span>=<span class="html__attr_value">&quot;newBookForm.title.$error.checking&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-messages&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;newBookForm.title.$error&quot;</span>&nbsp;<span class="html__attr_name">ng-show</span>=<span class="html__attr_value">&quot;newBookForm.title.$dirty&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-message&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&quot;</span>&nbsp;<span class="html__attr_name">when</span>=<span class="html__attr_value">&quot;checking&quot;</span><span class="html__tag_start">&gt;</span>checking&nbsp;title...&lt;/ng-message&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-message&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&quot;</span>&nbsp;<span class="html__attr_name">when</span>=<span class="html__attr_value">&quot;unique&quot;</span><span class="html__tag_start">&gt;</span>title&nbsp;must&nbsp;be&nbsp;unique&lt;/ng-message&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ng-messages&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-messages&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;newBookForm.title.$error&quot;</span>&nbsp;<span class="html__attr_name">ng-show</span>=<span class="html__attr_value">&quot;newBookForm.title.$touched&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ng</span>-message&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&quot;</span>&nbsp;<span class="html__attr_name">when</span>=<span class="html__attr_value">&quot;required&quot;</span><span class="html__tag_start">&gt;</span>required&lt;/ng-message&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ng-messages&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
<span class="html__tag_end">&lt;/form&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>This function can be seen below. It returns a promise which will be rejected immediately if the title&nbsp;is null or empty. Otherwise it will call
<strong>bookclientSvc.titleAvailable </strong>passing in the current title value as a parameter and return the resulting promise.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;checkTitle(title)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(title)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$q(<span class="js__operator">function</span>&nbsp;(resolve,&nbsp;reject)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bookClientSvc.titleAvailable(<span class="js__brace">{</span>&nbsp;title:&nbsp;title&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.$promise&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.then(<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(result.titleAvailable)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resolve(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reject(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resolve(<span class="js__string">&quot;unexpected&nbsp;error&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$q(<span class="js__operator">function</span>&nbsp;(resolve)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resolve();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>The <strong>unique</strong>&nbsp;directive takes the <strong>checkTitle</strong> function name as an attribute&nbsp;<strong>unique-function-name
</strong>and adds it to the ngModel.$asyncValidators (note the directive requires ngModel). Now Angular will set the the custom validation property
<strong>unique</strong>&nbsp;to the result of the promise returned by the function whenver the title value is changed. It also sets a temporary 'checking' validation error whilst waiting for the result of the promise in order to allow a message to be displayed
 to the user informing them that the validation check has not yet completed. This also means that the form will be invalid until the aysnc validation has completed, making it easy to prevent the user trying to save too early.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'use&nbsp;strict'</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;angular&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.module(<span class="js__string">'app'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.directive(<span class="js__string">'unique'</span>,&nbsp;unique);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unique.$inject&nbsp;=&nbsp;[];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;unique()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;directive&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;require:&nbsp;<span class="js__string">'ngModel'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;link:&nbsp;link,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;restrict:&nbsp;<span class="js__string">'A'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scope:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;unique:&nbsp;<span class="js__string">'&amp;'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;directive;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;link(scope,&nbsp;element,&nbsp;attrs,&nbsp;ngModel)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;wrappedValidator&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(mv,&nbsp;vv)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ngModel.$setValidity(<span class="js__string">'checking'</span>,&nbsp;false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;scope.unique(<span class="js__brace">{</span>&nbsp;title:&nbsp;mv&nbsp;||&nbsp;vv&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.<span class="js__statement">finally</span>(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ngModel.$setValidity(<span class="js__string">'checking'</span>,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ngModel.$asyncValidators.unique&nbsp;=&nbsp;wrappedValidator;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>)();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3>Advanced approach pre AngularJS 1.3</h3>
<p>I started writing this sample on version 1.2.6 of Angular and during the version 1.3 was released. Moving to this version allowed me to use the new $asyncValidators functionality. If you are using a previous version I have left in the old directive&nbsp;<strong>uniqueV12.js</strong>&nbsp;for
 you to use as a reference.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">angular&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.module(<span class="js__string">'app'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.directive(<span class="js__string">'uniqueV12'</span>,&nbsp;uniqueV12);&nbsp;
&nbsp;
uniqueV12.$inject&nbsp;=&nbsp;[<span class="js__string">'$parse'</span>];&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;uniqueV12($parse)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;directive&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;restrict:&nbsp;<span class="js__string">'A'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;require:&nbsp;<span class="js__string">'ngModel'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;link:&nbsp;link&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;directive;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;link(scope,&nbsp;element,&nbsp;attrs,&nbsp;ctrl)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fn&nbsp;=&nbsp;$parse(attrs[<span class="js__string">&quot;uniqueV12&quot;</span>]),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;checkUnique&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;fn(scope,&nbsp;<span class="js__brace">{</span>&nbsp;modelValue:&nbsp;ctrl.$modelValue,&nbsp;viewValue:&nbsp;ctrl.$viewValue&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl.$viewChangeListeners.push(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;checkUnique().then(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl.$setValidity(<span class="js__string">'unique'</span>,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctrl.$setValidity(<span class="js__string">'unique'</span>,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>It handles calling the unique validation function directly rather than adding it to the $asyncValidators, and then sets the unique validity depending on the result. To switch to it just change the directive on the title input from
<strong>unique</strong> to <strong>unique-v12</strong>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;newBookForm&quot;</span>&nbsp;<span class="html__attr_name">role</span>=<span class="html__attr_value">&quot;form&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;status.busy&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span>&nbsp;<span class="html__attr_name">ng-class</span>=<span class="html__attr_value">&quot;{'has-error':&nbsp;newBookForm.title.$error.unique}&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;title&quot;</span><span class="html__tag_start">&gt;</span>title<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;title&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__attr_name">ng-model</span>=<span class="html__attr_value">&quot;book.title&quot;</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;enter&nbsp;title&quot;</span>&nbsp;<span class="html__attr_name">min</span>=<span class="html__attr_value">&quot;1&quot;</span>&nbsp;<span class="html__attr_name">max</span>=<span class="html__attr_value">&quot;255&quot;</span>&nbsp;<span class="html__attr_name">unique-v12</span>=<span class="html__attr_value">&quot;checkTitle(modelValue,&nbsp;viewValue)&quot;</span>&nbsp;<span class="html__attr_name">ng-disabled</span>=<span class="html__attr_value">&quot;status.busy&quot;</span>&nbsp;required<span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&quot;</span>&nbsp;<span class="html__attr_name">ng-show</span>=<span class="html__attr_value">&quot;newBookForm.title.$error.unique&quot;</span><span class="html__tag_start">&gt;</span>title&nbsp;must&nbsp;be&nbsp;unique<span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;...&nbsp;
<span class="html__tag_end">&lt;/form&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Summary</h2>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p><span>If you have any questions or suggestions for improvement regarding this sample please feel free to leave them in the Q and A section.</span></p>
