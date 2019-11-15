# ASP.NET MVC アプリケーション開発入門: 第 7 回 JavaScript と jQuery を利用する
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- ASP.NET MVC
## Topics
- ASP.NET MVC アプリケーション
- 連載! ASP.NET MVC
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
<li><a href="#01" target="_self">はじめに</a> </li><li><a href="#02" target="_self">JavaScript を記述する</a> </li><li><a href="#03" target="_self">外部 JavaScript ファイルを使う</a> </li><li><a href="#04" target="_self">jQuery を利用する</a> </li><li><a href="#05" target="_self">AjaxHelper を利用する</a> </li><li><a href="#06" target="_self">AjaxHelper でユーザー コントロールを埋め込む</a> </li><li><a href="#07" target="_self">Ajax の動きをまとめてみると</a> </li><li><a href="#08" target="_self">おわりに</a> </li></ol>
<hr>
<h2 id="01">1. はじめに</h2>
<p>今回は、Web アプリケーションでは今や必須の技術となった JavaScript との組み合わせについて解説していきます。ASP.NET MVC でも JavaScript は重要な技術です。Visual Studio 2010 でのプログラミング、jQuery のインテリセンス機能、そして、Ajax の機能を備えています。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. JavaScript を記述する</h2>
<p>まずは、簡単な JavaScript を記述してみましょう。ASP.NET MVC アプリケーションで新しいビューを作成して JavaScript を書きます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Script1&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;JavaScript&nbsp;を直接記述する&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(<span class="cs__string">&quot;&lt;p&gt;ここにJavaScriptで書きます&lt;/p&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(<span class="cs__string">&quot;&lt;ul&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__number">10</span>;&nbsp;i&#43;&#43;)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(<span class="cs__string">&quot;&lt;li&gt;商品&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(<span class="cs__string">&quot;&lt;/ul&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>JavaScript は、script タグの間に書きます。ここでは、document オブジェクトの write メソッドを使ってメッセージを出力し、for ループを使って 0 から 9 までを表示させています。</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19146/1/image001.jpg" alt="図 1" width="600" height="499"></p>
<p>図 1</p>
<p>ASP.NET の記述を使っても同じ表示になるのですが、見かけ上は同じでも ASP.NET の記述と JavaScript では大きく動作が違ってきます。ASP.NET ではサーバー サイドで HTML タグを生成して出力していますが、JavaScript の場合はブラウザー上で HTML を生成しています。これは、後で Ajax を利用したときに違ってきます。</p>
<p>従来、JavaScript のコーディングでは、オブジェクトが持つメソッドの記述はリファレンスを参照しながら、メモ帳などのテキスト エディターを使ってコーディングすることが多かったかもしれません。しかし、Visual Studio 2010 を使うと、C# や Visual Basic をコーディングするときと同様に JavaScript でもインテリセンス機能が使えます。</p>
<p>このソース コードでは document オブジェクトの後にピリオドをタイピングしたときに、インテリセンス機能により、下の図のようにオブジェクトのメソッドやプロパティのリストが表示されます。</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19147/1/image002.gif" border="1" alt="図 2" width="457" height="317"></p>
<p>図 2</p>
<p>この機能を使えば、単純なテキスト エディターを使ってコーディングするよりも素早くプログラムが仕上げられます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. 外部 JavaScript ファイルを使う</h2>
<p>ASP.NET MVC で外部の JavaScript ファイルを読み込む時は、script タグの src 属性を使います。JavaScript はどこのフォルダーに置いてもよいのですが、jQuery などと一緒の Scripts フォルダーに置くとよいでしょう。</p>
<p><img src="http://i4.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19148/1/image003.gif" border="1" alt="図 3" width="281" height="379"></p>
<p>図 3</p>
<p>Visual Studio 2010 では、src 属性でファイルを指定するときに「URL の選択」をクリックすると、スクリプト ファイルを指定するプロジェクトの項目の選択ダイアログ ボックスが開きます。このダイアログで 読み込む JavaScript ファイルを指定するとフォルダー指定の間違いが少なくなります。</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19149/1/image004.gif" border="1" alt="図 4" width="400" height="321"></p>
<p>図 4</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19150/1/image005.gif" alt="図 5" width="600" height="475"></p>
<p>図 5</p>
<p>サンプルのコードは、先のインラインで記述した JavaScript と同じ結果になります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Script2&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Script2&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;外部の&nbsp;JavaScript&nbsp;ファイルで記述する&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;../../Scripts/MyJScript.js&quot;</span>&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>読み込んでいる MyJScript.js は次の通りです。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">js</span>

<div class="preview">
<pre id="codePreview" class="js">document.write(<span class="js__string">&quot;&lt;ul&gt;&quot;</span>);&nbsp;
<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="js__num">10</span>;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;document.write(<span class="js__string">&quot;&lt;li&gt;商品&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i);&nbsp;
<span class="js__brace">}</span>&nbsp;
document.write(<span class="js__string">&quot;&lt;/ul&gt;&quot;</span>);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>Visual Studio 2010 でデバッグ実行をすると、この JavaScript のファイル内でブレークポイントを指定できます。例えば、document.write メソッドの呼び出しでブレークポイントを設定すると、次の図のように実行が停止します。</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19151/1/image006.jpg" border="1" alt="図 6" width="473" height="218"></p>
<p>図 6</p>
<p>C# や Visual Basic でデバッグしていると同じようにイミディエイト ウィンドウで変数を参照したり、ウォッチ ウィンドウでオブジェクトの内容を変更したりできるので、非常に強力なデバッグができます。</p>
<p>JavaScript をインラインで記述した場合には、ブレークポイントで止まらない時があるので、その時は実行時のソリューション エクスプローラーの「スクリプト ドキュメント」から、現在表示しているページを選択して、ブレークポイントを設定しておきます。そうして、再び指定のページを表示するとブレークポイントを設定した箇所でデバッグ実行が停止します。</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19152/1/image007.gif" alt="図 7" width="326" height="277"></p>
<p>図 7</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. jQuery を利用する</h2>
<p>ブラウザーで動的ページを作るときに定番となっている jQuery ですが、Visual Studio 2010 で ASP.NET MVC アプリケーションを作成すると既に、Scripts フォルダーに jQuery のファイルが入っています。jQuery のファイルには 3 つの種類があります。</p>
<ul>
<li>jquery-1.4.1-vsdoc.js Visual Studio のインテリセンス用のドキュメントが含まれたファイル </li><li>jquery-1.4.1.js 元の jQuery のファイル </li><li>jquery-1.4.1.min.js 読み込みサイズが最小になるように調節されたファイル </li></ul>
<p>Visual Studio 2010 で jQuery を使ってデバッグする時は、jquery-1.4.1-vsdoc.js か jquery-1.4.1.js を使い、運用時には jquery-1.4.1.min.js を使うとよいでしょう。コーディングやデバッグの時には、もともとのファイルを使うとエラーの行を特定しやすくなります。</p>
<p>jQuery の場合には、先の JavaScript のサンプル ファイルとは違ってどのビューでも使われることが多いので、マスター ページの head タグに記述します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Master&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewMasterPage&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;!DOCTYPE&nbsp;html&nbsp;PUBLIC&nbsp;<span class="cs__string">&quot;-//W3C//DTD&nbsp;XHTML&nbsp;1.0&nbsp;Strict//EN&quot;</span>&nbsp;<span class="cs__string">&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd&quot;</span>&gt;&nbsp;
&lt;html&nbsp;xmlns=<span class="cs__string">&quot;http://www.w3.org/1999/xhtml&quot;</span>&gt;&nbsp;
&lt;head&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&lt;meta&nbsp;http-equiv=<span class="cs__string">&quot;Content-Type&quot;</span>&nbsp;content=<span class="cs__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;&lt;asp:ContentPlaceHolder&nbsp;ID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;/&gt;&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="cs__string">&quot;../../Content/Site.css&quot;</span>&nbsp;rel=<span class="cs__string">&quot;stylesheet&quot;</span>&nbsp;type=<span class="cs__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;../../Scripts/jquery-1.4.1-vsdoc.js&quot;</span>&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>こうしておくと、それぞれのビューで jQuery のクラスが使えます。一番良く使う $() 関数で現在時刻を表示させてみましょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Script001&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Script3&lt;/h2&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;jQueryを使う&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;time&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;dt&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Date();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="cs__string">'#time'</span>).text(dt.toString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>あらかじめ time という ID の div タグを設定しておき、これを「$('#time')」で参照します。ここでピリオドをタイピングすると、次の図のようにインテリセンス機能が働きます。</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19153/1/image008.gif" border="1" alt="図 8" width="566" height="351"></p>
<p>図 8</p>
<p>jQuery で定義されているメソッドが C# や Visual Basic と同じようにインテリセンスで表示されます。これによって、JavaScript でのコーディングが非常に楽になります。</p>
<p>実行した結果が次の図です。</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19154/1/image009.jpg" alt="図 9" width="600" height="499"></p>
<p>図 9</p>
<p>この他にも jQuery では、コントロールのドラッグ アンド ドロップなどの jQuery UI や、Ajax の機能であるサーバーとの非同期通信の機能もあります。これらの情報は「jQuery」や「jQuery UI」などで検索されると色々な情報が得られるので、ぜひ活用してみてください。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. AjaxHelper を利用する</h2>
<p>ASP.NET MVC には Ajax を使うための AjaxHelper クラスが備わっています。この AjaxHelper を使うと、ASP.NET MVC のコントローラーやユーザー コントロールと連携した機能を手早く作ることができます。</p>
<p>まずは、マスター ページで MicrosoftAjax.js と MicrosoftMvcAjax.js の 2 つのファイルを読み込ませます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Master&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewMasterPage&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;!DOCTYPE&nbsp;html&nbsp;PUBLIC&nbsp;<span class="cs__string">&quot;-//W3C//DTD&nbsp;XHTML&nbsp;1.0&nbsp;Strict//EN&quot;</span>&nbsp;<span class="cs__string">&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd&quot;</span>&gt;&nbsp;
&lt;html&nbsp;xmlns=<span class="cs__string">&quot;http://www.w3.org/1999/xhtml&quot;</span>&gt;&nbsp;
&lt;head&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&lt;meta&nbsp;http-equiv=<span class="cs__string">&quot;Content-Type&quot;</span>&nbsp;content=<span class="cs__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;&lt;asp:ContentPlaceHolder&nbsp;ID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;/&gt;&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="cs__string">&quot;../../Content/Site.css&quot;</span>&nbsp;rel=<span class="cs__string">&quot;stylesheet&quot;</span>&nbsp;type=<span class="cs__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;../../Scripts/MicrosoftAjax.js&quot;</span>&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="cs__string">&quot;../../Scripts/MicrosoftMvcAjax.js&quot;</span>&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>次にビューを新規に作成して、日付の表示を行うタグと、AjaxHelper の ActionLink メソッドを使って、コントローラーに定義する GetDateTime アクション メソッドの呼出しを記述します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Script4&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;AjaxHelper&nbsp;を使う&lt;/p&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;日時:&nbsp;&lt;span&nbsp;id=<span class="cs__string">&quot;time&quot;</span>&gt;&lt;/span&gt;&lt;/p&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Ajax.ActionLink(<span class="cs__string">&quot;日付を取得&quot;</span>,&nbsp;<span class="cs__string">&quot;GetDateTime&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;AjaxOptions&nbsp;{&nbsp;UpdateTargetId&nbsp;=&nbsp;<span class="cs__string">&quot;time&quot;</span>&nbsp;})%&gt;&nbsp;
&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;asp:Content&nbsp;ID=<span class="visualBasic__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="visualBasic__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="visualBasic__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Script4&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;AjaxHelper&nbsp;を使う&lt;/p&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;日時:&nbsp;&lt;span&nbsp;id=<span class="visualBasic__string">&quot;time&quot;</span>&gt;&lt;/span&gt;&lt;/p&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Ajax.ActionLink(<span class="visualBasic__string">&quot;日付を取得&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;GetDateTime&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;AjaxOptions()&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.UpdateTargetId&nbsp;=&nbsp;<span class="visualBasic__string">&quot;time&quot;</span>})%&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>ActionLink メソッドでは、リンクに表示する文字列と、呼び出すアクション メソッドを指定します。そして、コールバックが返ってきたときに、表示させるタグの ID を UpdateTargetId に指定しておきます。</p>
<p>コントローラーに記述する GetDateTime アクション メソッドは次のコードになります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;GetDateTime()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Request.IsAjaxRequest())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Content(DateTime.Now.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;EmptyResult();&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Function</span>&nbsp;GetDateTime()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Request.IsAjaxRequest&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Content(DateTime.Now)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;EmptyResult&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>Request オブジェクトの IsAjaxRequest メソッドを使うと、Ajax による非同期呼出しかどうかの判別ができます。Ajax からの呼び出しの時は、Content クラスを使って現在時刻を返しています。</p>
<p>これを実行すると次の図になります。</p>
<p><img src="http://i1.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19155/1/image010.jpg" alt="図 10" width="600" height="430"></p>
<p>図 10</p>
<p>「日付を取得」のリンクをクリックしたときには画面遷移はしません。「日時」のところの span タグにコントローラーの GetDateTime メソッドの結果が反映されます。</p>
<p>この方法は、単純な文字列や数値を返すときに利用できます。次に示す Ajax.BeginForm メソッドと合わせて利用すると、ユーザー登録時の重複チェックや、郵便番号から住所を返すなどの Ajax 処理を作成することができます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6. AjaxHelper でユーザー コントロールを埋め込む</h2>
<p>先の例では、文字列を表示しただけですが、AjaxHelper を使うとユーザー コントロールの結果をページに動的に表示させることができます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Script6&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;AjaxHelper&nbsp;を使う&lt;/p&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;<span class="cs__keyword">using</span>&nbsp;(Ajax.BeginForm(<span class="cs__string">&quot;GetProduct&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;AjaxOptions{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpMethod=<span class="cs__string">&quot;POST&quot;</span>,&nbsp;UpdateTargetId&nbsp;=&nbsp;<span class="cs__string">&quot;detail&quot;</span>}))&nbsp;{&nbsp;&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;商品ID:&nbsp;&lt;%:&nbsp;Html.TextBox(<span class="cs__string">&quot;productid&quot;</span>)&nbsp;%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="cs__string">&quot;submit&quot;</span>&nbsp;<span class="cs__keyword">value</span>=<span class="cs__string">&quot;送信&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;}&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;detail&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;asp:Content&nbsp;ID=<span class="visualBasic__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="visualBasic__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="visualBasic__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Script6&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;AjaxHelper&nbsp;を使う&lt;/p&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;Ajax.BeginForm(<span class="visualBasic__string">&quot;GetProduct&quot;</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;AjaxOptions&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HttpMethod&nbsp;=&nbsp;<span class="visualBasic__string">&quot;POST&quot;</span>,&nbsp;.UpdateTargetId&nbsp;=&nbsp;<span class="visualBasic__string">&quot;detail&quot;</span>})%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;商品ID:&nbsp;&lt;%:&nbsp;Html.TextBox(<span class="visualBasic__string">&quot;productid&quot;</span>)&nbsp;%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="visualBasic__string">&quot;submit&quot;</span>&nbsp;value=<span class="visualBasic__string">&quot;送信&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="visualBasic__string">&quot;detail&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>この例では、Html.BeginForm メソッドと同じようににテキスト ボックスを表示させて、送信ボタンでサーバーに商品 ID を通知します。ただし、HtmlBeginForm メソッドを使った場合は、コントローラーで次の画面に遷移させますが、Ajax.BeginForm メソッドを用いた場合は指定した ID のタグにコントローラーからの結果が反映されます。このため画面遷移をせずに、整形済みのユーザー コントロールを埋め込むことができます。</p>
<p>Ajax.BeginForm メソッドでは、GetProduct アクション メソッドを呼び出します。送信するプロトコル メソッドは「POST」としています。これは、Html.FormBegin メソッドと同じようにアクション メソッドが URL で指定した場合には動作しないようにするためです。また、受信した結果は「detail」という ID を持つタグに表示されます。</p>
<p>GetProduct アクション メソッドが次のコードになります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">[HttpPost]&nbsp;<br><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;GetProduct(FormCollection&nbsp;collection)&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Request.IsAjaxRequest())&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;id&nbsp;=&nbsp;collection[<span class="cs__string">&quot;productid&quot;</span>];&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Models.mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;(from&nbsp;t&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TProduct&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;t.id&nbsp;==&nbsp;id&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;t).FirstOrDefault();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(<span class="cs__string">&quot;ProductDetail&quot;</span>,&nbsp;model);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;EmptyResult();&nbsp;<br>}&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&lt;HttpPost()&gt;&nbsp;<br><span class="visualBasic__keyword">Function</span>&nbsp;GetProduct(<span class="visualBasic__keyword">ByVal</span>&nbsp;collection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;FormCollection)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Request.IsAjaxRequest&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;id&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;collection(<span class="visualBasic__string">&quot;productid&quot;</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ent&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;mvcdbEntities()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;model&nbsp;=&nbsp;(From&nbsp;t&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;ent.TProduct&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;t.id&nbsp;=&nbsp;id&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;t).FirstOrDefault&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View(<span class="visualBasic__string">&quot;ProductDetail&quot;</span>,&nbsp;model)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;EmptyResult&nbsp;<br><span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>まず、Request.IsAjaxRequest メソッドで Ajax による非同期呼出しかどうかを判断します。</p>
<p>商品 ID は、productid という名前でコレクションから取得します。この商品 ID を使ってデータベースを検索します。</p>
<p>検索した結果は、ProductDetail というテンプレートに表示させます。実際は、この中身がそのまま、Web ページの一部として表示されます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Control&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewUserControl&lt;MvcApplication1.Models.TProduct&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;fieldset&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;legend&gt;Fields&lt;/legend&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;id&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.id&nbsp;%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;name&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.name&nbsp;%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;price&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.price&nbsp;%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;cateid&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.cateid&nbsp;%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&lt;/fieldset&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>このテンプレートはビューの追加ダイアログから作成します。モデルを利用するテンプレートを作る場合は、図のように「部分ビュー (.ascx) を作成する」にチェックを入れます。</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19156/1/image011.gif" alt="図 11"></p>
<p>図 11</p>
<p>商品 ID を入力して、送信ボタンをクリックすると画面遷移をせずに商品の詳細情報が表示されます。このサンプルでは、あらかじめ<a href="http://ec.nikkeibp.co.jp/item/books/P94380.html" target="_blank">「ひと目でわかる ASP.NET MVC アプリケーション開発入門」</a>のサンプル データベースをインストールした後、LINQ to Entities を作成して表示させています。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. Ajax 処理をまとめてみると</h2>
<p>Ajax でテンプレートを表示する仕組みを図で説明します。</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-6a7b270b/image/file/19157/1/image012.gif" alt="図 12" width="600" height="317"></p>
<p>図 12</p>
<ol>
<li>ブラウザー上で、Ajax による非同期呼出しを行います。これは、通常の ASP.NET MVC のコントローラーのアクション メソッドを呼び出す時と同じ動作になります。
</li><li>アクション メソッド内では、Request.IsAjaxRequest メソッドを使って、ブラウザーから Ajax による非同期呼出しが行われたかどうかを判断します。非同期呼出しの場合には、データベースからデータを検索します。
</li><li>検索した結果をモデルに設定して、ビューに引き渡します。このとき、ビューとなるテンプレート (*.ascx) を指定します。 </li><li>テンプレートが、部分的なビューを作成して、非同期呼出しの応答データとして返します。 </li><li>応答から返ってきたデータを、jQuery により指定したタグ内に書き込みます。 </li></ol>
<p>これによって、Ajax の処理 はブラウザーの部分的な更新が可能になっています。この方法は、ASP.NET MVC アプリケーションに限りませんが、ビューで AjaxHelper を利用することにより、簡単に ASP.NET MVC のコントローラーを扱うことができます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="08">8. おわりに</h2>
<p>JavaScript、jQuery、AjaxHelper ということで、ASP.NET MVC とは少し違った趣向で解説していきましたがいかがだったでしょうか。JavaScript は主にブラウザー上のプログラム言語ですが、jQuery のようにライブラリ化することで高機能な動作を簡単に記述できたり、Ajax のようにサーバー技術と組み合わせることで、いままでとは違ったユーザー インターフェースを作ることができます。</p>
<p>例えば、RSS データを受信してブラウザーの一部を更新したり、ブログ パーツのデータ取得のバックエンドとして ASP.NET MVC を利用することも可能です。Ajax の機能を前面に押し出して、ASP.NET MVC のコントローラーをバックエンドにすると、また違った形で MVC パターンが利用できるので、ぜひ試してみてください。</p>
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
