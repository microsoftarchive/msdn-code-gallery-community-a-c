# ASP.NET MVC アプリケーション開発入門: 第 8 回　Action Filter について
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- ASP.NET MVC
## Topics
- ASP.NET MVC アプリケーション
## Updated
- 06/07/2011
## Description

<p style="text-indent:-3.5em; padding-left:3.5em">執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#masuda" target="_blank">
moonmile solutions 増田 智明</a></p>
<div style="margin:0; background-color:#d9e8ec; border:2px #46689a solid; margin-bottom:20px">
<div style="background-color:#d9e8ec; border:1px #ffffff solid">
<div style="padding:5px; font-size:100%; border:1px #46689a solid">
<p style="margin:0; padding:0">本連載では、日経 BP 社から発売された<a href="http://ec.nikkeibp.co.jp/item/books/P94380.html" target="_blank">「ひと目でわかる ASP.NET MVC アプリケーション開発入門」</a>をもとにして、執筆時に気づいたことや紙面の都合で書ききれなかった技術を紹介します。</p>
</div>
</div>
</div>
<h3>目次</h3>
<ol style="margin-bottom:0pt">
<li><a href="#i_01" target="_self">はじめに</a> </li><li><a href="#i_02" target="_self">Authorize 属性の動作をみる</a> </li><li><a href="#i_03" target="_self">ログイン名によって制御する</a> </li><li><a href="#i_04" target="_self">ロールを使う準備をする</a> </li><li><a href="#i_05" target="_self">ロール名によって制御する</a> </li><li><a href="#i_06" target="_self">独自のアクション フィルターを作る</a> </li><li><a href="#i_07" target="_self">ユーザー情報を SQL Server 上に作成する</a> </li><li><a href="#i_08" target="_self">おわりに</a> </li></ol>
<hr>
<h2 id="i_01">1. はじめに</h2>
<p>今回は、ASP.NET MVC のアクション メソッドを拡張するアクション フィルターについて解説します。アクション フィルターは、メソッドの属性として設定されます。クラスの静的なデータとして設定されるため、クラス内の共通処理を行う場合に使うことができます。<br>
<br>
Visual Studio 2010 で ASP.NET MVC アプリケーションを作ると、ログイン機能がテンプレートとして付いてきますが、ログインを制御するのは AccountController クラスで、Authorize という属性が設定されています。この Authorize 属性の中でログインが行われているか否かを判断して、アクション メソッドの動作を制御しています。<br>
<br>
アクション フィルターは、Authorize 属性の他に HandleError 属性、OutputCache 属性などがあります。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="i_02">2. Authorize 属性の動作をみる</h2>
<p>最初にログイン制御で使われる Authorize 属性の動作をみていきましょう。</p>
<p>Visual Studio 2010 で「ASP.NET MVC 2 Webアプリケーション」を作成します。</p>
<p>まず、HomeController.cs (VB の場合は HomeController.vb)を開いて、次の 2 つのメソッドを追加します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Normal()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}&nbsp;
&nbsp;
[Authorize]&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;LoginUser()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Normal()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;View();&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&lt;Authorize&gt;&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;LoginUser()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;View();&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<p>この 2 つのアクション メソッドの違いは、Authorize 属性が付いているか、いないかの違いだけです。<br>
<br>
次に、このアクション メソッドで表示するビューを作成します。<br>
<br>
1 つは、ログインしないユーザーでも表示できる一般ユーザー用の Normal.aspx というビューです。<br>
もう 1 つは、ログインしたユーザーだけが表示できる LoginUser.aspx というビューです。<br>
<br>
ここでは、LoignUser.aspx の例を示します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LoginUser&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;LoginUser&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;これはログインユーザーだけが閲覧できるページです&lt;/p&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;%@&nbsp;Page&nbsp;Title=<span class="visualBasic__string">&quot;&quot;</span>&nbsp;Language=<span class="visualBasic__string">&quot;VB&quot;</span>&nbsp;MasterPageFile=<span class="visualBasic__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;<span class="visualBasic__keyword">Inherits</span>=<span class="visualBasic__string">&quot;System.Web.Mvc.ViewPage&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="visualBasic__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="visualBasic__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="visualBasic__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LoginUser&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="visualBasic__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="visualBasic__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="visualBasic__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;LoginUser&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;これはログインユーザーだけが閲覧できるページです&lt;/p&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;</pre>
</div>
</div>
</div>
<p>さてコードの準備ができたので、動作を確認してみましょう。あらかじめユーザーを作成しておいて、ログインしていない状態とログインした状態で表示してみましょう。</p>
<p>動作を確認が簡単にできるように Home/Index.aspx に次のようなリンクを作成しておきます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;ul&gt;&nbsp;
&lt;li&gt;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;一般ユーザー用&quot;</span>,&nbsp;<span class="cs__string">&quot;Normal&quot;</span>)%&gt;&lt;/li&gt;&nbsp;
&lt;li&gt;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;ログインユーザー用&quot;</span>,<span class="cs__string">&quot;LoginUser&quot;</span>)&nbsp;%&gt;&lt;/li&gt;&nbsp;
&lt;/ul&gt;</pre>
</div>
</div>
</div>
<p>以下が実行した結果です。</p>
<p><img src="http://i3.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22272/1/image001.jpg" alt="図 1" width="550" height="489"></p>
<p>動作を確認してみると、ログインしていない状態で、「ログイン ユーザー用」のリンクをクリックすると、ログインするビューにリダイレクトされます。これは、LoginUser アクション メソッドに設定されている Authorize 属性がログイン状態をチェックして、ログインのためのページにジャンプさせているためです。</p>
<p>ログイン制御のジャンプ先は、web.config ファイルに記述されています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre id="codePreview" class="xml">&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;authentication</span>&nbsp;<span class="xml__attr_name">mode</span>=<span class="xml__attr_value">&quot;Forms&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;forms</span>&nbsp;<span class="xml__attr_name">loginUrl</span>=<span class="xml__attr_value">&quot;~/Account/LogOn&quot;</span>&nbsp;<span class="xml__attr_name">timeout</span>=<span class="xml__attr_value">&quot;2880&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/authentication&gt;</span></pre>
</div>
</div>
</div>
<p>この loginUrl 属性の値を変えることで、エラー時のジャンプ先のビューを変更することができます。例えば、Home/Error.aspx のビューにジャンプさせる時には次のように loginUrl 属性の値を変更します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre id="codePreview" class="xml">&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;authentication</span>&nbsp;<span class="xml__attr_name">mode</span>=<span class="xml__attr_value">&quot;Forms&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;forms</span>&nbsp;<span class="xml__attr_name">loginUrl</span>=<span class="xml__attr_value">&quot;~/Home/Error&quot;</span>&nbsp;<span class="xml__attr_name">timeout</span>=<span class="xml__attr_value">&quot;2880&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/authentication&gt;</span></pre>
</div>
</div>
</div>
</div>
<p><img src="http://i3.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22273/1/image002.jpg" alt="図 2" width="550" height="398"></p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="i_03">3. ログイン名によって制御する</h2>
<p>ユーザーがログインしているかどうかでチェックができたので、今度はログイン名によってログインの制御をしてみましょう。</p>
<p>まずは、AdminUser アクション メソッドを作成します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">[Authorize(Users=<span class="cs__string">&quot;admin&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;AdminUser()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;Authorize(Users:=<span class="visualBasic__string">&quot;admin&quot;</span>)&gt;&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;AdminUser()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
</div>
<p>Authorize 属性の Users パラメーターにログイン名を指定します。<br>
こうすることで、特定のユーザーだけで表示できるページを作成することができます。</p>
<p>次に「admin」という名前のログイン名を作成しておいて、この admin ユーザーだけが表示できる AdminUser.aspx ビューを作ります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AdminUser&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;AdminUser&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;これは管理ユーザーだけが閲覧できるページです&lt;/p&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;</pre>
</div>
</div>
</div>
<p>実行すると、admin ユーザーだけが AdminUser.aspx のページを表示できます。</p>
<p><img src="http://i3.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22274/1/image003.jpg" alt="図 3" width="550" height="304"></p>
<p><img src="http://i3.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22275/1/image004.jpg" alt="図 4" width="550" height="315"></p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="i_04">4. ロールを使う準備をする</h2>
<p>Authorize 属性では、ロール (役割) を使ったログインの制御も可能です。</p>
<p>ASP.NET MVC アプリケーションで扱う、ユーザー名とロールの関係は次の図になります。</p>
<p><img src="http://i2.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22276/1/image005.gif" alt="図 5" width="550" height="402"></p>
<p>ユーザー名で全てを制御しようとすると、管理ユーザーを追加するたびに属性を書き替えないといけません。これを避けるために、管理ロールを作成して、追加したい管理ユーザーを管理ロールに属するように設定します。</p>
<p>このロールを使うためには、まず Visual Studio 2010 の「プロジェクト」メニューから「ASP.NET 構成」を選択して、ASP.NET Web サイト管理ツールを開きます。<br>
サイト管理ツールはブラウザー上で、ASP.NET アプリケーションのユーザーの管理などができます。</p>
<p><img src="http://i3.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22277/1/image006.jpg" alt="図 6" width="550" height="443"></p>
<p>ロールを使うためには、まず「セキュリティ」のリンクをクリックした後で、「ロールの有効化」をクリックします。</p>
<p>「ロールの作成または管理」のリンクをクリックすると、新しいロールが作成できます。</p>
<p>ここでは「administrators」というロールを作成します。</p>
<p><img src="http://i4.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22278/1/image007.gif" alt="図 7" width="550" height="436"></p>
<p>次にユーザー管理のページを開いて、admin ユーザーを administrators ロールに追加します。</p>
<p>これで準備は完了です。ここでは、masuda と admin というユーザーがありますが、admin だけが管理ロールの administrators に属しています。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="i_05">5. ロール名によって制御する</h2>
<p>まずは、ビューを表示するための AdminRole メソッドに、次のように Authorize 属性を追加します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">[Authorize(Roles&nbsp;=&nbsp;<span class="cs__string">&quot;administrators&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;AdminRole()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;Authorize(Roles:=<span class="visualBasic__string">&quot;administators&quot;</span>)&gt;&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;AdminUser()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
</div>
<p>次に、administrators のロールに属しているユーザーだけが表示できるビューを作成していきましょう。AdminRole.aspx を次のように作成します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AdminUser&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;AdminUser&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;これは管理ユーザーだけが閲覧できるページです&lt;/p&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;</pre>
</div>
</div>
</div>
<p>これを実行すると次の図になります。</p>
<p><img src="http://i3.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22279/1/image008.jpg" alt="図 8" width="550" height="432"></p>
<p>masuda ユーザーでログインした状態でも管理ロール用のページ AdminUser.aspx を表示することはできません。masuda ユーザーをログアウトして、admin ユーザーでログインし直すと、管理ロールのページを表示することができます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="i_06">6. 独自のアクションフィルターを作る</h2>
<p>ここまで既に ASP.NET MVC で用意されている Authorize 属性の解説をしてきましたが、独自のアクション フィルターを作ることもできます。</p>
<p>アクション フィルターは、属性としてアクション メソッドに設定して動作するためのインターフェースが用意されています。</p>
<ul>
<li><strong>IActionFilter </strong>
<p>アクション メソッドの実行前と実行後にフィルターを実行します。</p>
</li><li><strong>IAuthorizationFilter </strong>
<p>アクション メソッドの実行前にフィルターを実行します。</p>
</li><li><strong>IExceptionFilter </strong>
<p>例外がスローされると、フィルターが実行します。</p>
</li><li><strong>IResultFilter </strong>
<p>アクションの結果の処理前と処理後にフィルターが実行します。</p>
</li></ul>
<p>ここでは、IActionFilter インターフェースを使って、アクション メソッドの前後にログを出力できるようにしてみましょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyFilterAttribute&nbsp;:&nbsp;FilterAttribute,&nbsp;IActionFilter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnActionExecuting(ActionExecutingContext&nbsp;filterContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="cs__string">&quot;メソッド前:{0}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.ActionDescriptor.ActionName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnActionExecuted(ActionExecutedContext&nbsp;filterContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="cs__string">&quot;メソッド後:{0}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.ActionDescriptor.ActionName&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;MyFilterAttribute&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;FilterAttribute&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Implements</span>&nbsp;IActionFilter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnActionExecuting(<span class="visualBasic__keyword">ByVal</span>&nbsp;filterContext&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionExecutingContext)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Implements</span>&nbsp;IActionFilter.OnActionExecuting&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="visualBasic__string">&quot;メソッド前:{0}&quot;</span>,&nbsp;filterContext.ActionDescriptor.ActionName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnActionExecuted(<span class="visualBasic__keyword">ByVal</span>&nbsp;filterContext&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionExecutedContext)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Implements</span>&nbsp;IActionFilter.OnActionExecuted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="visualBasic__string">&quot;メソッド後:{0}&quot;</span>,&nbsp;filterContext.ActionDescriptor.ActionName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
</div>
<p>この MyFilterAttribute 属性クラスでは、基本的な動作を FilterAttribute クラスを継承します。実行前と後のフィルター メソッドが実行されるように、IActionFilter インターフェースを継承します。<br>
<br>
OnActionExecuting メソッドが実行前に、OnActionExecuted メソッドが実行後になります。<br>
<br>
MyFilter 属性は、Authorize 属性などと同じようにアクション メソッドに設定します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">[MyFilter]&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Item(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;MyFilter()&gt;&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Item(<span class="visualBasic__keyword">ByVal</span>&nbsp;id&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
</div>
<p>Item.aspx ビューを作成して実行すると、Visual Studio 2010 の出力ウィンドウのログ出力が得られます。</p>
<p><img src="http://i1.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22280/1/image009.gif" alt="図 9" width="486" height="287"></p>
<p>IActionFilter インターフェースの OnActionExecuted メソッドでは、アクション メソッドの結果を修正することもできます。たとえば、ViewData プロパティを使い、デバッグ情報をビューに表示することも可能です。</p>
<p>アクション フィルターを次のように、ViewData を使うように書き変えます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnActionExecuted(ActionExecutedContext&nbsp;filterContext)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="cs__string">&quot;メソッド後:{0}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.ActionDescriptor.ActionName&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;filterContext.Controller.ViewData[<span class="cs__string">&quot;debug&quot;</span>]&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;ここでデバッグ情報を表示します&nbsp;id:{0}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.RequestContext.RouteData.Values[<span class="cs__string">&quot;id&quot;</span>]&nbsp;);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnActionExecuted(<span class="visualBasic__keyword">ByVal</span>&nbsp;filterContext&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionExecutedContext)&nbsp;_&nbsp;
&nbsp;<span class="visualBasic__keyword">Implements</span>&nbsp;IActionFilter.OnActionExecuted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="visualBasic__string">&quot;メソッド後:{0}&quot;</span>,&nbsp;filterContext.ActionDescriptor.ActionName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;filterContext.Controller.ViewData(<span class="visualBasic__string">&quot;debug&quot;</span>)&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;ここでデバッグ情報を表示します&nbsp;id:{0}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.RequestContext.RouteData.Values(<span class="visualBasic__string">&quot;id&quot;</span>))&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
</div>
<p>引数で渡される ActionExecutedContext クラスには上記のような Controller プロパティなど様々な情報が入っているので、これを活用することができます。</p>
<p>このデバッグ情報をビューで表示させます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Item&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Item&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;debug&quot;</span>]&nbsp;%&gt;&lt;/p&gt;&nbsp;
&lt;/asp:Content&gt;</pre>
</div>
</div>
</div>
<p>この実行が下の図です。</p>
<p><img src="http://i4.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22281/1/image010.gif" alt="図 10" width="500" height="361"></p>
<p>このようにアクション フィルター内で、ViewData コレクションを使うと、ビューとのやり取りが簡単にできるので一時的な情報やデバッグ時の情報などが出しやすくなります。LINQ to Entities で生成される SQL 文などを表示させるとパフォーマンス調査などができるでしょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="i_07">7. ユーザー情報を SQL Server 上に作成する</h2>
<p>最後にユーザー情報を App_Data フォルダー内のローカル ファイルではなく、SQL Server 上に作成する場合の説明をしましょう。<br>
<br>
Visual Studio 2010 で ASP.NET MVC アプリケーションを作成するとログイン情報は、App_Data フォルダー内にローカル ファイルとして保存されます。このデータは ASP.NET MVC アプリケーションでは利用できるのですが、バックアップの問題や、他の Web アプリケーションとの連携の問題が発生します。</p>
<p>このアカウント情報を SQL Server 上のデータベースに切り替えてみます。</p>
<p>まず、SQL Server Management Studio にアカウント情報を作成するデータベースを作ります。ここでは、「acldb」としています。</p>
<p><img src="http://i2.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22282/1/image011.gif" alt="図 11" width="316" height="347"></p>
<p>次に、データベースにアカウント情報用のテーブルとストアド プロシージャをインストールします。C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql.exe を実行して、ウィザードに従ってテーブルを作成します。</p>
<p><img src="http://i3.code.msdn.s-msft.com/aspnet-mvc-6d275641/image/file/22283/1/image012.jpg" alt="図 12" width="500" height="359"></p>
<p>ASP.NET MVC アプリケーションからアカウント用のデータベースにアクセスする設定は、web.config ファイルに記述されています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre id="codePreview" class="xml"><span class="xml__tag_start">&lt;configuration</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;ApplicationServicesOrg&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;data&nbsp;source=.\SQLEXPRESS;Integrated&nbsp;Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User&nbsp;Instance=true&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.SqlClient&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;ApplicationServices&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;Server=localhost;Database=acldb;Integrated&nbsp;Security=true&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.SqlClient&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/connectionStrings&gt;</span></pre>
</div>
</div>
</div>
<p>接続情報の名前は、ApplicationServices となっているので、この接続文字列 (connectionString) に、SQL Server 上に作成したデータベースを指定します。<br>
<br>
このようにすると、アカウント情報が SQL Server 上に作成されます。ローカル ファイルのデータベースと同様に ASP.NET Web サイト管理ツールを使ってユーザーとロールを管理できます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="i_08">8. おわりに</h2>
<p>いかがだったでしょうか。ASP.NET MVC のアクション フィルターは、あらかじめ定義されたものだけでなく独自に拡張できること理解頂けたと思います。C# や Visual Basic の属性の機能を使い、クラスやメソッド自身の情報としてアクション フィルターの動作を記述します。メソッドの実行前後のアスペクト指向的なインターフェースを使って、デバッグログだけでなく実行時のジャーナル機能 (誰がいつアクセスしたかなどの監査機能) を簡単に実装することができます。コード内で条件分岐をして if 文を使うよりも簡素に書けますので、ぜひ活用してみてください。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/"><img title="Code Recipe" src="http://i.msdn.microsoft.com/ff950935.coderecipe_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/asp.net/" target="_blank"><img title="ASP.NET デベロッパーセンター" src="http://i.msdn.microsoft.com/ff950935.ASP_NET_180x70%28ja-jp,MSDN.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net/gg490787" target="_blank">
連載! ASP.NET MVC アプリケーション開発入門一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://code.msdn.microsoft.com/">Code Recipe へ</a>
</li><li>もっと ASP.NET の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net/" target="_blank">
ASP.NET デベロッパーセンターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="http://www.microsoft.com/japan/msdn/nodehomes/graphics/top.gif" border="0" alt="">ページのトップへ</a></p>
