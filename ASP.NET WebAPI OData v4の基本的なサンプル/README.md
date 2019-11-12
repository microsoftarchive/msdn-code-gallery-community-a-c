# ASP.NET WebAPI OData v4の基本的なサンプル
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- OData
## Topics
- OData
## Updated
- 09/28/2014
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、ASP.NET WebAPI OData v4の基本的な使い方を示したものになります。ODataのサービス側の実装と、それを使うストアアプリからなります。</p>
<h2>サンプルプログラムの実行方法</h2>
<p>このサンプログラムを実行するには、ODataV4Sampleプロジェクトを実行した後、ClientAppプロジェクトを実行します。</p>
<h1>解説</h1>
<h2>サービスの解説</h2>
<p>ASP.NET WebAPIでOData v4を使うには、以下の手順で行います。</p>
<ol>
<li>EdmModelの作成
<ol>
<li>EntitySetの登録 </li><li>必要に応じてファンクション・アクションの登録 </li></ol>
</li><li>ODataControllerを継承したコントローラの作成
<ol>
<li>Get, Post, Patch, Post, Deleteメソッドの定義 </li><li>必要に応じてファンクション・アクションに対応するメソッドの定義 </li></ol>
</li></ol>
<p>EdmModelを作成するには、ODataConventionModelBuilderクラスを使います。ODataConventionModelBuilderのEntitySet&lt;T&gt;(name)メソッドを使ってTで指定した型を返すサービスを登録します。例えば以下のようなPersonクラスがあるとします。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;ODataV4Sample.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Person&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Age&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Person&nbsp;Clone()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Person&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Id,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Name,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Age&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Age&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>このクラスを返す、Peopleというサービスを登録するには、以下のようにODataConventionModelBuilderを使います。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;builder&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ODataConventionModelBuilder();&nbsp;
<span class="js__sl_comment">//&nbsp;名前空間の設定</span>&nbsp;
builder.Namespace&nbsp;=&nbsp;<span class="js__operator">typeof</span>(WebApiConfig).Namespace;&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;エンテティの登録</span>&nbsp;
builder.EntitySet&lt;Person&gt;(<span class="js__string">&quot;People&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>名前空間の登録はオプションですが、何も指定しないとDefaultという名前空間になるためプロジェクトに合わせたものにしておくのが良いです。ここでは、WebApiConfigクラスの所属する名前空間を指定しています。</p>
<p>Peopleという名前でEntitySetを登録したら、Controllers名前空間にODataControllerを継承したPeopleControllerクラスを作成します。</p>
<h2></h2>
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;ODataV4Sample.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Diagnostics.aspx" target="_blank" title="Auto generated link to System.Diagnostics">System.Diagnostics</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Net.aspx" target="_blank" title="Auto generated link to System.Net">System.Net</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.Http.aspx" target="_blank" title="Auto generated link to System.Web.Http">System.Web.Http</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.OData.aspx" target="_blank" title="Auto generated link to System.Web.OData">System.Web.OData</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.OData.Query.aspx" target="_blank" title="Auto generated link to System.Web.OData.Query">System.Web.OData.Query</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.OData.Routing.aspx" target="_blank" title="Auto generated link to System.Web.OData.Routing">System.Web.OData.Routing</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ODataV4Sample.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PeopleController&nbsp;:&nbsp;ODataController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</h2>
<p>&nbsp;EdmModelを作成したら、HttpConfigurationに登録します。MapODataServiceRouteメソッドを使ってEdmModelを登録します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Microsoft.OData.Edm;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ODataV4Sample.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.Http.aspx" target="_blank" title="Auto generated link to System.Web.Http">System.Web.Http</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.OData.Builder.aspx" target="_blank" title="Auto generated link to System.Web.OData.Builder">System.Web.OData.Builder</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.OData.Extensions.aspx" target="_blank" title="Auto generated link to System.Web.OData.Extensions">System.Web.OData.Extensions</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ODataV4Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WebApiConfig&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Register(HttpConfiguration&nbsp;config)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;config.MapODataServiceRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;ODataRoute&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;odata&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetEdmModel());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IEdmModel&nbsp;GetEdmModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;builder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ODataConventionModelBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;名前空間の設定</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;builder.Namespace&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(WebApiConfig).Namespace;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;エンテティの登録</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;builder.EntitySet&lt;Person&gt;(<span class="cs__string">&quot;People&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;builder.GetEdmModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>データの取得処理の作成</h2>
<p>コントローラーにデータを取得するためのメソッドを追加します。Getという名前で追加すると、データ取得のメソッドになります。Getはkeyという引数を持った単一要素を返すものと、そうでない複数の要素を返すものがあります。IQueryable&lt;T&gt;を返すと、クライアントサイドからODataのクエリを使って問い合わせを行うことができます。ODataQueryOptions&lt;T&gt;を引数に受け取ることで、より細かなクエリの制御を行うことも可能です。このサンプルプログラムではODataQueryOptions&lt;T&gt;クラスを使って、SkipとTopを処理するようにしています。コードを以下に示します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;PeopleRepository&nbsp;repository&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PeopleRepository();&nbsp;
&nbsp;
public&nbsp;IHttpActionResult&nbsp;Get(ODataQueryOptions&lt;Person&gt;&nbsp;options)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;skip&nbsp;=&nbsp;options.Skip&nbsp;==&nbsp;null&nbsp;?&nbsp;null&nbsp;:&nbsp;(int?)options.Skip.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;top&nbsp;=&nbsp;options.Top&nbsp;==&nbsp;null&nbsp;?&nbsp;null&nbsp;:&nbsp;(int?)options.Top.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;results&nbsp;=&nbsp;repository.GetPeople(skip,&nbsp;top);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!results.Any())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(results);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;IHttpActionResult&nbsp;Get(int&nbsp;key)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;response&nbsp;=&nbsp;<span class="js__operator">this</span>.repository.Get(key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(repository&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(response);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>PeopleRepositoryは、CRUDをサポートしたインメモリのリストをラップしたクラスになります。コードはサンプルをダウンロードして参照してください。</p>
<h2>更新・登録・削除</h2>
<p>更新処理は、PatchとPutメソッドで実装します。コード例を以下に示します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;IHttpActionResult&nbsp;Patch(int&nbsp;key,&nbsp;Delta&lt;Person&gt;&nbsp;delta)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;p&nbsp;=&nbsp;<span class="js__operator">this</span>.repository.Get(key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(p&nbsp;==&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;delta.Patch(p);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!<span class="js__operator">this</span>.repository.Update(key,&nbsp;p))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Updated(p);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;IHttpActionResult&nbsp;Put(int&nbsp;key,&nbsp;Person&nbsp;p)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!<span class="js__operator">this</span>.repository.Update(key,&nbsp;p))&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Updated(p);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Putメソッドが一括更新で、PatchがDelta&lt;Person&gt;で変更の差分のみを受け取るという違いがあります。Delta&lt;T&gt;はPatchメソッドを使ってクラスに変更を適用出来ます。</p>
<p>登録処理はPostメソッドを使って行います。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;IHttpActionResult&nbsp;Post(Person&nbsp;p)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newId&nbsp;=&nbsp;<span class="js__operator">this</span>.repository.Add(p);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Created(<span class="js__operator">this</span>.repository.Get(newId));&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>データの削除は、Deleteメソッドで行います。このメソッドはkeyを受け取る形で実装します。</p>
<p>&nbsp;</p>
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;IHttpActionResult&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;key)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">this</span>.repository.Delete(key))&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;NotFound();&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;StatusCode(HttpStatusCode.NoContent);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</h2>
<p>&nbsp;</p>
<h2>&nbsp;ファンクションの定義</h2>
<p style="padding-left:30px">ファンクションや後述するアクションを使うには、Web.configのsystem.webServerセクションに以下の定義を追加してください。</p>
<p style="padding-left:30px">&lt;!-- ODataの関数などを使うために必要 --&gt;<br>
&lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;</p>
<p>ファンクションは、Functionメソッドを使ってEdmModelに登録します。登録対象をModelBuilderにするか、コレクションにするか、型にするかでファンクションのスコープが変わります。このサンプルプログラムでは、コレクションに対して（Peopleに対して）Personの集計結果を返すAnalyzeというファンクションを登録しています。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;指定した範囲の年齢の分析をする関数</span>&nbsp;
<span class="cs__com">//&nbsp;Person全体にかかるためコレクションに対する関数として定義する</span>&nbsp;
var&nbsp;analyzeFunction&nbsp;=&nbsp;builder.EntityType&lt;Person&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Collection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Function(<span class="cs__string">&quot;Analyze&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Returns&lt;AnalyzeResult&gt;();&nbsp;
analyzeFunction.Parameter&lt;<span class="cs__keyword">int</span>&gt;(<span class="cs__string">&quot;skip&quot;</span>);&nbsp;
analyzeFunction.Parameter&lt;<span class="cs__keyword">int</span>&gt;(<span class="cs__string">&quot;top&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>ファンクションの定義は、Controllerに同名で同じ引数を受け取るメソッドを作成します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;GET&nbsp;ODataV4Sample.Analyze(skip={skip},top={top})</span>&nbsp;
[HttpGet]&nbsp;
public&nbsp;IHttpActionResult&nbsp;Analyze(int&nbsp;skip,&nbsp;int&nbsp;top)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;people&nbsp;=&nbsp;<span class="js__operator">this</span>.repository.GetPeople(skip,&nbsp;top);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;average&nbsp;=&nbsp;people.Select(x&nbsp;=&gt;&nbsp;x.Age)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Average();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;max&nbsp;=&nbsp;people.Max(p&nbsp;=&gt;&nbsp;p.Age);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;min&nbsp;=&nbsp;people.Min(p&nbsp;=&gt;&nbsp;p.Age);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(<span class="js__operator">new</span>&nbsp;AnalyzeResult&nbsp;<span class="js__brace">{</span>&nbsp;Average&nbsp;=&nbsp;average,&nbsp;MaxAge&nbsp;=&nbsp;max,&nbsp;MinAge&nbsp;=&nbsp;min&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>アクションの定義</h2>
<p>ODataのアクションもファンクションと同様に定義します。違いは、HttpPostでメソッドを定義するところです。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;指定した範囲の人を全員加齢させるアクション</span>&nbsp;
<span class="js__sl_comment">//&nbsp;Person全体にかかるためコレクションに対するアクションとして定義する</span>&nbsp;
<span class="js__statement">var</span>&nbsp;ageAction&nbsp;=&nbsp;builder.EntityType&lt;Person&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Collection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Action(<span class="js__string">&quot;Age&quot;</span>);&nbsp;
ageAction.Parameter&lt;AgeParameter&gt;(<span class="js__string">&quot;p&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;POST&nbsp;ODataV4Sample.Age</span>&nbsp;
[HttpPost]&nbsp;
<span class="cs__keyword">public</span>&nbsp;IHttpActionResult&nbsp;Age(ODataActionParameters&nbsp;parameter)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;p&nbsp;=&nbsp;(AgeParameter)parameter[<span class="cs__string">&quot;p&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;people&nbsp;=&nbsp;<span class="cs__keyword">this</span>.repository.GetPeople(p.Skip,&nbsp;p.Top);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;person&nbsp;<span class="cs__keyword">in</span>&nbsp;people)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;target&nbsp;=&nbsp;<span class="cs__keyword">this</span>.repository.Get(person.Id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;target.Age&nbsp;&#43;=&nbsp;p.Age;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.repository.Update(person.Id,&nbsp;target);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Ok();&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
