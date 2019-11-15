# Architecting Web application using ASP.NET MVC5, Web API2 and Knockoutjs
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Repository Pattern
- Code First
- Web API
- knockout.js
- Ninject
- MVC5
- Fluent validation framework
- JQuery BlockUI
## Topics
- Architecture and Design
## Updated
- 09/20/2018
## Description

<h1>Introduction</h1>
<p><em><em>In this article, I will show how to architect MVC5 application using Knockout. I have used simple application that create student information. In this app various design patterns and techniques used that promote(SoC) through the various layers of
 an n-tier application</em></em></p>
<h1>Architecture Overview&nbsp;</h1>
<p><strong>What is Layered architecture? :&nbsp;</strong>&nbsp;Logical layers are merely a way of organizing your code. in the application I have used five layers such as Common, Data Access, UI Services, domain and web project.</p>
<p><strong><strong>What is&nbsp;</strong>Ninject? :&nbsp;</strong>Dependency Injection (DI) is a design pattern that reduces hard-coded dependencies between your classes by injecting those dependencies at run-time&nbsp;</p>
<p><strong><strong>What is&nbsp;</strong>Repository Pattern? : &nbsp;</strong>The repository pattern is used to create an abstraction between your domain and data layer. That is, when you use the repository you should not have to have any knowledge about the
 underlying data source or the data layer (i.e. Entity Framework, nhibernate or similar)</p>
<p><strong><strong>What is&nbsp;</strong>KnokoutJs? :&nbsp;</strong>&nbsp;Knockout.js is a javascript library that allows us to bind html elements against any data model. It provides a simple two-way data binding mechanism between your data model and UI means
 any changes to data model are automatically reflected in the DOM(UI) and any changes to the DOM are automatically reflected to the data model.&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:medium; color:#ff6600"><strong>User Interface (UI)</strong></span></p>
<p><span style="font-size:medium; color:#ff6600"><strong><br>
</strong></span></p>
<p><strong>Form validation are done using MVC <a title="FluentValidation " href="http://fluentvalidation.codeplex.com/wikipage?title=mvc">
Fluentvalidation </a>and display validation messages as sliding bar with auto close.</strong></p>
<p><img id="108879" src="http://i1.code.msdn.s-msft.com/architecting-web-5dfc3130/image/file/108879/1/validation.jpg" alt="" width="660" height="378"></p>
<p>&nbsp;</p>
<p><img id="108880" src="http://i1.code.msdn.s-msft.com/architecting-web-5dfc3130/image/file/108880/1/success%20message.jpg" alt="" width="660" height="149"></p>
<p>&nbsp;</p>
<p><strong>Jquery <a title="BlockUI" href="http://malsup.com/jquery/block/">BlockUI
</a>for freezing screen while ajax submitting.</strong></p>
<p><img id="108881" src="http://i1.code.msdn.s-msft.com/architecting-web-5dfc3130/image/file/108881/1/wait%20message.jpg" alt="" width="660" height="311"></p>
<p><span style="color:#ff6600"><strong style="font-size:medium">Project Layers</strong></span></p>
<p><img id="108819" src="http://i1.code.msdn.s-msft.com/architecting-web-5dfc3130/image/file/108819/1/layered.jpg" alt="" width="660" height="206"></p>
<p>&nbsp;</p>
<p><span style="text-decoration:underline"><span style="font-size:medium"><strong><span style="color:#ff6600">Point of intersts</span></strong></span></span></p>
<p style="padding-left:60px">&nbsp;</p>
<p><span style="font-size:small; color:#000000"><strong>Web API2 and Attribute Routing.</strong></span></p>
<p><span style="font-size:small; color:#000000"><strong>WebAPI</strong> is an ideal platform for building pure HTTP based services where the request and response happens with HTTP protocol. The client can make a GET, PUT, POST, and DELETE request and get the
 WebAPI response appropriately.</span></p>
<p><span style="font-size:small; color:#000000"><span style="font-size:x-small"><span style="font-size:small"><strong>AttributeRouting</strong> for ASP.NET Web API lets you specify routes using attributes on your API controllers and actions.</span></span></span><span style="font-size:x-small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;App.Web.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[RoutePrefix(<span class="cs__string">&quot;api/students&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;StudentApiController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">readonly</span>&nbsp;IStudentService&nbsp;_studentService;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;StudentApiController(IStudentService&nbsp;studentService)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_studentService&nbsp;=&nbsp;studentService;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost(<span class="cs__string">&quot;create&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;HttpResponseMessage&nbsp;CreateStudent(StudentViewModel&nbsp;studentViewModel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;studentViewModel&nbsp;=&nbsp;new&nbsp;StudentViewModel();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TransactionStatus&nbsp;transactionStatus;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;results&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StudentValidation().Validate(studentViewModel);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!results.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentViewModel.Errors&nbsp;=&nbsp;GenerateErrorMessage.Built(results.Errors);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentViewModel.ErrorType&nbsp;=ErrorTypeEnum.Error.ToString().ToLower();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentViewModel.Status&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;badResponse&nbsp;=&nbsp;Request.CreateResponse(HttpStatusCode.BadRequest,&nbsp;studentViewModel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;badResponse;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;transactionStatus&nbsp;=&nbsp;_studentService.CreateStudent(BuiltStudentBo(studentViewModel));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(transactionStatus.Status&nbsp;==&nbsp;<span class="cs__keyword">false</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;badResponse&nbsp;=&nbsp;Request.CreateResponse(HttpStatusCode.BadRequest,&nbsp;JsonConvert.SerializeObject(studentViewModel));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;badResponse;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentViewModel.ErrorType&nbsp;=&nbsp;ErrorTypeEnum.Success.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;studentViewModel.ErrorType&nbsp;=&nbsp;ErrorTypeEnum.Info.ToString().ToLower();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;badResponse&nbsp;=&nbsp;Request.CreateResponse(HttpStatusCode.Created,&nbsp;studentViewModel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;badResponse;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>&nbsp;Code Explanation&nbsp;</strong></div>
<p><span style="font-size:small">In the </span><strong style="font-size:small">CreateStudent
</strong><span style="font-size:small">method template for&nbsp;</span><strong style="font-size:small">/api/students/create
</strong><span style="font-size:small">handle by&nbsp;&nbsp;</span><strong style="font-size:small">[HttpPost(&quot;create&quot;)]
</strong><span style="font-size:small">attribute routing feature indroduced in ASP.Net MVC 5</span></p>
<p><strong style="font-size:small">StudentApiController </strong><span style="font-size:small">Constructor, student data acees layer passed in order to serve its services without direcotly initiating service into controler.
</span><strong style="font-size:small">Here Dependenacy Injection DI </strong><span style="font-size:small">play it's role injecting service at run time. Primary use of &nbsp;DI is to create loosly copule layer &nbsp;for btter unit test purpose.</span></p>
<p><strong style="font-size:small">StudentValidation().Validate </strong><span style="font-size:small">method validate based on vlidate logic implemnted in validation class. I am using Fluent validation library to keep away validation logic from student ViewModel.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;StudentValidation&nbsp;&nbsp;:&nbsp;AbstractValidator&lt;StudentViewModel&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;StudentValidation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(x&nbsp;=&gt;&nbsp;x.FirstName).NotEmpty().WithMessage(<span class="cs__string">&quot;First&nbsp;Name&nbsp;cannot&nbsp;be&nbsp;blank&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(x&nbsp;=&gt;&nbsp;x.LastName).NotEmpty().WithMessage(<span class="cs__string">&quot;First&nbsp;Name&nbsp;cannot&nbsp;be&nbsp;blank&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(x&nbsp;=&gt;&nbsp;x.Subscribe).NotNull().WithMessage(<span class="cs__string">&quot;Select&nbsp;subscription&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(x&nbsp;=&gt;&nbsp;x.CountryId).NotEmpty().WithMessage(<span class="cs__string">&quot;Select&nbsp;Country&quot;</span>);&nbsp;
............&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><strong>MVVM - Model View View Model KnockoutJS</strong></h3>
<p><span style="font-size:small">Knockout is a standalone JavaScript implementation of the Model-View-View Model (MVVM) pattern. Knockout helps provide a clear separation between the presentation HTML markup and the data to be displayed. Knockout helps you
 easily associate DOM elements with Knockout's view model data using a concise, readable syntax. When your data model's state changes, your UI updates automatically</span></p>
<p><strong><span style="font-size:small">Ajax call to load country dropdown</span></strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode"><strong>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Load&nbsp;country</span>&nbsp;
<span class="js__operator">function</span>&nbsp;GetCountryLookup()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;countries&nbsp;=&nbsp;ko.observableArray([<span class="js__brace">{</span>&nbsp;CountryId:&nbsp;<span class="js__num">0</span>,&nbsp;CountryName:&nbsp;<span class="js__string">'Select&nbsp;Country'</span>&nbsp;<span class="js__brace">}</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.getJSON(<span class="js__string">&quot;/api/students/allcountries&quot;</span>,&nbsp;<span class="js__operator">function</span>(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ko.utils.arrayMap(result,&nbsp;<span class="js__operator">function</span>(item)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;countries.push(<span class="js__brace">{</span>&nbsp;CountryId:&nbsp;item.CountryId,&nbsp;CountryName:&nbsp;item.CountryName&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;countries;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</strong></div>
<div class="endscriptcode"><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">&nbsp;<span class="html__tag_start">&lt;select</span>&nbsp;<span class="html__attr_name">data-bind</span>=<span class="html__attr_value">&quot;options:&nbsp;CountryLookup,&nbsp;value:&nbsp;SelectedCountry,&nbsp;optionsText:&nbsp;&nbsp;
'CountryName'&nbsp;,optionsValue:'CountryId'&nbsp;&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/select&gt;</span></pre>
</div>
</div>
</div>
</strong></div>
<div class="scriptcode"><strong>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet(<span class="cs__string">&quot;allcountries&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;HttpResponseMessage&nbsp;GetLookupCountry()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;countires&nbsp;=&nbsp;_studentService.GetCountryLookup();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;badResponse&nbsp;=&nbsp;Request.CreateResponse(HttpStatusCode.OK,&nbsp;countires);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;badResponse;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</strong></div>
<p><strong>&nbsp;ViewModel&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;StudentViewModel()&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.StudentID&nbsp;=&nbsp;ko.observable(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.FirstName&nbsp;=&nbsp;ko.observable(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.LastName&nbsp;=&nbsp;ko.observable(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.Remarks&nbsp;=&nbsp;ko.observable(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.DateOfBirth&nbsp;=&nbsp;ko.observable(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.CountryLookup&nbsp;=&nbsp;GetCountryLookup();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.SelectedGender&nbsp;=&nbsp;ko.observable(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.SelectedCountry&nbsp;=&nbsp;ko.observable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.PaymentMethods&nbsp;=&nbsp;ko.observableArray([&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">&quot;Credit&nbsp;Card&quot;</span>,&nbsp;id:&nbsp;<span class="js__num">1</span>,&nbsp;isChecked:&nbsp;false&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">&quot;Cash&quot;</span>,&nbsp;id:&nbsp;<span class="js__num">2</span>,&nbsp;isChecked:&nbsp;false&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name:&nbsp;<span class="js__string">&quot;Bank&nbsp;Transfer&quot;</span>,&nbsp;id:&nbsp;<span class="js__num">3</span>,&nbsp;isChecked:&nbsp;false&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.SelectedPaymentMethods&nbsp;=&nbsp;ko.observableArray([]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.CreateStudent&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateStudent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</strong>Comeplete soruce code ataached, Please rate, if you are intrested
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="endscriptcode"></div>
<p><strong>&nbsp;</strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
</span></p>
