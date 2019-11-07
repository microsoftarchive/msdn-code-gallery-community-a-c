# Call WCF Service Using jQuery - Part 1
## Requires
- 
## License
- MIT
## Technologies
- C#
- JSON
- ASP.NET
- jQuery
- Javascript
- Entity Framework
- WCF Rest Service
## Topics
- WCF from jQuery &amp; using JSON for communication.
## Updated
- 10/07/2015
## Description

<h1>This sample contain the following method :</h1>
<ul>
<li>
<p><span style="font-size:small">Used WCF Service</span></p>
</li><li>
<p><span style="font-size:small">Configuration Setting for WCF in web.config</span></p>
</li><li>
<p><span style="font-size:small">Used JavaScript,JQuery and JSON.</span></p>
</li><li>
<p><span style="font-size:small">Insert,Update and Delete data without refreshing page</span></p>
</li></ul>
<h1><span>SQL Script for the Sample</span></h1>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">CREATE TABLE [dbo].[ProductInfo](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [ProductName] [varchar](max) NULL,  
    [ProductDescription] [varchar](max) NULL,  
    [CreatedDate] [datetime] DEFAULT GETDATE()  
)</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">ProductInfo</span>](&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Id</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__id">IDENTITY</span>(<span class="sql__number">1</span>,<span class="sql__number">1</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductName</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__id">max</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductDescription</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__id">max</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">CreatedDate</span>]&nbsp;[<span class="sql__keyword">datetime</span>]&nbsp;<span class="sql__keyword">DEFAULT</span>&nbsp;<span class="sql__id">GETDATE</span>()&nbsp;&nbsp;&nbsp;
)</pre>
</div>
</div>
</em></div>
<p><span style="font-size:20px; font-weight:bold">Configuration Setting for WCF</span><em>&nbsp;</em></p>
<ul>
<li>
<p><span style="font-size:small">&nbsp;This is service configuration setting.</span></p>
</li><li>
<p><span style="font-size:small">&nbsp;We need to add service end point and behavior setting in web.config file.</span></p>
</li><li>
<p><span style="font-size:small">&nbsp;there are so many way to host wcf service like self hosting, WAS, IIS and Window service.</span></p>
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;system.serviceModel&gt;  
  &lt;behaviors&gt;  
    &lt;endpointBehaviors&gt;  
      &lt;behavior name=&quot;AspNetAjaxBehavior&quot;&gt;  
        &lt;enableWebScript /&gt;  
      &lt;/behavior&gt;  
    &lt;/endpointBehaviors&gt;  
  &lt;/behaviors&gt;  
  &lt;serviceHostingEnvironment aspNetCompatibilityEnabled=&quot;true&quot; /&gt;  
  &lt;services&gt;  
    &lt;service name=&quot;WCFService.ProductService&quot;&gt;  
      &lt;endpoint behaviorConfiguration=&quot;AspNetAjaxBehavior&quot; binding=&quot;webHttpBinding&quot;  
       contract=&quot;WCFService.IProductService&quot; /&gt;  
    &lt;/service&gt;  
  &lt;/services&gt;  
&lt;/system.serviceModel&gt;</pre>
<div class="preview">
<pre class="csharp">&lt;system.serviceModel&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;behaviors&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;endpointBehaviors&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;behavior&nbsp;name=<span class="cs__string">&quot;AspNetAjaxBehavior&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;enableWebScript&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/behavior&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/endpointBehaviors&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;/behaviors&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;serviceHostingEnvironment&nbsp;aspNetCompatibilityEnabled=<span class="cs__string">&quot;true&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;services&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;service&nbsp;name=<span class="cs__string">&quot;WCFService.ProductService&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;endpoint&nbsp;behaviorConfiguration=<span class="cs__string">&quot;AspNetAjaxBehavior&quot;</span>&nbsp;binding=<span class="cs__string">&quot;webHttpBinding&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contract=<span class="cs__string">&quot;WCFService.IProductService&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/service&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;/services&gt;&nbsp;&nbsp;&nbsp;
&lt;/system.serviceModel&gt;</pre>
</div>
</div>
</div>
<ul>
<li><span style="color:#333333; font-family:Roboto,sans-serif; font-size:14px; line-height:21px">I add a script reference inside scriptmanager.</span><span style="color:#333333; font-family:Roboto,sans-serif; font-size:14px; line-height:21px">&nbsp;</span>
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;asp:ScriptManager runat=&quot;server&quot;&gt;  
     &lt;Scripts&gt;  
        &lt;asp:ScriptReference Path=&quot;~/Script/Product.js&quot; /&gt;  
      &lt;/Scripts&gt;  
      &lt;Services&gt;  
         asp:ServiceReference Path=&quot;~/ProductService.svc&quot; /&gt; 
      &lt;/Services&gt;  
&lt;/asp:ScriptManager&gt;</pre>
<div class="preview">
<pre class="js">&lt;asp:ScriptManager&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Scripts&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ScriptReference&nbsp;Path=<span class="js__string">&quot;~/Script/Product.js&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Scripts&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Services&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;asp:ServiceReference&nbsp;Path=<span class="js__string">&quot;~/ProductService.svc&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Services&gt;&nbsp;&nbsp;&nbsp;
&lt;/asp:ScriptManager&gt;</pre>
</div>
</div>
</div>
<h1>Service File</h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[ServiceContract(Namespace = &quot;WCFService&quot;)] 
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]    
public class ProductService
{    

    //my context
    readonly TestProductEntities _testProductEntities = new  TestProductEntities();    
  
    [OperationContract] 
    [WebInvoke(Method = &quot;POST&quot;, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]    
    public string LoadAllProductDetail()    
    {    
        try    
        {    
            var productDetail = (from s in _testProductEntities.ProductInfoes    
                                 select s).ToList();    
  
            var serializer = new JavaScriptSerializer();    
            return (serializer.Serialize(productDetail.ToList()));    
        }    
        catch (Exception ex)    
        {    
            throw ex;    
        }    
    }    
} </pre>
<div class="preview">
<pre class="js">[ServiceContract(Namespace&nbsp;=&nbsp;<span class="js__string">&quot;WCFService&quot;</span>)]&nbsp;&nbsp;
[AspNetCompatibilityRequirements(RequirementsMode&nbsp;=&nbsp;AspNetCompatibilityRequirementsMode.Allowed)]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
public&nbsp;class&nbsp;ProductService&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//my&nbsp;context</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;readonly&nbsp;TestProductEntities&nbsp;_testProductEntities&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;&nbsp;TestProductEntities();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(Method&nbsp;=&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;BodyStyle&nbsp;=&nbsp;WebMessageBodyStyle.WrappedRequest,&nbsp;RequestFormat&nbsp;=&nbsp;WebMessageFormat.Json,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;LoadAllProductDetail()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;productDetail&nbsp;=&nbsp;(from&nbsp;s&nbsp;<span class="js__operator">in</span>&nbsp;_testProductEntities.ProductInfoes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;s).ToList();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;serializer&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;JavaScriptSerializer();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;(serializer.Serialize(productDetail.ToList()));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;ex;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<h1>JS File</h1>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">$(document).ready(function () {  
    LoadProduct();  
});  
  
function BindProduct(results) {  
    var myJsonString = JSON.parse(results);  
    var string = &quot;&lt;table class='table table-bordered'&gt;&lt;tbody&gt;&quot;;  
    string &#43;= '&lt;tr&gt;&lt;th&gt;Name&lt;/th&gt;&lt;th&gt;Description&lt;/th&gt;&lt;th colspan=&quot;2&quot;&gt;Action&lt;/th&gt;&lt;/tr&gt;';  
    if (myJsonString.length &gt; 0) {  
        for (var i = 0; i &lt; myJsonString.length; i&#43;&#43;) {  
            string &#43;= '&lt;tr&gt;&lt;td&gt;' &#43; myJsonString[i].ProductName &#43; '&lt;/td&gt;';  
            string &#43;= '&lt;td&gt;' &#43; myJsonString[i].ProductDescription &#43; '&lt;/td&gt;';  
            string &#43;= '&lt;td&gt;&lt;span&gt;&lt;a href=&quot;javascript:void(0);&quot; ' &#43; ' onclick=&quot;EditProduct(' &#43; myJsonString[i].Id &#43; ');&quot;&gt;';  
            string &#43;= '&lt;img width=&quot;16&quot; height=&quot;16&quot; alt=&quot;Close&quot; src=&quot;Image/Edit.jpg&quot; /&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;';  
            string &#43;= '&lt;td&gt;&lt;span&gt;&lt;a href=&quot;javascript:void(0);&quot; ' &#43; ' onclick=&quot;DeleteProduct(' &#43; myJsonString[i].Id &#43; ');&quot;&gt;';  
            string &#43;= '&lt;img width=&quot;16&quot; height=&quot;16&quot; alt=&quot;Close&quot; src=&quot;Image/close.png&quot; /&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;&lt;/tr&gt;';  
        }  
    }  
    string = string &#43; &quot;&lt;/tbody&gt;&lt;/table&gt;&quot;;  
    $(&quot;#bindProduct&quot;).html(string);  
}  
  
function LoadProduct() {  
    WCFService.IProductService.LoadAllProductDetail(BindProduct, LoadProduct_success, LoadProduct_fail);  
}  
  
function LoadProduct_success() {  
  
}  
  
function LoadProduct_fail() {  
    alert(&quot;LoadProduct_fail&quot;);  
}</pre>
<div class="preview">
<pre class="js">$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LoadProduct();&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;BindProduct(results)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;myJsonString&nbsp;=&nbsp;JSON.parse(results);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;string&nbsp;=&nbsp;<span class="js__string">&quot;&lt;table&nbsp;class='table&nbsp;table-bordered'&gt;&lt;tbody&gt;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;tr&gt;&lt;th&gt;Name&lt;/th&gt;&lt;th&gt;Description&lt;/th&gt;&lt;th&nbsp;colspan=&quot;2&quot;&gt;Action&lt;/th&gt;&lt;/tr&gt;'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(myJsonString.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;myJsonString.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;tr&gt;&lt;td&gt;'</span>&nbsp;&#43;&nbsp;myJsonString[i].ProductName&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;td&gt;'</span>&nbsp;&#43;&nbsp;myJsonString[i].ProductDescription&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;td&gt;&lt;span&gt;&lt;a&nbsp;href=&quot;javascript:void(0);&quot;&nbsp;'</span>&nbsp;&#43;&nbsp;<span class="js__string">'&nbsp;onclick=&quot;EditProduct('</span>&nbsp;&#43;&nbsp;myJsonString[i].Id&nbsp;&#43;&nbsp;<span class="js__string">');&quot;&gt;'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;img&nbsp;width=&quot;16&quot;&nbsp;height=&quot;16&quot;&nbsp;alt=&quot;Close&quot;&nbsp;src=&quot;Image/Edit.jpg&quot;&nbsp;/&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;td&gt;&lt;span&gt;&lt;a&nbsp;href=&quot;javascript:void(0);&quot;&nbsp;'</span>&nbsp;&#43;&nbsp;<span class="js__string">'&nbsp;onclick=&quot;DeleteProduct('</span>&nbsp;&#43;&nbsp;myJsonString[i].Id&nbsp;&#43;&nbsp;<span class="js__string">');&quot;&gt;'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;img&nbsp;width=&quot;16&quot;&nbsp;height=&quot;16&quot;&nbsp;alt=&quot;Close&quot;&nbsp;src=&quot;Image/close.png&quot;&nbsp;/&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;&lt;/tr&gt;'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;=&nbsp;string&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/tbody&gt;&lt;/table&gt;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#bindProduct&quot;</span>).html(string);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;LoadProduct()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WCFService.IProductService.LoadAllProductDetail(BindProduct,&nbsp;LoadProduct_success,&nbsp;LoadProduct_fail);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;LoadProduct_success()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;LoadProduct_fail()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;LoadProduct_fail&quot;</span>);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h1>Download Source Code :&nbsp;<a id="143333" href="/Call-WCF-Service-Using-5cb8ea71/file/143333/1/WCFDemoApplication.rar">WCFDemoApplication.rar</a></h1>
<p>&nbsp;</p>
<h1>Test Output Here :&nbsp;<span style="font-size:small"><a class="title" title="Test Here" href="http://www.wcfdemo.somee.com/" target="_blank">http://www.wcfdemo.somee.com/</a></span></h1>
<h1>Output Image</h1>
<p><img id="143329" src="143329-2015-10-07_1223.png" alt="" width="592" height="402"></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small"><br>
</span></strong></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:452px; width:1px; height:1px; overflow:hidden">
<div class="page" style="outline:none 0px; width:1024px; margin:0px auto; color:#8d8d8d; font-family:Roboto,sans-serif; font-size:14px">
<div class="main responsive_marginTop" style="outline:none 0px; width:1024px; float:left; margin-top:5px; min-height:430px; z-index:0; height:auto!important">
<div class="leftCntr" style="outline:none 0px; width:676px; float:left">
<div class="PaddingLeft5" id="div2" style="outline:none 0px; color:#333333; float:left; padding:0px 0px 0px 10px; width:664px; line-height:21px">
<div style="outline:none 0px">
<ul style="outline:none 0px">
<li style="outline:none 0px"><span style="outline:none 0px">&nbsp;</span> </li></ul>
</div>
<div style="outline:none 0px">
<div class="dp-highlighter" style="outline:none 0px; font-family:Consolas,'Courier New',Courier,mono,serif; font-size:12px; width:657.359px; overflow:auto; padding-top:1px; margin:18px 0px!important; background-color:#e7e5dc">
<div class="bar" style="outline:none 0px; padding-left:45px"></div>
<ol class="dp-vb" style="outline:none 0px; padding:0px; border:none; color:#5c5c5c; margin:0px 1px 1px 45px!important; background-color:#ffffff">
<li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&lt;asp:ScriptManager&nbsp;runat=</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;server&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&gt;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp; &nbsp; &nbsp;&lt;Scripts&gt;&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ScriptReference&nbsp;Path=<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;~/Script/Product.js&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;/&gt;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp; &nbsp; &nbsp; &lt;/Scripts&gt;&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp; &nbsp; &nbsp; &lt;Services&gt;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;asp:ServiceReference&nbsp;Path=<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;~/ProductService.svc&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;/&gt;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp; &nbsp; &nbsp; &lt;/Services&gt;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&lt;/asp:ScriptManager&gt;&nbsp;&nbsp;</span>
</li></ol>
</div>
<strong style="outline:none 0px">IproductService.cs page</strong></div>
<div style="outline:none 0px">
<ul style="outline:none 0px">
<li style="outline:none 0px"><span style="outline:none 0px">&nbsp;The following interface method contain insert, update, delete definition only which is used in service call.<br style="outline:none 0px">
<div class="dp-highlighter" style="outline:none 0px; font-family:Consolas,'Courier New',Courier,mono,serif; font-size:12px; width:617.75px; overflow:auto; padding-top:1px; margin:18px 0px!important; background-color:#e7e5dc">
<div class="bar" style="outline:none 0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:none 0px; padding:0px; border:none; color:#5c5c5c; margin:0px 1px 1px 45px!important; background-color:#ffffff">
<li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">[ServiceContract(Namespace&nbsp;=&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;WCFService&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">)]&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">interface</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;IProductService&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">{&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">void</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;AddProductDetail(</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">string</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;productName,&nbsp;</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">string</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;productDescription);&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">void</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;UpdateProductDetail(</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">int</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;updateId,&nbsp;</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">string</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;productName,&nbsp;</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">string</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;productDescription);&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">void</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;DeleteProductDetail(</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">int</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;id);&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">string</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;EditProductDetail(</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">int</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;id);&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">string</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;LoadAllProductDetail();&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li></ol>
</div>
</span></li></ul>
</div>
<div style="outline:none 0px"><strong style="outline:none 0px">productService.cs page</strong></div>
<div style="outline:none 0px">
<ul style="outline:none 0px">
<li style="outline:none 0px"><span style="outline:none 0px">&nbsp;This file contain functionality which is mentioned in the above interface file. &nbsp;<br style="outline:none 0px">
<div class="dp-highlighter" style="outline:none 0px; font-family:Consolas,'Courier New',Courier,mono,serif; font-size:12px; width:617.75px; overflow:auto; padding-top:1px; margin:18px 0px!important; background-color:#e7e5dc">
<div class="bar" style="outline:none 0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:none 0px; padding:0px; border:none; color:#5c5c5c; margin:0px 1px 1px 45px!important; background-color:#ffffff">
<li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">[AspNetCompatibilityRequirements(RequirementsMode&nbsp;=&nbsp;AspNetCompatibilityRequirementsMode.Allowed)]&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">public</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">class</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;ProductService&nbsp;:&nbsp;IProductService&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">{&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="preprocessor" style="outline:none 0px; margin:0px; padding:0px; border:none; color:gray; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;&nbsp;IproductService&nbsp;Member&nbsp;&nbsp;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">readonly</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;TestProductEntities&nbsp;_testProductEntities&nbsp;=&nbsp;</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">new</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;TestProductEntities();&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(Method&nbsp;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;POST&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">,&nbsp;BodyStyle&nbsp;=&nbsp;WebMessageBodyStyle.WrappedRequest,&nbsp;RequestFormat&nbsp;=&nbsp;WebMessageFormat.Json,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">public</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">string</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;LoadAllProductDetail()&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">try</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;productDetail&nbsp;=&nbsp;(from&nbsp;s&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">in</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;_testProductEntities.ProductInfoes&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;s).ToList();&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;serializer&nbsp;=&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">new</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;JavaScriptSerializer();&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">return</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;(serializer.Serialize(productDetail.ToList()));&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">catch</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;(Exception&nbsp;ex)&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">throw</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;ex;&nbsp;&nbsp;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="preprocessor" style="outline:none 0px; margin:0px; padding:0px; border:none; color:gray; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;&nbsp;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</span></li></ul>
</div>
<div style="outline:none 0px"><strong style="outline:none 0px">product.js page</strong></div>
<div style="outline:none 0px">
<ul style="outline:none 0px">
<li style="outline:none 0px">&nbsp;<span style="outline:none 0px">This is my javascript file and highlighted area displays my service call.</span>
</li></ul>
<div style="outline:none 0px">
<div class="dp-highlighter" style="outline:none 0px; font-family:Consolas,'Courier New',Courier,mono,serif; font-size:12px; width:657.359px; overflow:auto; padding-top:1px; margin:18px 0px!important; background-color:#e7e5dc">
<div class="bar" style="outline:none 0px; padding-left:45px"></div>
<ol class="dp-c" style="outline:none 0px; padding:0px; border:none; color:#5c5c5c; margin:0px 1px 1px 45px!important; background-color:#ffffff">
<li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">$(document).ready(</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">function</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;()&nbsp;{&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;LoadProduct();&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">});&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">function</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;BindProduct(results)&nbsp;{&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">var</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;myJsonString&nbsp;=&nbsp;JSON.parse(results);&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">var</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;string&nbsp;=&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&lt;table&nbsp;class='table&nbsp;table-bordered'&gt;&lt;tbody&gt;&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;tr&gt;&lt;th&gt;Name&lt;/th&gt;&lt;th&gt;Description&lt;/th&gt;&lt;th&nbsp;colspan=&quot;2&quot;&gt;Action&lt;/th&gt;&lt;/tr&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">if</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;(myJsonString.length&nbsp;&gt;&nbsp;0)&nbsp;{&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">for</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;(</span><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">var</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;i&nbsp;=&nbsp;0;&nbsp;i&nbsp;&lt;&nbsp;myJsonString.length;&nbsp;i&#43;&#43;)&nbsp;{&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;tr&gt;&lt;td&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&#43;&nbsp;myJsonString[i].ProductName&nbsp;&#43;&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;/td&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;td&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&#43;&nbsp;myJsonString[i].ProductDescription&nbsp;&#43;&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;/td&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;td&gt;&lt;span&gt;&lt;a&nbsp;href=&quot;javascript:void(0);&quot;&nbsp;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&#43;&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&nbsp;onclick=&quot;EditProduct('</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&#43;&nbsp;myJsonString[i].Id&nbsp;&#43;&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">');&quot;&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;img&nbsp;width=&quot;16&quot;&nbsp;height=&quot;16&quot;&nbsp;alt=&quot;Close&quot;&nbsp;src=&quot;Image/Edit.jpg&quot;&nbsp;/&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;td&gt;&lt;span&gt;&lt;a&nbsp;href=&quot;javascript:void(0);&quot;&nbsp;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&#43;&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&nbsp;onclick=&quot;DeleteProduct('</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;&#43;&nbsp;myJsonString[i].Id&nbsp;&#43;&nbsp;</span><span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">');&quot;&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;&#43;=&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">'&lt;img&nbsp;width=&quot;16&quot;&nbsp;height=&quot;16&quot;&nbsp;alt=&quot;Close&quot;&nbsp;src=&quot;Image/close.png&quot;&nbsp;/&gt;&lt;/a&gt;&lt;/span&gt;&lt;/td&gt;&lt;/tr&gt;'</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;=&nbsp;string&nbsp;&#43;&nbsp;<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;&lt;/tbody&gt;&lt;/table&gt;&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">;&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;#bindProduct&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">).html(string);&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">function</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;LoadProduct()&nbsp;{&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;WCFService.IProductService.LoadAllProductDetail(BindProduct,&nbsp;LoadProduct_success,&nbsp;LoadProduct_fail);&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">function</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;LoadProduct_success()&nbsp;{&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;</span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit"><span class="keyword" style="outline:none 0px; margin:0px; padding:0px; border:none; color:#006699; font-weight:bold; background-color:inherit">function</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">&nbsp;LoadProduct_fail()&nbsp;{&nbsp;&nbsp;</span></span>
</li><li style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important; background-color:#f8f8f8">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="string" style="outline:none 0px; margin:0px; padding:0px; border:none; color:blue; background-color:inherit">&quot;LoadProduct_fail&quot;</span><span style="outline:none 0px; margin:0px; padding:0px; border:none; background-color:inherit">);&nbsp;&nbsp;</span></span>
</li><li class="alt" style="outline:none 0px; border-style:none none none solid; border-left-width:3px; border-left-color:#6ce26c; list-style:decimal-leading-zero outside; color:inherit; line-height:14px; margin:0px!important; padding:0px 3px 0px 10px!important">
<span style="outline:none 0px; margin:0px; padding:0px; border:none; color:black; background-color:inherit">}&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
<div style="outline:none 0px"><strong style="outline:none 0px">Output&nbsp;<br style="outline:none 0px">
<br style="outline:none 0px">
You can also test the output&nbsp;<a title="Click Here" href="http://www.wcfdemo.somee.com/" style="outline:none 0px; text-decoration:none; color:#0000ff">here</a><br style="outline:none 0px">
<br style="outline:none 0px">
<img src="-output.jpg" alt="output" style="outline:none 0px; border-style:none; border-width:initial"></strong></div>
</div>
<p style="outline:none 0px">&nbsp;</p>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div class="auther_bio" style="outline:none 0px; border-top-width:1px; border-top-style:dashed; border-top-color:#dee2e7; overflow:hidden; padding:18px 0px; width:676px">
<a id="ctl00_AboutAuthor1_AuthorImageAnchor" class="image" href="http://www.c-sharpcorner.com/authors/kunal-patel12" style="outline:none 0px; text-decoration:none; display:block; float:left; margin-right:20px; overflow:hidden"><img id="ctl00_AboutAuthor1_AuthorImage" src="-8af67520140415010943.jpg" alt="Kunal Patel" style="outline:none 0px; border-style:none; border-width:initial; height:100px; width:100px"></a>
<div class="autherDetail" style="outline:none 0px"><a id="ctl00_AboutAuthor1_AuthorName" class="userName" href="http://www.c-sharpcorner.com/authors/kunal-patel12" style="outline:none 0px; text-decoration:none; color:#ff6600; font-family:BebasNeueRegular; font-size:26px; padding:0px">Kunal
 Patel</a>
<p id="ctl00_AboutAuthor1_Description" class="description" style="outline:none 0px; color:#525252; line-height:22px; margin:6px 0px 10px">
&nbsp;</p>
<ul class="social" style="outline:none 0px; margin:0px; padding:0px; right:0px; top:12px">
<li class="twitter" style="outline:none 0px; display:block; float:left; list-style:none outside none">
<a id="ctl00_AboutAuthor1_TwitterFollow" title="Follow on Twitter" href="https://twitter.com/intent/follow?screen_name=kunalptl6" style="outline:none 0px; text-decoration:none; display:block; height:32px; line-height:28px; margin-left:10px; text-indent:-9999px; width:32px">Follow</a>
</li><li class="facebook" style="outline:none 0px; display:block; float:left; list-style:none outside none">
<a id="ctl00_AboutAuthor1_FacebookProfileUrl" title="Facebook" href="https://www.facebook.com/krpatel1991" style="outline:none 0px; text-decoration:none; display:block; height:32px; line-height:28px; margin-left:10px; text-indent:-9999px; width:32px">Facebook</a>
</li><li class="linkedIn" style="outline:none 0px; display:block; float:left; list-style:none outside none">
<a id="ctl00_AboutAuthor1_LinkedInProfileUrl" title="LinkedIn" href="https://in.linkedin.com/pub/kunal-patel/53/a0b/b86" style="outline:none 0px; text-decoration:none; display:block; height:32px; line-height:28px; margin-left:10px; text-indent:-9999px; width:32px">LinkedIn</a>
</li></ul>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div class="autherIcons" style="outline:none 0px; margin:13px 0px 0px; overflow:hidden; width:676px">
<ul style="outline:none 0px; display:table-row; list-style:none outside none; margin:0px; overflow:hidden; padding:0px; text-align:center">
<li class="li_1" style="outline:none 0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:1px 16px 0px 55px">
<a href="http://www.c-sharpcorner.com/Members/rank/" style="outline:none 0px; text-decoration:none"><span class="rank" style="outline:none 0px; display:block; height:46px; left:11px; top:0px; width:42px">&nbsp;</span><span class="text" style="outline:none 0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:19px; text-transform:capitalize">Rank</span><span id="ctl00_AboutAuthor1_Rank" class="count" style="outline:none 0px; color:#616161; display:block; font-size:24px; font-family:proximanova-bold">599</span></a>
</li><li class="li_2" style="outline:none 0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:0px 16px 0px 66px">
<a href="http://www.c-sharpcorner.com/Articles/AuthorTopArticles.aspx?authorid=8af675" style="outline:none 0px; text-decoration:none"><span class="reader" style="outline:none 0px; display:block; height:48px; left:11px; top:0px; width:50px">&nbsp;</span><span id="ctl00_AboutAuthor1_Readers" class="count" style="outline:none 0px; color:#616161; display:block; font-size:24px; font-family:proximanova-bold">28.8k</span><span class="text" style="outline:none 0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:15px; text-transform:capitalize">Read</span></a>
</li><li class="li_4" style="outline:none 0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:15px 16px 0px 48px">
<span id="ctl00_AboutAuthor1_Medal" class="medal Starter" title="Starter Member" style="outline:none 0px; display:block; height:55px; left:11px; top:0px; width:31px">&nbsp;</span><span id="ctl00_AboutAuthor1_MedalText" class="count x_x_x_x_x_x_Starter" style="outline:none 0px; color:#348ae7; display:block; font-size:24px; font-family:proximanova-regular; margin-top:-15px">Starter</span><span class="text" style="outline:none 0px; font-family:proximanova-regular; color:#b0b0b0; display:block; font-size:18px; line-height:15px; text-transform:capitalize">Member</span>
</li><li id="ctl00_AboutAuthor1_CSharpMVP" class="li_3 notSet" title="C# Corner MVP - Not awarded yet." style="outline:none 0px; display:inline-block; height:58px; text-align:center; vertical-align:middle; float:left; padding:0px 16px 0px 77px; border-right-width:medium; border-right-style:none">
<a href="http://www.c-sharpcorner.com/Members/mvps/" style="outline:none 0px; text-decoration:none"><span class="csharpmvp" style="outline:none 0px; display:block; height:50px; left:11px; top:0px; width:60px">&nbsp;</span></a>
</li></ul>
</div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div class="relatedArticle" id="ctl00_RelatedArticles" style="outline:none 0px; width:676px; float:left; padding:15px 0px 0px">
<h3 style="outline:none 0px; font-size:20px; text-transform:uppercase; color:#727272; padding:0px; margin:0px 0px 10px; font-family:BebasNeueRegular; font-weight:normal">
RELATED ARTICLES</h3>
<ul style="outline:none 0px; list-style:none; padding:0px 5px 0px 0px; overflow:hidden; margin:0px -15px 0px 0px">
<li style="outline:none 0px; width:308.688px; float:left; padding:0px 15px 0px 18px; line-height:20px">
<span class="bullet" style="outline:none 0px; height:6px; width:6px; top:8px; left:0px">&nbsp;</span><a id="ctl00_RepeaterSimilarArticles_ctl00_HyperLinkTitle" href="http://www.c-sharpcorner.com/uploadfile/ledomoon/creating-active-directory-service-using-wcf/default.aspx" style="outline:none 0px; text-decoration:none; color:#7a7a7a; display:inline-block; margin-left:-5px; float:left">Creating
 Active Directory Service using WCF</a> </li><li style="outline:none 0px; width:308.688px; float:left; padding:0px 15px 0px 18px; line-height:20px">
<span class="bullet" style="outline:none 0px; height:6px; width:6px; top:8px; left:0px">&nbsp;</span><a id="ctl00_RepeaterSimilarArticles_ctl01_HyperLinkTitle" href="http://www.c-sharpcorner.com/UploadFile/krishnasarala/hosting-wcf-service-under-windows-service/" style="outline:none 0px; text-decoration:none; color:#7a7a7a; display:inline-block; margin-left:-5px; float:left">Hosting
 a WCF Service Under a Windows Service</a> </li><li style="outline:none 0px; width:308.688px; float:left; padding:0px 15px 0px 18px; line-height:20px">
<span class="bullet" style="outline:none 0px; height:6px; width:6px; top:8px; left:0px">&nbsp;</span><a id="ctl00_RepeaterSimilarArticles_ctl02_HyperLinkTitle" href="http://www.c-sharpcorner.com/UploadFile/rohatash/calling-wcf-services-using-jquery/" style="outline:none 0px; text-decoration:none; color:#7a7a7a; display:inline-block; margin-left:-5px; float:left">Calling
 WCF Services Using jQuery</a> </li><li style="outline:none 0px; width:308.688px; float:left; padding:0px 15px 0px 18px; line-height:20px">
<span class="bullet" style="outline:none 0px; height:6px; width:6px; top:8px; left:0px">&nbsp;</span><a id="ctl00_RepeaterSimilarArticles_ctl03_HyperLinkTitle" href="http://www.c-sharpcorner.com/UploadFile/4b0136/consuming-wcf-service-using-javascript/" style="outline:none 0px; text-decoration:none; color:#7a7a7a; display:inline-block; margin-left:-5px; float:left">Consuming
 WCF Service Using JavaScript</a> </li><li style="outline:none 0px; width:308.688px; float:left; padding:0px 15px 0px 18px; line-height:20px">
<span class="bullet" style="outline:none 0px; height:6px; width:6px; top:8px; left:0px">&nbsp;</span><a id="ctl00_RepeaterSimilarArticles_ctl04_HyperLinkTitle" href="http://www.c-sharpcorner.com/UploadFile/rahul4_saxena/create-and-consume-wcf-restful-service-using-jquery/" style="outline:none 0px; text-decoration:none; color:#7a7a7a; display:inline-block; margin-left:-5px; float:left">Create
 and Consume WCF Restful Service Using jQuery</a> </li><li style="outline:none 0px; width:308.688px; float:left; padding:0px 15px 0px 18px; line-height:20px">
<span class="bullet" style="outline:none 0px; height:6px; width:6px; top:8px; left:0px">&nbsp;</span><a id="ctl00_RepeaterSimilarArticles_ctl05_HyperLinkTitle" href="http://www.c-sharpcorner.com/uploadfile/dhananjaycoder/webservicehost-hosting-a-wcf-rest-service/default.aspx" style="outline:none 0px; text-decoration:none; color:#7a7a7a; display:inline-block; margin-left:-5px; float:left">WebServiceHost:
 Hosting a WCF REST Service</a> </li></ul>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div class="article" style="outline:none 0px; width:676px"><a name="ReadAndPostComment" style="outline:none 0px"></a>
<div class="commentHeader" style="outline:none 0px; padding:15px 0px 0px; margin-bottom:5px; overflow:hidden">
<h2 class="headerControls" style="outline:none 0px; margin:0px; padding:0px; height:30px; line-height:30px; font-size:20px; font-family:BebasNeueRegular; color:#727272; font-weight:normal; text-transform:uppercase; clear:both; border:none">
COMMENTS</h2>
<div class="commentPaging" id="Paging" style="outline:none 0px; right:1px; top:9px">
<div class="commentpage" style="outline:none 0px; float:right; height:33px; line-height:33px; font-size:16px; color:#ffffff; padding:0px 10px; background:#ff6600">
&lt;label id=&quot;TotalComments&quot; class=&quot;floatRight&quot; style=&quot;outline: none 0px; float: right; width: auto; margin-right: 3px;&quot;&gt;14&lt;/label&gt;&lt;label class=&quot;floatRight&quot; style=&quot;outline: none 0px; float: right; width: auto; margin-right: 3px;&quot;&gt;of&lt;/label&gt;&lt;label
 id=&quot;CommentCount&quot; class=&quot;floatRight&quot; style=&quot;outline: none 0px; float: right; width: auto; margin-right: 3px;&quot;&gt;10&lt;/label&gt;</div>
<a id="ViewPreviousComments" class="previousComments" style="outline:none 0px; color:#ffffff; padding:0px 10px; float:right; height:33px; line-height:33px; font-size:16px; background:#0086dc">View Previous Comments &gt;&gt;</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div class="pulseMainComment" id="ctl00_Comments1_Panel1" style="outline:none 0px; width:auto">
<div class="pulseCommentSectionMain" style="outline:none 0px; width:674px; padding:0px; overflow:inherit">
<div class="pulseCommentSection" style="outline:none 0px; float:left; margin-top:5px; width:674px">
<div id="RootComments" style="outline:none 0px">
<div class="pulsecomment" id="comment_89813" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/kunal-patel12" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Kunal Patel" src="-8af67520140415010943.jpg.ashx?width=60&height=60" alt="Kunal Patel" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Thanks everyone.</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/kunal-patel12" style="outline:none 0px; text-decoration:none; color:#ff6600">Kunal Patel</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">599</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">121</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">28.8k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89813" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89813" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89813" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment x_x_x_x_x_x_BackgroundWhite" id="comment_89814" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/aqib-shehzad" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Aqib Shehzad" src="-70dbe620150912012708.jpg.ashx?width=60&height=60" alt="Aqib Shehzad" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Good article</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/aqib-shehzad" style="outline:none 0px; text-decoration:none; color:#ff6600">Aqib Shehzad</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">517</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">188</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">25.3k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89814" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89814" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89814" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment" id="comment_89815" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/surya-pratap-singh4" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Surya Pratap Singh" src="-ffeb9520150701095817.jpg.ashx?width=60&height=60" alt="Surya Pratap Singh" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Gud one...\</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/surya-pratap-singh4" style="outline:none 0px; text-decoration:none; color:#ff6600">Surya Pratap Singh</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">650</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">49</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">4.6k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89815" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89815" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89815" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment x_x_x_x_x_x_BackgroundWhite" id="comment_89817" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/manas-mohapatra" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Manas Mohapatra" src="-manas120150620051826.jpg.ashx?width=60&height=60" alt="Manas Mohapatra" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Good Share man...</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/manas-mohapatra" style="outline:none 0px; text-decoration:none; color:#ff6600">Manas Mohapatra</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">149</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">1.3k</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">50.5k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89817" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89817" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89817" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment" id="comment_89819" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/humayun-kabir-mamun" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Humayun Kabir Mamun" src="-hkmamun20141021123051.jpg.ashx?width=60&height=60" alt="Humayun Kabir Mamun" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Nice...</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/humayun-kabir-mamun" style="outline:none 0px; text-decoration:none; color:#ff6600">Humayun Kabir Mamun</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">416</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">328</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">0</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89819" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89819" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89819" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment x_x_x_x_x_x_BackgroundWhite" id="comment_89826" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/nilesh-jadav" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Nilesh Jadav" src="-00946420150428103406.jpg.ashx?width=60&height=60" alt="Nilesh Jadav" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Nice share sir</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/nilesh-jadav" style="outline:none 0px; text-decoration:none; color:#ff6600">Nilesh Jadav</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">73</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">2.7k</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">219.8k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89826" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89826" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89826" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment" id="comment_89834" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/kunal-patel12" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Kunal Patel" src="-8af67520140415010943.jpg.ashx?width=60&height=60" alt="Kunal Patel" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Thanks.</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/kunal-patel12" style="outline:none 0px; text-decoration:none; color:#ff6600">Kunal Patel</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">599</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">121</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">28.8k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89834" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89834" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89834" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment x_x_x_x_x_x_BackgroundWhite" id="comment_89840" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/harshad-pansuriya" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Harshad Pansuriya" src="-fe635420150914082644.jpg.ashx?width=60&height=60" alt="Harshad Pansuriya" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Nice One</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/harshad-pansuriya" style="outline:none 0px; text-decoration:none; color:#ff6600">Harshad Pansuriya</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">346</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">491</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">12.1k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89840" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89840" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89840" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment" id="comment_89933" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/santhakumar-munuswamy" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Santhakumar Munuswamy" src="-f2823e20150612020708.jpg.ashx?width=60&height=60" alt="Santhakumar Munuswamy" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Nice Article. Thanks for sharing us</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/santhakumar-munuswamy" style="outline:none 0px; text-decoration:none; color:#ff6600">Santhakumar Munuswamy</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 01, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">49</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">3.5k</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">76.3k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_89933" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_89933" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_89933" style="outline:none 0px"></div>
</div>
</div>
<div class="pulsecomment x_x_x_x_x_x_BackgroundWhite" id="comment_90010" style="outline:none 0px; float:left; padding:9px 5px; width:674px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<a href="http://www.c-sharpcorner.com/authors/karthikeyan-k14" style="outline:none 0px; text-decoration:none; display:block; width:60px; height:60px"><img title="Karthikeyan K" src="-88d8c020150818065856.jpg.ashx?width=60&height=60" alt="Karthikeyan K" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></a></div>
<div class="commentcontent" style="outline:none 0px; float:left; max-width:586px">
<div class="commentDescription" style="outline:none 0px; line-height:20px; color:#8b8b8b; margin-bottom:6px">
Good one sir...Thanks for sharing</div>
<div style="outline:none 0px"><a class="LinkRed" href="http://www.c-sharpcorner.com/authors/karthikeyan-k14" style="outline:none 0px; text-decoration:none; color:#ff6600">Karthikeyan K</a><span class="floatRight responsive_Commenttime" style="outline:none 0px; float:right; width:auto; font-size:11px"><span class="watchICon" style="outline:none 0px; display:inline-block; width:13px; height:13px; vertical-align:middle; margin-right:3px; padding-right:1px">&nbsp;</span>Oct
 02, 2015</span></div>
<div style="outline:none 0px; margin-top:4px">
<ul class="rpv" style="outline:none 0px; margin:0px; padding:0px; float:left">
<li class="newSpriteIcons rank" title="Rank" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">110</span> </li><li class="newSpriteIcons point" title="Points" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:5px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">1.8k</span> </li><li class="newSpriteIcons views" title="Total Views" style="outline:none 0px; float:left; font-size:12px; color:#676767; list-style:none; margin-right:0px; padding:0px 0px 0px 6px; font-weight:bold">
<span style="outline:none 0px">36.8k</span> </li></ul>
<div class="floatRight pulseAction" style="outline:none 0px; float:right; width:auto">
<a class="newSpriteIcons like" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Likes_90010" style="outline:none 0px">0</span></a><a class="newSpriteIcons reply" style="outline:none 0px; color:#676767; margin:0px 12px 0px 0px; float:left; font-size:13px; padding-left:18px"><span id="Replies_90010" style="outline:none 0px">0</span></a><a class="newSpriteIcons postReply" style="outline:none 0px; margin:0px 12px 0px 0px; color:#676767; float:left; font-size:13px; padding-left:24px">Post
 Reply</a></div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div id="CommentReplies_90010" style="outline:none 0px"></div>
</div>
</div>
</div>
<div class="pulsecomment x_x_x_x_x_x_borderNone" id="RootPostComment" style="outline:none 0px; float:left; padding:9px 5px; width:674px; min-height:42px">
<div class="image x_x_x_x_x_x_level0" style="outline:none 0px; width:75px; float:left; margin:0px; overflow:hidden">
<img src="-8af67520140415010943.jpg" alt="" style="outline:none 0px; border-style:none; border-width:initial; display:block; width:60px; height:60px"></div>
<div class="commentcontentPost" id="ctl00_Comments1_PanelPostComment" style="outline:none 0px; overflow:inherit; max-width:586px; float:left">
<div class="mentions-input-box" style="outline:none 0px; font-family:pt_sansregular">
<div class="mentions" style="outline:none 0px; bottom:0px; color:#ffffff; left:1px; overflow:hidden; padding:5px; right:0px; top:1px; white-space:pre-wrap; word-wrap:break-word">
<div style="outline:none 0px"></div>
</div>
&lt;textarea id=&quot;InputCommentText_0&quot; class=&quot;mention&quot; style=&quot;outline: none 0px; resize: none; width: 586px; border-color: #dcdcdc; display: block; overflow: hidden; padding: 5px; position: relative; font-family: pt_sansregular; font-size: 14px; min-height: 38px;
 color: #8b8b8b; height: 31px; background: none 0px 0px repeat scroll transparent;&quot;&gt;&lt;/textarea&gt;</div>
</div>
<span title="If checked, you'll get email notification for any comment posted" style="outline:none 0px; display:inline-block; margin-top:6px; clear:both">&lt;input id=&quot;ctl00_Comments1_FollowCheckBox&quot; style=&quot;outline: 0px; float: left; position: absolute; width:
 25px; height: 25px; overflow: hidden; margin: -2px 0px 0px; padding: 0px; border-width: 0px; opacity: 0;&quot; checked=&quot;checked&quot; name=&quot;ctl00$Comments1$FollowCheckBox&quot; type=&quot;checkbox&quot; /&gt;&lt;label style=&quot;outline: none 0px;&quot; for=&quot;ctl00_Comments1_FollowCheckBox&quot;&gt;Follow
 Comments&lt;/label&gt;</span></div>
</div>
</div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div class="socialComments" id="ctl00_Comments1_SocialComments" style="outline:none 0px">
<div class="commentHeader" style="outline:none 0px; padding:15px 0px 0px; margin-bottom:5px; overflow:hidden">
<h2 class="headerControls x_x_x_x_x_x_floatLeft" style="outline:none 0px; float:left; margin:0px; padding:0px; height:30px; line-height:30px; font-size:20px; font-family:BebasNeueRegular; color:#727272; font-weight:normal; text-transform:uppercase; clear:both; border:none">
COMMENT USING</h2>
<span class="facebookComments" style="outline:none 0px; width:24px; height:24px; display:inline-block; margin:3px 5px">&nbsp;</span></div>
<div class="fb-comments" style="outline:none 0px"></div>
</div>
</div>
<div style="outline:none 0px"></div>
</div>
<div class="rightCntr" style="outline:none 0px; width:336px; float:right; padding-bottom:10px">
<div id="ctl00_RightBar_ArticleDetailRightBar1_PremiumSponsorTextAd1_SponsorWithImage" style="outline:none 0px">
<h2 class="headerControls" style="outline:none 0px; margin:0px; padding:0px; height:30px; line-height:30px; font-size:20px; font-family:BebasNeueRegular; color:#727272; font-weight:normal; text-transform:uppercase; clear:both">
SPONSORED BY</h2>
<div class="adBox" id="ctl00_RightBar_ArticleDetailRightBar1_PremiumSponsorTextAd1_SponsorAdWithImage" style="outline:none 0px; width:326px; height:auto; float:left; padding:8px 0px 10px 10px">
<div class="adImage" style="outline:none 0px; float:left; top:0px; left:0px; width:100px; height:110px">
<a id="ctl00_RightBar_ArticleDetailRightBar1_PremiumSponsorTextAd1_HrefSponsorLinkImage" rel="nofollow" href="http://www.c-sharpcorner.com/AdRedirector.aspx?AdId=89&target=http://www.e-iceblue.com/Introduce/free-doc-component.html?aff_id=64" target="_blank" style="outline:none 0px; text-decoration:none"><img id="ctl00_RightBar_ArticleDetailRightBar1_PremiumSponsorTextAd1_imgSponsor" class="image90" src="-002549am.jpg" alt="" width="75" height="90" style="outline:none 0px; width:88px; height:88px; display:block; padding:5px; border:1px solid #d7d7d7!important"></a></div>
<div class="adRight" style="outline:none 0px; margin-left:5px; float:left; width:221px; height:auto">
<a id="ctl00_RightBar_ArticleDetailRightBar1_PremiumSponsorTextAd1_HrefSponsorLink" class="MemberoftheMonth" href="http://www.c-sharpcorner.com/AdRedirector.aspx?AdId=89&target=http://www.e-iceblue.com/Introduce/free-doc-component.html?aff_id=64" target="_blank" style="outline:none 0px; text-decoration:none; color:#333333; font-size:20px">Spire.Doc
 - Free .NET Word API</a>
<div id="ctl00_RightBar_ArticleDetailRightBar1_PremiumSponsorTextAd1_divSponsorDetail" style="outline:none 0px">
Use Spire.Doc to create, read, write, print, and convert word documents to OpenXML, RTF, TXT, XPS, EPUB, EMF, HTML, Image and PDF.</div>
</div>
</div>
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div style="outline:none 0px; width:336px; margin:10px 0px"><a id="ctl00_RightBar_ArticleDetailRightBar1_NewsArticleAd1_AdRotatorArticle" href="http://www.c-sharpcorner.com/AdRedirector.aspx?BannerId=728&target=http://www.infragistics.com/products/jquery?utm_source=c-sharpcorner.com&utm_medium=Banner&utm_content=jQuery%20338x280&utm_campaign=c-sharpcorner.com%20jQuery%20Banner" target="_blank" style="outline:none 0px; text-decoration:none"><img src="-sample_apps_338x280_2.jpg" alt="Infragistics jQuery Controls" style="outline:none 0px; border-style:none; border-width:initial"></a></div>
<h2 class="headerControls" style="outline:none 0px; margin:0px; padding:0px; height:30px; line-height:30px; font-size:20px; font-family:BebasNeueRegular; color:#727272; font-weight:normal; text-transform:uppercase; clear:both">
TRENDING UP<a id="ctl00_RightBar_ArticleDetailRightBar1_TrendingUp1_RssEnabledImageButton" class="headerRss" href="http://www.c-sharpcorner.com/RSS/TopArticles.aspx" target="_blank" style="outline:none 0px; text-decoration:none; margin-top:5px; width:16px; height:20px; display:block; text-indent:-9999px; float:right"></a></h2>
<div class="rightBox" style="outline:none 0px; float:left; margin-bottom:10px; padding:0px 0px 5px; width:336px">
<ul class="trendingBox" style="outline:none 0px; overflow:hidden; list-style:none; margin:10px 5px 5px; padding:0px">
<li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">01</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/145c93/crud-operations-using-ajax-part-2/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">CRUD Operations Using Ajax - Part 2</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">02</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/55a4e4/windows-10-important-tweaks/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Windows 10 Tweaks</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">03</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/70dbe6/best-ever-performance-and-debugging-tools-in-visual-studio-2/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Best Ever Performance And Debugging Tools
 In Visual Studio 2015</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">04</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/mahesh/best-C-Sharp-book/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Best C# Book</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">05</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/79037b/angularjs-write-less-code-get-more-functionality/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">AngularJS: Write Less Code Get More Functionality</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">06</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/mahesh/average-it-professional-salaries-around-the-world/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Average IT Professional Salaries Around The World</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">07</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/8ef97c/C-Sharp-net-interview-questions-and-answers/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">C# Interview Questions And Answers</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">08</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/746765/learning-angular-js-in-2-hours-6th-part/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Learning AngularJS in 2 Hours - Part 6</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-width:1px; border-bottom-style:solid; border-bottom-color:#f5f5f5; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">09</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/fe6354/animated-navigation-page-in-wpf-application/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">Animated Navigation Page In WPF Application</a></div>
</li><li style="outline:none 0px; overflow:hidden; display:block; border-bottom-style:none; padding:0px 0px 3px; margin-bottom:3px">
<div class="numbers" style="outline:none 0px; width:54px; padding:0px 0px 0px 6px; vertical-align:middle; display:table; float:left; font-size:26px; color:#a7a7a7; height:36px; line-height:36px">
<span title="Pulse rate/hour" style="outline:none 0px">10</span></div>
<div class="trendingDetail" style="outline:none 0px; width:260px; float:left; font-size:15px">
<a href="http://www.c-sharpcorner.com/UploadFile/145c93/crud-operation-using-ajax-part-1/" style="outline:none 0px; text-decoration:none; padding:0px; color:#7f8080; display:inline-block">CRUD Operations Using Ajax - Part 1</a></div>
</li></ul>
<a class="viewAllLink" href="http://www.c-sharpcorner.com/top-articles" style="outline:none 0px; text-decoration:none; margin:0px 10px 10px 0px; padding:0px 22px 1px 0px; font-size:15px; color:#3366cc; float:right">View All</a></div>
<div style="outline:none 0px; padding-bottom:10px"></div>
<div id="fb-root" style="outline:none 0px"></div>
<div class="fb-like-box" style="outline:none 0px; padding-bottom:10px; border:0px none">
</div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
<div style="outline:none 0px; width:336px; margin-bottom:10px"><a id="ctl00_RightBar_ArticleDetailRightBar1_NewsArticleAdMiddle1_AdRotatorArticle" href="http://www.c-sharpcorner.com/AdRedirector.aspx?BannerId=728&target=http://www.infragistics.com/products/jquery?utm_source=c-sharpcorner.com&utm_medium=Banner&utm_content=jQuery%20338x280&utm_campaign=c-sharpcorner.com%20jQuery%20Banner" target="_blank" style="outline:none 0px; text-decoration:none"><img src="-sample_apps_338x280_2.jpg" alt="Infragistics jQuery Controls" style="outline:none 0px; border-style:none; border-width:initial"></a></div>
<div class="clear" style="outline:none 0px; clear:both; overflow:hidden; height:0px">
</div>
</div>
</div>
</div>
<div class="footer" style="outline:none 0px; width:1263px; height:159px; float:left; margin-top:10px; bottom:0px; left:0px; color:#8d8d8d; font-family:Roboto,sans-serif; font-size:14px">
<div class="menuStripGray" style="outline:none 0px; width:1263px; height:auto; padding:5px 0px; float:left; background-color:#b5b5b5">
<div class="page" style="outline:none 0px; width:1024px; margin:0px auto">
<ul style="outline:none 0px; float:left; margin:0px; padding:0px">
<li class="first" style="outline:none 0px; display:block; float:left; color:#ff6600; background:none">
<a href="http://www.c-sharpcorner.com/Members/mvps/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">MVPs</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/mostviewed-articles" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">MOST VIEWED</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/Members/legend/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">LEGENDS</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/articles/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">NOW</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/prizes/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">PRIZES</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/reviews/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">REVIEWS</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/survey/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">SURVEY</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/exam/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">CERTIFICATIONS</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/downloads/" style="outline:none 0px; text-decoration:none; display:block; padding:4px 10px; font-size:12px; color:#000000">DOWNLOADS</a>
</li></ul>
<div class="rightlink" style="outline:none 0px; float:right"><a href="http://www.cbeyond.net/" target="_blank" style="outline:none 0px; text-decoration:none; color:#982929"><span class="hosted" style="outline:none 0px; color:#000000">Hosted By&nbsp;</span>CBeyond
 Cloud Services</a></div>
</div>
</div>
<div class="menuStripBlue" style="outline:none 0px; float:left; height:34px; width:1263px; z-index:99; background:#0086dc">
<div class="page" style="outline:none 0px; width:1024px; margin:0px auto">
<div class="menu" style="outline:none 0px">
<ul style="outline:none 0px; list-style:none; margin:0px; padding:0px">
<li class="first" style="outline:none 0px; display:block; float:left; background:none">
<a href="http://www.c-sharpcorner.com/resources/aboutus.aspx" style="outline:none 0px; text-decoration:none; display:block; padding:8px 10px 0px; float:left; color:#ffffff; height:27px; text-transform:uppercase; font-size:15px">ABOUT US</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/media/ContactUs.aspx" style="outline:none 0px; text-decoration:none; display:block; padding:8px 10px 0px; float:left; color:#ffffff; height:27px; text-transform:uppercase; font-size:15px">MEDIA
 KIT</a> </li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/Members/" style="outline:none 0px; text-decoration:none; display:block; padding:8px 10px 0px; float:left; color:#ffffff; height:27px; text-transform:uppercase; font-size:15px">MEMBERS</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/beginners/" style="outline:none 0px; text-decoration:none; display:block; padding:8px 10px 0px; float:left; color:#ffffff; height:27px; text-transform:uppercase; font-size:15px">STUDENTS</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/resources/" style="outline:none 0px; text-decoration:none; display:block; padding:8px 10px 0px; float:left; color:#ffffff; height:27px; text-transform:uppercase; font-size:15px">LINKS</a>
</li></ul>
</div>
</div>
</div>
<div class="footerBottom" style="outline:none 0px; float:left; padding:10px 0px; width:1263px; background-color:#000000">
<div class="page" style="outline:none 0px; width:1024px; margin:0px auto">
<ul style="outline:none 0px; float:left; margin:0px; padding:0px">
<li class="first" style="outline:none 0px; display:block; float:left; color:#ff6600; background:none">
<a href="http://www.c-sharpcorner.com/contactus.aspx" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:7px 7px 0px 10px; font-size:12px">CONTACT US</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/privacypolicy.aspx" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:7px 7px 0px 10px; font-size:12px">PRIVACY POLICY</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/termsconditions.aspx" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:7px 7px 0px 10px; font-size:12px">TERMS &amp; CONDITIONS</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/sitemap/" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:7px 7px 0px 10px; font-size:12px">SITEMAP</a>
</li><li style="outline:none 0px; display:block; float:left"><a href="http://www.c-sharpcorner.com/contactus.aspx?Type=6" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:7px 7px 0px 10px; font-size:12px">REPORT ABUSE</a>
</li></ul>
<div class="social_link" style="outline:none 0px; float:right; padding-bottom:6px">
<ul style="outline:none 0px; float:right; margin:0px; padding:0px 0px 6px">
<li style="outline:none 0px; display:block; float:left; background:none"><a class="facebook" href="http://www.facebook.com/pages/C-Corner/194086953935286" target="_blank" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">facebook</a>
</li><li style="outline:none 0px; display:block; float:left; background:none"><a class="twitter" href="http://twitter.com/csharpcorner" target="_blank" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">twitter</a>
</li><li style="outline:none 0px; display:block; float:left; background:none"><a class="google" href="https://plus.google.com/u/0/114221266846457741050/posts" target="_blank" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">google</a>
</li><li style="outline:none 0px; display:block; float:left; background:none"><a class="media" href="http://www.youtube.com/user/CsharpCorner1/" target="_blank" style="outline:none 0px; text-decoration:none; color:gray; display:block; padding:0px; font-size:12px; margin-right:7px; float:left; text-indent:-9999px; width:30px; height:30px">media</a>
</li></ul>
<p class="copyright" style="outline:none 0px; clear:both">&copy;2015 C# Corner. All contents are copyright of their authors.</p>
</div>
</div>
</div>
</div>
</div>
