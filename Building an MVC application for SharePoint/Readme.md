# Building an MVC application for SharePoint
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
- SharePoint Server 2013
- CSOM
## Topics
- SharePoint
- Web Development
## Updated
- 02/06/2016
## Description

<h1>The Right API</h1>
<p>Before we enter into the details of implementation of the ASP.NET MVC application that connects to SharePoint and retrieves data using the CSOM API, it is worth making a step back and understand what CSOM is and what the APIs that SharePoint makes available
 to programmers are.</p>
<p><strong>SharePoint 2013</strong> provides several sets of APIs, including the server object model, the various client object models, and the REST/OData web services. There are a few factors to consider for which API set to use, depending on:</p>
<ul>
<li><strong>The type of application</strong>: Whether you are developing a SharePoint add-in, a Web Part on a SharePoint page, an ASP.NET application exposed in SharePoint by an iframe, a .NET application running on a client computer, a Windows PowerShell script,
 or a mobile app. </li><li><strong>The programming language</strong> of your choice: Programming SharePoint is not exclusive of .NET developers. The JavaScript Client Side Object Model opens to any HTML-based applications to connect to a SharePoint backend, and the REST/OData web
 services allow any other platform to communicate with a SharePoint server. It is easily possible to create applications in SharePoint 2013 without needing to learn a lot about SharePoint programming.
</li><li><strong>The device</strong> on which the code runs: The possibilities include a server in the SharePoint farm, an external server such as a server in the cloud, a client computer, and a mobile device.
</li></ul>
<p>For more information about the SharePoint programming model, please refer to this article on MSDN:
<a href="https://msdn.microsoft.com/en-us/library/office/jj164060.aspx" target="_blank">
Choose the right API set in SharePoint 2013</a>.</p>
<p><img id="148234" src="148234-pic1.png" alt="" width="815" height="466"></p>
<p><em>SharePoint sets of APIs, from MSDN &ndash; Choose the right API set in SharePoint 2013.</em></p>
<p>&nbsp;</p>
<div>
<h1>The Client Side Object Model</h1>
<p>The SharePoint Client Side Object Model (<strong>CSOM</strong>) provides a programming interface for retrieving, updating, and managing data in SharePoint 2013. SharePoint 2013 makes the CSOM available in several forms. Specifically to .NET, almost every
 class in the core site and list server object model has a corresponding class in the .NET Framework client object model. This means that most of the functionalities of SharePoint Server are accessible to external applications using CSOM.</p>
<p>To improve performance, lines of code written against the .NET Framework client object model are sent to the SharePoint server in batches, where they are converted to server-side code and executed. The results, and the new state of all variables, are then
 returned to the client. We as the developer determine whether a batch runs synchronously or asynchronously. In a synchronous batch, the .NET Framework application waits for the returned results from the server before continuing; in an asynchronous batch, client-side
 processing continues immediately and the client user interface remains responsive.</p>
<p>Additionally, it is possible to use <strong>LINQ</strong> query syntax in our client code to query any
<strong>IEnumerable</strong> object, including SharePoint 2013 objects that implement the
<strong>IEnumerable</strong> interface. However, when doing this, we are using LINQ to Objects and not the LINQ to SharePoint provider.</p>
<p><img id="148235" src="148235-pic2.png" alt="" width="640" height="514"></p>
<p><em>Client applications and APIs in SharePoint.</em></p>
<p>&nbsp;</p>
</div>
<h1>The MVC Project</h1>
<p>Let&rsquo;s get started and create an ASP.NET MVC project in Visual Studio. As we are planning to use the SharePoint CSOM, we need to add a reference to the latest libraries. The assemblies for the .NET Framework client object model must be installed on
 the client. They are included in a redistributable package that you can obtain on the
<a href="https://www.microsoft.com/en-us/download/details.aspx?id=35585" target="_blank">
SharePoint Server 2013 Client Components SDK</a>.</p>
<p>Another option is to add a NuGet reference directly into the project; we need two packages:</p>
<ul>
<li>Microsoft.SharePoint.Client.Latest </li><li>Microsoft.SharePoint.Client.Runtime </li></ul>
<p><img id="148236" src="148236-image003.jpg" alt="" width="356" height="112"></p>
<p><em>Microsoft.SharePoint.Client package in NuGet.</em></p>
<p>&nbsp;</p>
<p>The MVC application that we want to build connects to a SharePoint site and displays a discussion list by category. For the purpose, I am using a SharePoint site created with the Community template, so I have the following lists already available:</p>
<ul>
<li>Categories </li><li>Discussion List </li></ul>
<p>&nbsp;<img id="148237" src="148237-image004.jpg" alt="" width="602" height="182"></p>
<p><em>Site Contents for a Community site in SharePoint 2013.</em></p>
<p>&nbsp;</p>
<p>A Category is identified by the following properties, which match to the equivalent model in the MVC application:</p>
<ul>
<li>Id </li><li>Name </li><li>Description </li></ul>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;Category&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Description&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>The Category model.</em></p>
<p>&nbsp;</p>
<p>When creating a discussion, we are presented with the following form:</p>
<p><img id="148239" src="148239-image005.jpg" alt="" width="387" height="308"></p>
<p><em>Adding a new item to the Discussion List in SharePoint.</em></p>
<p>&nbsp;</p>
<p>So our model reflects this structure:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class Discussion
{
    public string Subject { get; set; }

    public string Body { get; set; }

    [DisplayName(&quot;Question&quot;)]
    public bool IsQuestion { get; set; }

    public Category Category { get; set; }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;Discussion&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Subject&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Body&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DisplayName(<span class="cs__string">&quot;Question&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">bool</span>&nbsp;IsQuestion&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Category&nbsp;Category&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>The Discussion model.</em></p>
<p>&nbsp;</p>
<p>Now we need a controller with two actions:</p>
<ul>
<li><strong>Index</strong>: Retrieves the list of categories ordered by name. </li><li><strong>Discussion</strong>: Retrieves the list of discussions available for a specific category.
</li></ul>
<p>&nbsp;</p>
<p>For each of these actions, there is a view that displays the information obtained from SharePoint. More about the views later in this article.</p>
<p>Our controller, which for simplicity of design I call <strong>DefaultController</strong>, is implemented as follows:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class DefaultController : Controller
{
    // GET: Default
    public ActionResult Index()
    {
        using (var sp = new SharePointContext())
        {
            var categories = sp.Categories.OrderBy(c =&gt; c.Name);
            return View(categories);
        }
    }

    // GET: /discussion/{category}
    [Route(&quot;discussion/{category}&quot;)]
    public ActionResult Discussion(string category)
    {
        using (var sp = new SharePointContext())
        {
            var discussionList = sp.DiscussionList.Where(d =&gt; d.Category.Name == category);
            return View(discussionList);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;DefaultController&nbsp;:&nbsp;Controller&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET:&nbsp;Default</span><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;sp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharePointContext())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;categories&nbsp;=&nbsp;sp.Categories.OrderBy(c&nbsp;=&gt;&nbsp;c.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(categories);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET:&nbsp;/discussion/{category}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Route(<span class="cs__string">&quot;discussion/{category}&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Discussion(<span class="cs__keyword">string</span>&nbsp;category)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;sp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharePointContext())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;discussionList&nbsp;=&nbsp;sp.DiscussionList.Where(d&nbsp;=&gt;&nbsp;d.Category.Name&nbsp;==&nbsp;category);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(discussionList);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>The Default controller.</em></p>
<p>&nbsp;</p>
<p>A few things worth noticing here:</p>
<ol>
<li>The default action <strong>Index</strong> uses a disposable SharePoint context for obtaining a list of available categories, sorts them by name and then passes this collection to the view.
</li><li>The <strong>Discussion</strong> action has a custom route that responds to the URL /discussion/{category}, where {category} is the name of the category. When enabling attribute routing, which is available in MVC 5, it is necessary to activate these custom
 routes by calling the <strong>MapMvcAttributeRoutes</strong> method on the route collection in the
<strong>RegisterRoutes</strong> method of the <strong>RouteConfig</strong> class.
</li><li>From the SharePoint context, the actions retrieves a list of discussions in the given category, and passes this list to the view.
</li></ol>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute(&quot;{resource}.axd/{*pathInfo}&quot;);

        routes.MapMvcAttributeRoutes();

        routes.MapRoute(...);
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;RouteConfig&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;RegisterRoutes(RouteCollection&nbsp;routes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.IgnoreRoute(<span class="cs__string">&quot;{resource}.axd/{*pathInfo}&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.MapMvcAttributeRoutes();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.MapRoute(...);&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>The result that we want to obtain is similar to what in the screenshot below, a list of categories, and by clicking on their name, display all discussions for that category.</p>
<p><img id="148240" src="148240-image006.jpg" alt="" width="536" height="321"></p>
<p><em>List of categories in the MVC applications, directly from SharePoint.</em></p>
<p>&nbsp;</p>
<p>That makes the <strong>Index</strong> view really straightforward:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@model IEnumerable&lt;SharePointMvc.Models.Category&gt;

&lt;h2&gt;Categories&lt;/h2&gt;
&lt;ul&gt;
    @foreach (var category in Model)
    {
        &lt;li&gt;
            @Html.ActionLink(category.Name, &quot;Discussion&quot;, routeValues: new { category = category.Name })&lt;br /&gt;
            &lt;p&gt;@category.Description&lt;/p&gt;
        &lt;/li&gt;
    }
&lt;/ul&gt;
</pre>
<div class="preview">
<pre class="html">@model&nbsp;IEnumerable<span class="html__tag_start">&lt;SharePointMvc</span>.Models.Category<span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Categories<span class="html__tag_end">&lt;/h2&gt;</span><span class="html__tag_start">&lt;ul</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;@foreach&nbsp;(var&nbsp;category&nbsp;in&nbsp;Model)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ActionLink(category.Name,&nbsp;&quot;Discussion&quot;,&nbsp;routeValues:&nbsp;new&nbsp;{&nbsp;category&nbsp;=&nbsp;category.Name&nbsp;})<span class="html__tag_start">&lt;br</span><span class="html__tag_start">/&gt;</span><span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;@</span>category.Description<span class="html__tag_end">&lt;/p&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
<span class="html__tag_end">&lt;/ul&gt;</span></pre>
</div>
</div>
</div>
<p></p>
<p><em>The Index view.</em></p>
<p>&nbsp;</p>
<p>The model for this view is declared as an enumerable of <strong>Category</strong>, and for each category in this collection, the view creates an action link to the
<strong>Discussion</strong> action in the <strong>Default</strong> controller, passing the category name as route value.</p>
<p>Similarly, the <strong>Discussion</strong> view is as follows:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@model IEnumerable&lt;SharePointMvc.Models.Discussion&gt;

&lt;h2&gt;Discussion&lt;/h2&gt;

&lt;table class=&quot;table&quot;&gt;
    &lt;tr&gt;
        &lt;th&gt;
            @Html.DisplayNameFor(model =&gt; model.Subject)
        &lt;/th&gt;
        &lt;th&gt;
            @Html.DisplayNameFor(model =&gt; model.Body)
        &lt;/th&gt;
        &lt;th&gt;
            @Html.DisplayNameFor(model =&gt; model.IsQuestion)
        &lt;/th&gt;
    &lt;/tr&gt;
@foreach (var item in Model) {
    &lt;tr&gt;
        &lt;td&gt;
            @Html.DisplayFor(modelItem =&gt; item.Subject)
        &lt;/td&gt;
        &lt;td&gt;
            @Html.Raw(item.Body)
        &lt;/td&gt;
        &lt;td&gt;
            @Html.DisplayFor(modelItem =&gt; item.IsQuestion)
        &lt;/td&gt;
    &lt;/tr&gt;
}
&lt;/table&gt;
</pre>
<div class="preview">
<pre class="html">@model&nbsp;IEnumerable<span class="html__tag_start">&lt;SharePointMvc</span>.Models.Discussion<span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Discussion<span class="html__tag_end">&lt;/h2&gt;</span><span class="html__tag_start">&lt;table</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;table&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Subject)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.Body)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_start">&lt;th</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayNameFor(model&nbsp;=&gt;&nbsp;model.IsQuestion)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/th&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;
@foreach&nbsp;(var&nbsp;item&nbsp;in&nbsp;Model)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(modelItem&nbsp;=&gt;&nbsp;item.Subject)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.Raw(item.Body)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_start">&lt;td</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayFor(modelItem&nbsp;=&gt;&nbsp;item.IsQuestion)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span><span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;
}&nbsp;
<span class="html__tag_end">&lt;/table&gt;</span></pre>
</div>
</div>
</div>
<p></p>
<p><em>The Discussion view.</em></p>
<p>&nbsp;</p>
<h1>The SharePoint Context</h1>
<p>If you noticed the pattern used in the previous actions to obtain data from SharePoint, it is very similar to what Entity Framework exposes: A data context where collections of entities are defined, and the possibility to access these collections with LINQ.</p>
<p>In a similar way, our implementation of the SharePoint context follows the same pattern, by exposing collections of the models that we have defined in our MVC application. Because in this case we are only reading information from SharePoint, and not writing
 back (although technically possible), an enumerable would suffice.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class SharePointContext : IDisposable
{
    public IEnumerable&lt;Category&gt; Categories =&gt; LoadCategories();

    public IEnumerable&lt;Discussion&gt; DiscussionList =&gt; LoadDiscussionList();
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;SharePointContext&nbsp;:&nbsp;IDisposable&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Category&gt;&nbsp;Categories&nbsp;=&gt;&nbsp;LoadCategories();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Discussion&gt;&nbsp;DiscussionList&nbsp;=&gt;&nbsp;LoadDiscussionList();&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>Collection of models in the SharePoint context.</em></p>
<p>&nbsp;</p>
<p>First of all, the <strong>SharePointContext</strong> class implements the <strong>
IDisposable</strong> interface, so we can release the inner client context properly (more in a moment). Then, as anticipated,
<strong>Categories</strong> and <strong>DiscussionList</strong> are read-only properties that expose an enumerable collection of the
<strong>Category</strong> and <strong>Discussion</strong> models, respectively. Real time retrieval of data from SharePoint is implemented in two private methods.</p>
<p>The inner context is an instance of the <strong>ClientContext</strong> class defined in the SharePoint CSOM library. The
<strong>ClientContext</strong> class extends <strong>ClientRuntimeContext</strong>, which is disposable, hence the need for disposing
<strong>SharePointContext</strong> as well. All the <strong>ClientContext</strong> needs is the URL of the SharePoint site to which the MVC application is connecting; conveniently, this URL is stored in the Web.config and accessible via a static variable inside
 the <strong>SharePointContext</strong> class.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private ClientContext _context = new ClientContext(__sharepointUrl);

private static string __sharepointUrl =&gt; ConfigurationManager.AppSettings[&quot;SharePointUrl&quot;];
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;ClientContext&nbsp;_context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ClientContext(__sharepointUrl);&nbsp;
&nbsp;
<span class="cs__keyword">private</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;__sharepointUrl&nbsp;=&gt;&nbsp;ConfigurationManager.AppSettings[<span class="cs__string">&quot;SharePointUrl&quot;</span>];&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>Declaration of the ClientContext in the SharePointContext class.</em></p>
<p>&nbsp;</p>
<p>Disposing the client context follows the implementation of the <strong>Disposable</strong> pattern:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private bool disposedValue = false; // To detect redundant calls

protected virtual void Dispose(bool disposing)
{
    if (!disposedValue)
    {
        if (disposing)
        {
            _context.Dispose();
        }

        disposedValue = true;
    }
}

public void Dispose()
{
    Dispose(true);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">bool</span>&nbsp;disposedValue&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<span class="cs__com">//&nbsp;To&nbsp;detect&nbsp;redundant&nbsp;calls</span><span class="cs__keyword">protected</span><span class="cs__keyword">virtual</span><span class="cs__keyword">void</span>&nbsp;Dispose(<span class="cs__keyword">bool</span>&nbsp;disposing)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!disposedValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_context.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;disposedValue&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;Dispose()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dispose(<span class="cs__keyword">true</span>);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>Implementation of the Disposable pattern for disposing of the SharePoint client context.</em></p>
<p>&nbsp;</p>
<p>After building all this infrastructure around the SharePoint context, it is time to get to the
<em>juice</em> of it. :-) We have two tasks to accomplish:</p>
<ol>
<li>Retrieve a list of categories defined in SharePoint. </li><li>For a given category, retrieve a list of discussions. </li></ol>
<p>&nbsp;</p>
<p>The first task is implemented in the <strong>LoadCategories</strong> method:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private IEnumerable&lt;Category&gt; LoadCategories()
{
    Web web = _context.Web;
    _context.Load(web.Lists);
    _context.ExecuteQuery();

    List categoryList = web.Lists.GetByTitle(&quot;Categories&quot;);
    if (categoryList == null)
    {
        yield break;
    }

    CamlQuery query = CamlQuery.CreateAllItemsQuery();
    ListItemCollection categories = categoryList.GetItems(query);

    _context.Load(categories);
    _context.ExecuteQuery();

    foreach (var category in categories)
    {
        yield return new Category
        {
            Id = category.Id,
            Name = category[&quot;Title&quot;].ToString(),
            Description = category[&quot;CategoryDescription&quot;].ToString()
        };
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;IEnumerable&lt;Category&gt;&nbsp;LoadCategories()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Web&nbsp;web&nbsp;=&nbsp;_context.Web;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.Load(web.Lists);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.ExecuteQuery();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&nbsp;categoryList&nbsp;=&nbsp;web.Lists.GetByTitle(<span class="cs__string">&quot;Categories&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(categoryList&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CamlQuery&nbsp;query&nbsp;=&nbsp;CamlQuery.CreateAllItemsQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ListItemCollection&nbsp;categories&nbsp;=&nbsp;categoryList.GetItems(query);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.Load(categories);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.ExecuteQuery();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;category&nbsp;<span class="cs__keyword">in</span>&nbsp;categories)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">new</span>&nbsp;Category&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;category.Id,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;category[<span class="cs__string">&quot;Title&quot;</span>].ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Description&nbsp;=&nbsp;category[<span class="cs__string">&quot;CategoryDescription&quot;</span>].ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>The LoadCategories method in the SharePointContext class.</em></p>
<p>&nbsp;</p>
<p>The source code of <strong>LoadCategories</strong> is relatively simple to follow, even without a solid understating of how SharePoint works.</p>
<ol>
<li>First of all, we obtain a reference to the current site (<strong>Web</strong>) in the SharePoint context.
</li><li>The SharePoint CSOM data pattern always expects to load the desired object before accessing it; this is done by specifying the object to load in the
<strong>Load</strong> method, and then actually executing a query to retrieve it, via the
<strong>ExecuteQuery</strong> method on the SharePoint context instance. </li><li>We need to retrieve the &ldquo;Categories&rdquo; list, so we first load all available lists in the specified site, and then we get the specific list by title.
</li><li>Once we have access to the Categories list, we need to read its list items; this is done by executing a CAML (<a href="https://en.wikipedia.org/wiki/Collaborative_Application_Markup_Language" target="_blank">Collaborative Application Markup Language</a>)
 query. As we want to retrieve all existing categories, we can simply create a query that retrieves all items from the list.
</li><li>The list items are not available yet, we need to actually execute the query, and this is done, again, via the combination of
<strong>Load</strong> and <strong>ExecuteQuery</strong>. </li><li>Once obtained the list of categories, we can loop through them and read the necessary fields (Id, Title and Description) to create an instance of our MVC model
<strong>Category</strong> for each list item. </li></ol>
<p>&nbsp;</p>
<p>In a very similar way, the implementation of <strong>LoadDiscussionList</strong> follows the same steps seen before for the categories, with the obvious difference that we now want to retrieve items from the &ldquo;Discussions List&rdquo; list:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private IEnumerable&lt;Discussion&gt; LoadDiscussionList()
{
    Web web = _context.Web;
    _context.Load(web.Lists);
    _context.ExecuteQuery();

    List discussionList = web.Lists.GetByTitle(&quot;Discussions List&quot;);
    if (discussionList == null)
    {
        yield break;
    }

    CamlQuery query = CamlQuery.CreateAllItemsQuery();
    ListItemCollection discussions = discussionList.GetItems(query);

    _context.Load(discussions);
    _context.ExecuteQuery();

    foreach (var discussion in discussions)
    {
        var category = discussion[&quot;CategoriesLookup&quot;] as FieldLookupValue;

        yield return new Discussion
        {
            Subject = discussion[&quot;Title&quot;].ToString(),
            Body = discussion[&quot;Body&quot;].ToString(),
            IsQuestion = (bool)discussion[&quot;IsQuestion&quot;],
            Category = new Category { Id = category.LookupId, Name = category.LookupValue }
        };
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;IEnumerable&lt;Discussion&gt;&nbsp;LoadDiscussionList()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Web&nbsp;web&nbsp;=&nbsp;_context.Web;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.Load(web.Lists);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.ExecuteQuery();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&nbsp;discussionList&nbsp;=&nbsp;web.Lists.GetByTitle(<span class="cs__string">&quot;Discussions&nbsp;List&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(discussionList&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CamlQuery&nbsp;query&nbsp;=&nbsp;CamlQuery.CreateAllItemsQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ListItemCollection&nbsp;discussions&nbsp;=&nbsp;discussionList.GetItems(query);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.Load(discussions);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_context.ExecuteQuery();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;discussion&nbsp;<span class="cs__keyword">in</span>&nbsp;discussions)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;category&nbsp;=&nbsp;discussion[<span class="cs__string">&quot;CategoriesLookup&quot;</span>]&nbsp;<span class="cs__keyword">as</span>&nbsp;FieldLookupValue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">new</span>&nbsp;Discussion&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subject&nbsp;=&nbsp;discussion[<span class="cs__string">&quot;Title&quot;</span>].ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Body&nbsp;=&nbsp;discussion[<span class="cs__string">&quot;Body&quot;</span>].ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsQuestion&nbsp;=&nbsp;(<span class="cs__keyword">bool</span>)discussion[<span class="cs__string">&quot;IsQuestion&quot;</span>],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Category&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Category&nbsp;{&nbsp;Id&nbsp;=&nbsp;category.LookupId,&nbsp;Name&nbsp;=&nbsp;category.LookupValue&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p><em>The LoadDiscussionList method in the SharePointContext class.</em></p>
<p>&nbsp;</p>
<p>There is a lot of repeated code here, so a good refactoring is much expected, for example for loading the current site and a specific list. The notable difference, though, is in the loop through the list items. Besides the obvious difference in the field
 names, it is worth noticing that the reference to a <strong>Category</strong> in a SharePoint list is made via a
<strong>FieldLookupValue</strong> field. This object exposes two properties, the <strong>
LookupId</strong> and the <strong>LookupValue</strong>, which can be used to create an instance of our
<strong>Category</strong> model in the MVC application.</p>
