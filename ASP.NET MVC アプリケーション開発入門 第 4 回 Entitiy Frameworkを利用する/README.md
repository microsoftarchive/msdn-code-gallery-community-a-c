# ASP.NET MVC アプリケーション開発入門: 第 4 回 Entitiy Frameworkを利用する
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- ASP.NET MVC
## Topics
- ASP.NET MVC アプリケーション
- 連載! ASP.NET MVC
## Updated
- 09/04/2011
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
<li><a href="#01">ADO.NET Entity Framework とは?</a> </li><li><a href="#02">デザイナーで Entity Data Model を作成する</a> </li><li><a href="#03">商品一覧を表示する</a> </li><li><a href="#04">テーブルのリレーションを利用する</a> </li><li><a href="#05">ビューでカテゴリ名を表示させる</a> </li><li><a href="#06">商品の新規作成と更新ページを作る</a> </li><li><a href="#07">複雑なテーブルを Entity Data Model で扱う</a> </li><li><a href="#08">おわりに</a> </li></ol>
<div style="clear:both"></div>
<hr>
<h2 id="01">1. ADO.NET Entity Framework とは?</h2>
<p>今回は、データベースを扱うフレームワーク「ADO.NET Entity Framework」を使ってサンプルを動かしていきます。</p>
<p>ADO.NET Entity Framework は、データベースとオブジェクト指向を橋渡しするフレームワークになります。Visual Studio 2010 では、 Entity Data Model デザイナーと呼ばれるビジュアルにモデルを扱う機能が用意されています。Entity Data Model デザイナー上で、データ構造やリレーションを確認しながら、ASP.NET MVC アプリケーションでコントローラーやビューのコーディングができます。</p>
<p>詳細な情報は <a href="http://msdn.microsoft.com/ja-jp/data/ef" target="_blank">ADO.NET Entity Framework</a> や、<a href="http://msdn.microsoft.com/ja-jp/data/ff723829" target="_blank">SQL Server 2008 R2: サンプルで学ぶ ASP.NET MVC アプリケーション開発</a>を参照してください。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="02">2. デザイナーで Entity Data Model を作成する</h2>
<p>早速 Visual Studio 2010 を使って、Entity Data Model を作成してみましょう。<br>
利用するデータベースは、日経 BP 社より<a href="http://ec.nikkeibp.co.jp/nsp/dl/09438/index.shtml" target="_blank">サンプル プログラム</a>からダウンロードできるので、適宜作成してください。</p>
<p>ASP.NET MVC アプリケーションのプロジェクトに ADO.NET Entity Data Model を追加は、ソリューション エクスプローラーから行います。Models フォルダーを選択し、右クリックした後で「追加」&rarr;「新しい項目」をクリックすると、新しい項目の追加ダイアログ ボックスが開きます。<br>
新しい項目の追加ダイアログ ボックスから、インストールされたテンプレートの「データ」を選択して、「ADO.NET Entity Data Model」をクリックします。</p>
<p><img src="17567-image001.jpg" alt="図 1 新しい項目の追加" width="600" height="377"></p>
<p><strong>図 1 新しい項目の追加</strong></p>
<p>開かれる Entity Data Model ウィザードを使って、データベースからモデルを作成していきます。モデルのコンテンツの選択では、「データベースから生成」を選択します。既にデータベース上にあるテーブルやビューなどを使うことができます。</p>
<p><img src="17568-image002.jpg" alt="図 2 データベースから作成"></p>
<p><strong>図 2 データベースから作成</strong></p>
<p>データ接続の選択のページでは、「新しい接続」ボタンをクリックして、あらかじめ SQL Server 2008 上に作成しておいたデータベースに接続します。<br>
ここではローカル マシン (同じコンピューター) にインストールされているデータベースに接続するために、サーバー名に「(local)\sqlexpress」を入力しています。実際には、「(local)」の部分がコンピューター名、「sqlexpress」 がSQL Server のインスタンス名になります。<br>
データベース名は「mvcdb」としています。</p>
<p><img src="17569-image003.jpg" alt="図 3 接続のプロパティ" width="451" height="788"></p>
<p><strong>図 3 接続のプロパティ</strong></p>
<p>接続のプロパティ ダイアログ ボックスの OK ボタンをクリックして、データ接続の選択に戻ると「エンティティ接続設定に名前を付けて Web.Config に保存」のテキスト ボックスに接続名が設定されます。ここでは「mvcdbEntities」となっています。<br>
この接続名は、コントローラーなどから、Entity Data Model を扱うときの名前になります。命名規則などある場合、ここで変更しておくとよいでしょう。</p>
<p><img src="17570-image004.jpg" alt="図 4 データベース オブジェクトの選択" width="600" height="629"></p>
<p><strong>図 4 データベース オブジェクトの選択</strong></p>
<p>次へボタンをクリックして、データベース オブジェクトの選択のページを開きます。<br>
このページで、モデルに含めるテーブルやビューなどを追加します。モデルに不要なテーブルがある場合は、必要なテーブルのみチェックを入れます。<br>
モデルの名前空間のテキスト ボックスには、リレーションなどで使われる名前空間の名前が入力されています。通常はこのままでよいでしょう。</p>
<p>完了ボタンをクリックすると次のように Entity Data Model が作成されます。</p>
<p><img src="17571-image005.jpg" alt="図 5 Entity Data Model" width="600" height="445"></p>
<p><strong>図 5 Entity Data Model</strong></p>
<p>ASP.NET MVC のコントローラーやビューで Entity Data Model のモデル クラスを参照できるように、ここで一度ビルドをしておきます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="03">3. 商品一覧を表示する</h2>
<p>この Entity Data Model を使って、商品テーブル (TProduct) から一覧を表示させてみましょう。<br>
今回は、商品管理を想定して Admin という名前でコントローラーとビューを作成していきます。</p>
<p>まず、AdminController.cs (VB では AdminController.vb) を作成します。<br>
ソリューション エクスプローラーで Controllers フォルダーを右クリックして、「追加」&rarr;「コントローラー」を選択します。<br>
コントローラーの追加ダイアログ ボックスが開かれるので、コントローラー名を「AdminController」にします。<br>
コントローラーのメソッドを自動生成させるために、「Create、Update、Delete、および Detailes の各シナリオのアクション メソッドを追加する」にチェックを入れて、「追加」ボタンをクリックします。</p>
<p><img src="17572-image006.gif" alt="図 6 コントローラーの追加" width="493" height="232"></p>
<p><strong>図 6 コントローラーの追加</strong></p>
<p>コントローラーの Index メソッドのコードは次のように非常に簡単です。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><span class="cs__com">//</span>&nbsp;<br><span class="cs__com">//&nbsp;GET:&nbsp;/Admin/</span>&nbsp;<br>&nbsp;<br><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;ent.TProduct;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;<br>}&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__com">'</span>&nbsp;<br><span class="visualBasic__com">'&nbsp;GET:&nbsp;/Admin</span>&nbsp;<br>&nbsp;<br><span class="visualBasic__keyword">Function</span>&nbsp;Index()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;mvcdbEntities&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;model&nbsp;=&nbsp;ent.TProduct&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View(model)&nbsp;<br><span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>エンティティの接続オブジェクト (mvcdbEntities) を作成した後で、商品テーブルの一覧 (TProduct) をモデルとして設定するだけです。実際のデータベースの接続やテーブルからの検索は、Entity Data Model 内で行われています。<br>
<br>
次に商品の一覧を表示するためのビュー (Index.aspx) を作成しましょう。<br>
ソリューション エクスプローラーで、Views フォルダー配下に「Admin」フォルダーを作成します。この Admin フォルダーを右クリックして、「追加」&rarr;「ビュー」を選択すると、ビューの追加ダイアログが開かれます。</p>
<p><img src="17579-image007.gif" alt="図 7 ビューの追加" width="443" height="516"></p>
<p><strong>図 7 ビューの追加</strong></p>
<p>ビュー名は「Index」にします。<br>
厳密に型指定されたビューを作成するにチェックを入れて、ビュー データ クラスで「MvcApplication1.Models.TProduct」を選択します。<br>
ビュー コンテンツは「List」を選択して、一覧が表示されるようにします。<br>
追加ボタンを押すと、Index.aspx が自動生成されるので、そのままビルドします。</p>
<p>実行した結果が次の図です。</p>
<p><img src="17581-image008.gif" alt="図 8 実行結果" width="600" height="452"></p>
<p><strong>図 8 実行結果</strong></p>
<p>Entity Data Model のクラスをそのまま ASP.NET MVC のモデルとして扱うと、Visual Studio 2010 でビューが自動生成できるので、非常に手早く商品の一覧のビューが作成できることがわかります。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="04">4. テーブルのリレーションを利用する</h2>
<p>商品一覧の表示では、商品テーブル (TProduct) のデータだけを表示していました。<br>
このデータベースには、商品テーブルにカテゴリID (cateid) という列があります。このカテゴリ ID は、カテゴリ テーブル (TCategory) を参照することでカテゴリ名称を表示できる構成になっています。</p>
<p><img src="17582-image009.gif" alt="図 9 商品テーブルとカテゴリの関係" width="484" height="253"></p>
<p><strong>図 9 商品テーブルとカテゴリの関係</strong></p>
<p>カテゴリ テーブルと商品テーブルは、1 対多の関係になります。このテーブル同士の関係を示すリレーションという機能をうまく使うと、カテゴリ ID (cateid) の表示をカテゴリ名にすることができます。</p>
<p>ダウンロードしたサンプルのデータベースには、外部キー (リレーション) が設定されていないので、次のスクリプトを動かして商品テーブル (TProduct) とカテゴリ テーブル (TCategory) の外部キーを設定します。<br>
外部キーの設定は <a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=56ad557c-03e6-4369-9c1d-e81b33d8026b&displayLang=ja" target="_blank">
Microsoft SQL Server 2008 R2 Management Studio Express</a> などを使うとよいでしょう。</p>
<p><img src="17583-image010.jpg" alt="図 10 SQL Server 2008 Management Studio Express"></p>
<p><strong>図 10 SQL Server 2008 R2 Management Studio Express</strong></p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>ALTER TABLE TProduct <br>
&nbsp;ADD CONSTRAINT FK_TProduct_TCategory <br>
&nbsp;FOREIGN KEY (cateid)<br>
&nbsp;REFERENCES TCategory (id)</p>
</div>
<p>新たに設定したリレーションを Entity Data Model に反映させましょう。<br>
Entity Data Model デザイナーを使うと、既存のデータベースからモデルを更新することが可能です。デザイナーの背景部分を右クリックして、「データベースからモデルを更新」をクリックします。</p>
<p><img src="17584-image011.jpg" alt="図 11 データベースからモデルを更新"></p>
<p><strong>図 11 データベースからモデルを更新</strong></p>
<p>更新ウィザード ダイアログ ボックスが開かれるので、データベース オブジェクトの選択から更新のタブをクリックします。<br>
完了ボタンをクリックすれば、目的のテーブル (TCategory、TProduct） のリレーションが更新されます。</p>
<p><img src="17585-image012.gif" alt="図 12 更新されたデザイナー" width="378" height="256"></p>
<p><strong>図 12 更新されたデザイナー</strong></p>
<p>カテゴリ テーブル (TCategory) と商品テーブル (TProduct) のリレーションがデータベースから更新されていることがわかります。<br>
そして、商品テーブル (TProduct) のクラスのナビゲーション プロパティに「TCategory」が増えています。これにより、商品テーブルからプロパティとしてカテゴリ テーブルの各列を参照することができるようになりました。<br>
同じように、カテゴリ テーブル (TCategory) から商品テーブル (TProduct) の各列を参照することも可能です。<br>
コントローラーとビューで参照ができるように、一度ビルドをしておきます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="05">5. ビューでカテゴリ名を表示させる</h2>
<p>では、Index.aspx のビューを修正して、カテゴリ ID (cateid) の列のカテゴリ名を表示してみます。</p>
<p>ソリューション エクスプローラーで、Views/Admin/Index.aspx を開いて、「&lt;%: item.cateid %&gt;」の箇所を次のように変更します。</p>
<p>&lt;ソース(C#)&gt;</p>
<div style="margin:5px 0px 10px 0; padding:10px; background-color:#dedfde">&lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%: item.TCategory.name %&gt;<br>
&lt;/td&gt;</div>
<p>TProduct エンティティの TCategory プロパティを使い、カテゴリの名称 (name) を表示させます。</p>
<p>これを実行した結果が次の図になります。</p>
<p><img src="17586-image013.gif" alt="図 13 実行結果" width="600" height="434"></p>
<p><strong>図 13 実行結果</strong></p>
<p>このように、データベースのリレーションを利用すると、複数のテーブルを扱うことが容易になります。リレーション先のテーブルがナビゲーション プロパティとして利用できるため、コントローラーで LINQ の記述をするよりもコーディングミスを減らすことができるでしょう。</p>
<p><img src="17587-image014.gif" alt="図 14 ナビゲーション プロパティ" width="378" height="256"></p>
<p><strong>図 14 ナビゲーション プロパティ</strong></p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="06">6.商品の新規作成と更新ページを作る</h2>
<p>更に、商品の新規作成と更新のページを作ってみましょう。<br>
商品リストと同じように、Entity Data Model を使うと少ないコード行でできあがるので、やってみましょう。</p>
<p>ソリューション エクスプローラーで、AdminController.cs (VB では AdminController.vb) を開きます。<br>
次のように、2 つの Create メソッドを変更します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><span class="cs__com">//</span>&nbsp;<br><span class="cs__com">//&nbsp;GET:&nbsp;/Admin/Create</span>&nbsp;<br>&nbsp;<br><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Create()&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TProduct();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;<br>}&nbsp;&nbsp;<br>&nbsp;<br><span class="cs__com">//</span>&nbsp;<br><span class="cs__com">//&nbsp;POST:&nbsp;/Admin/Create</span>&nbsp;<br>&nbsp;<br>[HttpPost]&nbsp;<br><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Create(FormCollection&nbsp;collection)&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;新しい商品を作成</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TProduct();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;列の設定をする</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.id&nbsp;=&nbsp;collection[<span class="cs__string">&quot;id&quot;</span>];&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.name&nbsp;=&nbsp;collection[<span class="cs__string">&quot;name&quot;</span>];&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.price&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(collection[<span class="cs__string">&quot;price&quot;</span>]);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.cateid&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(collection[<span class="cs__string">&quot;cateid&quot;</span>]);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;テーブルに追加する</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ent.AddToTProduct(model);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;更新処理</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ent.SaveChanges();&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>}&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__com">'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;GET:&nbsp;/Admin/Create</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Function</span>&nbsp;Create()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;mvcdbEntities&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;model&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TProduct&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View(model)&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;POST:&nbsp;/Admin/Create</span>&nbsp;
&nbsp;
&lt;HttpPost&gt;&nbsp;_&nbsp;
<span class="visualBasic__keyword">Function</span>&nbsp;Create(<span class="visualBasic__keyword">ByVal</span>&nbsp;collection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;FormCollection)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
<span class="visualBasic__keyword">Try</span>&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;ent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;mvcdbEntities&nbsp;
<span class="visualBasic__com">'&nbsp;新しい商品を作成</span>&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;model&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TProduct&nbsp;
<span class="visualBasic__com">'&nbsp;列の設定をする</span>&nbsp;
model.id&nbsp;=&nbsp;collection(<span class="visualBasic__string">&quot;id&quot;</span>)&nbsp;
model.name&nbsp;=&nbsp;collection(<span class="visualBasic__string">&quot;name&quot;</span>)&nbsp;
model.price&nbsp;=&nbsp;<span class="visualBasic__keyword">Integer</span>.Parse(collection(<span class="visualBasic__string">&quot;price&quot;</span>))&nbsp;
model.cateid&nbsp;=&nbsp;<span class="visualBasic__keyword">Integer</span>.Parse(collection(<span class="visualBasic__string">&quot;cateid&quot;</span>))&nbsp;
<span class="visualBasic__com">'&nbsp;テーブルに追加する</span>&nbsp;
ent.AddToTProduct(model)&nbsp;
<span class="visualBasic__com">'&nbsp;更新処理</span>&nbsp;
ent.SaveChanges()&nbsp;
<span class="visualBasic__keyword">Return</span>&nbsp;RedirectToAction(<span class="visualBasic__string">&quot;Index&quot;</span>)&nbsp;
<span class="visualBasic__keyword">Catch</span>&nbsp;
<span class="visualBasic__keyword">Return</span>&nbsp;View()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>最初の Create メソッドは、商品の新規作成をするために商品一覧 (Index.aspx) などのビューから Create.aspx ページを表示させたときの動作です。ここでは、TCategory オブジェクトを作成しているだけですが、本来は商品 ID を割り振ったり、価&#26684; (price) の初期値を設定しておくとよいでしょう。<br>
2 つめの Create メソッドは、新しい商品の情報をブラウザーで入力した後に、作成 (Create) ボタンをクリックしたときの動作です。<br>
ブラウザーのフォームで入力した値は、FormCollection コレクションに設定されます。数値のエラー処理や空白のチェックはここで行います。<br>
商品テーブルへの行の追加は AddToTProduct メソッドを使い、オブジェクトを追加します。<br>
追加したデータの反映は、接続設定エンティティの SaveChanges メソッドを使います。</p>
<p>次に、新規作成用のビューを作りましょう。<br>
ソリューション エクスプローラーで、Admin フォルダーを右クリックして、ビューの追加ダイアログを表示させます。</p>
<p><img src="17588-image015.gif" alt="図 15 ビューの追加" width="443" height="516"></p>
<p><strong>図 15 ビューの追加</strong></p>
<p>ビュー名は「Create」にします。<br>
厳密に型指定されたビューを作成するにチェックを入れて、ビュー データ クラスで「MvcApplication1.Models.TProduct」を選択しておきます。<br>
ビュー コンテンツは「Create」を選択して、追加のためのテキスト ボックスが表示されるようにします。<br>
追加ボタンを押すと、Create.aspx が自動生成されるので、そのままビルドします。</p>
<p>実行した結果が次の図です。</p>
<p><img src="17589-image016.jpg" alt="図 16 実行結果" width="600" height="545"></p>
<p><strong>図 16 実行結果</strong></p>
<p>商品 ID や商品名を入力して「Create」ボタンをクリックすると、データベースに新しい商品が追加されます。</p>
<p>同じように、商品情報を更新するページを作ってみましょう。</p>
<p>ソリューション エクスプローラーで、AdminController.cs (VB では AdminController.vb) を開き、次のように、2 つの Edit メソッドを変更します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><span class="cs__com">//</span>&nbsp;<br><span class="cs__com">//&nbsp;GET:&nbsp;/Admin/Edit/5</span>&nbsp;<br>&nbsp;&nbsp;<br><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Edit(<span class="cs__keyword">string</span>&nbsp;id)&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;ent.TProduct.Where(m&nbsp;=&gt;&nbsp;m.id&nbsp;==&nbsp;id).Single();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;<br>}&nbsp;<br>&nbsp;<br><span class="cs__com">//</span>&nbsp;<br><span class="cs__com">//&nbsp;POST:&nbsp;/Admin/Edit/5</span>&nbsp;<br>&nbsp;<br>[HttpPost]&nbsp;<br><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Edit(<span class="cs__keyword">string</span>&nbsp;id,&nbsp;FormCollection&nbsp;collection)&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;指定した商品&nbsp;ID&nbsp;で検索する</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;ent.TProduct.Where(m&nbsp;=&gt;&nbsp;m.id&nbsp;==&nbsp;id).Single();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;商品名と価&#26684;を変更する</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.name&nbsp;=&nbsp;collection[<span class="cs__string">&quot;name&quot;</span>];&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.price&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(collection[<span class="cs__string">&quot;price&quot;</span>]);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;データベースを更新する</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ent.SaveChanges();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>}&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__com">'</span>&nbsp;<br><span class="visualBasic__com">'&nbsp;GET:&nbsp;/Admin/Edit/5</span>&nbsp;<br>&nbsp;<br><span class="visualBasic__keyword">Function</span>&nbsp;Edit(<span class="visualBasic__keyword">ByVal</span>&nbsp;id&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ent&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;mvcdbEntities&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;model&nbsp;=&nbsp;ent.TProduct.Where(&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>(m)&nbsp;m.id&nbsp;=&nbsp;id).<span class="visualBasic__keyword">Single</span>()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View(model)&nbsp;<br><span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;<br>&nbsp;<br><span class="visualBasic__com">'</span>&nbsp;<br><span class="visualBasic__com">'&nbsp;POST:&nbsp;/Admin/Edit/5</span>&nbsp;<br>&nbsp;<br>&lt;HttpPost()&gt;&nbsp;_&nbsp;<br><span class="visualBasic__keyword">Function</span>&nbsp;Edit(<span class="visualBasic__keyword">ByVal</span>&nbsp;id&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;collection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;FormCollection)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;mvcdbEntities&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;指定した商品&nbsp;ID&nbsp;で検索する</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;model&nbsp;=&nbsp;ent.TProduct.Where(&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>(m)&nbsp;m.id&nbsp;=&nbsp;id).<span class="visualBasic__keyword">Single</span>()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;商品名と価&#26684;を変更する</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.name&nbsp;=&nbsp;collection(<span class="visualBasic__string">&quot;name&quot;</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.price&nbsp;=&nbsp;<span class="visualBasic__keyword">Integer</span>.Parse(collection(<span class="visualBasic__string">&quot;price&quot;</span>))&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;データベースを更新する</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ent.SaveChanges()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;RedirectToAction(<span class="visualBasic__string">&quot;Index&quot;</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;<br><span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>最初の Edit メソッドは、指定された商品 ID の情報を表示するためのアクション メソッドです。データベースから商品 ID で検索してモデルに設定しています。<br>
2 つめの Edit メソッドは、入力した商品情報を更新するメソッドです。<br>
データを更新するときは、商品 ID で検索した結果に対して値を設定します。その後でデータベースに反映するために SaveChanges メソッドを呼び出します。<br>
この部分の処理は、新規作成と同じように書くことができます。</p>
<p>さて、更新用のビューを作りましょう。<br>
ソリューション エクスプローラーで、Admin フォルダーを右クリックして、ビューの追加ダイアログを表示させます。</p>
<p><img src="17590-image017.gif" alt="図 17 ビューの追加" width="443" height="516"></p>
<p><strong>図 17 ビューの追加</strong></p>
<p>ビュー名は「Edit」にします。<br>
ビュー データ クラスで「MvcApplication1.Models.TProduct」になります。<br>
ビュー コンテンツは「Edit」を選択して、更新のためのテキスト ボックスが表示されるようにします。<br>
追加ボタンを押すと、Edit.aspx が自動生成されるので、そのままビルドします。</p>
<p>実行した結果が次の図です。</p>
<p><img src="17591-image018.jpg" alt="図 18 実行結果" width="600" height="504"></p>
<p><strong>図 18 実行結果</strong></p>
<p>このように、Entity Data Model を ASP.NET MVC アプリケーションと組み合わせて使うと、非常に簡単にデータベースを扱うことが可能です。<br>
ここでは、追加 (Create) と更新 (Edit) のページだけを作りましたが、削除 (Delete) や詳細 (Details) のページも同じように、自動生成の機能を使ってコードを作成することができます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="07">7. 複雑なテーブルをEntity Data Model で扱う</h2>
<p>では、もう少し入り組んだリレーションを持つテーブルの場合はどうでしょうか?</p>
<p>サンプルのデータベースにある在庫数 (TStock) と販売数 (TSales) のテーブルを連携させて、商品の在庫数と販売数を一覧にして表示させてみます。<br>
4 つのテーブル (TProduct、TCategory、TStock、TSales) の関係は、以下の ER 図になります。</p>
<p><img src="17592-image019.jpg" alt="図 19 ER" width="600" height="338"></p>
<p><strong>図 19 ER</strong></p>
<p>商品テーブル (TProduct) とカテゴリ (TCategory) は内部結合になりますが、商品テーブル (TProduct) と在庫数 (TStock)、販売数 (TSales) は外部結合となります。</p>
<p>外部結合を設定するために、以下の 2 つのクエリを実行しておきます。</p>
<div style="margin:20px 0px; padding:10px; background-color:#dedfde">
<p>ALTER TABLE TStock<br>
&nbsp;ADD CONSTRAINT FK_TStock_TProduct <br>
&nbsp;FOREIGN KEY (id)<br>
&nbsp;REFERENCES TProduct (id)<br>
<br>
ALTER TABLE TSales<br>
&nbsp;ADD CONSTRAINT FK_TSales_TProduct<br>
&nbsp;FOREIGN KEY (id)<br>
&nbsp;REFERENCES TProduct (id)</p>
</div>
<p>Entity Data Model デザイナーでモデルを更新しておきます。</p>
<p><img src="17593-image020.jpg" alt="図 20 デザイナーの表示" width="600" height="514"></p>
<p><strong>図 20 デザイナーの表示</strong></p>
<p>商品テーブル (TProduct)、在庫数 (TStock)、販売数 (TSales)の 3 つのリレーションが更新されます。</p>
<p>カテゴリ名を一覧に表示したときのように、ナビゲーション プロパティを使って在庫数と販売数を一覧で表示させてみます。</p>
<p>まず、AdminController.cs (VB では AdminController.vb) に一覧を表示するための List アクション メソッドを追加します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;List()&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;ent.TProduct;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;<br>}&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Function</span>&nbsp;List()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;mvcdbEntities&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;model&nbsp;=&nbsp;ent.TProduct&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View(model)&nbsp;<br><span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>次に一覧を表示するためのビューを作成します。<br>
自動生成をした場合には、カテゴリ名、在庫数、販売数が表示されないので、ビュー (List.aspx) のコードを次のように修正します。</p>
<p>&lt;ソース (C#)&gt;</p>
<div style="margin:5px 0px 10px 0; padding:10px; background-color:#dedfde">
<p>&lt;%@ Page Title=&quot;&quot; Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;IEnumerable&lt;MvcApplication1.Models.TProduct&gt;&gt;&quot; %&gt;<br>
<br>
&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp; List2<br>
&lt;/asp:Content&gt;<br>
<br>
&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;h2&gt;List2&lt;/h2&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;table&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;tr&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;&lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; name<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; price<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cateid<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stock<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; sales<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/tr&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;% foreach (var item in Model) { %&gt;<br>
&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;tr&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, new { id=item.id }) %&gt; |<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, new { id=item.id })%&gt; |<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Delete&quot;, &quot;Delete&quot;, new { id=item.id })%&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.id %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.name %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.price %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.cateid %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.TCategory.name %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.TStock.num %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.TSales.num %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/tr&gt;<br>
&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp; &lt;% } %&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;/table&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;p&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;) %&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;/p&gt;<br>
<br>
&lt;/asp:Content&gt;</p>
</div>
<p>&lt;ソース (VB)&gt;</p>
<div style="margin:5px 0px 10px 0; padding:10px; background-color:#dedfde">
<p>&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Web.Mvc.ViewPage.aspx" target="_blank" title="Auto generated link to System.Web.Mvc.ViewPage">System.Web.Mvc.ViewPage</a>(Of IEnumerable (Of MvcApplication1.TProduct))&quot; %&gt;<br>
<br>
&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp; List<br>
&lt;/asp:Content&gt;<br>
<br>
&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;h2&gt;List&lt;/h2&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;p&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;)%&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;/p&gt;<br>
&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp; &lt;table&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;tr&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;&lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; name<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; price<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cateid<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stock<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sales<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/th&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/tr&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;% For Each item In Model%&gt;<br>
&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;tr&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, New With {.id = item.id})%&gt; |<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, New With {.id = item.id})%&gt; |<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: Html.ActionLink(&quot;Delete&quot;, &quot;Delete&quot;, New With {.id = item.id})%&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.id %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.name %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.price %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.TCategory.name %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.TStock.num %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%: item.TSales.num %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/tr&gt;<br>
&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp; &lt;% Next%&gt;<br>
<br>
&nbsp;&nbsp;&nbsp; &lt;/table&gt;<br>
<br>
&lt;/asp:Content&gt;</p>
</div>
<p>実はそのままビルドして実行すると、次の図のようにエラーになります。</p>
<p><img src="17594-image021.jpg" alt="図 21-1 エラー表示" width="600" height="380"></p>
<p><strong>図 21-1 エラー表示</strong></p>
<p>ナビゲーション プロパティの TStock と TSales は外部結合のために、結合先のテーブルに行がないときには null (VB の場合は Nothing) となります。このために 例外 (NullReferenceException) が発生しています。<br>
<br>
List.aspx の例外が発生している箇所を次のように修正します。</p>
<p>&lt;ソース(C#)&gt;</p>
<div style="margin:5px 0px 10px 0; padding:10px; background-color:#dedfde">
<p>&lt;td&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;%: (item.TStock == null)? 0: item.TStock.num %&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;%: (item.TSales == null)? 0: item.TSales.num %&gt;<br>
&lt;/td&gt;</p>
</div>
<p>&lt;ソース(VB)&gt;</p>
<div style="margin:5px 0px 10px 0; padding:10px; background-color:#dedfde">
<p>&lt;td&gt;<br>
&lt;%: If(item.TStock Is Nothing, 0, item.TStock.num)%&gt;<br>
&lt;/td&gt;<br>
&lt;td&gt;<br>
&lt;%: If(item.TStock Is Nothing, 0, item.TSales.num)%&gt;<br>
&lt;/td&gt;</p>
</div>
<p>あらかじめ、参照先のナビゲーション プロパティが null (VB では Nothing) でないことをチェックして表示させます。<br>
こうすると、次のように正常に一覧が表示されます。</p>
<p><img src="17595-image022.gif" alt="" width="600" height="462"></p>
<p><strong>図 21-2 実行結果</strong></p>
<p>ただし、このようにビューでプロパティの値を判別するとコーディング ミスが多くなりがちです。<br>
また、プロパティの値のチェックがビューに散在するために、テーブルの仕様が変更になった場合、多くのビューを変更しなければいけません。</p>
<p>このような場合は、データベースであらかじめ View を作成するとよいでしょう。<br>
次のような VProduct という View を作成しておきます。</p>
<div style="margin:5px 0px 10px 0; padding:10px; background-color:#dedfde">
<p>CREATE VIEW VProduct AS <br>
SELECT <br>
&nbsp;TProduct.id, <br>
&nbsp;TProduct.name, <br>
&nbsp;TProduct.price, <br>
&nbsp;TProduct.cateid,<br>
&nbsp;TCategory.name AS cate,<br>
&nbsp;ISNULL(TStock.num,0) AS stock, <br>
&nbsp;ISNULL(TSales.num,0) AS sale<br>
FROM <br>
TProduct inner join TCategory on TProduct.cateid = TCategory.id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;left outer join TStock on TProduct.id = TStock.id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;left outer join TSales on TProduct.id = TSales.id</p>
</div>
<p>在庫数 (TStock) と販売数 (TSales)&nbsp; のテーブル対して、あらかじめ外部結合をした View を作成します。<br>
列が見つからない場合には、在庫数/販売数を 0 に設定します。<br>
<br>
View を作成した状態で、再び Entity Data Model を更新します。<br>
更新ウィザード ダイアログ ボックスでは、追加のタブを選択してビューの VProduct にチェックを入れます。</p>
<p><img src="17596-image023.jpg" alt="図 22 更新ウィザード" width="600" height="633"></p>
<p><strong>図 22 更新ウィザード</strong></p>
<p>完了ボタンをクリックすると、VProduct が Entity Data Model デザイナーに VProduct が追加されます。</p>
<p><img src="17597-image024.jpg" alt="図 23 デザイナー" width="600" height="377"></p>
<p><strong>図 23 デザイナー</strong></p>
<p>一度ビルドをした後に、コントローラーの List メソッドを以下のように修正します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;List()&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;ent.VProduct;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;<br>}&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>

<pre id="codePreview" class="js"><span class="js__object">Function</span>&nbsp;List()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;ent&nbsp;As&nbsp;New&nbsp;mvcdbEntities&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;model&nbsp;=&nbsp;ent.VProduct&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;View(model)&nbsp;<br>End&nbsp;<span class="js__object">Function</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p>次に List.aspx を削除して、再びビューを作成します。<br>
ビューの追加ダイアログ ボックスでは、ビュー データ クラスを「MvcApplication1.Models.VProduct」に設定します。</p>
<p><img src="17598-image025.gif" alt="図 24 ビューの追加" width="443" height="516"></p>
<p><strong>図 24 ビューの追加</strong></p>
<p>そのままビルドをして実行した結果が次の図になります。</p>
<p><img src="17599-image026.gif" alt="図 25 実行結果" width="600" height="539"></p>
<p><strong>図 25 実行結果</strong></p>
<p>このように Entity Data Model では、テーブルだけではなくデータベースのビューも追加することができます。複数のテーブルからリストを表示する場合はデータベースのビューを活用するとよいでしょう。<br>
同じように、ストアド プロシージャを Entity Data Model から使うこともできます。データベースへの更新処理をストアド プロシージャに記述することで、データの詳細構造をデータベース側に分離させ、ASP.NET MVC のコントローラーやビューへの影響を少なくすることができます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" border="0" alt=""> ページのトップへ</a></p>
<hr>
<h2 id="08">8. おわりに</h2>
<p>いかがだったでしょうか。<br>
ADO.NET Entity Framework には、データベースからモデルの更新 (あるいはモデルからデータベースへの更新) の機能が加わって、よりデータベースを扱いやすくなっています。<br>
ASP.NET MVC と組み合わせでは、Entity Data Model をそのままモデルとして利用ができ、コントローラーやビューのコードをウィザードを使って自動生成させることが可能です。<br>
テーブルに対する CRUD 処理が一通り揃っているので、管理用のテーブルをそのまま編集する場合など、ぜひ活用してみてください。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank"><img title="Code Recipe" src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/asp.net/" target="_blank"><img title="ASP.NET デベロッパーセンター" src="-ff950935.asp_net_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net/gg490787" target="_blank">
連載! ASP.NET MVC アプリケーション開発入門一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe" target="_blank">
Code Recipe へ</a> </li><li>もっと ASP.NET の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net/" target="_blank">
ASP.NET デベロッパーセンターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
