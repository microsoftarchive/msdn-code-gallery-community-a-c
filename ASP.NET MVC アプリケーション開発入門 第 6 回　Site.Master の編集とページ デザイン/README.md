# ASP.NET MVC アプリケーション開発入門: 第 6 回　Site.Master の編集とページ デザイン
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- ASP.NET MVC
## Topics
- ASP.NET MVC アプリケーション
- 連載! ASP.NET MVC
## Updated
- 03/07/2011
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
<ol style="margin-bottom:0">
<li><a href="#01">はじめに</a> </li><li><a href="#02">マスター ページとは</a> </li><li><a href="#03">マスター ページとコンテンツ ページの関係</a> </li><li><a href="#04">特定のページだけマスター ページを切り替える</a> </li><li><a href="#05">マスター ページにコードを記述する</a> </li><li><a href="#06">Internet Explorer の開発ツールを使う</a> </li><li><a href="#07">ASP.NET MVC 3 のマスター ページ</a> </li><li><a href="#08">おわりに</a> </li></ol>
<div style="clear:both"></div>
<hr>
<h2 id="01">1. はじめに</h2>
<p>今回は ASP.NET MVC アプリケーションの全体的なデザインを担っているマスター ページに関して解説をしていきます。Visual Studio 2010 で ASP.NET MVC アプリケーションを作成すると、普通にマスター ページが作られます。「ひと目でわかる ASP.NET MVC アプリケーション入門」でも、このマスター ページを使ってサイトを作成しています。</p>
<p>WordPress や Joomla! などのオープン ソースのシステムを使ってサイトを作成すると、タイトルやメニュー表示が統一して表示されています。ASP.NET MVC で作成する Web サイトもマスター ページを使うと、同じように画面が統一されたサイトを作ることができます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. マスター ページとは</h2>
<p>最初に、マスター ページ (Site.Master) がどのように使われているのか見ていきましょう。<br>
マスター ページは、ソリューション エクスプローラーを開くと Views/Shared/Site.Master の場所にあります。</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18803/1/image001.gif" alt="図 1" width="330" height="461"></p>
<p><strong>図 1 ソリューション エクスプローラー</strong></p>
<p>ASP.NET MVC アプリケーションを作成したときは、Site.Master というファイルがひとつだけしかありませんが、このファイルは複数作ることができます。<br>
マスター ページは、他のビューのページ (*.aspx) と同じように HTML タグと ASP.NET のインライン コードで作成されています。</p>
<p>では、手始めにひな型のサイトに表示されている「マイ MVC アプリケーション」の表題を「日経 BP ショッピング」に変更してみましょう。<br>
マスター ページの h1 タグの部分を以下のように書き換えます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;page&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;header&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;title&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;日経BPショッピング&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;logindisplay&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;Html.RenderPartial(<span class="cs__string">&quot;LogOnUserControl&quot;</span>);&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>すると、以下の図のように表題が変更になります。</p>
<p><img src="http://i1.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18804/1/image002.gif" alt="図 2" width="559" height="418"></p>
<p><strong>図 2 実行結果</strong></p>
<p><strong><br>
</strong></p>
<p>今度は、ブラウザのタイトルを変えていきます。ページを作成したときには「Index」のように、aspx ページの名前がそのまま使われているので、これを「日経 BP ショッピング - トップ ページ」のように変更します。</p>
<p>タイトルの設定は、それぞれのビューで指定されているので、以下の部分を書き換えます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;IEnumerable&lt;MvcApplication1.Models.TProduct&gt;&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日経ショッピング&nbsp;-&nbsp;トップページ&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&lt;%@&nbsp;Page&nbsp;Title=<span class="visualBasic__string">&quot;&quot;</span>&nbsp;Language=<span class="visualBasic__string">&quot;VB&quot;</span>&nbsp;MasterPageFile=<span class="visualBasic__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;<span class="visualBasic__keyword">Inherits</span>=<span class="visualBasic__string">&quot;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.Mvc.ViewPage.aspx" target="_blank" title="Auto generated link to System.Web.Mvc.ViewPage">System.Web.Mvc.ViewPage</a>(Of&nbsp;IEnumerable&nbsp;(Of&nbsp;MvcApplication1.TProduct))&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="visualBasic__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="visualBasic__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="visualBasic__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日経ショッピング&nbsp;-&nbsp;トップページ&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>するとブラウザーのタイトル部分が変更されます。</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18805/1/image003.gif" alt="図 3" width="559" height="233"></p>
<p><strong>図 3 実行結果</strong></p>
<p>&nbsp;</p>
<p>このように、サイトとして統一した部分はマスター ページ (Site.Master など) に記述し、それぞれのページに特有な情報はビュー (Index.aspx など) に記述し、それぞれを使い分けます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. マスター ページとコンテンツ ページの関係</h2>
<p>もう少し詳しくマスター ページとコンテンツのページとを比較していきましょう。</p>
<p>先ほど、Index.aspx のファイルでブラウザーのタイトルを記述しましたが、これはどこに反映されているのでしょうか。Index.aspx ファイルでは、asp:Content という ASP.NET のタグを使って値を定義しています。これに、ContentPlaceHolderID 属性で値を「TitleContent」として設定していました。</p>
<p>今度は、Site.Master ファイルを見ていくと、title タグの間に、asp:ContentPlaceHolder という ASP.NET のタグが指定されています。この ID の値は、「TitleContent」となっています。</p>
<p><img src="http://i1.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18806/1/image004.gif" alt="図 4-1" width="559" height="356"></p>
<p><strong>図 4-1 マスター ページとコンテンツ ページの関係 - 1</strong></p>
<p><strong><br>
</strong></p>
<p>同じように商品リストを表示しているコンテンツを見ていくと asp:Content タグの ContentPlaceHolderID 属性に「MainContent」という値が設定されています。Site.Master ファイルでは、asp:ContentPlaceHolder タグの ID 属性に「MainContent」が設定されています。</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18807/1/image005.gif" alt="図 4-2" width="580" height="568"></p>
<p><strong>図 4-2 マスター ページとコンテンツページの関係 - 2</strong></p>
<p><strong><br>
</strong></p>
<p>このように、コンテンツのページでは asp:Content というタグを使って設定しておき、マスター ページでは asp:ContentPlaceHolder タグで位置を指定するという形になります。2 つのサーバー スクリプト タグを利用すると、コンテンツのページからマスター ページへ情報のやり取りができます。あらかじめ、マスター ページで表示する場所として asp:ContentPlaceHolder タグを記述しておき、必要に応じてコンテンツのページで asp:Content を設定します。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. 特定のページだけマスター ページを切り替える</h2>
<p>マスター ページはサイトにひとつだけではありません。コンテンツ ページから利用するマスター ページを切り替えることができます。例えば、お問い合わせのページや運営会社の説明のページだけのデザインを別にすることが可能です。</p>
<p>通常は、新しいページを追加するときにマスター ページを選択しますが、今回は既にある「このサイトについて」の about.aspx のマスター ページを切り替えてみましょう。</p>
<p><img src="http://i1.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18808/1/image006.gif" alt="図 5-1" width="443" height="516"></p>
<p><strong>図 5-1 ビューの追加 - 1</strong></p>
<p><strong><br>
</strong></p>
<p>既にある Site.Master ファイルをコピーして、SiteAbout.Master という名前に変更します。</p>
<p><img src="http://i3.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18809/1/image007.gif" alt="図 5-2" width="276" height="261"></p>
<p><strong>図 5-2 ビューの追加 - 2</strong></p>
<p><strong><br>
</strong></p>
<p>ここでは、表題と背景色を変えています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;head&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&lt;meta&nbsp;http-equiv=<span class="cs__string">&quot;Content-Type&quot;</span>&nbsp;content=<span class="cs__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;&lt;asp:ContentPlaceHolder&nbsp;ID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;/&gt;&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="cs__string">&quot;../../Content/Site.css&quot;</span>&nbsp;rel=<span class="cs__string">&quot;stylesheet&quot;</span>&nbsp;type=<span class="cs__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&lt;/head&gt;&nbsp;
&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;page&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;header&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;title&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;問合せ専用のマスターページ&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>次に about.aspx のファイルを開いて、先頭のマスター ページの記述を書き換えます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;%@&nbsp;Page&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/SiteAbout.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&lt;%@&nbsp;Page&nbsp;Language=<span class="visualBasic__string">&quot;VB&quot;</span>&nbsp;MasterPageFile=<span class="visualBasic__string">&quot;~/Views/Shared/SiteAbout.Master&quot;</span>&nbsp;<span class="visualBasic__keyword">Inherits</span>=<span class="visualBasic__string">&quot;System.Web.Mvc.ViewPage&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>実行すると、「このサイトについて」のページの背景だけがピンク色になります。</p>
<p><img src="http://i4.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18810/1/image008.gif" alt="図 6"></p>
<p><strong>図 6 実行結果</strong></p>
<p>&nbsp;</p>
<p>マスター ページを独自に作る時は、新しい項目の追加ダイアログ ボックスで「MVC 2 ビュー マスター ページ」を選択して作成していきます。</p>
<p><img src="http://i1.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18812/1/image009.gif" alt="図 7" width="560" height="387"></p>
<p><strong>図 7 マスター ページの作成</strong></p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. マスター ページにコードを記述する</h2>
<p>マスター ページでは、CSS や 画像ファイルを指定することによりレイアウトを変更できます。</p>
<p>ここでは、背景画像、タイトル画像、アクセス解析のコードを記述してみます。</p>
<p>参照する CSS は、Content/Site.css ですので、この body タグへの記述を変更します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">css</span>

<div class="preview">
<pre class="css"><span class="css__element">body</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background-color:</span>&nbsp;pink;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-size:</span>&nbsp;.<span class="css__number">75em</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">font-family:</span>&nbsp;Verdana,&nbsp;Helvetica,&nbsp;Sans-Serif;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">margin:</span>&nbsp;<span class="css__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">padding:</span>&nbsp;<span class="css__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">color:</span>&nbsp;<span class="css__color">#696969</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background-image:</span>&nbsp;<span class="css__url">url(</span>'/images/background.jpg'<span class="css__url">)</span>;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>実際には、メニューの表示などで使われているスタイル シート記述も変更します。</p>
<p>タイトル画像などはマスター ページに直接記述します。このようにすることで、どのページでも同じタイトル画像や広告記事を表示させることができます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;page&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;header&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;title&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;image&nbsp;src=<span class="cs__string">&quot;/images/title.png&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;logindisplay&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;Html.RenderPartial(<span class="cs__string">&quot;LogOnUserControl&quot;</span>);&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;menucontainer&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ul&nbsp;id=<span class="cs__string">&quot;menu&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;ホーム&quot;</span>,&nbsp;<span class="cs__string">&quot;Index&quot;</span>,&nbsp;<span class="cs__string">&quot;Home&quot;</span>)%&gt;&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;このサイトについて&quot;</span>,&nbsp;<span class="cs__string">&quot;About&quot;</span>,&nbsp;<span class="cs__string">&quot;Home&quot;</span>)%&gt;&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;Javascript&nbsp;アクセス解析を埋め込む&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;accessLogs&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=<span class="cs__string">&quot;text/javascript&quot;</span>&gt;&lt;!--&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.write(<span class="cs__string">&quot;&lt;b&gt;ここにアクセス解析のコードを書きます&lt;/b&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//--&gt;&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;main&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ContentPlaceHolder&nbsp;ID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="cs__string">&quot;footer&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>これを実行した結果が次の図です。</p>
<p><img src="http://i4.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18814/2/image010.gif" alt="図 8" width="580" height="497"></p>
<p><strong>図 8 実行結果</strong></p>
<p><strong><br>
</strong></p>
<p>このようにマスター ページを使うことによって、サイトのレイアウトを簡単に統一させることができ、同時に変更する場所も少なくて済みます。また、マスター ページを切り替えることで、コンテンツの種類ごとにデザインを変えることが可能です。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6. Internet Explorer の開発ツールを使う</h2>
<p>デザインを変更するためには、CSS (カスケード スタイル シート) を変更しますが、この記述はなかなか難しいものがあります。色々なデザイン ツールがあるので、それを使って修正してもよいのですが、ちょっとした変更であれば Internet Explorer 8/9 の「開発ツール」を使うとよいでしょう。</p>
<p>Internet Explorer 8 のメニューを Alt キーで表示させた後に「ツール」&rarr;「開発ツール」を選択するか、F12 キーを押します。すると、次のように現在表示されているページを解析したウィンドウが表示されます。</p>
<p><img src="http://i4.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18816/1/image011.gif" alt="図 9" width="559" height="431"></p>
<p><strong>図 9 開発ツールによるデザインの変更</strong></p>
<p><strong><br>
</strong></p>
<p>開発ツールでは、ページで使われている HTML タグが階層構造になって表示されています。この階層構造を開くことにより変更したい HTML タグを特定することができます。図のように div タグで囲まれたタイトル部分は、ブラウザーでは青い線で囲まれます。</p>
<p>指定されている CSS のファイルやタグ名が表示されるので、どこを変更したらよいかが分かります。直接、値を変更することができるので、色や幅を変えてすぐに確認ができます。</p>
<p>複雑な CSS の場合には、Internet Explorer の開発ツールを利用して、修正する箇所を絞り込むとよいでしょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. ASP.NET MVC 3 のマスター ページ</h2>
<p>最後に ASP.NET MVC 3 の新しい Razor ビュー エンジンでは、マスター ページと同等の機能がどのように用意されているかを見ていきましょう。</p>
<p>ソリューション エクスプローラーを見ると、マスター ページに当たるものは Views/Shared/_Layout.cshtml (VB の場合は _Layout.vbhtml) になります。</p>
<p>&nbsp;</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18817/1/image012.gif" alt="図 10" width="261" height="239"></p>
<p><strong>図 10 Razor ビュー エンジンのレイアウト ページ</strong></p>
<p>コンテンツとレイアウト ページ (マスター ページに相当するもの) との対応は非常に簡単になっています。Index.cshtml (VB では Index.vbhtml) からブラウザーのタイトルを変更する箇所は ViewBag.Title に値を設定しています。これを、レイアウト ページでは同じ ViewBag.Title で入力しています。</p>
<p>また、レイアウト ページでコンテンツ ページを表示する部分は、Views/Shared/_ViewStart.cshtml (VB では _ViewStart.vbhtml) にある Layout 変数に指定されている _Layout.cshtml (VB では _Layout.vbhtml) になります。このファイルが、aspx のマスター ページにあたる処理をしています。</p>
<p>ログインのようなユーザー コントロールの表示は、Html.Partial メソッドで、コンテンツの表示は RenderBody メソッドが使われています。</p>
<p>&nbsp;</p>
<p><img src="http://i4.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18818/1/image013.gif" alt="図 11" width="559" height="302"></p>
<p><strong>図 11 Razor ビュー エンジンのコンテンツ ページ</strong></p>
<p>&nbsp;</p>
<p>ASP.NET MVC 2 と同じようにタイトル画像と背景画像を変更して実行すると、ページ レイアウトを変更することができます。</p>
<p><img src="http://i2.code.msdn.microsoft.com/aspnet-mvc-61e5bf22/image/file/18819/1/image014.gif" alt="図 12" width="560" height="391"></p>
<p><strong>図 12 Razor ビュー エンジンによるページ レイアウトの変更</strong></p>
<p>コンテンツの表示部分が ASP.NET MVC 2 とは若干違いますが、マスター ページとの連携が asp:Content タグや asp:ContentPlaceHolder タグの記述よりも随分と簡単になっています。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="08">8. おわりに</h2>
<p>いかがだったでしょうか。ASP.NET MVC では各コンテンツ ページを細かく作るのではなく、サイト全体を統一したイメージで作れるように工夫がなされています。前回解説をしたユーザー コントロールと組み合わせることによって Web サイトの全体の外観を揃え、各コンテンツで使う部品 (コントロール) も揃えてデザインすることが可能です。</p>
<p>サイトのデザイン変更では、CSS を新しく作って開始しても良いのですが、Internet Explorer の開発ツールを利用しながら部分的に好みのデザインに変えても良いと思います。大雑把なデザインを作った上でデータ表示などを確認し、それから綺麗なデザインを煮詰めていくプロセスを踏んでもいいでしょう。</p>
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
